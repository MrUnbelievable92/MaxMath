using System.Runtime.CompilerServices;

namespace MaxMath
{
    unsafe public static partial class math
    {
        /// <summary>   Return the result of transforming a <see cref="MaxMath.float3"/> point by a <see cref="MaxMath.float4x4"/> matrix.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 transform(float4x4 a, float3 b)
        {
            return a.c0.xyz * b.xxx + a.c1.xyz * b.yyy + a.c2.xyz * b.zzz + a.c3.xyz;
        }

        /// <summary>   Return the result of transforming a <see cref="MaxMath.double3"/> point by a <see cref="MaxMath.double4x4"/> matrix.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 transform(double4x4 a, double3 b)
        {
            return a.c0.xyz * b.xxx + a.c1.xyz * b.yyy + a.c2.xyz * b.zzz + a.c3.xyz;
        }
    }
}
