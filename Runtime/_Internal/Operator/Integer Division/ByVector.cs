using DevTools;
using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    // Even though the code size is "large" and the C# source looks like a mess, 
    // this long division algorithm is about FIVE times faster than - (byte16 case), or EIGHT times faster than - (byte32 case) scalar division of bytes 
    // or even via float conversion when compiled natively without Divide-By-Zero checks (release mode) - without requiring RAM-bandwidth-bound table-lookups.
    // Additionally, each loop iteration is a fantastic candidate for instruction level parallelism.

    // There is no compare_greater instruction for unsigned types in <= Avx2. For the byte16 case, it is faster to up-/downcast to/from unsigned shorts,
    // because the Operator.greater_mask_byte, which is called eight times, consists of two XOR's and one compare instruction - and bitshifting bytes in vector
    // registers requires masking aswell, since there are no native 8-bit shifting instructions.

    // The first and last loop iterations are inlined by hand, in order to not perform two unnecessary bitshift operations during the first iteration
    // and operations on the now unneeded remainders and/or quotients during the last iteration. A decent compiler may remove a loop of eight iterations
    // aswell as useless operations, but I have seen the opposite happen, since unrolling often results in the usage of SIMD registers. A compiler might decide
    // that there is nothing to unroll here.
    unsafe internal static partial class Operator
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static byte32 vdivrem_byte(byte32 dividend, byte32 divisor, out byte32 remainder)
        {
Assert.AreNotEqual(divisor.x0,  0);
Assert.AreNotEqual(divisor.x1,  0);
Assert.AreNotEqual(divisor.x2,  0);
Assert.AreNotEqual(divisor.x3,  0);
Assert.AreNotEqual(divisor.x4,  0);
Assert.AreNotEqual(divisor.x5,  0);
Assert.AreNotEqual(divisor.x6,  0);
Assert.AreNotEqual(divisor.x7,  0);
Assert.AreNotEqual(divisor.x8,  0);
Assert.AreNotEqual(divisor.x9,  0);
Assert.AreNotEqual(divisor.x10, 0);
Assert.AreNotEqual(divisor.x11, 0);
Assert.AreNotEqual(divisor.x12, 0);
Assert.AreNotEqual(divisor.x13, 0);
Assert.AreNotEqual(divisor.x14, 0);
Assert.AreNotEqual(divisor.x15, 0);
Assert.AreNotEqual(divisor.x16, 0);
Assert.AreNotEqual(divisor.x17, 0);
Assert.AreNotEqual(divisor.x18, 0);
Assert.AreNotEqual(divisor.x19, 0);
Assert.AreNotEqual(divisor.x20, 0);
Assert.AreNotEqual(divisor.x21, 0);
Assert.AreNotEqual(divisor.x22, 0);
Assert.AreNotEqual(divisor.x23, 0);
Assert.AreNotEqual(divisor.x24, 0);
Assert.AreNotEqual(divisor.x25, 0);
Assert.AreNotEqual(divisor.x26, 0);
Assert.AreNotEqual(divisor.x27, 0);
Assert.AreNotEqual(divisor.x28, 0);
Assert.AreNotEqual(divisor.x29, 0);
Assert.AreNotEqual(divisor.x30, 0);
Assert.AreNotEqual(divisor.x31, 0);

            byte32 quotients = default(byte32); 
            remainder = default(byte32);


            remainder |= (new byte32(1) & (dividend >> 7));

            v256 subtractDivisorFromRemainder = Avx2.mm256_andnot_si256(Operator.greater_mask_byte(divisor, remainder), new v256(-1));

            remainder -= Avx2.mm256_blendv_epi8(default(v256), divisor, subtractDivisorFromRemainder);
            quotients |= new byte32(1) & subtractDivisorFromRemainder;

            divrem_LOOPHEAD_byte(6, ref quotients, ref remainder, in divisor, in dividend);
            divrem_LOOPHEAD_byte(5, ref quotients, ref remainder, in divisor, in dividend);
            divrem_LOOPHEAD_byte(4, ref quotients, ref remainder, in divisor, in dividend);
            divrem_LOOPHEAD_byte(3, ref quotients, ref remainder, in divisor, in dividend);
            divrem_LOOPHEAD_byte(2, ref quotients, ref remainder, in divisor, in dividend);
            divrem_LOOPHEAD_byte(1, ref quotients, ref remainder, in divisor, in dividend);

            remainder <<= 1;;
            quotients <<= 1;

            remainder |= new byte32(1) & dividend;

            subtractDivisorFromRemainder = Avx2.mm256_andnot_si256(Operator.greater_mask_byte(divisor, remainder), new v256(-1));

            remainder -= Avx2.mm256_blendv_epi8(default(v256), divisor, subtractDivisorFromRemainder);
            quotients |= new byte32(1) & subtractDivisorFromRemainder;


            return quotients;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static byte32 vdiv_byte(byte32 dividend, byte32 divisor)
        {
Assert.AreNotEqual(divisor.x0,  0);
Assert.AreNotEqual(divisor.x1,  0);
Assert.AreNotEqual(divisor.x2,  0);
Assert.AreNotEqual(divisor.x3,  0);
Assert.AreNotEqual(divisor.x4,  0);
Assert.AreNotEqual(divisor.x5,  0);
Assert.AreNotEqual(divisor.x6,  0);
Assert.AreNotEqual(divisor.x7,  0);
Assert.AreNotEqual(divisor.x8,  0);
Assert.AreNotEqual(divisor.x9,  0);
Assert.AreNotEqual(divisor.x10, 0);
Assert.AreNotEqual(divisor.x11, 0);
Assert.AreNotEqual(divisor.x12, 0);
Assert.AreNotEqual(divisor.x13, 0);
Assert.AreNotEqual(divisor.x14, 0);
Assert.AreNotEqual(divisor.x15, 0);
Assert.AreNotEqual(divisor.x16, 0);
Assert.AreNotEqual(divisor.x17, 0);
Assert.AreNotEqual(divisor.x18, 0);
Assert.AreNotEqual(divisor.x19, 0);
Assert.AreNotEqual(divisor.x20, 0);
Assert.AreNotEqual(divisor.x21, 0);
Assert.AreNotEqual(divisor.x22, 0);
Assert.AreNotEqual(divisor.x23, 0);
Assert.AreNotEqual(divisor.x24, 0);
Assert.AreNotEqual(divisor.x25, 0);
Assert.AreNotEqual(divisor.x26, 0);
Assert.AreNotEqual(divisor.x27, 0);
Assert.AreNotEqual(divisor.x28, 0);
Assert.AreNotEqual(divisor.x29, 0);
Assert.AreNotEqual(divisor.x30, 0);
Assert.AreNotEqual(divisor.x31, 0);

            byte32 quotients = default(byte32);
            byte32 remainder = default(byte32);


            remainder |= (new byte32(1) & (dividend >> 7));

            v256 subtractDivisorFromRemainder = Avx2.mm256_andnot_si256(Operator.greater_mask_byte(divisor, remainder), new v256(-1));

            remainder -= Avx2.mm256_blendv_epi8(default(v256), divisor, subtractDivisorFromRemainder);
            quotients |= new byte32(1) & subtractDivisorFromRemainder;

            divrem_LOOPHEAD_byte(6, ref quotients, ref remainder, in divisor, in dividend);
            divrem_LOOPHEAD_byte(5, ref quotients, ref remainder, in divisor, in dividend);
            divrem_LOOPHEAD_byte(4, ref quotients, ref remainder, in divisor, in dividend);
            divrem_LOOPHEAD_byte(3, ref quotients, ref remainder, in divisor, in dividend);
            divrem_LOOPHEAD_byte(2, ref quotients, ref remainder, in divisor, in dividend);
            divrem_LOOPHEAD_byte(1, ref quotients, ref remainder, in divisor, in dividend);

            remainder <<= 1;;
            quotients <<= 1;

            remainder |= new byte32(1) & dividend;

            subtractDivisorFromRemainder = Avx2.mm256_andnot_si256(Operator.greater_mask_byte(divisor, remainder), new v256(-1));

            quotients |= new byte32(1) & subtractDivisorFromRemainder;


            return quotients;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static byte32 vrem_byte(byte32 dividend, byte32 divisor)
        {
Assert.AreNotEqual(divisor.x0,  0);
Assert.AreNotEqual(divisor.x1,  0);
Assert.AreNotEqual(divisor.x2,  0);
Assert.AreNotEqual(divisor.x3,  0);
Assert.AreNotEqual(divisor.x4,  0);
Assert.AreNotEqual(divisor.x5,  0);
Assert.AreNotEqual(divisor.x6,  0);
Assert.AreNotEqual(divisor.x7,  0);
Assert.AreNotEqual(divisor.x8,  0);
Assert.AreNotEqual(divisor.x9,  0);
Assert.AreNotEqual(divisor.x10, 0);
Assert.AreNotEqual(divisor.x11, 0);
Assert.AreNotEqual(divisor.x12, 0);
Assert.AreNotEqual(divisor.x13, 0);
Assert.AreNotEqual(divisor.x14, 0);
Assert.AreNotEqual(divisor.x15, 0);
Assert.AreNotEqual(divisor.x16, 0);
Assert.AreNotEqual(divisor.x17, 0);
Assert.AreNotEqual(divisor.x18, 0);
Assert.AreNotEqual(divisor.x19, 0);
Assert.AreNotEqual(divisor.x20, 0);
Assert.AreNotEqual(divisor.x21, 0);
Assert.AreNotEqual(divisor.x22, 0);
Assert.AreNotEqual(divisor.x23, 0);
Assert.AreNotEqual(divisor.x24, 0);
Assert.AreNotEqual(divisor.x25, 0);
Assert.AreNotEqual(divisor.x26, 0);
Assert.AreNotEqual(divisor.x27, 0);
Assert.AreNotEqual(divisor.x28, 0);
Assert.AreNotEqual(divisor.x29, 0);
Assert.AreNotEqual(divisor.x30, 0);
Assert.AreNotEqual(divisor.x31, 0);

            byte32 remainders = default(byte32);


            remainders |= (new byte32(1) & (dividend >> 7));

            v256 subtractDivisorFromRemainder = Avx2.mm256_andnot_si256(Operator.greater_mask_byte(divisor, remainders), new v256(-1));

            remainders -= Avx2.mm256_blendv_epi8(default(v256), divisor, subtractDivisorFromRemainder);

            rem_LOOPHEAD_byte(6, ref remainders, in divisor, in dividend);
            rem_LOOPHEAD_byte(5, ref remainders, in divisor, in dividend);
            rem_LOOPHEAD_byte(4, ref remainders, in divisor, in dividend);
            rem_LOOPHEAD_byte(3, ref remainders, in divisor, in dividend);
            rem_LOOPHEAD_byte(2, ref remainders, in divisor, in dividend);
            rem_LOOPHEAD_byte(1, ref remainders, in divisor, in dividend);

            remainders <<= 1;;

            remainders |= new byte32(1) & dividend;

            subtractDivisorFromRemainder = Avx2.mm256_andnot_si256(Operator.greater_mask_byte(divisor, remainders), new v256(-1));

            remainders -= Avx2.mm256_blendv_epi8(default(v256), divisor, subtractDivisorFromRemainder);


            return remainders;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static sbyte32 vdivrem_sbyte(sbyte32 dividend, sbyte32 divisor, out sbyte32 remainder)
        {
            byte32 quotient = vdivrem_byte((byte32)maxmath.abs(dividend), (byte32)maxmath.abs(divisor), out byte32 remainders);

            byte32 mustNegate = Avx2.mm256_cmpgt_epi8(default(sbyte32), dividend);

            remainder = Avx2.mm256_blendv_epi8(remainders, -((sbyte32)remainders), mustNegate);

            mustNegate = Avx2.mm256_xor_si256(Avx2.mm256_cmpgt_epi8(default(sbyte32), divisor),
                                              Avx2.mm256_cmpgt_epi8(default(sbyte32), dividend));

            return Avx2.mm256_blendv_epi8(quotient, -((sbyte32)quotient), mustNegate);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static sbyte32 vdiv_sbyte(sbyte32 dividend, sbyte32 divisor)
        {
            byte32 quotient = vdiv_byte((byte32)maxmath.abs(dividend), (byte32)maxmath.abs(divisor));

            byte32 mustNegate = Avx2.mm256_xor_si256(Avx2.mm256_cmpgt_epi8(default(sbyte32), divisor),
                                                     Avx2.mm256_cmpgt_epi8(default(sbyte32), dividend));

            return Avx2.mm256_blendv_epi8(quotient, -((sbyte32)quotient), mustNegate);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static sbyte32 vrem_sbyte(sbyte32 dividend, sbyte32 divisor)
        {
            byte32 remainder = vrem_byte((byte32)maxmath.abs(dividend), (byte32)maxmath.abs(divisor));

            byte32 mustNegate = Avx2.mm256_cmpgt_epi8(default(sbyte32), dividend);

            return Avx2.mm256_blendv_epi8(remainder, -((sbyte32)remainder), mustNegate);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static byte16 vdivrem_byte(byte16 dividend, byte16 divisor, out byte16 remainder)
        {
Assert.AreNotEqual(divisor.x0,  0);
Assert.AreNotEqual(divisor.x1,  0);
Assert.AreNotEqual(divisor.x2,  0);
Assert.AreNotEqual(divisor.x3,  0);
Assert.AreNotEqual(divisor.x4,  0);
Assert.AreNotEqual(divisor.x5,  0);
Assert.AreNotEqual(divisor.x6,  0);
Assert.AreNotEqual(divisor.x7,  0);
Assert.AreNotEqual(divisor.x8,  0);
Assert.AreNotEqual(divisor.x9,  0);
Assert.AreNotEqual(divisor.x10, 0);
Assert.AreNotEqual(divisor.x11, 0);
Assert.AreNotEqual(divisor.x12, 0);
Assert.AreNotEqual(divisor.x13, 0);
Assert.AreNotEqual(divisor.x14, 0);
Assert.AreNotEqual(divisor.x15, 0);

            ushort16 quotients = default(ushort16);
            ushort16 remainders = default(ushort16);

            ushort16 divisorCast = divisor;
            ushort16 dividendCast = dividend;


            remainders |= (new ushort16(1) & (dividendCast >> 7));

            v256 subtractDivisorFromRemainder = Avx2.mm256_andnot_si256(Avx2.mm256_cmpgt_epi16(divisorCast, remainders), new v256(-1));

            remainders -= Avx2.mm256_blendv_epi8(default(v256), divisorCast, subtractDivisorFromRemainder);
            quotients |= new ushort16(1) & subtractDivisorFromRemainder;

            divrem_LOOPHEAD_upcast(6, ref quotients, ref remainders, in divisorCast, in dividendCast);
            divrem_LOOPHEAD_upcast(5, ref quotients, ref remainders, in divisorCast, in dividendCast);
            divrem_LOOPHEAD_upcast(4, ref quotients, ref remainders, in divisorCast, in dividendCast);
            divrem_LOOPHEAD_upcast(3, ref quotients, ref remainders, in divisorCast, in dividendCast);
            divrem_LOOPHEAD_upcast(2, ref quotients, ref remainders, in divisorCast, in dividendCast);
            divrem_LOOPHEAD_upcast(1, ref quotients, ref remainders, in divisorCast, in dividendCast);

            remainders <<= 1;
            quotients <<= 1;

            remainders |= new ushort16(1) & dividendCast;

            subtractDivisorFromRemainder = Avx2.mm256_andnot_si256(Avx2.mm256_cmpgt_epi16(divisorCast, remainders), new v256(-1));

            remainders -= Avx2.mm256_blendv_epi8(default(v256), divisorCast, subtractDivisorFromRemainder);
            quotients |= new ushort16(1) & subtractDivisorFromRemainder;


            remainder = Sse2.packus_epi16(Avx.mm256_castsi256_si128(remainders), Avx2.mm256_extracti128_si256(remainders, 1));
            return Sse2.packus_epi16(Avx.mm256_castsi256_si128(quotients), Avx2.mm256_extracti128_si256(quotients, 1));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static byte16 vdiv_byte(byte16 dividend, byte16 divisor)
        {
Assert.AreNotEqual(divisor.x0,  0);
Assert.AreNotEqual(divisor.x1,  0);
Assert.AreNotEqual(divisor.x2,  0);
Assert.AreNotEqual(divisor.x3,  0);
Assert.AreNotEqual(divisor.x4,  0);
Assert.AreNotEqual(divisor.x5,  0);
Assert.AreNotEqual(divisor.x6,  0);
Assert.AreNotEqual(divisor.x7,  0);
Assert.AreNotEqual(divisor.x8,  0);
Assert.AreNotEqual(divisor.x9,  0);
Assert.AreNotEqual(divisor.x10, 0);
Assert.AreNotEqual(divisor.x11, 0);
Assert.AreNotEqual(divisor.x12, 0);
Assert.AreNotEqual(divisor.x13, 0);
Assert.AreNotEqual(divisor.x14, 0);
Assert.AreNotEqual(divisor.x15, 0);

            ushort16 quotients = default(ushort16);
            ushort16 remainders = default(ushort16);

            ushort16 divisorCast = divisor;
            ushort16 dividendCast = dividend;


            remainders |= (new ushort16(1) & (dividendCast >> 7));

            v256 subtractDivisorFromRemainder = Avx2.mm256_andnot_si256(Avx2.mm256_cmpgt_epi16(divisorCast, remainders), new v256(-1));

            remainders -= Avx2.mm256_blendv_epi8(default(v256), divisorCast, subtractDivisorFromRemainder);
            quotients |= new ushort16(1) & subtractDivisorFromRemainder;

            divrem_LOOPHEAD_upcast(6, ref quotients, ref remainders, in divisorCast, in dividendCast);
            divrem_LOOPHEAD_upcast(5, ref quotients, ref remainders, in divisorCast, in dividendCast);
            divrem_LOOPHEAD_upcast(4, ref quotients, ref remainders, in divisorCast, in dividendCast);
            divrem_LOOPHEAD_upcast(3, ref quotients, ref remainders, in divisorCast, in dividendCast);
            divrem_LOOPHEAD_upcast(2, ref quotients, ref remainders, in divisorCast, in dividendCast);
            divrem_LOOPHEAD_upcast(1, ref quotients, ref remainders, in divisorCast, in dividendCast);

            remainders <<= 1;
            quotients <<= 1;

            remainders |= new ushort16(1) & dividendCast;

            subtractDivisorFromRemainder = Avx2.mm256_andnot_si256(Avx2.mm256_cmpgt_epi16(divisorCast, remainders), new v256(-1));

            quotients |= new ushort16(1) & subtractDivisorFromRemainder;


            return Sse2.packus_epi16(Avx.mm256_castsi256_si128(quotients), Avx2.mm256_extracti128_si256(quotients, 1));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static byte16 vrem_byte(byte16 dividend, byte16 divisor)
        {
Assert.AreNotEqual(divisor.x0,  0);
Assert.AreNotEqual(divisor.x1,  0);
Assert.AreNotEqual(divisor.x2,  0);
Assert.AreNotEqual(divisor.x3,  0);
Assert.AreNotEqual(divisor.x4,  0);
Assert.AreNotEqual(divisor.x5,  0);
Assert.AreNotEqual(divisor.x6,  0);
Assert.AreNotEqual(divisor.x7,  0);
Assert.AreNotEqual(divisor.x8,  0);
Assert.AreNotEqual(divisor.x9,  0);
Assert.AreNotEqual(divisor.x10, 0);
Assert.AreNotEqual(divisor.x11, 0);
Assert.AreNotEqual(divisor.x12, 0);
Assert.AreNotEqual(divisor.x13, 0);
Assert.AreNotEqual(divisor.x14, 0);
Assert.AreNotEqual(divisor.x15, 0);

            ushort16 remainders = default(ushort16);

            ushort16 divisorCast = divisor;
            ushort16 dividendCast = dividend;


            remainders |= (new ushort16(1) & (dividendCast >> 7));

            v256 subtractDivisorFromRemainder = Avx2.mm256_andnot_si256(Avx2.mm256_cmpgt_epi16(divisorCast, remainders), new v256(-1));

            remainders -= Avx2.mm256_blendv_epi8(default(v256), divisorCast, subtractDivisorFromRemainder);

            rem_LOOPHEAD_upcast(6, ref remainders, in divisorCast, in dividendCast);
            rem_LOOPHEAD_upcast(5, ref remainders, in divisorCast, in dividendCast);
            rem_LOOPHEAD_upcast(4, ref remainders, in divisorCast, in dividendCast);
            rem_LOOPHEAD_upcast(3, ref remainders, in divisorCast, in dividendCast);
            rem_LOOPHEAD_upcast(2, ref remainders, in divisorCast, in dividendCast);
            rem_LOOPHEAD_upcast(1, ref remainders, in divisorCast, in dividendCast);

            remainders <<= 1;

            remainders |= new ushort16(1) & dividendCast;

            subtractDivisorFromRemainder = Avx2.mm256_andnot_si256(Avx2.mm256_cmpgt_epi16(divisorCast, remainders), new v256(-1));

            remainders -= Avx2.mm256_blendv_epi8(default(v256), divisorCast, subtractDivisorFromRemainder);


            return Sse2.packus_epi16(Avx.mm256_castsi256_si128(remainders), Avx2.mm256_extracti128_si256(remainders, 1));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static sbyte16 vdivrem_sbyte(sbyte16 dividend, sbyte16 divisor, out sbyte16 remainder)
        {
            byte16 quotient = vdivrem_byte((byte16)maxmath.abs(dividend), (byte16)maxmath.abs(divisor), out byte16 remainders);

            byte16 mustNegate = Sse2.cmpgt_epi8(default(sbyte16), dividend);

            remainder = Sse4_1.blendv_epi8(remainders, -((sbyte16)remainders), mustNegate);

            mustNegate = Sse2.xor_si128(Sse2.cmpgt_epi8(default(sbyte16), divisor),
                                        Sse2.cmpgt_epi8(default(sbyte16), dividend));

            return Sse4_1.blendv_epi8(quotient, -((sbyte16)quotient), mustNegate);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static sbyte16 vdiv_sbyte(sbyte16 dividend, sbyte16 divisor)
        {
            byte16 quotient = vdiv_byte((byte16)maxmath.abs(dividend), (byte16)maxmath.abs(divisor));

            byte16 mustNegate = Sse2.xor_si128(Sse2.cmpgt_epi8(default(sbyte16), divisor),
                                               Sse2.cmpgt_epi8(default(sbyte16), dividend));

            return Sse4_1.blendv_epi8(quotient, -((sbyte16)quotient), mustNegate);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static sbyte16 vrem_sbyte(sbyte16 dividend, sbyte16 divisor)
        {
            byte16 remainder = vrem_byte((byte16)maxmath.abs(dividend), (byte16)maxmath.abs(divisor));

            byte16 mustNegate = Sse2.cmpgt_epi8(default(sbyte16), dividend);

            return Sse4_1.blendv_epi8(remainder, -((sbyte16)remainder), mustNegate);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void divrem_LOOPHEAD_upcast(int i, ref ushort16 quotients, ref ushort16 remainders, in ushort16 divisorCast, in ushort16 dividendCast)
        {
            quotients <<= 1;
            remainders <<= 1;

            remainders |= (new ushort16(1) & (dividendCast >> i));

            v256 subtractDivisorFromRemainder = Avx2.mm256_andnot_si256(Avx2.mm256_cmpgt_epi16(divisorCast, remainders), new v256(-1));

            remainders -= Avx2.mm256_blendv_epi8(default(v256), divisorCast, subtractDivisorFromRemainder);
            quotients |= new ushort16(1) & subtractDivisorFromRemainder;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void rem_LOOPHEAD_upcast(int i, ref ushort16 remainders, in ushort16 divisorCast, in ushort16 dividendCast)
        {
            remainders <<= 1;

            remainders |= (new ushort16(1) & (dividendCast >> i));

            v256 subtractDivisorFromRemainder = Avx2.mm256_andnot_si256(Avx2.mm256_cmpgt_epi16(divisorCast, remainders), new v256(-1));

            remainders -= Avx2.mm256_blendv_epi8(default(v256), divisorCast, subtractDivisorFromRemainder);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void divrem_LOOPHEAD_byte(int i, ref byte32 quotients, ref byte32 remainders, in byte32 divisorCast, in byte32 dividendCast)
        {
            quotients <<= 1;
            remainders <<= 1;

            remainders |= (new byte32(1) & (dividendCast >> i));

            v256 subtractDivisorFromRemainder = Avx2.mm256_andnot_si256(Operator.greater_mask_byte(divisorCast, remainders), new v256(-1));

            remainders -= Avx2.mm256_blendv_epi8(default(v256), divisorCast, subtractDivisorFromRemainder);
            quotients |= new byte32(1) & subtractDivisorFromRemainder;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void rem_LOOPHEAD_byte(int i, ref byte32 remainders, in byte32 divisorCast, in byte32 dividendCast)
        {
            remainders <<= 1;

            remainders |= (new byte32(1) & (dividendCast >> i));

            v256 subtractDivisorFromRemainder = Avx2.mm256_andnot_si256(Operator.greater_mask_byte(divisorCast, remainders), new v256(-1));

            remainders -= Avx2.mm256_blendv_epi8(default(v256), divisorCast, subtractDivisorFromRemainder);
        }
    }
}