using DevTools;
using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

namespace MaxMath
{
    internal static class Operator
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static byte32 divrem_byte(byte32 dividend, byte32 divisor, out byte32 remainder)
        {
Assert.AreNotEqual<byte>(divisor.x0, 0);
Assert.AreNotEqual<byte>(divisor.x1, 0);
Assert.AreNotEqual<byte>(divisor.x2, 0);
Assert.AreNotEqual<byte>(divisor.x3, 0);
Assert.AreNotEqual<byte>(divisor.x4, 0);
Assert.AreNotEqual<byte>(divisor.x5, 0);
Assert.AreNotEqual<byte>(divisor.x6, 0);
Assert.AreNotEqual<byte>(divisor.x7, 0);
Assert.AreNotEqual<byte>(divisor.x8, 0);
Assert.AreNotEqual<byte>(divisor.x9, 0);
Assert.AreNotEqual<byte>(divisor.x10, 0);
Assert.AreNotEqual<byte>(divisor.x11, 0);
Assert.AreNotEqual<byte>(divisor.x12, 0);
Assert.AreNotEqual<byte>(divisor.x13, 0);
Assert.AreNotEqual<byte>(divisor.x14, 0);
Assert.AreNotEqual<byte>(divisor.x15, 0);
Assert.AreNotEqual<byte>(divisor.x16, 0);
Assert.AreNotEqual<byte>(divisor.x17, 0);
Assert.AreNotEqual<byte>(divisor.x18, 0);
Assert.AreNotEqual<byte>(divisor.x19, 0);
Assert.AreNotEqual<byte>(divisor.x20, 0);
Assert.AreNotEqual<byte>(divisor.x21, 0);
Assert.AreNotEqual<byte>(divisor.x22, 0);
Assert.AreNotEqual<byte>(divisor.x23, 0);
Assert.AreNotEqual<byte>(divisor.x24, 0);
Assert.AreNotEqual<byte>(divisor.x25, 0);
Assert.AreNotEqual<byte>(divisor.x26, 0);
Assert.AreNotEqual<byte>(divisor.x27, 0);
Assert.AreNotEqual<byte>(divisor.x28, 0);
Assert.AreNotEqual<byte>(divisor.x29, 0);
Assert.AreNotEqual<byte>(divisor.x30, 0);
Assert.AreNotEqual<byte>(divisor.x31, 0);

            ushort16 quotients_lo = default(ushort16);
            ushort16 remainders_lo = default(ushort16);

            ushort16 divisorCast_lo = divisor.v16_0;
            ushort16 dividendCast_lo = dividend.v16_0;


            remainders_lo |= (new ushort16(1) & (dividendCast_lo >> 7));

            v256 subtractDivisorFromRemainder = X86.Avx2.mm256_andnot_si256(X86.Avx2.mm256_cmpgt_epi16(divisorCast_lo, remainders_lo), new v256(-1));

            remainders_lo -= X86.Avx2.mm256_blendv_epi8(new v256(0), divisorCast_lo, subtractDivisorFromRemainder);
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

            subtractDivisorFromRemainder = X86.Avx2.mm256_andnot_si256(X86.Avx2.mm256_cmpgt_epi16(divisorCast_lo, remainders_lo), new v256(-1));

            remainders_lo -= X86.Avx2.mm256_blendv_epi8(new v256(0), divisorCast_lo, subtractDivisorFromRemainder);
            quotients_lo |= new ushort16(1) & subtractDivisorFromRemainder;


            ushort16 quotients_hi = default(ushort16);
            ushort16 remainders_hi = default(ushort16);

            divisorCast_lo = divisor.v16_16;
            dividendCast_lo = dividend.v16_16;


            remainders_hi |= (new ushort16(1) & (dividendCast_lo >> 7));

            subtractDivisorFromRemainder = X86.Avx2.mm256_andnot_si256(X86.Avx2.mm256_cmpgt_epi16(divisorCast_lo, remainders_hi), new v256(-1));

            remainders_hi -= X86.Avx2.mm256_blendv_epi8(new v256(0), divisorCast_lo, subtractDivisorFromRemainder);
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

            subtractDivisorFromRemainder = X86.Avx2.mm256_andnot_si256(X86.Avx2.mm256_cmpgt_epi16(divisorCast_lo, remainders_hi), new v256(-1));

            remainders_hi -= X86.Avx2.mm256_blendv_epi8(new v256(0), divisorCast_lo, subtractDivisorFromRemainder);
            quotients_hi |= new ushort16(1) & subtractDivisorFromRemainder;


            remainder = X86.Avx2.mm256_permute4x64_epi64(X86.Avx2.mm256_packus_epi16(remainders_lo, remainders_hi), X86.Sse.SHUFFLE(3, 1, 2, 0));
            return X86.Avx2.mm256_permute4x64_epi64(X86.Avx2.mm256_packus_epi16(quotients_lo, quotients_hi), X86.Sse.SHUFFLE(3, 1, 2, 0));
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static byte32 div_byte(byte32 dividend, byte32 divisor)
        {
Assert.AreNotEqual<byte>(divisor.x0, 0);
Assert.AreNotEqual<byte>(divisor.x1, 0);
Assert.AreNotEqual<byte>(divisor.x2, 0);
Assert.AreNotEqual<byte>(divisor.x3, 0);
Assert.AreNotEqual<byte>(divisor.x4, 0);
Assert.AreNotEqual<byte>(divisor.x5, 0);
Assert.AreNotEqual<byte>(divisor.x6, 0);
Assert.AreNotEqual<byte>(divisor.x7, 0);
Assert.AreNotEqual<byte>(divisor.x8, 0);
Assert.AreNotEqual<byte>(divisor.x9, 0);
Assert.AreNotEqual<byte>(divisor.x10, 0);
Assert.AreNotEqual<byte>(divisor.x11, 0);
Assert.AreNotEqual<byte>(divisor.x12, 0);
Assert.AreNotEqual<byte>(divisor.x13, 0);
Assert.AreNotEqual<byte>(divisor.x14, 0);
Assert.AreNotEqual<byte>(divisor.x15, 0);
Assert.AreNotEqual<byte>(divisor.x16, 0);
Assert.AreNotEqual<byte>(divisor.x17, 0);
Assert.AreNotEqual<byte>(divisor.x18, 0);
Assert.AreNotEqual<byte>(divisor.x19, 0);
Assert.AreNotEqual<byte>(divisor.x20, 0);
Assert.AreNotEqual<byte>(divisor.x21, 0);
Assert.AreNotEqual<byte>(divisor.x22, 0);
Assert.AreNotEqual<byte>(divisor.x23, 0);
Assert.AreNotEqual<byte>(divisor.x24, 0);
Assert.AreNotEqual<byte>(divisor.x25, 0);
Assert.AreNotEqual<byte>(divisor.x26, 0);
Assert.AreNotEqual<byte>(divisor.x27, 0);
Assert.AreNotEqual<byte>(divisor.x28, 0);
Assert.AreNotEqual<byte>(divisor.x29, 0);
Assert.AreNotEqual<byte>(divisor.x30, 0);
Assert.AreNotEqual<byte>(divisor.x31, 0);

            ushort16 quotients_lo = default(ushort16);
            ushort16 remainders_lo = default(ushort16);

            ushort16 divisorCast_lo = divisor.v16_0;
            ushort16 dividendCast_lo = dividend.v16_0;


            remainders_lo |= (new ushort16(1) & (dividendCast_lo >> 7));

            v256 subtractDivisorFromRemainder = X86.Avx2.mm256_andnot_si256(X86.Avx2.mm256_cmpgt_epi16(divisorCast_lo, remainders_lo), new v256(-1));

            remainders_lo -= X86.Avx2.mm256_blendv_epi8(new v256(0), divisorCast_lo, subtractDivisorFromRemainder);
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

            subtractDivisorFromRemainder = X86.Avx2.mm256_andnot_si256(X86.Avx2.mm256_cmpgt_epi16(divisorCast_lo, remainders_lo), new v256(-1));

            quotients_lo |= new ushort16(1) & subtractDivisorFromRemainder;


            ushort16 quotients_hi = default(ushort16);
            ushort16 remainders_hi = default(ushort16);

            divisorCast_lo = divisor.v16_16;
            dividendCast_lo = dividend.v16_16;


            remainders_hi |= (new ushort16(1) & (dividendCast_lo >> 7));

            subtractDivisorFromRemainder = X86.Avx2.mm256_andnot_si256(X86.Avx2.mm256_cmpgt_epi16(divisorCast_lo, remainders_hi), new v256(-1));

            remainders_hi -= X86.Avx2.mm256_blendv_epi8(new v256(0), divisorCast_lo, subtractDivisorFromRemainder);
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

            subtractDivisorFromRemainder = X86.Avx2.mm256_andnot_si256(X86.Avx2.mm256_cmpgt_epi16(divisorCast_lo, remainders_hi), new v256(-1));

            quotients_hi |= new ushort16(1) & subtractDivisorFromRemainder;


            return X86.Avx2.mm256_permute4x64_epi64(X86.Avx2.mm256_packus_epi16(quotients_lo, quotients_hi), X86.Sse.SHUFFLE(3, 1, 2, 0));
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static byte32 rem_byte(byte32 dividend, byte32 divisor)
        {
Assert.AreNotEqual<byte>(divisor.x0, 0);
Assert.AreNotEqual<byte>(divisor.x1, 0);
Assert.AreNotEqual<byte>(divisor.x2, 0);
Assert.AreNotEqual<byte>(divisor.x3, 0);
Assert.AreNotEqual<byte>(divisor.x4, 0);
Assert.AreNotEqual<byte>(divisor.x5, 0);
Assert.AreNotEqual<byte>(divisor.x6, 0);
Assert.AreNotEqual<byte>(divisor.x7, 0);
Assert.AreNotEqual<byte>(divisor.x8, 0);
Assert.AreNotEqual<byte>(divisor.x9, 0);
Assert.AreNotEqual<byte>(divisor.x10, 0);
Assert.AreNotEqual<byte>(divisor.x11, 0);
Assert.AreNotEqual<byte>(divisor.x12, 0);
Assert.AreNotEqual<byte>(divisor.x13, 0);
Assert.AreNotEqual<byte>(divisor.x14, 0);
Assert.AreNotEqual<byte>(divisor.x15, 0);
Assert.AreNotEqual<byte>(divisor.x16, 0);
Assert.AreNotEqual<byte>(divisor.x17, 0);
Assert.AreNotEqual<byte>(divisor.x18, 0);
Assert.AreNotEqual<byte>(divisor.x19, 0);
Assert.AreNotEqual<byte>(divisor.x20, 0);
Assert.AreNotEqual<byte>(divisor.x21, 0);
Assert.AreNotEqual<byte>(divisor.x22, 0);
Assert.AreNotEqual<byte>(divisor.x23, 0);
Assert.AreNotEqual<byte>(divisor.x24, 0);
Assert.AreNotEqual<byte>(divisor.x25, 0);
Assert.AreNotEqual<byte>(divisor.x26, 0);
Assert.AreNotEqual<byte>(divisor.x27, 0);
Assert.AreNotEqual<byte>(divisor.x28, 0);
Assert.AreNotEqual<byte>(divisor.x29, 0);
Assert.AreNotEqual<byte>(divisor.x30, 0);
Assert.AreNotEqual<byte>(divisor.x31, 0);

            ushort16 remainders_lo = default(ushort16);

            ushort16 divisorCast_lo = divisor.v16_0;
            ushort16 dividendCast_lo = dividend.v16_0;


            remainders_lo |= (new ushort16(1) & (dividendCast_lo >> 7));

            v256 subtractDivisorFromRemainder = X86.Avx2.mm256_andnot_si256(X86.Avx2.mm256_cmpgt_epi16(divisorCast_lo, remainders_lo), new v256(-1));

            remainders_lo -= X86.Avx2.mm256_blendv_epi8(new v256(0), divisorCast_lo, subtractDivisorFromRemainder);

            rem_LOOPHEAD(6, ref remainders_lo, in divisorCast_lo, in dividendCast_lo);
            rem_LOOPHEAD(5, ref remainders_lo, in divisorCast_lo, in dividendCast_lo);
            rem_LOOPHEAD(4, ref remainders_lo, in divisorCast_lo, in dividendCast_lo);
            rem_LOOPHEAD(3, ref remainders_lo, in divisorCast_lo, in dividendCast_lo);
            rem_LOOPHEAD(2, ref remainders_lo, in divisorCast_lo, in dividendCast_lo);
            rem_LOOPHEAD(1, ref remainders_lo, in divisorCast_lo, in dividendCast_lo);

            remainders_lo <<= 1;;

            remainders_lo |= new ushort16(1) & dividendCast_lo;

            subtractDivisorFromRemainder = X86.Avx2.mm256_andnot_si256(X86.Avx2.mm256_cmpgt_epi16(divisorCast_lo, remainders_lo), new v256(-1));

            remainders_lo -= X86.Avx2.mm256_blendv_epi8(new v256(0), divisorCast_lo, subtractDivisorFromRemainder);


            ushort16 remainders_hi = default(ushort16);

            divisorCast_lo = divisor.v16_16;
            dividendCast_lo = dividend.v16_16;


            remainders_hi |= (new ushort16(1) & (dividendCast_lo >> 7));

            subtractDivisorFromRemainder = X86.Avx2.mm256_andnot_si256(X86.Avx2.mm256_cmpgt_epi16(divisorCast_lo, remainders_hi), new v256(-1));

            remainders_hi -= X86.Avx2.mm256_blendv_epi8(new v256(0), divisorCast_lo, subtractDivisorFromRemainder);

            rem_LOOPHEAD(6, ref remainders_hi, in divisorCast_lo, in dividendCast_lo);
            rem_LOOPHEAD(5, ref remainders_hi, in divisorCast_lo, in dividendCast_lo);
            rem_LOOPHEAD(4, ref remainders_hi, in divisorCast_lo, in dividendCast_lo);
            rem_LOOPHEAD(3, ref remainders_hi, in divisorCast_lo, in dividendCast_lo);
            rem_LOOPHEAD(2, ref remainders_hi, in divisorCast_lo, in dividendCast_lo);
            rem_LOOPHEAD(1, ref remainders_hi, in divisorCast_lo, in dividendCast_lo);

            remainders_hi <<= 1;;

            remainders_hi |= new ushort16(1) & dividendCast_lo;

            subtractDivisorFromRemainder = X86.Avx2.mm256_andnot_si256(X86.Avx2.mm256_cmpgt_epi16(divisorCast_lo, remainders_hi), new v256(-1));

            remainders_hi -= X86.Avx2.mm256_blendv_epi8(new v256(0), divisorCast_lo, subtractDivisorFromRemainder);


            return X86.Avx2.mm256_permute4x64_epi64(X86.Avx2.mm256_packus_epi16(remainders_lo, remainders_hi), X86.Sse.SHUFFLE(3, 1, 2, 0));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static sbyte32 divrem_byte(sbyte32 dividend, sbyte32 divisor, out sbyte32 remainder)
        {
            byte32 quotient = divrem_byte((byte32)maxmath.abs(dividend), (byte32)maxmath.abs(divisor), out byte32 remainders);

            byte32 mustNegate = X86.Avx2.mm256_cmpgt_epi8(default(sbyte32), dividend);

            remainder = X86.Avx2.mm256_blendv_epi8(remainders, -((sbyte32)remainders), mustNegate);

            mustNegate = X86.Avx2.mm256_xor_si256(X86.Avx2.mm256_cmpgt_epi8(default(sbyte32), divisor),
                                                  X86.Avx2.mm256_cmpgt_epi8(default(sbyte32), dividend));

            return X86.Avx2.mm256_blendv_epi8(quotient, -((sbyte32)quotient), mustNegate);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static sbyte32 div_byte(sbyte32 dividend, sbyte32 divisor)
        {
            byte32 quotient = div_byte((byte32)maxmath.abs(dividend), (byte32)maxmath.abs(divisor));

            byte32 mustNegate = X86.Avx2.mm256_xor_si256(X86.Avx2.mm256_cmpgt_epi8(default(sbyte32), divisor),
                                                         X86.Avx2.mm256_cmpgt_epi8(default(sbyte32), dividend));

            return X86.Avx2.mm256_blendv_epi8(quotient, -((sbyte32)quotient), mustNegate);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static sbyte32 rem_byte(sbyte32 dividend, sbyte32 divisor)
        {
            byte32 remainder = rem_byte((byte32)maxmath.abs(dividend), (byte32)maxmath.abs(divisor));

            byte32 mustNegate = X86.Avx2.mm256_cmpgt_epi8(default(sbyte32), dividend);

            return X86.Avx2.mm256_blendv_epi8(remainder, -((sbyte32)remainder), mustNegate);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static byte16 divrem_byte(byte16 dividend, byte16 divisor, out byte16 remainder)
        {
Assert.AreNotEqual<byte>(divisor.x0, 0);
Assert.AreNotEqual<byte>(divisor.x1, 0);
Assert.AreNotEqual<byte>(divisor.x2, 0);
Assert.AreNotEqual<byte>(divisor.x3, 0);
Assert.AreNotEqual<byte>(divisor.x4, 0);
Assert.AreNotEqual<byte>(divisor.x5, 0);
Assert.AreNotEqual<byte>(divisor.x6, 0);
Assert.AreNotEqual<byte>(divisor.x7, 0);
Assert.AreNotEqual<byte>(divisor.x8, 0);
Assert.AreNotEqual<byte>(divisor.x9, 0);
Assert.AreNotEqual<byte>(divisor.x10, 0);
Assert.AreNotEqual<byte>(divisor.x11, 0);
Assert.AreNotEqual<byte>(divisor.x12, 0);
Assert.AreNotEqual<byte>(divisor.x13, 0);
Assert.AreNotEqual<byte>(divisor.x14, 0);
Assert.AreNotEqual<byte>(divisor.x15, 0);

            ushort16 quotients = default(ushort16);
            ushort16 remainders = default(ushort16);

            ushort16 divisorCast = divisor;
            ushort16 dividendCast = dividend;


            remainders |= (new ushort16(1) & (dividendCast >> 7));

            v256 subtractDivisorFromRemainder = X86.Avx2.mm256_andnot_si256(X86.Avx2.mm256_cmpgt_epi16(divisorCast, remainders), new v256(-1));

            remainders -= X86.Avx2.mm256_blendv_epi8(new v256(0), divisorCast, subtractDivisorFromRemainder);
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

            subtractDivisorFromRemainder = X86.Avx2.mm256_andnot_si256(X86.Avx2.mm256_cmpgt_epi16(divisorCast, remainders), new v256(-1));

            remainders -= X86.Avx2.mm256_blendv_epi8(new v256(0), divisorCast, subtractDivisorFromRemainder);
            quotients |= new ushort16(1) & subtractDivisorFromRemainder;


            remainder = X86.Sse2.packus_epi16(X86.Avx.mm256_castsi256_si128(remainders), X86.Avx2.mm256_extracti128_si256(remainders, 1));
            return X86.Sse2.packus_epi16(X86.Avx.mm256_castsi256_si128(quotients), X86.Avx2.mm256_extracti128_si256(quotients, 1));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static byte16 div_byte(byte16 dividend, byte16 divisor)
        {
Assert.AreNotEqual<byte>(divisor.x0, 0);
Assert.AreNotEqual<byte>(divisor.x1, 0);
Assert.AreNotEqual<byte>(divisor.x2, 0);
Assert.AreNotEqual<byte>(divisor.x3, 0);
Assert.AreNotEqual<byte>(divisor.x4, 0);
Assert.AreNotEqual<byte>(divisor.x5, 0);
Assert.AreNotEqual<byte>(divisor.x6, 0);
Assert.AreNotEqual<byte>(divisor.x7, 0);
Assert.AreNotEqual<byte>(divisor.x8, 0);
Assert.AreNotEqual<byte>(divisor.x9, 0);
Assert.AreNotEqual<byte>(divisor.x10, 0);
Assert.AreNotEqual<byte>(divisor.x11, 0);
Assert.AreNotEqual<byte>(divisor.x12, 0);
Assert.AreNotEqual<byte>(divisor.x13, 0);
Assert.AreNotEqual<byte>(divisor.x14, 0);
Assert.AreNotEqual<byte>(divisor.x15, 0);

            ushort16 quotients = default(ushort16);
            ushort16 remainders = default(ushort16);

            ushort16 divisorCast = divisor;
            ushort16 dividendCast = dividend;


            remainders |= (new ushort16(1) & (dividendCast >> 7));

            v256 subtractDivisorFromRemainder = X86.Avx2.mm256_andnot_si256(X86.Avx2.mm256_cmpgt_epi16(divisorCast, remainders), new v256(-1));

            remainders -= X86.Avx2.mm256_blendv_epi8(new v256(0), divisorCast, subtractDivisorFromRemainder);
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

            subtractDivisorFromRemainder = X86.Avx2.mm256_andnot_si256(X86.Avx2.mm256_cmpgt_epi16(divisorCast, remainders), new v256(-1));

            quotients |= new ushort16(1) & subtractDivisorFromRemainder;


            return X86.Sse2.packus_epi16(X86.Avx.mm256_castsi256_si128(quotients), X86.Avx2.mm256_extracti128_si256(quotients, 1));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static byte16 rem_byte(byte16 dividend, byte16 divisor)
        {
Assert.AreNotEqual<byte>(divisor.x0, 0);
Assert.AreNotEqual<byte>(divisor.x1, 0);
Assert.AreNotEqual<byte>(divisor.x2, 0);
Assert.AreNotEqual<byte>(divisor.x3, 0);
Assert.AreNotEqual<byte>(divisor.x4, 0);
Assert.AreNotEqual<byte>(divisor.x5, 0);
Assert.AreNotEqual<byte>(divisor.x6, 0);
Assert.AreNotEqual<byte>(divisor.x7, 0);
Assert.AreNotEqual<byte>(divisor.x8, 0);
Assert.AreNotEqual<byte>(divisor.x9, 0);
Assert.AreNotEqual<byte>(divisor.x10, 0);
Assert.AreNotEqual<byte>(divisor.x11, 0);
Assert.AreNotEqual<byte>(divisor.x12, 0);
Assert.AreNotEqual<byte>(divisor.x13, 0);
Assert.AreNotEqual<byte>(divisor.x14, 0);
Assert.AreNotEqual<byte>(divisor.x15, 0);

            ushort16 remainders = default(ushort16);

            ushort16 divisorCast = divisor;
            ushort16 dividendCast = dividend;


            remainders |= (new ushort16(1) & (dividendCast >> 7));

            v256 subtractDivisorFromRemainder = X86.Avx2.mm256_andnot_si256(X86.Avx2.mm256_cmpgt_epi16(divisorCast, remainders), new v256(-1));

            remainders -= X86.Avx2.mm256_blendv_epi8(new v256(0), divisorCast, subtractDivisorFromRemainder);

            rem_LOOPHEAD(6, ref remainders, in divisorCast, in dividendCast);
            rem_LOOPHEAD(5, ref remainders, in divisorCast, in dividendCast);
            rem_LOOPHEAD(4, ref remainders, in divisorCast, in dividendCast);
            rem_LOOPHEAD(3, ref remainders, in divisorCast, in dividendCast);
            rem_LOOPHEAD(2, ref remainders, in divisorCast, in dividendCast);
            rem_LOOPHEAD(1, ref remainders, in divisorCast, in dividendCast);

            remainders <<= 1;

            remainders |= new ushort16(1) & dividendCast;

            subtractDivisorFromRemainder = X86.Avx2.mm256_andnot_si256(X86.Avx2.mm256_cmpgt_epi16(divisorCast, remainders), new v256(-1));

            remainders -= X86.Avx2.mm256_blendv_epi8(new v256(0), divisorCast, subtractDivisorFromRemainder);


            return X86.Sse2.packus_epi16(X86.Avx.mm256_castsi256_si128(remainders), X86.Avx2.mm256_extracti128_si256(remainders, 1));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static sbyte16 divrem_byte(sbyte16 dividend, sbyte16 divisor, out sbyte16 remainder)
        {
            byte16 quotient = divrem_byte((byte16)maxmath.abs(dividend), (byte16)maxmath.abs(divisor), out byte16 remainders);

            byte16 mustNegate = X86.Sse2.cmpgt_epi8(default(sbyte16), dividend);

            remainder = X86.Sse4_1.blendv_epi8(remainders, -((sbyte16)remainders), mustNegate);

            mustNegate = X86.Sse2.xor_si128(X86.Sse2.cmpgt_epi8(default(sbyte16), divisor),
                                            X86.Sse2.cmpgt_epi8(default(sbyte16), dividend));

            return X86.Sse4_1.blendv_epi8(quotient, -((sbyte16)quotient), mustNegate);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static sbyte16 div_byte(sbyte16 dividend, sbyte16 divisor)
        {
            byte16 quotient = div_byte((byte16)maxmath.abs(dividend), (byte16)maxmath.abs(divisor));

            byte16 mustNegate = X86.Sse2.xor_si128(X86.Sse2.cmpgt_epi8(default(sbyte16), divisor),
                                                   X86.Sse2.cmpgt_epi8(default(sbyte16), dividend));

            return X86.Sse4_1.blendv_epi8(quotient, -((sbyte16)quotient), mustNegate);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static sbyte16 rem_byte(sbyte16 dividend, sbyte16 divisor)
        {
            byte16 remainder = rem_byte((byte16)maxmath.abs(dividend), (byte16)maxmath.abs(divisor));

            byte16 mustNegate = X86.Sse2.cmpgt_epi8(default(sbyte16), dividend);

            return X86.Sse4_1.blendv_epi8(remainder, -((sbyte16)remainder), mustNegate);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void divrem_LOOPHEAD(int i, ref ushort16 quotients, ref ushort16 remainders, in ushort16 divisorCast, in ushort16 dividendCast)
        {
            quotients <<= 1;
            remainders <<= 1;


            remainders |= (new ushort16(1) & (dividendCast >> i));


            v256 subtractDivisorFromRemainder = X86.Avx2.mm256_andnot_si256(X86.Avx2.mm256_cmpgt_epi16(divisorCast, remainders), new v256(-1));


            remainders -= X86.Avx2.mm256_blendv_epi8(new v256(0), divisorCast, subtractDivisorFromRemainder);
            quotients |= new ushort16(1) & subtractDivisorFromRemainder;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void rem_LOOPHEAD(int i, ref ushort16 remainders, in ushort16 divisorCast, in ushort16 dividendCast)
        {
            remainders <<= 1;

            remainders |= (new ushort16(1) & (dividendCast >> i));

            v256 subtractDivisorFromRemainder = X86.Avx2.mm256_andnot_si256(X86.Avx2.mm256_cmpgt_epi16(divisorCast, remainders), new v256(-1));

            remainders -= X86.Avx2.mm256_blendv_epi8(new v256(0), divisorCast, subtractDivisorFromRemainder);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 shl_byte(v128 v, int n)
        {
            switch(n)
            {
                case 0:  return v;

                case 1:  return new byte16(0b1111_1110) & X86.Sse2.slli_epi16(v, 1);
                case 2:  return new byte16(0b1111_1100) & X86.Sse2.slli_epi16(v, 2);
                case 3:  return new byte16(0b1111_1000) & X86.Sse2.slli_epi16(v, 3);
                case 4:  return new byte16(0b1111_0000) & X86.Sse2.slli_epi16(v, 4);
                case 5:  return new byte16(0b1110_0000) & X86.Sse2.slli_epi16(v, 5);
                case 6:  return new byte16(0b1100_0000) & X86.Sse2.slli_epi16(v, 6);
                case 7:  return new byte16(0b1000_0000) & X86.Sse2.slli_epi16(v, 7);

                default: return  X86.Sse2.setzero_si128();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 shl_byte(v256 v, int n)
        {
            switch (n)
            {
                case 0: return v;

                case 1: return new byte32(0b1111_1110) & X86.Avx2.mm256_slli_epi16(v, 1);
                case 2: return new byte32(0b1111_1100) & X86.Avx2.mm256_slli_epi16(v, 2);
                case 3: return new byte32(0b1111_1000) & X86.Avx2.mm256_slli_epi16(v, 3);
                case 4: return new byte32(0b1111_0000) & X86.Avx2.mm256_slli_epi16(v, 4);
                case 5: return new byte32(0b1110_0000) & X86.Avx2.mm256_slli_epi16(v, 5);
                case 6: return new byte32(0b1100_0000) & X86.Avx2.mm256_slli_epi16(v, 6);
                case 7: return new byte32(0b1000_0000) & X86.Avx2.mm256_slli_epi16(v, 7);
                                    
                default: return X86.Avx.mm256_setzero_si256();
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 shrl_byte(v128 v, int n)
        {
            switch (n)
            {
                case 0:  return v;

                case 1:  return new byte16(0b0111_1111) & X86.Sse2.srli_epi16(v, 1);
                case 2:  return new byte16(0b0011_1111) & X86.Sse2.srli_epi16(v, 2);
                case 3:  return new byte16(0b0001_1111) & X86.Sse2.srli_epi16(v, 3);
                case 4:  return new byte16(0b0000_1111) & X86.Sse2.srli_epi16(v, 4);
                case 5:  return new byte16(0b0000_0111) & X86.Sse2.srli_epi16(v, 5);
                case 6:  return new byte16(0b0000_0011) & X86.Sse2.srli_epi16(v, 6);
                case 7:  return new byte16(0b0000_0001) & X86.Sse2.srli_epi16(v, 7);

                default: return X86.Sse2.setzero_si128();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 shrl_byte(v256 v, int n)
        {
            switch (n)
            {
                case 0: return v;

                case 1: return new byte32(0b0111_1111) & X86.Avx2.mm256_srli_epi16(v, 1);
                case 2: return new byte32(0b0011_1111) & X86.Avx2.mm256_srli_epi16(v, 2);
                case 3: return new byte32(0b0001_1111) & X86.Avx2.mm256_srli_epi16(v, 3);
                case 4: return new byte32(0b0000_1111) & X86.Avx2.mm256_srli_epi16(v, 4);
                case 5: return new byte32(0b0000_0111) & X86.Avx2.mm256_srli_epi16(v, 5);
                case 6: return new byte32(0b0000_0011) & X86.Avx2.mm256_srli_epi16(v, 6);
                case 7: return new byte32(0b0000_0001) & X86.Avx2.mm256_srli_epi16(v, 7);

                default: return X86.Avx.mm256_setzero_si256();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 shra_byte(v256 v, int n)
        {
            switch (n)
            {
                case 0: return v;

                case 1: return (new byte32(0b0111_1111) & X86.Avx2.mm256_srai_epi16(v, 1)) | X86.Avx2.mm256_blendv_epi8(default(v256), new byte32(0b1000_0000), X86.Avx2.mm256_cmpgt_epi8(default(v256), v));
                case 2: return (new byte32(0b0011_1111) & X86.Avx2.mm256_srai_epi16(v, 2)) | X86.Avx2.mm256_blendv_epi8(default(v256), new byte32(0b1100_0000), X86.Avx2.mm256_cmpgt_epi8(default(v256), v));
                case 3: return (new byte32(0b0001_1111) & X86.Avx2.mm256_srai_epi16(v, 3)) | X86.Avx2.mm256_blendv_epi8(default(v256), new byte32(0b1110_0000), X86.Avx2.mm256_cmpgt_epi8(default(v256), v));
                case 4: return (new byte32(0b0000_1111) & X86.Avx2.mm256_srai_epi16(v, 4)) | X86.Avx2.mm256_blendv_epi8(default(v256), new byte32(0b1111_0000), X86.Avx2.mm256_cmpgt_epi8(default(v256), v));
                case 5: return (new byte32(0b0000_0111) & X86.Avx2.mm256_srai_epi16(v, 5)) | X86.Avx2.mm256_blendv_epi8(default(v256), new byte32(0b1111_1000), X86.Avx2.mm256_cmpgt_epi8(default(v256), v));
                case 6: return (new byte32(0b0000_0011) & X86.Avx2.mm256_srai_epi16(v, 6)) | X86.Avx2.mm256_blendv_epi8(default(v256), new byte32(0b1111_1100), X86.Avx2.mm256_cmpgt_epi8(default(v256), v));
                case 7: return (new byte32(0b0000_0001) & X86.Avx2.mm256_srai_epi16(v, 7)) | X86.Avx2.mm256_blendv_epi8(default(v256), new byte32(0b1111_1110), X86.Avx2.mm256_cmpgt_epi8(default(v256), v));

                default: return X86.Avx.mm256_setzero_si256();
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 shl_short(v128 v, int n)
        {
            switch(n)
            {
                case 0:  return v;

                case 1:  return X86.Sse2.slli_epi16(v, 1);
                case 2:  return X86.Sse2.slli_epi16(v, 2);
                case 3:  return X86.Sse2.slli_epi16(v, 3);
                case 4:  return X86.Sse2.slli_epi16(v, 4);
                case 5:  return X86.Sse2.slli_epi16(v, 5);
                case 6:  return X86.Sse2.slli_epi16(v, 6);
                case 7:  return X86.Sse2.slli_epi16(v, 7);
                case 8:  return X86.Sse2.slli_epi16(v, 8);
                case 9:  return X86.Sse2.slli_epi16(v, 9);
                case 10: return X86.Sse2.slli_epi16(v, 10);
                case 11: return X86.Sse2.slli_epi16(v, 11);
                case 12: return X86.Sse2.slli_epi16(v, 12);
                case 13: return X86.Sse2.slli_epi16(v, 13);
                case 14: return X86.Sse2.slli_epi16(v, 14);
                case 15: return X86.Sse2.slli_epi16(v, 15);

                default: return  X86.Sse2.setzero_si128();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 shl_short(v256 v, int n)
        {
            switch(n)
            {
                case 0:  return v;

                case 1:  return X86.Avx2.mm256_slli_epi16(v, 1);
                case 2:  return X86.Avx2.mm256_slli_epi16(v, 2);
                case 3:  return X86.Avx2.mm256_slli_epi16(v, 3);
                case 4:  return X86.Avx2.mm256_slli_epi16(v, 4);
                case 5:  return X86.Avx2.mm256_slli_epi16(v, 5);
                case 6:  return X86.Avx2.mm256_slli_epi16(v, 6);
                case 7:  return X86.Avx2.mm256_slli_epi16(v, 7);
                case 8:  return X86.Avx2.mm256_slli_epi16(v, 8);
                case 9:  return X86.Avx2.mm256_slli_epi16(v, 9);
                case 10: return X86.Avx2.mm256_slli_epi16(v, 10);
                case 11: return X86.Avx2.mm256_slli_epi16(v, 11);
                case 12: return X86.Avx2.mm256_slli_epi16(v, 12);
                case 13: return X86.Avx2.mm256_slli_epi16(v, 13);
                case 14: return X86.Avx2.mm256_slli_epi16(v, 14);
                case 15: return X86.Avx2.mm256_slli_epi16(v, 15);

                default: return  X86.Avx.mm256_setzero_si256();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 shrl_short(v128 v, int n)
        {
            switch (n)
            {
                case 0:  return v;

                case 1:  return X86.Sse2.srli_epi16(v, 1);
                case 2:  return X86.Sse2.srli_epi16(v, 2);
                case 3:  return X86.Sse2.srli_epi16(v, 3);
                case 4:  return X86.Sse2.srli_epi16(v, 4);
                case 5:  return X86.Sse2.srli_epi16(v, 5);
                case 6:  return X86.Sse2.srli_epi16(v, 6);
                case 7:  return X86.Sse2.srli_epi16(v, 7);
                case 8:  return X86.Sse2.srli_epi16(v, 8);
                case 9:  return X86.Sse2.srli_epi16(v, 9);
                case 10: return X86.Sse2.srli_epi16(v, 10);
                case 11: return X86.Sse2.srli_epi16(v, 11);
                case 12: return X86.Sse2.srli_epi16(v, 12);
                case 13: return X86.Sse2.srli_epi16(v, 13);
                case 14: return X86.Sse2.srli_epi16(v, 14);
                case 15: return X86.Sse2.srli_epi16(v, 15);

                default: return X86.Sse2.setzero_si128();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 shra_short(v128 v, int n)
        {
            switch (n)
            {
                case 0:  return v;

                case 1:  return X86.Sse2.srai_epi16(v, 1);
                case 2:  return X86.Sse2.srai_epi16(v, 2);
                case 3:  return X86.Sse2.srai_epi16(v, 3);
                case 4:  return X86.Sse2.srai_epi16(v, 4);
                case 5:  return X86.Sse2.srai_epi16(v, 5);
                case 6:  return X86.Sse2.srai_epi16(v, 6);
                case 7:  return X86.Sse2.srai_epi16(v, 7);
                case 8:  return X86.Sse2.srai_epi16(v, 8);
                case 9:  return X86.Sse2.srai_epi16(v, 9);
                case 10: return X86.Sse2.srai_epi16(v, 10);
                case 11: return X86.Sse2.srai_epi16(v, 11);
                case 12: return X86.Sse2.srai_epi16(v, 12);
                case 13: return X86.Sse2.srai_epi16(v, 13);
                case 14: return X86.Sse2.srai_epi16(v, 14);
                case 15: return X86.Sse2.srai_epi16(v, 15);

                default: return X86.Sse2.srai_epi16(v, 16);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 shl_int(v256 v, int n)
        {
            switch (n)
            {
                case 1:  return X86.Avx2.mm256_slli_epi32(v, 1);
                case 2:  return X86.Avx2.mm256_slli_epi32(v, 2);
                case 3:  return X86.Avx2.mm256_slli_epi32(v, 3);
                case 4:  return X86.Avx2.mm256_slli_epi32(v, 4);
                case 5:  return X86.Avx2.mm256_slli_epi32(v, 5);
                case 6:  return X86.Avx2.mm256_slli_epi32(v, 6);
                case 7:  return X86.Avx2.mm256_slli_epi32(v, 7);
                case 8:  return X86.Avx2.mm256_slli_epi32(v, 8);
                case 9:  return X86.Avx2.mm256_slli_epi32(v, 9);
                case 10: return X86.Avx2.mm256_slli_epi32(v, 10);
                case 11: return X86.Avx2.mm256_slli_epi32(v, 11);
                case 12: return X86.Avx2.mm256_slli_epi32(v, 12);
                case 13: return X86.Avx2.mm256_slli_epi32(v, 13);
                case 14: return X86.Avx2.mm256_slli_epi32(v, 14);
                case 15: return X86.Avx2.mm256_slli_epi32(v, 15);
                case 16: return X86.Avx2.mm256_slli_epi32(v, 16);
                case 17: return X86.Avx2.mm256_slli_epi32(v, 17);
                case 18: return X86.Avx2.mm256_slli_epi32(v, 18);
                case 19: return X86.Avx2.mm256_slli_epi32(v, 19);
                case 20: return X86.Avx2.mm256_slli_epi32(v, 20);
                case 21: return X86.Avx2.mm256_slli_epi32(v, 21);
                case 22: return X86.Avx2.mm256_slli_epi32(v, 22);
                case 23: return X86.Avx2.mm256_slli_epi32(v, 23);
                case 24: return X86.Avx2.mm256_slli_epi32(v, 24);
                case 25: return X86.Avx2.mm256_slli_epi32(v, 25);
                case 26: return X86.Avx2.mm256_slli_epi32(v, 26);
                case 27: return X86.Avx2.mm256_slli_epi32(v, 27);
                case 28: return X86.Avx2.mm256_slli_epi32(v, 28);
                case 29: return X86.Avx2.mm256_slli_epi32(v, 29);
                case 30: return X86.Avx2.mm256_slli_epi32(v, 30);
                case 31: return X86.Avx2.mm256_slli_epi32(v, 31);

                default: return v;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 shl_long(v128 v, int n)
        {
            switch (n)
            {
                case 1:  return X86.Sse2.slli_epi64(v, 1);
                case 2:  return X86.Sse2.slli_epi64(v, 2);
                case 3:  return X86.Sse2.slli_epi64(v, 3);
                case 4:  return X86.Sse2.slli_epi64(v, 4);
                case 5:  return X86.Sse2.slli_epi64(v, 5);
                case 6:  return X86.Sse2.slli_epi64(v, 6);
                case 7:  return X86.Sse2.slli_epi64(v, 7);
                case 8:  return X86.Sse2.slli_epi64(v, 8);
                case 9:  return X86.Sse2.slli_epi64(v, 9);
                case 10: return X86.Sse2.slli_epi64(v, 10);
                case 11: return X86.Sse2.slli_epi64(v, 11);
                case 12: return X86.Sse2.slli_epi64(v, 12);
                case 13: return X86.Sse2.slli_epi64(v, 13);
                case 14: return X86.Sse2.slli_epi64(v, 14);
                case 15: return X86.Sse2.slli_epi64(v, 15);
                case 16: return X86.Sse2.slli_epi64(v, 16);
                case 17: return X86.Sse2.slli_epi64(v, 17);
                case 18: return X86.Sse2.slli_epi64(v, 18);
                case 19: return X86.Sse2.slli_epi64(v, 19);
                case 20: return X86.Sse2.slli_epi64(v, 20);
                case 21: return X86.Sse2.slli_epi64(v, 21);
                case 22: return X86.Sse2.slli_epi64(v, 22);
                case 23: return X86.Sse2.slli_epi64(v, 23);
                case 24: return X86.Sse2.slli_epi64(v, 24);
                case 25: return X86.Sse2.slli_epi64(v, 25);
                case 26: return X86.Sse2.slli_epi64(v, 26);
                case 27: return X86.Sse2.slli_epi64(v, 27);
                case 28: return X86.Sse2.slli_epi64(v, 28);
                case 29: return X86.Sse2.slli_epi64(v, 29);
                case 30: return X86.Sse2.slli_epi64(v, 30);
                case 31: return X86.Sse2.slli_epi64(v, 31);
                case 32: return X86.Sse2.slli_epi64(v, 32);
                case 33: return X86.Sse2.slli_epi64(v, 33);
                case 34: return X86.Sse2.slli_epi64(v, 34);
                case 35: return X86.Sse2.slli_epi64(v, 35);
                case 36: return X86.Sse2.slli_epi64(v, 36);
                case 37: return X86.Sse2.slli_epi64(v, 37);
                case 38: return X86.Sse2.slli_epi64(v, 38);
                case 39: return X86.Sse2.slli_epi64(v, 39);
                case 40: return X86.Sse2.slli_epi64(v, 40);
                case 41: return X86.Sse2.slli_epi64(v, 41);
                case 42: return X86.Sse2.slli_epi64(v, 42);
                case 43: return X86.Sse2.slli_epi64(v, 43);
                case 44: return X86.Sse2.slli_epi64(v, 44);
                case 45: return X86.Sse2.slli_epi64(v, 45);
                case 46: return X86.Sse2.slli_epi64(v, 46);
                case 47: return X86.Sse2.slli_epi64(v, 47);
                case 48: return X86.Sse2.slli_epi64(v, 48);
                case 49: return X86.Sse2.slli_epi64(v, 49);
                case 50: return X86.Sse2.slli_epi64(v, 50);
                case 51: return X86.Sse2.slli_epi64(v, 51);
                case 52: return X86.Sse2.slli_epi64(v, 52);
                case 53: return X86.Sse2.slli_epi64(v, 53);
                case 54: return X86.Sse2.slli_epi64(v, 54);
                case 55: return X86.Sse2.slli_epi64(v, 55);
                case 56: return X86.Sse2.slli_epi64(v, 56);
                case 57: return X86.Sse2.slli_epi64(v, 57);
                case 58: return X86.Sse2.slli_epi64(v, 58);
                case 59: return X86.Sse2.slli_epi64(v, 59);
                case 60: return X86.Sse2.slli_epi64(v, 60);
                case 61: return X86.Sse2.slli_epi64(v, 61);
                case 62: return X86.Sse2.slli_epi64(v, 62);
                case 63: return X86.Sse2.slli_epi64(v, 63);
    
                default: return v;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 shl_long(v256 v, int n)
        {
            switch (n)
            {
                case 1:  return X86.Avx2.mm256_slli_epi64(v, 1);
                case 2:  return X86.Avx2.mm256_slli_epi64(v, 2);
                case 3:  return X86.Avx2.mm256_slli_epi64(v, 3);
                case 4:  return X86.Avx2.mm256_slli_epi64(v, 4);
                case 5:  return X86.Avx2.mm256_slli_epi64(v, 5);
                case 6:  return X86.Avx2.mm256_slli_epi64(v, 6);
                case 7:  return X86.Avx2.mm256_slli_epi64(v, 7);
                case 8:  return X86.Avx2.mm256_slli_epi64(v, 8);
                case 9:  return X86.Avx2.mm256_slli_epi64(v, 9);
                case 10: return X86.Avx2.mm256_slli_epi64(v, 10);
                case 11: return X86.Avx2.mm256_slli_epi64(v, 11);
                case 12: return X86.Avx2.mm256_slli_epi64(v, 12);
                case 13: return X86.Avx2.mm256_slli_epi64(v, 13);
                case 14: return X86.Avx2.mm256_slli_epi64(v, 14);
                case 15: return X86.Avx2.mm256_slli_epi64(v, 15);
                case 16: return X86.Avx2.mm256_slli_epi64(v, 16);
                case 17: return X86.Avx2.mm256_slli_epi64(v, 17);
                case 18: return X86.Avx2.mm256_slli_epi64(v, 18);
                case 19: return X86.Avx2.mm256_slli_epi64(v, 19);
                case 20: return X86.Avx2.mm256_slli_epi64(v, 20);
                case 21: return X86.Avx2.mm256_slli_epi64(v, 21);
                case 22: return X86.Avx2.mm256_slli_epi64(v, 22);
                case 23: return X86.Avx2.mm256_slli_epi64(v, 23);
                case 24: return X86.Avx2.mm256_slli_epi64(v, 24);
                case 25: return X86.Avx2.mm256_slli_epi64(v, 25);
                case 26: return X86.Avx2.mm256_slli_epi64(v, 26);
                case 27: return X86.Avx2.mm256_slli_epi64(v, 27);
                case 28: return X86.Avx2.mm256_slli_epi64(v, 28);
                case 29: return X86.Avx2.mm256_slli_epi64(v, 29);
                case 30: return X86.Avx2.mm256_slli_epi64(v, 30);
                case 31: return X86.Avx2.mm256_slli_epi64(v, 31);
                case 32: return X86.Avx2.mm256_slli_epi64(v, 32);
                case 33: return X86.Avx2.mm256_slli_epi64(v, 33);
                case 34: return X86.Avx2.mm256_slli_epi64(v, 34);
                case 35: return X86.Avx2.mm256_slli_epi64(v, 35);
                case 36: return X86.Avx2.mm256_slli_epi64(v, 36);
                case 37: return X86.Avx2.mm256_slli_epi64(v, 37);
                case 38: return X86.Avx2.mm256_slli_epi64(v, 38);
                case 39: return X86.Avx2.mm256_slli_epi64(v, 39);
                case 40: return X86.Avx2.mm256_slli_epi64(v, 40);
                case 41: return X86.Avx2.mm256_slli_epi64(v, 41);
                case 42: return X86.Avx2.mm256_slli_epi64(v, 42);
                case 43: return X86.Avx2.mm256_slli_epi64(v, 43);
                case 44: return X86.Avx2.mm256_slli_epi64(v, 44);
                case 45: return X86.Avx2.mm256_slli_epi64(v, 45);
                case 46: return X86.Avx2.mm256_slli_epi64(v, 46);
                case 47: return X86.Avx2.mm256_slli_epi64(v, 47);
                case 48: return X86.Avx2.mm256_slli_epi64(v, 48);
                case 49: return X86.Avx2.mm256_slli_epi64(v, 49);
                case 50: return X86.Avx2.mm256_slli_epi64(v, 50);
                case 51: return X86.Avx2.mm256_slli_epi64(v, 51);
                case 52: return X86.Avx2.mm256_slli_epi64(v, 52);
                case 53: return X86.Avx2.mm256_slli_epi64(v, 53);
                case 54: return X86.Avx2.mm256_slli_epi64(v, 54);
                case 55: return X86.Avx2.mm256_slli_epi64(v, 55);
                case 56: return X86.Avx2.mm256_slli_epi64(v, 56);
                case 57: return X86.Avx2.mm256_slli_epi64(v, 57);
                case 58: return X86.Avx2.mm256_slli_epi64(v, 58);
                case 59: return X86.Avx2.mm256_slli_epi64(v, 59);
                case 60: return X86.Avx2.mm256_slli_epi64(v, 60);
                case 61: return X86.Avx2.mm256_slli_epi64(v, 61);
                case 62: return X86.Avx2.mm256_slli_epi64(v, 62);
                case 63: return X86.Avx2.mm256_slli_epi64(v, 63);

                default: return v;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 shrl_long(v256 v, int n)
        {
            switch (n)
            {
                case 1:  return X86.Avx2.mm256_srli_epi64(v, 1);
                case 2:  return X86.Avx2.mm256_srli_epi64(v, 2);
                case 3:  return X86.Avx2.mm256_srli_epi64(v, 3);
                case 4:  return X86.Avx2.mm256_srli_epi64(v, 4);
                case 5:  return X86.Avx2.mm256_srli_epi64(v, 5);
                case 6:  return X86.Avx2.mm256_srli_epi64(v, 6);
                case 7:  return X86.Avx2.mm256_srli_epi64(v, 7);
                case 8:  return X86.Avx2.mm256_srli_epi64(v, 8);
                case 9:  return X86.Avx2.mm256_srli_epi64(v, 9);
                case 10: return X86.Avx2.mm256_srli_epi64(v, 10);
                case 11: return X86.Avx2.mm256_srli_epi64(v, 11);
                case 12: return X86.Avx2.mm256_srli_epi64(v, 12);
                case 13: return X86.Avx2.mm256_srli_epi64(v, 13);
                case 14: return X86.Avx2.mm256_srli_epi64(v, 14);
                case 15: return X86.Avx2.mm256_srli_epi64(v, 15);
                case 16: return X86.Avx2.mm256_srli_epi64(v, 16);
                case 17: return X86.Avx2.mm256_srli_epi64(v, 17);
                case 18: return X86.Avx2.mm256_srli_epi64(v, 18);
                case 19: return X86.Avx2.mm256_srli_epi64(v, 19);
                case 20: return X86.Avx2.mm256_srli_epi64(v, 20);
                case 21: return X86.Avx2.mm256_srli_epi64(v, 21);
                case 22: return X86.Avx2.mm256_srli_epi64(v, 22);
                case 23: return X86.Avx2.mm256_srli_epi64(v, 23);
                case 24: return X86.Avx2.mm256_srli_epi64(v, 24);
                case 25: return X86.Avx2.mm256_srli_epi64(v, 25);
                case 26: return X86.Avx2.mm256_srli_epi64(v, 26);
                case 27: return X86.Avx2.mm256_srli_epi64(v, 27);
                case 28: return X86.Avx2.mm256_srli_epi64(v, 28);
                case 29: return X86.Avx2.mm256_srli_epi64(v, 29);
                case 30: return X86.Avx2.mm256_srli_epi64(v, 30);
                case 31: return X86.Avx2.mm256_srli_epi64(v, 31);
                case 32: return X86.Avx2.mm256_srli_epi64(v, 32);
                case 33: return X86.Avx2.mm256_srli_epi64(v, 33);
                case 34: return X86.Avx2.mm256_srli_epi64(v, 34);
                case 35: return X86.Avx2.mm256_srli_epi64(v, 35);
                case 36: return X86.Avx2.mm256_srli_epi64(v, 36);
                case 37: return X86.Avx2.mm256_srli_epi64(v, 37);
                case 38: return X86.Avx2.mm256_srli_epi64(v, 38);
                case 39: return X86.Avx2.mm256_srli_epi64(v, 39);
                case 40: return X86.Avx2.mm256_srli_epi64(v, 40);
                case 41: return X86.Avx2.mm256_srli_epi64(v, 41);
                case 42: return X86.Avx2.mm256_srli_epi64(v, 42);
                case 43: return X86.Avx2.mm256_srli_epi64(v, 43);
                case 44: return X86.Avx2.mm256_srli_epi64(v, 44);
                case 45: return X86.Avx2.mm256_srli_epi64(v, 45);
                case 46: return X86.Avx2.mm256_srli_epi64(v, 46);
                case 47: return X86.Avx2.mm256_srli_epi64(v, 47);
                case 48: return X86.Avx2.mm256_srli_epi64(v, 48);
                case 49: return X86.Avx2.mm256_srli_epi64(v, 49);
                case 50: return X86.Avx2.mm256_srli_epi64(v, 50);
                case 51: return X86.Avx2.mm256_srli_epi64(v, 51);
                case 52: return X86.Avx2.mm256_srli_epi64(v, 52);
                case 53: return X86.Avx2.mm256_srli_epi64(v, 53);
                case 54: return X86.Avx2.mm256_srli_epi64(v, 54);
                case 55: return X86.Avx2.mm256_srli_epi64(v, 55);
                case 56: return X86.Avx2.mm256_srli_epi64(v, 56);
                case 57: return X86.Avx2.mm256_srli_epi64(v, 57);
                case 58: return X86.Avx2.mm256_srli_epi64(v, 58);
                case 59: return X86.Avx2.mm256_srli_epi64(v, 59);
                case 60: return X86.Avx2.mm256_srli_epi64(v, 60);
                case 61: return X86.Avx2.mm256_srli_epi64(v, 61);
                case 62: return X86.Avx2.mm256_srli_epi64(v, 62);
                case 63: return X86.Avx2.mm256_srli_epi64(v, 63);
    
                default: return v;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static long2 shra_long(long2 v, int n)
        {
            long2 mask = (long2)X86.Sse4_2.cmpgt_epi64(default(long2), v)
                          &
                          X86.Sse4_2.cmpgt_epi64(new long2(n), default(long2));

            mask <<= (64 - n);

            return mask | X86.Sse2.srli_epi64(v,n);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 shra_long(v256 v, int n)
        {
            long4 mask = (long4)X86.Avx2.mm256_cmpgt_epi64(default(long4), v)
                          &
                          X86.Avx2.mm256_cmpgt_epi64(new long4(n), default(long4));

            mask <<= (64 - n);

            return mask | X86.Avx2.mm256_srli_epi64(v, n);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 greater_mask_byte(byte32 lhs, byte32 rhs)
        {
            byte32 mask = 1 << 7;

            byte32 lhs_sign = lhs & mask;
            byte32 rhs_sign = rhs & mask;

            return X86.Avx2.mm256_blendv_epi8(X86.Avx2.mm256_cmpgt_epi8(rhs_sign, lhs_sign),
                                              X86.Avx2.mm256_cmpgt_epi8(maxmath.andn(lhs, mask), maxmath.andn(rhs, mask)),
                                              X86.Avx2.mm256_cmpeq_epi8(rhs_sign, lhs_sign));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 greater_mask_ushort(ushort16 lhs, ushort16 rhs)
        {
            ushort16 mask = ushort.MaxValue >> 1;

            ushort16 lhs_sign = X86.Avx2.mm256_srai_epi16(lhs, 31);
            ushort16 rhs_sign = X86.Avx2.mm256_srai_epi16(rhs, 31);

            return X86.Avx2.mm256_blendv_epi8(lhs_sign,
                                              X86.Avx2.mm256_cmpgt_epi16(lhs & mask, rhs & mask),
                                              X86.Avx2.mm256_cmpeq_epi16(rhs_sign, lhs_sign));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 greater_mask_uint(uint8 lhs, uint8 rhs)
        {
            uint8 mask = uint.MaxValue >> 1;

            int8 lhs_sign = X86.Avx2.mm256_srai_epi32(lhs, 31);
            int8 rhs_sign = X86.Avx2.mm256_srai_epi32(rhs, 31);

            return X86.Avx2.mm256_blendv_epi8(lhs_sign,
                                              X86.Avx2.mm256_cmpgt_epi32(lhs & mask, rhs & mask),
                                              X86.Avx2.mm256_cmpeq_epi32(rhs_sign, lhs_sign));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 greater_mask_ulong(ulong2 lhs, ulong2 rhs)
        {
            ulong2 mask = 1ul << 63;

            ulong2 lhs_sign = lhs & mask;
            ulong2 rhs_sign = rhs & mask;

            return X86.Sse4_1.blendv_epi8(X86.Sse4_2.cmpgt_epi64(rhs_sign, lhs_sign),
                                          X86.Sse4_2.cmpgt_epi64(maxmath.andn(lhs, mask), maxmath.andn(rhs, mask)),
                                          X86.Sse4_1.cmpeq_epi64(rhs_sign, lhs_sign));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 greater_mask_ulong(v256 lhs, v256 rhs)
        {
            ulong4 mask = 1ul << 63;

            ulong4 lhs_sign = lhs & mask;
            ulong4 rhs_sign = rhs & mask;

            return X86.Avx2.mm256_blendv_epi8(X86.Avx2.mm256_cmpgt_epi64(rhs_sign, lhs_sign),
                                              X86.Avx2.mm256_cmpgt_epi64(maxmath.andn(lhs, mask), maxmath.andn(rhs, mask)),
                                              X86.Avx2.mm256_cmpeq_epi64(rhs_sign, lhs_sign));
        }
    }
}