using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the result of a fast approximate divide-add operation (a * (1 / b) + c) on 3 float values.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float dad(float dividend, float divisor, float summand)
        {
            return math.mad(dividend, math.rcp(divisor), summand);
        }

        /// <summary>       Returns the result of a componentwise fast approximate divide-add operation (a * (1 / b) + c) on 3 float2 vectors.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 dad(float2 dividend, float2 divisor, float2 summand)
        {
            return math.mad(dividend, math.rcp(divisor), summand);
        }

        /// <summary>       Returns the result of a componentwise fast approximate divide-add operation (a * (1 / b) + c) on 3 float3 vectors.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 dad(float3 dividend, float3 divisor, float3 summand)
        {
            return math.mad(dividend, math.rcp(divisor), summand);
        }

        /// <summary>       Returns the result of a componentwise fast approximate divide-add operation (a * (1 / b) + c) on 3 float4 vectors.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 dad(float4 dividend, float4 divisor, float4 summand)
        {
            return math.mad(dividend, math.rcp(divisor), summand);
        }

        /// <summary>       Returns the result of a componentwise fast approximate divide-add operation (a * (1 / b) + c) on 3 float8 vectors.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 dad(float8 dividend, float8 divisor, float8 summand)
        {
            return mad(dividend, rcp(divisor), summand);
        }
    }
}