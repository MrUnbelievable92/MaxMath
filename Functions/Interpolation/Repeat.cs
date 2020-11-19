using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float repeat(float x, float length)
        {
            return math.clamp(math.mad(math.floor(div(x, length)), -length, x), 0f, length);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 repeat(float2 x, float2 length)
        {
            return math.clamp(math.mad(math.floor(div(x, length)), -length, x), 0f, length);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 repeat(float3 x, float3 length)
        {
            return math.clamp(math.mad(math.floor(div(x, length)), -length, x), 0f, length);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 repeat(float4 x, float4 length)
        {
            return math.clamp(math.mad(math.floor(div(x, length)), -length, x), 0f, length);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 repeat(float8 x, float8 length)
        {
            return clamp(mad(floor(div(x, length)), -length, x), 0f, length);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double repeat(double x, double length)
        {
            return math.clamp(math.mad(math.floor(div(x, length)), -length, x), 0d, length);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 repeat(double2 x, double2 length)
        {
            return math.clamp(math.mad(math.floor(div(x, length)), -length, x), 0d, length);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 repeat(double3 x, double3 length)
        {
            return math.clamp(math.mad(math.floor(div(x, length)), -length, x), 0d, length);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 repeat(double4 x, double4 length)
        {
            return math.clamp(math.mad(math.floor(div(x, length)), -length, x), 0d, length);
        }
    }
}