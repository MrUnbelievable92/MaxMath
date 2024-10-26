using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    namespace Intrinsics
    {
        unsafe public static partial class Xse
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 bsr_epi8(v128 a)
            {
                if (Architecture.IsSIMDSupported)
                {
                    v128 result;
                    
                    if (Ssse3.IsSsse3Supported)
                    {
                        v128 SHUFFLE_MASK_LO = new v128(-1, 0, 1, 1, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 3, 3);
                        v128 SHUFFLE_MASK_HI = new v128(-1, 4, 5, 5, 6, 6, 6, 6, 7, 7, 7, 7, 7, 7, 7, 7);

                        result = max_epi8(shuffle_epi8(SHUFFLE_MASK_LO, and_si128(NIBBLE_MASK, a)),
                                          shuffle_epi8(SHUFFLE_MASK_HI, and_si128(NIBBLE_MASK, srli_epi16(a, 4))));
                    }
                    else
                    {
                        result = sub_epi8(set1_epi8(7), lzcnt_epi8(a));
                    }

                    constexpr.ASSUME_RANGE_EPI8(result, -1, 7);
                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_bsr_epi8(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 SHUFFLE_MASK_LO = new v256(-1, 0, 1, 1, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 3, 3,
                                                    -1, 0, 1, 1, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 3, 3);
                    v256 SHUFFLE_MASK_HI = new v256(-1, 4, 5, 5, 6, 6, 6, 6, 7, 7, 7, 7, 7, 7, 7, 7,
                                                    -1, 4, 5, 5, 6, 6, 6, 6, 7, 7, 7, 7, 7, 7, 7, 7);

                    v256 result = Avx2.mm256_max_epi8(Avx2.mm256_shuffle_epi8(SHUFFLE_MASK_LO, Avx2.mm256_and_si256(MM256_NIBBLE_MASK, a)),
                                                      Avx2.mm256_shuffle_epi8(SHUFFLE_MASK_HI, Avx2.mm256_and_si256(MM256_NIBBLE_MASK, Avx2.mm256_srli_epi16(a, 4))));
                    
                    constexpr.ASSUME_RANGE_EPI8(result, -1, 7);
                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 bsrp1_epi8(v128 a)
            {
                if (Architecture.IsSIMDSupported)
                {
                    v128 result;
                    
                    if (Ssse3.IsSsse3Supported)
                    {
                        v128 SHUFFLE_MASK_LO = new v128(0, 1, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4, 4, 4);
                        v128 SHUFFLE_MASK_HI = new v128(0, 5, 6, 6, 7, 7, 7, 7, 8, 8, 8, 8, 8, 8, 8, 8);
                    
                        result = max_epu8(shuffle_epi8(SHUFFLE_MASK_LO, and_si128(NIBBLE_MASK, a)),
                                          shuffle_epi8(SHUFFLE_MASK_HI, and_si128(NIBBLE_MASK, srli_epi16(a, 4))));
                    }
                    else
                    {
                        result = sub_epi8(set1_epi8(8), lzcnt_epi8(a));
                    }

                    constexpr.ASSUME_LE_EPU8(result, 8);
                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_bsrp1_epi8(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 SHUFFLE_MASK_LO = new v256(0, 1, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4, 4, 4,
                                                    0, 1, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4, 4, 4);
                    v256 SHUFFLE_MASK_HI = new v256(0, 5, 6, 6, 7, 7, 7, 7, 8, 8, 8, 8, 8, 8, 8, 8,
                                                    0, 5, 6, 6, 7, 7, 7, 7, 8, 8, 8, 8, 8, 8, 8, 8);

                    v256 result = Avx2.mm256_max_epu8(Avx2.mm256_shuffle_epi8(SHUFFLE_MASK_LO, Avx2.mm256_and_si256(MM256_NIBBLE_MASK, a)),
                                                      Avx2.mm256_shuffle_epi8(SHUFFLE_MASK_HI, Avx2.mm256_and_si256(MM256_NIBBLE_MASK, Avx2.mm256_srli_epi16(a, 4))));
                    
                    constexpr.ASSUME_LE_EPU8(result, 8);
                    return result;
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Computes the ceiling of the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 ceillog2(UInt128 x)
        {
            return (uint)(128 - lzcnt(x - 1));
        }

        /// <summary>       Computes the ceiling of the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 ceillog2(Int128 x)
        {
            return (Int128)ceillog2((UInt128)x);
        }


        /// <summary>       Computes the ceiling of the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [return: AssumeRange(0ul, 8ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte ceillog2(byte x)
        {
            return (byte)(8 - lzcnt((byte)(x - 1)));
        }

        /// <summary>       Computes the componentwise ceiling of the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 ceillog2(byte2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.bsrp1_epi8(x - 1);
            }
            else
            {
                return 8 - lzcnt(x - 1);
            }
        }

        /// <summary>       Computes the componentwise ceiling of the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 ceillog2(byte3 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.bsrp1_epi8(x - 1);
            }
            else
            {
                return 8 - lzcnt(x - 1);
            }
        }

        /// <summary>       Computes the componentwise ceiling of the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 ceillog2(byte4 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.bsrp1_epi8(x - 1);
            }
            else
            {
                return 8 - lzcnt(x - 1);
            }
        }

        /// <summary>       Computes the componentwise ceiling of the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 ceillog2(byte8 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.bsrp1_epi8(x - 1);
            }
            else
            {
                return 8 - lzcnt(x - 1);
            }
        }

        /// <summary>       Computes the componentwise ceiling of the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 ceillog2(byte16 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.bsrp1_epi8(x - 1);
            }
            else
            {
                return 8 - lzcnt(x - 1);
            }
        }

        /// <summary>       Computes the componentwise ceiling of the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 ceillog2(byte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_bsrp1_epi8(x - 1);
            }
            else
            {
                return new byte32(ceillog2(x.v16_0), ceillog2(x.v16_16));
            }
        }


        /// <summary>       Computes the ceiling of the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [return: AssumeRange(0, 8)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte ceillog2(sbyte x)
        {
            return (sbyte)ceillog2((byte)x);
        }

        /// <summary>       Computes the componentwise ceiling of the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 ceillog2(sbyte2 x)
        {
            return (sbyte2)ceillog2((byte2)x);
        }

        /// <summary>       Computes the componentwise ceiling of the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 ceillog2(sbyte3 x)
        {
            return (sbyte3)ceillog2((byte3)x);
        }

        /// <summary>       Computes the componentwise ceiling of the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 ceillog2(sbyte4 x)
        {
            return (sbyte4)ceillog2((byte4)x);
        }

        /// <summary>       Computes the componentwise ceiling of the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 ceillog2(sbyte8 x)
        {
            return (sbyte8)ceillog2((byte8)x);
        }

        /// <summary>       Computes the componentwise ceiling of the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 ceillog2(sbyte16 x)
        {
            return (sbyte16)ceillog2((byte16)x);
        }

        /// <summary>       Computes the componentwise ceiling of the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 ceillog2(sbyte32 x)
        {
            return (sbyte32)ceillog2((byte32)x);
        }


        /// <summary>       Computes the ceiling of the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [return: AssumeRange(0ul, 16ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort ceillog2(ushort x)
        {
            return (ushort)(16 - lzcnt((ushort)(x - 1)));
        }

        /// <summary>       Computes the componentwise ceiling of the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 ceillog2(ushort2 x)
        {
            return 16 - lzcnt(x - 1);
        }

        /// <summary>       Computes the componentwise ceiling of the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 ceillog2(ushort3 x)
        {
            return 16 - lzcnt(x - 1);
        }

        /// <summary>       Computes the componentwise ceiling of the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 ceillog2(ushort4 x)
        {
            return 16 - lzcnt(x - 1);
        }

        /// <summary>       Computes the componentwise ceiling of the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 ceillog2(ushort8 x)
        {
            return 16 - lzcnt(x - 1);
        }

        /// <summary>       Computes the componentwise ceiling of the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 ceillog2(ushort16 x)
        {
            return 16 - lzcnt(x - 1);
        }


        /// <summary>       Computes the ceiling of the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [return: AssumeRange(0, 16)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short ceillog2(short x)
        {
            return (short)ceillog2((ushort)x);
        }

        /// <summary>       Computes the componentwise ceiling of the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 ceillog2(short2 x)
        {
            return (short2)ceillog2((ushort2)x);
        }

        /// <summary>       Computes the componentwise ceiling of the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 ceillog2(short3 x)
        {
            return (short3)ceillog2((ushort3)x);
        }

        /// <summary>       Computes the componentwise ceiling of the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 ceillog2(short4 x)
        {
            return (short4)ceillog2((ushort4)x);
        }

        /// <summary>       Computes the componentwise ceiling of the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 ceillog2(short8 x)
        {
            return (short8)ceillog2((ushort8)x);
        }

        /// <summary>       Computes the componentwise ceiling of the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 ceillog2(short16 x)
        {
            return (short16)ceillog2((ushort16)x);
        }


        /// <summary>       Computes the componentwise ceiling of the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 ceillog2(uint8 x)
        {
            return (uint8)(32 - lzcnt(x - 1));
        }


        /// <summary>       Computes the componentwise ceiling of the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 ceillog2(int8 x)
        {
            return (int8)ceillog2((uint8)x);
        }


        /// <summary>       Computes the ceiling of the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [return: AssumeRange(0ul, 64ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong ceillog2(ulong x)
        {
            return (ulong)(64 - math.lzcnt(x - 1));
        }

        /// <summary>       Computes the componentwise ceiling of the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 ceillog2(ulong2 x)
        {
            return 64 - lzcnt(x - 1);
        }

        /// <summary>       Computes the componentwise ceiling of the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 ceillog2(ulong3 x)
        {
            return 64 - lzcnt(x - 1);
        }

        /// <summary>       Computes the componentwise ceiling of the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 ceillog2(ulong4 x)
        {
            return 64 - lzcnt(x - 1);
        }


        /// <summary>       Computes the ceiling of the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [return: AssumeRange(0L, 64L)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long ceillog2(long x)
        {
            return (long)ceillog2((ulong)x);
        }

        /// <summary>       Computes the componentwise ceiling of the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 ceillog2(long2 x)
        {
            return (long2)ceillog2((ulong2)x);
        }

        /// <summary>       Computes the componentwise ceiling of the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 ceillog2(long3 x)
        {
            return (long3)ceillog2((ulong3)x);
        }

        /// <summary>       Computes the componentwise ceiling of the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 ceillog2(long4 x)
        {
            return (long4)ceillog2((ulong4)x);
        }


        /// <summary>       Computes the floor of the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 floorlog2(Int128 x)
        {
            if (constexpr.IS_TRUE(x.hi64 == 0))
            {
                return floorlog2(x.lo64);
            }

            return 127 - lzcnt(x);
        }

        /// <summary>       Computes the floor of the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 floorlog2(UInt128 x)
        {
            if (constexpr.IS_TRUE(x.hi64 == 0))
            {
                return floorlog2(x.lo64);
            }

            return (uint)(127 - lzcnt(x));
        }


        /// <summary>       Computes the floor of the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte floorlog2(byte x)
        {
            return (byte)(7 - lzcnt((byte)(x)));
        }

        /// <summary>       Computes the componentwise floor of the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 floorlog2(byte2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.bsr_epi8(x);
            }
            else
            {
                return 7 - lzcnt(x);
            }
        }

        /// <summary>       Computes the componentwise floor of the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 floorlog2(byte3 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.bsr_epi8(x);
            }
            else
            {
                return 7 - lzcnt(x);
            }
        }

        /// <summary>       Computes the componentwise floor of the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 floorlog2(byte4 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.bsr_epi8(x);
            }
            else
            {
                return 7 - lzcnt(x);
            }
        }

        /// <summary>       Computes the componentwise floor of the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 floorlog2(byte8 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.bsr_epi8(x);
            }
            else
            {
                return 7 - lzcnt(x);
            }
        }

        /// <summary>       Computes the componentwise floor of the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 floorlog2(byte16 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.bsr_epi8(x);
            }
            else
            {
                return 7 - lzcnt(x);
            }
        }

        /// <summary>       Computes the componentwise floor of the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 floorlog2(byte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_bsr_epi8(x);
            }
            else
            {
                return new byte32(floorlog2(x.v16_0), floorlog2(x.v16_16));
            }
        }


        /// <summary>       Computes the floor of the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte floorlog2(sbyte x)
        {
            return (sbyte)floorlog2((byte)x);
        }

        /// <summary>       Computes the componentwise floor of the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 floorlog2(sbyte2 x)
        {
            return (sbyte2)floorlog2((byte2)x);
        }

        /// <summary>       Computes the componentwise floor of the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 floorlog2(sbyte3 x)
        {
            return (sbyte3)floorlog2((byte3)x);
        }

        /// <summary>       Computes the componentwise floor of the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 floorlog2(sbyte4 x)
        {
            return (sbyte4)floorlog2((byte4)x);
        }

        /// <summary>       Computes the componentwise floor of the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 floorlog2(sbyte8 x)
        {
            return (sbyte8)floorlog2((byte8)x);
        }

        /// <summary>       Computes the componentwise floor of the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 floorlog2(sbyte16 x)
        {
            return (sbyte16)floorlog2((byte16)x);
        }

        /// <summary>       Computes the componentwise floor of the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 floorlog2(sbyte32 x)
        {
            return (sbyte32)floorlog2((byte32)x);
        }


        /// <summary>       Computes the floor of the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort floorlog2(ushort x)
        {
            return (ushort)(15 - lzcnt(x));
        }

        /// <summary>       Computes the componentwise floor of the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 floorlog2(ushort2 x)
        {
            return 15 - lzcnt(x);
        }

        /// <summary>       Computes the componentwise floor of the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 floorlog2(ushort3 x)
        {
            return 15 - lzcnt(x);
        }

        /// <summary>       Computes the componentwise floor of the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 floorlog2(ushort4 x)
        {
            return 15 - lzcnt(x);
        }

        /// <summary>       Computes the componentwise floor of the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 floorlog2(ushort8 x)
        {
            return 15 - lzcnt(x);
        }

        /// <summary>       Computes the componentwise floor of the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 floorlog2(ushort16 x)
        {
            return 15 - lzcnt(x);
        }


        /// <summary>       Computes the floor of the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short floorlog2(short x)
        {
            return (short)floorlog2((ushort)x);
        }

        /// <summary>       Computes the componentwise floor of the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 floorlog2(short2 x)
        {
            return (short2)floorlog2((ushort2)x);
        }

        /// <summary>       Computes the componentwise floor of the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 floorlog2(short3 x)
        {
            return (short3)floorlog2((ushort3)x);
        }

        /// <summary>       Computes the componentwise floor of the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 floorlog2(short4 x)
        {
            return (short4)floorlog2((ushort4)x);
        }

        /// <summary>       Computes the componentwise floor of the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 floorlog2(short8 x)
        {
            return (short8)floorlog2((ushort8)x);
        }

        /// <summary>       Computes the componentwise floor of the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 floorlog2(short16 x)
        {
            return (short16)floorlog2((ushort16)x);
        }


        /// <summary>       Computes the componentwise floor of the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 floorlog2(uint8 x)
        {
            return (uint8)(31 - lzcnt(x));
        }


        /// <summary>       Computes the componentwise floor of the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 floorlog2(int8 x)
        {
            return (int8)floorlog2((uint8)x);
        }


        /// <summary>       Computes the floor of the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong floorlog2(ulong x)
        {
            return (ulong)(63 - math.lzcnt(x));
        }

        /// <summary>       Computes the componentwise floor of the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 floorlog2(ulong2 x)
        {
            return 63 - lzcnt(x);
        }

        /// <summary>       Computes the componentwise floor of the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 floorlog2(ulong3 x)
        {
            return 63 - lzcnt(x);
        }

        /// <summary>       Computes the componentwise floor of the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 floorlog2(ulong4 x)
        {
            return 63 - lzcnt(x);
        }


        /// <summary>       Computes the floor of the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long floorlog2(long x)
        {
            return (long)floorlog2((ulong)x);
        }

        /// <summary>       Computes the componentwise floor of the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 floorlog2(long2 x)
        {
            return (long2)floorlog2((ulong2)x);
        }

        /// <summary>       Computes the componentwise floor of the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 floorlog2(long3 x)
        {
            return (long3)floorlog2((ulong3)x);
        }

        /// <summary>       Computes the componentwise floor of the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 floorlog2(long4 x)
        {
            return (long4)floorlog2((ulong4)x);
        }


        /// <summary>       Computes the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 intlog2(Int128 x)
        {
            if (constexpr.IS_TRUE(x.hi64 == 0))
            {
                return intlog2(x.lo64);
            }

            return 127 - lzcnt(x);
        }

        /// <summary>       Computes the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 intlog2(UInt128 x)
        {
            if (constexpr.IS_TRUE(x.hi64 == 0))
            {
                return intlog2(x.lo64);
            }

            return (uint)(127 - lzcnt(x));
        }


        /// <summary>       Computes the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte intlog2(byte x)
        {
            return (byte)(7 - lzcnt((byte)(x)));
        }

        /// <summary>       Computes the componentwise base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 intlog2(byte2 x)
        {
            return 7 - lzcnt(x);
        }

        /// <summary>       Computes the componentwise base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 intlog2(byte3 x)
        {
            return 7 - lzcnt(x);
        }

        /// <summary>       Computes the componentwise base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 intlog2(byte4 x)
        {
            return 7 - lzcnt(x);
        }

        /// <summary>       Computes the componentwise base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 intlog2(byte8 x)
        {
            return 7 - lzcnt(x);
        }

        /// <summary>       Computes the componentwise base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 intlog2(byte16 x)
        {
            return 7 - lzcnt(x);
        }

        /// <summary>       Computes the componentwise base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 intlog2(byte32 x)
        {
            return 7 - lzcnt(x);
        }


        /// <summary>       Computes the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte intlog2(sbyte x)
        {
            return (sbyte)intlog2((byte)x);
        }

        /// <summary>       Computes the componentwise base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 intlog2(sbyte2 x)
        {
            return (sbyte2)intlog2((byte2)x);
        }

        /// <summary>       Computes the componentwise base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 intlog2(sbyte3 x)
        {
            return (sbyte3)intlog2((byte3)x);
        }

        /// <summary>       Computes the componentwise base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 intlog2(sbyte4 x)
        {
            return (sbyte4)intlog2((byte4)x);
        }

        /// <summary>       Computes the componentwise base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 intlog2(sbyte8 x)
        {
            return (sbyte8)intlog2((byte8)x);
        }

        /// <summary>       Computes the componentwise base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 intlog2(sbyte16 x)
        {
            return (sbyte16)intlog2((byte16)x);
        }

        /// <summary>       Computes the componentwise base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 intlog2(sbyte32 x)
        {
            return (sbyte32)intlog2((byte32)x);
        }


        /// <summary>       Computes the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort intlog2(ushort x)
        {
            return (ushort)(15 - lzcnt(x));
        }

        /// <summary>       Computes the componentwise base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 intlog2(ushort2 x)
        {
            return 15 - lzcnt(x);
        }

        /// <summary>       Computes the componentwise base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 intlog2(ushort3 x)
        {
            return 15 - lzcnt(x);
        }

        /// <summary>       Computes the componentwise base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 intlog2(ushort4 x)
        {
            return 15 - lzcnt(x);
        }

        /// <summary>       Computes the componentwise base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 intlog2(ushort8 x)
        {
            return 15 - lzcnt(x);
        }

        /// <summary>       Computes the componentwise base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 intlog2(ushort16 x)
        {
            return 15 - lzcnt(x);
        }


        /// <summary>       Computes the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short intlog2(short x)
        {
            return (short)intlog2((ushort)x);
        }

        /// <summary>       Computes the componentwise base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 intlog2(short2 x)
        {
            return (short2)intlog2((ushort2)x);
        }

        /// <summary>       Computes the componentwise base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 intlog2(short3 x)
        {
            return (short3)intlog2((ushort3)x);
        }

        /// <summary>       Computes the componentwise base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 intlog2(short4 x)
        {
            return (short4)intlog2((ushort4)x);
        }

        /// <summary>       Computes the componentwise base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 intlog2(short8 x)
        {
            return (short8)intlog2((ushort8)x);
        }

        /// <summary>       Computes the componentwise base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 intlog2(short16 x)
        {
            return (short16)intlog2((ushort16)x);
        }


        /// <summary>       Computes the componentwise base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint intlog2(uint x)
        {
            return (uint)math.floorlog2((uint)x);
        }

        /// <summary>       Computes the componentwise base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 intlog2(uint2 x)
        {
            return (uint2)math.floorlog2((uint2)x);
        }

        /// <summary>       Computes the componentwise base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 intlog2(uint3 x)
        {
            return (uint3)math.floorlog2((uint3)x);
        }

        /// <summary>       Computes the componentwise base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 intlog2(uint4 x)
        {
            return (uint4)math.floorlog2((uint4)x);
        }

        /// <summary>       Computes the componentwise base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 intlog2(uint8 x)
        {
            return (uint8)floorlog2((uint8)x);
        }


        /// <summary>       Computes the componentwise base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int intlog2(int x)
        {
            return (int)math.floorlog2((uint)x);
        }

        /// <summary>       Computes the componentwise base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 intlog2(int2 x)
        {
            return (int2)math.floorlog2((uint2)x);
        }

        /// <summary>       Computes the componentwise base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 intlog2(int3 x)
        {
            return (int3)math.floorlog2((uint3)x);
        }

        /// <summary>       Computes the componentwise base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 intlog2(int4 x)
        {
            return (int4)math.floorlog2((uint4)x);
        }

        /// <summary>       Computes the componentwise base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 intlog2(int8 x)
        {
            return (int8)floorlog2((uint8)x);
        }


        /// <summary>       Computes the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong intlog2(ulong x)
        {
            return (ulong)(63 - math.lzcnt(x));
        }

        /// <summary>       Computes the componentwise base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 intlog2(ulong2 x)
        {
            return 63 - lzcnt(x);
        }

        /// <summary>       Computes the componentwise base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 intlog2(ulong3 x)
        {
            return 63 - lzcnt(x);
        }

        /// <summary>       Computes the componentwise base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 intlog2(ulong4 x)
        {
            return 63 - lzcnt(x);
        }


        /// <summary>       Computes the base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long intlog2(long x)
        {
            return (long)intlog2((ulong)x);
        }

        /// <summary>       Computes the componentwise base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 intlog2(long2 x)
        {
            return (long2)intlog2((ulong2)x);
        }

        /// <summary>       Computes the componentwise base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 intlog2(long3 x)
        {
            return (long3)intlog2((ulong3)x);
        }

        /// <summary>       Computes the componentwise base-2 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 intlog2(long4 x)
        {
            return (long4)intlog2((ulong4)x);
        }
    }
}