using System;
using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;
using static Unity.Mathematics.math;
using static MaxMath.maxmath;

namespace MaxMath
{
    unsafe public partial struct Divider<T>
        where T : unmanaged, IEquatable<T>, IFormattable
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T operator / (byte x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(byte), 1, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            switch (sizeof(T))
            {
                case 32 * sizeof(byte): return ((byte32)x / d).Reinterpret<byte32, T>();
                case 16 * sizeof(byte): return ((byte16)x / d).Reinterpret<byte16, T>();
                case  8 * sizeof(byte): return ((byte8) x / d).Reinterpret<byte8,  T>();
                case  4 * sizeof(byte): return ((byte4) x / d).Reinterpret<byte4,  T>();
                case  3 * sizeof(byte): return ((byte3) x / d).Reinterpret<byte3,  T>();
                case  2 * sizeof(byte): return ((byte2) x / d).Reinterpret<byte2,  T>();
                default:
                {
                    if (d._promises.Pow2)
                    {
                        return pow2_div_u8(x, *(byte*)&d._divisor).Reinterpret<byte, T>();
                    }
                    else
                    {
                        return bmdiv_u8(x, *(byte*)&d._divisor, *(ushort*)&d._bigM, d._promises).Reinterpret<byte, T>();
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 operator / (byte2 x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(byte), 2, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            if (d.DivideByScalar<byte2>())
            {
                if (d._promises.Pow2)
                {
                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return pow2_div_epu8_su8(x, *(byte*)&d._divisor, 2);
                    }
                    else
                    {
                        byte shift = *(byte*)&d._divisor;

                        return new byte2(pow2_div_u8(x.x, shift),
                                         pow2_div_u8(x.y, shift));
                    }
                }
                else
                {
                    byte divisor = *(byte*)&d._divisor;
                    ushort mul = *(ushort*)&d._bigM;

                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return bmdiv_epu8_su8(x, divisor, mul, d._promises, 2);
                    }
                    else
                    {
                        return new byte2(bmdiv_u8(x.x, divisor, mul, d._promises),
                                         bmdiv_u8(x.y, divisor, mul, d._promises));
                    }
                }
            }
            else
            {
                if (d._promises.Pow2)
                {
                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return pow2_div_epu8(x, d._divisor.Reinterpret<T, byte2>(), 2);
                    }
                    else
                    {
                        byte2 shift = d._divisor.Reinterpret<T, byte2>();

                        return new byte2(pow2_div_u8(x.x, shift.x),
                                         pow2_div_u8(x.y, shift.y));
                    }
                }
                else
                {
                    ushort2 mul = *(ushort2*)&d._bigM;
                    byte2 divisor = *(byte2*)&d._divisor;

                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return bmdiv_epu8(x, divisor, mul, d._promises, 2);
                    }
                    else
                    {
                        return new byte2(bmdiv_u8(x.x, divisor.x, mul.x, d._promises),
                                         bmdiv_u8(x.y, divisor.y, mul.y, d._promises));
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 operator / (byte3 x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(byte), 3, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            if (d.DivideByScalar<byte3>())
            {
                if (d._promises.Pow2)
                {
                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return pow2_div_epu8_su8(x, *(byte*)&d._divisor, 3);
                    }
                    else
                    {
                        byte shift = *(byte*)&d._divisor;

                        return new byte3(pow2_div_u8(x.x, shift),
                                         pow2_div_u8(x.y, shift),
                                         pow2_div_u8(x.z, shift));
                    }
                }
                else
                {
                    byte divisor = *(byte*)&d._divisor;
                    ushort mul = *(ushort*)&d._bigM;

                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return bmdiv_epu8_su8(x, divisor, mul, d._promises, 3);
                    }
                    else
                    {
                        return new byte3(bmdiv_u8(x.x, divisor, mul, d._promises),
                                         bmdiv_u8(x.y, divisor, mul, d._promises),
                                         bmdiv_u8(x.z, divisor, mul, d._promises));
                    }
                }
            }
            else
            {
                if (d._promises.Pow2)
                {
                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return pow2_div_epu8(x, d._divisor.Reinterpret<T, byte3>(), 3);
                    }
                    else
                    {
                        byte3 shift = d._divisor.Reinterpret<T, byte3>();

                        return new byte3(pow2_div_u8(x.x, shift.x),
                                         pow2_div_u8(x.y, shift.y),
                                         pow2_div_u8(x.z, shift.z));
                    }
                }
                else
                {
                    ushort3 mul = *(ushort3*)&d._bigM;
                    byte3 divisor = *(byte3*)&d._divisor;

                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return bmdiv_epu8(x, divisor, mul, d._promises, 3);
                    }
                    else
                    {
                        return new byte3(bmdiv_u8(x.x, divisor.x, mul.x, d._promises),
                                         bmdiv_u8(x.y, divisor.y, mul.y, d._promises),
                                         bmdiv_u8(x.z, divisor.z, mul.z, d._promises));
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 operator / (byte4 x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(byte), 4, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            if (d.DivideByScalar<byte4>())
            {
                if (d._promises.Pow2)
                {
                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return pow2_div_epu8_su8(x, *(byte*)&d._divisor, 4);
                    }
                    else
                    {
                        byte shift = *(byte*)&d._divisor;

                        return new byte4(pow2_div_u8(x.x, shift),
                                         pow2_div_u8(x.y, shift),
                                         pow2_div_u8(x.z, shift),
                                         pow2_div_u8(x.w, shift));
                    }
                }
                else
                {
                    byte divisor = *(byte*)&d._divisor;
                    ushort mul = *(ushort*)&d._bigM;

                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return bmdiv_epu8_su8(x, divisor, mul, d._promises, 4);
                    }
                    else
                    {
                        return new byte4(bmdiv_u8(x.x, divisor, mul, d._promises),
                                         bmdiv_u8(x.y, divisor, mul, d._promises),
                                         bmdiv_u8(x.z, divisor, mul, d._promises),
                                         bmdiv_u8(x.w, divisor, mul, d._promises));
                    }
                }
            }
            else
            {
                if (d._promises.Pow2)
                {
                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return pow2_div_epu8(x, d._divisor.Reinterpret<T, byte4>(), 4);
                    }
                    else
                    {
                        byte4 shift = d._divisor.Reinterpret<T, byte4>();

                        return new byte4(pow2_div_u8(x.x, shift.x),
                                         pow2_div_u8(x.y, shift.y),
                                         pow2_div_u8(x.z, shift.z),
                                         pow2_div_u8(x.w, shift.w));
                    }
                }
                else
                {
                    ushort4 mul = *(ushort4*)&d._bigM;
                    byte4 divisor = *(byte4*)&d._divisor;

                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return bmdiv_epu8(x, divisor, mul, d._promises, 4);
                    }
                    else
                    {
                        return new byte4(bmdiv_u8(x.x, divisor.x, mul.x, d._promises),
                                         bmdiv_u8(x.y, divisor.y, mul.y, d._promises),
                                         bmdiv_u8(x.z, divisor.z, mul.z, d._promises),
                                         bmdiv_u8(x.w, divisor.w, mul.w, d._promises));
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 operator / (byte8 x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(byte), 8, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            if (d.DivideByScalar<byte8>())
            {
                if (d._promises.Pow2)
                {
                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return pow2_div_epu8_su8(x, *(byte*)&d._divisor, 8);
                    }
                    else
                    {
                        byte shift = *(byte*)&d._divisor;

                        return new byte8(pow2_div_u8(x.x0, shift),
                                         pow2_div_u8(x.x1, shift),
                                         pow2_div_u8(x.x2, shift),
                                         pow2_div_u8(x.x3, shift),
                                         pow2_div_u8(x.x4, shift),
                                         pow2_div_u8(x.x5, shift),
                                         pow2_div_u8(x.x6, shift),
                                         pow2_div_u8(x.x7, shift));
                    }
                }
                else
                {
                    byte divisor = *(byte*)&d._divisor;
                    ushort mul = *(ushort*)&d._bigM;

                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return bmdiv_epu8_su8(x, divisor, mul, d._promises, 8);
                    }
                    else
                    {
                        return new byte8(bmdiv_u8(x.x0, divisor, mul, d._promises),
                                         bmdiv_u8(x.x1, divisor, mul, d._promises),
                                         bmdiv_u8(x.x2, divisor, mul, d._promises),
                                         bmdiv_u8(x.x3, divisor, mul, d._promises),
                                         bmdiv_u8(x.x4, divisor, mul, d._promises),
                                         bmdiv_u8(x.x5, divisor, mul, d._promises),
                                         bmdiv_u8(x.x6, divisor, mul, d._promises),
                                         bmdiv_u8(x.x7, divisor, mul, d._promises));
                    }
                }
            }
            else
            {
                if (d._promises.Pow2)
                {
                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return pow2_div_epu8(x, d._divisor.Reinterpret<T, byte8>(), 8);
                    }
                    else
                    {
                        byte8 shift = d._divisor.Reinterpret<T, byte8>();

                        return new byte8(pow2_div_u8(x.x0, shift.x0),
                                         pow2_div_u8(x.x1, shift.x1),
                                         pow2_div_u8(x.x2, shift.x2),
                                         pow2_div_u8(x.x3, shift.x3),
                                         pow2_div_u8(x.x4, shift.x4),
                                         pow2_div_u8(x.x5, shift.x5),
                                         pow2_div_u8(x.x6, shift.x6),
                                         pow2_div_u8(x.x7, shift.x7));
                    }
                }
                else
                {
                    ushort8 mul = *(ushort8*)&d._bigM;
                    byte8 divisor = *(byte8*)&d._divisor;

                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return bmdiv_epu8(x, divisor, mul, d._promises, 8);
                    }
                    else
                    {
                        return new byte8(bmdiv_u8(x.x0, divisor.x0, mul.x0, d._promises),
                                         bmdiv_u8(x.x1, divisor.x1, mul.x1, d._promises),
                                         bmdiv_u8(x.x2, divisor.x2, mul.x2, d._promises),
                                         bmdiv_u8(x.x3, divisor.x3, mul.x3, d._promises),
                                         bmdiv_u8(x.x4, divisor.x4, mul.x4, d._promises),
                                         bmdiv_u8(x.x5, divisor.x5, mul.x5, d._promises),
                                         bmdiv_u8(x.x6, divisor.x6, mul.x6, d._promises),
                                         bmdiv_u8(x.x7, divisor.x7, mul.x7, d._promises));
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 operator / (byte16 x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(byte), 16, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            if (d.DivideByScalar<byte16>())
            {
                if (d._promises.Pow2)
                {
                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return pow2_div_epu8_su8(x, *(byte*)&d._divisor, 16);
                    }
                    else
                    {
                        byte shift = *(byte*)&d._divisor;

                        return new byte16(pow2_div_u8(x.x0,  shift),
                                          pow2_div_u8(x.x1,  shift),
                                          pow2_div_u8(x.x2,  shift),
                                          pow2_div_u8(x.x3,  shift),
                                          pow2_div_u8(x.x4,  shift),
                                          pow2_div_u8(x.x5,  shift),
                                          pow2_div_u8(x.x6,  shift),
                                          pow2_div_u8(x.x7,  shift),
                                          pow2_div_u8(x.x8,  shift),
                                          pow2_div_u8(x.x9,  shift),
                                          pow2_div_u8(x.x10, shift),
                                          pow2_div_u8(x.x11, shift),
                                          pow2_div_u8(x.x12, shift),
                                          pow2_div_u8(x.x13, shift),
                                          pow2_div_u8(x.x14, shift),
                                          pow2_div_u8(x.x15, shift));
                    }
                }
                else
                {
                    byte divisor = *(byte*)&d._divisor;
                    ushort mul = *(ushort*)&d._bigM;

                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return bmdiv_epu8_su8(x, divisor, mul, d._promises, 16);
                    }
                    else
                    {
                        return new byte16(bmdiv_u8(x.x0,  divisor, mul, d._promises),
                                          bmdiv_u8(x.x1,  divisor, mul, d._promises),
                                          bmdiv_u8(x.x2,  divisor, mul, d._promises),
                                          bmdiv_u8(x.x3,  divisor, mul, d._promises),
                                          bmdiv_u8(x.x4,  divisor, mul, d._promises),
                                          bmdiv_u8(x.x5,  divisor, mul, d._promises),
                                          bmdiv_u8(x.x6,  divisor, mul, d._promises),
                                          bmdiv_u8(x.x7,  divisor, mul, d._promises),
                                          bmdiv_u8(x.x8,  divisor, mul, d._promises),
                                          bmdiv_u8(x.x9,  divisor, mul, d._promises),
                                          bmdiv_u8(x.x10, divisor, mul, d._promises),
                                          bmdiv_u8(x.x11, divisor, mul, d._promises),
                                          bmdiv_u8(x.x12, divisor, mul, d._promises),
                                          bmdiv_u8(x.x13, divisor, mul, d._promises),
                                          bmdiv_u8(x.x14, divisor, mul, d._promises),
                                          bmdiv_u8(x.x15, divisor, mul, d._promises));
                    }
                }
            }
            else
            {
                if (d._promises.Pow2)
                {
                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return pow2_div_epu8(x, d._divisor.Reinterpret<T, byte16>(), 16);
                    }
                    else
                    {
                        byte16 shift = d._divisor.Reinterpret<T, byte16>();

                        return new byte16(pow2_div_u8(x.x0,  shift.x0),
                                          pow2_div_u8(x.x1,  shift.x1),
                                          pow2_div_u8(x.x2,  shift.x2),
                                          pow2_div_u8(x.x3,  shift.x3),
                                          pow2_div_u8(x.x4,  shift.x4),
                                          pow2_div_u8(x.x5,  shift.x5),
                                          pow2_div_u8(x.x6,  shift.x6),
                                          pow2_div_u8(x.x7,  shift.x7),
                                          pow2_div_u8(x.x8,  shift.x8),
                                          pow2_div_u8(x.x9,  shift.x9),
                                          pow2_div_u8(x.x10, shift.x10),
                                          pow2_div_u8(x.x11, shift.x11),
                                          pow2_div_u8(x.x12, shift.x12),
                                          pow2_div_u8(x.x13, shift.x13),
                                          pow2_div_u8(x.x14, shift.x14),
                                          pow2_div_u8(x.x15, shift.x15));
                    }
                }
                else
                {
                    ushort8 mulLo = *(ushort8*)&d._bigM._mulLo;
                    ushort8 mulHi = *(ushort8*)&d._bigM._mulHi;
                    byte16 divisor = *(byte16*)&d._divisor;

                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return bmdiv_epu8(x, divisor, mulLo, mulHi, d._promises);
                    }
                    else
                    {
                        return new byte16(bmdiv_u8(x.x0,  divisor.x0,  mulLo.x0, d._promises),
                                          bmdiv_u8(x.x1,  divisor.x1,  mulLo.x1, d._promises),
                                          bmdiv_u8(x.x2,  divisor.x2,  mulLo.x2, d._promises),
                                          bmdiv_u8(x.x3,  divisor.x3,  mulLo.x3, d._promises),
                                          bmdiv_u8(x.x4,  divisor.x4,  mulLo.x4, d._promises),
                                          bmdiv_u8(x.x5,  divisor.x5,  mulLo.x5, d._promises),
                                          bmdiv_u8(x.x6,  divisor.x6,  mulLo.x6, d._promises),
                                          bmdiv_u8(x.x7,  divisor.x7,  mulLo.x7, d._promises),
                                          bmdiv_u8(x.x8,  divisor.x8,  mulHi.x0, d._promises),
                                          bmdiv_u8(x.x9,  divisor.x9,  mulHi.x1, d._promises),
                                          bmdiv_u8(x.x10, divisor.x10, mulHi.x2, d._promises),
                                          bmdiv_u8(x.x11, divisor.x11, mulHi.x3, d._promises),
                                          bmdiv_u8(x.x12, divisor.x12, mulHi.x4, d._promises),
                                          bmdiv_u8(x.x13, divisor.x13, mulHi.x5, d._promises),
                                          bmdiv_u8(x.x14, divisor.x14, mulHi.x6, d._promises),
                                          bmdiv_u8(x.x15, divisor.x15, mulHi.x7, d._promises));
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 operator / (byte32 x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(byte), 32, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            if (d.DivideByScalar<byte32>())
            {
                if (d._promises.Pow2)
                {
                    byte divisor = *(byte*)&d._divisor;

                    if (Avx2.IsAvx2Supported)
                    {
                        return mm256_pow2_div_epu8_su8(x, divisor);
                    }
                    else if (BurstArchitecture.IsSIMDSupported)
                    {
                        return new byte32(pow2_div_epu8_su8(x.v16_0, divisor, 16), pow2_div_epu8_su8(x.v16_16, divisor, 16));
                    }
                    else
                    {
                        return new byte32(pow2_div_u8(x.x0,  divisor),
                                          pow2_div_u8(x.x1,  divisor),
                                          pow2_div_u8(x.x2,  divisor),
                                          pow2_div_u8(x.x3,  divisor),
                                          pow2_div_u8(x.x4,  divisor),
                                          pow2_div_u8(x.x5,  divisor),
                                          pow2_div_u8(x.x6,  divisor),
                                          pow2_div_u8(x.x7,  divisor),
                                          pow2_div_u8(x.x8,  divisor),
                                          pow2_div_u8(x.x9,  divisor),
                                          pow2_div_u8(x.x10, divisor),
                                          pow2_div_u8(x.x11, divisor),
                                          pow2_div_u8(x.x12, divisor),
                                          pow2_div_u8(x.x13, divisor),
                                          pow2_div_u8(x.x14, divisor),
                                          pow2_div_u8(x.x15, divisor),
                                          pow2_div_u8(x.x16, divisor),
                                          pow2_div_u8(x.x17, divisor),
                                          pow2_div_u8(x.x18, divisor),
                                          pow2_div_u8(x.x19, divisor),
                                          pow2_div_u8(x.x20, divisor),
                                          pow2_div_u8(x.x21, divisor),
                                          pow2_div_u8(x.x22, divisor),
                                          pow2_div_u8(x.x23, divisor),
                                          pow2_div_u8(x.x24, divisor),
                                          pow2_div_u8(x.x25, divisor),
                                          pow2_div_u8(x.x26, divisor),
                                          pow2_div_u8(x.x27, divisor),
                                          pow2_div_u8(x.x28, divisor),
                                          pow2_div_u8(x.x29, divisor),
                                          pow2_div_u8(x.x30, divisor),
                                          pow2_div_u8(x.x31, divisor));
                    }
                }
                else
                {
                    byte divisor = *(byte*)&d._divisor;
                    ushort mul = *(ushort*)&d._bigM;

                    if (Avx2.IsAvx2Supported)
                    {
                        return mm256_bmdiv_epu8_su8(x, divisor, mul, d._promises);

                    }
                    else if (BurstArchitecture.IsSIMDSupported)
                    {
                        return new byte32(bmdiv_epu8_su8(x.v16_0,  divisor, mul, d._promises),
                                          bmdiv_epu8_su8(x.v16_16, divisor, mul, d._promises));
                    }
                    else
                    {
                        return new byte32(bmdiv_u8(x.x0,  divisor, mul, d._promises),
                                          bmdiv_u8(x.x1,  divisor, mul, d._promises),
                                          bmdiv_u8(x.x2,  divisor, mul, d._promises),
                                          bmdiv_u8(x.x3,  divisor, mul, d._promises),
                                          bmdiv_u8(x.x4,  divisor, mul, d._promises),
                                          bmdiv_u8(x.x5,  divisor, mul, d._promises),
                                          bmdiv_u8(x.x6,  divisor, mul, d._promises),
                                          bmdiv_u8(x.x7,  divisor, mul, d._promises),
                                          bmdiv_u8(x.x8,  divisor, mul, d._promises),
                                          bmdiv_u8(x.x9,  divisor, mul, d._promises),
                                          bmdiv_u8(x.x10, divisor, mul, d._promises),
                                          bmdiv_u8(x.x11, divisor, mul, d._promises),
                                          bmdiv_u8(x.x12, divisor, mul, d._promises),
                                          bmdiv_u8(x.x13, divisor, mul, d._promises),
                                          bmdiv_u8(x.x14, divisor, mul, d._promises),
                                          bmdiv_u8(x.x15, divisor, mul, d._promises),
                                          bmdiv_u8(x.x16, divisor, mul, d._promises),
                                          bmdiv_u8(x.x17, divisor, mul, d._promises),
                                          bmdiv_u8(x.x18, divisor, mul, d._promises),
                                          bmdiv_u8(x.x19, divisor, mul, d._promises),
                                          bmdiv_u8(x.x20, divisor, mul, d._promises),
                                          bmdiv_u8(x.x21, divisor, mul, d._promises),
                                          bmdiv_u8(x.x22, divisor, mul, d._promises),
                                          bmdiv_u8(x.x23, divisor, mul, d._promises),
                                          bmdiv_u8(x.x24, divisor, mul, d._promises),
                                          bmdiv_u8(x.x25, divisor, mul, d._promises),
                                          bmdiv_u8(x.x26, divisor, mul, d._promises),
                                          bmdiv_u8(x.x27, divisor, mul, d._promises),
                                          bmdiv_u8(x.x28, divisor, mul, d._promises),
                                          bmdiv_u8(x.x29, divisor, mul, d._promises),
                                          bmdiv_u8(x.x30, divisor, mul, d._promises),
                                          bmdiv_u8(x.x31, divisor, mul, d._promises));
                    }
                }
            }
            else
            {
                if (d._promises.Pow2)
                {
                    byte32 divisor = d._divisor.Reinterpret<T, byte32>();

                    if (Avx2.IsAvx2Supported)
                    {
                        return mm256_pow2_div_epu8(x, divisor);
                    }
                    else if (BurstArchitecture.IsSIMDSupported)
                    {
                        return new byte32(pow2_div_epu8(x.v16_0, divisor.v16_0, 16), pow2_div_epu8(x.v16_16, divisor.v16_16, 16));
                    }
                    else
                    {
                        return new byte32(pow2_div_u8(x.x0,  divisor.x0),
                                          pow2_div_u8(x.x1,  divisor.x1),
                                          pow2_div_u8(x.x2,  divisor.x2),
                                          pow2_div_u8(x.x3,  divisor.x3),
                                          pow2_div_u8(x.x4,  divisor.x4),
                                          pow2_div_u8(x.x5,  divisor.x5),
                                          pow2_div_u8(x.x6,  divisor.x6),
                                          pow2_div_u8(x.x7,  divisor.x7),
                                          pow2_div_u8(x.x8,  divisor.x8),
                                          pow2_div_u8(x.x9,  divisor.x9),
                                          pow2_div_u8(x.x10, divisor.x10),
                                          pow2_div_u8(x.x11, divisor.x11),
                                          pow2_div_u8(x.x12, divisor.x12),
                                          pow2_div_u8(x.x13, divisor.x13),
                                          pow2_div_u8(x.x14, divisor.x14),
                                          pow2_div_u8(x.x15, divisor.x15),
                                          pow2_div_u8(x.x16, divisor.x16),
                                          pow2_div_u8(x.x17, divisor.x17),
                                          pow2_div_u8(x.x18, divisor.x18),
                                          pow2_div_u8(x.x19, divisor.x19),
                                          pow2_div_u8(x.x20, divisor.x20),
                                          pow2_div_u8(x.x21, divisor.x21),
                                          pow2_div_u8(x.x22, divisor.x22),
                                          pow2_div_u8(x.x23, divisor.x23),
                                          pow2_div_u8(x.x24, divisor.x24),
                                          pow2_div_u8(x.x25, divisor.x25),
                                          pow2_div_u8(x.x26, divisor.x26),
                                          pow2_div_u8(x.x27, divisor.x27),
                                          pow2_div_u8(x.x28, divisor.x28),
                                          pow2_div_u8(x.x29, divisor.x29),
                                          pow2_div_u8(x.x30, divisor.x30),
                                          pow2_div_u8(x.x31, divisor.x31));
                    }
                }
                else
                {
                    ushort16 mulLo = *(ushort16*)&d._bigM._mulLo;
                    ushort16 mulHi = *(ushort16*)&d._bigM._mulHi;
                    byte32 divisor = *(byte32*)&d._divisor;

                    if (Avx2.IsAvx2Supported)
                    {
                        return mm256_bmdiv_epu8(x, divisor, mulLo, mulHi, d._promises);
                    }
                    else if (BurstArchitecture.IsSIMDSupported)
                    {
                        return new byte32(bmdiv_epu8(x.v16_0,  divisor.v16_0,  mulLo.v8_0, mulLo.v8_8, d._promises),
                                          bmdiv_epu8(x.v16_16, divisor.v16_16, mulHi.v8_0, mulHi.v8_8, d._promises));
                    }
                    else
                    {
                        return new byte32(bmdiv_u8(x.x0,  divisor.x0,  mulLo.x0,  d._promises),
                                          bmdiv_u8(x.x1,  divisor.x1,  mulLo.x1,  d._promises),
                                          bmdiv_u8(x.x2,  divisor.x2,  mulLo.x2,  d._promises),
                                          bmdiv_u8(x.x3,  divisor.x3,  mulLo.x3,  d._promises),
                                          bmdiv_u8(x.x4,  divisor.x4,  mulLo.x4,  d._promises),
                                          bmdiv_u8(x.x5,  divisor.x5,  mulLo.x5,  d._promises),
                                          bmdiv_u8(x.x6,  divisor.x6,  mulLo.x6,  d._promises),
                                          bmdiv_u8(x.x7,  divisor.x7,  mulLo.x7,  d._promises),
                                          bmdiv_u8(x.x8,  divisor.x8,  mulLo.x8,  d._promises),
                                          bmdiv_u8(x.x9,  divisor.x9,  mulLo.x9,  d._promises),
                                          bmdiv_u8(x.x10, divisor.x10, mulLo.x10, d._promises),
                                          bmdiv_u8(x.x11, divisor.x11, mulLo.x11, d._promises),
                                          bmdiv_u8(x.x12, divisor.x12, mulLo.x12, d._promises),
                                          bmdiv_u8(x.x13, divisor.x13, mulLo.x13, d._promises),
                                          bmdiv_u8(x.x14, divisor.x14, mulLo.x14, d._promises),
                                          bmdiv_u8(x.x15, divisor.x15, mulLo.x15, d._promises),
                                          bmdiv_u8(x.x16, divisor.x16, mulHi.x0,  d._promises),
                                          bmdiv_u8(x.x17, divisor.x17, mulHi.x1,  d._promises),
                                          bmdiv_u8(x.x18, divisor.x18, mulHi.x2,  d._promises),
                                          bmdiv_u8(x.x19, divisor.x19, mulHi.x3,  d._promises),
                                          bmdiv_u8(x.x20, divisor.x20, mulHi.x4,  d._promises),
                                          bmdiv_u8(x.x21, divisor.x21, mulHi.x5,  d._promises),
                                          bmdiv_u8(x.x22, divisor.x22, mulHi.x6,  d._promises),
                                          bmdiv_u8(x.x23, divisor.x23, mulHi.x7,  d._promises),
                                          bmdiv_u8(x.x24, divisor.x24, mulHi.x8,  d._promises),
                                          bmdiv_u8(x.x25, divisor.x25, mulHi.x9,  d._promises),
                                          bmdiv_u8(x.x26, divisor.x26, mulHi.x10, d._promises),
                                          bmdiv_u8(x.x27, divisor.x27, mulHi.x11, d._promises),
                                          bmdiv_u8(x.x28, divisor.x28, mulHi.x12, d._promises),
                                          bmdiv_u8(x.x29, divisor.x29, mulHi.x13, d._promises),
                                          bmdiv_u8(x.x30, divisor.x30, mulHi.x14, d._promises),
                                          bmdiv_u8(x.x31, divisor.x31, mulHi.x15, d._promises));
                    }
                }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T operator / (ushort x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(ushort), 1, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            switch (sizeof(T))
            {
                case 16 * sizeof(ushort): return ((ushort16)x / d).Reinterpret<ushort16, T>();
                case  8 * sizeof(ushort): return ((ushort8) x / d).Reinterpret<ushort8,  T>();
                case  4 * sizeof(ushort): return ((ushort4) x / d).Reinterpret<ushort4,  T>();
                case  3 * sizeof(ushort): return ((ushort3) x / d).Reinterpret<ushort3,  T>();
                case  2 * sizeof(ushort): return ((ushort2) x / d).Reinterpret<ushort2,  T>();
                default:
                {
                    if (d._promises.Pow2)
                    {
                        return pow2_div_u16(x, *(ushort*)&d._divisor).Reinterpret<ushort, T>();
                    }
                    else
                    {
                        return bmdiv_u16(x, *(ushort*)&d._divisor, *(uint*)&d._bigM, d._promises).Reinterpret<ushort, T>();
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator / (ushort2 x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(ushort), 2, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            if (d.DivideByScalar<ushort2>())
            {
                if (d._promises.Pow2)
                {
                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return pow2_div_epu16_su16(x, *(ushort*)&d._divisor, 2);
                    }
                    else
                    {
                        ushort shift = *(ushort*)&d._divisor;

                        return new ushort2(pow2_div_u16(x.x, shift),
                                           pow2_div_u16(x.y, shift));
                    }
                }
                else
                {
                    ushort divisor = *(ushort*)&d._divisor;

                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        ushort mul = *(ushort*)&d._mulShift._mul;
                        ushort shift = *(ushort*)&d._mulShift._shift;

                        return msdiv_epu16_su16(x, divisor, mul, shift, d._promises, 2);
                    }
                    else
                    {
                        uint mul = *(uint*)&d._bigM;

                        return new ushort2(bmdiv_u16(x.x, divisor, mul, d._promises),
                                           bmdiv_u16(x.y, divisor, mul, d._promises));
                    }
                }
            }
            else
            {
                if (d._promises.Pow2)
                {
                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return pow2_div_epu16(x, d._divisor.Reinterpret<T, ushort2>(), 2);
                    }
                    else
                    {
                        ushort2 shift = d._divisor.Reinterpret<T, ushort2>();

                        return new ushort2(pow2_div_u16(x.x, shift.x),
                                           pow2_div_u16(x.y, shift.y));
                    }
                }
                else
                {
                    uint2 mul = *(uint2*)&d._bigM;
                    ushort2 divisor = *(ushort2*)&d._divisor;

                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return bmdiv_epu16(x, divisor, RegisterConversion.ToV128(mul), d._promises, 2);
                    }
                    else
                    {
                        return new ushort2(bmdiv_u16(x.x, divisor.x, mul.x, d._promises),
                                           bmdiv_u16(x.y, divisor.y, mul.y, d._promises));
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator / (ushort3 x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(ushort), 3, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            if (d.DivideByScalar<ushort3>())
            {
                if (d._promises.Pow2)
                {
                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return pow2_div_epu16_su16(x, *(ushort*)&d._divisor, 3);
                    }
                    else
                    {
                        ushort shift = *(ushort*)&d._divisor;

                        return new ushort3(pow2_div_u16(x.x, shift),
                                           pow2_div_u16(x.y, shift),
                                           pow2_div_u16(x.z, shift));
                    }
                }
                else
                {
                    ushort divisor = *(ushort*)&d._divisor;

                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        ushort mul = *(ushort*)&d._mulShift._mul;
                        ushort shift = *(ushort*)&d._mulShift._shift;

                        return msdiv_epu16_su16(x, divisor, mul, shift, d._promises, 3);
                    }
                    else
                    {
                        uint mul = *(uint*)&d._bigM;

                        return new ushort3(bmdiv_u16(x.x, divisor, mul, d._promises),
                                           bmdiv_u16(x.y, divisor, mul, d._promises),
                                           bmdiv_u16(x.z, divisor, mul, d._promises));
                    }
                }
            }
            else
            {
                if (d._promises.Pow2)
                {
                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return pow2_div_epu16(x, d._divisor.Reinterpret<T, ushort3>(), 3);
                    }
                    else
                    {
                        ushort3 shift = d._divisor.Reinterpret<T, ushort3>();

                        return new ushort3(pow2_div_u16(x.x, shift.x),
                                           pow2_div_u16(x.y, shift.y),
                                           pow2_div_u16(x.z, shift.z));
                    }
                }
                else
                {
                    uint3 mul = *(uint3*)&d._bigM;
                    ushort3 divisor = *(ushort3*)&d._divisor;

                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return bmdiv_epu16(x, divisor, RegisterConversion.ToV128(mul), d._promises, 3);
                    }
                    else
                    {
                        return new ushort3(bmdiv_u16(x.x, divisor.x, mul.x, d._promises),
                                           bmdiv_u16(x.y, divisor.y, mul.y, d._promises),
                                           bmdiv_u16(x.z, divisor.z, mul.z, d._promises));
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator / (ushort4 x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(ushort), 4, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            if (d.DivideByScalar<ushort4>())
            {
                if (d._promises.Pow2)
                {
                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return pow2_div_epu16_su16(x, *(ushort*)&d._divisor, 4);
                    }
                    else
                    {
                        ushort shift = *(ushort*)&d._divisor;

                        return new ushort4(pow2_div_u16(x.x, shift),
                                           pow2_div_u16(x.y, shift),
                                           pow2_div_u16(x.z, shift),
                                           pow2_div_u16(x.w, shift));
                    }
                }
                else
                {
                    ushort divisor = *(ushort*)&d._divisor;

                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        ushort mul = *(ushort*)&d._mulShift._mul;
                        ushort shift = *(ushort*)&d._mulShift._shift;

                        return msdiv_epu16_su16(x, divisor, mul, shift, d._promises, 4);
                    }
                    else
                    {
                        uint mul = *(uint*)&d._bigM;

                        return new ushort4(bmdiv_u16(x.x, divisor, mul, d._promises),
                                           bmdiv_u16(x.y, divisor, mul, d._promises),
                                           bmdiv_u16(x.z, divisor, mul, d._promises),
                                           bmdiv_u16(x.w, divisor, mul, d._promises));
                    }
                }
            }
            else
            {
                if (d._promises.Pow2)
                {
                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return pow2_div_epu16(x, d._divisor.Reinterpret<T, ushort4>(), 4);
                    }
                    else
                    {
                        ushort4 shift = d._divisor.Reinterpret<T, ushort4>();

                        return new ushort4(pow2_div_u16(x.x, shift.x),
                                           pow2_div_u16(x.y, shift.y),
                                           pow2_div_u16(x.z, shift.z),
                                           pow2_div_u16(x.w, shift.w));
                    }
                }
                else
                {
                    uint4 mul = *(uint4*)&d._bigM;
                    ushort4 divisor = *(ushort4*)&d._divisor;

                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return bmdiv_epu16(x, divisor, RegisterConversion.ToV128(mul), d._promises, 4);
                    }
                    else
                    {
                        return new ushort4(bmdiv_u16(x.x, divisor.x, mul.x, d._promises),
                                           bmdiv_u16(x.y, divisor.y, mul.y, d._promises),
                                           bmdiv_u16(x.z, divisor.z, mul.z, d._promises),
                                           bmdiv_u16(x.w, divisor.w, mul.w, d._promises));
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator / (ushort8 x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(ushort), 8, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            if (d.DivideByScalar<ushort8>())
            {
                if (d._promises.Pow2)
                {
                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return pow2_div_epu16_su16(x, *(ushort*)&d._divisor, 8);
                    }
                    else
                    {
                        ushort shift = *(ushort*)&d._divisor;

                        return new ushort8(pow2_div_u16(x.x0, shift),
                                           pow2_div_u16(x.x1, shift),
                                           pow2_div_u16(x.x2, shift),
                                           pow2_div_u16(x.x3, shift),
                                           pow2_div_u16(x.x4, shift),
                                           pow2_div_u16(x.x5, shift),
                                           pow2_div_u16(x.x6, shift),
                                           pow2_div_u16(x.x7, shift));
                    }
                }
                else
                {
                    ushort divisor = *(ushort*)&d._divisor;

                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        ushort mul = *(ushort*)&d._mulShift._mul;
                        ushort shift = *(ushort*)&d._mulShift._shift;

                        return msdiv_epu16_su16(x, divisor, mul, shift, d._promises, 8);
                    }
                    else
                    {
                        uint mul = *(uint*)&d._bigM;

                        return new ushort8(bmdiv_u16(x.x0, divisor, mul, d._promises),
                                           bmdiv_u16(x.x1, divisor, mul, d._promises),
                                           bmdiv_u16(x.x2, divisor, mul, d._promises),
                                           bmdiv_u16(x.x3, divisor, mul, d._promises),
                                           bmdiv_u16(x.x4, divisor, mul, d._promises),
                                           bmdiv_u16(x.x5, divisor, mul, d._promises),
                                           bmdiv_u16(x.x6, divisor, mul, d._promises),
                                           bmdiv_u16(x.x7, divisor, mul, d._promises));
                    }
                }
            }
            else
            {
                if (d._promises.Pow2)
                {
                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return pow2_div_epu16(x, d._divisor.Reinterpret<T, ushort8>(), 8);
                    }
                    else
                    {
                        ushort8 shift = d._divisor.Reinterpret<T, ushort8>();

                        return new ushort8(pow2_div_u16(x.x0, shift.x0),
                                           pow2_div_u16(x.x1, shift.x1),
                                           pow2_div_u16(x.x2, shift.x2),
                                           pow2_div_u16(x.x3, shift.x3),
                                           pow2_div_u16(x.x4, shift.x4),
                                           pow2_div_u16(x.x5, shift.x5),
                                           pow2_div_u16(x.x6, shift.x6),
                                           pow2_div_u16(x.x7, shift.x7));
                    }
                }
                else
                {
                    uint4 mulLo = *(uint4*)&d._bigM._mulLo;
                    uint4 mulHi = *(uint4*)&d._bigM._mulHi;
                    ushort8 divisor = *(ushort8*)&d._divisor;

                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return bmdiv_epu16(x, divisor, RegisterConversion.ToV128(mulLo), RegisterConversion.ToV128(mulHi), d._promises);
                    }
                    else
                    {
                        return new ushort8(bmdiv_u16(x.x0, divisor.x0, mulLo.x, d._promises),
                                           bmdiv_u16(x.x1, divisor.x1, mulLo.y, d._promises),
                                           bmdiv_u16(x.x2, divisor.x2, mulLo.z, d._promises),
                                           bmdiv_u16(x.x3, divisor.x3, mulLo.w, d._promises),
                                           bmdiv_u16(x.x4, divisor.x4, mulHi.x, d._promises),
                                           bmdiv_u16(x.x5, divisor.x5, mulHi.y, d._promises),
                                           bmdiv_u16(x.x6, divisor.x6, mulHi.z, d._promises),
                                           bmdiv_u16(x.x7, divisor.x7, mulHi.w, d._promises));
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 operator / (ushort16 x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(ushort), 16, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            if (d.DivideByScalar<ushort16>())
            {
                if (d._promises.Pow2)
                {
                    ushort divisor = *(ushort*)&d._divisor;

                    if (Avx2.IsAvx2Supported)
                    {
                        return mm256_pow2_div_epu16_su16(x, divisor);
                    }
                    else if (BurstArchitecture.IsSIMDSupported)
                    {
                        return new ushort16(pow2_div_epu16_su16(x.v8_0, divisor, 8), pow2_div_epu16_su16(x.v8_8, divisor, 8));
                    }
                    else
                    {
                        return new ushort16(pow2_div_u16(x.x0,  divisor),
                                            pow2_div_u16(x.x1,  divisor),
                                            pow2_div_u16(x.x2,  divisor),
                                            pow2_div_u16(x.x3,  divisor),
                                            pow2_div_u16(x.x4,  divisor),
                                            pow2_div_u16(x.x5,  divisor),
                                            pow2_div_u16(x.x6,  divisor),
                                            pow2_div_u16(x.x7,  divisor),
                                            pow2_div_u16(x.x8,  divisor),
                                            pow2_div_u16(x.x9,  divisor),
                                            pow2_div_u16(x.x10, divisor),
                                            pow2_div_u16(x.x11, divisor),
                                            pow2_div_u16(x.x12, divisor),
                                            pow2_div_u16(x.x13, divisor),
                                            pow2_div_u16(x.x14, divisor),
                                            pow2_div_u16(x.x15, divisor));
                    }
                }
                else
                {
                    ushort divisor = *(ushort*)&d._divisor;

                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        ushort mul = *(ushort*)&d._mulShift._mul;
                        ushort shift = *(ushort*)&d._mulShift._shift;

                        if (Avx2.IsAvx2Supported)
                        {
                            return mm256_msdiv_epu16_su16(x, divisor, mul, shift, d._promises);
                        }
                        else
                        {
                            return new ushort16(msdiv_epu16_su16(x.v8_0, divisor, mul, shift, d._promises),
                                                msdiv_epu16_su16(x.v8_8, divisor, mul, shift, d._promises));
                        }
                    }
                    else
                    {
                        uint mul = *(uint*)&d._bigM;

                        return new ushort16(bmdiv_u16(x.x0,  divisor, mul, d._promises),
                                            bmdiv_u16(x.x1,  divisor, mul, d._promises),
                                            bmdiv_u16(x.x2,  divisor, mul, d._promises),
                                            bmdiv_u16(x.x3,  divisor, mul, d._promises),
                                            bmdiv_u16(x.x4,  divisor, mul, d._promises),
                                            bmdiv_u16(x.x5,  divisor, mul, d._promises),
                                            bmdiv_u16(x.x6,  divisor, mul, d._promises),
                                            bmdiv_u16(x.x7,  divisor, mul, d._promises),
                                            bmdiv_u16(x.x8,  divisor, mul, d._promises),
                                            bmdiv_u16(x.x9,  divisor, mul, d._promises),
                                            bmdiv_u16(x.x10, divisor, mul, d._promises),
                                            bmdiv_u16(x.x11, divisor, mul, d._promises),
                                            bmdiv_u16(x.x12, divisor, mul, d._promises),
                                            bmdiv_u16(x.x13, divisor, mul, d._promises),
                                            bmdiv_u16(x.x14, divisor, mul, d._promises),
                                            bmdiv_u16(x.x15, divisor, mul, d._promises));
                    }
                }
            }
            else
            {
                if (d._promises.Pow2)
                {
                    ushort16 divisor = d._divisor.Reinterpret<T, ushort16>();

                    if (Avx2.IsAvx2Supported)
                    {
                        return mm256_pow2_div_epu16(x, divisor);
                    }
                    else if (BurstArchitecture.IsSIMDSupported)
                    {
                        return new ushort16(pow2_div_epu16(x.v8_0, divisor.v8_0, 8), pow2_div_epu16(x.v8_8, divisor.v8_8, 8));
                    }
                    else
                    {
                        return new ushort16(pow2_div_u16(x.x0,  divisor.x0),
                                            pow2_div_u16(x.x1,  divisor.x1),
                                            pow2_div_u16(x.x2,  divisor.x2),
                                            pow2_div_u16(x.x3,  divisor.x3),
                                            pow2_div_u16(x.x4,  divisor.x4),
                                            pow2_div_u16(x.x5,  divisor.x5),
                                            pow2_div_u16(x.x6,  divisor.x6),
                                            pow2_div_u16(x.x7,  divisor.x7),
                                            pow2_div_u16(x.x8,  divisor.x8),
                                            pow2_div_u16(x.x9,  divisor.x9),
                                            pow2_div_u16(x.x10, divisor.x10),
                                            pow2_div_u16(x.x11, divisor.x11),
                                            pow2_div_u16(x.x12, divisor.x12),
                                            pow2_div_u16(x.x13, divisor.x13),
                                            pow2_div_u16(x.x14, divisor.x14),
                                            pow2_div_u16(x.x15, divisor.x15));
                    }
                }
                else
                {
                    uint8 mulLo = *(uint8*)&d._bigM._mulLo;
                    uint8 mulHi = *(uint8*)&d._bigM._mulHi;
                    ushort16 divisor = *(ushort16*)&d._divisor;

                    if (Avx2.IsAvx2Supported)
                    {
                        return mm256_bmdiv_epu16(x, divisor, mulLo, mulHi, d._promises);
                    }
                    else if (BurstArchitecture.IsSIMDSupported)
                    {
                        return new ushort16(bmdiv_epu16(x.v8_0, divisor.v8_0, RegisterConversion.ToV128(mulLo.v4_0), RegisterConversion.ToV128(mulLo.v4_4), d._promises),
                                            bmdiv_epu16(x.v8_8, divisor.v8_8, RegisterConversion.ToV128(mulHi.v4_0), RegisterConversion.ToV128(mulHi.v4_4), d._promises));
                    }
                    else
                    {
                        return new ushort16(bmdiv_u16(x.x0,  divisor.x0,  mulLo.x0, d._promises),
                                            bmdiv_u16(x.x1,  divisor.x1,  mulLo.x1, d._promises),
                                            bmdiv_u16(x.x2,  divisor.x2,  mulLo.x2, d._promises),
                                            bmdiv_u16(x.x3,  divisor.x3,  mulLo.x3, d._promises),
                                            bmdiv_u16(x.x4,  divisor.x4,  mulLo.x4, d._promises),
                                            bmdiv_u16(x.x5,  divisor.x5,  mulLo.x5, d._promises),
                                            bmdiv_u16(x.x6,  divisor.x6,  mulLo.x6, d._promises),
                                            bmdiv_u16(x.x7,  divisor.x7,  mulLo.x7, d._promises),
                                            bmdiv_u16(x.x8,  divisor.x8,  mulHi.x0, d._promises),
                                            bmdiv_u16(x.x9,  divisor.x9,  mulHi.x1, d._promises),
                                            bmdiv_u16(x.x10, divisor.x10, mulHi.x2, d._promises),
                                            bmdiv_u16(x.x11, divisor.x11, mulHi.x3, d._promises),
                                            bmdiv_u16(x.x12, divisor.x12, mulHi.x4, d._promises),
                                            bmdiv_u16(x.x13, divisor.x13, mulHi.x5, d._promises),
                                            bmdiv_u16(x.x14, divisor.x14, mulHi.x6, d._promises),
                                            bmdiv_u16(x.x15, divisor.x15, mulHi.x7, d._promises));
                    }
                }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T operator / (uint x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(uint), 1, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            switch (sizeof(T))
            {
                case 8 * sizeof(uint): return ((uint8)x / d).Reinterpret<uint8, T>();
                case 4 * sizeof(uint): return ((uint4)x / d).Reinterpret<uint4, T>();
                case 3 * sizeof(uint): return ((uint3)x / d).Reinterpret<uint3, T>();
                case 2 * sizeof(uint): return ((uint2)x / d).Reinterpret<uint2, T>();
                default:
                {
                    if (d._promises.Pow2)
                    {
                        return pow2_div_u32(x, *(uint*)&d._divisor).Reinterpret<uint, T>();
                    }
                    else
                    {
                        if (BurstArchitecture.IsBurstCompiled)
                        {
                            return bmdiv_u32(x, *(uint*)&d._divisor, *(ulong*)&d._bigM, d._promises).Reinterpret<uint, T>();
                        }
                        else
                        {
                            return msdiv_u32(x, *(uint*)&d._divisor, *(uint*)&d._mulShift._mul, *(uint*)&d._mulShift._shift, d._promises).Reinterpret<uint, T>();
                        }
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator / (uint2 x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(uint), 2, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            if (d.DivideByScalar<uint2>())
            {
                if (d._promises.Pow2)
                {
                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return RegisterConversion.ToUInt2(pow2_div_epu32_su32(RegisterConversion.ToV128(x), *(uint*)&d._divisor, 2));
                    }
                    else
                    {
                        uint shift = *(uint*)&d._divisor;

                        return new uint2(pow2_div_u32(x.x, shift),
                                         pow2_div_u32(x.y, shift));
                    }
                }
                else
                {
                    uint divisor = *(uint*)&d._divisor;
                    uint mul = *(uint*)&d._mulShift._mul;
                    uint shift = *(uint*)&d._mulShift._shift;

                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return RegisterConversion.ToUInt2(msdiv_epu32_su32(RegisterConversion.ToV128(x), divisor, mul, shift, d._promises, 2));
                    }
                    else
                    {
                        if (BurstArchitecture.IsBurstCompiled)
                        {
                            ulong mul64 = *(ulong*)&d._bigM;

                            return new uint2(bmdiv_u32(x.x, divisor, mul64, d._promises),
                                             bmdiv_u32(x.y, divisor, mul64, d._promises));
                        }
                        else
                        {
                            return new uint2(msdiv_u32(x.x, divisor, mul, shift, d._promises),
                                             msdiv_u32(x.y, divisor, mul, shift, d._promises));
                        }
                    }
                }
            }
            else
            {
                if (d._promises.Pow2)
                {
                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return RegisterConversion.ToUInt2(pow2_div_epu32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(d._divisor.Reinterpret<T, uint2>()), 2));
                    }
                    else
                    {
                        uint2 shift = d._divisor.Reinterpret<T, uint2>();

                        return new uint2(pow2_div_u32(x.x, shift.x),
                                         pow2_div_u32(x.y, shift.y));
                    }
                }
                else
                {
                    uint2 divisor = *(uint2*)&d._divisor;
                    uint2 mul = *(uint2*)&d._mulShift._mul;
                    uint2 shift = *(uint2*)&d._mulShift._shift;

                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return RegisterConversion.ToUInt2(msdiv_epu32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(divisor), RegisterConversion.ToV128(mul), RegisterConversion.ToV128(shift), d._promises, 2));
                    }
                    else
                    {
                        if (BurstArchitecture.IsBurstCompiled)
                        {
                            ulong2 mul64 = *(ulong2*)&d._bigM;

                            return new uint2(bmdiv_u32(x.x, divisor.x, mul64.x, d._promises),
                                             bmdiv_u32(x.y, divisor.y, mul64.y, d._promises));
                        }
                        else
                        {
                            return new uint2(msdiv_u32(x.x, divisor.x, mul.x, shift.x, d._promises),
                                             msdiv_u32(x.y, divisor.y, mul.y, shift.y, d._promises));
                        }
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator / (uint3 x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(uint), 3, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            if (d.DivideByScalar<uint3>())
            {
                if (d._promises.Pow2)
                {
                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return RegisterConversion.ToUInt3(pow2_div_epu32_su32(RegisterConversion.ToV128(x), *(uint*)&d._divisor, 3));
                    }
                    else
                    {
                        uint shift = *(uint*)&d._divisor;

                        return new uint3(pow2_div_u32(x.x, shift),
                                         pow2_div_u32(x.y, shift),
                                         pow2_div_u32(x.z, shift));
                    }
                }
                else
                {
                    uint divisor = *(uint*)&d._divisor;
                    uint mul = *(uint*)&d._mulShift._mul;
                    uint shift = *(uint*)&d._mulShift._shift;

                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return RegisterConversion.ToUInt3(msdiv_epu32_su32(RegisterConversion.ToV128(x), divisor, mul, shift, d._promises, 3));
                    }
                    else
                    {
                        if (BurstArchitecture.IsBurstCompiled)
                        {
                            ulong mul64 = *(ulong*)&d._bigM;

                            return new uint3(bmdiv_u32(x.x, divisor, mul64, d._promises),
                                             bmdiv_u32(x.y, divisor, mul64, d._promises),
                                             bmdiv_u32(x.z, divisor, mul64, d._promises));
                        }
                        else
                        {
                            return new uint3(msdiv_u32(x.x, divisor, mul, shift, d._promises),
                                             msdiv_u32(x.y, divisor, mul, shift, d._promises),
                                             msdiv_u32(x.z, divisor, mul, shift, d._promises));
                        }
                    }
                }
            }
            else
            {
                if (d._promises.Pow2)
                {
                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return RegisterConversion.ToUInt3(pow2_div_epu32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(d._divisor.Reinterpret<T, uint3>()), 3));
                    }
                    else
                    {
                        uint3 shift = d._divisor.Reinterpret<T, uint3>();

                        return new uint3(pow2_div_u32(x.x, shift.x),
                                         pow2_div_u32(x.y, shift.y),
                                         pow2_div_u32(x.z, shift.z));
                    }
                }
                else
                {
                    uint3 divisor = *(uint3*)&d._divisor;
                    uint3 mul = *(uint3*)&d._mulShift._mul;
                    uint3 shift = *(uint3*)&d._mulShift._shift;

                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return RegisterConversion.ToUInt3(msdiv_epu32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(divisor), RegisterConversion.ToV128(mul), RegisterConversion.ToV128(shift), d._promises, 3));
                    }
                    else
                    {
                        if (BurstArchitecture.IsBurstCompiled)
                        {
                            ulong3 mul64 = *(ulong3*)&d._bigM;

                            return new uint3(bmdiv_u32(x.x, divisor.x, mul64.x, d._promises),
                                             bmdiv_u32(x.y, divisor.y, mul64.y, d._promises),
                                             bmdiv_u32(x.z, divisor.z, mul64.z, d._promises));
                        }
                        else
                        {
                            return new uint3(msdiv_u32(x.x, divisor.x, mul.x, shift.x, d._promises),
                                             msdiv_u32(x.y, divisor.y, mul.y, shift.y, d._promises),
                                             msdiv_u32(x.z, divisor.z, mul.z, shift.z, d._promises));
                        }
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 operator / (uint4 x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(uint), 4, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            if (d.DivideByScalar<uint4>())
            {
                if (d._promises.Pow2)
                {
                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return RegisterConversion.ToUInt4(pow2_div_epu32_su32(RegisterConversion.ToV128(x), *(uint*)&d._divisor, 4));
                    }
                    else
                    {
                        uint shift = *(uint*)&d._divisor;

                        return new uint4(pow2_div_u32(x.x, shift),
                                         pow2_div_u32(x.y, shift),
                                         pow2_div_u32(x.z, shift),
                                         pow2_div_u32(x.w, shift));
                    }
                }
                else
                {
                    uint divisor = *(uint*)&d._divisor;
                    uint mul = *(uint*)&d._mulShift._mul;
                    uint shift = *(uint*)&d._mulShift._shift;

                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return RegisterConversion.ToUInt4(msdiv_epu32_su32(RegisterConversion.ToV128(x), divisor, mul, shift, d._promises, 4));
                    }
                    else
                    {
                        if (BurstArchitecture.IsBurstCompiled)
                        {
                            ulong mul64 = *(ulong*)&d._bigM;

                            return new uint4(bmdiv_u32(x.x, divisor, mul64, d._promises),
                                             bmdiv_u32(x.y, divisor, mul64, d._promises),
                                             bmdiv_u32(x.z, divisor, mul64, d._promises),
                                             bmdiv_u32(x.w, divisor, mul64, d._promises));
                        }
                        else
                        {
                            return new uint4(msdiv_u32(x.x, divisor, mul, shift, d._promises),
                                             msdiv_u32(x.y, divisor, mul, shift, d._promises),
                                             msdiv_u32(x.z, divisor, mul, shift, d._promises),
                                             msdiv_u32(x.w, divisor, mul, shift, d._promises));
                        }
                    }
                }
            }
            else
            {
                if (d._promises.Pow2)
                {
                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return RegisterConversion.ToUInt4(pow2_div_epu32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(d._divisor.Reinterpret<T, uint4>()), 4));
                    }
                    else
                    {
                        uint4 shift = d._divisor.Reinterpret<T, uint4>();

                        return new uint4(pow2_div_u32(x.x, shift.x),
                                         pow2_div_u32(x.y, shift.y),
                                         pow2_div_u32(x.z, shift.z),
                                         pow2_div_u32(x.w, shift.w));
                    }
                }
                else
                {
                    uint4 divisor = *(uint4*)&d._divisor;
                    uint4 mul = *(uint4*)&d._mulShift._mul;
                    uint4 shift = *(uint4*)&d._mulShift._shift;

                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return RegisterConversion.ToUInt4(msdiv_epu32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(divisor), RegisterConversion.ToV128(mul), RegisterConversion.ToV128(shift), d._promises, 4));
                    }
                    else
                    {
                        if (BurstArchitecture.IsBurstCompiled)
                        {
                            ulong4 mul64 = *(ulong4*)&d._bigM;

                            return new uint4(bmdiv_u32(x.x, divisor.x, mul64.x, d._promises),
                                             bmdiv_u32(x.y, divisor.y, mul64.y, d._promises),
                                             bmdiv_u32(x.z, divisor.z, mul64.z, d._promises),
                                             bmdiv_u32(x.w, divisor.w, mul64.w, d._promises));
                        }
                        else
                        {
                            return new uint4(msdiv_u32(x.x, divisor.x, mul.x, shift.x, d._promises),
                                             msdiv_u32(x.y, divisor.y, mul.y, shift.y, d._promises),
                                             msdiv_u32(x.z, divisor.z, mul.z, shift.z, d._promises),
                                             msdiv_u32(x.w, divisor.w, mul.w, shift.w, d._promises));
                        }
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 operator / (uint8 x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(uint), 8, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            if (d.DivideByScalar<uint8>())
            {
                if (d._promises.Pow2)
                {
                    uint divisor = *(uint*)&d._divisor;

                    if (Avx2.IsAvx2Supported)
                    {
                        return mm256_pow2_div_epu32_su32(x, divisor);
                    }
                    else if (BurstArchitecture.IsSIMDSupported)
                    {
                        return new uint8(RegisterConversion.ToUInt4(pow2_div_epu32_su32(RegisterConversion.ToV128(x.v4_0), divisor, 4)),
                                         RegisterConversion.ToUInt4(pow2_div_epu32_su32(RegisterConversion.ToV128(x.v4_4), divisor, 4)));
                    }
                    else
                    {
                        return new uint8(pow2_div_u32(x.x0, divisor),
                                         pow2_div_u32(x.x1, divisor),
                                         pow2_div_u32(x.x2, divisor),
                                         pow2_div_u32(x.x3, divisor),
                                         pow2_div_u32(x.x4, divisor),
                                         pow2_div_u32(x.x5, divisor),
                                         pow2_div_u32(x.x6, divisor),
                                         pow2_div_u32(x.x7, divisor));
                    }
                }
                else
                {
                    uint divisor = *(uint*)&d._divisor;
                    uint mul = *(uint*)&d._mulShift._mul;
                    uint shift = *(uint*)&d._mulShift._shift;

                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        if (Avx2.IsAvx2Supported)
                        {
                            return mm256_msdiv_epu32_su32(x, divisor, mul, shift, d._promises);
                        }
                        else
                        {
                            return new uint8(RegisterConversion.ToUInt4(msdiv_epu32_su32(RegisterConversion.ToV128(x.v4_0), divisor, mul, shift, d._promises, 4)),
                                             RegisterConversion.ToUInt4(msdiv_epu32_su32(RegisterConversion.ToV128(x.v4_4), divisor, mul, shift, d._promises, 4)));
                        }
                    }
                    else
                    {
                        if (BurstArchitecture.IsBurstCompiled)
                        {
                            ulong mul64 = *(ulong*)&d._bigM;

                            return new uint8(bmdiv_u32(x.x0, divisor, mul64, d._promises),
                                             bmdiv_u32(x.x1, divisor, mul64, d._promises),
                                             bmdiv_u32(x.x2, divisor, mul64, d._promises),
                                             bmdiv_u32(x.x3, divisor, mul64, d._promises),
                                             bmdiv_u32(x.x4, divisor, mul64, d._promises),
                                             bmdiv_u32(x.x5, divisor, mul64, d._promises),
                                             bmdiv_u32(x.x6, divisor, mul64, d._promises),
                                             bmdiv_u32(x.x7, divisor, mul64, d._promises));
                        }
                        else
                        {
                            return new uint8(msdiv_u32(x.x0, divisor, mul, shift, d._promises),
                                             msdiv_u32(x.x1, divisor, mul, shift, d._promises),
                                             msdiv_u32(x.x2, divisor, mul, shift, d._promises),
                                             msdiv_u32(x.x3, divisor, mul, shift, d._promises),
                                             msdiv_u32(x.x4, divisor, mul, shift, d._promises),
                                             msdiv_u32(x.x5, divisor, mul, shift, d._promises),
                                             msdiv_u32(x.x6, divisor, mul, shift, d._promises),
                                             msdiv_u32(x.x7, divisor, mul, shift, d._promises));
                        }
                    }
                }
            }
            else
            {
                if (d._promises.Pow2)
                {
                    uint8 divisor = d._divisor.Reinterpret<T, uint8>();

                    if (Avx2.IsAvx2Supported)
                    {
                        return mm256_pow2_div_epu32(x, divisor);
                    }
                    else if (BurstArchitecture.IsSIMDSupported)
                    {
                        return new uint8(RegisterConversion.ToUInt4(pow2_div_epu32(RegisterConversion.ToV128(x.v4_0), RegisterConversion.ToV128(divisor.v4_0), 4)),
                                         RegisterConversion.ToUInt4(pow2_div_epu32(RegisterConversion.ToV128(x.v4_4), RegisterConversion.ToV128(divisor.v4_4), 4)));
                    }
                    else
                    {
                        return new uint8(pow2_div_u32(x.x0, divisor.x0),
                                         pow2_div_u32(x.x1, divisor.x1),
                                         pow2_div_u32(x.x2, divisor.x2),
                                         pow2_div_u32(x.x3, divisor.x3),
                                         pow2_div_u32(x.x4, divisor.x4),
                                         pow2_div_u32(x.x5, divisor.x5),
                                         pow2_div_u32(x.x6, divisor.x6),
                                         pow2_div_u32(x.x7, divisor.x7));
                    }
                }
                else
                {
                    uint8 divisor = *(uint8*)&d._divisor;
                    uint8 mul = *(uint8*)&d._mulShift._mul;
                    uint8 shift = *(uint8*)&d._mulShift._shift;

                    if (Avx2.IsAvx2Supported)
                    {
                        return mm256_msdiv_epu32(x, divisor, mul, shift, d._promises);
                    }
                    else if (BurstArchitecture.IsSIMDSupported)
                    {
                        return new uint8(RegisterConversion.ToUInt4(msdiv_epu32(RegisterConversion.ToV128(x.v4_0), RegisterConversion.ToV128(divisor.v4_0), RegisterConversion.ToV128(mul.v4_0), RegisterConversion.ToV128(shift.v4_0), d._promises)),
                                         RegisterConversion.ToUInt4(msdiv_epu32(RegisterConversion.ToV128(x.v4_4), RegisterConversion.ToV128(divisor.v4_4), RegisterConversion.ToV128(mul.v4_4), RegisterConversion.ToV128(shift.v4_4), d._promises)));
                    }
                    else
                    {
                        if (BurstArchitecture.IsBurstCompiled)
                        {
                            ulong4 mul64Lo = *(ulong4*)&d._bigM._mulLo;
                            ulong4 mul64Hi = *(ulong4*)&d._bigM._mulHi;

                            return new uint8(bmdiv_u32(x.x0, divisor.x0, mul64Lo.x, d._promises),
                                             bmdiv_u32(x.x1, divisor.x1, mul64Lo.y, d._promises),
                                             bmdiv_u32(x.x2, divisor.x2, mul64Lo.z, d._promises),
                                             bmdiv_u32(x.x3, divisor.x3, mul64Lo.w, d._promises),
                                             bmdiv_u32(x.x4, divisor.x4, mul64Hi.x, d._promises),
                                             bmdiv_u32(x.x5, divisor.x5, mul64Hi.y, d._promises),
                                             bmdiv_u32(x.x6, divisor.x6, mul64Hi.z, d._promises),
                                             bmdiv_u32(x.x7, divisor.x7, mul64Hi.w, d._promises));
                        }
                        else
                        {
                            return new uint8(msdiv_u32(x.x0, divisor.x0, mul.x0, shift.x0, d._promises),
                                             msdiv_u32(x.x1, divisor.x1, mul.x1, shift.x1, d._promises),
                                             msdiv_u32(x.x2, divisor.x2, mul.x2, shift.x2, d._promises),
                                             msdiv_u32(x.x3, divisor.x3, mul.x3, shift.x3, d._promises),
                                             msdiv_u32(x.x4, divisor.x4, mul.x4, shift.x4, d._promises),
                                             msdiv_u32(x.x5, divisor.x5, mul.x5, shift.x5, d._promises),
                                             msdiv_u32(x.x6, divisor.x6, mul.x6, shift.x6, d._promises),
                                             msdiv_u32(x.x7, divisor.x7, mul.x7, shift.x7, d._promises));
                        }
                    }
                }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T operator / (ulong x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(ulong), 1, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            switch (sizeof(T))
            {
                case 4 * sizeof(ulong): return ((ulong4)x / d).Reinterpret<ulong4, T>();
                case 3 * sizeof(ulong): return ((ulong3)x / d).Reinterpret<ulong3, T>();
                case 2 * sizeof(ulong): return ((ulong2)x / d).Reinterpret<ulong2, T>();
                default:
                {
                    if (d._promises.Pow2)
                    {
                        return pow2_div_u64(x, *(ulong*)&d._divisor).Reinterpret<ulong, T>();
                    }
                    else
                    {
                        if (BurstArchitecture.IsBurstCompiled)
                        {
                            return bmdiv_u64(x, *(ulong*)&d._divisor, *(UInt128*)&d._bigM, d._promises).Reinterpret<ulong, T>();
                        }
                        else
                        {
                            return msdiv_u64(x, *(ulong*)&d._divisor, *(ulong*)&d._mulShift._mul, *(ulong*)&d._mulShift._shift, d._promises).Reinterpret<ulong, T>();
                        }
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator / (ulong2 x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(ulong), 2, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            if (d.DivideByScalar<ulong2>())
            {
                if (d._promises.Pow2)
                {
                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return pow2_div_epu64_su64(x, *(ulong*)&d._divisor);
                    }
                    else
                    {
                        ulong shift = *(ulong*)&d._divisor;

                        return new ulong2(pow2_div_u64(x.x, shift),
                                          pow2_div_u64(x.y, shift));
                    }
                }
                else
                {
                    ulong divisor = *(ulong*)&d._divisor;

                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        ulong mul = *(ulong*)&d._mulShift._mul;
                        ulong shift = *(ulong*)&d._mulShift._shift;

                        return msdiv_epu64_su64(x, divisor, mul, shift, d._promises);
                    }
                    else if (BurstArchitecture.IsBurstCompiled)
                    {
                        UInt128 mul = *((UInt128*)&d._bigM + 0);

                        return new ulong2(bmdiv_u64(x.x, divisor, mul, d._promises),
                                          bmdiv_u64(x.y, divisor, mul, d._promises));
                    }
                    else
                    {
                        ulong mul = *(ulong*)&d._mulShift._mul;
                        ulong shift = *(ulong*)&d._mulShift._shift;

                        return new ulong2(msdiv_u64(x.x, divisor, mul, shift, d._promises),
                                          msdiv_u64(x.y, divisor, mul, shift, d._promises));
                    }
                }
            }
            else
            {
                if (d._promises.Pow2)
                {
                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return pow2_div_epu64(x, d._divisor.Reinterpret<T, ulong2>());
                    }
                    else
                    {
                        ulong2 shift = d._divisor.Reinterpret<T, ulong2>();

                        return new ulong2(pow2_div_u64(x.x, shift.x),
                                          pow2_div_u64(x.y, shift.y));
                    }
                }
                else
                {
                    ulong2 divisor = *(ulong2*)&d._divisor;

                    if (Avx2.IsAvx2Supported)
                    {
                        return msdiv_epu64(x, divisor, *(ulong2*)&d._mulShift._mul, *(ulong2*)&d._mulShift._shift, d._promises);
                    }
                    else if (BurstArchitecture.IsBurstCompiled)
                    {
                        UInt128 mul0 = *((UInt128*)&d._bigM + 0);
                        UInt128 mul1 = *((UInt128*)&d._bigM + 1);

                        return new ulong2(bmdiv_u64(x.x, divisor.x, mul0, d._promises),
                                          bmdiv_u64(x.y, divisor.y, mul1, d._promises));
                    }
                    else
                    {
                        ulong2 mul = *(ulong2*)&d._mulShift._mul;
                        ulong2 shift = *(ulong2*)&d._mulShift._shift;

                        return new ulong2(msdiv_u64(x.x, divisor.x, mul.x, shift.x, d._promises),
                                          msdiv_u64(x.y, divisor.y, mul.y, shift.y, d._promises));
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator / (ulong3 x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(ulong), 3, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            if (d.DivideByScalar<ulong3>())
            {
                if (d._promises.Pow2)
                {
                    ulong divisor = *(ulong*)&d._divisor;

                    if (Avx2.IsAvx2Supported)
                    {
                        return mm256_pow2_div_epu64_su64(x, divisor);
                    }
                    else if (BurstArchitecture.IsSIMDSupported)
                    {
                        return new ulong3(pow2_div_epu64_su64(x.xy, divisor),
                                          pow2_div_u64(x.z, divisor));
                    }
                    else
                    {
                        return new ulong3(pow2_div_u64(x.x, divisor),
                                          pow2_div_u64(x.y, divisor),
                                          pow2_div_u64(x.z, divisor));
                    }
                }
                else
                {
                    ulong divisor = *(ulong*)&d._divisor;

                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        ulong mul = *(ulong*)&d._mulShift._mul;
                        ulong shift = *(ulong*)&d._mulShift._shift;

                        if (Avx2.IsAvx2Supported)
                        {
                            return mm256_msdiv_epu64_su64(x, divisor, mul, shift, d._promises, 3);
                        }
                        else
                        {
                            ulong2 xy = msdiv_epu64_su64(x.xy, divisor, mul, shift, d._promises);

                            UInt128 mul128 = *(UInt128*)&d._bigM;

                            ulong z = bmdiv_u64(x.z, divisor, mul128, d._promises);

                            return new ulong3(xy, z);
                        }
                    }
                    else if (BurstArchitecture.IsBurstCompiled)
                    {
                        UInt128 mul = *(UInt128*)&d._bigM;

                        return new ulong3(bmdiv_u64(x.x, divisor, mul, d._promises),
                                          bmdiv_u64(x.y, divisor, mul, d._promises),
                                          bmdiv_u64(x.z, divisor, mul, d._promises));
                    }
                    else
                    {
                        ulong mul = *(ulong*)&d._mulShift._mul;
                        ulong shift = *(ulong*)&d._mulShift._shift;

                        return new ulong3(msdiv_u64(x.x, divisor, mul, shift, d._promises),
                                          msdiv_u64(x.y, divisor, mul, shift, d._promises),
                                          msdiv_u64(x.z, divisor, mul, shift, d._promises));
                    }
                }
            }
            else
            {
                if (d._promises.Pow2)
                {
                    ulong3 divisor = d._divisor.Reinterpret<T, ulong3>();

                    if (Avx2.IsAvx2Supported)
                    {
                        return mm256_pow2_div_epu64(x, divisor);
                    }
                    else if (BurstArchitecture.IsSIMDSupported)
                    {
                        return new ulong3(pow2_div_epu64(x.xy, divisor.xy),
                                          pow2_div_u64(x.z, divisor.z));
                    }
                    else
                    {
                        return new ulong3(pow2_div_u64(x.x, divisor.x),
                                          pow2_div_u64(x.y, divisor.y),
                                          pow2_div_u64(x.z, divisor.z));
                    }
                }
                else
                {
                    ulong3 divisor = *(ulong3*)&d._divisor;

                    if (Avx2.IsAvx2Supported)
                    {
                        return mm256_msdiv_epu64(x, divisor, *(ulong3*)&d._mulShift._mul, *(ulong3*)&d._mulShift._shift, d._promises, 3);
                    }
                    else if (BurstArchitecture.IsBurstCompiled)
                    {
                        UInt128 mul0 = *((UInt128*)&d._bigM + 0);
                        UInt128 mul1 = *((UInt128*)&d._bigM + 1);
                        UInt128 mul2 = *((UInt128*)&d._bigM + 2);

                        return new ulong3(bmdiv_u64(x.x, divisor.x, mul0, d._promises),
                                          bmdiv_u64(x.y, divisor.y, mul1, d._promises),
                                          bmdiv_u64(x.z, divisor.z, mul2, d._promises));
                    }
                    else
                    {
                        ulong3 mul = *(ulong3*)&d._mulShift._mul;
                        ulong3 shift = *(ulong3*)&d._mulShift._shift;

                        return new ulong3(msdiv_u64(x.x, divisor.x, mul.x, shift.x, d._promises),
                                          msdiv_u64(x.y, divisor.y, mul.y, shift.y, d._promises),
                                          msdiv_u64(x.z, divisor.z, mul.z, shift.z, d._promises));
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator / (ulong4 x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(ulong), 4, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            if (d.DivideByScalar<ulong4>())
            {
                if (d._promises.Pow2)
                {
                    ulong divisor = *(ulong*)&d._divisor;

                    if (Avx2.IsAvx2Supported)
                    {
                        return mm256_pow2_div_epu64_su64(x, divisor);
                    }
                    else if (BurstArchitecture.IsSIMDSupported)
                    {
                        return new ulong4(pow2_div_epu64_su64(x.xy, divisor),
                                          pow2_div_epu64_su64(x.zw, divisor));
                    }
                    else
                    {
                        return new ulong4(pow2_div_u64(x.x, divisor),
                                          pow2_div_u64(x.y, divisor),
                                          pow2_div_u64(x.z, divisor),
                                          pow2_div_u64(x.w, divisor));
                    }
                }
                else
                {
                    ulong divisor = *(ulong*)&d._divisor;

                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        ulong mul = *(ulong*)&d._mulShift._mul;
                        ulong shift = *(ulong*)&d._mulShift._shift;

                        if (Avx2.IsAvx2Supported)
                        {
                            return mm256_msdiv_epu64_su64(x, divisor, mul, shift, d._promises);
                        }
                        else
                        {
                            return new ulong4(msdiv_epu64_su64(x.xy, divisor, mul, shift, d._promises),
                                              msdiv_epu64_su64(x.zw, divisor, mul, shift, d._promises));
                        }
                    }
                    else if (BurstArchitecture.IsBurstCompiled)
                    {
                        UInt128 mul = *(UInt128*)&d._bigM;

                        return new ulong4(bmdiv_u64(x.x, divisor, mul, d._promises),
                                          bmdiv_u64(x.y, divisor, mul, d._promises),
                                          bmdiv_u64(x.z, divisor, mul, d._promises),
                                          bmdiv_u64(x.w, divisor, mul, d._promises));
                    }
                    else
                    {
                        ulong mul = *(ulong*)&d._mulShift._mul;
                        ulong shift = *(ulong*)&d._mulShift._shift;

                        return new ulong4(msdiv_u64(x.x, divisor, mul, shift, d._promises),
                                          msdiv_u64(x.y, divisor, mul, shift, d._promises),
                                          msdiv_u64(x.z, divisor, mul, shift, d._promises),
                                          msdiv_u64(x.w, divisor, mul, shift, d._promises));
                    }
                }
            }
            else
            {
                if (d._promises.Pow2)
                {
                    ulong4 divisor = d._divisor.Reinterpret<T, ulong4>();

                    if (Avx2.IsAvx2Supported)
                    {
                        return mm256_pow2_div_epu64(x, divisor);
                    }
                    else if (BurstArchitecture.IsSIMDSupported)
                    {
                        return new ulong4(pow2_div_epu64(x.xy, divisor.xy),
                                          pow2_div_epu64(x.zw, divisor.zw));
                    }
                    else
                    {
                        return new ulong4(pow2_div_u64(x.x, divisor.x),
                                          pow2_div_u64(x.y, divisor.y),
                                          pow2_div_u64(x.z, divisor.z),
                                          pow2_div_u64(x.w, divisor.w));
                    }
                }
                else
                {
                    ulong4 divisor = *(ulong4*)&d._divisor;

                    if (Avx2.IsAvx2Supported)
                    {
                        return mm256_msdiv_epu64(x, divisor, *(ulong4*)&d._mulShift._mul, *(ulong4*)&d._mulShift._shift, d._promises, 4);
                    }
                    else if (BurstArchitecture.IsBurstCompiled)
                    {
                        UInt128 mul0 = *((UInt128*)&d._bigM + 0);
                        UInt128 mul1 = *((UInt128*)&d._bigM + 1);
                        UInt128 mul2 = *((UInt128*)&d._bigM + 2);
                        UInt128 mul3 = *((UInt128*)&d._bigM + 3);

                        return new ulong4(bmdiv_u64(x.x, divisor.x, mul0, d._promises),
                                          bmdiv_u64(x.y, divisor.y, mul1, d._promises),
                                          bmdiv_u64(x.z, divisor.z, mul2, d._promises),
                                          bmdiv_u64(x.w, divisor.w, mul3, d._promises));
                    }
                    else
                    {
                        ulong4 mul = *(ulong4*)&d._mulShift._mul;
                        ulong4 shift = *(ulong4*)&d._mulShift._shift;

                        return new ulong4(msdiv_u64(x.x, divisor.x, mul.x, shift.x, d._promises),
                                          msdiv_u64(x.y, divisor.y, mul.y, shift.y, d._promises),
                                          msdiv_u64(x.z, divisor.z, mul.z, shift.z, d._promises),
                                          msdiv_u64(x.w, divisor.w, mul.w, shift.w, d._promises));
                    }
                }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator / (UInt128 x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(UInt128), 1, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            if (d._promises.Pow2)
            {
                return pow2_div_u128(x, *(UInt128*)&d._divisor);
            }
            else
            {
                return msdiv_u128(x, *(UInt128*)&d._divisor, *(UInt128*)&d._mulShift._mul, *(UInt128*)&d._mulShift._shift, d._promises);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static byte pow2_div_u8(byte x, byte original)
        {
            return (byte)(x >> tzcnt(original));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ushort pow2_div_u16(ushort x, ushort original)
        {
            return (ushort)(x >> tzcnt(original));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint pow2_div_u32(uint x, uint original)
        {
            return x >> tzcnt(original);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong pow2_div_u64(ulong x, ulong original)
        {
            return x >> tzcnt(original);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static UInt128 pow2_div_u128(UInt128 x, UInt128 original)
        {
            return x >> tzcnt(original);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 pow2_div_epu8(v128 x, v128 original, byte elements = 16)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.srlv_epi8(x, Xse.tzcnt_epi8(original), inRange: true, elements: elements);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 pow2_div_epu16(v128 x, v128 original, byte elements = 8)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.srlv_epi16(x, Xse.tzcnt_epi16(original), inRange: true, elements: elements);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 pow2_div_epu32(v128 x, v128 original, byte elements = 4)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.srlv_epi32(x, Xse.tzcnt_epi32(original), inRange: true, elements: elements);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 pow2_div_epu64(v128 x, v128 original)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.srlv_epi64(x, Xse.tzcnt_epi64(original), inRange: true);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_pow2_div_epu8(v256 x, v256 original)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_srlv_epi8(x, Xse.mm256_tzcnt_epi8(original));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_pow2_div_epu16(v256 x, v256 original)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_srlv_epi16(x, Xse.mm256_tzcnt_epi16(original));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_pow2_div_epu32(v256 x, v256 original)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_srlv_epi32(x, Xse.mm256_tzcnt_epi32(original));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_pow2_div_epu64(v256 x, v256 original)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_srlv_epi64(x, Xse.mm256_tzcnt_epi64(original));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 pow2_div_epu8_su8(v128 x, byte original, byte elements = 16)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.srli_epi8(x, tzcnt(original), inRange: true);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 pow2_div_epu16_su16(v128 x, ushort original, byte elements = 8)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.srli_epi16(x, tzcnt(original), inRange: true);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 pow2_div_epu32_su32(v128 x, uint original, byte elements = 4)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.srli_epi32(x, tzcnt(original), inRange: true);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 pow2_div_epu64_su64(v128 x, ulong original)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.srli_epi64(x, tzcnt(original), inRange: true);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_pow2_div_epu8_su8(v256 x, byte original)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_srli_epi8(x, tzcnt(original));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_pow2_div_epu16_su16(v256 x, ushort original)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_srli_epi16(x, tzcnt(original));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_pow2_div_epu32_su32(v256 x, uint original)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_srli_epi32(x, tzcnt(original));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_pow2_div_epu64_su64(v256 x, ulong original)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_srli_epi64(x, tzcnt(original));
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static byte bmdiv_u8(byte x, byte original, ushort mul, DividerPromise promise)
        {
            if (!promise.NotOne)
            {
                if (Hint.Unlikely(original == 1))
                {
                    return x;
                }
            }

            return (byte)(((uint)mul * (uint)x) >> 16);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ushort bmdiv_u16(ushort x, ushort original, uint mul, DividerPromise promise)
        {
            if (!promise.NotOne)
            {
                if (Hint.Unlikely(original == 1))
                {
                    return x;
                }
            }

            return (ushort)(((ulong)mul * (ulong)x) >> 32);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint msdiv_u32(uint x, uint original, uint mul, uint shift, DividerPromise promise)
        {
            uint hi = (uint)(((ulong)mul * x) >> 32);

            x -= hi;
            x >>= tobyte(promise.NotOne || original != 1);
            x += hi;
            x >>= (int)shift;

            return x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong msdiv_u64(ulong x, ulong original, ulong mul, ulong shift, DividerPromise promise)
        {
            UInt128 product = UInt128.umul128(mul, x);

            x -= product.hi64;
            x >>= tobyte(promise.NotOne || original != 1);
            x += product.hi64;
            x >>= (int)shift;

            return x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static UInt128 msdiv_u128(UInt128 x, UInt128 original, UInt128 mul, UInt128 shift, DividerPromise promise)
        {
            __UInt256__ product = __UInt256__.umul256(mul, x);

            x -= product.hi128;
            x >>= tobyte(promise.NotOne || original != 1);
            x += product.hi128;
            x >>= (int)shift;

            return x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint bmdiv_u32(uint x, uint original, ulong mul, DividerPromise promise)
        {
            if (!promise.NotOne)
            {
                if (Hint.Unlikely(original == 1))
                {
                    return x;
                }
            }

            UInt128 product = UInt128.umul128(mul, x);

            return (uint)product.hi64;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong bmdiv_u64(ulong x, ulong original, UInt128 mul, DividerPromise promise)
        {
            if (!promise.NotOne)
            {
                if (Hint.Unlikely(original == 1))
                {
                    return x;
                }
            }

            UInt128 lo = UInt128.umul128(mul.lo64, x);
            UInt128 hi = UInt128.umul128(mul.hi64, x);

            return (lo.hi64 + hi).hi64;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 bmdiv_epu8(v128 a, v128 original, v128 mul, DividerPromise promise, byte elements = 8)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.ALL_EQ_EPU8(original, 1, elements))
                {
                    return a;
                }

                v128 q = Xse.mulhi_epu16(mul, Xse.cvtepu8_epi16(a));
                q = Xse.packus_epi16(q, q);

                if (!promise.NotOne)
                {
                    q = Xse.blendv_si128(q, a, Xse.cmpeq_epi8(original, Xse.set1_epi8(1)));
                }

                return q;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 bmdiv_epu16(v128 a, v128 original, v128 mul, DividerPromise promise, byte elements = 4)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.ALL_EQ_EPU16(original, 1, elements))
                {
                    return a;
                }

                v128 q = Xse.mulhi_epu32(mul, Xse.cvtepu16_epi32(a), elements);
                if (Sse4_1.IsSse41Supported)
                {
                    q = Xse.packus_epi32(q, q);
                }
                else
                {
                    q = Xse.cvtepi32_epi16(q, elements);
                }

                if (!promise.NotOne)
                {
                    q = Xse.blendv_si128(q, a, Xse.cmpeq_epi16(original, Xse.set1_epi16(1)));
                }

                return q;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 bmdiv_epu8(v128 a, v128 original, v128 mulLo, v128 mulHi, DividerPromise promise)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.ALL_EQ_EPU8(original, 1))
                {
                    return a;
                }

                v128 a16Lo = Xse.cvt2x2epu8_epi16(a, out v128 a16Hi);
                v128 lo = Xse.mulhi_epu16(mulLo, a16Lo);
                v128 hi = Xse.mulhi_epu16(mulHi, a16Hi);
                v128 q = Xse.packus_epi16(lo, hi);

                if (!promise.NotOne)
                {
                    q = Xse.blendv_si128(q, a, Xse.cmpeq_epi8(original, Xse.set1_epi8(1)));
                }

                return q;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 bmdiv_epu16(v128 a, v128 original, v128 mulLo, v128 mulHi, DividerPromise promise)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.ALL_EQ_EPU16(original, 1))
                {
                    return a;
                }

                v128 a16Lo = Xse.cvt2x2epu16_epi32(a, out v128 a16Hi);
                v128 lo = Xse.mulhi_epu32(mulLo, a16Lo);
                v128 hi = Xse.mulhi_epu32(mulHi, a16Hi);
                v128 q;
                if (Sse4_1.IsSse41Supported)
                {
                    q = Xse.packus_epi32(lo, hi);
                }
                else
                {
                    q = Xse.cvt2x2epi32_epi16(lo, hi);
                }

                if (!promise.NotOne)
                {
                    q = Xse.blendv_si128(q, a, Xse.cmpeq_epi16(original, Xse.set1_epi16(1)));
                }

                return q;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 msdiv_epu32(v128 a, v128 original, v128 mul, v128 shift, DividerPromise promises, byte elements = 4)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.ALL_EQ_EPU32(original, 1, elements))
                {
                    return a;
                }

                v128 hi = Xse.mulhi_epu32(a, mul, elements);
                a = Xse.sub_epi32(a, hi);

                if (promises.NotOne)
                {
                    a = Xse.srli_epi32(a, 1);
                }
                else
                {
                    if (Avx2.IsAvx2Supported)
                    {
                        a = Avx2.srlv_epi32(a, Xse.add_epi32(Xse.cmpeq_epi32(original, Xse.set1_epi32(1)), Xse.set1_epi32(1)));
                    }
                    else
                    {
                        a = Xse.blendv_si128(Xse.srli_epi32(a, 1), a, Xse.cmpeq_epi32(original, Xse.set1_epi32(1)));
                    }
                }

                a = Xse.add_epi32(a, hi);
                a = Xse.srlv_epi32(a, shift, inRange: true, elements: elements);

                return a;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 msdiv_epu64(v128 a, v128 original, v128 mul, v128 shift, DividerPromise promises)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.ALL_EQ_EPU64(original, 1))
                {
                    return a;
                }

                v128 hi = Xse.mulhi_epu64(a, mul);
                a = Xse.sub_epi64(a, hi);

                if (promises.NotOne)
                {
                    a = Xse.srli_epi64(a, 1);
                }
                else
                {
                    a = Avx2.srlv_epi64(a, Xse.add_epi64(Xse.cmpeq_epi64(original, Xse.set1_epi64x(1)), Xse.set1_epi64x(1)));
                }

                a = Xse.add_epi64(a, hi);
                a = Avx2.srlv_epi64(a, shift);

                return a;
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_bmdiv_epu8(v256 a, v256 original, v256 mulLo, v256 mulHi, DividerPromise promise)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.ALL_EQ_EPU8(original, 1))
                {
                    return a;
                }

                v256 a16Lo = Xse.mm256_cvt2x2epu8_epi16(a, out v256 a16Hi);
                v256 lo = Avx2.mm256_mulhi_epu16(new v256(mulLo.Lo128, mulHi.Lo128), a16Lo);
                v256 hi = Avx2.mm256_mulhi_epu16(new v256(mulLo.Hi128, mulHi.Hi128), a16Hi);
                v256 q = Avx2.mm256_packus_epi16(lo, hi);

                if (!promise.NotOne)
                {
                    q = Xse.mm256_blendv_si256(q, a, Avx2.mm256_cmpeq_epi8(original, Xse.mm256_set1_epi8(1)));
                }

                return q;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_bmdiv_epu16(v256 a, v256 original, v256 mulLo, v256 mulHi, DividerPromise promise)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.ALL_EQ_EPU16(original, 1))
                {
                    return a;
                }

                v256 a16Lo = Xse.mm256_cvt2x2epu16_epi32(a, out v256 a16Hi);
                v256 lo = Xse.mm256_mulhi_epu32(new v256(mulLo.Lo128, mulHi.Lo128), a16Lo);
                v256 hi = Xse.mm256_mulhi_epu32(new v256(mulLo.Hi128, mulHi.Hi128), a16Hi);
                v256 q = Avx2.mm256_packus_epi32(lo, hi);

                if (!promise.NotOne)
                {
                    q = Xse.mm256_blendv_si256(q, a, Avx2.mm256_cmpeq_epi16(original, Xse.mm256_set1_epi16(1)));
                }

                return q;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_msdiv_epu32(v256 a, v256 original, v256 mul, v256 shift, DividerPromise promises)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.ALL_EQ_EPU32(original, 1))
                {
                    return a;
                }

                v256 hi = Xse.mm256_mulhi_epu32(a, mul);

                a = Avx2.mm256_sub_epi32(a, hi);

                if (promises.NotOne)
                {
                    a = Avx2.mm256_srli_epi32(a, 1);
                }
                else
                {
                    a = Avx2.mm256_srlv_epi32(a, Avx2.mm256_add_epi32(Avx2.mm256_cmpeq_epi32(original, Xse.mm256_set1_epi32(1)), Xse.mm256_set1_epi32(1)));
                }

                a = Avx2.mm256_add_epi32(a, hi);
                a = Avx2.mm256_srlv_epi32(a, shift);

                return a;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_msdiv_epu64(v256 a, v256 original, v256 mul, v256 shift, DividerPromise promises, byte elements = 4)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.ALL_EQ_EPU64(original, 1))
                {
                    return a;
                }

                v256 hi = Xse.mm256_mulhi_epu64(a, mul, elements);

                a = Avx2.mm256_sub_epi64(a, hi);

                if (promises.NotOne)
                {
                    a = Avx2.mm256_srli_epi64(a, 1);
                }
                else
                {
                    a = Avx2.mm256_srlv_epi64(a, Avx2.mm256_add_epi64(Avx2.mm256_cmpeq_epi64(original, Xse.mm256_set1_epi64x(1)), Xse.mm256_set1_epi64x(1)));
                }

                a = Avx2.mm256_add_epi64(a, hi);
                a = Avx2.mm256_srlv_epi64(a, shift);

                return a;
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 bmdiv_epu8_su8(v128 a, byte original, ushort mul, DividerPromise promise, byte elements = 16)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (!promise.NotOne)
                {
                    if (Hint.Unlikely(original == 1))
                    {
                        return a;
                    }
                }

                if (elements <= 8)
                {
                    v128 q = Xse.mulhi_epu16(Xse.set1_epi16(mul, elements), Xse.cvtepu8_epi16(a));

                    return Xse.packus_epi16(q, q);
                }
                else
                {
                    v128 a16Lo = Xse.cvt2x2epu8_epi16(a, out v128 a16Hi);
                    v128 lo = Xse.mulhi_epu16(Xse.set1_epi16(mul, elements), a16Lo);
                    v128 hi = Xse.mulhi_epu16(Xse.set1_epi16(mul, elements), a16Hi);

                    return Xse.packus_epi16(lo, hi);
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 msdiv_epu16_su16(v128 a, ushort original, ushort mul, ushort shift, DividerPromise promise, byte elements = 8)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (!promise.NotOne)
                {
                    if (Hint.Unlikely(original == 1))
                    {
                        return a;
                    }
                }

                v128 hi = Xse.mulhi_epu16(a, Xse.set1_epi16(mul, elements));

                a = Xse.sub_epi16(a, hi);
                a = Xse.srli_epi16(a, 1);
                a = Xse.add_epi16(a, hi);
                a = Xse.srli_epi16(a, shift, inRange: true);

                return a;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 msdiv_epu32_su32(v128 a, uint original, uint mul, uint shift, DividerPromise promise, byte elements = 4)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (!promise.NotOne)
                {
                    if (Hint.Unlikely(original == 1))
                    {
                        return a;
                    }
                }

                v128 hi;
                if (elements == 2)
                {
                    hi = Xse.shuffle_epi32(Xse.mul_epu32(Xse.cvtepu32_epi64(a), Xse.set1_epi64x(mul)), Sse.SHUFFLE(0, 0, 3, 1));
                }
                else
                {
                    hi = Xse.mulhi_epu32(a, Xse.set1_epi32(mul, elements), elements);
                }

                a = Xse.sub_epi32(a, hi);
                a = Xse.srli_epi32(a, 1);
                a = Xse.add_epi32(a, hi);
                a = Xse.srli_epi32(a, (int)shift, inRange: true);

                return a;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 msdiv_epu64_su64(v128 a, ulong original, ulong mul, ulong shift, DividerPromise promise)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (!promise.NotOne)
                {
                    if (Hint.Unlikely(original == 1))
                    {
                        return a;
                    }
                }

                v128 hi = Xse.mulhi_epu64(a, Xse.set1_epi64x(mul));

                a = Xse.sub_epi64(a, hi);
                a = Xse.srli_epi64(a, 1);
                a = Xse.add_epi64(a, hi);
                a = Xse.srli_epi64(a, (int)shift, inRange: true);

                return a;
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_bmdiv_epu8_su8(v256 a, byte original, ushort mul, DividerPromise promise)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (!promise.NotOne)
                {
                    if (Hint.Unlikely(original == 1))
                    {
                        return a;
                    }
                }

                v256 a16Lo = Xse.mm256_cvt2x2epu8_epi16(a, out v256 a16Hi);
                v256 lo = Avx2.mm256_mulhi_epu16(Xse.mm256_set1_epi16(mul), a16Lo);
                v256 hi = Avx2.mm256_mulhi_epu16(Xse.mm256_set1_epi16(mul), a16Hi);

                return Avx2.mm256_packus_epi16(lo, hi);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_msdiv_epu16_su16(v256 a, ushort original, ushort mul, ushort shift, DividerPromise promise)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (!promise.NotOne)
                {
                    if (Hint.Unlikely(original == 1))
                    {
                        return a;
                    }
                }

                v256 hi = Avx2.mm256_mulhi_epu16(a, Xse.mm256_set1_epi16(mul));

                a = Avx2.mm256_sub_epi16(a, hi);
                a = Avx2.mm256_srli_epi16(a, 1);
                a = Avx2.mm256_add_epi16(a, hi);
                a = Xse.mm256_srli_epi16(a, shift);

                return a;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_msdiv_epu32_su32(v256 a, uint original, uint mul, uint shift, DividerPromise promise)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (!promise.NotOne)
                {
                    if (Hint.Unlikely(original == 1))
                    {
                        return a;
                    }
                }

                v256 hi = Xse.mm256_mulhi_epu32(a, Xse.mm256_set1_epi32(mul));

                a = Avx2.mm256_sub_epi32(a, hi);
                a = Avx2.mm256_srli_epi32(a, 1);
                a = Avx2.mm256_add_epi32(a, hi);
                a = Xse.mm256_srli_epi32(a, (int)shift);

                return a;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_msdiv_epu64_su64(v256 a, ulong original, ulong mul, ulong shift, DividerPromise promise, byte elements = 4)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (!promise.NotOne)
                {
                    if (Hint.Unlikely(original == 1))
                    {
                        return a;
                    }
                }

                v256 hi = Xse.mm256_mulhi_epu64(a, Xse.mm256_set1_epi64x(mul), elements);

                a = Avx2.mm256_sub_epi64(a, hi);
                a = Avx2.mm256_srli_epi64(a, 1);
                a = Avx2.mm256_add_epi64(a, hi);
                a = Xse.mm256_srli_epi64(a, (int)shift);

                return a;
            }
            else throw new IllegalInstructionException();
        }
    }
}
