using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the result of a componentwise fast approximate divide-add/subtract operation (a * (1 / b) +/- c) on 3 float2 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 dadsub(float2 a, float2 b, float2 c)
        {
            v128 temp = Fma.fmsubadd_ps(*(v128*)&a, Sse.rcp_ps(*(v128*)&b), *(v128*)&c);

            return *(float2*)&temp;
        }

        /// <summary>       Returns the result of a componentwise fast approximate divide-add/subtract operation (a * (1 / b) +/-/+ c) on 3 float3 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 dadsub(float3 a, float3 b, float3 c)
        {
            v128 temp = Fma.fmsubadd_ps(*(v128*)&a, Sse.rcp_ps(*(v128*)&b), *(v128*)&c);

            return *(float3*)&temp;
        }

        /// <summary>       Returns the result of a componentwise fast approximate divide-add/subtract operation (a * (1 / b) +/-/+/- c) on 3 float4 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 dadsub(float4 a, float4 b, float4 c)
        {
            v128 temp = Fma.fmsubadd_ps(*(v128*)&a, Sse.rcp_ps(*(v128*)&b), *(v128*)&c);

            return *(float4*)&temp;
        }

        /// <summary>       Returns the result of a componentwise fast approximate divide-add/subtract operation (a * (1 / b) +/-/+/-/+/-/+/- c) on 3 float8 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 dadsub(float8 a, float8 b, float8 c)
        {
            return Fma.mm256_fmsubadd_ps(a, rcp(b), c);
        }
    }
}