using DevTools;
using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 mask_to_bool2(int imm8)
        {
Assert.IsBetween(imm8, 0, 3);

            int result = 0b0000_0001_0000_0001 & (imm8 | (imm8 << 7));

            return *(bool2*)&result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 mask_to_bool3(int imm8)
        {
            byte3 result = (byte3)(1 & shr_l(imm8, new int3(0, 1, 2)));

            return *(bool3*)&result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 mask_to_bool4(int imm8)
        {
            byte4 result = (byte4)(1 & shr_l(imm8, new int4(0, 1, 2, 3)));

            return *(bool4*)&result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x2 mask_to_bool4x2(int imm8)
        {
            byte8 result = (byte8)(1 & shr_l(imm8, new int8(0, 1, 2, 3, 4, 5, 6, 7)));

            return *(bool4x2*)&result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x4 mask_to_bool4x4(int imm8)
        {
Assert.IsBetween(imm8, 0, ushort.MaxValue);

            int8 broadcast = imm8;

            ushort16 shufCast = X86.Avx2.mm256_packus_epi32(shr_l(broadcast, new int8(0, 1, 2, 3, 4, 5, 6, 7)),  
                                                            shr_l(broadcast, new int8(8, 9, 10, 11, 12, 13, 14, 15)));

            byte16 result = 1 & (byte16)X86.Avx.mm256_castsi256_si128(X86.Avx2.mm256_permutevar8x32_epi32(X86.Avx2.mm256_shuffle_epi8(shufCast, new v256(0, 2, 4, 6, 8, 10, 12, 14, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 4, 6, 8, 10, 12, 14, 0, 0, 0, 0, 0, 0, 0, 0)),
                                                                                                          new v256(0, 4, 1, 5,   0,0,0,0)));
            return *(bool4x4*)&result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 mask_to_bool32(int imm8)
        {
            int8 broadcast = imm8;

            byte32 result = X86.Avx2.mm256_packus_epi16(X86.Avx2.mm256_packus_epi32(1 & shr_l(broadcast, new int8(0, 1, 2, 3, 4, 5, 6, 7)),
                                                                                    1 & shr_l(broadcast, new int8(8, 9, 10, 11, 12, 13, 14, 15))),   
                                                       1 & (ushort16)X86.Avx2.mm256_packus_epi32(shr_l(broadcast, new int8(16, 17, 18, 19, 20, 21, 22, 23)),
                                                                                                 shr_l(broadcast, new int8(24, 25, 26, 27, 28, 29, 30, 31))));
            result = X86.Avx2.mm256_permutevar8x32_epi32(result, new v256(0, 4, 1, 5, 2, 6, 3, 7));

            return *(bool32*)&result;
        }
    }
}