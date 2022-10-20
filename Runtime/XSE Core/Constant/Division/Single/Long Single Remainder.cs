using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
	{
		public static partial class constexpr
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private static long save_rem(long x, long y)
            {
                if (y == -1 && x == long.MinValue)
                {
					return long.MinValue;
                }
				else
                {
					return x % y;
                }
            }


			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal static v128 rem_epi64(v128 vector, long divisor)
			{
				return new v128(save_rem(vector.SLong0, divisor), save_rem(vector.SLong1, divisor));
			}
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal static v256 mm256_rem_epi64(v256 vector, long divisor, byte elements = 4)
			{
				return new v256(save_rem(vector.SLong0, divisor), save_rem(vector.SLong1, divisor), save_rem(vector.SLong2, divisor), save_rem(vector.SLong3, divisor));
			}
		}
	}
}
