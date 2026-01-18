using System;
using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public partial struct Divider<T>
        where T : unmanaged, IEquatable<T>, IFormattable
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T operator % (byte x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(byte), 1, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            switch (sizeof(T))
            {
                case 32 * sizeof(byte): return ((byte32)x % d).Reinterpret<byte32, T>();
                case 16 * sizeof(byte): return ((byte16)x % d).Reinterpret<byte16, T>();
                case  8 * sizeof(byte): return ((byte8) x % d).Reinterpret<byte8,  T>();
                case  4 * sizeof(byte): return ((byte4) x % d).Reinterpret<byte4,  T>();
                case  3 * sizeof(byte): return ((byte3) x % d).Reinterpret<byte3,  T>();
                case  2 * sizeof(byte): return ((byte2) x % d).Reinterpret<byte2,  T>();
                default:
                {
                    if (d._promises.Pow2)
                    {
                        return pow2_rem_u8(x, *(byte*)&d._divisor).Reinterpret<byte, T>();
                    }
                    else
                    {
                        return bmrem_u8(x, *(byte*)&d._divisor, *(ushort*)&d._bigM).Reinterpret<byte, T>();
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 operator % (byte2 x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(byte), 2, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            if (d.DivideByScalar<byte2>())
            {
                if (d._promises.Pow2)
                {
                    byte divisor = *(byte*)&d._divisor;

                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return pow2_rem_epu8(x, Xse.set1_epi8(divisor), 2);
                    }
                    else
                    {
                        return new byte2(pow2_rem_u8(x.x, divisor),
                                         pow2_rem_u8(x.y, divisor));
                    }
                }
                else
                {
                    ushort mul = *(ushort*)&d._bigM;
                    byte divisor = *(byte*)&d._divisor;

                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return bmrem_epu8_su8(x, divisor, mul, 2);
                    }
                    else
                    {
                        return new byte2(bmrem_u8(x.x, divisor, mul),
                                         bmrem_u8(x.y, divisor, mul));
                    }
                }
            }
            else
            {
                if (d._promises.Pow2)
                {
                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return pow2_rem_epu8(x, d._divisor.Reinterpret<T, byte2>(), 2);
                    }
                    else
                    {
                        byte2 divisor = d._divisor.Reinterpret<T, byte2>();

                        return new byte2(pow2_rem_u8(x.x, divisor.x),
                                         pow2_rem_u8(x.y, divisor.y));
                    }
                }
                else
                {
                    ushort2 mul = *(ushort2*)&d._bigM;
                    byte2 divisor = *(byte2*)&d._divisor;

                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return bmrem_epu8(x, divisor, mul, 2);
                    }
                    else
                    {
                        return new byte2(bmrem_u8(x.x, divisor.x, mul.x),
                                         bmrem_u8(x.y, divisor.y, mul.y));
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 operator % (byte3 x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(byte), 3, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            if (d.DivideByScalar<byte3>())
            {
                if (d._promises.Pow2)
                {
                    byte divisor = *(byte*)&d._divisor;

                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return pow2_rem_epu8(x, Xse.set1_epi8(divisor), 3);
                    }
                    else
                    {
                        return new byte3(pow2_rem_u8(x.x, divisor),
                                         pow2_rem_u8(x.y, divisor),
                                         pow2_rem_u8(x.z, divisor));
                    }
                }
                else
                {
                    ushort mul = *(ushort*)&d._bigM;
                    byte divisor = *(byte*)&d._divisor;

                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return bmrem_epu8_su8(x, divisor, mul, 3);
                    }
                    else
                    {
                        return new byte3(bmrem_u8(x.x, divisor, mul),
                                         bmrem_u8(x.y, divisor, mul),
                                         bmrem_u8(x.z, divisor, mul));
                    }
                }
            }
            else
            {
                if (d._promises.Pow2)
                {
                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return pow2_rem_epu8(x, d._divisor.Reinterpret<T, byte3>(), 3);
                    }
                    else
                    {
                        byte3 divisor = d._divisor.Reinterpret<T, byte3>();

                        return new byte3(pow2_rem_u8(x.x, divisor.x),
                                         pow2_rem_u8(x.y, divisor.y),
                                         pow2_rem_u8(x.z, divisor.z));
                    }
                }
                else
                {
                    ushort3 mul = *(ushort3*)&d._bigM;
                    byte3 divisor = *(byte3*)&d._divisor;

                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return bmrem_epu8(x, divisor, mul, 3);
                    }
                    else
                    {
                        return new byte3(bmrem_u8(x.x, divisor.x, mul.x),
                                         bmrem_u8(x.y, divisor.y, mul.y),
                                         bmrem_u8(x.z, divisor.z, mul.z));
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 operator % (byte4 x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(byte), 4, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            if (d.DivideByScalar<byte4>())
            {
                if (d._promises.Pow2)
                {
                    byte divisor = *(byte*)&d._divisor;

                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return pow2_rem_epu8(x, Xse.set1_epi8(divisor), 4);
                    }
                    else
                    {
                        return new byte4(pow2_rem_u8(x.x, divisor),
                                         pow2_rem_u8(x.y, divisor),
                                         pow2_rem_u8(x.z, divisor),
                                         pow2_rem_u8(x.w, divisor));
                    }
                }
                else
                {
                    ushort mul = *(ushort*)&d._bigM;
                    byte divisor = *(byte*)&d._divisor;

                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return bmrem_epu8_su8(x, divisor, mul, 4);
                    }
                    else
                    {
                        return new byte4(bmrem_u8(x.x, divisor, mul),
                                         bmrem_u8(x.y, divisor, mul),
                                         bmrem_u8(x.z, divisor, mul),
                                         bmrem_u8(x.w, divisor, mul));
                    }
                }
            }
            else
            {
                if (d._promises.Pow2)
                {
                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return pow2_rem_epu8(x, d._divisor.Reinterpret<T, byte4>(), 4);
                    }
                    else
                    {
                        byte4 divisor = d._divisor.Reinterpret<T, byte4>();

                        return new byte4(pow2_rem_u8(x.x, divisor.x),
                                         pow2_rem_u8(x.y, divisor.y),
                                         pow2_rem_u8(x.z, divisor.z),
                                         pow2_rem_u8(x.w, divisor.w));
                    }
                }
                else
                {
                    ushort4 mul = *(ushort4*)&d._bigM;
                    byte4 divisor = *(byte4*)&d._divisor;

                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return bmrem_epu8(x, divisor, mul, 4);
                    }
                    else
                    {
                        return new byte4(bmrem_u8(x.x, divisor.x, mul.x),
                                         bmrem_u8(x.y, divisor.y, mul.y),
                                         bmrem_u8(x.z, divisor.z, mul.z),
                                         bmrem_u8(x.w, divisor.w, mul.w));
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 operator % (byte8 x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(byte), 8, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            if (d.DivideByScalar<byte8>())
            {
                if (d._promises.Pow2)
                {
                    byte divisor = *(byte*)&d._divisor;

                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return pow2_rem_epu8(x, Xse.set1_epi8(divisor), 8);
                    }
                    else
                    {
                        return new byte8(pow2_rem_u8(x.x0, divisor),
                                         pow2_rem_u8(x.x1, divisor),
                                         pow2_rem_u8(x.x2, divisor),
                                         pow2_rem_u8(x.x3, divisor),
                                         pow2_rem_u8(x.x4, divisor),
                                         pow2_rem_u8(x.x5, divisor),
                                         pow2_rem_u8(x.x6, divisor),
                                         pow2_rem_u8(x.x7, divisor));
                    }
                }
                else
                {
                    ushort mul = *(ushort*)&d._bigM;
                    byte divisor = *(byte*)&d._divisor;

                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return bmrem_epu8_su8(x, divisor, mul, 8);
                    }
                    else
                    {
                        return new byte8(bmrem_u8(x.x0, divisor, mul),
                                         bmrem_u8(x.x1, divisor, mul),
                                         bmrem_u8(x.x2, divisor, mul),
                                         bmrem_u8(x.x3, divisor, mul),
                                         bmrem_u8(x.x4, divisor, mul),
                                         bmrem_u8(x.x5, divisor, mul),
                                         bmrem_u8(x.x6, divisor, mul),
                                         bmrem_u8(x.x7, divisor, mul));
                    }
                }
            }
            else
            {
                if (d._promises.Pow2)
                {
                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return pow2_rem_epu8(x, d._divisor.Reinterpret<T, byte8>(), 8);
                    }
                    else
                    {
                        byte8 divisor = d._divisor.Reinterpret<T, byte8>();

                        return new byte8(pow2_rem_u8(x.x0, divisor.x0),
                                         pow2_rem_u8(x.x1, divisor.x1),
                                         pow2_rem_u8(x.x2, divisor.x2),
                                         pow2_rem_u8(x.x3, divisor.x3),
                                         pow2_rem_u8(x.x4, divisor.x4),
                                         pow2_rem_u8(x.x5, divisor.x5),
                                         pow2_rem_u8(x.x6, divisor.x6),
                                         pow2_rem_u8(x.x7, divisor.x7));
                    }
                }
                else
                {
                    ushort8 mul = *(ushort8*)&d._bigM;
                    byte8 divisor = *(byte8*)&d._divisor;

                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return bmrem_epu8(x, divisor, mul, 8);
                    }
                    else
                    {
                        return new byte8(bmrem_u8(x.x0, divisor.x0, mul.x0),
                                         bmrem_u8(x.x1, divisor.x1, mul.x1),
                                         bmrem_u8(x.x2, divisor.x2, mul.x2),
                                         bmrem_u8(x.x3, divisor.x3, mul.x3),
                                         bmrem_u8(x.x4, divisor.x4, mul.x4),
                                         bmrem_u8(x.x5, divisor.x5, mul.x5),
                                         bmrem_u8(x.x6, divisor.x6, mul.x6),
                                         bmrem_u8(x.x7, divisor.x7, mul.x7));
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 operator % (byte16 x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(byte), 16, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            if (d.DivideByScalar<byte16>())
            {
                if (d._promises.Pow2)
                {
                    byte divisor = *(byte*)&d._divisor;

                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return pow2_rem_epu8(x, Xse.set1_epi8(divisor));
                    }
                    else
                    {
                        return new byte16(pow2_rem_u8(x.x0,  divisor),
                                          pow2_rem_u8(x.x1,  divisor),
                                          pow2_rem_u8(x.x2,  divisor),
                                          pow2_rem_u8(x.x3,  divisor),
                                          pow2_rem_u8(x.x4,  divisor),
                                          pow2_rem_u8(x.x5,  divisor),
                                          pow2_rem_u8(x.x6,  divisor),
                                          pow2_rem_u8(x.x7,  divisor),
                                          pow2_rem_u8(x.x8,  divisor),
                                          pow2_rem_u8(x.x9,  divisor),
                                          pow2_rem_u8(x.x10, divisor),
                                          pow2_rem_u8(x.x11, divisor),
                                          pow2_rem_u8(x.x12, divisor),
                                          pow2_rem_u8(x.x13, divisor),
                                          pow2_rem_u8(x.x14, divisor),
                                          pow2_rem_u8(x.x15, divisor));
                    }
                }
                else
                {
                    ushort mul = *(ushort*)&d._bigM;
                    byte divisor = *(byte*)&d._divisor;

                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return bmrem_epu8_su8(x, divisor, mul);
                    }
                    else
                    {
                        return new byte16(bmrem_u8(x.x0,  divisor, mul),
                                          bmrem_u8(x.x1,  divisor, mul),
                                          bmrem_u8(x.x2,  divisor, mul),
                                          bmrem_u8(x.x3,  divisor, mul),
                                          bmrem_u8(x.x4,  divisor, mul),
                                          bmrem_u8(x.x5,  divisor, mul),
                                          bmrem_u8(x.x6,  divisor, mul),
                                          bmrem_u8(x.x7,  divisor, mul),
                                          bmrem_u8(x.x8,  divisor, mul),
                                          bmrem_u8(x.x9,  divisor, mul),
                                          bmrem_u8(x.x10, divisor, mul),
                                          bmrem_u8(x.x11, divisor, mul),
                                          bmrem_u8(x.x12, divisor, mul),
                                          bmrem_u8(x.x13, divisor, mul),
                                          bmrem_u8(x.x14, divisor, mul),
                                          bmrem_u8(x.x15, divisor, mul));
                    }
                }
            }
            else
            {
                if (d._promises.Pow2)
                {
                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return pow2_rem_epu8(x, d._divisor.Reinterpret<T, byte16>());
                    }
                    else
                    {
                        byte16 divisor = d._divisor.Reinterpret<T, byte16>();

                        return new byte16(pow2_rem_u8(x.x0,  divisor.x0),
                                          pow2_rem_u8(x.x1,  divisor.x1),
                                          pow2_rem_u8(x.x2,  divisor.x2),
                                          pow2_rem_u8(x.x3,  divisor.x3),
                                          pow2_rem_u8(x.x4,  divisor.x4),
                                          pow2_rem_u8(x.x5,  divisor.x5),
                                          pow2_rem_u8(x.x6,  divisor.x6),
                                          pow2_rem_u8(x.x7,  divisor.x7),
                                          pow2_rem_u8(x.x8,  divisor.x8),
                                          pow2_rem_u8(x.x9,  divisor.x9),
                                          pow2_rem_u8(x.x10, divisor.x10),
                                          pow2_rem_u8(x.x11, divisor.x11),
                                          pow2_rem_u8(x.x12, divisor.x12),
                                          pow2_rem_u8(x.x13, divisor.x13),
                                          pow2_rem_u8(x.x14, divisor.x14),
                                          pow2_rem_u8(x.x15, divisor.x15));
                    }
                }
                else
                {
                    ushort16 mul = *(ushort16*)&d._bigM;
                    byte16 divisor = *(byte16*)&d._divisor;

                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return bmrem_epu8(x, divisor, mul.v8_0, mul.v8_8);
                    }
                    else
                    {
                        return new byte16(bmrem_u8(x.x0,  divisor.x0,  mul.v8_0.x0),
                                          bmrem_u8(x.x1,  divisor.x1,  mul.v8_0.x1),
                                          bmrem_u8(x.x2,  divisor.x2,  mul.v8_0.x2),
                                          bmrem_u8(x.x3,  divisor.x3,  mul.v8_0.x3),
                                          bmrem_u8(x.x4,  divisor.x4,  mul.v8_0.x4),
                                          bmrem_u8(x.x5,  divisor.x5,  mul.v8_0.x5),
                                          bmrem_u8(x.x6,  divisor.x6,  mul.v8_0.x6),
                                          bmrem_u8(x.x7,  divisor.x7,  mul.v8_0.x7),
                                          bmrem_u8(x.x8,  divisor.x8,  mul.v8_8.x0),
                                          bmrem_u8(x.x9,  divisor.x9,  mul.v8_8.x1),
                                          bmrem_u8(x.x10, divisor.x10, mul.v8_8.x2),
                                          bmrem_u8(x.x11, divisor.x11, mul.v8_8.x3),
                                          bmrem_u8(x.x12, divisor.x12, mul.v8_8.x4),
                                          bmrem_u8(x.x13, divisor.x13, mul.v8_8.x5),
                                          bmrem_u8(x.x14, divisor.x14, mul.v8_8.x6),
                                          bmrem_u8(x.x15, divisor.x15, mul.v8_8.x7));
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 operator % (byte32 x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(byte), 32, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            if (d.DivideByScalar<byte32>())
            {
                if (d._promises.Pow2)
                {
                    byte divisor = *(byte*)&d._divisor;

                    if (Avx2.IsAvx2Supported)
                    {
                        return mm256_pow2_rem_epu8(x, Xse.mm256_set1_epi8(divisor));
                    }
                    else if (BurstArchitecture.IsSIMDSupported)
                    {
                        return new byte32(pow2_rem_epu8(x.v16_0, Xse.set1_epi8(divisor)), pow2_rem_epu8(x.v16_16, Xse.set1_epi8(divisor)));
                    }
                    else
                    {
                        return new byte32(pow2_rem_u8(x.x0,  divisor),
                                          pow2_rem_u8(x.x1,  divisor),
                                          pow2_rem_u8(x.x2,  divisor),
                                          pow2_rem_u8(x.x3,  divisor),
                                          pow2_rem_u8(x.x4,  divisor),
                                          pow2_rem_u8(x.x5,  divisor),
                                          pow2_rem_u8(x.x6,  divisor),
                                          pow2_rem_u8(x.x7,  divisor),
                                          pow2_rem_u8(x.x8,  divisor),
                                          pow2_rem_u8(x.x9,  divisor),
                                          pow2_rem_u8(x.x10, divisor),
                                          pow2_rem_u8(x.x11, divisor),
                                          pow2_rem_u8(x.x12, divisor),
                                          pow2_rem_u8(x.x13, divisor),
                                          pow2_rem_u8(x.x14, divisor),
                                          pow2_rem_u8(x.x15, divisor),
                                          pow2_rem_u8(x.x16, divisor),
                                          pow2_rem_u8(x.x17, divisor),
                                          pow2_rem_u8(x.x18, divisor),
                                          pow2_rem_u8(x.x19, divisor),
                                          pow2_rem_u8(x.x20, divisor),
                                          pow2_rem_u8(x.x21, divisor),
                                          pow2_rem_u8(x.x22, divisor),
                                          pow2_rem_u8(x.x23, divisor),
                                          pow2_rem_u8(x.x24, divisor),
                                          pow2_rem_u8(x.x25, divisor),
                                          pow2_rem_u8(x.x26, divisor),
                                          pow2_rem_u8(x.x27, divisor),
                                          pow2_rem_u8(x.x28, divisor),
                                          pow2_rem_u8(x.x29, divisor),
                                          pow2_rem_u8(x.x30, divisor),
                                          pow2_rem_u8(x.x31, divisor));
                    }
                }
                else
                {
                    ushort mul = *(ushort*)&d._bigM;
                    byte divisor = *(byte*)&d._divisor;

                    if (Avx2.IsAvx2Supported)
                    {
                        return mm256_bmrem_epu8_su8(x, divisor, mul);
                    }
                    else if (BurstArchitecture.IsSIMDSupported)
                    {
                        return new byte32(bmrem_epu8_su8(x.v16_0,  divisor, mul),
                                          bmrem_epu8_su8(x.v16_16, divisor, mul));
                    }
                    else
                    {
                        return new byte32(bmrem_u8(x.x0,  divisor, mul),
                                          bmrem_u8(x.x1,  divisor, mul),
                                          bmrem_u8(x.x2,  divisor, mul),
                                          bmrem_u8(x.x3,  divisor, mul),
                                          bmrem_u8(x.x4,  divisor, mul),
                                          bmrem_u8(x.x5,  divisor, mul),
                                          bmrem_u8(x.x6,  divisor, mul),
                                          bmrem_u8(x.x7,  divisor, mul),
                                          bmrem_u8(x.x8,  divisor, mul),
                                          bmrem_u8(x.x9,  divisor, mul),
                                          bmrem_u8(x.x10, divisor, mul),
                                          bmrem_u8(x.x11, divisor, mul),
                                          bmrem_u8(x.x12, divisor, mul),
                                          bmrem_u8(x.x13, divisor, mul),
                                          bmrem_u8(x.x14, divisor, mul),
                                          bmrem_u8(x.x15, divisor, mul),
                                          bmrem_u8(x.x16, divisor, mul),
                                          bmrem_u8(x.x17, divisor, mul),
                                          bmrem_u8(x.x18, divisor, mul),
                                          bmrem_u8(x.x19, divisor, mul),
                                          bmrem_u8(x.x20, divisor, mul),
                                          bmrem_u8(x.x21, divisor, mul),
                                          bmrem_u8(x.x22, divisor, mul),
                                          bmrem_u8(x.x23, divisor, mul),
                                          bmrem_u8(x.x24, divisor, mul),
                                          bmrem_u8(x.x25, divisor, mul),
                                          bmrem_u8(x.x26, divisor, mul),
                                          bmrem_u8(x.x27, divisor, mul),
                                          bmrem_u8(x.x28, divisor, mul),
                                          bmrem_u8(x.x29, divisor, mul),
                                          bmrem_u8(x.x30, divisor, mul),
                                          bmrem_u8(x.x31, divisor, mul));
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
                        return mm256_pow2_rem_epu8(x, divisor);
                    }
                    else if (BurstArchitecture.IsSIMDSupported)
                    {
                        return new byte32(pow2_rem_epu8(x.v16_0, divisor.v16_0), pow2_rem_epu8(x.v16_16, divisor.v16_16));
                    }
                    else
                    {
                        return new byte32(pow2_rem_u8(x.x0,  divisor.x0),
                                          pow2_rem_u8(x.x1,  divisor.x1),
                                          pow2_rem_u8(x.x2,  divisor.x2),
                                          pow2_rem_u8(x.x3,  divisor.x3),
                                          pow2_rem_u8(x.x4,  divisor.x4),
                                          pow2_rem_u8(x.x5,  divisor.x5),
                                          pow2_rem_u8(x.x6,  divisor.x6),
                                          pow2_rem_u8(x.x7,  divisor.x7),
                                          pow2_rem_u8(x.x8,  divisor.x8),
                                          pow2_rem_u8(x.x9,  divisor.x9),
                                          pow2_rem_u8(x.x10, divisor.x10),
                                          pow2_rem_u8(x.x11, divisor.x11),
                                          pow2_rem_u8(x.x12, divisor.x12),
                                          pow2_rem_u8(x.x13, divisor.x13),
                                          pow2_rem_u8(x.x14, divisor.x14),
                                          pow2_rem_u8(x.x15, divisor.x15),
                                          pow2_rem_u8(x.x16, divisor.x16),
                                          pow2_rem_u8(x.x17, divisor.x17),
                                          pow2_rem_u8(x.x18, divisor.x18),
                                          pow2_rem_u8(x.x19, divisor.x19),
                                          pow2_rem_u8(x.x20, divisor.x20),
                                          pow2_rem_u8(x.x21, divisor.x21),
                                          pow2_rem_u8(x.x22, divisor.x22),
                                          pow2_rem_u8(x.x23, divisor.x23),
                                          pow2_rem_u8(x.x24, divisor.x24),
                                          pow2_rem_u8(x.x25, divisor.x25),
                                          pow2_rem_u8(x.x26, divisor.x26),
                                          pow2_rem_u8(x.x27, divisor.x27),
                                          pow2_rem_u8(x.x28, divisor.x28),
                                          pow2_rem_u8(x.x29, divisor.x29),
                                          pow2_rem_u8(x.x30, divisor.x30),
                                          pow2_rem_u8(x.x31, divisor.x31));
                    }
                }
                else
                {
                    ushort16 mulLo = *(ushort16*)&d._bigM._mulLo;
                    ushort16 mulHi = *(ushort16*)&d._bigM._mulHi;
                    byte32 divisor = *(byte32*)&d._divisor;

                    if (Avx2.IsAvx2Supported)
                    {
                        return mm256_bmrem_epu8(x, divisor, mulLo, mulHi);
                    }
                    else if (BurstArchitecture.IsSIMDSupported)
                    {
                        return new byte32(bmrem_epu8(x.v16_0,  divisor.v16_0,  mulLo.v8_0, mulLo.v8_8),
                                          bmrem_epu8(x.v16_16, divisor.v16_16, mulHi.v8_0, mulHi.v8_8));
                    }
                    else
                    {
                        return new byte32(bmrem_u8(x.x0,  divisor.x0,  mulLo.x0),
                                          bmrem_u8(x.x1,  divisor.x1,  mulLo.x1),
                                          bmrem_u8(x.x2,  divisor.x2,  mulLo.x2),
                                          bmrem_u8(x.x3,  divisor.x3,  mulLo.x3),
                                          bmrem_u8(x.x4,  divisor.x4,  mulLo.x4),
                                          bmrem_u8(x.x5,  divisor.x5,  mulLo.x5),
                                          bmrem_u8(x.x6,  divisor.x6,  mulLo.x6),
                                          bmrem_u8(x.x7,  divisor.x7,  mulLo.x7),
                                          bmrem_u8(x.x8,  divisor.x8,  mulLo.x8),
                                          bmrem_u8(x.x9,  divisor.x9,  mulLo.x9),
                                          bmrem_u8(x.x10, divisor.x10, mulLo.x10),
                                          bmrem_u8(x.x11, divisor.x11, mulLo.x11),
                                          bmrem_u8(x.x12, divisor.x12, mulLo.x12),
                                          bmrem_u8(x.x13, divisor.x13, mulLo.x13),
                                          bmrem_u8(x.x14, divisor.x14, mulLo.x14),
                                          bmrem_u8(x.x15, divisor.x15, mulLo.x15),
                                          bmrem_u8(x.x16, divisor.x16, mulHi.x0),
                                          bmrem_u8(x.x17, divisor.x17, mulHi.x1),
                                          bmrem_u8(x.x18, divisor.x18, mulHi.x2),
                                          bmrem_u8(x.x19, divisor.x19, mulHi.x3),
                                          bmrem_u8(x.x20, divisor.x20, mulHi.x4),
                                          bmrem_u8(x.x21, divisor.x21, mulHi.x5),
                                          bmrem_u8(x.x22, divisor.x22, mulHi.x6),
                                          bmrem_u8(x.x23, divisor.x23, mulHi.x7),
                                          bmrem_u8(x.x24, divisor.x24, mulHi.x8),
                                          bmrem_u8(x.x25, divisor.x25, mulHi.x9),
                                          bmrem_u8(x.x26, divisor.x26, mulHi.x10),
                                          bmrem_u8(x.x27, divisor.x27, mulHi.x11),
                                          bmrem_u8(x.x28, divisor.x28, mulHi.x12),
                                          bmrem_u8(x.x29, divisor.x29, mulHi.x13),
                                          bmrem_u8(x.x30, divisor.x30, mulHi.x14),
                                          bmrem_u8(x.x31, divisor.x31, mulHi.x15));
                    }
                }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T operator % (ushort x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(ushort), 1, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            switch (sizeof(T))
            {
                case 16 * sizeof(ushort): return ((ushort16)x % d).Reinterpret<ushort16, T>();
                case  8 * sizeof(ushort): return ((ushort8) x % d).Reinterpret<ushort8,  T>();
                case  4 * sizeof(ushort): return ((ushort4) x % d).Reinterpret<ushort4,  T>();
                case  3 * sizeof(ushort): return ((ushort3) x % d).Reinterpret<ushort3,  T>();
                case  2 * sizeof(ushort): return ((ushort2) x % d).Reinterpret<ushort2,  T>();
                default:
                {
                    if (d._promises.Pow2)
                    {
                        return pow2_rem_u16(x, *(ushort*)&d._divisor).Reinterpret<ushort, T>();
                    }
                    else
                    {
                        return bmrem_u16(x, *(ushort*)&d._divisor, *(uint*)&d._bigM).Reinterpret<ushort, T>();
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator % (ushort2 x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(ushort), 2, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            if (d.DivideByScalar<ushort2>())
            {
                if (d._promises.Pow2)
                {
                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return pow2_rem_epu16(x, Xse.set1_epi16(*(ushort*)&d._divisor, 2), 2);
                    }
                    else
                    {
                        ushort divisor = *(ushort*)&d._divisor;

                        return new ushort2(pow2_rem_u16(x.x, divisor),
                                           pow2_rem_u16(x.y, divisor));
                    }
                }
                else
                {
                    uint mul = *(uint*)&d._bigM;
                    ushort divisor = *(ushort*)&d._divisor;

                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return bmrem_epu16_su16(x, divisor, mul, 2);
                    }
                    else
                    {
                        return new ushort2(bmrem_u16(x.x, divisor, mul),
                                           bmrem_u16(x.y, divisor, mul));
                    }
                }
            }
            else
            {
                if (d._promises.Pow2)
                {
                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return pow2_rem_epu16(x, d._divisor.Reinterpret<T, ushort2>(), 2);
                    }
                    else
                    {
                        ushort2 divisor = d._divisor.Reinterpret<T, ushort2>();

                        return new ushort2(pow2_rem_u16(x.x, divisor.x),
                                           pow2_rem_u16(x.y, divisor.y));
                    }
                }
                else
                {
                    uint2 mul = *(uint2*)&d._bigM;
                    ushort2 divisor = *(ushort2*)&d._divisor;

                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return bmrem_epu16(x, divisor, RegisterConversion.ToV128(mul), 2);
                    }
                    else
                    {
                        return new ushort2(bmrem_u16(x.x, divisor.x, mul.x),
                                           bmrem_u16(x.y, divisor.y, mul.y));
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator % (ushort3 x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(ushort), 3, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            if (d.DivideByScalar<ushort3>())
            {
                if (d._promises.Pow2)
                {
                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return pow2_rem_epu16(x, Xse.set1_epi16(*(ushort*)&d._divisor, 3), 3);
                    }
                    else
                    {
                        ushort divisor = *(ushort*)&d._divisor;

                        return new ushort3(pow2_rem_u16(x.x, divisor),
                                           pow2_rem_u16(x.y, divisor),
                                           pow2_rem_u16(x.z, divisor));
                    }
                }
                else
                {
                    uint mul = *(uint*)&d._bigM;
                    ushort divisor = *(ushort*)&d._divisor;

                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return bmrem_epu16_su16(x, divisor, mul, 3);
                    }
                    else
                    {
                        return new ushort3(bmrem_u16(x.x, divisor, mul),
                                           bmrem_u16(x.y, divisor, mul),
                                           bmrem_u16(x.z, divisor, mul));
                    }
                }
            }
            else
            {
                if (d._promises.Pow2)
                {
                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return pow2_rem_epu16(x, d._divisor.Reinterpret<T, ushort3>(), 3);
                    }
                    else
                    {
                        ushort3 divisor = d._divisor.Reinterpret<T, ushort3>();

                        return new ushort3(pow2_rem_u16(x.x, divisor.x),
                                           pow2_rem_u16(x.y, divisor.y),
                                           pow2_rem_u16(x.z, divisor.z));
                    }
                }
                else
                {
                    uint3 mul = *(uint3*)&d._bigM;
                    ushort3 divisor = *(ushort3*)&d._divisor;

                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return bmrem_epu16(x, divisor, RegisterConversion.ToV128(mul), 3);
                    }
                    else
                    {
                        return new ushort3(bmrem_u16(x.x, divisor.x, mul.x),
                                           bmrem_u16(x.y, divisor.y, mul.y),
                                           bmrem_u16(x.z, divisor.z, mul.z));
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator % (ushort4 x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(ushort), 4, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            if (d.DivideByScalar<ushort4>())
            {
                if (d._promises.Pow2)
                {
                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return pow2_rem_epu16(x, Xse.set1_epi16(*(ushort*)&d._divisor, 4), 4);
                    }
                    else
                    {
                        ushort divisor = *(ushort*)&d._divisor;

                        return new ushort4(pow2_rem_u16(x.x, divisor),
                                           pow2_rem_u16(x.y, divisor),
                                           pow2_rem_u16(x.z, divisor),
                                           pow2_rem_u16(x.w, divisor));
                    }
                }
                else
                {
                    uint mul = *(uint*)&d._bigM;
                    ushort divisor = *(ushort*)&d._divisor;

                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return bmrem_epu16_su16(x, divisor, mul, 4);
                    }
                    else
                    {
                        return new ushort4(bmrem_u16(x.x, divisor, mul),
                                           bmrem_u16(x.y, divisor, mul),
                                           bmrem_u16(x.z, divisor, mul),
                                           bmrem_u16(x.w, divisor, mul));
                    }
                }
            }
            else
            {
                if (d._promises.Pow2)
                {
                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return pow2_rem_epu16(x, d._divisor.Reinterpret<T, ushort4>(), 4);
                    }
                    else
                    {
                        ushort4 divisor = d._divisor.Reinterpret<T, ushort4>();

                        return new ushort4(pow2_rem_u16(x.x, divisor.x),
                                           pow2_rem_u16(x.y, divisor.y),
                                           pow2_rem_u16(x.z, divisor.z),
                                           pow2_rem_u16(x.w, divisor.w));
                    }
                }
                else
                {
                    uint4 mul = *(uint4*)&d._bigM;
                    ushort4 divisor = *(ushort4*)&d._divisor;

                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return bmrem_epu16(x, divisor, RegisterConversion.ToV128(mul), 4);
                    }
                    else
                    {
                        return new ushort4(bmrem_u16(x.x, divisor.x, mul.x),
                                           bmrem_u16(x.y, divisor.y, mul.y),
                                           bmrem_u16(x.z, divisor.z, mul.z),
                                           bmrem_u16(x.w, divisor.w, mul.w));
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator % (ushort8 x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(ushort), 8, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            if (d.DivideByScalar<ushort8>())
            {
                if (d._promises.Pow2)
                {
                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return pow2_rem_epu16(x, Xse.set1_epi16(*(ushort*)&d._divisor));
                    }
                    else
                    {
                        ushort divisor = *(ushort*)&d._divisor;

                        return new ushort8(pow2_rem_u16(x.x0, divisor),
                                           pow2_rem_u16(x.x1, divisor),
                                           pow2_rem_u16(x.x2, divisor),
                                           pow2_rem_u16(x.x3, divisor),
                                           pow2_rem_u16(x.x4, divisor),
                                           pow2_rem_u16(x.x5, divisor),
                                           pow2_rem_u16(x.x6, divisor),
                                           pow2_rem_u16(x.x7, divisor));
                    }
                }
                else
                {
                    uint mul = *(uint*)&d._bigM;
                    ushort divisor = *(ushort*)&d._divisor;

                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return bmrem_epu16_su16(x, divisor, mul);
                    }
                    else
                    {
                        return new ushort8(bmrem_u16(x.x0, divisor, mul),
                                           bmrem_u16(x.x1, divisor, mul),
                                           bmrem_u16(x.x2, divisor, mul),
                                           bmrem_u16(x.x3, divisor, mul),
                                           bmrem_u16(x.x4, divisor, mul),
                                           bmrem_u16(x.x5, divisor, mul),
                                           bmrem_u16(x.x6, divisor, mul),
                                           bmrem_u16(x.x7, divisor, mul));
                    }
                }
            }
            else
            {
                if (d._promises.Pow2)
                {
                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return pow2_rem_epu16(x, d._divisor.Reinterpret<T, ushort8>());
                    }
                    else
                    {
                        ushort8 divisor = d._divisor.Reinterpret<T, ushort8>();

                        return new ushort8(pow2_rem_u16(x.x0, divisor.x0),
                                           pow2_rem_u16(x.x1, divisor.x1),
                                           pow2_rem_u16(x.x2, divisor.x2),
                                           pow2_rem_u16(x.x3, divisor.x3),
                                           pow2_rem_u16(x.x4, divisor.x4),
                                           pow2_rem_u16(x.x5, divisor.x5),
                                           pow2_rem_u16(x.x6, divisor.x6),
                                           pow2_rem_u16(x.x7, divisor.x7));
                    }
                }
                else
                {
                    uint4 mulLo = *(uint4*)&d._bigM._mulLo;
                    uint4 mulHi = *(uint4*)&d._bigM._mulHi;
                    ushort8 divisor = *(ushort8*)&d._divisor;

                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return bmrem_epu16(x, divisor, RegisterConversion.ToV128(mulLo), RegisterConversion.ToV128(mulHi));
                    }
                    else
                    {
                        return new ushort8(bmrem_u16(x.x0, divisor.x0, mulLo.x),
                                           bmrem_u16(x.x1, divisor.x1, mulLo.y),
                                           bmrem_u16(x.x2, divisor.x2, mulLo.z),
                                           bmrem_u16(x.x3, divisor.x3, mulLo.w),
                                           bmrem_u16(x.x4, divisor.x4, mulHi.x),
                                           bmrem_u16(x.x5, divisor.x5, mulHi.y),
                                           bmrem_u16(x.x6, divisor.x6, mulHi.z),
                                           bmrem_u16(x.x7, divisor.x7, mulHi.w));
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 operator % (ushort16 x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(ushort), 16, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            if (d.DivideByScalar<ushort16>())
            {
                if (d._promises.Pow2)
                {
                    ushort divisor = *(ushort*)&d._divisor;

                    if (Avx2.IsAvx2Supported)
                    {
                        return mm256_pow2_rem_epu16(x, Xse.mm256_set1_epi16(divisor));
                    }
                    else if (BurstArchitecture.IsSIMDSupported)
                    {
                        return new ushort16(pow2_rem_epu16(x.v8_0, Xse.set1_epi16(divisor)), pow2_rem_epu16(x.v8_8, Xse.set1_epi16(divisor)));
                    }
                    else
                    {
                        return new ushort16(pow2_rem_u16(x.x0,  divisor),
                                            pow2_rem_u16(x.x1,  divisor),
                                            pow2_rem_u16(x.x2,  divisor),
                                            pow2_rem_u16(x.x3,  divisor),
                                            pow2_rem_u16(x.x4,  divisor),
                                            pow2_rem_u16(x.x5,  divisor),
                                            pow2_rem_u16(x.x6,  divisor),
                                            pow2_rem_u16(x.x7,  divisor),
                                            pow2_rem_u16(x.x8,  divisor),
                                            pow2_rem_u16(x.x9,  divisor),
                                            pow2_rem_u16(x.x10, divisor),
                                            pow2_rem_u16(x.x11, divisor),
                                            pow2_rem_u16(x.x12, divisor),
                                            pow2_rem_u16(x.x13, divisor),
                                            pow2_rem_u16(x.x14, divisor),
                                            pow2_rem_u16(x.x15, divisor));
                    }
                }
                else
                {
                    uint mul = *(uint*)&d._bigM;
                    ushort divisor = *(ushort*)&d._divisor;

                    if (Avx2.IsAvx2Supported)
                    {
                        return mm256_bmrem_epu16_su16(x, divisor, mul);
                    }
                    else if (BurstArchitecture.IsSIMDSupported)
                    {
                        return new ushort16(bmrem_epu16_su16(x.v8_0, divisor, mul),
                                            bmrem_epu16_su16(x.v8_8, divisor, mul));
                    }
                    else
                    {
                        return new ushort16(bmrem_u16(x.x0,  divisor, mul),
                                            bmrem_u16(x.x1,  divisor, mul),
                                            bmrem_u16(x.x2,  divisor, mul),
                                            bmrem_u16(x.x3,  divisor, mul),
                                            bmrem_u16(x.x4,  divisor, mul),
                                            bmrem_u16(x.x5,  divisor, mul),
                                            bmrem_u16(x.x6,  divisor, mul),
                                            bmrem_u16(x.x7,  divisor, mul),
                                            bmrem_u16(x.x8,  divisor, mul),
                                            bmrem_u16(x.x9,  divisor, mul),
                                            bmrem_u16(x.x10, divisor, mul),
                                            bmrem_u16(x.x11, divisor, mul),
                                            bmrem_u16(x.x12, divisor, mul),
                                            bmrem_u16(x.x13, divisor, mul),
                                            bmrem_u16(x.x14, divisor, mul),
                                            bmrem_u16(x.x15, divisor, mul));
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
                        return mm256_pow2_rem_epu16(x, divisor);
                    }
                    else if (BurstArchitecture.IsSIMDSupported)
                    {
                        return new ushort16(pow2_rem_epu16(x.v8_0, divisor.v8_0), pow2_rem_epu16(x.v8_8, divisor.v8_8));
                    }
                    else
                    {
                        return new ushort16(pow2_rem_u16(x.x0,  divisor.x0),
                                            pow2_rem_u16(x.x1,  divisor.x1),
                                            pow2_rem_u16(x.x2,  divisor.x2),
                                            pow2_rem_u16(x.x3,  divisor.x3),
                                            pow2_rem_u16(x.x4,  divisor.x4),
                                            pow2_rem_u16(x.x5,  divisor.x5),
                                            pow2_rem_u16(x.x6,  divisor.x6),
                                            pow2_rem_u16(x.x7,  divisor.x7),
                                            pow2_rem_u16(x.x8,  divisor.x8),
                                            pow2_rem_u16(x.x9,  divisor.x9),
                                            pow2_rem_u16(x.x10, divisor.x10),
                                            pow2_rem_u16(x.x11, divisor.x11),
                                            pow2_rem_u16(x.x12, divisor.x12),
                                            pow2_rem_u16(x.x13, divisor.x13),
                                            pow2_rem_u16(x.x14, divisor.x14),
                                            pow2_rem_u16(x.x15, divisor.x15));
                    }
                }
                else
                {
                    uint8 mulLo = *(uint8*)&d._bigM._mulLo;
                    uint8 mulHi = *(uint8*)&d._bigM._mulHi;
                    ushort16 divisor = *(ushort16*)&d._divisor;

                    if (Avx2.IsAvx2Supported)
                    {
                        return mm256_bmrem_epu16(x, divisor, mulLo, mulHi);
                    }
                    else if (BurstArchitecture.IsSIMDSupported)
                    {
                        return new ushort16(bmrem_epu16(x.v8_0, divisor.v8_0, RegisterConversion.ToV128(mulLo.v4_0), RegisterConversion.ToV128(mulLo.v4_4)),
                                            bmrem_epu16(x.v8_8, divisor.v8_8, RegisterConversion.ToV128(mulHi.v4_0), RegisterConversion.ToV128(mulHi.v4_4)));
                    }
                    else
                    {
                        return new ushort16(bmrem_u16(x.x0,  divisor.x0,  mulLo.x0),
                                            bmrem_u16(x.x1,  divisor.x1,  mulLo.x1),
                                            bmrem_u16(x.x2,  divisor.x2,  mulLo.x2),
                                            bmrem_u16(x.x3,  divisor.x3,  mulLo.x3),
                                            bmrem_u16(x.x4,  divisor.x4,  mulLo.x4),
                                            bmrem_u16(x.x5,  divisor.x5,  mulLo.x5),
                                            bmrem_u16(x.x6,  divisor.x6,  mulLo.x6),
                                            bmrem_u16(x.x7,  divisor.x7,  mulLo.x7),
                                            bmrem_u16(x.x8,  divisor.x8,  mulHi.x0),
                                            bmrem_u16(x.x9,  divisor.x9,  mulHi.x1),
                                            bmrem_u16(x.x10, divisor.x10, mulHi.x2),
                                            bmrem_u16(x.x11, divisor.x11, mulHi.x3),
                                            bmrem_u16(x.x12, divisor.x12, mulHi.x4),
                                            bmrem_u16(x.x13, divisor.x13, mulHi.x5),
                                            bmrem_u16(x.x14, divisor.x14, mulHi.x6),
                                            bmrem_u16(x.x15, divisor.x15, mulHi.x7));
                    }
                }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T operator % (uint x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(uint), 1, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            switch (sizeof(T))
            {
                case 8 * sizeof(uint): return ((uint8)x % d).Reinterpret<uint8, T>();
                case 4 * sizeof(uint): return ((uint4)x % d).Reinterpret<uint4, T>();
                case 3 * sizeof(uint): return ((uint3)x % d).Reinterpret<uint3, T>();
                case 2 * sizeof(uint): return ((uint2)x % d).Reinterpret<uint2, T>();
                default:
                {
                    if (d._promises.Pow2)
                    {
                        return pow2_rem_u32(x, *(uint*)&d._divisor).Reinterpret<uint, T>();
                    }
                    else
                    {
                        return bmrem_u32(x, *(uint*)&d._divisor, *(ulong*)&d._bigM).Reinterpret<uint, T>();
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator % (uint2 x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(uint), 2, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            if (d.DivideByScalar<uint2>())
            {
                if (d._promises.Pow2)
                {
                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return RegisterConversion.ToUInt2(pow2_rem_epu32(RegisterConversion.ToV128(x), Xse.set1_epi32(*(uint*)&d._divisor), 2));
                    }
                    else
                    {
                        uint divisor = *(uint*)&d._divisor;

                        return new uint2(pow2_rem_u32(x.x, divisor),
                                         pow2_rem_u32(x.y, divisor));
                    }
                }
                else
                {
                    uint divisor = *(uint*)&d._divisor;

                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        uint mul = *(uint*)&d._mulShift._mul;
                        uint shift = *(uint*)&d._mulShift._shift;

                        return RegisterConversion.ToUInt2(msrem_epu32_su32(RegisterConversion.ToV128(x), divisor, mul, shift, d._promises, 2));
                    }
                    else
                    {
                        ulong mul = *(ulong*)&d._bigM;

                        return new uint2(bmrem_u32(x.x, divisor, mul),
                                         bmrem_u32(x.y, divisor, mul));
                    }
                }
            }
            else
            {
                if (d._promises.Pow2)
                {
                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return RegisterConversion.ToUInt2(pow2_rem_epu32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(d._divisor.Reinterpret<T, uint2>()), 2));
                    }
                    else
                    {
                        uint2 divisor = d._divisor.Reinterpret<T, uint2>();

                        return new uint2(pow2_rem_u32(x.x, divisor.x),
                                         pow2_rem_u32(x.y, divisor.y));
                    }
                }
                else
                {
                    uint2 divisor = *(uint2*)&d._divisor;

                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        uint2 mul = *(uint2*)&d._mulShift._mul;
                        uint2 shift = *(uint2*)&d._mulShift._shift;

                        return RegisterConversion.ToUInt2(msrem_epu32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(divisor), RegisterConversion.ToV128(mul), RegisterConversion.ToV128(shift), d._promises, 2));
                    }
                    else
                    {
                        ulong2 mul = *(ulong2*)&d._bigM;

                        return new uint2(bmrem_u32(x.x, divisor.x, mul.x),
                                         bmrem_u32(x.y, divisor.y, mul.y));
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator % (uint3 x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(uint), 3, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            if (d.DivideByScalar<uint3>())
            {
                if (d._promises.Pow2)
                {
                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return RegisterConversion.ToUInt3(pow2_rem_epu32(RegisterConversion.ToV128(x), Xse.set1_epi32(*(uint*)&d._divisor), 3));
                    }
                    else
                    {
                        uint divisor = *(uint*)&d._divisor;

                        return new uint3(pow2_rem_u32(x.x, divisor),
                                         pow2_rem_u32(x.y, divisor),
                                         pow2_rem_u32(x.z, divisor));
                    }
                }
                else
                {
                    uint divisor = *(uint*)&d._divisor;

                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        uint mul = *(uint*)&d._mulShift._mul;
                        uint shift = *(uint*)&d._mulShift._shift;

                        return RegisterConversion.ToUInt3(msrem_epu32_su32(RegisterConversion.ToV128(x), divisor, mul, shift, d._promises, 3));
                    }
                    else
                    {
                        ulong mul = *(ulong*)&d._bigM;

                        return new uint3(bmrem_u32(x.x, divisor, mul),
                                         bmrem_u32(x.y, divisor, mul),
                                         bmrem_u32(x.z, divisor, mul));
                    }
                }
            }
            else
            {
                if (d._promises.Pow2)
                {
                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return RegisterConversion.ToUInt3(pow2_rem_epu32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(d._divisor.Reinterpret<T, uint3>()), 3));
                    }
                    else
                    {
                        uint3 divisor = d._divisor.Reinterpret<T, uint3>();

                        return new uint3(pow2_rem_u32(x.x, divisor.x),
                                         pow2_rem_u32(x.y, divisor.y),
                                         pow2_rem_u32(x.z, divisor.z));
                    }
                }
                else
                {
                    uint3 divisor = *(uint3*)&d._divisor;

                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        uint3 mul = *(uint3*)&d._mulShift._mul;
                        uint3 shift = *(uint3*)&d._mulShift._shift;

                        return RegisterConversion.ToUInt3(msrem_epu32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(divisor), RegisterConversion.ToV128(mul), RegisterConversion.ToV128(shift), d._promises, 3));
                    }
                    else
                    {
                        ulong3 mul = *(ulong3*)&d._bigM;

                        return new uint3(bmrem_u32(x.x, divisor.x, mul.x),
                                         bmrem_u32(x.y, divisor.y, mul.y),
                                         bmrem_u32(x.z, divisor.z, mul.z));
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 operator % (uint4 x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(uint), 4, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            if (d.DivideByScalar<uint4>())
            {
                if (d._promises.Pow2)
                {
                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return RegisterConversion.ToUInt4(pow2_rem_epu32(RegisterConversion.ToV128(x), Xse.set1_epi32(*(uint*)&d._divisor)));
                    }
                    else
                    {
                        uint divisor = *(uint*)&d._divisor;

                        return new uint4(pow2_rem_u32(x.x, divisor),
                                         pow2_rem_u32(x.y, divisor),
                                         pow2_rem_u32(x.z, divisor),
                                         pow2_rem_u32(x.w, divisor));
                    }
                }
                else
                {
                    uint divisor = *(uint*)&d._divisor;

                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        uint mul = *(uint*)&d._mulShift._mul;
                        uint shift = *(uint*)&d._mulShift._shift;

                        return RegisterConversion.ToUInt4(msrem_epu32_su32(RegisterConversion.ToV128(x), divisor, mul, shift, d._promises, 4));
                    }
                    else
                    {
                        ulong mul = *(ulong*)&d._bigM;

                        return new uint4(bmrem_u32(x.x, divisor, mul),
                                         bmrem_u32(x.y, divisor, mul),
                                         bmrem_u32(x.z, divisor, mul),
                                         bmrem_u32(x.w, divisor, mul));
                    }
                }
            }
            else
            {
                if (d._promises.Pow2)
                {
                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return RegisterConversion.ToUInt4(pow2_rem_epu32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(d._divisor.Reinterpret<T, uint4>())));
                    }
                    else
                    {
                        uint4 divisor = d._divisor.Reinterpret<T, uint4>();

                        return new uint4(pow2_rem_u32(x.x, divisor.x),
                                         pow2_rem_u32(x.y, divisor.y),
                                         pow2_rem_u32(x.z, divisor.z),
                                         pow2_rem_u32(x.w, divisor.w));
                    }
                }
                else
                {
                    uint4 divisor = *(uint4*)&d._divisor;

                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        uint4 mul = *(uint4*)&d._mulShift._mul;
                        uint4 shift = *(uint4*)&d._mulShift._shift;

                        return RegisterConversion.ToUInt4(msrem_epu32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(divisor), RegisterConversion.ToV128(mul), RegisterConversion.ToV128(shift), d._promises, 4));
                    }
                    else
                    {
                        ulong4 mul = *(ulong4*)&d._bigM;

                        return new uint4(bmrem_u32(x.x, divisor.x, mul.x),
                                         bmrem_u32(x.y, divisor.y, mul.y),
                                         bmrem_u32(x.z, divisor.z, mul.z),
                                         bmrem_u32(x.w, divisor.w, mul.w));
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 operator % (uint8 x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(uint), 8, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            if (d.DivideByScalar<uint8>())
            {
                if (d._promises.Pow2)
                {
                    uint divisor = *(uint*)&d._divisor;

                    if (Avx2.IsAvx2Supported)
                    {
                        return mm256_pow2_rem_epu32(x, Xse.mm256_set1_epi32(divisor));
                    }
                    else if (BurstArchitecture.IsSIMDSupported)
                    {
                        return new uint8(RegisterConversion.ToUInt4(pow2_rem_epu32(RegisterConversion.ToV128(x.v4_0), Xse.set1_epi32(divisor))),
                                         RegisterConversion.ToUInt4(pow2_rem_epu32(RegisterConversion.ToV128(x.v4_4), Xse.set1_epi32(divisor))));
                    }
                    else
                    {
                        return new uint8(pow2_rem_u32(x.x0, divisor),
                                         pow2_rem_u32(x.x1, divisor),
                                         pow2_rem_u32(x.x2, divisor),
                                         pow2_rem_u32(x.x3, divisor),
                                         pow2_rem_u32(x.x4, divisor),
                                         pow2_rem_u32(x.x5, divisor),
                                         pow2_rem_u32(x.x6, divisor),
                                         pow2_rem_u32(x.x7, divisor));
                    }
                }
                else
                {
                    uint mul = *(uint*)&d._mulShift._mul;
                    uint shift = *(uint*)&d._mulShift._shift;
                    uint divisor = *(uint*)&d._divisor;

                    if (Avx2.IsAvx2Supported)
                    {
                        return mm256_msrem_epu32_su32(x, divisor, mul, shift, d._promises);
                    }
                    else if (BurstArchitecture.IsSIMDSupported)
                    {
                        return new uint8(RegisterConversion.ToUInt4(msrem_epu32_su32(RegisterConversion.ToV128(x.v4_0), divisor, mul, shift, d._promises)),
                                         RegisterConversion.ToUInt4(msrem_epu32_su32(RegisterConversion.ToV128(x.v4_4), divisor, mul, shift, d._promises)));
                    }
                    else
                    {
                        ulong mul64 = *(ulong*)&d._bigM;

                        return new uint8(bmrem_u32(x.x0, divisor, mul64),
                                         bmrem_u32(x.x1, divisor, mul64),
                                         bmrem_u32(x.x2, divisor, mul64),
                                         bmrem_u32(x.x3, divisor, mul64),
                                         bmrem_u32(x.x4, divisor, mul64),
                                         bmrem_u32(x.x5, divisor, mul64),
                                         bmrem_u32(x.x6, divisor, mul64),
                                         bmrem_u32(x.x7, divisor, mul64));
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
                        return mm256_pow2_rem_epu32(x, divisor);
                    }
                    else if (BurstArchitecture.IsSIMDSupported)
                    {
                        return new uint8(RegisterConversion.ToUInt4(pow2_rem_epu32(RegisterConversion.ToV128(x.v4_0), RegisterConversion.ToV128(divisor.v4_0))),
                                         RegisterConversion.ToUInt4(pow2_rem_epu32(RegisterConversion.ToV128(x.v4_4), RegisterConversion.ToV128(divisor.v4_4))));
                    }
                    else
                    {
                        return new uint8(pow2_rem_u32(x.x0, divisor.x0),
                                         pow2_rem_u32(x.x1, divisor.x1),
                                         pow2_rem_u32(x.x2, divisor.x2),
                                         pow2_rem_u32(x.x3, divisor.x3),
                                         pow2_rem_u32(x.x4, divisor.x4),
                                         pow2_rem_u32(x.x5, divisor.x5),
                                         pow2_rem_u32(x.x6, divisor.x6),
                                         pow2_rem_u32(x.x7, divisor.x7));
                    }
                }
                else
                {
                    uint8 mul = *(uint8*)&d._mulShift._mul;
                    uint8 shift = *(uint8*)&d._mulShift._shift;
                    uint8 divisor = *(uint8*)&d._divisor;

                    if (Avx2.IsAvx2Supported)
                    {
                        return mm256_msrem_epu32(x, divisor, mul, shift, d._promises);
                    }
                    else if (BurstArchitecture.IsSIMDSupported)
                    {
                        return new uint8(RegisterConversion.ToUInt4(msrem_epu32(RegisterConversion.ToV128(x.v4_0), RegisterConversion.ToV128(divisor.v4_0), RegisterConversion.ToV128(mul.v4_0), RegisterConversion.ToV128(shift.v4_0), d._promises)),
                                         RegisterConversion.ToUInt4(msrem_epu32(RegisterConversion.ToV128(x.v4_4), RegisterConversion.ToV128(divisor.v4_4), RegisterConversion.ToV128(mul.v4_4), RegisterConversion.ToV128(shift.v4_4), d._promises)));
                    }
                    else
                    {
                        ulong4 mulLo = *(ulong4*)&d._bigM._mulLo;
                        ulong4 mulHi = *(ulong4*)&d._bigM._mulHi;

                        return new uint8(bmrem_u32(x.x0, divisor.x0, mulLo.x),
                                         bmrem_u32(x.x1, divisor.x1, mulLo.y),
                                         bmrem_u32(x.x2, divisor.x2, mulLo.z),
                                         bmrem_u32(x.x3, divisor.x3, mulLo.w),
                                         bmrem_u32(x.x4, divisor.x4, mulHi.x),
                                         bmrem_u32(x.x5, divisor.x5, mulHi.y),
                                         bmrem_u32(x.x6, divisor.x6, mulHi.z),
                                         bmrem_u32(x.x7, divisor.x7, mulHi.w));
                    }
                }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T operator % (ulong x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(ulong), 1, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            switch (sizeof(T))
            {
                case 4 * sizeof(ulong): return ((ulong4)x % d).Reinterpret<ulong4, T>();
                case 3 * sizeof(ulong): return ((ulong3)x % d).Reinterpret<ulong3, T>();
                case 2 * sizeof(ulong): return ((ulong2)x % d).Reinterpret<ulong2, T>();
                default:
                {
                    if (d._promises.Pow2)
                    {
                        return pow2_rem_u64(x, *(ulong*)&d._divisor).Reinterpret<ulong, T>();
                    }
                    else
                    {
                        return bmrem_u64(x, *(ulong*)&d._divisor, *(UInt128*)&d._bigM).Reinterpret<ulong, T>();
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator % (ulong2 x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(ulong), 2, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            if (d.DivideByScalar<ulong2>())
            {
                if (d._promises.Pow2)
                {
                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return pow2_rem_epu64(x, Xse.set1_epi64x(*(ulong*)&d._divisor));
                    }
                    else
                    {
                        ulong divisor = *(ulong*)&d._divisor;

                        return new ulong2(pow2_rem_u64(x.x, divisor),
                                          pow2_rem_u64(x.y, divisor));
                    }
                }
                else
                {
                    UInt128 mul = *(UInt128*)&d._bigM;
                    ulong divisor = *(ulong*)&d._divisor;

                    return new ulong2(bmrem_u64(x.x, divisor, mul),
                                      bmrem_u64(x.y, divisor, mul));
                }
            }
            else
            {
                if (d._promises.Pow2)
                {
                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return pow2_rem_epu64(x, d._divisor.Reinterpret<T, ulong2>());
                    }
                    else
                    {
                        ulong2 divisor = d._divisor.Reinterpret<T, ulong2>();

                        return new ulong2(pow2_rem_u64(x.x, divisor.x),
                                          pow2_rem_u64(x.y, divisor.y));
                    }
                }
                else
                {
                    UInt128 mul0 = *((UInt128*)&d._bigM + 0);
                    UInt128 mul1 = *((UInt128*)&d._bigM + 1);
                    ulong2 divisor = *(ulong2*)&d._divisor;

                    return new ulong2(bmrem_u64(x.x, divisor.x, mul0),
                                      bmrem_u64(x.y, divisor.y, mul1));
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator % (ulong3 x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(ulong), 3, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            if (d.DivideByScalar<ulong3>())
            {
                if (d._promises.Pow2)
                {
                    ulong divisor = *(ulong*)&d._divisor;

                    if (Avx2.IsAvx2Supported)
                    {
                        return mm256_pow2_rem_epu64(x, Xse.mm256_set1_epi64x(divisor), 3);
                    }
                    else if (BurstArchitecture.IsSIMDSupported)
                    {
                        return new ulong3(pow2_rem_epu64(x.xy, Xse.set1_epi64x(divisor)),
                                          pow2_rem_u64(x.z, divisor));
                    }
                    else
                    {
                        return new ulong3(pow2_rem_u64(x.x, divisor),
                                          pow2_rem_u64(x.y, divisor),
                                          pow2_rem_u64(x.z, divisor));
                    }
                }
                else
                {
                    if (Avx2.IsAvx2Supported)
                    {
                        ulong mul = *(ulong*)&d._mulShift._mul;
                        ulong shift = *(ulong*)&d._mulShift._shift;
                        ulong divisor = *(ulong*)&d._divisor;

                        return mm256_msrem_epu64_su64(x, divisor, mul, shift, d._promises, 3);
                    }
                    else
                    {
                        UInt128 mul = *(UInt128*)&d._bigM;
                        ulong divisor = *(ulong*)&d._divisor;

                        return new ulong3(bmrem_u64(x.x, divisor, mul),
                                          bmrem_u64(x.y, divisor, mul),
                                          bmrem_u64(x.z, divisor, mul));
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
                        return mm256_pow2_rem_epu64(x, divisor, 3);
                    }
                    else if (BurstArchitecture.IsSIMDSupported)
                    {
                        return new ulong3(pow2_rem_epu64(x.xy, divisor.xy),
                                          pow2_rem_u64(x.z, divisor.z));
                    }
                    else
                    {
                        return new ulong3(pow2_rem_u64(x.x, divisor.x),
                                          pow2_rem_u64(x.y, divisor.y),
                                          pow2_rem_u64(x.z, divisor.z));
                    }
                }
                else
                {
                    if (Avx2.IsAvx2Supported)
                    {
                        return mm256_msrem_epu64(x, *(ulong3*)&d._divisor, *(ulong3*)&d._mulShift._mul, *(ulong3*)&d._mulShift._shift, d._promises, 3);
                    }
                    else
                    {
                        UInt128 mul0 = *((UInt128*)&d._bigM + 0);
                        UInt128 mul1 = *((UInt128*)&d._bigM + 1);
                        UInt128 mul2 = *((UInt128*)&d._bigM + 2);
                        ulong3 divisor = *(ulong3*)&d._divisor;

                        return new ulong3(bmrem_u64(x.x, divisor.x, mul0),
                                          bmrem_u64(x.y, divisor.y, mul1),
                                          bmrem_u64(x.z, divisor.z, mul2));
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator % (ulong4 x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(ulong), 4, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            if (d.DivideByScalar<ulong4>())
            {
                if (d._promises.Pow2)
                {
                    ulong divisor = *(ulong*)&d._divisor;

                    if (Avx2.IsAvx2Supported)
                    {
                        return mm256_pow2_rem_epu64(x, Xse.mm256_set1_epi64x(divisor));
                    }
                    else if (BurstArchitecture.IsSIMDSupported)
                    {
                        return new ulong4(pow2_rem_epu64(x.xy, Xse.set1_epi64x(divisor)),
                                          pow2_rem_epu64(x.zw, Xse.set1_epi64x(divisor)));
                    }
                    else
                    {
                        return new ulong4(pow2_rem_u64(x.x, divisor),
                                          pow2_rem_u64(x.y, divisor),
                                          pow2_rem_u64(x.z, divisor),
                                          pow2_rem_u64(x.w, divisor));
                    }
                }
                else
                {
                    if (Avx2.IsAvx2Supported)
                    {
                        ulong mul = *(ulong*)&d._mulShift._mul;
                        ulong shift = *(ulong*)&d._mulShift._shift;
                        ulong divisor = *(ulong*)&d._divisor;

                        return mm256_msrem_epu64_su64(x, divisor, mul, shift, d._promises, 4);
                    }
                    else
                    {
                        UInt128 mul = *(UInt128*)&d._bigM;
                        ulong divisor = *(ulong*)&d._divisor;

                        return new ulong4(bmrem_u64(x.x, divisor, mul),
                                          bmrem_u64(x.y, divisor, mul),
                                          bmrem_u64(x.z, divisor, mul),
                                          bmrem_u64(x.w, divisor, mul));
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
                        return mm256_pow2_rem_epu64(x, divisor);
                    }
                    else if (BurstArchitecture.IsSIMDSupported)
                    {
                        return new ulong4(pow2_rem_epu64(x.xy, divisor.xy),
                                          pow2_rem_epu64(x.zw, divisor.zw));
                    }
                    else
                    {
                        return new ulong4(pow2_rem_u64(x.x, divisor.x),
                                          pow2_rem_u64(x.y, divisor.y),
                                          pow2_rem_u64(x.z, divisor.z),
                                          pow2_rem_u64(x.w, divisor.w));
                    }
                }
                else
                {
                    if (Avx2.IsAvx2Supported)
                    {
                        return mm256_msrem_epu64(x, *(ulong4*)&d._divisor, *(ulong4*)&d._mulShift._mul, *(ulong4*)&d._mulShift._shift, d._promises, 4);
                    }
                    else
                    {
                        UInt128 mul0 = *((UInt128*)&d._bigM + 0);
                        UInt128 mul1 = *((UInt128*)&d._bigM + 1);
                        UInt128 mul2 = *((UInt128*)&d._bigM + 2);
                        UInt128 mul3 = *((UInt128*)&d._bigM + 3);
                        ulong4 divisor = *(ulong4*)&d._divisor;

                        return new ulong4(bmrem_u64(x.x, divisor.x, mul0),
                                          bmrem_u64(x.y, divisor.y, mul1),
                                          bmrem_u64(x.z, divisor.z, mul2),
                                          bmrem_u64(x.w, divisor.w, mul3));
                    }
                }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator % (UInt128 x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(UInt128), 1, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            if (d._promises.Pow2)
            {
                return pow2_rem_u128(x, *(UInt128*)&d._divisor);
            }
            else
            {
                return msrem_u128(x, *(UInt128*)&d._divisor, *(UInt128*)&d._mulShift._mul, *(UInt128*)&d._mulShift._shift, d._promises);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static byte pow2_rem_u8(byte x, byte divisor)
        {
            byte result = (byte)(x & (divisor - 1));
            constexpr.ASSUME(result < divisor);
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ushort pow2_rem_u16(ushort x, ushort divisor)
        {
            ushort result = (ushort)(x & (divisor - 1));
            constexpr.ASSUME(result < divisor);
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint pow2_rem_u32(uint x, uint divisor)
        {
            uint result = x & (divisor - 1);
            constexpr.ASSUME(result < divisor);
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong pow2_rem_u64(ulong x, ulong divisor)
        {
            ulong result = x & (divisor - 1);
            constexpr.ASSUME(result < divisor);
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static UInt128 pow2_rem_u128(UInt128 x, UInt128 divisor)
        {
            UInt128 result = x & (divisor - 1);
            constexpr.ASSUME(result < divisor);
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 pow2_rem_epu8(v128 x, v128 divisor, byte elements = 16)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 result = Xse.and_si128(x, Xse.dec_epi8(divisor));
                constexpr.ASSUME_LT_EPU8(result, divisor, elements);
                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 pow2_rem_epu16(v128 x, v128 divisor, byte elements = 8)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 result = Xse.and_si128(x, Xse.dec_epi16(divisor));
                constexpr.ASSUME_LT_EPU16(result, divisor, elements);
                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 pow2_rem_epu32(v128 x, v128 divisor, byte elements = 4)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 result = Xse.and_si128(x, Xse.dec_epi32(divisor));
                constexpr.ASSUME_LT_EPU32(result, divisor, elements);
                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 pow2_rem_epu64(v128 x, v128 divisor)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 result = Xse.and_si128(x, Xse.dec_epi64(divisor));
                constexpr.ASSUME_LT_EPU64(result, divisor);
                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_pow2_rem_epu8(v256 x, v256 divisor)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 result = Avx2.mm256_and_si256(x, Xse.mm256_dec_epi8(divisor));
                constexpr.ASSUME_LT_EPU8(result, divisor);
                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_pow2_rem_epu16(v256 x, v256 divisor)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 result = Avx2.mm256_and_si256(x, Xse.mm256_dec_epi16(divisor));
                constexpr.ASSUME_LT_EPU16(result, divisor);
                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_pow2_rem_epu32(v256 x, v256 divisor)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 result = Avx2.mm256_and_si256(x, Xse.mm256_dec_epi32(divisor));
                constexpr.ASSUME_LT_EPU32(result, divisor);
                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_pow2_rem_epu64(v256 x, v256 divisor, byte elements = 4)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 result = Avx2.mm256_and_si256(x, Xse.mm256_dec_epi64(divisor));
                constexpr.ASSUME_LT_EPU64(result, divisor, elements);
                return result;
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static byte bmrem_u8(byte x, byte original, ushort mul)
        {
            byte result = (byte)(((ushort)((uint)mul * (uint)x) * (uint)original) >> 16);
            constexpr.ASSUME(result < original);
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ushort bmrem_u16(ushort x, ushort original, uint mul)
        {
            ushort result = (ushort)(((mul * x) * (ulong)original) >> 32);
            constexpr.ASSUME(result < original);
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint bmrem_u32(uint x, uint original, ulong mul)
        {
            uint result = (uint)UInt128.umul128(mul * x, original).hi64;
            constexpr.ASSUME(result < original);
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong bmrem_u64(ulong x, ulong original, UInt128 mul)
        {
            mul *= x;

            UInt128 lo = UInt128.umul128(mul.lo64, original);
            UInt128 hi = UInt128.umul128(mul.hi64, original);

            ulong result = (lo.hi64 + hi).hi64;
            constexpr.ASSUME(result < original);
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static UInt128 msrem_u128(UInt128 dividend, UInt128 original, UInt128 mul, UInt128 shift, DividerPromise promises)
        {
            UInt128 result = dividend - (msdiv_u128(dividend, original, mul, shift, promises) * original);
            constexpr.ASSUME(result < original);
            return result;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 bmrem_epu8(v128 d, v128 original, v128 mul, byte elements = 16)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 d16 = Xse.cvtepu8_epi16(d);
                v128 o16 = Xse.cvtepu8_epi16(original);

                v128 q = Xse.mulhi_epu16(Xse.mullo_epi16(mul, d16), o16);

                v128 result = Xse.packus_epi16(q, q);
                constexpr.ASSUME_LT_EPU8(result, original, elements);
                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 bmrem_epu16(v128 d, v128 original, v128 mul, byte elements = 4)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 d16 = Xse.cvtepu16_epi32(d);
                v128 o16 = Xse.cvtepu16_epi32(original);

                v128 q = Xse.mulhi_epu32(Xse.mullo_epi32(mul, d16, elements), o16, elements);

                v128 result;
                if (Sse4_1.IsSse41Supported)
                {
                    result = Xse.packus_epi32(q, q);
                }
                else
                {
                    result = Xse.cvtepi32_epi16(q, elements);
                }
                constexpr.ASSUME_LT_EPU16(result, original, elements);
                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 msrem_epu32(v128 a, v128 original, v128 mul, v128 shift, DividerPromise promises, byte elements = 4)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 result = Xse.sub_epi32(a, Xse.mullo_epi32(msdiv_epu32(a, original, mul, shift, promises, elements), original, elements));
                //constexpr.ASSUME_LT_EPU32(result, original, elements);
                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 msrem_epu64(v128 a, v128 original, v128 mul, v128 shift, DividerPromise promises)
        {
            if (Avx2.IsAvx2Supported)
            {
                v128 result = Xse.sub_epi64(a, Xse.mullo_epi64(msdiv_epu64(a, original, mul, shift, promises), original));
                constexpr.ASSUME_LT_EPU64(result, original);
                return result;
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 bmrem_epu8(v128 d, v128 original, v128 mulLo, v128 mulHi)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 d16Lo = Xse.cvt2x2epu8_epi16(d,        out v128 d16Hi);
                v128 o16Lo = Xse.cvt2x2epu8_epi16(original, out v128 o16Hi);

                v128 lo = Xse.mulhi_epu16(Xse.mullo_epi16(mulLo, d16Lo), o16Lo);
                v128 hi = Xse.mulhi_epu16(Xse.mullo_epi16(mulHi, d16Hi), o16Hi);

                v128 result = Xse.packus_epi16(lo, hi);
                constexpr.ASSUME_LT_EPU8(result, original);
                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 bmrem_epu16(v128 d, v128 original, v128 mulLo, v128 mulHi)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 d16Lo = Xse.cvt2x2epu16_epi32(d,        out v128 d16Hi);
                v128 o16Lo = Xse.cvt2x2epu16_epi32(original, out v128 o16Hi);

                v128 lo = Xse.mulhi_epu32(Xse.mullo_epi32(mulLo, d16Lo), o16Lo);
                v128 hi = Xse.mulhi_epu32(Xse.mullo_epi32(mulHi, d16Hi), o16Hi);

                v128 result;
                if (Sse4_1.IsSse41Supported)
                {
                    result = Xse.packus_epi32(lo, hi);
                }
                else
                {
                    result = Xse.cvt2x2epi32_epi16(lo, hi);
                }
                constexpr.ASSUME_LT_EPU16(result, original);
                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_bmrem_epu8(v256 d, v256 original, v256 mulLo, v256 mulHi)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 d16Lo = Xse.mm256_cvt2x2epu8_epi16(d,        out v256 d16Hi);
                v256 o16Lo = Xse.mm256_cvt2x2epu8_epi16(original, out v256 o16Hi);

                v256 lo = Avx2.mm256_mulhi_epu16(Avx2.mm256_mullo_epi16(new v256(mulLo.Lo128, mulHi.Lo128), d16Lo), o16Lo);
                v256 hi = Avx2.mm256_mulhi_epu16(Avx2.mm256_mullo_epi16(new v256(mulLo.Hi128, mulHi.Hi128), d16Hi), o16Hi);

                v256 result = Avx2.mm256_packus_epi16(lo, hi);
                constexpr.ASSUME_LT_EPU8(result, original);
                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_bmrem_epu16(v256 d, v256 original, v256 mulLo, v256 mulHi)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 d16Lo = Xse.mm256_cvt2x2epu16_epi32(d,        out v256 d16Hi);
                v256 o16Lo = Xse.mm256_cvt2x2epu16_epi32(original, out v256 o16Hi);

                v256 lo = Xse.mm256_mulhi_epu32(Avx2.mm256_mullo_epi32(new v256(mulLo.Lo128, mulHi.Lo128), d16Lo), o16Lo);
                v256 hi = Xse.mm256_mulhi_epu32(Avx2.mm256_mullo_epi32(new v256(mulLo.Hi128, mulHi.Hi128), d16Hi), o16Hi);

                v256 result = Avx2.mm256_packus_epi32(lo, hi);
                constexpr.ASSUME_LT_EPU16(result, original);
                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_msrem_epu32(v256 a, v256 original, v256 mul, v256 shift, DividerPromise promises)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 result = Avx2.mm256_sub_epi32(a, Avx2.mm256_mullo_epi32(mm256_msdiv_epu32(a, original, mul, shift, promises), original));
                constexpr.ASSUME_LT_EPU32(result, original);
                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_msrem_epu64(v256 a, v256 original, v256 mul, v256 shift, DividerPromise promises, byte elements = 4)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 result = Avx2.mm256_sub_epi64(a, Xse.mm256_mullo_epi64(mm256_msdiv_epu64(a, original, mul, shift, promises), original, elements));
                constexpr.ASSUME_LT_EPU64(result, original, elements);
                return result;
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 bmrem_epu8_su8(v128 d, byte original, ushort mul, byte elements = 16)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 result;
                if (elements <= 8)
                {
                    result = bmrem_epu8(d, Xse.set1_epi8(original, elements), Xse.set1_epi16(mul, elements), elements);
                }
                else
                {
                    result = bmrem_epu8(d, Xse.set1_epi8(original), Xse.set1_epi16(mul), Xse.set1_epi16(mul));
                }
                constexpr.ASSUME_LT_EPU8(result, original, elements);
                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 bmrem_epu16_su16(v128 d, ushort original, uint mul, byte elements = 8)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 result;
                if (elements <= 4)
                {
                    result = bmrem_epu16(d, Xse.set1_epi16(original, elements), Xse.set1_epi32(mul, elements));
                }
                else
                {
                    result = bmrem_epu16(d, Xse.set1_epi16(original), Xse.set1_epi32(mul), Xse.set1_epi32(mul));
                }
                constexpr.ASSUME_LT_EPU16(result, original, elements);
                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 msrem_epu32_su32(v128 d, uint original, uint mul, uint shift, DividerPromise promises, byte elements = 4)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 result = Xse.sub_epi32(d, Xse.mullo_epi32(msdiv_epu32_su32(d, original, mul, shift, promises, elements), Xse.set1_epi32(original), elements));
                constexpr.ASSUME_LT_EPU32(result, original, elements);
                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 msrem_epu64_su64(v128 d, ulong original, ulong mul, ulong shift, DividerPromise promises)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 result = Xse.sub_epi64(d, Xse.mullo_epi64(msdiv_epu64_su64(d, original, mul, shift, promises), Xse.set1_epi64x(original)));
                constexpr.ASSUME_LT_EPU64(result, original);
                return result;
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_bmrem_epu8_su8(v256 d, byte original, ushort mul)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 d16Lo = Xse.mm256_cvt2x2epu8_epi16(d, out v256 d16Hi);
                v256 o = Xse.mm256_set1_epi16(original);

                v256 lo = Avx2.mm256_mulhi_epu16(Avx2.mm256_mullo_epi16(Xse.mm256_set1_epi16(mul), d16Lo), o);
                v256 hi = Avx2.mm256_mulhi_epu16(Avx2.mm256_mullo_epi16(Xse.mm256_set1_epi16(mul), d16Hi), o);

                v256 result = Avx2.mm256_packus_epi16(lo, hi);
                constexpr.ASSUME_LT_EPU8(result, original);
                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_bmrem_epu16_su16(v256 d, ushort original, uint mul)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 d16Lo = Xse.mm256_cvt2x2epu16_epi32(d, out v256 d16Hi);
                v256 o = Xse.mm256_set1_epi32(original);

                v256 lo = Xse.mm256_mulhi_epu32(Avx2.mm256_mullo_epi32(Xse.mm256_set1_epi32(mul), d16Lo), o);
                v256 hi = Xse.mm256_mulhi_epu32(Avx2.mm256_mullo_epi32(Xse.mm256_set1_epi32(mul), d16Hi), o);

                v256 result = Avx2.mm256_packus_epi32(lo, hi);
                constexpr.ASSUME_LT_EPU16(result, original);
                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_msrem_epu32_su32(v256 d, uint original, uint mul, uint shift, DividerPromise promises)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 result = Avx2.mm256_sub_epi32(d, Avx2.mm256_mullo_epi32(mm256_msdiv_epu32_su32(d, original, mul, shift, promises), Xse.mm256_set1_epi32(original)));
                constexpr.ASSUME_LT_EPU32(result, original);
                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_msrem_epu64_su64(v256 d, ulong original, ulong mul, ulong shift, DividerPromise promises, byte elements = 4)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 result = Avx2.mm256_sub_epi64(d, Xse.mm256_mullo_epi64(mm256_msdiv_epu64_su64(d, original, mul, shift, promises, elements), Xse.mm256_set1_epi64x(original), elements));
                constexpr.ASSUME_LT_EPU64(result, original, elements);
                return result;
            }
            else throw new IllegalInstructionException();
        }
    }
}
