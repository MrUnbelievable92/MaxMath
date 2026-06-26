using System.Runtime.CompilerServices;

namespace MaxMath
{
    unsafe public static partial class math
    {
        /// <summary>   Compute vector projection of <paramref name="a"/> onto <paramref name="b"/>.  </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 project(float2 a, float2 b) => Unity.Mathematics.math.project(a, b);
        
        /// <summary>   Compute vector projection of <paramref name="a"/> onto <paramref name="b"/>.  </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 project(float3 a, float3 b) => Unity.Mathematics.math.project(a, b);
        
        /// <summary>   Compute vector projection of <paramref name="a"/> onto <paramref name="b"/>.  </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 project(float4 a, float4 b) => Unity.Mathematics.math.project(a, b);

        /// <summary>   Compute vector projection of <paramref name="a"/> onto <paramref name="b"/>.  </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 project(float8 a, float8 b) => (dot(a, b) / dot(b, b)) * b;
        
        
        /// <summary>   Compute vector projection of <paramref name="a"/> onto <paramref name="b"/>.  </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 project(double2 a, double2 b) => Unity.Mathematics.math.project(a, b);
        
        /// <summary>   Compute vector projection of <paramref name="a"/> onto <paramref name="b"/>.  </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 project(double3 a, double3 b) => Unity.Mathematics.math.project(a, b);
        
        /// <summary>   Compute vector projection of <paramref name="a"/> onto <paramref name="b"/>.  </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 project(double4 a, double4 b) => Unity.Mathematics.math.project(a, b);
        

        /// <summary>   Compute vector projection of <paramref name="a"/> onto <paramref name="b"/>. If result is not finite, then return <paramref name="defaultValue"/> instead.  </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 projectsafe(float2 a, float2 b, float2 defaultValue = default) => Unity.Mathematics.math.projectsafe(a, b, defaultValue);

        /// <summary>   Compute vector projection of <paramref name="a"/> onto <paramref name="b"/>. If result is not finite, then return <paramref name="defaultValue"/> instead.  </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 projectsafe(float3 a, float3 b, float3 defaultValue = default) => Unity.Mathematics.math.projectsafe(a, b, defaultValue);

        /// <summary>   Compute vector projection of <paramref name="a"/> onto <paramref name="b"/>. If result is not finite, then return <paramref name="defaultValue"/> instead.  </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 projectsafe(float4 a, float4 b, float4 defaultValue = default) => Unity.Mathematics.math.projectsafe(a, b, defaultValue);

        /// <summary>   Compute vector projection of <paramref name="a"/> onto <paramref name="b"/>. If result is not finite, then return <paramref name="defaultValue"/> instead.  </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 projectsafe(float8 a, float8 b, float8 defaultValue = default)
        {
            float8 proj = project(a, b);

            return select(defaultValue, proj, all(isfinite(proj)));
        }
        

        /// <summary>   Compute vector projection of <paramref name="a"/> onto <paramref name="b"/>. If result is not finite, then return <paramref name="defaultValue"/> instead.  </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 projectsafe(double2 a, double2 b, double2 defaultValue = default) => Unity.Mathematics.math.projectsafe(a, b, defaultValue);

        /// <summary>   Compute vector projection of <paramref name="a"/> onto <paramref name="b"/>. If result is not finite, then return <paramref name="defaultValue"/> instead.  </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 projectsafe(double3 a, double3 b, double3 defaultValue = default) => Unity.Mathematics.math.projectsafe(a, b, defaultValue);

        /// <summary>   Compute vector projection of <paramref name="a"/> onto <paramref name="b"/>. If result is not finite, then return <paramref name="defaultValue"/> instead.  </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 projectsafe(double4 a, double4 b, double4 defaultValue = default) => Unity.Mathematics.math.projectsafe(a, b, defaultValue);
    }
}
