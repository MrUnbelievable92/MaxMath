using System.Runtime.CompilerServices;

namespace MaxMath
{
    unsafe public static partial class math
    {
        /// <summary>   Given an incident vector <paramref name="i"/> and a normal vector <paramref name="n"/>, returns the reflection vector r = <paramref name="i"/> - 2.0 * dot(<paramref name="i"/>, <paramref name="n"/>) * <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 reflect(float2 i, float2 n) => Unity.Mathematics.math.reflect(i, n);
        
        /// <summary>   Given an incident vector <paramref name="i"/> and a normal vector <paramref name="n"/>, returns the reflection vector r = <paramref name="i"/> - 2.0 * dot(<paramref name="i"/>, <paramref name="n"/>) * <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 reflect(float3 i, float3 n) => Unity.Mathematics.math.reflect(i, n);
        
        /// <summary>   Given an incident vector <paramref name="i"/> and a normal vector <paramref name="n"/>, returns the reflection vector r = <paramref name="i"/> - 2.0 * dot(<paramref name="i"/>, <paramref name="n"/>) * <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 reflect(float4 i, float4 n) => Unity.Mathematics.math.reflect(i, n);
        
        /// <summary>   Given an incident vector <paramref name="i"/> and a normal vector <paramref name="n"/>, returns the reflection vector r = <paramref name="i"/> - 2.0 * dot(<paramref name="i"/>, <paramref name="n"/>) * <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 reflect(float8 i, float8 n) => i - 2 * n * dot(i, n);
        

        /// <summary>   Given an incident vector <paramref name="i"/> and a normal vector <paramref name="n"/>, returns the reflection vector r = <paramref name="i"/> - 2.0 * dot(<paramref name="i"/>, <paramref name="n"/>) * <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 reflect(double2 i, double2 n) => Unity.Mathematics.math.reflect(i, n);
        
        /// <summary>   Given an incident vector <paramref name="i"/> and a normal vector <paramref name="n"/>, returns the reflection vector r = <paramref name="i"/> - 2.0 * dot(<paramref name="i"/>, <paramref name="n"/>) * <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 reflect(double3 i, double3 n) => Unity.Mathematics.math.reflect(i, n);
        
        /// <summary>   Given an incident vector <paramref name="i"/> and a normal vector <paramref name="n"/>, returns the reflection vector r = <paramref name="i"/> - 2.0 * dot(<paramref name="i"/>, <paramref name="n"/>) * <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 reflect(double4 i, double4 n) => Unity.Mathematics.math.reflect(i, n);
        
    }
}
