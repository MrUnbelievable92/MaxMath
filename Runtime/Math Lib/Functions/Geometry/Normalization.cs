using System.Runtime.CompilerServices;

namespace MaxMath
{
    unsafe public static partial class math
    {
        /// <summary>       Returns a normalized version of the <see cref="MaxMath.float2"/> <paramref name="x"/> by scaling it by 1 <see langword="/"/> length(<paramref name="x"/>).    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 normalize(float2 x)
        {
            return Unity.Mathematics.math.normalize(x);
        }

        /// <summary>       Returns a normalized version of the <see cref="MaxMath.float3"/> <paramref name="x"/> by scaling it by 1 <see langword="/"/> length(<paramref name="x"/>).    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 normalize(float3 x)
        {
            return Unity.Mathematics.math.normalize(x);
        }

        /// <summary>       Returns a normalized version of the <see cref="MaxMath.float4"/> <paramref name="x"/> by scaling it by 1 <see langword="/"/> length(<paramref name="x"/>).    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 normalize(float4 x)
        {
            return Unity.Mathematics.math.normalize(x);
        }

        /// <summary>       Returns a normalized version of the <see cref="MaxMath.float8"/> <paramref name="x"/> by scaling it by 1 <see langword="/"/> length(<paramref name="x"/>).    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 normalize(float8 x)
        {
            return x / length(x);
        }


        /// <summary>       Returns a normalized version of the <see cref="MaxMath.double2"/> <paramref name="x"/> by scaling it by 1 <see langword="/"/> length(<paramref name="x"/>).    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 normalize(double2 x)
        {
            return Unity.Mathematics.math.normalize(x);
        }

        /// <summary>       Returns a normalized version of the <see cref="MaxMath.double3"/> <paramref name="x"/> by scaling it by 1 <see langword="/"/> length(<paramref name="x"/>).    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 normalize(double3 x)
        {
            return Unity.Mathematics.math.normalize(x);
        }

        /// <summary>       Returns a normalized version of the <see cref="MaxMath.double4"/> <paramref name="x"/> by scaling it by 1 <see langword="/"/> length(<paramref name="x"/>).    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 normalize(double4 x)
        {
            return Unity.Mathematics.math.normalize(x);
        }


        /// <summary>       Returns a safe normalized version of the <see cref="MaxMath.float2"/> <paramref name="x"/> by scaling it by 1 <see langword="/"/> length(<paramref name="x"/>). Returns the given default value when 1 <see langword="/"/> length(<paramref name="x"/>) does not produce a finite number.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 normalizesafe(float2 x, float2 defaultvalue = default(float2))
        {
            return Unity.Mathematics.math.normalizesafe(x);
        }

        /// <summary>       Returns a safe normalized version of the <see cref="MaxMath.float3"/> <paramref name="x"/> by scaling it by 1 <see langword="/"/> length(<paramref name="x"/>). Returns the given default value when 1 <see langword="/"/> length(<paramref name="x"/>) does not produce a finite number.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 normalizesafe(float3 x, float3 defaultvalue = default(float3))
        {
            return Unity.Mathematics.math.normalizesafe(x);
        }

        /// <summary>       Returns a safe normalized version of the <see cref="MaxMath.float4"/> <paramref name="x"/> by scaling it by 1 <see langword="/"/> length(<paramref name="x"/>). Returns the given default value when 1 <see langword="/"/> length(<paramref name="x"/>) does not produce a finite number.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 normalizesafe(float4 x, float4 defaultvalue = default(float4))
        {
            return Unity.Mathematics.math.normalizesafe(x);
        }

        /// <summary>       Returns a safe normalized version of the <see cref="MaxMath.float8"/> <paramref name="x"/> by scaling it by 1 <see langword="/"/> length(<paramref name="x"/>). Returns the given default value when 1 <see langword="/"/> length(<paramref name="x"/>) does not produce a finite number.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 normalizesafe(float8 x, float8 defaultvalue = default(float8))
        {
            float len = dot(x, x);

            return select(defaultvalue, x / sqrt(len), len > FLT_MIN_NORMAL);
        }


        /// <summary>       Returns a safe normalized version of the <see cref="MaxMath.double2"/> <paramref name="x"/> by scaling it by 1 <see langword="/"/> length(<paramref name="x"/>). Returns the given default value when 1 <see langword="/"/> length(<paramref name="x"/>) does not produce a finite number.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 normalizesafe(double2 x, double2 defaultvalue = default(double2))
        {
            return Unity.Mathematics.math.normalizesafe(x);
        }

        /// <summary>       Returns a safe normalized version of the <see cref="MaxMath.double3"/> <paramref name="x"/> by scaling it by 1 <see langword="/"/> length(<paramref name="x"/>). Returns the given default value when 1 <see langword="/"/> length(<paramref name="x"/>) does not produce a finite number.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 normalizesafe(double3 x, double3 defaultvalue = default(double3))
        {
            return Unity.Mathematics.math.normalizesafe(x);
        }

        /// <summary>       Returns a safe normalized version of the <see cref="MaxMath.double4"/> <paramref name="x"/> by scaling it by 1 <see langword="/"/> length(<paramref name="x"/>). Returns the given default value when 1 <see langword="/"/> length(<paramref name="x"/>) does not produce a finite number.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 normalizesafe(double4 x, double4 defaultvalue = default(double4))
        {
            return Unity.Mathematics.math.normalizesafe(x);
        }
    }
}