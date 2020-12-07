using DevTools;
using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

namespace MaxMath
{
    unsafe internal static partial class Operator
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 shl_byte(v128 v, int n)
        {
            switch(n)
            {
                case 1:  return new byte16(0b1111_1110) & X86.Sse2.slli_epi16(v, 1);
                case 2:  return new byte16(0b1111_1100) & X86.Sse2.slli_epi16(v, 2);
                case 3:  return new byte16(0b1111_1000) & X86.Sse2.slli_epi16(v, 3);
                case 4:  return new byte16(0b1111_0000) & X86.Sse2.slli_epi16(v, 4);
                case 5:  return new byte16(0b1110_0000) & X86.Sse2.slli_epi16(v, 5);
                case 6:  return new byte16(0b1100_0000) & X86.Sse2.slli_epi16(v, 6);
                case 7:  return new byte16(0b1000_0000) & X86.Sse2.slli_epi16(v, 7);

                default: return v;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 shl_byte(v256 v, int n)
        {
            switch (n)
            {
                case 1: return new byte32(0b1111_1110) & X86.Avx2.mm256_slli_epi16(v, 1);
                case 2: return new byte32(0b1111_1100) & X86.Avx2.mm256_slli_epi16(v, 2);
                case 3: return new byte32(0b1111_1000) & X86.Avx2.mm256_slli_epi16(v, 3);
                case 4: return new byte32(0b1111_0000) & X86.Avx2.mm256_slli_epi16(v, 4);
                case 5: return new byte32(0b1110_0000) & X86.Avx2.mm256_slli_epi16(v, 5);
                case 6: return new byte32(0b1100_0000) & X86.Avx2.mm256_slli_epi16(v, 6);
                case 7: return new byte32(0b1000_0000) & X86.Avx2.mm256_slli_epi16(v, 7);
                                    
                default: return v;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 shrl_byte(v128 v, int n)
        {
            switch (n)
            {
                case 1:  return new byte16(0b0111_1111) & X86.Sse2.srli_epi16(v, 1);
                case 2:  return new byte16(0b0011_1111) & X86.Sse2.srli_epi16(v, 2);
                case 3:  return new byte16(0b0001_1111) & X86.Sse2.srli_epi16(v, 3);
                case 4:  return new byte16(0b0000_1111) & X86.Sse2.srli_epi16(v, 4);
                case 5:  return new byte16(0b0000_0111) & X86.Sse2.srli_epi16(v, 5);
                case 6:  return new byte16(0b0000_0011) & X86.Sse2.srli_epi16(v, 6);
                case 7:  return new byte16(0b0000_0001) & X86.Sse2.srli_epi16(v, 7);

                default: return v;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 shrl_byte(v256 v, int n)
        {
            switch (n)
            {
                case 1: return new byte32(0b0111_1111) & X86.Avx2.mm256_srli_epi16(v, 1);
                case 2: return new byte32(0b0011_1111) & X86.Avx2.mm256_srli_epi16(v, 2);
                case 3: return new byte32(0b0001_1111) & X86.Avx2.mm256_srli_epi16(v, 3);
                case 4: return new byte32(0b0000_1111) & X86.Avx2.mm256_srli_epi16(v, 4);
                case 5: return new byte32(0b0000_0111) & X86.Avx2.mm256_srli_epi16(v, 5);
                case 6: return new byte32(0b0000_0011) & X86.Avx2.mm256_srli_epi16(v, 6);
                case 7: return new byte32(0b0000_0001) & X86.Avx2.mm256_srli_epi16(v, 7);

                default: return v;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 shra_byte(v256 v, int n)
        {
            switch (n)
            {
                case 1: return (new byte32(0b0111_1111) & X86.Avx2.mm256_srai_epi16(v, 1)) | X86.Avx2.mm256_blendv_epi8(default(v256), new byte32(0b1000_0000), X86.Avx2.mm256_cmpgt_epi8(default(v256), v));
                case 2: return (new byte32(0b0011_1111) & X86.Avx2.mm256_srai_epi16(v, 2)) | X86.Avx2.mm256_blendv_epi8(default(v256), new byte32(0b1100_0000), X86.Avx2.mm256_cmpgt_epi8(default(v256), v));
                case 3: return (new byte32(0b0001_1111) & X86.Avx2.mm256_srai_epi16(v, 3)) | X86.Avx2.mm256_blendv_epi8(default(v256), new byte32(0b1110_0000), X86.Avx2.mm256_cmpgt_epi8(default(v256), v));
                case 4: return (new byte32(0b0000_1111) & X86.Avx2.mm256_srai_epi16(v, 4)) | X86.Avx2.mm256_blendv_epi8(default(v256), new byte32(0b1111_0000), X86.Avx2.mm256_cmpgt_epi8(default(v256), v));
                case 5: return (new byte32(0b0000_0111) & X86.Avx2.mm256_srai_epi16(v, 5)) | X86.Avx2.mm256_blendv_epi8(default(v256), new byte32(0b1111_1000), X86.Avx2.mm256_cmpgt_epi8(default(v256), v));
                case 6: return (new byte32(0b0000_0011) & X86.Avx2.mm256_srai_epi16(v, 6)) | X86.Avx2.mm256_blendv_epi8(default(v256), new byte32(0b1111_1100), X86.Avx2.mm256_cmpgt_epi8(default(v256), v));
                case 7: return (new byte32(0b0000_0001) & X86.Avx2.mm256_srai_epi16(v, 7)) | X86.Avx2.mm256_blendv_epi8(default(v256), new byte32(0b1111_1110), X86.Avx2.mm256_cmpgt_epi8(default(v256), v));

                default: return v;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 shl_short(v128 v, int n)
        {
            switch(n)
            {
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

                default: return v;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 shl_short(v256 v, int n)
        {
            switch(n)
            {
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

                default: return v;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 shrl_short(v128 v, int n)
        {
            switch (n)
            {
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

                default: return v;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 shra_short(v128 v, int n)
        {
            switch (n)
            {
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

                default: return v;
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
            long2 mask = X86.Sse2.and_si128(X86.Sse4_2.cmpgt_epi64(default(long2), v),
                                            X86.Sse4_2.cmpgt_epi64(new long2(n), default(long2)));
            mask <<= (64 - n);

            return mask | X86.Sse2.srli_epi64(v, n);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 shra_long(v256 v, int n)
        {
            long4 mask = X86.Avx2.mm256_and_si256(X86.Avx2.mm256_cmpgt_epi64(default(long4), v),
                                                  X86.Avx2.mm256_cmpgt_epi64(new long4(n), default(long4)));
            mask <<= (64 - n);

            return mask | X86.Avx2.mm256_srli_epi64(v, n);
        }
    }
}