using System.Runtime.CompilerServices;
using MaxMath.Intrinsics;

using static Unity.Mathematics.math;
using static MaxMath.maxmath;

namespace MaxMath
{
    unsafe public readonly partial struct UInt128
    {
        internal static partial class __const
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal static UInt128 udiv(UInt128 left, UInt128 right)
            {
                if (constexpr.IS_CONST(right))
                {
                    Divider<UInt128> Divider = new Divider<UInt128>(right);

                    if (constexpr.IS_CONST(Divider))
                    {
                        return left / Divider;
                    }
                }

                return asm128.__udiv128x128(left, right);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal static UInt128 udiv(UInt128 left, ulong right)
            {
                if (constexpr.IS_CONST(right))
                {
                    Divider<UInt128> Divider = new Divider<UInt128>((UInt128)right);

                    if (constexpr.IS_CONST(Divider))
                    {
                        return left / Divider;
                    }
                }

                return asm128.__udiv128x64(left, right);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal static UInt128 urem(UInt128 left, UInt128 right)
            {
                if (constexpr.IS_CONST(right))
                {
                    Divider<UInt128> Divider = new Divider<UInt128>(right);

                    if (constexpr.IS_CONST(Divider))
                    {
                        return left % Divider;
                    }
                }

                return asm128.__urem128x128(left, right);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal static ulong urem(UInt128 left, ulong right)
            {
                if (constexpr.IS_CONST(right))
                {
                    Divider<UInt128> Divider = new Divider<UInt128>((UInt128)right);

                    if (constexpr.IS_CONST(Divider))
                    {
                        return (left % Divider).lo64;
                    }
                }

                return asm128.__urem128x64(left, right);
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal static Int128 idiv(Int128 left, Int128 right)
            {
                if (constexpr.IS_CONST(right))
                {
                    Divider<Int128> Divider = new Divider<Int128>(right);

                    if (constexpr.IS_CONST(Divider))
                    {
                        return left / Divider;
                    }
                }

                return Xse.SIGNED_FROM_UNSIGNED_DIV_I128(out _, (long)left.hi64, (long)right.hi64, (UInt128)abs(left) / (UInt128)abs(right), default(UInt128));
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal static Int128 idiv(Int128 left, long right)
            {
                if (constexpr.IS_CONST(right))
                {
                    Divider<Int128> Divider = new Divider<Int128>((Int128)right);

                    if (constexpr.IS_CONST(Divider))
                    {
                        return left / Divider;
                    }
                }

                return Xse.SIGNED_FROM_UNSIGNED_DIV_I128(out _, (long)left.hi64, right, (UInt128)abs(left) / (ulong)abs(right), default(UInt128));
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal static Int128 idiv(Int128 left, ulong right)
            {
                if (constexpr.IS_CONST(right))
                {
                    Divider<Int128> Divider = new Divider<Int128>((Int128)right);

                    if (constexpr.IS_CONST(Divider))
                    {
                        return left / Divider;
                    }
                }

                return Xse.SIGNED_FROM_UNSIGNED_DIV_I128(out _, (long)left.hi64, 0, (UInt128)abs(left) / right, default(UInt128));
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal static Int128 irem(Int128 left, Int128 right)
            {
                if (constexpr.IS_CONST(right))
                {
                    Divider<Int128> Divider = new Divider<Int128>(right);

                    if (constexpr.IS_CONST(Divider))
                    {
                        return left % Divider;
                    }
                }

                Xse.SIGNED_FROM_UNSIGNED_DIV_I128(out Int128 result, (long)left.hi64, (long)right.hi64, default(UInt128), (UInt128)abs(left) % (UInt128)abs(right));

                return result;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal static Int128 irem(Int128 left, long right)
            {
                if (constexpr.IS_CONST(right))
                {
                    Divider<Int128> Divider = new Divider<Int128>((Int128)right);

                    if (constexpr.IS_CONST(Divider))
                    {
                        return left % Divider;
                    }
                }

                Xse.SIGNED_FROM_UNSIGNED_DIV_I128(out Int128 result, (long)left.hi64, right, default(UInt128), (UInt128)abs(left) % (ulong)abs(right));

                return result;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal static Int128 irem(Int128 left, ulong right)
            {
                if (constexpr.IS_CONST(right))
                {
                    Divider<Int128> Divider = new Divider<Int128>((Int128)right);

                    if (constexpr.IS_CONST(Divider))
                    {
                        return left % Divider;
                    }
                }

                Xse.SIGNED_FROM_UNSIGNED_DIV_I128(out Int128 result, (long)left.hi64, 0, default(UInt128), (UInt128)abs(left) % right);

                return result;
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal static UInt128 divrem10(UInt128 x, out ulong rem)
            {
                UInt128 mul = new UInt128(0xCCCC_CCCC_CCCC_CCCD, 0xCCCC_CCCC_CCCC_CCCC);
                UInt128 q = __const.shruint128(__UInt256__.umul256(x, mul).hi128, 3);

                UInt128 q10 = __const.shluint128(q, 3) + __const.shluint128(q, 1);

                rem = (x - q10).lo64;
                return q;
            }
        }
    }
}