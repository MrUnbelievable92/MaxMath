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
            if (Fma.IsFmaSupported)
            {
                v128 temp = Fma.fmsubadd_ps(*(v128*)&a, Sse.rcp_ps(*(v128*)&b), *(v128*)&c);

                return *(float2*)&temp;
            }
            else if (Sse.IsSseSupported)
            {
                b = math.rcp(b);
                v128 negate = Sse.xor_ps(*(v128*)&c, new v128(0, 1 << 31, 0, 0));

                return math.mad(a, b, *(float2*)&negate);
            }
            else
            {
                return new float2(a.x / b.x + c.x, a.y / b.y - c.y);
            }
        }

        /// <summary>       Returns the result of a componentwise fast approximate divide-add/subtract operation (a * (1 / b) +/-/+ c) on 3 float3 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 dadsub(float3 a, float3 b, float3 c)
        {
            if (Fma.IsFmaSupported)
            {
                v128 temp = Fma.fmsubadd_ps(*(v128*)&a, Sse.rcp_ps(*(v128*)&b), *(v128*)&c);

                return *(float3*)&temp;
            }
            else if (Sse.IsSseSupported)
            {
                b = math.rcp(b);
                v128 negate = Sse.xor_ps(*(v128*)&c, new v128(0, 1 << 31, 0, 0));

                return math.mad(a, b, *(float3*)&negate);
            }
            else
            {
                return new float3(a.x / b.x + c.x, a.y / b.y - c.y, a.z / b.z + c.z);
            }
        }

        /// <summary>       Returns the result of a componentwise fast approximate divide-add/subtract operation (a * (1 / b) +/-/+/- c) on 3 float4 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 dadsub(float4 a, float4 b, float4 c)
        {
            if (Fma.IsFmaSupported)
            {
                v128 temp = Fma.fmsubadd_ps(*(v128*)&a, Sse.rcp_ps(*(v128*)&b), *(v128*)&c);

                return *(float4*)&temp;
            }
            else if (Sse.IsSseSupported)
            {
                b = math.rcp(b);
                v128 negate = Sse.xor_ps(*(v128*)&c, new v128(0, 1 << 31, 0, 1 << 31));

                return math.mad(a, b, *(float4*)&negate);
            }
            else
            {
                return new float4(a.x / b.x + c.x, a.y / b.y - c.y, a.z / b.z + c.z, a.w / b.w - c.w);
            }
        }

        /// <summary>       Returns the result of a componentwise fast approximate divide-add/subtract operation (a * (1 / b) +/-/+/-/+/-/+/- c) on 3 float8 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 dadsub(float8 a, float8 b, float8 c)
        {
            if (Fma.IsFmaSupported)
            {
                return Fma.mm256_fmsubadd_ps(a, rcp(b), c);
            }
            else
            {
                return new float8(dadsub(a.v4_0, b.v4_0, c.v4_0), dadsub(a.v4_4, b.v4_4, c.v4_4));
            }
        }
    }
}