using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Burst.CompilerServices;
using MaxMath.CompilerServices;

using static MaxMath.math;
using static MaxMath.LUT.FLOATING_POINT;

namespace MaxMath
{
    unsafe public partial struct quadruple
    {
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
        private static void normSubnormalF8Sig(ref ulong exp, ref uint sig, bool nonZero = false)
        {
            byte16 shiftDistBase = new byte16(8, 7, 6, 6, 5, 5, 5, 5,    4, 4, 4, 4, 4, 4, 4, 4) - quarter.EXPONENT_BITS;

            exp = Hint.Likely(!nonZero && sig == 0) ? 0u : (ulong)(F8_EXPONENT_OFFSET - (uint)shiftDistBase[(int)sig]) << MANTISSA_BITS_HI64;
            sig <<= shiftDistBase[(int)sig];
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void normSubnormalF16Sig(ref ulong exp, ref uint sig, bool nonZero = false)
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
        private static void normSubnormalF32Sig(ref ulong exp, ref uint sig, bool nonZero = false)
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
        private static void normSubnormalF64Sig(ref ulong exp, ref ulong sig, bool nonZero = false)
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
        private static ulong expF128UI64(ulong a64) => (a64 & SIGNALING_EXPONENT.hi64) >> MANTISSA_BITS_HI64;

        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static UInt128 shortShiftLeft128(UInt128 a, byte dist)
        {
            constexpr.ASSUME(dist <= 63);
            constexpr.ASSUME(dist >= 0);
            constexpr.ASSUME((dist & 63) == dist);
            
            return a << dist;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static UInt128 shortShiftRight128(UInt128 a, byte dist)
        {
            constexpr.ASSUME(dist <= 63);
            constexpr.ASSUME(dist >= 0);
            constexpr.ASSUME((dist & 63) == dist);

            return a >> dist;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void normSubnormalF128Sig(ref ulong exp, ref UInt128 sig)
        {
            if (constexpr.IS_CONST(sig.hi64 == 0))
            {
                if (sig.hi64 == 0)
                {
                    int shiftDist = lzcnt(sig.lo64);
                    int shl = shiftDist - EXPONENT_BITS;

                    exp = (ulong)(EXPONENT_BITS - 63 - shiftDist);
                    sig = new UInt128(sig.lo64, 0) << (64 + shl);
                }
                else
                {
                    int shiftDist = lzcnt(sig.hi64);
                    int shl = shiftDist - EXPONENT_BITS;

                    exp = (ulong)(EXPONENT_BITS + 1 - shiftDist);
                    sig = shortShiftLeft128(sig, (byte)shl);
                }
            }
            else
            {
                int shiftDist = lzcnt(sig);
                int shl = shiftDist - EXPONENT_BITS;
                
                exp = (ulong)(EXPONENT_BITS + 1 - shiftDist);
                sig <<= shl;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void shiftLeftWide192(ulong H, ulong M, ulong L, int dist, out ulong newH, out ulong newM, out ulong newL)
        {
            constexpr.ASSUME(dist >= 0);
            constexpr.ASSUME(dist <= 191);

            if (constexpr.IS_CONST(dist))
            {
                if (dist == 0)
                {
                    newH = H; newM = M; newL = L;
                }
                else if (dist < 64)
                {
                    newH = (H << dist) | (M >> (64 - dist));
                    newM = (M << dist) | (L >> (64 - dist));
                    newL = L << dist;
                }
                else if (dist == 64)
                {
                    newH = M; newM = L; newL = 0;
                }
                else if (dist < 128)
                {
                    int d = dist - 64;
                    newH = (M << d) | (L >> (64 - d));
                    newM = L << d;
                    newL = 0;
                }
                else if (dist == 128)
                {
                    newH = L; newM = 0; newL = 0;
                }
                else
                {
                    int d = dist - 128;
                    newH = L << d;
                    newM = 0; newL = 0;
                }
            }
            else
            {
                __UInt256__ shl = new __UInt256__(L, M, H, 0) << dist;
                newL = shl._63;
                newM = shl._127;
                newH = shl._191;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static UInt128 shiftRightJam128(UInt128 a, int dist)
        {
            if (constexpr.IS_CONST(dist < 64)
             || COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
            {
                if (dist < 64)
                {
                    return new UInt128(a.hi64 << (64 - dist) | a.lo64 >> dist | tobyte(a.lo64 << (64 - dist) != 0),
                                       a.hi64 >> dist);
                }
                else
                {
                    return new UInt128((dist < 127) ? a.hi64 >> (dist & 63) | tobyte(((a.hi64 & ((1ul << (dist & 63)) - 1)) | a.lo64) != 0)
                                                    : tobyte((a.hi64 | a.lo64) != 0),
                                       0);
                }
            }
            else
            {
                return (dist < 127) 
                     ? (a >> dist) | tobyte((a << (-dist & 127)) != 0) 
                     : tobyte((a.lo64 | a.hi64) != 0);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static UInt128 shiftRightJam128Extra(UInt128 a, ulong extra, int dist, out ulong extraOut)
        {
            constexpr.ASSUME(dist > 0);

            UInt128 result;

            if (constexpr.IS_CONST(dist))
            {
                if (dist < 64)
                {
                    result = new UInt128(a.hi64 << (64 - dist) | a.lo64 >> dist, a.hi64 >> dist);
                    extraOut = a.lo64 << (64 - dist);
                }
                else
                {
                    if (dist == 64)
                    {
                        result = new UInt128(a.hi64, 0);
                        extraOut = a.lo64;
                    }
                    else
                    {
                        extra |= a.lo64;
                        if (dist < 128)
                        {
                            result = new UInt128(a.hi64 >> (dist & 63), 0);
                            extraOut = a.hi64 << (64 - dist);
                        }
                        else
                        {
                            result = new UInt128(0, 0);
                            extraOut = (dist == 128) ? a.hi64 : tobyte(a.hi64 != 0);
                        }
                    }
                }
                
                extraOut |= tobyte(extra != 0);
            }
            else
            {
                extraOut = ((uint)dist <= 64 ? a.lo64 : a.hi64) << (64 - dist);
                if (dist < 128)
                { 
                    result = a >> dist;
                }
                else
                {
                    result = 0;
                    extraOut = (dist == 128) ? a.hi64 : tobyte(a.hi64 != 0);
                }
                extraOut |= tobyte((extra | ((uint)dist <= 64 ? 0 : a.lo64)) != 0);
            }

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static UInt128 shortShiftRightJam128Extra(UInt128 a, ulong extra, int dist, out ulong extraOut)
        {
            constexpr.ASSUME(dist >= 0);
            constexpr.ASSUME(dist < 64);

            extraOut = a.lo64 << (64 - dist) | tobyte(extra != 0);
            return a >> dist;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static UInt128 shiftRightJamWideExtra(UInt128 a, ulong e, int dist, out ulong eOut)
        {
            if (constexpr.IS_CONST(dist))
            {
                if (dist == 0)
                {
                    eOut = e;
                    return a;
                }
                if (dist < 64)
                {
                    eOut = (a.lo64 << (64 - dist)) | (e >> dist) | tobyte((e & bitmask64((ulong)dist)) != 0);
                    return new UInt128((a.hi64 << (64 - dist)) | (a.lo64 >> dist), a.hi64 >> dist);
                }
                if (dist == 64)
                {
                    eOut = a.lo64 | tobyte(e != 0);
                    return new UInt128(a.hi64, 0);
                }
                if (dist < 128)
                {
                    int d = dist - 64;
                    eOut = (a.hi64 << (64 - d)) | (a.lo64 >> d) | tobyte(((a.lo64 & bitmask64((ulong)d)) != 0) | (e != 0));
                    return new UInt128(a.hi64 >> d, 0);
                }
                if (dist == 128)
                {
                    eOut = a.hi64 | tobyte((a.lo64 != 0) | (e != 0));
                    return new UInt128(0, 0);
                }
                if (dist < 192)
                {
                    int d = dist - 128;
                    eOut = (a.hi64 >> d) | tobyte(((a.hi64 & bitmask64((ulong)d)) != 0) | (a.lo64 != 0) | (e != 0));
                    return new UInt128(0, 0);
                }
                eOut = tobyte((a.hi64 | a.lo64 | e) != 0);
                return new UInt128(0, 0);
            }
            else
            {
                UInt128 topLo = a >> dist;
                ulong eLo = (a << (64 - dist)).lo64
                          | (e >> dist)
                          | tobyte((e & bitmask64((ulong)dist)) != 0);
            
                int dHi = dist - 64;
                UInt128 topHi = select(0, new UInt128(a.hi64, 0) >> dHi, dist < 128);
                ulong eHi = (a >> dHi).lo64
                          | tobyte((e != 0) | (a & bitmask128((ulong)dHi)).IsNotZero);
            
                bool useLo = dist < 64;
                eOut = select(eHi, eLo, useLo);
                return select(topHi, topLo, useLo);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static __UInt256__ shiftRightJam256M(__UInt256__ a, uint dist)
        {
            return dist >= 256 ? tobyte(a.hi128.IsNotZero)
                               : (a >> (int)dist) | (constexpr.IS_TRUE(dist <= 128) ? 0u
                                                                                    : tobyte((a & __UInt256__.bitmask256(dist)).IsNotZero));
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static UInt128 mul64ByShifted32To128(ulong a, uint b)
        {
            return ((UInt128)a * b) << 32;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static quadruple normRoundPackToF128(ulong sign, uint exp, UInt128 sig, bool noInf)
        {
            if (sig.hi64 == 0)
            {
                exp -= 64;
                sig <<= 64;
            }
            
            ulong sigExtra = 0;
            int shiftDist = lzcnt(sig.hi64) - EXPONENT_BITS;
            exp -= (uint)shiftDist;
            
            if (sig.hi64 <= bitmask64(64ul - EXPONENT_BITS))
            {
                if (sig.hi64 < 1ul << (64 - EXPONENT_BITS - 1))
                {
                    sig = shortShiftLeft128(sig, (byte)shiftDist);
                }
                if (exp < 0x7FFD)
                {
                    return new quadruple(sig.lo64, packToF128UI64(sign, sig != 0 ? (ulong)exp << MANTISSA_BITS_HI64 : 0, sig.hi64));
                }
            }
            else
            {
                sig = shortShiftRightJam128Extra(sig, 0, -shiftDist, out sigExtra);
            }
            
            return roundPackToF128(sign, exp, sig, sigExtra, noInf);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static quadruple roundPackToF128(ulong sign, ulong exp, UInt128 sig, ulong sigExtra, bool noInf)
        {
            bool doIncrement = ((UInt128)1 << (BITS - 1)).hi64 <= sigExtra;
            
            if ((bitmask64((ulong)EXPONENT_BITS) ^ 2) <= (uint)exp)
            {
                if ((long)exp < 0)
                {
                    sig = shiftRightJam128Extra(sig, sigExtra, -(int)exp, out sigExtra);
                    exp = 0;
                    doIncrement = ((UInt128)1 << (BITS - 1)).hi64 <= sigExtra;
                }
                else if (!noInf
                      && ((bitmask64((long)EXPONENT_BITS) ^ 2) < (int)exp
                      | ((exp == 0x7FFD)
                       & (sig == bitmask128((ulong)MANTISSA_BITS))
                       & doIncrement)))
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
        #endregion
    }
}