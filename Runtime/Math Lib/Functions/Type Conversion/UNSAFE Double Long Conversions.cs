using System.Runtime.CompilerServices;
using Unity.Mathematics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Converts each value in a <see cref="double2"/> to its respective <see cref="ulong"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, 2⁵²)       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for 0       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 toulongunsafe(double2 x, Promise promise = Promise.Unsafe0)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (promise.Promises(Promise.Unsafe0))
                {
                    return Xse.cvttpd_epu64(RegisterConversion.ToV128(x), nonZero: promise.Promises(Promise.NonZero));
                }
                else
                {
                    return (ulong2)x;
                }
            }
            else
            {
                return (ulong2)x;
            }
        }

        /// <summary>       Converts each value in a <see cref="double3"/> to its respective <see cref="ulong"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [<see cref="ulong.MinValue"/>, <see cref="long.MaxValue"/>]       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for input values outside the interval [0, 2⁵²)       </para>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for 0       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 toulongunsafe(double3 x, Promise promise = Promise.Unsafe0)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvttpd_epu64(RegisterConversion.ToV256(x), elements: 3, nonZero: promise.Promises(Promise.NonZero));
            }
            else
            {
                return new ulong3(toulongunsafe(x.xy, promise.Promises(Promise.Unsafe1) ? Promise.Unsafe0 : Promise.Nothing), (ulong)x.z);
            }
        }

        /// <summary>       Converts each value in a <see cref="double4"/> to its respective <see cref="ulong"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [<see cref="ulong.MinValue"/>, <see cref="long.MaxValue"/>]       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for input values outside the interval [0, 2⁵²)       </para>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for 0       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 toulongunsafe(double4 x, Promise promise = Promise.Unsafe0)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvttpd_epu64(RegisterConversion.ToV256(x), elements: 4, nonZero: promise.Promises(Promise.NonZero));
            }
            else
            {
                Promise downCast = promise.Promises(Promise.Unsafe1) ? Promise.Unsafe0 : Promise.Nothing;

                return new ulong4(toulongunsafe(x.xy, downCast), toulongunsafe(x.zw, downCast));
            }
        }


        /// <summary>       Converts each value in a <see cref="double2"/> to its respective <see cref="long"/> representation.
        ///    <para>       A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [-2⁵¹, 2⁵¹]       </para>
        ///    <para>       A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for 0       </para>
        ///    <para>       A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for negative input values       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 tolongunsafe(double2 x, Promise promise = Promise.Unsafe0)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (promise.Promises(Promise.Unsafe0))
                {
                    return Xse.cvttpd_epi64(RegisterConversion.ToV128(x), positive: promise.Promises(Promise.Positive), nonZero: promise.Promises(Promise.NonZero));
                }
                else
                {
                    return (long2)x;
                }
            }
            else
            {
                return (long2)x;
            }
        }

        /// <summary>       Converts each value in a <see cref="double3"/> to its respective <see cref="long"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [<see cref="long.MinValue"/>, <see cref="long.MaxValue"/>]       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for input values outside the interval [-2⁵¹, 2⁵¹]       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for 0       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for negative input values       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 tolongunsafe(double3 x, Promise promise = Promise.Unsafe0)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvttpd_epi64(RegisterConversion.ToV256(x), elements: 3, positive: promise.Promises(Promise.Positive), nonZero: promise.Promises(Promise.NonZero));
            }
            else
            {
                return new long3(tolongunsafe(x.xy, promise.Promises(Promise.Unsafe1) ? Promise.Unsafe0 : Promise.Nothing), (long)x.z);
            }
        }

        /// <summary>       Converts each value in a <see cref="double4"/> to its respective <see cref="long"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [<see cref="long.MinValue"/>, <see cref="long.MaxValue"/>]       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for input values outside the interval [-2⁵¹, 2⁵¹]       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for 0       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for negative input values       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 tolongunsafe(double4 x, Promise promise = Promise.Unsafe0)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvttpd_epi64(RegisterConversion.ToV256(x), elements: 4, positive: promise.Promises(Promise.Positive), nonZero: promise.Promises(Promise.NonZero));
            }
            else
            {
                Promise downCast = promise.Promises(Promise.Unsafe1) ? Promise.Unsafe0 : Promise.Nothing;

                return new long4(tolongunsafe(x.xy, downCast), tolongunsafe(x.zw, downCast));
            }
        }


        /// <summary>       Converts each value in a <see cref="MaxMath.ulong2"/> to its respective <see cref="double"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, 2⁵²)       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 todoubleunsafe(ulong2 x, Promise promise = Promise.Unsafe0)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (promise.Promises(Promise.Unsafe0))
                {
                    return RegisterConversion.ToDouble2(Xse.usfcvtepu64_pd(x));
                }
                else
                {
                    return x;
                }
            }
            else
            {
                return (double2)x;
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.ulong3"/> to its respective <see cref="double"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, 2⁵²)       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 todoubleunsafe(ulong3 x, Promise promise = Promise.Unsafe0)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (promise.Promises(Promise.Unsafe0))
                {
                    return RegisterConversion.ToDouble3(Xse.mm256_usfcvtepu64_pd(x));
                }
                else
                {
                    return x;
                }
            }
            else
            {
                return new double3(todoubleunsafe(x.xy, promise), (double)x.z);
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.ulong4"/> to its respective <see cref="double"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, 2⁵²)       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 todoubleunsafe(ulong4 x, Promise promise = Promise.Unsafe0)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (promise.Promises(Promise.Unsafe0))
                {
                    return RegisterConversion.ToDouble4(Xse.mm256_usfcvtepu64_pd(x));
                }
                else
                {
                    return x;
                }
            }
            else
            {
                return new double4(todoubleunsafe(x.xy, promise), todoubleunsafe(x.zw, promise));
            }
        }


        /// <summary>       Converts each value in a <see cref="MaxMath.long2"/> to its respective <see cref="double"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [-2⁵¹, 2⁵¹]       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 todoubleunsafe(long2 x, Promise promise = Promise.Unsafe0)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (promise.Promises(Promise.Unsafe0))
                {
                    return RegisterConversion.ToDouble2(Xse.usfcvtepi64_pd(x));
                }
                else
                {
                    return x;
                }
            }
            else
            {
                return (double2)x;
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.long3"/> to its respective <see cref="double"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [-2⁵¹, 2⁵¹]       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 todoubleunsafe(long3 x, Promise promise = Promise.Unsafe0)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (promise.Promises(Promise.Unsafe0))
                {
                    return RegisterConversion.ToDouble3(Xse.mm256_usfcvtepi64_pd(x));
                }
                else
                {
                    return x;
                }
            }
            else
            {
                return new double3(todoubleunsafe(x.xy, promise), (double)x.z);
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.long4"/> to its respective <see cref="double"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [-2⁵¹, 2⁵¹]       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 todoubleunsafe(long4 x, Promise promise = Promise.Unsafe0)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (promise.Promises(Promise.Unsafe0))
                {
                    return RegisterConversion.ToDouble4(Xse.mm256_usfcvtepi64_pd(x));
                }
                else
                {
                    return x;
                }
            }
            else
            {
                return new double4(todoubleunsafe(x.xy, promise), todoubleunsafe(x.zw, promise));
            }
        }
    }
}
