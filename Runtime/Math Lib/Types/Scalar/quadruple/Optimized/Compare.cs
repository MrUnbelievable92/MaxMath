using System.Runtime.CompilerServices;
using MaxMath.Intrinsics;

using static MaxMath.maxmath;

namespace MaxMath
{
    unsafe public readonly partial struct quadruple
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsZero(quadruple.ConstChecked x)
        {
            // TODO
            //if (constexpr.IS_TRUE(x.Promise.MinPossible > 0 || x.Promise.MaxPossible < 0))
            //{
            //    return false;
            //}
            //if (constexpr.IS_TRUE(x.Promise.MinPossible == 0 && x.Promise.MaxPossible == 0))
            //{
            //    return true;
            //}

            if (x.Promise.NoSignedZero)
            {
                return x.Value.value.IsZero;
            }
            else
            {
                return (x.Value.value.lo64 | (x.Value.value.hi64 << 1)) == 0;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsNotZero(quadruple.ConstChecked x)
        {
            // TODO
            //if (constexpr.IS_TRUE(x.Promise.MinPossible > 0 || x.Promise.MaxPossible < 0))
            //{
            //    return true;
            //}
            //if (constexpr.IS_TRUE(x.Promise.MinPossible == 0 && x.Promise.MaxPossible == 0))
            //{
            //    return false;
            //}

            if (x.Promise.NoSignedZero)
            {
                return x.Value.value.IsNotZero;
            }
            else
            {
                return (x.Value.value.lo64 | (x.Value.value.hi64 << 1)) != 0;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsPositive(quadruple.ConstChecked x)
        {
            // TODO
            //if (constexpr.IS_TRUE(x.Promise.MinPossible > 0))
            //{
            //    return true;
            //}
            //if (constexpr.IS_TRUE(x.Promise.MaxPossible < 0))
            //{
            //    return false;
            //}

            if (x.Promise.Positive) return true;

            bool positive = (long)x.Value.value.hi64 >= 0;
            bool notZero = IsNotZero(x);

            if (x.Promise.NotNaN)
            {
                return positive & notZero;
            }
            else
            {
                return !isnan(x) & (positive & notZero);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsNegative(quadruple.ConstChecked x)
        {
            // TODO
            //if (constexpr.IS_TRUE(x.Promise.MinPossible > 0))
            //{
            //    return false;
            //}
            //if (constexpr.IS_TRUE(x.Promise.MaxPossible < 0))
            //{
            //    return true;
            //}

            if (x.Promise.Negative) return true;

            bool negative = (long)x.Value.value.hi64 < 0;
            bool notZero = IsNotZero(x);

            if (x.Promise.NotNaN)
            {
                return notZero & negative;
            }
            else
            {
                return !isnan(x) & (notZero & negative);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsZeroOrGreater(quadruple.ConstChecked x)
        {
            // TODO
            //if (constexpr.IS_TRUE(x.Promise.MinPossible >= 0))
            //{
            //    return true;
            //}
            //if (constexpr.IS_TRUE(x.Promise.MaxPossible < 0))
            //{
            //    return false;
            //}

            if (x.Promise.ZeroOrGreater) return true;

            bool uintGEzero = (Int128)x.Value.value > 0;
            bool negativeZero = x.Promise.NoSignedZero ? false
                                                       : x.Value.value == (UInt128)1 << 127;
            if (x.Promise.NotNaN)
            {
                return uintGEzero | negativeZero;
            }
            else
            {
                return !isnan(x) & (uintGEzero | negativeZero);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsZeroOrLess(quadruple.ConstChecked x)
        {
            // TODO
            //if (constexpr.IS_TRUE(x.Promise.MinPossible > 0))
            //{
            //    return false;
            //}
            //if (constexpr.IS_TRUE(x.Promise.MaxPossible <= 0))
            //{
            //    return true;
            //}

            if (x.Promise.ZeroOrLess) return true;

            bool intLEzero = 1 > (Int128)x.Value.value;

            if (x.Promise.NotNaN)
            {
                return intLEzero;
            }
            else
            {
                return !isnan(x) & intLEzero;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool Equal(quadruple.ConstChecked left, quadruple.ConstChecked right)
        {
            // TODO
            //if (constexpr.IS_TRUE(left.Promise.MaxPossible < right.Promise.MinPossible))
            //{
            //    return false;
            //}
            //if (constexpr.IS_TRUE(left.Promise.MinPossible > right.Promise.MaxPossible))
            //{
            //    return false;
            //}

            if (constexpr.IS_TRUE(IsZero(left)))
            {
                return IsZero(right);
            }
            if (constexpr.IS_TRUE(IsZero(right)))
            {
                return IsZero(left);
            }

            UInt128 l = left.Value.value;
            UInt128 r = right.Value.value;

            bool loEq = l.lo64 == r.lo64;
            bool hiEq = l.hi64 == r.hi64;

            if (!(left.Promise.NonZero || right.Promise.NonZero))
            {
                ulong orHi = l.hi64 | r.hi64;
                if (!(left.Promise.Positive && right.Promise.Positive))
                {
                    orHi += orHi;
                }
                hiEq |= (l.lo64 | orHi) == 0;
            }

            if (!(left.Promise.NotNaN && right.Promise.NotNaN))
            {
                bool eitherNaN = (left.Promise.NotNaN ? false : isnan(left))
                               | (right.Promise.NotNaN ? false : isnan(right));

                loEq = andnot(loEq, eitherNaN);
            }

            return loEq & hiEq;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool NotEqual(quadruple.ConstChecked left, quadruple.ConstChecked right)
        {
            // TODO
            //if (constexpr.IS_TRUE(left.Promise.MaxPossible < right.Promise.MinPossible))
            //{
            //    return true;
            //}
            //if (constexpr.IS_TRUE(left.Promise.MinPossible > right.Promise.MaxPossible))
            //{
            //    return true;
            //}

            if (constexpr.IS_TRUE(IsZero(left)))
            {
                return IsNotZero(right);
            }
            if (constexpr.IS_TRUE(IsZero(right)))
            {
                return IsNotZero(left);
            }

            UInt128 l = left.Value.value;
            UInt128 r = right.Value.value;

            bool loNeq = l.lo64 != r.lo64;
            bool hiNeq = l.hi64 != r.hi64;

            if (!(left.Promise.NonZero || right.Promise.NonZero))
            {
                UInt128 or = l | r;
                bool notBothZero;
                if (!(left.Promise.Positive && right.Promise.Positive))
                {
                    notBothZero = (or.lo64 | (or.hi64 + or.hi64)) != 0;
                }
                else
                {
                    notBothZero = (or.lo64 | or.hi64) != 0;
                }
                hiNeq &= notBothZero;
            }

            if (!(left.Promise.NotNaN && right.Promise.NotNaN))
            {
                bool eitherNaN = (left.Promise.NotNaN ? false : isnan(left))
                               | (right.Promise.NotNaN ? false : isnan(right));

                loNeq |= eitherNaN;
            }

            return loNeq | hiNeq;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool LessThan(quadruple.ConstChecked left, quadruple.ConstChecked right)
        {
            // TODO
            //if (constexpr.IS_TRUE(left.Promise.MaxPossible < right.Promise.MinPossible))
            //{
            //    return true;
            //}

            UInt128 l = left.Value.value;
            UInt128 r = right.Value.value;

            if (constexpr.IS_TRUE(IsZero(right)))
            {
                return IsNegative(left);
            }
            if (constexpr.IS_TRUE(IsZero(left)))
            {
                return IsPositive(right);
            }

            ulong signA = SignBitLo(left);

            bool equalSigns = EqualSignBitsLo(left, right);
            bool differentValues = l != r;
            bool ifEqualSigns = differentValues & (tobool(signA) ^ (l < r));
            bool ifOppositeSigns = tobool(signA);

            if (!(left.Promise.NonZero || right.Promise.NonZero))
            {
                UInt128 or = l | r;
                bool notBothZero;
                if (!(left.Promise.Positive && right.Promise.Positive))
                {
                    notBothZero = (or.lo64 | (or.hi64 + or.hi64)) != 0;
                }
                else
                {
                    notBothZero = (or.lo64 | or.hi64) != 0;
                }
                ifOppositeSigns &= notBothZero;
            }

            if (left.Promise.NotNaN && right.Promise.NotNaN)
            {
                return equalSigns ? ifEqualSigns : ifOppositeSigns;
            }
            else
            {
                bool notNaN = !isnan(left) & !isnan(right);

                return notNaN & (equalSigns ? ifEqualSigns : ifOppositeSigns);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool GreaterThan(quadruple.ConstChecked left, quadruple.ConstChecked right) => LessThan(right, left);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool LessEqual(quadruple.ConstChecked left, quadruple.ConstChecked right)
        {
            // TODO
            //if (constexpr.IS_TRUE(left.Promise.MaxPossible <= right.Promise.MinPossible))
            //{
            //    return true;
            //}

            UInt128 l = left.Value.value;
            UInt128 r = right.Value.value;

            if (constexpr.IS_TRUE(IsZero(right)))
            {
                return IsZeroOrLess(left);
            }
            if (constexpr.IS_TRUE(IsZero(left)))
            {
                return IsZeroOrGreater(right);
            }

            ulong signA = SignBitLo(left);

            bool equalSigns = EqualSignBitsLo(left, right);
            bool equalValues = l == r;
            bool ifEqualSigns = equalValues | (tobool(signA) ^ (l < r));
            bool ifOppositeSigns = tobool(signA);

            if (!(left.Promise.NonZero || right.Promise.NonZero))
            {
                UInt128 or = l | r;
                bool bothZero;
                if (!(left.Promise.Positive && right.Promise.Positive))
                {
                    bothZero = (or.lo64 | (or.hi64 + or.hi64)) == 0;
                }
                else
                {
                    bothZero = (or.lo64 | or.hi64) == 0;
                }
                ifOppositeSigns |= bothZero;
            }

            if (left.Promise.NotNaN && right.Promise.NotNaN)
            {
                return equalSigns ? ifEqualSigns : ifOppositeSigns;
            }
            else
            {
                bool notNaN = !isnan(left) & !isnan(right);

                return notNaN & (equalSigns ? ifEqualSigns : ifOppositeSigns);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool GreaterEqual(quadruple.ConstChecked left, quadruple.ConstChecked right) => LessEqual(right, left);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (quadruple left, quadruple right) => Equal(left, right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (quadruple left, quadruple right) => NotEqual(left, right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator < (quadruple left, quadruple right) => LessThan(left, right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator > (quadruple left, quadruple right) => GreaterThan(left, right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <= (quadruple left, quadruple right) => LessEqual(left, right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (quadruple left, quadruple right) => GreaterEqual(left, right);
    }
}
