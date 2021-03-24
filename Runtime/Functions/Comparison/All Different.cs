using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    // optimizable (imm8 shuffles instead of byte shuffles)
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns false if any of the components of a byte2 vector is equal to the corresponding component of the other byte2 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif (byte2 a, byte2 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return 0 == (maxmath.bitmask32(2 * sizeof(byte)) & Sse2.movemask_epi8(Sse2.cmpeq_epi8(a, b)));
            }
            else
            {
                return math.all(a != b);
            }
        }

        /// <summary>       Returns false if any of the components of a byte3 vector is equal to the corresponding component of the other byte3 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif (byte3 a, byte3 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return 0 == (maxmath.bitmask32(3 * sizeof(byte)) & Sse2.movemask_epi8(Sse2.cmpeq_epi8(a, b)));
            }
            else
            {
                return math.all(a != b);
            }
        }

        /// <summary>       Returns false if any of the components of a byte4 vector is equal to the corresponding component of the other byte4 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif (byte4 a, byte4 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return 0 == (maxmath.bitmask32(4 * sizeof(byte)) & Sse2.movemask_epi8(Sse2.cmpeq_epi8(a, b)));
            }
            else
            {
                return math.all(a != b);
            }
        }

        /// <summary>       Returns false if any of the components of a byte8 vector is equal to the corresponding component of the other byte8 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif (byte8 a, byte8 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return 0 == (maxmath.bitmask32(8 * sizeof(byte)) & Sse2.movemask_epi8(Sse2.cmpeq_epi8(a, b)));
            }
            else
            {
                return all(a != b);
            }
        }

        /// <summary>       Returns false if any of the components of a byte16 vector is equal to the corresponding component of the other byte16 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif (byte16 a, byte16 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return 0 == Sse2.movemask_epi8(Sse2.cmpeq_epi8(a, b));
            }
            else
            {
                return all(a != b);
            }
        }

        /// <summary>       Returns false if any of the components of a byte32 vector is equal to the corresponding component of the other byte32 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif (byte32 a, byte32 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return 0 == Avx2.mm256_movemask_epi8(Avx2.mm256_cmpeq_epi8(a, b));
            }
            else if (Sse2.IsSse2Supported)
            {
                return all_dif (a.v16_0, b.v16_0) & all_dif (a.v16_16, b.v16_16);
            }
            else
            {
                return all(a != b);
            }
        }


        /// <summary>       Returns false if any of the components of an sbyte2 vector is equal to the corresponding component of the other sbyte2 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif (sbyte2 a, sbyte2 b)
        {
            return all_dif ((byte2)a, (byte2)b);
        }

        /// <summary>       Returns false if any of the components of an sbyte3 vector is equal to the corresponding component of the other sbyte3 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif (sbyte3 a, sbyte3 b)
        {
            return all_dif ((byte3)a, (byte3)b);
        }

        /// <summary>       Returns false if any of the components of an sbyte4 vector is equal to the corresponding component of the other sbyte4 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif (sbyte4 a, sbyte4 b)
        {
            return all_dif ((byte4)a, (byte4)b);
        }

        /// <summary>       Returns false if any of the components of an sbyte8 vector is equal to the corresponding component of the other sbyte8 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif (sbyte8 a, sbyte8 b)
        {
            return all_dif ((byte8)a, (byte8)b);
        }

        /// <summary>       Returns false if any of the components of an sbyte16 vector is equal to the corresponding component of the other sbyte16 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif (sbyte16 a, sbyte16 b)
        {
            return all_dif ((byte16)a, (byte16)b);
        }

        /// <summary>       Returns false if any of the components of an sbyte32 vector is equal to the corresponding component of the other sbyte32 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif (sbyte32 a, sbyte32 b)
        {
            return all_dif ((byte32)a, (byte32)b);
        }


        /// <summary>       Returns false if any of the components of a short2 vector is equal to the corresponding component of the other short2 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif (short2 a, short2 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return 0 == (maxmath.bitmask32(2 * sizeof(short)) & Sse2.movemask_epi8(Sse2.cmpeq_epi16(a, b)));
            }
            else
            {
                return math.all(a != b);
            }
        }

        /// <summary>       Returns false if any of the components of a short3 vector is equal to the corresponding component of the other short3 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif (short3 a, short3 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return 0 == (maxmath.bitmask32(3 * sizeof(short)) & Sse2.movemask_epi8(Sse2.cmpeq_epi16(a, b)));
            }
            else
            {
                return math.all(a != b);
            }
        }

        /// <summary>       Returns false if any of the components of a short4 vector is equal to the corresponding component of the other short4 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif (short4 a, short4 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return 0 == (maxmath.bitmask32(4 * sizeof(short)) & Sse2.movemask_epi8(Sse2.cmpeq_epi16(a, b)));
            }
            else
            {
                return math.all(a != b);
            }
        }

        /// <summary>       Returns false if any of the components of a short8 vector is equal to the corresponding component of the other short8 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif (short8 a, short8 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return 0 == Sse2.movemask_epi8(Sse2.cmpeq_epi16(a, b));
            }
            else
            {
                return all(a != b);
            }
        }

        /// <summary>       Returns false if any of the components of a short16 vector is equal to the corresponding component of the other short16 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif (short16 a, short16 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return 0 == Avx2.mm256_movemask_epi8(Avx2.mm256_cmpeq_epi16(a, b));
            }
            else if (Sse2.IsSse2Supported)
            {
                return all_dif (a.v8_0, b.v8_0) & all_dif (a.v8_8, b.v8_8);
            }
            else
            {
                return all(a != b);
            }
        }


        /// <summary>       Returns false if any of the components of a ushort2 vector is equal to the corresponding component of the other ushort2 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif (ushort2 a, ushort2 b)
        {
            return all_dif ((short2)a, (short2)b);
        }

        /// <summary>       Returns false if any of the components of a ushort3 vector is equal to the corresponding component of the other ushort3 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif (ushort3 a, ushort3 b)
        {
            return all_dif ((short3)a, (short3)b);
        }

        /// <summary>       Returns false if any of the components of a ushort4 vector is equal to the corresponding component of the other ushort4 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif (ushort4 a, ushort4 b)
        {
            return all_dif ((short4)a, (short4)b);
        }

        /// <summary>       Returns false if any of the components of a ushort8 vector is equal to the corresponding component of the other ushort8 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif (ushort8 a, ushort8 b)
        {
            return all_dif ((short8)a, (short8)b);
        }

        /// <summary>       Returns false if any of the components of a ushort16 vector is equal to the corresponding component of the other ushort16 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif (ushort16 a, ushort16 b)
        {
            return all_dif ((short16)a, (short16)b);
        }


        /// <summary>       Returns false if any of the components of an int2 vector is equal to the corresponding component of the other int2 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif (int2 a, int2 b)
        {
            return math.all(a != b);
        }

        /// <summary>       Returns false if any of the components of an int3 vector is equal to the corresponding component of the other int3 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif (int3 a, int3 b)
        {
            return math.all(a != b);
        }

        /// <summary>       Returns false if any of the components of an int4 vector is equal to the corresponding component of the other int4 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif (int4 a, int4 b)
        {
            return math.all(a != b);
        }

        /// <summary>       Returns false if any of the components of an int8 vector is equal to the corresponding component of the other int8 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif (int8 a, int8 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return 0 == Avx2.mm256_movemask_epi8(Avx2.mm256_cmpeq_epi32(a, b));
            }
            else if (Sse2.IsSse2Supported)
            {
                return math.all(a.v4_0 != b.v4_0) & math.all(a.v4_4 != b.v4_4);
            }
            else
            {
                return all(a != b);
            }
        }


        /// <summary>       Returns false if any of the components of a uint2 vector is equal to the corresponding component of the other uint2 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif (uint2 a, uint2 b)
        {
            return math.all(a != b);
        }

        /// <summary>       Returns false if any of the components of a uint3 vector is equal to the corresponding component of the other uint3 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif (uint3 a, uint3 b)
        {
            return math.all(a != b);
        }

        /// <summary>       Returns false if any of the components of a uint4 vector is equal to the corresponding component of the other uint4 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif (uint4 a, uint4 b)
        {
            return math.all(a != b);
        }

        /// <summary>       Returns false if any of the components of a uint8 vector is equal to the corresponding component of the other uint8 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif (uint8 a, uint8 b)
        {
            return all_dif ((int8)a, (int8)b);
        }


        /// <summary>       Returns false if any of the components of a long2 vector is equal to the corresponding component of the other long2 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif (long2 a, long2 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return 0 == (Sse2.movemask_epi8(Operator.equals_mask_long(a, b)));
            }
            else
            {
                return math.all(a != b);
            }
        }

        /// <summary>       Returns false if any of the components of a long3 vector is equal to the corresponding component of the other long3 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif (long3 a, long3 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return 0 == (maxmath.bitmask32(3 * sizeof(long)) & Avx2.mm256_movemask_epi8(Avx2.mm256_cmpeq_epi64(a, b)));
            }
            else
            {
                return all_dif(a.xy, b.xy) & a.z != b.z;
            }
        }

        /// <summary>       Returns false if any of the components of a long4 vector is equal to the corresponding component of the other long4 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif (long4 a, long4 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return 0 == (Avx2.mm256_movemask_epi8(Avx2.mm256_cmpeq_epi64(a, b)));
            }
            else
            {
                return all_dif(a.xy, b.xy) & all_dif(a.zw, b.zw);
            }
        }


        /// <summary>       Returns false if any of the components of a ulong2 vector is equal to the corresponding component of the other ulong2 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif (ulong2 a, ulong2 b)
        {
            return all_dif ((long2)a, (long2)b);
        }

        /// <summary>       Returns false if any of the components of a ulong3 vector is equal to the corresponding component of the other ulong3 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif (ulong3 a, ulong3 b)
        {
            return all_dif ((long3)a, (long3)b);
        }

        /// <summary>       Returns false if any of the components of a ulong4 vector is equal to the corresponding component of the other ulong4 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif (ulong4 a, ulong4 b)
        {
            return all_dif ((long4)a, (long4)b);
        }


        /// <summary>       Returns true if all of the components of a byte3 vector are unique within that vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif (byte3 c)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return all_dif(c.xxzx, c.yzyy);
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

        /// <summary>       Returns true if all of the components of a byte4 vector are unique within that vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif (byte4 c)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return all_dif ((byte16)Ssse3.shuffle_epi8(c, new v128(0, 0, 0, 1, 1, 2,    0, 0, 0, 0, 0, 0, 0, 0, 0, 0)),
                                (byte16)Ssse3.shuffle_epi8(c, new v128(1, 2, 3, 2, 3, 3,    1, 1, 1, 1, 1, 1, 1, 1, 1, 1)));
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

        /// <summary>       Returns true if all of the components of a byte8 vector are unique within that vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif (byte8 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 cccc = Avx2.mm256_broadcastq_epi64(c);

                v256 or = Avx2.mm256_cmpeq_epi8(Avx2.mm256_shuffle_epi8(cccc, new v256(0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 2, 2, 2,
                                                                                       2, 2, 3, 3, 3, 3, 4, 4, 4, 5, 5, 6, 0, 0, 0, 0)),
                                                Avx2.mm256_shuffle_epi8(cccc, new v256(1, 2, 3, 4, 5, 6, 7, 2, 3, 4, 5, 6, 7, 3, 4, 5,
                                                                                       6, 7, 4, 5, 6, 7, 5, 6, 7, 6, 7, 7, 1, 1, 1, 1)));
                 
                return 0 == Avx2.mm256_movemask_epi8(or);
            }
            else if (Ssse3.IsSsse3Supported)
            {
                v128 cmp0 = Sse2.cmpeq_epi8(Sse2.shuffle_epi32(c, Sse.SHUFFLE(0, 0, 0, 0)), // Int0 = Byte 0, 1, 2, 3
                                            Ssse3.shuffle_epi8(c, new v128(4, 5, 0, 7, 1, 6, 7, 5, 6, 2, 4, 6, 3, 3, 3, 4)));

                v128 cmp1 = Sse2.cmpeq_epi8(Sse2.shuffle_epi32(c, Sse.SHUFFLE(1, 1, 1, 1)), // Int1 = Byte 4, 5, 6, 7
                                            Ssse3.shuffle_epi8(c, new v128(1, 2, 2, 0, 5, 0, 7, 1, 6, 6, 7, 6, 7, 7, 7, 6)));

                return 0 == Sse2.movemask_epi8(Sse2.or_si128(cmp0, cmp1));
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

        /// <summary>       Returns true if all of the components of a byte16 vector are unique within that vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif (byte16 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 cc = Avx2.mm256_broadcastsi128_si256(c);

                v256 or = Avx2.mm256_or_si256(Avx2.mm256_cmpeq_epi8(Avx2.mm256_shuffle_epi8(cc, new v256(0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,
                                                                                                         1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  2,  2,  2)),
                                                                    Avx2.mm256_shuffle_epi8(cc, new v256(1,  2,  3,  4,  5,  6,  7,  8,  9,  10, 11, 12, 13, 14, 15, 2,
                                                                                                         3,  4,  5,  6,  7,  8,  9,  10, 11, 12, 13, 14, 15, 3,  4,  5))),
                          Avx2.mm256_or_si256(Avx2.mm256_cmpeq_epi8(Avx2.mm256_shuffle_epi8(cc, new v256(2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  3,  3,  3,  3,  3,  3,
                                                                                                         3,  3,  3,  3,  3,  3,  4,  4,  4,  4,  4,  4,  4,  4,  4,  4)),
                                                                    Avx2.mm256_shuffle_epi8(cc, new v256(6,  7,  8,  9,  10, 11, 12, 13, 14, 15, 4,  5,  6,  7,  8,  9,
                                                                                                         10, 11, 12, 13, 14, 15, 5,  6,  7,  8,  9,  10, 11, 12, 13, 14))),
                          Avx2.mm256_or_si256(Avx2.mm256_cmpeq_epi8(Avx2.mm256_shuffle_epi8(cc, new v256(4,  5,  5,  5,  5,  5,  5,  5,  5,  5,  5,  6,  6,  6,  6,  6,
                                                                                                         6,  6,  6,  6,  7,  7,  7,  7,  7,  7,  7,  7,  8,  8,  8,  8)),
                                                                    Avx2.mm256_shuffle_epi8(cc, new v256(15, 6,  7,  8,  9,  10, 11, 12, 13, 14, 15, 7,  8,  9,  10, 11,
                                                                                                         12, 13, 14, 15, 8,  9,  10, 11, 12, 13, 14, 15, 9,  10, 11, 12))),
                                              Avx2.mm256_cmpeq_epi8(Avx2.mm256_shuffle_epi8(cc, new v256(8,  8,  8,  9,  9,  9,  9,  9,  9,  10, 10, 10, 10, 10, 11, 11,
                                                                                                         11, 11, 12, 12, 12, 13, 13, 14, 0,  0,  0,  0,  0,  0,  0,  0)),
                                                                    Avx2.mm256_shuffle_epi8(cc, new v256(13, 14, 15, 10, 11, 12, 13, 14, 15, 11, 12, 13, 14, 15, 12, 13,
                                                                                                         14, 15, 13, 14, 15, 14, 15, 15, 1,  1,  1,  1,  1,  1,  1,  1))))));

                return 0 == Avx2.mm256_movemask_epi8(or);
            }
            else if (Ssse3.IsSsse3Supported)
            {
                v128 or = Sse2.or_si128(Sse2.or_si128(Sse2.or_si128(Sse2.cmpeq_epi8(Ssse3.shuffle_epi8(c, new v128(0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1)),
                                                                                    Ssse3.shuffle_epi8(c, new v128(1,  2,  3,  4,  5,  6,  7,  8,  9, 10, 11, 12, 13, 14, 15,  2))),

                                                                    Sse2.cmpeq_epi8(Ssse3.shuffle_epi8(c, new v128(1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  2,  2,  2)),
                                                                                    Ssse3.shuffle_epi8(c, new v128(3,  4,  5,  6,  7,  8,  9,  10, 11, 12, 13, 14, 15, 3,  4,  5)))),

                                                      Sse2.or_si128(Sse2.cmpeq_epi8(Ssse3.shuffle_epi8(c, new v128(2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  3,  3,  3,  3,  3,  3)),
                                                                                    Ssse3.shuffle_epi8(c, new v128(6,  7,  8,  9,  10, 11, 12, 13, 14, 15, 4,  5,  6,  7,  8,  9))),

                                                                    Sse2.cmpeq_epi8(Ssse3.shuffle_epi8(c, new v128(3,  3,  3,  3,  3,  3,  4,  4,  4,  4,  4,  4,  4,  4,  4,  4)),
                                                                                    Ssse3.shuffle_epi8(c, new v128(10, 11, 12, 13, 14, 15, 5,  6,  7,  8,  9,  10, 11, 12, 13, 14))))),

                                        Sse2.or_si128(Sse2.or_si128(Sse2.cmpeq_epi8(Ssse3.shuffle_epi8(c, new v128(4,  5,  5,  5,  5,  5,  5,  5,  5,  5,  5,  6,  6,  6,  6,  6)),
                                                                                    Ssse3.shuffle_epi8(c, new v128(15, 6,  7,  8,  9,  10, 11, 12, 13, 14, 15, 7,  8,  9,  10, 11))),

                                                                    Sse2.cmpeq_epi8(Ssse3.shuffle_epi8(c, new v128(6,  6,  6,  6,  7,  7,  7,  7,  7,  7,  7,  7,  8,  8,  8,  8)),
                                                                                    Ssse3.shuffle_epi8(c, new v128(12, 13, 14, 15, 8,  9,  10, 11, 12, 13, 14, 15, 9,  10, 11, 12)))),

                                                      Sse2.or_si128(Sse2.cmpeq_epi8(Ssse3.shuffle_epi8(c, new v128(8,  8,  8,  9,  9,  9,  9,  9,  9,  10, 10, 10, 10, 10, 11, 11)),
                                                                                    Ssse3.shuffle_epi8(c, new v128(13, 14, 15, 10, 11, 12, 13, 14, 15, 11, 12, 13, 14, 15, 12, 13))),

                                                                    Sse2.cmpeq_epi8(Ssse3.shuffle_epi8(c, new v128(11, 11, 12, 12, 12, 13, 13, 14,    0,  0,  0,  0,  0,  0,  0,  0)),
                                                                                    Ssse3.shuffle_epi8(c, new v128(14, 15, 13, 14, 15, 14, 15, 15,    1,  1,  1,  1,  1,  1,  1,  1))))));

                return 0 == Sse2.movemask_epi8(or);
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

        /// <summary>       Returns true if all of the components of a byte32 vector are unique within that vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif (byte32 c)
        {
            if (Avx2.IsAvx2Supported)
            {

                v256 lolo = Avx2.mm256_broadcastsi128_si256(Avx.mm256_castsi256_si128(c));
                v256 hihi = Avx2.mm256_permute4x64_epi64(c, Sse.SHUFFLE(3, 2, 3, 2));



                v256 _0 = Avx2.mm256_cmpeq_epi8(Avx2.mm256_shuffle_epi8(lolo, new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2)),
                                                Avx2.mm256_shuffle_epi8(lolo, new v256(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 3, 4, 5)));

                v256 _1 = Avx2.mm256_cmpeq_epi8(Avx2.mm256_shuffle_epi8(lolo, new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1)),
                                                Avx2.mm256_shuffle_epi8(hihi, new v256(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15)));

                v256 _2 = Avx2.mm256_cmpeq_epi8(Avx2.mm256_shuffle_epi8(lolo, new v256(2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4)),
                                                Avx2.mm256_shuffle_epi8(lolo, new v256(6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14)));

                v256 _3 = Avx2.mm256_cmpeq_epi8(Avx2.mm256_shuffle_epi8(lolo, new v256(2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3)),
                                                Avx2.mm256_shuffle_epi8(hihi, new v256(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15)));

                v256 _4 = Avx2.mm256_cmpeq_epi8(Avx2.mm256_shuffle_epi8(lolo, new v256(4, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 6, 6, 6, 6, 6, 6, 6, 6, 6, 7, 7, 7, 7, 7, 7, 7, 7, 8, 8, 8, 8)),
                                                Avx2.mm256_shuffle_epi8(lolo, new v256(15, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 7, 8, 9, 10, 11, 12, 13, 14, 15, 8, 9, 10, 11, 12, 13, 14, 15, 9, 10, 11, 12)));

                v256 _5 = Avx2.mm256_cmpeq_epi8(Avx2.mm256_shuffle_epi8(lolo, new v256(4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5)),
                                                Avx2.mm256_shuffle_epi8(hihi, new v256(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15)));

                v256 _6 = Avx2.mm256_cmpeq_epi8(Avx2.mm256_shuffle_epi8(lolo, new v256(6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7)),
                                                Avx2.mm256_shuffle_epi8(hihi, new v256(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15)));

                v256 _7 = Avx2.mm256_cmpeq_epi8(Avx2.mm256_shuffle_epi8(lolo, new v256(8, 8, 8, 9, 9, 9, 9, 9, 9, 10, 10, 10, 10, 10, 11, 11, 11, 11, 12, 12, 12, 13, 13, 14, 0, 0, 0, 0, 0, 0, 0, 0)),
                                                Avx2.mm256_shuffle_epi8(lolo, new v256(13, 14, 15, 10, 11, 12, 13, 14, 15, 11, 12, 13, 14, 15, 12, 13, 14, 15, 13, 14, 15, 14, 15, 15, 1, 1, 1, 1, 1, 1, 1, 1)));

                v256 _8 = Avx2.mm256_cmpeq_epi8(Avx2.mm256_shuffle_epi8(lolo, new v256(8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9)),
                                                Avx2.mm256_shuffle_epi8(hihi, new v256(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15)));

                v256 _9 = Avx2.mm256_cmpeq_epi8(Avx2.mm256_shuffle_epi8(hihi, new v256(0, 0, 0, 0, 0, 0, 0, 0, 9, 10, 10, 10, 10, 10, 11, 11, 11, 11, 12, 12, 12, 13, 13, 14, 0, 0, 0, 0, 0, 0, 0, 0)),
                                                Avx2.mm256_shuffle_epi8(hihi, new v256(1, 2, 3, 4, 5, 6, 7, 8, 15, 11, 12, 13, 14, 15, 12, 13, 14, 15, 13, 14, 15, 14, 15, 15, 1, 1, 1, 1, 1, 1, 1, 1)));

                v256 _10 = Avx2.mm256_cmpeq_epi8(Avx2.mm256_shuffle_epi8(lolo, new v256(10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11)),
                                                 Avx2.mm256_shuffle_epi8(hihi, new v256(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15)));

                v256 _11 = Avx2.mm256_cmpeq_epi8(Avx2.mm256_shuffle_epi8(lolo, new v256(14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15)),
                                                 Avx2.mm256_shuffle_epi8(hihi, new v256(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15)));

                v256 _12 = Avx2.mm256_cmpeq_epi8(Avx2.mm256_shuffle_epi8(lolo, new v256(12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13)),
                                                 Avx2.mm256_shuffle_epi8(hihi, new v256(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15)));

                v256 _13 = Avx2.mm256_cmpeq_epi8(Avx2.mm256_shuffle_epi8(hihi, new v256(0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2)),
                                                 Avx2.mm256_shuffle_epi8(hihi, new v256(9, 10, 11, 12, 13, 14, 15, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13)));

                v256 _14 = Avx2.mm256_cmpeq_epi8(Avx2.mm256_shuffle_epi8(hihi, new v256(2, 2, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 5, 5, 5, 5, 5, 5, 5)),
                                                 Avx2.mm256_shuffle_epi8(hihi, new v256(14, 15, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 6, 7, 8, 9, 10, 11, 12)));

                v256 _15 = Avx2.mm256_cmpeq_epi8(Avx2.mm256_shuffle_epi8(hihi, new v256(5, 5, 5, 6, 6, 6, 6, 6, 6, 6, 6, 6, 7, 7, 7, 7, 7, 7, 7, 7, 8, 8, 8, 8, 8, 8, 8, 9, 9, 9, 9, 9)),
                                                 Avx2.mm256_shuffle_epi8(hihi, new v256(13, 14, 15, 7, 8, 9, 10, 11, 12, 13, 14, 15, 8, 9, 10, 11, 12, 13, 14, 15, 9, 10, 11, 12, 13, 14, 15, 10, 11, 12, 13, 14)));


                v256 or = Avx2.mm256_or_si256(Avx2.mm256_or_si256(Avx2.mm256_or_si256(Avx2.mm256_or_si256(Avx2.mm256_or_si256(Avx2.mm256_or_si256(Avx2.mm256_or_si256(Avx2.mm256_or_si256(Avx2.mm256_or_si256(Avx2.mm256_or_si256(Avx2.mm256_or_si256(Avx2.mm256_or_si256(Avx2.mm256_or_si256(Avx2.mm256_or_si256(Avx2.mm256_or_si256(_0, _1), _2), _3), _4), _5), _6), _7), _8), _9), _10), _11), _12), _13), _14), _15);

                return 0 == Avx2.mm256_movemask_epi8(or);




                //Avx2.mm256_shuffle_epi8(lolo, new v256(0, 0, 0, 0, 0, 0, 0, 0, 0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0, 1));
                //Avx2.mm256_shuffle_epi8(lolo, new v256(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 2));
                //
                //Avx2.mm256_shuffle_epi8(lolo, new v256(1, 1, 1, 1, 1, 1, 1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1, 2, 2, 2));
                //Avx2.mm256_shuffle_epi8(lolo, new v256(3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 3, 4, 5));
                //
                //Avx2.mm256_shuffle_epi8(lolo, new v256(2, 2, 2, 2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2, 3, 3, 3, 3, 3, 3));
                //Avx2.mm256_shuffle_epi8(lolo, new v256(6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 4, 5, 6, 7, 8, 9));
                //
                //Avx2.mm256_shuffle_epi8(lolo, new v256( 3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3, 4, 4, 4, 4, 4,  4,  4,  4,  4,  4));
                //Avx2.mm256_shuffle_epi8(lolo, new v256(10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14));
                //
                //Avx2.mm256_shuffle_epi8(lolo, new v256( 4,  4,  4,  4,  4,  4,  4,  4,  4,  4,  4,  4,  4,  4,  4,  4,  4, 5, 5, 5, 5,  5,  5,  5,  5,  5,  5,  5,  5,  5,  5,  5));
                //Avx2.mm256_shuffle_epi8(lolo, new v256(15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20));
                //
                //Avx2.mm256_shuffle_epi8(lolo, new v256( 5,  5,  5,  5,  5,  5,  5,  5,  5,  5,  5, 6, 6, 6,  6,  6,  6,  6,  6,  6,  6,  6,  6,  6,  6,  6,  6,  6,  6,  6,  6,  6));
                //Avx2.mm256_shuffle_epi8(lolo, new v256(21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27));
                //
                //Avx2.mm256_shuffle_epi8(lolo, new v256( 6,  6,  6,  6, 7, 7,  7,  7,  7,  7,  7,  7,  7,  7,  7,  7,  7,  7,  7,  7,  7,  7,  7,  7,  7,  7,  7,  7, 8,  8,  8,  8));
                //Avx2.mm256_shuffle_epi8(lolo, new v256(28, 29, 30, 31, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 9, 10, 11, 12));
                //
                //Avx2.mm256_shuffle_epi8(lolo, new v256( 8,  8,  8,  8,  8,  8,  8,  8,  8,  8,  8,  8,  8,  8,  8,  8,  8,  8,  8,  9,  9,  9,  9,  9,  9,  9,  9,  9,  9,  9,  9,  9));
                //Avx2.mm256_shuffle_epi8(lolo, new v256(13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22));
                //
                //Avx2.mm256_shuffle_epi8(lolo, new v256( 9,  9,  9,  9,  9,  9,  9,  9,  9, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 11, 11));
                //Avx2.mm256_shuffle_epi8(lolo, new v256(23, 24, 25, 26, 27, 28, 29, 30, 31, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 12, 13));
                //
                //Avx2.mm256_shuffle_epi8(lolo, new v256(11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12));
                //Avx2.mm256_shuffle_epi8(lolo, new v256(14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26));
                //
                //Avx2.mm256_shuffle_epi8(lolo, new v256(12, 12, 12, 12, 12, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 14, 14, 14, 14, 14, 14, 14, 14, 14));
                //Avx2.mm256_shuffle_epi8(lolo, new v256(27, 28, 29, 30, 31, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 15, 16, 17, 18, 19, 20, 21, 22, 23));
                //
                //Avx2.mm256_shuffle_epi8(lolo, new v256(14, 14, 14, 14, 14, 14, 14, 14, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 16, 16, 16, 16, 16, 16, 16, 16));
                //Avx2.mm256_shuffle_epi8(lolo, new v256(24, 25, 26, 27, 28, 29, 30, 31, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 17, 18, 19, 20, 21, 22, 23, 24));
                //
                //Avx2.mm256_shuffle_epi8(hihi, new v256(16, 16, 16, 16, 16, 16, 16, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 18, 18, 18, 18, 18, 18, 18, 18, 18, 18, 18));
                //Avx2.mm256_shuffle_epi8(hihi, new v256(25, 26, 27, 28, 29, 30, 31, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29));
                //
                //Avx2.mm256_shuffle_epi8(hihi, new v256(18, 18, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 21, 21, 21, 21, 21, 21, 21));
                //Avx2.mm256_shuffle_epi8(hihi, new v256(30, 31, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 22, 23, 24, 25, 26, 27, 28));
                //
                //Avx2.mm256_shuffle_epi8(hihi, new v256(21, 21, 21, 22, 22, 22, 22, 22, 22, 22, 22, 22, 23, 23, 23, 23, 23, 23, 23, 23, 24, 24, 24, 24, 24, 24, 24, 25, 25, 25, 25, 25));
                //Avx2.mm256_shuffle_epi8(hihi, new v256(29, 30, 31, 23, 24, 25, 26, 27, 28, 29, 30, 31, 24, 25, 26, 27, 28, 29, 30, 31, 25, 26, 27, 28, 29, 30, 31, 26, 27, 28, 29, 30));
                //
                //Avx2.mm256_shuffle_epi8(hihi, new v256(25, 26, 26, 26, 26, 26, 27, 27, 27, 27, 28, 28, 28, 29, 29, 30,     0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
                //Avx2.mm256_shuffle_epi8(hihi, new v256(31, 27, 28, 29, 30, 31, 28, 29, 30, 31, 29, 30, 31, 30, 31, 31,     1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1));
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


        /// <summary>       Returns true if all of the components of an sbyte3 vector are unique within that vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif (sbyte3 c)
        {
            return all_dif ((short3)c);
        }

        /// <summary>       Returns true if all of the components of an sbyte4 vector are unique within that vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif (sbyte4 c)
        {
            return all_dif ((byte4)c);
        }

        /// <summary>       Returns true if all of the components of an sbyte8 vector are unique within that vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif (sbyte8 c)
        {
            return all_dif ((byte8)c);
        }

        /// <summary>       Returns true if all of the components of an sbyte16 vector are unique within that vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif (sbyte16 c)
        {
            return all_dif ((byte16)c);
        }

        /// <summary>       Returns true if all of the components of an sbyte32 vector are unique within that vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif (sbyte32 c)
        {
            return all_dif((byte32)c);
        }


        /// <summary>       Returns true if all of the components of a short3 vector are unique within that vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif (short3 c)
        {
            if (Sse2.IsSse2Supported)
            {
                return all_dif(c.xxzx, c.yzyy);
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

        /// <summary>       Returns true if all of the components of a short4 vector are unique within that vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif (short4 c)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return all_dif ((short8)Ssse3.shuffle_epi8(c, new v128(0, 1,  0, 1,  0, 1,  2, 3,  2, 3,  4, 5,    0, 1, 0, 1)),
                                (short8)Ssse3.shuffle_epi8(c, new v128(2, 3,  4, 5,  6, 7,  4, 5,  6, 7,  6, 7,    2, 3, 2, 3)));
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

        /// <summary>       Returns true if all of the components of a short8 vector are unique within that vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif (short8 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 cc = Avx2.mm256_broadcastsi128_si256(c);

                v256 or = Avx2.mm256_or_si256(Avx2.mm256_cmpeq_epi16(Avx2.mm256_shuffle_epi8(cc, new v256(0,  1,  0,  1,  0,  1,  0,  1,  0,  1,  0,  1,  0,  1,  2,  3,
                                                                                                          2,  3,  2,  3,  2,  3,  2,  3,  2,  3,  4,  5,  4,  5,  4,  5)),
                                                                     Avx2.mm256_shuffle_epi8(cc, new v256(2,  3,  4,  5,  6,  7,  8,  9,  10, 11, 12, 13, 14, 15, 4,  5,
                                                                                                          6,  7,  8,  9,  10, 11, 12, 13, 14, 15, 6,  7,  8,  9,  10, 11))),
                                              Avx2.mm256_cmpeq_epi16(Avx2.mm256_shuffle_epi8(cc, new v256(4,  5,  4,  5,  6,  7,  6,  7,  6,  7,  6,  7,  8,  9,  8,  9,
                                                                                                          8,  9,  10, 11, 10, 11, 12, 13, 0,  1,  0,  1,  0,  1,  0,  1)),
                                                                     Avx2.mm256_shuffle_epi8(cc, new v256(12, 13, 14, 15, 8,  9,  10, 11, 12, 13, 14, 15, 10, 11, 12, 13,
                                                                                                          14, 15, 12, 13, 14, 15, 14, 15, 2,  3,  2,  3,  2,  3,  2,  3))));

                return 0 == Avx2.mm256_movemask_epi8(or);

            }
            else if (Ssse3.IsSsse3Supported)
            {
                //v128 or = Sse2.or_si128(Sse2.or_si128(Sse2.cmpeq_epi16(Ssse3.shuffle_epi8(c, new v128(0,  1,  0,  1,  0,  1,  0,  1,  0,  1,  0,  1,  0,  1,  2,  3)),
                //                                                       Ssse3.shuffle_epi8(c, new v128(2,  3,  4,  5,  6,  7,  8,  9,  10, 11, 12, 13, 14, 15, 4,  5))),
                //
                //                                      Sse2.cmpeq_epi16(Ssse3.shuffle_epi8(c, new v128(2,  3,  2,  3,  2,  3,  2,  3,  2,  3,  4,  5,  4,  5,  4,  5)),
                //                                                       Ssse3.shuffle_epi8(c, new v128(6,  7,  8,  9,  10, 11, 12, 13, 14, 15, 6,  7,  8,  9,  10, 11)))),
                //
                //                        Sse2.or_si128(Sse2.cmpeq_epi16(Ssse3.shuffle_epi8(c, new v128(4,  5,  4,  5,  6,  7,  6,  7,  6,  7,  6,  7,  8,  9,  8,  9)),
                //                                                       Ssse3.shuffle_epi8(c, new v128(12, 13, 14, 15, 8,  9,  10, 11, 12, 13, 14, 15, 10, 11, 12, 13))),
                //
                //                                      Sse2.cmpeq_epi16(Ssse3.shuffle_epi8(c, new v128(8,  9,  10, 11, 10, 11, 12, 13,     0,  1,  0,  1,  0,  1,  0,  1)),
                //                                                       Ssse3.shuffle_epi8(c, new v128(14, 15, 12, 13, 14, 15, 14, 15,     2,  3,  2,  3,  2,  3,  2,  3)))));
                                                                                                                                            

                v128 or = Sse2.or_si128(Sse2.or_si128(Sse2.cmpeq_epi16(Ssse3.shuffle_epi8(c, new v128(2, 3,   0, 1,   6, 7,   0, 1,   0, 1,   0, 1,   0, 1,   0, 1)),
                                                                       c),
                                                      Sse2.cmpeq_epi16(Ssse3.shuffle_epi8(c, new v128(2, 3,   0, 1,   14, 15,   8, 9,   2, 3,   2, 3,   2, 3,   2, 3)),
                                                                       c)),
                                        Sse2.or_si128(Sse2.cmpeq_epi16(Ssse3.shuffle_epi8(c, new v128(4, 5,   4, 5,   10, 11,   12, 13,   10, 11,   12, 13,   14, 15,   8, 9)),
                                                                       c),
                                                      Sse2.cmpeq_epi16(Sse2.shuffle_epi32(c, Sse.SHUFFLE(2, 1, 1, 1)),
                                                                       Sse2.shuffle_epi32(c, Sse.SHUFFLE(3, 3, 2, 0)))));

                return 0 == Sse2.movemask_epi8(or);
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

        /// <summary>       Returns true if all of the components of a short16 vector are unique within that vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif (short16 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                short16 lolo = Avx2.mm256_broadcastsi128_si256(Avx.mm256_castsi256_si128(c)); 
                short16 hihi = Avx2.mm256_permute4x64_epi64(c, Sse.SHUFFLE(3, 2, 3, 2));

                  
                v256 cmp01  = Avx2.mm256_cmpeq_epi16(Avx2.mm256_shuffle_epi8(lolo, new v256(2, 3, 0, 1, 0, 1, 0, 1, 0, 1,  0,  1,  0,  1,  0,  1,      4, 5, 4, 5,  4,  5, 2, 3, 2, 3,  2,  3,  2,  3,  2,  3)),
                                                     Avx2.mm256_shuffle_epi8(lolo, new v256(4, 5, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15,      6, 7, 8, 9, 10, 11, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15)));
                
                v256 cmp12  = Avx2.mm256_cmpeq_epi16(Avx2.mm256_shuffle_epi8(lolo, new v256(0, 1, 0, 1, 0, 1, 0, 1, 0, 1,  0,  1,  0,  1,  0,  1,      2, 3, 2, 3, 2, 3, 2, 3, 2, 3,  2,  3,  2,  3,  2,  3)),
                                                     hihi);

                v256 cmp234 = Avx2.mm256_cmpeq_epi16(Avx2.mm256_shuffle_epi8(lolo, new v256( 4,  5,  4,  5, 6, 7,  6,  7,  6,  7,  6,  7,  8,  9,  8,  9,  8,  9,        10, 11, 10, 11, 12, 13, 0, 1, 0, 1, 0, 1, 0, 1)),
                                                     Avx2.mm256_shuffle_epi8(lolo, new v256(12, 13, 14, 15, 8, 9, 10, 11, 12, 13, 14, 15, 10, 11, 12, 13, 14, 15,        12, 13, 14, 15, 14, 15, 2, 3, 2, 3, 2, 3, 2, 3)));
                
                v256 cmp23hi = Avx2.mm256_cmpeq_epi16(Avx2.mm256_shuffle_epi8(lolo, new v256(4, 5, 4, 5, 4, 5, 4, 5, 4, 5,  4,  5,  4,  5,  4,  5,       6, 7, 6, 7, 6, 7, 6, 7, 6, 7,  6,  7,  6,  7,  6,  7)),
                                                      hihi);
                
                v256 cmp45hi = Avx2.mm256_cmpeq_epi16(Avx2.mm256_shuffle_epi8(lolo, new v256(8, 9, 8, 9, 8, 9, 8, 9, 8, 9,  8,  9,  8,  9,  8,  9,     10, 11, 10, 11, 10, 11, 10, 11, 10, 11, 10, 11, 10, 11, 10, 11)),
                                                      hihi);       
       
                v256 cmp78 = Avx2.mm256_cmpeq_epi16(Avx2.mm256_shuffle_epi8(c,    new v256(14, 15, 14, 15, 14, 15, 14, 15, 14, 15, 14, 15, 14, 15, 14, 15,      0, 1, 0, 1, 0, 1, 0, 1,  0,  1,  0,  1,  0,  1,  0,  1)),
                                                    Avx2.mm256_shuffle_epi8(hihi, new v256( 0,  1,  2,  3,  4,  5,  6,  7,  8,  9, 10, 11, 12, 13, 14, 15,      2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 14, 15)));
                                                                                             
                v256 _9_10_11 = Avx2.mm256_cmpeq_epi16(Avx2.mm256_shuffle_epi8(hihi, new v256(2, 3, 2, 3, 2, 3,  2,  3,  2,  3,  2,  3, 4, 5, 4, 5,        4,  5,  4,  5,  4,  5, 6, 7,  6,  7,  6,  7,  6,  7,  8,  9)),
                                                       Avx2.mm256_shuffle_epi8(hihi, new v256(4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 6, 7, 8, 9,       10, 11, 12, 13, 14, 15, 8, 9, 10, 11, 12, 13, 14, 15, 10, 11)));

                v128 rest = Sse2.cmpeq_epi16(Ssse3.shuffle_epi8(Avx.mm256_castsi256_si128(hihi), new v128( 8,  9,  8,  9, 10, 11, 10, 11, 12, 13,    0, 1, 0, 1, 0, 1)),
                                             Ssse3.shuffle_epi8(Avx.mm256_castsi256_si128(hihi), new v128(12, 13, 14, 15, 12, 13, 14, 15, 14, 15,    2, 3, 2, 3, 2, 3)));

                v256 rest256 = Avx2.mm256_permute2x128_si256(Avx.mm256_castsi128_si256(rest), default(v256), Sse.SHUFFLE(2, 2, 2, 0));


                v256 or = Avx2.mm256_or_si256(Avx2.mm256_or_si256(Avx2.mm256_or_si256(Avx2.mm256_or_si256(Avx2.mm256_or_si256(Avx2.mm256_or_si256(Avx2.mm256_or_si256(cmp01, cmp12), cmp234), cmp23hi), cmp45hi), cmp78), _9_10_11), rest256);


                return 0 == Avx2.mm256_movemask_epi8(or);
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


        /// <summary>       Returns true if all of the components of a ushort3 vector are unique within that vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif (ushort3 c)
        {
            return all_dif ((short3)c);
        }

        /// <summary>       Returns true if all of the components of a ushort4 vector are unique within that vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif (ushort4 c)
        {
            return all_dif ((short4)c);
        }

        /// <summary>       Returns true if all of the components of a ushort8 vector are unique within that vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif (ushort8 c)
        {
            return all_dif ((short8)c);
        }

        /// <summary>       Returns true if all of the components of a ushort16 vector are unique within that vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif (ushort16 c)
        {
            return all_dif ((short16)c);
        }


        /// <summary>       Returns true if all of the components of an int3 vector are unique within that vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif (int3 c)
        {
            return math.all(c.xxz != c.yzy);
        }

        /// <summary>       Returns true if all of the components of an int4 vector are unique within that vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif (int4 c)
        {
            return all_dif (new int8(c.xxxy, c.yzww), new int8(c.yzwz, c.wwzz));
        }

        /// <summary>       Returns true if all of the components of an int8 vector are unique within that vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif (int8 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                //v256 or = Avx2.mm256_or_si256(Avx2.mm256_or_si256(Avx2.mm256_cmpeq_epi32(Avx2.mm256_permutevar8x32_epi32(c, new v256(0, 0, 0, 0, 0, 0, 0, 1)),
                //                                                                         Avx2.mm256_permutevar8x32_epi32(c, new v256(1, 2, 3, 4, 5, 6, 7, 2))),
                //
                //                                                  Avx2.mm256_cmpeq_epi32(Avx2.mm256_permutevar8x32_epi32(c, new v256(1, 1, 1, 1, 1, 2, 2, 2)),
                //                                                                         Avx2.mm256_permutevar8x32_epi32(c, new v256(3, 4, 5, 6, 7, 3, 4, 5)))),
                //
                //                              Avx2.mm256_or_si256(Avx2.mm256_cmpeq_epi32(Avx2.mm256_permutevar8x32_epi32(c, new v256(2, 2, 3, 3, 3, 3, 4, 4)),
                //                                                                         Avx2.mm256_permutevar8x32_epi32(c, new v256(6, 7, 4, 5, 6, 7, 5, 6))),
                //
                //                                                  Avx2.mm256_cmpeq_epi32(Avx2.mm256_permutevar8x32_epi32(c, new v256(4, 5, 5, 6,    0, 0, 0, 0)),
                //                                                                         Avx2.mm256_permutevar8x32_epi32(c, new v256(7, 6, 7, 7,    1, 1, 1, 1)))));

                v256 or = Avx2.mm256_or_si256(Avx2.mm256_or_si256(Avx2.mm256_cmpeq_epi32(Avx2.mm256_permutevar8x32_epi32(c, new v256(1, 0, 3, 0, 0, 0, 0, 0)),
                                                                                         c),
                                                                  Avx2.mm256_cmpeq_epi32(Avx2.mm256_permutevar8x32_epi32(c, new v256(1, 0, 7, 4, 1, 1, 1, 1)),
                                                                                         c)),
                                              Avx2.mm256_or_si256(Avx2.mm256_cmpeq_epi32(Avx2.mm256_permutevar8x32_epi32(c, new v256(2, 2, 5, 6, 5, 6, 7, 4)),
                                                                                         c),
                                                                  Avx2.mm256_cmpeq_epi32(Avx2.mm256_permute4x64_epi64(c, Sse.SHUFFLE(2, 1, 1, 1)),
                                                                                         Avx2.mm256_permute4x64_epi64(c, Sse.SHUFFLE(3, 3, 2, 0)))));

                return 0 == Avx2.mm256_movemask_epi8(or);
            }
            else if (Sse2.IsSse2Supported)
            {
                int4 lo = c.v4_0;
                int4 hi = c.v4_4;


                int4 _0000 = lo.xxxx;
                int4 _1234 = math.shuffle(lo, hi, math.ShuffleComponent.LeftY,
                                                  math.ShuffleComponent.LeftZ, 
                                                  math.ShuffleComponent.LeftW, 
                                                  math.ShuffleComponent.RightX);

                v128 _1st_cmp = Sse2.cmpeq_epi32(*(v128*)&_0000, *(v128*)&_1234);


                int4 _0001 = lo.xxxy;
                int4 _5672 = math.shuffle(lo, hi, math.ShuffleComponent.RightY, 
                                                  math.ShuffleComponent.RightZ, 
                                                  math.ShuffleComponent.RightW, 
                                                  math.ShuffleComponent.LeftZ);

                v128 _2nd_cmp = Sse2.cmpeq_epi32(*(v128*)&_0001, *(v128*)&_5672);


                int4 _1111 = lo.yyyy;
                int4 _3456 = math.shuffle(lo, hi, math.ShuffleComponent.LeftW, 
                                                  math.ShuffleComponent.RightX, 
                                                  math.ShuffleComponent.RightY, 
                                                  math.ShuffleComponent.RightZ);

                v128 _3rd_cmp = Sse2.cmpeq_epi32(*(v128*)&_1111, *(v128*)&_3456);


                int4 _1222 = lo.yzzz;
                int4 _7345 = math.shuffle(lo, hi, math.ShuffleComponent.RightW, 
                                                  math.ShuffleComponent.LeftW, 
                                                  math.ShuffleComponent.RightX, 
                                                  math.ShuffleComponent.RightY);

                v128 _4th_cmp = Sse2.cmpeq_epi32(*(v128*)&_1222, *(v128*)&_7345);


                int4 _2233 = lo.zzww;
                int4 _6745 = hi.zwxy;

                v128 _5th_cmp = Sse2.cmpeq_epi32(*(v128*)&_2233, *(v128*)&_6745);


                int4 _3344 = math.shuffle(lo, hi, math.ShuffleComponent.LeftW, 
                                                  math.ShuffleComponent.LeftW, 
                                                  math.ShuffleComponent.RightX, 
                                                  math.ShuffleComponent.RightX);
                int4 _6756 = hi.zwyz;

                v128 _6th_cmp = Sse2.cmpeq_epi32(*(v128*)&_3344, *(v128*)&_6756);


                int4 _4556 = hi.xyyz;
                int4 _7677 = hi.wzww;

                v128 _7th_cmp = Sse2.cmpeq_epi32(*(v128*)&_4556, *(v128*)&_7677);


                v128 or = Sse2.or_si128(Sse2.or_si128(Sse2.or_si128(_1st_cmp, _2nd_cmp),
                                                      Sse2.or_si128(_3rd_cmp, _4th_cmp)),
                                        Sse2.or_si128(Sse2.or_si128(_5th_cmp, _6th_cmp),
                                                      _7th_cmp));

                return 0 == Sse2.movemask_epi8(or);
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

        /// <summary>       Returns true if all of the components of a uint3 vector are unique within that vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif (uint3 c)
        {
            return math.all(c.xxz != c.yzy);
        }

        /// <summary>       Returns true if all of the components of a uint4 vector are unique within that vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif (uint4 c)
        {
            return all_dif (new uint8(c.xxxy, c.yzww), new uint8(c.yzwz, c.wwzz));
        }

        /// <summary>       Returns true if all of the components of a uint8 vector are unique within that vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif (uint8 c)
        {
            return all_dif ((int8)c);
        }


        /// <summary>       Returns true if all of the components of a long3 vector are unique within that vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif (long3 c)
        {
            return all_dif (c.xxzx, c.yzyy);
        }

        /// <summary>       Returns true if all of the components of a long4 vector are unique within that vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif (long4 c)
        {
            return all_dif (c.xxxy, c.yzwz) & all_dif (c.yzyy, c.wwww);
        }

        /// <summary>       Returns true if all of the components of a ulong3 vector are unique within that vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif (ulong3 c)
        {
            return all_dif (c.xxzx, c.yzyy);
        }

        /// <summary>       Returns true if all of the components of a ulong4 vector are unique within that vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif (ulong4 c)
        {
            return all_dif (c.xxxy, c.yzwz) & all_dif (c.yzyy, c.wwww);
        }
    }
}