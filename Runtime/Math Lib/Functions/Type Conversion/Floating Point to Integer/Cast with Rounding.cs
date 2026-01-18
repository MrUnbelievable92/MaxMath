using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;
using static MaxMath.LUT.FLOATING_POINT;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint BASE_cvtf8i32(quarter x, bool signed, bool trunc, bool evenOnTie = true, bool nonZero = false, bool positive = false)
        {
            if (trunc)
            {
                int exp = x.value >> quarter.MANTISSA_BITS;

                int hi = new sbyte16(0, 0, 0, 1, 2, 4, 8, 0,   0, 0, 0,-1,-2,-4,-8, 0)[exp];
                int shr = new byte16(4, 4, 4, 4, 3, 2, 1, 0,   4, 4, 4, 4, 3, 2, 1, 0)[exp];

                int lo = x.value & bitmask32(quarter.MANTISSA_BITS);
                lo >>= shr;
                lo = negate(lo, signed && (x.value & (1 << 7)) != 0);

                return (uint)(lo + hi);
            }
            else
            {
                uint IMPLICIT_ONE = 1u << quarter.MANTISSA_BITS;
                uint MANTISSA_MASK = bitmask32((uint)quarter.MANTISSA_BITS);
                uint EXP = (uint)math.abs(quarter.EXPONENT_BIAS) + quarter.MANTISSA_BITS;

                uint __x = asbyte(x);

                uint biasedExponent;
                if (positive || !signed || (!COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO && constexpr.IS_TRUE(x >= 0)) || constexpr.IS_TRUE(__x < 1u << 7) || constexpr.IS_TRUE(x.IsGreaterThan(quarter.Zero)))
                {
                    biasedExponent = __x >> quarter.MANTISSA_BITS;
                }
                else
                {
                    biasedExponent = (__x << (1 + 24)) >> (quarter.MANTISSA_BITS + (1 + 24));
                }

                uint mantissa = IMPLICIT_ONE | (__x & MANTISSA_MASK);
                uint shift_mnt;
                uint shift_int;
                if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                {
                    shift_mnt = EXP -            (biasedExponent > EXP ? EXP : biasedExponent);
                    shift_int = biasedExponent - (EXP > biasedExponent ? biasedExponent : EXP);
                }
                else
                {
                    shift_mnt = EXP -            ((__x & bitmask32((uint)quarter.EXPONENT_BITS, quarter.MANTISSA_BITS)) > EXP << quarter.MANTISSA_BITS ? EXP : biasedExponent);
                    shift_int = biasedExponent - ((__x & bitmask32((uint)quarter.EXPONENT_BITS, quarter.MANTISSA_BITS)) < EXP << quarter.MANTISSA_BITS ? biasedExponent : EXP);
                }

                uint result = mantissa << (int)shift_int;

                uint ifRound = COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size
                             ? tobyte(EXP > biasedExponent)
                             : tobyte(EXP << quarter.MANTISSA_BITS > (__x & bitmask32((uint)quarter.EXPONENT_BITS, quarter.MANTISSA_BITS)));

                uint round = ifRound << (int)(shift_mnt - 1);
                if (evenOnTie)
                {
                    round -= andnot(ifRound, mantissa >> (int)shift_mnt);
                }

                result += round;
                
                result = shift_mnt <= 31 ? result >> (int)shift_mnt : 0;

                return (uint)negate((int)result, signed && (x.value & (1 << 7)) != 0);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint BASE_cvtf16i32(half x, bool signed, bool trunc, bool evenOnTie = true, bool nonZero = false, bool positive = false)
        {
            nonZero &= trunc;

            uint IMPLICIT_ONE = 1u << F16_MANTISSA_BITS;
            uint MANTISSA_MASK = bitmask32((uint)F16_MANTISSA_BITS);
            uint EXP = (uint)math.abs(F16_EXPONENT_BIAS) + F16_MANTISSA_BITS;

            uint __x = asushort(x);

            uint biasedExponent;
            if (positive || (!signed && nonZero) || (!COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO && constexpr.IS_TRUE(x >= 0)) || constexpr.IS_TRUE(__x < 1u << 15) || constexpr.IS_TRUE(x.IsGreaterThan(half.zero)))
            {
                biasedExponent = __x >> F16_MANTISSA_BITS;
            }
            else
            {
                biasedExponent = (__x << (1 + 16)) >> (F16_MANTISSA_BITS + (1 + 16));
            }

            uint mantissa = IMPLICIT_ONE | (__x & MANTISSA_MASK);
            uint shift_mnt;
            uint shift_int;
            if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
            {
                shift_mnt = EXP -            (biasedExponent > EXP ? EXP : biasedExponent);
                shift_int = biasedExponent - (EXP > biasedExponent ? biasedExponent : EXP);
            }
            else
            {
                shift_mnt = EXP -            ((__x & bitmask32((uint)F16_EXPONENT_BITS, F16_MANTISSA_BITS)) > EXP << F16_MANTISSA_BITS ? EXP : biasedExponent);
                shift_int = biasedExponent - ((__x & bitmask32((uint)F16_EXPONENT_BITS, F16_MANTISSA_BITS)) < EXP << F16_MANTISSA_BITS ? biasedExponent : EXP);
            }

            uint result = mantissa << (int)shift_int;

            if (!trunc)
            {
                uint ifRound = COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size
                             ? tobyte(EXP > biasedExponent)
                             : tobyte(EXP << F16_MANTISSA_BITS > (__x & bitmask32((uint)F16_EXPONENT_BITS, F16_MANTISSA_BITS)));

                uint round = ifRound << (int)(shift_mnt - 1);
                if (evenOnTie)
                {
                    round -= andnot(ifRound, mantissa >> (int)shift_mnt);
                }

                result += round;
            }
            
            result = shift_mnt <= 31 ? result >> (int)shift_mnt : 0;

            return (uint)negate((int)result, signed && x.IsLessThan(half.zero));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint BASE_cvtf32i32(float x, bool signed, bool trunc, bool evenOnTie = true, bool nonZero = false, bool positive = false)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (signed)
                {
                    if (trunc)
                    {
                        return Xse.cvttps_epi32(RegisterConversion.ToV128(x)).UInt0;
                    }
                    else
                    {
                        return Xse.cvtps_epi32(RegisterConversion.ToV128(x)).UInt0;
                    }
                }
                else
                {
                    if (trunc)
                    {
                        return (uint)Xse.cvttss_si64(RegisterConversion.ToV128(x));
                    }
                    else
                    {
                        return (uint)Xse.cvtss_si64(RegisterConversion.ToV128(x));
                    }
                }
            }

            nonZero &= trunc;

            uint IMPLICIT_ONE = 1u << F32_MANTISSA_BITS;
            uint MANTISSA_MASK = bitmask32((uint)F32_MANTISSA_BITS);
            uint EXP = (uint)math.abs(F32_EXPONENT_BIAS) + F32_MANTISSA_BITS;

            uint __x = math.asuint(x);

            uint biasedExponent;
            if (positive || (!signed && nonZero) || (!COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO && constexpr.IS_TRUE(x >= 0)) || constexpr.IS_TRUE(__x < 1u << 31) || constexpr.IS_TRUE(x > 0f))
            {
                biasedExponent = __x >> F32_MANTISSA_BITS;
            }
            else
            {
                biasedExponent = (__x << 1) >> (F32_MANTISSA_BITS + 1);
            }

            uint mantissa = (IMPLICIT_ONE | (__x & MANTISSA_MASK));
            uint shift_mnt;
            uint shift_int;
            if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
            {
                shift_mnt = EXP -            (biasedExponent > EXP ? EXP : biasedExponent);
                shift_int = biasedExponent - (EXP > biasedExponent ? biasedExponent : EXP);
            }
            else
            {
                shift_mnt = EXP -            ((__x & bitmask32((uint)F32_EXPONENT_BITS, F32_MANTISSA_BITS)) > EXP << F32_MANTISSA_BITS ? EXP : biasedExponent);
                shift_int = biasedExponent - ((__x & bitmask32((uint)F32_EXPONENT_BITS, F32_MANTISSA_BITS)) < EXP << F32_MANTISSA_BITS ? biasedExponent : EXP);
            }

            uint result = mantissa << (int)shift_int;

            if (!trunc)
            {
                uint ifRound = COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size
                             ? tobyte(EXP > biasedExponent)
                             : tobyte(EXP << F32_MANTISSA_BITS > (__x & bitmask32((uint)F32_EXPONENT_BITS, F32_MANTISSA_BITS)));

                uint round = ifRound << (int)(shift_mnt - 1);
                if (evenOnTie)
                {
                    round -= andnot(ifRound, mantissa >> (int)shift_mnt);
                }

                result += round;
            }

            result = shift_mnt <= 31 ? result >> (int)shift_mnt : 0;

            return (uint)negate((int)result, signed && x < 0f);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong BASE_cvtf32i64(float x, bool signed, bool trunc, bool evenOnTie = true, bool nonZero = false, bool positive = false)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (signed)
                {
                    if (trunc)
                    {
                        return (ulong)Xse.cvttss_si64(RegisterConversion.ToV128(x));
                    }
                    else
                    {
                        return (ulong)Xse.cvtss_si64(RegisterConversion.ToV128(x));
                    }
                }
            }

            nonZero &= trunc;

            ulong IMPLICIT_ONE = 1ul << F32_MANTISSA_BITS;
            ulong MANTISSA_MASK = bitmask64((ulong)F32_MANTISSA_BITS);
            ulong EXP = (uint)math.abs(F32_EXPONENT_BIAS) + F32_MANTISSA_BITS;

            ulong __x = math.asuint(x);

            ulong biasedExponent;
            if (positive || (!signed && nonZero) || (!COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO && constexpr.IS_TRUE(x >= 0)) || constexpr.IS_TRUE(__x < 1u << 31) || constexpr.IS_TRUE(x > 0f))
            {
                biasedExponent = __x >> F32_MANTISSA_BITS;
            }
            else
            {
                biasedExponent = (__x << (1 + 32)) >> (F32_MANTISSA_BITS + (1 + 32));
            }

            ulong mantissa = (IMPLICIT_ONE | (__x & MANTISSA_MASK));
            ulong shift_mnt;
            ulong shift_int;
            if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
            {
                shift_mnt = EXP -            (biasedExponent > EXP ? EXP : biasedExponent);
                shift_int = biasedExponent - (EXP > biasedExponent ? biasedExponent : EXP);
            }
            else
            {
                shift_mnt = EXP -            ((__x & bitmask32((uint)F32_EXPONENT_BITS, F32_MANTISSA_BITS)) > EXP << F32_MANTISSA_BITS ? EXP : biasedExponent);
                shift_int = biasedExponent - ((__x & bitmask32((uint)F32_EXPONENT_BITS, F32_MANTISSA_BITS)) < EXP << F32_MANTISSA_BITS ? biasedExponent : EXP);
            }

            ulong result = mantissa << (int)shift_int;

            if (!trunc)
            {
                ulong ifRound = COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size
                              ? tobyte(EXP > biasedExponent)
                              : tobyte(EXP << F32_MANTISSA_BITS > (__x & bitmask32((uint)F32_EXPONENT_BITS, F32_MANTISSA_BITS)));

                ulong round = ifRound << (int)(shift_mnt - 1);
                if (evenOnTie)
                {
                    round -= andnot(ifRound, mantissa >> (int)shift_mnt);
                }

                result += round;
            }
            
            result = shift_mnt <= 63 ? result >> (int)shift_mnt : 0;

            return (ulong)negate((long)result, signed && x < 0f);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static UInt128 BASE_cvtf32i128(float x, bool signed, bool trunc, bool evenOnTie = true, bool nonZero = false, bool positive = false)
        {
            nonZero &= trunc;

            ulong IMPLICIT_ONE = 1ul << F32_MANTISSA_BITS;
            ulong MANTISSA_MASK = bitmask64((ulong)F32_MANTISSA_BITS);
            ulong EXP = (uint)math.abs(F32_EXPONENT_BIAS) + F32_MANTISSA_BITS;

            ulong __x = math.asuint(x);

            ulong biasedExponent;
            if (positive || (!signed && nonZero) || (!COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO && constexpr.IS_TRUE(x >= 0)) || constexpr.IS_TRUE(__x < 1u << 31) || constexpr.IS_TRUE(x > 0f))
            {
                biasedExponent = __x >> F32_MANTISSA_BITS;
            }
            else
            {
                biasedExponent = (__x << (1 + 32)) >> (F32_MANTISSA_BITS + (1 + 32));
            }

            ulong mantissa = (IMPLICIT_ONE | (__x & MANTISSA_MASK));
            ulong shift_mnt;
            ulong shift_int;
            if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
            {
                shift_mnt = EXP -            (biasedExponent > EXP ? EXP : biasedExponent);
                shift_int = biasedExponent - (EXP > biasedExponent ? biasedExponent : EXP);
            }
            else
            {
                shift_mnt = EXP -            ((__x & bitmask32((uint)F32_EXPONENT_BITS, F32_MANTISSA_BITS)) > EXP << F32_MANTISSA_BITS ? EXP : biasedExponent);
                shift_int = biasedExponent - ((__x & bitmask32((uint)F32_EXPONENT_BITS, F32_MANTISSA_BITS)) < EXP << F32_MANTISSA_BITS ? biasedExponent : EXP);
            }

            UInt128 result = (UInt128)mantissa << (int)shift_int;

            if (!trunc)
            {
                ulong ifRound = COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size
                              ? tobyte(EXP > biasedExponent)
                              : tobyte(EXP << F32_MANTISSA_BITS > (__x & bitmask32((uint)F32_EXPONENT_BITS, F32_MANTISSA_BITS)));

                UInt128 round = (UInt128)ifRound << (int)(shift_mnt - 1);
                if (evenOnTie)
                {
                    round -= andnot(ifRound, mantissa >> (int)shift_mnt);
                }

                result += round;
            }
            
            result = shift_mnt <= 127 ? result >> (int)shift_mnt : 0;

            return (UInt128)negate((Int128)result, signed && x < 0f);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong BASE_cvtf64i64(double x, bool signed, bool trunc, bool evenOnTie = true, bool nonZero = false, bool positive = false)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (signed)
                {
                    if (trunc)
                    {
                        return (ulong)Xse.cvttsd_si64(RegisterConversion.ToV128(x));
                    }
                    else
                    {
                        return (ulong)Xse.cvtsd_si64(RegisterConversion.ToV128(x));
                    }
                }
            }

            nonZero &= trunc;

            ulong IMPLICIT_ONE = 1ul << F64_MANTISSA_BITS;
            ulong MANTISSA_MASK = bitmask64((ulong)F64_MANTISSA_BITS);
            ulong EXP = (uint)math.abs(F64_EXPONENT_BIAS) + F64_MANTISSA_BITS;

            ulong __x = math.asulong(x);

            ulong biasedExponent;
            if (positive || (!signed && nonZero) || (!COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO && constexpr.IS_TRUE(x >= 0)) || constexpr.IS_TRUE(__x < 1ul << 63) || constexpr.IS_TRUE(x > 0d))
            {
                biasedExponent = __x >> F64_MANTISSA_BITS;
            }
            else
            {
                biasedExponent = (__x << 1) >> (F64_MANTISSA_BITS + 1);
            }

            ulong mantissa = (IMPLICIT_ONE | (__x & MANTISSA_MASK));
            ulong shift_mnt;
            ulong shift_int;
            if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
            {
                shift_mnt = EXP -            (biasedExponent > EXP ? EXP : biasedExponent);
                shift_int = biasedExponent - (EXP > biasedExponent ? biasedExponent : EXP);
            }
            else
            {
                shift_mnt = EXP -            ((__x & bitmask64((ulong)F64_EXPONENT_BITS, F64_MANTISSA_BITS)) > EXP << F64_MANTISSA_BITS ? EXP : biasedExponent);
                shift_int = biasedExponent - ((__x & bitmask64((ulong)F64_EXPONENT_BITS, F64_MANTISSA_BITS)) < EXP << F64_MANTISSA_BITS ? biasedExponent : EXP);
            }

            ulong result = mantissa << (int)shift_int;

            if (!trunc)
            {
                ulong ifRound = COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size
                              ? tobyte(EXP > biasedExponent)
                              : tobyte(EXP << F64_MANTISSA_BITS > (__x & bitmask64((ulong)F64_EXPONENT_BITS, F64_MANTISSA_BITS)));

                ulong round = ifRound << (int)(shift_mnt - 1);
                if (evenOnTie)
                {
                    round -= andnot(ifRound, mantissa >> (int)shift_mnt);
                }

                result += round;
            }
            
            result = shift_mnt <= 63 ? result >> (int)shift_mnt : 0;

            return (ulong)negate((long)result, signed && x < 0d);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static UInt128 BASE_cvtf64i128(double x, bool signed, bool trunc, bool evenOnTie = true, bool nonZero = false, bool positive = false)
        {
            nonZero &= trunc;

            ulong IMPLICIT_ONE = 1ul << F64_MANTISSA_BITS;
            ulong MANTISSA_MASK = bitmask64((ulong)F64_MANTISSA_BITS);
            ulong EXP = (uint)math.abs(F64_EXPONENT_BIAS) + F64_MANTISSA_BITS;

            ulong __x = math.asulong(x);

            ulong biasedExponent;
            if (positive || (!signed && nonZero) || (!COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO && constexpr.IS_TRUE(x >= 0)) || constexpr.IS_TRUE(__x < 1ul << 63) || constexpr.IS_TRUE(x > 0d))
            {
                biasedExponent = __x >> F64_MANTISSA_BITS;
            }
            else
            {
                biasedExponent = (__x << 1) >> (F64_MANTISSA_BITS + 1);
            }

            ulong mantissa = (IMPLICIT_ONE | (__x & MANTISSA_MASK));
            ulong shift_mnt;
            ulong shift_int;
            if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
            {
                shift_mnt = EXP -            (biasedExponent > EXP ? EXP : biasedExponent);
                shift_int = biasedExponent - (EXP > biasedExponent ? biasedExponent : EXP);
            }
            else
            {
                shift_mnt = EXP -            ((__x & bitmask64((ulong)F64_EXPONENT_BITS, F64_MANTISSA_BITS)) > EXP << F64_MANTISSA_BITS ? EXP : biasedExponent);
                shift_int = biasedExponent - ((__x & bitmask64((ulong)F64_EXPONENT_BITS, F64_MANTISSA_BITS)) < EXP << F64_MANTISSA_BITS ? biasedExponent : EXP);
            }

            UInt128 result = (UInt128)mantissa << (int)shift_int;

            if (!trunc)
            {
                ulong ifRound = COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size
                              ? tobyte(EXP > biasedExponent)
                              : tobyte(EXP << F64_MANTISSA_BITS > (__x & bitmask64((ulong)F64_EXPONENT_BITS, F64_MANTISSA_BITS)));

                UInt128 round = (UInt128)ifRound << (int)(shift_mnt - 1);
                if (evenOnTie)
                {
                    round -= andnot(ifRound, mantissa >> (int)shift_mnt);
                }

                result += round;
            }
            
            result = shift_mnt <= 127 ? result >> (int)shift_mnt : 0;

            return (UInt128)negate((Int128)result, signed && x < 0d);
        }



        /// <summary>       Converts a <see cref="MaxMath.quarter"/> to an <see cref="sbyte"/> while rounding towards the nearest integer value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte roundtosbyte(quarter x, Promise promises = Promise.Nothing)
        {
            return (sbyte)BASE_cvtf8i32(x, signed: true, trunc: false, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.quarter2"/> to an <see cref="MaxMath.sbyte2"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 roundtosbyte(quarter2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtpq_epi8(x, elements: 2, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new sbyte2(roundtosbyte(x.x, promises), roundtosbyte(x.y, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.quarter3"/> to an <see cref="MaxMath.sbyte3"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 roundtosbyte(quarter3 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtpq_epi8(x, elements: 3, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new sbyte3(roundtosbyte(x.x, promises), roundtosbyte(x.y, promises), roundtosbyte(x.z, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.quarter4"/> to an <see cref="MaxMath.sbyte4"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 roundtosbyte(quarter4 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtpq_epi8(x, elements: 4, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new sbyte4(roundtosbyte(x.x, promises), roundtosbyte(x.y, promises), roundtosbyte(x.z, promises), roundtosbyte(x.w, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.quarter8"/> to an <see cref="MaxMath.sbyte8"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 roundtosbyte(quarter8 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtpq_epi8(x, elements: 8, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new sbyte8(roundtosbyte(x.x0, promises), roundtosbyte(x.x1, promises), roundtosbyte(x.x2, promises), roundtosbyte(x.x3, promises), roundtosbyte(x.x4, promises), roundtosbyte(x.x5, promises), roundtosbyte(x.x6, promises), roundtosbyte(x.x7, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.quarter16"/> to an <see cref="MaxMath.sbyte16"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 roundtosbyte(quarter16 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtpq_epi8(x, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new sbyte16(roundtosbyte(x.x0, promises), roundtosbyte(x.x1, promises), roundtosbyte(x.x2, promises), roundtosbyte(x.x3, promises), roundtosbyte(x.x4, promises), roundtosbyte(x.x5, promises), roundtosbyte(x.x6, promises), roundtosbyte(x.x7, promises), roundtosbyte(x.x8, promises), roundtosbyte(x.x9, promises), roundtosbyte(x.x10, promises), roundtosbyte(x.x11, promises), roundtosbyte(x.x12, promises), roundtosbyte(x.x13, promises), roundtosbyte(x.x14, promises), roundtosbyte(x.x15, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.quarter32"/> to an <see cref="MaxMath.sbyte32"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 roundtosbyte(quarter32 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtpq_epi8(x, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new sbyte32(roundtosbyte(x.v16_0, promises), roundtosbyte(x.v16_16, promises));
            }
        }


        /// <summary>       Converts a <see cref="MaxMath.quarter"/> to a <see cref="byte"/> while rounding towards the nearest integer value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte roundtobyte(quarter x, Promise promises = Promise.Nothing)
        {
            return (byte)BASE_cvtf8i32(x, signed: false, trunc: false, nonZero: promises.Promises(Promise.NonZero));
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.quarter2"/> to a <see cref="MaxMath.byte2"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 roundtobyte(quarter2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtpq_epu8(x, elements: 2, nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new byte2(roundtobyte(x.x, promises), roundtobyte(x.y, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.quarter3"/> to a <see cref="MaxMath.byte3"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 roundtobyte(quarter3 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtpq_epu8(x, elements: 3, nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new byte3(roundtobyte(x.x, promises), roundtobyte(x.y, promises), roundtobyte(x.z, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.quarter4"/> to a <see cref="MaxMath.byte4"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 roundtobyte(quarter4 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtpq_epu8(x, elements: 4, nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new byte4(roundtobyte(x.x, promises), roundtobyte(x.y, promises), roundtobyte(x.z, promises), roundtobyte(x.w, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.quarter8"/> to a <see cref="MaxMath.byte8"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 roundtobyte(quarter8 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtpq_epu8(x, elements: 8, nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new byte8(roundtobyte(x.x0, promises), roundtobyte(x.x1, promises), roundtobyte(x.x2, promises), roundtobyte(x.x3, promises), roundtobyte(x.x4, promises), roundtobyte(x.x5, promises), roundtobyte(x.x6, promises), roundtobyte(x.x7, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.quarter16"/> to an <see cref="MaxMath.byte16"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 roundtobyte(quarter16 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtpq_epu8(x, nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new byte16(roundtobyte(x.x0, promises), roundtobyte(x.x1, promises), roundtobyte(x.x2, promises), roundtobyte(x.x3, promises), roundtobyte(x.x4, promises), roundtobyte(x.x5, promises), roundtobyte(x.x6, promises), roundtobyte(x.x7, promises), roundtobyte(x.x8, promises), roundtobyte(x.x9, promises), roundtobyte(x.x10, promises), roundtobyte(x.x11, promises), roundtobyte(x.x12, promises), roundtobyte(x.x13, promises), roundtobyte(x.x14, promises), roundtobyte(x.x15, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.quarter32"/> to an <see cref="MaxMath.byte32"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 roundtobyte(quarter32 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtpq_epu8(x, nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new byte32(roundtobyte(x.v16_0, promises), roundtobyte(x.v16_16, promises));
            }
        }


        /// <summary>       Converts a <see cref="MaxMath.quarter"/> to a <see cref="short"/> while rounding towards the nearest integer value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short roundtoshort(quarter x, Promise promises = Promise.Nothing)
        {
            return (short)BASE_cvtf8i32(x, signed: true, trunc: false, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.quarter2"/> to a <see cref="MaxMath.short2"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 roundtoshort(quarter2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtpq_epi16(x, elements: 2, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new short2(roundtoshort(x.x, promises), roundtoshort(x.y, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.quarter3"/> to a <see cref="MaxMath.short3"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 roundtoshort(quarter3 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtpq_epi16(x, elements: 3, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new short3(roundtoshort(x.x, promises), roundtoshort(x.y, promises), roundtoshort(x.z, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.quarter4"/> to a <see cref="MaxMath.short4"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 roundtoshort(quarter4 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtpq_epi16(x, elements: 4, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new short4(roundtoshort(x.x, promises), roundtoshort(x.y, promises), roundtoshort(x.z, promises), roundtoshort(x.w, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.quarter8"/> to a <see cref="MaxMath.short8"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 roundtoshort(quarter8 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtpq_epi16(x, elements: 8, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new short8(roundtoshort(x.x0, promises), roundtoshort(x.x1, promises), roundtoshort(x.x2, promises), roundtoshort(x.x3, promises), roundtoshort(x.x4, promises), roundtoshort(x.x5, promises), roundtoshort(x.x6, promises), roundtoshort(x.x7, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.quarter16"/> to an <see cref="MaxMath.short16"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 roundtoshort(quarter16 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtpq_epi16(x, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new short16(roundtoshort(x.v8_0, promises), roundtoshort(x.v8_8, promises));
            }
        }


        /// <summary>       Converts a <see cref="MaxMath.quarter"/> to a <see cref="ushort"/> while rounding towards the nearest integer value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort roundtoushort(quarter x, Promise promises = Promise.Nothing)
        {
            return (ushort)BASE_cvtf8i32(x, signed: false, trunc: false, nonZero: promises.Promises(Promise.NonZero));
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.quarter2"/> to a <see cref="MaxMath.ushort2"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 roundtoushort(quarter2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtpq_epu16(x, elements: 2, nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new ushort2(roundtoushort(x.x, promises), roundtoushort(x.y, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.quarter3"/> to a <see cref="MaxMath.ushort3"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 roundtoushort(quarter3 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtpq_epu16(x, elements: 3, nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new ushort3(roundtoushort(x.x, promises), roundtoushort(x.y, promises), roundtoushort(x.z, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.quarter4"/> to a <see cref="MaxMath.ushort4"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 roundtoushort(quarter4 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtpq_epu16(x, elements: 4, nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new ushort4(roundtoushort(x.x, promises), roundtoushort(x.y, promises), roundtoushort(x.z, promises), roundtoushort(x.w, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.quarter8"/> to a <see cref="MaxMath.ushort8"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 roundtoushort(quarter8 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtpq_epu16(x, elements: 8, nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new ushort8(roundtoushort(x.x0, promises), roundtoushort(x.x1, promises), roundtoushort(x.x2, promises), roundtoushort(x.x3, promises), roundtoushort(x.x4, promises), roundtoushort(x.x5, promises), roundtoushort(x.x6, promises), roundtoushort(x.x7, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.quarter16"/> to an <see cref="MaxMath.ushort16"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 roundtoushort(quarter16 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtpq_epu16(x, nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new ushort16(roundtoushort(x.v8_0, promises), roundtoushort(x.v8_8, promises));
            }
        }


        /// <summary>       Converts a <see cref="MaxMath.quarter"/> to an <see cref="int"/> while rounding towards the nearest integer value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int roundtoint(quarter x, Promise promises = Promise.Nothing)
        {
            return (int)BASE_cvtf8i32(x, signed: true, trunc: false, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.quarter2"/> to an <see cref="int2"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 roundtoint(quarter2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt2(Xse.cvtpq_epi32(x, elements: 2, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero)));
            }
            else
            {
                return new int2(roundtoint(x.x, promises), roundtoint(x.y, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.quarter3"/> to an <see cref="int3"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 roundtoint(quarter3 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt3(Xse.cvtpq_epi32(x, elements: 3, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero)));
            }
            else
            {
                return new int3(roundtoint(x.x, promises), roundtoint(x.y, promises), roundtoint(x.z, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.quarter4"/> to an <see cref="int4"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 roundtoint(quarter4 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt4(Xse.cvtpq_epi32(x, elements: 4, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero)));
            }
            else
            {
                return new int4(roundtoint(x.x, promises), roundtoint(x.y, promises), roundtoint(x.z, promises), roundtoint(x.w, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.quarter8"/> to an <see cref="MaxMath.int8"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 roundtoint(quarter8 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtpq_epi32(x, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new int8(roundtoint(x.v4_0, promises), roundtoint(x.v4_4, promises));
            }
        }


        /// <summary>       Converts a <see cref="MaxMath.quarter"/> to a <see cref="uint"/> while rounding towards the nearest integer value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint roundtouint(quarter x, Promise promises = Promise.Nothing)
        {
            return BASE_cvtf8i32(x, signed: false, trunc: false, nonZero: promises.Promises(Promise.NonZero));
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.quarter2"/> to a <see cref="uint2"/> component while rounding towards the nearest respective uinteger value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 roundtouint(quarter2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt2(Xse.cvtpq_epu32(x, elements: 2, nonZero: promises.Promises(Promise.NonZero)));
            }
            else
            {
                return new uint2(roundtouint(x.x, promises), roundtouint(x.y, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.quarter3"/> to a <see cref="uint3"/> component while rounding towards the nearest respective uinteger value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 roundtouint(quarter3 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt3(Xse.cvtpq_epu32(x, elements: 3, nonZero: promises.Promises(Promise.NonZero)));
            }
            else
            {
                return new uint3(roundtouint(x.x, promises), roundtouint(x.y, promises), roundtouint(x.z, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.quarter4"/> to a <see cref="uint4"/> component while rounding towards the nearest respective uinteger value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 roundtouint(quarter4 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt4(Xse.cvtpq_epu32(x, elements: 4, nonZero: promises.Promises(Promise.NonZero)));
            }
            else
            {
                return new uint4(roundtouint(x.x, promises), roundtouint(x.y, promises), roundtouint(x.z, promises), roundtouint(x.w, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.quarter8"/> to a <see cref="MaxMath.uint8"/> component while rounding towards the nearest respective uinteger value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 roundtouint(quarter8 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtpq_epu32(x, nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new uint8(roundtouint(x.v4_0, promises), roundtouint(x.v4_4, promises));
            }
        }


        /// <summary>       Converts a <see cref="MaxMath.quarter"/> to a <see cref="long"/> while rounding towards the nearest integer value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long roundtolong(quarter x, Promise promises = Promise.Nothing)
        {
            return (int)BASE_cvtf8i32(x, signed: true, trunc: false, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.quarter2"/> to a <see cref="MaxMath.long2"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 roundtolong(quarter2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtpq_epi64(x, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new long2(roundtolong(x.x, promises), roundtolong(x.y, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.quarter3"/> to a <see cref="MaxMath.long3"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 roundtolong(quarter3 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtpq_epi64(x, elements: 3, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new long3(roundtolong(x.xy, promises), roundtolong(x.z, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.quarter4"/> to a <see cref="MaxMath.long4"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 roundtolong(quarter4 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtpq_epi64(x, elements: 4, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new long4(roundtolong(x.xy, promises), roundtolong(x.zw, promises));
            }
        }


        /// <summary>       Converts a <see cref="MaxMath.quarter"/> to a <see cref="ulong"/> while rounding towards the nearest integer value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong roundtoulong(quarter x, Promise promises = Promise.Nothing)
        {
            return BASE_cvtf8i32(x, signed: false, trunc: false, nonZero: promises.Promises(Promise.NonZero));
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.quarter2"/> to a <see cref="MaxMath.ulong2"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 roundtoulong(quarter2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtpq_epu64(x, nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new ulong2(roundtoulong(x.x, promises), roundtoulong(x.y, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.quarter3"/> to a <see cref="MaxMath.ulong3"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 roundtoulong(quarter3 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtpq_epu64(x, elements: 3, nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new ulong3(roundtoulong(x.xy, promises), roundtoulong(x.z, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.quarter4"/> to a <see cref="MaxMath.ulong4"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 roundtoulong(quarter4 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtpq_epu64(x, elements: 4, nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new ulong4(roundtoulong(x.xy, promises), roundtoulong(x.zw, promises));
            }
        }


        /// <summary>       Converts a <see cref="MaxMath.quarter"/> to an <see cref="Int128"/> while rounding towards the nearest integer value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 roundtoint128(quarter x, Promise promises = Promise.Nothing)
        {
            return (int)BASE_cvtf8i32(x, signed: true, trunc: false, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
        }


        /// <summary>       Converts a <see cref="MaxMath.quarter"/> to a <see cref="UInt128"/> while rounding towards the nearest integer value.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 roundtouint128(quarter x, Promise promises = Promise.Nothing)
        {
            return BASE_cvtf8i32(x, signed: false, trunc: false);
        }


        /// <summary>       Converts a <see cref="half"/> to an <see cref="sbyte"/> while rounding towards the nearest integer value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte roundtosbyte(half x, Promise promises = Promise.Nothing)
        {
            return (sbyte)BASE_cvtf16i32(x, signed: true, trunc: false, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
        }

        /// <summary>       Converts a each component in a <see cref="half2"/> to an <see cref="MaxMath.sbyte2"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 roundtosbyte(half2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtph_epi8(RegisterConversion.ToV128(x), elements: 2, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new sbyte2(roundtosbyte(x.x, promises), roundtosbyte(x.y, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="half3"/> to an <see cref="MaxMath.sbyte3"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 roundtosbyte(half3 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtph_epi8(RegisterConversion.ToV128(x), elements: 3, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new sbyte3(roundtosbyte(x.x, promises), roundtosbyte(x.y, promises), roundtosbyte(x.z, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="half4"/> to an <see cref="MaxMath.sbyte4"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 roundtosbyte(half4 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtph_epi8(RegisterConversion.ToV128(x), elements: 4, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new sbyte4(roundtosbyte(x.x, promises), roundtosbyte(x.y, promises), roundtosbyte(x.z, promises), roundtosbyte(x.w, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.half8"/> to an <see cref="MaxMath.sbyte8"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 roundtosbyte(half8 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtph_epi8(x, elements: 8, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new sbyte8(roundtosbyte(x.x0, promises), roundtosbyte(x.x1, promises), roundtosbyte(x.x2, promises), roundtosbyte(x.x3, promises), roundtosbyte(x.x4, promises), roundtosbyte(x.x5, promises), roundtosbyte(x.x6, promises), roundtosbyte(x.x7, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.half16"/> to an <see cref="MaxMath.sbyte16"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 roundtosbyte(half16 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtph_epi8(x, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new sbyte16(roundtosbyte(x.v8_0, promises), roundtosbyte(x.v8_8, promises));
            }
        }


        /// <summary>       Converts a <see cref="half"/> to a <see cref="byte"/> while rounding towards the nearest integer value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte roundtobyte(half x, Promise promises = Promise.Nothing)
        {
            return (byte)BASE_cvtf16i32(x, signed: false, trunc: false, nonZero: promises.Promises(Promise.NonZero));
        }

        /// <summary>       Converts a each component in a <see cref="half2"/> to a <see cref="MaxMath.byte2"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 roundtobyte(half2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtph_epu8(RegisterConversion.ToV128(x), elements: 2, nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new byte2(roundtobyte(x.x, promises), roundtobyte(x.y, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="half3"/> to a <see cref="MaxMath.byte3"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 roundtobyte(half3 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtph_epu8(RegisterConversion.ToV128(x), elements: 3, nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new byte3(roundtobyte(x.x, promises), roundtobyte(x.y, promises), roundtobyte(x.z, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="half4"/> to a <see cref="MaxMath.byte4"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 roundtobyte(half4 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtph_epu8(RegisterConversion.ToV128(x), elements: 4, nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new byte4(roundtobyte(x.x, promises), roundtobyte(x.y, promises), roundtobyte(x.z, promises), roundtobyte(x.w, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.half8"/> to a <see cref="MaxMath.byte8"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 roundtobyte(half8 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtph_epu8(x, elements: 8, nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new byte8(roundtobyte(x.x0, promises), roundtobyte(x.x1, promises), roundtobyte(x.x2, promises), roundtobyte(x.x3, promises), roundtobyte(x.x4, promises), roundtobyte(x.x5, promises), roundtobyte(x.x6, promises), roundtobyte(x.x7, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.half16"/> to an <see cref="MaxMath.byte16"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 roundtobyte(half16 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtph_epu8(x, nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new byte16(roundtobyte(x.v8_0, promises), roundtobyte(x.v8_8, promises));
            }
        }


        /// <summary>       Converts a <see cref="half"/> to a <see cref="short"/> while rounding towards the nearest integer value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short roundtoshort(half x, Promise promises = Promise.Nothing)
        {
            return (short)BASE_cvtf16i32(x, signed: true, trunc: false, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
        }

        /// <summary>       Converts a each component in a <see cref="half2"/> to a <see cref="MaxMath.short2"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 roundtoshort(half2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtph_epi16(RegisterConversion.ToV128(x), elements: 2, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new short2(roundtoshort(x.x, promises), roundtoshort(x.y, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="half3"/> to a <see cref="MaxMath.short3"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 roundtoshort(half3 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtph_epi16(RegisterConversion.ToV128(x), elements: 3, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new short3(roundtoshort(x.x, promises), roundtoshort(x.y, promises), roundtoshort(x.z, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="half4"/> to a <see cref="MaxMath.short4"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 roundtoshort(half4 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtph_epi16(RegisterConversion.ToV128(x), elements: 4, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new short4(roundtoshort(x.x, promises), roundtoshort(x.y, promises), roundtoshort(x.z, promises), roundtoshort(x.w, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.half8"/> to a <see cref="MaxMath.short8"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 roundtoshort(half8 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtph_epi16(x, elements: 8, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new short8(roundtoshort(x.x0, promises), roundtoshort(x.x1, promises), roundtoshort(x.x2, promises), roundtoshort(x.x3, promises), roundtoshort(x.x4, promises), roundtoshort(x.x5, promises), roundtoshort(x.x6, promises), roundtoshort(x.x7, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.half16"/> to a <see cref="MaxMath.short16"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 roundtoshort(half16 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtph_epi16(x, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new short16(roundtoshort(x.v8_0, promises), roundtoshort(x.v8_8, promises));
            }
        }


        /// <summary>       Converts a <see cref="half"/> to a <see cref="ushort"/> while rounding towards the nearest integer value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort roundtoushort(half x, Promise promises = Promise.Nothing)
        {
            return (ushort)BASE_cvtf16i32(x, signed: false, trunc: false, nonZero: promises.Promises(Promise.NonZero));
        }

        /// <summary>       Converts a each component in a <see cref="half2"/> to a <see cref="MaxMath.ushort2"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 roundtoushort(half2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtph_epu16(RegisterConversion.ToV128(x), elements: 2, nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new ushort2(roundtoushort(x.x, promises), roundtoushort(x.y, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="half3"/> to a <see cref="MaxMath.ushort3"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 roundtoushort(half3 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtph_epu16(RegisterConversion.ToV128(x), elements: 3, nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new ushort3(roundtoushort(x.x, promises), roundtoushort(x.y, promises), roundtoushort(x.z, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="half4"/> to a <see cref="MaxMath.ushort4"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 roundtoushort(half4 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtph_epu16(RegisterConversion.ToV128(x), elements: 4, nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new ushort4(roundtoushort(x.x, promises), roundtoushort(x.y, promises), roundtoushort(x.z, promises), roundtoushort(x.w, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.half8"/> to a <see cref="MaxMath.ushort8"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 roundtoushort(half8 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtph_epu16(x, elements: 8, nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new ushort8(roundtoushort(x.x0, promises), roundtoushort(x.x1, promises), roundtoushort(x.x2, promises), roundtoushort(x.x3, promises), roundtoushort(x.x4, promises), roundtoushort(x.x5, promises), roundtoushort(x.x6, promises), roundtoushort(x.x7, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.half16"/> to a <see cref="MaxMath.ushort16"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 roundtoushort(half16 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtph_epu16(x, nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new ushort16(roundtoushort(x.v8_0, promises), roundtoushort(x.v8_8, promises));
            }
        }


        /// <summary>       Converts a <see cref="half"/> to an <see cref="int"/> while rounding towards the nearest integer value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int roundtoint(half x, Promise promises = Promise.Nothing)
        {
            return (int)BASE_cvtf16i32(x, signed: true, trunc: false, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
        }

        /// <summary>       Converts a each component in a <see cref="half2"/> to an <see cref="int2"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 roundtoint(half2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt2(Xse.cvtph_epi32(RegisterConversion.ToV128(x), elements: 2, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero)));
            }
            else
            {
                return new int2(roundtoint(x.x, promises), roundtoint(x.y, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="half3"/> to an <see cref="int3"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 roundtoint(half3 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt3(Xse.cvtph_epi32(RegisterConversion.ToV128(x), elements: 3, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero)));
            }
            else
            {
                return new int3(roundtoint(x.x, promises), roundtoint(x.y, promises), roundtoint(x.z, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="half4"/> to an <see cref="int4"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 roundtoint(half4 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt4(Xse.cvtph_epi32(RegisterConversion.ToV128(x), elements: 4, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero)));
            }
            else
            {
                return new int4(roundtoint(x.x, promises), roundtoint(x.y, promises), roundtoint(x.z, promises), roundtoint(x.w, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.half8"/> to an <see cref="MaxMath.int8"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 roundtoint(half8 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtph_epi32(x, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new int8(roundtoint(x.v4_0, promises), roundtoint(x.v4_4, promises));
            }
        }


        /// <summary>       Converts a <see cref="half"/> to a <see cref="uint"/> while rounding towards the nearest integer value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint roundtouint(half x, Promise promises = Promise.Nothing)
        {
            return BASE_cvtf16i32(x, signed: false, trunc: false, nonZero: promises.Promises(Promise.NonZero));
        }

        /// <summary>       Converts a each component in a <see cref="half2"/> to a <see cref="uint2"/> component while rounding towards the nearest respective uinteger value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 roundtouint(half2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt2(Xse.cvtph_epu32(RegisterConversion.ToV128(x), elements: 2, nonZero: promises.Promises(Promise.NonZero)));
            }
            else
            {
                return new uint2(roundtouint(x.x, promises), roundtouint(x.y, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="half3"/> to a <see cref="uint3"/> component while rounding towards the nearest respective uinteger value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 roundtouint(half3 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt3(Xse.cvtph_epu32(RegisterConversion.ToV128(x), elements: 3, nonZero: promises.Promises(Promise.NonZero)));
            }
            else
            {
                return new uint3(roundtouint(x.x, promises), roundtouint(x.y, promises), roundtouint(x.z, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="half4"/> to a <see cref="uint4"/> component while rounding towards the nearest respective uinteger value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 roundtouint(half4 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt4(Xse.cvtph_epu32(RegisterConversion.ToV128(x), elements: 4, nonZero: promises.Promises(Promise.NonZero)));
            }
            else
            {
                return new uint4(roundtouint(x.x, promises), roundtouint(x.y, promises), roundtouint(x.z, promises), roundtouint(x.w, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.half8"/> to a <see cref="MaxMath.uint8"/> component while rounding towards the nearest respective uinteger value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 roundtouint(half8 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtph_epu32(x, nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new uint8(roundtouint(x.v4_0, promises), roundtouint(x.v4_4, promises));
            }
        }


        /// <summary>       Converts a <see cref="half"/> to a <see cref="long"/> while rounding towards the nearest integer value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long roundtolong(half x, Promise promises = Promise.Nothing)
        {
            return (int)BASE_cvtf16i32(x, signed: true, trunc: false, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
        }

        /// <summary>       Converts a each component in a <see cref="half2"/> to a <see cref="MaxMath.long2"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 roundtolong(half2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtph_epi64(RegisterConversion.ToV128(x), positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new long2(roundtolong(x.x, promises), roundtolong(x.y, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="half3"/> to a <see cref="MaxMath.long3"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 roundtolong(half3 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtph_epi64(RegisterConversion.ToV128(x), elements: 3, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new long3(roundtolong(x.xy, promises), roundtolong(x.z, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="half4"/> to a <see cref="MaxMath.long4"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 roundtolong(half4 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtph_epi64(RegisterConversion.ToV128(x), elements: 4, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new long4(roundtolong(x.xy, promises), roundtolong(x.zw, promises));
            }
        }


        /// <summary>       Converts a <see cref="half"/> to a <see cref="ulong"/> while rounding towards the nearest integer value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong roundtoulong(half x, Promise promises = Promise.Nothing)
        {
            return BASE_cvtf16i32(x, signed: false, trunc: false, nonZero: promises.Promises(Promise.NonZero));
        }

        /// <summary>       Converts a each component in a <see cref="half2"/> to a <see cref="MaxMath.ulong2"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 roundtoulong(half2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtph_epu64(RegisterConversion.ToV128(x), nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new ulong2(roundtoulong(x.x, promises), roundtoulong(x.y, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="half3"/> to a <see cref="MaxMath.ulong3"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 roundtoulong(half3 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtph_epu64(RegisterConversion.ToV128(x), elements: 3, nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new ulong3(roundtoulong(x.xy, promises), roundtoulong(x.z, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="half4"/> to a <see cref="MaxMath.ulong4"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 roundtoulong(half4 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtph_epu64(RegisterConversion.ToV128(x), elements: 4, nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new ulong4(roundtoulong(x.xy, promises), roundtoulong(x.zw, promises));
            }
        }


        /// <summary>       Converts a <see cref="half"/> to an <see cref="Int128"/> while rounding towards the nearest integer value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 roundtoint128(half x, Promise promises = Promise.Nothing)
        {
            return (int)BASE_cvtf16i32(x, signed: true, trunc: false, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
        }


        /// <summary>       Converts a <see cref="half"/> to a <see cref="UInt128"/> while rounding towards the nearest integer value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 roundtouint128(half x, Promise promises = Promise.Nothing)
        {
            return BASE_cvtf16i32(x, signed: false, trunc: false, nonZero: promises.Promises(Promise.NonZero));
        }


        /// <summary>       Converts a <see cref="float"/> to an <see cref="sbyte"/> while rounding towards the nearest integer value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte roundtosbyte(float x, Promise promises = Promise.Nothing)
        {
            return (sbyte)BASE_cvtf32i32(x, signed: true, trunc: false, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
        }

        /// <summary>       Converts a each component in a <see cref="float2"/> to an <see cref="MaxMath.sbyte2"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 roundtosbyte(float2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtps_epi8(RegisterConversion.ToV128(x));
            }
            else
            {
                return new sbyte2(roundtosbyte(x.x, promises), roundtosbyte(x.y, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="float3"/> to an <see cref="MaxMath.sbyte3"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 roundtosbyte(float3 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtps_epi8(RegisterConversion.ToV128(x));
            }
            else
            {
                return new sbyte3(roundtosbyte(x.x, promises), roundtosbyte(x.y, promises), roundtosbyte(x.z, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="float4"/> to an <see cref="MaxMath.sbyte4"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 roundtosbyte(float4 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtps_epi8(RegisterConversion.ToV128(x));
            }
            else
            {
                return new sbyte4(roundtosbyte(x.x, promises), roundtosbyte(x.y, promises), roundtosbyte(x.z, promises), roundtosbyte(x.w, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.float8"/> to an <see cref="MaxMath.sbyte8"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 roundtosbyte(float8 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtps_epi8(x);
            }
            else
            {
                return new sbyte8(roundtosbyte(x.v4_0, promises), roundtosbyte(x.v4_4, promises));
            }
        }


        /// <summary>       Converts a <see cref="float"/> to a <see cref="byte"/> while rounding towards the nearest integer value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte roundtobyte(float x, Promise promises = Promise.Nothing)
        {
            return (byte)BASE_cvtf32i32(x, signed: false, trunc: false, nonZero: promises.Promises(Promise.NonZero));
        }

        /// <summary>       Converts a each component in a <see cref="float2"/> to a <see cref="MaxMath.byte2"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 roundtobyte(float2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtps_epu8(RegisterConversion.ToV128(x));
            }
            else
            {
                return new byte2(roundtobyte(x.x, promises), roundtobyte(x.y, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="float3"/> to a <see cref="MaxMath.byte3"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 roundtobyte(float3 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtps_epu8(RegisterConversion.ToV128(x));
            }
            else
            {
                return new byte3(roundtobyte(x.x, promises), roundtobyte(x.y, promises), roundtobyte(x.z, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="float4"/> to a <see cref="MaxMath.byte4"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 roundtobyte(float4 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtps_epu8(RegisterConversion.ToV128(x));
            }
            else
            {
                return new byte4(roundtobyte(x.x, promises), roundtobyte(x.y, promises), roundtobyte(x.z, promises), roundtobyte(x.w, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.float8"/> to a <see cref="MaxMath.byte8"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 roundtobyte(float8 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtps_epu8(x);
            }
            else
            {
                return new byte8(roundtobyte(x.v4_0, promises), roundtobyte(x.v4_4, promises));
            }
        }


        /// <summary>       Converts a <see cref="float"/> to a <see cref="short"/> while rounding towards the nearest integer value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short roundtoshort(float x, Promise promises = Promise.Nothing)
        {
            return (short)BASE_cvtf32i32(x, signed: true, trunc: false, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
        }

        /// <summary>       Converts a each component in a <see cref="float2"/> to a <see cref="MaxMath.short2"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 roundtoshort(float2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtps_epi16(RegisterConversion.ToV128(x));
            }
            else
            {
                return new short2(roundtoshort(x.x, promises), roundtoshort(x.y, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="float3"/> to a <see cref="MaxMath.short3"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 roundtoshort(float3 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtps_epi16(RegisterConversion.ToV128(x));
            }
            else
            {
                return new short3(roundtoshort(x.x, promises), roundtoshort(x.y, promises), roundtoshort(x.z, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="float4"/> to a <see cref="MaxMath.short4"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 roundtoshort(float4 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtps_epi16(RegisterConversion.ToV128(x));
            }
            else
            {
                return new short4(roundtoshort(x.x, promises), roundtoshort(x.y, promises), roundtoshort(x.z, promises), roundtoshort(x.w, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.float8"/> to a <see cref="MaxMath.short8"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 roundtoshort(float8 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtps_epi16(x);
            }
            else
            {
                return new short8(roundtoshort(x.v4_0, promises), roundtoshort(x.v4_4, promises));
            }
        }


        /// <summary>       Converts a <see cref="float"/> to a <see cref="ushort"/> while rounding towards the nearest integer value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort roundtoushort(float x, Promise promises = Promise.Nothing)
        {
            return (ushort)BASE_cvtf32i32(x, signed: false, trunc: false, nonZero: promises.Promises(Promise.NonZero));
        }

        /// <summary>       Converts a each component in a <see cref="float2"/> to a <see cref="MaxMath.ushort2"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 roundtoushort(float2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtps_epu16(RegisterConversion.ToV128(x));
            }
            else
            {
                return new ushort2(roundtoushort(x.x, promises), roundtoushort(x.y, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="float3"/> to a <see cref="MaxMath.ushort3"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 roundtoushort(float3 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtps_epu16(RegisterConversion.ToV128(x));
            }
            else
            {
                return new ushort3(roundtoushort(x.x, promises), roundtoushort(x.y, promises), roundtoushort(x.z, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="float4"/> to a <see cref="MaxMath.ushort4"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 roundtoushort(float4 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtps_epu16(RegisterConversion.ToV128(x));
            }
            else
            {
                return new ushort4(roundtoushort(x.x, promises), roundtoushort(x.y, promises), roundtoushort(x.z, promises), roundtoushort(x.w, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.float8"/> to a <see cref="MaxMath.ushort8"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 roundtoushort(float8 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtps_epu16(x);
            }
            else
            {
                return new ushort8(roundtoushort(x.v4_0, promises), roundtoushort(x.v4_4, promises));
            }
        }


        /// <summary>       Converts a <see cref="float"/> to an <see cref="int"/> while rounding towards the nearest integer value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int roundtoint(float x, Promise promises = Promise.Nothing)
        {
            return (int)BASE_cvtf32i32(x, signed: true, trunc: false, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
        }

        /// <summary>       Converts a each component in a <see cref="float2"/> to an <see cref="int2"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 roundtoint(float2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt2(Xse.cvtps_epi32(RegisterConversion.ToV128(x)));
            }
            else
            {
                return new int2(roundtoint(x.x, promises), roundtoint(x.y, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="float3"/> to an <see cref="int3"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 roundtoint(float3 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt3(Xse.cvtps_epi32(RegisterConversion.ToV128(x)));
            }
            else
            {
                return new int3(roundtoint(x.x, promises), roundtoint(x.y, promises), roundtoint(x.z, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="float4"/> to an <see cref="int4"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 roundtoint(float4 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt4(Xse.cvtps_epi32(RegisterConversion.ToV128(x)));
            }
            else
            {
                return new int4(roundtoint(x.x, promises), roundtoint(x.y, promises), roundtoint(x.z, promises), roundtoint(x.w, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.float8"/> to an <see cref="MaxMath.int8"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 roundtoint(float8 x, Promise promises = Promise.Nothing)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_cvtps_epi32(x);
            }
            else
            {
                return new int8(roundtoint(x.v4_0, promises), roundtoint(x.v4_4, promises));
            }
        }


        /// <summary>       Converts a <see cref="float"/> to a <see cref="uint"/> while rounding towards the nearest integer value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint roundtouint(float x, Promise promises = Promise.Nothing)
        {
            return BASE_cvtf32i32(x, signed: false, trunc: false, nonZero: promises.Promises(Promise.NonZero));
        }

        /// <summary>       Converts a each component in a <see cref="float2"/> to a <see cref="uint2"/> component while rounding towards the nearest respective uinteger value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 roundtouint(float2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt2(Xse.cvtps_epu32(RegisterConversion.ToV128(x), elements: 2, nonZero: promises.Promises(Promise.NonZero)));
            }
            else
            {
                return new uint2(roundtouint(x.x, promises), roundtouint(x.y, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="float3"/> to a <see cref="uint3"/> component while rounding towards the nearest respective uinteger value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 roundtouint(float3 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt3(Xse.cvtps_epu32(RegisterConversion.ToV128(x), elements: 3, nonZero: promises.Promises(Promise.NonZero)));
            }
            else
            {
                return new uint3(roundtouint(x.x, promises), roundtouint(x.y, promises), roundtouint(x.z, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="float4"/> to a <see cref="uint4"/> component while rounding towards the nearest respective uinteger value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 roundtouint(float4 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt4(Xse.cvtps_epu32(RegisterConversion.ToV128(x), elements: 4, nonZero: promises.Promises(Promise.NonZero)));
            }
            else
            {
                return new uint4(roundtouint(x.x, promises), roundtouint(x.y, promises), roundtouint(x.z, promises), roundtouint(x.w, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="MaxMath.float8"/> to a <see cref="MaxMath.uint8"/> component while rounding towards the nearest respective uinteger value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 roundtouint(float8 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtps_epu32(x, nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new uint8(roundtouint(x.v4_0, promises), roundtouint(x.v4_4, promises));
            }
        }


        /// <summary>       Converts a <see cref="float"/> to a <see cref="long"/> while rounding towards the nearest integer value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long roundtolong(float x, Promise promises = Promise.Nothing)
        {
            return (long)BASE_cvtf32i64(x, signed: true, trunc: false, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
        }

        /// <summary>       Converts a each component in a <see cref="float2"/> to a <see cref="MaxMath.long2"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 roundtolong(float2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtps_epi64(RegisterConversion.ToV128(x), positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new long2(roundtolong(x.x, promises), roundtolong(x.y, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="float3"/> to a <see cref="MaxMath.long3"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 roundtolong(float3 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtps_epi64(RegisterConversion.ToV128(x), elements: 3, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new long3(roundtolong(x.xy, promises), roundtolong(x.z, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="float4"/> to a <see cref="MaxMath.long4"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 roundtolong(float4 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtps_epi64(RegisterConversion.ToV128(x), elements: 4, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new long4(roundtolong(x.xy, promises), roundtolong(x.zw, promises));
            }
        }


        /// <summary>       Converts a <see cref="float"/> to a <see cref="ulong"/> while rounding towards the nearest integer value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong roundtoulong(float x, Promise promises = Promise.Nothing)
        {
            return BASE_cvtf32i64(x, signed: false, trunc: false, nonZero: promises.Promises(Promise.NonZero));
        }

        /// <summary>       Converts a each component in a <see cref="float2"/> to a <see cref="MaxMath.ulong2"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 roundtoulong(float2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtps_epu64(RegisterConversion.ToV128(x), nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new ulong2(roundtoulong(x.x, promises), roundtoulong(x.y, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="float3"/> to a <see cref="MaxMath.ulong3"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 roundtoulong(float3 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtps_epu64(RegisterConversion.ToV128(x), elements: 3, nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new ulong3(roundtoulong(x.xy, promises), roundtoulong(x.z, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="float4"/> to a <see cref="MaxMath.ulong4"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 roundtoulong(float4 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtps_epu64(RegisterConversion.ToV128(x), elements: 4, nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new ulong4(roundtoulong(x.xy, promises), roundtoulong(x.zw, promises));
            }
        }


        /// <summary>       Converts a <see cref="float"/> to an <see cref="Int128"/> while rounding towards the nearest integer value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 roundtoint128(float x, Promise promises = Promise.Nothing)
        {
            return (Int128)BASE_cvtf32i128(x, signed: true, trunc: false, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
        }


        /// <summary>       Converts a <see cref="float"/> to a <see cref="UInt128"/> while rounding towards the nearest integer value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 roundtouint128(float x, Promise promises = Promise.Nothing)
        {
            return BASE_cvtf32i128(x, signed: false, trunc: false, nonZero: promises.Promises(Promise.NonZero));
        }


        /// <summary>       Converts a <see cref="double"/> to an <see cref="sbyte"/> while rounding towards the nearest integer value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte roundtosbyte(double x, Promise promises = Promise.Nothing)
        {
            return (sbyte)BASE_cvtf64i64(x, signed: true, trunc: false, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
        }

        /// <summary>       Converts a each component in a <see cref="double2"/> to an <see cref="MaxMath.sbyte2"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 roundtosbyte(double2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtpd_epi8(RegisterConversion.ToV128(x));
            }
            else
            {
                return new sbyte2(roundtosbyte(x.x, promises), roundtosbyte(x.y, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="double3"/> to an <see cref="MaxMath.sbyte3"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 roundtosbyte(double3 x, Promise promises = Promise.Nothing)
        {
            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_cvtpd_epi8(RegisterConversion.ToV256(x));
            }
            else
            {
                return new sbyte3(roundtosbyte(x.xy, promises), roundtosbyte(x.z, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="double4"/> to an <see cref="MaxMath.sbyte4"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 roundtosbyte(double4 x, Promise promises = Promise.Nothing)
        {
            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_cvtpd_epi8(RegisterConversion.ToV256(x));
            }
            else
            {
                return new sbyte4(roundtosbyte(x.xy, promises), roundtosbyte(x.zw, promises));
            }
        }


        /// <summary>       Converts a <see cref="double"/> to a <see cref="byte"/> while rounding towards the nearest integer value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte roundtobyte(double x, Promise promises = Promise.Nothing)
        {
            return (byte)BASE_cvtf64i64(x, signed: false, trunc: false, nonZero: promises.Promises(Promise.NonZero));
        }

        /// <summary>       Converts a each component in a <see cref="double2"/> to a <see cref="MaxMath.byte2"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 roundtobyte(double2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtpd_epu8(RegisterConversion.ToV128(x));
            }
            else
            {
                return new byte2(roundtobyte(x.x, promises), roundtobyte(x.y, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="double3"/> to a <see cref="MaxMath.byte3"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 roundtobyte(double3 x, Promise promises = Promise.Nothing)
        {
            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_cvtpd_epu8(RegisterConversion.ToV256(x));
            }
            else
            {
                return new byte3(roundtobyte(x.xy, promises), roundtobyte(x.z, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="double4"/> to a <see cref="MaxMath.byte4"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 roundtobyte(double4 x, Promise promises = Promise.Nothing)
        {
            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_cvtpd_epu8(RegisterConversion.ToV256(x));
            }
            else
            {
                return new byte4(roundtobyte(x.xy, promises), roundtobyte(x.zw, promises));
            }
        }


        /// <summary>       Converts a <see cref="double"/> to a <see cref="short"/> while rounding towards the nearest integer value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short roundtoshort(double x, Promise promises = Promise.Nothing)
        {
            return (short)BASE_cvtf64i64(x, signed: true, trunc: false, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
        }

        /// <summary>       Converts a each component in a <see cref="double2"/> to a <see cref="MaxMath.short2"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 roundtoshort(double2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtpd_epi16(RegisterConversion.ToV128(x));
            }
            else
            {
                return new short2(roundtoshort(x.x, promises), roundtoshort(x.y, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="double3"/> to a <see cref="MaxMath.short3"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 roundtoshort(double3 x, Promise promises = Promise.Nothing)
        {
            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_cvtpd_epi16(RegisterConversion.ToV256(x));
            }
            else
            {
                return new short3(roundtoshort(x.xy, promises), roundtoshort(x.z, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="double4"/> to a <see cref="MaxMath.short4"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 roundtoshort(double4 x, Promise promises = Promise.Nothing)
        {
            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_cvtpd_epi16(RegisterConversion.ToV256(x));
            }
            else
            {
                return new short4(roundtoshort(x.xy, promises), roundtoshort(x.zw, promises));
            }
        }


        /// <summary>       Converts a <see cref="double"/> to a <see cref="ushort"/> while rounding towards the nearest integer value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort roundtoushort(double x, Promise promises = Promise.Nothing)
        {
            return (ushort)BASE_cvtf64i64(x, signed: false, trunc: false, nonZero: promises.Promises(Promise.NonZero));
        }

        /// <summary>       Converts a each component in a <see cref="double2"/> to a <see cref="MaxMath.ushort2"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 roundtoushort(double2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtpd_epu16(RegisterConversion.ToV128(x));
            }
            else
            {
                return new ushort2(roundtoushort(x.x, promises), roundtoushort(x.y, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="double3"/> to a <see cref="MaxMath.ushort3"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 roundtoushort(double3 x, Promise promises = Promise.Nothing)
        {
            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_cvtpd_epu16(RegisterConversion.ToV256(x));
            }
            else
            {
                return new ushort3(roundtoushort(x.xy, promises), roundtoushort(x.z, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="double4"/> to a <see cref="MaxMath.ushort4"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 roundtoushort(double4 x, Promise promises = Promise.Nothing)
        {
            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_cvtpd_epu16(RegisterConversion.ToV256(x));
            }
            else
            {
                return new ushort4(roundtoushort(x.xy, promises), roundtoushort(x.zw, promises));
            }
        }


        /// <summary>       Converts a <see cref="double"/> to an <see cref="int"/> while rounding towards the nearest integer value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int roundtoint(double x, Promise promises = Promise.Nothing)
        {
            return (int)BASE_cvtf64i64(x, signed: true, trunc: false, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
        }

        /// <summary>       Converts a each component in a <see cref="double2"/> to an <see cref="int2"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 roundtoint(double2 x, Promise promises = Promise.Nothing)
        {
            if (Avx.IsAvxSupported)
            {
                return RegisterConversion.ToInt2(Xse.cvtpd_epi32(RegisterConversion.ToV128(x)));
            }
            else
            {
                return new int2(roundtoint(x.x, promises), roundtoint(x.y, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="double3"/> to an <see cref="int3"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 roundtoint(double3 x, Promise promises = Promise.Nothing)
        {
            if (Avx.IsAvxSupported)
            {
                return RegisterConversion.ToInt3(Avx.mm256_cvtpd_epi32(RegisterConversion.ToV256(x)));
            }
            else
            {
                return new int3(roundtoint(x.xy, promises), roundtoint(x.z, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="double4"/> to an <see cref="int4"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 roundtoint(double4 x, Promise promises = Promise.Nothing)
        {
            if (Avx.IsAvxSupported)
            {
                return RegisterConversion.ToInt4(Avx.mm256_cvtpd_epi32(RegisterConversion.ToV256(x)));
            }
            else
            {
                return new int4(roundtoint(x.xy, promises), roundtoint(x.zw, promises));
            }
        }


        /// <summary>       Converts a <see cref="double"/> to a <see cref="uint"/> while rounding towards the nearest integer value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint roundtouint(double x, Promise promises = Promise.Nothing)
        {
            return (uint)BASE_cvtf64i64(x, signed: false, trunc: false, nonZero: promises.Promises(Promise.NonZero));
        }

        /// <summary>       Converts a each component in a <see cref="double2"/> to a <see cref="uint2"/> component while rounding towards the nearest respective uinteger value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 roundtouint(double2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt2(Xse.cvtpd_epu32(RegisterConversion.ToV128(x), nonZero: promises.Promises(Promise.NonZero)));
            }
            else
            {
                return new uint2(roundtouint(x.x, promises), roundtouint(x.y, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="double3"/> to a <see cref="uint3"/> component while rounding towards the nearest respective uinteger value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 roundtouint(double3 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.ToUInt3(Xse.mm256_cvtpd_epu32(RegisterConversion.ToV256(x), elements: 3, nonZero: promises.Promises(Promise.NonZero)));
            }
            else
            {
                return new uint3(roundtouint(x.xy, promises), roundtouint(x.z, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="double4"/> to a <see cref="uint4"/> component while rounding towards the nearest respective uinteger value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 roundtouint(double4 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.ToUInt4(Xse.mm256_cvtpd_epu32(RegisterConversion.ToV256(x), elements: 4, nonZero: promises.Promises(Promise.NonZero)));
            }
            else
            {
                return new uint4(roundtouint(x.xy, promises), roundtouint(x.zw, promises));
            }
        }


        /// <summary>       Converts a <see cref="double"/> to a <see cref="long"/> while rounding towards the nearest integer value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long roundtolong(double x, Promise promises = Promise.Nothing)
        {
            return (long)BASE_cvtf64i64(x, signed: true, trunc: false, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
        }

        /// <summary>       Converts a each component in a <see cref="double2"/> to a <see cref="MaxMath.long2"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 roundtolong(double2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtpd_epi64(RegisterConversion.ToV128(x), positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new long2(roundtolong(x.x, promises), roundtolong(x.y, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="double3"/> to a <see cref="MaxMath.long3"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 roundtolong(double3 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtpd_epi64(RegisterConversion.ToV256(x), elements: 3, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new long3(roundtolong(x.xy, promises), roundtolong(x.z, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="double4"/> to a <see cref="MaxMath.long4"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 roundtolong(double4 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtpd_epi64(RegisterConversion.ToV256(x), elements: 4, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new long4(roundtolong(x.xy, promises), roundtolong(x.zw, promises));
            }
        }


        /// <summary>       Converts a <see cref="double"/> to a <see cref="ulong"/> while rounding towards the nearest integer value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong roundtoulong(double x, Promise promises = Promise.Nothing)
        {
            return BASE_cvtf64i64(x, signed: false, trunc: false, nonZero: promises.Promises(Promise.NonZero));
        }

        /// <summary>       Converts a each component in a <see cref="double2"/> to a <see cref="MaxMath.ulong2"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 roundtoulong(double2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtpd_epu64(RegisterConversion.ToV128(x), nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new ulong2(roundtoulong(x.x, promises), roundtoulong(x.y, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="double3"/> to a <see cref="MaxMath.ulong3"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 roundtoulong(double3 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtpd_epu64(RegisterConversion.ToV256(x), elements: 3, nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new ulong3(roundtoulong(x.xy, promises), roundtoulong(x.z, promises));
            }
        }

        /// <summary>       Converts a each component in a <see cref="double4"/> to a <see cref="MaxMath.ulong4"/> component while rounding towards the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 roundtoulong(double4 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtpd_epu64(RegisterConversion.ToV256(x), elements: 4, nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new ulong4(roundtoulong(x.xy, promises), roundtoulong(x.zw, promises));
            }
        }


        /// <summary>       Converts a <see cref="double"/> to an <see cref="Int128"/> while rounding towards the nearest integer value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 roundtoint128(double x, Promise promises = Promise.Nothing)
        {
            return (Int128)BASE_cvtf64i128(x, signed: true, trunc: false, positive: promises.Promises(Promise.Positive), nonZero: promises.Promises(Promise.NonZero));
        }


        /// <summary>       Converts a <see cref="double"/> to a <see cref="UInt128"/> while rounding towards the nearest integer value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 roundtouint128(double x, Promise promises = Promise.Nothing)
        {
            return BASE_cvtf64i128(x, signed: false, trunc: false, nonZero: promises.Promises(Promise.NonZero));
        }
    }
}
