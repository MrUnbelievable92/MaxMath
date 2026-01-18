#define EVEN_ON_TIE

using System;
using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Burst.CompilerServices;
using Unity.Mathematics;
using MaxMath.Intrinsics;
using DevTools;

using static Unity.Mathematics.math;
using static MaxMath.maxmath;
using static MaxMath.LUT.FLOATING_POINT;

namespace MaxMath
{
    /// <summary>       A 128-bit 1.15.112.-16383 IEEE 754 floating point number.       </summary>
    [Serializable]
    unsafe public readonly partial struct quadruple : IComparable, IComparable<quadruple>, IConvertible, IEquatable<quadruple>, IFormattable
    {
        internal const bool IEEE_754_STANDARD = true;                                                                                                    //standard: true
        internal const bool SIGN_BIT = IEEE_754_STANDARD || true;                                                                                        //standard: true
        internal const bool SIGNALING_NAN = false;                                                                                                       //standard: false
        internal const int BITS = 2 * 8 * sizeof(ulong);                                                                                                 //standard: 128
        internal const int SET_SIGN_BIT = (SIGN_BIT ? 1 : 0) << (BITS - 1);                                                                              //standard: 1 << 127
        internal const int EXPONENT_BITS = 15 + (SIGN_BIT ? 0 : 1);                                                                                      //standard: 15
        internal const int MANTISSA_BITS = BITS - EXPONENT_BITS - (SIGN_BIT ? 1 : 0);                                                                    //standard: 112
        internal const int MANTISSA_BITS_HI64 = MANTISSA_BITS - 8 * sizeof(ulong);                                                                       //standard: 48
        internal const int EXPONENT_BIAS = -((1 << (EXPONENT_BITS - 1)) - 1);                                                                            //standard: -16383
        internal const int MAX_UNBIASED_EXPONENT = -EXPONENT_BIAS;                                                                                       //standard: 16383
        internal const int MIN_UNBIASED_EXPONENT = EXPONENT_BIAS + 1;                                                                                    //standard: -16382
        internal static UInt128 SIGNALING_EXPONENT => (UInt128)(MAX_UNBIASED_EXPONENT - EXPONENT_BIAS + (IEEE_754_STANDARD ? 1 : 0)) << MANTISSA_BITS;   //standard: 0x7FFF << 112

        internal const int F8_EXPONENT_OFFSET = -EXPONENT_BIAS + quarter.EXPONENT_BIAS;
        internal const int F16_EXPONENT_OFFSET = -EXPONENT_BIAS + F16_EXPONENT_BIAS;
        internal const int F32_EXPONENT_OFFSET = -EXPONENT_BIAS + F32_EXPONENT_BIAS;
        internal const int F64_EXPONENT_OFFSET = -EXPONENT_BIAS + F64_EXPONENT_BIAS;


        #region CONSTANTS
        public static quadruple Epsilon => new quadruple(1, 0);
        public static quadruple MaxValue => new quadruple(SIGNALING_EXPONENT - 1);
        public static quadruple MinValue => -MaxValue;
        public static quadruple Zero => new quadruple(0);
        public static quadruple NaN => new quadruple(SIGNALING_EXPONENT | 1);
        public static quadruple PositiveInfinity => new quadruple(SIGNALING_EXPONENT);
        public static quadruple NegativeInfinity => -PositiveInfinity;
        #endregion


        public readonly UInt128 value;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal quadruple(UInt128 bits)
        {
            value = bits;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal quadruple(ulong lo64, ulong hi64)
        {
            value = new UInt128(lo64, hi64);
        }



        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool NoZeroSignBitConst(quadruple.ConstChecked x)
        {
            return x.Promise.NoSignedZero ? x.Promise.ZeroOrGreater
                                          : x.Promise.Positive;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool EqualSignBitsLo(quadruple.ConstChecked x, quadruple.ConstChecked y)
        {
            return (NoZeroSignBitConst(x) && NoZeroSignBitConst(y))
                || (x.Promise.Negative && y.Promise.Negative)
                || (SignBitLo(x) == SignBitLo(y));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong SignBitLo(quadruple.ConstChecked x)
        {
            return NoZeroSignBitConst(x) ? 0ul : (x.Promise.Negative ? 1ul : (x.Value.value.hi64 >> 63));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong SignBitHi(quadruple.ConstChecked x)
        {
            return NoZeroSignBitConst(x) ? 0ul : (x.Promise.Negative ? 1ul : (x.Value.value.hi64 & (1ul << 63)));
        }




        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static quarter ZeroQuarter(ulong sign) => COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO ? asquarter((byte)(sign >> (BITS - quarter.BITS))) : asquarter((byte)0);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static half ZeroHalf(ulong sign) => COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO ? ashalf((ushort)(sign >> (BITS - F16_BITS))) : ashalf((ushort)0);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static float ZeroFloat(ulong sign) => COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO ? asfloat((uint)(sign >> (BITS - F32_BITS))) : 0f;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static double ZeroDouble(ulong sign) => COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO ? asdouble(sign) : 0d;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static quadruple ZeroQuadruple(ulong sign) => asquadruple(new UInt128(0, COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO ? sign : 0));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quadruple.ConstChecked Add(quadruple.ConstChecked left, quadruple.ConstChecked right, bool sameSign = false)
        {
            if (sameSign || EqualSignBitsLo(left, right))
            {
                return softfloat_addMagsF128(left, right);
            }
            else
            {
                return softfloat_subMagsF128(left, right);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quadruple.ConstChecked Subtract(quadruple.ConstChecked left, quadruple.ConstChecked right, bool sameSign = false)
        {
            if (sameSign || EqualSignBitsLo(left, right))
            {
                return softfloat_subMagsF128(left, right);
            }
            else
            {
                return softfloat_addMagsF128(left, right);
            }
        }


        #region CHECKED AND NEEDED THIS WAY

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static byte fracF8UI(byte a) => (byte)(a & bitmask8(quarter.MANTISSA_BITS));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static uint fracF16UI(ushort a) => (ushort)(a & bitmask16(F16_MANTISSA_BITS));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static uint fracF32UI(uint f) => f & bitmask32((uint)F32_MANTISSA_BITS);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ulong fracF64UI(ulong d) => d & bitmask64((ulong)F64_MANTISSA_BITS);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ulong fracF128UI64(ulong a64) => a64 & bitmask64((ulong)MANTISSA_BITS_HI64);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ulong packToF128UI64(ulong sign, ulong exp, ulong sig64) => sign | (exp + sig64);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void softfloat_normSubnormalF8Sig(ref ulong exp, ref uint sig, bool nonZero = false)
        {
            byte16 shiftDistBase = new byte16(8, 7, 6, 6, 5, 5, 5, 5,    4, 4, 4, 4, 4, 4, 4, 4) - quarter.EXPONENT_BITS;

            exp = Hint.Likely(!nonZero && sig == 0) ? 0u : (ulong)(F8_EXPONENT_OFFSET - (uint)shiftDistBase[(int)sig]) << MANTISSA_BITS_HI64;
            sig <<= shiftDistBase[(int)sig];
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void softfloat_normSubnormalF16Sig(ref ulong exp, ref uint sig, bool nonZero = false)
        {
            int shiftDist = lzcnt((ushort)sig);

            if (!nonZero)
            {
                if (Hint.Likely(sig == 0)) // more often 0 than subnormal. Start 3 cycle latency 'LZCNT' anyway and evaluate this branch in parallel (better with more modern CPUs)
                {
                    return;
                }
            }

            exp = (ulong)(uint)(F16_EXPONENT_BITS + F16_EXPONENT_OFFSET - shiftDist) << MANTISSA_BITS_HI64;
            sig <<= shiftDist - F16_EXPONENT_BITS;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void softfloat_normSubnormalF32Sig(ref ulong exp, ref uint sig, bool nonZero = false)
        {
            int shiftDist = lzcnt(sig);

            if (!nonZero)
            {
                if (Hint.Likely(sig == 0)) // more often 0 than subnormal. Start 3 cycle latency 'LZCNT' anyway and evaluate this branch in parallel (better with more modern CPUs)
                {
                    return;
                }
            }

            exp = (ulong)(uint)(F32_EXPONENT_BITS + F32_EXPONENT_OFFSET - shiftDist) << MANTISSA_BITS_HI64;
            sig <<= shiftDist - F32_EXPONENT_BITS;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void softfloat_normSubnormalF64Sig(ref ulong exp, ref ulong sig, bool nonZero = false)
        {
            int shiftDist = lzcnt(sig);

            if (!nonZero)
            {
                if (Hint.Likely(sig == 0)) // more often 0 than subnormal. Start 3 cycle latency 'LZCNT' anyway and evaluate this branch in parallel (better with more modern CPUs)
                {
                    return;
                }
            }

            exp = (ulong)(F64_EXPONENT_BITS + F64_EXPONENT_OFFSET - shiftDist) << MANTISSA_BITS_HI64;
            sig <<= shiftDist - F64_EXPONENT_BITS;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void softfloat_normSubnormalF128Sig2(ref ulong exp, ref UInt128 sig)
        {
            if (sig.hi64 == 0)
            {
                int shiftDist = lzcnt(sig.lo64);
                int shl = shiftDist - EXPONENT_BITS;

                exp = (ulong)(uint)(EXPONENT_BITS - 63 - shiftDist) << MANTISSA_BITS_HI64;

                if (sig.lo64 > bitmask64(64ul - EXPONENT_BITS)) // good OoOE branch
                {
                    sig = new UInt128(sig.lo64 << (shl & 63), sig.lo64 >> (EXPONENT_BITS - shiftDist));
                }
                else
                {
                    sig = new UInt128(0, sig.lo64 << shl);
                }
            }
            else
            {
                int shiftDist = lzcnt(sig.hi64);
                exp = (ulong)(uint)(EXPONENT_BITS + 1 - shiftDist) << MANTISSA_BITS_HI64;
                sig = softfloat_shortShiftLeft128(sig.hi64, sig.lo64, (byte)(shiftDist - EXPONENT_BITS));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static __UInt256__ softfloat_shiftRightJam256M(__UInt256__ a, uint dist)
        {
            return dist >= 256 ? tobyte(a.hi128.IsNotZero)
                               : (a >> (int)dist) | (constexpr.IS_TRUE(dist <= 128) ? 0u
                                                                                    : tobyte((a & __UInt256__.bitmask256(dist)).IsNotZero));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static uint softfloat_approxRecip32_1(uint a)
        {
            ushort16 softfloat_approxRecip_1k0s = new ushort16
            (
                0xFFC4, 0xF0BE, 0xE363, 0xD76F, 0xCCAD, 0xC2F0, 0xBA16, 0xB201,
                0xAA97, 0xA3C6, 0x9D7A, 0x97A6, 0x923C, 0x8D32, 0x887E, 0x8417
            );
            ushort16 softfloat_approxRecip_1k1s  = new ushort16
            (
                0xF0F1, 0xD62C, 0xBFA1, 0xAC77, 0x9C0A, 0x8DDB, 0x8185, 0x76BA,
                0x6D3B, 0x64D4, 0x5D5C, 0x56B1, 0x50B6, 0x4B55, 0x4679, 0x4211
            );

            int index = (int)(a >> 27 & 0xF);
            ushort eps = (ushort)(a >> 11);
            ushort r0 = (ushort)(softfloat_approxRecip_1k0s[index]
                      - ((softfloat_approxRecip_1k1s[index] * (uint)eps)
                        >> 20));
            uint sigma0 = ~(uint)((r0 * (ulong)a) >> 7);
            uint r = (uint)(((uint)r0 << 16) + ((r0 * (ulong)sigma0) >> 24));
            ulong sqrSigma0 = ((ulong)sigma0 * sigma0) >> 32;
            return r + (uint)((r * sqrSigma0) >> 48);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static uint softfloat_approxRecipSqrt32_1(uint oddExpA, uint a)
        {
            ushort16 softfloat_approxRecipSqrt_1k0s = new ushort16
            (
                0xB4C9, 0xFFAB, 0xAA7D, 0xF11C, 0xA1C5, 0xE4C7, 0x9A43, 0xDA29,
                0x93B5, 0xD0E5, 0x8DED, 0xC8B7, 0x88C6, 0xC16D, 0x8424, 0xBAE1
            );
            ushort16 softfloat_approxRecipSqrt_1k1s = new ushort16
            (
                0xA5A5, 0xEA42, 0x8C21, 0xC62D, 0x788F, 0xAA7F, 0x6928, 0x94B6,
                0x5CC7, 0x8335, 0x52A6, 0x74E2, 0x4A3E, 0x68FE, 0x432B, 0x5EFD
            );

            int index = (int)((a >> 27 & 0xE) + oddExpA);
            ushort eps = (ushort)(a >> 12);
            ushort r0 = (ushort)(softfloat_approxRecipSqrt_1k0s[index]
                      - ((softfloat_approxRecipSqrt_1k1s[index] * (uint)eps)
                        >> 20));
            uint ESqrR0 = (uint)r0 * r0;
            if (oddExpA == 0) // good OoOE branch, 1 cycle instead of 3 on x86 (shift via CL) or 2 (cmov, add)
            {
                ESqrR0 <<= 1;
            }
            uint sigma0 = ~(uint)((ESqrR0 * (ulong)a) >> 23);
            uint r = (uint)(((uint)r0 << 16) + ((r0 * (ulong)sigma0) >> 25));
            uint sqrSigma0 = (uint)(((ulong)sigma0 * sigma0) >> 32);
            r += (uint)((((r >> 1) + (r >> 3) - ((uint)r0 << 14))
                      * (ulong)sqrSigma0)
                      >> 48);

            return select(r, 1u << 31, (int)r >= 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static UInt128 softfloat_mul64ByShifted32To128(ulong a, uint b)
        {
            ulong mid = (uint)a * (ulong)b;

            return new UInt128(mid << 32, (a >> 32) * b + (mid >> 32));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ulong expF128UI64(ulong a64) => (a64 & SIGNALING_EXPONENT.hi64) >> MANTISSA_BITS_HI64;
        #endregion

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void softfloat_normSubnormalF128Sig(ref ulong exp, ref UInt128 sig)
        {
            if (sig.hi64 == 0)
            {
                int shiftDist = lzcnt(sig.lo64);
                int shl = shiftDist - EXPONENT_BITS;

                exp = (uint)(EXPONENT_BITS - 63 - shiftDist);

                if (sig.lo64 > bitmask64(64ul - EXPONENT_BITS)) // good OoOE branch
                {
                    sig = new UInt128(sig.lo64 << (shl & 63), sig.lo64 >> (EXPONENT_BITS - shiftDist));
                }
                else
                {
                    sig = new UInt128(0, sig.lo64 << shl);
                }
            }
            else
            {
                int shiftDist = lzcnt(sig.hi64);
                exp = (uint)(EXPONENT_BITS + 1 - shiftDist);
                sig = softfloat_shortShiftLeft128(sig.hi64, sig.lo64, (byte)(shiftDist - EXPONENT_BITS));
            }
        }
        // TODO everywhere. performance has a code quality cost.
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void ValidateNaN(quadruple x)
        {
        #if DEBUG
            if (abs(x).value > SIGNALING_EXPONENT
             && x.value.lo64 == 0)
            {
                throw new ArgumentException($"Custom NaN formats for '{ nameof(quadruple) }' are not supported. A valid '{nameof(quadruple) }' NaN has its high 64 bits set to any value greater than or equal to { SIGNALING_EXPONENT.hi64 } and its low 64 bits must be set to any non-zero value.");
            }
        #endif
        }






        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static quadruple softfloat_normRoundPackToF128(ulong sign, uint exp, ulong sig64, ulong sig0)
        {
            if (sig64 == 0)
            {
                exp -= 64;
                sig64 = sig0;
                sig0 = 0;
            }

            int shiftDist = lzcnt(sig64) - EXPONENT_BITS;
            exp -= (uint)shiftDist;

            if (sig64 <= bitmask64(64ul - EXPONENT_BITS))
            {
                if (sig64 < 1ul << (64 - EXPONENT_BITS - 1))
                {
                    UInt128 sig128 = softfloat_shortShiftLeft128(sig64, sig0, (byte)shiftDist);
                    sig64 = sig128.hi64;
                    sig0  = sig128.lo64;
                }
                if (exp < 0x7FFD)
                {
                    return new quadruple(sig0, packToF128UI64(sign, (sig64 | sig0) != 0 ? (ulong)exp << MANTISSA_BITS_HI64 : 0, sig64));
                }

                return softfloat_roundPackToF128(sign, exp, sig64, sig0, 0);
            }
            else
            {
                UInt128 sig128Extra = softfloat_shortShiftRightJam128Extra(sig64, sig0, 0, -shiftDist, out ulong sigExtra);

                return softfloat_roundPackToF128(sign, exp, sig128Extra.hi64, sig128Extra.lo64, sigExtra);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static quadruple softfloat_roundPackToF128(ulong sign, ulong exp, ulong sig64, ulong sig0, ulong sigExtra)
        {
            UInt128 sig = new UInt128(sig0, sig64);

            bool doIncrement = ((UInt128)1 << (BITS - 1)).hi64 <= sigExtra;

            if ((bitmask64((ulong)EXPONENT_BITS) ^ 2) <= (uint)exp)
            {
                if ((int)exp < 0)
                {
                    sig = softfloat_shiftRightJam128Extra(sig.hi64, sig.lo64, sigExtra, -(int)exp, out sigExtra);
                    exp = 0;
                }
                else if ((bitmask64((long)EXPONENT_BITS) ^ 2) < (int)exp
                      | ((exp == 0x7FFD)
                       & (sig == bitmask128((ulong)MANTISSA_BITS))
                       & doIncrement))
                {
                    return new quadruple(0, sign | SIGNALING_EXPONENT.hi64);
                }
            }

            if (doIncrement)
            {
                sig++;
                sig = new UInt128(andnot(sig.lo64, tobyte(andnot(sigExtra, ((UInt128)1 << (BITS - 1)).hi64) == 0)), sig.hi64);
            }
            else if (sig == 0)
            {
                exp = 0;
            }

            return new quadruple(sig.lo64, packToF128UI64(sign, exp << MANTISSA_BITS_HI64, sig.hi64));

        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static UInt128 softfloat_shortShiftLeft128(ulong a64, ulong a0, byte dist)
        {
            constexpr.ASSUME(dist <= 63);

            return new UInt128(a0 << dist, a64 << dist | a0 >> (64 - dist));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static UInt128 softfloat_shortShiftRight128(ulong a64, ulong a0, byte dist)
        {
            constexpr.ASSUME(dist <= 63);

            return new UInt128(a64 << (64 - dist) | a0 >> dist, a64 >> dist);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static UInt128 softfloat_shiftRightJam128(ulong a64, ulong a0, int dist)
        {
            if (dist < 64)
            {
                return new UInt128(a64 << (64 - dist) | a0 >> dist | tobyte(a0 << (64 - dist) != 0),
                                   a64 >> dist);
            }
            else
            {
                return new UInt128((dist < 127) ? a64 >> (dist & 63) | tobyte(((a64 & ((1ul << (dist & 63)) - 1)) | a0) != 0)
                                                : tobyte((a64 | a0) != 0),
                                   0);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static UInt128 softfloat_shiftRightJam128Extra(ulong a64, ulong a0, ulong extra, int dist, out ulong extraOut)
        {
            UInt128 result;
            if (dist < 64)
            {
                result = new UInt128(a64 << (64 - dist) | a0 >> dist, a64 >> dist);
                extraOut = a0 << (64 - dist);
            }
            else
            {
                if (dist == 64)
                {
                    result = new UInt128(a64, 0);
                    extraOut = a0;
                }
                else
                {
                    extra |= a0;
                    if (dist < 128)
                    {
                        result = new UInt128(a64 >> (dist & 63), 0);
                        extraOut = a64 << (64 - dist);
                    }
                    else
                    {
                        result = new UInt128(0, 0);
                        extraOut = (dist == 128) ? a64 : tobyte(a64 != 0);
                    }
                }
            }

            extraOut |= tobyte(extra != 0);
            return result;

        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static UInt128 softfloat_shortShiftRightJam128Extra(ulong a64, ulong a0, ulong extra, int dist, out ulong extraOut)
        {
            extraOut = a0 << (64 - dist) | tobyte(extra != 0);
            return new UInt128(a64 << (64 - dist) | a0 >> dist, a64 >> dist);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static quadruple softfloat_subMagsF128(quadruple.ConstChecked left, quadruple.ConstChecked right)
        {
            UInt128 l = left.Value.value;
            UInt128 r = right.Value.value;

            ulong expZ;
            ulong expA = l.hi64 & SIGNALING_EXPONENT.hi64;
            ulong expB = r.hi64 & SIGNALING_EXPONENT.hi64;
            long expDiff = (long)(expA - expB);

            UInt128 sigZ;
            UInt128 sigA = new UInt128(l.lo64, fracF128UI64(l.hi64));
            UInt128 sigB = new UInt128(r.lo64, fracF128UI64(r.hi64));

            ulong sign = l.hi64 & (1ul << 63);

            sigA <<= 4;
            sigB <<= 4;

            if (expA > expB)
            {
                goto expABigger;
            }
            if (expB > expA)
            {
                goto expBBigger;
            }
            if (!(left.Promise.NotNaN && left.Promise.NotInf)
             && expA == SIGNALING_EXPONENT.hi64)
            {
                return NaN;
            }
            expZ = expA;
            expZ += toulong(!(left.Promise.NonZero && left.Promise.NotSubnormal) && expZ == 0) << MANTISSA_BITS_HI64;
            if (sigB.hi64 < sigA.hi64)
            {
                goto aBigger;
            }
            if (sigA.hi64 < sigB.hi64)
            {
                goto bBigger;
            }
            if (sigB.lo64 < sigA.lo64)
            {
                goto aBigger;
            }
            if (sigA.lo64 < sigB.lo64)
            {
                goto bBigger;
            }
            return default(quadruple);
        expBBigger:
            if (!(right.Promise.NotNaN && right.Promise.NotInf)
             && expB == SIGNALING_EXPONENT.hi64)
            {
                if (!right.Promise.NotNaN
                 && sigB.IsNotZero)
                {
                    return NaN;
                }
                return new quadruple(0, (sign ^ (1ul << 63)) | SIGNALING_EXPONENT.hi64);
            }
            if ((left.Promise.NonZero && left.Promise.NotSubnormal)
             || expA != 0)
            {
                sigA = new UInt128(sigA.lo64, sigA.hi64 | 0x0010_0000_0000_0000ul);
            }
            else if ((expDiff = expDiff + (1L << MANTISSA_BITS_HI64)) == 0)
            {
                goto newlyAlignedBBigger;
            }







            sigA = softfloat_shiftRightJam128(sigA.hi64, sigA.lo64, -(int)(expDiff >> MANTISSA_BITS_HI64));




        newlyAlignedBBigger:
            expZ = expB;
            sigB = new UInt128(sigB.lo64, sigB.hi64 | 0x0010_0000_0000_0000ul);
        bBigger:
            sign ^= (1ul << 63);
            sigZ = sigB - sigA;
            goto normRoundPack;
        expABigger:
            if (!(left.Promise.NotNaN && left.Promise.NotInf)
             && expA == SIGNALING_EXPONENT.hi64)
            {
                if (!left.Promise.NotNaN
                 && sigA.IsNotZero)
                {
                    return NaN;
                }
                return left;
            }
            if ((right.Promise.NonZero && right.Promise.NotSubnormal)
             || expB != 0)
            {
                sigB = new UInt128(sigB.lo64, sigB.hi64 | 0x0010_0000_0000_0000ul);
            }
            else if ((expDiff = expDiff - (1L << MANTISSA_BITS_HI64)) == 0)
            {
                goto newlyAlignedABigger;
            }








            sigB = softfloat_shiftRightJam128(sigB.hi64, sigB.lo64, (int)(expDiff >> MANTISSA_BITS_HI64));










        newlyAlignedABigger:
            expZ = expA;
            sigA = new UInt128(sigA.lo64, sigA.hi64 | 0x0010_0000_0000_0000);
        aBigger:
            sigZ = sigA - sigB;
        normRoundPack:








            return softfloat_normRoundPackToF128(sign, (uint)(expZ >> MANTISSA_BITS_HI64) - 5, sigZ.hi64, sigZ.lo64);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static quadruple softfloat_addMagsF128(quadruple.ConstChecked left, quadruple.ConstChecked right)
        {
            UInt128 l = left.Value.value;
            UInt128 r = right.Value.value;

            ulong expZ;
            ulong expA = l.hi64 & SIGNALING_EXPONENT.hi64;
            ulong expB = r.hi64 & SIGNALING_EXPONENT.hi64;
            long expDiff = (long)(expA - expB);

            UInt128 sigZ;
            ulong sigZExtra;
            UInt128 sigA = new UInt128(l.lo64, fracF128UI64(l.hi64));
            UInt128 sigB = new UInt128(r.lo64, fracF128UI64(r.hi64));

            ulong sign = l.hi64 & (1ul << 63);

            if (expDiff == 0)
            {
                if (!(left.Promise.NotNaN && left.Promise.NotInf)
                 && expA == SIGNALING_EXPONENT.hi64)
                {
                    if (!right.Promise.NotNaN
                     && (sigA | sigB).IsNotZero)
                    {
                        return NaN;
                    }
                    return left;
                }
                sigZ = sigA + sigB;
                if (!(left.Promise.NonZero && left.Promise.NotSubnormal)
                 && expA == 0)
                {
                    return new quadruple(sigZ.lo64, packToF128UI64(sign, 0, sigZ.hi64));
                }
                expZ = expA;
                sigZ = new UInt128(sigZ.lo64, sigZ.hi64 | 0x0002_0000_0000_0000ul);
                sigZExtra = 0;
                goto shiftRight1;
            }
            if (expDiff < 0)
            {
                if (!(right.Promise.NotNaN && right.Promise.NotInf)
                 && expB == SIGNALING_EXPONENT.hi64)
                {
                    if (!right.Promise.NotNaN
                     && sigB.IsNotZero)
                    {
                        return NaN;
                    }
                    return new quadruple(0, sign | SIGNALING_EXPONENT.hi64);
                }
                expZ = expB;
                if ((left.Promise.NonZero && left.Promise.NotSubnormal)
                 || expA != 0)
                {
                    sigA = new UInt128(sigA.lo64, sigA.hi64 | (1ul << MANTISSA_BITS_HI64));
                }
                else
                {
                    sigZExtra = 0;
                    if ((expDiff = expDiff + (1L << MANTISSA_BITS_HI64)) == 0)
                    {
                        goto newlyAligned;
                    }
                }





                sigA = softfloat_shiftRightJam128Extra(sigA.hi64, sigA.lo64, 0, -(int)(expDiff >> MANTISSA_BITS_HI64), out sigZExtra);





            }
            else
            {
                if (!(left.Promise.NotNaN && left.Promise.NotInf)
                 && expA == SIGNALING_EXPONENT.hi64)
                {
                    if (!left.Promise.NotNaN
                     && sigA.IsNotZero)
                    {
                        return NaN;
                    }
                    return left;
                }
                expZ = expA;
                if ((right.Promise.NonZero && right.Promise.NotSubnormal)
                 || expB != 0)
                {
                    sigB = new UInt128(sigB.lo64, sigB.hi64 | (1ul << MANTISSA_BITS_HI64));
                }
                else
                {
                    sigZExtra = 0;
                    if ((expDiff = expDiff - (1L << MANTISSA_BITS_HI64)) == 0)
                    {
                        goto newlyAligned;
                    }
                }






                sigB = softfloat_shiftRightJam128Extra(sigB.hi64, sigB.lo64, 0, (int)(expDiff >> MANTISSA_BITS_HI64), out sigZExtra);





            }
         newlyAligned:
            sigZ = new UInt128(sigA.lo64, sigA.hi64 | (1ul << MANTISSA_BITS_HI64)) + sigB;
            expZ--;
            if (sigZ.hi64 < 0x0002_0000_0000_0000ul)
            {
                goto roundAndPack;
            }
            expZ++;
         shiftRight1:
            sigZ = softfloat_shortShiftRightJam128Extra(sigZ.hi64, sigZ.lo64, sigZExtra, 1, out sigZExtra);
         roundAndPack:





            return softfloat_roundPackToF128(sign, (uint)(expZ >> MANTISSA_BITS_HI64), sigZ.hi64, sigZ.lo64, sigZExtra);
        }














        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple operator + (quadruple value)
        {
            return value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple operator - (quadruple value)
        {
            return new quadruple(value.value.lo64, value.value.hi64 ^ (1ul << 63));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple operator ++ (quadruple x)
        {
            return x + asquadruple(ONE_AS_QUADRUPLE);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple operator -- (quadruple x)
        {
            return x - asquadruple(ONE_AS_QUADRUPLE);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple operator + (quadruple left, quadruple right) => Add(left, right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple operator - (quadruple left, quadruple right) => Subtract(left, right);
















        public readonly int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

        public readonly int CompareTo(quadruple other)
        {
            return compareto(this, other);
        }


        public readonly TypeCode GetTypeCode()
        {
            throw new NotImplementedException();
        }

        public readonly bool ToBoolean(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public readonly byte ToByte(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public readonly char ToChar(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public readonly DateTime ToDateTime(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public readonly decimal ToDecimal(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public readonly double ToDouble(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public readonly short ToInt16(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public readonly int ToInt32(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public readonly long ToInt64(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public readonly sbyte ToSByte(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public readonly float ToSingle(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public readonly object ToType(Type conversionType, IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public readonly ushort ToUInt16(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public readonly uint ToUInt32(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public readonly ulong ToUInt64(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }


        public override readonly int GetHashCode()
        {
            return value.GetHashCode();
        }

        public readonly bool Equals(quadruple other)
        {
            return this == other;
        }

        public override readonly bool Equals(object obj) => obj is quadruple converted && this.Equals(converted);
    }


    unsafe public static partial class maxmath
    {
        internal static UInt128 MAX_PRECISE_I128 => new UInt128(0, 0x406F_0000_0000_0000);//asuint128((quadruple)((UInt128)1 << quadruple.MANTISSA_BITS));
        internal static UInt128 ONE_AS_QUADRUPLE => new UInt128(0ul, 0x3FFF_0000_0000_0000ul);
        internal static int F128_ROUND_SHIFT_BASE => quadruple.MANTISSA_BITS + math.abs(quadruple.EXPONENT_BIAS);
        internal static UInt128 ONE_HALF_QUADRUPLE => new UInt128(0ul, 0x3FFE_0000_0000_0000ul);
        internal static quadruple ONE_THIRD_QUADRUPLE => new quadruple(0x5555_5555_5555_5555, 0x3FFD_5555_5555_5555);
        internal static quadruple FOUR_THIRDS_QUADRUPLE => new quadruple(0x5555_5555_5555_5555, 0x3FFF_5555_5555_5555);
        internal static quadruple tinyQuadruple => new quadruple(0xAD75_EC52_E4D2_5544, 0x0000_0000_0177_69BE);
        internal static quadruple hugeQuadruple => new quadruple(0x4981_5192_2505_CB5F, 0x7F94_5D24_084E_B26F);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quadruple scalbn(quadruple x, int n)
        {
            ulong lx = x.value.lo64;
            ulong hx = x.value.hi64;
        	ulong k;
            k = (hx >> 48) & 0x7fff;		/* extract exponent */
            if (k == 0)
            {				/* 0 or subnormal x */
                if ((lx | (hx & 0x7ffffffffffffffful)) == 0)
                {
                    return x; /* +-0 */
                }
        	    x *= new quadruple(0, 0x4071000000000000);
        	    hx = x.value.hi64;
        	    k = ((hx >> 48) & 0x7fff) - 114;
        	}
            if (k == 0x7fff)/* NaN or Inf */
            {
                return x+x;
            }
        	if (n < -50000)  /*underflow*/
            {
                return copysign(tinyQuadruple * tinyQuadruple, x);
            }
            if ((n > 50000) | (k + (ulong)(long)n > 0x7ffe)) /* overflow  */
            {
                return copysign(hugeQuadruple * hugeQuadruple, x);
            }

        	/* Now k and n are bounded we know that k = k+n does not
        	   overflow.  */
            k = k + (ulong)(long)n;
            if ((long)k > 0) 				/* normal result */
            {
                return new quadruple(x.value.lo64, (hx & 0x8000fffffffffffful) | (k << 48));
            }
            if ((long)k <= -114)/*underflow*/
            {
        	    return copysign(tinyQuadruple * tinyQuadruple, x); 
            }

            k += 114;				/* subnormal result */
            x = new quadruple(x.value.lo64, (hx & 0x8000fffffffffffful) | (k << 48));
            return x * new quadruple(0, 0x3F8D000000000000);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quadruple ldexp(quadruple value, int exp)
        {
        	if(!isfinite(value) | value == 0)
            {
                return value + value;
            }

        	return scalbn(value, exp);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quadruple frexp(quadruple x, out int e)
        {
        	ulong ix = x.value.hi64 & 0x7ffffffffffffffful;
        	e = 0;
        	if(ix >= 0x7fff000000000000ul | ((ix | x.value.lo64) == 0)) /* 0,inf,nan */
            {
                return x + x;
            }
        	if (ix < 0x0001000000000000ul) /* subnormal */
            {
        	    x *= new quadruple(0, 0x4071000000000000);
        	    ix = x.value.hi64 & 0x7ffffffffffffffful;
        	    e = -114;
        	}
        	e += (int)(ix >> 48) - 16382;
        	return new quadruple(x.value.lo64, (x.value.hi64 & 0x8000fffffffffffful) | 0x3ffe000000000000ul);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple asquadruple(UInt128 x) => new quadruple(x);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple asquadruple(Int128 x) => new quadruple((UInt128)x);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 asuint128(quadruple x) => x.value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 asint128(quadruple x) => (Int128)x.value;


        /// <summary>       Converts a <see cref="quadruple"/> to an <see cref="sbyte"/> while rounding towards the nearest integer value.    </summary>
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte roundtosbyte(quadruple x, Promise promises = Promise.Nothing)
        {
            quadruple.ConstChecked c = x;
            c.Promise |= promises.Promises(Promise.Positive) ? FloatingPointPromise<quadruple>.POSITIVE : Promise.Nothing;
            c.Promise |= promises.Promises(Promise.NonZero) ? FloatingPointPromise<quadruple>.NON_ZERO : Promise.Nothing;

            return (sbyte)BASE_cvtf128i128(c, signed: true, trunc: false);
        }

        /// <summary>       Converts a <see cref="quadruple"/> to a <see cref="short"/> while rounding towards the nearest integer value.    </summary>
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short roundtoshort(quadruple x, Promise promises = Promise.Nothing)
        {
            quadruple.ConstChecked c = x;
            c.Promise |= promises.Promises(Promise.Positive) ? FloatingPointPromise<quadruple>.POSITIVE : Promise.Nothing;
            c.Promise |= promises.Promises(Promise.NonZero) ? FloatingPointPromise<quadruple>.NON_ZERO : Promise.Nothing;

            return (short)BASE_cvtf128i128(c, signed: true, trunc: false);
        }

        /// <summary>       Converts a <see cref="quadruple"/> to an <see cref="int"/> while rounding towards the nearest integer value.    </summary>
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int roundtoint(quadruple x, Promise promises = Promise.Nothing)
        {
            quadruple.ConstChecked c = x;
            c.Promise |= promises.Promises(Promise.Positive) ? FloatingPointPromise<quadruple>.POSITIVE : Promise.Nothing;
            c.Promise |= promises.Promises(Promise.NonZero) ? FloatingPointPromise<quadruple>.NON_ZERO : Promise.Nothing;

            return (int)BASE_cvtf128i128(c, signed: true, trunc: false);
        }

        /// <summary>       Converts a <see cref="quadruple"/> to a <see cref="long"/> while rounding towards the nearest integer value.    </summary>
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long roundtolong(quadruple x, Promise promises = Promise.Nothing)
        {
            quadruple.ConstChecked c = x;
            c.Promise |= promises.Promises(Promise.Positive) ? FloatingPointPromise<quadruple>.POSITIVE : Promise.Nothing;
            c.Promise |= promises.Promises(Promise.NonZero) ? FloatingPointPromise<quadruple>.NON_ZERO : Promise.Nothing;

            return (long)BASE_cvtf128i128(c, signed: true, trunc: false);
        }

        /// <summary>       Converts a <see cref="quadruple"/> to an <see cref="Int128"/> while rounding towards the nearest integer value.    </summary>
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect values if any <paramref name="x"/> is negative or 0.       </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 roundtoint128(quadruple x, Promise promises = Promise.Nothing)
        {
            quadruple.ConstChecked c = x;
            c.Promise |= promises.Promises(Promise.Positive) ? FloatingPointPromise<quadruple>.POSITIVE : Promise.Nothing;
            c.Promise |= promises.Promises(Promise.NonZero) ? FloatingPointPromise<quadruple>.NON_ZERO : Promise.Nothing;

            return (Int128)BASE_cvtf128i128(c, signed: true, trunc: false);
        }

        /// <summary>       Converts a <see cref="quadruple"/> to a <see cref="byte"/> while rounding towards the nearest integer value.    </summary>
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte roundtobyte(quadruple x, Promise promises = Promise.Nothing)
        {
            quadruple.ConstChecked c = x;
            c.Promise |= promises.Promises(Promise.Positive) ? FloatingPointPromise<quadruple>.POSITIVE : Promise.Nothing;
            c.Promise |= promises.Promises(Promise.NonZero) ? FloatingPointPromise<quadruple>.NON_ZERO : Promise.Nothing;

            return (byte)BASE_cvtf128i128(c, signed: false, trunc: false);
        }

        /// <summary>       Converts a <see cref="quadruple"/> to a <see cref="ushort"/> while rounding towards the nearest integer value.    </summary>
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort roundtoushort(quadruple x, Promise promises = Promise.Nothing)
        {
            quadruple.ConstChecked c = x;
            c.Promise |= promises.Promises(Promise.Positive) ? FloatingPointPromise<quadruple>.POSITIVE : Promise.Nothing;
            c.Promise |= promises.Promises(Promise.NonZero) ? FloatingPointPromise<quadruple>.NON_ZERO : Promise.Nothing;

            return (ushort)BASE_cvtf128i128(c, signed: false, trunc: false);
        }

        /// <summary>       Converts a <see cref="quadruple"/> to a <see cref="uint"/> while rounding towards the nearest integer value.    </summary>
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint roundtouint(quadruple x, Promise promises = Promise.Nothing)
        {
            quadruple.ConstChecked c = x;
            c.Promise |= promises.Promises(Promise.Positive) ? FloatingPointPromise<quadruple>.POSITIVE : Promise.Nothing;
            c.Promise |= promises.Promises(Promise.NonZero) ? FloatingPointPromise<quadruple>.NON_ZERO : Promise.Nothing;

            return (uint)BASE_cvtf128i128(c, signed: false, trunc: false);
        }

        /// <summary>       Converts a <see cref="quadruple"/> to a <see cref="ulong"/> while rounding towards the nearest integer value.    </summary>
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong roundtoulong(quadruple x, Promise promises = Promise.Nothing)
        {
            quadruple.ConstChecked c = x;
            c.Promise |= promises.Promises(Promise.Positive) ? FloatingPointPromise<quadruple>.POSITIVE : Promise.Nothing;
            c.Promise |= promises.Promises(Promise.NonZero) ? FloatingPointPromise<quadruple>.NON_ZERO : Promise.Nothing;

            return (ulong)BASE_cvtf128i128(c, signed: false, trunc: false);
        }

        /// <summary>       Converts a <see cref="quadruple"/> to a <see cref="UInt128"/> while rounding towards the nearest integer value.    </summary>
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect values if any <paramref name="x"/> is 0.       </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 roundtouint128(quadruple x, Promise promises = Promise.Nothing)
        {
            quadruple.ConstChecked c = x;
            c.Promise |= promises.Promises(Promise.Positive) ? FloatingPointPromise<quadruple>.POSITIVE : Promise.Nothing;
            c.Promise |= promises.Promises(Promise.NonZero) ? FloatingPointPromise<quadruple>.NON_ZERO : Promise.Nothing;

            return BASE_cvtf128i128(c, signed: false, trunc: false);
        }
















        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isnan(quadruple x)
        {
            // special encoding
            quadruple.ValidateNaN(x);

            return !COMPILATION_OPTIONS.FLOAT_NO_NAN
                && (abs(x).value.hi64 >= quadruple.SIGNALING_EXPONENT.hi64) & (x.value.lo64 != 0);
        }




















        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isinf(quadruple x)
        {
            return !COMPILATION_OPTIONS.FLOAT_NO_INF
                && abs(x).value == quadruple.SIGNALING_EXPONENT;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isfinite(quadruple x)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_INF
                || abs(x).value < quadruple.SIGNALING_EXPONENT;
        }


        /// <summary>   Returns the result of converting a <see cref="quadruple"/> value from radians to degrees.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple degrees(quadruple x)
        {
            return x * TODEGREES_QUAD;
        }

        /// <summary>   Returns the result of converting a <see cref="quadruple"/> value from degrees to radians.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple radians(quadruple x)
        {
            return x * TORADIANS_QUAD;
        }

        /// <summary>   Change the sign of <paramref name="x"/> based on the most significant bit of <paramref name="y"/> [msb(<paramref name="y"/>) <see langword="?"/> <see langword="-"/><paramref name="x"/> <see langword=":"/> <paramref name="x"/>].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple chgsign(quadruple x, quadruple y)
        {
            return new quadruple(x.value ^ (y.value & ((UInt128)1 << 127)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple round(quadruple x, Promise promises = Promise.Nothing)
        {
            UInt128 SIGN_MASK = bitmask128(127ul);

			UInt128 result = x.value;
			UInt128 __abs = result;
            if (!promises.Promises(Promise.Positive))
            {
                __abs &= SIGN_MASK;
            }

			if (Hint.Unlikely(__abs < ONE_AS_QUADRUPLE))
			{
                if (promises.Promises(Promise.Positive))
                {
                    #if EVEN_ON_TIE
                        result = ONE_AS_QUADRUPLE & UInt128.blendmask(__abs >= (bits_resetlowest(ONE_AS_QUADRUPLE) | 1));
                    #else
                        result = ONE_AS_QUADRUPLE & UInt128.blendmask(__abs >= bits_resetlowest(ONE_AS_QUADRUPLE));
                    #endif
                }
                else if (promises.Promises(Promise.Negative))
                {
                    #if EVEN_ON_TIE
                        result = __abs >= (bits_resetlowest(ONE_AS_QUADRUPLE) | 1) ? (~SIGN_MASK | ONE_AS_QUADRUPLE) : ~SIGN_MASK;
                    #else
                        result = __abs >= bits_resetlowest(ONE_AS_QUADRUPLE) ? (~SIGN_MASK | ONE_AS_QUADRUPLE) : ~SIGN_MASK;
                    #endif
                }
                else
                {
				    result &= ~SIGN_MASK;

                    #if EVEN_ON_TIE
                        result |= ONE_AS_QUADRUPLE & UInt128.blendmask(__abs >= (bits_resetlowest(ONE_AS_QUADRUPLE) | 1));
                    #else
                        result |= ONE_AS_QUADRUPLE & UInt128.blendmask(__abs >= bits_resetlowest(ONE_AS_QUADRUPLE)));
                    #endif
                }
			}
			else if (__abs < MAX_PRECISE_I128)
			{
				int shift = F128_ROUND_SHIFT_BASE - (int)(__abs >> quadruple.MANTISSA_BITS);
				UInt128 mask = bitmask128((ulong)(uint)shift);

                #if EVEN_ON_TIE
                    result += ((UInt128)1 << (shift - 1)) - andnot(1, result >> shift);
                #else
                    result += (UInt128)1 << (shift - 1);
                #endif

				result = andnot(result, mask);
			}

			return asquadruple(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple floor(quadruple x, Promise promises = Promise.Nothing)
        {
            UInt128 SIGN_MASK = bitmask128(127ul);

			UInt128 result = x.value;
			UInt128 __abs = result;
            if (!promises.Promises(Promise.Positive))
            {
                __abs &= SIGN_MASK;
            }

			if (Hint.Unlikely(__abs < ONE_AS_QUADRUPLE))
			{
                if (promises.Promises(Promise.Positive))
                {
                    result = 0;
                }
                else if (promises.Promises(Promise.Negative))
                {
                    result = (~SIGN_MASK | ONE_AS_QUADRUPLE);
                }
                else
                {
				    result &= ~SIGN_MASK;
                    result |= ONE_AS_QUADRUPLE & UInt128.blendmask(x.value > ~SIGN_MASK);
                }
			}
			else if (__abs < MAX_PRECISE_I128)
			{
				int shift = F128_ROUND_SHIFT_BASE - (int)(__abs.hi64 >> quadruple.MANTISSA_BITS_HI64);
				UInt128 mask = bitmask128((ulong)(uint)shift);

                if (promises.Promises(Promise.Positive))
                {
                    ;
                }
                else if (promises.Promises(Promise.Negative))
                {
                    result += mask;
                }
                else
                {
				    result += mask & (UInt128)((long)x.value.hi64 >> 63);
                }

				result = andnot(result, mask);
			}

			return asquadruple(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple ceil(quadruple x, Promise promises = Promise.Nothing)
        {
            UInt128 SIGN_MASK = bitmask128(127ul);

			UInt128 result = x.value;
			UInt128 __abs = result;
            if (!promises.Promises(Promise.Positive))
            {
                __abs &= SIGN_MASK;
            }

			if (Hint.Unlikely(__abs < ONE_AS_QUADRUPLE))
			{
                if (promises.Promises(Promise.Positive))
                {
                    result = ONE_AS_QUADRUPLE;
                }
                else
                {
                    result &= ~SIGN_MASK;

                    if (!promises.Promises(Promise.Negative))
                    {
                        result |= andnot(ONE_AS_QUADRUPLE, (UInt128)((long)x.value >> 63));
                    }
                }
			}
			else if (__abs < MAX_PRECISE_I128)
			{
				int shift = F128_ROUND_SHIFT_BASE - (int)(__abs.hi64 >> quadruple.MANTISSA_BITS_HI64);
				UInt128 mask = bitmask128((ulong)(uint)shift);

                if (promises.Promises(Promise.Positive))
                {
                    result += mask;
                }
                else if (promises.Promises(Promise.Negative))
                {
                    ;
                }
                else
                {
				    result += andnot(mask, (UInt128)((long)x.value.hi64 >> 63));
                }

				result = andnot(result, mask);
			}

			return asquadruple(result);
        }

        /// <summary>       Returns the result of a truncation of a <see cref="quadruple"/> to an integral <see cref="quadruple"/>.       </summary>
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns postive 0 if truncating a negative <paramref name="x"/> would result in negative 0 when adhering to the IEEE 754 standard.       </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple trunc(quadruple x, Promise promises = Promise.Nothing)
        {
            UInt128 SIGN_MASK = bitmask128(127ul);


            UInt128 rawExponent = x.value & SIGN_MASK;

            if (!(promises.Promises(Promise.Unsafe0) || constexpr.IS_TRUE((x.value & SIGN_MASK) < quadruple.SIGNALING_EXPONENT)))
            {
                if (Hint.Unlikely(rawExponent >= quadruple.SIGNALING_EXPONENT))
                {
                    return x;
                }
            }

            int unbiasedExponent = (int)(rawExponent >> quadruple.MANTISSA_BITS);
            int fractionBits = (quadruple.MANTISSA_BITS + math.abs(quadruple.EXPONENT_BIAS)) - unbiasedExponent;

            UInt128 mask = ((UInt128)1 << fractionBits) - 1u;
            UInt128 validRangeMask = (UInt128)(-tolong(unbiasedExponent - math.abs(quadruple.EXPONENT_BIAS) < quadruple.MANTISSA_BITS));

            UInt128 result = x.value & (UInt128)(-tolong(fractionBits <= quadruple.MANTISSA_BITS));
            result = andnot(result, mask & validRangeMask);

            // only here to preserve negative 0
            if (!(promises.Promises(Promise.Positive) || constexpr.IS_TRUE(x.value < ~SIGN_MASK)))
            {
                result |= andnot(x.value, SIGN_MASK);
            }

            return asquadruple(result);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple abs(quadruple x)
        {
            if (constexpr.IS_TRUE((long)x.value.hi64 >= 0))
            {
                return x;
            }
            else
            {
                return new quadruple(x.value.lo64, x.value.hi64 & bitmask64(63ul));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple nabs(quadruple x)
        {
            if (constexpr.IS_TRUE((long)x.value.hi64 < 0))
            {
                return x;
            }
            else
            {
                return new quadruple(x.value.lo64, x.value.hi64 | (1ul << 63));
            }
        }

        /// <summary>       Returns <see langword="true"/> if a <see cref="quadruple"/> is within the interval [<paramref name="min"/>, <paramref name="max"/>], where <paramref name="x"/>, <paramref name="min"/> and <paramref name="max"/> are <see cref="quadruple"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isinrange(quadruple x, quadruple min, quadruple max)
        {
            return x >= min & x <= max;
        }

        /// <summary>       Returns <see langword="true"/> if the <see cref="quadruple"/> <paramref name="x"/> is neither 0, normal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool issubnormal(quadruple x)
        {
            if (COMPILATION_OPTIONS.FLOAT_DENORMALS_ARE_ZERO)
            {
                return false;
            }

            ulong cmp = x.value.hi64 & quadruple.SIGNALING_EXPONENT.hi64;
            bool zeroExponent = cmp == 0;

            bool nonZero;
            if (COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO)
            {
                nonZero = (x.value.lo64 | (x.value.hi64 << 1)) != 0;
            }
            else
            {
                nonZero = x.value.IsNotZero;
            }

            return nonZero & zeroExponent;
        }

        /// <summary>       Returns <see langword="true"/> if the <see cref="quadruple"/> <paramref name="x"/> is neither 0, subnormal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isnormal(quadruple x)
        {
            ulong cmp = x.value.hi64 & quadruple.SIGNALING_EXPONENT.hi64;

            bool nonZeroExponent = cmp != 0;
            bool notNanInf;
            if (COMPILATION_OPTIONS.FLOAT_NO_NAN
             && COMPILATION_OPTIONS.FLOAT_NO_INF)
            {
                notNanInf = true;
            }
            else
            {
                notNanInf = cmp != quadruple.SIGNALING_EXPONENT.hi64;
            }

            return notNanInf & nonZeroExponent;
        }

        /// <summary>       Returns <see langword="true"/> if the two <see cref="quadruple"/>s <paramref name="a"/> and <paramref name="b"/> are approximately equal to each other, given a <paramref name="tolerance"/>.      </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="quadruple.PositiveInfinity"/>, and <see cref="quadruple.NegativeInfinity"/>.     </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool approx(quadruple a, quadruple b, quadruple tolerance, Promise promises = Promise.Nothing)
        {
            Promise basePromise = FloatingPointPromise<quadruple>.NOT_NAN | (promises.Promises(Promise.Unsafe0) ? FloatingPointPromise<quadruple>.NOT_INF : Promise.Nothing);
            quadruple.ConstChecked promisedA = a;
            quadruple.ConstChecked promisedB = b;
            promisedA.Promise |= basePromise;
            promisedB.Promise |= basePromise;

            quadruple cmp = abs(quadruple.Subtract(promisedB, promisedA));

            if (!promises.Promises(Promise.Unsafe0))
            {
                bool ainf = isinf(a);
                bool binf = isinf(b);
                cmp = select(select(cmp, quadruple.NaN, ainf | binf),
                             select(0f, quadruple.NaN, quadruple.NotEqual(promisedA, promisedB)),
                             ainf & binf);
            }

            return cmp <= tolerance;
        }

        /// <summary>       Returns <see langword="true"/> if the two <see cref="float"/>s <paramref name="a"/> and <paramref name="b"/> are approximately equal to each other.      </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="float.PositiveInfinity"/>, and <see cref="float.NegativeInfinity"/>.     </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool approx(quadruple a, quadruple b, Promise promises = Promise.Nothing)
        {
            return approx(a, b, max(F128_TO_LAST_DIGIT * max(abs(a), abs(b)), asquadruple(maxmath.bitmask128((ulong)MANTISSA_ROUNDING_BITS))), promises);
        }

        /// <summary>       Returns <paramref name="b"/> if <paramref name="c"/> is <see langword="true"/>, <paramref name="a"/> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple select(quadruple a, quadruple b, bool c)
        {
            return asquadruple(select(a.value, b.value, c));
        }

        /// <summary>       Returns -1 if <paramref name="x"/> is smaller than <paramref name="y"/>, 1 if <paramref name="x"/> is greater than <paramref name="y"/> or 0 if both are equal.      </summary>
        [return: AssumeRange(-1, 1)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compareto(quadruple x, quadruple y)
        {
            return tobyte(x > y) - tobyte(x < y);
        }

        /// <summary>       Returns the minimum of two <see cref="quadruple"/>s.    </summary>
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results if either <paramref name="a"/> or <paramref name="b"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results if either <paramref name="a"/> or <paramref name="b"/> is <see cref="quadruple.NaN"/>.       </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple min(quadruple a, quadruple b, Promise promises = Promise.Nothing)
        {
            if (promises.Promises(Promise.Unsafe0))
            {
                if (constexpr.IS_TRUE(quadruple.IsZero(a)))
                {
                    return asquadruple(b.value & new UInt128((long)b.value.hi64 >> 63, (long)b.value.hi64 >> 63));
                }
                if (constexpr.IS_TRUE(quadruple.IsZero(b)))
                {
                    return asquadruple(a.value & new UInt128((long)a.value.hi64 >> 63, (long)a.value.hi64 >> 63));
                }
            }

            Promise basePromise = (promises.Promises(Promise.NonZero) ? FloatingPointPromise<quadruple>.NON_ZERO : Promise.Nothing) | (promises.Promises(Promise.Unsafe0) ? FloatingPointPromise<quadruple>.NOT_NAN : Promise.Nothing);
            quadruple.ConstChecked promisedA = a;
            quadruple.ConstChecked promisedB = b;
            promisedA.Promise |= basePromise;
            promisedB.Promise |= basePromise;

            return quadruple.LessThan(promisedA, promisedB) ? promisedA : promisedB;
        }

        /// <summary>       Returns the maximum of two <see cref="quadruple"/>s.    </summary>
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results if either <paramref name="a"/> or <paramref name="b"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results if either <paramref name="a"/> or <paramref name="b"/> is <see cref="quadruple.NaN"/>.       </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple max(quadruple a, quadruple b, Promise promises = Promise.Nothing)
        {
            if (promises.Promises(Promise.Unsafe0))
            {
                if (constexpr.IS_TRUE(quadruple.IsZero(a)))
                {
                    return asquadruple(andnot(b.value, new UInt128((long)b.value.hi64 >> 63, (long)b.value.hi64 >> 63)));
                }
                if (constexpr.IS_TRUE(quadruple.IsZero(b)))
                {
                    return asquadruple(andnot(a.value, new UInt128((long)a.value.hi64 >> 63, (long)a.value.hi64 >> 63)));
                }
            }

            Promise basePromise = (promises.Promises(Promise.NonZero) ? FloatingPointPromise<quadruple>.NON_ZERO : Promise.Nothing) | (promises.Promises(Promise.Unsafe0) ? FloatingPointPromise<quadruple>.NOT_NAN : Promise.Nothing);
            quadruple.ConstChecked promisedA = a;
            quadruple.ConstChecked promisedB = b;
            promisedA.Promise |= basePromise;
            promisedB.Promise |= basePromise;

            return quadruple.LessThan(promisedA, promisedB) ? promisedB : promisedA;
        }

        /// <summary>       Transfers the sign of <paramref name="y"/> onto <paramref name="x"/> and returns the result. If <paramref name="y"/> is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned and if <paramref name="y"/> is greater than or equal to zero, abs(<paramref name="x"/>) is returned.     </summary>
        /// <remarks>       A <see cref="Promise"/> "<paramref name="nonZero"/>" with its <see cref="Promise.NonZero"/> flag set will incorrectly return <see langword="-"/>abs(<paramref name="x"/>), if <paramref name="y"/> is negative zero, exactly.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple copysign(quadruple x, quadruple y, Promise nonZero = Promise.Nothing)
        {
            UInt128 SIGN_MASK = (UInt128)1u << 127;
            UInt128 VALUE_MASK = ~SIGN_MASK;

            UInt128 _x = asuint128(x);
            UInt128 _y = asuint128(y);

            UInt128 xAbs = new UInt128(_x.lo64, _x.hi64 & VALUE_MASK.hi64);
            ulong ySign;

            if (nonZero.Promises(Promise.NonZero))
            {
                ySign = SIGN_MASK.hi64 & _y.hi64;
            }
            else
            {
                ySign = _y.hi64 & (toulong(quadruple.IsNotZero(y)) << 63);
            }

            return asquadruple(new UInt128(xAbs.lo64, xAbs.hi64 | ySign));
        }

        /// <summary>       Returns the next closest <see cref="quadruple"/> greater than <paramref name="x"/>.     </summary>
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that is negative 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that is negative or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that is positive or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for any <paramref name="x"/> that is either <see cref="quadruple.PositiveInfinity"/>, <see cref="quadruple.NegativeInfinity"/> or <see cref="quadruple.NaN"/>.       </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple nextgreater(quadruple x, Promise promises = Promise.Nothing)
        {
            Int128 __x = asint128(x);
            Int128 summand;
            long sign = (long)__x.hi64 >> 63;
            Int128 sign128 = new Int128(sign, sign);

            if (promises.Promises(Promise.NonZero))
            {
                if (promises.Promises(Promise.Positive) | promises.Promises(Promise.Negative))
                {
                    summand = 1;
                }
                else
                {
                    summand = 1 | sign128;
                }
            }
            else
            {
                Int128 notNegative0 = (Int128)UInt128.blendmask(__x.hi64 != 1ul << 63);
                summand = 1 | (sign128 & notNegative0);
                __x &= notNegative0;
            }

            if (!promises.Promises(Promise.Unsafe0))
            {
                Int128 notNanInf = (Int128)UInt128.blendmask(((UInt128)__x & quadruple.SIGNALING_EXPONENT) != quadruple.SIGNALING_EXPONENT);
                summand &= notNanInf;
            }

            if (promises.Promises(Promise.Negative))
            {
                return asquadruple(__x - summand);
            }
            else
            {
                return asquadruple(__x + summand);
            }
        }

        /// <summary>       Returns the next closest <see cref="quadruple"/> smaller than <paramref name="x"/>.     </summary>
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that is negative 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that is negative or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that is positive or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for any <paramref name="x"/> that is either <see cref="quadruple.PositiveInfinity"/>, <see cref="quadruple.NegativeInfinity"/> or <see cref="quadruple.NaN"/>.       </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple nextsmaller(quadruple x, Promise promises = Promise.Nothing)
        {
            Int128 __x = asint128(x);
            Int128 summand;
            long sign = (long)__x.hi64 >> 63;
            Int128 sign128 = new Int128(sign, sign);

            if (promises.Promises(Promise.NonZero))
            {
                if (promises.Promises(Promise.Positive) | promises.Promises(Promise.Negative))
                {
                    summand = 1;
                }
                else
                {
                    summand = 1 | sign;
                }
            }
            else
            {
                Int128 isNotZero = (Int128)UInt128.blendmask((__x.hi64 != 1ul << 63) & __x.IsNotZero);
                summand = 1 | (sign128 & isNotZero);
                __x |= andnot(new Int128(0x0000_0000_0000_0002, 0x8000_0000_0000_0000), isNotZero);
            }

            if (!promises.Promises(Promise.Unsafe0))
            {
                Int128 notNanInf = (Int128)UInt128.blendmask(((UInt128)__x & quadruple.SIGNALING_EXPONENT) != quadruple.SIGNALING_EXPONENT);
                summand &= notNanInf;
            }

            if (promises.Promises(Promise.Negative))
            {
                return asquadruple(__x + summand);
            }
            else
            {
                return asquadruple(__x - summand);
            }
        }

        /// <summary>       Returns the next closest <see cref="quadruple"/> to '<paramref name="from"/>' in the direction of '<paramref name="to"/>'.     </summary>
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any '<paramref name="from"/>' that is negative 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Positive"/> flag set returns incorrect results for any '<paramref name="from"/>' that is negative or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Negative"/> flag set returns incorrect results for any '<paramref name="from"/>' that is positive or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for any '<paramref name="from"/>' that is either <see cref="quadruple.PositiveInfinity"/>, <see cref="quadruple.NegativeInfinity"/> or <see cref="quadruple.NaN"/> as well as any '<paramref name="to"/>' that is <see cref="quadruple.NaN"/>.      </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple nexttoward(quadruple from, quadruple to, Promise promises = Promise.Nothing)
        {
            Promise basePromise = (promises.Promises(Promise.NonZero)  ? FloatingPointPromise<quadruple>.NON_ZERO                               : Promise.Nothing)
                                | (promises.Promises(Promise.Unsafe0)  ? FloatingPointPromise<quadruple>.NOT_NAN | FloatingPointPromise<quadruple>.NOT_INF : Promise.Nothing)
                                | (promises.Promises(Promise.Positive) ? FloatingPointPromise<quadruple>.POSITIVE                               : Promise.Nothing)
                                | (promises.Promises(Promise.Negative) ? FloatingPointPromise<quadruple>.NEGATIVE                               : Promise.Nothing);

            quadruple.ConstChecked promisedFrom = from;
            quadruple.ConstChecked promisedTo = to;
            promisedFrom.Promise |= basePromise;
            promisedTo.Promise |= basePromise;

            Int128 isGreater = (Int128)UInt128.blendmask(quadruple.GreaterThan(promisedFrom, promisedTo));
            Int128 __x = asint128(from);
            Int128 summand;
            long signx = (long)__x.hi64 >> 63;
            Int128 signx128 = new Int128(signx, signx);

            if (promises.Promises(Promise.NonZero))
            {
                if (promises.Promises(Promise.Positive) | promises.Promises(Promise.Negative))
                {
                    summand = 1;
                }
                else
                {
                    summand = 1 | signx;
                }
            }
            else
            {
                Int128 zeroMask = (Int128)UInt128.blendmask(__x.hi64 != 1ul << 63) ^ (-tolong(__x.IsZero) & isGreater);
                summand = 1 | (signx128 & zeroMask);
                __x = (__x & (isGreater | zeroMask)) | andnot(new Int128(0x0000_0000_0000_0002, 0x8000_0000_0000_0000) & isGreater, zeroMask);
            }

            if (!promises.Promises(Promise.Unsafe0))
            {
                Int128 xNotInf = (Int128)UInt128.blendmask(((UInt128)__x & quadruple.SIGNALING_EXPONENT) != quadruple.SIGNALING_EXPONENT);
                Int128 eitherNaN = (Int128)UInt128.blendmask((new UInt128(__x.lo64, __x.hi64 & 0x7FFF_FFFF_FFFF_FFFFul) > quadruple.SIGNALING_EXPONENT) | (new UInt128(to.value.lo64, to.value.hi64 & 0x7FFF_FFFF_FFFF_FFFFul) > quadruple.SIGNALING_EXPONENT));
                summand = andnot(summand & xNotInf, eitherNaN);
                __x |= eitherNaN;
            }

            summand = (summand ^ isGreater) - isGreater;
            long neq = -tolong(quadruple.NotEqual(promisedFrom, promisedTo));
            Int128 neq128 = new Int128(neq, neq);
            summand &= neq128;

            if (promises.Promises(Promise.Negative))
            {
                return asquadruple(__x - summand);
            }
            else
            {
                return asquadruple(__x + summand);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple rcp(quadruple x)
        {
            return 1 / x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple rsqrt(quadruple x)
        {
            return rcp(sqrt(x));
        }

        /// <summary>       Computes the square (<paramref name="x"/> <see langword="*"/> <paramref name="x"/>) of the input argument <paramref name="x"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quadruple square(quadruple x)
        {
            return x * x;
        }

        /// <summary>       Returns the cube root of a <see cref="quadruple"/>.    </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for negative input values, including negative 0.       </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for 0, including negative 0.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="quadruple.PositiveInfinity"/>, and <see cref="quadruple.NegativeInfinity"/>.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for subnormal values, i.e. values with magnitude greater or equal to 0 and magnitude less than or equal to ~3.362103143112093506262677817321752E-4932.       </para>
        /// </remarks>
        public static quadruple cbrt(quadruple x, Promise promises = Promise.Nothing)
        {
            int e, rem, sign;

            if (!isfinite(x))
            {
                return x + x;
            }
            if (x == 0)
            {
                return x;
            }
            if (x > 0)
            {
                sign = 1;
            }
            else
            {
                sign = -1;
                x = -x;
            }

            quadruple y = frexp(x, out e);

            y = quadruple.fmadd(y,
                quadruple.fmadd(y,
                quadruple.fmsub(y,
                quadruple.fmadd(y,
                quadruple.fmsub(y, LUT.R_CBRT.F128_C0,
                                   LUT.R_CBRT.F128_C1),
                                   LUT.R_CBRT.F128_C2),
                                   LUT.R_CBRT.F128_C3),
                                   LUT.R_CBRT.F128_C4),
                                   LUT.R_CBRT.F128_C5);
            if (e >= 0)
            {
                rem = e;
                e /= 3;
                rem -= 3 * e;
                if (rem == 1)
                {
                    y *= CBRT2_QUAD;
                }
                else if (rem == 2)
                {
                    y *= CBRT4_QUAD;
                }
            }
            else
            {
                e = -e;
                rem = e;
                e /= 3;
                rem -= 3 * e;
                if (rem == 1)
                {
                    y *= RCBRT2_QUAD;
                }
                else if (rem == 2)
                {
                    y *= RCBRT4_QUAD;
                }
                e = -e;
            }

            y = ldexp(y, e);

            y = quadruple.fnmadd(ONE_THIRD_QUADRUPLE,   y - (x / square(y)),   y);
            y = quadruple.fnmadd(ONE_THIRD_QUADRUPLE,   y - (x / square(y)),   y);

            if (COMPILATION_OPTIONS.FLOAT_PRECISION != FloatPrecision.Low)
            {
                y = quadruple.fnmadd(ONE_THIRD_QUADRUPLE,   y - (x / square(y)),   y);
            }

            if (sign < 0)
            {
                y = -y;
            }

            return y;
        }

        public static quadruple rcbrt(quadruple x, Promise promises = Promise.Nothing)
        {
            int e, rem, sign;

            if (!isfinite(x))
            {
                if (isnan(x))
                {
                    return x;
                }

                return copysign(0f, x);
            }
            if (x == 0)
            {
                return new quadruple(quadruple.PositiveInfinity.value.lo64, quadruple.PositiveInfinity.value.hi64 | x.value.hi64);
            }
            if (x > 0)
            {
                sign = 1;
            }
            else
            {
                sign = -1;
                x = -x;
            }

            quadruple y = frexp(x, out e);

            y = quadruple.fmadd(y,
                quadruple.fmadd(y,
                quadruple.fmsub(y,
                quadruple.fmadd(y,
                quadruple.fmsub(y, LUT.R_CBRT.F128_C0,
                                   LUT.R_CBRT.F128_C1),
                                   LUT.R_CBRT.F128_C2),
                                   LUT.R_CBRT.F128_C3),
                                   LUT.R_CBRT.F128_C4),
                                   LUT.R_CBRT.F128_C5);
            if (e >= 0)
            {
                rem = e;
                e = (int)((uint)e / 3);
                rem -= 3 * e;
                if (rem == 1)
                {
                    y *= CBRT2_QUAD;
                }
                else if (rem == 2)
                {
                    y *= CBRT4_QUAD;
                }
            }
            else
            {
                e = -e;
                rem = e;
                e = (int)((uint)e / 3);
                rem -= 3 * e;
                if (rem == 1)
                {
                    y *= RCBRT2_QUAD;
                }
                else if (rem == 2)
                {
                    y *= RCBRT4_QUAD;
                }
                e = -e;
            }

            quadruple thirdX = x * ONE_THIRD_QUADRUPLE;
            y = ldexp(y, e);
            quadruple inv = rcp(y);

            y = inv *  quadruple.fnmadd(thirdX / y,   square(inv),   FOUR_THIRDS_QUADRUPLE);
            y       *= quadruple.fnmadd(thirdX * y,   square(y),     FOUR_THIRDS_QUADRUPLE);

            if (COMPILATION_OPTIONS.FLOAT_PRECISION != FloatPrecision.Low)
            {
                y *= quadruple.fnmadd(thirdX * y,   square(y),   FOUR_THIRDS_QUADRUPLE);
            }

            if (sign < 0)
            {
                y = -y;
            }

            return y;
        }

        /// <summary>       Returns the fast approximate inverse square root a <see cref="quadruple"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple fastrsqrt(quadruple x)
        {
            // slower ATM

            //quadruple MAGIC = new quadruple(0xAB0F_F774_52AB_6769, 0x5FFE_6EC8_5E7D_E30D);
            //
            //UInt128 y = MAGIC.value - (x.value >> 1);
            //
            //quadruple g = asquadruple(y);
            //
            //quadruple mHalfA = -0.5d * x;
            //quadruple threeHalfsG = (3d / 2d) * g;
            //
            //return mad(g * mHalfA, square(g), threeHalfsG);

            return 1 / sqrt(x);
        }

        /// <summary>       Returns the result of linearly interpolating from <paramref name="start"/> to <paramref name="end"/> using the interpolation parameter <paramref name="t"/>.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple lerp(quadruple start, quadruple end, quadruple t)
        {
            return mad(t, end - start, start);
        }

        /// <summary>       Returns the result of normalizing a floating point value <paramref name="x"/> to a range [<paramref name="start"/>, <paramref name="end"/>]. The opposite of lerp. Equivalent to (<paramref name="x"/> - <paramref name="start"/>) / (<paramref name="end"/> - <paramref name="start"/>).</summary>
        public static quadruple unlerp(quadruple start, quadruple end, quadruple x)
        {
            return (x - start) / (end - start);
        }

        /// <summary>       Returns the result of a non-clamping linear remapping of a value <paramref name="x"/> from source range [<paramref name="srcStart"/>, <paramref name="srcEnd"/>] to the destination range [<paramref name="dstStart"/>, <paramref name="dstEnd"/>].</summary>
        public static quadruple remap(quadruple srcStart, quadruple srcEnd, quadruple dstStart, quadruple dstEnd, float x)
        {
            return lerp(dstStart, dstEnd, unlerp(srcStart, srcEnd, x));
        }

        /// <summary>       Returns the result of clamping the value <paramref name="valueToClamp"/> into the interval (inclusive) [<paramref name="lowerBound"/>, <paramref name="upperBound"/>], where <paramref name="valueToClamp"/>, <paramref name="lowerBound"/> and <paramref name="upperBound"/> are float values.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple clamp(quadruple valueToClamp, quadruple lowerBound, quadruple upperBound)
        {
            return max(lowerBound, min(upperBound, valueToClamp));
        }

        /// <summary>       Returns the result of clamping the float value <paramref name="x"/> into the interval [0, 1].      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple saturate(quadruple x)
        {
            return clamp(x, 0, 1);
        }

        /// <summary>       Returns the dot product of two float values. Equivalent to multiplication.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple dot(quadruple x, quadruple y)
        {
            return x * y;
        }

        /// <summary>       Returns the fractional part of a <see cref="quadruple"/> value.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple frac(quadruple x)
        {
            return x - floor(x);
        }

        /// <summary>       Returns the sign of a <see cref="quadruple"/> value. -1 if it is less than zero, 0 if it is zero and 1 if it is greater than zero.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sign(quadruple x)
        {
            int signBit = (int)(x.value.hi64 >> 63);
            int isNonZero;
            int isNegative = signBit;

            if (COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO)
            {
                UInt128 withoutSignBit = x.value << 1;
                isNonZero = tobyte(withoutSignBit.IsNotZero);
                isNegative &= isNonZero;
            }
            else
            {
                isNonZero = tobyte(x.value.IsNotZero);
            }

            int isPositive = andnot(isNonZero, signBit);
            return isPositive - isNegative;
        }

        /// <summary>       Splits a <see cref="quadruple"/> value into an integral part <paramref name="i"/> and a fractional part that gets returned. Both parts take the sign of the input.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple modf(quadruple x, out quadruple i)
        {
            return x - (i = trunc(x));
        }

        /// <summary>       Returns the length of a <see cref="quadruple"/> value. Equivalent to the absolute value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple length(quadruple x)
        {
            return abs(x);
        }

        /// <summary>       Returns the squared length of a <see cref="quadruple"/> value. Equivalent to squaring the value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple lengthsq(quadruple x)
        {
            return x * x;
        }

        /// <summary>       Returns the distance between two <see cref="quadruple"/> values.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple distance(quadruple x, quadruple y)
        {
            return abs(y - x);
        }

        /// <summary>       Returns the squared distance between two <see cref="quadruple"/> values.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple distancesq(quadruple x, quadruple y)
        {
            return square(y - x);
        }

        /// <summary>       Returns a smooth Hermite interpolation between 0.0 and 1.0 when <paramref name="x"/> is in the interval (inclusive) [<paramref name="xMin"/>, <paramref name="xMax"/>].        </summary>
        public static quadruple smoothstep(quadruple xMin, quadruple xMax, quadruple x)
        {
            quadruple t = saturate((x - xMin) / (xMax - xMin));
            return square(t) * mad(t, -2.0, 3.0);
        }

        /// <summary>       Returns the result of a step function where the result is 1.0 when <paramref name="x"/> <see langword=">="/> <paramref name="threshold"/> and 0.0 otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple step(quadruple threshold, quadruple x)
        {
            return select(0.0, 1.0, x >= threshold);
        }

        /// <summary>       Returns the average value of two <see cref="quadruple"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple avg(quadruple x, quadruple y)
        {
            if (constexpr.IS_CONST(x))
            {
                return mad(0.5, y, 0.5 * x);
            }
            if (constexpr.IS_CONST(y))
            {
                return mad(0.5, x, 0.5 * y);
            }

            return 0.5d * (x + y);
        }

        /// <summary>       Returns the componentwise fast approximate reciprocal a <see cref="quadruple"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple fastrcp(quadruple x)
        {
            return rcp(x);
        }

        /// <summary>       Returns the result of the fast approximate division of two <see cref="quadruple"/>s       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple div(quadruple dividend, quadruple divisor, bool fast = false)
        {
            return fast ? dividend * fastrcp(divisor) : dividend / divisor;
        }

        /// <summary>       Returns the truncated quotient of the <paramref name="dividend"/> divided by the <paramref name="divisor"/> with the <paramref name="remainder"/> as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple divrem(quadruple dividend, quadruple divisor, out quadruple remainder, bool fastApproximate = false)
        {
            remainder = divisor * modf(div(dividend, divisor, fastApproximate), out quadruple quotient);

            return quotient;
        }

        /// <summary>       Returns the result of a divide-add operation (<paramref name="a"/> <see langword="/"/> <paramref name="b"/> <see langword="+"/> <paramref name="c"/>) on 3 <see cref="quadruple"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple dad(quadruple a, quadruple b, quadruple c, bool fast = false)
        {
            return mad(a, fast ? fastrcp(b) : rcp(b), c);
        }

        /// <summary>       Returns the result of a divide-subtract operation (<paramref name="a"/> <see langword="/"/> <paramref name="b"/> <see langword="-"/> <paramref name="c"/>) on 3 <see cref="quadruple"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple dsub(quadruple a, quadruple b, quadruple c, bool fast = false)
        {
            return mad(a, fast ? fastrcp(b) : rcp(b), -c);
        }

        /// <summary>       Adds <paramref name="x"/> and <paramref name="y"/> and returns the result, which is clamped to <see cref="quadruple.MaxValue"/> if overflow occurs or <see cref="quadruple.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple addsaturated(quadruple x, quadruple y)
        {
            return clamp(x + y, quadruple.MinValue, quadruple.MaxValue);
        }

        /// <summary>       Subtracts <paramref name="y"/> from <paramref name=x"/> and returns the result, which is clamped to <see cref="quadruple.MaxValue"/> if overflow occurs or <see cref="quadruple.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple subsaturated(quadruple x, quadruple y)
        {
            return clamp(x - y, quadruple.MinValue, quadruple.MaxValue);
        }

        /// <summary>       Multiplies <paramref name="x"/> with <paramref name="y"/> and returns the result, which is clamped to <see cref="quadruple.MaxValue"/> if overflow occurs or <see cref="quadruple.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple mulsaturated(quadruple x, quadruple y)
        {
            return clamp(x * y, quadruple.MinValue, quadruple.MaxValue);
        }

        /// <summary>       Divides <paramref name="x"/> by <paramref name="y"/> and returns the result, which is clamped to <see cref="quadruple.MaxValue"/> if overflow occurs or <see cref="quadruple.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple divsaturated(quadruple x, quadruple y)
        {
            return clamp(x / y, quadruple.MinValue, quadruple.MaxValue);
        }

        /// <summary>       Casts the <see cref="quadruple"/> <paramref name="x"/> to a <see cref="byte"/> and returns the result, which is clamped to the interval [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte tobytesaturated(quadruple x)
        {
            return (byte)clamp(x, byte.MinValue, byte.MaxValue);
        }

        /// <summary>       Casts the <see cref="quadruple"/> <paramref name="x"/> to an <see cref="sbyte"/> and returns the result, which is clamped to the interval [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte tosbytesaturated(quadruple x)
        {
            return (sbyte)clamp(x, sbyte.MinValue, sbyte.MaxValue);
        }

        /// <summary>       Casts the <see cref="quadruple"/> <paramref name="x"/> to a <see cref="ushort"/> and returns the result, which is clamped to the interval [<see cref="ushort.MinValue"/>, <see cref="ushort.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort toushortsaturated(quadruple x)
        {
            return (ushort)clamp(x, ushort.MinValue, ushort.MaxValue);
        }

        /// <summary>       Casts the <see cref="quadruple"/> <paramref name="x"/> to a <see cref="short"/> and returns the result, which is clamped to the interval [<see cref="short.MinValue"/>, <see cref="short.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short toshortsaturated(quadruple x)
        {
            return (short)clamp(x, short.MinValue, short.MaxValue);
        }

        /// <summary>       Casts the <see cref="quadruple"/> <paramref name="x"/> to a <see cref="uint"/> and returns the result, which is clamped to the interval [<see cref="uint.MinValue"/>, <see cref="uint.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint touintsaturated(quadruple x)
        {
            return (uint)clamp(x, uint.MinValue, uint.MaxValue);
        }

        /// <summary>       Casts the <see cref="quadruple"/> <paramref name="x"/> to an <see cref="int"/> and returns the result, which is clamped to the interval [<see cref="uint.MinValue"/>, <see cref="uint.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int tointsaturated(quadruple x)
        {
            return (int)clamp(x, int.MinValue, int.MaxValue);
        }

        /// <summary>       Casts the <see cref="quadruple"/> <paramref name="x"/> to a <see cref="ulong"/> and returns the result, which is clamped to the longerval [<see cref="ulong.MinValue"/>, <see cref="ulong.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong toulongsaturated(quadruple x)
        {
            return (ulong)clamp(x, ulong.MinValue, ulong.MaxValue);
        }

        /// <summary>       Casts the <see cref="quadruple"/> <paramref name="x"/> to a <see cref="long"/> and returns the result, which is clamped to the longerval [<see cref="ulong.MinValue"/>, <see cref="ulong.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long tolongsaturated(quadruple x)
        {
            return (long)clamp(x, long.MinValue, long.MaxValue);
        }

        /// <summary>       Casts the <see cref="quadruple"/> <paramref name="x"/> to a <see cref="UInt128"/> and returns the result, which is clamped to the Int128erval [<see cref="uInt128.MinValue"/>, <see cref="uInt128.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 touint128saturated(quadruple x)
        {
            return (UInt128)clamp(x, UInt128.MinValue, UInt128.MaxValue);
        }

        /// <summary>       Casts the <see cref="quadruple"/> <paramref name="x"/> to an <see cref="Int128"/> and returns the result, which is clamped to the Int128erval [<see cref="uInt128.MinValue"/>, <see cref="uInt128.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 toint128saturated(quadruple x)
        {
            return (Int128)clamp(x, Int128.MinValue, Int128.MaxValue);
        }

        /// <summary>       Casts the <see cref="quadruple"/> <paramref name="x"/> to a <see cref="MaxMath.quarter"/> and returns the result, which is clamped to the Int128erval [<see cref="uInt128.MinValue"/>, <see cref="uInt128.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter toquartersaturated(quadruple x)
        {
            return (quarter)clamp(x, quarter.MinValue, quarter.MaxValue);
        }

        /// <summary>       Casts the <see cref="quadruple"/> <paramref name="x"/> to a <see cref="Unity.Mathematics.half"/> and returns the result, which is clamped to the Int128erval [<see cref="uInt128.MinValue"/>, <see cref="uInt128.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half tohalfsaturated(quadruple x)
        {
            return (half)clamp(x, Unity.Mathematics.half.MinValueAsHalf, Unity.Mathematics.half.MaxValueAsHalf);
        }

        /// <summary>       Casts the <see cref="quadruple"/> <paramref name="x"/> to a <see cref="float"/> and returns the result, which is clamped to the Int128erval [<see cref="uInt128.MinValue"/>, <see cref="uInt128.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float tofloatsaturated(quadruple x)
        {
            return (float)clamp(x, float.MinValue, float.MaxValue);
        }

        /// <summary>       Casts the <see cref="quadruple"/> <paramref name="x"/> to a <see cref="double"/> and returns the result, which is clamped to the Int128erval [<see cref="uInt128.MinValue"/>, <see cref="uInt128.MaxValue"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double todoublesaturated(quadruple x)
        {
            return (double)clamp(x, double.MinValue, double.MaxValue);
        }

        /// <summary>       Returns <paramref name="x"/> rounded to the nearest greater multiple of <paramref name="m"/> &gt; 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple ceilmultiple(quadruple x, quadruple m)
        {
Assert.IsGreater(m, 0);

            return m * ceil(x / m);
        }

        /// <summary>       Returns <paramref name="x"/> rounded to the nearest multiple toward 0 of <paramref name="m"/> &gt; 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple truncmultiple(quadruple x, quadruple m)
        {
Assert.IsGreater(m, 0);

            return m * trunc(x / m);
        }

        /// <summary>       Returns <paramref name="x"/> rounded to the nearest multiple of <paramref name="m"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple roundmultiple(quadruple x, quadruple m)
        {
Assert.IsGreater(m, 0);

            return m * round(x / m);
        }

        /// <summary>       Returns <paramref name="x"/> rounded to the nearest smaller multiple of <paramref name="m"/> &gt; 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple floormultiple(quadruple x, quadruple m)
        {
Assert.IsGreater(m, 0);

            return m * floor(x / m);
        }

        ///<summary>        Returns the result of performing a reversal of the byte order of a <see cref="quadruple"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple reversebytes(quadruple x)
        {
            return asquadruple(reversebytes(asuint128(x)));
        }

        /// <summary>       Negates the <see cref="quadruple"/> <paramref name="x"/> if the <see cref="bool"/> <paramref name="p"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple negate(quadruple x, bool p)
        {
Assert.IsSafeBoolean(p);

            return new quadruple(x.value.lo64, x.value.hi64 ^ (toulong(p) << 63));
        }

        /// <summary>       Returns the maximum of two <see cref="quadruple"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>), the sign of the return value is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple maxmag(quadruple a, quadruple b)
        {
            return select(b, a, abs(a) > abs(b));
        }

        /// <summary>       Returns the minimum of two <see cref="quadruple"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>), the sign of the return value is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple minmag(quadruple a, quadruple b)
        {
            return select(a, b, abs(a) > abs(b));
        }

        /// <summary>       Returns the minimum '<paramref name="minmag"/>' and maximum '<paramref name="maxmag"/>' of two <see cref="quadruple"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>), the sign of the return values are undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmaxmag(quadruple a, quadruple b, [NoAlias] out quadruple minmag, [NoAlias] out quadruple maxmag)
        {
            bool aMax = abs(a) > abs(b);

            minmag = select(a, b, aMax);
            maxmag = select(b, a, aMax);
        }

        /// <summary>       Returns the minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="quadruple"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(quadruple a, quadruple b, [NoAlias] out quadruple min, [NoAlias] out quadruple max)
        {
            bool aLTb = a < b;

            min = select(b, a, aLTb);
            max = select(a, b, aLTb);
        }

        /// <summary>       Returns the smallest difference of two angles as <see cref="quadruple"/>s in unsigned radians.      </summary>
        public static quadruple angledelta(quadruple a, quadruple b)
        {
            return repeat(b - a, TAU_QUAD);
        }

        /// <summary>       Returns the smallest difference of two angles as <see cref="quadruple"/>s in signed radians.      </summary>
        public static quadruple angledeltasgn(quadruple a, quadruple b)
        {
            quadruple deltas = angledelta(a, b);

            return select(deltas, deltas - TAU_QUAD, deltas > PI_QUAD);
        }

        /// <summary>       Returns the smallest difference of two angles as <see cref="quadruple"/>s in unsigned degrees.      </summary>
        public static quadruple angledeltadeg(quadruple a, quadruple b)
        {
            return repeat(b - a, 360);
        }

        /// <summary>       Returns the smallest difference of two angles as <see cref="quadruple"/>s in signed degrees.      </summary>
        public static quadruple angledeltasgndeg(quadruple a, quadruple b)
        {
            quadruple delta = angledeltadeg(a, b);

            return select(delta, delta - 360, delta > 180);
        }

        /// <summary>       Interpolates between the <see cref="quadruple"/>s <paramref name="from"/> and <paramref name="to"/> with smoothing at the limits if <paramref name="t"/> is within the interval [0, 1].     </summary>
        public static quadruple smoothlerp(quadruple from, quadruple to, quadruple t)
        {
            quadruple t2 = t + t;
            quadruple t3 = 3 * t;
            t *= mad(-t, t2, t3);

            return mad(t,
                       to,
                       mad(t,
                           -from,
                           from));
        }

        /// <summary>       Ping-Pongs the <see cref="quadruple"/> <paramref name="x"/>, so that it is never larger than the <see cref="quadruple"/> length and never smaller than 0.    </summary>
        public static quadruple pingpong(quadruple x, quadruple length)
        {
            return length - abs(repeat(x, length + length) - length);
        }

        /// <summary>       Loops the <see cref="quadruple"/> <paramref name="x"/>, so that it is never larger than the <see cref="quadruple"/> <paramref name="length"/> and never smaller than 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple repeat(quadruple x, quadruple length)
        {
            return clamp(quadruple.fnmadd(length,
                                          floor(x / length),
                                          x),
                         0,
                         length);
        }

        /// <summary>       Converts a <see cref="quadruple"/> to its <see cref="bool"/> representation. The underlying value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool tobool(quadruple a)
        {
Assert.IsTrue(a == 1 || a == 0);

            return asuint128(a) == asuint128((quadruple)1);
        }

        /// <summary>       Converts a <see cref="quadruple"/> to its <see cref="bool"/> representation. The underlying value is being clamped to the interval [0,1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool toboolsafe(quadruple a)
        {
            if (COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO)
            {
                return (a.value << 1).IsNotZero;
            }
            else
            {
                return a.value.IsNotZero;
            }
        }

        /// <summary>       Converts a <see cref="quadruple"/> to its <see cref="MaxMath.quarter"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for input values outside the interval [-15.5, 15.5].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values, including negative 0.        </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values that would result in a subnormal <see cref="quarter"/> value, which applies to input values with an absolute value that lies in the interval (0.0078125, 0.234375].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter toquarterunsafe(quadruple x, Promise promise = Promise.NoOverflow)
        {
            return quadruple.ToQuarter(x, promiseInRange: promise.Promises(Promise.NoOverflow), promiseAbs: promise.Promises(Promise.ZeroOrGreater), promiseNotSubnormal: promise.Promises(Promise.Unsafe0));
        }
        
        /// <summary>       Converts a <see cref="quadruple"/> to its <see cref="Unity.Mathematics.half"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for input values outside the interval [-65504, 65504].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values, including negative 0.        </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values that would result in a subnormal <see cref="half"/> value, which applies to input values with an absolute value that lies in the interval (2.98023223876953125E-8, 6.0975551605224609375E-5].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half tohalfunsafe(quadruple x, Promise promise = Promise.NoOverflow)
        {
            return quadruple.ToHalf(x, promiseInRange: promise.Promises(Promise.NoOverflow), promiseAbs: promise.Promises(Promise.ZeroOrGreater), promiseNotSubnormal: promise.Promises(Promise.Unsafe0));
        }
        
        /// <summary>       Converts a <see cref="quadruple"/> to its <see cref="float"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for input values outside the interval [-3.40282346638528859811704183484516925440e+38, 3.40282346638528859811704183484516925440e+38].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values, including negative 0.        </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values that would result in a subnormal <see cref="half"/> value, which applies to input values with an absolute value that lies in the interval (7.006492321624085354618647916449581E-46, 1.1754942106924410754870294448492873E-38].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float tofloatunsafe(quadruple x, Promise promise = Promise.NoOverflow)
        {
            return quadruple.ToFloat(x, promiseInRange: promise.Promises(Promise.NoOverflow), promiseAbs: promise.Promises(Promise.ZeroOrGreater), promiseNotSubnormal: promise.Promises(Promise.Unsafe0));
        }
        
        /// <summary>       Converts a <see cref="quadruple"/> to its <see cref="double"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for input values outside the interval [-1.797693134862315708145274237317043567981e+308, 1.797693134862315708145274237317043567981e+308].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values, including negative 0.        </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values that would result in a subnormal <see cref="half"/> value, which applies to input values with an absolute value that lies in the interval (2.470328229206232720882843964341107E-324, 2.2250738585072008890245868760858599E-308].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double todoubleunsafe(quadruple x, Promise promise = Promise.NoOverflow)
        {
            return quadruple.ToDouble(x, promiseInRange: promise.Promises(Promise.NoOverflow), promiseAbs: promise.Promises(Promise.ZeroOrGreater), promiseNotSubnormal: promise.Promises(Promise.Unsafe0));
        }
        
        /// <summary>       Converts a <see cref="quarter"/> to its <see cref="quadruple"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for input values outside the interval [-1.18973149535723176508575932662800701619646905264e+4932, 1.797693134862315708145274237317043567981e+4932].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values, including negative 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple toquadrupleunsafe(quarter q, Promise promise = Promise.Nothing)
        {
            return quadruple.FromQuarter(q, promiseInRange: promise.Promises(Promise.NoOverflow), promiseAbs: promise.Promises(Promise.ZeroOrGreater));
        }
        
        /// <summary>       Converts a <see cref="quarter"/> to its <see cref="quadruple"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for input values outside the interval [-1.18973149535723176508575932662800701619646905264e+4932, 1.797693134862315708145274237317043567981e+4932].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values, including negative 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple toquadrupleunsafe(half h, Promise promise = Promise.Nothing)
        {
            return quadruple.FromHalf(h, promiseInRange: promise.Promises(Promise.NoOverflow), promiseAbs: promise.Promises(Promise.ZeroOrGreater));
        }
        
        /// <summary>       Converts a <see cref="quarter"/> to its <see cref="quadruple"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for input values outside the interval [-1.18973149535723176508575932662800701619646905264e+4932, 1.797693134862315708145274237317043567981e+4932].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values, including negative 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple toquadrupleunsafe(float f, Promise promise = Promise.Nothing)
        {
            return quadruple.FromFloat(f, promiseInRange: promise.Promises(Promise.NoOverflow), promiseAbs: promise.Promises(Promise.ZeroOrGreater));
        }
        
        /// <summary>       Converts a <see cref="quarter"/> to its <see cref="quadruple"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for input values outside the interval [-1.18973149535723176508575932662800701619646905264e+4932, 1.797693134862315708145274237317043567981e+4932].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values, including negative 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple toquadrupleunsafe(double d, Promise promise = Promise.Nothing)
        {
            return quadruple.FromDouble(d, promiseInRange: promise.Promises(Promise.NoOverflow), promiseAbs: promise.Promises(Promise.ZeroOrGreater));
        }
        

        /// <summary>       Converts a <see cref="bool"/> to its <see cref="quadruple"/> representation. The underlying value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple toquadruple(bool a)
        {
            return new quadruple(0, a ? ((quadruple)1).value.hi64 : 0);
        }

        /// <summary>       Converts a <see cref="bool"/> to its <see cref="quadruple"/> representation. The underlying value is being clamped to the interval [0,1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple toquadruplesafe(bool a)
        {
            return toquadruple(a);
        }


        /// <summary>       Returns the base-2 exponential of <paramref name="x"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any x outside the interval [-2047, 2048].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple exp2(Int128 x, Promise noOverflow = Promise.Nothing)
        {
            long hi = (long)x.lo64;
            if (!noOverflow.Promises(Promise.NoOverflow))
            {
                hi = math.clamp(hi, nabs((long)quadruple.EXPONENT_BIAS), math.abs((long)quadruple.EXPONENT_BIAS) + 1);
            }

            hi = (math.abs((long)quadruple.EXPONENT_BIAS) << quadruple.MANTISSA_BITS_HI64) + (hi << quadruple.MANTISSA_BITS_HI64);

            return new quadruple(0, (ulong)hi);
        }

        /// <summary>       Returns the base-2 exponential of <paramref name="x"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any x outside the interval [0, 128].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple exp2(UInt128 x, Promise noOverflow = Promise.Nothing)
        {
            ulong hi = x.lo64;
            if (!noOverflow.Promises(Promise.NoOverflow))
            {
                hi = math.min(hi, (ulong)math.abs((long)quadruple.EXPONENT_BIAS) + 1);
            }

            return exp2((Int128)x, Promise.NoOverflow);
        }
        
        //public static quadruple pow(quadruple x, quadruple y)
        //{
        //    quadruple* bp = stackalloc quadruple[]
        //    {
        //        1,
        //        1.5,
        //    };
        //
        //    quadruple* dp_h = stackalloc quadruple[]
        //    {
        //        0,
        //        new quadruple(0x0000_0000_0000_0000, 0x3FFE_2B80_3473_F7AD)
        //    };
        //
        //    quadruple* dp_l = stackalloc quadruple[]
        //    {
        //        0,
        //        new quadruple(0xA2EB_7449_3CF9_A8E8, 0x3FC9_E7E8_02C4_8281)
        //    };
        //
        //
        //    quadruple zero = 0,
        //      one = 1,
        //      two = 2,
        //      two113 = new quadruple(0x9569_7AB5_E277_DE16, 0x3FFF_09D8_792F_B4C4);
        //
        //    quadruple* LN = stackalloc quadruple[]
        //    {
        //        new quadruple(0x61D8_61C0_269F_C673, 0x4082_2172_2C7D_A2C0),
        //        new quadruple(0x0B64_1C5D_E59B_59C6, 0x4083_3244_5746_0549),
        //        new quadruple(0x1DAF_339D_EEA2_BEA9, 0x4082_B386_4DBC_D539),
        //        new quadruple(0x8C54_BFCA_C72E_3F7D, 0x4080_D694_EC41_5DB4),
        //        new quadruple(0xD1FB_8916_3835_3084, 0x3FFE_FC3F_1F7D_5799)
        //    };
        //    quadruple* LD = stackalloc quadruple[]
        //    {
        //        new quadruple(0x2D20_8255_88D7_8EFB, 0x407F_81ED_90A7_83AB),
        //        new quadruple(0x8EEA_44A0_2C1C_29EB, 0x407A_5D8F_5691_D39C),
        //        new quadruple(0x08E0_47B9_836B_8937, 0x407A_6EE6_6B28_AF52),
        //        new quadruple(0xE781_7F3C_9F17_0811, 0x4080_1030_C1CA_E488),
        //        new quadruple(0x13EE_5B85_544D_803C, 0x407D_C1A4_E5AA_0A97)
        //    };
        //    quadruple* PN = stackalloc quadruple[]
        //    {
        //        new quadruple(0x889E_4C97_680D_01D7, 0x4068_40B4_EF2E_94CA),
        //        new quadruple(0xC2A0_DB67_F5FC_AD9B, 0x406F_CD87_1C04_317A),
        //        new quadruple(0xADD8_8219_FCAB_8848, 0x4075_449C_9AEE_2AD1),
        //        new quadruple(0x70A0_620B_C24A_6E63, 0x407F_8747_BDE7_1ACE),
        //        new quadruple(0x9CC0_10B8_DCC7_94E8, 0x3FF8_29CE_C291_D944)
        //    };
        //    quadruple* PD = stackalloc quadruple[]
        //    {
        //        new quadruple(0xB65A_86F7_C00C_7CB9, 0x4064_33E0_E59D_5BA3),
        //        new quadruple(0xD5F8_5004_0697_8761, 0x4066_0E10_6500_AB61),
        //        new quadruple(0xFF46_23E5_EF07_658F, 0x4072_FD04_1C42_E007),
        //        new quadruple(0xCDEB_DAFD_F92F_A62A, 0x4077_68A5_82D8_60DF)
        //    };
        //
        //    quadruple
        //      lg2_h = new quadruple(0xF000_0000_0000_0000, 0x3FFE_62E4_2FEF_A39E),
        //      lg2_l = new quadruple(0xF2F6_AF40_F343_2672, 0x3FC7_ABC9_E3B3_9803),
        //      ovt   = new quadruple(0xE459_FDE3_A492_DA6C, 0x3FC9_7154_7652_B82F),
        //      cp    = new quadruple(0xD749_FC15_522B_C2F8, 0x3FFE_EC70_9DC3_A03F),
        //      cp_h  = new quadruple(0xD000_0000_0000_0000, 0x3FFE_EC70_9DC3_A03F),
        //      cp_l  = new quadruple(0xBE29_B09C_E4FC_7094, 0x3FC8_D27F_0554_8AF0);
        //
        //    quadruple z, ax, z_h, z_l, p_h, p_l;
        //    quadruple y1, t1, t2, r, s, sgn, t, u, v, w;
        //    quadruple s2, s_h, s_l, t_h, t_l, ay;
        //    int i, j, k, yisint, n;
        //    uint ix, iy;
        //    int hx, hy;
        //    quadruple o, p, q;
        //
        //    p = x;
        //    hx = (int)(p.value.hi64 >> 32);
        //    ix = (uint)hx & 0x7fffffff;
        //
        //    q = y;
        //    hy = (int)(q.value.hi64 >> 32);
        //    iy = (uint)hy & 0x7fffffff;
        //
        //
        //    /* y==zero: x**0 = 1 */
        //    if ((iy | (uint)(q.value.hi64) | (uint)(q.value.lo64 >> 32) | (uint)(q.value.lo64)) == 0
        //        && !isnan (x))
        //      return one;
        //
        //    /* 1.0**y = 1; -1.0**+-Inf = 1 */
        //    if (x == one && !isnan (y))
        //      return one;
        //    if (x == -1 && iy == 0x7fff0000
        //        && ((uint)(q.value.hi64) | (uint)(q.value.lo64 >> 32) | (uint)(q.value.lo64)) == 0)
        //      return one;
        //
        //    /* +-NaN return x+y */
        //    if ((ix > 0x7fff0000)
        //        || ((ix == 0x7fff0000)
	    //          && (((uint)(p.value.hi64) | (uint)(p.value.lo64 >> 32) | (uint)(p.value.lo64)) != 0))
        //        || (iy > 0x7fff0000)
        //        || ((iy == 0x7fff0000)
	    //          && (((uint)(q.value.hi64) | (uint)(q.value.lo64 >> 32) | (uint)(q.value.lo64)) != 0)))
        //      return x + y;
        //
        //    /* determine if y is an odd int when x < 0
        //     * yisint = 0       ... y is not an integer
        //     * yisint = 1       ... y is an odd int
        //     * yisint = 2       ... y is an even int
        //     */
        //    yisint = 0;
        //    if (hx < 0)
        //      {
        //        if (iy >= 0x40700000)	/* 2^113 */
	    //        yisint = 2;		/* even integer y */
        //        else if (iy >= 0x3fff0000)	/* 1.0 */
	    //        {
	    //          if (floor(y) == y)
	    //            {
	    //              z = 0.5 * y;
	    //              if (floor(z) == z)
	    //        	yisint = 2;
	    //              else
	    //        	yisint = 1;
	    //            }
	    //        }
        //      }
        //
        //    /* special value of y */
        //    if (((uint)(q.value.hi64) | (uint)(q.value.lo64 >> 32) | (uint)(q.value.lo64)) == 0)
        //      {
        //        if (iy == 0x7fff0000)	/* y is +-inf */
	    //        {
	    //          if (((ix - 0x3fff0000) | (uint)(p.value.hi64) | (uint)(p.value.lo64 >> 32) | (uint)(p.value.lo64))
	    //              == 0)
	    //            return y - y;	/* +-1**inf is NaN */
	    //          else if (ix >= 0x3fff0000)	/* (|x|>1)**+-inf = inf,0 */
	    //            return (hy >= 0) ? y : zero;
	    //          else			/* (|x|<1)**-,+inf = inf,0 */
	    //            return (hy < 0) ? -y : zero;
	    //        }
        //        if (iy == 0x3fff0000)
	    //        {			/* y is  +-1 */
	    //          if (hy < 0)
	    //            return one / x;
	    //          else
	    //            return x;
	    //        }
        //        if (hy == 0x40000000)
	    //        return x * x;		/* y is  2 */
        //        if (hy == 0x3ffe0000)
	    //        {			/* y is  0.5 */
	    //          if (hx >= 0)		/* x >= +0 */
	    //            return sqrt(x);
	    //        }
        //      }
        //
        //    ax = abs(x);
        //    /* special value of x */
        //    if (((uint)(p.value.hi64) | (uint)(p.value.lo64 >> 32) | (uint)(p.value.lo64)) == 0)
        //      {
        //        if (ix == 0x7fff0000 || ix == 0 || ix == 0x3fff0000)
	    //        {
	    //          z = ax;		/*x is +-0,+-inf,+-1 */
	    //          if (hy < 0)
	    //            z = one / z;	/* z = (1/|x|) */
	    //          if (hx < 0)
	    //            {
	    //              if (((ix - 0x3fff0000) | (uint)yisint) == 0)
	    //        	{
	    //        	  z = (z - z) / (z - z);	/* (-1)**non-int is NaN */
	    //        	}
	    //              else if (yisint == 1)
	    //        	z = -z;		/* (x<0)**odd = -(|x|**odd) */
	    //            }
	    //          return z;
	    //        }
        //      }
        //
        //    /* (x<0)**(non-int) is NaN */
        //    if (((((uint)hx >> 31) - 1) | (uint)yisint) == 0)
        //      return (x - x) / (x - x);
        //
        //    /* sgn (sign of result -ve**odd) = -1 else = 1 */
        //    sgn = one;
        //    if (((((uint)hx >> 31) - 1) | (uint)(yisint - 1)) == 0)
        //      sgn = -one;			/* (-ve)**(odd int) */
        //
        //    /* |y| is huge.
        //       2^-16495 = 1/2 of smallest representable value.
        //       If (1 - 1/131072)^y underflows, y > 1.4986e9 */
        //    if (iy > 0x401d654b)
        //      {
        //        /* if (1 - 2^-113)^y underflows, y > 1.1873e38 */
        //        if (iy > 0x407d654b)
	    //        {
	    //          if (ix <= 0x3ffeffff)
	    //            return (hy < 0) ? hugeQuadruple * hugeQuadruple : tinyQuadruple * tinyQuadruple;
	    //          if (ix >= 0x3fff0000)
	    //            return (hy > 0) ? hugeQuadruple * hugeQuadruple : tinyQuadruple * tinyQuadruple;
	    //        }
        //        /* over/underflow if x is not close to one */
        //        if (ix < 0x3ffeffff)
	    //        return (hy < 0) ? sgn * hugeQuadruple * hugeQuadruple : sgn * tinyQuadruple * tinyQuadruple;
        //        if (ix > 0x3fff0000)
	    //        return (hy > 0) ? sgn * hugeQuadruple * hugeQuadruple : sgn * tinyQuadruple * tinyQuadruple;
        //      }
        //
        //    quadruple pow2m128 = new quadruple(0, 0x3F7F_0000_0000_0000);
        //    ay = y > 0 ? y : -y;
        //    if (ay < pow2m128)
        //      y = y < 0 ? -pow2m128 : pow2m128;
        //
        //    n = 0;
        //    /* take care subnormal number */
        //    if (ix < 0x00010000)
        //      {
        //        ax *= two113;
        //        n -= 113;
        //        o = ax;
        //        ix = (uint)(o.value.hi64 >> 32);
        //      }
        //    n += (int)(((ix) >> 16) - 0x3fff);
        //    j = (int)ix & 0x0000ffff;
        //    /* determine interval */
        //    ix = (uint)j | 0x3fff0000;		/* normalize ix */
        //    if (j <= 0x3988)
        //      k = 0;			/* |x|<sqrt(3/2) */
        //    else if (j < 0xbb67)
        //      k = 1;			/* |x|<sqrt(3)   */
        //    else
        //      {
        //        k = 0;
        //        n += 1;
        //        ix -= 0x00010000;
        //      }
        //
        //    o = new quadruple(ax.value.lo64, (uint)ax.value.hi64 | ((ulong)ix << 32));
        //    ax = o;
        //
        //    /* compute s = s_h+s_l = (x-1)/(x+1) or (x-1.5)/(x+1.5) */
        //    u = ax - bp[k];		/* bp[0]=1.0, bp[1]=1.5 */
        //    v = one / (ax + bp[k]);
        //    s = u * v;
        //    s_h = s;
        //
        //    o = s_h;
        //    o = new quadruple(o.value.lo64 & 0xF800_0000_0000_0000, o.value.hi64);
        //    s_h = o;
        //    /* t_h=ax+bp[k] High */
        //    t_h = ax + bp[k];
        //    o = t_h;
        //    o = new quadruple(o.value.lo64 & 0xF800_0000_0000_0000, o.value.hi64);
        //    t_h = o;
        //    t_l = ax - (t_h - bp[k]);
        //    s_l = v * ((u - s_h * t_h) - s_h * t_l);
        //    /* compute log(ax) */
        //    s2 = s * s;
        //    u = LN[0] + s2 * (LN[1] + s2 * (LN[2] + s2 * (LN[3] + s2 * LN[4])));
        //    v = LD[0] + s2 * (LD[1] + s2 * (LD[2] + s2 * (LD[3] + s2 * (LD[4] + s2))));
        //    r = s2 * s2 * u / v;
        //    r += s_l * (s_h + s);
        //    s2 = s_h * s_h;
        //    t_h = 3.0 + s2 + r;
        //    o = t_h;
        //    o = new quadruple(o.value.lo64 & 0xF800_0000_0000_0000, o.value.hi64);
        //    t_h = o;
        //    t_l = r - ((t_h - 3.0) - s2);
        //    /* u+v = s*(1+...) */
        //    u = s_h * t_h;
        //    v = s_l * t_h + t_l * s;
        //    /* 2/(3log2)*(s+...) */
        //    p_h = u + v;
        //    o = p_h;
        //    o = new quadruple(o.value.lo64 & 0xF800_0000_0000_0000, o.value.hi64);
        //    p_h = o;
        //    p_l = v - (p_h - u);
        //    z_h = cp_h * p_h;		/* cp_h+cp_l = 2/(3*log2) */
        //    z_l = cp_l * p_h + p_l * cp + dp_l[k];
        //    /* log2(ax) = (s+.)*2/(3*log2) = n + dp_h + z_h + z_l */
        //    t = (quadruple)n;
        //    t1 = (((z_h + z_l) + dp_h[k]) + t);
        //    o = t1;
        //    o = new quadruple(o.value.lo64 & 0xF800_0000_0000_0000, o.value.hi64);
        //    t1 = o;
        //    t2 = z_l - (((t1 - t) - dp_h[k]) - z_h);
        //
        //    /* split up y into y1+y2 and compute (y1+y2)*(t1+t2) */
        //    y1 = y;
        //    o = y1;
        //    o = new quadruple(o.value.lo64 & 0xF800_0000_0000_0000, o.value.hi64);
        //    y1 = o;
        //    p_l = (y - y1) * t1 + y * t2;
        //    p_h = y1 * t1;
        //    z = p_l + p_h;
        //    o = z;
        //    j = (int)(o.value.hi64 >> 32);
        //    if (j >= 0x400d0000) /* z >= 16384 */
        //      {
        //        /* if z > 16384 */
        //        if (((uint)(j - 0x400d0000) | (uint)(o.value.hi64) | (uint)(o.value.lo64 >> 32) | (uint)(o.value.lo64)) != 0)
	    //        return sgn * hugeQuadruple * hugeQuadruple;	/* overflow */
        //        else
	    //        {
	    //          if (p_l + ovt > z - p_h)
	    //            return sgn * hugeQuadruple * hugeQuadruple;	/* overflow */
	    //        }
        //      }
        //    else if ((j & 0x7fffffff) >= 0x400d01b9)	/* z <= -16495 */
        //      {
        //        /* z < -16495 */
        //        if (((uint)(j - 0xc00d01bc) | (uint)(o.value.hi64) | (uint)(o.value.lo64 >> 32) | (uint)(o.value.lo64))
	    //          != 0)
	    //        return sgn * tinyQuadruple * tinyQuadruple;	/* underflow */
        //        else
	    //        {
	    //          if (p_l <= z - p_h)
	    //            return sgn * tinyQuadruple * tinyQuadruple;	/* underflow */
	    //        }
        //      }
        //    /* compute 2**(p_h+p_l) */
        //    i = j & 0x7fffffff;
        //    k = (i >> 16) - 0x3fff;
        //    n = 0;
        //    if (i > 0x3ffe0000)
        //      {				/* if |z| > 0.5, set n = [z+0.5] */
        //        t = floor(z + 0.5);
        //        n = (int)t;
        //        p_h -= t;
        //      }
        //    t = p_l + p_h;
        //    o = t;
        //    o = new quadruple(o.value.lo64 & 0xF800_0000_0000_0000, o.value.hi64);
        //    t = o;
        //    u = t * lg2_h;
        //    v = (p_l - (t - p_h)) * LN2_QUAD + t * lg2_l;
        //    z = u + v;
        //    w = v - (z - u);
        //    /*  exp(z) */
        //    t = z * z;
        //    u = PN[0] + t * (PN[1] + t * (PN[2] + t * (PN[3] + t * PN[4])));
        //    v = PD[0] + t * (PD[1] + t * (PD[2] + t * (PD[3] + t)));
        //    t1 = z - t * u / v;
        //    r = (z * t1) / (t1 - two) - (w + z * w);
        //    z = one - (r - z);
        //    o = z;
        //    j = (int)(o.value.hi64 >> 32);
        //    j += (n << 16);
        //    if ((j >> 16) <= 0)
        //      {
        //        z = scalbn(z, n);	/* subnormal output */
        //      }
        //    else
        //      {
        //        o = new quadruple(o.value.lo64, (uint)o.value.hi64 | ((ulong)(uint)j << 32));
        //        z = o;
        //      }
        //    return sgn * z;
        //}
//tan
//tanh
//atan
//atan2
//cos
//cosh
//acos
//sin
//sinh
//asin
//sincos
//asinh
//acosh
//atanh
//pow
//exp
//exp2
//exp10
//log
//log2
//log10
//erf
//erfc
//gamma
//hypot
    }
}
