using System;
using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Negates the float value if the supplied bool value is true.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float negate(float x, bool p)
        {
            return math.asfloat(math.asint(x) ^ ((int)cvt_uint8(p) << 31));
        }

        /// <summary>       Negates the components of a float2 vector if the bool value of the corresponding bool2 vector is true.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 negate(float2 x, bool2 p)
        {
            return math.asfloat(math.asint(x) ^ ((int2)cvt_uint8(p) << 31));
        }

        /// <summary>       Negates the components of a float3 vector if the bool value of the corresponding bool3 vector is true.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 negate(float3 x, bool3 p)
        {
            return math.asfloat(math.asint(x) ^ ((int3)cvt_uint8(p) << 31));
        }

        /// <summary>       Negates the components of a float4 vector if the bool value of the corresponding bool4 vector is true.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 negate(float4 x, bool4 p)
        {
            return math.asfloat(math.asint(x) ^ ((int4)cvt_uint8(p) << 31));
        }

        /// <summary>       Negates the components of a float8 vector if the bool value of the corresponding bool8 vector is true.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 negate(float8 x, bool8 p)
        {
            return (v256)((v256)x ^ ((int8)cvt_uint8(p) << 31));
        }


        /// <summary>       Negates the double value if the supplied bool value is true.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double negate(double x, bool p)
        {
            return math.asdouble(math.aslong(x) ^ ((long)cvt_uint8(p) << 63));
        }

        /// <summary>       Negates the components of a double2 vector if the bool value of the corresponding bool2 vector is true.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 negate(double2 x, bool2 p)
        {
            long2 temp = *(v128*)&x ^ ((long2)cvt_uint8(p) << 63);

            return *(double2*)&temp;
        }

        /// <summary>       Negates the components of a double3 vector if the bool value of the corresponding bool3 vector is true.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 negate(double3 x, bool3 p)
        {
            long3 temp = *(v256*)&x ^ ((long3)cvt_uint8(p) << 63);

            return *(double3*)&temp;
        }

        /// <summary>       Negates the components of a double4 vector if the bool value of the corresponding bool4 vector is true.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 negate(double4 x, bool4 p)
        {
            long4 temp = *(v256*)&x ^ ((long4)cvt_uint8(p) << 63);

            return *(double4*)&temp;
        }
    }
}
