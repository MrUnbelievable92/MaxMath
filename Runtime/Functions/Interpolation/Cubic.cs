using DevTools;
using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Interpolates between the <see cref="float"/>s <paramref name="from"/> and <paramref name="to"/> with smoothing at the limits if <paramref name="t"/> is within the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float smoothlerp(float from, float to, float t)
        {
            float2 bi = t * new float2(-2f *  t, 3f);
            bi = new float2(t * math.csum(bi));
            
            return math.csum(new float3(from, bi * new float2(to, -from)));
        }

        /// <summary>       Interpolates between the <see cref="float2"/>s <paramref name="from"/> and <paramref name="to"/> with smoothing at the limits if <paramref name="t"/> is within the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 smoothlerp(float2 from, float2 to, float t)
        {
            float2 bi = t * new float2(-2f * t, 3f);
            bi = new float2(t * math.csum(bi));

            float4 temp = new float4(bi, -bi) * new float4(to, from);
            temp += temp.zwzw;

            return temp.xy + from;
        }

        /// <summary>       Interpolates between the <see cref="float3"/>s <paramref name="from"/> and <paramref name="to"/> with smoothing at the limits if <paramref name="t"/> is within the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 smoothlerp(float3 from, float3 to, float t)
        {
            float2 bi = t * new float2(-2f * t, 3f);
            t *= math.csum(bi);
            
            return math.mad(t,
                            to,
                            math.mad(-t,
                                     from,
                                     from));
        }

        /// <summary>       Interpolates between the <see cref="float4"/>s <paramref name="from"/> and <paramref name="to"/> with smoothing at the limits if <paramref name="t"/> is within the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 smoothlerp(float4 from, float4 to, float t)
        {
            float2 bi = t * new float2(-2f * t, 3f);
            t *= math.csum(bi);

            return math.mad(t,
                            to,
                            math.mad(-t,
                                     from,
                                     from));
        }

        /// <summary>       Interpolates between the <see cref="MaxMath.float8"/>s <paramref name="from"/> and <paramref name="to"/> with smoothing at the limits if <paramref name="t"/> is within the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 smoothlerp(float8 from, float8 to, float t)
        {
            float2 bi = t * new float2(-2f * t, 3f);
            t *= math.csum(bi);

            return mad(t,
                       to,
                       mad(-t,
                           from,
                           from));
        }


        /// <summary>       Interpolates between the <see cref="double"/>s <paramref name="from"/> and <paramref name="to"/> with smoothing at the limits if <paramref name="t"/> is within the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double smoothlerp(double from, double to, double t)
        {
            double2 bi = t * new double2(-2f * t, 3f);
            bi = new double2(t * math.csum(bi));

            return math.csum(new double3(from, bi * new double2(to, -from)));
        }

        /// <summary>       Interpolates between the <see cref="double2"/>s <paramref name="from"/> and <paramref name="to"/> with smoothing at the limits if <paramref name="t"/> is within the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 smoothlerp(double2 from, double2 to, double t)
        {
            double2 bi = t * new double2(-2f * t, 3f);
            bi = new double2(t * math.csum(bi));

            double4 temp = new double4(bi, -bi) * new double4(to, from);
            temp += temp.zwzw;

            return temp.xy + from;
        }

        /// <summary>       Interpolates between the <see cref="double3"/>s <paramref name="from"/> and <paramref name="to"/> with smoothing at the limits if <paramref name="t"/> is within the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 smoothlerp(double3 from, double3 to, double t)
        {
            double2 bi = t * new double2(-2f * t, 3f);
            t *= math.csum(bi);

            return math.mad(t,
                            to,
                            math.mad(-t,
                                     from,
                                     from));
        }

        /// <summary>       Interpolates between the <see cref="double4"/>s <paramref name="from"/> and <paramref name="to"/> with smoothing at the limits if <paramref name="t"/> is within the interval [0, 1].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 smoothlerp(double4 from, double4 to, double t)
        {
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