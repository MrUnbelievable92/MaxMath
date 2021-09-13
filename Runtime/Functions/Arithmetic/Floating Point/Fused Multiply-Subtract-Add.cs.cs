using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the result of a componentwise multiply-subtract/add operation (<paramref name="a"/> * <paramref name="b"/> -/+ <paramref name="c"/>) on 3 <see cref="float2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 msubadd(float2 a, float2 b, float2 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                v128 temp = Fma.fmaddsub_ps(UnityMathematicsLink.Tov128(a), UnityMathematicsLink.Tov128(b), UnityMathematicsLink.Tov128(c));

                return *(float2*)&temp;
            }
            else if (Sse.IsSseSupported)
            {
                v128 negate = Sse.xor_ps(UnityMathematicsLink.Tov128(c), new v128(1 << 31, 0, 0, 0));

                return math.mad(a, b, *(float2*)&negate);
            }
            else
            {
                return new float2(a.x * b.x - c.x, a.y * b.y + c.y);
            }
        }

        /// <summary>       Returns the result of a componentwise multiply-subtract/add operation (<paramref name="a"/> * <paramref name="b"/> -/+/- <paramref name="c"/>) on 3 <see cref="float3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 msubadd(float3 a, float3 b, float3 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                v128 temp = Fma.fmaddsub_ps(UnityMathematicsLink.Tov128(a), UnityMathematicsLink.Tov128(b), UnityMathematicsLink.Tov128(c));

                return *(float3*)&temp;
            }
            else if (Sse.IsSseSupported)
            {
                v128 negate = Sse.xor_ps(UnityMathematicsLink.Tov128(c), new v128(1 << 31, 0, 1 << 31, 0));

                return math.mad(a, b, *(float3*)&negate);
            }
            else
            {
                return new float3(a.x * b.x - c.x, a.y * b.y + c.y, a.z * b.z - c.z);
            }
        }

        /// <summary>       Returns the result of a componentwise multiply-subtract/add operation (<paramref name="a"/> * <paramref name="b"/> -/+/-/+ <paramref name="c"/>) on 3 <see cref="float4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 msubadd(float4 a, float4 b, float4 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                v128 temp = Fma.fmaddsub_ps(UnityMathematicsLink.Tov128(a), UnityMathematicsLink.Tov128(b), UnityMathematicsLink.Tov128(c));

                return *(float4*)&temp;
            }
            else if (Sse.IsSseSupported)
            {
                v128 negate = Sse.xor_ps(UnityMathematicsLink.Tov128(c), new v128(1 << 31, 0, 1 << 31, 0));

                return math.mad(a, b, *(float4*)&negate);
            }
            else
            {
                return new float4(a.x * b.x - c.x, a.y * b.y + c.y, a.z * b.z - c.z, a.w * b.w + c.w);
            }
        }

        /// <summary>       Returns the result of a componentwise multiply-subtract/add operation (<paramref name="a"/> * <paramref name="b"/> -/+/-/+/-/+/-/+ <paramref name="c"/>) on 3 <see cref="MaxMath.float8"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 msubadd(float8 a, float8 b, float8 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Fma.mm256_fmaddsub_ps(a, b, c);
            }
            else
            {
                return new float8(msubadd(a.v4_0, b.v4_0, c.v4_0), msubadd(a.v4_4, b.v4_4, c.v4_4));
            }
        }


        /// <summary>       Returns the result of a componentwise multiply-subtract/add operation (<paramref name="a"/> * <paramref name="b"/> -/+ <paramref name="c"/>) on 3 <see cref="double2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 msubadd(double2 a, double2 b, double2 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                v128 temp = Fma.fmaddsub_pd(UnityMathematicsLink.Tov128(a), UnityMathematicsLink.Tov128(b), UnityMathematicsLink.Tov128(c));

                return *(double2*)&temp;
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 negate = Sse2.xor_pd(UnityMathematicsLink.Tov128(c), new v128(1L << 63, 0L));

                return math.mad(a, b, *(double2*)&negate);
            }
            else
            {
                return new double2(a.x * b.x + c.x, a.y * b.y - c.y);
            }
        }

        /// <summary>       Returns the result of a componentwise multiply-subtract/add operation (<paramref name="a"/> * <paramref name="b"/> -/+/- <paramref name="c"/>) on 3 <see cref="double3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 msubadd(double3 a, double3 b, double3 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 temp = Fma.mm256_fmaddsub_pd(UnityMathematicsLink.Tov256(a), UnityMathematicsLink.Tov256(b), UnityMathematicsLink.Tov256(c));

                return *(double3*)&temp;
            }
            else
            {
                return new double3(a.x * b.x - c.x, a.y * b.y + c.y, a.z * b.z - c.z);
            }
        }

        /// <summary>       Returns the result of a componentwise multiply-subtract/add operation (<paramref name="a"/> * <paramref name="b"/> -/+/-/+ <paramref name="c"/>) on 3 <see cref="double4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 msubadd(double4 a, double4 b, double4 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 temp = Fma.mm256_fmaddsub_pd(UnityMathematicsLink.Tov256(a), UnityMathematicsLink.Tov256(b), UnityMathematicsLink.Tov256(c));

                return *(double4*)&temp;
            }
            else
            {
                return new double4(a.x * b.x - c.x, a.y * b.y + c.y, a.z * b.z - c.z, a.w * b.w + c.w);
            }
        }
    }
}