using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;
using Unity.Mathematics;

namespace MaxMath
{
    unsafe internal static partial class Operator
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static UInt128 umul256(UInt128 left, UInt128 right, out UInt128 high, bool lo = true)
        {
            ulong lolo = Unity.Burst.Intrinsics.Common.umul128(left.lo, right.lo, out ulong lohi);
            ulong m1lo = Unity.Burst.Intrinsics.Common.umul128(left.hi, right.lo, out ulong m1hi);
            ulong m2lo = Unity.Burst.Intrinsics.Common.umul128(left.lo, right.hi, out ulong m2hi);
            ulong hilo = Unity.Burst.Intrinsics.Common.umul128(left.hi, right.hi, out ulong hihi);

            high = (new UInt128(hilo, hihi) + m1hi) + ((new UInt128(m2lo, m2hi) + m1lo) + lohi).hi;

            return lo ? left * right : 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static UInt128 divuint128(UInt128 dividend, UInt128 divisor, int shift)
        {
            UInt128 quotient = 0;
            
            if (Hint.Likely(shift >= 0)) 
            {
                divisor <<= shift;
            
                do
                {
                    quotient <<= 1;
            
                    if (Hint.Likely(dividend >= divisor)) 
                    {
                       dividend -= divisor;
                       quotient |= 1u;
                    }
            
                    divisor >>= 1;
                    shift--;
                } 
                while (Hint.Likely(shift >= 0));
            }
            
            return quotient;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static UInt128 divuint128(UInt128 dividend, UInt128 divisor)
        {
            return divuint128(dividend, divisor, maxmath.lzcnt(divisor) - maxmath.lzcnt(dividend));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static UInt128 divuint128(UInt128 dividend, ulong divisor)
        {
            return divuint128(dividend, divisor, (64 + math.lzcnt(divisor)) - maxmath.lzcnt(dividend));
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static UInt128 divuint128(UInt128 dividend, uint divisor)
        {
            return divuint128(dividend, divisor, (96 + math.lzcnt(divisor)) - maxmath.lzcnt(dividend));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static UInt128 remuint128(UInt128 dividend, UInt128 divisor, int shift)
        {
            if (Hint.Likely(shift >= 0)) 
            {
                divisor <<= shift;

                do
                {
                    if (Hint.Likely(dividend >= divisor)) 
                    {
                       dividend -= divisor;
                    }

                    divisor >>= 1;
                    shift--;
                } 
                while (Hint.Likely(shift >= 0));
            }

            return dividend;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static UInt128 remuint128(UInt128 dividend, UInt128 divisor)
        {
            return remuint128(dividend, divisor, maxmath.lzcnt(divisor) - maxmath.lzcnt(dividend));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static UInt128 remuint128(UInt128 dividend, ulong divisor)
        {
            return remuint128(dividend, divisor, (64 + math.lzcnt(divisor)) - maxmath.lzcnt(dividend));
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static UInt128 remuint128(UInt128 dividend, uint divisor)
        {
            return remuint128(dividend, divisor, (96 + math.lzcnt(divisor)) - maxmath.lzcnt(dividend));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static UInt128 divremuint128(UInt128 dividend, UInt128 divisor, int shift, out UInt128 remainder)
        {
            UInt128 quotient = 0;

            if (shift >= 0) 
            {
                divisor <<= shift;

                do
                {
                    quotient <<= 1;

                    if (dividend >= divisor) 
                    {
                       dividend -= divisor;
                       quotient |= 1u;
                    }

                    divisor >>= 1;

                    shift--;
                } 
                while (shift >= 0);
            }

            remainder = dividend;

            return quotient;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static UInt128 divremuint128(UInt128 dividend, UInt128 divisor, out UInt128 rem)
        {
            return divremuint128(dividend, divisor, maxmath.lzcnt(divisor) - maxmath.lzcnt(dividend), out rem);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static UInt128 divremuint128(UInt128 dividend, ulong divisor, out UInt128 rem)
        {
            return divremuint128(dividend, divisor, (64 + math.lzcnt(divisor)) - maxmath.lzcnt(dividend), out rem);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static UInt128 divremuint128(UInt128 dividend, uint divisor, out UInt128 rem)
        {
            return divremuint128(dividend, divisor, (96 + math.lzcnt(divisor)) - maxmath.lzcnt(dividend), out rem);
        }
    }
}