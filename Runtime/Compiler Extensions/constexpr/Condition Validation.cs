using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;

namespace MaxMath.Intrinsics
{
    public static partial class constexpr
    {
    	[MethodImpl(MethodImplOptions.AggressiveInlining)]
    	public static bool IS_CONST<T>(T value)
            where T : unmanaged
    	{
    		return Constant.IsConstantExpression(value);
    	}

    	[MethodImpl(MethodImplOptions.AggressiveInlining)]
    	public static bool IS_TRUE(bool condition)
    	{
    		return IS_CONST(condition) && condition;
    	}

    	[MethodImpl(MethodImplOptions.AggressiveInlining)]
    	public static bool IS_FALSE(bool condition)
    	{
    		return IS_CONST(condition) && !condition;
    	}
    }
}
