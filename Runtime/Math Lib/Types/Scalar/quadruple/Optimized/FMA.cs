using System;
using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Burst.CompilerServices;

using static Unity.Mathematics.math;
using static MaxMath.maxmath;

namespace MaxMath
{
    unsafe public readonly partial struct quadruple : IComparable, IComparable<quadruple>, IConvertible, IEquatable<quadruple>, IFormattable
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static quadruple.ConstChecked softfloat_mulAddF128(quadruple.ConstChecked a, quadruple.ConstChecked b, quadruple.ConstChecked c, bool negProd, bool negC)
        {
            FloatingPointPromise<quadruple> finalPromise;
            ulong sigZExtra;
            __UInt256__ sig256C = 0u;
        
            ulong expA = a.Value.value.hi64 & SIGNALING_EXPONENT.hi64;
            ulong expB = b.Value.value.hi64 & SIGNALING_EXPONENT.hi64;
            UInt128 sigA = new UInt128(a.Value.value.lo64, fracF128UI64(a.Value.value.hi64));
            UInt128 sigB = new UInt128(b.Value.value.lo64, fracF128UI64(b.Value.value.hi64));

            bool aNaNifExpSignaling = !a.Promise.NotNaN && Hint.Unlikely(a.Value.value.lo64 != 0);
            bool bNaNifExpSignaling = !b.Promise.NotNaN && Hint.Unlikely(b.Value.value.lo64 != 0);
            bool aNotZero = a.Promise.NonZero || (Hint.Likely(expA != 0) | Hint.Likely(sigA.IsNotZero));
            bool bNotZero = b.Promise.NonZero || (Hint.Likely(expB != 0) | Hint.Likely(sigB.IsNotZero));
            
            bool aSignaling = false;

            if (!(a.Promise.NonZero && a.Promise.NotSubnormal)
             && Hint.Unlikely(expA == 0)) 
            {
                if (COMPILATION_OPTIONS.OPTIMIZE_FOR != OptimizeFor.Size)
                {
                    if (!a.Promise.NonZero
                     && Hint.Likely(sigA.IsZero))
                    {
                        if (!(b.Promise.NotNaN && b.Promise.NotInf) 
                         && Hint.Unlikely(expB == SIGNALING_EXPONENT.hi64))
                        {
                            return NaN;
                        }
                        else
                        {
                            finalPromise = c.Promise;
                            if (negC)
                            {
                                finalPromise.FlipSign();
                            }

                            return new quadruple.ConstChecked(new quadruple(c.Value.value.lo64, c.Value.value.hi64 ^ (toulong(negC) << 63)), finalPromise);
                        }
                    }
                }

                softfloat_normSubnormalF128Sig(ref expA, ref sigA);
            }
            else
            {
                aSignaling = !(a.Promise.NotNaN && a.Promise.NotInf) && Hint.Unlikely(expA == SIGNALING_EXPONENT.hi64);
                expA >>= MANTISSA_BITS_HI64;
            }

            if ((!(b.Promise.NonZero && b.Promise.NotSubnormal)
             && Hint.Unlikely(expB == 0)) 
             & !aSignaling) 
            {
                if (COMPILATION_OPTIONS.OPTIMIZE_FOR != OptimizeFor.Size)
                {
                    if (!b.Promise.NonZero
                     && Hint.Likely(sigB.IsZero))
                    {
                        if (aSignaling)
                        {
                            return NaN;
                        }
                        else
                        {
                            finalPromise = c.Promise;
                            if (negC)
                            {
                                finalPromise.FlipSign();
                            }
                            
                            return new quadruple.ConstChecked(new quadruple(c.Value.value.lo64, c.Value.value.hi64 ^ (toulong(negC) << 63)), finalPromise);
                        }
                    }
                }

                softfloat_normSubnormalF128Sig(ref expB, ref sigB);
            }
            else
            {
                expB >>= MANTISSA_BITS_HI64;
            }

            ulong expZ = expA + expB - 0x3FFE;

            sigA = new UInt128(sigA.lo64, sigA.hi64 | (1ul << MANTISSA_BITS_HI64));
            sigB = new UInt128(sigB.lo64, sigB.hi64 | (1ul << MANTISSA_BITS_HI64));
            sigA <<= 8;
            sigB <<= 15;
            __UInt256__ sig256Z = __UInt256__.umul256(sigA, sigB);
            UInt128 sigZ = sig256Z.hi128;

            ulong bit = andnot(0x0100_0000_0000_0000, sigZ.hi64) >> 56;
            expZ -= bit;
            int shiftDist = -(int)bit;

            ulong expC = expF128UI64(c.Value.value.hi64);
            UInt128 sigC = new UInt128(c.Value.value.lo64, fracF128UI64(c.Value.value.hi64));

            ulong signA = a.Value.value.hi64 & (1ul << 63);
            ulong signB = b.Value.value.hi64 & (1ul << 63);
            ulong signC = (c.Value.value.hi64 & (1ul << 63)) ^ (toulong(negC) << 63);
            ulong signZ = signA ^ signB ^ (toulong(negProd) << 63);

            if (aSignaling) 
            {
                if (aNaNifExpSignaling | 
                    (!(b.Promise.NotNaN && b.Promise.NotInf) 
                     && Hint.Unlikely((expB == (SIGNALING_EXPONENT.hi64 >> MANTISSA_BITS_HI64)) & bNaNifExpSignaling))) 
                {
                    return NaN;
                }
                if (bNotZero) 
                {
                    if (!(c.Promise.NotNaN && c.Promise.NotInf) 
                       && Hint.Likely(expC != SIGNALING_EXPONENT.hi64 >> MANTISSA_BITS_HI64))
                    { 
                        return new quadruple(0, signZ | SIGNALING_EXPONENT.hi64);
                    }
                    if (!c.Promise.NonZero
                     && Hint.Unlikely(sigC.IsNotZero))
                    { 
                        return NaN;
                    }
                    if (signZ == signC)
                    { 
                        return new quadruple(0, signZ | SIGNALING_EXPONENT.hi64);
                    }
                }

                return NaN;
            }
            if (!(b.Promise.NotNaN && b.Promise.NotInf) 
              && Hint.Unlikely(expB == SIGNALING_EXPONENT.hi64 >> MANTISSA_BITS_HI64))
            {
                if (bNaNifExpSignaling) 
                {
                    return NaN;
                }
                if (aNotZero) 
                {
                    if ((c.Promise.NotNaN && c.Promise.NotInf) 
                     || Hint.Likely(expC != SIGNALING_EXPONENT.hi64 >> MANTISSA_BITS_HI64))
                    { 
                        return new quadruple(0, signZ | SIGNALING_EXPONENT.hi64);
                    }
                    if (!c.Promise.NonZero
                     && Hint.Likely(sigC.IsNotZero))
                    { 
                        return NaN;
                    }
                    if (signZ == signC)
                    { 
                        return new quadruple(0, signZ | SIGNALING_EXPONENT.hi64);
                    }
                }

                return NaN;
            }
            if (!(c.Promise.NotNaN && c.Promise.NotInf) 
              && Hint.Unlikely(expC == SIGNALING_EXPONENT.hi64 >> MANTISSA_BITS_HI64))
            {
                return new quadruple(c.Value.value.lo64, c.Value.value.hi64);
            }

            finalPromise = FloatingPointPromise<quadruple>.NOT_NAN;
            
            if (!(c.Promise.NonZero && c.Promise.NotSubnormal)
             && Hint.Unlikely(expC == 0))
            {
                if (!c.Promise.NonZero
                 && Hint.Likely(sigC.IsZero)) 
                {
                    shiftDist += 8;
                    goto SIGZ;
                }
                softfloat_normSubnormalF128Sig(ref expC, ref sigC);
            }
            
            sigC = new UInt128(sigC.lo64, sigC.hi64 | (1ul << MANTISSA_BITS_HI64));
            sigC <<= 8;
            int expDiff = (int)expZ - (int)expC;
            if (expDiff < 0) 
            {
                expZ = expC;
                if ((signZ == signC) | (expDiff < -1)) 
                {
                    shiftDist -= expDiff;
                    if (shiftDist != 0) 
                    {
                        sigZ = softfloat_shiftRightJam128(sigZ.hi64, sigZ.lo64, shiftDist);
                    }
                } 
                else if (shiftDist == 0) 
                {
                    UInt128 x128 = sig256Z.lo128 >> 1;
                    sig256Z = new __UInt256__(new UInt128(x128.lo64, (sigZ.lo64 << 63) | x128.hi64), sig256Z.hi128);
                    sigZ >>= 1;
                    sig256Z = new __UInt256__(sig256Z.lo128, sigZ);
                }
            } 
            else 
            {
                if (shiftDist != 0) 
                {
                    sig256Z += sig256Z;
                }
                if (expDiff == 0) 
                {
                    sigZ = sig256Z.hi128;
                } 
                else
                {
                    sig256C = softfloat_shiftRightJam256M(new __UInt256__(0, sigC), (uint)expDiff);
                }
            }
            shiftDist = 8;
            if (signZ == signC) 
            {
                if (expDiff <= 0) 
                {
                    sigZ += sigC;
                } 
                else 
                {
                    sig256Z += sig256C;
                    sigZ = sig256Z.hi128;
                }

                bit = (sigZ.hi64 & 0x0200_0000_0000_0000) >> 57;
                expZ += bit;
                shiftDist += (int)bit;
            } 
            else 
            {
                if (expDiff < 0)
                {
                    signZ = signC;
                    if (expDiff < -1) 
                    {
                        sigZ = sigC - sigZ;
                        sigZExtra = sig256Z.lo128.hi64 | sig256Z.lo128.lo64;
                        sigZ = select(sigZ, sigZ - 1, sigZExtra != 0);

                        bit = andnot(0x0100_0000_0000_0000, sigZ.hi64) >> 56;
                        expZ -= bit;
                        shiftDist -= (int)bit;

                        goto SHIFT_ROUND_PACK;
                    } 
                    else
                    {
                        sig256C = new __UInt256__(0, sigC);
                        sig256Z = sig256C - sig256Z;
                    }
                } 
                else if (expDiff == 0) 
                {
                    sigZ -= sigC;
                    UInt128 loCMP = sigZ | sig256Z.lo128;

                    if (Hint.Unlikely(loCMP.IsZero))
                    {
                        return default(quadruple);
                    }

                    sig256Z = new __UInt256__(sig256Z.lo128, sigZ);
                    ulong signMask = (ulong)((long)sigZ.hi64 >> 63);
                    signZ ^= (1ul << 63) & sigZ.hi64;
                    sig256Z ^= new __UInt256__(signMask, signMask, signMask, signMask);
                    sig256Z -= new __UInt256__(signMask, signMask, signMask, signMask);
                } 
                else 
                {
                    sig256Z -= sig256C;
                    if (expDiff > 1) 
                    {
                        sigZ = sig256Z.hi128;
                        bit = andnot(0x0100_0000_0000_0000, sigZ.hi64) >> 56;
                        expZ -= bit;
                        shiftDist -= (int)bit;

                        goto SIGZ;
                    }
                }
                sigZ = sig256Z.hi128;
                sigZExtra = sig256Z.lo128.hi64;
                if (Hint.Likely(sigZ.hi64 != 0))
                {
                    sigZExtra |= tobyte(sig256Z.lo128.lo64 != 0);
                } 
                else 
                {
                    expZ -= 64;
                    sigZ = new UInt128(sigZExtra, sigZ.lo64);
                    sigZExtra = sig256Z.lo128.lo64;
                    if (sigZ.hi64 == 0) 
                    {
                        expZ -= 64;
                        sigZ = new UInt128(sigZExtra, sigZ.lo64);
                        sigZExtra = 0;
                        if (sigZ.hi64 == 0) 
                        {
                            expZ -= 64;
                            sigZ = new UInt128(sigZExtra, sigZ.lo64);
                        }
                    }
                }
                shiftDist = lzcnt(sigZ.hi64);
                expZ += (ulong)(7 - shiftDist);
                shiftDist = EXPONENT_BITS - shiftDist;

                if (sigZ.hi64 >= 1ul << (64 - EXPONENT_BITS - 1)) 
                {
                    goto SHIFT_ROUND_PACK;
                }
                else if (sigZ.hi64 <= 1ul << (64 - EXPONENT_BITS - 2)) 
                {
                    shiftDist = -shiftDist;
                    sigZ = softfloat_shortShiftLeft128(sigZ.hi64, sigZ.lo64, (byte)shiftDist);
                    UInt128 x128 = softfloat_shortShiftLeft128(0, sigZExtra, (byte)shiftDist);
                    sigZ = new UInt128(sigZ.lo64 | x128.hi64, sigZ.hi64);
                    sigZExtra = x128.lo64;
                }
            
                goto ROUND_PACK;
            }

         SIGZ:
            sigZExtra = sig256Z.lo128.hi64 | sig256Z.lo128.lo64;
         SHIFT_ROUND_PACK:
            sigZExtra = (sigZ.lo64 << (64 - shiftDist)) | tobyte(sigZExtra != 0);
            sigZ = softfloat_shortShiftRight128(sigZ.hi64, sigZ.lo64, (byte)shiftDist);
         ROUND_PACK:
            return new quadruple.ConstChecked(softfloat_roundPackToF128(signZ, expZ - 1, sigZ.hi64, sigZ.lo64, sigZExtra), finalPromise);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quadruple.ConstChecked fmadd(quadruple.ConstChecked a, quadruple.ConstChecked b, quadruple.ConstChecked c)
        {
            return softfloat_mulAddF128(a, b, c, false, false);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quadruple.ConstChecked fmsub(quadruple.ConstChecked a, quadruple.ConstChecked b, quadruple.ConstChecked c)
        {
            return softfloat_mulAddF128(a, b, c, false, true);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quadruple.ConstChecked fnmadd(quadruple.ConstChecked a, quadruple.ConstChecked b, quadruple.ConstChecked c)
        {
            return softfloat_mulAddF128(a, b, c, true, false);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quadruple.ConstChecked fnmsub(quadruple.ConstChecked a, quadruple.ConstChecked b, quadruple.ConstChecked c)
        {
            return softfloat_mulAddF128(a, b, c, true, true);
        }
    }


    unsafe public static partial class maxmath
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple mad(quadruple a, quadruple b, quadruple c)
        {
            return quadruple.fmadd(a, b, c);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple msub(quadruple a, quadruple b, quadruple c)
        {
            return quadruple.fmsub(a, b, c);
        }
    } 
}