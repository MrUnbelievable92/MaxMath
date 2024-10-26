using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Burst.CompilerServices;

using static Unity.Mathematics.math;
using static MaxMath.maxmath;

namespace MaxMath
{
    unsafe public readonly partial struct quadruple
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quadruple.ConstChecked Multiply(quadruple.ConstChecked left, quadruple.ConstChecked right)
        {
            FloatingPointPromise<quadruple> finalPromise = default(FloatingPointPromise<quadruple>);
            finalPromise |= left.Promise.Negative && right.Promise.Negative ? FloatingPointPromise<quadruple>.POSITIVE : Promise.Nothing;
            finalPromise |= left.Promise.Positive && right.Promise.Positive ? FloatingPointPromise<quadruple>.POSITIVE : Promise.Nothing;
            finalPromise |= left.Promise.Positive && right.Promise.Negative ? FloatingPointPromise<quadruple>.NEGATIVE : Promise.Nothing;
            finalPromise |= left.Promise.Negative && right.Promise.Positive ? FloatingPointPromise<quadruple>.NEGATIVE : Promise.Nothing;

            ulong signA = left.Value.value.hi64 & (1ul << 63);
            ulong signB = right.Value.value.hi64 & (1ul << 63);
            ulong signZ = signA ^ signB;

            ulong expA = left.Value.value.hi64 & SIGNALING_EXPONENT.hi64;
            ulong expB = right.Value.value.hi64 & SIGNALING_EXPONENT.hi64;

            UInt128 sigA = new UInt128(left.Value.value.lo64, fracF128UI64(left.Value.value.hi64));
            UInt128 sigB = new UInt128(right.Value.value.lo64, fracF128UI64(right.Value.value.hi64));
            
            bool expBNaNInf = !(right.Promise.NotNaN && right.Promise.NotInf) 
                            && Hint.Unlikely(expB == SIGNALING_EXPONENT.hi64);
            
            if (!(left.Promise.NotNaN && left.Promise.NotInf) 
             && Hint.Unlikely(expA == SIGNALING_EXPONENT.hi64)) 
            {
                if ((!left.Promise.NotNaN
                 && (left.Value.value.lo64 != 0)) 
                 | (!right.Promise.NotNaN
                 && (expBNaNInf & (right.Value.value.lo64 != 0))))
                {
                    return NaN;
                }
            
                bool bIsZero = !right.Promise.NonZero && 
                               (right.Promise.NoSignedZero ? right.Value.value.IsZero : (expB | sigB.hi64 | sigB.lo64) == 0);

                return new quadruple(tobyte(bIsZero), signZ | SIGNALING_EXPONENT.hi64);
            }
            if (expBNaNInf) 
            {
                if (!right.Promise.NotNaN
                 && right.Value.value.lo64 != 0)
                {
                    return NaN;
                }
            
                bool aIsZero = !left.Promise.NonZero && 
                               (left.Promise.NoSignedZero ? left.Value.value.IsZero : (expA | sigA.hi64 | sigA.lo64) == 0);
                
                return new quadruple(tobyte(aIsZero), signZ | SIGNALING_EXPONENT.hi64);
            }
            
            finalPromise |= FloatingPointPromise<quadruple>.NOT_NAN;

            if (!(left.Promise.NonZero && left.Promise.NotSubnormal)
             && Hint.Unlikely(expA == 0)) 
            {
                if (COMPILATION_OPTIONS.FLOAT_DENORMALS_ARE_ZERO 
                 || sigA.IsZero) 
                {
                    return ZeroQuadruple(signZ);
                }
                softfloat_normSubnormalF128Sig(ref expA, ref sigA);
            }
            else
            {
                expA >>= MANTISSA_BITS_HI64;
            }
            if (!(right.Promise.NonZero && right.Promise.NotSubnormal)
             && Hint.Unlikely(expB == 0)) 
            {
                if (COMPILATION_OPTIONS.FLOAT_DENORMALS_ARE_ZERO 
                 || sigB.IsZero) 
                { 
                    return ZeroQuadruple(signZ);
                }
                softfloat_normSubnormalF128Sig(ref expB, ref sigB);
            }
            else
            {
                expB >>= MANTISSA_BITS_HI64;
            }

            sigA = new UInt128(sigA.lo64, sigA.hi64 | (1ul << MANTISSA_BITS_HI64));
            sigB <<= 16;
            __UInt256__ sig256Z = __UInt256__.umul256(sigA, sigB);
            
            ulong expZ = expA + expB - 0x4000;
            ulong sigZExtra = sig256Z.lo128.hi64 | tobyte(sig256Z.lo128.lo64 != 0);
            UInt128 sigZ = sigA + sig256Z.hi128;
            if (sigZ.hi64 >= 0x0002_0000_0000_0000ul) 
            {
                expZ++;
                sigZ = softfloat_shortShiftRightJam128Extra(sigZ.hi64, sigZ.lo64, sigZExtra, 1, out sigZExtra);
            }
            return new quadruple.ConstChecked(softfloat_roundPackToF128(signZ, expZ, sigZ.hi64, sigZ.lo64, sigZExtra), finalPromise);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple operator * (quadruple left, quadruple right) => Multiply(left, right);
    }
}
