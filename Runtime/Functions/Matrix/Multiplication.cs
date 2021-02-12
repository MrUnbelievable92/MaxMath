using System.Runtime.CompilerServices;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>		Returns the long value result of a matrix multiplication between a long2 row vector and a long2 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long mul(long2 a, long2 b)
        {
            return dot(a, b);
        }

        /// <summary>		Returns the long2 row vector result of a matrix multiplication between a long2 row vector and a long2x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 mul(long2 a, long2x2 b)
        {
            return new long2(dot(a, b.c0), dot(a, b.c1));
        }

        /// <summary>		Returns the long3 row vector result of a matrix multiplication between a long2 row vector and a long2x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 mul(long2 a, long2x3 b)
        {
            return new long3(dot(a, b.c0), dot(a, b.c1), dot(a, b.c2));
        }

        /// <summary>		Returns the long4 row vector result of a matrix multiplication between a long2 row vector and a long2x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 mul(long2 a, long2x4 b)
        {
            return new long4(dot(a, b.c0), dot(a, b.c1), dot(a, b.c2), dot(a, b.c3));
        }

        /// <summary>		Returns the long value result of a matrix multiplication between a long3 row vector and a long3 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long mul(long3 a, long3 b)
        {
            return dot(a, b);
        }

        /// <summary>		Returns the long2 row vector result of a matrix multiplication between a long3 row vector and a long3x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 mul(long3 a, long3x2 b)
        {
            return new long2(dot(a, b.c0), dot(a, b.c1));
        }

        /// <summary>		Returns the long3 row vector result of a matrix multiplication between a long3 row vector and a long3x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 mul(long3 a, long3x3 b)
        {
            return new long3(dot(a, b.c0), dot(a, b.c1), dot(a, b.c2));
        }

        /// <summary>		Returns the long4 row vector result of a matrix multiplication between a long3 row vector and a long3x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 mul(long3 a, long3x4 b)
        {
            return new long4(dot(a, b.c0), dot(a, b.c1), dot(a, b.c2), dot(a, b.c3));
        }

        /// <summary>		Returns the long value result of a matrix multiplication between a long4 row vector and a long4 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long mul(long4 a, long4 b)
        {
            return dot(a, b);
        }

        /// <summary>		Returns the long2 row vector result of a matrix multiplication between a long4 row vector and a long4x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 mul(long4 a, long4x2 b)
        {
            return new long2(dot(a, b.c0), dot(a, b.c1));
        }

        /// <summary>		Returns the long3 row vector result of a matrix multiplication between a long4 row vector and a long4x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 mul(long4 a, long4x3 b)
        {
            return new long3(dot(a, b.c0), dot(a, b.c1), dot(a, b.c2));
        }

        /// <summary>		Returns the long4 row vector result of a matrix multiplication between a long4 row vector and a long4x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 mul(long4 a, long4x4 b)
        {
            return new long4(dot(a, b.c0), dot(a, b.c1), dot(a, b.c2), dot(a, b.c3));
        }

        /// <summary>		Returns the long2 column vector result of a matrix multiplication between a long2x2 matrix and a long2 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 mul(long2x2 a, long2 b)
        {
            return a.c0 * b.xx + a.c1 * b.yy;
        }

        /// <summary>		Returns the long2x2 matrix result of a matrix multiplication between a long2x2 matrix and a long2x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 mul(long2x2 a, long2x2 b)
        {
            return new long2x2(
                a.c0 * b.c0.xx + a.c1 * b.c0.yy,
                a.c0 * b.c1.xx + a.c1 * b.c1.yy);
        }

        /// <summary>		Returns the long2x3 matrix result of a matrix multiplication between a long2x2 matrix and a long2x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 mul(long2x2 a, long2x3 b)
        {
            return new long2x3(
                a.c0 * b.c0.xx + a.c1 * b.c0.yy,
                a.c0 * b.c1.xx + a.c1 * b.c1.yy,
                a.c0 * b.c2.xx + a.c1 * b.c2.yy);
        }

        /// <summary>		Returns the long2x4 matrix result of a matrix multiplication between a long2x2 matrix and a long2x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 mul(long2x2 a, long2x4 b)
        {
            return new long2x4(
                a.c0 * b.c0.xx + a.c1 * b.c0.yy,
                a.c0 * b.c1.xx + a.c1 * b.c1.yy,
                a.c0 * b.c2.xx + a.c1 * b.c2.yy,
                a.c0 * b.c3.xx + a.c1 * b.c3.yy);
        }

        /// <summary>		Returns the long2 column vector result of a matrix multiplication between a long2x3 matrix and a long3 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 mul(long2x3 a, long3 b)
        {
            return a.c0 * b.xx + a.c1 * b.yy + a.c2 * b.zz;
        }

        /// <summary>		Returns the long2x2 matrix result of a matrix multiplication between a long2x3 matrix and a long3x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 mul(long2x3 a, long3x2 b)
        {
            return new long2x2(
                a.c0 * b.c0.xx + a.c1 * b.c0.yy + a.c2 * b.c0.zz,
                a.c0 * b.c1.xx + a.c1 * b.c1.yy + a.c2 * b.c1.zz);
        }

        /// <summary>		Returns the long2x3 matrix result of a matrix multiplication between a long2x3 matrix and a long3x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 mul(long2x3 a, long3x3 b)
        {
            return new long2x3(
                a.c0 * b.c0.xx + a.c1 * b.c0.yy + a.c2 * b.c0.zz,
                a.c0 * b.c1.xx + a.c1 * b.c1.yy + a.c2 * b.c1.zz,
                a.c0 * b.c2.xx + a.c1 * b.c2.yy + a.c2 * b.c2.zz);
        }

        /// <summary>		Returns the long2x4 matrix result of a matrix multiplication between a long2x3 matrix and a long3x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 mul(long2x3 a, long3x4 b)
        {
            return new long2x4(
                a.c0 * b.c0.xx + a.c1 * b.c0.yy + a.c2 * b.c0.zz,
                a.c0 * b.c1.xx + a.c1 * b.c1.yy + a.c2 * b.c1.zz,
                a.c0 * b.c2.xx + a.c1 * b.c2.yy + a.c2 * b.c2.zz,
                a.c0 * b.c3.xx + a.c1 * b.c3.yy + a.c2 * b.c3.zz);
        }

        /// <summary>		Returns the long2 column vector result of a matrix multiplication between a long2x4 matrix and a long4 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 mul(long2x4 a, long4 b)
        {
            return a.c0 * b.xx + a.c1 * b.yy + a.c2 * b.zz + a.c3 * b.ww;
        }

        /// <summary>		Returns the long2x2 matrix result of a matrix multiplication between a long2x4 matrix and a long4x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 mul(long2x4 a, long4x2 b)
        {
            return new long2x2(
                (a.c0 * b.c0.xx + a.c1 * b.c0.yy) + (a.c2 * b.c0.zz + a.c3 * b.c0.ww),
                (a.c0 * b.c1.xx + a.c1 * b.c1.yy) + (a.c2 * b.c1.zz + a.c3 * b.c1.ww));
        }

        /// <summary>		Returns the long2x3 matrix result of a matrix multiplication between a long2x4 matrix and a long4x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 mul(long2x4 a, long4x3 b)
        {
            return new long2x3(
                (a.c0 * b.c0.xx + a.c1 * b.c0.yy) + (a.c2 * b.c0.zz + a.c3 * b.c0.ww),
                (a.c0 * b.c1.xx + a.c1 * b.c1.yy) + (a.c2 * b.c1.zz + a.c3 * b.c1.ww),
                (a.c0 * b.c2.xx + a.c1 * b.c2.yy) + (a.c2 * b.c2.zz + a.c3 * b.c2.ww));
        }

        /// <summary>		Returns the long2x4 matrix result of a matrix multiplication between a long2x4 matrix and a long4x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 mul(long2x4 a, long4x4 b)
        {
            return new long2x4(
                (a.c0 * b.c0.xx + a.c1 * b.c0.yy) + (a.c2 * b.c0.zz + a.c3 * b.c0.ww),
                (a.c0 * b.c1.xx + a.c1 * b.c1.yy) + (a.c2 * b.c1.zz + a.c3 * b.c1.ww),
                (a.c0 * b.c2.xx + a.c1 * b.c2.yy) + (a.c2 * b.c2.zz + a.c3 * b.c2.ww),
                (a.c0 * b.c3.xx + a.c1 * b.c3.yy) + (a.c2 * b.c3.zz + a.c3 * b.c3.ww));
        }

        /// <summary>		Returns the long3 column vector result of a matrix multiplication between a long3x2 matrix and a long2 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 mul(long3x2 a, long2 b)
        {
            return a.c0 * b.xxx + a.c1 * b.yyy;
        }

        /// <summary>		Returns the long3x2 matrix result of a matrix multiplication between a long3x2 matrix and a long2x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 mul(long3x2 a, long2x2 b)
        {
            return new long3x2(
                a.c0 * b.c0.xxx + a.c1 * b.c0.yyy,
                a.c0 * b.c1.xxx + a.c1 * b.c1.yyy);
        }

        /// <summary>		Returns the long3x3 matrix result of a matrix multiplication between a long3x2 matrix and a long2x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x3 mul(long3x2 a, long2x3 b)
        {
            return new long3x3(
                a.c0 * b.c0.xxx + a.c1 * b.c0.yyy,
                a.c0 * b.c1.xxx + a.c1 * b.c1.yyy,
                a.c0 * b.c2.xxx + a.c1 * b.c2.yyy);
        }

        /// <summary>		Returns the long3x4 matrix result of a matrix multiplication between a long3x2 matrix and a long2x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x4 mul(long3x2 a, long2x4 b)
        {
            return new long3x4(
                a.c0 * b.c0.xxx + a.c1 * b.c0.yyy,
                a.c0 * b.c1.xxx + a.c1 * b.c1.yyy,
                a.c0 * b.c2.xxx + a.c1 * b.c2.yyy,
                a.c0 * b.c3.xxx + a.c1 * b.c3.yyy);
        }

        /// <summary>		Returns the long3 column vector result of a matrix multiplication between a long3x3 matrix and a long3 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 mul(long3x3 a, long3 b)
        {
            return a.c0 * b.xxx + a.c1 * b.yyy + a.c2 * b.zzz;
        }

        /// <summary>		Returns the long3x2 matrix result of a matrix multiplication between a long3x3 matrix and a long3x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 mul(long3x3 a, long3x2 b)
        {
            return new long3x2(
                a.c0 * b.c0.xxx + a.c1 * b.c0.yyy + a.c2 * b.c0.zzz,
                a.c0 * b.c1.xxx + a.c1 * b.c1.yyy + a.c2 * b.c1.zzz);
        }

        /// <summary>		Returns the long3x3 matrix result of a matrix multiplication between a long3x3 matrix and a long3x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x3 mul(long3x3 a, long3x3 b)
        {
            return new long3x3(
                a.c0 * b.c0.xxx + a.c1 * b.c0.yyy + a.c2 * b.c0.zzz,
                a.c0 * b.c1.xxx + a.c1 * b.c1.yyy + a.c2 * b.c1.zzz,
                a.c0 * b.c2.xxx + a.c1 * b.c2.yyy + a.c2 * b.c2.zzz);
        }

        /// <summary>		Returns the long3x4 matrix result of a matrix multiplication between a long3x3 matrix and a long3x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x4 mul(long3x3 a, long3x4 b)
        {
            return new long3x4(
                a.c0 * b.c0.xxx + a.c1 * b.c0.yyy + a.c2 * b.c0.zzz,
                a.c0 * b.c1.xxx + a.c1 * b.c1.yyy + a.c2 * b.c1.zzz,
                a.c0 * b.c2.xxx + a.c1 * b.c2.yyy + a.c2 * b.c2.zzz,
                a.c0 * b.c3.xxx + a.c1 * b.c3.yyy + a.c2 * b.c3.zzz);
        }

        /// <summary>		Returns the long3 column vector result of a matrix multiplication between a long3x4 matrix and a long4 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 mul(long3x4 a, long4 b)
        {
            return a.c0 * b.xxx + a.c1 * b.yyy + a.c2 * b.zzz + a.c3 * b.www;
        }

        /// <summary>		Returns the long3x2 matrix result of a matrix multiplication between a long3x4 matrix and a long4x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 mul(long3x4 a, long4x2 b)
        {
            return new long3x2(
                (a.c0 * b.c0.xxx + a.c1 * b.c0.yyy) + (a.c2 * b.c0.zzz + a.c3 * b.c0.www),
                (a.c0 * b.c1.xxx + a.c1 * b.c1.yyy) + (a.c2 * b.c1.zzz + a.c3 * b.c1.www));
        }

        /// <summary>		Returns the long3x3 matrix result of a matrix multiplication between a long3x4 matrix and a long4x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x3 mul(long3x4 a, long4x3 b)
        {
            return new long3x3(
                (a.c0 * b.c0.xxx + a.c1 * b.c0.yyy) + (a.c2 * b.c0.zzz + a.c3 * b.c0.www),
                (a.c0 * b.c1.xxx + a.c1 * b.c1.yyy) + (a.c2 * b.c1.zzz + a.c3 * b.c1.www),
                (a.c0 * b.c2.xxx + a.c1 * b.c2.yyy) + (a.c2 * b.c2.zzz + a.c3 * b.c2.www));
        }

        /// <summary>		Returns the long3x4 matrix result of a matrix multiplication between a long3x4 matrix and a long4x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x4 mul(long3x4 a, long4x4 b)
        {
            return new long3x4(
                (a.c0 * b.c0.xxx + a.c1 * b.c0.yyy) + (a.c2 * b.c0.zzz + a.c3 * b.c0.www),
                (a.c0 * b.c1.xxx + a.c1 * b.c1.yyy) + (a.c2 * b.c1.zzz + a.c3 * b.c1.www),
                (a.c0 * b.c2.xxx + a.c1 * b.c2.yyy) + (a.c2 * b.c2.zzz + a.c3 * b.c2.www),
                (a.c0 * b.c3.xxx + a.c1 * b.c3.yyy) + (a.c2 * b.c3.zzz + a.c3 * b.c3.www));
        }

        /// <summary>		Returns the long4 column vector result of a matrix multiplication between a long4x2 matrix and a long2 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 mul(long4x2 a, long2 b)
        {
            return a.c0 * b.xxxx + a.c1 * b.yyyy;
        }

        /// <summary>		Returns the long4x2 matrix result of a matrix multiplication between a long4x2 matrix and a long2x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 mul(long4x2 a, long2x2 b)
        {
            return new long4x2(
                a.c0 * b.c0.xxxx + a.c1 * b.c0.yyyy,
                a.c0 * b.c1.xxxx + a.c1 * b.c1.yyyy);
        }

        /// <summary>		Returns the long4x3 matrix result of a matrix multiplication between a long4x2 matrix and a long2x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x3 mul(long4x2 a, long2x3 b)
        {
            return new long4x3(
                a.c0 * b.c0.xxxx + a.c1 * b.c0.yyyy,
                a.c0 * b.c1.xxxx + a.c1 * b.c1.yyyy,
                a.c0 * b.c2.xxxx + a.c1 * b.c2.yyyy);
        }

        /// <summary>		Returns the long4x4 matrix result of a matrix multiplication between a long4x2 matrix and a long2x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x4 mul(long4x2 a, long2x4 b)
        {
            return new long4x4(
                a.c0 * b.c0.xxxx + a.c1 * b.c0.yyyy,
                a.c0 * b.c1.xxxx + a.c1 * b.c1.yyyy,
                a.c0 * b.c2.xxxx + a.c1 * b.c2.yyyy,
                a.c0 * b.c3.xxxx + a.c1 * b.c3.yyyy);
        }

        /// <summary>		Returns the long4 column vector result of a matrix multiplication between a long4x3 matrix and a long3 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 mul(long4x3 a, long3 b)
        {
            return a.c0 * b.xxxx + a.c1 * b.yyyy + a.c2 * b.zzzz;
        }

        /// <summary>		Returns the long4x2 matrix result of a matrix multiplication between a long4x3 matrix and a long3x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 mul(long4x3 a, long3x2 b)
        {
            return new long4x2(
                a.c0 * b.c0.xxxx + a.c1 * b.c0.yyyy + a.c2 * b.c0.zzzz,
                a.c0 * b.c1.xxxx + a.c1 * b.c1.yyyy + a.c2 * b.c1.zzzz);
        }

        /// <summary>		Returns the long4x3 matrix result of a matrix multiplication between a long4x3 matrix and a long3x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x3 mul(long4x3 a, long3x3 b)
        {
            return new long4x3(
                a.c0 * b.c0.xxxx + a.c1 * b.c0.yyyy + a.c2 * b.c0.zzzz,
                a.c0 * b.c1.xxxx + a.c1 * b.c1.yyyy + a.c2 * b.c1.zzzz,
                a.c0 * b.c2.xxxx + a.c1 * b.c2.yyyy + a.c2 * b.c2.zzzz);
        }

        /// <summary>		Returns the long4x4 matrix result of a matrix multiplication between a long4x3 matrix and a long3x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x4 mul(long4x3 a, long3x4 b)
        {
            return new long4x4(
                a.c0 * b.c0.xxxx + a.c1 * b.c0.yyyy + a.c2 * b.c0.zzzz,
                a.c0 * b.c1.xxxx + a.c1 * b.c1.yyyy + a.c2 * b.c1.zzzz,
                a.c0 * b.c2.xxxx + a.c1 * b.c2.yyyy + a.c2 * b.c2.zzzz,
                a.c0 * b.c3.xxxx + a.c1 * b.c3.yyyy + a.c2 * b.c3.zzzz);
        }

        /// <summary>		Returns the long4 column vector result of a matrix multiplication between a long4x4 matrix and a long4 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 mul(long4x4 a, long4 b)
        {
            return a.c0 * b.xxxx + a.c1 * b.yyyy + a.c2 * b.zzzz + a.c3 * b.wwww;
        }

        /// <summary>		Returns the long4x2 matrix result of a matrix multiplication between a long4x4 matrix and a long4x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 mul(long4x4 a, long4x2 b)
        {
            return new long4x2(
                (a.c0 * b.c0.xxxx + a.c1 * b.c0.yyyy) + (a.c2 * b.c0.zzzz + a.c3 * b.c0.wwww),
                (a.c0 * b.c1.xxxx + a.c1 * b.c1.yyyy) + (a.c2 * b.c1.zzzz + a.c3 * b.c1.wwww));
        }

        /// <summary>		Returns the long4x3 matrix result of a matrix multiplication between a long4x4 matrix and a long4x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x3 mul(long4x4 a, long4x3 b)
        {
            return new long4x3(
                (a.c0 * b.c0.xxxx + a.c1 * b.c0.yyyy) + (a.c2 * b.c0.zzzz + a.c3 * b.c0.wwww),
                (a.c0 * b.c1.xxxx + a.c1 * b.c1.yyyy) + (a.c2 * b.c1.zzzz + a.c3 * b.c1.wwww),
                (a.c0 * b.c2.xxxx + a.c1 * b.c2.yyyy) + (a.c2 * b.c2.zzzz + a.c3 * b.c2.wwww));
        }

        /// <summary>		Returns the long4x4 matrix result of a matrix multiplication between a long4x4 matrix and a long4x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x4 mul(long4x4 a, long4x4 b)
        {
            return new long4x4(
                (a.c0 * b.c0.xxxx + a.c1 * b.c0.yyyy) + (a.c2 * b.c0.zzzz + a.c3 * b.c0.wwww),
                (a.c0 * b.c1.xxxx + a.c1 * b.c1.yyyy) + (a.c2 * b.c1.zzzz + a.c3 * b.c1.wwww),
                (a.c0 * b.c2.xxxx + a.c1 * b.c2.yyyy) + (a.c2 * b.c2.zzzz + a.c3 * b.c2.wwww),
                (a.c0 * b.c3.xxxx + a.c1 * b.c3.yyyy) + (a.c2 * b.c3.zzzz + a.c3 * b.c3.wwww));
        }


        /// <summary>		Returns the ulong value result of a matrix multiplication between a ulong2 row vector and a ulong2 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong mul(ulong2 a, ulong2 b)
        {
            return dot(a, b);
        }

        /// <summary>		Returns the ulong2 row vector result of a matrix multiplication between a ulong2 row vector and a ulong2x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 mul(ulong2 a, ulong2x2 b)
        {
            return new ulong2(dot(a, b.c0), dot(a, b.c1));
        }

        /// <summary>		Returns the ulong3 row vector result of a matrix multiplication between a ulong2 row vector and a ulong2x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 mul(ulong2 a, ulong2x3 b)
        {
            return new ulong3(dot(a, b.c0), dot(a, b.c1), dot(a, b.c2));
        }

        /// <summary>		Returns the ulong4 row vector result of a matrix multiplication between a ulong2 row vector and a ulong2x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 mul(ulong2 a, ulong2x4 b)
        {
            return new ulong4(dot(a, b.c0), dot(a, b.c1), dot(a, b.c2), dot(a, b.c3));
        }

        /// <summary>		Returns the ulong value result of a matrix multiplication between a ulong3 row vector and a ulong3 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong mul(ulong3 a, ulong3 b)
        {
            return dot(a, b);
        }

        /// <summary>		Returns the ulong2 row vector result of a matrix multiplication between a ulong3 row vector and a ulong3x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 mul(ulong3 a, ulong3x2 b)
        {
            return new ulong2(dot(a, b.c0), dot(a, b.c1));
        }

        /// <summary>		Returns the ulong3 row vector result of a matrix multiplication between a ulong3 row vector and a ulong3x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 mul(ulong3 a, ulong3x3 b)
        {
            return new ulong3(dot(a, b.c0), dot(a, b.c1), dot(a, b.c2));
        }

        /// <summary>		Returns the ulong4 row vector result of a matrix multiplication between a ulong3 row vector and a ulong3x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 mul(ulong3 a, ulong3x4 b)
        {
            return new ulong4(dot(a, b.c0), dot(a, b.c1), dot(a, b.c2), dot(a, b.c3));
        }

        /// <summary>		Returns the ulong value result of a matrix multiplication between a ulong4 row vector and a ulong4 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong mul(ulong4 a, ulong4 b)
        {
            return dot(a, b);
        }

        /// <summary>		Returns the ulong2 row vector result of a matrix multiplication between a ulong4 row vector and a ulong4x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 mul(ulong4 a, ulong4x2 b)
        {
            return new ulong2(dot(a, b.c0), dot(a, b.c1));
        }

        /// <summary>		Returns the ulong3 row vector result of a matrix multiplication between a ulong4 row vector and a ulong4x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 mul(ulong4 a, ulong4x3 b)
        {
            return new ulong3(dot(a, b.c0), dot(a, b.c1), dot(a, b.c2));
        }

        /// <summary>		Returns the ulong4 row vector result of a matrix multiplication between a ulong4 row vector and a ulong4x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 mul(ulong4 a, ulong4x4 b)
        {
            return new ulong4(dot(a, b.c0), dot(a, b.c1), dot(a, b.c2), dot(a, b.c3));
        }

        /// <summary>		Returns the ulong2 column vector result of a matrix multiplication between a ulong2x2 matrix and a ulong2 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 mul(ulong2x2 a, ulong2 b)
        {
            return a.c0 * b.xx + a.c1 * b.yy;
        }

        /// <summary>		Returns the ulong2x2 matrix result of a matrix multiplication between a ulong2x2 matrix and a ulong2x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x2 mul(ulong2x2 a, ulong2x2 b)
        {
            return new ulong2x2(
                a.c0 * b.c0.xx + a.c1 * b.c0.yy,
                a.c0 * b.c1.xx + a.c1 * b.c1.yy);
        }

        /// <summary>		Returns the ulong2x3 matrix result of a matrix multiplication between a ulong2x2 matrix and a ulong2x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 mul(ulong2x2 a, ulong2x3 b)
        {
            return new ulong2x3(
                a.c0 * b.c0.xx + a.c1 * b.c0.yy,
                a.c0 * b.c1.xx + a.c1 * b.c1.yy,
                a.c0 * b.c2.xx + a.c1 * b.c2.yy);
        }

        /// <summary>		Returns the ulong2x4 matrix result of a matrix multiplication between a ulong2x2 matrix and a ulong2x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x4 mul(ulong2x2 a, ulong2x4 b)
        {
            return new ulong2x4(
                a.c0 * b.c0.xx + a.c1 * b.c0.yy,
                a.c0 * b.c1.xx + a.c1 * b.c1.yy,
                a.c0 * b.c2.xx + a.c1 * b.c2.yy,
                a.c0 * b.c3.xx + a.c1 * b.c3.yy);
        }

        /// <summary>		Returns the ulong2 column vector result of a matrix multiplication between a ulong2x3 matrix and a ulong3 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 mul(ulong2x3 a, ulong3 b)
        {
            return a.c0 * b.xx + a.c1 * b.yy + a.c2 * b.zz;
        }

        /// <summary>		Returns the ulong2x2 matrix result of a matrix multiplication between a ulong2x3 matrix and a ulong3x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x2 mul(ulong2x3 a, ulong3x2 b)
        {
            return new ulong2x2(
                a.c0 * b.c0.xx + a.c1 * b.c0.yy + a.c2 * b.c0.zz,
                a.c0 * b.c1.xx + a.c1 * b.c1.yy + a.c2 * b.c1.zz);
        }

        /// <summary>		Returns the ulong2x3 matrix result of a matrix multiplication between a ulong2x3 matrix and a ulong3x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 mul(ulong2x3 a, ulong3x3 b)
        {
            return new ulong2x3(
                a.c0 * b.c0.xx + a.c1 * b.c0.yy + a.c2 * b.c0.zz,
                a.c0 * b.c1.xx + a.c1 * b.c1.yy + a.c2 * b.c1.zz,
                a.c0 * b.c2.xx + a.c1 * b.c2.yy + a.c2 * b.c2.zz);
        }

        /// <summary>		Returns the ulong2x4 matrix result of a matrix multiplication between a ulong2x3 matrix and a ulong3x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x4 mul(ulong2x3 a, ulong3x4 b)
        {
            return new ulong2x4(
                a.c0 * b.c0.xx + a.c1 * b.c0.yy + a.c2 * b.c0.zz,
                a.c0 * b.c1.xx + a.c1 * b.c1.yy + a.c2 * b.c1.zz,
                a.c0 * b.c2.xx + a.c1 * b.c2.yy + a.c2 * b.c2.zz,
                a.c0 * b.c3.xx + a.c1 * b.c3.yy + a.c2 * b.c3.zz);
        }

        /// <summary>		Returns the ulong2 column vector result of a matrix multiplication between a ulong2x4 matrix and a ulong4 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 mul(ulong2x4 a, ulong4 b)
        {
            return a.c0 * b.xx + a.c1 * b.yy + a.c2 * b.zz + a.c3 * b.ww;
        }

        /// <summary>		Returns the ulong2x2 matrix result of a matrix multiplication between a ulong2x4 matrix and a ulong4x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x2 mul(ulong2x4 a, ulong4x2 b)
        {
            return new ulong2x2(
                (a.c0 * b.c0.xx + a.c1 * b.c0.yy) + (a.c2 * b.c0.zz + a.c3 * b.c0.ww),
                (a.c0 * b.c1.xx + a.c1 * b.c1.yy) + (a.c2 * b.c1.zz + a.c3 * b.c1.ww));
        }

        /// <summary>		Returns the ulong2x3 matrix result of a matrix multiplication between a ulong2x4 matrix and a ulong4x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 mul(ulong2x4 a, ulong4x3 b)
        {
            return new ulong2x3(
                (a.c0 * b.c0.xx + a.c1 * b.c0.yy) + (a.c2 * b.c0.zz + a.c3 * b.c0.ww),
                (a.c0 * b.c1.xx + a.c1 * b.c1.yy) + (a.c2 * b.c1.zz + a.c3 * b.c1.ww),
                (a.c0 * b.c2.xx + a.c1 * b.c2.yy) + (a.c2 * b.c2.zz + a.c3 * b.c2.ww));
        }

        /// <summary>		Returns the ulong2x4 matrix result of a matrix multiplication between a ulong2x4 matrix and a ulong4x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x4 mul(ulong2x4 a, ulong4x4 b)
        {
            return new ulong2x4(
                (a.c0 * b.c0.xx + a.c1 * b.c0.yy) + (a.c2 * b.c0.zz + a.c3 * b.c0.ww),
                (a.c0 * b.c1.xx + a.c1 * b.c1.yy) + (a.c2 * b.c1.zz + a.c3 * b.c1.ww),
                (a.c0 * b.c2.xx + a.c1 * b.c2.yy) + (a.c2 * b.c2.zz + a.c3 * b.c2.ww),
                (a.c0 * b.c3.xx + a.c1 * b.c3.yy) + (a.c2 * b.c3.zz + a.c3 * b.c3.ww));
        }

        /// <summary>		Returns the ulong3 column vector result of a matrix multiplication between a ulong3x2 matrix and a ulong2 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 mul(ulong3x2 a, ulong2 b)
        {
            return a.c0 * b.xxx + a.c1 * b.yyy;
        }

        /// <summary>		Returns the ulong3x2 matrix result of a matrix multiplication between a ulong3x2 matrix and a ulong2x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 mul(ulong3x2 a, ulong2x2 b)
        {
            return new ulong3x2(
                a.c0 * b.c0.xxx + a.c1 * b.c0.yyy,
                a.c0 * b.c1.xxx + a.c1 * b.c1.yyy);
        }

        /// <summary>		Returns the ulong3x3 matrix result of a matrix multiplication between a ulong3x2 matrix and a ulong2x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x3 mul(ulong3x2 a, ulong2x3 b)
        {
            return new ulong3x3(
                a.c0 * b.c0.xxx + a.c1 * b.c0.yyy,
                a.c0 * b.c1.xxx + a.c1 * b.c1.yyy,
                a.c0 * b.c2.xxx + a.c1 * b.c2.yyy);
        }

        /// <summary>		Returns the ulong3x4 matrix result of a matrix multiplication between a ulong3x2 matrix and a ulong2x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 mul(ulong3x2 a, ulong2x4 b)
        {
            return new ulong3x4(
                a.c0 * b.c0.xxx + a.c1 * b.c0.yyy,
                a.c0 * b.c1.xxx + a.c1 * b.c1.yyy,
                a.c0 * b.c2.xxx + a.c1 * b.c2.yyy,
                a.c0 * b.c3.xxx + a.c1 * b.c3.yyy);
        }

        /// <summary>		Returns the ulong3 column vector result of a matrix multiplication between a ulong3x3 matrix and a ulong3 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 mul(ulong3x3 a, ulong3 b)
        {
            return a.c0 * b.xxx + a.c1 * b.yyy + a.c2 * b.zzz;
        }

        /// <summary>		Returns the ulong3x2 matrix result of a matrix multiplication between a ulong3x3 matrix and a ulong3x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 mul(ulong3x3 a, ulong3x2 b)
        {
            return new ulong3x2(
                a.c0 * b.c0.xxx + a.c1 * b.c0.yyy + a.c2 * b.c0.zzz,
                a.c0 * b.c1.xxx + a.c1 * b.c1.yyy + a.c2 * b.c1.zzz);
        }

        /// <summary>		Returns the ulong3x3 matrix result of a matrix multiplication between a ulong3x3 matrix and a ulong3x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x3 mul(ulong3x3 a, ulong3x3 b)
        {
            return new ulong3x3(
                a.c0 * b.c0.xxx + a.c1 * b.c0.yyy + a.c2 * b.c0.zzz,
                a.c0 * b.c1.xxx + a.c1 * b.c1.yyy + a.c2 * b.c1.zzz,
                a.c0 * b.c2.xxx + a.c1 * b.c2.yyy + a.c2 * b.c2.zzz);
        }

        /// <summary>		Returns the ulong3x4 matrix result of a matrix multiplication between a ulong3x3 matrix and a ulong3x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 mul(ulong3x3 a, ulong3x4 b)
        {
            return new ulong3x4(
                a.c0 * b.c0.xxx + a.c1 * b.c0.yyy + a.c2 * b.c0.zzz,
                a.c0 * b.c1.xxx + a.c1 * b.c1.yyy + a.c2 * b.c1.zzz,
                a.c0 * b.c2.xxx + a.c1 * b.c2.yyy + a.c2 * b.c2.zzz,
                a.c0 * b.c3.xxx + a.c1 * b.c3.yyy + a.c2 * b.c3.zzz);
        }

        /// <summary>		Returns the ulong3 column vector result of a matrix multiplication between a ulong3x4 matrix and a ulong4 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 mul(ulong3x4 a, ulong4 b)
        {
            return a.c0 * b.xxx + a.c1 * b.yyy + a.c2 * b.zzz + a.c3 * b.www;
        }

        /// <summary>		Returns the ulong3x2 matrix result of a matrix multiplication between a ulong3x4 matrix and a ulong4x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 mul(ulong3x4 a, ulong4x2 b)
        {
            return new ulong3x2(
                (a.c0 * b.c0.xxx + a.c1 * b.c0.yyy) + (a.c2 * b.c0.zzz + a.c3 * b.c0.www),
                (a.c0 * b.c1.xxx + a.c1 * b.c1.yyy) + (a.c2 * b.c1.zzz + a.c3 * b.c1.www));
        }

        /// <summary>		Returns the ulong3x3 matrix result of a matrix multiplication between a ulong3x4 matrix and a ulong4x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x3 mul(ulong3x4 a, ulong4x3 b)
        {
            return new ulong3x3(
                (a.c0 * b.c0.xxx + a.c1 * b.c0.yyy) + (a.c2 * b.c0.zzz + a.c3 * b.c0.www),
                (a.c0 * b.c1.xxx + a.c1 * b.c1.yyy) + (a.c2 * b.c1.zzz + a.c3 * b.c1.www),
                (a.c0 * b.c2.xxx + a.c1 * b.c2.yyy) + (a.c2 * b.c2.zzz + a.c3 * b.c2.www));
        }

        /// <summary>		Returns the ulong3x4 matrix result of a matrix multiplication between a ulong3x4 matrix and a ulong4x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 mul(ulong3x4 a, ulong4x4 b)
        {
            return new ulong3x4(
                (a.c0 * b.c0.xxx + a.c1 * b.c0.yyy) + (a.c2 * b.c0.zzz + a.c3 * b.c0.www),
                (a.c0 * b.c1.xxx + a.c1 * b.c1.yyy) + (a.c2 * b.c1.zzz + a.c3 * b.c1.www),
                (a.c0 * b.c2.xxx + a.c1 * b.c2.yyy) + (a.c2 * b.c2.zzz + a.c3 * b.c2.www),
                (a.c0 * b.c3.xxx + a.c1 * b.c3.yyy) + (a.c2 * b.c3.zzz + a.c3 * b.c3.www));
        }

        /// <summary>		Returns the ulong4 column vector result of a matrix multiplication between a ulong4x2 matrix and a ulong2 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 mul(ulong4x2 a, ulong2 b)
        {
            return a.c0 * b.xxxx + a.c1 * b.yyyy;
        }

        /// <summary>		Returns the ulong4x2 matrix result of a matrix multiplication between a ulong4x2 matrix and a ulong2x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x2 mul(ulong4x2 a, ulong2x2 b)
        {
            return new ulong4x2(
                a.c0 * b.c0.xxxx + a.c1 * b.c0.yyyy,
                a.c0 * b.c1.xxxx + a.c1 * b.c1.yyyy);
        }

        /// <summary>		Returns the ulong4x3 matrix result of a matrix multiplication between a ulong4x2 matrix and a ulong2x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x3 mul(ulong4x2 a, ulong2x3 b)
        {
            return new ulong4x3(
                a.c0 * b.c0.xxxx + a.c1 * b.c0.yyyy,
                a.c0 * b.c1.xxxx + a.c1 * b.c1.yyyy,
                a.c0 * b.c2.xxxx + a.c1 * b.c2.yyyy);
        }

        /// <summary>		Returns the ulong4x4 matrix result of a matrix multiplication between a ulong4x2 matrix and a ulong2x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 mul(ulong4x2 a, ulong2x4 b)
        {
            return new ulong4x4(
                a.c0 * b.c0.xxxx + a.c1 * b.c0.yyyy,
                a.c0 * b.c1.xxxx + a.c1 * b.c1.yyyy,
                a.c0 * b.c2.xxxx + a.c1 * b.c2.yyyy,
                a.c0 * b.c3.xxxx + a.c1 * b.c3.yyyy);
        }

        /// <summary>		Returns the ulong4 column vector result of a matrix multiplication between a ulong4x3 matrix and a ulong3 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 mul(ulong4x3 a, ulong3 b)
        {
            return a.c0 * b.xxxx + a.c1 * b.yyyy + a.c2 * b.zzzz;
        }

        /// <summary>		Returns the ulong4x2 matrix result of a matrix multiplication between a ulong4x3 matrix and a ulong3x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x2 mul(ulong4x3 a, ulong3x2 b)
        {
            return new ulong4x2(
                a.c0 * b.c0.xxxx + a.c1 * b.c0.yyyy + a.c2 * b.c0.zzzz,
                a.c0 * b.c1.xxxx + a.c1 * b.c1.yyyy + a.c2 * b.c1.zzzz);
        }

        /// <summary>		Returns the ulong4x3 matrix result of a matrix multiplication between a ulong4x3 matrix and a ulong3x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x3 mul(ulong4x3 a, ulong3x3 b)
        {
            return new ulong4x3(
                a.c0 * b.c0.xxxx + a.c1 * b.c0.yyyy + a.c2 * b.c0.zzzz,
                a.c0 * b.c1.xxxx + a.c1 * b.c1.yyyy + a.c2 * b.c1.zzzz,
                a.c0 * b.c2.xxxx + a.c1 * b.c2.yyyy + a.c2 * b.c2.zzzz);
        }

        /// <summary>		Returns the ulong4x4 matrix result of a matrix multiplication between a ulong4x3 matrix and a ulong3x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 mul(ulong4x3 a, ulong3x4 b)
        {
            return new ulong4x4(
                a.c0 * b.c0.xxxx + a.c1 * b.c0.yyyy + a.c2 * b.c0.zzzz,
                a.c0 * b.c1.xxxx + a.c1 * b.c1.yyyy + a.c2 * b.c1.zzzz,
                a.c0 * b.c2.xxxx + a.c1 * b.c2.yyyy + a.c2 * b.c2.zzzz,
                a.c0 * b.c3.xxxx + a.c1 * b.c3.yyyy + a.c2 * b.c3.zzzz);
        }

        /// <summary>		Returns the ulong4 column vector result of a matrix multiplication between a ulong4x4 matrix and a ulong4 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 mul(ulong4x4 a, ulong4 b)
        {
            return a.c0 * b.xxxx + a.c1 * b.yyyy + a.c2 * b.zzzz + a.c3 * b.wwww;
        }

        /// <summary>		Returns the ulong4x2 matrix result of a matrix multiplication between a ulong4x4 matrix and a ulong4x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x2 mul(ulong4x4 a, ulong4x2 b)
        {
            return new ulong4x2(
                (a.c0 * b.c0.xxxx + a.c1 * b.c0.yyyy) + (a.c2 * b.c0.zzzz + a.c3 * b.c0.wwww),
                (a.c0 * b.c1.xxxx + a.c1 * b.c1.yyyy) + (a.c2 * b.c1.zzzz + a.c3 * b.c1.wwww));
        }

        /// <summary>		Returns the ulong4x3 matrix result of a matrix multiplication between a ulong4x4 matrix and a ulong4x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x3 mul(ulong4x4 a, ulong4x3 b)
        {
            return new ulong4x3(
                (a.c0 * b.c0.xxxx + a.c1 * b.c0.yyyy) + (a.c2 * b.c0.zzzz + a.c3 * b.c0.wwww),
                (a.c0 * b.c1.xxxx + a.c1 * b.c1.yyyy) + (a.c2 * b.c1.zzzz + a.c3 * b.c1.wwww),
                (a.c0 * b.c2.xxxx + a.c1 * b.c2.yyyy) + (a.c2 * b.c2.zzzz + a.c3 * b.c2.wwww));
        }

        /// <summary>		Returns the ulong4x4 matrix result of a matrix multiplication between a ulong4x4 matrix and a ulong4x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 mul(ulong4x4 a, ulong4x4 b)
        {
            return new ulong4x4(
                (a.c0 * b.c0.xxxx + a.c1 * b.c0.yyyy) + (a.c2 * b.c0.zzzz + a.c3 * b.c0.wwww),
                (a.c0 * b.c1.xxxx + a.c1 * b.c1.yyyy) + (a.c2 * b.c1.zzzz + a.c3 * b.c1.wwww),
                (a.c0 * b.c2.xxxx + a.c1 * b.c2.yyyy) + (a.c2 * b.c2.zzzz + a.c3 * b.c2.wwww),
                (a.c0 * b.c3.xxxx + a.c1 * b.c3.yyyy) + (a.c2 * b.c3.zzzz + a.c3 * b.c3.wwww));
        }


        /// <summary>		Returns the short value result of a matrix multiplication between a short2 row vector and a short2 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int mul(short2 a, short2 b)
        {
            return dot(a, b);
        }

        /// <summary>		Returns the short2 row vector result of a matrix multiplication between a short2 row vector and a short2x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 mul(short2 a, short2x2 b)
        {
            return new short2((short)dot(a, b.c0), (short)dot(a, b.c1));
        }

        /// <summary>		Returns the short3 row vector result of a matrix multiplication between a short2 row vector and a short2x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 mul(short2 a, short2x3 b)
        {
            return new short3((short)dot(a, b.c0), (short)dot(a, b.c1), (short)dot(a, b.c2));
        }

        /// <summary>		Returns the short4 row vector result of a matrix multiplication between a short2 row vector and a short2x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 mul(short2 a, short2x4 b)
        {
            return new short4((short)dot(a, b.c0), (short)dot(a, b.c1), (short)dot(a, b.c2), (short)dot(a, b.c3));
        }

        /// <summary>		Returns the short value result of a matrix multiplication between a short3 row vector and a short3 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int mul(short3 a, short3 b)
        {
            return dot(a, b);
        }

        /// <summary>		Returns the short2 row vector result of a matrix multiplication between a short3 row vector and a short3x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 mul(short3 a, short3x2 b)
        {
            return new short2((short)dot(a, b.c0), (short)dot(a, b.c1));
        }

        /// <summary>		Returns the short3 row vector result of a matrix multiplication between a short3 row vector and a short3x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 mul(short3 a, short3x3 b)
        {
            return new short3((short)dot(a, b.c0), (short)dot(a, b.c1), (short)dot(a, b.c2));
        }

        /// <summary>		Returns the short4 row vector result of a matrix multiplication between a short3 row vector and a short3x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 mul(short3 a, short3x4 b)
        {
            return new short4((short)dot(a, b.c0), (short)dot(a, b.c1), (short)dot(a, b.c2), (short)dot(a, b.c3));
        }

        /// <summary>		Returns the short value result of a matrix multiplication between a short4 row vector and a short4 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int mul(short4 a, short4 b)
        {
            return dot(a, b);
        }

        /// <summary>		Returns the short2 row vector result of a matrix multiplication between a short4 row vector and a short4x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 mul(short4 a, short4x2 b)
        {
            return new short2((short)dot(a, b.c0), (short)dot(a, b.c1));
        }

        /// <summary>		Returns the short3 row vector result of a matrix multiplication between a short4 row vector and a short4x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 mul(short4 a, short4x3 b)
        {
            return new short3((short)dot(a, b.c0), (short)dot(a, b.c1), (short)dot(a, b.c2));
        }

        /// <summary>		Returns the short4 row vector result of a matrix multiplication between a short4 row vector and a short4x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 mul(short4 a, short4x4 b)
        {
            return new short4((short)dot(a, b.c0), (short)dot(a, b.c1), (short)dot(a, b.c2), (short)dot(a, b.c3));
        }

        /// <summary>		Returns the short2 column vector result of a matrix multiplication between a short2x2 matrix and a short2 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 mul(short2x2 a, short2 b)
        {
            return a.c0 * b.xx + a.c1 * b.yy;
        }

        /// <summary>		Returns the short2x2 matrix result of a matrix multiplication between a short2x2 matrix and a short2x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 mul(short2x2 a, short2x2 b)
        {
            return new short2x2(
                a.c0 * b.c0.xx + a.c1 * b.c0.yy,
                a.c0 * b.c1.xx + a.c1 * b.c1.yy);
        }

        /// <summary>		Returns the short2x3 matrix result of a matrix multiplication between a short2x2 matrix and a short2x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 mul(short2x2 a, short2x3 b)
        {
            return new short2x3(
                a.c0 * b.c0.xx + a.c1 * b.c0.yy,
                a.c0 * b.c1.xx + a.c1 * b.c1.yy,
                a.c0 * b.c2.xx + a.c1 * b.c2.yy);
        }

        /// <summary>		Returns the short2x4 matrix result of a matrix multiplication between a short2x2 matrix and a short2x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x4 mul(short2x2 a, short2x4 b)
        {
            return new short2x4(
                a.c0 * b.c0.xx + a.c1 * b.c0.yy,
                a.c0 * b.c1.xx + a.c1 * b.c1.yy,
                a.c0 * b.c2.xx + a.c1 * b.c2.yy,
                a.c0 * b.c3.xx + a.c1 * b.c3.yy);
        }

        /// <summary>		Returns the short2 column vector result of a matrix multiplication between a short2x3 matrix and a short3 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 mul(short2x3 a, short3 b)
        {
            return a.c0 * b.xx + a.c1 * b.yy + a.c2 * b.zz;
        }

        /// <summary>		Returns the short2x2 matrix result of a matrix multiplication between a short2x3 matrix and a short3x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 mul(short2x3 a, short3x2 b)
        {
            return new short2x2(
                a.c0 * b.c0.xx + a.c1 * b.c0.yy + a.c2 * b.c0.zz,
                a.c0 * b.c1.xx + a.c1 * b.c1.yy + a.c2 * b.c1.zz);
        }

        /// <summary>		Returns the short2x3 matrix result of a matrix multiplication between a short2x3 matrix and a short3x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 mul(short2x3 a, short3x3 b)
        {
            return new short2x3(
                a.c0 * b.c0.xx + a.c1 * b.c0.yy + a.c2 * b.c0.zz,
                a.c0 * b.c1.xx + a.c1 * b.c1.yy + a.c2 * b.c1.zz,
                a.c0 * b.c2.xx + a.c1 * b.c2.yy + a.c2 * b.c2.zz);
        }

        /// <summary>		Returns the short2x4 matrix result of a matrix multiplication between a short2x3 matrix and a short3x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x4 mul(short2x3 a, short3x4 b)
        {
            return new short2x4(
                a.c0 * b.c0.xx + a.c1 * b.c0.yy + a.c2 * b.c0.zz,
                a.c0 * b.c1.xx + a.c1 * b.c1.yy + a.c2 * b.c1.zz,
                a.c0 * b.c2.xx + a.c1 * b.c2.yy + a.c2 * b.c2.zz,
                a.c0 * b.c3.xx + a.c1 * b.c3.yy + a.c2 * b.c3.zz);
        }

        /// <summary>		Returns the short2 column vector result of a matrix multiplication between a short2x4 matrix and a short4 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 mul(short2x4 a, short4 b)
        {
            return a.c0 * b.xx + a.c1 * b.yy + a.c2 * b.zz + a.c3 * b.ww;
        }

        /// <summary>		Returns the short2x2 matrix result of a matrix multiplication between a short2x4 matrix and a short4x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 mul(short2x4 a, short4x2 b)
        {
            return new short2x2(
                (a.c0 * b.c0.xx + a.c1 * b.c0.yy) + (a.c2 * b.c0.zz + a.c3 * b.c0.ww),
                (a.c0 * b.c1.xx + a.c1 * b.c1.yy) + (a.c2 * b.c1.zz + a.c3 * b.c1.ww));
        }

        /// <summary>		Returns the short2x3 matrix result of a matrix multiplication between a short2x4 matrix and a short4x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 mul(short2x4 a, short4x3 b)
        {
            return new short2x3(
                (a.c0 * b.c0.xx + a.c1 * b.c0.yy) + (a.c2 * b.c0.zz + a.c3 * b.c0.ww),
                (a.c0 * b.c1.xx + a.c1 * b.c1.yy) + (a.c2 * b.c1.zz + a.c3 * b.c1.ww),
                (a.c0 * b.c2.xx + a.c1 * b.c2.yy) + (a.c2 * b.c2.zz + a.c3 * b.c2.ww));
        }

        /// <summary>		Returns the short2x4 matrix result of a matrix multiplication between a short2x4 matrix and a short4x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x4 mul(short2x4 a, short4x4 b)
        {
            return new short2x4(
                (a.c0 * b.c0.xx + a.c1 * b.c0.yy) + (a.c2 * b.c0.zz + a.c3 * b.c0.ww),
                (a.c0 * b.c1.xx + a.c1 * b.c1.yy) + (a.c2 * b.c1.zz + a.c3 * b.c1.ww),
                (a.c0 * b.c2.xx + a.c1 * b.c2.yy) + (a.c2 * b.c2.zz + a.c3 * b.c2.ww),
                (a.c0 * b.c3.xx + a.c1 * b.c3.yy) + (a.c2 * b.c3.zz + a.c3 * b.c3.ww));
        }

        /// <summary>		Returns the short3 column vector result of a matrix multiplication between a short3x2 matrix and a short2 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 mul(short3x2 a, short2 b)
        {
            return a.c0 * b.xxx + a.c1 * b.yyy;
        }

        /// <summary>		Returns the short3x2 matrix result of a matrix multiplication between a short3x2 matrix and a short2x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3x2 mul(short3x2 a, short2x2 b)
        {
            return new short3x2(
                a.c0 * b.c0.xxx + a.c1 * b.c0.yyy,
                a.c0 * b.c1.xxx + a.c1 * b.c1.yyy);
        }

        /// <summary>		Returns the short3x3 matrix result of a matrix multiplication between a short3x2 matrix and a short2x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3x3 mul(short3x2 a, short2x3 b)
        {
            return new short3x3(
                a.c0 * b.c0.xxx + a.c1 * b.c0.yyy,
                a.c0 * b.c1.xxx + a.c1 * b.c1.yyy,
                a.c0 * b.c2.xxx + a.c1 * b.c2.yyy);
        }

        /// <summary>		Returns the short3x4 matrix result of a matrix multiplication between a short3x2 matrix and a short2x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3x4 mul(short3x2 a, short2x4 b)
        {
            return new short3x4(
                a.c0 * b.c0.xxx + a.c1 * b.c0.yyy,
                a.c0 * b.c1.xxx + a.c1 * b.c1.yyy,
                a.c0 * b.c2.xxx + a.c1 * b.c2.yyy,
                a.c0 * b.c3.xxx + a.c1 * b.c3.yyy);
        }

        /// <summary>		Returns the short3 column vector result of a matrix multiplication between a short3x3 matrix and a short3 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 mul(short3x3 a, short3 b)
        {
            return a.c0 * b.xxx + a.c1 * b.yyy + a.c2 * b.zzz;
        }

        /// <summary>		Returns the short3x2 matrix result of a matrix multiplication between a short3x3 matrix and a short3x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3x2 mul(short3x3 a, short3x2 b)
        {
            return new short3x2(
                a.c0 * b.c0.xxx + a.c1 * b.c0.yyy + a.c2 * b.c0.zzz,
                a.c0 * b.c1.xxx + a.c1 * b.c1.yyy + a.c2 * b.c1.zzz);
        }

        /// <summary>		Returns the short3x3 matrix result of a matrix multiplication between a short3x3 matrix and a short3x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3x3 mul(short3x3 a, short3x3 b)
        {
            return new short3x3(
                a.c0 * b.c0.xxx + a.c1 * b.c0.yyy + a.c2 * b.c0.zzz,
                a.c0 * b.c1.xxx + a.c1 * b.c1.yyy + a.c2 * b.c1.zzz,
                a.c0 * b.c2.xxx + a.c1 * b.c2.yyy + a.c2 * b.c2.zzz);
        }

        /// <summary>		Returns the short3x4 matrix result of a matrix multiplication between a short3x3 matrix and a short3x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3x4 mul(short3x3 a, short3x4 b)
        {
            return new short3x4(
                a.c0 * b.c0.xxx + a.c1 * b.c0.yyy + a.c2 * b.c0.zzz,
                a.c0 * b.c1.xxx + a.c1 * b.c1.yyy + a.c2 * b.c1.zzz,
                a.c0 * b.c2.xxx + a.c1 * b.c2.yyy + a.c2 * b.c2.zzz,
                a.c0 * b.c3.xxx + a.c1 * b.c3.yyy + a.c2 * b.c3.zzz);
        }

        /// <summary>		Returns the short3 column vector result of a matrix multiplication between a short3x4 matrix and a short4 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 mul(short3x4 a, short4 b)
        {
            return a.c0 * b.xxx + a.c1 * b.yyy + a.c2 * b.zzz + a.c3 * b.www;
        }

        /// <summary>		Returns the short3x2 matrix result of a matrix multiplication between a short3x4 matrix and a short4x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3x2 mul(short3x4 a, short4x2 b)
        {
            return new short3x2(
                (a.c0 * b.c0.xxx + a.c1 * b.c0.yyy) + (a.c2 * b.c0.zzz + a.c3 * b.c0.www),
                (a.c0 * b.c1.xxx + a.c1 * b.c1.yyy) + (a.c2 * b.c1.zzz + a.c3 * b.c1.www));
        }

        /// <summary>		Returns the short3x3 matrix result of a matrix multiplication between a short3x4 matrix and a short4x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3x3 mul(short3x4 a, short4x3 b)
        {
            return new short3x3(
                (a.c0 * b.c0.xxx + a.c1 * b.c0.yyy) + (a.c2 * b.c0.zzz + a.c3 * b.c0.www),
                (a.c0 * b.c1.xxx + a.c1 * b.c1.yyy) + (a.c2 * b.c1.zzz + a.c3 * b.c1.www),
                (a.c0 * b.c2.xxx + a.c1 * b.c2.yyy) + (a.c2 * b.c2.zzz + a.c3 * b.c2.www));
        }

        /// <summary>		Returns the short3x4 matrix result of a matrix multiplication between a short3x4 matrix and a short4x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3x4 mul(short3x4 a, short4x4 b)
        {
            return new short3x4(
                (a.c0 * b.c0.xxx + a.c1 * b.c0.yyy) + (a.c2 * b.c0.zzz + a.c3 * b.c0.www),
                (a.c0 * b.c1.xxx + a.c1 * b.c1.yyy) + (a.c2 * b.c1.zzz + a.c3 * b.c1.www),
                (a.c0 * b.c2.xxx + a.c1 * b.c2.yyy) + (a.c2 * b.c2.zzz + a.c3 * b.c2.www),
                (a.c0 * b.c3.xxx + a.c1 * b.c3.yyy) + (a.c2 * b.c3.zzz + a.c3 * b.c3.www));
        }

        /// <summary>		Returns the short4 column vector result of a matrix multiplication between a short4x2 matrix and a short2 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 mul(short4x2 a, short2 b)
        {
            return a.c0 * b.xxxx + a.c1 * b.yyyy;
        }

        /// <summary>		Returns the short4x2 matrix result of a matrix multiplication between a short4x2 matrix and a short2x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4x2 mul(short4x2 a, short2x2 b)
        {
            return new short4x2(
                a.c0 * b.c0.xxxx + a.c1 * b.c0.yyyy,
                a.c0 * b.c1.xxxx + a.c1 * b.c1.yyyy);
        }

        /// <summary>		Returns the short4x3 matrix result of a matrix multiplication between a short4x2 matrix and a short2x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4x3 mul(short4x2 a, short2x3 b)
        {
            return new short4x3(
                a.c0 * b.c0.xxxx + a.c1 * b.c0.yyyy,
                a.c0 * b.c1.xxxx + a.c1 * b.c1.yyyy,
                a.c0 * b.c2.xxxx + a.c1 * b.c2.yyyy);
        }

        /// <summary>		Returns the short4x4 matrix result of a matrix multiplication between a short4x2 matrix and a short2x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4x4 mul(short4x2 a, short2x4 b)
        {
            return new short4x4(
                a.c0 * b.c0.xxxx + a.c1 * b.c0.yyyy,
                a.c0 * b.c1.xxxx + a.c1 * b.c1.yyyy,
                a.c0 * b.c2.xxxx + a.c1 * b.c2.yyyy,
                a.c0 * b.c3.xxxx + a.c1 * b.c3.yyyy);
        }

        /// <summary>		Returns the short4 column vector result of a matrix multiplication between a short4x3 matrix and a short3 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 mul(short4x3 a, short3 b)
        {
            return a.c0 * b.xxxx + a.c1 * b.yyyy + a.c2 * b.zzzz;
        }

        /// <summary>		Returns the short4x2 matrix result of a matrix multiplication between a short4x3 matrix and a short3x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4x2 mul(short4x3 a, short3x2 b)
        {
            return new short4x2(
                a.c0 * b.c0.xxxx + a.c1 * b.c0.yyyy + a.c2 * b.c0.zzzz,
                a.c0 * b.c1.xxxx + a.c1 * b.c1.yyyy + a.c2 * b.c1.zzzz);
        }

        /// <summary>		Returns the short4x3 matrix result of a matrix multiplication between a short4x3 matrix and a short3x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4x3 mul(short4x3 a, short3x3 b)
        {
            return new short4x3(
                a.c0 * b.c0.xxxx + a.c1 * b.c0.yyyy + a.c2 * b.c0.zzzz,
                a.c0 * b.c1.xxxx + a.c1 * b.c1.yyyy + a.c2 * b.c1.zzzz,
                a.c0 * b.c2.xxxx + a.c1 * b.c2.yyyy + a.c2 * b.c2.zzzz);
        }

        /// <summary>		Returns the short4x4 matrix result of a matrix multiplication between a short4x3 matrix and a short3x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4x4 mul(short4x3 a, short3x4 b)
        {
            return new short4x4(
                a.c0 * b.c0.xxxx + a.c1 * b.c0.yyyy + a.c2 * b.c0.zzzz,
                a.c0 * b.c1.xxxx + a.c1 * b.c1.yyyy + a.c2 * b.c1.zzzz,
                a.c0 * b.c2.xxxx + a.c1 * b.c2.yyyy + a.c2 * b.c2.zzzz,
                a.c0 * b.c3.xxxx + a.c1 * b.c3.yyyy + a.c2 * b.c3.zzzz);
        }

        /// <summary>		Returns the short4 column vector result of a matrix multiplication between a short4x4 matrix and a short4 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 mul(short4x4 a, short4 b)
        {
            return a.c0 * b.xxxx + a.c1 * b.yyyy + a.c2 * b.zzzz + a.c3 * b.wwww;
        }

        /// <summary>		Returns the short4x2 matrix result of a matrix multiplication between a short4x4 matrix and a short4x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4x2 mul(short4x4 a, short4x2 b)
        {
            return new short4x2(
                (a.c0 * b.c0.xxxx + a.c1 * b.c0.yyyy) + (a.c2 * b.c0.zzzz + a.c3 * b.c0.wwww),
                (a.c0 * b.c1.xxxx + a.c1 * b.c1.yyyy) + (a.c2 * b.c1.zzzz + a.c3 * b.c1.wwww));
        }

        /// <summary>		Returns the short4x3 matrix result of a matrix multiplication between a short4x4 matrix and a short4x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4x3 mul(short4x4 a, short4x3 b)
        {
            return new short4x3(
                (a.c0 * b.c0.xxxx + a.c1 * b.c0.yyyy) + (a.c2 * b.c0.zzzz + a.c3 * b.c0.wwww),
                (a.c0 * b.c1.xxxx + a.c1 * b.c1.yyyy) + (a.c2 * b.c1.zzzz + a.c3 * b.c1.wwww),
                (a.c0 * b.c2.xxxx + a.c1 * b.c2.yyyy) + (a.c2 * b.c2.zzzz + a.c3 * b.c2.wwww));
        }

        /// <summary>		Returns the short4x4 matrix result of a matrix multiplication between a short4x4 matrix and a short4x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4x4 mul(short4x4 a, short4x4 b)
        {
            return new short4x4(
                (a.c0 * b.c0.xxxx + a.c1 * b.c0.yyyy) + (a.c2 * b.c0.zzzz + a.c3 * b.c0.wwww),
                (a.c0 * b.c1.xxxx + a.c1 * b.c1.yyyy) + (a.c2 * b.c1.zzzz + a.c3 * b.c1.wwww),
                (a.c0 * b.c2.xxxx + a.c1 * b.c2.yyyy) + (a.c2 * b.c2.zzzz + a.c3 * b.c2.wwww),
                (a.c0 * b.c3.xxxx + a.c1 * b.c3.yyyy) + (a.c2 * b.c3.zzzz + a.c3 * b.c3.wwww));
        }


        /// <summary>		Returns the ushort value result of a matrix multiplication between a ushort2 row vector and a ushort2 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint mul(ushort2 a, ushort2 b)
        {
            return dot(a, b);
        }

        /// <summary>		Returns the ushort2 row vector result of a matrix multiplication between a ushort2 row vector and a ushort2x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 mul(ushort2 a, ushort2x2 b)
        {
            return new ushort2((ushort)dot(a, b.c0), (ushort)dot(a, b.c1));
        }

        /// <summary>		Returns the ushort3 row vector result of a matrix multiplication between a ushort2 row vector and a ushort2x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 mul(ushort2 a, ushort2x3 b)
        {
            return new ushort3((ushort)dot(a, b.c0), (ushort)dot(a, b.c1), (ushort)dot(a, b.c2));
        }

        /// <summary>		Returns the ushort4 row vector result of a matrix multiplication between a ushort2 row vector and a ushort2x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 mul(ushort2 a, ushort2x4 b)
        {
            return new ushort4((ushort)dot(a, b.c0), (ushort)dot(a, b.c1), (ushort)dot(a, b.c2), (ushort)dot(a, b.c3));
        }

        /// <summary>		Returns the ushort value result of a matrix multiplication between a ushort3 row vector and a ushort3 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint mul(ushort3 a, ushort3 b)
        {
            return dot(a, b);
        }

        /// <summary>		Returns the ushort2 row vector result of a matrix multiplication between a ushort3 row vector and a ushort3x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 mul(ushort3 a, ushort3x2 b)
        {
            return new ushort2((ushort)dot(a, b.c0), (ushort)dot(a, b.c1));
        }

        /// <summary>		Returns the ushort3 row vector result of a matrix multiplication between a ushort3 row vector and a ushort3x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 mul(ushort3 a, ushort3x3 b)
        {
            return new ushort3((ushort)dot(a, b.c0), (ushort)dot(a, b.c1), (ushort)dot(a, b.c2));
        }

        /// <summary>		Returns the ushort4 row vector result of a matrix multiplication between a ushort3 row vector and a ushort3x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 mul(ushort3 a, ushort3x4 b)
        {
            return new ushort4((ushort)dot(a, b.c0), (ushort)dot(a, b.c1), (ushort)dot(a, b.c2), (ushort)dot(a, b.c3));
        }

        /// <summary>		Returns the ushort value result of a matrix multiplication between a ushort4 row vector and a ushort4 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint mul(ushort4 a, ushort4 b)
        {
            return dot(a, b);
        }

        /// <summary>		Returns the ushort2 row vector result of a matrix multiplication between a ushort4 row vector and a ushort4x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 mul(ushort4 a, ushort4x2 b)
        {
            return new ushort2((ushort)dot(a, b.c0), (ushort)dot(a, b.c1));
        }

        /// <summary>		Returns the ushort3 row vector result of a matrix multiplication between a ushort4 row vector and a ushort4x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 mul(ushort4 a, ushort4x3 b)
        {
            return new ushort3((ushort)dot(a, b.c0), (ushort)dot(a, b.c1), (ushort)dot(a, b.c2));
        }

        /// <summary>		Returns the ushort4 row vector result of a matrix multiplication between a ushort4 row vector and a ushort4x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 mul(ushort4 a, ushort4x4 b)
        {
            return new ushort4((ushort)dot(a, b.c0), (ushort)dot(a, b.c1), (ushort)dot(a, b.c2), (ushort)dot(a, b.c3));
        }

        /// <summary>		Returns the ushort2 column vector result of a matrix multiplication between a ushort2x2 matrix and a ushort2 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 mul(ushort2x2 a, ushort2 b)
        {
            return a.c0 * b.xx + a.c1 * b.yy;
        }

        /// <summary>		Returns the ushort2x2 matrix result of a matrix multiplication between a ushort2x2 matrix and a ushort2x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2x2 mul(ushort2x2 a, ushort2x2 b)
        {
            return new ushort2x2(
                a.c0 * b.c0.xx + a.c1 * b.c0.yy,
                a.c0 * b.c1.xx + a.c1 * b.c1.yy);
        }

        /// <summary>		Returns the ushort2x3 matrix result of a matrix multiplication between a ushort2x2 matrix and a ushort2x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2x3 mul(ushort2x2 a, ushort2x3 b)
        {
            return new ushort2x3(
                a.c0 * b.c0.xx + a.c1 * b.c0.yy,
                a.c0 * b.c1.xx + a.c1 * b.c1.yy,
                a.c0 * b.c2.xx + a.c1 * b.c2.yy);
        }

        /// <summary>		Returns the ushort2x4 matrix result of a matrix multiplication between a ushort2x2 matrix and a ushort2x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2x4 mul(ushort2x2 a, ushort2x4 b)
        {
            return new ushort2x4(
                a.c0 * b.c0.xx + a.c1 * b.c0.yy,
                a.c0 * b.c1.xx + a.c1 * b.c1.yy,
                a.c0 * b.c2.xx + a.c1 * b.c2.yy,
                a.c0 * b.c3.xx + a.c1 * b.c3.yy);
        }

        /// <summary>		Returns the ushort2 column vector result of a matrix multiplication between a ushort2x3 matrix and a ushort3 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 mul(ushort2x3 a, ushort3 b)
        {
            return a.c0 * b.xx + a.c1 * b.yy + a.c2 * b.zz;
        }

        /// <summary>		Returns the ushort2x2 matrix result of a matrix multiplication between a ushort2x3 matrix and a ushort3x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2x2 mul(ushort2x3 a, ushort3x2 b)
        {
            return new ushort2x2(
                a.c0 * b.c0.xx + a.c1 * b.c0.yy + a.c2 * b.c0.zz,
                a.c0 * b.c1.xx + a.c1 * b.c1.yy + a.c2 * b.c1.zz);
        }

        /// <summary>		Returns the ushort2x3 matrix result of a matrix multiplication between a ushort2x3 matrix and a ushort3x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2x3 mul(ushort2x3 a, ushort3x3 b)
        {
            return new ushort2x3(
                a.c0 * b.c0.xx + a.c1 * b.c0.yy + a.c2 * b.c0.zz,
                a.c0 * b.c1.xx + a.c1 * b.c1.yy + a.c2 * b.c1.zz,
                a.c0 * b.c2.xx + a.c1 * b.c2.yy + a.c2 * b.c2.zz);
        }

        /// <summary>		Returns the ushort2x4 matrix result of a matrix multiplication between a ushort2x3 matrix and a ushort3x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2x4 mul(ushort2x3 a, ushort3x4 b)
        {
            return new ushort2x4(
                a.c0 * b.c0.xx + a.c1 * b.c0.yy + a.c2 * b.c0.zz,
                a.c0 * b.c1.xx + a.c1 * b.c1.yy + a.c2 * b.c1.zz,
                a.c0 * b.c2.xx + a.c1 * b.c2.yy + a.c2 * b.c2.zz,
                a.c0 * b.c3.xx + a.c1 * b.c3.yy + a.c2 * b.c3.zz);
        }

        /// <summary>		Returns the ushort2 column vector result of a matrix multiplication between a ushort2x4 matrix and a ushort4 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 mul(ushort2x4 a, ushort4 b)
        {
            return a.c0 * b.xx + a.c1 * b.yy + a.c2 * b.zz + a.c3 * b.ww;
        }

        /// <summary>		Returns the ushort2x2 matrix result of a matrix multiplication between a ushort2x4 matrix and a ushort4x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2x2 mul(ushort2x4 a, ushort4x2 b)
        {
            return new ushort2x2(
                (a.c0 * b.c0.xx + a.c1 * b.c0.yy) + (a.c2 * b.c0.zz + a.c3 * b.c0.ww),
                (a.c0 * b.c1.xx + a.c1 * b.c1.yy) + (a.c2 * b.c1.zz + a.c3 * b.c1.ww));
        }

        /// <summary>		Returns the ushort2x3 matrix result of a matrix multiplication between a ushort2x4 matrix and a ushort4x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2x3 mul(ushort2x4 a, ushort4x3 b)
        {
            return new ushort2x3(
                (a.c0 * b.c0.xx + a.c1 * b.c0.yy) + (a.c2 * b.c0.zz + a.c3 * b.c0.ww),
                (a.c0 * b.c1.xx + a.c1 * b.c1.yy) + (a.c2 * b.c1.zz + a.c3 * b.c1.ww),
                (a.c0 * b.c2.xx + a.c1 * b.c2.yy) + (a.c2 * b.c2.zz + a.c3 * b.c2.ww));
        }

        /// <summary>		Returns the ushort2x4 matrix result of a matrix multiplication between a ushort2x4 matrix and a ushort4x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2x4 mul(ushort2x4 a, ushort4x4 b)
        {
            return new ushort2x4(
                (a.c0 * b.c0.xx + a.c1 * b.c0.yy) + (a.c2 * b.c0.zz + a.c3 * b.c0.ww),
                (a.c0 * b.c1.xx + a.c1 * b.c1.yy) + (a.c2 * b.c1.zz + a.c3 * b.c1.ww),
                (a.c0 * b.c2.xx + a.c1 * b.c2.yy) + (a.c2 * b.c2.zz + a.c3 * b.c2.ww),
                (a.c0 * b.c3.xx + a.c1 * b.c3.yy) + (a.c2 * b.c3.zz + a.c3 * b.c3.ww));
        }

        /// <summary>		Returns the ushort3 column vector result of a matrix multiplication between a ushort3x2 matrix and a ushort2 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 mul(ushort3x2 a, ushort2 b)
        {
            return a.c0 * b.xxx + a.c1 * b.yyy;
        }

        /// <summary>		Returns the ushort3x2 matrix result of a matrix multiplication between a ushort3x2 matrix and a ushort2x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3x2 mul(ushort3x2 a, ushort2x2 b)
        {
            return new ushort3x2(
                a.c0 * b.c0.xxx + a.c1 * b.c0.yyy,
                a.c0 * b.c1.xxx + a.c1 * b.c1.yyy);
        }

        /// <summary>		Returns the ushort3x3 matrix result of a matrix multiplication between a ushort3x2 matrix and a ushort2x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3x3 mul(ushort3x2 a, ushort2x3 b)
        {
            return new ushort3x3(
                a.c0 * b.c0.xxx + a.c1 * b.c0.yyy,
                a.c0 * b.c1.xxx + a.c1 * b.c1.yyy,
                a.c0 * b.c2.xxx + a.c1 * b.c2.yyy);
        }

        /// <summary>		Returns the ushort3x4 matrix result of a matrix multiplication between a ushort3x2 matrix and a ushort2x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3x4 mul(ushort3x2 a, ushort2x4 b)
        {
            return new ushort3x4(
                a.c0 * b.c0.xxx + a.c1 * b.c0.yyy,
                a.c0 * b.c1.xxx + a.c1 * b.c1.yyy,
                a.c0 * b.c2.xxx + a.c1 * b.c2.yyy,
                a.c0 * b.c3.xxx + a.c1 * b.c3.yyy);
        }

        /// <summary>		Returns the ushort3 column vector result of a matrix multiplication between a ushort3x3 matrix and a ushort3 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 mul(ushort3x3 a, ushort3 b)
        {
            return a.c0 * b.xxx + a.c1 * b.yyy + a.c2 * b.zzz;
        }

        /// <summary>		Returns the ushort3x2 matrix result of a matrix multiplication between a ushort3x3 matrix and a ushort3x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3x2 mul(ushort3x3 a, ushort3x2 b)
        {
            return new ushort3x2(
                a.c0 * b.c0.xxx + a.c1 * b.c0.yyy + a.c2 * b.c0.zzz,
                a.c0 * b.c1.xxx + a.c1 * b.c1.yyy + a.c2 * b.c1.zzz);
        }

        /// <summary>		Returns the ushort3x3 matrix result of a matrix multiplication between a ushort3x3 matrix and a ushort3x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3x3 mul(ushort3x3 a, ushort3x3 b)
        {
            return new ushort3x3(
                a.c0 * b.c0.xxx + a.c1 * b.c0.yyy + a.c2 * b.c0.zzz,
                a.c0 * b.c1.xxx + a.c1 * b.c1.yyy + a.c2 * b.c1.zzz,
                a.c0 * b.c2.xxx + a.c1 * b.c2.yyy + a.c2 * b.c2.zzz);
        }

        /// <summary>		Returns the ushort3x4 matrix result of a matrix multiplication between a ushort3x3 matrix and a ushort3x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3x4 mul(ushort3x3 a, ushort3x4 b)
        {
            return new ushort3x4(
                a.c0 * b.c0.xxx + a.c1 * b.c0.yyy + a.c2 * b.c0.zzz,
                a.c0 * b.c1.xxx + a.c1 * b.c1.yyy + a.c2 * b.c1.zzz,
                a.c0 * b.c2.xxx + a.c1 * b.c2.yyy + a.c2 * b.c2.zzz,
                a.c0 * b.c3.xxx + a.c1 * b.c3.yyy + a.c2 * b.c3.zzz);
        }

        /// <summary>		Returns the ushort3 column vector result of a matrix multiplication between a ushort3x4 matrix and a ushort4 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 mul(ushort3x4 a, ushort4 b)
        {
            return a.c0 * b.xxx + a.c1 * b.yyy + a.c2 * b.zzz + a.c3 * b.www;
        }

        /// <summary>		Returns the ushort3x2 matrix result of a matrix multiplication between a ushort3x4 matrix and a ushort4x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3x2 mul(ushort3x4 a, ushort4x2 b)
        {
            return new ushort3x2(
                (a.c0 * b.c0.xxx + a.c1 * b.c0.yyy) + (a.c2 * b.c0.zzz + a.c3 * b.c0.www),
                (a.c0 * b.c1.xxx + a.c1 * b.c1.yyy) + (a.c2 * b.c1.zzz + a.c3 * b.c1.www));
        }

        /// <summary>		Returns the ushort3x3 matrix result of a matrix multiplication between a ushort3x4 matrix and a ushort4x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3x3 mul(ushort3x4 a, ushort4x3 b)
        {
            return new ushort3x3(
                (a.c0 * b.c0.xxx + a.c1 * b.c0.yyy) + (a.c2 * b.c0.zzz + a.c3 * b.c0.www),
                (a.c0 * b.c1.xxx + a.c1 * b.c1.yyy) + (a.c2 * b.c1.zzz + a.c3 * b.c1.www),
                (a.c0 * b.c2.xxx + a.c1 * b.c2.yyy) + (a.c2 * b.c2.zzz + a.c3 * b.c2.www));
        }

        /// <summary>		Returns the ushort3x4 matrix result of a matrix multiplication between a ushort3x4 matrix and a ushort4x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3x4 mul(ushort3x4 a, ushort4x4 b)
        {
            return new ushort3x4(
                (a.c0 * b.c0.xxx + a.c1 * b.c0.yyy) + (a.c2 * b.c0.zzz + a.c3 * b.c0.www),
                (a.c0 * b.c1.xxx + a.c1 * b.c1.yyy) + (a.c2 * b.c1.zzz + a.c3 * b.c1.www),
                (a.c0 * b.c2.xxx + a.c1 * b.c2.yyy) + (a.c2 * b.c2.zzz + a.c3 * b.c2.www),
                (a.c0 * b.c3.xxx + a.c1 * b.c3.yyy) + (a.c2 * b.c3.zzz + a.c3 * b.c3.www));
        }

        /// <summary>		Returns the ushort4 column vector result of a matrix multiplication between a ushort4x2 matrix and a ushort2 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 mul(ushort4x2 a, ushort2 b)
        {
            return a.c0 * b.xxxx + a.c1 * b.yyyy;
        }

        /// <summary>		Returns the ushort4x2 matrix result of a matrix multiplication between a ushort4x2 matrix and a ushort2x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x2 mul(ushort4x2 a, ushort2x2 b)
        {
            return new ushort4x2(
                a.c0 * b.c0.xxxx + a.c1 * b.c0.yyyy,
                a.c0 * b.c1.xxxx + a.c1 * b.c1.yyyy);
        }

        /// <summary>		Returns the ushort4x3 matrix result of a matrix multiplication between a ushort4x2 matrix and a ushort2x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 mul(ushort4x2 a, ushort2x3 b)
        {
            return new ushort4x3(
                a.c0 * b.c0.xxxx + a.c1 * b.c0.yyyy,
                a.c0 * b.c1.xxxx + a.c1 * b.c1.yyyy,
                a.c0 * b.c2.xxxx + a.c1 * b.c2.yyyy);
        }

        /// <summary>		Returns the ushort4x4 matrix result of a matrix multiplication between a ushort4x2 matrix and a ushort2x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x4 mul(ushort4x2 a, ushort2x4 b)
        {
            return new ushort4x4(
                a.c0 * b.c0.xxxx + a.c1 * b.c0.yyyy,
                a.c0 * b.c1.xxxx + a.c1 * b.c1.yyyy,
                a.c0 * b.c2.xxxx + a.c1 * b.c2.yyyy,
                a.c0 * b.c3.xxxx + a.c1 * b.c3.yyyy);
        }

        /// <summary>		Returns the ushort4 column vector result of a matrix multiplication between a ushort4x3 matrix and a ushort3 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 mul(ushort4x3 a, ushort3 b)
        {
            return a.c0 * b.xxxx + a.c1 * b.yyyy + a.c2 * b.zzzz;
        }

        /// <summary>		Returns the ushort4x2 matrix result of a matrix multiplication between a ushort4x3 matrix and a ushort3x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x2 mul(ushort4x3 a, ushort3x2 b)
        {
            return new ushort4x2(
                a.c0 * b.c0.xxxx + a.c1 * b.c0.yyyy + a.c2 * b.c0.zzzz,
                a.c0 * b.c1.xxxx + a.c1 * b.c1.yyyy + a.c2 * b.c1.zzzz);
        }

        /// <summary>		Returns the ushort4x3 matrix result of a matrix multiplication between a ushort4x3 matrix and a ushort3x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 mul(ushort4x3 a, ushort3x3 b)
        {
            return new ushort4x3(
                a.c0 * b.c0.xxxx + a.c1 * b.c0.yyyy + a.c2 * b.c0.zzzz,
                a.c0 * b.c1.xxxx + a.c1 * b.c1.yyyy + a.c2 * b.c1.zzzz,
                a.c0 * b.c2.xxxx + a.c1 * b.c2.yyyy + a.c2 * b.c2.zzzz);
        }

        /// <summary>		Returns the ushort4x4 matrix result of a matrix multiplication between a ushort4x3 matrix and a ushort3x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x4 mul(ushort4x3 a, ushort3x4 b)
        {
            return new ushort4x4(
                a.c0 * b.c0.xxxx + a.c1 * b.c0.yyyy + a.c2 * b.c0.zzzz,
                a.c0 * b.c1.xxxx + a.c1 * b.c1.yyyy + a.c2 * b.c1.zzzz,
                a.c0 * b.c2.xxxx + a.c1 * b.c2.yyyy + a.c2 * b.c2.zzzz,
                a.c0 * b.c3.xxxx + a.c1 * b.c3.yyyy + a.c2 * b.c3.zzzz);
        }

        /// <summary>		Returns the ushort4 column vector result of a matrix multiplication between a ushort4x4 matrix and a ushort4 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 mul(ushort4x4 a, ushort4 b)
        {
            return a.c0 * b.xxxx + a.c1 * b.yyyy + a.c2 * b.zzzz + a.c3 * b.wwww;
        }

        /// <summary>		Returns the ushort4x2 matrix result of a matrix multiplication between a ushort4x4 matrix and a ushort4x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x2 mul(ushort4x4 a, ushort4x2 b)
        {
            return new ushort4x2(
                (a.c0 * b.c0.xxxx + a.c1 * b.c0.yyyy) + (a.c2 * b.c0.zzzz + a.c3 * b.c0.wwww),
                (a.c0 * b.c1.xxxx + a.c1 * b.c1.yyyy) + (a.c2 * b.c1.zzzz + a.c3 * b.c1.wwww));
        }

        /// <summary>		Returns the ushort4x3 matrix result of a matrix multiplication between a ushort4x4 matrix and a ushort4x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 mul(ushort4x4 a, ushort4x3 b)
        {
            return new ushort4x3(
                (a.c0 * b.c0.xxxx + a.c1 * b.c0.yyyy) + (a.c2 * b.c0.zzzz + a.c3 * b.c0.wwww),
                (a.c0 * b.c1.xxxx + a.c1 * b.c1.yyyy) + (a.c2 * b.c1.zzzz + a.c3 * b.c1.wwww),
                (a.c0 * b.c2.xxxx + a.c1 * b.c2.yyyy) + (a.c2 * b.c2.zzzz + a.c3 * b.c2.wwww));
        }

        /// <summary>		Returns the ushort4x4 matrix result of a matrix multiplication between a ushort4x4 matrix and a ushort4x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x4 mul(ushort4x4 a, ushort4x4 b)
        {
            return new ushort4x4(
                (a.c0 * b.c0.xxxx + a.c1 * b.c0.yyyy) + (a.c2 * b.c0.zzzz + a.c3 * b.c0.wwww),
                (a.c0 * b.c1.xxxx + a.c1 * b.c1.yyyy) + (a.c2 * b.c1.zzzz + a.c3 * b.c1.wwww),
                (a.c0 * b.c2.xxxx + a.c1 * b.c2.yyyy) + (a.c2 * b.c2.zzzz + a.c3 * b.c2.wwww),
                (a.c0 * b.c3.xxxx + a.c1 * b.c3.yyyy) + (a.c2 * b.c3.zzzz + a.c3 * b.c3.wwww));
        }


        /// <summary>		Returns the sbyte value result of a matrix multiplication between an sbyte2 row vector and an sbyte2 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int mul(sbyte2 a, sbyte2 b)
        {
            return dot(a, b);
        }

        /// <summary>		Returns the sbyte2 row vector result of a matrix multiplication between an sbyte2 row vector and an sbyte2x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 mul(sbyte2 a, sbyte2x2 b)
        {
            return new sbyte2((sbyte)dot(a, b.c0), (sbyte)dot(a, b.c1));
        }

        /// <summary>		Returns the sbyte3 row vector result of a matrix multiplication between an sbyte2 row vector and an sbyte2x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 mul(sbyte2 a, sbyte2x3 b)
        {
            return new sbyte3((sbyte)dot(a, b.c0), (sbyte)dot(a, b.c1), (sbyte)dot(a, b.c2));
        }

        /// <summary>		Returns the sbyte4 row vector result of a matrix multiplication between an sbyte2 row vector and an sbyte2x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 mul(sbyte2 a, sbyte2x4 b)
        {
            return new sbyte4((sbyte)dot(a, b.c0), (sbyte)dot(a, b.c1), (sbyte)dot(a, b.c2), (sbyte)dot(a, b.c3));
        }

        /// <summary>		Returns the sbyte value result of a matrix multiplication between an sbyte3 row vector and an sbyte3 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int mul(sbyte3 a, sbyte3 b)
        {
            return dot(a, b);
        }

        /// <summary>		Returns the sbyte2 row vector result of a matrix multiplication between an sbyte3 row vector and an sbyte3x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 mul(sbyte3 a, sbyte3x2 b)
        {
            return new sbyte2((sbyte)dot(a, b.c0), (sbyte)dot(a, b.c1));
        }

        /// <summary>		Returns the sbyte3 row vector result of a matrix multiplication between an sbyte3 row vector and an sbyte3x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 mul(sbyte3 a, sbyte3x3 b)
        {
            return new sbyte3((sbyte)dot(a, b.c0), (sbyte)dot(a, b.c1), (sbyte)dot(a, b.c2));
        }

        /// <summary>		Returns the sbyte4 row vector result of a matrix multiplication between an sbyte3 row vector and an sbyte3x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 mul(sbyte3 a, sbyte3x4 b)
        {
            return new sbyte4((sbyte)dot(a, b.c0), (sbyte)dot(a, b.c1), (sbyte)dot(a, b.c2), (sbyte)dot(a, b.c3));
        }

        /// <summary>		Returns the sbyte value result of a matrix multiplication between an sbyte4 row vector and an sbyte4 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int mul(sbyte4 a, sbyte4 b)
        {
            return dot(a, b);
        }

        /// <summary>		Returns the sbyte2 row vector result of a matrix multiplication between an sbyte4 row vector and an sbyte4x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 mul(sbyte4 a, sbyte4x2 b)
        {
            return new sbyte2((sbyte)dot(a, b.c0), (sbyte)dot(a, b.c1));
        }

        /// <summary>		Returns the sbyte3 row vector result of a matrix multiplication between an sbyte4 row vector and an sbyte4x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 mul(sbyte4 a, sbyte4x3 b)
        {
            return new sbyte3((sbyte)dot(a, b.c0), (sbyte)dot(a, b.c1), (sbyte)dot(a, b.c2));
        }

        /// <summary>		Returns the sbyte4 row vector result of a matrix multiplication between an sbyte4 row vector and an sbyte4x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 mul(sbyte4 a, sbyte4x4 b)
        {
            return new sbyte4((sbyte)dot(a, b.c0), (sbyte)dot(a, b.c1), (sbyte)dot(a, b.c2), (sbyte)dot(a, b.c3));
        }

        /// <summary>		Returns the sbyte2 column vector result of a matrix multiplication between an sbyte2x2 matrix and an sbyte2 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 mul(sbyte2x2 a, sbyte2 b)
        {
            return (sbyte2)((short2)a.c0 * (short2)b.xx + (short2)a.c1 * (short2)b.yy);
        }

        /// <summary>		Returns the sbyte2x2 matrix result of a matrix multiplication between an sbyte2x2 matrix and an sbyte2x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2x2 mul(sbyte2x2 a, sbyte2x2 b)
        {
            return new sbyte2x2(
                (sbyte2)((short2)a.c0 * (short2)b.c0.xx + (short2)a.c1 * (short2)b.c0.yy),
                (sbyte2)((short2)a.c0 * (short2)b.c1.xx + (short2)a.c1 * (short2)b.c1.yy));
        }

        /// <summary>		Returns the sbyte2x3 matrix result of a matrix multiplication between an sbyte2x2 matrix and an sbyte2x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2x3 mul(sbyte2x2 a, sbyte2x3 b)
        {
            return new sbyte2x3(
                (sbyte2)((short2)a.c0 * (short2)b.c0.xx + (short2)a.c1 * (short2)b.c0.yy),
                (sbyte2)((short2)a.c0 * (short2)b.c1.xx + (short2)a.c1 * (short2)b.c1.yy),
                (sbyte2)((short2)a.c0 * (short2)b.c2.xx + (short2)a.c1 * (short2)b.c2.yy));
        }

        /// <summary>		Returns the sbyte2x4 matrix result of a matrix multiplication between an sbyte2x2 matrix and an sbyte2x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2x4 mul(sbyte2x2 a, sbyte2x4 b)
        {
            return new sbyte2x4(
                (sbyte2)((short2)a.c0 * (short2)b.c0.xx + (short2)a.c1 * (short2)b.c0.yy),
                (sbyte2)((short2)a.c0 * (short2)b.c1.xx + (short2)a.c1 * (short2)b.c1.yy),
                (sbyte2)((short2)a.c0 * (short2)b.c2.xx + (short2)a.c1 * (short2)b.c2.yy),
                (sbyte2)((short2)a.c0 * (short2)b.c3.xx + (short2)a.c1 * (short2)b.c3.yy));
        }

        /// <summary>		Returns the sbyte2 column vector result of a matrix multiplication between an sbyte2x3 matrix and an sbyte3 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 mul(sbyte2x3 a, sbyte3 b)
        {
            return (sbyte2)((short2)a.c0 * (short2)b.xx + (short2)a.c1 * (short2)b.yy + (short2)a.c2 * (short2)b.zz);
        }

        /// <summary>		Returns the sbyte2x2 matrix result of a matrix multiplication between an sbyte2x3 matrix and an sbyte3x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2x2 mul(sbyte2x3 a, sbyte3x2 b)
        {
            return new sbyte2x2(
                (sbyte2)((short2)a.c0 * (short2)b.c0.xx + (short2)a.c1 * (short2)b.c0.yy + (short2)a.c2 * (short2)b.c0.zz),
                (sbyte2)((short2)a.c0 * (short2)b.c1.xx + (short2)a.c1 * (short2)b.c1.yy + (short2)a.c2 * (short2)b.c1.zz));
        }

        /// <summary>		Returns the sbyte2x3 matrix result of a matrix multiplication between an sbyte2x3 matrix and an sbyte3x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2x3 mul(sbyte2x3 a, sbyte3x3 b)
        {
            return new sbyte2x3(
                (sbyte2)((short2)a.c0 * (short2)b.c0.xx + (short2)a.c1 * (short2)b.c0.yy + (short2)a.c2 * (short2)b.c0.zz),
                (sbyte2)((short2)a.c0 * (short2)b.c1.xx + (short2)a.c1 * (short2)b.c1.yy + (short2)a.c2 * (short2)b.c1.zz),
                (sbyte2)((short2)a.c0 * (short2)b.c2.xx + (short2)a.c1 * (short2)b.c2.yy + (short2)a.c2 * (short2)b.c2.zz));
        }

        /// <summary>		Returns the sbyte2x4 matrix result of a matrix multiplication between an sbyte2x3 matrix and an sbyte3x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2x4 mul(sbyte2x3 a, sbyte3x4 b)
        {
            return new sbyte2x4(
                (sbyte2)((short2)a.c0 * (short2)b.c0.xx + (short2)a.c1 * (short2)b.c0.yy + (short2)a.c2 * (short2)b.c0.zz),
                (sbyte2)((short2)a.c0 * (short2)b.c1.xx + (short2)a.c1 * (short2)b.c1.yy + (short2)a.c2 * (short2)b.c1.zz),
                (sbyte2)((short2)a.c0 * (short2)b.c2.xx + (short2)a.c1 * (short2)b.c2.yy + (short2)a.c2 * (short2)b.c2.zz),
                (sbyte2)((short2)a.c0 * (short2)b.c3.xx + (short2)a.c1 * (short2)b.c3.yy + (short2)a.c2 * (short2)b.c3.zz));
        }

        /// <summary>		Returns the sbyte2 column vector result of a matrix multiplication between an sbyte2x4 matrix and an sbyte4 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 mul(sbyte2x4 a, sbyte4 b)
        {
            return (sbyte2)(((short2)a.c0 * (short2)b.xx + (short2)a.c1 * (short2)b.yy) + ((short2)a.c2 * (short2)b.zz + (short2)a.c3 * (short2)b.ww));
        }

        /// <summary>		Returns the sbyte2x2 matrix result of a matrix multiplication between an sbyte2x4 matrix and an sbyte4x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2x2 mul(sbyte2x4 a, sbyte4x2 b)
        {
            return new sbyte2x2(
                (sbyte2)(((short2)a.c0 * (short2)b.c0.xx + (short2)a.c1 * (short2)b.c0.yy) + ((short2)a.c2 * (short2)b.c0.zz + (short2)a.c3 * (short2)b.c0.ww)),
                (sbyte2)(((short2)a.c0 * (short2)b.c1.xx + (short2)a.c1 * (short2)b.c1.yy) + ((short2)a.c2 * (short2)b.c1.zz + (short2)a.c3 * (short2)b.c1.ww)));
        }

        /// <summary>		Returns the sbyte2x3 matrix result of a matrix multiplication between an sbyte2x4 matrix and an sbyte4x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2x3 mul(sbyte2x4 a, sbyte4x3 b)
        {
            return new sbyte2x3(
                (sbyte2)(((short2)a.c0 * (short2)b.c0.xx + (short2)a.c1 * (short2)b.c0.yy) + ((short2)a.c2 * (short2)b.c0.zz + (short2)a.c3 * (short2)b.c0.ww)),
                (sbyte2)(((short2)a.c0 * (short2)b.c1.xx + (short2)a.c1 * (short2)b.c1.yy) + ((short2)a.c2 * (short2)b.c1.zz + (short2)a.c3 * (short2)b.c1.ww)),
                (sbyte2)(((short2)a.c0 * (short2)b.c2.xx + (short2)a.c1 * (short2)b.c2.yy) + ((short2)a.c2 * (short2)b.c2.zz + (short2)a.c3 * (short2)b.c2.ww)));
        }

        /// <summary>		Returns the sbyte2x4 matrix result of a matrix multiplication between an sbyte2x4 matrix and an sbyte4x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2x4 mul(sbyte2x4 a, sbyte4x4 b)
        {
            return new sbyte2x4(
                (sbyte2)(((short2)a.c0 * (short2)b.c0.xx + (short2)a.c1 * (short2)b.c0.yy) + ((short2)a.c2 * (short2)b.c0.zz + (short2)a.c3 * (short2)b.c0.ww)),
                (sbyte2)(((short2)a.c0 * (short2)b.c1.xx + (short2)a.c1 * (short2)b.c1.yy) + ((short2)a.c2 * (short2)b.c1.zz + (short2)a.c3 * (short2)b.c1.ww)),
                (sbyte2)(((short2)a.c0 * (short2)b.c2.xx + (short2)a.c1 * (short2)b.c2.yy) + ((short2)a.c2 * (short2)b.c2.zz + (short2)a.c3 * (short2)b.c2.ww)),
                (sbyte2)(((short2)a.c0 * (short2)b.c3.xx + (short2)a.c1 * (short2)b.c3.yy) + ((short2)a.c2 * (short2)b.c3.zz + (short2)a.c3 * (short2)b.c3.ww)));
        }

        /// <summary>		Returns the sbyte3 column vector result of a matrix multiplication between an sbyte3x2 matrix and an sbyte2 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 mul(sbyte3x2 a, sbyte2 b)
        {
            return (sbyte3)((short3)a.c0 * (short3)b.xxx + (short3)a.c1 * (short3)b.yyy);
        }

        /// <summary>		Returns the sbyte3x2 matrix result of a matrix multiplication between an sbyte3x2 matrix and an sbyte2x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3x2 mul(sbyte3x2 a, sbyte2x2 b)
        {
            return new sbyte3x2(
                (sbyte3)((short3)a.c0 * (short3)b.c0.xxx + (short3)a.c1 * (short3)b.c0.yyy),
                (sbyte3)((short3)a.c0 * (short3)b.c1.xxx + (short3)a.c1 * (short3)b.c1.yyy));
        }

        /// <summary>		Returns the sbyte3x3 matrix result of a matrix multiplication between an sbyte3x2 matrix and an sbyte2x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3x3 mul(sbyte3x2 a, sbyte2x3 b)
        {
            return new sbyte3x3(
                (sbyte3)((short3)a.c0 * (short3)b.c0.xxx + (short3)a.c1 * (short3)b.c0.yyy),
                (sbyte3)((short3)a.c0 * (short3)b.c1.xxx + (short3)a.c1 * (short3)b.c1.yyy),
                (sbyte3)((short3)a.c0 * (short3)b.c2.xxx + (short3)a.c1 * (short3)b.c2.yyy));
        }

        /// <summary>		Returns the sbyte3x4 matrix result of a matrix multiplication between an sbyte3x2 matrix and an sbyte2x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3x4 mul(sbyte3x2 a, sbyte2x4 b)
        {
            return new sbyte3x4(
                (sbyte3)((short3)a.c0 * (short3)b.c0.xxx + (short3)a.c1 * (short3)b.c0.yyy),
                (sbyte3)((short3)a.c0 * (short3)b.c1.xxx + (short3)a.c1 * (short3)b.c1.yyy),
                (sbyte3)((short3)a.c0 * (short3)b.c2.xxx + (short3)a.c1 * (short3)b.c2.yyy),
                (sbyte3)((short3)a.c0 * (short3)b.c3.xxx + (short3)a.c1 * (short3)b.c3.yyy));
        }

        /// <summary>		Returns the sbyte3 column vector result of a matrix multiplication between an sbyte3x3 matrix and an sbyte3 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 mul(sbyte3x3 a, sbyte3 b)
        {
            return (sbyte3)((short3)a.c0 * (short3)b.xxx + (short3)a.c1 * (short3)b.yyy + (short3)a.c2 * (short3)b.zzz);
        }

        /// <summary>		Returns the sbyte3x2 matrix result of a matrix multiplication between an sbyte3x3 matrix and an sbyte3x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3x2 mul(sbyte3x3 a, sbyte3x2 b)
        {
            return new sbyte3x2(
                (sbyte3)((short3)a.c0 * (short3)b.c0.xxx + (short3)a.c1 * (short3)b.c0.yyy + (short3)a.c2 * (short3)b.c0.zzz),
                (sbyte3)((short3)a.c0 * (short3)b.c1.xxx + (short3)a.c1 * (short3)b.c1.yyy + (short3)a.c2 * (short3)b.c1.zzz));
        }

        /// <summary>		Returns the sbyte3x3 matrix result of a matrix multiplication between an sbyte3x3 matrix and an sbyte3x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3x3 mul(sbyte3x3 a, sbyte3x3 b)
        {
            return new sbyte3x3(
                (sbyte3)((short3)a.c0 * (short3)b.c0.xxx + (short3)a.c1 * (short3)b.c0.yyy + (short3)a.c2 * (short3)b.c0.zzz),
                (sbyte3)((short3)a.c0 * (short3)b.c1.xxx + (short3)a.c1 * (short3)b.c1.yyy + (short3)a.c2 * (short3)b.c1.zzz),
                (sbyte3)((short3)a.c0 * (short3)b.c2.xxx + (short3)a.c1 * (short3)b.c2.yyy + (short3)a.c2 * (short3)b.c2.zzz));
        }

        /// <summary>		Returns the sbyte3x4 matrix result of a matrix multiplication between an sbyte3x3 matrix and an sbyte3x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3x4 mul(sbyte3x3 a, sbyte3x4 b)
        {
            return new sbyte3x4(
                (sbyte3)((short3)a.c0 * (short3)b.c0.xxx + (short3)a.c1 * (short3)b.c0.yyy + (short3)a.c2 * (short3)b.c0.zzz),
                (sbyte3)((short3)a.c0 * (short3)b.c1.xxx + (short3)a.c1 * (short3)b.c1.yyy + (short3)a.c2 * (short3)b.c1.zzz),
                (sbyte3)((short3)a.c0 * (short3)b.c2.xxx + (short3)a.c1 * (short3)b.c2.yyy + (short3)a.c2 * (short3)b.c2.zzz),
                (sbyte3)((short3)a.c0 * (short3)b.c3.xxx + (short3)a.c1 * (short3)b.c3.yyy + (short3)a.c2 * (short3)b.c3.zzz));
        }

        /// <summary>		Returns the sbyte3 column vector result of a matrix multiplication between an sbyte3x4 matrix and an sbyte4 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 mul(sbyte3x4 a, sbyte4 b)
        {
            return (sbyte3)(((short3)a.c0 * (short3)b.xxx + (short3)a.c1 * (short3)b.yyy) + ((short3)a.c2 * (short3)b.zzz + (short3)a.c3 * (short3)b.www));
        }

        /// <summary>		Returns the sbyte3x2 matrix result of a matrix multiplication between an sbyte3x4 matrix and an sbyte4x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3x2 mul(sbyte3x4 a, sbyte4x2 b)
        {
            return new sbyte3x2(
                (sbyte3)(((short3)a.c0 * (short3)b.c0.xxx + (short3)a.c1 * (short3)b.c0.yyy) + ((short3)a.c2 * (short3)b.c0.zzz + (short3)a.c3 * (short3)b.c0.www)),
                (sbyte3)(((short3)a.c0 * (short3)b.c1.xxx + (short3)a.c1 * (short3)b.c1.yyy) + ((short3)a.c2 * (short3)b.c1.zzz + (short3)a.c3 * (short3)b.c1.www)));
        }

        /// <summary>		Returns the sbyte3x3 matrix result of a matrix multiplication between an sbyte3x4 matrix and an sbyte4x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3x3 mul(sbyte3x4 a, sbyte4x3 b)
        {
            return new sbyte3x3(
                (sbyte3)(((short3)a.c0 * (short3)b.c0.xxx + (short3)a.c1 * (short3)b.c0.yyy) + ((short3)a.c2 * (short3)b.c0.zzz + (short3)a.c3 * (short3)b.c0.www)),
                (sbyte3)(((short3)a.c0 * (short3)b.c1.xxx + (short3)a.c1 * (short3)b.c1.yyy) + ((short3)a.c2 * (short3)b.c1.zzz + (short3)a.c3 * (short3)b.c1.www)),
                (sbyte3)(((short3)a.c0 * (short3)b.c2.xxx + (short3)a.c1 * (short3)b.c2.yyy) + ((short3)a.c2 * (short3)b.c2.zzz + (short3)a.c3 * (short3)b.c2.www)));
        }

        /// <summary>		Returns the sbyte3x4 matrix result of a matrix multiplication between an sbyte3x4 matrix and an sbyte4x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3x4 mul(sbyte3x4 a, sbyte4x4 b)
        {
            return new sbyte3x4(
                (sbyte3)(((short3)a.c0 * (short3)b.c0.xxx + (short3)a.c1 * (short3)b.c0.yyy) + ((short3)a.c2 * (short3)b.c0.zzz + (short3)a.c3 * (short3)b.c0.www)),
                (sbyte3)(((short3)a.c0 * (short3)b.c1.xxx + (short3)a.c1 * (short3)b.c1.yyy) + ((short3)a.c2 * (short3)b.c1.zzz + (short3)a.c3 * (short3)b.c1.www)),
                (sbyte3)(((short3)a.c0 * (short3)b.c2.xxx + (short3)a.c1 * (short3)b.c2.yyy) + ((short3)a.c2 * (short3)b.c2.zzz + (short3)a.c3 * (short3)b.c2.www)),
                (sbyte3)(((short3)a.c0 * (short3)b.c3.xxx + (short3)a.c1 * (short3)b.c3.yyy) + ((short3)a.c2 * (short3)b.c3.zzz + (short3)a.c3 * (short3)b.c3.www)));
        }

        /// <summary>		Returns the sbyte4 column vector result of a matrix multiplication between an sbyte4x2 matrix and an sbyte2 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 mul(sbyte4x2 a, sbyte2 b)
        {
            return (sbyte4)((short4)a.c0 * (short4)b.xxxx + (short4)a.c1 * (short4)b.yyyy);
        }

        /// <summary>		Returns the sbyte4x2 matrix result of a matrix multiplication between an sbyte4x2 matrix and an sbyte2x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4x2 mul(sbyte4x2 a, sbyte2x2 b)
        {
            return new sbyte4x2(
                (sbyte4)((short4)a.c0 * (short4)b.c0.xxxx + (short4)a.c1 * (short4)b.c0.yyyy),
                (sbyte4)((short4)a.c0 * (short4)b.c1.xxxx + (short4)a.c1 * (short4)b.c1.yyyy));
        }

        /// <summary>		Returns the sbyte4x3 matrix result of a matrix multiplication between an sbyte4x2 matrix and an sbyte2x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4x3 mul(sbyte4x2 a, sbyte2x3 b)
        {
            return new sbyte4x3(
                (sbyte4)((short4)a.c0 * (short4)b.c0.xxxx + (short4)a.c1 * (short4)b.c0.yyyy),
                (sbyte4)((short4)a.c0 * (short4)b.c1.xxxx + (short4)a.c1 * (short4)b.c1.yyyy),
                (sbyte4)((short4)a.c0 * (short4)b.c2.xxxx + (short4)a.c1 * (short4)b.c2.yyyy));
        }

        /// <summary>		Returns the sbyte4x4 matrix result of a matrix multiplication between an sbyte4x2 matrix and an sbyte2x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4x4 mul(sbyte4x2 a, sbyte2x4 b)
        {
            return new sbyte4x4(
                (sbyte4)((short4)a.c0 * (short4)b.c0.xxxx + (short4)a.c1 * (short4)b.c0.yyyy),
                (sbyte4)((short4)a.c0 * (short4)b.c1.xxxx + (short4)a.c1 * (short4)b.c1.yyyy),
                (sbyte4)((short4)a.c0 * (short4)b.c2.xxxx + (short4)a.c1 * (short4)b.c2.yyyy),
                (sbyte4)((short4)a.c0 * (short4)b.c3.xxxx + (short4)a.c1 * (short4)b.c3.yyyy));
        }

        /// <summary>		Returns the sbyte4 column vector result of a matrix multiplication between an sbyte4x3 matrix and an sbyte3 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 mul(sbyte4x3 a, sbyte3 b)
        {
            return (sbyte4)((short4)a.c0 * (short4)b.xxxx + (short4)a.c1 * (short4)b.yyyy + (short4)a.c2 * (short4)b.zzzz);
        }

        /// <summary>		Returns the sbyte4x2 matrix result of a matrix multiplication between an sbyte4x3 matrix and an sbyte3x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4x2 mul(sbyte4x3 a, sbyte3x2 b)
        {
            return new sbyte4x2(
                (sbyte4)((short4)a.c0 * (short4)b.c0.xxxx + (short4)a.c1 * (short4)b.c0.yyyy + (short4)a.c2 * (short4)b.c0.zzzz),
                (sbyte4)((short4)a.c0 * (short4)b.c1.xxxx + (short4)a.c1 * (short4)b.c1.yyyy + (short4)a.c2 * (short4)b.c1.zzzz));
        }

        /// <summary>		Returns the sbyte4x3 matrix result of a matrix multiplication between an sbyte4x3 matrix and an sbyte3x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4x3 mul(sbyte4x3 a, sbyte3x3 b)
        {
            return new sbyte4x3(
                (sbyte4)((short4)a.c0 * (short4)b.c0.xxxx + (short4)a.c1 * (short4)b.c0.yyyy + (short4)a.c2 * (short4)b.c0.zzzz),
                (sbyte4)((short4)a.c0 * (short4)b.c1.xxxx + (short4)a.c1 * (short4)b.c1.yyyy + (short4)a.c2 * (short4)b.c1.zzzz),
                (sbyte4)((short4)a.c0 * (short4)b.c2.xxxx + (short4)a.c1 * (short4)b.c2.yyyy + (short4)a.c2 * (short4)b.c2.zzzz));
        }

        /// <summary>		Returns the sbyte4x4 matrix result of a matrix multiplication between an sbyte4x3 matrix and an sbyte3x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4x4 mul(sbyte4x3 a, sbyte3x4 b)
        {
            return new sbyte4x4(
                (sbyte4)((short4)a.c0 * (short4)b.c0.xxxx + (short4)a.c1 * (short4)b.c0.yyyy + (short4)a.c2 * (short4)b.c0.zzzz),
                (sbyte4)((short4)a.c0 * (short4)b.c1.xxxx + (short4)a.c1 * (short4)b.c1.yyyy + (short4)a.c2 * (short4)b.c1.zzzz),
                (sbyte4)((short4)a.c0 * (short4)b.c2.xxxx + (short4)a.c1 * (short4)b.c2.yyyy + (short4)a.c2 * (short4)b.c2.zzzz),
                (sbyte4)((short4)a.c0 * (short4)b.c3.xxxx + (short4)a.c1 * (short4)b.c3.yyyy + (short4)a.c2 * (short4)b.c3.zzzz));
        }

        /// <summary>		Returns the sbyte4 column vector result of a matrix multiplication between an sbyte4x4 matrix and an sbyte4 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 mul(sbyte4x4 a, sbyte4 b)
        {
            return (sbyte4)(((short4)a.c0 * (short4)b.xxxx + (short4)a.c1 * (short4)b.yyyy) + ((short4)a.c2 * (short4)b.zzzz + (short4)a.c3 * (short4)b.wwww));
        }

        /// <summary>		Returns the sbyte4x2 matrix result of a matrix multiplication between an sbyte4x4 matrix and an sbyte4x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4x2 mul(sbyte4x4 a, sbyte4x2 b)
        {
            return new sbyte4x2(
                (sbyte4)(((short4)a.c0 * (short4)b.c0.xxxx + (short4)a.c1 * (short4)b.c0.yyyy) + ((short4)a.c2 * (short4)b.c0.zzzz + (short4)a.c3 * (short4)b.c0.wwww)),
                (sbyte4)(((short4)a.c0 * (short4)b.c1.xxxx + (short4)a.c1 * (short4)b.c1.yyyy) + ((short4)a.c2 * (short4)b.c1.zzzz + (short4)a.c3 * (short4)b.c1.wwww)));
        }

        /// <summary>		Returns the sbyte4x3 matrix result of a matrix multiplication between an sbyte4x4 matrix and an sbyte4x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4x3 mul(sbyte4x4 a, sbyte4x3 b)
        {
            return new sbyte4x3(
                (sbyte4)(((short4)a.c0 * (short4)b.c0.xxxx + (short4)a.c1 * (short4)b.c0.yyyy) + ((short4)a.c2 * (short4)b.c0.zzzz + (short4)a.c3 * (short4)b.c0.wwww)),
                (sbyte4)(((short4)a.c0 * (short4)b.c1.xxxx + (short4)a.c1 * (short4)b.c1.yyyy) + ((short4)a.c2 * (short4)b.c1.zzzz + (short4)a.c3 * (short4)b.c1.wwww)),
                (sbyte4)(((short4)a.c0 * (short4)b.c2.xxxx + (short4)a.c1 * (short4)b.c2.yyyy) + ((short4)a.c2 * (short4)b.c2.zzzz + (short4)a.c3 * (short4)b.c2.wwww)));
        }

        /// <summary>		Returns the sbyte4x4 matrix result of a matrix multiplication between an sbyte4x4 matrix and an sbyte4x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4x4 mul(sbyte4x4 a, sbyte4x4 b)
        {
            return new sbyte4x4(
                (sbyte4)(((short4)a.c0 * (short4)b.c0.xxxx + (short4)a.c1 * (short4)b.c0.yyyy) + ((short4)a.c2 * (short4)b.c0.zzzz + (short4)a.c3 * (short4)b.c0.wwww)),
                (sbyte4)(((short4)a.c0 * (short4)b.c1.xxxx + (short4)a.c1 * (short4)b.c1.yyyy) + ((short4)a.c2 * (short4)b.c1.zzzz + (short4)a.c3 * (short4)b.c1.wwww)),
                (sbyte4)(((short4)a.c0 * (short4)b.c2.xxxx + (short4)a.c1 * (short4)b.c2.yyyy) + ((short4)a.c2 * (short4)b.c2.zzzz + (short4)a.c3 * (short4)b.c2.wwww)),
                (sbyte4)(((short4)a.c0 * (short4)b.c3.xxxx + (short4)a.c1 * (short4)b.c3.yyyy) + ((short4)a.c2 * (short4)b.c3.zzzz + (short4)a.c3 * (short4)b.c3.wwww)));
        }


        /// <summary>		Returns the byte value result of a matrix multiplication between a byte2 row vector and a byte2 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint mul(byte2 a, byte2 b)
        {
            return dot(a, b);
        }

        /// <summary>		Returns the byte2 row vector result of a matrix multiplication between a byte2 row vector and a byte2x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 mul(byte2 a, byte2x2 b)
        {
            return new byte2((byte)dot(a, b.c0), (byte)dot(a, b.c1));
        }

        /// <summary>		Returns the byte3 row vector result of a matrix multiplication between a byte2 row vector and a byte2x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 mul(byte2 a, byte2x3 b)
        {
            return new byte3((byte)dot(a, b.c0), (byte)dot(a, b.c1), (byte)dot(a, b.c2));
        }

        /// <summary>		Returns the byte4 row vector result of a matrix multiplication between a byte2 row vector and a byte2x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 mul(byte2 a, byte2x4 b)
        {
            return new byte4((byte)dot(a, b.c0), (byte)dot(a, b.c1), (byte)dot(a, b.c2), (byte)dot(a, b.c3));
        }

        /// <summary>		Returns the byte value result of a matrix multiplication between a byte3 row vector and a byte3 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint mul(byte3 a, byte3 b)
        {
            return dot(a, b);
        }

        /// <summary>		Returns the byte2 row vector result of a matrix multiplication between a byte3 row vector and a byte3x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 mul(byte3 a, byte3x2 b)
        {
            return new byte2((byte)dot(a, b.c0), (byte)dot(a, b.c1));
        }

        /// <summary>		Returns the byte3 row vector result of a matrix multiplication between a byte3 row vector and a byte3x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 mul(byte3 a, byte3x3 b)
        {
            return new byte3((byte)dot(a, b.c0), (byte)dot(a, b.c1), (byte)dot(a, b.c2));
        }

        /// <summary>		Returns the byte4 row vector result of a matrix multiplication between a byte3 row vector and a byte3x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 mul(byte3 a, byte3x4 b)
        {
            return new byte4((byte)dot(a, b.c0), (byte)dot(a, b.c1), (byte)dot(a, b.c2), (byte)dot(a, b.c3));
        }

        /// <summary>		Returns the byte value result of a matrix multiplication between a byte4 row vector and a byte4 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint mul(byte4 a, byte4 b)
        {
            return dot(a, b);
        }

        /// <summary>		Returns the byte2 row vector result of a matrix multiplication between a byte4 row vector and a byte4x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 mul(byte4 a, byte4x2 b)
        {
            return new byte2((byte)dot(a, b.c0), (byte)dot(a, b.c1));
        }

        /// <summary>		Returns the byte3 row vector result of a matrix multiplication between a byte4 row vector and a byte4x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 mul(byte4 a, byte4x3 b)
        {
            return new byte3((byte)dot(a, b.c0), (byte)dot(a, b.c1), (byte)dot(a, b.c2));
        }

        /// <summary>		Returns the byte4 row vector result of a matrix multiplication between a byte4 row vector and a byte4x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 mul(byte4 a, byte4x4 b)
        {
            return new byte4((byte)dot(a, b.c0), (byte)dot(a, b.c1), (byte)dot(a, b.c2), (byte)dot(a, b.c3));
        }

        /// <summary>		Returns the byte2 column vector result of a matrix multiplication between a byte2x2 matrix and a byte2 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 mul(byte2x2 a, byte2 b)
        {
            return (byte2)((ushort2)a.c0 * (ushort2)b.xx + (ushort2)a.c1 * (ushort2)b.yy);
        }

        /// <summary>		Returns the byte2x2 matrix result of a matrix multiplication between a byte2x2 matrix and a byte2x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2x2 mul(byte2x2 a, byte2x2 b)
        {
            return new byte2x2(
                (byte2)((ushort2)a.c0 * (ushort2)b.c0.xx + (ushort2)a.c1 * (ushort2)b.c0.yy),
                (byte2)((ushort2)a.c0 * (ushort2)b.c1.xx + (ushort2)a.c1 * (ushort2)b.c1.yy));
        }

        /// <summary>		Returns the byte2x3 matrix result of a matrix multiplication between a byte2x2 matrix and a byte2x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2x3 mul(byte2x2 a, byte2x3 b)
        {
            return new byte2x3(
                (byte2)((ushort2)a.c0 * (ushort2)b.c0.xx + (ushort2)a.c1 * (ushort2)b.c0.yy),
                (byte2)((ushort2)a.c0 * (ushort2)b.c1.xx + (ushort2)a.c1 * (ushort2)b.c1.yy),
                (byte2)((ushort2)a.c0 * (ushort2)b.c2.xx + (ushort2)a.c1 * (ushort2)b.c2.yy));
        }

        /// <summary>		Returns the byte2x4 matrix result of a matrix multiplication between a byte2x2 matrix and a byte2x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2x4 mul(byte2x2 a, byte2x4 b)
        {
            return new byte2x4(
                (byte2)((ushort2)a.c0 * (ushort2)b.c0.xx + (ushort2)a.c1 * (ushort2)b.c0.yy),
                (byte2)((ushort2)a.c0 * (ushort2)b.c1.xx + (ushort2)a.c1 * (ushort2)b.c1.yy),
                (byte2)((ushort2)a.c0 * (ushort2)b.c2.xx + (ushort2)a.c1 * (ushort2)b.c2.yy),
                (byte2)((ushort2)a.c0 * (ushort2)b.c3.xx + (ushort2)a.c1 * (ushort2)b.c3.yy));
        }

        /// <summary>		Returns the byte2 column vector result of a matrix multiplication between a byte2x3 matrix and a byte3 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 mul(byte2x3 a, byte3 b)
        {
            return (byte2)((ushort2)a.c0 * (ushort2)b.xx + (ushort2)a.c1 * (ushort2)b.yy + (ushort2)a.c2 * (ushort2)b.zz);
        }

        /// <summary>		Returns the byte2x2 matrix result of a matrix multiplication between a byte2x3 matrix and a byte3x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2x2 mul(byte2x3 a, byte3x2 b)
        {
            return new byte2x2(
                (byte2)((ushort2)a.c0 * (ushort2)b.c0.xx + (ushort2)a.c1 * (ushort2)b.c0.yy + (ushort2)a.c2 * (ushort2)b.c0.zz),
                (byte2)((ushort2)a.c0 * (ushort2)b.c1.xx + (ushort2)a.c1 * (ushort2)b.c1.yy + (ushort2)a.c2 * (ushort2)b.c1.zz));
        }

        /// <summary>		Returns the byte2x3 matrix result of a matrix multiplication between a byte2x3 matrix and a byte3x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2x3 mul(byte2x3 a, byte3x3 b)
        {
            return new byte2x3(
                (byte2)((ushort2)a.c0 * (ushort2)b.c0.xx + (ushort2)a.c1 * (ushort2)b.c0.yy + (ushort2)a.c2 * (ushort2)b.c0.zz),
                (byte2)((ushort2)a.c0 * (ushort2)b.c1.xx + (ushort2)a.c1 * (ushort2)b.c1.yy + (ushort2)a.c2 * (ushort2)b.c1.zz),
                (byte2)((ushort2)a.c0 * (ushort2)b.c2.xx + (ushort2)a.c1 * (ushort2)b.c2.yy + (ushort2)a.c2 * (ushort2)b.c2.zz));
        }

        /// <summary>		Returns the byte2x4 matrix result of a matrix multiplication between a byte2x3 matrix and a byte3x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2x4 mul(byte2x3 a, byte3x4 b)
        {
            return new byte2x4(
                (byte2)((ushort2)a.c0 * (ushort2)b.c0.xx + (ushort2)a.c1 * (ushort2)b.c0.yy + (ushort2)a.c2 * (ushort2)b.c0.zz),
                (byte2)((ushort2)a.c0 * (ushort2)b.c1.xx + (ushort2)a.c1 * (ushort2)b.c1.yy + (ushort2)a.c2 * (ushort2)b.c1.zz),
                (byte2)((ushort2)a.c0 * (ushort2)b.c2.xx + (ushort2)a.c1 * (ushort2)b.c2.yy + (ushort2)a.c2 * (ushort2)b.c2.zz),
                (byte2)((ushort2)a.c0 * (ushort2)b.c3.xx + (ushort2)a.c1 * (ushort2)b.c3.yy + (ushort2)a.c2 * (ushort2)b.c3.zz));
        }

        /// <summary>		Returns the byte2 column vector result of a matrix multiplication between a byte2x4 matrix and a byte4 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 mul(byte2x4 a, byte4 b)
        {
            return (byte2)(((ushort2)a.c0 * (ushort2)b.xx + (ushort2)a.c1 * (ushort2)b.yy) + ((ushort2)a.c2 * (ushort2)b.zz + (ushort2)a.c3 * (ushort2)b.ww));
        }

        /// <summary>		Returns the byte2x2 matrix result of a matrix multiplication between a byte2x4 matrix and a byte4x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2x2 mul(byte2x4 a, byte4x2 b)
        {
            return new byte2x2(
                (byte2)(((ushort2)a.c0 * (ushort2)b.c0.xx + (ushort2)a.c1 * (ushort2)b.c0.yy) + ((ushort2)a.c2 * (ushort2)b.c0.zz + (ushort2)a.c3 * (ushort2)b.c0.ww)),
                (byte2)(((ushort2)a.c0 * (ushort2)b.c1.xx + (ushort2)a.c1 * (ushort2)b.c1.yy) + ((ushort2)a.c2 * (ushort2)b.c1.zz + (ushort2)a.c3 * (ushort2)b.c1.ww)));
        }

        /// <summary>		Returns the byte2x3 matrix result of a matrix multiplication between a byte2x4 matrix and a byte4x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2x3 mul(byte2x4 a, byte4x3 b)
        {
            return new byte2x3(
                (byte2)(((ushort2)a.c0 * (ushort2)b.c0.xx + (ushort2)a.c1 * (ushort2)b.c0.yy) + ((ushort2)a.c2 * (ushort2)b.c0.zz + (ushort2)a.c3 * (ushort2)b.c0.ww)),
                (byte2)(((ushort2)a.c0 * (ushort2)b.c1.xx + (ushort2)a.c1 * (ushort2)b.c1.yy) + ((ushort2)a.c2 * (ushort2)b.c1.zz + (ushort2)a.c3 * (ushort2)b.c1.ww)),
                (byte2)(((ushort2)a.c0 * (ushort2)b.c2.xx + (ushort2)a.c1 * (ushort2)b.c2.yy) + ((ushort2)a.c2 * (ushort2)b.c2.zz + (ushort2)a.c3 * (ushort2)b.c2.ww)));
        }

        /// <summary>		Returns the byte2x4 matrix result of a matrix multiplication between a byte2x4 matrix and a byte4x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2x4 mul(byte2x4 a, byte4x4 b)
        {
            return new byte2x4(
                (byte2)(((ushort2)a.c0 * (ushort2)b.c0.xx + (ushort2)a.c1 * (ushort2)b.c0.yy) + ((ushort2)a.c2 * (ushort2)b.c0.zz + (ushort2)a.c3 * (ushort2)b.c0.ww)),
                (byte2)(((ushort2)a.c0 * (ushort2)b.c1.xx + (ushort2)a.c1 * (ushort2)b.c1.yy) + ((ushort2)a.c2 * (ushort2)b.c1.zz + (ushort2)a.c3 * (ushort2)b.c1.ww)),
                (byte2)(((ushort2)a.c0 * (ushort2)b.c2.xx + (ushort2)a.c1 * (ushort2)b.c2.yy) + ((ushort2)a.c2 * (ushort2)b.c2.zz + (ushort2)a.c3 * (ushort2)b.c2.ww)),
                (byte2)(((ushort2)a.c0 * (ushort2)b.c3.xx + (ushort2)a.c1 * (ushort2)b.c3.yy) + ((ushort2)a.c2 * (ushort2)b.c3.zz + (ushort2)a.c3 * (ushort2)b.c3.ww)));
        }

        /// <summary>		Returns the byte3 column vector result of a matrix multiplication between a byte3x2 matrix and a byte2 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 mul(byte3x2 a, byte2 b)
        {
            return (byte3)((ushort3)a.c0 * (ushort3)b.xxx + (ushort3)a.c1 * (ushort3)b.yyy);
        }

        /// <summary>		Returns the byte3x2 matrix result of a matrix multiplication between a byte3x2 matrix and a byte2x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3x2 mul(byte3x2 a, byte2x2 b)
        {
            return new byte3x2(
                (byte3)((ushort3)a.c0 * (ushort3)b.c0.xxx + (ushort3)a.c1 * (ushort3)b.c0.yyy),
                (byte3)((ushort3)a.c0 * (ushort3)b.c1.xxx + (ushort3)a.c1 * (ushort3)b.c1.yyy));
        }

        /// <summary>		Returns the byte3x3 matrix result of a matrix multiplication between a byte3x2 matrix and a byte2x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3x3 mul(byte3x2 a, byte2x3 b)
        {
            return new byte3x3(
                (byte3)((ushort3)a.c0 * (ushort3)b.c0.xxx + (ushort3)a.c1 * (ushort3)b.c0.yyy),
                (byte3)((ushort3)a.c0 * (ushort3)b.c1.xxx + (ushort3)a.c1 * (ushort3)b.c1.yyy),
                (byte3)((ushort3)a.c0 * (ushort3)b.c2.xxx + (ushort3)a.c1 * (ushort3)b.c2.yyy));
        }

        /// <summary>		Returns the byte3x4 matrix result of a matrix multiplication between a byte3x2 matrix and a byte2x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3x4 mul(byte3x2 a, byte2x4 b)
        {
            return new byte3x4(
                (byte3)((ushort3)a.c0 * (ushort3)b.c0.xxx + (ushort3)a.c1 * (ushort3)b.c0.yyy),
                (byte3)((ushort3)a.c0 * (ushort3)b.c1.xxx + (ushort3)a.c1 * (ushort3)b.c1.yyy),
                (byte3)((ushort3)a.c0 * (ushort3)b.c2.xxx + (ushort3)a.c1 * (ushort3)b.c2.yyy),
                (byte3)((ushort3)a.c0 * (ushort3)b.c3.xxx + (ushort3)a.c1 * (ushort3)b.c3.yyy));
        }

        /// <summary>		Returns the byte3 column vector result of a matrix multiplication between a byte3x3 matrix and a byte3 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 mul(byte3x3 a, byte3 b)
        {
            return (byte3)((ushort3)a.c0 * (ushort3)b.xxx + (ushort3)a.c1 * (ushort3)b.yyy + (ushort3)a.c2 * (ushort3)b.zzz);
        }

        /// <summary>		Returns the byte3x2 matrix result of a matrix multiplication between a byte3x3 matrix and a byte3x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3x2 mul(byte3x3 a, byte3x2 b)
        {
            return new byte3x2(
                (byte3)((ushort3)a.c0 * (ushort3)b.c0.xxx + (ushort3)a.c1 * (ushort3)b.c0.yyy + (ushort3)a.c2 * (ushort3)b.c0.zzz),
                (byte3)((ushort3)a.c0 * (ushort3)b.c1.xxx + (ushort3)a.c1 * (ushort3)b.c1.yyy + (ushort3)a.c2 * (ushort3)b.c1.zzz));
        }

        /// <summary>		Returns the byte3x3 matrix result of a matrix multiplication between a byte3x3 matrix and a byte3x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3x3 mul(byte3x3 a, byte3x3 b)
        {
            return new byte3x3(
                (byte3)((ushort3)a.c0 * (ushort3)b.c0.xxx + (ushort3)a.c1 * (ushort3)b.c0.yyy + (ushort3)a.c2 * (ushort3)b.c0.zzz),
                (byte3)((ushort3)a.c0 * (ushort3)b.c1.xxx + (ushort3)a.c1 * (ushort3)b.c1.yyy + (ushort3)a.c2 * (ushort3)b.c1.zzz),
                (byte3)((ushort3)a.c0 * (ushort3)b.c2.xxx + (ushort3)a.c1 * (ushort3)b.c2.yyy + (ushort3)a.c2 * (ushort3)b.c2.zzz));
        }

        /// <summary>		Returns the byte3x4 matrix result of a matrix multiplication between a byte3x3 matrix and a byte3x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3x4 mul(byte3x3 a, byte3x4 b)
        {
            return new byte3x4(
                (byte3)((ushort3)a.c0 * (ushort3)b.c0.xxx + (ushort3)a.c1 * (ushort3)b.c0.yyy + (ushort3)a.c2 * (ushort3)b.c0.zzz),
                (byte3)((ushort3)a.c0 * (ushort3)b.c1.xxx + (ushort3)a.c1 * (ushort3)b.c1.yyy + (ushort3)a.c2 * (ushort3)b.c1.zzz),
                (byte3)((ushort3)a.c0 * (ushort3)b.c2.xxx + (ushort3)a.c1 * (ushort3)b.c2.yyy + (ushort3)a.c2 * (ushort3)b.c2.zzz),
                (byte3)((ushort3)a.c0 * (ushort3)b.c3.xxx + (ushort3)a.c1 * (ushort3)b.c3.yyy + (ushort3)a.c2 * (ushort3)b.c3.zzz));
        }

        /// <summary>		Returns the byte3 column vector result of a matrix multiplication between a byte3x4 matrix and a byte4 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 mul(byte3x4 a, byte4 b)
        {
            return (byte3)(((ushort3)a.c0 * (ushort3)b.xxx + (ushort3)a.c1 * (ushort3)b.yyy) + ((ushort3)a.c2 * (ushort3)b.zzz + (ushort3)a.c3 * (ushort3)b.www));
        }

        /// <summary>		Returns the byte3x2 matrix result of a matrix multiplication between a byte3x4 matrix and a byte4x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3x2 mul(byte3x4 a, byte4x2 b)
        {
            return new byte3x2(
                (byte3)(((ushort3)a.c0 * (ushort3)b.c0.xxx + (ushort3)a.c1 * (ushort3)b.c0.yyy) + ((ushort3)a.c2 * (ushort3)b.c0.zzz + (ushort3)a.c3 * (ushort3)b.c0.www)),
                (byte3)(((ushort3)a.c0 * (ushort3)b.c1.xxx + (ushort3)a.c1 * (ushort3)b.c1.yyy) + ((ushort3)a.c2 * (ushort3)b.c1.zzz + (ushort3)a.c3 * (ushort3)b.c1.www)));
        }

        /// <summary>		Returns the byte3x3 matrix result of a matrix multiplication between a byte3x4 matrix and a byte4x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3x3 mul(byte3x4 a, byte4x3 b)
        {
            return new byte3x3(
                (byte3)(((ushort3)a.c0 * (ushort3)b.c0.xxx + (ushort3)a.c1 * (ushort3)b.c0.yyy) + ((ushort3)a.c2 * (ushort3)b.c0.zzz + (ushort3)a.c3 * (ushort3)b.c0.www)),
                (byte3)(((ushort3)a.c0 * (ushort3)b.c1.xxx + (ushort3)a.c1 * (ushort3)b.c1.yyy) + ((ushort3)a.c2 * (ushort3)b.c1.zzz + (ushort3)a.c3 * (ushort3)b.c1.www)),
                (byte3)(((ushort3)a.c0 * (ushort3)b.c2.xxx + (ushort3)a.c1 * (ushort3)b.c2.yyy) + ((ushort3)a.c2 * (ushort3)b.c2.zzz + (ushort3)a.c3 * (ushort3)b.c2.www)));
        }

        /// <summary>		Returns the byte3x4 matrix result of a matrix multiplication between a byte3x4 matrix and a byte4x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3x4 mul(byte3x4 a, byte4x4 b)
        {
            return new byte3x4(
                (byte3)(((ushort3)a.c0 * (ushort3)b.c0.xxx + (ushort3)a.c1 * (ushort3)b.c0.yyy) + ((ushort3)a.c2 * (ushort3)b.c0.zzz + (ushort3)a.c3 * (ushort3)b.c0.www)),
                (byte3)(((ushort3)a.c0 * (ushort3)b.c1.xxx + (ushort3)a.c1 * (ushort3)b.c1.yyy) + ((ushort3)a.c2 * (ushort3)b.c1.zzz + (ushort3)a.c3 * (ushort3)b.c1.www)),
                (byte3)(((ushort3)a.c0 * (ushort3)b.c2.xxx + (ushort3)a.c1 * (ushort3)b.c2.yyy) + ((ushort3)a.c2 * (ushort3)b.c2.zzz + (ushort3)a.c3 * (ushort3)b.c2.www)),
                (byte3)(((ushort3)a.c0 * (ushort3)b.c3.xxx + (ushort3)a.c1 * (ushort3)b.c3.yyy) + ((ushort3)a.c2 * (ushort3)b.c3.zzz + (ushort3)a.c3 * (ushort3)b.c3.www)));
        }

        /// <summary>		Returns the byte4 column vector result of a matrix multiplication between a byte4x2 matrix and a byte2 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 mul(byte4x2 a, byte2 b)
        {
            return (byte4)((ushort4)a.c0 * (ushort4)b.xxxx + (ushort4)a.c1 * (ushort4)b.yyyy);
        }

        /// <summary>		Returns the byte4x2 matrix result of a matrix multiplication between a byte4x2 matrix and a byte2x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4x2 mul(byte4x2 a, byte2x2 b)
        {
            return new byte4x2(
                (byte4)((ushort4)a.c0 * (ushort4)b.c0.xxxx + (ushort4)a.c1 * (ushort4)b.c0.yyyy),
                (byte4)((ushort4)a.c0 * (ushort4)b.c1.xxxx + (ushort4)a.c1 * (ushort4)b.c1.yyyy));
        }

        /// <summary>		Returns the byte4x3 matrix result of a matrix multiplication between a byte4x2 matrix and a byte2x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4x3 mul(byte4x2 a, byte2x3 b)
        {
            return new byte4x3(
                (byte4)((ushort4)a.c0 * (ushort4)b.c0.xxxx + (ushort4)a.c1 * (ushort4)b.c0.yyyy),
                (byte4)((ushort4)a.c0 * (ushort4)b.c1.xxxx + (ushort4)a.c1 * (ushort4)b.c1.yyyy),
                (byte4)((ushort4)a.c0 * (ushort4)b.c2.xxxx + (ushort4)a.c1 * (ushort4)b.c2.yyyy));
        }

        /// <summary>		Returns the byte4x4 matrix result of a matrix multiplication between a byte4x2 matrix and a byte2x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4x4 mul(byte4x2 a, byte2x4 b)
        {
            return new byte4x4(
                (byte4)((ushort4)a.c0 * (ushort4)b.c0.xxxx + (ushort4)a.c1 * (ushort4)b.c0.yyyy),
                (byte4)((ushort4)a.c0 * (ushort4)b.c1.xxxx + (ushort4)a.c1 * (ushort4)b.c1.yyyy),
                (byte4)((ushort4)a.c0 * (ushort4)b.c2.xxxx + (ushort4)a.c1 * (ushort4)b.c2.yyyy),
                (byte4)((ushort4)a.c0 * (ushort4)b.c3.xxxx + (ushort4)a.c1 * (ushort4)b.c3.yyyy));
        }

        /// <summary>		Returns the byte4 column vector result of a matrix multiplication between a byte4x3 matrix and a byte3 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 mul(byte4x3 a, byte3 b)
        {
            return (byte4)((ushort4)a.c0 * (ushort4)b.xxxx + (ushort4)a.c1 * (ushort4)b.yyyy + (ushort4)a.c2 * (ushort4)b.zzzz);
        }

        /// <summary>		Returns the byte4x2 matrix result of a matrix multiplication between a byte4x3 matrix and a byte3x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4x2 mul(byte4x3 a, byte3x2 b)
        {
            return new byte4x2(
                (byte4)((ushort4)a.c0 * (ushort4)b.c0.xxxx + (ushort4)a.c1 * (ushort4)b.c0.yyyy + (ushort4)a.c2 * (ushort4)b.c0.zzzz),
                (byte4)((ushort4)a.c0 * (ushort4)b.c1.xxxx + (ushort4)a.c1 * (ushort4)b.c1.yyyy + (ushort4)a.c2 * (ushort4)b.c1.zzzz));
        }

        /// <summary>		Returns the byte4x3 matrix result of a matrix multiplication between a byte4x3 matrix and a byte3x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4x3 mul(byte4x3 a, byte3x3 b)
        {
            return new byte4x3(
                (byte4)((ushort4)a.c0 * (ushort4)b.c0.xxxx + (ushort4)a.c1 * (ushort4)b.c0.yyyy + (ushort4)a.c2 * (ushort4)b.c0.zzzz),
                (byte4)((ushort4)a.c0 * (ushort4)b.c1.xxxx + (ushort4)a.c1 * (ushort4)b.c1.yyyy + (ushort4)a.c2 * (ushort4)b.c1.zzzz),
                (byte4)((ushort4)a.c0 * (ushort4)b.c2.xxxx + (ushort4)a.c1 * (ushort4)b.c2.yyyy + (ushort4)a.c2 * (ushort4)b.c2.zzzz));
        }

        /// <summary>		Returns the byte4x4 matrix result of a matrix multiplication between a byte4x3 matrix and a byte3x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4x4 mul(byte4x3 a, byte3x4 b)
        {
            return new byte4x4(
                (byte4)((ushort4)a.c0 * (ushort4)b.c0.xxxx + (ushort4)a.c1 * (ushort4)b.c0.yyyy + (ushort4)a.c2 * (ushort4)b.c0.zzzz),
                (byte4)((ushort4)a.c0 * (ushort4)b.c1.xxxx + (ushort4)a.c1 * (ushort4)b.c1.yyyy + (ushort4)a.c2 * (ushort4)b.c1.zzzz),
                (byte4)((ushort4)a.c0 * (ushort4)b.c2.xxxx + (ushort4)a.c1 * (ushort4)b.c2.yyyy + (ushort4)a.c2 * (ushort4)b.c2.zzzz),
                (byte4)((ushort4)a.c0 * (ushort4)b.c3.xxxx + (ushort4)a.c1 * (ushort4)b.c3.yyyy + (ushort4)a.c2 * (ushort4)b.c3.zzzz));
        }

        /// <summary>		Returns the byte4 column vector result of a matrix multiplication between a byte4x4 matrix and a byte4 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 mul(byte4x4 a, byte4 b)
        {
            return (byte4)(((ushort4)a.c0 * (ushort4)b.xxxx + (ushort4)a.c1 * (ushort4)b.yyyy) + ((ushort4)a.c2 * (ushort4)b.zzzz + (ushort4)a.c3 * (ushort4)b.wwww));
        }

        /// <summary>		Returns the byte4x2 matrix result of a matrix multiplication between a byte4x4 matrix and a byte4x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4x2 mul(byte4x4 a, byte4x2 b)
        {
            return new byte4x2(
                (byte4)(((ushort4)a.c0 * (ushort4)b.c0.xxxx + (ushort4)a.c1 * (ushort4)b.c0.yyyy) + ((ushort4)a.c2 * (ushort4)b.c0.zzzz + (ushort4)a.c3 * (ushort4)b.c0.wwww)),
                (byte4)(((ushort4)a.c0 * (ushort4)b.c1.xxxx + (ushort4)a.c1 * (ushort4)b.c1.yyyy) + ((ushort4)a.c2 * (ushort4)b.c1.zzzz + (ushort4)a.c3 * (ushort4)b.c1.wwww)));
        }

        /// <summary>		Returns the byte4x3 matrix result of a matrix multiplication between a byte4x4 matrix and a byte4x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4x3 mul(byte4x4 a, byte4x3 b)
        {
            return new byte4x3(
                (byte4)(((ushort4)a.c0 * (ushort4)b.c0.xxxx + (ushort4)a.c1 * (ushort4)b.c0.yyyy) + ((ushort4)a.c2 * (ushort4)b.c0.zzzz + (ushort4)a.c3 * (ushort4)b.c0.wwww)),
                (byte4)(((ushort4)a.c0 * (ushort4)b.c1.xxxx + (ushort4)a.c1 * (ushort4)b.c1.yyyy) + ((ushort4)a.c2 * (ushort4)b.c1.zzzz + (ushort4)a.c3 * (ushort4)b.c1.wwww)),
                (byte4)(((ushort4)a.c0 * (ushort4)b.c2.xxxx + (ushort4)a.c1 * (ushort4)b.c2.yyyy) + ((ushort4)a.c2 * (ushort4)b.c2.zzzz + (ushort4)a.c3 * (ushort4)b.c2.wwww)));
        }

        /// <summary>		Returns the byte4x4 matrix result of a matrix multiplication between a byte4x4 matrix and a byte4x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4x4 mul(byte4x4 a, byte4x4 b)
        {
            return new byte4x4(
                (byte4)(((ushort4)a.c0 * (ushort4)b.c0.xxxx + (ushort4)a.c1 * (ushort4)b.c0.yyyy) + ((ushort4)a.c2 * (ushort4)b.c0.zzzz + (ushort4)a.c3 * (ushort4)b.c0.wwww)),
                (byte4)(((ushort4)a.c0 * (ushort4)b.c1.xxxx + (ushort4)a.c1 * (ushort4)b.c1.yyyy) + ((ushort4)a.c2 * (ushort4)b.c1.zzzz + (ushort4)a.c3 * (ushort4)b.c1.wwww)),
                (byte4)(((ushort4)a.c0 * (ushort4)b.c2.xxxx + (ushort4)a.c1 * (ushort4)b.c2.yyyy) + ((ushort4)a.c2 * (ushort4)b.c2.zzzz + (ushort4)a.c3 * (ushort4)b.c2.wwww)),
                (byte4)(((ushort4)a.c0 * (ushort4)b.c3.xxxx + (ushort4)a.c1 * (ushort4)b.c3.yyyy) + ((ushort4)a.c2 * (ushort4)b.c3.zzzz + (ushort4)a.c3 * (ushort4)b.c3.wwww)));
        }
    }
}