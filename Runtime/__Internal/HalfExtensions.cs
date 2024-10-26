using System.Runtime.CompilerServices;
using Unity.Mathematics;
using MaxMath.Intrinsics;

using static MaxMath.maxmath;

namespace MaxMath
{
    internal static class HalfExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsZero(this half h)
        {
            return (h.value & 0x7FFFu) == 0u;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsNotZero(this half h)
        {
            return (h.value & 0x7FFFu) != 0u;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsEqualTo(this half lhs, half rhs, bool neitherNaN = false, bool neitherZero = false)
        {
            neitherNaN |= constexpr.IS_TRUE(!isnan(lhs)) && constexpr.IS_TRUE(!isnan(rhs));
            neitherZero |= constexpr.IS_TRUE(IsNotZero(lhs)) && constexpr.IS_TRUE(IsNotZero(rhs));

            if (constexpr.IS_TRUE(IsZero(lhs)))
            {
                return IsZero(rhs);
            }
            else if (constexpr.IS_TRUE(IsZero(rhs)))
            {
                return IsZero(lhs);
            }

            bool value = lhs.value == rhs.value;

            if (neitherNaN)
            {
                if (neitherZero)
                {
                    return value;
                }
                else
                {
                    bool zero = IsZero(lhs) & IsZero(rhs);

                    return zero | value;
                }
            }
            else
            {
                bool nan = !isnan(lhs) & !isnan(rhs);

                if (neitherZero)
                {
                    return nan & value;
                }
                else
                {
                    bool zero = IsZero(lhs) & IsZero(rhs);

                    return nan & (zero | value);
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsNotEqualTo(this half lhs, half rhs, bool neitherNaN = false, bool neitherZero = false)
        {
            neitherNaN |= constexpr.IS_TRUE(!isnan(lhs)) && constexpr.IS_TRUE(!isnan(rhs));
            neitherZero |= constexpr.IS_TRUE(IsNotZero(lhs)) && constexpr.IS_TRUE(IsNotZero(rhs));

            if (constexpr.IS_TRUE(IsZero(lhs)))
            {
                return IsNotZero(rhs);
            }
            else if (constexpr.IS_TRUE(IsZero(rhs)))
            {
                return IsNotZero(lhs);
            }

            bool value = lhs.value != rhs.value;

            if (neitherNaN)
            {
                if (neitherZero)
                {
                    return value;
                }
                else
                {
                    bool notBothZero = IsNotZero(new half{ value = (ushort)(lhs.value | rhs.value) });
                    
                    return value & notBothZero;
                }
            }
            else
            {
                bool nan = isnan(lhs) | isnan(rhs);

                if (neitherZero)
                {
                    return nan | value;
                }
                else
                {
                    bool notBothZero = IsNotZero(new half{ value = (ushort)(lhs.value | rhs.value) });

                    return nan | (value & notBothZero);
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsLessThan(this half lhs, half rhs, bool neitherNaN = false, bool neitherZero = false)
        {
            neitherNaN |= constexpr.IS_TRUE(!isnan(lhs)) && constexpr.IS_TRUE(!isnan(rhs));
            neitherZero |= constexpr.IS_TRUE(IsNotZero(lhs)) && constexpr.IS_TRUE(IsNotZero(rhs));

            if (constexpr.IS_TRUE(IsZero(rhs)))
            {
                bool negative = lhs.value > 0x7FFF;
                bool notZero = (lhs.value & 0x7FFF) != 0;

                if (neitherNaN)
                {
                    return notZero & negative;
                }
                else
                {
                    return !isnan(lhs) & (notZero & negative);
                }
            }
            if (constexpr.IS_TRUE(IsZero(lhs)))
            {
                bool positive = rhs.value < 0x8000;
                bool notZero = (rhs.value & 0x7FFF) != 0;

                if (neitherNaN)
                {
                    return positive & notZero;
                }
                else
                {
                    return !isnan(rhs) & (positive & notZero);
                }
            }


            int signA = lhs.value >> 15;
            int signB = rhs.value >> 15;

            bool equalSigns = signA == signB;
            bool differentValues = lhs.value != rhs.value;

            bool ifEqualSigns = differentValues & (tobool(signA) ^ (rhs.value > lhs.value));
            bool ifOppositeSigns = tobool(signA);

            if (!neitherZero)
            {
                bool notBothZero = (ushort)((lhs.value | rhs.value) << 1) != 0;

                ifOppositeSigns &= notBothZero;
            }

            if (neitherNaN)
            {
                return equalSigns ? ifEqualSigns : ifOppositeSigns;
            }
            else
            {
                bool notNaN = !isnan(lhs) & !isnan(rhs);

                return notNaN & (equalSigns ? ifEqualSigns : ifOppositeSigns);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsLessThanOrEqualTo(this half lhs, half rhs, bool neitherNaN = false, bool neitherZero = false)
        {
            neitherNaN |= constexpr.IS_TRUE(!isnan(lhs)) && constexpr.IS_TRUE(!isnan(rhs));
            neitherZero |= constexpr.IS_TRUE(IsNotZero(lhs)) && constexpr.IS_TRUE(IsNotZero(rhs));

            if (constexpr.IS_TRUE(IsZero(rhs)))
            {
                bool intLEzero = 1 > (short)lhs.value;

                if (neitherNaN)
                {
                    return intLEzero;
                }
                else
                {
                    return !isnan(lhs) & intLEzero;
                }
            }
            if (constexpr.IS_TRUE(IsZero(lhs)))
            {
                bool uintGEzero = (short)rhs.value > 0;
                bool negativeZero = rhs.value == 0x8000;

                if (neitherNaN)
                {
                    return uintGEzero | negativeZero;
                }
                else
                {
                    return !isnan(rhs) & (uintGEzero | negativeZero);
                }
            }


            int signA = lhs.value >> 15;
            int signB = rhs.value >> 15;

            bool equalSigns = signA == signB;
            bool equalValues = lhs.value == rhs.value;

            bool ifEqualSigns = equalValues | (tobool(signA) ^ (rhs.value > lhs.value));
            bool ifOppositeSigns = tobool(signA);

            if (!neitherZero)
            {
                bool bothZero = (ushort)((lhs.value | rhs.value) << 1) == 0;

                ifOppositeSigns |= bothZero;
            }

            if (neitherNaN)
            {
                return equalSigns ? ifEqualSigns : ifOppositeSigns;
            }
            else
            {
                bool notNaN = !isnan(lhs) & !isnan(rhs);

                return notNaN & (equalSigns ? ifEqualSigns : ifOppositeSigns);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsGreaterThan(this half lhs, half rhs, bool neitherNaN = false, bool neitherZero = false)
        {
            return rhs.IsLessThan(lhs, neitherNaN, neitherZero);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsGreaterThanOrEqualTo(this half lhs, half rhs, bool neitherNaN = false, bool neitherZero = false)
        {
            return rhs.IsLessThanOrEqualTo(lhs, neitherNaN, neitherZero);
        }
    }
}