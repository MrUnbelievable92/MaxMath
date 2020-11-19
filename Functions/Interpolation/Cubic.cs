using DevTools;
using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float smoothlerp(float from, float to, float t)
        {
Assert.IsBetween<float>(t, 0f, 1f);

            float2 bi = t * new float2(-2f *  t, 3f);
            bi = new float2(t * math.csum(bi));

            return math.csum(new float3(from, bi * new float2(to, -from)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 smoothlerp(float2 from, float2 to, float t)
        {
Assert.IsBetween<float>(t, 0f, 1f);

            float2 bi = t * new float2(-2f * t, 3f);
            bi = new float2(t * math.csum(bi));

            float4 temp = new float4(bi, -bi) * new float4(to, from);
            temp += temp.zwzw;

            return temp.xy + from;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 smoothlerp(float3 from, float3 to, float t)
        {
Assert.IsBetween<float>(t, 0f, 1f);

            float2 bi = t * new float2(-2f * t, 3f);
            t *= math.csum(bi);

            return math.mad(t,
                            to,
                            math.mad(-t,
                                     from,
                                     from));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 smoothlerp(float4 from, float4 to, float t)
        {
Assert.IsBetween<float>(t, 0f, 1f);

            float2 bi = t * new float2(-2f * t, 3f);
            t *= math.csum(bi);

            return math.mad(t,
                            to,
                            math.mad(-t,
                                     from,
                                     from));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 smoothlerp(float8 from, float8 to, float t)
        {
            Assert.IsBetween<float>(t, 0f, 1f);

            float2 bi = t * new float2(-2f * t, 3f);
            t *= math.csum(bi);

            return mad(t,
                       to,
                       mad(-t,
                           from,
                           from));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double smoothlerp(double from, double to, double t)
        {
Assert.IsBetween<double>(t, 0d, 1d);

            double2 bi = t * new double2(-2f * t, 3f);
            bi = new double2(t * math.csum(bi));

            return math.csum(new double3(from, bi * new double2(to, -from)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 smoothlerp(double2 from, double2 to, double t)
        {
Assert.IsBetween<double>(t, 0d, 1d);

            double2 bi = t * new double2(-2f * t, 3f);
            bi = new double2(t * math.csum(bi));

            double4 temp = new double4(bi, -bi) * new double4(to, from);
            temp += temp.zwzw;

            return temp.xy + from;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 smoothlerp(double3 from, double3 to, double t)
        {
Assert.IsBetween<double>(t, 0d, 1d);

            double2 bi = t * new double2(-2f * t, 3f);
            t *= math.csum(bi);

            return math.mad(t,
                            to,
                            math.mad(-t,
                                     from,
                                     from));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 smoothlerp(double4 from, double4 to, double t)
        {
Assert.IsBetween<double>(t, 0d, 1d);

            double2 bi = t * new double2(-2f * t, 3f);
            t *= math.csum(bi);

            return math.mad(t,
                            to,
                            math.mad(-t,
                                     from,
                                     from));
        }
    }
}