using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;
using MaxMath.Intrinsics;

using static MaxMath.maxmath;

namespace MaxMath
{
    unsafe public readonly partial struct quadruple
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quadruple.ConstChecked Remainder(quadruple.ConstChecked left, quadruple.ConstChecked right)
        {
            FloatingPointPromise<quadruple> finalPromise = default(FloatingPointPromise<quadruple>);
            //finalPromise |= left.Promise.Negative && right.Promise.Negative ? FloatingPointPromise<quadruple>.POSITIVE : Promise.Nothing;
            //finalPromise |= left.Promise.Positive && right.Promise.Positive ? FloatingPointPromise<quadruple>.POSITIVE : Promise.Nothing;
            //finalPromise |= left.Promise.Positive && right.Promise.Negative ? FloatingPointPromise<quadruple>.NEGATIVE : Promise.Nothing;
            //finalPromise |= left.Promise.Negative && right.Promise.Positive ? FloatingPointPromise<quadruple>.NEGATIVE : Promise.Nothing;
             
            ulong signA = left.Value.value.hi64 & (1ul << 63);
            ulong expA = left.Value.value.hi64 & SIGNALING_EXPONENT.hi64;
            ulong expB = right.Value.value.hi64 & SIGNALING_EXPONENT.hi64;
            UInt128 sigA = new UInt128(left.Value.value.lo64, fracF128UI64(left.Value.value.hi64));
            UInt128 sigB = new UInt128(right.Value.value.lo64, fracF128UI64(right.Value.value.hi64));
            
            UInt128 rem;
            UInt128 altRem;
            uint q;

            if (!(right.Promise.NonZero && right.Promise.NotSubnormal)
             && Hint.Unlikely(expB == 0)) 
            {
                if (COMPILATION_OPTIONS.FLOAT_DENORMALS_ARE_ZERO 
                 || sigB.IsZero)
                {
                    return NaN;
                }
                
                softfloat_normSubnormalF128Sig2(ref expB, ref sigB);
            }
            if (!(left.Promise.NonZero && left.Promise.NotSubnormal)
             && Hint.Unlikely(expA == 0)) 
            {
                if (COMPILATION_OPTIONS.FLOAT_DENORMALS_ARE_ZERO 
                 || sigA.IsZero)
                {
                    if ((!(right.Promise.NotNaN && right.Promise.NotInf) 
                     && Hint.Unlikely(expB == SIGNALING_EXPONENT.hi64))
                     & (!right.Promise.NotNaN 
                     && right.Value.value.lo64 != 0))
                    {
                        return NaN;
                    }
                    else
                    {
                        return left;
                    }
                }
                
                softfloat_normSubnormalF128Sig2(ref expA, ref sigA);
            }
    
            sigA = new UInt128(sigA.lo64, sigA.hi64 | (1ul << MANTISSA_BITS_HI64));
            sigB = new UInt128(sigB.lo64, sigB.hi64 | (1ul << MANTISSA_BITS_HI64));
            rem = sigA;
            long expDiff = (long)(expA - expB);
            
            if (!(left.Promise.NotNaN && left.Promise.NotInf) 
             && Hint.Unlikely(expA == SIGNALING_EXPONENT.hi64)) 
            {
                return NaN;
            }
            if (!(right.Promise.NotNaN && right.Promise.NotInf) 
             && Hint.Unlikely(expB == SIGNALING_EXPONENT.hi64)) 
            {
                if (!right.Promise.NotNaN 
                 && right.Value.value.lo64 != 0)
                {
                    return NaN;
                }
                else
                {
                    return left;
                }
            }

            finalPromise |= FloatingPointPromise<quadruple>.NOT_NAN;
            finalPromise |= FloatingPointPromise<quadruple>.NOT_INF;

            if (expDiff < 1L << MANTISSA_BITS_HI64) 
            {
                if (expDiff < -1L << MANTISSA_BITS_HI64) 
                { 
                    return left;
                }
                if (expDiff != 0) 
                {
                    expB--;
                    sigB += sigB;
                    q = 0;
                } 
                else 
                {
                    bool le = sigB <= rem;
                    q = tobyte(le);
                    if (le) 
                    {
                        rem -= sigB;
                    }
                }
            }
            else 
            {
                ulong recip32 = softfloat_approxRecip32_1((uint)(sigB.hi64 >> 17));
                expDiff >>= MANTISSA_BITS_HI64;
                expDiff -= 30;
                ulong q64;
                while (true) 
                {
                    q64 = (uint)(rem.hi64 >> 19) * recip32;
                    if (expDiff < 0) 
                    {
                        break;
                    }
                    q = (uint)((q64 + 0x8000_0000) >> 32);
                    rem <<= 29;
                    rem -= q * sigB;
                    if ((long)rem.hi64 < 0) 
                    {
                        rem += sigB;
                    }
                    expDiff -= 29;
                }
                constexpr.ASSUME(expDiff >= -29);
                q = (uint)(q64 >> 32) >> andnot(31, (int)expDiff);
                rem = softfloat_shortShiftLeft128(rem.hi64, rem.lo64, (byte)(expDiff + 30));
                rem -= q * sigB;
                if ((long)rem.hi64 < 0) 
                {
                    altRem = rem + sigB;
                    goto SELECT_REM;
                }
            }
            
            do 
            {
                altRem = rem;
                q++;
                rem -= sigB;
            } 
            while (Hint.Unlikely((long)rem.hi64 >= 0));
            
        SELECT_REM:
            UInt128 meanRem = rem + altRem;
            if (((long)meanRem.hi64 < 0)
              | (meanRem.IsZero & ((q & 1) != 0))) 
            {
                rem = altRem;
            }
            ulong signRem = (signA ^ rem.hi64) & (1ul << 63);
            rem = (UInt128)negate((Int128)rem, (long)rem.hi64 < 0);
            return new quadruple.ConstChecked(softfloat_normRoundPackToF128(signRem, (uint)(expB - 1), rem.hi64, rem.lo64), finalPromise);
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple operator % (quadruple left, quadruple right) => Remainder(left, right);
    }


    unsafe public static partial class maxmath
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple fmod(quadruple x, quadruple y)
        {
            return x % y;
        }
    }
}
