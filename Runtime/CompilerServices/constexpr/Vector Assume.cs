using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;

namespace MaxMath.CompilerServices
{
    public static partial class constexpr
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_IS_MASK_EPI8(v128 v)
		{
			ASSUME(v.Byte0  == byte.MinValue || v.Byte0  == byte.MaxValue);
			ASSUME(v.Byte1  == byte.MinValue || v.Byte1  == byte.MaxValue);
			ASSUME(v.Byte2  == byte.MinValue || v.Byte2  == byte.MaxValue);
			ASSUME(v.Byte3  == byte.MinValue || v.Byte3  == byte.MaxValue);
			ASSUME(v.Byte4  == byte.MinValue || v.Byte4  == byte.MaxValue);
			ASSUME(v.Byte5  == byte.MinValue || v.Byte5  == byte.MaxValue);
			ASSUME(v.Byte6  == byte.MinValue || v.Byte6  == byte.MaxValue);
			ASSUME(v.Byte7  == byte.MinValue || v.Byte7  == byte.MaxValue);
			ASSUME(v.Byte8  == byte.MinValue || v.Byte8  == byte.MaxValue);
			ASSUME(v.Byte9  == byte.MinValue || v.Byte9  == byte.MaxValue);
			ASSUME(v.Byte10 == byte.MinValue || v.Byte10 == byte.MaxValue);
			ASSUME(v.Byte11 == byte.MinValue || v.Byte11 == byte.MaxValue);
			ASSUME(v.Byte12 == byte.MinValue || v.Byte12 == byte.MaxValue);
			ASSUME(v.Byte13 == byte.MinValue || v.Byte13 == byte.MaxValue);
			ASSUME(v.Byte14 == byte.MinValue || v.Byte14 == byte.MaxValue);
			ASSUME(v.Byte15 == byte.MinValue || v.Byte15 == byte.MaxValue);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_IS_MASK_EPI16(v128 v)
		{
			ASSUME(v.UShort0 == ushort.MinValue || v.UShort0 == ushort.MaxValue);
			ASSUME(v.UShort1 == ushort.MinValue || v.UShort1 == ushort.MaxValue);
			ASSUME(v.UShort2 == ushort.MinValue || v.UShort2 == ushort.MaxValue);
			ASSUME(v.UShort3 == ushort.MinValue || v.UShort3 == ushort.MaxValue);
			ASSUME(v.UShort4 == ushort.MinValue || v.UShort4 == ushort.MaxValue);
			ASSUME(v.UShort5 == ushort.MinValue || v.UShort5 == ushort.MaxValue);
			ASSUME(v.UShort6 == ushort.MinValue || v.UShort6 == ushort.MaxValue);
			ASSUME(v.UShort7 == ushort.MinValue || v.UShort7 == ushort.MaxValue);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_IS_MASK_EPI32(v128 v)
		{
			ASSUME(v.UInt0 == uint.MinValue || v.UInt0 == uint.MaxValue);
			ASSUME(v.UInt1 == uint.MinValue || v.UInt1 == uint.MaxValue);
			ASSUME(v.UInt2 == uint.MinValue || v.UInt2 == uint.MaxValue);
			ASSUME(v.UInt3 == uint.MinValue || v.UInt3 == uint.MaxValue);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_IS_MASK_EPI64(v128 v)
		{
			ASSUME(v.ULong0 == ulong.MinValue || v.ULong0 == ulong.MaxValue);
			ASSUME(v.ULong1 == ulong.MinValue || v.ULong1 == ulong.MaxValue);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_IS_MASK_EPI8(v256 v)
		{
			ASSUME(v.Byte0  == byte.MinValue || v.Byte0  == byte.MaxValue);
			ASSUME(v.Byte1  == byte.MinValue || v.Byte1  == byte.MaxValue);
			ASSUME(v.Byte2  == byte.MinValue || v.Byte2  == byte.MaxValue);
			ASSUME(v.Byte3  == byte.MinValue || v.Byte3  == byte.MaxValue);
			ASSUME(v.Byte4  == byte.MinValue || v.Byte4  == byte.MaxValue);
			ASSUME(v.Byte5  == byte.MinValue || v.Byte5  == byte.MaxValue);
			ASSUME(v.Byte6  == byte.MinValue || v.Byte6  == byte.MaxValue);
			ASSUME(v.Byte7  == byte.MinValue || v.Byte7  == byte.MaxValue);
			ASSUME(v.Byte8  == byte.MinValue || v.Byte8  == byte.MaxValue);
			ASSUME(v.Byte9  == byte.MinValue || v.Byte9  == byte.MaxValue);
			ASSUME(v.Byte10 == byte.MinValue || v.Byte10 == byte.MaxValue);
			ASSUME(v.Byte11 == byte.MinValue || v.Byte11 == byte.MaxValue);
			ASSUME(v.Byte12 == byte.MinValue || v.Byte12 == byte.MaxValue);
			ASSUME(v.Byte13 == byte.MinValue || v.Byte13 == byte.MaxValue);
			ASSUME(v.Byte14 == byte.MinValue || v.Byte14 == byte.MaxValue);
			ASSUME(v.Byte15 == byte.MinValue || v.Byte15 == byte.MaxValue);
			ASSUME(v.Byte16 == byte.MinValue || v.Byte16 == byte.MaxValue);
			ASSUME(v.Byte17 == byte.MinValue || v.Byte17 == byte.MaxValue);
			ASSUME(v.Byte18 == byte.MinValue || v.Byte18 == byte.MaxValue);
			ASSUME(v.Byte19 == byte.MinValue || v.Byte19 == byte.MaxValue);
			ASSUME(v.Byte20 == byte.MinValue || v.Byte20 == byte.MaxValue);
			ASSUME(v.Byte21 == byte.MinValue || v.Byte21 == byte.MaxValue);
			ASSUME(v.Byte22 == byte.MinValue || v.Byte22 == byte.MaxValue);
			ASSUME(v.Byte23 == byte.MinValue || v.Byte23 == byte.MaxValue);
			ASSUME(v.Byte24 == byte.MinValue || v.Byte24 == byte.MaxValue);
			ASSUME(v.Byte25 == byte.MinValue || v.Byte25 == byte.MaxValue);
			ASSUME(v.Byte26 == byte.MinValue || v.Byte26 == byte.MaxValue);
			ASSUME(v.Byte27 == byte.MinValue || v.Byte27 == byte.MaxValue);
			ASSUME(v.Byte28 == byte.MinValue || v.Byte28 == byte.MaxValue);
			ASSUME(v.Byte29 == byte.MinValue || v.Byte29 == byte.MaxValue);
			ASSUME(v.Byte30 == byte.MinValue || v.Byte30 == byte.MaxValue);
			ASSUME(v.Byte31 == byte.MinValue || v.Byte31 == byte.MaxValue);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_IS_MASK_EPI16(v256 v)
		{
			ASSUME(v.UShort0  == ushort.MinValue || v.UShort0  == ushort.MaxValue);
			ASSUME(v.UShort1  == ushort.MinValue || v.UShort1  == ushort.MaxValue);
			ASSUME(v.UShort2  == ushort.MinValue || v.UShort2  == ushort.MaxValue);
			ASSUME(v.UShort3  == ushort.MinValue || v.UShort3  == ushort.MaxValue);
			ASSUME(v.UShort4  == ushort.MinValue || v.UShort4  == ushort.MaxValue);
			ASSUME(v.UShort5  == ushort.MinValue || v.UShort5  == ushort.MaxValue);
			ASSUME(v.UShort6  == ushort.MinValue || v.UShort6  == ushort.MaxValue);
			ASSUME(v.UShort7  == ushort.MinValue || v.UShort7  == ushort.MaxValue);
			ASSUME(v.UShort8  == ushort.MinValue || v.UShort8  == ushort.MaxValue);
			ASSUME(v.UShort9  == ushort.MinValue || v.UShort9  == ushort.MaxValue);
			ASSUME(v.UShort10 == ushort.MinValue || v.UShort10 == ushort.MaxValue);
			ASSUME(v.UShort11 == ushort.MinValue || v.UShort11 == ushort.MaxValue);
			ASSUME(v.UShort12 == ushort.MinValue || v.UShort12 == ushort.MaxValue);
			ASSUME(v.UShort13 == ushort.MinValue || v.UShort13 == ushort.MaxValue);
			ASSUME(v.UShort14 == ushort.MinValue || v.UShort14 == ushort.MaxValue);
			ASSUME(v.UShort15 == ushort.MinValue || v.UShort15 == ushort.MaxValue);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_IS_MASK_EPI32(v256 v)
		{
			ASSUME(v.UInt0  == uint.MinValue || v.UInt0  == uint.MaxValue);
			ASSUME(v.UInt1  == uint.MinValue || v.UInt1  == uint.MaxValue);
			ASSUME(v.UInt2  == uint.MinValue || v.UInt2  == uint.MaxValue);
			ASSUME(v.UInt3  == uint.MinValue || v.UInt3  == uint.MaxValue);
			ASSUME(v.UInt4  == uint.MinValue || v.UInt4  == uint.MaxValue);
			ASSUME(v.UInt5  == uint.MinValue || v.UInt5  == uint.MaxValue);
			ASSUME(v.UInt6  == uint.MinValue || v.UInt6  == uint.MaxValue);
			ASSUME(v.UInt7  == uint.MinValue || v.UInt7  == uint.MaxValue);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_IS_MASK_EPI64(v256 v)
		{
			ASSUME(v.ULong0 == ulong.MinValue || v.ULong0 == ulong.MaxValue);
			ASSUME(v.ULong1 == ulong.MinValue || v.ULong1 == ulong.MaxValue);
			ASSUME(v.ULong2 == ulong.MinValue || v.ULong2 == ulong.MaxValue);
			ASSUME(v.ULong3 == ulong.MinValue || v.ULong3 == ulong.MaxValue);
		}


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
			ASSUME(math.isnan(v.Float0) || (v.Float0>= min && v.Float0 <= max));
			if (elements == 1) return;
			ASSUME(math.isnan(v.Float1) || (v.Float1>= min && v.Float1 <= max));
			if (elements == 2) return;
			ASSUME(math.isnan(v.Float2) || (v.Float2>= min && v.Float2 <= max));
			if (elements == 3) return;
			ASSUME(math.isnan(v.Float3) || (v.Float3>= min && v.Float3 <= max));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_RANGE_PD(v128 v, double min, double max, byte elements = 2)
		{
			ASSUME(math.isnan(v.Double0) || (v.Double0>= min && v.Double0 <= max));
			if (elements == 1) return;
			ASSUME(math.isnan(v.Double1) || (v.Double1>= min && v.Double1 <= max));
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
		public static void ASSUME_RANGE_EPU8(v256 v, uint min, uint max, byte elements = 32)
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
		public static void ASSUME_RANGE_EPU16(v256 v, uint min, uint max, byte elements = 16)
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
		public static void ASSUME_RANGE_EPU32(v256 v, uint min, uint max, byte elements = 8)
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
		public static void ASSUME_RANGE_EPU64(v256 v, ulong min, ulong max, byte elements = 4)
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
			ASSUME(math.isnan(v.Float0) || (v.Float0>= min && v.Float0 <= max));
			if (elements == 1) return;
			ASSUME(math.isnan(v.Float1) || (v.Float1>= min && v.Float1 <= max));
			ASSUME(math.isnan(v.Float2) || (v.Float2>= min && v.Float2 <= max));
			ASSUME(math.isnan(v.Float3) || (v.Float3>= min && v.Float3 <= max));
			ASSUME(math.isnan(v.Float4) || (v.Float4>= min && v.Float4 <= max));
			ASSUME(math.isnan(v.Float5) || (v.Float5>= min && v.Float5 <= max));
			ASSUME(math.isnan(v.Float6) || (v.Float6>= min && v.Float6 <= max));
			ASSUME(math.isnan(v.Float7) || (v.Float7>= min && v.Float7 <= max));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_RANGE_PD(v256 v, double min, double max, byte elements = 4)
		{
			ASSUME(math.isnan(v.Double0) || (v.Double0>= min && v.Double0 <= max));
			if (elements == 1) return;
			ASSUME(math.isnan(v.Double1) || (v.Double1>= min && v.Double1 <= max));
			ASSUME(math.isnan(v.Double2) || (v.Double2>= min && v.Double2 <= max));
			if (elements == 3) return;
			ASSUME(math.isnan(v.Double3) || (v.Double3>= min && v.Double3 <= max));
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
			ASSUME(math.isnan(v.Float0) || (v.Float0== cmpVal));
			if (elements == 1) return;
			ASSUME(math.isnan(v.Float1) || (v.Float1== cmpVal));
			if (elements == 2) return;
			ASSUME(math.isnan(v.Float2) || (v.Float2== cmpVal));
			if (elements == 3) return;
			ASSUME(math.isnan(v.Float3) || (v.Float3== cmpVal));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_EQ_PD(v128 v, double cmpVal, byte elements = 2)
		{
			ASSUME(math.isnan(v.Double0) || (v.Double0== cmpVal));
			if (elements == 1) return;
			ASSUME(math.isnan(v.Double1) || (v.Double1== cmpVal));
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
			ASSUME(math.isnan(v.Float0) || (v.Float0== cmpVal));
			if (elements == 1) return;
			ASSUME(math.isnan(v.Float1) || (v.Float1== cmpVal));
			ASSUME(math.isnan(v.Float2) || (v.Float2== cmpVal));
			ASSUME(math.isnan(v.Float3) || (v.Float3== cmpVal));
			ASSUME(math.isnan(v.Float4) || (v.Float4== cmpVal));
			ASSUME(math.isnan(v.Float5) || (v.Float5== cmpVal));
			ASSUME(math.isnan(v.Float6) || (v.Float6== cmpVal));
			ASSUME(math.isnan(v.Float7) || (v.Float7== cmpVal));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_EQ_PD(v256 v, double cmpVal, byte elements = 4)
		{
			ASSUME(math.isnan(v.Double0) || (v.Double0== cmpVal));
			if (elements == 1) return;
			ASSUME(math.isnan(v.Double1) || (v.Double1== cmpVal));
			ASSUME(math.isnan(v.Double2) || (v.Double2== cmpVal));
			if (elements == 3) return;
			ASSUME(math.isnan(v.Double3) || (v.Double3== cmpVal));
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
			ASSUME(math.isnan(v.Float0) || (v.Float0!= cmpVal));
			if (elements == 1) return;
			ASSUME(math.isnan(v.Float1) || (v.Float1!= cmpVal));
			if (elements == 2) return;
			ASSUME(math.isnan(v.Float2) || (v.Float2!= cmpVal));
			if (elements == 3) return;
			ASSUME(math.isnan(v.Float3) || (v.Float3!= cmpVal));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_NEQ_PD(v128 v, double cmpVal, byte elements = 2)
		{
			ASSUME(math.isnan(v.Double0) || (v.Double0!= cmpVal));
			if (elements == 1) return;
			ASSUME(math.isnan(v.Double1) || (v.Double1!= cmpVal));
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
			ASSUME(math.isnan(v.Float0) || (v.Float0!= cmpVal));
			if (elements == 1) return;
			ASSUME(math.isnan(v.Float1) || (v.Float1!= cmpVal));
			ASSUME(math.isnan(v.Float2) || (v.Float2!= cmpVal));
			ASSUME(math.isnan(v.Float3) || (v.Float3!= cmpVal));
			ASSUME(math.isnan(v.Float4) || (v.Float4!= cmpVal));
			ASSUME(math.isnan(v.Float5) || (v.Float5!= cmpVal));
			ASSUME(math.isnan(v.Float6) || (v.Float6!= cmpVal));
			ASSUME(math.isnan(v.Float7) || (v.Float7!= cmpVal));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_NEQ_PD(v256 v, double cmpVal, byte elements = 4)
		{
			ASSUME(math.isnan(v.Double0) || (v.Double0!= cmpVal));
			if (elements == 1) return;
			ASSUME(math.isnan(v.Double1) || (v.Double1!= cmpVal));
			ASSUME(math.isnan(v.Double2) || (v.Double2!= cmpVal));
			if (elements == 3) return;
			ASSUME(math.isnan(v.Double3) || (v.Double3!= cmpVal));
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
			ASSUME(math.isnan(v.Float0) || (v.Float0> cmpVal));
			if (elements == 1) return;
			ASSUME(math.isnan(v.Float1) || (v.Float1> cmpVal));
			if (elements == 2) return;
			ASSUME(math.isnan(v.Float2) || (v.Float2> cmpVal));
			if (elements == 3) return;
			ASSUME(math.isnan(v.Float3) || (v.Float3> cmpVal));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GT_PD(v128 v, double cmpVal, byte elements = 2)
		{
			ASSUME(math.isnan(v.Double0) || (v.Double0> cmpVal));
			if (elements == 1) return;
			ASSUME(math.isnan(v.Double1) || (v.Double1> cmpVal));
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
			ASSUME(math.isnan(v.Float0) || (v.Float0> cmpVal));
			if (elements == 1) return;
			ASSUME(math.isnan(v.Float1) || (v.Float1> cmpVal));
			ASSUME(math.isnan(v.Float2) || (v.Float2> cmpVal));
			ASSUME(math.isnan(v.Float3) || (v.Float3> cmpVal));
			ASSUME(math.isnan(v.Float4) || (v.Float4> cmpVal));
			ASSUME(math.isnan(v.Float5) || (v.Float5> cmpVal));
			ASSUME(math.isnan(v.Float6) || (v.Float6> cmpVal));
			ASSUME(math.isnan(v.Float7) || (v.Float7> cmpVal));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GT_PD(v256 v, double cmpVal, byte elements = 4)
		{
			ASSUME(math.isnan(v.Double0) || (v.Double0> cmpVal));
			if (elements == 1) return;
			ASSUME(math.isnan(v.Double1) || (v.Double1> cmpVal));
			ASSUME(math.isnan(v.Double2) || (v.Double2> cmpVal));
			if (elements == 3) return;
			ASSUME(math.isnan(v.Double3) || (v.Double3> cmpVal));
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
			ASSUME(math.isnan(v.Float0) || (v.Float0< cmpVal));
			if (elements == 1) return;
			ASSUME(math.isnan(v.Float1) || (v.Float1< cmpVal));
			if (elements == 2) return;
			ASSUME(math.isnan(v.Float2) || (v.Float2< cmpVal));
			if (elements == 3) return;
			ASSUME(math.isnan(v.Float3) || (v.Float3< cmpVal));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LT_PD(v128 v, double cmpVal, byte elements = 2)
		{
			ASSUME(math.isnan(v.Double0) || (v.Double0< cmpVal));
			if (elements == 1) return;
			ASSUME(math.isnan(v.Double1) || (v.Double1< cmpVal));
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
			ASSUME(math.isnan(v.Float0) || (v.Float0< cmpVal));
			if (elements == 1) return;
			ASSUME(math.isnan(v.Float1) || (v.Float1< cmpVal));
			ASSUME(math.isnan(v.Float2) || (v.Float2< cmpVal));
			ASSUME(math.isnan(v.Float3) || (v.Float3< cmpVal));
			ASSUME(math.isnan(v.Float4) || (v.Float4< cmpVal));
			ASSUME(math.isnan(v.Float5) || (v.Float5< cmpVal));
			ASSUME(math.isnan(v.Float6) || (v.Float6< cmpVal));
			ASSUME(math.isnan(v.Float7) || (v.Float7< cmpVal));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LT_PD(v256 v, double cmpVal, byte elements = 4)
		{
			ASSUME(math.isnan(v.Double0) || (v.Double0< cmpVal));
			if (elements == 1) return;
			ASSUME(math.isnan(v.Double1) || (v.Double1< cmpVal));
			ASSUME(math.isnan(v.Double2) || (v.Double2< cmpVal));
			if (elements == 3) return;
			ASSUME(math.isnan(v.Double3) || (v.Double3< cmpVal));
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
			ASSUME(math.isnan(v.Float0) || (v.Float0>= cmpVal));
			if (elements == 1) return;
			ASSUME(math.isnan(v.Float1) || (v.Float1>= cmpVal));
			if (elements == 2) return;
			ASSUME(math.isnan(v.Float2) || (v.Float2>= cmpVal));
			if (elements == 3) return;
			ASSUME(math.isnan(v.Float3) || (v.Float3>= cmpVal));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GE_PD(v128 v, double cmpVal, byte elements = 2)
		{
			ASSUME(math.isnan(v.Double0) || (v.Double0>= cmpVal));
			if (elements == 1) return;
			ASSUME(math.isnan(v.Double1) || (v.Double1>= cmpVal));
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
			ASSUME(math.isnan(v.Float0) || (v.Float0>= cmpVal));
			if (elements == 1) return;
			ASSUME(math.isnan(v.Float1) || (v.Float1>= cmpVal));
			ASSUME(math.isnan(v.Float2) || (v.Float2>= cmpVal));
			ASSUME(math.isnan(v.Float3) || (v.Float3>= cmpVal));
			ASSUME(math.isnan(v.Float4) || (v.Float4>= cmpVal));
			ASSUME(math.isnan(v.Float5) || (v.Float5>= cmpVal));
			ASSUME(math.isnan(v.Float6) || (v.Float6>= cmpVal));
			ASSUME(math.isnan(v.Float7) || (v.Float7>= cmpVal));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_GE_PD(v256 v, double cmpVal, byte elements = 4)
		{
			ASSUME(math.isnan(v.Double0) || (v.Double0>= cmpVal));
			if (elements == 1) return;
			ASSUME(math.isnan(v.Double1) || (v.Double1>= cmpVal));
			ASSUME(math.isnan(v.Double2) || (v.Double2>= cmpVal));
			if (elements == 3) return;
			ASSUME(math.isnan(v.Double3) || (v.Double3>= cmpVal));
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LE_EPU8(v128 v, byte cmpVal, byte elements = 16)
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
			ASSUME(math.isnan(v.Float0) || (v.Float0<= cmpVal));
			if (elements == 1) return;
			ASSUME(math.isnan(v.Float1) || (v.Float1<= cmpVal));
			if (elements == 2) return;
			ASSUME(math.isnan(v.Float2) || (v.Float2<= cmpVal));
			if (elements == 3) return;
			ASSUME(math.isnan(v.Float3) || (v.Float3<= cmpVal));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LE_PD(v128 v, double cmpVal, byte elements = 2)
		{
			ASSUME(math.isnan(v.Double0) || (v.Double0<= cmpVal));
			if (elements == 1) return;
			ASSUME(math.isnan(v.Double1) || (v.Double1<= cmpVal));
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
			ASSUME(math.isnan(v.Float0) || (v.Float0<= cmpVal));
			if (elements == 1) return;
			ASSUME(math.isnan(v.Float1) || (v.Float1<= cmpVal));
			ASSUME(math.isnan(v.Float2) || (v.Float2<= cmpVal));
			ASSUME(math.isnan(v.Float3) || (v.Float3<= cmpVal));
			ASSUME(math.isnan(v.Float4) || (v.Float4<= cmpVal));
			ASSUME(math.isnan(v.Float5) || (v.Float5<= cmpVal));
			ASSUME(math.isnan(v.Float6) || (v.Float6<= cmpVal));
			ASSUME(math.isnan(v.Float7) || (v.Float7<= cmpVal));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_LE_PD(v256 v, double cmpVal, byte elements = 4)
		{
			ASSUME(math.isnan(v.Double0) || (v.Double0<= cmpVal));
			if (elements == 1) return;
			ASSUME(math.isnan(v.Double1) || (v.Double1<= cmpVal));
			ASSUME(math.isnan(v.Double2) || (v.Double2<= cmpVal));
			if (elements == 3) return;
			ASSUME(math.isnan(v.Double3) || (v.Double3<= cmpVal));
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
				case  1: ASSUME(math.ispow2((uint)v.Byte0 ));	return;

				case  2: ASSUME(math.ispow2((uint)v.Byte0 ));
						 ASSUME(math.ispow2((uint)v.Byte1 ));	return;

				case  3: ASSUME(math.ispow2((uint)v.Byte0 ));
						 ASSUME(math.ispow2((uint)v.Byte1 ));
						 ASSUME(math.ispow2((uint)v.Byte2 ));	return;

				case  4: ASSUME(math.ispow2((uint)v.Byte0 ));
						 ASSUME(math.ispow2((uint)v.Byte1 ));
						 ASSUME(math.ispow2((uint)v.Byte2 ));
						 ASSUME(math.ispow2((uint)v.Byte3 ));	return;

				case  8: ASSUME(math.ispow2((uint)v.Byte0 ));
						 ASSUME(math.ispow2((uint)v.Byte1 ));
						 ASSUME(math.ispow2((uint)v.Byte2 ));
						 ASSUME(math.ispow2((uint)v.Byte3 ));
						 ASSUME(math.ispow2((uint)v.Byte4 ));
						 ASSUME(math.ispow2((uint)v.Byte5 ));
						 ASSUME(math.ispow2((uint)v.Byte6 ));
						 ASSUME(math.ispow2((uint)v.Byte7 ));	return;

				default: ASSUME(math.ispow2((uint)v.Byte0 ));
						 ASSUME(math.ispow2((uint)v.Byte1 ));
						 ASSUME(math.ispow2((uint)v.Byte2 ));
						 ASSUME(math.ispow2((uint)v.Byte3 ));
						 ASSUME(math.ispow2((uint)v.Byte4 ));
						 ASSUME(math.ispow2((uint)v.Byte5 ));
						 ASSUME(math.ispow2((uint)v.Byte6 ));
						 ASSUME(math.ispow2((uint)v.Byte7 ));
						 ASSUME(math.ispow2((uint)v.Byte8 ));
						 ASSUME(math.ispow2((uint)v.Byte9 ));
						 ASSUME(math.ispow2((uint)v.Byte10));
						 ASSUME(math.ispow2((uint)v.Byte11));
						 ASSUME(math.ispow2((uint)v.Byte12));
						 ASSUME(math.ispow2((uint)v.Byte13));
						 ASSUME(math.ispow2((uint)v.Byte14));
						 ASSUME(math.ispow2((uint)v.Byte15));	return;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_POW2_EPU16(v128 v, byte elements = 8)
		{
			switch (elements)
			{
				case  1: ASSUME(math.ispow2((uint)v.UShort0));	return;

				case  2: ASSUME(math.ispow2((uint)v.UShort0));
						 ASSUME(math.ispow2((uint)v.UShort1));	return;

				case  3: ASSUME(math.ispow2((uint)v.UShort0));
						 ASSUME(math.ispow2((uint)v.UShort1));
						 ASSUME(math.ispow2((uint)v.UShort2));	return;

				case  4: ASSUME(math.ispow2((uint)v.UShort0));
						 ASSUME(math.ispow2((uint)v.UShort1));
						 ASSUME(math.ispow2((uint)v.UShort2));
						 ASSUME(math.ispow2((uint)v.UShort3));	return;

				default: ASSUME(math.ispow2((uint)v.UShort0));
						 ASSUME(math.ispow2((uint)v.UShort1));
						 ASSUME(math.ispow2((uint)v.UShort2));
						 ASSUME(math.ispow2((uint)v.UShort3));
						 ASSUME(math.ispow2((uint)v.UShort4));
						 ASSUME(math.ispow2((uint)v.UShort5));
						 ASSUME(math.ispow2((uint)v.UShort6));
						 ASSUME(math.ispow2((uint)v.UShort7));	return;
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
				ASSUME(math.countbits(v.ULong0) == 1);
            }
			else
			{
				ASSUME(math.countbits(v.ULong0) == 1);
				ASSUME(math.countbits(v.ULong1) == 1);
			}
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_POW2_EPI8(v128 v, byte elements = 16)
		{
			switch (elements)
			{
				case  1: ASSUME(math.ispow2(v.SByte0 ));	return;

				case  2: ASSUME(math.ispow2(v.SByte0 ));
						 ASSUME(math.ispow2(v.SByte1 ));	return;

				case  3: ASSUME(math.ispow2(v.SByte0 ));
						 ASSUME(math.ispow2(v.SByte1 ));
						 ASSUME(math.ispow2(v.SByte2 ));	return;

				case  4: ASSUME(math.ispow2(v.SByte0 ));
						 ASSUME(math.ispow2(v.SByte1 ));
						 ASSUME(math.ispow2(v.SByte2 ));
						 ASSUME(math.ispow2(v.SByte3 ));	return;

				case  8: ASSUME(math.ispow2(v.SByte0 ));
						 ASSUME(math.ispow2(v.SByte1 ));
						 ASSUME(math.ispow2(v.SByte2 ));
						 ASSUME(math.ispow2(v.SByte3 ));
						 ASSUME(math.ispow2(v.SByte4 ));
						 ASSUME(math.ispow2(v.SByte5 ));
						 ASSUME(math.ispow2(v.SByte6 ));
						 ASSUME(math.ispow2(v.SByte7 ));	return;

				default: ASSUME(math.ispow2(v.SByte0 ));
						 ASSUME(math.ispow2(v.SByte1 ));
						 ASSUME(math.ispow2(v.SByte2 ));
						 ASSUME(math.ispow2(v.SByte3 ));
						 ASSUME(math.ispow2(v.SByte4 ));
						 ASSUME(math.ispow2(v.SByte5 ));
						 ASSUME(math.ispow2(v.SByte6 ));
						 ASSUME(math.ispow2(v.SByte7 ));
						 ASSUME(math.ispow2(v.SByte8 ));
						 ASSUME(math.ispow2(v.SByte9 ));
						 ASSUME(math.ispow2(v.SByte10));
						 ASSUME(math.ispow2(v.SByte11));
						 ASSUME(math.ispow2(v.SByte12));
						 ASSUME(math.ispow2(v.SByte13));
						 ASSUME(math.ispow2(v.SByte14));
						 ASSUME(math.ispow2(v.SByte15));	return;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_POW2_EPI16(v128 v, byte elements = 8)
		{
			switch (elements)
			{
				case  1: ASSUME(math.ispow2(v.SShort0));	return;

				case  2: ASSUME(math.ispow2(v.SShort0));
						 ASSUME(math.ispow2(v.SShort1));	return;

				case  3: ASSUME(math.ispow2(v.SShort0));
						 ASSUME(math.ispow2(v.SShort1));
						 ASSUME(math.ispow2(v.SShort2));	return;

				case  4: ASSUME(math.ispow2(v.SShort0));
						 ASSUME(math.ispow2(v.SShort1));
						 ASSUME(math.ispow2(v.SShort2));
						 ASSUME(math.ispow2(v.SShort3));	return;

				default: ASSUME(math.ispow2(v.SShort0));
						 ASSUME(math.ispow2(v.SShort1));
						 ASSUME(math.ispow2(v.SShort2));
						 ASSUME(math.ispow2(v.SShort3));
						 ASSUME(math.ispow2(v.SShort4));
						 ASSUME(math.ispow2(v.SShort5));
						 ASSUME(math.ispow2(v.SShort6));
						 ASSUME(math.ispow2(v.SShort7));	return;
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
				ASSUME(math.countbits(v.SLong0) == 1);
            }
			else
			{
				ASSUME(math.countbits(v.SLong0) == 1);
				ASSUME(math.countbits(v.SLong1) == 1);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_POW2_EPU8(v256 v)
		{
			ASSUME(math.ispow2((uint)v.Byte0 ));
			ASSUME(math.ispow2((uint)v.Byte1 ));
			ASSUME(math.ispow2((uint)v.Byte2 ));
			ASSUME(math.ispow2((uint)v.Byte3 ));
			ASSUME(math.ispow2((uint)v.Byte4 ));
			ASSUME(math.ispow2((uint)v.Byte5 ));
			ASSUME(math.ispow2((uint)v.Byte6 ));
			ASSUME(math.ispow2((uint)v.Byte7 ));
			ASSUME(math.ispow2((uint)v.Byte8 ));
			ASSUME(math.ispow2((uint)v.Byte9 ));
			ASSUME(math.ispow2((uint)v.Byte10));
			ASSUME(math.ispow2((uint)v.Byte11));
			ASSUME(math.ispow2((uint)v.Byte12));
			ASSUME(math.ispow2((uint)v.Byte13));
			ASSUME(math.ispow2((uint)v.Byte14));
			ASSUME(math.ispow2((uint)v.Byte15));
			ASSUME(math.ispow2((uint)v.Byte16));
			ASSUME(math.ispow2((uint)v.Byte17));
			ASSUME(math.ispow2((uint)v.Byte18));
			ASSUME(math.ispow2((uint)v.Byte19));
			ASSUME(math.ispow2((uint)v.Byte20));
			ASSUME(math.ispow2((uint)v.Byte21));
			ASSUME(math.ispow2((uint)v.Byte22));
			ASSUME(math.ispow2((uint)v.Byte23));
			ASSUME(math.ispow2((uint)v.Byte24));
			ASSUME(math.ispow2((uint)v.Byte25));
			ASSUME(math.ispow2((uint)v.Byte26));
			ASSUME(math.ispow2((uint)v.Byte27));
			ASSUME(math.ispow2((uint)v.Byte28));
			ASSUME(math.ispow2((uint)v.Byte29));
			ASSUME(math.ispow2((uint)v.Byte30));
			ASSUME(math.ispow2((uint)v.Byte31));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_POW2_EPU16(v256 v)
		{
			ASSUME(math.ispow2((uint)v.UShort0 ));
			ASSUME(math.ispow2((uint)v.UShort1 ));
			ASSUME(math.ispow2((uint)v.UShort2 ));
			ASSUME(math.ispow2((uint)v.UShort3 ));
			ASSUME(math.ispow2((uint)v.UShort4 ));
			ASSUME(math.ispow2((uint)v.UShort5 ));
			ASSUME(math.ispow2((uint)v.UShort6 ));
			ASSUME(math.ispow2((uint)v.UShort7 ));
			ASSUME(math.ispow2((uint)v.UShort8 ));
			ASSUME(math.ispow2((uint)v.UShort9 ));
			ASSUME(math.ispow2((uint)v.UShort10));
			ASSUME(math.ispow2((uint)v.UShort11));
			ASSUME(math.ispow2((uint)v.UShort12));
			ASSUME(math.ispow2((uint)v.UShort13));
			ASSUME(math.ispow2((uint)v.UShort14));
			ASSUME(math.ispow2((uint)v.UShort15));
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
				ASSUME(math.countbits(v.ULong0) == 1);
				ASSUME(math.countbits(v.ULong1) == 1);
				ASSUME(math.countbits(v.ULong2) == 1);
			}
			else
			{
				ASSUME(math.countbits(v.ULong0) == 1);
				ASSUME(math.countbits(v.ULong1) == 1);
				ASSUME(math.countbits(v.ULong2) == 1);
				ASSUME(math.countbits(v.ULong3) == 1);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_POW2_EPI8(v256 v)
		{
			ASSUME(math.ispow2(v.SByte0 ));
			ASSUME(math.ispow2(v.SByte1 ));
			ASSUME(math.ispow2(v.SByte2 ));
			ASSUME(math.ispow2(v.SByte3 ));
			ASSUME(math.ispow2(v.SByte4 ));
			ASSUME(math.ispow2(v.SByte5 ));
			ASSUME(math.ispow2(v.SByte6 ));
			ASSUME(math.ispow2(v.SByte7 ));
			ASSUME(math.ispow2(v.SByte8 ));
			ASSUME(math.ispow2(v.SByte9 ));
			ASSUME(math.ispow2(v.SByte10));
			ASSUME(math.ispow2(v.SByte11));
			ASSUME(math.ispow2(v.SByte12));
			ASSUME(math.ispow2(v.SByte13));
			ASSUME(math.ispow2(v.SByte14));
			ASSUME(math.ispow2(v.SByte15));
			ASSUME(math.ispow2(v.SByte16));
			ASSUME(math.ispow2(v.SByte17));
			ASSUME(math.ispow2(v.SByte18));
			ASSUME(math.ispow2(v.SByte19));
			ASSUME(math.ispow2(v.SByte20));
			ASSUME(math.ispow2(v.SByte21));
			ASSUME(math.ispow2(v.SByte22));
			ASSUME(math.ispow2(v.SByte23));
			ASSUME(math.ispow2(v.SByte24));
			ASSUME(math.ispow2(v.SByte25));
			ASSUME(math.ispow2(v.SByte26));
			ASSUME(math.ispow2(v.SByte27));
			ASSUME(math.ispow2(v.SByte28));
			ASSUME(math.ispow2(v.SByte29));
			ASSUME(math.ispow2(v.SByte30));
			ASSUME(math.ispow2(v.SByte31));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_POW2_EPI16(v256 v)
		{
			ASSUME(math.ispow2(v.SShort0 ));
			ASSUME(math.ispow2(v.SShort1 ));
			ASSUME(math.ispow2(v.SShort2 ));
			ASSUME(math.ispow2(v.SShort3 ));
			ASSUME(math.ispow2(v.SShort4 ));
			ASSUME(math.ispow2(v.SShort5 ));
			ASSUME(math.ispow2(v.SShort6 ));
			ASSUME(math.ispow2(v.SShort7 ));
			ASSUME(math.ispow2(v.SShort8 ));
			ASSUME(math.ispow2(v.SShort9 ));
			ASSUME(math.ispow2(v.SShort10));
			ASSUME(math.ispow2(v.SShort11));
			ASSUME(math.ispow2(v.SShort12));
			ASSUME(math.ispow2(v.SShort13));
			ASSUME(math.ispow2(v.SShort14));
			ASSUME(math.ispow2(v.SShort15));
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
				ASSUME(math.countbits(v.SLong0) == 1);
				ASSUME(math.countbits(v.SLong1) == 1);
				ASSUME(math.countbits(v.SLong2) == 1);
			}
			else
			{
				ASSUME(math.countbits(v.SLong0) == 1);
				ASSUME(math.countbits(v.SLong1) == 1);
				ASSUME(math.countbits(v.SLong2) == 1);
				ASSUME(math.countbits(v.SLong3) == 1);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_NONE_POW2_EPU8(v128 v, byte elements = 16)
		{
			switch (elements)
			{
				case  1: ASSUME(!math.ispow2((uint)v.Byte0 ));	return;

				case  2: ASSUME(!math.ispow2((uint)v.Byte0 ));
						 ASSUME(!math.ispow2((uint)v.Byte1 ));	return;

				case  3: ASSUME(!math.ispow2((uint)v.Byte0 ));
						 ASSUME(!math.ispow2((uint)v.Byte1 ));
						 ASSUME(!math.ispow2((uint)v.Byte2 ));	return;

				case  4: ASSUME(!math.ispow2((uint)v.Byte0 ));
						 ASSUME(!math.ispow2((uint)v.Byte1 ));
						 ASSUME(!math.ispow2((uint)v.Byte2 ));
						 ASSUME(!math.ispow2((uint)v.Byte3 ));	return;

				case  8: ASSUME(!math.ispow2((uint)v.Byte0 ));
						 ASSUME(!math.ispow2((uint)v.Byte1 ));
						 ASSUME(!math.ispow2((uint)v.Byte2 ));
						 ASSUME(!math.ispow2((uint)v.Byte3 ));
						 ASSUME(!math.ispow2((uint)v.Byte4 ));
						 ASSUME(!math.ispow2((uint)v.Byte5 ));
						 ASSUME(!math.ispow2((uint)v.Byte6 ));
						 ASSUME(!math.ispow2((uint)v.Byte7 ));	return;

				default: ASSUME(!math.ispow2((uint)v.Byte0 ));
						 ASSUME(!math.ispow2((uint)v.Byte1 ));
						 ASSUME(!math.ispow2((uint)v.Byte2 ));
						 ASSUME(!math.ispow2((uint)v.Byte3 ));
						 ASSUME(!math.ispow2((uint)v.Byte4 ));
						 ASSUME(!math.ispow2((uint)v.Byte5 ));
						 ASSUME(!math.ispow2((uint)v.Byte6 ));
						 ASSUME(!math.ispow2((uint)v.Byte7 ));
						 ASSUME(!math.ispow2((uint)v.Byte8 ));
						 ASSUME(!math.ispow2((uint)v.Byte9 ));
						 ASSUME(!math.ispow2((uint)v.Byte10));
						 ASSUME(!math.ispow2((uint)v.Byte11));
						 ASSUME(!math.ispow2((uint)v.Byte12));
						 ASSUME(!math.ispow2((uint)v.Byte13));
						 ASSUME(!math.ispow2((uint)v.Byte14));
						 ASSUME(!math.ispow2((uint)v.Byte15));	return;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_NONE_POW2_EPU16(v128 v, byte elements = 8)
		{
			switch (elements)
			{
				case  1: ASSUME(!math.ispow2((uint)v.UShort0));	return;

				case  2: ASSUME(!math.ispow2((uint)v.UShort0));
						 ASSUME(!math.ispow2((uint)v.UShort1));	return;

				case  3: ASSUME(!math.ispow2((uint)v.UShort0));
						 ASSUME(!math.ispow2((uint)v.UShort1));
						 ASSUME(!math.ispow2((uint)v.UShort2));	return;

				case  4: ASSUME(!math.ispow2((uint)v.UShort0));
						 ASSUME(!math.ispow2((uint)v.UShort1));
						 ASSUME(!math.ispow2((uint)v.UShort2));
						 ASSUME(!math.ispow2((uint)v.UShort3));	return;

				default: ASSUME(!math.ispow2((uint)v.UShort0));
						 ASSUME(!math.ispow2((uint)v.UShort1));
						 ASSUME(!math.ispow2((uint)v.UShort2));
						 ASSUME(!math.ispow2((uint)v.UShort3));
						 ASSUME(!math.ispow2((uint)v.UShort4));
						 ASSUME(!math.ispow2((uint)v.UShort5));
						 ASSUME(!math.ispow2((uint)v.UShort6));
						 ASSUME(!math.ispow2((uint)v.UShort7));	return;
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
				ASSUME(math.countbits(v.ULong0) != 1);
            }
			else
			{
				ASSUME(math.countbits(v.ULong0) != 1);
				ASSUME(math.countbits(v.ULong1) != 1);
			}
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_NONE_POW2_EPI8(v128 v, byte elements = 16)
		{
			switch (elements)
			{
				case  1: ASSUME(!math.ispow2(v.SByte0 ));	return;

				case  2: ASSUME(!math.ispow2(v.SByte0 ));
						 ASSUME(!math.ispow2(v.SByte1 ));	return;

				case  3: ASSUME(!math.ispow2(v.SByte0 ));
						 ASSUME(!math.ispow2(v.SByte1 ));
						 ASSUME(!math.ispow2(v.SByte2 ));	return;

				case  4: ASSUME(!math.ispow2(v.SByte0 ));
						 ASSUME(!math.ispow2(v.SByte1 ));
						 ASSUME(!math.ispow2(v.SByte2 ));
						 ASSUME(!math.ispow2(v.SByte3 ));	return;

				case  8: ASSUME(!math.ispow2(v.SByte0 ));
						 ASSUME(!math.ispow2(v.SByte1 ));
						 ASSUME(!math.ispow2(v.SByte2 ));
						 ASSUME(!math.ispow2(v.SByte3 ));
						 ASSUME(!math.ispow2(v.SByte4 ));
						 ASSUME(!math.ispow2(v.SByte5 ));
						 ASSUME(!math.ispow2(v.SByte6 ));
						 ASSUME(!math.ispow2(v.SByte7 ));	return;

				default: ASSUME(!math.ispow2(v.SByte0 ));
						 ASSUME(!math.ispow2(v.SByte1 ));
						 ASSUME(!math.ispow2(v.SByte2 ));
						 ASSUME(!math.ispow2(v.SByte3 ));
						 ASSUME(!math.ispow2(v.SByte4 ));
						 ASSUME(!math.ispow2(v.SByte5 ));
						 ASSUME(!math.ispow2(v.SByte6 ));
						 ASSUME(!math.ispow2(v.SByte7 ));
						 ASSUME(!math.ispow2(v.SByte8 ));
						 ASSUME(!math.ispow2(v.SByte9 ));
						 ASSUME(!math.ispow2(v.SByte10));
						 ASSUME(!math.ispow2(v.SByte11));
						 ASSUME(!math.ispow2(v.SByte12));
						 ASSUME(!math.ispow2(v.SByte13));
						 ASSUME(!math.ispow2(v.SByte14));
						 ASSUME(!math.ispow2(v.SByte15));	return;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_NONE_POW2_EPI16(v128 v, byte elements = 8)
		{
			switch (elements)
			{
				case  1: ASSUME(!math.ispow2(v.SShort0));	return;

				case  2: ASSUME(!math.ispow2(v.SShort0));
						 ASSUME(!math.ispow2(v.SShort1));	return;

				case  3: ASSUME(!math.ispow2(v.SShort0));
						 ASSUME(!math.ispow2(v.SShort1));
						 ASSUME(!math.ispow2(v.SShort2));	return;

				case  4: ASSUME(!math.ispow2(v.SShort0));
						 ASSUME(!math.ispow2(v.SShort1));
						 ASSUME(!math.ispow2(v.SShort2));
						 ASSUME(!math.ispow2(v.SShort3));	return;

				default: ASSUME(!math.ispow2(v.SShort0));
						 ASSUME(!math.ispow2(v.SShort1));
						 ASSUME(!math.ispow2(v.SShort2));
						 ASSUME(!math.ispow2(v.SShort3));
						 ASSUME(!math.ispow2(v.SShort4));
						 ASSUME(!math.ispow2(v.SShort5));
						 ASSUME(!math.ispow2(v.SShort6));
						 ASSUME(!math.ispow2(v.SShort7));	return;
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
				ASSUME(math.countbits(v.SLong0) != 1);
            }
			else
			{
				ASSUME(math.countbits(v.SLong0) != 1);
				ASSUME(math.countbits(v.SLong1) != 1);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_NONE_POW2_EPU8(v256 v)
		{
			ASSUME(!math.ispow2((uint)v.Byte0 ));
			ASSUME(!math.ispow2((uint)v.Byte1 ));
			ASSUME(!math.ispow2((uint)v.Byte2 ));
			ASSUME(!math.ispow2((uint)v.Byte3 ));
			ASSUME(!math.ispow2((uint)v.Byte4 ));
			ASSUME(!math.ispow2((uint)v.Byte5 ));
			ASSUME(!math.ispow2((uint)v.Byte6 ));
			ASSUME(!math.ispow2((uint)v.Byte7 ));
			ASSUME(!math.ispow2((uint)v.Byte8 ));
			ASSUME(!math.ispow2((uint)v.Byte9 ));
			ASSUME(!math.ispow2((uint)v.Byte10));
			ASSUME(!math.ispow2((uint)v.Byte11));
			ASSUME(!math.ispow2((uint)v.Byte12));
			ASSUME(!math.ispow2((uint)v.Byte13));
			ASSUME(!math.ispow2((uint)v.Byte14));
			ASSUME(!math.ispow2((uint)v.Byte15));
			ASSUME(!math.ispow2((uint)v.Byte16));
			ASSUME(!math.ispow2((uint)v.Byte17));
			ASSUME(!math.ispow2((uint)v.Byte18));
			ASSUME(!math.ispow2((uint)v.Byte19));
			ASSUME(!math.ispow2((uint)v.Byte20));
			ASSUME(!math.ispow2((uint)v.Byte21));
			ASSUME(!math.ispow2((uint)v.Byte22));
			ASSUME(!math.ispow2((uint)v.Byte23));
			ASSUME(!math.ispow2((uint)v.Byte24));
			ASSUME(!math.ispow2((uint)v.Byte25));
			ASSUME(!math.ispow2((uint)v.Byte26));
			ASSUME(!math.ispow2((uint)v.Byte27));
			ASSUME(!math.ispow2((uint)v.Byte28));
			ASSUME(!math.ispow2((uint)v.Byte29));
			ASSUME(!math.ispow2((uint)v.Byte30));
			ASSUME(!math.ispow2((uint)v.Byte31));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_NONE_POW2_EPU16(v256 v)
		{
			ASSUME(!math.ispow2((uint)v.UShort0 ));
			ASSUME(!math.ispow2((uint)v.UShort1 ));
			ASSUME(!math.ispow2((uint)v.UShort2 ));
			ASSUME(!math.ispow2((uint)v.UShort3 ));
			ASSUME(!math.ispow2((uint)v.UShort4 ));
			ASSUME(!math.ispow2((uint)v.UShort5 ));
			ASSUME(!math.ispow2((uint)v.UShort6 ));
			ASSUME(!math.ispow2((uint)v.UShort7 ));
			ASSUME(!math.ispow2((uint)v.UShort8 ));
			ASSUME(!math.ispow2((uint)v.UShort9 ));
			ASSUME(!math.ispow2((uint)v.UShort10));
			ASSUME(!math.ispow2((uint)v.UShort11));
			ASSUME(!math.ispow2((uint)v.UShort12));
			ASSUME(!math.ispow2((uint)v.UShort13));
			ASSUME(!math.ispow2((uint)v.UShort14));
			ASSUME(!math.ispow2((uint)v.UShort15));
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
				ASSUME(math.countbits(v.ULong0) != 1);
				ASSUME(math.countbits(v.ULong1) != 1);
				ASSUME(math.countbits(v.ULong2) != 1);
			}
			else
			{
				ASSUME(math.countbits(v.ULong0) != 1);
				ASSUME(math.countbits(v.ULong1) != 1);
				ASSUME(math.countbits(v.ULong2) != 1);
				ASSUME(math.countbits(v.ULong3) != 1);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_NONE_POW2_EPI8(v256 v)
		{
			ASSUME(!math.ispow2(v.SByte0 ));
			ASSUME(!math.ispow2(v.SByte1 ));
			ASSUME(!math.ispow2(v.SByte2 ));
			ASSUME(!math.ispow2(v.SByte3 ));
			ASSUME(!math.ispow2(v.SByte4 ));
			ASSUME(!math.ispow2(v.SByte5 ));
			ASSUME(!math.ispow2(v.SByte6 ));
			ASSUME(!math.ispow2(v.SByte7 ));
			ASSUME(!math.ispow2(v.SByte8 ));
			ASSUME(!math.ispow2(v.SByte9 ));
			ASSUME(!math.ispow2(v.SByte10));
			ASSUME(!math.ispow2(v.SByte11));
			ASSUME(!math.ispow2(v.SByte12));
			ASSUME(!math.ispow2(v.SByte13));
			ASSUME(!math.ispow2(v.SByte14));
			ASSUME(!math.ispow2(v.SByte15));
			ASSUME(!math.ispow2(v.SByte16));
			ASSUME(!math.ispow2(v.SByte17));
			ASSUME(!math.ispow2(v.SByte18));
			ASSUME(!math.ispow2(v.SByte19));
			ASSUME(!math.ispow2(v.SByte20));
			ASSUME(!math.ispow2(v.SByte21));
			ASSUME(!math.ispow2(v.SByte22));
			ASSUME(!math.ispow2(v.SByte23));
			ASSUME(!math.ispow2(v.SByte24));
			ASSUME(!math.ispow2(v.SByte25));
			ASSUME(!math.ispow2(v.SByte26));
			ASSUME(!math.ispow2(v.SByte27));
			ASSUME(!math.ispow2(v.SByte28));
			ASSUME(!math.ispow2(v.SByte29));
			ASSUME(!math.ispow2(v.SByte30));
			ASSUME(!math.ispow2(v.SByte31));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_NONE_POW2_EPI16(v256 v)
		{
			ASSUME(!math.ispow2(v.SShort0 ));
			ASSUME(!math.ispow2(v.SShort1 ));
			ASSUME(!math.ispow2(v.SShort2 ));
			ASSUME(!math.ispow2(v.SShort3 ));
			ASSUME(!math.ispow2(v.SShort4 ));
			ASSUME(!math.ispow2(v.SShort5 ));
			ASSUME(!math.ispow2(v.SShort6 ));
			ASSUME(!math.ispow2(v.SShort7 ));
			ASSUME(!math.ispow2(v.SShort8 ));
			ASSUME(!math.ispow2(v.SShort9 ));
			ASSUME(!math.ispow2(v.SShort10));
			ASSUME(!math.ispow2(v.SShort11));
			ASSUME(!math.ispow2(v.SShort12));
			ASSUME(!math.ispow2(v.SShort13));
			ASSUME(!math.ispow2(v.SShort14));
			ASSUME(!math.ispow2(v.SShort15));
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
				ASSUME(math.countbits(v.SLong0) != 1);
				ASSUME(math.countbits(v.SLong1) != 1);
				ASSUME(math.countbits(v.SLong2) != 1);
			}
			else
			{
				ASSUME(math.countbits(v.SLong0) != 1);
				ASSUME(math.countbits(v.SLong1) != 1);
				ASSUME(math.countbits(v.SLong2) != 1);
				ASSUME(math.countbits(v.SLong3) != 1);
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
				case  1: ASSUME(a.UInt0  <= b.UInt0);	return;

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


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_MULTIPLICATION_EPI8(v128 v, v128 a, v128 b, byte elements = 16)
		{
			ASSUME(v.SByte0 == (sbyte)(a.SByte0 * b.SByte0));
			if (elements == 1) return;
			ASSUME(v.SByte1 == (sbyte)(a.SByte1 * b.SByte1));
			if (elements == 2) return;
			ASSUME(v.SByte2 == (sbyte)(a.SByte2 * b.SByte2));
			if (elements == 3) return;
			ASSUME(v.SByte3 == (sbyte)(a.SByte3 * b.SByte3));
			if (elements == 4) return;
			ASSUME(v.SByte4 == (sbyte)(a.SByte4 * b.SByte4));
			ASSUME(v.SByte5 == (sbyte)(a.SByte5 * b.SByte5));
			ASSUME(v.SByte6 == (sbyte)(a.SByte6 * b.SByte6));
			ASSUME(v.SByte7 == (sbyte)(a.SByte7 * b.SByte7));
			if (elements == 8) return;
			ASSUME(v.SByte8 == (sbyte)(a.SByte8 * b.SByte8));
			ASSUME(v.SByte9 == (sbyte)(a.SByte9 * b.SByte9));
			ASSUME(v.SByte10 == (sbyte)(a.SByte10 * b.SByte10));
			ASSUME(v.SByte11 == (sbyte)(a.SByte11 * b.SByte11));
			ASSUME(v.SByte12 == (sbyte)(a.SByte12 * b.SByte12));
			ASSUME(v.SByte13 == (sbyte)(a.SByte13 * b.SByte13));
			ASSUME(v.SByte14 == (sbyte)(a.SByte14 * b.SByte14));
			ASSUME(v.SByte15 == (sbyte)(a.SByte15 * b.SByte15));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_MULTIPLICATION_EPI16(v128 v, v128 a, v128 b, byte elements = 8)
		{
			ASSUME(v.SShort0 == (short)(a.SShort0 * b.SShort0));
			if (elements == 1) return;
			ASSUME(v.SShort1 == (short)(a.SShort1 * b.SShort1));
			if (elements == 2) return;
			ASSUME(v.SShort2 == (short)(a.SShort2 * b.SShort2));
			if (elements == 3) return;
			ASSUME(v.SShort3 == (short)(a.SShort3 * b.SShort3));
			if (elements == 4) return;
			ASSUME(v.SShort4 == (short)(a.SShort4 * b.SShort4));
			ASSUME(v.SShort5 == (short)(a.SShort5 * b.SShort5));
			ASSUME(v.SShort6 == (short)(a.SShort6 * b.SShort6));
			ASSUME(v.SShort7 == (short)(a.SShort7 * b.SShort7));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_MULTIPLICATION_EPI32(v128 v, v128 a, v128 b, byte elements = 4)
		{
			ASSUME(v.SInt0 == a.SInt0 * b.SInt0);
			if (elements == 1) return;
			ASSUME(v.SInt1 == a.SInt1 * b.SInt1);
			if (elements == 2) return;
			ASSUME(v.SInt2 == a.SInt2 * b.SInt2);
			if (elements == 3) return;
			ASSUME(v.SInt3 == a.SInt3 * b.SInt3);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_MULTIPLICATION_EPI64(v128 v, v128 a, v128 b, byte elements = 2)
		{
			ASSUME(v.SLong0 == a.SLong0 * b.SLong0);
			if (elements == 1) return;
			ASSUME(v.SLong1 == a.SLong1 * b.SLong1);
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_MULTIPLICATION_EPI8(v256 v, v256 a, v256 b, byte elements = 32)
		{
			ASSUME(v.SByte0 == (sbyte)(a.SByte0 * b.SByte0));
			if (elements == 1) return;
			ASSUME(v.SByte1 == (sbyte)(a.SByte1 * b.SByte1));
			ASSUME(v.SByte2 == (sbyte)(a.SByte2 * b.SByte2));
			ASSUME(v.SByte3 == (sbyte)(a.SByte3 * b.SByte3));
			ASSUME(v.SByte4 == (sbyte)(a.SByte4 * b.SByte4));
			ASSUME(v.SByte5 == (sbyte)(a.SByte5 * b.SByte5));
			ASSUME(v.SByte6 == (sbyte)(a.SByte6 * b.SByte6));
			ASSUME(v.SByte7 == (sbyte)(a.SByte7 * b.SByte7));
			ASSUME(v.SByte8 == (sbyte)(a.SByte8 * b.SByte8));
			ASSUME(v.SByte9 == (sbyte)(a.SByte9 * b.SByte9));
			ASSUME(v.SByte10 == (sbyte)(a.SByte10 * b.SByte10));
			ASSUME(v.SByte11 == (sbyte)(a.SByte11 * b.SByte11));
			ASSUME(v.SByte12 == (sbyte)(a.SByte12 * b.SByte12));
			ASSUME(v.SByte13 == (sbyte)(a.SByte13 * b.SByte13));
			ASSUME(v.SByte14 == (sbyte)(a.SByte14 * b.SByte14));
			ASSUME(v.SByte15 == (sbyte)(a.SByte15 * b.SByte15));
			ASSUME(v.SByte16 == (sbyte)(a.SByte16 * b.SByte16));
			ASSUME(v.SByte17 == (sbyte)(a.SByte17 * b.SByte17));
			ASSUME(v.SByte18 == (sbyte)(a.SByte18 * b.SByte18));
			ASSUME(v.SByte19 == (sbyte)(a.SByte19 * b.SByte19));
			ASSUME(v.SByte20 == (sbyte)(a.SByte20 * b.SByte20));
			ASSUME(v.SByte21 == (sbyte)(a.SByte21 * b.SByte21));
			ASSUME(v.SByte22 == (sbyte)(a.SByte22 * b.SByte22));
			ASSUME(v.SByte23 == (sbyte)(a.SByte23 * b.SByte23));
			ASSUME(v.SByte24 == (sbyte)(a.SByte24 * b.SByte24));
			ASSUME(v.SByte25 == (sbyte)(a.SByte25 * b.SByte25));
			ASSUME(v.SByte26 == (sbyte)(a.SByte26 * b.SByte26));
			ASSUME(v.SByte27 == (sbyte)(a.SByte27 * b.SByte27));
			ASSUME(v.SByte28 == (sbyte)(a.SByte28 * b.SByte28));
			ASSUME(v.SByte29 == (sbyte)(a.SByte29 * b.SByte29));
			ASSUME(v.SByte30 == (sbyte)(a.SByte30 * b.SByte30));
			ASSUME(v.SByte31 == (sbyte)(a.SByte31 * b.SByte31));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_MULTIPLICATION_EPI16(v256 v, v256 a, v256 b, byte elements = 16)
		{
			ASSUME(v.SShort0 == (short)(a.SShort0 * b.SShort0));
			if (elements == 1) return;
			ASSUME(v.SShort1 == (short)(a.SShort1 * b.SShort1));
			ASSUME(v.SShort2 == (short)(a.SShort2 * b.SShort2));
			ASSUME(v.SShort3 == (short)(a.SShort3 * b.SShort3));
			ASSUME(v.SShort4 == (short)(a.SShort4 * b.SShort4));
			ASSUME(v.SShort5 == (short)(a.SShort5 * b.SShort5));
			ASSUME(v.SShort6 == (short)(a.SShort6 * b.SShort6));
			ASSUME(v.SShort7 == (short)(a.SShort7 * b.SShort7));
			ASSUME(v.SShort8 == (short)(a.SShort8 * b.SShort8));
			ASSUME(v.SShort9 == (short)(a.SShort9 * b.SShort9));
			ASSUME(v.SShort10 == (short)(a.SShort10 * b.SShort10));
			ASSUME(v.SShort11 == (short)(a.SShort11 * b.SShort11));
			ASSUME(v.SShort12 == (short)(a.SShort12 * b.SShort12));
			ASSUME(v.SShort13 == (short)(a.SShort13 * b.SShort13));
			ASSUME(v.SShort14 == (short)(a.SShort14 * b.SShort14));
			ASSUME(v.SShort15 == (short)(a.SShort15 * b.SShort15));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_MULTIPLICATION_EPI32(v256 v, v256 a, v256 b, byte elements = 8)
		{
			ASSUME(v.SInt0 == a.SInt0 * b.SInt0);
			if (elements == 1) return;
			ASSUME(v.SInt1 == a.SInt1 * b.SInt1);
			ASSUME(v.SInt2 == a.SInt2 * b.SInt2);
			ASSUME(v.SInt3 == a.SInt3 * b.SInt3);
			ASSUME(v.SInt4 == a.SInt4 * b.SInt4);
			ASSUME(v.SInt5 == a.SInt5 * b.SInt5);
			ASSUME(v.SInt6 == a.SInt6 * b.SInt6);
			ASSUME(v.SInt7 == a.SInt7 * b.SInt7);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_MULTIPLICATION_EPI64(v256 v, v256 a, v256 b, byte elements = 4)
		{
			ASSUME(v.SLong0 == a.SLong0 * b.SLong0);
			if (elements == 1) return;
			ASSUME(v.SLong1 == a.SLong1 * b.SLong1);
			ASSUME(v.SLong2 == a.SLong2 * b.SLong2);
			if (elements == 3) return;
			ASSUME(v.SLong3 == a.SLong3 * b.SLong3);
		}

		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_DIVISION_EPU8(v128 v, v128 a, v128 b, byte elements = 16)
		{
			ASSUME_NEQ_EPU8(b, 0, elements);
			ASSUME_LE_EPU8(v, a, elements);

			ASSUME(v.Byte0 == (byte)(a.Byte0 / b.Byte0));
			if (elements == 1) return;
			ASSUME(v.Byte1 == (byte)(a.Byte1 / b.Byte1));
			if (elements == 2) return;
			ASSUME(v.Byte2 == (byte)(a.Byte2 / b.Byte2));
			if (elements == 3) return;
			ASSUME(v.Byte3 == (byte)(a.Byte3 / b.Byte3));
			if (elements == 4) return;
			ASSUME(v.Byte4 == (byte)(a.Byte4 / b.Byte4));
			ASSUME(v.Byte5 == (byte)(a.Byte5 / b.Byte5));
			ASSUME(v.Byte6 == (byte)(a.Byte6 / b.Byte6));
			ASSUME(v.Byte7 == (byte)(a.Byte7 / b.Byte7));
			if (elements == 8) return;
			ASSUME(v.Byte8 == (byte)(a.Byte8 / b.Byte8));
			ASSUME(v.Byte9 == (byte)(a.Byte9 / b.Byte9));
			ASSUME(v.Byte10 == (byte)(a.Byte10 / b.Byte10));
			ASSUME(v.Byte11 == (byte)(a.Byte11 / b.Byte11));
			ASSUME(v.Byte12 == (byte)(a.Byte12 / b.Byte12));
			ASSUME(v.Byte13 == (byte)(a.Byte13 / b.Byte13));
			ASSUME(v.Byte14 == (byte)(a.Byte14 / b.Byte14));
			ASSUME(v.Byte15 == (byte)(a.Byte15 / b.Byte15));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_DIVISION_EPU16(v128 v, v128 a, v128 b, byte elements = 8)
		{
			ASSUME_NEQ_EPU16(b, 0, elements);
			ASSUME_LE_EPU16(v, a, elements);

			ASSUME(v.UShort0 == (ushort)(a.UShort0 / b.UShort0));
			if (elements == 1) return;
			ASSUME(v.UShort1 == (ushort)(a.UShort1 / b.UShort1));
			if (elements == 2) return;
			ASSUME(v.UShort2 == (ushort)(a.UShort2 / b.UShort2));
			if (elements == 3) return;
			ASSUME(v.UShort3 == (ushort)(a.UShort3 / b.UShort3));
			if (elements == 4) return;
			ASSUME(v.UShort4 == (ushort)(a.UShort4 / b.UShort4));
			ASSUME(v.UShort5 == (ushort)(a.UShort5 / b.UShort5));
			ASSUME(v.UShort6 == (ushort)(a.UShort6 / b.UShort6));
			ASSUME(v.UShort7 == (ushort)(a.UShort7 / b.UShort7));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_DIVISION_EPU32(v128 v, v128 a, v128 b, byte elements = 4)
		{
			ASSUME_NEQ_EPU32(b, 0, elements);
			ASSUME_LE_EPU32(v, a, elements);

			ASSUME(v.UInt0 == a.UInt0 / b.UInt0);
			if (elements == 1) return;
			ASSUME(v.UInt1 == a.UInt1 / b.UInt1);
			if (elements == 2) return;
			ASSUME(v.UInt2 == a.UInt2 / b.UInt2);
			if (elements == 3) return;
			ASSUME(v.UInt3 == a.UInt3 / b.UInt3);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_DIVISION_EPU64(v128 v, v128 a, v128 b, byte elements = 2)
		{
			ASSUME_NEQ_EPU64(b, 0, elements);
			ASSUME_LE_EPU64(v, a);

			ASSUME(v.ULong0 == a.ULong0 / b.ULong0);
			if (elements == 1) return;
			ASSUME(v.ULong1 == a.ULong1 / b.ULong1);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_DIVISION_EPI8(v128 v, v128 a, v128 b, byte elements = 16)
		{
			ASSUME_NEQ_EPU8(b, 0, elements);

			if (ALL_GE_EPI8(a, 0, elements)
			 && ALL_GE_EPI8(b, 0, elements))
			{
				ASSUME_LE_EPU8(a, (byte)sbyte.MaxValue, elements);
				ASSUME_LE_EPU8(b, (byte)sbyte.MaxValue, elements);
				ASSUME_DIVISION_EPU8(v, a, b, elements);
			}
			else
			{
				ASSUME(v.SByte0 == (sbyte)(a.SByte0 / b.SByte0));
				if (elements == 1) return;
				ASSUME(v.SByte1 == (sbyte)(a.SByte1 / b.SByte1));
				if (elements == 2) return;
				ASSUME(v.SByte2 == (sbyte)(a.SByte2 / b.SByte2));
				if (elements == 3) return;
				ASSUME(v.SByte3 == (sbyte)(a.SByte3 / b.SByte3));
				if (elements == 4) return;
				ASSUME(v.SByte4 == (sbyte)(a.SByte4 / b.SByte4));
				ASSUME(v.SByte5 == (sbyte)(a.SByte5 / b.SByte5));
				ASSUME(v.SByte6 == (sbyte)(a.SByte6 / b.SByte6));
				ASSUME(v.SByte7 == (sbyte)(a.SByte7 / b.SByte7));
				if (elements == 8) return;
				ASSUME(v.SByte8 == (sbyte)(a.SByte8 / b.SByte8));
				ASSUME(v.SByte9 == (sbyte)(a.SByte9 / b.SByte9));
				ASSUME(v.SByte10 == (sbyte)(a.SByte10 / b.SByte10));
				ASSUME(v.SByte11 == (sbyte)(a.SByte11 / b.SByte11));
				ASSUME(v.SByte12 == (sbyte)(a.SByte12 / b.SByte12));
				ASSUME(v.SByte13 == (sbyte)(a.SByte13 / b.SByte13));
				ASSUME(v.SByte14 == (sbyte)(a.SByte14 / b.SByte14));
				ASSUME(v.SByte15 == (sbyte)(a.SByte15 / b.SByte15));
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_DIVISION_EPI16(v128 v, v128 a, v128 b, byte elements = 8)
		{
			ASSUME_NEQ_EPU16(b, 0, elements);

			if (ALL_GE_EPI16(a, 0, elements)
			 && ALL_GE_EPI16(b, 0, elements))
			{
				ASSUME_LE_EPU16(a, (uint)short.MaxValue, elements);
				ASSUME_LE_EPU16(b, (uint)short.MaxValue, elements);
				ASSUME_DIVISION_EPU16(v, a, b, elements);
			}
			else
			{
				ASSUME(v.SShort0 == (short)(a.SShort0 / b.SShort0));
				if (elements == 1) return;
				ASSUME(v.SShort1 == (short)(a.SShort1 / b.SShort1));
				if (elements == 2) return;
				ASSUME(v.SShort2 == (short)(a.SShort2 / b.SShort2));
				if (elements == 3) return;
				ASSUME(v.SShort3 == (short)(a.SShort3 / b.SShort3));
				if (elements == 4) return;
				ASSUME(v.SShort4 == (short)(a.SShort4 / b.SShort4));
				ASSUME(v.SShort5 == (short)(a.SShort5 / b.SShort5));
				ASSUME(v.SShort6 == (short)(a.SShort6 / b.SShort6));
				ASSUME(v.SShort7 == (short)(a.SShort7 / b.SShort7));
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_DIVISION_EPI32(v128 v, v128 a, v128 b, byte elements = 4)
		{
			ASSUME_NEQ_EPU32(b, 0, elements);

			if (ALL_GE_EPI32(a, 0, elements)
			 && ALL_GE_EPI32(b, 0, elements))
			{
				ASSUME_LE_EPU32(a, int.MaxValue, elements);
				ASSUME_LE_EPU32(b, int.MaxValue, elements);
				ASSUME_DIVISION_EPU32(v, a, b, elements);
			}
			else
			{
				ASSUME((a.SInt0 == int.MinValue && b.SInt0 == -1) || (v.SInt0 == a.SInt0 / b.SInt0));
				if (elements == 1) return;
				ASSUME((a.SInt1 == int.MinValue && b.SInt1 == -1) || (v.SInt1 == a.SInt1 / b.SInt1));
				if (elements == 2) return;
				ASSUME((a.SInt2 == int.MinValue && b.SInt2 == -1) || (v.SInt2 == a.SInt2 / b.SInt2));
				if (elements == 3) return;
				ASSUME((a.SInt3 == int.MinValue && b.SInt3 == -1) || (v.SInt3 == a.SInt3 / b.SInt3));
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_DIVISION_EPI64(v128 v, v128 a, v128 b, byte elements = 2)
		{
			ASSUME_NEQ_EPU64(b, 0, elements);

			if (ALL_GE_EPI64(a, 0, elements)
			 && ALL_GE_EPI64(b, 0, elements))
			{
				ASSUME_LE_EPU64(a, long.MaxValue, elements);
				ASSUME_LE_EPU64(b, long.MaxValue, elements);
				ASSUME_DIVISION_EPU64(v, a, b, elements);
			}
			else
			{
				if (ALL_GT_EPI64(a, long.MinValue, elements)
				 || ALL_NEQ_EPI64(b, -1, elements))
				{
					ASSUME((a.SLong0 == long.MinValue && b.SLong0 == -1) || (v.SLong0 == a.SLong0 / b.SLong0));
					if (elements == 1) return;
					ASSUME((a.SLong1 == long.MinValue && b.SLong1 == -1) || (v.SLong1 == a.SLong1 / b.SLong1));
				}
			}
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_DIVISION_EPI8(v256 v, v256 a, v256 b, byte elements = 32)
		{
			ASSUME_NEQ_EPU8(b, 0, elements);

			if (ALL_GE_EPI8(a, 0)
			 && ALL_GE_EPI8(b, 0))
			{
				ASSUME_LE_EPU8(a, (uint)sbyte.MaxValue, elements);
				ASSUME_LE_EPU8(b, (uint)sbyte.MaxValue, elements);
				ASSUME_DIVISION_EPU8(v, a, b, elements);
			}
			else
			{
				ASSUME(v.SByte0 == (sbyte)(a.SByte0 / b.SByte0));
				if (elements == 1) return;
				ASSUME(v.SByte1 == (sbyte)(a.SByte1 / b.SByte1));
				ASSUME(v.SByte2 == (sbyte)(a.SByte2 / b.SByte2));
				ASSUME(v.SByte3 == (sbyte)(a.SByte3 / b.SByte3));
				ASSUME(v.SByte4 == (sbyte)(a.SByte4 / b.SByte4));
				ASSUME(v.SByte5 == (sbyte)(a.SByte5 / b.SByte5));
				ASSUME(v.SByte6 == (sbyte)(a.SByte6 / b.SByte6));
				ASSUME(v.SByte7 == (sbyte)(a.SByte7 / b.SByte7));
				ASSUME(v.SByte8 == (sbyte)(a.SByte8 / b.SByte8));
				ASSUME(v.SByte9 == (sbyte)(a.SByte9 / b.SByte9));
				ASSUME(v.SByte10 == (sbyte)(a.SByte10 / b.SByte10));
				ASSUME(v.SByte11 == (sbyte)(a.SByte11 / b.SByte11));
				ASSUME(v.SByte12 == (sbyte)(a.SByte12 / b.SByte12));
				ASSUME(v.SByte13 == (sbyte)(a.SByte13 / b.SByte13));
				ASSUME(v.SByte14 == (sbyte)(a.SByte14 / b.SByte14));
				ASSUME(v.SByte15 == (sbyte)(a.SByte15 / b.SByte15));
				ASSUME(v.SByte16 == (sbyte)(a.SByte16 / b.SByte16));
				ASSUME(v.SByte17 == (sbyte)(a.SByte17 / b.SByte17));
				ASSUME(v.SByte18 == (sbyte)(a.SByte18 / b.SByte18));
				ASSUME(v.SByte19 == (sbyte)(a.SByte19 / b.SByte19));
				ASSUME(v.SByte20 == (sbyte)(a.SByte20 / b.SByte20));
				ASSUME(v.SByte21 == (sbyte)(a.SByte21 / b.SByte21));
				ASSUME(v.SByte22 == (sbyte)(a.SByte22 / b.SByte22));
				ASSUME(v.SByte23 == (sbyte)(a.SByte23 / b.SByte23));
				ASSUME(v.SByte24 == (sbyte)(a.SByte24 / b.SByte24));
				ASSUME(v.SByte25 == (sbyte)(a.SByte25 / b.SByte25));
				ASSUME(v.SByte26 == (sbyte)(a.SByte26 / b.SByte26));
				ASSUME(v.SByte27 == (sbyte)(a.SByte27 / b.SByte27));
				ASSUME(v.SByte28 == (sbyte)(a.SByte28 / b.SByte28));
				ASSUME(v.SByte29 == (sbyte)(a.SByte29 / b.SByte29));
				ASSUME(v.SByte30 == (sbyte)(a.SByte30 / b.SByte30));
				ASSUME(v.SByte31 == (sbyte)(a.SByte31 / b.SByte31));
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_DIVISION_EPI16(v256 v, v256 a, v256 b, byte elements = 16)
		{
			ASSUME_NEQ_EPU16(b, 0, elements);

			if (ALL_GE_EPI16(a, 0)
			 && ALL_GE_EPI16(b, 0))
			{
				ASSUME_LE_EPU16(a, (uint)short.MaxValue, elements);
				ASSUME_LE_EPU16(b, (uint)short.MaxValue, elements);
				ASSUME_DIVISION_EPU16(v, a, b, elements);
			}
			else
			{
				ASSUME(v.SShort0 == (short)(a.SShort0 / b.SShort0));
				if (elements == 1) return;
				ASSUME(v.SShort1 == (short)(a.SShort1 / b.SShort1));
				ASSUME(v.SShort2 == (short)(a.SShort2 / b.SShort2));
				ASSUME(v.SShort3 == (short)(a.SShort3 / b.SShort3));
				ASSUME(v.SShort4 == (short)(a.SShort4 / b.SShort4));
				ASSUME(v.SShort5 == (short)(a.SShort5 / b.SShort5));
				ASSUME(v.SShort6 == (short)(a.SShort6 / b.SShort6));
				ASSUME(v.SShort7 == (short)(a.SShort7 / b.SShort7));
				ASSUME(v.SShort8 == (short)(a.SShort8 / b.SShort8));
				ASSUME(v.SShort9 == (short)(a.SShort9 / b.SShort9));
				ASSUME(v.SShort10 == (short)(a.SShort10 / b.SShort10));
				ASSUME(v.SShort11 == (short)(a.SShort11 / b.SShort11));
				ASSUME(v.SShort12 == (short)(a.SShort12 / b.SShort12));
				ASSUME(v.SShort13 == (short)(a.SShort13 / b.SShort13));
				ASSUME(v.SShort14 == (short)(a.SShort14 / b.SShort14));
				ASSUME(v.SShort15 == (short)(a.SShort15 / b.SShort15));
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_DIVISION_EPI32(v256 v, v256 a, v256 b, byte elements = 8)
		{
			ASSUME_NEQ_EPU32(b, 0, elements);

			if (ALL_GE_EPI32(a, 0)
			 && ALL_GE_EPI32(b, 0))
			{
				ASSUME_LE_EPU32(a, int.MaxValue, elements);
				ASSUME_LE_EPU32(b, int.MaxValue, elements);
				ASSUME_DIVISION_EPU32(v, a, b, elements);
			}
			else
			{
				ASSUME(v.SInt0 == (int)((long)a.SInt0 / b.SInt0));
				if (elements == 1) return;
				ASSUME(v.SInt1 == (int)((long)a.SInt1 / b.SInt1));
				ASSUME(v.SInt2 == (int)((long)a.SInt2 / b.SInt2));
				ASSUME(v.SInt3 == (int)((long)a.SInt3 / b.SInt3));
				ASSUME(v.SInt4 == (int)((long)a.SInt4 / b.SInt4));
				ASSUME(v.SInt5 == (int)((long)a.SInt5 / b.SInt5));
				ASSUME(v.SInt6 == (int)((long)a.SInt6 / b.SInt6));
				ASSUME(v.SInt7 == (int)((long)a.SInt7 / b.SInt7));
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_DIVISION_EPI64(v256 v, v256 a, v256 b, byte elements = 4)
		{
			ASSUME_NEQ_EPU64(b, 0, elements);

			if (ALL_GE_EPI64(a, 0, elements)
			 && ALL_GE_EPI64(b, 0, elements))
			{
				ASSUME_LE_EPU64(a, long.MaxValue, elements);
				ASSUME_LE_EPU64(b, long.MaxValue, elements);
				ASSUME_DIVISION_EPU64(v, a, b, elements);
			}
			else
			{
				if (ALL_GT_EPI64(a, long.MinValue, elements)
				 || ALL_NEQ_EPI64(b, -1, elements))
				{
					ASSUME((a.SLong0 == long.MinValue && b.SLong0 == -1) || (v.SLong0 == a.SLong0 / b.SLong0));
					if (elements == 1) return;
					ASSUME((a.SLong1 == long.MinValue && b.SLong1 == -1) || (v.SLong1 == a.SLong1 / b.SLong1));
					ASSUME((a.SLong2 == long.MinValue && b.SLong2 == -1) || (v.SLong2 == a.SLong2 / b.SLong2));
					if (elements == 3) return;
					ASSUME((a.SLong3 == long.MinValue && b.SLong3 == -1) || (v.SLong3 == a.SLong3 / b.SLong3));
				}
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_DIVISION_EPU8(v256 v, v256 a, v256 b, byte elements = 32)
		{
			ASSUME_NEQ_EPU8(b, 0, elements);
			ASSUME_LE_EPU8(v, a);

			ASSUME(v.Byte0 == (byte)(a.Byte0 / b.Byte0));
			if (elements == 1) return;
			ASSUME(v.Byte1 == (byte)(a.Byte1 / b.Byte1));
			ASSUME(v.Byte2 == (byte)(a.Byte2 / b.Byte2));
			ASSUME(v.Byte3 == (byte)(a.Byte3 / b.Byte3));
			ASSUME(v.Byte4 == (byte)(a.Byte4 / b.Byte4));
			ASSUME(v.Byte5 == (byte)(a.Byte5 / b.Byte5));
			ASSUME(v.Byte6 == (byte)(a.Byte6 / b.Byte6));
			ASSUME(v.Byte7 == (byte)(a.Byte7 / b.Byte7));
			ASSUME(v.Byte8 == (byte)(a.Byte8 / b.Byte8));
			ASSUME(v.Byte9 == (byte)(a.Byte9 / b.Byte9));
			ASSUME(v.Byte10 == (byte)(a.Byte10 / b.Byte10));
			ASSUME(v.Byte11 == (byte)(a.Byte11 / b.Byte11));
			ASSUME(v.Byte12 == (byte)(a.Byte12 / b.Byte12));
			ASSUME(v.Byte13 == (byte)(a.Byte13 / b.Byte13));
			ASSUME(v.Byte14 == (byte)(a.Byte14 / b.Byte14));
			ASSUME(v.Byte15 == (byte)(a.Byte15 / b.Byte15));
			ASSUME(v.Byte16 == (byte)(a.Byte16 / b.Byte16));
			ASSUME(v.Byte17 == (byte)(a.Byte17 / b.Byte17));
			ASSUME(v.Byte18 == (byte)(a.Byte18 / b.Byte18));
			ASSUME(v.Byte19 == (byte)(a.Byte19 / b.Byte19));
			ASSUME(v.Byte20 == (byte)(a.Byte20 / b.Byte20));
			ASSUME(v.Byte21 == (byte)(a.Byte21 / b.Byte21));
			ASSUME(v.Byte22 == (byte)(a.Byte22 / b.Byte22));
			ASSUME(v.Byte23 == (byte)(a.Byte23 / b.Byte23));
			ASSUME(v.Byte24 == (byte)(a.Byte24 / b.Byte24));
			ASSUME(v.Byte25 == (byte)(a.Byte25 / b.Byte25));
			ASSUME(v.Byte26 == (byte)(a.Byte26 / b.Byte26));
			ASSUME(v.Byte27 == (byte)(a.Byte27 / b.Byte27));
			ASSUME(v.Byte28 == (byte)(a.Byte28 / b.Byte28));
			ASSUME(v.Byte29 == (byte)(a.Byte29 / b.Byte29));
			ASSUME(v.Byte30 == (byte)(a.Byte30 / b.Byte30));
			ASSUME(v.Byte31 == (byte)(a.Byte31 / b.Byte31));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_DIVISION_EPU16(v256 v, v256 a, v256 b, byte elements = 16)
		{
			ASSUME_NEQ_EPU16(b, 0, elements);
			ASSUME_LE_EPU16(v, a);

			ASSUME(v.UShort0 == (ushort)(a.UShort0 / b.UShort0));
			if (elements == 1) return;
			ASSUME(v.UShort1 == (ushort)(a.UShort1 / b.UShort1));
			ASSUME(v.UShort2 == (ushort)(a.UShort2 / b.UShort2));
			ASSUME(v.UShort3 == (ushort)(a.UShort3 / b.UShort3));
			ASSUME(v.UShort4 == (ushort)(a.UShort4 / b.UShort4));
			ASSUME(v.UShort5 == (ushort)(a.UShort5 / b.UShort5));
			ASSUME(v.UShort6 == (ushort)(a.UShort6 / b.UShort6));
			ASSUME(v.UShort7 == (ushort)(a.UShort7 / b.UShort7));
			ASSUME(v.UShort8 == (ushort)(a.UShort8 / b.UShort8));
			ASSUME(v.UShort9 == (ushort)(a.UShort9 / b.UShort9));
			ASSUME(v.UShort10 == (ushort)(a.UShort10 / b.UShort10));
			ASSUME(v.UShort11 == (ushort)(a.UShort11 / b.UShort11));
			ASSUME(v.UShort12 == (ushort)(a.UShort12 / b.UShort12));
			ASSUME(v.UShort13 == (ushort)(a.UShort13 / b.UShort13));
			ASSUME(v.UShort14 == (ushort)(a.UShort14 / b.UShort14));
			ASSUME(v.UShort15 == (ushort)(a.UShort15 / b.UShort15));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_DIVISION_EPU32(v256 v, v256 a, v256 b, byte elements = 8)
		{
			ASSUME_NEQ_EPU32(b, 0, elements);
			ASSUME_LE_EPU32(v, a);

			ASSUME(v.UInt0 == a.UInt0 / b.UInt0);
			if (elements == 1) return;
			ASSUME(v.UInt1 == a.UInt1 / b.UInt1);
			ASSUME(v.UInt2 == a.UInt2 / b.UInt2);
			ASSUME(v.UInt3 == a.UInt3 / b.UInt3);
			ASSUME(v.UInt4 == a.UInt4 / b.UInt4);
			ASSUME(v.UInt5 == a.UInt5 / b.UInt5);
			ASSUME(v.UInt6 == a.UInt6 / b.UInt6);
			ASSUME(v.UInt7 == a.UInt7 / b.UInt7);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_DIVISION_EPU64(v256 v, v256 a, v256 b, byte elements = 4)
		{
			ASSUME_NEQ_EPU64(b, 0, elements);
			ASSUME_LE_EPU64(v, a, elements);

			ASSUME(v.ULong0 == a.ULong0 / b.ULong0);
			if (elements == 1) return;
			ASSUME(v.ULong1 == a.ULong1 / b.ULong1);
			ASSUME(v.ULong2 == a.ULong2 / b.ULong2);
			if (elements == 3) return;
			ASSUME(v.ULong3 == a.ULong3 / b.ULong3);
		}

		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_REMAINDER_EPU8(v128 v, v128 a, v128 b, byte elements = 16)
		{
			ASSUME_NEQ_EPU8(b, 0, elements);
			ASSUME_LT_EPU8(v, b, elements);
			ASSUME_LE_EPU8(v, a, elements);

			ASSUME(v.Byte0 == (byte)(a.Byte0 % b.Byte0));
			if (elements == 1) return;
			ASSUME(v.Byte1 == (byte)(a.Byte1 % b.Byte1));
			if (elements == 2) return;
			ASSUME(v.Byte2 == (byte)(a.Byte2 % b.Byte2));
			if (elements == 3) return;
			ASSUME(v.Byte3 == (byte)(a.Byte3 % b.Byte3));
			if (elements == 4) return;
			ASSUME(v.Byte4 == (byte)(a.Byte4 % b.Byte4));
			ASSUME(v.Byte5 == (byte)(a.Byte5 % b.Byte5));
			ASSUME(v.Byte6 == (byte)(a.Byte6 % b.Byte6));
			ASSUME(v.Byte7 == (byte)(a.Byte7 % b.Byte7));
			if (elements == 8) return;
			ASSUME(v.Byte8 == (byte)(a.Byte8 % b.Byte8));
			ASSUME(v.Byte9 == (byte)(a.Byte9 % b.Byte9));
			ASSUME(v.Byte10 == (byte)(a.Byte10 % b.Byte10));
			ASSUME(v.Byte11 == (byte)(a.Byte11 % b.Byte11));
			ASSUME(v.Byte12 == (byte)(a.Byte12 % b.Byte12));
			ASSUME(v.Byte13 == (byte)(a.Byte13 % b.Byte13));
			ASSUME(v.Byte14 == (byte)(a.Byte14 % b.Byte14));
			ASSUME(v.Byte15 == (byte)(a.Byte15 % b.Byte15));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_REMAINDER_EPU16(v128 v, v128 a, v128 b, byte elements = 8)
		{
			ASSUME_NEQ_EPU16(b, 0, elements);
			ASSUME_LT_EPU16(v, b, elements);
			ASSUME_LE_EPU16(v, a, elements);

			ASSUME(v.UShort0 == (ushort)(a.UShort0 % b.UShort0));
			if (elements == 1) return;
			ASSUME(v.UShort1 == (ushort)(a.UShort1 % b.UShort1));
			if (elements == 2) return;
			ASSUME(v.UShort2 == (ushort)(a.UShort2 % b.UShort2));
			if (elements == 3) return;
			ASSUME(v.UShort3 == (ushort)(a.UShort3 % b.UShort3));
			if (elements == 4) return;
			ASSUME(v.UShort4 == (ushort)(a.UShort4 % b.UShort4));
			ASSUME(v.UShort5 == (ushort)(a.UShort5 % b.UShort5));
			ASSUME(v.UShort6 == (ushort)(a.UShort6 % b.UShort6));
			ASSUME(v.UShort7 == (ushort)(a.UShort7 % b.UShort7));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_REMAINDER_EPU32(v128 v, v128 a, v128 b, byte elements = 4)
		{
			ASSUME_NEQ_EPU32(b, 0, elements);
			ASSUME_LT_EPU32(v, b, elements);
			ASSUME_LE_EPU32(v, a, elements);

			ASSUME(v.UInt0 == a.UInt0 % b.UInt0);
			if (elements == 1) return;
			ASSUME(v.UInt1 == a.UInt1 % b.UInt1);
			if (elements == 2) return;
			ASSUME(v.UInt2 == a.UInt2 % b.UInt2);
			if (elements == 3) return;
			ASSUME(v.UInt3 == a.UInt3 % b.UInt3);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_REMAINDER_EPU64(v128 v, v128 a, v128 b, byte elements = 2)
		{
			ASSUME_NEQ_EPU64(b, 0, elements);
			ASSUME_LT_EPU64(v, b);
			ASSUME_LE_EPU64(v, a);

			ASSUME(v.ULong0 == a.ULong0 % b.ULong0);
			if (elements == 1) return;
			ASSUME(v.ULong1 == a.ULong1 % b.ULong1);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_REMAINDER_EPI8(v128 v, v128 a, v128 b, byte elements = 16)
		{
			ASSUME_NEQ_EPU8(b, 0, elements);

			if (ALL_GE_EPI8(a, 0, elements)
			 && ALL_GE_EPI8(b, 0, elements))
			{
				ASSUME_LE_EPU8(a, (byte)sbyte.MaxValue, elements);
				ASSUME_LE_EPU8(b, (byte)sbyte.MaxValue, elements);
				ASSUME_REMAINDER_EPU8(v, a, b, elements);
			}
			else
			{
				ASSUME(v.SByte0 == (sbyte)(a.SByte0 % b.SByte0));
				if (elements == 1) return;
				ASSUME(v.SByte1 == (sbyte)(a.SByte1 % b.SByte1));
				if (elements == 2) return;
				ASSUME(v.SByte2 == (sbyte)(a.SByte2 % b.SByte2));
				if (elements == 3) return;
				ASSUME(v.SByte3 == (sbyte)(a.SByte3 % b.SByte3));
				if (elements == 4) return;
				ASSUME(v.SByte4 == (sbyte)(a.SByte4 % b.SByte4));
				ASSUME(v.SByte5 == (sbyte)(a.SByte5 % b.SByte5));
				ASSUME(v.SByte6 == (sbyte)(a.SByte6 % b.SByte6));
				ASSUME(v.SByte7 == (sbyte)(a.SByte7 % b.SByte7));
				if (elements == 8) return;
				ASSUME(v.SByte8 == (sbyte)(a.SByte8 % b.SByte8));
				ASSUME(v.SByte9 == (sbyte)(a.SByte9 % b.SByte9));
				ASSUME(v.SByte10 == (sbyte)(a.SByte10 % b.SByte10));
				ASSUME(v.SByte11 == (sbyte)(a.SByte11 % b.SByte11));
				ASSUME(v.SByte12 == (sbyte)(a.SByte12 % b.SByte12));
				ASSUME(v.SByte13 == (sbyte)(a.SByte13 % b.SByte13));
				ASSUME(v.SByte14 == (sbyte)(a.SByte14 % b.SByte14));
				ASSUME(v.SByte15 == (sbyte)(a.SByte15 % b.SByte15));
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_REMAINDER_EPI16(v128 v, v128 a, v128 b, byte elements = 8)
		{
			ASSUME_NEQ_EPU16(b, 0, elements);

			if (ALL_GE_EPI16(a, 0, elements)
			 && ALL_GE_EPI16(b, 0, elements))
			{
				ASSUME_LE_EPU16(a, (uint)short.MaxValue, elements);
				ASSUME_LE_EPU16(b, (uint)short.MaxValue, elements);
				ASSUME_REMAINDER_EPU16(v, a, b, elements);
			}
			else
			{
				ASSUME(v.SShort0 == (short)(a.SShort0 % b.SShort0));
				if (elements == 1) return;
				ASSUME(v.SShort1 == (short)(a.SShort1 % b.SShort1));
				if (elements == 2) return;
				ASSUME(v.SShort2 == (short)(a.SShort2 % b.SShort2));
				if (elements == 3) return;
				ASSUME(v.SShort3 == (short)(a.SShort3 % b.SShort3));
				if (elements == 4) return;
				ASSUME(v.SShort4 == (short)(a.SShort4 % b.SShort4));
				ASSUME(v.SShort5 == (short)(a.SShort5 % b.SShort5));
				ASSUME(v.SShort6 == (short)(a.SShort6 % b.SShort6));
				ASSUME(v.SShort7 == (short)(a.SShort7 % b.SShort7));
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_REMAINDER_EPI32(v128 v, v128 a, v128 b, byte elements = 4)
		{
			ASSUME_NEQ_EPU32(b, 0, elements);

			if (ALL_GE_EPI32(a, 0, elements)
			 && ALL_GE_EPI32(b, 0, elements))
			{
				ASSUME_LE_EPU32(a, int.MaxValue, elements);
				ASSUME_LE_EPU32(b, int.MaxValue, elements);
				ASSUME_REMAINDER_EPU32(v, a, b, elements);
			}
			else
			{
				ASSUME((a.SInt0 == int.MinValue && b.SInt0 == -1) || (v.SInt0 == a.SInt0 % b.SInt0));
				if (elements == 1) return;
				ASSUME((a.SInt1 == int.MinValue && b.SInt1 == -1) || (v.SInt1 == a.SInt1 % b.SInt1));
				if (elements == 2) return;
				ASSUME((a.SInt2 == int.MinValue && b.SInt2 == -1) || (v.SInt2 == a.SInt2 % b.SInt2));
				if (elements == 3) return;
				ASSUME((a.SInt3 == int.MinValue && b.SInt3 == -1) || (v.SInt3 == a.SInt3 % b.SInt3));
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_REMAINDER_EPI64(v128 v, v128 a, v128 b, byte elements = 2)
		{
			ASSUME_NEQ_EPU64(b, 0, elements);

			if (ALL_GE_EPI64(a, 0, elements)
			 && ALL_GE_EPI64(b, 0, elements))
			{
				ASSUME_LE_EPU64(a, long.MaxValue, elements);
				ASSUME_LE_EPU64(b, long.MaxValue, elements);
				ASSUME_REMAINDER_EPU64(v, a, b, elements);
			}
			else
			{
				ASSUME((a.SLong0 == long.MinValue && b.SLong0 == -1) || (v.SLong0 == a.SLong0 % b.SLong0));
				if (elements == 1) return;
				ASSUME((a.SLong1 == long.MinValue && b.SLong1 == -1) || (v.SLong1 == a.SLong1 % b.SLong1));
			}
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_REMAINDER_EPI8(v256 v, v256 a, v256 b, byte elements = 32)
		{
			ASSUME_NEQ_EPU8(b, 0, elements);

			if (ALL_GE_EPI8(a, 0)
			 && ALL_GE_EPI8(b, 0))
			{
				ASSUME_LE_EPU8(a, (uint)sbyte.MaxValue, elements);
				ASSUME_LE_EPU8(b, (uint)sbyte.MaxValue, elements);
				ASSUME_REMAINDER_EPU8(v, a, b, elements);
			}
			else
			{
				ASSUME(v.SByte0 == (sbyte)(a.SByte0 % b.SByte0));
				if (elements == 1) return;
				ASSUME(v.SByte1 == (sbyte)(a.SByte1 % b.SByte1));
				ASSUME(v.SByte2 == (sbyte)(a.SByte2 % b.SByte2));
				ASSUME(v.SByte3 == (sbyte)(a.SByte3 % b.SByte3));
				ASSUME(v.SByte4 == (sbyte)(a.SByte4 % b.SByte4));
				ASSUME(v.SByte5 == (sbyte)(a.SByte5 % b.SByte5));
				ASSUME(v.SByte6 == (sbyte)(a.SByte6 % b.SByte6));
				ASSUME(v.SByte7 == (sbyte)(a.SByte7 % b.SByte7));
				ASSUME(v.SByte8 == (sbyte)(a.SByte8 % b.SByte8));
				ASSUME(v.SByte9 == (sbyte)(a.SByte9 % b.SByte9));
				ASSUME(v.SByte10 == (sbyte)(a.SByte10 % b.SByte10));
				ASSUME(v.SByte11 == (sbyte)(a.SByte11 % b.SByte11));
				ASSUME(v.SByte12 == (sbyte)(a.SByte12 % b.SByte12));
				ASSUME(v.SByte13 == (sbyte)(a.SByte13 % b.SByte13));
				ASSUME(v.SByte14 == (sbyte)(a.SByte14 % b.SByte14));
				ASSUME(v.SByte15 == (sbyte)(a.SByte15 % b.SByte15));
				ASSUME(v.SByte16 == (sbyte)(a.SByte16 % b.SByte16));
				ASSUME(v.SByte17 == (sbyte)(a.SByte17 % b.SByte17));
				ASSUME(v.SByte18 == (sbyte)(a.SByte18 % b.SByte18));
				ASSUME(v.SByte19 == (sbyte)(a.SByte19 % b.SByte19));
				ASSUME(v.SByte20 == (sbyte)(a.SByte20 % b.SByte20));
				ASSUME(v.SByte21 == (sbyte)(a.SByte21 % b.SByte21));
				ASSUME(v.SByte22 == (sbyte)(a.SByte22 % b.SByte22));
				ASSUME(v.SByte23 == (sbyte)(a.SByte23 % b.SByte23));
				ASSUME(v.SByte24 == (sbyte)(a.SByte24 % b.SByte24));
				ASSUME(v.SByte25 == (sbyte)(a.SByte25 % b.SByte25));
				ASSUME(v.SByte26 == (sbyte)(a.SByte26 % b.SByte26));
				ASSUME(v.SByte27 == (sbyte)(a.SByte27 % b.SByte27));
				ASSUME(v.SByte28 == (sbyte)(a.SByte28 % b.SByte28));
				ASSUME(v.SByte29 == (sbyte)(a.SByte29 % b.SByte29));
				ASSUME(v.SByte30 == (sbyte)(a.SByte30 % b.SByte30));
				ASSUME(v.SByte31 == (sbyte)(a.SByte31 % b.SByte31));
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_REMAINDER_EPI16(v256 v, v256 a, v256 b, byte elements = 16)
		{
			ASSUME_NEQ_EPU16(b, 0, elements);

			if (ALL_GE_EPI16(a, 0)
			 && ALL_GE_EPI16(b, 0))
			{
				ASSUME_LE_EPU16(a, (uint)short.MaxValue, elements);
				ASSUME_LE_EPU16(b, (uint)short.MaxValue, elements);
				ASSUME_REMAINDER_EPU16(v, a, b, elements);
			}
			else
			{
				ASSUME(v.SShort0 == (short)(a.SShort0 % b.SShort0));
				if (elements == 1) return;
				ASSUME(v.SShort1 == (short)(a.SShort1 % b.SShort1));
				ASSUME(v.SShort2 == (short)(a.SShort2 % b.SShort2));
				ASSUME(v.SShort3 == (short)(a.SShort3 % b.SShort3));
				ASSUME(v.SShort4 == (short)(a.SShort4 % b.SShort4));
				ASSUME(v.SShort5 == (short)(a.SShort5 % b.SShort5));
				ASSUME(v.SShort6 == (short)(a.SShort6 % b.SShort6));
				ASSUME(v.SShort7 == (short)(a.SShort7 % b.SShort7));
				ASSUME(v.SShort8 == (short)(a.SShort8 % b.SShort8));
				ASSUME(v.SShort9 == (short)(a.SShort9 % b.SShort9));
				ASSUME(v.SShort10 == (short)(a.SShort10 % b.SShort10));
				ASSUME(v.SShort11 == (short)(a.SShort11 % b.SShort11));
				ASSUME(v.SShort12 == (short)(a.SShort12 % b.SShort12));
				ASSUME(v.SShort13 == (short)(a.SShort13 % b.SShort13));
				ASSUME(v.SShort14 == (short)(a.SShort14 % b.SShort14));
				ASSUME(v.SShort15 == (short)(a.SShort15 % b.SShort15));
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_REMAINDER_EPI32(v256 v, v256 a, v256 b, byte elements = 8)
		{
			ASSUME_NEQ_EPU32(b, 0, elements);

			if (ALL_GE_EPI32(a, 0)
			 && ALL_GE_EPI32(b, 0))
			{
				ASSUME_LE_EPU32(a, int.MaxValue, elements);
				ASSUME_LE_EPU32(b, int.MaxValue, elements);
				ASSUME_REMAINDER_EPU32(v, a, b, elements);
			}
			else
			{
				ASSUME((a.SInt0 == int.MinValue && b.SInt0 == -1) || (v.SInt0 == a.SInt0 % b.SInt0));
				if (elements == 1) return;
				ASSUME((a.SInt1 == int.MinValue && b.SInt1 == -1) || (v.SInt1 == a.SInt1 % b.SInt1));
				ASSUME((a.SInt2 == int.MinValue && b.SInt2 == -1) || (v.SInt2 == a.SInt2 % b.SInt2));
				ASSUME((a.SInt3 == int.MinValue && b.SInt3 == -1) || (v.SInt3 == a.SInt3 % b.SInt3));
				ASSUME((a.SInt4 == int.MinValue && b.SInt4 == -1) || (v.SInt4 == a.SInt4 % b.SInt4));
				ASSUME((a.SInt5 == int.MinValue && b.SInt5 == -1) || (v.SInt5 == a.SInt5 % b.SInt5));
				ASSUME((a.SInt6 == int.MinValue && b.SInt6 == -1) || (v.SInt6 == a.SInt6 % b.SInt6));
				ASSUME((a.SInt7 == int.MinValue && b.SInt7 == -1) || (v.SInt7 == a.SInt7 % b.SInt7));
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_REMAINDER_EPI64(v256 v, v256 a, v256 b, byte elements = 4)
		{
			ASSUME_NEQ_EPU64(b, 0, elements);

			if (ALL_GE_EPI64(a, 0, elements)
			 && ALL_GE_EPI64(b, 0, elements))
			{
				ASSUME_LE_EPU64(a, long.MaxValue, elements);
				ASSUME_LE_EPU64(b, long.MaxValue, elements);
				ASSUME_REMAINDER_EPU64(v, a, b, elements);
			}
			else
			{
				ASSUME((a.SLong0 == long.MinValue && b.SLong0 == -1) || (v.SLong0 == a.SLong0 % b.SLong0));
				if (elements == 1) return;
				ASSUME((a.SLong1 == long.MinValue && b.SLong1 == -1) || (v.SLong1 == a.SLong1 % b.SLong1));
				ASSUME((a.SLong2 == long.MinValue && b.SLong2 == -1) || (v.SLong2 == a.SLong2 % b.SLong2));
				if (elements == 3) return;
				ASSUME((a.SLong3 == long.MinValue && b.SLong3 == -1) || (v.SLong3 == a.SLong3 % b.SLong3));
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_REMAINDER_EPU8(v256 v, v256 a, v256 b, byte elements = 32)
		{
			ASSUME_NEQ_EPU8(b, 0, elements);
			ASSUME_LT_EPU8(v, b);
			ASSUME_LE_EPU8(v, a);

			ASSUME(v.Byte0 == (byte)(a.Byte0 % b.Byte0));
			if (elements == 1) return;
			ASSUME(v.Byte1 == (byte)(a.Byte1 % b.Byte1));
			ASSUME(v.Byte2 == (byte)(a.Byte2 % b.Byte2));
			ASSUME(v.Byte3 == (byte)(a.Byte3 % b.Byte3));
			ASSUME(v.Byte4 == (byte)(a.Byte4 % b.Byte4));
			ASSUME(v.Byte5 == (byte)(a.Byte5 % b.Byte5));
			ASSUME(v.Byte6 == (byte)(a.Byte6 % b.Byte6));
			ASSUME(v.Byte7 == (byte)(a.Byte7 % b.Byte7));
			ASSUME(v.Byte8 == (byte)(a.Byte8 % b.Byte8));
			ASSUME(v.Byte9 == (byte)(a.Byte9 % b.Byte9));
			ASSUME(v.Byte10 == (byte)(a.Byte10 % b.Byte10));
			ASSUME(v.Byte11 == (byte)(a.Byte11 % b.Byte11));
			ASSUME(v.Byte12 == (byte)(a.Byte12 % b.Byte12));
			ASSUME(v.Byte13 == (byte)(a.Byte13 % b.Byte13));
			ASSUME(v.Byte14 == (byte)(a.Byte14 % b.Byte14));
			ASSUME(v.Byte15 == (byte)(a.Byte15 % b.Byte15));
			ASSUME(v.Byte16 == (byte)(a.Byte16 % b.Byte16));
			ASSUME(v.Byte17 == (byte)(a.Byte17 % b.Byte17));
			ASSUME(v.Byte18 == (byte)(a.Byte18 % b.Byte18));
			ASSUME(v.Byte19 == (byte)(a.Byte19 % b.Byte19));
			ASSUME(v.Byte20 == (byte)(a.Byte20 % b.Byte20));
			ASSUME(v.Byte21 == (byte)(a.Byte21 % b.Byte21));
			ASSUME(v.Byte22 == (byte)(a.Byte22 % b.Byte22));
			ASSUME(v.Byte23 == (byte)(a.Byte23 % b.Byte23));
			ASSUME(v.Byte24 == (byte)(a.Byte24 % b.Byte24));
			ASSUME(v.Byte25 == (byte)(a.Byte25 % b.Byte25));
			ASSUME(v.Byte26 == (byte)(a.Byte26 % b.Byte26));
			ASSUME(v.Byte27 == (byte)(a.Byte27 % b.Byte27));
			ASSUME(v.Byte28 == (byte)(a.Byte28 % b.Byte28));
			ASSUME(v.Byte29 == (byte)(a.Byte29 % b.Byte29));
			ASSUME(v.Byte30 == (byte)(a.Byte30 % b.Byte30));
			ASSUME(v.Byte31 == (byte)(a.Byte31 % b.Byte31));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_REMAINDER_EPU16(v256 v, v256 a, v256 b, byte elements = 16)
		{
			ASSUME_NEQ_EPU16(b, 0, elements);
			ASSUME_LT_EPU16(v, b);
			ASSUME_LE_EPU16(v, a);

			ASSUME(v.UShort0 == (ushort)(a.UShort0 % b.UShort0));
			if (elements == 1) return;
			ASSUME(v.UShort1 == (ushort)(a.UShort1 % b.UShort1));
			ASSUME(v.UShort2 == (ushort)(a.UShort2 % b.UShort2));
			ASSUME(v.UShort3 == (ushort)(a.UShort3 % b.UShort3));
			ASSUME(v.UShort4 == (ushort)(a.UShort4 % b.UShort4));
			ASSUME(v.UShort5 == (ushort)(a.UShort5 % b.UShort5));
			ASSUME(v.UShort6 == (ushort)(a.UShort6 % b.UShort6));
			ASSUME(v.UShort7 == (ushort)(a.UShort7 % b.UShort7));
			ASSUME(v.UShort8 == (ushort)(a.UShort8 % b.UShort8));
			ASSUME(v.UShort9 == (ushort)(a.UShort9 % b.UShort9));
			ASSUME(v.UShort10 == (ushort)(a.UShort10 % b.UShort10));
			ASSUME(v.UShort11 == (ushort)(a.UShort11 % b.UShort11));
			ASSUME(v.UShort12 == (ushort)(a.UShort12 % b.UShort12));
			ASSUME(v.UShort13 == (ushort)(a.UShort13 % b.UShort13));
			ASSUME(v.UShort14 == (ushort)(a.UShort14 % b.UShort14));
			ASSUME(v.UShort15 == (ushort)(a.UShort15 % b.UShort15));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_REMAINDER_EPU32(v256 v, v256 a, v256 b, byte elements = 8)
		{
			ASSUME_NEQ_EPU32(b, 0, elements);
			ASSUME_LT_EPU32(v, b);
			ASSUME_LE_EPU32(v, a);

			ASSUME(v.UInt0 == a.UInt0 % b.UInt0);
			if (elements == 1) return;
			ASSUME(v.UInt1 == a.UInt1 % b.UInt1);
			ASSUME(v.UInt2 == a.UInt2 % b.UInt2);
			ASSUME(v.UInt3 == a.UInt3 % b.UInt3);
			ASSUME(v.UInt4 == a.UInt4 % b.UInt4);
			ASSUME(v.UInt5 == a.UInt5 % b.UInt5);
			ASSUME(v.UInt6 == a.UInt6 % b.UInt6);
			ASSUME(v.UInt7 == a.UInt7 % b.UInt7);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ASSUME_REMAINDER_EPU64(v256 v, v256 a, v256 b, byte elements = 4)
		{
			ASSUME_NEQ_EPU64(b, 0, elements);
			ASSUME_LT_EPU64(v, b, elements);
			ASSUME_LE_EPU64(v, a, elements);

			ASSUME(v.ULong0 == a.ULong0 % b.ULong0);
			if (elements == 1) return;
			ASSUME(v.ULong1 == a.ULong1 % b.ULong1);
			ASSUME(v.ULong2 == a.ULong2 % b.ULong2);
			if (elements == 3) return;
			ASSUME(v.ULong3 == a.ULong3 % b.ULong3);
		}
	}
}
