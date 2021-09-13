using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;

namespace MaxMath
{
    // This is __completely__ optimized away but prevents duplicate loads and stores and undefined behavior
    unsafe internal static class UnityMathematicsLink
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 Tov128(bool2 f)
        {
            return new v128(*(byte*)&f.x, *(byte*)&f.y, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 Tov128(bool3 f)
        {
            return new v128(*(byte*)&f.x, *(byte*)&f.y, *(byte*)&f.z, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 Tov128(bool4 f)
        {
            return new v128(*(byte*)&f.x, *(byte*)&f.y, *(byte*)&f.z, *(byte*)&f.w, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 Tov128(int2 f)
        {
            return new v128(f.x, f.y, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 Tov128(int3 f)
        {
            return new v128(f.x, f.y, f.z, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 Tov128(int4 f)
        {
            return new v128(f.x, f.y, f.z, f.w);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 Tov128(uint2 f)
        {
            return new v128(f.x, f.y, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 Tov128(uint3 f)
        {
            return new v128(f.x, f.y, f.z, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 Tov128(uint4 f)
        {
            return new v128(f.x, f.y, f.z, f.w);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 Tov128(float2 f)
        {
            return new v128(f.x, f.y, 0f, 0f);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 Tov128(float3 f)
        {
            return new v128(f.x, f.y, f.z, 0f);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 Tov128(float4 f)
        {
            return new v128(f.x, f.y, f.z, f.w);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 Tov128(double2 f)
        {
            return new v128(f.x, f.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 Tov256(double3 f)
        {
            return new v256(f.x, f.y, f.z, 0d);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 Tov256(double4 f)
        {
            return new v256(f.x, f.y, f.z, f.w);
        }
    }
}
