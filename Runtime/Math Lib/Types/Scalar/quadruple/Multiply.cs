using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;
using MaxMath.CompilerServices;

using static MaxMath.math;

namespace MaxMath
{
    unsafe public partial struct quadruple
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static bool ConstMultiply(quadruple.ConstChecked x, quadruple __const, FloatingPointPromise<quadruple> finalPromise, out quadruple.ConstChecked result)
        {
            UInt128 sign128 = asuint128(__const) & (UInt128)1 << 127;

            if (constexpr.IS_TRUE(abs(__const) == 0))
            {
                if (!constexpr.IS_FALSE(isinf(x) || isinf(__const) || isnan(x) || isnan(__const)))
                {
                    result = default;
                    return false;
                }

                result = new quadruple.ConstChecked(COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO ? asquadruple(sign128) : 0, finalPromise);
                
                return true;
            }
            if (constexpr.IS_TRUE(abs(__const) == 1))
            {
                result = new quadruple.ConstChecked(asquadruple(asuint128(x) ^ sign128), finalPromise);

                return true;
            }
            if (constexpr.IS_TRUE(ispow2mag(__const)))
            {
                result = new quadruple.ConstChecked(MultiplyByPowerOfTwo(x, __const), finalPromise);
            
                return true;
            }

            result = default;
            return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quadruple.ConstChecked Multiply(quadruple.ConstChecked left, quadruple.ConstChecked right)
        {
            FloatingPointPromise<quadruple> finalPromise = default(FloatingPointPromise<quadruple>);
            finalPromise |= left.Promise.Negative && right.Promise.Negative ? FloatingPointPromise<quadruple>.POSITIVE : Promise.Nothing;
            finalPromise |= left.Promise.Positive && right.Promise.Positive ? FloatingPointPromise<quadruple>.POSITIVE : Promise.Nothing;
            finalPromise |= left.Promise.Positive && right.Promise.Negative ? FloatingPointPromise<quadruple>.NEGATIVE : Promise.Nothing;
            finalPromise |= left.Promise.Negative && right.Promise.Positive ? FloatingPointPromise<quadruple>.NEGATIVE : Promise.Nothing;

            if (ConstMultiply(left, right.Value, finalPromise, out quadruple.ConstChecked constResultRight))
            {
                return constResultRight;
            }
            if (ConstMultiply(right, left.Value, finalPromise, out quadruple.ConstChecked constResultLeft))
            {
                return constResultLeft;
            }
            if (constexpr.IS_TRUE(left.Value.value == right.Value.value))
            {
                return Square(left);
            }

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
                if (isnan(left)
                  | isnan(right))
                {
                    return NaN;
                }

                bool bIsZero = !right.Promise.NonZero &&
                               (right.Promise.NoSignedZero ? right.Value.value.IsZero : (expB | sigB.hi64 | sigB.lo64) == 0);

                return new quadruple(tobyte(bIsZero), signZ | SIGNALING_EXPONENT.hi64);
            }
            if (expBNaNInf)
            {
                if (isnan(right))
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
                normSubnormalF128Sig(ref expA, ref sigA);
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
                normSubnormalF128Sig(ref expB, ref sigB);
            }
            else
            {
                expB >>= MANTISSA_BITS_HI64;
            }

            if (constexpr.IS_CONST(sigA))
            {
                UInt128 t = sigB;
                sigB = sigA;
                sigA = t;
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
                sigZ = shortShiftRightJam128Extra(sigZ, sigZExtra, 1, out sigZExtra);
            }
            return new quadruple.ConstChecked(roundPackToF128(signZ, expZ, sigZ, sigZExtra, /*TODO determine in this func whether not inf*/finalPromise.NotInf), finalPromise);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quadruple.ConstChecked Square(quadruple.ConstChecked x)
        {
            FloatingPointPromise<quadruple> finalPromise = default(FloatingPointPromise<quadruple>);
            finalPromise |= x.Promise.NonZero ? FloatingPointPromise<quadruple>.POSITIVE : Promise.Nothing;

            if (ConstMultiply(x, x, finalPromise, out quadruple.ConstChecked constResultRight))
            {
                return constResultRight;
            }
            if (ConstMultiply(x, x.Value, finalPromise, out quadruple.ConstChecked constResultLeft))
            {
                return constResultLeft;
            }
            
            ulong expA = x.Value.value.hi64 & SIGNALING_EXPONENT.hi64;
            UInt128 sigA = new UInt128(x.Value.value.lo64, fracF128UI64(x.Value.value.hi64));

            if (!(x.Promise.NotNaN && x.Promise.NotInf)
             && Hint.Unlikely(expA == SIGNALING_EXPONENT.hi64))
            {
                return abs(x);
            } 
            
            finalPromise |= FloatingPointPromise<quadruple>.NOT_NAN;

            if (!(x.Promise.NonZero && x.Promise.NotSubnormal)
             && Hint.Unlikely(expA == 0))
            {
                if (COMPILATION_OPTIONS.FLOAT_DENORMALS_ARE_ZERO
                 || sigA.IsZero)
                {
                    return 0;
                }
                normSubnormalF128Sig(ref expA, ref sigA);
            }
            else
            {
                expA >>= (MANTISSA_BITS_HI64 - 1);
            }
            
            UInt128 raw = sigA;
            sigA = new UInt128(sigA.lo64, sigA.hi64 | (1ul << MANTISSA_BITS_HI64));
            
            __UInt256__ qq = __UInt256__.usqr256(raw);
            qq <<= 16;
            __UInt256__ sig256Z = new __UInt256__(qq.lo128, qq.hi128 + raw);
            
            ulong expZ = expA - 0x4000;
            ulong sigZExtra = sig256Z.lo128.hi64 | tobyte(sig256Z.lo128.lo64 != 0);
            UInt128 sigZ = sigA + sig256Z.hi128;
            if (sigZ.hi64 >= 0x0002_0000_0000_0000ul)
            {
                expZ++;
                sigZ = shortShiftRightJam128Extra(sigZ, sigZExtra, 1, out sigZExtra);
            }
            return new quadruple.ConstChecked(roundPackToF128(0, expZ, sigZ, sigZExtra, false), default);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple operator * (quadruple left, quadruple right) => Multiply(left, right);


        internal unsafe partial struct ConstChecked
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static quadruple.ConstChecked operator * (quadruple.ConstChecked left, quadruple.ConstChecked right)
            {
                return quadruple.Multiply(left, right);
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static quadruple.ConstChecked operator * (quadruple.ConstChecked left, quadruple right) => left * (quadruple.ConstChecked)right;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static quadruple.ConstChecked operator * (quadruple left, quadruple.ConstChecked right) => (quadruple.ConstChecked)left * right;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static quadruple.ConstChecked operator * (quadruple.ConstChecked left, double right) => left * (quadruple)right;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static quadruple.ConstChecked operator * (double left, quadruple.ConstChecked right) => (quadruple)left * right;
        }
    }
}
