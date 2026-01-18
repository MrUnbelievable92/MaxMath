//#define TESTING

using System;
using System.Runtime.CompilerServices;
using MaxMath.Intrinsics;

namespace MaxMath
{
    /// <summary>       An optional parameter which selects optimized code paths. Must be <see langword="const"/> at compile time.     </summary>
    [Flags]
    public enum Promise : byte
    {
        Nothing = 0,
        Everything = byte.MaxValue,

        NonZero       = 1 << 0,
        ZeroOrGreater = 1 << 1,
        ZeroOrLess    = 1 << 2,
        NoOverflow    = 1 << 3,

        Unsafe0 = 1 << 4,
        Unsafe1 = 1 << 5,
        Unsafe2 = 1 << 6,
        Unsafe3 = 1 << 7,

        Positive = NonZero | ZeroOrGreater,
        Negative = NonZero | ZeroOrLess,
    }

    internal static class PromiseExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ThrowIfBurstCompiled()
        {
        #if DEBUG && !TESTING
            if (BurstArchitecture.IsBurstCompiled)
            {
                throw new ArgumentException("A Promise used as an argument must be constant, since it adds significant overhead instead of choosing an optimized code path otherwise.");
            }
        #endif
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool Promises(this Promise p, Promise flags)
        {
            if (constexpr.IS_CONST(p))
            {
                return (p & flags) == flags;
            }
            else
            {
                ThrowIfBurstCompiled();
                return false;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static byte CountUnsafeLevels(this Promise p)
        {
            if (p.Promises(Promise.Unsafe3)) return 4;
            if (p.Promises(Promise.Unsafe2)) return 3;
            if (p.Promises(Promise.Unsafe1)) return 2;
            if (p.Promises(Promise.Unsafe0)) return 1;
                                             return 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void DemoteUnsafeLevels(ref this Promise p)
        {
            if (constexpr.IS_CONST(p))
            {
                const Promise USF_MASK = Promise.Unsafe1 | Promise.Unsafe2 | Promise.Unsafe3;

                p = (Promise)(byte)((uint)((byte)p & (byte)USF_MASK) >> 1);
            }
            else
            {
                ThrowIfBurstCompiled();
            }
        }
    }
}
