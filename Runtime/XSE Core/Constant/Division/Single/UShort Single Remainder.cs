using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

namespace MaxMath.Intrinsics
{
	unsafe public static partial class Xse
	{
		public static partial class constexpr
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal static v128 rem_epu16(v128 vector, ushort divisor, byte elements = 8)
			{
				return new v128((ushort)(vector.UShort0 % divisor), (ushort)(vector.UShort1 % divisor), (ushort)(vector.UShort2 % divisor), (ushort)(vector.UShort3 % divisor), (ushort)(vector.UShort4 % divisor), (ushort)(vector.UShort5 % divisor), (ushort)(vector.UShort6 % divisor), (ushort)(vector.UShort7 % divisor));
			}
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal static v256 mm256_rem_epu16(v256 vector, ushort divisor)
			{
				return new v256((ushort)(vector.UShort0 % divisor), (ushort)(vector.UShort1 % divisor), (ushort)(vector.UShort2 % divisor), (ushort)(vector.UShort3 % divisor), (ushort)(vector.UShort4 % divisor), (ushort)(vector.UShort5 % divisor), (ushort)(vector.UShort6 % divisor), (ushort)(vector.UShort7 % divisor), (ushort)(vector.UShort8 % divisor), (ushort)(vector.UShort9 % divisor), (ushort)(vector.UShort10 % divisor), (ushort)(vector.UShort11 % divisor), (ushort)(vector.UShort12 % divisor), (ushort)(vector.UShort13 % divisor), (ushort)(vector.UShort14 % divisor), (ushort)(vector.UShort15 % divisor));
			}
		}
	}
}
