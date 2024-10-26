using System;
using System.Runtime.CompilerServices;
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
        public static T operator / (sbyte x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(sbyte), 1, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            switch (sizeof(T))
            {
                case 32 * sizeof(sbyte): return ((sbyte32)x / d).Reinterpret<sbyte32, T>();
                case 16 * sizeof(sbyte): return ((sbyte16)x / d).Reinterpret<sbyte16, T>();
                case  8 * sizeof(sbyte): return ((sbyte8) x / d).Reinterpret<sbyte8,  T>();
                case  4 * sizeof(sbyte): return ((sbyte4) x / d).Reinterpret<sbyte4,  T>();
                case  3 * sizeof(sbyte): return ((sbyte3) x / d).Reinterpret<sbyte3,  T>();
                case  2 * sizeof(sbyte): return ((sbyte2) x / d).Reinterpret<sbyte2,  T>();
                default:
                {
                    if (d._promises.Pow2)
                    {
                        return pow2div_i8(x, d._divisor.Reinterpret<T, sbyte>(), d._promises).Reinterpret<sbyte, T>();
                    }
                    else
                    {
                        return bmdiv_i8(x, *(ushort*)&d._bigM, *(sbyte*)&d._divisor, d._promises).Reinterpret<sbyte, T>();
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator / (sbyte2 x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(sbyte), 2, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            if (d.DivideByScalar<sbyte2>())
            {
                sbyte divisor = *(sbyte*)&d._divisor;

                if (d._promises.Pow2)
                {
                    if (Architecture.IsSIMDSupported)
                    {
                        return pow2div_epi8_si8(x, divisor, d._promises);
                    }
                    else
                    {
                        return new sbyte2(pow2div_i8(x.x, divisor, d._promises),
                                          pow2div_i8(x.y, divisor, d._promises));
                    }
                }
                else
                {
                    ushort mul = *(ushort*)&d._bigM;

                    if (Architecture.IsSIMDSupported)
                    {
                        return bmdiv_epi8_si8(x, mul, divisor, d._promises, 2);
                    }
                    else
                    {
                        return new sbyte2(bmdiv_i8(x.x, mul, divisor, d._promises),
                                          bmdiv_i8(x.y, mul, divisor, d._promises));
                    }
                }
            }
            else
            {
                sbyte2 divisor = *(sbyte2*)&d._divisor;

                if (d._promises.Pow2)
                {
                    if (Architecture.IsSIMDSupported)
                    {
                        return pow2div_epi8(x, divisor, d._promises, 2);
                    }
                    else
                    {
                        return new sbyte2(pow2div_i8(x.x, divisor.x, d._promises),
                                          pow2div_i8(x.y, divisor.y, d._promises));
                    }
                }
                else
                {
                    ushort2 mul = *(ushort2*)&d._bigM;

                    if (Architecture.IsSIMDSupported)
                    {
                        return bmdiv_epi8(x, mul, divisor, d._promises, 2);
                    }
                    else
                    {
                        return new sbyte2(bmdiv_i8(x.x, mul.x, divisor.x, d._promises),
                                          bmdiv_i8(x.y, mul.y, divisor.y, d._promises));
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 operator / (sbyte3 x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(sbyte), 3, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            if (d.DivideByScalar<sbyte3>())
            {
                sbyte divisor = *(sbyte*)&d._divisor;

                if (d._promises.Pow2)
                {
                    if (Architecture.IsSIMDSupported)
                    {
                        return pow2div_epi8_si8(x, divisor, d._promises);
                    }
                    else
                    {
                        return new sbyte3(pow2div_i8(x.x, divisor, d._promises),
                                          pow2div_i8(x.y, divisor, d._promises),
                                          pow2div_i8(x.z, divisor, d._promises));
                    }
                }
                else
                {
                    ushort mul = *(ushort*)&d._bigM;

                    if (Architecture.IsSIMDSupported)
                    {
                        return bmdiv_epi8_si8(x, mul, divisor, d._promises, 3);
                    }
                    else
                    {
                        return new sbyte3(bmdiv_i8(x.x, mul, divisor, d._promises),
                                          bmdiv_i8(x.y, mul, divisor, d._promises),
                                          bmdiv_i8(x.z, mul, divisor, d._promises));
                    }
                }
            }
            else
            {
                sbyte3 divisor = *(sbyte3*)&d._divisor;

                if (d._promises.Pow2)
                {
                    if (Architecture.IsSIMDSupported)
                    {
                        return pow2div_epi8(x, divisor, d._promises, 3);
                    }
                    else
                    {
                        return new sbyte3(pow2div_i8(x.x, divisor.x, d._promises),
                                          pow2div_i8(x.y, divisor.y, d._promises),
                                          pow2div_i8(x.z, divisor.z, d._promises));
                    }
                }
                else
                {
                    ushort3 mul = *(ushort3*)&d._bigM;

                    if (Architecture.IsSIMDSupported)
                    {
                        return bmdiv_epi8(x, mul, divisor, d._promises, 3);
                    }
                    else
                    {
                        return new sbyte3(bmdiv_i8(x.x, mul.x, divisor.x, d._promises),
                                          bmdiv_i8(x.y, mul.y, divisor.y, d._promises),
                                          bmdiv_i8(x.z, mul.z, divisor.z, d._promises));
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 operator / (sbyte4 x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(sbyte), 4, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            if (d.DivideByScalar<sbyte4>())
            {
                sbyte divisor = *(sbyte*)&d._divisor;

                if (d._promises.Pow2)
                {
                    if (Architecture.IsSIMDSupported)
                    {
                        return pow2div_epi8_si8(x, divisor, d._promises);
                    }
                    else
                    {
                        return new sbyte4(pow2div_i8(x.x, divisor, d._promises),
                                          pow2div_i8(x.y, divisor, d._promises),
                                          pow2div_i8(x.z, divisor, d._promises),
                                          pow2div_i8(x.w, divisor, d._promises));
                    }
                }
                else
                {
                    ushort mul = *(ushort*)&d._bigM;

                    if (Architecture.IsSIMDSupported)
                    {
                        return bmdiv_epi8_si8(x, mul, divisor, d._promises, 4);
                    }
                    else
                    {
                        return new sbyte4(bmdiv_i8(x.x, mul, divisor, d._promises),
                                          bmdiv_i8(x.y, mul, divisor, d._promises),
                                          bmdiv_i8(x.z, mul, divisor, d._promises),
                                          bmdiv_i8(x.w, mul, divisor, d._promises));
                    }
                }
            }
            else
            {
                sbyte4 divisor = *(sbyte4*)&d._divisor;

                if (d._promises.Pow2)
                {
                    if (Architecture.IsSIMDSupported)
                    {
                        return pow2div_epi8(x, divisor, d._promises, 4);
                    }
                    else
                    {
                        return new sbyte4(pow2div_i8(x.x, divisor.x, d._promises),
                                          pow2div_i8(x.y, divisor.y, d._promises),
                                          pow2div_i8(x.z, divisor.z, d._promises),
                                          pow2div_i8(x.w, divisor.w, d._promises));
                    }
                }
                else
                {
                    ushort4 mul = *(ushort4*)&d._bigM;

                    if (Architecture.IsSIMDSupported)
                    {
                        return bmdiv_epi8(x, mul, divisor, d._promises, 4);
                    }
                    else
                    {
                        return new sbyte4(bmdiv_i8(x.x, mul.x, divisor.x, d._promises),
                                          bmdiv_i8(x.y, mul.y, divisor.y, d._promises),
                                          bmdiv_i8(x.z, mul.z, divisor.z, d._promises),
                                          bmdiv_i8(x.w, mul.w, divisor.w, d._promises));
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 operator / (sbyte8 x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(sbyte), 8, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            if (d.DivideByScalar<sbyte8>())
            {
                sbyte divisor = *(sbyte*)&d._divisor;

                if (d._promises.Pow2)
                {
                    if (Architecture.IsSIMDSupported)
                    {
                        return pow2div_epi8_si8(x, divisor, d._promises);
                    }
                    else
                    {
                        return new sbyte8(pow2div_i8(x.x0, divisor, d._promises),
                                          pow2div_i8(x.x1, divisor, d._promises),
                                          pow2div_i8(x.x2, divisor, d._promises),
                                          pow2div_i8(x.x3, divisor, d._promises),
                                          pow2div_i8(x.x4, divisor, d._promises),
                                          pow2div_i8(x.x5, divisor, d._promises),
                                          pow2div_i8(x.x6, divisor, d._promises),
                                          pow2div_i8(x.x7, divisor, d._promises));
                    }
                }
                else
                {
                    ushort mul = *(ushort*)&d._bigM;

                    if (Architecture.IsSIMDSupported)
                    {
                        return bmdiv_epi8_si8(x, mul, divisor, d._promises, 8);
                    }
                    else
                    {
                        return new sbyte8(bmdiv_i8(x.x0, mul, divisor, d._promises),
                                          bmdiv_i8(x.x1, mul, divisor, d._promises),
                                          bmdiv_i8(x.x2, mul, divisor, d._promises),
                                          bmdiv_i8(x.x3, mul, divisor, d._promises),
                                          bmdiv_i8(x.x4, mul, divisor, d._promises),
                                          bmdiv_i8(x.x5, mul, divisor, d._promises),
                                          bmdiv_i8(x.x6, mul, divisor, d._promises),
                                          bmdiv_i8(x.x7, mul, divisor, d._promises));
                    }
                }
            }
            else
            {
                sbyte8 divisor = *(sbyte8*)&d._divisor;

                if (d._promises.Pow2)
                {
                    if (Architecture.IsSIMDSupported)
                    {
                        return pow2div_epi8(x, divisor, d._promises, 8);
                    }
                    else
                    {
                        return new sbyte8(pow2div_i8(x.x0, divisor.x0, d._promises),
                                          pow2div_i8(x.x1, divisor.x1, d._promises),
                                          pow2div_i8(x.x2, divisor.x2, d._promises),
                                          pow2div_i8(x.x3, divisor.x3, d._promises),
                                          pow2div_i8(x.x4, divisor.x4, d._promises),
                                          pow2div_i8(x.x5, divisor.x5, d._promises),
                                          pow2div_i8(x.x6, divisor.x6, d._promises),
                                          pow2div_i8(x.x7, divisor.x7, d._promises));
                    }
                }
                else
                {
                    ushort8 mul = *(ushort8*)&d._bigM;

                    if (Architecture.IsSIMDSupported)
                    {
                        return bmdiv_epi8(x, mul, divisor, d._promises, 8);
                    }
                    else
                    {
                        return new sbyte8(bmdiv_i8(x.x0, mul.x0, divisor.x0, d._promises),
                                          bmdiv_i8(x.x1, mul.x1, divisor.x1, d._promises),
                                          bmdiv_i8(x.x2, mul.x2, divisor.x2, d._promises),
                                          bmdiv_i8(x.x3, mul.x3, divisor.x3, d._promises),
                                          bmdiv_i8(x.x4, mul.x4, divisor.x4, d._promises),
                                          bmdiv_i8(x.x5, mul.x5, divisor.x5, d._promises),
                                          bmdiv_i8(x.x6, mul.x6, divisor.x6, d._promises),
                                          bmdiv_i8(x.x7, mul.x7, divisor.x7, d._promises));
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 operator / (sbyte16 x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(sbyte), 16, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            if (d.DivideByScalar<sbyte16>())
            {
                sbyte divisor = *(sbyte*)&d._divisor;

                if (d._promises.Pow2)
                {
                    if (Architecture.IsSIMDSupported)
                    {
                        return pow2div_epi8_si8(x, divisor, d._promises);
                    }
                    else
                    {
                        return new sbyte16(pow2div_i8(x.x0,  divisor, d._promises),
                                           pow2div_i8(x.x1,  divisor, d._promises),
                                           pow2div_i8(x.x2,  divisor, d._promises),
                                           pow2div_i8(x.x3,  divisor, d._promises),
                                           pow2div_i8(x.x4,  divisor, d._promises),
                                           pow2div_i8(x.x5,  divisor, d._promises),
                                           pow2div_i8(x.x6,  divisor, d._promises),
                                           pow2div_i8(x.x7,  divisor, d._promises),
                                           pow2div_i8(x.x8,  divisor, d._promises),
                                           pow2div_i8(x.x9,  divisor, d._promises),
                                           pow2div_i8(x.x10, divisor, d._promises),
                                           pow2div_i8(x.x11, divisor, d._promises),
                                           pow2div_i8(x.x12, divisor, d._promises),
                                           pow2div_i8(x.x13, divisor, d._promises),
                                           pow2div_i8(x.x14, divisor, d._promises),
                                           pow2div_i8(x.x15, divisor, d._promises));
                    }
                }
                else
                {
                    ushort mul = *(ushort*)&d._bigM;

                    if (Architecture.IsSIMDSupported)
                    {
                        return bmdiv_epi8_si8(x, mul, divisor, d._promises);
                    }
                    else
                    {
                        return new sbyte16(bmdiv_i8(x.x0,  mul, divisor, d._promises),
                                           bmdiv_i8(x.x1,  mul, divisor, d._promises),
                                           bmdiv_i8(x.x2,  mul, divisor, d._promises),
                                           bmdiv_i8(x.x3,  mul, divisor, d._promises),
                                           bmdiv_i8(x.x4,  mul, divisor, d._promises),
                                           bmdiv_i8(x.x5,  mul, divisor, d._promises),
                                           bmdiv_i8(x.x6,  mul, divisor, d._promises),
                                           bmdiv_i8(x.x7,  mul, divisor, d._promises),
                                           bmdiv_i8(x.x8,  mul, divisor, d._promises),
                                           bmdiv_i8(x.x9,  mul, divisor, d._promises),
                                           bmdiv_i8(x.x10, mul, divisor, d._promises),
                                           bmdiv_i8(x.x11, mul, divisor, d._promises),
                                           bmdiv_i8(x.x12, mul, divisor, d._promises),
                                           bmdiv_i8(x.x13, mul, divisor, d._promises),
                                           bmdiv_i8(x.x14, mul, divisor, d._promises),
                                           bmdiv_i8(x.x15, mul, divisor, d._promises));
                    }
                }
            }
            else
            {
                sbyte16 divisor = *(sbyte16*)&d._divisor;

                if (d._promises.Pow2)
                {
                    if (Architecture.IsSIMDSupported)
                    {
                        return pow2div_epi8(x, divisor, d._promises, 16);
                    }
                    else
                    {
                        return new sbyte16(pow2div_i8(x.x0,  divisor.x0,  d._promises),
                                           pow2div_i8(x.x1,  divisor.x1,  d._promises),
                                           pow2div_i8(x.x2,  divisor.x2,  d._promises),
                                           pow2div_i8(x.x3,  divisor.x3,  d._promises),
                                           pow2div_i8(x.x4,  divisor.x4,  d._promises),
                                           pow2div_i8(x.x5,  divisor.x5,  d._promises),
                                           pow2div_i8(x.x6,  divisor.x6,  d._promises),
                                           pow2div_i8(x.x7,  divisor.x7,  d._promises),
                                           pow2div_i8(x.x8,  divisor.x8,  d._promises),
                                           pow2div_i8(x.x9,  divisor.x9,  d._promises),
                                           pow2div_i8(x.x10, divisor.x10, d._promises),
                                           pow2div_i8(x.x11, divisor.x11, d._promises),
                                           pow2div_i8(x.x12, divisor.x12, d._promises),
                                           pow2div_i8(x.x13, divisor.x13, d._promises),
                                           pow2div_i8(x.x14, divisor.x14, d._promises),
                                           pow2div_i8(x.x15, divisor.x15, d._promises));
                    }
                }
                else
                {
                    ushort16 mul = *(ushort16*)&d._bigM;

                    if (Architecture.IsSIMDSupported)
                    {
                        return bmdiv_epi8(x, mul.v8_0, mul.v8_8, divisor, d._promises);
                    }
                    else
                    {
                        return new sbyte16(bmdiv_i8(x.x0,  mul.v8_0.x0, divisor.x0,  d._promises),
                                           bmdiv_i8(x.x1,  mul.v8_0.x1, divisor.x1,  d._promises),
                                           bmdiv_i8(x.x2,  mul.v8_0.x2, divisor.x2,  d._promises),
                                           bmdiv_i8(x.x3,  mul.v8_0.x3, divisor.x3,  d._promises),
                                           bmdiv_i8(x.x4,  mul.v8_0.x4, divisor.x4,  d._promises),
                                           bmdiv_i8(x.x5,  mul.v8_0.x5, divisor.x5,  d._promises),
                                           bmdiv_i8(x.x6,  mul.v8_0.x6, divisor.x6,  d._promises),
                                           bmdiv_i8(x.x7,  mul.v8_0.x7, divisor.x7,  d._promises),
                                           bmdiv_i8(x.x8,  mul.v8_8.x0, divisor.x8,  d._promises),
                                           bmdiv_i8(x.x9,  mul.v8_8.x1, divisor.x9,  d._promises),
                                           bmdiv_i8(x.x10, mul.v8_8.x2, divisor.x10, d._promises),
                                           bmdiv_i8(x.x11, mul.v8_8.x3, divisor.x11, d._promises),
                                           bmdiv_i8(x.x12, mul.v8_8.x4, divisor.x12, d._promises),
                                           bmdiv_i8(x.x13, mul.v8_8.x5, divisor.x13, d._promises),
                                           bmdiv_i8(x.x14, mul.v8_8.x6, divisor.x14, d._promises),
                                           bmdiv_i8(x.x15, mul.v8_8.x7, divisor.x15, d._promises));
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 operator / (sbyte32 x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(sbyte), 32, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            if (d.DivideByScalar<sbyte32>())
            {
                sbyte divisor = *(sbyte*)&d._divisor;

                if (d._promises.Pow2)
                {
                    if (Avx2.IsAvx2Supported)
                    {
                        return mm256_pow2div_epi8_si8(x, divisor, d._promises);
                    }
                    else if (Architecture.IsSIMDSupported)
                    {
                        return new sbyte32(pow2div_epi8_si8(x.v16_0,  divisor, d._promises),
                                           pow2div_epi8_si8(x.v16_16, divisor, d._promises));
                    }
                    else
                    {
                        return new sbyte32(pow2div_i8(x.x0,  divisor, d._promises),
                                           pow2div_i8(x.x1,  divisor, d._promises),
                                           pow2div_i8(x.x2,  divisor, d._promises),
                                           pow2div_i8(x.x3,  divisor, d._promises),
                                           pow2div_i8(x.x4,  divisor, d._promises),
                                           pow2div_i8(x.x5,  divisor, d._promises),
                                           pow2div_i8(x.x6,  divisor, d._promises),
                                           pow2div_i8(x.x7,  divisor, d._promises),
                                           pow2div_i8(x.x8,  divisor, d._promises),
                                           pow2div_i8(x.x9,  divisor, d._promises),
                                           pow2div_i8(x.x10, divisor, d._promises),
                                           pow2div_i8(x.x11, divisor, d._promises),
                                           pow2div_i8(x.x12, divisor, d._promises),
                                           pow2div_i8(x.x13, divisor, d._promises),
                                           pow2div_i8(x.x14, divisor, d._promises),
                                           pow2div_i8(x.x15, divisor, d._promises),
                                           pow2div_i8(x.x16, divisor, d._promises),
                                           pow2div_i8(x.x17, divisor, d._promises),
                                           pow2div_i8(x.x18, divisor, d._promises),
                                           pow2div_i8(x.x19, divisor, d._promises),
                                           pow2div_i8(x.x20, divisor, d._promises),
                                           pow2div_i8(x.x21, divisor, d._promises),
                                           pow2div_i8(x.x22, divisor, d._promises),
                                           pow2div_i8(x.x23, divisor, d._promises),
                                           pow2div_i8(x.x24, divisor, d._promises),
                                           pow2div_i8(x.x25, divisor, d._promises),
                                           pow2div_i8(x.x26, divisor, d._promises),
                                           pow2div_i8(x.x27, divisor, d._promises),
                                           pow2div_i8(x.x28, divisor, d._promises),
                                           pow2div_i8(x.x29, divisor, d._promises),
                                           pow2div_i8(x.x30, divisor, d._promises),
                                           pow2div_i8(x.x31, divisor, d._promises));
                    }
                }
                else
                {
                    ushort mul = *(ushort*)&d._bigM;

                    if (Avx2.IsAvx2Supported)
                    {
                        return mm256_bmdiv_epi8_si8(x, mul, divisor, d._promises);
                    }
                    else if (Architecture.IsSIMDSupported)
                    {
                        return new sbyte32(bmdiv_epi8_si8(x.v16_0,  mul, divisor, d._promises),
                                           bmdiv_epi8_si8(x.v16_16, mul, divisor, d._promises));
                    }
                    else
                    {
                        return new sbyte32(bmdiv_i8(x.x0,  mul, divisor, d._promises),
                                           bmdiv_i8(x.x1,  mul, divisor, d._promises),
                                           bmdiv_i8(x.x2,  mul, divisor, d._promises),
                                           bmdiv_i8(x.x3,  mul, divisor, d._promises),
                                           bmdiv_i8(x.x4,  mul, divisor, d._promises),
                                           bmdiv_i8(x.x5,  mul, divisor, d._promises),
                                           bmdiv_i8(x.x6,  mul, divisor, d._promises),
                                           bmdiv_i8(x.x7,  mul, divisor, d._promises),
                                           bmdiv_i8(x.x8,  mul, divisor, d._promises),
                                           bmdiv_i8(x.x9,  mul, divisor, d._promises),
                                           bmdiv_i8(x.x10, mul, divisor, d._promises),
                                           bmdiv_i8(x.x11, mul, divisor, d._promises),
                                           bmdiv_i8(x.x12, mul, divisor, d._promises),
                                           bmdiv_i8(x.x13, mul, divisor, d._promises),
                                           bmdiv_i8(x.x14, mul, divisor, d._promises),
                                           bmdiv_i8(x.x15, mul, divisor, d._promises),
                                           bmdiv_i8(x.x16, mul, divisor, d._promises),
                                           bmdiv_i8(x.x17, mul, divisor, d._promises),
                                           bmdiv_i8(x.x18, mul, divisor, d._promises),
                                           bmdiv_i8(x.x19, mul, divisor, d._promises),
                                           bmdiv_i8(x.x20, mul, divisor, d._promises),
                                           bmdiv_i8(x.x21, mul, divisor, d._promises),
                                           bmdiv_i8(x.x22, mul, divisor, d._promises),
                                           bmdiv_i8(x.x23, mul, divisor, d._promises),
                                           bmdiv_i8(x.x24, mul, divisor, d._promises),
                                           bmdiv_i8(x.x25, mul, divisor, d._promises),
                                           bmdiv_i8(x.x26, mul, divisor, d._promises),
                                           bmdiv_i8(x.x27, mul, divisor, d._promises),
                                           bmdiv_i8(x.x28, mul, divisor, d._promises),
                                           bmdiv_i8(x.x29, mul, divisor, d._promises),
                                           bmdiv_i8(x.x30, mul, divisor, d._promises),
                                           bmdiv_i8(x.x31, mul, divisor, d._promises));
                    }
                }
            }
            else
            {
                sbyte32 divisor = *(sbyte32*)&d._divisor;

                if (d._promises.Pow2)
                {
                    if (Avx2.IsAvx2Supported)
                    {
                        return mm256_pow2div_epi8(x, divisor, d._promises);
                    }
                    else if (Architecture.IsSIMDSupported)
                    {
                        return new sbyte32(pow2div_epi8(x.v16_0,  divisor.v16_0,  d._promises),
                                           pow2div_epi8(x.v16_16, divisor.v16_16, d._promises));
                    }
                    else
                    {
                        return new sbyte32(pow2div_i8(x.x0,  divisor.x0,  d._promises),
                                           pow2div_i8(x.x1,  divisor.x1,  d._promises),
                                           pow2div_i8(x.x2,  divisor.x2,  d._promises),
                                           pow2div_i8(x.x3,  divisor.x3,  d._promises),
                                           pow2div_i8(x.x4,  divisor.x4,  d._promises),
                                           pow2div_i8(x.x5,  divisor.x5,  d._promises),
                                           pow2div_i8(x.x6,  divisor.x6,  d._promises),
                                           pow2div_i8(x.x7,  divisor.x7,  d._promises),
                                           pow2div_i8(x.x8,  divisor.x8,  d._promises),
                                           pow2div_i8(x.x9,  divisor.x9,  d._promises),
                                           pow2div_i8(x.x10, divisor.x10, d._promises),
                                           pow2div_i8(x.x11, divisor.x11, d._promises),
                                           pow2div_i8(x.x12, divisor.x12, d._promises),
                                           pow2div_i8(x.x13, divisor.x13, d._promises),
                                           pow2div_i8(x.x14, divisor.x14, d._promises),
                                           pow2div_i8(x.x15, divisor.x15, d._promises),
                                           pow2div_i8(x.x16, divisor.x16, d._promises),
                                           pow2div_i8(x.x17, divisor.x17, d._promises),
                                           pow2div_i8(x.x18, divisor.x18, d._promises),
                                           pow2div_i8(x.x19, divisor.x19, d._promises),
                                           pow2div_i8(x.x20, divisor.x20, d._promises),
                                           pow2div_i8(x.x21, divisor.x21, d._promises),
                                           pow2div_i8(x.x22, divisor.x22, d._promises),
                                           pow2div_i8(x.x23, divisor.x23, d._promises),
                                           pow2div_i8(x.x24, divisor.x24, d._promises),
                                           pow2div_i8(x.x25, divisor.x25, d._promises),
                                           pow2div_i8(x.x26, divisor.x26, d._promises),
                                           pow2div_i8(x.x27, divisor.x27, d._promises),
                                           pow2div_i8(x.x28, divisor.x28, d._promises),
                                           pow2div_i8(x.x29, divisor.x29, d._promises),
                                           pow2div_i8(x.x30, divisor.x30, d._promises),
                                           pow2div_i8(x.x31, divisor.x31, d._promises));
                    }
                }
                else
                {
                    ushort16 mulLo = *(ushort16*)&d._bigM._mulLo;
                    ushort16 mulHi = *(ushort16*)&d._bigM._mulHi;

                    if (Avx2.IsAvx2Supported)
                    {
                        return mm256_bmdiv_epi8(x, mulLo, mulHi, divisor, d._promises);
                    }
                    else if (Architecture.IsSIMDSupported)
                    {
                        return new sbyte32(bmdiv_epi8(x.v16_0,  mulLo.v8_0, mulLo.v8_8, divisor.v16_0,  d._promises),
                                           bmdiv_epi8(x.v16_16, mulHi.v8_0, mulHi.v8_8, divisor.v16_16, d._promises));
                    }
                    else
                    {
                        return new sbyte32(bmdiv_i8(x.x0,  mulLo.x0,  divisor.x0,  d._promises),
                                           bmdiv_i8(x.x1,  mulLo.x1,  divisor.x1,  d._promises),
                                           bmdiv_i8(x.x2,  mulLo.x2,  divisor.x2,  d._promises),
                                           bmdiv_i8(x.x3,  mulLo.x3,  divisor.x3,  d._promises),
                                           bmdiv_i8(x.x4,  mulLo.x4,  divisor.x4,  d._promises),
                                           bmdiv_i8(x.x5,  mulLo.x5,  divisor.x5,  d._promises),
                                           bmdiv_i8(x.x6,  mulLo.x6,  divisor.x6,  d._promises),
                                           bmdiv_i8(x.x7,  mulLo.x7,  divisor.x7,  d._promises),
                                           bmdiv_i8(x.x8,  mulLo.x8,  divisor.x8,  d._promises),
                                           bmdiv_i8(x.x9,  mulLo.x9,  divisor.x9,  d._promises),
                                           bmdiv_i8(x.x10, mulLo.x10, divisor.x10, d._promises),
                                           bmdiv_i8(x.x11, mulLo.x11, divisor.x11, d._promises),
                                           bmdiv_i8(x.x12, mulLo.x12, divisor.x12, d._promises),
                                           bmdiv_i8(x.x13, mulLo.x13, divisor.x13, d._promises),
                                           bmdiv_i8(x.x14, mulLo.x14, divisor.x14, d._promises),
                                           bmdiv_i8(x.x15, mulLo.x15, divisor.x15, d._promises),
                                           bmdiv_i8(x.x16, mulHi.x0,  divisor.x16, d._promises),
                                           bmdiv_i8(x.x17, mulHi.x1,  divisor.x17, d._promises),
                                           bmdiv_i8(x.x18, mulHi.x2,  divisor.x18, d._promises),
                                           bmdiv_i8(x.x19, mulHi.x3,  divisor.x19, d._promises),
                                           bmdiv_i8(x.x20, mulHi.x4,  divisor.x20, d._promises),
                                           bmdiv_i8(x.x21, mulHi.x5,  divisor.x21, d._promises),
                                           bmdiv_i8(x.x22, mulHi.x6,  divisor.x22, d._promises),
                                           bmdiv_i8(x.x23, mulHi.x7,  divisor.x23, d._promises),
                                           bmdiv_i8(x.x24, mulHi.x8,  divisor.x24, d._promises),
                                           bmdiv_i8(x.x25, mulHi.x9,  divisor.x25, d._promises),
                                           bmdiv_i8(x.x26, mulHi.x10, divisor.x26, d._promises),
                                           bmdiv_i8(x.x27, mulHi.x11, divisor.x27, d._promises),
                                           bmdiv_i8(x.x28, mulHi.x12, divisor.x28, d._promises),
                                           bmdiv_i8(x.x29, mulHi.x13, divisor.x29, d._promises),
                                           bmdiv_i8(x.x30, mulHi.x14, divisor.x30, d._promises),
                                           bmdiv_i8(x.x31, mulHi.x15, divisor.x31, d._promises));
                    }
                }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T operator / (short x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(short), 1, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            switch (sizeof(T))
            {
                case 16 * sizeof(short): return ((short16)x / d).Reinterpret<short16, T>();
                case  8 * sizeof(short): return ((short8) x / d).Reinterpret<short8,  T>();
                case  4 * sizeof(short): return ((short4) x / d).Reinterpret<short4,  T>();
                case  3 * sizeof(short): return ((short3) x / d).Reinterpret<short3,  T>();
                case  2 * sizeof(short): return ((short2) x / d).Reinterpret<short2,  T>();
                default:
                {
                    if (d._promises.Pow2)
                    {
                        return pow2div_i16(x, d._divisor.Reinterpret<T, short>(), d._promises).Reinterpret<short, T>();
                    }
                    else
                    {
                        return bmdiv_i16(x, *(uint*)&d._bigM, *(short*)&d._divisor, d._promises).Reinterpret<short, T>();
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator / (short2 x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(short), 2, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            if (d.DivideByScalar<short2>())
            {
                short divisor = *(short*)&d._divisor;

                if (d._promises.Pow2)
                {
                    if (Architecture.IsSIMDSupported)
                    {
                        return pow2div_epi16_si16(x, divisor, d._promises);
                    }
                    else
                    {
                        return new short2(pow2div_i16(x.x, divisor, d._promises),
                                          pow2div_i16(x.y, divisor, d._promises));
                    }
                }
                else
                {
                    if (Architecture.IsSIMDSupported)
                    {
                        short mul = *(short*)&d._mulShift._mul;
                        short shift = *(short*)&d._mulShift._shift;

                        return msdiv_epi16_si16(x, mul, shift, divisor, d._promises, 2);
                    }
                    else
                    {
                        uint mul = *(uint*)&d._bigM;

                        return new short2(bmdiv_i16(x.x, mul, divisor, d._promises),
                                          bmdiv_i16(x.y, mul, divisor, d._promises));
                    }
                }
            }
            else
            {
                short2 divisor = *(short2*)&d._divisor;

                if (d._promises.Pow2)
                {
                    if (Architecture.IsSIMDSupported)
                    {
                        return pow2div_epi16(x, divisor, d._promises, 2);
                    }
                    else
                    {
                        return new short2(pow2div_i16(x.x, divisor.x, d._promises),
                                          pow2div_i16(x.y, divisor.y, d._promises));
                    }
                }
                else
                {
                    uint2 mul = *(uint2*)&d._bigM;

                    if (Avx2.IsAvx2Supported)
                    {
                        return msdiv_epi16(x, *(short2*)&d._mulShift._mul, *(short2*)&d._mulShift._shift, divisor, d._promises, 2);
                    }
                    else if (Architecture.IsSIMDSupported)
                    {
                        return bmdiv_epi16(x, RegisterConversion.ToV128(mul), divisor, d._promises, 2);
                    }
                    else
                    {
                        return new short2(bmdiv_i16(x.x, mul.x, divisor.x, d._promises),
                                          bmdiv_i16(x.y, mul.y, divisor.y, d._promises));
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator / (short3 x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(short), 3, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            if (d.DivideByScalar<short3>())
            {
                short divisor = *(short*)&d._divisor;

                if (d._promises.Pow2)
                {
                    if (Architecture.IsSIMDSupported)
                    {
                        return pow2div_epi16_si16(x, divisor, d._promises);
                    }
                    else
                    {
                        return new short3(pow2div_i16(x.x, divisor, d._promises),
                                          pow2div_i16(x.y, divisor, d._promises),
                                          pow2div_i16(x.z, divisor, d._promises));
                    }
                }
                else
                {
                    if (Architecture.IsSIMDSupported)
                    {
                        short mul = *(short*)&d._mulShift._mul;
                        short shift = *(short*)&d._mulShift._shift;

                        return msdiv_epi16_si16(x, mul, shift, divisor, d._promises, 3);
                    }
                    else
                    {
                        uint mul = *(uint*)&d._bigM;

                        return new short3(bmdiv_i16(x.x, mul, divisor, d._promises),
                                          bmdiv_i16(x.y, mul, divisor, d._promises),
                                          bmdiv_i16(x.z, mul, divisor, d._promises));
                    }
                }
            }
            else
            {
                short3 divisor = *(short3*)&d._divisor;

                if (d._promises.Pow2)
                {
                    if (Architecture.IsSIMDSupported)
                    {
                        return pow2div_epi16(x, divisor, d._promises, 3);
                    }
                    else
                    {
                        return new short3(pow2div_i16(x.x, divisor.x, d._promises),
                                          pow2div_i16(x.y, divisor.y, d._promises),
                                          pow2div_i16(x.z, divisor.z, d._promises));
                    }
                }
                else
                {
                    uint3 mul = *(uint3*)&d._bigM;

                    if (Avx2.IsAvx2Supported)
                    {
                        return msdiv_epi16(x, *(short3*)&d._mulShift._mul, *(short3*)&d._mulShift._shift, divisor, d._promises, 3);
                    }
                    else if (Architecture.IsSIMDSupported)
                    {
                        return bmdiv_epi16(x, RegisterConversion.ToV128(mul), divisor, d._promises, 3);
                    }
                    else
                    {
                        return new short3(bmdiv_i16(x.x, mul.x, divisor.x, d._promises),
                                          bmdiv_i16(x.y, mul.y, divisor.y, d._promises),
                                          bmdiv_i16(x.z, mul.z, divisor.z, d._promises));
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 operator / (short4 x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(short), 4, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            if (d.DivideByScalar<short4>())
            {
                short divisor = *(short*)&d._divisor;

                if (d._promises.Pow2)
                {
                    if (Architecture.IsSIMDSupported)
                    {
                        return pow2div_epi16_si16(x, divisor, d._promises);
                    }
                    else
                    {
                        return new short4(pow2div_i16(x.x, divisor, d._promises),
                                          pow2div_i16(x.y, divisor, d._promises),
                                          pow2div_i16(x.z, divisor, d._promises),
                                          pow2div_i16(x.w, divisor, d._promises));
                    }
                }
                else
                {
                    if (Architecture.IsSIMDSupported)
                    {
                        short mul = *(short*)&d._mulShift._mul;
                        short shift = *(short*)&d._mulShift._shift;

                        return msdiv_epi16_si16(x, mul, shift, divisor, d._promises, 4);
                    }
                    else
                    {
                        uint mul = *(uint*)&d._bigM;

                        return new short4(bmdiv_i16(x.x, mul, divisor, d._promises),
                                          bmdiv_i16(x.y, mul, divisor, d._promises),
                                          bmdiv_i16(x.z, mul, divisor, d._promises),
                                          bmdiv_i16(x.w, mul, divisor, d._promises));
                    }
                }
            }
            else
            {
                short4 divisor = *(short4*)&d._divisor;

                if (d._promises.Pow2)
                {
                    if (Architecture.IsSIMDSupported)
                    {
                        return pow2div_epi16(x, divisor, d._promises, 4);
                    }
                    else
                    {
                        return new short4(pow2div_i16(x.x, divisor.x, d._promises),
                                          pow2div_i16(x.y, divisor.y, d._promises),
                                          pow2div_i16(x.z, divisor.z, d._promises),
                                          pow2div_i16(x.w, divisor.w, d._promises));
                    }
                }
                else
                {
                    uint4 mul = *(uint4*)&d._bigM;

                    if (Avx2.IsAvx2Supported)
                    {
                        return msdiv_epi16(x, *(short4*)&d._mulShift._mul, *(short4*)&d._mulShift._shift, divisor, d._promises, 4);
                    }
                    else if (Architecture.IsSIMDSupported)
                    {
                        return bmdiv_epi16(x, RegisterConversion.ToV128(mul), divisor, d._promises, 4);
                    }
                    else
                    {
                        return new short4(bmdiv_i16(x.x, mul.x, divisor.x, d._promises),
                                          bmdiv_i16(x.y, mul.y, divisor.y, d._promises),
                                          bmdiv_i16(x.z, mul.z, divisor.z, d._promises),
                                          bmdiv_i16(x.w, mul.w, divisor.w, d._promises));
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator / (short8 x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(short), 8, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            if (d.DivideByScalar<short8>())
            {
                short divisor = *(short*)&d._divisor;

                if (d._promises.Pow2)
                {
                    if (Architecture.IsSIMDSupported)
                    {
                        return pow2div_epi16_si16(x, divisor, d._promises);
                    }
                    else
                    {
                        return new short8(pow2div_i16(x.x0, divisor, d._promises),
                                          pow2div_i16(x.x1, divisor, d._promises),
                                          pow2div_i16(x.x2, divisor, d._promises),
                                          pow2div_i16(x.x3, divisor, d._promises),
                                          pow2div_i16(x.x4, divisor, d._promises),
                                          pow2div_i16(x.x5, divisor, d._promises),
                                          pow2div_i16(x.x6, divisor, d._promises),
                                          pow2div_i16(x.x7, divisor, d._promises));
                    }
                }
                else
                {
                    if (Architecture.IsSIMDSupported)
                    {
                        short mul = *(short*)&d._mulShift._mul;
                        short shift = *(short*)&d._mulShift._shift;

                        return msdiv_epi16_si16(x, mul, shift, divisor, d._promises);
                    }
                    else
                    {
                        uint mul = *(uint*)&d._bigM;

                        return new short8(bmdiv_i16(x.x0, mul, divisor, d._promises),
                                          bmdiv_i16(x.x1, mul, divisor, d._promises),
                                          bmdiv_i16(x.x2, mul, divisor, d._promises),
                                          bmdiv_i16(x.x3, mul, divisor, d._promises),
                                          bmdiv_i16(x.x4, mul, divisor, d._promises),
                                          bmdiv_i16(x.x5, mul, divisor, d._promises),
                                          bmdiv_i16(x.x6, mul, divisor, d._promises),
                                          bmdiv_i16(x.x7, mul, divisor, d._promises));
                    }
                }
            }
            else
            {
                short8 divisor = *(short8*)&d._divisor;

                if (d._promises.Pow2)
                {
                    if (Architecture.IsSIMDSupported)
                    {
                        return pow2div_epi16(x, divisor, d._promises, 8);
                    }
                    else
                    {
                        return new short8(pow2div_i16(x.x0, divisor.x0, d._promises),
                                          pow2div_i16(x.x1, divisor.x1, d._promises),
                                          pow2div_i16(x.x2, divisor.x2, d._promises),
                                          pow2div_i16(x.x3, divisor.x3, d._promises),
                                          pow2div_i16(x.x4, divisor.x4, d._promises),
                                          pow2div_i16(x.x5, divisor.x5, d._promises),
                                          pow2div_i16(x.x6, divisor.x6, d._promises),
                                          pow2div_i16(x.x7, divisor.x7, d._promises));
                    }
                }
                else
                {
                    uint8 mul = *(uint8*)&d._bigM;

                    if (Avx2.IsAvx2Supported)
                    {
                        return msdiv_epi16(x, *(short8*)&d._mulShift._mul, *(short8*)&d._mulShift._shift, divisor, d._promises, 8);
                    }
                    else if (Architecture.IsSIMDSupported)
                    {
                        return bmdiv_epi16(x, RegisterConversion.ToV128(mul.v4_0), RegisterConversion.ToV128(mul.v4_4), divisor, d._promises);
                    }
                    else
                    {
                        return new short8(bmdiv_i16(x.x0, mul.v4_0.x, divisor.x0, d._promises),
                                          bmdiv_i16(x.x1, mul.v4_0.y, divisor.x1, d._promises),
                                          bmdiv_i16(x.x2, mul.v4_0.z, divisor.x2, d._promises),
                                          bmdiv_i16(x.x3, mul.v4_0.w, divisor.x3, d._promises),
                                          bmdiv_i16(x.x4, mul.v4_4.x, divisor.x4, d._promises),
                                          bmdiv_i16(x.x5, mul.v4_4.y, divisor.x5, d._promises),
                                          bmdiv_i16(x.x6, mul.v4_4.z, divisor.x6, d._promises),
                                          bmdiv_i16(x.x7, mul.v4_4.w, divisor.x7, d._promises));
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 operator / (short16 x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(short), 16, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            if (d.DivideByScalar<short16>())
            {
                short divisor = *(short*)&d._divisor;

                if (d._promises.Pow2)
                {
                    if (Avx2.IsAvx2Supported)
                    {
                        return mm256_pow2div_epi16_si16(x, divisor, d._promises);
                    }
                    else if (Architecture.IsSIMDSupported)
                    {
                        return new short16(pow2div_epi16_si16(x.v8_0, divisor, d._promises),
                                           pow2div_epi16_si16(x.v8_8, divisor, d._promises));
                    }
                    else
                    {
                        return new short16(pow2div_i16(x.x0,  divisor, d._promises),
                                           pow2div_i16(x.x1,  divisor, d._promises),
                                           pow2div_i16(x.x2,  divisor, d._promises),
                                           pow2div_i16(x.x3,  divisor, d._promises),
                                           pow2div_i16(x.x4,  divisor, d._promises),
                                           pow2div_i16(x.x5,  divisor, d._promises),
                                           pow2div_i16(x.x6,  divisor, d._promises),
                                           pow2div_i16(x.x7,  divisor, d._promises),
                                           pow2div_i16(x.x8,  divisor, d._promises),
                                           pow2div_i16(x.x9,  divisor, d._promises),
                                           pow2div_i16(x.x10, divisor, d._promises),
                                           pow2div_i16(x.x11, divisor, d._promises),
                                           pow2div_i16(x.x12, divisor, d._promises),
                                           pow2div_i16(x.x13, divisor, d._promises),
                                           pow2div_i16(x.x14, divisor, d._promises),
                                           pow2div_i16(x.x15, divisor, d._promises));
                    }
                }
                else
                {
                    short mul = *(short*)&d._mulShift._mul;
                    short shift = *(short*)&d._mulShift._shift;

                    if (Avx2.IsAvx2Supported)
                    {
                        return mm256_msdiv_epi16_si16(x, mul, shift, divisor, d._promises);
                    }
                    else if (Architecture.IsSIMDSupported)
                    {
                        return new short16(msdiv_epi16_si16(x.v8_0, mul, shift, divisor, d._promises),
                                           msdiv_epi16_si16(x.v8_8, mul, shift, divisor, d._promises));
                    }
                    else
                    {
                        uint mul32 = *(uint*)&d._bigM;

                        return new short16(bmdiv_i16(x.x0,  mul32, divisor, d._promises),
                                           bmdiv_i16(x.x1,  mul32, divisor, d._promises),
                                           bmdiv_i16(x.x2,  mul32, divisor, d._promises),
                                           bmdiv_i16(x.x3,  mul32, divisor, d._promises),
                                           bmdiv_i16(x.x4,  mul32, divisor, d._promises),
                                           bmdiv_i16(x.x5,  mul32, divisor, d._promises),
                                           bmdiv_i16(x.x6,  mul32, divisor, d._promises),
                                           bmdiv_i16(x.x7,  mul32, divisor, d._promises),
                                           bmdiv_i16(x.x8,  mul32, divisor, d._promises),
                                           bmdiv_i16(x.x9,  mul32, divisor, d._promises),
                                           bmdiv_i16(x.x10, mul32, divisor, d._promises),
                                           bmdiv_i16(x.x11, mul32, divisor, d._promises),
                                           bmdiv_i16(x.x12, mul32, divisor, d._promises),
                                           bmdiv_i16(x.x13, mul32, divisor, d._promises),
                                           bmdiv_i16(x.x14, mul32, divisor, d._promises),
                                           bmdiv_i16(x.x15, mul32, divisor, d._promises));
                    }
                }
            }
            else
            {
                short16 divisor = *(short16*)&d._divisor;

                if (d._promises.Pow2)
                {
                    if (Avx2.IsAvx2Supported)
                    {
                        return mm256_pow2div_epi16(x, divisor, d._promises);
                    }
                    else if (Architecture.IsSIMDSupported)
                    {
                        return new short16(pow2div_epi16(x.v8_0, divisor.v8_0, d._promises),
                                           pow2div_epi16(x.v8_8, divisor.v8_8, d._promises));
                    }
                    else
                    {
                        return new short16(pow2div_i16(x.x0,  divisor.x0,  d._promises),
                                           pow2div_i16(x.x1,  divisor.x1,  d._promises),
                                           pow2div_i16(x.x2,  divisor.x2,  d._promises),
                                           pow2div_i16(x.x3,  divisor.x3,  d._promises),
                                           pow2div_i16(x.x4,  divisor.x4,  d._promises),
                                           pow2div_i16(x.x5,  divisor.x5,  d._promises),
                                           pow2div_i16(x.x6,  divisor.x6,  d._promises),
                                           pow2div_i16(x.x7,  divisor.x7,  d._promises),
                                           pow2div_i16(x.x8,  divisor.x8,  d._promises),
                                           pow2div_i16(x.x9,  divisor.x9,  d._promises),
                                           pow2div_i16(x.x10, divisor.x10, d._promises),
                                           pow2div_i16(x.x11, divisor.x11, d._promises),
                                           pow2div_i16(x.x12, divisor.x12, d._promises),
                                           pow2div_i16(x.x13, divisor.x13, d._promises),
                                           pow2div_i16(x.x14, divisor.x14, d._promises),
                                           pow2div_i16(x.x15, divisor.x15, d._promises));
                    }
                }
                else
                {
                    uint8 mulLo = *(uint8*)&d._bigM._mulLo;
                    uint8 mulHi = *(uint8*)&d._bigM._mulHi;

                    if (Avx2.IsAvx2Supported)
                    {
                        return mm256_msdiv_epi16(x, *(short16*)&d._mulShift._mul, *(short16*)&d._mulShift._shift, divisor, d._promises);
                    }
                    else if (Architecture.IsSIMDSupported)
                    {
                        return new short16(bmdiv_epi16(x.v8_0, RegisterConversion.ToV128(mulLo.v4_0), RegisterConversion.ToV128(mulLo.v4_4), divisor.v8_0, d._promises),
                                           bmdiv_epi16(x.v8_8, RegisterConversion.ToV128(mulHi.v4_0), RegisterConversion.ToV128(mulHi.v4_4), divisor.v8_8, d._promises));
                    }
                    else
                    {
                        return new short16(bmdiv_i16(x.x0,  mulLo.x0, divisor.x0,  d._promises),
                                           bmdiv_i16(x.x1,  mulLo.x1, divisor.x1,  d._promises),
                                           bmdiv_i16(x.x2,  mulLo.x2, divisor.x2,  d._promises),
                                           bmdiv_i16(x.x3,  mulLo.x3, divisor.x3,  d._promises),
                                           bmdiv_i16(x.x4,  mulLo.x4, divisor.x4,  d._promises),
                                           bmdiv_i16(x.x5,  mulLo.x5, divisor.x5,  d._promises),
                                           bmdiv_i16(x.x6,  mulLo.x6, divisor.x6,  d._promises),
                                           bmdiv_i16(x.x7,  mulLo.x7, divisor.x7,  d._promises),
                                           bmdiv_i16(x.x8,  mulHi.x0, divisor.x8,  d._promises),
                                           bmdiv_i16(x.x9,  mulHi.x1, divisor.x9,  d._promises),
                                           bmdiv_i16(x.x10, mulHi.x2, divisor.x10, d._promises),
                                           bmdiv_i16(x.x11, mulHi.x3, divisor.x11, d._promises),
                                           bmdiv_i16(x.x12, mulHi.x4, divisor.x12, d._promises),
                                           bmdiv_i16(x.x13, mulHi.x5, divisor.x13, d._promises),
                                           bmdiv_i16(x.x14, mulHi.x6, divisor.x14, d._promises),
                                           bmdiv_i16(x.x15, mulHi.x7, divisor.x15, d._promises));
                    }
                }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T operator / (int x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(int), 1, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            switch (sizeof(T))
            {
                case 8 * sizeof(int): return ((int8)x / d).Reinterpret<int8, T>();
                case 4 * sizeof(int): return ((int4)x / d).Reinterpret<int4, T>();
                case 3 * sizeof(int): return ((int3)x / d).Reinterpret<int3, T>();
                case 2 * sizeof(int): return ((int2)x / d).Reinterpret<int2, T>();
                default:
                {
                    if (d._promises.Pow2)
                    {
                        return pow2div_i32(x, d._divisor.Reinterpret<T, int>(), d._promises).Reinterpret<int, T>();
                    }
                    else
                    {
                        if (Architecture.IsBurstCompiled)
                        {
                            return bmdiv_i32(x, *(ulong*)&d._bigM, *(int*)&d._divisor, d._promises).Reinterpret<int, T>();
                        }
                        else
                        {
                            return msdiv_i32(x, *(int*)&d._mulShift._mul, *(int*)&d._mulShift._shift, *(int*)&d._divisor, d._promises).Reinterpret<int, T>();
                        }
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator / (int2 x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(int), 2, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            if (d.DivideByScalar<int2>())
            {
                int divisor = *(int*)&d._divisor;

                if (d._promises.Pow2)
                {
                    if (Architecture.IsSIMDSupported)
                    {
                        return RegisterConversion.ToInt2(pow2div_epi32_si32(RegisterConversion.ToV128(x), divisor, d._promises));
                    }
                    else
                    {
                        return new int2(pow2div_i32(x.x, divisor, d._promises),
                                        pow2div_i32(x.y, divisor, d._promises));
                    }
                }
                else
                {
                    int mul = *(int*)&d._mulShift._mul;
                    int shift = *(int*)&d._mulShift._shift;

                    if (Architecture.IsSIMDSupported)
                    {
                        return RegisterConversion.ToInt2(msdiv_epi32_si32(RegisterConversion.ToV128(x), mul, shift, divisor, d._promises, 2));
                    }
                    else
                    {
                        if (Architecture.IsBurstCompiled)
                        {
                            ulong mul64 = *(ulong*)&d._bigM;

                            return new int2(bmdiv_i32(x.x, mul64, divisor, d._promises),
                                            bmdiv_i32(x.y, mul64, divisor, d._promises));
                        }
                        else
                        {
                            return new int2(msdiv_i32(x.x, mul, shift, divisor, d._promises),
                                            msdiv_i32(x.y, mul, shift, divisor, d._promises));
                        }
                    }
                }
            }
            else
            {
                int2 divisor = *(int2*)&d._divisor;

                if (d._promises.Pow2)
                {
                    if (Architecture.IsSIMDSupported)
                    {
                        return RegisterConversion.ToInt2(pow2div_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(divisor), d._promises, 2));
                    }
                    else
                    {
                        return new int2(pow2div_i32(x.x, divisor.x, d._promises),
                                        pow2div_i32(x.y, divisor.y, d._promises));
                    }
                }
                else
                {
                    int2 mul = *(int2*)&d._mulShift._mul;
                    int2 shift = *(int2*)&d._mulShift._shift;

                    if (Architecture.IsSIMDSupported)
                    {
                        return RegisterConversion.ToInt2(msdiv_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(mul), RegisterConversion.ToV128(shift), RegisterConversion.ToV128(divisor), d._promises, 2));
                    }
                    else
                    {
                        if (Architecture.IsBurstCompiled)
                        {
                            ulong2 mul64 = *(ulong2*)&d._bigM;

                            return new int2(bmdiv_i32(x.x, mul64.x, divisor.x, d._promises),
                                            bmdiv_i32(x.y, mul64.y, divisor.y, d._promises));
                        }
                        else
                        {
                            return new int2(msdiv_i32(x.x, mul.x, shift.x, divisor.x, d._promises),
                                            msdiv_i32(x.y, mul.y, shift.y, divisor.y, d._promises));
                        }
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator / (int3 x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(int), 3, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            if (d.DivideByScalar<int3>())
            {
                int divisor = *(int*)&d._divisor;

                if (d._promises.Pow2)
                {
                    if (Architecture.IsSIMDSupported)
                    {
                        return RegisterConversion.ToInt3(pow2div_epi32_si32(RegisterConversion.ToV128(x), divisor, d._promises));
                    }
                    else
                    {
                        return new int3(pow2div_i32(x.x, divisor, d._promises),
                                        pow2div_i32(x.y, divisor, d._promises),
                                        pow2div_i32(x.z, divisor, d._promises));
                    }
                }
                else
                {
                    int mul = *(int*)&d._mulShift._mul;
                    int shift = *(int*)&d._mulShift._shift;

                    if (Architecture.IsSIMDSupported)
                    {
                        return RegisterConversion.ToInt3(msdiv_epi32_si32(RegisterConversion.ToV128(x), mul, shift, divisor, d._promises, 3));
                    }
                    else
                    {
                        if (Architecture.IsBurstCompiled)
                        {
                            ulong mul64 = *(ulong*)&d._bigM;

                            return new int3(bmdiv_i32(x.x, mul64, divisor, d._promises),
                                            bmdiv_i32(x.y, mul64, divisor, d._promises),
                                            bmdiv_i32(x.z, mul64, divisor, d._promises));
                        }
                        else
                        {
                            return new int3(msdiv_i32(x.x, mul, shift, divisor, d._promises),
                                            msdiv_i32(x.y, mul, shift, divisor, d._promises),
                                            msdiv_i32(x.z, mul, shift, divisor, d._promises));
                        }
                    }
                }
            }
            else
            {
                int3 divisor = *(int3*)&d._divisor;

                if (d._promises.Pow2)
                {
                    if (Architecture.IsSIMDSupported)
                    {
                        return RegisterConversion.ToInt3(pow2div_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(divisor), d._promises, 3));
                    }
                    else
                    {
                        return new int3(pow2div_i32(x.x, divisor.x, d._promises),
                                        pow2div_i32(x.y, divisor.y, d._promises),
                                        pow2div_i32(x.z, divisor.z, d._promises));
                    }
                }
                else
                {
                    int3 mul = *(int3*)&d._mulShift._mul;
                    int3 shift = *(int3*)&d._mulShift._shift;

                    if (Architecture.IsSIMDSupported)
                    {
                        return RegisterConversion.ToInt3(msdiv_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(mul), RegisterConversion.ToV128(shift), RegisterConversion.ToV128(divisor), d._promises, 3));
                    }
                    else
                    {
                        if (Architecture.IsBurstCompiled)
                        {
                            ulong3 mul64 = *(ulong3*)&d._bigM;

                            return new int3(bmdiv_i32(x.x, mul64.x, divisor.x, d._promises),
                                            bmdiv_i32(x.y, mul64.y, divisor.y, d._promises),
                                            bmdiv_i32(x.z, mul64.z, divisor.z, d._promises));
                        }
                        else
                        {
                            return new int3(msdiv_i32(x.x, mul.x, shift.x, divisor.x, d._promises),
                                            msdiv_i32(x.y, mul.y, shift.y, divisor.y, d._promises),
                                            msdiv_i32(x.z, mul.z, shift.z, divisor.z, d._promises));
                        }
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 operator / (int4 x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(int), 4, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            if (d.DivideByScalar<int4>())
            {
                int divisor = *(int*)&d._divisor;

                if (d._promises.Pow2)
                {
                    if (Architecture.IsSIMDSupported)
                    {
                        return RegisterConversion.ToInt4(pow2div_epi32_si32(RegisterConversion.ToV128(x), divisor, d._promises));
                    }
                    else
                    {
                        return new int4(pow2div_i32(x.x, divisor, d._promises),
                                        pow2div_i32(x.y, divisor, d._promises),
                                        pow2div_i32(x.z, divisor, d._promises),
                                        pow2div_i32(x.w, divisor, d._promises));
                    }
                }
                else
                {
                    int mul = *(int*)&d._mulShift._mul;
                    int shift = *(int*)&d._mulShift._shift;

                    if (Architecture.IsSIMDSupported)
                    {
                        return RegisterConversion.ToInt4(msdiv_epi32_si32(RegisterConversion.ToV128(x), mul, shift, divisor, d._promises, 4));
                    }
                    else
                    {
                        if (Architecture.IsBurstCompiled)
                        {
                            ulong mul64 = *(ulong*)&d._bigM;

                            return new int4(bmdiv_i32(x.x, mul64, divisor, d._promises),
                                            bmdiv_i32(x.y, mul64, divisor, d._promises),
                                            bmdiv_i32(x.z, mul64, divisor, d._promises),
                                            bmdiv_i32(x.w, mul64, divisor, d._promises));
                        }
                        else
                        {
                            return new int4(msdiv_i32(x.x, mul, shift, divisor, d._promises),
                                            msdiv_i32(x.y, mul, shift, divisor, d._promises),
                                            msdiv_i32(x.z, mul, shift, divisor, d._promises),
                                            msdiv_i32(x.w, mul, shift, divisor, d._promises));
                        }
                    }
                }
            }
            else
            {
                int4 divisor = *(int4*)&d._divisor;

                if (d._promises.Pow2)
                {
                    if (Architecture.IsSIMDSupported)
                    {
                        return RegisterConversion.ToInt4(pow2div_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(divisor), d._promises, 4));
                    }
                    else
                    {
                        return new int4(pow2div_i32(x.x, divisor.x, d._promises),
                                        pow2div_i32(x.y, divisor.y, d._promises),
                                        pow2div_i32(x.z, divisor.z, d._promises),
                                        pow2div_i32(x.w, divisor.w, d._promises));
                    }
                }
                else
                {
                    int4 mul = *(int4*)&d._mulShift._mul;
                    int4 shift = *(int4*)&d._mulShift._shift;

                    if (Architecture.IsSIMDSupported)
                    {
                        return RegisterConversion.ToInt4(msdiv_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(mul), RegisterConversion.ToV128(shift), RegisterConversion.ToV128(divisor), d._promises, 4));
                    }
                    else
                    {
                        if (Architecture.IsBurstCompiled)
                        {
                            ulong4 mul64 = *(ulong4*)&d._bigM;

                            return new int4(bmdiv_i32(x.x, mul64.x, divisor.x, d._promises),
                                            bmdiv_i32(x.y, mul64.y, divisor.y, d._promises),
                                            bmdiv_i32(x.z, mul64.z, divisor.z, d._promises),
                                            bmdiv_i32(x.w, mul64.w, divisor.w, d._promises));
                        }
                        else
                        {
                            return new int4(msdiv_i32(x.x, mul.x, shift.x, divisor.x, d._promises),
                                            msdiv_i32(x.y, mul.y, shift.y, divisor.y, d._promises),
                                            msdiv_i32(x.z, mul.z, shift.z, divisor.z, d._promises),
                                            msdiv_i32(x.w, mul.w, shift.w, divisor.w, d._promises));
                        }
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 operator / (int8 x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(int), 8, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            if (d.DivideByScalar<int8>())
            {
                int divisor = *(int*)&d._divisor;

                if (d._promises.Pow2)
                {

                    if (Avx2.IsAvx2Supported)
                    {
                        return mm256_pow2div_epi32_si32(x, divisor, d._promises);
                    }
                    else if (Architecture.IsSIMDSupported)
                    {
                        return new int8(RegisterConversion.ToInt4(pow2div_epi32_si32(RegisterConversion.ToV128(x.v4_0), divisor, d._promises)),
                                        RegisterConversion.ToInt4(pow2div_epi32_si32(RegisterConversion.ToV128(x.v4_4), divisor, d._promises)));
                    }
                    else
                    {
                        return new int8(pow2div_i32(x.x0, divisor, d._promises),
                                        pow2div_i32(x.x1, divisor, d._promises),
                                        pow2div_i32(x.x2, divisor, d._promises),
                                        pow2div_i32(x.x3, divisor, d._promises),
                                        pow2div_i32(x.x4, divisor, d._promises),
                                        pow2div_i32(x.x5, divisor, d._promises),
                                        pow2div_i32(x.x6, divisor, d._promises),
                                        pow2div_i32(x.x7, divisor, d._promises));
                    }
                }
                else
                {
                    int mul = *(int*)&d._mulShift._mul;
                    int shift = *(int*)&d._mulShift._shift;

                    if (Avx2.IsAvx2Supported)
                    {
                        return mm256_msdiv_epi32_si32(x, mul, shift, divisor, d._promises);
                    }
                    else if (Architecture.IsSIMDSupported)
                    {
                        return new int8(RegisterConversion.ToInt4(msdiv_epi32_si32(RegisterConversion.ToV128(x.v4_0), mul, shift, divisor, d._promises)),
                                        RegisterConversion.ToInt4(msdiv_epi32_si32(RegisterConversion.ToV128(x.v4_4), mul, shift, divisor, d._promises)));
                    }
                    else
                    {
                        if (Architecture.IsBurstCompiled)
                        {
                            ulong mul64 = *(ulong*)&d._bigM;

                            return new int8(bmdiv_i32(x.x0, mul64, divisor, d._promises),
                                            bmdiv_i32(x.x1, mul64, divisor, d._promises),
                                            bmdiv_i32(x.x2, mul64, divisor, d._promises),
                                            bmdiv_i32(x.x3, mul64, divisor, d._promises),
                                            bmdiv_i32(x.x4, mul64, divisor, d._promises),
                                            bmdiv_i32(x.x5, mul64, divisor, d._promises),
                                            bmdiv_i32(x.x6, mul64, divisor, d._promises),
                                            bmdiv_i32(x.x7, mul64, divisor, d._promises));
                        }
                        else
                        {
                            return new int8(msdiv_i32(x.x0, mul, shift, divisor, d._promises),
                                            msdiv_i32(x.x1, mul, shift, divisor, d._promises),
                                            msdiv_i32(x.x2, mul, shift, divisor, d._promises),
                                            msdiv_i32(x.x3, mul, shift, divisor, d._promises),
                                            msdiv_i32(x.x4, mul, shift, divisor, d._promises),
                                            msdiv_i32(x.x5, mul, shift, divisor, d._promises),
                                            msdiv_i32(x.x6, mul, shift, divisor, d._promises),
                                            msdiv_i32(x.x7, mul, shift, divisor, d._promises));
                        }
                    }
                }
            }
            else
            {
                int8 divisor = *(int8*)&d._divisor;

                if (d._promises.Pow2)
                {
                    if (Avx2.IsAvx2Supported)
                    {
                        return mm256_pow2div_epi32(x, divisor, d._promises);
                    }
                    else if (Architecture.IsSIMDSupported)
                    {
                        return new int8(RegisterConversion.ToInt4(pow2div_epi32(RegisterConversion.ToV128(x.v4_0), RegisterConversion.ToV128(divisor.v4_0), d._promises)),
                                        RegisterConversion.ToInt4(pow2div_epi32(RegisterConversion.ToV128(x.v4_4), RegisterConversion.ToV128(divisor.v4_4), d._promises)));
                    }
                    else
                    {
                        return new int8(pow2div_i32(x.x0, divisor.x0, d._promises),
                                        pow2div_i32(x.x1, divisor.x1, d._promises),
                                        pow2div_i32(x.x2, divisor.x2, d._promises),
                                        pow2div_i32(x.x3, divisor.x3, d._promises),
                                        pow2div_i32(x.x4, divisor.x4, d._promises),
                                        pow2div_i32(x.x5, divisor.x5, d._promises),
                                        pow2div_i32(x.x6, divisor.x6, d._promises),
                                        pow2div_i32(x.x7, divisor.x7, d._promises));
                    }
                }
                else
                {
                    int8 mul = *(int8*)&d._mulShift._mul;
                    int8 shift = *(int8*)&d._mulShift._shift;

                    if (Avx2.IsAvx2Supported)
                    {
                        return mm256_msdiv_epi32(x, mul, shift, divisor, d._promises);
                    }
                    else if (Architecture.IsSIMDSupported)
                    {
                        return new int8(RegisterConversion.ToInt4(msdiv_epi32(RegisterConversion.ToV128(x.v4_0), RegisterConversion.ToV128(mul.v4_0), RegisterConversion.ToV128(shift.v4_0), RegisterConversion.ToV128(divisor.v4_0), d._promises)),
                                        RegisterConversion.ToInt4(msdiv_epi32(RegisterConversion.ToV128(x.v4_4), RegisterConversion.ToV128(mul.v4_4), RegisterConversion.ToV128(shift.v4_4), RegisterConversion.ToV128(divisor.v4_4), d._promises)));
                    }
                    else
                    {
                        if (Architecture.IsBurstCompiled)
                        {
                            ulong4 mul64Lo = *(ulong4*)&d._bigM._mulLo;
                            ulong4 mul64Hi = *(ulong4*)&d._bigM._mulHi;

                            return new int8(bmdiv_i32(x.x0, mul64Lo.x, divisor.x0, d._promises),
                                            bmdiv_i32(x.x1, mul64Lo.y, divisor.x1, d._promises),
                                            bmdiv_i32(x.x2, mul64Lo.z, divisor.x2, d._promises),
                                            bmdiv_i32(x.x3, mul64Lo.w, divisor.x3, d._promises),
                                            bmdiv_i32(x.x4, mul64Hi.x, divisor.x4, d._promises),
                                            bmdiv_i32(x.x5, mul64Hi.y, divisor.x5, d._promises),
                                            bmdiv_i32(x.x6, mul64Hi.z, divisor.x6, d._promises),
                                            bmdiv_i32(x.x7, mul64Hi.w, divisor.x7, d._promises));
                        }
                        else
                        {
                            return new int8(msdiv_i32(x.x0, mul.x0, shift.x0, divisor.x0, d._promises),
                                            msdiv_i32(x.x1, mul.x1, shift.x1, divisor.x1, d._promises),
                                            msdiv_i32(x.x2, mul.x2, shift.x2, divisor.x2, d._promises),
                                            msdiv_i32(x.x3, mul.x3, shift.x3, divisor.x3, d._promises),
                                            msdiv_i32(x.x4, mul.x4, shift.x4, divisor.x4, d._promises),
                                            msdiv_i32(x.x5, mul.x5, shift.x5, divisor.x5, d._promises),
                                            msdiv_i32(x.x6, mul.x6, shift.x6, divisor.x6, d._promises),
                                            msdiv_i32(x.x7, mul.x7, shift.x7, divisor.x7, d._promises));
                        }
                    }
                }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T operator / (long x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(long), 1, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            switch (sizeof(T))
            {
                case 4 * sizeof(long): return ((long4)x / d).Reinterpret<long4, T>();
                case 3 * sizeof(long): return ((long3)x / d).Reinterpret<long3, T>();
                case 2 * sizeof(long): return ((long2)x / d).Reinterpret<long2, T>();
                default:
                {
                    if (d._promises.Pow2)
                    {
                        return pow2div_i64(x, d._divisor.Reinterpret<T, long>(), d._promises).Reinterpret<long, T>();
                    }
                    else
                    {
                        return msdiv_i64(x, *(long*)&d._mulShift._mul, *(long*)&d._mulShift._shift, *(long*)&d._divisor, d._promises).Reinterpret<long, T>();
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator / (long2 x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(long), 2, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            if (d.DivideByScalar<long2>())
            {
                long divisor = *(long*)&d._divisor;

                if (d._promises.Pow2)
                {
                    if (Architecture.IsSIMDSupported)
                    {
                        return pow2div_epi64_si64(x, divisor, d._promises);
                    }
                    else
                    {
                        return new long2(pow2div_i64(x.x, divisor, d._promises),
                                         pow2div_i64(x.y, divisor, d._promises));
                    }
                }
                else
                {
                    long mul = *(long*)&d._mulShift._mul;
                    long shift = *(long*)&d._mulShift._shift;

                    return new long2(msdiv_i64(x.x, mul, shift, divisor, d._promises),
                                     msdiv_i64(x.y, mul, shift, divisor, d._promises));
                }
            }
            else
            {
                long2 divisor = *(long2*)&d._divisor;

                if (d._promises.Pow2)
                {
                    if (Architecture.IsSIMDSupported)
                    {
                        return pow2div_epi64(x, divisor, d._promises);
                    }
                    else
                    {
                        return new long2(pow2div_i64(x.x, divisor.x, d._promises),
                                         pow2div_i64(x.y, divisor.y, d._promises));
                    }
                }
                else
                {
                    long2 mul = *(long2*)&d._mulShift._mul;
                    long2 shift = *(long2*)&d._mulShift._shift;

                    return new long2(msdiv_i64(x.x, mul.x, shift.x, divisor.x, d._promises),
                                     msdiv_i64(x.y, mul.y, shift.y, divisor.y, d._promises));
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator / (long3 x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(long), 3, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            if (d.DivideByScalar<long3>())
            {
                long divisor = *(long*)&d._divisor;

                if (d._promises.Pow2)
                {
                    if (Avx2.IsAvx2Supported)
                    {
                        return mm256_pow2div_epi64_si64(x, divisor, d._promises);
                    }
                    else if (Architecture.IsSIMDSupported)
                    {
                        return new long3(pow2div_epi64_si64(x.xy, divisor, d._promises),
                                         pow2div_i64(x.z, divisor, d._promises));
                    }
                    else
                    {
                        return new long3(pow2div_i64(x.x, divisor, d._promises),
                                         pow2div_i64(x.y, divisor, d._promises),
                                         pow2div_i64(x.z, divisor, d._promises));
                    }
                }
                else
                {
                    long mul = *(long*)&d._mulShift._mul;
                    long shift = *(long*)&d._mulShift._shift;

                    if (Avx2.IsAvx2Supported)
                    {
                        return mm256_msdiv_epi64_si64(x, mul, shift, divisor, d._promises, 3);
                    }
                    else
                    {
                        return new long3(msdiv_i64(x.x, mul, shift, divisor, d._promises),
                                         msdiv_i64(x.y, mul, shift, divisor, d._promises),
                                         msdiv_i64(x.z, mul, shift, divisor, d._promises));
                    }
                }
            }
            else
            {
                long3 divisor = *(long3*)&d._divisor;

                if (d._promises.Pow2)
                {
                    if (Avx2.IsAvx2Supported)
                    {
                        return mm256_pow2div_epi64(x, divisor, d._promises, 3);
                    }
                    else if (Architecture.IsSIMDSupported)
                    {
                        return new long3(pow2div_epi64(x.xy, divisor.xy, d._promises),
                                         pow2div_i64(x.z, divisor.z, d._promises));
                    }
                    else
                    {
                        return new long3(pow2div_i64(x.x, divisor.x, d._promises),
                                         pow2div_i64(x.y, divisor.y, d._promises),
                                         pow2div_i64(x.z, divisor.z, d._promises));
                    }
                }
                else
                {
                    if (Avx2.IsAvx2Supported)
                    {
                        return mm256_msdiv_epi64(x, *(long3*)&d._mulShift._mul, *(long3*)&d._mulShift._shift, *(long3*)&d._divisor, d._promises, 3);
                    }
                    else
                    {
                        long3 mul = *(long3*)&d._mulShift._mul;
                        long3 shift = *(long3*)&d._mulShift._shift;

                        return new long3(msdiv_i64(x.x, mul.x, shift.x, divisor.x, d._promises),
                                         msdiv_i64(x.y, mul.y, shift.y, divisor.y, d._promises),
                                         msdiv_i64(x.z, mul.z, shift.z, divisor.z, d._promises));
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator / (long4 x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(long), 4, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            if (d.DivideByScalar<long4>())
            {
                long divisor = *(long*)&d._divisor;

                if (d._promises.Pow2)
                {
                    if (Avx2.IsAvx2Supported)
                    {
                        return mm256_pow2div_epi64_si64(x, divisor, d._promises);
                    }
                    else if (Architecture.IsSIMDSupported)
                    {
                        return new long4(pow2div_epi64_si64(x.xy, divisor, d._promises),
                                         pow2div_epi64_si64(x.zw, divisor, d._promises));
                    }
                    else
                    {
                        return new long4(pow2div_i64(x.x, divisor, d._promises),
                                         pow2div_i64(x.y, divisor, d._promises),
                                         pow2div_i64(x.z, divisor, d._promises),
                                         pow2div_i64(x.w, divisor, d._promises));
                    }
                }
                else
                {
                    long mul = *(long*)&d._mulShift._mul;
                    long shift = *(long*)&d._mulShift._shift;

                    if (Avx2.IsAvx2Supported)
                    {
                        return mm256_msdiv_epi64_si64(x, mul, shift, divisor, d._promises);
                    }
                    else
                    {
                        return new long4(msdiv_i64(x.x, mul, shift, divisor, d._promises),
                                         msdiv_i64(x.y, mul, shift, divisor, d._promises),
                                         msdiv_i64(x.z, mul, shift, divisor, d._promises),
                                         msdiv_i64(x.w, mul, shift, divisor, d._promises));
                    }
                }
            }
            else
            {
                long4 divisor = *(long4*)&d._divisor;

                if (d._promises.Pow2)
                {
                    if (Avx2.IsAvx2Supported)
                    {
                        return mm256_pow2div_epi64(x, divisor, d._promises, 4);
                    }
                    else if (Architecture.IsSIMDSupported)
                    {
                        return new long4(pow2div_epi64(x.xy, divisor.xy, d._promises),
                                         pow2div_epi64(x.zw, divisor.zw, d._promises));
                    }
                    else
                    {
                        return new long4(pow2div_i64(x.x, divisor.x, d._promises),
                                         pow2div_i64(x.y, divisor.y, d._promises),
                                         pow2div_i64(x.z, divisor.z, d._promises),
                                         pow2div_i64(x.w, divisor.w, d._promises));
                    }
                }
                else
                {
                    if (Avx2.IsAvx2Supported)
                    {
                        return mm256_msdiv_epi64(x, *(long4*)&d._mulShift._mul, *(long4*)&d._mulShift._shift, *(long4*)&d._divisor, d._promises, 4);
                    }
                    else
                    {
                        long4 mul = *(long4*)&d._mulShift._mul;
                        long4 shift = *(long4*)&d._mulShift._shift;

                        return new long4(msdiv_i64(x.x, mul.x, shift.x, divisor.x, d._promises),
                                         msdiv_i64(x.y, mul.y, shift.y, divisor.y, d._promises),
                                         msdiv_i64(x.z, mul.z, shift.z, divisor.z, d._promises),
                                         msdiv_i64(x.w, mul.w, shift.w, divisor.w, d._promises));
                    }
                }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 operator / (Int128 x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(Int128), 1, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            if (d._promises.Pow2)
            {
                return pow2div_i128(x, *(Int128*)&d._divisor, d._promises);
            }
            else
            {
                return msdiv_i128(x, *(UInt128*)&d._mulShift._mul, *(Int128*)&d._mulShift._shift, *(Int128*)&d._divisor, d._promises);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static sbyte pow2div_i8(sbyte x, sbyte original, DividerPromise promises)
        {
            byte __abs = (byte)promise_abs_i8(original, promises);

            int shift = tzcnt(__abs);
            int result = x;
            if (constexpr.IS_TRUE(original == 2 || original == -2))
            {
                result += (byte)x >> 7;
            }
            else
            {
                if (x < 0)
                {
                    result += __abs - 1;
                }
            }
            result >>= shift;

            return (sbyte)(original < 0 ? -result : result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static short pow2div_i16(short x, short original, DividerPromise promises)
        {
            ushort __abs = (ushort)promise_abs_i16(original, promises);

            int shift = tzcnt(__abs);
            int result = x;
            if (constexpr.IS_TRUE(original == 2 || original == -2))
            {
                result += (ushort)x >> 15;
            }
            else
            {
                if (x < 0)
                {
                    result += __abs - 1;
                }
            }
            result >>= shift;

            return (short)(original < 0 ? -result : result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int pow2div_i32(int x, int original, DividerPromise promises)
        {
            int __abs = promise_abs_i32(original, promises);

            int shift = tzcnt(__abs);
            int result = x;
            if (constexpr.IS_TRUE(original == 2 || original == -2))
            {
                result += (int)((uint)x >> 31);
            }
            else
            {
                if (x < 0)
                {
                    result += __abs - 1;
                }
            }
            result >>= shift;

            return original < 0 ? -result : result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static long pow2div_i64(long x, long original, DividerPromise promises)
        {
            long __abs = promise_abs_i64(original, promises);

            int shift = tzcnt(__abs);
            long result = x;
            if (constexpr.IS_TRUE(original == 2 || original == -2))
            {
                result += (long)((ulong)x >> 63);
            }
            else
            {
                if (x < 0)
                {
                    result += __abs - 1;
                }
            }
            result >>= shift;

            return original < 0 ? -result : result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Int128 pow2div_i128(Int128 x, Int128 original, DividerPromise promises)
        {
            Int128 __abs = promise_abs_i128(original, promises);

            int shift = tzcnt(__abs);
            Int128 result = x;
            if (constexpr.IS_TRUE(original == 2 || original == -2))
            {
                result += x.hi64 >> 63;
            }
            else
            {
                if ((long)x.hi64 < 0)
                {
                    result += __abs - 1;
                }
            }
            result >>= shift;

            return select(result, -result, original < 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 pow2div_epi8(v128 d, v128 original, DividerPromise promises, byte elements = 16)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 result;
                if (constexpr.ALL_EQ_EPI8(Xse.abs_epi8(original), 2, elements))
                {
                    result = Xse.sub_epi8(d, Xse.srai_epi8(d, 7, elements: elements));
                    result = Xse.srai_epi8(result, 1, elements: elements);
                }
                else
                {
                    v128 __abs = promise_abs_epi8(original, promises, elements);

                    v128 summand = Xse.dec_epi8(__abs);
                    if (Sse4_1.IsSse41Supported)
                    {
                        summand = Xse.blendv_epi8(Xse.setzero_si128(), summand, d);
                    }
                    else
                    {
                        summand = Xse.and_si128(Xse.srai_epi8(d, 7), summand);
                    }

                    result = Xse.add_epi8(d, summand);
                    result = Xse.srav_epi8(result, Xse.tzcnt_epi8(__abs), inRange: true, elements: elements);
                }

                if (promises.Positive)
                {
                    return result;
                }
                else if (promises.Negative)
                {
                    return Xse.neg_epi8(result);
                }
                else
                {
                    if (Ssse3.IsSsse3Supported)
                    {
                        return Xse.sign_epi8(result, original);
                    }
                    else
                    {
                        v128 sign = Xse.srai_epi8(original, 7);

                        result = Xse.xor_si128(result, sign);
                        result = Xse.sub_epi8(result, sign);

                        return result;
                    }
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 pow2div_epi16(v128 d, v128 original, DividerPromise promises, byte elements = 8)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 result;
                if (constexpr.ALL_EQ_EPI16(Xse.abs_epi16(original), 2, elements))
                {
                    result = Xse.sub_epi16(d, Xse.srai_epi16(d, 15));
                    result = Xse.srai_epi16(result, 1);
                }
                else
                {
                    v128 __abs = promise_abs_epi16(original, promises, elements);

                    v128 summand = Xse.dec_epi16(__abs);
                    summand = Xse.and_si128(Xse.srai_epi16(d, 15), summand);

                    result = Xse.add_epi16(d, summand);
                    result = Xse.srav_epi16(result, Xse.tzcnt_epi16(__abs), inRange: true, elements: elements);
                }

                if (promises.Positive)
                {
                    return result;
                }
                else if (promises.Negative)
                {
                    return Xse.neg_epi16(result);
                }
                else
                {
                    if (Ssse3.IsSsse3Supported)
                    {
                        return Xse.sign_epi16(result, original);
                    }
                    else
                    {
                        v128 sign = Xse.srai_epi16(original, 15);

                        result = Xse.xor_si128(result, sign);
                        result = Xse.sub_epi16(result, sign);

                        return result;
                    }
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 pow2div_epi32(v128 d, v128 original, DividerPromise promises, byte elements = 4)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 result;
                if (constexpr.ALL_EQ_EPI32(Xse.abs_epi32(original), 2, elements))
                {
                    result = Xse.sub_epi32(d, Xse.srai_epi32(d, 31));
                    result = Xse.srai_epi32(result, 1);
                }
                else
                {
                    v128 __abs = promise_abs_epi32(original, promises, elements);

                    v128 summand = Xse.dec_epi32(__abs);
                    if (Sse4_1.IsSse41Supported)
                    {
                        summand = Xse.blendv_ps(Xse.setzero_si128(), summand, d);
                    }
                    else
                    {
                        summand = Xse.and_si128(Xse.srai_epi32(d, 31), summand);
                    }

                    result = Xse.add_epi32(d, summand);
                    result = Xse.srav_epi32(result, Xse.tzcnt_epi32(__abs), inRange: true, elements: elements);
                }

                if (promises.Positive)
                {
                    return result;
                }
                else if (promises.Negative)
                {
                    return Xse.neg_epi32(result);
                }
                else
                {
                    if (Ssse3.IsSsse3Supported)
                    {
                        return Xse.sign_epi32(result, original);
                    }
                    else
                    {
                        v128 sign = Xse.srai_epi32(original, 31);

                        result = Xse.xor_si128(result, sign);
                        result = Xse.sub_epi32(result, sign);

                        return result;
                    }
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 pow2div_epi64(v128 d, v128 original, DividerPromise promises)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 result;
                if (constexpr.ALL_EQ_EPI64(Xse.abs_epi64(original), 2))
                {
                    result = Xse.add_epi64(d, Xse.srli_epi64(d, 63));
                    result = Xse.srai_epi64(result, 1);
                }
                else
                {
                    v128 __abs = promise_abs_epi64(original, promises);

                    v128 summand = Xse.dec_epi64(__abs);
                    if (Sse4_1.IsSse41Supported)
                    {
                        summand = Xse.blendv_pd(Xse.setzero_si128(), summand, d);
                    }
                    else
                    {
                        summand = Xse.and_si128(Xse.srai_epi64(d, 63), summand);
                    }

                    result = Xse.add_epi64(d, summand);
                    result = Xse.srav_epi64(result, Xse.tzcnt_epi64(__abs), inRange: true);
                }

                if (promises.Positive)
                {
                    return result;
                }
                else if (promises.Negative)
                {
                    return Xse.neg_epi64(result);
                }
                else
                {
                    v128 sign = Xse.srai_epi64(original, 63);

                    result = Xse.xor_si128(result, sign);
                    result = Xse.sub_epi64(result, sign);

                    return result;
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_pow2div_epi8(v256 d, v256 original, DividerPromise promises)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 result;
                if (constexpr.ALL_EQ_EPI8(Xse.mm256_abs_epi8(original), 2))
                {
                    result = Avx2.mm256_sub_epi8(d, Xse.mm256_srai_epi8(d, 7));
                    result = Xse.mm256_srai_epi8(result, 1);
                }
                else
                {
                    v256 __abs = mm256_promise_abs_epi8(original, promises);

                    v256 summand = Xse.mm256_dec_epi8(__abs);
                    summand = Avx2.mm256_blendv_epi8(Avx.mm256_setzero_si256(), summand, d);
                    result = Avx2.mm256_add_epi8(d, summand);
                    result = Xse.mm256_srav_epi8(result, Xse.mm256_tzcnt_epi8(__abs));
                }

                if (promises.Positive)
                {
                    return result;
                }
                else if (promises.Negative)
                {
                    return Xse.mm256_neg_epi8(result);
                }
                else
                {
                    return Avx2.mm256_sign_epi8(result, original);
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_pow2div_epi16(v256 d, v256 original, DividerPromise promises)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 result;
                if (constexpr.ALL_EQ_EPI16(Xse.mm256_abs_epi16(original), 2))
                {
                    result = Avx2.mm256_sub_epi16(d, Xse.mm256_srai_epi16(d, 15));
                    result = Xse.mm256_srai_epi16(result, 1);
                }
                else
                {
                    v256 __abs = mm256_promise_abs_epi16(original, promises);

                    v256 summand = Xse.mm256_dec_epi16(__abs);
                    summand = Avx2.mm256_and_si256(Xse.mm256_srai_epi16(d, 15), summand);
                    result = Avx2.mm256_add_epi16(d, summand);
                    result = Xse.mm256_srav_epi16(result, Xse.mm256_tzcnt_epi16(__abs));
                }

                if (promises.Positive)
                {
                    return result;
                }
                else if (promises.Negative)
                {
                    return Xse.mm256_neg_epi16(result);
                }
                else
                {
                    return Avx2.mm256_sign_epi16(result, original);
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_pow2div_epi32(v256 d, v256 original, DividerPromise promises)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 result;
                if (constexpr.ALL_EQ_EPI32(Xse.mm256_abs_epi32(original), 2))
                {
                    result = Avx2.mm256_sub_epi32(d, Xse.mm256_srai_epi32(d, 31));
                    result = Xse.mm256_srai_epi32(result, 1);
                }
                else
                {
                    v256 __abs = mm256_promise_abs_epi32(original, promises);

                    v256 summand = Xse.mm256_dec_epi32(__abs);
                    summand = Avx.mm256_blendv_ps(Avx.mm256_setzero_si256(), summand, d);
                    result = Avx2.mm256_add_epi32(d, summand);

                    result = Avx2.mm256_srav_epi32(result, Xse.mm256_tzcnt_epi32(__abs));
                }

                if (promises.Positive)
                {
                    return result;
                }
                else if (promises.Negative)
                {
                    return Xse.mm256_neg_epi32(result);
                }
                else
                {
                    return Avx2.mm256_sign_epi32(result, original);
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_pow2div_epi64(v256 d, v256 original, DividerPromise promises, byte elements = 4)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 result;
                if (constexpr.ALL_EQ_EPI64(Xse.mm256_abs_epi64(original), 2, elements))
                {
                    result = Avx2.mm256_add_epi64(d, Avx2.mm256_srli_epi64(d, 63));
                    result = Xse.mm256_srai_epi64(result, 1, elements);
                }
                else
                {
                    v256 __abs = mm256_promise_abs_epi64(original, promises, elements);

                    v256 summand = Xse.mm256_dec_epi64(__abs);
                    summand = Avx.mm256_blendv_pd(Avx.mm256_setzero_si256(), summand, d);
                    result = Avx2.mm256_add_epi64(d, summand);
                    result = Xse.mm256_srav_epi64(result, Xse.mm256_tzcnt_epi64(__abs));
                }

                if (promises.Positive)
                {
                    return result;
                }
                else if (promises.Negative)
                {
                    return Xse.mm256_neg_epi64(result);
                }
                else
                {
                    v256 sign = Xse.mm256_srai_epi64(original, 63);

                    result = Avx2.mm256_xor_si256(result, sign);
                    result = Avx2.mm256_sub_epi64(result, sign);

                    return result;
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 pow2div_epi8_si8(v128 d, sbyte original, DividerPromise promises)
        {
            if (Architecture.IsSIMDSupported)
            {
                sbyte __abs = promise_abs_i8(original, promises);

                int shift = tzcnt(__abs);
                v128 result = d;
                v128 summand = Xse.dec_epi8(Xse.set1_epi8(__abs));
                if (constexpr.IS_TRUE(original == 2 || original == -2))
                {
                    result = Xse.sub_epi8(result, Xse.srai_epi8(d, 7));
                }
                else
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        result = Xse.add_epi8(result, Xse.blendv_epi8(Xse.setzero_si128(), summand, d));
                    }
                    else
                    {
                        result = Xse.add_epi8(result, Xse.and_si128(Xse.srai_epi8(d, 7), summand));
                    }
                }

                result = Xse.srai_epi8(result, shift, inRange: true);

                if (promises.Positive)
                {
                    return result;
                }
                else if (promises.Negative)
                {
                    return Xse.neg_epi8(result);
                }
                else
                {
                    if (Ssse3.IsSsse3Supported)
                    {
                        return Xse.sign_epi8(result, Xse.set1_epi8(original));
                    }
                    else
                    {
                        v128 sign = Xse.set1_epi8((sbyte)(original >> 7));

                        result = Xse.xor_si128(result, sign);
                        result = Xse.sub_epi8(result, sign);

                        return result;
                    }
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 pow2div_epi16_si16(v128 d, short original, DividerPromise promises)
        {
            if (Architecture.IsSIMDSupported)
            {
                short __abs = promise_abs_i16(original, promises);

                int shift = tzcnt(__abs);
                v128 result = d;
                if (constexpr.IS_TRUE(original == 2 || original == -2))
                {
                    result = Xse.add_epi16(result, Xse.srli_epi16(d, 15));
                }
                else
                {
                    v128 summand = Xse.dec_epi16(Xse.set1_epi16(__abs));
                    summand = Xse.and_si128(Xse.srai_epi16(d, 15), summand);

                    result = Xse.add_epi16(result, summand);
                }

                result = Xse.srai_epi16(result, shift, inRange: true);

                if (promises.Positive)
                {
                    return result;
                }
                else if (promises.Negative)
                {
                    return Xse.neg_epi16(result);
                }
                else
                {
                    if (Ssse3.IsSsse3Supported)
                    {
                        return Xse.sign_epi16(result, Xse.set1_epi16(original));
                    }
                    else
                    {
                        v128 sign = Xse.set1_epi16((short)(original >> 15));

                        result = Xse.xor_si128(result, sign);
                        result = Xse.sub_epi16(result, sign);

                        return result;
                    }
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 pow2div_epi32_si32(v128 d, int original, DividerPromise promises)
        {
            if (Architecture.IsSIMDSupported)
            {
                int __abs = promise_abs_i32(original, promises);

                int shift = tzcnt(__abs);
                v128 result = d;
                v128 summand = Xse.dec_epi32(Xse.set1_epi32(__abs));
                if (constexpr.IS_TRUE(original == 2 || original == -2))
                {
                    result = Xse.add_epi32(result, Xse.srli_epi32(d, 31));
                }
                else
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        result = Xse.add_epi32(result, Xse.blendv_ps(Xse.setzero_si128(), summand, d));
                    }
                    else
                    {
                        result = Xse.add_epi32(result, Xse.and_si128(Xse.srai_epi32(d, 31), summand));
                    }
                }

                result = Xse.srai_epi32(result, shift, inRange: true);

                if (promises.Positive)
                {
                    return result;
                }
                else if (promises.Negative)
                {
                    return Xse.neg_epi32(result);
                }
                else
                {
                    if (Ssse3.IsSsse3Supported)
                    {
                        return Xse.sign_epi32(result, Xse.set1_epi32(original));
                    }
                    else
                    {
                        v128 sign = Xse.set1_epi32(original >> 31);

                        result = Xse.xor_si128(result, sign);
                        result = Xse.sub_epi32(result, sign);

                        return result;
                    }
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 pow2div_epi64_si64(v128 d, long original, DividerPromise promises)
        {
            if (Architecture.IsSIMDSupported)
            {
                long __abs = promise_abs_i64(original, promises);

                int shift = tzcnt(__abs);
                v128 result = d;
                v128 summand = Xse.dec_epi64(Xse.set1_epi64x(__abs));
                if (constexpr.IS_TRUE(original == 2 || original == -2))
                {
                    result = Xse.add_epi64(result, Xse.srli_epi64(d, 63));
                }
                else
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        result = Xse.add_epi64(result, Xse.blendv_pd(Xse.setzero_si128(), summand, d));
                    }
                    else
                    {
                        result = Xse.add_epi64(result, Xse.and_si128(Xse.srai_epi64(d, 63), summand));
                    }
                }

                result = Xse.srai_epi64(result, shift, inRange: true);

                if (promises.Positive)
                {
                    return result;
                }
                else if (promises.Negative)
                {
                    return Xse.neg_epi64(result);
                }
                else
                {
                    v128 sign = Xse.set1_epi64x(original >> 63);

                    result = Xse.xor_si128(result, sign);
                    result = Xse.sub_epi64(result, sign);

                    return result;
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_pow2div_epi8_si8(v256 d, sbyte original, DividerPromise promises)
        {
            if (Avx2.IsAvx2Supported)
            {
                sbyte __abs = promise_abs_i8(original, promises);
                int shift = tzcnt(__abs);
                v256 result;
                if (constexpr.IS_TRUE(original == 2 || original == -2))
                {
                    result = Avx2.mm256_sub_epi8(d, Xse.mm256_srai_epi8(d, 7));
                }
                else
                {
                    v256 summand = Xse.mm256_dec_epi8(Xse.mm256_set1_epi8(__abs));
                    summand = Avx2.mm256_blendv_epi8(Avx.mm256_setzero_si256(), summand, d);
                    result = Avx2.mm256_add_epi8(d, summand);
                }

                result = Xse.mm256_srai_epi8(result, shift);

                if (promises.Positive)
                {
                    return result;
                }
                else if (promises.Negative)
                {
                    return Xse.mm256_neg_epi8(result);
                }
                else
                {
                    return Avx2.mm256_sign_epi8(result, Xse.mm256_set1_epi8(original));
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_pow2div_epi16_si16(v256 d, short original, DividerPromise promises)
        {
            if (Avx2.IsAvx2Supported)
            {
                short __abs = promise_abs_i16(original, promises);
                int shift = tzcnt(__abs);
                v256 result;
                if (constexpr.IS_TRUE(original == 2 || original == -2))
                {
                    result = Avx2.mm256_add_epi16(d, Avx2.mm256_srli_epi16(d, 15));
                }
                else
                {
                    v256 summand = Xse.mm256_dec_epi16(Xse.mm256_set1_epi16(__abs));
                    summand = Avx2.mm256_and_si256(Xse.mm256_srai_epi16(d, 15), summand);
                    result = Avx2.mm256_add_epi16(d, summand);
                }

                result = Xse.mm256_srai_epi16(result, shift);

                if (promises.Positive)
                {
                    return result;
                }
                else if (promises.Negative)
                {
                    return Xse.mm256_neg_epi16(result);
                }
                else
                {
                    return Avx2.mm256_sign_epi16(result, Xse.mm256_set1_epi16(original));
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_pow2div_epi32_si32(v256 d, int original, DividerPromise promises)
        {
            if (Avx2.IsAvx2Supported)
            {
                int __abs = promise_abs_i32(original, promises);
                int shift = tzcnt(__abs);
                v256 result;
                if (constexpr.IS_TRUE(original == 2 || original == -2))
                {
                    result = Avx2.mm256_add_epi32(d, Avx2.mm256_srli_epi32(d, 31));
                }
                else
                {
                    v256 summand = Xse.mm256_dec_epi32(Xse.mm256_set1_epi32(__abs));
                    summand = Avx.mm256_blendv_ps(Avx.mm256_setzero_si256(), summand, d);
                    result = Avx2.mm256_add_epi32(d, summand);
                }

                result = Xse.mm256_srai_epi32(result, shift);

                if (promises.Positive)
                {
                    return result;
                }
                else if (promises.Negative)
                {
                    return Xse.mm256_neg_epi32(result);
                }
                else
                {
                    return Avx2.mm256_sign_epi32(result, Xse.mm256_set1_epi32(original));
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_pow2div_epi64_si64(v256 d, long original, DividerPromise promises)
        {
            if (Avx2.IsAvx2Supported)
            {
                long __abs = promise_abs_i64(original, promises);
                int shift = tzcnt(__abs);
                v256 result;
                if (constexpr.IS_TRUE(original == 2 || original == -2))
                {
                    result = Avx2.mm256_add_epi64(d, Avx2.mm256_srli_epi64(d, 63));
                }
                else
                {
                    v256 summand = Xse.mm256_dec_epi64(Xse.mm256_set1_epi64x(__abs));
                    summand = Avx.mm256_blendv_pd(Avx.mm256_setzero_si256(), summand, d);
                    result = Avx2.mm256_add_epi64(d, summand);
                }

                result = Xse.mm256_srai_epi64(result, shift);

                if (promises.Positive)
                {
                    return result;
                }
                else if (promises.Negative)
                {
                    return Xse.mm256_neg_epi64(result);
                }
                else
                {
                    v256 sign = Xse.mm256_set1_epi64x(original >> 63);

                    result = Avx2.mm256_xor_si256(result, sign);
                    result = Avx2.mm256_sub_epi64(result, sign);

                    return result;
                }
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static sbyte bmdiv_i8(sbyte x, ushort mul, sbyte original, DividerPromise promises)
        {
            sbyte __abs = promise_abs_i8(original, promises);
            byte absResult = bmdiv_u8((byte)abs(x), (byte)__abs, mul, promises);

            return Xse.SIGNED_FROM_UNSIGNED_DIV_I8(out _, x, original, absResult, 0, divisorNegative: promises.Negative, divisorPositive: promises.Positive);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static short bmdiv_i16(short x, uint mul, short original, DividerPromise promises)
        {
            short __abs = promise_abs_i16(original, promises);
            ushort absResult = bmdiv_u16((ushort)abs(x), (ushort)__abs, mul, promises);

            return Xse.SIGNED_FROM_UNSIGNED_DIV_I16(out _, x, original, absResult, 0, divisorNegative: promises.Negative, divisorPositive: promises.Positive);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int bmdiv_i32(int x, ulong mul, int original, DividerPromise promises)
        {
            ulong highbits = (mul * (UInt128)x).hi64;
            highbits += (uint)x >> 31;
            int q = (int)highbits;

            if (!promises.NotOne)
            {
                bool test1;
                if (promises.Positive)
                {
                    test1 = original == 1;
                }
                else if (promises.Negative)
                {
                    test1 = original == -1;
                }
                else
                {
                    test1 = abs(original) == 1;
                }

                if (test1)
                {
                    q = x;
                }
            }

            if (!promises.NotMinValue)
            {
                q = andnot(q, tobyte(original == int.MinValue));
                q |= -tobyte((original == int.MinValue) & (x == int.MinValue));
            }

            if (promises.Positive)
            {
                return q;
            }
            else if (promises.Negative)
            {
                return -q;
            }
            else
            {
                return original <= 0 ? -q : q;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int msdiv_i32(int dividend, int mul, int shift, int original, DividerPromise promises)
        {
            int result = dividend + (int)((dividend * (long)mul) >> 32);

            int n = (int)((uint)result >> 31);
            if (!promises.NotOne)
            {
                n |= tobyte((dividend == int.MinValue) & (original == 1 | original == -1));
            }

            result >>= shift;
            result += n;
            result ^= original >> 31;
            result -= original >> 31;

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static long msdiv_i64(long dividend, long mul, long shift, long original, DividerPromise promises)
        {
            Int128 product = UInt128.imul128(dividend, mul);
            long result = (long)product.hi64 + dividend;

            long n = (long)((ulong)result >> 63);
            if (!promises.NotOne)
            {
                n |= tobyte((dividend == long.MinValue) & (original == 1 | original == -1));
            }

            result >>= (int)shift;
            result += n;
            result ^= original >> 63;
            result -= original >> 63;

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Int128 msdiv_i128(Int128 dividend, UInt128 mul, Int128 shift, Int128 original, DividerPromise promises)
        {
            Int128 __abs = promise_abs_i128(original, promises);
            UInt128 t = msdiv_u128((UInt128)abs(dividend), (UInt128)__abs, mul, (UInt128)shift, promises);

            return Xse.SIGNED_FROM_UNSIGNED_DIV_I128(out _, (long)dividend.hi64, (long)original.hi64, t, default(UInt128), divisorPositive: promises.Positive, divisorNegative: promises.Negative);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 bmdiv_epi8(v128 d, v128 mul, v128 original, DividerPromise promises, byte elements = 8)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 __abs = promise_abs_epi8(original, promises, elements);
                v128 absResult = bmdiv_epu8(Xse.abs_epi8(d, elements), __abs, mul, promises, elements);

                return Xse.SIGNED_FROM_UNSIGNED_DIV_EPI8(out _, d, original, absResult, default(v128), elements: elements, divisorNegative: promises.Negative, divisorPositive: promises.Positive);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 bmdiv_epi16(v128 d, v128 mul, v128 original, DividerPromise promises, byte elements = 4)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 __abs = promise_abs_epi16(original, promises, elements);
                v128 absResult = bmdiv_epu16(Xse.abs_epi16(d, elements), __abs, mul, promises, elements);

                return Xse.SIGNED_FROM_UNSIGNED_DIV_EPI16(out _, d, original, absResult, default(v128), elements: elements, divisorNegative: promises.Negative, divisorPositive: promises.Positive);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 msdiv_epi16(v128 a, v128 mul, v128 shift, v128 original, DividerPromise promises, byte elements = 8)
        {
            if (Avx2.IsAvx2Supported) // intentional
            {
                v128 result = Xse.add_epi16(a, Xse.mulhi_epi16(a, mul));

                v128 n = Xse.srli_epi16(result, 15);
                if (!promises.NotOne)
                {
                    v128 __abs = promise_abs_epi16(original, promises, elements);

                    n = Xse.sub_epi16(n, Xse.and_si128(Xse.cmpeq_epi16(a, Xse.set1_epi16(short.MinValue)), Xse.cmpeq_epi16(__abs, Xse.set1_epi16(1))));
                }

                result = Xse.srav_epi16(result, shift, inRange: true, elements: elements);
                result = Xse.add_epi16(result, n);

                if (promises.Positive)
                {
                    return result;
                }
                else if (promises.Negative)
                {
                    return Xse.neg_epi16(result);
                }
                else
                {
                    return Xse.sign_epi16(result, original);
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 bmdiv_epi8(v128 d, v128 mulLo, v128 mulHi, v128 original, DividerPromise promises)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 __abs = promise_abs_epi8(original, promises);
                v128 absResult = bmdiv_epu8(Xse.abs_epi8(d), __abs, mulLo, mulHi, promises);

                return Xse.SIGNED_FROM_UNSIGNED_DIV_EPI8(out _, d, original, absResult, default(v128), divisorNegative: promises.Negative, divisorPositive: promises.Positive);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 bmdiv_epi16(v128 d, v128 mulLo, v128 mulHi, v128 original, DividerPromise promises)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 __abs = promise_abs_epi16(original, promises);
                v128 absResult = bmdiv_epu16(Xse.abs_epi16(d), __abs, mulLo, mulHi, promises);

                return Xse.SIGNED_FROM_UNSIGNED_DIV_EPI16(out _, d, original, absResult, default(v128), divisorNegative: promises.Negative, divisorPositive: promises.Positive);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 msdiv_epi32(v128 a, v128 mul, v128 shift, v128 original, DividerPromise promises, byte elements = 4)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 result = Xse.add_epi32(a, Xse.mulhi_epi32(a, mul, elements));

                v128 n = Xse.srli_epi32(result, 31);
                if (!promises.NotOne)
                {
                    v128 __abs = promise_abs_epi32(original, promises, elements);

                    n = Xse.sub_epi32(n, Xse.and_si128(Xse.cmpeq_epi32(a, Xse.set1_epi32(int.MinValue)), Xse.cmpeq_epi32(__abs, Xse.set1_epi32(1))));
                }

                result = Xse.srav_epi32(result, shift, inRange: true, elements: elements);
                result = Xse.add_epi32(result, n);

                if (promises.Positive)
                {
                    return result;
                }
                else if (promises.Negative)
                {
                    return Xse.neg_epi32(result);
                }
                else
                {
                    if (Ssse3.IsSsse3Supported)
                    {
                        return Xse.sign_epi32(result, original);
                    }
                    else
                    {
                        result = Xse.xor_si128(result, Xse.srai_epi32(original, 31));
                        result = Xse.sub_epi32(result, Xse.srai_epi32(original, 31));

                        return result;
                    }
                }
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_bmdiv_epi8(v256 d, v256 mulLo, v256 mulHi, v256 original, DividerPromise promises)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 __abs = mm256_promise_abs_epi8(original, promises);
                v256 absResult = mm256_bmdiv_epu8(Xse.mm256_abs_epi8(d), __abs, mulLo, mulHi, promises);

                return Xse.SIGNED_FROM_UNSIGNED_DIV_EPI8(out _, d, original, absResult, default(v256), divisorNegative: promises.Negative, divisorPositive: promises.Positive);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_msdiv_epi16(v256 a, v256 mul, v256 shift, v256 original, DividerPromise promises)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 result = Avx2.mm256_add_epi16(a, Avx2.mm256_mulhi_epi16(a, mul));

                v256 n = Avx2.mm256_srli_epi16(result, 15);
                if (!promises.NotOne)
                {
                    v256 __abs = mm256_promise_abs_epi16(original, promises);

                    n = Avx2.mm256_sub_epi16(n, Avx2.mm256_and_si256(Avx2.mm256_cmpeq_epi16(a, Xse.mm256_set1_epi16(short.MinValue)), Avx2.mm256_cmpeq_epi16(__abs, Xse.mm256_set1_epi16(1))));
                }

                result = Xse.mm256_srav_epi16(result, shift);
                result = Avx2.mm256_add_epi16(result, n);

                if (!promises.Positive)
                {
                    result = Avx2.mm256_sign_epi16(result, original);
                }

                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_msdiv_epi32(v256 a, v256 mul, v256 shift, v256 original, DividerPromise promises)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 result = Avx2.mm256_add_epi32(a, Xse.mm256_mulhi_epi32(a, mul));

                v256 n = Avx2.mm256_srli_epi32(result, 31);
                if (!promises.NotOne)
                {
                    v256 __abs = mm256_promise_abs_epi32(original, promises);

                    n = Avx2.mm256_sub_epi32(n, Avx2.mm256_and_si256(Avx2.mm256_cmpeq_epi32(a, Xse.mm256_set1_epi32(int.MinValue)), Avx2.mm256_cmpeq_epi32(__abs, Xse.mm256_set1_epi32(1))));
                }

                result = Avx2.mm256_srav_epi32(result, shift);
                result = Avx2.mm256_add_epi32(result, n);

                if (!promises.Positive)
                {
                    result = Avx2.mm256_sign_epi32(result, original);
                }

                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_msdiv_epi64(v256 a, v256 mul, v256 shift, v256 original, DividerPromise promises, byte elements = 4)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 result = Avx2.mm256_add_epi64(a, Xse.mm256_mulhi_epi64(a, mul, elements));

                v256 n = Avx2.mm256_srli_epi64(result, 63);
                if (!promises.NotOne)
                {
                    v256 __abs = mm256_promise_abs_epi64(original, promises, elements);

                    n = Avx2.mm256_sub_epi64(n, Avx2.mm256_and_si256(Avx2.mm256_cmpeq_epi64(a, Xse.mm256_set1_epi64x(long.MinValue)), Avx2.mm256_cmpeq_epi64(__abs, Xse.mm256_set1_epi64x(1))));
                }

                result = Xse.mm256_srav_epi64(result, shift, elements);
                result = Avx2.mm256_add_epi64(result, n);

                if (promises.Positive)
                {
                    return result;
                }
                else if (promises.Negative)
                {
                    return Xse.mm256_neg_epi64(result);
                }
                else
                {
                    result = Avx2.mm256_xor_si256(result, Xse.mm256_srai_epi64(original, 63, elements));
                    result = Avx2.mm256_sub_epi64(result, Xse.mm256_srai_epi64(original, 63, elements));

                    return result;
                }
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 bmdiv_epi8_si8(v128 d, ushort mul, sbyte original, DividerPromise promises, byte elements = 16)
        {
            if (Architecture.IsSIMDSupported)
            {
                sbyte __abs = promise_abs_i8(original, promises);
                v128 absResult = bmdiv_epu8_su8(Xse.abs_epi8(d, elements), (byte)__abs, mul, promises, elements);

                return Xse.SIGNED_FROM_UNSIGNED_DIV_EPI8(out _, d, Xse.set1_epi8(original), absResult, default(v128), elements: elements, divisorNegative: promises.Negative, divisorPositive: promises.Positive);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 msdiv_epi16_si16(v128 a, short mul, short shift, short original, DividerPromise promises, byte elements = 8)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 __original = Xse.set1_epi16(original, elements);

                v128 result = Xse.add_epi16(a, Xse.mulhi_epi16(a, Xse.set1_epi16(mul, elements)));

                v128 n = Xse.srli_epi16(result, 15);
                if (!promises.NotOne)
                {
                    v128 __abs = promise_abs_epi16(__original, promises, elements);

                    n = Xse.sub_epi16(n, Xse.and_si128(Xse.cmpeq_epi16(a, Xse.set1_epi16(short.MinValue)), Xse.cmpeq_epi16(__abs, Xse.set1_epi16(1))));
                }

                result = Xse.srai_epi16(result, (ushort)shift, inRange: true);
                result = Xse.add_epi16(result, n);

                if (promises.Positive)
                {
                    return result;
                }
                else if (promises.Negative)
                {
                    return Xse.neg_epi16(result);
                }
                else
                {
                    if (Ssse3.IsSsse3Supported)
                    {
                        return Xse.sign_epi16(result, __original);
                    }
                    else
                    {
                        return original >= 0 ? result : Xse.neg_epi16(result);
                    }
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 msdiv_epi32_si32(v128 a, int mul, int shift, int original, DividerPromise promises, byte elements = 4)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 __original = Xse.set1_epi32(original);

                v128 result = Xse.add_epi32(a, Xse.mulhi_epi32(a, Xse.set1_epi32(mul), elements));

                v128 n = Xse.srli_epi32(result, 31);
                if (!promises.NotOne)
                {
                    v128 __abs = promise_abs_epi32(__original, promises, elements);

                    n = Xse.sub_epi32(n, Xse.and_si128(Xse.cmpeq_epi32(a, Xse.set1_epi32(int.MinValue)), Xse.cmpeq_epi32(__abs, Xse.set1_epi32(1))));
                }

                result = Xse.srai_epi32(result, shift, inRange: true);
                result = Xse.add_epi32(result, n);

                if (promises.Positive)
                {
                    return result;
                }
                else if (promises.Negative)
                {
                    return Xse.neg_epi32(result);
                }
                else
                {
                    if (Ssse3.IsSsse3Supported)
                    {
                        return Xse.sign_epi32(result, __original);
                    }
                    else
                    {
                        return original >= 0 ? result : Xse.neg_epi32(result);
                    }
                }
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_bmdiv_epi8_si8(v256 d, ushort mul, sbyte original, DividerPromise promises)
        {
            if (Avx2.IsAvx2Supported)
            {
                sbyte __abs = promise_abs_i8(original, promises);
                v256 absResult = mm256_bmdiv_epu8_su8(Xse.mm256_abs_epi8(d), (byte)__abs, mul, promises);

                return Xse.SIGNED_FROM_UNSIGNED_DIV_EPI8(out _, d, Xse.mm256_set1_epi8(original), absResult, default(v256), divisorNegative: promises.Negative, divisorPositive: promises.Positive);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_msdiv_epi16_si16(v256 a, short mul, short shift, short original, DividerPromise promises)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 __original = Xse.mm256_set1_epi16(original);

                v256 result = Avx2.mm256_add_epi16(a, Avx2.mm256_mulhi_epi16(a, Xse.mm256_set1_epi16(mul)));

                v256 n = Avx2.mm256_srli_epi16(result, 15);
                if (!promises.NotOne)
                {
                    v256 __abs = mm256_promise_abs_epi16(__original, promises);

                    n = Avx2.mm256_sub_epi16(n, Avx2.mm256_and_si256(Avx2.mm256_cmpeq_epi16(a, Xse.mm256_set1_epi16(short.MinValue)), Avx2.mm256_cmpeq_epi16(__abs, Xse.mm256_set1_epi16(1))));
                }

                result = Avx2.mm256_sra_epi16(result, Xse.cvtsi32_si128((ushort)shift));
                result = Avx2.mm256_add_epi16(result, n);

                if (promises.Positive)
                {
                    return result;
                }
                else if (promises.Negative)
                {
                    return Xse.mm256_neg_epi16(result);
                }
                else
                {
                    return Avx2.mm256_sign_epi16(result, __original);
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_msdiv_epi32_si32(v256 a, int mul, int shift, int original, DividerPromise promises)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 __original = Xse.mm256_set1_epi32(original);

                v256 result = Avx2.mm256_add_epi32(a, Xse.mm256_mulhi_epi32(a, Xse.mm256_set1_epi32(mul)));

                v256 n = Avx2.mm256_srli_epi32(result, 31);
                if (!promises.NotOne)
                {
                    v256 __abs = mm256_promise_abs_epi32(__original, promises);

                    n = Avx2.mm256_sub_epi32(n, Avx2.mm256_and_si256(Avx2.mm256_cmpeq_epi32(a, Xse.mm256_set1_epi32(int.MinValue)), Avx2.mm256_cmpeq_epi32(__abs, Xse.mm256_set1_epi32(1))));
                }

                result = Avx2.mm256_sra_epi32(result, Xse.cvtsi32_si128(shift));
                result = Avx2.mm256_add_epi32(result, n);

                if (promises.Positive)
                {
                    return result;
                }
                else if (promises.Negative)
                {
                    return Xse.mm256_neg_epi32(result);
                }
                else
                {
                    return Avx2.mm256_sign_epi32(result, __original);
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_msdiv_epi64_si64(v256 a, long mul, long shift, long original, DividerPromise promises, byte elements = 4)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 __original = Xse.mm256_set1_epi64x(original);

                v256 result = Avx2.mm256_add_epi64(a, Xse.mm256_mulhi_epi64(a, Xse.mm256_set1_epi64x(mul), elements));

                v256 n = Avx2.mm256_srli_epi64(result, 63);
                if (!promises.NotOne)
                {
                    v256 __abs = mm256_promise_abs_epi64(__original, promises, elements);

                    n = Avx2.mm256_sub_epi64(n, Avx2.mm256_and_si256(Avx2.mm256_cmpeq_epi64(a, Xse.mm256_set1_epi64x(long.MinValue)), Avx2.mm256_cmpeq_epi64(__abs, Xse.mm256_set1_epi64x(1))));
                }

                result = Xse.mm256_srai_epi64(result, (int)shift, elements);
                result = Avx2.mm256_add_epi64(result, n);

                if (promises.Positive)
                {
                    return result;
                }
                else if (promises.Negative)
                {
                    return Xse.mm256_neg_epi64(result);
                }
                else
                {
                    if (original <= 0)
                    {
                        result = Avx2.mm256_xor_si256(result, Xse.mm256_srai_epi64(__original, 63, elements));
                        result = Avx2.mm256_sub_epi64(result, Xse.mm256_srai_epi64(__original, 63, elements));
                    }

                    return result;
                }
            }
            else throw new IllegalInstructionException();
        }
    }
}
