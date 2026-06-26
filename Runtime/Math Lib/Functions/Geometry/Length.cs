using System.Runtime.CompilerServices;

namespace MaxMath
{
    unsafe public static partial class math
    {
        /// <summary>       Returns the squared length of a <see cref="float"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float lengthsq(float x)
        {
            return Unity.Mathematics.math.lengthsq(x);
        }
        
        /// <summary>       Returns the squared length of a <see cref="MaxMath.float2"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float lengthsq(float2 x)
        {
            return Unity.Mathematics.math.lengthsq(x);
        }
        
        /// <summary>       Returns the squared length of a <see cref="MaxMath.float3"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float lengthsq(float3 x)
        {
            return Unity.Mathematics.math.lengthsq(x);
        }
        
        /// <summary>       Returns the squared length of a <see cref="MaxMath.float4"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float lengthsq(float4 x)
        {
            return Unity.Mathematics.math.lengthsq(x);
        }

        /// <summary>       Returns the squared length of a <see cref="MaxMath.float8"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float lengthsq(float8 x)
        {
            return dot(x, x);
        }

        
        /// <summary>       Returns the squared length of a <see cref="double"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double lengthsq(double x)
        {
            return Unity.Mathematics.math.lengthsq(x);
        }
        
        /// <summary>       Returns the squared length of a <see cref="MaxMath.double2"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double lengthsq(double2 x)
        {
            return Unity.Mathematics.math.lengthsq(x);
        }
        
        /// <summary>       Returns the squared length of a <see cref="MaxMath.double3"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double lengthsq(double3 x)
        {
            return Unity.Mathematics.math.lengthsq(x);
        }
        
        /// <summary>       Returns the squared length of a <see cref="MaxMath.double4"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double lengthsq(double4 x)
        {
            return Unity.Mathematics.math.lengthsq(x);
        }


        /// <summary>       Returns the length of a <see cref="float"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float length(float x)
        {
            return Unity.Mathematics.math.length(x);
        }

        /// <summary>       Returns the length of a <see cref="MaxMath.float2"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float length(float2 x)
        {
            return Unity.Mathematics.math.length(x);
        }

        /// <summary>       Returns the length of a <see cref="MaxMath.float3"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float length(float3 x)
        {
            return Unity.Mathematics.math.length(x);
        }

        /// <summary>       Returns the length of a <see cref="MaxMath.float4"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float length(float4 x)
        {
            return Unity.Mathematics.math.length(x);
        }

        /// <summary>       Returns the length of a <see cref="MaxMath.float8"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float length(float8 x)
        {
            return sqrt(lengthsq(x));
        }


        /// <summary>       Returns the length of a <see cref="double"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double length(double x)
        {
            return Unity.Mathematics.math.length(x);
        }

        /// <summary>       Returns the length of a <see cref="MaxMath.double2"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double length(double2 x)
        {
            return Unity.Mathematics.math.length(x);
        }

        /// <summary>       Returns the length of a <see cref="MaxMath.double3"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double length(double3 x)
        {
            return Unity.Mathematics.math.length(x);
        }

        /// <summary>       Returns the length of a <see cref="MaxMath.double4"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double length(double4 x)
        {
            return Unity.Mathematics.math.length(x);
        }
    }
}