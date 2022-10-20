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
        internal static bool IsEqualTo(this half lhs, half rhs)
        {
            if (Xse.constexpr.IS_TRUE(IsZero(lhs)))
            {
                return IsZero(rhs);
            }
            else if (Xse.constexpr.IS_TRUE(IsZero(rhs)))
            {
                return IsZero(lhs);
            }

            bool nan   = !isnan(lhs) & !isnan(rhs);
            bool zero  = IsZero(lhs) & IsZero(rhs);
            bool value = lhs.value == rhs.value;

            return nan & (zero | value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsNotEqualTo(this half lhs, half rhs)
        {
            if (Xse.constexpr.IS_TRUE(IsZero(lhs)))
            {
                return IsNotZero(rhs);
            }
            else if (Xse.constexpr.IS_TRUE(IsZero(rhs)))
            {
                return IsNotZero(lhs);
            }
            
            bool bothZero = IsZero(new half{ value = (ushort)(lhs.value | rhs.value) });
            bool value    = lhs.value != rhs.value;
            bool nan      = isnan(lhs) | isnan(rhs);

            return nan | !bothZero | value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsLessThan(this half lhs, half rhs)
        {
            if (Xse.constexpr.IS_TRUE(rhs.value == 0) || Xse.constexpr.IS_TRUE(rhs.value == 0x8000))
            {
                bool negative = lhs.value > 0x7FFF;
                bool notZero = (lhs.value & 0x7FFF) != 0;
            
                return !isnan(lhs) & (notZero & negative);
            }
            if (Xse.constexpr.IS_TRUE(lhs.value == 0) || Xse.constexpr.IS_TRUE(lhs.value == 0x8000))
            {
                bool positive = rhs.value < 0x8000;
                bool notZero = (rhs.value & 0x7FFF) != 0;

                return !isnan(rhs) & (positive & notZero);
            }


            int signA = lhs.value >> 15;
            int signB = rhs.value >> 15;

            bool notNaN = !isnan(lhs) & !isnan(rhs);
            bool equalSigns = signA == signB;
            bool differentValues = lhs.value != rhs.value;
            bool notBothZero = (ushort)((lhs.value | rhs.value) << 1) != 0;

            bool ifEqualSigns = differentValues & (tobool(signA) ^ (rhs.value > lhs.value));
            bool ifOppositeSigns = notBothZero & tobool(signA);

            return notNaN & (equalSigns ? ifEqualSigns : ifOppositeSigns);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsLessThanOrEqualTo(this half lhs, half rhs)
        {
            if (Xse.constexpr.IS_TRUE(rhs.value == 0) || Xse.constexpr.IS_TRUE(rhs.value == 0x8000))
            {
                bool intLEzero = 1 > (short)lhs.value;
            
                return !isnan(lhs) & intLEzero;
            }
            if (Xse.constexpr.IS_TRUE(lhs.value == 0) || Xse.constexpr.IS_TRUE(lhs.value == 0x8000))
            {
                bool uintGEzero = (short)rhs.value > 0;
                bool negativeZero = rhs.value == 0x8000;
            
                return !isnan(rhs) & (uintGEzero | negativeZero);
            }


            int signA = lhs.value >> 15;
            int signB = rhs.value >> 15;

            bool notNaN = !isnan(lhs) & !isnan(rhs);
            bool equalSigns = signA == signB;
            bool equalValues = lhs.value == rhs.value;
            bool bothZero = (ushort)((lhs.value | rhs.value) << 1) == 0;

            bool ifEqualSigns = equalValues | (tobool(signA) ^ (rhs.value > lhs.value));
            bool ifOppositeSigns = bothZero | tobool(signA);

            return notNaN & (equalSigns ? ifEqualSigns : ifOppositeSigns);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsGreaterThan(this half lhs, half rhs)
        {
            return rhs.IsLessThan(lhs);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsGreaterThanOrEqualTo(this half lhs, half rhs)
        {
            return rhs.IsLessThanOrEqualTo(lhs);
        }
    }
}