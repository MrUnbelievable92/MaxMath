using System.Runtime.CompilerServices;

namespace MaxMath
{
    unsafe public static partial class math
    {
        /// <summary>       Returns the cross product of two <see cref="MaxMath.float3"/> vectors.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 cross(float3 x, float3 y)
        {
            return Unity.Mathematics.math.cross(x, y);
        }

        /// <summary>       Returns the cross product of two <see cref="MaxMath.double3"/> vectors.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 cross(double3 x, double3 y)
        {
            return Unity.Mathematics.math.cross(x, y);
        }
    }
}