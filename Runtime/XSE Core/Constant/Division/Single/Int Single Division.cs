using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
	{
		public static partial class constexpr
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal static v128 div_epi32(v128 vector, int divisor)
			{
				return new v128((int)((long)vector.SInt0 / divisor), (int)((long)vector.SInt1 / divisor), (int)((long)vector.SInt2 / divisor), (int)((long)vector.SInt3 / divisor));
			}
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal static v256 mm256_div_epi32(v256 vector, int divisor)
			{
				return new v256((int)((long)vector.SInt0 / divisor), (int)((long)vector.SInt1 / divisor), (int)((long)vector.SInt2 / divisor), (int)((long)vector.SInt3 / divisor), (int)((long)vector.SInt4 / divisor), (int)((long)vector.SInt5 / divisor), (int)((long)vector.SInt6 / divisor), (int)((long)vector.SInt7 / divisor));
			}
		}
	}
}
