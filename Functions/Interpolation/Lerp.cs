using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float lerp(float from, float to, float t)
        {
            return math.mad(t, (to - from), from);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 lerp(float2 from, float2 to, float2 t)
        {
            return math.mad(t, (to - from), from);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 lerp(float3 from, float3 to, float3 t)
        {
            return math.mad(t, (to - from), from);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 lerp(float4 from, float4 to, float4 t)
        {
            return math.mad(t, (to - from), from);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 lerp(float8 from, float8 to, float8 t)
        {
            return mad(t, (to - from), from);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double lerp(double from, double to, double t)
        {
            return math.mad(t, (to - from), from);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 lerp(double2 from, double2 to, double2 t)
        {
            return math.mad(t, (to - from), from);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 lerp(double3 from, double3 to, double3 t)
        {
            return math.mad(t, (to - from), from);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 lerp(double4 from, double4 to, double4 t)
        {
            return math.mad(t, (to - from), from);
        }
    }
}