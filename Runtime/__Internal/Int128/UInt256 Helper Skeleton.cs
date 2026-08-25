using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;
using MaxMath.CompilerServices;
using DevTools;

using static MaxMath.math;

namespace MaxMath
{
    internal readonly struct __UInt256__ : IEquatable<__UInt256__>
    {
        internal readonly ulong _63;
        internal readonly ulong _127;
        internal readonly ulong _191;
        internal readonly ulong _255;

        public UInt128 lo128 => new UInt128(_63, _127);
        public UInt128 hi128 => new UInt128(_191, _255);

        public static __UInt256__ MinValue => new __UInt256__(0, 0);
        public static __UInt256__ MaxValue => new __UInt256__(UInt128.MaxValue, UInt128.MaxValue);

        internal bool IsZero => ((_63 | _127) | (_191 | _255)) == 0;
        internal bool IsNotZero => ((_63 | _127) | (_191 | _255)) != 0;
        internal bool IsMaxValue => ((_63 & _127) & (_191 & _255)) == ulong.MaxValue;
        internal bool IsNotMaxValue => ((_63 & _127) & (_191 & _255)) != ulong.MaxValue;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal __UInt256__(ulong lo, ulong m1, ulong m2, ulong hi)
        {
            _63 = lo;
            _127 = m1;
            _191 = m2;
            _255 = hi;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal __UInt256__(UInt128 lo, UInt128 hi)
            :this(lo.lo64, lo.hi64, hi.lo64, hi.hi64) { }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint(__UInt256__ input)
        {
            return (uint)input._63;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator __UInt256__(uint input)
        {
            return new __UInt256__(input, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong(__UInt256__ input)
        {
            return input._63;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator __UInt256__(ulong input)
        {
            return new __UInt256__(input, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator UInt128(__UInt256__ input)
        {
            return new UInt128(input._63, input._127);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator __UInt256__(UInt128 input)
        {
            return new __UInt256__(input, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator BigInteger(__UInt256__ input)
        {
            return (BigInteger)input.lo128 | ((BigInteger)input.hi128 << 128);
        }

        public static explicit operator __UInt256__(BigInteger value)
        {
            bool isNegative = value.Sign == -1;

            if (isNegative)
            {
                value = -value;
            }

            __UInt256__ result = new __UInt256__((UInt128)(value & UInt128.MaxValue), (UInt128)((value >> 128) & UInt128.MaxValue));

            if (isNegative)
            {
                result = 0 - result;
            }

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __UInt256__ operator ~ (__UInt256__ value)
        {
            return new __UInt256__(~value.lo128, ~value.hi128);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static __UInt256__ shl(__UInt256__ value, int n)
        {
            int n2 = n & 127;
            bool upper = n >= 128;

            UInt128 loShifted = value.lo128 << n2;

            UInt128 carry      = (value.lo128 >> 1) >> (127 - n2);
            UInt128 hiCombined = (value.hi128 << n2) | carry;

            UInt128 outLo = upper ? 0          : loShifted;
            UInt128 outHi = upper ? loShifted  : hiCombined;

            return new __UInt256__(outLo, outHi);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __UInt256__ operator << (__UInt256__ value, int n)
        {
            __UInt256__ result;

            n &= 255;
            
            if (constexpr.IS_TRUE(n == 0))
            {
                return value;
            }
            else
            {
                result = shl(value, n);
            }

            //constexpr.ASSUME(result == umul256(value, shl(1, n)));
            if (constexpr.IS_TRUE(value.IsZero))
            {
                constexpr.ASSUME(result.IsZero);
            }
            constexpr.ASSUME((result & (shl(1, n) - 1)).IsZero);
            constexpr.ASSUME(tzcnt(result) >= tzcnt(value));
            constexpr.ASSUME(tzcnt(result) == min(256, tzcnt(value) + n));
            constexpr.ASSUME(countbits(result) <= countbits(value));
            if (constexpr.IS_TRUE(ispow2(value)))
            {
                constexpr.ASSUME(ispow2(result) || result.IsZero);
            }

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __UInt256__ operator >> (__UInt256__ value, int n)
        {
            __UInt256__ result;

            n &= 255;

            if (constexpr.IS_TRUE(n == 0))
            {
                result = value;
            }
            else
            {
                int n2 = n & 127;
                bool upper = n >= 128;

                UInt128 hiShifted = value.hi128 >> n2;

                UInt128 carry      = (value.hi128 << 1) << (127 - n2);
                UInt128 loCombined = (value.lo128 >> n2) | carry;

                UInt128 outHi = upper ? 0           : hiShifted;
                UInt128 outLo = upper ? hiShifted   : loCombined;

                result = new __UInt256__(outLo, outHi);
            }

            //constexpr.ASSUME(result == value / ((__UInt256__)1 << n)));
            if (constexpr.IS_TRUE(value.IsZero))
            {
                constexpr.ASSUME(result.IsZero);
            }
            if (constexpr.IS_TRUE(n != 0))
            {
                constexpr.ASSUME((result & ~(((__UInt256__)1 << (256 - n)) - 1)).IsZero);
            }
            constexpr.ASSUME(lzcnt(result) >= lzcnt(value));
            constexpr.ASSUME(countbits(result) <= countbits(value));
            if (constexpr.IS_TRUE(ispow2(value)))
            {
                constexpr.ASSUME(ispow2(result) || result.IsZero);
            }
            constexpr.ASSUME((result << n) <= value);
            constexpr.ASSUME(value == (result << n) + (value & (((__UInt256__)1 << n) - 1)));

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __UInt256__ operator ++ (__UInt256__ value) => value + 1u;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __UInt256__ operator -- (__UInt256__ value) => value - 1u;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __UInt256__ operator + (__UInt256__ left, __UInt256__ right)
        {
            ulong _63 = left._63 + right._63;
            ulong _127 = left._127 + (right._127 + tobyte(_63 < left._63));
            ulong _191 = left._191 + (right._191 + tobyte(_127 < left._127));
            ulong _255 = left._255 + (right._255 + tobyte(_191 < left._191));

            return new __UInt256__(_63, _127, _191, _255);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __UInt256__ operator + (__UInt256__ left, UInt128 right)
        {
            ulong _63 = left._63 + right.lo64;
            ulong _127 = left._127 + (right.hi64 + tobyte(_63 < left._63));
            ulong _191 = left._191 + tobyte(_127 < left._127);
            ulong _255 = left._255 + tobyte(_191 < left._191);

            return new __UInt256__(_63, _127, _191, _255);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __UInt256__ operator - (__UInt256__ left, __UInt256__ right)
        {
            ulong _63 = left._63 - right._63;
            ulong _127 = left._127 - (right._127 + tobyte(_63 > left._63));
            ulong _191 = left._191 - (right._191 + tobyte(_127 > left._127));
            ulong _255 = left._255 - (right._255 + tobyte(_191 > left._191));

            return new __UInt256__(_63, _127, _191, _255);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __UInt256__ operator - (__UInt256__ left, UInt128 right)
        {
            return left - (__UInt256__)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __UInt256__ operator / (__UInt256__ left, UInt128 right)
        {
            __UInt256__ result = asm128.fallback__udiv256x128(left, right);
            
            if (constexpr.IS_TRUE(left.IsZero))
            {
                constexpr.ASSUME(result.IsZero);
            }
            if (constexpr.IS_TRUE(right == 1))
            {
                constexpr.ASSUME(result == left);
            }
            if (constexpr.IS_TRUE(left < right))
            {
                constexpr.ASSUME(result.IsZero);
            }
            if (constexpr.IS_TRUE(left == right))
            {
                constexpr.ASSUME(result == 1);
            }
            if (constexpr.IS_TRUE(result.hi128 == 0))
            {
                constexpr.ASSUME(left.hi128 < right);
            }
            if (constexpr.IS_TRUE(left.hi128 < right))
            {
                constexpr.ASSUME(result.hi128 == 0);
            }
            if (constexpr.IS_TRUE(left.hi128 == 0))
            {
                constexpr.ASSUME(result.hi128 == 0);
                constexpr.ASSUME(result.lo128 == left.lo128 / right);
                if (constexpr.IS_TRUE(left.lo128 < right))
                {
                    constexpr.ASSUME(result.IsZero);
                }
            }
            if (constexpr.IS_TRUE(ispow2(right)))
            {
                constexpr.ASSUME(result == (left >> tzcnt(right)));
            }
            constexpr.ASSUME(result <= left);
            //constexpr.ASSUME(result * right <= left);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __UInt256__ operator / (__UInt256__ left, __UInt256__ right)
        {
            __UInt256__ result = asm128.__udivrem256x256(left, right, out _);
            
            if (constexpr.IS_TRUE(left.IsZero))
            {
                constexpr.ASSUME(result.IsZero);
            }
            if (constexpr.IS_TRUE(right == 1))
            {
                constexpr.ASSUME(result == left);
            }
            if (constexpr.IS_TRUE(left < right))
            {
                constexpr.ASSUME(result.IsZero);
            }
            if (constexpr.IS_TRUE(left == right))
            {
                constexpr.ASSUME(result == 1);
            }
            if (constexpr.IS_TRUE(left < right))
            {
                constexpr.ASSUME(result.IsZero);
            }
            if (constexpr.IS_TRUE(right.hi128 != 0))
            {
                constexpr.ASSUME(result.hi128 == 0);
            }
            if (constexpr.IS_TRUE(ispow2(right)))
            {
                constexpr.ASSUME(result == (left >> tzcnt(right)));
            }
            if (constexpr.IS_TRUE((right.hi128 & ((UInt128)1ul << 127)) == 0 && left >= right && left < right + right))
            {
                constexpr.ASSUME(result == 1);
            }
            constexpr.ASSUME(result <= left);
            //constexpr.ASSUME(result * right <= left);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __UInt256__ operator % (__UInt256__ a, UInt128 b)
        {
            if (b > a)
            {
                return a;
            }
	        else
            {
                asm128.__udivrem256x128_rLEhi(a, b, out UInt128 result);

                return result;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __UInt256__ operator % (__UInt256__ a, __UInt256__ b)
        {
            asm128.__udivrem256x256(a, b, out __UInt256__ result);
            return result;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __UInt256__ operator * (__UInt256__ left, __UInt256__ right)
        {
            return umul(left, right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __UInt256__ operator * (__UInt256__ left, UInt128 right)
        {
            if (constexpr.IS_CONST(right))
            {
                if (right.IsZero)
                {
                    return MinValue;
                }
                else if (right == 1)
                {
                    return left;
                }
                else
                {
                    if (right == 2)
                    {
                        return left + left;
                    }
                    else if (right == 3)
                    {
                        return left + left + left;
                    }
                    else if (ispow2(right))
                    {
                        return left << tzcnt(right);
                    }
                }
            }
            if (constexpr.IS_CONST(left))
            {
                if (left.IsZero)
                {
                    return MinValue;
                }
                else if (left == 1)
                {
                    return right;
                }
                else
                {
                    if (left == 2)
                    {
                        return (__UInt256__)right + (__UInt256__)right;
                    }
                    else if (left == 3)
                    {
                        return (__UInt256__)right + (__UInt256__)right + (__UInt256__)right;
                    }
                    else if (ispow2(left))
                    {
                        return (__UInt256__)right << tzcnt(left);
                    }
                }
            }

            if (constexpr.IS_TRUE(left == right))
            {
                return square(left);
            }


            __UInt256__ product = umul256(left.lo128, right);
            UInt128 hi = product.hi128;

            if (constexpr.IS_CONST(left.hi128))
            {
                if (left.hi128 == 0)
                {
                    ;
                }
                else if (left.hi128 == UInt128.MaxValue)
                {
                    hi -= right;
                }
                else
                {
                    hi += left.hi128 * right;
                }
            }
            else
            {
                hi += left.hi128 * right;
            }

            __UInt256__ result = new __UInt256__(product.lo128, hi);
            
            if (constexpr.IS_TRUE(left.IsZero || right.IsZero))
            {
                constexpr.ASSUME(result.IsZero);
            }
            if (constexpr.IS_TRUE(left == 1))
            {
                //constexpr.ASSUME(result == right);
            }
            if (constexpr.IS_TRUE(right == 1))
            {
                //constexpr.ASSUME(result == left);
            }
            
            constexpr.ASSUME((result.lo128 & 1ul) == ((left.lo128 & right.lo64) & 1ul));
            constexpr.ASSUME(((result.lo128 & 1ul) == 0) ==  (((left.lo128 & 1ul) == 0) || ((right.lo64 & 1ul) == 0)));
            
            if (constexpr.IS_TRUE(ispow2(left)))
            {
                //constexpr.ASSUME(result == right << tzcnt(left));
            }
            if (constexpr.IS_TRUE(ispow2(right)))
            {
                //constexpr.ASSUME(result == left << tzcnt(right));
            }

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __UInt256__ operator * (UInt128 left, __UInt256__ right) => right * left;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __UInt256__ operator | (__UInt256__ a, uint b) => a | (ulong)b;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __UInt256__ operator | (__UInt256__ a, ulong b)
        {
            return new __UInt256__(a._63 | b, a._127, a._191, a._255);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __UInt256__ operator | (__UInt256__ a, UInt128 b)
        {
            return new __UInt256__(a.lo128 | b, a.hi128);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __UInt256__ operator | (__UInt256__ a, __UInt256__ b)
        {
            return new __UInt256__(a.lo128 | b.lo128, a.hi128 | b.hi128);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __UInt256__ operator & (__UInt256__ a, uint b) => a & (ulong)b;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __UInt256__ operator & (__UInt256__ a, ulong b)
        {
            return new __UInt256__(a._63 & b, 0, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __UInt256__ operator & (__UInt256__ a, UInt128 b)
        {
            return new __UInt256__(a.lo128 & b, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __UInt256__ operator & (__UInt256__ a, __UInt256__ b)
        {
            return new __UInt256__(a.lo128 & b.lo128, a.hi128 & b.hi128);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __UInt256__ operator ^ (__UInt256__ a, uint b) => a ^ (ulong)b;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __UInt256__ operator ^ (__UInt256__ a, ulong b)
        {
            return new __UInt256__(a._63 ^ b, a._127, a._191, a._255);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __UInt256__ operator ^ (__UInt256__ a, UInt128 b)
        {
            return new __UInt256__(a.lo128 ^ b, a.hi128);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __UInt256__ operator ^ (__UInt256__ a, __UInt256__ b)
        {
            return new __UInt256__(a.lo128 ^ b.lo128, a.hi128 ^ b.hi128);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator < (__UInt256__ left, __UInt256__ right)
        {
            bool result = cmplt(left, right);
            
            constexpr.ASSUME(!result || !cmpeq(left, right));
            constexpr.ASSUME(!result || cmpneq(left, right));
            constexpr.ASSUME(result == !cmpge(left, right));
            constexpr.ASSUME(result == (cmpge(right, left) && cmpneq(left, right)));

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator < (__UInt256__ left, UInt128 right)
        {
            bool result = cmplt(left, right);
            
            constexpr.ASSUME(!result || !cmpeq(left, right));
            constexpr.ASSUME(!result || cmpneq(left, right));
            constexpr.ASSUME(result == !cmpge(left, right));
            constexpr.ASSUME(result == (cmpge(right, left) && cmpneq(left, right)));

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator < (UInt128 left, __UInt256__ right)
        {
            bool result = cmplt(left, right);
            
            constexpr.ASSUME(!result || !cmpeq(left, right));
            constexpr.ASSUME(!result || cmpneq(left, right));
            constexpr.ASSUME(result == !cmpge(left, right));
            constexpr.ASSUME(result == (cmpge(right, left) && cmpneq(left, right)));

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator < (__UInt256__ left, ulong right)
        {
            bool result = cmplt(left, right);
            
            constexpr.ASSUME(!result || !cmpeq(left, right));
            constexpr.ASSUME(!result || cmpneq(left, right));
            constexpr.ASSUME(result == !cmpge(left, right));
            constexpr.ASSUME(result == (cmpge(right, left) && cmpneq(left, right)));

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator < (ulong left, __UInt256__ right)
        {
            bool result = cmplt(left, right);
            
            constexpr.ASSUME(!result || !cmpeq(left, right));
            constexpr.ASSUME(!result || cmpneq(left, right));
            constexpr.ASSUME(result == !cmpge(left, right));
            constexpr.ASSUME(result == (cmpge(right, left) && cmpneq(left, right)));

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator > (__UInt256__ left, __UInt256__ right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator > (__UInt256__ left, UInt128 right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator > (UInt128 left, __UInt256__ right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator > (__UInt256__ left, ulong right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator > (ulong left, __UInt256__ right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (__UInt256__ left, __UInt256__ right)
        {
            bool result = cmpge(left, right);

            constexpr.ASSUME(result == (cmplt(right, left) || cmpeq(left, right)));
            constexpr.ASSUME(result == !cmplt(left, right));

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (__UInt256__ left, UInt128 right)
        {
            bool result = cmpge(left, right);

            constexpr.ASSUME(result == (cmplt(right, left) || cmpeq(left, right)));
            constexpr.ASSUME(result == !cmplt(left, right));

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (UInt128 left, __UInt256__ right)
        {
            bool result = cmpge(left, right);

            constexpr.ASSUME(result == (cmplt(right, left) || cmpeq(left, right)));
            constexpr.ASSUME(result == !cmplt(left, right));

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (__UInt256__ left, ulong right)
        {
            bool result = cmpge(left, right);

            constexpr.ASSUME(result == (cmplt(right, left) || cmpeq(left, right)));
            constexpr.ASSUME(result == !cmplt(left, right));

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (ulong left, __UInt256__ right)
        {
            bool result = cmpge(left, right);

            constexpr.ASSUME(result == (cmplt(right, left) || cmpeq(left, right)));
            constexpr.ASSUME(result == !cmplt(left, right));

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (__UInt256__ left, __UInt256__ right)
        {
            bool result = cmpeq(left, right);
            
            constexpr.ASSUME(result == !cmpneq(left, right));
            constexpr.ASSUME(result == (!cmplt(left, right) && !cmplt(right, left)));
            constexpr.ASSUME(result == (cmpge(left, right) && cmpge(right, left)));

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (__UInt256__ left, UInt128 right)
        {
            bool result = cmpeq(left, right);
            
            constexpr.ASSUME(result == !cmpneq(left, right));
            constexpr.ASSUME(result == (!cmplt(left, right) && !cmplt(right, left)));
            constexpr.ASSUME(result == (cmpge(left, right) && cmpge(right, left)));

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (UInt128 left, __UInt256__ right)
        {
            bool result = cmpeq(left, right);
            
            constexpr.ASSUME(result == !cmpneq(left, right));
            constexpr.ASSUME(result == (!cmplt(left, right) && !cmplt(right, left)));
            constexpr.ASSUME(result == (cmpge(left, right) && cmpge(right, left)));

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (__UInt256__ left, __UInt256__ right)
        {
            bool result = cmpneq(left, right);

            constexpr.ASSUME(result == !cmpeq(left, right));
            constexpr.ASSUME(result == (cmplt(left, right) || cmplt(right, left)));
            constexpr.ASSUME(result == (!cmpge(left, right) || !cmpge(right, left)));

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (__UInt256__ left, UInt128 right)
        {
            bool result = cmpneq(left, right);

            constexpr.ASSUME(result == !cmpeq(left, right));
            constexpr.ASSUME(result == (cmplt(left, right) || cmplt(right, left)));
            constexpr.ASSUME(result == (!cmpge(left, right) || !cmpge(right, left)));

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (UInt128 left, __UInt256__ right)
        {
            bool result = cmpneq(left, right);

            constexpr.ASSUME(result == !cmpeq(left, right));
            constexpr.ASSUME(result == (cmplt(left, right) || cmplt(right, left)));
            constexpr.ASSUME(result == (!cmpge(left, right) || !cmpge(right, left)));

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <= (__UInt256__ left, __UInt256__ right) => right >= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <= (__UInt256__ left, UInt128 right) => right >= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <= (UInt128 left, __UInt256__ right) => right >= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <= (__UInt256__ left, ulong right) => right >= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <= (ulong left, __UInt256__ right) => right >= left;


        [return: AssumeRange(0L, 256L)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int lzcnt (__UInt256__ x)
        {
            int lzcntLo = math.lzcnt(x.lo128);
            int lzcntHi = math.lzcnt(x.hi128);
            bool hi0 = x.hi128 == 0;
            int add = hi0 ? 128 : 0;

            return add + (hi0 ? lzcntLo : lzcntHi);
        }

        [return: AssumeRange(0L, 256L)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int tzcnt(__UInt256__ x)
        {
            int tzcntLo = math.tzcnt(x.lo128);
            int tzcntHi = math.tzcnt(x.hi128);
            bool lo0 = x.lo128 == 0;
            int add = lo0 ? 128 : 0;

            return add + (lo0 ? tzcntHi : tzcntLo);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __UInt256__ bits_masktolowest(__UInt256__ x)
        {
            return x ^ (x - 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __UInt256__ bitmask256(ulong numBits, ulong index = 0)
        {
Assert.IsBetween(index, 0u, 255u);
Assert.IsBetween(numBits, 0u, 256ul - index);

            if (constexpr.IS_TRUE(numBits != 0))
            {
                return bits_masktolowest((__UInt256__)1 << ((int)numBits - 1)) << (int)index;
            }
            else
            {
                return ((((__UInt256__)1 << (int)numBits) - 1) << (int)index) | ((__UInt256__)0 - tobyte(numBits == 256));
            }
        }

        [return: AssumeRange(0L, 256L)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int countbits(__UInt256__ x)
        {
            return math.countbits(x.lo128) + math.countbits(x.hi128);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __UInt256__ bits_resetlowest(__UInt256__ x)
        {
            return x & (x - 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __UInt256__ bits_extractparallel(__UInt256__ x, __UInt256__ mask)
        {
            UInt128 lo = math.bits_extractparallel(x.lo128, mask.lo128);
            UInt128 hi = math.bits_extractparallel(x.hi128, mask.hi128);
            int maskloCount = math.countbits(mask.lo128);
            
            return lo | ((__UInt256__)hi << maskloCount);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ispow2(__UInt256__ x)
        {
            if (BurstArchitecture.IsPopcntSupported)
            {
                return countbits(x) == 1;
            }
            else
            {
                return x.IsNotZero & (bits_resetlowest(x) == 0);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static __UInt256__ square(__UInt256__ x)
        {
            __UInt256__ product = umul256(x.lo128, x.lo128);

            return new __UInt256__(product.lo128, product.hi128 + ((x.lo128 * x.hi128) << 1));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 intsqrt(__UInt256__ x)
        {
            //double xAsDub = (double)x;
            //if (xAsDub < 8.5e37)
            //{
            //    UInt128 vInt = (UInt128)sqrt(xAsDub);
            //    UInt128 v = (vInt + (x.lo128 / vInt)) >> 1;
            //    return v - tobyte(square(v) > x);
            //}
            //else
            //{
            //    __UInt256__ v = (__UInt256__)sqrt(xAsDub);
            //    v = (v + (x / v)) >> 1;
            //    if (xAsDub > 2e63)
            //    {
            //        v = (v + (x / v)) >> 1;
            //    }
            //    return (UInt128)(v - tobyte(square(v) > x));
            //}

            __UInt256__ result = 0;
            __UInt256__ mask = (__UInt256__)1 << 254;

            int lzcntX = lzcnt(x);
            mask >>= lzcntX & (-1 << 1);
            if (Hint.Likely(mask > x))
            {
                mask >>= 2;
            }

            if (x >= mask)
            {
                x -= mask;
                result = mask;
            }

            mask >>= 2;

            while (mask != 0)
            {
                __UInt256__ resultAdded = result | mask;
                result >>= 1;

                if (x >= resultAdded)
                {
                    x -= resultAdded;
                    result |= mask;
                }

                mask >>= 2;
            }

            return result.lo128;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static __UInt256__ umul(__UInt256__ left, __UInt256__ right)
        {
            if (constexpr.IS_TRUE(left == right))
            {
                return square(left);
            }

            __UInt256__ product = __UInt256__.umul256(left.lo128, right.lo128);
            UInt128 hi = product.hi128;

            if (constexpr.IS_CONST(left.hi128))
            {
                if (constexpr.IS_CONST(right.hi128))
                {
                    if (left.hi128 == 0)
                    {
                        if (right.hi128 == 0)
                        {
                            ;
                        }
                        else if (right.hi128 == ulong.MaxValue)
                        {
                            hi -= left.lo128;
                        }
                        else
                        {
                            hi += left.lo128 * right.hi128;
                        } 
                    }
                    else if (left.hi128 == ulong.MaxValue)
                    {
                        if (right.hi128 == 0)
                        {
                            hi -= right.lo128;
                        }
                        else if (right.hi128 == ulong.MaxValue)
                        {
                            hi -= right.lo128 + left.lo128;
                        }
                        else
                        {
                            hi = (hi - right.lo128) + (left.lo128 * right.hi128);
                        } 
                    }
                    else
                    {
                        if (right.hi128 == 0)
                        {
                            hi += left.hi128 * right.lo128;
                        }
                        else if (right.hi128 == ulong.MaxValue)
                        {
                            hi =  (hi - left.lo128) + (left.hi128 * right.lo128);
                        }
                        else
                        {
                            hi += (left.hi128 * right.lo128) + (left.lo128 * right.hi128);
                        } 
                    }
                }
                else
                {
                    if (left.hi128 == 0)
                    {
                        hi += left.lo128 * right.hi128;
                    }
                    else if (left.hi128 == ulong.MaxValue)
                    {
                        hi =  (hi - right.lo128) + (left.lo128 * right.hi128);
                    }
                    else
                    {
                        hi += (left.hi128 * right.lo128) + (left.lo128 * right.hi128);
                    } 
                }
            }
            else
            {
                hi += (left.hi128 * right.lo128) + (left.lo128 * right.hi128);
            }

            return new __UInt256__(product.lo128, hi);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static __UInt256__ umul256(UInt128 x, UInt128 y)
        {
            if (constexpr.IS_TRUE(x == y))
            {
                return usqr256(x);
            }

            UInt128 lo = UInt128.umul128(x.lo64, y.lo64);
            UInt128 m1 = UInt128.umul128(x.hi64, y.lo64);
            UInt128 m2 = UInt128.umul128(x.lo64, y.hi64);
            UInt128 hi = UInt128.umul128(x.hi64, y.hi64);

            UInt128 high = (hi + m1.hi64) + ((m2 + m1.lo64) + lo.hi64).hi64;

            return new __UInt256__(x * y, high);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static __UInt256__ usqr256(UInt128 x)
        {
            UInt128 lo = UInt128.umul128(x.lo64, x.lo64);
            UInt128 m  = UInt128.umul128(x.hi64, x.lo64);
            UInt128 hi = UInt128.umul128(x.hi64, x.hi64);

            UInt128 high = (hi + m.hi64) + ((m + m.lo64) + lo.hi64).hi64;

            return new __UInt256__(math.square(x), high);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static __UInt256__ imul256(Int128 x, Int128 y)
        {
            if (constexpr.IS_TRUE(x == y))
            {
                return isqr256(x);
            }

            __UInt256__ lo = umul256(x.value, y.value);
            UInt128 hi = lo.hi128;

            if (constexpr.IS_TRUE(x >= 0 && y >= 0)
            || (long)(x.hi64 | y.hi64) >= 0)
            {
                ;
            }
            else
            {
                ulong xMask = (ulong)((long)y.hi64 >> 63);
                ulong yMask = (ulong)((long)x.hi64 >> 63);
                x = new Int128(x.lo64 & xMask, x.hi64 & xMask);
                y = new Int128(y.lo64 & yMask, y.hi64 & yMask);
                hi -= (UInt128)(x + y);
            }

            return new __UInt256__(lo.lo128, hi);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static __UInt256__ isqr256(Int128 x)
        {
            __UInt256__ lo = usqr256(x.value);
            UInt128 hi = lo.hi128;

            if (constexpr.IS_TRUE(x >= 0)
             || (long)x.hi64 >= 0)
            {
                ;
            }
            else
            {
                ulong mask = (ulong)((long)x.hi64 >> 63);
                x = new Int128(x.lo64 & mask, x.hi64 & mask);
                hi -= (UInt128)(x + x);
            }

            return new __UInt256__(lo.lo128, hi);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void umul512(__UInt256__ x, __UInt256__ y, out __UInt256__ lo, out __UInt256__ hi)
        {
            if (constexpr.IS_TRUE(x == y))
            {
                usqr512(x, out lo, out hi);

                return;
            }

                        lo = umul256(x.lo128, y.lo128);
            __UInt256__ m1 = umul256(x.hi128, y.lo128);
            __UInt256__ m2 = umul256(x.lo128, y.hi128);
                        hi = umul256(x.hi128, y.hi128);

            hi = (hi + m1.hi128) + ((m2 + m1.lo128) + lo.hi128).hi128;

            lo = x * y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void usqr512(__UInt256__ x, out __UInt256__ lo, out __UInt256__ hi)
        {
                        lo = umul256(x.lo128, x.lo128);
            __UInt256__ m  = umul256(x.hi128, x.lo128);
                        hi = umul256(x.hi128, x.hi128);

            hi = (hi + m.hi128) + ((m + m.lo128) + lo.hi128).hi128;
            lo = square(x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool cmpeq(__UInt256__ left, __UInt256__ right)
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

            return ((left.lo128 ^ right.lo128) | (left.hi128 ^ right.hi128)).IsZero;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool cmpeq(__UInt256__ left, UInt128 right)
        {
            if (constexpr.IS_TRUE(left.IsZero))
            {
                return right.IsZero;
            }
            if (constexpr.IS_TRUE(right.IsZero))
            {
                return left.IsZero;
            }

            return ((left.lo128 ^ right) | left.hi128).IsZero;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool cmpeq(UInt128 left, __UInt256__ right)
        {
            if (constexpr.IS_TRUE(left.IsZero))
            {
                return right.IsZero;
            }
            if (constexpr.IS_TRUE(right.IsZero))
            {
                return left.IsZero;
            }

            return ((left ^ right.lo128) | right.hi128).IsZero;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool cmpneq(__UInt256__ left, __UInt256__ right)
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

            return ((left.lo128 ^ right.lo128) | (left.hi128 ^ right.hi128)).IsNotZero;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool cmpneq(__UInt256__ left, UInt128 right)
        {
            if (constexpr.IS_TRUE(left.IsZero))
            {
                return right.IsNotZero;
            }
            if (constexpr.IS_TRUE(right.IsZero))
            {
                return left.IsNotZero;
            }

            return ((left.lo128 ^ right) | left.hi128).IsNotZero;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool cmpneq(UInt128 left, __UInt256__ right)
        {
            if (constexpr.IS_TRUE(left.IsZero))
            {
                return right.IsNotZero;
            }
            if (constexpr.IS_TRUE(right.IsZero))
            {
                return left.IsNotZero;
            }

            return ((left ^ right.lo128) | right.hi128).IsNotZero;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool cmplt(__UInt256__ left, __UInt256__ right)
        {
            if (constexpr.IS_TRUE(right.hi128 == 0))
            {
                return cmplt(left, right.lo128);
            }
            else if (constexpr.IS_TRUE(left.hi128 == 0))
            {
                return cmplt(left.lo128, right);
            }
            if (constexpr.IS_CONST(right) && constexpr.IS_TRUE(right.IsNotZero & (right & (right - 1)).IsZero))
            {
                return (left & (0u - right)).IsZero;
            }

            return (left.hi128 < right.hi128) | (left.hi128 == right.hi128 & (left.lo128 < right.lo128));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool cmplt(__UInt256__ left, UInt128 right)
        {
            if (constexpr.IS_TRUE(left.hi128 == 0))
            {
                return left.lo128 < right;
            }
            if (constexpr.IS_CONST(right) && constexpr.IS_TRUE(ispow2(right)))
            {
                return (left & ((__UInt256__)0u - right)).IsZero;
            }

            return left.hi128.IsZero & left.lo128 < right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool cmplt(UInt128 left, __UInt256__ right)
        {
            if (constexpr.IS_CONST(right) && constexpr.IS_TRUE(right.IsNotZero & (right & (right - 1)).IsZero))
            {
                return (left & (0u - right).lo128) == 0;
            }

            return right.hi128.IsNotZero | left < right.lo128;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool cmplt(__UInt256__ left, ulong right)
        {
            if (constexpr.IS_TRUE(left.hi128 == 0 & left._191 == 0))
            {
                return right > left._63;
            }
            if (constexpr.IS_CONST(right) && constexpr.IS_TRUE(ispow2(right)))
            {
                return (left & ((__UInt256__)0u - right)).IsZero;
            }

            return left.hi128.IsZero & left.lo128 < right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool cmplt(ulong left, __UInt256__ right)
        {
            if (constexpr.IS_CONST(right) && constexpr.IS_TRUE(right.IsNotZero & (right & (right - 1)).IsZero))
            {
                return (left & (0u - right)._63) == 0;
            }

            return right.hi128.IsNotZero | left < right.lo128;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool cmpge(__UInt256__ left, __UInt256__ right)
        {
            if (constexpr.IS_TRUE(right.hi128 == 0))
            {
                return cmpge(left, right.lo128);
            }
            else if (constexpr.IS_TRUE(left.hi128 == 0))
            {
                return left.lo128 >= right;
            }
            else
            {
                return (right.hi128 < left.hi128) | (right.hi128 == left.hi128 & (right.lo128 <= left.lo128));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool cmpge(__UInt256__ left, UInt128 right)
        {
            if (constexpr.IS_CONST(right) && constexpr.IS_TRUE(right.IsNotZero & (right & (right - 1)).IsZero))
            {
                return (left & ((__UInt256__)0u - right)).IsNotZero;
            }
            else
            {
                return left.hi128.IsNotZero | left.lo128 >= right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool cmpge(UInt128 left, __UInt256__ right)
        {
            if (constexpr.IS_CONST(right) && constexpr.IS_TRUE(right.IsNotZero & (right & (right - 1)).IsZero))
            {
                return (left & (0u - right).lo128) != 0;
            }
            else
            {
                return right.hi128.IsZero & left >= right.lo128;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool cmpge(__UInt256__ left, ulong right)
        {
            if (constexpr.IS_CONST(right) && constexpr.IS_TRUE(ispow2(right)))
            {
                return (left & ((__UInt256__)0u - right)).IsNotZero;
            }
            else
            {
                return left.hi128.IsNotZero | left.lo128 >= right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool cmpge(ulong left, __UInt256__ right)
        {
            if (constexpr.IS_CONST(right) && constexpr.IS_TRUE(right.IsNotZero & (right & (right - 1)).IsZero))
            {
                return (left & (0u - right)._63) != 0;
            }
            else
            {
                return right.hi128.IsZero & left >= right.lo128;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __UInt256__ Next__UInt256__(__UInt256__ random, __UInt256__ min, __UInt256__ max)
        {
Assert.IsFalse(max < min);

            umul512(random, max - min, out _, out __UInt256__ producthi);

            return min + producthi;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(__UInt256__ other)
        {
            return this == other;
        }

        public override bool Equals(object obj)
        {
            return obj is __UInt256__ converted && this.Equals(converted);
        }


        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
