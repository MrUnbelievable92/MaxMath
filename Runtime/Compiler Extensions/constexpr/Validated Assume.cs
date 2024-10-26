//#define TESTING

using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;
using DevTools;

namespace MaxMath.Intrinsics
{
    public static partial class constexpr
    {
    	[MethodImpl(MethodImplOptions.AggressiveInlining)]
    	public static void ASSUME(bool value)
    	{
#if TESTING
Assert.IsTrue(value);
#endif
            Hint.Assume(value);
        }
    }
}
