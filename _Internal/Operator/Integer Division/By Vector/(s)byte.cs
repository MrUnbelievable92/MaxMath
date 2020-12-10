using DevTools;
using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe internal static partial class Operator
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static byte32 vdivrem_byte(byte32 dividend, byte32 divisor, out byte32 remainder)
        {
Assert.AreNotEqual(divisor.x0, 0);
Assert.AreNotEqual(divisor.x1, 0);
Assert.AreNotEqual(divisor.x2, 0);
Assert.AreNotEqual(divisor.x3, 0);
Assert.AreNotEqual(divisor.x4, 0);
Assert.AreNotEqual(divisor.x5, 0);
Assert.AreNotEqual(divisor.x6, 0);
Assert.AreNotEqual(divisor.x7, 0);
Assert.AreNotEqual(divisor.x8, 0);
Assert.AreNotEqual(divisor.x9, 0);
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

            ushort16 quotients_lo = default(ushort16);
            ushort16 remainders_lo = default(ushort16);

            ushort16 divisorCast_lo = divisor.v16_0;
            ushort16 dividendCast_lo = dividend.v16_0;


            remainders_lo |= (new ushort16(1) & (dividendCast_lo >> 7));

            v256 subtractDivisorFromRemainder = Avx2.mm256_andnot_si256(Avx2.mm256_cmpgt_epi16(divisorCast_lo, remainders_lo), new v256(-1));

            remainders_lo -= Avx2.mm256_blendv_epi8(default(v256), divisorCast_lo, subtractDivisorFromRemainder);
            quotients_lo |= new ushort16(1) & subtractDivisorFromRemainder;

            divrem_LOOPHEAD(6, ref quotients_lo, ref remainders_lo, in divisorCast_lo, in dividendCast_lo);
            divrem_LOOPHEAD(5, ref quotients_lo, ref remainders_lo, in divisorCast_lo, in dividendCast_lo);
            divrem_LOOPHEAD(4, ref quotients_lo, ref remainders_lo, in divisorCast_lo, in dividendCast_lo);
            divrem_LOOPHEAD(3, ref quotients_lo, ref remainders_lo, in divisorCast_lo, in dividendCast_lo);
            divrem_LOOPHEAD(2, ref quotients_lo, ref remainders_lo, in divisorCast_lo, in dividendCast_lo);
            divrem_LOOPHEAD(1, ref quotients_lo, ref remainders_lo, in divisorCast_lo, in dividendCast_lo);

            remainders_lo <<= 1;;
            quotients_lo <<= 1;

            remainders_lo |= new ushort16(1) & dividendCast_lo;

            subtractDivisorFromRemainder = Avx2.mm256_andnot_si256(Avx2.mm256_cmpgt_epi16(divisorCast_lo, remainders_lo), new v256(-1));

            remainders_lo -= Avx2.mm256_blendv_epi8(default(v256), divisorCast_lo, subtractDivisorFromRemainder);
            quotients_lo |= new ushort16(1) & subtractDivisorFromRemainder;


            ushort16 quotients_hi = default(ushort16);
            ushort16 remainders_hi = default(ushort16);

            divisorCast_lo = divisor.v16_16;
            dividendCast_lo = dividend.v16_16;


            remainders_hi |= (new ushort16(1) & (dividendCast_lo >> 7));

            subtractDivisorFromRemainder = Avx2.mm256_andnot_si256(Avx2.mm256_cmpgt_epi16(divisorCast_lo, remainders_hi), new v256(-1));

            remainders_hi -= Avx2.mm256_blendv_epi8(default(v256), divisorCast_lo, subtractDivisorFromRemainder);
            quotients_hi |= new ushort16(1) & subtractDivisorFromRemainder;

            divrem_LOOPHEAD(6, ref quotients_hi, ref remainders_hi, in divisorCast_lo, in dividendCast_lo);
            divrem_LOOPHEAD(5, ref quotients_hi, ref remainders_hi, in divisorCast_lo, in dividendCast_lo);
            divrem_LOOPHEAD(4, ref quotients_hi, ref remainders_hi, in divisorCast_lo, in dividendCast_lo);
            divrem_LOOPHEAD(3, ref quotients_hi, ref remainders_hi, in divisorCast_lo, in dividendCast_lo);
            divrem_LOOPHEAD(2, ref quotients_hi, ref remainders_hi, in divisorCast_lo, in dividendCast_lo);
            divrem_LOOPHEAD(1, ref quotients_hi, ref remainders_hi, in divisorCast_lo, in dividendCast_lo);

            remainders_hi <<= 1;;
            quotients_hi <<= 1;

            remainders_hi |= new ushort16(1) & dividendCast_lo;

            subtractDivisorFromRemainder = Avx2.mm256_andnot_si256(Avx2.mm256_cmpgt_epi16(divisorCast_lo, remainders_hi), new v256(-1));

            remainders_hi -= Avx2.mm256_blendv_epi8(default(v256), divisorCast_lo, subtractDivisorFromRemainder);
            quotients_hi |= new ushort16(1) & subtractDivisorFromRemainder;


            remainder = Avx2.mm256_permute4x64_epi64(Avx2.mm256_packus_epi16(remainders_lo, remainders_hi), Sse.SHUFFLE(3, 1, 2, 0));
            return Avx2.mm256_permute4x64_epi64(Avx2.mm256_packus_epi16(quotients_lo, quotients_hi), Sse.SHUFFLE(3, 1, 2, 0));
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static byte32 vdiv_byte(byte32 dividend, byte32 divisor)
        {
Assert.AreNotEqual(divisor.x0, 0);
Assert.AreNotEqual(divisor.x1, 0);
Assert.AreNotEqual(divisor.x2, 0);
Assert.AreNotEqual(divisor.x3, 0);
Assert.AreNotEqual(divisor.x4, 0);
Assert.AreNotEqual(divisor.x5, 0);
Assert.AreNotEqual(divisor.x6, 0);
Assert.AreNotEqual(divisor.x7, 0);
Assert.AreNotEqual(divisor.x8, 0);
Assert.AreNotEqual(divisor.x9, 0);
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

            ushort16 quotients_lo = default(ushort16);
            ushort16 remainders_lo = default(ushort16);

            ushort16 divisorCast_lo = divisor.v16_0;
            ushort16 dividendCast_lo = dividend.v16_0;


            remainders_lo |= (new ushort16(1) & (dividendCast_lo >> 7));

            v256 subtractDivisorFromRemainder = Avx2.mm256_andnot_si256(Avx2.mm256_cmpgt_epi16(divisorCast_lo, remainders_lo), new v256(-1));

            remainders_lo -= Avx2.mm256_blendv_epi8(default(v256), divisorCast_lo, subtractDivisorFromRemainder);
            quotients_lo |= new ushort16(1) & subtractDivisorFromRemainder;

            divrem_LOOPHEAD(6, ref quotients_lo, ref remainders_lo, in divisorCast_lo, in dividendCast_lo);
            divrem_LOOPHEAD(5, ref quotients_lo, ref remainders_lo, in divisorCast_lo, in dividendCast_lo);
            divrem_LOOPHEAD(4, ref quotients_lo, ref remainders_lo, in divisorCast_lo, in dividendCast_lo);
            divrem_LOOPHEAD(3, ref quotients_lo, ref remainders_lo, in divisorCast_lo, in dividendCast_lo);
            divrem_LOOPHEAD(2, ref quotients_lo, ref remainders_lo, in divisorCast_lo, in dividendCast_lo);
            divrem_LOOPHEAD(1, ref quotients_lo, ref remainders_lo, in divisorCast_lo, in dividendCast_lo);

            remainders_lo <<= 1;;
            quotients_lo <<= 1;

            remainders_lo |= new ushort16(1) & dividendCast_lo;

            subtractDivisorFromRemainder = Avx2.mm256_andnot_si256(Avx2.mm256_cmpgt_epi16(divisorCast_lo, remainders_lo), new v256(-1));

            quotients_lo |= new ushort16(1) & subtractDivisorFromRemainder;


            ushort16 quotients_hi = default(ushort16);
            ushort16 remainders_hi = default(ushort16);

            divisorCast_lo = divisor.v16_16;
            dividendCast_lo = dividend.v16_16;


            remainders_hi |= (new ushort16(1) & (dividendCast_lo >> 7));

            subtractDivisorFromRemainder = Avx2.mm256_andnot_si256(Avx2.mm256_cmpgt_epi16(divisorCast_lo, remainders_hi), new v256(-1));

            remainders_hi -= Avx2.mm256_blendv_epi8(default(v256), divisorCast_lo, subtractDivisorFromRemainder);
            quotients_hi |= new ushort16(1) & subtractDivisorFromRemainder;

            divrem_LOOPHEAD(6, ref quotients_hi, ref remainders_hi, in divisorCast_lo, in dividendCast_lo);
            divrem_LOOPHEAD(5, ref quotients_hi, ref remainders_hi, in divisorCast_lo, in dividendCast_lo);
            divrem_LOOPHEAD(4, ref quotients_hi, ref remainders_hi, in divisorCast_lo, in dividendCast_lo);
            divrem_LOOPHEAD(3, ref quotients_hi, ref remainders_hi, in divisorCast_lo, in dividendCast_lo);
            divrem_LOOPHEAD(2, ref quotients_hi, ref remainders_hi, in divisorCast_lo, in dividendCast_lo);
            divrem_LOOPHEAD(1, ref quotients_hi, ref remainders_hi, in divisorCast_lo, in dividendCast_lo);

            remainders_hi <<= 1;;
            quotients_hi <<= 1;

            remainders_hi |= new ushort16(1) & dividendCast_lo;

            subtractDivisorFromRemainder = Avx2.mm256_andnot_si256(Avx2.mm256_cmpgt_epi16(divisorCast_lo, remainders_hi), new v256(-1));

            quotients_hi |= new ushort16(1) & subtractDivisorFromRemainder;


            return Avx2.mm256_permute4x64_epi64(Avx2.mm256_packus_epi16(quotients_lo, quotients_hi), Sse.SHUFFLE(3, 1, 2, 0));
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static byte32 vrem_byte(byte32 dividend, byte32 divisor)
        {
Assert.AreNotEqual(divisor.x0, 0);
Assert.AreNotEqual(divisor.x1, 0);
Assert.AreNotEqual(divisor.x2, 0);
Assert.AreNotEqual(divisor.x3, 0);
Assert.AreNotEqual(divisor.x4, 0);
Assert.AreNotEqual(divisor.x5, 0);
Assert.AreNotEqual(divisor.x6, 0);
Assert.AreNotEqual(divisor.x7, 0);
Assert.AreNotEqual(divisor.x8, 0);
Assert.AreNotEqual(divisor.x9, 0);
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

            ushort16 remainders_lo = default(ushort16);

            ushort16 divisorCast_lo = divisor.v16_0;
            ushort16 dividendCast_lo = dividend.v16_0;


            remainders_lo |= (new ushort16(1) & (dividendCast_lo >> 7));

            v256 subtractDivisorFromRemainder = Avx2.mm256_andnot_si256(Avx2.mm256_cmpgt_epi16(divisorCast_lo, remainders_lo), new v256(-1));

            remainders_lo -= Avx2.mm256_blendv_epi8(default(v256), divisorCast_lo, subtractDivisorFromRemainder);

            rem_LOOPHEAD(6, ref remainders_lo, in divisorCast_lo, in dividendCast_lo);
            rem_LOOPHEAD(5, ref remainders_lo, in divisorCast_lo, in dividendCast_lo);
            rem_LOOPHEAD(4, ref remainders_lo, in divisorCast_lo, in dividendCast_lo);
            rem_LOOPHEAD(3, ref remainders_lo, in divisorCast_lo, in dividendCast_lo);
            rem_LOOPHEAD(2, ref remainders_lo, in divisorCast_lo, in dividendCast_lo);
            rem_LOOPHEAD(1, ref remainders_lo, in divisorCast_lo, in dividendCast_lo);

            remainders_lo <<= 1;;

            remainders_lo |= new ushort16(1) & dividendCast_lo;

            subtractDivisorFromRemainder = Avx2.mm256_andnot_si256(Avx2.mm256_cmpgt_epi16(divisorCast_lo, remainders_lo), new v256(-1));

            remainders_lo -= Avx2.mm256_blendv_epi8(default(v256), divisorCast_lo, subtractDivisorFromRemainder);


            ushort16 remainders_hi = default(ushort16);

            divisorCast_lo = divisor.v16_16;
            dividendCast_lo = dividend.v16_16;


            remainders_hi |= (new ushort16(1) & (dividendCast_lo >> 7));

            subtractDivisorFromRemainder = Avx2.mm256_andnot_si256(Avx2.mm256_cmpgt_epi16(divisorCast_lo, remainders_hi), new v256(-1));

            remainders_hi -= Avx2.mm256_blendv_epi8(default(v256), divisorCast_lo, subtractDivisorFromRemainder);

            rem_LOOPHEAD(6, ref remainders_hi, in divisorCast_lo, in dividendCast_lo);
            rem_LOOPHEAD(5, ref remainders_hi, in divisorCast_lo, in dividendCast_lo);
            rem_LOOPHEAD(4, ref remainders_hi, in divisorCast_lo, in dividendCast_lo);
            rem_LOOPHEAD(3, ref remainders_hi, in divisorCast_lo, in dividendCast_lo);
            rem_LOOPHEAD(2, ref remainders_hi, in divisorCast_lo, in dividendCast_lo);
            rem_LOOPHEAD(1, ref remainders_hi, in divisorCast_lo, in dividendCast_lo);

            remainders_hi <<= 1;;

            remainders_hi |= new ushort16(1) & dividendCast_lo;

            subtractDivisorFromRemainder = Avx2.mm256_andnot_si256(Avx2.mm256_cmpgt_epi16(divisorCast_lo, remainders_hi), new v256(-1));

            remainders_hi -= Avx2.mm256_blendv_epi8(default(v256), divisorCast_lo, subtractDivisorFromRemainder);


            return Avx2.mm256_permute4x64_epi64(Avx2.mm256_packus_epi16(remainders_lo, remainders_hi), Sse.SHUFFLE(3, 1, 2, 0));
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
Assert.AreNotEqual(divisor.x0, 0);
Assert.AreNotEqual(divisor.x1, 0);
Assert.AreNotEqual(divisor.x2, 0);
Assert.AreNotEqual(divisor.x3, 0);
Assert.AreNotEqual(divisor.x4, 0);
Assert.AreNotEqual(divisor.x5, 0);
Assert.AreNotEqual(divisor.x6, 0);
Assert.AreNotEqual(divisor.x7, 0);
Assert.AreNotEqual(divisor.x8, 0);
Assert.AreNotEqual(divisor.x9, 0);
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

            divrem_LOOPHEAD(6, ref quotients, ref remainders, in divisorCast, in dividendCast);
            divrem_LOOPHEAD(5, ref quotients, ref remainders, in divisorCast, in dividendCast);
            divrem_LOOPHEAD(4, ref quotients, ref remainders, in divisorCast, in dividendCast);
            divrem_LOOPHEAD(3, ref quotients, ref remainders, in divisorCast, in dividendCast);
            divrem_LOOPHEAD(2, ref quotients, ref remainders, in divisorCast, in dividendCast);
            divrem_LOOPHEAD(1, ref quotients, ref remainders, in divisorCast, in dividendCast);

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
Assert.AreNotEqual(divisor.x0, 0);
Assert.AreNotEqual(divisor.x1, 0);
Assert.AreNotEqual(divisor.x2, 0);
Assert.AreNotEqual(divisor.x3, 0);
Assert.AreNotEqual(divisor.x4, 0);
Assert.AreNotEqual(divisor.x5, 0);
Assert.AreNotEqual(divisor.x6, 0);
Assert.AreNotEqual(divisor.x7, 0);
Assert.AreNotEqual(divisor.x8, 0);
Assert.AreNotEqual(divisor.x9, 0);
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

            divrem_LOOPHEAD(6, ref quotients, ref remainders, in divisorCast, in dividendCast);
            divrem_LOOPHEAD(5, ref quotients, ref remainders, in divisorCast, in dividendCast);
            divrem_LOOPHEAD(4, ref quotients, ref remainders, in divisorCast, in dividendCast);
            divrem_LOOPHEAD(3, ref quotients, ref remainders, in divisorCast, in dividendCast);
            divrem_LOOPHEAD(2, ref quotients, ref remainders, in divisorCast, in dividendCast);
            divrem_LOOPHEAD(1, ref quotients, ref remainders, in divisorCast, in dividendCast);

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
Assert.AreNotEqual(divisor.x0, 0);
Assert.AreNotEqual(divisor.x1, 0);
Assert.AreNotEqual(divisor.x2, 0);
Assert.AreNotEqual(divisor.x3, 0);
Assert.AreNotEqual(divisor.x4, 0);
Assert.AreNotEqual(divisor.x5, 0);
Assert.AreNotEqual(divisor.x6, 0);
Assert.AreNotEqual(divisor.x7, 0);
Assert.AreNotEqual(divisor.x8, 0);
Assert.AreNotEqual(divisor.x9, 0);
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

            rem_LOOPHEAD(6, ref remainders, in divisorCast, in dividendCast);
            rem_LOOPHEAD(5, ref remainders, in divisorCast, in dividendCast);
            rem_LOOPHEAD(4, ref remainders, in divisorCast, in dividendCast);
            rem_LOOPHEAD(3, ref remainders, in divisorCast, in dividendCast);
            rem_LOOPHEAD(2, ref remainders, in divisorCast, in dividendCast);
            rem_LOOPHEAD(1, ref remainders, in divisorCast, in dividendCast);

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
        private static void divrem_LOOPHEAD(int i, ref ushort16 quotients, ref ushort16 remainders, in ushort16 divisorCast, in ushort16 dividendCast)
        {
            quotients <<= 1;
            remainders <<= 1;

            remainders |= (new ushort16(1) & (dividendCast >> i));

            v256 subtractDivisorFromRemainder = Avx2.mm256_andnot_si256(Avx2.mm256_cmpgt_epi16(divisorCast, remainders), new v256(-1));

            remainders -= Avx2.mm256_blendv_epi8(default(v256), divisorCast, subtractDivisorFromRemainder);
            quotients |= new ushort16(1) & subtractDivisorFromRemainder;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void rem_LOOPHEAD(int i, ref ushort16 remainders, in ushort16 divisorCast, in ushort16 dividendCast)
        {
            remainders <<= 1;

            remainders |= (new ushort16(1) & (dividendCast >> i));

            v256 subtractDivisorFromRemainder = Avx2.mm256_andnot_si256(Avx2.mm256_cmpgt_epi16(divisorCast, remainders), new v256(-1));

            remainders -= Avx2.mm256_blendv_epi8(default(v256), divisorCast, subtractDivisorFromRemainder);
        }
    }
}