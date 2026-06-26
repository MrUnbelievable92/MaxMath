using System.Runtime.CompilerServices;

namespace MaxMath
{
    unsafe public static partial class math
    {
        /// <summary>       Returns the result of a conversion of a <see cref="float"/> from degrees to radians.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float radians(float x)
        {
            return Unity.Mathematics.math.radians(x);
        }

        /// <summary>       Returns the result of a componentwise conversion of a <see cref="MaxMath.float2"/> from degrees to radians.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 radians(float2 x)
        {
            return Unity.Mathematics.math.radians(x);
        }

        /// <summary>       Returns the result of a componentwise conversion of a <see cref="MaxMath.float3"/> from degrees to radians.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 radians(float3 x)
        {
            return Unity.Mathematics.math.radians(x);
        }

        /// <summary>       Returns the result of a componentwise conversion of a <see cref="MaxMath.float4"/> from degrees to radians.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 radians(float4 x)
        {
            return Unity.Mathematics.math.radians(x);
        }

        /// <summary>       Returns the result of a componentwise conversion of a <see cref="MaxMath.float8"/> from degrees to radians.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 radians(float8 x)
        {
            return x * TORADIANS;
        }


        /// <summary>       Returns the result of a conversion of a <see cref="double"/> from degrees to radians.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double radians(double x)
        {
            return Unity.Mathematics.math.radians(x);
        }

        /// <summary>       Returns the result of a componentwise conversion of a <see cref="MaxMath.double2"/> from degrees to radians.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 radians(double2 x)
        {
            return Unity.Mathematics.math.radians(x);
        }

        /// <summary>       Returns the result of a componentwise conversion of a <see cref="MaxMath.double3"/> from degrees to radians.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 radians(double3 x)
        {
            return Unity.Mathematics.math.radians(x);
        }

        /// <summary>       Returns the result of a componentwise conversion of a <see cref="MaxMath.double4"/> from degrees to radians.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 radians(double4 x)
        {
            return Unity.Mathematics.math.radians(x);
        }


        /// <summary>       Returns the result of a conversion of a <see cref="float"/> from radians to degrees.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float degrees(float x)
        {
            return Unity.Mathematics.math.degrees(x);
        }

        /// <summary>       Returns the result of a componentwise conversion of a <see cref="MaxMath.float2"/> from radians to degrees.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 degrees(float2 x)
        {
            return Unity.Mathematics.math.degrees(x);
        }

        /// <summary>       Returns the result of a componentwise conversion of a <see cref="MaxMath.float3"/> from radians to degrees.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 degrees(float3 x)
        {
            return Unity.Mathematics.math.degrees(x);
        }

        /// <summary>       Returns the result of a componentwise conversion of a <see cref="MaxMath.float4"/> from radians to degrees.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 degrees(float4 x)
        {
            return Unity.Mathematics.math.degrees(x);
        }

        /// <summary>       Returns the result of a componentwise conversion of a <see cref="MaxMath.float8"/> from radians to degrees.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 degrees(float8 x)
        {
            return x * TODEGREES;
        }


        /// <summary>       Returns the result of a conversion of a <see cref="double"/> from radians to degrees.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double degrees(double x)
        {
            return Unity.Mathematics.math.degrees(x);
        }

        /// <summary>       Returns the result of a componentwise conversion of a <see cref="MaxMath.double2"/> from radians to degrees.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 degrees(double2 x)
        {
            return Unity.Mathematics.math.degrees(x);
        }

        /// <summary>       Returns the result of a componentwise conversion of a <see cref="MaxMath.double3"/> from radians to degrees.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 degrees(double3 x)
        {
            return Unity.Mathematics.math.degrees(x);
        }

        /// <summary>       Returns the result of a componentwise conversion of a <see cref="MaxMath.double4"/> from radians to degrees.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 degrees(double4 x)
        {
            return Unity.Mathematics.math.degrees(x);
        }
    }
}