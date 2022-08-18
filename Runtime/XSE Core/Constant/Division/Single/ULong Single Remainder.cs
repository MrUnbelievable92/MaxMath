using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

namespace MaxMath.Intrinsics
{
	unsafe public static partial class Xse
	{
		public static partial class constexpr
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal static v128 rem_epu64(v128 vector, ulong divisor)
			{
				return new v128((ulong)(vector.ULong0 % divisor), (ulong)(vector.ULong1 % divisor));
			}
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal static v256 mm256_rem_epu64(v256 vector, ulong divisor, byte elements = 4)
			{
				return new v256((ulong)(vector.ULong0 % divisor), (ulong)(vector.ULong1 % divisor), (ulong)(vector.ULong2 % divisor), (ulong)(vector.ULong3 % divisor));
			}
		}
	}
}
