using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Burst.CompilerServices;
using Unity.Mathematics;
using MaxMath.Intrinsics;
using DevTools;

using static MaxMath.maxmath;

namespace MaxMath
{
    internal readonly struct __UInt256__ : IEquatable<__UInt256__>
    {
        private readonly ulong _63;
        private readonly ulong _127;
        private readonly ulong _191;
        private readonly ulong _255;

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


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __UInt256__ operator << (__UInt256__ value, int n)
        {
            n &= 255;

            if (Hint.Unlikely(n == 0))
            {
                return value;
            }
            else
            {
                if (n < 128)
                {
                    constexpr.ASSUME(n > 0 && n < 128);

                    return new __UInt256__(value.lo128 << n, (value.hi128 << n) | (value.lo128 >> (128 - n)));
                }
                else
                {
                    constexpr.ASSUME(n > 127 && n < 256);

                    return new __UInt256__(0, value.lo128 << (n - 128));
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __UInt256__ operator >> (__UInt256__ value, int n)
        {
            n &= 255;

            if (Hint.Unlikely(n == 0))
            {
                return value;
            }
            else
            {
                if (n < 128)
                {
                    constexpr.ASSUME(n > 0 && n < 128);

                    return new __UInt256__((value.lo128 >> n) | (value.hi128 << (128 - n)), value.hi128 >> n);
                }
                else
                {
                    constexpr.ASSUME(n > 127 && n < 256);

                    return new __UInt256__(value.hi128 >> (n - 128), 0);
                }
            }
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
        public static __UInt256__ operator / (__UInt256__ a, UInt128 b)
        {
            if (b > a)
            {
                return MinValue;
            }
	        else
            {
                return __udivrem256x128_rLEhi(a, b, out UInt128 _);
            }
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
                __udivrem256x128_rLEhi(a, b, out UInt128 result);

                return result;
            }
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

            return new __UInt256__(product.lo128, hi);
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
            if (constexpr.IS_TRUE(right.hi128 == 0))
            {
                return left < right.lo128;
            }
            else if (constexpr.IS_TRUE(left.hi128 == 0))
            {
                return right > left.lo128;
            }
            if (constexpr.IS_CONST(right) && constexpr.IS_TRUE(ispow2(right)))
            {
                return (left & (0u - right)).IsZero;
            }

            return (left.hi128 < right.hi128) | (left.hi128 == right.hi128 & (left.lo128 < right.lo128));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator < (__UInt256__ left, UInt128 right)
        {
            if (constexpr.IS_TRUE(left.hi128 == 0))
            {
                return right > left.lo128;
            }
            if (constexpr.IS_CONST(right) && constexpr.IS_TRUE(ispow2(right)))
            {
                return (left & ((__UInt256__)0u - right)).IsZero;
            }

            return left.hi128.IsZero & left.lo128 < right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator < (UInt128 left, __UInt256__ right)
        {
            if (constexpr.IS_CONST(right) && constexpr.IS_TRUE(ispow2(right)))
            {
                return (left & (0u - right).lo128) == 0;
            }

            return right.hi128.IsNotZero | left < right.lo128;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator < (__UInt256__ left, ulong right)
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
        public static bool operator < (ulong left, __UInt256__ right)
        {
            if (constexpr.IS_CONST(right) && constexpr.IS_TRUE(ispow2(right)))
            {
                return (left & (0u - right)._63) == 0;
            }

            return right.hi128.IsNotZero | left < right.lo128;
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
            if (constexpr.IS_TRUE(right.hi128 == 0))
            {
                return left >= right.lo128;
            }
            else if (constexpr.IS_TRUE(left.hi128 == 0))
            {
                return left.lo128 >= right;
            }
            
            return (right.hi128 < left.hi128) | (right.hi128 == left.hi128 & (right.lo128 < left.lo128));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (__UInt256__ left, UInt128 right)
        {
            if (constexpr.IS_CONST(right) && constexpr.IS_TRUE(ispow2(right)))
            {
                return (left & ((__UInt256__)0u - right)).IsNotZero;
            }

            return left.hi128.IsNotZero | left.lo128 >= right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (UInt128 left, __UInt256__ right)
        {
            if (constexpr.IS_CONST(right) && constexpr.IS_TRUE(ispow2(right)))
            {
                return (left & (0u - right).lo128) != 0;
            }

            return right.hi128.IsZero & left >= right.lo128;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (__UInt256__ left, ulong right)
        {
            if (constexpr.IS_CONST(right) && constexpr.IS_TRUE(ispow2(right)))
            {
                return (left & ((__UInt256__)0u - right)).IsNotZero;
            }

            return left.hi128.IsNotZero | left.lo128 >= right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (ulong left, __UInt256__ right)
        {
            if (constexpr.IS_CONST(right) && constexpr.IS_TRUE(ispow2(right)))
            {
                return (left & (0u - right)._63) != 0;
            }

            return right.hi128.IsZero & left >= right.lo128;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (__UInt256__ left, __UInt256__ right)
        {
            return ((left.lo128 ^ right.lo128) | (left.hi128 ^ right.hi128)).IsZero;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (__UInt256__ left, UInt128 right)
        {
            return ((left.lo128 ^ right) | left.hi128).IsZero;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (UInt128 left, __UInt256__ right)
        {
            return ((left ^ right.lo128) | right.hi128).IsZero;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (__UInt256__ left, __UInt256__ right)
        {
            return ((left.lo128 ^ right.lo128) | (left.hi128 ^ right.hi128)).IsNotZero;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (__UInt256__ left, UInt128 right)
        {
            return ((left.lo128 ^ right) | left.hi128).IsNotZero;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (UInt128 left, __UInt256__ right)
        {
            return ((left ^ right.lo128) | right.hi128).IsNotZero;
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
            if (x.hi128.IsZero)
            {
                return 128 + maxmath.lzcnt(x.lo128);
            }
            else
            {
                return maxmath.lzcnt(x.hi128);
            }
        }

        [return: AssumeRange(0L, 256L)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int tzcnt(__UInt256__ x)
        {
            if (x.lo128.IsZero)
            {
                return 128 + maxmath.tzcnt(x.hi128);
            }
            else
            {
                return maxmath.tzcnt(x.lo128);
            }
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
            return math.countbits(x._63) + math.countbits(x._127) + math.countbits(x._191) + math.countbits(x._255);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __UInt256__ bits_resetlowest(__UInt256__ x)
        {
            return x & (x - 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ispow2(__UInt256__ x)
        {
            if (Architecture.IsPopcntSupported)
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

            return new __UInt256__(maxmath.square(x), high);
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
        private static __UInt256__ __udivrem256x128_rLEhi(__UInt256__ dividend, UInt128 divisor, out UInt128 remainder)
        {
            // TODO asm version

            UInt128 quotientHi = asm128.__udivrem128x128(dividend.hi128, divisor, out UInt128 dividendHi);
            dividend = new __UInt256__(dividend.lo128, dividendHi);

            return new __UInt256__(__usf__udivrem256x128(dividend, divisor, out remainder), quotientHi);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static UInt128 __usf__udivrem256x128(__UInt256__ dividend, UInt128 divisor, out UInt128 remainder, bool preShift = false, bool alignedDivisorHiLessThanAlignedDividendHi128Hi64 = false)
        {
Assert.IsSmaller(dividend.hi128, divisor);
            
            // TODO asm version
            
            int shift = maxmath.lzcnt(divisor);
            if (!preShift)
            {
                dividend <<= shift;
                divisor <<= shift;
            }

            UInt128 qHi = alignedDivisorHiLessThanAlignedDividendHi128Hi64 ? asm128.__usf__udivrem128x64(dividend.hi128, divisor.hi64, out ulong remdiv)
                                                                           : asm128.__udivrem128x64(dividend.hi128, divisor.hi64, out remdiv);
            UInt128 remdiv128 = new UInt128(dividend.lo128.hi64, remdiv);
            remainder = remdiv128 - (qHi * divisor.lo64);
            bool b1 = remainder > remdiv128;
            bool b2 = b1 & ((UInt128)(-(Int128)remainder) > divisor);
            qHi -= tobyte(b2);
            qHi -= tobyte(b1);
            remainder += b1 ? divisor : 0;
            remainder += b2 ? divisor : 0;

            UInt128 qLo = asm128.__udivrem128x64(remainder, divisor.hi64, out remdiv);
            remdiv128 = new UInt128(dividend.lo128.lo64, remdiv);;
            remainder = remdiv128 - (qLo * divisor.lo64);
            b1 = remainder > remdiv128;
            b2 = b1 & ((UInt128)(-(Int128)remainder) > divisor);
            qLo -= tobyte(b2);
            qLo -= tobyte(b1);
            remainder += b1 ? divisor : 0;
            remainder += b2 ? divisor : 0;

            remainder >>= shift;
            return new UInt128(qLo.lo64, qHi.lo64);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static UInt128 __usf__udiv256x128(__UInt256__ dividend, UInt128 divisor, bool preShift = false)
        {
            return __usf__udivrem256x128(dividend, divisor, out _, preShift);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static UInt128 __usf__urem256x128(__UInt256__ dividend, UInt128 divisor)
        {
            __usf__udivrem256x128(dividend, divisor, out UInt128 rem);

            return rem;
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
