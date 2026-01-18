using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;
using MaxMath.Intrinsics;

using static MaxMath.LUT.FLOATING_POINT;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the base-2 exponential of <paramref name="x"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any x outside the interval [-127, 128].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float exp2(int x, Promise noOverflow = Promise.Nothing)
        {
            if (!noOverflow.Promises(Promise.NoOverflow))
            {
                if (BurstArchitecture.IsMinMaxSupported)
                {
                    v128 MIN_EXPONENT = Xse.cvtsi32_si128(nabs(F32_EXPONENT_BIAS)           << F32_MANTISSA_BITS);
                    v128 MAX_EXPONENT = Xse.cvtsi32_si128((math.abs(F32_EXPONENT_BIAS) + 1) << F32_MANTISSA_BITS);
                    v128 BIAS         = Xse.cvtsi32_si128(math.abs(F32_EXPONENT_BIAS)       << F32_MANTISSA_BITS);

                    v128 mov = Xse.cvtsi32_si128(x << F32_MANTISSA_BITS);
                    v128 clamped = Xse.max_epi32(MIN_EXPONENT, Xse.min_epi32(mov, MAX_EXPONENT));

                    return Xse.add_epi32(BIAS, clamped).Float0;
                }
                else
                {
                    x = math.clamp(x, nabs(F32_EXPONENT_BIAS), math.abs(F32_EXPONENT_BIAS) + 1);
                }
            }

            return math.asfloat((math.abs(F32_EXPONENT_BIAS) << F32_MANTISSA_BITS) + (x << F32_MANTISSA_BITS));
        }

        /// <summary>       Returns the componentwise base-2 exponential of <paramref name="x"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any x outside the interval [-127, 128].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 exp2(int2 x, Promise noOverflow = Promise.Nothing)
        {
            if (!noOverflow.Promises(Promise.NoOverflow))
            {
                x = math.clamp(x, nabs(F32_EXPONENT_BIAS), math.abs(F32_EXPONENT_BIAS) + 1);
            }

            return math.asfloat((math.abs(F32_EXPONENT_BIAS) << F32_MANTISSA_BITS) + (x << F32_MANTISSA_BITS));
        }

        /// <summary>       Returns the componentwise base-2 exponential of <paramref name="x"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any x outside the interval [-127, 128].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 exp2(int3 x, Promise noOverflow = Promise.Nothing)
        {
            if (!noOverflow.Promises(Promise.NoOverflow))
            {
                x = math.clamp(x, nabs(F32_EXPONENT_BIAS), math.abs(F32_EXPONENT_BIAS) + 1);
            }

            return math.asfloat((math.abs(F32_EXPONENT_BIAS) << F32_MANTISSA_BITS) + (x << F32_MANTISSA_BITS));
        }

        /// <summary>       Returns the componentwise base-2 exponential of <paramref name="x"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any x outside the interval [-127, 128].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 exp2(int4 x, Promise noOverflow = Promise.Nothing)
        {
            if (!noOverflow.Promises(Promise.NoOverflow))
            {
                x = math.clamp(x, nabs(F32_EXPONENT_BIAS), math.abs(F32_EXPONENT_BIAS) + 1);
            }

            return math.asfloat((math.abs(F32_EXPONENT_BIAS) << F32_MANTISSA_BITS) + (x << F32_MANTISSA_BITS));
        }

        /// <summary>       Returns the componentwise base-2 exponential of <paramref name="x"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any x outside the interval [-127, 128].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 exp2(int8 x, Promise noOverflow = Promise.Nothing)
        {
            if (!noOverflow.Promises(Promise.NoOverflow))
            {
                x = clamp(x, nabs(F32_EXPONENT_BIAS), math.abs(F32_EXPONENT_BIAS) + 1);
            }

            return asfloat((math.abs(F32_EXPONENT_BIAS) << F32_MANTISSA_BITS) + (x << F32_MANTISSA_BITS));
        }


        /// <summary>       Returns the base-2 exponential of <paramref name="x"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any x outside the interval [0, 128].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float exp2(uint x, Promise noOverflow = Promise.Nothing)
        {
            if (!noOverflow.Promises(Promise.NoOverflow))
            {
                x = math.min(x, (uint)math.abs(F32_EXPONENT_BIAS) + 1);
            }

            return exp2((int)x, Promise.NoOverflow);
        }

        /// <summary>       Returns the componentwise base-2 exponential of <paramref name="x"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any x outside the interval [0, 128].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 exp2(uint2 x, Promise noOverflow = Promise.Nothing)
        {
            if (!noOverflow.Promises(Promise.NoOverflow))
            {
                x = math.min(x, (uint)math.abs(F32_EXPONENT_BIAS) + 1);
            }

            return exp2((int2)x, Promise.NoOverflow);
        }

        /// <summary>       Returns the componentwise base-2 exponential of <paramref name="x"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any x outside the interval [0, 128].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 exp2(uint3 x, Promise noOverflow = Promise.Nothing)
        {
            if (!noOverflow.Promises(Promise.NoOverflow))
            {
                x = math.min(x, (uint)math.abs(F32_EXPONENT_BIAS) + 1);
            }

            return exp2((int3)x, Promise.NoOverflow);
        }

        /// <summary>       Returns the componentwise base-2 exponential of <paramref name="x"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any x outside the interval [0, 128].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 exp2(uint4 x, Promise noOverflow = Promise.Nothing)
        {
            if (!noOverflow.Promises(Promise.NoOverflow))
            {
                x = math.min(x, (uint)math.abs(F32_EXPONENT_BIAS) + 1);
            }

            return exp2((int4)x, Promise.NoOverflow);
        }

        /// <summary>       Returns the componentwise base-2 exponential of <paramref name="x"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any x outside the interval [0, 128].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 exp2(uint8 x, Promise noOverflow = Promise.Nothing)
        {
            if (!noOverflow.Promises(Promise.NoOverflow))
            {
                x = min(x, (uint)math.abs(F32_EXPONENT_BIAS) + 1);
            }

            return exp2((int8)x, Promise.NoOverflow);
        }


        /// <summary>       Returns the base-2 exponential of <paramref name="x"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any x outside the interval [-1023, 1024].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double exp2(long x, Promise noOverflow = Promise.Nothing)
        {
            if (!noOverflow.Promises(Promise.NoOverflow))
            {
                x = math.clamp(x, nabs(F64_EXPONENT_BIAS), math.abs(F64_EXPONENT_BIAS) + 1);
            }

            return math.asdouble(((long)math.abs(F64_EXPONENT_BIAS) << F64_MANTISSA_BITS) + (x << F64_MANTISSA_BITS));
        }

        /// <summary>       Returns the componentwise base-2 exponential of <paramref name="x"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any x outside the interval [-1023, 1024].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 exp2(long2 x, Promise noOverflow = Promise.Nothing)
        {
            if (!noOverflow.Promises(Promise.NoOverflow))
            {
                x = clamp(x, nabs(F64_EXPONENT_BIAS), math.abs(F64_EXPONENT_BIAS) + 1);
            }

            return asdouble(((long)math.abs(F64_EXPONENT_BIAS) << F64_MANTISSA_BITS) + (x << F64_MANTISSA_BITS));
        }

        /// <summary>       Returns the componentwise base-2 exponential of <paramref name="x"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any x outside the interval [-1023, 1024].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 exp2(long3 x, Promise noOverflow = Promise.Nothing)
        {
            if (!noOverflow.Promises(Promise.NoOverflow))
            {
                x = clamp(x, nabs(F64_EXPONENT_BIAS), math.abs(F64_EXPONENT_BIAS) + 1);
            }

            return asdouble(((long)math.abs(F64_EXPONENT_BIAS) << F64_MANTISSA_BITS) + (x << F64_MANTISSA_BITS));
        }

        /// <summary>       Returns the componentwise base-2 exponential of <paramref name="x"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any x outside the interval [-1023, 1024].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 exp2(long4 x, Promise noOverflow = Promise.Nothing)
        {
            if (!noOverflow.Promises(Promise.NoOverflow))
            {
                x = clamp(x, nabs(F64_EXPONENT_BIAS), math.abs(F64_EXPONENT_BIAS) + 1);
            }

            return asdouble(((long)math.abs(F64_EXPONENT_BIAS) << F64_MANTISSA_BITS) + (x << F64_MANTISSA_BITS));
        }


        /// <summary>       Returns the base-2 exponential of <paramref name="x"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any x outside the interval [0, 1024].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double exp2(ulong x, Promise noOverflow = Promise.Nothing)
        {
            if (!noOverflow.Promises(Promise.NoOverflow))
            {
                x = math.min(x, (uint)math.abs(F64_EXPONENT_BIAS) + 1);
            }

            return exp2((long)x, Promise.NoOverflow);
        }

        /// <summary>       Returns the componentwise base-2 exponential of <paramref name="x"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any x outside the interval [0, 1024].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 exp2(ulong2 x, Promise noOverflow = Promise.Nothing)
        {
            if (!noOverflow.Promises(Promise.NoOverflow))
            {
                x = min(x, (uint)math.abs(F64_EXPONENT_BIAS) + 1);
            }

            return exp2((long2)x, Promise.NoOverflow);
        }

        /// <summary>       Returns the componentwise base-2 exponential of <paramref name="x"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any x outside the interval [0, 1024].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 exp2(ulong3 x, Promise noOverflow = Promise.Nothing)
        {
            if (!noOverflow.Promises(Promise.NoOverflow))
            {
                x = min(x, (uint)math.abs(F64_EXPONENT_BIAS) + 1);
            }

            return exp2((long3)x, Promise.NoOverflow);
        }

        /// <summary>       Returns the componentwise base-2 exponential of <paramref name="x"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any x outside the interval [0, 1024].       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 exp2(ulong4 x, Promise noOverflow = Promise.Nothing)
        {
            if (!noOverflow.Promises(Promise.NoOverflow))
            {
                x = min(x, (uint)math.abs(F64_EXPONENT_BIAS) + 1);
            }

            return exp2((long4)x, Promise.NoOverflow);
        }
    }
}
