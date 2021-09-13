using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns <see langword="true" /> if the two <see cref="float"/>s <paramref name="a"/> and <paramref name="b"/> are approximately equal to each other, given a <paramref name="tolerance"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool approx(float a, float b, float tolerance = 0f)
        {
            return math.abs(a - b) < 0.00001f + tolerance;
        }

        /// <summary>       Returns a <see cref="bool2"/> indicating for each component of a <see cref="float2"/> <paramref name="a"/> whether it is approximately equal to the corresponding component in the <see cref="float2"/> <paramref name="a"/>, given a <paramref name="tolerance"/> component.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 approx(float2 a, float2 b, float2 tolerance = default(float2))
        {
            return math.abs(a - b) < 0.00001f + tolerance;
        }

        /// <summary>       Returns a <see cref="bool3"/> indicating for each component of a <see cref="float3"/> <paramref name="a"/> whether it is approximately equal to the corresponding component in the <see cref="float3"/> <paramref name="a"/>, given a <paramref name="tolerance"/> component.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 approx(float3 a, float3 b, float3 tolerance = default(float3))
        {
            return math.abs(a - b) < 0.00001f + tolerance;
        }

        /// <summary>       Returns a <see cref="bool4"/> indicating for each component of a <see cref="float4"/> <paramref name="a"/> whether it is approximately equal to the corresponding component in the <see cref="float4"/> <paramref name="a"/>, given a <paramref name="tolerance"/> component.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 approx(float4 a, float4 b, float4 tolerance = default(float4))
        {
            return math.abs(a - b) < 0.00001f + tolerance;
        }

        /// <summary>       Returns a <see cref="MaxMath.bool8"/> indicating for each component of a <see cref="MaxMath.float8"/> <paramref name="a"/> whether it is approximately equal to the corresponding component in the <see cref="MaxMath.float8"/> <paramref name="a"/>, given a <paramref name="tolerance"/> component.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 approx(float8 a, float8 b, float8 tolerance = new float8())
        {
            return abs(a - b) < 0.00001f + tolerance;
        }


        /// <summary>       Returns <see langword="true" /> if the two <see cref="double"/>s <paramref name="a"/> and <paramref name="b"/> are approximately equal to each other, given a <paramref name="tolerance"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool approx(double a, double b, double tolerance = 0d)
        {
            return math.abs(a - b) < 0.000_000_000_000_001d + tolerance;
        }

        /// <summary>       Returns a <see cref="bool2"/> indicating for each component of a <see cref="double2"/> <paramref name="a"/> whether it is approximately equal to the corresponding component in the <see cref="double2"/> <paramref name="a"/>, given a <paramref name="tolerance"/> component.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 approx(double2 a, double2 b, double2 tolerance = default(double2))
        {
            return math.abs(a - b) < 0.000_000_000_000_01d + tolerance;
        }

        /// <summary>       Returns a <see cref="bool3"/> indicating for each component of a <see cref="double3"/> <paramref name="a"/> whether it is approximately equal to the corresponding component in the <see cref="double3"/> <paramref name="a"/>, given a <paramref name="tolerance"/> component.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 approx(double3 a, double3 b, double3 tolerance = default(double3))
        {
            return math.abs(a - b) < 0.000_000_000_000_01d + tolerance;
        }

        /// <summary>       Returns a <see cref="bool4"/> indicating for each component of a <see cref="double4"/> <paramref name="a"/> whether it is approximately equal to the corresponding component in the <see cref="double4"/> <paramref name="a"/>, given a <paramref name="tolerance"/> component.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 approx(double4 a, double4 b, double4 tolerance = default(double4))
        {
            return math.abs(a - b) < 0.000_000_000_000_01d + tolerance;
        }
    }
}