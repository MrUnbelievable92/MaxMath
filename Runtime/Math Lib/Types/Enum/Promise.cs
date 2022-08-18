using System;
using System.Runtime.CompilerServices;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
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
            return (p & flags) == flags;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static byte CountUnsafeLevels(this maxmath.Promise p)
        {
            if (p.Promises(maxmath.Promise.Unsafe3)) return 4;
            if (p.Promises(maxmath.Promise.Unsafe2)) return 3;
            if (p.Promises(maxmath.Promise.Unsafe1)) return 2;
            if (p.Promises(maxmath.Promise.Unsafe0)) return 1;

            else return 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static maxmath.Promise GetDemotedUnsafeLevels(this maxmath.Promise p)
        {
            const maxmath.Promise USF_MASK = maxmath.Promise.Unsafe1 | maxmath.Promise.Unsafe2 | maxmath.Promise.Unsafe3;

            p &= USF_MASK;
            p = (maxmath.Promise)((byte)p >> 1);

            return p;
        }
    }
}
