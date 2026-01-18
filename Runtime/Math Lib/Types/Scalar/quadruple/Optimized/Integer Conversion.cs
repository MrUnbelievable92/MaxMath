using System.Runtime.CompilerServices;
using DevTools;
using MaxMath.Intrinsics;

using static MaxMath.maxmath;
using static Unity.Mathematics.math;

namespace MaxMath
{
    unsafe public readonly partial struct quadruple
    {
        private const Promise FROM_SIGNED_INTEGER_BASER_PROMISE = FloatingPointPromise<quadruple>.NOT_NAN
                                                                | FloatingPointPromise<quadruple>.NOT_INF
                                                                | FloatingPointPromise<quadruple>.NO_SIGNED_ZERO
                                                                | FloatingPointPromise<quadruple>.NOT_SUBNORMAL;

        private const Promise FROM_UNSIGNED_INTEGER_BASER_PROMISE = FROM_SIGNED_INTEGER_BASER_PROMISE
                                                                  | FloatingPointPromise<quadruple>.ZERO_OR_GREATER;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static quadruple.ConstChecked MaxUInt<T>()
            where T : unmanaged
        {
            switch (sizeof(T))
            {
                case sizeof(byte):   return new quadruple(0x0000_0000_0000_0000, 0x4006_FE00_0000_0000);
                case sizeof(ushort): return new quadruple(0x0000_0000_0000_0000, 0x400E_FFFE_0000_0000);
                case sizeof(uint):   return new quadruple(0x0000_0000_0000_0000, 0x401E_FFFF_FFFE_0000);
                case sizeof(ulong):  return new quadruple(0xFFFE_0000_0000_0000, 0x403E_FFFF_FFFF_FFFF);
                case 16:             return new quadruple(0x0000_0000_0000_0000, 0x407F_0000_0000_0000);

                default: throw Assert.Unreachable();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static quadruple.ConstChecked MinInt<T>()
            where T : unmanaged
        {
            switch (sizeof(T))
            {
                case sizeof(sbyte): return new quadruple(0x0000_0000_0000_0000, 0xC006_0000_0000_0000);
                case sizeof(short): return new quadruple(0x0000_0000_0000_0000, 0xC00E_0000_0000_0000);
                case sizeof(int):   return new quadruple(0x0000_0000_0000_0000, 0xC01E_0000_0000_0000);
                case sizeof(long):  return new quadruple(0x0000_0000_0000_0000, 0xC03E_0000_0000_0000);
                case 16:            return new quadruple(0x0000_0000_0000_0000, 0xC07E_0000_0000_0000);

                default: throw Assert.Unreachable();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static quadruple.ConstChecked MaxInt<T>()
            where T : unmanaged
        {
            switch (sizeof(T))
            {
                case sizeof(sbyte): return new quadruple(0x0000_0000_0000_0000, 0x4005_FC00_0000_0000);
                case sizeof(short): return new quadruple(0x0000_0000_0000_0000, 0x400D_FFFC_0000_0000);
                case sizeof(int):   return new quadruple(0x0000_0000_0000_0000, 0x401D_FFFF_FFFC_0000);
                case sizeof(long):  return new quadruple(0xFFFC_0000_0000_0000, 0x403D_FFFF_FFFF_FFFF);
                case 16:            return new quadruple(0x0000_0000_0000_0000, 0x407E_0000_0000_0000);

                default: throw Assert.Unreachable();
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quadruple.ConstChecked u32tof128<T>(T ui)
            where T : unmanaged
        {
            uint ui32;
            switch (sizeof(T))
            {
                case sizeof(byte):   ui32 = ui.Reinterpret<T, byte>();   break;
                case sizeof(ushort): ui32 = ui.Reinterpret<T, ushort>(); break;
                case sizeof(uint):   ui32 = ui.Reinterpret<T, uint>();   break;

                default: throw Assert.Unreachable();
            }

            int shiftDist = lzcnt(ui32);
            quadruple.ConstChecked result = new quadruple(0, packToF128UI64(0, (ulong)((0x402E - 17) - ((ui32 == 0) ? (0x402E - 17) : shiftDist)) << MANTISSA_BITS_HI64, (ulong)ui32 << (shiftDist + 17)));

            result.Promise.MinPossible = default(quadruple);
            result.Promise.MaxPossible = MaxUInt<T>();
            result.Promise |= FROM_UNSIGNED_INTEGER_BASER_PROMISE;
            result.Promise |= constexpr.IS_TRUE(ui32 != 0) ? FloatingPointPromise<quadruple>.NON_ZERO : Promise.Nothing;
            result.Promise.Assume(result.Value);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quadruple.ConstChecked u64tof128(ulong ul)
        {
            int shiftDist = lzcnt(ul);
            UInt128 zSig;
            if (ul < 0x0002_0000_0000_0000)
            {
                zSig = new UInt128(0, ul << (shiftDist - (64 - 49)));
            }
            else
            {
                zSig = softfloat_shortShiftLeft128(0, ul, (byte)(shiftDist + 49));
            }

            quadruple.ConstChecked result = new quadruple(zSig.lo64, packToF128UI64(0, ((0x406E - 49) - (ulong)shiftDist) << MANTISSA_BITS_HI64, zSig.hi64));

            result.Promise.MinPossible = default(quadruple);
            result.Promise.MaxPossible = MaxUInt<ulong>();
            result.Promise |= FROM_UNSIGNED_INTEGER_BASER_PROMISE;
            result.Promise |= constexpr.IS_TRUE(ul != 0) ? FloatingPointPromise<quadruple>.NON_ZERO : Promise.Nothing;
            result.Promise.Assume(result.Value);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quadruple.ConstChecked u128tof128(UInt128 u128)
        {
            quadruple POW_2to64 = asquadruple((UInt128)(64 - EXPONENT_BIAS) << MANTISSA_BITS);

            quadruple.ConstChecked cvtLo = u64tof128(u128.lo64);
            quadruple.ConstChecked cvtHi = u64tof128(u128.hi64);
            quadruple.ConstChecked result = fmadd(POW_2to64, cvtHi, cvtLo);

            result.Promise.MinPossible = default(quadruple);
            result.Promise.MaxPossible = MaxUInt<ulong>();
            result.Promise |= FROM_UNSIGNED_INTEGER_BASER_PROMISE;
            result.Promise |= constexpr.IS_TRUE(u128.IsNotZero) ? FloatingPointPromise<quadruple>.NON_ZERO : Promise.Nothing;
            result.Promise.Assume(result.Value);

            return result;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quadruple.ConstChecked i32tof128<T>(T i)
            where T : unmanaged
        {
            int i32;
            switch (sizeof(T))
            {
                case sizeof(sbyte): i32 = i.Reinterpret<T, sbyte>(); break;
                case sizeof(short): i32 = i.Reinterpret<T, short>(); break;
                case sizeof(int):   i32 = i.Reinterpret<T, int>();   break;

                default: throw Assert.Unreachable();
            }

            if (constexpr.IS_TRUE(i32 >= 0))
            {
                return u32tof128((uint)i32);
            }

            quadruple.ConstChecked result = u32tof128((uint)abs(i32));
            result = new quadruple(result.Value.value.lo64, result.Value.value.hi64 ^ ((ulong)(i32 >> 31) << 63));

            result.Promise.MinPossible = MinInt<T>();
            result.Promise.MaxPossible = MaxInt<T>();
            result.Promise |= FROM_SIGNED_INTEGER_BASER_PROMISE;
            result.Promise |= constexpr.IS_TRUE(i32 != 0) ? FloatingPointPromise<quadruple>.NON_ZERO : Promise.Nothing;
            result.Promise.Assume(result.Value);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quadruple.ConstChecked i64tof128(long l)
        {
            if (constexpr.IS_TRUE(l >= 0))
            {
                return u64tof128((ulong)l);
            }

            quadruple.ConstChecked result = u64tof128((ulong)abs(l));
            result = new quadruple(result.Value.value.lo64, result.Value.value.hi64 ^ ((ulong)(l >> 63) << 63));

            result.Promise.MinPossible = MinInt<long>();
            result.Promise.MaxPossible = MaxInt<long>();
            result.Promise |= FROM_SIGNED_INTEGER_BASER_PROMISE;
            result.Promise |= constexpr.IS_TRUE(l != 0) ? FloatingPointPromise<quadruple>.NON_ZERO : Promise.Nothing;
            result.Promise.Assume(result.Value);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quadruple.ConstChecked i128tof128(Int128 i128)
        {
            if (constexpr.IS_TRUE(i128 >= 0))
            {
                return u128tof128((UInt128)i128);
            }

            quadruple.ConstChecked result = u128tof128((UInt128)abs(i128));
            result = new quadruple(result.Value.value.lo64, result.Value.value.hi64 ^ ((ulong)(i128.hi64 >> 63) << 63));

            result.Promise.MinPossible = MinInt<Int128>();
            result.Promise.MaxPossible = MaxInt<Int128>();
            result.Promise |= FROM_SIGNED_INTEGER_BASER_PROMISE;
            result.Promise |= constexpr.IS_TRUE(i128.IsNotZero) ? FloatingPointPromise<quadruple>.NON_ZERO : Promise.Nothing;
            result.Promise.Assume(result.Value);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator quadruple(byte b) => u32tof128(b);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator quadruple(ushort us) => u32tof128(us);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator quadruple(uint ui) => u32tof128(ui);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator quadruple(ulong ul) => u64tof128(ul);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator quadruple(UInt128 u128) => u128tof128(u128);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator quadruple(sbyte sb) => i32tof128(sb);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator quadruple(short s) => i32tof128(s);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator quadruple(int i) => i32tof128(i);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator quadruple(long l) => i64tof128(l);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator quadruple(Int128 i128) => i128tof128(i128);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte(quadruple f128) => (byte)(ulong)f128;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort(quadruple f128) => (ushort)(ulong)f128;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint(quadruple f128) => (uint)(UInt128)f128;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong(quadruple f128) => (ulong)(UInt128)f128;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator UInt128(quadruple f128)
        {
            return BASE_cvtf128i128(f128, signed: false, trunc: true);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte(quadruple f128) => (sbyte)(long)f128;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short(quadruple f128) => (short)(long)f128;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int(quadruple f128) => (int)(long)f128;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long(quadruple f128) => (long)(Int128)f128;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Int128(quadruple f128)
        {
            return (Int128)BASE_cvtf128i128(f128, signed: true, trunc: true);
        }
    }

    unsafe public static partial class maxmath
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static UInt128 BASE_cvtf128i128(quadruple.ConstChecked x, bool signed, bool trunc, bool evenOnTie = true)
        {
            UInt128 IMPLICIT_ONE = (UInt128)1ul << quadruple.MANTISSA_BITS;
            UInt128 MANTISSA_MASK = bitmask128((ulong)quadruple.MANTISSA_BITS);
            ulong EXP = (uint)abs(quadruple.EXPONENT_BIAS) + quadruple.MANTISSA_BITS;

            UInt128 __x = asuint128(x);

            ulong biasedExponent;
            if (x.Promise.Positive || (!signed && x.Promise.NonZero) || (x.Promise.NoSignedZero && x.Promise.ZeroOrGreater) || constexpr.IS_TRUE(__x < (UInt128)1ul << 127))
            {
                biasedExponent = __x.hi64 >> quadruple.MANTISSA_BITS_HI64;
            }
            else
            {
                biasedExponent = (__x.hi64 << 1) >> (quadruple.MANTISSA_BITS_HI64 + 1);
            }

            UInt128 mantissa = IMPLICIT_ONE | (__x & MANTISSA_MASK);
            ulong shift_mnt = EXP -            (biasedExponent > EXP ? EXP : biasedExponent);
            ulong shift_int = biasedExponent - (EXP > biasedExponent ? biasedExponent : EXP);

            UInt128 result = mantissa << (int)shift_int;

            if (!trunc)
            {
                ulong ifRound = tobyte(EXP > biasedExponent);
                UInt128 round = (UInt128)ifRound << (int)(shift_mnt - 1);
                if (evenOnTie)
                {
                    round -= andnot(ifRound, mantissa >> (int)shift_mnt);
                }

                result += round;
            }

            result >>= (int)(shift_mnt >= 128 ? 127 : shift_mnt);

            return (UInt128)negate((Int128)result, signed && quadruple.IsNegative(x));
        }
    }
}
