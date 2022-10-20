using System;
using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       An optional parameter for functions that selects optimized code paths. Must be <see langword="const"/> or it will add significant overhead instead.     </summary>
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
    }

    internal static class PromiseExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool Promises(this maxmath.Promise p, maxmath.Promise flags)
        {
#if DEBUG 
if (Constant.IsConstantExpression(1) && !(Constant.IsConstantExpression(p)))
{
    throw new ArgumentException("A maxmath.Promise used as an argument must be constant, since it adds significant overhead instead of chosing an optimized code path otherwise.");
}
#endif
            return (p & flags) == flags;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static byte CountUnsafeLevels(this maxmath.Promise p)
        {
#if DEBUG 
if (Constant.IsConstantExpression(1) && !(Constant.IsConstantExpression(p)))
{
    throw new ArgumentException("A maxmath.Promise used as an argument must be constant, since it adds significant overhead instead of chosing an optimized code path otherwise.");
}
#endif
            if (p.Promises(maxmath.Promise.Unsafe3)) return 4;
            if (p.Promises(maxmath.Promise.Unsafe2)) return 3;
            if (p.Promises(maxmath.Promise.Unsafe1)) return 2;
            if (p.Promises(maxmath.Promise.Unsafe0)) return 1;
                                                     return 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static maxmath.Promise GetDemotedUnsafeLevels(this maxmath.Promise p)
        {
#if DEBUG 
if (Constant.IsConstantExpression(1) && !(Constant.IsConstantExpression(p)))
{
    throw new ArgumentException("A maxmath.Promise used as an argument must be constant, since it adds significant overhead instead of chosing an optimized code path otherwise.");
}
#endif
            const maxmath.Promise USF_MASK = maxmath.Promise.Unsafe1 | maxmath.Promise.Unsafe2 | maxmath.Promise.Unsafe3;

            return (maxmath.Promise)(byte)((uint)((byte)p & (byte)USF_MASK) >> 1);
        }
    }
}
