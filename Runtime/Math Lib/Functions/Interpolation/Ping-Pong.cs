using System.Runtime.CompilerServices;

namespace MaxMath
{
    unsafe public static partial class math
    {
        /// <summary>       Ping-Pongs the <see cref="float"/> <paramref name="x"/>, so that it is never larger than the <see cref="float"/> length and never smaller than 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float pingpong(float x, float length)
        {
            return length - abs(repeat(x, length + length) - length);
        }

        /// <summary>       Ping-Pongs the components of the <see cref="MaxMath.float2"/> <paramref name="x"/>, so that they are never larger than the corresponding value in the <see cref="MaxMath.float2"/> length and never smaller than 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 pingpong(float2 x, float2 length)
        {
            return length - abs(repeat(x, length + length) - length);
        }

        /// <summary>       Ping-Pongs the components of the <see cref="MaxMath.float3"/> <paramref name="x"/>, so that they are never larger than the corresponding value in the <see cref="MaxMath.float3"/> length and never smaller than 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 pingpong(float3 x, float3 length)
        {
            return length - abs(repeat(x, length + length) - length);
        }

        /// <summary>       Ping-Pongs the components of the <see cref="MaxMath.float4"/> <paramref name="x"/>, so that they are never larger than the corresponding value in the <see cref="MaxMath.float4"/> length and never smaller than 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 pingpong(float4 x, float4 length)
        {
            return length - abs(repeat(x, length + length) - length);
        }


        /// <summary>       Ping-Pongs the components of the <see cref="MaxMath.float8"/> <paramref name="x"/>, so that they are never larger than the corresponding value in the <see cref="MaxMath.float8"/> length and never smaller than 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 pingpong(float8 x, float8 length)
        {
            return length - abs(repeat(x, length + length) - length);
        }


        /// <summary>       Ping-Pongs the <see cref="double"/> <paramref name="x"/>, so that it is never larger than the <see cref="double"/> length and never smaller than 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double pingpong(double x, double length)
        {
            return length - abs(repeat(x, length + length) - length);
        }

        /// <summary>       Ping-Pongs the components of the <see cref="MaxMath.double2"/> <paramref name="x"/>, so that they are never larger than the corresponding value in the <see cref="MaxMath.double2"/> length and never smaller than 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 pingpong(double2 x, double2 length)
        {
            return length - abs(repeat(x, length + length) - length);
        }

        /// <summary>       Ping-Pongs the components of the <see cref="MaxMath.double3"/> <paramref name="x"/>, so that they are never larger than the corresponding value in the <see cref="MaxMath.double3"/> length and never smaller than 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 pingpong(double3 x, double3 length)
        {
            return length - abs(repeat(x, length + length) - length);
        }

        /// <summary>       Ping-Pongs the components of the <see cref="MaxMath.double4"/> <paramref name="x"/>, so that they are never larger than the corresponding value in the <see cref="MaxMath.double4"/> length and never smaller than 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 pingpong(double4 x, double4 length)
        {
            return length - abs(repeat(x, length + length) - length);
        }
    }
}