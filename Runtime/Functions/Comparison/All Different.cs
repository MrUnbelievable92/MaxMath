using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns false if any of the components of a byte2 vector is equal to the corresponding component of the other byte2 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(byte2 a, byte2 b)
        {
            return 0 == (maxmath.bitmask32(2 * sizeof(byte)) & Sse2.movemask_epi8(Sse2.cmpeq_epi8(a, b)));
        }

        /// <summary>       Returns false if any of the components of a byte3 vector is equal to the corresponding component of the other byte3 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(byte3 a, byte3 b)
        {
            return 0 == (maxmath.bitmask32(3 * sizeof(byte)) & Sse2.movemask_epi8(Sse2.cmpeq_epi8(a, b)));
        }

        /// <summary>       Returns false if any of the components of a byte4 vector is equal to the corresponding component of the other byte4 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(byte4 a, byte4 b)
        {
            return 0 == (maxmath.bitmask32(4 * sizeof(byte)) & Sse2.movemask_epi8(Sse2.cmpeq_epi8(a, b)));
        }

        /// <summary>       Returns false if any of the components of a byte8 vector is equal to the corresponding component of the other byte8 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(byte8 a, byte8 b)
        {
            return 0 == (maxmath.bitmask32(8 * sizeof(byte)) & Sse2.movemask_epi8(Sse2.cmpeq_epi8(a, b)));
        }

        /// <summary>       Returns false if any of the components of a byte16 vector is equal to the corresponding component of the other byte16 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(byte16 a, byte16 b)
        {
            return 0 == Sse2.movemask_epi8(Sse2.cmpeq_epi8(a, b));
        }

        /// <summary>       Returns false if any of the components of a byte32 vector is equal to the corresponding component of the other byte32 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(byte32 a, byte32 b)
        {
            return 0 == Avx2.mm256_movemask_epi8(Avx2.mm256_cmpeq_epi8(a, b));
        }


        /// <summary>       Returns false if any of the components of an sbyte2 vector is equal to the corresponding component of the other sbyte2 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(sbyte2 a, sbyte2 b)
        {
            return all_dif((byte2)a, (byte2)b);
        }

        /// <summary>       Returns false if any of the components of an sbyte3 vector is equal to the corresponding component of the other sbyte3 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(sbyte3 a, sbyte3 b)
        {
            return all_dif((byte3)a, (byte3)b);
        }

        /// <summary>       Returns false if any of the components of an sbyte4 vector is equal to the corresponding component of the other sbyte4 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(sbyte4 a, sbyte4 b)
        {
            return all_dif((byte4)a, (byte4)b);
        }

        /// <summary>       Returns false if any of the components of an sbyte8 vector is equal to the corresponding component of the other sbyte8 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(sbyte8 a, sbyte8 b)
        {
            return all_dif((byte8)a, (byte8)b);
        }

        /// <summary>       Returns false if any of the components of an sbyte16 vector is equal to the corresponding component of the other sbyte16 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(sbyte16 a, sbyte16 b)
        {
            return all_dif((byte16)a, (byte16)b);
        }

        /// <summary>       Returns false if any of the components of an sbyte32 vector is equal to the corresponding component of the other sbyte32 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(sbyte32 a, sbyte32 b)
        {
            return all_dif((byte32)a, (byte32)b);
        }


        /// <summary>       Returns false if any of the components of a short2 vector is equal to the corresponding component of the other short2 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(short2 a, short2 b)
        {
            return 0 == (maxmath.bitmask32(2 * sizeof(short)) & Sse2.movemask_epi8(Sse2.cmpeq_epi16(a, b)));
        }

        /// <summary>       Returns false if any of the components of a short3 vector is equal to the corresponding component of the other short3 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(short3 a, short3 b)
        {
            return 0 == (maxmath.bitmask32(3 * sizeof(short)) & Sse2.movemask_epi8(Sse2.cmpeq_epi16(a, b)));
        }

        /// <summary>       Returns false if any of the components of a short4 vector is equal to the corresponding component of the other short4 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(short4 a, short4 b)
        {
            return 0 == (maxmath.bitmask32(4 * sizeof(short)) & Sse2.movemask_epi8(Sse2.cmpeq_epi16(a, b)));
        }

        /// <summary>       Returns false if any of the components of a short8 vector is equal to the corresponding component of the other short8 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(short8 a, short8 b)
        {
            return 0 == Sse2.movemask_epi8(Sse2.cmpeq_epi16(a, b));
        }

        /// <summary>       Returns false if any of the components of a short16 vector is equal to the corresponding component of the other short16 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(short16 a, short16 b)
        {
            return 0 == Avx2.mm256_movemask_epi8(Avx2.mm256_cmpeq_epi16(a, b));
        }


        /// <summary>       Returns false if any of the components of a ushort2 vector is equal to the corresponding component of the other ushort2 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(ushort2 a, ushort2 b)
        {
            return all_dif((short2)a, (short2)b);
        }

        /// <summary>       Returns false if any of the components of a ushort3 vector is equal to the corresponding component of the other ushort3 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(ushort3 a, ushort3 b)
        {
            return all_dif((short3)a, (short3)b);
        }

        /// <summary>       Returns false if any of the components of a ushort4 vector is equal to the corresponding component of the other ushort4 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(ushort4 a, ushort4 b)
        {
            return all_dif((short4)a, (short4)b);
        }

        /// <summary>       Returns false if any of the components of a ushort8 vector is equal to the corresponding component of the other ushort8 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(ushort8 a, ushort8 b)
        {
            return all_dif((short8)a, (short8)b);
        }

        /// <summary>       Returns false if any of the components of a ushort16 vector is equal to the corresponding component of the other ushort16 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(ushort16 a, ushort16 b)
        {
            return all_dif((short16)a, (short16)b);
        }


        /// <summary>       Returns false if any of the components of an int2 vector is equal to the corresponding component of the other int2 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(int2 a, int2 b)
        {
            return math.all(a != b);
        }

        /// <summary>       Returns false if any of the components of an int3 vector is equal to the corresponding component of the other int3 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(int3 a, int3 b)
        {
            return math.all(a != b);
        }

        /// <summary>       Returns false if any of the components of an int4 vector is equal to the corresponding component of the other int4 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(int4 a, int4 b)
        {
            return math.all(a != b);
        }

        /// <summary>       Returns false if any of the components of an int8 vector is equal to the corresponding component of the other int8 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(int8 a, int8 b)
        {
            return 0 == Avx.mm256_movemask_ps(Avx2.mm256_cmpeq_epi32(a, b));
        }


        /// <summary>       Returns false if any of the components of a uint2 vector is equal to the corresponding component of the other uint2 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(uint2 a, uint2 b)
        {
            return math.all(a != b);
        }

        /// <summary>       Returns false if any of the components of a uint3 vector is equal to the corresponding component of the other uint3 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(uint3 a, uint3 b)
        {
            return math.all(a != b);
        }

        /// <summary>       Returns false if any of the components of a uint4 vector is equal to the corresponding component of the other uint4 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(uint4 a, uint4 b)
        {
            return math.all(a != b);
        }

        /// <summary>       Returns false if any of the components of a uint8 vector is equal to the corresponding component of the other uint8 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(uint8 a, uint8 b)
        {
            return all_dif((int8)a, (int8)b);
        }


        /// <summary>       Returns false if any of the components of a long2 vector is equal to the corresponding component of the other long2 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(long2 a, long2 b)
        {
            return 0 == (Sse2.movemask_epi8(Sse4_1.cmpeq_epi64(a, b)));
        }

        /// <summary>       Returns false if any of the components of a long3 vector is equal to the corresponding component of the other long3 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(long3 a, long3 b)
        {
            return 0 == (maxmath.bitmask32(3) & Avx.mm256_movemask_pd(Avx2.mm256_cmpeq_epi64(a, b)));
        }

        /// <summary>       Returns false if any of the components of a long4 vector is equal to the corresponding component of the other long4 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(long4 a, long4 b)
        {
            return 0 == (Avx2.mm256_movemask_epi8(Avx2.mm256_cmpeq_epi64(a, b)));
        }


        /// <summary>       Returns false if any of the components of a ulong2 vector is equal to the corresponding component of the other ulong2 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(ulong2 a, ulong2 b)
        {
            return all_dif((long2)a, (long2)b);
        }

        /// <summary>       Returns false if any of the components of a ulong3 vector is equal to the corresponding component of the other ulong3 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(ulong3 a, ulong3 b)
        {
            return all_dif((long3)a, (long3)b);
        }

        /// <summary>       Returns false if any of the components of a ulong4 vector is equal to the corresponding component of the other ulong4 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(ulong4 a, ulong4 b)
        {
            return all_dif((long4)a, (long4)b);
        }


        /// <summary>       Returns true if all of the components of a byte3 vector are unique within that vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(byte3 c)
        {
            return all_dif(c.xxzx, c.yzyy);
        }

        /// <summary>       Returns true if all of the components of a byte4 vector are unique within that vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(byte4 c)
        {
            return all_dif((byte16)Ssse3.shuffle_epi8(c, new v128(0, 0, 0, 1, 1, 2,    0, 0, 0, 0, 0, 0, 0, 0, 0, 0)),
                           (byte16)Ssse3.shuffle_epi8(c, new v128(1, 2, 3, 2, 3, 3,    1, 1, 1, 1, 1, 1, 1, 1, 1, 1)));
        }

        /// <summary>       Returns true if all of the components of a byte8 vector are unique within that vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(byte8 c)
        {
            return all_dif(new byte32((byte16)Ssse3.shuffle_epi8(c, new v128(0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 2, 2, 2)),
                                      (byte16)Ssse3.shuffle_epi8(c, new v128(2, 2, 3, 3, 3, 3, 4, 4, 4, 5, 5, 6, 0, 0, 0, 0))),
                           new byte32((byte16)Ssse3.shuffle_epi8(c, new v128(1, 2, 3, 4, 5, 6, 7, 2, 3, 4, 5, 6, 7, 3, 4, 5)),
                                      (byte16)Ssse3.shuffle_epi8(c, new v128(6, 7, 4, 5, 6, 7, 5, 6, 7, 6, 7, 7, 1, 1, 1, 1))));
        }

        /// <summary>       Returns true if all of the components of a byte16 vector are unique within that vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(byte16 c)
        {
            v256 or = Avx2.mm256_or_si256(Avx2.mm256_cmpeq_epi8(new byte32((byte16)Ssse3.shuffle_epi8(c, new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1)),
                                                                           (byte16)Ssse3.shuffle_epi8(c, new v128(1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2))),
                                                                new byte32((byte16)Ssse3.shuffle_epi8(c, new v128(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 2)),
                                                                           (byte16)Ssse3.shuffle_epi8(c, new v128(3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 3, 4, 5)))),
                      Avx2.mm256_or_si256(Avx2.mm256_cmpeq_epi8(new byte32((byte16)Ssse3.shuffle_epi8(c, new v128(2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3)),
                                                                           (byte16)Ssse3.shuffle_epi8(c, new v128(3, 3, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4))),
                                                                new byte32((byte16)Ssse3.shuffle_epi8(c, new v128(6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 4, 5, 6, 7, 8, 9)),
                                                                           (byte16)Ssse3.shuffle_epi8(c, new v128(10, 11, 12, 13, 14, 15, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14)))),
                      Avx2.mm256_or_si256(Avx2.mm256_cmpeq_epi8(new byte32((byte16)Ssse3.shuffle_epi8(c, new v128(4, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 6, 6, 6, 6, 6)),
                                                                           (byte16)Ssse3.shuffle_epi8(c, new v128(6, 6, 6, 6, 7, 7, 7, 7, 7, 7, 7, 7, 8, 8, 8, 8))),
                                                                new byte32((byte16)Ssse3.shuffle_epi8(c, new v128(15, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 7, 8, 9, 10, 11)),
                                                                           (byte16)Ssse3.shuffle_epi8(c, new v128(12, 13, 14, 15, 8, 9, 10, 11, 12, 13, 14, 15, 9, 10, 11, 12)))),
                                          Avx2.mm256_cmpeq_epi8(new byte32((byte16)Ssse3.shuffle_epi8(c, new v128(8, 8, 8, 9, 9, 9, 9, 9, 9, 10, 10, 10, 10, 10, 11, 11)),
                                                                           (byte16)Ssse3.shuffle_epi8(c, new v128(11, 11, 12, 12, 12, 13, 13, 14, 0, 0, 0, 0, 0, 0, 0, 0))),
                                                                new byte32((byte16)Ssse3.shuffle_epi8(c, new v128(13, 14, 15, 10, 11, 12, 13, 14, 15, 11, 12, 13, 14, 15, 12, 13)),
                                                                           (byte16)Ssse3.shuffle_epi8(c, new v128(14, 15, 13, 14, 15, 14, 15, 15, 1, 1, 1, 1, 1, 1, 1, 1)))))));
                                          
            return maxmath.tobool(Avx.mm256_testz_si256(or, new v256(-1)));
        }

        ///// <summary>       Returns true if all of the components of a byte32 vector are unique within that vector.      </summary>
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool all_dif(byte32 c)
        //{
        //
        //}


        /// <summary>       Returns true if all of the components of an sbyte3 vector are unique within that vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(sbyte3 c)
        {
            return all_dif((short3)c);
        }

        /// <summary>       Returns true if all of the components of an sbyte4 vector are unique within that vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(sbyte4 c)
        {
            return all_dif((byte4)c);
        }

        /// <summary>       Returns true if all of the components of an sbyte8 vector are unique within that vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(sbyte8 c)
        {
            return all_dif((byte8)c);
        }

        /// <summary>       Returns true if all of the components of an sbyte16 vector are unique within that vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(sbyte16 c)
        {
            return all_dif((byte16)c);
        }

        ///// <summary>       Returns true if all of the components of an sbyte32 vector are unique within that vector.      </summary>
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool all_dif(sbyte32 c)
        //{
        //
        //}


        /// <summary>       Returns true if all of the components of a short3 vector are unique within that vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(short3 c)
        {
            return all_dif(c.xxzx, c.yzyy);
        }

        /// <summary>       Returns true if all of the components of a short4 vector are unique within that vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(short4 c)
        {
            return all_dif((short8)Ssse3.shuffle_epi8(c, new v128(0, 1,  0, 1,  0, 1,  2, 3,  2, 3,  4, 5,    0, 1, 0, 1)),
                           (short8)Ssse3.shuffle_epi8(c, new v128(2, 3,  4, 5,  6, 7,  4, 5,  6, 7,  6, 7,    2, 3, 2, 3)));
        }

        /// <summary>       Returns true if all of the components of a short8 vector are unique within that vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(short8 c)
        {
            v256 or = Avx2.mm256_or_si256(Avx2.mm256_cmpeq_epi16(new short16((short8)Ssse3.shuffle_epi8(c, new v128(0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 2, 3)),
                                                                             (short8)Ssse3.shuffle_epi8(c, new v128(2, 3, 2, 3, 2, 3, 2, 3, 2, 3, 4, 5, 4, 5, 4, 5))),
                                                                 new short16((short8)Ssse3.shuffle_epi8(c, new v128(2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 4, 5)),
                                                                             (short8)Ssse3.shuffle_epi8(c, new v128(6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 6, 7, 8, 9, 10, 11)))),
                                          Avx2.mm256_cmpeq_epi16(new short16((short8)Ssse3.shuffle_epi8(c, new v128(4, 5, 4, 5, 6, 7, 6, 7, 6, 7, 6, 7, 8, 9, 8, 9)),
                                                                             (short8)Ssse3.shuffle_epi8(c, new v128(8, 9, 10, 11, 10, 11, 12, 13, 0, 1, 0, 1, 0, 1, 0, 1))),
                                                                 new short16((short8)Ssse3.shuffle_epi8(c, new v128(12, 13, 14, 15, 8, 9, 10, 11, 12, 13, 14, 15, 10, 11, 12, 13)),
                                                                             (short8)Ssse3.shuffle_epi8(c, new v128(14, 15, 12, 13, 14, 15, 14, 15, 2, 3, 2, 3, 2, 3, 2, 3)))));

            return maxmath.tobool(Avx.mm256_testz_si256(or, new v256(-1)));

        }

        /// <summary>       Returns true if all of the components of a short16 vector are unique within that vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(short16 c)
        {
            return all_dif(c.v8_0) &&
                   all_dif(c.v8_8) &&
                   all_dif(new short8(c.v4_0, c.v4_8)) &&
                   all_dif(new short8(c.v4_0, c.v4_12)) &&
                   all_dif(new short8(c.v4_4, c.v4_8)) &&
                   all_dif(new short8(c.v4_4, c.v4_12));
        }


        /// <summary>       Returns true if all of the components of a ushort3 vector are unique within that vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(ushort3 c)
        {
            return all_dif((short3)c);
        }

        /// <summary>       Returns true if all of the components of a ushort4 vector are unique within that vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(ushort4 c)
        {
            return all_dif((short4)c);
        }

        /// <summary>       Returns true if all of the components of a ushort8 vector are unique within that vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(ushort8 c)
        {
            return all_dif((short8)c);
        }

        /// <summary>       Returns true if all of the components of a ushort16 vector are unique within that vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(ushort16 c)
        {
            return all_dif((short16)c);
        }


        /// <summary>       Returns true if all of the components of a uint4 vector are unique within that vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(int3 c)
        {
            return math.all(c.xxz != c.yzy);
        }

        /// <summary>       Returns true if all of the components of a uint2 vector are unique within that vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(int4 c)
        {
            return all_dif(new int8(c.xxxy, c.yzww), new int8(c.yzwz, c.wwzz));
        }

        /// <summary>       Returns true if all of the components of an int8 vector are unique within that vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(int8 c)
        {
            v256 or = Avx2.mm256_or_si256(Avx2.mm256_or_si256(Avx2.mm256_cmpeq_epi32(Avx2.mm256_permutevar8x32_epi32(c, new v256(0, 0, 0, 0, 0, 0, 0, 1)),
                                                                                     Avx2.mm256_permutevar8x32_epi32(c, new v256(1, 2, 3, 4, 5, 6, 7, 2))),
                                                              Avx2.mm256_cmpeq_epi32(Avx2.mm256_permutevar8x32_epi32(c, new v256(1, 1, 1, 1, 1, 2, 2, 2)),
                                                                                     Avx2.mm256_permutevar8x32_epi32(c, new v256(3, 4, 5, 6, 7, 3, 4, 5)))),
                                          Avx2.mm256_or_si256(Avx2.mm256_cmpeq_epi32(Avx2.mm256_permutevar8x32_epi32(c, new v256(2, 2, 3, 3, 3, 3, 4, 4)),
                                                                                     Avx2.mm256_permutevar8x32_epi32(c, new v256(6, 7, 4, 5, 6, 7, 5, 6))),
                                                              Avx2.mm256_cmpeq_epi32(Avx2.mm256_permutevar8x32_epi32(c, new v256(4, 5, 5, 6, 0, 0, 0, 0)),
                                                                                     Avx2.mm256_permutevar8x32_epi32(c, new v256(7, 6, 7, 7, 1, 1, 1, 1)))));
            return tobool(Avx.mm256_testz_si256(or, new v256(-1)));
        }

        /// <summary>       Returns true if all of the components of a uint3 vector are unique within that vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(uint3 c)
        {
            return math.all(c.xxz != c.yzy);
        }

        /// <summary>       Returns true if all of the components of a uint4 vector are unique within that vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(uint4 c)
        {
            return all_dif(new uint8(c.xxxy, c.yzww), new uint8(c.yzwz, c.wwzz));
        }

        /// <summary>       Returns true if all of the components of a uint8 vector are unique within that vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(uint8 c)
        {
            return all_dif((int8)c);
        }


        /// <summary>       Returns true if all of the components of a long3 vector are unique within that vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(long3 c)
        {
            return all_dif(c.xxzx, c.yzyy);
        }

        /// <summary>       Returns true if all of the components of a long4 vector are unique within that vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(long4 c)
        {
            return all_dif(c.xxxy, c.yzwz) & all_dif(c.yzyy, c.wwww);
        }

        /// <summary>       Returns true if all of the components of a ulong3 vector are unique within that vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(ulong3 c)
        {
            return all_dif(c.xxzx, c.yzyy);
        }

        /// <summary>       Returns true if all of the components of a ulong4 vector are unique within that vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(ulong4 c)
        {
            return all_dif(c.xxxy, c.yzwz) & all_dif(c.yzyy, c.wwww);
        }
    }
}