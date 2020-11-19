using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float remap(float a, float b, float c, float d, float x)
        {
            return lerp(c, d, unlerp(a, b, x));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 remap(float2 a, float2 b, float2 c, float2 d, float2 x)
        {
            return lerp(c, d, unlerp(a, b, x));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 remap(float3 a, float3 b, float3 c, float3 d, float3 x)
        {
            return lerp(c, d, unlerp(a, b, x));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 remap(float4 a, float4 b, float4 c, float4 d, float4 x)
        {
            return lerp(c, d, unlerp(a, b, x));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 remap(float8 a, float8 b, float8 c, float8 d, float8 x)
        {
            return lerp(c, d, unlerp(a, b, x));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double remap(double a, double b, double c, double d, double x)
        {
            return lerp(c, d, unlerp(a, b, x));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 remap(double2 a, double2 b, double2 c, double2 d, double2 x)
        {
            return lerp(c, d, unlerp(a, b, x));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 remap(double3 a, double3 b, double3 c, double3 d, double3 x)
        {
            return lerp(c, d, unlerp(a, b, x));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 remap(double4 a, double4 b, double4 c, double4 d, double4 x)
        {
            return lerp(c, d, unlerp(a, b, x));
        }
    }
}