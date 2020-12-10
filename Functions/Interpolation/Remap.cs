using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float fastremap(float a, float b, float c, float d, float x)
        {
            return math.lerp(c, d,fastunlerp(a, b, x));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 fastremap(float2 a, float2 b, float2 c, float2 d, float2 x)
        {
            return math.lerp(c, d,fastunlerp(a, b, x));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 fastremap(float3 a, float3 b, float3 c, float3 d, float3 x)
        {
            return math.lerp(c, d,fastunlerp(a, b, x));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 fastremap(float4 a, float4 b, float4 c, float4 d, float4 x)
        {
            return math.lerp(c, d,fastunlerp(a, b, x));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 fastremap(float8 a, float8 b, float8 c, float8 d, float8 x)
        {
            return lerp(c, d,fastunlerp(a, b, x));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double fastremap(double a, double b, double c, double d, double x)
        {
            return math.lerp(c, d,fastunlerp(a, b, x));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 fastremap(double2 a, double2 b, double2 c, double2 d, double2 x)
        {
            return math.lerp(c, d,fastunlerp(a, b, x));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 fastremap(double3 a, double3 b, double3 c, double3 d, double3 x)
        {
            return math.lerp(c, d,fastunlerp(a, b, x));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 fastremap(double4 a, double4 b, double4 c, double4 d, double4 x)
        {
            return math.lerp(c, d,fastunlerp(a, b, x));
        }
    }
}