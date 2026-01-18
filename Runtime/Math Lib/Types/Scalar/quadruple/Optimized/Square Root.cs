using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;
using static MaxMath.maxmath;

namespace MaxMath
{
    unsafe public readonly partial struct quadruple
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quadruple.ConstChecked SquareRoot(quadruple.ConstChecked a)
        {
            FloatingPointPromise<quadruple> finalPromise = default(FloatingPointPromise<quadruple>);

            ulong signA = a.Value.value.hi64 & (1ul << 63);
            ulong expA = a.Value.value.hi64 & SIGNALING_EXPONENT.hi64;
            UInt128 sigA = new UInt128(a.Value.value.lo64, fracF128UI64(a.Value.value.hi64));

            if (!(a.Promise.NonZero && a.Promise.NotSubnormal)
             && Hint.Unlikely(expA == 0))
            {
                finalPromise.MinPossible = new quadruple(0, 0);

                if (a.Promise.NotSubnormal
                 || Hint.Likely(sigA.IsZero))
                {
                    finalPromise.MaxPossible = finalPromise.MinPossible;

                    return new quadruple.ConstChecked(a, finalPromise);
                }
                else
                {
                    softfloat_normSubnormalF128Sig2(ref expA, ref sigA);
                }
            }
            else
            {
                finalPromise.MinPossible = new quadruple(0, 0x2000_0000_0000_0000);
                finalPromise |= FloatingPointPromise<quadruple>.POSITIVE;
                finalPromise |= FloatingPointPromise<quadruple>.NON_ZERO;
            }

            finalPromise.MaxPossible = new quadruple(0, 0x5FFF_0000_0000_0000);

            ulong expZ = (ulong)((((long)expA - (0x3FFFL << MANTISSA_BITS_HI64)) >> (1 + MANTISSA_BITS_HI64)) + 0x3FFE);
            sigA = new UInt128(sigA.lo64, sigA.hi64 | (1ul << MANTISSA_BITS_HI64));
            uint sig32A = (uint)(sigA.hi64 >> 17);
            uint recipSqrt32 = softfloat_approxRecipSqrt32_1((uint)((expA >> MANTISSA_BITS_HI64) & 1), sig32A);
            uint sig32Z = (uint)(((ulong)sig32A * recipSqrt32) >> 32);

            if (!(a.Promise.NotNaN
               && a.Promise.NotInf)
             && Hint.Unlikely(expA == SIGNALING_EXPONENT.hi64))
            {
                byte negativeINF = tobyte(a.Promise.ZeroOrGreater ? false : (a.Promise.Negative || signA != 0));
                ulong lo = a.Promise.NotNaN ? 0ul : a.Value.value.lo64;

                return new quadruple.ConstChecked(new quadruple(lo | negativeINF, a.Value.value.hi64), finalPromise);
            }

            finalPromise |= FloatingPointPromise<quadruple>.NOT_INF;

            if (Hint.Unlikely(signA != 0))
            {
                if (a.Promise.NonZero)
                {
                    return NaN;
                }
                else if (a.Promise.ZeroOrGreater
                      || Hint.Likely((expA | (sigA.hi64 | sigA.lo64)) == 0))
                {
                    finalPromise.MinPossible = finalPromise.MaxPossible = new quadruple(0, 0);

                    return new quadruple.ConstChecked(a, finalPromise);
                }
                else
                {
                    return NaN;
                }
            }

            finalPromise |= FloatingPointPromise<quadruple>.NOT_NAN;
            finalPromise |= FloatingPointPromise<quadruple>.NO_SIGNED_ZERO;
            finalPromise |= FloatingPointPromise<quadruple>.ZERO_OR_GREATER;

            UInt128 rem;
            if ((expA & (1ul << MANTISSA_BITS_HI64)) != 0) // good OoOE branch, 1 cycle instead of 3 on x86 (shift via CL)
            {
                sig32Z >>= 1;
                rem = sigA << 12;
            }
            else
            {
                rem = sigA << 13;
            }
            uint q2 = sig32Z;
            rem = new UInt128(rem.lo64, rem.hi64 - (ulong)sig32Z * sig32Z);

            uint q = (uint)(((uint)(rem.hi64 >> 2) * (ulong)recipSqrt32) >> 32);
            ulong x64 = (ulong)sig32Z << 32;
            ulong sig64Z = x64 + ((ulong)q << 3);
            UInt128 y = rem << 29;
            while (true)
            {
                rem = y - softfloat_mul64ByShifted32To128(x64 + sig64Z, q);
                if (Hint.Likely((long)rem.hi64 >= 0))
                {
                    break;
                }

                q--;
                sig64Z -= 1 << 3;
            }
            uint q1 = q;

            q = (uint)(((rem.hi64 >> 2) * recipSqrt32) >> 32);
            y = rem << 29;
            sig64Z <<= 1;
            while (true)
            {
                UInt128 term = (UInt128)sig64Z << 32;
                term += (ulong)q << 6;
                term *= q;
                rem = y - term;
                if (Hint.Likely((long)rem.hi64 >= 0))
                {
                    break;
                }

                q--;
            }
            uint q0 = q;

            q = (uint)((((rem.hi64 >> 2) * recipSqrt32) >> 32) + 2);
            ulong sigZExtra = (ulong)q << 59;
            UInt128 sigZ = ((UInt128)q1 << 53) + new UInt128(((ulong)q0 << 24) + (q >> 5), (ulong)q2 << 18);
            if ((q & 15) <= 2)
            {
                q &= ~3u;
                sigZExtra = (ulong)q << 59;
                y = sigZ << 6;
                y = new UInt128(y.lo64 | (sigZExtra >> 58), y.hi64);
                UInt128 term = y - q;
                y    = softfloat_mul64ByShifted32To128(term.lo64, q);
                term = softfloat_mul64ByShifted32To128(term.hi64, q);
                term += y.hi64;
                rem <<= 20;
                term -= rem;
                sigZExtra |= term.hi64 >> 63;
                sigZ -= tobyte((term.hi64 != 0) & (((term.lo64 != 0) | (y.lo64 != 0)) & sigZExtra == 0));
                sigZExtra -= tobyte(term.hi64 != 0);
            }

            return new quadruple.ConstChecked(softfloat_roundPackToF128(0, expZ, sigZ.hi64, sigZ.lo64, sigZExtra), finalPromise);
        }
    }

    unsafe public static partial class maxmath
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple sqrt(quadruple a)
        {
            return quadruple.SquareRoot(a);
        }
    }
}
