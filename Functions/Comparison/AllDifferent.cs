using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(byte2 a, byte2 b)
        {
            return maxmath.cvt_boolean(X86.Sse4_1.test_all_zeros(X86.Sse2.cmpeq_epi8(a, b), new short8(-1, 0, 0, 0, 0, 0, 0, 0)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(byte3 a, byte3 b)
        {
            return maxmath.cvt_boolean(X86.Sse4_1.test_all_zeros(X86.Sse2.cmpeq_epi8(a, b), new byte16(new byte4(255, 255, 255, 0), new byte4(255), new byte8(255))));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(byte4 a, byte4 b)
        {
            return maxmath.cvt_boolean(X86.Sse4_1.test_all_zeros(X86.Sse2.cmpeq_epi8(a, b), new short8(-1, -1, 0, 0, 0, 0, 0, 0)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(byte8 a, byte8 b)
        {
            return maxmath.cvt_boolean(X86.Sse4_1.test_all_zeros(X86.Sse2.cmpeq_epi8(a, b), new long2(-1L, 0)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(byte16 a, byte16 b)
        {
            return maxmath.cvt_boolean(X86.Sse4_1.test_all_zeros(X86.Sse2.cmpeq_epi8(a, b), new byte16(255)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(byte32 a, byte32 b)
        {
            return maxmath.cvt_boolean(X86.Avx.mm256_testz_si256(X86.Avx2.mm256_cmpeq_epi8(a, b), new v256(-1)));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(sbyte2 a, sbyte2 b)
        {
            return all_dif((byte2)a, (byte2)b);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(sbyte3 a, sbyte3 b)
        {
            return all_dif((byte3)a, (byte3)b);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(sbyte4 a, sbyte4 b)
        {
            return all_dif((byte4)a, (byte4)b);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(sbyte8 a, sbyte8 b)
        {
            return all_dif((byte8)a, (byte8)b);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(sbyte16 a, sbyte16 b)
        {
            return all_dif((byte16)a, (byte16)b);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(sbyte32 a, sbyte32 b)
        {
            return all_dif((byte32)a, (byte32)b);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(short2 a, short2 b)
        {
            return maxmath.cvt_boolean(X86.Sse4_1.test_all_zeros(X86.Sse2.cmpeq_epi16(a, b), new short8(-1, -1, 0, 0, 0, 0, 0, 0)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(short3 a, short3 b)
        {
            return maxmath.cvt_boolean(X86.Sse4_1.test_all_zeros(X86.Sse2.cmpeq_epi16(a, b), new short8(-1, -1, -1, 0, 0, 0, 0, 0)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(short4 a, short4 b)
        {
            return maxmath.cvt_boolean(X86.Sse4_1.test_all_zeros(X86.Sse2.cmpeq_epi16(a, b), new long2(-1L, 0L)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(short8 a, short8 b)
        {
            return maxmath.cvt_boolean(X86.Sse4_1.test_all_zeros(X86.Sse2.cmpeq_epi16(a, b), new short8(-1)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(short16 a, short16 b)
        {
            return maxmath.cvt_boolean(X86.Avx.mm256_testz_si256(X86.Avx2.mm256_cmpeq_epi16(a, b), new v256(-1)));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(ushort2 a, ushort2 b)
        {
            return all_dif((short2)a, (short2)b);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(ushort3 a, ushort3 b)
        {
            return all_dif((short3)a, (short3)b);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(ushort4 a, ushort4 b)
        {
            return all_dif((short4)a, (short4)b);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(ushort8 a, ushort8 b)
        {
            return all_dif((short8)a, (short8)b);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(ushort16 a, ushort16 b)
        {
            return all_dif((short16)a, (short16)b);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(int8 a, int8 b)
        {
            return maxmath.cvt_boolean(X86.Avx.mm256_testz_si256(X86.Avx2.mm256_cmpeq_epi32(a, b), new v256(-1)));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(uint8 a, uint8 b)
        {
            return all_dif((int8)a, (int8)b);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(long2 a, long2 b)
        {
            return maxmath.cvt_boolean(X86.Sse4_1.test_all_zeros(X86.Sse4_1.cmpeq_epi64(a, b), new short8(-1)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(long3 a, long3 b)
        {
            return maxmath.cvt_boolean(X86.Avx.mm256_testz_si256(X86.Avx2.mm256_cmpeq_epi64(a, b), new v256(-1L, -1L, -1L, 0L)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(long4 a, long4 b)
        {
            return maxmath.cvt_boolean(X86.Avx.mm256_testz_si256(X86.Avx2.mm256_cmpeq_epi64(a, b), new v256(-1)));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(ulong2 a, ulong2 b)
        {
            return all_dif((long2)a, (long2)b);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(ulong3 a, ulong3 b)
        {
            return all_dif((long3)a, (long3)b);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(ulong4 a, ulong4 b)
        {
            return all_dif((long4)a, (long4)b);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(byte3 c)
        {
            return all_dif(c.xxzx, c.yzyy);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(byte4 c)
        {
            return all_dif((byte16)X86.Ssse3.shuffle_epi8(c, new v128(0, 0, 0, 1, 1, 2,    0, 0, 0, 0, 0, 0, 0, 0, 0, 0)),
                           (byte16)X86.Ssse3.shuffle_epi8(c, new v128(1, 2, 3, 2, 3, 3,    1, 1, 1, 1, 1, 1, 1, 1, 1, 1)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(byte8 c)
        {
            return all_dif(new byte32((byte16)X86.Ssse3.shuffle_epi8(c, new v128(0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 2, 2, 2)),
                                      (byte16)X86.Ssse3.shuffle_epi8(c, new v128(2, 2, 3, 3, 3, 3, 4, 4, 4, 5, 5, 6, 0, 0, 0, 0))),
                           new byte32((byte16)X86.Ssse3.shuffle_epi8(c, new v128(1, 2, 3, 4, 5, 6, 7, 2, 3, 4, 5, 6, 7, 3, 4, 5)),
                                      (byte16)X86.Ssse3.shuffle_epi8(c, new v128(6, 7, 4, 5, 6, 7, 5, 6, 7, 6, 7, 7, 1, 1, 1, 1))));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(byte16 c)
        {
            v256 or = X86.Avx2.mm256_or_si256(X86.Avx2.mm256_cmpeq_epi8(new byte32((byte16)X86.Ssse3.shuffle_epi8(c, new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1)),
                                                                                   (byte16)X86.Ssse3.shuffle_epi8(c, new v128(1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2))),
                                                                        new byte32((byte16)X86.Ssse3.shuffle_epi8(c, new v128(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 2)),
                                                                                   (byte16)X86.Ssse3.shuffle_epi8(c, new v128(3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 3, 4, 5)))),
                      X86.Avx2.mm256_or_si256(X86.Avx2.mm256_cmpeq_epi8(new byte32((byte16)X86.Ssse3.shuffle_epi8(c, new v128(2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3)),
                                                                                   (byte16)X86.Ssse3.shuffle_epi8(c, new v128(3, 3, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4))),
                                                                        new byte32((byte16)X86.Ssse3.shuffle_epi8(c, new v128(6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 4, 5, 6, 7, 8, 9)),
                                                                                   (byte16)X86.Ssse3.shuffle_epi8(c, new v128(10, 11, 12, 13, 14, 15, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14)))),
                      X86.Avx2.mm256_or_si256(X86.Avx2.mm256_cmpeq_epi8(new byte32((byte16)X86.Ssse3.shuffle_epi8(c, new v128(4, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 6, 6, 6, 6, 6)),
                                                                                   (byte16)X86.Ssse3.shuffle_epi8(c, new v128(6, 6, 6, 6, 7, 7, 7, 7, 7, 7, 7, 7, 8, 8, 8, 8))),
                                                                        new byte32((byte16)X86.Ssse3.shuffle_epi8(c, new v128(15, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 7, 8, 9, 10, 11)),
                                                                                   (byte16)X86.Ssse3.shuffle_epi8(c, new v128(12, 13, 14, 15, 8, 9, 10, 11, 12, 13, 14, 15, 9, 10, 11, 12)))),
                                              X86.Avx2.mm256_cmpeq_epi8(new byte32((byte16)X86.Ssse3.shuffle_epi8(c, new v128(8, 8, 8, 9, 9, 9, 9, 9, 9, 10, 10, 10, 10, 10, 11, 11)),
                                                                                   (byte16)X86.Ssse3.shuffle_epi8(c, new v128(11, 11, 12, 12, 12, 13, 13, 14, 0, 0, 0, 0, 0, 0, 0, 0))),
                                                                        new byte32((byte16)X86.Ssse3.shuffle_epi8(c, new v128(13, 14, 15, 10, 11, 12, 13, 14, 15, 11, 12, 13, 14, 15, 12, 13)),
                                                                                   (byte16)X86.Ssse3.shuffle_epi8(c, new v128(14, 15, 13, 14, 15, 14, 15, 15, 1, 1, 1, 1, 1, 1, 1, 1)))))));

            return maxmath.cvt_boolean(X86.Avx.mm256_testz_si256(or, new v256(-1)));
        }

        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool all_dif(byte32 c)
        //{
        //
        //}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(sbyte3 c)
        {
            return all_dif((short3)c);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(sbyte4 c)
        {
            return all_dif((byte4)c);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(sbyte8 c)
        {
            return all_dif((byte8)c);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(sbyte16 c)
        {
            return all_dif((byte16)c);
        }

        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool all_dif(sbyte32 c)
        //{
        //
        //}


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(short3 c)
        {
            return all_dif(c.xxzx, c.yzyy);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(short4 c)
        {
            return all_dif((short8)X86.Ssse3.shuffle_epi8(c, new v128(0, 1,  0, 1,  0, 1,  2, 3,  2, 3,  4, 5,    0, 1, 0, 1)),
                           (short8)X86.Ssse3.shuffle_epi8(c, new v128(2, 3,  4, 5,  6, 7,  4, 5,  6, 7,  6, 7,    2, 3, 2, 3)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(short8 c)
        {
            v256 or = X86.Avx2.mm256_or_si256(X86.Avx2.mm256_cmpeq_epi16(new short16((short8)X86.Ssse3.shuffle_epi8(c, new v128(0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 2, 3)),
                                                                                     (short8)X86.Ssse3.shuffle_epi8(c, new v128(2, 3, 2, 3, 2, 3, 2, 3, 2, 3, 4, 5, 4, 5, 4, 5))),
                                                                         new short16((short8)X86.Ssse3.shuffle_epi8(c, new v128(2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 4, 5)),
                                                                                     (short8)X86.Ssse3.shuffle_epi8(c, new v128(6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 6, 7, 8, 9, 10, 11)))),
                                              X86.Avx2.mm256_cmpeq_epi16(new short16((short8)X86.Ssse3.shuffle_epi8(c, new v128(4, 5, 4, 5, 6, 7, 6, 7, 6, 7, 6, 7, 8, 9, 8, 9)),
                                                                                     (short8)X86.Ssse3.shuffle_epi8(c, new v128(8, 9, 10, 11, 10, 11, 12, 13, 0, 1, 0, 1, 0, 1, 0, 1))),
                                                                         new short16((short8)X86.Ssse3.shuffle_epi8(c, new v128(12, 13, 14, 15, 8, 9, 10, 11, 12, 13, 14, 15, 10, 11, 12, 13)),
                                                                                     (short8)X86.Ssse3.shuffle_epi8(c, new v128(14, 15, 12, 13, 14, 15, 14, 15, 2, 3, 2, 3, 2, 3, 2, 3)))));

            return maxmath.cvt_boolean(X86.Avx.mm256_testz_si256(or, new v256(-1)));

        }

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


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(ushort3 c)
        {
            return all_dif((short3)c);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(ushort4 c)
        {
            return all_dif((short4)c);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(ushort8 c)
        {
            return all_dif((short8)c);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(ushort16 c)
        {
            return all_dif((short16)c);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(int3 c)
        {
            return math.all(c.xxz != c.yzy);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(int4 c)
        {
            return all_dif(new int8(c.xxxy, c.yzww), new int8(c.yzwz, c.wwzz));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(uint3 c)
        {
            return math.all(c.xxz != c.yzy);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(uint4 c)
        {
            return all_dif(new uint8(c.xxxy, c.yzww), new uint8(c.yzwz, c.wwzz));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(long3 c)
        {
            return all_dif(c.xxzx, c.yzyy);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(long4 c)
        {
            return all_dif(c.xxxy, c.yzwz) & all_dif(c.yzyy, c.wwww);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(ulong3 c)
        {
            return all_dif((long3)c);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_dif(ulong4 c)
        {
            return all_dif((long4)c);
        }
    }
}