using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;
using static MaxMath.LUT.FLOATING_POINT;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the base-2 exponential of <paramref name="x"/>.    </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any x outside the interval [-127, 128].       </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float exp2(int x, Promise noOverflow = Promise.Nothing)
        {
            if (!noOverflow.Promises(Promise.NoOverflow))
            {
                x = math.clamp(x, nabs(F32_EXPONENT_BIAS), math.abs(F32_EXPONENT_BIAS) + 1);
            }

            return math.asfloat((math.abs(F32_EXPONENT_BIAS) << F32_MANTISSA_BITS) + (x << F32_MANTISSA_BITS));
        }
        
        /// <summary>       Returns the componentwise base-2 exponential of <paramref name="x"/>.    </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any x outside the interval [-127, 128].       </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 exp2(int2 x, Promise noOverflow = Promise.Nothing)
        {
            if (!noOverflow.Promises(Promise.NoOverflow))
            {
                x = math.clamp(x, nabs(F32_EXPONENT_BIAS), math.abs(F32_EXPONENT_BIAS) + 1);
            }

            return math.asfloat((math.abs(F32_EXPONENT_BIAS) << F32_MANTISSA_BITS) + (x << F32_MANTISSA_BITS));
        }
        
        /// <summary>       Returns the componentwise base-2 exponential of <paramref name="x"/>.    </summary>      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any x outside the interval [-127, 128].       </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 exp2(int3 x, Promise noOverflow = Promise.Nothing)
        {
            if (!noOverflow.Promises(Promise.NoOverflow))
            {
                x = math.clamp(x, nabs(F32_EXPONENT_BIAS), math.abs(F32_EXPONENT_BIAS) + 1);
            }

            return math.asfloat((math.abs(F32_EXPONENT_BIAS) << F32_MANTISSA_BITS) + (x << F32_MANTISSA_BITS));
        }
        
        /// <summary>       Returns the componentwise base-2 exponential of <paramref name="x"/>.    </summary>      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any x outside the interval [-127, 128].       </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 exp2(int4 x, Promise noOverflow = Promise.Nothing)
        {
            if (!noOverflow.Promises(Promise.NoOverflow))
            {
                x = math.clamp(x, nabs(F32_EXPONENT_BIAS), math.abs(F32_EXPONENT_BIAS) + 1);
            }

            return math.asfloat((math.abs(F32_EXPONENT_BIAS) << F32_MANTISSA_BITS) + (x << F32_MANTISSA_BITS));
        }
        
        /// <summary>       Returns the componentwise base-2 exponential of <paramref name="x"/>.    </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any x outside the interval [-127, 128].       </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 exp2(int8 x, Promise noOverflow = Promise.Nothing)
        {
            if (!noOverflow.Promises(Promise.NoOverflow))
            {
                x = clamp(x, nabs(F32_EXPONENT_BIAS), math.abs(F32_EXPONENT_BIAS) + 1);
            }

            return asfloat((math.abs(F32_EXPONENT_BIAS) << F32_MANTISSA_BITS) + (x << F32_MANTISSA_BITS));
        }
        

        /// <summary>       Returns the base-2 exponential of <paramref name="x"/>.    </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any x outside the interval [0, 128].       </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float exp2(uint x, Promise noOverflow = Promise.Nothing)
        {
            if (!noOverflow.Promises(Promise.NoOverflow))
            {
                x = math.min(x, (uint)math.abs(F32_EXPONENT_BIAS) + 1);
            }

            return exp2((int)x, Promise.NoOverflow);
        }
        
        /// <summary>       Returns the componentwise base-2 exponential of <paramref name="x"/>.    </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any x outside the interval [0, 128].       </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 exp2(uint2 x, Promise noOverflow = Promise.Nothing)
        {
            if (!noOverflow.Promises(Promise.NoOverflow))
            {
                x = math.min(x, (uint)math.abs(F32_EXPONENT_BIAS) + 1);
            }

            return exp2((int2)x, Promise.NoOverflow);
        }
        
        /// <summary>       Returns the componentwise base-2 exponential of <paramref name="x"/>.    </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any x outside the interval [0, 128].       </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 exp2(uint3 x, Promise noOverflow = Promise.Nothing)
        {
            if (!noOverflow.Promises(Promise.NoOverflow))
            {
                x = math.min(x, (uint)math.abs(F32_EXPONENT_BIAS) + 1);
            }

            return exp2((int3)x, Promise.NoOverflow);
        }
        
        /// <summary>       Returns the componentwise base-2 exponential of <paramref name="x"/>.    </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any x outside the interval [0, 128].       </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 exp2(uint4 x, Promise noOverflow = Promise.Nothing)
        {
            if (!noOverflow.Promises(Promise.NoOverflow))
            {
                x = math.min(x, (uint)math.abs(F32_EXPONENT_BIAS) + 1);
            }

            return exp2((int4)x, Promise.NoOverflow);
        }
        
        /// <summary>       Returns the componentwise base-2 exponential of <paramref name="x"/>.    </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any x outside the interval [0, 128].       </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 exp2(uint8 x, Promise noOverflow = Promise.Nothing)
        {
            if (!noOverflow.Promises(Promise.NoOverflow))
            {
                x = min(x, (uint)math.abs(F32_EXPONENT_BIAS) + 1);
            }

            return exp2((int8)x, Promise.NoOverflow);
        }

        
        /// <summary>       Returns the base-2 exponential of <paramref name="x"/>.    </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any x outside the interval [-1023, 1024].       </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double exp2(long x, Promise noOverflow = Promise.Nothing)
        {
            if (!noOverflow.Promises(Promise.NoOverflow))
            {
                x = math.clamp(x, nabs(F64_EXPONENT_BIAS), math.abs(F64_EXPONENT_BIAS) + 1);
            }

            return math.asdouble(((long)math.abs(F64_EXPONENT_BIAS) << F64_MANTISSA_BITS) + (x << F64_MANTISSA_BITS));
        }
        
        /// <summary>       Returns the componentwise base-2 exponential of <paramref name="x"/>.    </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any x outside the interval [-1023, 1024].       </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 exp2(long2 x, Promise noOverflow = Promise.Nothing)
        {
            if (!noOverflow.Promises(Promise.NoOverflow))
            {
                x = clamp(x, nabs(F64_EXPONENT_BIAS), math.abs(F64_EXPONENT_BIAS) + 1);
            }

            return asdouble(((long)math.abs(F64_EXPONENT_BIAS) << F64_MANTISSA_BITS) + (x << F64_MANTISSA_BITS));
        }
        
        /// <summary>       Returns the componentwise base-2 exponential of <paramref name="x"/>.    </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any x outside the interval [-1023, 1024].       </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 exp2(long3 x, Promise noOverflow = Promise.Nothing)
        {
            if (!noOverflow.Promises(Promise.NoOverflow))
            {
                x = clamp(x, nabs(F64_EXPONENT_BIAS), math.abs(F64_EXPONENT_BIAS) + 1);
            }

            return asdouble(((long)math.abs(F64_EXPONENT_BIAS) << F64_MANTISSA_BITS) + (x << F64_MANTISSA_BITS));
        }
        
        /// <summary>       Returns the componentwise base-2 exponential of <paramref name="x"/>.    </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any x outside the interval [-1023, 1024].       </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 exp2(long4 x, Promise noOverflow = Promise.Nothing)
        {
            if (!noOverflow.Promises(Promise.NoOverflow))
            {
                x = clamp(x, nabs(F64_EXPONENT_BIAS), math.abs(F64_EXPONENT_BIAS) + 1);
            }

            return asdouble(((long)math.abs(F64_EXPONENT_BIAS) << F64_MANTISSA_BITS) + (x << F64_MANTISSA_BITS));
        }
        

        /// <summary>       Returns the base-2 exponential of <paramref name="x"/>.    </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any x outside the interval [0, 1024].       </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double exp2(ulong x, Promise noOverflow = Promise.Nothing)
        {
            if (!noOverflow.Promises(Promise.NoOverflow))
            {
                x = math.min(x, (uint)math.abs(F64_EXPONENT_BIAS) + 1);
            }

            return exp2((long)x, Promise.NoOverflow);
        }
        
        /// <summary>       Returns the componentwise base-2 exponential of <paramref name="x"/>.    </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any x outside the interval [0, 1024].       </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 exp2(ulong2 x, Promise noOverflow = Promise.Nothing)
        {
            if (!noOverflow.Promises(Promise.NoOverflow))
            {
                x = min(x, (uint)math.abs(F64_EXPONENT_BIAS) + 1);
            }

            return exp2((long2)x, Promise.NoOverflow);
        }
        
        /// <summary>       Returns the componentwise base-2 exponential of <paramref name="x"/>.    </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any x outside the interval [0, 1024].       </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 exp2(ulong3 x, Promise noOverflow = Promise.Nothing)
        {
            if (!noOverflow.Promises(Promise.NoOverflow))
            {
                x = min(x, (uint)math.abs(F64_EXPONENT_BIAS) + 1);
            }

            return exp2((long3)x, Promise.NoOverflow);
        }
        
        /// <summary>       Returns the componentwise base-2 exponential of <paramref name="x"/>.    </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any x outside the interval [0, 1024].       </remarks>
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
