using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
	{
		public static partial class constexpr
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_EQ_EPU8(v128 v, int cmpVal)
			{
				Hint.Assume(v.Byte0  == cmpVal); 
				Hint.Assume(v.Byte1  == cmpVal);
				Hint.Assume(v.Byte2  == cmpVal);
				Hint.Assume(v.Byte3  == cmpVal);
				Hint.Assume(v.Byte4  == cmpVal);
				Hint.Assume(v.Byte5  == cmpVal);
				Hint.Assume(v.Byte6  == cmpVal);
				Hint.Assume(v.Byte7  == cmpVal);
				Hint.Assume(v.Byte8  == cmpVal);
				Hint.Assume(v.Byte9  == cmpVal);
				Hint.Assume(v.Byte10 == cmpVal);
				Hint.Assume(v.Byte11 == cmpVal);
				Hint.Assume(v.Byte12 == cmpVal);
				Hint.Assume(v.Byte13 == cmpVal);
				Hint.Assume(v.Byte14 == cmpVal);
				Hint.Assume(v.Byte15 == cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_EQ_EPU16(v128 v, int cmpVal)
			{
				Hint.Assume(v.UShort0 == cmpVal); 
				Hint.Assume(v.UShort1 == cmpVal);
				Hint.Assume(v.UShort2 == cmpVal);
				Hint.Assume(v.UShort3 == cmpVal);
				Hint.Assume(v.UShort4 == cmpVal);
				Hint.Assume(v.UShort5 == cmpVal);
				Hint.Assume(v.UShort6 == cmpVal);
				Hint.Assume(v.UShort7 == cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_EQ_EPU32(v128 v, uint cmpVal)
			{
				Hint.Assume(v.UInt0 == cmpVal); 
				Hint.Assume(v.UInt1 == cmpVal);
				Hint.Assume(v.UInt2 == cmpVal);
				Hint.Assume(v.UInt3 == cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_EQ_EPU64(v128 v, ulong cmpVal)
			{
				Hint.Assume(v.ULong0 == cmpVal); 
				Hint.Assume(v.ULong1 == cmpVal);
			}


			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_EQ_EPI8(v128 v, int cmpVal)
			{
				Hint.Assume(v.SByte0  == cmpVal); 
				Hint.Assume(v.SByte1  == cmpVal);
				Hint.Assume(v.SByte2  == cmpVal);
				Hint.Assume(v.SByte3  == cmpVal);
				Hint.Assume(v.SByte4  == cmpVal);
				Hint.Assume(v.SByte5  == cmpVal);
				Hint.Assume(v.SByte6  == cmpVal);
				Hint.Assume(v.SByte7  == cmpVal);
				Hint.Assume(v.SByte8  == cmpVal);
				Hint.Assume(v.SByte9  == cmpVal);
				Hint.Assume(v.SByte10 == cmpVal);
				Hint.Assume(v.SByte11 == cmpVal);
				Hint.Assume(v.SByte12 == cmpVal);
				Hint.Assume(v.SByte13 == cmpVal);
				Hint.Assume(v.SByte14 == cmpVal);
				Hint.Assume(v.SByte15 == cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_EQ_EPI16(v128 v, int cmpVal)
			{
				Hint.Assume(v.SShort0 == cmpVal); 
				Hint.Assume(v.SShort1 == cmpVal);
				Hint.Assume(v.SShort2 == cmpVal);
				Hint.Assume(v.SShort3 == cmpVal);
				Hint.Assume(v.SShort4 == cmpVal);
				Hint.Assume(v.SShort5 == cmpVal);
				Hint.Assume(v.SShort6 == cmpVal);
				Hint.Assume(v.SShort7 == cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_EQ_EPI32(v128 v, int cmpVal)
			{
				Hint.Assume(v.SInt0 == cmpVal); 
				Hint.Assume(v.SInt1 == cmpVal);
				Hint.Assume(v.SInt2 == cmpVal);
				Hint.Assume(v.SInt3 == cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_EQ_EPI64(v128 v, long cmpVal)
			{
				Hint.Assume(v.SLong0 == cmpVal); 
				Hint.Assume(v.SLong1 == cmpVal);
			}
			

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_EQ_PS(v128 v, float cmpVal)
			{
				Hint.Assume(v.Float0 == cmpVal); 
				Hint.Assume(v.Float1 == cmpVal);
				Hint.Assume(v.Float2 == cmpVal);
				Hint.Assume(v.Float3 == cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_EQ_PD(v128 v, double cmpVal)
			{
				Hint.Assume(v.Double0 == cmpVal); 
				Hint.Assume(v.Double1 == cmpVal);
			}


			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_EQ_EPU8(v256 v, int cmpVal)
			{
				Hint.Assume(v.Byte0  == cmpVal); 
				Hint.Assume(v.Byte1  == cmpVal);
				Hint.Assume(v.Byte2  == cmpVal);
				Hint.Assume(v.Byte3  == cmpVal);
				Hint.Assume(v.Byte4  == cmpVal);
				Hint.Assume(v.Byte5  == cmpVal);
				Hint.Assume(v.Byte6  == cmpVal);
				Hint.Assume(v.Byte7  == cmpVal);
				Hint.Assume(v.Byte8  == cmpVal);
				Hint.Assume(v.Byte9  == cmpVal);
				Hint.Assume(v.Byte10 == cmpVal);
				Hint.Assume(v.Byte11 == cmpVal);
				Hint.Assume(v.Byte12 == cmpVal);
				Hint.Assume(v.Byte13 == cmpVal);
				Hint.Assume(v.Byte14 == cmpVal);
				Hint.Assume(v.Byte15 == cmpVal);
				Hint.Assume(v.Byte16 == cmpVal); 
				Hint.Assume(v.Byte17 == cmpVal);
				Hint.Assume(v.Byte18 == cmpVal);
				Hint.Assume(v.Byte19 == cmpVal);
				Hint.Assume(v.Byte20 == cmpVal);
				Hint.Assume(v.Byte21 == cmpVal);
				Hint.Assume(v.Byte22 == cmpVal);
				Hint.Assume(v.Byte23 == cmpVal);
				Hint.Assume(v.Byte24 == cmpVal);
				Hint.Assume(v.Byte25 == cmpVal);
				Hint.Assume(v.Byte26 == cmpVal);
				Hint.Assume(v.Byte27 == cmpVal);
				Hint.Assume(v.Byte28 == cmpVal);
				Hint.Assume(v.Byte29 == cmpVal);
				Hint.Assume(v.Byte30 == cmpVal);
				Hint.Assume(v.Byte31 == cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_EQ_EPU16(v256 v, int cmpVal)
			{
				Hint.Assume(v.UShort0  == cmpVal); 
				Hint.Assume(v.UShort1  == cmpVal);
				Hint.Assume(v.UShort2  == cmpVal);
				Hint.Assume(v.UShort3  == cmpVal);
				Hint.Assume(v.UShort4  == cmpVal);
				Hint.Assume(v.UShort5  == cmpVal);
				Hint.Assume(v.UShort6  == cmpVal);
				Hint.Assume(v.UShort7  == cmpVal);
				Hint.Assume(v.UShort8  == cmpVal);
				Hint.Assume(v.UShort9  == cmpVal);
				Hint.Assume(v.UShort10 == cmpVal);
				Hint.Assume(v.UShort11 == cmpVal);
				Hint.Assume(v.UShort12 == cmpVal);
				Hint.Assume(v.UShort13 == cmpVal);
				Hint.Assume(v.UShort14 == cmpVal);
				Hint.Assume(v.UShort15 == cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_EQ_EPU32(v256 v, uint cmpVal)
			{
				Hint.Assume(v.UInt0  == cmpVal); 
				Hint.Assume(v.UInt1  == cmpVal);
				Hint.Assume(v.UInt2  == cmpVal);
				Hint.Assume(v.UInt3  == cmpVal);
				Hint.Assume(v.UInt4  == cmpVal);
				Hint.Assume(v.UInt5  == cmpVal);
				Hint.Assume(v.UInt6  == cmpVal);
				Hint.Assume(v.UInt7  == cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_EQ_EPU64(v256 v, ulong cmpVal)
			{
				Hint.Assume(v.ULong0  == cmpVal); 
				Hint.Assume(v.ULong1  == cmpVal);
				Hint.Assume(v.ULong2  == cmpVal);
				Hint.Assume(v.ULong3  == cmpVal);
			}


			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_EQ_EPI8(v256 v, int cmpVal)
			{
				Hint.Assume(v.SByte0  == cmpVal); 
				Hint.Assume(v.SByte1  == cmpVal);
				Hint.Assume(v.SByte2  == cmpVal);
				Hint.Assume(v.SByte3  == cmpVal);
				Hint.Assume(v.SByte4  == cmpVal);
				Hint.Assume(v.SByte5  == cmpVal);
				Hint.Assume(v.SByte6  == cmpVal);
				Hint.Assume(v.SByte7  == cmpVal);
				Hint.Assume(v.SByte8  == cmpVal);
				Hint.Assume(v.SByte9  == cmpVal);
				Hint.Assume(v.SByte10 == cmpVal);
				Hint.Assume(v.SByte11 == cmpVal);
				Hint.Assume(v.SByte12 == cmpVal);
				Hint.Assume(v.SByte13 == cmpVal);
				Hint.Assume(v.SByte14 == cmpVal);
				Hint.Assume(v.SByte15 == cmpVal);
				Hint.Assume(v.SByte16 == cmpVal); 
				Hint.Assume(v.SByte17 == cmpVal);
				Hint.Assume(v.SByte18 == cmpVal);
				Hint.Assume(v.SByte19 == cmpVal);
				Hint.Assume(v.SByte20 == cmpVal);
				Hint.Assume(v.SByte21 == cmpVal);
				Hint.Assume(v.SByte22 == cmpVal);
				Hint.Assume(v.SByte23 == cmpVal);
				Hint.Assume(v.SByte24 == cmpVal);
				Hint.Assume(v.SByte25 == cmpVal);
				Hint.Assume(v.SByte26 == cmpVal);
				Hint.Assume(v.SByte27 == cmpVal);
				Hint.Assume(v.SByte28 == cmpVal);
				Hint.Assume(v.SByte29 == cmpVal);
				Hint.Assume(v.SByte30 == cmpVal);
				Hint.Assume(v.SByte31 == cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_EQ_EPI16(v256 v, int cmpVal)
			{
				Hint.Assume(v.SShort0  == cmpVal); 
				Hint.Assume(v.SShort1  == cmpVal);
				Hint.Assume(v.SShort2  == cmpVal);
				Hint.Assume(v.SShort3  == cmpVal);
				Hint.Assume(v.SShort4  == cmpVal);
				Hint.Assume(v.SShort5  == cmpVal);
				Hint.Assume(v.SShort6  == cmpVal);
				Hint.Assume(v.SShort7  == cmpVal);
				Hint.Assume(v.SShort8  == cmpVal);
				Hint.Assume(v.SShort9  == cmpVal);
				Hint.Assume(v.SShort10 == cmpVal);
				Hint.Assume(v.SShort11 == cmpVal);
				Hint.Assume(v.SShort12 == cmpVal);
				Hint.Assume(v.SShort13 == cmpVal);
				Hint.Assume(v.SShort14 == cmpVal);
				Hint.Assume(v.SShort15 == cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_EQ_EPI32(v256 v, int cmpVal)
			{
				Hint.Assume(v.SInt0  == cmpVal); 
				Hint.Assume(v.SInt1  == cmpVal);
				Hint.Assume(v.SInt2  == cmpVal);
				Hint.Assume(v.SInt3  == cmpVal);
				Hint.Assume(v.SInt4  == cmpVal);
				Hint.Assume(v.SInt5  == cmpVal);
				Hint.Assume(v.SInt6  == cmpVal);
				Hint.Assume(v.SInt7  == cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_EQ_EPI64(v256 v, long cmpVal)
			{
				Hint.Assume(v.SLong0  == cmpVal); 
				Hint.Assume(v.SLong1  == cmpVal);
				Hint.Assume(v.SLong2  == cmpVal);
				Hint.Assume(v.SLong3  == cmpVal);
			}


			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_EQ_PS(v256 v, float cmpVal)
			{
				Hint.Assume(v.Float0 == cmpVal); 
				Hint.Assume(v.Float1 == cmpVal);
				Hint.Assume(v.Float2 == cmpVal);
				Hint.Assume(v.Float3 == cmpVal);
				Hint.Assume(v.Float4 == cmpVal);
				Hint.Assume(v.Float5 == cmpVal);
				Hint.Assume(v.Float6 == cmpVal);
				Hint.Assume(v.Float7 == cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_EQ_PD(v256 v, double cmpVal)
			{
				Hint.Assume(v.Double0 == cmpVal); 
				Hint.Assume(v.Double1 == cmpVal);
				Hint.Assume(v.Double2 == cmpVal);
				Hint.Assume(v.Double3 == cmpVal);
			}


			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_NEQ_EPU8(v128 v, int cmpVal)
			{
				Hint.Assume(v.Byte0  != cmpVal); 
				Hint.Assume(v.Byte1  != cmpVal);
				Hint.Assume(v.Byte2  != cmpVal);
				Hint.Assume(v.Byte3  != cmpVal);
				Hint.Assume(v.Byte4  != cmpVal);
				Hint.Assume(v.Byte5  != cmpVal);
				Hint.Assume(v.Byte6  != cmpVal);
				Hint.Assume(v.Byte7  != cmpVal);
				Hint.Assume(v.Byte8  != cmpVal);
				Hint.Assume(v.Byte9  != cmpVal);
				Hint.Assume(v.Byte10 != cmpVal);
				Hint.Assume(v.Byte11 != cmpVal);
				Hint.Assume(v.Byte12 != cmpVal);
				Hint.Assume(v.Byte13 != cmpVal);
				Hint.Assume(v.Byte14 != cmpVal);
				Hint.Assume(v.Byte15 != cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_NEQ_EPU16(v128 v, int cmpVal)
			{
				Hint.Assume(v.UShort0 != cmpVal); 
				Hint.Assume(v.UShort1 != cmpVal);
				Hint.Assume(v.UShort2 != cmpVal);
				Hint.Assume(v.UShort3 != cmpVal);
				Hint.Assume(v.UShort4 != cmpVal);
				Hint.Assume(v.UShort5 != cmpVal);
				Hint.Assume(v.UShort6 != cmpVal);
				Hint.Assume(v.UShort7 != cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_NEQ_EPU32(v128 v, uint cmpVal)
			{
				Hint.Assume(v.UInt0 != cmpVal); 
				Hint.Assume(v.UInt1 != cmpVal);
				Hint.Assume(v.UInt2 != cmpVal);
				Hint.Assume(v.UInt3 != cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_NEQ_EPU64(v128 v, ulong cmpVal)
			{
				Hint.Assume(v.ULong0 != cmpVal); 
				Hint.Assume(v.ULong1 != cmpVal);
			}


			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_NEQ_EPI8(v128 v, int cmpVal)
			{
				Hint.Assume(v.SByte0  != cmpVal); 
				Hint.Assume(v.SByte1  != cmpVal);
				Hint.Assume(v.SByte2  != cmpVal);
				Hint.Assume(v.SByte3  != cmpVal);
				Hint.Assume(v.SByte4  != cmpVal);
				Hint.Assume(v.SByte5  != cmpVal);
				Hint.Assume(v.SByte6  != cmpVal);
				Hint.Assume(v.SByte7  != cmpVal);
				Hint.Assume(v.SByte8  != cmpVal);
				Hint.Assume(v.SByte9  != cmpVal);
				Hint.Assume(v.SByte10 != cmpVal);
				Hint.Assume(v.SByte11 != cmpVal);
				Hint.Assume(v.SByte12 != cmpVal);
				Hint.Assume(v.SByte13 != cmpVal);
				Hint.Assume(v.SByte14 != cmpVal);
				Hint.Assume(v.SByte15 != cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_NEQ_EPI16(v128 v, int cmpVal)
			{
				Hint.Assume(v.SShort0 != cmpVal); 
				Hint.Assume(v.SShort1 != cmpVal);
				Hint.Assume(v.SShort2 != cmpVal);
				Hint.Assume(v.SShort3 != cmpVal);
				Hint.Assume(v.SShort4 != cmpVal);
				Hint.Assume(v.SShort5 != cmpVal);
				Hint.Assume(v.SShort6 != cmpVal);
				Hint.Assume(v.SShort7 != cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_NEQ_EPI32(v128 v, int cmpVal)
			{
				Hint.Assume(v.SInt0 != cmpVal); 
				Hint.Assume(v.SInt1 != cmpVal);
				Hint.Assume(v.SInt2 != cmpVal);
				Hint.Assume(v.SInt3 != cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_NEQ_EPI64(v128 v, long cmpVal)
			{
				Hint.Assume(v.SLong0 != cmpVal); 
				Hint.Assume(v.SLong1 != cmpVal);
			}
			

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_NEQ_PS(v128 v, float cmpVal)
			{
				Hint.Assume(v.Float0 != cmpVal); 
				Hint.Assume(v.Float1 != cmpVal);
				Hint.Assume(v.Float2 != cmpVal);
				Hint.Assume(v.Float3 != cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_NEQ_PD(v128 v, double cmpVal)
			{
				Hint.Assume(v.Double0 != cmpVal); 
				Hint.Assume(v.Double1 != cmpVal);
			}


			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_NEQ_EPU8(v256 v, int cmpVal)
			{
				Hint.Assume(v.Byte0  != cmpVal); 
				Hint.Assume(v.Byte1  != cmpVal);
				Hint.Assume(v.Byte2  != cmpVal);
				Hint.Assume(v.Byte3  != cmpVal);
				Hint.Assume(v.Byte4  != cmpVal);
				Hint.Assume(v.Byte5  != cmpVal);
				Hint.Assume(v.Byte6  != cmpVal);
				Hint.Assume(v.Byte7  != cmpVal);
				Hint.Assume(v.Byte8  != cmpVal);
				Hint.Assume(v.Byte9  != cmpVal);
				Hint.Assume(v.Byte10 != cmpVal);
				Hint.Assume(v.Byte11 != cmpVal);
				Hint.Assume(v.Byte12 != cmpVal);
				Hint.Assume(v.Byte13 != cmpVal);
				Hint.Assume(v.Byte14 != cmpVal);
				Hint.Assume(v.Byte15 != cmpVal);
				Hint.Assume(v.Byte16 != cmpVal); 
				Hint.Assume(v.Byte17 != cmpVal);
				Hint.Assume(v.Byte18 != cmpVal);
				Hint.Assume(v.Byte19 != cmpVal);
				Hint.Assume(v.Byte20 != cmpVal);
				Hint.Assume(v.Byte21 != cmpVal);
				Hint.Assume(v.Byte22 != cmpVal);
				Hint.Assume(v.Byte23 != cmpVal);
				Hint.Assume(v.Byte24 != cmpVal);
				Hint.Assume(v.Byte25 != cmpVal);
				Hint.Assume(v.Byte26 != cmpVal);
				Hint.Assume(v.Byte27 != cmpVal);
				Hint.Assume(v.Byte28 != cmpVal);
				Hint.Assume(v.Byte29 != cmpVal);
				Hint.Assume(v.Byte30 != cmpVal);
				Hint.Assume(v.Byte31 != cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_NEQ_EPU16(v256 v, int cmpVal)
			{
				Hint.Assume(v.UShort0  != cmpVal); 
				Hint.Assume(v.UShort1  != cmpVal);
				Hint.Assume(v.UShort2  != cmpVal);
				Hint.Assume(v.UShort3  != cmpVal);
				Hint.Assume(v.UShort4  != cmpVal);
				Hint.Assume(v.UShort5  != cmpVal);
				Hint.Assume(v.UShort6  != cmpVal);
				Hint.Assume(v.UShort7  != cmpVal);
				Hint.Assume(v.UShort8  != cmpVal);
				Hint.Assume(v.UShort9  != cmpVal);
				Hint.Assume(v.UShort10 != cmpVal);
				Hint.Assume(v.UShort11 != cmpVal);
				Hint.Assume(v.UShort12 != cmpVal);
				Hint.Assume(v.UShort13 != cmpVal);
				Hint.Assume(v.UShort14 != cmpVal);
				Hint.Assume(v.UShort15 != cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_NEQ_EPU32(v256 v, uint cmpVal)
			{
				Hint.Assume(v.UInt0  != cmpVal); 
				Hint.Assume(v.UInt1  != cmpVal);
				Hint.Assume(v.UInt2  != cmpVal);
				Hint.Assume(v.UInt3  != cmpVal);
				Hint.Assume(v.UInt4  != cmpVal);
				Hint.Assume(v.UInt5  != cmpVal);
				Hint.Assume(v.UInt6  != cmpVal);
				Hint.Assume(v.UInt7  != cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_NEQ_EPU64(v256 v, ulong cmpVal)
			{
				Hint.Assume(v.ULong0  != cmpVal); 
				Hint.Assume(v.ULong1  != cmpVal);
				Hint.Assume(v.ULong2  != cmpVal);
				Hint.Assume(v.ULong3  != cmpVal);
			}


			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_NEQ_EPI8(v256 v, int cmpVal)
			{
				Hint.Assume(v.SByte0  != cmpVal); 
				Hint.Assume(v.SByte1  != cmpVal);
				Hint.Assume(v.SByte2  != cmpVal);
				Hint.Assume(v.SByte3  != cmpVal);
				Hint.Assume(v.SByte4  != cmpVal);
				Hint.Assume(v.SByte5  != cmpVal);
				Hint.Assume(v.SByte6  != cmpVal);
				Hint.Assume(v.SByte7  != cmpVal);
				Hint.Assume(v.SByte8  != cmpVal);
				Hint.Assume(v.SByte9  != cmpVal);
				Hint.Assume(v.SByte10 != cmpVal);
				Hint.Assume(v.SByte11 != cmpVal);
				Hint.Assume(v.SByte12 != cmpVal);
				Hint.Assume(v.SByte13 != cmpVal);
				Hint.Assume(v.SByte14 != cmpVal);
				Hint.Assume(v.SByte15 != cmpVal);
				Hint.Assume(v.SByte16 != cmpVal); 
				Hint.Assume(v.SByte17 != cmpVal);
				Hint.Assume(v.SByte18 != cmpVal);
				Hint.Assume(v.SByte19 != cmpVal);
				Hint.Assume(v.SByte20 != cmpVal);
				Hint.Assume(v.SByte21 != cmpVal);
				Hint.Assume(v.SByte22 != cmpVal);
				Hint.Assume(v.SByte23 != cmpVal);
				Hint.Assume(v.SByte24 != cmpVal);
				Hint.Assume(v.SByte25 != cmpVal);
				Hint.Assume(v.SByte26 != cmpVal);
				Hint.Assume(v.SByte27 != cmpVal);
				Hint.Assume(v.SByte28 != cmpVal);
				Hint.Assume(v.SByte29 != cmpVal);
				Hint.Assume(v.SByte30 != cmpVal);
				Hint.Assume(v.SByte31 != cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_NEQ_EPI16(v256 v, int cmpVal)
			{
				Hint.Assume(v.SShort0  != cmpVal); 
				Hint.Assume(v.SShort1  != cmpVal);
				Hint.Assume(v.SShort2  != cmpVal);
				Hint.Assume(v.SShort3  != cmpVal);
				Hint.Assume(v.SShort4  != cmpVal);
				Hint.Assume(v.SShort5  != cmpVal);
				Hint.Assume(v.SShort6  != cmpVal);
				Hint.Assume(v.SShort7  != cmpVal);
				Hint.Assume(v.SShort8  != cmpVal);
				Hint.Assume(v.SShort9  != cmpVal);
				Hint.Assume(v.SShort10 != cmpVal);
				Hint.Assume(v.SShort11 != cmpVal);
				Hint.Assume(v.SShort12 != cmpVal);
				Hint.Assume(v.SShort13 != cmpVal);
				Hint.Assume(v.SShort14 != cmpVal);
				Hint.Assume(v.SShort15 != cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_NEQ_EPI32(v256 v, int cmpVal)
			{
				Hint.Assume(v.SInt0  != cmpVal); 
				Hint.Assume(v.SInt1  != cmpVal);
				Hint.Assume(v.SInt2  != cmpVal);
				Hint.Assume(v.SInt3  != cmpVal);
				Hint.Assume(v.SInt4  != cmpVal);
				Hint.Assume(v.SInt5  != cmpVal);
				Hint.Assume(v.SInt6  != cmpVal);
				Hint.Assume(v.SInt7  != cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_NEQ_EPI64(v256 v, long cmpVal)
			{
				Hint.Assume(v.SLong0  != cmpVal); 
				Hint.Assume(v.SLong1  != cmpVal);
				Hint.Assume(v.SLong2  != cmpVal);
				Hint.Assume(v.SLong3  != cmpVal);
			}


			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_NEQ_PS(v256 v, float cmpVal)
			{
				Hint.Assume(v.Float0 != cmpVal); 
				Hint.Assume(v.Float1 != cmpVal);
				Hint.Assume(v.Float2 != cmpVal);
				Hint.Assume(v.Float3 != cmpVal);
				Hint.Assume(v.Float4 != cmpVal);
				Hint.Assume(v.Float5 != cmpVal);
				Hint.Assume(v.Float6 != cmpVal);
				Hint.Assume(v.Float7 != cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_NEQ_PD(v256 v, double cmpVal)
			{
				Hint.Assume(v.Double0 != cmpVal); 
				Hint.Assume(v.Double1 != cmpVal);
				Hint.Assume(v.Double2 != cmpVal);
				Hint.Assume(v.Double3 != cmpVal);
			}


			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_GT_EPU8(v128 v, int cmpVal)
			{
				Hint.Assume(v.Byte0  > cmpVal); 
				Hint.Assume(v.Byte1  > cmpVal);
				Hint.Assume(v.Byte2  > cmpVal);
				Hint.Assume(v.Byte3  > cmpVal);
				Hint.Assume(v.Byte4  > cmpVal);
				Hint.Assume(v.Byte5  > cmpVal);
				Hint.Assume(v.Byte6  > cmpVal);
				Hint.Assume(v.Byte7  > cmpVal);
				Hint.Assume(v.Byte8  > cmpVal);
				Hint.Assume(v.Byte9  > cmpVal);
				Hint.Assume(v.Byte10 > cmpVal);
				Hint.Assume(v.Byte11 > cmpVal);
				Hint.Assume(v.Byte12 > cmpVal);
				Hint.Assume(v.Byte13 > cmpVal);
				Hint.Assume(v.Byte14 > cmpVal);
				Hint.Assume(v.Byte15 > cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_GT_EPU16(v128 v, int cmpVal)
			{
				Hint.Assume(v.UShort0 > cmpVal); 
				Hint.Assume(v.UShort1 > cmpVal);
				Hint.Assume(v.UShort2 > cmpVal);
				Hint.Assume(v.UShort3 > cmpVal);
				Hint.Assume(v.UShort4 > cmpVal);
				Hint.Assume(v.UShort5 > cmpVal);
				Hint.Assume(v.UShort6 > cmpVal);
				Hint.Assume(v.UShort7 > cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_GT_EPU32(v128 v, uint cmpVal)
			{
				Hint.Assume(v.UInt0 > cmpVal); 
				Hint.Assume(v.UInt1 > cmpVal);
				Hint.Assume(v.UInt2 > cmpVal);
				Hint.Assume(v.UInt3 > cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_GT_EPU64(v128 v, ulong cmpVal)
			{
				Hint.Assume(v.ULong0 > cmpVal); 
				Hint.Assume(v.ULong1 > cmpVal);
			}


			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_GT_EPI8(v128 v, int cmpVal)
			{
				Hint.Assume(v.SByte0  > cmpVal); 
				Hint.Assume(v.SByte1  > cmpVal);
				Hint.Assume(v.SByte2  > cmpVal);
				Hint.Assume(v.SByte3  > cmpVal);
				Hint.Assume(v.SByte4  > cmpVal);
				Hint.Assume(v.SByte5  > cmpVal);
				Hint.Assume(v.SByte6  > cmpVal);
				Hint.Assume(v.SByte7  > cmpVal);
				Hint.Assume(v.SByte8  > cmpVal);
				Hint.Assume(v.SByte9  > cmpVal);
				Hint.Assume(v.SByte10 > cmpVal);
				Hint.Assume(v.SByte11 > cmpVal);
				Hint.Assume(v.SByte12 > cmpVal);
				Hint.Assume(v.SByte13 > cmpVal);
				Hint.Assume(v.SByte14 > cmpVal);
				Hint.Assume(v.SByte15 > cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_GT_EPI16(v128 v, int cmpVal)
			{
				Hint.Assume(v.SShort0 > cmpVal); 
				Hint.Assume(v.SShort1 > cmpVal);
				Hint.Assume(v.SShort2 > cmpVal);
				Hint.Assume(v.SShort3 > cmpVal);
				Hint.Assume(v.SShort4 > cmpVal);
				Hint.Assume(v.SShort5 > cmpVal);
				Hint.Assume(v.SShort6 > cmpVal);
				Hint.Assume(v.SShort7 > cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_GT_EPI32(v128 v, int cmpVal)
			{
				Hint.Assume(v.SInt0 > cmpVal); 
				Hint.Assume(v.SInt1 > cmpVal);
				Hint.Assume(v.SInt2 > cmpVal);
				Hint.Assume(v.SInt3 > cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_GT_EPI64(v128 v, long cmpVal)
			{
				Hint.Assume(v.SLong0 > cmpVal); 
				Hint.Assume(v.SLong1 > cmpVal);
			}
			

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_GT_PS(v128 v, float cmpVal)
			{
				Hint.Assume(v.Float0 > cmpVal); 
				Hint.Assume(v.Float1 > cmpVal);
				Hint.Assume(v.Float2 > cmpVal);
				Hint.Assume(v.Float3 > cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_GT_PD(v128 v, double cmpVal)
			{
				Hint.Assume(v.Double0 > cmpVal); 
				Hint.Assume(v.Double1 > cmpVal);
			}


			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_GT_EPU8(v256 v, int cmpVal)
			{
				Hint.Assume(v.Byte0  > cmpVal); 
				Hint.Assume(v.Byte1  > cmpVal);
				Hint.Assume(v.Byte2  > cmpVal);
				Hint.Assume(v.Byte3  > cmpVal);
				Hint.Assume(v.Byte4  > cmpVal);
				Hint.Assume(v.Byte5  > cmpVal);
				Hint.Assume(v.Byte6  > cmpVal);
				Hint.Assume(v.Byte7  > cmpVal);
				Hint.Assume(v.Byte8  > cmpVal);
				Hint.Assume(v.Byte9  > cmpVal);
				Hint.Assume(v.Byte10 > cmpVal);
				Hint.Assume(v.Byte11 > cmpVal);
				Hint.Assume(v.Byte12 > cmpVal);
				Hint.Assume(v.Byte13 > cmpVal);
				Hint.Assume(v.Byte14 > cmpVal);
				Hint.Assume(v.Byte15 > cmpVal);
				Hint.Assume(v.Byte16 > cmpVal); 
				Hint.Assume(v.Byte17 > cmpVal);
				Hint.Assume(v.Byte18 > cmpVal);
				Hint.Assume(v.Byte19 > cmpVal);
				Hint.Assume(v.Byte20 > cmpVal);
				Hint.Assume(v.Byte21 > cmpVal);
				Hint.Assume(v.Byte22 > cmpVal);
				Hint.Assume(v.Byte23 > cmpVal);
				Hint.Assume(v.Byte24 > cmpVal);
				Hint.Assume(v.Byte25 > cmpVal);
				Hint.Assume(v.Byte26 > cmpVal);
				Hint.Assume(v.Byte27 > cmpVal);
				Hint.Assume(v.Byte28 > cmpVal);
				Hint.Assume(v.Byte29 > cmpVal);
				Hint.Assume(v.Byte30 > cmpVal);
				Hint.Assume(v.Byte31 > cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_GT_EPU16(v256 v, int cmpVal)
			{
				Hint.Assume(v.UShort0  > cmpVal); 
				Hint.Assume(v.UShort1  > cmpVal);
				Hint.Assume(v.UShort2  > cmpVal);
				Hint.Assume(v.UShort3  > cmpVal);
				Hint.Assume(v.UShort4  > cmpVal);
				Hint.Assume(v.UShort5  > cmpVal);
				Hint.Assume(v.UShort6  > cmpVal);
				Hint.Assume(v.UShort7  > cmpVal);
				Hint.Assume(v.UShort8  > cmpVal);
				Hint.Assume(v.UShort9  > cmpVal);
				Hint.Assume(v.UShort10 > cmpVal);
				Hint.Assume(v.UShort11 > cmpVal);
				Hint.Assume(v.UShort12 > cmpVal);
				Hint.Assume(v.UShort13 > cmpVal);
				Hint.Assume(v.UShort14 > cmpVal);
				Hint.Assume(v.UShort15 > cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_GT_EPU32(v256 v, uint cmpVal)
			{
				Hint.Assume(v.UInt0  > cmpVal); 
				Hint.Assume(v.UInt1  > cmpVal);
				Hint.Assume(v.UInt2  > cmpVal);
				Hint.Assume(v.UInt3  > cmpVal);
				Hint.Assume(v.UInt4  > cmpVal);
				Hint.Assume(v.UInt5  > cmpVal);
				Hint.Assume(v.UInt6  > cmpVal);
				Hint.Assume(v.UInt7  > cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_GT_EPU64(v256 v, ulong cmpVal)
			{
				Hint.Assume(v.ULong0  > cmpVal); 
				Hint.Assume(v.ULong1  > cmpVal);
				Hint.Assume(v.ULong2  > cmpVal);
				Hint.Assume(v.ULong3  > cmpVal);
			}


			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_GT_EPI8(v256 v, int cmpVal)
			{
				Hint.Assume(v.SByte0  > cmpVal); 
				Hint.Assume(v.SByte1  > cmpVal);
				Hint.Assume(v.SByte2  > cmpVal);
				Hint.Assume(v.SByte3  > cmpVal);
				Hint.Assume(v.SByte4  > cmpVal);
				Hint.Assume(v.SByte5  > cmpVal);
				Hint.Assume(v.SByte6  > cmpVal);
				Hint.Assume(v.SByte7  > cmpVal);
				Hint.Assume(v.SByte8  > cmpVal);
				Hint.Assume(v.SByte9  > cmpVal);
				Hint.Assume(v.SByte10 > cmpVal);
				Hint.Assume(v.SByte11 > cmpVal);
				Hint.Assume(v.SByte12 > cmpVal);
				Hint.Assume(v.SByte13 > cmpVal);
				Hint.Assume(v.SByte14 > cmpVal);
				Hint.Assume(v.SByte15 > cmpVal);
				Hint.Assume(v.SByte16 > cmpVal); 
				Hint.Assume(v.SByte17 > cmpVal);
				Hint.Assume(v.SByte18 > cmpVal);
				Hint.Assume(v.SByte19 > cmpVal);
				Hint.Assume(v.SByte20 > cmpVal);
				Hint.Assume(v.SByte21 > cmpVal);
				Hint.Assume(v.SByte22 > cmpVal);
				Hint.Assume(v.SByte23 > cmpVal);
				Hint.Assume(v.SByte24 > cmpVal);
				Hint.Assume(v.SByte25 > cmpVal);
				Hint.Assume(v.SByte26 > cmpVal);
				Hint.Assume(v.SByte27 > cmpVal);
				Hint.Assume(v.SByte28 > cmpVal);
				Hint.Assume(v.SByte29 > cmpVal);
				Hint.Assume(v.SByte30 > cmpVal);
				Hint.Assume(v.SByte31 > cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_GT_EPI16(v256 v, int cmpVal)
			{
				Hint.Assume(v.SShort0  > cmpVal); 
				Hint.Assume(v.SShort1  > cmpVal);
				Hint.Assume(v.SShort2  > cmpVal);
				Hint.Assume(v.SShort3  > cmpVal);
				Hint.Assume(v.SShort4  > cmpVal);
				Hint.Assume(v.SShort5  > cmpVal);
				Hint.Assume(v.SShort6  > cmpVal);
				Hint.Assume(v.SShort7  > cmpVal);
				Hint.Assume(v.SShort8  > cmpVal);
				Hint.Assume(v.SShort9  > cmpVal);
				Hint.Assume(v.SShort10 > cmpVal);
				Hint.Assume(v.SShort11 > cmpVal);
				Hint.Assume(v.SShort12 > cmpVal);
				Hint.Assume(v.SShort13 > cmpVal);
				Hint.Assume(v.SShort14 > cmpVal);
				Hint.Assume(v.SShort15 > cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_GT_EPI32(v256 v, int cmpVal)
			{
				Hint.Assume(v.SInt0  > cmpVal); 
				Hint.Assume(v.SInt1  > cmpVal);
				Hint.Assume(v.SInt2  > cmpVal);
				Hint.Assume(v.SInt3  > cmpVal);
				Hint.Assume(v.SInt4  > cmpVal);
				Hint.Assume(v.SInt5  > cmpVal);
				Hint.Assume(v.SInt6  > cmpVal);
				Hint.Assume(v.SInt7  > cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_GT_EPI64(v256 v, long cmpVal)
			{
				Hint.Assume(v.SLong0  > cmpVal); 
				Hint.Assume(v.SLong1  > cmpVal);
				Hint.Assume(v.SLong2  > cmpVal);
				Hint.Assume(v.SLong3  > cmpVal);
			}


			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_GT_PS(v256 v, float cmpVal)
			{
				Hint.Assume(v.Float0 > cmpVal); 
				Hint.Assume(v.Float1 > cmpVal);
				Hint.Assume(v.Float2 > cmpVal);
				Hint.Assume(v.Float3 > cmpVal);
				Hint.Assume(v.Float4 > cmpVal);
				Hint.Assume(v.Float5 > cmpVal);
				Hint.Assume(v.Float6 > cmpVal);
				Hint.Assume(v.Float7 > cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_GT_PD(v256 v, double cmpVal)
			{
				Hint.Assume(v.Double0 > cmpVal); 
				Hint.Assume(v.Double1 > cmpVal);
				Hint.Assume(v.Double2 > cmpVal);
				Hint.Assume(v.Double3 > cmpVal);
			}


			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_LT_EPU8(v128 v, int cmpVal)
			{
				Hint.Assume(v.Byte0  < cmpVal); 
				Hint.Assume(v.Byte1  < cmpVal);
				Hint.Assume(v.Byte2  < cmpVal);
				Hint.Assume(v.Byte3  < cmpVal);
				Hint.Assume(v.Byte4  < cmpVal);
				Hint.Assume(v.Byte5  < cmpVal);
				Hint.Assume(v.Byte6  < cmpVal);
				Hint.Assume(v.Byte7  < cmpVal);
				Hint.Assume(v.Byte8  < cmpVal);
				Hint.Assume(v.Byte9  < cmpVal);
				Hint.Assume(v.Byte10 < cmpVal);
				Hint.Assume(v.Byte11 < cmpVal);
				Hint.Assume(v.Byte12 < cmpVal);
				Hint.Assume(v.Byte13 < cmpVal);
				Hint.Assume(v.Byte14 < cmpVal);
				Hint.Assume(v.Byte15 < cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_LT_EPU16(v128 v, int cmpVal)
			{
				Hint.Assume(v.UShort0 < cmpVal); 
				Hint.Assume(v.UShort1 < cmpVal);
				Hint.Assume(v.UShort2 < cmpVal);
				Hint.Assume(v.UShort3 < cmpVal);
				Hint.Assume(v.UShort4 < cmpVal);
				Hint.Assume(v.UShort5 < cmpVal);
				Hint.Assume(v.UShort6 < cmpVal);
				Hint.Assume(v.UShort7 < cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_LT_EPU32(v128 v, uint cmpVal)
			{
				Hint.Assume(v.UInt0 < cmpVal); 
				Hint.Assume(v.UInt1 < cmpVal);
				Hint.Assume(v.UInt2 < cmpVal);
				Hint.Assume(v.UInt3 < cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_LT_EPU64(v128 v, ulong cmpVal)
			{
				Hint.Assume(v.ULong0 < cmpVal); 
				Hint.Assume(v.ULong1 < cmpVal);
			}


			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_LT_EPI8(v128 v, int cmpVal)
			{
				Hint.Assume(v.SByte0  < cmpVal); 
				Hint.Assume(v.SByte1  < cmpVal);
				Hint.Assume(v.SByte2  < cmpVal);
				Hint.Assume(v.SByte3  < cmpVal);
				Hint.Assume(v.SByte4  < cmpVal);
				Hint.Assume(v.SByte5  < cmpVal);
				Hint.Assume(v.SByte6  < cmpVal);
				Hint.Assume(v.SByte7  < cmpVal);
				Hint.Assume(v.SByte8  < cmpVal);
				Hint.Assume(v.SByte9  < cmpVal);
				Hint.Assume(v.SByte10 < cmpVal);
				Hint.Assume(v.SByte11 < cmpVal);
				Hint.Assume(v.SByte12 < cmpVal);
				Hint.Assume(v.SByte13 < cmpVal);
				Hint.Assume(v.SByte14 < cmpVal);
				Hint.Assume(v.SByte15 < cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_LT_EPI16(v128 v, int cmpVal)
			{
				Hint.Assume(v.SShort0 < cmpVal); 
				Hint.Assume(v.SShort1 < cmpVal);
				Hint.Assume(v.SShort2 < cmpVal);
				Hint.Assume(v.SShort3 < cmpVal);
				Hint.Assume(v.SShort4 < cmpVal);
				Hint.Assume(v.SShort5 < cmpVal);
				Hint.Assume(v.SShort6 < cmpVal);
				Hint.Assume(v.SShort7 < cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_LT_EPI32(v128 v, int cmpVal)
			{
				Hint.Assume(v.SInt0 < cmpVal); 
				Hint.Assume(v.SInt1 < cmpVal);
				Hint.Assume(v.SInt2 < cmpVal);
				Hint.Assume(v.SInt3 < cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_LT_EPI64(v128 v, long cmpVal)
			{
				Hint.Assume(v.SLong0 < cmpVal); 
				Hint.Assume(v.SLong1 < cmpVal);
			}
			

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_LT_PS(v128 v, float cmpVal)
			{
				Hint.Assume(v.Float0 < cmpVal); 
				Hint.Assume(v.Float1 < cmpVal);
				Hint.Assume(v.Float2 < cmpVal);
				Hint.Assume(v.Float3 < cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_LT_PD(v128 v, double cmpVal)
			{
				Hint.Assume(v.Double0 < cmpVal); 
				Hint.Assume(v.Double1 < cmpVal);
			}


			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_LT_EPU8(v256 v, int cmpVal)
			{
				Hint.Assume(v.Byte0  < cmpVal); 
				Hint.Assume(v.Byte1  < cmpVal);
				Hint.Assume(v.Byte2  < cmpVal);
				Hint.Assume(v.Byte3  < cmpVal);
				Hint.Assume(v.Byte4  < cmpVal);
				Hint.Assume(v.Byte5  < cmpVal);
				Hint.Assume(v.Byte6  < cmpVal);
				Hint.Assume(v.Byte7  < cmpVal);
				Hint.Assume(v.Byte8  < cmpVal);
				Hint.Assume(v.Byte9  < cmpVal);
				Hint.Assume(v.Byte10 < cmpVal);
				Hint.Assume(v.Byte11 < cmpVal);
				Hint.Assume(v.Byte12 < cmpVal);
				Hint.Assume(v.Byte13 < cmpVal);
				Hint.Assume(v.Byte14 < cmpVal);
				Hint.Assume(v.Byte15 < cmpVal);
				Hint.Assume(v.Byte16 < cmpVal); 
				Hint.Assume(v.Byte17 < cmpVal);
				Hint.Assume(v.Byte18 < cmpVal);
				Hint.Assume(v.Byte19 < cmpVal);
				Hint.Assume(v.Byte20 < cmpVal);
				Hint.Assume(v.Byte21 < cmpVal);
				Hint.Assume(v.Byte22 < cmpVal);
				Hint.Assume(v.Byte23 < cmpVal);
				Hint.Assume(v.Byte24 < cmpVal);
				Hint.Assume(v.Byte25 < cmpVal);
				Hint.Assume(v.Byte26 < cmpVal);
				Hint.Assume(v.Byte27 < cmpVal);
				Hint.Assume(v.Byte28 < cmpVal);
				Hint.Assume(v.Byte29 < cmpVal);
				Hint.Assume(v.Byte30 < cmpVal);
				Hint.Assume(v.Byte31 < cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_LT_EPU16(v256 v, int cmpVal)
			{
				Hint.Assume(v.UShort0  < cmpVal); 
				Hint.Assume(v.UShort1  < cmpVal);
				Hint.Assume(v.UShort2  < cmpVal);
				Hint.Assume(v.UShort3  < cmpVal);
				Hint.Assume(v.UShort4  < cmpVal);
				Hint.Assume(v.UShort5  < cmpVal);
				Hint.Assume(v.UShort6  < cmpVal);
				Hint.Assume(v.UShort7  < cmpVal);
				Hint.Assume(v.UShort8  < cmpVal);
				Hint.Assume(v.UShort9  < cmpVal);
				Hint.Assume(v.UShort10 < cmpVal);
				Hint.Assume(v.UShort11 < cmpVal);
				Hint.Assume(v.UShort12 < cmpVal);
				Hint.Assume(v.UShort13 < cmpVal);
				Hint.Assume(v.UShort14 < cmpVal);
				Hint.Assume(v.UShort15 < cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_LT_EPU32(v256 v, uint cmpVal)
			{
				Hint.Assume(v.UInt0  < cmpVal); 
				Hint.Assume(v.UInt1  < cmpVal);
				Hint.Assume(v.UInt2  < cmpVal);
				Hint.Assume(v.UInt3  < cmpVal);
				Hint.Assume(v.UInt4  < cmpVal);
				Hint.Assume(v.UInt5  < cmpVal);
				Hint.Assume(v.UInt6  < cmpVal);
				Hint.Assume(v.UInt7  < cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_LT_EPU64(v256 v, ulong cmpVal)
			{
				Hint.Assume(v.ULong0  < cmpVal); 
				Hint.Assume(v.ULong1  < cmpVal);
				Hint.Assume(v.ULong2  < cmpVal);
				Hint.Assume(v.ULong3  < cmpVal);
			}


			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_LT_EPI8(v256 v, int cmpVal)
			{
				Hint.Assume(v.SByte0  < cmpVal); 
				Hint.Assume(v.SByte1  < cmpVal);
				Hint.Assume(v.SByte2  < cmpVal);
				Hint.Assume(v.SByte3  < cmpVal);
				Hint.Assume(v.SByte4  < cmpVal);
				Hint.Assume(v.SByte5  < cmpVal);
				Hint.Assume(v.SByte6  < cmpVal);
				Hint.Assume(v.SByte7  < cmpVal);
				Hint.Assume(v.SByte8  < cmpVal);
				Hint.Assume(v.SByte9  < cmpVal);
				Hint.Assume(v.SByte10 < cmpVal);
				Hint.Assume(v.SByte11 < cmpVal);
				Hint.Assume(v.SByte12 < cmpVal);
				Hint.Assume(v.SByte13 < cmpVal);
				Hint.Assume(v.SByte14 < cmpVal);
				Hint.Assume(v.SByte15 < cmpVal);
				Hint.Assume(v.SByte16 < cmpVal); 
				Hint.Assume(v.SByte17 < cmpVal);
				Hint.Assume(v.SByte18 < cmpVal);
				Hint.Assume(v.SByte19 < cmpVal);
				Hint.Assume(v.SByte20 < cmpVal);
				Hint.Assume(v.SByte21 < cmpVal);
				Hint.Assume(v.SByte22 < cmpVal);
				Hint.Assume(v.SByte23 < cmpVal);
				Hint.Assume(v.SByte24 < cmpVal);
				Hint.Assume(v.SByte25 < cmpVal);
				Hint.Assume(v.SByte26 < cmpVal);
				Hint.Assume(v.SByte27 < cmpVal);
				Hint.Assume(v.SByte28 < cmpVal);
				Hint.Assume(v.SByte29 < cmpVal);
				Hint.Assume(v.SByte30 < cmpVal);
				Hint.Assume(v.SByte31 < cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_LT_EPI16(v256 v, int cmpVal)
			{
				Hint.Assume(v.SShort0  < cmpVal); 
				Hint.Assume(v.SShort1  < cmpVal);
				Hint.Assume(v.SShort2  < cmpVal);
				Hint.Assume(v.SShort3  < cmpVal);
				Hint.Assume(v.SShort4  < cmpVal);
				Hint.Assume(v.SShort5  < cmpVal);
				Hint.Assume(v.SShort6  < cmpVal);
				Hint.Assume(v.SShort7  < cmpVal);
				Hint.Assume(v.SShort8  < cmpVal);
				Hint.Assume(v.SShort9  < cmpVal);
				Hint.Assume(v.SShort10 < cmpVal);
				Hint.Assume(v.SShort11 < cmpVal);
				Hint.Assume(v.SShort12 < cmpVal);
				Hint.Assume(v.SShort13 < cmpVal);
				Hint.Assume(v.SShort14 < cmpVal);
				Hint.Assume(v.SShort15 < cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_LT_EPI32(v256 v, int cmpVal)
			{
				Hint.Assume(v.SInt0  < cmpVal); 
				Hint.Assume(v.SInt1  < cmpVal);
				Hint.Assume(v.SInt2  < cmpVal);
				Hint.Assume(v.SInt3  < cmpVal);
				Hint.Assume(v.SInt4  < cmpVal);
				Hint.Assume(v.SInt5  < cmpVal);
				Hint.Assume(v.SInt6  < cmpVal);
				Hint.Assume(v.SInt7  < cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_LT_EPI64(v256 v, long cmpVal)
			{
				Hint.Assume(v.SLong0  < cmpVal); 
				Hint.Assume(v.SLong1  < cmpVal);
				Hint.Assume(v.SLong2  < cmpVal);
				Hint.Assume(v.SLong3  < cmpVal);
			}


			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_LT_PS(v256 v, float cmpVal)
			{
				Hint.Assume(v.Float0 < cmpVal); 
				Hint.Assume(v.Float1 < cmpVal);
				Hint.Assume(v.Float2 < cmpVal);
				Hint.Assume(v.Float3 < cmpVal);
				Hint.Assume(v.Float4 < cmpVal);
				Hint.Assume(v.Float5 < cmpVal);
				Hint.Assume(v.Float6 < cmpVal);
				Hint.Assume(v.Float7 < cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_LT_PD(v256 v, double cmpVal)
			{
				Hint.Assume(v.Double0 < cmpVal); 
				Hint.Assume(v.Double1 < cmpVal);
				Hint.Assume(v.Double2 < cmpVal);
				Hint.Assume(v.Double3 < cmpVal);
			}


			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_GE_EPU8(v128 v, int cmpVal)
			{
				Hint.Assume(v.Byte0  >= cmpVal); 
				Hint.Assume(v.Byte1  >= cmpVal);
				Hint.Assume(v.Byte2  >= cmpVal);
				Hint.Assume(v.Byte3  >= cmpVal);
				Hint.Assume(v.Byte4  >= cmpVal);
				Hint.Assume(v.Byte5  >= cmpVal);
				Hint.Assume(v.Byte6  >= cmpVal);
				Hint.Assume(v.Byte7  >= cmpVal);
				Hint.Assume(v.Byte8  >= cmpVal);
				Hint.Assume(v.Byte9  >= cmpVal);
				Hint.Assume(v.Byte10 >= cmpVal);
				Hint.Assume(v.Byte11 >= cmpVal);
				Hint.Assume(v.Byte12 >= cmpVal);
				Hint.Assume(v.Byte13 >= cmpVal);
				Hint.Assume(v.Byte14 >= cmpVal);
				Hint.Assume(v.Byte15 >= cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_GE_EPU16(v128 v, int cmpVal)
			{
				Hint.Assume(v.UShort0 >= cmpVal); 
				Hint.Assume(v.UShort1 >= cmpVal);
				Hint.Assume(v.UShort2 >= cmpVal);
				Hint.Assume(v.UShort3 >= cmpVal);
				Hint.Assume(v.UShort4 >= cmpVal);
				Hint.Assume(v.UShort5 >= cmpVal);
				Hint.Assume(v.UShort6 >= cmpVal);
				Hint.Assume(v.UShort7 >= cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_GE_EPU32(v128 v, uint cmpVal)
			{
				Hint.Assume(v.UInt0 >= cmpVal); 
				Hint.Assume(v.UInt1 >= cmpVal);
				Hint.Assume(v.UInt2 >= cmpVal);
				Hint.Assume(v.UInt3 >= cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_GE_EPU64(v128 v, ulong cmpVal)
			{
				Hint.Assume(v.ULong0 >= cmpVal); 
				Hint.Assume(v.ULong1 >= cmpVal);
			}


			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_GE_EPI8(v128 v, int cmpVal)
			{
				Hint.Assume(v.SByte0  >= cmpVal); 
				Hint.Assume(v.SByte1  >= cmpVal);
				Hint.Assume(v.SByte2  >= cmpVal);
				Hint.Assume(v.SByte3  >= cmpVal);
				Hint.Assume(v.SByte4  >= cmpVal);
				Hint.Assume(v.SByte5  >= cmpVal);
				Hint.Assume(v.SByte6  >= cmpVal);
				Hint.Assume(v.SByte7  >= cmpVal);
				Hint.Assume(v.SByte8  >= cmpVal);
				Hint.Assume(v.SByte9  >= cmpVal);
				Hint.Assume(v.SByte10 >= cmpVal);
				Hint.Assume(v.SByte11 >= cmpVal);
				Hint.Assume(v.SByte12 >= cmpVal);
				Hint.Assume(v.SByte13 >= cmpVal);
				Hint.Assume(v.SByte14 >= cmpVal);
				Hint.Assume(v.SByte15 >= cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_GE_EPI16(v128 v, int cmpVal)
			{
				Hint.Assume(v.SShort0 >= cmpVal); 
				Hint.Assume(v.SShort1 >= cmpVal);
				Hint.Assume(v.SShort2 >= cmpVal);
				Hint.Assume(v.SShort3 >= cmpVal);
				Hint.Assume(v.SShort4 >= cmpVal);
				Hint.Assume(v.SShort5 >= cmpVal);
				Hint.Assume(v.SShort6 >= cmpVal);
				Hint.Assume(v.SShort7 >= cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_GE_EPI32(v128 v, int cmpVal)
			{
				Hint.Assume(v.SInt0 >= cmpVal); 
				Hint.Assume(v.SInt1 >= cmpVal);
				Hint.Assume(v.SInt2 >= cmpVal);
				Hint.Assume(v.SInt3 >= cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_GE_EPI64(v128 v, long cmpVal)
			{
				Hint.Assume(v.SLong0 >= cmpVal); 
				Hint.Assume(v.SLong1 >= cmpVal);
			}
			

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_GE_PS(v128 v, float cmpVal)
			{
				Hint.Assume(v.Float0 >= cmpVal); 
				Hint.Assume(v.Float1 >= cmpVal);
				Hint.Assume(v.Float2 >= cmpVal);
				Hint.Assume(v.Float3 >= cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_GE_PD(v128 v, double cmpVal)
			{
				Hint.Assume(v.Double0 >= cmpVal); 
				Hint.Assume(v.Double1 >= cmpVal);
			}


			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_GE_EPU8(v256 v, int cmpVal)
			{
				Hint.Assume(v.Byte0  >= cmpVal); 
				Hint.Assume(v.Byte1  >= cmpVal);
				Hint.Assume(v.Byte2  >= cmpVal);
				Hint.Assume(v.Byte3  >= cmpVal);
				Hint.Assume(v.Byte4  >= cmpVal);
				Hint.Assume(v.Byte5  >= cmpVal);
				Hint.Assume(v.Byte6  >= cmpVal);
				Hint.Assume(v.Byte7  >= cmpVal);
				Hint.Assume(v.Byte8  >= cmpVal);
				Hint.Assume(v.Byte9  >= cmpVal);
				Hint.Assume(v.Byte10 >= cmpVal);
				Hint.Assume(v.Byte11 >= cmpVal);
				Hint.Assume(v.Byte12 >= cmpVal);
				Hint.Assume(v.Byte13 >= cmpVal);
				Hint.Assume(v.Byte14 >= cmpVal);
				Hint.Assume(v.Byte15 >= cmpVal);
				Hint.Assume(v.Byte16 >= cmpVal); 
				Hint.Assume(v.Byte17 >= cmpVal);
				Hint.Assume(v.Byte18 >= cmpVal);
				Hint.Assume(v.Byte19 >= cmpVal);
				Hint.Assume(v.Byte20 >= cmpVal);
				Hint.Assume(v.Byte21 >= cmpVal);
				Hint.Assume(v.Byte22 >= cmpVal);
				Hint.Assume(v.Byte23 >= cmpVal);
				Hint.Assume(v.Byte24 >= cmpVal);
				Hint.Assume(v.Byte25 >= cmpVal);
				Hint.Assume(v.Byte26 >= cmpVal);
				Hint.Assume(v.Byte27 >= cmpVal);
				Hint.Assume(v.Byte28 >= cmpVal);
				Hint.Assume(v.Byte29 >= cmpVal);
				Hint.Assume(v.Byte30 >= cmpVal);
				Hint.Assume(v.Byte31 >= cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_GE_EPU16(v256 v, int cmpVal)
			{
				Hint.Assume(v.UShort0  >= cmpVal); 
				Hint.Assume(v.UShort1  >= cmpVal);
				Hint.Assume(v.UShort2  >= cmpVal);
				Hint.Assume(v.UShort3  >= cmpVal);
				Hint.Assume(v.UShort4  >= cmpVal);
				Hint.Assume(v.UShort5  >= cmpVal);
				Hint.Assume(v.UShort6  >= cmpVal);
				Hint.Assume(v.UShort7  >= cmpVal);
				Hint.Assume(v.UShort8  >= cmpVal);
				Hint.Assume(v.UShort9  >= cmpVal);
				Hint.Assume(v.UShort10 >= cmpVal);
				Hint.Assume(v.UShort11 >= cmpVal);
				Hint.Assume(v.UShort12 >= cmpVal);
				Hint.Assume(v.UShort13 >= cmpVal);
				Hint.Assume(v.UShort14 >= cmpVal);
				Hint.Assume(v.UShort15 >= cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_GE_EPU32(v256 v, uint cmpVal)
			{
				Hint.Assume(v.UInt0  >= cmpVal); 
				Hint.Assume(v.UInt1  >= cmpVal);
				Hint.Assume(v.UInt2  >= cmpVal);
				Hint.Assume(v.UInt3  >= cmpVal);
				Hint.Assume(v.UInt4  >= cmpVal);
				Hint.Assume(v.UInt5  >= cmpVal);
				Hint.Assume(v.UInt6  >= cmpVal);
				Hint.Assume(v.UInt7  >= cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_GE_EPU64(v256 v, ulong cmpVal)
			{
				Hint.Assume(v.ULong0  >= cmpVal); 
				Hint.Assume(v.ULong1  >= cmpVal);
				Hint.Assume(v.ULong2  >= cmpVal);
				Hint.Assume(v.ULong3  >= cmpVal);
			}


			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_GE_EPI8(v256 v, int cmpVal)
			{
				Hint.Assume(v.SByte0  >= cmpVal); 
				Hint.Assume(v.SByte1  >= cmpVal);
				Hint.Assume(v.SByte2  >= cmpVal);
				Hint.Assume(v.SByte3  >= cmpVal);
				Hint.Assume(v.SByte4  >= cmpVal);
				Hint.Assume(v.SByte5  >= cmpVal);
				Hint.Assume(v.SByte6  >= cmpVal);
				Hint.Assume(v.SByte7  >= cmpVal);
				Hint.Assume(v.SByte8  >= cmpVal);
				Hint.Assume(v.SByte9  >= cmpVal);
				Hint.Assume(v.SByte10 >= cmpVal);
				Hint.Assume(v.SByte11 >= cmpVal);
				Hint.Assume(v.SByte12 >= cmpVal);
				Hint.Assume(v.SByte13 >= cmpVal);
				Hint.Assume(v.SByte14 >= cmpVal);
				Hint.Assume(v.SByte15 >= cmpVal);
				Hint.Assume(v.SByte16 >= cmpVal); 
				Hint.Assume(v.SByte17 >= cmpVal);
				Hint.Assume(v.SByte18 >= cmpVal);
				Hint.Assume(v.SByte19 >= cmpVal);
				Hint.Assume(v.SByte20 >= cmpVal);
				Hint.Assume(v.SByte21 >= cmpVal);
				Hint.Assume(v.SByte22 >= cmpVal);
				Hint.Assume(v.SByte23 >= cmpVal);
				Hint.Assume(v.SByte24 >= cmpVal);
				Hint.Assume(v.SByte25 >= cmpVal);
				Hint.Assume(v.SByte26 >= cmpVal);
				Hint.Assume(v.SByte27 >= cmpVal);
				Hint.Assume(v.SByte28 >= cmpVal);
				Hint.Assume(v.SByte29 >= cmpVal);
				Hint.Assume(v.SByte30 >= cmpVal);
				Hint.Assume(v.SByte31 >= cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_GE_EPI16(v256 v, int cmpVal)
			{
				Hint.Assume(v.SShort0  >= cmpVal); 
				Hint.Assume(v.SShort1  >= cmpVal);
				Hint.Assume(v.SShort2  >= cmpVal);
				Hint.Assume(v.SShort3  >= cmpVal);
				Hint.Assume(v.SShort4  >= cmpVal);
				Hint.Assume(v.SShort5  >= cmpVal);
				Hint.Assume(v.SShort6  >= cmpVal);
				Hint.Assume(v.SShort7  >= cmpVal);
				Hint.Assume(v.SShort8  >= cmpVal);
				Hint.Assume(v.SShort9  >= cmpVal);
				Hint.Assume(v.SShort10 >= cmpVal);
				Hint.Assume(v.SShort11 >= cmpVal);
				Hint.Assume(v.SShort12 >= cmpVal);
				Hint.Assume(v.SShort13 >= cmpVal);
				Hint.Assume(v.SShort14 >= cmpVal);
				Hint.Assume(v.SShort15 >= cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_GE_EPI32(v256 v, int cmpVal)
			{
				Hint.Assume(v.SInt0  >= cmpVal); 
				Hint.Assume(v.SInt1  >= cmpVal);
				Hint.Assume(v.SInt2  >= cmpVal);
				Hint.Assume(v.SInt3  >= cmpVal);
				Hint.Assume(v.SInt4  >= cmpVal);
				Hint.Assume(v.SInt5  >= cmpVal);
				Hint.Assume(v.SInt6  >= cmpVal);
				Hint.Assume(v.SInt7  >= cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_GE_EPI64(v256 v, long cmpVal)
			{
				Hint.Assume(v.SLong0  >= cmpVal); 
				Hint.Assume(v.SLong1  >= cmpVal);
				Hint.Assume(v.SLong2  >= cmpVal);
				Hint.Assume(v.SLong3  >= cmpVal);
			}


			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_GE_PS(v256 v, float cmpVal)
			{
				Hint.Assume(v.Float0 >= cmpVal); 
				Hint.Assume(v.Float1 >= cmpVal);
				Hint.Assume(v.Float2 >= cmpVal);
				Hint.Assume(v.Float3 >= cmpVal);
				Hint.Assume(v.Float4 >= cmpVal);
				Hint.Assume(v.Float5 >= cmpVal);
				Hint.Assume(v.Float6 >= cmpVal);
				Hint.Assume(v.Float7 >= cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_GE_PD(v256 v, double cmpVal)
			{
				Hint.Assume(v.Double0 >= cmpVal); 
				Hint.Assume(v.Double1 >= cmpVal);
				Hint.Assume(v.Double2 >= cmpVal);
				Hint.Assume(v.Double3 >= cmpVal);
			}


			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_LE_EPU8(v128 v, int cmpVal)
			{
				Hint.Assume(v.Byte0  <= cmpVal); 
				Hint.Assume(v.Byte1  <= cmpVal);
				Hint.Assume(v.Byte2  <= cmpVal);
				Hint.Assume(v.Byte3  <= cmpVal);
				Hint.Assume(v.Byte4  <= cmpVal);
				Hint.Assume(v.Byte5  <= cmpVal);
				Hint.Assume(v.Byte6  <= cmpVal);
				Hint.Assume(v.Byte7  <= cmpVal);
				Hint.Assume(v.Byte8  <= cmpVal);
				Hint.Assume(v.Byte9  <= cmpVal);
				Hint.Assume(v.Byte10 <= cmpVal);
				Hint.Assume(v.Byte11 <= cmpVal);
				Hint.Assume(v.Byte12 <= cmpVal);
				Hint.Assume(v.Byte13 <= cmpVal);
				Hint.Assume(v.Byte14 <= cmpVal);
				Hint.Assume(v.Byte15 <= cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_LE_EPU16(v128 v, int cmpVal)
			{
				Hint.Assume(v.UShort0 <= cmpVal); 
				Hint.Assume(v.UShort1 <= cmpVal);
				Hint.Assume(v.UShort2 <= cmpVal);
				Hint.Assume(v.UShort3 <= cmpVal);
				Hint.Assume(v.UShort4 <= cmpVal);
				Hint.Assume(v.UShort5 <= cmpVal);
				Hint.Assume(v.UShort6 <= cmpVal);
				Hint.Assume(v.UShort7 <= cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_LE_EPU32(v128 v, uint cmpVal)
			{
				Hint.Assume(v.UInt0 <= cmpVal); 
				Hint.Assume(v.UInt1 <= cmpVal);
				Hint.Assume(v.UInt2 <= cmpVal);
				Hint.Assume(v.UInt3 <= cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_LE_EPU64(v128 v, ulong cmpVal)
			{
				Hint.Assume(v.ULong0 <= cmpVal); 
				Hint.Assume(v.ULong1 <= cmpVal);
			}


			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_LE_EPI8(v128 v, int cmpVal)
			{
				Hint.Assume(v.SByte0  <= cmpVal); 
				Hint.Assume(v.SByte1  <= cmpVal);
				Hint.Assume(v.SByte2  <= cmpVal);
				Hint.Assume(v.SByte3  <= cmpVal);
				Hint.Assume(v.SByte4  <= cmpVal);
				Hint.Assume(v.SByte5  <= cmpVal);
				Hint.Assume(v.SByte6  <= cmpVal);
				Hint.Assume(v.SByte7  <= cmpVal);
				Hint.Assume(v.SByte8  <= cmpVal);
				Hint.Assume(v.SByte9  <= cmpVal);
				Hint.Assume(v.SByte10 <= cmpVal);
				Hint.Assume(v.SByte11 <= cmpVal);
				Hint.Assume(v.SByte12 <= cmpVal);
				Hint.Assume(v.SByte13 <= cmpVal);
				Hint.Assume(v.SByte14 <= cmpVal);
				Hint.Assume(v.SByte15 <= cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_LE_EPI16(v128 v, int cmpVal)
			{
				Hint.Assume(v.SShort0 <= cmpVal); 
				Hint.Assume(v.SShort1 <= cmpVal);
				Hint.Assume(v.SShort2 <= cmpVal);
				Hint.Assume(v.SShort3 <= cmpVal);
				Hint.Assume(v.SShort4 <= cmpVal);
				Hint.Assume(v.SShort5 <= cmpVal);
				Hint.Assume(v.SShort6 <= cmpVal);
				Hint.Assume(v.SShort7 <= cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_LE_EPI32(v128 v, int cmpVal)
			{
				Hint.Assume(v.SInt0 <= cmpVal); 
				Hint.Assume(v.SInt1 <= cmpVal);
				Hint.Assume(v.SInt2 <= cmpVal);
				Hint.Assume(v.SInt3 <= cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_LE_EPI64(v128 v, long cmpVal)
			{
				Hint.Assume(v.SLong0 <= cmpVal); 
				Hint.Assume(v.SLong1 <= cmpVal);
			}
			

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_LE_PS(v128 v, float cmpVal)
			{
				Hint.Assume(v.Float0 <= cmpVal); 
				Hint.Assume(v.Float1 <= cmpVal);
				Hint.Assume(v.Float2 <= cmpVal);
				Hint.Assume(v.Float3 <= cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_LE_PD(v128 v, double cmpVal)
			{
				Hint.Assume(v.Double0 <= cmpVal); 
				Hint.Assume(v.Double1 <= cmpVal);
			}


			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_LE_EPU8(v256 v, int cmpVal)
			{
				Hint.Assume(v.Byte0  <= cmpVal); 
				Hint.Assume(v.Byte1  <= cmpVal);
				Hint.Assume(v.Byte2  <= cmpVal);
				Hint.Assume(v.Byte3  <= cmpVal);
				Hint.Assume(v.Byte4  <= cmpVal);
				Hint.Assume(v.Byte5  <= cmpVal);
				Hint.Assume(v.Byte6  <= cmpVal);
				Hint.Assume(v.Byte7  <= cmpVal);
				Hint.Assume(v.Byte8  <= cmpVal);
				Hint.Assume(v.Byte9  <= cmpVal);
				Hint.Assume(v.Byte10 <= cmpVal);
				Hint.Assume(v.Byte11 <= cmpVal);
				Hint.Assume(v.Byte12 <= cmpVal);
				Hint.Assume(v.Byte13 <= cmpVal);
				Hint.Assume(v.Byte14 <= cmpVal);
				Hint.Assume(v.Byte15 <= cmpVal);
				Hint.Assume(v.Byte16 <= cmpVal); 
				Hint.Assume(v.Byte17 <= cmpVal);
				Hint.Assume(v.Byte18 <= cmpVal);
				Hint.Assume(v.Byte19 <= cmpVal);
				Hint.Assume(v.Byte20 <= cmpVal);
				Hint.Assume(v.Byte21 <= cmpVal);
				Hint.Assume(v.Byte22 <= cmpVal);
				Hint.Assume(v.Byte23 <= cmpVal);
				Hint.Assume(v.Byte24 <= cmpVal);
				Hint.Assume(v.Byte25 <= cmpVal);
				Hint.Assume(v.Byte26 <= cmpVal);
				Hint.Assume(v.Byte27 <= cmpVal);
				Hint.Assume(v.Byte28 <= cmpVal);
				Hint.Assume(v.Byte29 <= cmpVal);
				Hint.Assume(v.Byte30 <= cmpVal);
				Hint.Assume(v.Byte31 <= cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_LE_EPU16(v256 v, int cmpVal)
			{
				Hint.Assume(v.UShort0  <= cmpVal); 
				Hint.Assume(v.UShort1  <= cmpVal);
				Hint.Assume(v.UShort2  <= cmpVal);
				Hint.Assume(v.UShort3  <= cmpVal);
				Hint.Assume(v.UShort4  <= cmpVal);
				Hint.Assume(v.UShort5  <= cmpVal);
				Hint.Assume(v.UShort6  <= cmpVal);
				Hint.Assume(v.UShort7  <= cmpVal);
				Hint.Assume(v.UShort8  <= cmpVal);
				Hint.Assume(v.UShort9  <= cmpVal);
				Hint.Assume(v.UShort10 <= cmpVal);
				Hint.Assume(v.UShort11 <= cmpVal);
				Hint.Assume(v.UShort12 <= cmpVal);
				Hint.Assume(v.UShort13 <= cmpVal);
				Hint.Assume(v.UShort14 <= cmpVal);
				Hint.Assume(v.UShort15 <= cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_LE_EPU32(v256 v, uint cmpVal)
			{
				Hint.Assume(v.UInt0  <= cmpVal); 
				Hint.Assume(v.UInt1  <= cmpVal);
				Hint.Assume(v.UInt2  <= cmpVal);
				Hint.Assume(v.UInt3  <= cmpVal);
				Hint.Assume(v.UInt4  <= cmpVal);
				Hint.Assume(v.UInt5  <= cmpVal);
				Hint.Assume(v.UInt6  <= cmpVal);
				Hint.Assume(v.UInt7  <= cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_LE_EPU64(v256 v, ulong cmpVal)
			{
				Hint.Assume(v.ULong0  <= cmpVal); 
				Hint.Assume(v.ULong1  <= cmpVal);
				Hint.Assume(v.ULong2  <= cmpVal);
				Hint.Assume(v.ULong3  <= cmpVal);
			}


			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_LE_EPI8(v256 v, int cmpVal)
			{
				Hint.Assume(v.SByte0  <= cmpVal); 
				Hint.Assume(v.SByte1  <= cmpVal);
				Hint.Assume(v.SByte2  <= cmpVal);
				Hint.Assume(v.SByte3  <= cmpVal);
				Hint.Assume(v.SByte4  <= cmpVal);
				Hint.Assume(v.SByte5  <= cmpVal);
				Hint.Assume(v.SByte6  <= cmpVal);
				Hint.Assume(v.SByte7  <= cmpVal);
				Hint.Assume(v.SByte8  <= cmpVal);
				Hint.Assume(v.SByte9  <= cmpVal);
				Hint.Assume(v.SByte10 <= cmpVal);
				Hint.Assume(v.SByte11 <= cmpVal);
				Hint.Assume(v.SByte12 <= cmpVal);
				Hint.Assume(v.SByte13 <= cmpVal);
				Hint.Assume(v.SByte14 <= cmpVal);
				Hint.Assume(v.SByte15 <= cmpVal);
				Hint.Assume(v.SByte16 <= cmpVal); 
				Hint.Assume(v.SByte17 <= cmpVal);
				Hint.Assume(v.SByte18 <= cmpVal);
				Hint.Assume(v.SByte19 <= cmpVal);
				Hint.Assume(v.SByte20 <= cmpVal);
				Hint.Assume(v.SByte21 <= cmpVal);
				Hint.Assume(v.SByte22 <= cmpVal);
				Hint.Assume(v.SByte23 <= cmpVal);
				Hint.Assume(v.SByte24 <= cmpVal);
				Hint.Assume(v.SByte25 <= cmpVal);
				Hint.Assume(v.SByte26 <= cmpVal);
				Hint.Assume(v.SByte27 <= cmpVal);
				Hint.Assume(v.SByte28 <= cmpVal);
				Hint.Assume(v.SByte29 <= cmpVal);
				Hint.Assume(v.SByte30 <= cmpVal);
				Hint.Assume(v.SByte31 <= cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_LE_EPI16(v256 v, int cmpVal)
			{
				Hint.Assume(v.SShort0  <= cmpVal); 
				Hint.Assume(v.SShort1  <= cmpVal);
				Hint.Assume(v.SShort2  <= cmpVal);
				Hint.Assume(v.SShort3  <= cmpVal);
				Hint.Assume(v.SShort4  <= cmpVal);
				Hint.Assume(v.SShort5  <= cmpVal);
				Hint.Assume(v.SShort6  <= cmpVal);
				Hint.Assume(v.SShort7  <= cmpVal);
				Hint.Assume(v.SShort8  <= cmpVal);
				Hint.Assume(v.SShort9  <= cmpVal);
				Hint.Assume(v.SShort10 <= cmpVal);
				Hint.Assume(v.SShort11 <= cmpVal);
				Hint.Assume(v.SShort12 <= cmpVal);
				Hint.Assume(v.SShort13 <= cmpVal);
				Hint.Assume(v.SShort14 <= cmpVal);
				Hint.Assume(v.SShort15 <= cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_LE_EPI32(v256 v, int cmpVal)
			{
				Hint.Assume(v.SInt0  <= cmpVal); 
				Hint.Assume(v.SInt1  <= cmpVal);
				Hint.Assume(v.SInt2  <= cmpVal);
				Hint.Assume(v.SInt3  <= cmpVal);
				Hint.Assume(v.SInt4  <= cmpVal);
				Hint.Assume(v.SInt5  <= cmpVal);
				Hint.Assume(v.SInt6  <= cmpVal);
				Hint.Assume(v.SInt7  <= cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_LE_EPI64(v256 v, long cmpVal)
			{
				Hint.Assume(v.SLong0  <= cmpVal); 
				Hint.Assume(v.SLong1  <= cmpVal);
				Hint.Assume(v.SLong2  <= cmpVal);
				Hint.Assume(v.SLong3  <= cmpVal);
			}


			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_LE_PS(v256 v, float cmpVal)
			{
				Hint.Assume(v.Float0 <= cmpVal); 
				Hint.Assume(v.Float1 <= cmpVal);
				Hint.Assume(v.Float2 <= cmpVal);
				Hint.Assume(v.Float3 <= cmpVal);
				Hint.Assume(v.Float4 <= cmpVal);
				Hint.Assume(v.Float5 <= cmpVal);
				Hint.Assume(v.Float6 <= cmpVal);
				Hint.Assume(v.Float7 <= cmpVal);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_LE_PD(v256 v, double cmpVal)
			{
				Hint.Assume(v.Double0 <= cmpVal); 
				Hint.Assume(v.Double1 <= cmpVal);
				Hint.Assume(v.Double2 <= cmpVal);
				Hint.Assume(v.Double3 <= cmpVal);
			}


			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_NAN_PS(v128 v)
			{
				Hint.Assume(math.isnan(v.Float0)); 
				Hint.Assume(math.isnan(v.Float1));
				Hint.Assume(math.isnan(v.Float2));
				Hint.Assume(math.isnan(v.Float3));
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_NAN_PD(v128 v)
			{
				Hint.Assume(math.isnan(v.Double0)); 
				Hint.Assume(math.isnan(v.Double1));
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_NAN_PS(v256 v)
			{
				Hint.Assume(math.isnan(v.Float0)); 
				Hint.Assume(math.isnan(v.Float1));
				Hint.Assume(math.isnan(v.Float2));
				Hint.Assume(math.isnan(v.Float3));
				Hint.Assume(math.isnan(v.Float4));
				Hint.Assume(math.isnan(v.Float5));
				Hint.Assume(math.isnan(v.Float6));
				Hint.Assume(math.isnan(v.Float7));
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_NAN_PD(v256 v)
			{
				Hint.Assume(math.isnan(v.Double0)); 
				Hint.Assume(math.isnan(v.Double1));
				Hint.Assume(math.isnan(v.Double2));
				Hint.Assume(math.isnan(v.Double3));
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_NOTNAN_PS(v128 v)
			{
				Hint.Assume(!math.isnan(v.Float0)); 
				Hint.Assume(!math.isnan(v.Float1));
				Hint.Assume(!math.isnan(v.Float2));
				Hint.Assume(!math.isnan(v.Float3));
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_NOTNAN_PD(v128 v)
			{
				Hint.Assume(!math.isnan(v.Double0)); 
				Hint.Assume(!math.isnan(v.Double1));
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_NOTNAN_PS(v256 v)
			{
				Hint.Assume(!math.isnan(v.Float0)); 
				Hint.Assume(!math.isnan(v.Float1));
				Hint.Assume(!math.isnan(v.Float2));
				Hint.Assume(!math.isnan(v.Float3));
				Hint.Assume(!math.isnan(v.Float4));
				Hint.Assume(!math.isnan(v.Float5));
				Hint.Assume(!math.isnan(v.Float6));
				Hint.Assume(!math.isnan(v.Float7));
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void ASSUME_NOTNAN_PD(v256 v)
			{
				Hint.Assume(!math.isnan(v.Double0)); 
				Hint.Assume(!math.isnan(v.Double1));
				Hint.Assume(!math.isnan(v.Double2));
				Hint.Assume(!math.isnan(v.Double3));
			}
		}
    }
}
