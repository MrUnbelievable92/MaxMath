using DevTools;
using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    // Even though the code size is "large" and the C# source looks like a mess, 
    // this long division algorithm is about FIVE times faster than - (byte16 case), or EIGHT times faster than (byte32 case) scalar division of bytes 
    // or even via float conversion when compiled natively without Divide-By-Zero checks (release mode) - without requiring RAM-bandwidth-bound table-lookups.
    // Additionally, each loop iteration is a fantastic candidate for instruction level parallelism.

    // There is no compare_greater instruction for unsigned types in <= Avx2. For the byte16 case, it is faster to up-/downcast to/from unsigned shorts,
    // because bitshifting bytes in vector registers requires masking, since there are no native 8-bit shifting instructions.
    unsafe internal static partial class Operator
    {
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

            if (Avx2.IsAvx2Supported)
            {
                byte32 quotients = byte32.zero;
                remainder = byte32.zero;

                remainder |= (new byte32(1) & (dividend >> 7));

                v256 subtractDivisorFromRemainder = Avx2.mm256_cmpeq_epi8(Avx2.mm256_min_epu8(divisor, remainder), divisor);

                remainder -= Avx2.mm256_blendv_epi8(default(v256), divisor, subtractDivisorFromRemainder);
                quotients |= new byte32(1) & subtractDivisorFromRemainder;

                divrem_LOOPHEAD_byte(6, ref quotients, ref remainder, divisor, dividend);
                divrem_LOOPHEAD_byte(5, ref quotients, ref remainder, divisor, dividend);
                divrem_LOOPHEAD_byte(4, ref quotients, ref remainder, divisor, dividend);
                divrem_LOOPHEAD_byte(3, ref quotients, ref remainder, divisor, dividend);
                divrem_LOOPHEAD_byte(2, ref quotients, ref remainder, divisor, dividend);
                divrem_LOOPHEAD_byte(1, ref quotients, ref remainder, divisor, dividend);

                remainder <<= 1; ;
                quotients <<= 1;

                remainder |= new byte32(1) & dividend;

                subtractDivisorFromRemainder = Avx2.mm256_cmpeq_epi8(Avx2.mm256_min_epu8(divisor, remainder), divisor);

                remainder -= Avx2.mm256_blendv_epi8(default(v256), divisor, subtractDivisorFromRemainder);
                quotients |= new byte32(1) & subtractDivisorFromRemainder;


                return quotients;
            }
            else throw new BurstCompilerException();
        }
        
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

            if (Avx2.IsAvx2Supported)
            {
                byte32 quotients = byte32.zero;
                byte32 remainder = byte32.zero;


                remainder |= (new byte32(1) & (dividend >> 7));

                v256 subtractDivisorFromRemainder = Avx2.mm256_cmpeq_epi8(Avx2.mm256_min_epu8(divisor, remainder), divisor);

                remainder -= Avx2.mm256_blendv_epi8(default(v256), divisor, subtractDivisorFromRemainder);
                quotients |= new byte32(1) & subtractDivisorFromRemainder;

                divrem_LOOPHEAD_byte(6, ref quotients, ref remainder, divisor, dividend);
                divrem_LOOPHEAD_byte(5, ref quotients, ref remainder, divisor, dividend);
                divrem_LOOPHEAD_byte(4, ref quotients, ref remainder, divisor, dividend);
                divrem_LOOPHEAD_byte(3, ref quotients, ref remainder, divisor, dividend);
                divrem_LOOPHEAD_byte(2, ref quotients, ref remainder, divisor, dividend);
                divrem_LOOPHEAD_byte(1, ref quotients, ref remainder, divisor, dividend);

                remainder <<= 1;;
                quotients <<= 1;

                remainder |= new byte32(1) & dividend;

                subtractDivisorFromRemainder = Avx2.mm256_cmpeq_epi8(Avx2.mm256_min_epu8(divisor, remainder), divisor);

                quotients |= new byte32(1) & subtractDivisorFromRemainder;


                return quotients;
            }
            else throw new BurstCompilerException();
        }
        
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

            if (Avx2.IsAvx2Supported)
            {
                byte32 remainders = byte32.zero;


                remainders |= (new byte32(1) & (dividend >> 7));

                v256 subtractDivisorFromRemainder = Avx2.mm256_cmpeq_epi8(Avx2.mm256_min_epu8(divisor, remainders), divisor);

                remainders -= Avx2.mm256_blendv_epi8(default(v256), divisor, subtractDivisorFromRemainder);

                rem_LOOPHEAD_byte(6, ref remainders, divisor, dividend);
                rem_LOOPHEAD_byte(5, ref remainders, divisor, dividend);
                rem_LOOPHEAD_byte(4, ref remainders, divisor, dividend);
                rem_LOOPHEAD_byte(3, ref remainders, divisor, dividend);
                rem_LOOPHEAD_byte(2, ref remainders, divisor, dividend);
                rem_LOOPHEAD_byte(1, ref remainders, divisor, dividend);

                remainders <<= 1;;

                remainders |= new byte32(1) & dividend;

                subtractDivisorFromRemainder = Avx2.mm256_cmpeq_epi8(Avx2.mm256_min_epu8(divisor, remainders), divisor);

                remainders -= Avx2.mm256_blendv_epi8(default(v256), divisor, subtractDivisorFromRemainder);


                return remainders;
            }
            else throw new BurstCompilerException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static sbyte32 vdivrem_sbyte(sbyte32 dividend, sbyte32 divisor, out sbyte32 remainder)
        {
            if (Avx2.IsAvx2Supported)
            {
                byte32 quotient = vdivrem_byte((byte32)maxmath.abs(dividend), (byte32)maxmath.abs(divisor), out byte32 remainders);

                byte32 mustNegate = Avx2.mm256_cmpgt_epi8(sbyte32.zero, dividend);

                remainder = Avx2.mm256_blendv_epi8(remainders, -((sbyte32)remainders), mustNegate);

                mustNegate = Avx2.mm256_xor_si256(Avx2.mm256_cmpgt_epi8(sbyte32.zero, divisor),
                                                  Avx2.mm256_cmpgt_epi8(sbyte32.zero, dividend));

                return Avx2.mm256_blendv_epi8(quotient, -((sbyte32)quotient), mustNegate);
            }
            else throw new BurstCompilerException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static sbyte32 vdiv_sbyte(sbyte32 dividend, sbyte32 divisor)
        {
            if (Avx2.IsAvx2Supported)
            {
                byte32 quotient = vdiv_byte((byte32)maxmath.abs(dividend), (byte32)maxmath.abs(divisor));

                byte32 mustNegate = Avx2.mm256_xor_si256(Avx2.mm256_cmpgt_epi8(sbyte32.zero, divisor),
                                                         Avx2.mm256_cmpgt_epi8(sbyte32.zero, dividend));

                return Avx2.mm256_blendv_epi8(quotient, -((sbyte32)quotient), mustNegate);
            }
            else throw new BurstCompilerException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static sbyte32 vrem_sbyte(sbyte32 dividend, sbyte32 divisor)
        {
            if (Avx2.IsAvx2Supported)
            {
                byte32 remainder = vrem_byte((byte32)maxmath.abs(dividend), (byte32)maxmath.abs(divisor));

                byte32 mustNegate = Avx2.mm256_cmpgt_epi8(sbyte32.zero, dividend);

                return Avx2.mm256_blendv_epi8(remainder, -((sbyte32)remainder), mustNegate);
            }
            else throw new BurstCompilerException();
        }


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

            if (Avx2.IsAvx2Supported)
            {
                ushort16 quotients = ushort16.zero;
                ushort16 remainders = ushort16.zero;

                ushort16 divisorCast = divisor;
                ushort16 dividendCast = dividend;


                remainders |= (new ushort16(1) & (dividendCast >> 7));

                v256 subtractDivisorFromRemainder = Avx2.mm256_cmpeq_epi16(Avx2.mm256_min_epu16(divisorCast, remainders), divisorCast);

                remainders -= Avx2.mm256_blendv_epi8(default(v256), divisorCast, subtractDivisorFromRemainder);
                quotients |= new ushort16(1) & subtractDivisorFromRemainder;

                divrem_LOOPHEAD_upcast(6, ref quotients, ref remainders, divisorCast, dividendCast);
                divrem_LOOPHEAD_upcast(5, ref quotients, ref remainders, divisorCast, dividendCast);
                divrem_LOOPHEAD_upcast(4, ref quotients, ref remainders, divisorCast, dividendCast);
                divrem_LOOPHEAD_upcast(3, ref quotients, ref remainders, divisorCast, dividendCast);
                divrem_LOOPHEAD_upcast(2, ref quotients, ref remainders, divisorCast, dividendCast);
                divrem_LOOPHEAD_upcast(1, ref quotients, ref remainders, divisorCast, dividendCast);

                remainders <<= 1;
                quotients <<= 1;

                remainders |= new ushort16(1) & dividendCast;

                subtractDivisorFromRemainder = Avx2.mm256_cmpeq_epi16(Avx2.mm256_min_epu16(divisorCast, remainders), divisorCast);

                remainders -= Avx2.mm256_blendv_epi8(default(v256), divisorCast, subtractDivisorFromRemainder);
                quotients |= new ushort16(1) & subtractDivisorFromRemainder;


                remainder = Sse2.packus_epi16(Avx.mm256_castsi256_si128(remainders), Avx2.mm256_extracti128_si256(remainders, 1));
                return Sse2.packus_epi16(Avx.mm256_castsi256_si128(quotients), Avx2.mm256_extracti128_si256(quotients, 1));
            }
            else throw new BurstCompilerException();
        }

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

            if (Avx2.IsAvx2Supported)
            {
                ushort16 quotients = ushort16.zero;
                ushort16 remainders = ushort16.zero;

                ushort16 divisorCast = divisor;
                ushort16 dividendCast = dividend;


                remainders |= (new ushort16(1) & (dividendCast >> 7));

                v256 subtractDivisorFromRemainder = Avx2.mm256_cmpeq_epi16(Avx2.mm256_min_epu16(divisorCast, remainders), divisorCast);

                remainders -= Avx2.mm256_blendv_epi8(default(v256), divisorCast, subtractDivisorFromRemainder);
                quotients |= new ushort16(1) & subtractDivisorFromRemainder;

                divrem_LOOPHEAD_upcast(6, ref quotients, ref remainders, divisorCast, dividendCast);
                divrem_LOOPHEAD_upcast(5, ref quotients, ref remainders, divisorCast, dividendCast);
                divrem_LOOPHEAD_upcast(4, ref quotients, ref remainders, divisorCast, dividendCast);
                divrem_LOOPHEAD_upcast(3, ref quotients, ref remainders, divisorCast, dividendCast);
                divrem_LOOPHEAD_upcast(2, ref quotients, ref remainders, divisorCast, dividendCast);
                divrem_LOOPHEAD_upcast(1, ref quotients, ref remainders, divisorCast, dividendCast);

                remainders <<= 1;
                quotients <<= 1;

                remainders |= new ushort16(1) & dividendCast;

                subtractDivisorFromRemainder = Avx2.mm256_cmpeq_epi16(Avx2.mm256_min_epu16(divisorCast, remainders), divisorCast);

                quotients |= new ushort16(1) & subtractDivisorFromRemainder;


                return Sse2.packus_epi16(Avx.mm256_castsi256_si128(quotients), Avx2.mm256_extracti128_si256(quotients, 1));
            }
            else throw new BurstCompilerException();
        }

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

            if (Avx2.IsAvx2Supported)
            {
                ushort16 remainders = ushort16.zero;

                ushort16 divisorCast = divisor;
                ushort16 dividendCast = dividend;


                remainders |= (new ushort16(1) & (dividendCast >> 7));

                v256 subtractDivisorFromRemainder = Avx2.mm256_cmpeq_epi16(Avx2.mm256_min_epu16(divisorCast, remainders), divisorCast);

                remainders -= Avx2.mm256_blendv_epi8(default(v256), divisorCast, subtractDivisorFromRemainder);

                rem_LOOPHEAD_upcast(6, ref remainders, divisorCast, dividendCast);
                rem_LOOPHEAD_upcast(5, ref remainders, divisorCast, dividendCast);
                rem_LOOPHEAD_upcast(4, ref remainders, divisorCast, dividendCast);
                rem_LOOPHEAD_upcast(3, ref remainders, divisorCast, dividendCast);
                rem_LOOPHEAD_upcast(2, ref remainders, divisorCast, dividendCast);
                rem_LOOPHEAD_upcast(1, ref remainders, divisorCast, dividendCast);

                remainders <<= 1;

                remainders |= new ushort16(1) & dividendCast;

                subtractDivisorFromRemainder = Avx2.mm256_cmpeq_epi16(Avx2.mm256_min_epu16(divisorCast, remainders), divisorCast);

                remainders -= Avx2.mm256_blendv_epi8(default(v256), divisorCast, subtractDivisorFromRemainder);


                return Sse2.packus_epi16(Avx.mm256_castsi256_si128(remainders), Avx2.mm256_extracti128_si256(remainders, 1));
            }
            else throw new BurstCompilerException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static sbyte16 vdivrem_sbyte(sbyte16 dividend, sbyte16 divisor, out sbyte16 remainder)
        {
            if (Avx2.IsAvx2Supported)
            {
                byte16 quotient = vdivrem_byte((byte16)maxmath.abs(dividend), (byte16)maxmath.abs(divisor), out byte16 remainders);

                byte16 mustNegate = Sse2.cmpgt_epi8(sbyte16.zero, dividend);

                remainder = Mask.BlendV(remainders, -((sbyte16)remainders), mustNegate);

                mustNegate = Sse2.xor_si128(Sse2.cmpgt_epi8(sbyte16.zero, divisor),
                                            Sse2.cmpgt_epi8(sbyte16.zero, dividend));

                return Mask.BlendV(quotient, -((sbyte16)quotient), mustNegate);
            }
            else throw new BurstCompilerException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static sbyte16 vdiv_sbyte(sbyte16 dividend, sbyte16 divisor)
        {
            if (Avx2.IsAvx2Supported)
            {
                byte16 quotient = vdiv_byte((byte16)maxmath.abs(dividend), (byte16)maxmath.abs(divisor));

                byte16 mustNegate = Sse2.xor_si128(Sse2.cmpgt_epi8(sbyte16.zero, divisor),
                                                   Sse2.cmpgt_epi8(sbyte16.zero, dividend));

                return Mask.BlendV(quotient, -((sbyte16)quotient), mustNegate);
            }
            else throw new BurstCompilerException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static sbyte16 vrem_sbyte(sbyte16 dividend, sbyte16 divisor)
        {
            if (Avx2.IsAvx2Supported)
            {
                byte16 remainder = vrem_byte((byte16)maxmath.abs(dividend), (byte16)maxmath.abs(divisor));

                byte16 mustNegate = Sse2.cmpgt_epi8(sbyte16.zero, dividend);

                return Mask.BlendV(remainder, -((sbyte16)remainder), mustNegate);
            }
            else throw new BurstCompilerException();
        }


        internal static byte8 vdivrem_byte_SSE_FALLBACK(byte8 dividend, byte8 divisor, out byte8 remainder)
        {
Assert.AreNotEqual(divisor.x0,  0);
Assert.AreNotEqual(divisor.x1,  0);
Assert.AreNotEqual(divisor.x2,  0);
Assert.AreNotEqual(divisor.x3,  0);
Assert.AreNotEqual(divisor.x4,  0);
Assert.AreNotEqual(divisor.x5,  0);
Assert.AreNotEqual(divisor.x6,  0);
Assert.AreNotEqual(divisor.x7,  0);

            if (Sse4_1.IsSse41Supported)
            {
                ushort8 quotients = ushort8.zero;
                ushort8 remainders = ushort8.zero;

                ushort8 divisorCast = divisor;
                ushort8 dividendCast = dividend;


                remainders |= (new ushort8(1) & (dividendCast >> 7));

                v128 subtractDivisorFromRemainder = Sse2.cmpeq_epi16(Sse4_1.min_epu16(divisorCast, remainders), divisorCast);

                remainders -= Mask.BlendV(default(v128), divisorCast, subtractDivisorFromRemainder);
                quotients |= new ushort8(1) & subtractDivisorFromRemainder;

                divrem_LOOPHEAD_upcast(6, ref quotients, ref remainders, divisorCast, dividendCast);
                divrem_LOOPHEAD_upcast(5, ref quotients, ref remainders, divisorCast, dividendCast);
                divrem_LOOPHEAD_upcast(4, ref quotients, ref remainders, divisorCast, dividendCast);
                divrem_LOOPHEAD_upcast(3, ref quotients, ref remainders, divisorCast, dividendCast);
                divrem_LOOPHEAD_upcast(2, ref quotients, ref remainders, divisorCast, dividendCast);
                divrem_LOOPHEAD_upcast(1, ref quotients, ref remainders, divisorCast, dividendCast);

                remainders <<= 1;
                quotients <<= 1;

                remainders |= new ushort8(1) & dividendCast;

                subtractDivisorFromRemainder = Sse2.cmpeq_epi16(Sse4_1.min_epu16(divisorCast, remainders), divisorCast);

                remainders -= Mask.BlendV(default(v128), divisorCast, subtractDivisorFromRemainder);
                quotients |= new ushort8(1) & subtractDivisorFromRemainder;


                byte16 temp = Sse2.packus_epi16(remainders, quotients);
                remainder =  temp .v8_0;
                return  temp .v8_8;
            }
            else throw new BurstCompilerException();
        }

        internal static byte8 vdiv_byte_SSE_FALLBACK(byte8 dividend, byte8 divisor)
        {
Assert.AreNotEqual(divisor.x0,  0);
Assert.AreNotEqual(divisor.x1,  0);
Assert.AreNotEqual(divisor.x2,  0);
Assert.AreNotEqual(divisor.x3,  0);
Assert.AreNotEqual(divisor.x4,  0);
Assert.AreNotEqual(divisor.x5,  0);
Assert.AreNotEqual(divisor.x6,  0);
Assert.AreNotEqual(divisor.x7,  0);

            if (Sse4_1.IsSse41Supported)
            {
                ushort8 quotients = ushort8.zero;
                ushort8 remainders = ushort8.zero;

                ushort8 divisorCast = divisor;
                ushort8 dividendCast = dividend;


                remainders |= (new ushort8(1) & (dividendCast >> 7));

                v128 subtractDivisorFromRemainder = Sse2.cmpeq_epi16(Sse4_1.min_epu16(divisorCast, remainders), divisorCast);

                remainders -= Mask.BlendV(default(v128), divisorCast, subtractDivisorFromRemainder);
                quotients |= new ushort8(1) & subtractDivisorFromRemainder;

                divrem_LOOPHEAD_upcast(6, ref quotients, ref remainders, divisorCast, dividendCast);
                divrem_LOOPHEAD_upcast(5, ref quotients, ref remainders, divisorCast, dividendCast);
                divrem_LOOPHEAD_upcast(4, ref quotients, ref remainders, divisorCast, dividendCast);
                divrem_LOOPHEAD_upcast(3, ref quotients, ref remainders, divisorCast, dividendCast);
                divrem_LOOPHEAD_upcast(2, ref quotients, ref remainders, divisorCast, dividendCast);
                divrem_LOOPHEAD_upcast(1, ref quotients, ref remainders, divisorCast, dividendCast);

                remainders <<= 1;
                quotients <<= 1;

                remainders |= new ushort8(1) & dividendCast;

                subtractDivisorFromRemainder = Sse2.cmpeq_epi16(Sse4_1.min_epu16(divisorCast, remainders), divisorCast);

                quotients |= new ushort8(1) & subtractDivisorFromRemainder;


                return (byte8)quotients;
            }
            else throw new BurstCompilerException();
        }

        internal static byte8 vrem_byte_SSE_FALLBACK(byte8 dividend, byte8 divisor)
        {
Assert.AreNotEqual(divisor.x0,  0);
Assert.AreNotEqual(divisor.x1,  0);
Assert.AreNotEqual(divisor.x2,  0);
Assert.AreNotEqual(divisor.x3,  0);
Assert.AreNotEqual(divisor.x4,  0);
Assert.AreNotEqual(divisor.x5,  0);
Assert.AreNotEqual(divisor.x6,  0);
Assert.AreNotEqual(divisor.x7,  0);

            if (Sse4_1.IsSse41Supported)
            {
                ushort8 remainders = ushort8.zero;

                ushort8 divisorCast = divisor;
                ushort8 dividendCast = dividend;


                remainders |= (new ushort8(1) & (dividendCast >> 7));

                v128 subtractDivisorFromRemainder = Sse2.cmpeq_epi16(Sse4_1.min_epu16(divisorCast, remainders), divisorCast);

                remainders -= Mask.BlendV(default(v128), divisorCast, subtractDivisorFromRemainder);

                rem_LOOPHEAD_upcast(6, ref remainders, divisorCast, dividendCast);
                rem_LOOPHEAD_upcast(5, ref remainders, divisorCast, dividendCast);
                rem_LOOPHEAD_upcast(4, ref remainders, divisorCast, dividendCast);
                rem_LOOPHEAD_upcast(3, ref remainders, divisorCast, dividendCast);
                rem_LOOPHEAD_upcast(2, ref remainders, divisorCast, dividendCast);
                rem_LOOPHEAD_upcast(1, ref remainders, divisorCast, dividendCast);

                remainders <<= 1;

                remainders |= new ushort8(1) & dividendCast;

                subtractDivisorFromRemainder = Sse2.cmpeq_epi16(Sse4_1.min_epu16(divisorCast, remainders), divisorCast);

                remainders -= Mask.BlendV(default(v128), divisorCast, subtractDivisorFromRemainder);


                return (byte8)remainders;
            }
            else throw new BurstCompilerException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static sbyte8 vdivrem_sbyte_SSE_FALLBACK(sbyte8 dividend, sbyte8 divisor, out sbyte8 remainder)
        {
            if (Sse4_1.IsSse41Supported)
            {
                byte8 quotient = vdivrem_byte_SSE_FALLBACK((byte8)maxmath.abs(dividend), (byte8)maxmath.abs(divisor), out byte8 remainders);

                byte8 mustNegate = Sse2.cmpgt_epi8(sbyte8.zero, dividend);

                remainder = Mask.BlendV(remainders, -((sbyte8)remainders), mustNegate);

                mustNegate = Sse2.xor_si128(Sse2.cmpgt_epi8(sbyte8.zero, divisor),
                                            Sse2.cmpgt_epi8(sbyte8.zero, dividend));

                return Mask.BlendV(quotient, -((sbyte8)quotient), mustNegate);
            }
            else throw new BurstCompilerException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static sbyte8 vdiv_sbyte_SSE_FALLBACK(sbyte8 dividend, sbyte8 divisor)
        {
            if (Sse4_1.IsSse41Supported)
            {
                byte8 quotient = vdiv_byte_SSE_FALLBACK((byte8)maxmath.abs(dividend), (byte8)maxmath.abs(divisor));

                byte8 mustNegate = Sse2.xor_si128(Sse2.cmpgt_epi8(sbyte8.zero, divisor),
                                                  Sse2.cmpgt_epi8(sbyte8.zero, dividend));

                return Mask.BlendV(quotient, -((sbyte8)quotient), mustNegate);
            }
            else throw new BurstCompilerException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static sbyte8 vrem_sbyte_SSE_FALLBACK(sbyte8 dividend, sbyte8 divisor)
        {
            if (Sse4_1.IsSse41Supported)
            {
                byte8 remainder = vrem_byte_SSE_FALLBACK((byte8)maxmath.abs(dividend), (byte8)maxmath.abs(divisor));

                byte8 mustNegate = Sse2.cmpgt_epi8(sbyte8.zero, dividend);

                return Mask.BlendV(remainder, -((sbyte8)remainder), mustNegate);
            }
            else throw new BurstCompilerException();
        }


        internal static byte16 vdivrem_byte_SSE_FALLBACK(byte16 dividend, byte16 divisor, out byte16 remainder)
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

            if (Sse2.IsSse2Supported)
            {
                byte16 quotients = byte16.zero; 
                remainder = byte16.zero;


                remainder |= (new byte16(1) & (dividend >> 7));

                v128 subtractDivisorFromRemainder = Sse2.cmpeq_epi8(Sse2.min_epu8(divisor, remainder), divisor);

                remainder -= Mask.BlendV(default(v128), divisor, subtractDivisorFromRemainder);
                quotients |= new byte16(1) & subtractDivisorFromRemainder;

                divrem_LOOPHEAD_byte(6, ref quotients, ref remainder, divisor, dividend);
                divrem_LOOPHEAD_byte(5, ref quotients, ref remainder, divisor, dividend);
                divrem_LOOPHEAD_byte(4, ref quotients, ref remainder, divisor, dividend);
                divrem_LOOPHEAD_byte(3, ref quotients, ref remainder, divisor, dividend);
                divrem_LOOPHEAD_byte(2, ref quotients, ref remainder, divisor, dividend);
                divrem_LOOPHEAD_byte(1, ref quotients, ref remainder, divisor, dividend);

                remainder <<= 1;;
                quotients <<= 1;

                remainder |= new byte16(1) & dividend;

                subtractDivisorFromRemainder = Sse2.cmpeq_epi8(Sse2.min_epu8(divisor, remainder), divisor);

                remainder -= Mask.BlendV(default(v128), divisor, subtractDivisorFromRemainder);
                quotients |= new byte16(1) & subtractDivisorFromRemainder;


                return quotients;
            }
            else throw new BurstCompilerException();
        }
        
        internal static byte16 vdiv_byte_SSE_FALLBACK(byte16 dividend, byte16 divisor)
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

            if (Sse2.IsSse2Supported)
            {
                byte16 quotients = byte16.zero;
                byte16 remainder = byte16.zero;


                remainder |= (new byte16(1) & (dividend >> 7));

                v128 subtractDivisorFromRemainder = Sse2.cmpeq_epi8(Sse2.min_epu8(divisor, remainder), divisor);

                remainder -= Mask.BlendV(default(v128), divisor, subtractDivisorFromRemainder);
                quotients |= new byte16(1) & subtractDivisorFromRemainder;

                divrem_LOOPHEAD_byte(6, ref quotients, ref remainder, divisor, dividend);
                divrem_LOOPHEAD_byte(5, ref quotients, ref remainder, divisor, dividend);
                divrem_LOOPHEAD_byte(4, ref quotients, ref remainder, divisor, dividend);
                divrem_LOOPHEAD_byte(3, ref quotients, ref remainder, divisor, dividend);
                divrem_LOOPHEAD_byte(2, ref quotients, ref remainder, divisor, dividend);
                divrem_LOOPHEAD_byte(1, ref quotients, ref remainder, divisor, dividend);

                remainder <<= 1;;
                quotients <<= 1;

                remainder |= new byte16(1) & dividend;

                subtractDivisorFromRemainder = Sse2.cmpeq_epi8(Sse2.min_epu8(divisor, remainder), divisor);

                quotients |= new byte16(1) & subtractDivisorFromRemainder;


                return quotients;
            }
            else throw new BurstCompilerException();
        }
        
        internal static byte16 vrem_byte_SSE_FALLBACK(byte16 dividend, byte16 divisor)
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

            if (Sse2.IsSse2Supported)
            {
                byte16 remainders = byte16.zero;


                remainders |= (new byte16(1) & (dividend >> 7));

                v128 subtractDivisorFromRemainder = Sse2.cmpeq_epi8(Sse2.min_epu8(divisor, remainders), divisor);

                remainders -= Mask.BlendV(default(v128), divisor, subtractDivisorFromRemainder);

                rem_LOOPHEAD_byte(6, ref remainders, divisor, dividend);
                rem_LOOPHEAD_byte(5, ref remainders, divisor, dividend);
                rem_LOOPHEAD_byte(4, ref remainders, divisor, dividend);
                rem_LOOPHEAD_byte(3, ref remainders, divisor, dividend);
                rem_LOOPHEAD_byte(2, ref remainders, divisor, dividend);
                rem_LOOPHEAD_byte(1, ref remainders, divisor, dividend);

                remainders <<= 1;;

                remainders |= new byte16(1) & dividend;

                subtractDivisorFromRemainder = Sse2.cmpeq_epi8(Sse2.min_epu8(divisor, remainders), divisor);

                remainders -= Mask.BlendV(default(v128), divisor, subtractDivisorFromRemainder);


                return remainders;
            }
            else throw new BurstCompilerException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static sbyte16 vdivrem_sbyte_SSE_FALLBACK(sbyte16 dividend, sbyte16 divisor, out sbyte16 remainder)
        {
            if (Sse2.IsSse2Supported)
            {
                byte16 quotient = vdivrem_byte_SSE_FALLBACK((byte16)maxmath.abs(dividend), (byte16)maxmath.abs(divisor), out byte16 remainders);

                byte16 mustNegate = Sse2.cmpgt_epi8(sbyte16.zero, dividend);

                remainder = Mask.BlendV(remainders, -((sbyte16)remainders), mustNegate);

                mustNegate = Sse2.xor_si128(Sse2.cmpgt_epi8(sbyte16.zero, divisor),
                                            Sse2.cmpgt_epi8(sbyte16.zero, dividend));

                return Mask.BlendV(quotient, -((sbyte16)quotient), mustNegate);
            }
            else throw new BurstCompilerException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static sbyte16 vdiv_sbyte_SSE_FALLBACK(sbyte16 dividend, sbyte16 divisor)
        {
            if (Sse2.IsSse2Supported)
            {
                byte16 quotient = vdiv_byte_SSE_FALLBACK((byte16)maxmath.abs(dividend), (byte16)maxmath.abs(divisor));

                byte16 mustNegate = Sse2.xor_si128(Sse2.cmpgt_epi8(sbyte16.zero, divisor),
                                                   Sse2.cmpgt_epi8(sbyte16.zero, dividend));

                return Mask.BlendV(quotient, -((sbyte16)quotient), mustNegate);
            }
            else throw new BurstCompilerException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static sbyte16 vrem_sbyte_SSE_FALLBACK(sbyte16 dividend, sbyte16 divisor)
        {
            if (Sse2.IsSse2Supported)
            {
                byte16 remainder = vrem_byte_SSE_FALLBACK((byte16)maxmath.abs(dividend), (byte16)maxmath.abs(divisor));

                byte16 mustNegate = Sse2.cmpgt_epi8(sbyte16.zero, dividend);

                return Mask.BlendV(remainder, -((sbyte16)remainder), mustNegate);
            }
            else throw new BurstCompilerException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void divrem_LOOPHEAD_upcast(int i, ref ushort16 quotients, ref ushort16 remainders, ushort16 divisorCast, ushort16 dividendCast)
        {
            if (Avx2.IsAvx2Supported)
            {
                quotients <<= 1;
                remainders <<= 1;

                remainders |= (new ushort16(1) & (dividendCast >> i));

                v256 subtractDivisorFromRemainder = Avx2.mm256_cmpeq_epi16(Avx2.mm256_min_epu16(divisorCast, remainders), divisorCast);

                remainders -= Avx2.mm256_blendv_epi8(default(v256), divisorCast, subtractDivisorFromRemainder);
                quotients |= new ushort16(1) & subtractDivisorFromRemainder;
            }
            else throw new BurstCompilerException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void rem_LOOPHEAD_upcast(int i, ref ushort16 remainders, ushort16 divisorCast, ushort16 dividendCast)
        {
            if (Avx2.IsAvx2Supported)
            {
                remainders <<= 1;

                remainders |= (new ushort16(1) & (dividendCast >> i));

                v256 subtractDivisorFromRemainder = Avx2.mm256_cmpeq_epi16(Avx2.mm256_min_epu16(divisorCast, remainders), divisorCast);

                remainders -= Avx2.mm256_blendv_epi8(default(v256), divisorCast, subtractDivisorFromRemainder);
            }
            else throw new BurstCompilerException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void divrem_LOOPHEAD_upcast(int i, ref ushort8 quotients, ref ushort8 remainders, ushort8 divisorCast, ushort8 dividendCast)
        {
            if (Sse2.IsSse2Supported)
            {
                quotients <<= 1;
                remainders <<= 1;

                remainders |= (new ushort8(1) & (dividendCast >> i));

                v128 subtractDivisorFromRemainder = Sse2.cmpeq_epi8(Sse2.min_epu8(divisorCast, remainders), divisorCast);

                remainders -= Mask.BlendV(default(v128), divisorCast, subtractDivisorFromRemainder);
                quotients |= new ushort8(1) & subtractDivisorFromRemainder;
            }
            else throw new BurstCompilerException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void rem_LOOPHEAD_upcast(int i, ref ushort8 remainders, ushort8 divisorCast, ushort8 dividendCast)
        {
            if (Sse2.IsSse2Supported)
            {
                remainders <<= 1;

                remainders |= (new ushort8(1) & (dividendCast >> i));

                v128 subtractDivisorFromRemainder = Sse2.cmpeq_epi8(Sse2.min_epu8(divisorCast, remainders), divisorCast);

                remainders -= Mask.BlendV(default(v128), divisorCast, subtractDivisorFromRemainder);
            }
            else throw new BurstCompilerException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void divrem_LOOPHEAD_byte(int i, ref byte32 quotients, ref byte32 remainders, byte32 divisorCast, byte32 dividendCast)
        {
            if (Avx2.IsAvx2Supported)
            {
                quotients <<= 1;
                remainders <<= 1;

                remainders |= (new byte32(1) & (dividendCast >> i));

                v256 subtractDivisorFromRemainder = Avx2.mm256_cmpeq_epi8(Avx2.mm256_min_epu8(divisorCast, remainders), divisorCast);

                remainders -= Avx2.mm256_blendv_epi8(default(v256), divisorCast, subtractDivisorFromRemainder);
                quotients |= new byte32(1) & subtractDivisorFromRemainder;
            }
            else throw new BurstCompilerException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void rem_LOOPHEAD_byte(int i, ref byte32 remainders, byte32 divisorCast, byte32 dividendCast)
        {
            if (Avx2.IsAvx2Supported)
            {
                remainders <<= 1;

                remainders |= (new byte32(1) & (dividendCast >> i));

                v256 subtractDivisorFromRemainder = Avx2.mm256_cmpeq_epi8(Avx2.mm256_min_epu8(divisorCast, remainders), divisorCast);

                remainders -= Avx2.mm256_blendv_epi8(default(v256), divisorCast, subtractDivisorFromRemainder);
            }
            else throw new BurstCompilerException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void divrem_LOOPHEAD_byte(int i, ref byte16 quotients, ref byte16 remainders, byte16 divisorCast, byte16 dividendCast)
        {
            if (Sse2.IsSse2Supported)
            {
                quotients <<= 1;
                remainders <<= 1;

                remainders |= (new byte16(1) & (dividendCast >> i));

                v128 subtractDivisorFromRemainder = Sse2.cmpeq_epi8(Sse2.min_epu8(divisorCast, remainders), divisorCast);

                remainders -= Mask.BlendV(default(v128), divisorCast, subtractDivisorFromRemainder);
                quotients |= new byte16(1) & subtractDivisorFromRemainder;
            }
            else throw new BurstCompilerException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void rem_LOOPHEAD_byte(int i, ref byte16 remainders, byte16 divisorCast, byte16 dividendCast)
        {
            if (Sse2.IsSse2Supported)
            {
                remainders <<= 1;

                remainders |= (new byte16(1) & (dividendCast >> i));

                v128 subtractDivisorFromRemainder = Sse2.cmpeq_epi8(Sse2.min_epu8(divisorCast, remainders), divisorCast);

                remainders -= Mask.BlendV(default(v128), divisorCast, subtractDivisorFromRemainder);
            }
            else throw new BurstCompilerException();
        }
    }
}