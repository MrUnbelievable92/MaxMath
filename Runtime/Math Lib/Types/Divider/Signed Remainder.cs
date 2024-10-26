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
        public static T operator % (sbyte x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(sbyte), 1, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            switch (sizeof(T))
            {
                case 32 * sizeof(sbyte): return ((sbyte32)x % d).Reinterpret<sbyte32, T>();
                case 16 * sizeof(sbyte): return ((sbyte16)x % d).Reinterpret<sbyte16, T>();
                case  8 * sizeof(sbyte): return ((sbyte8) x % d).Reinterpret<sbyte8,  T>();
                case  4 * sizeof(sbyte): return ((sbyte4) x % d).Reinterpret<sbyte4,  T>();
                case  3 * sizeof(sbyte): return ((sbyte3) x % d).Reinterpret<sbyte3,  T>();
                case  2 * sizeof(sbyte): return ((sbyte2) x % d).Reinterpret<sbyte2,  T>();
                default:
                {
                    if (d._promises.Pow2)
                    {
                        return pow2rem_i8(x, d._divisor.Reinterpret<T, sbyte>(), d._promises).Reinterpret<sbyte, T>();
                    }
                    else
                    {
                        return bmrem_i8(x, *(ushort*)&d._bigM, *(sbyte*)&d._divisor, d._promises).Reinterpret<sbyte, T>();
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator % (sbyte2 x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(sbyte), 2, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            if (d.DivideByScalar<sbyte2>())
            {
                sbyte divisor = *(sbyte*)&d._divisor;

                if (d._promises.Pow2)
                {
                    if (Architecture.IsSIMDSupported)
                    {
                        return pow2rem_epi8_si8(x, divisor, d._promises);
                    }
                    else
                    {
                        return new sbyte2(pow2rem_i8(x.x, divisor, d._promises),
                                          pow2rem_i8(x.y, divisor, d._promises));
                    }
                }
                else
                {
                    ushort mul = *(ushort*)&d._bigM;

                    if (Architecture.IsSIMDSupported)
                    {
                        return bmrem_epi8_si8(x, mul, divisor, d._promises, 2);
                    }
                    else
                    {
                        return new sbyte2(bmrem_i8(x.x, mul, divisor, d._promises),
                                          bmrem_i8(x.y, mul, divisor, d._promises));
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
                        return pow2rem_epi8(x, divisor, d._promises);
                    }
                    else
                    {
                        return new sbyte2(pow2rem_i8(x.x, divisor.x, d._promises),
                                          pow2rem_i8(x.y, divisor.y, d._promises));
                    }
                }
                else
                {
                    ushort2 mul = *(ushort2*)&d._bigM;

                    if (Architecture.IsSIMDSupported)
                    {
                        return bmrem_epi8(x, mul, divisor, d._promises, 2);
                    }
                    else
                    {
                        return new sbyte2(bmrem_i8(x.x, mul.x, divisor.x, d._promises),
                                          bmrem_i8(x.y, mul.y, divisor.y, d._promises));
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 operator % (sbyte3 x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(sbyte), 3, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            if (d.DivideByScalar<sbyte3>())
            {
                sbyte divisor = *(sbyte*)&d._divisor;

                if (d._promises.Pow2)
                {
                    if (Architecture.IsSIMDSupported)
                    {
                        return pow2rem_epi8_si8(x, divisor, d._promises);
                    }
                    else
                    {
                        return new sbyte3(pow2rem_i8(x.x, divisor, d._promises),
                                          pow2rem_i8(x.y, divisor, d._promises),
                                          pow2rem_i8(x.z, divisor, d._promises));
                    }
                }
                else
                {
                    ushort mul = *(ushort*)&d._bigM;

                    if (Architecture.IsSIMDSupported)
                    {
                        return bmrem_epi8_si8(x, mul, divisor, d._promises, 3);
                    }
                    else
                    {
                        return new sbyte3(bmrem_i8(x.x, mul, divisor, d._promises),
                                          bmrem_i8(x.y, mul, divisor, d._promises),
                                          bmrem_i8(x.z, mul, divisor, d._promises));
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
                        return pow2rem_epi8(x, divisor, d._promises);
                    }
                    else
                    {
                        return new sbyte3(pow2rem_i8(x.x, divisor.x, d._promises),
                                          pow2rem_i8(x.y, divisor.y, d._promises),
                                          pow2rem_i8(x.z, divisor.z, d._promises));
                    }
                }
                else
                {
                    ushort3 mul = *(ushort3*)&d._bigM;

                    if (Architecture.IsSIMDSupported)
                    {
                        return bmrem_epi8(x, mul, divisor, d._promises, 3);
                    }
                    else
                    {
                        return new sbyte3(bmrem_i8(x.x, mul.x, divisor.x, d._promises),
                                          bmrem_i8(x.y, mul.y, divisor.y, d._promises),
                                          bmrem_i8(x.z, mul.z, divisor.z, d._promises));
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 operator % (sbyte4 x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(sbyte), 4, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            if (d.DivideByScalar<sbyte4>())
            {
                sbyte divisor = *(sbyte*)&d._divisor;

                if (d._promises.Pow2)
                {
                    if (Architecture.IsSIMDSupported)
                    {
                        return pow2rem_epi8_si8(x, divisor, d._promises);
                    }
                    else
                    {
                        return new sbyte4(pow2rem_i8(x.x, divisor, d._promises),
                                          pow2rem_i8(x.y, divisor, d._promises),
                                          pow2rem_i8(x.z, divisor, d._promises),
                                          pow2rem_i8(x.w, divisor, d._promises));
                    }
                }
                else
                {
                    ushort mul = *(ushort*)&d._bigM;

                    if (Architecture.IsSIMDSupported)
                    {
                        return bmrem_epi8_si8(x, mul, divisor, d._promises, 4);
                    }
                    else
                    {
                        return new sbyte4(bmrem_i8(x.x, mul, divisor, d._promises),
                                          bmrem_i8(x.y, mul, divisor, d._promises),
                                          bmrem_i8(x.z, mul, divisor, d._promises),
                                          bmrem_i8(x.w, mul, divisor, d._promises));
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
                        return pow2rem_epi8(x, divisor, d._promises);
                    }
                    else
                    {
                        return new sbyte4(pow2rem_i8(x.x, divisor.x, d._promises),
                                          pow2rem_i8(x.y, divisor.y, d._promises),
                                          pow2rem_i8(x.z, divisor.z, d._promises),
                                          pow2rem_i8(x.w, divisor.w, d._promises));
                    }
                }
                else
                {
                    ushort4 mul = *(ushort4*)&d._bigM;

                    if (Architecture.IsSIMDSupported)
                    {
                        return bmrem_epi8(x, mul, divisor, d._promises, 4);
                    }
                    else
                    {
                        return new sbyte4(bmrem_i8(x.x, mul.x, divisor.x, d._promises),
                                          bmrem_i8(x.y, mul.y, divisor.y, d._promises),
                                          bmrem_i8(x.z, mul.z, divisor.z, d._promises),
                                          bmrem_i8(x.w, mul.w, divisor.w, d._promises));
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 operator % (sbyte8 x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(sbyte), 8, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            if (d.DivideByScalar<sbyte8>())
            {
                sbyte divisor = *(sbyte*)&d._divisor;

                if (d._promises.Pow2)
                {
                    if (Architecture.IsSIMDSupported)
                    {
                        return pow2rem_epi8_si8(x, divisor, d._promises);
                    }
                    else
                    {
                        return new sbyte8(pow2rem_i8(x.x0, divisor, d._promises),
                                          pow2rem_i8(x.x1, divisor, d._promises),
                                          pow2rem_i8(x.x2, divisor, d._promises),
                                          pow2rem_i8(x.x3, divisor, d._promises),
                                          pow2rem_i8(x.x4, divisor, d._promises),
                                          pow2rem_i8(x.x5, divisor, d._promises),
                                          pow2rem_i8(x.x6, divisor, d._promises),
                                          pow2rem_i8(x.x7, divisor, d._promises));
                    }
                }
                else
                {
                    ushort mul = *(ushort*)&d._bigM;

                    if (Architecture.IsSIMDSupported)
                    {
                        return bmrem_epi8_si8(x, mul, divisor, d._promises, 8);
                    }
                    else
                    {
                        return new sbyte8(bmrem_i8(x.x0, mul, divisor, d._promises),
                                          bmrem_i8(x.x1, mul, divisor, d._promises),
                                          bmrem_i8(x.x2, mul, divisor, d._promises),
                                          bmrem_i8(x.x3, mul, divisor, d._promises),
                                          bmrem_i8(x.x4, mul, divisor, d._promises),
                                          bmrem_i8(x.x5, mul, divisor, d._promises),
                                          bmrem_i8(x.x6, mul, divisor, d._promises),
                                          bmrem_i8(x.x7, mul, divisor, d._promises));
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
                        return pow2rem_epi8(x, divisor, d._promises);
                    }
                    else
                    {
                        return new sbyte8(pow2rem_i8(x.x0, divisor.x0, d._promises),
                                          pow2rem_i8(x.x1, divisor.x1, d._promises),
                                          pow2rem_i8(x.x2, divisor.x2, d._promises),
                                          pow2rem_i8(x.x3, divisor.x3, d._promises),
                                          pow2rem_i8(x.x4, divisor.x4, d._promises),
                                          pow2rem_i8(x.x5, divisor.x5, d._promises),
                                          pow2rem_i8(x.x6, divisor.x6, d._promises),
                                          pow2rem_i8(x.x7, divisor.x7, d._promises));
                    }
                }
                else
                {
                    ushort8 mul = *(ushort8*)&d._bigM;

                    if (Architecture.IsSIMDSupported)
                    {
                        return bmrem_epi8(x, mul, divisor, d._promises, 8);
                    }
                    else
                    {
                        return new sbyte8(bmrem_i8(x.x0, mul.x0, divisor.x0, d._promises),
                                          bmrem_i8(x.x1, mul.x1, divisor.x1, d._promises),
                                          bmrem_i8(x.x2, mul.x2, divisor.x2, d._promises),
                                          bmrem_i8(x.x3, mul.x3, divisor.x3, d._promises),
                                          bmrem_i8(x.x4, mul.x4, divisor.x4, d._promises),
                                          bmrem_i8(x.x5, mul.x5, divisor.x5, d._promises),
                                          bmrem_i8(x.x6, mul.x6, divisor.x6, d._promises),
                                          bmrem_i8(x.x7, mul.x7, divisor.x7, d._promises));
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 operator % (sbyte16 x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(sbyte), 16, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            if (d.DivideByScalar<sbyte16>())
            {
                sbyte divisor = *(sbyte*)&d._divisor;

                if (d._promises.Pow2)
                {
                    if (Architecture.IsSIMDSupported)
                    {
                        return pow2rem_epi8_si8(x, divisor, d._promises);
                    }
                    else
                    {
                        return new sbyte16(pow2rem_i8(x.x0,  divisor, d._promises),
                                           pow2rem_i8(x.x1,  divisor, d._promises),
                                           pow2rem_i8(x.x2,  divisor, d._promises),
                                           pow2rem_i8(x.x3,  divisor, d._promises),
                                           pow2rem_i8(x.x4,  divisor, d._promises),
                                           pow2rem_i8(x.x5,  divisor, d._promises),
                                           pow2rem_i8(x.x6,  divisor, d._promises),
                                           pow2rem_i8(x.x7,  divisor, d._promises),
                                           pow2rem_i8(x.x8,  divisor, d._promises),
                                           pow2rem_i8(x.x9,  divisor, d._promises),
                                           pow2rem_i8(x.x10, divisor, d._promises),
                                           pow2rem_i8(x.x11, divisor, d._promises),
                                           pow2rem_i8(x.x12, divisor, d._promises),
                                           pow2rem_i8(x.x13, divisor, d._promises),
                                           pow2rem_i8(x.x14, divisor, d._promises),
                                           pow2rem_i8(x.x15, divisor, d._promises));
                    }
                }
                else
                {
                    ushort mul = *(ushort*)&d._bigM;

                    if (Architecture.IsSIMDSupported)
                    {
                        return bmrem_epi8_si8(x, mul, divisor, d._promises);
                    }
                    else
                    {
                        return new sbyte16(bmrem_i8(x.x0,  mul, divisor, d._promises),
                                           bmrem_i8(x.x1,  mul, divisor, d._promises),
                                           bmrem_i8(x.x2,  mul, divisor, d._promises),
                                           bmrem_i8(x.x3,  mul, divisor, d._promises),
                                           bmrem_i8(x.x4,  mul, divisor, d._promises),
                                           bmrem_i8(x.x5,  mul, divisor, d._promises),
                                           bmrem_i8(x.x6,  mul, divisor, d._promises),
                                           bmrem_i8(x.x7,  mul, divisor, d._promises),
                                           bmrem_i8(x.x8,  mul, divisor, d._promises),
                                           bmrem_i8(x.x9,  mul, divisor, d._promises),
                                           bmrem_i8(x.x10, mul, divisor, d._promises),
                                           bmrem_i8(x.x11, mul, divisor, d._promises),
                                           bmrem_i8(x.x12, mul, divisor, d._promises),
                                           bmrem_i8(x.x13, mul, divisor, d._promises),
                                           bmrem_i8(x.x14, mul, divisor, d._promises),
                                           bmrem_i8(x.x15, mul, divisor, d._promises));
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
                        return pow2rem_epi8(x, divisor, d._promises);
                    }
                    else
                    {
                        return new sbyte16(pow2rem_i8(x.x0,  divisor.x0,  d._promises),
                                           pow2rem_i8(x.x1,  divisor.x1,  d._promises),
                                           pow2rem_i8(x.x2,  divisor.x2,  d._promises),
                                           pow2rem_i8(x.x3,  divisor.x3,  d._promises),
                                           pow2rem_i8(x.x4,  divisor.x4,  d._promises),
                                           pow2rem_i8(x.x5,  divisor.x5,  d._promises),
                                           pow2rem_i8(x.x6,  divisor.x6,  d._promises),
                                           pow2rem_i8(x.x7,  divisor.x7,  d._promises),
                                           pow2rem_i8(x.x8,  divisor.x8,  d._promises),
                                           pow2rem_i8(x.x9,  divisor.x9,  d._promises),
                                           pow2rem_i8(x.x10, divisor.x10, d._promises),
                                           pow2rem_i8(x.x11, divisor.x11, d._promises),
                                           pow2rem_i8(x.x12, divisor.x12, d._promises),
                                           pow2rem_i8(x.x13, divisor.x13, d._promises),
                                           pow2rem_i8(x.x14, divisor.x14, d._promises),
                                           pow2rem_i8(x.x15, divisor.x15, d._promises));
                    }
                }
                else
                {
                    ushort16 mul = *(ushort16*)&d._bigM;

                    if (Architecture.IsSIMDSupported)
                    {
                        return bmrem_epi8(x, mul.v8_0, mul.v8_8, divisor, d._promises);
                    }
                    else
                    {
                        return new sbyte16(bmrem_i8(x.x0,  mul.v8_0.x0, divisor.x0,  d._promises),
                                           bmrem_i8(x.x1,  mul.v8_0.x1, divisor.x1,  d._promises),
                                           bmrem_i8(x.x2,  mul.v8_0.x2, divisor.x2,  d._promises),
                                           bmrem_i8(x.x3,  mul.v8_0.x3, divisor.x3,  d._promises),
                                           bmrem_i8(x.x4,  mul.v8_0.x4, divisor.x4,  d._promises),
                                           bmrem_i8(x.x5,  mul.v8_0.x5, divisor.x5,  d._promises),
                                           bmrem_i8(x.x6,  mul.v8_0.x6, divisor.x6,  d._promises),
                                           bmrem_i8(x.x7,  mul.v8_0.x7, divisor.x7,  d._promises),
                                           bmrem_i8(x.x8,  mul.v8_8.x0, divisor.x8,  d._promises),
                                           bmrem_i8(x.x9,  mul.v8_8.x1, divisor.x9,  d._promises),
                                           bmrem_i8(x.x10, mul.v8_8.x2, divisor.x10, d._promises),
                                           bmrem_i8(x.x11, mul.v8_8.x3, divisor.x11, d._promises),
                                           bmrem_i8(x.x12, mul.v8_8.x4, divisor.x12, d._promises),
                                           bmrem_i8(x.x13, mul.v8_8.x5, divisor.x13, d._promises),
                                           bmrem_i8(x.x14, mul.v8_8.x6, divisor.x14, d._promises),
                                           bmrem_i8(x.x15, mul.v8_8.x7, divisor.x15, d._promises));
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 operator % (sbyte32 x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(sbyte), 32, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            if (d.DivideByScalar<sbyte32>())
            {
                sbyte divisor = *(sbyte*)&d._divisor;

                if (d._promises.Pow2)
                {
                    if (Avx2.IsAvx2Supported)
                    {
                        return mm256_pow2rem_epi8_si8(x, divisor, d._promises);
                    }
                    else if (Architecture.IsSIMDSupported)
                    {
                        return new sbyte32(pow2rem_epi8_si8(x.v16_0,  divisor, d._promises),
                                           pow2rem_epi8_si8(x.v16_16, divisor, d._promises));
                    }
                    else
                    {
                        return new sbyte32(pow2rem_i8(x.x0,  divisor, d._promises),
                                           pow2rem_i8(x.x1,  divisor, d._promises),
                                           pow2rem_i8(x.x2,  divisor, d._promises),
                                           pow2rem_i8(x.x3,  divisor, d._promises),
                                           pow2rem_i8(x.x4,  divisor, d._promises),
                                           pow2rem_i8(x.x5,  divisor, d._promises),
                                           pow2rem_i8(x.x6,  divisor, d._promises),
                                           pow2rem_i8(x.x7,  divisor, d._promises),
                                           pow2rem_i8(x.x8,  divisor, d._promises),
                                           pow2rem_i8(x.x9,  divisor, d._promises),
                                           pow2rem_i8(x.x10, divisor, d._promises),
                                           pow2rem_i8(x.x11, divisor, d._promises),
                                           pow2rem_i8(x.x12, divisor, d._promises),
                                           pow2rem_i8(x.x13, divisor, d._promises),
                                           pow2rem_i8(x.x14, divisor, d._promises),
                                           pow2rem_i8(x.x15, divisor, d._promises),
                                           pow2rem_i8(x.x16, divisor, d._promises),
                                           pow2rem_i8(x.x17, divisor, d._promises),
                                           pow2rem_i8(x.x18, divisor, d._promises),
                                           pow2rem_i8(x.x19, divisor, d._promises),
                                           pow2rem_i8(x.x20, divisor, d._promises),
                                           pow2rem_i8(x.x21, divisor, d._promises),
                                           pow2rem_i8(x.x22, divisor, d._promises),
                                           pow2rem_i8(x.x23, divisor, d._promises),
                                           pow2rem_i8(x.x24, divisor, d._promises),
                                           pow2rem_i8(x.x25, divisor, d._promises),
                                           pow2rem_i8(x.x26, divisor, d._promises),
                                           pow2rem_i8(x.x27, divisor, d._promises),
                                           pow2rem_i8(x.x28, divisor, d._promises),
                                           pow2rem_i8(x.x29, divisor, d._promises),
                                           pow2rem_i8(x.x30, divisor, d._promises),
                                           pow2rem_i8(x.x31, divisor, d._promises));
                    }
                }
                else
                {
                    ushort mul = *(ushort*)&d._bigM;

                    if (Avx2.IsAvx2Supported)
                    {
                        return mm256_bmrem_epi8_si8(x, mul, divisor, d._promises);
                    }
                    else if (Architecture.IsSIMDSupported)
                    {
                        return new sbyte32(bmrem_epi8_si8(x.v16_0,  mul, divisor, d._promises),
                                           bmrem_epi8_si8(x.v16_16, mul, divisor, d._promises));
                    }
                    else
                    {
                        return new sbyte32(bmrem_i8(x.x0,  mul, divisor, d._promises),
                                           bmrem_i8(x.x1,  mul, divisor, d._promises),
                                           bmrem_i8(x.x2,  mul, divisor, d._promises),
                                           bmrem_i8(x.x3,  mul, divisor, d._promises),
                                           bmrem_i8(x.x4,  mul, divisor, d._promises),
                                           bmrem_i8(x.x5,  mul, divisor, d._promises),
                                           bmrem_i8(x.x6,  mul, divisor, d._promises),
                                           bmrem_i8(x.x7,  mul, divisor, d._promises),
                                           bmrem_i8(x.x8,  mul, divisor, d._promises),
                                           bmrem_i8(x.x9,  mul, divisor, d._promises),
                                           bmrem_i8(x.x10, mul, divisor, d._promises),
                                           bmrem_i8(x.x11, mul, divisor, d._promises),
                                           bmrem_i8(x.x12, mul, divisor, d._promises),
                                           bmrem_i8(x.x13, mul, divisor, d._promises),
                                           bmrem_i8(x.x14, mul, divisor, d._promises),
                                           bmrem_i8(x.x15, mul, divisor, d._promises),
                                           bmrem_i8(x.x16, mul, divisor, d._promises),
                                           bmrem_i8(x.x17, mul, divisor, d._promises),
                                           bmrem_i8(x.x18, mul, divisor, d._promises),
                                           bmrem_i8(x.x19, mul, divisor, d._promises),
                                           bmrem_i8(x.x20, mul, divisor, d._promises),
                                           bmrem_i8(x.x21, mul, divisor, d._promises),
                                           bmrem_i8(x.x22, mul, divisor, d._promises),
                                           bmrem_i8(x.x23, mul, divisor, d._promises),
                                           bmrem_i8(x.x24, mul, divisor, d._promises),
                                           bmrem_i8(x.x25, mul, divisor, d._promises),
                                           bmrem_i8(x.x26, mul, divisor, d._promises),
                                           bmrem_i8(x.x27, mul, divisor, d._promises),
                                           bmrem_i8(x.x28, mul, divisor, d._promises),
                                           bmrem_i8(x.x29, mul, divisor, d._promises),
                                           bmrem_i8(x.x30, mul, divisor, d._promises),
                                           bmrem_i8(x.x31, mul, divisor, d._promises));
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
                        return mm256_pow2rem_epi8(x, divisor, d._promises);
                    }
                    else if (Architecture.IsSIMDSupported)
                    {
                        return new sbyte32(pow2rem_epi8(x.v16_0,  divisor.v16_0,  d._promises),
                                           pow2rem_epi8(x.v16_16, divisor.v16_16, d._promises));
                    }
                    else
                    {
                        return new sbyte32(pow2rem_i8(x.x0,  divisor.x0,  d._promises),
                                           pow2rem_i8(x.x1,  divisor.x1,  d._promises),
                                           pow2rem_i8(x.x2,  divisor.x2,  d._promises),
                                           pow2rem_i8(x.x3,  divisor.x3,  d._promises),
                                           pow2rem_i8(x.x4,  divisor.x4,  d._promises),
                                           pow2rem_i8(x.x5,  divisor.x5,  d._promises),
                                           pow2rem_i8(x.x6,  divisor.x6,  d._promises),
                                           pow2rem_i8(x.x7,  divisor.x7,  d._promises),
                                           pow2rem_i8(x.x8,  divisor.x8,  d._promises),
                                           pow2rem_i8(x.x9,  divisor.x9,  d._promises),
                                           pow2rem_i8(x.x10, divisor.x10, d._promises),
                                           pow2rem_i8(x.x11, divisor.x11, d._promises),
                                           pow2rem_i8(x.x12, divisor.x12, d._promises),
                                           pow2rem_i8(x.x13, divisor.x13, d._promises),
                                           pow2rem_i8(x.x14, divisor.x14, d._promises),
                                           pow2rem_i8(x.x15, divisor.x15, d._promises),
                                           pow2rem_i8(x.x16, divisor.x16, d._promises),
                                           pow2rem_i8(x.x17, divisor.x17, d._promises),
                                           pow2rem_i8(x.x18, divisor.x18, d._promises),
                                           pow2rem_i8(x.x19, divisor.x19, d._promises),
                                           pow2rem_i8(x.x20, divisor.x20, d._promises),
                                           pow2rem_i8(x.x21, divisor.x21, d._promises),
                                           pow2rem_i8(x.x22, divisor.x22, d._promises),
                                           pow2rem_i8(x.x23, divisor.x23, d._promises),
                                           pow2rem_i8(x.x24, divisor.x24, d._promises),
                                           pow2rem_i8(x.x25, divisor.x25, d._promises),
                                           pow2rem_i8(x.x26, divisor.x26, d._promises),
                                           pow2rem_i8(x.x27, divisor.x27, d._promises),
                                           pow2rem_i8(x.x28, divisor.x28, d._promises),
                                           pow2rem_i8(x.x29, divisor.x29, d._promises),
                                           pow2rem_i8(x.x30, divisor.x30, d._promises),
                                           pow2rem_i8(x.x31, divisor.x31, d._promises));
                    }
                }
                else
                {
                    ushort16 mulLo = *(ushort16*)&d._bigM._mulLo;
                    ushort16 mulHi = *(ushort16*)&d._bigM._mulHi;

                    if (Avx2.IsAvx2Supported)
                    {
                        return mm256_bmrem_epi8(x, mulLo, mulHi, divisor, d._promises);
                    }
                    else if (Architecture.IsSIMDSupported)
                    {
                        return new sbyte32(bmrem_epi8(x.v16_0,  mulLo.v8_0, mulLo.v8_8, divisor.v16_0,  d._promises),
                                           bmrem_epi8(x.v16_16, mulHi.v8_0, mulHi.v8_8, divisor.v16_16, d._promises));
                    }
                    else
                    {
                        return new sbyte32(bmrem_i8(x.x0,  mulLo.x0,  divisor.x0,  d._promises),
                                           bmrem_i8(x.x1,  mulLo.x1,  divisor.x1,  d._promises),
                                           bmrem_i8(x.x2,  mulLo.x2,  divisor.x2,  d._promises),
                                           bmrem_i8(x.x3,  mulLo.x3,  divisor.x3,  d._promises),
                                           bmrem_i8(x.x4,  mulLo.x4,  divisor.x4,  d._promises),
                                           bmrem_i8(x.x5,  mulLo.x5,  divisor.x5,  d._promises),
                                           bmrem_i8(x.x6,  mulLo.x6,  divisor.x6,  d._promises),
                                           bmrem_i8(x.x7,  mulLo.x7,  divisor.x7,  d._promises),
                                           bmrem_i8(x.x8,  mulLo.x8,  divisor.x8,  d._promises),
                                           bmrem_i8(x.x9,  mulLo.x9,  divisor.x9,  d._promises),
                                           bmrem_i8(x.x10, mulLo.x10, divisor.x10, d._promises),
                                           bmrem_i8(x.x11, mulLo.x11, divisor.x11, d._promises),
                                           bmrem_i8(x.x12, mulLo.x12, divisor.x12, d._promises),
                                           bmrem_i8(x.x13, mulLo.x13, divisor.x13, d._promises),
                                           bmrem_i8(x.x14, mulLo.x14, divisor.x14, d._promises),
                                           bmrem_i8(x.x15, mulLo.x15, divisor.x15, d._promises),
                                           bmrem_i8(x.x16, mulHi.x0,  divisor.x16, d._promises),
                                           bmrem_i8(x.x17, mulHi.x1,  divisor.x17, d._promises),
                                           bmrem_i8(x.x18, mulHi.x2,  divisor.x18, d._promises),
                                           bmrem_i8(x.x19, mulHi.x3,  divisor.x19, d._promises),
                                           bmrem_i8(x.x20, mulHi.x4,  divisor.x20, d._promises),
                                           bmrem_i8(x.x21, mulHi.x5,  divisor.x21, d._promises),
                                           bmrem_i8(x.x22, mulHi.x6,  divisor.x22, d._promises),
                                           bmrem_i8(x.x23, mulHi.x7,  divisor.x23, d._promises),
                                           bmrem_i8(x.x24, mulHi.x8,  divisor.x24, d._promises),
                                           bmrem_i8(x.x25, mulHi.x9,  divisor.x25, d._promises),
                                           bmrem_i8(x.x26, mulHi.x10, divisor.x26, d._promises),
                                           bmrem_i8(x.x27, mulHi.x11, divisor.x27, d._promises),
                                           bmrem_i8(x.x28, mulHi.x12, divisor.x28, d._promises),
                                           bmrem_i8(x.x29, mulHi.x13, divisor.x29, d._promises),
                                           bmrem_i8(x.x30, mulHi.x14, divisor.x30, d._promises),
                                           bmrem_i8(x.x31, mulHi.x15, divisor.x31, d._promises));
                    }
                }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T operator % (short x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(short), 1, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            switch (sizeof(T))
            {
                case 16 * sizeof(short): return ((short16)x % d).Reinterpret<short16, T>();
                case  8 * sizeof(short): return ((short8) x % d).Reinterpret<short8,  T>();
                case  4 * sizeof(short): return ((short4) x % d).Reinterpret<short4,  T>();
                case  3 * sizeof(short): return ((short3) x % d).Reinterpret<short3,  T>();
                case  2 * sizeof(short): return ((short2) x % d).Reinterpret<short2,  T>();
                default:
                {
                    if (d._promises.Pow2)
                    {
                        return pow2rem_i16(x, d._divisor.Reinterpret<T, short>(), d._promises).Reinterpret<short, T>();
                    }
                    else
                    {
                        return bmrem_i16(x, *(uint*)&d._bigM, *(short*)&d._divisor, d._promises).Reinterpret<short, T>();
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator % (short2 x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(short), 2, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            if (d.DivideByScalar<short2>())
            {
                short divisor = *(short*)&d._divisor;

                if (d._promises.Pow2)
                {
                    if (Architecture.IsSIMDSupported)
                    {
                        return pow2rem_epi16_si16(x, divisor, d._promises);
                    }
                    else
                    {
                        return new short2(pow2rem_i16(x.x, divisor, d._promises),
                                          pow2rem_i16(x.y, divisor, d._promises));
                    }
                }
                else
                {
                    uint mul = *(uint*)&d._bigM;

                    if (Architecture.IsSIMDSupported)
                    {
                        return bmrem_epi16_si16(x, mul, divisor, d._promises, 2);
                    }
                    else
                    {
                        return new short2(bmrem_i16(x.x, mul, divisor, d._promises),
                                          bmrem_i16(x.y, mul, divisor, d._promises));
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
                        return pow2rem_epi16(x, divisor, d._promises);
                    }
                    else
                    {
                        return new short2(pow2rem_i16(x.x, divisor.x, d._promises),
                                          pow2rem_i16(x.y, divisor.y, d._promises));
                    }
                }
                else
                {
                    uint2 mul = *(uint2*)&d._bigM;

                    if (Architecture.IsSIMDSupported)
                    {
                        return bmrem_epi16(x, RegisterConversion.ToV128(mul), divisor, d._promises, 2);
                    }
                    else
                    {
                        return new short2(bmrem_i16(x.x, mul.x, divisor.x, d._promises),
                                          bmrem_i16(x.y, mul.y, divisor.y, d._promises));
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator % (short3 x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(short), 3, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            if (d.DivideByScalar<short3>())
            {
                short divisor = *(short*)&d._divisor;

                if (d._promises.Pow2)
                {
                    if (Architecture.IsSIMDSupported)
                    {
                        return pow2rem_epi16_si16(x, divisor, d._promises);
                    }
                    else
                    {
                        return new short3(pow2rem_i16(x.x, divisor, d._promises),
                                          pow2rem_i16(x.y, divisor, d._promises),
                                          pow2rem_i16(x.z, divisor, d._promises));
                    }
                }
                else
                {
                    uint mul = *(uint*)&d._bigM;

                    if (Architecture.IsSIMDSupported)
                    {
                        return bmrem_epi16_si16(x, mul, divisor, d._promises, 3);
                    }
                    else
                    {
                        return new short3(bmrem_i16(x.x, mul, divisor, d._promises),
                                          bmrem_i16(x.y, mul, divisor, d._promises),
                                          bmrem_i16(x.z, mul, divisor, d._promises));
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
                        return pow2rem_epi16(x, divisor, d._promises);
                    }
                    else
                    {
                        return new short3(pow2rem_i16(x.x, divisor.x, d._promises),
                                          pow2rem_i16(x.y, divisor.y, d._promises),
                                          pow2rem_i16(x.z, divisor.z, d._promises));
                    }
                }
                else
                {
                    uint3 mul = *(uint3*)&d._bigM;

                    if (Architecture.IsSIMDSupported)
                    {
                        return bmrem_epi16(x, RegisterConversion.ToV128(mul), divisor, d._promises, 3);
                    }
                    else
                    {
                        return new short3(bmrem_i16(x.x, mul.x, divisor.x, d._promises),
                                          bmrem_i16(x.y, mul.y, divisor.y, d._promises),
                                          bmrem_i16(x.z, mul.z, divisor.z, d._promises));
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 operator % (short4 x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(short), 4, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            if (d.DivideByScalar<short4>())
            {
                short divisor = *(short*)&d._divisor;

                if (d._promises.Pow2)
                {
                    if (Architecture.IsSIMDSupported)
                    {
                        return pow2rem_epi16_si16(x, divisor, d._promises);
                    }
                    else
                    {
                        return new short4(pow2rem_i16(x.x, divisor, d._promises),
                                          pow2rem_i16(x.y, divisor, d._promises),
                                          pow2rem_i16(x.z, divisor, d._promises),
                                          pow2rem_i16(x.w, divisor, d._promises));
                    }
                }
                else
                {
                    uint mul = *(uint*)&d._bigM;

                    if (Architecture.IsSIMDSupported)
                    {
                        return bmrem_epi16_si16(x, mul, divisor, d._promises, 4);
                    }
                    else
                    {
                        return new short4(bmrem_i16(x.x, mul, divisor, d._promises),
                                          bmrem_i16(x.y, mul, divisor, d._promises),
                                          bmrem_i16(x.z, mul, divisor, d._promises),
                                          bmrem_i16(x.w, mul, divisor, d._promises));
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
                        return pow2rem_epi16(x, divisor, d._promises);
                    }
                    else
                    {
                        return new short4(pow2rem_i16(x.x, divisor.x, d._promises),
                                          pow2rem_i16(x.y, divisor.y, d._promises),
                                          pow2rem_i16(x.z, divisor.z, d._promises),
                                          pow2rem_i16(x.w, divisor.w, d._promises));
                    }
                }
                else
                {
                    uint4 mul = *(uint4*)&d._bigM;

                    if (Architecture.IsSIMDSupported)
                    {
                        return bmrem_epi16(x, RegisterConversion.ToV128(mul), divisor, d._promises, 4);
                    }
                    else
                    {
                        return new short4(bmrem_i16(x.x, mul.x, divisor.x, d._promises),
                                          bmrem_i16(x.y, mul.y, divisor.y, d._promises),
                                          bmrem_i16(x.z, mul.z, divisor.z, d._promises),
                                          bmrem_i16(x.w, mul.w, divisor.w, d._promises));
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator % (short8 x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(short), 8, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            if (d.DivideByScalar<short8>())
            {
                short divisor = *(short*)&d._divisor;

                if (d._promises.Pow2)
                {
                    if (Architecture.IsSIMDSupported)
                    {
                        return pow2rem_epi16_si16(x, divisor, d._promises);
                    }
                    else
                    {
                        return new short8(pow2rem_i16(x.x0, divisor, d._promises),
                                          pow2rem_i16(x.x1, divisor, d._promises),
                                          pow2rem_i16(x.x2, divisor, d._promises),
                                          pow2rem_i16(x.x3, divisor, d._promises),
                                          pow2rem_i16(x.x4, divisor, d._promises),
                                          pow2rem_i16(x.x5, divisor, d._promises),
                                          pow2rem_i16(x.x6, divisor, d._promises),
                                          pow2rem_i16(x.x7, divisor, d._promises));
                    }
                }
                else
                {
                    uint mul = *(uint*)&d._bigM;

                    if (Architecture.IsSIMDSupported)
                    {
                        return bmrem_epi16_si16(x, mul, divisor, d._promises);
                    }
                    else
                    {
                        return new short8(bmrem_i16(x.x0, mul, divisor, d._promises),
                                          bmrem_i16(x.x1, mul, divisor, d._promises),
                                          bmrem_i16(x.x2, mul, divisor, d._promises),
                                          bmrem_i16(x.x3, mul, divisor, d._promises),
                                          bmrem_i16(x.x4, mul, divisor, d._promises),
                                          bmrem_i16(x.x5, mul, divisor, d._promises),
                                          bmrem_i16(x.x6, mul, divisor, d._promises),
                                          bmrem_i16(x.x7, mul, divisor, d._promises));
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
                        return pow2rem_epi16(x, divisor, d._promises);
                    }
                    else
                    {
                        return new short8(pow2rem_i16(x.x0, divisor.x0, d._promises),
                                          pow2rem_i16(x.x1, divisor.x1, d._promises),
                                          pow2rem_i16(x.x2, divisor.x2, d._promises),
                                          pow2rem_i16(x.x3, divisor.x3, d._promises),
                                          pow2rem_i16(x.x4, divisor.x4, d._promises),
                                          pow2rem_i16(x.x5, divisor.x5, d._promises),
                                          pow2rem_i16(x.x6, divisor.x6, d._promises),
                                          pow2rem_i16(x.x7, divisor.x7, d._promises));
                    }
                }
                else
                {
                    uint8 mul = *(uint8*)&d._bigM;

                    if (Architecture.IsSIMDSupported)
                    {
                        return bmrem_epi16(x, RegisterConversion.ToV128(mul.v4_0), RegisterConversion.ToV128(mul.v4_4), divisor, d._promises);
                    }
                    else
                    {
                        return new short8(bmrem_i16(x.x0, mul.v4_0.x, divisor.x0, d._promises),
                                          bmrem_i16(x.x1, mul.v4_0.y, divisor.x1, d._promises),
                                          bmrem_i16(x.x2, mul.v4_0.z, divisor.x2, d._promises),
                                          bmrem_i16(x.x3, mul.v4_0.w, divisor.x3, d._promises),
                                          bmrem_i16(x.x4, mul.v4_4.x, divisor.x4, d._promises),
                                          bmrem_i16(x.x5, mul.v4_4.y, divisor.x5, d._promises),
                                          bmrem_i16(x.x6, mul.v4_4.z, divisor.x6, d._promises),
                                          bmrem_i16(x.x7, mul.v4_4.w, divisor.x7, d._promises));
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 operator % (short16 x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(short), 16, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            if (d.DivideByScalar<short16>())
            {
                short divisor = *(short*)&d._divisor;

                if (d._promises.Pow2)
                {
                    if (Avx2.IsAvx2Supported)
                    {
                        return mm256_pow2rem_epi16_si16(x, divisor, d._promises);
                    }
                    else if (Architecture.IsSIMDSupported)
                    {
                        return new short16(pow2rem_epi16_si16(x.v8_0, divisor, d._promises),
                                           pow2rem_epi16_si16(x.v8_8, divisor, d._promises));
                    }
                    else
                    {
                        return new short16(pow2rem_i16(x.x0,  divisor, d._promises),
                                           pow2rem_i16(x.x1,  divisor, d._promises),
                                           pow2rem_i16(x.x2,  divisor, d._promises),
                                           pow2rem_i16(x.x3,  divisor, d._promises),
                                           pow2rem_i16(x.x4,  divisor, d._promises),
                                           pow2rem_i16(x.x5,  divisor, d._promises),
                                           pow2rem_i16(x.x6,  divisor, d._promises),
                                           pow2rem_i16(x.x7,  divisor, d._promises),
                                           pow2rem_i16(x.x8,  divisor, d._promises),
                                           pow2rem_i16(x.x9,  divisor, d._promises),
                                           pow2rem_i16(x.x10, divisor, d._promises),
                                           pow2rem_i16(x.x11, divisor, d._promises),
                                           pow2rem_i16(x.x12, divisor, d._promises),
                                           pow2rem_i16(x.x13, divisor, d._promises),
                                           pow2rem_i16(x.x14, divisor, d._promises),
                                           pow2rem_i16(x.x15, divisor, d._promises));
                    }
                }
                else
                {
                    uint mul = *(uint*)&d._bigM;

                    if (Avx2.IsAvx2Supported)
                    {
                        return mm256_bmrem_epi16_si16(x, mul, divisor, d._promises);
                    }
                    else if (Architecture.IsSIMDSupported)
                    {
                        return new short16(bmrem_epi16_si16(x.v8_0, mul, divisor, d._promises),
                                           bmrem_epi16_si16(x.v8_8, mul, divisor, d._promises));
                    }
                    else
                    {
                        return new short16(bmrem_i16(x.x0,  mul, divisor, d._promises),
                                           bmrem_i16(x.x1,  mul, divisor, d._promises),
                                           bmrem_i16(x.x2,  mul, divisor, d._promises),
                                           bmrem_i16(x.x3,  mul, divisor, d._promises),
                                           bmrem_i16(x.x4,  mul, divisor, d._promises),
                                           bmrem_i16(x.x5,  mul, divisor, d._promises),
                                           bmrem_i16(x.x6,  mul, divisor, d._promises),
                                           bmrem_i16(x.x7,  mul, divisor, d._promises),
                                           bmrem_i16(x.x8,  mul, divisor, d._promises),
                                           bmrem_i16(x.x9,  mul, divisor, d._promises),
                                           bmrem_i16(x.x10, mul, divisor, d._promises),
                                           bmrem_i16(x.x11, mul, divisor, d._promises),
                                           bmrem_i16(x.x12, mul, divisor, d._promises),
                                           bmrem_i16(x.x13, mul, divisor, d._promises),
                                           bmrem_i16(x.x14, mul, divisor, d._promises),
                                           bmrem_i16(x.x15, mul, divisor, d._promises));
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
                        return mm256_pow2rem_epi16(x, divisor, d._promises);
                    }
                    else if (Architecture.IsSIMDSupported)
                    {
                        return new short16(pow2rem_epi16(x.v8_0, divisor.v8_0, d._promises),
                                           pow2rem_epi16(x.v8_8, divisor.v8_8, d._promises));
                    }
                    else
                    {
                        return new short16(pow2rem_i16(x.x0,  divisor.x0,  d._promises),
                                           pow2rem_i16(x.x1,  divisor.x1,  d._promises),
                                           pow2rem_i16(x.x2,  divisor.x2,  d._promises),
                                           pow2rem_i16(x.x3,  divisor.x3,  d._promises),
                                           pow2rem_i16(x.x4,  divisor.x4,  d._promises),
                                           pow2rem_i16(x.x5,  divisor.x5,  d._promises),
                                           pow2rem_i16(x.x6,  divisor.x6,  d._promises),
                                           pow2rem_i16(x.x7,  divisor.x7,  d._promises),
                                           pow2rem_i16(x.x8,  divisor.x8,  d._promises),
                                           pow2rem_i16(x.x9,  divisor.x9,  d._promises),
                                           pow2rem_i16(x.x10, divisor.x10, d._promises),
                                           pow2rem_i16(x.x11, divisor.x11, d._promises),
                                           pow2rem_i16(x.x12, divisor.x12, d._promises),
                                           pow2rem_i16(x.x13, divisor.x13, d._promises),
                                           pow2rem_i16(x.x14, divisor.x14, d._promises),
                                           pow2rem_i16(x.x15, divisor.x15, d._promises));
                    }
                }
                else
                {
                    uint8 mulLo = *(uint8*)&d._bigM._mulLo;
                    uint8 mulHi = *(uint8*)&d._bigM._mulHi;

                    if (Avx2.IsAvx2Supported)
                    {
                        return mm256_bmrem_epi16(x, mulLo, mulHi, divisor, d._promises);
                    }
                    else if (Architecture.IsSIMDSupported)
                    {
                        return new short16(bmrem_epi16(x.v8_0, RegisterConversion.ToV128(mulLo.v4_0), RegisterConversion.ToV128(mulLo.v4_4), divisor.v8_0, d._promises),
                                           bmrem_epi16(x.v8_8, RegisterConversion.ToV128(mulHi.v4_0), RegisterConversion.ToV128(mulHi.v4_4), divisor.v8_8, d._promises));
                    }
                    else
                    {
                        return new short16(bmrem_i16(x.x0,  mulLo.x0, divisor.x0,  d._promises),
                                           bmrem_i16(x.x1,  mulLo.x1, divisor.x1,  d._promises),
                                           bmrem_i16(x.x2,  mulLo.x2, divisor.x2,  d._promises),
                                           bmrem_i16(x.x3,  mulLo.x3, divisor.x3,  d._promises),
                                           bmrem_i16(x.x4,  mulLo.x4, divisor.x4,  d._promises),
                                           bmrem_i16(x.x5,  mulLo.x5, divisor.x5,  d._promises),
                                           bmrem_i16(x.x6,  mulLo.x6, divisor.x6,  d._promises),
                                           bmrem_i16(x.x7,  mulLo.x7, divisor.x7,  d._promises),
                                           bmrem_i16(x.x8,  mulHi.x0, divisor.x8,  d._promises),
                                           bmrem_i16(x.x9,  mulHi.x1, divisor.x9,  d._promises),
                                           bmrem_i16(x.x10, mulHi.x2, divisor.x10, d._promises),
                                           bmrem_i16(x.x11, mulHi.x3, divisor.x11, d._promises),
                                           bmrem_i16(x.x12, mulHi.x4, divisor.x12, d._promises),
                                           bmrem_i16(x.x13, mulHi.x5, divisor.x13, d._promises),
                                           bmrem_i16(x.x14, mulHi.x6, divisor.x14, d._promises),
                                           bmrem_i16(x.x15, mulHi.x7, divisor.x15, d._promises));
                    }
                }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T operator % (int x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(int), 1, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            switch (sizeof(T))
            {
                case 8 * sizeof(int): return ((int8)x % d).Reinterpret<int8, T>();
                case 4 * sizeof(int): return ((int4)x % d).Reinterpret<int4, T>();
                case 3 * sizeof(int): return ((int3)x % d).Reinterpret<int3, T>();
                case 2 * sizeof(int): return ((int2)x % d).Reinterpret<int2, T>();
                default:
                {
                    if (d._promises.Pow2)
                    {
                        return pow2rem_i32(x, d._divisor.Reinterpret<T, int>(), d._promises).Reinterpret<int, T>();
                    }
                    else
                    {
                        return bmrem_i32(x, *(ulong*)&d._bigM, *(int*)&d._divisor, d._promises).Reinterpret<int, T>();
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator % (int2 x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(int), 2, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            if (d.DivideByScalar<int2>())
            {
                int divisor = *(int*)&d._divisor;

                if (d._promises.Pow2)
                {
                    if (Architecture.IsSIMDSupported)
                    {
                        return RegisterConversion.ToInt2(pow2rem_epi32_si32(RegisterConversion.ToV128(x), divisor, d._promises));
                    }
                    else
                    {
                        return new int2(pow2rem_i32(x.x, divisor, d._promises),
                                        pow2rem_i32(x.y, divisor, d._promises));
                    }
                }
                else
                {
                    if (Architecture.IsSIMDSupported)
                    {
                        int mul = *(int*)&d._mulShift._mul;
                        int shift = *(int*)&d._mulShift._shift;

                        return RegisterConversion.ToInt2(msrem_epi32_si32(RegisterConversion.ToV128(x), mul, shift, divisor, d._promises, 2));
                    }
                    else
                    {
                        ulong mul64 = *(ulong*)&d._bigM;

                        return new int2(bmrem_i32(x.x, mul64, divisor, d._promises),
                                        bmrem_i32(x.y, mul64, divisor, d._promises));
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
                        return RegisterConversion.ToInt2(pow2rem_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(divisor), d._promises));
                    }
                    else
                    {
                        return new int2(pow2rem_i32(x.x, divisor.x, d._promises),
                                        pow2rem_i32(x.y, divisor.y, d._promises));
                    }
                }
                else
                {
                    if (Architecture.IsSIMDSupported)
                    {
                        int2 mul = *(int2*)&d._mulShift._mul;
                        int2 shift = *(int2*)&d._mulShift._shift;

                        return RegisterConversion.ToInt2(msrem_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(mul), RegisterConversion.ToV128(shift), RegisterConversion.ToV128(divisor), d._promises, 2));
                    }
                    else
                    {
                        ulong2 mul64 = *(ulong2*)&d._bigM;

                        return new int2(bmrem_i32(x.x, mul64.x, divisor.x, d._promises),
                                        bmrem_i32(x.y, mul64.y, divisor.y, d._promises));
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator % (int3 x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(int), 3, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            if (d.DivideByScalar<int3>())
            {
                int divisor = *(int*)&d._divisor;

                if (d._promises.Pow2)
                {
                    if (Architecture.IsSIMDSupported)
                    {
                        return RegisterConversion.ToInt3(pow2rem_epi32_si32(RegisterConversion.ToV128(x), divisor, d._promises));
                    }
                    else
                    {
                        return new int3(pow2rem_i32(x.x, divisor, d._promises),
                                        pow2rem_i32(x.y, divisor, d._promises),
                                        pow2rem_i32(x.z, divisor, d._promises));
                    }
                }
                else
                {
                    if (Architecture.IsSIMDSupported)
                    {
                        int mul = *(int*)&d._mulShift._mul;
                        int shift = *(int*)&d._mulShift._shift;

                        return RegisterConversion.ToInt3(msrem_epi32_si32(RegisterConversion.ToV128(x), mul, shift, divisor, d._promises, 3));
                    }
                    else
                    {
                        ulong mul64 = *(ulong*)&d._bigM;

                        return new int3(bmrem_i32(x.x, mul64, divisor, d._promises),
                                        bmrem_i32(x.y, mul64, divisor, d._promises),
                                        bmrem_i32(x.z, mul64, divisor, d._promises));
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
                        return RegisterConversion.ToInt3(pow2rem_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(divisor), d._promises));
                    }
                    else
                    {
                        return new int3(pow2rem_i32(x.x, divisor.x, d._promises),
                                        pow2rem_i32(x.y, divisor.y, d._promises),
                                        pow2rem_i32(x.z, divisor.z, d._promises));
                    }
                }
                else
                {
                    if (Architecture.IsSIMDSupported)
                    {
                        int3 mul = *(int3*)&d._mulShift._mul;
                        int3 shift = *(int3*)&d._mulShift._shift;

                        return RegisterConversion.ToInt3(msrem_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(mul), RegisterConversion.ToV128(shift), RegisterConversion.ToV128(divisor), d._promises, 3));
                    }
                    else
                    {
                        ulong3 mul64 = *(ulong3*)&d._bigM;

                        return new int3(bmrem_i32(x.x, mul64.x, divisor.x, d._promises),
                                        bmrem_i32(x.y, mul64.y, divisor.y, d._promises),
                                        bmrem_i32(x.z, mul64.z, divisor.z, d._promises));
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 operator % (int4 x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(int), 4, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            if (d.DivideByScalar<int4>())
            {
                int divisor = *(int*)&d._divisor;

                if (d._promises.Pow2)
                {
                    if (Architecture.IsSIMDSupported)
                    {
                        return RegisterConversion.ToInt4(pow2rem_epi32_si32(RegisterConversion.ToV128(x), divisor, d._promises));
                    }
                    else
                    {
                        return new int4(pow2rem_i32(x.x, divisor, d._promises),
                                        pow2rem_i32(x.y, divisor, d._promises),
                                        pow2rem_i32(x.z, divisor, d._promises),
                                        pow2rem_i32(x.w, divisor, d._promises));
                    }
                }
                else
                {
                    if (Architecture.IsSIMDSupported)
                    {
                        int mul = *(int*)&d._mulShift._mul;
                        int shift = *(int*)&d._mulShift._shift;

                        return RegisterConversion.ToInt4(msrem_epi32_si32(RegisterConversion.ToV128(x), mul, shift, divisor, d._promises));
                    }
                    else
                    {
                        ulong mul64 = *(ulong*)&d._bigM;

                        return new int4(bmrem_i32(x.x, mul64, divisor, d._promises),
                                        bmrem_i32(x.y, mul64, divisor, d._promises),
                                        bmrem_i32(x.z, mul64, divisor, d._promises),
                                        bmrem_i32(x.w, mul64, divisor, d._promises));
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
                        return RegisterConversion.ToInt4(pow2rem_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(divisor), d._promises));
                    }
                    else
                    {
                        return new int4(pow2rem_i32(x.x, divisor.x, d._promises),
                                        pow2rem_i32(x.y, divisor.y, d._promises),
                                        pow2rem_i32(x.z, divisor.z, d._promises),
                                        pow2rem_i32(x.w, divisor.w, d._promises));
                    }
                }
                else
                {
                    if (Architecture.IsSIMDSupported)
                    {
                        int4 mul = *(int4*)&d._mulShift._mul;
                        int4 shift = *(int4*)&d._mulShift._shift;

                        return RegisterConversion.ToInt4(msrem_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(mul), RegisterConversion.ToV128(shift), RegisterConversion.ToV128(divisor), d._promises, 4));
                    }
                    else
                    {
                        ulong4 mul64 = *(ulong4*)&d._bigM;

                        return new int4(bmrem_i32(x.x, mul64.x, divisor.x, d._promises),
                                        bmrem_i32(x.y, mul64.y, divisor.y, d._promises),
                                        bmrem_i32(x.z, mul64.z, divisor.z, d._promises),
                                        bmrem_i32(x.w, mul64.w, divisor.w, d._promises));
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 operator % (int8 x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(int), 8, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            if (d.DivideByScalar<int8>())
            {
                int divisor = *(int*)&d._divisor;

                if (d._promises.Pow2)
                {
                    if (Avx2.IsAvx2Supported)
                    {
                        return mm256_pow2rem_epi32_si32(x, divisor, d._promises);
                    }
                    else if (Architecture.IsSIMDSupported)
                    {
                        return new int8(RegisterConversion.ToInt4(pow2rem_epi32_si32(RegisterConversion.ToV128(x.v4_0), divisor, d._promises)),
                                        RegisterConversion.ToInt4(pow2rem_epi32_si32(RegisterConversion.ToV128(x.v4_4), divisor, d._promises)));
                    }
                    else
                    {
                        return new int8(pow2rem_i32(x.x0, divisor, d._promises),
                                        pow2rem_i32(x.x1, divisor, d._promises),
                                        pow2rem_i32(x.x2, divisor, d._promises),
                                        pow2rem_i32(x.x3, divisor, d._promises),
                                        pow2rem_i32(x.x4, divisor, d._promises),
                                        pow2rem_i32(x.x5, divisor, d._promises),
                                        pow2rem_i32(x.x6, divisor, d._promises),
                                        pow2rem_i32(x.x7, divisor, d._promises));
                    }
                }
                else
                {
                    int mul = *(int*)&d._mulShift._mul;
                    int shift = *(int*)&d._mulShift._shift;

                    if (Avx2.IsAvx2Supported)
                    {
                        return mm256_msrem_epi32_si32(x, mul, shift, divisor, d._promises);
                    }
                    else if (Architecture.IsSIMDSupported)
                    {
                        return new int8(RegisterConversion.ToInt4(msrem_epi32_si32(RegisterConversion.ToV128(x.v4_0), mul, shift, divisor, d._promises)),
                                        RegisterConversion.ToInt4(msrem_epi32_si32(RegisterConversion.ToV128(x.v4_4), mul, shift, divisor, d._promises)));
                    }
                    else
                    {
                        ulong mul64 = *(ulong*)&d._bigM;

                        return new int8(bmrem_i32(x.x0, mul64, divisor, d._promises),
                                        bmrem_i32(x.x1, mul64, divisor, d._promises),
                                        bmrem_i32(x.x2, mul64, divisor, d._promises),
                                        bmrem_i32(x.x3, mul64, divisor, d._promises),
                                        bmrem_i32(x.x4, mul64, divisor, d._promises),
                                        bmrem_i32(x.x5, mul64, divisor, d._promises),
                                        bmrem_i32(x.x6, mul64, divisor, d._promises),
                                        bmrem_i32(x.x7, mul64, divisor, d._promises));
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
                        return mm256_pow2rem_epi32(x, divisor, d._promises);
                    }
                    else if (Architecture.IsSIMDSupported)
                    {
                        return new int8(RegisterConversion.ToInt4(pow2rem_epi32(RegisterConversion.ToV128(x.v4_0), RegisterConversion.ToV128(divisor.v4_0), d._promises)),
                                        RegisterConversion.ToInt4(pow2rem_epi32(RegisterConversion.ToV128(x.v4_4), RegisterConversion.ToV128(divisor.v4_4), d._promises)));
                    }
                    else
                    {
                        return new int8(pow2rem_i32(x.x0, divisor.x0, d._promises),
                                        pow2rem_i32(x.x1, divisor.x1, d._promises),
                                        pow2rem_i32(x.x2, divisor.x2, d._promises),
                                        pow2rem_i32(x.x3, divisor.x3, d._promises),
                                        pow2rem_i32(x.x4, divisor.x4, d._promises),
                                        pow2rem_i32(x.x5, divisor.x5, d._promises),
                                        pow2rem_i32(x.x6, divisor.x6, d._promises),
                                        pow2rem_i32(x.x7, divisor.x7, d._promises));
                    }
                }
                else
                {
                    int8 mul = *(int8*)&d._mulShift._mul;
                    int8 shift = *(int8*)&d._mulShift._shift;

                    if (Avx2.IsAvx2Supported)
                    {
                        return mm256_msrem_epi32(x, mul, shift, divisor, d._promises);
                    }
                    else if (Architecture.IsSIMDSupported)
                    {
                        return new int8(RegisterConversion.ToInt4(msrem_epi32(RegisterConversion.ToV128(x.v4_0), RegisterConversion.ToV128(mul.v4_0), RegisterConversion.ToV128(shift.v4_0), RegisterConversion.ToV128(divisor.v4_0), d._promises)),
                                        RegisterConversion.ToInt4(msrem_epi32(RegisterConversion.ToV128(x.v4_4), RegisterConversion.ToV128(mul.v4_4), RegisterConversion.ToV128(shift.v4_4), RegisterConversion.ToV128(divisor.v4_4), d._promises)));
                    }
                    else
                    {
                        ulong4 mul64Lo = *(ulong4*)&d._bigM._mulLo;
                        ulong4 mul64Hi = *(ulong4*)&d._bigM._mulHi;

                        return new int8(bmrem_i32(x.x0, mul64Lo.x, divisor.x0, d._promises),
                                        bmrem_i32(x.x1, mul64Lo.y, divisor.x1, d._promises),
                                        bmrem_i32(x.x2, mul64Lo.z, divisor.x2, d._promises),
                                        bmrem_i32(x.x3, mul64Lo.w, divisor.x3, d._promises),
                                        bmrem_i32(x.x4, mul64Hi.x, divisor.x4, d._promises),
                                        bmrem_i32(x.x5, mul64Hi.y, divisor.x5, d._promises),
                                        bmrem_i32(x.x6, mul64Hi.z, divisor.x6, d._promises),
                                        bmrem_i32(x.x7, mul64Hi.w, divisor.x7, d._promises));
                    }
                }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T operator % (long x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(long), 1, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            switch (sizeof(T))
            {
                case 4 * sizeof(long): return ((long4)x % d).Reinterpret<long4, T>();
                case 3 * sizeof(long): return ((long3)x % d).Reinterpret<long3, T>();
                case 2 * sizeof(long): return ((long2)x % d).Reinterpret<long2, T>();
                default:
                {
                    if (d._promises.Pow2)
                    {
                        return pow2rem_i64(x, d._divisor.Reinterpret<T, long>(), d._promises).Reinterpret<long, T>();
                    }
                    else
                    {
                        if (Architecture.IsBurstCompiled)
                        {
                            return bmrem_i64(x, *(UInt128*)&d._bigM, *(long*)&d._divisor, d._promises).Reinterpret<long, T>();
                        }
                        else
                        {
                            return msrem_i64(x, *(long*)&d._mulShift._mul, *(long*)&d._mulShift._shift, *(long*)&d._divisor, d._promises).Reinterpret<long, T>();
                        }
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator % (long2 x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(long), 2, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            if (d.DivideByScalar<long2>())
            {
                long divisor = *(long*)&d._divisor;

                if (d._promises.Pow2)
                {
                    if (Architecture.IsSIMDSupported)
                    {
                        return pow2rem_epi64_si64(x, divisor, d._promises);
                    }
                    else
                    {
                        return new long2(pow2rem_i64(x.x, divisor, d._promises),
                                         pow2rem_i64(x.y, divisor, d._promises));
                    }
                }
                else
                {
                    if (Architecture.IsBurstCompiled)
                    {
                        UInt128 mul128 = *(UInt128*)&d._bigM;

                        return new long2(bmrem_i64(x.x, mul128, divisor, d._promises),
                                         bmrem_i64(x.y, mul128, divisor, d._promises));
                    }
                    else
                    {
                        long mul = *(long*)&d._mulShift._mul;
                        long shift = *(long*)&d._mulShift._shift;

                        return new long2(msrem_i64(x.x, mul, shift, divisor, d._promises),
                                         msrem_i64(x.y, mul, shift, divisor, d._promises));
                    }
                }
            }
            else
            {
                long2 divisor = *(long2*)&d._divisor;

                if (d._promises.Pow2)
                {
                    if (Architecture.IsSIMDSupported)
                    {
                        return pow2rem_epi64(x, divisor, d._promises);
                    }
                    else
                    {
                        return new long2(pow2rem_i64(x.x, divisor.x, d._promises),
                                         pow2rem_i64(x.y, divisor.y, d._promises));
                    }
                }
                else
                {
                    if (Architecture.IsBurstCompiled)
                    {
                        UInt128 mul0 = *((UInt128*)&d._bigM + 0);
                        UInt128 mul1 = *((UInt128*)&d._bigM + 1);

                        return new long2(bmrem_i64(x.x, mul0, divisor.x, d._promises),
                                         bmrem_i64(x.y, mul1, divisor.y, d._promises));
                    }
                    else
                    {
                        long2 mul = *(long2*)&d._mulShift._mul;
                        long2 shift = *(long2*)&d._mulShift._shift;

                        return new long2(msrem_i64(x.x, mul.x, shift.x, divisor.x, d._promises),
                                         msrem_i64(x.y, mul.y, shift.y, divisor.y, d._promises));
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator % (long3 x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(long), 3, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            if (d.DivideByScalar<long3>())
            {
                long divisor = *(long*)&d._divisor;

                if (d._promises.Pow2)
                {
                    if (Avx2.IsAvx2Supported)
                    {
                        return mm256_pow2rem_epi64_si64(x, divisor, d._promises);
                    }
                    else if (Architecture.IsSIMDSupported)
                    {
                        return new long3(pow2rem_epi64_si64(x.xy, divisor, d._promises),
                                         pow2rem_i64(x.z, divisor, d._promises));
                    }
                    else
                    {
                        return new long3(pow2rem_i64(x.x, divisor, d._promises),
                                         pow2rem_i64(x.y, divisor, d._promises),
                                         pow2rem_i64(x.z, divisor, d._promises));
                    }
                }
                else
                {
                    long mul = *(long*)&d._mulShift._mul;
                    long shift = *(long*)&d._mulShift._shift;

                    if (Avx2.IsAvx2Supported)
                    {
                        return mm256_msrem_epi64_si64(x, mul, shift, divisor, d._promises, 3);
                    }
                    else
                    {

                        if (Architecture.IsBurstCompiled)
                        {
                            UInt128 mul128 = *(UInt128*)&d._bigM;

                            return new long3(bmrem_i64(x.x, mul128, divisor, d._promises),
                                             bmrem_i64(x.y, mul128, divisor, d._promises),
                                             bmrem_i64(x.z, mul128, divisor, d._promises));
                        }
                        else
                        {
                            return new long3(msrem_i64(x.x, mul, shift, divisor, d._promises),
                                             msrem_i64(x.y, mul, shift, divisor, d._promises),
                                             msrem_i64(x.z, mul, shift, divisor, d._promises));
                        }
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
                        return mm256_pow2rem_epi64(x, divisor, d._promises);
                    }
                    else if (Architecture.IsSIMDSupported)
                    {
                        return new long3(pow2rem_epi64(x.xy, divisor.xy, d._promises),
                                         pow2rem_i64(x.z, divisor.z, d._promises));
                    }
                    else
                    {
                        return new long3(pow2rem_i64(x.x, divisor.x, d._promises),
                                         pow2rem_i64(x.y, divisor.y, d._promises),
                                         pow2rem_i64(x.z, divisor.z, d._promises));
                    }
                }
                else
                {
                    if (Avx2.IsAvx2Supported)
                    {
                        return mm256_msrem_epi64(x, *(long3*)&d._mulShift._mul, *(long3*)&d._mulShift._shift, divisor, d._promises, 3);
                    }
                    else
                    {
                        if (Architecture.IsBurstCompiled)
                        {
                            UInt128 mul0 = *((UInt128*)&d._bigM + 0);
                            UInt128 mul1 = *((UInt128*)&d._bigM + 1);
                            UInt128 mul2 = *((UInt128*)&d._bigM + 2);

                            return new long3(bmrem_i64(x.x, mul0, divisor.x, d._promises),
                                             bmrem_i64(x.y, mul1, divisor.y, d._promises),
                                             bmrem_i64(x.z, mul2, divisor.z, d._promises));
                        }
                        else
                        {
                            long3 mul = *(long3*)&d._mulShift._mul;
                            long3 shift = *(long3*)&d._mulShift._shift;

                            return new long3(msrem_i64(x.x, mul.x, shift.x, divisor.x, d._promises),
                                             msrem_i64(x.y, mul.y, shift.y, divisor.y, d._promises),
                                             msrem_i64(x.z, mul.z, shift.z, divisor.z, d._promises));
                        }
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator % (long4 x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(long), 4, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            if (d.DivideByScalar<long4>())
            {
                long divisor = *(long*)&d._divisor;

                if (d._promises.Pow2)
                {
                    if (Avx2.IsAvx2Supported)
                    {
                        return mm256_pow2rem_epi64_si64(x, divisor, d._promises);
                    }
                    else if (Architecture.IsSIMDSupported)
                    {
                        return new long4(pow2rem_epi64_si64(x.xy, divisor, d._promises),
                                         pow2rem_epi64_si64(x.zw, divisor, d._promises));
                    }
                    else
                    {
                        return new long4(pow2rem_i64(x.x, divisor, d._promises),
                                         pow2rem_i64(x.y, divisor, d._promises),
                                         pow2rem_i64(x.z, divisor, d._promises),
                                         pow2rem_i64(x.w, divisor, d._promises));
                    }
                }
                else
                {
                    long mul = *(long*)&d._mulShift._mul;
                    long shift = *(long*)&d._mulShift._shift;

                    if (Avx2.IsAvx2Supported)
                    {
                        return mm256_msrem_epi64_si64(x, mul, shift, divisor, d._promises);
                    }
                    else
                    {
                        if (Architecture.IsBurstCompiled)
                        {
                            UInt128 mul128 = *(UInt128*)&d._bigM;

                            return new long4(bmrem_i64(x.x, mul128, divisor, d._promises),
                                             bmrem_i64(x.y, mul128, divisor, d._promises),
                                             bmrem_i64(x.z, mul128, divisor, d._promises),
                                             bmrem_i64(x.w, mul128, divisor, d._promises));
                        }
                        else
                        {
                            return new long4(msrem_i64(x.x, mul, shift, divisor, d._promises),
                                             msrem_i64(x.y, mul, shift, divisor, d._promises),
                                             msrem_i64(x.z, mul, shift, divisor, d._promises),
                                             msrem_i64(x.w, mul, shift, divisor, d._promises));
                        }
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
                        return mm256_pow2rem_epi64(x, divisor, d._promises);
                    }
                    else if (Architecture.IsSIMDSupported)
                    {
                        return new long4(pow2rem_epi64(x.xy, divisor.xy, d._promises),
                                         pow2rem_epi64(x.zw, divisor.zw, d._promises));
                    }
                    else
                    {
                        return new long4(pow2rem_i64(x.x, divisor.x, d._promises),
                                         pow2rem_i64(x.y, divisor.y, d._promises),
                                         pow2rem_i64(x.z, divisor.z, d._promises),
                                         pow2rem_i64(x.w, divisor.w, d._promises));
                    }
                }
                else
                {
                    if (Avx2.IsAvx2Supported)
                    {
                        return mm256_msrem_epi64(x, *(long4*)&d._mulShift._mul, *(long4*)&d._mulShift._shift, divisor, d._promises, 4);
                    }
                    else
                    {
                        if (Architecture.IsBurstCompiled)
                        {
                            UInt128 mul0 = *((UInt128*)&d._bigM + 0);
                            UInt128 mul1 = *((UInt128*)&d._bigM + 1);
                            UInt128 mul2 = *((UInt128*)&d._bigM + 2);
                            UInt128 mul3 = *((UInt128*)&d._bigM + 3);

                            return new long4(bmrem_i64(x.x, mul0, divisor.x, d._promises),
                                             bmrem_i64(x.y, mul1, divisor.y, d._promises),
                                             bmrem_i64(x.z, mul2, divisor.z, d._promises),
                                             bmrem_i64(x.w, mul3, divisor.w, d._promises));
                        }
                        else
                        {
                            long4 mul = *(long4*)&d._mulShift._mul;
                            long4 shift = *(long4*)&d._mulShift._shift;

                            return new long4(msrem_i64(x.x, mul.x, shift.x, divisor.x, d._promises),
                                             msrem_i64(x.y, mul.y, shift.y, divisor.y, d._promises),
                                             msrem_i64(x.z, mul.z, shift.z, divisor.z, d._promises),
                                             msrem_i64(x.w, mul.w, shift.w, divisor.w, d._promises));
                        }
                    }
                }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 operator % (Int128 x, Divider<T> d)
        {
d.AssertOperationMatchesInitialization(sizeof(Int128), 1, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            if (d._promises.Pow2)
            {
                return pow2rem_i128(x, *(Int128*)&d._divisor, d._promises);
            }
            else
            {
                return msrem_i128(x, *(UInt128*)&d._mulShift._mul, *(Int128*)&d._mulShift._shift, *(Int128*)&d._divisor, d._promises);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static sbyte pow2rem_i8(sbyte x, sbyte original, DividerPromise promises)
        {
            byte __abs = (byte)promise_abs_i8(original, promises);

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

            return (sbyte)(x - (result & -__abs));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static short pow2rem_i16(short x, short original, DividerPromise promises)
        {
            ushort __abs = (ushort)promise_abs_i16(original, promises);

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

            return (short)(x - (result & -__abs));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int pow2rem_i32(int x, int original, DividerPromise promises)
        {
            int __abs = promise_abs_i32(original, promises);

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

            return x - (result & -__abs);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static long pow2rem_i64(long x, long original, DividerPromise promises)
        {
            long __abs = promise_abs_i64(original, promises);

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

            return x - (result & -__abs);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Int128 pow2rem_i128(Int128 x, Int128 original, DividerPromise promises)
        {
            Int128 __abs = promise_abs_i128(original, promises);

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

            return x - (result & -__abs);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 pow2rem_epi8(v128 d, v128 original, DividerPromise promises, byte elements = 16)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 __abs = promise_abs_epi8(original, promises, elements);

                v128 result;
                if (constexpr.ALL_EQ_EPI8(Xse.abs_epi8(original), 2, elements))
                {
                    result = Xse.sub_epi8(d, Xse.srai_epi8(d, 7, elements: elements));
                }
                else
                {
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
                }

                return Xse.sub_epi8(d, Xse.and_si128(result, Xse.neg_epi8(__abs)));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 pow2rem_epi16(v128 d, v128 original, DividerPromise promises, byte elements = 8)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 __abs = promise_abs_epi16(original, promises, elements);
                
                v128 result;
                if (constexpr.ALL_EQ_EPI16(Xse.abs_epi16(original), 2, elements))
                {
                    result = Xse.sub_epi16(d, Xse.srai_epi16(d, 15));
                }
                else
                {
                    v128 summand = Xse.dec_epi16(__abs);
                    summand = Xse.and_si128(Xse.srai_epi16(d, 15), summand);
                    result = Xse.add_epi16(d, summand);
                }

                return Xse.sub_epi16(d, Xse.and_si128(result, Xse.neg_epi16(__abs)));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 pow2rem_epi32(v128 d, v128 original, DividerPromise promises, byte elements = 4)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 __abs = promise_abs_epi32(original, promises, elements);
                
                v128 result;
                if (constexpr.ALL_EQ_EPI32(Xse.abs_epi32(original), 2, elements))
                {
                    result = Xse.sub_epi32(d, Xse.srai_epi32(d, 31));
                }
                else
                {
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
                }

                return Xse.sub_epi32(d, Xse.and_si128(result, Xse.neg_epi32(__abs)));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 pow2rem_epi64(v128 d, v128 original, DividerPromise promises)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 __abs = promise_abs_epi64(original, promises);
                
                v128 result;
                if (constexpr.ALL_EQ_EPI64(Xse.abs_epi64(original), 2))
                {
                    result = Xse.add_epi64(d, Xse.srli_epi64(d, 63));
                }
                else
                {
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
                }

                return Xse.sub_epi64(d, Xse.and_si128(result, Xse.neg_epi64(__abs)));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_pow2rem_epi8(v256 d, v256 original, DividerPromise promises)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 __abs = mm256_promise_abs_epi8(original, promises);
                
                v256 result;
                if (constexpr.ALL_EQ_EPI8(Xse.mm256_abs_epi8(original), 2))
                {
                    result = Avx2.mm256_sub_epi8(d, Xse.mm256_srai_epi8(d, 7));
                }
                else
                {
                    v256 summand = Xse.mm256_dec_epi8(__abs);
                    summand = Avx2.mm256_blendv_epi8(Avx.mm256_setzero_si256(), summand, d);
                    result = Avx2.mm256_add_epi8(d, summand);
                }

                return Avx2.mm256_sub_epi8(d, Avx2.mm256_and_si256(result, Xse.mm256_neg_epi8(__abs)));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_pow2rem_epi16(v256 d, v256 original, DividerPromise promises)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 __abs = mm256_promise_abs_epi16(original, promises);
                
                v256 result;
                if (constexpr.ALL_EQ_EPI16(Xse.mm256_abs_epi16(original), 2))
                {
                    result = Avx2.mm256_sub_epi16(d, Xse.mm256_srai_epi16(d, 15));
                }
                else
                {
                    v256 summand = Xse.mm256_dec_epi16(__abs);
                    summand = Avx2.mm256_and_si256(Xse.mm256_srai_epi16(d, 15), summand);
                    result = Avx2.mm256_add_epi16(d, summand);
                }

                return Avx2.mm256_sub_epi16(d, Avx2.mm256_and_si256(result, Xse.mm256_neg_epi16(__abs)));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_pow2rem_epi32(v256 d, v256 original, DividerPromise promises)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 __abs = mm256_promise_abs_epi32(original, promises);
                
                v256 result;
                if (constexpr.ALL_EQ_EPI32(Xse.mm256_abs_epi32(original), 2))
                {
                    result = Avx2.mm256_sub_epi32(d, Xse.mm256_srai_epi32(d, 31));
                }
                else
                {
                    v256 summand = Xse.mm256_dec_epi32(__abs);
                    summand = Avx.mm256_blendv_ps(Avx.mm256_setzero_si256(), summand, d);
                    result = Avx2.mm256_add_epi32(d, summand);
                }

                return Avx2.mm256_sub_epi32(d, Avx2.mm256_and_si256(result, Xse.mm256_neg_epi32(__abs)));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_pow2rem_epi64(v256 d, v256 original, DividerPromise promises, byte elements = 4)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 __abs = mm256_promise_abs_epi64(original, promises, elements);
                
                v256 result;
                if (constexpr.ALL_EQ_EPI64(Xse.mm256_abs_epi64(original), 2, elements))
                {
                    result = Avx2.mm256_add_epi64(d, Xse.mm256_srli_epi64(d, 63));
                }
                else
                {
                    v256 summand = Xse.mm256_dec_epi64(__abs);
                    summand = Avx.mm256_blendv_pd(Avx.mm256_setzero_si256(), summand, d);
                    result = Avx2.mm256_add_epi64(d, summand);
                }

                return Avx2.mm256_sub_epi64(d, Avx2.mm256_and_si256(result, Xse.mm256_neg_epi64(__abs)));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 pow2rem_epi8_si8(v128 d, sbyte original, DividerPromise promises)
        {
            if (Architecture.IsSIMDSupported)
            {
                sbyte __abs = promise_abs_i8(original, promises);

                v128 result = d;
                if (constexpr.IS_TRUE(original == 2 || original == -2))
                {
                    result = Xse.sub_epi8(result, Xse.srai_epi8(d, 7));
                }
                else
                {
                    v128 summand = Xse.dec_epi8(Xse.set1_epi8(__abs));
                    if (Sse4_1.IsSse41Supported)
                    {
                        result = Xse.add_epi8(result, Xse.blendv_epi8(Xse.setzero_si128(), summand, d));
                    }
                    else
                    {
                        result = Xse.add_epi8(result, Xse.and_si128(Xse.srai_epi8(d, 7), summand));
                    }
                }

                return Xse.sub_epi8(d, Xse.and_si128(result, Xse.neg_epi8(Xse.set1_epi8(__abs))));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 pow2rem_epi16_si16(v128 d, short original, DividerPromise promises)
        {
            if (Architecture.IsSIMDSupported)
            {
                short __abs = promise_abs_i16(original, promises);

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

                return Xse.sub_epi16(d, Xse.and_si128(result, Xse.neg_epi16(Xse.set1_epi16(__abs))));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 pow2rem_epi32_si32(v128 d, int original, DividerPromise promises)
        {
            if (Architecture.IsSIMDSupported)
            {
                int __abs = promise_abs_i32(original, promises);

                v128 result = d;
                if (constexpr.IS_TRUE(original == 2 || original == -2))
                {
                    result = Xse.add_epi32(result, Xse.srli_epi32(d, 31));
                }
                else
                {
                    v128 summand = Xse.dec_epi32(Xse.set1_epi32(__abs));
                    if (Sse4_1.IsSse41Supported)
                    {
                        result = Xse.add_epi32(result, Xse.blendv_ps(Xse.setzero_si128(), summand, d));
                    }
                    else
                    {
                        result = Xse.add_epi32(result, Xse.and_si128(Xse.srai_epi32(d, 31), summand));
                    }
                }

                return Xse.sub_epi32(d, Xse.and_si128(result, Xse.neg_epi32(Xse.set1_epi32(__abs))));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 pow2rem_epi64_si64(v128 d, long original, DividerPromise promises)
        {
            if (Architecture.IsSIMDSupported)
            {
                long __abs = promise_abs_i64(original, promises);

                v128 result = d;
                if (constexpr.IS_TRUE(original == 2 || original == -2))
                {
                    result = Xse.add_epi64(result, Xse.srli_epi64(d, 63));
                }
                else
                {
                    v128 summand = Xse.dec_epi64(Xse.set1_epi64x(__abs));
                    if (Sse4_1.IsSse41Supported)
                    {
                        result = Xse.add_epi64(result, Xse.blendv_pd(Xse.setzero_si128(), summand, d));
                    }
                    else
                    {
                        result = Xse.add_epi64(result, Xse.and_si128(Xse.srai_epi64(d, 63), summand));
                    }
                }

                return Xse.sub_epi64(d, Xse.and_si128(result, Xse.neg_epi64(Xse.set1_epi64x(__abs))));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_pow2rem_epi8_si8(v256 d, sbyte original, DividerPromise promises)
        {
            if (Avx2.IsAvx2Supported)
            {
                sbyte __abs = promise_abs_i8(original, promises);
                
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

                return Avx2.mm256_sub_epi8(d, Avx2.mm256_and_si256(result, Xse.mm256_neg_epi8(Xse.mm256_set1_epi8(__abs))));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_pow2rem_epi16_si16(v256 d, short original, DividerPromise promises)
        {
            if (Avx2.IsAvx2Supported)
            {
                short __abs = promise_abs_i16(original, promises);

                v256 result = d;
                if (constexpr.IS_TRUE(original == 2 || original == -2))
                {
                    result = Avx2.mm256_add_epi16(result, Avx2.mm256_srli_epi16(d, 15));
                }
                else
                {
                    v256 summand = Xse.mm256_dec_epi16(Xse.mm256_set1_epi16(__abs));
                    summand = Avx2.mm256_and_si256(Xse.mm256_srai_epi16(d, 15), summand);
                    result = Avx2.mm256_add_epi16(result, summand);
                }

                return Avx2.mm256_sub_epi16(d, Avx2.mm256_and_si256(result, Xse.mm256_neg_epi16(Xse.mm256_set1_epi16(__abs))));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_pow2rem_epi32_si32(v256 d, int original, DividerPromise promises)
        {
            if (Avx2.IsAvx2Supported)
            {
                int __abs = promise_abs_i32(original, promises);
                
                v256 result;
                if (constexpr.IS_TRUE(original == 2 || original == -2))
                {
                    result = Avx2.mm256_sub_epi32(d, Xse.mm256_srai_epi32(d, 31));
                }
                else
                {
                    v256 summand = Xse.mm256_dec_epi32(Xse.mm256_set1_epi32(__abs));
                    summand = Avx.mm256_blendv_ps(Avx.mm256_setzero_si256(), summand, d);
                    result = Avx2.mm256_add_epi32(d, summand);
                }

                return Avx2.mm256_sub_epi32(d, Avx2.mm256_and_si256(result, Xse.mm256_neg_epi32(Xse.mm256_set1_epi32(__abs))));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_pow2rem_epi64_si64(v256 d, long original, DividerPromise promises)
        {
            if (Avx2.IsAvx2Supported)
            {
                long __abs = promise_abs_i64(original, promises);
                
                v256 result;
                if (constexpr.IS_TRUE(original == 2 || original == -2))
                {
                    result = Avx2.mm256_add_epi64(d, Xse.mm256_srli_epi64(d, 63));
                }
                else
                {
                    v256 summand = Xse.mm256_dec_epi64(Xse.mm256_set1_epi64x(__abs));
                    summand = Avx.mm256_blendv_pd(Avx.mm256_setzero_si256(), summand, d);
                    result = Avx2.mm256_add_epi64(d, summand);
                }

                return Avx2.mm256_sub_epi64(d, Avx2.mm256_and_si256(result, Xse.mm256_neg_epi64(Xse.mm256_set1_epi64x(__abs))));
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static sbyte bmrem_i8(sbyte x, ushort mul, sbyte original, DividerPromise promises)
        {
            sbyte __abs = promise_abs_i8(original, promises);
            byte absResult = bmrem_u8((byte)abs(x), (byte)__abs, mul);

            Xse.SIGNED_FROM_UNSIGNED_DIV_I8(out sbyte result, x, original, 0, absResult, divisorPositive: promises.Positive, divisorNegative: promises.Negative);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static short bmrem_i16(short x, uint mul, short original, DividerPromise promises)
        {
            short __abs = promise_abs_i16(original, promises);
            ushort absResult = bmrem_u16((ushort)abs(x), (ushort)__abs, mul);

            Xse.SIGNED_FROM_UNSIGNED_DIV_I16(out short result, x, original, 0, absResult, divisorPositive: promises.Positive, divisorNegative: promises.Negative);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int bmrem_i32(int x, ulong mul, int original, DividerPromise promises)
        {
            int __abs = promise_abs_i32(original, promises);

            ulong lo = mul * (ulong)x;
            int r = (int)UInt128.umul128(lo, (uint)__abs).hi64;

            if (!constexpr.IS_TRUE(x >= 0))
            {
                r -= (__abs - 1) & (x >> 31);
            }
            if (!promises.NotMinValue)
            {
                if (original == int.MinValue)
                {
                    if (constexpr.IS_TRUE((x != int.MinValue) | (x > int.MinValue)))
                    {
                        r = x;
                    }
                    else if (constexpr.IS_TRUE(x == int.MinValue))
                    {
                        r = 0;
                    }
                    else
                    {
                        r = andnot(x, -tobyte(x == int.MinValue));
                    }
                }
            }

            return r;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static long FRONT_bmrem_i64(long x, UInt128 mul128, long absO, DividerPromise promises)
        {
            mul128 *= (UInt128)x;

            UInt128 lo = UInt128.umul128(mul128.lo64, (ulong)absO);
            UInt128 hi = UInt128.umul128(mul128.hi64, (ulong)absO);

            return (long)(lo.hi64 + hi).hi64;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static long bmrem_i64(long x, UInt128 mul128, long original, DividerPromise promises)
        {
            long __abs = promise_abs_i64(original, promises);

            long r = FRONT_bmrem_i64(x, mul128, __abs, promises);

            if (!constexpr.IS_TRUE(x >= 0))
            {
                r -= (abs(original) - 1) & (x >> 63);
            }
            if (!promises.NotMinValue)
            {
                if (original == long.MinValue)
                {
                    if (constexpr.IS_TRUE(x != long.MinValue))
                    {
                        r = x;
                    }
                    else if (constexpr.IS_TRUE(x == long.MinValue))
                    {
                        r = 0;
                    }
                    else
                    {
                        r = andnot(x, -tolong(x == long.MinValue));
                    }
                }
            }

            return r;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static long msrem_i64(long x, long mul, long shift, long original, DividerPromise promises)
        {
            return x - (msdiv_i64(x, mul, shift, original, promises) * original);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Int128 msrem_i128(Int128 dividend, UInt128 mul, Int128 shift, Int128 original, DividerPromise promises)
        {
            return dividend - (msdiv_i128(dividend, mul, shift, original, promises) * original);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 bmrem_epi8(v128 d, v128 mul, v128 original, DividerPromise promises, byte elements = 8)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 __abs = promise_abs_epi8(original, promises, elements);
                v128 absResult = bmrem_epu8(Xse.abs_epi8(d, elements), __abs, mul, elements);

                Xse.SIGNED_FROM_UNSIGNED_DIV_EPI8(out v128 signedResult, d, original, default(v128), absResult, elements: elements, divisorPositive: promises.Positive, divisorNegative: promises.Negative);

                return signedResult;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 bmrem_epi16(v128 d, v128 mul, v128 original, DividerPromise promises, byte elements = 4)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 __abs = promise_abs_epi16(original, promises, elements);
                v128 absResult = bmrem_epu16(Xse.abs_epi16(d, elements), __abs, mul, elements);

                Xse.SIGNED_FROM_UNSIGNED_DIV_EPI16(out v128 signedResult, d, original, default(v128), absResult, divisorPositive: promises.Positive, divisorNegative: promises.Negative, elements: elements);

                return signedResult;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 bmrem_epi8(v128 d, v128 mulLo, v128 mulHi, v128 original, DividerPromise promises)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 __abs = promise_abs_epi8(original, promises);
                v128 absResult = bmrem_epu8(Xse.abs_epi8(d), __abs, mulLo, mulHi);

                Xse.SIGNED_FROM_UNSIGNED_DIV_EPI8(out v128 signedResult, d, original, default(v128), absResult, divisorPositive: promises.Positive, divisorNegative: promises.Negative);

                return signedResult;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 bmrem_epi16(v128 d, v128 mulLo, v128 mulHi, v128 original, DividerPromise promises)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 __abs = promise_abs_epi16(original, promises);
                v128 absResult = bmrem_epu16(Xse.abs_epi16(d), __abs, mulLo, mulHi);

                Xse.SIGNED_FROM_UNSIGNED_DIV_EPI16(out v128 signedResult, d, original, default(v128), absResult, divisorPositive: promises.Positive, divisorNegative: promises.Negative);

                return signedResult;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 msrem_epi32(v128 a, v128 mul, v128 shift, v128 original, DividerPromise promises, byte elements = 4)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.sub_epi32(a, Xse.mullo_epi32(msdiv_epi32(a, mul, shift, original, promises, elements), original, elements));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 bmrem_epi32(v128 a, v128 mulLo, v128 mulHi, v128 original, DividerPromise promises, byte elements = 4)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 __abs = promise_abs_epi32(original, promises, elements);

                v128 r;

                if (elements == 2)
                {
                    v128 d16 = Xse.cvtepi32_epi64(a);
                    v128 absO16 = Xse.cvtepu32_epi64(__abs);

                    r = Xse.mulhi_epi64(Xse.mullo_epi64(mulLo, d16), absO16);
                    r = Xse.cvtepi64_epi32(r);
                }
                else
                {
                    v128 d16Lo = Xse.cvt2x2epi32_epi64(a, out v128 d16Hi);
                    v128 absO16Lo = Xse.cvt2x2epu32_epi64(__abs, out v128 absO16Hi);

                    v128 rLo = Xse.mulhi_epi64(Xse.mullo_epi64(mulLo, d16Lo), absO16Lo);
                    v128 rHi = Xse.mulhi_epi64(Xse.mullo_epi64(mulHi, d16Hi), absO16Hi);
                    r = Xse.cvt2x2epi64_epi32(rLo, rHi);
                }

                if (!constexpr.ALL_GE_EPI32(a, 0, elements))
                {
                    r = Xse.sub_epi32(r, Xse.and_si128(Xse.dec_epi32(__abs), Xse.srai_epi32(a, 31)));
                }
                if (!promises.NotMinValue)
                {
                    v128 MIN_VALUE_I32 = Xse.set1_epi32(int.MinValue);

                    v128 divisorIsMinValMask = Xse.cmpeq_epi32(original, MIN_VALUE_I32);

                    if (constexpr.ALL_NEQ_EPI32(a, int.MinValue, elements))
                    {
                        r = Xse.blendv_si128(r, a, divisorIsMinValMask);
                    }
                    else if (constexpr.ALL_EQ_EPI32(a, int.MinValue, elements))
                    {
                        r = Xse.andnot_si128(divisorIsMinValMask, r);
                    }
                    else
                    {
                        v128 dividendIsMinValMask = Xse.cmpeq_epi32(a, MIN_VALUE_I32);

                        r = Xse.blendv_si128(r, Xse.andnot_si128(dividendIsMinValMask, a), divisorIsMinValMask);
                    }
                }

                return r;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 bmrem_epi64(v128 a, UInt128 mulLo, UInt128 mulHi, v128 original, DividerPromise promises)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 __abs = promise_abs_epi64(original, promises);

                long r0 = FRONT_bmrem_i64((long)Xse.extract_epi64(a, 0), mulLo, (long)Xse.extract_epi64(__abs, 0), promises);
                long r1 = FRONT_bmrem_i64((long)Xse.extract_epi64(a, 1), mulHi, (long)Xse.extract_epi64(__abs, 1), promises);

                v128 r = Xse.unpacklo_epi64(Xse.cvtsi64x_si128(r0), Xse.cvtsi64x_si128(r1));

                if (constexpr.ALL_GE_EPI64(a, 0))
                {
                    r = Xse.sub_epi64(r, Xse.and_si128(Xse.dec_epi64(__abs), Xse.srai_epi64(a, 63)));
                }
                if (!promises.NotMinValue)
                {
                    v128 MIN_VALUE_I64 = Xse.set1_epi64x(long.MinValue);

                    v128 divisorIsMinValMask = Xse.cmpeq_epi64(original, MIN_VALUE_I64);

                    if (constexpr.ALL_NEQ_EPI64(a, long.MinValue) || constexpr.ALL_GT_EPI64(a, long.MinValue))
                    {
                        r = Xse.blendv_si128(r, a, divisorIsMinValMask);
                    }
                    else if (constexpr.ALL_EQ_EPI64(a, long.MinValue))
                    {
                        r = Xse.andnot_si128(divisorIsMinValMask, r);
                    }
                    else
                    {
                        v128 dividendIsMinValMask = Xse.cmpeq_epi64(a, MIN_VALUE_I64);

                        r = Xse.blendv_si128(r, Xse.andnot_si128(dividendIsMinValMask, a), divisorIsMinValMask);
                    }
                }

                return r;
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_bmrem_epi8(v256 d, v256 mulLo, v256 mulHi, v256 original, DividerPromise promises)
        {
            if (Architecture.IsSIMDSupported)
            {
                v256 __abs = mm256_promise_abs_epi8(original, promises);
                v256 absResult = mm256_bmrem_epu8(Xse.mm256_abs_epi8(d), __abs, mulLo, mulHi);

                Xse.SIGNED_FROM_UNSIGNED_DIV_EPI8(out v256 signedResult, d, original, default(v256), absResult, divisorPositive: promises.Positive, divisorNegative: promises.Negative);

                return signedResult;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_bmrem_epi16(v256 d, v256 mulLo, v256 mulHi, v256 original, DividerPromise promises)
        {
            if (Architecture.IsSIMDSupported)
            {
                v256 __abs = mm256_promise_abs_epi16(original, promises);
                v256 absResult = mm256_bmrem_epu16(Xse.mm256_abs_epi16(d), __abs, mulLo, mulHi);

                Xse.SIGNED_FROM_UNSIGNED_DIV_EPI16(out v256 signedResult, d, original, default(v256), absResult, divisorPositive: promises.Positive, divisorNegative: promises.Negative);

                return signedResult;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_msrem_epi32(v256 a, v256 mul, v256 shift, v256 original, DividerPromise promises)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_sub_epi32(a, Avx2.mm256_mullo_epi32(mm256_msdiv_epi32(a, mul, shift, original, promises), original));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_bmrem_epi32(v256 a, v256 mulLo, v256 mulHi, v256 original, DividerPromise promises)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 __abs = mm256_promise_abs_epi32(original, promises);

                v256 r;

                v256 d16Lo = Xse.mm256_cvt2x2epi32_epi64(a, out v256 d16Hi);
                v256 absO16Lo = Xse.mm256_cvt2x2epu32_epi64(__abs, out v256 absO16Hi);

                v256 rLo = Xse.mm256_mulhi_epi64(Xse.mm256_mullo_epi64(new v256(mulLo.Lo128, mulHi.Lo128), d16Lo), absO16Lo);
                v256 rHi = Xse.mm256_mulhi_epi64(Xse.mm256_mullo_epi64(new v256(mulLo.Hi128, mulHi.Hi128), d16Hi), absO16Hi);
                r = Xse.mm256_cvt2x2epi64_epi32(rLo, rHi);

                if (!constexpr.ALL_GE_EPI32(a, 0))
                {
                    r = Avx2.mm256_sub_epi32(r, Avx2.mm256_and_si256(Xse.mm256_dec_epi32(__abs), Avx2.mm256_srai_epi32(a, 31)));
                }
                if (!promises.NotMinValue)
                {
                    v256 MIN_VALUE_I32 = Xse.mm256_set1_epi32(int.MinValue);

                    v256 divisorIsMinValMask = Avx2.mm256_cmpeq_epi32(original, MIN_VALUE_I32);

                    if (constexpr.ALL_NEQ_EPI32(a, int.MinValue) || constexpr.ALL_GT_EPI32(a, int.MinValue))
                    {
                        r = Xse.mm256_blendv_si256(r, a, divisorIsMinValMask);
                    }
                    else if (constexpr.ALL_EQ_EPI32(a, int.MinValue))
                    {
                        r = Avx2.mm256_andnot_si256(divisorIsMinValMask, r);
                    }
                    else
                    {
                        v256 dividendIsMinValMask = Avx2.mm256_cmpeq_epi32(a, MIN_VALUE_I32);

                        r = Xse.mm256_blendv_si256(r, Avx2.mm256_andnot_si256(dividendIsMinValMask, a), divisorIsMinValMask);
                    }
                }

                return r;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_msrem_epi64(v256 a, v256 mul, v256 shift, v256 original, DividerPromise promises, byte elements)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_sub_epi64(a, Xse.mm256_mullo_epi64(mm256_msdiv_epi64(a, mul, shift, original, promises, elements), original, elements));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_bmrem_epi64(v256 a, UInt128 mul0, UInt128 mul1, UInt128 mul2, UInt128 mul3, v256 original, DividerPromise promises, byte elements = 4)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 __abs = mm256_promise_abs_epi64(original, promises, elements);

                long r0 = FRONT_bmrem_i64((long)Xse.mm256_extract_epi64(a, 0), mul0, (long)Xse.mm256_extract_epi64(__abs, 0), promises);
                long r1 = FRONT_bmrem_i64((long)Xse.mm256_extract_epi64(a, 1), mul1, (long)Xse.mm256_extract_epi64(__abs, 1), promises);
                long r2 = FRONT_bmrem_i64((long)Xse.mm256_extract_epi64(a, 2), mul2, (long)Xse.mm256_extract_epi64(__abs, 2), promises);

                v128 rLo = Xse.unpacklo_epi64(Xse.cvtsi64x_si128(r0), Xse.cvtsi64x_si128(r1));
                v128 rHi = Xse.cvtsi64x_si128(r2);

                if (elements == 4)
                {
                    long r3 = FRONT_bmrem_i64((long)Xse.mm256_extract_epi64(a, 3), mul3, (long)Xse.mm256_extract_epi64(__abs, 3), promises);
                    rHi = Xse.unpacklo_epi64(rHi, Xse.cvtsi64x_si128(r3));
                }

                v256 r = Avx2.mm256_inserti128_si256(Avx.mm256_castsi128_si256(rLo), rHi, 1);

                if (!constexpr.ALL_GE_EPI64(a, 0, elements))
                {
                    r = Avx2.mm256_sub_epi64(r, Avx2.mm256_and_si256(Xse.mm256_dec_epi64(Xse.mm256_abs_epi64(original)), Xse.mm256_srai_epi64(a, 63, elements)));
                }
                if (!promises.NotMinValue)
                {
                    v256 MIN_VALUE_I64 = Xse.mm256_set1_epi64x(long.MinValue);

                    v256 divisorIsMinValMask = Avx2.mm256_cmpeq_epi64(original, MIN_VALUE_I64);

                    if (constexpr.ALL_NEQ_EPI64(a, long.MinValue, elements) || constexpr.ALL_GT_EPI64(a, long.MinValue, elements))
                    {
                        r = Xse.mm256_blendv_si256(r, a, divisorIsMinValMask);
                    }
                    else if (constexpr.ALL_EQ_EPI64(a, long.MinValue, elements))
                    {
                        r = Avx2.mm256_andnot_si256(divisorIsMinValMask, r);
                    }
                    else
                    {
                        v256 dividendIsMinValMask = Avx2.mm256_cmpeq_epi64(a, MIN_VALUE_I64);

                        r = Xse.mm256_blendv_si256(r, Avx2.mm256_andnot_si256(dividendIsMinValMask, a), divisorIsMinValMask);
                    }
                }

                return r;
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 bmrem_epi8_si8(v128 d, ushort mul, sbyte original, DividerPromise promises, byte elements = 16)
        {
            if (Architecture.IsSIMDSupported)
            {
                sbyte __abs = promise_abs_i8(original, promises);
                v128 absResult = bmrem_epu8_su8(Xse.abs_epi8(d, elements), (byte)__abs, mul, elements);

                Xse.SIGNED_FROM_UNSIGNED_DIV_EPI8(out v128 signedResult, d, Xse.set1_epi8(original, elements), default(v128), absResult, elements: elements, divisorPositive: promises.Positive, divisorNegative: promises.Negative);

                return signedResult;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 bmrem_epi16_si16(v128 d, uint mul, short original, DividerPromise promises, byte elements = 8)
        {
            if (Architecture.IsSIMDSupported)
            {
                short __abs = promise_abs_i16(original, promises);
                v128 absResult = bmrem_epu16_su16(Xse.abs_epi16(d, elements), (ushort)__abs, mul, elements);

                Xse.SIGNED_FROM_UNSIGNED_DIV_EPI16(out v128 signedResult, d, Xse.set1_epi16(original), default(v128), absResult, divisorPositive: promises.Positive, divisorNegative: promises.Negative, elements: elements);

                return signedResult;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 msrem_epi32_si32(v128 a, int mul, int shift, int original, DividerPromise promises, byte elements = 4)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.sub_epi32(a, Xse.mullo_epi32(msdiv_epi32_si32(a, mul, shift, original, promises, elements), Xse.set1_epi32(original), elements));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 bmrem_epi32_si32(v128 a, ulong mul, int original, DividerPromise promises, byte elements = 4)
        {
            if (Architecture.IsSIMDSupported)
            {
                int __abs = promise_abs_i32(original, promises);

                v128 r;
                v128 absO64 = Xse.set1_epi64x((uint)__abs);

                if (elements == 2)
                {
                    v128 d64 = Xse.cvtepi32_epi64(a);

                    r = Xse.mulhi_epi64(Xse.mullo_epi64(Xse.set1_epi64x(mul), d64), absO64);
                    r = Xse.cvtepi64_epi32(r);
                }
                else
                {
                    v128 d16Lo = Xse.cvt2x2epi32_epi64(a, out v128 d16Hi);

                    v128 rLo = Xse.mulhi_epi64(Xse.mullo_epi64(Xse.set1_epi64x(mul), d16Lo), absO64);
                    v128 rHi = Xse.mulhi_epi64(Xse.mullo_epi64(Xse.set1_epi64x(mul), d16Hi), absO64);
                    r = Xse.cvt2x2epi64_epi32(rLo, rHi);
                }

                if (!constexpr.ALL_GE_EPI32(a, 0))
                {
                    r = Xse.sub_epi32(r, Xse.and_si128(Xse.dec_epi32(Xse.set1_epi32(__abs)), Xse.srai_epi32(a, 31)));
                }
                if (!promises.NotMinValue)
                {
                    if (constexpr.ALL_NEQ_EPI32(a, int.MinValue))
                    {
                        if (original == int.MinValue)
                        {
                            r = a;
                        }
                    }
                    else if (constexpr.ALL_EQ_EPI32(a, int.MinValue))
                    {
                        if (original == int.MinValue)
                        {
                            r = Xse.neg_epi32(r);
                        }
                    }
                    else
                    {
                        if (original == int.MinValue)
                        {
                            r = Xse.andnot_si128(Xse.cmpeq_epi32(a, Xse.set1_epi32(int.MinValue)), a);
                        }
                    }
                }

                return r;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 bmrem_epi64_si64(v128 a, UInt128 mul, long original, DividerPromise promises)
        {
            if (Architecture.IsSIMDSupported)
            {
                long __abs = promise_abs_i64(original, promises);

                long r0 = FRONT_bmrem_i64((long)Xse.extract_epi64(a, 0), mul, __abs, promises);
                long r1 = FRONT_bmrem_i64((long)Xse.extract_epi64(a, 1), mul, __abs, promises);

                v128 r = Xse.unpacklo_epi64(Xse.cvtsi64x_si128(r0), Xse.cvtsi64x_si128(r1));

                if (!constexpr.ALL_GE_EPI64(a, 0))
                {
                    r = Xse.sub_epi64(r, Xse.and_si128(Xse.dec_epi64(Xse.set1_epi64x(__abs)), Xse.srai_epi64(a, 63)));
                }
                if (!promises.NotMinValue)
                {
                    if (constexpr.ALL_NEQ_EPI64(a, long.MinValue))
                    {
                        if (original == long.MinValue)
                        {
                            r = a;
                        }
                    }
                    else if (constexpr.ALL_EQ_EPI64(a, long.MinValue))
                    {
                        if (original == long.MinValue)
                        {
                            r = Xse.neg_epi64(r);
                        }
                    }
                    else
                    {
                        if (original == long.MinValue)
                        {
                            r = Xse.andnot_si128(Xse.cmpeq_epi64(a, Xse.set1_epi64x(long.MinValue)), a);
                        }
                    }
                }

                return r;
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_bmrem_epi8_si8(v256 d, ushort mul, sbyte original, DividerPromise promises)
        {
            if (Architecture.IsSIMDSupported)
            {
                sbyte __abs = promise_abs_i8(original, promises);
                v256 absResult = mm256_bmrem_epu8_su8(Xse.mm256_abs_epi8(d), (byte)__abs, mul);

                Xse.SIGNED_FROM_UNSIGNED_DIV_EPI8(out v256 signedResult, d, Xse.mm256_set1_epi8(original), default(v256), absResult, divisorPositive: promises.Positive, divisorNegative: promises.Negative);

                return signedResult;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_bmrem_epi16_si16(v256 d, uint mul, short original, DividerPromise promises)
        {
            if (Architecture.IsSIMDSupported)
            {
                short __abs = promise_abs_i16(original, promises);
                v256 absResult = mm256_bmrem_epu16_su16(Xse.mm256_abs_epi16(d), (ushort)__abs, mul);

                Xse.SIGNED_FROM_UNSIGNED_DIV_EPI16(out v256 signedResult, d, Xse.mm256_set1_epi16(original), default(v256), absResult, divisorPositive: promises.Positive, divisorNegative: promises.Negative);

                return signedResult;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_bmrem_epi32_si32(v256 a, ulong mul, int original, DividerPromise promises)
        {
            if (Avx2.IsAvx2Supported)
            {
                int __abs = promise_abs_i32(original, promises);

                v256 r;

                v256 d16Lo = Xse.mm256_cvt2x2epi32_epi64(a, out v256 d16Hi);
                v256 absO = Xse.mm256_set1_epi64x(__abs);

                v256 rLo = Xse.mm256_mulhi_epi64(Xse.mm256_mullo_epi64(Xse.mm256_set1_epi64x(mul), d16Lo), absO);
                v256 rHi = Xse.mm256_mulhi_epi64(Xse.mm256_mullo_epi64(Xse.mm256_set1_epi64x(mul), d16Hi), absO);
                r = Xse.mm256_cvt2x2epi64_epi32(rLo, rHi);

                if (!constexpr.ALL_GE_EPI32(a, 0))
                {
                    r = Avx2.mm256_sub_epi32(r, Avx2.mm256_and_si256(Xse.mm256_dec_epi32(absO), Xse.mm256_srai_epi32(a, 31)));
                }
                if (!promises.NotMinValue)
                {
                    if (constexpr.ALL_NEQ_EPI32(a, int.MinValue) || constexpr.ALL_GT_EPI32(a, int.MinValue))
                    {
                        if (original == int.MinValue)
                        {
                            r = a;
                        }
                    }
                    else if (constexpr.ALL_EQ_EPI32(a, int.MinValue))
                    {
                        if (original == int.MinValue)
                        {
                            r = Xse.mm256_neg_epi32(r);
                        }
                    }
                    else
                    {
                        if (original == int.MinValue)
                        {
                            r = Avx2.mm256_andnot_si256(Avx2.mm256_cmpeq_epi32(a, Xse.mm256_set1_epi32(int.MinValue)), a);
                        }
                    }
                }

                return r;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_bmrem_epi64_si64(v256 a, UInt128 mul, long original, DividerPromise promises, byte elements = 4)
        {
            if (Avx2.IsAvx2Supported)
            {
                long __abs = promise_abs_i64(original, promises);

                long r0 = FRONT_bmrem_i64((long)Xse.mm256_extract_epi64(a, 0), mul, __abs, promises);
                long r1 = FRONT_bmrem_i64((long)Xse.mm256_extract_epi64(a, 1), mul, __abs, promises);
                long r2 = FRONT_bmrem_i64((long)Xse.mm256_extract_epi64(a, 2), mul, __abs, promises);

                v128 rLo = Xse.unpacklo_epi64(Xse.cvtsi64x_si128(r0), Xse.cvtsi64x_si128(r1));
                v128 rHi = Xse.cvtsi64x_si128(r2);

                if (elements == 4)
                {
                    long r3 = FRONT_bmrem_i64((long)Xse.mm256_extract_epi64(a, 3), mul, __abs, promises);
                    rHi = Xse.unpacklo_epi64(rHi, Xse.cvtsi64x_si128(r3));
                }

                v256 r = Avx2.mm256_inserti128_si256(Avx.mm256_castsi128_si256(rLo), rHi, 1);

                if (!constexpr.ALL_GE_EPI64(a, 0, elements))
                {
                    r = Avx2.mm256_sub_epi64(r, Avx2.mm256_and_si256(Xse.mm256_set1_epi64x(__abs), Xse.mm256_srai_epi64(a, 63, elements)));
                }
                if (!promises.NotMinValue)
                {
                    if (constexpr.ALL_NEQ_EPI64(a, long.MinValue, elements) || constexpr.ALL_GT_EPI64(a, long.MinValue, elements))
                    {
                        if (original == long.MinValue)
                        {
                            r = a;
                        }
                    }
                    else if (constexpr.ALL_EQ_EPI64(a, long.MinValue, elements))
                    {
                        if (original == long.MinValue)
                        {
                            r = Xse.mm256_neg_epi64(r);
                        }
                    }
                    else
                    {
                        if (original == long.MinValue)
                        {
                            r = Avx2.mm256_andnot_si256(Avx2.mm256_cmpeq_epi64(a, Xse.mm256_set1_epi64x(long.MinValue)), a);
                        }
                    }
                }

                return r;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_msrem_epi32_si32(v256 a, int mul, int shift, int original, DividerPromise promises)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_sub_epi32(a, Avx2.mm256_mullo_epi32(mm256_msdiv_epi32_si32(a, mul, shift, original, promises), Xse.mm256_set1_epi32(original)));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_msrem_epi64_si64(v256 a, long mul, long shift, long original, DividerPromise promises, byte elements = 4)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_sub_epi64(a, Xse.mm256_mullo_epi64(mm256_msdiv_epi64_si64(a, mul, shift, original, promises, elements), Xse.mm256_set1_epi64x(original), elements));
            }
            else throw new IllegalInstructionException();
        }
    }
}
