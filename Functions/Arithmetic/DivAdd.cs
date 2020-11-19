using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float dad(float dividend, float divisor, float summand)
        {
            return math.mad(dividend, math.rcp(divisor), summand);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 dad(float2 dividend, float2 divisor, float2 summand)
        {
            return math.mad(dividend, math.rcp(divisor), summand);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 dad(float3 dividend, float3 divisor, float3 summand)
        {
            return math.mad(dividend, math.rcp(divisor), summand);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 dad(float4 dividend, float4 divisor, float4 summand)
        {
            return math.mad(dividend, math.rcp(divisor), summand);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 dad(float8 dividend, float8 divisor, float8 summand)
        {
            return mad(dividend, rcp(divisor), summand);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double dad(double dividend, double divisor, double summand)
        {
            return math.mad(dividend, math.rcp(divisor), summand);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 dad(double2 dividend, double2 divisor, double2 summand)
        {
            return math.mad(dividend, math.rcp(divisor), summand);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 dad(double3 dividend, double3 divisor, double3 summand)
        {
            return math.mad(dividend, math.rcp(divisor), summand);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 dad(double4 dividend, double4 divisor, double4 summand)
        {
            return math.mad(dividend, math.rcp(divisor), summand);
        }
    }
}