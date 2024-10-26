using System.Runtime.CompilerServices;
using Unity.Mathematics;
using MaxMath.Intrinsics;
using DevTools;

using static Unity.Mathematics.math;
using static MaxMath.maxmath;
using static MaxMath.LUT.FLOATING_POINT;

namespace MaxMath
{
    unsafe internal struct FloatingPointPromise<T>
        where T : unmanaged
    {
        internal const Promise NOT_NAN = Promise.Unsafe0;
        internal const Promise NOT_INF = Promise.Unsafe1;
        internal const Promise NON_ZERO = Promise.NonZero;
        internal const Promise NO_SIGNED_ZERO = Promise.Unsafe2;
        internal const Promise NOT_SUBNORMAL = Promise.Unsafe3;
        internal const Promise POSITIVE = Promise.Positive;
        internal const Promise NEGATIVE = Promise.Negative;
        internal const Promise ZERO_OR_GREATER = Promise.ZeroOrGreater;
        internal const Promise ZERO_OR_LESS = Promise.ZeroOrLess;
        internal const Promise NORMAL = NOT_SUBNORMAL | NOT_NAN | NOT_INF | NON_ZERO;
    
        private Promise _promises;
        private T? _minPossible;
        private T? _maxPossible;
    
        // can deduce some promises from min and max
        internal T MinPossible 
        { 
            readonly get
            {
                if (_minPossible.HasValue 
                 && constexpr.IS_CONST(_minPossible.Value))
                {
                    return _minPossible.Value;
                }
                else
                {
                    switch (sizeof(T))
                    {
                        case 1:  return quarter.NegativeInfinity.Reinterpret<quarter, T>();
                        case 2:  return ((Unity.Mathematics.half)float.NegativeInfinity).Reinterpret<half, T>();
                        case 4:  return float.NegativeInfinity.Reinterpret<float, T>();
                        case 8:  return double.NegativeInfinity.Reinterpret<double, T>();
                        case 16: return quadruple.NegativeInfinity.Reinterpret<quadruple, T>();

                        default: throw Assert.Unreachable();
                    }
                }
            }

            set
            {
                if (constexpr.IS_CONST(value))
                {
                    _minPossible = value;
                }
            }
        }

        internal T MaxPossible
        { 
            readonly get
            {
                if (_maxPossible.HasValue 
                 && constexpr.IS_CONST(_maxPossible.Value))
                {
                    return _maxPossible.Value;
                }
                else
                {
                    switch (sizeof(T))
                    {
                        case 1:  return quarter.PositiveInfinity.Reinterpret<quarter, T>();
                        case 2:  return ((Unity.Mathematics.half)float.PositiveInfinity).Reinterpret<half, T>();
                        case 4:  return float.PositiveInfinity.Reinterpret<float, T>();
                        case 8:  return double.PositiveInfinity.Reinterpret<double, T>();
                        case 16: return quadruple.PositiveInfinity.Reinterpret<quadruple, T>();

                        default: throw Assert.Unreachable();
                    }
                }
            }

            set
            {
                if (constexpr.IS_CONST(value))
                {
                    _maxPossible = value;
                }
            }
        }
    
        internal readonly bool NotNaN        => Promises(NOT_NAN);
        internal readonly bool NotInf        => Promises(NOT_INF);
        internal readonly bool NonZero       => Promises(NON_ZERO);
        internal readonly bool NoSignedZero  => Promises(NO_SIGNED_ZERO);
        internal readonly bool NotSubnormal  => Promises(NOT_SUBNORMAL);
        internal readonly bool Positive      => Promises(POSITIVE);
        internal readonly bool Negative      => Promises(NEGATIVE);
        internal readonly bool ZeroOrGreater => Promises(ZERO_OR_GREATER);
        internal readonly bool ZeroOrLess    => Promises(ZERO_OR_LESS);
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal FloatingPointPromise(T f)
        {
            _minPossible = null;
            _maxPossible = null;
            
            _promises  = COMPILATION_OPTIONS.FLOAT_NO_NAN               ? NOT_NAN : Promise.Nothing;
            _promises |= COMPILATION_OPTIONS.FLOAT_NO_INF               ? NOT_INF : Promise.Nothing;
            _promises |= !COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO         ? NO_SIGNED_ZERO : Promise.Nothing;
            _promises |= COMPILATION_OPTIONS.FLOAT_DENORMALS_ARE_ZERO   ? NOT_SUBNORMAL : Promise.Nothing;

            switch (sizeof(T))
            {
                case 1:
                {
                    quarter f8 = f.Reinterpret<T, quarter>();

                    _promises  = constexpr.IS_FALSE(isnan(f8))                                                                            ? NOT_NAN : Promise.Nothing;
                    _promises |= constexpr.IS_FALSE(isinf(f8))                                                                            ? NOT_INF : Promise.Nothing;
                    _promises |= constexpr.IS_TRUE(f8.value != 1 << 7)                                                                    ? NO_SIGNED_ZERO : Promise.Nothing;
                    _promises |= constexpr.IS_TRUE((byte)(f8.value + f8.value) != 0 || (byte)(f8.value << 1) != 0)                        ? NON_ZERO : Promise.Nothing;
                    if (NonZero && NotNaN && NotInf)
                    {
                        _promises |= constexpr.IS_TRUE((f8.value & bitmask8((uint)quarter.EXPONENT_BITS, quarter.MANTISSA_BITS)) != 0)    ? NOT_SUBNORMAL : Promise.Nothing;
                    }                                                                                                  
                    else                                                                                               
                    {                                                                                                  
                        _promises |= constexpr.IS_FALSE(issubnormal(f8)) || constexpr.IS_TRUE(isnormal(f8))                               ? NOT_SUBNORMAL : Promise.Nothing;
                    }   
                        
                    _promises |= constexpr.IS_TRUE(isinrange(f8.value, (byte)0, quarter.MaxValue.value))                                  ? ZERO_OR_GREATER : Promise.Nothing;
                    _promises |= constexpr.IS_TRUE(isinrange((sbyte)f8.value, (sbyte)quarter.MinValue.value, (sbyte)0))                   ? ZERO_OR_LESS : Promise.Nothing;

                    break;
                }
                case 2:
                {
                    half f16 = f.Reinterpret<T, half>();
                    
                    _promises  = constexpr.IS_FALSE(isnan(f16))                                                                                 ? NOT_NAN : Promise.Nothing;
                    _promises |= constexpr.IS_FALSE(isinf(f16))                                                                                 ? NOT_INF : Promise.Nothing;
                    _promises |= constexpr.IS_TRUE(f16.value != 1 << 15)                                                                        ? NO_SIGNED_ZERO : Promise.Nothing;
                    _promises |= constexpr.IS_TRUE((ushort)(f16.value + f16.value) != 0 || (ushort)(f16.value << 1) != 0)                       ? NON_ZERO : Promise.Nothing;
                    if (NonZero && NotNaN && NotInf)
                    {
                        _promises |= constexpr.IS_TRUE((f16.value & bitmask16((uint)F16_EXPONENT_BITS, F16_MANTISSA_BITS)) != 0)                ? NOT_SUBNORMAL : Promise.Nothing;
                    }                                                                                                  
                    else                                                                                               
                    {                                                                                                  
                        _promises |= constexpr.IS_FALSE(issubnormal(f16)) || constexpr.IS_TRUE(isnormal(f16))                                   ? NOT_SUBNORMAL : Promise.Nothing;
                    }   
                        
                    _promises |= constexpr.IS_TRUE(isinrange(f16.value, (ushort)0, Unity.Mathematics.half.MaxValueAsHalf.value))                ? ZERO_OR_GREATER : Promise.Nothing;
                    _promises |= constexpr.IS_TRUE(isinrange((short)f16.value, (short)Unity.Mathematics.half.MinValueAsHalf.value, (short)0))   ? ZERO_OR_LESS : Promise.Nothing;

                    break;
                }
                case 4:
                {
                    float f32 = f.Reinterpret<T, float>();
                    
                    _promises  = constexpr.IS_FALSE(isnan(f32))                                                                         ? NOT_NAN : Promise.Nothing;
                    _promises |= constexpr.IS_FALSE(isinf(f32))                                                                         ? NOT_INF : Promise.Nothing;
                    _promises |= constexpr.IS_TRUE(asuint(f32) != 1u << 31)                                                             ? NO_SIGNED_ZERO : Promise.Nothing;
                    _promises |= constexpr.IS_TRUE(asuint(f32) + asuint(f32) != 0 || asuint(f32) << 1 != 0)                             ? NON_ZERO : Promise.Nothing;
                    if (NonZero && NotNaN && NotInf)
                    {
                        _promises |= constexpr.IS_TRUE((asuint(f32) & bitmask32((uint)F32_EXPONENT_BITS, F32_MANTISSA_BITS)) != 0)      ? NOT_SUBNORMAL : Promise.Nothing;
                    }                                                                                                  
                    else                                                                                               
                    {                                                                                                  
                        _promises |= constexpr.IS_FALSE(issubnormal(f32)) || constexpr.IS_TRUE(isnormal(f32))                           ? NOT_SUBNORMAL : Promise.Nothing;
                    }   
                        
                    _promises |= constexpr.IS_TRUE(isinrange(asuint(f32), 0, asuint(float.MaxValue)))                                   ? ZERO_OR_GREATER : Promise.Nothing;
                    _promises |= constexpr.IS_TRUE(isinrange(asuint(f32), asuint(float.MinValue), 0))                                   ? ZERO_OR_LESS : Promise.Nothing;

                    break;
                }
                case 8:
                {
                    double f64 = f.Reinterpret<T, double>();
                    
                    _promises  = constexpr.IS_FALSE(isnan(f64))                                                                           ? NOT_NAN : Promise.Nothing;
                    _promises |= constexpr.IS_FALSE(isinf(f64))                                                                           ? NOT_INF : Promise.Nothing;
                    _promises |= constexpr.IS_TRUE(asulong(f64) != 1ul << 63)                                                             ? NO_SIGNED_ZERO : Promise.Nothing;
                    _promises |= constexpr.IS_TRUE(asulong(f64) + asulong(f64) != 0 || asulong(f64) << 1 != 0)                            ? NON_ZERO : Promise.Nothing;
                    if (NonZero && NotNaN && NotInf)
                    {
                        _promises |= constexpr.IS_TRUE((asulong(f64) & bitmask64((ulong)F64_EXPONENT_BITS, F64_MANTISSA_BITS)) != 0)      ? NOT_SUBNORMAL : Promise.Nothing;
                    }                                                                                                  
                    else                                                                                               
                    {                                                                                                  
                        _promises |= constexpr.IS_FALSE(issubnormal(f64)) || constexpr.IS_TRUE(isnormal(f64))                             ? NOT_SUBNORMAL : Promise.Nothing;
                    }   
                        
                    _promises |= constexpr.IS_TRUE(isinrange(asulong(f64), 0, asulong(double.MaxValue)))                                  ? ZERO_OR_GREATER : Promise.Nothing;
                    _promises |= constexpr.IS_TRUE(isinrange(asulong(f64), asulong(double.MinValue), 0))                                  ? ZERO_OR_LESS : Promise.Nothing;

                    break;
                }
                case 16:
                {
                    quadruple f128 = f.Reinterpret<T, quadruple>();
                    _promises  = constexpr.IS_FALSE(isnan(f128))                                                                                            ? NOT_NAN : Promise.Nothing;
                    _promises |= constexpr.IS_FALSE(isinf(f128))                                                                                            ? NOT_INF : Promise.Nothing;
                    _promises |= constexpr.IS_TRUE(f128.value != (UInt128)1 << 127)                                                                         ? NO_SIGNED_ZERO : Promise.Nothing;
                    _promises |= constexpr.IS_TRUE((f128.value + f128.value).IsNotZero || (f128.value << 1).IsNotZero)                                      ? NON_ZERO : Promise.Nothing;
                    if (NonZero && NotNaN && NotInf)
                    {
                        _promises |= constexpr.IS_TRUE((f128.value.hi64 & bitmask64((ulong)quadruple.EXPONENT_BITS, quadruple.MANTISSA_BITS_HI64)) != 0)    ? NOT_SUBNORMAL : Promise.Nothing;
                    }                                                                                                  
                    else                                                                                               
                    {                                                                                                  
                        _promises |= constexpr.IS_FALSE(issubnormal(f128)) || constexpr.IS_TRUE(isnormal(f128))                                             ? NOT_SUBNORMAL : Promise.Nothing;
                    }   
                        
                    _promises |= constexpr.IS_TRUE(isinrange(f128.value, 0, quadruple.MaxValue.value))                                                      ? ZERO_OR_GREATER : Promise.Nothing;
                    _promises |= constexpr.IS_TRUE(isinrange((Int128)f128.value, (Int128)quadruple.MinValue.value, 0))                                      ? ZERO_OR_LESS : Promise.Nothing;

                    break;
                }
                default: throw Assert.Unreachable();
            }

            // TODO: reintroduce - stack overflow if constexpr returns true
            //Assume(f);
        }
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator FloatingPointPromise<T>(Promise p) => new FloatingPointPromise<T>{ _promises = p };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Promise(FloatingPointPromise<T> p) => p._promises;
    
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Promise operator & (FloatingPointPromise<T> lhs, Promise rhs)
        {
            if (constexpr.IS_CONST(lhs)
             && constexpr.IS_CONST(rhs))
            {
                return (Promise)lhs & rhs;
            }
            else
            {
                return Promise.Nothing;
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Promise operator | (FloatingPointPromise<T> lhs, Promise rhs)
        {
            if (constexpr.IS_CONST(lhs))
            {
                if (constexpr.IS_CONST(rhs))
                {
                    return (Promise)lhs | rhs;
                }
                else
                {
                    return lhs;
                }
            }
            else if (constexpr.IS_CONST(rhs))
            {
                return rhs;
            }
            else
            {
                return Promise.Nothing;
            }
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void FlipSign()
        {
            if (Negative)
            {
                this ^= NEGATIVE;
                this |= POSITIVE;
            }
            else if (Positive)
            {
                this ^= POSITIVE;
                this |= NEGATIVE;
            }
            else if (ZeroOrGreater)
            {
                this ^= ZERO_OR_GREATER;
                this |= ZERO_OR_LESS;
            }
            else if (Positive)
            {
                this ^= ZERO_OR_LESS;
                this |= ZERO_OR_GREATER;
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal readonly void Assume(T f)
        {
            switch (sizeof(T))
            {
                case 1:
                {
                    quarter f8 = f.Reinterpret<T, quarter>();

                    if (NotNaN)        constexpr.ASSUME(!isnan(f8));
                    if (NotInf)        constexpr.ASSUME(!isinf(f8)   &&   isfinite(f8));
                    if (NonZero)       constexpr.ASSUME(f8 != 0   &&   (f8 < 0 || f8 > 0));
                    if (NoSignedZero)  constexpr.ASSUME(f8.value != 1 << 7);
                    if (NotSubnormal)  constexpr.ASSUME(!issubnormal(f8));
                    if (Positive)      constexpr.ASSUME(f8 > 0);
                    if (Negative)      constexpr.ASSUME(f8 < 0);
                    if (ZeroOrGreater) constexpr.ASSUME(f8 >= 0);
                    if (ZeroOrLess)    constexpr.ASSUME(f8 <= 0);

                    break;
                }
                case 2:
                {
                    half f16 = f.Reinterpret<T, half>();
                    
                    if (NotNaN)        constexpr.ASSUME(!isnan(f16));
                    if (NotInf)        constexpr.ASSUME(!isinf(f16)   &&   isfinite(f16));
                    if (NonZero)       constexpr.ASSUME(f16 != 0   &&   (f16 < 0 || f16 > 0));
                    if (NoSignedZero)  constexpr.ASSUME(f16.value != 1 << 15);
                    if (NotSubnormal)  constexpr.ASSUME(!issubnormal(f16));
                    if (Positive)      constexpr.ASSUME(f16 > 0);
                    if (Negative)      constexpr.ASSUME(f16 < 0);
                    if (ZeroOrGreater) constexpr.ASSUME(f16 >= 0);
                    if (ZeroOrLess)    constexpr.ASSUME(f16 <= 0);

                    break;
                }
                case 4:
                {
                    float f32 = f.Reinterpret<T, float>();
                    
                    if (NotNaN)        constexpr.ASSUME(!isnan(f32));
                    if (NotInf)        constexpr.ASSUME(!isinf(f32)   &&   isfinite(f32));
                    if (NonZero)       constexpr.ASSUME(f32 != 0   &&   (f32 < 0 || f32 > 0));
                    if (NoSignedZero)  constexpr.ASSUME(asuint(f32) != 1u << 31);
                    if (NotSubnormal)  constexpr.ASSUME(!issubnormal(f32));
                    if (Positive)      constexpr.ASSUME(f32 > 0);
                    if (Negative)      constexpr.ASSUME(f32 < 0);
                    if (ZeroOrGreater) constexpr.ASSUME(f32 >= 0);
                    if (ZeroOrLess)    constexpr.ASSUME(f32 <= 0);

                    break;
                }
                case 8:
                {
                    double f64 = f.Reinterpret<T, double>();
                    
                    if (NotNaN)        constexpr.ASSUME(!isnan(f64));
                    if (NotInf)        constexpr.ASSUME(!isinf(f64)   &&   isfinite(f64));
                    if (NonZero)       constexpr.ASSUME(f64 != 0   &&   (f64 < 0 || f64 > 0));
                    if (NoSignedZero)  constexpr.ASSUME(asulong(f64) != 1ul << 63);
                    if (NotSubnormal)  constexpr.ASSUME(!issubnormal(f64));
                    if (Positive)      constexpr.ASSUME(f64 > 0);
                    if (Negative)      constexpr.ASSUME(f64 < 0);
                    if (ZeroOrGreater) constexpr.ASSUME(f64 >= 0);
                    if (ZeroOrLess)    constexpr.ASSUME(f64 <= 0);

                    break;
                }
                case 16:
                {
                    quadruple f128 = f.Reinterpret<T, quadruple>();
                    
                    if (NotNaN)        constexpr.ASSUME(!isnan(f128));
                    if (NotInf)        constexpr.ASSUME(!isinf(f128)   &&   isfinite(f128));
                    if (NonZero)       constexpr.ASSUME(f128 != default(quadruple)   &&   (f128 < default(quadruple) || f128 > default(quadruple)));
                    if (NoSignedZero)  constexpr.ASSUME(f128.value != (UInt128)1 << 127);
                    if (NotSubnormal)  constexpr.ASSUME(!issubnormal(f128));
                    if (Positive)      constexpr.ASSUME(f128 > default(quadruple));
                    if (Negative)      constexpr.ASSUME(f128 < default(quadruple));
                    if (ZeroOrGreater) constexpr.ASSUME(f128 >= default(quadruple));
                    if (ZeroOrLess)    constexpr.ASSUME(f128 <= default(quadruple));

                    break;
                }
                default: throw Assert.Unreachable();
            }
        }

        // Necessary, because _promises could be loaded from RAM and would deterministically throw
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private readonly bool Promises(Promise p)
        {
            return constexpr.IS_CONST(_promises) && _promises.Promises(p);
        }
    }
}
