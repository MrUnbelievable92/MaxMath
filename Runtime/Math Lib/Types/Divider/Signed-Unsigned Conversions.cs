using System;
using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;
using static Unity.Mathematics.math;
using static MaxMath.maxmath;

namespace MaxMath
{
    unsafe public partial struct Divider<T>
        where T : unmanaged, IEquatable<T>, IFormattable
    {
//        private const Promise RETAINDED_PROMISES_CVTI2U = Promise.Nothing;
//
//        [MethodImpl(MethodImplOptions.AggressiveInlining)]
//        public static explicit operator Divider<byte2>(Divider<T> input)
//        {
//input.AssertOperationMatchesInitialization(sizeof(byte), 2, Signedness.Signed, NumericDataType.Integer);
//
//            if (sizeof(T) == sizeof(sbyte))
//            {
//                sbyte divisor = input._divisor.Reinterpret<T, sbyte>();
//                ushort mul = input._bigM.Reinterpret<BigM, ushort>();
//                DividerPromise promises = input._promises;
//
//                bmcvti2u_i8(ref mul, divisor, promises);
//
//                Divider<byte2> result = new Divider<byte2>((byte)divisor, promises & RETAINDED_PROMISES_CVTI2U);
//                result._bigM = new Divider<byte2>.BigM { _mulLo = mul.Reinterpret<ushort, byte2>(), _mulHi = mul.Reinterpret<ushort, byte2>() };
//
//                return result;
//            }
//            else
//            {
//                sbyte2 divisor = input._divisor.Reinterpret<T, sbyte2>();
//                ushort2 mul = input._bigM.Reinterpret<BigM, ushort2>();
//                DividerPromise promises = input._promises;
//
//                if (ArchitectureInfo.IsSIMDSupported)
//                {
//                    v128 __mul = mul;
//                    bmcvti2u_epi8(ref __mul, divisor, promises);
//                    mul = __mul;
//                }
//                else
//                {
//                    bmcvti2u_i8(ref mul.x, divisor.x, promises);
//                    bmcvti2u_i8(ref mul.y, divisor.y, promises);
//                }
//
//                Divider<byte2> result = new Divider<byte2>((byte2)divisor, promises & RETAINDED_PROMISES_CVTI2U);
//                result._bigM = mul.Reinterpret<ushort2, Divider<byte2>.BigM>();
//
//                return result;
//            }
//        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static sbyte promise_abs_i8(sbyte x, DividerPromise promises)
        {
            if (promises.Positive)
            {
                return x;
            }
            else if (promises.Negative)
            {
                return (sbyte)-x;
            }
            else
            {
                return abs(x);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static short promise_abs_i16(short x, DividerPromise promises)
        {
            if (promises.Positive)
            {
                return x;
            }
            else if (promises.Negative)
            {
                return (short)-x;
            }
            else
            {
                return abs(x);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int promise_abs_i32(int x, DividerPromise promises)
        {
            if (promises.Positive)
            {
                return x;
            }
            else if (promises.Negative)
            {
                return -x;
            }
            else
            {
                return abs(x);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static long promise_abs_i64(long x, DividerPromise promises)
        {
            if (promises.Positive)
            {
                return x;
            }
            else if (promises.Negative)
            {
                return -x;
            }
            else
            {
                return abs(x);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Int128 promise_abs_i128(Int128 x, DividerPromise promises)
        {
            if (promises.Positive)
            {
                return x;
            }
            else if (promises.Negative)
            {
                return -x;
            }
            else
            {
                return abs(x);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 promise_abs_epi8(v128 x, DividerPromise promises, byte elements = 16)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (promises.Positive)
                {
                    return x;
                }
                else if (promises.Negative)
                {
                    return Xse.neg_epi8(x);
                }
                else
                {
                    return Xse.abs_epi8(x, elements);
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 promise_abs_epi16(v128 x, DividerPromise promises, byte elements = 8)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (promises.Positive)
                {
                    return x;
                }
                else if (promises.Negative)
                {
                    return Xse.neg_epi16(x);
                }
                else
                {
                    return Xse.abs_epi16(x, elements);
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 promise_abs_epi32(v128 x, DividerPromise promises, byte elements = 4)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (promises.Positive)
                {
                    return x;
                }
                else if (promises.Negative)
                {
                    return Xse.neg_epi32(x);
                }
                else
                {
                    return Xse.abs_epi32(x, elements);
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 promise_abs_epi64(v128 x, DividerPromise promises)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (promises.Positive)
                {
                    return x;
                }
                else if (promises.Negative)
                {
                    return Xse.neg_epi64(x);
                }
                else
                {
                    return Xse.abs_epi64(x);
                }
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_promise_abs_epi8(v256 x, DividerPromise promises)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (promises.Positive)
                {
                    return x;
                }
                else if (promises.Negative)
                {
                    return Xse.mm256_neg_epi8(x);
                }
                else
                {
                    return Xse.mm256_abs_epi8(x);
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_promise_abs_epi16(v256 x, DividerPromise promises)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (promises.Positive)
                {
                    return x;
                }
                else if (promises.Negative)
                {
                    return Xse.mm256_neg_epi16(x);
                }
                else
                {
                    return Xse.mm256_abs_epi16(x);
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_promise_abs_epi32(v256 x, DividerPromise promises)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (promises.Positive)
                {
                    return x;
                }
                else if (promises.Negative)
                {
                    return Xse.mm256_neg_epi32(x);
                }
                else
                {
                    return Xse.mm256_abs_epi32(x);
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_promise_abs_epi64(v256 x, DividerPromise promises, byte elements = 4)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (promises.Positive)
                {
                    return x;
                }
                else if (promises.Negative)
                {
                    return Xse.mm256_neg_epi64(x);
                }
                else
                {
                    return Xse.mm256_abs_epi64(x, elements);
                }
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void bmcvti2u_i8([NoAlias] ref ushort mul, [NoAlias] ref sbyte original, DividerPromise promises)
        {
            original = promise_abs_i8(original, promises);

            if (promises.NotPow2)
            {
                return;
            }
            else if (promises.Pow2)
            {
                mul--;
            }
            else
            {
                mul -= tobyte(bits_resetlowest(original) == 0);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void bmcvti2u_i16([NoAlias] ref uint mul, [NoAlias] ref short original, DividerPromise promises)
        {
            original = promise_abs_i16(original, promises);

            if (promises.NotPow2)
            {
                return;
            }
            else if (promises.Pow2)
            {
                mul--;
            }
            else
            {
                mul -= tobyte(bits_resetlowest(original) == 0);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void bmcvti2u_i32([NoAlias] ref ulong mul, [NoAlias] ref int original, DividerPromise promises)
        {
            original = promise_abs_i32(original, promises);

            if (promises.NotPow2)
            {
                return;
            }
            else if (promises.Pow2)
            {
                mul--;
            }
            else
            {
                mul -= tobyte(bits_resetlowest(original) == 0);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void bmcvti2u_i64([NoAlias] ref UInt128 mul, [NoAlias] ref long original, DividerPromise promises)
        {
            original = promise_abs_i64(original, promises);

            if (promises.NotPow2)
            {
                return;
            }
            else if (promises.Pow2)
            {
                mul--;
            }
            else
            {
                mul -= tobyte(bits_resetlowest(original) == 0);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void bmcvti2u_i128([NoAlias] ref __UInt256__ mul, [NoAlias] ref Int128 original, DividerPromise promises)
        {
            original = promise_abs_i128(original, promises);

            if (promises.NotPow2)
            {
                return;
            }
            else if (promises.Pow2)
            {
                mul--;
            }
            else
            {
                mul -= tobyte(bits_resetlowest(original) == 0);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void bmcvti2u_epi8([NoAlias] ref v128 mul, [NoAlias] ref v128 original, DividerPromise promises, byte elements = 8)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                original = promise_abs_epi8(original, promises, elements);

                if (promises.NotPow2)
                {
                    return;
                }
                else if (promises.Pow2)
                {
                    mul = Xse.dec_epi16(mul);
                }
                else
                {
                    v128 cmp = Xse.cvtepu8_epi16(original);

                    mul = Xse.add_epi16(mul, Xse.cmpeq_epi16(Xse.setzero_si128(), Xse.blsr_epi16(cmp)));
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void bmcvti2u_epi8([NoAlias] ref v128 mulLo, [NoAlias] ref v128 mulHi, [NoAlias] ref v128 original, DividerPromise promises)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                original = promise_abs_epi8(original, promises, 16);

                if (promises.NotPow2)
                {
                    return;
                }
                else if (promises.Pow2)
                {
                    mulLo = Xse.dec_epi16(mulLo);
                    mulHi = Xse.dec_epi16(mulHi);
                }
                else
                {
                    v128 maskLo = Xse.cvt2x2epi8_epi16(Xse.cmpeq_epi8(Xse.setzero_si128(), Xse.blsr_epi8(original)), out v128 maskHi);

                    mulLo = Xse.add_epi16(mulLo, maskLo);
                    mulHi = Xse.add_epi16(mulHi, maskHi);
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void mm256_bmcvti2u_epi8([NoAlias] ref v256 mulLo, [NoAlias] ref v256 mulHi, [NoAlias] ref v256 original, DividerPromise promises)
        {
            if (Avx2.IsAvx2Supported)
            {
                original = mm256_promise_abs_epi8(original, promises);

                if (promises.NotPow2)
                {
                    return;
                }
                else if (promises.Pow2)
                {
                    mulLo = Xse.mm256_dec_epi16(mulLo);
                    mulHi = Xse.mm256_dec_epi16(mulHi);
                }
                else
                {
                    v256 maskLo = Xse.mm256_cvt2x2epi8_epi16(Avx2.mm256_cmpeq_epi8(Avx.mm256_setzero_si256(), Xse.mm256_blsr_epi8(original)), out v256 maskHi);

                    v256 _mulLo = Avx2.mm256_add_epi16(new v256(mulLo.Lo128, mulHi.Lo128), maskLo);
                    v256 _mulHi = Avx2.mm256_add_epi16(new v256(mulLo.Hi128, mulHi.Hi128), maskHi);

                    mulLo = new v256(_mulLo.Lo128, _mulHi.Lo128);
                    mulHi = new v256(_mulLo.Hi128, _mulHi.Hi128);
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void bmcvti2u_epi16([NoAlias] ref v128 mul, [NoAlias] ref v128 original, DividerPromise promises, byte elements = 4)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                original = promise_abs_epi16(original, promises, elements);

                if (promises.NotPow2)
                {
                    return;
                }
                else if (promises.Pow2)
                {
                    mul = Xse.dec_epi16(mul);
                }
                else
                {
                    v128 cmp = Xse.cvtepu16_epi32(original);

                    mul = Xse.add_epi32(mul, Xse.cmpeq_epi32(Xse.setzero_si128(), Xse.blsr_epi32(cmp)));
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void bmcvti2u_epi16([NoAlias] ref v128 mulLo, [NoAlias] ref v128 mulHi, [NoAlias] ref v128 original, DividerPromise promises)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                original = promise_abs_epi16(original, promises);

                if (promises.NotPow2)
                {
                    return;
                }
                else if (promises.Pow2)
                {
                    mulLo = Xse.dec_epi16(mulLo);
                    mulHi = Xse.dec_epi16(mulHi);
                }
                else
                {
                    v128 maskLo = Xse.cvt2x2epi16_epi32(Xse.cmpeq_epi16(Xse.setzero_si128(), Xse.blsr_epi16(original)), out v128 maskHi);

                    mulLo = Xse.add_epi32(mulLo, maskLo);
                    mulHi = Xse.add_epi32(mulHi, maskHi);
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void mm256_bmcvti2u_epi16([NoAlias] ref v256 mulLo, [NoAlias] ref v256 mulHi, [NoAlias] ref v256 original, DividerPromise promises)
        {
            if (Avx2.IsAvx2Supported)
            {
                original = mm256_promise_abs_epi16(original, promises);

                if (promises.NotPow2)
                {
                    return;
                }
                else if (promises.Pow2)
                {
                    mulLo = Xse.mm256_dec_epi16(mulLo);
                    mulHi = Xse.mm256_dec_epi16(mulHi);
                }
                else
                {
                    v256 maskLo = Xse.mm256_cvt2x2epi16_epi32(Avx2.mm256_cmpeq_epi16(Avx.mm256_setzero_si256(), Xse.mm256_blsr_epi16(original)), out v256 maskHi);

                    v256 _mulLo = Avx2.mm256_add_epi32(new v256(mulLo.Lo128, mulHi.Lo128), maskLo);
                    v256 _mulHi = Avx2.mm256_add_epi32(new v256(mulLo.Hi128, mulHi.Hi128), maskHi);

                    mulLo = new v256(_mulLo.Lo128, _mulHi.Lo128);
                    mulHi = new v256(_mulLo.Hi128, _mulHi.Hi128);
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void bmcvti2u_epi32([NoAlias] ref v128 mul, [NoAlias] ref v128 original, DividerPromise promises)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                original = promise_abs_epi32(original, promises, 2);

                if (promises.NotPow2)
                {
                    return;
                }
                else if (promises.Pow2)
                {
                    mul = Xse.dec_epi64(mul);
                }
                else
                {
                    mul = Xse.add_epi64(mul, Xse.cvtepi32_epi64(Xse.cmpeq_epi32(Xse.setzero_si128(), Xse.blsr_epi32(original))));
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void bmcvti2u_epi32([NoAlias] ref v128 mulLo, [NoAlias] ref v128 mulHi, [NoAlias] ref v128 original, DividerPromise promises, byte elements = 4)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                original = promise_abs_epi32(original, promises, elements);

                if (promises.NotPow2)
                {
                    return;
                }
                else if (promises.Pow2)
                {
                    mulLo = Xse.dec_epi64(mulLo);
                    mulHi = Xse.dec_epi64(mulHi);
                }
                else
                {
                    v128 maskLo = Xse.cvt2x2epi32_epi64(Xse.cmpeq_epi32(Xse.setzero_si128(), Xse.blsr_epi32(original)), out v128 maskHi);

                    mulLo = Xse.add_epi64(mulLo, maskLo);
                    mulHi = Xse.add_epi64(mulHi, maskHi);
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void mm256_bmcvti2u_epi32([NoAlias] ref v256 mulLo, [NoAlias] ref v256 mulHi, [NoAlias] ref v256 original, DividerPromise promises)
        {
            if (Avx2.IsAvx2Supported)
            {
                original = mm256_promise_abs_epi32(original, promises);

                if (promises.NotPow2)
                {
                    return;
                }
                else if (promises.Pow2)
                {
                    mulLo = Xse.mm256_dec_epi32(mulLo);
                    mulHi = Xse.mm256_dec_epi32(mulHi);
                }
                else
                {
                    v256 maskLo = Xse.mm256_cvt2x2epi32_epi64(Avx2.mm256_cmpeq_epi32(Avx.mm256_setzero_si256(), Xse.mm256_blsr_epi32(original)), out v256 maskHi);

                    v256 _mulLo = Avx2.mm256_add_epi64(new v256(mulLo.Lo128, mulHi.Lo128), maskLo);
                    v256 _mulHi = Avx2.mm256_add_epi64(new v256(mulLo.Hi128, mulHi.Hi128), maskHi);

                    mulLo = new v256(_mulLo.Lo128, _mulHi.Lo128);
                    mulHi = new v256(_mulLo.Hi128, _mulHi.Hi128);
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void bmcvti2u_epi64([NoAlias] ref UInt128 mulLo, [NoAlias] ref UInt128 mulHi, [NoAlias] ref v128 original, DividerPromise promises)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                original = promise_abs_epi64(original, promises);

                if (promises.NotPow2)
                {
                    return;
                }
                else if (promises.Pow2)
                {
                    mulLo--;
                    mulHi--;
                }
                else
                {
                    v128 cmp = Xse.blsr_epi64(original);

                    if (BurstArchitecture.IsCMP64Supported)
                    {
                        v128 pow2Mask = Xse.cmpeq_epi64(Xse.setzero_si128(), cmp);

                        mulLo += new UInt128(Xse.extract_epi64(pow2Mask, 0), Xse.extract_epi64(pow2Mask, 0));
                        mulHi += new UInt128(Xse.extract_epi64(pow2Mask, 1), Xse.extract_epi64(pow2Mask, 1));
                    }
                    else
                    {
                        ulong cmpLo = Xse.extract_epi64(cmp, 0);
                        ulong cmpHi = Xse.extract_epi64(cmp, 1);

                        mulLo -= tobyte(cmpLo == 0);
                        mulHi -= tobyte(cmpHi == 0);
                    }
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void mm256_bmcvti2u_epi64([NoAlias] ref v256 mulLo, [NoAlias] ref v256 mulHi, [NoAlias] ref v256 original, DividerPromise promises, byte elements = 4)
        {
            if (Avx2.IsAvx2Supported)
            {
                original = mm256_promise_abs_epi64(original, promises, elements);

                if (promises.NotPow2)
                {
                    return;
                }
                else if (promises.Pow2)
                {
                    Xse.mm256_dec_epu128(mulLo, mulHi, out mulLo, out mulHi);
                }
                else
                {
                    v256 pow2Mask = Avx2.mm256_cmpeq_epi64(Avx.mm256_setzero_si256(), Xse.mm256_blsr_epi64(original));

                    v256 lo = mulLo;
                    v256 hi = mulHi;
                    Xse.mm256_dec_epu128(lo, hi, out lo, out hi);
                    mulLo = Xse.mm256_blendv_si256(mulLo, lo, pow2Mask);
                    mulHi = Xse.mm256_blendv_si256(mulHi, hi, pow2Mask);
                }
            }
            else throw new IllegalInstructionException();
        }
    }
}
