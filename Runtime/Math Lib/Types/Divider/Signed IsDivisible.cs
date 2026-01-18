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
        internal static bool bmdivisible_i8(sbyte x, sbyte divisor, ushort mul, DividerPromise promises)
        {
            divisor = promise_abs_i8(divisor, promises);

            return bmdivisible_u8((byte)abs(x), mul, (byte)divisor, promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool bmdivisible_i16(short x, short divisor, uint mul, DividerPromise promises)
        {
            divisor = promise_abs_i16(divisor, promises);

            return bmdivisible_u16((ushort)abs(x), mul, (ushort)divisor, promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool bmdivisible_i32(int x, int divisor, ulong mul, DividerPromise promises)
        {
            bmcvti2u_i32(ref mul, ref divisor, promises);

            return bmdivisible_u32((uint)abs(x), mul, (uint)divisor, promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool bmdivisible_i64(long x, long divisor, UInt128 mul, DividerPromise promises)
        {
            bmcvti2u_i64(ref mul, ref divisor, promises);

            return bmdivisible_u64((ulong)abs(x), mul, (ulong)divisor, promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool bmdivisible_i128(Int128 x, Int128 divisor, __UInt256__ mul, DividerPromise promises)
        {
            bmcvti2u_i128(ref mul, ref divisor, promises);

            return bmdivisible_u128((UInt128)abs(x), mul, (UInt128)divisor, promises);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 bmdivisible_epi8(v128 a, v128 divisor, v128 mul, DividerPromise promises, byte elements = 8)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                divisor = promise_abs_epi8(divisor, promises, elements);

                return bmdivisible_epu8(Xse.abs_epi8(a, elements), divisor, mul, promises, elements);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 bmdivisible_epi8(v128 a, v128 divisor, v128 mulLo, v128 mulHi, DividerPromise promises)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                divisor = promise_abs_epi8(divisor, promises);

                return bmdivisible_epu8(Xse.abs_epi8(a), divisor, mulLo, mulHi, promises);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_bmdivisible_epi8(v256 a, v256 divisor, v256 mulLo, v256 mulHi, DividerPromise promises)
        {
            if (Avx2.IsAvx2Supported)
            {
                divisor = mm256_promise_abs_epi8(divisor, promises);

                return mm256_bmdivisible_epu8(Xse.mm256_abs_epi8(a), divisor, mulLo, mulHi, promises);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 bmdivisible_epi16(v128 a, v128 divisor, v128 mul, DividerPromise promises, byte elements = 4)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                divisor = promise_abs_epi16(divisor, promises, elements);

                return bmdivisible_epu16(Xse.abs_epi16(a, elements), divisor, mul, promises, elements);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 bmdivisible_epi16(v128 a, v128 divisor, v128 mulLo, v128 mulHi, DividerPromise promises)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                divisor = promise_abs_epi16(divisor, promises);

                return bmdivisible_epu16(Xse.abs_epi16(a), divisor, mulLo, mulHi, promises);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_bmdivisible_epi16(v256 a, v256 divisor, v256 mulLo, v256 mulHi, DividerPromise promises)
        {
            if (Avx2.IsAvx2Supported)
            {
                divisor = mm256_promise_abs_epi16(divisor, promises);

                return mm256_bmdivisible_epu16(Xse.mm256_abs_epi16(a), divisor, mulLo, mulHi, promises);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 bmnotdivisible_epi32(v128 a, v128 divisor, v128 mul, DividerPromise promises)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                bmcvti2u_epi32(ref mul, ref divisor, promises);

                return bmnotdivisible_epu32(Xse.abs_epi32(a, 2), divisor, mul, promises);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 bmnotdivisible_epi32(v128 a, v128 divisor, v128 mulLo, v128 mulHi, DividerPromise promises, byte elements = 4)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                bmcvti2u_epi32(ref mulLo, ref mulHi, ref divisor, promises, elements);

                return bmnotdivisible_epu32(Xse.abs_epi32(a), divisor, mulLo, mulHi, promises, elements);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_bmnotdivisible_epi32(v256 a, v256 divisor, v256 mulLo, v256 mulHi, DividerPromise promises)
        {
            if (Avx2.IsAvx2Supported)
            {
                mm256_bmcvti2u_epi32(ref mulLo, ref mulHi, ref divisor, promises);

                return mm256_bmnotdivisible_epu32(Xse.mm256_abs_epi32(a), divisor, mulLo, mulHi, promises);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 bmdivisible_epi64(v128 a, v128 divisor, UInt128 mulLo, UInt128 mulHi, DividerPromise promises)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (promises.Pow2)
                {
                    divisor = promise_abs_epi64(divisor, promises);
                    return bmdivisible_epu64(Xse.abs_epi64(a), divisor, mulLo, mulHi, promises);
                }

                bmcvti2u_epi64(ref mulLo, ref mulHi, ref divisor, promises);

                a = Xse.abs_epi64(a);
                long cmpLo = tobyte(Xse.extract_epi64(a, 0) * mulLo <= mulLo - 1);
                long cmpHi = tobyte(Xse.extract_epi64(a, 1) * mulHi <= mulHi - 1);

                return Xse.neg_epi64(Xse.unpacklo_epi64(Xse.cvtsi64x_si128(cmpLo), Xse.cvtsi64x_si128(cmpHi)));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_bmnotdivisible_epi64(v256 a, v256 divisor, v256 mulLo, v256 mulHi, DividerPromise promises, byte elements = 4)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (promises.Pow2)
                {
                    divisor = mm256_promise_abs_epi64(divisor, promises, elements);
                    return mm256_bmnotdivisible_epu64(Xse.mm256_abs_epi64(a, elements), divisor, mulLo, mulHi, promises, elements);
                }

                mm256_bmcvti2u_epi64(ref mulLo, ref mulHi, ref divisor, promises, elements);

                return mm256_bmnotdivisible_epu64(Xse.mm256_abs_epi64(a, elements), divisor, mulLo, mulHi, promises, elements);
            }
            else throw new IllegalInstructionException();
        }
    }


    unsafe public static partial class Extensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool EvenlyDivides(this Divider<Int128> d, Int128 x)
        {
d.AssertOperationMatchesInitialization(sizeof(Int128), 1, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            return Divider<Int128>.bmdivisible_i128(x, d.Divisor, *(__UInt256__*)&d._bigM, d._promises);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool EvenlyDivides(this Divider<sbyte> d, sbyte x)
        {
d.AssertOperationMatchesInitialization(sizeof(sbyte), 1, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            return Divider<sbyte>.bmdivisible_i8(x, d.Divisor, *(ushort*)&d._bigM, d._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 EvenlyDivides(this Divider<sbyte2> d, sbyte2 x)
        {
d.AssertOperationMatchesInitialization(sizeof(sbyte), 2, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            ushort2 mul = *(ushort2*)&d._bigM;

            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool2(RegisterConversion.IsTrue8(Divider<sbyte2>.bmdivisible_epi8(x, d.Divisor, mul, d._promises, 2)));
            }
            else
            {
                return new bool2(Divider<sbyte>.bmdivisible_i8(x[0], d.Divisor[0], mul[0], (Promise)d._promises),
                                 Divider<sbyte>.bmdivisible_i8(x[1], d.Divisor[1], mul[1], (Promise)d._promises));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 EvenlyDivides(this Divider<sbyte3> d, sbyte3 x)
        {
d.AssertOperationMatchesInitialization(sizeof(sbyte), 3, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            ushort3 mul = *(ushort3*)&d._bigM;

            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool3(RegisterConversion.IsTrue8(Divider<sbyte3>.bmdivisible_epi8(x, d.Divisor, mul, d._promises, 3)));
            }
            else
            {
                return new bool3(Divider<sbyte>.bmdivisible_i8(x[0], d.Divisor[0], mul[0], (Promise)d._promises),
                                 Divider<sbyte>.bmdivisible_i8(x[1], d.Divisor[1], mul[1], (Promise)d._promises),
                                 Divider<sbyte>.bmdivisible_i8(x[2], d.Divisor[2], mul[2], (Promise)d._promises));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 EvenlyDivides(this Divider<sbyte4> d, sbyte4 x)
        {
d.AssertOperationMatchesInitialization(sizeof(sbyte), 4, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            ushort4 mul = *(ushort4*)&d._bigM;

            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool4(RegisterConversion.IsTrue8(Divider<sbyte4>.bmdivisible_epi8(x, d.Divisor, mul, d._promises, 4)));
            }
            else
            {
                return new bool4(Divider<sbyte>.bmdivisible_i8(x[0], d.Divisor[0], mul[0], (Promise)d._promises),
                                 Divider<sbyte>.bmdivisible_i8(x[1], d.Divisor[1], mul[1], (Promise)d._promises),
                                 Divider<sbyte>.bmdivisible_i8(x[2], d.Divisor[2], mul[2], (Promise)d._promises),
                                 Divider<sbyte>.bmdivisible_i8(x[3], d.Divisor[3], mul[3], (Promise)d._promises));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 EvenlyDivides(this Divider<sbyte8> d, sbyte8 x)
        {
d.AssertOperationMatchesInitialization(sizeof(sbyte), 8, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            ushort8 mul = *(ushort8*)&d._bigM;

            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.IsTrue8(Divider<sbyte8>.bmdivisible_epi8(x, d.Divisor, mul, d._promises, 8));
            }
            else
            {
                return new bool8(Divider<sbyte>.bmdivisible_i8(x[0], d.Divisor[0], mul[0], (Promise)d._promises),
                                 Divider<sbyte>.bmdivisible_i8(x[1], d.Divisor[1], mul[1], (Promise)d._promises),
                                 Divider<sbyte>.bmdivisible_i8(x[2], d.Divisor[2], mul[2], (Promise)d._promises),
                                 Divider<sbyte>.bmdivisible_i8(x[3], d.Divisor[3], mul[3], (Promise)d._promises),
                                 Divider<sbyte>.bmdivisible_i8(x[4], d.Divisor[4], mul[4], (Promise)d._promises),
                                 Divider<sbyte>.bmdivisible_i8(x[5], d.Divisor[5], mul[5], (Promise)d._promises),
                                 Divider<sbyte>.bmdivisible_i8(x[6], d.Divisor[6], mul[6], (Promise)d._promises),
                                 Divider<sbyte>.bmdivisible_i8(x[7], d.Divisor[7], mul[7], (Promise)d._promises));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 EvenlyDivides(this Divider<sbyte16> d, sbyte16 x)
        {
d.AssertOperationMatchesInitialization(sizeof(sbyte), 16, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            ushort16 mul = *(ushort16*)&d._bigM;

            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.IsTrue8(Divider<sbyte16>.bmdivisible_epi8(x, d.Divisor, mul.v8_0, mul.v8_8, d._promises));
            }
            else
            {
                return new bool16(Divider<sbyte>.bmdivisible_i8(x[0],  d.Divisor[0],  mul[0],  (Promise)d._promises),
                                  Divider<sbyte>.bmdivisible_i8(x[1],  d.Divisor[1],  mul[1],  (Promise)d._promises),
                                  Divider<sbyte>.bmdivisible_i8(x[2],  d.Divisor[2],  mul[2],  (Promise)d._promises),
                                  Divider<sbyte>.bmdivisible_i8(x[3],  d.Divisor[3],  mul[3],  (Promise)d._promises),
                                  Divider<sbyte>.bmdivisible_i8(x[4],  d.Divisor[4],  mul[4],  (Promise)d._promises),
                                  Divider<sbyte>.bmdivisible_i8(x[5],  d.Divisor[5],  mul[5],  (Promise)d._promises),
                                  Divider<sbyte>.bmdivisible_i8(x[6],  d.Divisor[6],  mul[6],  (Promise)d._promises),
                                  Divider<sbyte>.bmdivisible_i8(x[7],  d.Divisor[7],  mul[7],  (Promise)d._promises),
                                  Divider<sbyte>.bmdivisible_i8(x[8],  d.Divisor[8],  mul[8],  (Promise)d._promises),
                                  Divider<sbyte>.bmdivisible_i8(x[9],  d.Divisor[9],  mul[9],  (Promise)d._promises),
                                  Divider<sbyte>.bmdivisible_i8(x[10], d.Divisor[10], mul[10], (Promise)d._promises),
                                  Divider<sbyte>.bmdivisible_i8(x[11], d.Divisor[11], mul[11], (Promise)d._promises),
                                  Divider<sbyte>.bmdivisible_i8(x[12], d.Divisor[12], mul[12], (Promise)d._promises),
                                  Divider<sbyte>.bmdivisible_i8(x[13], d.Divisor[13], mul[13], (Promise)d._promises),
                                  Divider<sbyte>.bmdivisible_i8(x[14], d.Divisor[14], mul[14], (Promise)d._promises),
                                  Divider<sbyte>.bmdivisible_i8(x[15], d.Divisor[15], mul[15], (Promise)d._promises));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 EvenlyDivides(this Divider<sbyte32> d, sbyte32 x)
        {
d.AssertOperationMatchesInitialization(sizeof(sbyte), 32, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.IsTrue8(Divider<sbyte32>.mm256_bmdivisible_epi8(x, d.Divisor, *(ushort16*)&d._bigM._mulLo, *(ushort16*)&d._bigM._mulHi, d._promises));
            }
            else
            {
                return new bool32(d.GetInnerDivider<sbyte16>(0).EvenlyDivides(x.v16_0),
                                  d.GetInnerDivider<sbyte16>(16).EvenlyDivides(x.v16_16));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 EvenlyDivides(this Divider<sbyte2> d, sbyte x)
        {
d.AssertOperationMatchesInitialization(sizeof(sbyte), 2, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            ushort2 mul = *(ushort2*)&d._bigM;

            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool2(RegisterConversion.IsTrue8(Divider<sbyte2>.bmdivisible_epi8((sbyte2)x, d.Divisor, mul, d._promises, 2)));
            }
            else
            {
                return new bool2(Divider<sbyte>.bmdivisible_i8(x, d.Divisor[0], mul[0], (Promise)d._promises),
                                 Divider<sbyte>.bmdivisible_i8(x, d.Divisor[1], mul[1], (Promise)d._promises));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 EvenlyDivides(this Divider<sbyte3> d, sbyte x)
        {
d.AssertOperationMatchesInitialization(sizeof(sbyte), 3, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            ushort3 mul = *(ushort3*)&d._bigM;

            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool3(RegisterConversion.IsTrue8(Divider<sbyte3>.bmdivisible_epi8((sbyte3)x, d.Divisor, mul, d._promises, 3)));
            }
            else
            {
                return new bool3(Divider<sbyte>.bmdivisible_i8(x, d.Divisor[0], mul[0], (Promise)d._promises),
                                 Divider<sbyte>.bmdivisible_i8(x, d.Divisor[1], mul[1], (Promise)d._promises),
                                 Divider<sbyte>.bmdivisible_i8(x, d.Divisor[2], mul[2], (Promise)d._promises));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 EvenlyDivides(this Divider<sbyte4> d, sbyte x)
        {
d.AssertOperationMatchesInitialization(sizeof(sbyte), 4, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            ushort4 mul = *(ushort4*)&d._bigM;

            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool4(RegisterConversion.IsTrue8(Divider<sbyte4>.bmdivisible_epi8((sbyte4)x, d.Divisor, mul, d._promises, 4)));
            }
            else
            {
                return new bool4(Divider<sbyte>.bmdivisible_i8(x, d.Divisor[0], mul[0], (Promise)d._promises),
                                 Divider<sbyte>.bmdivisible_i8(x, d.Divisor[1], mul[1], (Promise)d._promises),
                                 Divider<sbyte>.bmdivisible_i8(x, d.Divisor[2], mul[2], (Promise)d._promises),
                                 Divider<sbyte>.bmdivisible_i8(x, d.Divisor[3], mul[3], (Promise)d._promises));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 EvenlyDivides(this Divider<sbyte8> d, sbyte x)
        {
d.AssertOperationMatchesInitialization(sizeof(sbyte), 8, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            ushort8 mul = *(ushort8*)&d._bigM;

            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.IsTrue8(Divider<sbyte8>.bmdivisible_epi8((sbyte8)x, d.Divisor, mul, d._promises, 8));
            }
            else
            {
                return new bool8(Divider<sbyte>.bmdivisible_i8(x, d.Divisor[0], mul[0], (Promise)d._promises),
                                 Divider<sbyte>.bmdivisible_i8(x, d.Divisor[1], mul[1], (Promise)d._promises),
                                 Divider<sbyte>.bmdivisible_i8(x, d.Divisor[2], mul[2], (Promise)d._promises),
                                 Divider<sbyte>.bmdivisible_i8(x, d.Divisor[3], mul[3], (Promise)d._promises),
                                 Divider<sbyte>.bmdivisible_i8(x, d.Divisor[4], mul[4], (Promise)d._promises),
                                 Divider<sbyte>.bmdivisible_i8(x, d.Divisor[5], mul[5], (Promise)d._promises),
                                 Divider<sbyte>.bmdivisible_i8(x, d.Divisor[6], mul[6], (Promise)d._promises),
                                 Divider<sbyte>.bmdivisible_i8(x, d.Divisor[7], mul[7], (Promise)d._promises));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 EvenlyDivides(this Divider<sbyte16> d, sbyte x)
        {
d.AssertOperationMatchesInitialization(sizeof(sbyte), 16, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            ushort16 mul = *(ushort16*)&d._bigM;

            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.IsTrue8(Divider<sbyte16>.bmdivisible_epi8((sbyte16)x, d.Divisor, mul.v8_0, mul.v8_8, d._promises));
            }
            else
            {
                return new bool16(Divider<sbyte>.bmdivisible_i8(x, d.Divisor[0],  mul[0],  (Promise)d._promises),
                                  Divider<sbyte>.bmdivisible_i8(x, d.Divisor[1],  mul[1],  (Promise)d._promises),
                                  Divider<sbyte>.bmdivisible_i8(x, d.Divisor[2],  mul[2],  (Promise)d._promises),
                                  Divider<sbyte>.bmdivisible_i8(x, d.Divisor[3],  mul[3],  (Promise)d._promises),
                                  Divider<sbyte>.bmdivisible_i8(x, d.Divisor[4],  mul[4],  (Promise)d._promises),
                                  Divider<sbyte>.bmdivisible_i8(x, d.Divisor[5],  mul[5],  (Promise)d._promises),
                                  Divider<sbyte>.bmdivisible_i8(x, d.Divisor[6],  mul[6],  (Promise)d._promises),
                                  Divider<sbyte>.bmdivisible_i8(x, d.Divisor[7],  mul[7],  (Promise)d._promises),
                                  Divider<sbyte>.bmdivisible_i8(x, d.Divisor[8],  mul[8],  (Promise)d._promises),
                                  Divider<sbyte>.bmdivisible_i8(x, d.Divisor[9],  mul[9],  (Promise)d._promises),
                                  Divider<sbyte>.bmdivisible_i8(x, d.Divisor[10], mul[10], (Promise)d._promises),
                                  Divider<sbyte>.bmdivisible_i8(x, d.Divisor[11], mul[11], (Promise)d._promises),
                                  Divider<sbyte>.bmdivisible_i8(x, d.Divisor[12], mul[12], (Promise)d._promises),
                                  Divider<sbyte>.bmdivisible_i8(x, d.Divisor[13], mul[13], (Promise)d._promises),
                                  Divider<sbyte>.bmdivisible_i8(x, d.Divisor[14], mul[14], (Promise)d._promises),
                                  Divider<sbyte>.bmdivisible_i8(x, d.Divisor[15], mul[15], (Promise)d._promises));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 EvenlyDivides(this Divider<sbyte32> d, sbyte x)
        {
d.AssertOperationMatchesInitialization(sizeof(sbyte), 32, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.IsTrue8(Divider<sbyte32>.mm256_bmdivisible_epi8((sbyte32)x, d.Divisor, *(ushort16*)&d._bigM._mulLo, *(ushort16*)&d._bigM._mulHi, d._promises));
            }
            else
            {
                return new bool32(d.GetInnerDivider<sbyte16>(0).EvenlyDivides(x),
                                  d.GetInnerDivider<sbyte16>(16).EvenlyDivides(x));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 EvenlyDivides(this Divider<sbyte> d, sbyte2 x)
        {
d.AssertOperationMatchesInitialization(sizeof(sbyte), 2, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            ushort mul = *(ushort*)&d._bigM;

            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool2(RegisterConversion.IsTrue8(Divider<sbyte2>.bmdivisible_epi8(x, (sbyte2)d.Divisor, (ushort2)mul, d._promises.Reinterpret<Divider<sbyte>.DividerPromise, Divider<sbyte2>.DividerPromise>(), 2)));
            }
            else
            {
                return new bool2(Divider<sbyte>.bmdivisible_i8(x[0], d.Divisor, mul, d._promises),
                                 Divider<sbyte>.bmdivisible_i8(x[1], d.Divisor, mul, d._promises));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 EvenlyDivides(this Divider<sbyte> d, sbyte3 x)
        {
d.AssertOperationMatchesInitialization(sizeof(sbyte), 3, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            ushort mul = *(ushort*)&d._bigM;

            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool3(RegisterConversion.IsTrue8(Divider<sbyte3>.bmdivisible_epi8(x, (sbyte3)d.Divisor, (ushort3)mul, d._promises.Reinterpret<Divider<sbyte>.DividerPromise, Divider<sbyte3>.DividerPromise>(), 3)));
            }
            else
            {
                return new bool3(Divider<sbyte>.bmdivisible_i8(x[0], d.Divisor, mul, d._promises),
                                 Divider<sbyte>.bmdivisible_i8(x[1], d.Divisor, mul, d._promises),
                                 Divider<sbyte>.bmdivisible_i8(x[2], d.Divisor, mul, d._promises));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 EvenlyDivides(this Divider<sbyte> d, sbyte4 x)
        {
d.AssertOperationMatchesInitialization(sizeof(sbyte), 4, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            ushort mul = *(ushort*)&d._bigM;

            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool4(RegisterConversion.IsTrue8(Divider<sbyte4>.bmdivisible_epi8(x, (sbyte4)d.Divisor, (ushort4)mul, d._promises.Reinterpret<Divider<sbyte>.DividerPromise, Divider<sbyte4>.DividerPromise>(), 4)));
            }
            else
            {
                return new bool4(Divider<sbyte>.bmdivisible_i8(x[0], d.Divisor, mul, d._promises),
                                 Divider<sbyte>.bmdivisible_i8(x[1], d.Divisor, mul, d._promises),
                                 Divider<sbyte>.bmdivisible_i8(x[2], d.Divisor, mul, d._promises),
                                 Divider<sbyte>.bmdivisible_i8(x[3], d.Divisor, mul, d._promises));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 EvenlyDivides(this Divider<sbyte> d, sbyte8 x)
        {
d.AssertOperationMatchesInitialization(sizeof(sbyte), 8, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            ushort mul = *(ushort*)&d._bigM;

            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.IsTrue8(Divider<sbyte8>.bmdivisible_epi8(x, (sbyte8)d.Divisor, (ushort8)mul, d._promises.Reinterpret<Divider<sbyte>.DividerPromise, Divider<sbyte8>.DividerPromise>(), 8));
            }
            else
            {
                return new bool8(Divider<sbyte>.bmdivisible_i8(x[0], d.Divisor, mul, d._promises),
                                 Divider<sbyte>.bmdivisible_i8(x[1], d.Divisor, mul, d._promises),
                                 Divider<sbyte>.bmdivisible_i8(x[2], d.Divisor, mul, d._promises),
                                 Divider<sbyte>.bmdivisible_i8(x[3], d.Divisor, mul, d._promises),
                                 Divider<sbyte>.bmdivisible_i8(x[4], d.Divisor, mul, d._promises),
                                 Divider<sbyte>.bmdivisible_i8(x[5], d.Divisor, mul, d._promises),
                                 Divider<sbyte>.bmdivisible_i8(x[6], d.Divisor, mul, d._promises),
                                 Divider<sbyte>.bmdivisible_i8(x[7], d.Divisor, mul, d._promises));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 EvenlyDivides(this Divider<sbyte> d, sbyte16 x)
        {
d.AssertOperationMatchesInitialization(sizeof(sbyte), 16, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            ushort mul = *(ushort*)&d._bigM;

            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.IsTrue8(Divider<sbyte16>.bmdivisible_epi8(x, (sbyte16)d.Divisor, (ushort8)mul, (ushort8)mul, d._promises.Reinterpret<Divider<sbyte>.DividerPromise, Divider<sbyte16>.DividerPromise>()));
            }
            else
            {
                return new bool16(Divider<sbyte>.bmdivisible_i8(x[0],  d.Divisor, mul, d._promises),
                                  Divider<sbyte>.bmdivisible_i8(x[1],  d.Divisor, mul, d._promises),
                                  Divider<sbyte>.bmdivisible_i8(x[2],  d.Divisor, mul, d._promises),
                                  Divider<sbyte>.bmdivisible_i8(x[3],  d.Divisor, mul, d._promises),
                                  Divider<sbyte>.bmdivisible_i8(x[4],  d.Divisor, mul, d._promises),
                                  Divider<sbyte>.bmdivisible_i8(x[5],  d.Divisor, mul, d._promises),
                                  Divider<sbyte>.bmdivisible_i8(x[6],  d.Divisor, mul, d._promises),
                                  Divider<sbyte>.bmdivisible_i8(x[7],  d.Divisor, mul, d._promises),
                                  Divider<sbyte>.bmdivisible_i8(x[8],  d.Divisor, mul, d._promises),
                                  Divider<sbyte>.bmdivisible_i8(x[9],  d.Divisor, mul, d._promises),
                                  Divider<sbyte>.bmdivisible_i8(x[10], d.Divisor, mul, d._promises),
                                  Divider<sbyte>.bmdivisible_i8(x[11], d.Divisor, mul, d._promises),
                                  Divider<sbyte>.bmdivisible_i8(x[12], d.Divisor, mul, d._promises),
                                  Divider<sbyte>.bmdivisible_i8(x[13], d.Divisor, mul, d._promises),
                                  Divider<sbyte>.bmdivisible_i8(x[14], d.Divisor, mul, d._promises),
                                  Divider<sbyte>.bmdivisible_i8(x[15], d.Divisor, mul, d._promises));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 EvenlyDivides(this Divider<sbyte> d, sbyte32 x)
        {
d.AssertOperationMatchesInitialization(sizeof(sbyte), 32, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            if (Avx2.IsAvx2Supported)
            {
                ushort mul = *(ushort*)&d._bigM;

                return RegisterConversion.IsTrue8(Divider<sbyte32>.mm256_bmdivisible_epi8(x, (sbyte32)d.Divisor, (ushort16)mul, (ushort16)mul, d._promises.Reinterpret<Divider<sbyte>.DividerPromise, Divider<sbyte32>.DividerPromise>()));
            }
            else
            {
                return new bool32(d.EvenlyDivides(x.v16_0),
                                  d.EvenlyDivides(x.v16_16));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool EvenlyDivides(this Divider<short> d, short x)
        {
d.AssertOperationMatchesInitialization(sizeof(short), 1, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            return Divider<short>.bmdivisible_i16(x, d.Divisor, *(uint*)&d._bigM, d._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 EvenlyDivides(this Divider<short2> d, short2 x)
        {
d.AssertOperationMatchesInitialization(sizeof(short), 2, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            uint2 mul = *(uint2*)&d._bigM;

            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool2(RegisterConversion.IsTrue16(Divider<short2>.bmdivisible_epi16(x, d.Divisor, RegisterConversion.ToV128(mul), d._promises, 2)));
            }
            else
            {
                return new bool2(Divider<short>.bmdivisible_i16(x[0], d.Divisor[0], mul[0], (Promise)d._promises),
                                 Divider<short>.bmdivisible_i16(x[1], d.Divisor[1], mul[1], (Promise)d._promises));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 EvenlyDivides(this Divider<short3> d, short3 x)
        {
d.AssertOperationMatchesInitialization(sizeof(short), 3, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            uint3 mul = *(uint3*)&d._bigM;

            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool3(RegisterConversion.IsTrue16(Divider<short3>.bmdivisible_epi16(x, d.Divisor, RegisterConversion.ToV128(mul), d._promises, 3)));
            }
            else
            {
                return new bool3(Divider<short>.bmdivisible_i16(x[0], d.Divisor[0], mul[0], (Promise)d._promises),
                                 Divider<short>.bmdivisible_i16(x[1], d.Divisor[1], mul[1], (Promise)d._promises),
                                 Divider<short>.bmdivisible_i16(x[2], d.Divisor[2], mul[2], (Promise)d._promises));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 EvenlyDivides(this Divider<short4> d, short4 x)
        {
d.AssertOperationMatchesInitialization(sizeof(short), 4, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            uint4 mul = *(uint4*)&d._bigM;

            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool4(RegisterConversion.IsTrue16(Divider<short4>.bmdivisible_epi16(x, d.Divisor, RegisterConversion.ToV128(mul), d._promises, 4)));
            }
            else
            {
                return new bool4(Divider<short>.bmdivisible_i16(x[0], d.Divisor[0], mul[0], (Promise)d._promises),
                                 Divider<short>.bmdivisible_i16(x[1], d.Divisor[1], mul[1], (Promise)d._promises),
                                 Divider<short>.bmdivisible_i16(x[2], d.Divisor[2], mul[2], (Promise)d._promises),
                                 Divider<short>.bmdivisible_i16(x[3], d.Divisor[3], mul[3], (Promise)d._promises));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 EvenlyDivides(this Divider<short8> d, short8 x)
        {
d.AssertOperationMatchesInitialization(sizeof(short), 8, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            uint8 mul = *(uint8*)&d._bigM;

            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.IsTrue16(Divider<short8>.bmdivisible_epi16(x, d.Divisor, RegisterConversion.ToV128(mul.v4_0), RegisterConversion.ToV128(mul.v4_4), d._promises));
            }
            else
            {
                return new bool8(Divider<short>.bmdivisible_i16(x[0], d.Divisor[0], mul[0], (Promise)d._promises),
                                 Divider<short>.bmdivisible_i16(x[1], d.Divisor[1], mul[1], (Promise)d._promises),
                                 Divider<short>.bmdivisible_i16(x[2], d.Divisor[2], mul[2], (Promise)d._promises),
                                 Divider<short>.bmdivisible_i16(x[3], d.Divisor[3], mul[3], (Promise)d._promises),
                                 Divider<short>.bmdivisible_i16(x[4], d.Divisor[4], mul[4], (Promise)d._promises),
                                 Divider<short>.bmdivisible_i16(x[5], d.Divisor[5], mul[5], (Promise)d._promises),
                                 Divider<short>.bmdivisible_i16(x[6], d.Divisor[6], mul[6], (Promise)d._promises),
                                 Divider<short>.bmdivisible_i16(x[7], d.Divisor[7], mul[7], (Promise)d._promises));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 EvenlyDivides(this Divider<short16> d, short16 x)
        {
d.AssertOperationMatchesInitialization(sizeof(short), 16, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.IsTrue16(Divider<short16>.mm256_bmdivisible_epi16(x, d.Divisor, *(uint8*)&d._bigM._mulLo, *(uint8*)&d._bigM._mulHi, d._promises));
            }
            else
            {
                return new bool16(d.GetInnerDivider<short8>(0).EvenlyDivides(x.v8_0),
                                  d.GetInnerDivider<short8>(8).EvenlyDivides(x.v8_8));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 EvenlyDivides(this Divider<short2> d, short x)
        {
d.AssertOperationMatchesInitialization(sizeof(short), 2, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            uint2 mul = *(uint2*)&d._bigM;

            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool2(RegisterConversion.IsTrue16(Divider<short2>.bmdivisible_epi16((short2)x, d.Divisor, RegisterConversion.ToV128(mul), d._promises, 2)));
            }
            else
            {
                return new bool2(Divider<short>.bmdivisible_i16(x, d.Divisor[0], mul[0], (Promise)d._promises),
                                 Divider<short>.bmdivisible_i16(x, d.Divisor[1], mul[1], (Promise)d._promises));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 EvenlyDivides(this Divider<short3> d, short x)
        {
d.AssertOperationMatchesInitialization(sizeof(short), 3, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            uint3 mul = *(uint3*)&d._bigM;

            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool3(RegisterConversion.IsTrue16(Divider<short3>.bmdivisible_epi16((short3)x, d.Divisor, RegisterConversion.ToV128(mul), d._promises, 3)));
            }
            else
            {
                return new bool3(Divider<short>.bmdivisible_i16(x, d.Divisor[0], mul[0], (Promise)d._promises),
                                 Divider<short>.bmdivisible_i16(x, d.Divisor[1], mul[1], (Promise)d._promises),
                                 Divider<short>.bmdivisible_i16(x, d.Divisor[2], mul[2], (Promise)d._promises));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 EvenlyDivides(this Divider<short4> d, short x)
        {
d.AssertOperationMatchesInitialization(sizeof(short), 4, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            uint4 mul = *(uint4*)&d._bigM;

            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool4(RegisterConversion.IsTrue16(Divider<short4>.bmdivisible_epi16((short4)x, d.Divisor, RegisterConversion.ToV128(mul), d._promises, 4)));
            }
            else
            {
                return new bool4(Divider<short>.bmdivisible_i16(x, d.Divisor[0], mul[0], (Promise)d._promises),
                                 Divider<short>.bmdivisible_i16(x, d.Divisor[1], mul[1], (Promise)d._promises),
                                 Divider<short>.bmdivisible_i16(x, d.Divisor[2], mul[2], (Promise)d._promises),
                                 Divider<short>.bmdivisible_i16(x, d.Divisor[3], mul[3], (Promise)d._promises));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 EvenlyDivides(this Divider<short8> d, short x)
        {
d.AssertOperationMatchesInitialization(sizeof(short), 8, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            uint8 mul = *(uint8*)&d._bigM;

            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.IsTrue16(Divider<short8>.bmdivisible_epi16((short8)x, d.Divisor, RegisterConversion.ToV128(mul.v4_0), RegisterConversion.ToV128(mul.v4_4), d._promises));
            }
            else
            {
                return new bool8(Divider<short>.bmdivisible_i16(x, d.Divisor[0], mul[0], (Promise)d._promises),
                                 Divider<short>.bmdivisible_i16(x, d.Divisor[1], mul[1], (Promise)d._promises),
                                 Divider<short>.bmdivisible_i16(x, d.Divisor[2], mul[2], (Promise)d._promises),
                                 Divider<short>.bmdivisible_i16(x, d.Divisor[3], mul[3], (Promise)d._promises),
                                 Divider<short>.bmdivisible_i16(x, d.Divisor[4], mul[4], (Promise)d._promises),
                                 Divider<short>.bmdivisible_i16(x, d.Divisor[5], mul[5], (Promise)d._promises),
                                 Divider<short>.bmdivisible_i16(x, d.Divisor[6], mul[6], (Promise)d._promises),
                                 Divider<short>.bmdivisible_i16(x, d.Divisor[7], mul[7], (Promise)d._promises));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 EvenlyDivides(this Divider<short16> d, short x)
        {
d.AssertOperationMatchesInitialization(sizeof(short), 16, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.IsTrue16(Divider<short16>.mm256_bmdivisible_epi16((short16)x, d.Divisor, *(uint8*)&d._bigM._mulLo, *(uint8*)&d._bigM._mulHi, d._promises));
            }
            else
            {
                return new bool16(d.GetInnerDivider<short8>(0).EvenlyDivides(x),
                                  d.GetInnerDivider<short8>(8).EvenlyDivides(x));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 EvenlyDivides(this Divider<short> d, short2 x)
        {
d.AssertOperationMatchesInitialization(sizeof(short), 2, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            uint mul = *(uint*)&d._bigM;

            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool2(RegisterConversion.IsTrue16(Divider<short2>.bmdivisible_epi16(x, (short2)d.Divisor, RegisterConversion.ToV128((uint2)mul), d._promises.Reinterpret<Divider<short>.DividerPromise, Divider<short2>.DividerPromise>(), 2)));
            }
            else
            {
                return new bool2(Divider<short>.bmdivisible_i16(x[0], d.Divisor, mul, d._promises),
                                 Divider<short>.bmdivisible_i16(x[1], d.Divisor, mul, d._promises));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 EvenlyDivides(this Divider<short> d, short3 x)
        {
d.AssertOperationMatchesInitialization(sizeof(short), 3, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            uint mul = *(uint*)&d._bigM;

            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool3(RegisterConversion.IsTrue16(Divider<short3>.bmdivisible_epi16(x, (short3)d.Divisor, RegisterConversion.ToV128((uint3)mul), d._promises.Reinterpret<Divider<short>.DividerPromise, Divider<short3>.DividerPromise>(), 3)));
            }
            else
            {
                return new bool3(Divider<short>.bmdivisible_i16(x[0], d.Divisor, mul, d._promises),
                                 Divider<short>.bmdivisible_i16(x[1], d.Divisor, mul, d._promises),
                                 Divider<short>.bmdivisible_i16(x[2], d.Divisor, mul, d._promises));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 EvenlyDivides(this Divider<short> d, short4 x)
        {
d.AssertOperationMatchesInitialization(sizeof(short), 4, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            uint mul = *(uint*)&d._bigM;

            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool4(RegisterConversion.IsTrue16(Divider<short4>.bmdivisible_epi16(x, (short4)d.Divisor, RegisterConversion.ToV128((uint4)mul), d._promises.Reinterpret<Divider<short>.DividerPromise, Divider<short4>.DividerPromise>(), 4)));
            }
            else
            {
                return new bool4(Divider<short>.bmdivisible_i16(x[0], d.Divisor, mul, d._promises),
                                 Divider<short>.bmdivisible_i16(x[1], d.Divisor, mul, d._promises),
                                 Divider<short>.bmdivisible_i16(x[2], d.Divisor, mul, d._promises),
                                 Divider<short>.bmdivisible_i16(x[3], d.Divisor, mul, d._promises));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 EvenlyDivides(this Divider<short> d, short8 x)
        {
d.AssertOperationMatchesInitialization(sizeof(short), 8, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            uint mul = *(uint*)&d._bigM;

            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.IsTrue16(Divider<short8>.bmdivisible_epi16(x, (short8)d.Divisor, RegisterConversion.ToV128((uint4)mul), RegisterConversion.ToV128((uint4)mul), d._promises.Reinterpret<Divider<short>.DividerPromise, Divider<short8>.DividerPromise>()));
            }
            else
            {
                return new bool8(Divider<short>.bmdivisible_i16(x[0], d.Divisor, mul, d._promises),
                                 Divider<short>.bmdivisible_i16(x[1], d.Divisor, mul, d._promises),
                                 Divider<short>.bmdivisible_i16(x[2], d.Divisor, mul, d._promises),
                                 Divider<short>.bmdivisible_i16(x[3], d.Divisor, mul, d._promises),
                                 Divider<short>.bmdivisible_i16(x[4], d.Divisor, mul, d._promises),
                                 Divider<short>.bmdivisible_i16(x[5], d.Divisor, mul, d._promises),
                                 Divider<short>.bmdivisible_i16(x[6], d.Divisor, mul, d._promises),
                                 Divider<short>.bmdivisible_i16(x[7], d.Divisor, mul, d._promises));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 EvenlyDivides(this Divider<short> d, short16 x)
        {
d.AssertOperationMatchesInitialization(sizeof(short), 16, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            if (Avx2.IsAvx2Supported)
            {
                uint mul = *(uint*)&d._bigM;

                return RegisterConversion.IsTrue16(Divider<short16>.mm256_bmdivisible_epi16(x, (short16)d.Divisor, (uint8)mul, (uint8)mul, d._promises.Reinterpret<Divider<short>.DividerPromise, Divider<short16>.DividerPromise>()));
            }
            else
            {
                return new bool16(d.EvenlyDivides(x.v8_0),
                                  d.EvenlyDivides(x.v8_8));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool EvenlyDivides(this Divider<int> d, int x)
        {
d.AssertOperationMatchesInitialization(sizeof(int), 1, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            return Divider<int>.bmdivisible_i32(x, d.Divisor, *(ulong*)&d._bigM, d._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 EvenlyDivides(this Divider<int2> d, int2 x)
        {
d.AssertOperationMatchesInitialization(sizeof(int), 2, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            ulong2 mul = *(ulong2*)&d._bigM;

            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool2(RegisterConversion.IsFalse32(Divider<int2>.bmnotdivisible_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(d.Divisor), mul, d._promises)));
            }
            else
            {
                return new bool2(Divider<int>.bmdivisible_i32(x[0], d.Divisor[0], mul[0], (Promise)d._promises),
                                 Divider<int>.bmdivisible_i32(x[1], d.Divisor[1], mul[1], (Promise)d._promises));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 EvenlyDivides(this Divider<int3> d, int3 x)
        {
d.AssertOperationMatchesInitialization(sizeof(int), 3, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            ulong3 mul = *(ulong3*)&d._bigM;

            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool3(RegisterConversion.IsFalse32(Divider<int3>.bmnotdivisible_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(d.Divisor), mul.xy, mul.zz, d._promises, 3)));
            }
            else
            {
                return new bool3(Divider<int>.bmdivisible_i32(x[0], d.Divisor[0], mul[0], (Promise)d._promises),
                                 Divider<int>.bmdivisible_i32(x[1], d.Divisor[1], mul[1], (Promise)d._promises),
                                 Divider<int>.bmdivisible_i32(x[2], d.Divisor[2], mul[2], (Promise)d._promises));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 EvenlyDivides(this Divider<int4> d, int4 x)
        {
d.AssertOperationMatchesInitialization(sizeof(int), 4, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            ulong4 mul = *(ulong4*)&d._bigM;

            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool4(RegisterConversion.IsFalse32(Divider<int4>.bmnotdivisible_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(d.Divisor), mul.xy, mul.zw, d._promises)));
            }
            else
            {
                return new bool4(Divider<int>.bmdivisible_i32(x[0], d.Divisor[0], mul[0], (Promise)d._promises),
                                 Divider<int>.bmdivisible_i32(x[1], d.Divisor[1], mul[1], (Promise)d._promises),
                                 Divider<int>.bmdivisible_i32(x[2], d.Divisor[2], mul[2], (Promise)d._promises),
                                 Divider<int>.bmdivisible_i32(x[3], d.Divisor[3], mul[3], (Promise)d._promises));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 EvenlyDivides(this Divider<int8> d, int8 x)
        {
d.AssertOperationMatchesInitialization(sizeof(int), 8, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.IsFalse32(Divider<int8>.mm256_bmnotdivisible_epi32(x, d.Divisor, *(long4*)&d._bigM._mulLo, *(long4*)&d._bigM._mulHi, d._promises));
            }
            else
            {
                return new bool8(d.GetInnerDivider<int4>(0).EvenlyDivides(x.v4_0),
                                 d.GetInnerDivider<int4>(4).EvenlyDivides(x.v4_4));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 EvenlyDivides(this Divider<int2> d, int x)
        {
d.AssertOperationMatchesInitialization(sizeof(int), 2, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            ulong2 mul = *(ulong2*)&d._bigM;

            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool2(RegisterConversion.IsFalse32(Divider<int2>.bmnotdivisible_epi32(RegisterConversion.ToV128((int2)x), RegisterConversion.ToV128(d.Divisor), mul, d._promises)));
            }
            else
            {
                return new bool2(Divider<int>.bmdivisible_i32(x, d.Divisor[0], mul[0], (Promise)d._promises),
                                 Divider<int>.bmdivisible_i32(x, d.Divisor[1], mul[1], (Promise)d._promises));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 EvenlyDivides(this Divider<int3> d, int x)
        {
d.AssertOperationMatchesInitialization(sizeof(int), 3, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            ulong3 mul = *(ulong3*)&d._bigM;

            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool3(RegisterConversion.IsFalse32(Divider<int3>.bmnotdivisible_epi32(RegisterConversion.ToV128((int3)x), RegisterConversion.ToV128(d.Divisor), mul.xy, mul.zz, d._promises, 3)));
            }
            else
            {
                return new bool3(Divider<int>.bmdivisible_i32(x, d.Divisor[0], mul[0], (Promise)d._promises),
                                 Divider<int>.bmdivisible_i32(x, d.Divisor[1], mul[1], (Promise)d._promises),
                                 Divider<int>.bmdivisible_i32(x, d.Divisor[2], mul[2], (Promise)d._promises));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 EvenlyDivides(this Divider<int4> d, int x)
        {
d.AssertOperationMatchesInitialization(sizeof(int), 4, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            ulong4 mul = *(ulong4*)&d._bigM;

            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool4(RegisterConversion.IsFalse32(Divider<int4>.bmnotdivisible_epi32(RegisterConversion.ToV128((int4)x), RegisterConversion.ToV128(d.Divisor), mul.xy, mul.zw, d._promises)));
            }
            else
            {
                return new bool4(Divider<int>.bmdivisible_i32(x, d.Divisor[0], mul[0], (Promise)d._promises),
                                 Divider<int>.bmdivisible_i32(x, d.Divisor[1], mul[1], (Promise)d._promises),
                                 Divider<int>.bmdivisible_i32(x, d.Divisor[2], mul[2], (Promise)d._promises),
                                 Divider<int>.bmdivisible_i32(x, d.Divisor[3], mul[3], (Promise)d._promises));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 EvenlyDivides(this Divider<int8> d, int x)
        {
d.AssertOperationMatchesInitialization(sizeof(int), 8, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.IsFalse32(Divider<int8>.mm256_bmnotdivisible_epi32((int8)x, d.Divisor, *(long4*)&d._bigM._mulLo, *(long4*)&d._bigM._mulHi, d._promises));
            }
            else
            {
                return new bool8(d.GetInnerDivider<int4>(0).EvenlyDivides(x),
                                 d.GetInnerDivider<int4>(4).EvenlyDivides(x));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 EvenlyDivides(this Divider<int> d, int2 x)
        {
d.AssertOperationMatchesInitialization(sizeof(int), 2, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            ulong mul = *(ulong*)&d._bigM;

            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool2(RegisterConversion.IsFalse32(Divider<int2>.bmnotdivisible_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128((int2)d.Divisor), (ulong2)mul, d._promises.Reinterpret<Divider<int>.DividerPromise, Divider<int2>.DividerPromise>())));
            }
            else
            {
                return new bool2(Divider<int>.bmdivisible_i32(x[0], d.Divisor, mul, d._promises),
                                 Divider<int>.bmdivisible_i32(x[1], d.Divisor, mul, d._promises));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 EvenlyDivides(this Divider<int> d, int3 x)
        {
d.AssertOperationMatchesInitialization(sizeof(int), 3, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            ulong mul = *(ulong*)&d._bigM;

            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool3(RegisterConversion.IsFalse32(Divider<int3>.bmnotdivisible_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128((int3)d.Divisor), (ulong2)mul, (ulong2)mul, d._promises.Reinterpret<Divider<int>.DividerPromise, Divider<int3>.DividerPromise>(), 3)));
            }
            else
            {
                return new bool3(Divider<int>.bmdivisible_i32(x[0], d.Divisor, mul, d._promises),
                                 Divider<int>.bmdivisible_i32(x[1], d.Divisor, mul, d._promises),
                                 Divider<int>.bmdivisible_i32(x[2], d.Divisor, mul, d._promises));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 EvenlyDivides(this Divider<int> d, int4 x)
        {
d.AssertOperationMatchesInitialization(sizeof(int), 4, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            ulong mul = *(ulong*)&d._bigM;

            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool4(RegisterConversion.IsFalse32(Divider<int4>.bmnotdivisible_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128((int4)d.Divisor), (ulong2)mul, (ulong2)mul, d._promises.Reinterpret<Divider<int>.DividerPromise, Divider<int4>.DividerPromise>())));
            }
            else
            {
                return new bool4(Divider<int>.bmdivisible_i32(x[0], d.Divisor, mul, d._promises),
                                 Divider<int>.bmdivisible_i32(x[1], d.Divisor, mul, d._promises),
                                 Divider<int>.bmdivisible_i32(x[2], d.Divisor, mul, d._promises),
                                 Divider<int>.bmdivisible_i32(x[3], d.Divisor, mul, d._promises));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 EvenlyDivides(this Divider<int> d, int8 x)
        {
d.AssertOperationMatchesInitialization(sizeof(int), 8, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            if (Avx2.IsAvx2Supported)
            {
                ulong mul = *(ulong*)&d._bigM;

                return RegisterConversion.IsFalse32(Divider<int8>.mm256_bmnotdivisible_epi32(x, (int8)d.Divisor, (ulong4)mul, (ulong4)mul, d._promises.Reinterpret<Divider<int>.DividerPromise, Divider<int8>.DividerPromise>()));
            }
            else
            {
                return new bool8(d.EvenlyDivides(x.v4_0),
                                 d.EvenlyDivides(x.v4_4));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool EvenlyDivides(this Divider<long> d, long x)
        {
d.AssertOperationMatchesInitialization(sizeof(long), 1, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            return Divider<long>.bmdivisible_i64(x, d.Divisor, *(UInt128*)&d._bigM, d._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 EvenlyDivides(this Divider<long2> d, long2 x)
        {
d.AssertOperationMatchesInitialization(sizeof(long), 2, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            UInt128* mul = (UInt128*)&d._bigM;

            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool2(RegisterConversion.IsTrue64(Divider<long2>.bmdivisible_epi64(x, d.Divisor, mul[0], mul[1], d._promises)));
            }
            else
            {
                return new bool2(Divider<long>.bmdivisible_i64(x[0], d.Divisor[0], mul[0], (Promise)d._promises),
                                 Divider<long>.bmdivisible_i64(x[1], d.Divisor[1], mul[1], (Promise)d._promises));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 EvenlyDivides(this Divider<long3> d, long3 x)
        {
d.AssertOperationMatchesInitialization(sizeof(long), 3, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            UInt128* mul = (UInt128*)&d._bigM;

            if (d._promises.Pow2)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return RegisterConversion.ToBool3(RegisterConversion.IsFalse64(Divider<long3>.mm256_bmnotdivisible_epi64(x, d.Divisor, default(v256), default(v256), (Promise)d._promises, 3)));
                }
            }

            if (BurstArchitecture.IsSIMDSupported)
            {
                return new bool3(RegisterConversion.ToBool2(RegisterConversion.IsTrue64(Divider<ulong2>.bmdivisible_epi64(x.xy, d.Divisor.xy, mul[0], mul[1], (Promise)d._promises))),
                                 Divider<ulong>.bmdivisible_i64(x[2], d._divisor[2], mul[2], (Promise)d._promises));
            }
            else
            {
                return new bool3(Divider<long>.bmdivisible_i64(x[0], d.Divisor[0], mul[0], (Promise)d._promises),
                                 Divider<long>.bmdivisible_i64(x[1], d.Divisor[1], mul[1], (Promise)d._promises),
                                 Divider<long>.bmdivisible_i64(x[2], d.Divisor[2], mul[2], (Promise)d._promises));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 EvenlyDivides(this Divider<long4> d, long4 x)
        {
d.AssertOperationMatchesInitialization(sizeof(long), 4, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            UInt128* mul = (UInt128*)&d._bigM;

            if (Avx2.IsAvx2Supported)
            {
                long4 mulLo = Avx2.mm256_i64gather_epi64(mul, new long4(0, 2, 4, 6), sizeof(long));
                long4 mulHi = Avx2.mm256_i64gather_epi64(mul, new long4(1, 3, 5, 7), sizeof(long));

                return RegisterConversion.ToBool4(RegisterConversion.IsFalse64(Divider<long4>.mm256_bmnotdivisible_epi64(x, d.Divisor, mulLo, mulHi, d._promises)));
            }
            else
            {
                return new bool4(d.GetInnerDivider<long2>(0).EvenlyDivides(x.xy),
                                 d.GetInnerDivider<long2>(2).EvenlyDivides(x.zw));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 EvenlyDivides(this Divider<long2> d, long x)
        {
d.AssertOperationMatchesInitialization(sizeof(long), 2, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            UInt128* mul = (UInt128*)&d._bigM;

            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool2(RegisterConversion.IsTrue64(Divider<long2>.bmdivisible_epi64((long2)x, d.Divisor, mul[0], mul[1], d._promises)));
            }
            else
            {
                return new bool2(Divider<long>.bmdivisible_i64(x, d.Divisor[0], mul[0], (Promise)d._promises),
                                 Divider<long>.bmdivisible_i64(x, d.Divisor[1], mul[1], (Promise)d._promises));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 EvenlyDivides(this Divider<long3> d, long x)
        {
d.AssertOperationMatchesInitialization(sizeof(long), 3, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            UInt128* mul = (UInt128*)&d._bigM;

            if (d._promises.Pow2)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return RegisterConversion.ToBool3(RegisterConversion.IsFalse64(Divider<long3>.mm256_bmnotdivisible_epi64(Xse.mm256_set1_epi64x(x), d.Divisor, default(v256), default(v256), (Promise)d._promises, 3)));
                }
            }

            if (BurstArchitecture.IsSIMDSupported)
            {
                return new bool3(RegisterConversion.ToBool2(RegisterConversion.IsTrue64(Divider<ulong2>.bmdivisible_epi64(Xse.set1_epi64x(x), d.Divisor.xy, mul[0], mul[1], (Promise)d._promises))),
                                 Divider<ulong>.bmdivisible_i64(x, d._divisor[2], mul[2], (Promise)d._promises));
            }
            else
            {
                return new bool3(Divider<long>.bmdivisible_i64(x, d.Divisor[0], mul[0], (Promise)d._promises),
                                 Divider<long>.bmdivisible_i64(x, d.Divisor[1], mul[1], (Promise)d._promises),
                                 Divider<long>.bmdivisible_i64(x, d.Divisor[2], mul[2], (Promise)d._promises));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 EvenlyDivides(this Divider<long4> d, long x)
        {
d.AssertOperationMatchesInitialization(sizeof(long), 4, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            UInt128* mul = (UInt128*)&d._bigM;

            if (Avx2.IsAvx2Supported)
            {
                long4 mulLo = Avx2.mm256_i64gather_epi64(mul, new long4(0, 2, 4, 6), sizeof(long));
                long4 mulHi = Avx2.mm256_i64gather_epi64(mul, new long4(1, 3, 5, 7), sizeof(long));

                return RegisterConversion.ToBool4(RegisterConversion.IsFalse64(Divider<long4>.mm256_bmnotdivisible_epi64((long4)x, d.Divisor, mulLo, mulHi, d._promises)));
            }
            else
            {
                return new bool4(d.GetInnerDivider<long2>(0).EvenlyDivides(x),
                                 d.GetInnerDivider<long2>(2).EvenlyDivides(x));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 EvenlyDivides(this Divider<long> d, long2 x)
        {
d.AssertOperationMatchesInitialization(sizeof(long), 2, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            UInt128 mul = *(UInt128*)&d._bigM;

            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool2(RegisterConversion.IsTrue64(Divider<long2>.bmdivisible_epi64(x, (long2)d.Divisor, mul, mul, d._promises.Reinterpret<Divider<long>.DividerPromise, Divider<long2>.DividerPromise>())));
            }
            else
            {
                return new bool2(Divider<long>.bmdivisible_i64(x[0], d.Divisor, mul, d._promises),
                                 Divider<long>.bmdivisible_i64(x[1], d.Divisor, mul, d._promises));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 EvenlyDivides(this Divider<long> d, long3 x)
        {
d.AssertOperationMatchesInitialization(sizeof(long), 3, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            UInt128 mul = *(UInt128*)&d._bigM;

            if (d._promises.Pow2)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return RegisterConversion.ToBool3(RegisterConversion.IsFalse64(Divider<long3>.mm256_bmnotdivisible_epi64(x, Xse.mm256_set1_epi64x(d.Divisor), default(v256), default(v256), (Promise)d._promises, 3)));
                }
            }

            if (BurstArchitecture.IsSIMDSupported)
            {
                return new bool3(RegisterConversion.ToBool2(RegisterConversion.IsTrue64(Divider<ulong2>.bmdivisible_epi64(x.xy, Xse.set1_epi64x(d.Divisor), mul, mul, (Promise)d._promises))),
                                 Divider<ulong>.bmdivisible_i64(x[2], d._divisor, mul, (Promise)d._promises));
            }
            {
                return new bool3(Divider<long>.bmdivisible_i64(x[0], d.Divisor, mul, d._promises),
                                 Divider<long>.bmdivisible_i64(x[1], d.Divisor, mul, d._promises),
                                 Divider<long>.bmdivisible_i64(x[2], d.Divisor, mul, d._promises));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 EvenlyDivides(this Divider<long> d, long4 x)
        {
d.AssertOperationMatchesInitialization(sizeof(long), 4, columnCount: 1, Signedness.Signed, NumericDataType.Integer);

            if (Avx2.IsAvx2Supported)
            {
                UInt128 mul = *(UInt128*)&d._bigM;

                return RegisterConversion.ToBool4(RegisterConversion.IsFalse64(Divider<long4>.mm256_bmnotdivisible_epi64(x, (long4)d.Divisor, (ulong4)mul.lo64, (ulong4)mul.hi64, d._promises.Reinterpret<Divider<long>.DividerPromise, Divider<long4>.DividerPromise>())));
            }
            else
            {
                return new bool4(d.EvenlyDivides(x.xy),
                                 d.EvenlyDivides(x.zw));
            }
        }
    }
}
