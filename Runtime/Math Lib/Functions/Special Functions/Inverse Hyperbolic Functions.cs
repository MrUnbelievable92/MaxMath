using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the hyperbolic arcsine of a <see cref="float"/>.       </summary>
    	[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float asinh(float x)
        {
            return math.log(x + math.sqrt(math.mad(x, x, 1f)));
        }

        /// <summary>       Returns the componentwise hyperbolic arcsine of a <see cref="float2"/>.       </summary>
    	[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 asinh(float2 x)
        {
            return math.log(x + math.sqrt(math.mad(x, x, 1f)));
        }

        /// <summary>       Returns the componentwise hyperbolic arcsine of a <see cref="float3"/>.       </summary>
    	[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 asinh(float3 x)
        {
            return math.log(x + math.sqrt(math.mad(x, x, 1f)));
        }

        /// <summary>       Returns the componentwise hyperbolic arcsine of a <see cref="float4"/>.       </summary>
    	[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 asinh(float4 x)
        {
            return math.log(x + math.sqrt(math.mad(x, x, 1f)));
        }

        /// <summary>       Returns the componentwise hyperbolic arcsine of a <see cref="MaxMath.float8"/>.       </summary>
    	[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 asinh(float8 x)
        {
            return log(x + sqrt(mad(x, x, 1f)));
        }


        /// <summary>       Returns the hyperbolic arccosine of a <see cref="float"/>.       </summary>
    	[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float acosh(float x)
        {
            return math.log(x + math.sqrt(math.mad(x, x, -1f)));
        }

        /// <summary>       Returns the componentwise hyperbolic arccosine of a <see cref="float2"/>.       </summary>
    	[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 acosh(float2 x)
        {
            return math.log(x + math.sqrt(math.mad(x, x, -1f)));
        }

        /// <summary>       Returns the componentwise hyperbolic arccosine of a <see cref="float3"/>.       </summary>
    	[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 acosh(float3 x)
        {
            return math.log(x + math.sqrt(math.mad(x, x, -1f)));
        }

        /// <summary>       Returns the componentwise hyperbolic arccosine of a <see cref="float4"/>.       </summary>
    	[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 acosh(float4 x)
        {
            return math.log(x + math.sqrt(math.mad(x, x, -1f)));
        }

        /// <summary>       Returns the componentwise hyperbolic arccosine of a <see cref="MaxMath.float8"/>.       </summary>
    	[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 acosh(float8 x)
        {
            return log(x + sqrt(mad(x, x, -1f)));
        }


        /// <summary>       Returns the hyperbolic arctangent of a <see cref="float"/>.       </summary>
    	[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float atanh(float x)
        {
            if (Architecture.IsSIMDSupported)
            {
                float2 xx = x;
                xx = addsub(1f, xx);
                xx = 0.5f * math.log(xx);

                return (xx - xx.yy).x;
            }
            else
            {
                return 0.5f * math.log((1f + x) / (1f - x));
            }
        }

        /// <summary>       Returns the componentwise hyperbolic arctangent of a <see cref="float2"/>.       </summary>
    	[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 atanh(float2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                float4 xxyy = x.xxyy;
                xxyy = addsub(1f, xxyy);
                xxyy = 0.5f * math.log(xxyy);

                return (xxyy - xxyy.yyww).xz;
            }
            else
            {
                return 0.5f * math.log((1f + x) / (1f - x));
            }
        }

        /// <summary>       Returns the componentwise hyperbolic arctangent of a <see cref="float3"/>.       </summary>
    	[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 atanh(float3 x)
        {
            return 0.5f * math.log((1f + x) / (1f - x));
        }

        /// <summary>       Returns the componentwise hyperbolic arctangent of a <see cref="float4"/>.       </summary>
    	[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 atanh(float4 x)
        {
            return 0.5f * math.log((1f + x) / (1f - x));
        }

        /// <summary>       Returns the componentwise hyperbolic arctangent of a <see cref="MaxMath.float8"/>.       </summary>
    	[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 atanh(float8 x)
        {
            return 0.5f * log((1f + x) / (1f - x));
        }


        /// <summary>       Returns the hyperbolic arcsine of a <see cref="double"/>.       </summary>
    	[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double asinh(double x)
        {
            return math.log(x + math.sqrt(math.mad(x, x, 1d)));
        }

        /// <summary>       Returns the componentwise hyperbolic arcsine of a <see cref="double2"/>.       </summary>
    	[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 asinh(double2 x)
        {
            return math.log(x + math.sqrt(math.mad(x, x, 1d)));
        }

        /// <summary>       Returns the componentwise hyperbolic arcsine of a <see cref="double3"/>.       </summary>
    	[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 asinh(double3 x)
        {
            return math.log(x + math.sqrt(math.mad(x, x, 1d)));
        }

        /// <summary>       Returns the componentwise hyperbolic arcsine of a <see cref="double4"/>.       </summary>
    	[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 asinh(double4 x)
        {
            return math.log(x + math.sqrt(math.mad(x, x, 1d)));
        }


        /// <summary>       Returns the hyperbolic arccosine of a <see cref="double"/>.       </summary>
    	[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double acosh(double x)
        {
            return math.log(x + math.sqrt(math.mad(x, x, -1d)));
        }

        /// <summary>       Returns the componentwise hyperbolic arccosine of a <see cref="double2"/>.       </summary>
    	[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 acosh(double2 x)
        {
            return math.log(x + math.sqrt(math.mad(x, x, -1d)));
        }

        /// <summary>       Returns the componentwise hyperbolic arccosine of a <see cref="double3"/>.       </summary>
    	[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 acosh(double3 x)
        {
            return math.log(x + math.sqrt(math.mad(x, x, -1d)));
        }

        /// <summary>       Returns the componentwise hyperbolic arccosine of a <see cref="double4"/>.       </summary>
    	[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 acosh(double4 x)
        {
            return math.log(x + math.sqrt(math.mad(x, x, -1d)));
        }


        /// <summary>       Returns the hyperbolic arctangent of a <see cref="double"/>.       </summary>
    	[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double atanh(double x)
        {
            if (Architecture.IsSIMDSupported)
            {
                double2 xx = x;
                xx = addsub(1d, xx);
                xx = 0.5d * math.log(xx);

                return (xx - xx.yy).x;
            }
            else
            {
                return 0.5d * math.log((1d + x) / (1d - x));
            }
        }

        /// <summary>       Returns the componentwise hyperbolic arctangent of a <see cref="double2"/>.       </summary>
    	[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 atanh(double2 x)
        {
            return 0.5d * math.log((1d + x) / (1d - x));
        }

        /// <summary>       Returns the componentwise hyperbolic arctangent of a <see cref="double3"/>.       </summary>
    	[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 atanh(double3 x)
        {
            return 0.5d * math.log((1d + x) / (1d - x));
        }

        /// <summary>       Returns the componentwise hyperbolic arctangent of a <see cref="double4"/>.       </summary>
    	[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 atanh(double4 x)
        {
            return 0.5d * math.log((1d + x) / (1d - x));
        }
    }
}
