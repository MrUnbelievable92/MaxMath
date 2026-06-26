using System.Runtime.CompilerServices;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class math
    {
        /// <summary>       Converts a <see cref="MaxMath.quarter"/> to its <see cref="float"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for input values outside the interval [-3.40282346638528859811704183484516925440e+38, 3.40282346638528859811704183484516925440e+38].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values, including negative 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float tofloatunsafe(quarter x, Promise promise = Promise.Nothing)
        {
            return MaxMath.quarter.ToFloat(x, inRange: promise.Promises(Promise.NoOverflow), abs: promise.Promises(Promise.ZeroOrGreater));
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.quarter2"/> to its respective <see cref="float"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for input values outside the interval [-3.40282346638528859811704183484516925440e+38, 3.40282346638528859811704183484516925440e+38].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values, including negative 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 tofloatunsafe(quarter2 x, Promise promise = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtpq_ps(x, promiseInRange: promise.Promises(Promise.NoOverflow), promiseAbs: promise.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new float2(tofloatunsafe(x.x, promise), tofloatunsafe(x.y, promise));
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.quarter3"/> to its respective <see cref="float"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for input values outside the interval [-3.40282346638528859811704183484516925440e+38, 3.40282346638528859811704183484516925440e+38].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values, including negative 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 tofloatunsafe(quarter3 x, Promise promise = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtpq_ps(x, promiseInRange: promise.Promises(Promise.NoOverflow), promiseAbs: promise.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new float3(tofloatunsafe(x.x, promise), tofloatunsafe(x.y, promise), tofloatunsafe(x.z, promise));
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.quarter4"/> to its respective <see cref="float"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for input values outside the interval [-3.40282346638528859811704183484516925440e+38, 3.40282346638528859811704183484516925440e+38].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values, including negative 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 tofloatunsafe(quarter4 x, Promise promise = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtpq_ps(x, promiseInRange: promise.Promises(Promise.NoOverflow), promiseAbs: promise.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new float4(tofloatunsafe(x.x, promise), tofloatunsafe(x.y, promise), tofloatunsafe(x.z, promise), tofloatunsafe(x.w, promise));
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.quarter8"/> to its respective <see cref="float"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for input values outside the interval [-3.40282346638528859811704183484516925440e+38, 3.40282346638528859811704183484516925440e+38].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values, including negative 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 tofloatunsafe(quarter8 x, Promise promise = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtpq_ps(x, promiseInRange: promise.Promises(Promise.NoOverflow), promiseAbs: promise.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new float8(tofloatunsafe(x.v4_0, promise), tofloatunsafe(x.v4_4, promise));
            }
        }

        
        /// <summary>       Converts a <see cref="MaxMath.half"/> to its <see cref="float"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for input values outside the interval [-3.40282346638528859811704183484516925440e+38, 3.40282346638528859811704183484516925440e+38].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values, including negative 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float tofloatunsafe(half x, Promise promise = Promise.Nothing)
        {
            return MaxMath.half.ToFloat(x, inRange: promise.Promises(Promise.NoOverflow), abs: promise.Promises(Promise.ZeroOrGreater));
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.half2"/> to its respective <see cref="float"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for input values outside the interval [-3.40282346638528859811704183484516925440e+38, 3.40282346638528859811704183484516925440e+38].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values, including negative 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 tofloatunsafe(half2 x, Promise promise = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtph_ps(x, promiseInRange: promise.Promises(Promise.NoOverflow), promiseAbs: promise.Promises(Promise.ZeroOrGreater), elements: 2);
            }
            else
            {
                return new float2(tofloatunsafe(x.x, promise), tofloatunsafe(x.y, promise));
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.half3"/> to its respective <see cref="float"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for input values outside the interval [-3.40282346638528859811704183484516925440e+38, 3.40282346638528859811704183484516925440e+38].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values, including negative 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 tofloatunsafe(half3 x, Promise promise = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtph_ps(x, promiseInRange: promise.Promises(Promise.NoOverflow), promiseAbs: promise.Promises(Promise.ZeroOrGreater), elements: 3);
            }
            else
            {
                return new float3(tofloatunsafe(x.x, promise), tofloatunsafe(x.y, promise), tofloatunsafe(x.z, promise));
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.half4"/> to its respective <see cref="float"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for input values outside the interval [-3.40282346638528859811704183484516925440e+38, 3.40282346638528859811704183484516925440e+38].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values, including negative 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 tofloatunsafe(half4 x, Promise promise = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtph_ps(x, promiseInRange: promise.Promises(Promise.NoOverflow), promiseAbs: promise.Promises(Promise.ZeroOrGreater), elements: 4);
            }
            else
            {
                return new float4(tofloatunsafe(x.x, promise), tofloatunsafe(x.y, promise), tofloatunsafe(x.z, promise), tofloatunsafe(x.w, promise));
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.half8"/> to its respective <see cref="float"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for input values outside the interval [-3.40282346638528859811704183484516925440e+38, 3.40282346638528859811704183484516925440e+38].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values, including negative 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 tofloatunsafe(half8 x, Promise promise = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtph_ps(x);
            }
            else
            {
                return new float8(tofloatunsafe(x.v4_0, promise), tofloatunsafe(x.v4_4, promise));
            }
        }
    }
}
