using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;
using MaxMath.CompilerServices;

using static MaxMath.math;

namespace MaxMath
{
    unsafe public partial struct quadruple
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static long ExtractPow2ExponentShifted(quadruple.ConstChecked pow2)
        {
            long BIAS_SHIFTED = abs((long)EXPONENT_BIAS) << MANTISSA_BITS_HI64;
        
            UInt128 pBits = asuint128(pow2);
            ulong pFieldIsolated = pBits.hi64 & SIGNALING_EXPONENT.hi64;
        
            if (Hint.Likely(pFieldIsolated != 0)
             || constexpr.IS_TRUE(isnormal(pow2))
             || COMPILATION_OPTIONS.FLOAT_DENORMALS_ARE_ZERO)
            {
                return (long)pFieldIsolated - BIAS_SHIFTED;
            }
            else
            {
                const int DENORMAL_MANTISSA_EXPONENT = MIN_UNBIASED_EXPONENT - MANTISSA_BITS;
        
                UInt128 pMantissa = pBits & bitmask128((ulong)MANTISSA_BITS);
                int bitPos = 127 - lzcnt(pMantissa);
                int k = DENORMAL_MANTISSA_EXPONENT + bitPos;
                return (long)k << MANTISSA_BITS_HI64;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static quadruple ScaleByPow2(quadruple.ConstChecked x, quadruple.ConstChecked pow2, long kShifted)
        {
            const ulong SIGN_MASK_HI = 1ul << 63;
            const long FIELD_ONE_SHIFTED  = 1L << MANTISSA_BITS_HI64;
            long FIELD_MAX_NORMAL_SHIFTED = (long)SIGNALING_EXPONENT.hi64 - FIELD_ONE_SHIFTED;
        
            UInt128 xBits = asuint128(x);
            UInt128 pBits = asuint128(pow2);
        
            ulong resultSign = (xBits.hi64 & SIGN_MASK_HI) ^ (pBits.hi64 & SIGN_MASK_HI);
            ulong xFieldIsolated = xBits.hi64 & SIGNALING_EXPONENT.hi64;
        
            // predictable branch (x nonzero normal)
            if (Hint.Likely(xFieldIsolated != 0)
             || constexpr.IS_TRUE(isnormal(x))
             || x.Promise.NotSubnormal)
            {
                UInt128 xSignificand = xBits & bitmask128((ulong)MANTISSA_BITS);
        
                if ((!COMPILATION_OPTIONS.FLOAT_NO_NAN 
                   ||!COMPILATION_OPTIONS.FLOAT_NO_INF)
                  && (!x.Promise.NotNaN 
                   && !x.Promise.NotInf)
                  && Hint.Unlikely(xFieldIsolated == SIGNALING_EXPONENT.hi64))
                {
                    if (!COMPILATION_OPTIONS.FLOAT_NO_NAN 
                     && !x.Promise.NotNaN 
                     && xSignificand != 0)
                    {
                        return NaN;
                    }
                    else
                    {
                        return asquadruple(new UInt128(0, SIGNALING_EXPONENT.hi64 | resultSign));
                    }
                }
        
                long thresholdHi = FIELD_MAX_NORMAL_SHIFTED - (long)xFieldIsolated;
        
                // predictable branch (result becomes infinite)
                if (!COMPILATION_OPTIONS.FLOAT_NO_INF 
                 && Hint.Unlikely(kShifted > thresholdHi))
                {
                    ulong inf = SIGNALING_EXPONENT.hi64 | resultSign;
                    return asquadruple(new UInt128(0, inf));
                }
        
                long thresholdLo = FIELD_ONE_SHIFTED - (long)xFieldIsolated;
                    
                long newExpWork = (long)xFieldIsolated + kShifted;
                // predictable branch (result is and remains normal)
                if (Hint.Likely(kShifted >= thresholdLo))
                {
                    ulong newHi = (xBits.hi64 & bitmask64((ulong)MANTISSA_BITS_HI64)) | (ulong)newExpWork | resultSign;
                    return asquadruple(new UInt128(xBits.lo64, newHi));
                }
                else 
                {
                    if (COMPILATION_OPTIONS.FLOAT_DENORMALS_ARE_ZERO)
                    {
                        return COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO
                             ? asquadruple(new UInt128(0, resultSign))
                             : 0;
                    }
                    else
                    {
                        int newExponent = (int)(newExpWork >> MANTISSA_BITS_HI64) - abs(EXPONENT_BIAS);
                        xSignificand |= (UInt128)1 << MANTISSA_BITS;
            
                        return SubnormalResult(xSignificand, newExponent, resultSign);
                    }
                }
            }
            else
            {
                UInt128 xMantissa = xBits & bitmask128((ulong)MANTISSA_BITS);
        
                if (Hint.Likely(xMantissa == 0)
                 || COMPILATION_OPTIONS.FLOAT_DENORMALS_ARE_ZERO)
                {
                    return COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO
                         ? asquadruple(new UInt128(0, resultSign))
                         : 0;
                }
        
                int msb = 127 - lzcnt(xMantissa);
                int shiftToNormalize = MANTISSA_BITS - msb;
                UInt128 xSignificand = xMantissa << shiftToNormalize;
                int xExponent = MIN_UNBIASED_EXPONENT - shiftToNormalize;
        
                int k = (int)(kShifted >> MANTISSA_BITS_HI64);
                int newExponent = xExponent + k;
                        
                // predictable branch (result becomes infinite)
                if (!COMPILATION_OPTIONS.FLOAT_NO_INF 
                 && Hint.Unlikely(newExponent > abs(EXPONENT_BIAS)))
                {
                    ulong inf = SIGNALING_EXPONENT.hi64 | resultSign;
                    return asquadruple(new UInt128(0, inf));
                }
        
                // somewhat unpredictable branch :( (result becomes normal)
                if (Hint.Likely(newExponent >= MIN_UNBIASED_EXPONENT))
                {
                    UInt128 storedMantissa = xSignificand & bitmask128((ulong)MANTISSA_BITS);
                    UInt128 storedExp = (UInt128)(uint)(newExponent - MIN_UNBIASED_EXPONENT + 1);
                    UInt128 r = (storedExp << MANTISSA_BITS) | storedMantissa;
                    return asquadruple(new UInt128(r.lo64, r.hi64 | resultSign));
                }
                
                return SubnormalResult(xSignificand, newExponent, resultSign);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static quadruple SubnormalResult(UInt128 xSignificand, int newExponent, ulong resultSign)
        {
            int shift = MIN_UNBIASED_EXPONENT - newExponent;
        
            UInt128 shifted = (shift == 128) ? 0 : (xSignificand >> shift);
            UInt128 guardMask = (UInt128)1 << (shift - 1);
        
            byte guard  = tobyte((xSignificand & guardMask) != 0);
            byte sticky = tobyte((xSignificand & (guardMask - 1)) != 0);
            byte lsb    = (byte)((byte)shifted & 1);
            shifted += (byte)(guard & (sticky | lsb));
        
            UInt128 r = select(select(shifted, 0, shift > 128), xSignificand << -shift, shift <= 0);
            return asquadruple(new UInt128(r.lo64, r.hi64 | resultSign));
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quadruple MultiplyByPowerOfTwo(quadruple.ConstChecked x, quadruple.ConstChecked pow2)
        {
            long kShifted = ExtractPow2ExponentShifted(pow2);
            return ScaleByPow2(x, pow2, kShifted);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quadruple DivideByPowerOfTwo(quadruple.ConstChecked x, quadruple.ConstChecked pow2)
        {
            long kShifted = ExtractPow2ExponentShifted(pow2);
            return ScaleByPow2(x, pow2, -kShifted);
        }
    }
}
