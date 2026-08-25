using System.Runtime.CompilerServices;
using MaxMath.CompilerServices;
    
using static MaxMath.math;

namespace MaxMath
{
    unsafe public readonly partial struct UInt128
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ASSUME_DIVISION(UInt128 r, UInt128 a, UInt128 b)
        {
            if (constexpr.IS_TRUE(a.IsZero))
            {
                constexpr.ASSUME(r.IsZero);
            }
            if (constexpr.IS_TRUE(b == 1))
            {
                constexpr.ASSUME(r == a);
            }
            if (constexpr.IS_TRUE(a < b))
            {
                constexpr.ASSUME(r.IsZero);
            }
            if (constexpr.IS_TRUE(a == b))
            {
                constexpr.ASSUME(r == 1);
            }
            if (constexpr.IS_TRUE(a < b))
            {
                constexpr.ASSUME(r.IsZero);
            }
            if (constexpr.IS_TRUE(b.hi64 != 0))
            {
                constexpr.ASSUME(r.hi64 == 0);
            }
            if (constexpr.IS_TRUE(ispow2(b)))
            {
                constexpr.ASSUME(r == (a >> tzcnt(b)));
            }
            if (constexpr.IS_TRUE((b.hi64 & (1ul << 63)) == 0 && a >= b && a < b + b))
            {
                constexpr.ASSUME(r == 1);
            }
            constexpr.ASSUME(r <= a);
            constexpr.ASSUME(r * b <= a);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ASSUME_DIVISION(UInt128 r, UInt128 a, ulong b)
        {
            if (constexpr.IS_TRUE(a.IsZero))
            {
                constexpr.ASSUME(r.IsZero);
            }
            if (constexpr.IS_TRUE(b == 1))
            {
                constexpr.ASSUME(r == a);
            }
            if (constexpr.IS_TRUE(a < b))
            {
                constexpr.ASSUME(r.IsZero);
            }
            if (constexpr.IS_TRUE(a == b))
            {
                constexpr.ASSUME(r == 1);
            }
            if (constexpr.IS_TRUE(r.hi64 == 0))
            {
                constexpr.ASSUME(a.hi64 < b);
            }
            if (constexpr.IS_TRUE(a.hi64 == 0))
            {
                constexpr.ASSUME(r.hi64 == 0);
                constexpr.ASSUME(r.lo64 == a.lo64 / b);
                if (constexpr.IS_TRUE(a.lo64 < b))
                {
                    constexpr.ASSUME(r.IsZero);
                }
            }
            if (constexpr.IS_TRUE(ispow2(b)))
            {
                constexpr.ASSUME(r == (a >> tzcnt(b)));
            }
            constexpr.ASSUME(r <= a);
            constexpr.ASSUME(r * b <= a);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ASSUME_REMAINDER(UInt128 r, UInt128 a, UInt128 b)
        {
            if (constexpr.IS_TRUE(a.IsZero))
            {
                constexpr.ASSUME(r.IsZero);
            }
            if (constexpr.IS_TRUE(b == 1))
            {
                constexpr.ASSUME(r.IsZero);
            }
            if (constexpr.IS_TRUE(a == b))
            {
                constexpr.ASSUME(r.IsZero);
            }
            if (constexpr.IS_TRUE(a < b))
            {
                constexpr.ASSUME(r == a);
            }
            if (constexpr.IS_TRUE(ispow2(b)))
            {
                constexpr.ASSUME(r == (a & (b - 1)));
            }
            //constexpr.ASSUME(a == (a / b) * b + r);
            constexpr.ASSUME(r < b);
            constexpr.ASSUME(r <= a);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ASSUME_REMAINDER(ulong r, UInt128 a, ulong b)
        {
            if (constexpr.IS_TRUE(a.IsZero))
            {
                constexpr.ASSUME(r == 0);
            }
            if (constexpr.IS_TRUE(b == 1))
            {
                constexpr.ASSUME(r == 0);
            }
            if (constexpr.IS_TRUE(a == b))
            {
                constexpr.ASSUME(r == 0);
            }
            if (constexpr.IS_TRUE(a < b))
            {
                constexpr.ASSUME(r == a);
            }
            if (constexpr.IS_TRUE(a.hi64 == 0))
            {
                constexpr.ASSUME(r == a.lo64 % b);
            }
            if (constexpr.IS_TRUE(a.hi64 == 0 && a.lo64 < b))
            {
                constexpr.ASSUME(r == a);
            }
            if (constexpr.IS_TRUE(ispow2(b)))
            {
                constexpr.ASSUME(r == (a & (b - 1)));
            }
            //constexpr.constexpr.ASSUME(a == (a / b) * b + r);
            constexpr.ASSUME(r < b);
            constexpr.ASSUME(r <= a);
        }
    }
}
