using System.Runtime.CompilerServices;

namespace MaxMath
{
    unsafe public static partial class math
    {
        /// <summary>   Multiplies matrix rows by scale components
        /// <para>  m.c0.x * s.x | m.c1.x * s.y | m.c2.x * s.z  </para>
        /// <para>  m.c0.y * s.x | m.c1.y * s.y | m.c2.y * s.z  </para>
        /// <para>  m.c0.z * s.x | m.c1.z * s.y | m.c2.z * s.z  </para>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x3 mulScale(float3x3 m, float3 s) => Unity.Mathematics.math.mulScale(m, s);

        /// <summary>   Multiplies matrix rows by scale components
        /// <para>  m.c0.x * s.x | m.c1.x * s.x | m.c2.x * s.x  </para>
        /// <para>  m.c0.y * s.y | m.c1.y * s.y | m.c2.y * s.y  </para>
        /// <para>  m.c0.z * s.z | m.c1.z * s.z | m.c2.z * s.z  </para>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x3 scaleMul(float3 s, float3x3 m) => Unity.Mathematics.math.scaleMul(s, m);


        /// <summary>   Multiplies matrix rows by scale components
        /// <para>  m.c0.x * s.x | m.c1.x * s.y | m.c2.x * s.z  </para>
        /// <para>  m.c0.y * s.x | m.c1.y * s.y | m.c2.y * s.z  </para>
        /// <para>  m.c0.z * s.x | m.c1.z * s.y | m.c2.z * s.z  </para>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x3 mulScale(double3x3 m, double3 s) => new double3x3(m.c0 * s.x, m.c1 * s.y, m.c2 * s.z);

        /// <summary>   Multiplies matrix rows by scale components
        /// <para>  m.c0.x * s.x | m.c1.x * s.x | m.c2.x * s.x  </para>
        /// <para>  m.c0.y * s.y | m.c1.y * s.y | m.c2.y * s.y  </para>
        /// <para>  m.c0.z * s.z | m.c1.z * s.z | m.c2.z * s.z  </para>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x3 scaleMul(double3 s, double3x3 m) => new double3x3(m.c0 * s, m.c1 * s, m.c2 * s);
    }
}