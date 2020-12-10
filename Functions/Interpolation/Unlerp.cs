using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float fastunlerp(float x, float y, float t)
        {
            float2 temp = new float2(t, y) - x;

            return div(temp.x, temp.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 fastunlerp(float2 x, float2 y, float2 t)
        {
            float4 temp = new float4(t, y) - new float4(x.xyxy);

            return div(temp.xy, temp.zw);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 fastunlerp(float3 x, float3 y, float3 t)
        {
            return div(t - x, y - x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 fastunlerp(float4 x, float4 y, float4 t)
        {
            return div(t - x, y - x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 fastunlerp(float8 x, float8 y, float8 t)
        {
            return div(t - x, y - x);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double fastunlerp(double x, double y, double t)
        {
            double2 temp = new double2(t, y) - x;

            return div(temp.x, temp.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 fastunlerp(double2 x, double2 y, double2 t)
        {
            double4 temp = new double4(t, y) - new double4(x, x);

            return div(temp.xy, temp.zw);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 fastunlerp(double3 x, double3 y, double3 t)
        {
            return div(t - x, y - x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 fastunlerp(double4 x, double4 y, double4 t)
        {
            return div(t - x, y - x);
        }
    }
}