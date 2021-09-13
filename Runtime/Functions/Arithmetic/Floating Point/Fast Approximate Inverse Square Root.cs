using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the componentwise fast approximate inverse square root a <see cref="MaxMath.float8"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 fastrsqrt(float8 x)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_rsqrt_ps(x);
            }
            else
            {
                return new float8(fastrsqrt(x.v4_0), fastrsqrt(x.v4_4));
            }
        }

        /// <summary>       Returns the componentwise fast approximate inverse square root a <see cref="MaxMath.float8"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 fastrsqrt(float4 x)
        {
            if (Sse.IsSseSupported)
            {
                v128 t = Sse.rsqrt_ps(UnityMathematicsLink.Tov128(x));

                return *(float4*)&t;
            }
            else
            {
                return math.rsqrt(x);
            }
        }

        /// <summary>       Returns the componentwise fast approximate inverse square root a <see cref="MaxMath.float8"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 fastrsqrt(float3 x)
        {
            if (Sse.IsSseSupported)
            {
                v128 t = Sse.rsqrt_ps(UnityMathematicsLink.Tov128(x));

                return *(float3*)&t;
            }
            else
            {
                return math.rsqrt(x);
            }
        }

        /// <summary>       Returns the componentwise fast approximate inverse square root a <see cref="MaxMath.float8"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 fastrsqrt(float2 x)
        {
            if (Sse.IsSseSupported)
            {
                v128 t = Sse.rsqrt_ps(UnityMathematicsLink.Tov128(x));

                return *(float2*)&t;
            }
            else
            {
                return math.rsqrt(x);
            }
        }

        /// <summary>       Returns the componentwise fast approximate inverse square root a <see cref="MaxMath.float8"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float fastrsqrt(float x)
        {
            if (Sse.IsSseSupported)
            {
                return Sse.rsqrt_ss(new v128(x, 0f, 0f, 0f)).Float0;
            }
            else
            {
                return math.rsqrt(x);
            }
        }
    }
}
