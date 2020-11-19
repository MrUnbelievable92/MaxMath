using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isneg(half x)
        {
            // keep x in XMM
            ushort2 result = *(ushort2*)&x >> 15;

            return *(bool*)&result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 isneg(half2 x)
        {
            ushort result = X86.Sse2.extract_epi16((byte2)(*(ushort2*)&x >> 15), 0);

            return *(bool2*)&result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 isneg(half3 x)
        {
            int result = X86.Sse4_1.extract_epi32((byte3)(*(ushort3*)&x >> 15), 0);

            return *(bool3*)&result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 isneg(half4 x)
        {
            int result = X86.Sse4_1.extract_epi32((byte4)(*(ushort4*)&x >> 15), 0);

            return *(bool4*)&result;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isneg(float x)
        {
            uint result = math.asuint(x) >> 31;

            return *(bool*)&result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 isneg(float2 x)
        {
            ushort result = X86.Sse2.extract_epi16((byte2)(math.asuint(x) >> 31), 0);

            return *(bool2*)&result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 isneg(float3 x)
        {
            int result = X86.Sse4_1.extract_epi32((byte3)(math.asuint(x) >> 31), 0);

            return *(bool3*)&result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 isneg(float4 x)
        {
            int result = X86.Sse4_1.extract_epi32((byte4)(math.asuint(x) >> 31), 0);

            return *(bool4*)&result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x2 isneg(float8 x)
        {
            long result = X86.Sse4_1.extract_epi64((byte8)(((int8)(v256)x) >> 31), 0);

            return *(bool4x2*)&result;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isneg(double x)
        {
            ulong result = math.asulong(x) >> 63;

            return *(bool*)&result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 isneg(double2 x)
        {
            ushort result = X86.Sse2.extract_epi16((byte2)(*(ulong2*)&x >> 63), 0);

            return *(bool2*)&result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 isneg(double3 x)
        {
            int result = X86.Sse4_1.extract_epi32((byte3)(*(ulong3*)&x >> 63), 0);

            return *(bool3*)&result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 isneg(double4 x)
        {
            int result = X86.Sse4_1.extract_epi32((byte4)(*(ulong4*)&x >> 63), 0);

            return *(bool4*)&result;
        }
    }
}