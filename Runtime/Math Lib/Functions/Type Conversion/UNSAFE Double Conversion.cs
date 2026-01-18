using System.Runtime.CompilerServices;
using Unity.Mathematics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Converts a <see cref="MaxMath.quarter"/> to its <see cref="double"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for input values outside the interval [-1.797693134862315708145274237317043567981e+308, 1.797693134862315708145274237317043567981e+308].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values, including negative 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double todoubleunsafe(quarter x, Promise promise = Promise.Nothing)
        {
            return quarter.ToDouble(x, inRange: promise.Promises(Promise.NoOverflow), abs: promise.Promises(Promise.ZeroOrGreater));
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.quarter2"/> to its respective <see cref="double"/> representation.
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
                return RegisterConversion.ToDouble2(Xse.cvtpq_pd(x, promiseInRange: promise.Promises(Promise.NoOverflow), promiseAbs: promise.Promises(Promise.ZeroOrGreater)));
            }
            else
            {
                return new double2(todoubleunsafe(x.x, promise), todoubleunsafe(x.y, promise));
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.quarter3"/> to its respective <see cref="double"/> representation.
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
                return RegisterConversion.ToDouble3(Xse.mm256_cvtpq_pd(x, promiseInRange: promise.Promises(Promise.NoOverflow), promiseAbs: promise.Promises(Promise.ZeroOrGreater), elements: 3));
            }
            else
            {
                return new double3(todoubleunsafe(x.xy, promise), todoubleunsafe(x.z, promise));
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.quarter4"/> to its respective <see cref="double"/> representation.
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
                return RegisterConversion.ToDouble4(Xse.mm256_cvtpq_pd(x, promiseInRange: promise.Promises(Promise.NoOverflow), promiseAbs: promise.Promises(Promise.ZeroOrGreater), elements: 4));
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
            return HalfExtensions.ToDouble(x, inRange: promise.Promises(Promise.NoOverflow), abs: promise.Promises(Promise.ZeroOrGreater));
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
                return RegisterConversion.ToDouble2(Xse.cvtph_pd(RegisterConversion.ToV128(x), promiseInRange: promise.Promises(Promise.NoOverflow), promiseAbs: promise.Promises(Promise.ZeroOrGreater)));
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
                return RegisterConversion.ToDouble3(Xse.mm256_cvtph_pd(RegisterConversion.ToV128(x), promiseInRange: promise.Promises(Promise.NoOverflow), promiseAbs: promise.Promises(Promise.ZeroOrGreater), elements: 3));
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
                return RegisterConversion.ToDouble4(Xse.mm256_cvtph_pd(RegisterConversion.ToV128(x), promiseInRange: promise.Promises(Promise.NoOverflow), promiseAbs: promise.Promises(Promise.ZeroOrGreater), elements: 4));
            }
            else
            {
                return new double4(todoubleunsafe(x.xy, promise), todoubleunsafe(x.zw, promise));
            }
        }
    }
}
