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
            if (Avx2.IsAvx2Supported)
            {
                byte3 temp = (byte3)(1 & shrl(mask, new int3(0, 1, 2)));

                return *(bool3*)&temp;
            }
            else
            {
                return tobool(1 & new byte3((byte)mask, (byte)(mask >> 1), (byte)(mask >> 2)));
            }
        }

        /// <summary>       Returns a bool4 vector from the first 4 bits of an int value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 tobool4(int mask)
        {
            if (Avx2.IsAvx2Supported)
            {
                byte4 temp = (byte4)(1 & shrl(mask, new int4(0, 1, 2, 3)));

                return *(bool4*)&temp;
            }
            else
            {
                return tobool(1 & new byte4((byte)mask, (byte)(mask >> 1), (byte)(mask >> 2), (byte)(mask >> 3)));
            }
        }

        /// <summary>       Returns a bool8 vector from the first 8 bits of an int value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 tobool8(int mask)
        {
            if (Avx2.IsAvx2Supported)
            {
                return tobool(((byte8)(1 & shrl(mask, new int8(0, 1, 2, 3, 4, 5, 6, 7)))));
            }
            else
            {
                return tobool(1 & new byte8((byte)mask, (byte)(mask >> 1), (byte)(mask >> 2), (byte)(mask >> 3), (byte)(mask >> 4), (byte)(mask >> 5), (byte)(mask >> 6), (byte)(mask >> 7)));
            }
        }

        /// <summary>       Returns a bool16 vector from the first 16 bits of an int value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 tobool16(int mask)
        {
            if (Avx2.IsAvx2Supported)
            {
Assert.IsBetween(mask, 0, ushort.MaxValue);

                int8 broadcast = mask;

                ushort16 shufCast = Avx2.mm256_packus_epi32(shrl(broadcast, new int8(0, 1, 2, 3, 4, 5, 6, 7)),  
                                                            shrl(broadcast, new int8(8, 9, 10, 11, 12, 13, 14, 15)));

                byte16 result = 1 & (byte16)Avx.mm256_castsi256_si128(Avx2.mm256_permutevar8x32_epi32(Avx2.mm256_shuffle_epi8(shufCast, new v256(0, 2, 4, 6, 8, 10, 12, 14, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 4, 6, 8, 10, 12, 14, 0, 0, 0, 0, 0, 0, 0, 0)),
                                                                                                      Avx.mm256_castsi128_si256(new v128(0, 4, 1, 5))));
                return (v128)result;
            }
            else
            {
                return tobool(1 & new byte16((byte)mask, (byte)(mask >> 1), (byte)(mask >> 2), (byte)(mask >> 3), (byte)(mask >> 4), (byte)(mask >> 5), (byte)(mask >> 6), (byte)(mask >> 7), (byte)(mask >> 8), (byte)(mask >> 9), (byte)(mask >> 10), (byte)(mask >> 11), (byte)(mask >> 12), (byte)(mask >> 13), (byte)(mask >> 14), (byte)(mask >> 15)));
            }
        }

        /// <summary>       Returns a bool32 vector from the bits of an int value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 tobool32(int mask)
        {
            if (Avx2.IsAvx2Supported)
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
            else
            {
                return tobool(1 & new byte32((byte)mask, (byte)(mask >> 1), (byte)(mask >> 2), (byte)(mask >> 3), (byte)(mask >> 4), (byte)(mask >> 5), (byte)(mask >> 6), (byte)(mask >> 7), (byte)(mask >> 8), (byte)(mask >> 9), (byte)(mask >> 10), (byte)(mask >> 11), (byte)(mask >> 12), (byte)(mask >> 13), (byte)(mask >> 14), (byte)(mask >> 15), (byte)(mask >> 16), (byte)(mask >> 17), (byte)(mask >> 18), (byte)(mask >> 19), (byte)(mask >> 20), (byte)(mask >> 21), (byte)(mask >> 22), (byte)(mask >> 23), (byte)(mask >> 24), (byte)(mask >> 25), (byte)(mask >> 26), (byte)(mask >> 27), (byte)(mask >> 28), (byte)(mask >> 29), (byte)(mask >> 30), (byte)(mask >> 31)));
            }
        }
    }
}