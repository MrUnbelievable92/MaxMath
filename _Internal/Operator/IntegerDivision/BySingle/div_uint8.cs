using System;
using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

namespace MaxMath
{
    unsafe internal static partial class Operator
    {
        // NOPE! Gets inlined if divisor is a constant, else its a function call (otherwise code size is going to be enormous)
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint8 div(uint8 dividend, uint divisor)
        {
            switch (divisor)
            {
#if UNITY_EDITOR
                case 0u: throw new DivideByZeroException();
#endif
                case 1u: return dividend;
                case uint.MaxValue: return X86.Avx2.mm256_blendv_epi8(default(uint8), new uint8(1u), X86.Avx2.mm256_cmpeq_epi32(dividend, new uint8(uint.MaxValue)));

                case 1u << 1:  return dividend >> 1;
                case 1u << 2:  return dividend >> 2;
                case 1u << 3:  return dividend >> 3;
                case 1u << 4:  return dividend >> 4;
                case 1u << 5:  return dividend >> 5;
                case 1u << 6:  return dividend >> 6;
                case 1u << 7:  return dividend >> 7;
                case 1u << 8:  return dividend >> 8;
                case 1u << 9:  return dividend >> 9;
                case 1u << 10: return dividend >> 10;
                case 1u << 11: return dividend >> 11;
                case 1u << 12: return dividend >> 12;
                case 1u << 13: return dividend >> 13;
                case 1u << 14: return dividend >> 14;
                case 1u << 15: return dividend >> 15;
                case 1u << 16: return dividend >> 16;
                case 1u << 17: return dividend >> 17;
                case 1u << 18: return dividend >> 18;
                case 1u << 19: return dividend >> 19;
                case 1u << 20: return dividend >> 20;
                case 1u << 21: return dividend >> 21;
                case 1u << 22: return dividend >> 22;
                case 1u << 23: return dividend >> 23;
                case 1u << 24: return dividend >> 24;
                case 1u << 25: return dividend >> 25;
                case 1u << 26: return dividend >> 26;
                case 1u << 27: return dividend >> 27;
                case 1u << 28: return dividend >> 28;
                case 1u << 29: return dividend >> 29;
                case 1u << 30: return dividend >> 30;
                case 1u << 31: return dividend >> 31;

                case 365: return div_uint_365(dividend);
                case 366: return div_uint_366(dividend);

                default: return new uint8(dividend.x0 / divisor, 
                                          dividend.x1 / divisor, 
                                          dividend.x2 / divisor, 
                                          dividend.x3 / divisor, 
                                          dividend.x4 / divisor, 
                                          dividend.x5 / divisor, 
                                          dividend.x6 / divisor, 
                                          dividend.x7 / divisor);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static uint8 div_uint_365(uint8 x)
        {
            ulong4 lo = x.v4_0;
            ulong4 hi = x.v4_4;

            ulong4 lo_mul = X86.Avx2.mm256_mul_epu32(lo, new ulong4(1_729_753_953ul));
            ulong4 hi_mul = X86.Avx2.mm256_mul_epu32(hi, new ulong4(1_729_753_953ul));

            uint8 castShift = X86.Avx2.mm256_permute2x128_si256(X86.Avx2.mm256_permutevar8x32_epi32(lo_mul, new v256(1, 3, 5, 7, 0, 0, 0, 0)),
                                                                X86.Avx2.mm256_permutevar8x32_epi32(hi_mul, new v256(1, 3, 5, 7, 0, 0, 0, 0)),
                                                                X86.Sse.SHUFFLE(0, 2, 0, 0));
            x -= castShift;
            x >>= 1;
            x += castShift;
            x >>= 8;

            return x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static uint8 div_uint_366(uint8 x)
        {
            ulong4 lo = x.v4_0;
            ulong4 hi = x.v4_4;

            lo = X86.Avx2.mm256_mul_epu32(lo, new ulong4(3_004_130_131ul));
            hi = X86.Avx2.mm256_mul_epu32(hi, new ulong4(3_004_130_131ul));

            x = X86.Avx2.mm256_permute2x128_si256(X86.Avx2.mm256_permutevar8x32_epi32(lo, new v256(1, 3, 5, 7, 0, 0, 0, 0)),
                                                  X86.Avx2.mm256_permutevar8x32_epi32(hi, new v256(1, 3, 5, 7, 0, 0, 0, 0)),
                                                  X86.Sse.SHUFFLE(0, 2, 0, 0));
            x >>= 8;

            return x;
        }
    }
}