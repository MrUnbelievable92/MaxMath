using DevTools;
using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe internal static partial class Operator
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 shl_byte(v128 v, int n)
        {
            switch(n)
            {
                case 1:  return new byte16(0b1111_1110) & Sse2.slli_epi16(v, 1);
                case 2:  return new byte16(0b1111_1100) & Sse2.slli_epi16(v, 2);
                case 3:  return new byte16(0b1111_1000) & Sse2.slli_epi16(v, 3);
                case 4:  return new byte16(0b1111_0000) & Sse2.slli_epi16(v, 4);
                case 5:  return new byte16(0b1110_0000) & Sse2.slli_epi16(v, 5);
                case 6:  return new byte16(0b1100_0000) & Sse2.slli_epi16(v, 6);
                case 7:  return new byte16(0b1000_0000) & Sse2.slli_epi16(v, 7);

                default: return v;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 shl_byte(v256 v, int n)
        {
            switch (n)
            {
                case 1: return new byte32(0b1111_1110) & Avx2.mm256_slli_epi16(v, 1);
                case 2: return new byte32(0b1111_1100) & Avx2.mm256_slli_epi16(v, 2);
                case 3: return new byte32(0b1111_1000) & Avx2.mm256_slli_epi16(v, 3);
                case 4: return new byte32(0b1111_0000) & Avx2.mm256_slli_epi16(v, 4);
                case 5: return new byte32(0b1110_0000) & Avx2.mm256_slli_epi16(v, 5);
                case 6: return new byte32(0b1100_0000) & Avx2.mm256_slli_epi16(v, 6);
                case 7: return new byte32(0b1000_0000) & Avx2.mm256_slli_epi16(v, 7);
                                    
                default: return v;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 shrl_byte(v128 v, int n)
        {
            switch (n)
            {
                case 1:  return new byte16(0b0111_1111) & Sse2.srli_epi16(v, 1);
                case 2:  return new byte16(0b0011_1111) & Sse2.srli_epi16(v, 2);
                case 3:  return new byte16(0b0001_1111) & Sse2.srli_epi16(v, 3);
                case 4:  return new byte16(0b0000_1111) & Sse2.srli_epi16(v, 4);
                case 5:  return new byte16(0b0000_0111) & Sse2.srli_epi16(v, 5);
                case 6:  return new byte16(0b0000_0011) & Sse2.srli_epi16(v, 6);
                case 7:  return new byte16(0b0000_0001) & Sse2.srli_epi16(v, 7);

                default: return v;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 shrl_byte(v256 v, int n)
        {
            switch (n)
            {
                case 1: return new byte32(0b0111_1111) & Avx2.mm256_srli_epi16(v, 1);
                case 2: return new byte32(0b0011_1111) & Avx2.mm256_srli_epi16(v, 2);
                case 3: return new byte32(0b0001_1111) & Avx2.mm256_srli_epi16(v, 3);
                case 4: return new byte32(0b0000_1111) & Avx2.mm256_srli_epi16(v, 4);
                case 5: return new byte32(0b0000_0111) & Avx2.mm256_srli_epi16(v, 5);
                case 6: return new byte32(0b0000_0011) & Avx2.mm256_srli_epi16(v, 6);
                case 7: return new byte32(0b0000_0001) & Avx2.mm256_srli_epi16(v, 7);

                default: return v;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 shra_byte(v256 v, int n)
        {
            switch (n)
            {
                case 1:
                {
                    byte32 mask = new byte32(0b1000_0000);

                    return (maxmath.andn(Avx2.mm256_srai_epi16(v, 1), mask)) | Avx2.mm256_blendv_epi8(default(v256), mask, Avx2.mm256_cmpgt_epi8(default(v256), v));
                }
                case 2:
                {
                    byte32 mask = new byte32(0b1100_0000);

                    return (maxmath.andn(Avx2.mm256_srai_epi16(v, 2), mask)) | Avx2.mm256_blendv_epi8(default(v256), mask, Avx2.mm256_cmpgt_epi8(default(v256), v));
                }
                case 3:
                {
                    byte32 mask = new byte32(0b1110_0000);

                    return (maxmath.andn(Avx2.mm256_srai_epi16(v, 3), mask)) | Avx2.mm256_blendv_epi8(default(v256), mask, Avx2.mm256_cmpgt_epi8(default(v256), v));
                }
                case 4:
                {
                    byte32 mask = new byte32(0b1111_0000);

                    return (maxmath.andn(Avx2.mm256_srai_epi16(v, 4), mask)) | Avx2.mm256_blendv_epi8(default(v256), mask, Avx2.mm256_cmpgt_epi8(default(v256), v));
                }
                case 5:
                {
                    byte32 mask = new byte32(0b1111_1000);

                    return (maxmath.andn(Avx2.mm256_srai_epi16(v, 5), mask)) | Avx2.mm256_blendv_epi8(default(v256), mask, Avx2.mm256_cmpgt_epi8(default(v256), v));
                }
                case 6:
                {
                    byte32 mask = new byte32(0b1111_1100);

                    return (maxmath.andn(Avx2.mm256_srai_epi16(v, 6), mask)) | Avx2.mm256_blendv_epi8(default(v256), mask, Avx2.mm256_cmpgt_epi8(default(v256), v));
                }
                case 7:
                {
                    byte32 mask = new byte32(0b1111_1110);

                    return (maxmath.andn(Avx2.mm256_srai_epi16(v, 7), mask)) | Avx2.mm256_blendv_epi8(default(v256), mask, Avx2.mm256_cmpgt_epi8(default(v256), v));
                }

                default: return v;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 shl_short(v128 v, int n)
        {
            return Sse2.sll_epi16(v, new v128(n, 0, 0, 0));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 shl_short(v256 v, int n)
        {
            return Avx2.mm256_sll_epi16(v, new v128(n, 0, 0, 0));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 shrl_short(v128 v, int n)
        {
            return Sse2.srl_epi16(v, new v128(n, 0, 0, 0));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 shrl_short(v256 v, int n)
        {
            return Avx2.mm256_srl_epi16(v, new v128(n, 0, 0, 0));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 shra_short(v128 v, int n)
        {
            return Sse2.sra_epi16(v, new v128(n, 0, 0, 0));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 shra_short(v256 v, int n)
        {
            return Avx2.mm256_sra_epi16(v, new v128(n, 0, 0, 0));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 shra_int(v128 v, int n)
        {
            return Sse2.sra_epi32(v, new v128(n, 0, 0, 0));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 shra_int(v256 v, int n)
        {
            return Avx2.mm256_sra_epi32(v, new v128(n, 0, 0, 0));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 shrl_int(v128 v, int n)
        {
            return Sse2.srl_epi32(v, new v128(n, 0, 0, 0));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 shrl_int(v256 v, int n)
        {
            
            return Avx2.mm256_srl_epi32(v, new v128(n, 0, 0, 0));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 shl_int(v256 v, int n)
        {
            return Avx2.mm256_sll_epi32(v, new v128(n, 0, 0, 0));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 shl_long(v128 v, int n)
        {
            return Sse2.sll_epi64(v, new v128(n, 0, 0, 0));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 shl_long(v256 v, int n)
        {
            return Avx2.mm256_sll_epi64(v, new v128(n, 0, 0, 0));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 shrl_long(v128 v, int n)
        {
            return Sse2.srl_epi64(v, new v128(n, 0, 0, 0));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 shrl_long(v256 v, int n)
        {
            return Avx2.mm256_srl_epi64(v, new v128(n, 0, 0, 0));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static long2 shra_long(long2 v, int n)
        {
            v128 shiftLo;
            v128 shiftHi;


            if (n <= 32)
            {
                if (n == 0)
                {
                    return v;
                }
                else
                {
                    shiftHi = shra_int(v, n);
                    shiftLo = shrl_long(v, n);
                }
            }
            else
            {
                shiftHi = shra_int(v, 31);
                shiftLo = shra_int(v, n - 32);
                shiftLo = shra_long(shiftLo, 32);
            }


            return Sse4_1.blend_epi16(shiftLo, shiftHi, 0b1100_1100);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 shra_long(v256 v, int n)
        {
            v256 shiftLo;
            v256 shiftHi;
           

            if (n <= 32)
            {
                if (n == 0)
                {
                    return v;
                }
                else
                {
                    shiftHi = shra_int(v, n);
                    shiftLo = shrl_long(v, n);
                }
            }
            else
            {
                shiftHi = shra_int(v, 31);
                shiftLo = shra_int(v, n - 32);
                shiftLo = shra_long(shiftLo, 32);
            }


            return Avx2.mm256_blend_epi32(shiftLo, shiftHi, 0b1010_1010);
        }
    }
}