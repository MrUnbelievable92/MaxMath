using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
	{
		public static partial class constexpr
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal static v128 div_epi16(v128 vector, short divisor, byte elements = 8)
			{
				return new v128((short)(vector.SShort0 / divisor), (short)(vector.SShort1 / divisor), (short)(vector.SShort2 / divisor), (short)(vector.SShort3 / divisor), (short)(vector.SShort4 / divisor), (short)(vector.SShort5 / divisor), (short)(vector.SShort6 / divisor), (short)(vector.SShort7 / divisor));
			}
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal static v256 mm256_div_epi16(v256 vector, short divisor)
			{
				return new v256((short)(vector.SShort0 / divisor), (short)(vector.SShort1 / divisor), (short)(vector.SShort2 / divisor), (short)(vector.SShort3 / divisor), (short)(vector.SShort4 / divisor), (short)(vector.SShort5 / divisor), (short)(vector.SShort6 / divisor), (short)(vector.SShort7 / divisor), (short)(vector.SShort8 / divisor), (short)(vector.SShort9 / divisor), (short)(vector.SShort10 / divisor), (short)(vector.SShort11 / divisor), (short)(vector.SShort12 / divisor), (short)(vector.SShort13 / divisor), (short)(vector.SShort14 / divisor), (short)(vector.SShort15 / divisor));
			}
		}
	}
}
