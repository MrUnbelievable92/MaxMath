using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the smallest difference of two angles as <see cref="float"/>s in unsigned radians.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float angledelta(float a, float b)
        {
            return repeat((b - a), TAU);
        }

        /// <summary>       Returns the componentwise smallest difference of angles of two <see cref="float2"/>s in unsigned radians.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 angledelta(float2 a, float2 b)
        {
            return repeat((b - a), TAU);
        }
        
        /// <summary>       Returns the componentwise smallest difference of angles of two <see cref="float3"/>s in unsigned radians.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 angledelta(float3 a, float3 b)
        {
            return repeat((b - a), TAU);
        }

        /// <summary>       Returns the componentwise smallest difference of angles of two <see cref="float4"/>s in unsigned radians.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 angledelta(float4 a, float4 b)
        {
            return repeat((b - a), TAU);
        }

        /// <summary>       Returns the componentwise smallest difference of angles of two <see cref="MaxMath.float8"/>s in unsigned radians.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 angledelta(float8 a, float8 b)
        {
            return repeat((b - a), TAU);
        }


        /// <summary>       Returns the smallest difference of two angles as <see cref="double"/>s in unsigned radians.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double angledelta(double a, double b)
        {
            return repeat((b - a), TAU_DBL);
        }

        /// <summary>       Returns the componentwise smallest difference of angles of two <see cref="double2"/>s in unsigned radians.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 angledelta(double2 a, double2 b)
        {
            return repeat((b - a), TAU_DBL);
        }

        /// <summary>       Returns the componentwise smallest difference of angles of two <see cref="double3"/>s in unsigned radians.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 angledelta(double3 a, double3 b)
        {
            return repeat((b - a), TAU_DBL);
        }

        /// <summary>       Returns the componentwise smallest difference of angles of two <see cref="double4"/>s in unsigned radians.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 angledelta(double4 a, double4 b)
        {
            return repeat((b - a), TAU_DBL);
        }


        /// <summary>       Returns the smallest difference of two angles as <see cref="float"/>s in signed radians.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float angledeltasgn(float a, float b)
        {
            float deltas = angledelta(a, b);

            return math.select(deltas, deltas - TAU, deltas > math.PI);
        }

        /// <summary>       Returns the componentwise smallest difference of angles of two <see cref="float2"/>s in signed radians.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 angledeltasgn(float2 a, float2 b)
        {
            float2 deltas = angledelta(a, b);

            return math.select(deltas, deltas - TAU, deltas > math.PI);
        }

        /// <summary>       Returns the componentwise smallest difference of angles of two <see cref="float3"/>s in signed radians.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 angledeltasgn(float3 a, float3 b)
        {
            float3 deltas = angledelta(a, b);

            return math.select(deltas, deltas - TAU, deltas > math.PI);
        }

        /// <summary>       Returns the componentwise smallest difference of angles of two <see cref="float4"/>s in signed radians.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 angledeltasgn(float4 a, float4 b)
        {
            float4 deltas = angledelta(a, b);

            return math.select(deltas, deltas - TAU, deltas > math.PI);
        }

        /// <summary>       Returns the componentwise smallest difference of angles of two <see cref="MaxMath.float8"/>s in signed radians.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 angledeltasgn(float8 a, float8 b)
        {
            float8 deltas = angledelta(a, b);

            return select(deltas, deltas - TAU, deltas > math.PI);
        }


        /// <summary>       Returns the smallest difference of two angles as <see cref="double"/>s in signed radians.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double angledeltasgn(double a, double b)
        {
            double deltas = angledelta(a, b);

            return math.select(deltas, deltas - TAU_DBL, deltas > math.PI_DBL);
        }

        /// <summary>       Returns the componentwise smallest difference of angles of two <see cref="double2"/>s in signed radians.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 angledeltasgn(double2 a, double2 b)
        {
            double2 deltas = angledelta(a, b);

            return math.select(deltas, deltas - TAU_DBL, deltas > math.PI_DBL);
        }

        /// <summary>       Returns the componentwise smallest difference of angles of two <see cref="double3"/>s in signed radians.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 angledeltasgn(double3 a, double3 b)
        {
            double3 deltas = angledelta(a, b);

            return math.select(deltas, deltas - TAU_DBL, deltas > math.PI_DBL);
        }

        /// <summary>       Returns the componentwise smallest difference of angles of two <see cref="double4"/>s in signed radians.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 angledeltasgn(double4 a, double4 b)
        {
            double4 deltas = angledelta(a, b);

            return math.select(deltas, deltas - TAU_DBL, deltas > math.PI_DBL);
        }


        /// <summary>       Returns the smallest difference of two angles as <see cref="float"/>s in unsigned degrees.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float angledeltadeg(float a, float b)
        {
            return repeat((b - a), 360f);
        }

        /// <summary>       Returns the componentwise smallest difference of angles of two <see cref="float2"/>s in unsigned degrees.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 angledeltadeg(float2 a, float2 b)
        {
            return repeat((b - a), 360f);
        }

        /// <summary>       Returns the componentwise smallest difference of angles of two <see cref="float3"/>s in unsigned degrees.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 angledeltadeg(float3 a, float3 b)
        {
            return repeat((b - a), 360f);
        }

        /// <summary>       Returns the componentwise smallest difference of angles of two <see cref="float4"/>s in unsigned degrees.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 angledeltadeg(float4 a, float4 b)
        {
            return repeat((b - a), 360f);
        }

        /// <summary>       Returns the componentwise smallest difference of angles of two <see cref="MaxMath.float8"/>s in unsigned degrees.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 angledeltadeg(float8 a, float8 b)
        {
            return repeat((b - a), 360f);
        }


        /// <summary>       Returns the smallest difference of two angles as <see cref="double"/>s in unsigned degrees.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double angledeltadeg(double a, double b)
        {
            return repeat((b - a), 360d);
        }

        /// <summary>       Returns the componentwise smallest difference of angles of two <see cref="double2"/>s in unsigned degrees.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 angledeltadeg(double2 a, double2 b)
        {
            return repeat((b - a), 360d);
        }

        /// <summary>       Returns the componentwise smallest difference of angles of two <see cref="double3"/>s in unsigned degrees.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 angledeltadeg(double3 a, double3 b)
        {
            return repeat((b - a), 360d);
        }

        /// <summary>       Returns the componentwise smallest difference of angles of two <see cref="double4"/>s in unsigned degrees.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 angledeltadeg(double4 a, double4 b)
        {
            return repeat((b - a), 360d);
        }


        /// <summary>       Returns the smallest difference of two angles as <see cref="float"/>s in signed degrees.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float angledeltasgndeg(float a, float b)
        {
            float delta = angledeltadeg(a, b);

            return math.select(delta, delta - 360f, delta > 180f);
        }

        /// <summary>       Returns the componentwise smallest difference of angles of two <see cref="float2"/>s in signed degrees.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 angledeltasgndeg(float2 a, float2 b)
        {
            float2 deltas = angledeltadeg(a, b);

            return math.select(deltas, deltas - 360f, deltas > 180f);
        }

        /// <summary>       Returns the componentwise smallest difference of angles of two <see cref="float3"/>s in signed degrees.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 angledeltasgndeg(float3 a, float3 b)
        {
            float3 deltas = angledeltadeg(a, b);

            return math.select(deltas, deltas - 360f, deltas > 180f);
        }

        /// <summary>       Returns the componentwise smallest difference of angles of two <see cref="float4"/>s in signed degrees.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 angledeltasgndeg(float4 a, float4 b)
        {
            float4 deltas = angledeltadeg(a, b);

            return math.select(deltas, deltas - 360f, deltas > 180f);
        }

        /// <summary>       Returns the componentwise smallest difference of angles of two <see cref="MaxMath.float8"/>s in signed degrees.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 angledeltasgndeg(float8 a, float8 b)
        {
            float8 deltas = angledeltadeg(a, b);

            return select(deltas, deltas - 360f, deltas > 180f);
        }


        /// <summary>       Returns the smallest difference of two angles as <see cref="double"/>s in signed degrees.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double angledeltasgndeg(double a, double b)
        {
            double delta = angledeltadeg(a, b);

            return math.select(delta, delta - 360d, delta > 180d);
        }

        /// <summary>       Returns the componentwise smallest difference of angles of two <see cref="double2"/>s in signed degrees.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 angledeltasgndeg(double2 a, double2 b)
        {
            double2 deltas = angledeltadeg(a, b);

            return math.select(deltas, deltas - 360d, deltas > 180d);
        }

        /// <summary>       Returns the componentwise smallest difference of angles of two <see cref="double3"/>s in signed degrees.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 angledeltasgndeg(double3 a, double3 b)
        {
            double3 deltas = angledeltadeg(a, b);

            return math.select(deltas, deltas - 360d, deltas > 180d);
        }

        /// <summary>       Returns the componentwise smallest difference of angles of two <see cref="double4"/>s in signed degrees.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 angledeltasgndeg(double4 a, double4 b)
        {
            double4 deltas = angledeltadeg(a, b);

            return math.select(deltas, deltas - 360d, deltas > 180d);
        }
    }
}