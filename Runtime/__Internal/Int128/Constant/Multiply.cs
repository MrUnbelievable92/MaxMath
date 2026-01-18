using MaxMath.Intrinsics;
using System.Runtime.CompilerServices;
using DevTools;

using static MaxMath.maxmath;

namespace MaxMath
{
    unsafe public readonly partial struct UInt128
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static UInt128 umul(UInt128 left, UInt128 right)
        {
            if (constexpr.IS_TRUE(left == right))
            {
                return square(left);
            }

            UInt128 product = UInt128.umul128(left.lo64, right.lo64);
            ulong hi = product.hi64;

            if (constexpr.IS_CONST(left.hi64))
            {
                if (constexpr.IS_CONST(right.hi64))
                {
                    if (left.hi64 == 0)
                    {
                        switch (right.hi64)
                        {
                            case 0:                 break;
                            case ulong.MaxValue:    hi -= left.lo64; break;
                            default:                hi += left.lo64 * right.hi64; break;
                        }
                    }
                    else if (left.hi64 == ulong.MaxValue)
                    {
                        switch (right.hi64)
                        {
                            case 0:                 hi -= right.lo64; break;
                            case ulong.MaxValue:    hi -= right.lo64 + left.lo64; break;
                            default:                hi =  (hi - right.lo64) + (left.lo64 * right.hi64); break;
                        }
                    }
                    else
                    {
                        switch (right.hi64)
                        {
                            case 0:                 hi += left.hi64 * right.lo64; break;
                            case ulong.MaxValue:    hi =  (hi - left.lo64) + (left.hi64 * right.lo64); break;
                            default:                hi += (left.hi64 * right.lo64) + (left.lo64 * right.hi64); break;
                        }
                    }
                }
                else
                {
                    switch (left.hi64)
                    {
                        case 0:                 hi += left.lo64 * right.hi64; break;
                        case ulong.MaxValue:    hi =  (hi - right.lo64) + (left.lo64 * right.hi64); break;
                        default:                hi += (left.hi64 * right.lo64) + (left.lo64 * right.hi64); break;
                    }
                }
            }
            else
            {
                hi += (left.hi64 * right.lo64) + (left.lo64 * right.hi64);
            }

            return new UInt128(product.lo64, hi);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static UInt128 umul(UInt128 left, ulong right)
        {
            UInt128 product = UInt128.umul128(left.lo64, right);
            ulong hi = product.hi64;

            if (constexpr.IS_CONST(left.hi64))
            {
                switch (left.hi64)
                {
                    case 0:                 break;
                    case ulong.MaxValue:    hi -= right; break;
                    default:                hi += left.hi64 * right; break;
                }
            }
            else
            {
                hi += left.hi64 * right;
            }

            return new UInt128(product.lo64, hi);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static UInt128 umul(UInt128 left, uint right)
        {
            if (BurstArchitecture.IsBurstCompiled)
            {
                return left * (ulong)right;
            }
            else
            {
                ulong lo = left.lo64 * right;
                ulong mid = (uint)(left.lo64 >> 32) * (ulong)right;
                uint carry = (uint)(lo >> 32) - (uint)mid;
                ulong hi = left.hi64 * right + (uint)((mid + carry) >> 32);

                return new UInt128(lo, hi);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Int128 imul(Int128 left, Int128 right)
        {
            if (constexpr.IS_TRUE(left == right))
            {
                return square(left);
            }
            if (constexpr.IS_TRUE(isinrange(left, long.MinValue, long.MaxValue)))
            {
                if (constexpr.IS_TRUE(isinrange(right, long.MinValue, long.MaxValue)))
                {
                    return imul128((long)left.lo64, (long)right.lo64);
                }

                return imul(right, (long)left);
            }
            if (constexpr.IS_TRUE(isinrange(right, long.MinValue, long.MaxValue)))
            {
                return imul(left, (long)right);
            }

            return (Int128)umul((UInt128)left, (UInt128)right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Int128 imul(Int128 left, long right)
        {
            if (constexpr.IS_TRUE(right >= 0))
            {
                return (Int128)umul((UInt128)left, (ulong)right);
            }
            if (constexpr.IS_TRUE(isinrange(left, long.MinValue, long.MaxValue)))
            {
                return imul128((long)left.lo64, right);
            }

            UInt128 result = UInt128.umul128(left.lo64, (ulong)right);
            ulong hi = result.hi64 + (ulong)-(long)(left.lo64 & (ulong)(right >> 63));
            hi += left.hi64 * (ulong)right;

            return new Int128(result.lo64, hi);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Int128 imul(Int128 left, ulong right)
        {
            if (constexpr.IS_TRUE(left.hi64 == 0))
            {
                return (Int128)UInt128.umul128(left.lo64, right);
            }
            if (constexpr.IS_TRUE(isinrange(left, long.MinValue, long.MaxValue)))
            {
                return imul128((long)left.lo64, (long)right);
            }

            return (Int128)umul((UInt128)left, right);
        }


        internal static partial class __const
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal static UInt128 umul(UInt128 x, UInt128 _const)
            {
#if DEBUG
Assert.IsTrue(constexpr.IS_CONST(_const));
#endif
                if (constexpr.IS_TRUE(_const == 0))
                {
                    return 0;
                }
                if (constexpr.IS_TRUE(_const == 1))
                {
                    return x;
                }
                if (constexpr.IS_TRUE(_const == 2))
                {
                    return x + x;
                }
                if (constexpr.IS_TRUE(_const == 3))
                {
                    return x + x + x;
                }
                if (constexpr.IS_CONST(_const))
                {
                    UInt128 cpy = _const;
                    int bits = countbits(_const);

                    if (constexpr.IS_CONST(bits) & bits <= 4)
                    {
                        int tz0 = tzcnt(cpy);
                        UInt128 result = (tz0 == 1) ? (x + x) : (x << tz0);

                        if (constexpr.IS_CONST(tz0) & bits == 1)
                        {
                            return result;
                        }

                        cpy ^= (UInt128)1 << tz0;
                        int tz1 = tzcnt(cpy);
                        result += (tz1 == 1) ? (x + x) : (x << tz1);

                        if (constexpr.IS_CONST(tz1) & bits == 2)
                        {
                            return result;
                        }

                        cpy ^= (UInt128)1 << tz1;
                        int tz2 = tzcnt(cpy);
                        result += x << tz2;

                        if (constexpr.IS_CONST(tz2) & bits == 3)
                        {
                            return result;
                        }

                        cpy ^= (UInt128)1 << tz2;
                        int tz3 = tzcnt(cpy);
                        result += x << tz3;

                        if (constexpr.IS_CONST(tz3))
                        {
                            return result;
                        }
                    }
                }

                return UInt128.umul(x, _const);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal static Int128 imul(Int128 x, Int128 _const)
            {
                if (constexpr.IS_TRUE(_const == 0))
                {
                    return 0;
                }
                if (constexpr.IS_TRUE(_const == 1))
                {
                    return x;
                }
                if (constexpr.IS_TRUE(_const == 2))
                {
                    return x + x;
                }
                if (constexpr.IS_TRUE(_const == 3))
                {
                    return x + x + x;
                }
                if (constexpr.IS_TRUE(_const == -1))
                {
                    return -x;
                }
                if (constexpr.IS_TRUE(_const == -2))
                {
                    x = -x;

                    return x + x;
                }
                if (constexpr.IS_TRUE(_const == -3))
                {
                    x = -x;

                    return x + x + x;
                }
                if (constexpr.IS_CONST(_const))
                {
                    Int128 neg = _const < 0 ? -x : x;
                    Int128 cpy = _const < 0 ? -_const : _const;
                    int bits = countbits(cpy);

                    if (constexpr.IS_CONST(bits) & bits <= 4)
                    {
                        int tz0 = tzcnt(cpy);
                        Int128 result = (tz0 == 1) ? (neg + neg) : (neg << tz0);

                        if (constexpr.IS_CONST(tz0) & bits == 1)
                        {
                            return result;
                        }

                        cpy ^= (Int128)1 << tz0;
                        int tz1 = tzcnt(cpy);
                        result += (tz1 == 1) ? (neg + neg) : (neg << tz1);

                        if (constexpr.IS_CONST(tz1) & bits == 2)
                        {
                            return result;
                        }

                        cpy ^= (Int128)1 << tz1;
                        int tz2 = tzcnt(cpy);
                        result += neg << tz2;

                        if (constexpr.IS_CONST(tz2) & bits == 3)
                        {
                            return result;
                        }

                        cpy ^= (Int128)1 << tz2;
                        int tz3 = tzcnt(cpy);
                        result += neg << tz3;

                        if (constexpr.IS_CONST(tz3))
                        {
                            return result;
                        }
                    }
                }

                return UInt128.imul(x, _const);
            }
        }
    }
}