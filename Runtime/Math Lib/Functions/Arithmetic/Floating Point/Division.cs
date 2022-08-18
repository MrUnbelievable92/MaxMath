using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the result of the fast approximate division of two floats       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float div(float dividend, float divisor, bool fast = false)
        {
            return fast ? dividend * fastrcp(divisor) : dividend / divisor;
        }

        /// <summary>       Returns the result of the componentwise fast approximate division of two <see cref="float2"/>s       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 div(float2 dividend, float2 divisor, bool fast = false)
        {
            return fast ? dividend * fastrcp(divisor) : dividend / divisor;
        }

        /// <summary>       Returns the result of the componentwise fast approximate division of two <see cref="float3"/>s       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 div(float3 dividend, float3 divisor, bool fast = false)
        {
            return fast ? dividend * fastrcp(divisor) : dividend / divisor;
        }

        /// <summary>       Returns the result of the componentwise fast approximate division of two <see cref="float4"/>s       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 div(float4 dividend, float4 divisor, bool fast = false)
        {
            return fast ? dividend * fastrcp(divisor) : dividend / divisor;
        }

        /// <summary>       Returns the result of the componentwise fast approximate division of two <see cref="MaxMath.float8"/>s       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 div(float8 dividend, float8 divisor, bool fast = false)
        {
            return fast ? dividend * fastrcp(divisor) : dividend / divisor;
        }


        /// <summary>       Returns the result of the fast approximate division of two doubles       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double div(double dividend, double divisor, bool fast = false)
        {
            return fast ? dividend * fastrcp(divisor) : dividend / divisor;
        }

        /// <summary>       Returns the result of the componentwise fast approximate division of two <see cref="double2"/>s       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 div(double2 dividend, double2 divisor, bool fast = false)
        {
            return fast ? dividend * fastrcp(divisor) : dividend / divisor;
        }

        /// <summary>       Returns the result of the componentwise fast approximate division of two <see cref="double3"/>s       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 div(double3 dividend, double3 divisor, bool fast = false)
        {
            return fast ? dividend * fastrcp(divisor) : dividend / divisor;
        }

        /// <summary>       Returns the result of the componentwise fast approximate division of two <see cref="double4"/>s       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 div(double4 dividend, double4 divisor, bool fast = false)
        {
            return fast ? dividend * fastrcp(divisor) : dividend / divisor;
        }
    }
}