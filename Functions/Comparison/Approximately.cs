using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool approx(float a, float b, float tolerance = 0f)
        {
            return math.abs(a - b) < 0.000002f + tolerance;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 approx(float2 a, float2 b, float2 tolerance = default(float2))
        {
            return math.abs(a - b) < 0.000002f + tolerance;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 approx(float3 a, float3 b, float3 tolerance = default(float3))
        {
            return math.abs(a - b) < 0.000002f + tolerance;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 approx(float4 a, float4 b, float4 tolerance = default(float4))
        {
            return math.abs(a - b) < 0.000002f + tolerance;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x2 approx(float8 a, float8 b, float8 tolerance = new float8())
        {
            return abs(a - b) < 0.000002f + tolerance;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool approx(double a, double b, double tolerance = 0d)
        {
            return math.abs(a - b) < 0.000_000_000_000_002d + tolerance;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 approx(double2 a, double2 b, double2 tolerance = default(double2))
        {
            return math.abs(a - b) < 0.000_000_000_000_002d + tolerance;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 approx(double3 a, double3 b, double3 tolerance = default(double3))
        {
            return math.abs(a - b) < 0.000_000_000_000_002d + tolerance;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 approx(double4 a, double4 b, double4 tolerance = default(double4))
        {
            return math.abs(a - b) < 0.000_000_000_000_002d + tolerance;
        }
    }
}