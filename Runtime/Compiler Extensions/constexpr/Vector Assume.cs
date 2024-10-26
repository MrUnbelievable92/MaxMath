using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;

namespace MaxMath.Intrinsics
{
    public static partial class constexpr
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_RANGE_EPU8(v128 v, uint min, uint max, byte elements = 16)
		{
			ASSUME(v.Byte0  >= min && v.Byte0  <= max);
			if (elements == 1) return;
			ASSUME(v.Byte1  >= min && v.Byte1  <= max);
			if (elements == 2) return;
			ASSUME(v.Byte2  >= min && v.Byte2  <= max);
			if (elements == 3) return;
			ASSUME(v.Byte3  >= min && v.Byte3  <= max);
			if (elements == 4) return;
			ASSUME(v.Byte4  >= min && v.Byte4  <= max);
			ASSUME(v.Byte5  >= min && v.Byte5  <= max);
			ASSUME(v.Byte6  >= min && v.Byte6  <= max);
			ASSUME(v.Byte7  >= min && v.Byte7  <= max);
			if (elements == 8) return;
			ASSUME(v.Byte8  >= min && v.Byte8  <= max);
			ASSUME(v.Byte9  >= min && v.Byte9  <= max);
			ASSUME(v.Byte10 >= min && v.Byte10 <= max);
			ASSUME(v.Byte11 >= min && v.Byte11 <= max);
			ASSUME(v.Byte12 >= min && v.Byte12 <= max);
			ASSUME(v.Byte13 >= min && v.Byte13 <= max);
			ASSUME(v.Byte14 >= min && v.Byte14 <= max);
			ASSUME(v.Byte15 >= min && v.Byte15 <= max);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_RANGE_EPU16(v128 v, uint min, uint max, byte elements = 8)
		{
			ASSUME(v.UShort0 >= min && v.UShort0 <= max);
			if (elements == 1) return;
			ASSUME(v.UShort1 >= min && v.UShort1 <= max);
			if (elements == 2) return;
			ASSUME(v.UShort2 >= min && v.UShort2 <= max);
			if (elements == 3) return;
			ASSUME(v.UShort3 >= min && v.UShort3 <= max);
			if (elements == 4) return;
			ASSUME(v.UShort4 >= min && v.UShort4 <= max);
			ASSUME(v.UShort5 >= min && v.UShort5 <= max);
			ASSUME(v.UShort6 >= min && v.UShort6 <= max);
			ASSUME(v.UShort7 >= min && v.UShort7 <= max);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_RANGE_EPU32(v128 v, uint min, uint max, byte elements = 4)
		{
			ASSUME(v.UInt0 >= min && v.UInt0 <= max);
			if (elements == 1) return;
			ASSUME(v.UInt1 >= min && v.UInt1 <= max);
			if (elements == 2) return;
			ASSUME(v.UInt2 >= min && v.UInt2 <= max);
			if (elements == 3) return;
			ASSUME(v.UInt3 >= min && v.UInt3 <= max);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_RANGE_EPU64(v128 v, ulong min, ulong max, byte elements = 2)
		{
			ASSUME(v.ULong0 >= min && v.ULong0 <= max);
			if (elements == 1) return;
			ASSUME(v.ULong1 >= min && v.ULong1 <= max);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_RANGE_EPI8(v128 v, int min, int max, byte elements = 16)
		{
			ASSUME(v.SByte0  >= min && v.SByte0  <= max);
			if (elements == 1) return;
			ASSUME(v.SByte1  >= min && v.SByte1  <= max);
			if (elements == 2) return;
			ASSUME(v.SByte2  >= min && v.SByte2  <= max);
			if (elements == 3) return;
			ASSUME(v.SByte3  >= min && v.SByte3  <= max);
			if (elements == 4) return;
			ASSUME(v.SByte4  >= min && v.SByte4  <= max);
			ASSUME(v.SByte5  >= min && v.SByte5  <= max);
			ASSUME(v.SByte6  >= min && v.SByte6  <= max);
			ASSUME(v.SByte7  >= min && v.SByte7  <= max);
			if (elements == 8) return;
			ASSUME(v.SByte8  >= min && v.SByte8  <= max);
			ASSUME(v.SByte9  >= min && v.SByte9  <= max);
			ASSUME(v.SByte10 >= min && v.SByte10 <= max);
			ASSUME(v.SByte11 >= min && v.SByte11 <= max);
			ASSUME(v.SByte12 >= min && v.SByte12 <= max);
			ASSUME(v.SByte13 >= min && v.SByte13 <= max);
			ASSUME(v.SByte14 >= min && v.SByte14 <= max);
			ASSUME(v.SByte15 >= min && v.SByte15 <= max);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_RANGE_EPI16(v128 v, int min, int max, byte elements = 8)
		{
			ASSUME(v.SShort0 >= min && v.SShort0 <= max);
			if (elements == 1) return;
			ASSUME(v.SShort1 >= min && v.SShort1 <= max);
			if (elements == 2) return;
			ASSUME(v.SShort2 >= min && v.SShort2 <= max);
			if (elements == 3) return;
			ASSUME(v.SShort3 >= min && v.SShort3 <= max);
			if (elements == 4) return;
			ASSUME(v.SShort4 >= min && v.SShort4 <= max);
			ASSUME(v.SShort5 >= min && v.SShort5 <= max);
			ASSUME(v.SShort6 >= min && v.SShort6 <= max);
			ASSUME(v.SShort7 >= min && v.SShort7 <= max);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_RANGE_EPI32(v128 v, int min, int max, byte elements = 4)
		{
			ASSUME(v.SInt0 >= min && v.SInt0 <= max);
			if (elements == 1) return;
			ASSUME(v.SInt1 >= min && v.SInt1 <= max);
			if (elements == 2) return;
			ASSUME(v.SInt2 >= min && v.SInt2 <= max);
			if (elements == 3) return;
			ASSUME(v.SInt3 >= min && v.SInt3 <= max);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_RANGE_EPI64(v128 v, long min, long max, byte elements = 2)
		{
			ASSUME(v.SLong0 >= min && v.SLong0 <= max);
			if (elements == 1) return;
			ASSUME(v.SLong1 >= min && v.SLong1 <= max);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_RANGE_PS(v128 v, float min, float max, byte elements = 4)
		{
			ASSUME(math.isnan(v.Float0) ^ (v.Float0 >= min && v.Float0 <= max));
			if (elements == 1) return;
			ASSUME(math.isnan(v.Float1) ^ (v.Float1 >= min && v.Float1 <= max));
			if (elements == 2) return;
			ASSUME(math.isnan(v.Float2) ^ (v.Float2 >= min && v.Float2 <= max));
			if (elements == 3) return;
			ASSUME(math.isnan(v.Float3) ^ (v.Float3 >= min && v.Float3 <= max));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_RANGE_PD(v128 v, double min, double max, byte elements = 2)
		{
			ASSUME(math.isnan(v.Double0) ^ (v.Double0 >= min && v.Double0 <= max));
			if (elements == 1) return;
			ASSUME(math.isnan(v.Double1) ^ (v.Double1 >= min && v.Double1 <= max));
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_RANGE_EPI8(v256 v, int min, int max, byte elements = 32)
		{
			ASSUME(v.SByte0  >= min && v.SByte0  <= max);
			if (elements == 1) return;
			ASSUME(v.SByte1  >= min && v.SByte1  <= max);
			ASSUME(v.SByte2  >= min && v.SByte2  <= max);
			ASSUME(v.SByte3  >= min && v.SByte3  <= max);
			ASSUME(v.SByte4  >= min && v.SByte4  <= max);
			ASSUME(v.SByte5  >= min && v.SByte5  <= max);
			ASSUME(v.SByte6  >= min && v.SByte6  <= max);
			ASSUME(v.SByte7  >= min && v.SByte7  <= max);
			ASSUME(v.SByte8  >= min && v.SByte8  <= max);
			ASSUME(v.SByte9  >= min && v.SByte9  <= max);
			ASSUME(v.SByte10 >= min && v.SByte10 <= max);
			ASSUME(v.SByte11 >= min && v.SByte11 <= max);
			ASSUME(v.SByte12 >= min && v.SByte12 <= max);
			ASSUME(v.SByte13 >= min && v.SByte13 <= max);
			ASSUME(v.SByte14 >= min && v.SByte14 <= max);
			ASSUME(v.SByte15 >= min && v.SByte15 <= max);
			ASSUME(v.SByte16 >= min && v.SByte16 <= max);
			ASSUME(v.SByte17 >= min && v.SByte17 <= max);
			ASSUME(v.SByte18 >= min && v.SByte18 <= max);
			ASSUME(v.SByte19 >= min && v.SByte19 <= max);
			ASSUME(v.SByte20 >= min && v.SByte20 <= max);
			ASSUME(v.SByte21 >= min && v.SByte21 <= max);
			ASSUME(v.SByte22 >= min && v.SByte22 <= max);
			ASSUME(v.SByte23 >= min && v.SByte23 <= max);
			ASSUME(v.SByte24 >= min && v.SByte24 <= max);
			ASSUME(v.SByte25 >= min && v.SByte25 <= max);
			ASSUME(v.SByte26 >= min && v.SByte26 <= max);
			ASSUME(v.SByte27 >= min && v.SByte27 <= max);
			ASSUME(v.SByte28 >= min && v.SByte28 <= max);
			ASSUME(v.SByte29 >= min && v.SByte29 <= max);
			ASSUME(v.SByte30 >= min && v.SByte30 <= max);
			ASSUME(v.SByte31 >= min && v.SByte31 <= max);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_RANGE_EPI16(v256 v, int min, int max, byte elements = 16)
		{
			ASSUME(v.SShort0  >= min && v.SShort0  <= max);
			if (elements == 1) return;
			ASSUME(v.SShort1  >= min && v.SShort1  <= max);
			ASSUME(v.SShort2  >= min && v.SShort2  <= max);
			ASSUME(v.SShort3  >= min && v.SShort3  <= max);
			ASSUME(v.SShort4  >= min && v.SShort4  <= max);
			ASSUME(v.SShort5  >= min && v.SShort5  <= max);
			ASSUME(v.SShort6  >= min && v.SShort6  <= max);
			ASSUME(v.SShort7  >= min && v.SShort7  <= max);
			ASSUME(v.SShort8  >= min && v.SShort8  <= max);
			ASSUME(v.SShort9  >= min && v.SShort9  <= max);
			ASSUME(v.SShort10 >= min && v.SShort10 <= max);
			ASSUME(v.SShort11 >= min && v.SShort11 <= max);
			ASSUME(v.SShort12 >= min && v.SShort12 <= max);
			ASSUME(v.SShort13 >= min && v.SShort13 <= max);
			ASSUME(v.SShort14 >= min && v.SShort14 <= max);
			ASSUME(v.SShort15 >= min && v.SShort15 <= max);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_RANGE_EPI32(v256 v, int min, int max, byte elements = 8)
		{
			ASSUME(v.SInt0 >= min && v.SInt0 <= max);
			if (elements == 1) return;
			ASSUME(v.SInt1 >= min && v.SInt1 <= max);
			ASSUME(v.SInt2 >= min && v.SInt2 <= max);
			ASSUME(v.SInt3 >= min && v.SInt3 <= max);
			ASSUME(v.SInt4 >= min && v.SInt4 <= max);
			ASSUME(v.SInt5 >= min && v.SInt5 <= max);
			ASSUME(v.SInt6 >= min && v.SInt6 <= max);
			ASSUME(v.SInt7 >= min && v.SInt7 <= max);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_RANGE_EPI64(v256 v, long min, long max, byte elements = 4)
		{
			ASSUME(v.SLong0 >= min && v.SLong0 <= max);
			if (elements == 1) return;
			ASSUME(v.SLong1 >= min && v.SLong1 <= max);
			ASSUME(v.SLong2 >= min && v.SLong2 <= max);
			if (elements == 3) return;
			ASSUME(v.SLong3 >= min && v.SLong3 <= max);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AUSUME_RANGE_EPU8(v256 v, uint min, uint max, byte elements = 32)
		{
			ASSUME(v.Byte0  >= min && v.Byte0  <= max);
			if (elements == 1) return;
			ASSUME(v.Byte1  >= min && v.Byte1  <= max);
			ASSUME(v.Byte2  >= min && v.Byte2  <= max);
			ASSUME(v.Byte3  >= min && v.Byte3  <= max);
			ASSUME(v.Byte4  >= min && v.Byte4  <= max);
			ASSUME(v.Byte5  >= min && v.Byte5  <= max);
			ASSUME(v.Byte6  >= min && v.Byte6  <= max);
			ASSUME(v.Byte7  >= min && v.Byte7  <= max);
			ASSUME(v.Byte8  >= min && v.Byte8  <= max);
			ASSUME(v.Byte9  >= min && v.Byte9  <= max);
			ASSUME(v.Byte10 >= min && v.Byte10 <= max);
			ASSUME(v.Byte11 >= min && v.Byte11 <= max);
			ASSUME(v.Byte12 >= min && v.Byte12 <= max);
			ASSUME(v.Byte13 >= min && v.Byte13 <= max);
			ASSUME(v.Byte14 >= min && v.Byte14 <= max);
			ASSUME(v.Byte15 >= min && v.Byte15 <= max);
			ASSUME(v.Byte16 >= min && v.Byte16 <= max);
			ASSUME(v.Byte17 >= min && v.Byte17 <= max);
			ASSUME(v.Byte18 >= min && v.Byte18 <= max);
			ASSUME(v.Byte19 >= min && v.Byte19 <= max);
			ASSUME(v.Byte20 >= min && v.Byte20 <= max);
			ASSUME(v.Byte21 >= min && v.Byte21 <= max);
			ASSUME(v.Byte22 >= min && v.Byte22 <= max);
			ASSUME(v.Byte23 >= min && v.Byte23 <= max);
			ASSUME(v.Byte24 >= min && v.Byte24 <= max);
			ASSUME(v.Byte25 >= min && v.Byte25 <= max);
			ASSUME(v.Byte26 >= min && v.Byte26 <= max);
			ASSUME(v.Byte27 >= min && v.Byte27 <= max);
			ASSUME(v.Byte28 >= min && v.Byte28 <= max);
			ASSUME(v.Byte29 >= min && v.Byte29 <= max);
			ASSUME(v.Byte30 >= min && v.Byte30 <= max);
			ASSUME(v.Byte31 >= min && v.Byte31 <= max);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AUSUME_RANGE_EPU16(v256 v, uint min, uint max, byte elements = 16)
		{
			ASSUME(v.UShort0  >= min && v.UShort0  <= max);
			if (elements == 1) return;
			ASSUME(v.UShort1  >= min && v.UShort1  <= max);
			ASSUME(v.UShort2  >= min && v.UShort2  <= max);
			ASSUME(v.UShort3  >= min && v.UShort3  <= max);
			ASSUME(v.UShort4  >= min && v.UShort4  <= max);
			ASSUME(v.UShort5  >= min && v.UShort5  <= max);
			ASSUME(v.UShort6  >= min && v.UShort6  <= max);
			ASSUME(v.UShort7  >= min && v.UShort7  <= max);
			ASSUME(v.UShort8  >= min && v.UShort8  <= max);
			ASSUME(v.UShort9  >= min && v.UShort9  <= max);
			ASSUME(v.UShort10 >= min && v.UShort10 <= max);
			ASSUME(v.UShort11 >= min && v.UShort11 <= max);
			ASSUME(v.UShort12 >= min && v.UShort12 <= max);
			ASSUME(v.UShort13 >= min && v.UShort13 <= max);
			ASSUME(v.UShort14 >= min && v.UShort14 <= max);
			ASSUME(v.UShort15 >= min && v.UShort15 <= max);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AUSUME_RANGE_EPU32(v256 v, uint min, uint max, byte elements = 8)
		{
			ASSUME(v.UInt0 >= min && v.UInt0 <= max);
			if (elements == 1) return;
			ASSUME(v.UInt1 >= min && v.UInt1 <= max);
			ASSUME(v.UInt2 >= min && v.UInt2 <= max);
			ASSUME(v.UInt3 >= min && v.UInt3 <= max);
			ASSUME(v.UInt4 >= min && v.UInt4 <= max);
			ASSUME(v.UInt5 >= min && v.UInt5 <= max);
			ASSUME(v.UInt6 >= min && v.UInt6 <= max);
			ASSUME(v.UInt7 >= min && v.UInt7 <= max);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AUSUME_RANGE_EPU64(v256 v, ulong min, ulong max, byte elements = 4)
		{
			ASSUME(v.ULong0 >= min && v.ULong0 <= max);
			if (elements == 1) return;
			ASSUME(v.ULong1 >= min && v.ULong1 <= max);
			ASSUME(v.ULong2 >= min && v.ULong2 <= max);
			if (elements == 3) return;
			ASSUME(v.ULong3 >= min && v.ULong3 <= max);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_RANGE_PS(v256 v, float min, float max, byte elements = 8)
		{
			ASSUME(math.isnan(v.Float0) ^ (v.Float0 >= min && v.Float0 <= max));
			if (elements == 1) return;
			ASSUME(math.isnan(v.Float1) ^ (v.Float1 >= min && v.Float1 <= max));
			ASSUME(math.isnan(v.Float2) ^ (v.Float2 >= min && v.Float2 <= max));
			ASSUME(math.isnan(v.Float3) ^ (v.Float3 >= min && v.Float3 <= max));
			ASSUME(math.isnan(v.Float4) ^ (v.Float4 >= min && v.Float4 <= max));
			ASSUME(math.isnan(v.Float5) ^ (v.Float5 >= min && v.Float5 <= max));
			ASSUME(math.isnan(v.Float6) ^ (v.Float6 >= min && v.Float6 <= max));
			ASSUME(math.isnan(v.Float7) ^ (v.Float7 >= min && v.Float7 <= max));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_RANGE_PD(v256 v, double min, double max, byte elements = 4)
		{
			ASSUME(math.isnan(v.Double0) ^ (v.Double0 >= min && v.Double0 <= max));
			if (elements == 1) return;
			ASSUME(math.isnan(v.Double1) ^ (v.Double1 >= min && v.Double1 <= max));
			ASSUME(math.isnan(v.Double2) ^ (v.Double2 >= min && v.Double2 <= max));
			if (elements == 3) return;
			ASSUME(math.isnan(v.Double3) ^ (v.Double3 >= min && v.Double3 <= max));
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_EQ_EPU8(v128 v, uint cmpVal, byte elements = 16)
		{
			ASSUME(v.Byte0  == cmpVal);
			if (elements == 1) return;
			ASSUME(v.Byte1  == cmpVal);
			if (elements == 2) return;
			ASSUME(v.Byte2  == cmpVal);
			if (elements == 3) return;
			ASSUME(v.Byte3  == cmpVal);
			if (elements == 4) return;
			ASSUME(v.Byte4  == cmpVal);
			ASSUME(v.Byte5  == cmpVal);
			ASSUME(v.Byte6  == cmpVal);
			ASSUME(v.Byte7  == cmpVal);
			if (elements == 8) return;
			ASSUME(v.Byte8  == cmpVal);
			ASSUME(v.Byte9  == cmpVal);
			ASSUME(v.Byte10 == cmpVal);
			ASSUME(v.Byte11 == cmpVal);
			ASSUME(v.Byte12 == cmpVal);
			ASSUME(v.Byte13 == cmpVal);
			ASSUME(v.Byte14 == cmpVal);
			ASSUME(v.Byte15 == cmpVal);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_EQ_EPU16(v128 v, uint cmpVal, byte elements = 8)
		{
			ASSUME(v.UShort0 == cmpVal);
			if (elements == 1) return;
			ASSUME(v.UShort1 == cmpVal);
			if (elements == 2) return;
			ASSUME(v.UShort2 == cmpVal);
			if (elements == 3) return;
			ASSUME(v.UShort3 == cmpVal);
			if (elements == 4) return;
			ASSUME(v.UShort4 == cmpVal);
			ASSUME(v.UShort5 == cmpVal);
			ASSUME(v.UShort6 == cmpVal);
			ASSUME(v.UShort7 == cmpVal);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_EQ_EPU32(v128 v, uint cmpVal, byte elements = 4)
		{
			ASSUME(v.UInt0 == cmpVal);
			if (elements == 1) return;
			ASSUME(v.UInt1 == cmpVal);
			if (elements == 2) return;
			ASSUME(v.UInt2 == cmpVal);
			if (elements == 3) return;
			ASSUME(v.UInt3 == cmpVal);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_EQ_EPU64(v128 v, ulong cmpVal, byte elements = 2)
		{
			ASSUME(v.ULong0 == cmpVal);
			if (elements == 1) return;
			ASSUME(v.ULong1 == cmpVal);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_EQ_EPI8(v128 v, int cmpVal, byte elements = 16)
		{
			ASSUME(v.SByte0  == cmpVal);
			if (elements == 1) return;
			ASSUME(v.SByte1  == cmpVal);
			if (elements == 2) return;
			ASSUME(v.SByte2  == cmpVal);
			if (elements == 3) return;
			ASSUME(v.SByte3  == cmpVal);
			if (elements == 4) return;
			ASSUME(v.SByte4  == cmpVal);
			ASSUME(v.SByte5  == cmpVal);
			ASSUME(v.SByte6  == cmpVal);
			ASSUME(v.SByte7  == cmpVal);
			if (elements == 8) return;
			ASSUME(v.SByte8  == cmpVal);
			ASSUME(v.SByte9  == cmpVal);
			ASSUME(v.SByte10 == cmpVal);
			ASSUME(v.SByte11 == cmpVal);
			ASSUME(v.SByte12 == cmpVal);
			ASSUME(v.SByte13 == cmpVal);
			ASSUME(v.SByte14 == cmpVal);
			ASSUME(v.SByte15 == cmpVal);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_EQ_EPI16(v128 v, int cmpVal, byte elements = 8)
		{
			ASSUME(v.SShort0 == cmpVal);
			if (elements == 1) return;
			ASSUME(v.SShort1 == cmpVal);
			if (elements == 2) return;
			ASSUME(v.SShort2 == cmpVal);
			if (elements == 3) return;
			ASSUME(v.SShort3 == cmpVal);
			if (elements == 4) return;
			ASSUME(v.SShort4 == cmpVal);
			ASSUME(v.SShort5 == cmpVal);
			ASSUME(v.SShort6 == cmpVal);
			ASSUME(v.SShort7 == cmpVal);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_EQ_EPI32(v128 v, int cmpVal, byte elements = 4)
		{
			ASSUME(v.SInt0 == cmpVal);
			if (elements == 1) return;
			ASSUME(v.SInt1 == cmpVal);
			if (elements == 2) return;
			ASSUME(v.SInt2 == cmpVal);
			if (elements == 3) return;
			ASSUME(v.SInt3 == cmpVal);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_EQ_EPI64(v128 v, long cmpVal, byte elements = 2)
		{
			ASSUME(v.SLong0 == cmpVal);
			if (elements == 1) return;
			ASSUME(v.SLong1 == cmpVal);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_EQ_PS(v128 v, float cmpVal, byte elements = 4)
		{
			ASSUME(math.isnan(v.Float0) ^ (v.Float0 == cmpVal));
			if (elements == 1) return;
			ASSUME(math.isnan(v.Float1) ^ (v.Float1 == cmpVal));
			if (elements == 2) return;
			ASSUME(math.isnan(v.Float2) ^ (v.Float2 == cmpVal));
			if (elements == 3) return;
			ASSUME(math.isnan(v.Float3) ^ (v.Float3 == cmpVal));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_EQ_PD(v128 v, double cmpVal, byte elements = 2)
		{
			ASSUME(math.isnan(v.Double0) ^ (v.Double0 == cmpVal));
			if (elements == 1) return;
			ASSUME(math.isnan(v.Double1) ^ (v.Double1 == cmpVal));
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_EQ_EPI8(v256 v, int cmpVal, byte elements = 32)
		{
			ASSUME(v.SByte0  == cmpVal);
			if (elements == 1) return;
			ASSUME(v.SByte1  == cmpVal);
			ASSUME(v.SByte2  == cmpVal);
			ASSUME(v.SByte3  == cmpVal);
			ASSUME(v.SByte4  == cmpVal);
			ASSUME(v.SByte5  == cmpVal);
			ASSUME(v.SByte6  == cmpVal);
			ASSUME(v.SByte7  == cmpVal);
			ASSUME(v.SByte8  == cmpVal);
			ASSUME(v.SByte9  == cmpVal);
			ASSUME(v.SByte10 == cmpVal);
			ASSUME(v.SByte11 == cmpVal);
			ASSUME(v.SByte12 == cmpVal);
			ASSUME(v.SByte13 == cmpVal);
			ASSUME(v.SByte14 == cmpVal);
			ASSUME(v.SByte15 == cmpVal);
			ASSUME(v.SByte16 == cmpVal);
			ASSUME(v.SByte17 == cmpVal);
			ASSUME(v.SByte18 == cmpVal);
			ASSUME(v.SByte19 == cmpVal);
			ASSUME(v.SByte20 == cmpVal);
			ASSUME(v.SByte21 == cmpVal);
			ASSUME(v.SByte22 == cmpVal);
			ASSUME(v.SByte23 == cmpVal);
			ASSUME(v.SByte24 == cmpVal);
			ASSUME(v.SByte25 == cmpVal);
			ASSUME(v.SByte26 == cmpVal);
			ASSUME(v.SByte27 == cmpVal);
			ASSUME(v.SByte28 == cmpVal);
			ASSUME(v.SByte29 == cmpVal);
			ASSUME(v.SByte30 == cmpVal);
			ASSUME(v.SByte31 == cmpVal);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_EQ_EPI16(v256 v, int cmpVal, byte elements = 16)
		{
			ASSUME(v.SShort0  == cmpVal);
			if (elements == 1) return;
			ASSUME(v.SShort1  == cmpVal);
			ASSUME(v.SShort2  == cmpVal);
			ASSUME(v.SShort3  == cmpVal);
			ASSUME(v.SShort4  == cmpVal);
			ASSUME(v.SShort5  == cmpVal);
			ASSUME(v.SShort6  == cmpVal);
			ASSUME(v.SShort7  == cmpVal);
			ASSUME(v.SShort8  == cmpVal);
			ASSUME(v.SShort9  == cmpVal);
			ASSUME(v.SShort10 == cmpVal);
			ASSUME(v.SShort11 == cmpVal);
			ASSUME(v.SShort12 == cmpVal);
			ASSUME(v.SShort13 == cmpVal);
			ASSUME(v.SShort14 == cmpVal);
			ASSUME(v.SShort15 == cmpVal);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_EQ_EPI32(v256 v, int cmpVal, byte elements = 8)
		{
			ASSUME(v.SInt0 == cmpVal);
			if (elements == 1) return;
			ASSUME(v.SInt1 == cmpVal);
			ASSUME(v.SInt2 == cmpVal);
			ASSUME(v.SInt3 == cmpVal);
			ASSUME(v.SInt4 == cmpVal);
			ASSUME(v.SInt5 == cmpVal);
			ASSUME(v.SInt6 == cmpVal);
			ASSUME(v.SInt7 == cmpVal);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_EQ_EPI64(v256 v, long cmpVal, byte elements = 4)
		{
			ASSUME(v.SLong0 == cmpVal);
			if (elements == 1) return;
			ASSUME(v.SLong1 == cmpVal);
			ASSUME(v.SLong2 == cmpVal);
			if (elements == 3) return;
			ASSUME(v.SLong3 == cmpVal);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_EQ_EPU8(v256 v, uint cmpVal, byte elements = 32)
		{
			ASSUME(v.Byte0  == cmpVal);
			if (elements == 1) return;
			ASSUME(v.Byte1  == cmpVal);
			ASSUME(v.Byte2  == cmpVal);
			ASSUME(v.Byte3  == cmpVal);
			ASSUME(v.Byte4  == cmpVal);
			ASSUME(v.Byte5  == cmpVal);
			ASSUME(v.Byte6  == cmpVal);
			ASSUME(v.Byte7  == cmpVal);
			ASSUME(v.Byte8  == cmpVal);
			ASSUME(v.Byte9  == cmpVal);
			ASSUME(v.Byte10 == cmpVal);
			ASSUME(v.Byte11 == cmpVal);
			ASSUME(v.Byte12 == cmpVal);
			ASSUME(v.Byte13 == cmpVal);
			ASSUME(v.Byte14 == cmpVal);
			ASSUME(v.Byte15 == cmpVal);
			ASSUME(v.Byte16 == cmpVal);
			ASSUME(v.Byte17 == cmpVal);
			ASSUME(v.Byte18 == cmpVal);
			ASSUME(v.Byte19 == cmpVal);
			ASSUME(v.Byte20 == cmpVal);
			ASSUME(v.Byte21 == cmpVal);
			ASSUME(v.Byte22 == cmpVal);
			ASSUME(v.Byte23 == cmpVal);
			ASSUME(v.Byte24 == cmpVal);
			ASSUME(v.Byte25 == cmpVal);
			ASSUME(v.Byte26 == cmpVal);
			ASSUME(v.Byte27 == cmpVal);
			ASSUME(v.Byte28 == cmpVal);
			ASSUME(v.Byte29 == cmpVal);
			ASSUME(v.Byte30 == cmpVal);
			ASSUME(v.Byte31 == cmpVal);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_EQ_EPU16(v256 v, uint cmpVal, byte elements = 16)
		{
			ASSUME(v.UShort0  == cmpVal);
			if (elements == 1) return;
			ASSUME(v.UShort1  == cmpVal);
			ASSUME(v.UShort2  == cmpVal);
			ASSUME(v.UShort3  == cmpVal);
			ASSUME(v.UShort4  == cmpVal);
			ASSUME(v.UShort5  == cmpVal);
			ASSUME(v.UShort6  == cmpVal);
			ASSUME(v.UShort7  == cmpVal);
			ASSUME(v.UShort8  == cmpVal);
			ASSUME(v.UShort9  == cmpVal);
			ASSUME(v.UShort10 == cmpVal);
			ASSUME(v.UShort11 == cmpVal);
			ASSUME(v.UShort12 == cmpVal);
			ASSUME(v.UShort13 == cmpVal);
			ASSUME(v.UShort14 == cmpVal);
			ASSUME(v.UShort15 == cmpVal);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_EQ_EPU32(v256 v, uint cmpVal, byte elements = 8)
		{
			ASSUME(v.UInt0 == cmpVal);
			if (elements == 1) return;
			ASSUME(v.UInt1 == cmpVal);
			ASSUME(v.UInt2 == cmpVal);
			ASSUME(v.UInt3 == cmpVal);
			ASSUME(v.UInt4 == cmpVal);
			ASSUME(v.UInt5 == cmpVal);
			ASSUME(v.UInt6 == cmpVal);
			ASSUME(v.UInt7 == cmpVal);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_EQ_EPU64(v256 v, ulong cmpVal, byte elements = 4)
		{
			ASSUME(v.ULong0 == cmpVal);
			if (elements == 1) return;
			ASSUME(v.ULong1 == cmpVal);
			ASSUME(v.ULong2 == cmpVal);
			if (elements == 3) return;
			ASSUME(v.ULong3 == cmpVal);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_EQ_PS(v256 v, float cmpVal, byte elements = 8)
		{
			ASSUME(math.isnan(v.Float0) ^ (v.Float0 == cmpVal));
			if (elements == 1) return;
			ASSUME(math.isnan(v.Float1) ^ (v.Float1 == cmpVal));
			ASSUME(math.isnan(v.Float2) ^ (v.Float2 == cmpVal));
			ASSUME(math.isnan(v.Float3) ^ (v.Float3 == cmpVal));
			ASSUME(math.isnan(v.Float4) ^ (v.Float4 == cmpVal));
			ASSUME(math.isnan(v.Float5) ^ (v.Float5 == cmpVal));
			ASSUME(math.isnan(v.Float6) ^ (v.Float6 == cmpVal));
			ASSUME(math.isnan(v.Float7) ^ (v.Float7 == cmpVal));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_EQ_PD(v256 v, double cmpVal, byte elements = 4)
		{
			ASSUME(math.isnan(v.Double0) ^ (v.Double0 == cmpVal));
			if (elements == 1) return;
			ASSUME(math.isnan(v.Double1) ^ (v.Double1 == cmpVal));
			ASSUME(math.isnan(v.Double2) ^ (v.Double2 == cmpVal));
			if (elements == 3) return;
			ASSUME(math.isnan(v.Double3) ^ (v.Double3 == cmpVal));
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_NEQ_EPU8(v128 v, uint cmpVal, byte elements = 16)
		{
			ASSUME(v.Byte0  != cmpVal);
			if (elements == 1) return;
			ASSUME(v.Byte1  != cmpVal);
			if (elements == 2) return;
			ASSUME(v.Byte2  != cmpVal);
			if (elements == 3) return;
			ASSUME(v.Byte3  != cmpVal);
			if (elements == 4) return;
			ASSUME(v.Byte4  != cmpVal);
			ASSUME(v.Byte5  != cmpVal);
			ASSUME(v.Byte6  != cmpVal);
			ASSUME(v.Byte7  != cmpVal);
			if (elements == 8) return;
			ASSUME(v.Byte8  != cmpVal);
			ASSUME(v.Byte9  != cmpVal);
			ASSUME(v.Byte10 != cmpVal);
			ASSUME(v.Byte11 != cmpVal);
			ASSUME(v.Byte12 != cmpVal);
			ASSUME(v.Byte13 != cmpVal);
			ASSUME(v.Byte14 != cmpVal);
			ASSUME(v.Byte15 != cmpVal);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_NEQ_EPU16(v128 v, uint cmpVal, byte elements = 8)
		{
			ASSUME(v.UShort0 != cmpVal);
			if (elements == 1) return;
			ASSUME(v.UShort1 != cmpVal);
			if (elements == 2) return;
			ASSUME(v.UShort2 != cmpVal);
			if (elements == 3) return;
			ASSUME(v.UShort3 != cmpVal);
			if (elements == 4) return;
			ASSUME(v.UShort4 != cmpVal);
			ASSUME(v.UShort5 != cmpVal);
			ASSUME(v.UShort6 != cmpVal);
			ASSUME(v.UShort7 != cmpVal);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_NEQ_EPU32(v128 v, uint cmpVal, byte elements = 4)
		{
			ASSUME(v.UInt0 != cmpVal);
			if (elements == 1) return;
			ASSUME(v.UInt1 != cmpVal);
			if (elements == 2) return;
			ASSUME(v.UInt2 != cmpVal);
			if (elements == 3) return;
			ASSUME(v.UInt3 != cmpVal);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_NEQ_EPU64(v128 v, ulong cmpVal, byte elements = 2)
		{
			ASSUME(v.ULong0 != cmpVal);
			if (elements == 1) return;
			ASSUME(v.ULong1 != cmpVal);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_NEQ_EPI8(v128 v, int cmpVal, byte elements = 16)
		{
			ASSUME(v.SByte0  != cmpVal);
			if (elements == 1) return;
			ASSUME(v.SByte1  != cmpVal);
			if (elements == 2) return;
			ASSUME(v.SByte2  != cmpVal);
			if (elements == 3) return;
			ASSUME(v.SByte3  != cmpVal);
			if (elements == 4) return;
			ASSUME(v.SByte4  != cmpVal);
			ASSUME(v.SByte5  != cmpVal);
			ASSUME(v.SByte6  != cmpVal);
			ASSUME(v.SByte7  != cmpVal);
			if (elements == 8) return;
			ASSUME(v.SByte8  != cmpVal);
			ASSUME(v.SByte9  != cmpVal);
			ASSUME(v.SByte10 != cmpVal);
			ASSUME(v.SByte11 != cmpVal);
			ASSUME(v.SByte12 != cmpVal);
			ASSUME(v.SByte13 != cmpVal);
			ASSUME(v.SByte14 != cmpVal);
			ASSUME(v.SByte15 != cmpVal);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_NEQ_EPI16(v128 v, int cmpVal, byte elements = 8)
		{
			ASSUME(v.SShort0 != cmpVal);
			if (elements == 1) return;
			ASSUME(v.SShort1 != cmpVal);
			if (elements == 2) return;
			ASSUME(v.SShort2 != cmpVal);
			if (elements == 3) return;
			ASSUME(v.SShort3 != cmpVal);
			if (elements == 4) return;
			ASSUME(v.SShort4 != cmpVal);
			ASSUME(v.SShort5 != cmpVal);
			ASSUME(v.SShort6 != cmpVal);
			ASSUME(v.SShort7 != cmpVal);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_NEQ_EPI32(v128 v, int cmpVal, byte elements = 4)
		{
			ASSUME(v.SInt0 != cmpVal);
			if (elements == 1) return;
			ASSUME(v.SInt1 != cmpVal);
			if (elements == 2) return;
			ASSUME(v.SInt2 != cmpVal);
			if (elements == 3) return;
			ASSUME(v.SInt3 != cmpVal);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_NEQ_EPI64(v128 v, long cmpVal, byte elements = 2)
		{
			ASSUME(v.SLong0 != cmpVal);
			if (elements == 1) return;
			ASSUME(v.SLong1 != cmpVal);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_NEQ_PS(v128 v, float cmpVal, byte elements = 4)
		{
			ASSUME(math.isnan(v.Float0) ^ (v.Float0 != cmpVal));
			if (elements == 1) return;
			ASSUME(math.isnan(v.Float1) ^ (v.Float1 != cmpVal));
			if (elements == 2) return;
			ASSUME(math.isnan(v.Float2) ^ (v.Float2 != cmpVal));
			if (elements == 3) return;
			ASSUME(math.isnan(v.Float3) ^ (v.Float3 != cmpVal));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_NEQ_PD(v128 v, double cmpVal, byte elements = 2)
		{
			ASSUME(math.isnan(v.Double0) ^ (v.Double0 != cmpVal));
			if (elements == 1) return;
			ASSUME(math.isnan(v.Double1) ^ (v.Double1 != cmpVal));
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_NEQ_EPI8(v256 v, int cmpVal, byte elements = 32)
		{
			ASSUME(v.SByte0  != cmpVal);
			if (elements == 1) return;
			ASSUME(v.SByte1  != cmpVal);
			ASSUME(v.SByte2  != cmpVal);
			ASSUME(v.SByte3  != cmpVal);
			ASSUME(v.SByte4  != cmpVal);
			ASSUME(v.SByte5  != cmpVal);
			ASSUME(v.SByte6  != cmpVal);
			ASSUME(v.SByte7  != cmpVal);
			ASSUME(v.SByte8  != cmpVal);
			ASSUME(v.SByte9  != cmpVal);
			ASSUME(v.SByte10 != cmpVal);
			ASSUME(v.SByte11 != cmpVal);
			ASSUME(v.SByte12 != cmpVal);
			ASSUME(v.SByte13 != cmpVal);
			ASSUME(v.SByte14 != cmpVal);
			ASSUME(v.SByte15 != cmpVal);
			ASSUME(v.SByte16 != cmpVal);
			ASSUME(v.SByte17 != cmpVal);
			ASSUME(v.SByte18 != cmpVal);
			ASSUME(v.SByte19 != cmpVal);
			ASSUME(v.SByte20 != cmpVal);
			ASSUME(v.SByte21 != cmpVal);
			ASSUME(v.SByte22 != cmpVal);
			ASSUME(v.SByte23 != cmpVal);
			ASSUME(v.SByte24 != cmpVal);
			ASSUME(v.SByte25 != cmpVal);
			ASSUME(v.SByte26 != cmpVal);
			ASSUME(v.SByte27 != cmpVal);
			ASSUME(v.SByte28 != cmpVal);
			ASSUME(v.SByte29 != cmpVal);
			ASSUME(v.SByte30 != cmpVal);
			ASSUME(v.SByte31 != cmpVal);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_NEQ_EPI16(v256 v, int cmpVal, byte elements = 16)
		{
			ASSUME(v.SShort0  != cmpVal);
			if (elements == 1) return;
			ASSUME(v.SShort1  != cmpVal);
			ASSUME(v.SShort2  != cmpVal);
			ASSUME(v.SShort3  != cmpVal);
			ASSUME(v.SShort4  != cmpVal);
			ASSUME(v.SShort5  != cmpVal);
			ASSUME(v.SShort6  != cmpVal);
			ASSUME(v.SShort7  != cmpVal);
			ASSUME(v.SShort8  != cmpVal);
			ASSUME(v.SShort9  != cmpVal);
			ASSUME(v.SShort10 != cmpVal);
			ASSUME(v.SShort11 != cmpVal);
			ASSUME(v.SShort12 != cmpVal);
			ASSUME(v.SShort13 != cmpVal);
			ASSUME(v.SShort14 != cmpVal);
			ASSUME(v.SShort15 != cmpVal);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_NEQ_EPI32(v256 v, int cmpVal, byte elements = 8)
		{
			ASSUME(v.SInt0 != cmpVal);
			if (elements == 1) return;
			ASSUME(v.SInt1 != cmpVal);
			ASSUME(v.SInt2 != cmpVal);
			ASSUME(v.SInt3 != cmpVal);
			ASSUME(v.SInt4 != cmpVal);
			ASSUME(v.SInt5 != cmpVal);
			ASSUME(v.SInt6 != cmpVal);
			ASSUME(v.SInt7 != cmpVal);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_NEQ_EPI64(v256 v, long cmpVal, byte elements = 4)
		{
			ASSUME(v.SLong0 != cmpVal);
			if (elements == 1) return;
			ASSUME(v.SLong1 != cmpVal);
			ASSUME(v.SLong2 != cmpVal);
			if (elements == 3) return;
			ASSUME(v.SLong3 != cmpVal);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_NEQ_EPU8(v256 v, uint cmpVal, byte elements = 32)
		{
			ASSUME(v.Byte0  != cmpVal);
			if (elements == 1) return;
			ASSUME(v.Byte1  != cmpVal);
			ASSUME(v.Byte2  != cmpVal);
			ASSUME(v.Byte3  != cmpVal);
			ASSUME(v.Byte4  != cmpVal);
			ASSUME(v.Byte5  != cmpVal);
			ASSUME(v.Byte6  != cmpVal);
			ASSUME(v.Byte7  != cmpVal);
			ASSUME(v.Byte8  != cmpVal);
			ASSUME(v.Byte9  != cmpVal);
			ASSUME(v.Byte10 != cmpVal);
			ASSUME(v.Byte11 != cmpVal);
			ASSUME(v.Byte12 != cmpVal);
			ASSUME(v.Byte13 != cmpVal);
			ASSUME(v.Byte14 != cmpVal);
			ASSUME(v.Byte15 != cmpVal);
			ASSUME(v.Byte16 != cmpVal);
			ASSUME(v.Byte17 != cmpVal);
			ASSUME(v.Byte18 != cmpVal);
			ASSUME(v.Byte19 != cmpVal);
			ASSUME(v.Byte20 != cmpVal);
			ASSUME(v.Byte21 != cmpVal);
			ASSUME(v.Byte22 != cmpVal);
			ASSUME(v.Byte23 != cmpVal);
			ASSUME(v.Byte24 != cmpVal);
			ASSUME(v.Byte25 != cmpVal);
			ASSUME(v.Byte26 != cmpVal);
			ASSUME(v.Byte27 != cmpVal);
			ASSUME(v.Byte28 != cmpVal);
			ASSUME(v.Byte29 != cmpVal);
			ASSUME(v.Byte30 != cmpVal);
			ASSUME(v.Byte31 != cmpVal);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_NEQ_EPU16(v256 v, uint cmpVal, byte elements = 16)
		{
			ASSUME(v.UShort0  != cmpVal);
			if (elements == 1) return;
			ASSUME(v.UShort1  != cmpVal);
			ASSUME(v.UShort2  != cmpVal);
			ASSUME(v.UShort3  != cmpVal);
			ASSUME(v.UShort4  != cmpVal);
			ASSUME(v.UShort5  != cmpVal);
			ASSUME(v.UShort6  != cmpVal);
			ASSUME(v.UShort7  != cmpVal);
			ASSUME(v.UShort8  != cmpVal);
			ASSUME(v.UShort9  != cmpVal);
			ASSUME(v.UShort10 != cmpVal);
			ASSUME(v.UShort11 != cmpVal);
			ASSUME(v.UShort12 != cmpVal);
			ASSUME(v.UShort13 != cmpVal);
			ASSUME(v.UShort14 != cmpVal);
			ASSUME(v.UShort15 != cmpVal);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_NEQ_EPU32(v256 v, uint cmpVal, byte elements = 8)
		{
			ASSUME(v.UInt0 != cmpVal);
			if (elements == 1) return;
			ASSUME(v.UInt1 != cmpVal);
			ASSUME(v.UInt2 != cmpVal);
			ASSUME(v.UInt3 != cmpVal);
			ASSUME(v.UInt4 != cmpVal);
			ASSUME(v.UInt5 != cmpVal);
			ASSUME(v.UInt6 != cmpVal);
			ASSUME(v.UInt7 != cmpVal);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_NEQ_EPU64(v256 v, ulong cmpVal, byte elements = 4)
		{
			ASSUME(v.ULong0 != cmpVal);
			if (elements == 1) return;
			ASSUME(v.ULong1 != cmpVal);
			ASSUME(v.ULong2 != cmpVal);
			if (elements == 3) return;
			ASSUME(v.ULong3 != cmpVal);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_NEQ_PS(v256 v, float cmpVal, byte elements = 8)
		{
			ASSUME(math.isnan(v.Float0) ^ (v.Float0 != cmpVal));
			if (elements == 1) return;
			ASSUME(math.isnan(v.Float1) ^ (v.Float1 != cmpVal));
			ASSUME(math.isnan(v.Float2) ^ (v.Float2 != cmpVal));
			ASSUME(math.isnan(v.Float3) ^ (v.Float3 != cmpVal));
			ASSUME(math.isnan(v.Float4) ^ (v.Float4 != cmpVal));
			ASSUME(math.isnan(v.Float5) ^ (v.Float5 != cmpVal));
			ASSUME(math.isnan(v.Float6) ^ (v.Float6 != cmpVal));
			ASSUME(math.isnan(v.Float7) ^ (v.Float7 != cmpVal));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_NEQ_PD(v256 v, double cmpVal, byte elements = 4)
		{
			ASSUME(math.isnan(v.Double0) ^ (v.Double0 != cmpVal));
			if (elements == 1) return;
			ASSUME(math.isnan(v.Double1) ^ (v.Double1 != cmpVal));
			ASSUME(math.isnan(v.Double2) ^ (v.Double2 != cmpVal));
			if (elements == 3) return;
			ASSUME(math.isnan(v.Double3) ^ (v.Double3 != cmpVal));
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GT_EPU8(v128 v, uint cmpVal, byte elements = 16)
		{
			ASSUME(v.Byte0  > cmpVal);
			if (elements == 1) return;
			ASSUME(v.Byte1  > cmpVal);
			if (elements == 2) return;
			ASSUME(v.Byte2  > cmpVal);
			if (elements == 3) return;
			ASSUME(v.Byte3  > cmpVal);
			if (elements == 4) return;
			ASSUME(v.Byte4  > cmpVal);
			ASSUME(v.Byte5  > cmpVal);
			ASSUME(v.Byte6  > cmpVal);
			ASSUME(v.Byte7  > cmpVal);
			if (elements == 8) return;
			ASSUME(v.Byte8  > cmpVal);
			ASSUME(v.Byte9  > cmpVal);
			ASSUME(v.Byte10 > cmpVal);
			ASSUME(v.Byte11 > cmpVal);
			ASSUME(v.Byte12 > cmpVal);
			ASSUME(v.Byte13 > cmpVal);
			ASSUME(v.Byte14 > cmpVal);
			ASSUME(v.Byte15 > cmpVal);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GT_EPU16(v128 v, uint cmpVal, byte elements = 8)
		{
			ASSUME(v.UShort0 > cmpVal);
			if (elements == 1) return;
			ASSUME(v.UShort1 > cmpVal);
			if (elements == 2) return;
			ASSUME(v.UShort2 > cmpVal);
			if (elements == 3) return;
			ASSUME(v.UShort3 > cmpVal);
			if (elements == 4) return;
			ASSUME(v.UShort4 > cmpVal);
			ASSUME(v.UShort5 > cmpVal);
			ASSUME(v.UShort6 > cmpVal);
			ASSUME(v.UShort7 > cmpVal);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GT_EPU32(v128 v, uint cmpVal, byte elements = 4)
		{
			ASSUME(v.UInt0 > cmpVal);
			if (elements == 1) return;
			ASSUME(v.UInt1 > cmpVal);
			if (elements == 2) return;
			ASSUME(v.UInt2 > cmpVal);
			if (elements == 3) return;
			ASSUME(v.UInt3 > cmpVal);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GT_EPU64(v128 v, ulong cmpVal, byte elements = 2)
		{
			ASSUME(v.ULong0 > cmpVal);
			if (elements == 1) return;
			ASSUME(v.ULong1 > cmpVal);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GT_EPI8(v128 v, int cmpVal, byte elements = 16)
		{
			ASSUME(v.SByte0  > cmpVal);
			if (elements == 1) return;
			ASSUME(v.SByte1  > cmpVal);
			if (elements == 2) return;
			ASSUME(v.SByte2  > cmpVal);
			if (elements == 3) return;
			ASSUME(v.SByte3  > cmpVal);
			if (elements == 4) return;
			ASSUME(v.SByte4  > cmpVal);
			ASSUME(v.SByte5  > cmpVal);
			ASSUME(v.SByte6  > cmpVal);
			ASSUME(v.SByte7  > cmpVal);
			if (elements == 8) return;
			ASSUME(v.SByte8  > cmpVal);
			ASSUME(v.SByte9  > cmpVal);
			ASSUME(v.SByte10 > cmpVal);
			ASSUME(v.SByte11 > cmpVal);
			ASSUME(v.SByte12 > cmpVal);
			ASSUME(v.SByte13 > cmpVal);
			ASSUME(v.SByte14 > cmpVal);
			ASSUME(v.SByte15 > cmpVal);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GT_EPI16(v128 v, int cmpVal, byte elements = 8)
		{
			ASSUME(v.SShort0 > cmpVal);
			if (elements == 1) return;
			ASSUME(v.SShort1 > cmpVal);
			if (elements == 2) return;
			ASSUME(v.SShort2 > cmpVal);
			if (elements == 3) return;
			ASSUME(v.SShort3 > cmpVal);
			if (elements == 4) return;
			ASSUME(v.SShort4 > cmpVal);
			ASSUME(v.SShort5 > cmpVal);
			ASSUME(v.SShort6 > cmpVal);
			ASSUME(v.SShort7 > cmpVal);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GT_EPI32(v128 v, int cmpVal, byte elements = 4)
		{
			ASSUME(v.SInt0 > cmpVal);
			if (elements == 1) return;
			ASSUME(v.SInt1 > cmpVal);
			if (elements == 2) return;
			ASSUME(v.SInt2 > cmpVal);
			if (elements == 3) return;
			ASSUME(v.SInt3 > cmpVal);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GT_EPI64(v128 v, long cmpVal, byte elements = 2)
		{
			ASSUME(v.SLong0 > cmpVal);
			if (elements == 1) return;
			ASSUME(v.SLong1 > cmpVal);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GT_PS(v128 v, float cmpVal, byte elements = 4)
		{
			ASSUME(math.isnan(v.Float0) ^ (v.Float0 > cmpVal));
			if (elements == 1) return;
			ASSUME(math.isnan(v.Float1) ^ (v.Float1 > cmpVal));
			if (elements == 2) return;
			ASSUME(math.isnan(v.Float2) ^ (v.Float2 > cmpVal));
			if (elements == 3) return;
			ASSUME(math.isnan(v.Float3) ^ (v.Float3 > cmpVal));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GT_PD(v128 v, double cmpVal, byte elements = 2)
		{
			ASSUME(math.isnan(v.Double0) ^ (v.Double0 > cmpVal));
			if (elements == 1) return;
			ASSUME(math.isnan(v.Double1) ^ (v.Double1 > cmpVal));
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GT_EPI8(v256 v, int cmpVal, byte elements = 32)
		{
			ASSUME(v.SByte0  > cmpVal);
			if (elements == 1) return;
			ASSUME(v.SByte1  > cmpVal);
			ASSUME(v.SByte2  > cmpVal);
			ASSUME(v.SByte3  > cmpVal);
			ASSUME(v.SByte4  > cmpVal);
			ASSUME(v.SByte5  > cmpVal);
			ASSUME(v.SByte6  > cmpVal);
			ASSUME(v.SByte7  > cmpVal);
			ASSUME(v.SByte8  > cmpVal);
			ASSUME(v.SByte9  > cmpVal);
			ASSUME(v.SByte10 > cmpVal);
			ASSUME(v.SByte11 > cmpVal);
			ASSUME(v.SByte12 > cmpVal);
			ASSUME(v.SByte13 > cmpVal);
			ASSUME(v.SByte14 > cmpVal);
			ASSUME(v.SByte15 > cmpVal);
			ASSUME(v.SByte16 > cmpVal);
			ASSUME(v.SByte17 > cmpVal);
			ASSUME(v.SByte18 > cmpVal);
			ASSUME(v.SByte19 > cmpVal);
			ASSUME(v.SByte20 > cmpVal);
			ASSUME(v.SByte21 > cmpVal);
			ASSUME(v.SByte22 > cmpVal);
			ASSUME(v.SByte23 > cmpVal);
			ASSUME(v.SByte24 > cmpVal);
			ASSUME(v.SByte25 > cmpVal);
			ASSUME(v.SByte26 > cmpVal);
			ASSUME(v.SByte27 > cmpVal);
			ASSUME(v.SByte28 > cmpVal);
			ASSUME(v.SByte29 > cmpVal);
			ASSUME(v.SByte30 > cmpVal);
			ASSUME(v.SByte31 > cmpVal);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GT_EPI16(v256 v, int cmpVal, byte elements = 16)
		{
			ASSUME(v.SShort0  > cmpVal);
			if (elements == 1) return;
			ASSUME(v.SShort1  > cmpVal);
			ASSUME(v.SShort2  > cmpVal);
			ASSUME(v.SShort3  > cmpVal);
			ASSUME(v.SShort4  > cmpVal);
			ASSUME(v.SShort5  > cmpVal);
			ASSUME(v.SShort6  > cmpVal);
			ASSUME(v.SShort7  > cmpVal);
			ASSUME(v.SShort8  > cmpVal);
			ASSUME(v.SShort9  > cmpVal);
			ASSUME(v.SShort10 > cmpVal);
			ASSUME(v.SShort11 > cmpVal);
			ASSUME(v.SShort12 > cmpVal);
			ASSUME(v.SShort13 > cmpVal);
			ASSUME(v.SShort14 > cmpVal);
			ASSUME(v.SShort15 > cmpVal);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GT_EPI32(v256 v, int cmpVal, byte elements = 8)
		{
			ASSUME(v.SInt0 > cmpVal);
			if (elements == 1) return;
			ASSUME(v.SInt1 > cmpVal);
			ASSUME(v.SInt2 > cmpVal);
			ASSUME(v.SInt3 > cmpVal);
			ASSUME(v.SInt4 > cmpVal);
			ASSUME(v.SInt5 > cmpVal);
			ASSUME(v.SInt6 > cmpVal);
			ASSUME(v.SInt7 > cmpVal);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GT_EPI64(v256 v, long cmpVal, byte elements = 4)
		{
			ASSUME(v.SLong0 > cmpVal);
			if (elements == 1) return;
			ASSUME(v.SLong1 > cmpVal);
			ASSUME(v.SLong2 > cmpVal);
			if (elements == 3) return;
			ASSUME(v.SLong3 > cmpVal);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GT_EPU8(v256 v, uint cmpVal, byte elements = 32)
		{
			ASSUME(v.Byte0  > cmpVal);
			if (elements == 1) return;
			ASSUME(v.Byte1  > cmpVal);
			ASSUME(v.Byte2  > cmpVal);
			ASSUME(v.Byte3  > cmpVal);
			ASSUME(v.Byte4  > cmpVal);
			ASSUME(v.Byte5  > cmpVal);
			ASSUME(v.Byte6  > cmpVal);
			ASSUME(v.Byte7  > cmpVal);
			ASSUME(v.Byte8  > cmpVal);
			ASSUME(v.Byte9  > cmpVal);
			ASSUME(v.Byte10 > cmpVal);
			ASSUME(v.Byte11 > cmpVal);
			ASSUME(v.Byte12 > cmpVal);
			ASSUME(v.Byte13 > cmpVal);
			ASSUME(v.Byte14 > cmpVal);
			ASSUME(v.Byte15 > cmpVal);
			ASSUME(v.Byte16 > cmpVal);
			ASSUME(v.Byte17 > cmpVal);
			ASSUME(v.Byte18 > cmpVal);
			ASSUME(v.Byte19 > cmpVal);
			ASSUME(v.Byte20 > cmpVal);
			ASSUME(v.Byte21 > cmpVal);
			ASSUME(v.Byte22 > cmpVal);
			ASSUME(v.Byte23 > cmpVal);
			ASSUME(v.Byte24 > cmpVal);
			ASSUME(v.Byte25 > cmpVal);
			ASSUME(v.Byte26 > cmpVal);
			ASSUME(v.Byte27 > cmpVal);
			ASSUME(v.Byte28 > cmpVal);
			ASSUME(v.Byte29 > cmpVal);
			ASSUME(v.Byte30 > cmpVal);
			ASSUME(v.Byte31 > cmpVal);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GT_EPU16(v256 v, uint cmpVal, byte elements = 16)
		{
			ASSUME(v.UShort0  > cmpVal);
			if (elements == 1) return;
			ASSUME(v.UShort1  > cmpVal);
			ASSUME(v.UShort2  > cmpVal);
			ASSUME(v.UShort3  > cmpVal);
			ASSUME(v.UShort4  > cmpVal);
			ASSUME(v.UShort5  > cmpVal);
			ASSUME(v.UShort6  > cmpVal);
			ASSUME(v.UShort7  > cmpVal);
			ASSUME(v.UShort8  > cmpVal);
			ASSUME(v.UShort9  > cmpVal);
			ASSUME(v.UShort10 > cmpVal);
			ASSUME(v.UShort11 > cmpVal);
			ASSUME(v.UShort12 > cmpVal);
			ASSUME(v.UShort13 > cmpVal);
			ASSUME(v.UShort14 > cmpVal);
			ASSUME(v.UShort15 > cmpVal);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GT_EPU32(v256 v, uint cmpVal, byte elements = 8)
		{
			ASSUME(v.UInt0 > cmpVal);
			if (elements == 1) return;
			ASSUME(v.UInt1 > cmpVal);
			ASSUME(v.UInt2 > cmpVal);
			ASSUME(v.UInt3 > cmpVal);
			ASSUME(v.UInt4 > cmpVal);
			ASSUME(v.UInt5 > cmpVal);
			ASSUME(v.UInt6 > cmpVal);
			ASSUME(v.UInt7 > cmpVal);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GT_EPU64(v256 v, ulong cmpVal, byte elements = 4)
		{
			ASSUME(v.ULong0 > cmpVal);
			if (elements == 1) return;
			ASSUME(v.ULong1 > cmpVal);
			ASSUME(v.ULong2 > cmpVal);
			if (elements == 3) return;
			ASSUME(v.ULong3 > cmpVal);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GT_PS(v256 v, float cmpVal, byte elements = 8)
		{
			ASSUME(math.isnan(v.Float0) ^ (v.Float0 > cmpVal));
			if (elements == 1) return;
			ASSUME(math.isnan(v.Float1) ^ (v.Float1 > cmpVal));
			ASSUME(math.isnan(v.Float2) ^ (v.Float2 > cmpVal));
			ASSUME(math.isnan(v.Float3) ^ (v.Float3 > cmpVal));
			ASSUME(math.isnan(v.Float4) ^ (v.Float4 > cmpVal));
			ASSUME(math.isnan(v.Float5) ^ (v.Float5 > cmpVal));
			ASSUME(math.isnan(v.Float6) ^ (v.Float6 > cmpVal));
			ASSUME(math.isnan(v.Float7) ^ (v.Float7 > cmpVal));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GT_PD(v256 v, double cmpVal, byte elements = 4)
		{
			ASSUME(math.isnan(v.Double0) ^ (v.Double0 > cmpVal));
			if (elements == 1) return;
			ASSUME(math.isnan(v.Double1) ^ (v.Double1 > cmpVal));
			ASSUME(math.isnan(v.Double2) ^ (v.Double2 > cmpVal));
			if (elements == 3) return;
			ASSUME(math.isnan(v.Double3) ^ (v.Double3 > cmpVal));
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LT_EPU8(v128 v, uint cmpVal, byte elements = 16)
		{
			ASSUME(v.Byte0  < cmpVal);
			if (elements == 1) return;
			ASSUME(v.Byte1  < cmpVal);
			if (elements == 2) return;
			ASSUME(v.Byte2  < cmpVal);
			if (elements == 3) return;
			ASSUME(v.Byte3  < cmpVal);
			if (elements == 4) return;
			ASSUME(v.Byte4  < cmpVal);
			ASSUME(v.Byte5  < cmpVal);
			ASSUME(v.Byte6  < cmpVal);
			ASSUME(v.Byte7  < cmpVal);
			if (elements == 8) return;
			ASSUME(v.Byte8  < cmpVal);
			ASSUME(v.Byte9  < cmpVal);
			ASSUME(v.Byte10 < cmpVal);
			ASSUME(v.Byte11 < cmpVal);
			ASSUME(v.Byte12 < cmpVal);
			ASSUME(v.Byte13 < cmpVal);
			ASSUME(v.Byte14 < cmpVal);
			ASSUME(v.Byte15 < cmpVal);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LT_EPU16(v128 v, uint cmpVal, byte elements = 8)
		{
			ASSUME(v.UShort0 < cmpVal);
			if (elements == 1) return;
			ASSUME(v.UShort1 < cmpVal);
			if (elements == 2) return;
			ASSUME(v.UShort2 < cmpVal);
			if (elements == 3) return;
			ASSUME(v.UShort3 < cmpVal);
			if (elements == 4) return;
			ASSUME(v.UShort4 < cmpVal);
			ASSUME(v.UShort5 < cmpVal);
			ASSUME(v.UShort6 < cmpVal);
			ASSUME(v.UShort7 < cmpVal);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LT_EPU32(v128 v, uint cmpVal, byte elements = 4)
		{
			ASSUME(v.UInt0 < cmpVal);
			if (elements == 1) return;
			ASSUME(v.UInt1 < cmpVal);
			if (elements == 2) return;
			ASSUME(v.UInt2 < cmpVal);
			if (elements == 3) return;
			ASSUME(v.UInt3 < cmpVal);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LT_EPU64(v128 v, ulong cmpVal, byte elements = 2)
		{
			ASSUME(v.ULong0 < cmpVal);
			if (elements == 1) return;
			ASSUME(v.ULong1 < cmpVal);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LT_EPI8(v128 v, int cmpVal, byte elements = 16)
		{
			ASSUME(v.SByte0  < cmpVal);
			if (elements == 1) return;
			ASSUME(v.SByte1  < cmpVal);
			if (elements == 2) return;
			ASSUME(v.SByte2  < cmpVal);
			if (elements == 3) return;
			ASSUME(v.SByte3  < cmpVal);
			if (elements == 4) return;
			ASSUME(v.SByte4  < cmpVal);
			ASSUME(v.SByte5  < cmpVal);
			ASSUME(v.SByte6  < cmpVal);
			ASSUME(v.SByte7  < cmpVal);
			if (elements == 8) return;
			ASSUME(v.SByte8  < cmpVal);
			ASSUME(v.SByte9  < cmpVal);
			ASSUME(v.SByte10 < cmpVal);
			ASSUME(v.SByte11 < cmpVal);
			ASSUME(v.SByte12 < cmpVal);
			ASSUME(v.SByte13 < cmpVal);
			ASSUME(v.SByte14 < cmpVal);
			ASSUME(v.SByte15 < cmpVal);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LT_EPI16(v128 v, int cmpVal, byte elements = 8)
		{
			ASSUME(v.SShort0 < cmpVal);
			if (elements == 1) return;
			ASSUME(v.SShort1 < cmpVal);
			if (elements == 2) return;
			ASSUME(v.SShort2 < cmpVal);
			if (elements == 3) return;
			ASSUME(v.SShort3 < cmpVal);
			if (elements == 4) return;
			ASSUME(v.SShort4 < cmpVal);
			ASSUME(v.SShort5 < cmpVal);
			ASSUME(v.SShort6 < cmpVal);
			ASSUME(v.SShort7 < cmpVal);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LT_EPI32(v128 v, int cmpVal, byte elements = 4)
		{
			ASSUME(v.SInt0 < cmpVal);
			if (elements == 1) return;
			ASSUME(v.SInt1 < cmpVal);
			if (elements == 2) return;
			ASSUME(v.SInt2 < cmpVal);
			if (elements == 3) return;
			ASSUME(v.SInt3 < cmpVal);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LT_EPI64(v128 v, long cmpVal, byte elements = 2)
		{
			ASSUME(v.SLong0 < cmpVal);
			if (elements == 1) return;
			ASSUME(v.SLong1 < cmpVal);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LT_PS(v128 v, float cmpVal, byte elements = 4)
		{
			ASSUME(math.isnan(v.Float0) ^ (v.Float0 < cmpVal));
			if (elements == 1) return;
			ASSUME(math.isnan(v.Float1) ^ (v.Float1 < cmpVal));
			if (elements == 2) return;
			ASSUME(math.isnan(v.Float2) ^ (v.Float2 < cmpVal));
			if (elements == 3) return;
			ASSUME(math.isnan(v.Float3) ^ (v.Float3 < cmpVal));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LT_PD(v128 v, double cmpVal, byte elements = 2)
		{
			ASSUME(math.isnan(v.Double0) ^ (v.Double0 < cmpVal));
			if (elements == 1) return;
			ASSUME(math.isnan(v.Double1) ^ (v.Double1 < cmpVal));
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LT_EPI8(v256 v, int cmpVal, byte elements = 32)
		{
			ASSUME(v.SByte0  < cmpVal);
			if (elements == 1) return;
			ASSUME(v.SByte1  < cmpVal);
			ASSUME(v.SByte2  < cmpVal);
			ASSUME(v.SByte3  < cmpVal);
			ASSUME(v.SByte4  < cmpVal);
			ASSUME(v.SByte5  < cmpVal);
			ASSUME(v.SByte6  < cmpVal);
			ASSUME(v.SByte7  < cmpVal);
			ASSUME(v.SByte8  < cmpVal);
			ASSUME(v.SByte9  < cmpVal);
			ASSUME(v.SByte10 < cmpVal);
			ASSUME(v.SByte11 < cmpVal);
			ASSUME(v.SByte12 < cmpVal);
			ASSUME(v.SByte13 < cmpVal);
			ASSUME(v.SByte14 < cmpVal);
			ASSUME(v.SByte15 < cmpVal);
			ASSUME(v.SByte16 < cmpVal);
			ASSUME(v.SByte17 < cmpVal);
			ASSUME(v.SByte18 < cmpVal);
			ASSUME(v.SByte19 < cmpVal);
			ASSUME(v.SByte20 < cmpVal);
			ASSUME(v.SByte21 < cmpVal);
			ASSUME(v.SByte22 < cmpVal);
			ASSUME(v.SByte23 < cmpVal);
			ASSUME(v.SByte24 < cmpVal);
			ASSUME(v.SByte25 < cmpVal);
			ASSUME(v.SByte26 < cmpVal);
			ASSUME(v.SByte27 < cmpVal);
			ASSUME(v.SByte28 < cmpVal);
			ASSUME(v.SByte29 < cmpVal);
			ASSUME(v.SByte30 < cmpVal);
			ASSUME(v.SByte31 < cmpVal);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LT_EPI16(v256 v, int cmpVal, byte elements = 16)
		{
			ASSUME(v.SShort0  < cmpVal);
			if (elements == 1) return;
			ASSUME(v.SShort1  < cmpVal);
			ASSUME(v.SShort2  < cmpVal);
			ASSUME(v.SShort3  < cmpVal);
			ASSUME(v.SShort4  < cmpVal);
			ASSUME(v.SShort5  < cmpVal);
			ASSUME(v.SShort6  < cmpVal);
			ASSUME(v.SShort7  < cmpVal);
			ASSUME(v.SShort8  < cmpVal);
			ASSUME(v.SShort9  < cmpVal);
			ASSUME(v.SShort10 < cmpVal);
			ASSUME(v.SShort11 < cmpVal);
			ASSUME(v.SShort12 < cmpVal);
			ASSUME(v.SShort13 < cmpVal);
			ASSUME(v.SShort14 < cmpVal);
			ASSUME(v.SShort15 < cmpVal);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LT_EPI32(v256 v, int cmpVal, byte elements = 8)
		{
			ASSUME(v.SInt0 < cmpVal);
			if (elements == 1) return;
			ASSUME(v.SInt1 < cmpVal);
			ASSUME(v.SInt2 < cmpVal);
			ASSUME(v.SInt3 < cmpVal);
			ASSUME(v.SInt4 < cmpVal);
			ASSUME(v.SInt5 < cmpVal);
			ASSUME(v.SInt6 < cmpVal);
			ASSUME(v.SInt7 < cmpVal);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LT_EPI64(v256 v, long cmpVal, byte elements = 4)
		{
			ASSUME(v.SLong0 < cmpVal);
			if (elements == 1) return;
			ASSUME(v.SLong1 < cmpVal);
			ASSUME(v.SLong2 < cmpVal);
			if (elements == 3) return;
			ASSUME(v.SLong3 < cmpVal);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LT_EPU8(v256 v, uint cmpVal, byte elements = 32)
		{
			ASSUME(v.Byte0  < cmpVal);
			if (elements == 1) return;
			ASSUME(v.Byte1  < cmpVal);
			ASSUME(v.Byte2  < cmpVal);
			ASSUME(v.Byte3  < cmpVal);
			ASSUME(v.Byte4  < cmpVal);
			ASSUME(v.Byte5  < cmpVal);
			ASSUME(v.Byte6  < cmpVal);
			ASSUME(v.Byte7  < cmpVal);
			ASSUME(v.Byte8  < cmpVal);
			ASSUME(v.Byte9  < cmpVal);
			ASSUME(v.Byte10 < cmpVal);
			ASSUME(v.Byte11 < cmpVal);
			ASSUME(v.Byte12 < cmpVal);
			ASSUME(v.Byte13 < cmpVal);
			ASSUME(v.Byte14 < cmpVal);
			ASSUME(v.Byte15 < cmpVal);
			ASSUME(v.Byte16 < cmpVal);
			ASSUME(v.Byte17 < cmpVal);
			ASSUME(v.Byte18 < cmpVal);
			ASSUME(v.Byte19 < cmpVal);
			ASSUME(v.Byte20 < cmpVal);
			ASSUME(v.Byte21 < cmpVal);
			ASSUME(v.Byte22 < cmpVal);
			ASSUME(v.Byte23 < cmpVal);
			ASSUME(v.Byte24 < cmpVal);
			ASSUME(v.Byte25 < cmpVal);
			ASSUME(v.Byte26 < cmpVal);
			ASSUME(v.Byte27 < cmpVal);
			ASSUME(v.Byte28 < cmpVal);
			ASSUME(v.Byte29 < cmpVal);
			ASSUME(v.Byte30 < cmpVal);
			ASSUME(v.Byte31 < cmpVal);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LT_EPU16(v256 v, uint cmpVal, byte elements = 16)
		{
			ASSUME(v.UShort0  < cmpVal);
			if (elements == 1) return;
			ASSUME(v.UShort1  < cmpVal);
			ASSUME(v.UShort2  < cmpVal);
			ASSUME(v.UShort3  < cmpVal);
			ASSUME(v.UShort4  < cmpVal);
			ASSUME(v.UShort5  < cmpVal);
			ASSUME(v.UShort6  < cmpVal);
			ASSUME(v.UShort7  < cmpVal);
			ASSUME(v.UShort8  < cmpVal);
			ASSUME(v.UShort9  < cmpVal);
			ASSUME(v.UShort10 < cmpVal);
			ASSUME(v.UShort11 < cmpVal);
			ASSUME(v.UShort12 < cmpVal);
			ASSUME(v.UShort13 < cmpVal);
			ASSUME(v.UShort14 < cmpVal);
			ASSUME(v.UShort15 < cmpVal);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LT_EPU32(v256 v, uint cmpVal, byte elements = 8)
		{
			ASSUME(v.UInt0 < cmpVal);
			if (elements == 1) return;
			ASSUME(v.UInt1 < cmpVal);
			ASSUME(v.UInt2 < cmpVal);
			ASSUME(v.UInt3 < cmpVal);
			ASSUME(v.UInt4 < cmpVal);
			ASSUME(v.UInt5 < cmpVal);
			ASSUME(v.UInt6 < cmpVal);
			ASSUME(v.UInt7 < cmpVal);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LT_EPU64(v256 v, ulong cmpVal, byte elements = 4)
		{
			ASSUME(v.ULong0 < cmpVal);
			if (elements == 1) return;
			ASSUME(v.ULong1 < cmpVal);
			ASSUME(v.ULong2 < cmpVal);
			if (elements == 3) return;
			ASSUME(v.ULong3 < cmpVal);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LT_PS(v256 v, float cmpVal, byte elements = 8)
		{
			ASSUME(math.isnan(v.Float0) ^ (v.Float0 < cmpVal));
			if (elements == 1) return;
			ASSUME(math.isnan(v.Float1) ^ (v.Float1 < cmpVal));
			ASSUME(math.isnan(v.Float2) ^ (v.Float2 < cmpVal));
			ASSUME(math.isnan(v.Float3) ^ (v.Float3 < cmpVal));
			ASSUME(math.isnan(v.Float4) ^ (v.Float4 < cmpVal));
			ASSUME(math.isnan(v.Float5) ^ (v.Float5 < cmpVal));
			ASSUME(math.isnan(v.Float6) ^ (v.Float6 < cmpVal));
			ASSUME(math.isnan(v.Float7) ^ (v.Float7 < cmpVal));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LT_PD(v256 v, double cmpVal, byte elements = 4)
		{
			ASSUME(math.isnan(v.Double0) ^ (v.Double0 < cmpVal));
			if (elements == 1) return;
			ASSUME(math.isnan(v.Double1) ^ (v.Double1 < cmpVal));
			ASSUME(math.isnan(v.Double2) ^ (v.Double2 < cmpVal));
			if (elements == 3) return;
			ASSUME(math.isnan(v.Double3) ^ (v.Double3 < cmpVal));
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GE_EPU8(v128 v, uint cmpVal, byte elements = 16)
		{
			ASSUME(v.Byte0  >= cmpVal);
			if (elements == 1) return;
			ASSUME(v.Byte1  >= cmpVal);
			if (elements == 2) return;
			ASSUME(v.Byte2  >= cmpVal);
			if (elements == 3) return;
			ASSUME(v.Byte3  >= cmpVal);
			if (elements == 4) return;
			ASSUME(v.Byte4  >= cmpVal);
			ASSUME(v.Byte5  >= cmpVal);
			ASSUME(v.Byte6  >= cmpVal);
			ASSUME(v.Byte7  >= cmpVal);
			if (elements == 8) return;
			ASSUME(v.Byte8  >= cmpVal);
			ASSUME(v.Byte9  >= cmpVal);
			ASSUME(v.Byte10 >= cmpVal);
			ASSUME(v.Byte11 >= cmpVal);
			ASSUME(v.Byte12 >= cmpVal);
			ASSUME(v.Byte13 >= cmpVal);
			ASSUME(v.Byte14 >= cmpVal);
			ASSUME(v.Byte15 >= cmpVal);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GE_EPU16(v128 v, uint cmpVal, byte elements = 8)
		{
			ASSUME(v.UShort0 >= cmpVal);
			if (elements == 1) return;
			ASSUME(v.UShort1 >= cmpVal);
			if (elements == 2) return;
			ASSUME(v.UShort2 >= cmpVal);
			if (elements == 3) return;
			ASSUME(v.UShort3 >= cmpVal);
			if (elements == 4) return;
			ASSUME(v.UShort4 >= cmpVal);
			ASSUME(v.UShort5 >= cmpVal);
			ASSUME(v.UShort6 >= cmpVal);
			ASSUME(v.UShort7 >= cmpVal);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GE_EPU32(v128 v, uint cmpVal, byte elements = 4)
		{
			ASSUME(v.UInt0 >= cmpVal);
			if (elements == 1) return;
			ASSUME(v.UInt1 >= cmpVal);
			if (elements == 2) return;
			ASSUME(v.UInt2 >= cmpVal);
			if (elements == 3) return;
			ASSUME(v.UInt3 >= cmpVal);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GE_EPU64(v128 v, ulong cmpVal, byte elements = 2)
		{
			ASSUME(v.ULong0 >= cmpVal);
			if (elements == 1) return;
			ASSUME(v.ULong1 >= cmpVal);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GE_EPI8(v128 v, int cmpVal, byte elements = 16)
		{
			ASSUME(v.SByte0  >= cmpVal);
			if (elements == 1) return;
			ASSUME(v.SByte1  >= cmpVal);
			if (elements == 2) return;
			ASSUME(v.SByte2  >= cmpVal);
			if (elements == 3) return;
			ASSUME(v.SByte3  >= cmpVal);
			if (elements == 4) return;
			ASSUME(v.SByte4  >= cmpVal);
			ASSUME(v.SByte5  >= cmpVal);
			ASSUME(v.SByte6  >= cmpVal);
			ASSUME(v.SByte7  >= cmpVal);
			if (elements == 8) return;
			ASSUME(v.SByte8  >= cmpVal);
			ASSUME(v.SByte9  >= cmpVal);
			ASSUME(v.SByte10 >= cmpVal);
			ASSUME(v.SByte11 >= cmpVal);
			ASSUME(v.SByte12 >= cmpVal);
			ASSUME(v.SByte13 >= cmpVal);
			ASSUME(v.SByte14 >= cmpVal);
			ASSUME(v.SByte15 >= cmpVal);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GE_EPI16(v128 v, int cmpVal, byte elements = 8)
		{
			ASSUME(v.SShort0 >= cmpVal);
			if (elements == 1) return;
			ASSUME(v.SShort1 >= cmpVal);
			if (elements == 2) return;
			ASSUME(v.SShort2 >= cmpVal);
			if (elements == 3) return;
			ASSUME(v.SShort3 >= cmpVal);
			if (elements == 4) return;
			ASSUME(v.SShort4 >= cmpVal);
			ASSUME(v.SShort5 >= cmpVal);
			ASSUME(v.SShort6 >= cmpVal);
			ASSUME(v.SShort7 >= cmpVal);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GE_EPI32(v128 v, int cmpVal, byte elements = 4)
		{
			ASSUME(v.SInt0 >= cmpVal);
			if (elements == 1) return;
			ASSUME(v.SInt1 >= cmpVal);
			if (elements == 2) return;
			ASSUME(v.SInt2 >= cmpVal);
			if (elements == 3) return;
			ASSUME(v.SInt3 >= cmpVal);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GE_EPI64(v128 v, long cmpVal, byte elements = 2)
		{
			ASSUME(v.SLong0 >= cmpVal);
			if (elements == 1) return;
			ASSUME(v.SLong1 >= cmpVal);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GE_PS(v128 v, float cmpVal, byte elements = 4)
		{
			ASSUME(math.isnan(v.Float0) ^ (v.Float0 >= cmpVal));
			if (elements == 1) return;
			ASSUME(math.isnan(v.Float1) ^ (v.Float1 >= cmpVal));
			if (elements == 2) return;
			ASSUME(math.isnan(v.Float2) ^ (v.Float2 >= cmpVal));
			if (elements == 3) return;
			ASSUME(math.isnan(v.Float3) ^ (v.Float3 >= cmpVal));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GE_PD(v128 v, double cmpVal, byte elements = 2)
		{
			ASSUME(math.isnan(v.Double0) ^ (v.Double0 >= cmpVal));
			if (elements == 1) return;
			ASSUME(math.isnan(v.Double1) ^ (v.Double1 >= cmpVal));
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GE_EPI8(v256 v, int cmpVal, byte elements = 32)
		{
			ASSUME(v.SByte0  >= cmpVal);
			if (elements == 1) return;
			ASSUME(v.SByte1  >= cmpVal);
			ASSUME(v.SByte2  >= cmpVal);
			ASSUME(v.SByte3  >= cmpVal);
			ASSUME(v.SByte4  >= cmpVal);
			ASSUME(v.SByte5  >= cmpVal);
			ASSUME(v.SByte6  >= cmpVal);
			ASSUME(v.SByte7  >= cmpVal);
			ASSUME(v.SByte8  >= cmpVal);
			ASSUME(v.SByte9  >= cmpVal);
			ASSUME(v.SByte10 >= cmpVal);
			ASSUME(v.SByte11 >= cmpVal);
			ASSUME(v.SByte12 >= cmpVal);
			ASSUME(v.SByte13 >= cmpVal);
			ASSUME(v.SByte14 >= cmpVal);
			ASSUME(v.SByte15 >= cmpVal);
			ASSUME(v.SByte16 >= cmpVal);
			ASSUME(v.SByte17 >= cmpVal);
			ASSUME(v.SByte18 >= cmpVal);
			ASSUME(v.SByte19 >= cmpVal);
			ASSUME(v.SByte20 >= cmpVal);
			ASSUME(v.SByte21 >= cmpVal);
			ASSUME(v.SByte22 >= cmpVal);
			ASSUME(v.SByte23 >= cmpVal);
			ASSUME(v.SByte24 >= cmpVal);
			ASSUME(v.SByte25 >= cmpVal);
			ASSUME(v.SByte26 >= cmpVal);
			ASSUME(v.SByte27 >= cmpVal);
			ASSUME(v.SByte28 >= cmpVal);
			ASSUME(v.SByte29 >= cmpVal);
			ASSUME(v.SByte30 >= cmpVal);
			ASSUME(v.SByte31 >= cmpVal);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GE_EPI16(v256 v, int cmpVal, byte elements = 16)
		{
			ASSUME(v.SShort0  >= cmpVal);
			if (elements == 1) return;
			ASSUME(v.SShort1  >= cmpVal);
			ASSUME(v.SShort2  >= cmpVal);
			ASSUME(v.SShort3  >= cmpVal);
			ASSUME(v.SShort4  >= cmpVal);
			ASSUME(v.SShort5  >= cmpVal);
			ASSUME(v.SShort6  >= cmpVal);
			ASSUME(v.SShort7  >= cmpVal);
			ASSUME(v.SShort8  >= cmpVal);
			ASSUME(v.SShort9  >= cmpVal);
			ASSUME(v.SShort10 >= cmpVal);
			ASSUME(v.SShort11 >= cmpVal);
			ASSUME(v.SShort12 >= cmpVal);
			ASSUME(v.SShort13 >= cmpVal);
			ASSUME(v.SShort14 >= cmpVal);
			ASSUME(v.SShort15 >= cmpVal);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GE_EPI32(v256 v, int cmpVal, byte elements = 8)
		{
			ASSUME(v.SInt0 >= cmpVal);
			if (elements == 1) return;
			ASSUME(v.SInt1 >= cmpVal);
			ASSUME(v.SInt2 >= cmpVal);
			ASSUME(v.SInt3 >= cmpVal);
			ASSUME(v.SInt4 >= cmpVal);
			ASSUME(v.SInt5 >= cmpVal);
			ASSUME(v.SInt6 >= cmpVal);
			ASSUME(v.SInt7 >= cmpVal);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GE_EPI64(v256 v, long cmpVal, byte elements = 4)
		{
			ASSUME(v.SLong0 >= cmpVal);
			if (elements == 1) return;
			ASSUME(v.SLong1 >= cmpVal);
			ASSUME(v.SLong2 >= cmpVal);
			if (elements == 3) return;
			ASSUME(v.SLong3 >= cmpVal);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GE_EPU8(v256 v, uint cmpVal, byte elements = 32)
		{
			ASSUME(v.Byte0  >= cmpVal);
			if (elements == 1) return;
			ASSUME(v.Byte1  >= cmpVal);
			ASSUME(v.Byte2  >= cmpVal);
			ASSUME(v.Byte3  >= cmpVal);
			ASSUME(v.Byte4  >= cmpVal);
			ASSUME(v.Byte5  >= cmpVal);
			ASSUME(v.Byte6  >= cmpVal);
			ASSUME(v.Byte7  >= cmpVal);
			ASSUME(v.Byte8  >= cmpVal);
			ASSUME(v.Byte9  >= cmpVal);
			ASSUME(v.Byte10 >= cmpVal);
			ASSUME(v.Byte11 >= cmpVal);
			ASSUME(v.Byte12 >= cmpVal);
			ASSUME(v.Byte13 >= cmpVal);
			ASSUME(v.Byte14 >= cmpVal);
			ASSUME(v.Byte15 >= cmpVal);
			ASSUME(v.Byte16 >= cmpVal);
			ASSUME(v.Byte17 >= cmpVal);
			ASSUME(v.Byte18 >= cmpVal);
			ASSUME(v.Byte19 >= cmpVal);
			ASSUME(v.Byte20 >= cmpVal);
			ASSUME(v.Byte21 >= cmpVal);
			ASSUME(v.Byte22 >= cmpVal);
			ASSUME(v.Byte23 >= cmpVal);
			ASSUME(v.Byte24 >= cmpVal);
			ASSUME(v.Byte25 >= cmpVal);
			ASSUME(v.Byte26 >= cmpVal);
			ASSUME(v.Byte27 >= cmpVal);
			ASSUME(v.Byte28 >= cmpVal);
			ASSUME(v.Byte29 >= cmpVal);
			ASSUME(v.Byte30 >= cmpVal);
			ASSUME(v.Byte31 >= cmpVal);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GE_EPU16(v256 v, uint cmpVal, byte elements = 16)
		{
			ASSUME(v.UShort0  >= cmpVal);
			if (elements == 1) return;
			ASSUME(v.UShort1  >= cmpVal);
			ASSUME(v.UShort2  >= cmpVal);
			ASSUME(v.UShort3  >= cmpVal);
			ASSUME(v.UShort4  >= cmpVal);
			ASSUME(v.UShort5  >= cmpVal);
			ASSUME(v.UShort6  >= cmpVal);
			ASSUME(v.UShort7  >= cmpVal);
			ASSUME(v.UShort8  >= cmpVal);
			ASSUME(v.UShort9  >= cmpVal);
			ASSUME(v.UShort10 >= cmpVal);
			ASSUME(v.UShort11 >= cmpVal);
			ASSUME(v.UShort12 >= cmpVal);
			ASSUME(v.UShort13 >= cmpVal);
			ASSUME(v.UShort14 >= cmpVal);
			ASSUME(v.UShort15 >= cmpVal);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GE_EPU32(v256 v, uint cmpVal, byte elements = 8)
		{
			ASSUME(v.UInt0 >= cmpVal);
			if (elements == 1) return;
			ASSUME(v.UInt1 >= cmpVal);
			ASSUME(v.UInt2 >= cmpVal);
			ASSUME(v.UInt3 >= cmpVal);
			ASSUME(v.UInt4 >= cmpVal);
			ASSUME(v.UInt5 >= cmpVal);
			ASSUME(v.UInt6 >= cmpVal);
			ASSUME(v.UInt7 >= cmpVal);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GE_EPU64(v256 v, ulong cmpVal, byte elements = 4)
		{
			ASSUME(v.ULong0 >= cmpVal);
			if (elements == 1) return;
			ASSUME(v.ULong1 >= cmpVal);
			ASSUME(v.ULong2 >= cmpVal);
			if (elements == 3) return;
			ASSUME(v.ULong3 >= cmpVal);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GE_PS(v256 v, float cmpVal, byte elements = 8)
		{
			ASSUME(math.isnan(v.Float0) ^ (v.Float0 >= cmpVal));
			if (elements == 1) return;
			ASSUME(math.isnan(v.Float1) ^ (v.Float1 >= cmpVal));
			ASSUME(math.isnan(v.Float2) ^ (v.Float2 >= cmpVal));
			ASSUME(math.isnan(v.Float3) ^ (v.Float3 >= cmpVal));
			ASSUME(math.isnan(v.Float4) ^ (v.Float4 >= cmpVal));
			ASSUME(math.isnan(v.Float5) ^ (v.Float5 >= cmpVal));
			ASSUME(math.isnan(v.Float6) ^ (v.Float6 >= cmpVal));
			ASSUME(math.isnan(v.Float7) ^ (v.Float7 >= cmpVal));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GE_PD(v256 v, double cmpVal, byte elements = 4)
		{
			ASSUME(math.isnan(v.Double0) ^ (v.Double0 >= cmpVal));
			if (elements == 1) return;
			ASSUME(math.isnan(v.Double1) ^ (v.Double1 >= cmpVal));
			ASSUME(math.isnan(v.Double2) ^ (v.Double2 >= cmpVal));
			if (elements == 3) return;
			ASSUME(math.isnan(v.Double3) ^ (v.Double3 >= cmpVal));
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LE_EPU8(v128 v, uint cmpVal, byte elements = 16)
		{
			ASSUME(v.Byte0  <= cmpVal);
			if (elements == 1) return;
			ASSUME(v.Byte1  <= cmpVal);
			if (elements == 2) return;
			ASSUME(v.Byte2  <= cmpVal);
			if (elements == 3) return;
			ASSUME(v.Byte3  <= cmpVal);
			if (elements == 4) return;
			ASSUME(v.Byte4  <= cmpVal);
			ASSUME(v.Byte5  <= cmpVal);
			ASSUME(v.Byte6  <= cmpVal);
			ASSUME(v.Byte7  <= cmpVal);
			if (elements == 8) return;
			ASSUME(v.Byte8  <= cmpVal);
			ASSUME(v.Byte9  <= cmpVal);
			ASSUME(v.Byte10 <= cmpVal);
			ASSUME(v.Byte11 <= cmpVal);
			ASSUME(v.Byte12 <= cmpVal);
			ASSUME(v.Byte13 <= cmpVal);
			ASSUME(v.Byte14 <= cmpVal);
			ASSUME(v.Byte15 <= cmpVal);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LE_EPU16(v128 v, uint cmpVal, byte elements = 8)
		{
			ASSUME(v.UShort0 <= cmpVal);
			if (elements == 1) return;
			ASSUME(v.UShort1 <= cmpVal);
			if (elements == 2) return;
			ASSUME(v.UShort2 <= cmpVal);
			if (elements == 3) return;
			ASSUME(v.UShort3 <= cmpVal);
			if (elements == 4) return;
			ASSUME(v.UShort4 <= cmpVal);
			ASSUME(v.UShort5 <= cmpVal);
			ASSUME(v.UShort6 <= cmpVal);
			ASSUME(v.UShort7 <= cmpVal);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LE_EPU32(v128 v, uint cmpVal, byte elements = 4)
		{
			ASSUME(v.UInt0 <= cmpVal);
			if (elements == 1) return;
			ASSUME(v.UInt1 <= cmpVal);
			if (elements == 2) return;
			ASSUME(v.UInt2 <= cmpVal);
			if (elements == 3) return;
			ASSUME(v.UInt3 <= cmpVal);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LE_EPU64(v128 v, ulong cmpVal, byte elements = 2)
		{
			ASSUME(v.ULong0 <= cmpVal);
			if (elements == 1) return;
			ASSUME(v.ULong1 <= cmpVal);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LE_EPI8(v128 v, int cmpVal, byte elements = 16)
		{
			ASSUME(v.SByte0  <= cmpVal);
			if (elements == 1) return;
			ASSUME(v.SByte1  <= cmpVal);
			if (elements == 2) return;
			ASSUME(v.SByte2  <= cmpVal);
			if (elements == 3) return;
			ASSUME(v.SByte3  <= cmpVal);
			if (elements == 4) return;
			ASSUME(v.SByte4  <= cmpVal);
			ASSUME(v.SByte5  <= cmpVal);
			ASSUME(v.SByte6  <= cmpVal);
			ASSUME(v.SByte7  <= cmpVal);
			if (elements == 8) return;
			ASSUME(v.SByte8  <= cmpVal);
			ASSUME(v.SByte9  <= cmpVal);
			ASSUME(v.SByte10 <= cmpVal);
			ASSUME(v.SByte11 <= cmpVal);
			ASSUME(v.SByte12 <= cmpVal);
			ASSUME(v.SByte13 <= cmpVal);
			ASSUME(v.SByte14 <= cmpVal);
			ASSUME(v.SByte15 <= cmpVal);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LE_EPI16(v128 v, int cmpVal, byte elements = 8)
		{
			ASSUME(v.SShort0 <= cmpVal);
			if (elements == 1) return;
			ASSUME(v.SShort1 <= cmpVal);
			if (elements == 2) return;
			ASSUME(v.SShort2 <= cmpVal);
			if (elements == 3) return;
			ASSUME(v.SShort3 <= cmpVal);
			if (elements == 4) return;
			ASSUME(v.SShort4 <= cmpVal);
			ASSUME(v.SShort5 <= cmpVal);
			ASSUME(v.SShort6 <= cmpVal);
			ASSUME(v.SShort7 <= cmpVal);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LE_EPI32(v128 v, int cmpVal, byte elements = 4)
		{
			ASSUME(v.SInt0 <= cmpVal);
			if (elements == 1) return;
			ASSUME(v.SInt1 <= cmpVal);
			if (elements == 2) return;
			ASSUME(v.SInt2 <= cmpVal);
			if (elements == 3) return;
			ASSUME(v.SInt3 <= cmpVal);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LE_EPI64(v128 v, long cmpVal, byte elements = 2)
		{
			ASSUME(v.SLong0 <= cmpVal);
			if (elements == 1) return;
			ASSUME(v.SLong1 <= cmpVal);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LE_PS(v128 v, float cmpVal, byte elements = 4)
		{
			ASSUME(math.isnan(v.Float0) ^ (v.Float0 <= cmpVal));
			if (elements == 1) return;
			ASSUME(math.isnan(v.Float1) ^ (v.Float1 <= cmpVal));
			if (elements == 2) return;
			ASSUME(math.isnan(v.Float2) ^ (v.Float2 <= cmpVal));
			if (elements == 3) return;
			ASSUME(math.isnan(v.Float3) ^ (v.Float3 <= cmpVal));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LE_PD(v128 v, double cmpVal, byte elements = 2)
		{
			ASSUME(math.isnan(v.Double0) ^ (v.Double0 <= cmpVal));
			if (elements == 1) return;
			ASSUME(math.isnan(v.Double1) ^ (v.Double1 <= cmpVal));
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LE_EPI8(v256 v, int cmpVal, byte elements = 32)
		{
			ASSUME(v.SByte0  <= cmpVal);
			if (elements == 1) return;
			ASSUME(v.SByte1  <= cmpVal);
			ASSUME(v.SByte2  <= cmpVal);
			ASSUME(v.SByte3  <= cmpVal);
			ASSUME(v.SByte4  <= cmpVal);
			ASSUME(v.SByte5  <= cmpVal);
			ASSUME(v.SByte6  <= cmpVal);
			ASSUME(v.SByte7  <= cmpVal);
			ASSUME(v.SByte8  <= cmpVal);
			ASSUME(v.SByte9  <= cmpVal);
			ASSUME(v.SByte10 <= cmpVal);
			ASSUME(v.SByte11 <= cmpVal);
			ASSUME(v.SByte12 <= cmpVal);
			ASSUME(v.SByte13 <= cmpVal);
			ASSUME(v.SByte14 <= cmpVal);
			ASSUME(v.SByte15 <= cmpVal);
			ASSUME(v.SByte16 <= cmpVal);
			ASSUME(v.SByte17 <= cmpVal);
			ASSUME(v.SByte18 <= cmpVal);
			ASSUME(v.SByte19 <= cmpVal);
			ASSUME(v.SByte20 <= cmpVal);
			ASSUME(v.SByte21 <= cmpVal);
			ASSUME(v.SByte22 <= cmpVal);
			ASSUME(v.SByte23 <= cmpVal);
			ASSUME(v.SByte24 <= cmpVal);
			ASSUME(v.SByte25 <= cmpVal);
			ASSUME(v.SByte26 <= cmpVal);
			ASSUME(v.SByte27 <= cmpVal);
			ASSUME(v.SByte28 <= cmpVal);
			ASSUME(v.SByte29 <= cmpVal);
			ASSUME(v.SByte30 <= cmpVal);
			ASSUME(v.SByte31 <= cmpVal);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LE_EPI16(v256 v, int cmpVal, byte elements = 16)
		{
			ASSUME(v.SShort0  <= cmpVal);
			if (elements == 1) return;
			ASSUME(v.SShort1  <= cmpVal);
			ASSUME(v.SShort2  <= cmpVal);
			ASSUME(v.SShort3  <= cmpVal);
			ASSUME(v.SShort4  <= cmpVal);
			ASSUME(v.SShort5  <= cmpVal);
			ASSUME(v.SShort6  <= cmpVal);
			ASSUME(v.SShort7  <= cmpVal);
			ASSUME(v.SShort8  <= cmpVal);
			ASSUME(v.SShort9  <= cmpVal);
			ASSUME(v.SShort10 <= cmpVal);
			ASSUME(v.SShort11 <= cmpVal);
			ASSUME(v.SShort12 <= cmpVal);
			ASSUME(v.SShort13 <= cmpVal);
			ASSUME(v.SShort14 <= cmpVal);
			ASSUME(v.SShort15 <= cmpVal);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LE_EPI32(v256 v, int cmpVal, byte elements = 8)
		{
			ASSUME(v.SInt0 <= cmpVal);
			if (elements == 1) return;
			ASSUME(v.SInt1 <= cmpVal);
			ASSUME(v.SInt2 <= cmpVal);
			ASSUME(v.SInt3 <= cmpVal);
			ASSUME(v.SInt4 <= cmpVal);
			ASSUME(v.SInt5 <= cmpVal);
			ASSUME(v.SInt6 <= cmpVal);
			ASSUME(v.SInt7 <= cmpVal);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LE_EPI64(v256 v, long cmpVal, byte elements = 4)
		{
			ASSUME(v.SLong0 <= cmpVal);
			if (elements == 1) return;
			ASSUME(v.SLong1 <= cmpVal);
			ASSUME(v.SLong2 <= cmpVal);
			if (elements == 3) return;
			ASSUME(v.SLong3 <= cmpVal);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LE_EPU8(v256 v, uint cmpVal, byte elements = 32)
		{
			ASSUME(v.Byte0  <= cmpVal);
			if (elements == 1) return;
			ASSUME(v.Byte1  <= cmpVal);
			ASSUME(v.Byte2  <= cmpVal);
			ASSUME(v.Byte3  <= cmpVal);
			ASSUME(v.Byte4  <= cmpVal);
			ASSUME(v.Byte5  <= cmpVal);
			ASSUME(v.Byte6  <= cmpVal);
			ASSUME(v.Byte7  <= cmpVal);
			ASSUME(v.Byte8  <= cmpVal);
			ASSUME(v.Byte9  <= cmpVal);
			ASSUME(v.Byte10 <= cmpVal);
			ASSUME(v.Byte11 <= cmpVal);
			ASSUME(v.Byte12 <= cmpVal);
			ASSUME(v.Byte13 <= cmpVal);
			ASSUME(v.Byte14 <= cmpVal);
			ASSUME(v.Byte15 <= cmpVal);
			ASSUME(v.Byte16 <= cmpVal);
			ASSUME(v.Byte17 <= cmpVal);
			ASSUME(v.Byte18 <= cmpVal);
			ASSUME(v.Byte19 <= cmpVal);
			ASSUME(v.Byte20 <= cmpVal);
			ASSUME(v.Byte21 <= cmpVal);
			ASSUME(v.Byte22 <= cmpVal);
			ASSUME(v.Byte23 <= cmpVal);
			ASSUME(v.Byte24 <= cmpVal);
			ASSUME(v.Byte25 <= cmpVal);
			ASSUME(v.Byte26 <= cmpVal);
			ASSUME(v.Byte27 <= cmpVal);
			ASSUME(v.Byte28 <= cmpVal);
			ASSUME(v.Byte29 <= cmpVal);
			ASSUME(v.Byte30 <= cmpVal);
			ASSUME(v.Byte31 <= cmpVal);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LE_EPU16(v256 v, uint cmpVal, byte elements = 16)
		{
			ASSUME(v.UShort0  <= cmpVal);
			if (elements == 1) return;
			ASSUME(v.UShort1  <= cmpVal);
			ASSUME(v.UShort2  <= cmpVal);
			ASSUME(v.UShort3  <= cmpVal);
			ASSUME(v.UShort4  <= cmpVal);
			ASSUME(v.UShort5  <= cmpVal);
			ASSUME(v.UShort6  <= cmpVal);
			ASSUME(v.UShort7  <= cmpVal);
			ASSUME(v.UShort8  <= cmpVal);
			ASSUME(v.UShort9  <= cmpVal);
			ASSUME(v.UShort10 <= cmpVal);
			ASSUME(v.UShort11 <= cmpVal);
			ASSUME(v.UShort12 <= cmpVal);
			ASSUME(v.UShort13 <= cmpVal);
			ASSUME(v.UShort14 <= cmpVal);
			ASSUME(v.UShort15 <= cmpVal);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LE_EPU32(v256 v, uint cmpVal, byte elements = 8)
		{
			ASSUME(v.UInt0 <= cmpVal);
			if (elements == 1) return;
			ASSUME(v.UInt1 <= cmpVal);
			ASSUME(v.UInt2 <= cmpVal);
			ASSUME(v.UInt3 <= cmpVal);
			ASSUME(v.UInt4 <= cmpVal);
			ASSUME(v.UInt5 <= cmpVal);
			ASSUME(v.UInt6 <= cmpVal);
			ASSUME(v.UInt7 <= cmpVal);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LE_EPU64(v256 v, ulong cmpVal, byte elements = 4)
		{
			ASSUME(v.ULong0 <= cmpVal);
			if (elements == 1) return;
			ASSUME(v.ULong1 <= cmpVal);
			ASSUME(v.ULong2 <= cmpVal);
			if (elements == 3) return;
			ASSUME(v.ULong3 <= cmpVal);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LE_PS(v256 v, float cmpVal, byte elements = 8)
		{
			ASSUME(math.isnan(v.Float0) ^ (v.Float0 <= cmpVal));
			if (elements == 1) return;
			ASSUME(math.isnan(v.Float1) ^ (v.Float1 <= cmpVal));
			ASSUME(math.isnan(v.Float2) ^ (v.Float2 <= cmpVal));
			ASSUME(math.isnan(v.Float3) ^ (v.Float3 <= cmpVal));
			ASSUME(math.isnan(v.Float4) ^ (v.Float4 <= cmpVal));
			ASSUME(math.isnan(v.Float5) ^ (v.Float5 <= cmpVal));
			ASSUME(math.isnan(v.Float6) ^ (v.Float6 <= cmpVal));
			ASSUME(math.isnan(v.Float7) ^ (v.Float7 <= cmpVal));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LE_PD(v256 v, double cmpVal, byte elements = 4)
		{
			ASSUME(math.isnan(v.Double0) ^ (v.Double0 <= cmpVal));
			if (elements == 1) return;
			ASSUME(math.isnan(v.Double1) ^ (v.Double1 <= cmpVal));
			ASSUME(math.isnan(v.Double2) ^ (v.Double2 <= cmpVal));
			if (elements == 3) return;
			ASSUME(math.isnan(v.Double3) ^ (v.Double3 <= cmpVal));
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_NAN_PS(v128 v, byte elements = 4)
         {
			switch (elements)
			{
				case  1: ASSUME(math.isnan(v.Float0));	return;

				case  2: ASSUME(math.isnan(v.Float0));
						 ASSUME(math.isnan(v.Float1));	return;

				case  3: ASSUME(math.isnan(v.Float0));
						 ASSUME(math.isnan(v.Float1));
						 ASSUME(math.isnan(v.Float2));	return;

				default: ASSUME(math.isnan(v.Float0));
						 ASSUME(math.isnan(v.Float1));
						 ASSUME(math.isnan(v.Float2));
						 ASSUME(math.isnan(v.Float3));	return;
			}
         }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_NOTNAN_PS(v128 v, byte elements = 4)
         {
			switch (elements)
			{
				case  1: ASSUME(!math.isnan(v.Float0));	return;

				case  2: ASSUME(!math.isnan(v.Float0));
						 ASSUME(!math.isnan(v.Float1));	return;

				case  3: ASSUME(!math.isnan(v.Float0));
						 ASSUME(!math.isnan(v.Float1));
						 ASSUME(!math.isnan(v.Float2));	return;

				default: ASSUME(!math.isnan(v.Float0));
						 ASSUME(!math.isnan(v.Float1));
						 ASSUME(!math.isnan(v.Float2));
						 ASSUME(!math.isnan(v.Float3));	return;
			}
         }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_NAN_PS(v256 v)
         {
			ASSUME(math.isnan(v.Float0));
			ASSUME(math.isnan(v.Float1));
			ASSUME(math.isnan(v.Float2));
			ASSUME(math.isnan(v.Float3));
			ASSUME(math.isnan(v.Float4));
			ASSUME(math.isnan(v.Float5));
			ASSUME(math.isnan(v.Float6));
			ASSUME(math.isnan(v.Float7));
         }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_NOTNAN_PS(v256 v)
         {
			ASSUME(!math.isnan(v.Float0));
			ASSUME(!math.isnan(v.Float1));
			ASSUME(!math.isnan(v.Float2));
			ASSUME(!math.isnan(v.Float3));
			ASSUME(!math.isnan(v.Float4));
			ASSUME(!math.isnan(v.Float5));
			ASSUME(!math.isnan(v.Float6));
			ASSUME(!math.isnan(v.Float7));
         }


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_NAN_PD(v128 v)
        {
			ASSUME(math.isnan(v.Double0));
			ASSUME(math.isnan(v.Double1));
        }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_NOTNAN_PD(v128 v)
        {
			ASSUME(!math.isnan(v.Double0));
			ASSUME(!math.isnan(v.Double1));
        }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_NAN_PD(v256 v, byte elements = 4)
        {
            if (elements == 3)
            {
				ASSUME(math.isnan(v.Double0));
				ASSUME(math.isnan(v.Double1));
				ASSUME(math.isnan(v.Double2));
            }
			else
            {
				ASSUME(math.isnan(v.Double0));
				ASSUME(math.isnan(v.Double1));
				ASSUME(math.isnan(v.Double2));
				ASSUME(math.isnan(v.Double3));
            }
        }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_NOTNAN_PD(v256 v, byte elements = 4)
        {
            if (elements == 3)
            {
				ASSUME(!math.isnan(v.Double0));
				ASSUME(!math.isnan(v.Double1));
				ASSUME(!math.isnan(v.Double2));
            }
			else
            {
				ASSUME(!math.isnan(v.Double0));
				ASSUME(!math.isnan(v.Double1));
				ASSUME(!math.isnan(v.Double2));
				ASSUME(!math.isnan(v.Double3));
            }
        }


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_POW2_EPU8(v128 v, byte elements = 16)
		{
			switch (elements)
			{
				case  1: ASSUME(maxmath.ispow2(v.Byte0 ));	return;

				case  2: ASSUME(maxmath.ispow2(v.Byte0 ));
						 ASSUME(maxmath.ispow2(v.Byte1 ));	return;

				case  3: ASSUME(maxmath.ispow2(v.Byte0 ));
						 ASSUME(maxmath.ispow2(v.Byte1 ));
						 ASSUME(maxmath.ispow2(v.Byte2 ));	return;

				case  4: ASSUME(maxmath.ispow2(v.Byte0 ));
						 ASSUME(maxmath.ispow2(v.Byte1 ));
						 ASSUME(maxmath.ispow2(v.Byte2 ));
						 ASSUME(maxmath.ispow2(v.Byte3 ));	return;

				case  8: ASSUME(maxmath.ispow2(v.Byte0 ));
						 ASSUME(maxmath.ispow2(v.Byte1 ));
						 ASSUME(maxmath.ispow2(v.Byte2 ));
						 ASSUME(maxmath.ispow2(v.Byte3 ));
						 ASSUME(maxmath.ispow2(v.Byte4 ));
						 ASSUME(maxmath.ispow2(v.Byte5 ));
						 ASSUME(maxmath.ispow2(v.Byte6 ));
						 ASSUME(maxmath.ispow2(v.Byte7 ));	return;

				default: ASSUME(maxmath.ispow2(v.Byte0 ));
						 ASSUME(maxmath.ispow2(v.Byte1 ));
						 ASSUME(maxmath.ispow2(v.Byte2 ));
						 ASSUME(maxmath.ispow2(v.Byte3 ));
						 ASSUME(maxmath.ispow2(v.Byte4 ));
						 ASSUME(maxmath.ispow2(v.Byte5 ));
						 ASSUME(maxmath.ispow2(v.Byte6 ));
						 ASSUME(maxmath.ispow2(v.Byte7 ));
						 ASSUME(maxmath.ispow2(v.Byte8 ));
						 ASSUME(maxmath.ispow2(v.Byte9 ));
						 ASSUME(maxmath.ispow2(v.Byte10));
						 ASSUME(maxmath.ispow2(v.Byte11));
						 ASSUME(maxmath.ispow2(v.Byte12));
						 ASSUME(maxmath.ispow2(v.Byte13));
						 ASSUME(maxmath.ispow2(v.Byte14));
						 ASSUME(maxmath.ispow2(v.Byte15));	return;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_POW2_EPU16(v128 v, byte elements = 8)
		{
			switch (elements)
			{
				case  1: ASSUME(maxmath.ispow2(v.UShort0));	return;

				case  2: ASSUME(maxmath.ispow2(v.UShort0));
						 ASSUME(maxmath.ispow2(v.UShort1));	return;

				case  3: ASSUME(maxmath.ispow2(v.UShort0));
						 ASSUME(maxmath.ispow2(v.UShort1));
						 ASSUME(maxmath.ispow2(v.UShort2));	return;

				case  4: ASSUME(maxmath.ispow2(v.UShort0));
						 ASSUME(maxmath.ispow2(v.UShort1));
						 ASSUME(maxmath.ispow2(v.UShort2));
						 ASSUME(maxmath.ispow2(v.UShort3));	return;

				default: ASSUME(maxmath.ispow2(v.UShort0));
						 ASSUME(maxmath.ispow2(v.UShort1));
						 ASSUME(maxmath.ispow2(v.UShort2));
						 ASSUME(maxmath.ispow2(v.UShort3));
						 ASSUME(maxmath.ispow2(v.UShort4));
						 ASSUME(maxmath.ispow2(v.UShort5));
						 ASSUME(maxmath.ispow2(v.UShort6));
						 ASSUME(maxmath.ispow2(v.UShort7));	return;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_POW2_EPU32(v128 v, byte elements = 4)
		{
			switch (elements)
			{
				case  1: ASSUME(math.ispow2(v.UInt0));	return;

				case  2: ASSUME(math.ispow2(v.UInt0));
						 ASSUME(math.ispow2(v.UInt1));	return;

				case  3: ASSUME(math.ispow2(v.UInt0));
						 ASSUME(math.ispow2(v.UInt1));
						 ASSUME(math.ispow2(v.UInt2));	return;

				default: ASSUME(math.ispow2(v.UInt0));
						 ASSUME(math.ispow2(v.UInt1));
						 ASSUME(math.ispow2(v.UInt2));
						 ASSUME(math.ispow2(v.UInt3));	return;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_POW2_EPU64(v128 v, byte elements = 2)
		{
            if (elements == 1)
            {
				ASSUME(maxmath.ispow2(v.ULong0));
            }
			else
			{
				ASSUME(maxmath.ispow2(v.ULong0));
				ASSUME(maxmath.ispow2(v.ULong1));
			}
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_POW2_EPI8(v128 v, byte elements = 16)
		{
			switch (elements)
			{
				case  1: ASSUME(maxmath.ispow2(v.SByte0 ));	return;

				case  2: ASSUME(maxmath.ispow2(v.SByte0 ));
						 ASSUME(maxmath.ispow2(v.SByte1 ));	return;

				case  3: ASSUME(maxmath.ispow2(v.SByte0 ));
						 ASSUME(maxmath.ispow2(v.SByte1 ));
						 ASSUME(maxmath.ispow2(v.SByte2 ));	return;

				case  4: ASSUME(maxmath.ispow2(v.SByte0 ));
						 ASSUME(maxmath.ispow2(v.SByte1 ));
						 ASSUME(maxmath.ispow2(v.SByte2 ));
						 ASSUME(maxmath.ispow2(v.SByte3 ));	return;

				case  8: ASSUME(maxmath.ispow2(v.SByte0 ));
						 ASSUME(maxmath.ispow2(v.SByte1 ));
						 ASSUME(maxmath.ispow2(v.SByte2 ));
						 ASSUME(maxmath.ispow2(v.SByte3 ));
						 ASSUME(maxmath.ispow2(v.SByte4 ));
						 ASSUME(maxmath.ispow2(v.SByte5 ));
						 ASSUME(maxmath.ispow2(v.SByte6 ));
						 ASSUME(maxmath.ispow2(v.SByte7 ));	return;

				default: ASSUME(maxmath.ispow2(v.SByte0 ));
						 ASSUME(maxmath.ispow2(v.SByte1 ));
						 ASSUME(maxmath.ispow2(v.SByte2 ));
						 ASSUME(maxmath.ispow2(v.SByte3 ));
						 ASSUME(maxmath.ispow2(v.SByte4 ));
						 ASSUME(maxmath.ispow2(v.SByte5 ));
						 ASSUME(maxmath.ispow2(v.SByte6 ));
						 ASSUME(maxmath.ispow2(v.SByte7 ));
						 ASSUME(maxmath.ispow2(v.SByte8 ));
						 ASSUME(maxmath.ispow2(v.SByte9 ));
						 ASSUME(maxmath.ispow2(v.SByte10));
						 ASSUME(maxmath.ispow2(v.SByte11));
						 ASSUME(maxmath.ispow2(v.SByte12));
						 ASSUME(maxmath.ispow2(v.SByte13));
						 ASSUME(maxmath.ispow2(v.SByte14));
						 ASSUME(maxmath.ispow2(v.SByte15));	return;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_POW2_EPI16(v128 v, byte elements = 8)
		{
			switch (elements)
			{
				case  1: ASSUME(maxmath.ispow2(v.SShort0));	return;

				case  2: ASSUME(maxmath.ispow2(v.SShort0));
						 ASSUME(maxmath.ispow2(v.SShort1));	return;

				case  3: ASSUME(maxmath.ispow2(v.SShort0));
						 ASSUME(maxmath.ispow2(v.SShort1));
						 ASSUME(maxmath.ispow2(v.SShort2));	return;

				case  4: ASSUME(maxmath.ispow2(v.SShort0));
						 ASSUME(maxmath.ispow2(v.SShort1));
						 ASSUME(maxmath.ispow2(v.SShort2));
						 ASSUME(maxmath.ispow2(v.SShort3));	return;

				default: ASSUME(maxmath.ispow2(v.SShort0));
						 ASSUME(maxmath.ispow2(v.SShort1));
						 ASSUME(maxmath.ispow2(v.SShort2));
						 ASSUME(maxmath.ispow2(v.SShort3));
						 ASSUME(maxmath.ispow2(v.SShort4));
						 ASSUME(maxmath.ispow2(v.SShort5));
						 ASSUME(maxmath.ispow2(v.SShort6));
						 ASSUME(maxmath.ispow2(v.SShort7));	return;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_POW2_EPI32(v128 v, byte elements = 4)
		{
			switch (elements)
			{
				case  1: ASSUME(math.ispow2(v.SInt0));	return;

				case  2: ASSUME(math.ispow2(v.SInt0));
						 ASSUME(math.ispow2(v.SInt1));	return;

				case  3: ASSUME(math.ispow2(v.SInt0));
						 ASSUME(math.ispow2(v.SInt1));
						 ASSUME(math.ispow2(v.SInt2));	return;

				default: ASSUME(math.ispow2(v.SInt0));
						 ASSUME(math.ispow2(v.SInt1));
						 ASSUME(math.ispow2(v.SInt2));
						 ASSUME(math.ispow2(v.SInt3));	return;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_POW2_EPI64(v128 v, byte elements = 2)
		{
            if (elements == 1)
            {
				ASSUME(maxmath.ispow2(v.SLong0));
            }
			else
			{
				ASSUME(maxmath.ispow2(v.SLong0));
				ASSUME(maxmath.ispow2(v.SLong1));
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_POW2_EPU8(v256 v)
		{
			ASSUME(maxmath.ispow2(v.Byte0 ));
			ASSUME(maxmath.ispow2(v.Byte1 ));
			ASSUME(maxmath.ispow2(v.Byte2 ));
			ASSUME(maxmath.ispow2(v.Byte3 ));
			ASSUME(maxmath.ispow2(v.Byte4 ));
			ASSUME(maxmath.ispow2(v.Byte5 ));
			ASSUME(maxmath.ispow2(v.Byte6 ));
			ASSUME(maxmath.ispow2(v.Byte7 ));
			ASSUME(maxmath.ispow2(v.Byte8 ));
			ASSUME(maxmath.ispow2(v.Byte9 ));
			ASSUME(maxmath.ispow2(v.Byte10));
			ASSUME(maxmath.ispow2(v.Byte11));
			ASSUME(maxmath.ispow2(v.Byte12));
			ASSUME(maxmath.ispow2(v.Byte13));
			ASSUME(maxmath.ispow2(v.Byte14));
			ASSUME(maxmath.ispow2(v.Byte15));
			ASSUME(maxmath.ispow2(v.Byte16));
			ASSUME(maxmath.ispow2(v.Byte17));
			ASSUME(maxmath.ispow2(v.Byte18));
			ASSUME(maxmath.ispow2(v.Byte19));
			ASSUME(maxmath.ispow2(v.Byte20));
			ASSUME(maxmath.ispow2(v.Byte21));
			ASSUME(maxmath.ispow2(v.Byte22));
			ASSUME(maxmath.ispow2(v.Byte23));
			ASSUME(maxmath.ispow2(v.Byte24));
			ASSUME(maxmath.ispow2(v.Byte25));
			ASSUME(maxmath.ispow2(v.Byte26));
			ASSUME(maxmath.ispow2(v.Byte27));
			ASSUME(maxmath.ispow2(v.Byte28));
			ASSUME(maxmath.ispow2(v.Byte29));
			ASSUME(maxmath.ispow2(v.Byte30));
			ASSUME(maxmath.ispow2(v.Byte31));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_POW2_EPU16(v256 v)
		{
			ASSUME(maxmath.ispow2(v.UShort0 ));
			ASSUME(maxmath.ispow2(v.UShort1 ));
			ASSUME(maxmath.ispow2(v.UShort2 ));
			ASSUME(maxmath.ispow2(v.UShort3 ));
			ASSUME(maxmath.ispow2(v.UShort4 ));
			ASSUME(maxmath.ispow2(v.UShort5 ));
			ASSUME(maxmath.ispow2(v.UShort6 ));
			ASSUME(maxmath.ispow2(v.UShort7 ));
			ASSUME(maxmath.ispow2(v.UShort8 ));
			ASSUME(maxmath.ispow2(v.UShort9 ));
			ASSUME(maxmath.ispow2(v.UShort10));
			ASSUME(maxmath.ispow2(v.UShort11));
			ASSUME(maxmath.ispow2(v.UShort12));
			ASSUME(maxmath.ispow2(v.UShort13));
			ASSUME(maxmath.ispow2(v.UShort14));
			ASSUME(maxmath.ispow2(v.UShort15));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_POW2_EPU32(v256 v)
		{
			ASSUME(math.ispow2(v.UInt0));
			ASSUME(math.ispow2(v.UInt1));
			ASSUME(math.ispow2(v.UInt2));
			ASSUME(math.ispow2(v.UInt3));
			ASSUME(math.ispow2(v.UInt4));
			ASSUME(math.ispow2(v.UInt5));
			ASSUME(math.ispow2(v.UInt6));
			ASSUME(math.ispow2(v.UInt7));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_POW2_EPU64(v256 v, byte elements = 4)
		{
			if (elements == 3)
			{
				ASSUME(maxmath.ispow2(v.ULong0));
				ASSUME(maxmath.ispow2(v.ULong1));
				ASSUME(maxmath.ispow2(v.ULong2));
			}
			else
			{
				ASSUME(maxmath.ispow2(v.ULong0));
				ASSUME(maxmath.ispow2(v.ULong1));
				ASSUME(maxmath.ispow2(v.ULong2));
				ASSUME(maxmath.ispow2(v.ULong3));
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_POW2_EPI8(v256 v)
		{
			ASSUME(maxmath.ispow2(v.SByte0 ));
			ASSUME(maxmath.ispow2(v.SByte1 ));
			ASSUME(maxmath.ispow2(v.SByte2 ));
			ASSUME(maxmath.ispow2(v.SByte3 ));
			ASSUME(maxmath.ispow2(v.SByte4 ));
			ASSUME(maxmath.ispow2(v.SByte5 ));
			ASSUME(maxmath.ispow2(v.SByte6 ));
			ASSUME(maxmath.ispow2(v.SByte7 ));
			ASSUME(maxmath.ispow2(v.SByte8 ));
			ASSUME(maxmath.ispow2(v.SByte9 ));
			ASSUME(maxmath.ispow2(v.SByte10));
			ASSUME(maxmath.ispow2(v.SByte11));
			ASSUME(maxmath.ispow2(v.SByte12));
			ASSUME(maxmath.ispow2(v.SByte13));
			ASSUME(maxmath.ispow2(v.SByte14));
			ASSUME(maxmath.ispow2(v.SByte15));
			ASSUME(maxmath.ispow2(v.SByte16));
			ASSUME(maxmath.ispow2(v.SByte17));
			ASSUME(maxmath.ispow2(v.SByte18));
			ASSUME(maxmath.ispow2(v.SByte19));
			ASSUME(maxmath.ispow2(v.SByte20));
			ASSUME(maxmath.ispow2(v.SByte21));
			ASSUME(maxmath.ispow2(v.SByte22));
			ASSUME(maxmath.ispow2(v.SByte23));
			ASSUME(maxmath.ispow2(v.SByte24));
			ASSUME(maxmath.ispow2(v.SByte25));
			ASSUME(maxmath.ispow2(v.SByte26));
			ASSUME(maxmath.ispow2(v.SByte27));
			ASSUME(maxmath.ispow2(v.SByte28));
			ASSUME(maxmath.ispow2(v.SByte29));
			ASSUME(maxmath.ispow2(v.SByte30));
			ASSUME(maxmath.ispow2(v.SByte31));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_POW2_EPI16(v256 v)
		{
			ASSUME(maxmath.ispow2(v.SShort0 ));
			ASSUME(maxmath.ispow2(v.SShort1 ));
			ASSUME(maxmath.ispow2(v.SShort2 ));
			ASSUME(maxmath.ispow2(v.SShort3 ));
			ASSUME(maxmath.ispow2(v.SShort4 ));
			ASSUME(maxmath.ispow2(v.SShort5 ));
			ASSUME(maxmath.ispow2(v.SShort6 ));
			ASSUME(maxmath.ispow2(v.SShort7 ));
			ASSUME(maxmath.ispow2(v.SShort8 ));
			ASSUME(maxmath.ispow2(v.SShort9 ));
			ASSUME(maxmath.ispow2(v.SShort10));
			ASSUME(maxmath.ispow2(v.SShort11));
			ASSUME(maxmath.ispow2(v.SShort12));
			ASSUME(maxmath.ispow2(v.SShort13));
			ASSUME(maxmath.ispow2(v.SShort14));
			ASSUME(maxmath.ispow2(v.SShort15));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_POW2_EPI32(v256 v)
		{
			ASSUME(math.ispow2(v.SInt0));
			ASSUME(math.ispow2(v.SInt1));
			ASSUME(math.ispow2(v.SInt2));
			ASSUME(math.ispow2(v.SInt3));
			ASSUME(math.ispow2(v.SInt4));
			ASSUME(math.ispow2(v.SInt5));
			ASSUME(math.ispow2(v.SInt6));
			ASSUME(math.ispow2(v.SInt7));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_POW2_EPI64(v256 v, byte elements = 4)
		{
			if (elements == 3)
			{
				ASSUME(maxmath.ispow2(v.SLong0));
				ASSUME(maxmath.ispow2(v.SLong1));
				ASSUME(maxmath.ispow2(v.SLong2));
			}
			else
			{
				ASSUME(maxmath.ispow2(v.SLong0));
				ASSUME(maxmath.ispow2(v.SLong1));
				ASSUME(maxmath.ispow2(v.SLong2));
				ASSUME(maxmath.ispow2(v.SLong3));
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_NONE_POW2_EPU8(v128 v, byte elements = 16)
		{
			switch (elements)
			{
				case  1: ASSUME(!maxmath.ispow2(v.Byte0 ));	return;

				case  2: ASSUME(!maxmath.ispow2(v.Byte0 ));
						 ASSUME(!maxmath.ispow2(v.Byte1 ));	return;

				case  3: ASSUME(!maxmath.ispow2(v.Byte0 ));
						 ASSUME(!maxmath.ispow2(v.Byte1 ));
						 ASSUME(!maxmath.ispow2(v.Byte2 ));	return;

				case  4: ASSUME(!maxmath.ispow2(v.Byte0 ));
						 ASSUME(!maxmath.ispow2(v.Byte1 ));
						 ASSUME(!maxmath.ispow2(v.Byte2 ));
						 ASSUME(!maxmath.ispow2(v.Byte3 ));	return;

				case  8: ASSUME(!maxmath.ispow2(v.Byte0 ));
						 ASSUME(!maxmath.ispow2(v.Byte1 ));
						 ASSUME(!maxmath.ispow2(v.Byte2 ));
						 ASSUME(!maxmath.ispow2(v.Byte3 ));
						 ASSUME(!maxmath.ispow2(v.Byte4 ));
						 ASSUME(!maxmath.ispow2(v.Byte5 ));
						 ASSUME(!maxmath.ispow2(v.Byte6 ));
						 ASSUME(!maxmath.ispow2(v.Byte7 ));	return;

				default: ASSUME(!maxmath.ispow2(v.Byte0 ));
						 ASSUME(!maxmath.ispow2(v.Byte1 ));
						 ASSUME(!maxmath.ispow2(v.Byte2 ));
						 ASSUME(!maxmath.ispow2(v.Byte3 ));
						 ASSUME(!maxmath.ispow2(v.Byte4 ));
						 ASSUME(!maxmath.ispow2(v.Byte5 ));
						 ASSUME(!maxmath.ispow2(v.Byte6 ));
						 ASSUME(!maxmath.ispow2(v.Byte7 ));
						 ASSUME(!maxmath.ispow2(v.Byte8 ));
						 ASSUME(!maxmath.ispow2(v.Byte9 ));
						 ASSUME(!maxmath.ispow2(v.Byte10));
						 ASSUME(!maxmath.ispow2(v.Byte11));
						 ASSUME(!maxmath.ispow2(v.Byte12));
						 ASSUME(!maxmath.ispow2(v.Byte13));
						 ASSUME(!maxmath.ispow2(v.Byte14));
						 ASSUME(!maxmath.ispow2(v.Byte15));	return;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_NONE_POW2_EPU16(v128 v, byte elements = 8)
		{
			switch (elements)
			{
				case  1: ASSUME(!maxmath.ispow2(v.UShort0));	return;

				case  2: ASSUME(!maxmath.ispow2(v.UShort0));
						 ASSUME(!maxmath.ispow2(v.UShort1));	return;

				case  3: ASSUME(!maxmath.ispow2(v.UShort0));
						 ASSUME(!maxmath.ispow2(v.UShort1));
						 ASSUME(!maxmath.ispow2(v.UShort2));	return;

				case  4: ASSUME(!maxmath.ispow2(v.UShort0));
						 ASSUME(!maxmath.ispow2(v.UShort1));
						 ASSUME(!maxmath.ispow2(v.UShort2));
						 ASSUME(!maxmath.ispow2(v.UShort3));	return;

				default: ASSUME(!maxmath.ispow2(v.UShort0));
						 ASSUME(!maxmath.ispow2(v.UShort1));
						 ASSUME(!maxmath.ispow2(v.UShort2));
						 ASSUME(!maxmath.ispow2(v.UShort3));
						 ASSUME(!maxmath.ispow2(v.UShort4));
						 ASSUME(!maxmath.ispow2(v.UShort5));
						 ASSUME(!maxmath.ispow2(v.UShort6));
						 ASSUME(!maxmath.ispow2(v.UShort7));	return;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_NONE_POW2_EPU32(v128 v, byte elements = 4)
		{
			switch (elements)
			{
				case  1: ASSUME(!math.ispow2(v.UInt0));	return;

				case  2: ASSUME(!math.ispow2(v.UInt0));
						 ASSUME(!math.ispow2(v.UInt1));	return;

				case  3: ASSUME(!math.ispow2(v.UInt0));
						 ASSUME(!math.ispow2(v.UInt1));
						 ASSUME(!math.ispow2(v.UInt2));	return;

				default: ASSUME(!math.ispow2(v.UInt0));
						 ASSUME(!math.ispow2(v.UInt1));
						 ASSUME(!math.ispow2(v.UInt2));
						 ASSUME(!math.ispow2(v.UInt3));	return;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_NONE_POW2_EPU64(v128 v, byte elements = 2)
		{
            if (elements == 1)
            {
				ASSUME(!maxmath.ispow2(v.ULong0));
            }
			else
			{
				ASSUME(!maxmath.ispow2(v.ULong0));
				ASSUME(!maxmath.ispow2(v.ULong1));
			}
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_NONE_POW2_EPI8(v128 v, byte elements = 16)
		{
			switch (elements)
			{
				case  1: ASSUME(!maxmath.ispow2(v.SByte0 ));	return;

				case  2: ASSUME(!maxmath.ispow2(v.SByte0 ));
						 ASSUME(!maxmath.ispow2(v.SByte1 ));	return;

				case  3: ASSUME(!maxmath.ispow2(v.SByte0 ));
						 ASSUME(!maxmath.ispow2(v.SByte1 ));
						 ASSUME(!maxmath.ispow2(v.SByte2 ));	return;

				case  4: ASSUME(!maxmath.ispow2(v.SByte0 ));
						 ASSUME(!maxmath.ispow2(v.SByte1 ));
						 ASSUME(!maxmath.ispow2(v.SByte2 ));
						 ASSUME(!maxmath.ispow2(v.SByte3 ));	return;

				case  8: ASSUME(!maxmath.ispow2(v.SByte0 ));
						 ASSUME(!maxmath.ispow2(v.SByte1 ));
						 ASSUME(!maxmath.ispow2(v.SByte2 ));
						 ASSUME(!maxmath.ispow2(v.SByte3 ));
						 ASSUME(!maxmath.ispow2(v.SByte4 ));
						 ASSUME(!maxmath.ispow2(v.SByte5 ));
						 ASSUME(!maxmath.ispow2(v.SByte6 ));
						 ASSUME(!maxmath.ispow2(v.SByte7 ));	return;

				default: ASSUME(!maxmath.ispow2(v.SByte0 ));
						 ASSUME(!maxmath.ispow2(v.SByte1 ));
						 ASSUME(!maxmath.ispow2(v.SByte2 ));
						 ASSUME(!maxmath.ispow2(v.SByte3 ));
						 ASSUME(!maxmath.ispow2(v.SByte4 ));
						 ASSUME(!maxmath.ispow2(v.SByte5 ));
						 ASSUME(!maxmath.ispow2(v.SByte6 ));
						 ASSUME(!maxmath.ispow2(v.SByte7 ));
						 ASSUME(!maxmath.ispow2(v.SByte8 ));
						 ASSUME(!maxmath.ispow2(v.SByte9 ));
						 ASSUME(!maxmath.ispow2(v.SByte10));
						 ASSUME(!maxmath.ispow2(v.SByte11));
						 ASSUME(!maxmath.ispow2(v.SByte12));
						 ASSUME(!maxmath.ispow2(v.SByte13));
						 ASSUME(!maxmath.ispow2(v.SByte14));
						 ASSUME(!maxmath.ispow2(v.SByte15));	return;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_NONE_POW2_EPI16(v128 v, byte elements = 8)
		{
			switch (elements)
			{
				case  1: ASSUME(!maxmath.ispow2(v.SShort0));	return;

				case  2: ASSUME(!maxmath.ispow2(v.SShort0));
						 ASSUME(!maxmath.ispow2(v.SShort1));	return;

				case  3: ASSUME(!maxmath.ispow2(v.SShort0));
						 ASSUME(!maxmath.ispow2(v.SShort1));
						 ASSUME(!maxmath.ispow2(v.SShort2));	return;

				case  4: ASSUME(!maxmath.ispow2(v.SShort0));
						 ASSUME(!maxmath.ispow2(v.SShort1));
						 ASSUME(!maxmath.ispow2(v.SShort2));
						 ASSUME(!maxmath.ispow2(v.SShort3));	return;

				default: ASSUME(!maxmath.ispow2(v.SShort0));
						 ASSUME(!maxmath.ispow2(v.SShort1));
						 ASSUME(!maxmath.ispow2(v.SShort2));
						 ASSUME(!maxmath.ispow2(v.SShort3));
						 ASSUME(!maxmath.ispow2(v.SShort4));
						 ASSUME(!maxmath.ispow2(v.SShort5));
						 ASSUME(!maxmath.ispow2(v.SShort6));
						 ASSUME(!maxmath.ispow2(v.SShort7));	return;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_NONE_POW2_EPI32(v128 v, byte elements = 4)
		{
			switch (elements)
			{
				case  1: ASSUME(!math.ispow2(v.SInt0));	return;

				case  2: ASSUME(!math.ispow2(v.SInt0));
						 ASSUME(!math.ispow2(v.SInt1));	return;

				case  3: ASSUME(!math.ispow2(v.SInt0));
						 ASSUME(!math.ispow2(v.SInt1));
						 ASSUME(!math.ispow2(v.SInt2));	return;

				default: ASSUME(!math.ispow2(v.SInt0));
						 ASSUME(!math.ispow2(v.SInt1));
						 ASSUME(!math.ispow2(v.SInt2));
						 ASSUME(!math.ispow2(v.SInt3));	return;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_NONE_POW2_EPI64(v128 v, byte elements = 2)
		{
            if (elements == 1)
            {
				ASSUME(!maxmath.ispow2(v.SLong0));
            }
			else
			{
				ASSUME(!maxmath.ispow2(v.SLong0));
				ASSUME(!maxmath.ispow2(v.SLong1));
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_NONE_POW2_EPU8(v256 v)
		{
			ASSUME(!maxmath.ispow2(v.Byte0 ));
			ASSUME(!maxmath.ispow2(v.Byte1 ));
			ASSUME(!maxmath.ispow2(v.Byte2 ));
			ASSUME(!maxmath.ispow2(v.Byte3 ));
			ASSUME(!maxmath.ispow2(v.Byte4 ));
			ASSUME(!maxmath.ispow2(v.Byte5 ));
			ASSUME(!maxmath.ispow2(v.Byte6 ));
			ASSUME(!maxmath.ispow2(v.Byte7 ));
			ASSUME(!maxmath.ispow2(v.Byte8 ));
			ASSUME(!maxmath.ispow2(v.Byte9 ));
			ASSUME(!maxmath.ispow2(v.Byte10));
			ASSUME(!maxmath.ispow2(v.Byte11));
			ASSUME(!maxmath.ispow2(v.Byte12));
			ASSUME(!maxmath.ispow2(v.Byte13));
			ASSUME(!maxmath.ispow2(v.Byte14));
			ASSUME(!maxmath.ispow2(v.Byte15));
			ASSUME(!maxmath.ispow2(v.Byte16));
			ASSUME(!maxmath.ispow2(v.Byte17));
			ASSUME(!maxmath.ispow2(v.Byte18));
			ASSUME(!maxmath.ispow2(v.Byte19));
			ASSUME(!maxmath.ispow2(v.Byte20));
			ASSUME(!maxmath.ispow2(v.Byte21));
			ASSUME(!maxmath.ispow2(v.Byte22));
			ASSUME(!maxmath.ispow2(v.Byte23));
			ASSUME(!maxmath.ispow2(v.Byte24));
			ASSUME(!maxmath.ispow2(v.Byte25));
			ASSUME(!maxmath.ispow2(v.Byte26));
			ASSUME(!maxmath.ispow2(v.Byte27));
			ASSUME(!maxmath.ispow2(v.Byte28));
			ASSUME(!maxmath.ispow2(v.Byte29));
			ASSUME(!maxmath.ispow2(v.Byte30));
			ASSUME(!maxmath.ispow2(v.Byte31));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_NONE_POW2_EPU16(v256 v)
		{
			ASSUME(!maxmath.ispow2(v.UShort0 ));
			ASSUME(!maxmath.ispow2(v.UShort1 ));
			ASSUME(!maxmath.ispow2(v.UShort2 ));
			ASSUME(!maxmath.ispow2(v.UShort3 ));
			ASSUME(!maxmath.ispow2(v.UShort4 ));
			ASSUME(!maxmath.ispow2(v.UShort5 ));
			ASSUME(!maxmath.ispow2(v.UShort6 ));
			ASSUME(!maxmath.ispow2(v.UShort7 ));
			ASSUME(!maxmath.ispow2(v.UShort8 ));
			ASSUME(!maxmath.ispow2(v.UShort9 ));
			ASSUME(!maxmath.ispow2(v.UShort10));
			ASSUME(!maxmath.ispow2(v.UShort11));
			ASSUME(!maxmath.ispow2(v.UShort12));
			ASSUME(!maxmath.ispow2(v.UShort13));
			ASSUME(!maxmath.ispow2(v.UShort14));
			ASSUME(!maxmath.ispow2(v.UShort15));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_NONE_POW2_EPU32(v256 v)
		{
			ASSUME(!math.ispow2(v.UInt0));
			ASSUME(!math.ispow2(v.UInt1));
			ASSUME(!math.ispow2(v.UInt2));
			ASSUME(!math.ispow2(v.UInt3));
			ASSUME(!math.ispow2(v.UInt4));
			ASSUME(!math.ispow2(v.UInt5));
			ASSUME(!math.ispow2(v.UInt6));
			ASSUME(!math.ispow2(v.UInt7));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_NONE_POW2_EPU64(v256 v, byte elements = 4)
		{
			if (elements == 3)
			{
				ASSUME(!maxmath.ispow2(v.ULong0));
				ASSUME(!maxmath.ispow2(v.ULong1));
				ASSUME(!maxmath.ispow2(v.ULong2));
			}
			else
			{
				ASSUME(!maxmath.ispow2(v.ULong0));
				ASSUME(!maxmath.ispow2(v.ULong1));
				ASSUME(!maxmath.ispow2(v.ULong2));
				ASSUME(!maxmath.ispow2(v.ULong3));
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_NONE_POW2_EPI8(v256 v)
		{
			ASSUME(!maxmath.ispow2(v.SByte0 ));
			ASSUME(!maxmath.ispow2(v.SByte1 ));
			ASSUME(!maxmath.ispow2(v.SByte2 ));
			ASSUME(!maxmath.ispow2(v.SByte3 ));
			ASSUME(!maxmath.ispow2(v.SByte4 ));
			ASSUME(!maxmath.ispow2(v.SByte5 ));
			ASSUME(!maxmath.ispow2(v.SByte6 ));
			ASSUME(!maxmath.ispow2(v.SByte7 ));
			ASSUME(!maxmath.ispow2(v.SByte8 ));
			ASSUME(!maxmath.ispow2(v.SByte9 ));
			ASSUME(!maxmath.ispow2(v.SByte10));
			ASSUME(!maxmath.ispow2(v.SByte11));
			ASSUME(!maxmath.ispow2(v.SByte12));
			ASSUME(!maxmath.ispow2(v.SByte13));
			ASSUME(!maxmath.ispow2(v.SByte14));
			ASSUME(!maxmath.ispow2(v.SByte15));
			ASSUME(!maxmath.ispow2(v.SByte16));
			ASSUME(!maxmath.ispow2(v.SByte17));
			ASSUME(!maxmath.ispow2(v.SByte18));
			ASSUME(!maxmath.ispow2(v.SByte19));
			ASSUME(!maxmath.ispow2(v.SByte20));
			ASSUME(!maxmath.ispow2(v.SByte21));
			ASSUME(!maxmath.ispow2(v.SByte22));
			ASSUME(!maxmath.ispow2(v.SByte23));
			ASSUME(!maxmath.ispow2(v.SByte24));
			ASSUME(!maxmath.ispow2(v.SByte25));
			ASSUME(!maxmath.ispow2(v.SByte26));
			ASSUME(!maxmath.ispow2(v.SByte27));
			ASSUME(!maxmath.ispow2(v.SByte28));
			ASSUME(!maxmath.ispow2(v.SByte29));
			ASSUME(!maxmath.ispow2(v.SByte30));
			ASSUME(!maxmath.ispow2(v.SByte31));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_NONE_POW2_EPI16(v256 v)
		{
			ASSUME(!maxmath.ispow2(v.SShort0 ));
			ASSUME(!maxmath.ispow2(v.SShort1 ));
			ASSUME(!maxmath.ispow2(v.SShort2 ));
			ASSUME(!maxmath.ispow2(v.SShort3 ));
			ASSUME(!maxmath.ispow2(v.SShort4 ));
			ASSUME(!maxmath.ispow2(v.SShort5 ));
			ASSUME(!maxmath.ispow2(v.SShort6 ));
			ASSUME(!maxmath.ispow2(v.SShort7 ));
			ASSUME(!maxmath.ispow2(v.SShort8 ));
			ASSUME(!maxmath.ispow2(v.SShort9 ));
			ASSUME(!maxmath.ispow2(v.SShort10));
			ASSUME(!maxmath.ispow2(v.SShort11));
			ASSUME(!maxmath.ispow2(v.SShort12));
			ASSUME(!maxmath.ispow2(v.SShort13));
			ASSUME(!maxmath.ispow2(v.SShort14));
			ASSUME(!maxmath.ispow2(v.SShort15));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_NONE_POW2_EPI32(v256 v)
		{
			ASSUME(!math.ispow2(v.SInt0));
			ASSUME(!math.ispow2(v.SInt1));
			ASSUME(!math.ispow2(v.SInt2));
			ASSUME(!math.ispow2(v.SInt3));
			ASSUME(!math.ispow2(v.SInt4));
			ASSUME(!math.ispow2(v.SInt5));
			ASSUME(!math.ispow2(v.SInt6));
			ASSUME(!math.ispow2(v.SInt7));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_NONE_POW2_EPI64(v256 v, byte elements = 4)
		{
			if (elements == 3)
			{
				ASSUME(!maxmath.ispow2(v.SLong0));
				ASSUME(!maxmath.ispow2(v.SLong1));
				ASSUME(!maxmath.ispow2(v.SLong2));
			}
			else
			{
				ASSUME(!maxmath.ispow2(v.SLong0));
				ASSUME(!maxmath.ispow2(v.SLong1));
				ASSUME(!maxmath.ispow2(v.SLong2));
				ASSUME(!maxmath.ispow2(v.SLong3));
			}
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_EQ_EPU8(v128 a, v128 b, byte elements = 16)
		{
			switch (elements)
			{
				case  2: ASSUME(a.Byte0  == b.Byte0);
						 ASSUME(a.Byte1  == b.Byte1);	return;

				case  3: ASSUME(a.Byte0  == b.Byte0);
						 ASSUME(a.Byte1  == b.Byte1);
						 ASSUME(a.Byte2  == b.Byte2);	return;

				case  4: ASSUME(a.Byte0  == b.Byte0);
						 ASSUME(a.Byte1  == b.Byte1);
						 ASSUME(a.Byte2  == b.Byte2);
						 ASSUME(a.Byte3  == b.Byte3);	return;

				case  8: ASSUME(a.Byte0  == b.Byte0);
						 ASSUME(a.Byte1  == b.Byte1);
						 ASSUME(a.Byte2  == b.Byte2);
						 ASSUME(a.Byte3  == b.Byte3);
						 ASSUME(a.Byte4  == b.Byte4);
						 ASSUME(a.Byte5  == b.Byte5);
						 ASSUME(a.Byte6  == b.Byte6);
						 ASSUME(a.Byte7  == b.Byte7);	return;

				default: ASSUME(a.Byte0  == b.Byte0);
						 ASSUME(a.Byte1  == b.Byte1);
						 ASSUME(a.Byte2  == b.Byte2);
						 ASSUME(a.Byte3  == b.Byte3);
						 ASSUME(a.Byte4  == b.Byte4);
						 ASSUME(a.Byte5  == b.Byte5);
						 ASSUME(a.Byte6  == b.Byte6);
						 ASSUME(a.Byte7  == b.Byte7);
						 ASSUME(a.Byte8  == b.Byte8);
						 ASSUME(a.Byte9  == b.Byte9);
						 ASSUME(a.Byte10 == b.Byte10);
						 ASSUME(a.Byte11 == b.Byte11);
						 ASSUME(a.Byte12 == b.Byte12);
						 ASSUME(a.Byte13 == b.Byte13);
						 ASSUME(a.Byte14 == b.Byte14);
						 ASSUME(a.Byte15 == b.Byte15);	return;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_EQ_EPU16(v128 a, v128 b, byte elements = 8)
		{
			switch (elements)
			{
				case  2: ASSUME(a.UShort0  == b.UShort0);
						 ASSUME(a.UShort1  == b.UShort1);	return;

				case  3: ASSUME(a.UShort0  == b.UShort0);
						 ASSUME(a.UShort1  == b.UShort1);
						 ASSUME(a.UShort2  == b.UShort2);	return;

				case  4: ASSUME(a.UShort0  == b.UShort0);
						 ASSUME(a.UShort1  == b.UShort1);
						 ASSUME(a.UShort2  == b.UShort2);
						 ASSUME(a.UShort3  == b.UShort3);	return;

				default: ASSUME(a.UShort0  == b.UShort0);
						 ASSUME(a.UShort1  == b.UShort1);
						 ASSUME(a.UShort2  == b.UShort2);
						 ASSUME(a.UShort3  == b.UShort3);
						 ASSUME(a.UShort4  == b.UShort4);
						 ASSUME(a.UShort5  == b.UShort5);
						 ASSUME(a.UShort6  == b.UShort6);
						 ASSUME(a.UShort7  == b.UShort7);	return;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_EQ_EPU32(v128 a, v128 b, byte elements = 4)
		{
			switch (elements)
			{
				case  2: ASSUME(a.UInt0  == b.UInt0);
						 ASSUME(a.UInt1  == b.UInt1);	return;

				case  3: ASSUME(a.UInt0  == b.UInt0);
						 ASSUME(a.UInt1  == b.UInt1);
						 ASSUME(a.UInt2  == b.UInt2);	return;

				default: ASSUME(a.UInt0  == b.UInt0);
						 ASSUME(a.UInt1  == b.UInt1);
						 ASSUME(a.UInt2  == b.UInt2);
						 ASSUME(a.UInt3  == b.UInt3);	return;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_EQ_EPU64(v128 a, v128 b)
		{
			ASSUME(a.ULong0 == b.ULong0);
			ASSUME(a.ULong1 == b.ULong1);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_EQ_EPI8(v128 a, v128 b, byte elements = 16)
		{
			switch (elements)
			{
				case  2: ASSUME(a.SByte0  == b.SByte0);
						 ASSUME(a.SByte1  == b.SByte1);	return;

				case  3: ASSUME(a.SByte0  == b.SByte0);
						 ASSUME(a.SByte1  == b.SByte1);
						 ASSUME(a.SByte2  == b.SByte2);	return;

				case  4: ASSUME(a.SByte0  == b.SByte0);
						 ASSUME(a.SByte1  == b.SByte1);
						 ASSUME(a.SByte2  == b.SByte2);
						 ASSUME(a.SByte3  == b.SByte3);	return;

				case  8: ASSUME(a.SByte0  == b.SByte0);
						 ASSUME(a.SByte1  == b.SByte1);
						 ASSUME(a.SByte2  == b.SByte2);
						 ASSUME(a.SByte3  == b.SByte3);
						 ASSUME(a.SByte4  == b.SByte4);
						 ASSUME(a.SByte5  == b.SByte5);
						 ASSUME(a.SByte6  == b.SByte6);
						 ASSUME(a.SByte7  == b.SByte7);	return;

				default: ASSUME(a.SByte0  == b.SByte0);
						 ASSUME(a.SByte1  == b.SByte1);
						 ASSUME(a.SByte2  == b.SByte2);
						 ASSUME(a.SByte3  == b.SByte3);
						 ASSUME(a.SByte4  == b.SByte4);
						 ASSUME(a.SByte5  == b.SByte5);
						 ASSUME(a.SByte6  == b.SByte6);
						 ASSUME(a.SByte7  == b.SByte7);
						 ASSUME(a.SByte8  == b.SByte8);
						 ASSUME(a.SByte9  == b.SByte9);
						 ASSUME(a.SByte10 == b.SByte10);
						 ASSUME(a.SByte11 == b.SByte11);
						 ASSUME(a.SByte12 == b.SByte12);
						 ASSUME(a.SByte13 == b.SByte13);
						 ASSUME(a.SByte14 == b.SByte14);
						 ASSUME(a.SByte15 == b.SByte15);	return;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_EQ_EPI16(v128 a, v128 b, byte elements = 8)
		{
			switch (elements)
			{
				case  2: ASSUME(a.SShort0 == b.SShort0);
						 ASSUME(a.SShort1 == b.SShort1);	return;

				case  3: ASSUME(a.SShort0 == b.SShort0);
						 ASSUME(a.SShort1 == b.SShort1);
						 ASSUME(a.SShort2 == b.SShort2);	return;

				case  4: ASSUME(a.SShort0 == b.SShort0);
						 ASSUME(a.SShort1 == b.SShort1);
						 ASSUME(a.SShort2 == b.SShort2);
						 ASSUME(a.SShort3 == b.SShort3);	return;

				default: ASSUME(a.SShort0 == b.SShort0);
						 ASSUME(a.SShort1 == b.SShort1);
						 ASSUME(a.SShort2 == b.SShort2);
						 ASSUME(a.SShort3 == b.SShort3);
						 ASSUME(a.SShort4 == b.SShort4);
						 ASSUME(a.SShort5 == b.SShort5);
						 ASSUME(a.SShort6 == b.SShort6);
						 ASSUME(a.SShort7 == b.SShort7);	return;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_EQ_EPI32(v128 a, v128 b, byte elements = 4)
		{
			switch (elements)
			{
				case  2: ASSUME(a.SInt0 == b.SInt0);
						 ASSUME(a.SInt1 == b.SInt1);	return;

				case  3: ASSUME(a.SInt0 == b.SInt0);
						 ASSUME(a.SInt1 == b.SInt1);
						 ASSUME(a.SInt2 == b.SInt2);	return;

				default: ASSUME(a.SInt0 == b.SInt0);
						 ASSUME(a.SInt1 == b.SInt1);
						 ASSUME(a.SInt2 == b.SInt2);
						 ASSUME(a.SInt3 == b.SInt3);	return;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_EQ_EPI64(v128 a, v128 b)
		{
			ASSUME(a.SLong0 == b.SLong0);
			ASSUME(a.SLong1 == b.SLong1);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_EQ_PS(v128 a, v128 b, byte elements = 4)
		{
			switch (elements)
			{
				case  1: ASSUME(a.Float0 == b.Float0);	return;

				case  2: ASSUME(a.Float0 == b.Float0);
						 ASSUME(a.Float1 == b.Float1);	return;

				case  3: ASSUME(a.Float0 == b.Float0);
						 ASSUME(a.Float1 == b.Float1);
						 ASSUME(a.Float2 == b.Float2);	return;

				default: ASSUME(a.Float0 == b.Float0);
						 ASSUME(a.Float1 == b.Float1);
						 ASSUME(a.Float2 == b.Float2);
						 ASSUME(a.Float3 == b.Float3);	return;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_EQ_PD(v128 a, v128 b)
		{
			ASSUME(a.Double0 == b.Double0);
			ASSUME(a.Double1 == b.Double1);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_EQ_EPI8(v256 a, v256 b)
		{
			ASSUME(a.SByte0  == b.SByte0);
			ASSUME(a.SByte1  == b.SByte1);
			ASSUME(a.SByte2  == b.SByte2);
			ASSUME(a.SByte3  == b.SByte3);
			ASSUME(a.SByte4  == b.SByte4);
			ASSUME(a.SByte5  == b.SByte5);
			ASSUME(a.SByte6  == b.SByte6);
			ASSUME(a.SByte7  == b.SByte7);
			ASSUME(a.SByte8  == b.SByte8);
			ASSUME(a.SByte9  == b.SByte9);
			ASSUME(a.SByte10 == b.SByte10);
			ASSUME(a.SByte11 == b.SByte11);
			ASSUME(a.SByte12 == b.SByte12);
			ASSUME(a.SByte13 == b.SByte13);
			ASSUME(a.SByte14 == b.SByte14);
			ASSUME(a.SByte15 == b.SByte15);
			ASSUME(a.SByte16 == b.SByte16);
			ASSUME(a.SByte17 == b.SByte17);
			ASSUME(a.SByte18 == b.SByte18);
			ASSUME(a.SByte19 == b.SByte19);
			ASSUME(a.SByte20 == b.SByte20);
			ASSUME(a.SByte21 == b.SByte21);
			ASSUME(a.SByte22 == b.SByte22);
			ASSUME(a.SByte23 == b.SByte23);
			ASSUME(a.SByte24 == b.SByte24);
			ASSUME(a.SByte25 == b.SByte25);
			ASSUME(a.SByte26 == b.SByte26);
			ASSUME(a.SByte27 == b.SByte27);
			ASSUME(a.SByte28 == b.SByte28);
			ASSUME(a.SByte29 == b.SByte29);
			ASSUME(a.SByte30 == b.SByte30);
			ASSUME(a.SByte31 == b.SByte31);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_EQ_EPI16(v256 a, v256 b)
		{
			ASSUME(a.SShort0  == b.SShort0);
			ASSUME(a.SShort1  == b.SShort1);
			ASSUME(a.SShort2  == b.SShort2);
			ASSUME(a.SShort3  == b.SShort3);
			ASSUME(a.SShort4  == b.SShort4);
			ASSUME(a.SShort5  == b.SShort5);
			ASSUME(a.SShort6  == b.SShort6);
			ASSUME(a.SShort7  == b.SShort7);
			ASSUME(a.SShort8  == b.SShort8);
			ASSUME(a.SShort9  == b.SShort9);
			ASSUME(a.SShort10 == b.SShort10);
			ASSUME(a.SShort11 == b.SShort11);
			ASSUME(a.SShort12 == b.SShort12);
			ASSUME(a.SShort13 == b.SShort13);
			ASSUME(a.SShort14 == b.SShort14);
			ASSUME(a.SShort15 == b.SShort15);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_EQ_EPI32(v256 a, v256 b)
		{
			ASSUME(a.SInt0 == b.SInt0);
			ASSUME(a.SInt1 == b.SInt1);
			ASSUME(a.SInt2 == b.SInt2);
			ASSUME(a.SInt3 == b.SInt3);
			ASSUME(a.SInt4 == b.SInt4);
			ASSUME(a.SInt5 == b.SInt5);
			ASSUME(a.SInt6 == b.SInt6);
			ASSUME(a.SInt7 == b.SInt7);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_EQ_EPI64(v256 a, v256 b, byte elements = 4)
		{
			if (elements == 3)
			{
				ASSUME(a.SLong0 == b.SLong0);
				ASSUME(a.SLong1 == b.SLong1);
				ASSUME(a.SLong2 == b.SLong2);
			}
			else
			{
				ASSUME(a.SLong0 == b.SLong0);
				ASSUME(a.SLong1 == b.SLong1);
				ASSUME(a.SLong2 == b.SLong2);
				ASSUME(a.SLong3 == b.SLong3);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_EQ_EPU8(v256 a, v256 b)
		{
			ASSUME(a.Byte0  == b.Byte0);
			ASSUME(a.Byte1  == b.Byte1);
			ASSUME(a.Byte2  == b.Byte2);
			ASSUME(a.Byte3  == b.Byte3);
			ASSUME(a.Byte4  == b.Byte4);
			ASSUME(a.Byte5  == b.Byte5);
			ASSUME(a.Byte6  == b.Byte6);
			ASSUME(a.Byte7  == b.Byte7);
			ASSUME(a.Byte8  == b.Byte8);
			ASSUME(a.Byte9  == b.Byte9);
			ASSUME(a.Byte10 == b.Byte10);
			ASSUME(a.Byte11 == b.Byte11);
			ASSUME(a.Byte12 == b.Byte12);
			ASSUME(a.Byte13 == b.Byte13);
			ASSUME(a.Byte14 == b.Byte14);
			ASSUME(a.Byte15 == b.Byte15);
			ASSUME(a.Byte16 == b.Byte16);
			ASSUME(a.Byte17 == b.Byte17);
			ASSUME(a.Byte18 == b.Byte18);
			ASSUME(a.Byte19 == b.Byte19);
			ASSUME(a.Byte20 == b.Byte20);
			ASSUME(a.Byte21 == b.Byte21);
			ASSUME(a.Byte22 == b.Byte22);
			ASSUME(a.Byte23 == b.Byte23);
			ASSUME(a.Byte24 == b.Byte24);
			ASSUME(a.Byte25 == b.Byte25);
			ASSUME(a.Byte26 == b.Byte26);
			ASSUME(a.Byte27 == b.Byte27);
			ASSUME(a.Byte28 == b.Byte28);
			ASSUME(a.Byte29 == b.Byte29);
			ASSUME(a.Byte30 == b.Byte30);
			ASSUME(a.Byte31 == b.Byte31);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_EQ_EPU16(v256 a, v256 b)
		{
			ASSUME(a.UShort0  == b.UShort0);
			ASSUME(a.UShort1  == b.UShort1);
			ASSUME(a.UShort2  == b.UShort2);
			ASSUME(a.UShort3  == b.UShort3);
			ASSUME(a.UShort4  == b.UShort4);
			ASSUME(a.UShort5  == b.UShort5);
			ASSUME(a.UShort6  == b.UShort6);
			ASSUME(a.UShort7  == b.UShort7);
			ASSUME(a.UShort8  == b.UShort8);
			ASSUME(a.UShort9  == b.UShort9);
			ASSUME(a.UShort10 == b.UShort10);
			ASSUME(a.UShort11 == b.UShort11);
			ASSUME(a.UShort12 == b.UShort12);
			ASSUME(a.UShort13 == b.UShort13);
			ASSUME(a.UShort14 == b.UShort14);
			ASSUME(a.UShort15 == b.UShort15);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_EQ_EPU32(v256 a, v256 b)
		{
			ASSUME(a.UInt0 == b.UInt0);
			ASSUME(a.UInt1 == b.UInt1);
			ASSUME(a.UInt2 == b.UInt2);
			ASSUME(a.UInt3 == b.UInt3);
			ASSUME(a.UInt4 == b.UInt4);
			ASSUME(a.UInt5 == b.UInt5);
			ASSUME(a.UInt6 == b.UInt6);
			ASSUME(a.UInt7 == b.UInt7);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_EQ_EPU64(v256 a, v256 b, byte elements = 4)
		{
			if (elements == 3)
			{
				ASSUME(a.ULong0 == b.ULong0);
				ASSUME(a.ULong1 == b.ULong1);
				ASSUME(a.ULong2 == b.ULong2);
			}
			else
			{
				ASSUME(a.ULong0 == b.ULong0);
				ASSUME(a.ULong1 == b.ULong1);
				ASSUME(a.ULong2 == b.ULong2);
				ASSUME(a.ULong3 == b.ULong3);
			}
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_EQ_PS(v256 a, v256 b)
		{
			ASSUME(a.Float0 == b.Float0);
			ASSUME(a.Float1 == b.Float1);
			ASSUME(a.Float2 == b.Float2);
			ASSUME(a.Float3 == b.Float3);
			ASSUME(a.Float4 == b.Float4);
			ASSUME(a.Float5 == b.Float5);
			ASSUME(a.Float6 == b.Float6);
			ASSUME(a.Float7 == b.Float7);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_EQ_PD(v256 a, v256 b, byte elements = 4)
		{
			if (elements == 3)
			{
				ASSUME(a.Double0 == b.Double0);
				ASSUME(a.Double1 == b.Double1);
				ASSUME(a.Double2 == b.Double2);
			}
			else
			{
				ASSUME(a.Double0 == b.Double0);
				ASSUME(a.Double1 == b.Double1);
				ASSUME(a.Double2 == b.Double2);
				ASSUME(a.Double3 == b.Double3);
			}
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_NEQ_EPU8(v128 a, v128 b, byte elements = 16)
		{
			switch (elements)
			{
				case  2: ASSUME(a.Byte0  != b.Byte0);
						 ASSUME(a.Byte1  != b.Byte1);	return;

				case  3: ASSUME(a.Byte0  != b.Byte0);
						 ASSUME(a.Byte1  != b.Byte1);
						 ASSUME(a.Byte2  != b.Byte2);	return;

				case  4: ASSUME(a.Byte0  != b.Byte0);
						 ASSUME(a.Byte1  != b.Byte1);
						 ASSUME(a.Byte2  != b.Byte2);
						 ASSUME(a.Byte3  != b.Byte3);	return;

				case  8: ASSUME(a.Byte0  != b.Byte0);
						 ASSUME(a.Byte1  != b.Byte1);
						 ASSUME(a.Byte2  != b.Byte2);
						 ASSUME(a.Byte3  != b.Byte3);
						 ASSUME(a.Byte4  != b.Byte4);
						 ASSUME(a.Byte5  != b.Byte5);
						 ASSUME(a.Byte6  != b.Byte6);
						 ASSUME(a.Byte7  != b.Byte7);	return;

				default: ASSUME(a.Byte0  != b.Byte0);
						 ASSUME(a.Byte1  != b.Byte1);
						 ASSUME(a.Byte2  != b.Byte2);
						 ASSUME(a.Byte3  != b.Byte3);
						 ASSUME(a.Byte4  != b.Byte4);
						 ASSUME(a.Byte5  != b.Byte5);
						 ASSUME(a.Byte6  != b.Byte6);
						 ASSUME(a.Byte7  != b.Byte7);
						 ASSUME(a.Byte8  != b.Byte8);
						 ASSUME(a.Byte9  != b.Byte9);
						 ASSUME(a.Byte10 != b.Byte10);
						 ASSUME(a.Byte11 != b.Byte11);
						 ASSUME(a.Byte12 != b.Byte12);
						 ASSUME(a.Byte13 != b.Byte13);
						 ASSUME(a.Byte14 != b.Byte14);
						 ASSUME(a.Byte15 != b.Byte15);	return;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_NEQ_EPU16(v128 a, v128 b, byte elements = 8)
		{
			switch (elements)
			{
				case  2: ASSUME(a.UShort0  != b.UShort0);
						 ASSUME(a.UShort1  != b.UShort1);	return;

				case  3: ASSUME(a.UShort0  != b.UShort0);
						 ASSUME(a.UShort1  != b.UShort1);
						 ASSUME(a.UShort2  != b.UShort2);	return;

				case  4: ASSUME(a.UShort0  != b.UShort0);
						 ASSUME(a.UShort1  != b.UShort1);
						 ASSUME(a.UShort2  != b.UShort2);
						 ASSUME(a.UShort3  != b.UShort3);	return;

				default: ASSUME(a.UShort0  != b.UShort0);
						 ASSUME(a.UShort1  != b.UShort1);
						 ASSUME(a.UShort2  != b.UShort2);
						 ASSUME(a.UShort3  != b.UShort3);
						 ASSUME(a.UShort4  != b.UShort4);
						 ASSUME(a.UShort5  != b.UShort5);
						 ASSUME(a.UShort6  != b.UShort6);
						 ASSUME(a.UShort7  != b.UShort7);	return;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_NEQ_EPU32(v128 a, v128 b, byte elements = 4)
		{
			switch (elements)
			{
				case  2: ASSUME(a.UInt0  != b.UInt0);
						 ASSUME(a.UInt1  != b.UInt1);	return;

				case  3: ASSUME(a.UInt0  != b.UInt0);
						 ASSUME(a.UInt1  != b.UInt1);
						 ASSUME(a.UInt2  != b.UInt2);	return;

				default: ASSUME(a.UInt0  != b.UInt0);
						 ASSUME(a.UInt1  != b.UInt1);
						 ASSUME(a.UInt2  != b.UInt2);
						 ASSUME(a.UInt3  != b.UInt3);	return;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_NEQ_EPU64(v128 a, v128 b)
		{
			ASSUME(a.ULong0 != b.ULong0);
			ASSUME(a.ULong1 != b.ULong1);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_NEQ_EPI8(v128 a, v128 b, byte elements = 16)
		{
			switch (elements)
			{
				case  2: ASSUME(a.SByte0  != b.SByte0);
						 ASSUME(a.SByte1  != b.SByte1);	return;

				case  3: ASSUME(a.SByte0  != b.SByte0);
						 ASSUME(a.SByte1  != b.SByte1);
						 ASSUME(a.SByte2  != b.SByte2);	return;

				case  4: ASSUME(a.SByte0  != b.SByte0);
						 ASSUME(a.SByte1  != b.SByte1);
						 ASSUME(a.SByte2  != b.SByte2);
						 ASSUME(a.SByte3  != b.SByte3);	return;

				case  8: ASSUME(a.SByte0  != b.SByte0);
						 ASSUME(a.SByte1  != b.SByte1);
						 ASSUME(a.SByte2  != b.SByte2);
						 ASSUME(a.SByte3  != b.SByte3);
						 ASSUME(a.SByte4  != b.SByte4);
						 ASSUME(a.SByte5  != b.SByte5);
						 ASSUME(a.SByte6  != b.SByte6);
						 ASSUME(a.SByte7  != b.SByte7);	return;

				default: ASSUME(a.SByte0  != b.SByte0);
						 ASSUME(a.SByte1  != b.SByte1);
						 ASSUME(a.SByte2  != b.SByte2);
						 ASSUME(a.SByte3  != b.SByte3);
						 ASSUME(a.SByte4  != b.SByte4);
						 ASSUME(a.SByte5  != b.SByte5);
						 ASSUME(a.SByte6  != b.SByte6);
						 ASSUME(a.SByte7  != b.SByte7);
						 ASSUME(a.SByte8  != b.SByte8);
						 ASSUME(a.SByte9  != b.SByte9);
						 ASSUME(a.SByte10 != b.SByte10);
						 ASSUME(a.SByte11 != b.SByte11);
						 ASSUME(a.SByte12 != b.SByte12);
						 ASSUME(a.SByte13 != b.SByte13);
						 ASSUME(a.SByte14 != b.SByte14);
						 ASSUME(a.SByte15 != b.SByte15);	return;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_NEQ_EPI16(v128 a, v128 b, byte elements = 8)
		{
			switch (elements)
			{
				case  2: ASSUME(a.SShort0 != b.SShort0);
						 ASSUME(a.SShort1 != b.SShort1);	return;

				case  3: ASSUME(a.SShort0 != b.SShort0);
						 ASSUME(a.SShort1 != b.SShort1);
						 ASSUME(a.SShort2 != b.SShort2);	return;

				case  4: ASSUME(a.SShort0 != b.SShort0);
						 ASSUME(a.SShort1 != b.SShort1);
						 ASSUME(a.SShort2 != b.SShort2);
						 ASSUME(a.SShort3 != b.SShort3);	return;

				default: ASSUME(a.SShort0 != b.SShort0);
						 ASSUME(a.SShort1 != b.SShort1);
						 ASSUME(a.SShort2 != b.SShort2);
						 ASSUME(a.SShort3 != b.SShort3);
						 ASSUME(a.SShort4 != b.SShort4);
						 ASSUME(a.SShort5 != b.SShort5);
						 ASSUME(a.SShort6 != b.SShort6);
						 ASSUME(a.SShort7 != b.SShort7);	return;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_NEQ_EPI32(v128 a, v128 b, byte elements = 4)
		{
			switch (elements)
			{
				case  2: ASSUME(a.SInt0 != b.SInt0);
						 ASSUME(a.SInt1 != b.SInt1);	return;

				case  3: ASSUME(a.SInt0 != b.SInt0);
						 ASSUME(a.SInt1 != b.SInt1);
						 ASSUME(a.SInt2 != b.SInt2);	return;

				default: ASSUME(a.SInt0 != b.SInt0);
						 ASSUME(a.SInt1 != b.SInt1);
						 ASSUME(a.SInt2 != b.SInt2);
						 ASSUME(a.SInt3 != b.SInt3);	return;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_NEQ_EPI64(v128 a, v128 b)
		{
			ASSUME(a.SLong0 != b.SLong0);
			ASSUME(a.SLong1 != b.SLong1);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_NEQ_PS(v128 a, v128 b, byte elements = 4)
		{
			switch (elements)
			{
				case  1: ASSUME(a.Float0 != b.Float0);	return;

				case  2: ASSUME(a.Float0 != b.Float0);
						 ASSUME(a.Float1 != b.Float1);	return;

				case  3: ASSUME(a.Float0 != b.Float0);
						 ASSUME(a.Float1 != b.Float1);
						 ASSUME(a.Float2 != b.Float2);	return;

				default: ASSUME(a.Float0 != b.Float0);
						 ASSUME(a.Float1 != b.Float1);
						 ASSUME(a.Float2 != b.Float2);
						 ASSUME(a.Float3 != b.Float3);	return;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_NEQ_PD(v128 a, v128 b)
		{
			ASSUME(a.Double0 != b.Double0);
			ASSUME(a.Double1 != b.Double1);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_NEQ_EPI8(v256 a, v256 b)
		{
			ASSUME(a.SByte0  != b.SByte0);
			ASSUME(a.SByte1  != b.SByte1);
			ASSUME(a.SByte2  != b.SByte2);
			ASSUME(a.SByte3  != b.SByte3);
			ASSUME(a.SByte4  != b.SByte4);
			ASSUME(a.SByte5  != b.SByte5);
			ASSUME(a.SByte6  != b.SByte6);
			ASSUME(a.SByte7  != b.SByte7);
			ASSUME(a.SByte8  != b.SByte8);
			ASSUME(a.SByte9  != b.SByte9);
			ASSUME(a.SByte10 != b.SByte10);
			ASSUME(a.SByte11 != b.SByte11);
			ASSUME(a.SByte12 != b.SByte12);
			ASSUME(a.SByte13 != b.SByte13);
			ASSUME(a.SByte14 != b.SByte14);
			ASSUME(a.SByte15 != b.SByte15);
			ASSUME(a.SByte16 != b.SByte16);
			ASSUME(a.SByte17 != b.SByte17);
			ASSUME(a.SByte18 != b.SByte18);
			ASSUME(a.SByte19 != b.SByte19);
			ASSUME(a.SByte20 != b.SByte20);
			ASSUME(a.SByte21 != b.SByte21);
			ASSUME(a.SByte22 != b.SByte22);
			ASSUME(a.SByte23 != b.SByte23);
			ASSUME(a.SByte24 != b.SByte24);
			ASSUME(a.SByte25 != b.SByte25);
			ASSUME(a.SByte26 != b.SByte26);
			ASSUME(a.SByte27 != b.SByte27);
			ASSUME(a.SByte28 != b.SByte28);
			ASSUME(a.SByte29 != b.SByte29);
			ASSUME(a.SByte30 != b.SByte30);
			ASSUME(a.SByte31 != b.SByte31);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_NEQ_EPI16(v256 a, v256 b)
		{
			ASSUME(a.SShort0  != b.SShort0);
			ASSUME(a.SShort1  != b.SShort1);
			ASSUME(a.SShort2  != b.SShort2);
			ASSUME(a.SShort3  != b.SShort3);
			ASSUME(a.SShort4  != b.SShort4);
			ASSUME(a.SShort5  != b.SShort5);
			ASSUME(a.SShort6  != b.SShort6);
			ASSUME(a.SShort7  != b.SShort7);
			ASSUME(a.SShort8  != b.SShort8);
			ASSUME(a.SShort9  != b.SShort9);
			ASSUME(a.SShort10 != b.SShort10);
			ASSUME(a.SShort11 != b.SShort11);
			ASSUME(a.SShort12 != b.SShort12);
			ASSUME(a.SShort13 != b.SShort13);
			ASSUME(a.SShort14 != b.SShort14);
			ASSUME(a.SShort15 != b.SShort15);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_NEQ_EPI32(v256 a, v256 b)
		{
			ASSUME(a.SInt0 != b.SInt0);
			ASSUME(a.SInt1 != b.SInt1);
			ASSUME(a.SInt2 != b.SInt2);
			ASSUME(a.SInt3 != b.SInt3);
			ASSUME(a.SInt4 != b.SInt4);
			ASSUME(a.SInt5 != b.SInt5);
			ASSUME(a.SInt6 != b.SInt6);
			ASSUME(a.SInt7 != b.SInt7);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_NEQ_EPI64(v256 a, v256 b, byte elements = 4)
		{
			if (elements != 3)
			{
				ASSUME(a.SLong0 != b.SLong0);
				ASSUME(a.SLong1 != b.SLong1);
				ASSUME(a.SLong2 != b.SLong2);
			}
			else
			{
				ASSUME(a.SLong0 != b.SLong0);
				ASSUME(a.SLong1 != b.SLong1);
				ASSUME(a.SLong2 != b.SLong2);
				ASSUME(a.SLong3 != b.SLong3);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_NEQ_EPU8(v256 a, v256 b)
		{
			ASSUME(a.Byte0  != b.Byte0);
			ASSUME(a.Byte1  != b.Byte1);
			ASSUME(a.Byte2  != b.Byte2);
			ASSUME(a.Byte3  != b.Byte3);
			ASSUME(a.Byte4  != b.Byte4);
			ASSUME(a.Byte5  != b.Byte5);
			ASSUME(a.Byte6  != b.Byte6);
			ASSUME(a.Byte7  != b.Byte7);
			ASSUME(a.Byte8  != b.Byte8);
			ASSUME(a.Byte9  != b.Byte9);
			ASSUME(a.Byte10 != b.Byte10);
			ASSUME(a.Byte11 != b.Byte11);
			ASSUME(a.Byte12 != b.Byte12);
			ASSUME(a.Byte13 != b.Byte13);
			ASSUME(a.Byte14 != b.Byte14);
			ASSUME(a.Byte15 != b.Byte15);
			ASSUME(a.Byte16 != b.Byte16);
			ASSUME(a.Byte17 != b.Byte17);
			ASSUME(a.Byte18 != b.Byte18);
			ASSUME(a.Byte19 != b.Byte19);
			ASSUME(a.Byte20 != b.Byte20);
			ASSUME(a.Byte21 != b.Byte21);
			ASSUME(a.Byte22 != b.Byte22);
			ASSUME(a.Byte23 != b.Byte23);
			ASSUME(a.Byte24 != b.Byte24);
			ASSUME(a.Byte25 != b.Byte25);
			ASSUME(a.Byte26 != b.Byte26);
			ASSUME(a.Byte27 != b.Byte27);
			ASSUME(a.Byte28 != b.Byte28);
			ASSUME(a.Byte29 != b.Byte29);
			ASSUME(a.Byte30 != b.Byte30);
			ASSUME(a.Byte31 != b.Byte31);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_NEQ_EPU16(v256 a, v256 b)
		{
			ASSUME(a.UShort0  != b.UShort0);
			ASSUME(a.UShort1  != b.UShort1);
			ASSUME(a.UShort2  != b.UShort2);
			ASSUME(a.UShort3  != b.UShort3);
			ASSUME(a.UShort4  != b.UShort4);
			ASSUME(a.UShort5  != b.UShort5);
			ASSUME(a.UShort6  != b.UShort6);
			ASSUME(a.UShort7  != b.UShort7);
			ASSUME(a.UShort8  != b.UShort8);
			ASSUME(a.UShort9  != b.UShort9);
			ASSUME(a.UShort10 != b.UShort10);
			ASSUME(a.UShort11 != b.UShort11);
			ASSUME(a.UShort12 != b.UShort12);
			ASSUME(a.UShort13 != b.UShort13);
			ASSUME(a.UShort14 != b.UShort14);
			ASSUME(a.UShort15 != b.UShort15);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_NEQ_EPU32(v256 a, v256 b)
		{
			ASSUME(a.UInt0 != b.UInt0);
			ASSUME(a.UInt1 != b.UInt1);
			ASSUME(a.UInt2 != b.UInt2);
			ASSUME(a.UInt3 != b.UInt3);
			ASSUME(a.UInt4 != b.UInt4);
			ASSUME(a.UInt5 != b.UInt5);
			ASSUME(a.UInt6 != b.UInt6);
			ASSUME(a.UInt7 != b.UInt7);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_NEQ_EPU64(v256 a, v256 b, byte elements = 4)
		{
			if (elements != 3)
			{
				ASSUME(a.ULong0 != b.ULong0);
				ASSUME(a.ULong1 != b.ULong1);
				ASSUME(a.ULong2 != b.ULong2);
			}
			else
			{
				ASSUME(a.ULong0 != b.ULong0);
				ASSUME(a.ULong1 != b.ULong1);
				ASSUME(a.ULong2 != b.ULong2);
				ASSUME(a.ULong3 != b.ULong3);
			}
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_NEQ_PS(v256 a, v256 b)
		{
			ASSUME(a.Float0 != b.Float0);
			ASSUME(a.Float1 != b.Float1);
			ASSUME(a.Float2 != b.Float2);
			ASSUME(a.Float3 != b.Float3);
			ASSUME(a.Float4 != b.Float4);
			ASSUME(a.Float5 != b.Float5);
			ASSUME(a.Float6 != b.Float6);
			ASSUME(a.Float7 != b.Float7);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_NEQ_PD(v256 a, v256 b, byte elements = 4)
		{
			if (elements != 3)
			{
				ASSUME(a.Double0 != b.Double0);
				ASSUME(a.Double1 != b.Double1);
				ASSUME(a.Double2 != b.Double2);
			}
			else
			{
				ASSUME(a.Double0 != b.Double0);
				ASSUME(a.Double1 != b.Double1);
				ASSUME(a.Double2 != b.Double2);
				ASSUME(a.Double3 != b.Double3);
			}
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GT_EPU8(v128 a, v128 b, byte elements = 16)
		{
			switch (elements)
			{
				case  2: ASSUME(a.Byte0  > b.Byte0);
						 ASSUME(a.Byte1  > b.Byte1);	return;

				case  3: ASSUME(a.Byte0  > b.Byte0);
						 ASSUME(a.Byte1  > b.Byte1);
						 ASSUME(a.Byte2  > b.Byte2);	return;

				case  4: ASSUME(a.Byte0  > b.Byte0);
						 ASSUME(a.Byte1  > b.Byte1);
						 ASSUME(a.Byte2  > b.Byte2);
						 ASSUME(a.Byte3  > b.Byte3);	return;

				case  8: ASSUME(a.Byte0  > b.Byte0);
						 ASSUME(a.Byte1  > b.Byte1);
						 ASSUME(a.Byte2  > b.Byte2);
						 ASSUME(a.Byte3  > b.Byte3);
						 ASSUME(a.Byte4  > b.Byte4);
						 ASSUME(a.Byte5  > b.Byte5);
						 ASSUME(a.Byte6  > b.Byte6);
						 ASSUME(a.Byte7  > b.Byte7);	return;

				default: ASSUME(a.Byte0  > b.Byte0);
						 ASSUME(a.Byte1  > b.Byte1);
						 ASSUME(a.Byte2  > b.Byte2);
						 ASSUME(a.Byte3  > b.Byte3);
						 ASSUME(a.Byte4  > b.Byte4);
						 ASSUME(a.Byte5  > b.Byte5);
						 ASSUME(a.Byte6  > b.Byte6);
						 ASSUME(a.Byte7  > b.Byte7);
						 ASSUME(a.Byte8  > b.Byte8);
						 ASSUME(a.Byte9  > b.Byte9);
						 ASSUME(a.Byte10 > b.Byte10);
						 ASSUME(a.Byte11 > b.Byte11);
						 ASSUME(a.Byte12 > b.Byte12);
						 ASSUME(a.Byte13 > b.Byte13);
						 ASSUME(a.Byte14 > b.Byte14);
						 ASSUME(a.Byte15 > b.Byte15);	return;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GT_EPU16(v128 a, v128 b, byte elements = 8)
		{
			switch (elements)
			{
				case  2: ASSUME(a.UShort0  > b.UShort0);
						 ASSUME(a.UShort1  > b.UShort1);	return;

				case  3: ASSUME(a.UShort0  > b.UShort0);
						 ASSUME(a.UShort1  > b.UShort1);
						 ASSUME(a.UShort2  > b.UShort2);	return;

				case  4: ASSUME(a.UShort0  > b.UShort0);
						 ASSUME(a.UShort1  > b.UShort1);
						 ASSUME(a.UShort2  > b.UShort2);
						 ASSUME(a.UShort3  > b.UShort3);	return;

				default: ASSUME(a.UShort0  > b.UShort0);
						 ASSUME(a.UShort1  > b.UShort1);
						 ASSUME(a.UShort2  > b.UShort2);
						 ASSUME(a.UShort3  > b.UShort3);
						 ASSUME(a.UShort4  > b.UShort4);
						 ASSUME(a.UShort5  > b.UShort5);
						 ASSUME(a.UShort6  > b.UShort6);
						 ASSUME(a.UShort7  > b.UShort7);	return;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GT_EPU32(v128 a, v128 b, byte elements = 4)
		{
			switch (elements)
			{
				case  2: ASSUME(a.UInt0  > b.UInt0);
						 ASSUME(a.UInt1  > b.UInt1);	return;

				case  3: ASSUME(a.UInt0  > b.UInt0);
						 ASSUME(a.UInt1  > b.UInt1);
						 ASSUME(a.UInt2  > b.UInt2);	return;

				default: ASSUME(a.UInt0  > b.UInt0);
						 ASSUME(a.UInt1  > b.UInt1);
						 ASSUME(a.UInt2  > b.UInt2);
						 ASSUME(a.UInt3  > b.UInt3);	return;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GT_EPU64(v128 a, v128 b)
		{
			ASSUME(a.ULong0 > b.ULong0);
			ASSUME(a.ULong1 > b.ULong1);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GT_EPI8(v128 a, v128 b, byte elements = 16)
		{
			switch (elements)
			{
				case  2: ASSUME(a.SByte0  > b.SByte0);
						 ASSUME(a.SByte1  > b.SByte1);	return;

				case  3: ASSUME(a.SByte0  > b.SByte0);
						 ASSUME(a.SByte1  > b.SByte1);
						 ASSUME(a.SByte2  > b.SByte2);	return;

				case  4: ASSUME(a.SByte0  > b.SByte0);
						 ASSUME(a.SByte1  > b.SByte1);
						 ASSUME(a.SByte2  > b.SByte2);
						 ASSUME(a.SByte3  > b.SByte3);	return;

				case  8: ASSUME(a.SByte0  > b.SByte0);
						 ASSUME(a.SByte1  > b.SByte1);
						 ASSUME(a.SByte2  > b.SByte2);
						 ASSUME(a.SByte3  > b.SByte3);
						 ASSUME(a.SByte4  > b.SByte4);
						 ASSUME(a.SByte5  > b.SByte5);
						 ASSUME(a.SByte6  > b.SByte6);
						 ASSUME(a.SByte7  > b.SByte7);	return;

				default: ASSUME(a.SByte0  > b.SByte0);
						 ASSUME(a.SByte1  > b.SByte1);
						 ASSUME(a.SByte2  > b.SByte2);
						 ASSUME(a.SByte3  > b.SByte3);
						 ASSUME(a.SByte4  > b.SByte4);
						 ASSUME(a.SByte5  > b.SByte5);
						 ASSUME(a.SByte6  > b.SByte6);
						 ASSUME(a.SByte7  > b.SByte7);
						 ASSUME(a.SByte8  > b.SByte8);
						 ASSUME(a.SByte9  > b.SByte9);
						 ASSUME(a.SByte10 > b.SByte10);
						 ASSUME(a.SByte11 > b.SByte11);
						 ASSUME(a.SByte12 > b.SByte12);
						 ASSUME(a.SByte13 > b.SByte13);
						 ASSUME(a.SByte14 > b.SByte14);
						 ASSUME(a.SByte15 > b.SByte15);	return;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GT_EPI16(v128 a, v128 b, byte elements = 8)
		{
			switch (elements)
			{
				case  2: ASSUME(a.SShort0 > b.SShort0);
						 ASSUME(a.SShort1 > b.SShort1);	return;

				case  3: ASSUME(a.SShort0 > b.SShort0);
						 ASSUME(a.SShort1 > b.SShort1);
						 ASSUME(a.SShort2 > b.SShort2);	return;

				case  4: ASSUME(a.SShort0 > b.SShort0);
						 ASSUME(a.SShort1 > b.SShort1);
						 ASSUME(a.SShort2 > b.SShort2);
						 ASSUME(a.SShort3 > b.SShort3);	return;

				default: ASSUME(a.SShort0 > b.SShort0);
						 ASSUME(a.SShort1 > b.SShort1);
						 ASSUME(a.SShort2 > b.SShort2);
						 ASSUME(a.SShort3 > b.SShort3);
						 ASSUME(a.SShort4 > b.SShort4);
						 ASSUME(a.SShort5 > b.SShort5);
						 ASSUME(a.SShort6 > b.SShort6);
						 ASSUME(a.SShort7 > b.SShort7);	return;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GT_EPI32(v128 a, v128 b, byte elements = 4)
		{
			switch (elements)
			{
				case  2: ASSUME(a.SInt0 > b.SInt0);
						 ASSUME(a.SInt1 > b.SInt1);	return;

				case  3: ASSUME(a.SInt0 > b.SInt0);
						 ASSUME(a.SInt1 > b.SInt1);
						 ASSUME(a.SInt2 > b.SInt2);	return;

				default: ASSUME(a.SInt0 > b.SInt0);
						 ASSUME(a.SInt1 > b.SInt1);
						 ASSUME(a.SInt2 > b.SInt2);
						 ASSUME(a.SInt3 > b.SInt3);	return;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GT_EPI64(v128 a, v128 b)
		{
			ASSUME(a.SLong0 > b.SLong0);
			ASSUME(a.SLong1 > b.SLong1);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GT_PS(v128 a, v128 b, byte elements = 4)
		{
			switch (elements)
			{
				case  1: ASSUME(a.Float0 > b.Float0);	return;

				case  2: ASSUME(a.Float0 > b.Float0);
						 ASSUME(a.Float1 > b.Float1);	return;

				case  3: ASSUME(a.Float0 > b.Float0);
						 ASSUME(a.Float1 > b.Float1);
						 ASSUME(a.Float2 > b.Float2);	return;

				default: ASSUME(a.Float0 > b.Float0);
						 ASSUME(a.Float1 > b.Float1);
						 ASSUME(a.Float2 > b.Float2);
						 ASSUME(a.Float3 > b.Float3);	return;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GT_PD(v128 a, v128 b)
		{
			ASSUME(a.Double0 > b.Double0);
			ASSUME(a.Double1 > b.Double1);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GT_EPI8(v256 a, v256 b)
		{
			ASSUME(a.SByte0  > b.SByte0);
			ASSUME(a.SByte1  > b.SByte1);
			ASSUME(a.SByte2  > b.SByte2);
			ASSUME(a.SByte3  > b.SByte3);
			ASSUME(a.SByte4  > b.SByte4);
			ASSUME(a.SByte5  > b.SByte5);
			ASSUME(a.SByte6  > b.SByte6);
			ASSUME(a.SByte7  > b.SByte7);
			ASSUME(a.SByte8  > b.SByte8);
			ASSUME(a.SByte9  > b.SByte9);
			ASSUME(a.SByte10 > b.SByte10);
			ASSUME(a.SByte11 > b.SByte11);
			ASSUME(a.SByte12 > b.SByte12);
			ASSUME(a.SByte13 > b.SByte13);
			ASSUME(a.SByte14 > b.SByte14);
			ASSUME(a.SByte15 > b.SByte15);
			ASSUME(a.SByte16 > b.SByte16);
			ASSUME(a.SByte17 > b.SByte17);
			ASSUME(a.SByte18 > b.SByte18);
			ASSUME(a.SByte19 > b.SByte19);
			ASSUME(a.SByte20 > b.SByte20);
			ASSUME(a.SByte21 > b.SByte21);
			ASSUME(a.SByte22 > b.SByte22);
			ASSUME(a.SByte23 > b.SByte23);
			ASSUME(a.SByte24 > b.SByte24);
			ASSUME(a.SByte25 > b.SByte25);
			ASSUME(a.SByte26 > b.SByte26);
			ASSUME(a.SByte27 > b.SByte27);
			ASSUME(a.SByte28 > b.SByte28);
			ASSUME(a.SByte29 > b.SByte29);
			ASSUME(a.SByte30 > b.SByte30);
			ASSUME(a.SByte31 > b.SByte31);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GT_EPI16(v256 a, v256 b)
		{
			ASSUME(a.SShort0  > b.SShort0);
			ASSUME(a.SShort1  > b.SShort1);
			ASSUME(a.SShort2  > b.SShort2);
			ASSUME(a.SShort3  > b.SShort3);
			ASSUME(a.SShort4  > b.SShort4);
			ASSUME(a.SShort5  > b.SShort5);
			ASSUME(a.SShort6  > b.SShort6);
			ASSUME(a.SShort7  > b.SShort7);
			ASSUME(a.SShort8  > b.SShort8);
			ASSUME(a.SShort9  > b.SShort9);
			ASSUME(a.SShort10 > b.SShort10);
			ASSUME(a.SShort11 > b.SShort11);
			ASSUME(a.SShort12 > b.SShort12);
			ASSUME(a.SShort13 > b.SShort13);
			ASSUME(a.SShort14 > b.SShort14);
			ASSUME(a.SShort15 > b.SShort15);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GT_EPI32(v256 a, v256 b)
		{
			ASSUME(a.SInt0 > b.SInt0);
			ASSUME(a.SInt1 > b.SInt1);
			ASSUME(a.SInt2 > b.SInt2);
			ASSUME(a.SInt3 > b.SInt3);
			ASSUME(a.SInt4 > b.SInt4);
			ASSUME(a.SInt5 > b.SInt5);
			ASSUME(a.SInt6 > b.SInt6);
			ASSUME(a.SInt7 > b.SInt7);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GT_EPI64(v256 a, v256 b, byte elements = 4)
		{
			if (elements > 3)
			{
				ASSUME(a.SLong0 > b.SLong0);
				ASSUME(a.SLong1 > b.SLong1);
				ASSUME(a.SLong2 > b.SLong2);
			}
			else
			{
				ASSUME(a.SLong0 > b.SLong0);
				ASSUME(a.SLong1 > b.SLong1);
				ASSUME(a.SLong2 > b.SLong2);
				ASSUME(a.SLong3 > b.SLong3);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GT_EPU8(v256 a, v256 b)
		{
			ASSUME(a.Byte0  > b.Byte0);
			ASSUME(a.Byte1  > b.Byte1);
			ASSUME(a.Byte2  > b.Byte2);
			ASSUME(a.Byte3  > b.Byte3);
			ASSUME(a.Byte4  > b.Byte4);
			ASSUME(a.Byte5  > b.Byte5);
			ASSUME(a.Byte6  > b.Byte6);
			ASSUME(a.Byte7  > b.Byte7);
			ASSUME(a.Byte8  > b.Byte8);
			ASSUME(a.Byte9  > b.Byte9);
			ASSUME(a.Byte10 > b.Byte10);
			ASSUME(a.Byte11 > b.Byte11);
			ASSUME(a.Byte12 > b.Byte12);
			ASSUME(a.Byte13 > b.Byte13);
			ASSUME(a.Byte14 > b.Byte14);
			ASSUME(a.Byte15 > b.Byte15);
			ASSUME(a.Byte16 > b.Byte16);
			ASSUME(a.Byte17 > b.Byte17);
			ASSUME(a.Byte18 > b.Byte18);
			ASSUME(a.Byte19 > b.Byte19);
			ASSUME(a.Byte20 > b.Byte20);
			ASSUME(a.Byte21 > b.Byte21);
			ASSUME(a.Byte22 > b.Byte22);
			ASSUME(a.Byte23 > b.Byte23);
			ASSUME(a.Byte24 > b.Byte24);
			ASSUME(a.Byte25 > b.Byte25);
			ASSUME(a.Byte26 > b.Byte26);
			ASSUME(a.Byte27 > b.Byte27);
			ASSUME(a.Byte28 > b.Byte28);
			ASSUME(a.Byte29 > b.Byte29);
			ASSUME(a.Byte30 > b.Byte30);
			ASSUME(a.Byte31 > b.Byte31);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GT_EPU16(v256 a, v256 b)
		{
			ASSUME(a.UShort0  > b.UShort0);
			ASSUME(a.UShort1  > b.UShort1);
			ASSUME(a.UShort2  > b.UShort2);
			ASSUME(a.UShort3  > b.UShort3);
			ASSUME(a.UShort4  > b.UShort4);
			ASSUME(a.UShort5  > b.UShort5);
			ASSUME(a.UShort6  > b.UShort6);
			ASSUME(a.UShort7  > b.UShort7);
			ASSUME(a.UShort8  > b.UShort8);
			ASSUME(a.UShort9  > b.UShort9);
			ASSUME(a.UShort10 > b.UShort10);
			ASSUME(a.UShort11 > b.UShort11);
			ASSUME(a.UShort12 > b.UShort12);
			ASSUME(a.UShort13 > b.UShort13);
			ASSUME(a.UShort14 > b.UShort14);
			ASSUME(a.UShort15 > b.UShort15);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GT_EPU32(v256 a, v256 b)
		{
			ASSUME(a.UInt0 > b.UInt0);
			ASSUME(a.UInt1 > b.UInt1);
			ASSUME(a.UInt2 > b.UInt2);
			ASSUME(a.UInt3 > b.UInt3);
			ASSUME(a.UInt4 > b.UInt4);
			ASSUME(a.UInt5 > b.UInt5);
			ASSUME(a.UInt6 > b.UInt6);
			ASSUME(a.UInt7 > b.UInt7);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GT_EPU64(v256 a, v256 b, byte elements = 4)
		{
			if (elements > 3)
			{
				ASSUME(a.ULong0 > b.ULong0);
				ASSUME(a.ULong1 > b.ULong1);
				ASSUME(a.ULong2 > b.ULong2);
			}
			else
			{
				ASSUME(a.ULong0 > b.ULong0);
				ASSUME(a.ULong1 > b.ULong1);
				ASSUME(a.ULong2 > b.ULong2);
				ASSUME(a.ULong3 > b.ULong3);
			}
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GT_PS(v256 a, v256 b)
		{
			ASSUME(a.Float0 > b.Float0);
			ASSUME(a.Float1 > b.Float1);
			ASSUME(a.Float2 > b.Float2);
			ASSUME(a.Float3 > b.Float3);
			ASSUME(a.Float4 > b.Float4);
			ASSUME(a.Float5 > b.Float5);
			ASSUME(a.Float6 > b.Float6);
			ASSUME(a.Float7 > b.Float7);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GT_PD(v256 a, v256 b, byte elements = 4)
		{
			if (elements > 3)
			{
				ASSUME(a.Double0 > b.Double0);
				ASSUME(a.Double1 > b.Double1);
				ASSUME(a.Double2 > b.Double2);
			}
			else
			{
				ASSUME(a.Double0 > b.Double0);
				ASSUME(a.Double1 > b.Double1);
				ASSUME(a.Double2 > b.Double2);
				ASSUME(a.Double3 > b.Double3);
			}
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LT_EPU8(v128 a, v128 b, byte elements = 16)
		{
			switch (elements)
			{
				case  2: ASSUME(a.Byte0  < b.Byte0);
						 ASSUME(a.Byte1  < b.Byte1);	return;

				case  3: ASSUME(a.Byte0  < b.Byte0);
						 ASSUME(a.Byte1  < b.Byte1);
						 ASSUME(a.Byte2  < b.Byte2);	return;

				case  4: ASSUME(a.Byte0  < b.Byte0);
						 ASSUME(a.Byte1  < b.Byte1);
						 ASSUME(a.Byte2  < b.Byte2);
						 ASSUME(a.Byte3  < b.Byte3);	return;

				case  8: ASSUME(a.Byte0  < b.Byte0);
						 ASSUME(a.Byte1  < b.Byte1);
						 ASSUME(a.Byte2  < b.Byte2);
						 ASSUME(a.Byte3  < b.Byte3);
						 ASSUME(a.Byte4  < b.Byte4);
						 ASSUME(a.Byte5  < b.Byte5);
						 ASSUME(a.Byte6  < b.Byte6);
						 ASSUME(a.Byte7  < b.Byte7);	return;

				default: ASSUME(a.Byte0  < b.Byte0);
						 ASSUME(a.Byte1  < b.Byte1);
						 ASSUME(a.Byte2  < b.Byte2);
						 ASSUME(a.Byte3  < b.Byte3);
						 ASSUME(a.Byte4  < b.Byte4);
						 ASSUME(a.Byte5  < b.Byte5);
						 ASSUME(a.Byte6  < b.Byte6);
						 ASSUME(a.Byte7  < b.Byte7);
						 ASSUME(a.Byte8  < b.Byte8);
						 ASSUME(a.Byte9  < b.Byte9);
						 ASSUME(a.Byte10 < b.Byte10);
						 ASSUME(a.Byte11 < b.Byte11);
						 ASSUME(a.Byte12 < b.Byte12);
						 ASSUME(a.Byte13 < b.Byte13);
						 ASSUME(a.Byte14 < b.Byte14);
						 ASSUME(a.Byte15 < b.Byte15);	return;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LT_EPU16(v128 a, v128 b, byte elements = 8)
		{
			switch (elements)
			{
				case  2: ASSUME(a.UShort0  < b.UShort0);
						 ASSUME(a.UShort1  < b.UShort1);	return;

				case  3: ASSUME(a.UShort0  < b.UShort0);
						 ASSUME(a.UShort1  < b.UShort1);
						 ASSUME(a.UShort2  < b.UShort2);	return;

				case  4: ASSUME(a.UShort0  < b.UShort0);
						 ASSUME(a.UShort1  < b.UShort1);
						 ASSUME(a.UShort2  < b.UShort2);
						 ASSUME(a.UShort3  < b.UShort3);	return;

				default: ASSUME(a.UShort0  < b.UShort0);
						 ASSUME(a.UShort1  < b.UShort1);
						 ASSUME(a.UShort2  < b.UShort2);
						 ASSUME(a.UShort3  < b.UShort3);
						 ASSUME(a.UShort4  < b.UShort4);
						 ASSUME(a.UShort5  < b.UShort5);
						 ASSUME(a.UShort6  < b.UShort6);
						 ASSUME(a.UShort7  < b.UShort7);	return;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LT_EPU32(v128 a, v128 b, byte elements = 4)
		{
			switch (elements)
			{
				case  2: ASSUME(a.UInt0  < b.UInt0);
						 ASSUME(a.UInt1  < b.UInt1);	return;

				case  3: ASSUME(a.UInt0  < b.UInt0);
						 ASSUME(a.UInt1  < b.UInt1);
						 ASSUME(a.UInt2  < b.UInt2);	return;

				default: ASSUME(a.UInt0  < b.UInt0);
						 ASSUME(a.UInt1  < b.UInt1);
						 ASSUME(a.UInt2  < b.UInt2);
						 ASSUME(a.UInt3  < b.UInt3);	return;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LT_EPU64(v128 a, v128 b)
		{
			ASSUME(a.ULong0 < b.ULong0);
			ASSUME(a.ULong1 < b.ULong1);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LT_EPI8(v128 a, v128 b, byte elements = 16)
		{
			switch (elements)
			{
				case  2: ASSUME(a.SByte0  < b.SByte0);
						 ASSUME(a.SByte1  < b.SByte1);	return;

				case  3: ASSUME(a.SByte0  < b.SByte0);
						 ASSUME(a.SByte1  < b.SByte1);
						 ASSUME(a.SByte2  < b.SByte2);	return;

				case  4: ASSUME(a.SByte0  < b.SByte0);
						 ASSUME(a.SByte1  < b.SByte1);
						 ASSUME(a.SByte2  < b.SByte2);
						 ASSUME(a.SByte3  < b.SByte3);	return;

				case  8: ASSUME(a.SByte0  < b.SByte0);
						 ASSUME(a.SByte1  < b.SByte1);
						 ASSUME(a.SByte2  < b.SByte2);
						 ASSUME(a.SByte3  < b.SByte3);
						 ASSUME(a.SByte4  < b.SByte4);
						 ASSUME(a.SByte5  < b.SByte5);
						 ASSUME(a.SByte6  < b.SByte6);
						 ASSUME(a.SByte7  < b.SByte7);	return;

				default: ASSUME(a.SByte0  < b.SByte0);
						 ASSUME(a.SByte1  < b.SByte1);
						 ASSUME(a.SByte2  < b.SByte2);
						 ASSUME(a.SByte3  < b.SByte3);
						 ASSUME(a.SByte4  < b.SByte4);
						 ASSUME(a.SByte5  < b.SByte5);
						 ASSUME(a.SByte6  < b.SByte6);
						 ASSUME(a.SByte7  < b.SByte7);
						 ASSUME(a.SByte8  < b.SByte8);
						 ASSUME(a.SByte9  < b.SByte9);
						 ASSUME(a.SByte10 < b.SByte10);
						 ASSUME(a.SByte11 < b.SByte11);
						 ASSUME(a.SByte12 < b.SByte12);
						 ASSUME(a.SByte13 < b.SByte13);
						 ASSUME(a.SByte14 < b.SByte14);
						 ASSUME(a.SByte15 < b.SByte15);	return;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LT_EPI16(v128 a, v128 b, byte elements = 8)
		{
			switch (elements)
			{
				case  2: ASSUME(a.SShort0 < b.SShort0);
						 ASSUME(a.SShort1 < b.SShort1);	return;

				case  3: ASSUME(a.SShort0 < b.SShort0);
						 ASSUME(a.SShort1 < b.SShort1);
						 ASSUME(a.SShort2 < b.SShort2);	return;

				case  4: ASSUME(a.SShort0 < b.SShort0);
						 ASSUME(a.SShort1 < b.SShort1);
						 ASSUME(a.SShort2 < b.SShort2);
						 ASSUME(a.SShort3 < b.SShort3);	return;

				default: ASSUME(a.SShort0 < b.SShort0);
						 ASSUME(a.SShort1 < b.SShort1);
						 ASSUME(a.SShort2 < b.SShort2);
						 ASSUME(a.SShort3 < b.SShort3);
						 ASSUME(a.SShort4 < b.SShort4);
						 ASSUME(a.SShort5 < b.SShort5);
						 ASSUME(a.SShort6 < b.SShort6);
						 ASSUME(a.SShort7 < b.SShort7);	return;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LT_EPI32(v128 a, v128 b, byte elements = 4)
		{
			switch (elements)
			{
				case  2: ASSUME(a.SInt0 < b.SInt0);
						 ASSUME(a.SInt1 < b.SInt1);	return;

				case  3: ASSUME(a.SInt0 < b.SInt0);
						 ASSUME(a.SInt1 < b.SInt1);
						 ASSUME(a.SInt2 < b.SInt2);	return;

				default: ASSUME(a.SInt0 < b.SInt0);
						 ASSUME(a.SInt1 < b.SInt1);
						 ASSUME(a.SInt2 < b.SInt2);
						 ASSUME(a.SInt3 < b.SInt3);	return;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LT_EPI64(v128 a, v128 b)
		{
			ASSUME(a.SLong0 < b.SLong0);
			ASSUME(a.SLong1 < b.SLong1);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LT_PS(v128 a, v128 b, byte elements = 4)
		{
			switch (elements)
			{
				case  1: ASSUME(a.Float0 < b.Float0);	return;

				case  2: ASSUME(a.Float0 < b.Float0);
						 ASSUME(a.Float1 < b.Float1);	return;

				case  3: ASSUME(a.Float0 < b.Float0);
						 ASSUME(a.Float1 < b.Float1);
						 ASSUME(a.Float2 < b.Float2);	return;

				default: ASSUME(a.Float0 < b.Float0);
						 ASSUME(a.Float1 < b.Float1);
						 ASSUME(a.Float2 < b.Float2);
						 ASSUME(a.Float3 < b.Float3);	return;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LT_PD(v128 a, v128 b)
		{
			ASSUME(a.Double0 < b.Double0);
			ASSUME(a.Double1 < b.Double1);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LT_EPI8(v256 a, v256 b)
		{
			ASSUME(a.SByte0  < b.SByte0);
			ASSUME(a.SByte1  < b.SByte1);
			ASSUME(a.SByte2  < b.SByte2);
			ASSUME(a.SByte3  < b.SByte3);
			ASSUME(a.SByte4  < b.SByte4);
			ASSUME(a.SByte5  < b.SByte5);
			ASSUME(a.SByte6  < b.SByte6);
			ASSUME(a.SByte7  < b.SByte7);
			ASSUME(a.SByte8  < b.SByte8);
			ASSUME(a.SByte9  < b.SByte9);
			ASSUME(a.SByte10 < b.SByte10);
			ASSUME(a.SByte11 < b.SByte11);
			ASSUME(a.SByte12 < b.SByte12);
			ASSUME(a.SByte13 < b.SByte13);
			ASSUME(a.SByte14 < b.SByte14);
			ASSUME(a.SByte15 < b.SByte15);
			ASSUME(a.SByte16 < b.SByte16);
			ASSUME(a.SByte17 < b.SByte17);
			ASSUME(a.SByte18 < b.SByte18);
			ASSUME(a.SByte19 < b.SByte19);
			ASSUME(a.SByte20 < b.SByte20);
			ASSUME(a.SByte21 < b.SByte21);
			ASSUME(a.SByte22 < b.SByte22);
			ASSUME(a.SByte23 < b.SByte23);
			ASSUME(a.SByte24 < b.SByte24);
			ASSUME(a.SByte25 < b.SByte25);
			ASSUME(a.SByte26 < b.SByte26);
			ASSUME(a.SByte27 < b.SByte27);
			ASSUME(a.SByte28 < b.SByte28);
			ASSUME(a.SByte29 < b.SByte29);
			ASSUME(a.SByte30 < b.SByte30);
			ASSUME(a.SByte31 < b.SByte31);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LT_EPI16(v256 a, v256 b)
		{
			ASSUME(a.SShort0  < b.SShort0);
			ASSUME(a.SShort1  < b.SShort1);
			ASSUME(a.SShort2  < b.SShort2);
			ASSUME(a.SShort3  < b.SShort3);
			ASSUME(a.SShort4  < b.SShort4);
			ASSUME(a.SShort5  < b.SShort5);
			ASSUME(a.SShort6  < b.SShort6);
			ASSUME(a.SShort7  < b.SShort7);
			ASSUME(a.SShort8  < b.SShort8);
			ASSUME(a.SShort9  < b.SShort9);
			ASSUME(a.SShort10 < b.SShort10);
			ASSUME(a.SShort11 < b.SShort11);
			ASSUME(a.SShort12 < b.SShort12);
			ASSUME(a.SShort13 < b.SShort13);
			ASSUME(a.SShort14 < b.SShort14);
			ASSUME(a.SShort15 < b.SShort15);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LT_EPI32(v256 a, v256 b)
		{
			ASSUME(a.SInt0 < b.SInt0);
			ASSUME(a.SInt1 < b.SInt1);
			ASSUME(a.SInt2 < b.SInt2);
			ASSUME(a.SInt3 < b.SInt3);
			ASSUME(a.SInt4 < b.SInt4);
			ASSUME(a.SInt5 < b.SInt5);
			ASSUME(a.SInt6 < b.SInt6);
			ASSUME(a.SInt7 < b.SInt7);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LT_EPI64(v256 a, v256 b, byte elements = 4)
		{
			if (elements < 3)
			{
				ASSUME(a.SLong0 < b.SLong0);
				ASSUME(a.SLong1 < b.SLong1);
				ASSUME(a.SLong2 < b.SLong2);
			}
			else
			{
				ASSUME(a.SLong0 < b.SLong0);
				ASSUME(a.SLong1 < b.SLong1);
				ASSUME(a.SLong2 < b.SLong2);
				ASSUME(a.SLong3 < b.SLong3);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LT_EPU8(v256 a, v256 b)
		{
			ASSUME(a.Byte0  < b.Byte0);
			ASSUME(a.Byte1  < b.Byte1);
			ASSUME(a.Byte2  < b.Byte2);
			ASSUME(a.Byte3  < b.Byte3);
			ASSUME(a.Byte4  < b.Byte4);
			ASSUME(a.Byte5  < b.Byte5);
			ASSUME(a.Byte6  < b.Byte6);
			ASSUME(a.Byte7  < b.Byte7);
			ASSUME(a.Byte8  < b.Byte8);
			ASSUME(a.Byte9  < b.Byte9);
			ASSUME(a.Byte10 < b.Byte10);
			ASSUME(a.Byte11 < b.Byte11);
			ASSUME(a.Byte12 < b.Byte12);
			ASSUME(a.Byte13 < b.Byte13);
			ASSUME(a.Byte14 < b.Byte14);
			ASSUME(a.Byte15 < b.Byte15);
			ASSUME(a.Byte16 < b.Byte16);
			ASSUME(a.Byte17 < b.Byte17);
			ASSUME(a.Byte18 < b.Byte18);
			ASSUME(a.Byte19 < b.Byte19);
			ASSUME(a.Byte20 < b.Byte20);
			ASSUME(a.Byte21 < b.Byte21);
			ASSUME(a.Byte22 < b.Byte22);
			ASSUME(a.Byte23 < b.Byte23);
			ASSUME(a.Byte24 < b.Byte24);
			ASSUME(a.Byte25 < b.Byte25);
			ASSUME(a.Byte26 < b.Byte26);
			ASSUME(a.Byte27 < b.Byte27);
			ASSUME(a.Byte28 < b.Byte28);
			ASSUME(a.Byte29 < b.Byte29);
			ASSUME(a.Byte30 < b.Byte30);
			ASSUME(a.Byte31 < b.Byte31);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LT_EPU16(v256 a, v256 b)
		{
			ASSUME(a.UShort0  < b.UShort0);
			ASSUME(a.UShort1  < b.UShort1);
			ASSUME(a.UShort2  < b.UShort2);
			ASSUME(a.UShort3  < b.UShort3);
			ASSUME(a.UShort4  < b.UShort4);
			ASSUME(a.UShort5  < b.UShort5);
			ASSUME(a.UShort6  < b.UShort6);
			ASSUME(a.UShort7  < b.UShort7);
			ASSUME(a.UShort8  < b.UShort8);
			ASSUME(a.UShort9  < b.UShort9);
			ASSUME(a.UShort10 < b.UShort10);
			ASSUME(a.UShort11 < b.UShort11);
			ASSUME(a.UShort12 < b.UShort12);
			ASSUME(a.UShort13 < b.UShort13);
			ASSUME(a.UShort14 < b.UShort14);
			ASSUME(a.UShort15 < b.UShort15);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LT_EPU32(v256 a, v256 b)
		{
			ASSUME(a.UInt0 < b.UInt0);
			ASSUME(a.UInt1 < b.UInt1);
			ASSUME(a.UInt2 < b.UInt2);
			ASSUME(a.UInt3 < b.UInt3);
			ASSUME(a.UInt4 < b.UInt4);
			ASSUME(a.UInt5 < b.UInt5);
			ASSUME(a.UInt6 < b.UInt6);
			ASSUME(a.UInt7 < b.UInt7);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LT_EPU64(v256 a, v256 b, byte elements = 4)
		{
			if (elements == 3)
			{
				ASSUME(a.ULong0 < b.ULong0);
				ASSUME(a.ULong1 < b.ULong1);
				ASSUME(a.ULong2 < b.ULong2);
			}
			else
			{
				ASSUME(a.ULong0 < b.ULong0);
				ASSUME(a.ULong1 < b.ULong1);
				ASSUME(a.ULong2 < b.ULong2);
				ASSUME(a.ULong3 < b.ULong3);
			}
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LT_PS(v256 a, v256 b)
		{
			ASSUME(a.Float0 < b.Float0);
			ASSUME(a.Float1 < b.Float1);
			ASSUME(a.Float2 < b.Float2);
			ASSUME(a.Float3 < b.Float3);
			ASSUME(a.Float4 < b.Float4);
			ASSUME(a.Float5 < b.Float5);
			ASSUME(a.Float6 < b.Float6);
			ASSUME(a.Float7 < b.Float7);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LT_PD(v256 a, v256 b, byte elements = 4)
		{
			if (elements == 3)
			{
				ASSUME(a.Double0 < b.Double0);
				ASSUME(a.Double1 < b.Double1);
				ASSUME(a.Double2 < b.Double2);
			}
			else
			{
				ASSUME(a.Double0 < b.Double0);
				ASSUME(a.Double1 < b.Double1);
				ASSUME(a.Double2 < b.Double2);
				ASSUME(a.Double3 < b.Double3);
			}
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GE_EPU8(v128 a, v128 b, byte elements = 16)
		{
			switch (elements)
			{
				case  2: ASSUME(a.Byte0  >= b.Byte0);
						 ASSUME(a.Byte1  >= b.Byte1);	return;

				case  3: ASSUME(a.Byte0  >= b.Byte0);
						 ASSUME(a.Byte1  >= b.Byte1);
						 ASSUME(a.Byte2  >= b.Byte2);	return;

				case  4: ASSUME(a.Byte0  >= b.Byte0);
						 ASSUME(a.Byte1  >= b.Byte1);
						 ASSUME(a.Byte2  >= b.Byte2);
						 ASSUME(a.Byte3  >= b.Byte3);	return;

				case  8: ASSUME(a.Byte0  >= b.Byte0);
						 ASSUME(a.Byte1  >= b.Byte1);
						 ASSUME(a.Byte2  >= b.Byte2);
						 ASSUME(a.Byte3  >= b.Byte3);
						 ASSUME(a.Byte4  >= b.Byte4);
						 ASSUME(a.Byte5  >= b.Byte5);
						 ASSUME(a.Byte6  >= b.Byte6);
						 ASSUME(a.Byte7  >= b.Byte7);	return;

				default: ASSUME(a.Byte0  >= b.Byte0);
						 ASSUME(a.Byte1  >= b.Byte1);
						 ASSUME(a.Byte2  >= b.Byte2);
						 ASSUME(a.Byte3  >= b.Byte3);
						 ASSUME(a.Byte4  >= b.Byte4);
						 ASSUME(a.Byte5  >= b.Byte5);
						 ASSUME(a.Byte6  >= b.Byte6);
						 ASSUME(a.Byte7  >= b.Byte7);
						 ASSUME(a.Byte8  >= b.Byte8);
						 ASSUME(a.Byte9  >= b.Byte9);
						 ASSUME(a.Byte10 >= b.Byte10);
						 ASSUME(a.Byte11 >= b.Byte11);
						 ASSUME(a.Byte12 >= b.Byte12);
						 ASSUME(a.Byte13 >= b.Byte13);
						 ASSUME(a.Byte14 >= b.Byte14);
						 ASSUME(a.Byte15 >= b.Byte15);	return;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GE_EPU16(v128 a, v128 b, byte elements = 8)
		{
			switch (elements)
			{
				case  2: ASSUME(a.UShort0  >= b.UShort0);
						 ASSUME(a.UShort1  >= b.UShort1);	return;

				case  3: ASSUME(a.UShort0  >= b.UShort0);
						 ASSUME(a.UShort1  >= b.UShort1);
						 ASSUME(a.UShort2  >= b.UShort2);	return;

				case  4: ASSUME(a.UShort0  >= b.UShort0);
						 ASSUME(a.UShort1  >= b.UShort1);
						 ASSUME(a.UShort2  >= b.UShort2);
						 ASSUME(a.UShort3  >= b.UShort3);	return;

				default: ASSUME(a.UShort0  >= b.UShort0);
						 ASSUME(a.UShort1  >= b.UShort1);
						 ASSUME(a.UShort2  >= b.UShort2);
						 ASSUME(a.UShort3  >= b.UShort3);
						 ASSUME(a.UShort4  >= b.UShort4);
						 ASSUME(a.UShort5  >= b.UShort5);
						 ASSUME(a.UShort6  >= b.UShort6);
						 ASSUME(a.UShort7  >= b.UShort7);	return;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GE_EPU32(v128 a, v128 b, byte elements = 4)
		{
			switch (elements)
			{
				case  2: ASSUME(a.UInt0  >= b.UInt0);
						 ASSUME(a.UInt1  >= b.UInt1);	return;

				case  3: ASSUME(a.UInt0  >= b.UInt0);
						 ASSUME(a.UInt1  >= b.UInt1);
						 ASSUME(a.UInt2  >= b.UInt2);	return;

				default: ASSUME(a.UInt0  >= b.UInt0);
						 ASSUME(a.UInt1  >= b.UInt1);
						 ASSUME(a.UInt2  >= b.UInt2);
						 ASSUME(a.UInt3  >= b.UInt3);	return;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GE_EPU64(v128 a, v128 b)
		{
			ASSUME(a.ULong0 >= b.ULong0);
			ASSUME(a.ULong1 >= b.ULong1);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GE_EPI8(v128 a, v128 b, byte elements = 16)
		{
			switch (elements)
			{
				case  2: ASSUME(a.SByte0  >= b.SByte0);
						 ASSUME(a.SByte1  >= b.SByte1);	return;

				case  3: ASSUME(a.SByte0  >= b.SByte0);
						 ASSUME(a.SByte1  >= b.SByte1);
						 ASSUME(a.SByte2  >= b.SByte2);	return;

				case  4: ASSUME(a.SByte0  >= b.SByte0);
						 ASSUME(a.SByte1  >= b.SByte1);
						 ASSUME(a.SByte2  >= b.SByte2);
						 ASSUME(a.SByte3  >= b.SByte3);	return;

				case  8: ASSUME(a.SByte0  >= b.SByte0);
						 ASSUME(a.SByte1  >= b.SByte1);
						 ASSUME(a.SByte2  >= b.SByte2);
						 ASSUME(a.SByte3  >= b.SByte3);
						 ASSUME(a.SByte4  >= b.SByte4);
						 ASSUME(a.SByte5  >= b.SByte5);
						 ASSUME(a.SByte6  >= b.SByte6);
						 ASSUME(a.SByte7  >= b.SByte7);	return;

				default: ASSUME(a.SByte0  >= b.SByte0);
						 ASSUME(a.SByte1  >= b.SByte1);
						 ASSUME(a.SByte2  >= b.SByte2);
						 ASSUME(a.SByte3  >= b.SByte3);
						 ASSUME(a.SByte4  >= b.SByte4);
						 ASSUME(a.SByte5  >= b.SByte5);
						 ASSUME(a.SByte6  >= b.SByte6);
						 ASSUME(a.SByte7  >= b.SByte7);
						 ASSUME(a.SByte8  >= b.SByte8);
						 ASSUME(a.SByte9  >= b.SByte9);
						 ASSUME(a.SByte10 >= b.SByte10);
						 ASSUME(a.SByte11 >= b.SByte11);
						 ASSUME(a.SByte12 >= b.SByte12);
						 ASSUME(a.SByte13 >= b.SByte13);
						 ASSUME(a.SByte14 >= b.SByte14);
						 ASSUME(a.SByte15 >= b.SByte15);	return;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GE_EPI16(v128 a, v128 b, byte elements = 8)
		{
			switch (elements)
			{
				case  2: ASSUME(a.SShort0 >= b.SShort0);
						 ASSUME(a.SShort1 >= b.SShort1);	return;

				case  3: ASSUME(a.SShort0 >= b.SShort0);
						 ASSUME(a.SShort1 >= b.SShort1);
						 ASSUME(a.SShort2 >= b.SShort2);	return;

				case  4: ASSUME(a.SShort0 >= b.SShort0);
						 ASSUME(a.SShort1 >= b.SShort1);
						 ASSUME(a.SShort2 >= b.SShort2);
						 ASSUME(a.SShort3 >= b.SShort3);	return;

				default: ASSUME(a.SShort0 >= b.SShort0);
						 ASSUME(a.SShort1 >= b.SShort1);
						 ASSUME(a.SShort2 >= b.SShort2);
						 ASSUME(a.SShort3 >= b.SShort3);
						 ASSUME(a.SShort4 >= b.SShort4);
						 ASSUME(a.SShort5 >= b.SShort5);
						 ASSUME(a.SShort6 >= b.SShort6);
						 ASSUME(a.SShort7 >= b.SShort7);	return;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GE_EPI32(v128 a, v128 b, byte elements = 4)
		{
			switch (elements)
			{
				case  2: ASSUME(a.SInt0 >= b.SInt0);
						 ASSUME(a.SInt1 >= b.SInt1);	return;

				case  3: ASSUME(a.SInt0 >= b.SInt0);
						 ASSUME(a.SInt1 >= b.SInt1);
						 ASSUME(a.SInt2 >= b.SInt2);	return;

				default: ASSUME(a.SInt0 >= b.SInt0);
						 ASSUME(a.SInt1 >= b.SInt1);
						 ASSUME(a.SInt2 >= b.SInt2);
						 ASSUME(a.SInt3 >= b.SInt3);	return;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GE_EPI64(v128 a, v128 b)
		{
			ASSUME(a.SLong0 >= b.SLong0);
			ASSUME(a.SLong1 >= b.SLong1);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GE_PS(v128 a, v128 b, byte elements = 4)
		{
			switch (elements)
			{
				case  1: ASSUME(a.Float0 >= b.Float0);	return;

				case  2: ASSUME(a.Float0 >= b.Float0);
						 ASSUME(a.Float1 >= b.Float1);	return;

				case  3: ASSUME(a.Float0 >= b.Float0);
						 ASSUME(a.Float1 >= b.Float1);
						 ASSUME(a.Float2 >= b.Float2);	return;

				default: ASSUME(a.Float0 >= b.Float0);
						 ASSUME(a.Float1 >= b.Float1);
						 ASSUME(a.Float2 >= b.Float2);
						 ASSUME(a.Float3 >= b.Float3);	return;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GE_PD(v128 a, v128 b)
		{
			ASSUME(a.Double0 >= b.Double0);
			ASSUME(a.Double1 >= b.Double1);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GE_EPI8(v256 a, v256 b)
		{
			ASSUME(a.SByte0  >= b.SByte0);
			ASSUME(a.SByte1  >= b.SByte1);
			ASSUME(a.SByte2  >= b.SByte2);
			ASSUME(a.SByte3  >= b.SByte3);
			ASSUME(a.SByte4  >= b.SByte4);
			ASSUME(a.SByte5  >= b.SByte5);
			ASSUME(a.SByte6  >= b.SByte6);
			ASSUME(a.SByte7  >= b.SByte7);
			ASSUME(a.SByte8  >= b.SByte8);
			ASSUME(a.SByte9  >= b.SByte9);
			ASSUME(a.SByte10 >= b.SByte10);
			ASSUME(a.SByte11 >= b.SByte11);
			ASSUME(a.SByte12 >= b.SByte12);
			ASSUME(a.SByte13 >= b.SByte13);
			ASSUME(a.SByte14 >= b.SByte14);
			ASSUME(a.SByte15 >= b.SByte15);
			ASSUME(a.SByte16 >= b.SByte16);
			ASSUME(a.SByte17 >= b.SByte17);
			ASSUME(a.SByte18 >= b.SByte18);
			ASSUME(a.SByte19 >= b.SByte19);
			ASSUME(a.SByte20 >= b.SByte20);
			ASSUME(a.SByte21 >= b.SByte21);
			ASSUME(a.SByte22 >= b.SByte22);
			ASSUME(a.SByte23 >= b.SByte23);
			ASSUME(a.SByte24 >= b.SByte24);
			ASSUME(a.SByte25 >= b.SByte25);
			ASSUME(a.SByte26 >= b.SByte26);
			ASSUME(a.SByte27 >= b.SByte27);
			ASSUME(a.SByte28 >= b.SByte28);
			ASSUME(a.SByte29 >= b.SByte29);
			ASSUME(a.SByte30 >= b.SByte30);
			ASSUME(a.SByte31 >= b.SByte31);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GE_EPI16(v256 a, v256 b)
		{
			ASSUME(a.SShort0  >= b.SShort0);
			ASSUME(a.SShort1  >= b.SShort1);
			ASSUME(a.SShort2  >= b.SShort2);
			ASSUME(a.SShort3  >= b.SShort3);
			ASSUME(a.SShort4  >= b.SShort4);
			ASSUME(a.SShort5  >= b.SShort5);
			ASSUME(a.SShort6  >= b.SShort6);
			ASSUME(a.SShort7  >= b.SShort7);
			ASSUME(a.SShort8  >= b.SShort8);
			ASSUME(a.SShort9  >= b.SShort9);
			ASSUME(a.SShort10 >= b.SShort10);
			ASSUME(a.SShort11 >= b.SShort11);
			ASSUME(a.SShort12 >= b.SShort12);
			ASSUME(a.SShort13 >= b.SShort13);
			ASSUME(a.SShort14 >= b.SShort14);
			ASSUME(a.SShort15 >= b.SShort15);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GE_EPI32(v256 a, v256 b)
		{
			ASSUME(a.SInt0 >= b.SInt0);
			ASSUME(a.SInt1 >= b.SInt1);
			ASSUME(a.SInt2 >= b.SInt2);
			ASSUME(a.SInt3 >= b.SInt3);
			ASSUME(a.SInt4 >= b.SInt4);
			ASSUME(a.SInt5 >= b.SInt5);
			ASSUME(a.SInt6 >= b.SInt6);
			ASSUME(a.SInt7 >= b.SInt7);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GE_EPI64(v256 a, v256 b, byte elements = 4)
		{
			if (elements >= 3)
			{
				ASSUME(a.SLong0 >= b.SLong0);
				ASSUME(a.SLong1 >= b.SLong1);
				ASSUME(a.SLong2 >= b.SLong2);
			}
			else
			{
				ASSUME(a.SLong0 >= b.SLong0);
				ASSUME(a.SLong1 >= b.SLong1);
				ASSUME(a.SLong2 >= b.SLong2);
				ASSUME(a.SLong3 >= b.SLong3);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GE_EPU8(v256 a, v256 b)
		{
			ASSUME(a.Byte0  >= b.Byte0);
			ASSUME(a.Byte1  >= b.Byte1);
			ASSUME(a.Byte2  >= b.Byte2);
			ASSUME(a.Byte3  >= b.Byte3);
			ASSUME(a.Byte4  >= b.Byte4);
			ASSUME(a.Byte5  >= b.Byte5);
			ASSUME(a.Byte6  >= b.Byte6);
			ASSUME(a.Byte7  >= b.Byte7);
			ASSUME(a.Byte8  >= b.Byte8);
			ASSUME(a.Byte9  >= b.Byte9);
			ASSUME(a.Byte10 >= b.Byte10);
			ASSUME(a.Byte11 >= b.Byte11);
			ASSUME(a.Byte12 >= b.Byte12);
			ASSUME(a.Byte13 >= b.Byte13);
			ASSUME(a.Byte14 >= b.Byte14);
			ASSUME(a.Byte15 >= b.Byte15);
			ASSUME(a.Byte16 >= b.Byte16);
			ASSUME(a.Byte17 >= b.Byte17);
			ASSUME(a.Byte18 >= b.Byte18);
			ASSUME(a.Byte19 >= b.Byte19);
			ASSUME(a.Byte20 >= b.Byte20);
			ASSUME(a.Byte21 >= b.Byte21);
			ASSUME(a.Byte22 >= b.Byte22);
			ASSUME(a.Byte23 >= b.Byte23);
			ASSUME(a.Byte24 >= b.Byte24);
			ASSUME(a.Byte25 >= b.Byte25);
			ASSUME(a.Byte26 >= b.Byte26);
			ASSUME(a.Byte27 >= b.Byte27);
			ASSUME(a.Byte28 >= b.Byte28);
			ASSUME(a.Byte29 >= b.Byte29);
			ASSUME(a.Byte30 >= b.Byte30);
			ASSUME(a.Byte31 >= b.Byte31);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GE_EPU16(v256 a, v256 b)
		{
			ASSUME(a.UShort0  >= b.UShort0);
			ASSUME(a.UShort1  >= b.UShort1);
			ASSUME(a.UShort2  >= b.UShort2);
			ASSUME(a.UShort3  >= b.UShort3);
			ASSUME(a.UShort4  >= b.UShort4);
			ASSUME(a.UShort5  >= b.UShort5);
			ASSUME(a.UShort6  >= b.UShort6);
			ASSUME(a.UShort7  >= b.UShort7);
			ASSUME(a.UShort8  >= b.UShort8);
			ASSUME(a.UShort9  >= b.UShort9);
			ASSUME(a.UShort10 >= b.UShort10);
			ASSUME(a.UShort11 >= b.UShort11);
			ASSUME(a.UShort12 >= b.UShort12);
			ASSUME(a.UShort13 >= b.UShort13);
			ASSUME(a.UShort14 >= b.UShort14);
			ASSUME(a.UShort15 >= b.UShort15);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GE_EPU32(v256 a, v256 b)
		{
			ASSUME(a.UInt0 >= b.UInt0);
			ASSUME(a.UInt1 >= b.UInt1);
			ASSUME(a.UInt2 >= b.UInt2);
			ASSUME(a.UInt3 >= b.UInt3);
			ASSUME(a.UInt4 >= b.UInt4);
			ASSUME(a.UInt5 >= b.UInt5);
			ASSUME(a.UInt6 >= b.UInt6);
			ASSUME(a.UInt7 >= b.UInt7);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GE_EPU64(v256 a, v256 b, byte elements = 4)
		{
			if (elements >= 3)
			{
				ASSUME(a.ULong0 >= b.ULong0);
				ASSUME(a.ULong1 >= b.ULong1);
				ASSUME(a.ULong2 >= b.ULong2);
			}
			else
			{
				ASSUME(a.ULong0 >= b.ULong0);
				ASSUME(a.ULong1 >= b.ULong1);
				ASSUME(a.ULong2 >= b.ULong2);
				ASSUME(a.ULong3 >= b.ULong3);
			}
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GE_PS(v256 a, v256 b)
		{
			ASSUME(a.Float0 >= b.Float0);
			ASSUME(a.Float1 >= b.Float1);
			ASSUME(a.Float2 >= b.Float2);
			ASSUME(a.Float3 >= b.Float3);
			ASSUME(a.Float4 >= b.Float4);
			ASSUME(a.Float5 >= b.Float5);
			ASSUME(a.Float6 >= b.Float6);
			ASSUME(a.Float7 >= b.Float7);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GE_PD(v256 a, v256 b, byte elements = 4)
		{
			if (elements >= 3)
			{
				ASSUME(a.Double0 >= b.Double0);
				ASSUME(a.Double1 >= b.Double1);
				ASSUME(a.Double2 >= b.Double2);
			}
			else
			{
				ASSUME(a.Double0 >= b.Double0);
				ASSUME(a.Double1 >= b.Double1);
				ASSUME(a.Double2 >= b.Double2);
				ASSUME(a.Double3 >= b.Double3);
			}
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LE_EPU8(v128 a, v128 b, byte elements = 16)
		{
			switch (elements)
			{
				case  2: ASSUME(a.Byte0  <= b.Byte0);
						 ASSUME(a.Byte1  <= b.Byte1);	return;

				case  3: ASSUME(a.Byte0  <= b.Byte0);
						 ASSUME(a.Byte1  <= b.Byte1);
						 ASSUME(a.Byte2  <= b.Byte2);	return;

				case  4: ASSUME(a.Byte0  <= b.Byte0);
						 ASSUME(a.Byte1  <= b.Byte1);
						 ASSUME(a.Byte2  <= b.Byte2);
						 ASSUME(a.Byte3  <= b.Byte3);	return;

				case  8: ASSUME(a.Byte0  <= b.Byte0);
						 ASSUME(a.Byte1  <= b.Byte1);
						 ASSUME(a.Byte2  <= b.Byte2);
						 ASSUME(a.Byte3  <= b.Byte3);
						 ASSUME(a.Byte4  <= b.Byte4);
						 ASSUME(a.Byte5  <= b.Byte5);
						 ASSUME(a.Byte6  <= b.Byte6);
						 ASSUME(a.Byte7  <= b.Byte7);	return;

				default: ASSUME(a.Byte0  <= b.Byte0);
						 ASSUME(a.Byte1  <= b.Byte1);
						 ASSUME(a.Byte2  <= b.Byte2);
						 ASSUME(a.Byte3  <= b.Byte3);
						 ASSUME(a.Byte4  <= b.Byte4);
						 ASSUME(a.Byte5  <= b.Byte5);
						 ASSUME(a.Byte6  <= b.Byte6);
						 ASSUME(a.Byte7  <= b.Byte7);
						 ASSUME(a.Byte8  <= b.Byte8);
						 ASSUME(a.Byte9  <= b.Byte9);
						 ASSUME(a.Byte10 <= b.Byte10);
						 ASSUME(a.Byte11 <= b.Byte11);
						 ASSUME(a.Byte12 <= b.Byte12);
						 ASSUME(a.Byte13 <= b.Byte13);
						 ASSUME(a.Byte14 <= b.Byte14);
						 ASSUME(a.Byte15 <= b.Byte15);	return;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LE_EPU16(v128 a, v128 b, byte elements = 8)
		{
			switch (elements)
			{
				case  2: ASSUME(a.UShort0  <= b.UShort0);
						 ASSUME(a.UShort1  <= b.UShort1);	return;

				case  3: ASSUME(a.UShort0  <= b.UShort0);
						 ASSUME(a.UShort1  <= b.UShort1);
						 ASSUME(a.UShort2  <= b.UShort2);	return;

				case  4: ASSUME(a.UShort0  <= b.UShort0);
						 ASSUME(a.UShort1  <= b.UShort1);
						 ASSUME(a.UShort2  <= b.UShort2);
						 ASSUME(a.UShort3  <= b.UShort3);	return;

				default: ASSUME(a.UShort0  <= b.UShort0);
						 ASSUME(a.UShort1  <= b.UShort1);
						 ASSUME(a.UShort2  <= b.UShort2);
						 ASSUME(a.UShort3  <= b.UShort3);
						 ASSUME(a.UShort4  <= b.UShort4);
						 ASSUME(a.UShort5  <= b.UShort5);
						 ASSUME(a.UShort6  <= b.UShort6);
						 ASSUME(a.UShort7  <= b.UShort7);	return;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LE_EPU32(v128 a, v128 b, byte elements = 4)
		{
			switch (elements)
			{
				case  2: ASSUME(a.UInt0  <= b.UInt0);
						 ASSUME(a.UInt1  <= b.UInt1);	return;

				case  3: ASSUME(a.UInt0  <= b.UInt0);
						 ASSUME(a.UInt1  <= b.UInt1);
						 ASSUME(a.UInt2  <= b.UInt2);	return;

				default: ASSUME(a.UInt0  <= b.UInt0);
						 ASSUME(a.UInt1  <= b.UInt1);
						 ASSUME(a.UInt2  <= b.UInt2);
						 ASSUME(a.UInt3  <= b.UInt3);	return;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LE_EPU64(v128 a, v128 b)
		{
			ASSUME(a.ULong0 <= b.ULong0);
			ASSUME(a.ULong1 <= b.ULong1);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LE_EPI8(v128 a, v128 b, byte elements = 16)
		{
			switch (elements)
			{
				case  2: ASSUME(a.SByte0  <= b.SByte0);
						 ASSUME(a.SByte1  <= b.SByte1);	return;

				case  3: ASSUME(a.SByte0  <= b.SByte0);
						 ASSUME(a.SByte1  <= b.SByte1);
						 ASSUME(a.SByte2  <= b.SByte2);	return;

				case  4: ASSUME(a.SByte0  <= b.SByte0);
						 ASSUME(a.SByte1  <= b.SByte1);
						 ASSUME(a.SByte2  <= b.SByte2);
						 ASSUME(a.SByte3  <= b.SByte3);	return;

				case  8: ASSUME(a.SByte0  <= b.SByte0);
						 ASSUME(a.SByte1  <= b.SByte1);
						 ASSUME(a.SByte2  <= b.SByte2);
						 ASSUME(a.SByte3  <= b.SByte3);
						 ASSUME(a.SByte4  <= b.SByte4);
						 ASSUME(a.SByte5  <= b.SByte5);
						 ASSUME(a.SByte6  <= b.SByte6);
						 ASSUME(a.SByte7  <= b.SByte7);	return;

				default: ASSUME(a.SByte0  <= b.SByte0);
						 ASSUME(a.SByte1  <= b.SByte1);
						 ASSUME(a.SByte2  <= b.SByte2);
						 ASSUME(a.SByte3  <= b.SByte3);
						 ASSUME(a.SByte4  <= b.SByte4);
						 ASSUME(a.SByte5  <= b.SByte5);
						 ASSUME(a.SByte6  <= b.SByte6);
						 ASSUME(a.SByte7  <= b.SByte7);
						 ASSUME(a.SByte8  <= b.SByte8);
						 ASSUME(a.SByte9  <= b.SByte9);
						 ASSUME(a.SByte10 <= b.SByte10);
						 ASSUME(a.SByte11 <= b.SByte11);
						 ASSUME(a.SByte12 <= b.SByte12);
						 ASSUME(a.SByte13 <= b.SByte13);
						 ASSUME(a.SByte14 <= b.SByte14);
						 ASSUME(a.SByte15 <= b.SByte15);	return;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LE_EPI16(v128 a, v128 b, byte elements = 8)
		{
			switch (elements)
			{
				case  2: ASSUME(a.SShort0 <= b.SShort0);
						 ASSUME(a.SShort1 <= b.SShort1);	return;

				case  3: ASSUME(a.SShort0 <= b.SShort0);
						 ASSUME(a.SShort1 <= b.SShort1);
						 ASSUME(a.SShort2 <= b.SShort2);	return;

				case  4: ASSUME(a.SShort0 <= b.SShort0);
						 ASSUME(a.SShort1 <= b.SShort1);
						 ASSUME(a.SShort2 <= b.SShort2);
						 ASSUME(a.SShort3 <= b.SShort3);	return;

				default: ASSUME(a.SShort0 <= b.SShort0);
						 ASSUME(a.SShort1 <= b.SShort1);
						 ASSUME(a.SShort2 <= b.SShort2);
						 ASSUME(a.SShort3 <= b.SShort3);
						 ASSUME(a.SShort4 <= b.SShort4);
						 ASSUME(a.SShort5 <= b.SShort5);
						 ASSUME(a.SShort6 <= b.SShort6);
						 ASSUME(a.SShort7 <= b.SShort7);	return;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LE_EPI32(v128 a, v128 b, byte elements = 4)
		{
			switch (elements)
			{
				case  2: ASSUME(a.SInt0 <= b.SInt0);
						 ASSUME(a.SInt1 <= b.SInt1);	return;

				case  3: ASSUME(a.SInt0 <= b.SInt0);
						 ASSUME(a.SInt1 <= b.SInt1);
						 ASSUME(a.SInt2 <= b.SInt2);	return;

				default: ASSUME(a.SInt0 <= b.SInt0);
						 ASSUME(a.SInt1 <= b.SInt1);
						 ASSUME(a.SInt2 <= b.SInt2);
						 ASSUME(a.SInt3 <= b.SInt3);	return;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LE_EPI64(v128 a, v128 b)
		{
			ASSUME(a.SLong0 <= b.SLong0);
			ASSUME(a.SLong1 <= b.SLong1);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LE_PS(v128 a, v128 b, byte elements = 4)
		{
			switch (elements)
			{
				case  1: ASSUME(a.Float0 <= b.Float0);	return;

				case  2: ASSUME(a.Float0 <= b.Float0);
						 ASSUME(a.Float1 <= b.Float1);	return;

				case  3: ASSUME(a.Float0 <= b.Float0);
						 ASSUME(a.Float1 <= b.Float1);
						 ASSUME(a.Float2 <= b.Float2);	return;

				default: ASSUME(a.Float0 <= b.Float0);
						 ASSUME(a.Float1 <= b.Float1);
						 ASSUME(a.Float2 <= b.Float2);
						 ASSUME(a.Float3 <= b.Float3);	return;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LE_PD(v128 a, v128 b)
		{
			ASSUME(a.Double0 <= b.Double0);
			ASSUME(a.Double1 <= b.Double1);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LE_EPI8(v256 a, v256 b)
		{
			ASSUME(a.SByte0  <= b.SByte0);
			ASSUME(a.SByte1  <= b.SByte1);
			ASSUME(a.SByte2  <= b.SByte2);
			ASSUME(a.SByte3  <= b.SByte3);
			ASSUME(a.SByte4  <= b.SByte4);
			ASSUME(a.SByte5  <= b.SByte5);
			ASSUME(a.SByte6  <= b.SByte6);
			ASSUME(a.SByte7  <= b.SByte7);
			ASSUME(a.SByte8  <= b.SByte8);
			ASSUME(a.SByte9  <= b.SByte9);
			ASSUME(a.SByte10 <= b.SByte10);
			ASSUME(a.SByte11 <= b.SByte11);
			ASSUME(a.SByte12 <= b.SByte12);
			ASSUME(a.SByte13 <= b.SByte13);
			ASSUME(a.SByte14 <= b.SByte14);
			ASSUME(a.SByte15 <= b.SByte15);
			ASSUME(a.SByte16 <= b.SByte16);
			ASSUME(a.SByte17 <= b.SByte17);
			ASSUME(a.SByte18 <= b.SByte18);
			ASSUME(a.SByte19 <= b.SByte19);
			ASSUME(a.SByte20 <= b.SByte20);
			ASSUME(a.SByte21 <= b.SByte21);
			ASSUME(a.SByte22 <= b.SByte22);
			ASSUME(a.SByte23 <= b.SByte23);
			ASSUME(a.SByte24 <= b.SByte24);
			ASSUME(a.SByte25 <= b.SByte25);
			ASSUME(a.SByte26 <= b.SByte26);
			ASSUME(a.SByte27 <= b.SByte27);
			ASSUME(a.SByte28 <= b.SByte28);
			ASSUME(a.SByte29 <= b.SByte29);
			ASSUME(a.SByte30 <= b.SByte30);
			ASSUME(a.SByte31 <= b.SByte31);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LE_EPI16(v256 a, v256 b)
		{
			ASSUME(a.SShort0  <= b.SShort0);
			ASSUME(a.SShort1  <= b.SShort1);
			ASSUME(a.SShort2  <= b.SShort2);
			ASSUME(a.SShort3  <= b.SShort3);
			ASSUME(a.SShort4  <= b.SShort4);
			ASSUME(a.SShort5  <= b.SShort5);
			ASSUME(a.SShort6  <= b.SShort6);
			ASSUME(a.SShort7  <= b.SShort7);
			ASSUME(a.SShort8  <= b.SShort8);
			ASSUME(a.SShort9  <= b.SShort9);
			ASSUME(a.SShort10 <= b.SShort10);
			ASSUME(a.SShort11 <= b.SShort11);
			ASSUME(a.SShort12 <= b.SShort12);
			ASSUME(a.SShort13 <= b.SShort13);
			ASSUME(a.SShort14 <= b.SShort14);
			ASSUME(a.SShort15 <= b.SShort15);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LE_EPI32(v256 a, v256 b)
		{
			ASSUME(a.SInt0 <= b.SInt0);
			ASSUME(a.SInt1 <= b.SInt1);
			ASSUME(a.SInt2 <= b.SInt2);
			ASSUME(a.SInt3 <= b.SInt3);
			ASSUME(a.SInt4 <= b.SInt4);
			ASSUME(a.SInt5 <= b.SInt5);
			ASSUME(a.SInt6 <= b.SInt6);
			ASSUME(a.SInt7 <= b.SInt7);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LE_EPI64(v256 a, v256 b, byte elements = 4)
		{
			if (elements <= 3)
			{
				ASSUME(a.SLong0 <= b.SLong0);
				ASSUME(a.SLong1 <= b.SLong1);
				ASSUME(a.SLong2 <= b.SLong2);
			}
			else
			{
				ASSUME(a.SLong0 <= b.SLong0);
				ASSUME(a.SLong1 <= b.SLong1);
				ASSUME(a.SLong2 <= b.SLong2);
				ASSUME(a.SLong3 <= b.SLong3);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LE_EPU8(v256 a, v256 b)
		{
			ASSUME(a.Byte0  <= b.Byte0);
			ASSUME(a.Byte1  <= b.Byte1);
			ASSUME(a.Byte2  <= b.Byte2);
			ASSUME(a.Byte3  <= b.Byte3);
			ASSUME(a.Byte4  <= b.Byte4);
			ASSUME(a.Byte5  <= b.Byte5);
			ASSUME(a.Byte6  <= b.Byte6);
			ASSUME(a.Byte7  <= b.Byte7);
			ASSUME(a.Byte8  <= b.Byte8);
			ASSUME(a.Byte9  <= b.Byte9);
			ASSUME(a.Byte10 <= b.Byte10);
			ASSUME(a.Byte11 <= b.Byte11);
			ASSUME(a.Byte12 <= b.Byte12);
			ASSUME(a.Byte13 <= b.Byte13);
			ASSUME(a.Byte14 <= b.Byte14);
			ASSUME(a.Byte15 <= b.Byte15);
			ASSUME(a.Byte16 <= b.Byte16);
			ASSUME(a.Byte17 <= b.Byte17);
			ASSUME(a.Byte18 <= b.Byte18);
			ASSUME(a.Byte19 <= b.Byte19);
			ASSUME(a.Byte20 <= b.Byte20);
			ASSUME(a.Byte21 <= b.Byte21);
			ASSUME(a.Byte22 <= b.Byte22);
			ASSUME(a.Byte23 <= b.Byte23);
			ASSUME(a.Byte24 <= b.Byte24);
			ASSUME(a.Byte25 <= b.Byte25);
			ASSUME(a.Byte26 <= b.Byte26);
			ASSUME(a.Byte27 <= b.Byte27);
			ASSUME(a.Byte28 <= b.Byte28);
			ASSUME(a.Byte29 <= b.Byte29);
			ASSUME(a.Byte30 <= b.Byte30);
			ASSUME(a.Byte31 <= b.Byte31);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LE_EPU16(v256 a, v256 b)
		{
			ASSUME(a.UShort0  <= b.UShort0);
			ASSUME(a.UShort1  <= b.UShort1);
			ASSUME(a.UShort2  <= b.UShort2);
			ASSUME(a.UShort3  <= b.UShort3);
			ASSUME(a.UShort4  <= b.UShort4);
			ASSUME(a.UShort5  <= b.UShort5);
			ASSUME(a.UShort6  <= b.UShort6);
			ASSUME(a.UShort7  <= b.UShort7);
			ASSUME(a.UShort8  <= b.UShort8);
			ASSUME(a.UShort9  <= b.UShort9);
			ASSUME(a.UShort10 <= b.UShort10);
			ASSUME(a.UShort11 <= b.UShort11);
			ASSUME(a.UShort12 <= b.UShort12);
			ASSUME(a.UShort13 <= b.UShort13);
			ASSUME(a.UShort14 <= b.UShort14);
			ASSUME(a.UShort15 <= b.UShort15);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LE_EPU32(v256 a, v256 b)
		{
			ASSUME(a.UInt0 <= b.UInt0);
			ASSUME(a.UInt1 <= b.UInt1);
			ASSUME(a.UInt2 <= b.UInt2);
			ASSUME(a.UInt3 <= b.UInt3);
			ASSUME(a.UInt4 <= b.UInt4);
			ASSUME(a.UInt5 <= b.UInt5);
			ASSUME(a.UInt6 <= b.UInt6);
			ASSUME(a.UInt7 <= b.UInt7);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LE_EPU64(v256 a, v256 b, byte elements = 4)
		{
			if (elements <= 3)
			{
				ASSUME(a.ULong0 <= b.ULong0);
				ASSUME(a.ULong1 <= b.ULong1);
				ASSUME(a.ULong2 <= b.ULong2);
			}
			else
			{
				ASSUME(a.ULong0 <= b.ULong0);
				ASSUME(a.ULong1 <= b.ULong1);
				ASSUME(a.ULong2 <= b.ULong2);
				ASSUME(a.ULong3 <= b.ULong3);
			}
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LE_PS(v256 a, v256 b)
		{
			ASSUME(a.Float0 <= b.Float0);
			ASSUME(a.Float1 <= b.Float1);
			ASSUME(a.Float2 <= b.Float2);
			ASSUME(a.Float3 <= b.Float3);
			ASSUME(a.Float4 <= b.Float4);
			ASSUME(a.Float5 <= b.Float5);
			ASSUME(a.Float6 <= b.Float6);
			ASSUME(a.Float7 <= b.Float7);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LE_PD(v256 a, v256 b, byte elements = 4)
		{
			if (elements <= 3)
			{
				ASSUME(a.Double0 <= b.Double0);
				ASSUME(a.Double1 <= b.Double1);
				ASSUME(a.Double2 <= b.Double2);
			}
			else
			{
				ASSUME(a.Double0 <= b.Double0);
				ASSUME(a.Double1 <= b.Double1);
				ASSUME(a.Double2 <= b.Double2);
				ASSUME(a.Double3 <= b.Double3);
			}
		}
	}
}
