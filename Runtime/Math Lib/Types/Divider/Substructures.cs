using System;
using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;
using MaxMath.Intrinsics;
using DevTools;

using static Unity.Burst.Intrinsics.X86;
using static MaxMath.maxmath;

namespace MaxMath
{
    unsafe public static partial class Extensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Divider<T> CreateFromData<T>(T divisor, T mulLo, T mulHi, T mul, T shift, byte elementSize, byte elementCount, Signedness sign, Promise promises)
            where T : unmanaged, IEquatable<T>, IFormattable
        {
            Divider<T> res = new Divider<T>(divisor, promises, sign, elementSize);

            res._bigM._mulLo = mulLo;
            res._bigM._mulHi = mulHi;
            res._mulShift._mul = mul;
            res._mulShift._shift = shift;
#if DEBUG
res._typeInfo = new TypeInfo(elementSize, elementCount, columnCount: 1, sign, NumericDataType.Integer);
#endif
            return res;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Divider<T> GetInnerDivider8Base<T>(Divider<byte32> Divider, int index, Signedness sign)
            where T : unmanaged, IEquatable<T>, IFormattable
        {
Assert.IsWithinArrayBounds(index, 33 - sizeof(T) / sizeof(byte));

            switch (sizeof(T))
            {
                case 1 * sizeof(byte):
                {
                    return CreateFromData(Divider.Divisor[index], ((byte*)&Divider._bigM._mulLo)[2 * index], ((byte*)&Divider._bigM._mulLo)[2 * index + 1], Uninitialized<byte>.Create(), Uninitialized<byte>.Create(),  sizeof(byte), 1, sign, Divider._promises).Reinterpret<Divider<byte>, Divider<T>>();
                }
                case 2 * sizeof(byte):
                {
                    if (constexpr.IS_CONST(index))
                    {
                        switch (index)
                        {
                            case 0:  return CreateFromData(Divider.Divisor.v2_0,  *(byte2*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte2*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte2>.Create(), Uninitialized<byte2>.Create(), sizeof(byte), 2, sign, Divider._promises).Reinterpret<Divider<byte2>, Divider<T>>();
                            case 1:  return CreateFromData(Divider.Divisor.v2_1,  *(byte2*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte2*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte2>.Create(), Uninitialized<byte2>.Create(), sizeof(byte), 2, sign, Divider._promises).Reinterpret<Divider<byte2>, Divider<T>>();
                            case 2:  return CreateFromData(Divider.Divisor.v2_2,  *(byte2*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte2*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte2>.Create(), Uninitialized<byte2>.Create(), sizeof(byte), 2, sign, Divider._promises).Reinterpret<Divider<byte2>, Divider<T>>();
                            case 3:  return CreateFromData(Divider.Divisor.v2_3,  *(byte2*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte2*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte2>.Create(), Uninitialized<byte2>.Create(), sizeof(byte), 2, sign, Divider._promises).Reinterpret<Divider<byte2>, Divider<T>>();
                            case 4:  return CreateFromData(Divider.Divisor.v2_4,  *(byte2*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte2*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte2>.Create(), Uninitialized<byte2>.Create(), sizeof(byte), 2, sign, Divider._promises).Reinterpret<Divider<byte2>, Divider<T>>();
                            case 5:  return CreateFromData(Divider.Divisor.v2_5,  *(byte2*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte2*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte2>.Create(), Uninitialized<byte2>.Create(), sizeof(byte), 2, sign, Divider._promises).Reinterpret<Divider<byte2>, Divider<T>>();
                            case 6:  return CreateFromData(Divider.Divisor.v2_6,  *(byte2*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte2*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte2>.Create(), Uninitialized<byte2>.Create(), sizeof(byte), 2, sign, Divider._promises).Reinterpret<Divider<byte2>, Divider<T>>();
                            case 7:  return CreateFromData(Divider.Divisor.v2_7,  *(byte2*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte2*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte2>.Create(), Uninitialized<byte2>.Create(), sizeof(byte), 2, sign, Divider._promises).Reinterpret<Divider<byte2>, Divider<T>>();
                            case 8:  return CreateFromData(Divider.Divisor.v2_8,  *(byte2*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte2*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte2>.Create(), Uninitialized<byte2>.Create(), sizeof(byte), 2, sign, Divider._promises).Reinterpret<Divider<byte2>, Divider<T>>();
                            case 9:  return CreateFromData(Divider.Divisor.v2_9,  *(byte2*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte2*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte2>.Create(), Uninitialized<byte2>.Create(), sizeof(byte), 2, sign, Divider._promises).Reinterpret<Divider<byte2>, Divider<T>>();
                            case 10: return CreateFromData(Divider.Divisor.v2_10, *(byte2*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte2*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte2>.Create(), Uninitialized<byte2>.Create(), sizeof(byte), 2, sign, Divider._promises).Reinterpret<Divider<byte2>, Divider<T>>();
                            case 11: return CreateFromData(Divider.Divisor.v2_11, *(byte2*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte2*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte2>.Create(), Uninitialized<byte2>.Create(), sizeof(byte), 2, sign, Divider._promises).Reinterpret<Divider<byte2>, Divider<T>>();
                            case 12: return CreateFromData(Divider.Divisor.v2_12, *(byte2*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte2*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte2>.Create(), Uninitialized<byte2>.Create(), sizeof(byte), 2, sign, Divider._promises).Reinterpret<Divider<byte2>, Divider<T>>();
                            case 13: return CreateFromData(Divider.Divisor.v2_13, *(byte2*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte2*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte2>.Create(), Uninitialized<byte2>.Create(), sizeof(byte), 2, sign, Divider._promises).Reinterpret<Divider<byte2>, Divider<T>>();
                            case 14: return CreateFromData(Divider.Divisor.v2_14, *(byte2*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte2*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte2>.Create(), Uninitialized<byte2>.Create(), sizeof(byte), 2, sign, Divider._promises).Reinterpret<Divider<byte2>, Divider<T>>();
                            case 15: return CreateFromData(Divider.Divisor.v2_15, *(byte2*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte2*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte2>.Create(), Uninitialized<byte2>.Create(), sizeof(byte), 2, sign, Divider._promises).Reinterpret<Divider<byte2>, Divider<T>>();
                            case 16: return CreateFromData(Divider.Divisor.v2_16, *(byte2*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte2*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte2>.Create(), Uninitialized<byte2>.Create(), sizeof(byte), 2, sign, Divider._promises).Reinterpret<Divider<byte2>, Divider<T>>();
                            case 17: return CreateFromData(Divider.Divisor.v2_17, *(byte2*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte2*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte2>.Create(), Uninitialized<byte2>.Create(), sizeof(byte), 2, sign, Divider._promises).Reinterpret<Divider<byte2>, Divider<T>>();
                            case 18: return CreateFromData(Divider.Divisor.v2_18, *(byte2*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte2*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte2>.Create(), Uninitialized<byte2>.Create(), sizeof(byte), 2, sign, Divider._promises).Reinterpret<Divider<byte2>, Divider<T>>();
                            case 19: return CreateFromData(Divider.Divisor.v2_19, *(byte2*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte2*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte2>.Create(), Uninitialized<byte2>.Create(), sizeof(byte), 2, sign, Divider._promises).Reinterpret<Divider<byte2>, Divider<T>>();
                            case 20: return CreateFromData(Divider.Divisor.v2_20, *(byte2*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte2*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte2>.Create(), Uninitialized<byte2>.Create(), sizeof(byte), 2, sign, Divider._promises).Reinterpret<Divider<byte2>, Divider<T>>();
                            case 21: return CreateFromData(Divider.Divisor.v2_21, *(byte2*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte2*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte2>.Create(), Uninitialized<byte2>.Create(), sizeof(byte), 2, sign, Divider._promises).Reinterpret<Divider<byte2>, Divider<T>>();
                            case 22: return CreateFromData(Divider.Divisor.v2_22, *(byte2*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte2*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte2>.Create(), Uninitialized<byte2>.Create(), sizeof(byte), 2, sign, Divider._promises).Reinterpret<Divider<byte2>, Divider<T>>();
                            case 23: return CreateFromData(Divider.Divisor.v2_23, *(byte2*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte2*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte2>.Create(), Uninitialized<byte2>.Create(), sizeof(byte), 2, sign, Divider._promises).Reinterpret<Divider<byte2>, Divider<T>>();
                            case 24: return CreateFromData(Divider.Divisor.v2_24, *(byte2*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte2*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte2>.Create(), Uninitialized<byte2>.Create(), sizeof(byte), 2, sign, Divider._promises).Reinterpret<Divider<byte2>, Divider<T>>();
                            case 25: return CreateFromData(Divider.Divisor.v2_25, *(byte2*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte2*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte2>.Create(), Uninitialized<byte2>.Create(), sizeof(byte), 2, sign, Divider._promises).Reinterpret<Divider<byte2>, Divider<T>>();
                            case 26: return CreateFromData(Divider.Divisor.v2_26, *(byte2*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte2*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte2>.Create(), Uninitialized<byte2>.Create(), sizeof(byte), 2, sign, Divider._promises).Reinterpret<Divider<byte2>, Divider<T>>();
                            case 27: return CreateFromData(Divider.Divisor.v2_27, *(byte2*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte2*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte2>.Create(), Uninitialized<byte2>.Create(), sizeof(byte), 2, sign, Divider._promises).Reinterpret<Divider<byte2>, Divider<T>>();
                            case 28: return CreateFromData(Divider.Divisor.v2_28, *(byte2*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte2*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte2>.Create(), Uninitialized<byte2>.Create(), sizeof(byte), 2, sign, Divider._promises).Reinterpret<Divider<byte2>, Divider<T>>();
                            case 29: return CreateFromData(Divider.Divisor.v2_29, *(byte2*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte2*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte2>.Create(), Uninitialized<byte2>.Create(), sizeof(byte), 2, sign, Divider._promises).Reinterpret<Divider<byte2>, Divider<T>>();
                            case 30: return CreateFromData(Divider.Divisor.v2_30, *(byte2*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte2*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte2>.Create(), Uninitialized<byte2>.Create(), sizeof(byte), 2, sign, Divider._promises).Reinterpret<Divider<byte2>, Divider<T>>();

                            default: throw Assert.Unreachable();
                        }
                    }
                    else
                    {
                        if (Avx2.IsAvx2Supported)
                        {
                            return CreateFromData((byte2)Avx.mm256_castsi256_si128(Xse.mm256_bsrli_si256(Divider.Divisor, sizeof(byte) * index)),
                                                  *(byte2*)((byte*)&Divider._bigM._mulLo  + 2 * index),
                                                  *((byte2*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1),
                                                  Uninitialized<byte2>.Create(),
                                                  Uninitialized<byte2>.Create(),
                                                  sizeof(byte),
                                                  2,
                                                  sign,
                                                  Divider._promises).Reinterpret<Divider<byte2>, Divider<T>>();
                        }
                        else
                        {
                            return CreateFromData(*(byte2*)((byte*)&Divider._divisor + index),
                                                  *(byte2*)((byte*)&Divider._bigM._mulLo  + 2 * index),
                                                  *((byte2*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1),
                                                  Uninitialized<byte2>.Create(),
                                                  Uninitialized<byte2>.Create(),
                                                  sizeof(byte),
                                                  2,
                                                  sign,
                                                  Divider._promises).Reinterpret<Divider<byte2>, Divider<T>>();
                        }
                    }
                }
                case 3 * sizeof(byte):
                {
                    if (constexpr.IS_CONST(index))
                    {
                        switch (index)
                        {
                            case 0:  return CreateFromData(Divider.Divisor.v3_0,  *(byte3*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte3*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte3>.Create(), Uninitialized<byte3>.Create(),  sizeof(byte), 3, sign, Divider._promises).Reinterpret<Divider<byte3>, Divider<T>>();
                            case 1:  return CreateFromData(Divider.Divisor.v3_1,  *(byte3*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte3*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte3>.Create(), Uninitialized<byte3>.Create(),  sizeof(byte), 3, sign, Divider._promises).Reinterpret<Divider<byte3>, Divider<T>>();
                            case 2:  return CreateFromData(Divider.Divisor.v3_2,  *(byte3*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte3*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte3>.Create(), Uninitialized<byte3>.Create(),  sizeof(byte), 3, sign, Divider._promises).Reinterpret<Divider<byte3>, Divider<T>>();
                            case 3:  return CreateFromData(Divider.Divisor.v3_3,  *(byte3*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte3*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte3>.Create(), Uninitialized<byte3>.Create(),  sizeof(byte), 3, sign, Divider._promises).Reinterpret<Divider<byte3>, Divider<T>>();
                            case 4:  return CreateFromData(Divider.Divisor.v3_4,  *(byte3*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte3*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte3>.Create(), Uninitialized<byte3>.Create(),  sizeof(byte), 3, sign, Divider._promises).Reinterpret<Divider<byte3>, Divider<T>>();
                            case 5:  return CreateFromData(Divider.Divisor.v3_5,  *(byte3*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte3*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte3>.Create(), Uninitialized<byte3>.Create(),  sizeof(byte), 3, sign, Divider._promises).Reinterpret<Divider<byte3>, Divider<T>>();
                            case 6:  return CreateFromData(Divider.Divisor.v3_6,  *(byte3*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte3*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte3>.Create(), Uninitialized<byte3>.Create(),  sizeof(byte), 3, sign, Divider._promises).Reinterpret<Divider<byte3>, Divider<T>>();
                            case 7:  return CreateFromData(Divider.Divisor.v3_7,  *(byte3*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte3*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte3>.Create(), Uninitialized<byte3>.Create(),  sizeof(byte), 3, sign, Divider._promises).Reinterpret<Divider<byte3>, Divider<T>>();
                            case 8:  return CreateFromData(Divider.Divisor.v3_8,  *(byte3*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte3*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte3>.Create(), Uninitialized<byte3>.Create(),  sizeof(byte), 3, sign, Divider._promises).Reinterpret<Divider<byte3>, Divider<T>>();
                            case 9:  return CreateFromData(Divider.Divisor.v3_9,  *(byte3*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte3*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte3>.Create(), Uninitialized<byte3>.Create(),  sizeof(byte), 3, sign, Divider._promises).Reinterpret<Divider<byte3>, Divider<T>>();
                            case 10: return CreateFromData(Divider.Divisor.v3_10, *(byte3*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte3*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte3>.Create(), Uninitialized<byte3>.Create(),  sizeof(byte), 3, sign, Divider._promises).Reinterpret<Divider<byte3>, Divider<T>>();
                            case 11: return CreateFromData(Divider.Divisor.v3_11, *(byte3*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte3*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte3>.Create(), Uninitialized<byte3>.Create(),  sizeof(byte), 3, sign, Divider._promises).Reinterpret<Divider<byte3>, Divider<T>>();
                            case 12: return CreateFromData(Divider.Divisor.v3_12, *(byte3*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte3*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte3>.Create(), Uninitialized<byte3>.Create(),  sizeof(byte), 3, sign, Divider._promises).Reinterpret<Divider<byte3>, Divider<T>>();
                            case 13: return CreateFromData(Divider.Divisor.v3_13, *(byte3*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte3*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte3>.Create(), Uninitialized<byte3>.Create(),  sizeof(byte), 3, sign, Divider._promises).Reinterpret<Divider<byte3>, Divider<T>>();
                            case 14: return CreateFromData(Divider.Divisor.v3_14, *(byte3*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte3*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte3>.Create(), Uninitialized<byte3>.Create(),  sizeof(byte), 3, sign, Divider._promises).Reinterpret<Divider<byte3>, Divider<T>>();
                            case 15: return CreateFromData(Divider.Divisor.v3_15, *(byte3*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte3*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte3>.Create(), Uninitialized<byte3>.Create(),  sizeof(byte), 3, sign, Divider._promises).Reinterpret<Divider<byte3>, Divider<T>>();
                            case 16: return CreateFromData(Divider.Divisor.v3_16, *(byte3*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte3*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte3>.Create(), Uninitialized<byte3>.Create(),  sizeof(byte), 3, sign, Divider._promises).Reinterpret<Divider<byte3>, Divider<T>>();
                            case 17: return CreateFromData(Divider.Divisor.v3_17, *(byte3*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte3*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte3>.Create(), Uninitialized<byte3>.Create(),  sizeof(byte), 3, sign, Divider._promises).Reinterpret<Divider<byte3>, Divider<T>>();
                            case 18: return CreateFromData(Divider.Divisor.v3_18, *(byte3*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte3*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte3>.Create(), Uninitialized<byte3>.Create(),  sizeof(byte), 3, sign, Divider._promises).Reinterpret<Divider<byte3>, Divider<T>>();
                            case 19: return CreateFromData(Divider.Divisor.v3_19, *(byte3*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte3*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte3>.Create(), Uninitialized<byte3>.Create(),  sizeof(byte), 3, sign, Divider._promises).Reinterpret<Divider<byte3>, Divider<T>>();
                            case 20: return CreateFromData(Divider.Divisor.v3_20, *(byte3*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte3*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte3>.Create(), Uninitialized<byte3>.Create(),  sizeof(byte), 3, sign, Divider._promises).Reinterpret<Divider<byte3>, Divider<T>>();
                            case 21: return CreateFromData(Divider.Divisor.v3_21, *(byte3*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte3*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte3>.Create(), Uninitialized<byte3>.Create(),  sizeof(byte), 3, sign, Divider._promises).Reinterpret<Divider<byte3>, Divider<T>>();
                            case 22: return CreateFromData(Divider.Divisor.v3_22, *(byte3*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte3*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte3>.Create(), Uninitialized<byte3>.Create(),  sizeof(byte), 3, sign, Divider._promises).Reinterpret<Divider<byte3>, Divider<T>>();
                            case 23: return CreateFromData(Divider.Divisor.v3_23, *(byte3*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte3*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte3>.Create(), Uninitialized<byte3>.Create(),  sizeof(byte), 3, sign, Divider._promises).Reinterpret<Divider<byte3>, Divider<T>>();
                            case 24: return CreateFromData(Divider.Divisor.v3_24, *(byte3*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte3*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte3>.Create(), Uninitialized<byte3>.Create(),  sizeof(byte), 3, sign, Divider._promises).Reinterpret<Divider<byte3>, Divider<T>>();
                            case 25: return CreateFromData(Divider.Divisor.v3_25, *(byte3*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte3*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte3>.Create(), Uninitialized<byte3>.Create(),  sizeof(byte), 3, sign, Divider._promises).Reinterpret<Divider<byte3>, Divider<T>>();
                            case 26: return CreateFromData(Divider.Divisor.v3_26, *(byte3*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte3*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte3>.Create(), Uninitialized<byte3>.Create(),  sizeof(byte), 3, sign, Divider._promises).Reinterpret<Divider<byte3>, Divider<T>>();
                            case 27: return CreateFromData(Divider.Divisor.v3_27, *(byte3*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte3*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte3>.Create(), Uninitialized<byte3>.Create(),  sizeof(byte), 3, sign, Divider._promises).Reinterpret<Divider<byte3>, Divider<T>>();
                            case 28: return CreateFromData(Divider.Divisor.v3_28, *(byte3*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte3*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte3>.Create(), Uninitialized<byte3>.Create(),  sizeof(byte), 3, sign, Divider._promises).Reinterpret<Divider<byte3>, Divider<T>>();
                            case 29: return CreateFromData(Divider.Divisor.v3_29, *(byte3*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte3*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte3>.Create(), Uninitialized<byte3>.Create(),  sizeof(byte), 3, sign, Divider._promises).Reinterpret<Divider<byte3>, Divider<T>>();

                            default: throw Assert.Unreachable();
                        }
                    }
                    else
                    {
                        if (Avx2.IsAvx2Supported)
                        {
                            return CreateFromData((byte3)Avx.mm256_castsi256_si128(Xse.mm256_bsrli_si256(Divider.Divisor, sizeof(byte) * index)),
                                                  *(byte3*)((byte*)&Divider._bigM._mulLo  + 2 * index),
                                                  *((byte3*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1),
                                                  Uninitialized<byte3>.Create(),
                                                  Uninitialized<byte3>.Create(),
                                                  sizeof(byte),
                                                  3,
                                                  sign,
                                                  Divider._promises).Reinterpret<Divider<byte3>, Divider<T>>();
                        }
                        else
                        {
                            return CreateFromData(*(byte3*)((byte*)&Divider._divisor + index),
                                                  *(byte3*)((byte*)&Divider._bigM._mulLo  + 2 * index),
                                                  *((byte3*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1),
                                                  Uninitialized<byte3>.Create(),
                                                  Uninitialized<byte3>.Create(),
                                                  sizeof(byte),
                                                  3,
                                                  sign,
                                                  Divider._promises).Reinterpret<Divider<byte3>, Divider<T>>();
                        }
                    }
                }
                case 4 * sizeof(byte):
                {
                    if (constexpr.IS_CONST(index))
                    {
                        switch (index)
                        {
                            case 0:  return CreateFromData(Divider.Divisor.v4_0,  *(byte4*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte4*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte4>.Create(), Uninitialized<byte4>.Create(),  sizeof(byte), 4, sign, Divider._promises).Reinterpret<Divider<byte4>, Divider<T>>();
                            case 1:  return CreateFromData(Divider.Divisor.v4_1,  *(byte4*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte4*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte4>.Create(), Uninitialized<byte4>.Create(),  sizeof(byte), 4, sign, Divider._promises).Reinterpret<Divider<byte4>, Divider<T>>();
                            case 2:  return CreateFromData(Divider.Divisor.v4_2,  *(byte4*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte4*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte4>.Create(), Uninitialized<byte4>.Create(),  sizeof(byte), 4, sign, Divider._promises).Reinterpret<Divider<byte4>, Divider<T>>();
                            case 3:  return CreateFromData(Divider.Divisor.v4_3,  *(byte4*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte4*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte4>.Create(), Uninitialized<byte4>.Create(),  sizeof(byte), 4, sign, Divider._promises).Reinterpret<Divider<byte4>, Divider<T>>();
                            case 4:  return CreateFromData(Divider.Divisor.v4_4,  *(byte4*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte4*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte4>.Create(), Uninitialized<byte4>.Create(),  sizeof(byte), 4, sign, Divider._promises).Reinterpret<Divider<byte4>, Divider<T>>();
                            case 5:  return CreateFromData(Divider.Divisor.v4_5,  *(byte4*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte4*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte4>.Create(), Uninitialized<byte4>.Create(),  sizeof(byte), 4, sign, Divider._promises).Reinterpret<Divider<byte4>, Divider<T>>();
                            case 6:  return CreateFromData(Divider.Divisor.v4_6,  *(byte4*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte4*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte4>.Create(), Uninitialized<byte4>.Create(),  sizeof(byte), 4, sign, Divider._promises).Reinterpret<Divider<byte4>, Divider<T>>();
                            case 7:  return CreateFromData(Divider.Divisor.v4_7,  *(byte4*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte4*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte4>.Create(), Uninitialized<byte4>.Create(),  sizeof(byte), 4, sign, Divider._promises).Reinterpret<Divider<byte4>, Divider<T>>();
                            case 8:  return CreateFromData(Divider.Divisor.v4_8,  *(byte4*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte4*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte4>.Create(), Uninitialized<byte4>.Create(),  sizeof(byte), 4, sign, Divider._promises).Reinterpret<Divider<byte4>, Divider<T>>();
                            case 9:  return CreateFromData(Divider.Divisor.v4_9,  *(byte4*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte4*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte4>.Create(), Uninitialized<byte4>.Create(),  sizeof(byte), 4, sign, Divider._promises).Reinterpret<Divider<byte4>, Divider<T>>();
                            case 10: return CreateFromData(Divider.Divisor.v4_10, *(byte4*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte4*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte4>.Create(), Uninitialized<byte4>.Create(),  sizeof(byte), 4, sign, Divider._promises).Reinterpret<Divider<byte4>, Divider<T>>();
                            case 11: return CreateFromData(Divider.Divisor.v4_11, *(byte4*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte4*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte4>.Create(), Uninitialized<byte4>.Create(),  sizeof(byte), 4, sign, Divider._promises).Reinterpret<Divider<byte4>, Divider<T>>();
                            case 12: return CreateFromData(Divider.Divisor.v4_12, *(byte4*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte4*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte4>.Create(), Uninitialized<byte4>.Create(),  sizeof(byte), 4, sign, Divider._promises).Reinterpret<Divider<byte4>, Divider<T>>();
                            case 13: return CreateFromData(Divider.Divisor.v4_13, *(byte4*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte4*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte4>.Create(), Uninitialized<byte4>.Create(),  sizeof(byte), 4, sign, Divider._promises).Reinterpret<Divider<byte4>, Divider<T>>();
                            case 14: return CreateFromData(Divider.Divisor.v4_14, *(byte4*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte4*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte4>.Create(), Uninitialized<byte4>.Create(),  sizeof(byte), 4, sign, Divider._promises).Reinterpret<Divider<byte4>, Divider<T>>();
                            case 15: return CreateFromData(Divider.Divisor.v4_15, *(byte4*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte4*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte4>.Create(), Uninitialized<byte4>.Create(),  sizeof(byte), 4, sign, Divider._promises).Reinterpret<Divider<byte4>, Divider<T>>();
                            case 16: return CreateFromData(Divider.Divisor.v4_16, *(byte4*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte4*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte4>.Create(), Uninitialized<byte4>.Create(),  sizeof(byte), 4, sign, Divider._promises).Reinterpret<Divider<byte4>, Divider<T>>();
                            case 17: return CreateFromData(Divider.Divisor.v4_17, *(byte4*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte4*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte4>.Create(), Uninitialized<byte4>.Create(),  sizeof(byte), 4, sign, Divider._promises).Reinterpret<Divider<byte4>, Divider<T>>();
                            case 18: return CreateFromData(Divider.Divisor.v4_18, *(byte4*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte4*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte4>.Create(), Uninitialized<byte4>.Create(),  sizeof(byte), 4, sign, Divider._promises).Reinterpret<Divider<byte4>, Divider<T>>();
                            case 19: return CreateFromData(Divider.Divisor.v4_19, *(byte4*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte4*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte4>.Create(), Uninitialized<byte4>.Create(),  sizeof(byte), 4, sign, Divider._promises).Reinterpret<Divider<byte4>, Divider<T>>();
                            case 20: return CreateFromData(Divider.Divisor.v4_20, *(byte4*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte4*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte4>.Create(), Uninitialized<byte4>.Create(),  sizeof(byte), 4, sign, Divider._promises).Reinterpret<Divider<byte4>, Divider<T>>();
                            case 21: return CreateFromData(Divider.Divisor.v4_21, *(byte4*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte4*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte4>.Create(), Uninitialized<byte4>.Create(),  sizeof(byte), 4, sign, Divider._promises).Reinterpret<Divider<byte4>, Divider<T>>();
                            case 22: return CreateFromData(Divider.Divisor.v4_22, *(byte4*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte4*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte4>.Create(), Uninitialized<byte4>.Create(),  sizeof(byte), 4, sign, Divider._promises).Reinterpret<Divider<byte4>, Divider<T>>();
                            case 23: return CreateFromData(Divider.Divisor.v4_23, *(byte4*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte4*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte4>.Create(), Uninitialized<byte4>.Create(),  sizeof(byte), 4, sign, Divider._promises).Reinterpret<Divider<byte4>, Divider<T>>();
                            case 24: return CreateFromData(Divider.Divisor.v4_24, *(byte4*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte4*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte4>.Create(), Uninitialized<byte4>.Create(),  sizeof(byte), 4, sign, Divider._promises).Reinterpret<Divider<byte4>, Divider<T>>();
                            case 25: return CreateFromData(Divider.Divisor.v4_25, *(byte4*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte4*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte4>.Create(), Uninitialized<byte4>.Create(),  sizeof(byte), 4, sign, Divider._promises).Reinterpret<Divider<byte4>, Divider<T>>();
                            case 26: return CreateFromData(Divider.Divisor.v4_26, *(byte4*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte4*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte4>.Create(), Uninitialized<byte4>.Create(),  sizeof(byte), 4, sign, Divider._promises).Reinterpret<Divider<byte4>, Divider<T>>();
                            case 27: return CreateFromData(Divider.Divisor.v4_27, *(byte4*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte4*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte4>.Create(), Uninitialized<byte4>.Create(),  sizeof(byte), 4, sign, Divider._promises).Reinterpret<Divider<byte4>, Divider<T>>();
                            case 28: return CreateFromData(Divider.Divisor.v4_28, *(byte4*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte4*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte4>.Create(), Uninitialized<byte4>.Create(),  sizeof(byte), 4, sign, Divider._promises).Reinterpret<Divider<byte4>, Divider<T>>();

                            default: throw Assert.Unreachable();
                        }
                    }
                    else
                    {
                        if (Avx2.IsAvx2Supported)
                        {
                            return CreateFromData((byte4)Avx.mm256_castsi256_si128(Xse.mm256_bsrli_si256(Divider.Divisor, sizeof(byte) * index)),
                                                  *(byte4*)((byte*)&Divider._bigM._mulLo  + 2 * index),
                                                  *((byte4*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1),
                                                  Uninitialized<byte4>.Create(),
                                                  Uninitialized<byte4>.Create(),
                                                  sizeof(byte),
                                                  4,
                                                  sign,
                                                  Divider._promises).Reinterpret<Divider<byte4>, Divider<T>>();
                        }
                        else
                        {
                            return CreateFromData(*(byte4*)((byte*)&Divider._divisor + index),
                                                  *(byte4*)((byte*)&Divider._bigM._mulLo  + 2 * index),
                                                  *((byte4*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1),
                                                  Uninitialized<byte4>.Create(),
                                                  Uninitialized<byte4>.Create(),
                                                  sizeof(byte),
                                                  4,
                                                  sign,
                                                  Divider._promises).Reinterpret<Divider<byte4>, Divider<T>>();
                        }
                    }
                }
                case 8 * sizeof(byte):
                {
                    if (constexpr.IS_CONST(index))
                    {
                        switch (index)
                        {
                            case 0:  return CreateFromData(Divider.Divisor.v8_0,   *(byte8*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte8*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte8>.Create(), Uninitialized<byte8>.Create(),  sizeof(byte), 8, sign, Divider._promises).Reinterpret<Divider<byte8>, Divider<T>>();
                            case 1:  return CreateFromData(Divider.Divisor.v8_1,   *(byte8*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte8*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte8>.Create(), Uninitialized<byte8>.Create(),  sizeof(byte), 8, sign, Divider._promises).Reinterpret<Divider<byte8>, Divider<T>>();
                            case 2:  return CreateFromData(Divider.Divisor.v8_2,   *(byte8*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte8*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte8>.Create(), Uninitialized<byte8>.Create(),  sizeof(byte), 8, sign, Divider._promises).Reinterpret<Divider<byte8>, Divider<T>>();
                            case 3:  return CreateFromData(Divider.Divisor.v8_3,   *(byte8*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte8*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte8>.Create(), Uninitialized<byte8>.Create(),  sizeof(byte), 8, sign, Divider._promises).Reinterpret<Divider<byte8>, Divider<T>>();
                            case 4:  return CreateFromData(Divider.Divisor.v8_4,   *(byte8*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte8*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte8>.Create(), Uninitialized<byte8>.Create(),  sizeof(byte), 8, sign, Divider._promises).Reinterpret<Divider<byte8>, Divider<T>>();
                            case 5:  return CreateFromData(Divider.Divisor.v8_5,   *(byte8*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte8*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte8>.Create(), Uninitialized<byte8>.Create(),  sizeof(byte), 8, sign, Divider._promises).Reinterpret<Divider<byte8>, Divider<T>>();
                            case 6:  return CreateFromData(Divider.Divisor.v8_6,   *(byte8*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte8*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte8>.Create(), Uninitialized<byte8>.Create(),  sizeof(byte), 8, sign, Divider._promises).Reinterpret<Divider<byte8>, Divider<T>>();
                            case 7:  return CreateFromData(Divider.Divisor.v8_7,   *(byte8*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte8*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte8>.Create(), Uninitialized<byte8>.Create(),  sizeof(byte), 8, sign, Divider._promises).Reinterpret<Divider<byte8>, Divider<T>>();
                            case 8:  return CreateFromData(Divider.Divisor.v8_8,   *(byte8*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte8*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte8>.Create(), Uninitialized<byte8>.Create(),  sizeof(byte), 8, sign, Divider._promises).Reinterpret<Divider<byte8>, Divider<T>>();
                            case 9:  return CreateFromData(Divider.Divisor.v8_9,   *(byte8*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte8*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte8>.Create(), Uninitialized<byte8>.Create(),  sizeof(byte), 8, sign, Divider._promises).Reinterpret<Divider<byte8>, Divider<T>>();
                            case 10: return CreateFromData(Divider.Divisor.v8_10,  *(byte8*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte8*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte8>.Create(), Uninitialized<byte8>.Create(),  sizeof(byte), 8, sign, Divider._promises).Reinterpret<Divider<byte8>, Divider<T>>();
                            case 11: return CreateFromData(Divider.Divisor.v8_11,  *(byte8*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte8*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte8>.Create(), Uninitialized<byte8>.Create(),  sizeof(byte), 8, sign, Divider._promises).Reinterpret<Divider<byte8>, Divider<T>>();
                            case 12: return CreateFromData(Divider.Divisor.v8_12,  *(byte8*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte8*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte8>.Create(), Uninitialized<byte8>.Create(),  sizeof(byte), 8, sign, Divider._promises).Reinterpret<Divider<byte8>, Divider<T>>();
                            case 13: return CreateFromData(Divider.Divisor.v8_13,  *(byte8*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte8*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte8>.Create(), Uninitialized<byte8>.Create(),  sizeof(byte), 8, sign, Divider._promises).Reinterpret<Divider<byte8>, Divider<T>>();
                            case 14: return CreateFromData(Divider.Divisor.v8_14,  *(byte8*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte8*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte8>.Create(), Uninitialized<byte8>.Create(),  sizeof(byte), 8, sign, Divider._promises).Reinterpret<Divider<byte8>, Divider<T>>();
                            case 15: return CreateFromData(Divider.Divisor.v8_15,  *(byte8*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte8*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte8>.Create(), Uninitialized<byte8>.Create(),  sizeof(byte), 8, sign, Divider._promises).Reinterpret<Divider<byte8>, Divider<T>>();
                            case 16: return CreateFromData(Divider.Divisor.v8_16,  *(byte8*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte8*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte8>.Create(), Uninitialized<byte8>.Create(),  sizeof(byte), 8, sign, Divider._promises).Reinterpret<Divider<byte8>, Divider<T>>();
                            case 17: return CreateFromData(Divider.Divisor.v8_17,  *(byte8*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte8*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte8>.Create(), Uninitialized<byte8>.Create(),  sizeof(byte), 8, sign, Divider._promises).Reinterpret<Divider<byte8>, Divider<T>>();
                            case 18: return CreateFromData(Divider.Divisor.v8_18,  *(byte8*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte8*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte8>.Create(), Uninitialized<byte8>.Create(),  sizeof(byte), 8, sign, Divider._promises).Reinterpret<Divider<byte8>, Divider<T>>();
                            case 19: return CreateFromData(Divider.Divisor.v8_19,  *(byte8*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte8*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte8>.Create(), Uninitialized<byte8>.Create(),  sizeof(byte), 8, sign, Divider._promises).Reinterpret<Divider<byte8>, Divider<T>>();
                            case 20: return CreateFromData(Divider.Divisor.v8_20,  *(byte8*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte8*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte8>.Create(), Uninitialized<byte8>.Create(),  sizeof(byte), 8, sign, Divider._promises).Reinterpret<Divider<byte8>, Divider<T>>();
                            case 21: return CreateFromData(Divider.Divisor.v8_21,  *(byte8*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte8*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte8>.Create(), Uninitialized<byte8>.Create(),  sizeof(byte), 8, sign, Divider._promises).Reinterpret<Divider<byte8>, Divider<T>>();
                            case 22: return CreateFromData(Divider.Divisor.v8_22,  *(byte8*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte8*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte8>.Create(), Uninitialized<byte8>.Create(),  sizeof(byte), 8, sign, Divider._promises).Reinterpret<Divider<byte8>, Divider<T>>();
                            case 23: return CreateFromData(Divider.Divisor.v8_23,  *(byte8*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte8*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte8>.Create(), Uninitialized<byte8>.Create(),  sizeof(byte), 8, sign, Divider._promises).Reinterpret<Divider<byte8>, Divider<T>>();
                            case 24: return CreateFromData(Divider.Divisor.v8_24,  *(byte8*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte8*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte8>.Create(), Uninitialized<byte8>.Create(),  sizeof(byte), 8, sign, Divider._promises).Reinterpret<Divider<byte8>, Divider<T>>();

                            default: throw Assert.Unreachable();
                        }
                    }
                    else
                    {
                        if (Avx2.IsAvx2Supported)
                        {
                            return CreateFromData((byte8)Avx.mm256_castsi256_si128(Xse.mm256_bsrli_si256(Divider.Divisor, sizeof(byte) * index)),
                                                  *(byte8*)((byte*)&Divider._bigM._mulLo  + 2 * index),
                                                  *((byte8*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1),
                                                  Uninitialized<byte8>.Create(),
                                                  Uninitialized<byte8>.Create(),
                                                  sizeof(byte),
                                                  8,
                                                  sign,
                                                  Divider._promises).Reinterpret<Divider<byte8>, Divider<T>>();
                        }
                        else
                        {
                            return CreateFromData(*(byte8*)((byte*)&Divider._divisor + index),
                                                  *(byte8*)((byte*)&Divider._bigM._mulLo  + 2 * index),
                                                  *((byte8*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1),
                                                  Uninitialized<byte8>.Create(),
                                                  Uninitialized<byte8>.Create(),
                                                  sizeof(byte),
                                                  8,
                                                  sign,
                                                  Divider._promises).Reinterpret<Divider<byte8>, Divider<T>>();
                        }
                    }
                }
                case 16 * sizeof(byte):
                {
                    if (constexpr.IS_CONST(index))
                    {
                        switch (index)
                        {
                            case 0:  return CreateFromData(Divider.Divisor.v16_0,  *(byte16*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte16*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte16>.Create(), Uninitialized<byte16>.Create(),  sizeof(byte), 16, sign, Divider._promises).Reinterpret<Divider<byte16>, Divider<T>>();
                            case 1:  return CreateFromData(Divider.Divisor.v16_1,  *(byte16*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte16*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte16>.Create(), Uninitialized<byte16>.Create(),  sizeof(byte), 16, sign, Divider._promises).Reinterpret<Divider<byte16>, Divider<T>>();
                            case 2:  return CreateFromData(Divider.Divisor.v16_2,  *(byte16*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte16*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte16>.Create(), Uninitialized<byte16>.Create(),  sizeof(byte), 16, sign, Divider._promises).Reinterpret<Divider<byte16>, Divider<T>>();
                            case 3:  return CreateFromData(Divider.Divisor.v16_3,  *(byte16*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte16*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte16>.Create(), Uninitialized<byte16>.Create(),  sizeof(byte), 16, sign, Divider._promises).Reinterpret<Divider<byte16>, Divider<T>>();
                            case 4:  return CreateFromData(Divider.Divisor.v16_4,  *(byte16*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte16*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte16>.Create(), Uninitialized<byte16>.Create(),  sizeof(byte), 16, sign, Divider._promises).Reinterpret<Divider<byte16>, Divider<T>>();
                            case 5:  return CreateFromData(Divider.Divisor.v16_5,  *(byte16*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte16*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte16>.Create(), Uninitialized<byte16>.Create(),  sizeof(byte), 16, sign, Divider._promises).Reinterpret<Divider<byte16>, Divider<T>>();
                            case 6:  return CreateFromData(Divider.Divisor.v16_6,  *(byte16*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte16*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte16>.Create(), Uninitialized<byte16>.Create(),  sizeof(byte), 16, sign, Divider._promises).Reinterpret<Divider<byte16>, Divider<T>>();
                            case 7:  return CreateFromData(Divider.Divisor.v16_7,  *(byte16*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte16*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte16>.Create(), Uninitialized<byte16>.Create(),  sizeof(byte), 16, sign, Divider._promises).Reinterpret<Divider<byte16>, Divider<T>>();
                            case 8:  return CreateFromData(Divider.Divisor.v16_8,  *(byte16*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte16*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte16>.Create(), Uninitialized<byte16>.Create(),  sizeof(byte), 16, sign, Divider._promises).Reinterpret<Divider<byte16>, Divider<T>>();
                            case 9:  return CreateFromData(Divider.Divisor.v16_9,  *(byte16*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte16*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte16>.Create(), Uninitialized<byte16>.Create(),  sizeof(byte), 16, sign, Divider._promises).Reinterpret<Divider<byte16>, Divider<T>>();
                            case 10: return CreateFromData(Divider.Divisor.v16_10, *(byte16*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte16*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte16>.Create(), Uninitialized<byte16>.Create(),  sizeof(byte), 16, sign, Divider._promises).Reinterpret<Divider<byte16>, Divider<T>>();
                            case 11: return CreateFromData(Divider.Divisor.v16_11, *(byte16*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte16*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte16>.Create(), Uninitialized<byte16>.Create(),  sizeof(byte), 16, sign, Divider._promises).Reinterpret<Divider<byte16>, Divider<T>>();
                            case 12: return CreateFromData(Divider.Divisor.v16_12, *(byte16*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte16*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte16>.Create(), Uninitialized<byte16>.Create(),  sizeof(byte), 16, sign, Divider._promises).Reinterpret<Divider<byte16>, Divider<T>>();
                            case 13: return CreateFromData(Divider.Divisor.v16_13, *(byte16*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte16*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte16>.Create(), Uninitialized<byte16>.Create(),  sizeof(byte), 16, sign, Divider._promises).Reinterpret<Divider<byte16>, Divider<T>>();
                            case 14: return CreateFromData(Divider.Divisor.v16_14, *(byte16*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte16*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte16>.Create(), Uninitialized<byte16>.Create(),  sizeof(byte), 16, sign, Divider._promises).Reinterpret<Divider<byte16>, Divider<T>>();
                            case 15: return CreateFromData(Divider.Divisor.v16_15, *(byte16*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte16*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte16>.Create(), Uninitialized<byte16>.Create(),  sizeof(byte), 16, sign, Divider._promises).Reinterpret<Divider<byte16>, Divider<T>>();
                            case 16: return CreateFromData(Divider.Divisor.v16_16, *(byte16*)((byte*)&Divider._bigM._mulLo  + 2 * index), *((byte16*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1), Uninitialized<byte16>.Create(), Uninitialized<byte16>.Create(),  sizeof(byte), 16, sign, Divider._promises).Reinterpret<Divider<byte16>, Divider<T>>();

                            default: throw Assert.Unreachable();
                        }
                    }
                    else
                    {
                        if (Avx2.IsAvx2Supported)
                        {
                            return CreateFromData((byte16)Avx.mm256_castsi256_si128(Xse.mm256_bsrli_si256(Divider.Divisor, sizeof(byte) * index)),
                                                  *(byte16*)((byte*)&Divider._bigM._mulLo  + 2 * index),
                                                  *((byte16*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1),
                                                  Uninitialized<byte16>.Create(),
                                                  Uninitialized<byte16>.Create(),
                                                  sizeof(byte),
                                                  16,
                                                  sign,
                                                  Divider._promises).Reinterpret<Divider<byte16>, Divider<T>>();
                        }
                        else
                        {
                            return CreateFromData(*(byte16*)((byte*)&Divider._divisor + index),
                                                  *(byte16*)((byte*)&Divider._bigM._mulLo  + 2 * index),
                                                  *((byte16*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1),
                                                  Uninitialized<byte16>.Create(),
                                                  Uninitialized<byte16>.Create(),
                                                  sizeof(byte),
                                                  16,
                                                  sign,
                                                  Divider._promises).Reinterpret<Divider<byte16>, Divider<T>>();
                        }
                    }
                }

                default: throw new InvalidCastException();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Divider<T> GetInnerDivider8Base<T>(Divider<byte16> Divider, int index, Signedness sign)
            where T : unmanaged, IEquatable<T>, IFormattable
        {
Assert.IsWithinArrayBounds(index, 17 - sizeof(T) / sizeof(byte));

            switch (sizeof(T))
            {
                case 1 * sizeof(byte):
                {
                    return CreateFromData(Divider.Divisor[index], ((byte*)&Divider._bigM._mulLo)[2 * index], ((byte*)&Divider._bigM._mulLo)[2 * index + 1], Uninitialized<byte>.Create(), Uninitialized<byte>.Create(),  sizeof(byte), 1, sign, Divider._promises).Reinterpret<Divider<byte>, Divider<T>>();
                }
                case 2 * sizeof(byte):
                {
                    if (Architecture.IsSIMDSupported)
                    {
                        return CreateFromData((byte2)Xse.bsrli_si128(Divider.Divisor, sizeof(byte) * index),
                                              *(byte2*)((byte*)&Divider._bigM._mulLo  + 2 * index),
                                              *((byte2*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1),
                                              Uninitialized<byte2>.Create(),
                                              Uninitialized<byte2>.Create(),
                                              sizeof(byte),
                                              2,
                                              sign,
                                              Divider._promises).Reinterpret<Divider<byte2>, Divider<T>>();
                    }
                    else
                    {
                        return CreateFromData(*(byte2*)((byte*)&Divider._divisor + index),
                                              *(byte2*)((byte*)&Divider._bigM._mulLo  + 2 * index),
                                              *((byte2*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1),
                                              Uninitialized<byte2>.Create(),
                                              Uninitialized<byte2>.Create(),
                                              sizeof(byte),
                                              2,
                                              sign,
                                              Divider._promises).Reinterpret<Divider<byte2>, Divider<T>>();
                    }
                }
                case 3 * sizeof(byte):
                {
                    if (Architecture.IsSIMDSupported)
                    {
                        return CreateFromData((byte3)Xse.bsrli_si128(Divider.Divisor, sizeof(byte) * index),
                                              *(byte3*)((byte*)&Divider._bigM._mulLo  + 2 * index),
                                              *((byte3*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1),
                                              Uninitialized<byte3>.Create(),
                                              Uninitialized<byte3>.Create(),
                                              sizeof(byte),
                                              3,
                                              sign,
                                              Divider._promises).Reinterpret<Divider<byte3>, Divider<T>>();
                    }
                    else
                    {
                        return CreateFromData(*(byte3*)((byte*)&Divider._divisor + index),
                                              *(byte3*)((byte*)&Divider._bigM._mulLo  + 2 * index),
                                              *((byte3*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1),
                                              Uninitialized<byte3>.Create(),
                                              Uninitialized<byte3>.Create(),
                                              sizeof(byte),
                                              3,
                                              sign,
                                              Divider._promises).Reinterpret<Divider<byte3>, Divider<T>>();
                    }
                }
                case 4 * sizeof(byte):
                {
                    if (Architecture.IsSIMDSupported)
                    {
                        return CreateFromData((byte4)Xse.bsrli_si128(Divider.Divisor, sizeof(byte) * index),
                                              *(byte4*)((byte*)&Divider._bigM._mulLo  + 2 * index),
                                              *((byte4*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1),
                                              Uninitialized<byte4>.Create(),
                                              Uninitialized<byte4>.Create(),
                                              sizeof(byte),
                                              4,
                                              sign,
                                              Divider._promises).Reinterpret<Divider<byte4>, Divider<T>>();
                    }
                    else
                    {
                        return CreateFromData(*(byte4*)((byte*)&Divider._divisor + index),
                                              *(byte4*)((byte*)&Divider._bigM._mulLo  + 2 * index),
                                              *((byte4*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1),
                                              Uninitialized<byte4>.Create(),
                                              Uninitialized<byte4>.Create(),
                                              sizeof(byte),
                                              4,
                                              sign,
                                              Divider._promises).Reinterpret<Divider<byte4>, Divider<T>>();
                    }
                }
                case 8 * sizeof(byte):
                {
                    if (Architecture.IsSIMDSupported)
                    {
                        return CreateFromData((byte8)Xse.bsrli_si128(Divider.Divisor, sizeof(byte) * index),
                                              *(byte8*)((byte*)&Divider._bigM._mulLo  + 2 * index),
                                              *((byte8*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1),
                                              Uninitialized<byte8>.Create(),
                                              Uninitialized<byte8>.Create(),
                                              sizeof(byte),
                                              8,
                                              sign,
                                              Divider._promises).Reinterpret<Divider<byte8>, Divider<T>>();
                    }
                    else
                    {
                        return CreateFromData(*(byte8*)((byte*)&Divider._divisor + index),
                                              *(byte8*)((byte*)&Divider._bigM._mulLo  + 2 * index),
                                              *((byte8*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1),
                                              Uninitialized<byte8>.Create(),
                                              Uninitialized<byte8>.Create(),
                                              sizeof(byte),
                                              8,
                                              sign,
                                              Divider._promises).Reinterpret<Divider<byte8>, Divider<T>>();
                    }
                }

                default: throw new InvalidCastException();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Divider<T> GetInnerDivider8Base<T>(Divider<byte8> Divider, int index, Signedness sign)
            where T : unmanaged, IEquatable<T>, IFormattable
        {
Assert.IsWithinArrayBounds(index, 9 - sizeof(T) / sizeof(byte));

            switch (sizeof(T))
            {
                case 1 * sizeof(byte):
                {
                    return CreateFromData(Divider.Divisor[index], ((byte*)&Divider._bigM._mulLo)[2 * index], ((byte*)&Divider._bigM._mulLo)[2 * index + 1], Uninitialized<byte>.Create(), Uninitialized<byte>.Create(),  sizeof(byte), 1, sign, Divider._promises).Reinterpret<Divider<byte>, Divider<T>>();
                }
                case 2 * sizeof(byte):
                {
                    if (Architecture.IsSIMDSupported)
                    {
                        return CreateFromData((byte2)Xse.bsrli_si128(Divider.Divisor, sizeof(byte) * index),
                                              *(byte2*)((byte*)&Divider._bigM._mulLo  + 2 * index),
                                              *((byte2*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1),
                                              Uninitialized<byte2>.Create(),
                                              Uninitialized<byte2>.Create(),
                                              sizeof(byte),
                                              2,
                                              sign,
                                              Divider._promises).Reinterpret<Divider<byte2>, Divider<T>>();
                    }
                    else
                    {
                        return CreateFromData(*(byte2*)((byte*)&Divider._divisor + index),
                                              *(byte2*)((byte*)&Divider._bigM._mulLo  + 2 * index),
                                              *((byte2*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1),
                                              Uninitialized<byte2>.Create(),
                                              Uninitialized<byte2>.Create(),
                                              sizeof(byte),
                                              2,
                                              sign,
                                              Divider._promises).Reinterpret<Divider<byte2>, Divider<T>>();
                    }
                }
                case 3 * sizeof(byte):
                {
                    if (Architecture.IsSIMDSupported)
                    {
                        return CreateFromData((byte3)Xse.bsrli_si128(Divider.Divisor, sizeof(byte) * index),
                                              *(byte3*)((byte*)&Divider._bigM._mulLo  + 2 * index),
                                              *((byte3*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1),
                                              Uninitialized<byte3>.Create(),
                                              Uninitialized<byte3>.Create(),
                                              sizeof(byte),
                                              3,
                                              sign,
                                              Divider._promises).Reinterpret<Divider<byte3>, Divider<T>>();
                    }
                    else
                    {
                        return CreateFromData(*(byte3*)((byte*)&Divider._divisor + index),
                                              *(byte3*)((byte*)&Divider._bigM._mulLo  + 2 * index),
                                              *((byte3*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1),
                                              Uninitialized<byte3>.Create(),
                                              Uninitialized<byte3>.Create(),
                                              sizeof(byte),
                                              3,
                                              sign,
                                              Divider._promises).Reinterpret<Divider<byte3>, Divider<T>>();
                    }
                }
                case 4 * sizeof(byte):
                {
                    if (Architecture.IsSIMDSupported)
                    {
                        return CreateFromData((byte4)Xse.bsrli_si128(Divider.Divisor, sizeof(byte) * index),
                                              *(byte4*)((byte*)&Divider._bigM._mulLo  + 2 * index),
                                              *((byte4*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1),
                                              Uninitialized<byte4>.Create(),
                                              Uninitialized<byte4>.Create(),
                                              sizeof(byte),
                                              4,
                                              sign,
                                              Divider._promises).Reinterpret<Divider<byte4>, Divider<T>>();
                    }
                    else
                    {
                        return CreateFromData(*(byte4*)((byte*)&Divider._divisor + index),
                                              *(byte4*)((byte*)&Divider._bigM._mulLo  + 2 * index),
                                              *((byte4*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1),
                                              Uninitialized<byte4>.Create(),
                                              Uninitialized<byte4>.Create(),
                                              sizeof(byte),
                                              4,
                                              sign,
                                              Divider._promises).Reinterpret<Divider<byte4>, Divider<T>>();
                    }
                }

                default: throw new InvalidCastException();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Divider<T> GetInnerDivider8Base<T>(Divider<byte4> Divider, int index, Signedness sign)
            where T : unmanaged, IEquatable<T>, IFormattable
        {
Assert.IsWithinArrayBounds(index, 5 - sizeof(T) / sizeof(byte));

            switch (sizeof(T))
            {
                case 1 * sizeof(byte):
                {
                    return CreateFromData(Divider.Divisor[index], ((byte*)&Divider._bigM._mulLo)[2 * index], ((byte*)&Divider._bigM._mulLo)[2 * index + 1], Uninitialized<byte>.Create(), Uninitialized<byte>.Create(),  sizeof(byte), 1, sign, Divider._promises).Reinterpret<Divider<byte>, Divider<T>>();
                }
                case 2 * sizeof(byte):
                {
                    if (Architecture.IsSIMDSupported)
                    {
                        return CreateFromData((byte2)Xse.bsrli_si128(Divider.Divisor, sizeof(byte) * index),
                                              *(byte2*)((byte*)&Divider._bigM._mulLo  + 2 * index),
                                              *((byte2*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1),
                                              Uninitialized<byte2>.Create(),
                                              Uninitialized<byte2>.Create(),
                                              sizeof(byte),
                                              2,
                                              sign,
                                              Divider._promises).Reinterpret<Divider<byte2>, Divider<T>>();
                    }
                    else
                    {
                        return CreateFromData(*(byte2*)((byte*)&Divider._divisor + index),
                                              *(byte2*)((byte*)&Divider._bigM._mulLo  + 2 * index),
                                              *((byte2*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1),
                                              Uninitialized<byte2>.Create(),
                                              Uninitialized<byte2>.Create(),
                                              sizeof(byte),
                                              2,
                                              sign,
                                              Divider._promises).Reinterpret<Divider<byte2>, Divider<T>>();
                    }
                }
                case 3 * sizeof(byte):
                {
                    if (Architecture.IsSIMDSupported)
                    {
                        return CreateFromData((byte3)Xse.bsrli_si128(Divider.Divisor, sizeof(byte) * index),
                                              *(byte3*)((byte*)&Divider._bigM._mulLo  + 2 * index),
                                              *((byte3*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1),
                                              Uninitialized<byte3>.Create(),
                                              Uninitialized<byte3>.Create(),
                                              sizeof(byte),
                                              3,
                                              sign,
                                              Divider._promises).Reinterpret<Divider<byte3>, Divider<T>>();
                    }
                    else
                    {
                        return CreateFromData(*(byte3*)((byte*)&Divider._divisor + index),
                                              *(byte3*)((byte*)&Divider._bigM._mulLo  + 2 * index),
                                              *((byte3*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1),
                                              Uninitialized<byte3>.Create(),
                                              Uninitialized<byte3>.Create(),
                                              sizeof(byte),
                                              3,
                                              sign,
                                              Divider._promises).Reinterpret<Divider<byte3>, Divider<T>>();
                    }
                }

                default: throw new InvalidCastException();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Divider<T> GetInnerDivider8Base<T>(Divider<byte3> Divider, int index, Signedness sign)
            where T : unmanaged, IEquatable<T>, IFormattable
        {
Assert.IsWithinArrayBounds(index, 4 - sizeof(T) / sizeof(byte));

            switch (sizeof(T))
            {
                case 1 * sizeof(byte):
                {
                    return CreateFromData(Divider.Divisor[index], ((byte*)&Divider._bigM._mulLo)[2 * index], ((byte*)&Divider._bigM._mulLo)[2 * index + 1], Uninitialized<byte>.Create(), Uninitialized<byte>.Create(),  sizeof(byte), 1, sign, Divider._promises).Reinterpret<Divider<byte>, Divider<T>>();
                }
                case 2 * sizeof(byte):
                {
                    if (Architecture.IsSIMDSupported)
                    {
                        return CreateFromData((byte2)Xse.bsrli_si128(Divider.Divisor, sizeof(byte) * index),
                                              *(byte2*)((byte*)&Divider._bigM._mulLo  + 2 * index),
                                              *((byte2*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1),
                                              Uninitialized<byte2>.Create(),
                                              Uninitialized<byte2>.Create(),
                                              sizeof(byte),
                                              2,
                                              sign,
                                              Divider._promises).Reinterpret<Divider<byte2>, Divider<T>>();
                    }
                    else
                    {
                        return CreateFromData(*(byte2*)((byte*)&Divider._divisor + index),
                                              *(byte2*)((byte*)&Divider._bigM._mulLo  + 2 * index),
                                              *((byte2*)((byte*)&Divider._bigM._mulLo + 2 * index) + 1),
                                              Uninitialized<byte2>.Create(),
                                              Uninitialized<byte2>.Create(),
                                              sizeof(byte),
                                              2,
                                              sign,
                                              Divider._promises).Reinterpret<Divider<byte2>, Divider<T>>();
                    }
                }

                default: throw new InvalidCastException();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Divider<T> GetInnerDivider8Base<T>(Divider<byte2> Divider, int index, Signedness sign)
            where T : unmanaged, IEquatable<T>, IFormattable
        {
Assert.IsWithinArrayBounds(index, 3 - sizeof(T) / sizeof(byte));

            return CreateFromData(Divider.Divisor[index], ((byte*)&Divider._bigM._mulLo)[2 * index], ((byte*)&Divider._bigM._mulLo)[2 * index + 1], Uninitialized<byte>.Create(), Uninitialized<byte>.Create(),  sizeof(byte), 1, sign, Divider._promises).Reinterpret<Divider<byte>, Divider<T>>();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Divider<T> GetInnerDivider16Base<T>(Divider<ushort16> Divider, int index, Signedness sign)
            where T : unmanaged, IEquatable<T>, IFormattable
        {
Assert.IsWithinArrayBounds(index, 17 - sizeof(T) / sizeof(ushort));

            switch (sizeof(T))
            {
                case 1 * sizeof(ushort):
                {
                    return CreateFromData(Divider.Divisor[index], ((ushort*)&Divider._bigM._mulLo)[2 * index], ((ushort*)&Divider._bigM._mulLo)[2 * index + 1], Divider._mulShift._mul[index], Divider._mulShift._shift[index], sizeof(ushort), 1, sign, Divider._promises).Reinterpret<Divider<ushort>, Divider<T>>();
                }
                case 2 * sizeof(ushort):
                {
                    if (constexpr.IS_CONST(index))
                    {
                        switch (index)
                        {
                            case 0:  return CreateFromData(Divider.Divisor.v2_0,  *(ushort2*)((ushort*)&Divider._bigM._mulLo  + 2 * index), *((ushort2*)((ushort*)&Divider._bigM._mulLo + 2 * index) + 1), Divider._mulShift._mul.v2_0,  Divider._mulShift._shift.v2_0,  sizeof(ushort), 2, sign, Divider._promises).Reinterpret<Divider<ushort2>, Divider<T>>();
                            case 1:  return CreateFromData(Divider.Divisor.v2_1,  *(ushort2*)((ushort*)&Divider._bigM._mulLo  + 2 * index), *((ushort2*)((ushort*)&Divider._bigM._mulLo + 2 * index) + 1), Divider._mulShift._mul.v2_1,  Divider._mulShift._shift.v2_1,  sizeof(ushort), 2, sign, Divider._promises).Reinterpret<Divider<ushort2>, Divider<T>>();
                            case 2:  return CreateFromData(Divider.Divisor.v2_2,  *(ushort2*)((ushort*)&Divider._bigM._mulLo  + 2 * index), *((ushort2*)((ushort*)&Divider._bigM._mulLo + 2 * index) + 1), Divider._mulShift._mul.v2_2,  Divider._mulShift._shift.v2_2,  sizeof(ushort), 2, sign, Divider._promises).Reinterpret<Divider<ushort2>, Divider<T>>();
                            case 3:  return CreateFromData(Divider.Divisor.v2_3,  *(ushort2*)((ushort*)&Divider._bigM._mulLo  + 2 * index), *((ushort2*)((ushort*)&Divider._bigM._mulLo + 2 * index) + 1), Divider._mulShift._mul.v2_3,  Divider._mulShift._shift.v2_3,  sizeof(ushort), 2, sign, Divider._promises).Reinterpret<Divider<ushort2>, Divider<T>>();
                            case 4:  return CreateFromData(Divider.Divisor.v2_4,  *(ushort2*)((ushort*)&Divider._bigM._mulLo  + 2 * index), *((ushort2*)((ushort*)&Divider._bigM._mulLo + 2 * index) + 1), Divider._mulShift._mul.v2_4,  Divider._mulShift._shift.v2_4,  sizeof(ushort), 2, sign, Divider._promises).Reinterpret<Divider<ushort2>, Divider<T>>();
                            case 5:  return CreateFromData(Divider.Divisor.v2_5,  *(ushort2*)((ushort*)&Divider._bigM._mulLo  + 2 * index), *((ushort2*)((ushort*)&Divider._bigM._mulLo + 2 * index) + 1), Divider._mulShift._mul.v2_5,  Divider._mulShift._shift.v2_5,  sizeof(ushort), 2, sign, Divider._promises).Reinterpret<Divider<ushort2>, Divider<T>>();
                            case 6:  return CreateFromData(Divider.Divisor.v2_6,  *(ushort2*)((ushort*)&Divider._bigM._mulLo  + 2 * index), *((ushort2*)((ushort*)&Divider._bigM._mulLo + 2 * index) + 1), Divider._mulShift._mul.v2_6,  Divider._mulShift._shift.v2_6,  sizeof(ushort), 2, sign, Divider._promises).Reinterpret<Divider<ushort2>, Divider<T>>();
                            case 7:  return CreateFromData(Divider.Divisor.v2_7,  *(ushort2*)((ushort*)&Divider._bigM._mulLo  + 2 * index), *((ushort2*)((ushort*)&Divider._bigM._mulLo + 2 * index) + 1), Divider._mulShift._mul.v2_7,  Divider._mulShift._shift.v2_7,  sizeof(ushort), 2, sign, Divider._promises).Reinterpret<Divider<ushort2>, Divider<T>>();
                            case 8:  return CreateFromData(Divider.Divisor.v2_8,  *(ushort2*)((ushort*)&Divider._bigM._mulLo  + 2 * index), *((ushort2*)((ushort*)&Divider._bigM._mulLo + 2 * index) + 1), Divider._mulShift._mul.v2_8,  Divider._mulShift._shift.v2_8,  sizeof(ushort), 2, sign, Divider._promises).Reinterpret<Divider<ushort2>, Divider<T>>();
                            case 9:  return CreateFromData(Divider.Divisor.v2_9,  *(ushort2*)((ushort*)&Divider._bigM._mulLo  + 2 * index), *((ushort2*)((ushort*)&Divider._bigM._mulLo + 2 * index) + 1), Divider._mulShift._mul.v2_9,  Divider._mulShift._shift.v2_9,  sizeof(ushort), 2, sign, Divider._promises).Reinterpret<Divider<ushort2>, Divider<T>>();
                            case 10: return CreateFromData(Divider.Divisor.v2_10, *(ushort2*)((ushort*)&Divider._bigM._mulLo  + 2 * index), *((ushort2*)((ushort*)&Divider._bigM._mulLo + 2 * index) + 1), Divider._mulShift._mul.v2_10, Divider._mulShift._shift.v2_10, sizeof(ushort), 2, sign, Divider._promises).Reinterpret<Divider<ushort2>, Divider<T>>();
                            case 11: return CreateFromData(Divider.Divisor.v2_11, *(ushort2*)((ushort*)&Divider._bigM._mulLo  + 2 * index), *((ushort2*)((ushort*)&Divider._bigM._mulLo + 2 * index) + 1), Divider._mulShift._mul.v2_11, Divider._mulShift._shift.v2_11, sizeof(ushort), 2, sign, Divider._promises).Reinterpret<Divider<ushort2>, Divider<T>>();
                            case 12: return CreateFromData(Divider.Divisor.v2_12, *(ushort2*)((ushort*)&Divider._bigM._mulLo  + 2 * index), *((ushort2*)((ushort*)&Divider._bigM._mulLo + 2 * index) + 1), Divider._mulShift._mul.v2_12, Divider._mulShift._shift.v2_12, sizeof(ushort), 2, sign, Divider._promises).Reinterpret<Divider<ushort2>, Divider<T>>();
                            case 13: return CreateFromData(Divider.Divisor.v2_13, *(ushort2*)((ushort*)&Divider._bigM._mulLo  + 2 * index), *((ushort2*)((ushort*)&Divider._bigM._mulLo + 2 * index) + 1), Divider._mulShift._mul.v2_13, Divider._mulShift._shift.v2_13, sizeof(ushort), 2, sign, Divider._promises).Reinterpret<Divider<ushort2>, Divider<T>>();
                            case 14: return CreateFromData(Divider.Divisor.v2_14, *(ushort2*)((ushort*)&Divider._bigM._mulLo  + 2 * index), *((ushort2*)((ushort*)&Divider._bigM._mulLo + 2 * index) + 1), Divider._mulShift._mul.v2_14, Divider._mulShift._shift.v2_14, sizeof(ushort), 2, sign, Divider._promises).Reinterpret<Divider<ushort2>, Divider<T>>();

                            default: throw Assert.Unreachable();
                        }
                    }
                    else
                    {
                        if (Avx2.IsAvx2Supported)
                        {
                            return CreateFromData((ushort2)Avx.mm256_castsi256_si128(Xse.mm256_bsrli_si256(Divider.Divisor, sizeof(ushort) * index)),
                                                  *(ushort2*)((ushort*)&Divider._bigM._mulLo  + 2 * index),
                                                  *((ushort2*)((ushort*)&Divider._bigM._mulLo + 2 * index) + 1),
                                                  (ushort2)Avx.mm256_castsi256_si128(Xse.mm256_bsrli_si256(Divider._mulShift._mul,    sizeof(ushort) * index)),
                                                  (ushort2)Avx.mm256_castsi256_si128(Xse.mm256_bsrli_si256(Divider._mulShift._shift, sizeof(ushort) * index)),
                                                  sizeof(ushort),
                                                  2,
                                                  sign,
                                                  Divider._promises).Reinterpret<Divider<ushort2>, Divider<T>>();
                        }
                        else
                        {
                            return CreateFromData(*(ushort2*)((ushort*)&Divider._divisor + index),
                                                  *(ushort2*)((ushort*)&Divider._bigM._mulLo  + 2 * index),
                                                  *((ushort2*)((ushort*)&Divider._bigM._mulLo + 2 * index) + 1),
                                                  *(ushort2*)((ushort*)&Divider._mulShift._mul    + index),
                                                  *(ushort2*)((ushort*)&Divider._mulShift._shift + index),
                                                  sizeof(ushort),
                                                  2,
                                                  sign,
                                                  Divider._promises).Reinterpret<Divider<ushort2>, Divider<T>>();
                        }
                    }
                }
                case 3 * sizeof(ushort):
                {
                    if (constexpr.IS_CONST(index))
                    {
                        switch (index)
                        {
                            case 0:  return CreateFromData(Divider.Divisor.v3_0,  *(ushort3*)((ushort*)&Divider._bigM._mulLo  + 2 * index), *((ushort3*)((ushort*)&Divider._bigM._mulLo + 2 * index) + 1), Divider._mulShift._mul.v3_0,  Divider._mulShift._shift.v3_0,  sizeof(ushort), 3, sign, Divider._promises).Reinterpret<Divider<ushort3>, Divider<T>>();
                            case 1:  return CreateFromData(Divider.Divisor.v3_1,  *(ushort3*)((ushort*)&Divider._bigM._mulLo  + 2 * index), *((ushort3*)((ushort*)&Divider._bigM._mulLo + 2 * index) + 1), Divider._mulShift._mul.v3_1,  Divider._mulShift._shift.v3_1,  sizeof(ushort), 3, sign, Divider._promises).Reinterpret<Divider<ushort3>, Divider<T>>();
                            case 2:  return CreateFromData(Divider.Divisor.v3_2,  *(ushort3*)((ushort*)&Divider._bigM._mulLo  + 2 * index), *((ushort3*)((ushort*)&Divider._bigM._mulLo + 2 * index) + 1), Divider._mulShift._mul.v3_2,  Divider._mulShift._shift.v3_2,  sizeof(ushort), 3, sign, Divider._promises).Reinterpret<Divider<ushort3>, Divider<T>>();
                            case 3:  return CreateFromData(Divider.Divisor.v3_3,  *(ushort3*)((ushort*)&Divider._bigM._mulLo  + 2 * index), *((ushort3*)((ushort*)&Divider._bigM._mulLo + 2 * index) + 1), Divider._mulShift._mul.v3_3,  Divider._mulShift._shift.v3_3,  sizeof(ushort), 3, sign, Divider._promises).Reinterpret<Divider<ushort3>, Divider<T>>();
                            case 4:  return CreateFromData(Divider.Divisor.v3_4,  *(ushort3*)((ushort*)&Divider._bigM._mulLo  + 2 * index), *((ushort3*)((ushort*)&Divider._bigM._mulLo + 2 * index) + 1), Divider._mulShift._mul.v3_4,  Divider._mulShift._shift.v3_4,  sizeof(ushort), 3, sign, Divider._promises).Reinterpret<Divider<ushort3>, Divider<T>>();
                            case 5:  return CreateFromData(Divider.Divisor.v3_5,  *(ushort3*)((ushort*)&Divider._bigM._mulLo  + 2 * index), *((ushort3*)((ushort*)&Divider._bigM._mulLo + 2 * index) + 1), Divider._mulShift._mul.v3_5,  Divider._mulShift._shift.v3_5,  sizeof(ushort), 3, sign, Divider._promises).Reinterpret<Divider<ushort3>, Divider<T>>();
                            case 6:  return CreateFromData(Divider.Divisor.v3_6,  *(ushort3*)((ushort*)&Divider._bigM._mulLo  + 2 * index), *((ushort3*)((ushort*)&Divider._bigM._mulLo + 2 * index) + 1), Divider._mulShift._mul.v3_6,  Divider._mulShift._shift.v3_6,  sizeof(ushort), 3, sign, Divider._promises).Reinterpret<Divider<ushort3>, Divider<T>>();
                            case 7:  return CreateFromData(Divider.Divisor.v3_7,  *(ushort3*)((ushort*)&Divider._bigM._mulLo  + 2 * index), *((ushort3*)((ushort*)&Divider._bigM._mulLo + 2 * index) + 1), Divider._mulShift._mul.v3_7,  Divider._mulShift._shift.v3_7,  sizeof(ushort), 3, sign, Divider._promises).Reinterpret<Divider<ushort3>, Divider<T>>();
                            case 8:  return CreateFromData(Divider.Divisor.v3_8,  *(ushort3*)((ushort*)&Divider._bigM._mulLo  + 2 * index), *((ushort3*)((ushort*)&Divider._bigM._mulLo + 2 * index) + 1), Divider._mulShift._mul.v3_8,  Divider._mulShift._shift.v3_8,  sizeof(ushort), 3, sign, Divider._promises).Reinterpret<Divider<ushort3>, Divider<T>>();
                            case 9:  return CreateFromData(Divider.Divisor.v3_9,  *(ushort3*)((ushort*)&Divider._bigM._mulLo  + 2 * index), *((ushort3*)((ushort*)&Divider._bigM._mulLo + 2 * index) + 1), Divider._mulShift._mul.v3_9,  Divider._mulShift._shift.v3_9,  sizeof(ushort), 3, sign, Divider._promises).Reinterpret<Divider<ushort3>, Divider<T>>();
                            case 10: return CreateFromData(Divider.Divisor.v3_10, *(ushort3*)((ushort*)&Divider._bigM._mulLo  + 2 * index), *((ushort3*)((ushort*)&Divider._bigM._mulLo + 2 * index) + 1), Divider._mulShift._mul.v3_10, Divider._mulShift._shift.v3_10, sizeof(ushort), 3, sign, Divider._promises).Reinterpret<Divider<ushort3>, Divider<T>>();
                            case 11: return CreateFromData(Divider.Divisor.v3_11, *(ushort3*)((ushort*)&Divider._bigM._mulLo  + 2 * index), *((ushort3*)((ushort*)&Divider._bigM._mulLo + 2 * index) + 1), Divider._mulShift._mul.v3_11, Divider._mulShift._shift.v3_11, sizeof(ushort), 3, sign, Divider._promises).Reinterpret<Divider<ushort3>, Divider<T>>();
                            case 12: return CreateFromData(Divider.Divisor.v3_12, *(ushort3*)((ushort*)&Divider._bigM._mulLo  + 2 * index), *((ushort3*)((ushort*)&Divider._bigM._mulLo + 2 * index) + 1), Divider._mulShift._mul.v3_12, Divider._mulShift._shift.v3_12, sizeof(ushort), 3, sign, Divider._promises).Reinterpret<Divider<ushort3>, Divider<T>>();
                            case 13: return CreateFromData(Divider.Divisor.v3_13, *(ushort3*)((ushort*)&Divider._bigM._mulLo  + 2 * index), *((ushort3*)((ushort*)&Divider._bigM._mulLo + 2 * index) + 1), Divider._mulShift._mul.v3_13, Divider._mulShift._shift.v3_13, sizeof(ushort), 3, sign, Divider._promises).Reinterpret<Divider<ushort3>, Divider<T>>();

                            default: throw Assert.Unreachable();
                        }
                    }
                    else
                    {
                        if (Avx2.IsAvx2Supported)
                        {
                            return CreateFromData((ushort3)Avx.mm256_castsi256_si128(Xse.mm256_bsrli_si256(Divider.Divisor, sizeof(ushort) * index)),
                                                  *(ushort3*)((ushort*)&Divider._bigM._mulLo  + 2 * index),
                                                  *((ushort3*)((ushort*)&Divider._bigM._mulLo + 2 * index) + 1),
                                                  (ushort3)Avx.mm256_castsi256_si128(Xse.mm256_bsrli_si256(Divider._mulShift._mul,    sizeof(ushort) * index)),
                                                  (ushort3)Avx.mm256_castsi256_si128(Xse.mm256_bsrli_si256(Divider._mulShift._shift, sizeof(ushort) * index)),
                                                  sizeof(ushort),
                                                  3,
                                                  sign,
                                                  Divider._promises).Reinterpret<Divider<ushort3>, Divider<T>>();
                        }
                        else
                        {
                            return CreateFromData(*(ushort3*)((ushort*)&Divider._divisor + index),
                                                  *(ushort3*)((ushort*)&Divider._bigM._mulLo  + 2 * index),
                                                  *((ushort3*)((ushort*)&Divider._bigM._mulLo + 2 * index) + 1),
                                                  *(ushort3*)((ushort*)&Divider._mulShift._mul    + index),
                                                  *(ushort3*)((ushort*)&Divider._mulShift._shift + index),
                                                  sizeof(ushort),
                                                  3,
                                                  sign,
                                                  Divider._promises).Reinterpret<Divider<ushort3>, Divider<T>>();
                        }
                    }
                }
                case 4 * sizeof(ushort):
                {
                    if (constexpr.IS_CONST(index))
                    {
                        switch (index)
                        {
                            case 0:  return CreateFromData(Divider.Divisor.v4_0,  *(ushort4*)((ushort*)&Divider._bigM._mulLo  + 2 * index), *((ushort4*)((ushort*)&Divider._bigM._mulLo + 2 * index) + 1), Divider._mulShift._mul.v4_0,  Divider._mulShift._shift.v4_0,  sizeof(ushort), 4, sign, Divider._promises).Reinterpret<Divider<ushort4>, Divider<T>>();
                            case 1:  return CreateFromData(Divider.Divisor.v4_1,  *(ushort4*)((ushort*)&Divider._bigM._mulLo  + 2 * index), *((ushort4*)((ushort*)&Divider._bigM._mulLo + 2 * index) + 1), Divider._mulShift._mul.v4_1,  Divider._mulShift._shift.v4_1,  sizeof(ushort), 4, sign, Divider._promises).Reinterpret<Divider<ushort4>, Divider<T>>();
                            case 2:  return CreateFromData(Divider.Divisor.v4_2,  *(ushort4*)((ushort*)&Divider._bigM._mulLo  + 2 * index), *((ushort4*)((ushort*)&Divider._bigM._mulLo + 2 * index) + 1), Divider._mulShift._mul.v4_2,  Divider._mulShift._shift.v4_2,  sizeof(ushort), 4, sign, Divider._promises).Reinterpret<Divider<ushort4>, Divider<T>>();
                            case 3:  return CreateFromData(Divider.Divisor.v4_3,  *(ushort4*)((ushort*)&Divider._bigM._mulLo  + 2 * index), *((ushort4*)((ushort*)&Divider._bigM._mulLo + 2 * index) + 1), Divider._mulShift._mul.v4_3,  Divider._mulShift._shift.v4_3,  sizeof(ushort), 4, sign, Divider._promises).Reinterpret<Divider<ushort4>, Divider<T>>();
                            case 4:  return CreateFromData(Divider.Divisor.v4_4,  *(ushort4*)((ushort*)&Divider._bigM._mulLo  + 2 * index), *((ushort4*)((ushort*)&Divider._bigM._mulLo + 2 * index) + 1), Divider._mulShift._mul.v4_4,  Divider._mulShift._shift.v4_4,  sizeof(ushort), 4, sign, Divider._promises).Reinterpret<Divider<ushort4>, Divider<T>>();
                            case 5:  return CreateFromData(Divider.Divisor.v4_5,  *(ushort4*)((ushort*)&Divider._bigM._mulLo  + 2 * index), *((ushort4*)((ushort*)&Divider._bigM._mulLo + 2 * index) + 1), Divider._mulShift._mul.v4_5,  Divider._mulShift._shift.v4_5,  sizeof(ushort), 4, sign, Divider._promises).Reinterpret<Divider<ushort4>, Divider<T>>();
                            case 6:  return CreateFromData(Divider.Divisor.v4_6,  *(ushort4*)((ushort*)&Divider._bigM._mulLo  + 2 * index), *((ushort4*)((ushort*)&Divider._bigM._mulLo + 2 * index) + 1), Divider._mulShift._mul.v4_6,  Divider._mulShift._shift.v4_6,  sizeof(ushort), 4, sign, Divider._promises).Reinterpret<Divider<ushort4>, Divider<T>>();
                            case 7:  return CreateFromData(Divider.Divisor.v4_7,  *(ushort4*)((ushort*)&Divider._bigM._mulLo  + 2 * index), *((ushort4*)((ushort*)&Divider._bigM._mulLo + 2 * index) + 1), Divider._mulShift._mul.v4_7,  Divider._mulShift._shift.v4_7,  sizeof(ushort), 4, sign, Divider._promises).Reinterpret<Divider<ushort4>, Divider<T>>();
                            case 8:  return CreateFromData(Divider.Divisor.v4_8,  *(ushort4*)((ushort*)&Divider._bigM._mulLo  + 2 * index), *((ushort4*)((ushort*)&Divider._bigM._mulLo + 2 * index) + 1), Divider._mulShift._mul.v4_8,  Divider._mulShift._shift.v4_8,  sizeof(ushort), 4, sign, Divider._promises).Reinterpret<Divider<ushort4>, Divider<T>>();
                            case 9:  return CreateFromData(Divider.Divisor.v4_9,  *(ushort4*)((ushort*)&Divider._bigM._mulLo  + 2 * index), *((ushort4*)((ushort*)&Divider._bigM._mulLo + 2 * index) + 1), Divider._mulShift._mul.v4_9,  Divider._mulShift._shift.v4_9,  sizeof(ushort), 4, sign, Divider._promises).Reinterpret<Divider<ushort4>, Divider<T>>();
                            case 10: return CreateFromData(Divider.Divisor.v4_10, *(ushort4*)((ushort*)&Divider._bigM._mulLo  + 2 * index), *((ushort4*)((ushort*)&Divider._bigM._mulLo + 2 * index) + 1), Divider._mulShift._mul.v4_10, Divider._mulShift._shift.v4_10, sizeof(ushort), 4, sign, Divider._promises).Reinterpret<Divider<ushort4>, Divider<T>>();
                            case 11: return CreateFromData(Divider.Divisor.v4_11, *(ushort4*)((ushort*)&Divider._bigM._mulLo  + 2 * index), *((ushort4*)((ushort*)&Divider._bigM._mulLo + 2 * index) + 1), Divider._mulShift._mul.v4_11, Divider._mulShift._shift.v4_11, sizeof(ushort), 4, sign, Divider._promises).Reinterpret<Divider<ushort4>, Divider<T>>();
                            case 12: return CreateFromData(Divider.Divisor.v4_12, *(ushort4*)((ushort*)&Divider._bigM._mulLo  + 2 * index), *((ushort4*)((ushort*)&Divider._bigM._mulLo + 2 * index) + 1), Divider._mulShift._mul.v4_12, Divider._mulShift._shift.v4_12, sizeof(ushort), 4, sign, Divider._promises).Reinterpret<Divider<ushort4>, Divider<T>>();

                            default: throw Assert.Unreachable();
                        }
                    }
                    else
                    {
                        if (Avx2.IsAvx2Supported)
                        {
                            return CreateFromData((ushort4)Avx.mm256_castsi256_si128(Xse.mm256_bsrli_si256(Divider.Divisor, sizeof(ushort) * index)),
                                                  *(ushort4*)((ushort*)&Divider._bigM._mulLo  + 2 * index),
                                                  *((ushort4*)((ushort*)&Divider._bigM._mulLo + 2 * index) + 1),
                                                  (ushort4)Avx.mm256_castsi256_si128(Xse.mm256_bsrli_si256(Divider._mulShift._mul,    sizeof(ushort) * index)),
                                                  (ushort4)Avx.mm256_castsi256_si128(Xse.mm256_bsrli_si256(Divider._mulShift._shift, sizeof(ushort) * index)),
                                                  sizeof(ushort),
                                                  4,
                                                  sign,
                                                  Divider._promises).Reinterpret<Divider<ushort4>, Divider<T>>();
                        }
                        else
                        {
                            return CreateFromData(*(ushort4*)((ushort*)&Divider._divisor + index),
                                                  *(ushort4*)((ushort*)&Divider._bigM._mulLo  + 2 * index),
                                                  *((ushort4*)((ushort*)&Divider._bigM._mulLo + 2 * index) + 1),
                                                  *(ushort4*)((ushort*)&Divider._mulShift._mul    + index),
                                                  *(ushort4*)((ushort*)&Divider._mulShift._shift + index),
                                                  sizeof(ushort),
                                                  4,
                                                  sign,
                                                  Divider._promises).Reinterpret<Divider<ushort4>, Divider<T>>();
                        }
                    }
                }
                case 8 * sizeof(ushort):
                {
                    if (constexpr.IS_CONST(index))
                    {
                        switch (index)
                        {
                            case 0:  return CreateFromData(Divider.Divisor.v8_0, *(ushort8*)((ushort*)&Divider._bigM._mulLo  + 2 * index),  *((ushort8*)((ushort*)&Divider._bigM._mulLo + 2 * index) + 1),  Divider._mulShift._mul.v8_0,  Divider._mulShift._shift.v8_0, sizeof(ushort), 8, sign, Divider._promises).Reinterpret<Divider<ushort8>, Divider<T>>();
                            case 1:  return CreateFromData(Divider.Divisor.v8_1, *(ushort8*)((ushort*)&Divider._bigM._mulLo  + 2 * index),  *((ushort8*)((ushort*)&Divider._bigM._mulLo + 2 * index) + 1),  Divider._mulShift._mul.v8_1,  Divider._mulShift._shift.v8_1, sizeof(ushort), 8, sign, Divider._promises).Reinterpret<Divider<ushort8>, Divider<T>>();
                            case 2:  return CreateFromData(Divider.Divisor.v8_2, *(ushort8*)((ushort*)&Divider._bigM._mulLo  + 2 * index),  *((ushort8*)((ushort*)&Divider._bigM._mulLo + 2 * index) + 1),  Divider._mulShift._mul.v8_2,  Divider._mulShift._shift.v8_2, sizeof(ushort), 8, sign, Divider._promises).Reinterpret<Divider<ushort8>, Divider<T>>();
                            case 3:  return CreateFromData(Divider.Divisor.v8_3, *(ushort8*)((ushort*)&Divider._bigM._mulLo  + 2 * index),  *((ushort8*)((ushort*)&Divider._bigM._mulLo + 2 * index) + 1),  Divider._mulShift._mul.v8_3,  Divider._mulShift._shift.v8_3, sizeof(ushort), 8, sign, Divider._promises).Reinterpret<Divider<ushort8>, Divider<T>>();
                            case 4:  return CreateFromData(Divider.Divisor.v8_4, *(ushort8*)((ushort*)&Divider._bigM._mulLo  + 2 * index),  *((ushort8*)((ushort*)&Divider._bigM._mulLo + 2 * index) + 1),  Divider._mulShift._mul.v8_4,  Divider._mulShift._shift.v8_4, sizeof(ushort), 8, sign, Divider._promises).Reinterpret<Divider<ushort8>, Divider<T>>();
                            case 5:  return CreateFromData(Divider.Divisor.v8_5, *(ushort8*)((ushort*)&Divider._bigM._mulLo  + 2 * index),  *((ushort8*)((ushort*)&Divider._bigM._mulLo + 2 * index) + 1),  Divider._mulShift._mul.v8_5,  Divider._mulShift._shift.v8_5, sizeof(ushort), 8, sign, Divider._promises).Reinterpret<Divider<ushort8>, Divider<T>>();
                            case 6:  return CreateFromData(Divider.Divisor.v8_6, *(ushort8*)((ushort*)&Divider._bigM._mulLo  + 2 * index),  *((ushort8*)((ushort*)&Divider._bigM._mulLo + 2 * index) + 1),  Divider._mulShift._mul.v8_6,  Divider._mulShift._shift.v8_6, sizeof(ushort), 8, sign, Divider._promises).Reinterpret<Divider<ushort8>, Divider<T>>();
                            case 7:  return CreateFromData(Divider.Divisor.v8_7, *(ushort8*)((ushort*)&Divider._bigM._mulLo  + 2 * index),  *((ushort8*)((ushort*)&Divider._bigM._mulLo + 2 * index) + 1),  Divider._mulShift._mul.v8_7,  Divider._mulShift._shift.v8_7, sizeof(ushort), 8, sign, Divider._promises).Reinterpret<Divider<ushort8>, Divider<T>>();
                            case 8:  return CreateFromData(Divider.Divisor.v8_8, *(ushort8*)((ushort*)&Divider._bigM._mulLo  + 2 * index),  *((ushort8*)((ushort*)&Divider._bigM._mulLo + 2 * index) + 1),  Divider._mulShift._mul.v8_8,  Divider._mulShift._shift.v8_8, sizeof(ushort), 8, sign, Divider._promises).Reinterpret<Divider<ushort8>, Divider<T>>();

                            default: throw Assert.Unreachable();
                        }
                    }
                    else
                    {
                        if (Avx2.IsAvx2Supported)
                        {
                            return CreateFromData((ushort8)Avx.mm256_castsi256_si128(Xse.mm256_bsrli_si256(Divider.Divisor, sizeof(ushort) * index)),
                                                  *(ushort8*)((ushort*)&Divider._bigM._mulLo  + 2 * index),
                                                  *((ushort8*)((ushort*)&Divider._bigM._mulLo + 2 * index) + 1),
                                                  (ushort8)Avx.mm256_castsi256_si128(Xse.mm256_bsrli_si256(Divider._mulShift._mul,    sizeof(ushort) * index)),
                                                  (ushort8)Avx.mm256_castsi256_si128(Xse.mm256_bsrli_si256(Divider._mulShift._shift, sizeof(ushort) * index)),
                                                  sizeof(ushort),
                                                  8,
                                                  sign,
                                                  Divider._promises).Reinterpret<Divider<ushort8>, Divider<T>>();
                        }
                        else
                        {
                            return CreateFromData(*(ushort8*)((ushort*)&Divider._divisor + index),
                                                  *(ushort8*)((ushort*)&Divider._bigM._mulLo  + 2 * index),
                                                  *((ushort8*)((ushort*)&Divider._bigM._mulLo + 2 * index) + 1),
                                                  *(ushort8*)((ushort*)&Divider._mulShift._mul    + index),
                                                  *(ushort8*)((ushort*)&Divider._mulShift._shift + index),
                                                  sizeof(ushort),
                                                  8,
                                                  sign,
                                                  Divider._promises).Reinterpret<Divider<ushort8>, Divider<T>>();
                        }
                    }
                }

                default: throw new InvalidCastException();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Divider<T> GetInnerDivider16Base<T>(Divider<ushort8> Divider, int index, Signedness sign)
            where T : unmanaged, IEquatable<T>, IFormattable
        {
Assert.IsWithinArrayBounds(index, 9 - sizeof(T) / sizeof(ushort));

            switch (sizeof(T))
            {
                case 1 * sizeof(ushort):
                {
                    return CreateFromData(Divider.Divisor[index], ((ushort*)&Divider._bigM._mulLo)[2 * index], ((ushort*)&Divider._bigM._mulLo)[2 * index + 1], Divider._mulShift._mul[index], Divider._mulShift._shift[index], sizeof(ushort), 1, sign, Divider._promises).Reinterpret<Divider<ushort>, Divider<T>>();
                }
                case 2 * sizeof(ushort):
                {
                    if (Architecture.IsSIMDSupported)
                    {
                        return CreateFromData((ushort2)Xse.bsrli_si128(Divider.Divisor, sizeof(ushort) * index),
                                              *(ushort2*)((ushort*)&Divider._bigM._mulLo  + 2 * index),
                                              *((ushort2*)((ushort*)&Divider._bigM._mulLo + 2 * index) + 1),
                                              (ushort2)Xse.bsrli_si128(Divider._mulShift._mul,    sizeof(ushort) * index),
                                              (ushort2)Xse.bsrli_si128(Divider._mulShift._shift, sizeof(ushort) * index),
                                              sizeof(ushort),
                                              2,
                                              sign,
                                              Divider._promises).Reinterpret<Divider<ushort2>, Divider<T>>();
                    }
                    else
                    {
                        return CreateFromData(*(ushort2*)((ushort*)&Divider._divisor + index),
                                              *(ushort2*)((ushort*)&Divider._bigM._mulLo  + 2 * index),
                                              *((ushort2*)((ushort*)&Divider._bigM._mulLo + 2 * index) + 1),
                                              *(ushort2*)((ushort*)&Divider._mulShift._mul    + index),
                                              *(ushort2*)((ushort*)&Divider._mulShift._shift + index),
                                              sizeof(ushort),
                                              2,
                                              sign,
                                              Divider._promises).Reinterpret<Divider<ushort2>, Divider<T>>();
                    }
                }
                case 3 * sizeof(ushort):
                {
                    if (Architecture.IsSIMDSupported)
                    {
                        return CreateFromData((ushort3)Xse.bsrli_si128(Divider.Divisor, sizeof(ushort) * index),
                                              *(ushort3*)((ushort*)&Divider._bigM._mulLo  + 2 * index),
                                              *((ushort3*)((ushort*)&Divider._bigM._mulLo + 2 * index) + 1),
                                              (ushort3)Xse.bsrli_si128(Divider._mulShift._mul,    sizeof(ushort) * index),
                                              (ushort3)Xse.bsrli_si128(Divider._mulShift._shift, sizeof(ushort) * index),
                                              sizeof(ushort),
                                              3,
                                              sign,
                                              Divider._promises).Reinterpret<Divider<ushort3>, Divider<T>>();
                    }
                    else
                    {
                        return CreateFromData(*(ushort3*)((ushort*)&Divider._divisor + index),
                                              *(ushort3*)((ushort*)&Divider._bigM._mulLo  + 2 * index),
                                              *((ushort3*)((ushort*)&Divider._bigM._mulLo + 2 * index) + 1),
                                              *(ushort3*)((ushort*)&Divider._mulShift._mul    + index),
                                              *(ushort3*)((ushort*)&Divider._mulShift._shift + index),
                                              sizeof(ushort),
                                              3,
                                              sign,
                                              Divider._promises).Reinterpret<Divider<ushort3>, Divider<T>>();
                    }
                }
                case 4 * sizeof(ushort):
                {
                    if (Architecture.IsSIMDSupported)
                    {
                        return CreateFromData((ushort4)Xse.bsrli_si128(Divider.Divisor, sizeof(ushort) * index),
                                              *(ushort4*)((ushort*)&Divider._bigM._mulLo  + 2 * index),
                                              *((ushort4*)((ushort*)&Divider._bigM._mulLo + 2 * index) + 1),
                                              (ushort4)Xse.bsrli_si128(Divider._mulShift._mul,    sizeof(ushort) * index),
                                              (ushort4)Xse.bsrli_si128(Divider._mulShift._shift, sizeof(ushort) * index),
                                              sizeof(ushort),
                                              4,
                                              sign,
                                              Divider._promises).Reinterpret<Divider<ushort4>, Divider<T>>();
                    }
                    else
                    {
                        return CreateFromData(*(ushort4*)((ushort*)&Divider._divisor + index),
                                              *(ushort4*)((ushort*)&Divider._bigM._mulLo  + 2 * index),
                                              *((ushort4*)((ushort*)&Divider._bigM._mulLo + 2 * index) + 1),
                                              *(ushort4*)((ushort*)&Divider._mulShift._mul    + index),
                                              *(ushort4*)((ushort*)&Divider._mulShift._shift + index),
                                              sizeof(ushort),
                                              4,
                                              sign,
                                              Divider._promises).Reinterpret<Divider<ushort4>, Divider<T>>();
                    }
                }

                default: throw new InvalidCastException();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Divider<T> GetInnerDivider16Base<T>(Divider<ushort4> Divider, int index, Signedness sign)
            where T : unmanaged, IEquatable<T>, IFormattable
        {
Assert.IsWithinArrayBounds(index, 5 - sizeof(T) / sizeof(ushort));

            switch (sizeof(T))
            {
                case 1 * sizeof(ushort):
                {
                    return CreateFromData(Divider.Divisor[index], ((ushort*)&Divider._bigM._mulLo)[2 * index], ((ushort*)&Divider._bigM._mulLo)[2 * index + 1], Divider._mulShift._mul[index], Divider._mulShift._shift[index], sizeof(ushort), 1, sign, Divider._promises).Reinterpret<Divider<ushort>, Divider<T>>();
                }
                case 2 * sizeof(ushort):
                {
                    if (Architecture.IsSIMDSupported)
                    {
                        return CreateFromData((ushort2)Xse.bsrli_si128(Divider.Divisor, sizeof(ushort) * index),
                                              *(ushort2*)((ushort*)&Divider._bigM._mulLo  + 2 * index),
                                              *((ushort2*)((ushort*)&Divider._bigM._mulLo + 2 * index) + 1),
                                              (ushort2)Xse.bsrli_si128(Divider._mulShift._mul,    sizeof(ushort) * index),
                                              (ushort2)Xse.bsrli_si128(Divider._mulShift._shift, sizeof(ushort) * index),
                                              sizeof(ushort),
                                              2,
                                              sign,
                                              Divider._promises).Reinterpret<Divider<ushort2>, Divider<T>>();
                    }
                    else
                    {
                        return CreateFromData(*(ushort2*)((ushort*)&Divider._divisor + index),
                                              *(ushort2*)((ushort*)&Divider._bigM._mulLo  + 2 * index),
                                              *((ushort2*)((ushort*)&Divider._bigM._mulLo + 2 * index) + 1),
                                              *(ushort2*)((ushort*)&Divider._mulShift._mul    + index),
                                              *(ushort2*)((ushort*)&Divider._mulShift._shift + index),
                                              sizeof(ushort),
                                              2,
                                              sign,
                                              Divider._promises).Reinterpret<Divider<ushort2>, Divider<T>>();
                    }
                }
                case 3 * sizeof(ushort):
                {
                    if (Architecture.IsSIMDSupported)
                    {
                        return CreateFromData((ushort3)Xse.bsrli_si128(Divider.Divisor, sizeof(ushort) * index),
                                              *(ushort3*)((ushort*)&Divider._bigM._mulLo  + 2 * index),
                                              *((ushort3*)((ushort*)&Divider._bigM._mulLo + 2 * index) + 1),
                                              (ushort3)Xse.bsrli_si128(Divider._mulShift._mul,    sizeof(ushort) * index),
                                              (ushort3)Xse.bsrli_si128(Divider._mulShift._shift, sizeof(ushort) * index),
                                              sizeof(ushort),
                                              3,
                                              sign,
                                              Divider._promises).Reinterpret<Divider<ushort3>, Divider<T>>();
                    }
                    else
                    {
                        return CreateFromData(*(ushort3*)((ushort*)&Divider._divisor + index),
                                              *(ushort3*)((ushort*)&Divider._bigM._mulLo  + 2 * index),
                                              *((ushort3*)((ushort*)&Divider._bigM._mulLo + 2 * index) + 1),
                                              *(ushort3*)((ushort*)&Divider._mulShift._mul    + index),
                                              *(ushort3*)((ushort*)&Divider._mulShift._shift + index),
                                              sizeof(ushort),
                                              3,
                                              sign,
                                              Divider._promises).Reinterpret<Divider<ushort3>, Divider<T>>();
                    }
                }

                default: throw new InvalidCastException();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Divider<T> GetInnerDivider16Base<T>(Divider<ushort3> Divider, int index, Signedness sign)
            where T : unmanaged, IEquatable<T>, IFormattable
        {
Assert.IsWithinArrayBounds(index, 4 - sizeof(T) / sizeof(ushort));

            switch (sizeof(T))
            {
                case 1 * sizeof(ushort):
                {
                    return CreateFromData(Divider.Divisor[index], ((ushort*)&Divider._bigM._mulLo)[2 * index], ((ushort*)&Divider._bigM._mulLo)[2 * index + 1], Divider._mulShift._mul[index], Divider._mulShift._shift[index], sizeof(ushort), 1, sign, Divider._promises).Reinterpret<Divider<ushort>, Divider<T>>();
                }
                case 2 * sizeof(ushort):
                {
                    if (Architecture.IsSIMDSupported)
                    {
                        return CreateFromData((ushort2)Xse.bsrli_si128(Divider.Divisor, sizeof(ushort) * index),
                                              *(ushort2*)((ushort*)&Divider._bigM._mulLo  + 2 * index),
                                              *((ushort2*)((ushort*)&Divider._bigM._mulLo + 2 * index) + 1),
                                              (ushort2)Xse.bsrli_si128(Divider._mulShift._mul,    sizeof(ushort) * index),
                                              (ushort2)Xse.bsrli_si128(Divider._mulShift._shift, sizeof(ushort) * index),
                                              sizeof(ushort),
                                              2,
                                              sign,
                                              Divider._promises).Reinterpret<Divider<ushort2>, Divider<T>>();
                    }
                    else
                    {
                        return CreateFromData(*(ushort2*)((ushort*)&Divider._divisor + index),
                                              *(ushort2*)((ushort*)&Divider._bigM._mulLo  + 2 * index),
                                              *((ushort2*)((ushort*)&Divider._bigM._mulLo + 2 * index) + 1),
                                              *(ushort2*)((ushort*)&Divider._mulShift._mul    + index),
                                              *(ushort2*)((ushort*)&Divider._mulShift._shift + index),
                                              sizeof(ushort),
                                              2,
                                              sign,
                                              Divider._promises).Reinterpret<Divider<ushort2>, Divider<T>>();
                    }
                }

                default: throw new InvalidCastException();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Divider<T> GetInnerDivider16Base<T>(Divider<ushort2> Divider, int index, Signedness sign)
            where T : unmanaged, IEquatable<T>, IFormattable
        {
Assert.IsWithinArrayBounds(index, 3 - sizeof(T) / sizeof(ushort));

            return CreateFromData(Divider.Divisor[index], ((ushort*)&Divider._bigM._mulLo)[2 * index], ((ushort*)&Divider._bigM._mulLo)[2 * index + 1], Divider._mulShift._mul[index], Divider._mulShift._shift[index], sizeof(ushort), 1, sign, Divider._promises).Reinterpret<Divider<ushort>, Divider<T>>();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Divider<T> GetInnerDivider32Base<T>(Divider<uint8> Divider, int index, Signedness sign)
            where T : unmanaged, IEquatable<T>, IFormattable
        {
Assert.IsWithinArrayBounds(index, 9 - sizeof(T) / sizeof(uint));

            switch (sizeof(T))
            {
                case 1 * sizeof(uint):
                {
                    return CreateFromData(Divider.Divisor[index], ((uint*)&Divider._bigM._mulLo)[2 * index], ((uint*)&Divider._bigM._mulLo)[2 * index + 1], Divider._mulShift._mul[index], Divider._mulShift._shift[index], sizeof(uint), 1, sign, Divider._promises).Reinterpret<Divider<uint>, Divider<T>>();
                }
                case 2 * sizeof(uint):
                {
                    if (constexpr.IS_CONST(index))
                    {
                        switch (index)
                        {
                            case 0:  return CreateFromData(Divider.Divisor.v2_0, *(uint2*)((uint*)&Divider._bigM._mulLo  + 2 * index), *((uint2*)((uint*)&Divider._bigM._mulLo + 2 * index) + 1),  Divider._mulShift._mul.v2_0,  Divider._mulShift._shift.v2_0, sizeof(uint), 2, sign, Divider._promises).Reinterpret<Divider<uint2>, Divider<T>>();
                            case 1:  return CreateFromData(Divider.Divisor.v2_1, *(uint2*)((uint*)&Divider._bigM._mulLo  + 2 * index), *((uint2*)((uint*)&Divider._bigM._mulLo + 2 * index) + 1),  Divider._mulShift._mul.v2_1,  Divider._mulShift._shift.v2_1, sizeof(uint), 2, sign, Divider._promises).Reinterpret<Divider<uint2>, Divider<T>>();
                            case 2:  return CreateFromData(Divider.Divisor.v2_2, *(uint2*)((uint*)&Divider._bigM._mulLo  + 2 * index), *((uint2*)((uint*)&Divider._bigM._mulLo + 2 * index) + 1),  Divider._mulShift._mul.v2_2,  Divider._mulShift._shift.v2_2, sizeof(uint), 2, sign, Divider._promises).Reinterpret<Divider<uint2>, Divider<T>>();
                            case 3:  return CreateFromData(Divider.Divisor.v2_3, *(uint2*)((uint*)&Divider._bigM._mulLo  + 2 * index), *((uint2*)((uint*)&Divider._bigM._mulLo + 2 * index) + 1),  Divider._mulShift._mul.v2_3,  Divider._mulShift._shift.v2_3, sizeof(uint), 2, sign, Divider._promises).Reinterpret<Divider<uint2>, Divider<T>>();
                            case 4:  return CreateFromData(Divider.Divisor.v2_4, *(uint2*)((uint*)&Divider._bigM._mulLo  + 2 * index), *((uint2*)((uint*)&Divider._bigM._mulLo + 2 * index) + 1),  Divider._mulShift._mul.v2_4,  Divider._mulShift._shift.v2_4, sizeof(uint), 2, sign, Divider._promises).Reinterpret<Divider<uint2>, Divider<T>>();
                            case 5:  return CreateFromData(Divider.Divisor.v2_5, *(uint2*)((uint*)&Divider._bigM._mulLo  + 2 * index), *((uint2*)((uint*)&Divider._bigM._mulLo + 2 * index) + 1),  Divider._mulShift._mul.v2_5,  Divider._mulShift._shift.v2_5, sizeof(uint), 2, sign, Divider._promises).Reinterpret<Divider<uint2>, Divider<T>>();
                            case 6:  return CreateFromData(Divider.Divisor.v2_6, *(uint2*)((uint*)&Divider._bigM._mulLo  + 2 * index), *((uint2*)((uint*)&Divider._bigM._mulLo + 2 * index) + 1),  Divider._mulShift._mul.v2_6,  Divider._mulShift._shift.v2_6, sizeof(uint), 2, sign, Divider._promises).Reinterpret<Divider<uint2>, Divider<T>>();

                            default: throw Assert.Unreachable();
                        }
                    }
                    else
                    {
                        if (Avx2.IsAvx2Supported)
                        {
                            return CreateFromData(RegisterConversion.ToUInt2(Avx.mm256_castsi256_si128(Xse.mm256_bsrli_si256(Divider.Divisor, sizeof(uint) * index))),
                                                  *(uint2*)((uint*)&Divider._bigM._mulLo  + 2 * index),
                                                  *((uint2*)((uint*)&Divider._bigM._mulLo + 2 * index) + 1),
                                                  RegisterConversion.ToUInt2(Avx.mm256_castsi256_si128(Xse.mm256_bsrli_si256(Divider._mulShift._mul,    sizeof(uint) * index))),
                                                  RegisterConversion.ToUInt2(Avx.mm256_castsi256_si128(Xse.mm256_bsrli_si256(Divider._mulShift._shift, sizeof(uint) * index))),
                                                  sizeof(uint),
                                                  2,
                                                  sign,
                                                  Divider._promises).Reinterpret<Divider<uint2>, Divider<T>>();
                        }
                        else
                        {
                            return CreateFromData(*(uint2*)((uint*)&Divider._divisor + index),
                                                  *(uint2*)((uint*)&Divider._bigM._mulLo  + 2 * index),
                                                  *((uint2*)((uint*)&Divider._bigM._mulLo + 2 * index) + 1),
                                                  *(uint2*)((uint*)&Divider._mulShift._mul    + index),
                                                  *(uint2*)((uint*)&Divider._mulShift._shift + index),
                                                  sizeof(uint),
                                                  2,
                                                  sign,
                                                  Divider._promises).Reinterpret<Divider<uint2>, Divider<T>>();
                        }
                    }
                }
                case 3 * sizeof(uint):
                {
                    if (constexpr.IS_CONST(index))
                    {
                        switch (index)
                        {
                            case 0:  return CreateFromData(Divider.Divisor.v3_0,  *(uint3*)((uint*)&Divider._bigM._mulLo  + 2 * index), *((uint3*)((uint*)&Divider._bigM._mulLo + 2 * index) + 1), Divider._mulShift._mul.v3_0,  Divider._mulShift._shift.v3_0, sizeof(uint), 3, sign, Divider._promises).Reinterpret<Divider<uint3>, Divider<T>>();
                            case 1:  return CreateFromData(Divider.Divisor.v3_1,  *(uint3*)((uint*)&Divider._bigM._mulLo  + 2 * index), *((uint3*)((uint*)&Divider._bigM._mulLo + 2 * index) + 1), Divider._mulShift._mul.v3_1,  Divider._mulShift._shift.v3_1, sizeof(uint), 3, sign, Divider._promises).Reinterpret<Divider<uint3>, Divider<T>>();
                            case 2:  return CreateFromData(Divider.Divisor.v3_2,  *(uint3*)((uint*)&Divider._bigM._mulLo  + 2 * index), *((uint3*)((uint*)&Divider._bigM._mulLo + 2 * index) + 1), Divider._mulShift._mul.v3_2,  Divider._mulShift._shift.v3_2, sizeof(uint), 3, sign, Divider._promises).Reinterpret<Divider<uint3>, Divider<T>>();
                            case 3:  return CreateFromData(Divider.Divisor.v3_3,  *(uint3*)((uint*)&Divider._bigM._mulLo  + 2 * index), *((uint3*)((uint*)&Divider._bigM._mulLo + 2 * index) + 1), Divider._mulShift._mul.v3_3,  Divider._mulShift._shift.v3_3, sizeof(uint), 3, sign, Divider._promises).Reinterpret<Divider<uint3>, Divider<T>>();
                            case 4:  return CreateFromData(Divider.Divisor.v3_4,  *(uint3*)((uint*)&Divider._bigM._mulLo  + 2 * index), *((uint3*)((uint*)&Divider._bigM._mulLo + 2 * index) + 1), Divider._mulShift._mul.v3_4,  Divider._mulShift._shift.v3_4, sizeof(uint), 3, sign, Divider._promises).Reinterpret<Divider<uint3>, Divider<T>>();
                            case 5:  return CreateFromData(Divider.Divisor.v3_5,  *(uint3*)((uint*)&Divider._bigM._mulLo  + 2 * index), *((uint3*)((uint*)&Divider._bigM._mulLo + 2 * index) + 1), Divider._mulShift._mul.v3_5,  Divider._mulShift._shift.v3_5, sizeof(uint), 3, sign, Divider._promises).Reinterpret<Divider<uint3>, Divider<T>>();

                            default: throw Assert.Unreachable();
                        }
                    }
                    else
                    {
                        if (Avx2.IsAvx2Supported)
                        {
                            return CreateFromData(RegisterConversion.ToUInt3(Avx.mm256_castsi256_si128(Xse.mm256_bsrli_si256(Divider.Divisor, sizeof(uint) * index))),
                                                  *(uint3*)((uint*)&Divider._bigM._mulLo  + 2 * index),
                                                  *((uint3*)((uint*)&Divider._bigM._mulLo + 2 * index) + 1),
                                                  RegisterConversion.ToUInt3(Avx.mm256_castsi256_si128(Xse.mm256_bsrli_si256(Divider._mulShift._mul,    sizeof(uint) * index))),
                                                  RegisterConversion.ToUInt3(Avx.mm256_castsi256_si128(Xse.mm256_bsrli_si256(Divider._mulShift._shift, sizeof(uint) * index))),
                                                  sizeof(uint),
                                                  3,
                                                  sign,
                                                  Divider._promises).Reinterpret<Divider<uint3>, Divider<T>>();
                        }
                        else
                        {
                            return CreateFromData(*(uint3*)((uint*)&Divider._divisor + index),
                                                  *(uint3*)((uint*)&Divider._bigM._mulLo  + 2 * index),
                                                  *((uint3*)((uint*)&Divider._bigM._mulLo + 2 * index) + 1),
                                                  *(uint3*)((uint*)&Divider._mulShift._mul    + index),
                                                  *(uint3*)((uint*)&Divider._mulShift._shift + index),
                                                  sizeof(uint),
                                                  3,
                                                  sign,
                                                  Divider._promises).Reinterpret<Divider<uint3>, Divider<T>>();
                        }
                    }
                }
                case 4 * sizeof(uint):
                {
                    if (constexpr.IS_CONST(index))
                    {
                        switch (index)
                        {
                            case 0:  return CreateFromData(Divider.Divisor.v4_0, *(uint4*)((uint*)&Divider._bigM._mulLo  + 2 * index), *((uint4*)((uint*)&Divider._bigM._mulLo + 2 * index) + 1), Divider._mulShift._mul.v4_0,  Divider._mulShift._shift.v4_0, sizeof(uint), 4, sign, Divider._promises).Reinterpret<Divider<uint4>, Divider<T>>();
                            case 1:  return CreateFromData(Divider.Divisor.v4_1, *(uint4*)((uint*)&Divider._bigM._mulLo  + 2 * index), *((uint4*)((uint*)&Divider._bigM._mulLo + 2 * index) + 1), Divider._mulShift._mul.v4_1,  Divider._mulShift._shift.v4_1, sizeof(uint), 4, sign, Divider._promises).Reinterpret<Divider<uint4>, Divider<T>>();
                            case 2:  return CreateFromData(Divider.Divisor.v4_2, *(uint4*)((uint*)&Divider._bigM._mulLo  + 2 * index), *((uint4*)((uint*)&Divider._bigM._mulLo + 2 * index) + 1), Divider._mulShift._mul.v4_2,  Divider._mulShift._shift.v4_2, sizeof(uint), 4, sign, Divider._promises).Reinterpret<Divider<uint4>, Divider<T>>();
                            case 3:  return CreateFromData(Divider.Divisor.v4_3, *(uint4*)((uint*)&Divider._bigM._mulLo  + 2 * index), *((uint4*)((uint*)&Divider._bigM._mulLo + 2 * index) + 1), Divider._mulShift._mul.v4_3,  Divider._mulShift._shift.v4_3, sizeof(uint), 4, sign, Divider._promises).Reinterpret<Divider<uint4>, Divider<T>>();
                            case 4:  return CreateFromData(Divider.Divisor.v4_4, *(uint4*)((uint*)&Divider._bigM._mulLo  + 2 * index), *((uint4*)((uint*)&Divider._bigM._mulLo + 2 * index) + 1), Divider._mulShift._mul.v4_4,  Divider._mulShift._shift.v4_4, sizeof(uint), 4, sign, Divider._promises).Reinterpret<Divider<uint4>, Divider<T>>();

                            default: throw Assert.Unreachable();
                        }
                    }
                    else
                    {
                        if (Avx2.IsAvx2Supported)
                        {
                            return CreateFromData(RegisterConversion.ToUInt4(Avx.mm256_castsi256_si128(Xse.mm256_bsrli_si256(Divider.Divisor, sizeof(uint) * index))),
                                                  *(uint4*)((uint*)&Divider._bigM._mulLo  + 2 * index),
                                                  *((uint4*)((uint*)&Divider._bigM._mulLo + 2 * index) + 1),
                                                  RegisterConversion.ToUInt4(Avx.mm256_castsi256_si128(Xse.mm256_bsrli_si256(Divider._mulShift._mul,    sizeof(uint) * index))),
                                                  RegisterConversion.ToUInt4(Avx.mm256_castsi256_si128(Xse.mm256_bsrli_si256(Divider._mulShift._shift, sizeof(uint) * index))),
                                                  sizeof(uint),
                                                  4,
                                                  sign,
                                                  Divider._promises).Reinterpret<Divider<uint4>, Divider<T>>();
                        }
                        else
                        {
                            return CreateFromData(*(uint4*)((uint*)&Divider._divisor + index),
                                                  *(uint4*)((uint*)&Divider._bigM._mulLo  + 2 * index),
                                                  *((uint4*)((uint*)&Divider._bigM._mulLo + 2 * index) + 1),
                                                  *(uint4*)((uint*)&Divider._mulShift._mul    + index),
                                                  *(uint4*)((uint*)&Divider._mulShift._shift + index),
                                                  sizeof(uint),
                                                  4,
                                                  sign,
                                                  Divider._promises).Reinterpret<Divider<uint4>, Divider<T>>();
                        }
                    }
                }

                default: throw new InvalidCastException();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Divider<T> GetInnerDivider32Base<T>(Divider<uint4> Divider, int index, Signedness sign)
            where T : unmanaged, IEquatable<T>, IFormattable
        {
Assert.IsWithinArrayBounds(index, 5 - sizeof(T) / sizeof(uint));

            switch (sizeof(T))
            {
                case 1 * sizeof(uint):
                {
                    return CreateFromData(Divider.Divisor[index], ((uint*)&Divider._bigM._mulLo)[2 * index], ((uint*)&Divider._bigM._mulLo)[2 * index + 1], Divider._mulShift._mul[index], Divider._mulShift._shift[index], sizeof(uint), 1, sign, Divider._promises).Reinterpret<Divider<uint>, Divider<T>>();
                }
                case 2 * sizeof(uint):
                {
                    if (Architecture.IsSIMDSupported)
                    {
                        return CreateFromData(RegisterConversion.ToUInt2(Xse.bsrli_si128(RegisterConversion.ToV128(Divider.Divisor), sizeof(uint) * index)),
                                              *(uint2*)((uint*)&Divider._bigM._mulLo  + 2 * index),
                                              *((uint2*)((uint*)&Divider._bigM._mulLo + 2 * index) + 1),
                                              RegisterConversion.ToUInt2(Xse.bsrli_si128(RegisterConversion.ToV128(Divider._mulShift._mul),    sizeof(uint) * index)),
                                              RegisterConversion.ToUInt2(Xse.bsrli_si128(RegisterConversion.ToV128(Divider._mulShift._shift), sizeof(uint) * index)),
                                              sizeof(uint),
                                              2,
                                              sign,
                                              Divider._promises).Reinterpret<Divider<uint2>, Divider<T>>();
                    }
                    else
                    {
                        return CreateFromData(*(uint2*)((uint*)&Divider._divisor + index),
                                              *(uint2*)((uint*)&Divider._bigM._mulLo  + 2 * index),
                                              *((uint2*)((uint*)&Divider._bigM._mulLo + 2 * index) + 1),
                                              *(uint2*)((uint*)&Divider._mulShift._mul    + index),
                                              *(uint2*)((uint*)&Divider._mulShift._shift + index),
                                              sizeof(uint),
                                              2,
                                              sign,
                                              Divider._promises).Reinterpret<Divider<uint2>, Divider<T>>();
                    }
                }
                case 3 * sizeof(uint):
                {
                    if (Architecture.IsSIMDSupported)
                    {
                        return CreateFromData(RegisterConversion.ToUInt3(Xse.bsrli_si128(RegisterConversion.ToV128(Divider.Divisor), sizeof(uint) * index)),
                                              *(uint3*)((uint*)&Divider._bigM._mulLo  + 2 * index),
                                              *((uint3*)((uint*)&Divider._bigM._mulLo + 2 * index) + 1),
                                              RegisterConversion.ToUInt3(Xse.bsrli_si128(RegisterConversion.ToV128(Divider._mulShift._mul),    sizeof(uint) * index)),
                                              RegisterConversion.ToUInt3(Xse.bsrli_si128(RegisterConversion.ToV128(Divider._mulShift._shift), sizeof(uint) * index)),
                                              sizeof(uint),
                                              3,
                                              sign,
                                              Divider._promises).Reinterpret<Divider<uint3>, Divider<T>>();
                    }
                    else
                    {
                        return CreateFromData(*(uint3*)((uint*)&Divider._divisor + index),
                                              *(uint3*)((uint*)&Divider._bigM._mulLo  + 2 * index),
                                              *((uint3*)((uint*)&Divider._bigM._mulLo + 2 * index) + 1),
                                              *(uint3*)((uint*)&Divider._mulShift._mul    + index),
                                              *(uint3*)((uint*)&Divider._mulShift._shift + index),
                                              sizeof(uint),
                                              3,
                                              sign,
                                              Divider._promises).Reinterpret<Divider<uint3>, Divider<T>>();
                    }
                }

                default: throw new InvalidCastException();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Divider<T> GetInnerDivider32Base<T>(Divider<uint3> Divider, int index, Signedness sign)
            where T : unmanaged, IEquatable<T>, IFormattable
        {
Assert.IsWithinArrayBounds(index, 4 - sizeof(T) / sizeof(uint));

            switch (sizeof(T))
            {
                case 1 * sizeof(uint):
                {
                    return CreateFromData(Divider.Divisor[index], ((uint*)&Divider._bigM._mulLo)[2 * index], ((uint*)&Divider._bigM._mulLo)[2 * index + 1], Divider._mulShift._mul[index], Divider._mulShift._shift[index], sizeof(uint), 1, sign, Divider._promises).Reinterpret<Divider<uint>, Divider<T>>();
                }
                case 2 * sizeof(uint):
                {
                    if (Architecture.IsSIMDSupported)
                    {
                        return CreateFromData(RegisterConversion.ToUInt2(Xse.bsrli_si128(RegisterConversion.ToV128(Divider.Divisor), sizeof(uint) * index)),
                                              *(uint2*)((uint*)&Divider._bigM._mulLo  + 2 * index),
                                              *((uint2*)((uint*)&Divider._bigM._mulLo + 2 * index) + 1),
                                              RegisterConversion.ToUInt2(Xse.bsrli_si128(RegisterConversion.ToV128(Divider._mulShift._mul),    sizeof(uint) * index)),
                                              RegisterConversion.ToUInt2(Xse.bsrli_si128(RegisterConversion.ToV128(Divider._mulShift._shift), sizeof(uint) * index)),
                                              sizeof(uint),
                                              2,
                                              sign,
                                              Divider._promises).Reinterpret<Divider<uint2>, Divider<T>>();
                    }
                    else
                    {
                        return CreateFromData(*(uint2*)((uint*)&Divider._divisor + index),
                                              *(uint2*)((uint*)&Divider._bigM._mulLo  + 2 * index),
                                              *((uint2*)((uint*)&Divider._bigM._mulLo + 2 * index) + 1),
                                              *(uint2*)((uint*)&Divider._mulShift._mul    + index),
                                              *(uint2*)((uint*)&Divider._mulShift._shift + index),
                                              sizeof(uint),
                                              2,
                                              sign,
                                              Divider._promises).Reinterpret<Divider<uint2>, Divider<T>>();
                    }
                }

                default: throw new InvalidCastException();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Divider<T> GetInnerDivider32Base<T>(Divider<uint2> Divider, int index, Signedness sign)
            where T : unmanaged, IEquatable<T>, IFormattable
        {
Assert.IsWithinArrayBounds(index, 3 - sizeof(T) / sizeof(uint));

            return CreateFromData(Divider.Divisor[index], ((uint*)&Divider._bigM._mulLo)[2 * index], ((uint*)&Divider._bigM._mulLo)[2 * index + 1], Divider._mulShift._mul[index], Divider._mulShift._shift[index], sizeof(uint), 1, sign, Divider._promises).Reinterpret<Divider<uint>, Divider<T>>();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Divider<T> GetInnerDivider64Base<T>(Divider<ulong4> Divider, int index, Signedness sign)
            where T : unmanaged, IEquatable<T>, IFormattable
        {
Assert.IsWithinArrayBounds(index, 5 - sizeof(T) / sizeof(ulong));

            switch (sizeof(T))
            {
                case 1 * sizeof(ulong):
                {
                    return CreateFromData(Divider.Divisor[index], ((ulong*)&Divider._bigM._mulLo)[2 * index], ((ulong*)&Divider._bigM._mulLo)[2 * index + 1], Divider._mulShift._mul[index], Divider._mulShift._shift[index], sizeof(ulong), 1, sign, Divider._promises).Reinterpret<Divider<ulong>, Divider<T>>();
                }
                case 2 * sizeof(ulong):
                {
                    if (constexpr.IS_CONST(index))
                    {
                        switch (index)
                        {
                            case 0:  return CreateFromData(Divider.Divisor.xy, *(ulong2*)((ulong*)&Divider._bigM._mulLo  + 2 * index), *((ulong2*)((ulong*)&Divider._bigM._mulLo + 2 * index) + 1), Divider._mulShift._mul.xy,  Divider._mulShift._shift.xy, sizeof(ulong), 2, sign, Divider._promises).Reinterpret<Divider<ulong2>, Divider<T>>();
                            case 1:  return CreateFromData(Divider.Divisor.yz, *(ulong2*)((ulong*)&Divider._bigM._mulLo  + 2 * index), *((ulong2*)((ulong*)&Divider._bigM._mulLo + 2 * index) + 1), Divider._mulShift._mul.yz,  Divider._mulShift._shift.yz, sizeof(ulong), 2, sign, Divider._promises).Reinterpret<Divider<ulong2>, Divider<T>>();
                            case 2:  return CreateFromData(Divider.Divisor.zw, *(ulong2*)((ulong*)&Divider._bigM._mulLo  + 2 * index), *((ulong2*)((ulong*)&Divider._bigM._mulLo + 2 * index) + 1), Divider._mulShift._mul.zw,  Divider._mulShift._shift.zw, sizeof(ulong), 2, sign, Divider._promises).Reinterpret<Divider<ulong2>, Divider<T>>();

                            default: throw Assert.Unreachable();
                        }
                    }
                    else
                    {
                        if (Avx2.IsAvx2Supported)
                        {
                            return CreateFromData((ulong2)Avx.mm256_castsi256_si128(Xse.mm256_bsrli_si256(Divider.Divisor, sizeof(ulong) * index)),
                                                  *(ulong2*)((ulong*)&Divider._bigM._mulLo  + 2 * index),
                                                  *((ulong2*)((ulong*)&Divider._bigM._mulLo + 2 * index) + 1),
                                                  (ulong2)Avx.mm256_castsi256_si128(Xse.mm256_bsrli_si256(Divider._mulShift._mul,    sizeof(ulong) * index)),
                                                  (ulong2)Avx.mm256_castsi256_si128(Xse.mm256_bsrli_si256(Divider._mulShift._shift, sizeof(ulong) * index)),
                                                  sizeof(ulong),
                                                  2,
                                                  sign,
                                                  Divider._promises).Reinterpret<Divider<ulong2>, Divider<T>>();
                        }
                        else
                        {
                            return CreateFromData(*(ulong2*)((ulong*)&Divider._divisor + index),
                                                  *(ulong2*)((ulong*)&Divider._bigM._mulLo  + 2 * index),
                                                  *((ulong2*)((ulong*)&Divider._bigM._mulLo + 2 * index) + 1),
                                                  *(ulong2*)((ulong*)&Divider._mulShift._mul    + index),
                                                  *(ulong2*)((ulong*)&Divider._mulShift._shift + index),
                                                  sizeof(ulong),
                                                  2,
                                                  sign,
                                                  Divider._promises).Reinterpret<Divider<ulong2>, Divider<T>>();
                        }
                    }
                }
                case 3 * sizeof(ulong):
                {
                    if (constexpr.IS_CONST(index))
                    {
                        switch (index)
                        {
                            case 0:  return CreateFromData(Divider.Divisor.xyz,*(ulong3*)((ulong*)&Divider._bigM._mulLo  + 2 * index), *((ulong3*)((ulong*)&Divider._bigM._mulLo + 2 * index) + 1), Divider._mulShift._mul.xyz,  Divider._mulShift._shift.xyz, sizeof(ulong), 3, sign, Divider._promises).Reinterpret<Divider<ulong3>, Divider<T>>();
                            case 1:  return CreateFromData(Divider.Divisor.yzw,*(ulong3*)((ulong*)&Divider._bigM._mulLo  + 2 * index), *((ulong3*)((ulong*)&Divider._bigM._mulLo + 2 * index) + 1), Divider._mulShift._mul.yzw,  Divider._mulShift._shift.yzw, sizeof(ulong), 3, sign, Divider._promises).Reinterpret<Divider<ulong3>, Divider<T>>();

                            default: throw Assert.Unreachable();
                        }
                    }
                    else
                    {
                        if (Avx2.IsAvx2Supported)
                        {
                            return CreateFromData((ulong3)Xse.mm256_bsrli_si256(Divider.Divisor, sizeof(ulong) * index),
                                                  *(ulong3*)((ulong*)&Divider._bigM._mulLo  + 2 * index),
                                                  *((ulong3*)((ulong*)&Divider._bigM._mulLo + 2 * index) + 1),
                                                  (ulong3)Xse.mm256_bsrli_si256(Divider._mulShift._mul,    sizeof(ulong) * index),
                                                  (ulong3)Xse.mm256_bsrli_si256(Divider._mulShift._shift, sizeof(ulong) * index),
                                                  sizeof(ulong),
                                                  3,
                                                  sign,
                                                  Divider._promises).Reinterpret<Divider<ulong3>, Divider<T>>();
                        }
                        else
                        {
                            return CreateFromData(*(ulong3*)((ulong*)&Divider._divisor + index),
                                                  *(ulong3*)((ulong*)&Divider._bigM._mulLo  + 2 * index),
                                                  *((ulong3*)((ulong*)&Divider._bigM._mulLo + 2 * index) + 1),
                                                  *(ulong3*)((ulong*)&Divider._mulShift._mul    + index),
                                                  *(ulong3*)((ulong*)&Divider._mulShift._shift + index),
                                                  sizeof(ulong),
                                                  3,
                                                  sign,
                                                  Divider._promises).Reinterpret<Divider<ulong3>, Divider<T>>();
                        }
                    }
                }

                default: throw new InvalidCastException();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Divider<T> GetInnerDivider64Base<T>(Divider<ulong3> Divider, int index, Signedness sign)
            where T : unmanaged, IEquatable<T>, IFormattable
        {
Assert.IsWithinArrayBounds(index, 4 - sizeof(T) / sizeof(ulong));

            switch (sizeof(T))
            {
                case 1 * sizeof(ulong):
                {
                    return CreateFromData(Divider.Divisor[index], ((ulong*)&Divider._bigM._mulLo)[2 * index], ((ulong*)&Divider._bigM._mulLo)[2 * index + 1], Divider._mulShift._mul[index], Divider._mulShift._shift[index], sizeof(ulong), 1, sign, Divider._promises).Reinterpret<Divider<ulong>, Divider<T>>();
                }
                case 2 * sizeof(ulong):
                {
                    if (constexpr.IS_CONST(index))
                    {
                        switch (index)
                        {
                            case 0:  return CreateFromData(Divider.Divisor.xy, *(ulong2*)((ulong*)&Divider._bigM._mulLo  + 2 * index), *((ulong2*)((ulong*)&Divider._bigM._mulLo + 2 * index) + 1), Divider._mulShift._mul.xy,  Divider._mulShift._shift.xy, sizeof(ulong), 2, sign, Divider._promises).Reinterpret<Divider<ulong2>, Divider<T>>();
                            case 1:  return CreateFromData(Divider.Divisor.yz, *(ulong2*)((ulong*)&Divider._bigM._mulLo  + 2 * index), *((ulong2*)((ulong*)&Divider._bigM._mulLo + 2 * index) + 1), Divider._mulShift._mul.yz,  Divider._mulShift._shift.yz, sizeof(ulong), 2, sign, Divider._promises).Reinterpret<Divider<ulong2>, Divider<T>>();

                            default: throw Assert.Unreachable();
                        }
                    }
                    else
                    {
                        if (Avx2.IsAvx2Supported)
                        {
                            return CreateFromData((ulong2)Avx.mm256_castsi256_si128(Xse.mm256_bsrli_si256(Divider.Divisor, sizeof(ulong) * index)),
                                                  *(ulong2*)((ulong*)&Divider._bigM._mulLo  + 2 * index),
                                                  *((ulong2*)((ulong*)&Divider._bigM._mulLo + 2 * index) + 1),
                                                  (ulong2)Avx.mm256_castsi256_si128(Xse.mm256_bsrli_si256(Divider._mulShift._mul,    sizeof(ulong) * index)),
                                                  (ulong2)Avx.mm256_castsi256_si128(Xse.mm256_bsrli_si256(Divider._mulShift._shift, sizeof(ulong) * index)),
                                                  sizeof(ulong),
                                                  2,
                                                  sign,
                                                  Divider._promises).Reinterpret<Divider<ulong2>, Divider<T>>();
                        }
                        else
                        {
                            return CreateFromData(*(ulong2*)((ulong*)&Divider._divisor + index),
                                                  *(ulong2*)((ulong*)&Divider._bigM._mulLo  + 2 * index),
                                                  *((ulong2*)((ulong*)&Divider._bigM._mulLo + 2 * index) + 1),
                                                  *(ulong2*)((ulong*)&Divider._mulShift._mul    + index),
                                                  *(ulong2*)((ulong*)&Divider._mulShift._shift + index),
                                                  sizeof(ulong),
                                                  2,
                                                  sign,
                                                  Divider._promises).Reinterpret<Divider<ulong2>, Divider<T>>();
                        }
                    }
                }

                default: throw new InvalidCastException();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Divider<T> GetInnerDivider64Base<T>(Divider<ulong2> Divider, int index, Signedness sign)
            where T : unmanaged, IEquatable<T>, IFormattable
        {
Assert.IsWithinArrayBounds(index, 3 - sizeof(T) / sizeof(ulong));

            return CreateFromData(Divider.Divisor[index], ((ulong*)&Divider._bigM._mulLo)[2 * index], ((ulong*)&Divider._bigM._mulLo)[2 * index + 1], Divider._mulShift._mul[index], Divider._mulShift._shift[index], sizeof(ulong), 1, sign, Divider._promises).Reinterpret<Divider<ulong>, Divider<T>>();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Divider<T> GetInnerDivider<T>(this Divider<byte32> Divider, int index)
            where T : unmanaged, IEquatable<T>, IFormattable
        {
            return GetInnerDivider8Base<T>(Divider, index, Signedness.Unsigned);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Divider<T> GetInnerDivider<T>(this Divider<byte16> Divider, int index)
            where T : unmanaged, IEquatable<T>, IFormattable
        {
            return GetInnerDivider8Base<T>(Divider, index, Signedness.Unsigned);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Divider<T> GetInnerDivider<T>(this Divider<byte8> Divider, int index)
            where T : unmanaged, IEquatable<T>, IFormattable
        {
            return GetInnerDivider8Base<T>(Divider, index, Signedness.Unsigned);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Divider<T> GetInnerDivider<T>(this Divider<byte4> Divider, int index)
            where T : unmanaged, IEquatable<T>, IFormattable
        {
            return GetInnerDivider8Base<T>(Divider, index, Signedness.Unsigned);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Divider<T> GetInnerDivider<T>(this Divider<byte3> Divider, int index)
            where T : unmanaged, IEquatable<T>, IFormattable
        {
            return GetInnerDivider8Base<T>(Divider, index, Signedness.Unsigned);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Divider<T> GetInnerDivider<T>(this Divider<byte2> Divider, int index)
            where T : unmanaged, IEquatable<T>, IFormattable
        {
            return GetInnerDivider8Base<T>(Divider, index, Signedness.Unsigned);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Divider<T> GetInnerDivider<T>(this Divider<ushort16> Divider, int index)
            where T : unmanaged, IEquatable<T>, IFormattable
        {
            return GetInnerDivider16Base<T>(Divider, index, Signedness.Unsigned);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Divider<T> GetInnerDivider<T>(this Divider<ushort8> Divider, int index)
            where T : unmanaged, IEquatable<T>, IFormattable
        {
            return GetInnerDivider16Base<T>(Divider, index, Signedness.Unsigned);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Divider<T> GetInnerDivider<T>(this Divider<ushort4> Divider, int index)
            where T : unmanaged, IEquatable<T>, IFormattable
        {
            return GetInnerDivider16Base<T>(Divider, index, Signedness.Unsigned);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Divider<T> GetInnerDivider<T>(this Divider<ushort3> Divider, int index)
            where T : unmanaged, IEquatable<T>, IFormattable
        {
            return GetInnerDivider16Base<T>(Divider, index, Signedness.Unsigned);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Divider<T> GetInnerDivider<T>(this Divider<ushort2> Divider, int index)
            where T : unmanaged, IEquatable<T>, IFormattable
        {
            return GetInnerDivider16Base<T>(Divider, index, Signedness.Unsigned);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Divider<T> GetInnerDivider<T>(this Divider<uint8> Divider, int index)
            where T : unmanaged, IEquatable<T>, IFormattable
        {
            return GetInnerDivider32Base<T>(Divider, index, Signedness.Unsigned);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Divider<T> GetInnerDivider<T>(this Divider<uint4> Divider, int index)
            where T : unmanaged, IEquatable<T>, IFormattable
        {
            return GetInnerDivider32Base<T>(Divider, index, Signedness.Unsigned);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Divider<T> GetInnerDivider<T>(this Divider<uint3> Divider, int index)
            where T : unmanaged, IEquatable<T>, IFormattable
        {
            return GetInnerDivider32Base<T>(Divider, index, Signedness.Unsigned);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Divider<T> GetInnerDivider<T>(this Divider<uint2> Divider, int index)
            where T : unmanaged, IEquatable<T>, IFormattable
        {
            return GetInnerDivider32Base<T>(Divider, index, Signedness.Unsigned);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Divider<T> GetInnerDivider<T>(this Divider<ulong4> Divider, int index)
            where T : unmanaged, IEquatable<T>, IFormattable
        {
            return GetInnerDivider64Base<T>(Divider, index, Signedness.Unsigned);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Divider<T> GetInnerDivider<T>(this Divider<ulong3> Divider, int index)
            where T : unmanaged, IEquatable<T>, IFormattable
        {
            return GetInnerDivider64Base<T>(Divider, index, Signedness.Unsigned);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Divider<T> GetInnerDivider<T>(this Divider<ulong2> Divider, int index)
            where T : unmanaged, IEquatable<T>, IFormattable
        {
            return GetInnerDivider64Base<T>(Divider, index, Signedness.Unsigned);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Divider<T> GetInnerDivider<T>(this Divider<sbyte32> Divider, int index)
            where T : unmanaged, IEquatable<T>, IFormattable
        {
            return GetInnerDivider8Base<T>(Divider.Reinterpret<Divider<sbyte32>, Divider<byte32>>(), index, Signedness.Signed);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Divider<T> GetInnerDivider<T>(this Divider<sbyte16> Divider, int index)
            where T : unmanaged, IEquatable<T>, IFormattable
        {
            return GetInnerDivider8Base<T>(Divider.Reinterpret<Divider<sbyte16>, Divider<byte16>>(), index, Signedness.Signed);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Divider<T> GetInnerDivider<T>(this Divider<sbyte8> Divider, int index)
            where T : unmanaged, IEquatable<T>, IFormattable
        {
            return GetInnerDivider8Base<T>(Divider.Reinterpret<Divider<sbyte8>, Divider<byte8>>(), index, Signedness.Signed);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Divider<T> GetInnerDivider<T>(this Divider<sbyte4> Divider, int index)
            where T : unmanaged, IEquatable<T>, IFormattable
        {
            return GetInnerDivider8Base<T>(Divider.Reinterpret<Divider<sbyte4>, Divider<byte4>>(), index, Signedness.Signed);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Divider<T> GetInnerDivider<T>(this Divider<sbyte3> Divider, int index)
            where T : unmanaged, IEquatable<T>, IFormattable
        {
            return GetInnerDivider8Base<T>(Divider.Reinterpret<Divider<sbyte3>, Divider<byte3>>(), index, Signedness.Signed);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Divider<T> GetInnerDivider<T>(this Divider<sbyte2> Divider, int index)
            where T : unmanaged, IEquatable<T>, IFormattable
        {
            return GetInnerDivider8Base<T>(Divider.Reinterpret<Divider<sbyte2>, Divider<byte2>>(), index, Signedness.Signed);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Divider<T> GetInnerDivider<T>(this Divider<short16> Divider, int index)
            where T : unmanaged, IEquatable<T>, IFormattable
        {
            return GetInnerDivider16Base<T>(Divider.Reinterpret<Divider<short16>, Divider<ushort16>>(), index, Signedness.Signed);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Divider<T> GetInnerDivider<T>(this Divider<short8> Divider, int index)
            where T : unmanaged, IEquatable<T>, IFormattable
        {
            return GetInnerDivider16Base<T>(Divider.Reinterpret<Divider<short8>, Divider<ushort8>>(), index, Signedness.Signed);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Divider<T> GetInnerDivider<T>(this Divider<short4> Divider, int index)
            where T : unmanaged, IEquatable<T>, IFormattable
        {
            return GetInnerDivider16Base<T>(Divider.Reinterpret<Divider<short4>, Divider<ushort4>>(), index, Signedness.Signed);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Divider<T> GetInnerDivider<T>(this Divider<short3> Divider, int index)
            where T : unmanaged, IEquatable<T>, IFormattable
        {
            return GetInnerDivider16Base<T>(Divider.Reinterpret<Divider<short3>, Divider<ushort3>>(), index, Signedness.Signed);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Divider<T> GetInnerDivider<T>(this Divider<short2> Divider, int index)
            where T : unmanaged, IEquatable<T>, IFormattable
        {
            return GetInnerDivider16Base<T>(Divider.Reinterpret<Divider<short2>, Divider<ushort2>>(), index, Signedness.Signed);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Divider<T> GetInnerDivider<T>(this Divider<int8> Divider, int index)
            where T : unmanaged, IEquatable<T>, IFormattable
        {
            return GetInnerDivider32Base<T>(Divider.Reinterpret<Divider<int8>, Divider<uint8>>(), index, Signedness.Signed);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Divider<T> GetInnerDivider<T>(this Divider<int4> Divider, int index)
            where T : unmanaged, IEquatable<T>, IFormattable
        {
            return GetInnerDivider32Base<T>(Divider.Reinterpret<Divider<int4>, Divider<uint4>>(), index, Signedness.Signed);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Divider<T> GetInnerDivider<T>(this Divider<int3> Divider, int index)
            where T : unmanaged, IEquatable<T>, IFormattable
        {
            return GetInnerDivider32Base<T>(Divider.Reinterpret<Divider<int3>, Divider<uint3>>(), index, Signedness.Signed);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Divider<T> GetInnerDivider<T>(this Divider<int2> Divider, int index)
            where T : unmanaged, IEquatable<T>, IFormattable
        {
            return GetInnerDivider32Base<T>(Divider.Reinterpret<Divider<int2>, Divider<uint2>>(), index, Signedness.Signed);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Divider<T> GetInnerDivider<T>(this Divider<long4> Divider, int index)
            where T : unmanaged, IEquatable<T>, IFormattable
        {
            return GetInnerDivider64Base<T>(Divider.Reinterpret<Divider<long4>, Divider<ulong4>>(), index, Signedness.Signed);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Divider<T> GetInnerDivider<T>(this Divider<long3> Divider, int index)
            where T : unmanaged, IEquatable<T>, IFormattable
        {
            return GetInnerDivider64Base<T>(Divider.Reinterpret<Divider<long3>, Divider<ulong3>>(), index, Signedness.Signed);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Divider<T> GetInnerDivider<T>(this Divider<long2> Divider, int index)
            where T : unmanaged, IEquatable<T>, IFormattable
        {
            return GetInnerDivider64Base<T>(Divider.Reinterpret<Divider<long2>, Divider<ulong2>>(), index, Signedness.Signed);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void SetInnerDividerBase(ref this Divider<byte2> Divider, Divider<byte> value, int index, Signedness sign)
        {
Assert.IsWithinArrayBounds(index, 2);

            Divider._divisor[index] = value._divisor;

            Divider._bigM.SetField(value._bigM, index);

            Divider._promises = (Divider._promises & value._promises) | new Divider<byte2>.DividerPromise(Divider._divisor, sign, sizeof(byte));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void SetInnerDividerBase(ref this Divider<byte3> Divider, Divider<byte> value, int index, Signedness sign)
        {
Assert.IsWithinArrayBounds(index, 3);

            Divider._divisor[index] = value._divisor;

            Divider._bigM.SetField(value._bigM, index);

            Divider._promises = (Divider._promises & value._promises) | new Divider<byte3>.DividerPromise(Divider._divisor, sign, sizeof(byte));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void SetInnerDividerBase(ref this Divider<byte3> Divider, Divider<byte2> value, int index, Signedness sign)
        {
Assert.IsWithinArrayBounds(index, 2);

            ushort3 oldBigM = Divider._bigM.Reinterpret<Divider<byte3>.BigM, ushort3>();

            if (constexpr.IS_CONST(index))
            {
                switch (index)
                {
                    case 0:
                    {
                        Divider._divisor.xy = value._divisor;
                        oldBigM.xy = value._bigM.Reinterpret<Divider<byte2>.BigM, ushort2>();

                        break;
                    }
                    case 1:
                    {
                        Divider._divisor.yz = value._divisor;
                        oldBigM.yz = value._bigM.Reinterpret<Divider<byte2>.BigM, ushort2>();

                        break;
                    }
                    default: throw Assert.Unreachable();
                }

                Divider._bigM = oldBigM.Reinterpret<ushort3, Divider<byte3>.BigM>();
            }
            else
            {
                byte3 oldDivisor = Divider._divisor;

                if (Architecture.IsSIMDSupported)
                {
                    v128 divisorMask = Xse.bslli_si128(Xse.cvtsi32_si128(bitmask32(8 * sizeof(byte2))),   index * sizeof(byte));
                    v128 alignedDivisor = Xse.bslli_si128(value._divisor, index * sizeof(byte));
                    oldDivisor = Xse.blendv_si128(oldDivisor, alignedDivisor, divisorMask);

                    v128 bigMMask  = Xse.bslli_si128(Xse.cvtsi32_si128(bitmask32(8 * sizeof(ushort2))), index * sizeof(ushort));
                    v128 alignedBigM  = Xse.bslli_si128(*(ushort2*)&value._bigM, index * sizeof(ushort));
                    oldBigM  = Xse.blendv_si128(oldBigM, alignedBigM, bigMMask);
                }
                else
                {
                    oldDivisor.SetField(value._divisor, index, sizeof(byte));
                    oldBigM.SetField(value._bigM, index, sizeof(ushort));
                }

                Divider._divisor = oldDivisor;
                Divider._bigM  = oldBigM.Reinterpret<ushort3, Divider<byte3>.BigM>();
            }

            Divider._promises = (Divider._promises & value._promises) | new Divider<byte3>.DividerPromise(Divider._divisor, sign, sizeof(byte));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void SetInnerDividerBase(ref this Divider<byte4> Divider, Divider<byte> value, int index, Signedness sign)
        {
Assert.IsWithinArrayBounds(index, 4);

            Divider._divisor[index] = value._divisor;

            Divider._bigM.SetField(value._bigM, index);

            Divider._promises = (Divider._promises & value._promises) | new Divider<byte4>.DividerPromise(Divider._divisor, sign, sizeof(byte));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void SetInnerDividerBase(ref this Divider<byte4> Divider, Divider<byte2> value, int index, Signedness sign)
        {
Assert.IsWithinArrayBounds(index, 3);

            ushort4 oldBigM = Divider._bigM.Reinterpret<Divider<byte4>.BigM, ushort4>();

            if (constexpr.IS_CONST(index))
            {
                switch (index)
                {
                    case 0:
                    {
                        Divider._divisor.xy = value._divisor;
                        oldBigM.xy = value._bigM.Reinterpret<Divider<byte2>.BigM, ushort2>();

                        break;
                    }
                    case 1:
                    {
                        Divider._divisor.yz = value._divisor;
                        oldBigM.yz = value._bigM.Reinterpret<Divider<byte2>.BigM, ushort2>();

                        break;
                    }
                    case 2:
                    {
                        Divider._divisor.zw = value._divisor;
                        oldBigM.zw = value._bigM.Reinterpret<Divider<byte2>.BigM, ushort2>();

                        break;
                    }
                    default: throw Assert.Unreachable();
                }

                Divider._bigM = oldBigM.Reinterpret<ushort4, Divider<byte4>.BigM>();
            }
            else
            {
                byte4 oldDivisor = Divider._divisor;

                if (Architecture.IsSIMDSupported)
                {
                    v128 divisorMask = Xse.bslli_si128(Xse.cvtsi32_si128(bitmask32(8 * sizeof(byte2))),   index * sizeof(byte));
                    v128 alignedDivisor = Xse.bslli_si128(value._divisor, index * sizeof(byte));
                    oldDivisor = Xse.blendv_si128(oldDivisor, alignedDivisor, divisorMask);

                    v128 bigMMask = Xse.bslli_si128(Xse.cvtsi32_si128(bitmask32(8 * sizeof(ushort2))), index * sizeof(ushort));
                    v128 alignedBigM = Xse.bslli_si128(*(ushort2*)&value._bigM, index * sizeof(ushort));
                    oldBigM = Xse.blendv_si128(oldBigM, alignedBigM, bigMMask);
                }
                else
                {
                    oldDivisor.SetField(value._divisor, index, sizeof(byte));
                    oldBigM.SetField(value._bigM, index, sizeof(ushort));
                }

                Divider._divisor = oldDivisor;
                Divider._bigM  = oldBigM.Reinterpret<ushort4, Divider<byte4>.BigM>();
            }

            Divider._promises = (Divider._promises & value._promises) | new Divider<byte4>.DividerPromise(Divider._divisor, sign, sizeof(byte));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void SetInnerDividerBase(ref this Divider<byte4> Divider, Divider<byte3> value, int index, Signedness sign)
        {
Assert.IsWithinArrayBounds(index, 2);

            ushort4 oldBigM = Divider._bigM.Reinterpret<Divider<byte4>.BigM, ushort4>();

            if (constexpr.IS_CONST(index))
            {
                switch (index)
                {
                    case 0:
                    {
                        Divider._divisor.xyz = value._divisor;
                        oldBigM.xyz = value._bigM.Reinterpret<Divider<byte3>.BigM, ushort3>();

                        break;
                    }
                    case 1:
                    {
                        Divider._divisor.yzw = value._divisor;
                        oldBigM.yzw = value._bigM.Reinterpret<Divider<byte3>.BigM, ushort3>();

                        break;
                    }
                    default: throw Assert.Unreachable();
                }

                Divider._bigM = oldBigM.Reinterpret<ushort4, Divider<byte4>.BigM>();
            }
            else
            {
                byte4 oldDivisor = Divider._divisor;

                if (Architecture.IsSIMDSupported)
                {
                    v128 divisorMask = Xse.bslli_si128(Xse.cvtsi32_si128( bitmask32(8 * sizeof(byte3))),   index * sizeof(byte));
                    v128 alignedDivisor = Xse.bslli_si128(value._divisor, index * sizeof(byte));
                    oldDivisor = Xse.blendv_si128(oldDivisor, alignedDivisor, divisorMask);

                    v128 bigMMask = Xse.bslli_si128(Xse.cvtsi64x_si128(bitmask64(8 * sizeof(ushort3))), index * sizeof(ushort));
                    v128 alignedBigM = Xse.bslli_si128(*(ushort3*)&value._bigM, index * sizeof(ushort));
                    oldBigM = Xse.blendv_si128(oldBigM, alignedBigM, bigMMask);
                }
                else
                {
                    oldDivisor.SetField(value._divisor, index, sizeof(byte));
                    oldBigM.SetField(value._bigM, index, sizeof(ushort));
                }

                Divider._divisor = oldDivisor;
                Divider._bigM  = oldBigM.Reinterpret<ushort4, Divider<byte4>.BigM>();
            }

            Divider._promises = (Divider._promises & value._promises) | new Divider<byte4>.DividerPromise(Divider._divisor, sign, sizeof(byte));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void SetInnerDividerBase(ref this Divider<byte8> Divider, Divider<byte> value, int index, Signedness sign)
        {
Assert.IsWithinArrayBounds(index, 8);

            Divider._divisor[index] = value._divisor;

            Divider._bigM.SetField(value._bigM, index);

            Divider._promises = (Divider._promises & value._promises) | new Divider<byte8>.DividerPromise(Divider._divisor, sign, sizeof(byte));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void SetInnerDividerBase(ref this Divider<byte8> Divider, Divider<byte2> value, int index, Signedness sign)
        {
Assert.IsWithinArrayBounds(index, 7);

            ushort8 oldBigM = Divider._bigM.Reinterpret<Divider<byte8>.BigM, ushort8>();

            if (constexpr.IS_CONST(index))
            {
                switch (index)
                {
                    case 0:
                    {
                        Divider._divisor.v2_0 = value._divisor;
                        oldBigM.v2_0 = value._bigM.Reinterpret<Divider<byte2>.BigM, ushort2>();

                        break;
                    }
                    case 1:
                    {
                        Divider._divisor.v2_1 = value._divisor;
                        oldBigM.v2_1 = value._bigM.Reinterpret<Divider<byte2>.BigM, ushort2>();

                        break;
                    }
                    case 2:
                    {
                        Divider._divisor.v2_2 = value._divisor;
                        oldBigM.v2_2 = value._bigM.Reinterpret<Divider<byte2>.BigM, ushort2>();

                        break;
                    }
                    case 3:
                    {
                        Divider._divisor.v2_3 = value._divisor;
                        oldBigM.v2_3 = value._bigM.Reinterpret<Divider<byte2>.BigM, ushort2>();

                        break;
                    }
                    case 4:
                    {
                        Divider._divisor.v2_4 = value._divisor;
                        oldBigM.v2_4 = value._bigM.Reinterpret<Divider<byte2>.BigM, ushort2>();

                        break;
                    }
                    case 5:
                    {
                        Divider._divisor.v2_5 = value._divisor;
                        oldBigM.v2_5 = value._bigM.Reinterpret<Divider<byte2>.BigM, ushort2>();

                        break;
                    }
                    case 6:
                    {
                        Divider._divisor.v2_6 = value._divisor;
                        oldBigM.v2_6 = value._bigM.Reinterpret<Divider<byte2>.BigM, ushort2>();

                        break;
                    }
                    default: throw Assert.Unreachable();
                }

                Divider._bigM = oldBigM.Reinterpret<ushort8, Divider<byte8>.BigM>();
            }
            else
            {
                byte8 oldDivisor = Divider._divisor;

                if (Architecture.IsSIMDSupported)
                {
                    v128 divisorMask = Xse.bslli_si128(Xse.cvtsi32_si128(bitmask32(8 * sizeof(byte2))),   index * sizeof(byte));
                    v128 alignedDivisor = Xse.bslli_si128(value._divisor, index * sizeof(byte));
                    oldDivisor = Xse.blendv_si128(oldDivisor, alignedDivisor, divisorMask);

                    v128 bigMMask = Xse.bslli_si128(Xse.cvtsi32_si128(bitmask32(8 * sizeof(ushort2))), index * sizeof(ushort));
                    v128 alignedBigM = Xse.bslli_si128(*(ushort2*)&value._bigM, index * sizeof(ushort));
                    oldBigM = Xse.blendv_si128(oldBigM, alignedBigM, bigMMask);
                }
                else
                {
                    oldDivisor.SetField(value._divisor, index, sizeof(byte));
                    oldBigM.SetField(value._bigM, index, sizeof(ushort));
                }

                Divider._divisor = oldDivisor;
                Divider._bigM  = oldBigM.Reinterpret<ushort8, Divider<byte8>.BigM>();
            }

            Divider._promises = (Divider._promises & value._promises) | new Divider<byte8>.DividerPromise(Divider._divisor, sign, sizeof(byte));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void SetInnerDividerBase(ref this Divider<byte8> Divider, Divider<byte3> value, int index, Signedness sign)
        {
Assert.IsWithinArrayBounds(index, 6);

            ushort8 oldBigM = Divider._bigM.Reinterpret<Divider<byte8>.BigM, ushort8>();

            if (constexpr.IS_CONST(index))
            {
                switch (index)
                {
                    case 0:
                    {
                        Divider._divisor.v3_0 = value._divisor;
                        oldBigM.v3_0 = value._bigM.Reinterpret<Divider<byte3>.BigM, ushort3>();

                        break;
                    }
                    case 1:
                    {
                        Divider._divisor.v3_1 = value._divisor;
                        oldBigM.v3_1 = value._bigM.Reinterpret<Divider<byte3>.BigM, ushort3>();

                        break;
                    }
                    case 2:
                    {
                        Divider._divisor.v3_2 = value._divisor;
                        oldBigM.v3_2 = value._bigM.Reinterpret<Divider<byte3>.BigM, ushort3>();

                        break;
                    }
                    case 3:
                    {
                        Divider._divisor.v3_3 = value._divisor;
                        oldBigM.v3_3 = value._bigM.Reinterpret<Divider<byte3>.BigM, ushort3>();

                        break;
                    }
                    case 4:
                    {
                        Divider._divisor.v3_4 = value._divisor;
                        oldBigM.v3_4 = value._bigM.Reinterpret<Divider<byte3>.BigM, ushort3>();

                        break;
                    }
                    case 5:
                    {
                        Divider._divisor.v3_5 = value._divisor;
                        oldBigM.v3_5 = value._bigM.Reinterpret<Divider<byte3>.BigM, ushort3>();

                        break;
                    }
                    default: throw Assert.Unreachable();
                }

                Divider._bigM = oldBigM.Reinterpret<ushort8, Divider<byte8>.BigM>();
            }
            else
            {
                byte8 oldDivisor = Divider._divisor;

                if (Architecture.IsSIMDSupported)
                {
                    v128 divisorMask = Xse.bslli_si128(Xse.cvtsi32_si128 (bitmask32(8 * sizeof(byte3))),   index * sizeof(byte));
                    v128 alignedDivisor = Xse.bslli_si128(value._divisor, index * sizeof(byte));
                    oldDivisor = Xse.blendv_si128(oldDivisor, alignedDivisor, divisorMask);

                    v128 bigMMask = Xse.bslli_si128(Xse.cvtsi64x_si128(bitmask64(8 * sizeof(ushort3))), index * sizeof(ushort));
                    v128 alignedBigM = Xse.bslli_si128(*(ushort3*)&value._bigM, index * sizeof(ushort));
                    oldBigM = Xse.blendv_si128(oldBigM, alignedBigM,    bigMMask);
                }
                else
                {
                    oldDivisor.SetField(value._divisor, index, sizeof(byte));
                    oldBigM.SetField(value._bigM, index, sizeof(ushort));
                }

                Divider._divisor = oldDivisor;
                Divider._bigM  = oldBigM.Reinterpret<ushort8, Divider<byte8>.BigM>();
            }

            Divider._promises = (Divider._promises & value._promises) | new Divider<byte8>.DividerPromise(Divider._divisor, sign, sizeof(byte));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void SetInnerDividerBase(ref this Divider<byte8> Divider, Divider<byte4> value, int index, Signedness sign)
        {
Assert.IsWithinArrayBounds(index, 5);

            ushort8 oldBigM = Divider._bigM.Reinterpret<Divider<byte8>.BigM, ushort8>();

            if (constexpr.IS_CONST(index))
            {
                switch (index)
                {
                    case 0:
                    {
                        Divider._divisor.v4_0 = value._divisor;
                        oldBigM.v4_0 = value._bigM.Reinterpret<Divider<byte4>.BigM, ushort4>();

                        break;
                    }
                    case 1:
                    {
                        Divider._divisor.v4_1 = value._divisor;
                        oldBigM.v4_1 = value._bigM.Reinterpret<Divider<byte4>.BigM, ushort4>();

                        break;
                    }
                    case 2:
                    {
                        Divider._divisor.v4_2 = value._divisor;
                        oldBigM.v4_2 = value._bigM.Reinterpret<Divider<byte4>.BigM, ushort4>();

                        break;
                    }
                    case 3:
                    {
                        Divider._divisor.v4_3 = value._divisor;
                        oldBigM.v4_3 = value._bigM.Reinterpret<Divider<byte4>.BigM, ushort4>();

                        break;
                    }
                    case 4:
                    {
                        Divider._divisor.v4_4 = value._divisor;
                        oldBigM.v4_4 = value._bigM.Reinterpret<Divider<byte4>.BigM, ushort4>();

                        break;
                    }
                    default: throw Assert.Unreachable();
                }

                Divider._bigM = oldBigM.Reinterpret<ushort8, Divider<byte8>.BigM>();
            }
            else
            {
                byte8 oldDivisor = Divider._divisor;

                if (Architecture.IsSIMDSupported)
                {
                    v128 divisorMask = Xse.bslli_si128(Xse.cvtsi32_si128 (bitmask32(8 * sizeof(byte4))),   index * sizeof(byte));
                    v128 alignedDivisor = Xse.bslli_si128(value._divisor, index * sizeof(byte));
                    oldDivisor = Xse.blendv_si128(oldDivisor, alignedDivisor, divisorMask);

                    v128 bigMMask = Xse.bslli_si128(Xse.cvtsi64x_si128(bitmask64(8 * sizeof(ushort4))), index * sizeof(ushort));
                    v128 alignedBigM = Xse.bslli_si128(*(ushort4*)&value._bigM, index * sizeof(ushort));
                    oldBigM = Xse.blendv_si128(oldBigM, alignedBigM, bigMMask);
                }
                else
                {
                    oldDivisor.SetField(value._divisor, index, sizeof(byte));
                    oldBigM.SetField(value._bigM, index, sizeof(ushort));
                }

                Divider._divisor = oldDivisor;
                Divider._bigM  = oldBigM.Reinterpret<ushort8, Divider<byte8>.BigM>();
            }

            Divider._promises = (Divider._promises & value._promises) | new Divider<byte8>.DividerPromise(Divider._divisor, sign, sizeof(byte));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void SetInnerDividerBase(ref this Divider<byte16> Divider, Divider<byte> value, int index, Signedness sign)
        {
Assert.IsWithinArrayBounds(index, 16);

            Divider._divisor[index] = value._divisor;

            Divider._bigM.SetField(value._bigM, index);

            Divider._promises = (Divider._promises & value._promises) | new Divider<byte16>.DividerPromise(Divider._divisor, sign, sizeof(byte));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void SetInnerDividerBase(ref this Divider<byte16> Divider, Divider<byte2> value, int index, Signedness sign)
        {
Assert.IsWithinArrayBounds(index, 15);

            ushort16 oldBigM = Divider._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>();

            if (constexpr.IS_CONST(index))
            {
                switch (index)
                {
                    case 0:
                    {
                        Divider._divisor.v2_0 = value._divisor;
                        oldBigM.v2_0 = value._bigM.Reinterpret<Divider<byte2>.BigM, ushort2>();

                        break;
                    }
                    case 1:
                    {
                        Divider._divisor.v2_1 = value._divisor;
                        oldBigM.v2_1 = value._bigM.Reinterpret<Divider<byte2>.BigM, ushort2>();

                        break;
                    }
                    case 2:
                    {
                        Divider._divisor.v2_2 = value._divisor;
                        oldBigM.v2_2 = value._bigM.Reinterpret<Divider<byte2>.BigM, ushort2>();

                        break;
                    }
                    case 3:
                    {
                        Divider._divisor.v2_3 = value._divisor;
                        oldBigM.v2_3 = value._bigM.Reinterpret<Divider<byte2>.BigM, ushort2>();

                        break;
                    }
                    case 4:
                    {
                        Divider._divisor.v2_4 = value._divisor;
                        oldBigM.v2_4 = value._bigM.Reinterpret<Divider<byte2>.BigM, ushort2>();

                        break;
                    }
                    case 5:
                    {
                        Divider._divisor.v2_5 = value._divisor;
                        oldBigM.v2_5 = value._bigM.Reinterpret<Divider<byte2>.BigM, ushort2>();

                        break;
                    }
                    case 6:
                    {
                        Divider._divisor.v2_6 = value._divisor;
                        oldBigM.v2_6 = value._bigM.Reinterpret<Divider<byte2>.BigM, ushort2>();

                        break;
                    }
                    case 7:
                    {
                        Divider._divisor.v2_7 = value._divisor;
                        oldBigM.v2_7 = value._bigM.Reinterpret<Divider<byte2>.BigM, ushort2>();

                        break;
                    }
                    case 8:
                    {
                        Divider._divisor.v2_8 = value._divisor;
                        oldBigM.v2_8 = value._bigM.Reinterpret<Divider<byte2>.BigM, ushort2>();

                        break;
                    }
                    case 9:
                    {
                        Divider._divisor.v2_9 = value._divisor;
                        oldBigM.v2_9 = value._bigM.Reinterpret<Divider<byte2>.BigM, ushort2>();

                        break;
                    }
                    case 10:
                    {
                        Divider._divisor.v2_10 = value._divisor;
                        oldBigM.v2_10 = value._bigM.Reinterpret<Divider<byte2>.BigM, ushort2>();

                        break;
                    }
                    case 11:
                    {
                        Divider._divisor.v2_11 = value._divisor;
                        oldBigM.v2_11 = value._bigM.Reinterpret<Divider<byte2>.BigM, ushort2>();

                        break;
                    }
                    case 12:
                    {
                        Divider._divisor.v2_12 = value._divisor;
                        oldBigM.v2_12 = value._bigM.Reinterpret<Divider<byte2>.BigM, ushort2>();

                        break;
                    }
                    case 13:
                    {
                        Divider._divisor.v2_13 = value._divisor;
                        oldBigM.v2_13 = value._bigM.Reinterpret<Divider<byte2>.BigM, ushort2>();

                        break;
                    }
                    case 14:
                    {
                        Divider._divisor.v2_14 = value._divisor;
                        oldBigM.v2_14 = value._bigM.Reinterpret<Divider<byte2>.BigM, ushort2>();

                        break;
                    }
                    default: throw Assert.Unreachable();
                }

                Divider._bigM = oldBigM.Reinterpret<ushort16, Divider<byte16>.BigM>();
            }
            else
            {
                byte16 oldDivisor = Divider._divisor;

                if (Architecture.IsSIMDSupported)
                {
                    v128 divisorMask = Xse.bslli_si128(Xse.cvtsi32_si128(bitmask32(8 * sizeof(byte2))), index * sizeof(byte));
                    v128 alignedDivisor = Xse.bslli_si128(value._divisor, index * sizeof(byte));

                    oldDivisor = Xse.blendv_si128(oldDivisor, alignedDivisor, divisorMask);

                    if (Avx2.IsAvx2Supported)
                    {
                        v256 bigMMask = Xse.mm256_bslli_si256(Xse.mm256_cvtsi32_si256(bitmask32(8 * sizeof(ushort2))), index * sizeof(ushort));
                        v256 alignedBigM = Xse.mm256_bslli_si256(Avx.mm256_castsi128_si256(*(ushort2*)&value._bigM), index * sizeof(ushort));

                        oldBigM = Xse.mm256_blendv_si256(oldBigM, alignedBigM, bigMMask);
                    }
                    else
                    {
                        oldBigM.SetField(value._bigM, index, sizeof(ushort));
                    }
                }
                else
                {
                    oldDivisor.SetField(value._divisor, index, sizeof(byte));
                    oldBigM.SetField(value._bigM, index, sizeof(ushort));
                }

                Divider._divisor = oldDivisor;
                Divider._bigM  = oldBigM.Reinterpret<ushort16, Divider<byte16>.BigM>();
            }

            Divider._promises = (Divider._promises & value._promises) | new Divider<byte16>.DividerPromise(Divider._divisor, sign, sizeof(byte));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void SetInnerDividerBase(ref this Divider<byte16> Divider, Divider<byte3> value, int index, Signedness sign)
        {
Assert.IsWithinArrayBounds(index, 14);

            ushort16 oldBigM = Divider._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>();

            if (constexpr.IS_CONST(index))
            {
                switch (index)
                {
                    case 0:
                    {
                        Divider._divisor.v3_0 = value._divisor;
                        oldBigM.v3_0 = value._bigM.Reinterpret<Divider<byte3>.BigM, ushort3>();

                        break;
                    }
                    case 1:
                    {
                        Divider._divisor.v3_1 = value._divisor;
                        oldBigM.v3_1 = value._bigM.Reinterpret<Divider<byte3>.BigM, ushort3>();

                        break;
                    }
                    case 2:
                    {
                        Divider._divisor.v3_2 = value._divisor;
                        oldBigM.v3_2 = value._bigM.Reinterpret<Divider<byte3>.BigM, ushort3>();

                        break;
                    }
                    case 3:
                    {
                        Divider._divisor.v3_3 = value._divisor;
                        oldBigM.v3_3 = value._bigM.Reinterpret<Divider<byte3>.BigM, ushort3>();

                        break;
                    }
                    case 4:
                    {
                        Divider._divisor.v3_4 = value._divisor;
                        oldBigM.v3_4 = value._bigM.Reinterpret<Divider<byte3>.BigM, ushort3>();

                        break;
                    }
                    case 5:
                    {
                        Divider._divisor.v3_5 = value._divisor;
                        oldBigM.v3_5 = value._bigM.Reinterpret<Divider<byte3>.BigM, ushort3>();

                        break;
                    }
                    case 6:
                    {
                        Divider._divisor.v3_6 = value._divisor;
                        oldBigM.v3_6 = value._bigM.Reinterpret<Divider<byte3>.BigM, ushort3>();

                        break;
                    }
                    case 7:
                    {
                        Divider._divisor.v3_7 = value._divisor;
                        oldBigM.v3_7 = value._bigM.Reinterpret<Divider<byte3>.BigM, ushort3>();

                        break;
                    }
                    case 8:
                    {
                        Divider._divisor.v3_8 = value._divisor;
                        oldBigM.v3_8 = value._bigM.Reinterpret<Divider<byte3>.BigM, ushort3>();

                        break;
                    }
                    case 9:
                    {
                        Divider._divisor.v3_9 = value._divisor;
                        oldBigM.v3_9 = value._bigM.Reinterpret<Divider<byte3>.BigM, ushort3>();

                        break;
                    }
                    case 10:
                    {
                        Divider._divisor.v3_10 = value._divisor;
                        oldBigM.v3_10 = value._bigM.Reinterpret<Divider<byte3>.BigM, ushort3>();

                        break;
                    }
                    case 11:
                    {
                        Divider._divisor.v3_11 = value._divisor;
                        oldBigM.v3_11 = value._bigM.Reinterpret<Divider<byte3>.BigM, ushort3>();

                        break;
                    }
                    case 12:
                    {
                        Divider._divisor.v3_12 = value._divisor;
                        oldBigM.v3_12 = value._bigM.Reinterpret<Divider<byte3>.BigM, ushort3>();

                        break;
                    }
                    case 13:
                    {
                        Divider._divisor.v3_13 = value._divisor;
                        oldBigM.v3_13 = value._bigM.Reinterpret<Divider<byte3>.BigM, ushort3>();

                        break;
                    }
                    default: throw Assert.Unreachable();
                }

                Divider._bigM = oldBigM.Reinterpret<ushort16, Divider<byte16>.BigM>();
            }
            else
            {
                byte16 oldDivisor = Divider._divisor;

                if (Architecture.IsSIMDSupported)
                {
                    v128 divisorMask = Xse.bslli_si128(Xse.cvtsi32_si128(bitmask32(8 * sizeof(byte3))), index * sizeof(byte));
                    v128 alignedDivisor = Xse.bslli_si128(value._divisor, index * sizeof(byte));

                    oldDivisor = Xse.blendv_si128(oldDivisor, alignedDivisor, divisorMask);

                    if (Avx2.IsAvx2Supported)
                    {
                        v256 bigMMask = Xse.mm256_bslli_si256(Xse.mm256_cvtsi64x_si256(bitmask64(8 * sizeof(ushort3))), index * sizeof(ushort));
                        v256 alignedBigM = Xse.mm256_bslli_si256(Avx.mm256_castsi128_si256(*(ushort3*)&value._bigM), index * sizeof(ushort));

                        oldBigM = Xse.mm256_blendv_si256(oldBigM, alignedBigM, bigMMask);
                    }
                    else
                    {
                        oldBigM.SetField(value._bigM, index, sizeof(ushort));
                    }
                }
                else
                {
                    oldDivisor.SetField(value._divisor, index, sizeof(byte));
                    oldBigM.SetField(value._bigM, index, sizeof(ushort));
                }

                Divider._divisor = oldDivisor;
                Divider._bigM  = oldBigM.Reinterpret<ushort16, Divider<byte16>.BigM>();
            }

            Divider._promises = (Divider._promises & value._promises) | new Divider<byte16>.DividerPromise(Divider._divisor, sign, sizeof(byte));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void SetInnerDividerBase(ref this Divider<byte16> Divider, Divider<byte4> value, int index, Signedness sign)
        {
Assert.IsWithinArrayBounds(index, 13);

            ushort16 oldBigM = Divider._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>();

            if (constexpr.IS_CONST(index))
            {
                switch (index)
                {
                    case 0:
                    {
                        Divider._divisor.v4_0 = value._divisor;
                        oldBigM.v4_0 = value._bigM.Reinterpret<Divider<byte4>.BigM, ushort4>();

                        break;
                    }
                    case 1:
                    {
                        Divider._divisor.v4_1 = value._divisor;
                        oldBigM.v4_1 = value._bigM.Reinterpret<Divider<byte4>.BigM, ushort4>();

                        break;
                    }
                    case 2:
                    {
                        Divider._divisor.v4_2 = value._divisor;
                        oldBigM.v4_2 = value._bigM.Reinterpret<Divider<byte4>.BigM, ushort4>();

                        break;
                    }
                    case 3:
                    {
                        Divider._divisor.v4_3 = value._divisor;
                        oldBigM.v4_3 = value._bigM.Reinterpret<Divider<byte4>.BigM, ushort4>();

                        break;
                    }
                    case 4:
                    {
                        Divider._divisor.v4_4 = value._divisor;
                        oldBigM.v4_4 = value._bigM.Reinterpret<Divider<byte4>.BigM, ushort4>();

                        break;
                    }
                    case 5:
                    {
                        Divider._divisor.v4_5 = value._divisor;
                        oldBigM.v4_5 = value._bigM.Reinterpret<Divider<byte4>.BigM, ushort4>();

                        break;
                    }
                    case 6:
                    {
                        Divider._divisor.v4_6 = value._divisor;
                        oldBigM.v4_6 = value._bigM.Reinterpret<Divider<byte4>.BigM, ushort4>();

                        break;
                    }
                    case 7:
                    {
                        Divider._divisor.v4_7 = value._divisor;
                        oldBigM.v4_7 = value._bigM.Reinterpret<Divider<byte4>.BigM, ushort4>();

                        break;
                    }
                    case 8:
                    {
                        Divider._divisor.v4_8 = value._divisor;
                        oldBigM.v4_8 = value._bigM.Reinterpret<Divider<byte4>.BigM, ushort4>();

                        break;
                    }
                    case 9:
                    {
                        Divider._divisor.v4_9 = value._divisor;
                        oldBigM.v4_9 = value._bigM.Reinterpret<Divider<byte4>.BigM, ushort4>();

                        break;
                    }
                    case 10:
                    {
                        Divider._divisor.v4_10 = value._divisor;
                        oldBigM.v4_10 = value._bigM.Reinterpret<Divider<byte4>.BigM, ushort4>();

                        break;
                    }
                    case 11:
                    {
                        Divider._divisor.v4_11 = value._divisor;
                        oldBigM.v4_11 = value._bigM.Reinterpret<Divider<byte4>.BigM, ushort4>();

                        break;
                    }
                    case 12:
                    {
                        Divider._divisor.v4_12 = value._divisor;
                        oldBigM.v4_12 = value._bigM.Reinterpret<Divider<byte4>.BigM, ushort4>();

                        break;
                    }
                    default: throw Assert.Unreachable();
                }

                Divider._bigM = oldBigM.Reinterpret<ushort16, Divider<byte16>.BigM>();
            }
            else
            {
                byte16 oldDivisor = Divider._divisor;

                if (Architecture.IsSIMDSupported)
                {
                    v128 divisorMask = Xse.bslli_si128(Xse.cvtsi32_si128(bitmask32(8 * sizeof(byte4))), index * sizeof(byte));
                    v128 alignedDivisor = Xse.bslli_si128(value._divisor, index * sizeof(byte));

                    oldDivisor = Xse.blendv_si128(oldDivisor, alignedDivisor, divisorMask);

                    if (Avx2.IsAvx2Supported)
                    {
                        v256 bigMMask = Xse.mm256_bslli_si256(Xse.mm256_cvtsi64x_si256(bitmask64(8 * sizeof(ushort4))), index * sizeof(ushort));
                        v256 alignedBigM = Xse.mm256_bslli_si256(Avx.mm256_castsi128_si256(*(ushort4*)&value._bigM), index * sizeof(ushort));

                        oldBigM = Xse.mm256_blendv_si256(oldBigM, alignedBigM, bigMMask);
                    }
                    else
                    {
                        oldBigM.SetField(value._bigM, index, sizeof(ushort));
                    }
                }
                else
                {
                    oldDivisor.SetField(value._divisor, index, sizeof(byte));
                    oldBigM.SetField(value._bigM, index, sizeof(ushort));
                }

                Divider._divisor = oldDivisor;
                Divider._bigM  = oldBigM.Reinterpret<ushort16, Divider<byte16>.BigM>();
            }

            Divider._promises = (Divider._promises & value._promises) | new Divider<byte16>.DividerPromise(Divider._divisor, sign, sizeof(byte));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void SetInnerDividerBase(ref this Divider<byte16> Divider, Divider<byte8> value, int index, Signedness sign)
        {
Assert.IsWithinArrayBounds(index, 9);

            ushort16 oldBigM = Divider._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>();

            if (constexpr.IS_CONST(index))
            {
                switch (index)
                {
                    case 0:
                    {
                        Divider._divisor.v8_0 = value._divisor;
                        oldBigM.v8_0 = value._bigM.Reinterpret<Divider<byte8>.BigM, ushort8>();

                        break;
                    }
                    case 1:
                    {
                        Divider._divisor.v8_1 = value._divisor;
                        oldBigM.v8_1 = value._bigM.Reinterpret<Divider<byte8>.BigM, ushort8>();

                        break;
                    }
                    case 2:
                    {
                        Divider._divisor.v8_2 = value._divisor;
                        oldBigM.v8_2 = value._bigM.Reinterpret<Divider<byte8>.BigM, ushort8>();

                        break;
                    }
                    case 3:
                    {
                        Divider._divisor.v8_3 = value._divisor;
                        oldBigM.v8_3 = value._bigM.Reinterpret<Divider<byte8>.BigM, ushort8>();

                        break;
                    }
                    case 4:
                    {
                        Divider._divisor.v8_4 = value._divisor;
                        oldBigM.v8_4 = value._bigM.Reinterpret<Divider<byte8>.BigM, ushort8>();

                        break;
                    }
                    case 5:
                    {
                        Divider._divisor.v8_5 = value._divisor;
                        oldBigM.v8_5 = value._bigM.Reinterpret<Divider<byte8>.BigM, ushort8>();

                        break;
                    }
                    case 6:
                    {
                        Divider._divisor.v8_6 = value._divisor;
                        oldBigM.v8_6 = value._bigM.Reinterpret<Divider<byte8>.BigM, ushort8>();

                        break;
                    }
                    case 7:
                    {
                        Divider._divisor.v8_7 = value._divisor;
                        oldBigM.v8_7 = value._bigM.Reinterpret<Divider<byte8>.BigM, ushort8>();

                        break;
                    }
                    case 8:
                    {
                        Divider._divisor.v8_8 = value._divisor;
                        oldBigM.v8_8 = value._bigM.Reinterpret<Divider<byte8>.BigM, ushort8>();

                        break;
                    }
                    default: throw Assert.Unreachable();
                }

                Divider._bigM = oldBigM.Reinterpret<ushort16, Divider<byte16>.BigM>();
            }
            else
            {
                byte16 oldDivisor = Divider._divisor;

                if (Architecture.IsSIMDSupported)
                {
                    v128 divisorMask = Xse.bslli_si128(Xse.cvtsi64x_si128(bitmask64(8 * sizeof(byte8))), index * sizeof(byte));
                    v128 alignedDivisor = Xse.bslli_si128(value._divisor, index * sizeof(byte));

                    oldDivisor = Xse.blendv_si128(oldDivisor, alignedDivisor, divisorMask);

                    if (Avx2.IsAvx2Supported)
                    {
                        v256 bigMMask = Xse.mm256_bslli_si256(Avx.mm256_castsi128_si256(Xse.setall_si128()), index * sizeof(ushort));
                        v256 alignedBigM = Xse.mm256_bslli_si256(Avx.mm256_castsi128_si256(*(ushort8*)&value._bigM), index * sizeof(ushort));

                        oldBigM = Xse.mm256_blendv_si256(oldBigM, alignedBigM, bigMMask);
                    }
                    else
                    {
                        oldBigM.SetField(value._bigM, index, sizeof(ushort));
                    }
                }
                else
                {
                    oldDivisor.SetField(value._divisor, index, sizeof(byte));
                    oldBigM.SetField(value._bigM, index, sizeof(ushort));
                }

                Divider._divisor = oldDivisor;
                Divider._bigM  = oldBigM.Reinterpret<ushort16, Divider<byte16>.BigM>();
            }

            Divider._promises = (Divider._promises & value._promises) | new Divider<byte16>.DividerPromise(Divider._divisor, sign, sizeof(byte));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void SetInnerDividerBase(ref this Divider<byte32> Divider, Divider<byte> value, int index, Signedness sign)
        {
Assert.IsWithinArrayBounds(index, 32);

            Divider._divisor[index] = value._divisor;

            if (constexpr.IS_CONST(index))
            {
                if (index < 16)
                {
                    Divider._bigM._mulLo.SetField(value._bigM, index);
                }
                else
                {
                    Divider._bigM._mulHi.SetField(value._bigM, index - 16);
                }
            }
            else
            {
                Divider._bigM.SetField(value._bigM, index);
            }

            Divider._promises = (Divider._promises & value._promises) | new Divider<byte32>.DividerPromise(Divider._divisor, sign, sizeof(byte));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void SetInnerDividerBase(ref this Divider<byte32> Divider, Divider<byte2> value, int index, Signedness sign)
        {
Assert.IsWithinArrayBounds(index, 31);

            Divider<byte32>.BigM oldBigM = Divider._bigM;

            if (constexpr.IS_CONST(index))
            {
                ushort16 oldBigM_lo = oldBigM.GetField<Divider<byte32>.BigM, ushort16>(0);
                ushort16 oldBigM_hi = oldBigM.GetField<Divider<byte32>.BigM, ushort16>(1);

                switch (index)
                {
                    case 0:
                    {
                        Divider._divisor.v2_0 = value._divisor;
                        oldBigM_lo.v2_0 = value._bigM.Reinterpret<Divider<byte2>.BigM, ushort2>();

                        break;
                    }
                    case 1:
                    {
                        Divider._divisor.v2_1 = value._divisor;
                        oldBigM_lo.v2_1 = value._bigM.Reinterpret<Divider<byte2>.BigM, ushort2>();

                        break;
                    }
                    case 2:
                    {
                        Divider._divisor.v2_2 = value._divisor;
                        oldBigM_lo.v2_2 = value._bigM.Reinterpret<Divider<byte2>.BigM, ushort2>();

                        break;
                    }
                    case 3:
                    {
                        Divider._divisor.v2_3 = value._divisor;
                        oldBigM_lo.v2_3 = value._bigM.Reinterpret<Divider<byte2>.BigM, ushort2>();

                        break;
                    }
                    case 4:
                    {
                        Divider._divisor.v2_4 = value._divisor;
                        oldBigM_lo.v2_4 = value._bigM.Reinterpret<Divider<byte2>.BigM, ushort2>();

                        break;
                    }
                    case 5:
                    {
                        Divider._divisor.v2_5 = value._divisor;
                        oldBigM_lo.v2_5 = value._bigM.Reinterpret<Divider<byte2>.BigM, ushort2>();

                        break;
                    }
                    case 6:
                    {
                        Divider._divisor.v2_6 = value._divisor;
                        oldBigM_lo.v2_6 = value._bigM.Reinterpret<Divider<byte2>.BigM, ushort2>();

                        break;
                    }
                    case 7:
                    {
                        Divider._divisor.v2_7 = value._divisor;
                        oldBigM_lo.v2_7 = value._bigM.Reinterpret<Divider<byte2>.BigM, ushort2>();

                        break;
                    }
                    case 8:
                    {
                        Divider._divisor.v2_8 = value._divisor;
                        oldBigM_lo.v2_8 = value._bigM.Reinterpret<Divider<byte2>.BigM, ushort2>();

                        break;
                    }
                    case 9:
                    {
                        Divider._divisor.v2_9 = value._divisor;
                        oldBigM_lo.v2_9 = value._bigM.Reinterpret<Divider<byte2>.BigM, ushort2>();

                        break;
                    }
                    case 10:
                    {
                        Divider._divisor.v2_10 = value._divisor;
                        oldBigM_lo.v2_10 = value._bigM.Reinterpret<Divider<byte2>.BigM, ushort2>();

                        break;
                    }
                    case 11:
                    {
                        Divider._divisor.v2_11 = value._divisor;
                        oldBigM_lo.v2_11 = value._bigM.Reinterpret<Divider<byte2>.BigM, ushort2>();

                        break;
                    }
                    case 12:
                    {
                        Divider._divisor.v2_12 = value._divisor;
                        oldBigM_lo.v2_12 = value._bigM.Reinterpret<Divider<byte2>.BigM, ushort2>();

                        break;
                    }
                    case 13:
                    {
                        Divider._divisor.v2_13 = value._divisor;
                        oldBigM_lo.v2_13 = value._bigM.Reinterpret<Divider<byte2>.BigM, ushort2>();

                        break;
                    }
                    case 14:
                    {
                        Divider._divisor.v2_14 = value._divisor;
                        oldBigM_lo.v2_14 = value._bigM.Reinterpret<Divider<byte2>.BigM, ushort2>();

                        break;
                    }
                    case 15:
                    {
                        Divider._divisor.v2_15 = value._divisor;
                        oldBigM_lo.x15 = value._bigM.Reinterpret<Divider<byte2>.BigM, ushort2>().x;
                        oldBigM_hi.x0  = value._bigM.Reinterpret<Divider<byte2>.BigM, ushort2>().y;

                        break;
                    }
                    case 16:
                    {
                        Divider._divisor.v2_16 = value._divisor;
                        oldBigM_hi.v2_0 = value._bigM.Reinterpret<Divider<byte2>.BigM, ushort2>();

                        break;
                    }
                    case 17:
                    {
                        Divider._divisor.v2_17 = value._divisor;
                        oldBigM_hi.v2_1 = value._bigM.Reinterpret<Divider<byte2>.BigM, ushort2>();

                        break;
                    }
                    case 18:
                    {
                        Divider._divisor.v2_18 = value._divisor;
                        oldBigM_hi.v2_2 = value._bigM.Reinterpret<Divider<byte2>.BigM, ushort2>();

                        break;
                    }
                    case 19:
                    {
                        Divider._divisor.v2_19 = value._divisor;
                        oldBigM_hi.v2_3 = value._bigM.Reinterpret<Divider<byte2>.BigM, ushort2>();

                        break;
                    }
                    case 20:
                    {
                        Divider._divisor.v2_20 = value._divisor;
                        oldBigM_hi.v2_4 = value._bigM.Reinterpret<Divider<byte2>.BigM, ushort2>();

                        break;
                    }
                    case 21:
                    {
                        Divider._divisor.v2_21 = value._divisor;
                        oldBigM_hi.v2_5 = value._bigM.Reinterpret<Divider<byte2>.BigM, ushort2>();

                        break;
                    }
                    case 22:
                    {
                        Divider._divisor.v2_22 = value._divisor;
                        oldBigM_hi.v2_6 = value._bigM.Reinterpret<Divider<byte2>.BigM, ushort2>();

                        break;
                    }
                    case 23:
                    {
                        Divider._divisor.v2_23 = value._divisor;
                        oldBigM_hi.v2_7 = value._bigM.Reinterpret<Divider<byte2>.BigM, ushort2>();

                        break;
                    }
                    case 24:
                    {
                        Divider._divisor.v2_24 = value._divisor;
                        oldBigM_hi.v2_8 = value._bigM.Reinterpret<Divider<byte2>.BigM, ushort2>();

                        break;
                    }
                    case 25:
                    {
                        Divider._divisor.v2_25 = value._divisor;
                        oldBigM_hi.v2_9 = value._bigM.Reinterpret<Divider<byte2>.BigM, ushort2>();

                        break;
                    }
                    case 26:
                    {
                        Divider._divisor.v2_26 = value._divisor;
                        oldBigM_hi.v2_10 = value._bigM.Reinterpret<Divider<byte2>.BigM, ushort2>();

                        break;
                    }
                    case 27:
                    {
                        Divider._divisor.v2_27 = value._divisor;
                        oldBigM_hi.v2_11 = value._bigM.Reinterpret<Divider<byte2>.BigM, ushort2>();

                        break;
                    }
                    case 28:
                    {
                        Divider._divisor.v2_28 = value._divisor;
                        oldBigM_hi.v2_12 = value._bigM.Reinterpret<Divider<byte2>.BigM, ushort2>();

                        break;
                    }
                    case 29:
                    {
                        Divider._divisor.v2_29 = value._divisor;
                        oldBigM_hi.v2_13 = value._bigM.Reinterpret<Divider<byte2>.BigM, ushort2>();

                        break;
                    }
                    case 30:
                    {
                        Divider._divisor.v2_30 = value._divisor;
                        oldBigM_hi.v2_14 = value._bigM.Reinterpret<Divider<byte2>.BigM, ushort2>();

                        break;
                    }
                    default: throw Assert.Unreachable();
                }

                oldBigM.SetField(oldBigM_lo, 0);
                oldBigM.SetField(oldBigM_hi, 1);
            }
            else
            {
                byte32 oldDivisor = Divider._divisor;

                if (Avx2.IsAvx2Supported)
                {
                    v256 divisorMask = Xse.mm256_bslli_si256(Xse.mm256_cvtsi32_si256(bitmask32(8 * sizeof(byte2))),   index * sizeof(byte));
                    v256 alignedDivisor = Xse.mm256_bslli_si256(Avx.mm256_castsi128_si256(value._divisor), index * sizeof(byte));

                    oldDivisor = Xse.mm256_blendv_si256(oldDivisor, alignedDivisor, divisorMask);
                }
                else
                {
                    oldDivisor.SetField(value._divisor, index, sizeof(byte));
                }

                oldBigM.SetField(value._bigM, index, sizeof(ushort));

                Divider._divisor = oldDivisor;
            }

            Divider._bigM = oldBigM;

            Divider._promises = (Divider._promises & value._promises) | new Divider<byte32>.DividerPromise(Divider._divisor, sign, sizeof(byte));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void SetInnerDividerBase(ref this Divider<byte32> Divider, Divider<byte3> value, int index, Signedness sign)
        {
Assert.IsWithinArrayBounds(index, 30);

            Divider<byte32>.BigM oldBigM = Divider._bigM;

            if (constexpr.IS_CONST(index))
            {
                ushort16 oldBigM_lo = oldBigM.GetField<Divider<byte32>.BigM, ushort16>(0);
                ushort16 oldBigM_hi = oldBigM.GetField<Divider<byte32>.BigM, ushort16>(1);

                switch (index)
                {
                    case 0:
                    {
                        Divider._divisor.v3_0 = value._divisor;
                        oldBigM_lo.v3_0 = value._bigM.Reinterpret<Divider<byte3>.BigM, ushort3>();

                        break;
                    }
                    case 1:
                    {
                        Divider._divisor.v3_1 = value._divisor;
                        oldBigM_lo.v3_1 = value._bigM.Reinterpret<Divider<byte3>.BigM, ushort3>();

                        break;
                    }
                    case 2:
                    {
                        Divider._divisor.v3_2 = value._divisor;
                        oldBigM_lo.v3_2 = value._bigM.Reinterpret<Divider<byte3>.BigM, ushort3>();

                        break;
                    }
                    case 3:
                    {
                        Divider._divisor.v3_3 = value._divisor;
                        oldBigM_lo.v3_3 = value._bigM.Reinterpret<Divider<byte3>.BigM, ushort3>();

                        break;
                    }
                    case 4:
                    {
                        Divider._divisor.v3_4 = value._divisor;
                        oldBigM_lo.v3_4 = value._bigM.Reinterpret<Divider<byte3>.BigM, ushort3>();

                        break;
                    }
                    case 5:
                    {
                        Divider._divisor.v3_5 = value._divisor;
                        oldBigM_lo.v3_5 = value._bigM.Reinterpret<Divider<byte3>.BigM, ushort3>();

                        break;
                    }
                    case 6:
                    {
                        Divider._divisor.v3_6 = value._divisor;
                        oldBigM_lo.v3_6 = value._bigM.Reinterpret<Divider<byte3>.BigM, ushort3>();

                        break;
                    }
                    case 7:
                    {
                        Divider._divisor.v3_7 = value._divisor;
                        oldBigM_lo.v3_7 = value._bigM.Reinterpret<Divider<byte3>.BigM, ushort3>();

                        break;
                    }
                    case 8:
                    {
                        Divider._divisor.v3_8 = value._divisor;
                        oldBigM_lo.v3_8 = value._bigM.Reinterpret<Divider<byte3>.BigM, ushort3>();

                        break;
                    }
                    case 9:
                    {
                        Divider._divisor.v3_9 = value._divisor;
                        oldBigM_lo.v3_9 = value._bigM.Reinterpret<Divider<byte3>.BigM, ushort3>();

                        break;
                    }
                    case 10:
                    {
                        Divider._divisor.v3_10 = value._divisor;
                        oldBigM_lo.v3_10 = value._bigM.Reinterpret<Divider<byte3>.BigM, ushort3>();

                        break;
                    }
                    case 11:
                    {
                        Divider._divisor.v3_11 = value._divisor;
                        oldBigM_lo.v3_11 = value._bigM.Reinterpret<Divider<byte3>.BigM, ushort3>();

                        break;
                    }
                    case 12:
                    {
                        Divider._divisor.v3_12 = value._divisor;
                        oldBigM_lo.v3_12 = value._bigM.Reinterpret<Divider<byte3>.BigM, ushort3>();

                        break;
                    }
                    case 13:
                    {
                        Divider._divisor.v3_13 = value._divisor;
                        oldBigM_lo.v3_13 = value._bigM.Reinterpret<Divider<byte3>.BigM, ushort3>();

                        break;
                    }
                    case 14:
                    {
                        Divider._divisor.v3_14 = value._divisor;
                        oldBigM_lo.v2_14 = value._bigM.Reinterpret<Divider<byte3>.BigM, ushort3>().xy;
                        oldBigM_hi.x0  = value._bigM.Reinterpret<Divider<byte3>.BigM, ushort3>().z;

                        break;
                    }
                    case 15:
                    {
                        Divider._divisor.v3_15 = value._divisor;
                        oldBigM_lo.x15  = value._bigM.Reinterpret<Divider<byte3>.BigM, ushort3>().x;
                        oldBigM_hi.v2_0 = value._bigM.Reinterpret<Divider<byte3>.BigM, ushort3>().yz;

                        break;
                    }
                    case 16:
                    {
                        Divider._divisor.v3_16 = value._divisor;
                        oldBigM_hi.v3_0 = value._bigM.Reinterpret<Divider<byte3>.BigM, ushort3>();

                        break;
                    }
                    case 17:
                    {
                        Divider._divisor.v3_17 = value._divisor;
                        oldBigM_hi.v3_1 = value._bigM.Reinterpret<Divider<byte3>.BigM, ushort3>();

                        break;
                    }
                    case 18:
                    {
                        Divider._divisor.v3_18 = value._divisor;
                        oldBigM_hi.v3_2 = value._bigM.Reinterpret<Divider<byte3>.BigM, ushort3>();

                        break;
                    }
                    case 19:
                    {
                        Divider._divisor.v3_19 = value._divisor;
                        oldBigM_hi.v3_3 = value._bigM.Reinterpret<Divider<byte3>.BigM, ushort3>();

                        break;
                    }
                    case 20:
                    {
                        Divider._divisor.v3_20 = value._divisor;
                        oldBigM_hi.v3_4 = value._bigM.Reinterpret<Divider<byte3>.BigM, ushort3>();

                        break;
                    }
                    case 21:
                    {
                        Divider._divisor.v3_21 = value._divisor;
                        oldBigM_hi.v3_5 = value._bigM.Reinterpret<Divider<byte3>.BigM, ushort3>();

                        break;
                    }
                    case 22:
                    {
                        Divider._divisor.v3_22 = value._divisor;
                        oldBigM_hi.v3_6 = value._bigM.Reinterpret<Divider<byte3>.BigM, ushort3>();

                        break;
                    }
                    case 23:
                    {
                        Divider._divisor.v3_23 = value._divisor;
                        oldBigM_hi.v3_7 = value._bigM.Reinterpret<Divider<byte3>.BigM, ushort3>();

                        break;
                    }
                    case 24:
                    {
                        Divider._divisor.v3_24 = value._divisor;
                        oldBigM_hi.v3_8 = value._bigM.Reinterpret<Divider<byte3>.BigM, ushort3>();

                        break;
                    }
                    case 25:
                    {
                        Divider._divisor.v3_25 = value._divisor;
                        oldBigM_hi.v3_9 = value._bigM.Reinterpret<Divider<byte3>.BigM, ushort3>();

                        break;
                    }
                    case 26:
                    {
                        Divider._divisor.v3_26 = value._divisor;
                        oldBigM_hi.v3_10 = value._bigM.Reinterpret<Divider<byte3>.BigM, ushort3>();

                        break;
                    }
                    case 27:
                    {
                        Divider._divisor.v3_27 = value._divisor;
                        oldBigM_hi.v3_11 = value._bigM.Reinterpret<Divider<byte3>.BigM, ushort3>();

                        break;
                    }
                    case 28:
                    {
                        Divider._divisor.v3_28 = value._divisor;
                        oldBigM_hi.v3_12 = value._bigM.Reinterpret<Divider<byte3>.BigM, ushort3>();

                        break;
                    }
                    case 29:
                    {
                        Divider._divisor.v3_29 = value._divisor;
                        oldBigM_hi.v3_13 = value._bigM.Reinterpret<Divider<byte3>.BigM, ushort3>();

                        break;
                    }
                    default: throw Assert.Unreachable();
                }

                oldBigM.SetField(oldBigM_lo, 0);
                oldBigM.SetField(oldBigM_hi, 1);
            }
            else
            {
                byte32 oldDivisor = Divider._divisor;

                if (Avx2.IsAvx2Supported)
                {
                    v256 divisorMask = Xse.mm256_bslli_si256(Xse.mm256_cvtsi32_si256(bitmask32(8 * sizeof(byte3))),   index * sizeof(byte));
                    v256 alignedDivisor = Xse.mm256_bslli_si256(Avx.mm256_castsi128_si256(value._divisor), index * sizeof(byte));

                    oldDivisor = Xse.mm256_blendv_si256(oldDivisor, alignedDivisor, divisorMask);
                }
                else
                {
                    oldDivisor.SetField(value._divisor, index, sizeof(byte));
                }

                oldBigM.SetField(value._bigM, index, sizeof(ushort));

                Divider._divisor = oldDivisor;
            }

            Divider._bigM = oldBigM;

            Divider._promises = (Divider._promises & value._promises) | new Divider<byte32>.DividerPromise(Divider._divisor, sign, sizeof(byte));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void SetInnerDividerBase(ref this Divider<byte32> Divider, Divider<byte4> value, int index, Signedness sign)
        {
Assert.IsWithinArrayBounds(index, 29);

            Divider<byte32>.BigM oldBigM = Divider._bigM;

            if (constexpr.IS_CONST(index))
            {
                ushort16 oldBigM_lo = oldBigM.GetField<Divider<byte32>.BigM, ushort16>(0);
                ushort16 oldBigM_hi = oldBigM.GetField<Divider<byte32>.BigM, ushort16>(1);

                switch (index)
                {
                    case 0:
                    {
                        Divider._divisor.v4_0 = value._divisor;
                        oldBigM_lo.v4_0 = value._bigM.Reinterpret<Divider<byte4>.BigM, ushort4>();

                        break;
                    }
                    case 1:
                    {
                        Divider._divisor.v4_1 = value._divisor;
                        oldBigM_lo.v4_1 = value._bigM.Reinterpret<Divider<byte4>.BigM, ushort4>();

                        break;
                    }
                    case 2:
                    {
                        Divider._divisor.v4_2 = value._divisor;
                        oldBigM_lo.v4_2 = value._bigM.Reinterpret<Divider<byte4>.BigM, ushort4>();

                        break;
                    }
                    case 3:
                    {
                        Divider._divisor.v4_3 = value._divisor;
                        oldBigM_lo.v4_3 = value._bigM.Reinterpret<Divider<byte4>.BigM, ushort4>();

                        break;
                    }
                    case 4:
                    {
                        Divider._divisor.v4_4 = value._divisor;
                        oldBigM_lo.v4_4 = value._bigM.Reinterpret<Divider<byte4>.BigM, ushort4>();

                        break;
                    }
                    case 5:
                    {
                        Divider._divisor.v4_5 = value._divisor;
                        oldBigM_lo.v4_5 = value._bigM.Reinterpret<Divider<byte4>.BigM, ushort4>();

                        break;
                    }
                    case 6:
                    {
                        Divider._divisor.v4_6 = value._divisor;
                        oldBigM_lo.v4_6 = value._bigM.Reinterpret<Divider<byte4>.BigM, ushort4>();

                        break;
                    }
                    case 7:
                    {
                        Divider._divisor.v4_7 = value._divisor;
                        oldBigM_lo.v4_7 = value._bigM.Reinterpret<Divider<byte4>.BigM, ushort4>();

                        break;
                    }
                    case 8:
                    {
                        Divider._divisor.v4_8 = value._divisor;
                        oldBigM_lo.v4_8 = value._bigM.Reinterpret<Divider<byte4>.BigM, ushort4>();

                        break;
                    }
                    case 9:
                    {
                        Divider._divisor.v4_9 = value._divisor;
                        oldBigM_lo.v4_9 = value._bigM.Reinterpret<Divider<byte4>.BigM, ushort4>();

                        break;
                    }
                    case 10:
                    {
                        Divider._divisor.v4_10 = value._divisor;
                        oldBigM_lo.v4_10 = value._bigM.Reinterpret<Divider<byte4>.BigM, ushort4>();

                        break;
                    }
                    case 11:
                    {
                        Divider._divisor.v4_11 = value._divisor;
                        oldBigM_lo.v4_11 = value._bigM.Reinterpret<Divider<byte4>.BigM, ushort4>();

                        break;
                    }
                    case 12:
                    {
                        Divider._divisor.v4_12 = value._divisor;
                        oldBigM_lo.v4_12 = value._bigM.Reinterpret<Divider<byte4>.BigM, ushort4>();

                        break;
                    }
                    case 13:
                    {
                        Divider._divisor.v4_13 = value._divisor;
                        oldBigM_lo.v3_13 = value._bigM.Reinterpret<Divider<byte4>.BigM, ushort4>().xyz;
                        oldBigM_hi.x0  = value._bigM.Reinterpret<Divider<byte4>.BigM, ushort4>().w;

                        break;
                    }
                    case 14:
                    {
                        Divider._divisor.v4_14 = value._divisor;
                        oldBigM_lo.v2_14 = value._bigM.Reinterpret<Divider<byte4>.BigM, ushort4>().xy;
                        oldBigM_hi.v2_0  = value._bigM.Reinterpret<Divider<byte4>.BigM, ushort4>().zw;

                        break;
                    }
                    case 15:
                    {
                        Divider._divisor.v4_15 = value._divisor;
                        oldBigM_lo.x15  = value._bigM.Reinterpret<Divider<byte4>.BigM, ushort4>().x;
                        oldBigM_hi.v3_0 = value._bigM.Reinterpret<Divider<byte4>.BigM, ushort4>().yzw;

                        break;
                    }
                    case 16:
                    {
                        Divider._divisor.v4_16 = value._divisor;
                        oldBigM_hi.v4_0 = value._bigM.Reinterpret<Divider<byte4>.BigM, ushort4>();

                        break;
                    }
                    case 17:
                    {
                        Divider._divisor.v4_17 = value._divisor;
                        oldBigM_hi.v4_1 = value._bigM.Reinterpret<Divider<byte4>.BigM, ushort4>();

                        break;
                    }
                    case 18:
                    {
                        Divider._divisor.v4_18 = value._divisor;
                        oldBigM_hi.v4_2 = value._bigM.Reinterpret<Divider<byte4>.BigM, ushort4>();

                        break;
                    }
                    case 19:
                    {
                        Divider._divisor.v4_19 = value._divisor;
                        oldBigM_hi.v4_3 = value._bigM.Reinterpret<Divider<byte4>.BigM, ushort4>();

                        break;
                    }
                    case 20:
                    {
                        Divider._divisor.v4_20 = value._divisor;
                        oldBigM_hi.v4_4 = value._bigM.Reinterpret<Divider<byte4>.BigM, ushort4>();

                        break;
                    }
                    case 21:
                    {
                        Divider._divisor.v4_21 = value._divisor;
                        oldBigM_hi.v4_5 = value._bigM.Reinterpret<Divider<byte4>.BigM, ushort4>();

                        break;
                    }
                    case 22:
                    {
                        Divider._divisor.v4_22 = value._divisor;
                        oldBigM_hi.v4_6 = value._bigM.Reinterpret<Divider<byte4>.BigM, ushort4>();

                        break;
                    }
                    case 23:
                    {
                        Divider._divisor.v4_23 = value._divisor;
                        oldBigM_hi.v4_7 = value._bigM.Reinterpret<Divider<byte4>.BigM, ushort4>();

                        break;
                    }
                    case 24:
                    {
                        Divider._divisor.v4_24 = value._divisor;
                        oldBigM_hi.v4_8 = value._bigM.Reinterpret<Divider<byte4>.BigM, ushort4>();

                        break;
                    }
                    case 25:
                    {
                        Divider._divisor.v4_25 = value._divisor;
                        oldBigM_hi.v4_9 = value._bigM.Reinterpret<Divider<byte4>.BigM, ushort4>();

                        break;
                    }
                    case 26:
                    {
                        Divider._divisor.v4_26 = value._divisor;
                        oldBigM_hi.v4_10 = value._bigM.Reinterpret<Divider<byte4>.BigM, ushort4>();

                        break;
                    }
                    case 27:
                    {
                        Divider._divisor.v4_27 = value._divisor;
                        oldBigM_hi.v4_11 = value._bigM.Reinterpret<Divider<byte4>.BigM, ushort4>();

                        break;
                    }
                    case 28:
                    {
                        Divider._divisor.v4_28 = value._divisor;
                        oldBigM_hi.v4_12 = value._bigM.Reinterpret<Divider<byte4>.BigM, ushort4>();

                        break;
                    }
                    default: throw Assert.Unreachable();
                }

                oldBigM.SetField(oldBigM_lo, 0);
                oldBigM.SetField(oldBigM_hi, 1);
            }
            else
            {
                byte32 oldDivisor = Divider._divisor;

                if (Avx2.IsAvx2Supported)
                {
                    v256 divisorMask = Xse.mm256_bslli_si256(Xse.mm256_cvtsi32_si256(bitmask32(8 * sizeof(byte4))),   index * sizeof(byte));
                    v256 alignedDivisor = Xse.mm256_bslli_si256(Avx.mm256_castsi128_si256(value._divisor), index * sizeof(byte));

                    oldDivisor = Xse.mm256_blendv_si256(oldDivisor, alignedDivisor, divisorMask);
                }
                else
                {
                    oldDivisor.SetField(value._divisor, index, sizeof(byte));
                }

                oldBigM.SetField(value._bigM, index, sizeof(ushort));

                Divider._divisor = oldDivisor;
            }

            Divider._bigM = oldBigM;

            Divider._promises = (Divider._promises & value._promises) | new Divider<byte32>.DividerPromise(Divider._divisor, sign, sizeof(byte));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void SetInnerDividerBase(ref this Divider<byte32> Divider, Divider<byte8> value, int index, Signedness sign)
        {
Assert.IsWithinArrayBounds(index, 25);

            Divider<byte32>.BigM oldBigM = Divider._bigM;

            if (constexpr.IS_CONST(index))
            {
                ushort16 oldBigM_lo = oldBigM.GetField<Divider<byte32>.BigM, ushort16>(0);
                ushort16 oldBigM_hi = oldBigM.GetField<Divider<byte32>.BigM, ushort16>(1);
                bool set = true;

                switch (index)
                {
                    case 0:
                    {
                        Divider._divisor.v8_0 = value._divisor;
                        oldBigM_lo.v8_0 = value._bigM.Reinterpret<Divider<byte8>.BigM, ushort8>();

                        break;
                    }
                    case 1:
                    {
                        Divider._divisor.v8_1 = value._divisor;
                        oldBigM_lo.v8_1 = value._bigM.Reinterpret<Divider<byte8>.BigM, ushort8>();

                        break;
                    }
                    case 2:
                    {
                        Divider._divisor.v8_2 = value._divisor;
                        oldBigM_lo.v8_2 = value._bigM.Reinterpret<Divider<byte8>.BigM, ushort8>();

                        break;
                    }
                    case 3:
                    {
                        Divider._divisor.v8_3 = value._divisor;
                        oldBigM_lo.v8_3 = value._bigM.Reinterpret<Divider<byte8>.BigM, ushort8>();

                        break;
                    }
                    case 4:
                    {
                        Divider._divisor.v8_4 = value._divisor;
                        oldBigM_lo.v8_4 = value._bigM.Reinterpret<Divider<byte8>.BigM, ushort8>();

                        break;
                    }
                    case 5:
                    {
                        Divider._divisor.v8_5 = value._divisor;
                        oldBigM_lo.v8_5 = value._bigM.Reinterpret<Divider<byte8>.BigM, ushort8>();

                        break;
                    }
                    case 6:
                    {
                        Divider._divisor.v8_6 = value._divisor;
                        oldBigM_lo.v8_6 = value._bigM.Reinterpret<Divider<byte8>.BigM, ushort8>();

                        break;
                    }
                    case 7:
                    {
                        Divider._divisor.v8_7 = value._divisor;
                        oldBigM_lo.v8_7 = value._bigM.Reinterpret<Divider<byte8>.BigM, ushort8>();

                        break;
                    }
                    case 8:
                    {
                        Divider._divisor.v8_8 = value._divisor;
                        oldBigM_lo.v8_8 = value._bigM.Reinterpret<Divider<byte8>.BigM, ushort8>();

                        break;
                    }
                    case 9:
                    {
                        Divider._divisor.v8_9 = value._divisor;

                        if (Avx2.IsAvx2Supported)
                        {
                            oldBigM_lo = Xse.mm256_blendv_si256(oldBigM_lo, Xse.mm256_bslli_si256(Avx.mm256_castsi128_si256(value._bigM.Reinterpret<Divider<byte8>.BigM, ushort8>()), 9 * sizeof(ushort)), new short16(0, 0, 0, 0, 0, 0, 0, 0,   0, -1, -1, -1, -1, -1, -1, -1));
                            oldBigM_hi = Xse.mm256_insert_epi16(oldBigM_hi, Xse.extract_epi16(value._bigM.Reinterpret<Divider<byte8>.BigM, ushort8>(), 7), 0);
                        }
                        else if (Architecture.IsSIMDSupported)
                        {
                            oldBigM_lo.v8_8 = Xse.blend_epi16(oldBigM_lo.v8_8, Xse.bslli_si128(value._bigM.Reinterpret<Divider<byte8>.BigM, ushort8>(), 1 * sizeof(ushort)), 0b1111_1110);
                            oldBigM_hi.v8_0 = Xse.blend_epi16(oldBigM_hi.v8_0, Xse.bsrli_si128(value._bigM.Reinterpret<Divider<byte8>.BigM, ushort8>(), 7 * sizeof(ushort)), 0b0000_0001);
                        }
                        else
                        {
                            set = false;
                            oldBigM.SetField(value._bigM, 9, sizeof(ushort));
                        }

                        break;
                    }
                    case 10:
                    {
                        Divider._divisor.v8_10 = value._divisor;

                        if (Architecture.IsSIMDSupported)
                        {
                            oldBigM_hi.v2_0 = value._bigM.Reinterpret<Divider<byte8>.BigM, ushort8>().v2_6;

                            if (Avx2.IsAvx2Supported)
                            {
                                oldBigM_lo = Avx2.mm256_blend_epi32(oldBigM_lo, Xse.mm256_bslli_si256(Avx.mm256_castsi128_si256(value._bigM.Reinterpret<Divider<byte8>.BigM, ushort8>()), 10 * sizeof(ushort)), 0b1110_0000);
                            }
                            else
                            {
                                oldBigM_lo.v8_8 = Xse.blend_epi16(oldBigM_lo.v8_8, Xse.bslli_si128(value._bigM.Reinterpret<Divider<byte8>.BigM, ushort8>(), 2 * sizeof(ushort)), 0b1111_1100);
                            }
                        }
                        else
                        {
                            set = false;
                            oldBigM.SetField(value._bigM, 10, sizeof(ushort));
                        }

                        break;
                    }
                    case 11:
                    {
                        Divider._divisor.v8_11 = value._divisor;

                        if (Architecture.IsSIMDSupported)
                        {
                            oldBigM_hi.v3_0 = value._bigM.Reinterpret<Divider<byte8>.BigM, ushort8>().v3_5;

                            if (Avx2.IsAvx2Supported)
                            {
                                oldBigM_lo = Xse.mm256_blendv_si256(oldBigM_lo, Xse.mm256_bslli_si256(Avx.mm256_castsi128_si256(value._bigM.Reinterpret<Divider<byte8>.BigM, ushort8>()), 11 * sizeof(ushort)), new short16(0, 0, 0, 0, 0, 0, 0, 0,   0, 0, 0, -1, -1, -1, -1, -1));
                            }
                            else
                            {
                                oldBigM_lo.v8_8 = Xse.blend_epi16(oldBigM_lo.v8_8, Xse.bslli_si128(value._bigM.Reinterpret<Divider<byte8>.BigM, ushort8>(), 3 * sizeof(ushort)), 0b1111_1000);
                            }
                        }
                        else
                        {
                            set = false;
                            oldBigM.SetField(value._bigM, 11, sizeof(ushort));
                        }

                        break;
                    }
                    case 12:
                    {
                        Divider._divisor.v8_12 = value._divisor;
                        oldBigM_lo.v4_12 = value._bigM.Reinterpret<Divider<byte8>.BigM, ushort8>().v4_0;
                        oldBigM_hi.v4_0  = value._bigM.Reinterpret<Divider<byte8>.BigM, ushort8>().v4_4;

                        break;
                    }
                    case 13:
                    {
                        Divider._divisor.v8_13 = value._divisor;

                        if (Architecture.IsSIMDSupported)
                        {
                            oldBigM_lo.v3_13 = value._bigM.Reinterpret<Divider<byte8>.BigM, ushort8>().v3_0;

                            if (Avx2.IsAvx2Supported)
                            {
                                oldBigM_hi = Xse.mm256_blendv_si256(oldBigM_hi, Avx.mm256_castsi128_si256(Xse.bsrli_si128(value._bigM.Reinterpret<Divider<byte8>.BigM, ushort8>(), 3 * sizeof(ushort))), new short16(-1, -1, -1, -1, -1, 0, 0, 0,   0, 0, 0, 0, 0, 0, 0, 0));
                            }
                            else
                            {
                                oldBigM_hi.v8_0 = Xse.blend_epi16(oldBigM_hi.v8_0, Xse.bsrli_si128(value._bigM.Reinterpret<Divider<byte8>.BigM, ushort8>(), 3 * sizeof(ushort)), 0b0001_1111);
                            }
                        }
                        else
                        {
                            set = false;
                            oldBigM.SetField(value._bigM, 13, sizeof(ushort));
                        }

                        break;
                    }
                    case 14:
                    {
                        Divider._divisor.v8_14 = value._divisor;

                        if (Architecture.IsSIMDSupported)
                        {
                            oldBigM_lo.v2_14 = value._bigM.Reinterpret<Divider<byte8>.BigM, ushort8>().v2_0;

                            if (Avx2.IsAvx2Supported)
                            {
                                oldBigM_hi = Avx2.mm256_blend_epi32(oldBigM_hi, Avx.mm256_castsi128_si256(Xse.bsrli_si128(value._bigM.Reinterpret<Divider<byte8>.BigM, ushort8>(), 2 * sizeof(ushort))), 0b0000_0111);
                            }
                            else
                            {
                                oldBigM_hi.v8_0 = Xse.blend_epi16(oldBigM_hi.v8_0, Xse.bsrli_si128(value._bigM.Reinterpret<Divider<byte8>.BigM, ushort8>(), 2 * sizeof(ushort)), 0b0011_1111);
                            }
                        }
                        else
                        {
                            set = false;
                            oldBigM.SetField(value._bigM, 14, sizeof(ushort));
                        }

                        break;
                    }
                    case 15:
                    {
                        Divider._divisor.v8_15 = value._divisor;

                        if (Architecture.IsSIMDSupported)
                        {
                            oldBigM_lo.x15  = value._bigM.Reinterpret<Divider<byte8>.BigM, ushort8>().x0;

                            if (Avx2.IsAvx2Supported)
                            {
                                oldBigM_hi = Xse.mm256_blendv_si256(oldBigM_hi, Avx.mm256_castsi128_si256(Xse.bsrli_si128(value._bigM.Reinterpret<Divider<byte8>.BigM, ushort8>(), 1 * sizeof(ushort))), new short16(-1, -1, -1, -1, -1, -1, -1, 0,   0, 0, 0, 0, 0, 0, 0, 0));
                            }
                            else
                            {
                                oldBigM_hi.v8_0 = Xse.blend_epi16(oldBigM_hi.v8_0, Xse.bsrli_si128(value._bigM.Reinterpret<Divider<byte8>.BigM, ushort8>(), 1 * sizeof(ushort)), 0b0111_1111);
                            }
                        }
                        else
                        {
                            set = false;
                            oldBigM.SetField(value._bigM, 15, sizeof(ushort));
                        }

                        break;
                    }
                    case 16:
                    {
                        Divider._divisor.v8_16 = value._divisor;
                        oldBigM_hi.v8_0 = value._bigM.Reinterpret<Divider<byte8>.BigM, ushort8>();

                        break;
                    }
                    case 17:
                    {
                        Divider._divisor.v8_17 = value._divisor;
                        oldBigM_hi.v8_1 = value._bigM.Reinterpret<Divider<byte8>.BigM, ushort8>();

                        break;
                    }
                    case 18:
                    {
                        Divider._divisor.v8_18 = value._divisor;
                        oldBigM_hi.v8_2 = value._bigM.Reinterpret<Divider<byte8>.BigM, ushort8>();

                        break;
                    }
                    case 19:
                    {
                        Divider._divisor.v8_19 = value._divisor;
                        oldBigM_hi.v8_3 = value._bigM.Reinterpret<Divider<byte8>.BigM, ushort8>();

                        break;
                    }
                    case 20:
                    {
                        Divider._divisor.v8_20 = value._divisor;
                        oldBigM_hi.v8_4 = value._bigM.Reinterpret<Divider<byte8>.BigM, ushort8>();

                        break;
                    }
                    case 21:
                    {
                        Divider._divisor.v8_21 = value._divisor;
                        oldBigM_hi.v8_5 = value._bigM.Reinterpret<Divider<byte8>.BigM, ushort8>();

                        break;
                    }
                    case 22:
                    {
                        Divider._divisor.v8_22 = value._divisor;
                        oldBigM_hi.v8_6 = value._bigM.Reinterpret<Divider<byte8>.BigM, ushort8>();

                        break;
                    }
                    case 23:
                    {
                        Divider._divisor.v8_23 = value._divisor;
                        oldBigM_hi.v8_7 = value._bigM.Reinterpret<Divider<byte8>.BigM, ushort8>();

                        break;
                    }
                    case 24:
                    {
                        Divider._divisor.v8_24 = value._divisor;
                        oldBigM_hi.v8_8 = value._bigM.Reinterpret<Divider<byte8>.BigM, ushort8>();

                        break;
                    }
                    default: throw Assert.Unreachable();
                }

                if (set)
                {
                    oldBigM.SetField(oldBigM_lo, 0);
                    oldBigM.SetField(oldBigM_hi, 1);
                }
            }
            else
            {
                byte32 oldDivisor = Divider._divisor;

                if (Avx2.IsAvx2Supported)
                {
                    v256 divisorMask = Xse.mm256_bslli_si256(Xse.mm256_cvtsi64x_si256(bitmask64(8 * sizeof(byte8))),   index * sizeof(byte));
                    v256 alignedDivisor = Xse.mm256_bslli_si256(Avx.mm256_castsi128_si256(value._divisor), index * sizeof(byte));

                    oldDivisor = Xse.mm256_blendv_si256(oldDivisor, alignedDivisor, divisorMask);
                }
                else
                {
                    oldDivisor.SetField(value._divisor, index, sizeof(byte));
                }

                oldBigM.SetField(value._bigM, index, sizeof(ushort));

                Divider._divisor = oldDivisor;
            }

            Divider._bigM = oldBigM;

            Divider._promises = (Divider._promises & value._promises) | new Divider<byte32>.DividerPromise(Divider._divisor, sign, sizeof(byte));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void SetInnerDividerBase(ref this Divider<byte32> Divider, Divider<byte16> value, int index, Signedness sign)
        {
Assert.IsWithinArrayBounds(index, 17);

            Divider<byte32>.BigM oldBigM = Divider._bigM;

            if (constexpr.IS_CONST(index))
            {
                ushort16 oldBigM_lo = oldBigM.GetField<Divider<byte32>.BigM, ushort16>(0);
                ushort16 oldBigM_hi = oldBigM.GetField<Divider<byte32>.BigM, ushort16>(1);
                bool set = true;

                switch (index)
                {
                    case 0:
                    {
                        Divider._divisor.v16_0 = value._divisor;
                        oldBigM_lo = value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>();

                        break;
                    }
                    case 1:
                    {
                        Divider._divisor.v16_1 = value._divisor;

                        if (Avx2.IsAvx2Supported)
                        {
                            oldBigM_lo = Xse.mm256_blendv_si256(oldBigM_lo, Xse.mm256_bslli_si256(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>(), 1  * sizeof(ushort)), new short16(0, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1));
                            oldBigM_hi = Xse.mm256_blendv_si256(oldBigM_hi, Xse.mm256_bsrli_si256(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>(), 15 * sizeof(ushort)), new short16(-1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
                        }
                        else if (Architecture.IsSIMDSupported)
                        {
                            oldBigM_lo.v8_0 = Xse.blend_epi16(oldBigM_lo.v8_0, Xse.bslli_si128(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>().v8_0, 1 * sizeof(ushort)), 0b1111_1110);
                            oldBigM_lo.v8_8 = Xse.blend_epi16(Xse.bsrli_si128(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>().v8_0, 7 * sizeof(ushort)), Xse.bslli_si128(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>().v8_8, 1 * sizeof(ushort)), 0b1111_1110);
                            oldBigM_hi.v8_0 = Xse.blend_epi16(oldBigM_hi.v8_0, Xse.bsrli_si128(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>().v8_8, 7 * sizeof(ushort)), 0b0000_0001);
                        }
                        else
                        {
                            set = false;
                            oldBigM.SetField(value._bigM, 1, sizeof(ushort));
                        }

                        break;
                    }
                    case 2:
                    {
                        Divider._divisor.v16_2 = value._divisor;

                        if (Avx2.IsAvx2Supported)
                        {
                            oldBigM_lo = Avx2.mm256_blend_epi32(oldBigM_lo, Xse.mm256_bslli_si256(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>(), 2  * sizeof(ushort)), 0b1111_1110);
                            oldBigM_hi = Avx2.mm256_blend_epi32(oldBigM_hi, Xse.mm256_bsrli_si256(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>(), 14 * sizeof(ushort)), 0b0000_0001);
                        }
                        else if (Architecture.IsSIMDSupported)
                        {
                            oldBigM_lo.v8_0 = Xse.blend_epi16(oldBigM_lo.v8_0, Xse.bslli_si128(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>().v8_0, 2 * sizeof(ushort)), 0b1111_1100);
                            oldBigM_lo.v8_8 = Xse.blend_epi16(Xse.bsrli_si128(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>().v8_0, 6 * sizeof(ushort)), Xse.bslli_si128(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>().v8_8, 2 * sizeof(ushort)), 0b1111_1100);
                            oldBigM_hi.v8_0 = Xse.blend_epi16(oldBigM_hi.v8_0, Xse.bsrli_si128(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>().v8_8, 6 * sizeof(ushort)), 0b0000_0011);
                        }
                        else
                        {
                            set = false;
                            oldBigM.SetField(value._bigM, 2, sizeof(ushort));
                        }

                        break;
                    }
                    case 3:
                    {
                        Divider._divisor.v16_3 = value._divisor;

                        if (Avx2.IsAvx2Supported)
                        {
                            oldBigM_lo = Xse.mm256_blendv_si256(oldBigM_lo, Xse.mm256_bslli_si256(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>(), 3  * sizeof(ushort)), new short16(0, 0, 0, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1));
                            oldBigM_hi = Xse.mm256_blendv_si256(oldBigM_hi, Xse.mm256_bsrli_si256(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>(), 13 * sizeof(ushort)), new short16(-1, -1, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
                        }
                        else if (Architecture.IsSIMDSupported)
                        {
                            oldBigM_lo.v8_0 = Xse.blend_epi16(oldBigM_lo.v8_0, Xse.bslli_si128(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>().v8_0, 3 * sizeof(ushort)), 0b1111_1000);
                            oldBigM_lo.v8_8 = Xse.blend_epi16(Xse.bsrli_si128(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>().v8_0, 5 * sizeof(ushort)), Xse.bslli_si128(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>().v8_8, 3 * sizeof(ushort)), 0b1111_1000);
                            oldBigM_hi.v8_0 = Xse.blend_epi16(oldBigM_hi.v8_0, Xse.bsrli_si128(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>().v8_8, 5 * sizeof(ushort)), 0b0000_0111);
                        }
                        else
                        {
                            set = false;
                            oldBigM.SetField(value._bigM, 3, sizeof(ushort));
                        }

                        break;
                    }
                    case 4:
                    {
                        Divider._divisor.v16_4 = value._divisor;

                        if (Avx2.IsAvx2Supported)
                        {
                            oldBigM_lo = Avx2.mm256_blend_epi32(oldBigM_lo, Xse.mm256_bslli_si256(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>(), 4  * sizeof(ushort)), 0b1111_1100);
                            oldBigM_hi = Avx2.mm256_blend_epi32(oldBigM_hi, Xse.mm256_bsrli_si256(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>(), 12 * sizeof(ushort)), 0b0000_0011);
                        }
                        else if (Architecture.IsSIMDSupported)
                        {
                            oldBigM_lo.v8_0 = Xse.unpacklo_epi64(oldBigM_lo.v8_0, value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>().v8_0);
                            oldBigM_lo.v8_8 = Xse.blend_epi16(Xse.bsrli_si128(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>().v8_0, 4 * sizeof(ushort)), Xse.bslli_si128(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>().v8_8, 4 * sizeof(ushort)), 0b1111_0000);
                            oldBigM_hi.v8_0 = Xse.unpackhi_epi64(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>().v8_8, oldBigM_hi.v8_0);
                        }
                        else
                        {
                            set = false;
                            oldBigM.SetField(value._bigM, 4, sizeof(ushort));
                        }

                        break;
                    }
                    case 5:
                    {
                        Divider._divisor.v16_5 = value._divisor;

                        if (Avx2.IsAvx2Supported)
                        {
                            oldBigM_lo = Xse.mm256_blendv_si256(oldBigM_lo, Xse.mm256_bslli_si256(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>(), 5  * sizeof(ushort)), new short16(0, 0, 0, 0, 0, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1));
                            oldBigM_hi = Xse.mm256_blendv_si256(oldBigM_hi, Xse.mm256_bsrli_si256(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>(), 11 * sizeof(ushort)), new short16(-1, -1, -1, -1, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
                        }
                        else if (Architecture.IsSIMDSupported)
                        {
                            oldBigM_lo.v8_0 = Xse.blend_epi16(oldBigM_lo.v8_0, Xse.bslli_si128(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>().v8_0, 5 * sizeof(ushort)), 0b1110_0000);
                            oldBigM_lo.v8_8 = Xse.blend_epi16(Xse.bsrli_si128(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>().v8_0, 3 * sizeof(ushort)), Xse.bslli_si128(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>().v8_8, 5 * sizeof(ushort)), 0b1110_0000);
                            oldBigM_hi.v8_0 = Xse.blend_epi16(oldBigM_hi.v8_0, Xse.bsrli_si128(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>().v8_8, 3 * sizeof(ushort)), 0b0001_1111);
                        }
                        else
                        {
                            set = false;
                            oldBigM.SetField(value._bigM, 5, sizeof(ushort));
                        }

                        break;
                    }
                    case 6:
                    {
                        Divider._divisor.v16_6 = value._divisor;

                        if (Avx2.IsAvx2Supported)
                        {
                            oldBigM_lo = Avx2.mm256_blend_epi32(oldBigM_lo, Xse.mm256_bslli_si256(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>(), 6  * sizeof(ushort)), 0b1111_1000);
                            oldBigM_hi = Avx2.mm256_blend_epi32(oldBigM_hi, Xse.mm256_bsrli_si256(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>(), 10 * sizeof(ushort)), 0b0000_0111);
                        }
                        else if (Architecture.IsSIMDSupported)
                        {
                            oldBigM_lo.v8_0 = Xse.blend_epi16(oldBigM_lo.v8_0, Xse.bslli_si128(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>().v8_0, 6 * sizeof(ushort)), 0b1100_0000);
                            oldBigM_lo.v8_8 = Xse.blend_epi16(Xse.bsrli_si128(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>().v8_0, 2 * sizeof(ushort)), Xse.bslli_si128(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>().v8_8, 6 * sizeof(ushort)), 0b1100_0000);
                            oldBigM_hi.v8_0 = Xse.blend_epi16(oldBigM_hi.v8_0, Xse.bsrli_si128(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>().v8_8, 2 * sizeof(ushort)), 0b0011_1111);
                        }
                        else
                        {
                            set = false;
                            oldBigM.SetField(value._bigM, 6, sizeof(ushort));
                        }

                        break;
                    }
                    case 7:
                    {
                        Divider._divisor.v16_7 = value._divisor;

                        if (Avx2.IsAvx2Supported)
                        {
                            oldBigM_lo = Xse.mm256_blendv_si256(oldBigM_lo, Xse.mm256_bslli_si256(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>(), 7 * sizeof(ushort)), new short16(0, 0, 0, 0, 0, 0, 0, -1, -1, -1, -1, -1, -1, -1, -1, -1));
                            oldBigM_hi = Xse.mm256_blendv_si256(oldBigM_hi, Xse.mm256_bsrli_si256(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>(), 9 * sizeof(ushort)), new short16(-1, -1, -1, -1, -1, -1, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0));
                        }
                        else if (Architecture.IsSIMDSupported)
                        {
                            oldBigM_lo.v8_0 = Xse.blend_epi16(oldBigM_lo.v8_0, Xse.bslli_si128(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>().v8_0, 7 * sizeof(ushort)), 0b1000_0000);
                            oldBigM_lo.v8_8 = Xse.blend_epi16(Xse.bsrli_si128(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>().v8_0, 1 * sizeof(ushort)), Xse.bslli_si128(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>().v8_8, 7 * sizeof(ushort)), 0b1000_0000);
                            oldBigM_hi.v8_0 = Xse.blend_epi16(oldBigM_hi.v8_0, Xse.bsrli_si128(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>().v8_8, 1 * sizeof(ushort)), 0b0111_1111);
                        }
                        else
                        {
                            set = false;
                            oldBigM.SetField(value._bigM, 7, sizeof(ushort));
                        }

                        break;
                    }
                    case 8:
                    {
                        Divider._divisor.v16_8 = value._divisor;

                        if (Avx2.IsAvx2Supported)
                        {
                            oldBigM_lo = Avx2.mm256_blend_epi32(oldBigM_lo, Xse.mm256_bslli_si256(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>(), 8 * sizeof(ushort)), 0b1111_0000);
                            oldBigM_hi = Avx2.mm256_blend_epi32(oldBigM_hi, Xse.mm256_bsrli_si256(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>(), 8 * sizeof(ushort)), 0b0000_1111);
                        }
                        else if (Architecture.IsSIMDSupported)
                        {
                            oldBigM_lo.v8_8 = value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>().v8_0;
                            oldBigM_hi.v8_0 = value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>().v8_8;
                        }
                        else
                        {
                            set = false;
                            oldBigM.SetField(value._bigM, 8, sizeof(ushort));
                        }

                        break;
                    }
                    case 9:
                    {
                        Divider._divisor.v16_9 = value._divisor;

                        if (Avx2.IsAvx2Supported)
                        {
                            oldBigM_lo = Xse.mm256_blendv_si256(oldBigM_lo, Xse.mm256_bslli_si256(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>(), 9 * sizeof(ushort)), new short16(0, 0, 0, 0, 0, 0, 0, 0, 0, -1, -1, -1, -1, -1, -1, -1));
                            oldBigM_hi = Xse.mm256_blendv_si256(oldBigM_hi, Xse.mm256_bsrli_si256(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>(), 7 * sizeof(ushort)), new short16(-1, -1, -1, -1, -1, -1, -1, -1, -1, 0, 0, 0, 0, 0, 0, 0));
                        }
                        else if (Architecture.IsSIMDSupported)
                        {
                            oldBigM_lo.v8_8 = Xse.blend_epi16(oldBigM_lo.v8_8, Xse.bslli_si128(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>().v8_0, 1 * sizeof(ushort)), 0b1111_1110);
                            oldBigM_hi.v8_0 = Xse.blend_epi16(Xse.bsrli_si128(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>().v8_0, 7 * sizeof(ushort)), Xse.bslli_si128(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>().v8_8, 1 * sizeof(ushort)), 0b1111_1110);
                            oldBigM_hi.v8_8 = Xse.blend_epi16(oldBigM_hi.v8_8, Xse.bsrli_si128(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>().v8_8, 7 * sizeof(ushort)), 0b0000_0001);
                        }
                        else
                        {
                            set = false;
                            oldBigM.SetField(value._bigM, 9, sizeof(ushort));
                        }

                        break;
                    }
                    case 10:
                    {
                        Divider._divisor.v16_10 = value._divisor;

                        if (Avx2.IsAvx2Supported)
                        {
                            oldBigM_lo = Avx2.mm256_blend_epi32(oldBigM_lo, Xse.mm256_bslli_si256(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>(), 10 * sizeof(ushort)), 0b1110_0000);
                            oldBigM_hi = Avx2.mm256_blend_epi32(oldBigM_hi, Xse.mm256_bsrli_si256(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>(), 6  * sizeof(ushort)), 0b0001_1111);
                        }
                        else if (Architecture.IsSIMDSupported)
                        {
                            oldBigM_lo.v8_8 = Xse.blend_epi16(oldBigM_lo.v8_8, Xse.bslli_si128(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>().v8_0, 2 * sizeof(ushort)), 0b1111_1100);
                            oldBigM_hi.v8_0 = Xse.blend_epi16(Xse.bsrli_si128(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>().v8_0, 6 * sizeof(ushort)), Xse.bslli_si128(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>().v8_8, 2 * sizeof(ushort)), 0b1111_1100);
                            oldBigM_hi.v8_8 = Xse.blend_epi16(oldBigM_hi.v8_8, Xse.bsrli_si128(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>().v8_8, 6 * sizeof(ushort)), 0b0000_0011);
                        }
                        else
                        {
                            set = false;
                            oldBigM.SetField(value._bigM, 10, sizeof(ushort));
                        }

                        break;
                    }
                    case 11:
                    {
                        Divider._divisor.v16_11 = value._divisor;

                        if (Avx2.IsAvx2Supported)
                        {
                            oldBigM_lo = Xse.mm256_blendv_si256(oldBigM_lo, Xse.mm256_bslli_si256(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>(), 11 * sizeof(ushort)), new short16(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, -1, -1, -1, -1));
                            oldBigM_hi = Xse.mm256_blendv_si256(oldBigM_hi, Xse.mm256_bsrli_si256(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>(), 5  * sizeof(ushort)), new short16(-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 0, 0, 0, 0, 0));
                        }
                        else if (Architecture.IsSIMDSupported)
                        {
                            oldBigM_lo.v8_8 = Xse.blend_epi16(oldBigM_lo.v8_8, Xse.bslli_si128(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>().v8_0, 3 * sizeof(ushort)), 0b1111_1000);
                            oldBigM_hi.v8_0 = Xse.blend_epi16(Xse.bsrli_si128(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>().v8_0, 5 * sizeof(ushort)), Xse.bslli_si128(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>().v8_8, 3 * sizeof(ushort)), 0b1111_1000);
                            oldBigM_hi.v8_8 = Xse.blend_epi16(oldBigM_hi.v8_8, Xse.bsrli_si128(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>().v8_8, 5 * sizeof(ushort)), 0b0000_0111);
                        }
                        else
                        {
                            set = false;
                            oldBigM.SetField(value._bigM, 11, sizeof(ushort));
                        }

                        break;
                    }
                    case 12:
                    {
                        Divider._divisor.v16_12 = value._divisor;

                        if (Avx2.IsAvx2Supported)
                        {
                            oldBigM_lo = Avx2.mm256_blend_epi32(oldBigM_lo, Xse.mm256_bslli_si256(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>(), 12 * sizeof(ushort)), 0b1100_0000);
                            oldBigM_hi = Avx2.mm256_blend_epi32(oldBigM_hi, Xse.mm256_bsrli_si256(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>(), 4  * sizeof(ushort)), 0b0011_1111);
                        }
                        else if (Architecture.IsSIMDSupported)
                        {
                            oldBigM_lo.v8_8 = Xse.blend_epi16(oldBigM_lo.v8_8, Xse.bslli_si128(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>().v8_0, 4 * sizeof(ushort)), 0b1111_0000);
                            oldBigM_hi.v8_0 = Xse.blend_epi16(Xse.bsrli_si128(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>().v8_0, 4 * sizeof(ushort)), Xse.bslli_si128(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>().v8_8, 4 * sizeof(ushort)), 0b1111_0000);
                            oldBigM_hi.v8_8 = Xse.blend_epi16(oldBigM_hi.v8_8, Xse.bsrli_si128(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>().v8_8, 4 * sizeof(ushort)), 0b0000_1111);
                        }
                        else
                        {
                            set = false;
                            oldBigM.SetField(value._bigM, 12, sizeof(ushort));
                        }

                        break;
                    }
                    case 13:
                    {
                        Divider._divisor.v16_13 = value._divisor;

                        if (Avx2.IsAvx2Supported)
                        {
                            oldBigM_lo = Xse.mm256_blendv_si256(oldBigM_lo, Xse.mm256_bslli_si256(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>(), 13 * sizeof(ushort)), new short16(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, -1, -1));
                            oldBigM_hi = Xse.mm256_blendv_si256(oldBigM_hi, Xse.mm256_bsrli_si256(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>(), 3  * sizeof(ushort)), new short16(-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 0, 0, 0));
                        }
                        else if (Architecture.IsSIMDSupported)
                        {
                            oldBigM_lo.v8_8 = Xse.blend_epi16(oldBigM_lo.v8_8, Xse.bslli_si128(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>().v8_0, 5 * sizeof(ushort)), 0b1110_0000);
                            oldBigM_hi.v8_0 = Xse.blend_epi16(Xse.bsrli_si128(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>().v8_0, 3 * sizeof(ushort)), Xse.bslli_si128(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>().v8_8, 5 * sizeof(ushort)), 0b1110_0000);
                            oldBigM_hi.v8_8 = Xse.blend_epi16(oldBigM_hi.v8_8, Xse.bsrli_si128(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>().v8_8, 3 * sizeof(ushort)), 0b0001_1111);
                        }
                        else
                        {
                            set = false;
                            oldBigM.SetField(value._bigM, 13, sizeof(ushort));
                        }

                        break;
                    }
                    case 14:
                    {
                        Divider._divisor.v16_14 = value._divisor;

                        if (Avx2.IsAvx2Supported)
                        {
                            oldBigM_lo = Avx2.mm256_blend_epi32(oldBigM_lo, Xse.mm256_bslli_si256(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>(), 14 * sizeof(ushort)), 0b1000_0000);
                            oldBigM_hi = Avx2.mm256_blend_epi32(oldBigM_hi, Xse.mm256_bsrli_si256(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>(), 2  * sizeof(ushort)), 0b0111_1111);
                        }
                        else if (Architecture.IsSIMDSupported)
                        {
                            oldBigM_lo.v8_8 = Xse.blend_epi16(oldBigM_lo.v8_8, Xse.bslli_si128(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>().v8_0, 6 * sizeof(ushort)), 0b1100_0000);
                            oldBigM_hi.v8_0 = Xse.blend_epi16(Xse.bsrli_si128(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>().v8_0, 2 * sizeof(ushort)), Xse.bslli_si128(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>().v8_8, 6 * sizeof(ushort)), 0b1100_0000);
                            oldBigM_hi.v8_8 = Xse.blend_epi16(oldBigM_hi.v8_8, Xse.bsrli_si128(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>().v8_8, 2 * sizeof(ushort)), 0b0011_1111);
                        }
                        else
                        {
                            set = false;
                            oldBigM.SetField(value._bigM, 14, sizeof(ushort));
                        }

                        break;
                    }
                    case 15:
                    {
                        Divider._divisor.v16_15 = value._divisor;

                        if (Avx2.IsAvx2Supported)
                        {
                            oldBigM_lo = Xse.mm256_blendv_si256(oldBigM_lo, Xse.mm256_bslli_si256(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>(), 15 * sizeof(ushort)), new short16(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1));
                            oldBigM_hi = Xse.mm256_blendv_si256(oldBigM_hi, Xse.mm256_bsrli_si256(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>(), 1  * sizeof(ushort)), new short16(-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 0));
                        }
                        else if (Architecture.IsSIMDSupported)
                        {
                            oldBigM_lo.v8_8 = Xse.blend_epi16(oldBigM_lo.v8_8, Xse.bslli_si128(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>().v8_0, 7 * sizeof(ushort)), 0b1000_0000);
                            oldBigM_hi.v8_0 = Xse.blend_epi16(Xse.bsrli_si128(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>().v8_0, 1 * sizeof(ushort)), Xse.bslli_si128(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>().v8_8, 7 * sizeof(ushort)), 0b1000_0000);
                            oldBigM_hi.v8_8 = Xse.blend_epi16(oldBigM_hi.v8_8, Xse.bsrli_si128(value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>().v8_8, 1 * sizeof(ushort)), 0b0111_1111);
                        }
                        else
                        {
                            set = false;
                            oldBigM.SetField(value._bigM, 15, sizeof(ushort));
                        }

                        break;
                    }
                    case 16:
                    {
                        Divider._divisor.v16_16 = value._divisor;
                        oldBigM_hi = value._bigM.Reinterpret<Divider<byte16>.BigM, ushort16>();

                        break;
                    }
                    default: throw Assert.Unreachable();
                }

                if (set)
                {
                    oldBigM.SetField(oldBigM_lo, 0);
                    oldBigM.SetField(oldBigM_hi, 1);
                }
            }
            else
            {
                byte32 oldDivisor = Divider._divisor;

                if (Avx2.IsAvx2Supported)
                {
                    v256 divisorMask = Xse.mm256_bslli_si256(Avx.mm256_castsi128_si256(Xse.setall_si128()), index * sizeof(byte));
                    v256 alignedDivisor = Xse.mm256_bslli_si256(Avx.mm256_castsi128_si256(value._divisor), index * sizeof(byte));

                    oldDivisor = Xse.mm256_blendv_si256(oldDivisor, alignedDivisor, divisorMask);
                }
                else
                {
                    oldDivisor.SetField(value._divisor, index, sizeof(byte));
                }

                oldBigM.SetField(value._bigM, index, sizeof(ushort));

                Divider._divisor = oldDivisor;
            }

            Divider._bigM = oldBigM;

            Divider._promises = (Divider._promises & value._promises) | new Divider<byte32>.DividerPromise(Divider._divisor, sign, sizeof(byte));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void SetInnerDividerBase(ref this Divider<ushort2> Divider, Divider<ushort> value, int index, Signedness sign)
        {
Assert.IsWithinArrayBounds(index, 2);

            Divider._divisor[index] = value._divisor;

            Divider._mulShift._mul[index] = value._mulShift._mul;
            Divider._mulShift._shift[index] = value._mulShift._shift;

            Divider._bigM.SetField(value._bigM, index);

            Divider._promises = (Divider._promises & value._promises) | new Divider<ushort2>.DividerPromise(Divider._divisor, sign, sizeof(ushort));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void SetInnerDividerBase(ref this Divider<ushort3> Divider, Divider<ushort> value, int index, Signedness sign)
        {
Assert.IsWithinArrayBounds(index, 3);

            Divider._divisor[index] = value._divisor;

            Divider._mulShift._mul[index] = value._mulShift._mul;
            Divider._mulShift._shift[index] = value._mulShift._shift;

            Divider._bigM.SetField(value._bigM, index);

            Divider._promises = (Divider._promises & value._promises) | new Divider<ushort3>.DividerPromise(Divider._divisor, sign, sizeof(ushort));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void SetInnerDividerBase(ref this Divider<ushort3> Divider, Divider<ushort2> value, int index, Signedness sign)
        {
Assert.IsWithinArrayBounds(index, 2);

            uint3 oldBigM = Divider._bigM.Reinterpret<Divider<ushort3>.BigM, uint3>();

            if (constexpr.IS_CONST(index))
            {
                switch (index)
                {
                    case 0:
                    {
                        Divider._divisor.xy = value._divisor;

                        Divider._mulShift._mul.xy = value._mulShift._mul;
                        Divider._mulShift._shift.xy = value._mulShift._shift;

                        oldBigM.xy = value._bigM.Reinterpret<Divider<ushort2>.BigM, uint2>();

                        break;
                    }
                    case 1:
                    {
                        Divider._divisor.yz = value._divisor;

                        Divider._mulShift._mul.yz = value._mulShift._mul;
                        Divider._mulShift._shift.yz = value._mulShift._shift;

                        oldBigM.yz = value._bigM.Reinterpret<Divider<ushort2>.BigM, uint2>();

                        break;
                    }
                    default: throw Assert.Unreachable();
                }

                Divider._bigM = oldBigM.Reinterpret<uint3, Divider<ushort3>.BigM>();
            }
            else
            {
                ushort3 oldDivisor = Divider._divisor;

                ushort3 oldMul    = Divider._mulShift._mul;
                ushort3 oldShift1 = Divider._mulShift._shift;

                if (Architecture.IsSIMDSupported)
                {
                    v128 sameTypeMask = Xse.bslli_si128(Xse.cvtsi32_si128(bitmask32(8 * sizeof(ushort2))), index * sizeof(ushort));
                    v128 alignedDivisor = Xse.bslli_si128(value._divisor,          index * sizeof(ushort));
                    v128 alignedMul     = Xse.bslli_si128(value._mulShift._mul,    index * sizeof(ushort));
                    v128 alignedShift1  = Xse.bslli_si128(value._mulShift._shift, index * sizeof(ushort));
                    oldDivisor = Xse.blendv_si128(oldDivisor, alignedDivisor, sameTypeMask);
                    oldMul     = Xse.blendv_si128(oldMul,     alignedMul,     sameTypeMask);
                    oldShift1  = Xse.blendv_si128(oldShift1,  alignedShift1,  sameTypeMask);

                    v128 bigMMask = Xse.bslli_si128(Xse.cvtsi64x_si128(bitmask64(8 * sizeof(uint2))), index * sizeof(uint));
                    v128 alignedBigM = Xse.bslli_si128(RegisterConversion.ToV128(*(uint2*)&value._bigM), index * sizeof(uint));
                    oldBigM = RegisterConversion.ToUInt3(Xse.blendv_si128(RegisterConversion.ToV128(oldBigM), alignedBigM, bigMMask));
                }
                else
                {
                    oldDivisor.SetField(value._divisor, index, sizeof(ushort));
                    oldMul.SetField(value._mulShift._mul, index, sizeof(ushort));
                    oldShift1.SetField(value._mulShift._shift, index, sizeof(ushort));
                    oldBigM.SetField(value._bigM, index, sizeof(uint));
                }

                Divider._divisor = oldDivisor;

                Divider._mulShift._mul  = oldMul;
                Divider._mulShift._shift = oldShift1;

                Divider._bigM  = oldBigM.Reinterpret<uint3, Divider<ushort3>.BigM>();
            }

            Divider._promises = (Divider._promises & value._promises) | new Divider<ushort3>.DividerPromise(Divider._divisor, sign, sizeof(ushort));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void SetInnerDividerBase(ref this Divider<ushort4> Divider, Divider<ushort> value, int index, Signedness sign)
        {
Assert.IsWithinArrayBounds(index, 4);

            Divider._divisor[index] = value._divisor;

            Divider._mulShift._mul[index] = value._mulShift._mul;
            Divider._mulShift._shift[index] = value._mulShift._shift;

            Divider._bigM.SetField(value._bigM, index);

            Divider._promises = (Divider._promises & value._promises) | new Divider<ushort4>.DividerPromise(Divider._divisor, sign, sizeof(ushort));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void SetInnerDividerBase(ref this Divider<ushort4> Divider, Divider<ushort2> value, int index, Signedness sign)
        {
Assert.IsWithinArrayBounds(index, 3);

            uint4 oldBigM = Divider._bigM.Reinterpret<Divider<ushort4>.BigM, uint4>();

            if (constexpr.IS_CONST(index))
            {
                switch (index)
                {
                    case 0:
                    {
                        Divider._divisor.xy = value._divisor;

                        Divider._mulShift._mul.xy = value._mulShift._mul;
                        Divider._mulShift._shift.xy = value._mulShift._shift;

                        oldBigM.xy = value._bigM.Reinterpret<Divider<ushort2>.BigM, uint2>();

                        break;
                    }
                    case 1:
                    {
                        Divider._divisor.yz = value._divisor;

                        Divider._mulShift._mul.yz = value._mulShift._mul;
                        Divider._mulShift._shift.yz = value._mulShift._shift;

                        oldBigM.yz = value._bigM.Reinterpret<Divider<ushort2>.BigM, uint2>();

                        break;
                    }
                    case 2:
                    {
                        Divider._divisor.zw = value._divisor;

                        Divider._mulShift._mul.zw = value._mulShift._mul;
                        Divider._mulShift._shift.zw = value._mulShift._shift;

                        oldBigM.zw = value._bigM.Reinterpret<Divider<ushort2>.BigM, uint2>();

                        break;
                    }
                    default: throw Assert.Unreachable();
                }

                Divider._bigM = oldBigM.Reinterpret<uint4, Divider<ushort4>.BigM>();
            }
            else
            {
                ushort4 oldDivisor = Divider._divisor;

                ushort4 oldMul    = Divider._mulShift._mul;
                ushort4 oldShift1 = Divider._mulShift._shift;

                if (Architecture.IsSIMDSupported)
                {
                    v128 sameTypeMask = Xse.bslli_si128(Xse.cvtsi32_si128(bitmask32(8 * sizeof(ushort2))), index * sizeof(ushort));
                    v128 alignedDivisor = Xse.bslli_si128(value._divisor,          index * sizeof(ushort));
                    v128 alignedMul     = Xse.bslli_si128(value._mulShift._mul,    index * sizeof(ushort));
                    v128 alignedShift1  = Xse.bslli_si128(value._mulShift._shift, index * sizeof(ushort));
                    oldDivisor = Xse.blendv_si128(oldDivisor, alignedDivisor, sameTypeMask);
                    oldMul     = Xse.blendv_si128(oldMul,     alignedMul,     sameTypeMask);
                    oldShift1  = Xse.blendv_si128(oldShift1,  alignedShift1,  sameTypeMask);

                    v128 bigMMask = Xse.bslli_si128(Xse.cvtsi64x_si128(bitmask64(8 * sizeof(uint2))), index * sizeof(uint));
                    v128 alignedBigM = Xse.bslli_si128(RegisterConversion.ToV128(*(uint2*)&value._bigM), index * sizeof(uint));
                    oldBigM = RegisterConversion.ToUInt4(Xse.blendv_si128(RegisterConversion.ToV128(oldBigM), alignedBigM, bigMMask));
                }
                else
                {
                    oldDivisor.SetField(value._divisor, index, sizeof(ushort));
                    oldMul.SetField(value._mulShift._mul, index, sizeof(ushort));
                    oldShift1.SetField(value._mulShift._shift, index, sizeof(ushort));
                    oldBigM.SetField(value._bigM, index, sizeof(uint));
                }

                Divider._divisor = oldDivisor;

                Divider._mulShift._mul  = oldMul;
                Divider._mulShift._shift = oldShift1;

                Divider._bigM  = oldBigM.Reinterpret<uint4, Divider<ushort4>.BigM>();
            }

            Divider._promises = (Divider._promises & value._promises) | new Divider<ushort4>.DividerPromise(Divider._divisor, sign, sizeof(ushort));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void SetInnerDividerBase(ref this Divider<ushort4> Divider, Divider<ushort3> value, int index, Signedness sign)
        {
Assert.IsWithinArrayBounds(index, 2);

            uint4 oldBigM = Divider._bigM.Reinterpret<Divider<ushort4>.BigM, uint4>();

            if (constexpr.IS_CONST(index))
            {
                switch (index)
                {
                    case 0:
                    {
                        Divider._divisor.xyz = value._divisor;

                        Divider._mulShift._mul.xyz = value._mulShift._mul;
                        Divider._mulShift._shift.xyz = value._mulShift._shift;

                        oldBigM.xyz = value._bigM.Reinterpret<Divider<ushort3>.BigM, uint3>();

                        break;
                    }
                    case 1:
                    {
                        Divider._divisor.yzw = value._divisor;

                        Divider._mulShift._mul.yzw = value._mulShift._mul;
                        Divider._mulShift._shift.yzw = value._mulShift._shift;

                        oldBigM.yzw = value._bigM.Reinterpret<Divider<ushort3>.BigM, uint3>();

                        break;
                    }
                    default: throw Assert.Unreachable();
                }

                Divider._bigM = oldBigM.Reinterpret<uint4, Divider<ushort4>.BigM>();
            }
            else
            {
                ushort4 oldDivisor = Divider._divisor;

                ushort4 oldMul    = Divider._mulShift._mul;
                ushort4 oldShift1 = Divider._mulShift._shift;

                if (Architecture.IsSIMDSupported)
                {
                    v128 sameTypeMask = Xse.bslli_si128(Xse.cvtsi64x_si128(bitmask64(8 * sizeof(ushort3))), index * sizeof(ushort));
                    v128 alignedDivisor = Xse.bslli_si128(value._divisor,          index * sizeof(ushort));
                    v128 alignedMul     = Xse.bslli_si128(value._mulShift._mul,    index * sizeof(ushort));
                    v128 alignedShift1  = Xse.bslli_si128(value._mulShift._shift, index * sizeof(ushort));
                    oldDivisor = Xse.blendv_si128(oldDivisor, alignedDivisor, sameTypeMask);
                    oldMul     = Xse.blendv_si128(oldMul,     alignedMul,     sameTypeMask);
                    oldShift1  = Xse.blendv_si128(oldShift1,  alignedShift1,  sameTypeMask);

                    v128 bigMMask = Xse.bslli_si128(new v128(-1, -1, -1, 0), index * sizeof(uint));
                    v128 alignedBigM = Xse.bslli_si128(RegisterConversion.ToV128(*(uint3*)&value._bigM), index * sizeof(uint));
                    oldBigM = RegisterConversion.ToUInt4(Xse.blendv_si128(RegisterConversion.ToV128(oldBigM), alignedBigM, bigMMask));
                }
                else
                {
                    oldDivisor.SetField(value._divisor, index, sizeof(ushort));
                    oldMul.SetField(value._mulShift._mul, index, sizeof(ushort));
                    oldShift1.SetField(value._mulShift._shift, index, sizeof(ushort));
                    oldBigM.SetField(value._bigM, index, sizeof(uint));
                }

                Divider._divisor = oldDivisor;

                Divider._mulShift._mul  = oldMul;
                Divider._mulShift._shift = oldShift1;

                Divider._bigM  = oldBigM.Reinterpret<uint4, Divider<ushort4>.BigM>();
            }

            Divider._promises = (Divider._promises & value._promises) | new Divider<ushort4>.DividerPromise(Divider._divisor, sign, sizeof(ushort));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void SetInnerDividerBase(ref this Divider<ushort8> Divider, Divider<ushort> value, int index, Signedness sign)
        {
Assert.IsWithinArrayBounds(index, 8);

            Divider._divisor[index] = value._divisor;

            Divider._mulShift._mul[index] = value._mulShift._mul;
            Divider._mulShift._shift[index] = value._mulShift._shift;

            Divider._bigM.SetField(value._bigM, index);

            Divider._promises = (Divider._promises & value._promises) | new Divider<ushort8>.DividerPromise(Divider._divisor, sign, sizeof(ushort));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void SetInnerDividerBase(ref this Divider<ushort8> Divider, Divider<ushort2> value, int index, Signedness sign)
        {
Assert.IsWithinArrayBounds(index, 7);

            uint8 oldBigM = Divider._bigM.Reinterpret<Divider<ushort8>.BigM, uint8>();

            if (constexpr.IS_CONST(index))
            {
                switch (index)
                {
                    case 0:
                    {
                        Divider._divisor.v2_0 = value._divisor;

                        Divider._mulShift._mul.v2_0 = value._mulShift._mul;
                        Divider._mulShift._shift.v2_0 = value._mulShift._shift;

                        oldBigM.v2_0 = value._bigM.Reinterpret<Divider<ushort2>.BigM, uint2>();

                        break;
                    }
                    case 1:
                    {
                        Divider._divisor.v2_1 = value._divisor;

                        Divider._mulShift._mul.v2_1 = value._mulShift._mul;
                        Divider._mulShift._shift.v2_1 = value._mulShift._shift;

                        oldBigM.v2_1 = value._bigM.Reinterpret<Divider<ushort2>.BigM, uint2>();

                        break;
                    }
                    case 2:
                    {
                        Divider._divisor.v2_2 = value._divisor;

                        Divider._mulShift._mul.v2_2 = value._mulShift._mul;
                        Divider._mulShift._shift.v2_2 = value._mulShift._shift;

                        oldBigM.v2_2 = value._bigM.Reinterpret<Divider<ushort2>.BigM, uint2>();

                        break;
                    }
                    case 3:
                    {
                        Divider._divisor.v2_3 = value._divisor;

                        Divider._mulShift._mul.v2_3 = value._mulShift._mul;
                        Divider._mulShift._shift.v2_3 = value._mulShift._shift;

                        oldBigM.v2_3 = value._bigM.Reinterpret<Divider<ushort2>.BigM, uint2>();

                        break;
                    }
                    case 4:
                    {
                        Divider._divisor.v2_4 = value._divisor;

                        Divider._mulShift._mul.v2_4 = value._mulShift._mul;
                        Divider._mulShift._shift.v2_4 = value._mulShift._shift;

                        oldBigM.v2_4 = value._bigM.Reinterpret<Divider<ushort2>.BigM, uint2>();

                        break;
                    }
                    case 5:
                    {
                        Divider._divisor.v2_5 = value._divisor;

                        Divider._mulShift._mul.v2_5 = value._mulShift._mul;
                        Divider._mulShift._shift.v2_5 = value._mulShift._shift;

                        oldBigM.v2_5 = value._bigM.Reinterpret<Divider<ushort2>.BigM, uint2>();

                        break;
                    }
                    case 6:
                    {
                        Divider._divisor.v2_6 = value._divisor;

                        Divider._mulShift._mul.v2_6 = value._mulShift._mul;
                        Divider._mulShift._shift.v2_6 = value._mulShift._shift;

                        oldBigM.v2_6 = value._bigM.Reinterpret<Divider<ushort2>.BigM, uint2>();

                        break;
                    }
                    default: throw Assert.Unreachable();
                }

                Divider._bigM = oldBigM.Reinterpret<uint8, Divider<ushort8>.BigM>();
            }
            else
            {
                ushort8 oldDivisor = Divider._divisor;

                ushort8 oldMul    = Divider._mulShift._mul;
                ushort8 oldShift1 = Divider._mulShift._shift;

                if (Architecture.IsSIMDSupported)
                {
                    v128 sameTypeMask = Xse.bslli_si128(Xse.cvtsi32_si128(bitmask32(8 * sizeof(ushort2))), index * sizeof(ushort));
                    v128 alignedDivisor = Xse.bslli_si128(value._divisor,          index * sizeof(ushort));
                    v128 alignedMul     = Xse.bslli_si128(value._mulShift._mul,    index * sizeof(ushort));
                    v128 alignedShift1  = Xse.bslli_si128(value._mulShift._shift, index * sizeof(ushort));
                    oldDivisor = Xse.blendv_si128(oldDivisor, alignedDivisor, sameTypeMask);
                    oldMul     = Xse.blendv_si128(oldMul,     alignedMul,     sameTypeMask);
                    oldShift1  = Xse.blendv_si128(oldShift1,  alignedShift1,  sameTypeMask);

                    if (Avx2.IsAvx2Supported)
                    {
                        v256 bigMMask = Xse.mm256_bslli_si256(Xse.mm256_cvtsi64x_si256(bitmask64(8 * sizeof(uint2))), index * sizeof(uint));
                        v256 alignedBigM = Xse.mm256_bslli_si256(Avx.mm256_castsi128_si256(RegisterConversion.ToV128(*(uint2*)&value._bigM)), index * sizeof(uint));
                        oldBigM = Xse.mm256_blendv_si256(oldBigM, alignedBigM, bigMMask);
                    }
                    else
                    {
                        oldBigM.SetField(value._bigM, index, sizeof(uint));
                    }
                }
                else
                {
                    oldDivisor.SetField(value._divisor, index, sizeof(ushort));
                    oldMul.SetField(value._mulShift._mul, index, sizeof(ushort));
                    oldShift1.SetField(value._mulShift._shift, index, sizeof(ushort));
                    oldBigM.SetField(value._bigM, index, sizeof(uint));
                }

                Divider._divisor = oldDivisor;

                Divider._mulShift._mul  = oldMul;
                Divider._mulShift._shift = oldShift1;

                Divider._bigM  = oldBigM.Reinterpret<uint8, Divider<ushort8>.BigM>();
            }

            Divider._promises = (Divider._promises & value._promises) | new Divider<ushort8>.DividerPromise(Divider._divisor, sign, sizeof(ushort));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void SetInnerDividerBase(ref this Divider<ushort8> Divider, Divider<ushort3> value, int index, Signedness sign)
        {
Assert.IsWithinArrayBounds(index, 6);

            uint8 oldBigM = Divider._bigM.Reinterpret<Divider<ushort8>.BigM, uint8>();

            if (constexpr.IS_CONST(index))
            {
                switch (index)
                {
                    case 0:
                    {
                        Divider._divisor.v3_0 = value._divisor;

                        Divider._mulShift._mul.v3_0 = value._mulShift._mul;
                        Divider._mulShift._shift.v3_0 = value._mulShift._shift;

                        oldBigM.v3_0 = value._bigM.Reinterpret<Divider<ushort3>.BigM, uint3>();

                        break;
                    }
                    case 1:
                    {
                        Divider._divisor.v3_1 = value._divisor;

                        Divider._mulShift._mul.v3_1 = value._mulShift._mul;
                        Divider._mulShift._shift.v3_1 = value._mulShift._shift;

                        oldBigM.v3_1 = value._bigM.Reinterpret<Divider<ushort3>.BigM, uint3>();

                        break;
                    }
                    case 2:
                    {
                        Divider._divisor.v3_2 = value._divisor;

                        Divider._mulShift._mul.v3_2 = value._mulShift._mul;
                        Divider._mulShift._shift.v3_2 = value._mulShift._shift;

                        oldBigM.v3_2 = value._bigM.Reinterpret<Divider<ushort3>.BigM, uint3>();

                        break;
                    }
                    case 3:
                    {
                        Divider._divisor.v3_3 = value._divisor;

                        Divider._mulShift._mul.v3_3 = value._mulShift._mul;
                        Divider._mulShift._shift.v3_3 = value._mulShift._shift;

                        oldBigM.v3_3 = value._bigM.Reinterpret<Divider<ushort3>.BigM, uint3>();

                        break;
                    }
                    case 4:
                    {
                        Divider._divisor.v3_4 = value._divisor;

                        Divider._mulShift._mul.v3_4 = value._mulShift._mul;
                        Divider._mulShift._shift.v3_4 = value._mulShift._shift;

                        oldBigM.v3_4 = value._bigM.Reinterpret<Divider<ushort3>.BigM, uint3>();

                        break;
                    }
                    case 5:
                    {
                        Divider._divisor.v3_5 = value._divisor;

                        Divider._mulShift._mul.v3_5 = value._mulShift._mul;
                        Divider._mulShift._shift.v3_5 = value._mulShift._shift;

                        oldBigM.v3_5 = value._bigM.Reinterpret<Divider<ushort3>.BigM, uint3>();

                        break;
                    }
                    default: throw Assert.Unreachable();
                }

                Divider._bigM = oldBigM.Reinterpret<uint8, Divider<ushort8>.BigM>();
            }
            else
            {
                ushort8 oldDivisor = Divider._divisor;

                ushort8 oldMul    = Divider._mulShift._mul;
                ushort8 oldShift1 = Divider._mulShift._shift;

                if (Architecture.IsSIMDSupported)
                {
                    v128 sameTypeMask = Xse.bslli_si128(Xse.cvtsi64x_si128(bitmask64(8 * sizeof(ushort3))), index * sizeof(ushort));
                    v128 alignedDivisor = Xse.bslli_si128(value._divisor,          index * sizeof(ushort));
                    v128 alignedMul     = Xse.bslli_si128(value._mulShift._mul,    index * sizeof(ushort));
                    v128 alignedShift1  = Xse.bslli_si128(value._mulShift._shift, index * sizeof(ushort));
                    oldDivisor = Xse.blendv_si128(oldDivisor, alignedDivisor, sameTypeMask);
                    oldMul     = Xse.blendv_si128(oldMul,     alignedMul,     sameTypeMask);
                    oldShift1  = Xse.blendv_si128(oldShift1,  alignedShift1,  sameTypeMask);

                    if (Avx2.IsAvx2Supported)
                    {
                        v256 bigMMask = Xse.mm256_bslli_si256(Avx.mm256_castsi128_si256(new v128(-1, -1, -1, 0)), index * sizeof(uint));
                        v256 alignedBigM = Xse.mm256_bslli_si256(Avx.mm256_castsi128_si256(RegisterConversion.ToV128(*(uint3*)&value._bigM)), index * sizeof(uint));
                        oldBigM = Xse.mm256_blendv_si256(oldBigM, alignedBigM, bigMMask);
                    }
                    else
                    {
                        oldBigM.SetField(value._bigM, index, sizeof(uint));
                    }
                }
                else
                {
                    oldDivisor.SetField(value._divisor, index, sizeof(ushort));
                    oldMul.SetField(value._mulShift._mul, index, sizeof(ushort));
                    oldShift1.SetField(value._mulShift._shift, index, sizeof(ushort));
                    oldBigM.SetField(value._bigM, index, sizeof(uint));
                }

                Divider._divisor = oldDivisor;

                Divider._mulShift._mul  = oldMul;
                Divider._mulShift._shift = oldShift1;

                Divider._bigM  = oldBigM.Reinterpret<uint8, Divider<ushort8>.BigM>();
            }

            Divider._promises = (Divider._promises & value._promises) | new Divider<ushort8>.DividerPromise(Divider._divisor, sign, sizeof(ushort));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void SetInnerDividerBase(ref this Divider<ushort8> Divider, Divider<ushort4> value, int index, Signedness sign)
        {
Assert.IsWithinArrayBounds(index, 5);

            uint8 oldBigM = Divider._bigM.Reinterpret<Divider<ushort8>.BigM, uint8>();

            if (constexpr.IS_CONST(index))
            {
                switch (index)
                {
                    case 0:
                    {
                        Divider._divisor.v4_0 = value._divisor;

                        Divider._mulShift._mul.v4_0 = value._mulShift._mul;
                        Divider._mulShift._shift.v4_0 = value._mulShift._shift;

                        oldBigM.v4_0 = value._bigM.Reinterpret<Divider<ushort4>.BigM, uint4>();

                        break;
                    }
                    case 1:
                    {
                        Divider._divisor.v4_1 = value._divisor;

                        Divider._mulShift._mul.v4_1 = value._mulShift._mul;
                        Divider._mulShift._shift.v4_1 = value._mulShift._shift;

                        oldBigM.v4_1 = value._bigM.Reinterpret<Divider<ushort4>.BigM, uint4>();

                        break;
                    }
                    case 2:
                    {
                        Divider._divisor.v4_2 = value._divisor;

                        Divider._mulShift._mul.v4_2 = value._mulShift._mul;
                        Divider._mulShift._shift.v4_2 = value._mulShift._shift;

                        oldBigM.v4_2 = value._bigM.Reinterpret<Divider<ushort4>.BigM, uint4>();

                        break;
                    }
                    case 3:
                    {
                        Divider._divisor.v4_3 = value._divisor;

                        Divider._mulShift._mul.v4_3 = value._mulShift._mul;
                        Divider._mulShift._shift.v4_3 = value._mulShift._shift;

                        oldBigM.v4_3 = value._bigM.Reinterpret<Divider<ushort4>.BigM, uint4>();

                        break;
                    }
                    case 4:
                    {
                        Divider._divisor.v4_4 = value._divisor;

                        Divider._mulShift._mul.v4_4 = value._mulShift._mul;
                        Divider._mulShift._shift.v4_4 = value._mulShift._shift;

                        oldBigM.v4_4 = value._bigM.Reinterpret<Divider<ushort4>.BigM, uint4>();

                        break;
                    }
                    default: throw Assert.Unreachable();
                }

                Divider._bigM = oldBigM.Reinterpret<uint8, Divider<ushort8>.BigM>();
            }
            else
            {
                ushort8 oldDivisor = Divider._divisor;

                ushort8 oldMul    = Divider._mulShift._mul;
                ushort8 oldShift1 = Divider._mulShift._shift;

                if (Architecture.IsSIMDSupported)
                {
                    v128 sameTypeMask = Xse.bslli_si128(Xse.cvtsi64x_si128(bitmask64(8 * sizeof(ushort4))), index * sizeof(ushort));
                    v128 alignedDivisor = Xse.bslli_si128(value._divisor,          index * sizeof(ushort));
                    v128 alignedMul     = Xse.bslli_si128(value._mulShift._mul,    index * sizeof(ushort));
                    v128 alignedShift1  = Xse.bslli_si128(value._mulShift._shift, index * sizeof(ushort));
                    oldDivisor = Xse.blendv_si128(oldDivisor, alignedDivisor, sameTypeMask);
                    oldMul     = Xse.blendv_si128(oldMul,     alignedMul,     sameTypeMask);
                    oldShift1  = Xse.blendv_si128(oldShift1,  alignedShift1,  sameTypeMask);

                    if (Avx2.IsAvx2Supported)
                    {
                        v256 bigMMask = Xse.mm256_bslli_si256(Avx.mm256_castsi128_si256(Xse.setall_si128()), index * sizeof(uint));
                        v256 alignedBigM = Xse.mm256_bslli_si256(Avx.mm256_castsi128_si256(RegisterConversion.ToV128(*(uint4*)&value._bigM)), index * sizeof(uint));
                        oldBigM = Xse.mm256_blendv_si256(oldBigM, alignedBigM, bigMMask);
                    }
                    else
                    {
                        oldBigM.SetField(value._bigM, index, sizeof(uint));
                    }
                }
                else
                {
                    oldDivisor.SetField(value._divisor, index, sizeof(ushort));
                    oldMul.SetField(value._mulShift._mul, index, sizeof(ushort));
                    oldShift1.SetField(value._mulShift._shift, index, sizeof(ushort));
                    oldBigM.SetField(value._bigM, index, sizeof(uint));
                }

                Divider._divisor = oldDivisor;

                Divider._mulShift._mul  = oldMul;
                Divider._mulShift._shift = oldShift1;

                Divider._bigM  = oldBigM.Reinterpret<uint8, Divider<ushort8>.BigM>();
            }

            Divider._promises = (Divider._promises & value._promises) | new Divider<ushort8>.DividerPromise(Divider._divisor, sign, sizeof(ushort));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void SetInnerDividerBase(ref this Divider<ushort16> Divider, Divider<ushort> value, int index, Signedness sign)
        {
Assert.IsWithinArrayBounds(index, 16);

            Divider._divisor[index] = value._divisor;

            Divider._mulShift._mul[index] = value._mulShift._mul;
            Divider._mulShift._shift[index] = value._mulShift._shift;

            if (constexpr.IS_CONST(index))
            {
                if (index < 8)
                {
                    Divider._bigM._mulLo.SetField(value._bigM, index);
                }
                else
                {
                    Divider._bigM._mulHi.SetField(value._bigM, index - 8);
                }
            }
            else
            {
                Divider._bigM.SetField(value._bigM, index);
            }

            Divider._promises = (Divider._promises & value._promises) | new Divider<ushort16>.DividerPromise(Divider._divisor, sign, sizeof(ushort));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void SetInnerDividerBase(ref this Divider<ushort16> Divider, Divider<ushort2> value, int index, Signedness sign)
        {
Assert.IsWithinArrayBounds(index, 15);

            Divider<ushort16>.BigM oldBigM = Divider._bigM;

            if (constexpr.IS_CONST(index))
            {
                uint8 oldBigM_lo = oldBigM.GetField<Divider<ushort16>.BigM, uint8>(0);
                uint8 oldBigM_hi = oldBigM.GetField<Divider<ushort16>.BigM, uint8>(1);

                switch (index)
                {
                    case 0:
                    {
                        Divider._divisor.v2_0 = value._divisor;

                        Divider._mulShift._mul.v2_0 = value._mulShift._mul;
                        Divider._mulShift._shift.v2_0 = value._mulShift._shift;

                        oldBigM_lo.v2_0 = value._bigM.Reinterpret<Divider<ushort2>.BigM, uint2>();

                        break;
                    }
                    case 1:
                    {
                        Divider._divisor.v2_1 = value._divisor;

                        Divider._mulShift._mul.v2_1 = value._mulShift._mul;
                        Divider._mulShift._shift.v2_1 = value._mulShift._shift;

                        oldBigM_lo.v2_1 = value._bigM.Reinterpret<Divider<ushort2>.BigM, uint2>();

                        break;
                    }
                    case 2:
                    {
                        Divider._divisor.v2_2 = value._divisor;

                        Divider._mulShift._mul.v2_2 = value._mulShift._mul;
                        Divider._mulShift._shift.v2_2 = value._mulShift._shift;

                        oldBigM_lo.v2_2 = value._bigM.Reinterpret<Divider<ushort2>.BigM, uint2>();

                        break;
                    }
                    case 3:
                    {
                        Divider._divisor.v2_3 = value._divisor;

                        Divider._mulShift._mul.v2_3 = value._mulShift._mul;
                        Divider._mulShift._shift.v2_3 = value._mulShift._shift;

                        oldBigM_lo.v2_3 = value._bigM.Reinterpret<Divider<ushort2>.BigM, uint2>();

                        break;
                    }
                    case 4:
                    {
                        Divider._divisor.v2_4 = value._divisor;

                        Divider._mulShift._mul.v2_4 = value._mulShift._mul;
                        Divider._mulShift._shift.v2_4 = value._mulShift._shift;

                        oldBigM_lo.v2_4 = value._bigM.Reinterpret<Divider<ushort2>.BigM, uint2>();

                        break;
                    }
                    case 5:
                    {
                        Divider._divisor.v2_5 = value._divisor;

                        Divider._mulShift._mul.v2_5 = value._mulShift._mul;
                        Divider._mulShift._shift.v2_5 = value._mulShift._shift;

                        oldBigM_lo.v2_5 = value._bigM.Reinterpret<Divider<ushort2>.BigM, uint2>();

                        break;
                    }
                    case 6:
                    {
                        Divider._divisor.v2_6 = value._divisor;

                        Divider._mulShift._mul.v2_6 = value._mulShift._mul;
                        Divider._mulShift._shift.v2_6 = value._mulShift._shift;

                        oldBigM_lo.v2_6 = value._bigM.Reinterpret<Divider<ushort2>.BigM, uint2>();

                        break;
                    }
                    case 7:
                    {
                        Divider._divisor.v2_7 = value._divisor;

                        Divider._mulShift._mul.v2_7 = value._mulShift._mul;
                        Divider._mulShift._shift.v2_7 = value._mulShift._shift;

                        oldBigM_lo.x7 = value._bigM.Reinterpret<Divider<ushort2>.BigM, uint2>().x;
                        oldBigM_hi.x0  = value._bigM.Reinterpret<Divider<ushort2>.BigM, uint2>().y;

                        break;
                    }
                    case 8:
                    {
                        Divider._divisor.v2_8 = value._divisor;

                        Divider._mulShift._mul.v2_8 = value._mulShift._mul;
                        Divider._mulShift._shift.v2_8 = value._mulShift._shift;

                        oldBigM_hi.v2_0 = value._bigM.Reinterpret<Divider<ushort2>.BigM, uint2>();

                        break;
                    }
                    case 9:
                    {
                        Divider._divisor.v2_9 = value._divisor;

                        Divider._mulShift._mul.v2_9 = value._mulShift._mul;
                        Divider._mulShift._shift.v2_9 = value._mulShift._shift;

                        oldBigM_hi.v2_1 = value._bigM.Reinterpret<Divider<ushort2>.BigM, uint2>();

                        break;
                    }
                    case 10:
                    {
                        Divider._divisor.v2_10 = value._divisor;

                        Divider._mulShift._mul.v2_10 = value._mulShift._mul;
                        Divider._mulShift._shift.v2_10 = value._mulShift._shift;

                        oldBigM_hi.v2_2 = value._bigM.Reinterpret<Divider<ushort2>.BigM, uint2>();

                        break;
                    }
                    case 11:
                    {
                        Divider._divisor.v2_11 = value._divisor;

                        Divider._mulShift._mul.v2_11 = value._mulShift._mul;
                        Divider._mulShift._shift.v2_11 = value._mulShift._shift;

                        oldBigM_hi.v2_3 = value._bigM.Reinterpret<Divider<ushort2>.BigM, uint2>();

                        break;
                    }
                    case 12:
                    {
                        Divider._divisor.v2_12 = value._divisor;

                        Divider._mulShift._mul.v2_12 = value._mulShift._mul;
                        Divider._mulShift._shift.v2_12 = value._mulShift._shift;

                        oldBigM_hi.v2_4 = value._bigM.Reinterpret<Divider<ushort2>.BigM, uint2>();

                        break;
                    }
                    case 13:
                    {
                        Divider._divisor.v2_13 = value._divisor;

                        Divider._mulShift._mul.v2_13 = value._mulShift._mul;
                        Divider._mulShift._shift.v2_13 = value._mulShift._shift;

                        oldBigM_hi.v2_5 = value._bigM.Reinterpret<Divider<ushort2>.BigM, uint2>();

                        break;
                    }
                    case 14:
                    {
                        Divider._divisor.v2_14 = value._divisor;

                        Divider._mulShift._mul.v2_14 = value._mulShift._mul;
                        Divider._mulShift._shift.v2_14 = value._mulShift._shift;

                        oldBigM_hi.v2_6 = value._bigM.Reinterpret<Divider<ushort2>.BigM, uint2>();

                        break;
                    }
                    default: throw Assert.Unreachable();
                }

                oldBigM.SetField(oldBigM_lo, 0);
                oldBigM.SetField(oldBigM_hi, 1);
            }
            else
            {
                ushort16 oldDivisor = Divider._divisor;

                ushort16 oldMul    = Divider._mulShift._mul;
                ushort16 oldShift1 = Divider._mulShift._shift;

                if (Avx2.IsAvx2Supported)
                {
                    v256 sameTypeMask = Xse.mm256_bslli_si256(Xse.mm256_cvtsi32_si256(bitmask32(8 * sizeof(ushort2))),   index * sizeof(ushort));
                    v256 alignedDivisor = Xse.mm256_bslli_si256(Avx.mm256_castsi128_si256(value._divisor),          index * sizeof(ushort));
                    v256 alignedMul     = Xse.mm256_bslli_si256(Avx.mm256_castsi128_si256(value._mulShift._mul),    index * sizeof(ushort));
                    v256 alignedShift1  = Xse.mm256_bslli_si256(Avx.mm256_castsi128_si256(value._mulShift._shift), index * sizeof(ushort));
                    oldDivisor = Xse.mm256_blendv_si256(oldDivisor, alignedDivisor, sameTypeMask);
                    oldMul     = Xse.mm256_blendv_si256(oldMul,     alignedMul,     sameTypeMask);
                    oldShift1  = Xse.mm256_blendv_si256(oldShift1,  alignedShift1,  sameTypeMask);
                }
                else
                {
                    oldDivisor.SetField(value._divisor, index, sizeof(ushort));
                    oldMul.SetField(value._mulShift._mul, index, sizeof(ushort));
                    oldShift1.SetField(value._mulShift._shift, index, sizeof(ushort));
                }

                oldBigM.SetField(value._bigM, index, sizeof(uint));

                Divider._divisor = oldDivisor;

                Divider._mulShift._mul  = oldMul;
                Divider._mulShift._shift = oldShift1;
            }

            Divider._bigM = oldBigM;

            Divider._promises = (Divider._promises & value._promises) | new Divider<ushort16>.DividerPromise(Divider._divisor, sign, sizeof(ushort));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void SetInnerDividerBase(ref this Divider<ushort16> Divider, Divider<ushort3> value, int index, Signedness sign)
        {
Assert.IsWithinArrayBounds(index, 14);

            Divider<ushort16>.BigM oldBigM = Divider._bigM;

            if (constexpr.IS_CONST(index))
            {
                uint8 oldBigM_lo = oldBigM.GetField<Divider<ushort16>.BigM, uint8>(0);
                uint8 oldBigM_hi = oldBigM.GetField<Divider<ushort16>.BigM, uint8>(1);

                switch (index)
                {
                    case 0:
                    {
                        Divider._divisor.v3_0 = value._divisor;

                        Divider._mulShift._mul.v3_0 = value._mulShift._mul;
                        Divider._mulShift._shift.v3_0 = value._mulShift._shift;

                        oldBigM_lo.v3_0 = value._bigM.Reinterpret<Divider<ushort3>.BigM, uint3>();

                        break;
                    }
                    case 1:
                    {
                        Divider._divisor.v3_1 = value._divisor;

                        Divider._mulShift._mul.v3_1 = value._mulShift._mul;
                        Divider._mulShift._shift.v3_1 = value._mulShift._shift;

                        oldBigM_lo.v3_1 = value._bigM.Reinterpret<Divider<ushort3>.BigM, uint3>();

                        break;
                    }
                    case 2:
                    {
                        Divider._divisor.v3_2 = value._divisor;

                        Divider._mulShift._mul.v3_2 = value._mulShift._mul;
                        Divider._mulShift._shift.v3_2 = value._mulShift._shift;

                        oldBigM_lo.v3_2 = value._bigM.Reinterpret<Divider<ushort3>.BigM, uint3>();

                        break;
                    }
                    case 3:
                    {
                        Divider._divisor.v3_3 = value._divisor;

                        Divider._mulShift._mul.v3_3 = value._mulShift._mul;
                        Divider._mulShift._shift.v3_3 = value._mulShift._shift;

                        oldBigM_lo.v3_3 = value._bigM.Reinterpret<Divider<ushort3>.BigM, uint3>();

                        break;
                    }
                    case 4:
                    {
                        Divider._divisor.v3_4 = value._divisor;

                        Divider._mulShift._mul.v3_4 = value._mulShift._mul;
                        Divider._mulShift._shift.v3_4 = value._mulShift._shift;

                        oldBigM_lo.v3_4 = value._bigM.Reinterpret<Divider<ushort3>.BigM, uint3>();

                        break;
                    }
                    case 5:
                    {
                        Divider._divisor.v3_5 = value._divisor;

                        Divider._mulShift._mul.v3_5 = value._mulShift._mul;
                        Divider._mulShift._shift.v3_5 = value._mulShift._shift;

                        oldBigM_lo.v3_5 = value._bigM.Reinterpret<Divider<ushort3>.BigM, uint3>();

                        break;
                    }
                    case 6:
                    {
                        Divider._divisor.v3_6 = value._divisor;

                        Divider._mulShift._mul.v3_6 = value._mulShift._mul;
                        Divider._mulShift._shift.v3_6 = value._mulShift._shift;

                        oldBigM_lo.v2_6 = value._bigM.Reinterpret<Divider<ushort3>.BigM, uint3>().xy;
                        oldBigM_hi.x0  = value._bigM.Reinterpret<Divider<ushort3>.BigM, uint3>().z;

                        break;
                    }
                    case 7:
                    {
                        Divider._divisor.v3_7 = value._divisor;

                        Divider._mulShift._mul.v3_7 = value._mulShift._mul;
                        Divider._mulShift._shift.v3_7 = value._mulShift._shift;

                        oldBigM_lo.x7 = value._bigM.Reinterpret<Divider<ushort3>.BigM, uint3>().x;
                        oldBigM_hi.v2_0 = value._bigM.Reinterpret<Divider<ushort3>.BigM, uint3>().yz;

                        break;
                    }
                    case 8:
                    {
                        Divider._divisor.v3_8 = value._divisor;

                        Divider._mulShift._mul.v3_8 = value._mulShift._mul;
                        Divider._mulShift._shift.v3_8 = value._mulShift._shift;

                        oldBigM_hi.v3_0 = value._bigM.Reinterpret<Divider<ushort3>.BigM, uint3>();

                        break;
                    }
                    case 9:
                    {
                        Divider._divisor.v3_9 = value._divisor;

                        Divider._mulShift._mul.v3_9 = value._mulShift._mul;
                        Divider._mulShift._shift.v3_9 = value._mulShift._shift;

                        oldBigM_hi.v3_1 = value._bigM.Reinterpret<Divider<ushort3>.BigM, uint3>();

                        break;
                    }
                    case 10:
                    {
                        Divider._divisor.v3_10 = value._divisor;

                        Divider._mulShift._mul.v3_10 = value._mulShift._mul;
                        Divider._mulShift._shift.v3_10 = value._mulShift._shift;

                        oldBigM_hi.v3_2 = value._bigM.Reinterpret<Divider<ushort3>.BigM, uint3>();

                        break;
                    }
                    case 11:
                    {
                        Divider._divisor.v3_11 = value._divisor;

                        Divider._mulShift._mul.v3_11 = value._mulShift._mul;
                        Divider._mulShift._shift.v3_11 = value._mulShift._shift;

                        oldBigM_hi.v3_3 = value._bigM.Reinterpret<Divider<ushort3>.BigM, uint3>();

                        break;
                    }
                    case 12:
                    {
                        Divider._divisor.v3_12 = value._divisor;

                        Divider._mulShift._mul.v3_12 = value._mulShift._mul;
                        Divider._mulShift._shift.v3_12 = value._mulShift._shift;

                        oldBigM_hi.v3_4 = value._bigM.Reinterpret<Divider<ushort3>.BigM, uint3>();

                        break;
                    }
                    case 13:
                    {
                        Divider._divisor.v3_13 = value._divisor;

                        Divider._mulShift._mul.v3_13 = value._mulShift._mul;
                        Divider._mulShift._shift.v3_13 = value._mulShift._shift;

                        oldBigM_hi.v3_5 = value._bigM.Reinterpret<Divider<ushort3>.BigM, uint3>();

                        break;
                    }
                    default: throw Assert.Unreachable();
                }

                oldBigM.SetField(oldBigM_lo, 0);
                oldBigM.SetField(oldBigM_hi, 1);
            }
            else
            {
                ushort16 oldDivisor = Divider._divisor;

                ushort16 oldMul    = Divider._mulShift._mul;
                ushort16 oldShift1 = Divider._mulShift._shift;

                if (Avx2.IsAvx2Supported)
                {
                    v256 sameTypeMask = Xse.mm256_bslli_si256(Xse.mm256_cvtsi64x_si256(bitmask64(8 * sizeof(ushort3))),   index * sizeof(ushort));
                    v256 alignedDivisor = Xse.mm256_bslli_si256(Avx.mm256_castsi128_si256(value._divisor),          index * sizeof(ushort));
                    v256 alignedMul     = Xse.mm256_bslli_si256(Avx.mm256_castsi128_si256(value._mulShift._mul),    index * sizeof(ushort));
                    v256 alignedShift1  = Xse.mm256_bslli_si256(Avx.mm256_castsi128_si256(value._mulShift._shift), index * sizeof(ushort));
                    oldDivisor = Xse.mm256_blendv_si256(oldDivisor, alignedDivisor, sameTypeMask);
                    oldMul     = Xse.mm256_blendv_si256(oldMul,     alignedMul,     sameTypeMask);
                    oldShift1  = Xse.mm256_blendv_si256(oldShift1,  alignedShift1,  sameTypeMask);
                }
                else
                {
                    oldDivisor.SetField(value._divisor, index, sizeof(ushort));
                    oldMul.SetField(value._mulShift._mul, index, sizeof(ushort));
                    oldShift1.SetField(value._mulShift._shift, index, sizeof(ushort));
                }

                oldBigM.SetField(value._bigM, index, sizeof(uint));

                Divider._divisor = oldDivisor;

                Divider._mulShift._mul  = oldMul;
                Divider._mulShift._shift = oldShift1;
            }

            Divider._bigM = oldBigM;

            Divider._promises = (Divider._promises & value._promises) | new Divider<ushort16>.DividerPromise(Divider._divisor, sign, sizeof(ushort));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void SetInnerDividerBase(ref this Divider<ushort16> Divider, Divider<ushort4> value, int index, Signedness sign)
        {
Assert.IsWithinArrayBounds(index, 13);

            Divider<ushort16>.BigM oldBigM = Divider._bigM;

            if (constexpr.IS_CONST(index))
            {
                uint8 oldBigM_lo = oldBigM.GetField<Divider<ushort16>.BigM, uint8>(0);
                uint8 oldBigM_hi = oldBigM.GetField<Divider<ushort16>.BigM, uint8>(1);

                switch (index)
                {
                    case 0:
                    {
                        Divider._divisor.v4_0 = value._divisor;

                        Divider._mulShift._mul.v4_0 = value._mulShift._mul;
                        Divider._mulShift._shift.v4_0 = value._mulShift._shift;

                        oldBigM_lo.v4_0 = value._bigM.Reinterpret<Divider<ushort4>.BigM, uint4>();

                        break;
                    }
                    case 1:
                    {
                        Divider._divisor.v4_1 = value._divisor;

                        Divider._mulShift._mul.v4_1 = value._mulShift._mul;
                        Divider._mulShift._shift.v4_1 = value._mulShift._shift;

                        oldBigM_lo.v4_1 = value._bigM.Reinterpret<Divider<ushort4>.BigM, uint4>();

                        break;
                    }
                    case 2:
                    {
                        Divider._divisor.v4_2 = value._divisor;

                        Divider._mulShift._mul.v4_2 = value._mulShift._mul;
                        Divider._mulShift._shift.v4_2 = value._mulShift._shift;

                        oldBigM_lo.v4_2 = value._bigM.Reinterpret<Divider<ushort4>.BigM, uint4>();

                        break;
                    }
                    case 3:
                    {
                        Divider._divisor.v4_3 = value._divisor;

                        Divider._mulShift._mul.v4_3 = value._mulShift._mul;
                        Divider._mulShift._shift.v4_3 = value._mulShift._shift;

                        oldBigM_lo.v4_3 = value._bigM.Reinterpret<Divider<ushort4>.BigM, uint4>();

                        break;
                    }
                    case 4:
                    {
                        Divider._divisor.v4_4 = value._divisor;

                        Divider._mulShift._mul.v4_4 = value._mulShift._mul;
                        Divider._mulShift._shift.v4_4 = value._mulShift._shift;

                        oldBigM_lo.v4_4 = value._bigM.Reinterpret<Divider<ushort4>.BigM, uint4>();

                        break;
                    }
                    case 5:
                    {
                        Divider._divisor.v4_5 = value._divisor;

                        Divider._mulShift._mul.v4_5 = value._mulShift._mul;
                        Divider._mulShift._shift.v4_5 = value._mulShift._shift;

                        oldBigM_lo.v3_5 = value._bigM.Reinterpret<Divider<ushort4>.BigM, uint4>().xyz;
                        oldBigM_hi.x0  = value._bigM.Reinterpret<Divider<ushort4>.BigM, uint4>().w;

                        break;
                    }
                    case 6:
                    {
                        Divider._divisor.v4_6 = value._divisor;

                        Divider._mulShift._mul.v4_6 = value._mulShift._mul;
                        Divider._mulShift._shift.v4_6 = value._mulShift._shift;

                        oldBigM_lo.v2_6 = value._bigM.Reinterpret<Divider<ushort4>.BigM, uint4>().xy;
                        oldBigM_hi.v2_0 = value._bigM.Reinterpret<Divider<ushort4>.BigM, uint4>().zw;

                        break;
                    }
                    case 7:
                    {
                        Divider._divisor.v4_7 = value._divisor;

                        Divider._mulShift._mul.v4_7 = value._mulShift._mul;
                        Divider._mulShift._shift.v4_7 = value._mulShift._shift;

                        oldBigM_lo.x7 = value._bigM.Reinterpret<Divider<ushort4>.BigM, uint4>().x;
                        oldBigM_hi.v3_0 = value._bigM.Reinterpret<Divider<ushort4>.BigM, uint4>().yzw;

                        break;
                    }
                    case 8:
                    {
                        Divider._divisor.v4_8 = value._divisor;

                        Divider._mulShift._mul.v4_8 = value._mulShift._mul;
                        Divider._mulShift._shift.v4_8 = value._mulShift._shift;

                        oldBigM_hi.v4_0 = value._bigM.Reinterpret<Divider<ushort4>.BigM, uint4>();

                        break;
                    }
                    case 9:
                    {
                        Divider._divisor.v4_9 = value._divisor;

                        Divider._mulShift._mul.v4_9 = value._mulShift._mul;
                        Divider._mulShift._shift.v4_9 = value._mulShift._shift;

                        oldBigM_hi.v4_1 = value._bigM.Reinterpret<Divider<ushort4>.BigM, uint4>();

                        break;
                    }
                    case 10:
                    {
                        Divider._divisor.v4_10 = value._divisor;

                        Divider._mulShift._mul.v4_10 = value._mulShift._mul;
                        Divider._mulShift._shift.v4_10 = value._mulShift._shift;

                        oldBigM_hi.v4_2 = value._bigM.Reinterpret<Divider<ushort4>.BigM, uint4>();

                        break;
                    }
                    case 11:
                    {
                        Divider._divisor.v4_11 = value._divisor;

                        Divider._mulShift._mul.v4_11 = value._mulShift._mul;
                        Divider._mulShift._shift.v4_11 = value._mulShift._shift;

                        oldBigM_hi.v4_3 = value._bigM.Reinterpret<Divider<ushort4>.BigM, uint4>();

                        break;
                    }
                    case 12:
                    {
                        Divider._divisor.v4_12 = value._divisor;

                        Divider._mulShift._mul.v4_12 = value._mulShift._mul;
                        Divider._mulShift._shift.v4_12 = value._mulShift._shift;

                        oldBigM_hi.v4_4 = value._bigM.Reinterpret<Divider<ushort4>.BigM, uint4>();

                        break;
                    }
                    default: throw Assert.Unreachable();
                }

                oldBigM.SetField(oldBigM_lo, 0);
                oldBigM.SetField(oldBigM_hi, 1);
            }
            else
            {
                ushort16 oldDivisor = Divider._divisor;

                ushort16 oldMul    = Divider._mulShift._mul;
                ushort16 oldShift1 = Divider._mulShift._shift;

                if (Avx2.IsAvx2Supported)
                {
                    v256 sameTypeMask = Xse.mm256_bslli_si256(Xse.mm256_cvtsi64x_si256(bitmask64(8 * sizeof(ushort4))),   index * sizeof(ushort));
                    v256 alignedDivisor = Xse.mm256_bslli_si256(Avx.mm256_castsi128_si256(value._divisor),          index * sizeof(ushort));
                    v256 alignedMul     = Xse.mm256_bslli_si256(Avx.mm256_castsi128_si256(value._mulShift._mul),    index * sizeof(ushort));
                    v256 alignedShift1  = Xse.mm256_bslli_si256(Avx.mm256_castsi128_si256(value._mulShift._shift), index * sizeof(ushort));
                    oldDivisor = Xse.mm256_blendv_si256(oldDivisor, alignedDivisor, sameTypeMask);
                    oldMul     = Xse.mm256_blendv_si256(oldMul,     alignedMul,     sameTypeMask);
                    oldShift1  = Xse.mm256_blendv_si256(oldShift1,  alignedShift1,  sameTypeMask);
                }
                else
                {
                    oldDivisor.SetField(value._divisor, index, sizeof(ushort));
                    oldMul.SetField(value._mulShift._mul, index, sizeof(ushort));
                    oldShift1.SetField(value._mulShift._shift, index, sizeof(ushort));
                }

                oldBigM.SetField(value._bigM, index, sizeof(uint));

                Divider._divisor = oldDivisor;

                Divider._mulShift._mul  = oldMul;
                Divider._mulShift._shift = oldShift1;
            }

            Divider._bigM = oldBigM;

            Divider._promises = (Divider._promises & value._promises) | new Divider<ushort16>.DividerPromise(Divider._divisor, sign, sizeof(ushort));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void SetInnerDividerBase(ref this Divider<ushort16> Divider, Divider<ushort8> value, int index, Signedness sign)
        {
Assert.IsWithinArrayBounds(index, 9);

            Divider<ushort16>.BigM oldBigM = Divider._bigM;

            if (constexpr.IS_CONST(index))
            {
                uint8 oldBigM_lo = oldBigM.GetField<Divider<ushort16>.BigM, uint8>(0);
                uint8 oldBigM_hi = oldBigM.GetField<Divider<ushort16>.BigM, uint8>(1);

                switch (index)
                {
                    case 0:
                    {
                        Divider._divisor.v8_0 = value._divisor;

                        Divider._mulShift._mul.v8_0 = value._mulShift._mul;
                        Divider._mulShift._shift.v8_0 = value._mulShift._shift;

                        oldBigM_lo = value._bigM.Reinterpret<Divider<ushort8>.BigM, uint8>();

                        break;
                    }
                    case 1:
                    {
                        Divider._divisor.v8_1 = value._divisor;

                        Divider._mulShift._mul.v8_1 = value._mulShift._mul;
                        Divider._mulShift._shift.v8_1 = value._mulShift._shift;

                        if (Avx2.IsAvx2Supported)
                        {
                            oldBigM_lo = Avx2.mm256_blend_epi32(oldBigM_lo, Xse.mm256_bslli_si256(value._bigM.Reinterpret<Divider<ushort8>.BigM, uint8>(), 1 * sizeof(uint)), 0b1111_1110);
                            oldBigM_hi = Avx2.mm256_blend_epi32(oldBigM_hi, Xse.mm256_bsrli_si256(value._bigM.Reinterpret<Divider<ushort8>.BigM, uint8>(), 7 * sizeof(uint)), 0b0000_0001);
                        }
                        else
                        {
                            uint4 lolo = oldBigM_lo.v4_0;
                            uint4 lohi = oldBigM_lo.v4_4;
                            uint4 hilo = oldBigM_hi.v4_0;
                            uint4 hihi = oldBigM_hi.v4_4;
                            lolo.yzw = value._bigM.Reinterpret<Divider<ushort8>.BigM, uint8>().v4_0.xyz;
                            lohi.x   = value._bigM.Reinterpret<Divider<ushort8>.BigM, uint8>().v4_0.w;
                            lohi.yzw = value._bigM.Reinterpret<Divider<ushort8>.BigM, uint8>().v4_4.xyz;
                            hilo.x   = value._bigM.Reinterpret<Divider<ushort8>.BigM, uint8>().v4_4.w;

                            oldBigM_lo = new uint8(lolo, lohi);
                            oldBigM_hi = new uint8(hilo, hihi);
                        }

                        break;
                    }
                    case 2:
                    {
                        Divider._divisor.v8_2 = value._divisor;

                        Divider._mulShift._mul.v8_2 = value._mulShift._mul;
                        Divider._mulShift._shift.v8_2 = value._mulShift._shift;

                        if (Avx2.IsAvx2Supported)
                        {
                            oldBigM_lo = Avx2.mm256_blend_epi32(oldBigM_lo, Xse.mm256_bslli_si256(value._bigM.Reinterpret<Divider<ushort8>.BigM, uint8>(), 2 * sizeof(uint)), 0b1111_1100);
                            oldBigM_hi = Avx2.mm256_blend_epi32(oldBigM_hi, Xse.mm256_bsrli_si256(value._bigM.Reinterpret<Divider<ushort8>.BigM, uint8>(), 6 * sizeof(uint)), 0b0000_0011);
                        }
                        else
                        {
                            uint4 lolo = oldBigM_lo.v4_0;
                            uint4 lohi = oldBigM_lo.v4_4;
                            uint4 hilo = oldBigM_hi.v4_0;
                            uint4 hihi = oldBigM_hi.v4_4;
                            lolo.zw   = value._bigM.Reinterpret<Divider<ushort8>.BigM, uint8>().v4_0.xy;
                            lohi.xy   = value._bigM.Reinterpret<Divider<ushort8>.BigM, uint8>().v4_0.zw;
                            lohi.zw   = value._bigM.Reinterpret<Divider<ushort8>.BigM, uint8>().v4_4.xy;
                            hilo.xy   = value._bigM.Reinterpret<Divider<ushort8>.BigM, uint8>().v4_4.zw;

                            oldBigM_lo = new uint8(lolo, lohi);
                            oldBigM_hi = new uint8(hilo, hihi);
                        }

                        break;
                    }
                    case 3:
                    {
                        Divider._divisor.v8_3 = value._divisor;

                        Divider._mulShift._mul.v8_3 = value._mulShift._mul;
                        Divider._mulShift._shift.v8_3 = value._mulShift._shift;

                        if (Avx2.IsAvx2Supported)
                        {
                            oldBigM_lo = Avx2.mm256_blend_epi32(oldBigM_lo, Xse.mm256_bslli_si256(value._bigM.Reinterpret<Divider<ushort8>.BigM, uint8>(), 3 * sizeof(uint)), 0b1111_1000);
                            oldBigM_hi = Avx2.mm256_blend_epi32(oldBigM_hi, Xse.mm256_bsrli_si256(value._bigM.Reinterpret<Divider<ushort8>.BigM, uint8>(), 5 * sizeof(uint)), 0b0000_0111);
                        }
                        else
                        {
                            uint4 lolo = oldBigM_lo.v4_0;
                            uint4 lohi = oldBigM_lo.v4_4;
                            uint4 hilo = oldBigM_hi.v4_0;
                            uint4 hihi = oldBigM_hi.v4_4;
                            lolo.w     = value._bigM.Reinterpret<Divider<ushort8>.BigM, uint8>().v4_0.x;
                            lohi.xyz   = value._bigM.Reinterpret<Divider<ushort8>.BigM, uint8>().v4_0.yzw;
                            lohi.w     = value._bigM.Reinterpret<Divider<ushort8>.BigM, uint8>().v4_4.x;
                            hilo.xyz   = value._bigM.Reinterpret<Divider<ushort8>.BigM, uint8>().v4_4.yzw;

                            oldBigM_lo = new uint8(lolo, lohi);
                            oldBigM_hi = new uint8(hilo, hihi);
                        }

                        break;
                    }
                    case 4:
                    {
                        Divider._divisor.v8_4 = value._divisor;

                        Divider._mulShift._mul.v8_4 = value._mulShift._mul;
                        Divider._mulShift._shift.v8_4 = value._mulShift._shift;

                        oldBigM_lo.v4_4 = value._bigM.Reinterpret<Divider<ushort8>.BigM, uint8>().v4_0;
                        oldBigM_hi.v4_0 = value._bigM.Reinterpret<Divider<ushort8>.BigM, uint8>().v4_4;

                        break;
                    }
                    case 5:
                    {
                        Divider._divisor.v8_5 = value._divisor;

                        Divider._mulShift._mul.v8_5 = value._mulShift._mul;
                        Divider._mulShift._shift.v8_5 = value._mulShift._shift;

                        if (Avx2.IsAvx2Supported)
                        {
                            oldBigM_lo = Avx2.mm256_blend_epi32(oldBigM_lo, Xse.mm256_bslli_si256(value._bigM.Reinterpret<Divider<ushort8>.BigM, uint8>(), 5 * sizeof(uint)), 0b1110_0000);
                            oldBigM_hi = Avx2.mm256_blend_epi32(oldBigM_hi, Xse.mm256_bsrli_si256(value._bigM.Reinterpret<Divider<ushort8>.BigM, uint8>(), 3 * sizeof(uint)), 0b0001_1111);
                        }
                        else
                        {
                            uint4 lolo = oldBigM_lo.v4_0;
                            uint4 lohi = oldBigM_lo.v4_4;
                            uint4 hilo = oldBigM_hi.v4_0;
                            uint4 hihi = oldBigM_hi.v4_4;
                            lohi.yzw   = value._bigM.Reinterpret<Divider<ushort8>.BigM, uint8>().v4_0.xyz;
                            hilo.x     = value._bigM.Reinterpret<Divider<ushort8>.BigM, uint8>().v4_0.w;
                            hilo.yzw   = value._bigM.Reinterpret<Divider<ushort8>.BigM, uint8>().v4_4.xyz;
                            hihi.x     = value._bigM.Reinterpret<Divider<ushort8>.BigM, uint8>().v4_4.w;

                            oldBigM_lo = new uint8(lolo, lohi);
                            oldBigM_hi = new uint8(hilo, hihi);
                        }

                        break;
                    }
                    case 6:
                    {
                        Divider._divisor.v8_6 = value._divisor;

                        Divider._mulShift._mul.v8_6 = value._mulShift._mul;
                        Divider._mulShift._shift.v8_6 = value._mulShift._shift;

                        if (Avx2.IsAvx2Supported)
                        {
                            oldBigM_lo = Avx2.mm256_blend_epi32(oldBigM_lo, Xse.mm256_bslli_si256(value._bigM.Reinterpret<Divider<ushort8>.BigM, uint8>(), 6 * sizeof(uint)), 0b1100_0000);
                            oldBigM_hi = Avx2.mm256_blend_epi32(oldBigM_hi, Xse.mm256_bsrli_si256(value._bigM.Reinterpret<Divider<ushort8>.BigM, uint8>(), 2 * sizeof(uint)), 0b0011_1111);
                        }
                        else
                        {
                            uint4 lolo = oldBigM_lo.v4_0;
                            uint4 lohi = oldBigM_lo.v4_4;
                            uint4 hilo = oldBigM_hi.v4_0;
                            uint4 hihi = oldBigM_hi.v4_4;
                            lohi.zw    = value._bigM.Reinterpret<Divider<ushort8>.BigM, uint8>().v4_0.xy;
                            hilo.xy    = value._bigM.Reinterpret<Divider<ushort8>.BigM, uint8>().v4_0.zw;
                            hilo.zw    = value._bigM.Reinterpret<Divider<ushort8>.BigM, uint8>().v4_4.xy;
                            hihi.xy    = value._bigM.Reinterpret<Divider<ushort8>.BigM, uint8>().v4_4.zw;

                            oldBigM_lo = new uint8(lolo, lohi);
                            oldBigM_hi = new uint8(hilo, hihi);
                        }

                        break;
                    }
                    case 7:
                    {
                        Divider._divisor.v8_7 = value._divisor;

                        Divider._mulShift._mul.v8_7 = value._mulShift._mul;
                        Divider._mulShift._shift.v8_7 = value._mulShift._shift;

                        if (Avx2.IsAvx2Supported)
                        {
                            oldBigM_lo = Avx2.mm256_blend_epi32(oldBigM_lo, Xse.mm256_bslli_si256(value._bigM.Reinterpret<Divider<ushort8>.BigM, uint8>(), 7 * sizeof(uint)), 0b1000_0000);
                            oldBigM_hi = Avx2.mm256_blend_epi32(oldBigM_hi, Xse.mm256_bsrli_si256(value._bigM.Reinterpret<Divider<ushort8>.BigM, uint8>(), 1 * sizeof(uint)), 0b0111_1111);
                        }
                        else
                        {
                            uint4 lolo = oldBigM_lo.v4_0;
                            uint4 lohi = oldBigM_lo.v4_4;
                            uint4 hilo = oldBigM_hi.v4_0;
                            uint4 hihi = oldBigM_hi.v4_4;
                            lohi.w     = value._bigM.Reinterpret<Divider<ushort8>.BigM, uint8>().v4_0.x;
                            hilo.xyz   = value._bigM.Reinterpret<Divider<ushort8>.BigM, uint8>().v4_0.yzw;
                            hilo.w     = value._bigM.Reinterpret<Divider<ushort8>.BigM, uint8>().v4_4.x;
                            hihi.xyz   = value._bigM.Reinterpret<Divider<ushort8>.BigM, uint8>().v4_4.yzw;

                            oldBigM_lo = new uint8(lolo, lohi);
                            oldBigM_hi = new uint8(hilo, hihi);
                        }

                        break;
                    }
                    case 8:
                    {
                        Divider._divisor.v8_8 = value._divisor;

                        Divider._mulShift._mul.v8_8 = value._mulShift._mul;
                        Divider._mulShift._shift.v8_8 = value._mulShift._shift;

                        oldBigM_hi = value._bigM.Reinterpret<Divider<ushort8>.BigM, uint8>();

                        break;
                    }
                    default: throw Assert.Unreachable();
                }

                oldBigM.SetField(oldBigM_lo, 0);
                oldBigM.SetField(oldBigM_hi, 1);
            }
            else
            {
                ushort16 oldDivisor = Divider._divisor;

                ushort16 oldMul    = Divider._mulShift._mul;
                ushort16 oldShift1 = Divider._mulShift._shift;

                if (Avx2.IsAvx2Supported)
                {
                    v256 sameTypeMask = Xse.mm256_bslli_si256(Avx.mm256_castsi128_si256(Xse.setall_si128()),   index * sizeof(ushort));
                    v256 alignedDivisor = Xse.mm256_bslli_si256(Avx.mm256_castsi128_si256(value._divisor),          index * sizeof(ushort));
                    v256 alignedMul     = Xse.mm256_bslli_si256(Avx.mm256_castsi128_si256(value._mulShift._mul),    index * sizeof(ushort));
                    v256 alignedShift1  = Xse.mm256_bslli_si256(Avx.mm256_castsi128_si256(value._mulShift._shift), index * sizeof(ushort));
                    oldDivisor = Xse.mm256_blendv_si256(oldDivisor, alignedDivisor, sameTypeMask);
                    oldMul     = Xse.mm256_blendv_si256(oldMul,     alignedMul,     sameTypeMask);
                    oldShift1  = Xse.mm256_blendv_si256(oldShift1,  alignedShift1,  sameTypeMask);
                }
                else
                {
                    oldDivisor.SetField(value._divisor, index, sizeof(ushort));
                    oldMul.SetField(value._mulShift._mul, index, sizeof(ushort));
                    oldShift1.SetField(value._mulShift._shift, index, sizeof(ushort));
                }

                oldBigM.SetField(value._bigM, index, sizeof(uint));

                Divider._divisor = oldDivisor;

                Divider._mulShift._mul  = oldMul;
                Divider._mulShift._shift = oldShift1;
            }

            Divider._bigM = oldBigM;

            Divider._promises = (Divider._promises & value._promises) | new Divider<ushort16>.DividerPromise(Divider._divisor, sign, sizeof(ushort));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void SetInnerDividerBase(ref this Divider<uint2> Divider, Divider<uint> value, int index, Signedness sign)
        {
Assert.IsWithinArrayBounds(index, 2);

            Divider._divisor[index] = value._divisor;

            Divider._mulShift._mul[index] = value._mulShift._mul;
            Divider._mulShift._shift[index] = value._mulShift._shift;

            Divider._bigM.SetField(value._bigM, index);

            Divider._promises = (Divider._promises & value._promises) | new Divider<uint2>.DividerPromise(Divider._divisor, sign, sizeof(uint));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void SetInnerDividerBase(ref this Divider<uint3> Divider, Divider<uint> value, int index, Signedness sign)
        {
Assert.IsWithinArrayBounds(index, 3);

            Divider._divisor[index] = value._divisor;

            Divider._mulShift._mul[index] = value._mulShift._mul;
            Divider._mulShift._shift[index] = value._mulShift._shift;

            Divider._bigM.SetField(value._bigM, index);

            Divider._promises = (Divider._promises & value._promises) | new Divider<uint3>.DividerPromise(Divider._divisor, sign, sizeof(uint));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void SetInnerDividerBase(ref this Divider<uint3> Divider, Divider<uint2> value, int index, Signedness sign)
        {
Assert.IsWithinArrayBounds(index, 2);

            ulong3 oldBigM = Divider._bigM.Reinterpret<Divider<uint3>.BigM, ulong3>();

            if (constexpr.IS_CONST(index))
            {
                switch (index)
                {
                    case 0:
                    {
                        Divider._divisor.xy = value._divisor;

                        Divider._mulShift._mul.xy = value._mulShift._mul;
                        Divider._mulShift._shift.xy = value._mulShift._shift;

                        oldBigM.xy = value._bigM.Reinterpret<Divider<uint2>.BigM, ulong2>();

                        break;
                    }
                    case 1:
                    {
                        Divider._divisor.yz = value._divisor;

                        Divider._mulShift._mul.yz = value._mulShift._mul;
                        Divider._mulShift._shift.yz = value._mulShift._shift;

                        oldBigM.yz = value._bigM.Reinterpret<Divider<uint2>.BigM, ulong2>();

                        break;
                    }
                    default: throw Assert.Unreachable();
                }

                Divider._bigM = oldBigM.Reinterpret<ulong3, Divider<uint3>.BigM>();
            }
            else
            {
                uint3 oldDivisor = Divider._divisor;

                uint3 oldMul    = Divider._mulShift._mul;
                uint3 oldShift1 = Divider._mulShift._shift;

                if (Architecture.IsSIMDSupported)
                {
                    v128 sameTypeMask = Xse.bslli_si128(Xse.cvtsi64x_si128(bitmask64(8 * sizeof(uint2))), index * sizeof(uint));
                    v128 alignedDivisor = Xse.bslli_si128(RegisterConversion.ToV128(value._divisor),          index * sizeof(uint));
                    v128 alignedMul     = Xse.bslli_si128(RegisterConversion.ToV128(value._mulShift._mul),    index * sizeof(uint));
                    v128 alignedShift1  = Xse.bslli_si128(RegisterConversion.ToV128(value._mulShift._shift), index * sizeof(uint));
                    oldDivisor = RegisterConversion.ToUInt3(Xse.blendv_si128(RegisterConversion.ToV128(oldDivisor), alignedDivisor, sameTypeMask));
                    oldMul     = RegisterConversion.ToUInt3(Xse.blendv_si128(RegisterConversion.ToV128(oldMul),     alignedMul,     sameTypeMask));
                    oldShift1  = RegisterConversion.ToUInt3(Xse.blendv_si128(RegisterConversion.ToV128(oldShift1),  alignedShift1,  sameTypeMask));

                    if (Avx2.IsAvx2Supported)
                    {
                        v256 bigMMask = Xse.mm256_bslli_si256(Avx.mm256_castsi128_si256(Xse.setall_si128()), index * sizeof(ulong));
                        v256 alignedBigM = Xse.mm256_bslli_si256(Avx.mm256_castsi128_si256(*(ulong2*)&value._bigM), index * sizeof(ulong));
                        oldBigM = Xse.mm256_blendv_si256(oldBigM, alignedBigM, bigMMask);
                    }
                    else
                    {
                        oldBigM.SetField(value._bigM, index, sizeof(ulong));
                    }
                }
                else
                {
                    oldDivisor.SetField(value._divisor, index, sizeof(uint));
                    oldMul.SetField(value._mulShift._mul, index, sizeof(uint));
                    oldShift1.SetField(value._mulShift._shift, index, sizeof(uint));
                    oldBigM.SetField(value._bigM, index, sizeof(ulong));
                }

                Divider._divisor = oldDivisor;

                Divider._mulShift._mul  = oldMul;
                Divider._mulShift._shift = oldShift1;

                Divider._bigM  = oldBigM.Reinterpret<ulong3, Divider<uint3>.BigM>();
            }

            Divider._promises = (Divider._promises & value._promises) | new Divider<uint3>.DividerPromise(Divider._divisor, sign, sizeof(uint));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void SetInnerDividerBase(ref this Divider<uint4> Divider, Divider<uint> value, int index, Signedness sign)
        {
Assert.IsWithinArrayBounds(index, 4);

            Divider._divisor[index] = value._divisor;

            Divider._mulShift._mul[index] = value._mulShift._mul;
            Divider._mulShift._shift[index] = value._mulShift._shift;

            Divider._bigM.SetField(value._bigM, index);

            Divider._promises = (Divider._promises & value._promises) | new Divider<uint4>.DividerPromise(Divider._divisor, sign, sizeof(uint));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void SetInnerDividerBase(ref this Divider<uint4> Divider, Divider<uint2> value, int index, Signedness sign)
        {
Assert.IsWithinArrayBounds(index, 3);

            ulong4 oldBigM = Divider._bigM.Reinterpret<Divider<uint4>.BigM, ulong4>();

            if (constexpr.IS_CONST(index))
            {
                switch (index)
                {
                    case 0:
                    {
                        Divider._divisor.xy = value._divisor;

                        Divider._mulShift._mul.xy = value._mulShift._mul;
                        Divider._mulShift._shift.xy = value._mulShift._shift;

                        oldBigM.xy = value._bigM.Reinterpret<Divider<uint2>.BigM, ulong2>();

                        break;
                    }
                    case 1:
                    {
                        Divider._divisor.yz = value._divisor;

                        Divider._mulShift._mul.yz = value._mulShift._mul;
                        Divider._mulShift._shift.yz = value._mulShift._shift;

                        oldBigM.yz = value._bigM.Reinterpret<Divider<uint2>.BigM, ulong2>();

                        break;
                    }
                    case 2:
                    {
                        Divider._divisor.zw = value._divisor;

                        Divider._mulShift._mul.zw = value._mulShift._mul;
                        Divider._mulShift._shift.zw = value._mulShift._shift;

                        oldBigM.zw = value._bigM.Reinterpret<Divider<uint2>.BigM, ulong2>();

                        break;
                    }
                    default: throw Assert.Unreachable();
                }

                Divider._bigM = oldBigM.Reinterpret<ulong4, Divider<uint4>.BigM>();
            }
            else
            {
                uint4 oldDivisor = Divider._divisor;

                uint4 oldMul    = Divider._mulShift._mul;
                uint4 oldShift1 = Divider._mulShift._shift;

                if (Architecture.IsSIMDSupported)
                {
                    v128 sameTypeMask = Xse.bslli_si128(Xse.cvtsi64x_si128(bitmask64(8 * sizeof(uint2))), index * sizeof(uint));
                    v128 alignedDivisor = Xse.bslli_si128(RegisterConversion.ToV128(value._divisor),          index * sizeof(uint));
                    v128 alignedMul     = Xse.bslli_si128(RegisterConversion.ToV128(value._mulShift._mul),    index * sizeof(uint));
                    v128 alignedShift1  = Xse.bslli_si128(RegisterConversion.ToV128(value._mulShift._shift), index * sizeof(uint));
                    oldDivisor = RegisterConversion.ToUInt4(Xse.blendv_si128(RegisterConversion.ToV128(oldDivisor), alignedDivisor, sameTypeMask));
                    oldMul     = RegisterConversion.ToUInt4(Xse.blendv_si128(RegisterConversion.ToV128(oldMul),     alignedMul,     sameTypeMask));
                    oldShift1  = RegisterConversion.ToUInt4(Xse.blendv_si128(RegisterConversion.ToV128(oldShift1),  alignedShift1,  sameTypeMask));

                    if (Avx2.IsAvx2Supported)
                    {
                        v256 bigMMask = Xse.mm256_bslli_si256(Avx.mm256_castsi128_si256(Xse.setall_si128()), index * sizeof(ulong));
                        v256 alignedBigM = Xse.mm256_bslli_si256(Avx.mm256_castsi128_si256(*(ulong2*)&value._bigM), index * sizeof(ulong));
                        oldBigM = Xse.mm256_blendv_si256(oldBigM, alignedBigM, bigMMask);
                    }
                    else
                    {
                        oldBigM.SetField(value._bigM, index, sizeof(ulong));
                    }
                }
                else
                {
                    oldDivisor.SetField(value._divisor, index, sizeof(uint));
                    oldMul.SetField(value._mulShift._mul, index, sizeof(uint));
                    oldShift1.SetField(value._mulShift._shift, index, sizeof(uint));
                    oldBigM.SetField(value._bigM, index, sizeof(ulong));
                }

                Divider._divisor = oldDivisor;

                Divider._mulShift._mul  = oldMul;
                Divider._mulShift._shift = oldShift1;

                Divider._bigM  = oldBigM.Reinterpret<ulong4, Divider<uint4>.BigM>();
            }

            Divider._promises = (Divider._promises & value._promises) | new Divider<uint4>.DividerPromise(Divider._divisor, sign, sizeof(uint));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void SetInnerDividerBase(ref this Divider<uint4> Divider, Divider<uint3> value, int index, Signedness sign)
        {
Assert.IsWithinArrayBounds(index, 2);

            ulong4 oldBigM = Divider._bigM.Reinterpret<Divider<uint4>.BigM, ulong4>();

            if (constexpr.IS_CONST(index))
            {
                switch (index)
                {
                    case 0:
                    {
                        Divider._divisor.xyz = value._divisor;

                        Divider._mulShift._mul.xyz = value._mulShift._mul;
                        Divider._mulShift._shift.xyz = value._mulShift._shift;

                        oldBigM.xyz = value._bigM.Reinterpret<Divider<uint3>.BigM, ulong3>();

                        break;
                    }
                    case 1:
                    {
                        Divider._divisor.yzw = value._divisor;

                        Divider._mulShift._mul.yzw = value._mulShift._mul;
                        Divider._mulShift._shift.yzw = value._mulShift._shift;

                        oldBigM.yzw = value._bigM.Reinterpret<Divider<uint3>.BigM, ulong3>();

                        break;
                    }
                    default: throw Assert.Unreachable();
                }

                Divider._bigM = oldBigM.Reinterpret<ulong4, Divider<uint4>.BigM>();
            }
            else
            {
                uint4 oldDivisor = Divider._divisor;

                uint4 oldMul    = Divider._mulShift._mul;
                uint4 oldShift1 = Divider._mulShift._shift;

                if (Architecture.IsSIMDSupported)
                {
                    v128 sameTypeMask = Xse.bslli_si128(new v128(-1, -1, -1, 0), index * sizeof(uint));
                    v128 alignedDivisor = Xse.bslli_si128(RegisterConversion.ToV128(value._divisor),          index * sizeof(uint));
                    v128 alignedMul     = Xse.bslli_si128(RegisterConversion.ToV128(value._mulShift._mul),    index * sizeof(uint));
                    v128 alignedShift1  = Xse.bslli_si128(RegisterConversion.ToV128(value._mulShift._shift), index * sizeof(uint));
                    oldDivisor = RegisterConversion.ToUInt4(Xse.blendv_si128(RegisterConversion.ToV128(oldDivisor), alignedDivisor, sameTypeMask));
                    oldMul     = RegisterConversion.ToUInt4(Xse.blendv_si128(RegisterConversion.ToV128(oldMul),     alignedMul,     sameTypeMask));
                    oldShift1  = RegisterConversion.ToUInt4(Xse.blendv_si128(RegisterConversion.ToV128(oldShift1),  alignedShift1,  sameTypeMask));

                    if (Avx2.IsAvx2Supported)
                    {
                        v256 bigMMask = Xse.mm256_bslli_si256(new v256(-1L, -1L, -1L, 0L), index * sizeof(ulong));
                        v256 alignedBigM = Xse.mm256_bslli_si256(*(ulong3*)&value._bigM, index * sizeof(ulong));
                        oldBigM = Xse.mm256_blendv_si256(oldBigM, alignedBigM, bigMMask);
                    }
                    else
                    {
                        oldBigM.SetField(value._bigM, index, sizeof(ulong));
                    }
                }
                else
                {
                    oldDivisor.SetField(value._divisor, index, sizeof(uint));
                    oldMul.SetField(value._mulShift._mul, index, sizeof(uint));
                    oldShift1.SetField(value._mulShift._shift, index, sizeof(uint));
                    oldBigM.SetField(value._bigM, index, sizeof(ulong));
                }

                Divider._divisor = oldDivisor;

                Divider._mulShift._mul  = oldMul;
                Divider._mulShift._shift = oldShift1;

                Divider._bigM  = oldBigM.Reinterpret<ulong4, Divider<uint4>.BigM>();
            }

            Divider._promises = (Divider._promises & value._promises) | new Divider<uint4>.DividerPromise(Divider._divisor, sign, sizeof(uint));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void SetInnerDividerBase(ref this Divider<uint8> Divider, Divider<uint> value, int index, Signedness sign)
        {
Assert.IsWithinArrayBounds(index, 8);

            Divider._divisor[index] = value._divisor;

            Divider._mulShift._mul[index] = value._mulShift._mul;
            Divider._mulShift._shift[index] = value._mulShift._shift;

            if (constexpr.IS_CONST(index))
            {
                if (index < 4)
                {
                    Divider._bigM._mulLo.SetField(value._bigM, index);
                }
                else
                {
                    Divider._bigM._mulHi.SetField(value._bigM, index - 4);
                }
            }
            else
            {
                Divider._bigM.SetField(value._bigM, index);
            }

            Divider._promises = (Divider._promises & value._promises) | new Divider<uint8>.DividerPromise(Divider._divisor, sign, sizeof(uint));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void SetInnerDividerBase(ref this Divider<uint8> Divider, Divider<uint2> value, int index, Signedness sign)
        {
Assert.IsWithinArrayBounds(index, 7);

            Divider<uint8>.BigM oldBigM = Divider._bigM;

            if (constexpr.IS_CONST(index))
            {
                ulong4 oldBigM_lo = oldBigM.GetField<Divider<uint8>.BigM, ulong4>(0);
                ulong4 oldBigM_hi = oldBigM.GetField<Divider<uint8>.BigM, ulong4>(1);

                switch (index)
                {
                    case 0:
                    {
                        Divider._divisor.v2_0 = value._divisor;

                        Divider._mulShift._mul.v2_0 = value._mulShift._mul;
                        Divider._mulShift._shift.v2_0 = value._mulShift._shift;

                        oldBigM_lo.xy = value._bigM.Reinterpret<Divider<uint2>.BigM, ulong2>();

                        break;
                    }
                    case 1:
                    {
                        Divider._divisor.v2_1 = value._divisor;

                        Divider._mulShift._mul.v2_1 = value._mulShift._mul;
                        Divider._mulShift._shift.v2_1 = value._mulShift._shift;

                        oldBigM_lo.yz = value._bigM.Reinterpret<Divider<uint2>.BigM, ulong2>();

                        break;
                    }
                    case 2:
                    {
                        Divider._divisor.v2_2 = value._divisor;

                        Divider._mulShift._mul.v2_2 = value._mulShift._mul;
                        Divider._mulShift._shift.v2_2 = value._mulShift._shift;

                        oldBigM_lo.zw = value._bigM.Reinterpret<Divider<uint2>.BigM, ulong2>();

                        break;
                    }
                    case 3:
                    {
                        Divider._divisor.v2_3 = value._divisor;

                        Divider._mulShift._mul.v2_3 = value._mulShift._mul;
                        Divider._mulShift._shift.v2_3 = value._mulShift._shift;

                        oldBigM_lo.w = value._bigM.Reinterpret<Divider<uint2>.BigM, ulong2>().x;
                        oldBigM_hi.x = value._bigM.Reinterpret<Divider<uint2>.BigM, ulong2>().y;

                        break;
                    }
                    case 4:
                    {
                        Divider._divisor.v2_4 = value._divisor;

                        Divider._mulShift._mul.v2_4 = value._mulShift._mul;
                        Divider._mulShift._shift.v2_4 = value._mulShift._shift;

                        oldBigM_hi.xy = value._bigM.Reinterpret<Divider<uint2>.BigM, ulong2>();

                        break;
                    }
                    case 5:
                    {
                        Divider._divisor.v2_5 = value._divisor;

                        Divider._mulShift._mul.v2_5 = value._mulShift._mul;
                        Divider._mulShift._shift.v2_5 = value._mulShift._shift;

                        oldBigM_hi.yz = value._bigM.Reinterpret<Divider<uint2>.BigM, ulong2>();

                        break;
                    }
                    case 6:
                    {
                        Divider._divisor.v2_6 = value._divisor;

                        Divider._mulShift._mul.v2_6 = value._mulShift._mul;
                        Divider._mulShift._shift.v2_6 = value._mulShift._shift;

                        oldBigM_hi.zw = value._bigM.Reinterpret<Divider<uint2>.BigM, ulong2>();

                        break;
                    }
                    default: throw Assert.Unreachable();
                }

                oldBigM.SetField(oldBigM_lo, 0);
                oldBigM.SetField(oldBigM_hi, 1);
            }
            else
            {
                uint8 oldDivisor = Divider._divisor;

                uint8 oldMul    = Divider._mulShift._mul;
                uint8 oldShift1 = Divider._mulShift._shift;

                if (Avx2.IsAvx2Supported)
                {
                    v256 sameTypeMask = Xse.mm256_bslli_si256(Xse.mm256_cvtsi64x_si256(bitmask64(8 * sizeof(uint2))),   index * sizeof(uint));
                    v256 alignedDivisor = Xse.mm256_bslli_si256(Avx.mm256_castsi128_si256(RegisterConversion.ToV128(value._divisor)),          index * sizeof(uint));
                    v256 alignedMul     = Xse.mm256_bslli_si256(Avx.mm256_castsi128_si256(RegisterConversion.ToV128(value._mulShift._mul)),    index * sizeof(uint));
                    v256 alignedShift1  = Xse.mm256_bslli_si256(Avx.mm256_castsi128_si256(RegisterConversion.ToV128(value._mulShift._shift)), index * sizeof(uint));
                    oldDivisor = Xse.mm256_blendv_si256(oldDivisor, alignedDivisor, sameTypeMask);
                    oldMul     = Xse.mm256_blendv_si256(oldMul,     alignedMul,     sameTypeMask);
                    oldShift1  = Xse.mm256_blendv_si256(oldShift1,  alignedShift1,  sameTypeMask);
                }
                else
                {
                    oldDivisor.SetField(value._divisor, index, sizeof(uint));
                    oldMul.SetField(value._mulShift._mul, index, sizeof(uint));
                    oldShift1.SetField(value._mulShift._shift, index, sizeof(uint));
                }

                oldBigM.SetField(value._bigM, index, sizeof(ulong));

                Divider._divisor = oldDivisor;

                Divider._mulShift._mul  = oldMul;
                Divider._mulShift._shift = oldShift1;
            }

            Divider._bigM = oldBigM;

            Divider._promises = (Divider._promises & value._promises) | new Divider<uint8>.DividerPromise(Divider._divisor, sign, sizeof(uint));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void SetInnerDividerBase(ref this Divider<uint8> Divider, Divider<uint3> value, int index, Signedness sign)
        {
Assert.IsWithinArrayBounds(index, 6);

            Divider<uint8>.BigM oldBigM = Divider._bigM;

            if (constexpr.IS_CONST(index))
            {
                ulong4 oldBigM_lo = oldBigM.GetField<Divider<uint8>.BigM, ulong4>(0);
                ulong4 oldBigM_hi = oldBigM.GetField<Divider<uint8>.BigM, ulong4>(1);

                switch (index)
                {
                    case 0:
                    {
                        Divider._divisor.v3_0 = value._divisor;

                        Divider._mulShift._mul.v3_0 = value._mulShift._mul;
                        Divider._mulShift._shift.v3_0 = value._mulShift._shift;

                        oldBigM_lo.xyz = value._bigM.Reinterpret<Divider<uint3>.BigM, ulong3>();

                        break;
                    }
                    case 1:
                    {
                        Divider._divisor.v3_1 = value._divisor;

                        Divider._mulShift._mul.v3_1 = value._mulShift._mul;
                        Divider._mulShift._shift.v3_1 = value._mulShift._shift;

                        oldBigM_lo.yzw = value._bigM.Reinterpret<Divider<uint3>.BigM, ulong3>();

                        break;
                    }
                    case 2:
                    {
                        Divider._divisor.v3_2 = value._divisor;

                        Divider._mulShift._mul.v3_2 = value._mulShift._mul;
                        Divider._mulShift._shift.v3_2 = value._mulShift._shift;

                        oldBigM_lo.zw = value._bigM.Reinterpret<Divider<uint3>.BigM, ulong3>().xy;
                        oldBigM_hi.x  = value._bigM.Reinterpret<Divider<uint3>.BigM, ulong3>().z;

                        break;
                    }
                    case 3:
                    {
                        Divider._divisor.v3_3 = value._divisor;

                        Divider._mulShift._mul.v3_3 = value._mulShift._mul;
                        Divider._mulShift._shift.v3_3 = value._mulShift._shift;

                        oldBigM_lo.w = value._bigM.Reinterpret<Divider<uint3>.BigM, ulong3>().x;
                        oldBigM_hi.xy  = value._bigM.Reinterpret<Divider<uint3>.BigM, ulong3>().yz;

                        break;
                    }
                    case 4:
                    {
                        Divider._divisor.v3_4 = value._divisor;

                        Divider._mulShift._mul.v3_4 = value._mulShift._mul;
                        Divider._mulShift._shift.v3_4 = value._mulShift._shift;

                        oldBigM_hi.xyz = value._bigM.Reinterpret<Divider<uint3>.BigM, ulong3>();

                        break;
                    }
                    case 5:
                    {
                        Divider._divisor.v3_5 = value._divisor;

                        Divider._mulShift._mul.v3_5 = value._mulShift._mul;
                        Divider._mulShift._shift.v3_5 = value._mulShift._shift;

                        oldBigM_hi.yzw = value._bigM.Reinterpret<Divider<uint3>.BigM, ulong3>();

                        break;
                    }
                    default: throw Assert.Unreachable();
                }

                oldBigM.SetField(oldBigM_lo, 0);
                oldBigM.SetField(oldBigM_hi, 1);
            }
            else
            {
                uint8 oldDivisor = Divider._divisor;

                uint8 oldMul    = Divider._mulShift._mul;
                uint8 oldShift1 = Divider._mulShift._shift;

                if (Avx2.IsAvx2Supported)
                {
                    v256 sameTypeMask = Xse.mm256_bslli_si256(Avx.mm256_castsi128_si256(new v128(-1, -1, -1, 0)),   index * sizeof(uint));
                    v256 alignedDivisor = Xse.mm256_bslli_si256(Avx.mm256_castsi128_si256(RegisterConversion.ToV128(value._divisor)),          index * sizeof(uint));
                    v256 alignedMul     = Xse.mm256_bslli_si256(Avx.mm256_castsi128_si256(RegisterConversion.ToV128(value._mulShift._mul)),    index * sizeof(uint));
                    v256 alignedShift1  = Xse.mm256_bslli_si256(Avx.mm256_castsi128_si256(RegisterConversion.ToV128(value._mulShift._shift)), index * sizeof(uint));
                    oldDivisor = Xse.mm256_blendv_si256(oldDivisor, alignedDivisor, sameTypeMask);
                    oldMul     = Xse.mm256_blendv_si256(oldMul,     alignedMul,     sameTypeMask);
                    oldShift1  = Xse.mm256_blendv_si256(oldShift1,  alignedShift1,  sameTypeMask);
                }
                else
                {
                    oldDivisor.SetField(value._divisor, index, sizeof(uint));
                    oldMul.SetField(value._mulShift._mul, index, sizeof(uint));
                    oldShift1.SetField(value._mulShift._shift, index, sizeof(uint));
                }

                oldBigM.SetField(value._bigM, index, sizeof(ulong));

                Divider._divisor = oldDivisor;

                Divider._mulShift._mul  = oldMul;
                Divider._mulShift._shift = oldShift1;
            }

            Divider._bigM = oldBigM;

            Divider._promises = (Divider._promises & value._promises) | new Divider<uint8>.DividerPromise(Divider._divisor, sign, sizeof(uint));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void SetInnerDividerBase(ref this Divider<uint8> Divider, Divider<uint4> value, int index, Signedness sign)
        {
Assert.IsWithinArrayBounds(index, 5);

            Divider<uint8>.BigM oldBigM = Divider._bigM;

            if (constexpr.IS_CONST(index))
            {
                ulong4 oldBigM_lo = oldBigM.GetField<Divider<uint8>.BigM, ulong4>(0);
                ulong4 oldBigM_hi = oldBigM.GetField<Divider<uint8>.BigM, ulong4>(1);

                switch (index)
                {
                    case 0:
                    {
                        Divider._divisor.v4_0 = value._divisor;

                        Divider._mulShift._mul.v4_0 = value._mulShift._mul;
                        Divider._mulShift._shift.v4_0 = value._mulShift._shift;

                        oldBigM_lo = value._bigM.Reinterpret<Divider<uint4>.BigM, ulong4>();

                        break;
                    }
                    case 1:
                    {
                        Divider._divisor.v4_1 = value._divisor;

                        Divider._mulShift._mul.v4_1 = value._mulShift._mul;
                        Divider._mulShift._shift.v4_1 = value._mulShift._shift;

                        oldBigM_lo.yzw = value._bigM.Reinterpret<Divider<uint4>.BigM, ulong4>().xyz;
                        oldBigM_hi.x   = value._bigM.Reinterpret<Divider<uint4>.BigM, ulong4>().w;

                        break;
                    }
                    case 2:
                    {
                        Divider._divisor.v4_2 = value._divisor;

                        Divider._mulShift._mul.v4_2 = value._mulShift._mul;
                        Divider._mulShift._shift.v4_2 = value._mulShift._shift;

                        oldBigM_lo.zw = value._bigM.Reinterpret<Divider<uint4>.BigM, ulong4>().xy;
                        oldBigM_hi.xy  = value._bigM.Reinterpret<Divider<uint4>.BigM, ulong4>().zw;

                        break;
                    }
                    case 3:
                    {
                        Divider._divisor.v4_3 = value._divisor;

                        Divider._mulShift._mul.v4_3 = value._mulShift._mul;
                        Divider._mulShift._shift.v4_3 = value._mulShift._shift;

                        oldBigM_lo.w = value._bigM.Reinterpret<Divider<uint4>.BigM, ulong4>().x;
                        oldBigM_hi.xyz  = value._bigM.Reinterpret<Divider<uint4>.BigM, ulong4>().yzw;

                        break;
                    }
                    case 4:
                    {
                        Divider._divisor.v4_4 = value._divisor;

                        Divider._mulShift._mul.v4_4 = value._mulShift._mul;
                        Divider._mulShift._shift.v4_4 = value._mulShift._shift;

                        oldBigM_hi = value._bigM.Reinterpret<Divider<uint4>.BigM, ulong4>();

                        break;
                    }
                    default: throw Assert.Unreachable();
                }

                oldBigM.SetField(oldBigM_lo, 0);
                oldBigM.SetField(oldBigM_hi, 1);
            }
            else
            {
                uint8 oldDivisor = Divider._divisor;

                uint8 oldMul    = Divider._mulShift._mul;
                uint8 oldShift1 = Divider._mulShift._shift;

                if (Avx2.IsAvx2Supported)
                {
                    v256 sameTypeMask = Xse.mm256_bslli_si256(Avx.mm256_castsi128_si256(Xse.setall_si128()),   index * sizeof(uint));
                    v256 alignedDivisor = Xse.mm256_bslli_si256(Avx.mm256_castsi128_si256(RegisterConversion.ToV128(value._divisor)),          index * sizeof(uint));
                    v256 alignedMul     = Xse.mm256_bslli_si256(Avx.mm256_castsi128_si256(RegisterConversion.ToV128(value._mulShift._mul)),    index * sizeof(uint));
                    v256 alignedShift1  = Xse.mm256_bslli_si256(Avx.mm256_castsi128_si256(RegisterConversion.ToV128(value._mulShift._shift)), index * sizeof(uint));
                    oldDivisor = Xse.mm256_blendv_si256(oldDivisor, alignedDivisor, sameTypeMask);
                    oldMul     = Xse.mm256_blendv_si256(oldMul,     alignedMul,     sameTypeMask);
                    oldShift1  = Xse.mm256_blendv_si256(oldShift1,  alignedShift1,  sameTypeMask);
                }
                else
                {
                    oldDivisor.SetField(value._divisor, index, sizeof(uint));
                    oldMul.SetField(value._mulShift._mul, index, sizeof(uint));
                    oldShift1.SetField(value._mulShift._shift, index, sizeof(uint));
                }

                oldBigM.SetField(value._bigM, index, sizeof(ulong));

                Divider._divisor = oldDivisor;

                Divider._mulShift._mul  = oldMul;
                Divider._mulShift._shift = oldShift1;
            }

            Divider._bigM = oldBigM;

            Divider._promises = (Divider._promises & value._promises) | new Divider<uint8>.DividerPromise(Divider._divisor, sign, sizeof(uint));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void SetInnerDividerBase(ref this Divider<ulong2> Divider, Divider<ulong> value, int index, Signedness sign)
        {
Assert.IsWithinArrayBounds(index, 2);

            Divider._divisor[index] = value._divisor;

            Divider._mulShift._mul[index] = value._mulShift._mul;
            Divider._mulShift._shift[index] = value._mulShift._shift;

            Divider._bigM.SetField(value._bigM, index);

            Divider._promises = (Divider._promises & value._promises) | new Divider<ulong2>.DividerPromise(Divider._divisor, sign, sizeof(ulong));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void SetInnerDividerBase(ref this Divider<ulong3> Divider, Divider<ulong> value, int index, Signedness sign)
        {
Assert.IsWithinArrayBounds(index, 3);

            Divider._divisor[index] = value._divisor;

            Divider._mulShift._mul[index] = value._mulShift._mul;
            Divider._mulShift._shift[index] = value._mulShift._shift;

            Divider._bigM.SetField(value._bigM, index);

            Divider._promises = (Divider._promises & value._promises) | new Divider<ulong3>.DividerPromise(Divider._divisor, sign, sizeof(ulong));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void SetInnerDividerBase(ref this Divider<ulong3> Divider, Divider<ulong2> value, int index, Signedness sign)
        {
Assert.IsWithinArrayBounds(index, 2);

            if (constexpr.IS_CONST(index))
            {
                switch (index)
                {
                    case 0:
                    {
                        Divider._divisor.xy = value._divisor;

                        Divider._mulShift._mul.xy = value._mulShift._mul;
                        Divider._mulShift._shift.xy = value._mulShift._shift;

                        Divider._bigM.SetField(value._bigM.GetField<Divider<ulong2>.BigM, UInt128>(0), 0);
                        Divider._bigM.SetField(value._bigM.GetField<Divider<ulong2>.BigM, UInt128>(1), 1);

                        break;
                    }
                    case 1:
                    {
                        Divider._divisor.yz = value._divisor;

                        Divider._mulShift._mul.yz = value._mulShift._mul;
                        Divider._mulShift._shift.yz = value._mulShift._shift;

                        Divider._bigM.SetField(value._bigM.GetField<Divider<ulong2>.BigM, UInt128>(0), 1);
                        Divider._bigM.SetField(value._bigM.GetField<Divider<ulong2>.BigM, UInt128>(1), 2);

                        break;
                    }
                    default: throw Assert.Unreachable();
                }
            }
            else
            {
                ulong3 oldDivisor = Divider._divisor;

                ulong3 oldMul    = Divider._mulShift._mul;
                ulong3 oldShift1 = Divider._mulShift._shift;

                if (Avx2.IsAvx2Supported)
                {
                    v256 sameTypeMask = Xse.mm256_bslli_si256(Avx.mm256_castsi128_si256(Xse.setall_si128()),   index * sizeof(ulong));
                    v256 alignedDivisor = Xse.mm256_bslli_si256(Avx.mm256_castsi128_si256(value._divisor),          index * sizeof(ulong));
                    v256 alignedMul     = Xse.mm256_bslli_si256(Avx.mm256_castsi128_si256(value._mulShift._mul),    index * sizeof(ulong));
                    v256 alignedShift1  = Xse.mm256_bslli_si256(Avx.mm256_castsi128_si256(value._mulShift._shift), index * sizeof(ulong));
                    oldDivisor = Xse.mm256_blendv_si256(oldDivisor, alignedDivisor, sameTypeMask);
                    oldMul     = Xse.mm256_blendv_si256(oldMul,     alignedMul,     sameTypeMask);
                    oldShift1  = Xse.mm256_blendv_si256(oldShift1,  alignedShift1,  sameTypeMask);
                }
                else
                {
                    oldDivisor.SetField(value._divisor, index, sizeof(ulong));
                    oldMul.SetField(value._mulShift._mul, index, sizeof(ulong));
                    oldShift1.SetField(value._mulShift._shift, index, sizeof(ulong));
                }

                Divider._divisor = oldDivisor;

                Divider._mulShift._mul  = oldMul;
                Divider._mulShift._shift = oldShift1;

                Divider._bigM.SetField(value._bigM, index, sizeof(UInt128));
            }

            Divider._promises = (Divider._promises & value._promises) | new Divider<ulong3>.DividerPromise(Divider._divisor, sign, sizeof(ulong));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void SetInnerDividerBase(ref this Divider<ulong4> Divider, Divider<ulong> value, int index, Signedness sign)
        {
Assert.IsWithinArrayBounds(index, 4);

            Divider._divisor[index] = value._divisor;

            Divider._mulShift._mul[index] = value._mulShift._mul;
            Divider._mulShift._shift[index] = value._mulShift._shift;

            Divider._bigM.SetField(value._bigM, index);

            Divider._promises = (Divider._promises & value._promises) | new Divider<ulong4>.DividerPromise(Divider._divisor, sign, sizeof(ulong));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void SetInnerDividerBase(ref this Divider<ulong4> Divider, Divider<ulong2> value, int index, Signedness sign)
        {
Assert.IsWithinArrayBounds(index, 3);

            if (constexpr.IS_CONST(index))
            {
                switch (index)
                {
                    case 0:
                    {
                        Divider._divisor.xy = value._divisor;

                        Divider._mulShift._mul.xy = value._mulShift._mul;
                        Divider._mulShift._shift.xy = value._mulShift._shift;

                        Divider._bigM.SetField(value._bigM.GetField<Divider<ulong2>.BigM, UInt128>(0), 0);
                        Divider._bigM.SetField(value._bigM.GetField<Divider<ulong2>.BigM, UInt128>(1), 1);

                        break;
                    }
                    case 1:
                    {
                        Divider._divisor.yz = value._divisor;

                        Divider._mulShift._mul.yz = value._mulShift._mul;
                        Divider._mulShift._shift.yz = value._mulShift._shift;

                        Divider._bigM.SetField(value._bigM.GetField<Divider<ulong2>.BigM, UInt128>(0), 1);
                        Divider._bigM.SetField(value._bigM.GetField<Divider<ulong2>.BigM, UInt128>(1), 2);

                        break;
                    }
                    case 2:
                    {
                        Divider._divisor.zw = value._divisor;

                        Divider._mulShift._mul.zw = value._mulShift._mul;
                        Divider._mulShift._shift.zw = value._mulShift._shift;

                        Divider._bigM.SetField(value._bigM.GetField<Divider<ulong2>.BigM, UInt128>(0), 2);
                        Divider._bigM.SetField(value._bigM.GetField<Divider<ulong2>.BigM, UInt128>(1), 3);

                        break;
                    }
                    default: throw Assert.Unreachable();
                }
            }
            else
            {
                ulong4 oldDivisor = Divider._divisor;

                ulong4 oldMul    = Divider._mulShift._mul;
                ulong4 oldShift1 = Divider._mulShift._shift;

                if (Avx2.IsAvx2Supported)
                {
                    v256 sameTypeMask = Xse.mm256_bslli_si256(Avx.mm256_castsi128_si256(Xse.setall_si128()),   index * sizeof(ulong));
                    v256 alignedDivisor = Xse.mm256_bslli_si256(Avx.mm256_castsi128_si256(value._divisor),          index * sizeof(ulong));
                    v256 alignedMul     = Xse.mm256_bslli_si256(Avx.mm256_castsi128_si256(value._mulShift._mul),    index * sizeof(ulong));
                    v256 alignedShift1  = Xse.mm256_bslli_si256(Avx.mm256_castsi128_si256(value._mulShift._shift), index * sizeof(ulong));
                    oldDivisor = Xse.mm256_blendv_si256(oldDivisor, alignedDivisor, sameTypeMask);
                    oldMul     = Xse.mm256_blendv_si256(oldMul,     alignedMul,     sameTypeMask);
                    oldShift1  = Xse.mm256_blendv_si256(oldShift1,  alignedShift1,  sameTypeMask);
                }
                else
                {
                    oldDivisor.SetField(value._divisor, index, sizeof(ulong));
                    oldMul.SetField(value._mulShift._mul, index, sizeof(ulong));
                    oldShift1.SetField(value._mulShift._shift, index, sizeof(ulong));
                }

                Divider._divisor = oldDivisor;

                Divider._mulShift._mul  = oldMul;
                Divider._mulShift._shift = oldShift1;

                Divider._bigM.SetField(value._bigM, index, sizeof(UInt128));
            }

            Divider._promises = (Divider._promises & value._promises) | new Divider<ulong4>.DividerPromise(Divider._divisor, sign, sizeof(ulong));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void SetInnerDividerBase(ref this Divider<ulong4> Divider, Divider<ulong3> value, int index, Signedness sign)
        {
Assert.IsWithinArrayBounds(index, 2);

            if (constexpr.IS_CONST(index))
            {
                switch (index)
                {
                    case 0:
                    {
                        Divider._divisor.xyz = value._divisor;

                        Divider._mulShift._mul.xyz = value._mulShift._mul;
                        Divider._mulShift._shift.xyz = value._mulShift._shift;

                        Divider._bigM.SetField(value._bigM.GetField<Divider<ulong3>.BigM, UInt128>(0), 0);
                        Divider._bigM.SetField(value._bigM.GetField<Divider<ulong3>.BigM, UInt128>(1), 1);
                        Divider._bigM.SetField(value._bigM.GetField<Divider<ulong3>.BigM, UInt128>(2), 2);

                        break;
                    }
                    case 1:
                    {
                        Divider._divisor.yzw = value._divisor;

                        Divider._mulShift._mul.yzw = value._mulShift._mul;
                        Divider._mulShift._shift.yzw = value._mulShift._shift;

                        Divider._bigM.SetField(value._bigM.GetField<Divider<ulong3>.BigM, UInt128>(0), 1);
                        Divider._bigM.SetField(value._bigM.GetField<Divider<ulong3>.BigM, UInt128>(1), 2);
                        Divider._bigM.SetField(value._bigM.GetField<Divider<ulong3>.BigM, UInt128>(2), 3);

                        break;
                    }
                    default: throw Assert.Unreachable();
                }
            }
            else
            {
                ulong4 oldDivisor = Divider._divisor;

                ulong4 oldMul    = Divider._mulShift._mul;
                ulong4 oldShift1 = Divider._mulShift._shift;

                if (Avx2.IsAvx2Supported)
                {
                    v256 sameTypeMask = Xse.mm256_bslli_si256(new v256(-1L, -1L, -1L, 0L),   index * sizeof(ulong));
                    v256 alignedDivisor = Xse.mm256_bslli_si256(value._divisor,          index * sizeof(ulong));
                    v256 alignedMul     = Xse.mm256_bslli_si256(value._mulShift._mul,    index * sizeof(ulong));
                    v256 alignedShift1  = Xse.mm256_bslli_si256(value._mulShift._shift, index * sizeof(ulong));
                    oldDivisor = Xse.mm256_blendv_si256(oldDivisor, alignedDivisor, sameTypeMask);
                    oldMul     = Xse.mm256_blendv_si256(oldMul,     alignedMul,     sameTypeMask);
                    oldShift1  = Xse.mm256_blendv_si256(oldShift1,  alignedShift1,  sameTypeMask);
                }
                else
                {
                    oldDivisor.SetField(value._divisor, index, sizeof(ulong));
                    oldMul.SetField(value._mulShift._mul, index, sizeof(ulong));
                    oldShift1.SetField(value._mulShift._shift, index, sizeof(ulong));
                }

                Divider._divisor = oldDivisor;

                Divider._mulShift._mul  = oldMul;
                Divider._mulShift._shift = oldShift1;

                Divider._bigM.SetField(value._bigM, index, sizeof(UInt128));
            }

            Divider._promises = (Divider._promises & value._promises) | new Divider<ulong4>.DividerPromise(Divider._divisor, sign, sizeof(ulong));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<byte2> Divider, Divider<byte> value, int index)
        {
            Divider.SetInnerDividerBase(value, index, Signedness.Unsigned);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<byte3> Divider, Divider<byte> value, int index)
        {
            Divider.SetInnerDividerBase(value, index, Signedness.Unsigned);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<byte3> Divider, Divider<byte2> value, int index)
        {
            Divider.SetInnerDividerBase(value, index, Signedness.Unsigned);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<byte4> Divider, Divider<byte> value, int index)
        {
            Divider.SetInnerDividerBase(value, index, Signedness.Unsigned);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<byte4> Divider, Divider<byte2> value, int index)
        {
            Divider.SetInnerDividerBase(value, index, Signedness.Unsigned);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<byte4> Divider, Divider<byte3> value, int index)
        {
            Divider.SetInnerDividerBase(value, index, Signedness.Unsigned);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<byte8> Divider, Divider<byte> value, int index)
        {
            Divider.SetInnerDividerBase(value, index, Signedness.Unsigned);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<byte8> Divider, Divider<byte2> value, int index)
        {
            Divider.SetInnerDividerBase(value, index, Signedness.Unsigned);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<byte8> Divider, Divider<byte3> value, int index)
        {
            Divider.SetInnerDividerBase(value, index, Signedness.Unsigned);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<byte8> Divider, Divider<byte4> value, int index)
        {
            Divider.SetInnerDividerBase(value, index, Signedness.Unsigned);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<byte16> Divider, Divider<byte> value, int index)
        {
            Divider.SetInnerDividerBase(value, index, Signedness.Unsigned);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<byte16> Divider, Divider<byte2> value, int index)
        {
            Divider.SetInnerDividerBase(value, index, Signedness.Unsigned);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<byte16> Divider, Divider<byte3> value, int index)
        {
            Divider.SetInnerDividerBase(value, index, Signedness.Unsigned);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<byte16> Divider, Divider<byte4> value, int index)
        {
            Divider.SetInnerDividerBase(value, index, Signedness.Unsigned);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<byte16> Divider, Divider<byte8> value, int index)
        {
            Divider.SetInnerDividerBase(value, index, Signedness.Unsigned);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<byte32> Divider, Divider<byte> value, int index)
        {
            Divider.SetInnerDividerBase(value, index, Signedness.Unsigned);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<byte32> Divider, Divider<byte2> value, int index)
        {
            Divider.SetInnerDividerBase(value, index, Signedness.Unsigned);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<byte32> Divider, Divider<byte3> value, int index)
        {
            Divider.SetInnerDividerBase(value, index, Signedness.Unsigned);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<byte32> Divider, Divider<byte4> value, int index)
        {
            Divider.SetInnerDividerBase(value, index, Signedness.Unsigned);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<byte32> Divider, Divider<byte8> value, int index)
        {
            Divider.SetInnerDividerBase(value, index, Signedness.Unsigned);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<byte32> Divider, Divider<byte16> value, int index)
        {
            Divider.SetInnerDividerBase(value, index, Signedness.Unsigned);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<ushort2> Divider, Divider<ushort> value, int index)
        {
            Divider.SetInnerDividerBase(value, index, Signedness.Unsigned);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<ushort3> Divider, Divider<ushort> value, int index)
        {
            Divider.SetInnerDividerBase(value, index, Signedness.Unsigned);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<ushort3> Divider, Divider<ushort2> value, int index)
        {
            Divider.SetInnerDividerBase(value, index, Signedness.Unsigned);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<ushort4> Divider, Divider<ushort> value, int index)
        {
            Divider.SetInnerDividerBase(value, index, Signedness.Unsigned);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<ushort4> Divider, Divider<ushort2> value, int index)
        {
            Divider.SetInnerDividerBase(value, index, Signedness.Unsigned);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<ushort4> Divider, Divider<ushort3> value, int index)
        {
            Divider.SetInnerDividerBase(value, index, Signedness.Unsigned);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<ushort8> Divider, Divider<ushort> value, int index)
        {
            Divider.SetInnerDividerBase(value, index, Signedness.Unsigned);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<ushort8> Divider, Divider<ushort2> value, int index)
        {
            Divider.SetInnerDividerBase(value, index, Signedness.Unsigned);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<ushort8> Divider, Divider<ushort3> value, int index)
        {
            Divider.SetInnerDividerBase(value, index, Signedness.Unsigned);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<ushort8> Divider, Divider<ushort4> value, int index)
        {
            Divider.SetInnerDividerBase(value, index, Signedness.Unsigned);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<ushort16> Divider, Divider<ushort> value, int index)
        {
            Divider.SetInnerDividerBase(value, index, Signedness.Unsigned);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<ushort16> Divider, Divider<ushort2> value, int index)
        {
            Divider.SetInnerDividerBase(value, index, Signedness.Unsigned);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<ushort16> Divider, Divider<ushort3> value, int index)
        {
            Divider.SetInnerDividerBase(value, index, Signedness.Unsigned);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<ushort16> Divider, Divider<ushort4> value, int index)
        {
            Divider.SetInnerDividerBase(value, index, Signedness.Unsigned);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<ushort16> Divider, Divider<ushort8> value, int index)
        {
            Divider.SetInnerDividerBase(value, index, Signedness.Unsigned);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<uint2> Divider, Divider<uint> value, int index)
        {
            Divider.SetInnerDividerBase(value, index, Signedness.Unsigned);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<uint3> Divider, Divider<uint> value, int index)
        {
            Divider.SetInnerDividerBase(value, index, Signedness.Unsigned);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<uint3> Divider, Divider<uint2> value, int index)
        {
            Divider.SetInnerDividerBase(value, index, Signedness.Unsigned);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<uint4> Divider, Divider<uint> value, int index)
        {
            Divider.SetInnerDividerBase(value, index, Signedness.Unsigned);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<uint4> Divider, Divider<uint2> value, int index)
        {
            Divider.SetInnerDividerBase(value, index, Signedness.Unsigned);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<uint4> Divider, Divider<uint3> value, int index)
        {
            Divider.SetInnerDividerBase(value, index, Signedness.Unsigned);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<uint8> Divider, Divider<uint> value, int index)
        {
            Divider.SetInnerDividerBase(value, index, Signedness.Unsigned);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<uint8> Divider, Divider<uint2> value, int index)
        {
            Divider.SetInnerDividerBase(value, index, Signedness.Unsigned);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<uint8> Divider, Divider<uint3> value, int index)
        {
            Divider.SetInnerDividerBase(value, index, Signedness.Unsigned);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<uint8> Divider, Divider<uint4> value, int index)
        {
            Divider.SetInnerDividerBase(value, index, Signedness.Unsigned);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<ulong2> Divider, Divider<ulong> value, int index)
        {
            Divider.SetInnerDividerBase(value, index, Signedness.Unsigned);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<ulong3> Divider, Divider<ulong> value, int index)
        {
            Divider.SetInnerDividerBase(value, index, Signedness.Unsigned);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<ulong3> Divider, Divider<ulong2> value, int index)
        {
            Divider.SetInnerDividerBase(value, index, Signedness.Unsigned);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<ulong4> Divider, Divider<ulong> value, int index)
        {
            Divider.SetInnerDividerBase(value, index, Signedness.Unsigned);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<ulong4> Divider, Divider<ulong2> value, int index)
        {
            Divider.SetInnerDividerBase(value, index, Signedness.Unsigned);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<ulong4> Divider, Divider<ulong3> value, int index)
        {
            Divider.SetInnerDividerBase(value, index, Signedness.Unsigned);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<sbyte2> Divider, Divider<sbyte> value, int index)
        {
            Divider<byte2> punned = Divider.Reinterpret<Divider<sbyte2>, Divider<byte2>>();
            punned.SetInnerDividerBase(value.Reinterpret<Divider<sbyte>, Divider<byte>>(), index, Signedness.Signed);
            Divider = punned.Reinterpret<Divider<byte2>, Divider<sbyte2>>();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<sbyte3> Divider, Divider<sbyte> value, int index)
        {
            Divider<byte3> punned = Divider.Reinterpret<Divider<sbyte3>, Divider<byte3>>();
            punned.SetInnerDividerBase(value.Reinterpret<Divider<sbyte>, Divider<byte>>(), index, Signedness.Signed);
            Divider = punned.Reinterpret<Divider<byte3>, Divider<sbyte3>>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<sbyte3> Divider, Divider<sbyte2> value, int index)
        {
            Divider<byte3> punned = Divider.Reinterpret<Divider<sbyte3>, Divider<byte3>>();
            punned.SetInnerDividerBase(value.Reinterpret<Divider<sbyte2>, Divider<byte2>>(), index, Signedness.Signed);
            Divider = punned.Reinterpret<Divider<byte3>, Divider<sbyte3>>();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<sbyte4> Divider, Divider<sbyte> value, int index)
        {
            Divider<byte4> punned = Divider.Reinterpret<Divider<sbyte4>, Divider<byte4>>();
            punned.SetInnerDividerBase(value.Reinterpret<Divider<sbyte>, Divider<byte>>(), index, Signedness.Signed);
            Divider = punned.Reinterpret<Divider<byte4>, Divider<sbyte4>>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<sbyte4> Divider, Divider<sbyte2> value, int index)
        {
            Divider<byte4> punned = Divider.Reinterpret<Divider<sbyte4>, Divider<byte4>>();
            punned.SetInnerDividerBase(value.Reinterpret<Divider<sbyte2>, Divider<byte2>>(), index, Signedness.Signed);
            Divider = punned.Reinterpret<Divider<byte4>, Divider<sbyte4>>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<sbyte4> Divider, Divider<sbyte3> value, int index)
        {
            Divider<byte4> punned = Divider.Reinterpret<Divider<sbyte4>, Divider<byte4>>();
            punned.SetInnerDividerBase(value.Reinterpret<Divider<sbyte3>, Divider<byte3>>(), index, Signedness.Signed);
            Divider = punned.Reinterpret<Divider<byte4>, Divider<sbyte4>>();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<sbyte8> Divider, Divider<sbyte> value, int index)
        {
            Divider<byte8> punned = Divider.Reinterpret<Divider<sbyte8>, Divider<byte8>>();
            punned.SetInnerDividerBase(value.Reinterpret<Divider<sbyte>, Divider<byte>>(), index, Signedness.Signed);
            Divider = punned.Reinterpret<Divider<byte8>, Divider<sbyte8>>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<sbyte8> Divider, Divider<sbyte2> value, int index)
        {
            Divider<byte8> punned = Divider.Reinterpret<Divider<sbyte8>, Divider<byte8>>();
            punned.SetInnerDividerBase(value.Reinterpret<Divider<sbyte2>, Divider<byte2>>(), index, Signedness.Signed);
            Divider = punned.Reinterpret<Divider<byte8>, Divider<sbyte8>>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<sbyte8> Divider, Divider<sbyte3> value, int index)
        {
            Divider<byte8> punned = Divider.Reinterpret<Divider<sbyte8>, Divider<byte8>>();
            punned.SetInnerDividerBase(value.Reinterpret<Divider<sbyte3>, Divider<byte3>>(), index, Signedness.Signed);
            Divider = punned.Reinterpret<Divider<byte8>, Divider<sbyte8>>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<sbyte8> Divider, Divider<sbyte4> value, int index)
        {
            Divider<byte8> punned = Divider.Reinterpret<Divider<sbyte8>, Divider<byte8>>();
            punned.SetInnerDividerBase(value.Reinterpret<Divider<sbyte4>, Divider<byte4>>(), index, Signedness.Signed);
            Divider = punned.Reinterpret<Divider<byte8>, Divider<sbyte8>>();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<sbyte16> Divider, Divider<sbyte> value, int index)
        {
            Divider<byte16> punned = Divider.Reinterpret<Divider<sbyte16>, Divider<byte16>>();
            punned.SetInnerDividerBase(value.Reinterpret<Divider<sbyte>, Divider<byte>>(), index, Signedness.Signed);
            Divider = punned.Reinterpret<Divider<byte16>, Divider<sbyte16>>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<sbyte16> Divider, Divider<sbyte2> value, int index)
        {
            Divider<byte16> punned = Divider.Reinterpret<Divider<sbyte16>, Divider<byte16>>();
            punned.SetInnerDividerBase(value.Reinterpret<Divider<sbyte2>, Divider<byte2>>(), index, Signedness.Signed);
            Divider = punned.Reinterpret<Divider<byte16>, Divider<sbyte16>>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<sbyte16> Divider, Divider<sbyte3> value, int index)
        {
            Divider<byte16> punned = Divider.Reinterpret<Divider<sbyte16>, Divider<byte16>>();
            punned.SetInnerDividerBase(value.Reinterpret<Divider<sbyte3>, Divider<byte3>>(), index, Signedness.Signed);
            Divider = punned.Reinterpret<Divider<byte16>, Divider<sbyte16>>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<sbyte16> Divider, Divider<sbyte4> value, int index)
        {
            Divider<byte16> punned = Divider.Reinterpret<Divider<sbyte16>, Divider<byte16>>();
            punned.SetInnerDividerBase(value.Reinterpret<Divider<sbyte4>, Divider<byte4>>(), index, Signedness.Signed);
            Divider = punned.Reinterpret<Divider<byte16>, Divider<sbyte16>>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<sbyte16> Divider, Divider<sbyte8> value, int index)
        {
            Divider<byte16> punned = Divider.Reinterpret<Divider<sbyte16>, Divider<byte16>>();
            punned.SetInnerDividerBase(value.Reinterpret<Divider<sbyte8>, Divider<byte8>>(), index, Signedness.Signed);
            Divider = punned.Reinterpret<Divider<byte16>, Divider<sbyte16>>();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<sbyte32> Divider, Divider<sbyte> value, int index)
        {
            Divider<byte32> punned = Divider.Reinterpret<Divider<sbyte32>, Divider<byte32>>();
            punned.SetInnerDividerBase(value.Reinterpret<Divider<sbyte>, Divider<byte>>(), index, Signedness.Signed);
            Divider = punned.Reinterpret<Divider<byte32>, Divider<sbyte32>>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<sbyte32> Divider, Divider<sbyte2> value, int index)
        {
            Divider<byte32> punned = Divider.Reinterpret<Divider<sbyte32>, Divider<byte32>>();
            punned.SetInnerDividerBase(value.Reinterpret<Divider<sbyte2>, Divider<byte2>>(), index, Signedness.Signed);
            Divider = punned.Reinterpret<Divider<byte32>, Divider<sbyte32>>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<sbyte32> Divider, Divider<sbyte3> value, int index)
        {
            Divider<byte32> punned = Divider.Reinterpret<Divider<sbyte32>, Divider<byte32>>();
            punned.SetInnerDividerBase(value.Reinterpret<Divider<sbyte3>, Divider<byte3>>(), index, Signedness.Signed);
            Divider = punned.Reinterpret<Divider<byte32>, Divider<sbyte32>>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<sbyte32> Divider, Divider<sbyte4> value, int index)
        {
            Divider<byte32> punned = Divider.Reinterpret<Divider<sbyte32>, Divider<byte32>>();
            punned.SetInnerDividerBase(value.Reinterpret<Divider<sbyte4>, Divider<byte4>>(), index, Signedness.Signed);
            Divider = punned.Reinterpret<Divider<byte32>, Divider<sbyte32>>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<sbyte32> Divider, Divider<sbyte8> value, int index)
        {
            Divider<byte32> punned = Divider.Reinterpret<Divider<sbyte32>, Divider<byte32>>();
            punned.SetInnerDividerBase(value.Reinterpret<Divider<sbyte8>, Divider<byte8>>(), index, Signedness.Signed);
            Divider = punned.Reinterpret<Divider<byte32>, Divider<sbyte32>>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<sbyte32> Divider, Divider<sbyte16> value, int index)
        {
            Divider<byte32> punned = Divider.Reinterpret<Divider<sbyte32>, Divider<byte32>>();
            punned.SetInnerDividerBase(value.Reinterpret<Divider<sbyte16>, Divider<byte16>>(), index, Signedness.Signed);
            Divider = punned.Reinterpret<Divider<byte32>, Divider<sbyte32>>();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<short2> Divider, Divider<short> value, int index)
        {
            Divider<ushort2> punned = Divider.Reinterpret<Divider<short2>, Divider<ushort2>>();
            punned.SetInnerDividerBase(value.Reinterpret<Divider<short>, Divider<ushort>>(), index, Signedness.Signed);
            Divider = punned.Reinterpret<Divider<ushort2>, Divider<short2>>();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<short3> Divider, Divider<short> value, int index)
        {
            Divider<ushort3> punned = Divider.Reinterpret<Divider<short3>, Divider<ushort3>>();
            punned.SetInnerDividerBase(value.Reinterpret<Divider<short>, Divider<ushort>>(), index, Signedness.Signed);
            Divider = punned.Reinterpret<Divider<ushort3>, Divider<short3>>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<short3> Divider, Divider<short2> value, int index)
        {
            Divider<ushort3> punned = Divider.Reinterpret<Divider<short3>, Divider<ushort3>>();
            punned.SetInnerDividerBase(value.Reinterpret<Divider<short2>, Divider<ushort2>>(), index, Signedness.Signed);
            Divider = punned.Reinterpret<Divider<ushort3>, Divider<short3>>();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<short4> Divider, Divider<short> value, int index)
        {
            Divider<ushort4> punned = Divider.Reinterpret<Divider<short4>, Divider<ushort4>>();
            punned.SetInnerDividerBase(value.Reinterpret<Divider<short>, Divider<ushort>>(), index, Signedness.Signed);
            Divider = punned.Reinterpret<Divider<ushort4>, Divider<short4>>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<short4> Divider, Divider<short2> value, int index)
        {
            Divider<ushort4> punned = Divider.Reinterpret<Divider<short4>, Divider<ushort4>>();
            punned.SetInnerDividerBase(value.Reinterpret<Divider<short2>, Divider<ushort2>>(), index, Signedness.Signed);
            Divider = punned.Reinterpret<Divider<ushort4>, Divider<short4>>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<short4> Divider, Divider<short3> value, int index)
        {
            Divider<ushort4> punned = Divider.Reinterpret<Divider<short4>, Divider<ushort4>>();
            punned.SetInnerDividerBase(value.Reinterpret<Divider<short3>, Divider<ushort3>>(), index, Signedness.Signed);
            Divider = punned.Reinterpret<Divider<ushort4>, Divider<short4>>();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<short8> Divider, Divider<short> value, int index)
        {
            Divider<ushort8> punned = Divider.Reinterpret<Divider<short8>, Divider<ushort8>>();
            punned.SetInnerDividerBase(value.Reinterpret<Divider<short>, Divider<ushort>>(), index, Signedness.Signed);
            Divider = punned.Reinterpret<Divider<ushort8>, Divider<short8>>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<short8> Divider, Divider<short2> value, int index)
        {
            Divider<ushort8> punned = Divider.Reinterpret<Divider<short8>, Divider<ushort8>>();
            punned.SetInnerDividerBase(value.Reinterpret<Divider<short2>, Divider<ushort2>>(), index, Signedness.Signed);
            Divider = punned.Reinterpret<Divider<ushort8>, Divider<short8>>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<short8> Divider, Divider<short3> value, int index)
        {
            Divider<ushort8> punned = Divider.Reinterpret<Divider<short8>, Divider<ushort8>>();
            punned.SetInnerDividerBase(value.Reinterpret<Divider<short3>, Divider<ushort3>>(), index, Signedness.Signed);
            Divider = punned.Reinterpret<Divider<ushort8>, Divider<short8>>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<short8> Divider, Divider<short4> value, int index)
        {
            Divider<ushort8> punned = Divider.Reinterpret<Divider<short8>, Divider<ushort8>>();
            punned.SetInnerDividerBase(value.Reinterpret<Divider<short4>, Divider<ushort4>>(), index, Signedness.Signed);
            Divider = punned.Reinterpret<Divider<ushort8>, Divider<short8>>();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<short16> Divider, Divider<short> value, int index)
        {
            Divider<ushort16> punned = Divider.Reinterpret<Divider<short16>, Divider<ushort16>>();
            punned.SetInnerDividerBase(value.Reinterpret<Divider<short>, Divider<ushort>>(), index, Signedness.Signed);
            Divider = punned.Reinterpret<Divider<ushort16>, Divider<short16>>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<short16> Divider, Divider<short2> value, int index)
        {
            Divider<ushort16> punned = Divider.Reinterpret<Divider<short16>, Divider<ushort16>>();
            punned.SetInnerDividerBase(value.Reinterpret<Divider<short2>, Divider<ushort2>>(), index, Signedness.Signed);
            Divider = punned.Reinterpret<Divider<ushort16>, Divider<short16>>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<short16> Divider, Divider<short3> value, int index)
        {
            Divider<ushort16> punned = Divider.Reinterpret<Divider<short16>, Divider<ushort16>>();
            punned.SetInnerDividerBase(value.Reinterpret<Divider<short3>, Divider<ushort3>>(), index, Signedness.Signed);
            Divider = punned.Reinterpret<Divider<ushort16>, Divider<short16>>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<short16> Divider, Divider<short4> value, int index)
        {
            Divider<ushort16> punned = Divider.Reinterpret<Divider<short16>, Divider<ushort16>>();
            punned.SetInnerDividerBase(value.Reinterpret<Divider<short4>, Divider<ushort4>>(), index, Signedness.Signed);
            Divider = punned.Reinterpret<Divider<ushort16>, Divider<short16>>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<short16> Divider, Divider<short8> value, int index)
        {
            Divider<ushort16> punned = Divider.Reinterpret<Divider<short16>, Divider<ushort16>>();
            punned.SetInnerDividerBase(value.Reinterpret<Divider<short8>, Divider<ushort8>>(), index, Signedness.Signed);
            Divider = punned.Reinterpret<Divider<ushort16>, Divider<short16>>();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<int2> Divider, Divider<int> value, int index)
        {
            Divider<uint2> punned = Divider.Reinterpret<Divider<int2>, Divider<uint2>>();
            punned.SetInnerDividerBase(value.Reinterpret<Divider<int>, Divider<uint>>(), index, Signedness.Signed);
            Divider = punned.Reinterpret<Divider<uint2>, Divider<int2>>();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<int3> Divider, Divider<int> value, int index)
        {
            Divider<uint3> punned = Divider.Reinterpret<Divider<int3>, Divider<uint3>>();
            punned.SetInnerDividerBase(value.Reinterpret<Divider<int>, Divider<uint>>(), index, Signedness.Signed);
            Divider = punned.Reinterpret<Divider<uint3>, Divider<int3>>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<int3> Divider, Divider<int2> value, int index)
        {
            Divider<uint3> punned = Divider.Reinterpret<Divider<int3>, Divider<uint3>>();
            punned.SetInnerDividerBase(value.Reinterpret<Divider<int2>, Divider<uint2>>(), index, Signedness.Signed);
            Divider = punned.Reinterpret<Divider<uint3>, Divider<int3>>();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<int4> Divider, Divider<int> value, int index)
        {
            Divider<uint4> punned = Divider.Reinterpret<Divider<int4>, Divider<uint4>>();
            punned.SetInnerDividerBase(value.Reinterpret<Divider<int>, Divider<uint>>(), index, Signedness.Signed);
            Divider = punned.Reinterpret<Divider<uint4>, Divider<int4>>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<int4> Divider, Divider<int2> value, int index)
        {
            Divider<uint4> punned = Divider.Reinterpret<Divider<int4>, Divider<uint4>>();
            punned.SetInnerDividerBase(value.Reinterpret<Divider<int2>, Divider<uint2>>(), index, Signedness.Signed);
            Divider = punned.Reinterpret<Divider<uint4>, Divider<int4>>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<int4> Divider, Divider<int3> value, int index)
        {
            Divider<uint4> punned = Divider.Reinterpret<Divider<int4>, Divider<uint4>>();
            punned.SetInnerDividerBase(value.Reinterpret<Divider<int3>, Divider<uint3>>(), index, Signedness.Signed);
            Divider = punned.Reinterpret<Divider<uint4>, Divider<int4>>();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<int8> Divider, Divider<int> value, int index)
        {
            Divider<uint8> punned = Divider.Reinterpret<Divider<int8>, Divider<uint8>>();
            punned.SetInnerDividerBase(value.Reinterpret<Divider<int>, Divider<uint>>(), index, Signedness.Signed);
            Divider = punned.Reinterpret<Divider<uint8>, Divider<int8>>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<int8> Divider, Divider<int2> value, int index)
        {
            Divider<uint8> punned = Divider.Reinterpret<Divider<int8>, Divider<uint8>>();
            punned.SetInnerDividerBase(value.Reinterpret<Divider<int2>, Divider<uint2>>(), index, Signedness.Signed);
            Divider = punned.Reinterpret<Divider<uint8>, Divider<int8>>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<int8> Divider, Divider<int3> value, int index)
        {
            Divider<uint8> punned = Divider.Reinterpret<Divider<int8>, Divider<uint8>>();
            punned.SetInnerDividerBase(value.Reinterpret<Divider<int3>, Divider<uint3>>(), index, Signedness.Signed);
            Divider = punned.Reinterpret<Divider<uint8>, Divider<int8>>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<int8> Divider, Divider<int4> value, int index)
        {
            Divider<uint8> punned = Divider.Reinterpret<Divider<int8>, Divider<uint8>>();
            punned.SetInnerDividerBase(value.Reinterpret<Divider<int4>, Divider<uint4>>(), index, Signedness.Signed);
            Divider = punned.Reinterpret<Divider<uint8>, Divider<int8>>();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<long2> Divider, Divider<long> value, int index)
        {
            Divider<ulong2> punned = Divider.Reinterpret<Divider<long2>, Divider<ulong2>>();
            punned.SetInnerDividerBase(value.Reinterpret<Divider<long>, Divider<ulong>>(), index, Signedness.Signed);
            Divider = punned.Reinterpret<Divider<ulong2>, Divider<long2>>();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<long3> Divider, Divider<long> value, int index)
        {
            Divider<ulong3> punned = Divider.Reinterpret<Divider<long3>, Divider<ulong3>>();
            punned.SetInnerDividerBase(value.Reinterpret<Divider<long>, Divider<ulong>>(), index, Signedness.Signed);
            Divider = punned.Reinterpret<Divider<ulong3>, Divider<long3>>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<long3> Divider, Divider<long2> value, int index)
        {
            Divider<ulong3> punned = Divider.Reinterpret<Divider<long3>, Divider<ulong3>>();
            punned.SetInnerDividerBase(value.Reinterpret<Divider<long2>, Divider<ulong2>>(), index, Signedness.Signed);
            Divider = punned.Reinterpret<Divider<ulong3>, Divider<long3>>();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<long4> Divider, Divider<long> value, int index)
        {
            Divider<ulong4> punned = Divider.Reinterpret<Divider<long4>, Divider<ulong4>>();
            punned.SetInnerDividerBase(value.Reinterpret<Divider<long>, Divider<ulong>>(), index, Signedness.Signed);
            Divider = punned.Reinterpret<Divider<ulong4>, Divider<long4>>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<long4> Divider, Divider<long2> value, int index)
        {
            Divider<ulong4> punned = Divider.Reinterpret<Divider<long4>, Divider<ulong4>>();
            punned.SetInnerDividerBase(value.Reinterpret<Divider<long2>, Divider<ulong2>>(), index, Signedness.Signed);
            Divider = punned.Reinterpret<Divider<ulong4>, Divider<long4>>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInnerDivider(ref this Divider<long4> Divider, Divider<long3> value, int index)
        {
            Divider<ulong4> punned = Divider.Reinterpret<Divider<long4>, Divider<ulong4>>();
            punned.SetInnerDividerBase(value.Reinterpret<Divider<long3>, Divider<ulong3>>(), index, Signedness.Signed);
            Divider = punned.Reinterpret<Divider<ulong4>, Divider<long4>>();
        }
    }
}
