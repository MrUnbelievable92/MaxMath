//#define TESTING

using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Burst.CompilerServices;

namespace MaxMath.CompilerServices
{
    public static partial class constexpr
    {
    	[MethodImpl(MethodImplOptions.AggressiveInlining)]
    	public static void ASSUME(bool value)
    	{
            // needs LLVM 21, because otherwise it is often a pessimization
            // (it still can be, ongoing LLVM dev effort)
            // Burst 1.8.30 updated to LLVM 21, and said Burst version requires Unity 6
            #if !UNITY_6000_0_OR_NEWER
            {
                return;
            }
            #endif

            if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.FastCompilation
             || COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Balanced)
            {
                return;
            }

            if (IS_TRUE(value))
            {
                return;
            }

#if TESTING
DevTools.Assert.IsTrue(value);
#endif
            Hint.Assume(value);
        }
    }
}
