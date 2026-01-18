using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns <see langword="true"/> if <paramref name="a"/> and <paramref name="b"/> do not share any components with each other.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(byte2 a, byte2 b)
        {
            return !math.any(a.xyxy == b.xxyy);
        }

        /// <summary>       Returns <see langword="true"/> if <paramref name="a"/> and <paramref name="b"/> do not share any components with each other.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(byte3 a, byte3 b)
        {
            if (BurstArchitecture.IsTableLookupSupported)
            {
                return Xse.allfalse_epi128<byte>(Xse.cmpeq_epi8(Xse.shuffle_epi8(a, new v128(0, 1, 2, 0, 1, 2, 0, 1, 2,   -1, -1, -1, -1, -1, -1, -1)),
                                                                Xse.shuffle_epi8(b, new v128(0, 0, 0, 1, 1, 1, 2, 2, 2,   -1, -1, -1, -1, -1, -1, -1))),
                                                                9);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                v128 a16 = Xse.cvtepu8_epi16(a);
                v128 b16 = Xse.cvtepu8_epi16(b);

                return Xse.allfalse_epi128<ushort>(Xse.or_si128(Xse.cmpeq_epi16(a16, Xse.shufflelo_epi16(b16, Sse.SHUFFLE(0, 0, 0, 0))),
                                                   Xse.or_si128(Xse.cmpeq_epi16(a16, Xse.shufflelo_epi16(b16, Sse.SHUFFLE(1, 1, 1, 1))),
                                                                Xse.cmpeq_epi16(a16, Xse.shufflelo_epi16(b16, Sse.SHUFFLE(2, 2, 2, 2))))),
                                                                 3);
            }
            else
            {
                return !math.any(a == b.x | a == b.y | a == b.z);
            }
        }

        /// <summary>       Returns <see langword="true"/> if <paramref name="a"/> and <paramref name="b"/> do not share any components with each other.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(byte4 a, byte4 b)
        {
            if (BurstArchitecture.IsTableLookupSupported)
            {
                return Xse.allfalse_epi128<byte>(Xse.cmpeq_epi8(Xse.shuffle_epi8(a, new v128(0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3)),
                                                                Xse.shuffle_epi8(b, new v128(0, 0, 0, 0, 1, 1, 1, 1, 2, 2, 2, 2, 3, 3, 3, 3))));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                v128 a16 = Xse.cvtepu8_epi16(a);
                v128 b16 = Xse.cvtepu8_epi16(b);

                return Xse.allfalse_epi128<ushort>(Xse.or_si128(Xse.cmpeq_epi16(a16, Xse.shufflelo_epi16(b16, Sse.SHUFFLE(0, 0, 0, 0))),
                                                   Xse.or_si128(Xse.cmpeq_epi16(a16, Xse.shufflelo_epi16(b16, Sse.SHUFFLE(1, 1, 1, 1))),
                                                   Xse.or_si128(Xse.cmpeq_epi16(a16, Xse.shufflelo_epi16(b16, Sse.SHUFFLE(2, 2, 2, 2))),
                                                                Xse.cmpeq_epi16(a16, Xse.shufflelo_epi16(b16, Sse.SHUFFLE(3, 3, 3, 3)))))),
                                                                4);
            }
            else
            {
                return !math.any(a == b.x | a == b.y | a == b.z | a == b.w);
            }
        }

        /// <summary>       Returns <see langword="true"/> if <paramref name="a"/> and <paramref name="b"/> do not share any components with each other.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(byte8 a, byte8 b)
        {
            if (BurstArchitecture.IsTableLookupSupported)
            {
                v128 dupA = Xse.unpacklo_epi64(a, a);

                return Xse.allfalse_epi128<byte>(Xse.ternarylogic_si128(Xse.or_si128(Xse.cmpeq_epi8(dupA, Xse.shuffle_epi8(b, new v128(0, 0, 0, 0, 0, 0, 0, 0,   4, 4, 4, 4, 4, 4, 4, 4))),
                                                                                     Xse.cmpeq_epi8(dupA, Xse.shuffle_epi8(b, new v128(1, 1, 1, 1, 1, 1, 1, 1,   5, 5, 5, 5, 5, 5, 5, 5)))),
                                                                                     Xse.cmpeq_epi8(dupA, Xse.shuffle_epi8(b, new v128(2, 2, 2, 2, 2, 2, 2, 2,   6, 6, 6, 6, 6, 6, 6, 6))),
                                                                                     Xse.cmpeq_epi8(dupA, Xse.shuffle_epi8(b, new v128(3, 3, 3, 3, 3, 3, 3, 3,   7, 7, 7, 7, 7, 7, 7, 7))),
                                                                                     TernaryOperation.OxFE));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.allfalse_epi128<byte>(Xse.or_si128(Xse.or_si128(Xse.or_si128(Xse.cmpeq_epi8(a, Xse.broadcasti_epi8(b, 0, 8)),
                                                                                        Xse.cmpeq_epi8(a, Xse.broadcasti_epi8(b, 1, 8))),
                                                                           Xse.or_si128(Xse.cmpeq_epi8(a, Xse.broadcasti_epi8(b, 2, 8)),
                                                                                        Xse.cmpeq_epi8(a, Xse.broadcasti_epi8(b, 3, 8)))),
                                                              Xse.or_si128(Xse.or_si128(Xse.cmpeq_epi8(a, Xse.broadcasti_epi8(b, 4, 8)),
                                                                                        Xse.cmpeq_epi8(a, Xse.broadcasti_epi8(b, 5, 8))),
                                                                           Xse.or_si128(Xse.cmpeq_epi8(a, Xse.broadcasti_epi8(b, 6, 8)),
                                                                                        Xse.cmpeq_epi8(a, Xse.broadcasti_epi8(b, 7, 8))))),
                                                                                        8);
            }
            else
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (a[i] == b[j])
                        {
                            return false;
                        }
                    }
                }

                return true;
            }
        }

        /// <summary>       Returns <see langword="true"/> if <paramref name="a"/> and <paramref name="b"/> do not share any components with each other.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(byte16 a, byte16 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 dupA = Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(a), Sse.SHUFFLE(1, 0, 1, 0));
                v256 dupB = Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(b), Sse.SHUFFLE(1, 1, 0, 0));

                return Xse.mm256_allfalse_epi256<byte>(Xse.mm256_ternarylogic_si256(Xse.mm256_ternarylogic_si256(Avx2.mm256_cmpeq_epi8(dupA, Xse.mm256_bror_si128(dupB, 0 * sizeof(byte))),
                                                                                                                 Avx2.mm256_cmpeq_epi8(dupA, Xse.mm256_bror_si128(dupB, 1 * sizeof(byte))),
                                                                                                                 Avx2.mm256_cmpeq_epi8(dupA, Xse.mm256_bror_si128(dupB, 2 * sizeof(byte))), TernaryOperation.OxFE),
                                                                                    Xse.mm256_ternarylogic_si256(Avx2.mm256_cmpeq_epi8(dupA, Xse.mm256_bror_si128(dupB, 3 * sizeof(byte))),
                                                                                                                 Avx2.mm256_cmpeq_epi8(dupA, Xse.mm256_bror_si128(dupB, 4 * sizeof(byte))),
                                                                                                                 Avx2.mm256_cmpeq_epi8(dupA, Xse.mm256_bror_si128(dupB, 5 * sizeof(byte))), TernaryOperation.OxFE),
                                                                                             Avx2.mm256_or_si256(Avx2.mm256_cmpeq_epi8(dupA, Xse.mm256_bror_si128(dupB, 6 * sizeof(byte))),
                                                                                                                 Avx2.mm256_cmpeq_epi8(dupA, Xse.mm256_bror_si128(dupB, 7 * sizeof(byte)))), TernaryOperation.OxFE));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.allfalse_epi128<byte>(Xse.or_si128(Xse.or_si128(Xse.or_si128(Xse.or_si128(Xse.cmpeq_epi8(a, Xse.bror_si128(b, 0  * sizeof(byte))),
                                                                                                     Xse.cmpeq_epi8(a, Xse.bror_si128(b, 1  * sizeof(byte)))),
                                                                                        Xse.or_si128(Xse.cmpeq_epi8(a, Xse.bror_si128(b, 2  * sizeof(byte))),
                                                                                                     Xse.cmpeq_epi8(a, Xse.bror_si128(b, 3  * sizeof(byte))))),
                                                                           Xse.or_si128(Xse.or_si128(Xse.cmpeq_epi8(a, Xse.bror_si128(b, 4  * sizeof(byte))),
                                                                                                     Xse.cmpeq_epi8(a, Xse.bror_si128(b, 5  * sizeof(byte)))),
                                                                                        Xse.or_si128(Xse.cmpeq_epi8(a, Xse.bror_si128(b, 6  * sizeof(byte))),
                                                                                                     Xse.cmpeq_epi8(a, Xse.bror_si128(b, 7  * sizeof(byte)))))),
                                                              Xse.or_si128(Xse.or_si128(Xse.or_si128(Xse.cmpeq_epi8(a, Xse.bror_si128(b, 8  * sizeof(byte))),
                                                                                                     Xse.cmpeq_epi8(a, Xse.bror_si128(b, 9  * sizeof(byte)))),
                                                                                        Xse.or_si128(Xse.cmpeq_epi8(a, Xse.bror_si128(b, 10 * sizeof(byte))),
                                                                                                     Xse.cmpeq_epi8(a, Xse.bror_si128(b, 11 * sizeof(byte))))),
                                                                           Xse.or_si128(Xse.or_si128(Xse.cmpeq_epi8(a, Xse.bror_si128(b, 12 * sizeof(byte))),
                                                                                                     Xse.cmpeq_epi8(a, Xse.bror_si128(b, 13 * sizeof(byte)))),
                                                                                        Xse.or_si128(Xse.cmpeq_epi8(a, Xse.bror_si128(b, 14 * sizeof(byte))),
                                                                                                     Xse.cmpeq_epi8(a, Xse.bror_si128(b, 15 * sizeof(byte))))))));
            }
            else
            {
                for (int i = 0; i < 16; i++)
                {
                    for (int j = 0; j < 16; j++)
                    {
                        if (a[i] == b[j])
                        {
                            return false;
                        }
                    }
                }

                return true;
            }
        }

        /// <summary>       Returns <see langword="true"/> if <paramref name="a"/> and <paramref name="b"/> do not share any components with each other.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(byte32 a, byte32 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_allfalse_epi256<byte>(Avx2.mm256_or_si256(Xse.mm256_ternarylogic_si256(Xse.mm256_ternarylogic_si256(Xse.mm256_ternarylogic_si256(Avx2.mm256_cmpeq_epi8(a, Xse.mm256_bror_si256(b, 0  * sizeof(byte))),
                                                                                                                                                                  Avx2.mm256_cmpeq_epi8(a, Xse.mm256_bror_si256(b, 1  * sizeof(byte))),
                                                                                                                                                                  Avx2.mm256_cmpeq_epi8(a, Xse.mm256_bror_si256(b, 2  * sizeof(byte))), TernaryOperation.OxFE),
                                                                                                                                     Xse.mm256_ternarylogic_si256(Avx2.mm256_cmpeq_epi8(a, Xse.mm256_bror_si256(b, 3  * sizeof(byte))),
                                                                                                                                                                  Avx2.mm256_cmpeq_epi8(a, Xse.mm256_bror_si256(b, 4  * sizeof(byte))),
                                                                                                                                                                  Avx2.mm256_cmpeq_epi8(a, Xse.mm256_bror_si256(b, 5  * sizeof(byte))), TernaryOperation.OxFE),
                                                                                                                                     Xse.mm256_ternarylogic_si256(Avx2.mm256_cmpeq_epi8(a, Xse.mm256_bror_si256(b, 6  * sizeof(byte))),
                                                                                                                                                                  Avx2.mm256_cmpeq_epi8(a, Xse.mm256_bror_si256(b, 7  * sizeof(byte))),
                                                                                                                                                                  Avx2.mm256_cmpeq_epi8(a, Xse.mm256_bror_si256(b, 8  * sizeof(byte))), TernaryOperation.OxFE), TernaryOperation.OxFE),
                                                                                                        Xse.mm256_ternarylogic_si256(Xse.mm256_ternarylogic_si256(Avx2.mm256_cmpeq_epi8(a, Xse.mm256_bror_si256(b, 9  * sizeof(byte))),
                                                                                                                                                                  Avx2.mm256_cmpeq_epi8(a, Xse.mm256_bror_si256(b, 10 * sizeof(byte))),
                                                                                                                                                                  Avx2.mm256_cmpeq_epi8(a, Xse.mm256_bror_si256(b, 11 * sizeof(byte))), TernaryOperation.OxFE),
                                                                                                                                     Xse.mm256_ternarylogic_si256(Avx2.mm256_cmpeq_epi8(a, Xse.mm256_bror_si256(b, 12 * sizeof(byte))),
                                                                                                                                                                  Avx2.mm256_cmpeq_epi8(a, Xse.mm256_bror_si256(b, 13 * sizeof(byte))),
                                                                                                                                                                  Avx2.mm256_cmpeq_epi8(a, Xse.mm256_bror_si256(b, 14 * sizeof(byte))), TernaryOperation.OxFE),
                                                                                                                                     Xse.mm256_ternarylogic_si256(Avx2.mm256_cmpeq_epi8(a, Xse.mm256_bror_si256(b, 15 * sizeof(byte))),
                                                                                                                                                                  Avx2.mm256_cmpeq_epi8(a, Xse.mm256_bror_si256(b, 16 * sizeof(byte))),
                                                                                                                                                                  Avx2.mm256_cmpeq_epi8(a, Xse.mm256_bror_si256(b, 17 * sizeof(byte))), TernaryOperation.OxFE), TernaryOperation.OxFE),
                                                                                                        Xse.mm256_ternarylogic_si256(Xse.mm256_ternarylogic_si256(Avx2.mm256_cmpeq_epi8(a, Xse.mm256_bror_si256(b, 18 * sizeof(byte))),
                                                                                                                                                                  Avx2.mm256_cmpeq_epi8(a, Xse.mm256_bror_si256(b, 19 * sizeof(byte))),
                                                                                                                                                                  Avx2.mm256_cmpeq_epi8(a, Xse.mm256_bror_si256(b, 20 * sizeof(byte))), TernaryOperation.OxFE),
                                                                                                                                     Xse.mm256_ternarylogic_si256(Avx2.mm256_cmpeq_epi8(a, Xse.mm256_bror_si256(b, 21 * sizeof(byte))),
                                                                                                                                                                  Avx2.mm256_cmpeq_epi8(a, Xse.mm256_bror_si256(b, 22 * sizeof(byte))),
                                                                                                                                                                  Avx2.mm256_cmpeq_epi8(a, Xse.mm256_bror_si256(b, 23 * sizeof(byte))), TernaryOperation.OxFE),
                                                                                                                                     Xse.mm256_ternarylogic_si256(Avx2.mm256_cmpeq_epi8(a, Xse.mm256_bror_si256(b, 24 * sizeof(byte))),
                                                                                                                                                                  Avx2.mm256_cmpeq_epi8(a, Xse.mm256_bror_si256(b, 25 * sizeof(byte))),
                                                                                                                                                                  Avx2.mm256_cmpeq_epi8(a, Xse.mm256_bror_si256(b, 26 * sizeof(byte))), TernaryOperation.OxFE), TernaryOperation.OxFE), TernaryOperation.OxFE),
                                                                                                        Xse.mm256_ternarylogic_si256(Xse.mm256_ternarylogic_si256(Avx2.mm256_cmpeq_epi8(a, Xse.mm256_bror_si256(b, 27 * sizeof(byte))),
                                                                                                                                                                  Avx2.mm256_cmpeq_epi8(a, Xse.mm256_bror_si256(b, 28 * sizeof(byte))),
                                                                                                                                                                  Avx2.mm256_cmpeq_epi8(a, Xse.mm256_bror_si256(b, 29 * sizeof(byte))), TernaryOperation.OxFE),
                                                                                                                                                                  Avx2.mm256_cmpeq_epi8(a, Xse.mm256_bror_si256(b, 30 * sizeof(byte))),
                                                                                                                                                                  Avx2.mm256_cmpeq_epi8(a, Xse.mm256_bror_si256(b, 31 * sizeof(byte))), TernaryOperation.OxFE)),
                                                                                                                                                                  32);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return all_dif(a.v16_0,  b.v16_0)
                    && all_dif(a.v16_16, b.v16_0)
                    && all_dif(a.v16_0,  b.v16_16)
                    && all_dif(a.v16_16, b.v16_16);
            }
            else
            {
                for (int i = 0; i < 32; i++)
                {
                    for (int j = 0; j < 32; j++)
                    {
                        if (a[i] == b[j])
                        {
                            return false;
                        }
                    }
                }

                return true;
            }
        }


        /// <summary>       Returns <see langword="true"/> if <paramref name="a"/> and <paramref name="b"/> do not share any components with each other.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(sbyte2 a, sbyte2 b)
        {
            return all_dif((byte2)a, (byte2)b);
        }

        /// <summary>       Returns <see langword="true"/> if <paramref name="a"/> and <paramref name="b"/> do not share any components with each other.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(sbyte3 a, sbyte3 b)
        {
            return all_dif((byte3)a, (byte3)b);
        }

        /// <summary>       Returns <see langword="true"/> if <paramref name="a"/> and <paramref name="b"/> do not share any components with each other.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(sbyte4 a, sbyte4 b)
        {
            return all_dif((byte4)a, (byte4)b);
        }

        /// <summary>       Returns <see langword="true"/> if <paramref name="a"/> and <paramref name="b"/> do not share any components with each other.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(sbyte8 a, sbyte8 b)
        {
            return all_dif((byte8)a, (byte8)b);
        }

        /// <summary>       Returns <see langword="true"/> if <paramref name="a"/> and <paramref name="b"/> do not share any components with each other.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(sbyte16 a, sbyte16 b)
        {
            return all_dif((byte16)a, (byte16)b);
        }

        /// <summary>       Returns <see langword="true"/> if <paramref name="a"/> and <paramref name="b"/> do not share any components with each other.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(sbyte32 a, sbyte32 b)
        {
            return all_dif((byte32)a, (byte32)b);
        }


        /// <summary>       Returns <see langword="true"/> if <paramref name="a"/> and <paramref name="b"/> do not share any components with each other.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(short2 a, short2 b)
        {
            return !math.any(a.xyxy == b.xxyy);
        }

        /// <summary>       Returns <see langword="true"/> if <paramref name="a"/> and <paramref name="b"/> do not share any components with each other.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(short3 a, short3 b)
        {
            if (BurstArchitecture.IsTableLookupSupported)
            {
                return (Xse.extract_epi16(a, 2) != Xse.extract_epi16(b, 2)) & Xse.allfalse_epi128<short>(Xse.cmpeq_epi16(Xse.shuffle_epi16(a, new v128(0, 1, 2, 0, 1, 2, 0, 1)),
                                                                                                                         Xse.shuffle_epi16(b, new v128(0, 0, 0, 1, 1, 1, 2, 2))));
            }
            else
            {
                return !math.any(a == b.x | a == b.y | a == b.z);
            }
        }

        /// <summary>       Returns <see langword="true"/> if <paramref name="a"/> and <paramref name="b"/> do not share any components with each other.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(short4 a, short4 b)
        {
            if (BurstArchitecture.IsTableLookupSupported)
            {
                return Xse.allfalse_epi128<short>(Xse.or_si128(Xse.cmpeq_epi16(Xse.unpacklo_epi64(a, a), Xse.shuffle_epi16(b, new v128(0, 0, 0, 0, 1, 1, 1, 1))),
                                                               Xse.cmpeq_epi16(Xse.unpacklo_epi64(a, a), Xse.shuffle_epi16(b, new v128(2, 2, 2, 2, 3, 3, 3, 3)))));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.allfalse_epi128<short>(Xse.or_si128(Xse.cmpeq_epi16(a, Xse.shufflelo_epi16(b, Sse.SHUFFLE(0, 0, 0, 0))),
                                                  Xse.or_si128(Xse.cmpeq_epi16(a, Xse.shufflelo_epi16(b, Sse.SHUFFLE(1, 1, 1, 1))),
                                                  Xse.or_si128(Xse.cmpeq_epi16(a, Xse.shufflelo_epi16(b, Sse.SHUFFLE(2, 2, 2, 2))),
                                                               Xse.cmpeq_epi16(a, Xse.shufflelo_epi16(b, Sse.SHUFFLE(3, 3, 3, 3)))))),
                                                  4);
            }
            else
            {
                return !math.any(a == b.x | a == b.y | a == b.z | a == b.w);
            }
        }

        /// <summary>       Returns <see langword="true"/> if <paramref name="a"/> and <paramref name="b"/> do not share any components with each other.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(short8 a, short8 b)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.allfalse_epi128<short>(Xse.ternarylogic_si128(Xse.ternarylogic_si128(Xse.cmpeq_epi16(a, Xse.bror_si128(b, 0 * sizeof(ushort))),
                                                                                                Xse.cmpeq_epi16(a, Xse.bror_si128(b, 1 * sizeof(ushort))),
                                                                                                Xse.cmpeq_epi16(a, Xse.bror_si128(b, 2 * sizeof(ushort))), TernaryOperation.OxFE),
                                                                         Xse.ternarylogic_si128(Xse.cmpeq_epi16(a, Xse.bror_si128(b, 3 * sizeof(ushort))),
                                                                                                Xse.cmpeq_epi16(a, Xse.bror_si128(b, 4 * sizeof(ushort))),
                                                                                                Xse.cmpeq_epi16(a, Xse.bror_si128(b, 5 * sizeof(ushort))), TernaryOperation.OxFE),
                                                                                   Xse.or_si128(Xse.cmpeq_epi16(a, Xse.bror_si128(b, 6 * sizeof(ushort))),
                                                                                                Xse.cmpeq_epi16(a, Xse.bror_si128(b, 7 * sizeof(ushort)))), TernaryOperation.OxFE));
            }
            else
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (a[i] == b[j])
                        {
                            return false;
                        }
                    }
                }

                return true;
            }
        }

        /// <summary>       Returns <see langword="true"/> if <paramref name="a"/> and <paramref name="b"/> do not share any components with each other.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(short16 a, short16 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_allfalse_epi256<short>(Avx2.mm256_or_si256(Xse.mm256_ternarylogic_si256(Xse.mm256_ternarylogic_si256(Avx2.mm256_cmpeq_epi16(a, Xse.mm256_bror_si256(b, 0  * sizeof(ushort))),
                                                                                                                                      Avx2.mm256_cmpeq_epi16(a, Xse.mm256_bror_si256(b, 1  * sizeof(ushort))),
                                                                                                                                      Avx2.mm256_cmpeq_epi16(a, Xse.mm256_bror_si256(b, 2  * sizeof(ushort))), TernaryOperation.OxFE),
                                                                                                         Xse.mm256_ternarylogic_si256(Avx2.mm256_cmpeq_epi16(a, Xse.mm256_bror_si256(b, 3  * sizeof(ushort))),
                                                                                                                                      Avx2.mm256_cmpeq_epi16(a, Xse.mm256_bror_si256(b, 4  * sizeof(ushort))),
                                                                                                                                      Avx2.mm256_cmpeq_epi16(a, Xse.mm256_bror_si256(b, 5  * sizeof(ushort))), TernaryOperation.OxFE),
                                                                                                         Xse.mm256_ternarylogic_si256(Avx2.mm256_cmpeq_epi16(a, Xse.mm256_bror_si256(b, 6  * sizeof(ushort))),
                                                                                                                                      Avx2.mm256_cmpeq_epi16(a, Xse.mm256_bror_si256(b, 7  * sizeof(ushort))),
                                                                                                                                      Avx2.mm256_cmpeq_epi16(a, Xse.mm256_bror_si256(b, 8  * sizeof(ushort))), TernaryOperation.OxFE), TernaryOperation.OxFE),
                                                                            Xse.mm256_ternarylogic_si256(Xse.mm256_ternarylogic_si256(Avx2.mm256_cmpeq_epi16(a, Xse.mm256_bror_si256(b, 9  * sizeof(ushort))),
                                                                                                                                      Avx2.mm256_cmpeq_epi16(a, Xse.mm256_bror_si256(b, 10 * sizeof(ushort))),
                                                                                                                                      Avx2.mm256_cmpeq_epi16(a, Xse.mm256_bror_si256(b, 11 * sizeof(ushort))), TernaryOperation.OxFE),
                                                                                                         Xse.mm256_ternarylogic_si256(Avx2.mm256_cmpeq_epi16(a, Xse.mm256_bror_si256(b, 12 * sizeof(ushort))),
                                                                                                                                      Avx2.mm256_cmpeq_epi16(a, Xse.mm256_bror_si256(b, 13 * sizeof(ushort))),
                                                                                                                                      Avx2.mm256_cmpeq_epi16(a, Xse.mm256_bror_si256(b, 14 * sizeof(ushort))), TernaryOperation.OxFE),
                                                                                                                                      Avx2.mm256_cmpeq_epi16(a, Xse.mm256_bror_si256(b, 15 * sizeof(ushort))), TernaryOperation.OxFE)));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return all_dif(a.v8_0, b.v8_0)
                    && all_dif(a.v8_8, b.v8_0)
                    && all_dif(a.v8_0, b.v8_8)
                    && all_dif(a.v8_8, b.v8_8);
            }
            else
            {
                for (int i = 0; i < 16; i++)
                {
                    for (int j = 0; j < 16; j++)
                    {
                        if (a[i] == b[j])
                        {
                            return false;
                        }
                    }
                }

                return true;
            }
        }


        /// <summary>       Returns <see langword="true"/> if <paramref name="a"/> and <paramref name="b"/> do not share any components with each other.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(ushort2 a, ushort2 b)
        {
            return all_dif((short2)a, (short2)b);
        }

        /// <summary>       Returns <see langword="true"/> if <paramref name="a"/> and <paramref name="b"/> do not share any components with each other.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(ushort3 a, ushort3 b)
        {
            return all_dif((short3)a, (short3)b);
        }

        /// <summary>       Returns <see langword="true"/> if <paramref name="a"/> and <paramref name="b"/> do not share any components with each other.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(ushort4 a, ushort4 b)
        {
            return all_dif((short4)a, (short4)b);
        }

        /// <summary>       Returns <see langword="true"/> if <paramref name="a"/> and <paramref name="b"/> do not share any components with each other.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(ushort8 a, ushort8 b)
        {
            return all_dif((short8)a, (short8)b);
        }

        /// <summary>       Returns <see langword="true"/> if <paramref name="a"/> and <paramref name="b"/> do not share any components with each other.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(ushort16 a, ushort16 b)
        {
            return all_dif((short16)a, (short16)b);
        }


        /// <summary>       Returns <see langword="true"/> if <paramref name="a"/> and <paramref name="b"/> do not share any components with each other.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(int2 a, int2 b)
        {
            return !math.any(a.xyxy == b.xxyy);
        }

        /// <summary>       Returns <see langword="true"/> if <paramref name="a"/> and <paramref name="b"/> do not share any components with each other.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(int3 a, int3 b)
        {
            return !math.any(a == b.xxx | a == b.yyy | a == b.zzz);
        }

        /// <summary>       Returns <see langword="true"/> if <paramref name="a"/> and <paramref name="b"/> do not share any components with each other.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(int4 a, int4 b)
        {
            return !math.any(a == b.xxxx | a == b.yyyy | a == b.zzzz | a == b.wwww);
        }

        /// <summary>       Returns <see langword="true"/> if <paramref name="a"/> and <paramref name="b"/> do not share any components with each other.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(int8 a, int8 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_allfalse_epi256<int>(Xse.mm256_ternarylogic_si256(Xse.mm256_ternarylogic_si256(Avx2.mm256_cmpeq_epi32(a, Xse.mm256_bror_si256(b, 0 * sizeof(int))),
                                                                                                                Avx2.mm256_cmpeq_epi32(a, Xse.mm256_bror_si256(b, 1 * sizeof(int))),
                                                                                                                Avx2.mm256_cmpeq_epi32(a, Xse.mm256_bror_si256(b, 2 * sizeof(int))), TernaryOperation.OxFE),
                                                                                   Xse.mm256_ternarylogic_si256(Avx2.mm256_cmpeq_epi32(a, Xse.mm256_bror_si256(b, 3 * sizeof(int))),
                                                                                                                Avx2.mm256_cmpeq_epi32(a, Xse.mm256_bror_si256(b, 4 * sizeof(int))),
                                                                                                                Avx2.mm256_cmpeq_epi32(a, Xse.mm256_bror_si256(b, 5 * sizeof(int))), TernaryOperation.OxFE),
                                                                                            Avx2.mm256_or_si256(Avx2.mm256_cmpeq_epi32(a, Xse.mm256_bror_si256(b, 6 * sizeof(int))),
                                                                                                                Avx2.mm256_cmpeq_epi32(a, Xse.mm256_bror_si256(b, 7 * sizeof(int)))), TernaryOperation.OxFE));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return all_dif(a.v4_0, b.v4_0)
                     & all_dif(a.v4_4, b.v4_0)
                     & all_dif(a.v4_0, b.v4_4)
                     & all_dif(a.v4_4, b.v4_4);
            }
            else
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (a[i] == b[j])
                        {
                            return false;
                        }
                    }
                }

                return true;
            }
        }


        /// <summary>       Returns <see langword="true"/> if <paramref name="a"/> and <paramref name="b"/> do not share any components with each other.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(uint2 a, uint2 b)
        {
            return all_dif((int2)a, (int2)b);
        }

        /// <summary>       Returns <see langword="true"/> if <paramref name="a"/> and <paramref name="b"/> do not share any components with each other.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(uint3 a, uint3 b)
        {
            return all_dif((int3)a, (int3)b);
        }

        /// <summary>       Returns <see langword="true"/> if <paramref name="a"/> and <paramref name="b"/> do not share any components with each other.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(uint4 a, uint4 b)
        {
            return all_dif((int4)a, (int4)b);
        }

        /// <summary>       Returns <see langword="true"/> if <paramref name="a"/> and <paramref name="b"/> do not share any components with each other.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(uint8 a, uint8 b)
        {
            return all_dif((int8)a, (int8)b);
        }


        /// <summary>       Returns <see langword="true"/> if <paramref name="a"/> and <paramref name="b"/> do not share any components with each other.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(long2 a, long2 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return !math.any(a.xyxy == b.xxyy);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.allfalse_epi128<long>(Xse.or_si128(Xse.cmpeq_epi64(a, b.xx), Xse.cmpeq_epi64(a, b.yy)));
            }
            else
            {
                return !math.any(a == b.xx | a == b.yy);
            }
        }

        /// <summary>       Returns <see langword="true"/> if <paramref name="a"/> and <paramref name="b"/> do not share any components with each other.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(long3 a, long3 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_allfalse_epi256<long>(Xse.mm256_ternarylogic_si256(Avx2.mm256_cmpeq_epi64(a, b.xxx),
                                                                                    Avx2.mm256_cmpeq_epi64(a, b.yyy),
                                                                                    Avx2.mm256_cmpeq_epi64(a, b.zzz),
                                                                                    TernaryOperation.OxFE),
                                                                                    3);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.allfalse_epi128<long>(Xse.or_si128(Xse.or_si128(Xse.cmpeq_epi64(a.xy, b.xx),
                                                              Xse.or_si128(Xse.cmpeq_epi64(a.xy, b.yy),
                                                                           Xse.cmpeq_epi64(a.xy, b.zz))),
                                                              Xse.or_si128(Xse.cmpeq_epi64(a.zz, b.zz),
                                                                           Xse.cmpeq_epi64(a.zz, b.xy))));
            }
            else
            {
                return !math.any(a.xy == b.xx | a.xy == b.yy | a.xy == b.zz | a.zz == b.xy) & a.z != b.z;
            }
        }

        /// <summary>       Returns <see langword="true"/> if <paramref name="a"/> and <paramref name="b"/> do not share any components with each other.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(long4 a, long4 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_allfalse_epi256<long>(Avx2.mm256_or_si256(Avx2.mm256_cmpeq_epi64(a, b.xxxx),
                                              Xse.mm256_ternarylogic_si256(Avx2.mm256_cmpeq_epi64(a, b.yyyy),
                                                                           Avx2.mm256_cmpeq_epi64(a, b.zzzz),
                                                                           Avx2.mm256_cmpeq_epi64(a, b.wwww),
                                                                           TernaryOperation.OxFE)));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.allfalse_epi128<long>(Xse.or_si128(Xse.or_si128(Xse.or_si128(Xse.cmpeq_epi64(a.xy, b.xx),
                                                                                        Xse.cmpeq_epi64(a.xy, b.yy)),
                                                                           Xse.or_si128(Xse.cmpeq_epi64(a.xy, b.zz),
                                                                                        Xse.cmpeq_epi64(a.xy, b.ww))),
                                                              Xse.or_si128(Xse.or_si128(Xse.cmpeq_epi64(a.zw, b.xx),
                                                                                        Xse.cmpeq_epi64(a.zw, b.yy)),
                                                                           Xse.or_si128(Xse.cmpeq_epi64(a.zw, b.zz),
                                                                                        Xse.cmpeq_epi64(a.zw, b.ww)))));
            }
            else
            {
                return !math.any(a.xy == b.xx | a.xy == b.yy | a.xy == b.zz | a.xy == b.ww |
                                 a.zw == b.xx | a.zw == b.yy | a.zw == b.zz | a.zw == b.ww);
            }
        }


        /// <summary>       Returns <see langword="true"/> if <paramref name="a"/> and <paramref name="b"/> do not share any components with each other.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(ulong2 a, ulong2 b)
        {
            return all_dif((long2)a, (long2)b);
        }

        /// <summary>       Returns <see langword="true"/> if <paramref name="a"/> and <paramref name="b"/> do not share any components with each other.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(ulong3 a, ulong3 b)
        {
            return all_dif((long3)a, (long3)b);
        }

        /// <summary>       Returns <see langword="true"/> if <paramref name="a"/> and <paramref name="b"/> do not share any components with each other.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(ulong4 a, ulong4 b)
        {
            return all_dif((long4)a, (long4)b);
        }


        /// <summary>       Returns <see langword="true"/> if <paramref name="a"/> and <paramref name="b"/> do not share any components with each other.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(float2 a, float2 b)
        {
            return !math.any(a.xyxy == b.xxyy);
        }

        /// <summary>       Returns <see langword="true"/> if <paramref name="a"/> and <paramref name="b"/> do not share any components with each other.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(float3 a, float3 b)
        {
            return !math.any(a == b.xxx | a == b.yyy | a == b.zzz);
        }

        /// <summary>       Returns <see langword="true"/> if <paramref name="a"/> and <paramref name="b"/> do not share any components with each other.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(float4 a, float4 b)
        {
            return !math.any(a == b.xxxx | a == b.yyyy | a == b.zzzz | a == b.wwww);
        }

        /// <summary>       Returns <see langword="true"/> if <paramref name="a"/> and <paramref name="b"/> do not share any components with each other.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(float8 a, float8 b)
        {
            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_allfalse_f256<float>(Xse.mm256_ternarylogic_si256(Xse.mm256_ternarylogic_si256(Xse.mm256_cmpeq_ps(a, Xse.mm256_bror_si256(b, 0 * sizeof(int))),
                                                                                                                Xse.mm256_cmpeq_ps(a, Xse.mm256_bror_si256(b, 1 * sizeof(int))),
                                                                                                                Xse.mm256_cmpeq_ps(a, Xse.mm256_bror_si256(b, 2 * sizeof(int))), TernaryOperation.OxFE),
                                                                                   Xse.mm256_ternarylogic_si256(Xse.mm256_cmpeq_ps(a, Xse.mm256_bror_si256(b, 3 * sizeof(int))),
                                                                                                                Xse.mm256_cmpeq_ps(a, Xse.mm256_bror_si256(b, 4 * sizeof(int))),
                                                                                                                Xse.mm256_cmpeq_ps(a, Xse.mm256_bror_si256(b, 5 * sizeof(int))), TernaryOperation.OxFE),
                                                                                                Avx.mm256_or_ps(Xse.mm256_cmpeq_ps(a, Xse.mm256_bror_si256(b, 6 * sizeof(int))),
                                                                                                                Xse.mm256_cmpeq_ps(a, Xse.mm256_bror_si256(b, 7 * sizeof(int)))), TernaryOperation.OxFE));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return all_dif(a.v4_0, b.v4_0)
                     & all_dif(a.v4_4, b.v4_0)
                     & all_dif(a.v4_0, b.v4_4)
                     & all_dif(a.v4_4, b.v4_4);
            }
            else
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (a[i] == b[j])
                        {
                            return false;
                        }
                    }
                }

                return true;
            }
        }


        /// <summary>       Returns <see langword="true"/> if <paramref name="a"/> and <paramref name="b"/> do not share any components with each other.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(double2 a, double2 b)
        {
            if (Avx.IsAvxSupported)
            {
                return !math.any(a.xyxy == b.xxyy);
            }
            else
            {
                return !math.any(a == b.xx | a == b.yy);
            }
        }

        /// <summary>       Returns <see langword="true"/> if <paramref name="a"/> and <paramref name="b"/> do not share any components with each other.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(double3 a, double3 b)
        {
            if (Avx.IsAvxSupported)
            {
                return !math.any(a == b.xxx | a == b.yyy | a == b.zzz);
            }
            else
            {
                return !math.any(a.xy == b.xx | a.xy == b.yy | a.xy == b.zz | a.zz == b.xy | a.zz == b.zz);
            }
        }

        /// <summary>       Returns <see langword="true"/> if <paramref name="a"/> and <paramref name="b"/> do not share any components with each other.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(double4 a, double4 b)
        {
            if (Avx.IsAvxSupported)
            {
                return !math.any(a == b.xxxx | a == b.yyyy | a == b.zzzz | a == b.wwww);
            }
            else
            {
                return !math.any(a.xy == b.xx | a.xy == b.yy | a.xy == b.zz | a.xy == b.ww |
                                 a.zw == b.xx | a.zw == b.yy | a.zw == b.zz | a.zw == b.ww);
            }
        }


        /// <summary>       Returns <see langword="true"/> if all of the components of a <see cref="MaxMath.byte2"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(byte2 c)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.allfalse_epi128<byte>(Xse.cmpeq_epi8(c, Xse.bsrli_si128(c, 1 * sizeof(byte))), 1);
            }
            else
            {
                return c.x != c.y;
            }
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of a <see cref="MaxMath.byte3"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(byte3 c)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return !math.any(c.xxz == c.yzy);
            }
            else
            {
                return c.x != c.y & c.x != c.z & c.y != c.z;
            }
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of a <see cref="MaxMath.byte4"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(byte4 c)
        {
            if (BurstArchitecture.IsTableLookupSupported)
            {
                return Xse.allfalse_epi128<byte>(Xse.cmpeq_epi8(Xse.shuffle_epi8(c, new v128(0, 0, 0, 1, 1, 2,    0, 0, 0, 0, 0, 0, 0, 0, 0, 0)),
                                                                Xse.shuffle_epi8(c, new v128(1, 2, 3, 2, 3, 3,    1, 1, 1, 1, 1, 1, 1, 1, 1, 1))));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return !math.any(c == c.ywxz | c == c.wzxz);
            }
            else
            {
                for (int i = 0; i < 4 - 1; i++)
                {
                    for (int j = i + 1; j < 4; j++)
                    {
                        if (c[i] == c[j])
                        {
                            return false;
                        }
                        else continue;
                    }
                }

                return true;
            }
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of a <see cref="MaxMath.byte8"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(byte8 c)
        {
            if (BurstArchitecture.IsTableLookupSupported)
            {
                v128 cmp0 = Xse.cmpeq_epi8(Xse.shuffle_epi32(c, Sse.SHUFFLE(0, 0, 0, 0)), // Int0 = Byte 0, 1, 2, 3
                                           Xse.shuffle_epi8(c, new v128(4, 5, 0, 7, 1, 6, 7, 5, 6, 2, 4, 6, 3, 3, 3, 4)));

                v128 cmp1 = Xse.cmpeq_epi8(Xse.shuffle_epi32(c, Sse.SHUFFLE(1, 1, 1, 1)), // Int1 = Byte 4, 5, 6, 7
                                           Xse.shuffle_epi8(c, new v128(1, 2, 2, 0, 5, 0, 7, 1, 6, 6, 7, 6, 7, 7, 7, 6)));

                return Xse.allfalse_epi128<byte>(Xse.or_si128(cmp0, cmp1));
            }
            else
            {
                for (int i = 0; i < 8 - 1; i++)
                {
                    for (int j = i + 1; j < 8; j++)
                    {
                        if (c[i] == c[j])
                        {
                            return false;
                        }
                        else continue;
                    }
                }

                return true;
            }
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of a <see cref="MaxMath.byte16"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(byte16 c)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 cShuf0;
                if (BurstArchitecture.IsTableLookupSupported)
                {
                    cShuf0 = Xse.shuffle_epi8(c, new v128(8, 15, 15, 11, 15, 13, 14, 15, 15, 1, 2, 0, 4, 0, 1, 1));
                }
                else
                {
                    cShuf0 = new v128(c.x8, c.x15, c.x15, c.x11, c.x15, c.x13, c.x14, c.x15, c.x15, c.x1, c.x2, c.x0, c.x4, c.x0, c.x1, c.x1);
                }

                v128 or = Xse.ternarylogic_si128(Xse.cmpeq_epi8(c, cShuf0),
                                                 Xse.cmpeq_epi8(c, Xse.bror_si128(c, 1 * sizeof(byte))),
                                                 Xse.cmpeq_epi8(c, Xse.bror_si128(c, 2 * sizeof(byte))),
                                                 TernaryOperation.OxFE);
                or = Xse.ternarylogic_si128(or,
                                            Xse.cmpeq_epi8(c, Xse.bror_si128(c, 3 * sizeof(byte))),
                                            Xse.cmpeq_epi8(c, Xse.bror_si128(c, 4 * sizeof(byte))),
                                            TernaryOperation.OxFE);
                or = Xse.ternarylogic_si128(or,
                                            Xse.or_si128(Xse.cmpeq_epi8(c, Xse.bror_si128(c, 5 * sizeof(byte))),
                                                         Xse.cmpeq_epi8(c, Xse.bror_si128(c, 6 * sizeof(byte)))),
                                            Xse.cmpeq_epi8(c, Xse.bror_si128(c, 7 * sizeof(byte))),
                                            TernaryOperation.OxFE);

                return Xse.allfalse_epi128<byte>(or);
            }
            else
            {
                for (int i = 0; i < 16 - 1; i++)
                {
                    for (int j = i + 1; j < 16; j++)
                    {
                        if (c[i] == c[j])
                        {
                            return false;
                        }
                        else continue;
                    }
                }

                return true;
            }
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of a <see cref="MaxMath.byte32"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(byte32 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 dupA = Avx2.mm256_permute4x64_epi64(c, Sse.SHUFFLE(1, 0, 1, 0));
                v256 dupB = Avx2.mm256_permute4x64_epi64(c, Sse.SHUFFLE(3, 3, 2, 2));

                v256 orHi = Xse.mm256_ternarylogic_si256(Xse.mm256_ternarylogic_si256(Avx2.mm256_cmpeq_epi8(dupA, Xse.mm256_bror_si128(dupB, 0 * sizeof(byte))),
                                                                                      Avx2.mm256_cmpeq_epi8(dupA, Xse.mm256_bror_si128(dupB, 1 * sizeof(byte))),
                                                                                      Avx2.mm256_cmpeq_epi8(dupA, Xse.mm256_bror_si128(dupB, 2 * sizeof(byte))), TernaryOperation.OxFE),
                                                         Xse.mm256_ternarylogic_si256(Avx2.mm256_cmpeq_epi8(dupA, Xse.mm256_bror_si128(dupB, 3 * sizeof(byte))),
                                                                                      Avx2.mm256_cmpeq_epi8(dupA, Xse.mm256_bror_si128(dupB, 4 * sizeof(byte))),
                                                                                      Avx2.mm256_cmpeq_epi8(dupA, Xse.mm256_bror_si128(dupB, 5 * sizeof(byte))), TernaryOperation.OxFE),
                                                                  Avx2.mm256_or_si256(Avx2.mm256_cmpeq_epi8(dupA, Xse.mm256_bror_si128(dupB, 6 * sizeof(byte))),
                                                                                      Avx2.mm256_cmpeq_epi8(dupA, Xse.mm256_bror_si128(dupB, 7 * sizeof(byte)))), TernaryOperation.OxFE);

                v256 cShuf0 = Avx2.mm256_shuffle_epi8(c, new v256(8, 15, 15, 11, 15, 13, 14, 15, 15, 1, 2, 0, 4, 0, 1, 1,
                                                                  8, 15, 15, 11, 15, 13, 14, 15, 15, 1, 2, 0, 4, 0, 1, 1));

                v256 orLo = Xse.mm256_ternarylogic_si256(Avx2.mm256_cmpeq_epi8(c, cShuf0),
                                                         Avx2.mm256_cmpeq_epi8(c, Xse.mm256_bror_si128(c, 1 * sizeof(byte))),
                                                         Avx2.mm256_cmpeq_epi8(c, Xse.mm256_bror_si128(c, 2 * sizeof(byte))),
                                                         TernaryOperation.OxFE);
                orLo = Xse.mm256_ternarylogic_si256(orLo,
                                                    Avx2.mm256_cmpeq_epi8(c, Xse.mm256_bror_si128(c, 3 * sizeof(byte))),
                                                    Avx2.mm256_cmpeq_epi8(c, Xse.mm256_bror_si128(c, 4 * sizeof(byte))),
                                                    TernaryOperation.OxFE);
                v256 orLast = Xse.mm256_ternarylogic_si256(Avx2.mm256_cmpeq_epi8(c, Xse.mm256_bror_si128(c, 5 * sizeof(byte))),
                                                           Avx2.mm256_cmpeq_epi8(c, Xse.mm256_bror_si128(c, 6 * sizeof(byte))),
                                                           Avx2.mm256_cmpeq_epi8(c, Xse.mm256_bror_si128(c, 7 * sizeof(byte))),
                                                           TernaryOperation.OxFE);

                return Xse.mm256_allfalse_epi256<byte>(Xse.mm256_ternarylogic_si256(orHi, orLo, orLast, TernaryOperation.OxFE));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return all_dif(c.v16_0) && all_dif(c.v16_16) && all_dif(c.v16_0, c.v16_16);
            }
            else
            {
                for (int i = 0; i < 32 - 1; i++)
                {
                    for (int j = i + 1; j < 32; j++)
                    {
                        if (c[i] == c[j])
                        {
                            return false;
                        }
                        else continue;
                    }
                }

                return true;
            }
        }


        /// <summary>       Returns <see langword="true"/> if all of the components of an <see cref="MaxMath.sbyte2"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(sbyte2 c)
        {
            return all_dif((short2)c);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of an <see cref="MaxMath.sbyte3"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(sbyte3 c)
        {
            return all_dif((short3)c);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of an <see cref="MaxMath.sbyte4"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(sbyte4 c)
        {
            return all_dif((byte4)c);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of an <see cref="MaxMath.sbyte8"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(sbyte8 c)
        {
            return all_dif((byte8)c);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of an <see cref="MaxMath.sbyte16"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(sbyte16 c)
        {
            return all_dif((byte16)c);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of an <see cref="MaxMath.sbyte32"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(sbyte32 c)
        {
            return all_dif((byte32)c);
        }


        /// <summary>       Returns <see langword="true"/> if all of the components of a <see cref="MaxMath.short2"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(short2 c)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return 0 == Xse.cmpeq_epi16(c, Xse.bsrli_si128(c, 1 * sizeof(short))).UShort0;
            }
            else
            {
                return c.x != c.y;
            }
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of a <see cref="MaxMath.short3"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(short3 c)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return !math.any(c.xxzx == c.yzyy);
            }
            else
            {
                for (int i = 0; i < 3 - 1; i++)
                {
                    for (int j = i + 1; j < 3; j++)
                    {
                        if (c[i] == c[j])
                        {
                            return false;
                        }
                        else continue;
                    }
                }

                return true;
            }
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of a <see cref="MaxMath.short4"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(short4 c)
        {
            if (BurstArchitecture.IsTableLookupSupported)
            {
                return Xse.allfalse_epi128<short>(Xse.cmpeq_epi16(Xse.shuffle_epi16(c, new v128(0, 0, 0, 1, 1, 2,    0, 0)),
                                                                  Xse.shuffle_epi16(c, new v128(1, 2, 3, 2, 3, 3,    1, 1))));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return !math.any(c == c.ywxz | c == c.wzxz);
            }
            else
            {
                for (int i = 0; i < 4 - 1; i++)
                {
                    for (int j = i + 1; j < 4; j++)
                    {
                        if (c[i] == c[j])
                        {
                            return false;
                        }
                        else continue;
                    }
                }

                return true;
            }
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of a <see cref="MaxMath.short8"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(short8 c)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 finalCmp;
                if (BurstArchitecture.IsTableLookupSupported)
                {
                    finalCmp = Xse.shuffle_epi16(c, new v128(4, 5, 6, 7, 7, 0, 1, 2));
                }
                else
                {
                    finalCmp = Xse.bsrli_si128(c, 4 * sizeof(short));
                    finalCmp = Xse.or_si128(finalCmp, Xse.bslli_si128(c, 5 * sizeof(short)));
                    finalCmp = Xse.insert_epi16(finalCmp, Xse.extract_epi16(c, 7), 5);
                }

                v128 or = Xse.or_si128(Xse.or_si128(Xse.cmpeq_epi16(c, Xse.bror_si128(c, 1 * sizeof(short))),
                                                    Xse.cmpeq_epi16(c, Xse.bror_si128(c, 2 * sizeof(short)))),
                                       Xse.or_si128(Xse.cmpeq_epi16(c, Xse.bror_si128(c, 3 * sizeof(short))),
                                                    Xse.cmpeq_epi16(c, finalCmp)));

                return Xse.allfalse_epi128<short>(or);
            }
            else
            {
                for (int i = 0; i < 8 - 1; i++)
                {
                    for (int j = i + 1; j < 8; j++)
                    {
                        if (c[i] == c[j])
                        {
                            return false;
                        }
                        else continue;
                    }
                }

                return true;
            }
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of a <see cref="MaxMath.short16"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(short16 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 dupA = Avx2.mm256_permute4x64_epi64(c, Sse.SHUFFLE(1, 0, 1, 0));
                v256 dupB = Avx2.mm256_permute4x64_epi64(c, Sse.SHUFFLE(3, 3, 2, 2));

                v256 orHi = Xse.mm256_ternarylogic_si256(Avx2.mm256_cmpeq_epi16(dupA, Xse.mm256_bror_si128(dupB, 3 * sizeof(short))),
                                                         Avx2.mm256_cmpeq_epi16(dupA, Xse.mm256_bror_si128(dupB, 2 * sizeof(short))),
                                                         Avx2.mm256_cmpeq_epi16(dupA, Xse.mm256_bror_si128(dupB, 1 * sizeof(short))), TernaryOperation.OxFE);

                v256 orLo = Xse.mm256_ternarylogic_si256(Avx2.mm256_cmpeq_epi16(c, Xse.mm256_bror_si128(c, 3 * sizeof(short))),
                                                         Avx2.mm256_cmpeq_epi16(c, Xse.mm256_bror_si128(c, 2 * sizeof(short))),
                                                         Avx2.mm256_cmpeq_epi16(c, Xse.mm256_bror_si128(c, 1 * sizeof(short))), TernaryOperation.OxFE);

                v256 finalCmp  = Xse.mm256_shuffle_epi16(c, new v256(4, 5, 6, 7, 7, 0, 1, 2,   4, 5, 6, 7, 7, 0, 1, 2));
                v256 orMid = Avx2.mm256_or_si256(Avx2.mm256_cmpeq_epi16(dupA, dupB),
                                                 Avx2.mm256_cmpeq_epi16(c, finalCmp));

                return Xse.mm256_allfalse_epi256<short>(Xse.mm256_ternarylogic_si256(orHi, orMid, orLo, TernaryOperation.OxFE));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return all_dif(c.v8_0) && all_dif(c.v8_8) && all_dif(c.v8_0, c.v8_8);
            }
            else
            {
                for (int i = 0; i < 16 - 1; i++)
                {
                    for (int j = i + 1; j < 16; j++)
                    {
                        if (c[i] == c[j])
                        {
                            return false;
                        }
                        else continue;
                    }
                }

                return true;
            }
        }


        /// <summary>       Returns <see langword="true"/> if all of the components of a <see cref="MaxMath.ushort2"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(ushort2 c)
        {
            return all_dif((short2)c);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of a <see cref="MaxMath.ushort3"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(ushort3 c)
        {
            return all_dif((short3)c);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of a <see cref="MaxMath.ushort4"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(ushort4 c)
        {
            return all_dif((short4)c);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of a <see cref="MaxMath.ushort8"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(ushort8 c)
        {
            return all_dif((short8)c);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of a <see cref="MaxMath.ushort16"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(ushort16 c)
        {
            return all_dif((short16)c);
        }


        /// <summary>       Returns <see langword="true"/> if all of the components of an <see cref="int2"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(int2 c)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 _c = RegisterConversion.ToV128(c);

                return Xse.allfalse_epi128<int>(Xse.cmpeq_epi32(_c, Xse.bsrli_si128(_c, 1 * sizeof(int))), 1);
            }
            else
            {
                return c.x != c.y;
            }
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of an <see cref="int3"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(int3 c)
        {
            return !math.any(c.xxz == c.yzy);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of an <see cref="int4"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(int4 c)
        {
            return !math.any(c == c.ywxz | c == c.wzxz);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of an <see cref="MaxMath.int8"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(int8 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 cmp0 = Avx2.mm256_cmpeq_epi32(c, Avx2.mm256_permutevar8x32_epi32(c, Avx.mm256_castsi128_si256(new v128(1, 0, 3, 0))));
                v256 cmp1 = Avx2.mm256_cmpeq_epi32(c, Avx2.mm256_permutevar8x32_epi32(c, new v256(1, 0, 7, 4, 1, 1, 1, 1)));
                v256 cmp2 = Avx2.mm256_cmpeq_epi32(c, Avx2.mm256_permutevar8x32_epi32(c, new v256(2, 2, 5, 6, 5, 6, 7, 4)));
                v256 cmp3 = Avx2.mm256_cmpeq_epi32(Avx2.mm256_permute4x64_epi64(c, Sse.SHUFFLE(2, 1, 1, 1)), Avx2.mm256_permute4x64_epi64(c, Sse.SHUFFLE(3, 3, 2, 0)));

                v256 or = Xse.mm256_ternarylogic_si256(Avx2.mm256_or_si256(cmp0, cmp1), cmp2, cmp3, TernaryOperation.OxFE);

                return Xse.mm256_allfalse_epi256<int>(or);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                int4 lo = c.v4_0;
                int4 hi = c.v4_4;


                int4 _0000 = lo.xxxx;
                int4 _1234 = math.shuffle(lo, hi, math.ShuffleComponent.LeftY,
                                                  math.ShuffleComponent.LeftZ,
                                                  math.ShuffleComponent.LeftW,
                                                  math.ShuffleComponent.RightX);

                v128 _1st_cmp = Xse.cmpeq_epi32(RegisterConversion.ToV128(_0000), RegisterConversion.ToV128(_1234));


                int4 _0001 = lo.xxxy;
                int4 _5672 = math.shuffle(lo, hi, math.ShuffleComponent.RightY,
                                                  math.ShuffleComponent.RightZ,
                                                  math.ShuffleComponent.RightW,
                                                  math.ShuffleComponent.LeftZ);

                v128 _2nd_cmp = Xse.cmpeq_epi32(RegisterConversion.ToV128(_0001), RegisterConversion.ToV128(_5672));


                int4 _1111 = lo.yyyy;
                int4 _3456 = math.shuffle(lo, hi, math.ShuffleComponent.LeftW,
                                                  math.ShuffleComponent.RightX,
                                                  math.ShuffleComponent.RightY,
                                                  math.ShuffleComponent.RightZ);

                v128 _3rd_cmp = Xse.cmpeq_epi32(RegisterConversion.ToV128(_1111), RegisterConversion.ToV128(_3456));


                int4 _1222 = lo.yzzz;
                int4 _7345 = math.shuffle(lo, hi, math.ShuffleComponent.RightW,
                                                  math.ShuffleComponent.LeftW,
                                                  math.ShuffleComponent.RightX,
                                                  math.ShuffleComponent.RightY);

                v128 _4th_cmp = Xse.cmpeq_epi32(RegisterConversion.ToV128(_1222), RegisterConversion.ToV128(_7345));


                int4 _2233 = lo.zzww;
                int4 _6745 = hi.zwxy;

                v128 _5th_cmp = Xse.cmpeq_epi32(RegisterConversion.ToV128(_2233), RegisterConversion.ToV128(_6745));


                int4 _3344 = math.shuffle(lo, hi, math.ShuffleComponent.LeftW,
                                                  math.ShuffleComponent.LeftW,
                                                  math.ShuffleComponent.RightX,
                                                  math.ShuffleComponent.RightX);
                int4 _6756 = hi.zwyz;

                v128 _6th_cmp = Xse.cmpeq_epi32(RegisterConversion.ToV128(_3344), RegisterConversion.ToV128(_6756));


                int4 _4556 = hi.xyyz;
                int4 _7677 = hi.wzww;

                v128 _7th_cmp = Xse.cmpeq_epi32(RegisterConversion.ToV128(_4556), RegisterConversion.ToV128(_7677));


                v128 or = Xse.or_si128(Xse.or_si128(Xse.or_si128(_1st_cmp, _2nd_cmp),
                                                    Xse.or_si128(_3rd_cmp, _4th_cmp)),
                                       Xse.or_si128(Xse.or_si128(_5th_cmp, _6th_cmp),
                                                      _7th_cmp));

                return Xse.allfalse_epi128<int>(or);
            }
            else
            {
                for (int i = 0; i < 8 - 1; i++)
                {
                    for (int j = i + 1; j < 8; j++)
                    {
                        if (c[i] == c[j])
                        {
                            return false;
                        }
                        else continue;
                    }
                }

                return true;
            }
        }


        /// <summary>       Returns <see langword="true"/> if all of the components of a <see cref="uint2"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(uint2 c)
        {
            return all_dif((int2)c);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of a <see cref="uint3"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(uint3 c)
        {
            return all_dif((int3)c);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of a <see cref="uint4"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(uint4 c)
        {
            return all_dif((int4)c);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of a <see cref="MaxMath.uint8"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(uint8 c)
        {
            return all_dif((int8)c);
        }


        /// <summary>       Returns <see langword="true"/> if all of the components of a <see cref="MaxMath.long2"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(long2 c)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.allfalse_epi128<long>(Xse.cmpeq_epi64(c, Xse.bsrli_si128(c, 1 * sizeof(long))), 1);
            }
            else
            {
                return c.x != c.y;
            }
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of a <see cref="MaxMath.long3"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(long3 c)
        {
            return !math.any(c.xxz == c.yzy);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of a <see cref="MaxMath.long4"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(long4 c)
        {
            return !math.any(c == c.ywxz | c == c.wzxz);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of a <see cref="MaxMath.ulong2"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(ulong2 c)
        {
            return all_dif((long2)c);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of a <see cref="MaxMath.ulong3"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(ulong3 c)
        {
            return all_dif(c.xxzx, c.yzyy);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of a <see cref="MaxMath.ulong4"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(ulong4 c)
        {
            return all_dif(c, c.ywxz) & all_dif(c, c.wzxz);
        }


        /// <summary>       Returns <see langword="true"/> if all of the components of a <see cref="float2"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(float2 c)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 _c = RegisterConversion.ToV128(c);

                return Xse.allfalse_f128<float>(Xse.cmpeq_ps(_c, Xse.bsrli_si128(_c, 1 * sizeof(float))), 1);
            }
            else
            {
                return c.x != c.y;
            }
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of an <see cref="float3"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(float3 c)
        {
            return !math.any(c.xxz == c.yzy);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of an <see cref="float4"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(float4 c)
        {
            return !math.any(c == c.ywxz | c == c.wzxz);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of an <see cref="MaxMath.float8"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(float8 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 cmp0 = Xse.mm256_cmpeq_ps(c, Avx2.mm256_permutevar8x32_ps(c, Avx.mm256_castsi128_si256(new v128(1, 0, 3, 0))));
                v256 cmp1 = Xse.mm256_cmpeq_ps(c, Avx2.mm256_permutevar8x32_ps(c, new v256(1, 0, 7, 4, 1, 1, 1, 1)));
                v256 cmp2 = Xse.mm256_cmpeq_ps(c, Avx2.mm256_permutevar8x32_ps(c, new v256(2, 2, 5, 6, 5, 6, 7, 4)));
                v256 cmp3 = Xse.mm256_cmpeq_ps(Avx2.mm256_permute4x64_pd(c, Sse.SHUFFLE(2, 1, 1, 1)), Avx2.mm256_permute4x64_pd(c, Sse.SHUFFLE(3, 3, 2, 0)));

                v256 or = Avx.mm256_or_ps(Avx.mm256_or_ps(cmp0, cmp1), Avx.mm256_or_ps(cmp2, cmp3));

                return Xse.mm256_allfalse_f256<float>(or);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                float4 lo = c.v4_0;
                float4 hi = c.v4_4;


                float4 _0000 = lo.xxxx;
                float4 _1234 = math.shuffle(lo, hi, math.ShuffleComponent.LeftY,
                                                    math.ShuffleComponent.LeftZ,
                                                    math.ShuffleComponent.LeftW,
                                                    math.ShuffleComponent.RightX);

                v128 _1st_cmp = Xse.cmpeq_ps(RegisterConversion.ToV128(_0000), RegisterConversion.ToV128(_1234));


                float4 _0001 = lo.xxxy;
                float4 _5672 = math.shuffle(lo, hi, math.ShuffleComponent.RightY,
                                                    math.ShuffleComponent.RightZ,
                                                    math.ShuffleComponent.RightW,
                                                    math.ShuffleComponent.LeftZ);

                v128 _2nd_cmp = Xse.cmpeq_ps(RegisterConversion.ToV128(_0001), RegisterConversion.ToV128(_5672));


                float4 _1111 = lo.yyyy;
                float4 _3456 = math.shuffle(lo, hi, math.ShuffleComponent.LeftW,
                                                    math.ShuffleComponent.RightX,
                                                    math.ShuffleComponent.RightY,
                                                    math.ShuffleComponent.RightZ);

                v128 _3rd_cmp = Xse.cmpeq_ps(RegisterConversion.ToV128(_1111), RegisterConversion.ToV128(_3456));


                float4 _1222 = lo.yzzz;
                float4 _7345 = math.shuffle(lo, hi, math.ShuffleComponent.RightW,
                                                    math.ShuffleComponent.LeftW,
                                                    math.ShuffleComponent.RightX,
                                                    math.ShuffleComponent.RightY);

                v128 _4th_cmp = Xse.cmpeq_ps(RegisterConversion.ToV128(_1222), RegisterConversion.ToV128(_7345));


                float4 _2233 = lo.zzww;
                float4 _6745 = hi.zwxy;

                v128 _5th_cmp = Xse.cmpeq_ps(RegisterConversion.ToV128(_2233), RegisterConversion.ToV128(_6745));


                float4 _3344 = math.shuffle(lo, hi, math.ShuffleComponent.LeftW,
                                                    math.ShuffleComponent.LeftW,
                                                    math.ShuffleComponent.RightX,
                                                    math.ShuffleComponent.RightX);
                float4 _6756 = hi.zwyz;

                v128 _6th_cmp = Xse.cmpeq_ps(RegisterConversion.ToV128(_3344), RegisterConversion.ToV128(_6756));


                float4 _4556 = hi.xyyz;
                float4 _7677 = hi.wzww;

                v128 _7th_cmp = Xse.cmpeq_ps(RegisterConversion.ToV128(_4556), RegisterConversion.ToV128(_7677));


                v128 or = Xse.or_ps(Xse.or_ps(Xse.or_ps(_1st_cmp, _2nd_cmp),
                                              Xse.or_ps(_3rd_cmp, _4th_cmp)),
                                    Xse.or_ps(Xse.or_ps(_5th_cmp, _6th_cmp),
                                              _7th_cmp));

                return Xse.allfalse_f128<float>(or);
            }
            else
            {
                for (int i = 0; i < 8 - 1; i++)
                {
                    for (int j = i + 1; j < 8; j++)
                    {
                        if (c[i] == c[j])
                        {
                            return false;
                        }
                        else continue;
                    }
                }

                return true;
            }
        }


        /// <summary>       Returns <see langword="true"/> if all of the components of a <see cref="double2"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(double2 c)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 _c = RegisterConversion.ToV128(c);

                return Xse.allfalse_f128<double>(Xse.cmpeq_pd(_c, Xse.bsrli_si128(_c, 1 * sizeof(double))), 1);
            }
            else
            {
                return c.x != c.y;
            }
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of a <see cref="double3"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(double3 c)
        {
            return !math.any(c.xxz == c.yzy);
        }

        /// <summary>       Returns <see langword="true"/> if all of the components of a <see cref="double4"/> are unique within that vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(double4 c)
        {
            return !math.any(c == c.ywxz | c == c.wzxz);
        }
    }
}