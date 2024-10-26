using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;

namespace MaxMath.Intrinsics
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


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_POW2_EPU8(v128 v, byte elements = 16)
		{
			switch (elements)
			{
				case  1: return IS_TRUE(maxmath.ispow2(v.Byte0 ));

				case  2: return IS_TRUE(maxmath.ispow2(v.Byte0 ))
							 && IS_TRUE(maxmath.ispow2(v.Byte1 ));

				case  3: return IS_TRUE(maxmath.ispow2(v.Byte0 ))
							 && IS_TRUE(maxmath.ispow2(v.Byte1 ))
							 && IS_TRUE(maxmath.ispow2(v.Byte2 ));

				case  4: return IS_TRUE(maxmath.ispow2(v.Byte0 ))
							 && IS_TRUE(maxmath.ispow2(v.Byte1 ))
							 && IS_TRUE(maxmath.ispow2(v.Byte2 ))
							 && IS_TRUE(maxmath.ispow2(v.Byte3 ));

				case  8: return IS_TRUE(maxmath.ispow2(v.Byte0 ))
							 && IS_TRUE(maxmath.ispow2(v.Byte1 ))
							 && IS_TRUE(maxmath.ispow2(v.Byte2 ))
							 && IS_TRUE(maxmath.ispow2(v.Byte3 ))
							 && IS_TRUE(maxmath.ispow2(v.Byte4 ))
							 && IS_TRUE(maxmath.ispow2(v.Byte5 ))
							 && IS_TRUE(maxmath.ispow2(v.Byte6 ))
							 && IS_TRUE(maxmath.ispow2(v.Byte7 ));

				default: return IS_TRUE(maxmath.ispow2(v.Byte0 ))
							 && IS_TRUE(maxmath.ispow2(v.Byte1 ))
							 && IS_TRUE(maxmath.ispow2(v.Byte2 ))
							 && IS_TRUE(maxmath.ispow2(v.Byte3 ))
							 && IS_TRUE(maxmath.ispow2(v.Byte4 ))
							 && IS_TRUE(maxmath.ispow2(v.Byte5 ))
							 && IS_TRUE(maxmath.ispow2(v.Byte6 ))
							 && IS_TRUE(maxmath.ispow2(v.Byte7 ))
							 && IS_TRUE(maxmath.ispow2(v.Byte8 ))
							 && IS_TRUE(maxmath.ispow2(v.Byte9 ))
							 && IS_TRUE(maxmath.ispow2(v.Byte10))
							 && IS_TRUE(maxmath.ispow2(v.Byte11))
							 && IS_TRUE(maxmath.ispow2(v.Byte12))
							 && IS_TRUE(maxmath.ispow2(v.Byte13))
							 && IS_TRUE(maxmath.ispow2(v.Byte14))
							 && IS_TRUE(maxmath.ispow2(v.Byte15));
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_POW2_EPU16(v128 v, byte elements = 8)
		{
			switch (elements)
			{
				case  1: return IS_TRUE(maxmath.ispow2(v.UShort0));

				case  2: return IS_TRUE(maxmath.ispow2(v.UShort0))
							 && IS_TRUE(maxmath.ispow2(v.UShort1));

				case  3: return IS_TRUE(maxmath.ispow2(v.UShort0))
							 && IS_TRUE(maxmath.ispow2(v.UShort1))
							 && IS_TRUE(maxmath.ispow2(v.UShort2));

				case  4: return IS_TRUE(maxmath.ispow2(v.UShort0))
							 && IS_TRUE(maxmath.ispow2(v.UShort1))
							 && IS_TRUE(maxmath.ispow2(v.UShort2))
							 && IS_TRUE(maxmath.ispow2(v.UShort3));

				default: return IS_TRUE(maxmath.ispow2(v.UShort0))
							 && IS_TRUE(maxmath.ispow2(v.UShort1))
							 && IS_TRUE(maxmath.ispow2(v.UShort2))
							 && IS_TRUE(maxmath.ispow2(v.UShort3))
							 && IS_TRUE(maxmath.ispow2(v.UShort4))
							 && IS_TRUE(maxmath.ispow2(v.UShort5))
							 && IS_TRUE(maxmath.ispow2(v.UShort6))
							 && IS_TRUE(maxmath.ispow2(v.UShort7));
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_POW2_EPU32(v128 v, byte elements = 4)
		{
			switch (elements)
			{
				case  1: return IS_TRUE(math.ispow2(v.UInt0));

				case  2: return IS_TRUE(math.ispow2(v.UInt0))
							 && IS_TRUE(math.ispow2(v.UInt1));

				case  3: return IS_TRUE(math.ispow2(v.UInt0))
							 && IS_TRUE(math.ispow2(v.UInt1))
							 && IS_TRUE(math.ispow2(v.UInt2));

				default: return IS_TRUE(math.ispow2(v.UInt0))
							 && IS_TRUE(math.ispow2(v.UInt1))
							 && IS_TRUE(math.ispow2(v.UInt2))
							 && IS_TRUE(math.ispow2(v.UInt3));
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_POW2_EPU64(v128 v, byte elements = 2)
		{
             if (elements == 1)
             {
				return IS_TRUE(maxmath.ispow2(v.ULong0));
             }
			else
			{
				return IS_TRUE(maxmath.ispow2(v.ULong0))
					&& IS_TRUE(maxmath.ispow2(v.ULong1));
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_POW2_EPU128(v128 vLo, v128 vHi)
		{
			return IS_TRUE(maxmath.ispow2(new UInt128(vLo.ULong0, vHi.ULong0)))
				&& IS_TRUE(maxmath.ispow2(new UInt128(vLo.ULong1, vHi.ULong1)));
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_POW2_EPI8(v128 v, byte elements = 16)
		{
			switch (elements)
			{
				case  1: return IS_TRUE(maxmath.ispow2((byte)maxmath.abs(v.SByte0 )));

				case  2: return IS_TRUE(maxmath.ispow2((byte)maxmath.abs(v.SByte0 )))
							 && IS_TRUE(maxmath.ispow2((byte)maxmath.abs(v.SByte1 )));

				case  3: return IS_TRUE(maxmath.ispow2((byte)maxmath.abs(v.SByte0 )))
							 && IS_TRUE(maxmath.ispow2((byte)maxmath.abs(v.SByte1 )))
							 && IS_TRUE(maxmath.ispow2((byte)maxmath.abs(v.SByte2 )));

				case  4: return IS_TRUE(maxmath.ispow2((byte)maxmath.abs(v.SByte0 )))
							 && IS_TRUE(maxmath.ispow2((byte)maxmath.abs(v.SByte1 )))
							 && IS_TRUE(maxmath.ispow2((byte)maxmath.abs(v.SByte2 )))
							 && IS_TRUE(maxmath.ispow2((byte)maxmath.abs(v.SByte3 )));

				case  8: return IS_TRUE(maxmath.ispow2((byte)maxmath.abs(v.SByte0 )))
							 && IS_TRUE(maxmath.ispow2((byte)maxmath.abs(v.SByte1 )))
							 && IS_TRUE(maxmath.ispow2((byte)maxmath.abs(v.SByte2 )))
							 && IS_TRUE(maxmath.ispow2((byte)maxmath.abs(v.SByte3 )))
							 && IS_TRUE(maxmath.ispow2((byte)maxmath.abs(v.SByte4 )))
							 && IS_TRUE(maxmath.ispow2((byte)maxmath.abs(v.SByte5 )))
							 && IS_TRUE(maxmath.ispow2((byte)maxmath.abs(v.SByte6 )))
							 && IS_TRUE(maxmath.ispow2((byte)maxmath.abs(v.SByte7 )));

				default: return IS_TRUE(maxmath.ispow2((byte)maxmath.abs(v.SByte0 )))
							 && IS_TRUE(maxmath.ispow2((byte)maxmath.abs(v.SByte1 )))
							 && IS_TRUE(maxmath.ispow2((byte)maxmath.abs(v.SByte2 )))
							 && IS_TRUE(maxmath.ispow2((byte)maxmath.abs(v.SByte3 )))
							 && IS_TRUE(maxmath.ispow2((byte)maxmath.abs(v.SByte4 )))
							 && IS_TRUE(maxmath.ispow2((byte)maxmath.abs(v.SByte5 )))
							 && IS_TRUE(maxmath.ispow2((byte)maxmath.abs(v.SByte6 )))
							 && IS_TRUE(maxmath.ispow2((byte)maxmath.abs(v.SByte7 )))
							 && IS_TRUE(maxmath.ispow2((byte)maxmath.abs(v.SByte8 )))
							 && IS_TRUE(maxmath.ispow2((byte)maxmath.abs(v.SByte9 )))
							 && IS_TRUE(maxmath.ispow2((byte)maxmath.abs(v.SByte10)))
							 && IS_TRUE(maxmath.ispow2((byte)maxmath.abs(v.SByte11)))
							 && IS_TRUE(maxmath.ispow2((byte)maxmath.abs(v.SByte12)))
							 && IS_TRUE(maxmath.ispow2((byte)maxmath.abs(v.SByte13)))
							 && IS_TRUE(maxmath.ispow2((byte)maxmath.abs(v.SByte14)))
							 && IS_TRUE(maxmath.ispow2((byte)maxmath.abs(v.SByte15)));
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_POW2_EPI16(v128 v, byte elements = 8)
		{
			switch (elements)
			{
				case  1: return IS_TRUE(maxmath.ispow2((ushort)maxmath.abs(v.SShort0)));

				case  2: return IS_TRUE(maxmath.ispow2((ushort)maxmath.abs(v.SShort0)))
							 && IS_TRUE(maxmath.ispow2((ushort)maxmath.abs(v.SShort1)));

				case  3: return IS_TRUE(maxmath.ispow2((ushort)maxmath.abs(v.SShort0)))
							 && IS_TRUE(maxmath.ispow2((ushort)maxmath.abs(v.SShort1)))
							 && IS_TRUE(maxmath.ispow2((ushort)maxmath.abs(v.SShort2)));

				case  4: return IS_TRUE(maxmath.ispow2((ushort)maxmath.abs(v.SShort0)))
							 && IS_TRUE(maxmath.ispow2((ushort)maxmath.abs(v.SShort1)))
							 && IS_TRUE(maxmath.ispow2((ushort)maxmath.abs(v.SShort2)))
							 && IS_TRUE(maxmath.ispow2((ushort)maxmath.abs(v.SShort3)));

				default: return IS_TRUE(maxmath.ispow2((ushort)maxmath.abs(v.SShort0)))
							 && IS_TRUE(maxmath.ispow2((ushort)maxmath.abs(v.SShort1)))
							 && IS_TRUE(maxmath.ispow2((ushort)maxmath.abs(v.SShort2)))
							 && IS_TRUE(maxmath.ispow2((ushort)maxmath.abs(v.SShort3)))
							 && IS_TRUE(maxmath.ispow2((ushort)maxmath.abs(v.SShort4)))
							 && IS_TRUE(maxmath.ispow2((ushort)maxmath.abs(v.SShort5)))
							 && IS_TRUE(maxmath.ispow2((ushort)maxmath.abs(v.SShort6)))
							 && IS_TRUE(maxmath.ispow2((ushort)maxmath.abs(v.SShort7)));
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_POW2_EPI32(v128 v, byte elements = 4)
		{
			switch (elements)
			{
				case  1: return IS_TRUE(math.ispow2((uint)math.abs(v.SInt0)));

				case  2: return IS_TRUE(math.ispow2((uint)math.abs(v.SInt0)))
							 && IS_TRUE(math.ispow2((uint)math.abs(v.SInt1)));

				case  3: return IS_TRUE(math.ispow2((uint)math.abs(v.SInt0)))
							 && IS_TRUE(math.ispow2((uint)math.abs(v.SInt1)))
							 && IS_TRUE(math.ispow2((uint)math.abs(v.SInt2)));

				default: return IS_TRUE(math.ispow2((uint)math.abs(v.SInt0)))
							 && IS_TRUE(math.ispow2((uint)math.abs(v.SInt1)))
							 && IS_TRUE(math.ispow2((uint)math.abs(v.SInt2)))
							 && IS_TRUE(math.ispow2((uint)math.abs(v.SInt3)));
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_POW2_EPI64(v128 v, byte elements = 2)
		{
             if (elements == 1)
             {
				return IS_TRUE(maxmath.ispow2((ulong)math.abs(v.SLong0)));
             }
			else
			{
				return IS_TRUE(maxmath.ispow2((ulong)math.abs(v.SLong0)))
					&& IS_TRUE(maxmath.ispow2((ulong)math.abs(v.SLong1)));
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_POW2_EPU8(v256 v)
		{
			return IS_TRUE(maxmath.ispow2(v.Byte0 ))
				&& IS_TRUE(maxmath.ispow2(v.Byte1 ))
				&& IS_TRUE(maxmath.ispow2(v.Byte2 ))
				&& IS_TRUE(maxmath.ispow2(v.Byte3 ))
				&& IS_TRUE(maxmath.ispow2(v.Byte4 ))
				&& IS_TRUE(maxmath.ispow2(v.Byte5 ))
				&& IS_TRUE(maxmath.ispow2(v.Byte6 ))
				&& IS_TRUE(maxmath.ispow2(v.Byte7 ))
				&& IS_TRUE(maxmath.ispow2(v.Byte8 ))
				&& IS_TRUE(maxmath.ispow2(v.Byte9 ))
				&& IS_TRUE(maxmath.ispow2(v.Byte10))
				&& IS_TRUE(maxmath.ispow2(v.Byte11))
				&& IS_TRUE(maxmath.ispow2(v.Byte12))
				&& IS_TRUE(maxmath.ispow2(v.Byte13))
				&& IS_TRUE(maxmath.ispow2(v.Byte14))
				&& IS_TRUE(maxmath.ispow2(v.Byte15))
			    && IS_TRUE(maxmath.ispow2(v.Byte16))
				&& IS_TRUE(maxmath.ispow2(v.Byte17))
				&& IS_TRUE(maxmath.ispow2(v.Byte18))
				&& IS_TRUE(maxmath.ispow2(v.Byte19))
				&& IS_TRUE(maxmath.ispow2(v.Byte20))
				&& IS_TRUE(maxmath.ispow2(v.Byte21))
				&& IS_TRUE(maxmath.ispow2(v.Byte22))
				&& IS_TRUE(maxmath.ispow2(v.Byte23))
				&& IS_TRUE(maxmath.ispow2(v.Byte24))
				&& IS_TRUE(maxmath.ispow2(v.Byte25))
				&& IS_TRUE(maxmath.ispow2(v.Byte26))
				&& IS_TRUE(maxmath.ispow2(v.Byte27))
				&& IS_TRUE(maxmath.ispow2(v.Byte28))
				&& IS_TRUE(maxmath.ispow2(v.Byte29))
				&& IS_TRUE(maxmath.ispow2(v.Byte30))
				&& IS_TRUE(maxmath.ispow2(v.Byte31));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_POW2_EPU16(v256 v)
		{
			return IS_TRUE(maxmath.ispow2(v.UShort0 ))
				&& IS_TRUE(maxmath.ispow2(v.UShort1 ))
				&& IS_TRUE(maxmath.ispow2(v.UShort2 ))
				&& IS_TRUE(maxmath.ispow2(v.UShort3 ))
				&& IS_TRUE(maxmath.ispow2(v.UShort4 ))
				&& IS_TRUE(maxmath.ispow2(v.UShort5 ))
				&& IS_TRUE(maxmath.ispow2(v.UShort6 ))
				&& IS_TRUE(maxmath.ispow2(v.UShort7 ))
				&& IS_TRUE(maxmath.ispow2(v.UShort8 ))
				&& IS_TRUE(maxmath.ispow2(v.UShort9 ))
				&& IS_TRUE(maxmath.ispow2(v.UShort10))
				&& IS_TRUE(maxmath.ispow2(v.UShort11))
				&& IS_TRUE(maxmath.ispow2(v.UShort12))
				&& IS_TRUE(maxmath.ispow2(v.UShort13))
				&& IS_TRUE(maxmath.ispow2(v.UShort14))
				&& IS_TRUE(maxmath.ispow2(v.UShort15));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_POW2_EPU32(v256 v)
		{
			return IS_TRUE(math.ispow2(v.UInt0))
				&& IS_TRUE(math.ispow2(v.UInt1))
				&& IS_TRUE(math.ispow2(v.UInt2))
				&& IS_TRUE(math.ispow2(v.UInt3))
				&& IS_TRUE(math.ispow2(v.UInt4))
				&& IS_TRUE(math.ispow2(v.UInt5))
				&& IS_TRUE(math.ispow2(v.UInt6))
				&& IS_TRUE(math.ispow2(v.UInt7));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_POW2_EPU64(v256 v, byte elements = 4)
		{
			if (elements == 3)
			{
				return IS_TRUE(maxmath.ispow2(v.ULong0))
					&& IS_TRUE(maxmath.ispow2(v.ULong1))
					&& IS_TRUE(maxmath.ispow2(v.ULong2));
			}
			else
			{
				return IS_TRUE(maxmath.ispow2(v.ULong0))
					&& IS_TRUE(maxmath.ispow2(v.ULong1))
					&& IS_TRUE(maxmath.ispow2(v.ULong2))
					&& IS_TRUE(maxmath.ispow2(v.ULong3));
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_POW2_EPI8(v256 v)
		{
			return IS_TRUE(maxmath.ispow2((byte)maxmath.abs(v.SByte0 )))
				&& IS_TRUE(maxmath.ispow2((byte)maxmath.abs(v.SByte1 )))
				&& IS_TRUE(maxmath.ispow2((byte)maxmath.abs(v.SByte2 )))
				&& IS_TRUE(maxmath.ispow2((byte)maxmath.abs(v.SByte3 )))
				&& IS_TRUE(maxmath.ispow2((byte)maxmath.abs(v.SByte4 )))
				&& IS_TRUE(maxmath.ispow2((byte)maxmath.abs(v.SByte5 )))
				&& IS_TRUE(maxmath.ispow2((byte)maxmath.abs(v.SByte6 )))
				&& IS_TRUE(maxmath.ispow2((byte)maxmath.abs(v.SByte7 )))
				&& IS_TRUE(maxmath.ispow2((byte)maxmath.abs(v.SByte8 )))
				&& IS_TRUE(maxmath.ispow2((byte)maxmath.abs(v.SByte9 )))
				&& IS_TRUE(maxmath.ispow2((byte)maxmath.abs(v.SByte10)))
				&& IS_TRUE(maxmath.ispow2((byte)maxmath.abs(v.SByte11)))
				&& IS_TRUE(maxmath.ispow2((byte)maxmath.abs(v.SByte12)))
				&& IS_TRUE(maxmath.ispow2((byte)maxmath.abs(v.SByte13)))
				&& IS_TRUE(maxmath.ispow2((byte)maxmath.abs(v.SByte14)))
				&& IS_TRUE(maxmath.ispow2((byte)maxmath.abs(v.SByte15)))
			    && IS_TRUE(maxmath.ispow2((byte)maxmath.abs(v.SByte16)))
				&& IS_TRUE(maxmath.ispow2((byte)maxmath.abs(v.SByte17)))
				&& IS_TRUE(maxmath.ispow2((byte)maxmath.abs(v.SByte18)))
				&& IS_TRUE(maxmath.ispow2((byte)maxmath.abs(v.SByte19)))
				&& IS_TRUE(maxmath.ispow2((byte)maxmath.abs(v.SByte20)))
				&& IS_TRUE(maxmath.ispow2((byte)maxmath.abs(v.SByte21)))
				&& IS_TRUE(maxmath.ispow2((byte)maxmath.abs(v.SByte22)))
				&& IS_TRUE(maxmath.ispow2((byte)maxmath.abs(v.SByte23)))
				&& IS_TRUE(maxmath.ispow2((byte)maxmath.abs(v.SByte24)))
				&& IS_TRUE(maxmath.ispow2((byte)maxmath.abs(v.SByte25)))
				&& IS_TRUE(maxmath.ispow2((byte)maxmath.abs(v.SByte26)))
				&& IS_TRUE(maxmath.ispow2((byte)maxmath.abs(v.SByte27)))
				&& IS_TRUE(maxmath.ispow2((byte)maxmath.abs(v.SByte28)))
				&& IS_TRUE(maxmath.ispow2((byte)maxmath.abs(v.SByte29)))
				&& IS_TRUE(maxmath.ispow2((byte)maxmath.abs(v.SByte30)))
				&& IS_TRUE(maxmath.ispow2((byte)maxmath.abs(v.SByte31)));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_POW2_EPI16(v256 v)
		{
			return IS_TRUE(maxmath.ispow2((ushort)maxmath.abs(v.SShort0 )))
				&& IS_TRUE(maxmath.ispow2((ushort)maxmath.abs(v.SShort1 )))
				&& IS_TRUE(maxmath.ispow2((ushort)maxmath.abs(v.SShort2 )))
				&& IS_TRUE(maxmath.ispow2((ushort)maxmath.abs(v.SShort3 )))
				&& IS_TRUE(maxmath.ispow2((ushort)maxmath.abs(v.SShort4 )))
				&& IS_TRUE(maxmath.ispow2((ushort)maxmath.abs(v.SShort5 )))
				&& IS_TRUE(maxmath.ispow2((ushort)maxmath.abs(v.SShort6 )))
				&& IS_TRUE(maxmath.ispow2((ushort)maxmath.abs(v.SShort7 )))
				&& IS_TRUE(maxmath.ispow2((ushort)maxmath.abs(v.SShort8 )))
				&& IS_TRUE(maxmath.ispow2((ushort)maxmath.abs(v.SShort9 )))
				&& IS_TRUE(maxmath.ispow2((ushort)maxmath.abs(v.SShort10)))
				&& IS_TRUE(maxmath.ispow2((ushort)maxmath.abs(v.SShort11)))
				&& IS_TRUE(maxmath.ispow2((ushort)maxmath.abs(v.SShort12)))
				&& IS_TRUE(maxmath.ispow2((ushort)maxmath.abs(v.SShort13)))
				&& IS_TRUE(maxmath.ispow2((ushort)maxmath.abs(v.SShort14)))
				&& IS_TRUE(maxmath.ispow2((ushort)maxmath.abs(v.SShort15)));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_POW2_EPI32(v256 v)
		{
			return IS_TRUE(math.ispow2((uint)math.abs(v.SInt0)))
				&& IS_TRUE(math.ispow2((uint)math.abs(v.SInt1)))
				&& IS_TRUE(math.ispow2((uint)math.abs(v.SInt2)))
				&& IS_TRUE(math.ispow2((uint)math.abs(v.SInt3)))
				&& IS_TRUE(math.ispow2((uint)math.abs(v.SInt4)))
				&& IS_TRUE(math.ispow2((uint)math.abs(v.SInt5)))
				&& IS_TRUE(math.ispow2((uint)math.abs(v.SInt6)))
				&& IS_TRUE(math.ispow2((uint)math.abs(v.SInt7)));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_POW2_EPI64(v256 v, byte elements = 4)
		{
			if (elements == 3)
			{
				return IS_TRUE(maxmath.ispow2((ulong)math.abs(v.SLong0)))
					&& IS_TRUE(maxmath.ispow2((ulong)math.abs(v.SLong1)))
					&& IS_TRUE(maxmath.ispow2((ulong)math.abs(v.SLong2)));
			}
			else
			{
				return IS_TRUE(maxmath.ispow2((ulong)math.abs(v.SLong0)))
					&& IS_TRUE(maxmath.ispow2((ulong)math.abs(v.SLong1)))
					&& IS_TRUE(maxmath.ispow2((ulong)math.abs(v.SLong2)))
					&& IS_TRUE(maxmath.ispow2((ulong)math.abs(v.SLong3)));
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_POW2_EPU128(v256 vLo, v256 vHi, byte elements = 4)
		{
			if (elements == 3)
			{
				return IS_TRUE(maxmath.ispow2(new UInt128(vLo.ULong0, vHi.ULong0)))
					&& IS_TRUE(maxmath.ispow2(new UInt128(vLo.ULong1, vHi.ULong1)))
					&& IS_TRUE(maxmath.ispow2(new UInt128(vLo.ULong2, vHi.ULong2)));
			}
			else
			{
				return IS_TRUE(maxmath.ispow2(new UInt128(vLo.ULong0, vHi.ULong0)))
					&& IS_TRUE(maxmath.ispow2(new UInt128(vLo.ULong1, vHi.ULong1)))
					&& IS_TRUE(maxmath.ispow2(new UInt128(vLo.ULong2, vHi.ULong2)))
					&& IS_TRUE(maxmath.ispow2(new UInt128(vLo.ULong3, vHi.ULong3)));
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool NONE_POW2_EPU8(v128 v, byte elements = 16)
		{
			switch (elements)
			{
				case  1: return IS_FALSE(maxmath.ispow2(v.Byte0 ));

				case  2: return IS_FALSE(maxmath.ispow2(v.Byte0 ))
							 && IS_FALSE(maxmath.ispow2(v.Byte1 ));

				case  3: return IS_FALSE(maxmath.ispow2(v.Byte0 ))
							 && IS_FALSE(maxmath.ispow2(v.Byte1 ))
							 && IS_FALSE(maxmath.ispow2(v.Byte2 ));

				case  4: return IS_FALSE(maxmath.ispow2(v.Byte0 ))
							 && IS_FALSE(maxmath.ispow2(v.Byte1 ))
							 && IS_FALSE(maxmath.ispow2(v.Byte2 ))
							 && IS_FALSE(maxmath.ispow2(v.Byte3 ));

				case  8: return IS_FALSE(maxmath.ispow2(v.Byte0 ))
							 && IS_FALSE(maxmath.ispow2(v.Byte1 ))
							 && IS_FALSE(maxmath.ispow2(v.Byte2 ))
							 && IS_FALSE(maxmath.ispow2(v.Byte3 ))
							 && IS_FALSE(maxmath.ispow2(v.Byte4 ))
							 && IS_FALSE(maxmath.ispow2(v.Byte5 ))
							 && IS_FALSE(maxmath.ispow2(v.Byte6 ))
							 && IS_FALSE(maxmath.ispow2(v.Byte7 ));

				default: return IS_FALSE(maxmath.ispow2(v.Byte0 ))
							 && IS_FALSE(maxmath.ispow2(v.Byte1 ))
							 && IS_FALSE(maxmath.ispow2(v.Byte2 ))
							 && IS_FALSE(maxmath.ispow2(v.Byte3 ))
							 && IS_FALSE(maxmath.ispow2(v.Byte4 ))
							 && IS_FALSE(maxmath.ispow2(v.Byte5 ))
							 && IS_FALSE(maxmath.ispow2(v.Byte6 ))
							 && IS_FALSE(maxmath.ispow2(v.Byte7 ))
							 && IS_FALSE(maxmath.ispow2(v.Byte8 ))
							 && IS_FALSE(maxmath.ispow2(v.Byte9 ))
							 && IS_FALSE(maxmath.ispow2(v.Byte10))
							 && IS_FALSE(maxmath.ispow2(v.Byte11))
							 && IS_FALSE(maxmath.ispow2(v.Byte12))
							 && IS_FALSE(maxmath.ispow2(v.Byte13))
							 && IS_FALSE(maxmath.ispow2(v.Byte14))
							 && IS_FALSE(maxmath.ispow2(v.Byte15));
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool NONE_POW2_EPU16(v128 v, byte elements = 8)
		{
			switch (elements)
			{
				case  1: return IS_FALSE(maxmath.ispow2(v.UShort0));

				case  2: return IS_FALSE(maxmath.ispow2(v.UShort0))
							 && IS_FALSE(maxmath.ispow2(v.UShort1));

				case  3: return IS_FALSE(maxmath.ispow2(v.UShort0))
							 && IS_FALSE(maxmath.ispow2(v.UShort1))
							 && IS_FALSE(maxmath.ispow2(v.UShort2));

				case  4: return IS_FALSE(maxmath.ispow2(v.UShort0))
							 && IS_FALSE(maxmath.ispow2(v.UShort1))
							 && IS_FALSE(maxmath.ispow2(v.UShort2))
							 && IS_FALSE(maxmath.ispow2(v.UShort3));

				default: return IS_FALSE(maxmath.ispow2(v.UShort0))
							 && IS_FALSE(maxmath.ispow2(v.UShort1))
							 && IS_FALSE(maxmath.ispow2(v.UShort2))
							 && IS_FALSE(maxmath.ispow2(v.UShort3))
							 && IS_FALSE(maxmath.ispow2(v.UShort4))
							 && IS_FALSE(maxmath.ispow2(v.UShort5))
							 && IS_FALSE(maxmath.ispow2(v.UShort6))
							 && IS_FALSE(maxmath.ispow2(v.UShort7));
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool NONE_POW2_EPU32(v128 v, byte elements = 4)
		{
			switch (elements)
			{
				case  1: return IS_FALSE(math.ispow2(v.UInt0));

				case  2: return IS_FALSE(math.ispow2(v.UInt0))
							 && IS_FALSE(math.ispow2(v.UInt1));

				case  3: return IS_FALSE(math.ispow2(v.UInt0))
							 && IS_FALSE(math.ispow2(v.UInt1))
							 && IS_FALSE(math.ispow2(v.UInt2));

				default: return IS_FALSE(math.ispow2(v.UInt0))
							 && IS_FALSE(math.ispow2(v.UInt1))
							 && IS_FALSE(math.ispow2(v.UInt2))
							 && IS_FALSE(math.ispow2(v.UInt3));
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool NONE_POW2_EPU64(v128 v, byte elements = 2)
		{
             if (elements == 1)
             {
				return IS_FALSE(maxmath.ispow2(v.ULong0));
             }
			else
			{
				return IS_FALSE(maxmath.ispow2(v.ULong0))
					&& IS_FALSE(maxmath.ispow2(v.ULong1));
			}
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool NONE_POW2_EPI8(v128 v, byte elements = 16)
		{
			switch (elements)
			{
				case  1: return IS_FALSE(maxmath.ispow2((byte)maxmath.abs(v.SByte0 )));

				case  2: return IS_FALSE(maxmath.ispow2((byte)maxmath.abs(v.SByte0 )))
							 && IS_FALSE(maxmath.ispow2((byte)maxmath.abs(v.SByte1 )));

				case  3: return IS_FALSE(maxmath.ispow2((byte)maxmath.abs(v.SByte0 )))
							 && IS_FALSE(maxmath.ispow2((byte)maxmath.abs(v.SByte1 )))
							 && IS_FALSE(maxmath.ispow2((byte)maxmath.abs(v.SByte2 )));

				case  4: return IS_FALSE(maxmath.ispow2((byte)maxmath.abs(v.SByte0 )))
							 && IS_FALSE(maxmath.ispow2((byte)maxmath.abs(v.SByte1 )))
							 && IS_FALSE(maxmath.ispow2((byte)maxmath.abs(v.SByte2 )))
							 && IS_FALSE(maxmath.ispow2((byte)maxmath.abs(v.SByte3 )));

				case  8: return IS_FALSE(maxmath.ispow2((byte)maxmath.abs(v.SByte0 )))
							 && IS_FALSE(maxmath.ispow2((byte)maxmath.abs(v.SByte1 )))
							 && IS_FALSE(maxmath.ispow2((byte)maxmath.abs(v.SByte2 )))
							 && IS_FALSE(maxmath.ispow2((byte)maxmath.abs(v.SByte3 )))
							 && IS_FALSE(maxmath.ispow2((byte)maxmath.abs(v.SByte4 )))
							 && IS_FALSE(maxmath.ispow2((byte)maxmath.abs(v.SByte5 )))
							 && IS_FALSE(maxmath.ispow2((byte)maxmath.abs(v.SByte6 )))
							 && IS_FALSE(maxmath.ispow2((byte)maxmath.abs(v.SByte7 )));

				default: return IS_FALSE(maxmath.ispow2((byte)maxmath.abs(v.SByte0 )))
							 && IS_FALSE(maxmath.ispow2((byte)maxmath.abs(v.SByte1 )))
							 && IS_FALSE(maxmath.ispow2((byte)maxmath.abs(v.SByte2 )))
							 && IS_FALSE(maxmath.ispow2((byte)maxmath.abs(v.SByte3 )))
							 && IS_FALSE(maxmath.ispow2((byte)maxmath.abs(v.SByte4 )))
							 && IS_FALSE(maxmath.ispow2((byte)maxmath.abs(v.SByte5 )))
							 && IS_FALSE(maxmath.ispow2((byte)maxmath.abs(v.SByte6 )))
							 && IS_FALSE(maxmath.ispow2((byte)maxmath.abs(v.SByte7 )))
							 && IS_FALSE(maxmath.ispow2((byte)maxmath.abs(v.SByte8 )))
							 && IS_FALSE(maxmath.ispow2((byte)maxmath.abs(v.SByte9 )))
							 && IS_FALSE(maxmath.ispow2((byte)maxmath.abs(v.SByte10)))
							 && IS_FALSE(maxmath.ispow2((byte)maxmath.abs(v.SByte11)))
							 && IS_FALSE(maxmath.ispow2((byte)maxmath.abs(v.SByte12)))
							 && IS_FALSE(maxmath.ispow2((byte)maxmath.abs(v.SByte13)))
							 && IS_FALSE(maxmath.ispow2((byte)maxmath.abs(v.SByte14)))
							 && IS_FALSE(maxmath.ispow2((byte)maxmath.abs(v.SByte15)));
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool NONE_POW2_EPI16(v128 v, byte elements = 8)
		{
			switch (elements)
			{
				case  1: return IS_FALSE(maxmath.ispow2((ushort)maxmath.abs(v.SShort0)));

				case  2: return IS_FALSE(maxmath.ispow2((ushort)maxmath.abs(v.SShort0)))
							 && IS_FALSE(maxmath.ispow2((ushort)maxmath.abs(v.SShort1)));

				case  3: return IS_FALSE(maxmath.ispow2((ushort)maxmath.abs(v.SShort0)))
							 && IS_FALSE(maxmath.ispow2((ushort)maxmath.abs(v.SShort1)))
							 && IS_FALSE(maxmath.ispow2((ushort)maxmath.abs(v.SShort2)));

				case  4: return IS_FALSE(maxmath.ispow2((ushort)maxmath.abs(v.SShort0)))
							 && IS_FALSE(maxmath.ispow2((ushort)maxmath.abs(v.SShort1)))
							 && IS_FALSE(maxmath.ispow2((ushort)maxmath.abs(v.SShort2)))
							 && IS_FALSE(maxmath.ispow2((ushort)maxmath.abs(v.SShort3)));

				default: return IS_FALSE(maxmath.ispow2((ushort)maxmath.abs(v.SShort0)))
							 && IS_FALSE(maxmath.ispow2((ushort)maxmath.abs(v.SShort1)))
							 && IS_FALSE(maxmath.ispow2((ushort)maxmath.abs(v.SShort2)))
							 && IS_FALSE(maxmath.ispow2((ushort)maxmath.abs(v.SShort3)))
							 && IS_FALSE(maxmath.ispow2((ushort)maxmath.abs(v.SShort4)))
							 && IS_FALSE(maxmath.ispow2((ushort)maxmath.abs(v.SShort5)))
							 && IS_FALSE(maxmath.ispow2((ushort)maxmath.abs(v.SShort6)))
							 && IS_FALSE(maxmath.ispow2((ushort)maxmath.abs(v.SShort7)));
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool NONE_POW2_EPI32(v128 v, byte elements = 4)
		{
			switch (elements)
			{
				case  1: return IS_FALSE(math.ispow2((uint)math.abs(v.SInt0)));

				case  2: return IS_FALSE(math.ispow2((uint)math.abs(v.SInt0)))
							 && IS_FALSE(math.ispow2((uint)math.abs(v.SInt1)));

				case  3: return IS_FALSE(math.ispow2((uint)math.abs(v.SInt0)))
							 && IS_FALSE(math.ispow2((uint)math.abs(v.SInt1)))
							 && IS_FALSE(math.ispow2((uint)math.abs(v.SInt2)));

				default: return IS_FALSE(math.ispow2((uint)math.abs(v.SInt0)))
							 && IS_FALSE(math.ispow2((uint)math.abs(v.SInt1)))
							 && IS_FALSE(math.ispow2((uint)math.abs(v.SInt2)))
							 && IS_FALSE(math.ispow2((uint)math.abs(v.SInt3)));
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool NONE_POW2_EPI64(v128 v, byte elements = 2)
		{
             if (elements == 1)
             {
				return IS_FALSE(maxmath.ispow2((ulong)math.abs(v.SLong0)));
             }
			else
			{
				return IS_FALSE(maxmath.ispow2((ulong)math.abs(v.SLong0)))
					&& IS_FALSE(maxmath.ispow2((ulong)math.abs(v.SLong1)));
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool NONE_POW2_EPU128(v128 vLo, v128 vHi)
		{
			return IS_FALSE(maxmath.ispow2(new UInt128(vLo.ULong0, vHi.ULong0)))
				&& IS_FALSE(maxmath.ispow2(new UInt128(vLo.ULong1, vHi.ULong1)));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool NONE_POW2_EPU8(v256 v)
		{
			return IS_FALSE(maxmath.ispow2(v.Byte0 ))
				&& IS_FALSE(maxmath.ispow2(v.Byte1 ))
				&& IS_FALSE(maxmath.ispow2(v.Byte2 ))
				&& IS_FALSE(maxmath.ispow2(v.Byte3 ))
				&& IS_FALSE(maxmath.ispow2(v.Byte4 ))
				&& IS_FALSE(maxmath.ispow2(v.Byte5 ))
				&& IS_FALSE(maxmath.ispow2(v.Byte6 ))
				&& IS_FALSE(maxmath.ispow2(v.Byte7 ))
				&& IS_FALSE(maxmath.ispow2(v.Byte8 ))
				&& IS_FALSE(maxmath.ispow2(v.Byte9 ))
				&& IS_FALSE(maxmath.ispow2(v.Byte10))
				&& IS_FALSE(maxmath.ispow2(v.Byte11))
				&& IS_FALSE(maxmath.ispow2(v.Byte12))
				&& IS_FALSE(maxmath.ispow2(v.Byte13))
				&& IS_FALSE(maxmath.ispow2(v.Byte14))
				&& IS_FALSE(maxmath.ispow2(v.Byte15))
			    && IS_FALSE(maxmath.ispow2(v.Byte16))
				&& IS_FALSE(maxmath.ispow2(v.Byte17))
				&& IS_FALSE(maxmath.ispow2(v.Byte18))
				&& IS_FALSE(maxmath.ispow2(v.Byte19))
				&& IS_FALSE(maxmath.ispow2(v.Byte20))
				&& IS_FALSE(maxmath.ispow2(v.Byte21))
				&& IS_FALSE(maxmath.ispow2(v.Byte22))
				&& IS_FALSE(maxmath.ispow2(v.Byte23))
				&& IS_FALSE(maxmath.ispow2(v.Byte24))
				&& IS_FALSE(maxmath.ispow2(v.Byte25))
				&& IS_FALSE(maxmath.ispow2(v.Byte26))
				&& IS_FALSE(maxmath.ispow2(v.Byte27))
				&& IS_FALSE(maxmath.ispow2(v.Byte28))
				&& IS_FALSE(maxmath.ispow2(v.Byte29))
				&& IS_FALSE(maxmath.ispow2(v.Byte30))
				&& IS_FALSE(maxmath.ispow2(v.Byte31));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool NONE_POW2_EPU16(v256 v)
		{
			return IS_FALSE(maxmath.ispow2(v.UShort0 ))
				&& IS_FALSE(maxmath.ispow2(v.UShort1 ))
				&& IS_FALSE(maxmath.ispow2(v.UShort2 ))
				&& IS_FALSE(maxmath.ispow2(v.UShort3 ))
				&& IS_FALSE(maxmath.ispow2(v.UShort4 ))
				&& IS_FALSE(maxmath.ispow2(v.UShort5 ))
				&& IS_FALSE(maxmath.ispow2(v.UShort6 ))
				&& IS_FALSE(maxmath.ispow2(v.UShort7 ))
				&& IS_FALSE(maxmath.ispow2(v.UShort8 ))
				&& IS_FALSE(maxmath.ispow2(v.UShort9 ))
				&& IS_FALSE(maxmath.ispow2(v.UShort10))
				&& IS_FALSE(maxmath.ispow2(v.UShort11))
				&& IS_FALSE(maxmath.ispow2(v.UShort12))
				&& IS_FALSE(maxmath.ispow2(v.UShort13))
				&& IS_FALSE(maxmath.ispow2(v.UShort14))
				&& IS_FALSE(maxmath.ispow2(v.UShort15));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool NONE_POW2_EPU32(v256 v)
		{
			return IS_FALSE(math.ispow2(v.UInt0))
				&& IS_FALSE(math.ispow2(v.UInt1))
				&& IS_FALSE(math.ispow2(v.UInt2))
				&& IS_FALSE(math.ispow2(v.UInt3))
				&& IS_FALSE(math.ispow2(v.UInt4))
				&& IS_FALSE(math.ispow2(v.UInt5))
				&& IS_FALSE(math.ispow2(v.UInt6))
				&& IS_FALSE(math.ispow2(v.UInt7));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool NONE_POW2_EPU64(v256 v, byte elements = 4)
		{
			if (elements == 3)
			{
				return IS_FALSE(maxmath.ispow2(v.ULong0))
					&& IS_FALSE(maxmath.ispow2(v.ULong1))
					&& IS_FALSE(maxmath.ispow2(v.ULong2));
			}
			else
			{
				return IS_FALSE(maxmath.ispow2(v.ULong0))
					&& IS_FALSE(maxmath.ispow2(v.ULong1))
					&& IS_FALSE(maxmath.ispow2(v.ULong2))
					&& IS_FALSE(maxmath.ispow2(v.ULong3));
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool NONE_POW2_EPU128(v256 vLo, v256 vHi, byte elements = 4)
		{
			if (elements == 3)
			{
				return IS_FALSE(maxmath.ispow2(new UInt128(vLo.ULong0, vHi.ULong0)))
					&& IS_FALSE(maxmath.ispow2(new UInt128(vLo.ULong1, vHi.ULong1)))
					&& IS_FALSE(maxmath.ispow2(new UInt128(vLo.ULong2, vHi.ULong2)));
			}
			else
			{
				return IS_FALSE(maxmath.ispow2(new UInt128(vLo.ULong0, vHi.ULong0)))
					&& IS_FALSE(maxmath.ispow2(new UInt128(vLo.ULong1, vHi.ULong1)))
					&& IS_FALSE(maxmath.ispow2(new UInt128(vLo.ULong2, vHi.ULong2)))
					&& IS_FALSE(maxmath.ispow2(new UInt128(vLo.ULong3, vHi.ULong3)));
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool NONE_POW2_EPI8(v256 v)
		{
			return IS_FALSE(maxmath.ispow2((byte)maxmath.abs(v.SByte0 )))
				&& IS_FALSE(maxmath.ispow2((byte)maxmath.abs(v.SByte1 )))
				&& IS_FALSE(maxmath.ispow2((byte)maxmath.abs(v.SByte2 )))
				&& IS_FALSE(maxmath.ispow2((byte)maxmath.abs(v.SByte3 )))
				&& IS_FALSE(maxmath.ispow2((byte)maxmath.abs(v.SByte4 )))
				&& IS_FALSE(maxmath.ispow2((byte)maxmath.abs(v.SByte5 )))
				&& IS_FALSE(maxmath.ispow2((byte)maxmath.abs(v.SByte6 )))
				&& IS_FALSE(maxmath.ispow2((byte)maxmath.abs(v.SByte7 )))
				&& IS_FALSE(maxmath.ispow2((byte)maxmath.abs(v.SByte8 )))
				&& IS_FALSE(maxmath.ispow2((byte)maxmath.abs(v.SByte9 )))
				&& IS_FALSE(maxmath.ispow2((byte)maxmath.abs(v.SByte10)))
				&& IS_FALSE(maxmath.ispow2((byte)maxmath.abs(v.SByte11)))
				&& IS_FALSE(maxmath.ispow2((byte)maxmath.abs(v.SByte12)))
				&& IS_FALSE(maxmath.ispow2((byte)maxmath.abs(v.SByte13)))
				&& IS_FALSE(maxmath.ispow2((byte)maxmath.abs(v.SByte14)))
				&& IS_FALSE(maxmath.ispow2((byte)maxmath.abs(v.SByte15)))
			    && IS_FALSE(maxmath.ispow2((byte)maxmath.abs(v.SByte16)))
				&& IS_FALSE(maxmath.ispow2((byte)maxmath.abs(v.SByte17)))
				&& IS_FALSE(maxmath.ispow2((byte)maxmath.abs(v.SByte18)))
				&& IS_FALSE(maxmath.ispow2((byte)maxmath.abs(v.SByte19)))
				&& IS_FALSE(maxmath.ispow2((byte)maxmath.abs(v.SByte20)))
				&& IS_FALSE(maxmath.ispow2((byte)maxmath.abs(v.SByte21)))
				&& IS_FALSE(maxmath.ispow2((byte)maxmath.abs(v.SByte22)))
				&& IS_FALSE(maxmath.ispow2((byte)maxmath.abs(v.SByte23)))
				&& IS_FALSE(maxmath.ispow2((byte)maxmath.abs(v.SByte24)))
				&& IS_FALSE(maxmath.ispow2((byte)maxmath.abs(v.SByte25)))
				&& IS_FALSE(maxmath.ispow2((byte)maxmath.abs(v.SByte26)))
				&& IS_FALSE(maxmath.ispow2((byte)maxmath.abs(v.SByte27)))
				&& IS_FALSE(maxmath.ispow2((byte)maxmath.abs(v.SByte28)))
				&& IS_FALSE(maxmath.ispow2((byte)maxmath.abs(v.SByte29)))
				&& IS_FALSE(maxmath.ispow2((byte)maxmath.abs(v.SByte30)))
				&& IS_FALSE(maxmath.ispow2((byte)maxmath.abs(v.SByte31)));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool NONE_POW2_EPI16(v256 v)
		{
			return IS_FALSE(maxmath.ispow2((ushort)maxmath.abs(v.SShort0 )))
				&& IS_FALSE(maxmath.ispow2((ushort)maxmath.abs(v.SShort1 )))
				&& IS_FALSE(maxmath.ispow2((ushort)maxmath.abs(v.SShort2 )))
				&& IS_FALSE(maxmath.ispow2((ushort)maxmath.abs(v.SShort3 )))
				&& IS_FALSE(maxmath.ispow2((ushort)maxmath.abs(v.SShort4 )))
				&& IS_FALSE(maxmath.ispow2((ushort)maxmath.abs(v.SShort5 )))
				&& IS_FALSE(maxmath.ispow2((ushort)maxmath.abs(v.SShort6 )))
				&& IS_FALSE(maxmath.ispow2((ushort)maxmath.abs(v.SShort7 )))
				&& IS_FALSE(maxmath.ispow2((ushort)maxmath.abs(v.SShort8 )))
				&& IS_FALSE(maxmath.ispow2((ushort)maxmath.abs(v.SShort9 )))
				&& IS_FALSE(maxmath.ispow2((ushort)maxmath.abs(v.SShort10)))
				&& IS_FALSE(maxmath.ispow2((ushort)maxmath.abs(v.SShort11)))
				&& IS_FALSE(maxmath.ispow2((ushort)maxmath.abs(v.SShort12)))
				&& IS_FALSE(maxmath.ispow2((ushort)maxmath.abs(v.SShort13)))
				&& IS_FALSE(maxmath.ispow2((ushort)maxmath.abs(v.SShort14)))
				&& IS_FALSE(maxmath.ispow2((ushort)maxmath.abs(v.SShort15)));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool NONE_POW2_EPI32(v256 v)
		{
			return IS_FALSE(math.ispow2((uint)math.abs(v.SInt0)))
				&& IS_FALSE(math.ispow2((uint)math.abs(v.SInt1)))
				&& IS_FALSE(math.ispow2((uint)math.abs(v.SInt2)))
				&& IS_FALSE(math.ispow2((uint)math.abs(v.SInt3)))
				&& IS_FALSE(math.ispow2((uint)math.abs(v.SInt4)))
				&& IS_FALSE(math.ispow2((uint)math.abs(v.SInt5)))
				&& IS_FALSE(math.ispow2((uint)math.abs(v.SInt6)))
				&& IS_FALSE(math.ispow2((uint)math.abs(v.SInt7)));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool NONE_POW2_EPI64(v256 v, byte elements = 4)
		{
			if (elements == 3)
			{
				return IS_FALSE(maxmath.ispow2((ulong)math.abs(v.SLong0)))
					&& IS_FALSE(maxmath.ispow2((ulong)math.abs(v.SLong1)))
					&& IS_FALSE(maxmath.ispow2((ulong)math.abs(v.SLong2)));
			}
			else
			{
				return IS_FALSE(maxmath.ispow2((ulong)math.abs(v.SLong0)))
					&& IS_FALSE(maxmath.ispow2((ulong)math.abs(v.SLong1)))
					&& IS_FALSE(maxmath.ispow2((ulong)math.abs(v.SLong2)))
					&& IS_FALSE(maxmath.ispow2((ulong)math.abs(v.SLong3)));
			}
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_EQ_EPU8(v128 a, v128 b, byte elements = 16)
		{
			switch (elements)
			{
				case  2: return IS_TRUE(a.Byte0  == b.Byte0)
							 && IS_TRUE(a.Byte1  == b.Byte1);

				case  3: return IS_TRUE(a.Byte0  == b.Byte0)
							 && IS_TRUE(a.Byte1  == b.Byte1)
							 && IS_TRUE(a.Byte2  == b.Byte2);

				case  4: return IS_TRUE(a.Byte0  == b.Byte0)
							 && IS_TRUE(a.Byte1  == b.Byte1)
							 && IS_TRUE(a.Byte2  == b.Byte2)
							 && IS_TRUE(a.Byte3  == b.Byte3);

				case  8: return IS_TRUE(a.Byte0  == b.Byte0)
							 && IS_TRUE(a.Byte1  == b.Byte1)
							 && IS_TRUE(a.Byte2  == b.Byte2)
							 && IS_TRUE(a.Byte3  == b.Byte3)
							 && IS_TRUE(a.Byte4  == b.Byte4)
							 && IS_TRUE(a.Byte5  == b.Byte5)
							 && IS_TRUE(a.Byte6  == b.Byte6)
							 && IS_TRUE(a.Byte7  == b.Byte7);

				default: return IS_TRUE(a.Byte0  == b.Byte0)
							 && IS_TRUE(a.Byte1  == b.Byte1)
							 && IS_TRUE(a.Byte2  == b.Byte2)
							 && IS_TRUE(a.Byte3  == b.Byte3)
							 && IS_TRUE(a.Byte4  == b.Byte4)
							 && IS_TRUE(a.Byte5  == b.Byte5)
							 && IS_TRUE(a.Byte6  == b.Byte6)
							 && IS_TRUE(a.Byte7  == b.Byte7)
							 && IS_TRUE(a.Byte8  == b.Byte8)
							 && IS_TRUE(a.Byte9  == b.Byte9)
							 && IS_TRUE(a.Byte10 == b.Byte10)
							 && IS_TRUE(a.Byte11 == b.Byte11)
							 && IS_TRUE(a.Byte12 == b.Byte12)
							 && IS_TRUE(a.Byte13 == b.Byte13)
							 && IS_TRUE(a.Byte14 == b.Byte14)
							 && IS_TRUE(a.Byte15 == b.Byte15);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_EQ_EPU16(v128 a, v128 b, byte elements = 8)
		{
			switch (elements)
			{
				case  2: return IS_TRUE(a.UShort0  == b.UShort0)
							 && IS_TRUE(a.UShort1  == b.UShort1);

				case  3: return IS_TRUE(a.UShort0  == b.UShort0)
							 && IS_TRUE(a.UShort1  == b.UShort1)
							 && IS_TRUE(a.UShort2  == b.UShort2);

				case  4: return IS_TRUE(a.UShort0  == b.UShort0)
							 && IS_TRUE(a.UShort1  == b.UShort1)
							 && IS_TRUE(a.UShort2  == b.UShort2)
							 && IS_TRUE(a.UShort3  == b.UShort3);

				default: return IS_TRUE(a.UShort0  == b.UShort0)
							 && IS_TRUE(a.UShort1  == b.UShort1)
							 && IS_TRUE(a.UShort2  == b.UShort2)
							 && IS_TRUE(a.UShort3  == b.UShort3)
							 && IS_TRUE(a.UShort4  == b.UShort4)
							 && IS_TRUE(a.UShort5  == b.UShort5)
							 && IS_TRUE(a.UShort6  == b.UShort6)
							 && IS_TRUE(a.UShort7  == b.UShort7);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_EQ_EPU32(v128 a, v128 b, byte elements = 4)
		{
			switch (elements)
			{
				case  2: return IS_TRUE(a.UInt0  == b.UInt0)
							 && IS_TRUE(a.UInt1  == b.UInt1);

				case  3: return IS_TRUE(a.UInt0  == b.UInt0)
							 && IS_TRUE(a.UInt1  == b.UInt1)
							 && IS_TRUE(a.UInt2  == b.UInt2);

				default: return IS_TRUE(a.UInt0  == b.UInt0)
							 && IS_TRUE(a.UInt1  == b.UInt1)
							 && IS_TRUE(a.UInt2  == b.UInt2)
							 && IS_TRUE(a.UInt3  == b.UInt3);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_EQ_EPU64(v128 a, v128 b)
		{
			return IS_TRUE(a.ULong0 == b.ULong0)
				&& IS_TRUE(a.ULong1 == b.ULong1);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_EQ_EPI8(v128 a, v128 b, byte elements = 16)
		{
			switch (elements)
			{
				case  2: return IS_TRUE(a.SByte0  == b.SByte0)
							 && IS_TRUE(a.SByte1  == b.SByte1);

				case  3: return IS_TRUE(a.SByte0  == b.SByte0)
							 && IS_TRUE(a.SByte1  == b.SByte1)
							 && IS_TRUE(a.SByte2  == b.SByte2);

				case  4: return IS_TRUE(a.SByte0  == b.SByte0)
							 && IS_TRUE(a.SByte1  == b.SByte1)
							 && IS_TRUE(a.SByte2  == b.SByte2)
							 && IS_TRUE(a.SByte3  == b.SByte3);

				case  8: return IS_TRUE(a.SByte0  == b.SByte0)
							 && IS_TRUE(a.SByte1  == b.SByte1)
							 && IS_TRUE(a.SByte2  == b.SByte2)
							 && IS_TRUE(a.SByte3  == b.SByte3)
							 && IS_TRUE(a.SByte4  == b.SByte4)
							 && IS_TRUE(a.SByte5  == b.SByte5)
							 && IS_TRUE(a.SByte6  == b.SByte6)
							 && IS_TRUE(a.SByte7  == b.SByte7);

				default: return IS_TRUE(a.SByte0  == b.SByte0)
							 && IS_TRUE(a.SByte1  == b.SByte1)
							 && IS_TRUE(a.SByte2  == b.SByte2)
							 && IS_TRUE(a.SByte3  == b.SByte3)
							 && IS_TRUE(a.SByte4  == b.SByte4)
							 && IS_TRUE(a.SByte5  == b.SByte5)
							 && IS_TRUE(a.SByte6  == b.SByte6)
							 && IS_TRUE(a.SByte7  == b.SByte7)
							 && IS_TRUE(a.SByte8  == b.SByte8)
							 && IS_TRUE(a.SByte9  == b.SByte9)
							 && IS_TRUE(a.SByte10 == b.SByte10)
							 && IS_TRUE(a.SByte11 == b.SByte11)
							 && IS_TRUE(a.SByte12 == b.SByte12)
							 && IS_TRUE(a.SByte13 == b.SByte13)
							 && IS_TRUE(a.SByte14 == b.SByte14)
							 && IS_TRUE(a.SByte15 == b.SByte15);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_EQ_EPI16(v128 a, v128 b, byte elements = 8)
		{
			switch (elements)
			{
				case  2: return IS_TRUE(a.SShort0 == b.SShort0)
							 && IS_TRUE(a.SShort1 == b.SShort1);

				case  3: return IS_TRUE(a.SShort0 == b.SShort0)
							 && IS_TRUE(a.SShort1 == b.SShort1)
							 && IS_TRUE(a.SShort2 == b.SShort2);

				case  4: return IS_TRUE(a.SShort0 == b.SShort0)
							 && IS_TRUE(a.SShort1 == b.SShort1)
							 && IS_TRUE(a.SShort2 == b.SShort2)
							 && IS_TRUE(a.SShort3 == b.SShort3);

				default: return IS_TRUE(a.SShort0 == b.SShort0)
							 && IS_TRUE(a.SShort1 == b.SShort1)
							 && IS_TRUE(a.SShort2 == b.SShort2)
							 && IS_TRUE(a.SShort3 == b.SShort3)
							 && IS_TRUE(a.SShort4 == b.SShort4)
							 && IS_TRUE(a.SShort5 == b.SShort5)
							 && IS_TRUE(a.SShort6 == b.SShort6)
							 && IS_TRUE(a.SShort7 == b.SShort7);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_EQ_EPI32(v128 a, v128 b, byte elements = 4)
		{
			switch (elements)
			{
				case  2: return IS_TRUE(a.SInt0 == b.SInt0)
							 && IS_TRUE(a.SInt1 == b.SInt1);

				case  3: return IS_TRUE(a.SInt0 == b.SInt0)
							 && IS_TRUE(a.SInt1 == b.SInt1)
							 && IS_TRUE(a.SInt2 == b.SInt2);

				default: return IS_TRUE(a.SInt0 == b.SInt0)
							 && IS_TRUE(a.SInt1 == b.SInt1)
							 && IS_TRUE(a.SInt2 == b.SInt2)
							 && IS_TRUE(a.SInt3 == b.SInt3);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_EQ_EPI64(v128 a, v128 b)
		{
			return IS_TRUE(a.SLong0 == b.SLong0)
				&& IS_TRUE(a.SLong1 == b.SLong1);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_EQ_PS(v128 a, v128 b, byte elements = 4)
		{
			switch (elements)
			{
				case  1: return IS_TRUE(a.Float0 == b.Float0);

				case  2: return IS_TRUE(a.Float0 == b.Float0)
							 && IS_TRUE(a.Float1 == b.Float1);

				case  3: return IS_TRUE(a.Float0 == b.Float0)
							 && IS_TRUE(a.Float1 == b.Float1)
							 && IS_TRUE(a.Float2 == b.Float2);

				default: return IS_TRUE(a.Float0 == b.Float0)
							 && IS_TRUE(a.Float1 == b.Float1)
							 && IS_TRUE(a.Float2 == b.Float2)
							 && IS_TRUE(a.Float3 == b.Float3);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_EQ_PD(v128 a, v128 b)
		{
			return IS_TRUE(a.Double0 == b.Double0)
				&& IS_TRUE(a.Double1 == b.Double1);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_EQ_EPI8(v256 a, v256 b)
		{
			return IS_TRUE(a.SByte0  == b.SByte0)
				&& IS_TRUE(a.SByte1  == b.SByte1)
				&& IS_TRUE(a.SByte2  == b.SByte2)
				&& IS_TRUE(a.SByte3  == b.SByte3)
				&& IS_TRUE(a.SByte4  == b.SByte4)
				&& IS_TRUE(a.SByte5  == b.SByte5)
				&& IS_TRUE(a.SByte6  == b.SByte6)
				&& IS_TRUE(a.SByte7  == b.SByte7)
				&& IS_TRUE(a.SByte8  == b.SByte8)
				&& IS_TRUE(a.SByte9  == b.SByte9)
				&& IS_TRUE(a.SByte10 == b.SByte10)
				&& IS_TRUE(a.SByte11 == b.SByte11)
				&& IS_TRUE(a.SByte12 == b.SByte12)
				&& IS_TRUE(a.SByte13 == b.SByte13)
				&& IS_TRUE(a.SByte14 == b.SByte14)
				&& IS_TRUE(a.SByte15 == b.SByte15)
			    && IS_TRUE(a.SByte16 == b.SByte16)
				&& IS_TRUE(a.SByte17 == b.SByte17)
				&& IS_TRUE(a.SByte18 == b.SByte18)
				&& IS_TRUE(a.SByte19 == b.SByte19)
				&& IS_TRUE(a.SByte20 == b.SByte20)
				&& IS_TRUE(a.SByte21 == b.SByte21)
				&& IS_TRUE(a.SByte22 == b.SByte22)
				&& IS_TRUE(a.SByte23 == b.SByte23)
				&& IS_TRUE(a.SByte24 == b.SByte24)
				&& IS_TRUE(a.SByte25 == b.SByte25)
				&& IS_TRUE(a.SByte26 == b.SByte26)
				&& IS_TRUE(a.SByte27 == b.SByte27)
				&& IS_TRUE(a.SByte28 == b.SByte28)
				&& IS_TRUE(a.SByte29 == b.SByte29)
				&& IS_TRUE(a.SByte30 == b.SByte30)
				&& IS_TRUE(a.SByte31 == b.SByte31);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_EQ_EPI16(v256 a, v256 b)
		{
			return IS_TRUE(a.SShort0  == b.SShort0)
				&& IS_TRUE(a.SShort1  == b.SShort1)
				&& IS_TRUE(a.SShort2  == b.SShort2)
				&& IS_TRUE(a.SShort3  == b.SShort3)
				&& IS_TRUE(a.SShort4  == b.SShort4)
				&& IS_TRUE(a.SShort5  == b.SShort5)
				&& IS_TRUE(a.SShort6  == b.SShort6)
				&& IS_TRUE(a.SShort7  == b.SShort7)
				&& IS_TRUE(a.SShort8  == b.SShort8)
				&& IS_TRUE(a.SShort9  == b.SShort9)
				&& IS_TRUE(a.SShort10 == b.SShort10)
				&& IS_TRUE(a.SShort11 == b.SShort11)
				&& IS_TRUE(a.SShort12 == b.SShort12)
				&& IS_TRUE(a.SShort13 == b.SShort13)
				&& IS_TRUE(a.SShort14 == b.SShort14)
				&& IS_TRUE(a.SShort15 == b.SShort15);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_EQ_EPI32(v256 a, v256 b)
		{
			return IS_TRUE(a.SInt0 == b.SInt0)
				&& IS_TRUE(a.SInt1 == b.SInt1)
				&& IS_TRUE(a.SInt2 == b.SInt2)
				&& IS_TRUE(a.SInt3 == b.SInt3)
				&& IS_TRUE(a.SInt4 == b.SInt4)
				&& IS_TRUE(a.SInt5 == b.SInt5)
				&& IS_TRUE(a.SInt6 == b.SInt6)
				&& IS_TRUE(a.SInt7 == b.SInt7);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_EQ_EPI64(v256 a, v256 b, byte elements = 4)
		{
			if (elements == 3)
			{
				return IS_TRUE(a.SLong0 == b.SLong0)
					&& IS_TRUE(a.SLong1 == b.SLong1)
					&& IS_TRUE(a.SLong2 == b.SLong2);
			}
			else
			{
				return IS_TRUE(a.SLong0 == b.SLong0)
					&& IS_TRUE(a.SLong1 == b.SLong1)
					&& IS_TRUE(a.SLong2 == b.SLong2)
					&& IS_TRUE(a.SLong3 == b.SLong3);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_EQ_EPU8(v256 a, v256 b)
		{
			return IS_TRUE(a.Byte0  == b.Byte0)
				&& IS_TRUE(a.Byte1  == b.Byte1)
				&& IS_TRUE(a.Byte2  == b.Byte2)
				&& IS_TRUE(a.Byte3  == b.Byte3)
				&& IS_TRUE(a.Byte4  == b.Byte4)
				&& IS_TRUE(a.Byte5  == b.Byte5)
				&& IS_TRUE(a.Byte6  == b.Byte6)
				&& IS_TRUE(a.Byte7  == b.Byte7)
				&& IS_TRUE(a.Byte8  == b.Byte8)
				&& IS_TRUE(a.Byte9  == b.Byte9)
				&& IS_TRUE(a.Byte10 == b.Byte10)
				&& IS_TRUE(a.Byte11 == b.Byte11)
				&& IS_TRUE(a.Byte12 == b.Byte12)
				&& IS_TRUE(a.Byte13 == b.Byte13)
				&& IS_TRUE(a.Byte14 == b.Byte14)
				&& IS_TRUE(a.Byte15 == b.Byte15)
			    && IS_TRUE(a.Byte16 == b.Byte16)
				&& IS_TRUE(a.Byte17 == b.Byte17)
				&& IS_TRUE(a.Byte18 == b.Byte18)
				&& IS_TRUE(a.Byte19 == b.Byte19)
				&& IS_TRUE(a.Byte20 == b.Byte20)
				&& IS_TRUE(a.Byte21 == b.Byte21)
				&& IS_TRUE(a.Byte22 == b.Byte22)
				&& IS_TRUE(a.Byte23 == b.Byte23)
				&& IS_TRUE(a.Byte24 == b.Byte24)
				&& IS_TRUE(a.Byte25 == b.Byte25)
				&& IS_TRUE(a.Byte26 == b.Byte26)
				&& IS_TRUE(a.Byte27 == b.Byte27)
				&& IS_TRUE(a.Byte28 == b.Byte28)
				&& IS_TRUE(a.Byte29 == b.Byte29)
				&& IS_TRUE(a.Byte30 == b.Byte30)
				&& IS_TRUE(a.Byte31 == b.Byte31);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_EQ_EPU16(v256 a, v256 b)
		{
			return IS_TRUE(a.UShort0  == b.UShort0)
				&& IS_TRUE(a.UShort1  == b.UShort1)
				&& IS_TRUE(a.UShort2  == b.UShort2)
				&& IS_TRUE(a.UShort3  == b.UShort3)
				&& IS_TRUE(a.UShort4  == b.UShort4)
				&& IS_TRUE(a.UShort5  == b.UShort5)
				&& IS_TRUE(a.UShort6  == b.UShort6)
				&& IS_TRUE(a.UShort7  == b.UShort7)
				&& IS_TRUE(a.UShort8  == b.UShort8)
				&& IS_TRUE(a.UShort9  == b.UShort9)
				&& IS_TRUE(a.UShort10 == b.UShort10)
				&& IS_TRUE(a.UShort11 == b.UShort11)
				&& IS_TRUE(a.UShort12 == b.UShort12)
				&& IS_TRUE(a.UShort13 == b.UShort13)
				&& IS_TRUE(a.UShort14 == b.UShort14)
				&& IS_TRUE(a.UShort15 == b.UShort15);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_EQ_EPU32(v256 a, v256 b)
		{
			return IS_TRUE(a.UInt0 == b.UInt0)
				&& IS_TRUE(a.UInt1 == b.UInt1)
				&& IS_TRUE(a.UInt2 == b.UInt2)
				&& IS_TRUE(a.UInt3 == b.UInt3)
				&& IS_TRUE(a.UInt4 == b.UInt4)
				&& IS_TRUE(a.UInt5 == b.UInt5)
				&& IS_TRUE(a.UInt6 == b.UInt6)
				&& IS_TRUE(a.UInt7 == b.UInt7);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_EQ_EPU64(v256 a, v256 b, byte elements = 4)
		{
			if (elements == 3)
			{
				return IS_TRUE(a.ULong0 == b.ULong0)
					&& IS_TRUE(a.ULong1 == b.ULong1)
					&& IS_TRUE(a.ULong2 == b.ULong2);
			}
			else
			{
				return IS_TRUE(a.ULong0 == b.ULong0)
					&& IS_TRUE(a.ULong1 == b.ULong1)
					&& IS_TRUE(a.ULong2 == b.ULong2)
					&& IS_TRUE(a.ULong3 == b.ULong3);
			}
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_EQ_PS(v256 a, v256 b)
		{
			return IS_TRUE(a.Float0 == b.Float0)
				&& IS_TRUE(a.Float1 == b.Float1)
				&& IS_TRUE(a.Float2 == b.Float2)
				&& IS_TRUE(a.Float3 == b.Float3)
				&& IS_TRUE(a.Float4 == b.Float4)
				&& IS_TRUE(a.Float5 == b.Float5)
				&& IS_TRUE(a.Float6 == b.Float6)
				&& IS_TRUE(a.Float7 == b.Float7);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_EQ_PD(v256 a, v256 b, byte elements = 4)
		{
			if (elements == 3)
			{
				return IS_TRUE(a.Double0 == b.Double0)
					&& IS_TRUE(a.Double1 == b.Double1)
					&& IS_TRUE(a.Double2 == b.Double2);
			}
			else
			{
				return IS_TRUE(a.Double0 == b.Double0)
					&& IS_TRUE(a.Double1 == b.Double1)
					&& IS_TRUE(a.Double2 == b.Double2)
					&& IS_TRUE(a.Double3 == b.Double3);
			}
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_NEQ_EPU8(v128 a, v128 b, byte elements = 16)
		{
			switch (elements)
			{
				case  2: return IS_TRUE(a.Byte0  != b.Byte0)
							 && IS_TRUE(a.Byte1  != b.Byte1);

				case  3: return IS_TRUE(a.Byte0  != b.Byte0)
							 && IS_TRUE(a.Byte1  != b.Byte1)
							 && IS_TRUE(a.Byte2  != b.Byte2);

				case  4: return IS_TRUE(a.Byte0  != b.Byte0)
							 && IS_TRUE(a.Byte1  != b.Byte1)
							 && IS_TRUE(a.Byte2  != b.Byte2)
							 && IS_TRUE(a.Byte3  != b.Byte3);

				case  8: return IS_TRUE(a.Byte0  != b.Byte0)
							 && IS_TRUE(a.Byte1  != b.Byte1)
							 && IS_TRUE(a.Byte2  != b.Byte2)
							 && IS_TRUE(a.Byte3  != b.Byte3)
							 && IS_TRUE(a.Byte4  != b.Byte4)
							 && IS_TRUE(a.Byte5  != b.Byte5)
							 && IS_TRUE(a.Byte6  != b.Byte6)
							 && IS_TRUE(a.Byte7  != b.Byte7);

				default: return IS_TRUE(a.Byte0  != b.Byte0)
							 && IS_TRUE(a.Byte1  != b.Byte1)
							 && IS_TRUE(a.Byte2  != b.Byte2)
							 && IS_TRUE(a.Byte3  != b.Byte3)
							 && IS_TRUE(a.Byte4  != b.Byte4)
							 && IS_TRUE(a.Byte5  != b.Byte5)
							 && IS_TRUE(a.Byte6  != b.Byte6)
							 && IS_TRUE(a.Byte7  != b.Byte7)
							 && IS_TRUE(a.Byte8  != b.Byte8)
							 && IS_TRUE(a.Byte9  != b.Byte9)
							 && IS_TRUE(a.Byte10 != b.Byte10)
							 && IS_TRUE(a.Byte11 != b.Byte11)
							 && IS_TRUE(a.Byte12 != b.Byte12)
							 && IS_TRUE(a.Byte13 != b.Byte13)
							 && IS_TRUE(a.Byte14 != b.Byte14)
							 && IS_TRUE(a.Byte15 != b.Byte15);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_NEQ_EPU16(v128 a, v128 b, byte elements = 8)
		{
			switch (elements)
			{
				case  2: return IS_TRUE(a.UShort0  != b.UShort0)
							 && IS_TRUE(a.UShort1  != b.UShort1);

				case  3: return IS_TRUE(a.UShort0  != b.UShort0)
							 && IS_TRUE(a.UShort1  != b.UShort1)
							 && IS_TRUE(a.UShort2  != b.UShort2);

				case  4: return IS_TRUE(a.UShort0  != b.UShort0)
							 && IS_TRUE(a.UShort1  != b.UShort1)
							 && IS_TRUE(a.UShort2  != b.UShort2)
							 && IS_TRUE(a.UShort3  != b.UShort3);

				default: return IS_TRUE(a.UShort0  != b.UShort0)
							 && IS_TRUE(a.UShort1  != b.UShort1)
							 && IS_TRUE(a.UShort2  != b.UShort2)
							 && IS_TRUE(a.UShort3  != b.UShort3)
							 && IS_TRUE(a.UShort4  != b.UShort4)
							 && IS_TRUE(a.UShort5  != b.UShort5)
							 && IS_TRUE(a.UShort6  != b.UShort6)
							 && IS_TRUE(a.UShort7  != b.UShort7);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_NEQ_EPU32(v128 a, v128 b, byte elements = 4)
		{
			switch (elements)
			{
				case  2: return IS_TRUE(a.UInt0  != b.UInt0)
							 && IS_TRUE(a.UInt1  != b.UInt1);

				case  3: return IS_TRUE(a.UInt0  != b.UInt0)
							 && IS_TRUE(a.UInt1  != b.UInt1)
							 && IS_TRUE(a.UInt2  != b.UInt2);

				default: return IS_TRUE(a.UInt0  != b.UInt0)
							 && IS_TRUE(a.UInt1  != b.UInt1)
							 && IS_TRUE(a.UInt2  != b.UInt2)
							 && IS_TRUE(a.UInt3  != b.UInt3);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_NEQ_EPU64(v128 a, v128 b)
		{
			return IS_TRUE(a.ULong0 != b.ULong0)
				&& IS_TRUE(a.ULong1 != b.ULong1);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_NEQ_EPI8(v128 a, v128 b, byte elements = 16)
		{
			switch (elements)
			{
				case  2: return IS_TRUE(a.SByte0  != b.SByte0)
							 && IS_TRUE(a.SByte1  != b.SByte1);

				case  3: return IS_TRUE(a.SByte0  != b.SByte0)
							 && IS_TRUE(a.SByte1  != b.SByte1)
							 && IS_TRUE(a.SByte2  != b.SByte2);

				case  4: return IS_TRUE(a.SByte0  != b.SByte0)
							 && IS_TRUE(a.SByte1  != b.SByte1)
							 && IS_TRUE(a.SByte2  != b.SByte2)
							 && IS_TRUE(a.SByte3  != b.SByte3);

				case  8: return IS_TRUE(a.SByte0  != b.SByte0)
							 && IS_TRUE(a.SByte1  != b.SByte1)
							 && IS_TRUE(a.SByte2  != b.SByte2)
							 && IS_TRUE(a.SByte3  != b.SByte3)
							 && IS_TRUE(a.SByte4  != b.SByte4)
							 && IS_TRUE(a.SByte5  != b.SByte5)
							 && IS_TRUE(a.SByte6  != b.SByte6)
							 && IS_TRUE(a.SByte7  != b.SByte7);

				default: return IS_TRUE(a.SByte0  != b.SByte0)
							 && IS_TRUE(a.SByte1  != b.SByte1)
							 && IS_TRUE(a.SByte2  != b.SByte2)
							 && IS_TRUE(a.SByte3  != b.SByte3)
							 && IS_TRUE(a.SByte4  != b.SByte4)
							 && IS_TRUE(a.SByte5  != b.SByte5)
							 && IS_TRUE(a.SByte6  != b.SByte6)
							 && IS_TRUE(a.SByte7  != b.SByte7)
							 && IS_TRUE(a.SByte8  != b.SByte8)
							 && IS_TRUE(a.SByte9  != b.SByte9)
							 && IS_TRUE(a.SByte10 != b.SByte10)
							 && IS_TRUE(a.SByte11 != b.SByte11)
							 && IS_TRUE(a.SByte12 != b.SByte12)
							 && IS_TRUE(a.SByte13 != b.SByte13)
							 && IS_TRUE(a.SByte14 != b.SByte14)
							 && IS_TRUE(a.SByte15 != b.SByte15);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_NEQ_EPI16(v128 a, v128 b, byte elements = 8)
		{
			switch (elements)
			{
				case  2: return IS_TRUE(a.SShort0 != b.SShort0)
							 && IS_TRUE(a.SShort1 != b.SShort1);

				case  3: return IS_TRUE(a.SShort0 != b.SShort0)
							 && IS_TRUE(a.SShort1 != b.SShort1)
							 && IS_TRUE(a.SShort2 != b.SShort2);

				case  4: return IS_TRUE(a.SShort0 != b.SShort0)
							 && IS_TRUE(a.SShort1 != b.SShort1)
							 && IS_TRUE(a.SShort2 != b.SShort2)
							 && IS_TRUE(a.SShort3 != b.SShort3);

				default: return IS_TRUE(a.SShort0 != b.SShort0)
							 && IS_TRUE(a.SShort1 != b.SShort1)
							 && IS_TRUE(a.SShort2 != b.SShort2)
							 && IS_TRUE(a.SShort3 != b.SShort3)
							 && IS_TRUE(a.SShort4 != b.SShort4)
							 && IS_TRUE(a.SShort5 != b.SShort5)
							 && IS_TRUE(a.SShort6 != b.SShort6)
							 && IS_TRUE(a.SShort7 != b.SShort7);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_NEQ_EPI32(v128 a, v128 b, byte elements = 4)
		{
			switch (elements)
			{
				case  2: return IS_TRUE(a.SInt0 != b.SInt0)
							 && IS_TRUE(a.SInt1 != b.SInt1);

				case  3: return IS_TRUE(a.SInt0 != b.SInt0)
							 && IS_TRUE(a.SInt1 != b.SInt1)
							 && IS_TRUE(a.SInt2 != b.SInt2);

				default: return IS_TRUE(a.SInt0 != b.SInt0)
							 && IS_TRUE(a.SInt1 != b.SInt1)
							 && IS_TRUE(a.SInt2 != b.SInt2)
							 && IS_TRUE(a.SInt3 != b.SInt3);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_NEQ_EPI64(v128 a, v128 b)
		{
			return IS_TRUE(a.SLong0 != b.SLong0)
				&& IS_TRUE(a.SLong1 != b.SLong1);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_NEQ_PS(v128 a, v128 b, byte elements = 4)
		{
			switch (elements)
			{
				case  1: return IS_TRUE(a.Float0 != b.Float0);

				case  2: return IS_TRUE(a.Float0 != b.Float0)
							 && IS_TRUE(a.Float1 != b.Float1);

				case  3: return IS_TRUE(a.Float0 != b.Float0)
							 && IS_TRUE(a.Float1 != b.Float1)
							 && IS_TRUE(a.Float2 != b.Float2);

				default: return IS_TRUE(a.Float0 != b.Float0)
							 && IS_TRUE(a.Float1 != b.Float1)
							 && IS_TRUE(a.Float2 != b.Float2)
							 && IS_TRUE(a.Float3 != b.Float3);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_NEQ_PD(v128 a, v128 b)
		{
			return IS_TRUE(a.Double0 != b.Double0)
				&& IS_TRUE(a.Double1 != b.Double1);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_NEQ_EPI8(v256 a, v256 b)
		{
			return IS_TRUE(a.SByte0  != b.SByte0)
				&& IS_TRUE(a.SByte1  != b.SByte1)
				&& IS_TRUE(a.SByte2  != b.SByte2)
				&& IS_TRUE(a.SByte3  != b.SByte3)
				&& IS_TRUE(a.SByte4  != b.SByte4)
				&& IS_TRUE(a.SByte5  != b.SByte5)
				&& IS_TRUE(a.SByte6  != b.SByte6)
				&& IS_TRUE(a.SByte7  != b.SByte7)
				&& IS_TRUE(a.SByte8  != b.SByte8)
				&& IS_TRUE(a.SByte9  != b.SByte9)
				&& IS_TRUE(a.SByte10 != b.SByte10)
				&& IS_TRUE(a.SByte11 != b.SByte11)
				&& IS_TRUE(a.SByte12 != b.SByte12)
				&& IS_TRUE(a.SByte13 != b.SByte13)
				&& IS_TRUE(a.SByte14 != b.SByte14)
				&& IS_TRUE(a.SByte15 != b.SByte15)
			    && IS_TRUE(a.SByte16 != b.SByte16)
				&& IS_TRUE(a.SByte17 != b.SByte17)
				&& IS_TRUE(a.SByte18 != b.SByte18)
				&& IS_TRUE(a.SByte19 != b.SByte19)
				&& IS_TRUE(a.SByte20 != b.SByte20)
				&& IS_TRUE(a.SByte21 != b.SByte21)
				&& IS_TRUE(a.SByte22 != b.SByte22)
				&& IS_TRUE(a.SByte23 != b.SByte23)
				&& IS_TRUE(a.SByte24 != b.SByte24)
				&& IS_TRUE(a.SByte25 != b.SByte25)
				&& IS_TRUE(a.SByte26 != b.SByte26)
				&& IS_TRUE(a.SByte27 != b.SByte27)
				&& IS_TRUE(a.SByte28 != b.SByte28)
				&& IS_TRUE(a.SByte29 != b.SByte29)
				&& IS_TRUE(a.SByte30 != b.SByte30)
				&& IS_TRUE(a.SByte31 != b.SByte31);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_NEQ_EPI16(v256 a, v256 b)
		{
			return IS_TRUE(a.SShort0  != b.SShort0)
				&& IS_TRUE(a.SShort1  != b.SShort1)
				&& IS_TRUE(a.SShort2  != b.SShort2)
				&& IS_TRUE(a.SShort3  != b.SShort3)
				&& IS_TRUE(a.SShort4  != b.SShort4)
				&& IS_TRUE(a.SShort5  != b.SShort5)
				&& IS_TRUE(a.SShort6  != b.SShort6)
				&& IS_TRUE(a.SShort7  != b.SShort7)
				&& IS_TRUE(a.SShort8  != b.SShort8)
				&& IS_TRUE(a.SShort9  != b.SShort9)
				&& IS_TRUE(a.SShort10 != b.SShort10)
				&& IS_TRUE(a.SShort11 != b.SShort11)
				&& IS_TRUE(a.SShort12 != b.SShort12)
				&& IS_TRUE(a.SShort13 != b.SShort13)
				&& IS_TRUE(a.SShort14 != b.SShort14)
				&& IS_TRUE(a.SShort15 != b.SShort15);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_NEQ_EPI32(v256 a, v256 b)
		{
			return IS_TRUE(a.SInt0 != b.SInt0)
				&& IS_TRUE(a.SInt1 != b.SInt1)
				&& IS_TRUE(a.SInt2 != b.SInt2)
				&& IS_TRUE(a.SInt3 != b.SInt3)
				&& IS_TRUE(a.SInt4 != b.SInt4)
				&& IS_TRUE(a.SInt5 != b.SInt5)
				&& IS_TRUE(a.SInt6 != b.SInt6)
				&& IS_TRUE(a.SInt7 != b.SInt7);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_NEQ_EPI64(v256 a, v256 b, byte elements = 4)
		{
			if (elements == 3)
			{
				return IS_TRUE(a.SLong0 != b.SLong0)
					&& IS_TRUE(a.SLong1 != b.SLong1)
					&& IS_TRUE(a.SLong2 != b.SLong2);
			}
			else
			{
				return IS_TRUE(a.SLong0 != b.SLong0)
					&& IS_TRUE(a.SLong1 != b.SLong1)
					&& IS_TRUE(a.SLong2 != b.SLong2)
					&& IS_TRUE(a.SLong3 != b.SLong3);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_NEQ_EPU8(v256 a, v256 b)
		{
			return IS_TRUE(a.Byte0  != b.Byte0)
				&& IS_TRUE(a.Byte1  != b.Byte1)
				&& IS_TRUE(a.Byte2  != b.Byte2)
				&& IS_TRUE(a.Byte3  != b.Byte3)
				&& IS_TRUE(a.Byte4  != b.Byte4)
				&& IS_TRUE(a.Byte5  != b.Byte5)
				&& IS_TRUE(a.Byte6  != b.Byte6)
				&& IS_TRUE(a.Byte7  != b.Byte7)
				&& IS_TRUE(a.Byte8  != b.Byte8)
				&& IS_TRUE(a.Byte9  != b.Byte9)
				&& IS_TRUE(a.Byte10 != b.Byte10)
				&& IS_TRUE(a.Byte11 != b.Byte11)
				&& IS_TRUE(a.Byte12 != b.Byte12)
				&& IS_TRUE(a.Byte13 != b.Byte13)
				&& IS_TRUE(a.Byte14 != b.Byte14)
				&& IS_TRUE(a.Byte15 != b.Byte15)
			    && IS_TRUE(a.Byte16 != b.Byte16)
				&& IS_TRUE(a.Byte17 != b.Byte17)
				&& IS_TRUE(a.Byte18 != b.Byte18)
				&& IS_TRUE(a.Byte19 != b.Byte19)
				&& IS_TRUE(a.Byte20 != b.Byte20)
				&& IS_TRUE(a.Byte21 != b.Byte21)
				&& IS_TRUE(a.Byte22 != b.Byte22)
				&& IS_TRUE(a.Byte23 != b.Byte23)
				&& IS_TRUE(a.Byte24 != b.Byte24)
				&& IS_TRUE(a.Byte25 != b.Byte25)
				&& IS_TRUE(a.Byte26 != b.Byte26)
				&& IS_TRUE(a.Byte27 != b.Byte27)
				&& IS_TRUE(a.Byte28 != b.Byte28)
				&& IS_TRUE(a.Byte29 != b.Byte29)
				&& IS_TRUE(a.Byte30 != b.Byte30)
				&& IS_TRUE(a.Byte31 != b.Byte31);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_NEQ_EPU16(v256 a, v256 b)
		{
			return IS_TRUE(a.UShort0  != b.UShort0)
				&& IS_TRUE(a.UShort1  != b.UShort1)
				&& IS_TRUE(a.UShort2  != b.UShort2)
				&& IS_TRUE(a.UShort3  != b.UShort3)
				&& IS_TRUE(a.UShort4  != b.UShort4)
				&& IS_TRUE(a.UShort5  != b.UShort5)
				&& IS_TRUE(a.UShort6  != b.UShort6)
				&& IS_TRUE(a.UShort7  != b.UShort7)
				&& IS_TRUE(a.UShort8  != b.UShort8)
				&& IS_TRUE(a.UShort9  != b.UShort9)
				&& IS_TRUE(a.UShort10 != b.UShort10)
				&& IS_TRUE(a.UShort11 != b.UShort11)
				&& IS_TRUE(a.UShort12 != b.UShort12)
				&& IS_TRUE(a.UShort13 != b.UShort13)
				&& IS_TRUE(a.UShort14 != b.UShort14)
				&& IS_TRUE(a.UShort15 != b.UShort15);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_NEQ_EPU32(v256 a, v256 b)
		{
			return IS_TRUE(a.UInt0 != b.UInt0)
				&& IS_TRUE(a.UInt1 != b.UInt1)
				&& IS_TRUE(a.UInt2 != b.UInt2)
				&& IS_TRUE(a.UInt3 != b.UInt3)
				&& IS_TRUE(a.UInt4 != b.UInt4)
				&& IS_TRUE(a.UInt5 != b.UInt5)
				&& IS_TRUE(a.UInt6 != b.UInt6)
				&& IS_TRUE(a.UInt7 != b.UInt7);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_NEQ_EPU64(v256 a, v256 b, byte elements = 4)
		{
			if (elements == 3)
			{
				return IS_TRUE(a.ULong0 != b.ULong0)
					&& IS_TRUE(a.ULong1 != b.ULong1)
					&& IS_TRUE(a.ULong2 != b.ULong2);
			}
			else
			{
				return IS_TRUE(a.ULong0 != b.ULong0)
					&& IS_TRUE(a.ULong1 != b.ULong1)
					&& IS_TRUE(a.ULong2 != b.ULong2)
					&& IS_TRUE(a.ULong3 != b.ULong3);
			}
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_NEQ_PS(v256 a, v256 b)
		{
			return IS_TRUE(a.Float0 != b.Float0)
				&& IS_TRUE(a.Float1 != b.Float1)
				&& IS_TRUE(a.Float2 != b.Float2)
				&& IS_TRUE(a.Float3 != b.Float3)
				&& IS_TRUE(a.Float4 != b.Float4)
				&& IS_TRUE(a.Float5 != b.Float5)
				&& IS_TRUE(a.Float6 != b.Float6)
				&& IS_TRUE(a.Float7 != b.Float7);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_NEQ_PD(v256 a, v256 b, byte elements = 4)
		{
			if (elements == 3)
			{
				return IS_TRUE(a.Double0 != b.Double0)
					&& IS_TRUE(a.Double1 != b.Double1)
					&& IS_TRUE(a.Double2 != b.Double2);
			}
			else
			{
				return IS_TRUE(a.Double0 != b.Double0)
					&& IS_TRUE(a.Double1 != b.Double1)
					&& IS_TRUE(a.Double2 != b.Double2)
					&& IS_TRUE(a.Double3 != b.Double3);
			}
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_GT_EPU8(v128 a, v128 b, byte elements = 16)
		{
			switch (elements)
			{
				case  2: return IS_TRUE(a.Byte0  > b.Byte0)
							 && IS_TRUE(a.Byte1  > b.Byte1);

				case  3: return IS_TRUE(a.Byte0  > b.Byte0)
							 && IS_TRUE(a.Byte1  > b.Byte1)
							 && IS_TRUE(a.Byte2  > b.Byte2);

				case  4: return IS_TRUE(a.Byte0  > b.Byte0)
							 && IS_TRUE(a.Byte1  > b.Byte1)
							 && IS_TRUE(a.Byte2  > b.Byte2)
							 && IS_TRUE(a.Byte3  > b.Byte3);

				case  8: return IS_TRUE(a.Byte0  > b.Byte0)
							 && IS_TRUE(a.Byte1  > b.Byte1)
							 && IS_TRUE(a.Byte2  > b.Byte2)
							 && IS_TRUE(a.Byte3  > b.Byte3)
							 && IS_TRUE(a.Byte4  > b.Byte4)
							 && IS_TRUE(a.Byte5  > b.Byte5)
							 && IS_TRUE(a.Byte6  > b.Byte6)
							 && IS_TRUE(a.Byte7  > b.Byte7);

				default: return IS_TRUE(a.Byte0  > b.Byte0)
							 && IS_TRUE(a.Byte1  > b.Byte1)
							 && IS_TRUE(a.Byte2  > b.Byte2)
							 && IS_TRUE(a.Byte3  > b.Byte3)
							 && IS_TRUE(a.Byte4  > b.Byte4)
							 && IS_TRUE(a.Byte5  > b.Byte5)
							 && IS_TRUE(a.Byte6  > b.Byte6)
							 && IS_TRUE(a.Byte7  > b.Byte7)
							 && IS_TRUE(a.Byte8  > b.Byte8)
							 && IS_TRUE(a.Byte9  > b.Byte9)
							 && IS_TRUE(a.Byte10 > b.Byte10)
							 && IS_TRUE(a.Byte11 > b.Byte11)
							 && IS_TRUE(a.Byte12 > b.Byte12)
							 && IS_TRUE(a.Byte13 > b.Byte13)
							 && IS_TRUE(a.Byte14 > b.Byte14)
							 && IS_TRUE(a.Byte15 > b.Byte15);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_GT_EPU16(v128 a, v128 b, byte elements = 8)
		{
			switch (elements)
			{
				case  2: return IS_TRUE(a.UShort0  > b.UShort0)
							 && IS_TRUE(a.UShort1  > b.UShort1);

				case  3: return IS_TRUE(a.UShort0  > b.UShort0)
							 && IS_TRUE(a.UShort1  > b.UShort1)
							 && IS_TRUE(a.UShort2  > b.UShort2);

				case  4: return IS_TRUE(a.UShort0  > b.UShort0)
							 && IS_TRUE(a.UShort1  > b.UShort1)
							 && IS_TRUE(a.UShort2  > b.UShort2)
							 && IS_TRUE(a.UShort3  > b.UShort3);

				default: return IS_TRUE(a.UShort0  > b.UShort0)
							 && IS_TRUE(a.UShort1  > b.UShort1)
							 && IS_TRUE(a.UShort2  > b.UShort2)
							 && IS_TRUE(a.UShort3  > b.UShort3)
							 && IS_TRUE(a.UShort4  > b.UShort4)
							 && IS_TRUE(a.UShort5  > b.UShort5)
							 && IS_TRUE(a.UShort6  > b.UShort6)
							 && IS_TRUE(a.UShort7  > b.UShort7);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_GT_EPU32(v128 a, v128 b, byte elements = 4)
		{
			switch (elements)
			{
				case  2: return IS_TRUE(a.UInt0  > b.UInt0)
							 && IS_TRUE(a.UInt1  > b.UInt1);

				case  3: return IS_TRUE(a.UInt0  > b.UInt0)
							 && IS_TRUE(a.UInt1  > b.UInt1)
							 && IS_TRUE(a.UInt2  > b.UInt2);

				default: return IS_TRUE(a.UInt0  > b.UInt0)
							 && IS_TRUE(a.UInt1  > b.UInt1)
							 && IS_TRUE(a.UInt2  > b.UInt2)
							 && IS_TRUE(a.UInt3  > b.UInt3);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_GT_EPU64(v128 a, v128 b)
		{
			return IS_TRUE(a.ULong0 > b.ULong0)
				&& IS_TRUE(a.ULong1 > b.ULong1);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_GT_EPI8(v128 a, v128 b, byte elements = 16)
		{
			switch (elements)
			{
				case  2: return IS_TRUE(a.SByte0  > b.SByte0)
							 && IS_TRUE(a.SByte1  > b.SByte1);

				case  3: return IS_TRUE(a.SByte0  > b.SByte0)
							 && IS_TRUE(a.SByte1  > b.SByte1)
							 && IS_TRUE(a.SByte2  > b.SByte2);

				case  4: return IS_TRUE(a.SByte0  > b.SByte0)
							 && IS_TRUE(a.SByte1  > b.SByte1)
							 && IS_TRUE(a.SByte2  > b.SByte2)
							 && IS_TRUE(a.SByte3  > b.SByte3);

				case  8: return IS_TRUE(a.SByte0  > b.SByte0)
							 && IS_TRUE(a.SByte1  > b.SByte1)
							 && IS_TRUE(a.SByte2  > b.SByte2)
							 && IS_TRUE(a.SByte3  > b.SByte3)
							 && IS_TRUE(a.SByte4  > b.SByte4)
							 && IS_TRUE(a.SByte5  > b.SByte5)
							 && IS_TRUE(a.SByte6  > b.SByte6)
							 && IS_TRUE(a.SByte7  > b.SByte7);

				default: return IS_TRUE(a.SByte0  > b.SByte0)
							 && IS_TRUE(a.SByte1  > b.SByte1)
							 && IS_TRUE(a.SByte2  > b.SByte2)
							 && IS_TRUE(a.SByte3  > b.SByte3)
							 && IS_TRUE(a.SByte4  > b.SByte4)
							 && IS_TRUE(a.SByte5  > b.SByte5)
							 && IS_TRUE(a.SByte6  > b.SByte6)
							 && IS_TRUE(a.SByte7  > b.SByte7)
							 && IS_TRUE(a.SByte8  > b.SByte8)
							 && IS_TRUE(a.SByte9  > b.SByte9)
							 && IS_TRUE(a.SByte10 > b.SByte10)
							 && IS_TRUE(a.SByte11 > b.SByte11)
							 && IS_TRUE(a.SByte12 > b.SByte12)
							 && IS_TRUE(a.SByte13 > b.SByte13)
							 && IS_TRUE(a.SByte14 > b.SByte14)
							 && IS_TRUE(a.SByte15 > b.SByte15);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_GT_EPI16(v128 a, v128 b, byte elements = 8)
		{
			switch (elements)
			{
				case  2: return IS_TRUE(a.SShort0 > b.SShort0)
							 && IS_TRUE(a.SShort1 > b.SShort1);

				case  3: return IS_TRUE(a.SShort0 > b.SShort0)
							 && IS_TRUE(a.SShort1 > b.SShort1)
							 && IS_TRUE(a.SShort2 > b.SShort2);

				case  4: return IS_TRUE(a.SShort0 > b.SShort0)
							 && IS_TRUE(a.SShort1 > b.SShort1)
							 && IS_TRUE(a.SShort2 > b.SShort2)
							 && IS_TRUE(a.SShort3 > b.SShort3);

				default: return IS_TRUE(a.SShort0 > b.SShort0)
							 && IS_TRUE(a.SShort1 > b.SShort1)
							 && IS_TRUE(a.SShort2 > b.SShort2)
							 && IS_TRUE(a.SShort3 > b.SShort3)
							 && IS_TRUE(a.SShort4 > b.SShort4)
							 && IS_TRUE(a.SShort5 > b.SShort5)
							 && IS_TRUE(a.SShort6 > b.SShort6)
							 && IS_TRUE(a.SShort7 > b.SShort7);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_GT_EPI32(v128 a, v128 b, byte elements = 4)
		{
			switch (elements)
			{
				case  2: return IS_TRUE(a.SInt0 > b.SInt0)
							 && IS_TRUE(a.SInt1 > b.SInt1);

				case  3: return IS_TRUE(a.SInt0 > b.SInt0)
							 && IS_TRUE(a.SInt1 > b.SInt1)
							 && IS_TRUE(a.SInt2 > b.SInt2);

				default: return IS_TRUE(a.SInt0 > b.SInt0)
							 && IS_TRUE(a.SInt1 > b.SInt1)
							 && IS_TRUE(a.SInt2 > b.SInt2)
							 && IS_TRUE(a.SInt3 > b.SInt3);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_GT_EPI64(v128 a, v128 b)
		{
			return IS_TRUE(a.SLong0 > b.SLong0)
				&& IS_TRUE(a.SLong1 > b.SLong1);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_GT_PS(v128 a, v128 b, byte elements = 4)
		{
			switch (elements)
			{
				case  1: return IS_TRUE(a.Float0 > b.Float0);

				case  2: return IS_TRUE(a.Float0 > b.Float0)
							 && IS_TRUE(a.Float1 > b.Float1);

				case  3: return IS_TRUE(a.Float0 > b.Float0)
							 && IS_TRUE(a.Float1 > b.Float1)
							 && IS_TRUE(a.Float2 > b.Float2);

				default: return IS_TRUE(a.Float0 > b.Float0)
							 && IS_TRUE(a.Float1 > b.Float1)
							 && IS_TRUE(a.Float2 > b.Float2)
							 && IS_TRUE(a.Float3 > b.Float3);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_GT_PD(v128 a, v128 b)
		{
			return IS_TRUE(a.Double0 > b.Double0)
				&& IS_TRUE(a.Double1 > b.Double1);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_GT_EPI8(v256 a, v256 b)
		{
			return IS_TRUE(a.SByte0  > b.SByte0)
				&& IS_TRUE(a.SByte1  > b.SByte1)
				&& IS_TRUE(a.SByte2  > b.SByte2)
				&& IS_TRUE(a.SByte3  > b.SByte3)
				&& IS_TRUE(a.SByte4  > b.SByte4)
				&& IS_TRUE(a.SByte5  > b.SByte5)
				&& IS_TRUE(a.SByte6  > b.SByte6)
				&& IS_TRUE(a.SByte7  > b.SByte7)
				&& IS_TRUE(a.SByte8  > b.SByte8)
				&& IS_TRUE(a.SByte9  > b.SByte9)
				&& IS_TRUE(a.SByte10 > b.SByte10)
				&& IS_TRUE(a.SByte11 > b.SByte11)
				&& IS_TRUE(a.SByte12 > b.SByte12)
				&& IS_TRUE(a.SByte13 > b.SByte13)
				&& IS_TRUE(a.SByte14 > b.SByte14)
				&& IS_TRUE(a.SByte15 > b.SByte15)
			    && IS_TRUE(a.SByte16 > b.SByte16)
				&& IS_TRUE(a.SByte17 > b.SByte17)
				&& IS_TRUE(a.SByte18 > b.SByte18)
				&& IS_TRUE(a.SByte19 > b.SByte19)
				&& IS_TRUE(a.SByte20 > b.SByte20)
				&& IS_TRUE(a.SByte21 > b.SByte21)
				&& IS_TRUE(a.SByte22 > b.SByte22)
				&& IS_TRUE(a.SByte23 > b.SByte23)
				&& IS_TRUE(a.SByte24 > b.SByte24)
				&& IS_TRUE(a.SByte25 > b.SByte25)
				&& IS_TRUE(a.SByte26 > b.SByte26)
				&& IS_TRUE(a.SByte27 > b.SByte27)
				&& IS_TRUE(a.SByte28 > b.SByte28)
				&& IS_TRUE(a.SByte29 > b.SByte29)
				&& IS_TRUE(a.SByte30 > b.SByte30)
				&& IS_TRUE(a.SByte31 > b.SByte31);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_GT_EPI16(v256 a, v256 b)
		{
			return IS_TRUE(a.SShort0  > b.SShort0)
				&& IS_TRUE(a.SShort1  > b.SShort1)
				&& IS_TRUE(a.SShort2  > b.SShort2)
				&& IS_TRUE(a.SShort3  > b.SShort3)
				&& IS_TRUE(a.SShort4  > b.SShort4)
				&& IS_TRUE(a.SShort5  > b.SShort5)
				&& IS_TRUE(a.SShort6  > b.SShort6)
				&& IS_TRUE(a.SShort7  > b.SShort7)
				&& IS_TRUE(a.SShort8  > b.SShort8)
				&& IS_TRUE(a.SShort9  > b.SShort9)
				&& IS_TRUE(a.SShort10 > b.SShort10)
				&& IS_TRUE(a.SShort11 > b.SShort11)
				&& IS_TRUE(a.SShort12 > b.SShort12)
				&& IS_TRUE(a.SShort13 > b.SShort13)
				&& IS_TRUE(a.SShort14 > b.SShort14)
				&& IS_TRUE(a.SShort15 > b.SShort15);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_GT_EPI32(v256 a, v256 b)
		{
			return IS_TRUE(a.SInt0 > b.SInt0)
				&& IS_TRUE(a.SInt1 > b.SInt1)
				&& IS_TRUE(a.SInt2 > b.SInt2)
				&& IS_TRUE(a.SInt3 > b.SInt3)
				&& IS_TRUE(a.SInt4 > b.SInt4)
				&& IS_TRUE(a.SInt5 > b.SInt5)
				&& IS_TRUE(a.SInt6 > b.SInt6)
				&& IS_TRUE(a.SInt7 > b.SInt7);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_GT_EPI64(v256 a, v256 b, byte elements = 4)
		{
			if (elements == 3)
			{
				return IS_TRUE(a.SLong0 > b.SLong0)
					&& IS_TRUE(a.SLong1 > b.SLong1)
					&& IS_TRUE(a.SLong2 > b.SLong2);
			}
			else
			{
				return IS_TRUE(a.SLong0 > b.SLong0)
					&& IS_TRUE(a.SLong1 > b.SLong1)
					&& IS_TRUE(a.SLong2 > b.SLong2)
					&& IS_TRUE(a.SLong3 > b.SLong3);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_GT_EPU8(v256 a, v256 b)
		{
			return IS_TRUE(a.Byte0  > b.Byte0)
				&& IS_TRUE(a.Byte1  > b.Byte1)
				&& IS_TRUE(a.Byte2  > b.Byte2)
				&& IS_TRUE(a.Byte3  > b.Byte3)
				&& IS_TRUE(a.Byte4  > b.Byte4)
				&& IS_TRUE(a.Byte5  > b.Byte5)
				&& IS_TRUE(a.Byte6  > b.Byte6)
				&& IS_TRUE(a.Byte7  > b.Byte7)
				&& IS_TRUE(a.Byte8  > b.Byte8)
				&& IS_TRUE(a.Byte9  > b.Byte9)
				&& IS_TRUE(a.Byte10 > b.Byte10)
				&& IS_TRUE(a.Byte11 > b.Byte11)
				&& IS_TRUE(a.Byte12 > b.Byte12)
				&& IS_TRUE(a.Byte13 > b.Byte13)
				&& IS_TRUE(a.Byte14 > b.Byte14)
				&& IS_TRUE(a.Byte15 > b.Byte15)
			    && IS_TRUE(a.Byte16 > b.Byte16)
				&& IS_TRUE(a.Byte17 > b.Byte17)
				&& IS_TRUE(a.Byte18 > b.Byte18)
				&& IS_TRUE(a.Byte19 > b.Byte19)
				&& IS_TRUE(a.Byte20 > b.Byte20)
				&& IS_TRUE(a.Byte21 > b.Byte21)
				&& IS_TRUE(a.Byte22 > b.Byte22)
				&& IS_TRUE(a.Byte23 > b.Byte23)
				&& IS_TRUE(a.Byte24 > b.Byte24)
				&& IS_TRUE(a.Byte25 > b.Byte25)
				&& IS_TRUE(a.Byte26 > b.Byte26)
				&& IS_TRUE(a.Byte27 > b.Byte27)
				&& IS_TRUE(a.Byte28 > b.Byte28)
				&& IS_TRUE(a.Byte29 > b.Byte29)
				&& IS_TRUE(a.Byte30 > b.Byte30)
				&& IS_TRUE(a.Byte31 > b.Byte31);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_GT_EPU16(v256 a, v256 b)
		{
			return IS_TRUE(a.UShort0  > b.UShort0)
				&& IS_TRUE(a.UShort1  > b.UShort1)
				&& IS_TRUE(a.UShort2  > b.UShort2)
				&& IS_TRUE(a.UShort3  > b.UShort3)
				&& IS_TRUE(a.UShort4  > b.UShort4)
				&& IS_TRUE(a.UShort5  > b.UShort5)
				&& IS_TRUE(a.UShort6  > b.UShort6)
				&& IS_TRUE(a.UShort7  > b.UShort7)
				&& IS_TRUE(a.UShort8  > b.UShort8)
				&& IS_TRUE(a.UShort9  > b.UShort9)
				&& IS_TRUE(a.UShort10 > b.UShort10)
				&& IS_TRUE(a.UShort11 > b.UShort11)
				&& IS_TRUE(a.UShort12 > b.UShort12)
				&& IS_TRUE(a.UShort13 > b.UShort13)
				&& IS_TRUE(a.UShort14 > b.UShort14)
				&& IS_TRUE(a.UShort15 > b.UShort15);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_GT_EPU32(v256 a, v256 b)
		{
			return IS_TRUE(a.UInt0 > b.UInt0)
				&& IS_TRUE(a.UInt1 > b.UInt1)
				&& IS_TRUE(a.UInt2 > b.UInt2)
				&& IS_TRUE(a.UInt3 > b.UInt3)
				&& IS_TRUE(a.UInt4 > b.UInt4)
				&& IS_TRUE(a.UInt5 > b.UInt5)
				&& IS_TRUE(a.UInt6 > b.UInt6)
				&& IS_TRUE(a.UInt7 > b.UInt7);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_GT_EPU64(v256 a, v256 b, byte elements = 4)
		{
			if (elements == 3)
			{
				return IS_TRUE(a.ULong0 > b.ULong0)
					&& IS_TRUE(a.ULong1 > b.ULong1)
					&& IS_TRUE(a.ULong2 > b.ULong2);
			}
			else
			{
				return IS_TRUE(a.ULong0 > b.ULong0)
					&& IS_TRUE(a.ULong1 > b.ULong1)
					&& IS_TRUE(a.ULong2 > b.ULong2)
					&& IS_TRUE(a.ULong3 > b.ULong3);
			}
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_GT_PS(v256 a, v256 b)
		{
			return IS_TRUE(a.Float0 > b.Float0)
				&& IS_TRUE(a.Float1 > b.Float1)
				&& IS_TRUE(a.Float2 > b.Float2)
				&& IS_TRUE(a.Float3 > b.Float3)
				&& IS_TRUE(a.Float4 > b.Float4)
				&& IS_TRUE(a.Float5 > b.Float5)
				&& IS_TRUE(a.Float6 > b.Float6)
				&& IS_TRUE(a.Float7 > b.Float7);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_GT_PD(v256 a, v256 b, byte elements = 4)
		{
			if (elements == 3)
			{
				return IS_TRUE(a.Double0 > b.Double0)
					&& IS_TRUE(a.Double1 > b.Double1)
					&& IS_TRUE(a.Double2 > b.Double2);
			}
			else
			{
				return IS_TRUE(a.Double0 > b.Double0)
					&& IS_TRUE(a.Double1 > b.Double1)
					&& IS_TRUE(a.Double2 > b.Double2)
					&& IS_TRUE(a.Double3 > b.Double3);
			}
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_LT_EPU8(v128 a, v128 b, byte elements = 16)
		{
			switch (elements)
			{
				case  2: return IS_TRUE(a.Byte0  < b.Byte0)
							 && IS_TRUE(a.Byte1  < b.Byte1);

				case  3: return IS_TRUE(a.Byte0  < b.Byte0)
							 && IS_TRUE(a.Byte1  < b.Byte1)
							 && IS_TRUE(a.Byte2  < b.Byte2);

				case  4: return IS_TRUE(a.Byte0  < b.Byte0)
							 && IS_TRUE(a.Byte1  < b.Byte1)
							 && IS_TRUE(a.Byte2  < b.Byte2)
							 && IS_TRUE(a.Byte3  < b.Byte3);

				case  8: return IS_TRUE(a.Byte0  < b.Byte0)
							 && IS_TRUE(a.Byte1  < b.Byte1)
							 && IS_TRUE(a.Byte2  < b.Byte2)
							 && IS_TRUE(a.Byte3  < b.Byte3)
							 && IS_TRUE(a.Byte4  < b.Byte4)
							 && IS_TRUE(a.Byte5  < b.Byte5)
							 && IS_TRUE(a.Byte6  < b.Byte6)
							 && IS_TRUE(a.Byte7  < b.Byte7);

				default: return IS_TRUE(a.Byte0  < b.Byte0)
							 && IS_TRUE(a.Byte1  < b.Byte1)
							 && IS_TRUE(a.Byte2  < b.Byte2)
							 && IS_TRUE(a.Byte3  < b.Byte3)
							 && IS_TRUE(a.Byte4  < b.Byte4)
							 && IS_TRUE(a.Byte5  < b.Byte5)
							 && IS_TRUE(a.Byte6  < b.Byte6)
							 && IS_TRUE(a.Byte7  < b.Byte7)
							 && IS_TRUE(a.Byte8  < b.Byte8)
							 && IS_TRUE(a.Byte9  < b.Byte9)
							 && IS_TRUE(a.Byte10 < b.Byte10)
							 && IS_TRUE(a.Byte11 < b.Byte11)
							 && IS_TRUE(a.Byte12 < b.Byte12)
							 && IS_TRUE(a.Byte13 < b.Byte13)
							 && IS_TRUE(a.Byte14 < b.Byte14)
							 && IS_TRUE(a.Byte15 < b.Byte15);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_LT_EPU16(v128 a, v128 b, byte elements = 8)
		{
			switch (elements)
			{
				case  2: return IS_TRUE(a.UShort0  < b.UShort0)
							 && IS_TRUE(a.UShort1  < b.UShort1);

				case  3: return IS_TRUE(a.UShort0  < b.UShort0)
							 && IS_TRUE(a.UShort1  < b.UShort1)
							 && IS_TRUE(a.UShort2  < b.UShort2);

				case  4: return IS_TRUE(a.UShort0  < b.UShort0)
							 && IS_TRUE(a.UShort1  < b.UShort1)
							 && IS_TRUE(a.UShort2  < b.UShort2)
							 && IS_TRUE(a.UShort3  < b.UShort3);

				default: return IS_TRUE(a.UShort0  < b.UShort0)
							 && IS_TRUE(a.UShort1  < b.UShort1)
							 && IS_TRUE(a.UShort2  < b.UShort2)
							 && IS_TRUE(a.UShort3  < b.UShort3)
							 && IS_TRUE(a.UShort4  < b.UShort4)
							 && IS_TRUE(a.UShort5  < b.UShort5)
							 && IS_TRUE(a.UShort6  < b.UShort6)
							 && IS_TRUE(a.UShort7  < b.UShort7);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_LT_EPU32(v128 a, v128 b, byte elements = 4)
		{
			switch (elements)
			{
				case  2: return IS_TRUE(a.UInt0  < b.UInt0)
							 && IS_TRUE(a.UInt1  < b.UInt1);

				case  3: return IS_TRUE(a.UInt0  < b.UInt0)
							 && IS_TRUE(a.UInt1  < b.UInt1)
							 && IS_TRUE(a.UInt2  < b.UInt2);

				default: return IS_TRUE(a.UInt0  < b.UInt0)
							 && IS_TRUE(a.UInt1  < b.UInt1)
							 && IS_TRUE(a.UInt2  < b.UInt2)
							 && IS_TRUE(a.UInt3  < b.UInt3);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_LT_EPU64(v128 a, v128 b)
		{
			return IS_TRUE(a.ULong0 < b.ULong0)
				&& IS_TRUE(a.ULong1 < b.ULong1);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_LT_EPI8(v128 a, v128 b, byte elements = 16)
		{
			switch (elements)
			{
				case  2: return IS_TRUE(a.SByte0  < b.SByte0)
							 && IS_TRUE(a.SByte1  < b.SByte1);

				case  3: return IS_TRUE(a.SByte0  < b.SByte0)
							 && IS_TRUE(a.SByte1  < b.SByte1)
							 && IS_TRUE(a.SByte2  < b.SByte2);

				case  4: return IS_TRUE(a.SByte0  < b.SByte0)
							 && IS_TRUE(a.SByte1  < b.SByte1)
							 && IS_TRUE(a.SByte2  < b.SByte2)
							 && IS_TRUE(a.SByte3  < b.SByte3);

				case  8: return IS_TRUE(a.SByte0  < b.SByte0)
							 && IS_TRUE(a.SByte1  < b.SByte1)
							 && IS_TRUE(a.SByte2  < b.SByte2)
							 && IS_TRUE(a.SByte3  < b.SByte3)
							 && IS_TRUE(a.SByte4  < b.SByte4)
							 && IS_TRUE(a.SByte5  < b.SByte5)
							 && IS_TRUE(a.SByte6  < b.SByte6)
							 && IS_TRUE(a.SByte7  < b.SByte7);

				default: return IS_TRUE(a.SByte0  < b.SByte0)
							 && IS_TRUE(a.SByte1  < b.SByte1)
							 && IS_TRUE(a.SByte2  < b.SByte2)
							 && IS_TRUE(a.SByte3  < b.SByte3)
							 && IS_TRUE(a.SByte4  < b.SByte4)
							 && IS_TRUE(a.SByte5  < b.SByte5)
							 && IS_TRUE(a.SByte6  < b.SByte6)
							 && IS_TRUE(a.SByte7  < b.SByte7)
							 && IS_TRUE(a.SByte8  < b.SByte8)
							 && IS_TRUE(a.SByte9  < b.SByte9)
							 && IS_TRUE(a.SByte10 < b.SByte10)
							 && IS_TRUE(a.SByte11 < b.SByte11)
							 && IS_TRUE(a.SByte12 < b.SByte12)
							 && IS_TRUE(a.SByte13 < b.SByte13)
							 && IS_TRUE(a.SByte14 < b.SByte14)
							 && IS_TRUE(a.SByte15 < b.SByte15);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_LT_EPI16(v128 a, v128 b, byte elements = 8)
		{
			switch (elements)
			{
				case  2: return IS_TRUE(a.SShort0 < b.SShort0)
							 && IS_TRUE(a.SShort1 < b.SShort1);

				case  3: return IS_TRUE(a.SShort0 < b.SShort0)
							 && IS_TRUE(a.SShort1 < b.SShort1)
							 && IS_TRUE(a.SShort2 < b.SShort2);

				case  4: return IS_TRUE(a.SShort0 < b.SShort0)
							 && IS_TRUE(a.SShort1 < b.SShort1)
							 && IS_TRUE(a.SShort2 < b.SShort2)
							 && IS_TRUE(a.SShort3 < b.SShort3);

				default: return IS_TRUE(a.SShort0 < b.SShort0)
							 && IS_TRUE(a.SShort1 < b.SShort1)
							 && IS_TRUE(a.SShort2 < b.SShort2)
							 && IS_TRUE(a.SShort3 < b.SShort3)
							 && IS_TRUE(a.SShort4 < b.SShort4)
							 && IS_TRUE(a.SShort5 < b.SShort5)
							 && IS_TRUE(a.SShort6 < b.SShort6)
							 && IS_TRUE(a.SShort7 < b.SShort7);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_LT_EPI32(v128 a, v128 b, byte elements = 4)
		{
			switch (elements)
			{
				case  2: return IS_TRUE(a.SInt0 < b.SInt0)
							 && IS_TRUE(a.SInt1 < b.SInt1);

				case  3: return IS_TRUE(a.SInt0 < b.SInt0)
							 && IS_TRUE(a.SInt1 < b.SInt1)
							 && IS_TRUE(a.SInt2 < b.SInt2);

				default: return IS_TRUE(a.SInt0 < b.SInt0)
							 && IS_TRUE(a.SInt1 < b.SInt1)
							 && IS_TRUE(a.SInt2 < b.SInt2)
							 && IS_TRUE(a.SInt3 < b.SInt3);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_LT_EPI64(v128 a, v128 b)
		{
			return IS_TRUE(a.SLong0 < b.SLong0)
				&& IS_TRUE(a.SLong1 < b.SLong1);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_LT_PS(v128 a, v128 b, byte elements = 4)
		{
			switch (elements)
			{
				case  1: return IS_TRUE(a.Float0 < b.Float0);

				case  2: return IS_TRUE(a.Float0 < b.Float0)
							 && IS_TRUE(a.Float1 < b.Float1);

				case  3: return IS_TRUE(a.Float0 < b.Float0)
							 && IS_TRUE(a.Float1 < b.Float1)
							 && IS_TRUE(a.Float2 < b.Float2);

				default: return IS_TRUE(a.Float0 < b.Float0)
							 && IS_TRUE(a.Float1 < b.Float1)
							 && IS_TRUE(a.Float2 < b.Float2)
							 && IS_TRUE(a.Float3 < b.Float3);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_LT_PD(v128 a, v128 b)
		{
			return IS_TRUE(a.Double0 < b.Double0)
				&& IS_TRUE(a.Double1 < b.Double1);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_LT_EPI8(v256 a, v256 b)
		{
			return IS_TRUE(a.SByte0  < b.SByte0)
				&& IS_TRUE(a.SByte1  < b.SByte1)
				&& IS_TRUE(a.SByte2  < b.SByte2)
				&& IS_TRUE(a.SByte3  < b.SByte3)
				&& IS_TRUE(a.SByte4  < b.SByte4)
				&& IS_TRUE(a.SByte5  < b.SByte5)
				&& IS_TRUE(a.SByte6  < b.SByte6)
				&& IS_TRUE(a.SByte7  < b.SByte7)
				&& IS_TRUE(a.SByte8  < b.SByte8)
				&& IS_TRUE(a.SByte9  < b.SByte9)
				&& IS_TRUE(a.SByte10 < b.SByte10)
				&& IS_TRUE(a.SByte11 < b.SByte11)
				&& IS_TRUE(a.SByte12 < b.SByte12)
				&& IS_TRUE(a.SByte13 < b.SByte13)
				&& IS_TRUE(a.SByte14 < b.SByte14)
				&& IS_TRUE(a.SByte15 < b.SByte15)
			    && IS_TRUE(a.SByte16 < b.SByte16)
				&& IS_TRUE(a.SByte17 < b.SByte17)
				&& IS_TRUE(a.SByte18 < b.SByte18)
				&& IS_TRUE(a.SByte19 < b.SByte19)
				&& IS_TRUE(a.SByte20 < b.SByte20)
				&& IS_TRUE(a.SByte21 < b.SByte21)
				&& IS_TRUE(a.SByte22 < b.SByte22)
				&& IS_TRUE(a.SByte23 < b.SByte23)
				&& IS_TRUE(a.SByte24 < b.SByte24)
				&& IS_TRUE(a.SByte25 < b.SByte25)
				&& IS_TRUE(a.SByte26 < b.SByte26)
				&& IS_TRUE(a.SByte27 < b.SByte27)
				&& IS_TRUE(a.SByte28 < b.SByte28)
				&& IS_TRUE(a.SByte29 < b.SByte29)
				&& IS_TRUE(a.SByte30 < b.SByte30)
				&& IS_TRUE(a.SByte31 < b.SByte31);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_LT_EPI16(v256 a, v256 b)
		{
			return IS_TRUE(a.SShort0  < b.SShort0)
				&& IS_TRUE(a.SShort1  < b.SShort1)
				&& IS_TRUE(a.SShort2  < b.SShort2)
				&& IS_TRUE(a.SShort3  < b.SShort3)
				&& IS_TRUE(a.SShort4  < b.SShort4)
				&& IS_TRUE(a.SShort5  < b.SShort5)
				&& IS_TRUE(a.SShort6  < b.SShort6)
				&& IS_TRUE(a.SShort7  < b.SShort7)
				&& IS_TRUE(a.SShort8  < b.SShort8)
				&& IS_TRUE(a.SShort9  < b.SShort9)
				&& IS_TRUE(a.SShort10 < b.SShort10)
				&& IS_TRUE(a.SShort11 < b.SShort11)
				&& IS_TRUE(a.SShort12 < b.SShort12)
				&& IS_TRUE(a.SShort13 < b.SShort13)
				&& IS_TRUE(a.SShort14 < b.SShort14)
				&& IS_TRUE(a.SShort15 < b.SShort15);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_LT_EPI32(v256 a, v256 b)
		{
			return IS_TRUE(a.SInt0 < b.SInt0)
				&& IS_TRUE(a.SInt1 < b.SInt1)
				&& IS_TRUE(a.SInt2 < b.SInt2)
				&& IS_TRUE(a.SInt3 < b.SInt3)
				&& IS_TRUE(a.SInt4 < b.SInt4)
				&& IS_TRUE(a.SInt5 < b.SInt5)
				&& IS_TRUE(a.SInt6 < b.SInt6)
				&& IS_TRUE(a.SInt7 < b.SInt7);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_LT_EPI64(v256 a, v256 b, byte elements = 4)
		{
			if (elements == 3)
			{
				return IS_TRUE(a.SLong0 < b.SLong0)
					&& IS_TRUE(a.SLong1 < b.SLong1)
					&& IS_TRUE(a.SLong2 < b.SLong2);
			}
			else
			{
				return IS_TRUE(a.SLong0 < b.SLong0)
					&& IS_TRUE(a.SLong1 < b.SLong1)
					&& IS_TRUE(a.SLong2 < b.SLong2)
					&& IS_TRUE(a.SLong3 < b.SLong3);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_LT_EPU8(v256 a, v256 b)
		{
			return IS_TRUE(a.Byte0  < b.Byte0)
				&& IS_TRUE(a.Byte1  < b.Byte1)
				&& IS_TRUE(a.Byte2  < b.Byte2)
				&& IS_TRUE(a.Byte3  < b.Byte3)
				&& IS_TRUE(a.Byte4  < b.Byte4)
				&& IS_TRUE(a.Byte5  < b.Byte5)
				&& IS_TRUE(a.Byte6  < b.Byte6)
				&& IS_TRUE(a.Byte7  < b.Byte7)
				&& IS_TRUE(a.Byte8  < b.Byte8)
				&& IS_TRUE(a.Byte9  < b.Byte9)
				&& IS_TRUE(a.Byte10 < b.Byte10)
				&& IS_TRUE(a.Byte11 < b.Byte11)
				&& IS_TRUE(a.Byte12 < b.Byte12)
				&& IS_TRUE(a.Byte13 < b.Byte13)
				&& IS_TRUE(a.Byte14 < b.Byte14)
				&& IS_TRUE(a.Byte15 < b.Byte15)
			    && IS_TRUE(a.Byte16 < b.Byte16)
				&& IS_TRUE(a.Byte17 < b.Byte17)
				&& IS_TRUE(a.Byte18 < b.Byte18)
				&& IS_TRUE(a.Byte19 < b.Byte19)
				&& IS_TRUE(a.Byte20 < b.Byte20)
				&& IS_TRUE(a.Byte21 < b.Byte21)
				&& IS_TRUE(a.Byte22 < b.Byte22)
				&& IS_TRUE(a.Byte23 < b.Byte23)
				&& IS_TRUE(a.Byte24 < b.Byte24)
				&& IS_TRUE(a.Byte25 < b.Byte25)
				&& IS_TRUE(a.Byte26 < b.Byte26)
				&& IS_TRUE(a.Byte27 < b.Byte27)
				&& IS_TRUE(a.Byte28 < b.Byte28)
				&& IS_TRUE(a.Byte29 < b.Byte29)
				&& IS_TRUE(a.Byte30 < b.Byte30)
				&& IS_TRUE(a.Byte31 < b.Byte31);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_LT_EPU16(v256 a, v256 b)
		{
			return IS_TRUE(a.UShort0  < b.UShort0)
				&& IS_TRUE(a.UShort1  < b.UShort1)
				&& IS_TRUE(a.UShort2  < b.UShort2)
				&& IS_TRUE(a.UShort3  < b.UShort3)
				&& IS_TRUE(a.UShort4  < b.UShort4)
				&& IS_TRUE(a.UShort5  < b.UShort5)
				&& IS_TRUE(a.UShort6  < b.UShort6)
				&& IS_TRUE(a.UShort7  < b.UShort7)
				&& IS_TRUE(a.UShort8  < b.UShort8)
				&& IS_TRUE(a.UShort9  < b.UShort9)
				&& IS_TRUE(a.UShort10 < b.UShort10)
				&& IS_TRUE(a.UShort11 < b.UShort11)
				&& IS_TRUE(a.UShort12 < b.UShort12)
				&& IS_TRUE(a.UShort13 < b.UShort13)
				&& IS_TRUE(a.UShort14 < b.UShort14)
				&& IS_TRUE(a.UShort15 < b.UShort15);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_LT_EPU32(v256 a, v256 b)
		{
			return IS_TRUE(a.UInt0 < b.UInt0)
				&& IS_TRUE(a.UInt1 < b.UInt1)
				&& IS_TRUE(a.UInt2 < b.UInt2)
				&& IS_TRUE(a.UInt3 < b.UInt3)
				&& IS_TRUE(a.UInt4 < b.UInt4)
				&& IS_TRUE(a.UInt5 < b.UInt5)
				&& IS_TRUE(a.UInt6 < b.UInt6)
				&& IS_TRUE(a.UInt7 < b.UInt7);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_LT_EPU64(v256 a, v256 b, byte elements = 4)
		{
			if (elements == 3)
			{
				return IS_TRUE(a.ULong0 < b.ULong0)
					&& IS_TRUE(a.ULong1 < b.ULong1)
					&& IS_TRUE(a.ULong2 < b.ULong2);
			}
			else
			{
				return IS_TRUE(a.ULong0 < b.ULong0)
					&& IS_TRUE(a.ULong1 < b.ULong1)
					&& IS_TRUE(a.ULong2 < b.ULong2)
					&& IS_TRUE(a.ULong3 < b.ULong3);
			}
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_LT_PS(v256 a, v256 b)
		{
			return IS_TRUE(a.Float0 < b.Float0)
				&& IS_TRUE(a.Float1 < b.Float1)
				&& IS_TRUE(a.Float2 < b.Float2)
				&& IS_TRUE(a.Float3 < b.Float3)
				&& IS_TRUE(a.Float4 < b.Float4)
				&& IS_TRUE(a.Float5 < b.Float5)
				&& IS_TRUE(a.Float6 < b.Float6)
				&& IS_TRUE(a.Float7 < b.Float7);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_LT_PD(v256 a, v256 b, byte elements = 4)
		{
			if (elements == 3)
			{
				return IS_TRUE(a.Double0 < b.Double0)
					&& IS_TRUE(a.Double1 < b.Double1)
					&& IS_TRUE(a.Double2 < b.Double2);
			}
			else
			{
				return IS_TRUE(a.Double0 < b.Double0)
					&& IS_TRUE(a.Double1 < b.Double1)
					&& IS_TRUE(a.Double2 < b.Double2)
					&& IS_TRUE(a.Double3 < b.Double3);
			}
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_GE_EPU8(v128 a, v128 b, byte elements = 16)
		{
			switch (elements)
			{
				case  2: return IS_TRUE(a.Byte0  >= b.Byte0)
							 && IS_TRUE(a.Byte1  >= b.Byte1);

				case  3: return IS_TRUE(a.Byte0  >= b.Byte0)
							 && IS_TRUE(a.Byte1  >= b.Byte1)
							 && IS_TRUE(a.Byte2  >= b.Byte2);

				case  4: return IS_TRUE(a.Byte0  >= b.Byte0)
							 && IS_TRUE(a.Byte1  >= b.Byte1)
							 && IS_TRUE(a.Byte2  >= b.Byte2)
							 && IS_TRUE(a.Byte3  >= b.Byte3);

				case  8: return IS_TRUE(a.Byte0  >= b.Byte0)
							 && IS_TRUE(a.Byte1  >= b.Byte1)
							 && IS_TRUE(a.Byte2  >= b.Byte2)
							 && IS_TRUE(a.Byte3  >= b.Byte3)
							 && IS_TRUE(a.Byte4  >= b.Byte4)
							 && IS_TRUE(a.Byte5  >= b.Byte5)
							 && IS_TRUE(a.Byte6  >= b.Byte6)
							 && IS_TRUE(a.Byte7  >= b.Byte7);

				default: return IS_TRUE(a.Byte0  >= b.Byte0)
							 && IS_TRUE(a.Byte1  >= b.Byte1)
							 && IS_TRUE(a.Byte2  >= b.Byte2)
							 && IS_TRUE(a.Byte3  >= b.Byte3)
							 && IS_TRUE(a.Byte4  >= b.Byte4)
							 && IS_TRUE(a.Byte5  >= b.Byte5)
							 && IS_TRUE(a.Byte6  >= b.Byte6)
							 && IS_TRUE(a.Byte7  >= b.Byte7)
							 && IS_TRUE(a.Byte8  >= b.Byte8)
							 && IS_TRUE(a.Byte9  >= b.Byte9)
							 && IS_TRUE(a.Byte10 >= b.Byte10)
							 && IS_TRUE(a.Byte11 >= b.Byte11)
							 && IS_TRUE(a.Byte12 >= b.Byte12)
							 && IS_TRUE(a.Byte13 >= b.Byte13)
							 && IS_TRUE(a.Byte14 >= b.Byte14)
							 && IS_TRUE(a.Byte15 >= b.Byte15);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_GE_EPU16(v128 a, v128 b, byte elements = 8)
		{
			switch (elements)
			{
				case  2: return IS_TRUE(a.UShort0  >= b.UShort0)
							 && IS_TRUE(a.UShort1  >= b.UShort1);

				case  3: return IS_TRUE(a.UShort0  >= b.UShort0)
							 && IS_TRUE(a.UShort1  >= b.UShort1)
							 && IS_TRUE(a.UShort2  >= b.UShort2);

				case  4: return IS_TRUE(a.UShort0  >= b.UShort0)
							 && IS_TRUE(a.UShort1  >= b.UShort1)
							 && IS_TRUE(a.UShort2  >= b.UShort2)
							 && IS_TRUE(a.UShort3  >= b.UShort3);

				default: return IS_TRUE(a.UShort0  >= b.UShort0)
							 && IS_TRUE(a.UShort1  >= b.UShort1)
							 && IS_TRUE(a.UShort2  >= b.UShort2)
							 && IS_TRUE(a.UShort3  >= b.UShort3)
							 && IS_TRUE(a.UShort4  >= b.UShort4)
							 && IS_TRUE(a.UShort5  >= b.UShort5)
							 && IS_TRUE(a.UShort6  >= b.UShort6)
							 && IS_TRUE(a.UShort7  >= b.UShort7);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_GE_EPU32(v128 a, v128 b, byte elements = 4)
		{
			switch (elements)
			{
				case  2: return IS_TRUE(a.UInt0  >= b.UInt0)
							 && IS_TRUE(a.UInt1  >= b.UInt1);

				case  3: return IS_TRUE(a.UInt0  >= b.UInt0)
							 && IS_TRUE(a.UInt1  >= b.UInt1)
							 && IS_TRUE(a.UInt2  >= b.UInt2);

				default: return IS_TRUE(a.UInt0  >= b.UInt0)
							 && IS_TRUE(a.UInt1  >= b.UInt1)
							 && IS_TRUE(a.UInt2  >= b.UInt2)
							 && IS_TRUE(a.UInt3  >= b.UInt3);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_GE_EPU64(v128 a, v128 b)
		{
			return IS_TRUE(a.ULong0 >= b.ULong0)
				&& IS_TRUE(a.ULong1 >= b.ULong1);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_GE_EPI8(v128 a, v128 b, byte elements = 16)
		{
			switch (elements)
			{
				case  2: return IS_TRUE(a.SByte0  >= b.SByte0)
							 && IS_TRUE(a.SByte1  >= b.SByte1);

				case  3: return IS_TRUE(a.SByte0  >= b.SByte0)
							 && IS_TRUE(a.SByte1  >= b.SByte1)
							 && IS_TRUE(a.SByte2  >= b.SByte2);

				case  4: return IS_TRUE(a.SByte0  >= b.SByte0)
							 && IS_TRUE(a.SByte1  >= b.SByte1)
							 && IS_TRUE(a.SByte2  >= b.SByte2)
							 && IS_TRUE(a.SByte3  >= b.SByte3);

				case  8: return IS_TRUE(a.SByte0  >= b.SByte0)
							 && IS_TRUE(a.SByte1  >= b.SByte1)
							 && IS_TRUE(a.SByte2  >= b.SByte2)
							 && IS_TRUE(a.SByte3  >= b.SByte3)
							 && IS_TRUE(a.SByte4  >= b.SByte4)
							 && IS_TRUE(a.SByte5  >= b.SByte5)
							 && IS_TRUE(a.SByte6  >= b.SByte6)
							 && IS_TRUE(a.SByte7  >= b.SByte7);

				default: return IS_TRUE(a.SByte0  >= b.SByte0)
							 && IS_TRUE(a.SByte1  >= b.SByte1)
							 && IS_TRUE(a.SByte2  >= b.SByte2)
							 && IS_TRUE(a.SByte3  >= b.SByte3)
							 && IS_TRUE(a.SByte4  >= b.SByte4)
							 && IS_TRUE(a.SByte5  >= b.SByte5)
							 && IS_TRUE(a.SByte6  >= b.SByte6)
							 && IS_TRUE(a.SByte7  >= b.SByte7)
							 && IS_TRUE(a.SByte8  >= b.SByte8)
							 && IS_TRUE(a.SByte9  >= b.SByte9)
							 && IS_TRUE(a.SByte10 >= b.SByte10)
							 && IS_TRUE(a.SByte11 >= b.SByte11)
							 && IS_TRUE(a.SByte12 >= b.SByte12)
							 && IS_TRUE(a.SByte13 >= b.SByte13)
							 && IS_TRUE(a.SByte14 >= b.SByte14)
							 && IS_TRUE(a.SByte15 >= b.SByte15);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_GE_EPI16(v128 a, v128 b, byte elements = 8)
		{
			switch (elements)
			{
				case  2: return IS_TRUE(a.SShort0 >= b.SShort0)
							 && IS_TRUE(a.SShort1 >= b.SShort1);

				case  3: return IS_TRUE(a.SShort0 >= b.SShort0)
							 && IS_TRUE(a.SShort1 >= b.SShort1)
							 && IS_TRUE(a.SShort2 >= b.SShort2);

				case  4: return IS_TRUE(a.SShort0 >= b.SShort0)
							 && IS_TRUE(a.SShort1 >= b.SShort1)
							 && IS_TRUE(a.SShort2 >= b.SShort2)
							 && IS_TRUE(a.SShort3 >= b.SShort3);

				default: return IS_TRUE(a.SShort0 >= b.SShort0)
							 && IS_TRUE(a.SShort1 >= b.SShort1)
							 && IS_TRUE(a.SShort2 >= b.SShort2)
							 && IS_TRUE(a.SShort3 >= b.SShort3)
							 && IS_TRUE(a.SShort4 >= b.SShort4)
							 && IS_TRUE(a.SShort5 >= b.SShort5)
							 && IS_TRUE(a.SShort6 >= b.SShort6)
							 && IS_TRUE(a.SShort7 >= b.SShort7);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_GE_EPI32(v128 a, v128 b, byte elements = 4)
		{
			switch (elements)
			{
				case  2: return IS_TRUE(a.SInt0 >= b.SInt0)
							 && IS_TRUE(a.SInt1 >= b.SInt1);

				case  3: return IS_TRUE(a.SInt0 >= b.SInt0)
							 && IS_TRUE(a.SInt1 >= b.SInt1)
							 && IS_TRUE(a.SInt2 >= b.SInt2);

				default: return IS_TRUE(a.SInt0 >= b.SInt0)
							 && IS_TRUE(a.SInt1 >= b.SInt1)
							 && IS_TRUE(a.SInt2 >= b.SInt2)
							 && IS_TRUE(a.SInt3 >= b.SInt3);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_GE_EPI64(v128 a, v128 b)
		{
			return IS_TRUE(a.SLong0 >= b.SLong0)
				&& IS_TRUE(a.SLong1 >= b.SLong1);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_GE_PS(v128 a, v128 b, byte elements = 4)
		{
			switch (elements)
			{
				case  1: return IS_TRUE(a.Float0 >= b.Float0);

				case  2: return IS_TRUE(a.Float0 >= b.Float0)
							 && IS_TRUE(a.Float1 >= b.Float1);

				case  3: return IS_TRUE(a.Float0 >= b.Float0)
							 && IS_TRUE(a.Float1 >= b.Float1)
							 && IS_TRUE(a.Float2 >= b.Float2);

				default: return IS_TRUE(a.Float0 >= b.Float0)
							 && IS_TRUE(a.Float1 >= b.Float1)
							 && IS_TRUE(a.Float2 >= b.Float2)
							 && IS_TRUE(a.Float3 >= b.Float3);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_GE_PD(v128 a, v128 b)
		{
			return IS_TRUE(a.Double0 >= b.Double0)
				&& IS_TRUE(a.Double1 >= b.Double1);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_GE_EPI8(v256 a, v256 b)
		{
			return IS_TRUE(a.SByte0  >= b.SByte0)
				&& IS_TRUE(a.SByte1  >= b.SByte1)
				&& IS_TRUE(a.SByte2  >= b.SByte2)
				&& IS_TRUE(a.SByte3  >= b.SByte3)
				&& IS_TRUE(a.SByte4  >= b.SByte4)
				&& IS_TRUE(a.SByte5  >= b.SByte5)
				&& IS_TRUE(a.SByte6  >= b.SByte6)
				&& IS_TRUE(a.SByte7  >= b.SByte7)
				&& IS_TRUE(a.SByte8  >= b.SByte8)
				&& IS_TRUE(a.SByte9  >= b.SByte9)
				&& IS_TRUE(a.SByte10 >= b.SByte10)
				&& IS_TRUE(a.SByte11 >= b.SByte11)
				&& IS_TRUE(a.SByte12 >= b.SByte12)
				&& IS_TRUE(a.SByte13 >= b.SByte13)
				&& IS_TRUE(a.SByte14 >= b.SByte14)
				&& IS_TRUE(a.SByte15 >= b.SByte15)
			    && IS_TRUE(a.SByte16 >= b.SByte16)
				&& IS_TRUE(a.SByte17 >= b.SByte17)
				&& IS_TRUE(a.SByte18 >= b.SByte18)
				&& IS_TRUE(a.SByte19 >= b.SByte19)
				&& IS_TRUE(a.SByte20 >= b.SByte20)
				&& IS_TRUE(a.SByte21 >= b.SByte21)
				&& IS_TRUE(a.SByte22 >= b.SByte22)
				&& IS_TRUE(a.SByte23 >= b.SByte23)
				&& IS_TRUE(a.SByte24 >= b.SByte24)
				&& IS_TRUE(a.SByte25 >= b.SByte25)
				&& IS_TRUE(a.SByte26 >= b.SByte26)
				&& IS_TRUE(a.SByte27 >= b.SByte27)
				&& IS_TRUE(a.SByte28 >= b.SByte28)
				&& IS_TRUE(a.SByte29 >= b.SByte29)
				&& IS_TRUE(a.SByte30 >= b.SByte30)
				&& IS_TRUE(a.SByte31 >= b.SByte31);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_GE_EPI16(v256 a, v256 b)
		{
			return IS_TRUE(a.SShort0  >= b.SShort0)
				&& IS_TRUE(a.SShort1  >= b.SShort1)
				&& IS_TRUE(a.SShort2  >= b.SShort2)
				&& IS_TRUE(a.SShort3  >= b.SShort3)
				&& IS_TRUE(a.SShort4  >= b.SShort4)
				&& IS_TRUE(a.SShort5  >= b.SShort5)
				&& IS_TRUE(a.SShort6  >= b.SShort6)
				&& IS_TRUE(a.SShort7  >= b.SShort7)
				&& IS_TRUE(a.SShort8  >= b.SShort8)
				&& IS_TRUE(a.SShort9  >= b.SShort9)
				&& IS_TRUE(a.SShort10 >= b.SShort10)
				&& IS_TRUE(a.SShort11 >= b.SShort11)
				&& IS_TRUE(a.SShort12 >= b.SShort12)
				&& IS_TRUE(a.SShort13 >= b.SShort13)
				&& IS_TRUE(a.SShort14 >= b.SShort14)
				&& IS_TRUE(a.SShort15 >= b.SShort15);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_GE_EPI32(v256 a, v256 b)
		{
			return IS_TRUE(a.SInt0 >= b.SInt0)
				&& IS_TRUE(a.SInt1 >= b.SInt1)
				&& IS_TRUE(a.SInt2 >= b.SInt2)
				&& IS_TRUE(a.SInt3 >= b.SInt3)
				&& IS_TRUE(a.SInt4 >= b.SInt4)
				&& IS_TRUE(a.SInt5 >= b.SInt5)
				&& IS_TRUE(a.SInt6 >= b.SInt6)
				&& IS_TRUE(a.SInt7 >= b.SInt7);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_GE_EPI64(v256 a, v256 b, byte elements = 4)
		{
			if (elements == 3)
			{
				return IS_TRUE(a.SLong0 >= b.SLong0)
					&& IS_TRUE(a.SLong1 >= b.SLong1)
					&& IS_TRUE(a.SLong2 >= b.SLong2);
			}
			else
			{
				return IS_TRUE(a.SLong0 >= b.SLong0)
					&& IS_TRUE(a.SLong1 >= b.SLong1)
					&& IS_TRUE(a.SLong2 >= b.SLong2)
					&& IS_TRUE(a.SLong3 >= b.SLong3);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_GE_EPU8(v256 a, v256 b)
		{
			return IS_TRUE(a.Byte0  >= b.Byte0)
				&& IS_TRUE(a.Byte1  >= b.Byte1)
				&& IS_TRUE(a.Byte2  >= b.Byte2)
				&& IS_TRUE(a.Byte3  >= b.Byte3)
				&& IS_TRUE(a.Byte4  >= b.Byte4)
				&& IS_TRUE(a.Byte5  >= b.Byte5)
				&& IS_TRUE(a.Byte6  >= b.Byte6)
				&& IS_TRUE(a.Byte7  >= b.Byte7)
				&& IS_TRUE(a.Byte8  >= b.Byte8)
				&& IS_TRUE(a.Byte9  >= b.Byte9)
				&& IS_TRUE(a.Byte10 >= b.Byte10)
				&& IS_TRUE(a.Byte11 >= b.Byte11)
				&& IS_TRUE(a.Byte12 >= b.Byte12)
				&& IS_TRUE(a.Byte13 >= b.Byte13)
				&& IS_TRUE(a.Byte14 >= b.Byte14)
				&& IS_TRUE(a.Byte15 >= b.Byte15)
			    && IS_TRUE(a.Byte16 >= b.Byte16)
				&& IS_TRUE(a.Byte17 >= b.Byte17)
				&& IS_TRUE(a.Byte18 >= b.Byte18)
				&& IS_TRUE(a.Byte19 >= b.Byte19)
				&& IS_TRUE(a.Byte20 >= b.Byte20)
				&& IS_TRUE(a.Byte21 >= b.Byte21)
				&& IS_TRUE(a.Byte22 >= b.Byte22)
				&& IS_TRUE(a.Byte23 >= b.Byte23)
				&& IS_TRUE(a.Byte24 >= b.Byte24)
				&& IS_TRUE(a.Byte25 >= b.Byte25)
				&& IS_TRUE(a.Byte26 >= b.Byte26)
				&& IS_TRUE(a.Byte27 >= b.Byte27)
				&& IS_TRUE(a.Byte28 >= b.Byte28)
				&& IS_TRUE(a.Byte29 >= b.Byte29)
				&& IS_TRUE(a.Byte30 >= b.Byte30)
				&& IS_TRUE(a.Byte31 >= b.Byte31);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_GE_EPU16(v256 a, v256 b)
		{
			return IS_TRUE(a.UShort0  >= b.UShort0)
				&& IS_TRUE(a.UShort1  >= b.UShort1)
				&& IS_TRUE(a.UShort2  >= b.UShort2)
				&& IS_TRUE(a.UShort3  >= b.UShort3)
				&& IS_TRUE(a.UShort4  >= b.UShort4)
				&& IS_TRUE(a.UShort5  >= b.UShort5)
				&& IS_TRUE(a.UShort6  >= b.UShort6)
				&& IS_TRUE(a.UShort7  >= b.UShort7)
				&& IS_TRUE(a.UShort8  >= b.UShort8)
				&& IS_TRUE(a.UShort9  >= b.UShort9)
				&& IS_TRUE(a.UShort10 >= b.UShort10)
				&& IS_TRUE(a.UShort11 >= b.UShort11)
				&& IS_TRUE(a.UShort12 >= b.UShort12)
				&& IS_TRUE(a.UShort13 >= b.UShort13)
				&& IS_TRUE(a.UShort14 >= b.UShort14)
				&& IS_TRUE(a.UShort15 >= b.UShort15);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_GE_EPU32(v256 a, v256 b)
		{
			return IS_TRUE(a.UInt0 >= b.UInt0)
				&& IS_TRUE(a.UInt1 >= b.UInt1)
				&& IS_TRUE(a.UInt2 >= b.UInt2)
				&& IS_TRUE(a.UInt3 >= b.UInt3)
				&& IS_TRUE(a.UInt4 >= b.UInt4)
				&& IS_TRUE(a.UInt5 >= b.UInt5)
				&& IS_TRUE(a.UInt6 >= b.UInt6)
				&& IS_TRUE(a.UInt7 >= b.UInt7);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_GE_EPU64(v256 a, v256 b, byte elements = 4)
		{
			if (elements == 3)
			{
				return IS_TRUE(a.ULong0 >= b.ULong0)
					&& IS_TRUE(a.ULong1 >= b.ULong1)
					&& IS_TRUE(a.ULong2 >= b.ULong2);
			}
			else
			{
				return IS_TRUE(a.ULong0 >= b.ULong0)
					&& IS_TRUE(a.ULong1 >= b.ULong1)
					&& IS_TRUE(a.ULong2 >= b.ULong2)
					&& IS_TRUE(a.ULong3 >= b.ULong3);
			}
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_GE_PS(v256 a, v256 b)
		{
			return IS_TRUE(a.Float0 >= b.Float0)
				&& IS_TRUE(a.Float1 >= b.Float1)
				&& IS_TRUE(a.Float2 >= b.Float2)
				&& IS_TRUE(a.Float3 >= b.Float3)
				&& IS_TRUE(a.Float4 >= b.Float4)
				&& IS_TRUE(a.Float5 >= b.Float5)
				&& IS_TRUE(a.Float6 >= b.Float6)
				&& IS_TRUE(a.Float7 >= b.Float7);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_GE_PD(v256 a, v256 b, byte elements = 4)
		{
			if (elements == 3)
			{
				return IS_TRUE(a.Double0 >= b.Double0)
					&& IS_TRUE(a.Double1 >= b.Double1)
					&& IS_TRUE(a.Double2 >= b.Double2);
			}
			else
			{
				return IS_TRUE(a.Double0 >= b.Double0)
					&& IS_TRUE(a.Double1 >= b.Double1)
					&& IS_TRUE(a.Double2 >= b.Double2)
					&& IS_TRUE(a.Double3 >= b.Double3);
			}
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_LE_EPU8(v128 a, v128 b, byte elements = 16)
		{
			switch (elements)
			{
				case  2: return IS_TRUE(a.Byte0  <= b.Byte0)
							 && IS_TRUE(a.Byte1  <= b.Byte1);

				case  3: return IS_TRUE(a.Byte0  <= b.Byte0)
							 && IS_TRUE(a.Byte1  <= b.Byte1)
							 && IS_TRUE(a.Byte2  <= b.Byte2);

				case  4: return IS_TRUE(a.Byte0  <= b.Byte0)
							 && IS_TRUE(a.Byte1  <= b.Byte1)
							 && IS_TRUE(a.Byte2  <= b.Byte2)
							 && IS_TRUE(a.Byte3  <= b.Byte3);

				case  8: return IS_TRUE(a.Byte0  <= b.Byte0)
							 && IS_TRUE(a.Byte1  <= b.Byte1)
							 && IS_TRUE(a.Byte2  <= b.Byte2)
							 && IS_TRUE(a.Byte3  <= b.Byte3)
							 && IS_TRUE(a.Byte4  <= b.Byte4)
							 && IS_TRUE(a.Byte5  <= b.Byte5)
							 && IS_TRUE(a.Byte6  <= b.Byte6)
							 && IS_TRUE(a.Byte7  <= b.Byte7);

				default: return IS_TRUE(a.Byte0  <= b.Byte0)
							 && IS_TRUE(a.Byte1  <= b.Byte1)
							 && IS_TRUE(a.Byte2  <= b.Byte2)
							 && IS_TRUE(a.Byte3  <= b.Byte3)
							 && IS_TRUE(a.Byte4  <= b.Byte4)
							 && IS_TRUE(a.Byte5  <= b.Byte5)
							 && IS_TRUE(a.Byte6  <= b.Byte6)
							 && IS_TRUE(a.Byte7  <= b.Byte7)
							 && IS_TRUE(a.Byte8  <= b.Byte8)
							 && IS_TRUE(a.Byte9  <= b.Byte9)
							 && IS_TRUE(a.Byte10 <= b.Byte10)
							 && IS_TRUE(a.Byte11 <= b.Byte11)
							 && IS_TRUE(a.Byte12 <= b.Byte12)
							 && IS_TRUE(a.Byte13 <= b.Byte13)
							 && IS_TRUE(a.Byte14 <= b.Byte14)
							 && IS_TRUE(a.Byte15 <= b.Byte15);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_LE_EPU16(v128 a, v128 b, byte elements = 8)
		{
			switch (elements)
			{
				case  2: return IS_TRUE(a.UShort0  <= b.UShort0)
							 && IS_TRUE(a.UShort1  <= b.UShort1);

				case  3: return IS_TRUE(a.UShort0  <= b.UShort0)
							 && IS_TRUE(a.UShort1  <= b.UShort1)
							 && IS_TRUE(a.UShort2  <= b.UShort2);

				case  4: return IS_TRUE(a.UShort0  <= b.UShort0)
							 && IS_TRUE(a.UShort1  <= b.UShort1)
							 && IS_TRUE(a.UShort2  <= b.UShort2)
							 && IS_TRUE(a.UShort3  <= b.UShort3);

				default: return IS_TRUE(a.UShort0  <= b.UShort0)
							 && IS_TRUE(a.UShort1  <= b.UShort1)
							 && IS_TRUE(a.UShort2  <= b.UShort2)
							 && IS_TRUE(a.UShort3  <= b.UShort3)
							 && IS_TRUE(a.UShort4  <= b.UShort4)
							 && IS_TRUE(a.UShort5  <= b.UShort5)
							 && IS_TRUE(a.UShort6  <= b.UShort6)
							 && IS_TRUE(a.UShort7  <= b.UShort7);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_LE_EPU32(v128 a, v128 b, byte elements = 4)
		{
			switch (elements)
			{
				case  2: return IS_TRUE(a.UInt0  <= b.UInt0)
							 && IS_TRUE(a.UInt1  <= b.UInt1);

				case  3: return IS_TRUE(a.UInt0  <= b.UInt0)
							 && IS_TRUE(a.UInt1  <= b.UInt1)
							 && IS_TRUE(a.UInt2  <= b.UInt2);

				default: return IS_TRUE(a.UInt0  <= b.UInt0)
							 && IS_TRUE(a.UInt1  <= b.UInt1)
							 && IS_TRUE(a.UInt2  <= b.UInt2)
							 && IS_TRUE(a.UInt3  <= b.UInt3);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_LE_EPU64(v128 a, v128 b)
		{
			return IS_TRUE(a.ULong0 <= b.ULong0)
				&& IS_TRUE(a.ULong1 <= b.ULong1);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_LE_EPI8(v128 a, v128 b, byte elements = 16)
		{
			switch (elements)
			{
				case  2: return IS_TRUE(a.SByte0  <= b.SByte0)
							 && IS_TRUE(a.SByte1  <= b.SByte1);

				case  3: return IS_TRUE(a.SByte0  <= b.SByte0)
							 && IS_TRUE(a.SByte1  <= b.SByte1)
							 && IS_TRUE(a.SByte2  <= b.SByte2);

				case  4: return IS_TRUE(a.SByte0  <= b.SByte0)
							 && IS_TRUE(a.SByte1  <= b.SByte1)
							 && IS_TRUE(a.SByte2  <= b.SByte2)
							 && IS_TRUE(a.SByte3  <= b.SByte3);

				case  8: return IS_TRUE(a.SByte0  <= b.SByte0)
							 && IS_TRUE(a.SByte1  <= b.SByte1)
							 && IS_TRUE(a.SByte2  <= b.SByte2)
							 && IS_TRUE(a.SByte3  <= b.SByte3)
							 && IS_TRUE(a.SByte4  <= b.SByte4)
							 && IS_TRUE(a.SByte5  <= b.SByte5)
							 && IS_TRUE(a.SByte6  <= b.SByte6)
							 && IS_TRUE(a.SByte7  <= b.SByte7);

				default: return IS_TRUE(a.SByte0  <= b.SByte0)
							 && IS_TRUE(a.SByte1  <= b.SByte1)
							 && IS_TRUE(a.SByte2  <= b.SByte2)
							 && IS_TRUE(a.SByte3  <= b.SByte3)
							 && IS_TRUE(a.SByte4  <= b.SByte4)
							 && IS_TRUE(a.SByte5  <= b.SByte5)
							 && IS_TRUE(a.SByte6  <= b.SByte6)
							 && IS_TRUE(a.SByte7  <= b.SByte7)
							 && IS_TRUE(a.SByte8  <= b.SByte8)
							 && IS_TRUE(a.SByte9  <= b.SByte9)
							 && IS_TRUE(a.SByte10 <= b.SByte10)
							 && IS_TRUE(a.SByte11 <= b.SByte11)
							 && IS_TRUE(a.SByte12 <= b.SByte12)
							 && IS_TRUE(a.SByte13 <= b.SByte13)
							 && IS_TRUE(a.SByte14 <= b.SByte14)
							 && IS_TRUE(a.SByte15 <= b.SByte15);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_LE_EPI16(v128 a, v128 b, byte elements = 8)
		{
			switch (elements)
			{
				case  2: return IS_TRUE(a.SShort0 <= b.SShort0)
							 && IS_TRUE(a.SShort1 <= b.SShort1);

				case  3: return IS_TRUE(a.SShort0 <= b.SShort0)
							 && IS_TRUE(a.SShort1 <= b.SShort1)
							 && IS_TRUE(a.SShort2 <= b.SShort2);

				case  4: return IS_TRUE(a.SShort0 <= b.SShort0)
							 && IS_TRUE(a.SShort1 <= b.SShort1)
							 && IS_TRUE(a.SShort2 <= b.SShort2)
							 && IS_TRUE(a.SShort3 <= b.SShort3);

				default: return IS_TRUE(a.SShort0 <= b.SShort0)
							 && IS_TRUE(a.SShort1 <= b.SShort1)
							 && IS_TRUE(a.SShort2 <= b.SShort2)
							 && IS_TRUE(a.SShort3 <= b.SShort3)
							 && IS_TRUE(a.SShort4 <= b.SShort4)
							 && IS_TRUE(a.SShort5 <= b.SShort5)
							 && IS_TRUE(a.SShort6 <= b.SShort6)
							 && IS_TRUE(a.SShort7 <= b.SShort7);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_LE_EPI32(v128 a, v128 b, byte elements = 4)
		{
			switch (elements)
			{
				case  2: return IS_TRUE(a.SInt0 <= b.SInt0)
							 && IS_TRUE(a.SInt1 <= b.SInt1);

				case  3: return IS_TRUE(a.SInt0 <= b.SInt0)
							 && IS_TRUE(a.SInt1 <= b.SInt1)
							 && IS_TRUE(a.SInt2 <= b.SInt2);

				default: return IS_TRUE(a.SInt0 <= b.SInt0)
							 && IS_TRUE(a.SInt1 <= b.SInt1)
							 && IS_TRUE(a.SInt2 <= b.SInt2)
							 && IS_TRUE(a.SInt3 <= b.SInt3);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_LE_EPI64(v128 a, v128 b)
		{
			return IS_TRUE(a.SLong0 <= b.SLong0)
				&& IS_TRUE(a.SLong1 <= b.SLong1);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_LE_PS(v128 a, v128 b, byte elements = 4)
		{
			switch (elements)
			{
				case  1: return IS_TRUE(a.Float0 <= b.Float0);

				case  2: return IS_TRUE(a.Float0 <= b.Float0)
							 && IS_TRUE(a.Float1 <= b.Float1);

				case  3: return IS_TRUE(a.Float0 <= b.Float0)
							 && IS_TRUE(a.Float1 <= b.Float1)
							 && IS_TRUE(a.Float2 <= b.Float2);

				default: return IS_TRUE(a.Float0 <= b.Float0)
							 && IS_TRUE(a.Float1 <= b.Float1)
							 && IS_TRUE(a.Float2 <= b.Float2)
							 && IS_TRUE(a.Float3 <= b.Float3);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_LE_PD(v128 a, v128 b)
		{
			return IS_TRUE(a.Double0 <= b.Double0)
				&& IS_TRUE(a.Double1 <= b.Double1);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_LE_EPI8(v256 a, v256 b)
		{
			return IS_TRUE(a.SByte0  <= b.SByte0)
				&& IS_TRUE(a.SByte1  <= b.SByte1)
				&& IS_TRUE(a.SByte2  <= b.SByte2)
				&& IS_TRUE(a.SByte3  <= b.SByte3)
				&& IS_TRUE(a.SByte4  <= b.SByte4)
				&& IS_TRUE(a.SByte5  <= b.SByte5)
				&& IS_TRUE(a.SByte6  <= b.SByte6)
				&& IS_TRUE(a.SByte7  <= b.SByte7)
				&& IS_TRUE(a.SByte8  <= b.SByte8)
				&& IS_TRUE(a.SByte9  <= b.SByte9)
				&& IS_TRUE(a.SByte10 <= b.SByte10)
				&& IS_TRUE(a.SByte11 <= b.SByte11)
				&& IS_TRUE(a.SByte12 <= b.SByte12)
				&& IS_TRUE(a.SByte13 <= b.SByte13)
				&& IS_TRUE(a.SByte14 <= b.SByte14)
				&& IS_TRUE(a.SByte15 <= b.SByte15)
			    && IS_TRUE(a.SByte16 <= b.SByte16)
				&& IS_TRUE(a.SByte17 <= b.SByte17)
				&& IS_TRUE(a.SByte18 <= b.SByte18)
				&& IS_TRUE(a.SByte19 <= b.SByte19)
				&& IS_TRUE(a.SByte20 <= b.SByte20)
				&& IS_TRUE(a.SByte21 <= b.SByte21)
				&& IS_TRUE(a.SByte22 <= b.SByte22)
				&& IS_TRUE(a.SByte23 <= b.SByte23)
				&& IS_TRUE(a.SByte24 <= b.SByte24)
				&& IS_TRUE(a.SByte25 <= b.SByte25)
				&& IS_TRUE(a.SByte26 <= b.SByte26)
				&& IS_TRUE(a.SByte27 <= b.SByte27)
				&& IS_TRUE(a.SByte28 <= b.SByte28)
				&& IS_TRUE(a.SByte29 <= b.SByte29)
				&& IS_TRUE(a.SByte30 <= b.SByte30)
				&& IS_TRUE(a.SByte31 <= b.SByte31);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_LE_EPI16(v256 a, v256 b)
		{
			return IS_TRUE(a.SShort0  <= b.SShort0)
				&& IS_TRUE(a.SShort1  <= b.SShort1)
				&& IS_TRUE(a.SShort2  <= b.SShort2)
				&& IS_TRUE(a.SShort3  <= b.SShort3)
				&& IS_TRUE(a.SShort4  <= b.SShort4)
				&& IS_TRUE(a.SShort5  <= b.SShort5)
				&& IS_TRUE(a.SShort6  <= b.SShort6)
				&& IS_TRUE(a.SShort7  <= b.SShort7)
				&& IS_TRUE(a.SShort8  <= b.SShort8)
				&& IS_TRUE(a.SShort9  <= b.SShort9)
				&& IS_TRUE(a.SShort10 <= b.SShort10)
				&& IS_TRUE(a.SShort11 <= b.SShort11)
				&& IS_TRUE(a.SShort12 <= b.SShort12)
				&& IS_TRUE(a.SShort13 <= b.SShort13)
				&& IS_TRUE(a.SShort14 <= b.SShort14)
				&& IS_TRUE(a.SShort15 <= b.SShort15);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_LE_EPI32(v256 a, v256 b)
		{
			return IS_TRUE(a.SInt0 <= b.SInt0)
				&& IS_TRUE(a.SInt1 <= b.SInt1)
				&& IS_TRUE(a.SInt2 <= b.SInt2)
				&& IS_TRUE(a.SInt3 <= b.SInt3)
				&& IS_TRUE(a.SInt4 <= b.SInt4)
				&& IS_TRUE(a.SInt5 <= b.SInt5)
				&& IS_TRUE(a.SInt6 <= b.SInt6)
				&& IS_TRUE(a.SInt7 <= b.SInt7);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_LE_EPI64(v256 a, v256 b, byte elements = 4)
		{
			if (elements == 3)
			{
				return IS_TRUE(a.SLong0 <= b.SLong0)
					&& IS_TRUE(a.SLong1 <= b.SLong1)
					&& IS_TRUE(a.SLong2 <= b.SLong2);
			}
			else
			{
				return IS_TRUE(a.SLong0 <= b.SLong0)
					&& IS_TRUE(a.SLong1 <= b.SLong1)
					&& IS_TRUE(a.SLong2 <= b.SLong2)
					&& IS_TRUE(a.SLong3 <= b.SLong3);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_LE_EPU8(v256 a, v256 b)
		{
			return IS_TRUE(a.Byte0  <= b.Byte0)
				&& IS_TRUE(a.Byte1  <= b.Byte1)
				&& IS_TRUE(a.Byte2  <= b.Byte2)
				&& IS_TRUE(a.Byte3  <= b.Byte3)
				&& IS_TRUE(a.Byte4  <= b.Byte4)
				&& IS_TRUE(a.Byte5  <= b.Byte5)
				&& IS_TRUE(a.Byte6  <= b.Byte6)
				&& IS_TRUE(a.Byte7  <= b.Byte7)
				&& IS_TRUE(a.Byte8  <= b.Byte8)
				&& IS_TRUE(a.Byte9  <= b.Byte9)
				&& IS_TRUE(a.Byte10 <= b.Byte10)
				&& IS_TRUE(a.Byte11 <= b.Byte11)
				&& IS_TRUE(a.Byte12 <= b.Byte12)
				&& IS_TRUE(a.Byte13 <= b.Byte13)
				&& IS_TRUE(a.Byte14 <= b.Byte14)
				&& IS_TRUE(a.Byte15 <= b.Byte15)
			    && IS_TRUE(a.Byte16 <= b.Byte16)
				&& IS_TRUE(a.Byte17 <= b.Byte17)
				&& IS_TRUE(a.Byte18 <= b.Byte18)
				&& IS_TRUE(a.Byte19 <= b.Byte19)
				&& IS_TRUE(a.Byte20 <= b.Byte20)
				&& IS_TRUE(a.Byte21 <= b.Byte21)
				&& IS_TRUE(a.Byte22 <= b.Byte22)
				&& IS_TRUE(a.Byte23 <= b.Byte23)
				&& IS_TRUE(a.Byte24 <= b.Byte24)
				&& IS_TRUE(a.Byte25 <= b.Byte25)
				&& IS_TRUE(a.Byte26 <= b.Byte26)
				&& IS_TRUE(a.Byte27 <= b.Byte27)
				&& IS_TRUE(a.Byte28 <= b.Byte28)
				&& IS_TRUE(a.Byte29 <= b.Byte29)
				&& IS_TRUE(a.Byte30 <= b.Byte30)
				&& IS_TRUE(a.Byte31 <= b.Byte31);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_LE_EPU16(v256 a, v256 b)
		{
			return IS_TRUE(a.UShort0  <= b.UShort0)
				&& IS_TRUE(a.UShort1  <= b.UShort1)
				&& IS_TRUE(a.UShort2  <= b.UShort2)
				&& IS_TRUE(a.UShort3  <= b.UShort3)
				&& IS_TRUE(a.UShort4  <= b.UShort4)
				&& IS_TRUE(a.UShort5  <= b.UShort5)
				&& IS_TRUE(a.UShort6  <= b.UShort6)
				&& IS_TRUE(a.UShort7  <= b.UShort7)
				&& IS_TRUE(a.UShort8  <= b.UShort8)
				&& IS_TRUE(a.UShort9  <= b.UShort9)
				&& IS_TRUE(a.UShort10 <= b.UShort10)
				&& IS_TRUE(a.UShort11 <= b.UShort11)
				&& IS_TRUE(a.UShort12 <= b.UShort12)
				&& IS_TRUE(a.UShort13 <= b.UShort13)
				&& IS_TRUE(a.UShort14 <= b.UShort14)
				&& IS_TRUE(a.UShort15 <= b.UShort15);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_LE_EPU32(v256 a, v256 b)
		{
			return IS_TRUE(a.UInt0 <= b.UInt0)
				&& IS_TRUE(a.UInt1 <= b.UInt1)
				&& IS_TRUE(a.UInt2 <= b.UInt2)
				&& IS_TRUE(a.UInt3 <= b.UInt3)
				&& IS_TRUE(a.UInt4 <= b.UInt4)
				&& IS_TRUE(a.UInt5 <= b.UInt5)
				&& IS_TRUE(a.UInt6 <= b.UInt6)
				&& IS_TRUE(a.UInt7 <= b.UInt7);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_LE_EPU64(v256 a, v256 b, byte elements = 4)
		{
			if (elements == 3)
			{
				return IS_TRUE(a.ULong0 <= b.ULong0)
					&& IS_TRUE(a.ULong1 <= b.ULong1)
					&& IS_TRUE(a.ULong2 <= b.ULong2);
			}
			else
			{
				return IS_TRUE(a.ULong0 <= b.ULong0)
					&& IS_TRUE(a.ULong1 <= b.ULong1)
					&& IS_TRUE(a.ULong2 <= b.ULong2)
					&& IS_TRUE(a.ULong3 <= b.ULong3);
			}
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_LE_PS(v256 a, v256 b)
		{
			return IS_TRUE(a.Float0 <= b.Float0)
				&& IS_TRUE(a.Float1 <= b.Float1)
				&& IS_TRUE(a.Float2 <= b.Float2)
				&& IS_TRUE(a.Float3 <= b.Float3)
				&& IS_TRUE(a.Float4 <= b.Float4)
				&& IS_TRUE(a.Float5 <= b.Float5)
				&& IS_TRUE(a.Float6 <= b.Float6)
				&& IS_TRUE(a.Float7 <= b.Float7);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ALL_LE_PD(v256 a, v256 b, byte elements = 4)
		{
			if (elements == 3)
			{
				return IS_TRUE(a.Double0 <= b.Double0)
					&& IS_TRUE(a.Double1 <= b.Double1)
					&& IS_TRUE(a.Double2 <= b.Double2);
			}
			else
			{
				return IS_TRUE(a.Double0 <= b.Double0)
					&& IS_TRUE(a.Double1 <= b.Double1)
					&& IS_TRUE(a.Double2 <= b.Double2)
					&& IS_TRUE(a.Double3 <= b.Double3);
			}
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_EQ_EPU8(v128 a, v128 b, byte elements = 16)
		{
			switch (elements)
			{
				case  2: return IS_TRUE(a.Byte0  == b.Byte0)
							 || IS_TRUE(a.Byte1  == b.Byte1);

				case  3: return IS_TRUE(a.Byte0  == b.Byte0)
							 || IS_TRUE(a.Byte1  == b.Byte1)
							 || IS_TRUE(a.Byte2  == b.Byte2);

				case  4: return IS_TRUE(a.Byte0  == b.Byte0)
							 || IS_TRUE(a.Byte1  == b.Byte1)
							 || IS_TRUE(a.Byte2  == b.Byte2)
							 || IS_TRUE(a.Byte3  == b.Byte3);

				case  8: return IS_TRUE(a.Byte0  == b.Byte0)
							 || IS_TRUE(a.Byte1  == b.Byte1)
							 || IS_TRUE(a.Byte2  == b.Byte2)
							 || IS_TRUE(a.Byte3  == b.Byte3)
							 || IS_TRUE(a.Byte4  == b.Byte4)
							 || IS_TRUE(a.Byte5  == b.Byte5)
							 || IS_TRUE(a.Byte6  == b.Byte6)
							 || IS_TRUE(a.Byte7  == b.Byte7);

				default: return IS_TRUE(a.Byte0  == b.Byte0)
							 || IS_TRUE(a.Byte1  == b.Byte1)
							 || IS_TRUE(a.Byte2  == b.Byte2)
							 || IS_TRUE(a.Byte3  == b.Byte3)
							 || IS_TRUE(a.Byte4  == b.Byte4)
							 || IS_TRUE(a.Byte5  == b.Byte5)
							 || IS_TRUE(a.Byte6  == b.Byte6)
							 || IS_TRUE(a.Byte7  == b.Byte7)
							 || IS_TRUE(a.Byte8  == b.Byte8)
							 || IS_TRUE(a.Byte9  == b.Byte9)
							 || IS_TRUE(a.Byte10 == b.Byte10)
							 || IS_TRUE(a.Byte11 == b.Byte11)
							 || IS_TRUE(a.Byte12 == b.Byte12)
							 || IS_TRUE(a.Byte13 == b.Byte13)
							 || IS_TRUE(a.Byte14 == b.Byte14)
							 || IS_TRUE(a.Byte15 == b.Byte15);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_EQ_EPU16(v128 a, v128 b, byte elements = 8)
		{
			switch (elements)
			{
				case  2: return IS_TRUE(a.UShort0  == b.UShort0)
							 || IS_TRUE(a.UShort1  == b.UShort1);

				case  3: return IS_TRUE(a.UShort0  == b.UShort0)
							 || IS_TRUE(a.UShort1  == b.UShort1)
							 || IS_TRUE(a.UShort2  == b.UShort2);

				case  4: return IS_TRUE(a.UShort0  == b.UShort0)
							 || IS_TRUE(a.UShort1  == b.UShort1)
							 || IS_TRUE(a.UShort2  == b.UShort2)
							 || IS_TRUE(a.UShort3  == b.UShort3);

				default: return IS_TRUE(a.UShort0  == b.UShort0)
							 || IS_TRUE(a.UShort1  == b.UShort1)
							 || IS_TRUE(a.UShort2  == b.UShort2)
							 || IS_TRUE(a.UShort3  == b.UShort3)
							 || IS_TRUE(a.UShort4  == b.UShort4)
							 || IS_TRUE(a.UShort5  == b.UShort5)
							 || IS_TRUE(a.UShort6  == b.UShort6)
							 || IS_TRUE(a.UShort7  == b.UShort7);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_EQ_EPU32(v128 a, v128 b, byte elements = 4)
		{
			switch (elements)
			{
				case  2: return IS_TRUE(a.UInt0  == b.UInt0)
							 || IS_TRUE(a.UInt1  == b.UInt1);

				case  3: return IS_TRUE(a.UInt0  == b.UInt0)
							 || IS_TRUE(a.UInt1  == b.UInt1)
							 || IS_TRUE(a.UInt2  == b.UInt2);

				default: return IS_TRUE(a.UInt0  == b.UInt0)
							 || IS_TRUE(a.UInt1  == b.UInt1)
							 || IS_TRUE(a.UInt2  == b.UInt2)
							 || IS_TRUE(a.UInt3  == b.UInt3);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_EQ_EPU64(v128 a, v128 b)
		{
			return IS_TRUE(a.ULong0 == b.ULong0)
				|| IS_TRUE(a.ULong1 == b.ULong1);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_EQ_EPI8(v128 a, v128 b, byte elements = 16)
		{
			switch (elements)
			{
				case  2: return IS_TRUE(a.SByte0  == b.SByte0)
							 || IS_TRUE(a.SByte1  == b.SByte1);

				case  3: return IS_TRUE(a.SByte0  == b.SByte0)
							 || IS_TRUE(a.SByte1  == b.SByte1)
							 || IS_TRUE(a.SByte2  == b.SByte2);

				case  4: return IS_TRUE(a.SByte0  == b.SByte0)
							 || IS_TRUE(a.SByte1  == b.SByte1)
							 || IS_TRUE(a.SByte2  == b.SByte2)
							 || IS_TRUE(a.SByte3  == b.SByte3);

				case  8: return IS_TRUE(a.SByte0  == b.SByte0)
							 || IS_TRUE(a.SByte1  == b.SByte1)
							 || IS_TRUE(a.SByte2  == b.SByte2)
							 || IS_TRUE(a.SByte3  == b.SByte3)
							 || IS_TRUE(a.SByte4  == b.SByte4)
							 || IS_TRUE(a.SByte5  == b.SByte5)
							 || IS_TRUE(a.SByte6  == b.SByte6)
							 || IS_TRUE(a.SByte7  == b.SByte7);

				default: return IS_TRUE(a.SByte0  == b.SByte0)
							 || IS_TRUE(a.SByte1  == b.SByte1)
							 || IS_TRUE(a.SByte2  == b.SByte2)
							 || IS_TRUE(a.SByte3  == b.SByte3)
							 || IS_TRUE(a.SByte4  == b.SByte4)
							 || IS_TRUE(a.SByte5  == b.SByte5)
							 || IS_TRUE(a.SByte6  == b.SByte6)
							 || IS_TRUE(a.SByte7  == b.SByte7)
							 || IS_TRUE(a.SByte8  == b.SByte8)
							 || IS_TRUE(a.SByte9  == b.SByte9)
							 || IS_TRUE(a.SByte10 == b.SByte10)
							 || IS_TRUE(a.SByte11 == b.SByte11)
							 || IS_TRUE(a.SByte12 == b.SByte12)
							 || IS_TRUE(a.SByte13 == b.SByte13)
							 || IS_TRUE(a.SByte14 == b.SByte14)
							 || IS_TRUE(a.SByte15 == b.SByte15);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_EQ_EPI16(v128 a, v128 b, byte elements = 8)
		{
			switch (elements)
			{
				case  2: return IS_TRUE(a.SShort0 == b.SShort0)
							 || IS_TRUE(a.SShort1 == b.SShort1);

				case  3: return IS_TRUE(a.SShort0 == b.SShort0)
							 || IS_TRUE(a.SShort1 == b.SShort1)
							 || IS_TRUE(a.SShort2 == b.SShort2);

				case  4: return IS_TRUE(a.SShort0 == b.SShort0)
							 || IS_TRUE(a.SShort1 == b.SShort1)
							 || IS_TRUE(a.SShort2 == b.SShort2)
							 || IS_TRUE(a.SShort3 == b.SShort3);

				default: return IS_TRUE(a.SShort0 == b.SShort0)
							 || IS_TRUE(a.SShort1 == b.SShort1)
							 || IS_TRUE(a.SShort2 == b.SShort2)
							 || IS_TRUE(a.SShort3 == b.SShort3)
							 || IS_TRUE(a.SShort4 == b.SShort4)
							 || IS_TRUE(a.SShort5 == b.SShort5)
							 || IS_TRUE(a.SShort6 == b.SShort6)
							 || IS_TRUE(a.SShort7 == b.SShort7);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_EQ_EPI32(v128 a, v128 b, byte elements = 4)
		{
			switch (elements)
			{
				case  2: return IS_TRUE(a.SInt0 == b.SInt0)
							 || IS_TRUE(a.SInt1 == b.SInt1);

				case  3: return IS_TRUE(a.SInt0 == b.SInt0)
							 || IS_TRUE(a.SInt1 == b.SInt1)
							 || IS_TRUE(a.SInt2 == b.SInt2);

				default: return IS_TRUE(a.SInt0 == b.SInt0)
							 || IS_TRUE(a.SInt1 == b.SInt1)
							 || IS_TRUE(a.SInt2 == b.SInt2)
							 || IS_TRUE(a.SInt3 == b.SInt3);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_EQ_EPI64(v128 a, v128 b)
		{
			return IS_TRUE(a.SLong0 == b.SLong0)
				|| IS_TRUE(a.SLong1 == b.SLong1);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_EQ_PS(v128 a, v128 b, byte elements = 4)
		{
			switch (elements)
			{
				case  1: return IS_TRUE(a.Float0 == b.Float0);

				case  2: return IS_TRUE(a.Float0 == b.Float0)
							 || IS_TRUE(a.Float1 == b.Float1);

				case  3: return IS_TRUE(a.Float0 == b.Float0)
							 || IS_TRUE(a.Float1 == b.Float1)
							 || IS_TRUE(a.Float2 == b.Float2);

				default: return IS_TRUE(a.Float0 == b.Float0)
							 || IS_TRUE(a.Float1 == b.Float1)
							 || IS_TRUE(a.Float2 == b.Float2)
							 || IS_TRUE(a.Float3 == b.Float3);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_EQ_PD(v128 a, v128 b)
		{
			return IS_TRUE(a.Double0 == b.Double0)
				|| IS_TRUE(a.Double1 == b.Double1);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_EQ_EPI8(v256 a, v256 b)
		{
			return IS_TRUE(a.SByte0  == b.SByte0)
				|| IS_TRUE(a.SByte1  == b.SByte1)
				|| IS_TRUE(a.SByte2  == b.SByte2)
				|| IS_TRUE(a.SByte3  == b.SByte3)
				|| IS_TRUE(a.SByte4  == b.SByte4)
				|| IS_TRUE(a.SByte5  == b.SByte5)
				|| IS_TRUE(a.SByte6  == b.SByte6)
				|| IS_TRUE(a.SByte7  == b.SByte7)
				|| IS_TRUE(a.SByte8  == b.SByte8)
				|| IS_TRUE(a.SByte9  == b.SByte9)
				|| IS_TRUE(a.SByte10 == b.SByte10)
				|| IS_TRUE(a.SByte11 == b.SByte11)
				|| IS_TRUE(a.SByte12 == b.SByte12)
				|| IS_TRUE(a.SByte13 == b.SByte13)
				|| IS_TRUE(a.SByte14 == b.SByte14)
				|| IS_TRUE(a.SByte15 == b.SByte15)
			    || IS_TRUE(a.SByte16 == b.SByte16)
				|| IS_TRUE(a.SByte17 == b.SByte17)
				|| IS_TRUE(a.SByte18 == b.SByte18)
				|| IS_TRUE(a.SByte19 == b.SByte19)
				|| IS_TRUE(a.SByte20 == b.SByte20)
				|| IS_TRUE(a.SByte21 == b.SByte21)
				|| IS_TRUE(a.SByte22 == b.SByte22)
				|| IS_TRUE(a.SByte23 == b.SByte23)
				|| IS_TRUE(a.SByte24 == b.SByte24)
				|| IS_TRUE(a.SByte25 == b.SByte25)
				|| IS_TRUE(a.SByte26 == b.SByte26)
				|| IS_TRUE(a.SByte27 == b.SByte27)
				|| IS_TRUE(a.SByte28 == b.SByte28)
				|| IS_TRUE(a.SByte29 == b.SByte29)
				|| IS_TRUE(a.SByte30 == b.SByte30)
				|| IS_TRUE(a.SByte31 == b.SByte31);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_EQ_EPI16(v256 a, v256 b)
		{
			return IS_TRUE(a.SShort0  == b.SShort0)
				|| IS_TRUE(a.SShort1  == b.SShort1)
				|| IS_TRUE(a.SShort2  == b.SShort2)
				|| IS_TRUE(a.SShort3  == b.SShort3)
				|| IS_TRUE(a.SShort4  == b.SShort4)
				|| IS_TRUE(a.SShort5  == b.SShort5)
				|| IS_TRUE(a.SShort6  == b.SShort6)
				|| IS_TRUE(a.SShort7  == b.SShort7)
				|| IS_TRUE(a.SShort8  == b.SShort8)
				|| IS_TRUE(a.SShort9  == b.SShort9)
				|| IS_TRUE(a.SShort10 == b.SShort10)
				|| IS_TRUE(a.SShort11 == b.SShort11)
				|| IS_TRUE(a.SShort12 == b.SShort12)
				|| IS_TRUE(a.SShort13 == b.SShort13)
				|| IS_TRUE(a.SShort14 == b.SShort14)
				|| IS_TRUE(a.SShort15 == b.SShort15);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_EQ_EPI32(v256 a, v256 b)
		{
			return IS_TRUE(a.SInt0 == b.SInt0)
				|| IS_TRUE(a.SInt1 == b.SInt1)
				|| IS_TRUE(a.SInt2 == b.SInt2)
				|| IS_TRUE(a.SInt3 == b.SInt3)
				|| IS_TRUE(a.SInt4 == b.SInt4)
				|| IS_TRUE(a.SInt5 == b.SInt5)
				|| IS_TRUE(a.SInt6 == b.SInt6)
				|| IS_TRUE(a.SInt7 == b.SInt7);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_EQ_EPI64(v256 a, v256 b, byte elements = 4)
		{
			if (elements == 3)
			{
				return IS_TRUE(a.SLong0 == b.SLong0)
					|| IS_TRUE(a.SLong1 == b.SLong1)
					|| IS_TRUE(a.SLong2 == b.SLong2);
			}
			else
			{
				return IS_TRUE(a.SLong0 == b.SLong0)
					|| IS_TRUE(a.SLong1 == b.SLong1)
					|| IS_TRUE(a.SLong2 == b.SLong2)
					|| IS_TRUE(a.SLong3 == b.SLong3);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_EQ_EPU8(v256 a, v256 b)
		{
			return IS_TRUE(a.Byte0  == b.Byte0)
				|| IS_TRUE(a.Byte1  == b.Byte1)
				|| IS_TRUE(a.Byte2  == b.Byte2)
				|| IS_TRUE(a.Byte3  == b.Byte3)
				|| IS_TRUE(a.Byte4  == b.Byte4)
				|| IS_TRUE(a.Byte5  == b.Byte5)
				|| IS_TRUE(a.Byte6  == b.Byte6)
				|| IS_TRUE(a.Byte7  == b.Byte7)
				|| IS_TRUE(a.Byte8  == b.Byte8)
				|| IS_TRUE(a.Byte9  == b.Byte9)
				|| IS_TRUE(a.Byte10 == b.Byte10)
				|| IS_TRUE(a.Byte11 == b.Byte11)
				|| IS_TRUE(a.Byte12 == b.Byte12)
				|| IS_TRUE(a.Byte13 == b.Byte13)
				|| IS_TRUE(a.Byte14 == b.Byte14)
				|| IS_TRUE(a.Byte15 == b.Byte15)
			    || IS_TRUE(a.Byte16 == b.Byte16)
				|| IS_TRUE(a.Byte17 == b.Byte17)
				|| IS_TRUE(a.Byte18 == b.Byte18)
				|| IS_TRUE(a.Byte19 == b.Byte19)
				|| IS_TRUE(a.Byte20 == b.Byte20)
				|| IS_TRUE(a.Byte21 == b.Byte21)
				|| IS_TRUE(a.Byte22 == b.Byte22)
				|| IS_TRUE(a.Byte23 == b.Byte23)
				|| IS_TRUE(a.Byte24 == b.Byte24)
				|| IS_TRUE(a.Byte25 == b.Byte25)
				|| IS_TRUE(a.Byte26 == b.Byte26)
				|| IS_TRUE(a.Byte27 == b.Byte27)
				|| IS_TRUE(a.Byte28 == b.Byte28)
				|| IS_TRUE(a.Byte29 == b.Byte29)
				|| IS_TRUE(a.Byte30 == b.Byte30)
				|| IS_TRUE(a.Byte31 == b.Byte31);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_EQ_EPU16(v256 a, v256 b)
		{
			return IS_TRUE(a.UShort0  == b.UShort0)
				|| IS_TRUE(a.UShort1  == b.UShort1)
				|| IS_TRUE(a.UShort2  == b.UShort2)
				|| IS_TRUE(a.UShort3  == b.UShort3)
				|| IS_TRUE(a.UShort4  == b.UShort4)
				|| IS_TRUE(a.UShort5  == b.UShort5)
				|| IS_TRUE(a.UShort6  == b.UShort6)
				|| IS_TRUE(a.UShort7  == b.UShort7)
				|| IS_TRUE(a.UShort8  == b.UShort8)
				|| IS_TRUE(a.UShort9  == b.UShort9)
				|| IS_TRUE(a.UShort10 == b.UShort10)
				|| IS_TRUE(a.UShort11 == b.UShort11)
				|| IS_TRUE(a.UShort12 == b.UShort12)
				|| IS_TRUE(a.UShort13 == b.UShort13)
				|| IS_TRUE(a.UShort14 == b.UShort14)
				|| IS_TRUE(a.UShort15 == b.UShort15);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_EQ_EPU32(v256 a, v256 b)
		{
			return IS_TRUE(a.UInt0 == b.UInt0)
				|| IS_TRUE(a.UInt1 == b.UInt1)
				|| IS_TRUE(a.UInt2 == b.UInt2)
				|| IS_TRUE(a.UInt3 == b.UInt3)
				|| IS_TRUE(a.UInt4 == b.UInt4)
				|| IS_TRUE(a.UInt5 == b.UInt5)
				|| IS_TRUE(a.UInt6 == b.UInt6)
				|| IS_TRUE(a.UInt7 == b.UInt7);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_EQ_EPU64(v256 a, v256 b, byte elements = 4)
		{
			if (elements == 3)
			{
				return IS_TRUE(a.ULong0 == b.ULong0)
					|| IS_TRUE(a.ULong1 == b.ULong1)
					|| IS_TRUE(a.ULong2 == b.ULong2);
			}
			else
			{
				return IS_TRUE(a.ULong0 == b.ULong0)
					|| IS_TRUE(a.ULong1 == b.ULong1)
					|| IS_TRUE(a.ULong2 == b.ULong2)
					|| IS_TRUE(a.ULong3 == b.ULong3);
			}
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_EQ_PS(v256 a, v256 b)
		{
			return IS_TRUE(a.Float0 == b.Float0)
				|| IS_TRUE(a.Float1 == b.Float1)
				|| IS_TRUE(a.Float2 == b.Float2)
				|| IS_TRUE(a.Float3 == b.Float3)
				|| IS_TRUE(a.Float4 == b.Float4)
				|| IS_TRUE(a.Float5 == b.Float5)
				|| IS_TRUE(a.Float6 == b.Float6)
				|| IS_TRUE(a.Float7 == b.Float7);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_EQ_PD(v256 a, v256 b, byte elements = 4)
		{
			if (elements == 3)
			{
				return IS_TRUE(a.Double0 == b.Double0)
					|| IS_TRUE(a.Double1 == b.Double1)
					|| IS_TRUE(a.Double2 == b.Double2);
			}
			else
			{
				return IS_TRUE(a.Double0 == b.Double0)
					|| IS_TRUE(a.Double1 == b.Double1)
					|| IS_TRUE(a.Double2 == b.Double2)
					|| IS_TRUE(a.Double3 == b.Double3);
			}
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_NEQ_EPU8(v128 a, v128 b, byte elements = 16)
		{
			switch (elements)
			{
				case  2: return IS_TRUE(a.Byte0  != b.Byte0)
							 || IS_TRUE(a.Byte1  != b.Byte1);

				case  3: return IS_TRUE(a.Byte0  != b.Byte0)
							 || IS_TRUE(a.Byte1  != b.Byte1)
							 || IS_TRUE(a.Byte2  != b.Byte2);

				case  4: return IS_TRUE(a.Byte0  != b.Byte0)
							 || IS_TRUE(a.Byte1  != b.Byte1)
							 || IS_TRUE(a.Byte2  != b.Byte2)
							 || IS_TRUE(a.Byte3  != b.Byte3);

				case  8: return IS_TRUE(a.Byte0  != b.Byte0)
							 || IS_TRUE(a.Byte1  != b.Byte1)
							 || IS_TRUE(a.Byte2  != b.Byte2)
							 || IS_TRUE(a.Byte3  != b.Byte3)
							 || IS_TRUE(a.Byte4  != b.Byte4)
							 || IS_TRUE(a.Byte5  != b.Byte5)
							 || IS_TRUE(a.Byte6  != b.Byte6)
							 || IS_TRUE(a.Byte7  != b.Byte7);

				default: return IS_TRUE(a.Byte0  != b.Byte0)
							 || IS_TRUE(a.Byte1  != b.Byte1)
							 || IS_TRUE(a.Byte2  != b.Byte2)
							 || IS_TRUE(a.Byte3  != b.Byte3)
							 || IS_TRUE(a.Byte4  != b.Byte4)
							 || IS_TRUE(a.Byte5  != b.Byte5)
							 || IS_TRUE(a.Byte6  != b.Byte6)
							 || IS_TRUE(a.Byte7  != b.Byte7)
							 || IS_TRUE(a.Byte8  != b.Byte8)
							 || IS_TRUE(a.Byte9  != b.Byte9)
							 || IS_TRUE(a.Byte10 != b.Byte10)
							 || IS_TRUE(a.Byte11 != b.Byte11)
							 || IS_TRUE(a.Byte12 != b.Byte12)
							 || IS_TRUE(a.Byte13 != b.Byte13)
							 || IS_TRUE(a.Byte14 != b.Byte14)
							 || IS_TRUE(a.Byte15 != b.Byte15);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_NEQ_EPU16(v128 a, v128 b, byte elements = 8)
		{
			switch (elements)
			{
				case  2: return IS_TRUE(a.UShort0  != b.UShort0)
							 || IS_TRUE(a.UShort1  != b.UShort1);

				case  3: return IS_TRUE(a.UShort0  != b.UShort0)
							 || IS_TRUE(a.UShort1  != b.UShort1)
							 || IS_TRUE(a.UShort2  != b.UShort2);

				case  4: return IS_TRUE(a.UShort0  != b.UShort0)
							 || IS_TRUE(a.UShort1  != b.UShort1)
							 || IS_TRUE(a.UShort2  != b.UShort2)
							 || IS_TRUE(a.UShort3  != b.UShort3);

				default: return IS_TRUE(a.UShort0  != b.UShort0)
							 || IS_TRUE(a.UShort1  != b.UShort1)
							 || IS_TRUE(a.UShort2  != b.UShort2)
							 || IS_TRUE(a.UShort3  != b.UShort3)
							 || IS_TRUE(a.UShort4  != b.UShort4)
							 || IS_TRUE(a.UShort5  != b.UShort5)
							 || IS_TRUE(a.UShort6  != b.UShort6)
							 || IS_TRUE(a.UShort7  != b.UShort7);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_NEQ_EPU32(v128 a, v128 b, byte elements = 4)
		{
			switch (elements)
			{
				case  2: return IS_TRUE(a.UInt0  != b.UInt0)
							 || IS_TRUE(a.UInt1  != b.UInt1);

				case  3: return IS_TRUE(a.UInt0  != b.UInt0)
							 || IS_TRUE(a.UInt1  != b.UInt1)
							 || IS_TRUE(a.UInt2  != b.UInt2);

				default: return IS_TRUE(a.UInt0  != b.UInt0)
							 || IS_TRUE(a.UInt1  != b.UInt1)
							 || IS_TRUE(a.UInt2  != b.UInt2)
							 || IS_TRUE(a.UInt3  != b.UInt3);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_NEQ_EPU64(v128 a, v128 b)
		{
			return IS_TRUE(a.ULong0 != b.ULong0)
				|| IS_TRUE(a.ULong1 != b.ULong1);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_NEQ_EPI8(v128 a, v128 b, byte elements = 16)
		{
			switch (elements)
			{
				case  2: return IS_TRUE(a.SByte0  != b.SByte0)
							 || IS_TRUE(a.SByte1  != b.SByte1);

				case  3: return IS_TRUE(a.SByte0  != b.SByte0)
							 || IS_TRUE(a.SByte1  != b.SByte1)
							 || IS_TRUE(a.SByte2  != b.SByte2);

				case  4: return IS_TRUE(a.SByte0  != b.SByte0)
							 || IS_TRUE(a.SByte1  != b.SByte1)
							 || IS_TRUE(a.SByte2  != b.SByte2)
							 || IS_TRUE(a.SByte3  != b.SByte3);

				case  8: return IS_TRUE(a.SByte0  != b.SByte0)
							 || IS_TRUE(a.SByte1  != b.SByte1)
							 || IS_TRUE(a.SByte2  != b.SByte2)
							 || IS_TRUE(a.SByte3  != b.SByte3)
							 || IS_TRUE(a.SByte4  != b.SByte4)
							 || IS_TRUE(a.SByte5  != b.SByte5)
							 || IS_TRUE(a.SByte6  != b.SByte6)
							 || IS_TRUE(a.SByte7  != b.SByte7);

				default: return IS_TRUE(a.SByte0  != b.SByte0)
							 || IS_TRUE(a.SByte1  != b.SByte1)
							 || IS_TRUE(a.SByte2  != b.SByte2)
							 || IS_TRUE(a.SByte3  != b.SByte3)
							 || IS_TRUE(a.SByte4  != b.SByte4)
							 || IS_TRUE(a.SByte5  != b.SByte5)
							 || IS_TRUE(a.SByte6  != b.SByte6)
							 || IS_TRUE(a.SByte7  != b.SByte7)
							 || IS_TRUE(a.SByte8  != b.SByte8)
							 || IS_TRUE(a.SByte9  != b.SByte9)
							 || IS_TRUE(a.SByte10 != b.SByte10)
							 || IS_TRUE(a.SByte11 != b.SByte11)
							 || IS_TRUE(a.SByte12 != b.SByte12)
							 || IS_TRUE(a.SByte13 != b.SByte13)
							 || IS_TRUE(a.SByte14 != b.SByte14)
							 || IS_TRUE(a.SByte15 != b.SByte15);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_NEQ_EPI16(v128 a, v128 b, byte elements = 8)
		{
			switch (elements)
			{
				case  2: return IS_TRUE(a.SShort0 != b.SShort0)
							 || IS_TRUE(a.SShort1 != b.SShort1);

				case  3: return IS_TRUE(a.SShort0 != b.SShort0)
							 || IS_TRUE(a.SShort1 != b.SShort1)
							 || IS_TRUE(a.SShort2 != b.SShort2);

				case  4: return IS_TRUE(a.SShort0 != b.SShort0)
							 || IS_TRUE(a.SShort1 != b.SShort1)
							 || IS_TRUE(a.SShort2 != b.SShort2)
							 || IS_TRUE(a.SShort3 != b.SShort3);

				default: return IS_TRUE(a.SShort0 != b.SShort0)
							 || IS_TRUE(a.SShort1 != b.SShort1)
							 || IS_TRUE(a.SShort2 != b.SShort2)
							 || IS_TRUE(a.SShort3 != b.SShort3)
							 || IS_TRUE(a.SShort4 != b.SShort4)
							 || IS_TRUE(a.SShort5 != b.SShort5)
							 || IS_TRUE(a.SShort6 != b.SShort6)
							 || IS_TRUE(a.SShort7 != b.SShort7);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_NEQ_EPI32(v128 a, v128 b, byte elements = 4)
		{
			switch (elements)
			{
				case  2: return IS_TRUE(a.SInt0 != b.SInt0)
							 || IS_TRUE(a.SInt1 != b.SInt1);

				case  3: return IS_TRUE(a.SInt0 != b.SInt0)
							 || IS_TRUE(a.SInt1 != b.SInt1)
							 || IS_TRUE(a.SInt2 != b.SInt2);

				default: return IS_TRUE(a.SInt0 != b.SInt0)
							 || IS_TRUE(a.SInt1 != b.SInt1)
							 || IS_TRUE(a.SInt2 != b.SInt2)
							 || IS_TRUE(a.SInt3 != b.SInt3);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_NEQ_EPI64(v128 a, v128 b)
		{
			return IS_TRUE(a.SLong0 != b.SLong0)
				|| IS_TRUE(a.SLong1 != b.SLong1);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_NEQ_PS(v128 a, v128 b, byte elements = 4)
		{
			switch (elements)
			{
				case  1: return IS_TRUE(a.Float0 != b.Float0);

				case  2: return IS_TRUE(a.Float0 != b.Float0)
							 || IS_TRUE(a.Float1 != b.Float1);

				case  3: return IS_TRUE(a.Float0 != b.Float0)
							 || IS_TRUE(a.Float1 != b.Float1)
							 || IS_TRUE(a.Float2 != b.Float2);

				default: return IS_TRUE(a.Float0 != b.Float0)
							 || IS_TRUE(a.Float1 != b.Float1)
							 || IS_TRUE(a.Float2 != b.Float2)
							 || IS_TRUE(a.Float3 != b.Float3);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_NEQ_PD(v128 a, v128 b)
		{
			return IS_TRUE(a.Double0 != b.Double0)
				|| IS_TRUE(a.Double1 != b.Double1);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_NEQ_EPI8(v256 a, v256 b)
		{
			return IS_TRUE(a.SByte0  != b.SByte0)
				|| IS_TRUE(a.SByte1  != b.SByte1)
				|| IS_TRUE(a.SByte2  != b.SByte2)
				|| IS_TRUE(a.SByte3  != b.SByte3)
				|| IS_TRUE(a.SByte4  != b.SByte4)
				|| IS_TRUE(a.SByte5  != b.SByte5)
				|| IS_TRUE(a.SByte6  != b.SByte6)
				|| IS_TRUE(a.SByte7  != b.SByte7)
				|| IS_TRUE(a.SByte8  != b.SByte8)
				|| IS_TRUE(a.SByte9  != b.SByte9)
				|| IS_TRUE(a.SByte10 != b.SByte10)
				|| IS_TRUE(a.SByte11 != b.SByte11)
				|| IS_TRUE(a.SByte12 != b.SByte12)
				|| IS_TRUE(a.SByte13 != b.SByte13)
				|| IS_TRUE(a.SByte14 != b.SByte14)
				|| IS_TRUE(a.SByte15 != b.SByte15)
			    || IS_TRUE(a.SByte16 != b.SByte16)
				|| IS_TRUE(a.SByte17 != b.SByte17)
				|| IS_TRUE(a.SByte18 != b.SByte18)
				|| IS_TRUE(a.SByte19 != b.SByte19)
				|| IS_TRUE(a.SByte20 != b.SByte20)
				|| IS_TRUE(a.SByte21 != b.SByte21)
				|| IS_TRUE(a.SByte22 != b.SByte22)
				|| IS_TRUE(a.SByte23 != b.SByte23)
				|| IS_TRUE(a.SByte24 != b.SByte24)
				|| IS_TRUE(a.SByte25 != b.SByte25)
				|| IS_TRUE(a.SByte26 != b.SByte26)
				|| IS_TRUE(a.SByte27 != b.SByte27)
				|| IS_TRUE(a.SByte28 != b.SByte28)
				|| IS_TRUE(a.SByte29 != b.SByte29)
				|| IS_TRUE(a.SByte30 != b.SByte30)
				|| IS_TRUE(a.SByte31 != b.SByte31);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_NEQ_EPI16(v256 a, v256 b)
		{
			return IS_TRUE(a.SShort0  != b.SShort0)
				|| IS_TRUE(a.SShort1  != b.SShort1)
				|| IS_TRUE(a.SShort2  != b.SShort2)
				|| IS_TRUE(a.SShort3  != b.SShort3)
				|| IS_TRUE(a.SShort4  != b.SShort4)
				|| IS_TRUE(a.SShort5  != b.SShort5)
				|| IS_TRUE(a.SShort6  != b.SShort6)
				|| IS_TRUE(a.SShort7  != b.SShort7)
				|| IS_TRUE(a.SShort8  != b.SShort8)
				|| IS_TRUE(a.SShort9  != b.SShort9)
				|| IS_TRUE(a.SShort10 != b.SShort10)
				|| IS_TRUE(a.SShort11 != b.SShort11)
				|| IS_TRUE(a.SShort12 != b.SShort12)
				|| IS_TRUE(a.SShort13 != b.SShort13)
				|| IS_TRUE(a.SShort14 != b.SShort14)
				|| IS_TRUE(a.SShort15 != b.SShort15);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_NEQ_EPI32(v256 a, v256 b)
		{
			return IS_TRUE(a.SInt0 != b.SInt0)
				|| IS_TRUE(a.SInt1 != b.SInt1)
				|| IS_TRUE(a.SInt2 != b.SInt2)
				|| IS_TRUE(a.SInt3 != b.SInt3)
				|| IS_TRUE(a.SInt4 != b.SInt4)
				|| IS_TRUE(a.SInt5 != b.SInt5)
				|| IS_TRUE(a.SInt6 != b.SInt6)
				|| IS_TRUE(a.SInt7 != b.SInt7);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_NEQ_EPI64(v256 a, v256 b, byte elements = 4)
		{
			if (elements == 3)
			{
				return IS_TRUE(a.SLong0 != b.SLong0)
					|| IS_TRUE(a.SLong1 != b.SLong1)
					|| IS_TRUE(a.SLong2 != b.SLong2);
			}
			else
			{
				return IS_TRUE(a.SLong0 != b.SLong0)
					|| IS_TRUE(a.SLong1 != b.SLong1)
					|| IS_TRUE(a.SLong2 != b.SLong2)
					|| IS_TRUE(a.SLong3 != b.SLong3);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_NEQ_EPU8(v256 a, v256 b)
		{
			return IS_TRUE(a.Byte0  != b.Byte0)
				|| IS_TRUE(a.Byte1  != b.Byte1)
				|| IS_TRUE(a.Byte2  != b.Byte2)
				|| IS_TRUE(a.Byte3  != b.Byte3)
				|| IS_TRUE(a.Byte4  != b.Byte4)
				|| IS_TRUE(a.Byte5  != b.Byte5)
				|| IS_TRUE(a.Byte6  != b.Byte6)
				|| IS_TRUE(a.Byte7  != b.Byte7)
				|| IS_TRUE(a.Byte8  != b.Byte8)
				|| IS_TRUE(a.Byte9  != b.Byte9)
				|| IS_TRUE(a.Byte10 != b.Byte10)
				|| IS_TRUE(a.Byte11 != b.Byte11)
				|| IS_TRUE(a.Byte12 != b.Byte12)
				|| IS_TRUE(a.Byte13 != b.Byte13)
				|| IS_TRUE(a.Byte14 != b.Byte14)
				|| IS_TRUE(a.Byte15 != b.Byte15)
			    || IS_TRUE(a.Byte16 != b.Byte16)
				|| IS_TRUE(a.Byte17 != b.Byte17)
				|| IS_TRUE(a.Byte18 != b.Byte18)
				|| IS_TRUE(a.Byte19 != b.Byte19)
				|| IS_TRUE(a.Byte20 != b.Byte20)
				|| IS_TRUE(a.Byte21 != b.Byte21)
				|| IS_TRUE(a.Byte22 != b.Byte22)
				|| IS_TRUE(a.Byte23 != b.Byte23)
				|| IS_TRUE(a.Byte24 != b.Byte24)
				|| IS_TRUE(a.Byte25 != b.Byte25)
				|| IS_TRUE(a.Byte26 != b.Byte26)
				|| IS_TRUE(a.Byte27 != b.Byte27)
				|| IS_TRUE(a.Byte28 != b.Byte28)
				|| IS_TRUE(a.Byte29 != b.Byte29)
				|| IS_TRUE(a.Byte30 != b.Byte30)
				|| IS_TRUE(a.Byte31 != b.Byte31);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_NEQ_EPU16(v256 a, v256 b)
		{
			return IS_TRUE(a.UShort0  != b.UShort0)
				|| IS_TRUE(a.UShort1  != b.UShort1)
				|| IS_TRUE(a.UShort2  != b.UShort2)
				|| IS_TRUE(a.UShort3  != b.UShort3)
				|| IS_TRUE(a.UShort4  != b.UShort4)
				|| IS_TRUE(a.UShort5  != b.UShort5)
				|| IS_TRUE(a.UShort6  != b.UShort6)
				|| IS_TRUE(a.UShort7  != b.UShort7)
				|| IS_TRUE(a.UShort8  != b.UShort8)
				|| IS_TRUE(a.UShort9  != b.UShort9)
				|| IS_TRUE(a.UShort10 != b.UShort10)
				|| IS_TRUE(a.UShort11 != b.UShort11)
				|| IS_TRUE(a.UShort12 != b.UShort12)
				|| IS_TRUE(a.UShort13 != b.UShort13)
				|| IS_TRUE(a.UShort14 != b.UShort14)
				|| IS_TRUE(a.UShort15 != b.UShort15);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_NEQ_EPU32(v256 a, v256 b)
		{
			return IS_TRUE(a.UInt0 != b.UInt0)
				|| IS_TRUE(a.UInt1 != b.UInt1)
				|| IS_TRUE(a.UInt2 != b.UInt2)
				|| IS_TRUE(a.UInt3 != b.UInt3)
				|| IS_TRUE(a.UInt4 != b.UInt4)
				|| IS_TRUE(a.UInt5 != b.UInt5)
				|| IS_TRUE(a.UInt6 != b.UInt6)
				|| IS_TRUE(a.UInt7 != b.UInt7);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_NEQ_EPU64(v256 a, v256 b, byte elements = 4)
		{
			if (elements == 3)
			{
				return IS_TRUE(a.ULong0 != b.ULong0)
					|| IS_TRUE(a.ULong1 != b.ULong1)
					|| IS_TRUE(a.ULong2 != b.ULong2);
			}
			else
			{
				return IS_TRUE(a.ULong0 != b.ULong0)
					|| IS_TRUE(a.ULong1 != b.ULong1)
					|| IS_TRUE(a.ULong2 != b.ULong2)
					|| IS_TRUE(a.ULong3 != b.ULong3);
			}
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_NEQ_PS(v256 a, v256 b)
		{
			return IS_TRUE(a.Float0 != b.Float0)
				|| IS_TRUE(a.Float1 != b.Float1)
				|| IS_TRUE(a.Float2 != b.Float2)
				|| IS_TRUE(a.Float3 != b.Float3)
				|| IS_TRUE(a.Float4 != b.Float4)
				|| IS_TRUE(a.Float5 != b.Float5)
				|| IS_TRUE(a.Float6 != b.Float6)
				|| IS_TRUE(a.Float7 != b.Float7);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_NEQ_PD(v256 a, v256 b, byte elements = 4)
		{
			if (elements == 3)
			{
				return IS_TRUE(a.Double0 != b.Double0)
					|| IS_TRUE(a.Double1 != b.Double1)
					|| IS_TRUE(a.Double2 != b.Double2);
			}
			else
			{
				return IS_TRUE(a.Double0 != b.Double0)
					|| IS_TRUE(a.Double1 != b.Double1)
					|| IS_TRUE(a.Double2 != b.Double2)
					|| IS_TRUE(a.Double3 != b.Double3);
			}
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_GT_EPU8(v128 a, v128 b, byte elements = 16)
		{
			switch (elements)
			{
				case  2: return IS_TRUE(a.Byte0  > b.Byte0)
							 || IS_TRUE(a.Byte1  > b.Byte1);

				case  3: return IS_TRUE(a.Byte0  > b.Byte0)
							 || IS_TRUE(a.Byte1  > b.Byte1)
							 || IS_TRUE(a.Byte2  > b.Byte2);

				case  4: return IS_TRUE(a.Byte0  > b.Byte0)
							 || IS_TRUE(a.Byte1  > b.Byte1)
							 || IS_TRUE(a.Byte2  > b.Byte2)
							 || IS_TRUE(a.Byte3  > b.Byte3);

				case  8: return IS_TRUE(a.Byte0  > b.Byte0)
							 || IS_TRUE(a.Byte1  > b.Byte1)
							 || IS_TRUE(a.Byte2  > b.Byte2)
							 || IS_TRUE(a.Byte3  > b.Byte3)
							 || IS_TRUE(a.Byte4  > b.Byte4)
							 || IS_TRUE(a.Byte5  > b.Byte5)
							 || IS_TRUE(a.Byte6  > b.Byte6)
							 || IS_TRUE(a.Byte7  > b.Byte7);

				default: return IS_TRUE(a.Byte0  > b.Byte0)
							 || IS_TRUE(a.Byte1  > b.Byte1)
							 || IS_TRUE(a.Byte2  > b.Byte2)
							 || IS_TRUE(a.Byte3  > b.Byte3)
							 || IS_TRUE(a.Byte4  > b.Byte4)
							 || IS_TRUE(a.Byte5  > b.Byte5)
							 || IS_TRUE(a.Byte6  > b.Byte6)
							 || IS_TRUE(a.Byte7  > b.Byte7)
							 || IS_TRUE(a.Byte8  > b.Byte8)
							 || IS_TRUE(a.Byte9  > b.Byte9)
							 || IS_TRUE(a.Byte10 > b.Byte10)
							 || IS_TRUE(a.Byte11 > b.Byte11)
							 || IS_TRUE(a.Byte12 > b.Byte12)
							 || IS_TRUE(a.Byte13 > b.Byte13)
							 || IS_TRUE(a.Byte14 > b.Byte14)
							 || IS_TRUE(a.Byte15 > b.Byte15);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_GT_EPU16(v128 a, v128 b, byte elements = 8)
		{
			switch (elements)
			{
				case  2: return IS_TRUE(a.UShort0  > b.UShort0)
							 || IS_TRUE(a.UShort1  > b.UShort1);

				case  3: return IS_TRUE(a.UShort0  > b.UShort0)
							 || IS_TRUE(a.UShort1  > b.UShort1)
							 || IS_TRUE(a.UShort2  > b.UShort2);

				case  4: return IS_TRUE(a.UShort0  > b.UShort0)
							 || IS_TRUE(a.UShort1  > b.UShort1)
							 || IS_TRUE(a.UShort2  > b.UShort2)
							 || IS_TRUE(a.UShort3  > b.UShort3);

				default: return IS_TRUE(a.UShort0  > b.UShort0)
							 || IS_TRUE(a.UShort1  > b.UShort1)
							 || IS_TRUE(a.UShort2  > b.UShort2)
							 || IS_TRUE(a.UShort3  > b.UShort3)
							 || IS_TRUE(a.UShort4  > b.UShort4)
							 || IS_TRUE(a.UShort5  > b.UShort5)
							 || IS_TRUE(a.UShort6  > b.UShort6)
							 || IS_TRUE(a.UShort7  > b.UShort7);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_GT_EPU32(v128 a, v128 b, byte elements = 4)
		{
			switch (elements)
			{
				case  2: return IS_TRUE(a.UInt0  > b.UInt0)
							 || IS_TRUE(a.UInt1  > b.UInt1);

				case  3: return IS_TRUE(a.UInt0  > b.UInt0)
							 || IS_TRUE(a.UInt1  > b.UInt1)
							 || IS_TRUE(a.UInt2  > b.UInt2);

				default: return IS_TRUE(a.UInt0  > b.UInt0)
							 || IS_TRUE(a.UInt1  > b.UInt1)
							 || IS_TRUE(a.UInt2  > b.UInt2)
							 || IS_TRUE(a.UInt3  > b.UInt3);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_GT_EPU64(v128 a, v128 b)
		{
			return IS_TRUE(a.ULong0 > b.ULong0)
				|| IS_TRUE(a.ULong1 > b.ULong1);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_GT_EPI8(v128 a, v128 b, byte elements = 16)
		{
			switch (elements)
			{
				case  2: return IS_TRUE(a.SByte0  > b.SByte0)
							 || IS_TRUE(a.SByte1  > b.SByte1);

				case  3: return IS_TRUE(a.SByte0  > b.SByte0)
							 || IS_TRUE(a.SByte1  > b.SByte1)
							 || IS_TRUE(a.SByte2  > b.SByte2);

				case  4: return IS_TRUE(a.SByte0  > b.SByte0)
							 || IS_TRUE(a.SByte1  > b.SByte1)
							 || IS_TRUE(a.SByte2  > b.SByte2)
							 || IS_TRUE(a.SByte3  > b.SByte3);

				case  8: return IS_TRUE(a.SByte0  > b.SByte0)
							 || IS_TRUE(a.SByte1  > b.SByte1)
							 || IS_TRUE(a.SByte2  > b.SByte2)
							 || IS_TRUE(a.SByte3  > b.SByte3)
							 || IS_TRUE(a.SByte4  > b.SByte4)
							 || IS_TRUE(a.SByte5  > b.SByte5)
							 || IS_TRUE(a.SByte6  > b.SByte6)
							 || IS_TRUE(a.SByte7  > b.SByte7);

				default: return IS_TRUE(a.SByte0  > b.SByte0)
							 || IS_TRUE(a.SByte1  > b.SByte1)
							 || IS_TRUE(a.SByte2  > b.SByte2)
							 || IS_TRUE(a.SByte3  > b.SByte3)
							 || IS_TRUE(a.SByte4  > b.SByte4)
							 || IS_TRUE(a.SByte5  > b.SByte5)
							 || IS_TRUE(a.SByte6  > b.SByte6)
							 || IS_TRUE(a.SByte7  > b.SByte7)
							 || IS_TRUE(a.SByte8  > b.SByte8)
							 || IS_TRUE(a.SByte9  > b.SByte9)
							 || IS_TRUE(a.SByte10 > b.SByte10)
							 || IS_TRUE(a.SByte11 > b.SByte11)
							 || IS_TRUE(a.SByte12 > b.SByte12)
							 || IS_TRUE(a.SByte13 > b.SByte13)
							 || IS_TRUE(a.SByte14 > b.SByte14)
							 || IS_TRUE(a.SByte15 > b.SByte15);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_GT_EPI16(v128 a, v128 b, byte elements = 8)
		{
			switch (elements)
			{
				case  2: return IS_TRUE(a.SShort0 > b.SShort0)
							 || IS_TRUE(a.SShort1 > b.SShort1);

				case  3: return IS_TRUE(a.SShort0 > b.SShort0)
							 || IS_TRUE(a.SShort1 > b.SShort1)
							 || IS_TRUE(a.SShort2 > b.SShort2);

				case  4: return IS_TRUE(a.SShort0 > b.SShort0)
							 || IS_TRUE(a.SShort1 > b.SShort1)
							 || IS_TRUE(a.SShort2 > b.SShort2)
							 || IS_TRUE(a.SShort3 > b.SShort3);

				default: return IS_TRUE(a.SShort0 > b.SShort0)
							 || IS_TRUE(a.SShort1 > b.SShort1)
							 || IS_TRUE(a.SShort2 > b.SShort2)
							 || IS_TRUE(a.SShort3 > b.SShort3)
							 || IS_TRUE(a.SShort4 > b.SShort4)
							 || IS_TRUE(a.SShort5 > b.SShort5)
							 || IS_TRUE(a.SShort6 > b.SShort6)
							 || IS_TRUE(a.SShort7 > b.SShort7);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_GT_EPI32(v128 a, v128 b, byte elements = 4)
		{
			switch (elements)
			{
				case  2: return IS_TRUE(a.SInt0 > b.SInt0)
							 || IS_TRUE(a.SInt1 > b.SInt1);

				case  3: return IS_TRUE(a.SInt0 > b.SInt0)
							 || IS_TRUE(a.SInt1 > b.SInt1)
							 || IS_TRUE(a.SInt2 > b.SInt2);

				default: return IS_TRUE(a.SInt0 > b.SInt0)
							 || IS_TRUE(a.SInt1 > b.SInt1)
							 || IS_TRUE(a.SInt2 > b.SInt2)
							 || IS_TRUE(a.SInt3 > b.SInt3);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_GT_EPI64(v128 a, v128 b)
		{
			return IS_TRUE(a.SLong0 > b.SLong0)
				|| IS_TRUE(a.SLong1 > b.SLong1);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_GT_PS(v128 a, v128 b, byte elements = 4)
		{
			switch (elements)
			{
				case  1: return IS_TRUE(a.Float0 > b.Float0);

				case  2: return IS_TRUE(a.Float0 > b.Float0)
							 || IS_TRUE(a.Float1 > b.Float1);

				case  3: return IS_TRUE(a.Float0 > b.Float0)
							 || IS_TRUE(a.Float1 > b.Float1)
							 || IS_TRUE(a.Float2 > b.Float2);

				default: return IS_TRUE(a.Float0 > b.Float0)
							 || IS_TRUE(a.Float1 > b.Float1)
							 || IS_TRUE(a.Float2 > b.Float2)
							 || IS_TRUE(a.Float3 > b.Float3);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_GT_PD(v128 a, v128 b)
		{
			return IS_TRUE(a.Double0 > b.Double0)
				|| IS_TRUE(a.Double1 > b.Double1);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_GT_EPI8(v256 a, v256 b)
		{
			return IS_TRUE(a.SByte0  > b.SByte0)
				|| IS_TRUE(a.SByte1  > b.SByte1)
				|| IS_TRUE(a.SByte2  > b.SByte2)
				|| IS_TRUE(a.SByte3  > b.SByte3)
				|| IS_TRUE(a.SByte4  > b.SByte4)
				|| IS_TRUE(a.SByte5  > b.SByte5)
				|| IS_TRUE(a.SByte6  > b.SByte6)
				|| IS_TRUE(a.SByte7  > b.SByte7)
				|| IS_TRUE(a.SByte8  > b.SByte8)
				|| IS_TRUE(a.SByte9  > b.SByte9)
				|| IS_TRUE(a.SByte10 > b.SByte10)
				|| IS_TRUE(a.SByte11 > b.SByte11)
				|| IS_TRUE(a.SByte12 > b.SByte12)
				|| IS_TRUE(a.SByte13 > b.SByte13)
				|| IS_TRUE(a.SByte14 > b.SByte14)
				|| IS_TRUE(a.SByte15 > b.SByte15)
			    || IS_TRUE(a.SByte16 > b.SByte16)
				|| IS_TRUE(a.SByte17 > b.SByte17)
				|| IS_TRUE(a.SByte18 > b.SByte18)
				|| IS_TRUE(a.SByte19 > b.SByte19)
				|| IS_TRUE(a.SByte20 > b.SByte20)
				|| IS_TRUE(a.SByte21 > b.SByte21)
				|| IS_TRUE(a.SByte22 > b.SByte22)
				|| IS_TRUE(a.SByte23 > b.SByte23)
				|| IS_TRUE(a.SByte24 > b.SByte24)
				|| IS_TRUE(a.SByte25 > b.SByte25)
				|| IS_TRUE(a.SByte26 > b.SByte26)
				|| IS_TRUE(a.SByte27 > b.SByte27)
				|| IS_TRUE(a.SByte28 > b.SByte28)
				|| IS_TRUE(a.SByte29 > b.SByte29)
				|| IS_TRUE(a.SByte30 > b.SByte30)
				|| IS_TRUE(a.SByte31 > b.SByte31);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_GT_EPI16(v256 a, v256 b)
		{
			return IS_TRUE(a.SShort0  > b.SShort0)
				|| IS_TRUE(a.SShort1  > b.SShort1)
				|| IS_TRUE(a.SShort2  > b.SShort2)
				|| IS_TRUE(a.SShort3  > b.SShort3)
				|| IS_TRUE(a.SShort4  > b.SShort4)
				|| IS_TRUE(a.SShort5  > b.SShort5)
				|| IS_TRUE(a.SShort6  > b.SShort6)
				|| IS_TRUE(a.SShort7  > b.SShort7)
				|| IS_TRUE(a.SShort8  > b.SShort8)
				|| IS_TRUE(a.SShort9  > b.SShort9)
				|| IS_TRUE(a.SShort10 > b.SShort10)
				|| IS_TRUE(a.SShort11 > b.SShort11)
				|| IS_TRUE(a.SShort12 > b.SShort12)
				|| IS_TRUE(a.SShort13 > b.SShort13)
				|| IS_TRUE(a.SShort14 > b.SShort14)
				|| IS_TRUE(a.SShort15 > b.SShort15);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_GT_EPI32(v256 a, v256 b)
		{
			return IS_TRUE(a.SInt0 > b.SInt0)
				|| IS_TRUE(a.SInt1 > b.SInt1)
				|| IS_TRUE(a.SInt2 > b.SInt2)
				|| IS_TRUE(a.SInt3 > b.SInt3)
				|| IS_TRUE(a.SInt4 > b.SInt4)
				|| IS_TRUE(a.SInt5 > b.SInt5)
				|| IS_TRUE(a.SInt6 > b.SInt6)
				|| IS_TRUE(a.SInt7 > b.SInt7);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_GT_EPI64(v256 a, v256 b, byte elements = 4)
		{
			if (elements == 3)
			{
				return IS_TRUE(a.SLong0 > b.SLong0)
					|| IS_TRUE(a.SLong1 > b.SLong1)
					|| IS_TRUE(a.SLong2 > b.SLong2);
			}
			else
			{
				return IS_TRUE(a.SLong0 > b.SLong0)
					|| IS_TRUE(a.SLong1 > b.SLong1)
					|| IS_TRUE(a.SLong2 > b.SLong2)
					|| IS_TRUE(a.SLong3 > b.SLong3);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_GT_EPU8(v256 a, v256 b)
		{
			return IS_TRUE(a.Byte0  > b.Byte0)
				|| IS_TRUE(a.Byte1  > b.Byte1)
				|| IS_TRUE(a.Byte2  > b.Byte2)
				|| IS_TRUE(a.Byte3  > b.Byte3)
				|| IS_TRUE(a.Byte4  > b.Byte4)
				|| IS_TRUE(a.Byte5  > b.Byte5)
				|| IS_TRUE(a.Byte6  > b.Byte6)
				|| IS_TRUE(a.Byte7  > b.Byte7)
				|| IS_TRUE(a.Byte8  > b.Byte8)
				|| IS_TRUE(a.Byte9  > b.Byte9)
				|| IS_TRUE(a.Byte10 > b.Byte10)
				|| IS_TRUE(a.Byte11 > b.Byte11)
				|| IS_TRUE(a.Byte12 > b.Byte12)
				|| IS_TRUE(a.Byte13 > b.Byte13)
				|| IS_TRUE(a.Byte14 > b.Byte14)
				|| IS_TRUE(a.Byte15 > b.Byte15)
			    || IS_TRUE(a.Byte16 > b.Byte16)
				|| IS_TRUE(a.Byte17 > b.Byte17)
				|| IS_TRUE(a.Byte18 > b.Byte18)
				|| IS_TRUE(a.Byte19 > b.Byte19)
				|| IS_TRUE(a.Byte20 > b.Byte20)
				|| IS_TRUE(a.Byte21 > b.Byte21)
				|| IS_TRUE(a.Byte22 > b.Byte22)
				|| IS_TRUE(a.Byte23 > b.Byte23)
				|| IS_TRUE(a.Byte24 > b.Byte24)
				|| IS_TRUE(a.Byte25 > b.Byte25)
				|| IS_TRUE(a.Byte26 > b.Byte26)
				|| IS_TRUE(a.Byte27 > b.Byte27)
				|| IS_TRUE(a.Byte28 > b.Byte28)
				|| IS_TRUE(a.Byte29 > b.Byte29)
				|| IS_TRUE(a.Byte30 > b.Byte30)
				|| IS_TRUE(a.Byte31 > b.Byte31);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_GT_EPU16(v256 a, v256 b)
		{
			return IS_TRUE(a.UShort0  > b.UShort0)
				|| IS_TRUE(a.UShort1  > b.UShort1)
				|| IS_TRUE(a.UShort2  > b.UShort2)
				|| IS_TRUE(a.UShort3  > b.UShort3)
				|| IS_TRUE(a.UShort4  > b.UShort4)
				|| IS_TRUE(a.UShort5  > b.UShort5)
				|| IS_TRUE(a.UShort6  > b.UShort6)
				|| IS_TRUE(a.UShort7  > b.UShort7)
				|| IS_TRUE(a.UShort8  > b.UShort8)
				|| IS_TRUE(a.UShort9  > b.UShort9)
				|| IS_TRUE(a.UShort10 > b.UShort10)
				|| IS_TRUE(a.UShort11 > b.UShort11)
				|| IS_TRUE(a.UShort12 > b.UShort12)
				|| IS_TRUE(a.UShort13 > b.UShort13)
				|| IS_TRUE(a.UShort14 > b.UShort14)
				|| IS_TRUE(a.UShort15 > b.UShort15);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_GT_EPU32(v256 a, v256 b)
		{
			return IS_TRUE(a.UInt0 > b.UInt0)
				|| IS_TRUE(a.UInt1 > b.UInt1)
				|| IS_TRUE(a.UInt2 > b.UInt2)
				|| IS_TRUE(a.UInt3 > b.UInt3)
				|| IS_TRUE(a.UInt4 > b.UInt4)
				|| IS_TRUE(a.UInt5 > b.UInt5)
				|| IS_TRUE(a.UInt6 > b.UInt6)
				|| IS_TRUE(a.UInt7 > b.UInt7);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_GT_EPU64(v256 a, v256 b, byte elements = 4)
		{
			if (elements == 3)
			{
				return IS_TRUE(a.ULong0 > b.ULong0)
					|| IS_TRUE(a.ULong1 > b.ULong1)
					|| IS_TRUE(a.ULong2 > b.ULong2);
			}
			else
			{
				return IS_TRUE(a.ULong0 > b.ULong0)
					|| IS_TRUE(a.ULong1 > b.ULong1)
					|| IS_TRUE(a.ULong2 > b.ULong2)
					|| IS_TRUE(a.ULong3 > b.ULong3);
			}
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_GT_PS(v256 a, v256 b)
		{
			return IS_TRUE(a.Float0 > b.Float0)
				|| IS_TRUE(a.Float1 > b.Float1)
				|| IS_TRUE(a.Float2 > b.Float2)
				|| IS_TRUE(a.Float3 > b.Float3)
				|| IS_TRUE(a.Float4 > b.Float4)
				|| IS_TRUE(a.Float5 > b.Float5)
				|| IS_TRUE(a.Float6 > b.Float6)
				|| IS_TRUE(a.Float7 > b.Float7);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_GT_PD(v256 a, v256 b, byte elements = 4)
		{
			if (elements == 3)
			{
				return IS_TRUE(a.Double0 > b.Double0)
					|| IS_TRUE(a.Double1 > b.Double1)
					|| IS_TRUE(a.Double2 > b.Double2);
			}
			else
			{
				return IS_TRUE(a.Double0 > b.Double0)
					|| IS_TRUE(a.Double1 > b.Double1)
					|| IS_TRUE(a.Double2 > b.Double2)
					|| IS_TRUE(a.Double3 > b.Double3);
			}
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_LT_EPU8(v128 a, v128 b, byte elements = 16)
		{
			switch (elements)
			{
				case  2: return IS_TRUE(a.Byte0  < b.Byte0)
							 || IS_TRUE(a.Byte1  < b.Byte1);

				case  3: return IS_TRUE(a.Byte0  < b.Byte0)
							 || IS_TRUE(a.Byte1  < b.Byte1)
							 || IS_TRUE(a.Byte2  < b.Byte2);

				case  4: return IS_TRUE(a.Byte0  < b.Byte0)
							 || IS_TRUE(a.Byte1  < b.Byte1)
							 || IS_TRUE(a.Byte2  < b.Byte2)
							 || IS_TRUE(a.Byte3  < b.Byte3);

				case  8: return IS_TRUE(a.Byte0  < b.Byte0)
							 || IS_TRUE(a.Byte1  < b.Byte1)
							 || IS_TRUE(a.Byte2  < b.Byte2)
							 || IS_TRUE(a.Byte3  < b.Byte3)
							 || IS_TRUE(a.Byte4  < b.Byte4)
							 || IS_TRUE(a.Byte5  < b.Byte5)
							 || IS_TRUE(a.Byte6  < b.Byte6)
							 || IS_TRUE(a.Byte7  < b.Byte7);

				default: return IS_TRUE(a.Byte0  < b.Byte0)
							 || IS_TRUE(a.Byte1  < b.Byte1)
							 || IS_TRUE(a.Byte2  < b.Byte2)
							 || IS_TRUE(a.Byte3  < b.Byte3)
							 || IS_TRUE(a.Byte4  < b.Byte4)
							 || IS_TRUE(a.Byte5  < b.Byte5)
							 || IS_TRUE(a.Byte6  < b.Byte6)
							 || IS_TRUE(a.Byte7  < b.Byte7)
							 || IS_TRUE(a.Byte8  < b.Byte8)
							 || IS_TRUE(a.Byte9  < b.Byte9)
							 || IS_TRUE(a.Byte10 < b.Byte10)
							 || IS_TRUE(a.Byte11 < b.Byte11)
							 || IS_TRUE(a.Byte12 < b.Byte12)
							 || IS_TRUE(a.Byte13 < b.Byte13)
							 || IS_TRUE(a.Byte14 < b.Byte14)
							 || IS_TRUE(a.Byte15 < b.Byte15);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_LT_EPU16(v128 a, v128 b, byte elements = 8)
		{
			switch (elements)
			{
				case  2: return IS_TRUE(a.UShort0  < b.UShort0)
							 || IS_TRUE(a.UShort1  < b.UShort1);

				case  3: return IS_TRUE(a.UShort0  < b.UShort0)
							 || IS_TRUE(a.UShort1  < b.UShort1)
							 || IS_TRUE(a.UShort2  < b.UShort2);

				case  4: return IS_TRUE(a.UShort0  < b.UShort0)
							 || IS_TRUE(a.UShort1  < b.UShort1)
							 || IS_TRUE(a.UShort2  < b.UShort2)
							 || IS_TRUE(a.UShort3  < b.UShort3);

				default: return IS_TRUE(a.UShort0  < b.UShort0)
							 || IS_TRUE(a.UShort1  < b.UShort1)
							 || IS_TRUE(a.UShort2  < b.UShort2)
							 || IS_TRUE(a.UShort3  < b.UShort3)
							 || IS_TRUE(a.UShort4  < b.UShort4)
							 || IS_TRUE(a.UShort5  < b.UShort5)
							 || IS_TRUE(a.UShort6  < b.UShort6)
							 || IS_TRUE(a.UShort7  < b.UShort7);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_LT_EPU32(v128 a, v128 b, byte elements = 4)
		{
			switch (elements)
			{
				case  2: return IS_TRUE(a.UInt0  < b.UInt0)
							 || IS_TRUE(a.UInt1  < b.UInt1);

				case  3: return IS_TRUE(a.UInt0  < b.UInt0)
							 || IS_TRUE(a.UInt1  < b.UInt1)
							 || IS_TRUE(a.UInt2  < b.UInt2);

				default: return IS_TRUE(a.UInt0  < b.UInt0)
							 || IS_TRUE(a.UInt1  < b.UInt1)
							 || IS_TRUE(a.UInt2  < b.UInt2)
							 || IS_TRUE(a.UInt3  < b.UInt3);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_LT_EPU64(v128 a, v128 b)
		{
			return IS_TRUE(a.ULong0 < b.ULong0)
				|| IS_TRUE(a.ULong1 < b.ULong1);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_LT_EPI8(v128 a, v128 b, byte elements = 16)
		{
			switch (elements)
			{
				case  2: return IS_TRUE(a.SByte0  < b.SByte0)
							 || IS_TRUE(a.SByte1  < b.SByte1);

				case  3: return IS_TRUE(a.SByte0  < b.SByte0)
							 || IS_TRUE(a.SByte1  < b.SByte1)
							 || IS_TRUE(a.SByte2  < b.SByte2);

				case  4: return IS_TRUE(a.SByte0  < b.SByte0)
							 || IS_TRUE(a.SByte1  < b.SByte1)
							 || IS_TRUE(a.SByte2  < b.SByte2)
							 || IS_TRUE(a.SByte3  < b.SByte3);

				case  8: return IS_TRUE(a.SByte0  < b.SByte0)
							 || IS_TRUE(a.SByte1  < b.SByte1)
							 || IS_TRUE(a.SByte2  < b.SByte2)
							 || IS_TRUE(a.SByte3  < b.SByte3)
							 || IS_TRUE(a.SByte4  < b.SByte4)
							 || IS_TRUE(a.SByte5  < b.SByte5)
							 || IS_TRUE(a.SByte6  < b.SByte6)
							 || IS_TRUE(a.SByte7  < b.SByte7);

				default: return IS_TRUE(a.SByte0  < b.SByte0)
							 || IS_TRUE(a.SByte1  < b.SByte1)
							 || IS_TRUE(a.SByte2  < b.SByte2)
							 || IS_TRUE(a.SByte3  < b.SByte3)
							 || IS_TRUE(a.SByte4  < b.SByte4)
							 || IS_TRUE(a.SByte5  < b.SByte5)
							 || IS_TRUE(a.SByte6  < b.SByte6)
							 || IS_TRUE(a.SByte7  < b.SByte7)
							 || IS_TRUE(a.SByte8  < b.SByte8)
							 || IS_TRUE(a.SByte9  < b.SByte9)
							 || IS_TRUE(a.SByte10 < b.SByte10)
							 || IS_TRUE(a.SByte11 < b.SByte11)
							 || IS_TRUE(a.SByte12 < b.SByte12)
							 || IS_TRUE(a.SByte13 < b.SByte13)
							 || IS_TRUE(a.SByte14 < b.SByte14)
							 || IS_TRUE(a.SByte15 < b.SByte15);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_LT_EPI16(v128 a, v128 b, byte elements = 8)
		{
			switch (elements)
			{
				case  2: return IS_TRUE(a.SShort0 < b.SShort0)
							 || IS_TRUE(a.SShort1 < b.SShort1);

				case  3: return IS_TRUE(a.SShort0 < b.SShort0)
							 || IS_TRUE(a.SShort1 < b.SShort1)
							 || IS_TRUE(a.SShort2 < b.SShort2);

				case  4: return IS_TRUE(a.SShort0 < b.SShort0)
							 || IS_TRUE(a.SShort1 < b.SShort1)
							 || IS_TRUE(a.SShort2 < b.SShort2)
							 || IS_TRUE(a.SShort3 < b.SShort3);

				default: return IS_TRUE(a.SShort0 < b.SShort0)
							 || IS_TRUE(a.SShort1 < b.SShort1)
							 || IS_TRUE(a.SShort2 < b.SShort2)
							 || IS_TRUE(a.SShort3 < b.SShort3)
							 || IS_TRUE(a.SShort4 < b.SShort4)
							 || IS_TRUE(a.SShort5 < b.SShort5)
							 || IS_TRUE(a.SShort6 < b.SShort6)
							 || IS_TRUE(a.SShort7 < b.SShort7);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_LT_EPI32(v128 a, v128 b, byte elements = 4)
		{
			switch (elements)
			{
				case  2: return IS_TRUE(a.SInt0 < b.SInt0)
							 || IS_TRUE(a.SInt1 < b.SInt1);

				case  3: return IS_TRUE(a.SInt0 < b.SInt0)
							 || IS_TRUE(a.SInt1 < b.SInt1)
							 || IS_TRUE(a.SInt2 < b.SInt2);

				default: return IS_TRUE(a.SInt0 < b.SInt0)
							 || IS_TRUE(a.SInt1 < b.SInt1)
							 || IS_TRUE(a.SInt2 < b.SInt2)
							 || IS_TRUE(a.SInt3 < b.SInt3);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_LT_EPI64(v128 a, v128 b)
		{
			return IS_TRUE(a.SLong0 < b.SLong0)
				|| IS_TRUE(a.SLong1 < b.SLong1);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_LT_PS(v128 a, v128 b, byte elements = 4)
		{
			switch (elements)
			{
				case  1: return IS_TRUE(a.Float0 < b.Float0);

				case  2: return IS_TRUE(a.Float0 < b.Float0)
							 || IS_TRUE(a.Float1 < b.Float1);

				case  3: return IS_TRUE(a.Float0 < b.Float0)
							 || IS_TRUE(a.Float1 < b.Float1)
							 || IS_TRUE(a.Float2 < b.Float2);

				default: return IS_TRUE(a.Float0 < b.Float0)
							 || IS_TRUE(a.Float1 < b.Float1)
							 || IS_TRUE(a.Float2 < b.Float2)
							 || IS_TRUE(a.Float3 < b.Float3);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_LT_PD(v128 a, v128 b)
		{
			return IS_TRUE(a.Double0 < b.Double0)
				|| IS_TRUE(a.Double1 < b.Double1);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_LT_EPI8(v256 a, v256 b)
		{
			return IS_TRUE(a.SByte0  < b.SByte0)
				|| IS_TRUE(a.SByte1  < b.SByte1)
				|| IS_TRUE(a.SByte2  < b.SByte2)
				|| IS_TRUE(a.SByte3  < b.SByte3)
				|| IS_TRUE(a.SByte4  < b.SByte4)
				|| IS_TRUE(a.SByte5  < b.SByte5)
				|| IS_TRUE(a.SByte6  < b.SByte6)
				|| IS_TRUE(a.SByte7  < b.SByte7)
				|| IS_TRUE(a.SByte8  < b.SByte8)
				|| IS_TRUE(a.SByte9  < b.SByte9)
				|| IS_TRUE(a.SByte10 < b.SByte10)
				|| IS_TRUE(a.SByte11 < b.SByte11)
				|| IS_TRUE(a.SByte12 < b.SByte12)
				|| IS_TRUE(a.SByte13 < b.SByte13)
				|| IS_TRUE(a.SByte14 < b.SByte14)
				|| IS_TRUE(a.SByte15 < b.SByte15)
			    || IS_TRUE(a.SByte16 < b.SByte16)
				|| IS_TRUE(a.SByte17 < b.SByte17)
				|| IS_TRUE(a.SByte18 < b.SByte18)
				|| IS_TRUE(a.SByte19 < b.SByte19)
				|| IS_TRUE(a.SByte20 < b.SByte20)
				|| IS_TRUE(a.SByte21 < b.SByte21)
				|| IS_TRUE(a.SByte22 < b.SByte22)
				|| IS_TRUE(a.SByte23 < b.SByte23)
				|| IS_TRUE(a.SByte24 < b.SByte24)
				|| IS_TRUE(a.SByte25 < b.SByte25)
				|| IS_TRUE(a.SByte26 < b.SByte26)
				|| IS_TRUE(a.SByte27 < b.SByte27)
				|| IS_TRUE(a.SByte28 < b.SByte28)
				|| IS_TRUE(a.SByte29 < b.SByte29)
				|| IS_TRUE(a.SByte30 < b.SByte30)
				|| IS_TRUE(a.SByte31 < b.SByte31);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_LT_EPI16(v256 a, v256 b)
		{
			return IS_TRUE(a.SShort0  < b.SShort0)
				|| IS_TRUE(a.SShort1  < b.SShort1)
				|| IS_TRUE(a.SShort2  < b.SShort2)
				|| IS_TRUE(a.SShort3  < b.SShort3)
				|| IS_TRUE(a.SShort4  < b.SShort4)
				|| IS_TRUE(a.SShort5  < b.SShort5)
				|| IS_TRUE(a.SShort6  < b.SShort6)
				|| IS_TRUE(a.SShort7  < b.SShort7)
				|| IS_TRUE(a.SShort8  < b.SShort8)
				|| IS_TRUE(a.SShort9  < b.SShort9)
				|| IS_TRUE(a.SShort10 < b.SShort10)
				|| IS_TRUE(a.SShort11 < b.SShort11)
				|| IS_TRUE(a.SShort12 < b.SShort12)
				|| IS_TRUE(a.SShort13 < b.SShort13)
				|| IS_TRUE(a.SShort14 < b.SShort14)
				|| IS_TRUE(a.SShort15 < b.SShort15);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_LT_EPI32(v256 a, v256 b)
		{
			return IS_TRUE(a.SInt0 < b.SInt0)
				|| IS_TRUE(a.SInt1 < b.SInt1)
				|| IS_TRUE(a.SInt2 < b.SInt2)
				|| IS_TRUE(a.SInt3 < b.SInt3)
				|| IS_TRUE(a.SInt4 < b.SInt4)
				|| IS_TRUE(a.SInt5 < b.SInt5)
				|| IS_TRUE(a.SInt6 < b.SInt6)
				|| IS_TRUE(a.SInt7 < b.SInt7);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_LT_EPI64(v256 a, v256 b, byte elements = 4)
		{
			if (elements == 3)
			{
				return IS_TRUE(a.SLong0 < b.SLong0)
					|| IS_TRUE(a.SLong1 < b.SLong1)
					|| IS_TRUE(a.SLong2 < b.SLong2);
			}
			else
			{
				return IS_TRUE(a.SLong0 < b.SLong0)
					|| IS_TRUE(a.SLong1 < b.SLong1)
					|| IS_TRUE(a.SLong2 < b.SLong2)
					|| IS_TRUE(a.SLong3 < b.SLong3);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_LT_EPU8(v256 a, v256 b)
		{
			return IS_TRUE(a.Byte0  < b.Byte0)
				|| IS_TRUE(a.Byte1  < b.Byte1)
				|| IS_TRUE(a.Byte2  < b.Byte2)
				|| IS_TRUE(a.Byte3  < b.Byte3)
				|| IS_TRUE(a.Byte4  < b.Byte4)
				|| IS_TRUE(a.Byte5  < b.Byte5)
				|| IS_TRUE(a.Byte6  < b.Byte6)
				|| IS_TRUE(a.Byte7  < b.Byte7)
				|| IS_TRUE(a.Byte8  < b.Byte8)
				|| IS_TRUE(a.Byte9  < b.Byte9)
				|| IS_TRUE(a.Byte10 < b.Byte10)
				|| IS_TRUE(a.Byte11 < b.Byte11)
				|| IS_TRUE(a.Byte12 < b.Byte12)
				|| IS_TRUE(a.Byte13 < b.Byte13)
				|| IS_TRUE(a.Byte14 < b.Byte14)
				|| IS_TRUE(a.Byte15 < b.Byte15)
			    || IS_TRUE(a.Byte16 < b.Byte16)
				|| IS_TRUE(a.Byte17 < b.Byte17)
				|| IS_TRUE(a.Byte18 < b.Byte18)
				|| IS_TRUE(a.Byte19 < b.Byte19)
				|| IS_TRUE(a.Byte20 < b.Byte20)
				|| IS_TRUE(a.Byte21 < b.Byte21)
				|| IS_TRUE(a.Byte22 < b.Byte22)
				|| IS_TRUE(a.Byte23 < b.Byte23)
				|| IS_TRUE(a.Byte24 < b.Byte24)
				|| IS_TRUE(a.Byte25 < b.Byte25)
				|| IS_TRUE(a.Byte26 < b.Byte26)
				|| IS_TRUE(a.Byte27 < b.Byte27)
				|| IS_TRUE(a.Byte28 < b.Byte28)
				|| IS_TRUE(a.Byte29 < b.Byte29)
				|| IS_TRUE(a.Byte30 < b.Byte30)
				|| IS_TRUE(a.Byte31 < b.Byte31);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_LT_EPU16(v256 a, v256 b)
		{
			return IS_TRUE(a.UShort0  < b.UShort0)
				|| IS_TRUE(a.UShort1  < b.UShort1)
				|| IS_TRUE(a.UShort2  < b.UShort2)
				|| IS_TRUE(a.UShort3  < b.UShort3)
				|| IS_TRUE(a.UShort4  < b.UShort4)
				|| IS_TRUE(a.UShort5  < b.UShort5)
				|| IS_TRUE(a.UShort6  < b.UShort6)
				|| IS_TRUE(a.UShort7  < b.UShort7)
				|| IS_TRUE(a.UShort8  < b.UShort8)
				|| IS_TRUE(a.UShort9  < b.UShort9)
				|| IS_TRUE(a.UShort10 < b.UShort10)
				|| IS_TRUE(a.UShort11 < b.UShort11)
				|| IS_TRUE(a.UShort12 < b.UShort12)
				|| IS_TRUE(a.UShort13 < b.UShort13)
				|| IS_TRUE(a.UShort14 < b.UShort14)
				|| IS_TRUE(a.UShort15 < b.UShort15);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_LT_EPU32(v256 a, v256 b)
		{
			return IS_TRUE(a.UInt0 < b.UInt0)
				|| IS_TRUE(a.UInt1 < b.UInt1)
				|| IS_TRUE(a.UInt2 < b.UInt2)
				|| IS_TRUE(a.UInt3 < b.UInt3)
				|| IS_TRUE(a.UInt4 < b.UInt4)
				|| IS_TRUE(a.UInt5 < b.UInt5)
				|| IS_TRUE(a.UInt6 < b.UInt6)
				|| IS_TRUE(a.UInt7 < b.UInt7);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_LT_EPU64(v256 a, v256 b, byte elements = 4)
		{
			if (elements == 3)
			{
				return IS_TRUE(a.ULong0 < b.ULong0)
					|| IS_TRUE(a.ULong1 < b.ULong1)
					|| IS_TRUE(a.ULong2 < b.ULong2);
			}
			else
			{
				return IS_TRUE(a.ULong0 < b.ULong0)
					|| IS_TRUE(a.ULong1 < b.ULong1)
					|| IS_TRUE(a.ULong2 < b.ULong2)
					|| IS_TRUE(a.ULong3 < b.ULong3);
			}
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_LT_PS(v256 a, v256 b)
		{
			return IS_TRUE(a.Float0 < b.Float0)
				|| IS_TRUE(a.Float1 < b.Float1)
				|| IS_TRUE(a.Float2 < b.Float2)
				|| IS_TRUE(a.Float3 < b.Float3)
				|| IS_TRUE(a.Float4 < b.Float4)
				|| IS_TRUE(a.Float5 < b.Float5)
				|| IS_TRUE(a.Float6 < b.Float6)
				|| IS_TRUE(a.Float7 < b.Float7);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_LT_PD(v256 a, v256 b, byte elements = 4)
		{
			if (elements == 3)
			{
				return IS_TRUE(a.Double0 < b.Double0)
					|| IS_TRUE(a.Double1 < b.Double1)
					|| IS_TRUE(a.Double2 < b.Double2);
			}
			else
			{
				return IS_TRUE(a.Double0 < b.Double0)
					|| IS_TRUE(a.Double1 < b.Double1)
					|| IS_TRUE(a.Double2 < b.Double2)
					|| IS_TRUE(a.Double3 < b.Double3);
			}
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_GE_EPU8(v128 a, v128 b, byte elements = 16)
		{
			switch (elements)
			{
				case  2: return IS_TRUE(a.Byte0  >= b.Byte0)
							 || IS_TRUE(a.Byte1  >= b.Byte1);

				case  3: return IS_TRUE(a.Byte0  >= b.Byte0)
							 || IS_TRUE(a.Byte1  >= b.Byte1)
							 || IS_TRUE(a.Byte2  >= b.Byte2);

				case  4: return IS_TRUE(a.Byte0  >= b.Byte0)
							 || IS_TRUE(a.Byte1  >= b.Byte1)
							 || IS_TRUE(a.Byte2  >= b.Byte2)
							 || IS_TRUE(a.Byte3  >= b.Byte3);

				case  8: return IS_TRUE(a.Byte0  >= b.Byte0)
							 || IS_TRUE(a.Byte1  >= b.Byte1)
							 || IS_TRUE(a.Byte2  >= b.Byte2)
							 || IS_TRUE(a.Byte3  >= b.Byte3)
							 || IS_TRUE(a.Byte4  >= b.Byte4)
							 || IS_TRUE(a.Byte5  >= b.Byte5)
							 || IS_TRUE(a.Byte6  >= b.Byte6)
							 || IS_TRUE(a.Byte7  >= b.Byte7);

				default: return IS_TRUE(a.Byte0  >= b.Byte0)
							 || IS_TRUE(a.Byte1  >= b.Byte1)
							 || IS_TRUE(a.Byte2  >= b.Byte2)
							 || IS_TRUE(a.Byte3  >= b.Byte3)
							 || IS_TRUE(a.Byte4  >= b.Byte4)
							 || IS_TRUE(a.Byte5  >= b.Byte5)
							 || IS_TRUE(a.Byte6  >= b.Byte6)
							 || IS_TRUE(a.Byte7  >= b.Byte7)
							 || IS_TRUE(a.Byte8  >= b.Byte8)
							 || IS_TRUE(a.Byte9  >= b.Byte9)
							 || IS_TRUE(a.Byte10 >= b.Byte10)
							 || IS_TRUE(a.Byte11 >= b.Byte11)
							 || IS_TRUE(a.Byte12 >= b.Byte12)
							 || IS_TRUE(a.Byte13 >= b.Byte13)
							 || IS_TRUE(a.Byte14 >= b.Byte14)
							 || IS_TRUE(a.Byte15 >= b.Byte15);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_GE_EPU16(v128 a, v128 b, byte elements = 8)
		{
			switch (elements)
			{
				case  2: return IS_TRUE(a.UShort0  >= b.UShort0)
							 || IS_TRUE(a.UShort1  >= b.UShort1);

				case  3: return IS_TRUE(a.UShort0  >= b.UShort0)
							 || IS_TRUE(a.UShort1  >= b.UShort1)
							 || IS_TRUE(a.UShort2  >= b.UShort2);

				case  4: return IS_TRUE(a.UShort0  >= b.UShort0)
							 || IS_TRUE(a.UShort1  >= b.UShort1)
							 || IS_TRUE(a.UShort2  >= b.UShort2)
							 || IS_TRUE(a.UShort3  >= b.UShort3);

				default: return IS_TRUE(a.UShort0  >= b.UShort0)
							 || IS_TRUE(a.UShort1  >= b.UShort1)
							 || IS_TRUE(a.UShort2  >= b.UShort2)
							 || IS_TRUE(a.UShort3  >= b.UShort3)
							 || IS_TRUE(a.UShort4  >= b.UShort4)
							 || IS_TRUE(a.UShort5  >= b.UShort5)
							 || IS_TRUE(a.UShort6  >= b.UShort6)
							 || IS_TRUE(a.UShort7  >= b.UShort7);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_GE_EPU32(v128 a, v128 b, byte elements = 4)
		{
			switch (elements)
			{
				case  2: return IS_TRUE(a.UInt0  >= b.UInt0)
							 || IS_TRUE(a.UInt1  >= b.UInt1);

				case  3: return IS_TRUE(a.UInt0  >= b.UInt0)
							 || IS_TRUE(a.UInt1  >= b.UInt1)
							 || IS_TRUE(a.UInt2  >= b.UInt2);

				default: return IS_TRUE(a.UInt0  >= b.UInt0)
							 || IS_TRUE(a.UInt1  >= b.UInt1)
							 || IS_TRUE(a.UInt2  >= b.UInt2)
							 || IS_TRUE(a.UInt3  >= b.UInt3);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_GE_EPU64(v128 a, v128 b)
		{
			return IS_TRUE(a.ULong0 >= b.ULong0)
				|| IS_TRUE(a.ULong1 >= b.ULong1);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_GE_EPI8(v128 a, v128 b, byte elements = 16)
		{
			switch (elements)
			{
				case  2: return IS_TRUE(a.SByte0  >= b.SByte0)
							 || IS_TRUE(a.SByte1  >= b.SByte1);

				case  3: return IS_TRUE(a.SByte0  >= b.SByte0)
							 || IS_TRUE(a.SByte1  >= b.SByte1)
							 || IS_TRUE(a.SByte2  >= b.SByte2);

				case  4: return IS_TRUE(a.SByte0  >= b.SByte0)
							 || IS_TRUE(a.SByte1  >= b.SByte1)
							 || IS_TRUE(a.SByte2  >= b.SByte2)
							 || IS_TRUE(a.SByte3  >= b.SByte3);

				case  8: return IS_TRUE(a.SByte0  >= b.SByte0)
							 || IS_TRUE(a.SByte1  >= b.SByte1)
							 || IS_TRUE(a.SByte2  >= b.SByte2)
							 || IS_TRUE(a.SByte3  >= b.SByte3)
							 || IS_TRUE(a.SByte4  >= b.SByte4)
							 || IS_TRUE(a.SByte5  >= b.SByte5)
							 || IS_TRUE(a.SByte6  >= b.SByte6)
							 || IS_TRUE(a.SByte7  >= b.SByte7);

				default: return IS_TRUE(a.SByte0  >= b.SByte0)
							 || IS_TRUE(a.SByte1  >= b.SByte1)
							 || IS_TRUE(a.SByte2  >= b.SByte2)
							 || IS_TRUE(a.SByte3  >= b.SByte3)
							 || IS_TRUE(a.SByte4  >= b.SByte4)
							 || IS_TRUE(a.SByte5  >= b.SByte5)
							 || IS_TRUE(a.SByte6  >= b.SByte6)
							 || IS_TRUE(a.SByte7  >= b.SByte7)
							 || IS_TRUE(a.SByte8  >= b.SByte8)
							 || IS_TRUE(a.SByte9  >= b.SByte9)
							 || IS_TRUE(a.SByte10 >= b.SByte10)
							 || IS_TRUE(a.SByte11 >= b.SByte11)
							 || IS_TRUE(a.SByte12 >= b.SByte12)
							 || IS_TRUE(a.SByte13 >= b.SByte13)
							 || IS_TRUE(a.SByte14 >= b.SByte14)
							 || IS_TRUE(a.SByte15 >= b.SByte15);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_GE_EPI16(v128 a, v128 b, byte elements = 8)
		{
			switch (elements)
			{
				case  2: return IS_TRUE(a.SShort0 >= b.SShort0)
							 || IS_TRUE(a.SShort1 >= b.SShort1);

				case  3: return IS_TRUE(a.SShort0 >= b.SShort0)
							 || IS_TRUE(a.SShort1 >= b.SShort1)
							 || IS_TRUE(a.SShort2 >= b.SShort2);

				case  4: return IS_TRUE(a.SShort0 >= b.SShort0)
							 || IS_TRUE(a.SShort1 >= b.SShort1)
							 || IS_TRUE(a.SShort2 >= b.SShort2)
							 || IS_TRUE(a.SShort3 >= b.SShort3);

				default: return IS_TRUE(a.SShort0 >= b.SShort0)
							 || IS_TRUE(a.SShort1 >= b.SShort1)
							 || IS_TRUE(a.SShort2 >= b.SShort2)
							 || IS_TRUE(a.SShort3 >= b.SShort3)
							 || IS_TRUE(a.SShort4 >= b.SShort4)
							 || IS_TRUE(a.SShort5 >= b.SShort5)
							 || IS_TRUE(a.SShort6 >= b.SShort6)
							 || IS_TRUE(a.SShort7 >= b.SShort7);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_GE_EPI32(v128 a, v128 b, byte elements = 4)
		{
			switch (elements)
			{
				case  2: return IS_TRUE(a.SInt0 >= b.SInt0)
							 || IS_TRUE(a.SInt1 >= b.SInt1);

				case  3: return IS_TRUE(a.SInt0 >= b.SInt0)
							 || IS_TRUE(a.SInt1 >= b.SInt1)
							 || IS_TRUE(a.SInt2 >= b.SInt2);

				default: return IS_TRUE(a.SInt0 >= b.SInt0)
							 || IS_TRUE(a.SInt1 >= b.SInt1)
							 || IS_TRUE(a.SInt2 >= b.SInt2)
							 || IS_TRUE(a.SInt3 >= b.SInt3);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_GE_EPI64(v128 a, v128 b)
		{
			return IS_TRUE(a.SLong0 >= b.SLong0)
				|| IS_TRUE(a.SLong1 >= b.SLong1);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_GE_PS(v128 a, v128 b, byte elements = 4)
		{
			switch (elements)
			{
				case  1: return IS_TRUE(a.Float0 >= b.Float0);

				case  2: return IS_TRUE(a.Float0 >= b.Float0)
							 || IS_TRUE(a.Float1 >= b.Float1);

				case  3: return IS_TRUE(a.Float0 >= b.Float0)
							 || IS_TRUE(a.Float1 >= b.Float1)
							 || IS_TRUE(a.Float2 >= b.Float2);

				default: return IS_TRUE(a.Float0 >= b.Float0)
							 || IS_TRUE(a.Float1 >= b.Float1)
							 || IS_TRUE(a.Float2 >= b.Float2)
							 || IS_TRUE(a.Float3 >= b.Float3);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_GE_PD(v128 a, v128 b)
		{
			return IS_TRUE(a.Double0 >= b.Double0)
				|| IS_TRUE(a.Double1 >= b.Double1);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_GE_EPI8(v256 a, v256 b)
		{
			return IS_TRUE(a.SByte0  >= b.SByte0)
				|| IS_TRUE(a.SByte1  >= b.SByte1)
				|| IS_TRUE(a.SByte2  >= b.SByte2)
				|| IS_TRUE(a.SByte3  >= b.SByte3)
				|| IS_TRUE(a.SByte4  >= b.SByte4)
				|| IS_TRUE(a.SByte5  >= b.SByte5)
				|| IS_TRUE(a.SByte6  >= b.SByte6)
				|| IS_TRUE(a.SByte7  >= b.SByte7)
				|| IS_TRUE(a.SByte8  >= b.SByte8)
				|| IS_TRUE(a.SByte9  >= b.SByte9)
				|| IS_TRUE(a.SByte10 >= b.SByte10)
				|| IS_TRUE(a.SByte11 >= b.SByte11)
				|| IS_TRUE(a.SByte12 >= b.SByte12)
				|| IS_TRUE(a.SByte13 >= b.SByte13)
				|| IS_TRUE(a.SByte14 >= b.SByte14)
				|| IS_TRUE(a.SByte15 >= b.SByte15)
			    || IS_TRUE(a.SByte16 >= b.SByte16)
				|| IS_TRUE(a.SByte17 >= b.SByte17)
				|| IS_TRUE(a.SByte18 >= b.SByte18)
				|| IS_TRUE(a.SByte19 >= b.SByte19)
				|| IS_TRUE(a.SByte20 >= b.SByte20)
				|| IS_TRUE(a.SByte21 >= b.SByte21)
				|| IS_TRUE(a.SByte22 >= b.SByte22)
				|| IS_TRUE(a.SByte23 >= b.SByte23)
				|| IS_TRUE(a.SByte24 >= b.SByte24)
				|| IS_TRUE(a.SByte25 >= b.SByte25)
				|| IS_TRUE(a.SByte26 >= b.SByte26)
				|| IS_TRUE(a.SByte27 >= b.SByte27)
				|| IS_TRUE(a.SByte28 >= b.SByte28)
				|| IS_TRUE(a.SByte29 >= b.SByte29)
				|| IS_TRUE(a.SByte30 >= b.SByte30)
				|| IS_TRUE(a.SByte31 >= b.SByte31);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_GE_EPI16(v256 a, v256 b)
		{
			return IS_TRUE(a.SShort0  >= b.SShort0)
				|| IS_TRUE(a.SShort1  >= b.SShort1)
				|| IS_TRUE(a.SShort2  >= b.SShort2)
				|| IS_TRUE(a.SShort3  >= b.SShort3)
				|| IS_TRUE(a.SShort4  >= b.SShort4)
				|| IS_TRUE(a.SShort5  >= b.SShort5)
				|| IS_TRUE(a.SShort6  >= b.SShort6)
				|| IS_TRUE(a.SShort7  >= b.SShort7)
				|| IS_TRUE(a.SShort8  >= b.SShort8)
				|| IS_TRUE(a.SShort9  >= b.SShort9)
				|| IS_TRUE(a.SShort10 >= b.SShort10)
				|| IS_TRUE(a.SShort11 >= b.SShort11)
				|| IS_TRUE(a.SShort12 >= b.SShort12)
				|| IS_TRUE(a.SShort13 >= b.SShort13)
				|| IS_TRUE(a.SShort14 >= b.SShort14)
				|| IS_TRUE(a.SShort15 >= b.SShort15);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_GE_EPI32(v256 a, v256 b)
		{
			return IS_TRUE(a.SInt0 >= b.SInt0)
				|| IS_TRUE(a.SInt1 >= b.SInt1)
				|| IS_TRUE(a.SInt2 >= b.SInt2)
				|| IS_TRUE(a.SInt3 >= b.SInt3)
				|| IS_TRUE(a.SInt4 >= b.SInt4)
				|| IS_TRUE(a.SInt5 >= b.SInt5)
				|| IS_TRUE(a.SInt6 >= b.SInt6)
				|| IS_TRUE(a.SInt7 >= b.SInt7);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_GE_EPI64(v256 a, v256 b, byte elements = 4)
		{
			if (elements == 3)
			{
				return IS_TRUE(a.SLong0 >= b.SLong0)
					|| IS_TRUE(a.SLong1 >= b.SLong1)
					|| IS_TRUE(a.SLong2 >= b.SLong2);
			}
			else
			{
				return IS_TRUE(a.SLong0 >= b.SLong0)
					|| IS_TRUE(a.SLong1 >= b.SLong1)
					|| IS_TRUE(a.SLong2 >= b.SLong2)
					|| IS_TRUE(a.SLong3 >= b.SLong3);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_GE_EPU8(v256 a, v256 b)
		{
			return IS_TRUE(a.Byte0  >= b.Byte0)
				|| IS_TRUE(a.Byte1  >= b.Byte1)
				|| IS_TRUE(a.Byte2  >= b.Byte2)
				|| IS_TRUE(a.Byte3  >= b.Byte3)
				|| IS_TRUE(a.Byte4  >= b.Byte4)
				|| IS_TRUE(a.Byte5  >= b.Byte5)
				|| IS_TRUE(a.Byte6  >= b.Byte6)
				|| IS_TRUE(a.Byte7  >= b.Byte7)
				|| IS_TRUE(a.Byte8  >= b.Byte8)
				|| IS_TRUE(a.Byte9  >= b.Byte9)
				|| IS_TRUE(a.Byte10 >= b.Byte10)
				|| IS_TRUE(a.Byte11 >= b.Byte11)
				|| IS_TRUE(a.Byte12 >= b.Byte12)
				|| IS_TRUE(a.Byte13 >= b.Byte13)
				|| IS_TRUE(a.Byte14 >= b.Byte14)
				|| IS_TRUE(a.Byte15 >= b.Byte15)
			    || IS_TRUE(a.Byte16 >= b.Byte16)
				|| IS_TRUE(a.Byte17 >= b.Byte17)
				|| IS_TRUE(a.Byte18 >= b.Byte18)
				|| IS_TRUE(a.Byte19 >= b.Byte19)
				|| IS_TRUE(a.Byte20 >= b.Byte20)
				|| IS_TRUE(a.Byte21 >= b.Byte21)
				|| IS_TRUE(a.Byte22 >= b.Byte22)
				|| IS_TRUE(a.Byte23 >= b.Byte23)
				|| IS_TRUE(a.Byte24 >= b.Byte24)
				|| IS_TRUE(a.Byte25 >= b.Byte25)
				|| IS_TRUE(a.Byte26 >= b.Byte26)
				|| IS_TRUE(a.Byte27 >= b.Byte27)
				|| IS_TRUE(a.Byte28 >= b.Byte28)
				|| IS_TRUE(a.Byte29 >= b.Byte29)
				|| IS_TRUE(a.Byte30 >= b.Byte30)
				|| IS_TRUE(a.Byte31 >= b.Byte31);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_GE_EPU16(v256 a, v256 b)
		{
			return IS_TRUE(a.UShort0  >= b.UShort0)
				|| IS_TRUE(a.UShort1  >= b.UShort1)
				|| IS_TRUE(a.UShort2  >= b.UShort2)
				|| IS_TRUE(a.UShort3  >= b.UShort3)
				|| IS_TRUE(a.UShort4  >= b.UShort4)
				|| IS_TRUE(a.UShort5  >= b.UShort5)
				|| IS_TRUE(a.UShort6  >= b.UShort6)
				|| IS_TRUE(a.UShort7  >= b.UShort7)
				|| IS_TRUE(a.UShort8  >= b.UShort8)
				|| IS_TRUE(a.UShort9  >= b.UShort9)
				|| IS_TRUE(a.UShort10 >= b.UShort10)
				|| IS_TRUE(a.UShort11 >= b.UShort11)
				|| IS_TRUE(a.UShort12 >= b.UShort12)
				|| IS_TRUE(a.UShort13 >= b.UShort13)
				|| IS_TRUE(a.UShort14 >= b.UShort14)
				|| IS_TRUE(a.UShort15 >= b.UShort15);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_GE_EPU32(v256 a, v256 b)
		{
			return IS_TRUE(a.UInt0 >= b.UInt0)
				|| IS_TRUE(a.UInt1 >= b.UInt1)
				|| IS_TRUE(a.UInt2 >= b.UInt2)
				|| IS_TRUE(a.UInt3 >= b.UInt3)
				|| IS_TRUE(a.UInt4 >= b.UInt4)
				|| IS_TRUE(a.UInt5 >= b.UInt5)
				|| IS_TRUE(a.UInt6 >= b.UInt6)
				|| IS_TRUE(a.UInt7 >= b.UInt7);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_GE_EPU64(v256 a, v256 b, byte elements = 4)
		{
			if (elements == 3)
			{
				return IS_TRUE(a.ULong0 >= b.ULong0)
					|| IS_TRUE(a.ULong1 >= b.ULong1)
					|| IS_TRUE(a.ULong2 >= b.ULong2);
			}
			else
			{
				return IS_TRUE(a.ULong0 >= b.ULong0)
					|| IS_TRUE(a.ULong1 >= b.ULong1)
					|| IS_TRUE(a.ULong2 >= b.ULong2)
					|| IS_TRUE(a.ULong3 >= b.ULong3);
			}
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_GE_PS(v256 a, v256 b)
		{
			return IS_TRUE(a.Float0 >= b.Float0)
				|| IS_TRUE(a.Float1 >= b.Float1)
				|| IS_TRUE(a.Float2 >= b.Float2)
				|| IS_TRUE(a.Float3 >= b.Float3)
				|| IS_TRUE(a.Float4 >= b.Float4)
				|| IS_TRUE(a.Float5 >= b.Float5)
				|| IS_TRUE(a.Float6 >= b.Float6)
				|| IS_TRUE(a.Float7 >= b.Float7);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_GE_PD(v256 a, v256 b, byte elements = 4)
		{
			if (elements == 3)
			{
				return IS_TRUE(a.Double0 >= b.Double0)
					|| IS_TRUE(a.Double1 >= b.Double1)
					|| IS_TRUE(a.Double2 >= b.Double2);
			}
			else
			{
				return IS_TRUE(a.Double0 >= b.Double0)
					|| IS_TRUE(a.Double1 >= b.Double1)
					|| IS_TRUE(a.Double2 >= b.Double2)
					|| IS_TRUE(a.Double3 >= b.Double3);
			}
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_LE_EPU8(v128 a, v128 b, byte elements = 16)
		{
			switch (elements)
			{
				case  2: return IS_TRUE(a.Byte0  <= b.Byte0)
							 || IS_TRUE(a.Byte1  <= b.Byte1);

				case  3: return IS_TRUE(a.Byte0  <= b.Byte0)
							 || IS_TRUE(a.Byte1  <= b.Byte1)
							 || IS_TRUE(a.Byte2  <= b.Byte2);

				case  4: return IS_TRUE(a.Byte0  <= b.Byte0)
							 || IS_TRUE(a.Byte1  <= b.Byte1)
							 || IS_TRUE(a.Byte2  <= b.Byte2)
							 || IS_TRUE(a.Byte3  <= b.Byte3);

				case  8: return IS_TRUE(a.Byte0  <= b.Byte0)
							 || IS_TRUE(a.Byte1  <= b.Byte1)
							 || IS_TRUE(a.Byte2  <= b.Byte2)
							 || IS_TRUE(a.Byte3  <= b.Byte3)
							 || IS_TRUE(a.Byte4  <= b.Byte4)
							 || IS_TRUE(a.Byte5  <= b.Byte5)
							 || IS_TRUE(a.Byte6  <= b.Byte6)
							 || IS_TRUE(a.Byte7  <= b.Byte7);

				default: return IS_TRUE(a.Byte0  <= b.Byte0)
							 || IS_TRUE(a.Byte1  <= b.Byte1)
							 || IS_TRUE(a.Byte2  <= b.Byte2)
							 || IS_TRUE(a.Byte3  <= b.Byte3)
							 || IS_TRUE(a.Byte4  <= b.Byte4)
							 || IS_TRUE(a.Byte5  <= b.Byte5)
							 || IS_TRUE(a.Byte6  <= b.Byte6)
							 || IS_TRUE(a.Byte7  <= b.Byte7)
							 || IS_TRUE(a.Byte8  <= b.Byte8)
							 || IS_TRUE(a.Byte9  <= b.Byte9)
							 || IS_TRUE(a.Byte10 <= b.Byte10)
							 || IS_TRUE(a.Byte11 <= b.Byte11)
							 || IS_TRUE(a.Byte12 <= b.Byte12)
							 || IS_TRUE(a.Byte13 <= b.Byte13)
							 || IS_TRUE(a.Byte14 <= b.Byte14)
							 || IS_TRUE(a.Byte15 <= b.Byte15);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_LE_EPU16(v128 a, v128 b, byte elements = 8)
		{
			switch (elements)
			{
				case  2: return IS_TRUE(a.UShort0  <= b.UShort0)
							 || IS_TRUE(a.UShort1  <= b.UShort1);

				case  3: return IS_TRUE(a.UShort0  <= b.UShort0)
							 || IS_TRUE(a.UShort1  <= b.UShort1)
							 || IS_TRUE(a.UShort2  <= b.UShort2);

				case  4: return IS_TRUE(a.UShort0  <= b.UShort0)
							 || IS_TRUE(a.UShort1  <= b.UShort1)
							 || IS_TRUE(a.UShort2  <= b.UShort2)
							 || IS_TRUE(a.UShort3  <= b.UShort3);

				default: return IS_TRUE(a.UShort0  <= b.UShort0)
							 || IS_TRUE(a.UShort1  <= b.UShort1)
							 || IS_TRUE(a.UShort2  <= b.UShort2)
							 || IS_TRUE(a.UShort3  <= b.UShort3)
							 || IS_TRUE(a.UShort4  <= b.UShort4)
							 || IS_TRUE(a.UShort5  <= b.UShort5)
							 || IS_TRUE(a.UShort6  <= b.UShort6)
							 || IS_TRUE(a.UShort7  <= b.UShort7);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_LE_EPU32(v128 a, v128 b, byte elements = 4)
		{
			switch (elements)
			{
				case  2: return IS_TRUE(a.UInt0  <= b.UInt0)
							 || IS_TRUE(a.UInt1  <= b.UInt1);

				case  3: return IS_TRUE(a.UInt0  <= b.UInt0)
							 || IS_TRUE(a.UInt1  <= b.UInt1)
							 || IS_TRUE(a.UInt2  <= b.UInt2);

				default: return IS_TRUE(a.UInt0  <= b.UInt0)
							 || IS_TRUE(a.UInt1  <= b.UInt1)
							 || IS_TRUE(a.UInt2  <= b.UInt2)
							 || IS_TRUE(a.UInt3  <= b.UInt3);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_LE_EPU64(v128 a, v128 b)
		{
			return IS_TRUE(a.ULong0 <= b.ULong0)
				|| IS_TRUE(a.ULong1 <= b.ULong1);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_LE_EPI8(v128 a, v128 b, byte elements = 16)
		{
			switch (elements)
			{
				case  2: return IS_TRUE(a.SByte0  <= b.SByte0)
							 || IS_TRUE(a.SByte1  <= b.SByte1);

				case  3: return IS_TRUE(a.SByte0  <= b.SByte0)
							 || IS_TRUE(a.SByte1  <= b.SByte1)
							 || IS_TRUE(a.SByte2  <= b.SByte2);

				case  4: return IS_TRUE(a.SByte0  <= b.SByte0)
							 || IS_TRUE(a.SByte1  <= b.SByte1)
							 || IS_TRUE(a.SByte2  <= b.SByte2)
							 || IS_TRUE(a.SByte3  <= b.SByte3);

				case  8: return IS_TRUE(a.SByte0  <= b.SByte0)
							 || IS_TRUE(a.SByte1  <= b.SByte1)
							 || IS_TRUE(a.SByte2  <= b.SByte2)
							 || IS_TRUE(a.SByte3  <= b.SByte3)
							 || IS_TRUE(a.SByte4  <= b.SByte4)
							 || IS_TRUE(a.SByte5  <= b.SByte5)
							 || IS_TRUE(a.SByte6  <= b.SByte6)
							 || IS_TRUE(a.SByte7  <= b.SByte7);

				default: return IS_TRUE(a.SByte0  <= b.SByte0)
							 || IS_TRUE(a.SByte1  <= b.SByte1)
							 || IS_TRUE(a.SByte2  <= b.SByte2)
							 || IS_TRUE(a.SByte3  <= b.SByte3)
							 || IS_TRUE(a.SByte4  <= b.SByte4)
							 || IS_TRUE(a.SByte5  <= b.SByte5)
							 || IS_TRUE(a.SByte6  <= b.SByte6)
							 || IS_TRUE(a.SByte7  <= b.SByte7)
							 || IS_TRUE(a.SByte8  <= b.SByte8)
							 || IS_TRUE(a.SByte9  <= b.SByte9)
							 || IS_TRUE(a.SByte10 <= b.SByte10)
							 || IS_TRUE(a.SByte11 <= b.SByte11)
							 || IS_TRUE(a.SByte12 <= b.SByte12)
							 || IS_TRUE(a.SByte13 <= b.SByte13)
							 || IS_TRUE(a.SByte14 <= b.SByte14)
							 || IS_TRUE(a.SByte15 <= b.SByte15);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_LE_EPI16(v128 a, v128 b, byte elements = 8)
		{
			switch (elements)
			{
				case  2: return IS_TRUE(a.SShort0 <= b.SShort0)
							 || IS_TRUE(a.SShort1 <= b.SShort1);

				case  3: return IS_TRUE(a.SShort0 <= b.SShort0)
							 || IS_TRUE(a.SShort1 <= b.SShort1)
							 || IS_TRUE(a.SShort2 <= b.SShort2);

				case  4: return IS_TRUE(a.SShort0 <= b.SShort0)
							 || IS_TRUE(a.SShort1 <= b.SShort1)
							 || IS_TRUE(a.SShort2 <= b.SShort2)
							 || IS_TRUE(a.SShort3 <= b.SShort3);

				default: return IS_TRUE(a.SShort0 <= b.SShort0)
							 || IS_TRUE(a.SShort1 <= b.SShort1)
							 || IS_TRUE(a.SShort2 <= b.SShort2)
							 || IS_TRUE(a.SShort3 <= b.SShort3)
							 || IS_TRUE(a.SShort4 <= b.SShort4)
							 || IS_TRUE(a.SShort5 <= b.SShort5)
							 || IS_TRUE(a.SShort6 <= b.SShort6)
							 || IS_TRUE(a.SShort7 <= b.SShort7);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_LE_EPI32(v128 a, v128 b, byte elements = 4)
		{
			switch (elements)
			{
				case  2: return IS_TRUE(a.SInt0 <= b.SInt0)
							 || IS_TRUE(a.SInt1 <= b.SInt1);

				case  3: return IS_TRUE(a.SInt0 <= b.SInt0)
							 || IS_TRUE(a.SInt1 <= b.SInt1)
							 || IS_TRUE(a.SInt2 <= b.SInt2);

				default: return IS_TRUE(a.SInt0 <= b.SInt0)
							 || IS_TRUE(a.SInt1 <= b.SInt1)
							 || IS_TRUE(a.SInt2 <= b.SInt2)
							 || IS_TRUE(a.SInt3 <= b.SInt3);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_LE_EPI64(v128 a, v128 b)
		{
			return IS_TRUE(a.SLong0 <= b.SLong0)
				|| IS_TRUE(a.SLong1 <= b.SLong1);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_LE_PS(v128 a, v128 b, byte elements = 4)
		{
			switch (elements)
			{
				case  1: return IS_TRUE(a.Float0 <= b.Float0);

				case  2: return IS_TRUE(a.Float0 <= b.Float0)
							 || IS_TRUE(a.Float1 <= b.Float1);

				case  3: return IS_TRUE(a.Float0 <= b.Float0)
							 || IS_TRUE(a.Float1 <= b.Float1)
							 || IS_TRUE(a.Float2 <= b.Float2);

				default: return IS_TRUE(a.Float0 <= b.Float0)
							 || IS_TRUE(a.Float1 <= b.Float1)
							 || IS_TRUE(a.Float2 <= b.Float2)
							 || IS_TRUE(a.Float3 <= b.Float3);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_LE_PD(v128 a, v128 b)
		{
			return IS_TRUE(a.Double0 <= b.Double0)
				|| IS_TRUE(a.Double1 <= b.Double1);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_LE_EPI8(v256 a, v256 b)
		{
			return IS_TRUE(a.SByte0  <= b.SByte0)
				|| IS_TRUE(a.SByte1  <= b.SByte1)
				|| IS_TRUE(a.SByte2  <= b.SByte2)
				|| IS_TRUE(a.SByte3  <= b.SByte3)
				|| IS_TRUE(a.SByte4  <= b.SByte4)
				|| IS_TRUE(a.SByte5  <= b.SByte5)
				|| IS_TRUE(a.SByte6  <= b.SByte6)
				|| IS_TRUE(a.SByte7  <= b.SByte7)
				|| IS_TRUE(a.SByte8  <= b.SByte8)
				|| IS_TRUE(a.SByte9  <= b.SByte9)
				|| IS_TRUE(a.SByte10 <= b.SByte10)
				|| IS_TRUE(a.SByte11 <= b.SByte11)
				|| IS_TRUE(a.SByte12 <= b.SByte12)
				|| IS_TRUE(a.SByte13 <= b.SByte13)
				|| IS_TRUE(a.SByte14 <= b.SByte14)
				|| IS_TRUE(a.SByte15 <= b.SByte15)
			    || IS_TRUE(a.SByte16 <= b.SByte16)
				|| IS_TRUE(a.SByte17 <= b.SByte17)
				|| IS_TRUE(a.SByte18 <= b.SByte18)
				|| IS_TRUE(a.SByte19 <= b.SByte19)
				|| IS_TRUE(a.SByte20 <= b.SByte20)
				|| IS_TRUE(a.SByte21 <= b.SByte21)
				|| IS_TRUE(a.SByte22 <= b.SByte22)
				|| IS_TRUE(a.SByte23 <= b.SByte23)
				|| IS_TRUE(a.SByte24 <= b.SByte24)
				|| IS_TRUE(a.SByte25 <= b.SByte25)
				|| IS_TRUE(a.SByte26 <= b.SByte26)
				|| IS_TRUE(a.SByte27 <= b.SByte27)
				|| IS_TRUE(a.SByte28 <= b.SByte28)
				|| IS_TRUE(a.SByte29 <= b.SByte29)
				|| IS_TRUE(a.SByte30 <= b.SByte30)
				|| IS_TRUE(a.SByte31 <= b.SByte31);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_LE_EPI16(v256 a, v256 b)
		{
			return IS_TRUE(a.SShort0  <= b.SShort0)
				|| IS_TRUE(a.SShort1  <= b.SShort1)
				|| IS_TRUE(a.SShort2  <= b.SShort2)
				|| IS_TRUE(a.SShort3  <= b.SShort3)
				|| IS_TRUE(a.SShort4  <= b.SShort4)
				|| IS_TRUE(a.SShort5  <= b.SShort5)
				|| IS_TRUE(a.SShort6  <= b.SShort6)
				|| IS_TRUE(a.SShort7  <= b.SShort7)
				|| IS_TRUE(a.SShort8  <= b.SShort8)
				|| IS_TRUE(a.SShort9  <= b.SShort9)
				|| IS_TRUE(a.SShort10 <= b.SShort10)
				|| IS_TRUE(a.SShort11 <= b.SShort11)
				|| IS_TRUE(a.SShort12 <= b.SShort12)
				|| IS_TRUE(a.SShort13 <= b.SShort13)
				|| IS_TRUE(a.SShort14 <= b.SShort14)
				|| IS_TRUE(a.SShort15 <= b.SShort15);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_LE_EPI32(v256 a, v256 b)
		{
			return IS_TRUE(a.SInt0 <= b.SInt0)
				|| IS_TRUE(a.SInt1 <= b.SInt1)
				|| IS_TRUE(a.SInt2 <= b.SInt2)
				|| IS_TRUE(a.SInt3 <= b.SInt3)
				|| IS_TRUE(a.SInt4 <= b.SInt4)
				|| IS_TRUE(a.SInt5 <= b.SInt5)
				|| IS_TRUE(a.SInt6 <= b.SInt6)
				|| IS_TRUE(a.SInt7 <= b.SInt7);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_LE_EPI64(v256 a, v256 b, byte elements = 4)
		{
			if (elements == 3)
			{
				return IS_TRUE(a.SLong0 <= b.SLong0)
					|| IS_TRUE(a.SLong1 <= b.SLong1)
					|| IS_TRUE(a.SLong2 <= b.SLong2);
			}
			else
			{
				return IS_TRUE(a.SLong0 <= b.SLong0)
					|| IS_TRUE(a.SLong1 <= b.SLong1)
					|| IS_TRUE(a.SLong2 <= b.SLong2)
					|| IS_TRUE(a.SLong3 <= b.SLong3);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_LE_EPU8(v256 a, v256 b)
		{
			return IS_TRUE(a.Byte0  <= b.Byte0)
				|| IS_TRUE(a.Byte1  <= b.Byte1)
				|| IS_TRUE(a.Byte2  <= b.Byte2)
				|| IS_TRUE(a.Byte3  <= b.Byte3)
				|| IS_TRUE(a.Byte4  <= b.Byte4)
				|| IS_TRUE(a.Byte5  <= b.Byte5)
				|| IS_TRUE(a.Byte6  <= b.Byte6)
				|| IS_TRUE(a.Byte7  <= b.Byte7)
				|| IS_TRUE(a.Byte8  <= b.Byte8)
				|| IS_TRUE(a.Byte9  <= b.Byte9)
				|| IS_TRUE(a.Byte10 <= b.Byte10)
				|| IS_TRUE(a.Byte11 <= b.Byte11)
				|| IS_TRUE(a.Byte12 <= b.Byte12)
				|| IS_TRUE(a.Byte13 <= b.Byte13)
				|| IS_TRUE(a.Byte14 <= b.Byte14)
				|| IS_TRUE(a.Byte15 <= b.Byte15)
			    || IS_TRUE(a.Byte16 <= b.Byte16)
				|| IS_TRUE(a.Byte17 <= b.Byte17)
				|| IS_TRUE(a.Byte18 <= b.Byte18)
				|| IS_TRUE(a.Byte19 <= b.Byte19)
				|| IS_TRUE(a.Byte20 <= b.Byte20)
				|| IS_TRUE(a.Byte21 <= b.Byte21)
				|| IS_TRUE(a.Byte22 <= b.Byte22)
				|| IS_TRUE(a.Byte23 <= b.Byte23)
				|| IS_TRUE(a.Byte24 <= b.Byte24)
				|| IS_TRUE(a.Byte25 <= b.Byte25)
				|| IS_TRUE(a.Byte26 <= b.Byte26)
				|| IS_TRUE(a.Byte27 <= b.Byte27)
				|| IS_TRUE(a.Byte28 <= b.Byte28)
				|| IS_TRUE(a.Byte29 <= b.Byte29)
				|| IS_TRUE(a.Byte30 <= b.Byte30)
				|| IS_TRUE(a.Byte31 <= b.Byte31);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_LE_EPU16(v256 a, v256 b)
		{
			return IS_TRUE(a.UShort0  <= b.UShort0)
				|| IS_TRUE(a.UShort1  <= b.UShort1)
				|| IS_TRUE(a.UShort2  <= b.UShort2)
				|| IS_TRUE(a.UShort3  <= b.UShort3)
				|| IS_TRUE(a.UShort4  <= b.UShort4)
				|| IS_TRUE(a.UShort5  <= b.UShort5)
				|| IS_TRUE(a.UShort6  <= b.UShort6)
				|| IS_TRUE(a.UShort7  <= b.UShort7)
				|| IS_TRUE(a.UShort8  <= b.UShort8)
				|| IS_TRUE(a.UShort9  <= b.UShort9)
				|| IS_TRUE(a.UShort10 <= b.UShort10)
				|| IS_TRUE(a.UShort11 <= b.UShort11)
				|| IS_TRUE(a.UShort12 <= b.UShort12)
				|| IS_TRUE(a.UShort13 <= b.UShort13)
				|| IS_TRUE(a.UShort14 <= b.UShort14)
				|| IS_TRUE(a.UShort15 <= b.UShort15);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_LE_EPU32(v256 a, v256 b)
		{
			return IS_TRUE(a.UInt0 <= b.UInt0)
				|| IS_TRUE(a.UInt1 <= b.UInt1)
				|| IS_TRUE(a.UInt2 <= b.UInt2)
				|| IS_TRUE(a.UInt3 <= b.UInt3)
				|| IS_TRUE(a.UInt4 <= b.UInt4)
				|| IS_TRUE(a.UInt5 <= b.UInt5)
				|| IS_TRUE(a.UInt6 <= b.UInt6)
				|| IS_TRUE(a.UInt7 <= b.UInt7);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_LE_EPU64(v256 a, v256 b, byte elements = 4)
		{
			if (elements == 3)
			{
				return IS_TRUE(a.ULong0 <= b.ULong0)
					|| IS_TRUE(a.ULong1 <= b.ULong1)
					|| IS_TRUE(a.ULong2 <= b.ULong2);
			}
			else
			{
				return IS_TRUE(a.ULong0 <= b.ULong0)
					|| IS_TRUE(a.ULong1 <= b.ULong1)
					|| IS_TRUE(a.ULong2 <= b.ULong2)
					|| IS_TRUE(a.ULong3 <= b.ULong3);
			}
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_LE_PS(v256 a, v256 b)
		{
			return IS_TRUE(a.Float0 <= b.Float0)
				|| IS_TRUE(a.Float1 <= b.Float1)
				|| IS_TRUE(a.Float2 <= b.Float2)
				|| IS_TRUE(a.Float3 <= b.Float3)
				|| IS_TRUE(a.Float4 <= b.Float4)
				|| IS_TRUE(a.Float5 <= b.Float5)
				|| IS_TRUE(a.Float6 <= b.Float6)
				|| IS_TRUE(a.Float7 <= b.Float7);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ANY_LE_PD(v256 a, v256 b, byte elements = 4)
		{
			if (elements == 3)
			{
				return IS_TRUE(a.Double0 <= b.Double0)
					|| IS_TRUE(a.Double1 <= b.Double1)
					|| IS_TRUE(a.Double2 <= b.Double2);
			}
			else
			{
				return IS_TRUE(a.Double0 <= b.Double0)
					|| IS_TRUE(a.Double1 <= b.Double1)
					|| IS_TRUE(a.Double2 <= b.Double2)
					|| IS_TRUE(a.Double3 <= b.Double3);
			}
		}
	}
}
