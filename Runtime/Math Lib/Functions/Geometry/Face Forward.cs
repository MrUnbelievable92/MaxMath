using System.Runtime.CompilerServices;

namespace MaxMath
{
    unsafe public static partial class math
    {
        /// <summary>   Conditionally flips a vector <paramref name="n"/> if two vectors <paramref name="i"/> and <paramref name="ng"/> are pointing in the same direction. Returns <paramref name="n"/> if dot(<paramref name="i"/>, <paramref name="ng"/>) <see langword="&lt;"/> 0, <see langword="-"/><paramref name="n"/> otherwise.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 faceforward(float2 n, float2 i, float2 ng) => Unity.Mathematics.math.faceforward(n, i, ng);
        
        /// <summary>   Conditionally flips a vector <paramref name="n"/> if two vectors <paramref name="i"/> and <paramref name="ng"/> are pointing in the same direction. Returns <paramref name="n"/> if dot(<paramref name="i"/>, <paramref name="ng"/>) <see langword="&lt;"/> 0, <see langword="-"/><paramref name="n"/> otherwise.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 faceforward(float3 n, float3 i, float3 ng) => Unity.Mathematics.math.faceforward(n, i, ng);
        
        /// <summary>   Conditionally flips a vector <paramref name="n"/> if two vectors <paramref name="i"/> and <paramref name="ng"/> are pointing in the same direction. Returns <paramref name="n"/> if dot(<paramref name="i"/>, <paramref name="ng"/>) <see langword="&lt;"/> 0, <see langword="-"/><paramref name="n"/> otherwise.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 faceforward(float4 n, float4 i, float4 ng) => Unity.Mathematics.math.faceforward(n, i, ng);

        /// <summary>   Conditionally flips a vector <paramref name="n"/> if two vectors <paramref name="i"/> and <paramref name="ng"/> are pointing in the same direction. Returns <paramref name="n"/> if dot(<paramref name="i"/>, <paramref name="ng"/>) <see langword="&lt;"/> 0, <see langword="-"/><paramref name="n"/> otherwise.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 faceforward(float8 n, float8 i, float8 ng) => select(n, -n, dot(ng, i) >= 0f);
        

        /// <summary>   Conditionally flips a vector <paramref name="n"/> if two vectors <paramref name="i"/> and <paramref name="ng"/> are pointing in the same direction. Returns <paramref name="n"/> if dot(<paramref name="i"/>, <paramref name="ng"/>) <see langword="&lt;"/> 0, <see langword="-"/><paramref name="n"/> otherwise.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 faceforward(double2 n, double2 i, double2 ng) => Unity.Mathematics.math.faceforward(n, i, ng);
        
        /// <summary>   Conditionally flips a vector <paramref name="n"/> if two vectors <paramref name="i"/> and <paramref name="ng"/> are pointing in the same direction. Returns <paramref name="n"/> if dot(<paramref name="i"/>, <paramref name="ng"/>) <see langword="&lt;"/> 0, <see langword="-"/><paramref name="n"/> otherwise.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 faceforward(double3 n, double3 i, double3 ng) => Unity.Mathematics.math.faceforward(n, i, ng);
        
        /// <summary>   Conditionally flips a vector <paramref name="n"/> if two vectors <paramref name="i"/> and <paramref name="ng"/> are pointing in the same direction. Returns <paramref name="n"/> if dot(<paramref name="i"/>, <paramref name="ng"/>) <see langword="&lt;"/> 0, <see langword="-"/><paramref name="n"/> otherwise.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 faceforward(double4 n, double4 i, double4 ng) => Unity.Mathematics.math.faceforward(n, i, ng);
    }
}
