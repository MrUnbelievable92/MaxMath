using System.Runtime.CompilerServices;

namespace MaxMath
{
    unsafe public static partial class math
    {
        /// <summary>		Returns the <see cref="MaxMath.float2x2"/> full inverse of a <see cref="MaxMath.float2x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 inverse(float2x2 v)
        {
            return Unity.Mathematics.math.inverse(v);
        }

        /// <summary>		Returns the <see cref="MaxMath.float3x3"/> full inverse of a <see cref="MaxMath.float3x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x3 inverse(float3x3 v)
        {
            return Unity.Mathematics.math.inverse(v);
        }

        /// <summary>		Returns the <see cref="MaxMath.float4x4"/> full inverse of a <see cref="MaxMath.float4x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 inverse(float4x4 v)
        {
            return Unity.Mathematics.math.inverse(v);
        }

        
        /// <summary>		Returns the <see cref="MaxMath.double2x2"/> full inverse of a <see cref="MaxMath.double2x2"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 inverse(double2x2 v)
        {
            return Unity.Mathematics.math.inverse(v);
        }

        /// <summary>		Returns the <see cref="MaxMath.double3x3"/> full inverse of a <see cref="MaxMath.double3x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x3 inverse(double3x3 v)
        {
            return Unity.Mathematics.math.inverse(v);
        }

        /// <summary>		Returns the <see cref="MaxMath.double4x4"/> full inverse of a <see cref="MaxMath.double4x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 inverse(double4x4 v)
        {
            return Unity.Mathematics.math.inverse(v);
        }


        /// <summary>		Returns the float<see cref="MaxMath.float3x4"/> fast inverse for rigid transforms (orthonormal basis and translation) of a <see cref="MaxMath.float4x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x4 fastinverse(float3x4 v)
        {
            return Unity.Mathematics.math.fastinverse(v);
        }

        /// <summary>		Returns the <see cref="MaxMath.float4x4"/> fast inverse for rigid transforms (orthonormal basis and translation) of a <see cref="MaxMath.float4x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 fastinverse(float4x4 v)
        {
            return Unity.Mathematics.math.fastinverse(v);
        }

        /// <summary>		Returns the double<see cref="MaxMath.double3x4"/> fast inverse for rigid transforms (orthonormal basis and translation) of a <see cref="MaxMath.double4x3"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 fastinverse(double3x4 v)
        {
            return Unity.Mathematics.math.fastinverse(v);
        }

        /// <summary>		Returns the <see cref="MaxMath.double4x4"/> fast inverse for rigid transforms (orthonormal basis and translation) of a <see cref="MaxMath.double4x4"/>.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 fastinverse(double4x4 v)
        {
            return Unity.Mathematics.math.fastinverse(v);
        }

        /// <summary>   Computes the pseudoinverse of a <see cref="MaxMath.float3x3"/> matrix.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x3 pseudoinverse(float3x3 m) => Unity.Mathematics.math.pseudoinverse(m);
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static double3x3 adj(double3x3 m, out double det)
        {
            double3x3 adjT;
            adjT.c0 = cross(m.c1, m.c2);
            adjT.c1 = cross(m.c2, m.c0);
            adjT.c2 = cross(m.c0, m.c1);
            det = dot(m.c0, adjT.c0);

            return transpose(adjT);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool adjInverse(double3x3 m, out double3x3 i, double epsilon = svd.k_EpsilonNormal_DBL)
        {
            i = adj(m, out double det);
            bool c = abs(det) > epsilon;
            double3 detInv = select(1d, rcp(det), c);
            i = scaleMul(detInv, i);
            return c;
        }

        /// <summary>   Computes the pseudoinverse of a <see cref="MaxMath.double3x3"/> matrix.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x3 pseudoinverse(double3x3 m)
        {
            double scaleSq = (1d / 3d) * (lengthsq(m.c0) + lengthsq(m.c1) + lengthsq(m.c2));
            if (scaleSq < svd.k_EpsilonNormal_DBL)
                return 0;

            double3 scaleInv = rsqrt(scaleSq);
            double3x3 ms = mulScale(m, scaleInv);
            if (!adjInverse(ms, out double3x3 i, svd.k_EpsilonDeterminant_DBL))
            {
                i = svd.svdInverse(ms);
            }

            return mulScale(i, scaleInv);
        }
    }
}