using System.Runtime.CompilerServices;

namespace MaxMath
{
    unsafe public static partial class math
    {
        /// <summary>       Returns the distance between two <see cref="float"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float distance(float x, float y)
        {
            return Unity.Mathematics.math.distance(x, y);
        }
        
        /// <summary>       Returns the distance between two <see cref="MaxMath.float2"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float distance(float2 x, float2 y)
        {
            return Unity.Mathematics.math.distance(x, y);
        }
        
        /// <summary>       Returns the distance between two <see cref="MaxMath.float3"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float distance(float3 x, float3 y)
        {
            return Unity.Mathematics.math.distance(x, y);
        }
        
        /// <summary>       Returns the distance between two <see cref="MaxMath.float4"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float distance(float4 x, float4 y)
        {
            return Unity.Mathematics.math.distance(x, y);
        }

        /// <summary>       Returns the distance between two <see cref="MaxMath.float8"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float distance(float8 x, float8 y)
        {
            return length(y - x);
        }


        /// <summary>       Returns the distance between two <see cref="double"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double distance(double x, double y)
        {
            return Unity.Mathematics.math.distance(x, y);
        }
        
        /// <summary>       Returns the distance between two <see cref="MaxMath.double2"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double distance(double2 x, double2 y)
        {
            return Unity.Mathematics.math.distance(x, y);
        }
        
        /// <summary>       Returns the distance between two <see cref="MaxMath.double3"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double distance(double3 x, double3 y)
        {
            return Unity.Mathematics.math.distance(x, y);
        }
        
        /// <summary>       Returns the distance between two <see cref="MaxMath.double4"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double distance(double4 x, double4 y)
        {
            return Unity.Mathematics.math.distance(x, y);
        }


        /// <summary>       Returns the distance between two <see cref="float"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float distancesq(float x, float y)
        {
            return Unity.Mathematics.math.distancesq(x, y);
        }

        /// <summary>       Returns the distance between two <see cref="MaxMath.float2"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float distancesq(float2 x, float2 y)
        {
            return Unity.Mathematics.math.distancesq(x, y);
        }

        /// <summary>       Returns the distance between two <see cref="MaxMath.float3"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float distancesq(float3 x, float3 y)
        {
            return Unity.Mathematics.math.distancesq(x, y);
        }

        /// <summary>       Returns the distance between two <see cref="MaxMath.float4"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float distancesq(float4 x, float4 y)
        {
            return Unity.Mathematics.math.distancesq(x, y);
        }

        /// <summary>       Returns the distance between two <see cref="MaxMath.float8"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float distancesq(float8 x, float8 y)
        {
            return lengthsq(y - x);
        }


        /// <summary>       Returns the distance between two <see cref="double"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double distancesq(double x, double y)
        {
            return Unity.Mathematics.math.distancesq(x, y);
        }

        /// <summary>       Returns the distance between two <see cref="MaxMath.double2"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double distancesq(double2 x, double2 y)
        {
            return Unity.Mathematics.math.distancesq(x, y);
        }

        /// <summary>       Returns the distance between two <see cref="MaxMath.double3"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double distancesq(double3 x, double3 y)
        {
            return Unity.Mathematics.math.distancesq(x, y);
        }

        /// <summary>       Returns the distance between two <see cref="MaxMath.double4"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double distancesq(double4 x, double4 y)
        {
            return Unity.Mathematics.math.distancesq(x, y);
        }
    }
}