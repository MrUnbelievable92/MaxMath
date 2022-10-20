using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
	{
		public static partial class constexpr
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_EQ_EPU8(v128 v, uint cmpVal, byte elements = 16)
			{
				switch (elements)
				{
					case  1: return IS_TRUE(v.Byte0  == cmpVal);

					case  2: return IS_TRUE(v.Byte0  == cmpVal)
								 && IS_TRUE(v.Byte1  == cmpVal);
									
					case  3: return IS_TRUE(v.Byte0  == cmpVal)
								 && IS_TRUE(v.Byte1  == cmpVal)
								 && IS_TRUE(v.Byte2  == cmpVal);

					case  4: return IS_TRUE(v.Byte0  == cmpVal)
								 && IS_TRUE(v.Byte1  == cmpVal)
								 && IS_TRUE(v.Byte2  == cmpVal)
								 && IS_TRUE(v.Byte3  == cmpVal);

					case  8: return IS_TRUE(v.Byte0  == cmpVal)
								 && IS_TRUE(v.Byte1  == cmpVal)
								 && IS_TRUE(v.Byte2  == cmpVal)
								 && IS_TRUE(v.Byte3  == cmpVal)
								 && IS_TRUE(v.Byte4  == cmpVal)
								 && IS_TRUE(v.Byte5  == cmpVal)
								 && IS_TRUE(v.Byte6  == cmpVal)
								 && IS_TRUE(v.Byte7  == cmpVal);

					default: return IS_TRUE(v.Byte0  == cmpVal)
								 && IS_TRUE(v.Byte1  == cmpVal)
								 && IS_TRUE(v.Byte2  == cmpVal)
								 && IS_TRUE(v.Byte3  == cmpVal)
								 && IS_TRUE(v.Byte4  == cmpVal)
								 && IS_TRUE(v.Byte5  == cmpVal)
								 && IS_TRUE(v.Byte6  == cmpVal)
								 && IS_TRUE(v.Byte7  == cmpVal)
								 && IS_TRUE(v.Byte8  == cmpVal)
								 && IS_TRUE(v.Byte9  == cmpVal)
								 && IS_TRUE(v.Byte10 == cmpVal)
								 && IS_TRUE(v.Byte11 == cmpVal)
								 && IS_TRUE(v.Byte12 == cmpVal)
								 && IS_TRUE(v.Byte13 == cmpVal)
								 && IS_TRUE(v.Byte14 == cmpVal)
								 && IS_TRUE(v.Byte15 == cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_EQ_EPU16(v128 v, uint cmpVal, byte elements = 8)
			{
				switch (elements)
				{
					case  1: return IS_TRUE(v.UShort0  == cmpVal);

					case  2: return IS_TRUE(v.UShort0  == cmpVal)
								 && IS_TRUE(v.UShort1  == cmpVal);

					case  3: return IS_TRUE(v.UShort0  == cmpVal)
								 && IS_TRUE(v.UShort1  == cmpVal)
								 && IS_TRUE(v.UShort2  == cmpVal);

					case  4: return IS_TRUE(v.UShort0  == cmpVal)
								 && IS_TRUE(v.UShort1  == cmpVal)
								 && IS_TRUE(v.UShort2  == cmpVal)
								 && IS_TRUE(v.UShort3  == cmpVal);

					default: return IS_TRUE(v.UShort0  == cmpVal)
								 && IS_TRUE(v.UShort1  == cmpVal)
								 && IS_TRUE(v.UShort2  == cmpVal)
								 && IS_TRUE(v.UShort3  == cmpVal)
								 && IS_TRUE(v.UShort4  == cmpVal)
								 && IS_TRUE(v.UShort5  == cmpVal)
								 && IS_TRUE(v.UShort6  == cmpVal)
								 && IS_TRUE(v.UShort7  == cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_EQ_EPU32(v128 v, uint cmpVal, byte elements = 4)
			{
				switch (elements)
				{
					case  1: return IS_TRUE(v.UInt0  == cmpVal);

					case  2: return IS_TRUE(v.UInt0  == cmpVal)
								 && IS_TRUE(v.UInt1  == cmpVal);

					case  3: return IS_TRUE(v.UInt0  == cmpVal)
								 && IS_TRUE(v.UInt1  == cmpVal)
								 && IS_TRUE(v.UInt2  == cmpVal);

					default: return IS_TRUE(v.UInt0  == cmpVal)
								 && IS_TRUE(v.UInt1  == cmpVal)
								 && IS_TRUE(v.UInt2  == cmpVal)
								 && IS_TRUE(v.UInt3  == cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_EQ_EPU64(v128 v, ulong cmpVal, byte elements = 2)
			{
                if (elements == 1)
                {
					return IS_TRUE(v.ULong0 == cmpVal);
                }
				else
				{
					return IS_TRUE(v.ULong0 == cmpVal)
						&& IS_TRUE(v.ULong1 == cmpVal);
				}
			}
			
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_EQ_EPI8(v128 v, int cmpVal, byte elements = 16)
			{
				switch (elements)
				{
					case  1: return IS_TRUE(v.SByte0  == cmpVal);

					case  2: return IS_TRUE(v.SByte0  == cmpVal)
								 && IS_TRUE(v.SByte1  == cmpVal);

					case  3: return IS_TRUE(v.SByte0  == cmpVal)
								 && IS_TRUE(v.SByte1  == cmpVal)
								 && IS_TRUE(v.SByte2  == cmpVal);

					case  4: return IS_TRUE(v.SByte0  == cmpVal)
								 && IS_TRUE(v.SByte1  == cmpVal)
								 && IS_TRUE(v.SByte2  == cmpVal)
								 && IS_TRUE(v.SByte3  == cmpVal);

					case  8: return IS_TRUE(v.SByte0  == cmpVal)
								 && IS_TRUE(v.SByte1  == cmpVal)
								 && IS_TRUE(v.SByte2  == cmpVal)
								 && IS_TRUE(v.SByte3  == cmpVal)
								 && IS_TRUE(v.SByte4  == cmpVal)
								 && IS_TRUE(v.SByte5  == cmpVal)
								 && IS_TRUE(v.SByte6  == cmpVal)
								 && IS_TRUE(v.SByte7  == cmpVal);

					default: return IS_TRUE(v.SByte0  == cmpVal)
								 && IS_TRUE(v.SByte1  == cmpVal)
								 && IS_TRUE(v.SByte2  == cmpVal)
								 && IS_TRUE(v.SByte3  == cmpVal)
								 && IS_TRUE(v.SByte4  == cmpVal)
								 && IS_TRUE(v.SByte5  == cmpVal)
								 && IS_TRUE(v.SByte6  == cmpVal)
								 && IS_TRUE(v.SByte7  == cmpVal)
								 && IS_TRUE(v.SByte8  == cmpVal)
								 && IS_TRUE(v.SByte9  == cmpVal)
								 && IS_TRUE(v.SByte10 == cmpVal)
								 && IS_TRUE(v.SByte11 == cmpVal)
								 && IS_TRUE(v.SByte12 == cmpVal)
								 && IS_TRUE(v.SByte13 == cmpVal)
								 && IS_TRUE(v.SByte14 == cmpVal)
								 && IS_TRUE(v.SByte15 == cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_EQ_EPI16(v128 v, int cmpVal, byte elements = 8)
			{
				switch (elements)
				{
					case  1: return IS_TRUE(v.SShort0 == cmpVal);

					case  2: return IS_TRUE(v.SShort0 == cmpVal)
								 && IS_TRUE(v.SShort1 == cmpVal);

					case  3: return IS_TRUE(v.SShort0 == cmpVal)
								 && IS_TRUE(v.SShort1 == cmpVal)
								 && IS_TRUE(v.SShort2 == cmpVal);

					case  4: return IS_TRUE(v.SShort0 == cmpVal)
								 && IS_TRUE(v.SShort1 == cmpVal)
								 && IS_TRUE(v.SShort2 == cmpVal)
								 && IS_TRUE(v.SShort3 == cmpVal);

					default: return IS_TRUE(v.SShort0 == cmpVal)
								 && IS_TRUE(v.SShort1 == cmpVal)
								 && IS_TRUE(v.SShort2 == cmpVal)
								 && IS_TRUE(v.SShort3 == cmpVal)
								 && IS_TRUE(v.SShort4 == cmpVal)
								 && IS_TRUE(v.SShort5 == cmpVal)
								 && IS_TRUE(v.SShort6 == cmpVal)
								 && IS_TRUE(v.SShort7 == cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_EQ_EPI32(v128 v, int cmpVal, byte elements = 4)
			{
				switch (elements)
				{
					case  1: return IS_TRUE(v.SInt0 == cmpVal);

					case  2: return IS_TRUE(v.SInt0 == cmpVal)
								 && IS_TRUE(v.SInt1 == cmpVal);

					case  3: return IS_TRUE(v.SInt0 == cmpVal)
								 && IS_TRUE(v.SInt1 == cmpVal)
								 && IS_TRUE(v.SInt2 == cmpVal);

					default: return IS_TRUE(v.SInt0 == cmpVal)
								 && IS_TRUE(v.SInt1 == cmpVal)
								 && IS_TRUE(v.SInt2 == cmpVal)
								 && IS_TRUE(v.SInt3 == cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_EQ_EPI64(v128 v, long cmpVal, byte elements = 2)
			{
                if (elements == 1)
                {
					return IS_TRUE(v.SLong0 == cmpVal);
                }
				else
				{
					return IS_TRUE(v.SLong0 == cmpVal)
						&& IS_TRUE(v.SLong1 == cmpVal);
				}
			}
			
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_EQ_PS(v128 v, float cmpVal, byte elements = 4)
			{
				switch (elements)
				{
					case  1: return IS_TRUE(v.Float0 == cmpVal);

					case  2: return IS_TRUE(v.Float0 == cmpVal)
								 && IS_TRUE(v.Float1 == cmpVal);

					case  3: return IS_TRUE(v.Float0 == cmpVal)
								 && IS_TRUE(v.Float1 == cmpVal)
								 && IS_TRUE(v.Float2 == cmpVal);

					default: return IS_TRUE(v.Float0 == cmpVal)
								 && IS_TRUE(v.Float1 == cmpVal)
								 && IS_TRUE(v.Float2 == cmpVal)
								 && IS_TRUE(v.Float3 == cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_EQ_PD(v128 v, double cmpVal, byte elements = 2)
			{
                if (elements == 1)
                {
					return IS_TRUE(v.Double0 == cmpVal);
                }
				else
				{
					return IS_TRUE(v.Double0 == cmpVal)
						&& IS_TRUE(v.Double1 == cmpVal);
				}
			}


			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_EQ_EPI8(v256 v, int cmpVal)
			{
				return IS_TRUE(v.SByte0  == cmpVal)
					&& IS_TRUE(v.SByte1  == cmpVal)
					&& IS_TRUE(v.SByte2  == cmpVal)
					&& IS_TRUE(v.SByte3  == cmpVal)
					&& IS_TRUE(v.SByte4  == cmpVal)
					&& IS_TRUE(v.SByte5  == cmpVal)
					&& IS_TRUE(v.SByte6  == cmpVal)
					&& IS_TRUE(v.SByte7  == cmpVal)
					&& IS_TRUE(v.SByte8  == cmpVal)
					&& IS_TRUE(v.SByte9  == cmpVal)
					&& IS_TRUE(v.SByte10 == cmpVal)
					&& IS_TRUE(v.SByte11 == cmpVal)
					&& IS_TRUE(v.SByte12 == cmpVal)
					&& IS_TRUE(v.SByte13 == cmpVal)
					&& IS_TRUE(v.SByte14 == cmpVal)
					&& IS_TRUE(v.SByte15 == cmpVal)
				    && IS_TRUE(v.SByte16 == cmpVal)
					&& IS_TRUE(v.SByte17 == cmpVal)
					&& IS_TRUE(v.SByte18 == cmpVal)
					&& IS_TRUE(v.SByte19 == cmpVal)
					&& IS_TRUE(v.SByte20 == cmpVal)
					&& IS_TRUE(v.SByte21 == cmpVal)
					&& IS_TRUE(v.SByte22 == cmpVal)
					&& IS_TRUE(v.SByte23 == cmpVal)
					&& IS_TRUE(v.SByte24 == cmpVal)
					&& IS_TRUE(v.SByte25 == cmpVal)
					&& IS_TRUE(v.SByte26 == cmpVal)
					&& IS_TRUE(v.SByte27 == cmpVal)
					&& IS_TRUE(v.SByte28 == cmpVal)
					&& IS_TRUE(v.SByte29 == cmpVal)
					&& IS_TRUE(v.SByte30 == cmpVal)
					&& IS_TRUE(v.SByte31 == cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_EQ_EPI16(v256 v, int cmpVal)
			{
				return IS_TRUE(v.SShort0  == cmpVal)
					&& IS_TRUE(v.SShort1  == cmpVal)
					&& IS_TRUE(v.SShort2  == cmpVal)
					&& IS_TRUE(v.SShort3  == cmpVal)
					&& IS_TRUE(v.SShort4  == cmpVal)
					&& IS_TRUE(v.SShort5  == cmpVal)
					&& IS_TRUE(v.SShort6  == cmpVal)
					&& IS_TRUE(v.SShort7  == cmpVal)
					&& IS_TRUE(v.SShort8  == cmpVal)
					&& IS_TRUE(v.SShort9  == cmpVal)
					&& IS_TRUE(v.SShort10 == cmpVal)
					&& IS_TRUE(v.SShort11 == cmpVal)
					&& IS_TRUE(v.SShort12 == cmpVal)
					&& IS_TRUE(v.SShort13 == cmpVal)
					&& IS_TRUE(v.SShort14 == cmpVal)
					&& IS_TRUE(v.SShort15 == cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_EQ_EPI32(v256 v, int cmpVal)
			{
				return IS_TRUE(v.SInt0 == cmpVal)
					&& IS_TRUE(v.SInt1 == cmpVal)
					&& IS_TRUE(v.SInt2 == cmpVal)
					&& IS_TRUE(v.SInt3 == cmpVal)
					&& IS_TRUE(v.SInt4 == cmpVal)
					&& IS_TRUE(v.SInt5 == cmpVal)
					&& IS_TRUE(v.SInt6 == cmpVal)
					&& IS_TRUE(v.SInt7 == cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_EQ_EPI64(v256 v, long cmpVal, byte elements = 4)
			{
				if (elements == 3)
				{
					return IS_TRUE(v.SLong0 == cmpVal)
						&& IS_TRUE(v.SLong1 == cmpVal)
						&& IS_TRUE(v.SLong2 == cmpVal);
				}
				else
				{
					return IS_TRUE(v.SLong0 == cmpVal)
						&& IS_TRUE(v.SLong1 == cmpVal)
						&& IS_TRUE(v.SLong2 == cmpVal)
						&& IS_TRUE(v.SLong3 == cmpVal);
				}
			}
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_EQ_EPU8(v256 v, uint cmpVal)
			{
				return IS_TRUE(v.Byte0  == cmpVal)
					&& IS_TRUE(v.Byte1  == cmpVal)
					&& IS_TRUE(v.Byte2  == cmpVal)
					&& IS_TRUE(v.Byte3  == cmpVal)
					&& IS_TRUE(v.Byte4  == cmpVal)
					&& IS_TRUE(v.Byte5  == cmpVal)
					&& IS_TRUE(v.Byte6  == cmpVal)
					&& IS_TRUE(v.Byte7  == cmpVal)
					&& IS_TRUE(v.Byte8  == cmpVal)
					&& IS_TRUE(v.Byte9  == cmpVal)
					&& IS_TRUE(v.Byte10 == cmpVal)
					&& IS_TRUE(v.Byte11 == cmpVal)
					&& IS_TRUE(v.Byte12 == cmpVal)
					&& IS_TRUE(v.Byte13 == cmpVal)
					&& IS_TRUE(v.Byte14 == cmpVal)
					&& IS_TRUE(v.Byte15 == cmpVal)
				    && IS_TRUE(v.Byte16 == cmpVal)
					&& IS_TRUE(v.Byte17 == cmpVal)
					&& IS_TRUE(v.Byte18 == cmpVal)
					&& IS_TRUE(v.Byte19 == cmpVal)
					&& IS_TRUE(v.Byte20 == cmpVal)
					&& IS_TRUE(v.Byte21 == cmpVal)
					&& IS_TRUE(v.Byte22 == cmpVal)
					&& IS_TRUE(v.Byte23 == cmpVal)
					&& IS_TRUE(v.Byte24 == cmpVal)
					&& IS_TRUE(v.Byte25 == cmpVal)
					&& IS_TRUE(v.Byte26 == cmpVal)
					&& IS_TRUE(v.Byte27 == cmpVal)
					&& IS_TRUE(v.Byte28 == cmpVal)
					&& IS_TRUE(v.Byte29 == cmpVal)
					&& IS_TRUE(v.Byte30 == cmpVal)
					&& IS_TRUE(v.Byte31 == cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_EQ_EPU16(v256 v, uint cmpVal)
			{
				return IS_TRUE(v.UShort0  == cmpVal)
					&& IS_TRUE(v.UShort1  == cmpVal)
					&& IS_TRUE(v.UShort2  == cmpVal)
					&& IS_TRUE(v.UShort3  == cmpVal)
					&& IS_TRUE(v.UShort4  == cmpVal)
					&& IS_TRUE(v.UShort5  == cmpVal)
					&& IS_TRUE(v.UShort6  == cmpVal)
					&& IS_TRUE(v.UShort7  == cmpVal)
					&& IS_TRUE(v.UShort8  == cmpVal)
					&& IS_TRUE(v.UShort9  == cmpVal)
					&& IS_TRUE(v.UShort10 == cmpVal)
					&& IS_TRUE(v.UShort11 == cmpVal)
					&& IS_TRUE(v.UShort12 == cmpVal)
					&& IS_TRUE(v.UShort13 == cmpVal)
					&& IS_TRUE(v.UShort14 == cmpVal)
					&& IS_TRUE(v.UShort15 == cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_EQ_EPU32(v256 v, uint cmpVal)
			{
				return IS_TRUE(v.UInt0 == cmpVal)
					&& IS_TRUE(v.UInt1 == cmpVal)
					&& IS_TRUE(v.UInt2 == cmpVal)
					&& IS_TRUE(v.UInt3 == cmpVal)
					&& IS_TRUE(v.UInt4 == cmpVal)
					&& IS_TRUE(v.UInt5 == cmpVal)
					&& IS_TRUE(v.UInt6 == cmpVal)
					&& IS_TRUE(v.UInt7 == cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_EQ_EPU64(v256 v, ulong cmpVal, byte elements = 4)
			{
				if (elements == 3)
				{
					return IS_TRUE(v.ULong0 == cmpVal)
						&& IS_TRUE(v.ULong1 == cmpVal)
						&& IS_TRUE(v.ULong2 == cmpVal);
				}
				else
				{
					return IS_TRUE(v.ULong0 == cmpVal)
						&& IS_TRUE(v.ULong1 == cmpVal)
						&& IS_TRUE(v.ULong2 == cmpVal)
						&& IS_TRUE(v.ULong3 == cmpVal);
				}
			}


			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_EQ_PS(v256 v, float cmpVal)
			{
				return IS_TRUE(v.Float0 == cmpVal)
					&& IS_TRUE(v.Float1 == cmpVal)
					&& IS_TRUE(v.Float2 == cmpVal)
					&& IS_TRUE(v.Float3 == cmpVal)
					&& IS_TRUE(v.Float4 == cmpVal)
					&& IS_TRUE(v.Float5 == cmpVal)
					&& IS_TRUE(v.Float6 == cmpVal)
					&& IS_TRUE(v.Float7 == cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_EQ_PD(v256 v, double cmpVal, byte elements = 4)
			{
				if (elements == 3)
				{
					return IS_TRUE(v.Double0 == cmpVal)
						&& IS_TRUE(v.Double1 == cmpVal)
						&& IS_TRUE(v.Double2 == cmpVal);
				}
				else
				{
					return IS_TRUE(v.Double0 == cmpVal)
						&& IS_TRUE(v.Double1 == cmpVal)
						&& IS_TRUE(v.Double2 == cmpVal)
						&& IS_TRUE(v.Double3 == cmpVal);
				}
			}


			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_NEQ_EPU8(v128 v, uint cmpVal, byte elements = 16)
			{
				switch (elements)
				{
					case  1: return IS_TRUE(v.Byte0  != cmpVal);

					case  2: return IS_TRUE(v.Byte0  != cmpVal)
								 && IS_TRUE(v.Byte1  != cmpVal);
									
					case  3: return IS_TRUE(v.Byte0  != cmpVal)
								 && IS_TRUE(v.Byte1  != cmpVal)
								 && IS_TRUE(v.Byte2  != cmpVal);

					case  4: return IS_TRUE(v.Byte0  != cmpVal)
								 && IS_TRUE(v.Byte1  != cmpVal)
								 && IS_TRUE(v.Byte2  != cmpVal)
								 && IS_TRUE(v.Byte3  != cmpVal);

					case  8: return IS_TRUE(v.Byte0  != cmpVal)
								 && IS_TRUE(v.Byte1  != cmpVal)
								 && IS_TRUE(v.Byte2  != cmpVal)
								 && IS_TRUE(v.Byte3  != cmpVal)
								 && IS_TRUE(v.Byte4  != cmpVal)
								 && IS_TRUE(v.Byte5  != cmpVal)
								 && IS_TRUE(v.Byte6  != cmpVal)
								 && IS_TRUE(v.Byte7  != cmpVal);

					default: return IS_TRUE(v.Byte0  != cmpVal)
								 && IS_TRUE(v.Byte1  != cmpVal)
								 && IS_TRUE(v.Byte2  != cmpVal)
								 && IS_TRUE(v.Byte3  != cmpVal)
								 && IS_TRUE(v.Byte4  != cmpVal)
								 && IS_TRUE(v.Byte5  != cmpVal)
								 && IS_TRUE(v.Byte6  != cmpVal)
								 && IS_TRUE(v.Byte7  != cmpVal)
								 && IS_TRUE(v.Byte8  != cmpVal)
								 && IS_TRUE(v.Byte9  != cmpVal)
								 && IS_TRUE(v.Byte10 != cmpVal)
								 && IS_TRUE(v.Byte11 != cmpVal)
								 && IS_TRUE(v.Byte12 != cmpVal)
								 && IS_TRUE(v.Byte13 != cmpVal)
								 && IS_TRUE(v.Byte14 != cmpVal)
								 && IS_TRUE(v.Byte15 != cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_NEQ_EPU16(v128 v, uint cmpVal, byte elements = 8)
			{
				switch (elements)
				{
					case  1: return IS_TRUE(v.UShort0  != cmpVal);

					case  2: return IS_TRUE(v.UShort0  != cmpVal)
								 && IS_TRUE(v.UShort1  != cmpVal);

					case  3: return IS_TRUE(v.UShort0  != cmpVal)
								 && IS_TRUE(v.UShort1  != cmpVal)
								 && IS_TRUE(v.UShort2  != cmpVal);

					case  4: return IS_TRUE(v.UShort0  != cmpVal)
								 && IS_TRUE(v.UShort1  != cmpVal)
								 && IS_TRUE(v.UShort2  != cmpVal)
								 && IS_TRUE(v.UShort3  != cmpVal);

					default: return IS_TRUE(v.UShort0  != cmpVal)
								 && IS_TRUE(v.UShort1  != cmpVal)
								 && IS_TRUE(v.UShort2  != cmpVal)
								 && IS_TRUE(v.UShort3  != cmpVal)
								 && IS_TRUE(v.UShort4  != cmpVal)
								 && IS_TRUE(v.UShort5  != cmpVal)
								 && IS_TRUE(v.UShort6  != cmpVal)
								 && IS_TRUE(v.UShort7  != cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_NEQ_EPU32(v128 v, uint cmpVal, byte elements = 4)
			{
				switch (elements)
				{
					case  1: return IS_TRUE(v.UInt0  != cmpVal);

					case  2: return IS_TRUE(v.UInt0  != cmpVal)
								 && IS_TRUE(v.UInt1  != cmpVal);

					case  3: return IS_TRUE(v.UInt0  != cmpVal)
								 && IS_TRUE(v.UInt1  != cmpVal)
								 && IS_TRUE(v.UInt2  != cmpVal);

					default: return IS_TRUE(v.UInt0  != cmpVal)
								 && IS_TRUE(v.UInt1  != cmpVal)
								 && IS_TRUE(v.UInt2  != cmpVal)
								 && IS_TRUE(v.UInt3  != cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_NEQ_EPU64(v128 v, ulong cmpVal, byte elements = 2)
			{
                if (elements == 1)
                {
					return IS_TRUE(v.ULong0 != cmpVal);
                }
				else
				{
					return IS_TRUE(v.ULong0 != cmpVal)
						&& IS_TRUE(v.ULong1 != cmpVal);
				}
			}
			
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_NEQ_EPI8(v128 v, int cmpVal, byte elements = 16)
			{
				switch (elements)
				{
					case  1: return IS_TRUE(v.SByte0  != cmpVal);

					case  2: return IS_TRUE(v.SByte0  != cmpVal)
								 && IS_TRUE(v.SByte1  != cmpVal);

					case  3: return IS_TRUE(v.SByte0  != cmpVal)
								 && IS_TRUE(v.SByte1  != cmpVal)
								 && IS_TRUE(v.SByte2  != cmpVal);

					case  4: return IS_TRUE(v.SByte0  != cmpVal)
								 && IS_TRUE(v.SByte1  != cmpVal)
								 && IS_TRUE(v.SByte2  != cmpVal)
								 && IS_TRUE(v.SByte3  != cmpVal);

					case  8: return IS_TRUE(v.SByte0  != cmpVal)
								 && IS_TRUE(v.SByte1  != cmpVal)
								 && IS_TRUE(v.SByte2  != cmpVal)
								 && IS_TRUE(v.SByte3  != cmpVal)
								 && IS_TRUE(v.SByte4  != cmpVal)
								 && IS_TRUE(v.SByte5  != cmpVal)
								 && IS_TRUE(v.SByte6  != cmpVal)
								 && IS_TRUE(v.SByte7  != cmpVal);

					default: return IS_TRUE(v.SByte0  != cmpVal)
								 && IS_TRUE(v.SByte1  != cmpVal)
								 && IS_TRUE(v.SByte2  != cmpVal)
								 && IS_TRUE(v.SByte3  != cmpVal)
								 && IS_TRUE(v.SByte4  != cmpVal)
								 && IS_TRUE(v.SByte5  != cmpVal)
								 && IS_TRUE(v.SByte6  != cmpVal)
								 && IS_TRUE(v.SByte7  != cmpVal)
								 && IS_TRUE(v.SByte8  != cmpVal)
								 && IS_TRUE(v.SByte9  != cmpVal)
								 && IS_TRUE(v.SByte10 != cmpVal)
								 && IS_TRUE(v.SByte11 != cmpVal)
								 && IS_TRUE(v.SByte12 != cmpVal)
								 && IS_TRUE(v.SByte13 != cmpVal)
								 && IS_TRUE(v.SByte14 != cmpVal)
								 && IS_TRUE(v.SByte15 != cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_NEQ_EPI16(v128 v, int cmpVal, byte elements = 8)
			{
				switch (elements)
				{
					case  1: return IS_TRUE(v.SShort0 != cmpVal);

					case  2: return IS_TRUE(v.SShort0 != cmpVal)
								 && IS_TRUE(v.SShort1 != cmpVal);

					case  3: return IS_TRUE(v.SShort0 != cmpVal)
								 && IS_TRUE(v.SShort1 != cmpVal)
								 && IS_TRUE(v.SShort2 != cmpVal);

					case  4: return IS_TRUE(v.SShort0 != cmpVal)
								 && IS_TRUE(v.SShort1 != cmpVal)
								 && IS_TRUE(v.SShort2 != cmpVal)
								 && IS_TRUE(v.SShort3 != cmpVal);

					default: return IS_TRUE(v.SShort0 != cmpVal)
								 && IS_TRUE(v.SShort1 != cmpVal)
								 && IS_TRUE(v.SShort2 != cmpVal)
								 && IS_TRUE(v.SShort3 != cmpVal)
								 && IS_TRUE(v.SShort4 != cmpVal)
								 && IS_TRUE(v.SShort5 != cmpVal)
								 && IS_TRUE(v.SShort6 != cmpVal)
								 && IS_TRUE(v.SShort7 != cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_NEQ_EPI32(v128 v, int cmpVal, byte elements = 4)
			{
				switch (elements)
				{
					case  1: return IS_TRUE(v.SInt0 != cmpVal);

					case  2: return IS_TRUE(v.SInt0 != cmpVal)
								 && IS_TRUE(v.SInt1 != cmpVal);

					case  3: return IS_TRUE(v.SInt0 != cmpVal)
								 && IS_TRUE(v.SInt1 != cmpVal)
								 && IS_TRUE(v.SInt2 != cmpVal);

					default: return IS_TRUE(v.SInt0 != cmpVal)
								 && IS_TRUE(v.SInt1 != cmpVal)
								 && IS_TRUE(v.SInt2 != cmpVal)
								 && IS_TRUE(v.SInt3 != cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_NEQ_EPI64(v128 v, long cmpVal, byte elements = 2)
			{
                if (elements == 1)
                {
					return IS_TRUE(v.SLong0 != cmpVal);
                }
				else
				{
					return IS_TRUE(v.SLong0 != cmpVal)
						&& IS_TRUE(v.SLong1 != cmpVal);
				}
			}
			
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_NEQ_PS(v128 v, float cmpVal, byte elements = 4)
			{
				switch (elements)
				{
					case  1: return IS_TRUE(v.Float0 != cmpVal);

					case  2: return IS_TRUE(v.Float0 != cmpVal)
								 && IS_TRUE(v.Float1 != cmpVal);

					case  3: return IS_TRUE(v.Float0 != cmpVal)
								 && IS_TRUE(v.Float1 != cmpVal)
								 && IS_TRUE(v.Float2 != cmpVal);

					default: return IS_TRUE(v.Float0 != cmpVal)
								 && IS_TRUE(v.Float1 != cmpVal)
								 && IS_TRUE(v.Float2 != cmpVal)
								 && IS_TRUE(v.Float3 != cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_NEQ_PD(v128 v, double cmpVal, byte elements = 2)
			{
                if (elements == 1)
                {
					return IS_TRUE(v.Double0 != cmpVal);
                }
				else
				{
					return IS_TRUE(v.Double0 != cmpVal)
						&& IS_TRUE(v.Double1 != cmpVal);
				}
			}


			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_NEQ_EPI8(v256 v, int cmpVal)
			{
				return IS_TRUE(v.SByte0  != cmpVal)
					&& IS_TRUE(v.SByte1  != cmpVal)
					&& IS_TRUE(v.SByte2  != cmpVal)
					&& IS_TRUE(v.SByte3  != cmpVal)
					&& IS_TRUE(v.SByte4  != cmpVal)
					&& IS_TRUE(v.SByte5  != cmpVal)
					&& IS_TRUE(v.SByte6  != cmpVal)
					&& IS_TRUE(v.SByte7  != cmpVal)
					&& IS_TRUE(v.SByte8  != cmpVal)
					&& IS_TRUE(v.SByte9  != cmpVal)
					&& IS_TRUE(v.SByte10 != cmpVal)
					&& IS_TRUE(v.SByte11 != cmpVal)
					&& IS_TRUE(v.SByte12 != cmpVal)
					&& IS_TRUE(v.SByte13 != cmpVal)
					&& IS_TRUE(v.SByte14 != cmpVal)
					&& IS_TRUE(v.SByte15 != cmpVal)
				    && IS_TRUE(v.SByte16 != cmpVal)
					&& IS_TRUE(v.SByte17 != cmpVal)
					&& IS_TRUE(v.SByte18 != cmpVal)
					&& IS_TRUE(v.SByte19 != cmpVal)
					&& IS_TRUE(v.SByte20 != cmpVal)
					&& IS_TRUE(v.SByte21 != cmpVal)
					&& IS_TRUE(v.SByte22 != cmpVal)
					&& IS_TRUE(v.SByte23 != cmpVal)
					&& IS_TRUE(v.SByte24 != cmpVal)
					&& IS_TRUE(v.SByte25 != cmpVal)
					&& IS_TRUE(v.SByte26 != cmpVal)
					&& IS_TRUE(v.SByte27 != cmpVal)
					&& IS_TRUE(v.SByte28 != cmpVal)
					&& IS_TRUE(v.SByte29 != cmpVal)
					&& IS_TRUE(v.SByte30 != cmpVal)
					&& IS_TRUE(v.SByte31 != cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_NEQ_EPI16(v256 v, int cmpVal)
			{
				return IS_TRUE(v.SShort0  != cmpVal)
					&& IS_TRUE(v.SShort1  != cmpVal)
					&& IS_TRUE(v.SShort2  != cmpVal)
					&& IS_TRUE(v.SShort3  != cmpVal)
					&& IS_TRUE(v.SShort4  != cmpVal)
					&& IS_TRUE(v.SShort5  != cmpVal)
					&& IS_TRUE(v.SShort6  != cmpVal)
					&& IS_TRUE(v.SShort7  != cmpVal)
					&& IS_TRUE(v.SShort8  != cmpVal)
					&& IS_TRUE(v.SShort9  != cmpVal)
					&& IS_TRUE(v.SShort10 != cmpVal)
					&& IS_TRUE(v.SShort11 != cmpVal)
					&& IS_TRUE(v.SShort12 != cmpVal)
					&& IS_TRUE(v.SShort13 != cmpVal)
					&& IS_TRUE(v.SShort14 != cmpVal)
					&& IS_TRUE(v.SShort15 != cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_NEQ_EPI32(v256 v, int cmpVal)
			{
				return IS_TRUE(v.SInt0 != cmpVal)
					&& IS_TRUE(v.SInt1 != cmpVal)
					&& IS_TRUE(v.SInt2 != cmpVal)
					&& IS_TRUE(v.SInt3 != cmpVal)
					&& IS_TRUE(v.SInt4 != cmpVal)
					&& IS_TRUE(v.SInt5 != cmpVal)
					&& IS_TRUE(v.SInt6 != cmpVal)
					&& IS_TRUE(v.SInt7 != cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_NEQ_EPI64(v256 v, long cmpVal, byte elements = 4)
			{
				if (elements == 3)
				{
					return IS_TRUE(v.SLong0 != cmpVal)
						&& IS_TRUE(v.SLong1 != cmpVal)
						&& IS_TRUE(v.SLong2 != cmpVal);
				}
				else
				{
					return IS_TRUE(v.SLong0 != cmpVal)
						&& IS_TRUE(v.SLong1 != cmpVal)
						&& IS_TRUE(v.SLong2 != cmpVal)
						&& IS_TRUE(v.SLong3 != cmpVal);
				}
			}
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_NEQ_EPU8(v256 v, uint cmpVal)
			{
				return IS_TRUE(v.Byte0  != cmpVal)
					&& IS_TRUE(v.Byte1  != cmpVal)
					&& IS_TRUE(v.Byte2  != cmpVal)
					&& IS_TRUE(v.Byte3  != cmpVal)
					&& IS_TRUE(v.Byte4  != cmpVal)
					&& IS_TRUE(v.Byte5  != cmpVal)
					&& IS_TRUE(v.Byte6  != cmpVal)
					&& IS_TRUE(v.Byte7  != cmpVal)
					&& IS_TRUE(v.Byte8  != cmpVal)
					&& IS_TRUE(v.Byte9  != cmpVal)
					&& IS_TRUE(v.Byte10 != cmpVal)
					&& IS_TRUE(v.Byte11 != cmpVal)
					&& IS_TRUE(v.Byte12 != cmpVal)
					&& IS_TRUE(v.Byte13 != cmpVal)
					&& IS_TRUE(v.Byte14 != cmpVal)
					&& IS_TRUE(v.Byte15 != cmpVal)
				    && IS_TRUE(v.Byte16 != cmpVal)
					&& IS_TRUE(v.Byte17 != cmpVal)
					&& IS_TRUE(v.Byte18 != cmpVal)
					&& IS_TRUE(v.Byte19 != cmpVal)
					&& IS_TRUE(v.Byte20 != cmpVal)
					&& IS_TRUE(v.Byte21 != cmpVal)
					&& IS_TRUE(v.Byte22 != cmpVal)
					&& IS_TRUE(v.Byte23 != cmpVal)
					&& IS_TRUE(v.Byte24 != cmpVal)
					&& IS_TRUE(v.Byte25 != cmpVal)
					&& IS_TRUE(v.Byte26 != cmpVal)
					&& IS_TRUE(v.Byte27 != cmpVal)
					&& IS_TRUE(v.Byte28 != cmpVal)
					&& IS_TRUE(v.Byte29 != cmpVal)
					&& IS_TRUE(v.Byte30 != cmpVal)
					&& IS_TRUE(v.Byte31 != cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_NEQ_EPU16(v256 v, uint cmpVal)
			{
				return IS_TRUE(v.UShort0  != cmpVal)
					&& IS_TRUE(v.UShort1  != cmpVal)
					&& IS_TRUE(v.UShort2  != cmpVal)
					&& IS_TRUE(v.UShort3  != cmpVal)
					&& IS_TRUE(v.UShort4  != cmpVal)
					&& IS_TRUE(v.UShort5  != cmpVal)
					&& IS_TRUE(v.UShort6  != cmpVal)
					&& IS_TRUE(v.UShort7  != cmpVal)
					&& IS_TRUE(v.UShort8  != cmpVal)
					&& IS_TRUE(v.UShort9  != cmpVal)
					&& IS_TRUE(v.UShort10 != cmpVal)
					&& IS_TRUE(v.UShort11 != cmpVal)
					&& IS_TRUE(v.UShort12 != cmpVal)
					&& IS_TRUE(v.UShort13 != cmpVal)
					&& IS_TRUE(v.UShort14 != cmpVal)
					&& IS_TRUE(v.UShort15 != cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_NEQ_EPU32(v256 v, uint cmpVal)
			{
				return IS_TRUE(v.UInt0 != cmpVal)
					&& IS_TRUE(v.UInt1 != cmpVal)
					&& IS_TRUE(v.UInt2 != cmpVal)
					&& IS_TRUE(v.UInt3 != cmpVal)
					&& IS_TRUE(v.UInt4 != cmpVal)
					&& IS_TRUE(v.UInt5 != cmpVal)
					&& IS_TRUE(v.UInt6 != cmpVal)
					&& IS_TRUE(v.UInt7 != cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_NEQ_EPU64(v256 v, ulong cmpVal, byte elements = 4)
			{
				if (elements == 3)
				{
					return IS_TRUE(v.ULong0 != cmpVal)
						&& IS_TRUE(v.ULong1 != cmpVal)
						&& IS_TRUE(v.ULong2 != cmpVal);
				}
				else
				{
					return IS_TRUE(v.ULong0 != cmpVal)
						&& IS_TRUE(v.ULong1 != cmpVal)
						&& IS_TRUE(v.ULong2 != cmpVal)
						&& IS_TRUE(v.ULong3 != cmpVal);
				}
			}


			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_NEQ_PS(v256 v, float cmpVal)
			{
				return IS_TRUE(v.Float0 != cmpVal)
					&& IS_TRUE(v.Float1 != cmpVal)
					&& IS_TRUE(v.Float2 != cmpVal)
					&& IS_TRUE(v.Float3 != cmpVal)
					&& IS_TRUE(v.Float4 != cmpVal)
					&& IS_TRUE(v.Float5 != cmpVal)
					&& IS_TRUE(v.Float6 != cmpVal)
					&& IS_TRUE(v.Float7 != cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_NEQ_PD(v256 v, double cmpVal, byte elements = 4)
			{
				if (elements == 3)
				{
					return IS_TRUE(v.Double0 != cmpVal)
						&& IS_TRUE(v.Double1 != cmpVal)
						&& IS_TRUE(v.Double2 != cmpVal);
				}
				else
				{
					return IS_TRUE(v.Double0 != cmpVal)
						&& IS_TRUE(v.Double1 != cmpVal)
						&& IS_TRUE(v.Double2 != cmpVal)
						&& IS_TRUE(v.Double3 != cmpVal);
				}
			}


			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_GT_EPU8(v128 v, uint cmpVal, byte elements = 16)
			{
				switch (elements)
				{
					case  1: return IS_TRUE(v.Byte0  > cmpVal);

					case  2: return IS_TRUE(v.Byte0  > cmpVal)
								 && IS_TRUE(v.Byte1  > cmpVal);
									
					case  3: return IS_TRUE(v.Byte0  > cmpVal)
								 && IS_TRUE(v.Byte1  > cmpVal)
								 && IS_TRUE(v.Byte2  > cmpVal);

					case  4: return IS_TRUE(v.Byte0  > cmpVal)
								 && IS_TRUE(v.Byte1  > cmpVal)
								 && IS_TRUE(v.Byte2  > cmpVal)
								 && IS_TRUE(v.Byte3  > cmpVal);

					case  8: return IS_TRUE(v.Byte0  > cmpVal)
								 && IS_TRUE(v.Byte1  > cmpVal)
								 && IS_TRUE(v.Byte2  > cmpVal)
								 && IS_TRUE(v.Byte3  > cmpVal)
								 && IS_TRUE(v.Byte4  > cmpVal)
								 && IS_TRUE(v.Byte5  > cmpVal)
								 && IS_TRUE(v.Byte6  > cmpVal)
								 && IS_TRUE(v.Byte7  > cmpVal);

					default: return IS_TRUE(v.Byte0  > cmpVal)
								 && IS_TRUE(v.Byte1  > cmpVal)
								 && IS_TRUE(v.Byte2  > cmpVal)
								 && IS_TRUE(v.Byte3  > cmpVal)
								 && IS_TRUE(v.Byte4  > cmpVal)
								 && IS_TRUE(v.Byte5  > cmpVal)
								 && IS_TRUE(v.Byte6  > cmpVal)
								 && IS_TRUE(v.Byte7  > cmpVal)
								 && IS_TRUE(v.Byte8  > cmpVal)
								 && IS_TRUE(v.Byte9  > cmpVal)
								 && IS_TRUE(v.Byte10 > cmpVal)
								 && IS_TRUE(v.Byte11 > cmpVal)
								 && IS_TRUE(v.Byte12 > cmpVal)
								 && IS_TRUE(v.Byte13 > cmpVal)
								 && IS_TRUE(v.Byte14 > cmpVal)
								 && IS_TRUE(v.Byte15 > cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_GT_EPU16(v128 v, uint cmpVal, byte elements = 8)
			{
				switch (elements)
				{
					case  1: return IS_TRUE(v.UShort0  > cmpVal);

					case  2: return IS_TRUE(v.UShort0  > cmpVal)
								 && IS_TRUE(v.UShort1  > cmpVal);

					case  3: return IS_TRUE(v.UShort0  > cmpVal)
								 && IS_TRUE(v.UShort1  > cmpVal)
								 && IS_TRUE(v.UShort2  > cmpVal);

					case  4: return IS_TRUE(v.UShort0  > cmpVal)
								 && IS_TRUE(v.UShort1  > cmpVal)
								 && IS_TRUE(v.UShort2  > cmpVal)
								 && IS_TRUE(v.UShort3  > cmpVal);

					default: return IS_TRUE(v.UShort0  > cmpVal)
								 && IS_TRUE(v.UShort1  > cmpVal)
								 && IS_TRUE(v.UShort2  > cmpVal)
								 && IS_TRUE(v.UShort3  > cmpVal)
								 && IS_TRUE(v.UShort4  > cmpVal)
								 && IS_TRUE(v.UShort5  > cmpVal)
								 && IS_TRUE(v.UShort6  > cmpVal)
								 && IS_TRUE(v.UShort7  > cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_GT_EPU32(v128 v, uint cmpVal, byte elements = 4)
			{
				switch (elements)
				{
					case  1: return IS_TRUE(v.UInt0  > cmpVal);

					case  2: return IS_TRUE(v.UInt0  > cmpVal)
								 && IS_TRUE(v.UInt1  > cmpVal);

					case  3: return IS_TRUE(v.UInt0  > cmpVal)
								 && IS_TRUE(v.UInt1  > cmpVal)
								 && IS_TRUE(v.UInt2  > cmpVal);

					default: return IS_TRUE(v.UInt0  > cmpVal)
								 && IS_TRUE(v.UInt1  > cmpVal)
								 && IS_TRUE(v.UInt2  > cmpVal)
								 && IS_TRUE(v.UInt3  > cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_GT_EPU64(v128 v, ulong cmpVal, byte elements = 2)
			{
                if (elements == 1)
                {
					return IS_TRUE(v.ULong0 > cmpVal);
                }
				else
				{
					return IS_TRUE(v.ULong0 > cmpVal)
						&& IS_TRUE(v.ULong1 > cmpVal);
				}
			}
			
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_GT_EPI8(v128 v, int cmpVal, byte elements = 16)
			{
				switch (elements)
				{
					case  1: return IS_TRUE(v.SByte0  > cmpVal);

					case  2: return IS_TRUE(v.SByte0  > cmpVal)
								 && IS_TRUE(v.SByte1  > cmpVal);

					case  3: return IS_TRUE(v.SByte0  > cmpVal)
								 && IS_TRUE(v.SByte1  > cmpVal)
								 && IS_TRUE(v.SByte2  > cmpVal);

					case  4: return IS_TRUE(v.SByte0  > cmpVal)
								 && IS_TRUE(v.SByte1  > cmpVal)
								 && IS_TRUE(v.SByte2  > cmpVal)
								 && IS_TRUE(v.SByte3  > cmpVal);

					case  8: return IS_TRUE(v.SByte0  > cmpVal)
								 && IS_TRUE(v.SByte1  > cmpVal)
								 && IS_TRUE(v.SByte2  > cmpVal)
								 && IS_TRUE(v.SByte3  > cmpVal)
								 && IS_TRUE(v.SByte4  > cmpVal)
								 && IS_TRUE(v.SByte5  > cmpVal)
								 && IS_TRUE(v.SByte6  > cmpVal)
								 && IS_TRUE(v.SByte7  > cmpVal);

					default: return IS_TRUE(v.SByte0  > cmpVal)
								 && IS_TRUE(v.SByte1  > cmpVal)
								 && IS_TRUE(v.SByte2  > cmpVal)
								 && IS_TRUE(v.SByte3  > cmpVal)
								 && IS_TRUE(v.SByte4  > cmpVal)
								 && IS_TRUE(v.SByte5  > cmpVal)
								 && IS_TRUE(v.SByte6  > cmpVal)
								 && IS_TRUE(v.SByte7  > cmpVal)
								 && IS_TRUE(v.SByte8  > cmpVal)
								 && IS_TRUE(v.SByte9  > cmpVal)
								 && IS_TRUE(v.SByte10 > cmpVal)
								 && IS_TRUE(v.SByte11 > cmpVal)
								 && IS_TRUE(v.SByte12 > cmpVal)
								 && IS_TRUE(v.SByte13 > cmpVal)
								 && IS_TRUE(v.SByte14 > cmpVal)
								 && IS_TRUE(v.SByte15 > cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_GT_EPI16(v128 v, int cmpVal, byte elements = 8)
			{
				switch (elements)
				{
					case  1: return IS_TRUE(v.SShort0 > cmpVal);

					case  2: return IS_TRUE(v.SShort0 > cmpVal)
								 && IS_TRUE(v.SShort1 > cmpVal);

					case  3: return IS_TRUE(v.SShort0 > cmpVal)
								 && IS_TRUE(v.SShort1 > cmpVal)
								 && IS_TRUE(v.SShort2 > cmpVal);

					case  4: return IS_TRUE(v.SShort0 > cmpVal)
								 && IS_TRUE(v.SShort1 > cmpVal)
								 && IS_TRUE(v.SShort2 > cmpVal)
								 && IS_TRUE(v.SShort3 > cmpVal);

					default: return IS_TRUE(v.SShort0 > cmpVal)
								 && IS_TRUE(v.SShort1 > cmpVal)
								 && IS_TRUE(v.SShort2 > cmpVal)
								 && IS_TRUE(v.SShort3 > cmpVal)
								 && IS_TRUE(v.SShort4 > cmpVal)
								 && IS_TRUE(v.SShort5 > cmpVal)
								 && IS_TRUE(v.SShort6 > cmpVal)
								 && IS_TRUE(v.SShort7 > cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_GT_EPI32(v128 v, int cmpVal, byte elements = 4)
			{
				switch (elements)
				{
					case  1: return IS_TRUE(v.SInt0 > cmpVal);

					case  2: return IS_TRUE(v.SInt0 > cmpVal)
								 && IS_TRUE(v.SInt1 > cmpVal);

					case  3: return IS_TRUE(v.SInt0 > cmpVal)
								 && IS_TRUE(v.SInt1 > cmpVal)
								 && IS_TRUE(v.SInt2 > cmpVal);

					default: return IS_TRUE(v.SInt0 > cmpVal)
								 && IS_TRUE(v.SInt1 > cmpVal)
								 && IS_TRUE(v.SInt2 > cmpVal)
								 && IS_TRUE(v.SInt3 > cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_GT_EPI64(v128 v, long cmpVal, byte elements = 2)
			{
                if (elements == 1)
                {
					return IS_TRUE(v.SLong0 > cmpVal);
                }
				else
				{
					return IS_TRUE(v.SLong0 > cmpVal)
						&& IS_TRUE(v.SLong1 > cmpVal);
				}
			}
			
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_GT_PS(v128 v, float cmpVal, byte elements = 4)
			{
				switch (elements)
				{
					case  1: return IS_TRUE(v.Float0 > cmpVal);

					case  2: return IS_TRUE(v.Float0 > cmpVal)
								 && IS_TRUE(v.Float1 > cmpVal);

					case  3: return IS_TRUE(v.Float0 > cmpVal)
								 && IS_TRUE(v.Float1 > cmpVal)
								 && IS_TRUE(v.Float2 > cmpVal);

					default: return IS_TRUE(v.Float0 > cmpVal)
								 && IS_TRUE(v.Float1 > cmpVal)
								 && IS_TRUE(v.Float2 > cmpVal)
								 && IS_TRUE(v.Float3 > cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_GT_PD(v128 v, double cmpVal, byte elements = 2)
			{
                if (elements == 1)
                {
					return IS_TRUE(v.Double0 > cmpVal);
                }
				else
				{
					return IS_TRUE(v.Double0 > cmpVal)
						&& IS_TRUE(v.Double1 > cmpVal);
				}
			}


			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_GT_EPI8(v256 v, int cmpVal)
			{
				return IS_TRUE(v.SByte0  > cmpVal)
					&& IS_TRUE(v.SByte1  > cmpVal)
					&& IS_TRUE(v.SByte2  > cmpVal)
					&& IS_TRUE(v.SByte3  > cmpVal)
					&& IS_TRUE(v.SByte4  > cmpVal)
					&& IS_TRUE(v.SByte5  > cmpVal)
					&& IS_TRUE(v.SByte6  > cmpVal)
					&& IS_TRUE(v.SByte7  > cmpVal)
					&& IS_TRUE(v.SByte8  > cmpVal)
					&& IS_TRUE(v.SByte9  > cmpVal)
					&& IS_TRUE(v.SByte10 > cmpVal)
					&& IS_TRUE(v.SByte11 > cmpVal)
					&& IS_TRUE(v.SByte12 > cmpVal)
					&& IS_TRUE(v.SByte13 > cmpVal)
					&& IS_TRUE(v.SByte14 > cmpVal)
					&& IS_TRUE(v.SByte15 > cmpVal)
				    && IS_TRUE(v.SByte16 > cmpVal)
					&& IS_TRUE(v.SByte17 > cmpVal)
					&& IS_TRUE(v.SByte18 > cmpVal)
					&& IS_TRUE(v.SByte19 > cmpVal)
					&& IS_TRUE(v.SByte20 > cmpVal)
					&& IS_TRUE(v.SByte21 > cmpVal)
					&& IS_TRUE(v.SByte22 > cmpVal)
					&& IS_TRUE(v.SByte23 > cmpVal)
					&& IS_TRUE(v.SByte24 > cmpVal)
					&& IS_TRUE(v.SByte25 > cmpVal)
					&& IS_TRUE(v.SByte26 > cmpVal)
					&& IS_TRUE(v.SByte27 > cmpVal)
					&& IS_TRUE(v.SByte28 > cmpVal)
					&& IS_TRUE(v.SByte29 > cmpVal)
					&& IS_TRUE(v.SByte30 > cmpVal)
					&& IS_TRUE(v.SByte31 > cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_GT_EPI16(v256 v, int cmpVal)
			{
				return IS_TRUE(v.SShort0  > cmpVal)
					&& IS_TRUE(v.SShort1  > cmpVal)
					&& IS_TRUE(v.SShort2  > cmpVal)
					&& IS_TRUE(v.SShort3  > cmpVal)
					&& IS_TRUE(v.SShort4  > cmpVal)
					&& IS_TRUE(v.SShort5  > cmpVal)
					&& IS_TRUE(v.SShort6  > cmpVal)
					&& IS_TRUE(v.SShort7  > cmpVal)
					&& IS_TRUE(v.SShort8  > cmpVal)
					&& IS_TRUE(v.SShort9  > cmpVal)
					&& IS_TRUE(v.SShort10 > cmpVal)
					&& IS_TRUE(v.SShort11 > cmpVal)
					&& IS_TRUE(v.SShort12 > cmpVal)
					&& IS_TRUE(v.SShort13 > cmpVal)
					&& IS_TRUE(v.SShort14 > cmpVal)
					&& IS_TRUE(v.SShort15 > cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_GT_EPI32(v256 v, int cmpVal)
			{
				return IS_TRUE(v.SInt0 > cmpVal)
					&& IS_TRUE(v.SInt1 > cmpVal)
					&& IS_TRUE(v.SInt2 > cmpVal)
					&& IS_TRUE(v.SInt3 > cmpVal)
					&& IS_TRUE(v.SInt4 > cmpVal)
					&& IS_TRUE(v.SInt5 > cmpVal)
					&& IS_TRUE(v.SInt6 > cmpVal)
					&& IS_TRUE(v.SInt7 > cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_GT_EPI64(v256 v, long cmpVal, byte elements = 4)
			{
				if (elements == 3)
				{
					return IS_TRUE(v.SLong0 > cmpVal)
						&& IS_TRUE(v.SLong1 > cmpVal)
						&& IS_TRUE(v.SLong2 > cmpVal);
				}
				else
				{
					return IS_TRUE(v.SLong0 > cmpVal)
						&& IS_TRUE(v.SLong1 > cmpVal)
						&& IS_TRUE(v.SLong2 > cmpVal)
						&& IS_TRUE(v.SLong3 > cmpVal);
				}
			}
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_GT_EPU8(v256 v, uint cmpVal)
			{
				return IS_TRUE(v.Byte0  > cmpVal)
					&& IS_TRUE(v.Byte1  > cmpVal)
					&& IS_TRUE(v.Byte2  > cmpVal)
					&& IS_TRUE(v.Byte3  > cmpVal)
					&& IS_TRUE(v.Byte4  > cmpVal)
					&& IS_TRUE(v.Byte5  > cmpVal)
					&& IS_TRUE(v.Byte6  > cmpVal)
					&& IS_TRUE(v.Byte7  > cmpVal)
					&& IS_TRUE(v.Byte8  > cmpVal)
					&& IS_TRUE(v.Byte9  > cmpVal)
					&& IS_TRUE(v.Byte10 > cmpVal)
					&& IS_TRUE(v.Byte11 > cmpVal)
					&& IS_TRUE(v.Byte12 > cmpVal)
					&& IS_TRUE(v.Byte13 > cmpVal)
					&& IS_TRUE(v.Byte14 > cmpVal)
					&& IS_TRUE(v.Byte15 > cmpVal)
				    && IS_TRUE(v.Byte16 > cmpVal)
					&& IS_TRUE(v.Byte17 > cmpVal)
					&& IS_TRUE(v.Byte18 > cmpVal)
					&& IS_TRUE(v.Byte19 > cmpVal)
					&& IS_TRUE(v.Byte20 > cmpVal)
					&& IS_TRUE(v.Byte21 > cmpVal)
					&& IS_TRUE(v.Byte22 > cmpVal)
					&& IS_TRUE(v.Byte23 > cmpVal)
					&& IS_TRUE(v.Byte24 > cmpVal)
					&& IS_TRUE(v.Byte25 > cmpVal)
					&& IS_TRUE(v.Byte26 > cmpVal)
					&& IS_TRUE(v.Byte27 > cmpVal)
					&& IS_TRUE(v.Byte28 > cmpVal)
					&& IS_TRUE(v.Byte29 > cmpVal)
					&& IS_TRUE(v.Byte30 > cmpVal)
					&& IS_TRUE(v.Byte31 > cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_GT_EPU16(v256 v, uint cmpVal)
			{
				return IS_TRUE(v.UShort0  > cmpVal)
					&& IS_TRUE(v.UShort1  > cmpVal)
					&& IS_TRUE(v.UShort2  > cmpVal)
					&& IS_TRUE(v.UShort3  > cmpVal)
					&& IS_TRUE(v.UShort4  > cmpVal)
					&& IS_TRUE(v.UShort5  > cmpVal)
					&& IS_TRUE(v.UShort6  > cmpVal)
					&& IS_TRUE(v.UShort7  > cmpVal)
					&& IS_TRUE(v.UShort8  > cmpVal)
					&& IS_TRUE(v.UShort9  > cmpVal)
					&& IS_TRUE(v.UShort10 > cmpVal)
					&& IS_TRUE(v.UShort11 > cmpVal)
					&& IS_TRUE(v.UShort12 > cmpVal)
					&& IS_TRUE(v.UShort13 > cmpVal)
					&& IS_TRUE(v.UShort14 > cmpVal)
					&& IS_TRUE(v.UShort15 > cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_GT_EPU32(v256 v, uint cmpVal)
			{
				return IS_TRUE(v.UInt0 > cmpVal)
					&& IS_TRUE(v.UInt1 > cmpVal)
					&& IS_TRUE(v.UInt2 > cmpVal)
					&& IS_TRUE(v.UInt3 > cmpVal)
					&& IS_TRUE(v.UInt4 > cmpVal)
					&& IS_TRUE(v.UInt5 > cmpVal)
					&& IS_TRUE(v.UInt6 > cmpVal)
					&& IS_TRUE(v.UInt7 > cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_GT_EPU64(v256 v, ulong cmpVal, byte elements = 4)
			{
				if (elements == 3)
				{
					return IS_TRUE(v.ULong0 > cmpVal)
						&& IS_TRUE(v.ULong1 > cmpVal)
						&& IS_TRUE(v.ULong2 > cmpVal);
				}
				else
				{
					return IS_TRUE(v.ULong0 > cmpVal)
						&& IS_TRUE(v.ULong1 > cmpVal)
						&& IS_TRUE(v.ULong2 > cmpVal)
						&& IS_TRUE(v.ULong3 > cmpVal);
				}
			}


			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_GT_PS(v256 v, float cmpVal)
			{
				return IS_TRUE(v.Float0 > cmpVal)
					&& IS_TRUE(v.Float1 > cmpVal)
					&& IS_TRUE(v.Float2 > cmpVal)
					&& IS_TRUE(v.Float3 > cmpVal)
					&& IS_TRUE(v.Float4 > cmpVal)
					&& IS_TRUE(v.Float5 > cmpVal)
					&& IS_TRUE(v.Float6 > cmpVal)
					&& IS_TRUE(v.Float7 > cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_GT_PD(v256 v, double cmpVal, byte elements = 4)
			{
				if (elements == 3)
				{
					return IS_TRUE(v.Double0 > cmpVal)
						&& IS_TRUE(v.Double1 > cmpVal)
						&& IS_TRUE(v.Double2 > cmpVal);
				}
				else
				{
					return IS_TRUE(v.Double0 > cmpVal)
						&& IS_TRUE(v.Double1 > cmpVal)
						&& IS_TRUE(v.Double2 > cmpVal)
						&& IS_TRUE(v.Double3 > cmpVal);
				}
			}


			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_LT_EPU8(v128 v, uint cmpVal, byte elements = 16)
			{
				switch (elements)
				{
					case  1: return IS_TRUE(v.Byte0  < cmpVal);

					case  2: return IS_TRUE(v.Byte0  < cmpVal)
								 && IS_TRUE(v.Byte1  < cmpVal);
									
					case  3: return IS_TRUE(v.Byte0  < cmpVal)
								 && IS_TRUE(v.Byte1  < cmpVal)
								 && IS_TRUE(v.Byte2  < cmpVal);

					case  4: return IS_TRUE(v.Byte0  < cmpVal)
								 && IS_TRUE(v.Byte1  < cmpVal)
								 && IS_TRUE(v.Byte2  < cmpVal)
								 && IS_TRUE(v.Byte3  < cmpVal);

					case  8: return IS_TRUE(v.Byte0  < cmpVal)
								 && IS_TRUE(v.Byte1  < cmpVal)
								 && IS_TRUE(v.Byte2  < cmpVal)
								 && IS_TRUE(v.Byte3  < cmpVal)
								 && IS_TRUE(v.Byte4  < cmpVal)
								 && IS_TRUE(v.Byte5  < cmpVal)
								 && IS_TRUE(v.Byte6  < cmpVal)
								 && IS_TRUE(v.Byte7  < cmpVal);

					default: return IS_TRUE(v.Byte0  < cmpVal)
								 && IS_TRUE(v.Byte1  < cmpVal)
								 && IS_TRUE(v.Byte2  < cmpVal)
								 && IS_TRUE(v.Byte3  < cmpVal)
								 && IS_TRUE(v.Byte4  < cmpVal)
								 && IS_TRUE(v.Byte5  < cmpVal)
								 && IS_TRUE(v.Byte6  < cmpVal)
								 && IS_TRUE(v.Byte7  < cmpVal)
								 && IS_TRUE(v.Byte8  < cmpVal)
								 && IS_TRUE(v.Byte9  < cmpVal)
								 && IS_TRUE(v.Byte10 < cmpVal)
								 && IS_TRUE(v.Byte11 < cmpVal)
								 && IS_TRUE(v.Byte12 < cmpVal)
								 && IS_TRUE(v.Byte13 < cmpVal)
								 && IS_TRUE(v.Byte14 < cmpVal)
								 && IS_TRUE(v.Byte15 < cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_LT_EPU16(v128 v, uint cmpVal, byte elements = 8)
			{
				switch (elements)
				{
					case  1: return IS_TRUE(v.UShort0  < cmpVal);

					case  2: return IS_TRUE(v.UShort0  < cmpVal)
								 && IS_TRUE(v.UShort1  < cmpVal);

					case  3: return IS_TRUE(v.UShort0  < cmpVal)
								 && IS_TRUE(v.UShort1  < cmpVal)
								 && IS_TRUE(v.UShort2  < cmpVal);

					case  4: return IS_TRUE(v.UShort0  < cmpVal)
								 && IS_TRUE(v.UShort1  < cmpVal)
								 && IS_TRUE(v.UShort2  < cmpVal)
								 && IS_TRUE(v.UShort3  < cmpVal);

					default: return IS_TRUE(v.UShort0  < cmpVal)
								 && IS_TRUE(v.UShort1  < cmpVal)
								 && IS_TRUE(v.UShort2  < cmpVal)
								 && IS_TRUE(v.UShort3  < cmpVal)
								 && IS_TRUE(v.UShort4  < cmpVal)
								 && IS_TRUE(v.UShort5  < cmpVal)
								 && IS_TRUE(v.UShort6  < cmpVal)
								 && IS_TRUE(v.UShort7  < cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_LT_EPU32(v128 v, uint cmpVal, byte elements = 4)
			{
				switch (elements)
				{
					case  1: return IS_TRUE(v.UInt0  < cmpVal);

					case  2: return IS_TRUE(v.UInt0  < cmpVal)
								 && IS_TRUE(v.UInt1  < cmpVal);

					case  3: return IS_TRUE(v.UInt0  < cmpVal)
								 && IS_TRUE(v.UInt1  < cmpVal)
								 && IS_TRUE(v.UInt2  < cmpVal);

					default: return IS_TRUE(v.UInt0  < cmpVal)
								 && IS_TRUE(v.UInt1  < cmpVal)
								 && IS_TRUE(v.UInt2  < cmpVal)
								 && IS_TRUE(v.UInt3  < cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_LT_EPU64(v128 v, ulong cmpVal, byte elements = 2)
			{
                if (elements == 1)
                {
					return IS_TRUE(v.ULong0 < cmpVal);
                }
				else
				{
					return IS_TRUE(v.ULong0 < cmpVal)
						&& IS_TRUE(v.ULong1 < cmpVal);
				}
			}
			
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_LT_EPI8(v128 v, int cmpVal, byte elements = 16)
			{
				switch (elements)
				{
					case  1: return IS_TRUE(v.SByte0  < cmpVal);

					case  2: return IS_TRUE(v.SByte0  < cmpVal)
								 && IS_TRUE(v.SByte1  < cmpVal);

					case  3: return IS_TRUE(v.SByte0  < cmpVal)
								 && IS_TRUE(v.SByte1  < cmpVal)
								 && IS_TRUE(v.SByte2  < cmpVal);

					case  4: return IS_TRUE(v.SByte0  < cmpVal)
								 && IS_TRUE(v.SByte1  < cmpVal)
								 && IS_TRUE(v.SByte2  < cmpVal)
								 && IS_TRUE(v.SByte3  < cmpVal);

					case  8: return IS_TRUE(v.SByte0  < cmpVal)
								 && IS_TRUE(v.SByte1  < cmpVal)
								 && IS_TRUE(v.SByte2  < cmpVal)
								 && IS_TRUE(v.SByte3  < cmpVal)
								 && IS_TRUE(v.SByte4  < cmpVal)
								 && IS_TRUE(v.SByte5  < cmpVal)
								 && IS_TRUE(v.SByte6  < cmpVal)
								 && IS_TRUE(v.SByte7  < cmpVal);

					default: return IS_TRUE(v.SByte0  < cmpVal)
								 && IS_TRUE(v.SByte1  < cmpVal)
								 && IS_TRUE(v.SByte2  < cmpVal)
								 && IS_TRUE(v.SByte3  < cmpVal)
								 && IS_TRUE(v.SByte4  < cmpVal)
								 && IS_TRUE(v.SByte5  < cmpVal)
								 && IS_TRUE(v.SByte6  < cmpVal)
								 && IS_TRUE(v.SByte7  < cmpVal)
								 && IS_TRUE(v.SByte8  < cmpVal)
								 && IS_TRUE(v.SByte9  < cmpVal)
								 && IS_TRUE(v.SByte10 < cmpVal)
								 && IS_TRUE(v.SByte11 < cmpVal)
								 && IS_TRUE(v.SByte12 < cmpVal)
								 && IS_TRUE(v.SByte13 < cmpVal)
								 && IS_TRUE(v.SByte14 < cmpVal)
								 && IS_TRUE(v.SByte15 < cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_LT_EPI16(v128 v, int cmpVal, byte elements = 8)
			{
				switch (elements)
				{
					case  1: return IS_TRUE(v.SShort0 < cmpVal);

					case  2: return IS_TRUE(v.SShort0 < cmpVal)
								 && IS_TRUE(v.SShort1 < cmpVal);

					case  3: return IS_TRUE(v.SShort0 < cmpVal)
								 && IS_TRUE(v.SShort1 < cmpVal)
								 && IS_TRUE(v.SShort2 < cmpVal);

					case  4: return IS_TRUE(v.SShort0 < cmpVal)
								 && IS_TRUE(v.SShort1 < cmpVal)
								 && IS_TRUE(v.SShort2 < cmpVal)
								 && IS_TRUE(v.SShort3 < cmpVal);

					default: return IS_TRUE(v.SShort0 < cmpVal)
								 && IS_TRUE(v.SShort1 < cmpVal)
								 && IS_TRUE(v.SShort2 < cmpVal)
								 && IS_TRUE(v.SShort3 < cmpVal)
								 && IS_TRUE(v.SShort4 < cmpVal)
								 && IS_TRUE(v.SShort5 < cmpVal)
								 && IS_TRUE(v.SShort6 < cmpVal)
								 && IS_TRUE(v.SShort7 < cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_LT_EPI32(v128 v, int cmpVal, byte elements = 4)
			{
				switch (elements)
				{
					case  1: return IS_TRUE(v.SInt0 < cmpVal);

					case  2: return IS_TRUE(v.SInt0 < cmpVal)
								 && IS_TRUE(v.SInt1 < cmpVal);

					case  3: return IS_TRUE(v.SInt0 < cmpVal)
								 && IS_TRUE(v.SInt1 < cmpVal)
								 && IS_TRUE(v.SInt2 < cmpVal);

					default: return IS_TRUE(v.SInt0 < cmpVal)
								 && IS_TRUE(v.SInt1 < cmpVal)
								 && IS_TRUE(v.SInt2 < cmpVal)
								 && IS_TRUE(v.SInt3 < cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_LT_EPI64(v128 v, long cmpVal, byte elements = 2)
			{
                if (elements == 1)
                {
					return IS_TRUE(v.SLong0 < cmpVal);
                }
				else
				{
					return IS_TRUE(v.SLong0 < cmpVal)
						&& IS_TRUE(v.SLong1 < cmpVal);
				}
			}
			
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_LT_PS(v128 v, float cmpVal, byte elements = 4)
			{
				switch (elements)
				{
					case  1: return IS_TRUE(v.Float0 < cmpVal);

					case  2: return IS_TRUE(v.Float0 < cmpVal)
								 && IS_TRUE(v.Float1 < cmpVal);

					case  3: return IS_TRUE(v.Float0 < cmpVal)
								 && IS_TRUE(v.Float1 < cmpVal)
								 && IS_TRUE(v.Float2 < cmpVal);

					default: return IS_TRUE(v.Float0 < cmpVal)
								 && IS_TRUE(v.Float1 < cmpVal)
								 && IS_TRUE(v.Float2 < cmpVal)
								 && IS_TRUE(v.Float3 < cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_LT_PD(v128 v, double cmpVal, byte elements = 2)
			{
                if (elements == 1)
                {
					return IS_TRUE(v.Double0 < cmpVal);
                }
				else
				{
					return IS_TRUE(v.Double0 < cmpVal)
						&& IS_TRUE(v.Double1 < cmpVal);
				}
			}


			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_LT_EPI8(v256 v, int cmpVal)
			{
				return IS_TRUE(v.SByte0  < cmpVal)
					&& IS_TRUE(v.SByte1  < cmpVal)
					&& IS_TRUE(v.SByte2  < cmpVal)
					&& IS_TRUE(v.SByte3  < cmpVal)
					&& IS_TRUE(v.SByte4  < cmpVal)
					&& IS_TRUE(v.SByte5  < cmpVal)
					&& IS_TRUE(v.SByte6  < cmpVal)
					&& IS_TRUE(v.SByte7  < cmpVal)
					&& IS_TRUE(v.SByte8  < cmpVal)
					&& IS_TRUE(v.SByte9  < cmpVal)
					&& IS_TRUE(v.SByte10 < cmpVal)
					&& IS_TRUE(v.SByte11 < cmpVal)
					&& IS_TRUE(v.SByte12 < cmpVal)
					&& IS_TRUE(v.SByte13 < cmpVal)
					&& IS_TRUE(v.SByte14 < cmpVal)
					&& IS_TRUE(v.SByte15 < cmpVal)
				    && IS_TRUE(v.SByte16 < cmpVal)
					&& IS_TRUE(v.SByte17 < cmpVal)
					&& IS_TRUE(v.SByte18 < cmpVal)
					&& IS_TRUE(v.SByte19 < cmpVal)
					&& IS_TRUE(v.SByte20 < cmpVal)
					&& IS_TRUE(v.SByte21 < cmpVal)
					&& IS_TRUE(v.SByte22 < cmpVal)
					&& IS_TRUE(v.SByte23 < cmpVal)
					&& IS_TRUE(v.SByte24 < cmpVal)
					&& IS_TRUE(v.SByte25 < cmpVal)
					&& IS_TRUE(v.SByte26 < cmpVal)
					&& IS_TRUE(v.SByte27 < cmpVal)
					&& IS_TRUE(v.SByte28 < cmpVal)
					&& IS_TRUE(v.SByte29 < cmpVal)
					&& IS_TRUE(v.SByte30 < cmpVal)
					&& IS_TRUE(v.SByte31 < cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_LT_EPI16(v256 v, int cmpVal)
			{
				return IS_TRUE(v.SShort0  < cmpVal)
					&& IS_TRUE(v.SShort1  < cmpVal)
					&& IS_TRUE(v.SShort2  < cmpVal)
					&& IS_TRUE(v.SShort3  < cmpVal)
					&& IS_TRUE(v.SShort4  < cmpVal)
					&& IS_TRUE(v.SShort5  < cmpVal)
					&& IS_TRUE(v.SShort6  < cmpVal)
					&& IS_TRUE(v.SShort7  < cmpVal)
					&& IS_TRUE(v.SShort8  < cmpVal)
					&& IS_TRUE(v.SShort9  < cmpVal)
					&& IS_TRUE(v.SShort10 < cmpVal)
					&& IS_TRUE(v.SShort11 < cmpVal)
					&& IS_TRUE(v.SShort12 < cmpVal)
					&& IS_TRUE(v.SShort13 < cmpVal)
					&& IS_TRUE(v.SShort14 < cmpVal)
					&& IS_TRUE(v.SShort15 < cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_LT_EPI32(v256 v, int cmpVal)
			{
				return IS_TRUE(v.SInt0 < cmpVal)
					&& IS_TRUE(v.SInt1 < cmpVal)
					&& IS_TRUE(v.SInt2 < cmpVal)
					&& IS_TRUE(v.SInt3 < cmpVal)
					&& IS_TRUE(v.SInt4 < cmpVal)
					&& IS_TRUE(v.SInt5 < cmpVal)
					&& IS_TRUE(v.SInt6 < cmpVal)
					&& IS_TRUE(v.SInt7 < cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_LT_EPI64(v256 v, long cmpVal, byte elements = 4)
			{
				if (elements == 3)
				{
					return IS_TRUE(v.SLong0 < cmpVal)
						&& IS_TRUE(v.SLong1 < cmpVal)
						&& IS_TRUE(v.SLong2 < cmpVal);
				}
				else
				{
					return IS_TRUE(v.SLong0 < cmpVal)
						&& IS_TRUE(v.SLong1 < cmpVal)
						&& IS_TRUE(v.SLong2 < cmpVal)
						&& IS_TRUE(v.SLong3 < cmpVal);
				}
			}
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_LT_EPU8(v256 v, uint cmpVal)
			{
				return IS_TRUE(v.Byte0  < cmpVal)
					&& IS_TRUE(v.Byte1  < cmpVal)
					&& IS_TRUE(v.Byte2  < cmpVal)
					&& IS_TRUE(v.Byte3  < cmpVal)
					&& IS_TRUE(v.Byte4  < cmpVal)
					&& IS_TRUE(v.Byte5  < cmpVal)
					&& IS_TRUE(v.Byte6  < cmpVal)
					&& IS_TRUE(v.Byte7  < cmpVal)
					&& IS_TRUE(v.Byte8  < cmpVal)
					&& IS_TRUE(v.Byte9  < cmpVal)
					&& IS_TRUE(v.Byte10 < cmpVal)
					&& IS_TRUE(v.Byte11 < cmpVal)
					&& IS_TRUE(v.Byte12 < cmpVal)
					&& IS_TRUE(v.Byte13 < cmpVal)
					&& IS_TRUE(v.Byte14 < cmpVal)
					&& IS_TRUE(v.Byte15 < cmpVal)
				    && IS_TRUE(v.Byte16 < cmpVal)
					&& IS_TRUE(v.Byte17 < cmpVal)
					&& IS_TRUE(v.Byte18 < cmpVal)
					&& IS_TRUE(v.Byte19 < cmpVal)
					&& IS_TRUE(v.Byte20 < cmpVal)
					&& IS_TRUE(v.Byte21 < cmpVal)
					&& IS_TRUE(v.Byte22 < cmpVal)
					&& IS_TRUE(v.Byte23 < cmpVal)
					&& IS_TRUE(v.Byte24 < cmpVal)
					&& IS_TRUE(v.Byte25 < cmpVal)
					&& IS_TRUE(v.Byte26 < cmpVal)
					&& IS_TRUE(v.Byte27 < cmpVal)
					&& IS_TRUE(v.Byte28 < cmpVal)
					&& IS_TRUE(v.Byte29 < cmpVal)
					&& IS_TRUE(v.Byte30 < cmpVal)
					&& IS_TRUE(v.Byte31 < cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_LT_EPU16(v256 v, uint cmpVal)
			{
				return IS_TRUE(v.UShort0  < cmpVal)
					&& IS_TRUE(v.UShort1  < cmpVal)
					&& IS_TRUE(v.UShort2  < cmpVal)
					&& IS_TRUE(v.UShort3  < cmpVal)
					&& IS_TRUE(v.UShort4  < cmpVal)
					&& IS_TRUE(v.UShort5  < cmpVal)
					&& IS_TRUE(v.UShort6  < cmpVal)
					&& IS_TRUE(v.UShort7  < cmpVal)
					&& IS_TRUE(v.UShort8  < cmpVal)
					&& IS_TRUE(v.UShort9  < cmpVal)
					&& IS_TRUE(v.UShort10 < cmpVal)
					&& IS_TRUE(v.UShort11 < cmpVal)
					&& IS_TRUE(v.UShort12 < cmpVal)
					&& IS_TRUE(v.UShort13 < cmpVal)
					&& IS_TRUE(v.UShort14 < cmpVal)
					&& IS_TRUE(v.UShort15 < cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_LT_EPU32(v256 v, uint cmpVal)
			{
				return IS_TRUE(v.UInt0 < cmpVal)
					&& IS_TRUE(v.UInt1 < cmpVal)
					&& IS_TRUE(v.UInt2 < cmpVal)
					&& IS_TRUE(v.UInt3 < cmpVal)
					&& IS_TRUE(v.UInt4 < cmpVal)
					&& IS_TRUE(v.UInt5 < cmpVal)
					&& IS_TRUE(v.UInt6 < cmpVal)
					&& IS_TRUE(v.UInt7 < cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_LT_EPU64(v256 v, ulong cmpVal, byte elements = 4)
			{
				if (elements == 3)
				{
					return IS_TRUE(v.ULong0 < cmpVal)
						&& IS_TRUE(v.ULong1 < cmpVal)
						&& IS_TRUE(v.ULong2 < cmpVal);
				}
				else
				{
					return IS_TRUE(v.ULong0 < cmpVal)
						&& IS_TRUE(v.ULong1 < cmpVal)
						&& IS_TRUE(v.ULong2 < cmpVal)
						&& IS_TRUE(v.ULong3 < cmpVal);
				}
			}


			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_LT_PS(v256 v, float cmpVal)
			{
				return IS_TRUE(v.Float0 < cmpVal)
					&& IS_TRUE(v.Float1 < cmpVal)
					&& IS_TRUE(v.Float2 < cmpVal)
					&& IS_TRUE(v.Float3 < cmpVal)
					&& IS_TRUE(v.Float4 < cmpVal)
					&& IS_TRUE(v.Float5 < cmpVal)
					&& IS_TRUE(v.Float6 < cmpVal)
					&& IS_TRUE(v.Float7 < cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_LT_PD(v256 v, double cmpVal, byte elements = 4)
			{
				if (elements == 3)
				{
					return IS_TRUE(v.Double0 < cmpVal)
						&& IS_TRUE(v.Double1 < cmpVal)
						&& IS_TRUE(v.Double2 < cmpVal);
				}
				else
				{
					return IS_TRUE(v.Double0 < cmpVal)
						&& IS_TRUE(v.Double1 < cmpVal)
						&& IS_TRUE(v.Double2 < cmpVal)
						&& IS_TRUE(v.Double3 < cmpVal);
				}
			}


			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_GE_EPU8(v128 v, uint cmpVal, byte elements = 16)
			{
				switch (elements)
				{
					case  1: return IS_TRUE(v.Byte0  >= cmpVal);

					case  2: return IS_TRUE(v.Byte0  >= cmpVal)
								 && IS_TRUE(v.Byte1  >= cmpVal);
									
					case  3: return IS_TRUE(v.Byte0  >= cmpVal)
								 && IS_TRUE(v.Byte1  >= cmpVal)
								 && IS_TRUE(v.Byte2  >= cmpVal);

					case  4: return IS_TRUE(v.Byte0  >= cmpVal)
								 && IS_TRUE(v.Byte1  >= cmpVal)
								 && IS_TRUE(v.Byte2  >= cmpVal)
								 && IS_TRUE(v.Byte3  >= cmpVal);

					case  8: return IS_TRUE(v.Byte0  >= cmpVal)
								 && IS_TRUE(v.Byte1  >= cmpVal)
								 && IS_TRUE(v.Byte2  >= cmpVal)
								 && IS_TRUE(v.Byte3  >= cmpVal)
								 && IS_TRUE(v.Byte4  >= cmpVal)
								 && IS_TRUE(v.Byte5  >= cmpVal)
								 && IS_TRUE(v.Byte6  >= cmpVal)
								 && IS_TRUE(v.Byte7  >= cmpVal);

					default: return IS_TRUE(v.Byte0  >= cmpVal)
								 && IS_TRUE(v.Byte1  >= cmpVal)
								 && IS_TRUE(v.Byte2  >= cmpVal)
								 && IS_TRUE(v.Byte3  >= cmpVal)
								 && IS_TRUE(v.Byte4  >= cmpVal)
								 && IS_TRUE(v.Byte5  >= cmpVal)
								 && IS_TRUE(v.Byte6  >= cmpVal)
								 && IS_TRUE(v.Byte7  >= cmpVal)
								 && IS_TRUE(v.Byte8  >= cmpVal)
								 && IS_TRUE(v.Byte9  >= cmpVal)
								 && IS_TRUE(v.Byte10 >= cmpVal)
								 && IS_TRUE(v.Byte11 >= cmpVal)
								 && IS_TRUE(v.Byte12 >= cmpVal)
								 && IS_TRUE(v.Byte13 >= cmpVal)
								 && IS_TRUE(v.Byte14 >= cmpVal)
								 && IS_TRUE(v.Byte15 >= cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_GE_EPU16(v128 v, uint cmpVal, byte elements = 8)
			{
				switch (elements)
				{
					case  1: return IS_TRUE(v.UShort0  >= cmpVal);

					case  2: return IS_TRUE(v.UShort0  >= cmpVal)
								 && IS_TRUE(v.UShort1  >= cmpVal);

					case  3: return IS_TRUE(v.UShort0  >= cmpVal)
								 && IS_TRUE(v.UShort1  >= cmpVal)
								 && IS_TRUE(v.UShort2  >= cmpVal);

					case  4: return IS_TRUE(v.UShort0  >= cmpVal)
								 && IS_TRUE(v.UShort1  >= cmpVal)
								 && IS_TRUE(v.UShort2  >= cmpVal)
								 && IS_TRUE(v.UShort3  >= cmpVal);

					default: return IS_TRUE(v.UShort0  >= cmpVal)
								 && IS_TRUE(v.UShort1  >= cmpVal)
								 && IS_TRUE(v.UShort2  >= cmpVal)
								 && IS_TRUE(v.UShort3  >= cmpVal)
								 && IS_TRUE(v.UShort4  >= cmpVal)
								 && IS_TRUE(v.UShort5  >= cmpVal)
								 && IS_TRUE(v.UShort6  >= cmpVal)
								 && IS_TRUE(v.UShort7  >= cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_GE_EPU32(v128 v, uint cmpVal, byte elements = 4)
			{
				switch (elements)
				{
					case  1: return IS_TRUE(v.UInt0  >= cmpVal);

					case  2: return IS_TRUE(v.UInt0  >= cmpVal)
								 && IS_TRUE(v.UInt1  >= cmpVal);

					case  3: return IS_TRUE(v.UInt0  >= cmpVal)
								 && IS_TRUE(v.UInt1  >= cmpVal)
								 && IS_TRUE(v.UInt2  >= cmpVal);

					default: return IS_TRUE(v.UInt0  >= cmpVal)
								 && IS_TRUE(v.UInt1  >= cmpVal)
								 && IS_TRUE(v.UInt2  >= cmpVal)
								 && IS_TRUE(v.UInt3  >= cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_GE_EPU64(v128 v, ulong cmpVal, byte elements = 2)
			{
                if (elements == 1)
                {
					return IS_TRUE(v.ULong0 >= cmpVal);
                }
				else
				{
					return IS_TRUE(v.ULong0 >= cmpVal)
						&& IS_TRUE(v.ULong1 >= cmpVal);
				}
			}
			
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_GE_EPI8(v128 v, int cmpVal, byte elements = 16)
			{
				switch (elements)
				{
					case  1: return IS_TRUE(v.SByte0  >= cmpVal);

					case  2: return IS_TRUE(v.SByte0  >= cmpVal)
								 && IS_TRUE(v.SByte1  >= cmpVal);

					case  3: return IS_TRUE(v.SByte0  >= cmpVal)
								 && IS_TRUE(v.SByte1  >= cmpVal)
								 && IS_TRUE(v.SByte2  >= cmpVal);

					case  4: return IS_TRUE(v.SByte0  >= cmpVal)
								 && IS_TRUE(v.SByte1  >= cmpVal)
								 && IS_TRUE(v.SByte2  >= cmpVal)
								 && IS_TRUE(v.SByte3  >= cmpVal);

					case  8: return IS_TRUE(v.SByte0  >= cmpVal)
								 && IS_TRUE(v.SByte1  >= cmpVal)
								 && IS_TRUE(v.SByte2  >= cmpVal)
								 && IS_TRUE(v.SByte3  >= cmpVal)
								 && IS_TRUE(v.SByte4  >= cmpVal)
								 && IS_TRUE(v.SByte5  >= cmpVal)
								 && IS_TRUE(v.SByte6  >= cmpVal)
								 && IS_TRUE(v.SByte7  >= cmpVal);

					default: return IS_TRUE(v.SByte0  >= cmpVal)
								 && IS_TRUE(v.SByte1  >= cmpVal)
								 && IS_TRUE(v.SByte2  >= cmpVal)
								 && IS_TRUE(v.SByte3  >= cmpVal)
								 && IS_TRUE(v.SByte4  >= cmpVal)
								 && IS_TRUE(v.SByte5  >= cmpVal)
								 && IS_TRUE(v.SByte6  >= cmpVal)
								 && IS_TRUE(v.SByte7  >= cmpVal)
								 && IS_TRUE(v.SByte8  >= cmpVal)
								 && IS_TRUE(v.SByte9  >= cmpVal)
								 && IS_TRUE(v.SByte10 >= cmpVal)
								 && IS_TRUE(v.SByte11 >= cmpVal)
								 && IS_TRUE(v.SByte12 >= cmpVal)
								 && IS_TRUE(v.SByte13 >= cmpVal)
								 && IS_TRUE(v.SByte14 >= cmpVal)
								 && IS_TRUE(v.SByte15 >= cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_GE_EPI16(v128 v, int cmpVal, byte elements = 8)
			{
				switch (elements)
				{
					case  1: return IS_TRUE(v.SShort0 >= cmpVal);

					case  2: return IS_TRUE(v.SShort0 >= cmpVal)
								 && IS_TRUE(v.SShort1 >= cmpVal);

					case  3: return IS_TRUE(v.SShort0 >= cmpVal)
								 && IS_TRUE(v.SShort1 >= cmpVal)
								 && IS_TRUE(v.SShort2 >= cmpVal);

					case  4: return IS_TRUE(v.SShort0 >= cmpVal)
								 && IS_TRUE(v.SShort1 >= cmpVal)
								 && IS_TRUE(v.SShort2 >= cmpVal)
								 && IS_TRUE(v.SShort3 >= cmpVal);

					default: return IS_TRUE(v.SShort0 >= cmpVal)
								 && IS_TRUE(v.SShort1 >= cmpVal)
								 && IS_TRUE(v.SShort2 >= cmpVal)
								 && IS_TRUE(v.SShort3 >= cmpVal)
								 && IS_TRUE(v.SShort4 >= cmpVal)
								 && IS_TRUE(v.SShort5 >= cmpVal)
								 && IS_TRUE(v.SShort6 >= cmpVal)
								 && IS_TRUE(v.SShort7 >= cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_GE_EPI32(v128 v, int cmpVal, byte elements = 4)
			{
				switch (elements)
				{
					case  1: return IS_TRUE(v.SInt0 >= cmpVal);

					case  2: return IS_TRUE(v.SInt0 >= cmpVal)
								 && IS_TRUE(v.SInt1 >= cmpVal);

					case  3: return IS_TRUE(v.SInt0 >= cmpVal)
								 && IS_TRUE(v.SInt1 >= cmpVal)
								 && IS_TRUE(v.SInt2 >= cmpVal);

					default: return IS_TRUE(v.SInt0 >= cmpVal)
								 && IS_TRUE(v.SInt1 >= cmpVal)
								 && IS_TRUE(v.SInt2 >= cmpVal)
								 && IS_TRUE(v.SInt3 >= cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_GE_EPI64(v128 v, long cmpVal, byte elements = 2)
			{
                if (elements == 1)
                {
					return IS_TRUE(v.SLong0 >= cmpVal);
                }
				else
				{
					return IS_TRUE(v.SLong0 >= cmpVal)
						&& IS_TRUE(v.SLong1 >= cmpVal);
				}
			}
			
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_GE_PS(v128 v, float cmpVal, byte elements = 4)
			{
				switch (elements)
				{
					case  1: return IS_TRUE(v.Float0 >= cmpVal);

					case  2: return IS_TRUE(v.Float0 >= cmpVal)
								 && IS_TRUE(v.Float1 >= cmpVal);

					case  3: return IS_TRUE(v.Float0 >= cmpVal)
								 && IS_TRUE(v.Float1 >= cmpVal)
								 && IS_TRUE(v.Float2 >= cmpVal);

					default: return IS_TRUE(v.Float0 >= cmpVal)
								 && IS_TRUE(v.Float1 >= cmpVal)
								 && IS_TRUE(v.Float2 >= cmpVal)
								 && IS_TRUE(v.Float3 >= cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_GE_PD(v128 v, double cmpVal, byte elements = 2)
			{
                if (elements == 1)
                {
					return IS_TRUE(v.Double0 >= cmpVal);
                }
				else
				{
					return IS_TRUE(v.Double0 >= cmpVal)
						&& IS_TRUE(v.Double1 >= cmpVal);
				}
			}


			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_GE_EPI8(v256 v, int cmpVal)
			{
				return IS_TRUE(v.SByte0  >= cmpVal)
					&& IS_TRUE(v.SByte1  >= cmpVal)
					&& IS_TRUE(v.SByte2  >= cmpVal)
					&& IS_TRUE(v.SByte3  >= cmpVal)
					&& IS_TRUE(v.SByte4  >= cmpVal)
					&& IS_TRUE(v.SByte5  >= cmpVal)
					&& IS_TRUE(v.SByte6  >= cmpVal)
					&& IS_TRUE(v.SByte7  >= cmpVal)
					&& IS_TRUE(v.SByte8  >= cmpVal)
					&& IS_TRUE(v.SByte9  >= cmpVal)
					&& IS_TRUE(v.SByte10 >= cmpVal)
					&& IS_TRUE(v.SByte11 >= cmpVal)
					&& IS_TRUE(v.SByte12 >= cmpVal)
					&& IS_TRUE(v.SByte13 >= cmpVal)
					&& IS_TRUE(v.SByte14 >= cmpVal)
					&& IS_TRUE(v.SByte15 >= cmpVal)
				    && IS_TRUE(v.SByte16 >= cmpVal)
					&& IS_TRUE(v.SByte17 >= cmpVal)
					&& IS_TRUE(v.SByte18 >= cmpVal)
					&& IS_TRUE(v.SByte19 >= cmpVal)
					&& IS_TRUE(v.SByte20 >= cmpVal)
					&& IS_TRUE(v.SByte21 >= cmpVal)
					&& IS_TRUE(v.SByte22 >= cmpVal)
					&& IS_TRUE(v.SByte23 >= cmpVal)
					&& IS_TRUE(v.SByte24 >= cmpVal)
					&& IS_TRUE(v.SByte25 >= cmpVal)
					&& IS_TRUE(v.SByte26 >= cmpVal)
					&& IS_TRUE(v.SByte27 >= cmpVal)
					&& IS_TRUE(v.SByte28 >= cmpVal)
					&& IS_TRUE(v.SByte29 >= cmpVal)
					&& IS_TRUE(v.SByte30 >= cmpVal)
					&& IS_TRUE(v.SByte31 >= cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_GE_EPI16(v256 v, int cmpVal)
			{
				return IS_TRUE(v.SShort0  >= cmpVal)
					&& IS_TRUE(v.SShort1  >= cmpVal)
					&& IS_TRUE(v.SShort2  >= cmpVal)
					&& IS_TRUE(v.SShort3  >= cmpVal)
					&& IS_TRUE(v.SShort4  >= cmpVal)
					&& IS_TRUE(v.SShort5  >= cmpVal)
					&& IS_TRUE(v.SShort6  >= cmpVal)
					&& IS_TRUE(v.SShort7  >= cmpVal)
					&& IS_TRUE(v.SShort8  >= cmpVal)
					&& IS_TRUE(v.SShort9  >= cmpVal)
					&& IS_TRUE(v.SShort10 >= cmpVal)
					&& IS_TRUE(v.SShort11 >= cmpVal)
					&& IS_TRUE(v.SShort12 >= cmpVal)
					&& IS_TRUE(v.SShort13 >= cmpVal)
					&& IS_TRUE(v.SShort14 >= cmpVal)
					&& IS_TRUE(v.SShort15 >= cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_GE_EPI32(v256 v, int cmpVal)
			{
				return IS_TRUE(v.SInt0 >= cmpVal)
					&& IS_TRUE(v.SInt1 >= cmpVal)
					&& IS_TRUE(v.SInt2 >= cmpVal)
					&& IS_TRUE(v.SInt3 >= cmpVal)
					&& IS_TRUE(v.SInt4 >= cmpVal)
					&& IS_TRUE(v.SInt5 >= cmpVal)
					&& IS_TRUE(v.SInt6 >= cmpVal)
					&& IS_TRUE(v.SInt7 >= cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_GE_EPI64(v256 v, long cmpVal, byte elements = 4)
			{
				if (elements == 3)
				{
					return IS_TRUE(v.SLong0 >= cmpVal)
						&& IS_TRUE(v.SLong1 >= cmpVal)
						&& IS_TRUE(v.SLong2 >= cmpVal);
				}
				else
				{
					return IS_TRUE(v.SLong0 >= cmpVal)
						&& IS_TRUE(v.SLong1 >= cmpVal)
						&& IS_TRUE(v.SLong2 >= cmpVal)
						&& IS_TRUE(v.SLong3 >= cmpVal);
				}
			}
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_GE_EPU8(v256 v, uint cmpVal)
			{
				return IS_TRUE(v.Byte0  >= cmpVal)
					&& IS_TRUE(v.Byte1  >= cmpVal)
					&& IS_TRUE(v.Byte2  >= cmpVal)
					&& IS_TRUE(v.Byte3  >= cmpVal)
					&& IS_TRUE(v.Byte4  >= cmpVal)
					&& IS_TRUE(v.Byte5  >= cmpVal)
					&& IS_TRUE(v.Byte6  >= cmpVal)
					&& IS_TRUE(v.Byte7  >= cmpVal)
					&& IS_TRUE(v.Byte8  >= cmpVal)
					&& IS_TRUE(v.Byte9  >= cmpVal)
					&& IS_TRUE(v.Byte10 >= cmpVal)
					&& IS_TRUE(v.Byte11 >= cmpVal)
					&& IS_TRUE(v.Byte12 >= cmpVal)
					&& IS_TRUE(v.Byte13 >= cmpVal)
					&& IS_TRUE(v.Byte14 >= cmpVal)
					&& IS_TRUE(v.Byte15 >= cmpVal)
				    && IS_TRUE(v.Byte16 >= cmpVal)
					&& IS_TRUE(v.Byte17 >= cmpVal)
					&& IS_TRUE(v.Byte18 >= cmpVal)
					&& IS_TRUE(v.Byte19 >= cmpVal)
					&& IS_TRUE(v.Byte20 >= cmpVal)
					&& IS_TRUE(v.Byte21 >= cmpVal)
					&& IS_TRUE(v.Byte22 >= cmpVal)
					&& IS_TRUE(v.Byte23 >= cmpVal)
					&& IS_TRUE(v.Byte24 >= cmpVal)
					&& IS_TRUE(v.Byte25 >= cmpVal)
					&& IS_TRUE(v.Byte26 >= cmpVal)
					&& IS_TRUE(v.Byte27 >= cmpVal)
					&& IS_TRUE(v.Byte28 >= cmpVal)
					&& IS_TRUE(v.Byte29 >= cmpVal)
					&& IS_TRUE(v.Byte30 >= cmpVal)
					&& IS_TRUE(v.Byte31 >= cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_GE_EPU16(v256 v, uint cmpVal)
			{
				return IS_TRUE(v.UShort0  >= cmpVal)
					&& IS_TRUE(v.UShort1  >= cmpVal)
					&& IS_TRUE(v.UShort2  >= cmpVal)
					&& IS_TRUE(v.UShort3  >= cmpVal)
					&& IS_TRUE(v.UShort4  >= cmpVal)
					&& IS_TRUE(v.UShort5  >= cmpVal)
					&& IS_TRUE(v.UShort6  >= cmpVal)
					&& IS_TRUE(v.UShort7  >= cmpVal)
					&& IS_TRUE(v.UShort8  >= cmpVal)
					&& IS_TRUE(v.UShort9  >= cmpVal)
					&& IS_TRUE(v.UShort10 >= cmpVal)
					&& IS_TRUE(v.UShort11 >= cmpVal)
					&& IS_TRUE(v.UShort12 >= cmpVal)
					&& IS_TRUE(v.UShort13 >= cmpVal)
					&& IS_TRUE(v.UShort14 >= cmpVal)
					&& IS_TRUE(v.UShort15 >= cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_GE_EPU32(v256 v, uint cmpVal)
			{
				return IS_TRUE(v.UInt0 >= cmpVal)
					&& IS_TRUE(v.UInt1 >= cmpVal)
					&& IS_TRUE(v.UInt2 >= cmpVal)
					&& IS_TRUE(v.UInt3 >= cmpVal)
					&& IS_TRUE(v.UInt4 >= cmpVal)
					&& IS_TRUE(v.UInt5 >= cmpVal)
					&& IS_TRUE(v.UInt6 >= cmpVal)
					&& IS_TRUE(v.UInt7 >= cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_GE_EPU64(v256 v, ulong cmpVal, byte elements = 4)
			{
				if (elements == 3)
				{
					return IS_TRUE(v.ULong0 >= cmpVal)
						&& IS_TRUE(v.ULong1 >= cmpVal)
						&& IS_TRUE(v.ULong2 >= cmpVal);
				}
				else
				{
					return IS_TRUE(v.ULong0 >= cmpVal)
						&& IS_TRUE(v.ULong1 >= cmpVal)
						&& IS_TRUE(v.ULong2 >= cmpVal)
						&& IS_TRUE(v.ULong3 >= cmpVal);
				}
			}


			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_GE_PS(v256 v, float cmpVal)
			{
				return IS_TRUE(v.Float0 >= cmpVal)
					&& IS_TRUE(v.Float1 >= cmpVal)
					&& IS_TRUE(v.Float2 >= cmpVal)
					&& IS_TRUE(v.Float3 >= cmpVal)
					&& IS_TRUE(v.Float4 >= cmpVal)
					&& IS_TRUE(v.Float5 >= cmpVal)
					&& IS_TRUE(v.Float6 >= cmpVal)
					&& IS_TRUE(v.Float7 >= cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_GE_PD(v256 v, double cmpVal, byte elements = 4)
			{
				if (elements == 3)
				{
					return IS_TRUE(v.Double0 >= cmpVal)
						&& IS_TRUE(v.Double1 >= cmpVal)
						&& IS_TRUE(v.Double2 >= cmpVal);
				}
				else
				{
					return IS_TRUE(v.Double0 >= cmpVal)
						&& IS_TRUE(v.Double1 >= cmpVal)
						&& IS_TRUE(v.Double2 >= cmpVal)
						&& IS_TRUE(v.Double3 >= cmpVal);
				}
			}


			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_LE_EPU8(v128 v, uint cmpVal, byte elements = 16)
			{
				switch (elements)
				{
					case  1: return IS_TRUE(v.Byte0  <= cmpVal);

					case  2: return IS_TRUE(v.Byte0  <= cmpVal)
								 && IS_TRUE(v.Byte1  <= cmpVal);
									
					case  3: return IS_TRUE(v.Byte0  <= cmpVal)
								 && IS_TRUE(v.Byte1  <= cmpVal)
								 && IS_TRUE(v.Byte2  <= cmpVal);

					case  4: return IS_TRUE(v.Byte0  <= cmpVal)
								 && IS_TRUE(v.Byte1  <= cmpVal)
								 && IS_TRUE(v.Byte2  <= cmpVal)
								 && IS_TRUE(v.Byte3  <= cmpVal);

					case  8: return IS_TRUE(v.Byte0  <= cmpVal)
								 && IS_TRUE(v.Byte1  <= cmpVal)
								 && IS_TRUE(v.Byte2  <= cmpVal)
								 && IS_TRUE(v.Byte3  <= cmpVal)
								 && IS_TRUE(v.Byte4  <= cmpVal)
								 && IS_TRUE(v.Byte5  <= cmpVal)
								 && IS_TRUE(v.Byte6  <= cmpVal)
								 && IS_TRUE(v.Byte7  <= cmpVal);

					default: return IS_TRUE(v.Byte0  <= cmpVal)
								 && IS_TRUE(v.Byte1  <= cmpVal)
								 && IS_TRUE(v.Byte2  <= cmpVal)
								 && IS_TRUE(v.Byte3  <= cmpVal)
								 && IS_TRUE(v.Byte4  <= cmpVal)
								 && IS_TRUE(v.Byte5  <= cmpVal)
								 && IS_TRUE(v.Byte6  <= cmpVal)
								 && IS_TRUE(v.Byte7  <= cmpVal)
								 && IS_TRUE(v.Byte8  <= cmpVal)
								 && IS_TRUE(v.Byte9  <= cmpVal)
								 && IS_TRUE(v.Byte10 <= cmpVal)
								 && IS_TRUE(v.Byte11 <= cmpVal)
								 && IS_TRUE(v.Byte12 <= cmpVal)
								 && IS_TRUE(v.Byte13 <= cmpVal)
								 && IS_TRUE(v.Byte14 <= cmpVal)
								 && IS_TRUE(v.Byte15 <= cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_LE_EPU16(v128 v, uint cmpVal, byte elements = 8)
			{
				switch (elements)
				{
					case  1: return IS_TRUE(v.UShort0  <= cmpVal);

					case  2: return IS_TRUE(v.UShort0  <= cmpVal)
								 && IS_TRUE(v.UShort1  <= cmpVal);

					case  3: return IS_TRUE(v.UShort0  <= cmpVal)
								 && IS_TRUE(v.UShort1  <= cmpVal)
								 && IS_TRUE(v.UShort2  <= cmpVal);

					case  4: return IS_TRUE(v.UShort0  <= cmpVal)
								 && IS_TRUE(v.UShort1  <= cmpVal)
								 && IS_TRUE(v.UShort2  <= cmpVal)
								 && IS_TRUE(v.UShort3  <= cmpVal);

					default: return IS_TRUE(v.UShort0  <= cmpVal)
								 && IS_TRUE(v.UShort1  <= cmpVal)
								 && IS_TRUE(v.UShort2  <= cmpVal)
								 && IS_TRUE(v.UShort3  <= cmpVal)
								 && IS_TRUE(v.UShort4  <= cmpVal)
								 && IS_TRUE(v.UShort5  <= cmpVal)
								 && IS_TRUE(v.UShort6  <= cmpVal)
								 && IS_TRUE(v.UShort7  <= cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_LE_EPU32(v128 v, uint cmpVal, byte elements = 4)
			{
				switch (elements)
				{
					case  1: return IS_TRUE(v.UInt0  <= cmpVal);

					case  2: return IS_TRUE(v.UInt0  <= cmpVal)
								 && IS_TRUE(v.UInt1  <= cmpVal);

					case  3: return IS_TRUE(v.UInt0  <= cmpVal)
								 && IS_TRUE(v.UInt1  <= cmpVal)
								 && IS_TRUE(v.UInt2  <= cmpVal);

					default: return IS_TRUE(v.UInt0  <= cmpVal)
								 && IS_TRUE(v.UInt1  <= cmpVal)
								 && IS_TRUE(v.UInt2  <= cmpVal)
								 && IS_TRUE(v.UInt3  <= cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_LE_EPU64(v128 v, ulong cmpVal, byte elements = 2)
			{
                if (elements == 1)
                {
					return IS_TRUE(v.ULong0 <= cmpVal);
                }
				else
				{
					return IS_TRUE(v.ULong0 <= cmpVal)
						&& IS_TRUE(v.ULong1 <= cmpVal);
				}
			}
			
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_LE_EPI8(v128 v, int cmpVal, byte elements = 16)
			{
				switch (elements)
				{
					case  1: return IS_TRUE(v.SByte0  <= cmpVal);

					case  2: return IS_TRUE(v.SByte0  <= cmpVal)
								 && IS_TRUE(v.SByte1  <= cmpVal);

					case  3: return IS_TRUE(v.SByte0  <= cmpVal)
								 && IS_TRUE(v.SByte1  <= cmpVal)
								 && IS_TRUE(v.SByte2  <= cmpVal);

					case  4: return IS_TRUE(v.SByte0  <= cmpVal)
								 && IS_TRUE(v.SByte1  <= cmpVal)
								 && IS_TRUE(v.SByte2  <= cmpVal)
								 && IS_TRUE(v.SByte3  <= cmpVal);

					case  8: return IS_TRUE(v.SByte0  <= cmpVal)
								 && IS_TRUE(v.SByte1  <= cmpVal)
								 && IS_TRUE(v.SByte2  <= cmpVal)
								 && IS_TRUE(v.SByte3  <= cmpVal)
								 && IS_TRUE(v.SByte4  <= cmpVal)
								 && IS_TRUE(v.SByte5  <= cmpVal)
								 && IS_TRUE(v.SByte6  <= cmpVal)
								 && IS_TRUE(v.SByte7  <= cmpVal);

					default: return IS_TRUE(v.SByte0  <= cmpVal)
								 && IS_TRUE(v.SByte1  <= cmpVal)
								 && IS_TRUE(v.SByte2  <= cmpVal)
								 && IS_TRUE(v.SByte3  <= cmpVal)
								 && IS_TRUE(v.SByte4  <= cmpVal)
								 && IS_TRUE(v.SByte5  <= cmpVal)
								 && IS_TRUE(v.SByte6  <= cmpVal)
								 && IS_TRUE(v.SByte7  <= cmpVal)
								 && IS_TRUE(v.SByte8  <= cmpVal)
								 && IS_TRUE(v.SByte9  <= cmpVal)
								 && IS_TRUE(v.SByte10 <= cmpVal)
								 && IS_TRUE(v.SByte11 <= cmpVal)
								 && IS_TRUE(v.SByte12 <= cmpVal)
								 && IS_TRUE(v.SByte13 <= cmpVal)
								 && IS_TRUE(v.SByte14 <= cmpVal)
								 && IS_TRUE(v.SByte15 <= cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_LE_EPI16(v128 v, int cmpVal, byte elements = 8)
			{
				switch (elements)
				{
					case  1: return IS_TRUE(v.SShort0 <= cmpVal);

					case  2: return IS_TRUE(v.SShort0 <= cmpVal)
								 && IS_TRUE(v.SShort1 <= cmpVal);

					case  3: return IS_TRUE(v.SShort0 <= cmpVal)
								 && IS_TRUE(v.SShort1 <= cmpVal)
								 && IS_TRUE(v.SShort2 <= cmpVal);

					case  4: return IS_TRUE(v.SShort0 <= cmpVal)
								 && IS_TRUE(v.SShort1 <= cmpVal)
								 && IS_TRUE(v.SShort2 <= cmpVal)
								 && IS_TRUE(v.SShort3 <= cmpVal);

					default: return IS_TRUE(v.SShort0 <= cmpVal)
								 && IS_TRUE(v.SShort1 <= cmpVal)
								 && IS_TRUE(v.SShort2 <= cmpVal)
								 && IS_TRUE(v.SShort3 <= cmpVal)
								 && IS_TRUE(v.SShort4 <= cmpVal)
								 && IS_TRUE(v.SShort5 <= cmpVal)
								 && IS_TRUE(v.SShort6 <= cmpVal)
								 && IS_TRUE(v.SShort7 <= cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_LE_EPI32(v128 v, int cmpVal, byte elements = 4)
			{
				switch (elements)
				{
					case  1: return IS_TRUE(v.SInt0 <= cmpVal);

					case  2: return IS_TRUE(v.SInt0 <= cmpVal)
								 && IS_TRUE(v.SInt1 <= cmpVal);

					case  3: return IS_TRUE(v.SInt0 <= cmpVal)
								 && IS_TRUE(v.SInt1 <= cmpVal)
								 && IS_TRUE(v.SInt2 <= cmpVal);

					default: return IS_TRUE(v.SInt0 <= cmpVal)
								 && IS_TRUE(v.SInt1 <= cmpVal)
								 && IS_TRUE(v.SInt2 <= cmpVal)
								 && IS_TRUE(v.SInt3 <= cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_LE_EPI64(v128 v, long cmpVal, byte elements = 2)
			{
                if (elements == 1)
                {
					return IS_TRUE(v.SLong0 <= cmpVal);
                }
				else
				{
					return IS_TRUE(v.SLong0 <= cmpVal)
						&& IS_TRUE(v.SLong1 <= cmpVal);
				}
			}
			
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_LE_PS(v128 v, float cmpVal, byte elements = 4)
			{
				switch (elements)
				{
					case  1: return IS_TRUE(v.Float0 <= cmpVal);

					case  2: return IS_TRUE(v.Float0 <= cmpVal)
								 && IS_TRUE(v.Float1 <= cmpVal);

					case  3: return IS_TRUE(v.Float0 <= cmpVal)
								 && IS_TRUE(v.Float1 <= cmpVal)
								 && IS_TRUE(v.Float2 <= cmpVal);

					default: return IS_TRUE(v.Float0 <= cmpVal)
								 && IS_TRUE(v.Float1 <= cmpVal)
								 && IS_TRUE(v.Float2 <= cmpVal)
								 && IS_TRUE(v.Float3 <= cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_LE_PD(v128 v, double cmpVal, byte elements = 2)
			{
                if (elements == 1)
                {
					return IS_TRUE(v.Double0 <= cmpVal);
                }
				else
				{
					return IS_TRUE(v.Double0 <= cmpVal)
						&& IS_TRUE(v.Double1 <= cmpVal);
				}
			}


			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_LE_EPI8(v256 v, int cmpVal)
			{
				return IS_TRUE(v.SByte0  <= cmpVal)
					&& IS_TRUE(v.SByte1  <= cmpVal)
					&& IS_TRUE(v.SByte2  <= cmpVal)
					&& IS_TRUE(v.SByte3  <= cmpVal)
					&& IS_TRUE(v.SByte4  <= cmpVal)
					&& IS_TRUE(v.SByte5  <= cmpVal)
					&& IS_TRUE(v.SByte6  <= cmpVal)
					&& IS_TRUE(v.SByte7  <= cmpVal)
					&& IS_TRUE(v.SByte8  <= cmpVal)
					&& IS_TRUE(v.SByte9  <= cmpVal)
					&& IS_TRUE(v.SByte10 <= cmpVal)
					&& IS_TRUE(v.SByte11 <= cmpVal)
					&& IS_TRUE(v.SByte12 <= cmpVal)
					&& IS_TRUE(v.SByte13 <= cmpVal)
					&& IS_TRUE(v.SByte14 <= cmpVal)
					&& IS_TRUE(v.SByte15 <= cmpVal)
				    && IS_TRUE(v.SByte16 <= cmpVal)
					&& IS_TRUE(v.SByte17 <= cmpVal)
					&& IS_TRUE(v.SByte18 <= cmpVal)
					&& IS_TRUE(v.SByte19 <= cmpVal)
					&& IS_TRUE(v.SByte20 <= cmpVal)
					&& IS_TRUE(v.SByte21 <= cmpVal)
					&& IS_TRUE(v.SByte22 <= cmpVal)
					&& IS_TRUE(v.SByte23 <= cmpVal)
					&& IS_TRUE(v.SByte24 <= cmpVal)
					&& IS_TRUE(v.SByte25 <= cmpVal)
					&& IS_TRUE(v.SByte26 <= cmpVal)
					&& IS_TRUE(v.SByte27 <= cmpVal)
					&& IS_TRUE(v.SByte28 <= cmpVal)
					&& IS_TRUE(v.SByte29 <= cmpVal)
					&& IS_TRUE(v.SByte30 <= cmpVal)
					&& IS_TRUE(v.SByte31 <= cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_LE_EPI16(v256 v, int cmpVal)
			{
				return IS_TRUE(v.SShort0  <= cmpVal)
					&& IS_TRUE(v.SShort1  <= cmpVal)
					&& IS_TRUE(v.SShort2  <= cmpVal)
					&& IS_TRUE(v.SShort3  <= cmpVal)
					&& IS_TRUE(v.SShort4  <= cmpVal)
					&& IS_TRUE(v.SShort5  <= cmpVal)
					&& IS_TRUE(v.SShort6  <= cmpVal)
					&& IS_TRUE(v.SShort7  <= cmpVal)
					&& IS_TRUE(v.SShort8  <= cmpVal)
					&& IS_TRUE(v.SShort9  <= cmpVal)
					&& IS_TRUE(v.SShort10 <= cmpVal)
					&& IS_TRUE(v.SShort11 <= cmpVal)
					&& IS_TRUE(v.SShort12 <= cmpVal)
					&& IS_TRUE(v.SShort13 <= cmpVal)
					&& IS_TRUE(v.SShort14 <= cmpVal)
					&& IS_TRUE(v.SShort15 <= cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_LE_EPI32(v256 v, int cmpVal)
			{
				return IS_TRUE(v.SInt0 <= cmpVal)
					&& IS_TRUE(v.SInt1 <= cmpVal)
					&& IS_TRUE(v.SInt2 <= cmpVal)
					&& IS_TRUE(v.SInt3 <= cmpVal)
					&& IS_TRUE(v.SInt4 <= cmpVal)
					&& IS_TRUE(v.SInt5 <= cmpVal)
					&& IS_TRUE(v.SInt6 <= cmpVal)
					&& IS_TRUE(v.SInt7 <= cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_LE_EPI64(v256 v, long cmpVal, byte elements = 4)
			{
				if (elements == 3)
				{
					return IS_TRUE(v.SLong0 <= cmpVal)
						&& IS_TRUE(v.SLong1 <= cmpVal)
						&& IS_TRUE(v.SLong2 <= cmpVal);
				}
				else
				{
					return IS_TRUE(v.SLong0 <= cmpVal)
						&& IS_TRUE(v.SLong1 <= cmpVal)
						&& IS_TRUE(v.SLong2 <= cmpVal)
						&& IS_TRUE(v.SLong3 <= cmpVal);
				}
			}
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_LE_EPU8(v256 v, uint cmpVal)
			{
				return IS_TRUE(v.Byte0  <= cmpVal)
					&& IS_TRUE(v.Byte1  <= cmpVal)
					&& IS_TRUE(v.Byte2  <= cmpVal)
					&& IS_TRUE(v.Byte3  <= cmpVal)
					&& IS_TRUE(v.Byte4  <= cmpVal)
					&& IS_TRUE(v.Byte5  <= cmpVal)
					&& IS_TRUE(v.Byte6  <= cmpVal)
					&& IS_TRUE(v.Byte7  <= cmpVal)
					&& IS_TRUE(v.Byte8  <= cmpVal)
					&& IS_TRUE(v.Byte9  <= cmpVal)
					&& IS_TRUE(v.Byte10 <= cmpVal)
					&& IS_TRUE(v.Byte11 <= cmpVal)
					&& IS_TRUE(v.Byte12 <= cmpVal)
					&& IS_TRUE(v.Byte13 <= cmpVal)
					&& IS_TRUE(v.Byte14 <= cmpVal)
					&& IS_TRUE(v.Byte15 <= cmpVal)
				    && IS_TRUE(v.Byte16 <= cmpVal)
					&& IS_TRUE(v.Byte17 <= cmpVal)
					&& IS_TRUE(v.Byte18 <= cmpVal)
					&& IS_TRUE(v.Byte19 <= cmpVal)
					&& IS_TRUE(v.Byte20 <= cmpVal)
					&& IS_TRUE(v.Byte21 <= cmpVal)
					&& IS_TRUE(v.Byte22 <= cmpVal)
					&& IS_TRUE(v.Byte23 <= cmpVal)
					&& IS_TRUE(v.Byte24 <= cmpVal)
					&& IS_TRUE(v.Byte25 <= cmpVal)
					&& IS_TRUE(v.Byte26 <= cmpVal)
					&& IS_TRUE(v.Byte27 <= cmpVal)
					&& IS_TRUE(v.Byte28 <= cmpVal)
					&& IS_TRUE(v.Byte29 <= cmpVal)
					&& IS_TRUE(v.Byte30 <= cmpVal)
					&& IS_TRUE(v.Byte31 <= cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_LE_EPU16(v256 v, uint cmpVal)
			{
				return IS_TRUE(v.UShort0  <= cmpVal)
					&& IS_TRUE(v.UShort1  <= cmpVal)
					&& IS_TRUE(v.UShort2  <= cmpVal)
					&& IS_TRUE(v.UShort3  <= cmpVal)
					&& IS_TRUE(v.UShort4  <= cmpVal)
					&& IS_TRUE(v.UShort5  <= cmpVal)
					&& IS_TRUE(v.UShort6  <= cmpVal)
					&& IS_TRUE(v.UShort7  <= cmpVal)
					&& IS_TRUE(v.UShort8  <= cmpVal)
					&& IS_TRUE(v.UShort9  <= cmpVal)
					&& IS_TRUE(v.UShort10 <= cmpVal)
					&& IS_TRUE(v.UShort11 <= cmpVal)
					&& IS_TRUE(v.UShort12 <= cmpVal)
					&& IS_TRUE(v.UShort13 <= cmpVal)
					&& IS_TRUE(v.UShort14 <= cmpVal)
					&& IS_TRUE(v.UShort15 <= cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_LE_EPU32(v256 v, uint cmpVal)
			{
				return IS_TRUE(v.UInt0 <= cmpVal)
					&& IS_TRUE(v.UInt1 <= cmpVal)
					&& IS_TRUE(v.UInt2 <= cmpVal)
					&& IS_TRUE(v.UInt3 <= cmpVal)
					&& IS_TRUE(v.UInt4 <= cmpVal)
					&& IS_TRUE(v.UInt5 <= cmpVal)
					&& IS_TRUE(v.UInt6 <= cmpVal)
					&& IS_TRUE(v.UInt7 <= cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_LE_EPU64(v256 v, ulong cmpVal, byte elements = 4)
			{
				if (elements == 3)
				{
					return IS_TRUE(v.ULong0 <= cmpVal)
						&& IS_TRUE(v.ULong1 <= cmpVal)
						&& IS_TRUE(v.ULong2 <= cmpVal);
				}
				else
				{
					return IS_TRUE(v.ULong0 <= cmpVal)
						&& IS_TRUE(v.ULong1 <= cmpVal)
						&& IS_TRUE(v.ULong2 <= cmpVal)
						&& IS_TRUE(v.ULong3 <= cmpVal);
				}
			}


			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_LE_PS(v256 v, float cmpVal)
			{
				return IS_TRUE(v.Float0 <= cmpVal)
					&& IS_TRUE(v.Float1 <= cmpVal)
					&& IS_TRUE(v.Float2 <= cmpVal)
					&& IS_TRUE(v.Float3 <= cmpVal)
					&& IS_TRUE(v.Float4 <= cmpVal)
					&& IS_TRUE(v.Float5 <= cmpVal)
					&& IS_TRUE(v.Float6 <= cmpVal)
					&& IS_TRUE(v.Float7 <= cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_LE_PD(v256 v, double cmpVal, byte elements = 4)
			{
				if (elements == 3)
				{
					return IS_TRUE(v.Double0 <= cmpVal)
						&& IS_TRUE(v.Double1 <= cmpVal)
						&& IS_TRUE(v.Double2 <= cmpVal);
				}
				else
				{
					return IS_TRUE(v.Double0 <= cmpVal)
						&& IS_TRUE(v.Double1 <= cmpVal)
						&& IS_TRUE(v.Double2 <= cmpVal)
						&& IS_TRUE(v.Double3 <= cmpVal);
				}
			}


			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_EQ_EPU8(v128 v, uint cmpVal, byte elements = 16)
			{
				switch (elements)
				{
					case  2: return IS_TRUE(v.Byte0  == cmpVal)
								 || IS_TRUE(v.Byte1  == cmpVal);
									
					case  3: return IS_TRUE(v.Byte0  == cmpVal)
								 || IS_TRUE(v.Byte1  == cmpVal)
								 || IS_TRUE(v.Byte2  == cmpVal);

					case  4: return IS_TRUE(v.Byte0  == cmpVal)
								 || IS_TRUE(v.Byte1  == cmpVal)
								 || IS_TRUE(v.Byte2  == cmpVal)
								 || IS_TRUE(v.Byte3  == cmpVal);

					case  8: return IS_TRUE(v.Byte0  == cmpVal)
								 || IS_TRUE(v.Byte1  == cmpVal)
								 || IS_TRUE(v.Byte2  == cmpVal)
								 || IS_TRUE(v.Byte3  == cmpVal)
								 || IS_TRUE(v.Byte4  == cmpVal)
								 || IS_TRUE(v.Byte5  == cmpVal)
								 || IS_TRUE(v.Byte6  == cmpVal)
								 || IS_TRUE(v.Byte7  == cmpVal);

					default: return IS_TRUE(v.Byte0  == cmpVal)
								 || IS_TRUE(v.Byte1  == cmpVal)
								 || IS_TRUE(v.Byte2  == cmpVal)
								 || IS_TRUE(v.Byte3  == cmpVal)
								 || IS_TRUE(v.Byte4  == cmpVal)
								 || IS_TRUE(v.Byte5  == cmpVal)
								 || IS_TRUE(v.Byte6  == cmpVal)
								 || IS_TRUE(v.Byte7  == cmpVal)
								 || IS_TRUE(v.Byte8  == cmpVal)
								 || IS_TRUE(v.Byte9  == cmpVal)
								 || IS_TRUE(v.Byte10 == cmpVal)
								 || IS_TRUE(v.Byte11 == cmpVal)
								 || IS_TRUE(v.Byte12 == cmpVal)
								 || IS_TRUE(v.Byte13 == cmpVal)
								 || IS_TRUE(v.Byte14 == cmpVal)
								 || IS_TRUE(v.Byte15 == cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_EQ_EPU16(v128 v, uint cmpVal, byte elements = 8)
			{
				switch (elements)
				{
					case  2: return IS_TRUE(v.UShort0  == cmpVal)
								 || IS_TRUE(v.UShort1  == cmpVal);

					case  3: return IS_TRUE(v.UShort0  == cmpVal)
								 || IS_TRUE(v.UShort1  == cmpVal)
								 || IS_TRUE(v.UShort2  == cmpVal);

					case  4: return IS_TRUE(v.UShort0  == cmpVal)
								 || IS_TRUE(v.UShort1  == cmpVal)
								 || IS_TRUE(v.UShort2  == cmpVal)
								 || IS_TRUE(v.UShort3  == cmpVal);

					default: return IS_TRUE(v.UShort0  == cmpVal)
								 || IS_TRUE(v.UShort1  == cmpVal)
								 || IS_TRUE(v.UShort2  == cmpVal)
								 || IS_TRUE(v.UShort3  == cmpVal)
								 || IS_TRUE(v.UShort4  == cmpVal)
								 || IS_TRUE(v.UShort5  == cmpVal)
								 || IS_TRUE(v.UShort6  == cmpVal)
								 || IS_TRUE(v.UShort7  == cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_EQ_EPU32(v128 v, uint cmpVal, byte elements = 4)
			{
				switch (elements)
				{
					case  2: return IS_TRUE(v.UInt0  == cmpVal)
								 || IS_TRUE(v.UInt1  == cmpVal);

					case  3: return IS_TRUE(v.UInt0  == cmpVal)
								 || IS_TRUE(v.UInt1  == cmpVal)
								 || IS_TRUE(v.UInt2  == cmpVal);

					default: return IS_TRUE(v.UInt0  == cmpVal)
								 || IS_TRUE(v.UInt1  == cmpVal)
								 || IS_TRUE(v.UInt2  == cmpVal)
								 || IS_TRUE(v.UInt3  == cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_EQ_EPU64(v128 v, ulong cmpVal)
			{
				return IS_TRUE(v.ULong0 == cmpVal)
					|| IS_TRUE(v.ULong1 == cmpVal);
			}
			
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_EQ_EPI8(v128 v, int cmpVal, byte elements = 16)
			{
				switch (elements)
				{
					case  2: return IS_TRUE(v.SByte0  == cmpVal)
								 || IS_TRUE(v.SByte1  == cmpVal);

					case  3: return IS_TRUE(v.SByte0  == cmpVal)
								 || IS_TRUE(v.SByte1  == cmpVal)
								 || IS_TRUE(v.SByte2  == cmpVal);

					case  4: return IS_TRUE(v.SByte0  == cmpVal)
								 || IS_TRUE(v.SByte1  == cmpVal)
								 || IS_TRUE(v.SByte2  == cmpVal)
								 || IS_TRUE(v.SByte3  == cmpVal);

					case  8: return IS_TRUE(v.SByte0  == cmpVal)
								 || IS_TRUE(v.SByte1  == cmpVal)
								 || IS_TRUE(v.SByte2  == cmpVal)
								 || IS_TRUE(v.SByte3  == cmpVal)
								 || IS_TRUE(v.SByte4  == cmpVal)
								 || IS_TRUE(v.SByte5  == cmpVal)
								 || IS_TRUE(v.SByte6  == cmpVal)
								 || IS_TRUE(v.SByte7  == cmpVal);

					default: return IS_TRUE(v.SByte0  == cmpVal)
								 || IS_TRUE(v.SByte1  == cmpVal)
								 || IS_TRUE(v.SByte2  == cmpVal)
								 || IS_TRUE(v.SByte3  == cmpVal)
								 || IS_TRUE(v.SByte4  == cmpVal)
								 || IS_TRUE(v.SByte5  == cmpVal)
								 || IS_TRUE(v.SByte6  == cmpVal)
								 || IS_TRUE(v.SByte7  == cmpVal)
								 || IS_TRUE(v.SByte8  == cmpVal)
								 || IS_TRUE(v.SByte9  == cmpVal)
								 || IS_TRUE(v.SByte10 == cmpVal)
								 || IS_TRUE(v.SByte11 == cmpVal)
								 || IS_TRUE(v.SByte12 == cmpVal)
								 || IS_TRUE(v.SByte13 == cmpVal)
								 || IS_TRUE(v.SByte14 == cmpVal)
								 || IS_TRUE(v.SByte15 == cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_EQ_EPI16(v128 v, int cmpVal, byte elements = 8)
			{
				switch (elements)
				{
					case  2: return IS_TRUE(v.SShort0 == cmpVal)
								 || IS_TRUE(v.SShort1 == cmpVal);

					case  3: return IS_TRUE(v.SShort0 == cmpVal)
								 || IS_TRUE(v.SShort1 == cmpVal)
								 || IS_TRUE(v.SShort2 == cmpVal);

					case  4: return IS_TRUE(v.SShort0 == cmpVal)
								 || IS_TRUE(v.SShort1 == cmpVal)
								 || IS_TRUE(v.SShort2 == cmpVal)
								 || IS_TRUE(v.SShort3 == cmpVal);

					default: return IS_TRUE(v.SShort0 == cmpVal)
								 || IS_TRUE(v.SShort1 == cmpVal)
								 || IS_TRUE(v.SShort2 == cmpVal)
								 || IS_TRUE(v.SShort3 == cmpVal)
								 || IS_TRUE(v.SShort4 == cmpVal)
								 || IS_TRUE(v.SShort5 == cmpVal)
								 || IS_TRUE(v.SShort6 == cmpVal)
								 || IS_TRUE(v.SShort7 == cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_EQ_EPI32(v128 v, int cmpVal, byte elements = 4)
			{
				switch (elements)
				{
					case  2: return IS_TRUE(v.SInt0 == cmpVal)
								 || IS_TRUE(v.SInt1 == cmpVal);

					case  3: return IS_TRUE(v.SInt0 == cmpVal)
								 || IS_TRUE(v.SInt1 == cmpVal)
								 || IS_TRUE(v.SInt2 == cmpVal);

					default: return IS_TRUE(v.SInt0 == cmpVal)
								 || IS_TRUE(v.SInt1 == cmpVal)
								 || IS_TRUE(v.SInt2 == cmpVal)
								 || IS_TRUE(v.SInt3 == cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_EQ_EPI64(v128 v, long cmpVal)
			{
				return IS_TRUE(v.SLong0 == cmpVal)
					|| IS_TRUE(v.SLong1 == cmpVal);
			}
			
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_EQ_PS(v128 v, float cmpVal, byte elements = 4)
			{
				switch (elements)
				{
					case  1: return IS_TRUE(v.Float0 == cmpVal);

					case  2: return IS_TRUE(v.Float0 == cmpVal)
								 || IS_TRUE(v.Float1 == cmpVal);

					case  3: return IS_TRUE(v.Float0 == cmpVal)
								 || IS_TRUE(v.Float1 == cmpVal)
								 || IS_TRUE(v.Float2 == cmpVal);

					default: return IS_TRUE(v.Float0 == cmpVal)
								 || IS_TRUE(v.Float1 == cmpVal)
								 || IS_TRUE(v.Float2 == cmpVal)
								 || IS_TRUE(v.Float3 == cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_EQ_PD(v128 v, double cmpVal)
			{
				return IS_TRUE(v.Double0 == cmpVal)
					|| IS_TRUE(v.Double1 == cmpVal);
			}


			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_EQ_EPI8(v256 v, int cmpVal)
			{
				return IS_TRUE(v.SByte0  == cmpVal)
					|| IS_TRUE(v.SByte1  == cmpVal)
					|| IS_TRUE(v.SByte2  == cmpVal)
					|| IS_TRUE(v.SByte3  == cmpVal)
					|| IS_TRUE(v.SByte4  == cmpVal)
					|| IS_TRUE(v.SByte5  == cmpVal)
					|| IS_TRUE(v.SByte6  == cmpVal)
					|| IS_TRUE(v.SByte7  == cmpVal)
					|| IS_TRUE(v.SByte8  == cmpVal)
					|| IS_TRUE(v.SByte9  == cmpVal)
					|| IS_TRUE(v.SByte10 == cmpVal)
					|| IS_TRUE(v.SByte11 == cmpVal)
					|| IS_TRUE(v.SByte12 == cmpVal)
					|| IS_TRUE(v.SByte13 == cmpVal)
					|| IS_TRUE(v.SByte14 == cmpVal)
					|| IS_TRUE(v.SByte15 == cmpVal)
				    || IS_TRUE(v.SByte16 == cmpVal)
					|| IS_TRUE(v.SByte17 == cmpVal)
					|| IS_TRUE(v.SByte18 == cmpVal)
					|| IS_TRUE(v.SByte19 == cmpVal)
					|| IS_TRUE(v.SByte20 == cmpVal)
					|| IS_TRUE(v.SByte21 == cmpVal)
					|| IS_TRUE(v.SByte22 == cmpVal)
					|| IS_TRUE(v.SByte23 == cmpVal)
					|| IS_TRUE(v.SByte24 == cmpVal)
					|| IS_TRUE(v.SByte25 == cmpVal)
					|| IS_TRUE(v.SByte26 == cmpVal)
					|| IS_TRUE(v.SByte27 == cmpVal)
					|| IS_TRUE(v.SByte28 == cmpVal)
					|| IS_TRUE(v.SByte29 == cmpVal)
					|| IS_TRUE(v.SByte30 == cmpVal)
					|| IS_TRUE(v.SByte31 == cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_EQ_EPI16(v256 v, int cmpVal)
			{
				return IS_TRUE(v.SShort0  == cmpVal)
					|| IS_TRUE(v.SShort1  == cmpVal)
					|| IS_TRUE(v.SShort2  == cmpVal)
					|| IS_TRUE(v.SShort3  == cmpVal)
					|| IS_TRUE(v.SShort4  == cmpVal)
					|| IS_TRUE(v.SShort5  == cmpVal)
					|| IS_TRUE(v.SShort6  == cmpVal)
					|| IS_TRUE(v.SShort7  == cmpVal)
					|| IS_TRUE(v.SShort8  == cmpVal)
					|| IS_TRUE(v.SShort9  == cmpVal)
					|| IS_TRUE(v.SShort10 == cmpVal)
					|| IS_TRUE(v.SShort11 == cmpVal)
					|| IS_TRUE(v.SShort12 == cmpVal)
					|| IS_TRUE(v.SShort13 == cmpVal)
					|| IS_TRUE(v.SShort14 == cmpVal)
					|| IS_TRUE(v.SShort15 == cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_EQ_EPI32(v256 v, int cmpVal)
			{
				return IS_TRUE(v.SInt0 == cmpVal)
					|| IS_TRUE(v.SInt1 == cmpVal)
					|| IS_TRUE(v.SInt2 == cmpVal)
					|| IS_TRUE(v.SInt3 == cmpVal)
					|| IS_TRUE(v.SInt4 == cmpVal)
					|| IS_TRUE(v.SInt5 == cmpVal)
					|| IS_TRUE(v.SInt6 == cmpVal)
					|| IS_TRUE(v.SInt7 == cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_EQ_EPI64(v256 v, long cmpVal, byte elements = 4)
			{
				if (elements == 3)
				{
					return IS_TRUE(v.SLong0 == cmpVal)
						|| IS_TRUE(v.SLong1 == cmpVal)
						|| IS_TRUE(v.SLong2 == cmpVal);
				}
				else
				{
					return IS_TRUE(v.SLong0 == cmpVal)
						|| IS_TRUE(v.SLong1 == cmpVal)
						|| IS_TRUE(v.SLong2 == cmpVal)
						|| IS_TRUE(v.SLong3 == cmpVal);
				}
			}
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_EQ_EPU8(v256 v, uint cmpVal)
			{
				return IS_TRUE(v.Byte0  == cmpVal)
					|| IS_TRUE(v.Byte1  == cmpVal)
					|| IS_TRUE(v.Byte2  == cmpVal)
					|| IS_TRUE(v.Byte3  == cmpVal)
					|| IS_TRUE(v.Byte4  == cmpVal)
					|| IS_TRUE(v.Byte5  == cmpVal)
					|| IS_TRUE(v.Byte6  == cmpVal)
					|| IS_TRUE(v.Byte7  == cmpVal)
					|| IS_TRUE(v.Byte8  == cmpVal)
					|| IS_TRUE(v.Byte9  == cmpVal)
					|| IS_TRUE(v.Byte10 == cmpVal)
					|| IS_TRUE(v.Byte11 == cmpVal)
					|| IS_TRUE(v.Byte12 == cmpVal)
					|| IS_TRUE(v.Byte13 == cmpVal)
					|| IS_TRUE(v.Byte14 == cmpVal)
					|| IS_TRUE(v.Byte15 == cmpVal)
				    || IS_TRUE(v.Byte16 == cmpVal)
					|| IS_TRUE(v.Byte17 == cmpVal)
					|| IS_TRUE(v.Byte18 == cmpVal)
					|| IS_TRUE(v.Byte19 == cmpVal)
					|| IS_TRUE(v.Byte20 == cmpVal)
					|| IS_TRUE(v.Byte21 == cmpVal)
					|| IS_TRUE(v.Byte22 == cmpVal)
					|| IS_TRUE(v.Byte23 == cmpVal)
					|| IS_TRUE(v.Byte24 == cmpVal)
					|| IS_TRUE(v.Byte25 == cmpVal)
					|| IS_TRUE(v.Byte26 == cmpVal)
					|| IS_TRUE(v.Byte27 == cmpVal)
					|| IS_TRUE(v.Byte28 == cmpVal)
					|| IS_TRUE(v.Byte29 == cmpVal)
					|| IS_TRUE(v.Byte30 == cmpVal)
					|| IS_TRUE(v.Byte31 == cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_EQ_EPU16(v256 v, uint cmpVal)
			{
				return IS_TRUE(v.UShort0  == cmpVal)
					|| IS_TRUE(v.UShort1  == cmpVal)
					|| IS_TRUE(v.UShort2  == cmpVal)
					|| IS_TRUE(v.UShort3  == cmpVal)
					|| IS_TRUE(v.UShort4  == cmpVal)
					|| IS_TRUE(v.UShort5  == cmpVal)
					|| IS_TRUE(v.UShort6  == cmpVal)
					|| IS_TRUE(v.UShort7  == cmpVal)
					|| IS_TRUE(v.UShort8  == cmpVal)
					|| IS_TRUE(v.UShort9  == cmpVal)
					|| IS_TRUE(v.UShort10 == cmpVal)
					|| IS_TRUE(v.UShort11 == cmpVal)
					|| IS_TRUE(v.UShort12 == cmpVal)
					|| IS_TRUE(v.UShort13 == cmpVal)
					|| IS_TRUE(v.UShort14 == cmpVal)
					|| IS_TRUE(v.UShort15 == cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_EQ_EPU32(v256 v, uint cmpVal)
			{
				return IS_TRUE(v.UInt0 == cmpVal)
					|| IS_TRUE(v.UInt1 == cmpVal)
					|| IS_TRUE(v.UInt2 == cmpVal)
					|| IS_TRUE(v.UInt3 == cmpVal)
					|| IS_TRUE(v.UInt4 == cmpVal)
					|| IS_TRUE(v.UInt5 == cmpVal)
					|| IS_TRUE(v.UInt6 == cmpVal)
					|| IS_TRUE(v.UInt7 == cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_EQ_EPU64(v256 v, ulong cmpVal, byte elements = 4)
			{
				if (elements == 3)
				{
					return IS_TRUE(v.ULong0 == cmpVal)
						|| IS_TRUE(v.ULong1 == cmpVal)
						|| IS_TRUE(v.ULong2 == cmpVal);
				}
				else
				{
					return IS_TRUE(v.ULong0 == cmpVal)
						|| IS_TRUE(v.ULong1 == cmpVal)
						|| IS_TRUE(v.ULong2 == cmpVal)
						|| IS_TRUE(v.ULong3 == cmpVal);
				}
			}


			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_EQ_PS(v256 v, float cmpVal)
			{
				return IS_TRUE(v.Float0 == cmpVal)
					|| IS_TRUE(v.Float1 == cmpVal)
					|| IS_TRUE(v.Float2 == cmpVal)
					|| IS_TRUE(v.Float3 == cmpVal)
					|| IS_TRUE(v.Float4 == cmpVal)
					|| IS_TRUE(v.Float5 == cmpVal)
					|| IS_TRUE(v.Float6 == cmpVal)
					|| IS_TRUE(v.Float7 == cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_EQ_PD(v256 v, double cmpVal, byte elements = 4)
			{
				if (elements == 3)
				{
					return IS_TRUE(v.Double0 == cmpVal)
						|| IS_TRUE(v.Double1 == cmpVal)
						|| IS_TRUE(v.Double2 == cmpVal);
				}
				else
				{
					return IS_TRUE(v.Double0 == cmpVal)
						|| IS_TRUE(v.Double1 == cmpVal)
						|| IS_TRUE(v.Double2 == cmpVal)
						|| IS_TRUE(v.Double3 == cmpVal);
				}
			}


			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_NEQ_EPU8(v128 v, uint cmpVal, byte elements = 16)
			{
				switch (elements)
				{
					case  2: return IS_TRUE(v.Byte0  != cmpVal)
								 || IS_TRUE(v.Byte1  != cmpVal);
									
					case  3: return IS_TRUE(v.Byte0  != cmpVal)
								 || IS_TRUE(v.Byte1  != cmpVal)
								 || IS_TRUE(v.Byte2  != cmpVal);

					case  4: return IS_TRUE(v.Byte0  != cmpVal)
								 || IS_TRUE(v.Byte1  != cmpVal)
								 || IS_TRUE(v.Byte2  != cmpVal)
								 || IS_TRUE(v.Byte3  != cmpVal);

					case  8: return IS_TRUE(v.Byte0  != cmpVal)
								 || IS_TRUE(v.Byte1  != cmpVal)
								 || IS_TRUE(v.Byte2  != cmpVal)
								 || IS_TRUE(v.Byte3  != cmpVal)
								 || IS_TRUE(v.Byte4  != cmpVal)
								 || IS_TRUE(v.Byte5  != cmpVal)
								 || IS_TRUE(v.Byte6  != cmpVal)
								 || IS_TRUE(v.Byte7  != cmpVal);

					default: return IS_TRUE(v.Byte0  != cmpVal)
								 || IS_TRUE(v.Byte1  != cmpVal)
								 || IS_TRUE(v.Byte2  != cmpVal)
								 || IS_TRUE(v.Byte3  != cmpVal)
								 || IS_TRUE(v.Byte4  != cmpVal)
								 || IS_TRUE(v.Byte5  != cmpVal)
								 || IS_TRUE(v.Byte6  != cmpVal)
								 || IS_TRUE(v.Byte7  != cmpVal)
								 || IS_TRUE(v.Byte8  != cmpVal)
								 || IS_TRUE(v.Byte9  != cmpVal)
								 || IS_TRUE(v.Byte10 != cmpVal)
								 || IS_TRUE(v.Byte11 != cmpVal)
								 || IS_TRUE(v.Byte12 != cmpVal)
								 || IS_TRUE(v.Byte13 != cmpVal)
								 || IS_TRUE(v.Byte14 != cmpVal)
								 || IS_TRUE(v.Byte15 != cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_NEQ_EPU16(v128 v, uint cmpVal, byte elements = 8)
			{
				switch (elements)
				{
					case  2: return IS_TRUE(v.UShort0  != cmpVal)
								 || IS_TRUE(v.UShort1  != cmpVal);

					case  3: return IS_TRUE(v.UShort0  != cmpVal)
								 || IS_TRUE(v.UShort1  != cmpVal)
								 || IS_TRUE(v.UShort2  != cmpVal);

					case  4: return IS_TRUE(v.UShort0  != cmpVal)
								 || IS_TRUE(v.UShort1  != cmpVal)
								 || IS_TRUE(v.UShort2  != cmpVal)
								 || IS_TRUE(v.UShort3  != cmpVal);

					default: return IS_TRUE(v.UShort0  != cmpVal)
								 || IS_TRUE(v.UShort1  != cmpVal)
								 || IS_TRUE(v.UShort2  != cmpVal)
								 || IS_TRUE(v.UShort3  != cmpVal)
								 || IS_TRUE(v.UShort4  != cmpVal)
								 || IS_TRUE(v.UShort5  != cmpVal)
								 || IS_TRUE(v.UShort6  != cmpVal)
								 || IS_TRUE(v.UShort7  != cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_NEQ_EPU32(v128 v, uint cmpVal, byte elements = 4)
			{
				switch (elements)
				{
					case  2: return IS_TRUE(v.UInt0  != cmpVal)
								 || IS_TRUE(v.UInt1  != cmpVal);

					case  3: return IS_TRUE(v.UInt0  != cmpVal)
								 || IS_TRUE(v.UInt1  != cmpVal)
								 || IS_TRUE(v.UInt2  != cmpVal);

					default: return IS_TRUE(v.UInt0  != cmpVal)
								 || IS_TRUE(v.UInt1  != cmpVal)
								 || IS_TRUE(v.UInt2  != cmpVal)
								 || IS_TRUE(v.UInt3  != cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_NEQ_EPU64(v128 v, ulong cmpVal)
			{
				return IS_TRUE(v.ULong0 != cmpVal)
					|| IS_TRUE(v.ULong1 != cmpVal);
			}
			
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_NEQ_EPI8(v128 v, int cmpVal, byte elements = 16)
			{
				switch (elements)
				{
					case  2: return IS_TRUE(v.SByte0  != cmpVal)
								 || IS_TRUE(v.SByte1  != cmpVal);

					case  3: return IS_TRUE(v.SByte0  != cmpVal)
								 || IS_TRUE(v.SByte1  != cmpVal)
								 || IS_TRUE(v.SByte2  != cmpVal);

					case  4: return IS_TRUE(v.SByte0  != cmpVal)
								 || IS_TRUE(v.SByte1  != cmpVal)
								 || IS_TRUE(v.SByte2  != cmpVal)
								 || IS_TRUE(v.SByte3  != cmpVal);

					case  8: return IS_TRUE(v.SByte0  != cmpVal)
								 || IS_TRUE(v.SByte1  != cmpVal)
								 || IS_TRUE(v.SByte2  != cmpVal)
								 || IS_TRUE(v.SByte3  != cmpVal)
								 || IS_TRUE(v.SByte4  != cmpVal)
								 || IS_TRUE(v.SByte5  != cmpVal)
								 || IS_TRUE(v.SByte6  != cmpVal)
								 || IS_TRUE(v.SByte7  != cmpVal);

					default: return IS_TRUE(v.SByte0  != cmpVal)
								 || IS_TRUE(v.SByte1  != cmpVal)
								 || IS_TRUE(v.SByte2  != cmpVal)
								 || IS_TRUE(v.SByte3  != cmpVal)
								 || IS_TRUE(v.SByte4  != cmpVal)
								 || IS_TRUE(v.SByte5  != cmpVal)
								 || IS_TRUE(v.SByte6  != cmpVal)
								 || IS_TRUE(v.SByte7  != cmpVal)
								 || IS_TRUE(v.SByte8  != cmpVal)
								 || IS_TRUE(v.SByte9  != cmpVal)
								 || IS_TRUE(v.SByte10 != cmpVal)
								 || IS_TRUE(v.SByte11 != cmpVal)
								 || IS_TRUE(v.SByte12 != cmpVal)
								 || IS_TRUE(v.SByte13 != cmpVal)
								 || IS_TRUE(v.SByte14 != cmpVal)
								 || IS_TRUE(v.SByte15 != cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_NEQ_EPI16(v128 v, int cmpVal, byte elements = 8)
			{
				switch (elements)
				{
					case  2: return IS_TRUE(v.SShort0 != cmpVal)
								 || IS_TRUE(v.SShort1 != cmpVal);

					case  3: return IS_TRUE(v.SShort0 != cmpVal)
								 || IS_TRUE(v.SShort1 != cmpVal)
								 || IS_TRUE(v.SShort2 != cmpVal);

					case  4: return IS_TRUE(v.SShort0 != cmpVal)
								 || IS_TRUE(v.SShort1 != cmpVal)
								 || IS_TRUE(v.SShort2 != cmpVal)
								 || IS_TRUE(v.SShort3 != cmpVal);

					default: return IS_TRUE(v.SShort0 != cmpVal)
								 || IS_TRUE(v.SShort1 != cmpVal)
								 || IS_TRUE(v.SShort2 != cmpVal)
								 || IS_TRUE(v.SShort3 != cmpVal)
								 || IS_TRUE(v.SShort4 != cmpVal)
								 || IS_TRUE(v.SShort5 != cmpVal)
								 || IS_TRUE(v.SShort6 != cmpVal)
								 || IS_TRUE(v.SShort7 != cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_NEQ_EPI32(v128 v, int cmpVal, byte elements = 4)
			{
				switch (elements)
				{
					case  2: return IS_TRUE(v.SInt0 != cmpVal)
								 || IS_TRUE(v.SInt1 != cmpVal);

					case  3: return IS_TRUE(v.SInt0 != cmpVal)
								 || IS_TRUE(v.SInt1 != cmpVal)
								 || IS_TRUE(v.SInt2 != cmpVal);

					default: return IS_TRUE(v.SInt0 != cmpVal)
								 || IS_TRUE(v.SInt1 != cmpVal)
								 || IS_TRUE(v.SInt2 != cmpVal)
								 || IS_TRUE(v.SInt3 != cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_NEQ_EPI64(v128 v, long cmpVal)
			{
				return IS_TRUE(v.SLong0 != cmpVal)
					|| IS_TRUE(v.SLong1 != cmpVal);
			}
			
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_NEQ_PS(v128 v, float cmpVal, byte elements = 4)
			{
				switch (elements)
				{
					case  1: return IS_TRUE(v.Float0 != cmpVal);

					case  2: return IS_TRUE(v.Float0 != cmpVal)
								 || IS_TRUE(v.Float1 != cmpVal);

					case  3: return IS_TRUE(v.Float0 != cmpVal)
								 || IS_TRUE(v.Float1 != cmpVal)
								 || IS_TRUE(v.Float2 != cmpVal);

					default: return IS_TRUE(v.Float0 != cmpVal)
								 || IS_TRUE(v.Float1 != cmpVal)
								 || IS_TRUE(v.Float2 != cmpVal)
								 || IS_TRUE(v.Float3 != cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_NEQ_PD(v128 v, double cmpVal)
			{
				return IS_TRUE(v.Double0 != cmpVal)
					|| IS_TRUE(v.Double1 != cmpVal);
			}


			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_NEQ_EPI8(v256 v, int cmpVal)
			{
				return IS_TRUE(v.SByte0  != cmpVal)
					|| IS_TRUE(v.SByte1  != cmpVal)
					|| IS_TRUE(v.SByte2  != cmpVal)
					|| IS_TRUE(v.SByte3  != cmpVal)
					|| IS_TRUE(v.SByte4  != cmpVal)
					|| IS_TRUE(v.SByte5  != cmpVal)
					|| IS_TRUE(v.SByte6  != cmpVal)
					|| IS_TRUE(v.SByte7  != cmpVal)
					|| IS_TRUE(v.SByte8  != cmpVal)
					|| IS_TRUE(v.SByte9  != cmpVal)
					|| IS_TRUE(v.SByte10 != cmpVal)
					|| IS_TRUE(v.SByte11 != cmpVal)
					|| IS_TRUE(v.SByte12 != cmpVal)
					|| IS_TRUE(v.SByte13 != cmpVal)
					|| IS_TRUE(v.SByte14 != cmpVal)
					|| IS_TRUE(v.SByte15 != cmpVal)
				    || IS_TRUE(v.SByte16 != cmpVal)
					|| IS_TRUE(v.SByte17 != cmpVal)
					|| IS_TRUE(v.SByte18 != cmpVal)
					|| IS_TRUE(v.SByte19 != cmpVal)
					|| IS_TRUE(v.SByte20 != cmpVal)
					|| IS_TRUE(v.SByte21 != cmpVal)
					|| IS_TRUE(v.SByte22 != cmpVal)
					|| IS_TRUE(v.SByte23 != cmpVal)
					|| IS_TRUE(v.SByte24 != cmpVal)
					|| IS_TRUE(v.SByte25 != cmpVal)
					|| IS_TRUE(v.SByte26 != cmpVal)
					|| IS_TRUE(v.SByte27 != cmpVal)
					|| IS_TRUE(v.SByte28 != cmpVal)
					|| IS_TRUE(v.SByte29 != cmpVal)
					|| IS_TRUE(v.SByte30 != cmpVal)
					|| IS_TRUE(v.SByte31 != cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_NEQ_EPI16(v256 v, int cmpVal)
			{
				return IS_TRUE(v.SShort0  != cmpVal)
					|| IS_TRUE(v.SShort1  != cmpVal)
					|| IS_TRUE(v.SShort2  != cmpVal)
					|| IS_TRUE(v.SShort3  != cmpVal)
					|| IS_TRUE(v.SShort4  != cmpVal)
					|| IS_TRUE(v.SShort5  != cmpVal)
					|| IS_TRUE(v.SShort6  != cmpVal)
					|| IS_TRUE(v.SShort7  != cmpVal)
					|| IS_TRUE(v.SShort8  != cmpVal)
					|| IS_TRUE(v.SShort9  != cmpVal)
					|| IS_TRUE(v.SShort10 != cmpVal)
					|| IS_TRUE(v.SShort11 != cmpVal)
					|| IS_TRUE(v.SShort12 != cmpVal)
					|| IS_TRUE(v.SShort13 != cmpVal)
					|| IS_TRUE(v.SShort14 != cmpVal)
					|| IS_TRUE(v.SShort15 != cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_NEQ_EPI32(v256 v, int cmpVal)
			{
				return IS_TRUE(v.SInt0 != cmpVal)
					|| IS_TRUE(v.SInt1 != cmpVal)
					|| IS_TRUE(v.SInt2 != cmpVal)
					|| IS_TRUE(v.SInt3 != cmpVal)
					|| IS_TRUE(v.SInt4 != cmpVal)
					|| IS_TRUE(v.SInt5 != cmpVal)
					|| IS_TRUE(v.SInt6 != cmpVal)
					|| IS_TRUE(v.SInt7 != cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_NEQ_EPI64(v256 v, long cmpVal, byte elements = 4)
			{
				if (elements == 3)
				{
					return IS_TRUE(v.SLong0 != cmpVal)
						|| IS_TRUE(v.SLong1 != cmpVal)
						|| IS_TRUE(v.SLong2 != cmpVal);
				}
				else
				{
					return IS_TRUE(v.SLong0 != cmpVal)
						|| IS_TRUE(v.SLong1 != cmpVal)
						|| IS_TRUE(v.SLong2 != cmpVal)
						|| IS_TRUE(v.SLong3 != cmpVal);
				}
			}
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_NEQ_EPU8(v256 v, uint cmpVal)
			{
				return IS_TRUE(v.Byte0  != cmpVal)
					|| IS_TRUE(v.Byte1  != cmpVal)
					|| IS_TRUE(v.Byte2  != cmpVal)
					|| IS_TRUE(v.Byte3  != cmpVal)
					|| IS_TRUE(v.Byte4  != cmpVal)
					|| IS_TRUE(v.Byte5  != cmpVal)
					|| IS_TRUE(v.Byte6  != cmpVal)
					|| IS_TRUE(v.Byte7  != cmpVal)
					|| IS_TRUE(v.Byte8  != cmpVal)
					|| IS_TRUE(v.Byte9  != cmpVal)
					|| IS_TRUE(v.Byte10 != cmpVal)
					|| IS_TRUE(v.Byte11 != cmpVal)
					|| IS_TRUE(v.Byte12 != cmpVal)
					|| IS_TRUE(v.Byte13 != cmpVal)
					|| IS_TRUE(v.Byte14 != cmpVal)
					|| IS_TRUE(v.Byte15 != cmpVal)
				    || IS_TRUE(v.Byte16 != cmpVal)
					|| IS_TRUE(v.Byte17 != cmpVal)
					|| IS_TRUE(v.Byte18 != cmpVal)
					|| IS_TRUE(v.Byte19 != cmpVal)
					|| IS_TRUE(v.Byte20 != cmpVal)
					|| IS_TRUE(v.Byte21 != cmpVal)
					|| IS_TRUE(v.Byte22 != cmpVal)
					|| IS_TRUE(v.Byte23 != cmpVal)
					|| IS_TRUE(v.Byte24 != cmpVal)
					|| IS_TRUE(v.Byte25 != cmpVal)
					|| IS_TRUE(v.Byte26 != cmpVal)
					|| IS_TRUE(v.Byte27 != cmpVal)
					|| IS_TRUE(v.Byte28 != cmpVal)
					|| IS_TRUE(v.Byte29 != cmpVal)
					|| IS_TRUE(v.Byte30 != cmpVal)
					|| IS_TRUE(v.Byte31 != cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_NEQ_EPU16(v256 v, uint cmpVal)
			{
				return IS_TRUE(v.UShort0  != cmpVal)
					|| IS_TRUE(v.UShort1  != cmpVal)
					|| IS_TRUE(v.UShort2  != cmpVal)
					|| IS_TRUE(v.UShort3  != cmpVal)
					|| IS_TRUE(v.UShort4  != cmpVal)
					|| IS_TRUE(v.UShort5  != cmpVal)
					|| IS_TRUE(v.UShort6  != cmpVal)
					|| IS_TRUE(v.UShort7  != cmpVal)
					|| IS_TRUE(v.UShort8  != cmpVal)
					|| IS_TRUE(v.UShort9  != cmpVal)
					|| IS_TRUE(v.UShort10 != cmpVal)
					|| IS_TRUE(v.UShort11 != cmpVal)
					|| IS_TRUE(v.UShort12 != cmpVal)
					|| IS_TRUE(v.UShort13 != cmpVal)
					|| IS_TRUE(v.UShort14 != cmpVal)
					|| IS_TRUE(v.UShort15 != cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_NEQ_EPU32(v256 v, uint cmpVal)
			{
				return IS_TRUE(v.UInt0 != cmpVal)
					|| IS_TRUE(v.UInt1 != cmpVal)
					|| IS_TRUE(v.UInt2 != cmpVal)
					|| IS_TRUE(v.UInt3 != cmpVal)
					|| IS_TRUE(v.UInt4 != cmpVal)
					|| IS_TRUE(v.UInt5 != cmpVal)
					|| IS_TRUE(v.UInt6 != cmpVal)
					|| IS_TRUE(v.UInt7 != cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_NEQ_EPU64(v256 v, ulong cmpVal, byte elements = 4)
			{
				if (elements == 3)
				{
					return IS_TRUE(v.ULong0 != cmpVal)
						|| IS_TRUE(v.ULong1 != cmpVal)
						|| IS_TRUE(v.ULong2 != cmpVal);
				}
				else
				{
					return IS_TRUE(v.ULong0 != cmpVal)
						|| IS_TRUE(v.ULong1 != cmpVal)
						|| IS_TRUE(v.ULong2 != cmpVal)
						|| IS_TRUE(v.ULong3 != cmpVal);
				}
			}


			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_NEQ_PS(v256 v, float cmpVal)
			{
				return IS_TRUE(v.Float0 != cmpVal)
					|| IS_TRUE(v.Float1 != cmpVal)
					|| IS_TRUE(v.Float2 != cmpVal)
					|| IS_TRUE(v.Float3 != cmpVal)
					|| IS_TRUE(v.Float4 != cmpVal)
					|| IS_TRUE(v.Float5 != cmpVal)
					|| IS_TRUE(v.Float6 != cmpVal)
					|| IS_TRUE(v.Float7 != cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_NEQ_PD(v256 v, double cmpVal, byte elements = 4)
			{
				if (elements == 3)
				{
					return IS_TRUE(v.Double0 != cmpVal)
						|| IS_TRUE(v.Double1 != cmpVal)
						|| IS_TRUE(v.Double2 != cmpVal);
				}
				else
				{
					return IS_TRUE(v.Double0 != cmpVal)
						|| IS_TRUE(v.Double1 != cmpVal)
						|| IS_TRUE(v.Double2 != cmpVal)
						|| IS_TRUE(v.Double3 != cmpVal);
				}
			}


			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_GT_EPU8(v128 v, uint cmpVal, byte elements = 16)
			{
				switch (elements)
				{
					case  2: return IS_TRUE(v.Byte0  > cmpVal)
								 || IS_TRUE(v.Byte1  > cmpVal);
									
					case  3: return IS_TRUE(v.Byte0  > cmpVal)
								 || IS_TRUE(v.Byte1  > cmpVal)
								 || IS_TRUE(v.Byte2  > cmpVal);

					case  4: return IS_TRUE(v.Byte0  > cmpVal)
								 || IS_TRUE(v.Byte1  > cmpVal)
								 || IS_TRUE(v.Byte2  > cmpVal)
								 || IS_TRUE(v.Byte3  > cmpVal);

					case  8: return IS_TRUE(v.Byte0  > cmpVal)
								 || IS_TRUE(v.Byte1  > cmpVal)
								 || IS_TRUE(v.Byte2  > cmpVal)
								 || IS_TRUE(v.Byte3  > cmpVal)
								 || IS_TRUE(v.Byte4  > cmpVal)
								 || IS_TRUE(v.Byte5  > cmpVal)
								 || IS_TRUE(v.Byte6  > cmpVal)
								 || IS_TRUE(v.Byte7  > cmpVal);

					default: return IS_TRUE(v.Byte0  > cmpVal)
								 || IS_TRUE(v.Byte1  > cmpVal)
								 || IS_TRUE(v.Byte2  > cmpVal)
								 || IS_TRUE(v.Byte3  > cmpVal)
								 || IS_TRUE(v.Byte4  > cmpVal)
								 || IS_TRUE(v.Byte5  > cmpVal)
								 || IS_TRUE(v.Byte6  > cmpVal)
								 || IS_TRUE(v.Byte7  > cmpVal)
								 || IS_TRUE(v.Byte8  > cmpVal)
								 || IS_TRUE(v.Byte9  > cmpVal)
								 || IS_TRUE(v.Byte10 > cmpVal)
								 || IS_TRUE(v.Byte11 > cmpVal)
								 || IS_TRUE(v.Byte12 > cmpVal)
								 || IS_TRUE(v.Byte13 > cmpVal)
								 || IS_TRUE(v.Byte14 > cmpVal)
								 || IS_TRUE(v.Byte15 > cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_GT_EPU16(v128 v, uint cmpVal, byte elements = 8)
			{
				switch (elements)
				{
					case  2: return IS_TRUE(v.UShort0  > cmpVal)
								 || IS_TRUE(v.UShort1  > cmpVal);

					case  3: return IS_TRUE(v.UShort0  > cmpVal)
								 || IS_TRUE(v.UShort1  > cmpVal)
								 || IS_TRUE(v.UShort2  > cmpVal);

					case  4: return IS_TRUE(v.UShort0  > cmpVal)
								 || IS_TRUE(v.UShort1  > cmpVal)
								 || IS_TRUE(v.UShort2  > cmpVal)
								 || IS_TRUE(v.UShort3  > cmpVal);

					default: return IS_TRUE(v.UShort0  > cmpVal)
								 || IS_TRUE(v.UShort1  > cmpVal)
								 || IS_TRUE(v.UShort2  > cmpVal)
								 || IS_TRUE(v.UShort3  > cmpVal)
								 || IS_TRUE(v.UShort4  > cmpVal)
								 || IS_TRUE(v.UShort5  > cmpVal)
								 || IS_TRUE(v.UShort6  > cmpVal)
								 || IS_TRUE(v.UShort7  > cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_GT_EPU32(v128 v, uint cmpVal, byte elements = 4)
			{
				switch (elements)
				{
					case  2: return IS_TRUE(v.UInt0  > cmpVal)
								 || IS_TRUE(v.UInt1  > cmpVal);

					case  3: return IS_TRUE(v.UInt0  > cmpVal)
								 || IS_TRUE(v.UInt1  > cmpVal)
								 || IS_TRUE(v.UInt2  > cmpVal);

					default: return IS_TRUE(v.UInt0  > cmpVal)
								 || IS_TRUE(v.UInt1  > cmpVal)
								 || IS_TRUE(v.UInt2  > cmpVal)
								 || IS_TRUE(v.UInt3  > cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_GT_EPU64(v128 v, ulong cmpVal)
			{
				return IS_TRUE(v.ULong0 > cmpVal)
					|| IS_TRUE(v.ULong1 > cmpVal);
			}
			
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_GT_EPI8(v128 v, int cmpVal, byte elements = 16)
			{
				switch (elements)
				{
					case  2: return IS_TRUE(v.SByte0  > cmpVal)
								 || IS_TRUE(v.SByte1  > cmpVal);

					case  3: return IS_TRUE(v.SByte0  > cmpVal)
								 || IS_TRUE(v.SByte1  > cmpVal)
								 || IS_TRUE(v.SByte2  > cmpVal);

					case  4: return IS_TRUE(v.SByte0  > cmpVal)
								 || IS_TRUE(v.SByte1  > cmpVal)
								 || IS_TRUE(v.SByte2  > cmpVal)
								 || IS_TRUE(v.SByte3  > cmpVal);

					case  8: return IS_TRUE(v.SByte0  > cmpVal)
								 || IS_TRUE(v.SByte1  > cmpVal)
								 || IS_TRUE(v.SByte2  > cmpVal)
								 || IS_TRUE(v.SByte3  > cmpVal)
								 || IS_TRUE(v.SByte4  > cmpVal)
								 || IS_TRUE(v.SByte5  > cmpVal)
								 || IS_TRUE(v.SByte6  > cmpVal)
								 || IS_TRUE(v.SByte7  > cmpVal);

					default: return IS_TRUE(v.SByte0  > cmpVal)
								 || IS_TRUE(v.SByte1  > cmpVal)
								 || IS_TRUE(v.SByte2  > cmpVal)
								 || IS_TRUE(v.SByte3  > cmpVal)
								 || IS_TRUE(v.SByte4  > cmpVal)
								 || IS_TRUE(v.SByte5  > cmpVal)
								 || IS_TRUE(v.SByte6  > cmpVal)
								 || IS_TRUE(v.SByte7  > cmpVal)
								 || IS_TRUE(v.SByte8  > cmpVal)
								 || IS_TRUE(v.SByte9  > cmpVal)
								 || IS_TRUE(v.SByte10 > cmpVal)
								 || IS_TRUE(v.SByte11 > cmpVal)
								 || IS_TRUE(v.SByte12 > cmpVal)
								 || IS_TRUE(v.SByte13 > cmpVal)
								 || IS_TRUE(v.SByte14 > cmpVal)
								 || IS_TRUE(v.SByte15 > cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_GT_EPI16(v128 v, int cmpVal, byte elements = 8)
			{
				switch (elements)
				{
					case  2: return IS_TRUE(v.SShort0 > cmpVal)
								 || IS_TRUE(v.SShort1 > cmpVal);

					case  3: return IS_TRUE(v.SShort0 > cmpVal)
								 || IS_TRUE(v.SShort1 > cmpVal)
								 || IS_TRUE(v.SShort2 > cmpVal);

					case  4: return IS_TRUE(v.SShort0 > cmpVal)
								 || IS_TRUE(v.SShort1 > cmpVal)
								 || IS_TRUE(v.SShort2 > cmpVal)
								 || IS_TRUE(v.SShort3 > cmpVal);

					default: return IS_TRUE(v.SShort0 > cmpVal)
								 || IS_TRUE(v.SShort1 > cmpVal)
								 || IS_TRUE(v.SShort2 > cmpVal)
								 || IS_TRUE(v.SShort3 > cmpVal)
								 || IS_TRUE(v.SShort4 > cmpVal)
								 || IS_TRUE(v.SShort5 > cmpVal)
								 || IS_TRUE(v.SShort6 > cmpVal)
								 || IS_TRUE(v.SShort7 > cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_GT_EPI32(v128 v, int cmpVal, byte elements = 4)
			{
				switch (elements)
				{
					case  2: return IS_TRUE(v.SInt0 > cmpVal)
								 || IS_TRUE(v.SInt1 > cmpVal);

					case  3: return IS_TRUE(v.SInt0 > cmpVal)
								 || IS_TRUE(v.SInt1 > cmpVal)
								 || IS_TRUE(v.SInt2 > cmpVal);

					default: return IS_TRUE(v.SInt0 > cmpVal)
								 || IS_TRUE(v.SInt1 > cmpVal)
								 || IS_TRUE(v.SInt2 > cmpVal)
								 || IS_TRUE(v.SInt3 > cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_GT_EPI64(v128 v, long cmpVal)
			{
				return IS_TRUE(v.SLong0 > cmpVal)
					|| IS_TRUE(v.SLong1 > cmpVal);
			}
			
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_GT_PS(v128 v, float cmpVal, byte elements = 4)
			{
				switch (elements)
				{
					case  1: return IS_TRUE(v.Float0 > cmpVal);

					case  2: return IS_TRUE(v.Float0 > cmpVal)
								 || IS_TRUE(v.Float1 > cmpVal);

					case  3: return IS_TRUE(v.Float0 > cmpVal)
								 || IS_TRUE(v.Float1 > cmpVal)
								 || IS_TRUE(v.Float2 > cmpVal);

					default: return IS_TRUE(v.Float0 > cmpVal)
								 || IS_TRUE(v.Float1 > cmpVal)
								 || IS_TRUE(v.Float2 > cmpVal)
								 || IS_TRUE(v.Float3 > cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_GT_PD(v128 v, double cmpVal)
			{
				return IS_TRUE(v.Double0 > cmpVal)
					|| IS_TRUE(v.Double1 > cmpVal);
			}


			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_GT_EPI8(v256 v, int cmpVal)
			{
				return IS_TRUE(v.SByte0  > cmpVal)
					|| IS_TRUE(v.SByte1  > cmpVal)
					|| IS_TRUE(v.SByte2  > cmpVal)
					|| IS_TRUE(v.SByte3  > cmpVal)
					|| IS_TRUE(v.SByte4  > cmpVal)
					|| IS_TRUE(v.SByte5  > cmpVal)
					|| IS_TRUE(v.SByte6  > cmpVal)
					|| IS_TRUE(v.SByte7  > cmpVal)
					|| IS_TRUE(v.SByte8  > cmpVal)
					|| IS_TRUE(v.SByte9  > cmpVal)
					|| IS_TRUE(v.SByte10 > cmpVal)
					|| IS_TRUE(v.SByte11 > cmpVal)
					|| IS_TRUE(v.SByte12 > cmpVal)
					|| IS_TRUE(v.SByte13 > cmpVal)
					|| IS_TRUE(v.SByte14 > cmpVal)
					|| IS_TRUE(v.SByte15 > cmpVal)
				    || IS_TRUE(v.SByte16 > cmpVal)
					|| IS_TRUE(v.SByte17 > cmpVal)
					|| IS_TRUE(v.SByte18 > cmpVal)
					|| IS_TRUE(v.SByte19 > cmpVal)
					|| IS_TRUE(v.SByte20 > cmpVal)
					|| IS_TRUE(v.SByte21 > cmpVal)
					|| IS_TRUE(v.SByte22 > cmpVal)
					|| IS_TRUE(v.SByte23 > cmpVal)
					|| IS_TRUE(v.SByte24 > cmpVal)
					|| IS_TRUE(v.SByte25 > cmpVal)
					|| IS_TRUE(v.SByte26 > cmpVal)
					|| IS_TRUE(v.SByte27 > cmpVal)
					|| IS_TRUE(v.SByte28 > cmpVal)
					|| IS_TRUE(v.SByte29 > cmpVal)
					|| IS_TRUE(v.SByte30 > cmpVal)
					|| IS_TRUE(v.SByte31 > cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_GT_EPI16(v256 v, int cmpVal)
			{
				return IS_TRUE(v.SShort0  > cmpVal)
					|| IS_TRUE(v.SShort1  > cmpVal)
					|| IS_TRUE(v.SShort2  > cmpVal)
					|| IS_TRUE(v.SShort3  > cmpVal)
					|| IS_TRUE(v.SShort4  > cmpVal)
					|| IS_TRUE(v.SShort5  > cmpVal)
					|| IS_TRUE(v.SShort6  > cmpVal)
					|| IS_TRUE(v.SShort7  > cmpVal)
					|| IS_TRUE(v.SShort8  > cmpVal)
					|| IS_TRUE(v.SShort9  > cmpVal)
					|| IS_TRUE(v.SShort10 > cmpVal)
					|| IS_TRUE(v.SShort11 > cmpVal)
					|| IS_TRUE(v.SShort12 > cmpVal)
					|| IS_TRUE(v.SShort13 > cmpVal)
					|| IS_TRUE(v.SShort14 > cmpVal)
					|| IS_TRUE(v.SShort15 > cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_GT_EPI32(v256 v, int cmpVal)
			{
				return IS_TRUE(v.SInt0 > cmpVal)
					|| IS_TRUE(v.SInt1 > cmpVal)
					|| IS_TRUE(v.SInt2 > cmpVal)
					|| IS_TRUE(v.SInt3 > cmpVal)
					|| IS_TRUE(v.SInt4 > cmpVal)
					|| IS_TRUE(v.SInt5 > cmpVal)
					|| IS_TRUE(v.SInt6 > cmpVal)
					|| IS_TRUE(v.SInt7 > cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_GT_EPI64(v256 v, long cmpVal, byte elements = 4)
			{
				if (elements == 3)
				{
					return IS_TRUE(v.SLong0 > cmpVal)
						|| IS_TRUE(v.SLong1 > cmpVal)
						|| IS_TRUE(v.SLong2 > cmpVal);
				}
				else
				{
					return IS_TRUE(v.SLong0 > cmpVal)
						|| IS_TRUE(v.SLong1 > cmpVal)
						|| IS_TRUE(v.SLong2 > cmpVal)
						|| IS_TRUE(v.SLong3 > cmpVal);
				}
			}
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_GT_EPU8(v256 v, uint cmpVal)
			{
				return IS_TRUE(v.Byte0  > cmpVal)
					|| IS_TRUE(v.Byte1  > cmpVal)
					|| IS_TRUE(v.Byte2  > cmpVal)
					|| IS_TRUE(v.Byte3  > cmpVal)
					|| IS_TRUE(v.Byte4  > cmpVal)
					|| IS_TRUE(v.Byte5  > cmpVal)
					|| IS_TRUE(v.Byte6  > cmpVal)
					|| IS_TRUE(v.Byte7  > cmpVal)
					|| IS_TRUE(v.Byte8  > cmpVal)
					|| IS_TRUE(v.Byte9  > cmpVal)
					|| IS_TRUE(v.Byte10 > cmpVal)
					|| IS_TRUE(v.Byte11 > cmpVal)
					|| IS_TRUE(v.Byte12 > cmpVal)
					|| IS_TRUE(v.Byte13 > cmpVal)
					|| IS_TRUE(v.Byte14 > cmpVal)
					|| IS_TRUE(v.Byte15 > cmpVal)
				    || IS_TRUE(v.Byte16 > cmpVal)
					|| IS_TRUE(v.Byte17 > cmpVal)
					|| IS_TRUE(v.Byte18 > cmpVal)
					|| IS_TRUE(v.Byte19 > cmpVal)
					|| IS_TRUE(v.Byte20 > cmpVal)
					|| IS_TRUE(v.Byte21 > cmpVal)
					|| IS_TRUE(v.Byte22 > cmpVal)
					|| IS_TRUE(v.Byte23 > cmpVal)
					|| IS_TRUE(v.Byte24 > cmpVal)
					|| IS_TRUE(v.Byte25 > cmpVal)
					|| IS_TRUE(v.Byte26 > cmpVal)
					|| IS_TRUE(v.Byte27 > cmpVal)
					|| IS_TRUE(v.Byte28 > cmpVal)
					|| IS_TRUE(v.Byte29 > cmpVal)
					|| IS_TRUE(v.Byte30 > cmpVal)
					|| IS_TRUE(v.Byte31 > cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_GT_EPU16(v256 v, uint cmpVal)
			{
				return IS_TRUE(v.UShort0  > cmpVal)
					|| IS_TRUE(v.UShort1  > cmpVal)
					|| IS_TRUE(v.UShort2  > cmpVal)
					|| IS_TRUE(v.UShort3  > cmpVal)
					|| IS_TRUE(v.UShort4  > cmpVal)
					|| IS_TRUE(v.UShort5  > cmpVal)
					|| IS_TRUE(v.UShort6  > cmpVal)
					|| IS_TRUE(v.UShort7  > cmpVal)
					|| IS_TRUE(v.UShort8  > cmpVal)
					|| IS_TRUE(v.UShort9  > cmpVal)
					|| IS_TRUE(v.UShort10 > cmpVal)
					|| IS_TRUE(v.UShort11 > cmpVal)
					|| IS_TRUE(v.UShort12 > cmpVal)
					|| IS_TRUE(v.UShort13 > cmpVal)
					|| IS_TRUE(v.UShort14 > cmpVal)
					|| IS_TRUE(v.UShort15 > cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_GT_EPU32(v256 v, uint cmpVal)
			{
				return IS_TRUE(v.UInt0 > cmpVal)
					|| IS_TRUE(v.UInt1 > cmpVal)
					|| IS_TRUE(v.UInt2 > cmpVal)
					|| IS_TRUE(v.UInt3 > cmpVal)
					|| IS_TRUE(v.UInt4 > cmpVal)
					|| IS_TRUE(v.UInt5 > cmpVal)
					|| IS_TRUE(v.UInt6 > cmpVal)
					|| IS_TRUE(v.UInt7 > cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_GT_EPU64(v256 v, ulong cmpVal, byte elements = 4)
			{
				if (elements == 3)
				{
					return IS_TRUE(v.ULong0 > cmpVal)
						|| IS_TRUE(v.ULong1 > cmpVal)
						|| IS_TRUE(v.ULong2 > cmpVal);
				}
				else
				{
					return IS_TRUE(v.ULong0 > cmpVal)
						|| IS_TRUE(v.ULong1 > cmpVal)
						|| IS_TRUE(v.ULong2 > cmpVal)
						|| IS_TRUE(v.ULong3 > cmpVal);
				}
			}


			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_GT_PS(v256 v, float cmpVal)
			{
				return IS_TRUE(v.Float0 > cmpVal)
					|| IS_TRUE(v.Float1 > cmpVal)
					|| IS_TRUE(v.Float2 > cmpVal)
					|| IS_TRUE(v.Float3 > cmpVal)
					|| IS_TRUE(v.Float4 > cmpVal)
					|| IS_TRUE(v.Float5 > cmpVal)
					|| IS_TRUE(v.Float6 > cmpVal)
					|| IS_TRUE(v.Float7 > cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_GT_PD(v256 v, double cmpVal, byte elements = 4)
			{
				if (elements == 3)
				{
					return IS_TRUE(v.Double0 > cmpVal)
						|| IS_TRUE(v.Double1 > cmpVal)
						|| IS_TRUE(v.Double2 > cmpVal);
				}
				else
				{
					return IS_TRUE(v.Double0 > cmpVal)
						|| IS_TRUE(v.Double1 > cmpVal)
						|| IS_TRUE(v.Double2 > cmpVal)
						|| IS_TRUE(v.Double3 > cmpVal);
				}
			}


			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_LT_EPU8(v128 v, uint cmpVal, byte elements = 16)
			{
				switch (elements)
				{
					case  2: return IS_TRUE(v.Byte0  < cmpVal)
								 || IS_TRUE(v.Byte1  < cmpVal);
									
					case  3: return IS_TRUE(v.Byte0  < cmpVal)
								 || IS_TRUE(v.Byte1  < cmpVal)
								 || IS_TRUE(v.Byte2  < cmpVal);

					case  4: return IS_TRUE(v.Byte0  < cmpVal)
								 || IS_TRUE(v.Byte1  < cmpVal)
								 || IS_TRUE(v.Byte2  < cmpVal)
								 || IS_TRUE(v.Byte3  < cmpVal);

					case  8: return IS_TRUE(v.Byte0  < cmpVal)
								 || IS_TRUE(v.Byte1  < cmpVal)
								 || IS_TRUE(v.Byte2  < cmpVal)
								 || IS_TRUE(v.Byte3  < cmpVal)
								 || IS_TRUE(v.Byte4  < cmpVal)
								 || IS_TRUE(v.Byte5  < cmpVal)
								 || IS_TRUE(v.Byte6  < cmpVal)
								 || IS_TRUE(v.Byte7  < cmpVal);

					default: return IS_TRUE(v.Byte0  < cmpVal)
								 || IS_TRUE(v.Byte1  < cmpVal)
								 || IS_TRUE(v.Byte2  < cmpVal)
								 || IS_TRUE(v.Byte3  < cmpVal)
								 || IS_TRUE(v.Byte4  < cmpVal)
								 || IS_TRUE(v.Byte5  < cmpVal)
								 || IS_TRUE(v.Byte6  < cmpVal)
								 || IS_TRUE(v.Byte7  < cmpVal)
								 || IS_TRUE(v.Byte8  < cmpVal)
								 || IS_TRUE(v.Byte9  < cmpVal)
								 || IS_TRUE(v.Byte10 < cmpVal)
								 || IS_TRUE(v.Byte11 < cmpVal)
								 || IS_TRUE(v.Byte12 < cmpVal)
								 || IS_TRUE(v.Byte13 < cmpVal)
								 || IS_TRUE(v.Byte14 < cmpVal)
								 || IS_TRUE(v.Byte15 < cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_LT_EPU16(v128 v, uint cmpVal, byte elements = 8)
			{
				switch (elements)
				{
					case  2: return IS_TRUE(v.UShort0  < cmpVal)
								 || IS_TRUE(v.UShort1  < cmpVal);

					case  3: return IS_TRUE(v.UShort0  < cmpVal)
								 || IS_TRUE(v.UShort1  < cmpVal)
								 || IS_TRUE(v.UShort2  < cmpVal);

					case  4: return IS_TRUE(v.UShort0  < cmpVal)
								 || IS_TRUE(v.UShort1  < cmpVal)
								 || IS_TRUE(v.UShort2  < cmpVal)
								 || IS_TRUE(v.UShort3  < cmpVal);

					default: return IS_TRUE(v.UShort0  < cmpVal)
								 || IS_TRUE(v.UShort1  < cmpVal)
								 || IS_TRUE(v.UShort2  < cmpVal)
								 || IS_TRUE(v.UShort3  < cmpVal)
								 || IS_TRUE(v.UShort4  < cmpVal)
								 || IS_TRUE(v.UShort5  < cmpVal)
								 || IS_TRUE(v.UShort6  < cmpVal)
								 || IS_TRUE(v.UShort7  < cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_LT_EPU32(v128 v, uint cmpVal, byte elements = 4)
			{
				switch (elements)
				{
					case  2: return IS_TRUE(v.UInt0  < cmpVal)
								 || IS_TRUE(v.UInt1  < cmpVal);

					case  3: return IS_TRUE(v.UInt0  < cmpVal)
								 || IS_TRUE(v.UInt1  < cmpVal)
								 || IS_TRUE(v.UInt2  < cmpVal);

					default: return IS_TRUE(v.UInt0  < cmpVal)
								 || IS_TRUE(v.UInt1  < cmpVal)
								 || IS_TRUE(v.UInt2  < cmpVal)
								 || IS_TRUE(v.UInt3  < cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_LT_EPU64(v128 v, ulong cmpVal)
			{
				return IS_TRUE(v.ULong0 < cmpVal)
					|| IS_TRUE(v.ULong1 < cmpVal);
			}
			
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_LT_EPI8(v128 v, int cmpVal, byte elements = 16)
			{
				switch (elements)
				{
					case  2: return IS_TRUE(v.SByte0  < cmpVal)
								 || IS_TRUE(v.SByte1  < cmpVal);

					case  3: return IS_TRUE(v.SByte0  < cmpVal)
								 || IS_TRUE(v.SByte1  < cmpVal)
								 || IS_TRUE(v.SByte2  < cmpVal);

					case  4: return IS_TRUE(v.SByte0  < cmpVal)
								 || IS_TRUE(v.SByte1  < cmpVal)
								 || IS_TRUE(v.SByte2  < cmpVal)
								 || IS_TRUE(v.SByte3  < cmpVal);

					case  8: return IS_TRUE(v.SByte0  < cmpVal)
								 || IS_TRUE(v.SByte1  < cmpVal)
								 || IS_TRUE(v.SByte2  < cmpVal)
								 || IS_TRUE(v.SByte3  < cmpVal)
								 || IS_TRUE(v.SByte4  < cmpVal)
								 || IS_TRUE(v.SByte5  < cmpVal)
								 || IS_TRUE(v.SByte6  < cmpVal)
								 || IS_TRUE(v.SByte7  < cmpVal);

					default: return IS_TRUE(v.SByte0  < cmpVal)
								 || IS_TRUE(v.SByte1  < cmpVal)
								 || IS_TRUE(v.SByte2  < cmpVal)
								 || IS_TRUE(v.SByte3  < cmpVal)
								 || IS_TRUE(v.SByte4  < cmpVal)
								 || IS_TRUE(v.SByte5  < cmpVal)
								 || IS_TRUE(v.SByte6  < cmpVal)
								 || IS_TRUE(v.SByte7  < cmpVal)
								 || IS_TRUE(v.SByte8  < cmpVal)
								 || IS_TRUE(v.SByte9  < cmpVal)
								 || IS_TRUE(v.SByte10 < cmpVal)
								 || IS_TRUE(v.SByte11 < cmpVal)
								 || IS_TRUE(v.SByte12 < cmpVal)
								 || IS_TRUE(v.SByte13 < cmpVal)
								 || IS_TRUE(v.SByte14 < cmpVal)
								 || IS_TRUE(v.SByte15 < cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_LT_EPI16(v128 v, int cmpVal, byte elements = 8)
			{
				switch (elements)
				{
					case  2: return IS_TRUE(v.SShort0 < cmpVal)
								 || IS_TRUE(v.SShort1 < cmpVal);

					case  3: return IS_TRUE(v.SShort0 < cmpVal)
								 || IS_TRUE(v.SShort1 < cmpVal)
								 || IS_TRUE(v.SShort2 < cmpVal);

					case  4: return IS_TRUE(v.SShort0 < cmpVal)
								 || IS_TRUE(v.SShort1 < cmpVal)
								 || IS_TRUE(v.SShort2 < cmpVal)
								 || IS_TRUE(v.SShort3 < cmpVal);

					default: return IS_TRUE(v.SShort0 < cmpVal)
								 || IS_TRUE(v.SShort1 < cmpVal)
								 || IS_TRUE(v.SShort2 < cmpVal)
								 || IS_TRUE(v.SShort3 < cmpVal)
								 || IS_TRUE(v.SShort4 < cmpVal)
								 || IS_TRUE(v.SShort5 < cmpVal)
								 || IS_TRUE(v.SShort6 < cmpVal)
								 || IS_TRUE(v.SShort7 < cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_LT_EPI32(v128 v, int cmpVal, byte elements = 4)
			{
				switch (elements)
				{
					case  2: return IS_TRUE(v.SInt0 < cmpVal)
								 || IS_TRUE(v.SInt1 < cmpVal);

					case  3: return IS_TRUE(v.SInt0 < cmpVal)
								 || IS_TRUE(v.SInt1 < cmpVal)
								 || IS_TRUE(v.SInt2 < cmpVal);

					default: return IS_TRUE(v.SInt0 < cmpVal)
								 || IS_TRUE(v.SInt1 < cmpVal)
								 || IS_TRUE(v.SInt2 < cmpVal)
								 || IS_TRUE(v.SInt3 < cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_LT_EPI64(v128 v, long cmpVal)
			{
				return IS_TRUE(v.SLong0 < cmpVal)
					|| IS_TRUE(v.SLong1 < cmpVal);
			}
			
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_LT_PS(v128 v, float cmpVal, byte elements = 4)
			{
				switch (elements)
				{
					case  1: return IS_TRUE(v.Float0 < cmpVal);

					case  2: return IS_TRUE(v.Float0 < cmpVal)
								 || IS_TRUE(v.Float1 < cmpVal);

					case  3: return IS_TRUE(v.Float0 < cmpVal)
								 || IS_TRUE(v.Float1 < cmpVal)
								 || IS_TRUE(v.Float2 < cmpVal);

					default: return IS_TRUE(v.Float0 < cmpVal)
								 || IS_TRUE(v.Float1 < cmpVal)
								 || IS_TRUE(v.Float2 < cmpVal)
								 || IS_TRUE(v.Float3 < cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_LT_PD(v128 v, double cmpVal)
			{
				return IS_TRUE(v.Double0 < cmpVal)
					|| IS_TRUE(v.Double1 < cmpVal);
			}


			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_LT_EPI8(v256 v, int cmpVal)
			{
				return IS_TRUE(v.SByte0  < cmpVal)
					|| IS_TRUE(v.SByte1  < cmpVal)
					|| IS_TRUE(v.SByte2  < cmpVal)
					|| IS_TRUE(v.SByte3  < cmpVal)
					|| IS_TRUE(v.SByte4  < cmpVal)
					|| IS_TRUE(v.SByte5  < cmpVal)
					|| IS_TRUE(v.SByte6  < cmpVal)
					|| IS_TRUE(v.SByte7  < cmpVal)
					|| IS_TRUE(v.SByte8  < cmpVal)
					|| IS_TRUE(v.SByte9  < cmpVal)
					|| IS_TRUE(v.SByte10 < cmpVal)
					|| IS_TRUE(v.SByte11 < cmpVal)
					|| IS_TRUE(v.SByte12 < cmpVal)
					|| IS_TRUE(v.SByte13 < cmpVal)
					|| IS_TRUE(v.SByte14 < cmpVal)
					|| IS_TRUE(v.SByte15 < cmpVal)
				    || IS_TRUE(v.SByte16 < cmpVal)
					|| IS_TRUE(v.SByte17 < cmpVal)
					|| IS_TRUE(v.SByte18 < cmpVal)
					|| IS_TRUE(v.SByte19 < cmpVal)
					|| IS_TRUE(v.SByte20 < cmpVal)
					|| IS_TRUE(v.SByte21 < cmpVal)
					|| IS_TRUE(v.SByte22 < cmpVal)
					|| IS_TRUE(v.SByte23 < cmpVal)
					|| IS_TRUE(v.SByte24 < cmpVal)
					|| IS_TRUE(v.SByte25 < cmpVal)
					|| IS_TRUE(v.SByte26 < cmpVal)
					|| IS_TRUE(v.SByte27 < cmpVal)
					|| IS_TRUE(v.SByte28 < cmpVal)
					|| IS_TRUE(v.SByte29 < cmpVal)
					|| IS_TRUE(v.SByte30 < cmpVal)
					|| IS_TRUE(v.SByte31 < cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_LT_EPI16(v256 v, int cmpVal)
			{
				return IS_TRUE(v.SShort0  < cmpVal)
					|| IS_TRUE(v.SShort1  < cmpVal)
					|| IS_TRUE(v.SShort2  < cmpVal)
					|| IS_TRUE(v.SShort3  < cmpVal)
					|| IS_TRUE(v.SShort4  < cmpVal)
					|| IS_TRUE(v.SShort5  < cmpVal)
					|| IS_TRUE(v.SShort6  < cmpVal)
					|| IS_TRUE(v.SShort7  < cmpVal)
					|| IS_TRUE(v.SShort8  < cmpVal)
					|| IS_TRUE(v.SShort9  < cmpVal)
					|| IS_TRUE(v.SShort10 < cmpVal)
					|| IS_TRUE(v.SShort11 < cmpVal)
					|| IS_TRUE(v.SShort12 < cmpVal)
					|| IS_TRUE(v.SShort13 < cmpVal)
					|| IS_TRUE(v.SShort14 < cmpVal)
					|| IS_TRUE(v.SShort15 < cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_LT_EPI32(v256 v, int cmpVal)
			{
				return IS_TRUE(v.SInt0 < cmpVal)
					|| IS_TRUE(v.SInt1 < cmpVal)
					|| IS_TRUE(v.SInt2 < cmpVal)
					|| IS_TRUE(v.SInt3 < cmpVal)
					|| IS_TRUE(v.SInt4 < cmpVal)
					|| IS_TRUE(v.SInt5 < cmpVal)
					|| IS_TRUE(v.SInt6 < cmpVal)
					|| IS_TRUE(v.SInt7 < cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_LT_EPI64(v256 v, long cmpVal, byte elements = 4)
			{
				if (elements == 3)
				{
					return IS_TRUE(v.SLong0 < cmpVal)
						|| IS_TRUE(v.SLong1 < cmpVal)
						|| IS_TRUE(v.SLong2 < cmpVal);
				}
				else
				{
					return IS_TRUE(v.SLong0 < cmpVal)
						|| IS_TRUE(v.SLong1 < cmpVal)
						|| IS_TRUE(v.SLong2 < cmpVal)
						|| IS_TRUE(v.SLong3 < cmpVal);
				}
			}
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_LT_EPU8(v256 v, uint cmpVal)
			{
				return IS_TRUE(v.Byte0  < cmpVal)
					|| IS_TRUE(v.Byte1  < cmpVal)
					|| IS_TRUE(v.Byte2  < cmpVal)
					|| IS_TRUE(v.Byte3  < cmpVal)
					|| IS_TRUE(v.Byte4  < cmpVal)
					|| IS_TRUE(v.Byte5  < cmpVal)
					|| IS_TRUE(v.Byte6  < cmpVal)
					|| IS_TRUE(v.Byte7  < cmpVal)
					|| IS_TRUE(v.Byte8  < cmpVal)
					|| IS_TRUE(v.Byte9  < cmpVal)
					|| IS_TRUE(v.Byte10 < cmpVal)
					|| IS_TRUE(v.Byte11 < cmpVal)
					|| IS_TRUE(v.Byte12 < cmpVal)
					|| IS_TRUE(v.Byte13 < cmpVal)
					|| IS_TRUE(v.Byte14 < cmpVal)
					|| IS_TRUE(v.Byte15 < cmpVal)
				    || IS_TRUE(v.Byte16 < cmpVal)
					|| IS_TRUE(v.Byte17 < cmpVal)
					|| IS_TRUE(v.Byte18 < cmpVal)
					|| IS_TRUE(v.Byte19 < cmpVal)
					|| IS_TRUE(v.Byte20 < cmpVal)
					|| IS_TRUE(v.Byte21 < cmpVal)
					|| IS_TRUE(v.Byte22 < cmpVal)
					|| IS_TRUE(v.Byte23 < cmpVal)
					|| IS_TRUE(v.Byte24 < cmpVal)
					|| IS_TRUE(v.Byte25 < cmpVal)
					|| IS_TRUE(v.Byte26 < cmpVal)
					|| IS_TRUE(v.Byte27 < cmpVal)
					|| IS_TRUE(v.Byte28 < cmpVal)
					|| IS_TRUE(v.Byte29 < cmpVal)
					|| IS_TRUE(v.Byte30 < cmpVal)
					|| IS_TRUE(v.Byte31 < cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_LT_EPU16(v256 v, uint cmpVal)
			{
				return IS_TRUE(v.UShort0  < cmpVal)
					|| IS_TRUE(v.UShort1  < cmpVal)
					|| IS_TRUE(v.UShort2  < cmpVal)
					|| IS_TRUE(v.UShort3  < cmpVal)
					|| IS_TRUE(v.UShort4  < cmpVal)
					|| IS_TRUE(v.UShort5  < cmpVal)
					|| IS_TRUE(v.UShort6  < cmpVal)
					|| IS_TRUE(v.UShort7  < cmpVal)
					|| IS_TRUE(v.UShort8  < cmpVal)
					|| IS_TRUE(v.UShort9  < cmpVal)
					|| IS_TRUE(v.UShort10 < cmpVal)
					|| IS_TRUE(v.UShort11 < cmpVal)
					|| IS_TRUE(v.UShort12 < cmpVal)
					|| IS_TRUE(v.UShort13 < cmpVal)
					|| IS_TRUE(v.UShort14 < cmpVal)
					|| IS_TRUE(v.UShort15 < cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_LT_EPU32(v256 v, uint cmpVal)
			{
				return IS_TRUE(v.UInt0 < cmpVal)
					|| IS_TRUE(v.UInt1 < cmpVal)
					|| IS_TRUE(v.UInt2 < cmpVal)
					|| IS_TRUE(v.UInt3 < cmpVal)
					|| IS_TRUE(v.UInt4 < cmpVal)
					|| IS_TRUE(v.UInt5 < cmpVal)
					|| IS_TRUE(v.UInt6 < cmpVal)
					|| IS_TRUE(v.UInt7 < cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_LT_EPU64(v256 v, ulong cmpVal, byte elements = 4)
			{
				if (elements == 3)
				{
					return IS_TRUE(v.ULong0 < cmpVal)
						|| IS_TRUE(v.ULong1 < cmpVal)
						|| IS_TRUE(v.ULong2 < cmpVal);
				}
				else
				{
					return IS_TRUE(v.ULong0 < cmpVal)
						|| IS_TRUE(v.ULong1 < cmpVal)
						|| IS_TRUE(v.ULong2 < cmpVal)
						|| IS_TRUE(v.ULong3 < cmpVal);
				}
			}


			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_LT_PS(v256 v, float cmpVal)
			{
				return IS_TRUE(v.Float0 < cmpVal)
					|| IS_TRUE(v.Float1 < cmpVal)
					|| IS_TRUE(v.Float2 < cmpVal)
					|| IS_TRUE(v.Float3 < cmpVal)
					|| IS_TRUE(v.Float4 < cmpVal)
					|| IS_TRUE(v.Float5 < cmpVal)
					|| IS_TRUE(v.Float6 < cmpVal)
					|| IS_TRUE(v.Float7 < cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_LT_PD(v256 v, double cmpVal, byte elements = 4)
			{
				if (elements == 3)
				{
					return IS_TRUE(v.Double0 < cmpVal)
						|| IS_TRUE(v.Double1 < cmpVal)
						|| IS_TRUE(v.Double2 < cmpVal);
				}
				else
				{
					return IS_TRUE(v.Double0 < cmpVal)
						|| IS_TRUE(v.Double1 < cmpVal)
						|| IS_TRUE(v.Double2 < cmpVal)
						|| IS_TRUE(v.Double3 < cmpVal);
				}
			}


			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_GE_EPU8(v128 v, uint cmpVal, byte elements = 16)
			{
				switch (elements)
				{
					case  2: return IS_TRUE(v.Byte0  >= cmpVal)
								 || IS_TRUE(v.Byte1  >= cmpVal);
									
					case  3: return IS_TRUE(v.Byte0  >= cmpVal)
								 || IS_TRUE(v.Byte1  >= cmpVal)
								 || IS_TRUE(v.Byte2  >= cmpVal);

					case  4: return IS_TRUE(v.Byte0  >= cmpVal)
								 || IS_TRUE(v.Byte1  >= cmpVal)
								 || IS_TRUE(v.Byte2  >= cmpVal)
								 || IS_TRUE(v.Byte3  >= cmpVal);

					case  8: return IS_TRUE(v.Byte0  >= cmpVal)
								 || IS_TRUE(v.Byte1  >= cmpVal)
								 || IS_TRUE(v.Byte2  >= cmpVal)
								 || IS_TRUE(v.Byte3  >= cmpVal)
								 || IS_TRUE(v.Byte4  >= cmpVal)
								 || IS_TRUE(v.Byte5  >= cmpVal)
								 || IS_TRUE(v.Byte6  >= cmpVal)
								 || IS_TRUE(v.Byte7  >= cmpVal);

					default: return IS_TRUE(v.Byte0  >= cmpVal)
								 || IS_TRUE(v.Byte1  >= cmpVal)
								 || IS_TRUE(v.Byte2  >= cmpVal)
								 || IS_TRUE(v.Byte3  >= cmpVal)
								 || IS_TRUE(v.Byte4  >= cmpVal)
								 || IS_TRUE(v.Byte5  >= cmpVal)
								 || IS_TRUE(v.Byte6  >= cmpVal)
								 || IS_TRUE(v.Byte7  >= cmpVal)
								 || IS_TRUE(v.Byte8  >= cmpVal)
								 || IS_TRUE(v.Byte9  >= cmpVal)
								 || IS_TRUE(v.Byte10 >= cmpVal)
								 || IS_TRUE(v.Byte11 >= cmpVal)
								 || IS_TRUE(v.Byte12 >= cmpVal)
								 || IS_TRUE(v.Byte13 >= cmpVal)
								 || IS_TRUE(v.Byte14 >= cmpVal)
								 || IS_TRUE(v.Byte15 >= cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_GE_EPU16(v128 v, uint cmpVal, byte elements = 8)
			{
				switch (elements)
				{
					case  2: return IS_TRUE(v.UShort0  >= cmpVal)
								 || IS_TRUE(v.UShort1  >= cmpVal);

					case  3: return IS_TRUE(v.UShort0  >= cmpVal)
								 || IS_TRUE(v.UShort1  >= cmpVal)
								 || IS_TRUE(v.UShort2  >= cmpVal);

					case  4: return IS_TRUE(v.UShort0  >= cmpVal)
								 || IS_TRUE(v.UShort1  >= cmpVal)
								 || IS_TRUE(v.UShort2  >= cmpVal)
								 || IS_TRUE(v.UShort3  >= cmpVal);

					default: return IS_TRUE(v.UShort0  >= cmpVal)
								 || IS_TRUE(v.UShort1  >= cmpVal)
								 || IS_TRUE(v.UShort2  >= cmpVal)
								 || IS_TRUE(v.UShort3  >= cmpVal)
								 || IS_TRUE(v.UShort4  >= cmpVal)
								 || IS_TRUE(v.UShort5  >= cmpVal)
								 || IS_TRUE(v.UShort6  >= cmpVal)
								 || IS_TRUE(v.UShort7  >= cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_GE_EPU32(v128 v, uint cmpVal, byte elements = 4)
			{
				switch (elements)
				{
					case  2: return IS_TRUE(v.UInt0  >= cmpVal)
								 || IS_TRUE(v.UInt1  >= cmpVal);

					case  3: return IS_TRUE(v.UInt0  >= cmpVal)
								 || IS_TRUE(v.UInt1  >= cmpVal)
								 || IS_TRUE(v.UInt2  >= cmpVal);

					default: return IS_TRUE(v.UInt0  >= cmpVal)
								 || IS_TRUE(v.UInt1  >= cmpVal)
								 || IS_TRUE(v.UInt2  >= cmpVal)
								 || IS_TRUE(v.UInt3  >= cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_GE_EPU64(v128 v, ulong cmpVal)
			{
				return IS_TRUE(v.ULong0 >= cmpVal)
					|| IS_TRUE(v.ULong1 >= cmpVal);
			}
			
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_GE_EPI8(v128 v, int cmpVal, byte elements = 16)
			{
				switch (elements)
				{
					case  2: return IS_TRUE(v.SByte0  >= cmpVal)
								 || IS_TRUE(v.SByte1  >= cmpVal);

					case  3: return IS_TRUE(v.SByte0  >= cmpVal)
								 || IS_TRUE(v.SByte1  >= cmpVal)
								 || IS_TRUE(v.SByte2  >= cmpVal);

					case  4: return IS_TRUE(v.SByte0  >= cmpVal)
								 || IS_TRUE(v.SByte1  >= cmpVal)
								 || IS_TRUE(v.SByte2  >= cmpVal)
								 || IS_TRUE(v.SByte3  >= cmpVal);

					case  8: return IS_TRUE(v.SByte0  >= cmpVal)
								 || IS_TRUE(v.SByte1  >= cmpVal)
								 || IS_TRUE(v.SByte2  >= cmpVal)
								 || IS_TRUE(v.SByte3  >= cmpVal)
								 || IS_TRUE(v.SByte4  >= cmpVal)
								 || IS_TRUE(v.SByte5  >= cmpVal)
								 || IS_TRUE(v.SByte6  >= cmpVal)
								 || IS_TRUE(v.SByte7  >= cmpVal);

					default: return IS_TRUE(v.SByte0  >= cmpVal)
								 || IS_TRUE(v.SByte1  >= cmpVal)
								 || IS_TRUE(v.SByte2  >= cmpVal)
								 || IS_TRUE(v.SByte3  >= cmpVal)
								 || IS_TRUE(v.SByte4  >= cmpVal)
								 || IS_TRUE(v.SByte5  >= cmpVal)
								 || IS_TRUE(v.SByte6  >= cmpVal)
								 || IS_TRUE(v.SByte7  >= cmpVal)
								 || IS_TRUE(v.SByte8  >= cmpVal)
								 || IS_TRUE(v.SByte9  >= cmpVal)
								 || IS_TRUE(v.SByte10 >= cmpVal)
								 || IS_TRUE(v.SByte11 >= cmpVal)
								 || IS_TRUE(v.SByte12 >= cmpVal)
								 || IS_TRUE(v.SByte13 >= cmpVal)
								 || IS_TRUE(v.SByte14 >= cmpVal)
								 || IS_TRUE(v.SByte15 >= cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_GE_EPI16(v128 v, int cmpVal, byte elements = 8)
			{
				switch (elements)
				{
					case  2: return IS_TRUE(v.SShort0 >= cmpVal)
								 || IS_TRUE(v.SShort1 >= cmpVal);

					case  3: return IS_TRUE(v.SShort0 >= cmpVal)
								 || IS_TRUE(v.SShort1 >= cmpVal)
								 || IS_TRUE(v.SShort2 >= cmpVal);

					case  4: return IS_TRUE(v.SShort0 >= cmpVal)
								 || IS_TRUE(v.SShort1 >= cmpVal)
								 || IS_TRUE(v.SShort2 >= cmpVal)
								 || IS_TRUE(v.SShort3 >= cmpVal);

					default: return IS_TRUE(v.SShort0 >= cmpVal)
								 || IS_TRUE(v.SShort1 >= cmpVal)
								 || IS_TRUE(v.SShort2 >= cmpVal)
								 || IS_TRUE(v.SShort3 >= cmpVal)
								 || IS_TRUE(v.SShort4 >= cmpVal)
								 || IS_TRUE(v.SShort5 >= cmpVal)
								 || IS_TRUE(v.SShort6 >= cmpVal)
								 || IS_TRUE(v.SShort7 >= cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_GE_EPI32(v128 v, int cmpVal, byte elements = 4)
			{
				switch (elements)
				{
					case  2: return IS_TRUE(v.SInt0 >= cmpVal)
								 || IS_TRUE(v.SInt1 >= cmpVal);

					case  3: return IS_TRUE(v.SInt0 >= cmpVal)
								 || IS_TRUE(v.SInt1 >= cmpVal)
								 || IS_TRUE(v.SInt2 >= cmpVal);

					default: return IS_TRUE(v.SInt0 >= cmpVal)
								 || IS_TRUE(v.SInt1 >= cmpVal)
								 || IS_TRUE(v.SInt2 >= cmpVal)
								 || IS_TRUE(v.SInt3 >= cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_GE_EPI64(v128 v, long cmpVal)
			{
				return IS_TRUE(v.SLong0 >= cmpVal)
					|| IS_TRUE(v.SLong1 >= cmpVal);
			}
			
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_GE_PS(v128 v, float cmpVal, byte elements = 4)
			{
				switch (elements)
				{
					case  1: return IS_TRUE(v.Float0 >= cmpVal);

					case  2: return IS_TRUE(v.Float0 >= cmpVal)
								 || IS_TRUE(v.Float1 >= cmpVal);

					case  3: return IS_TRUE(v.Float0 >= cmpVal)
								 || IS_TRUE(v.Float1 >= cmpVal)
								 || IS_TRUE(v.Float2 >= cmpVal);

					default: return IS_TRUE(v.Float0 >= cmpVal)
								 || IS_TRUE(v.Float1 >= cmpVal)
								 || IS_TRUE(v.Float2 >= cmpVal)
								 || IS_TRUE(v.Float3 >= cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_GE_PD(v128 v, double cmpVal)
			{
				return IS_TRUE(v.Double0 >= cmpVal)
					|| IS_TRUE(v.Double1 >= cmpVal);
			}


			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_GE_EPI8(v256 v, int cmpVal)
			{
				return IS_TRUE(v.SByte0  >= cmpVal)
					|| IS_TRUE(v.SByte1  >= cmpVal)
					|| IS_TRUE(v.SByte2  >= cmpVal)
					|| IS_TRUE(v.SByte3  >= cmpVal)
					|| IS_TRUE(v.SByte4  >= cmpVal)
					|| IS_TRUE(v.SByte5  >= cmpVal)
					|| IS_TRUE(v.SByte6  >= cmpVal)
					|| IS_TRUE(v.SByte7  >= cmpVal)
					|| IS_TRUE(v.SByte8  >= cmpVal)
					|| IS_TRUE(v.SByte9  >= cmpVal)
					|| IS_TRUE(v.SByte10 >= cmpVal)
					|| IS_TRUE(v.SByte11 >= cmpVal)
					|| IS_TRUE(v.SByte12 >= cmpVal)
					|| IS_TRUE(v.SByte13 >= cmpVal)
					|| IS_TRUE(v.SByte14 >= cmpVal)
					|| IS_TRUE(v.SByte15 >= cmpVal)
				    || IS_TRUE(v.SByte16 >= cmpVal)
					|| IS_TRUE(v.SByte17 >= cmpVal)
					|| IS_TRUE(v.SByte18 >= cmpVal)
					|| IS_TRUE(v.SByte19 >= cmpVal)
					|| IS_TRUE(v.SByte20 >= cmpVal)
					|| IS_TRUE(v.SByte21 >= cmpVal)
					|| IS_TRUE(v.SByte22 >= cmpVal)
					|| IS_TRUE(v.SByte23 >= cmpVal)
					|| IS_TRUE(v.SByte24 >= cmpVal)
					|| IS_TRUE(v.SByte25 >= cmpVal)
					|| IS_TRUE(v.SByte26 >= cmpVal)
					|| IS_TRUE(v.SByte27 >= cmpVal)
					|| IS_TRUE(v.SByte28 >= cmpVal)
					|| IS_TRUE(v.SByte29 >= cmpVal)
					|| IS_TRUE(v.SByte30 >= cmpVal)
					|| IS_TRUE(v.SByte31 >= cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_GE_EPI16(v256 v, int cmpVal)
			{
				return IS_TRUE(v.SShort0  >= cmpVal)
					|| IS_TRUE(v.SShort1  >= cmpVal)
					|| IS_TRUE(v.SShort2  >= cmpVal)
					|| IS_TRUE(v.SShort3  >= cmpVal)
					|| IS_TRUE(v.SShort4  >= cmpVal)
					|| IS_TRUE(v.SShort5  >= cmpVal)
					|| IS_TRUE(v.SShort6  >= cmpVal)
					|| IS_TRUE(v.SShort7  >= cmpVal)
					|| IS_TRUE(v.SShort8  >= cmpVal)
					|| IS_TRUE(v.SShort9  >= cmpVal)
					|| IS_TRUE(v.SShort10 >= cmpVal)
					|| IS_TRUE(v.SShort11 >= cmpVal)
					|| IS_TRUE(v.SShort12 >= cmpVal)
					|| IS_TRUE(v.SShort13 >= cmpVal)
					|| IS_TRUE(v.SShort14 >= cmpVal)
					|| IS_TRUE(v.SShort15 >= cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_GE_EPI32(v256 v, int cmpVal)
			{
				return IS_TRUE(v.SInt0 >= cmpVal)
					|| IS_TRUE(v.SInt1 >= cmpVal)
					|| IS_TRUE(v.SInt2 >= cmpVal)
					|| IS_TRUE(v.SInt3 >= cmpVal)
					|| IS_TRUE(v.SInt4 >= cmpVal)
					|| IS_TRUE(v.SInt5 >= cmpVal)
					|| IS_TRUE(v.SInt6 >= cmpVal)
					|| IS_TRUE(v.SInt7 >= cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_GE_EPI64(v256 v, long cmpVal, byte elements = 4)
			{
				if (elements == 3)
				{
					return IS_TRUE(v.SLong0 >= cmpVal)
						|| IS_TRUE(v.SLong1 >= cmpVal)
						|| IS_TRUE(v.SLong2 >= cmpVal);
				}
				else
				{
					return IS_TRUE(v.SLong0 >= cmpVal)
						|| IS_TRUE(v.SLong1 >= cmpVal)
						|| IS_TRUE(v.SLong2 >= cmpVal)
						|| IS_TRUE(v.SLong3 >= cmpVal);
				}
			}
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_GE_EPU8(v256 v, uint cmpVal)
			{
				return IS_TRUE(v.Byte0  >= cmpVal)
					|| IS_TRUE(v.Byte1  >= cmpVal)
					|| IS_TRUE(v.Byte2  >= cmpVal)
					|| IS_TRUE(v.Byte3  >= cmpVal)
					|| IS_TRUE(v.Byte4  >= cmpVal)
					|| IS_TRUE(v.Byte5  >= cmpVal)
					|| IS_TRUE(v.Byte6  >= cmpVal)
					|| IS_TRUE(v.Byte7  >= cmpVal)
					|| IS_TRUE(v.Byte8  >= cmpVal)
					|| IS_TRUE(v.Byte9  >= cmpVal)
					|| IS_TRUE(v.Byte10 >= cmpVal)
					|| IS_TRUE(v.Byte11 >= cmpVal)
					|| IS_TRUE(v.Byte12 >= cmpVal)
					|| IS_TRUE(v.Byte13 >= cmpVal)
					|| IS_TRUE(v.Byte14 >= cmpVal)
					|| IS_TRUE(v.Byte15 >= cmpVal)
				    || IS_TRUE(v.Byte16 >= cmpVal)
					|| IS_TRUE(v.Byte17 >= cmpVal)
					|| IS_TRUE(v.Byte18 >= cmpVal)
					|| IS_TRUE(v.Byte19 >= cmpVal)
					|| IS_TRUE(v.Byte20 >= cmpVal)
					|| IS_TRUE(v.Byte21 >= cmpVal)
					|| IS_TRUE(v.Byte22 >= cmpVal)
					|| IS_TRUE(v.Byte23 >= cmpVal)
					|| IS_TRUE(v.Byte24 >= cmpVal)
					|| IS_TRUE(v.Byte25 >= cmpVal)
					|| IS_TRUE(v.Byte26 >= cmpVal)
					|| IS_TRUE(v.Byte27 >= cmpVal)
					|| IS_TRUE(v.Byte28 >= cmpVal)
					|| IS_TRUE(v.Byte29 >= cmpVal)
					|| IS_TRUE(v.Byte30 >= cmpVal)
					|| IS_TRUE(v.Byte31 >= cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_GE_EPU16(v256 v, uint cmpVal)
			{
				return IS_TRUE(v.UShort0  >= cmpVal)
					|| IS_TRUE(v.UShort1  >= cmpVal)
					|| IS_TRUE(v.UShort2  >= cmpVal)
					|| IS_TRUE(v.UShort3  >= cmpVal)
					|| IS_TRUE(v.UShort4  >= cmpVal)
					|| IS_TRUE(v.UShort5  >= cmpVal)
					|| IS_TRUE(v.UShort6  >= cmpVal)
					|| IS_TRUE(v.UShort7  >= cmpVal)
					|| IS_TRUE(v.UShort8  >= cmpVal)
					|| IS_TRUE(v.UShort9  >= cmpVal)
					|| IS_TRUE(v.UShort10 >= cmpVal)
					|| IS_TRUE(v.UShort11 >= cmpVal)
					|| IS_TRUE(v.UShort12 >= cmpVal)
					|| IS_TRUE(v.UShort13 >= cmpVal)
					|| IS_TRUE(v.UShort14 >= cmpVal)
					|| IS_TRUE(v.UShort15 >= cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_GE_EPU32(v256 v, uint cmpVal)
			{
				return IS_TRUE(v.UInt0 >= cmpVal)
					|| IS_TRUE(v.UInt1 >= cmpVal)
					|| IS_TRUE(v.UInt2 >= cmpVal)
					|| IS_TRUE(v.UInt3 >= cmpVal)
					|| IS_TRUE(v.UInt4 >= cmpVal)
					|| IS_TRUE(v.UInt5 >= cmpVal)
					|| IS_TRUE(v.UInt6 >= cmpVal)
					|| IS_TRUE(v.UInt7 >= cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_GE_EPU64(v256 v, ulong cmpVal, byte elements = 4)
			{
				if (elements == 3)
				{
					return IS_TRUE(v.ULong0 >= cmpVal)
						|| IS_TRUE(v.ULong1 >= cmpVal)
						|| IS_TRUE(v.ULong2 >= cmpVal);
				}
				else
				{
					return IS_TRUE(v.ULong0 >= cmpVal)
						|| IS_TRUE(v.ULong1 >= cmpVal)
						|| IS_TRUE(v.ULong2 >= cmpVal)
						|| IS_TRUE(v.ULong3 >= cmpVal);
				}
			}


			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_GE_PS(v256 v, float cmpVal)
			{
				return IS_TRUE(v.Float0 >= cmpVal)
					|| IS_TRUE(v.Float1 >= cmpVal)
					|| IS_TRUE(v.Float2 >= cmpVal)
					|| IS_TRUE(v.Float3 >= cmpVal)
					|| IS_TRUE(v.Float4 >= cmpVal)
					|| IS_TRUE(v.Float5 >= cmpVal)
					|| IS_TRUE(v.Float6 >= cmpVal)
					|| IS_TRUE(v.Float7 >= cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_GE_PD(v256 v, double cmpVal, byte elements = 4)
			{
				if (elements == 3)
				{
					return IS_TRUE(v.Double0 >= cmpVal)
						|| IS_TRUE(v.Double1 >= cmpVal)
						|| IS_TRUE(v.Double2 >= cmpVal);
				}
				else
				{
					return IS_TRUE(v.Double0 >= cmpVal)
						|| IS_TRUE(v.Double1 >= cmpVal)
						|| IS_TRUE(v.Double2 >= cmpVal)
						|| IS_TRUE(v.Double3 >= cmpVal);
				}
			}


			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_LE_EPU8(v128 v, uint cmpVal, byte elements = 16)
			{
				switch (elements)
				{
					case  2: return IS_TRUE(v.Byte0  <= cmpVal)
								 || IS_TRUE(v.Byte1  <= cmpVal);
									
					case  3: return IS_TRUE(v.Byte0  <= cmpVal)
								 || IS_TRUE(v.Byte1  <= cmpVal)
								 || IS_TRUE(v.Byte2  <= cmpVal);

					case  4: return IS_TRUE(v.Byte0  <= cmpVal)
								 || IS_TRUE(v.Byte1  <= cmpVal)
								 || IS_TRUE(v.Byte2  <= cmpVal)
								 || IS_TRUE(v.Byte3  <= cmpVal);

					case  8: return IS_TRUE(v.Byte0  <= cmpVal)
								 || IS_TRUE(v.Byte1  <= cmpVal)
								 || IS_TRUE(v.Byte2  <= cmpVal)
								 || IS_TRUE(v.Byte3  <= cmpVal)
								 || IS_TRUE(v.Byte4  <= cmpVal)
								 || IS_TRUE(v.Byte5  <= cmpVal)
								 || IS_TRUE(v.Byte6  <= cmpVal)
								 || IS_TRUE(v.Byte7  <= cmpVal);

					default: return IS_TRUE(v.Byte0  <= cmpVal)
								 || IS_TRUE(v.Byte1  <= cmpVal)
								 || IS_TRUE(v.Byte2  <= cmpVal)
								 || IS_TRUE(v.Byte3  <= cmpVal)
								 || IS_TRUE(v.Byte4  <= cmpVal)
								 || IS_TRUE(v.Byte5  <= cmpVal)
								 || IS_TRUE(v.Byte6  <= cmpVal)
								 || IS_TRUE(v.Byte7  <= cmpVal)
								 || IS_TRUE(v.Byte8  <= cmpVal)
								 || IS_TRUE(v.Byte9  <= cmpVal)
								 || IS_TRUE(v.Byte10 <= cmpVal)
								 || IS_TRUE(v.Byte11 <= cmpVal)
								 || IS_TRUE(v.Byte12 <= cmpVal)
								 || IS_TRUE(v.Byte13 <= cmpVal)
								 || IS_TRUE(v.Byte14 <= cmpVal)
								 || IS_TRUE(v.Byte15 <= cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_LE_EPU16(v128 v, uint cmpVal, byte elements = 8)
			{
				switch (elements)
				{
					case  2: return IS_TRUE(v.UShort0  <= cmpVal)
								 || IS_TRUE(v.UShort1  <= cmpVal);

					case  3: return IS_TRUE(v.UShort0  <= cmpVal)
								 || IS_TRUE(v.UShort1  <= cmpVal)
								 || IS_TRUE(v.UShort2  <= cmpVal);

					case  4: return IS_TRUE(v.UShort0  <= cmpVal)
								 || IS_TRUE(v.UShort1  <= cmpVal)
								 || IS_TRUE(v.UShort2  <= cmpVal)
								 || IS_TRUE(v.UShort3  <= cmpVal);

					default: return IS_TRUE(v.UShort0  <= cmpVal)
								 || IS_TRUE(v.UShort1  <= cmpVal)
								 || IS_TRUE(v.UShort2  <= cmpVal)
								 || IS_TRUE(v.UShort3  <= cmpVal)
								 || IS_TRUE(v.UShort4  <= cmpVal)
								 || IS_TRUE(v.UShort5  <= cmpVal)
								 || IS_TRUE(v.UShort6  <= cmpVal)
								 || IS_TRUE(v.UShort7  <= cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_LE_EPU32(v128 v, uint cmpVal, byte elements = 4)
			{
				switch (elements)
				{
					case  2: return IS_TRUE(v.UInt0  <= cmpVal)
								 || IS_TRUE(v.UInt1  <= cmpVal);

					case  3: return IS_TRUE(v.UInt0  <= cmpVal)
								 || IS_TRUE(v.UInt1  <= cmpVal)
								 || IS_TRUE(v.UInt2  <= cmpVal);

					default: return IS_TRUE(v.UInt0  <= cmpVal)
								 || IS_TRUE(v.UInt1  <= cmpVal)
								 || IS_TRUE(v.UInt2  <= cmpVal)
								 || IS_TRUE(v.UInt3  <= cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_LE_EPU64(v128 v, ulong cmpVal)
			{
				return IS_TRUE(v.ULong0 <= cmpVal)
					|| IS_TRUE(v.ULong1 <= cmpVal);
			}
			
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_LE_EPI8(v128 v, int cmpVal, byte elements = 16)
			{
				switch (elements)
				{
					case  2: return IS_TRUE(v.SByte0  <= cmpVal)
								 || IS_TRUE(v.SByte1  <= cmpVal);

					case  3: return IS_TRUE(v.SByte0  <= cmpVal)
								 || IS_TRUE(v.SByte1  <= cmpVal)
								 || IS_TRUE(v.SByte2  <= cmpVal);

					case  4: return IS_TRUE(v.SByte0  <= cmpVal)
								 || IS_TRUE(v.SByte1  <= cmpVal)
								 || IS_TRUE(v.SByte2  <= cmpVal)
								 || IS_TRUE(v.SByte3  <= cmpVal);

					case  8: return IS_TRUE(v.SByte0  <= cmpVal)
								 || IS_TRUE(v.SByte1  <= cmpVal)
								 || IS_TRUE(v.SByte2  <= cmpVal)
								 || IS_TRUE(v.SByte3  <= cmpVal)
								 || IS_TRUE(v.SByte4  <= cmpVal)
								 || IS_TRUE(v.SByte5  <= cmpVal)
								 || IS_TRUE(v.SByte6  <= cmpVal)
								 || IS_TRUE(v.SByte7  <= cmpVal);

					default: return IS_TRUE(v.SByte0  <= cmpVal)
								 || IS_TRUE(v.SByte1  <= cmpVal)
								 || IS_TRUE(v.SByte2  <= cmpVal)
								 || IS_TRUE(v.SByte3  <= cmpVal)
								 || IS_TRUE(v.SByte4  <= cmpVal)
								 || IS_TRUE(v.SByte5  <= cmpVal)
								 || IS_TRUE(v.SByte6  <= cmpVal)
								 || IS_TRUE(v.SByte7  <= cmpVal)
								 || IS_TRUE(v.SByte8  <= cmpVal)
								 || IS_TRUE(v.SByte9  <= cmpVal)
								 || IS_TRUE(v.SByte10 <= cmpVal)
								 || IS_TRUE(v.SByte11 <= cmpVal)
								 || IS_TRUE(v.SByte12 <= cmpVal)
								 || IS_TRUE(v.SByte13 <= cmpVal)
								 || IS_TRUE(v.SByte14 <= cmpVal)
								 || IS_TRUE(v.SByte15 <= cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_LE_EPI16(v128 v, int cmpVal, byte elements = 8)
			{
				switch (elements)
				{
					case  2: return IS_TRUE(v.SShort0 <= cmpVal)
								 || IS_TRUE(v.SShort1 <= cmpVal);

					case  3: return IS_TRUE(v.SShort0 <= cmpVal)
								 || IS_TRUE(v.SShort1 <= cmpVal)
								 || IS_TRUE(v.SShort2 <= cmpVal);

					case  4: return IS_TRUE(v.SShort0 <= cmpVal)
								 || IS_TRUE(v.SShort1 <= cmpVal)
								 || IS_TRUE(v.SShort2 <= cmpVal)
								 || IS_TRUE(v.SShort3 <= cmpVal);

					default: return IS_TRUE(v.SShort0 <= cmpVal)
								 || IS_TRUE(v.SShort1 <= cmpVal)
								 || IS_TRUE(v.SShort2 <= cmpVal)
								 || IS_TRUE(v.SShort3 <= cmpVal)
								 || IS_TRUE(v.SShort4 <= cmpVal)
								 || IS_TRUE(v.SShort5 <= cmpVal)
								 || IS_TRUE(v.SShort6 <= cmpVal)
								 || IS_TRUE(v.SShort7 <= cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_LE_EPI32(v128 v, int cmpVal, byte elements = 4)
			{
				switch (elements)
				{
					case  2: return IS_TRUE(v.SInt0 <= cmpVal)
								 || IS_TRUE(v.SInt1 <= cmpVal);

					case  3: return IS_TRUE(v.SInt0 <= cmpVal)
								 || IS_TRUE(v.SInt1 <= cmpVal)
								 || IS_TRUE(v.SInt2 <= cmpVal);

					default: return IS_TRUE(v.SInt0 <= cmpVal)
								 || IS_TRUE(v.SInt1 <= cmpVal)
								 || IS_TRUE(v.SInt2 <= cmpVal)
								 || IS_TRUE(v.SInt3 <= cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_LE_EPI64(v128 v, long cmpVal)
			{
				return IS_TRUE(v.SLong0 <= cmpVal)
					|| IS_TRUE(v.SLong1 <= cmpVal);
			}
			
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_LE_PS(v128 v, float cmpVal, byte elements = 4)
			{
				switch (elements)
				{
					case  1: return IS_TRUE(v.Float0 <= cmpVal);

					case  2: return IS_TRUE(v.Float0 <= cmpVal)
								 || IS_TRUE(v.Float1 <= cmpVal);

					case  3: return IS_TRUE(v.Float0 <= cmpVal)
								 || IS_TRUE(v.Float1 <= cmpVal)
								 || IS_TRUE(v.Float2 <= cmpVal);

					default: return IS_TRUE(v.Float0 <= cmpVal)
								 || IS_TRUE(v.Float1 <= cmpVal)
								 || IS_TRUE(v.Float2 <= cmpVal)
								 || IS_TRUE(v.Float3 <= cmpVal);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_LE_PD(v128 v, double cmpVal)
			{
				return IS_TRUE(v.Double0 <= cmpVal)
					|| IS_TRUE(v.Double1 <= cmpVal);
			}


			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_LE_EPI8(v256 v, int cmpVal)
			{
				return IS_TRUE(v.SByte0  <= cmpVal)
					|| IS_TRUE(v.SByte1  <= cmpVal)
					|| IS_TRUE(v.SByte2  <= cmpVal)
					|| IS_TRUE(v.SByte3  <= cmpVal)
					|| IS_TRUE(v.SByte4  <= cmpVal)
					|| IS_TRUE(v.SByte5  <= cmpVal)
					|| IS_TRUE(v.SByte6  <= cmpVal)
					|| IS_TRUE(v.SByte7  <= cmpVal)
					|| IS_TRUE(v.SByte8  <= cmpVal)
					|| IS_TRUE(v.SByte9  <= cmpVal)
					|| IS_TRUE(v.SByte10 <= cmpVal)
					|| IS_TRUE(v.SByte11 <= cmpVal)
					|| IS_TRUE(v.SByte12 <= cmpVal)
					|| IS_TRUE(v.SByte13 <= cmpVal)
					|| IS_TRUE(v.SByte14 <= cmpVal)
					|| IS_TRUE(v.SByte15 <= cmpVal)
				    || IS_TRUE(v.SByte16 <= cmpVal)
					|| IS_TRUE(v.SByte17 <= cmpVal)
					|| IS_TRUE(v.SByte18 <= cmpVal)
					|| IS_TRUE(v.SByte19 <= cmpVal)
					|| IS_TRUE(v.SByte20 <= cmpVal)
					|| IS_TRUE(v.SByte21 <= cmpVal)
					|| IS_TRUE(v.SByte22 <= cmpVal)
					|| IS_TRUE(v.SByte23 <= cmpVal)
					|| IS_TRUE(v.SByte24 <= cmpVal)
					|| IS_TRUE(v.SByte25 <= cmpVal)
					|| IS_TRUE(v.SByte26 <= cmpVal)
					|| IS_TRUE(v.SByte27 <= cmpVal)
					|| IS_TRUE(v.SByte28 <= cmpVal)
					|| IS_TRUE(v.SByte29 <= cmpVal)
					|| IS_TRUE(v.SByte30 <= cmpVal)
					|| IS_TRUE(v.SByte31 <= cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_LE_EPI16(v256 v, int cmpVal)
			{
				return IS_TRUE(v.SShort0  <= cmpVal)
					|| IS_TRUE(v.SShort1  <= cmpVal)
					|| IS_TRUE(v.SShort2  <= cmpVal)
					|| IS_TRUE(v.SShort3  <= cmpVal)
					|| IS_TRUE(v.SShort4  <= cmpVal)
					|| IS_TRUE(v.SShort5  <= cmpVal)
					|| IS_TRUE(v.SShort6  <= cmpVal)
					|| IS_TRUE(v.SShort7  <= cmpVal)
					|| IS_TRUE(v.SShort8  <= cmpVal)
					|| IS_TRUE(v.SShort9  <= cmpVal)
					|| IS_TRUE(v.SShort10 <= cmpVal)
					|| IS_TRUE(v.SShort11 <= cmpVal)
					|| IS_TRUE(v.SShort12 <= cmpVal)
					|| IS_TRUE(v.SShort13 <= cmpVal)
					|| IS_TRUE(v.SShort14 <= cmpVal)
					|| IS_TRUE(v.SShort15 <= cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_LE_EPI32(v256 v, int cmpVal)
			{
				return IS_TRUE(v.SInt0 <= cmpVal)
					|| IS_TRUE(v.SInt1 <= cmpVal)
					|| IS_TRUE(v.SInt2 <= cmpVal)
					|| IS_TRUE(v.SInt3 <= cmpVal)
					|| IS_TRUE(v.SInt4 <= cmpVal)
					|| IS_TRUE(v.SInt5 <= cmpVal)
					|| IS_TRUE(v.SInt6 <= cmpVal)
					|| IS_TRUE(v.SInt7 <= cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_LE_EPI64(v256 v, long cmpVal, byte elements = 4)
			{
				if (elements == 3)
				{
					return IS_TRUE(v.SLong0 <= cmpVal)
						|| IS_TRUE(v.SLong1 <= cmpVal)
						|| IS_TRUE(v.SLong2 <= cmpVal);
				}
				else
				{
					return IS_TRUE(v.SLong0 <= cmpVal)
						|| IS_TRUE(v.SLong1 <= cmpVal)
						|| IS_TRUE(v.SLong2 <= cmpVal)
						|| IS_TRUE(v.SLong3 <= cmpVal);
				}
			}
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_LE_EPU8(v256 v, uint cmpVal)
			{
				return IS_TRUE(v.Byte0  <= cmpVal)
					|| IS_TRUE(v.Byte1  <= cmpVal)
					|| IS_TRUE(v.Byte2  <= cmpVal)
					|| IS_TRUE(v.Byte3  <= cmpVal)
					|| IS_TRUE(v.Byte4  <= cmpVal)
					|| IS_TRUE(v.Byte5  <= cmpVal)
					|| IS_TRUE(v.Byte6  <= cmpVal)
					|| IS_TRUE(v.Byte7  <= cmpVal)
					|| IS_TRUE(v.Byte8  <= cmpVal)
					|| IS_TRUE(v.Byte9  <= cmpVal)
					|| IS_TRUE(v.Byte10 <= cmpVal)
					|| IS_TRUE(v.Byte11 <= cmpVal)
					|| IS_TRUE(v.Byte12 <= cmpVal)
					|| IS_TRUE(v.Byte13 <= cmpVal)
					|| IS_TRUE(v.Byte14 <= cmpVal)
					|| IS_TRUE(v.Byte15 <= cmpVal)
				    || IS_TRUE(v.Byte16 <= cmpVal)
					|| IS_TRUE(v.Byte17 <= cmpVal)
					|| IS_TRUE(v.Byte18 <= cmpVal)
					|| IS_TRUE(v.Byte19 <= cmpVal)
					|| IS_TRUE(v.Byte20 <= cmpVal)
					|| IS_TRUE(v.Byte21 <= cmpVal)
					|| IS_TRUE(v.Byte22 <= cmpVal)
					|| IS_TRUE(v.Byte23 <= cmpVal)
					|| IS_TRUE(v.Byte24 <= cmpVal)
					|| IS_TRUE(v.Byte25 <= cmpVal)
					|| IS_TRUE(v.Byte26 <= cmpVal)
					|| IS_TRUE(v.Byte27 <= cmpVal)
					|| IS_TRUE(v.Byte28 <= cmpVal)
					|| IS_TRUE(v.Byte29 <= cmpVal)
					|| IS_TRUE(v.Byte30 <= cmpVal)
					|| IS_TRUE(v.Byte31 <= cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_LE_EPU16(v256 v, uint cmpVal)
			{
				return IS_TRUE(v.UShort0  <= cmpVal)
					|| IS_TRUE(v.UShort1  <= cmpVal)
					|| IS_TRUE(v.UShort2  <= cmpVal)
					|| IS_TRUE(v.UShort3  <= cmpVal)
					|| IS_TRUE(v.UShort4  <= cmpVal)
					|| IS_TRUE(v.UShort5  <= cmpVal)
					|| IS_TRUE(v.UShort6  <= cmpVal)
					|| IS_TRUE(v.UShort7  <= cmpVal)
					|| IS_TRUE(v.UShort8  <= cmpVal)
					|| IS_TRUE(v.UShort9  <= cmpVal)
					|| IS_TRUE(v.UShort10 <= cmpVal)
					|| IS_TRUE(v.UShort11 <= cmpVal)
					|| IS_TRUE(v.UShort12 <= cmpVal)
					|| IS_TRUE(v.UShort13 <= cmpVal)
					|| IS_TRUE(v.UShort14 <= cmpVal)
					|| IS_TRUE(v.UShort15 <= cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_LE_EPU32(v256 v, uint cmpVal)
			{
				return IS_TRUE(v.UInt0 <= cmpVal)
					|| IS_TRUE(v.UInt1 <= cmpVal)
					|| IS_TRUE(v.UInt2 <= cmpVal)
					|| IS_TRUE(v.UInt3 <= cmpVal)
					|| IS_TRUE(v.UInt4 <= cmpVal)
					|| IS_TRUE(v.UInt5 <= cmpVal)
					|| IS_TRUE(v.UInt6 <= cmpVal)
					|| IS_TRUE(v.UInt7 <= cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_LE_EPU64(v256 v, ulong cmpVal, byte elements = 4)
			{
				if (elements == 3)
				{
					return IS_TRUE(v.ULong0 <= cmpVal)
						|| IS_TRUE(v.ULong1 <= cmpVal)
						|| IS_TRUE(v.ULong2 <= cmpVal);
				}
				else
				{
					return IS_TRUE(v.ULong0 <= cmpVal)
						|| IS_TRUE(v.ULong1 <= cmpVal)
						|| IS_TRUE(v.ULong2 <= cmpVal)
						|| IS_TRUE(v.ULong3 <= cmpVal);
				}
			}


			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_LE_PS(v256 v, float cmpVal)
			{
				return IS_TRUE(v.Float0 <= cmpVal)
					|| IS_TRUE(v.Float1 <= cmpVal)
					|| IS_TRUE(v.Float2 <= cmpVal)
					|| IS_TRUE(v.Float3 <= cmpVal)
					|| IS_TRUE(v.Float4 <= cmpVal)
					|| IS_TRUE(v.Float5 <= cmpVal)
					|| IS_TRUE(v.Float6 <= cmpVal)
					|| IS_TRUE(v.Float7 <= cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_LE_PD(v256 v, double cmpVal, byte elements = 4)
			{
				if (elements == 3)
				{
					return IS_TRUE(v.Double0 <= cmpVal)
						|| IS_TRUE(v.Double1 <= cmpVal)
						|| IS_TRUE(v.Double2 <= cmpVal);
				}
				else
				{
					return IS_TRUE(v.Double0 <= cmpVal)
						|| IS_TRUE(v.Double1 <= cmpVal)
						|| IS_TRUE(v.Double2 <= cmpVal)
						|| IS_TRUE(v.Double3 <= cmpVal);
				}
			}


			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_SAME_EPU8(v128 v, byte elements = 16)
			{
				return ALL_EQ_EPU8(v, v.Byte0, elements);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_SAME_EPU16(v128 v, byte elements = 8)
			{
				return ALL_EQ_EPU16(v, v.UShort0, elements);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_SAME_EPU32(v128 v, byte elements = 4)
			{
				return ALL_EQ_EPU32(v, v.UInt0, elements);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_SAME_EPU64(v128 v)
			{
				return ALL_EQ_EPU64(v, v.ULong0);
			}
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_SAME_EPI8(v128 v, byte elements = 16)
			{
				return ALL_EQ_EPI8(v, v.SByte0, elements);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_SAME_EPI16(v128 v, byte elements = 8)
			{
				return ALL_EQ_EPI16(v, v.SShort0, elements);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_SAME_EPI32(v128 v, byte elements = 4)
			{
				return ALL_EQ_EPI32(v, v.SInt0, elements);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_SAME_EPI64(v128 v)
			{
				return ALL_EQ_EPI64(v, v.SLong0);
			}


			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_SAME_PS(v128 v, byte elements = 4)
			{
				return ALL_EQ_PS(v, v.Float0, elements);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_SAME_PD(v128 v)
			{
				return ALL_EQ_PD(v, v.Double0);
			}


			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_SAME_EPU8(v256 v)
			{
				return ALL_EQ_EPU8(v, v.Byte0);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_SAME_EPU16(v256 v)
			{
				return ALL_EQ_EPU16(v, v.UShort0);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_SAME_EPU32(v256 v)
			{
				return ALL_EQ_EPU32(v, v.UInt0);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_SAME_EPU64(v256 v, byte elements = 4)
			{
				return ALL_EQ_EPU64(v, v.ULong0, elements);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_SAME_PS(v256 v)
			{
				return ALL_EQ_PS(v, v.Float0);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_SAME_PD(v256 v, byte elements = 4)
			{
				return ALL_EQ_PD(v, v.Double0, elements);
			}


			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_SAME_EPI8(v256 v)
			{
				return ALL_EQ_EPI8(v, v.SByte0);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_SAME_EPI16(v256 v)
			{
				return ALL_EQ_EPI16(v, v.SShort0);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_SAME_EPI32(v256 v)
			{
				return ALL_EQ_EPI32(v, v.SInt0);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_SAME_EPI64(v256 v, byte elements = 4)
			{
				return ALL_EQ_EPI64(v, v.SLong0);
			}

			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_NAN_PS(v128 v, byte elements = 4)
            {
				switch (elements)
				{
					case  2: return IS_TRUE(math.isnan(v.Float0))
								 && IS_TRUE(math.isnan(v.Float1));

					case  3: return IS_TRUE(math.isnan(v.Float0))
								 && IS_TRUE(math.isnan(v.Float1))
								 && IS_TRUE(math.isnan(v.Float2));

					default: return IS_TRUE(math.isnan(v.Float0))
								 && IS_TRUE(math.isnan(v.Float1))
								 && IS_TRUE(math.isnan(v.Float2))
								 && IS_TRUE(math.isnan(v.Float3));
				}
            }

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_NAN_PS(v128 v, byte elements = 4)
            {
				switch (elements)
				{
					case  2: return IS_TRUE(math.isnan(v.Float0))
								 || IS_TRUE(math.isnan(v.Float1));

					case  3: return IS_TRUE(math.isnan(v.Float0))
								 || IS_TRUE(math.isnan(v.Float1))
								 || IS_TRUE(math.isnan(v.Float2));

					default: return IS_TRUE(math.isnan(v.Float0))
								 || IS_TRUE(math.isnan(v.Float1))
								 || IS_TRUE(math.isnan(v.Float2))
								 || IS_TRUE(math.isnan(v.Float3));
				}
            }

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_NOTNAN_PS(v128 v, byte elements = 4)
            {
				switch (elements)
				{
					case  2: return IS_TRUE(!math.isnan(v.Float0))
								 && IS_TRUE(!math.isnan(v.Float1));

					case  3: return IS_TRUE(!math.isnan(v.Float0))
								 && IS_TRUE(!math.isnan(v.Float1))
								 && IS_TRUE(!math.isnan(v.Float2));

					default: return IS_TRUE(!math.isnan(v.Float0))
								 && IS_TRUE(!math.isnan(v.Float1))
								 && IS_TRUE(!math.isnan(v.Float2))
								 && IS_TRUE(!math.isnan(v.Float3));
				}
            }

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_NOTNAN_PS(v128 v, byte elements = 4)
            {
				switch (elements)
				{
					case  2: return IS_TRUE(!math.isnan(v.Float0))
								 || IS_TRUE(!math.isnan(v.Float1));

					case  3: return IS_TRUE(!math.isnan(v.Float0))
								 || IS_TRUE(!math.isnan(v.Float1))
								 || IS_TRUE(!math.isnan(v.Float2));

					default: return IS_TRUE(!math.isnan(v.Float0))
								 || IS_TRUE(!math.isnan(v.Float1))
								 || IS_TRUE(!math.isnan(v.Float2))
								 || IS_TRUE(!math.isnan(v.Float3));
				}
            }

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_NAN_PS(v256 v)
            {
				return IS_TRUE(math.isnan(v.Float0))
					&& IS_TRUE(math.isnan(v.Float1))
					&& IS_TRUE(math.isnan(v.Float2))
					&& IS_TRUE(math.isnan(v.Float3))
					&& IS_TRUE(math.isnan(v.Float4))
					&& IS_TRUE(math.isnan(v.Float5))
					&& IS_TRUE(math.isnan(v.Float6))
					&& IS_TRUE(math.isnan(v.Float7));
            }

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_NAN_PS(v256 v)
            {
				return IS_TRUE(math.isnan(v.Float0))
					|| IS_TRUE(math.isnan(v.Float1))
					|| IS_TRUE(math.isnan(v.Float2))
					|| IS_TRUE(math.isnan(v.Float3))
					|| IS_TRUE(math.isnan(v.Float4))
					|| IS_TRUE(math.isnan(v.Float5))
					|| IS_TRUE(math.isnan(v.Float6))
					|| IS_TRUE(math.isnan(v.Float7));
            }

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_NOTNAN_PS(v256 v)
            {
				return IS_TRUE(!math.isnan(v.Float0))
					&& IS_TRUE(!math.isnan(v.Float1))
					&& IS_TRUE(!math.isnan(v.Float2))
					&& IS_TRUE(!math.isnan(v.Float3))
					&& IS_TRUE(!math.isnan(v.Float4))
					&& IS_TRUE(!math.isnan(v.Float5))
					&& IS_TRUE(!math.isnan(v.Float6))
					&& IS_TRUE(!math.isnan(v.Float7));
            }

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_NOTNAN_PS(v256 v)
            {
				return IS_TRUE(!math.isnan(v.Float0))
					|| IS_TRUE(!math.isnan(v.Float1))
					|| IS_TRUE(!math.isnan(v.Float2))
					|| IS_TRUE(!math.isnan(v.Float3))
					|| IS_TRUE(!math.isnan(v.Float4))
					|| IS_TRUE(!math.isnan(v.Float5))
					|| IS_TRUE(!math.isnan(v.Float6))
					|| IS_TRUE(!math.isnan(v.Float7));
            }


			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_NAN_PD(v128 v)
            {
				return IS_TRUE(math.isnan(v.Double0))
					&& IS_TRUE(math.isnan(v.Double1));
            }

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_NAN_PD(v128 v)
            {
				return IS_TRUE(math.isnan(v.Double0))
					|| IS_TRUE(math.isnan(v.Double1));
            }

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_NOTNAN_PD(v128 v)
            {
				return IS_TRUE(!math.isnan(v.Double0))
				    && IS_TRUE(!math.isnan(v.Double1));
            }

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_NOTNAN_PD(v128 v)
            {
				return IS_TRUE(!math.isnan(v.Double0))
					|| IS_TRUE(!math.isnan(v.Double1));
            }

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_NAN_PD(v256 v, byte elements = 4)
            {
                if (elements == 3)
                {
					return IS_TRUE(math.isnan(v.Double0))
						&& IS_TRUE(math.isnan(v.Double1))
						&& IS_TRUE(math.isnan(v.Double2));
                }
				else
                {
					return IS_TRUE(math.isnan(v.Double0))
						&& IS_TRUE(math.isnan(v.Double1))
						&& IS_TRUE(math.isnan(v.Double2))
						&& IS_TRUE(math.isnan(v.Double3));
                }
            }

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_NAN_PD(v256 v, byte elements = 4)
            {
                if (elements == 3)
                {
					return IS_TRUE(math.isnan(v.Double0))
						|| IS_TRUE(math.isnan(v.Double1))
						|| IS_TRUE(math.isnan(v.Double2));
                }
				else
                {
					return IS_TRUE(math.isnan(v.Double0))
						|| IS_TRUE(math.isnan(v.Double1))
						|| IS_TRUE(math.isnan(v.Double2))
						|| IS_TRUE(math.isnan(v.Double3));
                }
            }

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ALL_NOTNAN_PD(v256 v, byte elements = 4)
            {
                if (elements == 3)
                {
					return IS_TRUE(!math.isnan(v.Double0))
						&& IS_TRUE(!math.isnan(v.Double1))
						&& IS_TRUE(!math.isnan(v.Double2));
                }
				else
                {
					return IS_TRUE(!math.isnan(v.Double0))
						&& IS_TRUE(!math.isnan(v.Double1))
						&& IS_TRUE(!math.isnan(v.Double2))
						&& IS_TRUE(!math.isnan(v.Double3));
                }
            }

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool ANY_NOTNAN_PD(v256 v, byte elements = 4)
            {
                if (elements == 3)
                {
					return IS_TRUE(!math.isnan(v.Double0))
						|| IS_TRUE(!math.isnan(v.Double1))
						|| IS_TRUE(!math.isnan(v.Double2));
                }
				else
                {
					return IS_TRUE(!math.isnan(v.Double0))
						|| IS_TRUE(!math.isnan(v.Double1))
						|| IS_TRUE(!math.isnan(v.Double2))
						|| IS_TRUE(!math.isnan(v.Double3));
                }
            }
		}
    }
}
