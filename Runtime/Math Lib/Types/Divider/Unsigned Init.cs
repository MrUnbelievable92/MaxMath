using System;
using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;
using MaxMath.Intrinsics;
using DevTools;

using static Unity.Burst.Intrinsics.X86;
using static Unity.Mathematics.math;
using static MaxMath.maxmath;

namespace MaxMath
{
    unsafe public partial struct Divider<T>
        where T : unmanaged, IEquatable<T>, IFormattable
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(byte divisor, Promise promises = Promise.Nothing)
            : this(divisor.Reinterpret<byte, T>(), promises, Signedness.Unsigned, sizeof(byte))
        {
#if DEBUG
_typeInfo = new TypeInfo(sizeof(byte), 1, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            bminit_u8(divisor, out ushort mul);

            _bigM = mul.Reinterpret<ushort, BigM>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(byte2 divisor, Promise promises = Promise.Nothing)
            : this(divisor.Reinterpret<byte2, T>(), promises, Signedness.Unsigned, sizeof(byte))
        {
#if DEBUG
_typeInfo = new TypeInfo(sizeof(byte), 2, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            if (_promises.SameValue)
            {
                bminit_u8(divisor.x, out ushort mul);

                _bigM = ((ushort2)mul).Reinterpret<ushort2, BigM>();
            }
            else
            {
                if (Architecture.IsSIMDSupported)
                {
                    bminit_epu8(divisor, out v128 mul16, _promises, 2);

                    _bigM = ((ushort2)mul16).Reinterpret<ushort2, BigM>();
                }
                else
                {
                    ushort2 mul;
                    bminit_u8(divisor.x, out mul.x);
                    bminit_u8(divisor.y, out mul.y);

                    _bigM = mul.Reinterpret<ushort2, BigM>();
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(byte3 divisor, Promise promises = Promise.Nothing)
            : this(divisor.Reinterpret<byte3, T>(), promises, Signedness.Unsigned, sizeof(byte))
        {
#if DEBUG
_typeInfo = new TypeInfo(sizeof(byte), 3, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            if (_promises.SameValue)
            {
                bminit_u8(divisor.x, out ushort mul);

                _bigM = ((ushort3)mul).Reinterpret<ushort3, BigM>();
            }
            else
            {
                if (Architecture.IsSIMDSupported)
                {
                    bminit_epu8(divisor, out v128 mul16, _promises, 3);

                    _bigM = ((ushort3)mul16).Reinterpret<ushort3, BigM>();
                }
                else
                {
                    ushort3 mul;
                    bminit_u8(divisor.x, out mul.x);
                    bminit_u8(divisor.y, out mul.y);
                    bminit_u8(divisor.z, out mul.z);

                    _bigM = mul.Reinterpret<ushort3, BigM>();
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(byte4 divisor, Promise promises = Promise.Nothing)
            : this(divisor.Reinterpret<byte4, T>(), promises, Signedness.Unsigned, sizeof(byte))
        {
#if DEBUG
_typeInfo = new TypeInfo(sizeof(byte), 4, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            if (_promises.SameValue)
            {
                bminit_u8(divisor.x, out ushort mul);

                _bigM = ((ushort4)mul).Reinterpret<ushort4, BigM>();
            }
            else
            {
                if (Architecture.IsSIMDSupported)
                {
                    bminit_epu8(divisor, out v128 mul16, _promises, 4);

                    _bigM = ((ushort4)mul16).Reinterpret<ushort4, BigM>();
                }
                else
                {
                    ushort4 mul;
                    bminit_u8(divisor.x, out mul.x);
                    bminit_u8(divisor.y, out mul.y);
                    bminit_u8(divisor.z, out mul.z);
                    bminit_u8(divisor.w, out mul.w);

                    _bigM = mul.Reinterpret<ushort4, BigM>();
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(byte8 divisor, Promise promises = Promise.Nothing)
            : this(divisor.Reinterpret<byte8, T>(), promises, Signedness.Unsigned, sizeof(byte))
        {
#if DEBUG
_typeInfo = new TypeInfo(sizeof(byte), 8, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            if (_promises.SameValue)
            {
                bminit_u8(divisor.x0, out ushort mul);

                _bigM = ((ushort8)mul).Reinterpret<ushort8, BigM>();
            }
            else
            {
                if (Architecture.IsSIMDSupported)
                {
                    bminit_epu8(divisor, out v128 mul16, _promises, 8);

                    _bigM = ((ushort8)mul16).Reinterpret<ushort8, BigM>();
                }
                else
                {
                    ushort8 mul;
                    bminit_u8(divisor.x0, out mul.x0);
                    bminit_u8(divisor.x1, out mul.x1);
                    bminit_u8(divisor.x2, out mul.x2);
                    bminit_u8(divisor.x3, out mul.x3);
                    bminit_u8(divisor.x4, out mul.x4);
                    bminit_u8(divisor.x5, out mul.x5);
                    bminit_u8(divisor.x6, out mul.x6);
                    bminit_u8(divisor.x7, out mul.x7);

                    _bigM = mul.Reinterpret<ushort8, BigM>();
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(byte16 divisor, Promise promises = Promise.Nothing)
            : this(divisor.Reinterpret<byte16, T>(), promises, Signedness.Unsigned, sizeof(byte))
        {
#if DEBUG
_typeInfo = new TypeInfo(sizeof(byte), 16, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            if (_promises.SameValue)
            {
                bminit_u8(divisor.x0, out ushort mul);

                _bigM = ((ushort16)mul).Reinterpret<ushort16, BigM>();
            }
            else
            {
                if (Architecture.IsSIMDSupported)
                {
                    bminit_epu8(divisor, out v128 mulLo, out v128 mulHi, _promises);

                    _bigM = new ushort16((ushort8)mulLo, (ushort8)mulHi).Reinterpret<ushort16, BigM>();
                }
                else
                {
                    ushort16 mul = Uninitialized<ushort16>.Create();
                    bminit_u8(divisor.x0,  out mul.x0);
                    bminit_u8(divisor.x1,  out mul.x1);
                    bminit_u8(divisor.x2,  out mul.x2);
                    bminit_u8(divisor.x3,  out mul.x3);
                    bminit_u8(divisor.x4,  out mul.x4);
                    bminit_u8(divisor.x5,  out mul.x5);
                    bminit_u8(divisor.x6,  out mul.x6);
                    bminit_u8(divisor.x7,  out mul.x7);
                    bminit_u8(divisor.x8,  out mul.x8);
                    bminit_u8(divisor.x9,  out mul.x9);
                    bminit_u8(divisor.x10, out mul.x10);
                    bminit_u8(divisor.x11, out mul.x11);
                    bminit_u8(divisor.x12, out mul.x12);
                    bminit_u8(divisor.x13, out mul.x13);
                    bminit_u8(divisor.x14, out mul.x14);
                    bminit_u8(divisor.x15, out mul.x15);

                    _bigM = mul.Reinterpret<ushort16, BigM>();
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(byte32 divisor, Promise promises = Promise.Nothing)
            : this(divisor.Reinterpret<byte32, T>(), promises, Signedness.Unsigned, sizeof(byte))
        {
#if DEBUG
_typeInfo = new TypeInfo(sizeof(byte), 32, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            if (_promises.SameValue)
            {
                bminit_u8(divisor.x0, out ushort mul);

                _bigM._mulLo = ((ushort16)mul).Reinterpret<ushort16, T>();
                _bigM._mulHi = ((ushort16)mul).Reinterpret<ushort16, T>();
            }
            else
            {
                if (Avx2.IsAvx2Supported)
                {
                    mm256_bminit_epu8(divisor, out v256 mulLo, out v256 mulHi, _promises);

                    _bigM._mulLo = ((ushort16)mulLo).Reinterpret<ushort16, T>();
                    _bigM._mulHi = ((ushort16)mulHi).Reinterpret<ushort16, T>();
                }
                else if (Architecture.IsSIMDSupported)
                {
                    bminit_epu8(divisor.v16_0,  out v128 mulLo_0, out v128 mulLo_1, _promises);
                    bminit_epu8(divisor.v16_16, out v128 mulHi_0, out v128 mulHi_1, _promises);

                    _bigM._mulLo = new ushort16((ushort8)mulLo_0, (ushort8)mulLo_1).Reinterpret<ushort16, T>();
                    _bigM._mulHi = new ushort16((ushort8)mulHi_0, (ushort8)mulHi_1).Reinterpret<ushort16, T>();
                }
                else
                {
                    ushort16 mul0 = Uninitialized<ushort16>.Create();
                    ushort16 mul1 = Uninitialized<ushort16>.Create();
                    bminit_u8(divisor.x0,  out mul0.x0);
                    bminit_u8(divisor.x1,  out mul0.x1);
                    bminit_u8(divisor.x2,  out mul0.x2);
                    bminit_u8(divisor.x3,  out mul0.x3);
                    bminit_u8(divisor.x4,  out mul0.x4);
                    bminit_u8(divisor.x5,  out mul0.x5);
                    bminit_u8(divisor.x6,  out mul0.x6);
                    bminit_u8(divisor.x7,  out mul0.x7);
                    bminit_u8(divisor.x8,  out mul0.x8);
                    bminit_u8(divisor.x9,  out mul0.x9);
                    bminit_u8(divisor.x10, out mul0.x10);
                    bminit_u8(divisor.x11, out mul0.x11);
                    bminit_u8(divisor.x12, out mul0.x12);
                    bminit_u8(divisor.x13, out mul0.x13);
                    bminit_u8(divisor.x14, out mul0.x14);
                    bminit_u8(divisor.x15, out mul0.x15);
                    bminit_u8(divisor.x16, out mul1.x0);
                    bminit_u8(divisor.x17, out mul1.x1);
                    bminit_u8(divisor.x18, out mul1.x2);
                    bminit_u8(divisor.x19, out mul1.x3);
                    bminit_u8(divisor.x20, out mul1.x4);
                    bminit_u8(divisor.x21, out mul1.x5);
                    bminit_u8(divisor.x22, out mul1.x6);
                    bminit_u8(divisor.x23, out mul1.x7);
                    bminit_u8(divisor.x24, out mul1.x8);
                    bminit_u8(divisor.x25, out mul1.x9);
                    bminit_u8(divisor.x26, out mul1.x10);
                    bminit_u8(divisor.x27, out mul1.x11);
                    bminit_u8(divisor.x28, out mul1.x12);
                    bminit_u8(divisor.x29, out mul1.x13);
                    bminit_u8(divisor.x30, out mul1.x14);
                    bminit_u8(divisor.x31, out mul1.x15);

                    _bigM._mulLo = mul0.Reinterpret<ushort16, T>();
                    _bigM._mulHi = mul1.Reinterpret<ushort16, T>();
                }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(ushort divisor, Promise promises = Promise.Nothing)
            : this(divisor.Reinterpret<ushort, T>(), promises, Signedness.Unsigned, sizeof(ushort))
        {
#if DEBUG
_typeInfo = new TypeInfo(sizeof(ushort), 1, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            bminit_u16(divisor, out uint mul32);
            msinit_u16(divisor, out ushort mul, out ushort shift, _promises);

            _mulShift._mul = mul.Reinterpret<ushort, T>();
            _mulShift._shift = shift.Reinterpret<ushort, T>();
            _bigM = mul32.Reinterpret<uint, BigM>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(ushort2 divisor, Promise promises = Promise.Nothing)
            : this(divisor.Reinterpret<ushort2, T>(), promises, Signedness.Unsigned, sizeof(ushort))
        {
#if DEBUG
_typeInfo = new TypeInfo(sizeof(ushort), 2, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            if (_promises.SameValue)
            {
                bminit_u16(divisor.x, out uint mul32);
                msinit_u16(divisor.x, out ushort mul, out ushort shift, _promises);

                _mulShift._mul = ((ushort2)mul).Reinterpret<ushort2, T>();
                _mulShift._shift = ((ushort2)shift).Reinterpret<ushort2, T>();
                _bigM = ((uint2)mul32).Reinterpret<uint2, BigM>();
            }
            else
            {
                if (Architecture.IsSIMDSupported)
                {
                    bminit_epu16(divisor, out v128 mul32, 2);
                    msinit_epu16(divisor, out v128 mul, out v128 shift, _promises, 2);

                    _mulShift._mul = ((ushort2)mul).Reinterpret<ushort2, T>();
                    _mulShift._shift = ((ushort2)shift).Reinterpret<ushort2, T>();
                    _bigM = RegisterConversion.ToUInt2(mul32).Reinterpret<uint2, BigM>();
                }
                else
                {
                    uint2 mul32;
                    ushort2 mul;
                    ushort2 shift;
                    bminit_u16(divisor.x, out mul32.x);
                    bminit_u16(divisor.y, out mul32.y);
                    msinit_u16(divisor.x, out mul.x, out shift.x, _promises);
                    msinit_u16(divisor.y, out mul.y, out shift.y, _promises);

                    _mulShift._mul = mul.Reinterpret<ushort2, T>();
                    _mulShift._shift = shift.Reinterpret<ushort2, T>();
                    _bigM = mul32.Reinterpret<uint2, BigM>();
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(ushort3 divisor, Promise promises = Promise.Nothing)
            : this(divisor.Reinterpret<ushort3, T>(), promises, Signedness.Unsigned, sizeof(ushort))
        {
#if DEBUG
_typeInfo = new TypeInfo(sizeof(ushort), 3, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            if (_promises.SameValue)
            {
                bminit_u16(divisor.x, out uint mul32);
                msinit_u16(divisor.x, out ushort mul, out ushort shift, _promises);

                _mulShift._mul = ((ushort3)mul).Reinterpret<ushort3, T>();
                _mulShift._shift = ((ushort3)shift).Reinterpret<ushort3, T>();
                _bigM = ((uint3)mul32).Reinterpret<uint3, BigM>();
            }
            else
            {
                if (Architecture.IsSIMDSupported)
                {
                    bminit_epu16(divisor, out v128 mul128, 3);
                    msinit_epu16(divisor, out v128 mul, out v128 shift, _promises, 3);

                    _mulShift._mul = ((ushort3)mul).Reinterpret<ushort3, T>();
                    _mulShift._shift = ((ushort3)shift).Reinterpret<ushort3, T>();
                    _bigM = RegisterConversion.ToUInt3(mul128).Reinterpret<uint3, BigM>();
                }
                else
                {
                    uint3 mul32;
                    ushort3 mul;
                    ushort3 shift;
                    bminit_u16(divisor.x, out mul32.x);
                    bminit_u16(divisor.y, out mul32.y);
                    bminit_u16(divisor.z, out mul32.z);
                    msinit_u16(divisor.x, out mul.x, out shift.x, _promises);
                    msinit_u16(divisor.y, out mul.y, out shift.y, _promises);
                    msinit_u16(divisor.z, out mul.z, out shift.z, _promises);

                    _mulShift._mul = mul.Reinterpret<ushort3, T>();
                    _mulShift._shift = shift.Reinterpret<ushort3, T>();
                    _bigM = mul32.Reinterpret<uint3, BigM>();
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(ushort4 divisor, Promise promises = Promise.Nothing)
            : this(divisor.Reinterpret<ushort4, T>(), promises, Signedness.Unsigned, sizeof(ushort))
        {
#if DEBUG
_typeInfo = new TypeInfo(sizeof(ushort), 4, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            if (_promises.SameValue)
            {
                bminit_u16(divisor.x, out uint mul32);
                msinit_u16(divisor.x, out ushort mul, out ushort shift, _promises);

                _mulShift._mul = ((ushort4)mul).Reinterpret<ushort4, T>();
                _mulShift._shift = ((ushort4)shift).Reinterpret<ushort4, T>();
                _bigM = ((uint4)mul32).Reinterpret<uint4, BigM>();
            }
            else
            {
                if (Architecture.IsSIMDSupported)
                {
                    bminit_epu16(divisor, out v128 mul32, 4);
                    msinit_epu16(divisor, out v128 mul, out v128 shift, _promises, 4);

                    _mulShift._mul = ((ushort4)mul).Reinterpret<ushort4, T>();
                    _mulShift._shift = ((ushort4)shift).Reinterpret<ushort4, T>();
                    _bigM = RegisterConversion.ToUInt4(mul32).Reinterpret<uint4, BigM>();
                }
                else
                {
                    uint4 mul32;
                    ushort4 mul;
                    ushort4 shift;
                    bminit_u16(divisor.x, out mul32.x);
                    bminit_u16(divisor.y, out mul32.y);
                    bminit_u16(divisor.z, out mul32.z);
                    bminit_u16(divisor.w, out mul32.w);
                    msinit_u16(divisor.x, out mul.x, out shift.x, _promises);
                    msinit_u16(divisor.y, out mul.y, out shift.y, _promises);
                    msinit_u16(divisor.z, out mul.z, out shift.z, _promises);
                    msinit_u16(divisor.w, out mul.w, out shift.w, _promises);

                    _mulShift._mul = mul.Reinterpret<ushort4, T>();
                    _mulShift._shift = shift.Reinterpret<ushort4, T>();
                    _bigM = mul32.Reinterpret<uint4, BigM>();
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(ushort8 divisor, Promise promises = Promise.Nothing)
            : this(divisor.Reinterpret<ushort8, T>(), promises, Signedness.Unsigned, sizeof(ushort))
        {
#if DEBUG
_typeInfo = new TypeInfo(sizeof(ushort), 8, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            if (_promises.SameValue)
            {
                bminit_u16(divisor.x0, out uint mul32);
                msinit_u16(divisor.x0, out ushort mul, out ushort shift, _promises);

                _mulShift._mul = ((ushort8)mul).Reinterpret<ushort8, T>();
                _mulShift._shift = ((ushort8)shift).Reinterpret<ushort8, T>();
                _bigM = ((uint8)mul32).Reinterpret<uint8, BigM>();
            }
            else
            {
                if (Architecture.IsSIMDSupported)
                {
                    bminit_epu16(divisor, out v128 mulLo, out v128 mulHi);
                    msinit_epu16(divisor, out v128 mul, out v128 shift, _promises, 8);

                    _mulShift._mul = ((ushort8)mul).Reinterpret<ushort8, T>();
                    _mulShift._shift = ((ushort8)shift).Reinterpret<ushort8, T>();
                    _bigM = new uint8(RegisterConversion.ToUInt4(mulLo), RegisterConversion.ToUInt4(mulHi)).Reinterpret<uint8, BigM>();
                }
                else
                {
                    uint8 mul32 = Uninitialized<uint8>.Create();
                    ushort8 mul;
                    ushort8 shift;
                    bminit_u16(divisor.x0, out mul32.x0);
                    bminit_u16(divisor.x1, out mul32.x1);
                    bminit_u16(divisor.x2, out mul32.x2);
                    bminit_u16(divisor.x3, out mul32.x3);
                    bminit_u16(divisor.x4, out mul32.x4);
                    bminit_u16(divisor.x5, out mul32.x5);
                    bminit_u16(divisor.x6, out mul32.x6);
                    bminit_u16(divisor.x7, out mul32.x7);
                    msinit_u16(divisor.x0, out mul.x0, out shift.x0, _promises);
                    msinit_u16(divisor.x1, out mul.x1, out shift.x1, _promises);
                    msinit_u16(divisor.x2, out mul.x2, out shift.x2, _promises);
                    msinit_u16(divisor.x3, out mul.x3, out shift.x3, _promises);
                    msinit_u16(divisor.x4, out mul.x4, out shift.x4, _promises);
                    msinit_u16(divisor.x5, out mul.x5, out shift.x5, _promises);
                    msinit_u16(divisor.x6, out mul.x6, out shift.x6, _promises);
                    msinit_u16(divisor.x7, out mul.x7, out shift.x7, _promises);

                    _mulShift._mul = mul.Reinterpret<ushort8, T>();
                    _mulShift._shift = shift.Reinterpret<ushort8, T>();
                    _bigM = mul32.Reinterpret<uint8, BigM>();
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(ushort16 divisor, Promise promises = Promise.Nothing)
            : this(divisor.Reinterpret<ushort16, T>(), promises, Signedness.Unsigned, sizeof(ushort))
        {
#if DEBUG
_typeInfo = new TypeInfo(sizeof(ushort), 16, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            if (_promises.SameValue)
            {
                bminit_u16(divisor.x0, out uint mul32);
                msinit_u16(divisor.x0, out ushort mul, out ushort shift, _promises);

                _mulShift._mul = ((ushort16)mul).Reinterpret<ushort16, T>();
                _mulShift._shift = ((ushort16)shift).Reinterpret<ushort16, T>();
                _bigM._mulLo = ((uint8)mul32).Reinterpret<uint8, T>();
                _bigM._mulHi = ((uint8)mul32).Reinterpret<uint8, T>();
            }
            else
            {
                if (Avx2.IsAvx2Supported)
                {
                    mm256_bminit_epu16(divisor, out v256 mulLo, out v256 mulHi);
                    mm256_msinit_epu16(divisor, out v256 mul, out v256 shift, _promises);

                    _mulShift._mul = ((ushort16)mul).Reinterpret<ushort16, T>();
                    _mulShift._shift = ((ushort16)shift).Reinterpret<ushort16, T>();
                    _bigM._mulLo = ((uint8)mulLo).Reinterpret<uint8, T>();
                    _bigM._mulHi = ((uint8)mulHi).Reinterpret<uint8, T>();
                }
                else if (Architecture.IsSIMDSupported)
                {
                    bminit_epu16(divisor.v8_0, out v128 mulLo_0, out v128 mulLo_1);
                    bminit_epu16(divisor.v8_8, out v128 mulHi_0, out v128 mulHi_1);
                    msinit_epu16(divisor.v8_0, out v128 mulLo, out v128 shiftLo, _promises, 8);
                    msinit_epu16(divisor.v8_8, out v128 mulHi, out v128 shiftHi, _promises, 8);

                    _mulShift._mul = new ushort16(mulLo, mulHi).Reinterpret<ushort16, T>();
                    _mulShift._shift = new ushort16(shiftLo, shiftHi).Reinterpret<ushort16, T>();
                    _bigM._mulLo = new uint8(RegisterConversion.ToUInt4(mulLo_0), RegisterConversion.ToUInt4(mulLo_1)).Reinterpret<uint8, T>();
                    _bigM._mulHi = new uint8(RegisterConversion.ToUInt4(mulHi_0), RegisterConversion.ToUInt4(mulHi_1)).Reinterpret<uint8, T>();
                }
                else
                {
                    uint8 mul32Lo = Uninitialized<uint8>.Create();
                    uint8 mul32Hi = Uninitialized<uint8>.Create();
                    ushort16 mul = Uninitialized<ushort16>.Create();
                    ushort16 shift = Uninitialized<ushort16>.Create();
                    bminit_u16(divisor.x0,  out mul32Lo.x0);
                    bminit_u16(divisor.x1,  out mul32Lo.x1);
                    bminit_u16(divisor.x2,  out mul32Lo.x2);
                    bminit_u16(divisor.x3,  out mul32Lo.x3);
                    bminit_u16(divisor.x4,  out mul32Lo.x4);
                    bminit_u16(divisor.x5,  out mul32Lo.x5);
                    bminit_u16(divisor.x6,  out mul32Lo.x6);
                    bminit_u16(divisor.x7,  out mul32Lo.x7);
                    bminit_u16(divisor.x8,  out mul32Hi.x0);
                    bminit_u16(divisor.x9,  out mul32Hi.x1);
                    bminit_u16(divisor.x10, out mul32Hi.x2);
                    bminit_u16(divisor.x11, out mul32Hi.x3);
                    bminit_u16(divisor.x12, out mul32Hi.x4);
                    bminit_u16(divisor.x13, out mul32Hi.x5);
                    bminit_u16(divisor.x14, out mul32Hi.x6);
                    bminit_u16(divisor.x15, out mul32Hi.x7);
                    msinit_u16(divisor.x0,  out mul.x0,  out shift.x0,  _promises);
                    msinit_u16(divisor.x1,  out mul.x1,  out shift.x1,  _promises);
                    msinit_u16(divisor.x2,  out mul.x2,  out shift.x2,  _promises);
                    msinit_u16(divisor.x3,  out mul.x3,  out shift.x3,  _promises);
                    msinit_u16(divisor.x4,  out mul.x4,  out shift.x4,  _promises);
                    msinit_u16(divisor.x5,  out mul.x5,  out shift.x5,  _promises);
                    msinit_u16(divisor.x6,  out mul.x6,  out shift.x6,  _promises);
                    msinit_u16(divisor.x7,  out mul.x7,  out shift.x7,  _promises);
                    msinit_u16(divisor.x8,  out mul.x8,  out shift.x8,  _promises);
                    msinit_u16(divisor.x9,  out mul.x9,  out shift.x9,  _promises);
                    msinit_u16(divisor.x10, out mul.x10, out shift.x10, _promises);
                    msinit_u16(divisor.x11, out mul.x11, out shift.x11, _promises);
                    msinit_u16(divisor.x12, out mul.x12, out shift.x12, _promises);
                    msinit_u16(divisor.x13, out mul.x13, out shift.x13, _promises);
                    msinit_u16(divisor.x14, out mul.x14, out shift.x14, _promises);
                    msinit_u16(divisor.x15, out mul.x15, out shift.x15, _promises);

                    _mulShift._mul = mul.Reinterpret<ushort16, T>();
                    _mulShift._shift = shift.Reinterpret<ushort16, T>();
                    _bigM._mulLo = mul32Lo.Reinterpret<uint8, T>();
                    _bigM._mulHi = mul32Hi.Reinterpret<uint8, T>();
                }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(uint divisor, Promise promises = Promise.Nothing)
            : this(divisor.Reinterpret<uint, T>(), promises, Signedness.Unsigned, sizeof(uint))
        {
#if DEBUG
_typeInfo = new TypeInfo(sizeof(uint), 1, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            msinit_u32(divisor, out uint mul, out uint shift, _promises);
            bminit_u32(divisor, out ulong mul64);

            _mulShift._mul = mul.Reinterpret<uint, T>();
            _mulShift._shift = shift.Reinterpret<uint, T>();
            _bigM = mul64.Reinterpret<ulong, BigM>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(uint2 divisor, Promise promises = Promise.Nothing)
            : this(divisor.Reinterpret<uint2, T>(), promises, Signedness.Unsigned, sizeof(uint))
        {
#if DEBUG
_typeInfo = new TypeInfo(sizeof(uint), 2, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            if (_promises.SameValue)
            {
                msinit_u32(divisor.x, out uint mul, out uint shift, _promises);
                bminit_u32(divisor.x, out ulong mul64);

                _mulShift._mul = ((uint2)mul).Reinterpret<uint2, T>();
                _mulShift._shift = ((uint2)shift).Reinterpret<uint2, T>();
                _bigM = ((ulong2)mul64).Reinterpret<ulong2, BigM>();
            }
            else
            {
                if (Architecture.IsSIMDSupported)
                {
                    msinit_epu32(RegisterConversion.ToV128(divisor), out v128 mul, out v128 shift, _promises, 2);
                    bminit_epu32(divisor, out ulong2 mul64);

                    _mulShift._mul = RegisterConversion.ToUInt2(mul).Reinterpret<uint2, T>();
                    _mulShift._shift = RegisterConversion.ToUInt2(shift).Reinterpret<uint2, T>();
                    _bigM = mul64.Reinterpret<ulong2, BigM>();
                }
                else
                {
                    uint2 mul;
                    uint2 shift;
                    ulong2 mul64;
                    msinit_u32(divisor.x, out mul.x, out shift.x, _promises);
                    msinit_u32(divisor.y, out mul.y, out shift.y, _promises);
                    bminit_u32(divisor.x, out mul64.x);
                    bminit_u32(divisor.y, out mul64.y);

                    _mulShift._mul = mul.Reinterpret<uint2, T>();
                    _mulShift._shift = shift.Reinterpret<uint2, T>();
                    _bigM = mul64.Reinterpret<ulong2, BigM>();
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(uint3 divisor, Promise promises = Promise.Nothing)
            : this(divisor.Reinterpret<uint3, T>(), promises, Signedness.Unsigned, sizeof(uint))
        {
#if DEBUG
_typeInfo = new TypeInfo(sizeof(uint), 3, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            if (_promises.SameValue)
            {
                msinit_u32(divisor.x, out uint mul, out uint shift, _promises);
                bminit_u32(divisor.x, out ulong mul64);

                _mulShift._mul = ((uint3)mul).Reinterpret<uint3, T>();
                _mulShift._shift = ((uint3)shift).Reinterpret<uint3, T>();
                _bigM = ((ulong3)mul64).Reinterpret<ulong3, BigM>();
            }
            else
            {
                if (Architecture.IsSIMDSupported)
                {
                    msinit_epu32(RegisterConversion.ToV128(divisor), out v128 mul, out v128 shift, _promises, 3);
                    bminit_epu32(divisor, out ulong3 mul64);

                    _mulShift._mul = RegisterConversion.ToUInt3(mul).Reinterpret<uint3, T>();
                    _mulShift._shift = RegisterConversion.ToUInt3(shift).Reinterpret<uint3, T>();
                    _bigM = mul64.Reinterpret<ulong3, BigM>();
                }
                else
                {
                    uint3 mul;
                    uint3 shift;
                    ulong3 mul64 = Uninitialized<ulong3>.Create();
                    msinit_u32(divisor.x, out mul.x, out shift.x, _promises);
                    msinit_u32(divisor.y, out mul.y, out shift.y, _promises);
                    msinit_u32(divisor.z, out mul.z, out shift.z, _promises);
                    bminit_u32(divisor.x, out mul64.x);
                    bminit_u32(divisor.y, out mul64.y);
                    bminit_u32(divisor.z, out mul64.z);

                    _mulShift._mul = mul.Reinterpret<uint3, T>();
                    _mulShift._shift = shift.Reinterpret<uint3, T>();
                    _bigM = mul64.Reinterpret<ulong3, BigM>();
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(uint4 divisor, Promise promises = Promise.Nothing)
            : this(divisor.Reinterpret<uint4, T>(), promises, Signedness.Unsigned, sizeof(uint))
        {
#if DEBUG
_typeInfo = new TypeInfo(sizeof(uint), 4, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            if (_promises.SameValue)
            {
                msinit_u32(divisor.x, out uint mul, out uint shift, _promises);
                bminit_u32(divisor.x, out ulong mul64);

                _mulShift._mul = ((uint4)mul).Reinterpret<uint4, T>();
                _mulShift._shift = ((uint4)shift).Reinterpret<uint4, T>();
                _bigM = ((ulong4)mul64).Reinterpret<ulong4, BigM>();
            }
            else
            {
                if (Architecture.IsSIMDSupported)
                {
                    msinit_epu32(RegisterConversion.ToV128(divisor), out v128 mul, out v128 shift, _promises, 4);
                    bminit_epu32(divisor, out ulong4 mul64);

                    _mulShift._mul = RegisterConversion.ToUInt4(mul).Reinterpret<uint4, T>();
                    _mulShift._shift = RegisterConversion.ToUInt4(shift).Reinterpret<uint4, T>();
                    _bigM = mul64.Reinterpret<ulong4, BigM>();
                }
                else
                {
                    uint4 mul;
                    uint4 shift;
                    ulong4 mul64 = Uninitialized<ulong4>.Create();
                    msinit_u32(divisor.x, out mul.x, out shift.x, _promises);
                    msinit_u32(divisor.y, out mul.y, out shift.y, _promises);
                    msinit_u32(divisor.z, out mul.z, out shift.z, _promises);
                    msinit_u32(divisor.w, out mul.w, out shift.w, _promises);
                    bminit_u32(divisor.x, out mul64.x);
                    bminit_u32(divisor.y, out mul64.y);
                    bminit_u32(divisor.z, out mul64.z);
                    bminit_u32(divisor.w, out mul64.w);

                    _mulShift._mul = mul.Reinterpret<uint4, T>();
                    _mulShift._shift = shift.Reinterpret<uint4, T>();
                    _bigM = mul64.Reinterpret<ulong4, BigM>();
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(uint8 divisor, Promise promises = Promise.Nothing)
            : this(divisor.Reinterpret<uint8, T>(), promises, Signedness.Unsigned, sizeof(uint))
        {
#if DEBUG
_typeInfo = new TypeInfo(sizeof(uint), 8, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            if (_promises.SameValue)
            {
                msinit_u32(divisor.x0, out uint mul, out uint shift, _promises);
                bminit_u32(divisor.x0, out ulong mul64);

                _mulShift._mul = ((uint8)mul).Reinterpret<uint8, T>();
                _mulShift._shift = ((uint8)shift).Reinterpret<uint8, T>();
                _bigM._mulLo = ((ulong4)mul64).Reinterpret<ulong4, T>();
                _bigM._mulHi = ((ulong4)mul64).Reinterpret<ulong4, T>();
            }
            else
            {
                if (Avx2.IsAvx2Supported)
                {
                    mm256_msinit_epu32(divisor, out v256 mul, out v256 shift, _promises);
                    mm256_bminit_epu32(divisor, out v256 mul64Lo, out v256 mul64Hi);

                    _mulShift._mul = ((uint8)mul).Reinterpret<uint8, T>();
                    _mulShift._shift = ((uint8)shift).Reinterpret<uint8, T>();
                    _bigM._mulLo = ((ulong4)mul64Lo).Reinterpret<ulong4, T>();
                    _bigM._mulHi = ((ulong4)mul64Hi).Reinterpret<ulong4, T>();
                }
                else if (Architecture.IsSIMDSupported)
                {
                    msinit_epu32(RegisterConversion.ToV128(divisor.v4_0), out v128 mul0, out v128 shift_0, _promises, 4);
                    msinit_epu32(RegisterConversion.ToV128(divisor.v4_4), out v128 mul1, out v128 shift_1, _promises, 4);
                    bminit_epu32(divisor.v4_0, out ulong4 mul64Lo);
                    bminit_epu32(divisor.v4_4, out ulong4 mul64Hi);

                    _mulShift._mul = new uint8(RegisterConversion.ToUInt4(mul0), RegisterConversion.ToUInt4(mul1)).Reinterpret<uint8, T>();
                    _mulShift._shift = new uint8(RegisterConversion.ToUInt4(shift_0), RegisterConversion.ToUInt4(shift_1)).Reinterpret<uint8, T>();
                    _bigM._mulLo = mul64Lo.Reinterpret<ulong4, T>();
                    _bigM._mulHi = mul64Hi.Reinterpret<ulong4, T>();
                }
                else
                {
                    uint8 mul = Uninitialized<uint8>.Create();
                    uint8 shift = Uninitialized<uint8>.Create();
                    ulong4 mul64_0 = Uninitialized<ulong4>.Create();
                    ulong4 mul64_1 = Uninitialized<ulong4>.Create();
                    msinit_u32(divisor.x0, out mul.x0, out shift.x0, _promises);
                    msinit_u32(divisor.x1, out mul.x1, out shift.x1, _promises);
                    msinit_u32(divisor.x2, out mul.x2, out shift.x2, _promises);
                    msinit_u32(divisor.x3, out mul.x3, out shift.x3, _promises);
                    msinit_u32(divisor.x4, out mul.x4, out shift.x4, _promises);
                    msinit_u32(divisor.x5, out mul.x5, out shift.x5, _promises);
                    msinit_u32(divisor.x6, out mul.x6, out shift.x6, _promises);
                    msinit_u32(divisor.x7, out mul.x7, out shift.x7, _promises);
                    bminit_u32(divisor.x0, out mul64_0.x);
                    bminit_u32(divisor.x1, out mul64_0.y);
                    bminit_u32(divisor.x2, out mul64_0.z);
                    bminit_u32(divisor.x3, out mul64_0.w);
                    bminit_u32(divisor.x4, out mul64_1.x);
                    bminit_u32(divisor.x5, out mul64_1.y);
                    bminit_u32(divisor.x6, out mul64_1.z);
                    bminit_u32(divisor.x7, out mul64_1.w);

                    _mulShift._mul = mul.Reinterpret<uint8, T>();
                    _mulShift._shift = shift.Reinterpret<uint8, T>();
                    _bigM._mulLo = mul64_0.Reinterpret<ulong4, T>();
                    _bigM._mulHi = mul64_1.Reinterpret<ulong4, T>();
                }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(ulong divisor, Promise promises = Promise.Nothing)
            : this(divisor.Reinterpret<ulong, T>(), promises, Signedness.Unsigned, sizeof(ulong))
        {
#if DEBUG
_typeInfo = new TypeInfo(sizeof(ulong), 1, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            msbminit_u64(divisor, out ulong mul, out ulong shift, out UInt128 mul128, _promises);

            _mulShift._mul = mul.Reinterpret<ulong, T>();
            _mulShift._shift = shift.Reinterpret<ulong, T>();
            _bigM = mul128.Reinterpret<UInt128, BigM>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(ulong2 divisor, Promise promises = Promise.Nothing)
            : this(divisor.Reinterpret<ulong2, T>(), promises, Signedness.Unsigned, sizeof(ulong))
        {
#if DEBUG
_typeInfo = new TypeInfo(sizeof(ulong), 2, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            if (_promises.SameValue)
            {
                msbminit_u64(divisor.x, out ulong mul, out ulong shift, out UInt128 mul128, _promises);

                _mulShift._mul = ((ulong2)mul).Reinterpret<ulong2, T>();
                _mulShift._shift = ((ulong2)shift).Reinterpret<ulong2, T>();
                _bigM._mulLo = mul128.Reinterpret<UInt128, T>();
                _bigM._mulHi = mul128.Reinterpret<UInt128, T>();
            }
            else
            {
                UInt128 mul128Lo;
                UInt128 mul128Hi;

                if (Architecture.IsSIMDSupported)
                {
                    msbminit_epu64(divisor, out v128 mul, out v128 shift, out mul128Lo, out mul128Hi, _promises);

                    _mulShift._mul = ((ulong2)mul).Reinterpret<ulong2, T>();
                    _mulShift._shift = ((ulong2)shift).Reinterpret<ulong2, T>();
                }
                else
                {
                    ulong2 shift;
                    ulong2 mul;

                    msbminit_u64(divisor.x, out mul.x, out shift.x, out mul128Lo,
                                   divisor.y, out mul.y, out shift.y, out mul128Hi,
                                   _promises);

                    _mulShift._mul = mul.Reinterpret<ulong2, T>();
                    _mulShift._shift = shift.Reinterpret<ulong2, T>();
                }

                _bigM._mulLo = mul128Lo.Reinterpret<UInt128, T>();
                _bigM._mulHi = mul128Hi.Reinterpret<UInt128, T>();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(ulong3 divisor, Promise promises = Promise.Nothing)
            : this(divisor.Reinterpret<ulong3, T>(), promises, Signedness.Unsigned, sizeof(ulong))
        {
#if DEBUG
_typeInfo = new TypeInfo(sizeof(ulong), 3, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            if (_promises.SameValue)
            {
                msbminit_u64(divisor.x, out ulong mul, out ulong shift, out UInt128 mul128, _promises);

                _mulShift._mul = ((ulong3)mul).Reinterpret<ulong3, T>();
                _mulShift._shift = ((ulong3)shift).Reinterpret<ulong3, T>();
                _bigM.SetField(mul128, 0);
                _bigM.SetField(mul128, 1);
                _bigM.SetField(mul128, 2);
            }
            else
            {
                UInt128 mul128_0;
                UInt128 mul128_1;
                UInt128 mul128_2;

                if (Avx2.IsAvx2Supported)
                {
                    mm256_msbminit_epu64(divisor, out v256 mul, out v256 shift, out mul128_0, out mul128_1, out mul128_2, out _, _promises, 3);

                    _mulShift._mul = ((ulong3)mul).Reinterpret<ulong3, T>();
                    _mulShift._shift = ((ulong3)shift).Reinterpret<ulong3, T>();
                }
                else if (Architecture.IsSIMDSupported)
                {
                    msbminit_epu64(divisor.xy, out v128 mul, out v128 shift, out mul128_0, out mul128_1, _promises);
                    msbminit_u64(divisor.z, out ulong mulZ, out ulong shiftZ, out mul128_2, _promises);

                    _mulShift._mul = new ulong3(mul, mulZ).Reinterpret<ulong3, T>();
                    _mulShift._shift = new ulong3(shift, shiftZ).Reinterpret<ulong3, T>();
                }
                else
                {
                    ulong3 shift = Uninitialized<ulong3>.Create();
                    ulong3 mul = Uninitialized<ulong3>.Create();

                    msbminit_u64(divisor.x, out mul.x, out shift.x, out mul128_0,
                                   divisor.y, out mul.y, out shift.y, out mul128_1,
                                   divisor.z, out mul.z, out shift.z, out mul128_2,
                                   _promises);

                    _mulShift._mul = mul.Reinterpret<ulong3, T>();
                    _mulShift._shift = shift.Reinterpret<ulong3, T>();
                }

                _bigM.SetField(mul128_0, 0);
                _bigM.SetField(mul128_1, 1);
                _bigM.SetField(mul128_2, 2);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(ulong4 divisor, Promise promises = Promise.Nothing)
            : this(divisor.Reinterpret<ulong4, T>(), promises, Signedness.Unsigned, sizeof(ulong))
        {
#if DEBUG
_typeInfo = new TypeInfo(sizeof(ulong), 4, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            if (_promises.SameValue)
            {
                msbminit_u64(divisor.x, out ulong mul, out ulong shift, out UInt128 mul128, _promises);

                _mulShift._mul = ((ulong4)mul).Reinterpret<ulong4, T>();
                _mulShift._shift = ((ulong4)shift).Reinterpret<ulong4, T>();
                _bigM.SetField(mul128, 0);
                _bigM.SetField(mul128, 1);
                _bigM.SetField(mul128, 2);
                _bigM.SetField(mul128, 3);
            }
            else
            {
                UInt128 mul128_0;
                UInt128 mul128_1;
                UInt128 mul128_2;
                UInt128 mul128_3;

                if (Avx2.IsAvx2Supported)
                {
                    mm256_msbminit_epu64(divisor, out v256 mul, out v256 shift, out mul128_0, out mul128_1, out mul128_2, out mul128_3, _promises, 4);

                    _mulShift._mul = ((ulong4)mul).Reinterpret<ulong4, T>();
                    _mulShift._shift = ((ulong4)shift).Reinterpret<ulong4, T>();
                }
                else if (Architecture.IsSIMDSupported)
                {
                    msbminit_epu64(divisor.xy, out v128 mul,   out v128 shift,   out mul128_0, out mul128_1, _promises);
                    msbminit_epu64(divisor.zw, out v128 mulZW, out v128 shiftZW, out mul128_2, out mul128_3, _promises);

                    _mulShift._mul = new ulong4(mul, mulZW).Reinterpret<ulong4, T>();
                    _mulShift._shift = new ulong4(shift, shiftZW).Reinterpret<ulong4, T>();
                }
                else
                {
                    ulong4 shift = Uninitialized<ulong4>.Create();
                    ulong4 mul = Uninitialized<ulong4>.Create();

                    msbminit_u64(divisor.x, out mul.x, out shift.x, out mul128_0,
                                 divisor.y, out mul.y, out shift.y, out mul128_1,
                                 divisor.z, out mul.z, out shift.z, out mul128_2,
                                 divisor.w, out mul.w, out shift.w, out mul128_3,
                                 _promises);

                    _mulShift._mul = mul.Reinterpret<ulong4, T>();
                    _mulShift._shift = shift.Reinterpret<ulong4, T>();
                }

                _bigM.SetField(mul128_0, 0);
                _bigM.SetField(mul128_1, 1);
                _bigM.SetField(mul128_2, 2);
                _bigM.SetField(mul128_3, 3);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(UInt128 divisor, Promise promises = Promise.Nothing)
            : this(divisor.Reinterpret<UInt128, T>(), promises, Signedness.Unsigned, (byte)sizeof(UInt128))
        {
#if DEBUG
_typeInfo = new TypeInfo((byte)sizeof(UInt128), 1, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            msbminit_u128(divisor, out UInt128 mul, out UInt128 shift, out __UInt256__ mulrem, _promises);

            _mulShift._mul = mul.Reinterpret<UInt128, T>();
            _mulShift._shift = shift.Reinterpret<UInt128, T>();
            _bigM = mulrem.Reinterpret<__UInt256__, BigM>();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void bminit_u8(byte d, out ushort mul)
        {
            mul = (ushort)(ushort.MaxValue / (uint)d + 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void bminit_u16(ushort d, out uint mul)
        {
            mul = uint.MaxValue / (uint)d + 1u;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void msinit_u16(ushort d, [NoAlias] out ushort mul, [NoAlias] out ushort shift, DividerPromise promises)
        {
Assert.AreNotEqual(d, 0ul);

            ushort L = ceillog2(d);
            uint L2 = 1u << L;

            mul = (ushort)(((L2 - d) << 16) / d + 1);

            if (promises.NotOne)
            {
                shift = (ushort)(L - 1);
            }
            else
            {
                shift = (ushort)(L - toushort(d != 1));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void msinit_u32(uint d, [NoAlias] out uint mul, [NoAlias] out uint shift, DividerPromise promises)
        {
Assert.AreNotEqual(d, 0u);

            uint L = (uint)ceillog2(d);
            ulong L2 = 1ul << (int)L;

            mul = 1u + (uint)(((L2 - d) << 32) / d);

            if (promises.NotOne)
            {
                shift = L - 1;
            }
            else
            {
                shift = L - touint(d != 1);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void bminit_u32(uint d, out ulong mul)
        {
            mul = ulong.MaxValue / d + 1u;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void bminit_epu32(uint2 d, out ulong2 mul)
        {
            if (Architecture.IsSIMDSupported)
            {
                mul = Xse.inc_epi64(Xse.impl_div_epu64(Xse.setall_si128(), Xse.cvtepu32_epi64(RegisterConversion.ToV128(d)), bLEu32max: true));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void bminit_epu32(uint3 d, out ulong3 mul)
        {
            if (Avx2.IsAvx2Supported)
            {
                mul = Xse.mm256_inc_epi64(Xse.mm256_impl_div_epu64(Xse.mm256_setall_si256(), Avx2.mm256_cvtepu32_epi64(RegisterConversion.ToV128(d)), bLEu32max: true, elements: 3));
            }
            else if (Architecture.IsSIMDSupported)
            {
                v128 xy = Xse.inc_epi64(Xse.impl_div_epu64(Xse.setall_si128(), Xse.cvtepu32_epi64(RegisterConversion.ToV128(d)), true, bLEu32max: true));
                bminit_u32(d.z, out ulong z);

                mul = new ulong3(xy, z);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void bminit_epu32(uint4 d, out ulong4 mul)
        {
            if (Avx2.IsAvx2Supported)
            {
                mul = Xse.mm256_inc_epi64(Xse.mm256_impl_div_epu64(Xse.mm256_setall_si256(), Avx2.mm256_cvtepu32_epi64(RegisterConversion.ToV128(d)), bLEu32max: true));
            }
            else if (Architecture.IsSIMDSupported)
            {
                v128 lo = Xse.cvt2x2epu32_epi64(RegisterConversion.ToV128(d), out v128 hi);

                v128 xy = Xse.inc_epi64(Xse.impl_div_epu64(Xse.setall_si128(), lo, true, bLEu32max: true));
                v128 zw = Xse.inc_epi64(Xse.impl_div_epu64(Xse.setall_si128(), hi, false, bLEu32max: true));

                mul = new ulong4(xy, zw);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void mm256_bminit_epu32(v256 d, [NoAlias] out v256 mulLo, [NoAlias] out v256 mulHi)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 lo = Xse.mm256_cvt2x2epu32_epi64(d, out v256 hi);

                v256 _mulLo = Xse.mm256_inc_epi64(Xse.mm256_impl_div_epu64(Xse.mm256_setall_si256(), lo, bLEu32max: true));
                v256 _mulHi = Xse.mm256_inc_epi64(Xse.mm256_impl_div_epu64(Xse.mm256_setall_si256(), hi, bLEu32max: true));

                mulLo = new v256(_mulLo.Lo128, _mulHi.Lo128);
                mulHi = new v256(_mulLo.Hi128, _mulHi.Hi128);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void msbminit_u64(ulong d, [NoAlias] out ulong mul, [NoAlias] out ulong shift, [NoAlias] out UInt128 mulrem, DividerPromise promises)
        {
Assert.AreNotEqual(d, 0ul);

            ulong L = ceillog2(d);
            UInt128 L2 = (UInt128)1 << (int)L;

            mulrem = asm128.__spc__udivmax128x64_inc(d);
            mul = 1 + asm128.__spc__udiv128hiXloRlo((L2 - d).lo64, d);

            if (promises.NotOne)
            {
                shift = L - 1;
            }
            else
            {
                shift = L - touint(d != 1);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void msbminit_u64(ulong d0, [NoAlias] out ulong mul0, [NoAlias] out ulong shift_0, [NoAlias] out UInt128 mulrem0,
                                          ulong d1, [NoAlias] out ulong mul1, [NoAlias] out ulong shift_1, [NoAlias] out UInt128 mulrem1,
                                          DividerPromise promises)
        {
Assert.AreNotEqual(d0, 0ul);
Assert.AreNotEqual(d1, 0ul);

            ulong L0 = ceillog2(d0);
            ulong L1 = ceillog2(d1);
            UInt128 L2_0 = (UInt128)1 << (int)L0;
            UInt128 L2_1 = (UInt128)1 << (int)L1;

            ulong2 mul = 1 + asm128.__spc__2xudiv128hiXloRlo(new ulong2((L2_0 - d0).lo64,
                                                                        (L2_1 - d1).lo64),
                                                             new ulong2(d0,
                                                                        d1));
            asm128.__spc__2xudivmax128x64_inc(d0, out mulrem0,
                                              d1, out mulrem1);
            mul0 = mul.x;
            mul1 = mul.y;

            if (promises.NotOne)
            {
                shift_0 = L0 - 1;
                shift_1 = L1 - 1;
            }
            else
            {
                shift_0 = L0 - touint(d0 != 1);
                shift_1 = L1 - touint(d1 != 1);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void msbminit_u64(ulong d0, [NoAlias] out ulong mul0, [NoAlias] out ulong shift_0, [NoAlias] out UInt128 mulrem0,
                                          ulong d1, [NoAlias] out ulong mul1, [NoAlias] out ulong shift_1, [NoAlias] out UInt128 mulrem1,
                                          ulong d2, [NoAlias] out ulong mul2, [NoAlias] out ulong shift_2, [NoAlias] out UInt128 mulrem2,
                                          DividerPromise promises)
        {
Assert.AreNotEqual(d0, 0ul);
Assert.AreNotEqual(d1, 0ul);
Assert.AreNotEqual(d2, 0ul);

            ulong L0 = ceillog2(d0);
            ulong L1 = ceillog2(d1);
            ulong L2 = ceillog2(d2);
            UInt128 L2_0 = (UInt128)1 << (int)L0;
            UInt128 L2_1 = (UInt128)1 << (int)L1;
            UInt128 L2_2 = (UInt128)1 << (int)L2;

            ulong3 mul = 1 + asm128.__spc__3xudiv128hiXloRlo(new ulong3((L2_0 - d0).lo64,
                                                                        (L2_1 - d1).lo64,
                                                                        (L2_2 - d2).lo64),
                                                             new ulong3(d0,
                                                                        d1,
                                                                        d2));
            asm128.__spc__3xudivmax128x64_inc(d0, out mulrem0,
                                              d1, out mulrem1,
                                              d2, out mulrem2);
            mul0 = mul.x;
            mul1 = mul.y;
            mul2 = mul.z;

            if (promises.NotOne)
            {
                shift_0 = L0 - 1;
                shift_1 = L1 - 1;
                shift_2 = L2 - 1;
            }
            else
            {
                shift_0 = L0 - touint(d0 != 1);
                shift_1 = L1 - touint(d1 != 1);
                shift_2 = L2 - touint(d2 != 1);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void msbminit_u64(ulong d0, [NoAlias] out ulong mul0, [NoAlias] out ulong shift_0, [NoAlias] out UInt128 mulrem0,
                                          ulong d1, [NoAlias] out ulong mul1, [NoAlias] out ulong shift_1, [NoAlias] out UInt128 mulrem1,
                                          ulong d2, [NoAlias] out ulong mul2, [NoAlias] out ulong shift_2, [NoAlias] out UInt128 mulrem2,
                                          ulong d3, [NoAlias] out ulong mul3, [NoAlias] out ulong shift_3, [NoAlias] out UInt128 mulrem3,
                                          DividerPromise promises)
        {
Assert.AreNotEqual(d0, 0ul);
Assert.AreNotEqual(d1, 0ul);
Assert.AreNotEqual(d2, 0ul);
Assert.AreNotEqual(d3, 0ul);

            ulong L0 = ceillog2(d0);
            ulong L1 = ceillog2(d1);
            ulong L2 = ceillog2(d2);
            ulong L3 = ceillog2(d3);
            UInt128 L2_0 = (UInt128)1 << (int)L0;
            UInt128 L2_1 = (UInt128)1 << (int)L1;
            UInt128 L2_2 = (UInt128)1 << (int)L2;
            UInt128 L2_3 = (UInt128)1 << (int)L3;

            ulong4 mul = 1 + asm128.__spc__4xudiv128hiXloRlo(new ulong4((L2_0 - d0).lo64,
                                                                        (L2_1 - d1).lo64,
                                                                        (L2_2 - d2).lo64,
                                                                        (L2_3 - d3).lo64),
                                                             new ulong4(d0,
                                                                        d1,
                                                                        d2,
                                                                        d3));
            asm128.__spc__4xudivmax128x64_inc(d0, out mulrem0,
                                              d1, out mulrem1,
                                              d2, out mulrem2,
                                              d3, out mulrem3);
            mul0 = mul.x;
            mul1 = mul.y;
            mul2 = mul.z;
            mul3 = mul.w;

            if (promises.NotOne)
            {
                shift_0 = L0 - 1;
                shift_1 = L1 - 1;
                shift_2 = L2 - 1;
                shift_3 = L3 - 1;
            }
            else
            {
                shift_0 = L0 - touint(d0 != 1);
                shift_1 = L1 - touint(d1 != 1);
                shift_2 = L2 - touint(d2 != 1);
                shift_3 = L3 - touint(d3 != 1);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void msbminit_u128(UInt128 d, [NoAlias] out UInt128 mul, [NoAlias] out UInt128 shift, [NoAlias] out __UInt256__ mulrem, DividerPromise promises)
        {
Assert.AreNotEqual(d, 0ul);

            UInt128 L = ceillog2(d);
            __UInt256__ L2 = (__UInt256__)1u << (int)L;

            mulrem = __UInt256__.MaxValue / d + (UInt128)1;
            mul = __UInt256__.__usf__udiv256x128(new __UInt256__(0, (L2 - d).lo128), d);
            mul++;

            if (promises.NotOne)
            {
                shift = L - 1;
            }
            else
            {
                shift = L - touint(d != 1);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void bminit_epu8(v128 d, out v128 mul, DividerPromise promises, byte elements = 8)
        {
VectorAssert.AreNotEqual<byte16, byte>(d, 0, elements);

            if (Architecture.IsSIMDSupported)
            {
                if (Architecture.IsTableLookupSupported)
                {
                    if (constexpr.ALL_LE_EPU8(d, 16, elements))
                    {
                        bminitLE16_epu8(d, out mul, elements);

                        return;
                    }
                }

                v128 MUL_16 = Xse.setall_si128();

                mul = Xse.impl_usfdivadd_epu16(MUL_16, Xse.cvtepu8_epi16(d), Xse.set1_epi16(1), elements: elements, correctOverflow: !promises.NotOne);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void bminit_epu16(v128 d, out v128 mul, byte elements = 4)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 MUL_32 = Xse.setall_si128();

                mul = Xse.inc_epi32(Xse.impl_div_epu32(MUL_32, Xse.cvtepu16_epi32(d), elements));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void bminit_epu8(v128 d, [NoAlias] out v128 mulLo, [NoAlias] out v128 mulHi, DividerPromise promises)
        {
VectorAssert.AreNotEqual<byte16, byte>(d, 0, 16);

            if (Architecture.IsSIMDSupported)
            {
                if (Architecture.IsTableLookupSupported)
                {
                    if (constexpr.ALL_LE_EPU8(d, 16))
                    {
                        bminitLE16_epu8(d, out mulLo, out mulHi);

                        return;
                    }
                }

                v128 MUL_16 = Xse.setall_si128();

                v128 dLo = Xse.cvt2x2epu8_epi16(d, out v128 dHi);
                mulLo = Xse.impl_usfdivadd_epu16(MUL_16, dLo, Xse.set1_epi16(1), correctOverflow: !promises.NotOne);
                mulHi = Xse.impl_usfdivadd_epu16(MUL_16, dHi, Xse.set1_epi16(1), correctOverflow: !promises.NotOne);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void bminit_epu16(v128 d, [NoAlias] out v128 mulLo, [NoAlias] out v128 mulHi)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 MUL_32 = Xse.setall_si128();

                v128 dLo = Xse.cvt2x2epu16_epi32(d, out v128 dHi);
                mulLo = Xse.inc_epi32(Xse.impl_div_epu32(MUL_32, dLo));
                mulHi = Xse.inc_epi32(Xse.impl_div_epu32(MUL_32, dHi));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void msinit_epu32(v128 a, [NoAlias] out v128 mul, [NoAlias] out v128 shift, DividerPromise promises, byte elements = 4)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 ONE_32 = Xse.set1_epi32(1);
                v128 ONE_64 = Xse.set1_epi64x(1);

                v128 L = Xse.sub_epi32(Xse.set1_epi32(32), Xse.lzcnt_epi32(Xse.dec_epi32(a), elements));

                switch (elements)
                {
                    case 2:
                    {
                        v128 a64 = Xse.cvtepu32_epi64(a);
                        v128 L2;

                        if (promises.LZCNTnot0)
                        {
                            L2 = Xse.sllv_epi32(ONE_32, L, inRange: true, elements: elements);
                            L2 = Xse.sub_epi32(L2, a);

                            L2 = Xse.unpacklo_epi32(Xse.setzero_si128(), L2);
                        }
                        else
                        {
                            v128 shifts = Xse.cvtepu32_epi64(L);
                            L2 = Xse.slli_epi64(Xse.sub_epi64(Xse.sllv_epi64(ONE_64, shifts, inRange: true), a64), 32);
                        }

                        mul = Xse.add_epi32(ONE_32, Xse.cvtepi64_epi32(Xse.impl_div_epu64(L2, a64, useFPU: false, aLEu32max: false, bLEu32max: true)));

                        break;
                    }
                    case 3:
                    {
                        v128 a64Lo = Xse.cvtepu32_epi64(a);
                        v128 L2Lo;

                        if (promises.LZCNTnot0)
                        {
                            v128 L2 = Xse.sllv_epi32(ONE_32, L, inRange: true, elements: elements);
                            L2 = Xse.sub_epi32(L2, a);

                            L2Lo = Xse.unpacklo_epi32(Xse.setzero_si128(), L2);
                        }
                        else
                        {
                            v128 shiftsLo = Xse.cvtepu32_epi64(L);
                            L2Lo = Xse.slli_epi64(Xse.sub_epi64(Xse.sllv_epi64(ONE_64, shiftsLo, inRange: true), a64Lo), 32);
                        }

                        v128 mulLo = Xse.cvtepi64_epi32(Xse.impl_div_epu64(L2Lo, a64Lo, useFPU: true, aLEu32max: false, bLEu32max: true));

                        ulong L2z = 1ul << (int)Xse.extract_epi32(L, 2);
                        ulong mulZ = ((L2z - Xse.extract_epi32(a, 2)) << 32) / Xse.extract_epi32(a, 2);

                        mul = Xse.add_epi32(ONE_32, Xse.insert_epi32(mulLo, (uint)mulZ, 2));

                        break;
                    }
                    default:
                    {
                        v128 a64Lo = Xse.cvt2x2epu32_epi64(a, out v128 a64Hi);
                        v128 L2Lo;
                        v128 L2Hi;

                        if (promises.LZCNTnot0)
                        {
                            v128 L2 = Xse.sllv_epi32(ONE_32, L, inRange: true, elements: elements);
                            L2 = Xse.sub_epi32(L2, a);

                            L2Lo = Xse.unpacklo_epi32(Xse.setzero_si128(), L2);
                            L2Hi = Xse.unpackhi_epi32(Xse.setzero_si128(), L2);
                        }
                        else
                        {
                            v128 shiftsLo = Xse.cvt2x2epu32_epi64(L, out v128 shiftsHi);
                            L2Lo = Xse.slli_epi64(Xse.sub_epi64(Xse.sllv_epi64(ONE_64, shiftsLo, inRange: true), a64Lo), 32);
                            L2Hi = Xse.slli_epi64(Xse.sub_epi64(Xse.sllv_epi64(ONE_64, shiftsHi, inRange: true), a64Hi), 32);
                        }

                        v128 mulLo = Xse.impl_div_epu64(L2Lo, a64Lo, useFPU: true,  aLEu32max: false, bLEu32max: true);
                        v128 mulHi = Xse.impl_div_epu64(L2Hi, a64Hi, useFPU: false, aLEu32max: false, bLEu32max: true);

                        mul = Xse.add_epi32(ONE_32, Xse.cvt2x2epi64_epi32(mulLo, mulHi));

                        break;
                    }
                }

                if (promises.NotOne)
                {
                    shift = Xse.sub_epi32(L, ONE_32);
                }
                else
                {
                    shift = Xse.sub_epi32(L, Xse.andnot_si128(Xse.cmpeq_epi32(a, ONE_32), ONE_32));
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void msbminit_epu64(v128 a, [NoAlias] out v128 mul, [NoAlias] out v128 shift, out UInt128 mulrem0, out UInt128 mulrem1, DividerPromise promises)
        {
VectorAssert.AreNotEqual<ulong2, ulong>(a, 0ul, 2);

            if (Architecture.IsSIMDSupported)
            {
                v128 ONE = Xse.set1_epi64x(1);
                v128 L;

                ulong aLo = Xse.extract_epi64(a, 0);
                ulong aHi = Xse.extract_epi64(a, 1);

                if (promises.LZCNTnot0)
                {
                    L = Xse.sub_epi64(Xse.set1_epi64x(64), Xse.lzcnt_epi64(Xse.sub_epi64(a, ONE)));
                    v128 L2 = Xse.sllv_epi64(ONE, L);
                    L2 = Xse.sub_epi64(L2, a);

                    mul = Xse.impl_udivrem128_epu64(L2, a, out _, unsafeRange: true, useFPU: true);
                }
                else
                {

                    ulong LLo = ceillog2(aLo);
                    ulong LHi = ceillog2(aHi);
                    UInt128 L2Lo = (UInt128)1 << (int)LLo;
                    UInt128 L2Hi = (UInt128)1 << (int)LHi;
                    L = Xse.unpacklo_epi64(Xse.cvtsi64x_si128(LLo), Xse.cvtsi64x_si128(LHi));

                    mul = asm128.__spc__2xudiv128hiXloRlo(new ulong2((L2Lo - aLo).lo64,
                                                                     (L2Hi - aHi).lo64),
                                                          new ulong2(aLo,
                                                                     aHi));
                }

                asm128.__spc__2xudivmax128x64_inc(aLo, out mulrem0,
                                                  aHi, out mulrem1);

                mul = Xse.add_epi64(mul, ONE);

                if (promises.NotOne)
                {
                    shift = Xse.sub_epi64(L, ONE);
                }
                else
                {
                    shift = Xse.sub_epi64(L, Xse.andnot_si128(Xse.cmpeq_epi64(a, ONE), ONE));
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void mm256_bminit_epu8(v256 d, [NoAlias] out v256 mulLo, [NoAlias] out v256 mulHi, DividerPromise promises)
        {
VectorAssert.AreNotEqual<byte32, byte>(d, 0, 32);

            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.ALL_LE_EPU8(d, 16))
                {
                    mm256_bminitLE16_epu8(d, out mulLo, out mulHi);
                }
                else
                {
                    v256 MUL_16 = Xse.mm256_setall_si256();

                    v256 dLo = Xse.mm256_cvt2x2epu8_epi16(d, out v256 dHi);
                    v256 _mulLo = Xse.mm256_impl_usfdivadd_epu16(MUL_16, dLo, Xse.mm256_set1_epi16(1), correctOverflow: !promises.NotOne);
                    v256 _mulHi = Xse.mm256_impl_usfdivadd_epu16(MUL_16, dHi, Xse.mm256_set1_epi16(1), correctOverflow: !promises.NotOne);

                    mulLo = new v256(_mulLo.Lo128, _mulHi.Lo128);
                    mulHi = new v256(_mulLo.Hi128, _mulHi.Hi128);
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void mm256_bminit_epu16(v256 d, [NoAlias] out v256 mulLo, [NoAlias] out v256 mulHi)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 MUL_32 = Xse.mm256_setall_si256();

                v256 dLo = Xse.mm256_cvt2x2epu16_epi32(d, out v256 dHi);
                v256 _mulLo = Xse.mm256_inc_epi32(Xse.mm256_impl_div_epu32(MUL_32, dLo));
                v256 _mulHi = Xse.mm256_inc_epi32(Xse.mm256_impl_div_epu32(MUL_32, dHi));

                mulLo = new v256(_mulLo.Lo128, _mulHi.Lo128);
                mulHi = new v256(_mulLo.Hi128, _mulHi.Hi128);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void mm256_msinit_epu32(v256 a, [NoAlias] out v256 mul, [NoAlias] out v256 shift, DividerPromise promises)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 ONE_32 = Xse.mm256_set1_epi32(1);

                v256 L = Avx2.mm256_sub_epi32(Xse.mm256_set1_epi32(32), Xse.mm256_lzcnt_epi32(Avx2.mm256_sub_epi32(a, ONE_32)));
                v256 a64Lo = Xse.mm256_cvt2x2epu32_epi64(a, out v256 a64Hi);
                v256 L2Lo;
                v256 L2Hi;

                if (promises.LZCNTnot0)
                {
                    v256 L2 = Avx2.mm256_sllv_epi32(ONE_32, L);
                    L2 = Avx2.mm256_sub_epi32(L2, a);

                    L2Lo = Avx2.mm256_unpacklo_epi32(Avx.mm256_setzero_si256(), L2);
                    L2Hi = Avx2.mm256_unpackhi_epi32(Avx.mm256_setzero_si256(), L2);
                }
                else
                {
                    v256 ONE_64 = Xse.mm256_set1_epi64x(1);

                    v256 shiftsLo = Xse.mm256_cvt2x2epu32_epi64(L, out v256 shiftsHi);
                    L2Lo = Avx2.mm256_slli_epi64(Avx2.mm256_sub_epi64(Avx2.mm256_sllv_epi64(ONE_64, shiftsLo), a64Lo), 32);
                    L2Hi = Avx2.mm256_slli_epi64(Avx2.mm256_sub_epi64(Avx2.mm256_sllv_epi64(ONE_64, shiftsHi), a64Hi), 32);
                }

                v256 mulLo = Xse.mm256_impl_div_epu64(L2Lo, a64Lo, aLEu32max: false, bLEu32max: true);
                v256 mulHi = Xse.mm256_impl_div_epu64(L2Hi, a64Hi, aLEu32max: false, bLEu32max: true);
                mul = Avx2.mm256_add_epi32(ONE_32, Xse.mm256_cvt2x2epi64_epi32(mulLo, mulHi));

                if (promises.NotOne)
                {
                    shift = Avx2.mm256_sub_epi32(L, ONE_32);
                }
                else
                {
                    shift = Avx2.mm256_sub_epi32(L, Avx2.mm256_andnot_si256(Avx2.mm256_cmpeq_epi32(a, ONE_32), ONE_32));
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void mm256_msbminit_epu64(v256 a, [NoAlias] out v256 mul, [NoAlias] out v256 shift, [NoAlias] out UInt128 mulrem0, [NoAlias] out UInt128 mulrem1, [NoAlias] out UInt128 mulrem2, [NoAlias] out UInt128 mulrem3, DividerPromise promises, byte elements = 4)
        {
VectorAssert.AreNotEqual<ulong4, ulong>(a, 0ul, elements);

            if (Avx2.IsAvx2Supported)
            {
                v256 ONE = Xse.mm256_set1_epi64x(1);
                v256 L;

                if (promises.LZCNTnot0)
                {
                    L = Avx2.mm256_sub_epi64(Xse.mm256_set1_epi64x(64), Xse.mm256_lzcnt_epi64(Avx2.mm256_sub_epi64(a, ONE)));
                    v256 L2 = Avx2.mm256_sllv_epi64(ONE, L);
                    L2 = Avx2.mm256_sub_epi64(L2, a);

                    mul = Xse.mm256_impl_udivrem128_epu64(L2, a, out _, elements: elements, unsafeRange: true);
                }
                else
                {
                    ulong a0 = Xse.mm256_extract_epi64(a, 0);
                    ulong a1 = Xse.mm256_extract_epi64(a, 1);
                    ulong a2 = Xse.mm256_extract_epi64(a, 2);

                    ulong L0 = ceillog2(a0);
                    ulong L1 = ceillog2(a1);
                    ulong L2 = ceillog2(a2);
                    UInt128 L2_0 = (UInt128)1 << (int)L0;
                    UInt128 L2_1 = (UInt128)1 << (int)L1;
                    UInt128 L2_2 = (UInt128)1 << (int)L2;

                    v128 LLo = Xse.unpacklo_epi64(Xse.cvtsi64x_si128(L0), Xse.cvtsi64x_si128(L1));
                    v128 LHi = Xse.cvtsi64x_si128(L2);

                    if (elements == 4)
                    {
                        ulong a3 = Xse.mm256_extract_epi64(a, 3);
                        ulong L3 = ceillog2(a3);
                        UInt128 L2_3 = (UInt128)1 << (int)L3;
                        LHi = Xse.unpacklo_epi64(LHi, Xse.cvtsi64x_si128(L3));

                        mul = asm128.__spc__4xudiv128hiXloRlo(new ulong4((L2_0 - a0).lo64,
                                                                         (L2_1 - a1).lo64,
                                                                         (L2_2 - a2).lo64,
                                                                         (L2_3 - a3).lo64),
                                                              new ulong4(a0,
                                                                         a1,
                                                                         a2,
                                                                         a3));
                    }
                    else
                    {
                        mul = asm128.__spc__3xudiv128hiXloRlo(new ulong3((L2_0 - a0).lo64,
                                                                         (L2_1 - a1).lo64,
                                                                         (L2_2 - a2).lo64),
                                                              new ulong3(a0,
                                                                         a1,
                                                                         a2));
                    }

                    L = Avx2.mm256_inserti128_si256(Avx.mm256_castsi128_si256(LLo), LHi, 1);
                }

                if (elements == 4)
                {
                    asm128.__spc__4xudivmax128x64_inc(Xse.mm256_extract_epi64(a, 0), out mulrem0,
                                                      Xse.mm256_extract_epi64(a, 1), out mulrem1,
                                                      Xse.mm256_extract_epi64(a, 2), out mulrem2,
                                                      Xse.mm256_extract_epi64(a, 3), out mulrem3);
                }
                else
                {
                    asm128.__spc__3xudivmax128x64_inc(Xse.mm256_extract_epi64(a, 0), out mulrem0,
                                                      Xse.mm256_extract_epi64(a, 1), out mulrem1,
                                                      Xse.mm256_extract_epi64(a, 2), out mulrem2);
                    mulrem3 = 0;
                }

                mul = Avx2.mm256_add_epi64(mul, ONE);

                if (promises.NotOne)
                {
                    shift = Avx2.mm256_sub_epi64(L, ONE);
                }
                else
                {
                    shift = Avx2.mm256_sub_epi64(L, Avx2.mm256_andnot_si256(Avx2.mm256_cmpeq_epi64(a, ONE), ONE));
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void msinit_epu16(v128 a, [NoAlias] out v128 mul, [NoAlias] out v128 shift, DividerPromise promises, byte elements = 8)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 ONE = Xse.set1_epi16(1);

                v128 L = Xse.sub_epi16(Xse.set1_epi16(16), Xse.lzcnt_epi16(Xse.dec_epi16(a)));

                if (elements == 8)
                {
                    v128 lLo = Xse.cvt2x2epu16_epi32(L, out v128 lHi);
                    v128 aLo = Xse.cvt2x2epu16_epi32(a, out v128 aHi);

                    lLo = Xse.sllv_epi32(Xse.set1_epi32(1), lLo, inRange: true);
                    lHi = Xse.sllv_epi32(Xse.set1_epi32(1), lHi, inRange: true);
                    lLo = Xse.slli_epi32(Xse.sub_epi32(lLo, aLo), 16);
                    lHi = Xse.slli_epi32(Xse.sub_epi32(lHi, aHi), 16);
                    v128 lo = Xse.impl_div_epu32(lLo, aLo);
                    v128 hi = Xse.impl_div_epu32(lHi, aHi);

                    if (Sse4_1.IsSse41Supported)
                    {
                        mul = Xse.add_epi16(ONE, Xse.packus_epi32(lo, hi));
                    }
                    else
                    {
                        mul = Xse.add_epi16(ONE, Xse.cvt2x2epi32_epi16(lo, hi));
                    }
                }
                else
                {
                    v128 l32 = Xse.cvtepu16_epi32(L);
                    v128 a32 = Xse.cvtepu16_epi32(a);

                    l32 = Xse.sllv_epi32(Xse.set1_epi32(1), l32, inRange: true, elements: elements);
                    l32 = Xse.slli_epi32(Xse.sub_epi32(l32, a32), 16);

                    mul = Xse.add_epi16(ONE, Xse.cvtepi32_epi16(Xse.impl_div_epu32(l32, a32, elements)));
                }

                if (promises.NotOne)
                {
                    shift = Xse.sub_epi16(L, ONE);
                }
                else
                {
                    shift = Xse.sub_epi16(L, Xse.andnot_si128(Xse.cmpeq_epi16(a, ONE), ONE));
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void mm256_msinit_epu16(v256 a, [NoAlias] out v256 mul, [NoAlias] out v256 shift, DividerPromise promises)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 ONE = Xse.mm256_set1_epi16(1);

                v256 L = Avx2.mm256_sub_epi16(Xse.mm256_set1_epi16(16), Xse.mm256_lzcnt_epi16(Xse.mm256_dec_epi16(a)));

                v256 lLo = Xse.mm256_cvt2x2epu16_epi32(L, out v256 lHi);
                v256 aLo = Xse.mm256_cvt2x2epu16_epi32(a, out v256 aHi);

                lLo = Avx2.mm256_sllv_epi32(Xse.mm256_set1_epi32(1), lLo);
                lHi = Avx2.mm256_sllv_epi32(Xse.mm256_set1_epi32(1), lHi);
                lLo = Avx2.mm256_slli_epi32(Avx2.mm256_sub_epi32(lLo, aLo), 16);
                lHi = Avx2.mm256_slli_epi32(Avx2.mm256_sub_epi32(lHi, aHi), 16);
                v256 lo = Xse.mm256_impl_div_epu32(lLo, aLo);
                v256 hi = Xse.mm256_impl_div_epu32(lHi, aHi);

                mul = Avx2.mm256_add_epi16(Avx2.mm256_packus_epi32(lo, hi), ONE);

                if (promises.NotOne)
                {
                    shift = Avx2.mm256_sub_epi16(L, ONE);
                }
                else
                {
                    shift = Avx2.mm256_sub_epi16(L, Avx2.mm256_andnot_si256(Avx2.mm256_cmpeq_epi16(a, ONE), ONE));
                }
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void bminitLE16_epu8(v128 d, out v128 mul, byte elements = 8)
        {
            if (Architecture.IsTableLookupSupported)
            {
                v128 LUT_LO;
                v128 LUT_HI;

                if (constexpr.ALL_LE_EPU8(d, 15, elements))
                {
                    LUT_LO = new v128(0b0000_0000, 0b0000_0000, 0b0000_0000, 0b0101_0110, 0b0000_0000, 0b0011_0100, 0b1010_1011, 0b1001_0011, 0b0000_0000, 0b0111_0010, 0b1001_1010, 0b0100_0110, 0b0101_0110, 0b1011_0010, 0b0100_1010, 0b0001_0010);
                    LUT_HI = new v128(0b0000_0000, 0b0000_0000, 0b1000_0000, 0b0101_0101, 0b0100_0000, 0b0011_0011, 0b0010_1010, 0b0010_0100, 0b0010_0000, 0b0001_1100, 0b0001_1001, 0b0001_0111, 0b0001_0101, 0b0001_0011, 0b0001_0010, 0b0001_0001);
                }
                else
                {
                    LUT_LO = new v128(0b0000_0000, 0b0000_0000, 0b0101_0110, 0b0000_0000, 0b0011_0100, 0b1010_1011, 0b1001_0011, 0b0000_0000, 0b0111_0010, 0b1001_1010, 0b0100_0110, 0b0101_0110, 0b1011_0010, 0b0100_1010, 0b0001_0010, 0b0000_0000);
                    LUT_HI = new v128(0b0000_0000, 0b1000_0000, 0b0101_0101, 0b0100_0000, 0b0011_0011, 0b0010_1010, 0b0010_0100, 0b0010_0000, 0b0001_1100, 0b0001_1001, 0b0001_0111, 0b0001_0101, 0b0001_0011, 0b0001_0010, 0b0001_0001, 0b0001_0000);

                    d = Xse.dec_epi8(d);
                }

                mul = Xse.unpacklo_epi8(Xse.shuffle_epi8(LUT_LO, d), Xse.shuffle_epi8(LUT_HI, d));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void bminitLE16_epu8(v128 d, [NoAlias] out v128 mulLo, [NoAlias] out v128 mulHi)
        {
            if (Architecture.IsTableLookupSupported)
            {
                v128 LUT_LO;
                v128 LUT_HI;

                if (constexpr.ALL_LE_EPU8(d, 15))
                {
                    LUT_LO = new v128(0b0000_0000, 0b0000_0000, 0b0000_0000, 0b0101_0110, 0b0000_0000, 0b0011_0100, 0b1010_1011, 0b1001_0011, 0b0000_0000, 0b0111_0010, 0b1001_1010, 0b0100_0110, 0b0101_0110, 0b1011_0010, 0b0100_1010, 0b0001_0010);
                    LUT_HI = new v128(0b0000_0000, 0b0000_0000, 0b1000_0000, 0b0101_0101, 0b0100_0000, 0b0011_0011, 0b0010_1010, 0b0010_0100, 0b0010_0000, 0b0001_1100, 0b0001_1001, 0b0001_0111, 0b0001_0101, 0b0001_0011, 0b0001_0010, 0b0001_0001);
                }
                else
                {
                    LUT_LO = new v128(0b0000_0000, 0b0000_0000, 0b0101_0110, 0b0000_0000, 0b0011_0100, 0b1010_1011, 0b1001_0011, 0b0000_0000, 0b0111_0010, 0b1001_1010, 0b0100_0110, 0b0101_0110, 0b1011_0010, 0b0100_1010, 0b0001_0010, 0b0000_0000);
                    LUT_HI = new v128(0b0000_0000, 0b1000_0000, 0b0101_0101, 0b0100_0000, 0b0011_0011, 0b0010_1010, 0b0010_0100, 0b0010_0000, 0b0001_1100, 0b0001_1001, 0b0001_0111, 0b0001_0101, 0b0001_0011, 0b0001_0010, 0b0001_0001, 0b0001_0000);

                    d = Xse.dec_epi8(d);
                }

                v128 lo = Xse.shuffle_epi8(LUT_LO, d);
                v128 hi = Xse.shuffle_epi8(LUT_HI, d);

                mulLo = Xse.unpacklo_epi8(lo, hi);
                mulHi = Xse.unpackhi_epi8(lo, hi);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void mm256_bminitLE16_epu8(v256 d, [NoAlias] out v256 mulLo, [NoAlias] out v256 mulHi)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 LUT_LO;
                v256 LUT_HI;

                if (constexpr.ALL_LE_EPU8(d, 15))
                {
                    LUT_LO = new v256(0b0000_0000, 0b0000_0000, 0b0000_0000, 0b0101_0110, 0b0000_0000, 0b0011_0100, 0b1010_1011, 0b1001_0011, 0b0000_0000, 0b0111_0010, 0b1001_1010, 0b0100_0110, 0b0101_0110, 0b1011_0010, 0b0100_1010, 0b0001_0010,
                                      0b0000_0000, 0b0000_0000, 0b0000_0000, 0b0101_0110, 0b0000_0000, 0b0011_0100, 0b1010_1011, 0b1001_0011, 0b0000_0000, 0b0111_0010, 0b1001_1010, 0b0100_0110, 0b0101_0110, 0b1011_0010, 0b0100_1010, 0b0001_0010);
                    LUT_HI = new v256(0b0000_0000, 0b0000_0000, 0b1000_0000, 0b0101_0101, 0b0100_0000, 0b0011_0011, 0b0010_1010, 0b0010_0100, 0b0010_0000, 0b0001_1100, 0b0001_1001, 0b0001_0111, 0b0001_0101, 0b0001_0011, 0b0001_0010, 0b0001_0001,
                                      0b0000_0000, 0b0000_0000, 0b1000_0000, 0b0101_0101, 0b0100_0000, 0b0011_0011, 0b0010_1010, 0b0010_0100, 0b0010_0000, 0b0001_1100, 0b0001_1001, 0b0001_0111, 0b0001_0101, 0b0001_0011, 0b0001_0010, 0b0001_0001);
                }
                else
                {
                    LUT_LO = new v256(0b0000_0000, 0b0000_0000, 0b0101_0110, 0b0000_0000, 0b0011_0100, 0b1010_1011, 0b1001_0011, 0b0000_0000, 0b0111_0010, 0b1001_1010, 0b0100_0110, 0b0101_0110, 0b1011_0010, 0b0100_1010, 0b0001_0010, 0b0000_0000,
                                      0b0000_0000, 0b0000_0000, 0b0101_0110, 0b0000_0000, 0b0011_0100, 0b1010_1011, 0b1001_0011, 0b0000_0000, 0b0111_0010, 0b1001_1010, 0b0100_0110, 0b0101_0110, 0b1011_0010, 0b0100_1010, 0b0001_0010, 0b0000_0000);
                    LUT_HI = new v256(0b0000_0000, 0b1000_0000, 0b0101_0101, 0b0100_0000, 0b0011_0011, 0b0010_1010, 0b0010_0100, 0b0010_0000, 0b0001_1100, 0b0001_1001, 0b0001_0111, 0b0001_0101, 0b0001_0011, 0b0001_0010, 0b0001_0001, 0b0001_0000,
                                      0b0000_0000, 0b1000_0000, 0b0101_0101, 0b0100_0000, 0b0011_0011, 0b0010_1010, 0b0010_0100, 0b0010_0000, 0b0001_1100, 0b0001_1001, 0b0001_0111, 0b0001_0101, 0b0001_0011, 0b0001_0010, 0b0001_0001, 0b0001_0000);

                    d = Xse.mm256_dec_epi8(d);
                }

                d = Avx2.mm256_permute4x64_epi64(d, Sse.SHUFFLE(3, 1, 2, 0));

                v256 lo = Avx2.mm256_shuffle_epi8(LUT_LO, d);
                v256 hi = Avx2.mm256_shuffle_epi8(LUT_HI, d);

                mulLo = Avx2.mm256_unpacklo_epi8(lo, hi);
                mulHi = Avx2.mm256_unpackhi_epi8(lo, hi);
            }
            else throw new IllegalInstructionException();
        }
    }
}
