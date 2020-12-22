using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the unsigned angle between two non-normalized float2 (origin) vectors in radians.         </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float angle(float2 a, float2 b)
        {
            float4 temp = new float4(a, b);
            temp *= temp;
            temp += temp.yyww;  // Sse3.movehdup_ps(temp)
            temp *= temp.zwzw;  // Sse.movehl_ps(temp, temp)

            return math.acos(math.dot(b, a) * math.rsqrt(temp.x));
        }

        /// <summary>       Returns the unsigned angle between two non-normalized float3 (origin) vectors in radians.         </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float angle(float3 a, float3 b)
        {
            return math.acos(math.dot(b, a) * math.rsqrt(math.lengthsq(b) * math.lengthsq(a)));
        }


        /// <summary>       Returns the unsigned angle between two non-normalized double2 (origin) vectors in radians.         </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double angle(double2 a, double2 b)
        {
            double4 temp = new double4(a, b);
            temp *= temp;
            temp += temp.yyww;
            temp *= temp.zwzw;

            return math.acos(math.dot(b, a) * math.rsqrt(temp.x));
        }

        /// <summary>       Returns the unsigned angle between two non-normalized double3 (origin) vectors in radians.         </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double angle(double3 a, double3 b)
        {
            return math.acos(math.dot(b, a) * math.rsqrt(math.lengthsq(b) * math.lengthsq(a)));
        }
    }
}