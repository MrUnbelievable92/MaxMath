using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;

using static MaxMath.math;

namespace MaxMath
{
    unsafe public partial struct quadruple
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static uint approxRecipSqrt32_1(uint oddExpA, uint a)
        {
            ushort16 approxRecipSqrt_1k0s = new ushort16
            (
                0xB4C9, 0xFFAB, 0xAA7D, 0xF11C, 0xA1C5, 0xE4C7, 0x9A43, 0xDA29,
                0x93B5, 0xD0E5, 0x8DED, 0xC8B7, 0x88C6, 0xC16D, 0x8424, 0xBAE1
            );
            ushort16 approxRecipSqrt_1k1s = new ushort16
            (
                0xA5A5, 0xEA42, 0x8C21, 0xC62D, 0x788F, 0xAA7F, 0x6928, 0x94B6,
                0x5CC7, 0x8335, 0x52A6, 0x74E2, 0x4A3E, 0x68FE, 0x432B, 0x5EFD
            );

            int index = (int)((a >> 27 & 0xE) + oddExpA);
            ushort eps = (ushort)(a >> 12);
            ushort r0 = (ushort)(approxRecipSqrt_1k0s[index]
                      - ((approxRecipSqrt_1k1s[index] * (uint)eps)
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
        internal static quadruple.ConstChecked SquareRoot(quadruple.ConstChecked x)
        {
            FloatingPointPromise<quadruple> finalPromise = default(FloatingPointPromise<quadruple>);

            ulong signA = x.Value.value.hi64 & (1ul << 63);
            ulong expA = x.Value.value.hi64 & SIGNALING_EXPONENT.hi64;
            UInt128 sigA = new UInt128(x.Value.value.lo64, fracF128UI64(x.Value.value.hi64));

            if (!(x.Promise.NonZero && x.Promise.NotSubnormal)
             && Hint.Unlikely(expA == 0))
            {
                finalPromise.MinPossible = new quadruple(0, 0);

                if (x.Promise.NotSubnormal
                 || Hint.Likely(sigA.IsZero))
                {
                    finalPromise.MaxPossible = finalPromise.MinPossible;

                    return new quadruple.ConstChecked(x, finalPromise);
                }
                else
                {
                    normSubnormalF128Sig(ref expA, ref sigA);
                    expA <<= MANTISSA_BITS_HI64;
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
            uint recipSqrt32 = approxRecipSqrt32_1((uint)((expA >> MANTISSA_BITS_HI64) & 1), sig32A);
            uint sig32Z = (uint)(((ulong)sig32A * recipSqrt32) >> 32);

            if (!(x.Promise.NotNaN
               && x.Promise.NotInf)
             && Hint.Unlikely(expA == SIGNALING_EXPONENT.hi64))
            {
                byte negativeINF = tobyte(!x.Promise.ZeroOrGreater && (x.Promise.Negative || signA != 0));
                ulong lo = x.Promise.NotNaN ? 0ul : x.Value.value.lo64;

                return new quadruple.ConstChecked(new quadruple(lo | negativeINF, x.Value.value.hi64), finalPromise);
            }

            finalPromise |= FloatingPointPromise<quadruple>.NOT_INF;

            if (Hint.Unlikely(signA != 0))
            {
                if (x.Promise.NonZero)
                {
                    return NaN;
                }
                else if (x.Promise.ZeroOrGreater
                      || Hint.Likely((expA | (sigA.hi64 | sigA.lo64)) == 0))
                {
                    finalPromise.MinPossible = finalPromise.MaxPossible = new quadruple(0, 0);

                    return new quadruple.ConstChecked(x, finalPromise);
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
                rem = y - mul64ByShifted32To128(x64 + sig64Z, q);
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
                y    = mul64ByShifted32To128(term.lo64, q);
                term = mul64ByShifted32To128(term.hi64, q);
                term += y.hi64;
                rem <<= 20;
                term -= rem;
                sigZExtra |= term.hi64 >> 63;
                sigZ -= tobyte((term.hi64 != 0) & (((term.lo64 != 0) | (y.lo64 != 0)) & sigZExtra == 0));
                sigZExtra -= tobyte(term.hi64 != 0);
            }

            return new quadruple.ConstChecked(roundPackToF128(0, expZ, sigZ, sigZExtra, true), finalPromise);
        }
    }
}
