using System.Runtime.CompilerServices;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>		Returns the <see cref="long"/> result of a matrix multiplication between a <see cref="MaxMath.long2"/> row vector and a <see cref="MaxMath.long2"/> column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long mul(long2 a, long2 b)
        {
            return dot(a, b);
        }

        /// <summary>		Returns the <see cref="MaxMath.long2"/> row vector result of a matrix multiplication between a <see cref="MaxMath.long2"/> row vector and a <see cref="MaxMath.long2x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 mul(long2 a, long2x2 b)
        {
            return new long2(dot(a, b.c0), dot(a, b.c1));
        }

        /// <summary>		Returns the <see cref="MaxMath.long3"/> row vector result of a matrix multiplication between a <see cref="MaxMath.long2"/> row vector and a <see cref="MaxMath.long2x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 mul(long2 a, long2x3 b)
        {
            return new long3(dot(a, b.c0), dot(a, b.c1), dot(a, b.c2));
        }

        /// <summary>		Returns the <see cref="MaxMath.long4"/> row vector result of a matrix multiplication between a <see cref="MaxMath.long2"/> row vector and a <see cref="MaxMath.long2x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 mul(long2 a, long2x4 b)
        {
            return new long4(dot(a, b.c0), dot(a, b.c1), dot(a, b.c2), dot(a, b.c3));
        }

        /// <summary>		Returns the <see cref="long"/> result of a matrix multiplication between a <see cref="MaxMath.long3"/> row vector and a <see cref="MaxMath.long3"/> column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long mul(long3 a, long3 b)
        {
            return dot(a, b);
        }

        /// <summary>		Returns the <see cref="MaxMath.long2"/> row vector result of a matrix multiplication between a <see cref="MaxMath.long3"/> row vector and a <see cref="MaxMath.long3x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 mul(long3 a, long3x2 b)
        {
            return new long2(dot(a, b.c0), dot(a, b.c1));
        }

        /// <summary>		Returns the <see cref="MaxMath.long3"/> row vector result of a matrix multiplication between a <see cref="MaxMath.long3"/> row vector and a <see cref="MaxMath.long3x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 mul(long3 a, long3x3 b)
        {
            return new long3(dot(a, b.c0), dot(a, b.c1), dot(a, b.c2));
        }

        /// <summary>		Returns the <see cref="MaxMath.long4"/> row vector result of a matrix multiplication between a <see cref="MaxMath.long3"/> row vector and a <see cref="MaxMath.long3x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 mul(long3 a, long3x4 b)
        {
            return new long4(dot(a, b.c0), dot(a, b.c1), dot(a, b.c2), dot(a, b.c3));
        }

        /// <summary>		Returns the <see cref="long"/> result of a matrix multiplication between a <see cref="MaxMath.long4"/> row vector and a <see cref="MaxMath.long4"/> column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long mul(long4 a, long4 b)
        {
            return dot(a, b);
        }

        /// <summary>		Returns the <see cref="MaxMath.long2"/> row vector result of a matrix multiplication between a <see cref="MaxMath.long4"/> row vector and a <see cref="MaxMath.long4x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 mul(long4 a, long4x2 b)
        {
            return new long2(dot(a, b.c0), dot(a, b.c1));
        }

        /// <summary>		Returns the <see cref="MaxMath.long3"/> row vector result of a matrix multiplication between a <see cref="MaxMath.long4"/> row vector and a <see cref="MaxMath.long4x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 mul(long4 a, long4x3 b)
        {
            return new long3(dot(a, b.c0), dot(a, b.c1), dot(a, b.c2));
        }

        /// <summary>		Returns the <see cref="MaxMath.long4"/> row vector result of a matrix multiplication between a <see cref="MaxMath.long4"/> row vector and a <see cref="MaxMath.long4x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 mul(long4 a, long4x4 b)
        {
            return new long4(dot(a, b.c0), dot(a, b.c1), dot(a, b.c2), dot(a, b.c3));
        }

        /// <summary>		Returns the <see cref="MaxMath.long2"/> column vector result of a matrix multiplication between a <see cref="MaxMath.long2x2"/> and a <see cref="MaxMath.long2"/> column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 mul(long2x2 a, long2 b)
        {
            return a.c0 * b.xx + a.c1 * b.yy;
        }

        /// <summary>		Returns the <see cref="MaxMath.long2x2"/> result of a matrix multiplication between a <see cref="MaxMath.long2x2"/> and a <see cref="MaxMath.long2x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 mul(long2x2 a, long2x2 b)
        {
            return new long2x2(
                a.c0 * b.c0.xx + a.c1 * b.c0.yy,
                a.c0 * b.c1.xx + a.c1 * b.c1.yy);
        }

        /// <summary>		Returns the <see cref="MaxMath.long2x3"/> result of a matrix multiplication between a <see cref="MaxMath.long2x2"/> and a <see cref="MaxMath.long2x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 mul(long2x2 a, long2x3 b)
        {
            return new long2x3(
                a.c0 * b.c0.xx + a.c1 * b.c0.yy,
                a.c0 * b.c1.xx + a.c1 * b.c1.yy,
                a.c0 * b.c2.xx + a.c1 * b.c2.yy);
        }

        /// <summary>		Returns the <see cref="MaxMath.long2x4"/> result of a matrix multiplication between a <see cref="MaxMath.long2x2"/> and a <see cref="MaxMath.long2x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 mul(long2x2 a, long2x4 b)
        {
            return new long2x4(
                a.c0 * b.c0.xx + a.c1 * b.c0.yy,
                a.c0 * b.c1.xx + a.c1 * b.c1.yy,
                a.c0 * b.c2.xx + a.c1 * b.c2.yy,
                a.c0 * b.c3.xx + a.c1 * b.c3.yy);
        }

        /// <summary>		Returns the <see cref="MaxMath.long2"/> column vector result of a matrix multiplication between a <see cref="MaxMath.long2x3"/> and a <see cref="MaxMath.long3"/> column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 mul(long2x3 a, long3 b)
        {
            return a.c0 * b.xx + a.c1 * b.yy + a.c2 * b.zz;
        }

        /// <summary>		Returns the <see cref="MaxMath.long2x2"/> result of a matrix multiplication between a <see cref="MaxMath.long2x3"/> and a <see cref="MaxMath.long3x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 mul(long2x3 a, long3x2 b)
        {
            return new long2x2(
                a.c0 * b.c0.xx + a.c1 * b.c0.yy + a.c2 * b.c0.zz,
                a.c0 * b.c1.xx + a.c1 * b.c1.yy + a.c2 * b.c1.zz);
        }

        /// <summary>		Returns the <see cref="MaxMath.long2x3"/> result of a matrix multiplication between a <see cref="MaxMath.long2x3"/> and a <see cref="MaxMath.long3x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 mul(long2x3 a, long3x3 b)
        {
            return new long2x3(
                a.c0 * b.c0.xx + a.c1 * b.c0.yy + a.c2 * b.c0.zz,
                a.c0 * b.c1.xx + a.c1 * b.c1.yy + a.c2 * b.c1.zz,
                a.c0 * b.c2.xx + a.c1 * b.c2.yy + a.c2 * b.c2.zz);
        }

        /// <summary>		Returns the <see cref="MaxMath.long2x4"/> result of a matrix multiplication between a <see cref="MaxMath.long2x3"/> and a <see cref="MaxMath.long3x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 mul(long2x3 a, long3x4 b)
        {
            return new long2x4(
                a.c0 * b.c0.xx + a.c1 * b.c0.yy + a.c2 * b.c0.zz,
                a.c0 * b.c1.xx + a.c1 * b.c1.yy + a.c2 * b.c1.zz,
                a.c0 * b.c2.xx + a.c1 * b.c2.yy + a.c2 * b.c2.zz,
                a.c0 * b.c3.xx + a.c1 * b.c3.yy + a.c2 * b.c3.zz);
        }

        /// <summary>		Returns the <see cref="MaxMath.long2"/> column vector result of a matrix multiplication between a <see cref="MaxMath.long2x4"/> and a <see cref="MaxMath.long4"/> column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 mul(long2x4 a, long4 b)
        {
            return a.c0 * b.xx + a.c1 * b.yy + a.c2 * b.zz + a.c3 * b.ww;
        }

        /// <summary>		Returns the <see cref="MaxMath.long2x2"/> result of a matrix multiplication between a <see cref="MaxMath.long2x4"/> and a <see cref="MaxMath.long4x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 mul(long2x4 a, long4x2 b)
        {
            return new long2x2(
                (a.c0 * b.c0.xx + a.c1 * b.c0.yy) + (a.c2 * b.c0.zz + a.c3 * b.c0.ww),
                (a.c0 * b.c1.xx + a.c1 * b.c1.yy) + (a.c2 * b.c1.zz + a.c3 * b.c1.ww));
        }

        /// <summary>		Returns the <see cref="MaxMath.long2x3"/> result of a matrix multiplication between a <see cref="MaxMath.long2x4"/> and a <see cref="MaxMath.long4x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 mul(long2x4 a, long4x3 b)
        {
            return new long2x3(
                (a.c0 * b.c0.xx + a.c1 * b.c0.yy) + (a.c2 * b.c0.zz + a.c3 * b.c0.ww),
                (a.c0 * b.c1.xx + a.c1 * b.c1.yy) + (a.c2 * b.c1.zz + a.c3 * b.c1.ww),
                (a.c0 * b.c2.xx + a.c1 * b.c2.yy) + (a.c2 * b.c2.zz + a.c3 * b.c2.ww));
        }

        /// <summary>		Returns the <see cref="MaxMath.long2x4"/> result of a matrix multiplication between a <see cref="MaxMath.long2x4"/> and a <see cref="MaxMath.long4x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 mul(long2x4 a, long4x4 b)
        {
            return new long2x4(
                (a.c0 * b.c0.xx + a.c1 * b.c0.yy) + (a.c2 * b.c0.zz + a.c3 * b.c0.ww),
                (a.c0 * b.c1.xx + a.c1 * b.c1.yy) + (a.c2 * b.c1.zz + a.c3 * b.c1.ww),
                (a.c0 * b.c2.xx + a.c1 * b.c2.yy) + (a.c2 * b.c2.zz + a.c3 * b.c2.ww),
                (a.c0 * b.c3.xx + a.c1 * b.c3.yy) + (a.c2 * b.c3.zz + a.c3 * b.c3.ww));
        }

        /// <summary>		Returns the <see cref="MaxMath.long3"/> column vector result of a matrix multiplication between a <see cref="MaxMath.long3x2"/> and a <see cref="MaxMath.long2"/> column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 mul(long3x2 a, long2 b)
        {
            return a.c0 * b.xxx + a.c1 * b.yyy;
        }

        /// <summary>		Returns the <see cref="MaxMath.long3x2"/> result of a matrix multiplication between a <see cref="MaxMath.long3x2"/> and a <see cref="MaxMath.long2x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 mul(long3x2 a, long2x2 b)
        {
            return new long3x2(
                a.c0 * b.c0.xxx + a.c1 * b.c0.yyy,
                a.c0 * b.c1.xxx + a.c1 * b.c1.yyy);
        }

        /// <summary>		Returns the <see cref="MaxMath.long3x3"/> result of a matrix multiplication between a <see cref="MaxMath.long3x2"/> and a <see cref="MaxMath.long2x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x3 mul(long3x2 a, long2x3 b)
        {
            return new long3x3(
                a.c0 * b.c0.xxx + a.c1 * b.c0.yyy,
                a.c0 * b.c1.xxx + a.c1 * b.c1.yyy,
                a.c0 * b.c2.xxx + a.c1 * b.c2.yyy);
        }

        /// <summary>		Returns the <see cref="MaxMath.long3x4"/> result of a matrix multiplication between a <see cref="MaxMath.long3x2"/> and a <see cref="MaxMath.long2x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x4 mul(long3x2 a, long2x4 b)
        {
            return new long3x4(
                a.c0 * b.c0.xxx + a.c1 * b.c0.yyy,
                a.c0 * b.c1.xxx + a.c1 * b.c1.yyy,
                a.c0 * b.c2.xxx + a.c1 * b.c2.yyy,
                a.c0 * b.c3.xxx + a.c1 * b.c3.yyy);
        }

        /// <summary>		Returns the <see cref="MaxMath.long3"/> column vector result of a matrix multiplication between a <see cref="MaxMath.long3x3"/> and a <see cref="MaxMath.long3"/> column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 mul(long3x3 a, long3 b)
        {
            return a.c0 * b.xxx + a.c1 * b.yyy + a.c2 * b.zzz;
        }

        /// <summary>		Returns the <see cref="MaxMath.long3x2"/> result of a matrix multiplication between a <see cref="MaxMath.long3x3"/> and a <see cref="MaxMath.long3x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 mul(long3x3 a, long3x2 b)
        {
            return new long3x2(
                a.c0 * b.c0.xxx + a.c1 * b.c0.yyy + a.c2 * b.c0.zzz,
                a.c0 * b.c1.xxx + a.c1 * b.c1.yyy + a.c2 * b.c1.zzz);
        }

        /// <summary>		Returns the <see cref="MaxMath.long3x3"/> result of a matrix multiplication between a <see cref="MaxMath.long3x3"/> and a <see cref="MaxMath.long3x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x3 mul(long3x3 a, long3x3 b)
        {
            return new long3x3(
                a.c0 * b.c0.xxx + a.c1 * b.c0.yyy + a.c2 * b.c0.zzz,
                a.c0 * b.c1.xxx + a.c1 * b.c1.yyy + a.c2 * b.c1.zzz,
                a.c0 * b.c2.xxx + a.c1 * b.c2.yyy + a.c2 * b.c2.zzz);
        }

        /// <summary>		Returns the <see cref="MaxMath.long3x4"/> result of a matrix multiplication between a <see cref="MaxMath.long3x3"/> and a <see cref="MaxMath.long3x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x4 mul(long3x3 a, long3x4 b)
        {
            return new long3x4(
                a.c0 * b.c0.xxx + a.c1 * b.c0.yyy + a.c2 * b.c0.zzz,
                a.c0 * b.c1.xxx + a.c1 * b.c1.yyy + a.c2 * b.c1.zzz,
                a.c0 * b.c2.xxx + a.c1 * b.c2.yyy + a.c2 * b.c2.zzz,
                a.c0 * b.c3.xxx + a.c1 * b.c3.yyy + a.c2 * b.c3.zzz);
        }

        /// <summary>		Returns the <see cref="MaxMath.long3"/> column vector result of a matrix multiplication between a <see cref="MaxMath.long3x4"/> and a <see cref="MaxMath.long4"/> column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 mul(long3x4 a, long4 b)
        {
            return a.c0 * b.xxx + a.c1 * b.yyy + a.c2 * b.zzz + a.c3 * b.www;
        }

        /// <summary>		Returns the <see cref="MaxMath.long3x2"/> result of a matrix multiplication between a <see cref="MaxMath.long3x4"/> and a <see cref="MaxMath.long4x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 mul(long3x4 a, long4x2 b)
        {
            return new long3x2(
                (a.c0 * b.c0.xxx + a.c1 * b.c0.yyy) + (a.c2 * b.c0.zzz + a.c3 * b.c0.www),
                (a.c0 * b.c1.xxx + a.c1 * b.c1.yyy) + (a.c2 * b.c1.zzz + a.c3 * b.c1.www));
        }

        /// <summary>		Returns the <see cref="MaxMath.long3x3"/> result of a matrix multiplication between a <see cref="MaxMath.long3x4"/> and a <see cref="MaxMath.long4x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x3 mul(long3x4 a, long4x3 b)
        {
            return new long3x3(
                (a.c0 * b.c0.xxx + a.c1 * b.c0.yyy) + (a.c2 * b.c0.zzz + a.c3 * b.c0.www),
                (a.c0 * b.c1.xxx + a.c1 * b.c1.yyy) + (a.c2 * b.c1.zzz + a.c3 * b.c1.www),
                (a.c0 * b.c2.xxx + a.c1 * b.c2.yyy) + (a.c2 * b.c2.zzz + a.c3 * b.c2.www));
        }

        /// <summary>		Returns the <see cref="MaxMath.long3x4"/> result of a matrix multiplication between a <see cref="MaxMath.long3x4"/> and a <see cref="MaxMath.long4x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x4 mul(long3x4 a, long4x4 b)
        {
            return new long3x4(
                (a.c0 * b.c0.xxx + a.c1 * b.c0.yyy) + (a.c2 * b.c0.zzz + a.c3 * b.c0.www),
                (a.c0 * b.c1.xxx + a.c1 * b.c1.yyy) + (a.c2 * b.c1.zzz + a.c3 * b.c1.www),
                (a.c0 * b.c2.xxx + a.c1 * b.c2.yyy) + (a.c2 * b.c2.zzz + a.c3 * b.c2.www),
                (a.c0 * b.c3.xxx + a.c1 * b.c3.yyy) + (a.c2 * b.c3.zzz + a.c3 * b.c3.www));
        }

        /// <summary>		Returns the <see cref="MaxMath.long4"/> column vector result of a matrix multiplication between a <see cref="MaxMath.long4x2"/> and a <see cref="MaxMath.long2"/> column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 mul(long4x2 a, long2 b)
        {
            return a.c0 * b.xxxx + a.c1 * b.yyyy;
        }

        /// <summary>		Returns the <see cref="MaxMath.long4x2"/> result of a matrix multiplication between a <see cref="MaxMath.long4x2"/> and a <see cref="MaxMath.long2x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 mul(long4x2 a, long2x2 b)
        {
            return new long4x2(
                a.c0 * b.c0.xxxx + a.c1 * b.c0.yyyy,
                a.c0 * b.c1.xxxx + a.c1 * b.c1.yyyy);
        }

        /// <summary>		Returns the <see cref="MaxMath.long4x3"/> result of a matrix multiplication between a <see cref="MaxMath.long4x2"/> and a <see cref="MaxMath.long2x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x3 mul(long4x2 a, long2x3 b)
        {
            return new long4x3(
                a.c0 * b.c0.xxxx + a.c1 * b.c0.yyyy,
                a.c0 * b.c1.xxxx + a.c1 * b.c1.yyyy,
                a.c0 * b.c2.xxxx + a.c1 * b.c2.yyyy);
        }

        /// <summary>		Returns the <see cref="MaxMath.long4x4"/> result of a matrix multiplication between a <see cref="MaxMath.long4x2"/> and a <see cref="MaxMath.long2x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x4 mul(long4x2 a, long2x4 b)
        {
            return new long4x4(
                a.c0 * b.c0.xxxx + a.c1 * b.c0.yyyy,
                a.c0 * b.c1.xxxx + a.c1 * b.c1.yyyy,
                a.c0 * b.c2.xxxx + a.c1 * b.c2.yyyy,
                a.c0 * b.c3.xxxx + a.c1 * b.c3.yyyy);
        }

        /// <summary>		Returns the <see cref="MaxMath.long4"/> column vector result of a matrix multiplication between a <see cref="MaxMath.long4x3"/> and a <see cref="MaxMath.long3"/> column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 mul(long4x3 a, long3 b)
        {
            return a.c0 * b.xxxx + a.c1 * b.yyyy + a.c2 * b.zzzz;
        }

        /// <summary>		Returns the <see cref="MaxMath.long4x2"/> result of a matrix multiplication between a <see cref="MaxMath.long4x3"/> and a <see cref="MaxMath.long3x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 mul(long4x3 a, long3x2 b)
        {
            return new long4x2(
                a.c0 * b.c0.xxxx + a.c1 * b.c0.yyyy + a.c2 * b.c0.zzzz,
                a.c0 * b.c1.xxxx + a.c1 * b.c1.yyyy + a.c2 * b.c1.zzzz);
        }

        /// <summary>		Returns the <see cref="MaxMath.long4x3"/> result of a matrix multiplication between a <see cref="MaxMath.long4x3"/> and a <see cref="MaxMath.long3x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x3 mul(long4x3 a, long3x3 b)
        {
            return new long4x3(
                a.c0 * b.c0.xxxx + a.c1 * b.c0.yyyy + a.c2 * b.c0.zzzz,
                a.c0 * b.c1.xxxx + a.c1 * b.c1.yyyy + a.c2 * b.c1.zzzz,
                a.c0 * b.c2.xxxx + a.c1 * b.c2.yyyy + a.c2 * b.c2.zzzz);
        }

        /// <summary>		Returns the <see cref="MaxMath.long4x4"/> result of a matrix multiplication between a <see cref="MaxMath.long4x3"/> and a <see cref="MaxMath.long3x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x4 mul(long4x3 a, long3x4 b)
        {
            return new long4x4(
                a.c0 * b.c0.xxxx + a.c1 * b.c0.yyyy + a.c2 * b.c0.zzzz,
                a.c0 * b.c1.xxxx + a.c1 * b.c1.yyyy + a.c2 * b.c1.zzzz,
                a.c0 * b.c2.xxxx + a.c1 * b.c2.yyyy + a.c2 * b.c2.zzzz,
                a.c0 * b.c3.xxxx + a.c1 * b.c3.yyyy + a.c2 * b.c3.zzzz);
        }

        /// <summary>		Returns the <see cref="MaxMath.long4"/> column vector result of a matrix multiplication between a <see cref="MaxMath.long4x4"/> and a <see cref="MaxMath.long4"/> column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 mul(long4x4 a, long4 b)
        {
            return a.c0 * b.xxxx + a.c1 * b.yyyy + a.c2 * b.zzzz + a.c3 * b.wwww;
        }

        /// <summary>		Returns the <see cref="MaxMath.long4x2"/> result of a matrix multiplication between a <see cref="MaxMath.long4x4"/> and a <see cref="MaxMath.long4x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 mul(long4x4 a, long4x2 b)
        {
            return new long4x2(
                (a.c0 * b.c0.xxxx + a.c1 * b.c0.yyyy) + (a.c2 * b.c0.zzzz + a.c3 * b.c0.wwww),
                (a.c0 * b.c1.xxxx + a.c1 * b.c1.yyyy) + (a.c2 * b.c1.zzzz + a.c3 * b.c1.wwww));
        }

        /// <summary>		Returns the <see cref="MaxMath.long4x3"/> result of a matrix multiplication between a <see cref="MaxMath.long4x4"/> and a <see cref="MaxMath.long4x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x3 mul(long4x4 a, long4x3 b)
        {
            return new long4x3(
                (a.c0 * b.c0.xxxx + a.c1 * b.c0.yyyy) + (a.c2 * b.c0.zzzz + a.c3 * b.c0.wwww),
                (a.c0 * b.c1.xxxx + a.c1 * b.c1.yyyy) + (a.c2 * b.c1.zzzz + a.c3 * b.c1.wwww),
                (a.c0 * b.c2.xxxx + a.c1 * b.c2.yyyy) + (a.c2 * b.c2.zzzz + a.c3 * b.c2.wwww));
        }

        /// <summary>		Returns the <see cref="MaxMath.long4x4"/> result of a matrix multiplication between a <see cref="MaxMath.long4x4"/> and a <see cref="MaxMath.long4x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x4 mul(long4x4 a, long4x4 b)
        {
            return new long4x4(
                (a.c0 * b.c0.xxxx + a.c1 * b.c0.yyyy) + (a.c2 * b.c0.zzzz + a.c3 * b.c0.wwww),
                (a.c0 * b.c1.xxxx + a.c1 * b.c1.yyyy) + (a.c2 * b.c1.zzzz + a.c3 * b.c1.wwww),
                (a.c0 * b.c2.xxxx + a.c1 * b.c2.yyyy) + (a.c2 * b.c2.zzzz + a.c3 * b.c2.wwww),
                (a.c0 * b.c3.xxxx + a.c1 * b.c3.yyyy) + (a.c2 * b.c3.zzzz + a.c3 * b.c3.wwww));
        }


        /// <summary>		Returns the <see cref="ulong"/> result of a matrix multiplication between a <see cref="MaxMath.ulong2"/> row vector and a <see cref="MaxMath.ulong2"/> column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong mul(ulong2 a, ulong2 b)
        {
            return dot(a, b);
        }

        /// <summary>		Returns the <see cref="MaxMath.ulong2"/> row vector result of a matrix multiplication between a <see cref="MaxMath.ulong2"/> row vector and a <see cref="MaxMath.ulong2x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 mul(ulong2 a, ulong2x2 b)
        {
            return new ulong2(dot(a, b.c0), dot(a, b.c1));
        }

        /// <summary>		Returns the <see cref="MaxMath.ulong3"/> row vector result of a matrix multiplication between a <see cref="MaxMath.ulong2"/> row vector and a <see cref="MaxMath.ulong2x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 mul(ulong2 a, ulong2x3 b)
        {
            return new ulong3(dot(a, b.c0), dot(a, b.c1), dot(a, b.c2));
        }

        /// <summary>		Returns the <see cref="MaxMath.ulong4"/> row vector result of a matrix multiplication between a <see cref="MaxMath.ulong2"/> row vector and a <see cref="MaxMath.ulong2x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 mul(ulong2 a, ulong2x4 b)
        {
            return new ulong4(dot(a, b.c0), dot(a, b.c1), dot(a, b.c2), dot(a, b.c3));
        }

        /// <summary>		Returns the <see cref="ulong"/> result of a matrix multiplication between a <see cref="MaxMath.ulong3"/> row vector and a <see cref="MaxMath.ulong3"/> column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong mul(ulong3 a, ulong3 b)
        {
            return dot(a, b);
        }

        /// <summary>		Returns the <see cref="MaxMath.ulong2"/> row vector result of a matrix multiplication between a <see cref="MaxMath.ulong3"/> row vector and a <see cref="MaxMath.ulong3x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 mul(ulong3 a, ulong3x2 b)
        {
            return new ulong2(dot(a, b.c0), dot(a, b.c1));
        }

        /// <summary>		Returns the <see cref="MaxMath.ulong3"/> row vector result of a matrix multiplication between a <see cref="MaxMath.ulong3"/> row vector and a <see cref="MaxMath.ulong3x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 mul(ulong3 a, ulong3x3 b)
        {
            return new ulong3(dot(a, b.c0), dot(a, b.c1), dot(a, b.c2));
        }

        /// <summary>		Returns the <see cref="MaxMath.ulong4"/> row vector result of a matrix multiplication between a <see cref="MaxMath.ulong3"/> row vector and a <see cref="MaxMath.ulong3x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 mul(ulong3 a, ulong3x4 b)
        {
            return new ulong4(dot(a, b.c0), dot(a, b.c1), dot(a, b.c2), dot(a, b.c3));
        }

        /// <summary>		Returns the <see cref="ulong"/> result of a matrix multiplication between a <see cref="MaxMath.ulong4"/> row vector and a <see cref="MaxMath.ulong4"/> column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong mul(ulong4 a, ulong4 b)
        {
            return dot(a, b);
        }

        /// <summary>		Returns the <see cref="MaxMath.ulong2"/> row vector result of a matrix multiplication between a <see cref="MaxMath.ulong4"/> row vector and a <see cref="MaxMath.ulong4x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 mul(ulong4 a, ulong4x2 b)
        {
            return new ulong2(dot(a, b.c0), dot(a, b.c1));
        }

        /// <summary>		Returns the <see cref="MaxMath.ulong3"/> row vector result of a matrix multiplication between a <see cref="MaxMath.ulong4"/> row vector and a <see cref="MaxMath.ulong4x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 mul(ulong4 a, ulong4x3 b)
        {
            return new ulong3(dot(a, b.c0), dot(a, b.c1), dot(a, b.c2));
        }

        /// <summary>		Returns the <see cref="MaxMath.ulong4"/> row vector result of a matrix multiplication between a <see cref="MaxMath.ulong4"/> row vector and a <see cref="MaxMath.ulong4x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 mul(ulong4 a, ulong4x4 b)
        {
            return new ulong4(dot(a, b.c0), dot(a, b.c1), dot(a, b.c2), dot(a, b.c3));
        }

        /// <summary>		Returns the <see cref="MaxMath.ulong2"/> column vector result of a matrix multiplication between a <see cref="MaxMath.ulong2x2"/> and a <see cref="MaxMath.ulong2"/> column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 mul(ulong2x2 a, ulong2 b)
        {
            return a.c0 * b.xx + a.c1 * b.yy;
        }

        /// <summary>		Returns the <see cref="MaxMath.ulong2x2"/> result of a matrix multiplication between a <see cref="MaxMath.ulong2x2"/> and a <see cref="MaxMath.ulong2x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x2 mul(ulong2x2 a, ulong2x2 b)
        {
            return new ulong2x2(
                a.c0 * b.c0.xx + a.c1 * b.c0.yy,
                a.c0 * b.c1.xx + a.c1 * b.c1.yy);
        }

        /// <summary>		Returns the <see cref="MaxMath.ulong2x3"/> result of a matrix multiplication between a <see cref="MaxMath.ulong2x2"/> and a <see cref="MaxMath.ulong2x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 mul(ulong2x2 a, ulong2x3 b)
        {
            return new ulong2x3(
                a.c0 * b.c0.xx + a.c1 * b.c0.yy,
                a.c0 * b.c1.xx + a.c1 * b.c1.yy,
                a.c0 * b.c2.xx + a.c1 * b.c2.yy);
        }

        /// <summary>		Returns the <see cref="MaxMath.ulong2x4"/> result of a matrix multiplication between a <see cref="MaxMath.ulong2x2"/> and a <see cref="MaxMath.ulong2x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x4 mul(ulong2x2 a, ulong2x4 b)
        {
            return new ulong2x4(
                a.c0 * b.c0.xx + a.c1 * b.c0.yy,
                a.c0 * b.c1.xx + a.c1 * b.c1.yy,
                a.c0 * b.c2.xx + a.c1 * b.c2.yy,
                a.c0 * b.c3.xx + a.c1 * b.c3.yy);
        }

        /// <summary>		Returns the <see cref="MaxMath.ulong2"/> column vector result of a matrix multiplication between a <see cref="MaxMath.ulong2x3"/> and a <see cref="MaxMath.ulong3"/> column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 mul(ulong2x3 a, ulong3 b)
        {
            return a.c0 * b.xx + a.c1 * b.yy + a.c2 * b.zz;
        }

        /// <summary>		Returns the <see cref="MaxMath.ulong2x2"/> result of a matrix multiplication between a <see cref="MaxMath.ulong2x3"/> and a <see cref="MaxMath.ulong3x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x2 mul(ulong2x3 a, ulong3x2 b)
        {
            return new ulong2x2(
                a.c0 * b.c0.xx + a.c1 * b.c0.yy + a.c2 * b.c0.zz,
                a.c0 * b.c1.xx + a.c1 * b.c1.yy + a.c2 * b.c1.zz);
        }

        /// <summary>		Returns the <see cref="MaxMath.ulong2x3"/> result of a matrix multiplication between a <see cref="MaxMath.ulong2x3"/> and a <see cref="MaxMath.ulong3x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 mul(ulong2x3 a, ulong3x3 b)
        {
            return new ulong2x3(
                a.c0 * b.c0.xx + a.c1 * b.c0.yy + a.c2 * b.c0.zz,
                a.c0 * b.c1.xx + a.c1 * b.c1.yy + a.c2 * b.c1.zz,
                a.c0 * b.c2.xx + a.c1 * b.c2.yy + a.c2 * b.c2.zz);
        }

        /// <summary>		Returns the <see cref="MaxMath.ulong2x4"/> result of a matrix multiplication between a <see cref="MaxMath.ulong2x3"/> and a <see cref="MaxMath.ulong3x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x4 mul(ulong2x3 a, ulong3x4 b)
        {
            return new ulong2x4(
                a.c0 * b.c0.xx + a.c1 * b.c0.yy + a.c2 * b.c0.zz,
                a.c0 * b.c1.xx + a.c1 * b.c1.yy + a.c2 * b.c1.zz,
                a.c0 * b.c2.xx + a.c1 * b.c2.yy + a.c2 * b.c2.zz,
                a.c0 * b.c3.xx + a.c1 * b.c3.yy + a.c2 * b.c3.zz);
        }

        /// <summary>		Returns the <see cref="MaxMath.ulong2"/> column vector result of a matrix multiplication between a <see cref="MaxMath.ulong2x4"/> and a <see cref="MaxMath.ulong4"/> column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 mul(ulong2x4 a, ulong4 b)
        {
            return a.c0 * b.xx + a.c1 * b.yy + a.c2 * b.zz + a.c3 * b.ww;
        }

        /// <summary>		Returns the <see cref="MaxMath.ulong2x2"/> result of a matrix multiplication between a <see cref="MaxMath.ulong2x4"/> and a <see cref="MaxMath.ulong4x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x2 mul(ulong2x4 a, ulong4x2 b)
        {
            return new ulong2x2(
                (a.c0 * b.c0.xx + a.c1 * b.c0.yy) + (a.c2 * b.c0.zz + a.c3 * b.c0.ww),
                (a.c0 * b.c1.xx + a.c1 * b.c1.yy) + (a.c2 * b.c1.zz + a.c3 * b.c1.ww));
        }

        /// <summary>		Returns the <see cref="MaxMath.ulong2x3"/> result of a matrix multiplication between a <see cref="MaxMath.ulong2x4"/> and a <see cref="MaxMath.ulong4x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 mul(ulong2x4 a, ulong4x3 b)
        {
            return new ulong2x3(
                (a.c0 * b.c0.xx + a.c1 * b.c0.yy) + (a.c2 * b.c0.zz + a.c3 * b.c0.ww),
                (a.c0 * b.c1.xx + a.c1 * b.c1.yy) + (a.c2 * b.c1.zz + a.c3 * b.c1.ww),
                (a.c0 * b.c2.xx + a.c1 * b.c2.yy) + (a.c2 * b.c2.zz + a.c3 * b.c2.ww));
        }

        /// <summary>		Returns the <see cref="MaxMath.ulong2x4"/> result of a matrix multiplication between a <see cref="MaxMath.ulong2x4"/> and a <see cref="MaxMath.ulong4x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x4 mul(ulong2x4 a, ulong4x4 b)
        {
            return new ulong2x4(
                (a.c0 * b.c0.xx + a.c1 * b.c0.yy) + (a.c2 * b.c0.zz + a.c3 * b.c0.ww),
                (a.c0 * b.c1.xx + a.c1 * b.c1.yy) + (a.c2 * b.c1.zz + a.c3 * b.c1.ww),
                (a.c0 * b.c2.xx + a.c1 * b.c2.yy) + (a.c2 * b.c2.zz + a.c3 * b.c2.ww),
                (a.c0 * b.c3.xx + a.c1 * b.c3.yy) + (a.c2 * b.c3.zz + a.c3 * b.c3.ww));
        }

        /// <summary>		Returns the <see cref="MaxMath.ulong3"/> column vector result of a matrix multiplication between a <see cref="MaxMath.ulong3x2"/> and a <see cref="MaxMath.ulong2"/> column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 mul(ulong3x2 a, ulong2 b)
        {
            return a.c0 * b.xxx + a.c1 * b.yyy;
        }

        /// <summary>		Returns the <see cref="MaxMath.ulong3x2"/> result of a matrix multiplication between a <see cref="MaxMath.ulong3x2"/> and a <see cref="MaxMath.ulong2x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 mul(ulong3x2 a, ulong2x2 b)
        {
            return new ulong3x2(
                a.c0 * b.c0.xxx + a.c1 * b.c0.yyy,
                a.c0 * b.c1.xxx + a.c1 * b.c1.yyy);
        }

        /// <summary>		Returns the <see cref="MaxMath.ulong3x3"/> result of a matrix multiplication between a <see cref="MaxMath.ulong3x2"/> and a <see cref="MaxMath.ulong2x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x3 mul(ulong3x2 a, ulong2x3 b)
        {
            return new ulong3x3(
                a.c0 * b.c0.xxx + a.c1 * b.c0.yyy,
                a.c0 * b.c1.xxx + a.c1 * b.c1.yyy,
                a.c0 * b.c2.xxx + a.c1 * b.c2.yyy);
        }

        /// <summary>		Returns the <see cref="MaxMath.ulong3x4"/> result of a matrix multiplication between a <see cref="MaxMath.ulong3x2"/> and a <see cref="MaxMath.ulong2x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 mul(ulong3x2 a, ulong2x4 b)
        {
            return new ulong3x4(
                a.c0 * b.c0.xxx + a.c1 * b.c0.yyy,
                a.c0 * b.c1.xxx + a.c1 * b.c1.yyy,
                a.c0 * b.c2.xxx + a.c1 * b.c2.yyy,
                a.c0 * b.c3.xxx + a.c1 * b.c3.yyy);
        }

        /// <summary>		Returns the <see cref="MaxMath.ulong3"/> column vector result of a matrix multiplication between a <see cref="MaxMath.ulong3x3"/> and a <see cref="MaxMath.ulong3"/> column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 mul(ulong3x3 a, ulong3 b)
        {
            return a.c0 * b.xxx + a.c1 * b.yyy + a.c2 * b.zzz;
        }

        /// <summary>		Returns the <see cref="MaxMath.ulong3x2"/> result of a matrix multiplication between a <see cref="MaxMath.ulong3x3"/> and a <see cref="MaxMath.ulong3x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 mul(ulong3x3 a, ulong3x2 b)
        {
            return new ulong3x2(
                a.c0 * b.c0.xxx + a.c1 * b.c0.yyy + a.c2 * b.c0.zzz,
                a.c0 * b.c1.xxx + a.c1 * b.c1.yyy + a.c2 * b.c1.zzz);
        }

        /// <summary>		Returns the <see cref="MaxMath.ulong3x3"/> result of a matrix multiplication between a <see cref="MaxMath.ulong3x3"/> and a <see cref="MaxMath.ulong3x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x3 mul(ulong3x3 a, ulong3x3 b)
        {
            return new ulong3x3(
                a.c0 * b.c0.xxx + a.c1 * b.c0.yyy + a.c2 * b.c0.zzz,
                a.c0 * b.c1.xxx + a.c1 * b.c1.yyy + a.c2 * b.c1.zzz,
                a.c0 * b.c2.xxx + a.c1 * b.c2.yyy + a.c2 * b.c2.zzz);
        }

        /// <summary>		Returns the <see cref="MaxMath.ulong3x4"/> result of a matrix multiplication between a <see cref="MaxMath.ulong3x3"/> and a <see cref="MaxMath.ulong3x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 mul(ulong3x3 a, ulong3x4 b)
        {
            return new ulong3x4(
                a.c0 * b.c0.xxx + a.c1 * b.c0.yyy + a.c2 * b.c0.zzz,
                a.c0 * b.c1.xxx + a.c1 * b.c1.yyy + a.c2 * b.c1.zzz,
                a.c0 * b.c2.xxx + a.c1 * b.c2.yyy + a.c2 * b.c2.zzz,
                a.c0 * b.c3.xxx + a.c1 * b.c3.yyy + a.c2 * b.c3.zzz);
        }

        /// <summary>		Returns the <see cref="MaxMath.ulong3"/> column vector result of a matrix multiplication between a <see cref="MaxMath.ulong3x4"/> and a <see cref="MaxMath.ulong4"/> column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 mul(ulong3x4 a, ulong4 b)
        {
            return a.c0 * b.xxx + a.c1 * b.yyy + a.c2 * b.zzz + a.c3 * b.www;
        }

        /// <summary>		Returns the <see cref="MaxMath.ulong3x2"/> result of a matrix multiplication between a <see cref="MaxMath.ulong3x4"/> and a <see cref="MaxMath.ulong4x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 mul(ulong3x4 a, ulong4x2 b)
        {
            return new ulong3x2(
                (a.c0 * b.c0.xxx + a.c1 * b.c0.yyy) + (a.c2 * b.c0.zzz + a.c3 * b.c0.www),
                (a.c0 * b.c1.xxx + a.c1 * b.c1.yyy) + (a.c2 * b.c1.zzz + a.c3 * b.c1.www));
        }

        /// <summary>		Returns the <see cref="MaxMath.ulong3x3"/> result of a matrix multiplication between a <see cref="MaxMath.ulong3x4"/> and a <see cref="MaxMath.ulong4x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x3 mul(ulong3x4 a, ulong4x3 b)
        {
            return new ulong3x3(
                (a.c0 * b.c0.xxx + a.c1 * b.c0.yyy) + (a.c2 * b.c0.zzz + a.c3 * b.c0.www),
                (a.c0 * b.c1.xxx + a.c1 * b.c1.yyy) + (a.c2 * b.c1.zzz + a.c3 * b.c1.www),
                (a.c0 * b.c2.xxx + a.c1 * b.c2.yyy) + (a.c2 * b.c2.zzz + a.c3 * b.c2.www));
        }

        /// <summary>		Returns the <see cref="MaxMath.ulong3x4"/> result of a matrix multiplication between a <see cref="MaxMath.ulong3x4"/> and a <see cref="MaxMath.ulong4x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 mul(ulong3x4 a, ulong4x4 b)
        {
            return new ulong3x4(
                (a.c0 * b.c0.xxx + a.c1 * b.c0.yyy) + (a.c2 * b.c0.zzz + a.c3 * b.c0.www),
                (a.c0 * b.c1.xxx + a.c1 * b.c1.yyy) + (a.c2 * b.c1.zzz + a.c3 * b.c1.www),
                (a.c0 * b.c2.xxx + a.c1 * b.c2.yyy) + (a.c2 * b.c2.zzz + a.c3 * b.c2.www),
                (a.c0 * b.c3.xxx + a.c1 * b.c3.yyy) + (a.c2 * b.c3.zzz + a.c3 * b.c3.www));
        }

        /// <summary>		Returns the <see cref="MaxMath.ulong4"/> column vector result of a matrix multiplication between a <see cref="MaxMath.ulong4x2"/> and a <see cref="MaxMath.ulong2"/> column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 mul(ulong4x2 a, ulong2 b)
        {
            return a.c0 * b.xxxx + a.c1 * b.yyyy;
        }

        /// <summary>		Returns the <see cref="MaxMath.ulong4x2"/> result of a matrix multiplication between a <see cref="MaxMath.ulong4x2"/> and a <see cref="MaxMath.ulong2x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x2 mul(ulong4x2 a, ulong2x2 b)
        {
            return new ulong4x2(
                a.c0 * b.c0.xxxx + a.c1 * b.c0.yyyy,
                a.c0 * b.c1.xxxx + a.c1 * b.c1.yyyy);
        }

        /// <summary>		Returns the <see cref="MaxMath.ulong4x3"/> result of a matrix multiplication between a <see cref="MaxMath.ulong4x2"/> and a <see cref="MaxMath.ulong2x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x3 mul(ulong4x2 a, ulong2x3 b)
        {
            return new ulong4x3(
                a.c0 * b.c0.xxxx + a.c1 * b.c0.yyyy,
                a.c0 * b.c1.xxxx + a.c1 * b.c1.yyyy,
                a.c0 * b.c2.xxxx + a.c1 * b.c2.yyyy);
        }

        /// <summary>		Returns the <see cref="MaxMath.ulong4x4"/> result of a matrix multiplication between a <see cref="MaxMath.ulong4x2"/> and a <see cref="MaxMath.ulong2x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 mul(ulong4x2 a, ulong2x4 b)
        {
            return new ulong4x4(
                a.c0 * b.c0.xxxx + a.c1 * b.c0.yyyy,
                a.c0 * b.c1.xxxx + a.c1 * b.c1.yyyy,
                a.c0 * b.c2.xxxx + a.c1 * b.c2.yyyy,
                a.c0 * b.c3.xxxx + a.c1 * b.c3.yyyy);
        }

        /// <summary>		Returns the <see cref="MaxMath.ulong4"/> column vector result of a matrix multiplication between a <see cref="MaxMath.ulong4x3"/> and a <see cref="MaxMath.ulong3"/> column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 mul(ulong4x3 a, ulong3 b)
        {
            return a.c0 * b.xxxx + a.c1 * b.yyyy + a.c2 * b.zzzz;
        }

        /// <summary>		Returns the <see cref="MaxMath.ulong4x2"/> result of a matrix multiplication between a <see cref="MaxMath.ulong4x3"/> and a <see cref="MaxMath.ulong3x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x2 mul(ulong4x3 a, ulong3x2 b)
        {
            return new ulong4x2(
                a.c0 * b.c0.xxxx + a.c1 * b.c0.yyyy + a.c2 * b.c0.zzzz,
                a.c0 * b.c1.xxxx + a.c1 * b.c1.yyyy + a.c2 * b.c1.zzzz);
        }

        /// <summary>		Returns the <see cref="MaxMath.ulong4x3"/> result of a matrix multiplication between a <see cref="MaxMath.ulong4x3"/> and a <see cref="MaxMath.ulong3x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x3 mul(ulong4x3 a, ulong3x3 b)
        {
            return new ulong4x3(
                a.c0 * b.c0.xxxx + a.c1 * b.c0.yyyy + a.c2 * b.c0.zzzz,
                a.c0 * b.c1.xxxx + a.c1 * b.c1.yyyy + a.c2 * b.c1.zzzz,
                a.c0 * b.c2.xxxx + a.c1 * b.c2.yyyy + a.c2 * b.c2.zzzz);
        }

        /// <summary>		Returns the <see cref="MaxMath.ulong4x4"/> result of a matrix multiplication between a <see cref="MaxMath.ulong4x3"/> and a <see cref="MaxMath.ulong3x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 mul(ulong4x3 a, ulong3x4 b)
        {
            return new ulong4x4(
                a.c0 * b.c0.xxxx + a.c1 * b.c0.yyyy + a.c2 * b.c0.zzzz,
                a.c0 * b.c1.xxxx + a.c1 * b.c1.yyyy + a.c2 * b.c1.zzzz,
                a.c0 * b.c2.xxxx + a.c1 * b.c2.yyyy + a.c2 * b.c2.zzzz,
                a.c0 * b.c3.xxxx + a.c1 * b.c3.yyyy + a.c2 * b.c3.zzzz);
        }

        /// <summary>		Returns the <see cref="MaxMath.ulong4"/> column vector result of a matrix multiplication between a <see cref="MaxMath.ulong4x4"/> and a <see cref="MaxMath.ulong4"/> column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 mul(ulong4x4 a, ulong4 b)
        {
            return a.c0 * b.xxxx + a.c1 * b.yyyy + a.c2 * b.zzzz + a.c3 * b.wwww;
        }

        /// <summary>		Returns the <see cref="MaxMath.ulong4x2"/> result of a matrix multiplication between a <see cref="MaxMath.ulong4x4"/> and a <see cref="MaxMath.ulong4x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x2 mul(ulong4x4 a, ulong4x2 b)
        {
            return new ulong4x2(
                (a.c0 * b.c0.xxxx + a.c1 * b.c0.yyyy) + (a.c2 * b.c0.zzzz + a.c3 * b.c0.wwww),
                (a.c0 * b.c1.xxxx + a.c1 * b.c1.yyyy) + (a.c2 * b.c1.zzzz + a.c3 * b.c1.wwww));
        }

        /// <summary>		Returns the <see cref="MaxMath.ulong4x3"/> result of a matrix multiplication between a <see cref="MaxMath.ulong4x4"/> and a <see cref="MaxMath.ulong4x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x3 mul(ulong4x4 a, ulong4x3 b)
        {
            return new ulong4x3(
                (a.c0 * b.c0.xxxx + a.c1 * b.c0.yyyy) + (a.c2 * b.c0.zzzz + a.c3 * b.c0.wwww),
                (a.c0 * b.c1.xxxx + a.c1 * b.c1.yyyy) + (a.c2 * b.c1.zzzz + a.c3 * b.c1.wwww),
                (a.c0 * b.c2.xxxx + a.c1 * b.c2.yyyy) + (a.c2 * b.c2.zzzz + a.c3 * b.c2.wwww));
        }

        /// <summary>		Returns the <see cref="MaxMath.ulong4x4"/> result of a matrix multiplication between a <see cref="MaxMath.ulong4x4"/> and a <see cref="MaxMath.ulong4x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 mul(ulong4x4 a, ulong4x4 b)
        {
            return new ulong4x4(
                (a.c0 * b.c0.xxxx + a.c1 * b.c0.yyyy) + (a.c2 * b.c0.zzzz + a.c3 * b.c0.wwww),
                (a.c0 * b.c1.xxxx + a.c1 * b.c1.yyyy) + (a.c2 * b.c1.zzzz + a.c3 * b.c1.wwww),
                (a.c0 * b.c2.xxxx + a.c1 * b.c2.yyyy) + (a.c2 * b.c2.zzzz + a.c3 * b.c2.wwww),
                (a.c0 * b.c3.xxxx + a.c1 * b.c3.yyyy) + (a.c2 * b.c3.zzzz + a.c3 * b.c3.wwww));
        }


        /// <summary>		Returns the <see cref="short"/> result of a matrix multiplication between a <see cref="MaxMath.short2"/> row vector and a <see cref="MaxMath.short2"/> column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int mul(short2 a, short2 b)
        {
            return dot(a, b);
        }

        /// <summary>		Returns the <see cref="MaxMath.short2"/> row vector result of a matrix multiplication between a <see cref="MaxMath.short2"/> row vector and a <see cref="MaxMath.short2x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 mul(short2 a, short2x2 b)
        {
            return new short2((short)dot(a, b.c0), (short)dot(a, b.c1));
        }

        /// <summary>		Returns the <see cref="MaxMath.short3"/> row vector result of a matrix multiplication between a <see cref="MaxMath.short2"/> row vector and a <see cref="MaxMath.short2x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 mul(short2 a, short2x3 b)
        {
            return new short3((short)dot(a, b.c0), (short)dot(a, b.c1), (short)dot(a, b.c2));
        }

        /// <summary>		Returns the <see cref="MaxMath.short4"/> row vector result of a matrix multiplication between a <see cref="MaxMath.short2"/> row vector and a <see cref="MaxMath.short2x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 mul(short2 a, short2x4 b)
        {
            return new short4((short)dot(a, b.c0), (short)dot(a, b.c1), (short)dot(a, b.c2), (short)dot(a, b.c3));
        }

        /// <summary>		Returns the <see cref="short"/> result of a matrix multiplication between a <see cref="MaxMath.short3"/> row vector and a short3 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int mul(short3 a, short3 b)
        {
            return dot(a, b);
        }

        /// <summary>		Returns the <see cref="MaxMath.short2"/> row vector result of a matrix multiplication between a <see cref="MaxMath.short3"/> row vector and a <see cref="MaxMath.short3x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 mul(short3 a, short3x2 b)
        {
            return new short2((short)dot(a, b.c0), (short)dot(a, b.c1));
        }

        /// <summary>		Returns the <see cref="MaxMath.short3"/> row vector result of a matrix multiplication between a <see cref="MaxMath.short3"/> row vector and a <see cref="MaxMath.short3x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 mul(short3 a, short3x3 b)
        {
            return new short3((short)dot(a, b.c0), (short)dot(a, b.c1), (short)dot(a, b.c2));
        }

        /// <summary>		Returns the <see cref="MaxMath.short4"/> row vector result of a matrix multiplication between a <see cref="MaxMath.short3"/> row vector and a <see cref="MaxMath.short3x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 mul(short3 a, short3x4 b)
        {
            return new short4((short)dot(a, b.c0), (short)dot(a, b.c1), (short)dot(a, b.c2), (short)dot(a, b.c3));
        }

        /// <summary>		Returns the <see cref="short"/> result of a matrix multiplication between a <see cref="MaxMath.short4"/> row vector and a <see cref="MaxMath.short4"/> column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int mul(short4 a, short4 b)
        {
            return dot(a, b);
        }

        /// <summary>		Returns the <see cref="MaxMath.short2"/> row vector result of a matrix multiplication between a <see cref="MaxMath.short4"/> row vector and a <see cref="MaxMath.short4x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 mul(short4 a, short4x2 b)
        {
            return new short2((short)dot(a, b.c0), (short)dot(a, b.c1));
        }

        /// <summary>		Returns the <see cref="MaxMath.short3"/> row vector result of a matrix multiplication between a <see cref="MaxMath.short4"/> row vector and a <see cref="MaxMath.short4x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 mul(short4 a, short4x3 b)
        {
            return new short3((short)dot(a, b.c0), (short)dot(a, b.c1), (short)dot(a, b.c2));
        }

        /// <summary>		Returns the <see cref="MaxMath.short4"/> row vector result of a matrix multiplication between a <see cref="MaxMath.short4"/> row vector and a <see cref="MaxMath.short4x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 mul(short4 a, short4x4 b)
        {
            return new short4((short)dot(a, b.c0), (short)dot(a, b.c1), (short)dot(a, b.c2), (short)dot(a, b.c3));
        }

        /// <summary>		Returns the <see cref="MaxMath.short2"/> column vector result of a matrix multiplication between a <see cref="MaxMath.short2x2"/> and a <see cref="MaxMath.short2"/> column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 mul(short2x2 a, short2 b)
        {
            return a.c0 * b.xx + a.c1 * b.yy;
        }

        /// <summary>		Returns the <see cref="MaxMath.short2x2"/> result of a matrix multiplication between a <see cref="MaxMath.short2x2"/> and a <see cref="MaxMath.short2x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 mul(short2x2 a, short2x2 b)
        {
            return new short2x2(
                a.c0 * b.c0.xx + a.c1 * b.c0.yy,
                a.c0 * b.c1.xx + a.c1 * b.c1.yy);
        }

        /// <summary>		Returns the <see cref="MaxMath.short2x3"/> result of a matrix multiplication between a <see cref="MaxMath.short2x2"/> and a <see cref="MaxMath.short2x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 mul(short2x2 a, short2x3 b)
        {
            return new short2x3(
                a.c0 * b.c0.xx + a.c1 * b.c0.yy,
                a.c0 * b.c1.xx + a.c1 * b.c1.yy,
                a.c0 * b.c2.xx + a.c1 * b.c2.yy);
        }

        /// <summary>		Returns the <see cref="MaxMath.short2x4"/> result of a matrix multiplication between a <see cref="MaxMath.short2x2"/> and a <see cref="MaxMath.short2x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x4 mul(short2x2 a, short2x4 b)
        {
            return new short2x4(
                a.c0 * b.c0.xx + a.c1 * b.c0.yy,
                a.c0 * b.c1.xx + a.c1 * b.c1.yy,
                a.c0 * b.c2.xx + a.c1 * b.c2.yy,
                a.c0 * b.c3.xx + a.c1 * b.c3.yy);
        }

        /// <summary>		Returns the <see cref="MaxMath.short2"/> column vector result of a matrix multiplication between a <see cref="MaxMath.short2x3"/> and a <see cref="MaxMath.short3"/> column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 mul(short2x3 a, short3 b)
        {
            return a.c0 * b.xx + a.c1 * b.yy + a.c2 * b.zz;
        }

        /// <summary>		Returns the <see cref="MaxMath.short2x2"/> result of a matrix multiplication between a <see cref="MaxMath.short2x3"/> and a <see cref="MaxMath.short3x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 mul(short2x3 a, short3x2 b)
        {
            return new short2x2(
                a.c0 * b.c0.xx + a.c1 * b.c0.yy + a.c2 * b.c0.zz,
                a.c0 * b.c1.xx + a.c1 * b.c1.yy + a.c2 * b.c1.zz);
        }

        /// <summary>		Returns the <see cref="MaxMath.short2x3"/> result of a matrix multiplication between a <see cref="MaxMath.short2x3"/> and a <see cref="MaxMath.short3x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 mul(short2x3 a, short3x3 b)
        {
            return new short2x3(
                a.c0 * b.c0.xx + a.c1 * b.c0.yy + a.c2 * b.c0.zz,
                a.c0 * b.c1.xx + a.c1 * b.c1.yy + a.c2 * b.c1.zz,
                a.c0 * b.c2.xx + a.c1 * b.c2.yy + a.c2 * b.c2.zz);
        }

        /// <summary>		Returns the <see cref="MaxMath.short2x4"/> result of a matrix multiplication between a <see cref="MaxMath.short2x3"/> and a <see cref="MaxMath.short3x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x4 mul(short2x3 a, short3x4 b)
        {
            return new short2x4(
                a.c0 * b.c0.xx + a.c1 * b.c0.yy + a.c2 * b.c0.zz,
                a.c0 * b.c1.xx + a.c1 * b.c1.yy + a.c2 * b.c1.zz,
                a.c0 * b.c2.xx + a.c1 * b.c2.yy + a.c2 * b.c2.zz,
                a.c0 * b.c3.xx + a.c1 * b.c3.yy + a.c2 * b.c3.zz);
        }

        /// <summary>		Returns the <see cref="MaxMath.short2"/> column vector result of a matrix multiplication between a <see cref="MaxMath.short2x4"/> and a <see cref="MaxMath.short4"/> column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 mul(short2x4 a, short4 b)
        {
            return a.c0 * b.xx + a.c1 * b.yy + a.c2 * b.zz + a.c3 * b.ww;
        }

        /// <summary>		Returns the <see cref="MaxMath.short2x2"/> result of a matrix multiplication between a <see cref="MaxMath.short2x4"/> and a <see cref="MaxMath.short4x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 mul(short2x4 a, short4x2 b)
        {
            return new short2x2(
                (a.c0 * b.c0.xx + a.c1 * b.c0.yy) + (a.c2 * b.c0.zz + a.c3 * b.c0.ww),
                (a.c0 * b.c1.xx + a.c1 * b.c1.yy) + (a.c2 * b.c1.zz + a.c3 * b.c1.ww));
        }

        /// <summary>		Returns the <see cref="MaxMath.short2x3"/> result of a matrix multiplication between a <see cref="MaxMath.short2x4"/> and a <see cref="MaxMath.short4x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 mul(short2x4 a, short4x3 b)
        {
            return new short2x3(
                (a.c0 * b.c0.xx + a.c1 * b.c0.yy) + (a.c2 * b.c0.zz + a.c3 * b.c0.ww),
                (a.c0 * b.c1.xx + a.c1 * b.c1.yy) + (a.c2 * b.c1.zz + a.c3 * b.c1.ww),
                (a.c0 * b.c2.xx + a.c1 * b.c2.yy) + (a.c2 * b.c2.zz + a.c3 * b.c2.ww));
        }

        /// <summary>		Returns the <see cref="MaxMath.short2x4"/> result of a matrix multiplication between a <see cref="MaxMath.short2x4"/> and a <see cref="MaxMath.short4x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x4 mul(short2x4 a, short4x4 b)
        {
            return new short2x4(
                (a.c0 * b.c0.xx + a.c1 * b.c0.yy) + (a.c2 * b.c0.zz + a.c3 * b.c0.ww),
                (a.c0 * b.c1.xx + a.c1 * b.c1.yy) + (a.c2 * b.c1.zz + a.c3 * b.c1.ww),
                (a.c0 * b.c2.xx + a.c1 * b.c2.yy) + (a.c2 * b.c2.zz + a.c3 * b.c2.ww),
                (a.c0 * b.c3.xx + a.c1 * b.c3.yy) + (a.c2 * b.c3.zz + a.c3 * b.c3.ww));
        }

        /// <summary>		Returns the <see cref="MaxMath.short3"/> column vector result of a matrix multiplication between a <see cref="MaxMath.short3x2"/> and a <see cref="MaxMath.short2"/> column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 mul(short3x2 a, short2 b)
        {
            return a.c0 * b.xxx + a.c1 * b.yyy;
        }

        /// <summary>		Returns the <see cref="MaxMath.short3x2"/> result of a matrix multiplication between a <see cref="MaxMath.short3x2"/> and a <see cref="MaxMath.short2x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3x2 mul(short3x2 a, short2x2 b)
        {
            return new short3x2(
                a.c0 * b.c0.xxx + a.c1 * b.c0.yyy,
                a.c0 * b.c1.xxx + a.c1 * b.c1.yyy);
        }

        /// <summary>		Returns the <see cref="MaxMath.short3x3"/> result of a matrix multiplication between a <see cref="MaxMath.short3x2"/> and a <see cref="MaxMath.short2x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3x3 mul(short3x2 a, short2x3 b)
        {
            return new short3x3(
                a.c0 * b.c0.xxx + a.c1 * b.c0.yyy,
                a.c0 * b.c1.xxx + a.c1 * b.c1.yyy,
                a.c0 * b.c2.xxx + a.c1 * b.c2.yyy);
        }

        /// <summary>		Returns the <see cref="MaxMath.short3x4"/> result of a matrix multiplication between a <see cref="MaxMath.short3x2"/> and a <see cref="MaxMath.short2x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3x4 mul(short3x2 a, short2x4 b)
        {
            return new short3x4(
                a.c0 * b.c0.xxx + a.c1 * b.c0.yyy,
                a.c0 * b.c1.xxx + a.c1 * b.c1.yyy,
                a.c0 * b.c2.xxx + a.c1 * b.c2.yyy,
                a.c0 * b.c3.xxx + a.c1 * b.c3.yyy);
        }

        /// <summary>		Returns the <see cref="MaxMath.short3"/> column vector result of a matrix multiplication between a <see cref="MaxMath.short3x3"/> and a <see cref="MaxMath.short3"/> column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 mul(short3x3 a, short3 b)
        {
            return a.c0 * b.xxx + a.c1 * b.yyy + a.c2 * b.zzz;
        }

        /// <summary>		Returns the <see cref="MaxMath.short3x2"/> result of a matrix multiplication between a <see cref="MaxMath.short3x3"/> and a <see cref="MaxMath.short3x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3x2 mul(short3x3 a, short3x2 b)
        {
            return new short3x2(
                a.c0 * b.c0.xxx + a.c1 * b.c0.yyy + a.c2 * b.c0.zzz,
                a.c0 * b.c1.xxx + a.c1 * b.c1.yyy + a.c2 * b.c1.zzz);
        }

        /// <summary>		Returns the <see cref="MaxMath.short3x3"/> result of a matrix multiplication between a <see cref="MaxMath.short3x3"/> and a <see cref="MaxMath.short3x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3x3 mul(short3x3 a, short3x3 b)
        {
            return new short3x3(
                a.c0 * b.c0.xxx + a.c1 * b.c0.yyy + a.c2 * b.c0.zzz,
                a.c0 * b.c1.xxx + a.c1 * b.c1.yyy + a.c2 * b.c1.zzz,
                a.c0 * b.c2.xxx + a.c1 * b.c2.yyy + a.c2 * b.c2.zzz);
        }

        /// <summary>		Returns the <see cref="MaxMath.short3x4"/> result of a matrix multiplication between a <see cref="MaxMath.short3x3"/> and a <see cref="MaxMath.short3x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3x4 mul(short3x3 a, short3x4 b)
        {
            return new short3x4(
                a.c0 * b.c0.xxx + a.c1 * b.c0.yyy + a.c2 * b.c0.zzz,
                a.c0 * b.c1.xxx + a.c1 * b.c1.yyy + a.c2 * b.c1.zzz,
                a.c0 * b.c2.xxx + a.c1 * b.c2.yyy + a.c2 * b.c2.zzz,
                a.c0 * b.c3.xxx + a.c1 * b.c3.yyy + a.c2 * b.c3.zzz);
        }

        /// <summary>		Returns the <see cref="MaxMath.short3"/> column vector result of a matrix multiplication between a <see cref="MaxMath.short3x4"/> and a <see cref="MaxMath.short4"/> column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 mul(short3x4 a, short4 b)
        {
            return a.c0 * b.xxx + a.c1 * b.yyy + a.c2 * b.zzz + a.c3 * b.www;
        }

        /// <summary>		Returns the <see cref="MaxMath.short3x2"/> result of a matrix multiplication between a <see cref="MaxMath.short3x4"/> and a <see cref="MaxMath.short4x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3x2 mul(short3x4 a, short4x2 b)
        {
            return new short3x2(
                (a.c0 * b.c0.xxx + a.c1 * b.c0.yyy) + (a.c2 * b.c0.zzz + a.c3 * b.c0.www),
                (a.c0 * b.c1.xxx + a.c1 * b.c1.yyy) + (a.c2 * b.c1.zzz + a.c3 * b.c1.www));
        }

        /// <summary>		Returns the <see cref="MaxMath.short3x3"/> result of a matrix multiplication between a <see cref="MaxMath.short3x4"/> and a <see cref="MaxMath.short4x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3x3 mul(short3x4 a, short4x3 b)
        {
            return new short3x3(
                (a.c0 * b.c0.xxx + a.c1 * b.c0.yyy) + (a.c2 * b.c0.zzz + a.c3 * b.c0.www),
                (a.c0 * b.c1.xxx + a.c1 * b.c1.yyy) + (a.c2 * b.c1.zzz + a.c3 * b.c1.www),
                (a.c0 * b.c2.xxx + a.c1 * b.c2.yyy) + (a.c2 * b.c2.zzz + a.c3 * b.c2.www));
        }

        /// <summary>		Returns the <see cref="MaxMath.short3x4"/> result of a matrix multiplication between a <see cref="MaxMath.short3x4"/> and a <see cref="MaxMath.short4x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3x4 mul(short3x4 a, short4x4 b)
        {
            return new short3x4(
                (a.c0 * b.c0.xxx + a.c1 * b.c0.yyy) + (a.c2 * b.c0.zzz + a.c3 * b.c0.www),
                (a.c0 * b.c1.xxx + a.c1 * b.c1.yyy) + (a.c2 * b.c1.zzz + a.c3 * b.c1.www),
                (a.c0 * b.c2.xxx + a.c1 * b.c2.yyy) + (a.c2 * b.c2.zzz + a.c3 * b.c2.www),
                (a.c0 * b.c3.xxx + a.c1 * b.c3.yyy) + (a.c2 * b.c3.zzz + a.c3 * b.c3.www));
        }

        /// <summary>		Returns the <see cref="MaxMath.short4"/> column vector result of a matrix multiplication between a <see cref="MaxMath.short4x2"/> and a <see cref="MaxMath.short2"/> column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 mul(short4x2 a, short2 b)
        {
            return a.c0 * b.xxxx + a.c1 * b.yyyy;
        }

        /// <summary>		Returns the <see cref="MaxMath.short4x2"/> result of a matrix multiplication between a <see cref="MaxMath.short4x2"/> and a <see cref="MaxMath.short2x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4x2 mul(short4x2 a, short2x2 b)
        {
            return new short4x2(
                a.c0 * b.c0.xxxx + a.c1 * b.c0.yyyy,
                a.c0 * b.c1.xxxx + a.c1 * b.c1.yyyy);
        }

        /// <summary>		Returns the <see cref="MaxMath.short4x3"/> result of a matrix multiplication between a <see cref="MaxMath.short4x2"/> and a <see cref="MaxMath.short2x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4x3 mul(short4x2 a, short2x3 b)
        {
            return new short4x3(
                a.c0 * b.c0.xxxx + a.c1 * b.c0.yyyy,
                a.c0 * b.c1.xxxx + a.c1 * b.c1.yyyy,
                a.c0 * b.c2.xxxx + a.c1 * b.c2.yyyy);
        }

        /// <summary>		Returns the <see cref="MaxMath.short4x4"/> result of a matrix multiplication between a <see cref="MaxMath.short4x2"/> and a <see cref="MaxMath.short2x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4x4 mul(short4x2 a, short2x4 b)
        {
            return new short4x4(
                a.c0 * b.c0.xxxx + a.c1 * b.c0.yyyy,
                a.c0 * b.c1.xxxx + a.c1 * b.c1.yyyy,
                a.c0 * b.c2.xxxx + a.c1 * b.c2.yyyy,
                a.c0 * b.c3.xxxx + a.c1 * b.c3.yyyy);
        }

        /// <summary>		Returns the <see cref="MaxMath.short4"/> column vector result of a matrix multiplication between a <see cref="MaxMath.short4x3"/> and a <see cref="MaxMath.short3"/> column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 mul(short4x3 a, short3 b)
        {
            return a.c0 * b.xxxx + a.c1 * b.yyyy + a.c2 * b.zzzz;
        }

        /// <summary>		Returns the <see cref="MaxMath.short4x2"/> result of a matrix multiplication between a <see cref="MaxMath.short4x3"/> and a <see cref="MaxMath.short3x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4x2 mul(short4x3 a, short3x2 b)
        {
            return new short4x2(
                a.c0 * b.c0.xxxx + a.c1 * b.c0.yyyy + a.c2 * b.c0.zzzz,
                a.c0 * b.c1.xxxx + a.c1 * b.c1.yyyy + a.c2 * b.c1.zzzz);
        }

        /// <summary>		Returns the <see cref="MaxMath.short4x3"/> result of a matrix multiplication between a <see cref="MaxMath.short4x3"/> and a <see cref="MaxMath.short3x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4x3 mul(short4x3 a, short3x3 b)
        {
            return new short4x3(
                a.c0 * b.c0.xxxx + a.c1 * b.c0.yyyy + a.c2 * b.c0.zzzz,
                a.c0 * b.c1.xxxx + a.c1 * b.c1.yyyy + a.c2 * b.c1.zzzz,
                a.c0 * b.c2.xxxx + a.c1 * b.c2.yyyy + a.c2 * b.c2.zzzz);
        }

        /// <summary>		Returns the <see cref="MaxMath.short4x4"/> result of a matrix multiplication between a <see cref="MaxMath.short4x3"/> and a <see cref="MaxMath.short3x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4x4 mul(short4x3 a, short3x4 b)
        {
            return new short4x4(
                a.c0 * b.c0.xxxx + a.c1 * b.c0.yyyy + a.c2 * b.c0.zzzz,
                a.c0 * b.c1.xxxx + a.c1 * b.c1.yyyy + a.c2 * b.c1.zzzz,
                a.c0 * b.c2.xxxx + a.c1 * b.c2.yyyy + a.c2 * b.c2.zzzz,
                a.c0 * b.c3.xxxx + a.c1 * b.c3.yyyy + a.c2 * b.c3.zzzz);
        }

        /// <summary>		Returns the <see cref="MaxMath.short4"/> column vector result of a matrix multiplication between a <see cref="MaxMath.short4x4"/> and a <see cref="MaxMath.short4"/> column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 mul(short4x4 a, short4 b)
        {
            return a.c0 * b.xxxx + a.c1 * b.yyyy + a.c2 * b.zzzz + a.c3 * b.wwww;
        }

        /// <summary>		Returns the <see cref="MaxMath.short4x2"/> result of a matrix multiplication between a <see cref="MaxMath.short4x4"/> and a <see cref="MaxMath.short4x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4x2 mul(short4x4 a, short4x2 b)
        {
            return new short4x2(
                (a.c0 * b.c0.xxxx + a.c1 * b.c0.yyyy) + (a.c2 * b.c0.zzzz + a.c3 * b.c0.wwww),
                (a.c0 * b.c1.xxxx + a.c1 * b.c1.yyyy) + (a.c2 * b.c1.zzzz + a.c3 * b.c1.wwww));
        }

        /// <summary>		Returns the <see cref="MaxMath.short4x3"/> result of a matrix multiplication between a <see cref="MaxMath.short4x4"/> and a <see cref="MaxMath.short4x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4x3 mul(short4x4 a, short4x3 b)
        {
            return new short4x3(
                (a.c0 * b.c0.xxxx + a.c1 * b.c0.yyyy) + (a.c2 * b.c0.zzzz + a.c3 * b.c0.wwww),
                (a.c0 * b.c1.xxxx + a.c1 * b.c1.yyyy) + (a.c2 * b.c1.zzzz + a.c3 * b.c1.wwww),
                (a.c0 * b.c2.xxxx + a.c1 * b.c2.yyyy) + (a.c2 * b.c2.zzzz + a.c3 * b.c2.wwww));
        }

        /// <summary>		Returns the <see cref="MaxMath.short4x4"/> result of a matrix multiplication between a <see cref="MaxMath.short4x4"/> and a <see cref="MaxMath.short4x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4x4 mul(short4x4 a, short4x4 b)
        {
            return new short4x4(
                (a.c0 * b.c0.xxxx + a.c1 * b.c0.yyyy) + (a.c2 * b.c0.zzzz + a.c3 * b.c0.wwww),
                (a.c0 * b.c1.xxxx + a.c1 * b.c1.yyyy) + (a.c2 * b.c1.zzzz + a.c3 * b.c1.wwww),
                (a.c0 * b.c2.xxxx + a.c1 * b.c2.yyyy) + (a.c2 * b.c2.zzzz + a.c3 * b.c2.wwww),
                (a.c0 * b.c3.xxxx + a.c1 * b.c3.yyyy) + (a.c2 * b.c3.zzzz + a.c3 * b.c3.wwww));
        }


        /// <summary>		Returns the <see cref="ushort"/> result of a matrix multiplication between a <see cref="MaxMath.ushort2"/> row vector and a <see cref="MaxMath.ushort2"/> column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint mul(ushort2 a, ushort2 b)
        {
            return dot(a, b);
        }

        /// <summary>		Returns the <see cref="MaxMath.ushort2"/> row vector result of a matrix multiplication between a <see cref="MaxMath.ushort2"/> row vector and a <see cref="MaxMath.ushort2x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 mul(ushort2 a, ushort2x2 b)
        {
            return new ushort2((ushort)dot(a, b.c0), (ushort)dot(a, b.c1));
        }

        /// <summary>		Returns the <see cref="MaxMath.ushort3"/> row vector result of a matrix multiplication between a <see cref="MaxMath.ushort2"/> row vector and a <see cref="MaxMath.ushort2x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 mul(ushort2 a, ushort2x3 b)
        {
            return new ushort3((ushort)dot(a, b.c0), (ushort)dot(a, b.c1), (ushort)dot(a, b.c2));
        }

        /// <summary>		Returns the <see cref="MaxMath.ushort4"/> row vector result of a matrix multiplication between a <see cref="MaxMath.ushort2"/> row vector and a <see cref="MaxMath.ushort2x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 mul(ushort2 a, ushort2x4 b)
        {
            return new ushort4((ushort)dot(a, b.c0), (ushort)dot(a, b.c1), (ushort)dot(a, b.c2), (ushort)dot(a, b.c3));
        }

        /// <summary>		Returns the <see cref="ushort"/> result of a matrix multiplication between a <see cref="MaxMath.ushort3"/> row vector and a ushort3 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint mul(ushort3 a, ushort3 b)
        {
            return dot(a, b);
        }

        /// <summary>		Returns the <see cref="MaxMath.ushort2"/> row vector result of a matrix multiplication between a <see cref="MaxMath.ushort3"/> row vector and a <see cref="MaxMath.ushort3x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 mul(ushort3 a, ushort3x2 b)
        {
            return new ushort2((ushort)dot(a, b.c0), (ushort)dot(a, b.c1));
        }

        /// <summary>		Returns the <see cref="MaxMath.ushort3"/> row vector result of a matrix multiplication between a <see cref="MaxMath.ushort3"/> row vector and a <see cref="MaxMath.ushort3x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 mul(ushort3 a, ushort3x3 b)
        {
            return new ushort3((ushort)dot(a, b.c0), (ushort)dot(a, b.c1), (ushort)dot(a, b.c2));
        }

        /// <summary>		Returns the <see cref="MaxMath.ushort4"/> row vector result of a matrix multiplication between a <see cref="MaxMath.ushort3"/> row vector and a <see cref="MaxMath.ushort3x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 mul(ushort3 a, ushort3x4 b)
        {
            return new ushort4((ushort)dot(a, b.c0), (ushort)dot(a, b.c1), (ushort)dot(a, b.c2), (ushort)dot(a, b.c3));
        }

        /// <summary>		Returns the <see cref="ushort"/> result of a matrix multiplication between a <see cref="MaxMath.ushort4"/> row vector and a <see cref="MaxMath.ushort4"/> column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint mul(ushort4 a, ushort4 b)
        {
            return dot(a, b);
        }

        /// <summary>		Returns the <see cref="MaxMath.ushort2"/> row vector result of a matrix multiplication between a <see cref="MaxMath.ushort4"/> row vector and a <see cref="MaxMath.ushort4x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 mul(ushort4 a, ushort4x2 b)
        {
            return new ushort2((ushort)dot(a, b.c0), (ushort)dot(a, b.c1));
        }

        /// <summary>		Returns the <see cref="MaxMath.ushort3"/> row vector result of a matrix multiplication between a <see cref="MaxMath.ushort4"/> row vector and a <see cref="MaxMath.ushort4x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 mul(ushort4 a, ushort4x3 b)
        {
            return new ushort3((ushort)dot(a, b.c0), (ushort)dot(a, b.c1), (ushort)dot(a, b.c2));
        }

        /// <summary>		Returns the <see cref="MaxMath.ushort4"/> row vector result of a matrix multiplication between a <see cref="MaxMath.ushort4"/> row vector and a <see cref="MaxMath.ushort4x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 mul(ushort4 a, ushort4x4 b)
        {
            return new ushort4((ushort)dot(a, b.c0), (ushort)dot(a, b.c1), (ushort)dot(a, b.c2), (ushort)dot(a, b.c3));
        }

        /// <summary>		Returns the <see cref="MaxMath.ushort2"/> column vector result of a matrix multiplication between a <see cref="MaxMath.ushort2x2"/> and a <see cref="MaxMath.ushort2"/> column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 mul(ushort2x2 a, ushort2 b)
        {
            return a.c0 * b.xx + a.c1 * b.yy;
        }

        /// <summary>		Returns the <see cref="MaxMath.ushort2x2"/> result of a matrix multiplication between a <see cref="MaxMath.ushort2x2"/> and a <see cref="MaxMath.ushort2x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2x2 mul(ushort2x2 a, ushort2x2 b)
        {
            return new ushort2x2(
                a.c0 * b.c0.xx + a.c1 * b.c0.yy,
                a.c0 * b.c1.xx + a.c1 * b.c1.yy);
        }

        /// <summary>		Returns the <see cref="MaxMath.ushort2x3"/> result of a matrix multiplication between a <see cref="MaxMath.ushort2x2"/> and a <see cref="MaxMath.ushort2x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2x3 mul(ushort2x2 a, ushort2x3 b)
        {
            return new ushort2x3(
                a.c0 * b.c0.xx + a.c1 * b.c0.yy,
                a.c0 * b.c1.xx + a.c1 * b.c1.yy,
                a.c0 * b.c2.xx + a.c1 * b.c2.yy);
        }

        /// <summary>		Returns the <see cref="MaxMath.ushort2x4"/> result of a matrix multiplication between a <see cref="MaxMath.ushort2x2"/> and a <see cref="MaxMath.ushort2x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2x4 mul(ushort2x2 a, ushort2x4 b)
        {
            return new ushort2x4(
                a.c0 * b.c0.xx + a.c1 * b.c0.yy,
                a.c0 * b.c1.xx + a.c1 * b.c1.yy,
                a.c0 * b.c2.xx + a.c1 * b.c2.yy,
                a.c0 * b.c3.xx + a.c1 * b.c3.yy);
        }

        /// <summary>		Returns the <see cref="MaxMath.ushort2"/> column vector result of a matrix multiplication between a <see cref="MaxMath.ushort2x3"/> and a <see cref="MaxMath.ushort3"/> column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 mul(ushort2x3 a, ushort3 b)
        {
            return a.c0 * b.xx + a.c1 * b.yy + a.c2 * b.zz;
        }

        /// <summary>		Returns the <see cref="MaxMath.ushort2x2"/> result of a matrix multiplication between a <see cref="MaxMath.ushort2x3"/> and a <see cref="MaxMath.ushort3x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2x2 mul(ushort2x3 a, ushort3x2 b)
        {
            return new ushort2x2(
                a.c0 * b.c0.xx + a.c1 * b.c0.yy + a.c2 * b.c0.zz,
                a.c0 * b.c1.xx + a.c1 * b.c1.yy + a.c2 * b.c1.zz);
        }

        /// <summary>		Returns the <see cref="MaxMath.ushort2x3"/> result of a matrix multiplication between a <see cref="MaxMath.ushort2x3"/> and a <see cref="MaxMath.ushort3x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2x3 mul(ushort2x3 a, ushort3x3 b)
        {
            return new ushort2x3(
                a.c0 * b.c0.xx + a.c1 * b.c0.yy + a.c2 * b.c0.zz,
                a.c0 * b.c1.xx + a.c1 * b.c1.yy + a.c2 * b.c1.zz,
                a.c0 * b.c2.xx + a.c1 * b.c2.yy + a.c2 * b.c2.zz);
        }

        /// <summary>		Returns the <see cref="MaxMath.ushort2x4"/> result of a matrix multiplication between a <see cref="MaxMath.ushort2x3"/> and a <see cref="MaxMath.ushort3x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2x4 mul(ushort2x3 a, ushort3x4 b)
        {
            return new ushort2x4(
                a.c0 * b.c0.xx + a.c1 * b.c0.yy + a.c2 * b.c0.zz,
                a.c0 * b.c1.xx + a.c1 * b.c1.yy + a.c2 * b.c1.zz,
                a.c0 * b.c2.xx + a.c1 * b.c2.yy + a.c2 * b.c2.zz,
                a.c0 * b.c3.xx + a.c1 * b.c3.yy + a.c2 * b.c3.zz);
        }

        /// <summary>		Returns the Returns the <see cref="MaxMath.ushort2"/> column vector result of a matrix multiplication between a <see cref="MaxMath.ushort2x4"/> and a <see cref="MaxMath.ushort4"/> column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 mul(ushort2x4 a, ushort4 b)
        {
            return a.c0 * b.xx + a.c1 * b.yy + a.c2 * b.zz + a.c3 * b.ww;
        }

        /// <summary>		Returns the <see cref="MaxMath.ushort2x2"/> result of a matrix multiplication between a <see cref="MaxMath.ushort2x4"/> and a <see cref="MaxMath.ushort4x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2x2 mul(ushort2x4 a, ushort4x2 b)
        {
            return new ushort2x2(
                (a.c0 * b.c0.xx + a.c1 * b.c0.yy) + (a.c2 * b.c0.zz + a.c3 * b.c0.ww),
                (a.c0 * b.c1.xx + a.c1 * b.c1.yy) + (a.c2 * b.c1.zz + a.c3 * b.c1.ww));
        }

        /// <summary>		Returns the <see cref="MaxMath.ushort2x3"/> result of a matrix multiplication between a <see cref="MaxMath.ushort2x4"/> and a <see cref="MaxMath.ushort4x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2x3 mul(ushort2x4 a, ushort4x3 b)
        {
            return new ushort2x3(
                (a.c0 * b.c0.xx + a.c1 * b.c0.yy) + (a.c2 * b.c0.zz + a.c3 * b.c0.ww),
                (a.c0 * b.c1.xx + a.c1 * b.c1.yy) + (a.c2 * b.c1.zz + a.c3 * b.c1.ww),
                (a.c0 * b.c2.xx + a.c1 * b.c2.yy) + (a.c2 * b.c2.zz + a.c3 * b.c2.ww));
        }

        /// <summary>		Returns the <see cref="MaxMath.ushort2x4"/> result of a matrix multiplication between a <see cref="MaxMath.ushort2x4"/> and a <see cref="MaxMath.ushort4x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2x4 mul(ushort2x4 a, ushort4x4 b)
        {
            return new ushort2x4(
                (a.c0 * b.c0.xx + a.c1 * b.c0.yy) + (a.c2 * b.c0.zz + a.c3 * b.c0.ww),
                (a.c0 * b.c1.xx + a.c1 * b.c1.yy) + (a.c2 * b.c1.zz + a.c3 * b.c1.ww),
                (a.c0 * b.c2.xx + a.c1 * b.c2.yy) + (a.c2 * b.c2.zz + a.c3 * b.c2.ww),
                (a.c0 * b.c3.xx + a.c1 * b.c3.yy) + (a.c2 * b.c3.zz + a.c3 * b.c3.ww));
        }

        /// <summary>		Returns the Returns the <see cref="MaxMath.ushort3"/> column vector result of a matrix multiplication between a <see cref="MaxMath.ushort3x2"/> and a <see cref="MaxMath.ushort2"/> column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 mul(ushort3x2 a, ushort2 b)
        {
            return a.c0 * b.xxx + a.c1 * b.yyy;
        }

        /// <summary>		Returns the <see cref="MaxMath.ushort3x2"/> result of a matrix multiplication between a <see cref="MaxMath.ushort3x2"/> and a <see cref="MaxMath.ushort2x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3x2 mul(ushort3x2 a, ushort2x2 b)
        {
            return new ushort3x2(
                a.c0 * b.c0.xxx + a.c1 * b.c0.yyy,
                a.c0 * b.c1.xxx + a.c1 * b.c1.yyy);
        }

        /// <summary>		Returns the <see cref="MaxMath.ushort3x3"/> result of a matrix multiplication between a <see cref="MaxMath.ushort3x2"/> and a <see cref="MaxMath.ushort2x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3x3 mul(ushort3x2 a, ushort2x3 b)
        {
            return new ushort3x3(
                a.c0 * b.c0.xxx + a.c1 * b.c0.yyy,
                a.c0 * b.c1.xxx + a.c1 * b.c1.yyy,
                a.c0 * b.c2.xxx + a.c1 * b.c2.yyy);
        }

        /// <summary>		Returns the <see cref="MaxMath.ushort3x4"/> result of a matrix multiplication between a <see cref="MaxMath.ushort3x2"/> and a <see cref="MaxMath.ushort2x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3x4 mul(ushort3x2 a, ushort2x4 b)
        {
            return new ushort3x4(
                a.c0 * b.c0.xxx + a.c1 * b.c0.yyy,
                a.c0 * b.c1.xxx + a.c1 * b.c1.yyy,
                a.c0 * b.c2.xxx + a.c1 * b.c2.yyy,
                a.c0 * b.c3.xxx + a.c1 * b.c3.yyy);
        }

        /// <summary>		Returns the Returns the <see cref="MaxMath.ushort3"/> column vector result of a matrix multiplication between a <see cref="MaxMath.ushort3x3"/> and a <see cref="MaxMath.ushort3"/> column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 mul(ushort3x3 a, ushort3 b)
        {
            return a.c0 * b.xxx + a.c1 * b.yyy + a.c2 * b.zzz;
        }

        /// <summary>		Returns the <see cref="MaxMath.ushort3x2"/> result of a matrix multiplication between a <see cref="MaxMath.ushort3x3"/> and a <see cref="MaxMath.ushort3x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3x2 mul(ushort3x3 a, ushort3x2 b)
        {
            return new ushort3x2(
                a.c0 * b.c0.xxx + a.c1 * b.c0.yyy + a.c2 * b.c0.zzz,
                a.c0 * b.c1.xxx + a.c1 * b.c1.yyy + a.c2 * b.c1.zzz);
        }

        /// <summary>		Returns the <see cref="MaxMath.ushort3x3"/> result of a matrix multiplication between a <see cref="MaxMath.ushort3x3"/> and a <see cref="MaxMath.ushort3x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3x3 mul(ushort3x3 a, ushort3x3 b)
        {
            return new ushort3x3(
                a.c0 * b.c0.xxx + a.c1 * b.c0.yyy + a.c2 * b.c0.zzz,
                a.c0 * b.c1.xxx + a.c1 * b.c1.yyy + a.c2 * b.c1.zzz,
                a.c0 * b.c2.xxx + a.c1 * b.c2.yyy + a.c2 * b.c2.zzz);
        }

        /// <summary>		Returns the <see cref="MaxMath.ushort3x4"/> result of a matrix multiplication between a <see cref="MaxMath.ushort3x3"/> and a <see cref="MaxMath.ushort3x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3x4 mul(ushort3x3 a, ushort3x4 b)
        {
            return new ushort3x4(
                a.c0 * b.c0.xxx + a.c1 * b.c0.yyy + a.c2 * b.c0.zzz,
                a.c0 * b.c1.xxx + a.c1 * b.c1.yyy + a.c2 * b.c1.zzz,
                a.c0 * b.c2.xxx + a.c1 * b.c2.yyy + a.c2 * b.c2.zzz,
                a.c0 * b.c3.xxx + a.c1 * b.c3.yyy + a.c2 * b.c3.zzz);
        }

        /// <summary>		Returns the <see cref="MaxMath.ushort3"/> column vector result of a matrix multiplication between a <see cref="MaxMath.ushort3x4"/> and a <see cref="MaxMath.ushort4"/> column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 mul(ushort3x4 a, ushort4 b)
        {
            return a.c0 * b.xxx + a.c1 * b.yyy + a.c2 * b.zzz + a.c3 * b.www;
        }

        /// <summary>		Returns the <see cref="MaxMath.ushort3x2"/> result of a matrix multiplication between a <see cref="MaxMath.ushort3x4"/> and a <see cref="MaxMath.ushort4x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3x2 mul(ushort3x4 a, ushort4x2 b)
        {
            return new ushort3x2(
                (a.c0 * b.c0.xxx + a.c1 * b.c0.yyy) + (a.c2 * b.c0.zzz + a.c3 * b.c0.www),
                (a.c0 * b.c1.xxx + a.c1 * b.c1.yyy) + (a.c2 * b.c1.zzz + a.c3 * b.c1.www));
        }

        /// <summary>		Returns the <see cref="MaxMath.ushort3x3"/> result of a matrix multiplication between a <see cref="MaxMath.ushort3x4"/> and a <see cref="MaxMath.ushort4x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3x3 mul(ushort3x4 a, ushort4x3 b)
        {
            return new ushort3x3(
                (a.c0 * b.c0.xxx + a.c1 * b.c0.yyy) + (a.c2 * b.c0.zzz + a.c3 * b.c0.www),
                (a.c0 * b.c1.xxx + a.c1 * b.c1.yyy) + (a.c2 * b.c1.zzz + a.c3 * b.c1.www),
                (a.c0 * b.c2.xxx + a.c1 * b.c2.yyy) + (a.c2 * b.c2.zzz + a.c3 * b.c2.www));
        }

        /// <summary>		Returns the <see cref="MaxMath.ushort3x4"/> result of a matrix multiplication between a <see cref="MaxMath.ushort3x4"/> and a <see cref="MaxMath.ushort4x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3x4 mul(ushort3x4 a, ushort4x4 b)
        {
            return new ushort3x4(
                (a.c0 * b.c0.xxx + a.c1 * b.c0.yyy) + (a.c2 * b.c0.zzz + a.c3 * b.c0.www),
                (a.c0 * b.c1.xxx + a.c1 * b.c1.yyy) + (a.c2 * b.c1.zzz + a.c3 * b.c1.www),
                (a.c0 * b.c2.xxx + a.c1 * b.c2.yyy) + (a.c2 * b.c2.zzz + a.c3 * b.c2.www),
                (a.c0 * b.c3.xxx + a.c1 * b.c3.yyy) + (a.c2 * b.c3.zzz + a.c3 * b.c3.www));
        }

        /// <summary>		Returns the <see cref="MaxMath.ushort4"/> column vector result of a matrix multiplication between a <see cref="MaxMath.ushort4x2"/> and a <see cref="MaxMath.ushort2"/> column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 mul(ushort4x2 a, ushort2 b)
        {
            return a.c0 * b.xxxx + a.c1 * b.yyyy;
        }

        /// <summary>		Returns the <see cref="MaxMath.ushort4x2"/> result of a matrix multiplication between a <see cref="MaxMath.ushort4x2"/> and a <see cref="MaxMath.ushort2x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x2 mul(ushort4x2 a, ushort2x2 b)
        {
            return new ushort4x2(
                a.c0 * b.c0.xxxx + a.c1 * b.c0.yyyy,
                a.c0 * b.c1.xxxx + a.c1 * b.c1.yyyy);
        }

        /// <summary>		Returns the <see cref="MaxMath.ushort4x3"/> result of a matrix multiplication between a <see cref="MaxMath.ushort4x2"/> and a <see cref="MaxMath.ushort2x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 mul(ushort4x2 a, ushort2x3 b)
        {
            return new ushort4x3(
                a.c0 * b.c0.xxxx + a.c1 * b.c0.yyyy,
                a.c0 * b.c1.xxxx + a.c1 * b.c1.yyyy,
                a.c0 * b.c2.xxxx + a.c1 * b.c2.yyyy);
        }

        /// <summary>		Returns the <see cref="MaxMath.ushort4x4"/> result of a matrix multiplication between a <see cref="MaxMath.ushort4x2"/> and a <see cref="MaxMath.ushort2x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x4 mul(ushort4x2 a, ushort2x4 b)
        {
            return new ushort4x4(
                a.c0 * b.c0.xxxx + a.c1 * b.c0.yyyy,
                a.c0 * b.c1.xxxx + a.c1 * b.c1.yyyy,
                a.c0 * b.c2.xxxx + a.c1 * b.c2.yyyy,
                a.c0 * b.c3.xxxx + a.c1 * b.c3.yyyy);
        }

        /// <summary>		Returns the <see cref="MaxMath.ushort4"/> column vector result of a matrix multiplication between a <see cref="MaxMath.ushort4x3"/> and a <see cref="MaxMath.ushort3"/> column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 mul(ushort4x3 a, ushort3 b)
        {
            return a.c0 * b.xxxx + a.c1 * b.yyyy + a.c2 * b.zzzz;
        }

        /// <summary>		Returns the <see cref="MaxMath.ushort4x2"/> result of a matrix multiplication between a <see cref="MaxMath.ushort4x3"/> and a <see cref="MaxMath.ushort3x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x2 mul(ushort4x3 a, ushort3x2 b)
        {
            return new ushort4x2(
                a.c0 * b.c0.xxxx + a.c1 * b.c0.yyyy + a.c2 * b.c0.zzzz,
                a.c0 * b.c1.xxxx + a.c1 * b.c1.yyyy + a.c2 * b.c1.zzzz);
        }

        /// <summary>		Returns the <see cref="MaxMath.ushort4x3"/> result of a matrix multiplication between a <see cref="MaxMath.ushort4x3"/> and a <see cref="MaxMath.ushort3x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 mul(ushort4x3 a, ushort3x3 b)
        {
            return new ushort4x3(
                a.c0 * b.c0.xxxx + a.c1 * b.c0.yyyy + a.c2 * b.c0.zzzz,
                a.c0 * b.c1.xxxx + a.c1 * b.c1.yyyy + a.c2 * b.c1.zzzz,
                a.c0 * b.c2.xxxx + a.c1 * b.c2.yyyy + a.c2 * b.c2.zzzz);
        }

        /// <summary>		Returns the <see cref="MaxMath.ushort4x4"/> result of a matrix multiplication between a <see cref="MaxMath.ushort4x3"/> and a <see cref="MaxMath.ushort3x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x4 mul(ushort4x3 a, ushort3x4 b)
        {
            return new ushort4x4(
                a.c0 * b.c0.xxxx + a.c1 * b.c0.yyyy + a.c2 * b.c0.zzzz,
                a.c0 * b.c1.xxxx + a.c1 * b.c1.yyyy + a.c2 * b.c1.zzzz,
                a.c0 * b.c2.xxxx + a.c1 * b.c2.yyyy + a.c2 * b.c2.zzzz,
                a.c0 * b.c3.xxxx + a.c1 * b.c3.yyyy + a.c2 * b.c3.zzzz);
        }

        /// <summary>		Returns the <see cref="MaxMath.ushort4"/> column vector result of a matrix multiplication between a <see cref="MaxMath.ushort4x4"/> and a <see cref="MaxMath.ushort4"/> column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 mul(ushort4x4 a, ushort4 b)
        {
            return a.c0 * b.xxxx + a.c1 * b.yyyy + a.c2 * b.zzzz + a.c3 * b.wwww;
        }

        /// <summary>		Returns the <see cref="MaxMath.ushort4x2"/> result of a matrix multiplication between a <see cref="MaxMath.ushort4x4"/> and a <see cref="MaxMath.ushort4x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x2 mul(ushort4x4 a, ushort4x2 b)
        {
            return new ushort4x2(
                (a.c0 * b.c0.xxxx + a.c1 * b.c0.yyyy) + (a.c2 * b.c0.zzzz + a.c3 * b.c0.wwww),
                (a.c0 * b.c1.xxxx + a.c1 * b.c1.yyyy) + (a.c2 * b.c1.zzzz + a.c3 * b.c1.wwww));
        }

        /// <summary>		Returns the <see cref="MaxMath.ushort4x3"/> result of a matrix multiplication between a <see cref="MaxMath.ushort4x4"/> and a <see cref="MaxMath.ushort4x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 mul(ushort4x4 a, ushort4x3 b)
        {
            return new ushort4x3(
                (a.c0 * b.c0.xxxx + a.c1 * b.c0.yyyy) + (a.c2 * b.c0.zzzz + a.c3 * b.c0.wwww),
                (a.c0 * b.c1.xxxx + a.c1 * b.c1.yyyy) + (a.c2 * b.c1.zzzz + a.c3 * b.c1.wwww),
                (a.c0 * b.c2.xxxx + a.c1 * b.c2.yyyy) + (a.c2 * b.c2.zzzz + a.c3 * b.c2.wwww));
        }

        /// <summary>		Returns the <see cref="MaxMath.ushort4x4"/> result of a matrix multiplication between a <see cref="MaxMath.ushort4x4"/> and a <see cref="MaxMath.ushort4x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x4 mul(ushort4x4 a, ushort4x4 b)
        {
            return new ushort4x4(
                (a.c0 * b.c0.xxxx + a.c1 * b.c0.yyyy) + (a.c2 * b.c0.zzzz + a.c3 * b.c0.wwww),
                (a.c0 * b.c1.xxxx + a.c1 * b.c1.yyyy) + (a.c2 * b.c1.zzzz + a.c3 * b.c1.wwww),
                (a.c0 * b.c2.xxxx + a.c1 * b.c2.yyyy) + (a.c2 * b.c2.zzzz + a.c3 * b.c2.wwww),
                (a.c0 * b.c3.xxxx + a.c1 * b.c3.yyyy) + (a.c2 * b.c3.zzzz + a.c3 * b.c3.wwww));
        }


        /// <summary>		Returns the <see cref="sbyte"/> result of a matrix multiplication between an <see cref="MaxMath.sbyte2"/> row vector and an <see cref="MaxMath.sbyte2"/> column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int mul(sbyte2 a, sbyte2 b)
        {
            return dot(a, b);
        }

        /// <summary>		Returns the <see cref="MaxMath.sbyte2"/> row vector result of a matrix multiplication between an <see cref="MaxMath.sbyte2"/> row vector and an <see cref="MaxMath.sbyte2x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 mul(sbyte2 a, sbyte2x2 b)
        {
            return new sbyte2((sbyte)dot(a, b.c0), (sbyte)dot(a, b.c1));
        }

        /// <summary>		Returns the <see cref="MaxMath.sbyte3"/> row vector result of a matrix multiplication between an <see cref="MaxMath.sbyte2"/> row vector and an <see cref="MaxMath.sbyte2x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 mul(sbyte2 a, sbyte2x3 b)
        {
            return new sbyte3((sbyte)dot(a, b.c0), (sbyte)dot(a, b.c1), (sbyte)dot(a, b.c2));
        }

        /// <summary>		Returns the <see cref="MaxMath.sbyte4"/> row vector result of a matrix multiplication between an <see cref="MaxMath.sbyte2"/> row vector and an <see cref="MaxMath.sbyte2x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 mul(sbyte2 a, sbyte2x4 b)
        {
            return new sbyte4((sbyte)dot(a, b.c0), (sbyte)dot(a, b.c1), (sbyte)dot(a, b.c2), (sbyte)dot(a, b.c3));
        }

        /// <summary>		Returns the <see cref="sbyte"/> result of a matrix multiplication between an <see cref="MaxMath.sbyte3"/> row vector and an <see cref="MaxMath.sbyte3"/> column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int mul(sbyte3 a, sbyte3 b)
        {
            return dot(a, b);
        }

        /// <summary>		Returns the <see cref="MaxMath.sbyte2"/> row vector result of a matrix multiplication between an <see cref="MaxMath.sbyte3"/> row vector and an <see cref="MaxMath.sbyte3x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 mul(sbyte3 a, sbyte3x2 b)
        {
            return new sbyte2((sbyte)dot(a, b.c0), (sbyte)dot(a, b.c1));
        }

        /// <summary>		Returns the <see cref="MaxMath.sbyte3"/> row vector result of a matrix multiplication between an <see cref="MaxMath.sbyte3"/> row vector and an <see cref="MaxMath.sbyte3x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 mul(sbyte3 a, sbyte3x3 b)
        {
            return new sbyte3((sbyte)dot(a, b.c0), (sbyte)dot(a, b.c1), (sbyte)dot(a, b.c2));
        }

        /// <summary>		Returns the <see cref="MaxMath.sbyte4"/> row vector result of a matrix multiplication between an <see cref="MaxMath.sbyte3"/> row vector and an <see cref="MaxMath.sbyte3x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 mul(sbyte3 a, sbyte3x4 b)
        {
            return new sbyte4((sbyte)dot(a, b.c0), (sbyte)dot(a, b.c1), (sbyte)dot(a, b.c2), (sbyte)dot(a, b.c3));
        }

        /// <summary>		Returns the <see cref="sbyte"/> result of a matrix multiplication between an <see cref="MaxMath.sbyte4"/> row vector and an <see cref="MaxMath.sbyte4"/> column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int mul(sbyte4 a, sbyte4 b)
        {
            return dot(a, b);
        }

        /// <summary>		Returns the <see cref="MaxMath.sbyte2"/> row vector result of a matrix multiplication between an <see cref="MaxMath.sbyte4"/> row vector and an <see cref="MaxMath.sbyte4x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 mul(sbyte4 a, sbyte4x2 b)
        {
            return new sbyte2((sbyte)dot(a, b.c0), (sbyte)dot(a, b.c1));
        }

        /// <summary>		Returns the <see cref="MaxMath.sbyte3"/> row vector result of a matrix multiplication between an <see cref="MaxMath.sbyte4"/> row vector and an <see cref="MaxMath.sbyte4x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 mul(sbyte4 a, sbyte4x3 b)
        {
            return new sbyte3((sbyte)dot(a, b.c0), (sbyte)dot(a, b.c1), (sbyte)dot(a, b.c2));
        }

        /// <summary>		Returns the <see cref="MaxMath.sbyte4"/> row vector result of a matrix multiplication between an <see cref="MaxMath.sbyte4"/> row vector and an <see cref="MaxMath.sbyte4x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 mul(sbyte4 a, sbyte4x4 b)
        {
            return new sbyte4((sbyte)dot(a, b.c0), (sbyte)dot(a, b.c1), (sbyte)dot(a, b.c2), (sbyte)dot(a, b.c3));
        }

        /// <summary>		Returns the <see cref="MaxMath.sbyte2"/> column vector result of a matrix multiplication between an <see cref="MaxMath.sbyte2x2"/> and an <see cref="MaxMath.sbyte2"/> column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 mul(sbyte2x2 a, sbyte2 b)
        {
            return (sbyte2)mul((short2x2) a, (short2)b);
        }

        /// <summary>		Returns the <see cref="MaxMath.sbyte2x2"/> result of a matrix multiplication between an <see cref="MaxMath.sbyte2x2"/> and an <see cref="MaxMath.sbyte2x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2x2 mul(sbyte2x2 a, sbyte2x2 b)
        {
            return (sbyte2x2)mul((short2x2) a, (short2x2)b);
        }

        /// <summary>		Returns the <see cref="MaxMath.sbyte2x3"/> result of a matrix multiplication between an <see cref="MaxMath.sbyte2x2"/> and an <see cref="MaxMath.sbyte2x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2x3 mul(sbyte2x2 a, sbyte2x3 b)
        {
            return (sbyte2x3)mul((short2x2) a, (sbyte2x3)b);
        }

        /// <summary>		Returns the <see cref="MaxMath.sbyte2x4"/> result of a matrix multiplication between an <see cref="MaxMath.sbyte2x2"/> and an <see cref="MaxMath.sbyte2x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2x4 mul(sbyte2x2 a, sbyte2x4 b)
        {
            return (sbyte2x4)mul((short2x2) a, (short2x4)b);
        }

        /// <summary>		Returns the <see cref="MaxMath.sbyte2"/> column vector result of a matrix multiplication between an <see cref="MaxMath.sbyte2x3"/> and an <see cref="MaxMath.sbyte3"/> column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 mul(sbyte2x3 a, sbyte3 b)
        {
            return (sbyte2)mul((short2x3) a, (short3)b);
        }

        /// <summary>		Returns the <see cref="MaxMath.sbyte2x2"/> result of a matrix multiplication between an <see cref="MaxMath.sbyte2x3"/> and an <see cref="MaxMath.sbyte3x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2x2 mul(sbyte2x3 a, sbyte3x2 b)
        {
            return (sbyte2x2)mul((short2x3) a, (short3x2)b);
        }

        /// <summary>		Returns the <see cref="MaxMath.sbyte2x3"/> result of a matrix multiplication between an <see cref="MaxMath.sbyte2x3"/> and an <see cref="MaxMath.sbyte3x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2x3 mul(sbyte2x3 a, sbyte3x3 b)
        {
            return (sbyte2x3)mul((short2x3) a, (short3x3)b);
        }

        /// <summary>		Returns the <see cref="MaxMath.sbyte2x4"/> result of a matrix multiplication between an <see cref="MaxMath.sbyte2x3"/> and an <see cref="MaxMath.sbyte3x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2x4 mul(sbyte2x3 a, sbyte3x4 b)
        {
            return (sbyte2x4)mul((short2x3) a, (short3x4)b);
        }

        /// <summary>		Returns the <see cref="MaxMath.sbyte2"/> column vector result of a matrix multiplication between an <see cref="MaxMath.sbyte2x4"/> and an <see cref="MaxMath.sbyte4"/> column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 mul(sbyte2x4 a, sbyte4 b)
        {
            return (sbyte2)mul((short2x4) a, (short4)b);
        }

        /// <summary>		Returns the <see cref="MaxMath.sbyte2x2"/> result of a matrix multiplication between an <see cref="MaxMath.sbyte2x4"/> and an <see cref="MaxMath.sbyte4x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2x2 mul(sbyte2x4 a, sbyte4x2 b)
        {
            return (sbyte2x2)mul((short2x4) a, (short4x2)b);
        }

        /// <summary>		Returns the <see cref="MaxMath.sbyte2x3"/> result of a matrix multiplication between an <see cref="MaxMath.sbyte2x4"/> and an <see cref="MaxMath.sbyte4x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2x3 mul(sbyte2x4 a, sbyte4x3 b)
        {
            return (sbyte2x3)mul((short2x4) a, (short4x3)b);
        }

        /// <summary>		Returns the <see cref="MaxMath.sbyte2x4"/> result of a matrix multiplication between an <see cref="MaxMath.sbyte2x4"/> and an <see cref="MaxMath.sbyte4x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2x4 mul(sbyte2x4 a, sbyte4x4 b)
        {
            return (sbyte2x4)mul((short2x4) a, (short4x4)b);
        }

        /// <summary>		Returns the <see cref="MaxMath.sbyte3"/> column vector result of a matrix multiplication between an <see cref="MaxMath.sbyte3x2"/> and an <see cref="MaxMath.sbyte2"/> column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 mul(sbyte3x2 a, sbyte2 b)
        {
            return (sbyte3)mul((short3x2) a, (short2)b);
        }

        /// <summary>		Returns the <see cref="MaxMath.sbyte3x2"/> result of a matrix multiplication between an <see cref="MaxMath.sbyte3x2"/> and an <see cref="MaxMath.sbyte2x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3x2 mul(sbyte3x2 a, sbyte2x2 b)
        {
            return (sbyte3x2)mul((short3x2) a, (short2x2)b);
        }

        /// <summary>		Returns the <see cref="MaxMath.sbyte3x3"/> result of a matrix multiplication between an <see cref="MaxMath.sbyte3x2"/> and an <see cref="MaxMath.sbyte2x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3x3 mul(sbyte3x2 a, sbyte2x3 b)
        {
            return (sbyte3x3)mul((short3x2) a, (short2x3)b);
        }

        /// <summary>		Returns the <see cref="MaxMath.sbyte3x4"/> result of a matrix multiplication between an <see cref="MaxMath.sbyte3x2"/> and an <see cref="MaxMath.sbyte2x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3x4 mul(sbyte3x2 a, sbyte2x4 b)
        {
            return (sbyte3x4)mul((short3x2) a, (short2x4)b);
        }

        /// <summary>		Returns the <see cref="MaxMath.sbyte3"/> column vector result of a matrix multiplication between an <see cref="MaxMath.sbyte3x3"/> and an <see cref="MaxMath.sbyte3"/> column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 mul(sbyte3x3 a, sbyte3 b)
        {
            return (sbyte3)mul((short3x3) a, (short3)b);
        }

        /// <summary>		Returns the <see cref="MaxMath.sbyte3x2"/> result of a matrix multiplication between an <see cref="MaxMath.sbyte3x3"/> and an <see cref="MaxMath.sbyte3x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3x2 mul(sbyte3x3 a, sbyte3x2 b)
        {
            return (sbyte3x2)mul((short3x3) a, (short3x2)b);
        }

        /// <summary>		Returns the <see cref="MaxMath.sbyte3x3"/> result of a matrix multiplication between an <see cref="MaxMath.sbyte3x3"/> and an <see cref="MaxMath.sbyte3x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3x3 mul(sbyte3x3 a, sbyte3x3 b)
        {
            return (sbyte3x3)mul((short3x3) a, (short3x3)b);
        }

        /// <summary>		Returns the <see cref="MaxMath.sbyte3x4"/> result of a matrix multiplication between an <see cref="MaxMath.sbyte3x3"/> and an <see cref="MaxMath.sbyte3x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3x4 mul(sbyte3x3 a, sbyte3x4 b)
        {
            return (sbyte3x4)mul((short3x3) a, (short3x4)b);
        }

        /// <summary>		Returns the <see cref="MaxMath.sbyte3"/> column vector result of a matrix multiplication between an <see cref="MaxMath.sbyte3x4"/> and an <see cref="MaxMath.sbyte4"/> column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 mul(sbyte3x4 a, sbyte4 b)
        {
            return (sbyte3)mul((short3x4) a, (short4)b);
        }

        /// <summary>		Returns the <see cref="MaxMath.sbyte3x2"/> result of a matrix multiplication between an <see cref="MaxMath.sbyte3x4"/> and an <see cref="MaxMath.sbyte4x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3x2 mul(sbyte3x4 a, sbyte4x2 b)
        {
            return (sbyte3x2)mul((short3x4) a, (short4x2)b);
        }

        /// <summary>		Returns the <see cref="MaxMath.sbyte3x3"/> result of a matrix multiplication between an <see cref="MaxMath.sbyte3x4"/> and an <see cref="MaxMath.sbyte4x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3x3 mul(sbyte3x4 a, sbyte4x3 b)
        {
            return (sbyte3x3)mul((short3x4) a, (short4x3)b);
        }

        /// <summary>		Returns the <see cref="MaxMath.sbyte3x4"/> result of a matrix multiplication between an <see cref="MaxMath.sbyte3x4"/> and an <see cref="MaxMath.sbyte4x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3x4 mul(sbyte3x4 a, sbyte4x4 b)
        {
            return (sbyte3x4)mul((short3x4) a, (short4x4)b);
        }

        /// <summary>		Returns the <see cref="MaxMath.sbyte4"/> column vector result of a matrix multiplication between an <see cref="MaxMath.sbyte4x2"/> and an <see cref="MaxMath.sbyte2"/> column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 mul(sbyte4x2 a, sbyte2 b)
        {
            return (sbyte4)mul((short4x2) a, (short2)b);
        }

        /// <summary>		Returns the <see cref="MaxMath.sbyte4x2"/> result of a matrix multiplication between an <see cref="MaxMath.sbyte4x2"/> and an <see cref="MaxMath.sbyte2x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4x2 mul(sbyte4x2 a, sbyte2x2 b)
        {
            return (sbyte4x2)mul((short4x2) a, (short2x2)b);
        }

        /// <summary>		Returns the <see cref="MaxMath.sbyte4x3"/> result of a matrix multiplication between an <see cref="MaxMath.sbyte4x2"/> and an <see cref="MaxMath.sbyte2x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4x3 mul(sbyte4x2 a, sbyte2x3 b)
        {
            return (sbyte4x3)mul((short4x2) a, (short2x3)b);
        }

        /// <summary>		Returns the <see cref="MaxMath.sbyte4x4"/> result of a matrix multiplication between an <see cref="MaxMath.sbyte4x2"/> and an <see cref="MaxMath.sbyte2x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4x4 mul(sbyte4x2 a, sbyte2x4 b)
        {
            return (sbyte4x4)mul((short4x2) a, (short2x4)b);
        }

        /// <summary>		Returns the <see cref="MaxMath.sbyte4"/> column vector result of a matrix multiplication between an <see cref="MaxMath.sbyte4x3"/> and an <see cref="MaxMath.sbyte3"/> column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 mul(sbyte4x3 a, sbyte3 b)
        {
            return (sbyte4)mul((short4x3) a, (short3)b);
        }

        /// <summary>		Returns the <see cref="MaxMath.sbyte4x2"/> result of a matrix multiplication between an <see cref="MaxMath.sbyte4x3"/> and an <see cref="MaxMath.sbyte3x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4x2 mul(sbyte4x3 a, sbyte3x2 b)
        {
            return (sbyte4x2)mul((short4x3) a, (short3x2)b);
        }

        /// <summary>		Returns the <see cref="MaxMath.sbyte4x3"/> result of a matrix multiplication between an <see cref="MaxMath.sbyte4x3"/> and an <see cref="MaxMath.sbyte3x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4x3 mul(sbyte4x3 a, sbyte3x3 b)
        {
            return (sbyte4x3)mul((short4x3) a, (short3x3)b);
        }

        /// <summary>		Returns the <see cref="MaxMath.sbyte4x4"/> result of a matrix multiplication between an <see cref="MaxMath.sbyte4x3"/> and an <see cref="MaxMath.sbyte3x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4x4 mul(sbyte4x3 a, sbyte3x4 b)
        {
            return (sbyte4x4)mul((short4x3) a, (short3x4)b);
        }

        /// <summary>		Returns the <see cref="MaxMath.sbyte4"/> column vector result of a matrix multiplication between an <see cref="MaxMath.sbyte4x4"/> and an <see cref="MaxMath.sbyte4"/> column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 mul(sbyte4x4 a, sbyte4 b)
        {
            return (sbyte4)mul((short4x4) a, (short4)b);
        }

        /// <summary>		Returns the <see cref="MaxMath.sbyte4x2"/> result of a matrix multiplication between an <see cref="MaxMath.sbyte4x4"/> and an <see cref="MaxMath.sbyte4x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4x2 mul(sbyte4x4 a, sbyte4x2 b)
        {
            return (sbyte4x2)mul((short4x4) a, (short4x2)b);
        }

        /// <summary>		Returns the <see cref="MaxMath.sbyte4x3"/> result of a matrix multiplication between an <see cref="MaxMath.sbyte4x4"/> and an <see cref="MaxMath.sbyte4x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4x3 mul(sbyte4x4 a, sbyte4x3 b)
        {
            return (sbyte4x3)mul((short4x4) a, (short4x3)b);
        }

        /// <summary>		Returns the <see cref="MaxMath.sbyte4x4"/> result of a matrix multiplication between an <see cref="MaxMath.sbyte4x4"/> and an <see cref="MaxMath.sbyte4x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4x4 mul(sbyte4x4 a, sbyte4x4 b)
        {
            return (sbyte4x4)mul((short4x4) a, (short4x4)b);
        }


        /// <summary>		Returns the <see cref="byte"/> result of a matrix multiplication between an <see cref="byte2"/> row vector and an <see cref="byte2"/> column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint mul(byte2 a, byte2 b)
        {
            return dot(a, b);
        }

        /// <summary>		Returns the <see cref="byte2"/> row vector result of a matrix multiplication between an <see cref="byte2"/> row vector and an <see cref="byte2x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 mul(byte2 a, byte2x2 b)
        {
            return new byte2((byte)dot(a, b.c0), (byte)dot(a, b.c1));
        }

        /// <summary>		Returns the <see cref="byte3"/> row vector result of a matrix multiplication between an <see cref="byte2"/> row vector and an <see cref="byte2x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 mul(byte2 a, byte2x3 b)
        {
            return new byte3((byte)dot(a, b.c0), (byte)dot(a, b.c1), (byte)dot(a, b.c2));
        }

        /// <summary>		Returns the <see cref="MaxMath.byte4"/> row vector result of a matrix multiplication between an <see cref="byte2"/> row vector and an <see cref="byte2x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 mul(byte2 a, byte2x4 b)
        {
            return new byte4((byte)dot(a, b.c0), (byte)dot(a, b.c1), (byte)dot(a, b.c2), (byte)dot(a, b.c3));
        }

        /// <summary>		Returns the <see cref="byte"/> result of a matrix multiplication between an <see cref="byte3"/> row vector and an <see cref="byte3"/> column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint mul(byte3 a, byte3 b)
        {
            return dot(a, b);
        }

        /// <summary>		Returns the <see cref="byte2"/> row vector result of a matrix multiplication between an <see cref="byte3"/> row vector and an <see cref="byte3x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 mul(byte3 a, byte3x2 b)
        {
            return new byte2((byte)dot(a, b.c0), (byte)dot(a, b.c1));
        }

        /// <summary>		Returns the <see cref="byte3"/> row vector result of a matrix multiplication between an <see cref="byte3"/> row vector and an <see cref="byte3x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 mul(byte3 a, byte3x3 b)
        {
            return new byte3((byte)dot(a, b.c0), (byte)dot(a, b.c1), (byte)dot(a, b.c2));
        }

        /// <summary>		Returns the <see cref="MaxMath.byte4"/> row vector result of a matrix multiplication between an <see cref="byte3"/> row vector and an <see cref="byte3x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 mul(byte3 a, byte3x4 b)
        {
            return new byte4((byte)dot(a, b.c0), (byte)dot(a, b.c1), (byte)dot(a, b.c2), (byte)dot(a, b.c3));
        }

        /// <summary>		Returns the <see cref="byte"/> result of a matrix multiplication between a <see cref="MaxMath.byte4"/> row vector and a <see cref="MaxMath.byte4"/> column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint mul(byte4 a, byte4 b)
        {
            return dot(a, b);
        }

        /// <summary>		Returns the <see cref="byte2"/> row vector result of a matrix multiplication between a <see cref="MaxMath.byte4"/> row vector and a <see cref="MaxMath.byte4x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 mul(byte4 a, byte4x2 b)
        {
            return new byte2((byte)dot(a, b.c0), (byte)dot(a, b.c1));
        }

        /// <summary>		Returns the <see cref="byte3"/> row vector result of a matrix multiplication between a <see cref="MaxMath.byte4"/> row vector and a <see cref="MaxMath.byte4x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 mul(byte4 a, byte4x3 b)
        {
            return new byte3((byte)dot(a, b.c0), (byte)dot(a, b.c1), (byte)dot(a, b.c2));
        }

        /// <summary>		Returns the <see cref="MaxMath.byte4"/> row vector result of a matrix multiplication between a <see cref="MaxMath.byte4"/> row vector and a <see cref="MaxMath.byte4x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 mul(byte4 a, byte4x4 b)
        {
            return new byte4((byte)dot(a, b.c0), (byte)dot(a, b.c1), (byte)dot(a, b.c2), (byte)dot(a, b.c3));
        }

        /// <summary>		Returns the <see cref="byte2"/> column vector result of a matrix multiplication between an <see cref="byte2x2"/> and an <see cref="byte2"/> column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 mul(byte2x2 a, byte2 b)
        {
            return (byte2)mul((ushort2x2) a, (ushort2)b);
        }

        /// <summary>		Returns the <see cref="byte2x2"/> result of a matrix multiplication between an <see cref="byte2x2"/> and an <see cref="byte2x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2x2 mul(byte2x2 a, byte2x2 b)
        {
            return (byte2x2)mul((ushort2x2) a, (ushort2x2)b);
        }

        /// <summary>		Returns the <see cref="byte2x3"/> result of a matrix multiplication between an <see cref="byte2x2"/> and an <see cref="byte2x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2x3 mul(byte2x2 a, byte2x3 b)
        {
            return (byte2x3)mul((ushort2x2) a, (byte2x3)b);
        }

        /// <summary>		Returns the <see cref="byte2x4"/> result of a matrix multiplication between an <see cref="byte2x2"/> and an <see cref="byte2x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2x4 mul(byte2x2 a, byte2x4 b)
        {
            return (byte2x4)mul((ushort2x2) a, (ushort2x4)b);
        }

        /// <summary>		Returns the <see cref="byte2"/> column vector result of a matrix multiplication between an <see cref="byte2x3"/> and an <see cref="byte3"/> column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 mul(byte2x3 a, byte3 b)
        {
            return (byte2)mul((ushort2x3) a, (ushort3)b);
        }

        /// <summary>		Returns the <see cref="byte2x2"/> result of a matrix multiplication between an <see cref="byte2x3"/> and an <see cref="byte3x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2x2 mul(byte2x3 a, byte3x2 b)
        {
            return (byte2x2)mul((ushort2x3) a, (ushort3x2)b);
        }

        /// <summary>		Returns the <see cref="byte2x3"/> result of a matrix multiplication between an <see cref="byte2x3"/> and an <see cref="byte3x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2x3 mul(byte2x3 a, byte3x3 b)
        {
            return (byte2x3)mul((ushort2x3) a, (ushort3x3)b);
        }

        /// <summary>		Returns the <see cref="byte2x4"/> result of a matrix multiplication between an <see cref="byte2x3"/> and an <see cref="byte3x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2x4 mul(byte2x3 a, byte3x4 b)
        {
            return (byte2x4)mul((ushort2x3) a, (ushort3x4)b);
        }

        /// <summary>		Returns the <see cref="byte2"/> column vector result of a matrix multiplication between an <see cref="byte2x4"/> and a <see cref="MaxMath.byte4"/> column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 mul(byte2x4 a, byte4 b)
        {
            return (byte2)mul((ushort2x4) a, (ushort4)b);
        }

        /// <summary>		Returns the <see cref="byte2x2"/> result of a matrix multiplication between an <see cref="byte2x4"/> and a <see cref="MaxMath.byte4x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2x2 mul(byte2x4 a, byte4x2 b)
        {
            return (byte2x2)mul((ushort2x4) a, (ushort4x2)b);
        }

        /// <summary>		Returns the <see cref="byte2x3"/> result of a matrix multiplication between an <see cref="byte2x4"/> and a <see cref="MaxMath.byte4x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2x3 mul(byte2x4 a, byte4x3 b)
        {
            return (byte2x3)mul((ushort2x4) a, (ushort4x3)b);
        }

        /// <summary>		Returns the <see cref="byte2x4"/> result of a matrix multiplication between an <see cref="byte2x4"/> and a <see cref="MaxMath.byte4x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2x4 mul(byte2x4 a, byte4x4 b)
        {
            return (byte2x4)mul((ushort2x4) a, (ushort4x4)b);
        }

        /// <summary>		Returns the <see cref="byte3"/> column vector result of a matrix multiplication between an <see cref="byte3x2"/> and an <see cref="byte2"/> column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 mul(byte3x2 a, byte2 b)
        {
            return (byte3)mul((ushort3x2) a, (ushort2)b);
        }

        /// <summary>		Returns the <see cref="byte3x2"/> result of a matrix multiplication between an <see cref="byte3x2"/> and an <see cref="byte2x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3x2 mul(byte3x2 a, byte2x2 b)
        {
            return (byte3x2)mul((ushort3x2) a, (ushort2x2)b);
        }

        /// <summary>		Returns the <see cref="byte3x3"/> result of a matrix multiplication between an <see cref="byte3x2"/> and an <see cref="byte2x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3x3 mul(byte3x2 a, byte2x3 b)
        {
            return (byte3x3)mul((ushort3x2) a, (ushort2x3)b);
        }

        /// <summary>		Returns the <see cref="byte3x4"/> result of a matrix multiplication between an <see cref="byte3x2"/> and an <see cref="byte2x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3x4 mul(byte3x2 a, byte2x4 b)
        {
            return (byte3x4)mul((ushort3x2) a, (ushort2x4)b);
        }

        /// <summary>		Returns the <see cref="byte3"/> column vector result of a matrix multiplication between an <see cref="byte3x3"/> and an <see cref="byte3"/> column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 mul(byte3x3 a, byte3 b)
        {
            return (byte3)mul((ushort3x3) a, (ushort3)b);
        }

        /// <summary>		Returns the <see cref="byte3x2"/> result of a matrix multiplication between an <see cref="byte3x3"/> and an <see cref="byte3x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3x2 mul(byte3x3 a, byte3x2 b)
        {
            return (byte3x2)mul((ushort3x3) a, (ushort3x2)b);
        }

        /// <summary>		Returns the <see cref="byte3x3"/> result of a matrix multiplication between an <see cref="byte3x3"/> and an <see cref="byte3x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3x3 mul(byte3x3 a, byte3x3 b)
        {
            return (byte3x3)mul((ushort3x3) a, (ushort3x3)b);
        }

        /// <summary>		Returns the <see cref="byte3x4"/> result of a matrix multiplication between an <see cref="byte3x3"/> and an <see cref="byte3x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3x4 mul(byte3x3 a, byte3x4 b)
        {
            return (byte3x4)mul((ushort3x3) a, (ushort3x4)b);
        }

        /// <summary>		Returns the <see cref="byte3"/> column vector result of a matrix multiplication between an <see cref="byte3x4"/> and a <see cref="MaxMath.byte4"/> column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 mul(byte3x4 a, byte4 b)
        {
            return (byte3)mul((ushort3x4) a, (ushort4)b);
        }

        /// <summary>		Returns the <see cref="byte3x2"/> result of a matrix multiplication between an <see cref="byte3x4"/> and a <see cref="MaxMath.byte4x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3x2 mul(byte3x4 a, byte4x2 b)
        {
            return (byte3x2)mul((ushort3x4) a, (ushort4x2)b);
        }

        /// <summary>		Returns the <see cref="byte3x3"/> result of a matrix multiplication between an <see cref="byte3x4"/> and a <see cref="MaxMath.byte4x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3x3 mul(byte3x4 a, byte4x3 b)
        {
            return (byte3x3)mul((ushort3x4) a, (ushort4x3)b);
        }

        /// <summary>		Returns the <see cref="byte3x4"/> result of a matrix multiplication between an <see cref="byte3x4"/> and a <see cref="MaxMath.byte4x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3x4 mul(byte3x4 a, byte4x4 b)
        {
            return (byte3x4)mul((ushort3x4) a, (ushort4x4)b);
        }

        /// <summary>		Returns the <see cref="MaxMath.byte4"/> column vector result of a matrix multiplication between a <see cref="MaxMath.byte4x2"/> and an <see cref="byte2"/> column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 mul(byte4x2 a, byte2 b)
        {
            return (byte4)mul((ushort4x2) a, (ushort2)b);
        }

        /// <summary>		Returns the <see cref="MaxMath.byte4x2"/> result of a matrix multiplication between a <see cref="MaxMath.byte4x2"/> and an <see cref="byte2x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4x2 mul(byte4x2 a, byte2x2 b)
        {
            return (byte4x2)mul((ushort4x2) a, (ushort2x2)b);
        }

        /// <summary>		Returns the <see cref="MaxMath.byte4x3"/> result of a matrix multiplication between a <see cref="MaxMath.byte4x2"/> and an <see cref="byte2x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4x3 mul(byte4x2 a, byte2x3 b)
        {
            return (byte4x3)mul((ushort4x2) a, (ushort2x3)b);
        }

        /// <summary>		Returns the <see cref="MaxMath.byte4x4"/> result of a matrix multiplication between a <see cref="MaxMath.byte4x2"/> and an <see cref="byte2x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4x4 mul(byte4x2 a, byte2x4 b)
        {
            return (byte4x4)mul((ushort4x2) a, (ushort2x4)b);
        }

        /// <summary>		Returns the <see cref="MaxMath.byte4"/> column vector result of a matrix multiplication between a <see cref="MaxMath.byte4x3"/> and an <see cref="byte3"/> column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 mul(byte4x3 a, byte3 b)
        {
            return (byte4)mul((ushort4x3) a, (ushort3)b);
        }

        /// <summary>		Returns the <see cref="MaxMath.byte4x2"/> result of a matrix multiplication between a <see cref="MaxMath.byte4x3"/> and an <see cref="byte3x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4x2 mul(byte4x3 a, byte3x2 b)
        {
            return (byte4x2)mul((ushort4x3) a, (ushort3x2)b);
        }

        /// <summary>		Returns the <see cref="MaxMath.byte4x3"/> result of a matrix multiplication between a <see cref="MaxMath.byte4x3"/> and an <see cref="byte3x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4x3 mul(byte4x3 a, byte3x3 b)
        {
            return (byte4x3)mul((ushort4x3) a, (ushort3x3)b);
        }

        /// <summary>		Returns the <see cref="MaxMath.byte4x4"/> result of a matrix multiplication between a <see cref="MaxMath.byte4x3"/> and an <see cref="byte3x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4x4 mul(byte4x3 a, byte3x4 b)
        {
            return (byte4x4)mul((ushort4x3) a, (ushort3x4)b);
        }

        /// <summary>		Returns the <see cref="MaxMath.byte4"/> column vector result of a matrix multiplication between a <see cref="MaxMath.byte4x4"/> and a <see cref="MaxMath.byte4"/> column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 mul(byte4x4 a, byte4 b)
        {
            return (byte4)mul((ushort4x4) a, (ushort4)b);
        }

        /// <summary>		Returns the <see cref="MaxMath.byte4x2"/> result of a matrix multiplication between a <see cref="MaxMath.byte4x4"/> and a <see cref="MaxMath.byte4x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4x2 mul(byte4x4 a, byte4x2 b)
        {
            return (byte4x2)mul((ushort4x4) a, (ushort4x2)b);
        }

        /// <summary>		Returns the <see cref="MaxMath.byte4x3"/> result of a matrix multiplication between a <see cref="MaxMath.byte4x4"/> and a <see cref="MaxMath.byte4x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4x3 mul(byte4x4 a, byte4x3 b)
        {
            return (byte4x3)mul((ushort4x4) a, (ushort4x3)b);
        }

        /// <summary>		Returns the <see cref="MaxMath.byte4x4"/> result of a matrix multiplication between a <see cref="MaxMath.byte4x4"/> and a <see cref="MaxMath.byte4x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4x4 mul(byte4x4 a, byte4x4 b)
        {
            return (byte4x4)mul((ushort4x4) a, (ushort4x4)b);
        }
    }
}