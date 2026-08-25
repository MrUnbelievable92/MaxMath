using System.Runtime.CompilerServices;
using MaxMath.CompilerServices;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class math
    {
        /// <summary>       Converts a <see cref="quarter"/> to its <see cref="double"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for input values outside the interval [-1.797693134862315708145274237317043567981e+308, 1.797693134862315708145274237317043567981e+308].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values, including negative 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double todoubleunsafe(quarter x, Promise promise = Promise.Nothing)
        {
            return MaxMath.quarter.ToDouble(x, inRange: promise.Promises(Promise.NoOverflow), abs: promise.Promises(Promise.ZeroOrGreater));
        }

        /// <summary>       Converts each value in a <see cref="quarter2"/> to its respective <see cref="double"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for input values outside the interval [-1.797693134862315708145274237317043567981e+308, 1.797693134862315708145274237317043567981e+308].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values, including negative 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 todoubleunsafe(quarter2 x, Promise promise = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtpq_pd(x, promiseInRange: promise.Promises(Promise.NoOverflow), promiseAbs: promise.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new double2(todoubleunsafe(x.x, promise), todoubleunsafe(x.y, promise));
            }
        }

        /// <summary>       Converts each value in a <see cref="quarter3"/> to its respective <see cref="double"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for input values outside the interval [-1.797693134862315708145274237317043567981e+308, 1.797693134862315708145274237317043567981e+308].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values, including negative 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 todoubleunsafe(quarter3 x, Promise promise = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtpq_pd(x, promiseInRange: promise.Promises(Promise.NoOverflow), promiseAbs: promise.Promises(Promise.ZeroOrGreater), elements: 3);
            }
            else
            {
                return new double3(todoubleunsafe(x.xy, promise), todoubleunsafe(x.z, promise));
            }
        }

        /// <summary>       Converts each value in a <see cref="quarter4"/> to its respective <see cref="double"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for input values outside the interval [-1.797693134862315708145274237317043567981e+308, 1.797693134862315708145274237317043567981e+308].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values, including negative 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 todoubleunsafe(quarter4 x, Promise promise = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtpq_pd(x, promiseInRange: promise.Promises(Promise.NoOverflow), promiseAbs: promise.Promises(Promise.ZeroOrGreater), elements: 4);
            }
            else
            {
                return new double4(todoubleunsafe(x.xy, promise), todoubleunsafe(x.zw, promise));
            }
        }

        
        /// <summary>       Converts a <see cref="half"/> to its <see cref="double"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for input values outside the interval [-1.797693134862315708145274237317043567981e+308, 1.797693134862315708145274237317043567981e+308].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values, including negative 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double todoubleunsafe(half x, Promise promise = Promise.Nothing)
        {
            return MaxMath.half.ToDouble(x, inRange: promise.Promises(Promise.NoOverflow), abs: promise.Promises(Promise.ZeroOrGreater));
        }

        /// <summary>       Converts each value in a <see cref="half2"/> to its respective <see cref="double"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for input values outside the interval [-1.797693134862315708145274237317043567981e+308, 1.797693134862315708145274237317043567981e+308].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values, including negative 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 todoubleunsafe(half2 x, Promise promise = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtph_pd(x, promiseInRange: promise.Promises(Promise.NoOverflow), promiseAbs: promise.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new double2(todoubleunsafe(x.x, promise), todoubleunsafe(x.y, promise));
            }
        }

        /// <summary>       Converts each value in a <see cref="half3"/> to its respective <see cref="double"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for input values outside the interval [-1.797693134862315708145274237317043567981e+308, 1.797693134862315708145274237317043567981e+308].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values, including negative 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 todoubleunsafe(half3 x, Promise promise = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtph_pd(x, promiseInRange: promise.Promises(Promise.NoOverflow), promiseAbs: promise.Promises(Promise.ZeroOrGreater), elements: 3);
            }
            else
            {
                return new double3(todoubleunsafe(x.xy, promise), todoubleunsafe(x.z, promise));
            }
        }

        /// <summary>       Converts each value in a <see cref="half4"/> to its respective <see cref="double"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for input values outside the interval [-1.797693134862315708145274237317043567981e+308, 1.797693134862315708145274237317043567981e+308].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values, including negative 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 todoubleunsafe(half4 x, Promise promise = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtph_pd(x, promiseInRange: promise.Promises(Promise.NoOverflow), promiseAbs: promise.Promises(Promise.ZeroOrGreater), elements: 4);
            }
            else
            {
                return new double4(todoubleunsafe(x.xy, promise), todoubleunsafe(x.zw, promise));
            }
        }

        
        /// <summary>       Converts a <see cref="quadruple"/> to its <see cref="double"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for input values outside the interval [-1.797693134862315708145274237317043567981e+308, 1.797693134862315708145274237317043567981e+308].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values, including negative 0.        </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values that would result in a subnormal <see cref="half"/> value, which applies to input values with an absolute value that lies in the interval (2.470328229206232720882843964341107E-324, 2.2250738585072008890245868760858599E-308].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double todoubleunsafe(quadruple x, Promise promise = Promise.NoOverflow)
        {
            return quadruple.ToDouble(x, promiseInRange: promise.Promises(Promise.NoOverflow), promiseAbs: promise.Promises(Promise.ZeroOrGreater), promiseNotSubnormal: promise.Promises(Promise.Unsafe0));
        }
    }
}
