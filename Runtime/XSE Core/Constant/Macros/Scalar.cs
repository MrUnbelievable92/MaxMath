using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;

namespace MaxMath.Intrinsics
{
	unsafe public static partial class Xse
	{
		public static partial class constexpr
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool IS_TRUE(bool condition)
			{
				return Constant.IsConstantExpression(condition) && condition;
			}
		}
    }
}
