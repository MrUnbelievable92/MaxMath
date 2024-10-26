using System;
using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Burst;
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
        public Divider(sbyte divisor, Promise promises = Promise.Nothing)
            : this(divisor.Reinterpret<sbyte, T>(), promises, Signedness.Signed, sizeof(sbyte))
        {
#if DEBUG
_typeInfo = new TypeInfo(sizeof(sbyte), 1, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            bminit_i8(divisor, out ushort mul, _promises);

            _bigM = mul.Reinterpret<ushort, BigM>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(sbyte2 divisor, Promise promises = Promise.Nothing)
            : this(divisor.Reinterpret<sbyte2, T>(), promises, Signedness.Signed, sizeof(sbyte))
        {
#if DEBUG
_typeInfo = new TypeInfo(sizeof(sbyte), 2, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            if (_promises.SameValue)
            {
                bminit_i8(divisor.x, out ushort mul, _promises);

                _bigM = ((ushort2)mul).Reinterpret<ushort2, BigM>();
            }
            else
            {
                if (Architecture.IsSIMDSupported)
                {
                    bminit_epi8(divisor, out v128 mul16, _promises, 2);

                    _bigM = ((ushort2)mul16).Reinterpret<ushort2, BigM>();
                }
                else
                {
                    ushort2 mul;
                    bminit_i8(divisor.x, out mul.x, _promises);
                    bminit_i8(divisor.y, out mul.y, _promises);

                    _bigM = mul.Reinterpret<ushort2, BigM>();
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(sbyte3 divisor, Promise promises = Promise.Nothing)
            : this(divisor.Reinterpret<sbyte3, T>(), promises, Signedness.Signed, sizeof(sbyte))
        {
#if DEBUG
_typeInfo = new TypeInfo(sizeof(sbyte), 3, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            if (_promises.SameValue)
            {
                bminit_i8(divisor.x, out ushort mul, _promises);

                _bigM = ((ushort3)mul).Reinterpret<ushort3, BigM>();
            }
            else
            {
                if (Architecture.IsSIMDSupported)
                {
                    bminit_epi8(divisor, out v128 mul16, _promises, 3);

                    _bigM = ((ushort3)mul16).Reinterpret<ushort3, BigM>();
                }
                else
                {
                    ushort3 mul;
                    bminit_i8(divisor.x, out mul.x, _promises);
                    bminit_i8(divisor.y, out mul.y, _promises);
                    bminit_i8(divisor.z, out mul.z, _promises);

                    _bigM = mul.Reinterpret<ushort3, BigM>();
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(sbyte4 divisor, Promise promises = Promise.Nothing)
            : this(divisor.Reinterpret<sbyte4, T>(), promises, Signedness.Signed, sizeof(sbyte))
        {
#if DEBUG
_typeInfo = new TypeInfo(sizeof(sbyte), 4, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            if (_promises.SameValue)
            {
                bminit_i8(divisor.x, out ushort mul, _promises);

                _bigM = ((ushort4)mul).Reinterpret<ushort4, BigM>();
            }
            else
            {
                if (Architecture.IsSIMDSupported)
                {
                    bminit_epi8(divisor, out v128 mul16, _promises, 4);

                    _bigM = ((ushort4)mul16).Reinterpret<ushort4, BigM>();
                }
                else
                {
                    ushort4 mul;
                    bminit_i8(divisor.x, out mul.x, _promises);
                    bminit_i8(divisor.y, out mul.y, _promises);
                    bminit_i8(divisor.z, out mul.z, _promises);
                    bminit_i8(divisor.w, out mul.w, _promises);

                    _bigM = mul.Reinterpret<ushort4, BigM>();
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(sbyte8 divisor, Promise promises = Promise.Nothing)
            : this(divisor.Reinterpret<sbyte8, T>(), promises, Signedness.Signed, sizeof(sbyte))
        {
#if DEBUG
_typeInfo = new TypeInfo(sizeof(sbyte), 8, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            if (_promises.SameValue)
            {
                bminit_i8(divisor.x0, out ushort mul, _promises);

                _bigM = ((ushort8)mul).Reinterpret<ushort8, BigM>();
            }
            else
            {
                if (Architecture.IsSIMDSupported)
                {
                    bminit_epi8(divisor, out v128 mul16, _promises, 8);

                    _bigM = ((ushort8)mul16).Reinterpret<ushort8, BigM>();
                }
                else
                {
                    ushort8 mul;
                    bminit_i8(divisor.x0, out mul.x0, _promises);
                    bminit_i8(divisor.x1, out mul.x1, _promises);
                    bminit_i8(divisor.x2, out mul.x2, _promises);
                    bminit_i8(divisor.x3, out mul.x3, _promises);
                    bminit_i8(divisor.x4, out mul.x4, _promises);
                    bminit_i8(divisor.x5, out mul.x5, _promises);
                    bminit_i8(divisor.x6, out mul.x6, _promises);
                    bminit_i8(divisor.x7, out mul.x7, _promises);

                    _bigM = mul.Reinterpret<ushort8, BigM>();
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(sbyte16 divisor, Promise promises = Promise.Nothing)
            : this(divisor.Reinterpret<sbyte16, T>(), promises, Signedness.Signed, sizeof(sbyte))
        {
#if DEBUG
_typeInfo = new TypeInfo(sizeof(sbyte), 16, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            if (_promises.SameValue)
            {
                bminit_i8(divisor.x0, out ushort mul, _promises);

                _bigM = ((ushort16)mul).Reinterpret<ushort16, BigM>();
            }
            else
            {
                if (Architecture.IsSIMDSupported)
                {
                    bminit_epi8(divisor, out v128 mulLo, out v128 mulHi, _promises);

                    _bigM = new ushort16((ushort8)mulLo, (ushort8)mulHi).Reinterpret<ushort16, BigM>();
                }
                else
                {
                    ushort16 mul = Uninitialized<ushort16>.Create();
                    bminit_i8(divisor.x0,  out mul.x0,  _promises);
                    bminit_i8(divisor.x1,  out mul.x1,  _promises);
                    bminit_i8(divisor.x2,  out mul.x2,  _promises);
                    bminit_i8(divisor.x3,  out mul.x3,  _promises);
                    bminit_i8(divisor.x4,  out mul.x4,  _promises);
                    bminit_i8(divisor.x5,  out mul.x5,  _promises);
                    bminit_i8(divisor.x6,  out mul.x6,  _promises);
                    bminit_i8(divisor.x7,  out mul.x7,  _promises);
                    bminit_i8(divisor.x8,  out mul.x8,  _promises);
                    bminit_i8(divisor.x9,  out mul.x9,  _promises);
                    bminit_i8(divisor.x10, out mul.x10, _promises);
                    bminit_i8(divisor.x11, out mul.x11, _promises);
                    bminit_i8(divisor.x12, out mul.x12, _promises);
                    bminit_i8(divisor.x13, out mul.x13, _promises);
                    bminit_i8(divisor.x14, out mul.x14, _promises);
                    bminit_i8(divisor.x15, out mul.x15, _promises);

                    _bigM = mul.Reinterpret<ushort16, BigM>();
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(sbyte32 divisor, Promise promises = Promise.Nothing)
            : this(divisor.Reinterpret<sbyte32, T>(), promises, Signedness.Signed, sizeof(sbyte))
        {
#if DEBUG
_typeInfo = new TypeInfo(sizeof(sbyte), 32, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            if (_promises.SameValue)
            {
                bminit_i8(divisor.x0, out ushort mul, _promises);

                _bigM._mulLo = ((ushort16)mul).Reinterpret<ushort16, T>();
                _bigM._mulHi = ((ushort16)mul).Reinterpret<ushort16, T>();
            }
            else
            {
                if (Avx2.IsAvx2Supported)
                {
                    mm256_bminit_epi8(divisor, out v256 mulLo, out v256 mulHi, _promises);

                    _bigM._mulLo = ((ushort16)mulLo).Reinterpret<ushort16, T>();
                    _bigM._mulHi = ((ushort16)mulHi).Reinterpret<ushort16, T>();
                }
                else if (Architecture.IsSIMDSupported)
                {
                    bminit_epi8(divisor.v16_0,  out v128 mul0, out v128 mul1, _promises);
                    bminit_epi8(divisor.v16_16, out v128 mul2, out v128 mul3, _promises);

                    _bigM._mulLo = new ushort16((ushort8)mul0, (ushort8)mul1).Reinterpret<ushort16, T>();
                    _bigM._mulHi = new ushort16((ushort8)mul2, (ushort8)mul3).Reinterpret<ushort16, T>();
                }
                else
                {
                    ushort16 mulLo = Uninitialized<ushort16>.Create();
                    ushort16 mulHi = Uninitialized<ushort16>.Create();
                    bminit_i8(divisor.x0,  out mulLo.x0,  _promises);
                    bminit_i8(divisor.x1,  out mulLo.x1,  _promises);
                    bminit_i8(divisor.x2,  out mulLo.x2,  _promises);
                    bminit_i8(divisor.x3,  out mulLo.x3,  _promises);
                    bminit_i8(divisor.x4,  out mulLo.x4,  _promises);
                    bminit_i8(divisor.x5,  out mulLo.x5,  _promises);
                    bminit_i8(divisor.x6,  out mulLo.x6,  _promises);
                    bminit_i8(divisor.x7,  out mulLo.x7,  _promises);
                    bminit_i8(divisor.x8,  out mulLo.x8,  _promises);
                    bminit_i8(divisor.x9,  out mulLo.x9,  _promises);
                    bminit_i8(divisor.x10, out mulLo.x10, _promises);
                    bminit_i8(divisor.x11, out mulLo.x11, _promises);
                    bminit_i8(divisor.x12, out mulLo.x12, _promises);
                    bminit_i8(divisor.x13, out mulLo.x13, _promises);
                    bminit_i8(divisor.x14, out mulLo.x14, _promises);
                    bminit_i8(divisor.x15, out mulLo.x15, _promises);
                    bminit_i8(divisor.x16, out mulHi.x0,  _promises);
                    bminit_i8(divisor.x17, out mulHi.x1,  _promises);
                    bminit_i8(divisor.x18, out mulHi.x2,  _promises);
                    bminit_i8(divisor.x19, out mulHi.x3,  _promises);
                    bminit_i8(divisor.x20, out mulHi.x4,  _promises);
                    bminit_i8(divisor.x21, out mulHi.x5,  _promises);
                    bminit_i8(divisor.x22, out mulHi.x6,  _promises);
                    bminit_i8(divisor.x23, out mulHi.x7,  _promises);
                    bminit_i8(divisor.x24, out mulHi.x8,  _promises);
                    bminit_i8(divisor.x25, out mulHi.x9,  _promises);
                    bminit_i8(divisor.x26, out mulHi.x10, _promises);
                    bminit_i8(divisor.x27, out mulHi.x11, _promises);
                    bminit_i8(divisor.x28, out mulHi.x12, _promises);
                    bminit_i8(divisor.x29, out mulHi.x13, _promises);
                    bminit_i8(divisor.x30, out mulHi.x14, _promises);
                    bminit_i8(divisor.x31, out mulHi.x15, _promises);

                    _bigM._mulLo = mulLo.Reinterpret<ushort16, T>();
                    _bigM._mulHi = mulHi.Reinterpret<ushort16, T>();
                }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(short divisor, Promise promises = Promise.Nothing)
            : this(divisor.Reinterpret<short, T>(), promises, Signedness.Signed, sizeof(short))
        {
#if DEBUG
_typeInfo = new TypeInfo(sizeof(short), 1, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            bminit_i16(divisor, out uint mul32, _promises);
            msinit_i16(divisor, out short mul, out short shift, _promises);

            _mulShift._mul = mul.Reinterpret<short, T>();
            _mulShift._shift = shift.Reinterpret<short, T>();
            _bigM = mul32.Reinterpret<uint, BigM>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(short2 divisor, Promise promises = Promise.Nothing)
            : this(divisor.Reinterpret<short2, T>(), promises, Signedness.Signed, sizeof(short))
        {
#if DEBUG
_typeInfo = new TypeInfo(sizeof(short), 2, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            if (_promises.SameValue)
            {
                bminit_i16(divisor.x, out uint mul32, _promises);
                msinit_i16(divisor.x, out short mul, out short shift, _promises);

                _mulShift._mul = ((short2)mul).Reinterpret<short2, T>();
                _mulShift._shift = ((short2)shift).Reinterpret<short2, T>();
                _bigM = ((uint2)mul32).Reinterpret<uint2, BigM>();
            }
            else
            {
                if (Architecture.IsSIMDSupported)
                {
                    bminit_epi16(divisor, out v128 mul32, _promises, 2);
                    msinit_epi16(divisor, out v128 mul, out v128 shift, _promises, 2);

                    _mulShift._mul = ((short2)mul).Reinterpret<short2, T>();
                    _mulShift._shift = ((short2)shift).Reinterpret<short2, T>();
                    _bigM = RegisterConversion.ToUInt2(mul32).Reinterpret<uint2, BigM>();
                }
                else
                {
                    short2 mul;
                    short2 shift;
                    uint2 mul32;
                    bminit_i16(divisor.x, out mul32.x, _promises);
                    bminit_i16(divisor.y, out mul32.y, _promises);
                    msinit_i16(divisor.x, out mul.x, out shift.x, _promises);
                    msinit_i16(divisor.y, out mul.y, out shift.y, _promises);

                    _mulShift._mul = mul.Reinterpret<short2, T>();
                    _mulShift._shift = shift.Reinterpret<short2, T>();
                    _bigM = mul32.Reinterpret<uint2, BigM>();
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(short3 divisor, Promise promises = Promise.Nothing)
            : this(divisor.Reinterpret<short3, T>(), promises, Signedness.Signed, sizeof(short))
        {
#if DEBUG
_typeInfo = new TypeInfo(sizeof(short), 3, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            if (_promises.SameValue)
            {
                bminit_i16(divisor.x, out uint mul32, _promises);
                msinit_i16(divisor.x, out short mul, out short shift, _promises);

                _mulShift._mul = ((short3)mul).Reinterpret<short3, T>();
                _mulShift._shift = ((short3)shift).Reinterpret<short3, T>();
                _bigM = ((uint3)mul32).Reinterpret<uint3, BigM>();
            }
            else
            {
                if (Architecture.IsSIMDSupported)
                {
                    bminit_epi16(divisor, out v128 mul32, _promises, 3);
                    msinit_epi16(divisor, out v128 mul, out v128 shift, _promises, 3);

                    _mulShift._mul = ((short3)mul).Reinterpret<short3, T>();
                    _mulShift._shift = ((short3)shift).Reinterpret<short3, T>();
                    _bigM = RegisterConversion.ToUInt3(mul32).Reinterpret<uint3, BigM>();
                }
                else
                {
                    short3 mul;
                    short3 shift;
                    uint3 mul32;
                    bminit_i16(divisor.x, out mul32.x, _promises);
                    bminit_i16(divisor.y, out mul32.y, _promises);
                    bminit_i16(divisor.z, out mul32.z, _promises);
                    msinit_i16(divisor.x, out mul.x, out shift.x, _promises);
                    msinit_i16(divisor.y, out mul.y, out shift.y, _promises);
                    msinit_i16(divisor.z, out mul.z, out shift.z, _promises);

                    _mulShift._mul = mul.Reinterpret<short3, T>();
                    _mulShift._shift = shift.Reinterpret<short3, T>();
                    _bigM = mul32.Reinterpret<uint3, BigM>();
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(short4 divisor, Promise promises = Promise.Nothing)
            : this(divisor.Reinterpret<short4, T>(), promises, Signedness.Signed, sizeof(short))
        {
#if DEBUG
_typeInfo = new TypeInfo(sizeof(short), 4, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            if (_promises.SameValue)
            {
                bminit_i16(divisor.x, out uint mul32, _promises);
                msinit_i16(divisor.x, out short mul, out short shift, _promises);

                _mulShift._mul = ((short4)mul).Reinterpret<short4, T>();
                _mulShift._shift = ((short4)shift).Reinterpret<short4, T>();
                _bigM = ((uint4)mul32).Reinterpret<uint4, BigM>();
            }
            else
            {
                if (Architecture.IsSIMDSupported)
                {
                    bminit_epi16(divisor, out v128 mul32, _promises, 4);
                    msinit_epi16(divisor, out v128 mul, out v128 shift, _promises, 4);

                    _mulShift._mul = ((short4)mul).Reinterpret<short4, T>();
                    _mulShift._shift = ((short4)shift).Reinterpret<short4, T>();
                    _bigM = RegisterConversion.ToUInt4(mul32).Reinterpret<uint4, BigM>();
                }
                else
                {
                    short4 mul;
                    short4 shift;
                    uint4 mul32;
                    bminit_i16(divisor.x, out mul32.x, _promises);
                    bminit_i16(divisor.y, out mul32.y, _promises);
                    bminit_i16(divisor.z, out mul32.z, _promises);
                    bminit_i16(divisor.w, out mul32.w, _promises);
                    msinit_i16(divisor.x, out mul.x, out shift.x, _promises);
                    msinit_i16(divisor.y, out mul.y, out shift.y, _promises);
                    msinit_i16(divisor.z, out mul.z, out shift.z, _promises);
                    msinit_i16(divisor.w, out mul.w, out shift.w, _promises);

                    _mulShift._mul = mul.Reinterpret<short4, T>();
                    _mulShift._shift = shift.Reinterpret<short4, T>();
                    _bigM = mul32.Reinterpret<uint4, BigM>();
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(short8 divisor, Promise promises = Promise.Nothing)
            : this(divisor.Reinterpret<short8, T>(), promises, Signedness.Signed, sizeof(short))
        {
#if DEBUG
_typeInfo = new TypeInfo(sizeof(short), 8, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            if (_promises.SameValue)
            {
                bminit_i16(divisor.x0, out uint mul32, _promises);
                msinit_i16(divisor.x0, out short mul, out short shift, _promises);

                _mulShift._mul = ((short8)mul).Reinterpret<short8, T>();
                _mulShift._shift = ((short8)shift).Reinterpret<short8, T>();
                _bigM = ((uint8)mul32).Reinterpret<uint8, BigM>();
            }
            else
            {
                if (Architecture.IsSIMDSupported)
                {
                    bminit_epi16(divisor, out v128 mulLo, out v128 mulHi, _promises);
                    msinit_epi16(divisor, out v128 mul, out v128 shift, _promises, 8);

                    _mulShift._mul = ((short8)mul).Reinterpret<short8, T>();
                    _mulShift._shift = ((short8)shift).Reinterpret<short8, T>();
                    _bigM = new uint8(RegisterConversion.ToUInt4(mulLo), RegisterConversion.ToUInt4(mulHi)).Reinterpret<uint8, BigM>();
                }
                else
                {
                    short8 mul;
                    short8 shift;
                    uint8 mul32 = Uninitialized<uint8>.Create();
                    bminit_i16(divisor.x0, out mul32.x0, _promises);
                    bminit_i16(divisor.x1, out mul32.x1, _promises);
                    bminit_i16(divisor.x2, out mul32.x2, _promises);
                    bminit_i16(divisor.x3, out mul32.x3, _promises);
                    bminit_i16(divisor.x4, out mul32.x4, _promises);
                    bminit_i16(divisor.x5, out mul32.x5, _promises);
                    bminit_i16(divisor.x6, out mul32.x6, _promises);
                    bminit_i16(divisor.x7, out mul32.x7, _promises);
                    msinit_i16(divisor.x0, out mul.x0, out shift.x0, _promises);
                    msinit_i16(divisor.x1, out mul.x1, out shift.x1, _promises);
                    msinit_i16(divisor.x2, out mul.x2, out shift.x2, _promises);
                    msinit_i16(divisor.x3, out mul.x3, out shift.x3, _promises);
                    msinit_i16(divisor.x4, out mul.x4, out shift.x4, _promises);
                    msinit_i16(divisor.x5, out mul.x5, out shift.x5, _promises);
                    msinit_i16(divisor.x6, out mul.x6, out shift.x6, _promises);
                    msinit_i16(divisor.x7, out mul.x7, out shift.x7, _promises);

                    _mulShift._mul = mul.Reinterpret<short8, T>();
                    _mulShift._shift = shift.Reinterpret<short8, T>();
                    _bigM = mul32.Reinterpret<uint8, BigM>();
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(short16 divisor, Promise promises = Promise.Nothing)
            : this(divisor.Reinterpret<short16, T>(), promises, Signedness.Signed, sizeof(short))
        {
#if DEBUG
_typeInfo = new TypeInfo(sizeof(short), 16, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            if (_promises.SameValue)
            {
                bminit_i16(divisor.x0, out uint mul32, _promises);
                msinit_i16(divisor.x0, out short mul, out short shift, _promises);

                _mulShift._mul = ((short16)mul).Reinterpret<short16, T>();
                _mulShift._shift = ((short16)shift).Reinterpret<short16, T>();
                _bigM._mulLo = ((uint8)mul32).Reinterpret<uint8, T>();
                _bigM._mulHi = ((uint8)mul32).Reinterpret<uint8, T>();
            }
            else
            {
                if (Avx2.IsAvx2Supported)
                {
                    mm256_bminit_epi16(divisor, out v256 mulLo, out v256 mulHi, _promises);
                    mm256_msinit_epi16(divisor, out v256 mul, out v256 shift, _promises);

                    _mulShift._mul = ((short16)mul).Reinterpret<short16, T>();
                    _mulShift._shift = ((short16)shift).Reinterpret<short16, T>();
                    _bigM._mulLo = ((uint8)mulLo).Reinterpret<uint8, T>();
                    _bigM._mulHi = ((uint8)mulHi).Reinterpret<uint8, T>();
                }
                else if (Architecture.IsSIMDSupported)
                {
                    bminit_epi16(divisor.v8_0, out v128 mul32_0, out v128 mul32_1, _promises);
                    bminit_epi16(divisor.v8_8, out v128 mul32_2, out v128 mul32_3, _promises);
                    msinit_epi16(divisor.v8_0, out v128 mulLo, out v128 shiftLo, _promises, 8);
                    msinit_epi16(divisor.v8_8, out v128 mulHi, out v128 shiftHi, _promises, 8);

                    _mulShift._mul = new short16(mulLo, mulHi).Reinterpret<short16, T>();
                    _mulShift._shift = new short16(shiftLo, shiftHi).Reinterpret<short16, T>();
                    _bigM._mulLo = new uint8(RegisterConversion.ToUInt4(mul32_0), RegisterConversion.ToUInt4(mul32_1)).Reinterpret<uint8, T>();
                    _bigM._mulHi = new uint8(RegisterConversion.ToUInt4(mul32_2), RegisterConversion.ToUInt4(mul32_3)).Reinterpret<uint8, T>();
                }
                else
                {
                    short16 mul = Uninitialized<short16>.Create();
                    short16 shift = Uninitialized<short16>.Create();
                    uint8 mul32Lo = Uninitialized<uint8>.Create();
                    uint8 mul32Hi = Uninitialized<uint8>.Create();
                    bminit_i16(divisor.x0,  out mul32Lo.x0, _promises);
                    bminit_i16(divisor.x1,  out mul32Lo.x1, _promises);
                    bminit_i16(divisor.x2,  out mul32Lo.x2, _promises);
                    bminit_i16(divisor.x3,  out mul32Lo.x3, _promises);
                    bminit_i16(divisor.x4,  out mul32Lo.x4, _promises);
                    bminit_i16(divisor.x5,  out mul32Lo.x5, _promises);
                    bminit_i16(divisor.x6,  out mul32Lo.x6, _promises);
                    bminit_i16(divisor.x7,  out mul32Lo.x7, _promises);
                    bminit_i16(divisor.x8,  out mul32Hi.x0, _promises);
                    bminit_i16(divisor.x9,  out mul32Hi.x1, _promises);
                    bminit_i16(divisor.x10, out mul32Hi.x2, _promises);
                    bminit_i16(divisor.x11, out mul32Hi.x3, _promises);
                    bminit_i16(divisor.x12, out mul32Hi.x4, _promises);
                    bminit_i16(divisor.x13, out mul32Hi.x5, _promises);
                    bminit_i16(divisor.x14, out mul32Hi.x6, _promises);
                    bminit_i16(divisor.x15, out mul32Hi.x7, _promises);
                    msinit_i16(divisor.x0,  out mul.x0,  out shift.x0,  _promises);
                    msinit_i16(divisor.x1,  out mul.x1,  out shift.x1,  _promises);
                    msinit_i16(divisor.x2,  out mul.x2,  out shift.x2,  _promises);
                    msinit_i16(divisor.x3,  out mul.x3,  out shift.x3,  _promises);
                    msinit_i16(divisor.x4,  out mul.x4,  out shift.x4,  _promises);
                    msinit_i16(divisor.x5,  out mul.x5,  out shift.x5,  _promises);
                    msinit_i16(divisor.x6,  out mul.x6,  out shift.x6,  _promises);
                    msinit_i16(divisor.x7,  out mul.x7,  out shift.x7,  _promises);
                    msinit_i16(divisor.x8,  out mul.x8,  out shift.x8,  _promises);
                    msinit_i16(divisor.x9,  out mul.x9,  out shift.x9,  _promises);
                    msinit_i16(divisor.x10, out mul.x10, out shift.x10, _promises);
                    msinit_i16(divisor.x11, out mul.x11, out shift.x11, _promises);
                    msinit_i16(divisor.x12, out mul.x12, out shift.x12, _promises);
                    msinit_i16(divisor.x13, out mul.x13, out shift.x13, _promises);
                    msinit_i16(divisor.x14, out mul.x14, out shift.x14, _promises);
                    msinit_i16(divisor.x15, out mul.x15, out shift.x15, _promises);

                    _mulShift._mul = mul.Reinterpret<short16, T>();
                    _mulShift._shift = shift.Reinterpret<short16, T>();
                    _bigM._mulLo = mul32Lo.Reinterpret<uint8, T>();
                    _bigM._mulHi = mul32Hi.Reinterpret<uint8, T>();
                }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(int divisor, Promise promises = Promise.Nothing)
            : this(divisor.Reinterpret<int, T>(), promises, Signedness.Signed, sizeof(int))
        {
#if DEBUG
_typeInfo = new TypeInfo(sizeof(int), 1, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            bminit_i32(divisor, out ulong mul64, _promises);
            msinit_i32(divisor, out int mul, out int shift, _promises);

            _mulShift._mul = mul.Reinterpret<int, T>();
            _mulShift._shift = shift.Reinterpret<int, T>();
            _bigM = mul64.Reinterpret<ulong, BigM>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(int2 divisor, Promise promises = Promise.Nothing)
            : this(divisor.Reinterpret<int2, T>(), promises, Signedness.Signed, sizeof(int))
        {
#if DEBUG
_typeInfo = new TypeInfo(sizeof(int), 2, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            if (_promises.SameValue)
            {
                bminit_i32(divisor.x, out ulong mul64, _promises);
                msinit_i32(divisor.x, out int mul, out int shift, _promises);

                _mulShift._mul = ((int2)mul).Reinterpret<int2, T>();
                _mulShift._shift = ((int2)shift).Reinterpret<int2, T>();
                _bigM = ((ulong2)mul64).Reinterpret<ulong2, BigM>();
            }
            else
            {
                if (Architecture.IsSIMDSupported)
                {
                    msinit_epi32(RegisterConversion.ToV128(divisor), out v128 mul, out v128 shift, _promises, 2);
                    bminit_epi32(RegisterConversion.ToV128(divisor), out v128 mul64, _promises);

                    _mulShift._mul = RegisterConversion.ToInt2(mul).Reinterpret<int2, T>();
                    _mulShift._shift = RegisterConversion.ToInt2(shift).Reinterpret<int2, T>();
                    _bigM = ((ulong2)mul64).Reinterpret<ulong2, BigM>();
                }
                else
                {
                    int2 mul;
                    int2 shift;
                    ulong2 mul64;
                    bminit_i32(divisor.x, out mul64.x, _promises);
                    bminit_i32(divisor.y, out mul64.y, _promises);
                    msinit_i32(divisor.x, out mul.x, out shift.x, _promises);
                    msinit_i32(divisor.y, out mul.y, out shift.y, _promises);

                    _mulShift._mul = mul.Reinterpret<int2, T>();
                    _mulShift._shift = shift.Reinterpret<int2, T>();
                    _bigM = mul64.Reinterpret<ulong2, BigM>();
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(int3 divisor, Promise promises = Promise.Nothing)
            : this(divisor.Reinterpret<int3, T>(), promises, Signedness.Signed, sizeof(int))
        {
#if DEBUG
_typeInfo = new TypeInfo(sizeof(int), 3, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            if (_promises.SameValue)
            {
                bminit_i32(divisor.x, out ulong mul64, _promises);
                msinit_i32(divisor.x, out int mul, out int shift, _promises);

                _mulShift._mul = ((int3)mul).Reinterpret<int3, T>();
                _mulShift._shift = ((int3)shift).Reinterpret<int3, T>();
                _bigM = ((ulong3)mul64).Reinterpret<ulong3, BigM>();
            }
            else
            {
                if (Architecture.IsSIMDSupported)
                {
                    msinit_epi32(RegisterConversion.ToV128(divisor), out v128 mul, out v128 shift, _promises, 3);
                    bminit_epi32(RegisterConversion.ToV128(divisor), out v128 mulLo, out v128 mulHi, _promises, 3);

                    _mulShift._mul = RegisterConversion.ToInt3(mul).Reinterpret<int3, T>();
                    _mulShift._shift = RegisterConversion.ToInt3(shift).Reinterpret<int3, T>();
                    _bigM = new ulong3(mulLo, mulHi.ULong0).Reinterpret<ulong3, BigM>();
                }
                else
                {
                    int3 mul;
                    int3 shift;
                    ulong3 mul64 = Uninitialized<ulong3>.Create();
                    bminit_i32(divisor.x, out mul64.x, _promises);
                    bminit_i32(divisor.y, out mul64.y, _promises);
                    bminit_i32(divisor.z, out mul64.z, _promises);
                    msinit_i32(divisor.x, out mul.x, out shift.x, _promises);
                    msinit_i32(divisor.y, out mul.y, out shift.y, _promises);
                    msinit_i32(divisor.z, out mul.z, out shift.z, _promises);

                    _mulShift._mul = mul.Reinterpret<int3, T>();
                    _mulShift._shift = shift.Reinterpret<int3, T>();
                    _bigM = mul64.Reinterpret<ulong3, BigM>();
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(int4 divisor, Promise promises = Promise.Nothing)
            : this(divisor.Reinterpret<int4, T>(), promises, Signedness.Signed, sizeof(int))
        {
#if DEBUG
_typeInfo = new TypeInfo(sizeof(int), 4, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            if (_promises.SameValue)
            {
                bminit_i32(divisor.x, out ulong mul64, _promises);
                msinit_i32(divisor.x, out int mul, out int shift, _promises);

                _mulShift._mul = ((int4)mul).Reinterpret<int4, T>();
                _mulShift._shift = ((int4)shift).Reinterpret<int4, T>();
                _bigM = ((ulong4)mul64).Reinterpret<ulong4, BigM>();
            }
            else
            {
                if (Architecture.IsSIMDSupported)
                {
                    msinit_epi32(RegisterConversion.ToV128(divisor), out v128 mul, out v128 shift, _promises, 4);
                    bminit_epi32(RegisterConversion.ToV128(divisor), out v128 mulLo, out v128 mulHi, _promises, 4);

                    _mulShift._mul = RegisterConversion.ToInt4(mul).Reinterpret<int4, T>();
                    _mulShift._shift = RegisterConversion.ToInt4(shift).Reinterpret<int4, T>();
                    _bigM = new ulong4(mulLo, mulHi).Reinterpret<ulong4, BigM>();
                }
                else
                {
                    int4 mul;
                    int4 shift;
                    ulong4 mul64 = Uninitialized<ulong4>.Create();
                    bminit_i32(divisor.x, out mul64.x, _promises);
                    bminit_i32(divisor.y, out mul64.y, _promises);
                    bminit_i32(divisor.z, out mul64.z, _promises);
                    bminit_i32(divisor.w, out mul64.w, _promises);
                    msinit_i32(divisor.x, out mul.x, out shift.x, _promises);
                    msinit_i32(divisor.y, out mul.y, out shift.y, _promises);
                    msinit_i32(divisor.z, out mul.z, out shift.z, _promises);
                    msinit_i32(divisor.w, out mul.w, out shift.w, _promises);

                    _mulShift._mul = mul.Reinterpret<int4, T>();
                    _mulShift._shift = shift.Reinterpret<int4, T>();
                    _bigM = mul64.Reinterpret<ulong4, BigM>();
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(int8 divisor, Promise promises = Promise.Nothing)
            : this(divisor.Reinterpret<int8, T>(), promises, Signedness.Signed, sizeof(int))
        {
#if DEBUG
_typeInfo = new TypeInfo(sizeof(int), 8, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            if (_promises.SameValue)
            {
                bminit_i32(divisor.x0, out ulong mul64, _promises);
                msinit_i32(divisor.x0, out int mul, out int shift, _promises);

                _mulShift._mul = ((int8)mul).Reinterpret<int8, T>();
                _mulShift._shift = ((int8)shift).Reinterpret<int8, T>();
                _bigM._mulLo = ((ulong4)mul64).Reinterpret<ulong4, T>();
                _bigM._mulHi = ((ulong4)mul64).Reinterpret<ulong4, T>();
            }
            else
            {
                if (Avx2.IsAvx2Supported)
                {
                    mm256_msinit_epi32(divisor, out v256 mul, out v256 shift, _promises);
                    mm256_bminit_epi32(divisor, out v256 mulLo, out v256 mulHi, _promises);

                    _mulShift._mul = ((int8)mul).Reinterpret<int8, T>();
                    _mulShift._shift = ((int8)shift).Reinterpret<int8, T>();
                    _bigM._mulLo = ((ulong4)mulLo).Reinterpret<ulong4, T>();
                    _bigM._mulHi = ((ulong4)mulHi).Reinterpret<ulong4, T>();
                }
                else if (Architecture.IsSIMDSupported)
                {
                    msinit_epi32(RegisterConversion.ToV128(divisor.v4_0), out v128 mulLo, out v128 shiftLo, _promises, 4);
                    msinit_epi32(RegisterConversion.ToV128(divisor.v4_4), out v128 mulHi, out v128 shiftHi, _promises, 4);
                    bminit_epi32(RegisterConversion.ToV128(divisor.v4_0), out v128 mul64_0, out v128 mul64_1, _promises, 4);
                    bminit_epi32(RegisterConversion.ToV128(divisor.v4_4), out v128 mul64_2, out v128 mul64_3, _promises, 4);

                    _mulShift._mul = new int8(RegisterConversion.ToInt4(mulLo), RegisterConversion.ToInt4(mulHi)).Reinterpret<int8, T>();
                    _mulShift._shift = new int8(RegisterConversion.ToInt4(shiftLo), RegisterConversion.ToInt4(shiftHi)).Reinterpret<int8, T>();
                    _bigM._mulLo = new ulong4(mul64_0, mul64_1).Reinterpret<ulong4, T>();
                    _bigM._mulHi = new ulong4(mul64_2, mul64_3).Reinterpret<ulong4, T>();
                }
                else
                {
                    int8 mul = Uninitialized<int8>.Create();
                    int8 shift = Uninitialized<int8>.Create();
                    ulong4 mul64Lo = Uninitialized<ulong4>.Create();
                    ulong4 mul64Hi = Uninitialized<ulong4>.Create();
                    bminit_i32(divisor.x0, out mul64Lo.x, _promises);
                    bminit_i32(divisor.x1, out mul64Lo.y, _promises);
                    bminit_i32(divisor.x2, out mul64Lo.z, _promises);
                    bminit_i32(divisor.x3, out mul64Lo.w, _promises);
                    bminit_i32(divisor.x4, out mul64Hi.x, _promises);
                    bminit_i32(divisor.x5, out mul64Hi.y, _promises);
                    bminit_i32(divisor.x6, out mul64Hi.z, _promises);
                    bminit_i32(divisor.x7, out mul64Hi.w, _promises);
                    msinit_i32(divisor.x0, out mul.x0, out shift.x0, _promises);
                    msinit_i32(divisor.x1, out mul.x1, out shift.x1, _promises);
                    msinit_i32(divisor.x2, out mul.x2, out shift.x2, _promises);
                    msinit_i32(divisor.x3, out mul.x3, out shift.x3, _promises);
                    msinit_i32(divisor.x4, out mul.x4, out shift.x4, _promises);
                    msinit_i32(divisor.x5, out mul.x5, out shift.x5, _promises);
                    msinit_i32(divisor.x6, out mul.x6, out shift.x6, _promises);
                    msinit_i32(divisor.x7, out mul.x7, out shift.x7, _promises);

                    _mulShift._mul = mul.Reinterpret<int8, T>();
                    _mulShift._shift = shift.Reinterpret<int8, T>();
                    _bigM._mulLo = mul64Lo.Reinterpret<ulong4, T>();
                    _bigM._mulHi = mul64Hi.Reinterpret<ulong4, T>();
                }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(long divisor, Promise promises = Promise.Nothing)
            : this(divisor.Reinterpret<long, T>(), promises, Signedness.Signed, sizeof(long))
        {
#if DEBUG
_typeInfo = new TypeInfo(sizeof(long), 1, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            msbminit_i64(divisor, out ulong mul, out ulong shift, out UInt128 mul128, _promises);

            _mulShift._mul = mul.Reinterpret<ulong, T>();
            _mulShift._shift = shift.Reinterpret<ulong, T>();
            _bigM = mul128.Reinterpret<UInt128, BigM>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(long2 divisor, Promise promises = Promise.Nothing)
            : this(divisor.Reinterpret<long2, T>(), promises, Signedness.Signed, sizeof(long))
        {
#if DEBUG
_typeInfo = new TypeInfo(sizeof(long), 2, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            if (_promises.SameValue)
            {
                msbminit_i64(divisor.x, out ulong mul, out ulong shift, out UInt128 mul128, _promises);

                _mulShift._mul = ((ulong2)mul).Reinterpret<ulong2, T>();
                _mulShift._shift = ((ulong2)shift).Reinterpret<ulong2, T>();
                _bigM._mulLo = mul128.Reinterpret<UInt128, T>();
                _bigM._mulHi = mul128.Reinterpret<UInt128, T>();
            }
            else
            {
                if (Architecture.IsSIMDSupported)
                {
                    msbminit_epi64(divisor, out v128 mul, out v128 shift, out UInt128 mul128Lo, out UInt128 mul128Hi, _promises);

                    _mulShift._mul = ((ulong2)mul).Reinterpret<ulong2, T>();
                    _mulShift._shift = ((ulong2)shift).Reinterpret<ulong2, T>();
                    _bigM._mulLo = mul128Lo.Reinterpret<UInt128, T>();
                    _bigM._mulHi = mul128Hi.Reinterpret<UInt128, T>();
                }
                else
                {
                    ulong2 mul;
                    ulong2 shift;

                    msbminit_i64(divisor.x, out mul.x, out shift.x, out UInt128 mul128Lo,
                                   divisor.y, out mul.y, out shift.y, out UInt128 mul128Hi,
                                   _promises);

                    _mulShift._mul = mul.Reinterpret<ulong2, T>();
                    _mulShift._shift = shift.Reinterpret<ulong2, T>();
                    _bigM._mulLo = mul128Lo.Reinterpret<UInt128, T>();
                    _bigM._mulHi = mul128Hi.Reinterpret<UInt128, T>();
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(long3 divisor, Promise promises = Promise.Nothing)
            : this(divisor.Reinterpret<long3, T>(), promises, Signedness.Signed, sizeof(long))
        {
#if DEBUG
_typeInfo = new TypeInfo(sizeof(long), 3, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            if (_promises.SameValue)
            {
                msbminit_i64(divisor.x, out ulong mul, out ulong shift, out UInt128 mul128, _promises);

                _mulShift._mul = ((ulong3)mul).Reinterpret<ulong3, T>();
                _mulShift._shift = ((ulong3)shift).Reinterpret<ulong3, T>();
                _bigM.SetField(mul128, 0);
                _bigM.SetField(mul128, 1);
                _bigM.SetField(mul128, 2);
            }
            else
            {
                if (Avx2.IsAvx2Supported)
                {
                    mm256_msbminit_epi64(divisor, out v256 mul, out v256 shift, out UInt128 mul128_0, out UInt128 mul128_1, out UInt128 mul128_2, out _, _promises, 3);

                    _mulShift._mul = ((ulong3)mul).Reinterpret<ulong3, T>();
                    _mulShift._shift = ((ulong3)shift).Reinterpret<ulong3, T>();
                    _bigM.SetField(mul128_0, 0);
                    _bigM.SetField(mul128_1, 1);
                    _bigM.SetField(mul128_2, 2);
                }
                else if (Architecture.IsSIMDSupported)
                {
                    msbminit_epi64(divisor.xy, out v128 mul, out v128 shift, out UInt128 mul128_0, out UInt128 mul128_1, _promises);
                    msbminit_i64(divisor.z, out ulong mulZ, out ulong shiftZ, out UInt128 mul128_2, _promises);

                    _mulShift._mul = new ulong3(mul, mulZ).Reinterpret<ulong3, T>();
                    _mulShift._shift = new ulong3(shift, shiftZ).Reinterpret<ulong3, T>();
                    _bigM.SetField(mul128_0, 0);
                    _bigM.SetField(mul128_1, 1);
                    _bigM.SetField(mul128_2, 2);
                }
                else
                {
                    ulong3 mul = Uninitialized<ulong3>.Create();
                    ulong3 shift = Uninitialized<ulong3>.Create();
                    msbminit_i64(divisor.x, out mul.x, out shift.x, out UInt128 mul128_0,
                                   divisor.y, out mul.y, out shift.y, out UInt128 mul128_1,
                                   divisor.z, out mul.z, out shift.z, out UInt128 mul128_2,
                                   _promises);

                    _mulShift._mul = mul.Reinterpret<ulong3, T>();
                    _mulShift._shift = shift.Reinterpret<ulong3, T>();
                    _bigM.SetField(mul128_0, 0);
                    _bigM.SetField(mul128_1, 1);
                    _bigM.SetField(mul128_2, 2);
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(long4 divisor, Promise promises = Promise.Nothing)
            : this(divisor.Reinterpret<long4, T>(), promises, Signedness.Signed, sizeof(long))
        {
#if DEBUG
_typeInfo = new TypeInfo(sizeof(long), 4, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            if (_promises.SameValue)
            {
                msbminit_i64(divisor.x, out ulong mul, out ulong shift, out UInt128 mul128, _promises);

                _mulShift._mul = ((ulong4)mul).Reinterpret<ulong4, T>();
                _mulShift._shift = ((ulong4)shift).Reinterpret<ulong4, T>();
                _bigM.SetField(mul128, 0);
                _bigM.SetField(mul128, 1);
                _bigM.SetField(mul128, 2);
                _bigM.SetField(mul128, 3);
            }
            else
            {
                if (Avx2.IsAvx2Supported)
                {
                    mm256_msbminit_epi64(divisor, out v256 mul, out v256 shift, out UInt128 mul128_0, out UInt128 mul128_1, out UInt128 mul128_2, out UInt128 mul128_3, _promises, 4);

                    _mulShift._mul = ((ulong4)mul).Reinterpret<ulong4, T>();
                    _mulShift._shift = ((ulong4)shift).Reinterpret<ulong4, T>();
                    _bigM.SetField(mul128_0, 0);
                    _bigM.SetField(mul128_1, 1);
                    _bigM.SetField(mul128_2, 2);
                    _bigM.SetField(mul128_3, 3);
                }
                else if (Architecture.IsSIMDSupported)
                {
                    msbminit_epi64(divisor.xy, out v128 mul, out v128 shift, out UInt128 mul128_0, out UInt128 mul128_1, _promises);
                    msbminit_epi64(divisor.zw, out v128 mulZW, out v128 shiftZW, out UInt128 mul128_2, out UInt128 mul128_3, _promises);

                    _mulShift._mul = new ulong4(mul, mulZW).Reinterpret<ulong4, T>();
                    _mulShift._shift = new ulong4(shift, shiftZW).Reinterpret<ulong4, T>();
                    _bigM.SetField(mul128_0, 0);
                    _bigM.SetField(mul128_1, 1);
                    _bigM.SetField(mul128_2, 2);
                    _bigM.SetField(mul128_3, 3);
                }
                else
                {
                    ulong4 mul = Uninitialized<ulong4>.Create();
                    ulong4 shift = Uninitialized<ulong4>.Create();
                    msbminit_i64(divisor.x, out mul.x, out shift.x, out UInt128 mul128_0,
                                   divisor.y, out mul.y, out shift.y, out UInt128 mul128_1,
                                   divisor.z, out mul.z, out shift.z, out UInt128 mul128_2,
                                   divisor.w, out mul.w, out shift.w, out UInt128 mul128_3,
                                   _promises);

                    _mulShift._mul = mul.Reinterpret<ulong4, T>();
                    _mulShift._shift = shift.Reinterpret<ulong4, T>();
                    _bigM.SetField(mul128_0, 0);
                    _bigM.SetField(mul128_1, 1);
                    _bigM.SetField(mul128_2, 2);
                    _bigM.SetField(mul128_3, 3);
                }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Int128 divisor, Promise promises = Promise.Nothing)
            : this(divisor.Reinterpret<Int128, T>(), promises, Signedness.Signed, (byte)sizeof(Int128))
        {
#if DEBUG
_typeInfo = new TypeInfo((byte)sizeof(Int128), 1, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            msbminit_i128(divisor, out UInt128 mul, out UInt128 shift, out __UInt256__ mulrem, _promises);

            _mulShift._mul = mul.Reinterpret<UInt128, T>();
            _mulShift._shift = shift.Reinterpret<UInt128, T>();
            _bigM = mulrem.Reinterpret<__UInt256__, BigM>();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void bminit_i8(sbyte d, out ushort mul, DividerPromise promises)
        {
            d = promise_abs_i8(d, promises);

            bminit_u8((byte)d, out mul);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void bminit_i16(short d, out uint mul, DividerPromise promises)
        {
            d = promise_abs_i16(d, promises);

            bminit_u16((ushort)d, out mul);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void msinit_i16(short d, [NoAlias] out short mul, [NoAlias] out short shift, DividerPromise promises)
        {
Assert.AreNotEqual(d, 0);

            d = promise_abs_i16(d, promises);

            if (promises.NotOne)
            {
                shift = (short)(15 - lzcnt((short)(d - 1)));
            }
            else
            {
                shift = (short)(16 - tobyte(d != 1) - lzcnt((short)(d - 1)));
            }
            mul = (short)(1 + (int)(((1u << 16) << shift) / (ushort)d));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void bminit_i32(int d, out ulong mul, DividerPromise promises)
        {
            d = promise_abs_i32(d, promises);

            mul = ulong.MaxValue / (uint)d + 1 + tobyte((d & (d - 1)) == 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void msinit_i32(int d, [NoAlias] out int mul, [NoAlias] out int shift, DividerPromise promises)
        {
Assert.AreNotEqual(d, 0);

            d = promise_abs_i32(d, promises);

            if (promises.NotOne)
            {
                shift = 31 - lzcnt(d - 1);
            }
            else
            {
                shift = 32 - tobyte(d != 1) - lzcnt(d - 1);
            }
            mul = 1 + (int)(((1ul << 32) << shift) / (uint)d);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void msbminit_i64(long d, [NoAlias] out ulong mul, [NoAlias] out ulong shift, [NoAlias] out UInt128 mul128, DividerPromise promises)
        {
Assert.AreNotEqual(d, 0L);

            d = promise_abs_i64(d, promises);

            if (promises.NotOne)
            {
                shift = (ulong)(63 - lzcnt(d - 1));
            }
            else
            {
                shift = (ulong)(64 - tobyte(d != 1) - lzcnt(d - 1));
            }
            mul128 = asm128.__spc__udivmax128x64_inc((ulong)d);
            mul = (promises.NotOne || d != 1) ? asm128.__usf__udiv128x64(new UInt128(0, 1ul << (int)shift), (ulong)d) : 0;

            mul++;
            mul128 = new UInt128(mul128.lo64 + tobyte((d & (d - 1)) == 0), mul128.hi64);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void msbminit_i64(long d0, [NoAlias] out ulong mul0, [NoAlias] out ulong shift0, [NoAlias] out UInt128 mul0_128,
                                          long d1, [NoAlias] out ulong mul1, [NoAlias] out ulong shift1, [NoAlias] out UInt128 mul1_128,
                                          DividerPromise promises)
        {
Assert.AreNotEqual(d0, 0L);
Assert.AreNotEqual(d1, 0L);

            d0 = promise_abs_i64(d0, promises);
            d1 = promise_abs_i64(d1, promises);

            if (promises.NotOne)
            {
                shift0 = (ulong)(63 - lzcnt(d0 - 1));
                shift1 = (ulong)(63 - lzcnt(d1 - 1));
            }
            else
            {
                shift0 = (ulong)(64 - tobyte(d0 != 1) - lzcnt(d0 - 1));
                shift1 = (ulong)(64 - tobyte(d1 != 1) - lzcnt(d1 - 1));
            }

            asm128.__spc__2xudivmax128x64_inc((ulong)d0, out mul0_128,
                                              (ulong)d1, out mul1_128);

            mul0 = 1 + ((promises.NotOne || d0 != 1) ? asm128.__usf__udiv128x64(new UInt128(0, 1ul << (int)shift0), (ulong)d0) : 0);
            mul1 = 1 + ((promises.NotOne || d1 != 1) ? asm128.__usf__udiv128x64(new UInt128(0, 1ul << (int)shift1), (ulong)d1) : 0);
            
            mul0_128 = new UInt128(mul0_128.lo64 + tobyte((d0 & (d0 - 1)) == 0), mul0_128.hi64);
            mul1_128 = new UInt128(mul1_128.lo64 + tobyte((d1 & (d1 - 1)) == 0), mul1_128.hi64);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void msbminit_i64(long d0, [NoAlias] out ulong mul0, [NoAlias] out ulong shift0, [NoAlias] out UInt128 mul0_128,
                                          long d1, [NoAlias] out ulong mul1, [NoAlias] out ulong shift1, [NoAlias] out UInt128 mul1_128,
                                          long d2, [NoAlias] out ulong mul2, [NoAlias] out ulong shift2, [NoAlias] out UInt128 mul2_128,
                                          DividerPromise promises)
        {
Assert.AreNotEqual(d0, 0L);
Assert.AreNotEqual(d1, 0L);
Assert.AreNotEqual(d2, 0L);

            d0 = promise_abs_i64(d0, promises);
            d1 = promise_abs_i64(d1, promises);
            d2 = promise_abs_i64(d2, promises);

            if (promises.NotOne)
            {
                shift0 = (ulong)(63 - lzcnt(d0 - 1));
                shift1 = (ulong)(63 - lzcnt(d1 - 1));
                shift2 = (ulong)(63 - lzcnt(d2 - 1));
            }
            else
            {
                shift0 = (ulong)(64 - tobyte(d0 != 1) - lzcnt(d0 - 1));
                shift1 = (ulong)(64 - tobyte(d1 != 1) - lzcnt(d1 - 1));
                shift2 = (ulong)(64 - tobyte(d2 != 1) - lzcnt(d2 - 1));
            }

            asm128.__spc__3xudivmax128x64_inc((ulong)d0, out mul0_128,
                                              (ulong)d1, out mul1_128,
                                              (ulong)d2, out mul2_128);

            mul0 = 1 + ((promises.NotOne || d0 != 1) ? asm128.__usf__udiv128x64(new UInt128(0, 1ul << (int)shift0), (ulong)d0) : 0);
            mul1 = 1 + ((promises.NotOne || d1 != 1) ? asm128.__usf__udiv128x64(new UInt128(0, 1ul << (int)shift1), (ulong)d1) : 0);
            mul2 = 1 + ((promises.NotOne || d2 != 1) ? asm128.__usf__udiv128x64(new UInt128(0, 1ul << (int)shift2), (ulong)d2) : 0);
            
            mul0_128 = new UInt128(mul0_128.lo64 + tobyte((d0 & (d0 - 1)) == 0), mul0_128.hi64);
            mul1_128 = new UInt128(mul1_128.lo64 + tobyte((d1 & (d1 - 1)) == 0), mul1_128.hi64);
            mul2_128 = new UInt128(mul2_128.lo64 + tobyte((d2 & (d2 - 1)) == 0), mul2_128.hi64);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void msbminit_i64(long d0, [NoAlias] out ulong mul0, [NoAlias] out ulong shift0, [NoAlias] out UInt128 mul0_128,
                                          long d1, [NoAlias] out ulong mul1, [NoAlias] out ulong shift1, [NoAlias] out UInt128 mul1_128,
                                          long d2, [NoAlias] out ulong mul2, [NoAlias] out ulong shift2, [NoAlias] out UInt128 mul2_128,
                                          long d3, [NoAlias] out ulong mul3, [NoAlias] out ulong shift3, [NoAlias] out UInt128 mul3_128,
                                          DividerPromise promises)
        {
Assert.AreNotEqual(d0, 0L);
Assert.AreNotEqual(d1, 0L);
Assert.AreNotEqual(d2, 0L);
Assert.AreNotEqual(d3, 0L);

            d0 = promise_abs_i64(d0, promises);
            d1 = promise_abs_i64(d1, promises);
            d2 = promise_abs_i64(d2, promises);
            d3 = promise_abs_i64(d3, promises);

            if (promises.NotOne)
            {
                shift0 = (ulong)(63 - lzcnt(d0 - 1));
                shift1 = (ulong)(63 - lzcnt(d1 - 1));
                shift2 = (ulong)(63 - lzcnt(d2 - 1));
                shift3 = (ulong)(63 - lzcnt(d3 - 1));
            }
            else
            {
                shift0 = (ulong)(64 - tobyte(d0 != 1) - lzcnt(d0 - 1));
                shift1 = (ulong)(64 - tobyte(d1 != 1) - lzcnt(d1 - 1));
                shift2 = (ulong)(64 - tobyte(d2 != 1) - lzcnt(d2 - 1));
                shift3 = (ulong)(64 - tobyte(d3 != 1) - lzcnt(d3 - 1));
            }

            asm128.__spc__4xudivmax128x64_inc((ulong)d0, out mul0_128,
                                              (ulong)d1, out mul1_128,
                                              (ulong)d2, out mul2_128,
                                              (ulong)d3, out mul3_128);

            mul0 = 1 + ((promises.NotOne || d0 != 1) ? asm128.__usf__udiv128x64(new UInt128(0, 1ul << (int)shift0), (ulong)d0) : 0);
            mul1 = 1 + ((promises.NotOne || d1 != 1) ? asm128.__usf__udiv128x64(new UInt128(0, 1ul << (int)shift1), (ulong)d1) : 0);
            mul2 = 1 + ((promises.NotOne || d2 != 1) ? asm128.__usf__udiv128x64(new UInt128(0, 1ul << (int)shift2), (ulong)d2) : 0);
            mul3 = 1 + ((promises.NotOne || d3 != 1) ? asm128.__usf__udiv128x64(new UInt128(0, 1ul << (int)shift3), (ulong)d3) : 0);
            
            mul0_128 = new UInt128(mul0_128.lo64 + tobyte((d0 & (d0 - 1)) == 0), mul0_128.hi64);
            mul1_128 = new UInt128(mul1_128.lo64 + tobyte((d1 & (d1 - 1)) == 0), mul1_128.hi64);
            mul2_128 = new UInt128(mul2_128.lo64 + tobyte((d2 & (d2 - 1)) == 0), mul2_128.hi64);
            mul3_128 = new UInt128(mul3_128.lo64 + tobyte((d3 & (d3 - 1)) == 0), mul3_128.hi64);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void msbminit_i128(Int128 d, [NoAlias] out UInt128 mul, [NoAlias] out UInt128 shift, [NoAlias] out __UInt256__ mulrem, DividerPromise promises)
        {
Assert.AreNotEqual(d, 0L);

            d = promise_abs_i128(d, promises);

            msbminit_u128((UInt128)d, out mul, out shift, out mulrem, promises);

            mulrem = new __UInt256__(new UInt128(mulrem.lo128.lo64 + tobyte((d & (d - 1)) == 0), mulrem.lo128.hi64), mulrem.hi128);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void bminit_epi8(v128 d, out v128 mul, DividerPromise promises, byte elements = 8)
        {
            if (Architecture.IsSIMDSupported)
            {
                d = promise_abs_epi8(d, promises, elements);

                bminit_epu8(d, out mul, promises, elements);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void bminit_epi16(v128 d, out v128 mul, DividerPromise promises, byte elements = 4)
        {
            if (Architecture.IsSIMDSupported)
            {
                d = promise_abs_epi16(d, promises, elements);

                bminit_epu16(d, out mul, elements);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void bminit_epi8(v128 d, [NoAlias] out v128 mulLo, [NoAlias] out v128 mulHi, DividerPromise promises)
        {
            if (Architecture.IsSIMDSupported)
            {
                d = promise_abs_epi8(d, promises);

                bminit_epu8(d, out mulLo, out mulHi, promises);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void bminit_epi16(v128 d, [NoAlias] out v128 mulLo, [NoAlias] out v128 mulHi, DividerPromise promises)
        {
            if (Architecture.IsSIMDSupported)
            {
                d = promise_abs_epi16(d, promises);

                bminit_epu16(d, out mulLo, out mulHi);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void msinit_epi32(v128 a, [NoAlias] out v128 mul, [NoAlias] out v128 shift, DividerPromise promises, byte elements = 4)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 ZERO = Xse.setzero_si128();
                v128 ONE = Xse.set1_epi32(1);
                v128 PRE_SHIFT = Xse.set1_epi64x(1L << 32);

                v128 __abs = promise_abs_epi32(a, promises, elements);

                if (promises.NotOne)
                {
                    shift = Xse.sub_epi32(Xse.set1_epi32(31), Xse.lzcnt_epi32(Xse.dec_epi32(__abs)));
                }
                else
                {
                    shift = Xse.sub_epi32(Xse.add_epi32(Xse.set1_epi32(32), Xse.not_si128(Xse.cmpeq_epi32(__abs, ONE))), Xse.lzcnt_epi32(Xse.dec_epi32(__abs)));
                }

                if (elements == 4)
                {
                    v128 shiftLo = Xse.cvt2x2epu32_epi64(shift, out v128 shiftHi);
                    v128 aLo = Xse.cvt2x2epu32_epi64(__abs, out v128 aHi);
                    v128 lo = Xse.impl_div_epu64(Xse.sllv_epi64(PRE_SHIFT, shiftLo, inRange: true), aLo, useFPU: true,  bLEu32max: true);
                    v128 hi = Xse.impl_div_epu64(Xse.sllv_epi64(PRE_SHIFT, shiftHi, inRange: true), aHi, useFPU: false, bLEu32max: true);
                    mul = Xse.inc_epi32(Xse.cvt2x2epi64_epi32(lo, hi));
                }
                else if (elements == 3)
                {
                    mul = Xse.impl_div_epu64(Xse.sllv_epi64(PRE_SHIFT, Xse.blend_epi16(shift, ZERO, 0b1100_1100), inRange: true), Xse.blend_epi16(__abs, ZERO, 0b1100_1100), true,  bLEu32max: true);
                    int mulY = (int)((PRE_SHIFT.ULong0 << (int)Xse.extract_epi32(shift, 1)) / Xse.extract_epi32(__abs, 1));
                    mul = Xse.inc_epi32(Xse.insert_epi32(mul, (uint)mulY, 1));
                }
                else
                {
                    mul = Xse.inc_epi32(Xse.cvtepi64_epi32(Xse.impl_div_epu64(Xse.sllv_epi64(PRE_SHIFT, Xse.cvtepu32_epi64(shift), inRange: true), Xse.cvtepu32_epi64(__abs), false)));
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void msbminit_epi64(v128 a, [NoAlias] out v128 mul, [NoAlias] out v128 shift, [NoAlias] out UInt128 mul128_0, [NoAlias] out UInt128 mul128_1, DividerPromise promises)
        {
            if (Architecture.IsSIMDSupported)
            {
VectorAssert.AreNotEqual<ulong2, ulong>(a, 0L, 2);

                v128 ONE = Xse.set1_epi64x(1);

                a = promise_abs_epi64(a, promises);

                ulong a0 = Xse.extract_epi64(a, 0);
                ulong a1 = Xse.extract_epi64(a, 1);

                int shiftLo;
                int shiftHi;
                if (promises.NotOne)
                {
                    shiftLo = 63 - lzcnt(a0 - 1);
                    shiftHi = 63 - lzcnt(a1 - 1);
                }
                else
                {
                    shiftLo = 64 - tobyte(a0 != 1) - lzcnt(a0 - 1);
                    shiftHi = 64 - tobyte(a1 != 1) - lzcnt(a1 - 1);
                }
                shift = Xse.unpacklo_epi64(Xse.cvtsi32_si128(shiftLo), Xse.cvtsi32_si128(shiftHi));

                if (Avx2.IsAvx2Supported)
                {
                    mul = Xse.add_epi64(ONE, Xse.impl_udivrem128_epu64(Xse.sllv_epi64(ONE, shift, inRange: true), a, out _, useFPU: true, unsafeRange: true));
                }
                else
                {
                    mul = Xse.add_epi64(ONE, Xse.impl_udivrem128_epu64(new v128(1ul << shiftLo, 1ul << shiftHi), a, out _, useFPU: true, unsafeRange: true));
                }

                asm128.__spc__2xudivmax128x64_inc(a0, out mul128_0,
                                                  a1, out mul128_1);

                v128 pow2Mask = Xse.cmpeq_epi64(Xse.setzero_si128(), Xse.and_si128(a, Xse.sub_epi64(a, ONE)));
                mul128_0 = new UInt128(mul128_0.lo64 - Xse.extract_epi64(pow2Mask, 0), mul128_0.hi64);
                mul128_1 = new UInt128(mul128_1.lo64 - Xse.extract_epi64(pow2Mask, 1), mul128_1.hi64);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void mm256_bminit_epi8(v256 d, [NoAlias] out v256 mulLo, [NoAlias] out v256 mulHi, DividerPromise promises)
        {
            if (Avx2.IsAvx2Supported)
            {
                d = mm256_promise_abs_epi8(d, promises);

                mm256_bminit_epu8(d, out mulLo, out mulHi, promises);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void mm256_bminit_epi16(v256 d, [NoAlias] out v256 mulLo, [NoAlias] out v256 mulHi, DividerPromise promises)
        {
            if (Avx2.IsAvx2Supported)
            {
                d = mm256_promise_abs_epi16(d, promises);

                mm256_bminit_epu16(d, out mulLo, out mulHi);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void bminit_epi32(v128 d, out v128 mul, DividerPromise promises)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 ZERO = Xse.setzero_si128();
                v128 MUL_64 = Xse.setall_si128();

                d = promise_abs_epi32(d, promises);

                d = Xse.cvtepu32_epi64(d);
                mul = Xse.impl_div_epu64(MUL_64, d, bLEu32max: true);
                mul = Xse.sub_epi64(mul, Xse.dec_epi64(Xse.cmpeq_epi64(ZERO, Xse.and_si128(d, Xse.dec_epi64(d)))));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void bminit_epi32(v128 d, [NoAlias] out v128 mulLo, [NoAlias] out v128 mulHi, DividerPromise promises, byte elements = 4)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 ZERO = Xse.setzero_si128();
                v128 MUL_64 = Xse.setall_si128();

                d = promise_abs_epi32(d, promises, elements);

                if (elements == 3)
                {
                    ulong z = Xse.extract_epi32(d, 2);
                    d = Xse.cvtepu32_epi64(d);

                    mulLo = Xse.impl_div_epu64(MUL_64, d, true, bLEu32max: true);
                    mulLo = Xse.sub_epi64(mulLo, Xse.dec_epi64(Xse.cmpeq_epi64(ZERO, Xse.and_si128(d, Xse.dec_epi64(d)))));
                    z = MUL_64.ULong0 / z + 1 + tobyte((z & (z - 1)) == 0);
                    mulHi = Xse.cvtsi64x_si128(z);

                }
                else
                {
                    v128 dLo = Xse.cvt2x2epu32_epi64(d, out v128 dHi);
                    mulLo = Xse.impl_div_epu64(MUL_64, dLo, true, bLEu32max: true);
                    mulHi = Xse.impl_div_epu64(MUL_64, dHi, false, bLEu32max: true);
                    mulLo = Xse.sub_epi64(mulLo, Xse.dec_epi64(Xse.cmpeq_epi64(ZERO, Xse.and_si128(dLo, Xse.dec_epi64(dLo)))));
                    mulHi = Xse.sub_epi64(mulHi, Xse.dec_epi64(Xse.cmpeq_epi64(ZERO, Xse.and_si128(dHi, Xse.dec_epi64(dHi)))));
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void mm256_bminit_epi32(v256 d, [NoAlias] out v256 mulLo, [NoAlias] out v256 mulHi, DividerPromise promises)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 ZERO = Avx.mm256_setzero_si256();
                v256 MUL_64 = Xse.mm256_setall_si256();

                d = mm256_promise_abs_epi32(d, promises);

                v256 dLo = Xse.mm256_cvt2x2epu32_epi64(d, out v256 dHi);
                v256 _mulLo = Xse.mm256_impl_div_epu64(MUL_64, dLo, bLEu32max: true);
                v256 _mulHi = Xse.mm256_impl_div_epu64(MUL_64, dHi, bLEu32max: true);
                _mulLo = Avx2.mm256_sub_epi64(_mulLo, Xse.mm256_dec_epi64(Avx2.mm256_cmpeq_epi64(ZERO, Avx2.mm256_and_si256(dLo, Xse.mm256_dec_epi64(dLo)))));
                _mulHi = Avx2.mm256_sub_epi64(_mulHi, Xse.mm256_dec_epi64(Avx2.mm256_cmpeq_epi64(ZERO, Avx2.mm256_and_si256(dHi, Xse.mm256_dec_epi64(dHi)))));

                mulLo = new v256(_mulLo.Lo128, _mulHi.Lo128);
                mulHi = new v256(_mulLo.Hi128, _mulHi.Hi128);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void msinit_epi16(v128 a, [NoAlias] out v128 mul, [NoAlias] out v128 shift, DividerPromise promises, byte elements = 8)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 ONE = Xse.set1_epi16(1);
                v128 PRE_SHIFT = Xse.set1_epi32(0x0001_0000);

                v128 __abs = promise_abs_epi16(a, promises, elements);

                if (promises.NotOne)
                {
                    shift = Xse.sub_epi16(Xse.set1_epi16(15), Xse.lzcnt_epi16(Xse.dec_epi16(__abs)));
                }
                else
                {
                    shift = Xse.sub_epi16(Xse.add_epi16(Xse.set1_epi16(16), Xse.not_si128(Xse.cmpeq_epi16(__abs, ONE))), Xse.lzcnt_epi16(Xse.dec_epi16(__abs)));
                }

                if (elements > 4)
                {
                    v128 shiftLo = Xse.cvt2x2epu16_epi32(shift, out v128 shiftHi);
                    v128 aLo = Xse.cvt2x2epu16_epi32(__abs, out v128 aHi);
                    v128 lo = Xse.impl_div_epu32(Xse.sllv_epi32(PRE_SHIFT, shiftLo, inRange: true), aLo, 4);
                    v128 hi = Xse.impl_div_epu32(Xse.sllv_epi32(PRE_SHIFT, shiftHi, inRange: true), aHi, 4);

                    if (Sse4_1.IsSse41Supported)
                    {
                        if (promises.NotOne)
                        {
                            mul = Xse.inc_epi16(Xse.packus_epi32(lo, hi));

                            return;
                        }
                    }

                    mul = Xse.inc_epi16(Xse.cvt2x2epi32_epi16(lo, hi));
                }
                else
                {
                    v128 q = Xse.impl_div_epu32(Xse.sllv_epi32(PRE_SHIFT, Xse.cvtepu16_epi32(shift), inRange: true), Xse.cvtepu16_epi32(__abs), elements);

                    if (Sse4_1.IsSse41Supported)
                    {
                        if (promises.NotOne)
                        {
                            mul = Xse.inc_epi16(Xse.packus_epi32(q, q));

                            return;
                        }
                    }

                    mul = Xse.inc_epi16(Xse.cvtepi32_epi16(q, elements));
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void mm256_msinit_epi16(v256 a, [NoAlias] out v256 mul, [NoAlias] out v256 shift, DividerPromise promises)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 ONE = Xse.mm256_set1_epi16(1);
                v256 PRE_SHIFT = Xse.mm256_set1_epi32(0x0001_0000);

                v256 __abs = mm256_promise_abs_epi16(a, promises);

                if (promises.NotOne)
                {
                    shift = Avx2.mm256_sub_epi16(Xse.mm256_set1_epi16(15), Xse.mm256_lzcnt_epi16(Xse.mm256_dec_epi16(__abs)));
                }
                else
                {
                    shift = Avx2.mm256_sub_epi16(Avx2.mm256_add_epi16(Xse.mm256_set1_epi16(16), Xse.mm256_not_si256(Avx2.mm256_cmpeq_epi16(__abs, ONE))), Xse.mm256_lzcnt_epi16(Xse.mm256_dec_epi16(__abs)));
                }

                v256 shiftLo = Xse.mm256_cvt2x2epu16_epi32(shift, out v256 shiftHi);
                v256 aLo = Xse.mm256_cvt2x2epu16_epi32(__abs, out v256 aHi);
                v256 lo = Xse.mm256_impl_div_epu32(Avx2.mm256_sllv_epi32(PRE_SHIFT, shiftLo), aLo);
                v256 hi = Xse.mm256_impl_div_epu32(Avx2.mm256_sllv_epi32(PRE_SHIFT, shiftHi), aHi);

                if (promises.NotOne)
                {
                    mul = Xse.mm256_inc_epi16(Avx2.mm256_packus_epi32(lo, hi));

                    return;
                }

                mul = Xse.mm256_inc_epi16(Xse.mm256_cvt2x2epi32_epi16(lo, hi));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void mm256_msinit_epi32(v256 a, [NoAlias] out v256 mul, [NoAlias] out v256 shift, DividerPromise promises)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 ONE = Xse.mm256_set1_epi32(1);
                v256 PRE_SHIFT = Xse.mm256_set1_epi64x(1L << 32);

                v256 __abs = mm256_promise_abs_epi32(a, promises);

                if (promises.NotOne)
                {
                    shift = Avx2.mm256_sub_epi32(Xse.mm256_set1_epi32(31), Xse.mm256_lzcnt_epi32(Xse.mm256_dec_epi32(__abs)));
                }
                else
                {
                    shift = Avx2.mm256_sub_epi32(Avx2.mm256_add_epi32(Xse.mm256_set1_epi32(32), Xse.mm256_not_si256(Avx2.mm256_cmpeq_epi32(__abs, ONE))), Xse.mm256_lzcnt_epi32(Xse.mm256_dec_epi32(__abs)));
                }

                v256 shiftLo = Xse.mm256_cvt2x2epu32_epi64(shift, out v256 shiftHi);
                v256 aLo = Xse.mm256_cvt2x2epu32_epi64(__abs, out v256 aHi);
                v256 lo = Xse.mm256_impl_div_epu64(Avx2.mm256_sllv_epi64(PRE_SHIFT, shiftLo), aLo, bLEu32max: true);
                v256 hi = Xse.mm256_impl_div_epu64(Avx2.mm256_sllv_epi64(PRE_SHIFT, shiftHi), aHi, bLEu32max: true);
                mul = Xse.mm256_inc_epi32(Xse.mm256_cvt2x2epi64_epi32(lo, hi));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void mm256_msbminit_epi64(v256 a, [NoAlias] out v256 mul, [NoAlias] out v256 shift, [NoAlias] out UInt128 mul128_0, [NoAlias] out UInt128 mul128_1, [NoAlias] out UInt128 mul128_2, [NoAlias] out UInt128 mul128_3, DividerPromise promises, byte elements = 4)
        {
VectorAssert.AreNotEqual<ulong4, ulong>(a, 0L, elements);

            if (Avx2.IsAvx2Supported)
            {
                v256 ONE = Xse.mm256_set1_epi64x(1);

                a = mm256_promise_abs_epi64(a, promises, elements);

                ulong a0 = Xse.mm256_extract_epi64(a, 0);
                ulong a1 = Xse.mm256_extract_epi64(a, 1);
                ulong a2 = Xse.mm256_extract_epi64(a, 2);

                if (promises.NotOne)
                {
                    shift = Avx2.mm256_sub_epi64(Xse.mm256_set1_epi64x(63), Xse.mm256_lzcnt_epi64(Xse.mm256_dec_epi64(a)));
                }
                else
                {
                    shift = Avx2.mm256_sub_epi64(Avx2.mm256_add_epi64(Xse.mm256_set1_epi64x(64), Xse.mm256_not_si256(Avx2.mm256_cmpeq_epi64(a, ONE))), Xse.mm256_lzcnt_epi64(Xse.mm256_dec_epi64(a)));
                }

                mul = Avx2.mm256_add_epi64(ONE, Xse.mm256_impl_udivrem128_epu64(Avx2.mm256_sllv_epi64(ONE, shift), a, out _, elements, unsafeRange: true));

                if (elements == 4)
                {
                    ulong a3 = Xse.mm256_extract_epi64(a, 3);

                    asm128.__spc__4xudivmax128x64_inc(a0, out mul128_0,
                                                      a1, out mul128_1,
                                                      a2, out mul128_2,
                                                      a3, out mul128_3);

                    v256 pow2Mask = Avx2.mm256_cmpeq_epi64(Avx.mm256_setzero_si256(), Avx2.mm256_and_si256(a, Avx2.mm256_sub_epi64(a, ONE)));
                    mul128_0 = new UInt128(mul128_0.lo64 - Xse.mm256_extract_epi64(pow2Mask, 0), mul128_0.hi64);
                    mul128_1 = new UInt128(mul128_1.lo64 - Xse.mm256_extract_epi64(pow2Mask, 1), mul128_1.hi64);
                    mul128_2 = new UInt128(mul128_2.lo64 - Xse.mm256_extract_epi64(pow2Mask, 2), mul128_2.hi64);
                    mul128_3 = new UInt128(mul128_3.lo64 - Xse.mm256_extract_epi64(pow2Mask, 3), mul128_3.hi64);
                }
                else
                {
                    mul128_3 = 0;

                    asm128.__spc__3xudivmax128x64_inc(a0, out mul128_0,
                                                      a1, out mul128_1,
                                                      a2, out mul128_2);

                    v256 pow2Mask = Avx2.mm256_cmpeq_epi64(Avx.mm256_setzero_si256(), Avx2.mm256_and_si256(a, Avx2.mm256_sub_epi64(a, ONE)));
                    mul128_0 = new UInt128(mul128_0.lo64 - Xse.mm256_extract_epi64(pow2Mask, 0), mul128_0.hi64);
                    mul128_1 = new UInt128(mul128_1.lo64 - Xse.mm256_extract_epi64(pow2Mask, 1), mul128_1.hi64);
                    mul128_2 = new UInt128(mul128_2.lo64 - Xse.mm256_extract_epi64(pow2Mask, 2), mul128_2.hi64);
                }
            }
            else throw new IllegalInstructionException();
        }
    }
}
