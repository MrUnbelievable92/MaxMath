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
            if (Sse.IsSseSupported)
            {
                return dividend * Sse.rcp_ss(*(v128*)&divisor).Float0;
            }
            else
            {
                return dividend / divisor;
            }
        }

        /// <summary>       Returns the result of the componentwise fast approximate division of two float2 vectors        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 div(float2 dividend, float2 divisor)
        {
            if (Sse.IsSseSupported)
            {
                v128 temp = Sse.mul_ps(*(v128*)&dividend, Sse.rcp_ps(*(v128*)&divisor));

                return *(float2*)&temp;
            }
            else
            {
                return dividend / divisor;
            }
        }

        /// <summary>       Returns the result of the componentwise fast approximate division of two float3 vectors        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 div(float3 dividend, float3 divisor)
        {
            if (Sse.IsSseSupported)
            {
                v128 temp = Sse.mul_ps(*(v128*)&dividend, Sse.rcp_ps(*(v128*)&divisor));

                return *(float3*)&temp;
            }
            else
            {
                return dividend / divisor;
            }
        }

        /// <summary>       Returns the result of the componentwise fast approximate division of two float4 vectors        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 div(float4 dividend, float4 divisor)
        {
            if (Sse.IsSseSupported)
            {
                v128 temp = Sse.mul_ps(*(v128*)&dividend, Sse.rcp_ps(*(v128*)&divisor));

                return *(float4*)&temp;
            }
            else
            {
                return dividend / divisor;
            }
        }

        /// <summary>       Returns the result of the componentwise fast approximate division of two float8 vectors        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 div(float8 dividend, float8 divisor)
        {
            if (Avx.IsAvxSupported)
            {
                return dividend * rcp(divisor);
            }
            else
            {
                return dividend / divisor;
            }
        }
    }
}