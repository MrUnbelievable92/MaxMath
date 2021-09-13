using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the result of the fast approximate division of two floats       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float div(float dividend, float divisor, bool fast = false)
        {
            if (Sse.IsSseSupported)
            {
                if (fast)
                {
                    return dividend * fastrcp(divisor);
                }
            }

            return dividend / divisor;
        }

        /// <summary>       Returns the result of the componentwise fast approximate division of two <see cref="float2"/>s       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 div(float2 dividend, float2 divisor, bool fast = false)
        {
            if (Sse.IsSseSupported)
            {
                if (fast)
                {
                    return dividend * fastrcp(divisor);
                }
            }

            return dividend / divisor;
        }

        /// <summary>       Returns the result of the componentwise fast approximate division of two <see cref="float3"/>s       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 div(float3 dividend, float3 divisor, bool fast = false)
        {
            if (Sse.IsSseSupported)
            {
                if (fast)
                {
                    return dividend * fastrcp(divisor);
                }
            }

            return dividend / divisor;
        }

        /// <summary>       Returns the result of the componentwise fast approximate division of two <see cref="float4"/>s       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 div(float4 dividend, float4 divisor, bool fast = false)
        {
            if (Sse.IsSseSupported)
            {
                if (fast)
                {
                    return dividend * fastrcp(divisor);
                }
            }

            return dividend / divisor;
        }

        /// <summary>       Returns the result of the componentwise fast approximate division of two <see cref="MaxMath.float8"/>s       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 div(float8 dividend, float8 divisor, bool fast = false)
        {
            if (Avx.IsAvxSupported)
            {
                if (fast)
                {
                    return dividend * fastrcp(divisor);
                }
                else
                {
                    return dividend / divisor;
                }
            }
            else
            {
                return new float8(div(dividend.v4_0, divisor.v4_0, fast), div(dividend.v4_4, divisor.v4_4, fast));
            }
        }
    }
}