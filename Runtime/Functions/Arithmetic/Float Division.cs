using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the result of the fast approximate division of two floats        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float div(float dividend, float divisor)
        {
            return dividend * Sse.rcp_ss(*(v128*)&divisor).Float0;
        }

        /// <summary>       Returns the result of the componentwise fast approximate division of two float2 vectors        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 div(float2 dividend, float2 divisor)
        {
            v128 t = Sse.mul_ps(*(v128*)&dividend, Sse.rcp_ps(*(v128*)&divisor));

            return *(float2*)&t;
        }

        /// <summary>       Returns the result of the componentwise fast approximate division of two float3 vectors        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 div(float3 dividend, float3 divisor)
        {
            v128 t = Sse.mul_ps(*(v128*)&dividend, Sse.rcp_ps(*(v128*)&divisor));

            return *(float3*)&t;
        }

        /// <summary>       Returns the result of the componentwise fast approximate division of two float4 vectors        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 div(float4 dividend, float4 divisor)
        {
            v128 t = Sse.mul_ps(*(v128*)&dividend, Sse.rcp_ps(*(v128*)&divisor));

            return *(float4*)&t;
        }

        /// <summary>       Returns the result of the componentwise fast approximate division of two float8 vectors        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 div(float8 dividend, float8 divisor)
        {
            return dividend * rcp(divisor);
        }
    }
}