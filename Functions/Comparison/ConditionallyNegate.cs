using System;
using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float negate(float x, bool p)
        {
            return math.asfloat(math.asint(x) ^ ((int)cvt_uint8(p) << 31));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 negate(float2 x, bool2 p)
        {
            return math.asfloat(math.asint(x) ^ ((int2)cvt_uint8(p) << 31));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 negate(float3 x, bool3 p)
        {
            return math.asfloat(math.asint(x) ^ ((int3)cvt_uint8(p) << 31));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 negate(float4 x, bool4 p)
        {
            return math.asfloat(math.asint(x) ^ ((int4)cvt_uint8(p) << 31));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 negate(float8 x, bool4x2 p)
        {
            return(v256)((v256)x ^ ((int8)cvt_uint8(p) << 31));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double negate(double x, bool p)
        {
            return math.asdouble(math.aslong(x) ^ ((long)cvt_uint8(p) << 63));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 negate(double2 x, bool2 p)
        {
            long2 temp = *(v128*)&x ^ ((long2)cvt_uint8(p) << 63);

            return *(double2*)&temp;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 negate(double3 x, bool3 p)
        {
            long3 temp = *(v256*)&x ^ ((long3)cvt_uint8(p) << 63);

            return *(double3*)&temp;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 negate(double4 x, bool4 p)
        {
            long4 temp = *(v256*)&x ^ ((long4)cvt_uint8(p) << 63);

            return *(double4*)&temp;
        }
    }
}
