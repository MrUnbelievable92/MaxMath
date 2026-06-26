using System.Runtime.CompilerServices;

namespace MaxMath
{
    unsafe public static partial class math
    {
        /// <summary>       Generate an orthonormal basis given a single unit length normal vector.     </summary>
        public static void orthonormal_basis(float3 normal, out float3 basis1, out float3 basis2)
        {
            Unity.Mathematics.math.orthonormal_basis(normal, out Unity.Mathematics.float3 __basis1, out Unity.Mathematics.float3 __basis2);
            basis1 = __basis1;
            basis2 = __basis2;
        }
        
        /// <summary>       Generate an orthonormal basis given a single unit length normal vector.     </summary>
        public static void orthonormal_basis(double3 normal, out double3 basis1, out double3 basis2)
        {
            Unity.Mathematics.math.orthonormal_basis(normal, out Unity.Mathematics.double3 __basis1, out Unity.Mathematics.double3 __basis2);
            basis1 = __basis1;
            basis2 = __basis2;
        }

        /// <summary>   Returns an orthonormalized version of a <see cref="MaxMath.float3x3"/> matrix.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x3 orthonormalize(float3x3 i) => Unity.Mathematics.math.orthonormalize(i);

        /// <summary>   Returns an orthonormalized version of a <see cref="MaxMath.double3x3"/> matrix.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x3 orthonormalize(double3x3 i)
        {
            double3x3 o;

            double3 u = i.c0;
            double3 v = i.c1 - i.c0 * math.dot(i.c1, i.c0);

            double lenU = math.length(u);
            double lenV = math.length(v);

            bool c = lenU > 1e-300d && lenV > 1e-300d;

            o.c0 = math.select(new double3(1, 0, 0), u / lenU, c);
            o.c1 = math.select(new double3(0, 1, 0), v / lenV, c);
            o.c2 = math.cross(o.c0, o.c1);

            return o;
        }
    }
}