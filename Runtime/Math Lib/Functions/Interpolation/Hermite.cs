using System.Runtime.CompilerServices;

namespace MaxMath
{
    unsafe public static partial class math
    {
        /// <summary>       Returns a smooth Hermite interpolation between 0.0f and 1.0f when <paramref name="x"/> is in [<paramref name="a"/>, <paramref name="b"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float smoothstep(float a, float b, float x)
        {
            float temp = saturate(unlerp(a, b, x));

            return square(temp) * mad(-2f, temp, 3f);
        }
        
        /// <summary>       Returns a componentwise smooth Hermite interpolation between 0.0f and 1.0f when <paramref name="x"/> is in [<paramref name="a"/>, <paramref name="b"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 smoothstep(float2 a, float2 b, float2 x)
        {
            float2 temp = saturate(unlerp(a, b, x));

            return square(temp) * mad(-2f, temp, 3f);
        }
        
        /// <summary>       Returns a componentwise smooth Hermite interpolation between 0.0f and 1.0f when <paramref name="x"/> is in [<paramref name="a"/>, <paramref name="b"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 smoothstep(float3 a, float3 b, float3 x)
        {
            float3 temp = saturate(unlerp(a, b, x));

            return square(temp) * mad(-2f, temp, 3f);
        }
        
        /// <summary>       Returns a componentwise smooth Hermite interpolation between 0.0f and 1.0f when <paramref name="x"/> is in [<paramref name="a"/>, <paramref name="b"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 smoothstep(float4 a, float4 b, float4 x)
        {
            float4 temp = saturate(unlerp(a, b, x));

            return square(temp) * mad(-2f, temp, 3f);
        }

        /// <summary>       Returns a componentwise smooth Hermite interpolation between 0.0f and 1.0f when <paramref name="x"/> is in [<paramref name="a"/>, <paramref name="b"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 smoothstep(float8 a, float8 b, float8 x)
        {
            float8 temp = saturate(unlerp(a, b, x));

            return square(temp) * mad(-2f, temp, 3f);
        }


        /// <summary>       Returns a smooth Hermite interpolation between 0.0d and 1.0d when <paramref name="x"/> is in [<paramref name="a"/>, <paramref name="b"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double smoothstep(double a, double b, double x)
        {
            double temp = saturate(unlerp(a, b, x));

            return square(temp) * mad(-2d, temp, 3d);
        }
        
        /// <summary>       Returns a componentwise smooth Hermite interpolation between 0.0d and 1.0d when <paramref name="x"/> is in [<paramref name="a"/>, <paramref name="b"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 smoothstep(double2 a, double2 b, double2 x)
        {
            double2 temp = saturate(unlerp(a, b, x));

            return square(temp) * mad(-2d, temp, 3d);
        }
        
        /// <summary>       Returns a componentwise smooth Hermite interpolation between 0.0d and 1.0d when <paramref name="x"/> is in [<paramref name="a"/>, <paramref name="b"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 smoothstep(double3 a, double3 b, double3 x)
        {
            double3 temp = saturate(unlerp(a, b, x));

            return square(temp) * mad(-2d, temp, 3d);
        }
        
        /// <summary>       Returns a componentwise smooth Hermite interpolation between 0.0d and 1.0d when <paramref name="x"/> is in [<paramref name="a"/>, <paramref name="b"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 smoothstep(double4 a, double4 b, double4 x)
        {
            double4 temp = saturate(unlerp(a, b, x));

            return square(temp) * mad(-2d, temp, 3d);
        }
    }
}