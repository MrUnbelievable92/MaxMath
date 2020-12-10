using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns true if the two corresponding float values are approximately equal to each other, given a tolerance.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool approx(float a, float b, float tolerance = 0f)
        {
            return math.abs(a - b) < 0.000001f + tolerance;
        }

        /// <summary>       Returns a bool2 indicating for each component of a float2 vector whether it is approximately equal to the corresponding component in the other float2 vector, given a tolerance.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 approx(float2 a, float2 b, float2 tolerance = default(float2))
        {
            return math.abs(a - b) < 0.000001f + tolerance;
        }

        /// <summary>       Returns a bool3 indicating for each component of a float3 vector whether it is approximately equal to the corresponding component in the other float3 vector, given a tolerance.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 approx(float3 a, float3 b, float3 tolerance = default(float3))
        {
            return math.abs(a - b) < 0.000001f + tolerance;
        }

        /// <summary>       Returns a bool4 indicating for each component of a float4 vector whether it is approximately equal to the corresponding component in the other float4 vector, given a tolerance.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 approx(float4 a, float4 b, float4 tolerance = default(float4))
        {
            return math.abs(a - b) < 0.000001f + tolerance;
        }

        /// <summary>       Returns a bool8 indicating for each component of a float8 vector whether it is approximately equal to the corresponding component in the other float8 vector, given a tolerance.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 approx(float8 a, float8 b, float8 tolerance = new float8())
        {
            return abs(a - b) < 0.000001f + tolerance;
        }


        /// <summary>       Returns true if the two corresponding double values are approximately equal to each other, given a tolerance.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool approx(double a, double b, double tolerance = 0d)
        {
            return math.abs(a - b) < 0.000_000_000_000_001d + tolerance;
        }

        /// <summary>       Returns a bool2 indicating for each component of a double2 vector whether it is approximately equal to the corresponding component in the other double2 vector, given a tolerance.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 approx(double2 a, double2 b, double2 tolerance = default(double2))
        {
            return math.abs(a - b) < 0.000_000_000_000_001d + tolerance;
        }

        /// <summary>       Returns a bool3 indicating for each component of a double3 vector whether it is approximately equal to the corresponding component in the other double3 vector, given a tolerance.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 approx(double3 a, double3 b, double3 tolerance = default(double3))
        {
            return math.abs(a - b) < 0.000_000_000_000_001d + tolerance;
        }

        /// <summary>       Returns a bool4 indicating for each component of a double4 vector whether it is approximately equal to the corresponding component in the other double4 vector, given a tolerance.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 approx(double4 a, double4 b, double4 tolerance = default(double4))
        {
            return math.abs(a - b) < 0.000_000_000_000_001d + tolerance;
        }
    }
}