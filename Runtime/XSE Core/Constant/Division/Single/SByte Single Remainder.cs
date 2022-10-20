using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
	{
		public static partial class constexpr
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal static v128 rem_epi8(v128 vector, sbyte divisor, byte elements = 16)
			{
				return new v128((sbyte)(vector.SByte0 % divisor), (sbyte)(vector.SByte1 % divisor), (sbyte)(vector.SByte2 % divisor), (sbyte)(vector.SByte3 % divisor), (sbyte)(vector.SByte4 % divisor), (sbyte)(vector.SByte5 % divisor), (sbyte)(vector.SByte6 % divisor), (sbyte)(vector.SByte7 % divisor), (sbyte)(vector.SByte8 % divisor), (sbyte)(vector.SByte9 % divisor), (sbyte)(vector.SByte10 % divisor), (sbyte)(vector.SByte11 % divisor), (sbyte)(vector.SByte12 % divisor), (sbyte)(vector.SByte13 % divisor), (sbyte)(vector.SByte14 % divisor), (sbyte)(vector.SByte15 % divisor));
			}
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal static v256 mm256_rem_epi8(v256 vector, sbyte divisor)
			{
				return new v256((sbyte)(vector.SByte0 % divisor), (sbyte)(vector.SByte1 % divisor), (sbyte)(vector.SByte2 % divisor), (sbyte)(vector.SByte3 % divisor), (sbyte)(vector.SByte4 % divisor), (sbyte)(vector.SByte5 % divisor), (sbyte)(vector.SByte6 % divisor), (sbyte)(vector.SByte7 % divisor), (sbyte)(vector.SByte8 % divisor), (sbyte)(vector.SByte9 % divisor), (sbyte)(vector.SByte10 % divisor), (sbyte)(vector.SByte11 % divisor), (sbyte)(vector.SByte12 % divisor), (sbyte)(vector.SByte13 % divisor), (sbyte)(vector.SByte14 % divisor), (sbyte)(vector.SByte15 % divisor), (sbyte)(vector.SByte16 % divisor), (sbyte)(vector.SByte17 % divisor), (sbyte)(vector.SByte18 % divisor), (sbyte)(vector.SByte19 % divisor), (sbyte)(vector.SByte20 % divisor), (sbyte)(vector.SByte21 % divisor), (sbyte)(vector.SByte22 % divisor), (sbyte)(vector.SByte23 % divisor), (sbyte)(vector.SByte24 % divisor), (sbyte)(vector.SByte25 % divisor), (sbyte)(vector.SByte26 % divisor), (sbyte)(vector.SByte27 % divisor), (sbyte)(vector.SByte28 % divisor), (sbyte)(vector.SByte29 % divisor), (sbyte)(vector.SByte30 % divisor), (sbyte)(vector.SByte31 % divisor));
			}
		}
	}
}
