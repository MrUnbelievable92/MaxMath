using System.Runtime.CompilerServices;
using MaxMath.CompilerServices;

using static MaxMath.math;

namespace MaxMath
{
    unsafe public readonly partial struct Int128
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool cmplt(Int128 left, Int128 right)
        {
            if (constexpr.IS_TRUE(right.IsZero))
            {
                return (long)left.hi64 < 0;
            }

            return ((long)left.hi64 < (long)right.hi64) | ((left.hi64 == right.hi64) & (left.lo64 < right.lo64));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool cmplt(Int128 left, long right)
        {
            if (constexpr.IS_TRUE(right == 0))
            {
                return (long)left.hi64 < 0;
            }
            else if ((left.hi64 == 0 && left.lo64 < (1ul << 63)) 
                  || (left.hi64 == ulong.MaxValue && left.lo64 >= (1ul << 63)))
            {
                return (long)left.lo64 < right;
            }

            return left < (Int128)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool cmplt(long left, Int128 right)
        {
            if ((right.hi64 == 0 && right.lo64 < (1ul << 63)) 
             || (right.hi64 == ulong.MaxValue && right.lo64 >= (1ul << 63)))
            {
                return (long)right.lo64 > left;
            }

            return (Int128)left < right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool cmplt(Int128 left, int right) => cmplt(left, (long)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool cmplt(int left, Int128 right) => cmplt((long)left, right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool cmplt(Int128 left, ulong right)
        {
            if (constexpr.IS_TRUE(left.hi64 == 0))
            {
                return left.lo64 < right;
            }

            return left < (Int128)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool cmplt(ulong left, Int128 right)
        {
            if (constexpr.IS_TRUE(right.hi64 == 0))
            {
                return right.lo64 > left;
            }

            return (Int128)left < right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool cmplt(Int128 left, uint right) => cmplt(left, (ulong)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool cmplt(uint left, Int128 right) => cmplt((ulong)left, right);
    }

    unsafe public readonly partial struct UInt128
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static UInt128 shl(UInt128 value, int n)
        {
            if (!constexpr.IS_TRUE(n <= 127 && n >= 0))
            {
                n &= 127;
            }

            if (constexpr.IS_TRUE(value.lo64 == 0))
            {
                return new UInt128(0, (n < 64) ? (value.hi64 << n) : 0);
            }
            else if (constexpr.IS_CONST(n))
            {
                return __const.shluint128(value, n);
            }
            else
            {
                int n2 = n;
                if (!constexpr.IS_TRUE(n <= 63 && n >= 0))
                {
                    n2 &= 63;
                }

                bool upper = n >= 64;

                ulong loShifted = value.lo64 << n2;

                ulong carry      = (value.lo64 >> 1) >> (63 - n2);
                ulong hiCombined = (value.hi64 << n2) | carry;

                ulong outLo = upper ? 0          : loShifted;
                ulong outHi = upper ? loShifted  : hiCombined;

                return new UInt128(outLo, outHi);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool cmplt(UInt128 left, UInt128 right)
        {
            if (constexpr.IS_TRUE(right.hi64 == 0))
            {
                return cmplt(left, right.lo64);
            }
            else if (constexpr.IS_TRUE(left.hi64 == 0))
            {
                return cmplt(left.lo64, right);
            }
            if (constexpr.IS_TRUE(right.IsNotZero & (right & (right - 1)).IsZero))
            {
                return (left & (UInt128)(-(Int128)right)).IsZero;
            }
            else
            {
                return (left.hi64 < right.hi64) | ((left.hi64 == right.hi64) & left.lo64 < right.lo64);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool cmpge(UInt128 left, UInt128 right)
        {
            if (constexpr.IS_TRUE(right.hi64 == 0))
            {
                return cmpge(left, right.lo64);
            }
            else if (constexpr.IS_TRUE(left.hi64 == 0))
            {
                return cmpge(left.lo64, right);
            }
            else if (constexpr.IS_TRUE(right.IsNotZero & (right & (right - 1)).IsZero))
            {
                return (left & (UInt128)(-(Int128)right)).IsNotZero;
            }
            else
            {
                return (right.hi64 < left.hi64) | ((right.hi64 == left.hi64) & right.lo64 <= left.lo64);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool cmpge(UInt128 left, ulong right)
        {
            if (constexpr.IS_TRUE(ispow2(right)))
            {
                return (left & (UInt128)(-(Int128)right)).IsNotZero;
            }
            else
            {
                return left.hi64 != 0 | left.lo64 >= right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool cmpge(ulong left, UInt128 right)
        {
            if (constexpr.IS_TRUE(right.IsNotZero & (right & (right - 1)).IsZero))
            {
                return (left & (-(Int128)right).lo64) != 0;
            }
            else
            {
                return right.hi64 == 0 & left >= right.lo64;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool cmplt(UInt128 left, ulong right)
        {
            if (constexpr.IS_TRUE(ispow2(right)))
            {
                return (left & new UInt128((-(Int128)right).lo64, ulong.MaxValue)).IsZero;
            }
            else
            {
                return left.hi64 == 0 & left.lo64 < right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool cmplt(ulong left, UInt128 right)
        {
            if (constexpr.IS_TRUE(right.IsNotZero & (right & (right - 1)).IsZero))
            {
                return (left & (-(Int128)right).lo64) == 0;
            }
            else
            {
                return right.hi64 != 0 | left < right.lo64;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool cmpeq(UInt128 left, UInt128 right)
        {
            if (constexpr.IS_CONST(right))
            {
                if (right.IsZero)
                {
                    return left.IsZero;
                }
                if (right.IsMaxValue)
                {
                    return left.IsMaxValue;
                }
            }
            else if (constexpr.IS_CONST(left))
            {
                if (left.IsZero)
                {
                    return right.IsZero;
                }
                if (left.IsMaxValue)
                {
                    return right.IsMaxValue;
                }
            }

            return ((left.lo64 ^ right.lo64) | (left.hi64 ^ right.hi64)) == 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool cmpeq(UInt128 left, ulong right)
        {
            if (constexpr.IS_TRUE(right == 0))
            {
                return left.IsZero;
            }

            return ((left.lo64 ^ right) | left.hi64) == 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool cmpeq(ulong left, UInt128 right)
        {
            return cmpeq(right, left);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool cmpneq(UInt128 left, UInt128 right)
        {
            if (constexpr.IS_CONST(right))
            {
                if (right.IsZero)
                {
                    return left.IsNotZero;
                }
                if (right.IsMaxValue)
                {
                    return left.IsNotMaxValue;
                }
            }
            else if (constexpr.IS_CONST(left))
            {
                if (left.IsZero)
                {
                    return right.IsNotZero;
                }
                if (left.IsMaxValue)
                {
                    return right.IsNotMaxValue;
                }
            }

            return ((left.lo64 ^ right.lo64) | (left.hi64 ^ right.hi64)) != 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool cmpneq(UInt128 left, ulong right)
        {
            if (constexpr.IS_TRUE(right == 0))
            {
                return left.IsNotZero;
            }

            return ((left.lo64 ^ right) | left.hi64) != 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool cmpneq(ulong left, UInt128 right)
        {
            return cmpneq(right, left);
        }
    }
}
