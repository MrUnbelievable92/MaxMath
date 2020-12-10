using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the result of the fast approximate division of two floats        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float div(float dividend, float divisor)
        {
            return dividend * math.rcp(divisor);
        }

        /// <summary>       Returns the result of the componentwise fast approximate division of two float2 vectors        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 div(float2 dividend, float2 divisor)
        {
            return dividend * math.rcp(divisor);
        }

        /// <summary>       Returns the result of the componentwise fast approximate division of two float3 vectors        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 div(float3 dividend, float3 divisor)
        {
            return dividend * math.rcp(divisor);
        }

        /// <summary>       Returns the result of the componentwise fast approximate division of two float4 vectors        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 div(float4 dividend, float4 divisor)
        {
            return dividend * math.rcp(divisor);
        }

        /// <summary>       Returns the result of the componentwise fast approximate division of two float8 vectors        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 div(float8 dividend, float8 divisor)
        {
            return dividend * rcp(divisor);
        }


        /// <summary>       Returns the result of the fast approximate division of two doubles        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double div(double dividend, double divisor)
        {
            return dividend * math.rcp(divisor);
        }

        /// <summary>       Returns the result of the componentwise fast approximate division of two double2 vectors        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 div(double2 dividend, double2 divisor)
        {
            return dividend * math.rcp(divisor);
        }

        /// <summary>       Returns the result of the componentwise fast approximate division of two double3 vectors        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 div(double3 dividend, double3 divisor)
        {
            return dividend * math.rcp(divisor);
        }

        /// <summary>       Returns the result of the componentwise fast approximate division of two double4 vectors        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 div(double4 dividend, double4 divisor)
        {
            return dividend * math.rcp(divisor);
        }
    }
}