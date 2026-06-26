using System.Runtime.CompilerServices;

namespace MaxMath
{
    unsafe public static partial class math
    {
        /// <summary>   Returns the refraction vector given the incident vector <paramref name="i"/>, the normal vector <paramref name="n"/> and the refraction index <paramref name="indexOfRefraction"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 refract(float2 i, float2 n, float indexOfRefraction) => Unity.Mathematics.math.refract(i, n, indexOfRefraction);

        /// <summary>   Returns the refraction vector given the incident vector <paramref name="i"/>, the normal vector <paramref name="n"/> and the refraction index <paramref name="indexOfRefraction"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 refract(float3 i, float3 n, float indexOfRefraction) => Unity.Mathematics.math.refract(i, n, indexOfRefraction);

        /// <summary>   Returns the refraction vector given the incident vector <paramref name="i"/>, the normal vector <paramref name="n"/> and the refraction index <paramref name="indexOfRefraction"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 refract(float4 i, float4 n, float indexOfRefraction) => Unity.Mathematics.math.refract(i, n, indexOfRefraction);

        /// <summary>   Returns the refraction vector given the incident vector <paramref name="i"/>, the normal vector <paramref name="n"/> and the refraction index <paramref name="indexOfRefraction"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 refract(float8 i, float8 n, float indexOfRefraction)
        {
            float ni = dot(n, i);
            float k = 1f - indexOfRefraction * indexOfRefraction * (1f - ni * ni);
            return select(0f, indexOfRefraction * i - (indexOfRefraction * ni + sqrt(k)) * n, k >= 0);
        }


        /// <summary>   Returns the refraction vector given the incident vector <paramref name="i"/>, the normal vector <paramref name="n"/> and the refraction index <paramref name="indexOfRefraction"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 refract(double2 i, double2 n, double indexOfRefraction) => Unity.Mathematics.math.refract(i, n, indexOfRefraction);

        /// <summary>   Returns the refraction vector given the incident vector <paramref name="i"/>, the normal vector <paramref name="n"/> and the refraction index <paramref name="indexOfRefraction"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 refract(double3 i, double3 n, double indexOfRefraction) => Unity.Mathematics.math.refract(i, n, indexOfRefraction);

        /// <summary>   Returns the refraction vector given the incident vector <paramref name="i"/>, the normal vector <paramref name="n"/> and the refraction index <paramref name="indexOfRefraction"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 refract(double4 i, double4 n, double indexOfRefraction) => Unity.Mathematics.math.refract(i, n, indexOfRefraction);

    }
}
