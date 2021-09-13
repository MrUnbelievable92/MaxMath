using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Loops the <see cref="float"/> <paramref name="x"/>, so that it is never larger than the <see cref="float"/> <paramref name="length"/> and never smaller than 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float repeat(float x, float length)
        {
            return math.clamp(math.mad(math.floor(x / length), 
                                       -length, 
                                       x), 
                              0f, 
                              length);
        }

        /// <summary>       Loops the components of the <see cref="float2"/> <paramref name="x"/>, so that they are never larger than the corresponding value in the <see cref="float2"/> <paramref name="length"/> and never smaller than 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 repeat(float2 x, float2 length)
        {
            return math.clamp(math.mad(math.floor(x / length),
                                       -length,
                                       x),
                              0f,
                              length);
        }

        /// <summary>       Loops the components of the <see cref="float3"/> <paramref name="x"/>, so that they are never larger than the corresponding value in the <see cref="float3"/> <paramref name="length"/> and never smaller than 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 repeat(float3 x, float3 length)
        {
            return math.clamp(math.mad(math.floor(x / length),
                                       -length,
                                       x),
                              0f,
                              length);
        }

        /// <summary>       Loops the components of the <see cref="float4"/> <paramref name="x"/>, so that they are never larger than the corresponding value in the <see cref="float4"/> <paramref name="length"/> and never smaller than 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 repeat(float4 x, float4 length)
        {
            return math.clamp(math.mad(math.floor(x / length),
                                       -length,
                                       x),
                              0f,
                              length);
        }

        /// <summary>       Loops the components of the <see cref="MaxMath.float8"/> <paramref name="x"/>, so that they are never larger than the corresponding value in the <see cref="MaxMath.float8"/> <paramref name="length"/> and never smaller than 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 repeat(float8 x, float8 length)
        {
            return clamp(mad(floor(x / length), 
                             -length, 
                             x), 
                         0f, 
                         length);
        }


        /// <summary>       Loops the <see cref="double"/> <paramref name="x"/>, so that it is never larger than the <see cref="double"/> <paramref name="length"/> and never smaller than 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double repeat(double x, double length)
        {
            return math.clamp(math.mad(math.floor(x / length),
                                       -length,
                                       x),
                              0d,
                              length);
        }

        /// <summary>       Loops the components of the <see cref="double2"/> <paramref name="x"/>, so that they are never larger than the corresponding value in the <see cref="double2"/> <paramref name="length"/> and never smaller than 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 repeat(double2 x, double2 length)
        {
            return math.clamp(math.mad(math.floor(x / length),
                                       -length,
                                       x),
                              0d,
                              length);
        }

        /// <summary>       Loops the components of the <see cref="double3"/> <paramref name="x"/>, so that they are never larger than the corresponding value in the <see cref="double3"/> <paramref name="length"/> and never smaller than 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 repeat(double3 x, double3 length)
        {
            return math.clamp(math.mad(math.floor(x / length),
                                       -length,
                                       x),
                              0d,
                              length);
        }

        /// <summary>       Loops the components of the <see cref="double4"/> <paramref name="x"/>, so that they are never larger than the corresponding value in the <see cref="double4"/> <paramref name="length"/> and never smaller than 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 repeat(double4 x, double4 length)
        {
            return math.clamp(math.mad(math.floor(x / length),
                                       -length,
                                       x),
                              0d,
                              length);
        }
    }
}