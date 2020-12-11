using DevTools;
using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns a bool2 vector from the first two bits of an int value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 mask2bool2(int imm8)
        {
Assert.IsBetween(imm8, 0, 3);

            int result = 0x0101 & (imm8 | (imm8 << 7));

            return *(bool2*)&result;
        }

        /// <summary>       Returns a bool3 vector from the first 3 bits of an int value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 mask2bool3(int imm8)
        {
            return cvt_boolean(1 & shr_l(imm8, new int3(0, 1, 2)));
        }

        /// <summary>       Returns a bool4 vector from the first 4 bits of an int value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 mask2bool4(int imm8)
        {
            return cvt_boolean(1 & shr_l(imm8, new int4(0, 1, 2, 3)));
        }

        /// <summary>       Returns a bool8 vector from the first 8 bits of an int value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 mask2bool8(int imm8)
        {
            return cvt_boolean(1 & shr_l(imm8, new int8(0, 1, 2, 3, 4, 5, 6, 7)));
        }

        /// <summary>       Returns a bool16 vector from the first 16 bits of an int value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 mask2bool16(int imm8)
        {
Assert.IsBetween(imm8, 0, ushort.MaxValue);

            int8 broadcast = imm8;

            ushort16 shufCast = Avx2.mm256_packus_epi32(shr_l(broadcast, new int8(0, 1, 2, 3, 4, 5, 6, 7)),  
                                                        shr_l(broadcast, new int8(8, 9, 10, 11, 12, 13, 14, 15)));

            byte16 result = 1 & (byte16)Avx.mm256_castsi256_si128(Avx2.mm256_permutevar8x32_epi32(Avx2.mm256_shuffle_epi8(shufCast, new v256(0, 2, 4, 6, 8, 10, 12, 14, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 4, 6, 8, 10, 12, 14, 0, 0, 0, 0, 0, 0, 0, 0)),
                                                                                                  new v256(0, 4, 1, 5,   0,0,0,0)));
            return cvt_boolean(result);
        }

        /// <summary>       Returns a bool32 vector from the bits of an int value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 mask2bool32(int imm8)
        {
            int8 broadcast = imm8;

            byte32 result = X86.Avx2.mm256_packus_epi16(X86.Avx2.mm256_packus_epi32(1 & maxmath.shr_l(broadcast, new int8(0, 1, 2, 3, 4, 5, 6, 7)),
                                                                                    1 & maxmath.shr_l(broadcast, new int8(8, 9, 10, 11, 12, 13, 14, 15))),
                                                        1 & (ushort16)X86.Avx2.mm256_packus_epi32(maxmath.shr_l(broadcast, new int8(16, 17, 18, 19, 20, 21, 22, 23)),
                                                                                                  maxmath.shr_l(broadcast, new int8(24, 25, 26, 27, 28, 29, 30, 31))));

            result = X86.Avx2.mm256_permutevar8x32_epi32(result, new v256(0, 4, 1, 5, 2, 6, 3, 7));

            return cvt_boolean(result);
        }
    }
}