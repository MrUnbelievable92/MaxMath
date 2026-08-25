using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;
using MaxMath.CompilerServices;

using static MaxMath.math;

namespace MaxMath
{
    unsafe public partial struct quadruple
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static bool ConstDivide(quadruple.ConstChecked x, quadruple.ConstChecked __const, FloatingPointPromise<quadruple> finalPromise, out quadruple.ConstChecked result)
        {
            if (constexpr.IS_TRUE(abs(__const) == 1))
            {
                if (!constexpr.IS_FALSE(isinf(x) || isinf(__const) || isnan(x) || isnan(__const)))
                {
                    result = default;
                    return false;
                }

                result = chgsign(x, __const);

                return true;
            }
            if (constexpr.IS_TRUE(ispow2mag(__const)))
            {
                result = new quadruple.ConstChecked(DivideByPowerOfTwo(x, __const), finalPromise);
            
                return true;
            }

            result = default;
            return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quadruple.ConstChecked Reciprocal(quadruple.ConstChecked x)
        {
            FloatingPointPromise<quadruple> finalPromise = default(FloatingPointPromise<quadruple>);
            finalPromise |= x.Promise.Positive ? FloatingPointPromise<quadruple>.POSITIVE : Promise.Nothing;
            finalPromise |= x.Promise.Negative ? FloatingPointPromise<quadruple>.NEGATIVE : Promise.Nothing;
            
            if (ConstDivide(1, x.Value, finalPromise, out quadruple.ConstChecked constResultRight))
            {
                return constResultRight;
            }
            
            ulong signZ = x.Value.value.hi64 & (1ul << 63);
            const ulong expA = 0x3FFF;
            ulong expX = x.Value.value.hi64 & SIGNALING_EXPONENT.hi64;
            UInt128 sigX = new UInt128(x.Value.value.lo64, fracF128UI64(x.Value.value.hi64));

            bool expX0 = !(x.Promise.NonZero && x.Promise.NotSubnormal) && Hint.Unlikely(expX == 0);
            bool expXNaNInf = !(x.Promise.NotNaN && x.Promise.NotInf) && Hint.Unlikely(expX == SIGNALING_EXPONENT.hi64);

            if (expX0)
            {
                if (x.Promise.NonZero
                 || Hint.Unlikely(sigX.IsNotZero))
                {
                    normSubnormalF128Sig(ref expX, ref sigX);
                }
                else
                {
                    return new quadruple(0, signZ | SIGNALING_EXPONENT.hi64);
                }
            }
            else
            {
                expX >>= MANTISSA_BITS_HI64;
            }

            if (expXNaNInf)
            {
                if (Hint.Unlikely(isnan(x)))
                {
                    return NaN;
                }
                else
                {
                    return ZeroQuadruple(signZ);
                }
            }
            
            finalPromise |= FloatingPointPromise<quadruple>.NOT_NAN;

            bool aLTb = sigX != 0;
            sigX = new UInt128(sigX.lo64, sigX.hi64 | (1ul << MANTISSA_BITS_HI64));
            ulong expZ = expA - expX + 0x3FFE - tobyte(aLTb);

            ulong sigZExtra = asm128.__rcpdivf128(sigX, out UInt128 sigZ);

            return new quadruple.ConstChecked(roundPackToF128(signZ, expZ, sigZ, sigZExtra, /*TODO determine in this func whether not inf*/finalPromise.NotInf), finalPromise);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quadruple.ConstChecked Divide(quadruple.ConstChecked left, quadruple.ConstChecked right)
        {
            FloatingPointPromise<quadruple> finalPromise = default(FloatingPointPromise<quadruple>);
            finalPromise |= left.Promise.Negative && right.Promise.Negative ? FloatingPointPromise<quadruple>.POSITIVE : Promise.Nothing;
            finalPromise |= left.Promise.Positive && right.Promise.Positive ? FloatingPointPromise<quadruple>.POSITIVE : Promise.Nothing;
            finalPromise |= left.Promise.Positive && right.Promise.Negative ? FloatingPointPromise<quadruple>.NEGATIVE : Promise.Nothing;
            finalPromise |= left.Promise.Negative && right.Promise.Positive ? FloatingPointPromise<quadruple>.NEGATIVE : Promise.Nothing;
            
            if (constexpr.IS_TRUE(abs(left) == 1))
            {
                return chgsign(Reciprocal(right), left);
            }
            if (ConstDivide(left, right.Value, finalPromise, out quadruple.ConstChecked constResultRight))
            {
                return constResultRight;
            }
            
            ulong signA = left.Value.value.hi64 & (1ul << 63);
            ulong signB = right.Value.value.hi64 & (1ul << 63);
            ulong signZ = signA ^ signB;
            ulong expA = left.Value.value.hi64 & SIGNALING_EXPONENT.hi64;
            ulong expB = right.Value.value.hi64 & SIGNALING_EXPONENT.hi64;
            UInt128 sigA = new UInt128(left.Value.value.lo64, fracF128UI64(left.Value.value.hi64));
            UInt128 sigB = new UInt128(right.Value.value.lo64, fracF128UI64(right.Value.value.hi64));

            bool expA0 = !(left.Promise.NonZero && left.Promise.NotSubnormal) && Hint.Unlikely(expA == 0);
            bool expB0 = !(right.Promise.NonZero && right.Promise.NotSubnormal) && Hint.Unlikely(expB == 0);
            bool expANaNInf = !(left.Promise.NotNaN && left.Promise.NotInf) && Hint.Unlikely(expA == SIGNALING_EXPONENT.hi64);
            bool expBNaNInf = !(right.Promise.NotNaN && right.Promise.NotInf) && Hint.Unlikely(expB == SIGNALING_EXPONENT.hi64);

            if (expB0)
            {
                if (right.Promise.NonZero
                 || Hint.Unlikely(sigB.IsNotZero))
                {
                    normSubnormalF128Sig(ref expB, ref sigB);
                }
                else if (!expANaNInf)
                {
                    bool aIsZero = !left.Promise.NonZero &&
                                   (left.Promise.NoSignedZero ? left.Value.value.IsZero : (expA | sigA.hi64 | sigA.lo64) == 0);

                    return new quadruple(tobyte(aIsZero), signZ | SIGNALING_EXPONENT.hi64);
                }
            }
            else
            {
                expB >>= MANTISSA_BITS_HI64;
            }
            if (expA0)
            {
                if (left.Promise.NonZero
                 || Hint.Unlikely(Hint.Likely(sigA.IsNotZero)))
                {
                    normSubnormalF128Sig(ref expA, ref sigA);
                }
                else if (!expBNaNInf)
                {
                    return ZeroQuadruple(signZ);
                }
            }
            else
            {
                expA >>= MANTISSA_BITS_HI64;
            }
            
            if (expANaNInf)
            {
                if (Hint.Unlikely(isnan(left))
                  | expBNaNInf)
                {
                    return NaN;
                }
                else
                {
                    return new quadruple(0, signZ | SIGNALING_EXPONENT.hi64);
                }
            }
            if (expBNaNInf)
            {
                if (Hint.Unlikely(isnan(right)))
                {
                    return NaN;
                }
                else
                {
                    return ZeroQuadruple(signZ);
                }
            }

            finalPromise |= FloatingPointPromise<quadruple>.NOT_NAN;
            
            bool aLTb;
            if (left.Promise.NotSubnormal
             && right.Promise.NotSubnormal)
            {
                aLTb = sigA < sigB;
                sigA = new UInt128(sigA.lo64, sigA.hi64 | (1ul << MANTISSA_BITS_HI64));
                sigB = new UInt128(sigB.lo64, sigB.hi64 | (1ul << MANTISSA_BITS_HI64));
            }
            else
            {
                sigA = new UInt128(sigA.lo64, sigA.hi64 | (1ul << MANTISSA_BITS_HI64));
                sigB = new UInt128(sigB.lo64, sigB.hi64 | (1ul << MANTISSA_BITS_HI64));
                aLTb = sigA < sigB;
            }

            ulong expZ = expA - expB + 0x3FFE - tobyte(aLTb);
            UInt128 rem = sigA + select(0, sigA, aLTb);
            
            ulong sigZExtra = asm128.__usf__div128to256x128shl127x15(rem, sigB, out UInt128 sigZ);

            return new quadruple.ConstChecked(roundPackToF128(signZ, expZ, sigZ, sigZExtra, /*TODO determine in this func whether not inf*/finalPromise.NotInf), finalPromise);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple operator / (quadruple left, quadruple right) => Divide(left, right);


        internal unsafe partial struct ConstChecked
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static quadruple.ConstChecked operator / (quadruple.ConstChecked left, quadruple.ConstChecked right)
            {
                return quadruple.Divide(left, right);
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static quadruple.ConstChecked operator / (quadruple.ConstChecked left, quadruple right) => left / (quadruple.ConstChecked)right;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static quadruple.ConstChecked operator / (quadruple left, quadruple.ConstChecked right) => (quadruple.ConstChecked)left / right;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static quadruple.ConstChecked operator / (quadruple.ConstChecked left, double right) => left / (quadruple)right;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static quadruple.ConstChecked operator / (double left, quadruple.ConstChecked right) => (quadruple)left / right;
        }
    }
}
