using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace MaxMath
{
    internal static class UnsafeFunctions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static float min(float x, float y)
        {
            return math.select(y, x, x < y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static float2 min(float2 x, float2 y)
        {
            return math.select(y, x, x < y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static float3 min(float3 x, float3 y)
        {
            return math.select(y, x, x < y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static float4 min(float4 x, float4 y)
        {
            return math.select(y, x, x < y);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static double min(double x, double y)
        {
            return math.select(y, x, x < y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static double2 min(double2 x, double2 y)
        {
            return math.select(y, x, x < y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static double3 min(double3 x, double3 y)
        {
            return math.select(y, x, x < y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static double4 min(double4 x, double4 y)
        {
            return math.select(y, x, x < y);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static float max(float x, float y)
        {
            return math.select(y, x, x > y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static float2 max(float2 x, float2 y)
        {
            return math.select(y, x, x > y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static float3 max(float3 x, float3 y)
        {
            return math.select(y, x, x > y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static float4 max(float4 x, float4 y)
        {
            return math.select(y, x, x > y);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static double max(double x, double y)
        {
            return math.select(y, x, x > y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static double2 max(double2 x, double2 y)
        {
            return math.select(y, x, x > y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static double3 max(double3 x, double3 y)
        {
            return math.select(y, x, x > y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static double4 max(double4 x, double4 y)
        {
            return math.select(y, x, x > y);
        }
    }
}
