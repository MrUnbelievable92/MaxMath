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
        internal static quadruple.ConstChecked Divide(quadruple.ConstChecked left, quadruple.ConstChecked right)
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

            bool expA0 = !(left.Promise.NonZero && left.Promise.NotSubnormal) && Hint.Unlikely(expA == 0);
            bool expB0 = !(right.Promise.NonZero && right.Promise.NotSubnormal) && Hint.Unlikely(expB == 0);
            bool expANaNInf = !(left.Promise.NotNaN && left.Promise.NotInf) && Hint.Unlikely(expA == SIGNALING_EXPONENT.hi64);
            bool expBNaNInf = !(right.Promise.NotNaN && right.Promise.NotInf) && Hint.Unlikely(expB == SIGNALING_EXPONENT.hi64);

            if (expB0)
            {
                if (right.Promise.NonZero
                 || Hint.Unlikely(sigB.IsNotZero))
                {
                    softfloat_normSubnormalF128Sig(ref expB, ref sigB);
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
                    softfloat_normSubnormalF128Sig(ref expA, ref sigA);
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

            finalPromise |= FloatingPointPromise<quadruple>.NOT_NAN;

            sigA = new UInt128(sigA.lo64, sigA.hi64 | (1ul << MANTISSA_BITS_HI64));
            sigB = new UInt128(sigB.lo64, sigB.hi64 | (1ul << MANTISSA_BITS_HI64));
            bool aLTb = sigA < sigB;

            ulong expZ = expA - expB + 0x3FFE - tobyte(aLTb);
            UInt128 rem = sigA + select(0, sigA, aLTb);
            ulong recip32 = softfloat_approxRecip32_1((uint)(sigB.hi64 >> 17));

            if (expANaNInf)
            {
                if ((!left.Promise.NotNaN
                 && Hint.Unlikely(left.Value.value.lo64 != 0))
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
                if (!right.Promise.NotNaN
                 && Hint.Unlikely(right.Value.value.lo64 != 0))
                {
                    return NaN;
                }
                else
                {
                    return ZeroQuadruple(signZ);
                }
            }

            ulong q64;
            uint q;
            uint q0;
            uint q1;
            uint q2;
            bool round;
            if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
            {
                uint* q0p = &q0;
                uint* q1p = &q1;
                uint* q2p = &q2;

                int ix = 3;
                while (true)
                {
                    q64 = (uint)(rem.hi64 >> 19) * recip32;
                    q = (uint)((q64 + 0x8000_0000) >> 32);
                    if (--ix < 0)
                    {
                        break;
                    }
                    rem <<= 29;
                    rem -= q * sigB;
                    if ((long)rem.hi64 < 0)
                    {
                        q--;
                        rem += sigB;
                    }

                    switch (ix)
                    {
                        case 0:  q0 = q; break;
                        case 1:  q1 = q; break;
                        default: q2 = q; break;
                    }
                }

                round = ((q + 1) & 7) < 2;
            }
            else
            {
                q64 = (uint)(rem.hi64 >> 19) * recip32;
                q = (uint)((q64 + 0x8000_0000) >> 32);
                rem <<= 29;
                rem -= q * sigB;
                if ((long)rem.hi64 < 0)
                {
                    q--;
                    rem += sigB;
                }
                q2 = q;
                q64 = (uint)(rem.hi64 >> 19) * recip32;
                q = (uint)((q64 + 0x8000_0000) >> 32);
                rem <<= 29;
                rem -= q * sigB;
                if ((long)rem.hi64 < 0)
                {
                    q--;
                    rem += sigB;
                }
                q1 = q;
                q64 = (uint)(rem.hi64 >> 19) * recip32;
                q = (uint)((q64 + 0x8000_0000) >> 32);
                rem <<= 29;
                rem -= q * sigB;
                if ((long)rem.hi64 < 0)
                {
                    q--;
                    rem += sigB;
                }
                q0 = q;
                q64 = (uint)(rem.hi64 >> 19) * recip32;
                q = (uint)((q64 + 0x8000_0000) >> 32);

                round = ((q64 + 0x0000_0001_8000_0000ul) & (7ul << 32)) < (2ul << 32);
            }

            if (round)
            {
                rem <<= 29;
                rem -= q * sigB;
                if ((long)rem.hi64 < 0)
                {
                    q--;
                    rem += sigB;
                }
                else if (sigB <= rem)
                {
                    q++;
                    rem -= sigB;
                }

                q |= tobyte(rem.IsNotZero);
            }

            ulong sigZExtra = (ulong)q << 60;
            UInt128 sigZ = (UInt128)q1 << 54;
            sigZ += new UInt128(((ulong)q0 << 25) + (q >> 4), (ulong)q2 << 19);
            return new quadruple.ConstChecked(softfloat_roundPackToF128(signZ, expZ, sigZ.hi64, sigZ.lo64, sigZExtra), finalPromise);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple operator / (quadruple left, quadruple right) => Divide(left, right);
    }
}
