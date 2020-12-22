using System.Runtime.CompilerServices;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>		Returns the long value result of a matrix multiplication between a long2 row vector and a long2 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long mul(long2 a, long2 b)
        {
            return a.x * b.x + a.y * b.y;
        }

        /// <summary>		Returns the long2 row vector result of a matrix multiplication between a long2 row vector and a long2x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 mul(long2 a, long2x2 b)
        {
            return new long2(
                a.x * b.c0.x + a.y * b.c0.y,
                a.x * b.c1.x + a.y * b.c1.y);
        }

        /// <summary>		Returns the long3 row vector result of a matrix multiplication between a long2 row vector and a long2x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 mul(long2 a, long2x3 b)
        {
            return new long3(
                a.x * b.c0.x + a.y * b.c0.y,
                a.x * b.c1.x + a.y * b.c1.y,
                a.x * b.c2.x + a.y * b.c2.y);
        }

        /// <summary>		Returns the long4 row vector result of a matrix multiplication between a long2 row vector and a long2x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 mul(long2 a, long2x4 b)
        {
            return new long4(
                a.x * b.c0.x + a.y * b.c0.y,
                a.x * b.c1.x + a.y * b.c1.y,
                a.x * b.c2.x + a.y * b.c2.y,
                a.x * b.c3.x + a.y * b.c3.y);
        }

        /// <summary>		Returns the long value result of a matrix multiplication between a long3 row vector and a long3 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long mul(long3 a, long3 b)
        {
            return a.x * b.x + a.y * b.y + a.z * b.z;
        }

        /// <summary>		Returns the long2 row vector result of a matrix multiplication between a long3 row vector and a long3x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 mul(long3 a, long3x2 b)
        {
            return new long2(
                a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z,
                a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z);
        }

        /// <summary>		Returns the long3 row vector result of a matrix multiplication between a long3 row vector and a long3x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 mul(long3 a, long3x3 b)
        {
            return new long3(
                a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z,
                a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z,
                a.x * b.c2.x + a.y * b.c2.y + a.z * b.c2.z);
        }

        /// <summary>		Returns the long4 row vector result of a matrix multiplication between a long3 row vector and a long3x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 mul(long3 a, long3x4 b)
        {
            return new long4(
                a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z,
                a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z,
                a.x * b.c2.x + a.y * b.c2.y + a.z * b.c2.z,
                a.x * b.c3.x + a.y * b.c3.y + a.z * b.c3.z);
        }

        /// <summary>		Returns the long value result of a matrix multiplication between a long4 row vector and a long4 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long mul(long4 a, long4 b)
        {
            return a.x * b.x + a.y * b.y + a.z * b.z + a.w * b.w;
        }

        /// <summary>		Returns the long2 row vector result of a matrix multiplication between a long4 row vector and a long4x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 mul(long4 a, long4x2 b)
        {
            return new long2(
                a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z + a.w * b.c0.w,
                a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z + a.w * b.c1.w);
        }

        /// <summary>		Returns the long3 row vector result of a matrix multiplication between a long4 row vector and a long4x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 mul(long4 a, long4x3 b)
        {
            return new long3(
                a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z + a.w * b.c0.w,
                a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z + a.w * b.c1.w,
                a.x * b.c2.x + a.y * b.c2.y + a.z * b.c2.z + a.w * b.c2.w);
        }

        /// <summary>		Returns the long4 row vector result of a matrix multiplication between a long4 row vector and a long4x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 mul(long4 a, long4x4 b)
        {
            return new long4(
                a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z + a.w * b.c0.w,
                a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z + a.w * b.c1.w,
                a.x * b.c2.x + a.y * b.c2.y + a.z * b.c2.z + a.w * b.c2.w,
                a.x * b.c3.x + a.y * b.c3.y + a.z * b.c3.z + a.w * b.c3.w);
        }

        /// <summary>		Returns the long2 column vector result of a matrix multiplication between a long2x2 matrix and a long2 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 mul(long2x2 a, long2 b)
        {
            return a.c0 * b.x + a.c1 * b.y;
        }

        /// <summary>		Returns the long2x2 matrix result of a matrix multiplication between a long2x2 matrix and a long2x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 mul(long2x2 a, long2x2 b)
        {
            return new long2x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y);
        }

        /// <summary>		Returns the long2x3 matrix result of a matrix multiplication between a long2x2 matrix and a long2x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 mul(long2x2 a, long2x3 b)
        {
            return new long2x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y,
                a.c0 * b.c2.x + a.c1 * b.c2.y);
        }

        /// <summary>		Returns the long2x4 matrix result of a matrix multiplication between a long2x2 matrix and a long2x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 mul(long2x2 a, long2x4 b)
        {
            return new long2x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y,
                a.c0 * b.c2.x + a.c1 * b.c2.y,
                a.c0 * b.c3.x + a.c1 * b.c3.y);
        }

        /// <summary>		Returns the long2 column vector result of a matrix multiplication between a long2x3 matrix and a long3 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 mul(long2x3 a, long3 b)
        {
            return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z;
        }

        /// <summary>		Returns the long2x2 matrix result of a matrix multiplication between a long2x3 matrix and a long3x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 mul(long2x3 a, long3x2 b)
        {
            return new long2x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z);
        }

        /// <summary>		Returns the long2x3 matrix result of a matrix multiplication between a long2x3 matrix and a long3x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 mul(long2x3 a, long3x3 b)
        {
            return new long2x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z);
        }

        /// <summary>		Returns the long2x4 matrix result of a matrix multiplication between a long2x3 matrix and a long3x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 mul(long2x3 a, long3x4 b)
        {
            return new long2x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z,
                a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z);
        }

        /// <summary>		Returns the long2 column vector result of a matrix multiplication between a long2x4 matrix and a long4 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 mul(long2x4 a, long4 b)
        {
            return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z + a.c3 * b.w;
        }

        /// <summary>		Returns the long2x2 matrix result of a matrix multiplication between a long2x4 matrix and a long4x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 mul(long2x4 a, long4x2 b)
        {
            return new long2x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w);
        }

        /// <summary>		Returns the long2x3 matrix result of a matrix multiplication between a long2x4 matrix and a long4x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 mul(long2x4 a, long4x3 b)
        {
            return new long2x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w);
        }

        /// <summary>		Returns the long2x4 matrix result of a matrix multiplication between a long2x4 matrix and a long4x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 mul(long2x4 a, long4x4 b)
        {
            return new long2x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w,
                a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z + a.c3 * b.c3.w);
        }

        /// <summary>		Returns the long3 column vector result of a matrix multiplication between a long3x2 matrix and a long2 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 mul(long3x2 a, long2 b)
        {
            return a.c0 * b.x + a.c1 * b.y;
        }

        /// <summary>		Returns the long3x2 matrix result of a matrix multiplication between a long3x2 matrix and a long2x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 mul(long3x2 a, long2x2 b)
        {
            return new long3x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y);
        }

        /// <summary>		Returns the long3x3 matrix result of a matrix multiplication between a long3x2 matrix and a long2x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x3 mul(long3x2 a, long2x3 b)
        {
            return new long3x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y,
                a.c0 * b.c2.x + a.c1 * b.c2.y);
        }

        /// <summary>		Returns the long3x4 matrix result of a matrix multiplication between a long3x2 matrix and a long2x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x4 mul(long3x2 a, long2x4 b)
        {
            return new long3x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y,
                a.c0 * b.c2.x + a.c1 * b.c2.y,
                a.c0 * b.c3.x + a.c1 * b.c3.y);
        }

        /// <summary>		Returns the long3 column vector result of a matrix multiplication between a long3x3 matrix and a long3 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 mul(long3x3 a, long3 b)
        {
            return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z;
        }

        /// <summary>		Returns the long3x2 matrix result of a matrix multiplication between a long3x3 matrix and a long3x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 mul(long3x3 a, long3x2 b)
        {
            return new long3x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z);
        }

        /// <summary>		Returns the long3x3 matrix result of a matrix multiplication between a long3x3 matrix and a long3x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x3 mul(long3x3 a, long3x3 b)
        {
            return new long3x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z);
        }

        /// <summary>		Returns the long3x4 matrix result of a matrix multiplication between a long3x3 matrix and a long3x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x4 mul(long3x3 a, long3x4 b)
        {
            return new long3x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z,
                a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z);
        }

        /// <summary>		Returns the long3 column vector result of a matrix multiplication between a long3x4 matrix and a long4 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 mul(long3x4 a, long4 b)
        {
            return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z + a.c3 * b.w;
        }

        /// <summary>		Returns the long3x2 matrix result of a matrix multiplication between a long3x4 matrix and a long4x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x2 mul(long3x4 a, long4x2 b)
        {
            return new long3x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w);
        }

        /// <summary>		Returns the long3x3 matrix result of a matrix multiplication between a long3x4 matrix and a long4x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x3 mul(long3x4 a, long4x3 b)
        {
            return new long3x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w);
        }

        /// <summary>		Returns the long3x4 matrix result of a matrix multiplication between a long3x4 matrix and a long4x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3x4 mul(long3x4 a, long4x4 b)
        {
            return new long3x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w,
                a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z + a.c3 * b.c3.w);
        }

        /// <summary>		Returns the long4 column vector result of a matrix multiplication between a long4x2 matrix and a long2 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 mul(long4x2 a, long2 b)
        {
            return a.c0 * b.x + a.c1 * b.y;
        }

        /// <summary>		Returns the long4x2 matrix result of a matrix multiplication between a long4x2 matrix and a long2x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 mul(long4x2 a, long2x2 b)
        {
            return new long4x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y);
        }

        /// <summary>		Returns the long4x3 matrix result of a matrix multiplication between a long4x2 matrix and a long2x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x3 mul(long4x2 a, long2x3 b)
        {
            return new long4x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y,
                a.c0 * b.c2.x + a.c1 * b.c2.y);
        }

        /// <summary>		Returns the long4x4 matrix result of a matrix multiplication between a long4x2 matrix and a long2x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x4 mul(long4x2 a, long2x4 b)
        {
            return new long4x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y,
                a.c0 * b.c2.x + a.c1 * b.c2.y,
                a.c0 * b.c3.x + a.c1 * b.c3.y);
        }

        /// <summary>		Returns the long4 column vector result of a matrix multiplication between a long4x3 matrix and a long3 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 mul(long4x3 a, long3 b)
        {
            return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z;
        }

        /// <summary>		Returns the long4x2 matrix result of a matrix multiplication between a long4x3 matrix and a long3x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 mul(long4x3 a, long3x2 b)
        {
            return new long4x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z);
        }

        /// <summary>		Returns the long4x3 matrix result of a matrix multiplication between a long4x3 matrix and a long3x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x3 mul(long4x3 a, long3x3 b)
        {
            return new long4x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z);
        }

        /// <summary>		Returns the long4x4 matrix result of a matrix multiplication between a long4x3 matrix and a long3x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x4 mul(long4x3 a, long3x4 b)
        {
            return new long4x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z,
                a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z);
        }

        /// <summary>		Returns the long4 column vector result of a matrix multiplication between a long4x4 matrix and a long4 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 mul(long4x4 a, long4 b)
        {
            return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z + a.c3 * b.w;
        }

        /// <summary>		Returns the long4x2 matrix result of a matrix multiplication between a long4x4 matrix and a long4x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x2 mul(long4x4 a, long4x2 b)
        {
            return new long4x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w);
        }

        /// <summary>		Returns the long4x3 matrix result of a matrix multiplication between a long4x4 matrix and a long4x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x3 mul(long4x4 a, long4x3 b)
        {
            return new long4x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w);
        }

        /// <summary>		Returns the long4x4 matrix result of a matrix multiplication between a long4x4 matrix and a long4x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x4 mul(long4x4 a, long4x4 b)
        {
            return new long4x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w,
                a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z + a.c3 * b.c3.w);
        }


        /// <summary>		Returns the ulong value result of a matrix multiplication between a ulong2 row vector and a ulong2 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong mul(ulong2 a, ulong2 b)
        {
            return a.x * b.x + a.y * b.y;
        }

        /// <summary>		Returns the ulong2 row vector result of a matrix multiplication between a ulong2 row vector and a ulong2x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 mul(ulong2 a, ulong2x2 b)
        {
            return new ulong2(
                a.x * b.c0.x + a.y * b.c0.y,
                a.x * b.c1.x + a.y * b.c1.y);
        }

        /// <summary>		Returns the ulong3 row vector result of a matrix multiplication between a ulong2 row vector and a ulong2x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 mul(ulong2 a, ulong2x3 b)
        {
            return new ulong3(
                a.x * b.c0.x + a.y * b.c0.y,
                a.x * b.c1.x + a.y * b.c1.y,
                a.x * b.c2.x + a.y * b.c2.y);
        }

        /// <summary>		Returns the ulong4 row vector result of a matrix multiplication between a ulong2 row vector and a ulong2x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 mul(ulong2 a, ulong2x4 b)
        {
            return new ulong4(
                a.x * b.c0.x + a.y * b.c0.y,
                a.x * b.c1.x + a.y * b.c1.y,
                a.x * b.c2.x + a.y * b.c2.y,
                a.x * b.c3.x + a.y * b.c3.y);
        }

        /// <summary>		Returns the ulong value result of a matrix multiplication between a ulong3 row vector and a ulong3 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong mul(ulong3 a, ulong3 b)
        {
            return a.x * b.x + a.y * b.y + a.z * b.z;
        }

        /// <summary>		Returns the ulong2 row vector result of a matrix multiplication between a ulong3 row vector and a ulong3x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 mul(ulong3 a, ulong3x2 b)
        {
            return new ulong2(
                a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z,
                a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z);
        }

        /// <summary>		Returns the ulong3 row vector result of a matrix multiplication between a ulong3 row vector and a ulong3x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 mul(ulong3 a, ulong3x3 b)
        {
            return new ulong3(
                a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z,
                a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z,
                a.x * b.c2.x + a.y * b.c2.y + a.z * b.c2.z);
        }

        /// <summary>		Returns the ulong4 row vector result of a matrix multiplication between a ulong3 row vector and a ulong3x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 mul(ulong3 a, ulong3x4 b)
        {
            return new ulong4(
                a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z,
                a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z,
                a.x * b.c2.x + a.y * b.c2.y + a.z * b.c2.z,
                a.x * b.c3.x + a.y * b.c3.y + a.z * b.c3.z);
        }

        /// <summary>		Returns the ulong value result of a matrix multiplication between a ulong4 row vector and a ulong4 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong mul(ulong4 a, ulong4 b)
        {
            return a.x * b.x + a.y * b.y + a.z * b.z + a.w * b.w;
        }

        /// <summary>		Returns the ulong2 row vector result of a matrix multiplication between a ulong4 row vector and a ulong4x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 mul(ulong4 a, ulong4x2 b)
        {
            return new ulong2(
                a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z + a.w * b.c0.w,
                a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z + a.w * b.c1.w);
        }

        /// <summary>		Returns the ulong3 row vector result of a matrix multiplication between a ulong4 row vector and a ulong4x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 mul(ulong4 a, ulong4x3 b)
        {
            return new ulong3(
                a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z + a.w * b.c0.w,
                a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z + a.w * b.c1.w,
                a.x * b.c2.x + a.y * b.c2.y + a.z * b.c2.z + a.w * b.c2.w);
        }

        /// <summary>		Returns the ulong4 row vector result of a matrix multiplication between a ulong4 row vector and a ulong4x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 mul(ulong4 a, ulong4x4 b)
        {
            return new ulong4(
                a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z + a.w * b.c0.w,
                a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z + a.w * b.c1.w,
                a.x * b.c2.x + a.y * b.c2.y + a.z * b.c2.z + a.w * b.c2.w,
                a.x * b.c3.x + a.y * b.c3.y + a.z * b.c3.z + a.w * b.c3.w);
        }

        /// <summary>		Returns the ulong2 column vector result of a matrix multiplication between a ulong2x2 matrix and a ulong2 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 mul(ulong2x2 a, ulong2 b)
        {
            return a.c0 * b.x + a.c1 * b.y;
        }

        /// <summary>		Returns the ulong2x2 matrix result of a matrix multiplication between a ulong2x2 matrix and a ulong2x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x2 mul(ulong2x2 a, ulong2x2 b)
        {
            return new ulong2x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y);
        }

        /// <summary>		Returns the ulong2x3 matrix result of a matrix multiplication between a ulong2x2 matrix and a ulong2x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 mul(ulong2x2 a, ulong2x3 b)
        {
            return new ulong2x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y,
                a.c0 * b.c2.x + a.c1 * b.c2.y);
        }

        /// <summary>		Returns the ulong2x4 matrix result of a matrix multiplication between a ulong2x2 matrix and a ulong2x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x4 mul(ulong2x2 a, ulong2x4 b)
        {
            return new ulong2x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y,
                a.c0 * b.c2.x + a.c1 * b.c2.y,
                a.c0 * b.c3.x + a.c1 * b.c3.y);
        }

        /// <summary>		Returns the ulong2 column vector result of a matrix multiplication between a ulong2x3 matrix and a ulong3 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 mul(ulong2x3 a, ulong3 b)
        {
            return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z;
        }

        /// <summary>		Returns the ulong2x2 matrix result of a matrix multiplication between a ulong2x3 matrix and a ulong3x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x2 mul(ulong2x3 a, ulong3x2 b)
        {
            return new ulong2x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z);
        }

        /// <summary>		Returns the ulong2x3 matrix result of a matrix multiplication between a ulong2x3 matrix and a ulong3x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 mul(ulong2x3 a, ulong3x3 b)
        {
            return new ulong2x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z);
        }

        /// <summary>		Returns the ulong2x4 matrix result of a matrix multiplication between a ulong2x3 matrix and a ulong3x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x4 mul(ulong2x3 a, ulong3x4 b)
        {
            return new ulong2x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z,
                a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z);
        }

        /// <summary>		Returns the ulong2 column vector result of a matrix multiplication between a ulong2x4 matrix and a ulong4 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 mul(ulong2x4 a, ulong4 b)
        {
            return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z + a.c3 * b.w;
        }

        /// <summary>		Returns the ulong2x2 matrix result of a matrix multiplication between a ulong2x4 matrix and a ulong4x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x2 mul(ulong2x4 a, ulong4x2 b)
        {
            return new ulong2x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w);
        }

        /// <summary>		Returns the ulong2x3 matrix result of a matrix multiplication between a ulong2x4 matrix and a ulong4x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 mul(ulong2x4 a, ulong4x3 b)
        {
            return new ulong2x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w);
        }

        /// <summary>		Returns the ulong2x4 matrix result of a matrix multiplication between a ulong2x4 matrix and a ulong4x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x4 mul(ulong2x4 a, ulong4x4 b)
        {
            return new ulong2x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w,
                a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z + a.c3 * b.c3.w);
        }

        /// <summary>		Returns the ulong3 column vector result of a matrix multiplication between a ulong3x2 matrix and a ulong2 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 mul(ulong3x2 a, ulong2 b)
        {
            return a.c0 * b.x + a.c1 * b.y;
        }

        /// <summary>		Returns the ulong3x2 matrix result of a matrix multiplication between a ulong3x2 matrix and a ulong2x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 mul(ulong3x2 a, ulong2x2 b)
        {
            return new ulong3x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y);
        }

        /// <summary>		Returns the ulong3x3 matrix result of a matrix multiplication between a ulong3x2 matrix and a ulong2x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x3 mul(ulong3x2 a, ulong2x3 b)
        {
            return new ulong3x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y,
                a.c0 * b.c2.x + a.c1 * b.c2.y);
        }

        /// <summary>		Returns the ulong3x4 matrix result of a matrix multiplication between a ulong3x2 matrix and a ulong2x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 mul(ulong3x2 a, ulong2x4 b)
        {
            return new ulong3x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y,
                a.c0 * b.c2.x + a.c1 * b.c2.y,
                a.c0 * b.c3.x + a.c1 * b.c3.y);
        }

        /// <summary>		Returns the ulong3 column vector result of a matrix multiplication between a ulong3x3 matrix and a ulong3 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 mul(ulong3x3 a, ulong3 b)
        {
            return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z;
        }

        /// <summary>		Returns the ulong3x2 matrix result of a matrix multiplication between a ulong3x3 matrix and a ulong3x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 mul(ulong3x3 a, ulong3x2 b)
        {
            return new ulong3x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z);
        }

        /// <summary>		Returns the ulong3x3 matrix result of a matrix multiplication between a ulong3x3 matrix and a ulong3x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x3 mul(ulong3x3 a, ulong3x3 b)
        {
            return new ulong3x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z);
        }

        /// <summary>		Returns the ulong3x4 matrix result of a matrix multiplication between a ulong3x3 matrix and a ulong3x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 mul(ulong3x3 a, ulong3x4 b)
        {
            return new ulong3x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z,
                a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z);
        }

        /// <summary>		Returns the ulong3 column vector result of a matrix multiplication between a ulong3x4 matrix and a ulong4 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 mul(ulong3x4 a, ulong4 b)
        {
            return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z + a.c3 * b.w;
        }

        /// <summary>		Returns the ulong3x2 matrix result of a matrix multiplication between a ulong3x4 matrix and a ulong4x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 mul(ulong3x4 a, ulong4x2 b)
        {
            return new ulong3x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w);
        }

        /// <summary>		Returns the ulong3x3 matrix result of a matrix multiplication between a ulong3x4 matrix and a ulong4x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x3 mul(ulong3x4 a, ulong4x3 b)
        {
            return new ulong3x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w);
        }

        /// <summary>		Returns the ulong3x4 matrix result of a matrix multiplication between a ulong3x4 matrix and a ulong4x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 mul(ulong3x4 a, ulong4x4 b)
        {
            return new ulong3x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w,
                a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z + a.c3 * b.c3.w);
        }

        /// <summary>		Returns the ulong4 column vector result of a matrix multiplication between a ulong4x2 matrix and a ulong2 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 mul(ulong4x2 a, ulong2 b)
        {
            return a.c0 * b.x + a.c1 * b.y;
        }

        /// <summary>		Returns the ulong4x2 matrix result of a matrix multiplication between a ulong4x2 matrix and a ulong2x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x2 mul(ulong4x2 a, ulong2x2 b)
        {
            return new ulong4x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y);
        }

        /// <summary>		Returns the ulong4x3 matrix result of a matrix multiplication between a ulong4x2 matrix and a ulong2x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x3 mul(ulong4x2 a, ulong2x3 b)
        {
            return new ulong4x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y,
                a.c0 * b.c2.x + a.c1 * b.c2.y);
        }

        /// <summary>		Returns the ulong4x4 matrix result of a matrix multiplication between a ulong4x2 matrix and a ulong2x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 mul(ulong4x2 a, ulong2x4 b)
        {
            return new ulong4x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y,
                a.c0 * b.c2.x + a.c1 * b.c2.y,
                a.c0 * b.c3.x + a.c1 * b.c3.y);
        }

        /// <summary>		Returns the ulong4 column vector result of a matrix multiplication between a ulong4x3 matrix and a ulong3 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 mul(ulong4x3 a, ulong3 b)
        {
            return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z;
        }

        /// <summary>		Returns the ulong4x2 matrix result of a matrix multiplication between a ulong4x3 matrix and a ulong3x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x2 mul(ulong4x3 a, ulong3x2 b)
        {
            return new ulong4x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z);
        }

        /// <summary>		Returns the ulong4x3 matrix result of a matrix multiplication between a ulong4x3 matrix and a ulong3x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x3 mul(ulong4x3 a, ulong3x3 b)
        {
            return new ulong4x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z);
        }

        /// <summary>		Returns the ulong4x4 matrix result of a matrix multiplication between a ulong4x3 matrix and a ulong3x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 mul(ulong4x3 a, ulong3x4 b)
        {
            return new ulong4x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z,
                a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z);
        }

        /// <summary>		Returns the ulong4 column vector result of a matrix multiplication between a ulong4x4 matrix and a ulong4 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 mul(ulong4x4 a, ulong4 b)
        {
            return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z + a.c3 * b.w;
        }

        /// <summary>		Returns the ulong4x2 matrix result of a matrix multiplication between a ulong4x4 matrix and a ulong4x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x2 mul(ulong4x4 a, ulong4x2 b)
        {
            return new ulong4x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w);
        }

        /// <summary>		Returns the ulong4x3 matrix result of a matrix multiplication between a ulong4x4 matrix and a ulong4x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x3 mul(ulong4x4 a, ulong4x3 b)
        {
            return new ulong4x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w);
        }

        /// <summary>		Returns the ulong4x4 matrix result of a matrix multiplication between a ulong4x4 matrix and a ulong4x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 mul(ulong4x4 a, ulong4x4 b)
        {
            return new ulong4x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w,
                a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z + a.c3 * b.c3.w);
        }


        /// <summary>		Returns the short value result of a matrix multiplication between a short2 row vector and a short2 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short mul(short2 a, short2 b)
        {
            return (short)(a.x * b.x + a.y * b.y);
        }

        /// <summary>		Returns the short2 row vector result of a matrix multiplication between a short2 row vector and a short2x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 mul(short2 a, short2x2 b)
        {
            return new short2(
                (short)(a.x * b.c0.x + a.y * b.c0.y),
                (short)(a.x * b.c1.x + a.y * b.c1.y));
        }

        /// <summary>		Returns the short3 row vector result of a matrix multiplication between a short2 row vector and a short2x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 mul(short2 a, short2x3 b)
        {
            return new short3(
                (short)(a.x * b.c0.x + a.y * b.c0.y),
                (short)(a.x * b.c1.x + a.y * b.c1.y),
                (short)(a.x * b.c2.x + a.y * b.c2.y));
        }

        /// <summary>		Returns the short4 row vector result of a matrix multiplication between a short2 row vector and a short2x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 mul(short2 a, short2x4 b)
        {
            return new short4(
                (short)(a.x * b.c0.x + a.y * b.c0.y),
                (short)(a.x * b.c1.x + a.y * b.c1.y),
                (short)(a.x * b.c2.x + a.y * b.c2.y),
                (short)(a.x * b.c3.x + a.y * b.c3.y));
        }

        /// <summary>		Returns the short value result of a matrix multiplication between a short3 row vector and a short3 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short mul(short3 a, short3 b)
        {
            return (short)(a.x * b.x + a.y * b.y + a.z * b.z);
        }

        /// <summary>		Returns the short2 row vector result of a matrix multiplication between a short3 row vector and a short3x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 mul(short3 a, short3x2 b)
        {
            return new short2(
                (short)(a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z),
                (short)(a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z));
        }

        /// <summary>		Returns the short3 row vector result of a matrix multiplication between a short3 row vector and a short3x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 mul(short3 a, short3x3 b)
        {
            return new short3(
                (short)(a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z),
                (short)(a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z),
                (short)(a.x * b.c2.x + a.y * b.c2.y + a.z * b.c2.z));
        }

        /// <summary>		Returns the short4 row vector result of a matrix multiplication between a short3 row vector and a short3x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 mul(short3 a, short3x4 b)
        {
            return new short4(
                (short)(a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z),
                (short)(a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z),
                (short)(a.x * b.c2.x + a.y * b.c2.y + a.z * b.c2.z),
                (short)(a.x * b.c3.x + a.y * b.c3.y + a.z * b.c3.z));
        }

        /// <summary>		Returns the short value result of a matrix multiplication between a short4 row vector and a short4 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short mul(short4 a, short4 b)
        {
            return (short)(a.x * b.x + a.y * b.y + a.z * b.z + a.w * b.w);
        }

        /// <summary>		Returns the short2 row vector result of a matrix multiplication between a short4 row vector and a short4x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 mul(short4 a, short4x2 b)
        {
            return new short2(
                (short)(a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z + a.w * b.c0.w),
                (short)(a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z + a.w * b.c1.w));
        }

        /// <summary>		Returns the short3 row vector result of a matrix multiplication between a short4 row vector and a short4x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 mul(short4 a, short4x3 b)
        {
            return new short3(
                (short)(a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z + a.w * b.c0.w),
                (short)(a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z + a.w * b.c1.w),
                (short)(a.x * b.c2.x + a.y * b.c2.y + a.z * b.c2.z + a.w * b.c2.w));
        }

        /// <summary>		Returns the short4 row vector result of a matrix multiplication between a short4 row vector and a short4x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 mul(short4 a, short4x4 b)
        {
            return new short4(
                (short)(a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z + a.w * b.c0.w),
                (short)(a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z + a.w * b.c1.w),
                (short)(a.x * b.c2.x + a.y * b.c2.y + a.z * b.c2.z + a.w * b.c2.w),
                (short)(a.x * b.c3.x + a.y * b.c3.y + a.z * b.c3.z + a.w * b.c3.w));
        }

        /// <summary>		Returns the short2 column vector result of a matrix multiplication between a short2x2 matrix and a short2 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 mul(short2x2 a, short2 b)
        {
            return a.c0 * b.x + a.c1 * b.y;
        }

        /// <summary>		Returns the short2x2 matrix result of a matrix multiplication between a short2x2 matrix and a short2x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 mul(short2x2 a, short2x2 b)
        {
            return new short2x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y);
        }

        /// <summary>		Returns the short2x3 matrix result of a matrix multiplication between a short2x2 matrix and a short2x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 mul(short2x2 a, short2x3 b)
        {
            return new short2x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y,
                a.c0 * b.c2.x + a.c1 * b.c2.y);
        }

        /// <summary>		Returns the short2x4 matrix result of a matrix multiplication between a short2x2 matrix and a short2x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x4 mul(short2x2 a, short2x4 b)
        {
            return new short2x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y,
                a.c0 * b.c2.x + a.c1 * b.c2.y,
                a.c0 * b.c3.x + a.c1 * b.c3.y);
        }

        /// <summary>		Returns the short2 column vector result of a matrix multiplication between a short2x3 matrix and a short3 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 mul(short2x3 a, short3 b)
        {
            return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z;
        }

        /// <summary>		Returns the short2x2 matrix result of a matrix multiplication between a short2x3 matrix and a short3x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 mul(short2x3 a, short3x2 b)
        {
            return new short2x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z);
        }

        /// <summary>		Returns the short2x3 matrix result of a matrix multiplication between a short2x3 matrix and a short3x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 mul(short2x3 a, short3x3 b)
        {
            return new short2x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z);
        }

        /// <summary>		Returns the short2x4 matrix result of a matrix multiplication between a short2x3 matrix and a short3x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x4 mul(short2x3 a, short3x4 b)
        {
            return new short2x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z,
                a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z);
        }

        /// <summary>		Returns the short2 column vector result of a matrix multiplication between a short2x4 matrix and a short4 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 mul(short2x4 a, short4 b)
        {
            return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z + a.c3 * b.w;
        }

        /// <summary>		Returns the short2x2 matrix result of a matrix multiplication between a short2x4 matrix and a short4x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 mul(short2x4 a, short4x2 b)
        {
            return new short2x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w);
        }

        /// <summary>		Returns the short2x3 matrix result of a matrix multiplication between a short2x4 matrix and a short4x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 mul(short2x4 a, short4x3 b)
        {
            return new short2x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w);
        }

        /// <summary>		Returns the short2x4 matrix result of a matrix multiplication between a short2x4 matrix and a short4x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x4 mul(short2x4 a, short4x4 b)
        {
            return new short2x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w,
                a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z + a.c3 * b.c3.w);
        }

        /// <summary>		Returns the short3 column vector result of a matrix multiplication between a short3x2 matrix and a short2 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 mul(short3x2 a, short2 b)
        {
            return a.c0 * b.x + a.c1 * b.y;
        }

        /// <summary>		Returns the short3x2 matrix result of a matrix multiplication between a short3x2 matrix and a short2x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3x2 mul(short3x2 a, short2x2 b)
        {
            return new short3x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y);
        }

        /// <summary>		Returns the short3x3 matrix result of a matrix multiplication between a short3x2 matrix and a short2x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3x3 mul(short3x2 a, short2x3 b)
        {
            return new short3x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y,
                a.c0 * b.c2.x + a.c1 * b.c2.y);
        }

        /// <summary>		Returns the short3x4 matrix result of a matrix multiplication between a short3x2 matrix and a short2x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3x4 mul(short3x2 a, short2x4 b)
        {
            return new short3x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y,
                a.c0 * b.c2.x + a.c1 * b.c2.y,
                a.c0 * b.c3.x + a.c1 * b.c3.y);
        }

        /// <summary>		Returns the short3 column vector result of a matrix multiplication between a short3x3 matrix and a short3 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 mul(short3x3 a, short3 b)
        {
            return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z;
        }

        /// <summary>		Returns the short3x2 matrix result of a matrix multiplication between a short3x3 matrix and a short3x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3x2 mul(short3x3 a, short3x2 b)
        {
            return new short3x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z);
        }

        /// <summary>		Returns the short3x3 matrix result of a matrix multiplication between a short3x3 matrix and a short3x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3x3 mul(short3x3 a, short3x3 b)
        {
            return new short3x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z);
        }

        /// <summary>		Returns the short3x4 matrix result of a matrix multiplication between a short3x3 matrix and a short3x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3x4 mul(short3x3 a, short3x4 b)
        {
            return new short3x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z,
                a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z);
        }

        /// <summary>		Returns the short3 column vector result of a matrix multiplication between a short3x4 matrix and a short4 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 mul(short3x4 a, short4 b)
        {
            return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z + a.c3 * b.w;
        }

        /// <summary>		Returns the short3x2 matrix result of a matrix multiplication between a short3x4 matrix and a short4x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3x2 mul(short3x4 a, short4x2 b)
        {
            return new short3x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w);
        }

        /// <summary>		Returns the short3x3 matrix result of a matrix multiplication between a short3x4 matrix and a short4x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3x3 mul(short3x4 a, short4x3 b)
        {
            return new short3x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w);
        }

        /// <summary>		Returns the short3x4 matrix result of a matrix multiplication between a short3x4 matrix and a short4x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3x4 mul(short3x4 a, short4x4 b)
        {
            return new short3x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w,
                a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z + a.c3 * b.c3.w);
        }

        /// <summary>		Returns the short4 column vector result of a matrix multiplication between a short4x2 matrix and a short2 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 mul(short4x2 a, short2 b)
        {
            return a.c0 * b.x + a.c1 * b.y;
        }

        /// <summary>		Returns the short4x2 matrix result of a matrix multiplication between a short4x2 matrix and a short2x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4x2 mul(short4x2 a, short2x2 b)
        {
            return new short4x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y);
        }

        /// <summary>		Returns the short4x3 matrix result of a matrix multiplication between a short4x2 matrix and a short2x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4x3 mul(short4x2 a, short2x3 b)
        {
            return new short4x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y,
                a.c0 * b.c2.x + a.c1 * b.c2.y);
        }

        /// <summary>		Returns the short4x4 matrix result of a matrix multiplication between a short4x2 matrix and a short2x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4x4 mul(short4x2 a, short2x4 b)
        {
            return new short4x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y,
                a.c0 * b.c2.x + a.c1 * b.c2.y,
                a.c0 * b.c3.x + a.c1 * b.c3.y);
        }

        /// <summary>		Returns the short4 column vector result of a matrix multiplication between a short4x3 matrix and a short3 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 mul(short4x3 a, short3 b)
        {
            return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z;
        }

        /// <summary>		Returns the short4x2 matrix result of a matrix multiplication between a short4x3 matrix and a short3x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4x2 mul(short4x3 a, short3x2 b)
        {
            return new short4x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z);
        }

        /// <summary>		Returns the short4x3 matrix result of a matrix multiplication between a short4x3 matrix and a short3x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4x3 mul(short4x3 a, short3x3 b)
        {
            return new short4x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z);
        }

        /// <summary>		Returns the short4x4 matrix result of a matrix multiplication between a short4x3 matrix and a short3x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4x4 mul(short4x3 a, short3x4 b)
        {
            return new short4x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z,
                a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z);
        }

        /// <summary>		Returns the short4 column vector result of a matrix multiplication between a short4x4 matrix and a short4 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 mul(short4x4 a, short4 b)
        {
            return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z + a.c3 * b.w;
        }

        /// <summary>		Returns the short4x2 matrix result of a matrix multiplication between a short4x4 matrix and a short4x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4x2 mul(short4x4 a, short4x2 b)
        {
            return new short4x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w);
        }

        /// <summary>		Returns the short4x3 matrix result of a matrix multiplication between a short4x4 matrix and a short4x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4x3 mul(short4x4 a, short4x3 b)
        {
            return new short4x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w);
        }

        /// <summary>		Returns the short4x4 matrix result of a matrix multiplication between a short4x4 matrix and a short4x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4x4 mul(short4x4 a, short4x4 b)
        {
            return new short4x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w,
                a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z + a.c3 * b.c3.w);
        }


        /// <summary>		Returns the ushort value result of a matrix multiplication between a ushort2 row vector and a ushort2 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort mul(ushort2 a, ushort2 b)
        {
            return (ushort)(a.x * b.x + a.y * b.y);
        }

        /// <summary>		Returns the ushort2 row vector result of a matrix multiplication between a ushort2 row vector and a ushort2x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 mul(ushort2 a, ushort2x2 b)
        {
            return new ushort2(
                (ushort)(a.x * b.c0.x + a.y * b.c0.y),
                (ushort)(a.x * b.c1.x + a.y * b.c1.y));
        }

        /// <summary>		Returns the ushort3 row vector result of a matrix multiplication between a ushort2 row vector and a ushort2x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 mul(ushort2 a, ushort2x3 b)
        {
            return new ushort3(
                (ushort)(a.x * b.c0.x + a.y * b.c0.y),
                (ushort)(a.x * b.c1.x + a.y * b.c1.y),
                (ushort)(a.x * b.c2.x + a.y * b.c2.y));
        }

        /// <summary>		Returns the ushort4 row vector result of a matrix multiplication between a ushort2 row vector and a ushort2x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 mul(ushort2 a, ushort2x4 b)
        {
            return new ushort4(
                (ushort)(a.x * b.c0.x + a.y * b.c0.y),
                (ushort)(a.x * b.c1.x + a.y * b.c1.y),
                (ushort)(a.x * b.c2.x + a.y * b.c2.y),
                (ushort)(a.x * b.c3.x + a.y * b.c3.y));
        }

        /// <summary>		Returns the ushort value result of a matrix multiplication between a ushort3 row vector and a ushort3 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort mul(ushort3 a, ushort3 b)
        {
            return (ushort)(a.x * b.x + a.y * b.y + a.z * b.z);
        }

        /// <summary>		Returns the ushort2 row vector result of a matrix multiplication between a ushort3 row vector and a ushort3x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 mul(ushort3 a, ushort3x2 b)
        {
            return new ushort2(
                (ushort)(a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z),
                (ushort)(a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z));
        }

        /// <summary>		Returns the ushort3 row vector result of a matrix multiplication between a ushort3 row vector and a ushort3x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 mul(ushort3 a, ushort3x3 b)
        {
            return new ushort3(
                (ushort)(a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z),
                (ushort)(a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z),
                (ushort)(a.x * b.c2.x + a.y * b.c2.y + a.z * b.c2.z));
        }

        /// <summary>		Returns the ushort4 row vector result of a matrix multiplication between a ushort3 row vector and a ushort3x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 mul(ushort3 a, ushort3x4 b)
        {
            return new ushort4(
                (ushort)(a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z),
                (ushort)(a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z),
                (ushort)(a.x * b.c2.x + a.y * b.c2.y + a.z * b.c2.z),
                (ushort)(a.x * b.c3.x + a.y * b.c3.y + a.z * b.c3.z));
        }

        /// <summary>		Returns the ushort value result of a matrix multiplication between a ushort4 row vector and a ushort4 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort mul(ushort4 a, ushort4 b)
        {
            return (ushort)(a.x * b.x + a.y * b.y + a.z * b.z + a.w * b.w);
        }

        /// <summary>		Returns the ushort2 row vector result of a matrix multiplication between a ushort4 row vector and a ushort4x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 mul(ushort4 a, ushort4x2 b)
        {
            return new ushort2(
                (ushort)(a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z + a.w * b.c0.w),
                (ushort)(a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z + a.w * b.c1.w));
        }

        /// <summary>		Returns the ushort3 row vector result of a matrix multiplication between a ushort4 row vector and a ushort4x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 mul(ushort4 a, ushort4x3 b)
        {
            return new ushort3(
                (ushort)(a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z + a.w * b.c0.w),
                (ushort)(a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z + a.w * b.c1.w),
                (ushort)(a.x * b.c2.x + a.y * b.c2.y + a.z * b.c2.z + a.w * b.c2.w));
        }

        /// <summary>		Returns the ushort4 row vector result of a matrix multiplication between a ushort4 row vector and a ushort4x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 mul(ushort4 a, ushort4x4 b)
        {
            return new ushort4(
                (ushort)(a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z + a.w * b.c0.w),
                (ushort)(a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z + a.w * b.c1.w),
                (ushort)(a.x * b.c2.x + a.y * b.c2.y + a.z * b.c2.z + a.w * b.c2.w),
                (ushort)(a.x * b.c3.x + a.y * b.c3.y + a.z * b.c3.z + a.w * b.c3.w));
        }

        /// <summary>		Returns the ushort2 column vector result of a matrix multiplication between a ushort2x2 matrix and a ushort2 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 mul(ushort2x2 a, ushort2 b)
        {
            return a.c0 * b.x + a.c1 * b.y;
        }

        /// <summary>		Returns the ushort2x2 matrix result of a matrix multiplication between a ushort2x2 matrix and a ushort2x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2x2 mul(ushort2x2 a, ushort2x2 b)
        {
            return new ushort2x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y);
        }

        /// <summary>		Returns the ushort2x3 matrix result of a matrix multiplication between a ushort2x2 matrix and a ushort2x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2x3 mul(ushort2x2 a, ushort2x3 b)
        {
            return new ushort2x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y,
                a.c0 * b.c2.x + a.c1 * b.c2.y);
        }

        /// <summary>		Returns the ushort2x4 matrix result of a matrix multiplication between a ushort2x2 matrix and a ushort2x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2x4 mul(ushort2x2 a, ushort2x4 b)
        {
            return new ushort2x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y,
                a.c0 * b.c2.x + a.c1 * b.c2.y,
                a.c0 * b.c3.x + a.c1 * b.c3.y);
        }

        /// <summary>		Returns the ushort2 column vector result of a matrix multiplication between a ushort2x3 matrix and a ushort3 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 mul(ushort2x3 a, ushort3 b)
        {
            return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z;
        }

        /// <summary>		Returns the ushort2x2 matrix result of a matrix multiplication between a ushort2x3 matrix and a ushort3x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2x2 mul(ushort2x3 a, ushort3x2 b)
        {
            return new ushort2x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z);
        }

        /// <summary>		Returns the ushort2x3 matrix result of a matrix multiplication between a ushort2x3 matrix and a ushort3x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2x3 mul(ushort2x3 a, ushort3x3 b)
        {
            return new ushort2x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z);
        }

        /// <summary>		Returns the ushort2x4 matrix result of a matrix multiplication between a ushort2x3 matrix and a ushort3x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2x4 mul(ushort2x3 a, ushort3x4 b)
        {
            return new ushort2x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z,
                a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z);
        }

        /// <summary>		Returns the ushort2 column vector result of a matrix multiplication between a ushort2x4 matrix and a ushort4 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 mul(ushort2x4 a, ushort4 b)
        {
            return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z + a.c3 * b.w;
        }

        /// <summary>		Returns the ushort2x2 matrix result of a matrix multiplication between a ushort2x4 matrix and a ushort4x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2x2 mul(ushort2x4 a, ushort4x2 b)
        {
            return new ushort2x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w);
        }

        /// <summary>		Returns the ushort2x3 matrix result of a matrix multiplication between a ushort2x4 matrix and a ushort4x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2x3 mul(ushort2x4 a, ushort4x3 b)
        {
            return new ushort2x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w);
        }

        /// <summary>		Returns the ushort2x4 matrix result of a matrix multiplication between a ushort2x4 matrix and a ushort4x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2x4 mul(ushort2x4 a, ushort4x4 b)
        {
            return new ushort2x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w,
                a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z + a.c3 * b.c3.w);
        }

        /// <summary>		Returns the ushort3 column vector result of a matrix multiplication between a ushort3x2 matrix and a ushort2 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 mul(ushort3x2 a, ushort2 b)
        {
            return a.c0 * b.x + a.c1 * b.y;
        }

        /// <summary>		Returns the ushort3x2 matrix result of a matrix multiplication between a ushort3x2 matrix and a ushort2x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3x2 mul(ushort3x2 a, ushort2x2 b)
        {
            return new ushort3x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y);
        }

        /// <summary>		Returns the ushort3x3 matrix result of a matrix multiplication between a ushort3x2 matrix and a ushort2x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3x3 mul(ushort3x2 a, ushort2x3 b)
        {
            return new ushort3x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y,
                a.c0 * b.c2.x + a.c1 * b.c2.y);
        }

        /// <summary>		Returns the ushort3x4 matrix result of a matrix multiplication between a ushort3x2 matrix and a ushort2x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3x4 mul(ushort3x2 a, ushort2x4 b)
        {
            return new ushort3x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y,
                a.c0 * b.c2.x + a.c1 * b.c2.y,
                a.c0 * b.c3.x + a.c1 * b.c3.y);
        }

        /// <summary>		Returns the ushort3 column vector result of a matrix multiplication between a ushort3x3 matrix and a ushort3 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 mul(ushort3x3 a, ushort3 b)
        {
            return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z;
        }

        /// <summary>		Returns the ushort3x2 matrix result of a matrix multiplication between a ushort3x3 matrix and a ushort3x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3x2 mul(ushort3x3 a, ushort3x2 b)
        {
            return new ushort3x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z);
        }

        /// <summary>		Returns the ushort3x3 matrix result of a matrix multiplication between a ushort3x3 matrix and a ushort3x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3x3 mul(ushort3x3 a, ushort3x3 b)
        {
            return new ushort3x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z);
        }

        /// <summary>		Returns the ushort3x4 matrix result of a matrix multiplication between a ushort3x3 matrix and a ushort3x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3x4 mul(ushort3x3 a, ushort3x4 b)
        {
            return new ushort3x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z,
                a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z);
        }

        /// <summary>		Returns the ushort3 column vector result of a matrix multiplication between a ushort3x4 matrix and a ushort4 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 mul(ushort3x4 a, ushort4 b)
        {
            return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z + a.c3 * b.w;
        }

        /// <summary>		Returns the ushort3x2 matrix result of a matrix multiplication between a ushort3x4 matrix and a ushort4x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3x2 mul(ushort3x4 a, ushort4x2 b)
        {
            return new ushort3x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w);
        }

        /// <summary>		Returns the ushort3x3 matrix result of a matrix multiplication between a ushort3x4 matrix and a ushort4x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3x3 mul(ushort3x4 a, ushort4x3 b)
        {
            return new ushort3x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w);
        }

        /// <summary>		Returns the ushort3x4 matrix result of a matrix multiplication between a ushort3x4 matrix and a ushort4x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3x4 mul(ushort3x4 a, ushort4x4 b)
        {
            return new ushort3x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w,
                a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z + a.c3 * b.c3.w);
        }

        /// <summary>		Returns the ushort4 column vector result of a matrix multiplication between a ushort4x2 matrix and a ushort2 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 mul(ushort4x2 a, ushort2 b)
        {
            return a.c0 * b.x + a.c1 * b.y;
        }

        /// <summary>		Returns the ushort4x2 matrix result of a matrix multiplication between a ushort4x2 matrix and a ushort2x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x2 mul(ushort4x2 a, ushort2x2 b)
        {
            return new ushort4x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y);
        }

        /// <summary>		Returns the ushort4x3 matrix result of a matrix multiplication between a ushort4x2 matrix and a ushort2x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 mul(ushort4x2 a, ushort2x3 b)
        {
            return new ushort4x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y,
                a.c0 * b.c2.x + a.c1 * b.c2.y);
        }

        /// <summary>		Returns the ushort4x4 matrix result of a matrix multiplication between a ushort4x2 matrix and a ushort2x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x4 mul(ushort4x2 a, ushort2x4 b)
        {
            return new ushort4x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y,
                a.c0 * b.c2.x + a.c1 * b.c2.y,
                a.c0 * b.c3.x + a.c1 * b.c3.y);
        }

        /// <summary>		Returns the ushort4 column vector result of a matrix multiplication between a ushort4x3 matrix and a ushort3 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 mul(ushort4x3 a, ushort3 b)
        {
            return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z;
        }

        /// <summary>		Returns the ushort4x2 matrix result of a matrix multiplication between a ushort4x3 matrix and a ushort3x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x2 mul(ushort4x3 a, ushort3x2 b)
        {
            return new ushort4x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z);
        }

        /// <summary>		Returns the ushort4x3 matrix result of a matrix multiplication between a ushort4x3 matrix and a ushort3x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 mul(ushort4x3 a, ushort3x3 b)
        {
            return new ushort4x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z);
        }

        /// <summary>		Returns the ushort4x4 matrix result of a matrix multiplication between a ushort4x3 matrix and a ushort3x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x4 mul(ushort4x3 a, ushort3x4 b)
        {
            return new ushort4x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z,
                a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z);
        }

        /// <summary>		Returns the ushort4 column vector result of a matrix multiplication between a ushort4x4 matrix and a ushort4 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 mul(ushort4x4 a, ushort4 b)
        {
            return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z + a.c3 * b.w;
        }

        /// <summary>		Returns the ushort4x2 matrix result of a matrix multiplication between a ushort4x4 matrix and a ushort4x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x2 mul(ushort4x4 a, ushort4x2 b)
        {
            return new ushort4x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w);
        }

        /// <summary>		Returns the ushort4x3 matrix result of a matrix multiplication between a ushort4x4 matrix and a ushort4x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 mul(ushort4x4 a, ushort4x3 b)
        {
            return new ushort4x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w);
        }

        /// <summary>		Returns the ushort4x4 matrix result of a matrix multiplication between a ushort4x4 matrix and a ushort4x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x4 mul(ushort4x4 a, ushort4x4 b)
        {
            return new ushort4x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w,
                a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z + a.c3 * b.c3.w);
        }


        /// <summary>		Returns the sbyte value result of a matrix multiplication between an sbyte2 row vector and an sbyte2 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte mul(sbyte2 a, sbyte2 b)
        {
            return (sbyte)(a.x * b.x + a.y * b.y);
        }

        /// <summary>		Returns the sbyte2 row vector result of a matrix multiplication between an sbyte2 row vector and an sbyte2x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 mul(sbyte2 a, sbyte2x2 b)
        {
            return new sbyte2(
                (sbyte)(a.x * b.c0.x + a.y * b.c0.y),
                (sbyte)(a.x * b.c1.x + a.y * b.c1.y));
        }

        /// <summary>		Returns the sbyte3 row vector result of a matrix multiplication between an sbyte2 row vector and an sbyte2x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 mul(sbyte2 a, sbyte2x3 b)
        {
            return new sbyte3(
                (sbyte)(a.x * b.c0.x + a.y * b.c0.y),
                (sbyte)(a.x * b.c1.x + a.y * b.c1.y),
                (sbyte)(a.x * b.c2.x + a.y * b.c2.y));
        }

        /// <summary>		Returns the sbyte4 row vector result of a matrix multiplication between an sbyte2 row vector and an sbyte2x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 mul(sbyte2 a, sbyte2x4 b)
        {
            return new sbyte4(
                (sbyte)(a.x * b.c0.x + a.y * b.c0.y),
                (sbyte)(a.x * b.c1.x + a.y * b.c1.y),
                (sbyte)(a.x * b.c2.x + a.y * b.c2.y),
                (sbyte)(a.x * b.c3.x + a.y * b.c3.y));
        }

        /// <summary>		Returns the sbyte value result of a matrix multiplication between an sbyte3 row vector and an sbyte3 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte mul(sbyte3 a, sbyte3 b)
        {
            return (sbyte)(a.x * b.x + a.y * b.y + a.z * b.z);
        }

        /// <summary>		Returns the sbyte2 row vector result of a matrix multiplication between an sbyte3 row vector and an sbyte3x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 mul(sbyte3 a, sbyte3x2 b)
        {
            return new sbyte2(
                (sbyte)(a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z),
                (sbyte)(a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z));
        }

        /// <summary>		Returns the sbyte3 row vector result of a matrix multiplication between an sbyte3 row vector and an sbyte3x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 mul(sbyte3 a, sbyte3x3 b)
        {
            return new sbyte3(
                (sbyte)(a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z),
                (sbyte)(a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z),
                (sbyte)(a.x * b.c2.x + a.y * b.c2.y + a.z * b.c2.z));
        }

        /// <summary>		Returns the sbyte4 row vector result of a matrix multiplication between an sbyte3 row vector and an sbyte3x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 mul(sbyte3 a, sbyte3x4 b)
        {
            return new sbyte4(
                (sbyte)(a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z),
                (sbyte)(a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z),
                (sbyte)(a.x * b.c2.x + a.y * b.c2.y + a.z * b.c2.z),
                (sbyte)(a.x * b.c3.x + a.y * b.c3.y + a.z * b.c3.z));
        }

        /// <summary>		Returns the sbyte value result of a matrix multiplication between an sbyte4 row vector and an sbyte4 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte mul(sbyte4 a, sbyte4 b)
        {
            return (sbyte)(a.x * b.x + a.y * b.y + a.z * b.z + a.w * b.w);
        }

        /// <summary>		Returns the sbyte2 row vector result of a matrix multiplication between an sbyte4 row vector and an sbyte4x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 mul(sbyte4 a, sbyte4x2 b)
        {
            return new sbyte2(
                (sbyte)(a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z + a.w * b.c0.w),
                (sbyte)(a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z + a.w * b.c1.w));
        }

        /// <summary>		Returns the sbyte3 row vector result of a matrix multiplication between an sbyte4 row vector and an sbyte4x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 mul(sbyte4 a, sbyte4x3 b)
        {
            return new sbyte3(
                (sbyte)(a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z + a.w * b.c0.w),
                (sbyte)(a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z + a.w * b.c1.w),
                (sbyte)(a.x * b.c2.x + a.y * b.c2.y + a.z * b.c2.z + a.w * b.c2.w));
        }

        /// <summary>		Returns the sbyte4 row vector result of a matrix multiplication between an sbyte4 row vector and an sbyte4x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 mul(sbyte4 a, sbyte4x4 b)
        {
            return new sbyte4(
                (sbyte)(a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z + a.w * b.c0.w),
                (sbyte)(a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z + a.w * b.c1.w),
                (sbyte)(a.x * b.c2.x + a.y * b.c2.y + a.z * b.c2.z + a.w * b.c2.w),
                (sbyte)(a.x * b.c3.x + a.y * b.c3.y + a.z * b.c3.z + a.w * b.c3.w));
        }

        /// <summary>		Returns the sbyte2 column vector result of a matrix multiplication between an sbyte2x2 matrix and an sbyte2 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 mul(sbyte2x2 a, sbyte2 b)
        {
            return a.c0 * b.x + a.c1 * b.y;
        }

        /// <summary>		Returns the sbyte2x2 matrix result of a matrix multiplication between an sbyte2x2 matrix and an sbyte2x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2x2 mul(sbyte2x2 a, sbyte2x2 b)
        {
            return new sbyte2x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y);
        }

        /// <summary>		Returns the sbyte2x3 matrix result of a matrix multiplication between an sbyte2x2 matrix and an sbyte2x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2x3 mul(sbyte2x2 a, sbyte2x3 b)
        {
            return new sbyte2x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y,
                a.c0 * b.c2.x + a.c1 * b.c2.y);
        }

        /// <summary>		Returns the sbyte2x4 matrix result of a matrix multiplication between an sbyte2x2 matrix and an sbyte2x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2x4 mul(sbyte2x2 a, sbyte2x4 b)
        {
            return new sbyte2x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y,
                a.c0 * b.c2.x + a.c1 * b.c2.y,
                a.c0 * b.c3.x + a.c1 * b.c3.y);
        }

        /// <summary>		Returns the sbyte2 column vector result of a matrix multiplication between an sbyte2x3 matrix and an sbyte3 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 mul(sbyte2x3 a, sbyte3 b)
        {
            return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z;
        }

        /// <summary>		Returns the sbyte2x2 matrix result of a matrix multiplication between an sbyte2x3 matrix and an sbyte3x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2x2 mul(sbyte2x3 a, sbyte3x2 b)
        {
            return new sbyte2x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z);
        }

        /// <summary>		Returns the sbyte2x3 matrix result of a matrix multiplication between an sbyte2x3 matrix and an sbyte3x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2x3 mul(sbyte2x3 a, sbyte3x3 b)
        {
            return new sbyte2x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z);
        }

        /// <summary>		Returns the sbyte2x4 matrix result of a matrix multiplication between an sbyte2x3 matrix and an sbyte3x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2x4 mul(sbyte2x3 a, sbyte3x4 b)
        {
            return new sbyte2x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z,
                a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z);
        }

        /// <summary>		Returns the sbyte2 column vector result of a matrix multiplication between an sbyte2x4 matrix and an sbyte4 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 mul(sbyte2x4 a, sbyte4 b)
        {
            return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z + a.c3 * b.w;
        }

        /// <summary>		Returns the sbyte2x2 matrix result of a matrix multiplication between an sbyte2x4 matrix and an sbyte4x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2x2 mul(sbyte2x4 a, sbyte4x2 b)
        {
            return new sbyte2x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w);
        }

        /// <summary>		Returns the sbyte2x3 matrix result of a matrix multiplication between an sbyte2x4 matrix and an sbyte4x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2x3 mul(sbyte2x4 a, sbyte4x3 b)
        {
            return new sbyte2x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w);
        }

        /// <summary>		Returns the sbyte2x4 matrix result of a matrix multiplication between an sbyte2x4 matrix and an sbyte4x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2x4 mul(sbyte2x4 a, sbyte4x4 b)
        {
            return new sbyte2x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w,
                a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z + a.c3 * b.c3.w);
        }

        /// <summary>		Returns the sbyte3 column vector result of a matrix multiplication between an sbyte3x2 matrix and an sbyte2 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 mul(sbyte3x2 a, sbyte2 b)
        {
            return a.c0 * b.x + a.c1 * b.y;
        }

        /// <summary>		Returns the sbyte3x2 matrix result of a matrix multiplication between an sbyte3x2 matrix and an sbyte2x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3x2 mul(sbyte3x2 a, sbyte2x2 b)
        {
            return new sbyte3x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y);
        }

        /// <summary>		Returns the sbyte3x3 matrix result of a matrix multiplication between an sbyte3x2 matrix and an sbyte2x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3x3 mul(sbyte3x2 a, sbyte2x3 b)
        {
            return new sbyte3x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y,
                a.c0 * b.c2.x + a.c1 * b.c2.y);
        }

        /// <summary>		Returns the sbyte3x4 matrix result of a matrix multiplication between an sbyte3x2 matrix and an sbyte2x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3x4 mul(sbyte3x2 a, sbyte2x4 b)
        {
            return new sbyte3x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y,
                a.c0 * b.c2.x + a.c1 * b.c2.y,
                a.c0 * b.c3.x + a.c1 * b.c3.y);
        }

        /// <summary>		Returns the sbyte3 column vector result of a matrix multiplication between an sbyte3x3 matrix and an sbyte3 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 mul(sbyte3x3 a, sbyte3 b)
        {
            return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z;
        }

        /// <summary>		Returns the sbyte3x2 matrix result of a matrix multiplication between an sbyte3x3 matrix and an sbyte3x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3x2 mul(sbyte3x3 a, sbyte3x2 b)
        {
            return new sbyte3x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z);
        }

        /// <summary>		Returns the sbyte3x3 matrix result of a matrix multiplication between an sbyte3x3 matrix and an sbyte3x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3x3 mul(sbyte3x3 a, sbyte3x3 b)
        {
            return new sbyte3x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z);
        }

        /// <summary>		Returns the sbyte3x4 matrix result of a matrix multiplication between an sbyte3x3 matrix and an sbyte3x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3x4 mul(sbyte3x3 a, sbyte3x4 b)
        {
            return new sbyte3x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z,
                a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z);
        }

        /// <summary>		Returns the sbyte3 column vector result of a matrix multiplication between an sbyte3x4 matrix and an sbyte4 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 mul(sbyte3x4 a, sbyte4 b)
        {
            return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z + a.c3 * b.w;
        }

        /// <summary>		Returns the sbyte3x2 matrix result of a matrix multiplication between an sbyte3x4 matrix and an sbyte4x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3x2 mul(sbyte3x4 a, sbyte4x2 b)
        {
            return new sbyte3x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w);
        }

        /// <summary>		Returns the sbyte3x3 matrix result of a matrix multiplication between an sbyte3x4 matrix and an sbyte4x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3x3 mul(sbyte3x4 a, sbyte4x3 b)
        {
            return new sbyte3x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w);
        }

        /// <summary>		Returns the sbyte3x4 matrix result of a matrix multiplication between an sbyte3x4 matrix and an sbyte4x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3x4 mul(sbyte3x4 a, sbyte4x4 b)
        {
            return new sbyte3x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w,
                a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z + a.c3 * b.c3.w);
        }

        /// <summary>		Returns the sbyte4 column vector result of a matrix multiplication between an sbyte4x2 matrix and an sbyte2 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 mul(sbyte4x2 a, sbyte2 b)
        {
            return a.c0 * b.x + a.c1 * b.y;
        }

        /// <summary>		Returns the sbyte4x2 matrix result of a matrix multiplication between an sbyte4x2 matrix and an sbyte2x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4x2 mul(sbyte4x2 a, sbyte2x2 b)
        {
            return new sbyte4x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y);
        }

        /// <summary>		Returns the sbyte4x3 matrix result of a matrix multiplication between an sbyte4x2 matrix and an sbyte2x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4x3 mul(sbyte4x2 a, sbyte2x3 b)
        {
            return new sbyte4x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y,
                a.c0 * b.c2.x + a.c1 * b.c2.y);
        }

        /// <summary>		Returns the sbyte4x4 matrix result of a matrix multiplication between an sbyte4x2 matrix and an sbyte2x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4x4 mul(sbyte4x2 a, sbyte2x4 b)
        {
            return new sbyte4x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y,
                a.c0 * b.c2.x + a.c1 * b.c2.y,
                a.c0 * b.c3.x + a.c1 * b.c3.y);
        }

        /// <summary>		Returns the sbyte4 column vector result of a matrix multiplication between an sbyte4x3 matrix and an sbyte3 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 mul(sbyte4x3 a, sbyte3 b)
        {
            return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z;
        }

        /// <summary>		Returns the sbyte4x2 matrix result of a matrix multiplication between an sbyte4x3 matrix and an sbyte3x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4x2 mul(sbyte4x3 a, sbyte3x2 b)
        {
            return new sbyte4x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z);
        }

        /// <summary>		Returns the sbyte4x3 matrix result of a matrix multiplication between an sbyte4x3 matrix and an sbyte3x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4x3 mul(sbyte4x3 a, sbyte3x3 b)
        {
            return new sbyte4x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z);
        }

        /// <summary>		Returns the sbyte4x4 matrix result of a matrix multiplication between an sbyte4x3 matrix and an sbyte3x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4x4 mul(sbyte4x3 a, sbyte3x4 b)
        {
            return new sbyte4x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z,
                a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z);
        }

        /// <summary>		Returns the sbyte4 column vector result of a matrix multiplication between an sbyte4x4 matrix and an sbyte4 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 mul(sbyte4x4 a, sbyte4 b)
        {
            return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z + a.c3 * b.w;
        }

        /// <summary>		Returns the sbyte4x2 matrix result of a matrix multiplication between an sbyte4x4 matrix and an sbyte4x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4x2 mul(sbyte4x4 a, sbyte4x2 b)
        {
            return new sbyte4x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w);
        }

        /// <summary>		Returns the sbyte4x3 matrix result of a matrix multiplication between an sbyte4x4 matrix and an sbyte4x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4x3 mul(sbyte4x4 a, sbyte4x3 b)
        {
            return new sbyte4x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w);
        }

        /// <summary>		Returns the sbyte4x4 matrix result of a matrix multiplication between an sbyte4x4 matrix and an sbyte4x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4x4 mul(sbyte4x4 a, sbyte4x4 b)
        {
            return new sbyte4x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w,
                a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z + a.c3 * b.c3.w);
        }


        /// <summary>		Returns the byte value result of a matrix multiplication between a byte2 row vector and a byte2 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte mul(byte2 a, byte2 b)
        {
            return (byte)(a.x * b.x + a.y * b.y);
        }

        /// <summary>		Returns the byte2 row vector result of a matrix multiplication between a byte2 row vector and a byte2x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 mul(byte2 a, byte2x2 b)
        {
            return new byte2(
                (byte)(a.x * b.c0.x + a.y * b.c0.y),
                (byte)(a.x * b.c1.x + a.y * b.c1.y));
        }

        /// <summary>		Returns the byte3 row vector result of a matrix multiplication between a byte2 row vector and a byte2x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 mul(byte2 a, byte2x3 b)
        {
            return new byte3(
                (byte)(a.x * b.c0.x + a.y * b.c0.y),
                (byte)(a.x * b.c1.x + a.y * b.c1.y),
                (byte)(a.x * b.c2.x + a.y * b.c2.y));
        }

        /// <summary>		Returns the byte4 row vector result of a matrix multiplication between a byte2 row vector and a byte2x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 mul(byte2 a, byte2x4 b)
        {
            return new byte4(
                (byte)(a.x * b.c0.x + a.y * b.c0.y),
                (byte)(a.x * b.c1.x + a.y * b.c1.y),
                (byte)(a.x * b.c2.x + a.y * b.c2.y),
                (byte)(a.x * b.c3.x + a.y * b.c3.y));
        }

        /// <summary>		Returns the byte value result of a matrix multiplication between a byte3 row vector and a byte3 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte mul(byte3 a, byte3 b)
        {
            return (byte)(a.x * b.x + a.y * b.y + a.z * b.z);
        }

        /// <summary>		Returns the byte2 row vector result of a matrix multiplication between a byte3 row vector and a byte3x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 mul(byte3 a, byte3x2 b)
        {
            return new byte2(
                (byte)(a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z),
                (byte)(a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z));
        }

        /// <summary>		Returns the byte3 row vector result of a matrix multiplication between a byte3 row vector and a byte3x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 mul(byte3 a, byte3x3 b)
        {
            return new byte3(
                (byte)(a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z),
                (byte)(a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z),
                (byte)(a.x * b.c2.x + a.y * b.c2.y + a.z * b.c2.z));
        }

        /// <summary>		Returns the byte4 row vector result of a matrix multiplication between a byte3 row vector and a byte3x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 mul(byte3 a, byte3x4 b)
        {
            return new byte4(
                (byte)(a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z),
                (byte)(a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z),
                (byte)(a.x * b.c2.x + a.y * b.c2.y + a.z * b.c2.z),
                (byte)(a.x * b.c3.x + a.y * b.c3.y + a.z * b.c3.z));
        }

        /// <summary>		Returns the byte value result of a matrix multiplication between a byte4 row vector and a byte4 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte mul(byte4 a, byte4 b)
        {
            return (byte)(a.x * b.x + a.y * b.y + a.z * b.z + a.w * b.w);
        }

        /// <summary>		Returns the byte2 row vector result of a matrix multiplication between a byte4 row vector and a byte4x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 mul(byte4 a, byte4x2 b)
        {
            return new byte2(
                (byte)(a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z + a.w * b.c0.w),
                (byte)(a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z + a.w * b.c1.w));
        }

        /// <summary>		Returns the byte3 row vector result of a matrix multiplication between a byte4 row vector and a byte4x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 mul(byte4 a, byte4x3 b)
        {
            return new byte3(
                (byte)(a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z + a.w * b.c0.w),
                (byte)(a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z + a.w * b.c1.w),
                (byte)(a.x * b.c2.x + a.y * b.c2.y + a.z * b.c2.z + a.w * b.c2.w));
        }

        /// <summary>		Returns the byte4 row vector result of a matrix multiplication between a byte4 row vector and a byte4x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 mul(byte4 a, byte4x4 b)
        {
            return new byte4(
                (byte)(a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z + a.w * b.c0.w),
                (byte)(a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z + a.w * b.c1.w),
                (byte)(a.x * b.c2.x + a.y * b.c2.y + a.z * b.c2.z + a.w * b.c2.w),
                (byte)(a.x * b.c3.x + a.y * b.c3.y + a.z * b.c3.z + a.w * b.c3.w));
        }

        /// <summary>		Returns the byte2 column vector result of a matrix multiplication between a byte2x2 matrix and a byte2 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 mul(byte2x2 a, byte2 b)
        {
            return a.c0 * b.x + a.c1 * b.y;
        }

        /// <summary>		Returns the byte2x2 matrix result of a matrix multiplication between a byte2x2 matrix and a byte2x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2x2 mul(byte2x2 a, byte2x2 b)
        {
            return new byte2x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y);
        }

        /// <summary>		Returns the byte2x3 matrix result of a matrix multiplication between a byte2x2 matrix and a byte2x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2x3 mul(byte2x2 a, byte2x3 b)
        {
            return new byte2x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y,
                a.c0 * b.c2.x + a.c1 * b.c2.y);
        }

        /// <summary>		Returns the byte2x4 matrix result of a matrix multiplication between a byte2x2 matrix and a byte2x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2x4 mul(byte2x2 a, byte2x4 b)
        {
            return new byte2x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y,
                a.c0 * b.c2.x + a.c1 * b.c2.y,
                a.c0 * b.c3.x + a.c1 * b.c3.y);
        }

        /// <summary>		Returns the byte2 column vector result of a matrix multiplication between a byte2x3 matrix and a byte3 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 mul(byte2x3 a, byte3 b)
        {
            return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z;
        }

        /// <summary>		Returns the byte2x2 matrix result of a matrix multiplication between a byte2x3 matrix and a byte3x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2x2 mul(byte2x3 a, byte3x2 b)
        {
            return new byte2x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z);
        }

        /// <summary>		Returns the byte2x3 matrix result of a matrix multiplication between a byte2x3 matrix and a byte3x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2x3 mul(byte2x3 a, byte3x3 b)
        {
            return new byte2x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z);
        }

        /// <summary>		Returns the byte2x4 matrix result of a matrix multiplication between a byte2x3 matrix and a byte3x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2x4 mul(byte2x3 a, byte3x4 b)
        {
            return new byte2x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z,
                a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z);
        }

        /// <summary>		Returns the byte2 column vector result of a matrix multiplication between a byte2x4 matrix and a byte4 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 mul(byte2x4 a, byte4 b)
        {
            return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z + a.c3 * b.w;
        }

        /// <summary>		Returns the byte2x2 matrix result of a matrix multiplication between a byte2x4 matrix and a byte4x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2x2 mul(byte2x4 a, byte4x2 b)
        {
            return new byte2x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w);
        }

        /// <summary>		Returns the byte2x3 matrix result of a matrix multiplication between a byte2x4 matrix and a byte4x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2x3 mul(byte2x4 a, byte4x3 b)
        {
            return new byte2x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w);
        }

        /// <summary>		Returns the byte2x4 matrix result of a matrix multiplication between a byte2x4 matrix and a byte4x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2x4 mul(byte2x4 a, byte4x4 b)
        {
            return new byte2x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w,
                a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z + a.c3 * b.c3.w);
        }

        /// <summary>		Returns the byte3 column vector result of a matrix multiplication between a byte3x2 matrix and a byte2 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 mul(byte3x2 a, byte2 b)
        {
            return a.c0 * b.x + a.c1 * b.y;
        }

        /// <summary>		Returns the byte3x2 matrix result of a matrix multiplication between a byte3x2 matrix and a byte2x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3x2 mul(byte3x2 a, byte2x2 b)
        {
            return new byte3x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y);
        }

        /// <summary>		Returns the byte3x3 matrix result of a matrix multiplication between a byte3x2 matrix and a byte2x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3x3 mul(byte3x2 a, byte2x3 b)
        {
            return new byte3x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y,
                a.c0 * b.c2.x + a.c1 * b.c2.y);
        }

        /// <summary>		Returns the byte3x4 matrix result of a matrix multiplication between a byte3x2 matrix and a byte2x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3x4 mul(byte3x2 a, byte2x4 b)
        {
            return new byte3x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y,
                a.c0 * b.c2.x + a.c1 * b.c2.y,
                a.c0 * b.c3.x + a.c1 * b.c3.y);
        }

        /// <summary>		Returns the byte3 column vector result of a matrix multiplication between a byte3x3 matrix and a byte3 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 mul(byte3x3 a, byte3 b)
        {
            return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z;
        }

        /// <summary>		Returns the byte3x2 matrix result of a matrix multiplication between a byte3x3 matrix and a byte3x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3x2 mul(byte3x3 a, byte3x2 b)
        {
            return new byte3x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z);
        }

        /// <summary>		Returns the byte3x3 matrix result of a matrix multiplication between a byte3x3 matrix and a byte3x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3x3 mul(byte3x3 a, byte3x3 b)
        {
            return new byte3x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z);
        }

        /// <summary>		Returns the byte3x4 matrix result of a matrix multiplication between a byte3x3 matrix and a byte3x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3x4 mul(byte3x3 a, byte3x4 b)
        {
            return new byte3x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z,
                a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z);
        }

        /// <summary>		Returns the byte3 column vector result of a matrix multiplication between a byte3x4 matrix and a byte4 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 mul(byte3x4 a, byte4 b)
        {
            return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z + a.c3 * b.w;
        }

        /// <summary>		Returns the byte3x2 matrix result of a matrix multiplication between a byte3x4 matrix and a byte4x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3x2 mul(byte3x4 a, byte4x2 b)
        {
            return new byte3x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w);
        }

        /// <summary>		Returns the byte3x3 matrix result of a matrix multiplication between a byte3x4 matrix and a byte4x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3x3 mul(byte3x4 a, byte4x3 b)
        {
            return new byte3x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w);
        }

        /// <summary>		Returns the byte3x4 matrix result of a matrix multiplication between a byte3x4 matrix and a byte4x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3x4 mul(byte3x4 a, byte4x4 b)
        {
            return new byte3x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w,
                a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z + a.c3 * b.c3.w);
        }

        /// <summary>		Returns the byte4 column vector result of a matrix multiplication between a byte4x2 matrix and a byte2 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 mul(byte4x2 a, byte2 b)
        {
            return a.c0 * b.x + a.c1 * b.y;
        }

        /// <summary>		Returns the byte4x2 matrix result of a matrix multiplication between a byte4x2 matrix and a byte2x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4x2 mul(byte4x2 a, byte2x2 b)
        {
            return new byte4x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y);
        }

        /// <summary>		Returns the byte4x3 matrix result of a matrix multiplication between a byte4x2 matrix and a byte2x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4x3 mul(byte4x2 a, byte2x3 b)
        {
            return new byte4x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y,
                a.c0 * b.c2.x + a.c1 * b.c2.y);
        }

        /// <summary>		Returns the byte4x4 matrix result of a matrix multiplication between a byte4x2 matrix and a byte2x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4x4 mul(byte4x2 a, byte2x4 b)
        {
            return new byte4x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y,
                a.c0 * b.c1.x + a.c1 * b.c1.y,
                a.c0 * b.c2.x + a.c1 * b.c2.y,
                a.c0 * b.c3.x + a.c1 * b.c3.y);
        }

        /// <summary>		Returns the byte4 column vector result of a matrix multiplication between a byte4x3 matrix and a byte3 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 mul(byte4x3 a, byte3 b)
        {
            return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z;
        }

        /// <summary>		Returns the byte4x2 matrix result of a matrix multiplication between a byte4x3 matrix and a byte3x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4x2 mul(byte4x3 a, byte3x2 b)
        {
            return new byte4x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z);
        }

        /// <summary>		Returns the byte4x3 matrix result of a matrix multiplication between a byte4x3 matrix and a byte3x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4x3 mul(byte4x3 a, byte3x3 b)
        {
            return new byte4x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z);
        }

        /// <summary>		Returns the byte4x4 matrix result of a matrix multiplication between a byte4x3 matrix and a byte3x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4x4 mul(byte4x3 a, byte3x4 b)
        {
            return new byte4x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z,
                a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z);
        }

        /// <summary>		Returns the byte4 column vector result of a matrix multiplication between a byte4x4 matrix and a byte4 column vector.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 mul(byte4x4 a, byte4 b)
        {
            return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z + a.c3 * b.w;
        }

        /// <summary>		Returns the byte4x2 matrix result of a matrix multiplication between a byte4x4 matrix and a byte4x2 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4x2 mul(byte4x4 a, byte4x2 b)
        {
            return new byte4x2(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w);
        }

        /// <summary>		Returns the byte4x3 matrix result of a matrix multiplication between a byte4x4 matrix and a byte4x3 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4x3 mul(byte4x4 a, byte4x3 b)
        {
            return new byte4x3(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w);
        }

        /// <summary>		Returns the byte4x4 matrix result of a matrix multiplication between a byte4x4 matrix and a byte4x4 matrix.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4x4 mul(byte4x4 a, byte4x4 b)
        {
            return new byte4x4(
                a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w,
                a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w,
                a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w,
                a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z + a.c3 * b.c3.w);
        }
    }
}