using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
	{
		public static partial class constexpr
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal static v128 rem_epu32(v128 vector, uint divisor)
			{
				return new v128((uint)(vector.UInt0 % divisor), (uint)(vector.UInt1 % divisor), (uint)(vector.UInt2 % divisor), (uint)(vector.UInt3 % divisor));
			}
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal static v256 mm256_rem_epu32(v256 vector, uint divisor)
			{
				return new v256((uint)(vector.UInt0 % divisor), (uint)(vector.UInt1 % divisor), (uint)(vector.UInt2 % divisor), (uint)(vector.UInt3 % divisor), (uint)(vector.UInt4 % divisor), (uint)(vector.UInt5 % divisor), (uint)(vector.UInt6 % divisor), (uint)(vector.UInt7 % divisor));
			}
		}
	}
}
