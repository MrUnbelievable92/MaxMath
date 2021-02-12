using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Loops the float value x, so that it is never larger than the float value length and never smaller than 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float repeat(float x, float length)
        {
            return math.clamp(math.mad(math.floor(x / length), 
                                       -length, 
                                       x), 
                              0f, 
                              length);
        }

        /// <summary>       Loops the components of the float2 vector x, so that they are never larger than the corresponding value in the float2 vector length and never smaller than 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 repeat(float2 x, float2 length)
        {
            return math.clamp(math.mad(math.floor(x / length),
                                       -length,
                                       x),
                              0f,
                              length);
        }

        /// <summary>       Loops the components of the float3 vector x, so that they are never larger than the corresponding value in the float3 vector length and never smaller than 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 repeat(float3 x, float3 length)
        {
            return math.clamp(math.mad(math.floor(x / length),
                                       -length,
                                       x),
                              0f,
                              length);
        }

        /// <summary>       Loops the components of the float4 vector x, so that they are never larger than the corresponding value in the float4 vector length and never smaller than 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 repeat(float4 x, float4 length)
        {
            return math.clamp(math.mad(math.floor(x / length),
                                       -length,
                                       x),
                              0f,
                              length);
        }

        /// <summary>       Loops the components of the float8 vector x, so that they are never larger than the corresponding value in the float8 vector length and never smaller than 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 repeat(float8 x, float8 length)
        {
            return clamp(mad(floor(x / length), 
                             -length, 
                             x), 
                         0f, 
                         length);
        }


        /// <summary>       Loops the double value x, so that it is never larger than the double value length and never smaller than 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double repeat(double x, double length)
        {
            return math.clamp(math.mad(math.floor(x / length),
                                       -length,
                                       x),
                              0d,
                              length);
        }

        /// <summary>       Loops the components of the double2 vector x, so that they are never larger than the corresponding value in the double2 vector length and never smaller than 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 repeat(double2 x, double2 length)
        {
            return math.clamp(math.mad(math.floor(x / length),
                                       -length,
                                       x),
                              0d,
                              length);
        }

        /// <summary>       Loops the components of the double3 vector x, so that they are never larger than the corresponding value in the double3 vector length and never smaller than 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 repeat(double3 x, double3 length)
        {
            return math.clamp(math.mad(math.floor(x / length),
                                       -length,
                                       x),
                              0d,
                              length);
        }

        /// <summary>       Loops the components of the double4 vector x, so that they are never larger than the corresponding value in the double4 vector length and never smaller than 0.     </summary>
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