using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float angle(float2 a, float2 b)
        {
            return math.acos(math.dot(b, a) * math.rsqrt(math.lengthsq(b) * math.lengthsq(a)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float angle(float3 a, float3 b)
        {
            return math.acos(math.dot(b, a) * math.rsqrt(math.lengthsq(b) * math.lengthsq(a)));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double angle(double2 a, double2 b)
        {
            return math.acos(math.dot(b, a) * math.rsqrt(math.lengthsq(b) * math.lengthsq(a)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double angle(double3 a, double3 b)
        {
            return math.acos(math.dot(b, a) * math.rsqrt(math.lengthsq(b) * math.lengthsq(a)));
        }
    }
}