using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;
using Unity.Mathematics;

using static Unity.Mathematics.math;
using static MaxMath.maxmath;
using static MaxMath.LUT.FLOATING_POINT;

namespace MaxMath
{
    unsafe public readonly partial struct quadruple
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter(quadruple f128) => QuadrupleToQuarter(f128);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half(quadruple f128) => QuadrupleToHalf(f128);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float(quadruple f128) => QuadrupleToFloat(f128);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator double(quadruple f128) => QuadrupleToDouble(f128);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator quadruple(quarter q)
        {
            FloatingPointPromise<quarter> promise = new FloatingPointPromise<quarter>(q);

            ulong sign = (ulong)(q.value >> 7) << 63;
            ulong exp = (ulong)q.value & quarter.SIGNALING_EXPONENT;
            uint frac = fracF8UI(q.value);
            
            if (Hint.Unlikely(exp == 0))
            {
                if (promise.NotSubnormal)
                {
                    exp = 0;
                }
                else
                {
                    softfloat_normSubnormalF8Sig(ref exp, ref frac, promise.NonZero);
                }
            }
            else
            {
                if (!(promise.NotNaN 
                   && promise.NotInf)
                 && Hint.Unlikely(exp == bitmask64((ulong)quarter.EXPONENT_BITS) << quarter.MANTISSA_BITS))
                {
                    return new quadruple(promise.NotNaN ? 0ul : tobyte(frac != 0), sign | SIGNALING_EXPONENT.hi64);
                }

                exp += F8_EXPONENT_OFFSET << quarter.MANTISSA_BITS;
                exp <<= MANTISSA_BITS_HI64 - quarter.MANTISSA_BITS;
            }

            return new quadruple(0, packToF128UI64(sign, exp, (ulong)frac << (MANTISSA_BITS_HI64 - quarter.MANTISSA_BITS)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator quadruple(half h)
        {
            FloatingPointPromise<half> promise = new FloatingPointPromise<half>(h);

            ulong sign = (ulong)(h.value >> 15) << 63;
            ulong exp = (ulong)h.value & F16_SIGNALING_EXPONENT;
            uint frac = fracF16UI(h.value);
            
            if (Hint.Unlikely(exp == 0))
            {
                if (promise.NotSubnormal)
                {
                    exp = 0;
                }
                else
                {
                    softfloat_normSubnormalF16Sig(ref exp, ref frac, promise.NonZero);
                }
            }
            else
            {
                if (!(promise.NotNaN 
                   && promise.NotInf)
                 && Hint.Unlikely(exp == bitmask64((ulong)F16_EXPONENT_BITS) << F16_MANTISSA_BITS))
                {
                    return new quadruple(promise.NotNaN ? 0ul : tobyte(frac != 0), sign | SIGNALING_EXPONENT.hi64);
                }
                
                exp += F16_EXPONENT_OFFSET << F16_MANTISSA_BITS;
                exp <<= MANTISSA_BITS_HI64 - F16_MANTISSA_BITS;
            }

            return new quadruple(0, packToF128UI64(sign, exp, (ulong)frac << (MANTISSA_BITS_HI64 - F16_MANTISSA_BITS)));
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator quadruple(float f)
        {
            FloatingPointPromise<float> promise = new FloatingPointPromise<float>(f);

            uint uiA = asuint(f);
            ulong sign = (ulong)(uiA >> 31) << 63;;
            ulong exp = (ulong)asuint(f) & F32_SIGNALING_EXPONENT;
            uint frac = fracF32UI(uiA);
            
            if (Hint.Unlikely(exp == 0))
            {
                if (promise.NotSubnormal)
                {
                    exp = 0;
                }
                else
                {
                    softfloat_normSubnormalF32Sig(ref exp, ref frac, promise.NonZero);
                }
            }
            else
            {
                if (!(promise.NotNaN 
                   && promise.NotInf)
                 && Hint.Unlikely(exp == bitmask64((ulong)F32_EXPONENT_BITS) << F32_MANTISSA_BITS))
                {
                    return new quadruple(promise.NotNaN ? 0ul : tobyte(frac != 0), sign | SIGNALING_EXPONENT.hi64);
                }
                
                exp += (ulong)F32_EXPONENT_OFFSET << F32_MANTISSA_BITS;
                exp <<= MANTISSA_BITS_HI64 - F32_MANTISSA_BITS;
            }
    
            return new quadruple(0, packToF128UI64(sign, exp, (ulong)frac << (MANTISSA_BITS_HI64 - F32_MANTISSA_BITS)));
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator quadruple(double d)
        {
            FloatingPointPromise<double> promise = new FloatingPointPromise<double>(d);

            ulong uiA = asulong(d);
            ulong sign = uiA & (1ul << 63);
            ulong exp = asulong(d) & F64_SIGNALING_EXPONENT;
            ulong frac = fracF64UI(uiA);
            
            if (Hint.Unlikely(exp == 0))
            {
                if (COMPILATION_OPTIONS.FLOAT_DENORMALS_ARE_ZERO)
                {
                    exp = 0;
                }
                else
                {
                    softfloat_normSubnormalF64Sig(ref exp, ref frac, promise.NonZero);
                }
            }
            else
            {
                if (!(promise.NotNaN 
                   && promise.NotInf))
                {
                    if (Hint.Unlikely(exp == bitmask64((ulong)F64_EXPONENT_BITS) << F64_MANTISSA_BITS))
                    {
                        return new quadruple(tobyte(frac != 0), sign | SIGNALING_EXPONENT.hi64);
                    }
                }
                
                exp >>= F64_MANTISSA_BITS - MANTISSA_BITS_HI64;
                exp += (ulong)F64_EXPONENT_OFFSET << MANTISSA_BITS_HI64;
            }

            return new quadruple(frac << 60, packToF128UI64(sign, exp, frac >> 4));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quarter QuadrupleToQuarter(quadruple.ConstChecked f128)
        {
            ulong sign = f128.Value.value.hi64 >> 63;
            ulong exp = f128.Value.value.hi64 & SIGNALING_EXPONENT.hi64;
            ulong frac64 = fracF128UI64(f128.Value.value.hi64) | tobyte(f128.Value.value.lo64 != 0);
            
            bool denormalF8 = exp <= (ulong)F8_EXPONENT_OFFSET << MANTISSA_BITS_HI64;
            bool overflow = abs(f128).value > asuint128((quadruple)quarter.MaxValue);
            bool noUnderflow = exp >= (ulong)(quarter.MIN_UNBIASED_EXPONENT - quarter.MANTISSA_BITS - 1 - EXPONENT_BIAS) << MANTISSA_BITS_HI64;

            exp -= (ulong)F8_EXPONENT_OFFSET << MANTISSA_BITS_HI64;
            byte frac8;
            if (Hint.Unlikely(denormalF8))
            {
                int bitIndex = quarter.MANTISSA_BITS - 1 - (int)abs((long)exp >> MANTISSA_BITS_HI64);
                frac8 = (byte)(tobyte(noUnderflow) << bitIndex);
                frac8 |= (byte)((frac64 & (ulong)-tolong(noUnderflow)) >> (MANTISSA_BITS_HI64 - bitIndex));
                
                return asquarter((byte)(((int)sign << (quarter.BITS - 1)) | frac8));
            }
            else
            {
                if (overflow)
                {
                    bool nan = f128.Promise.NotNaN ? false : isnan(f128);
                    return asquarter((byte)(((int)sign << (quarter.BITS - 1)) | quarter.SIGNALING_EXPONENT | tobyte(nan)));
                }
                else
                {
                    frac8 = (byte)(frac64 >> (MANTISSA_BITS_HI64 - quarter.MANTISSA_BITS));

                    byte round = tobyte((frac64 & bitmask64((ulong)(MANTISSA_BITS_HI64 - quarter.MANTISSA_BITS))) != 0);
                    frac8 += round;
            
                    return asquarter((byte)(((int)sign << (quarter.BITS - 1)) | (byte)(exp >> (MANTISSA_BITS_HI64 - quarter.MANTISSA_BITS)) | frac8));
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static half QuadrupleToHalf(quadruple.ConstChecked f128)
        {
            ulong sign = f128.Value.value.hi64 >> 63;
            ulong exp = f128.Value.value.hi64 & SIGNALING_EXPONENT.hi64;
            ulong frac64 = fracF128UI64(f128.Value.value.hi64) | tobyte(f128.Value.value.lo64 != 0);
            
            if (!(f128.Promise.NotNaN 
               && f128.Promise.NotInf))
            {
                if (Hint.Unlikely(exp == SIGNALING_EXPONENT.hi64))
                {
                    ushort cvtINF = (ushort)((sign << (F16_BITS - 1)) | F16_SIGNALING_EXPONENT);

                    if (!f128.Promise.NotNaN)
                    {
                        cvtINF |= tobyte(frac64 != 0);
                    }
                    
                    return ashalf(cvtINF);
                }
            }

            bool denormalF16 = exp <= (ulong)F16_EXPONENT_OFFSET << MANTISSA_BITS_HI64;
            bool overflow = abs(f128).value > asuint128((quadruple)Unity.Mathematics.half.MaxValueAsHalf);
            bool noUnderflow = exp >= (ulong)(F16_MIN_UNBIASED_EXPONENT - F16_MANTISSA_BITS - 1 - EXPONENT_BIAS) << MANTISSA_BITS_HI64;

            exp -= (ulong)F16_EXPONENT_OFFSET << MANTISSA_BITS_HI64;
            ushort frac16;
            if (Hint.Unlikely(denormalF16))
            {
                int bitIndex = F16_MANTISSA_BITS - 1 - (int)abs((long)exp >> MANTISSA_BITS_HI64);
                frac16 = (ushort)(tobyte(noUnderflow) << bitIndex);
                frac16 |= (ushort)((frac64 & (ulong)-tolong(noUnderflow)) >> (MANTISSA_BITS_HI64 - bitIndex));
                
                return ashalf((ushort)(((int)sign << (F16_BITS - 1)) | frac16));
            }
            else
            {
                if (overflow)
                {
                    bool nan = f128.Promise.NotNaN ? false : isnan(f128);
                    return ashalf((ushort)(((int)sign << (F16_BITS - 1)) | F16_SIGNALING_EXPONENT | tobyte(nan)));
                }
                else
                {
                    frac16 = (ushort)(frac64 >> (MANTISSA_BITS_HI64 - F16_MANTISSA_BITS));

                    byte round = tobyte((frac64 & bitmask64((ulong)(MANTISSA_BITS_HI64 - F16_MANTISSA_BITS))) != 0);
                    frac16 += round;
            
                    return ashalf((ushort)(((int)sign << (F16_BITS - 1)) | (ushort)(exp >> (MANTISSA_BITS_HI64 - F16_MANTISSA_BITS)) | frac16));
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static float QuadrupleToFloat(quadruple.ConstChecked f128)
        {
            ulong sign = f128.Value.value.hi64 >> 63;
            ulong exp = f128.Value.value.hi64 & SIGNALING_EXPONENT.hi64;
            ulong frac64 = fracF128UI64(f128.Value.value.hi64) | tobyte(f128.Value.value.lo64 != 0);
            
            bool denormalF32 = exp <= (ulong)F32_EXPONENT_OFFSET << MANTISSA_BITS_HI64;
            bool overflow = abs(f128).value > asuint128((quadruple)float.MaxValue);
            bool noUnderflow = exp >= (ulong)(F32_MIN_UNBIASED_EXPONENT - F32_MANTISSA_BITS - 1 - EXPONENT_BIAS) << MANTISSA_BITS_HI64;

            exp -= (ulong)F32_EXPONENT_OFFSET << MANTISSA_BITS_HI64;
            uint frac32;
            if (Hint.Unlikely(denormalF32))
            {
                int bitIndex = F32_MANTISSA_BITS - 1 - (int)abs((long)exp >> MANTISSA_BITS_HI64);
                frac32 = touint(noUnderflow) << bitIndex;
                frac32 |= (uint)((frac64 & (ulong)-tolong(noUnderflow)) >> (MANTISSA_BITS_HI64 - bitIndex));
                
                return asfloat(((uint)sign << (F32_BITS - 1)) | frac32);
            }
            else
            {
                if (overflow)
                {
                    bool nan = f128.Promise.NotNaN ? false : isnan(f128);
                    return asfloat(((uint)sign << (F32_BITS - 1)) | F32_SIGNALING_EXPONENT | tobyte(nan));
                }
                else
                {
                    frac32 = (uint)(frac64 >> (MANTISSA_BITS_HI64 - F32_MANTISSA_BITS));

                    byte round = tobyte((frac64 & bitmask64((ulong)(MANTISSA_BITS_HI64 - F32_MANTISSA_BITS))) != 0);
                    frac32 += round;
            
                    return asfloat(((uint)sign << (F32_BITS - 1)) | (uint)(exp >> (MANTISSA_BITS_HI64 - F32_MANTISSA_BITS)) | frac32);
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static double QuadrupleToDouble(quadruple.ConstChecked f128)
        {
            ulong sign = f128.Value.value.hi64 & (1ul << 63);
            ulong exp = f128.Value.value.hi64 & SIGNALING_EXPONENT.hi64;
            UInt128 frac128 = f128.Value.value & bitmask128((ulong)MANTISSA_BITS);
            
            bool denormalF64 = exp <= (ulong)F64_EXPONENT_OFFSET << MANTISSA_BITS_HI64;
            bool overflow = abs(f128).value > asuint128((quadruple)double.MaxValue);
            bool noUnderflow = exp >= (ulong)(F64_MIN_UNBIASED_EXPONENT - F64_MANTISSA_BITS - 1 - EXPONENT_BIAS) << MANTISSA_BITS_HI64;

            exp -= (ulong)F64_EXPONENT_OFFSET << MANTISSA_BITS_HI64;
            ulong frac64;
            if (Hint.Unlikely(denormalF64))
            {
                int bitIndex = F64_MANTISSA_BITS - 1 - (int)abs((long)exp >> MANTISSA_BITS_HI64);
                frac64 = toulong(noUnderflow) << bitIndex;
                frac64 |= (ulong)((frac128 & new UInt128((ulong)-tolong(noUnderflow), (ulong)-tolong(noUnderflow))) >> (MANTISSA_BITS - bitIndex));
                
                return asdouble(sign | frac64);
            }
            else
            {
                if (overflow)
                {
                    bool nan = f128.Promise.NotNaN ? false : isnan(f128);
                    return asdouble(sign | F64_SIGNALING_EXPONENT | tobyte(nan));
                }
                else
                {
                    frac64 = (ulong)(frac128 >> (MANTISSA_BITS - F64_MANTISSA_BITS));

                    byte round = tobyte((frac128.lo64 & bitmask64((ulong)(MANTISSA_BITS - F64_MANTISSA_BITS))) != 0);
                    frac64 += round;
            
                    return asdouble(sign | (exp << -(MANTISSA_BITS_HI64 - F64_MANTISSA_BITS)) | frac64);
                }
            }
        }
    }
}
