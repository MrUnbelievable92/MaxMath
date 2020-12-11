using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Negates the float value if the supplied bool value is true.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float negate(float x, bool p)
        {
            return math.asfloat(math.asuint(x) ^ (cvt_uint32(p) << 31));
        }

        /// <summary>       Negates the components of a float2 vector if the bool value of the corresponding bool2 vector is true.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 negate(float2 x, bool2 p)
        {
            return math.asfloat(math.asuint(x) ^ (cvt_uint32(p) << 31));
        }

        /// <summary>       Negates the components of a float3 vector if the bool value of the corresponding bool3 vector is true.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 negate(float3 x, bool3 p)
        {
            return math.asfloat(math.asuint(x) ^ (cvt_uint32(p) << 31));
        }

        /// <summary>       Negates the components of a float4 vector if the bool value of the corresponding bool4 vector is true.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 negate(float4 x, bool4 p)
        {
            return math.asfloat(math.asuint(x) ^ (cvt_uint32(p) << 31));
        }

        /// <summary>       Negates the components of a float8 vector if the bool value of the corresponding bool8 vector is true.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 negate(float8 x, bool8 p)
        {
            return asfloat(asuint(x) ^ (cvt_uint32(p) << 31));
        }


        /// <summary>       Negates the double value if the supplied bool value is true.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double negate(double x, bool p)
        {
            return math.asdouble(math.asulong(x) ^ (cvt_uint64(p) << 63));
        }

        /// <summary>       Negates the components of a double2 vector if the bool value of the corresponding bool2 vector is true.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 negate(double2 x, bool2 p)
        {
            return asdouble(asulong(x) ^ (cvt_uint64(p) << 63));
        }

        /// <summary>       Negates the components of a double3 vector if the bool value of the corresponding bool3 vector is true.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 negate(double3 x, bool3 p)
        {
            return asdouble(asulong(x) ^ (cvt_uint64(p) << 63));
        }

        /// <summary>       Negates the components of a double4 vector if the bool value of the corresponding bool4 vector is true.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 negate(double4 x, bool4 p)
        {
            return asdouble(asulong(x) ^ (cvt_uint64(p) << 63));
        }
    }
}
