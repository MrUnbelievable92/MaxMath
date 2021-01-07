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
        public static bool2 tobool2(int mask)
        {
Assert.IsBetween(mask, 0, 3);

            int result = 0x0101 & (mask | (mask << 7));

            return *(bool2*)&result;
        }

        /// <summary>       Returns a bool3 vector from the first 3 bits of an int value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 tobool3(int mask)
        {
            byte3 temp = (byte3)(1 & shrl(mask, new int3(0, 1, 2)));

            return *(bool3*)&temp;
        }

        /// <summary>       Returns a bool4 vector from the first 4 bits of an int value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 tobool4(int mask)
        {
            byte4 temp = (byte4)(1 & shrl(mask, new int4(0, 1, 2, 3)));

            return *(bool4*)&temp;
        }

        /// <summary>       Returns a bool8 vector from the first 8 bits of an int value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 tobool8(int mask)
        {
            return (v128)((byte8)(1 & shrl(mask, new int8(0, 1, 2, 3, 4, 5, 6, 7))));
        }

        /// <summary>       Returns a bool16 vector from the first 16 bits of an int value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 tobool16(int mask)
        {
Assert.IsBetween(mask, 0, ushort.MaxValue);

            int8 broadcast = mask;

            ushort16 shufCast = Avx2.mm256_packus_epi32(shrl(broadcast, new int8(0, 1, 2, 3, 4, 5, 6, 7)),  
                                                        shrl(broadcast, new int8(8, 9, 10, 11, 12, 13, 14, 15)));

            byte16 result = 1 & (byte16)Avx.mm256_castsi256_si128(Avx2.mm256_permutevar8x32_epi32(Avx2.mm256_shuffle_epi8(shufCast, new v256(0, 2, 4, 6, 8, 10, 12, 14, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 4, 6, 8, 10, 12, 14, 0, 0, 0, 0, 0, 0, 0, 0)),
                                                                                                  Avx.mm256_castsi128_si256(new v128(0, 4, 1, 5))));
            return (v128)result;
        }

        /// <summary>       Returns a bool32 vector from the bits of an int value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 tobool32(int mask)
        {
            int8 broadcast = mask;

            ushort16 hi = Avx2.mm256_packus_epi32(1 & shrl(broadcast, new int8(0, 1, 2, 3, 4, 5, 6, 7)),
                                                  1 & shrl(broadcast, new int8(8, 9, 10, 11, 12, 13, 14, 15)));
            ushort16 lo = 1 & (ushort16)Avx2.mm256_packus_epi32(shrl(broadcast, new int8(16, 17, 18, 19, 20, 21, 22, 23)),
                                                                shrl(broadcast, new int8(24, 25, 26, 27, 28, 29, 30, 31)));

            byte32 result = X86.Avx2.mm256_permutevar8x32_epi32(Avx2.mm256_packus_epi16(hi, lo),
                                                                new v256(0, 4, 1, 5, 2, 6, 3, 7));

            return (v256)result;
        }
    }
}