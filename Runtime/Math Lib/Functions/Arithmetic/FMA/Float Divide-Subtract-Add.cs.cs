using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the result of a componentwise divide-subtract/add operation (<paramref name="a"/> <see langword="/" /> <paramref name="b"/> <see langword="-" />/<see langword="+" /> <paramref name="c"/>) on 3 <see cref="float2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 dsubadd(float2 a, float2 b, float2 c, bool fast = false)
        {
            if (Sse.IsSseSupported)
            {
               return RegisterConversion.ToType<float2>(Xse.fmaddsub_ps(RegisterConversion.ToV128(a), 
                                                    fast ? Sse.rcp_ps(RegisterConversion.ToV128(b)) : RegisterConversion.ToV128(math.rcp(b)), 
                                                    RegisterConversion.ToV128(c)));
            }
            else
            {
                return new float2(a.x / b.x - c.x, a.y / b.y + c.y);
            }
        }

        /// <summary>       Returns the result of a componentwise divide-subtract/add operation (<paramref name="a"/> <see langword="/" /> <paramref name="b"/> <see langword="-" />/<see langword="+" />/<see langword="-" /> <paramref name="c"/>) on 3 <see cref="float3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 dsubadd(float3 a, float3 b, float3 c, bool fast = false)
        {
            if (Sse.IsSseSupported)
            {
               return RegisterConversion.ToType<float3>(Xse.fmaddsub_ps(RegisterConversion.ToV128(a), 
                                                    fast ? Sse.rcp_ps(RegisterConversion.ToV128(b)) : RegisterConversion.ToV128(math.rcp(b)), 
                                                    RegisterConversion.ToV128(c)));
            }
            else
            {
                return new float3(a.x / b.x - c.x, a.y / b.y + c.y, a.z / b.z - c.z);
            }
        }

        /// <summary>       Returns the result of a componentwise divide-subtract/add operation (<paramref name="a"/> <see langword="/" /> <paramref name="b"/> <see langword="-" />/<see langword="+" />/<see langword="-" />/<see langword="+" /> <paramref name="c"/>) on 3 <see cref="float4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 dsubadd(float4 a, float4 b, float4 c, bool fast = false)
        {
            if (Sse.IsSseSupported)
            {
               return RegisterConversion.ToType<float4>(Xse.fmaddsub_ps(RegisterConversion.ToV128(a), 
                                                    fast ? Sse.rcp_ps(RegisterConversion.ToV128(b)) : RegisterConversion.ToV128(math.rcp(b)), 
                                                    RegisterConversion.ToV128(c)));
            }
            else
            {
                return new float4(a.x / b.x - c.x, a.y / b.y + c.y, a.z / b.z - c.z, a.w / b.w + c.w);
            }
        }

        /// <summary>       Returns the result of a componentwise divide-subtract/add operation (<paramref name="a"/> <see langword="/" /> <paramref name="b"/> <see langword="-" />/<see langword="+" />/<see langword="-" />/<see langword="+" />/<see langword="-" />/<see langword="+" />/<see langword="-" />/<see langword="+" /> <paramref name="c"/>) on 3 <see cref="MaxMath.float8"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 dsubadd(float8 a, float8 b, float8 c, bool fast = false)
        {
            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_fmaddsub_ps(a, fast ? fastrcp(b) : rcp(b), c);
            }
            else
            {
                return new float8(dsubadd(a.v4_0, b.v4_0, c.v4_0, fast), dsubadd(a.v4_4, b.v4_4, c.v4_4, fast));
            }
        }

        
        /// <summary>       Returns the result of a componentwise divide-add/subtract operation (<paramref name="a"/> <see langword="/" /> <paramref name="b"/> <see langword="+" />/<see langword="-" /> <paramref name="c"/>) on 3 <see cref="double2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 dsubadd(double2 a, double2 b, double2 c, bool fast = false)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToType<double2>(Xse.fmaddsub_pd(RegisterConversion.ToV128(a), 
                                                      fast ? Xse.rcp_pd(RegisterConversion.ToV128(b)) : RegisterConversion.ToV128(math.rcp(b)), 
                                                      RegisterConversion.ToV128(c)));
            }
            else
            {
                return new double2(a.x / b.x - c.x, a.y / b.y + c.y);
            }
        }

        /// <summary>       Returns the result of a componentwise divide-add/subtract operation (<paramref name="a"/> <see langword="/" /> <paramref name="b"/> <see langword="+" />/<see langword="-" />/<see langword="+" /> <paramref name="c"/>) on 3 <see cref="double3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 dsubadd(double3 a, double3 b, double3 c, bool fast = false)
        {
            if (Avx.IsAvxSupported)
            {
                v256 divisor;

                if (Avx2.IsAvx2Supported)
                {
                    divisor = fast ? Xse.mm256_rcp_pd(RegisterConversion.ToV256(b)) : RegisterConversion.ToV256(math.rcp(b));
                }
                else
                {
                    divisor = RegisterConversion.ToV256(math.rcp(b));
                }

                return RegisterConversion.ToType<double3>(Xse.mm256_fmaddsub_ps(RegisterConversion.ToV256(a), divisor, RegisterConversion.ToV256(c)));
            }
            else
            {
                return new double3(dsubadd(a.xy, b.xy, c.xy), a.z / b.z - c.z);
            }
        }

        /// <summary>       Returns the result of a componentwise divide-add/subtract operation (<paramref name="a"/> <see langword="/" /> <paramref name="b"/> <see langword="+" />/<see langword="-" />/<see langword="+" />/<see langword="-" /> <paramref name="c"/>) on 3 <see cref="double4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 dsubadd(double4 a, double4 b, double4 c, bool fast = false)
        {
            if (Sse.IsSseSupported)
            {
                v256 divisor;

                if (Avx2.IsAvx2Supported)
                {
                    divisor = fast ? Xse.mm256_rcp_pd(RegisterConversion.ToV256(b)) : RegisterConversion.ToV256(math.rcp(b));
                }
                else
                {
                    divisor = RegisterConversion.ToV256(math.rcp(b));
                }

                return RegisterConversion.ToType<double4>(Xse.mm256_fmaddsub_ps(RegisterConversion.ToV256(a), divisor, RegisterConversion.ToV256(c)));
            }
            else
            {
                return new double4(dsubadd(a.xy, b.xy, c.xy), dsubadd(a.zw, b.zw, c.zw));
            }
        }
    }
}