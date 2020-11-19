using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float div(float dividend, float divisor)
        {
            return dividend * math.rcp(divisor);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 div(float2 dividend, float2 divisor)
        {
            return dividend * math.rcp(divisor);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 div(float3 dividend, float3 divisor)
        {
            return dividend * math.rcp(divisor);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 div(float4 dividend, float4 divisor)
        {
            return dividend * math.rcp(divisor);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 div(float8 dividend, float8 divisor)
        {
            return dividend * rcp(divisor);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double div(double dividend, double divisor)
        {
            return dividend * math.rcp(divisor);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 div(double2 dividend, double2 divisor)
        {
            return dividend * math.rcp(divisor);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 div(double3 dividend, double3 divisor)
        {
            return dividend * math.rcp(divisor);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 div(double4 dividend, double4 divisor)
        {
            return dividend * math.rcp(divisor);
        }
    }
}