using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;
using MaxMath.CompilerServices;

using static MaxMath.math;

namespace MaxMath
{
    unsafe public partial struct quadruple
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static quadruple addMagsF128(quadruple.ConstChecked left, quadruple.ConstChecked right)
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

                sigA = shiftRightJam128Extra(sigA, 0, -(int)(expDiff >> MANTISSA_BITS_HI64), out sigZExtra);
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
                    if ((expDiff -= (1L << MANTISSA_BITS_HI64)) == 0)
                    {
                        goto newlyAligned;
                    }
                }

                sigB = shiftRightJam128Extra(sigB, 0, (int)(expDiff >> MANTISSA_BITS_HI64), out sigZExtra);
            }
         newlyAligned:
            sigZ = new UInt128(sigA.lo64, sigA.hi64 | (1ul << MANTISSA_BITS_HI64)) + sigB;
            if (sigZ.hi64 < 0x0002_0000_0000_0000ul)
            {
                expZ -= 1ul << MANTISSA_BITS_HI64;
                goto roundAndPack;
            }
         shiftRight1:
            sigZ = shortShiftRightJam128Extra(sigZ, sigZExtra, 1, out sigZExtra);
         roundAndPack:
            return roundPackToF128(sign, (expZ >> MANTISSA_BITS_HI64), sigZ, sigZExtra, false);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static quadruple addSubMagsF128(quadruple.ConstChecked left, quadruple.ConstChecked right, bool subtract)
        {
            FloatingPointPromise<quadruple> finalPromise;

            ulong expA = left.Value.value.hi64 & SIGNALING_EXPONENT.hi64;
            UInt128 sigA = new UInt128(left.Value.value.lo64, fracF128UI64(left.Value.value.hi64));
            ulong signZ = left.Value.value.hi64 & (1ul << 63);

            bool aSignaling = false;

            if (!(left.Promise.NonZero && left.Promise.NotSubnormal)
             && Hint.Unlikely(expA == 0))
            {
                if (!left.Promise.NonZero && Hint.Likely(sigA.IsZero))
                {
                    finalPromise = right.Promise;
                    if (subtract)
                    {
                        finalPromise.FlipSign();
                    }

                    return new quadruple.ConstChecked(new quadruple(right.Value.value.lo64, right.Value.value.hi64 ^ (toulong(subtract) << 63)), finalPromise);
                }
                normSubnormalF128Sig(ref expA, ref sigA);
            }
            else
            {
                aSignaling = !(left.Promise.NotNaN && left.Promise.NotInf) && Hint.Unlikely(expA == SIGNALING_EXPONENT.hi64);
                expA >>= MANTISSA_BITS_HI64;
            }

            ulong expZ = expA;
            UInt128 sigZ = new UInt128(sigA.lo64, sigA.hi64 | (1ul << MANTISSA_BITS_HI64));

            ulong expC = right.Value.value.hi64 & SIGNALING_EXPONENT.hi64;;
            UInt128 sigC = new UInt128(right.Value.value.lo64, fracF128UI64(right.Value.value.hi64));
            ulong signC = (right.Value.value.hi64 & (1ul << 63)) ^ (toulong(subtract) << 63);
            
            if (aSignaling)
            {
                if (Hint.Unlikely(isnan(left)))
                {
                    return NaN;
                }
                if (!(right.Promise.NotNaN && right.Promise.NotInf)
                 && Hint.Unlikely(expC == SIGNALING_EXPONENT.hi64))
                {
                    if ((!right.Promise.NotNaN && Hint.Unlikely(sigC.IsNotZero)) | signZ != signC)
                    {
                        return NaN;
                    }
                }

                return new quadruple(0, signZ | SIGNALING_EXPONENT.hi64);
            }
            if (!(right.Promise.NotNaN && right.Promise.NotInf)
             && Hint.Unlikely(expC == SIGNALING_EXPONENT.hi64))
            {
                if (!right.Promise.NotNaN
                 && Hint.Unlikely(sigC.IsNotZero))
                {
                    return NaN;
                }
                else
                {
                    return new quadruple(right.Value.value.lo64, right.Value.value.hi64 ^ (toulong(subtract) << 63));
                }
            }

            finalPromise = FloatingPointPromise<quadruple>.NOT_NAN;

            expC >>= MANTISSA_BITS_HI64;
            if (!(right.Promise.NonZero && right.Promise.NotSubnormal)
             && Hint.Unlikely(expC == 0))
            {
                if (!right.Promise.NonZero
                 && Hint.Likely(sigC.IsZero))
                {
                    return new quadruple.ConstChecked(roundPackToF128(signZ, expZ - 1, sigZ, 0, finalPromise.NotInf), finalPromise);
                }
                normSubnormalF128Sig(ref expC, ref sigC);
            }

            sigC = new UInt128(sigC.lo64, sigC.hi64 | (1ul << MANTISSA_BITS_HI64));

            return addSubF128_core(finalPromise, signZ, expZ, sigZ, expC, sigC, signC, 0);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static quadruple addSubF128_core(FloatingPointPromise<quadruple> finalPromise, ulong signZ, ulong expZ, UInt128 sigZ, ulong expC, UInt128 sigC, ulong signC, ulong sigZExtra)
        {
            ulong sigCExtra = 0;
            int expDiff = (int)expZ - (int)expC;

            if (expDiff > 0)
            {
                sigC = shiftRightJam128Extra(sigC, 0, expDiff, out sigCExtra);
            }
            else if (expDiff != 0)
            {
                sigZ = shiftRightJam128Extra(sigZ, sigZExtra, -expDiff, out sigZExtra);
                expZ = expC;
            }

            if (signZ == signC)
            {
                UInt128 sum = (UInt128)sigZExtra + (UInt128)sigCExtra;
                ulong extraSum = sum.lo64;
                ulong carry = sum.hi64;
                UInt128 sigSum = sigZ + sigC + carry;

                bool jamExtra = sigSum.hi64 >= 0x0002_0000_0000_0000ul;
                expZ -= tobyte(!jamExtra);
                if (jamExtra)
                {
                    sigSum = shortShiftRightJam128Extra(sigSum, extraSum, 1, out extraSum);
                }

                return new quadruple.ConstChecked(roundPackToF128(signZ, expZ, sigSum, extraSum, finalPromise.NotInf), finalPromise);
            }
            else
            {
                bool zBigger = (sigZ > sigC) | ((sigZ == sigC) & (sigZExtra > sigCExtra));

                ulong leftCMP = zBigger ? sigZExtra : sigCExtra;
                ulong rightCMP = zBigger ? sigCExtra : sigZExtra;
                UInt128 leftSUB = zBigger ? sigZ : sigC;
                UInt128 rightSUB = zBigger ? sigC : sigZ;
                ulong resultSign = zBigger ? signZ : signC;

                bool borrow = leftCMP < rightCMP;
                ulong magExtra = leftCMP - rightCMP;
                UInt128 magHi = leftSUB - rightSUB - tobyte(borrow);

                int lz0 = lzcnt(magHi.hi64);
                int lz1 = lzcnt(magHi.lo64);
                int lz2 = lzcnt(magExtra);
                int lz = lz0;
                lz += magHi.hi64 == 0 ? lz1 : 0;
                lz += magHi == 0 ? lz2 : 0;

                //if ((magHi | magExtra) == 0)
                //separate compare-vs-0 is used immediately before (or after)
                //-> better machine code even though the commented out version
                //is generally more efficient (or64, or64, or64, jnz)
                if ((magHi.hi64 == 0)
                  & (magHi.lo64 == 0))
                {
                    if (magExtra == 0)
                    {
                        return default(quadruple);
                    }

                    // xchg magExtra, magHi.lo64 (== 0 == magHi.hi64)
                    magHi = new UInt128(magExtra, magHi.hi64);
                    magExtra = 0;
                }

                int shiftDist = lz - (64 - MANTISSA_BITS_HI64 - 1);

                if (shiftDist > 0)
                {
                    shiftLeftWide192(magHi.hi64, magHi.lo64, magExtra, shiftDist, out ulong newH, out ulong newM, out magExtra);
                    magHi = new UInt128(newM, newH);
                }
                else if (shiftDist != 0)
                {
                    magHi = shiftRightJamWideExtra(magHi, magExtra, -shiftDist, out magExtra);
                }

                expZ = (ulong)((long)expZ - 1 - shiftDist);
                return new quadruple.ConstChecked(roundPackToF128(resultSign, expZ, magHi, magExtra, finalPromise.NotInf), finalPromise);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quadruple.ConstChecked Add(quadruple.ConstChecked left, quadruple.ConstChecked right, bool sameSign = false)
        {
            if (constexpr.IS_TRUE(sameSign || EqualSignBitsLo(left, right)))
            {
                return addMagsF128(left, right);
            }
            else
            {
                return addSubMagsF128(left, right, false);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quadruple.ConstChecked Subtract(quadruple.ConstChecked left, quadruple.ConstChecked right, bool sameSign = false)
        {
            if (constexpr.IS_FALSE(sameSign || EqualSignBitsLo(left, right)))
            {
                return addMagsF128(left, right);
            }
            else
            {
                return addSubMagsF128(left, right, true);
            }
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

        
        internal partial struct ConstChecked
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static quadruple.ConstChecked operator + (quadruple.ConstChecked value)
            {
                return value;
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static quadruple.ConstChecked operator - (quadruple.ConstChecked value)
            {
                value.Value = new quadruple(value.Value.value.lo64, value.Value.value.hi64 ^ (1ul << 63));
                value.Promise.FlipSign();

                return value;
            }
            
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static quadruple.ConstChecked operator ++ (quadruple.ConstChecked x)
            {
                return x + 1;
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static quadruple.ConstChecked operator -- (quadruple.ConstChecked x)
            {
                return x - 1;
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static quadruple.ConstChecked operator + (quadruple.ConstChecked left, quadruple.ConstChecked right) => Add(left, right);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static quadruple.ConstChecked operator - (quadruple.ConstChecked left, quadruple.ConstChecked right) => Subtract(left, right);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static quadruple.ConstChecked operator + (quadruple.ConstChecked left, quadruple right) => left + (quadruple.ConstChecked)right;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static quadruple.ConstChecked operator + (quadruple left, quadruple.ConstChecked right) => (quadruple.ConstChecked)left + right;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static quadruple.ConstChecked operator + (quadruple.ConstChecked left, double right) => left + (quadruple)right;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static quadruple.ConstChecked operator + (double left, quadruple.ConstChecked right) => (quadruple)left + right;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static quadruple.ConstChecked operator - (quadruple.ConstChecked left, quadruple right) => left - (quadruple.ConstChecked)right;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static quadruple.ConstChecked operator - (quadruple left, quadruple.ConstChecked right) => (quadruple.ConstChecked)left - right;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static quadruple.ConstChecked operator - (quadruple.ConstChecked left, double right) => left - (quadruple)right;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static quadruple.ConstChecked operator - (double left, quadruple.ConstChecked right) => (quadruple)left - right;
        }
    }
}
