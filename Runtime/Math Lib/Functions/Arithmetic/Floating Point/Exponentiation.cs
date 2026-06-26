using System.Runtime.CompilerServices;
using MaxMath.Intrinsics;
using Unity.Burst.Intrinsics;
using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class math
    {
        /// <summary>       Returns the result of raising <paramref name="x"/> to the power <paramref name="y"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float pow(float x, float y)
        {
            float result;

            if (constexpr.IS_CONST(y))
            {
                if (x == E)
                {
                    return exp(y);
                }
                if (x == 2)
                {
                    return exp2(y);
                }
                if (x == 10)
                {
                    return exp10(y);
                }

                float t = trunc(y);
                bool powsqrt = y > 1f & (y - t == 0.5f);
                bool powcbrt = y > 1f & (y == t + 1f / 3f);

                bool integer = t == y;
                if (integer && isinrange(t, int.MinValue, int.MaxValue))
                {
                    return pow(x, (int)t);
                }

                if (powsqrt | powcbrt)
                {
                    y = t;
                }

                switch (y)
                {
                    case -0.5f:    { result = rsqrt(x); break; }
                    case -1f / 3f: { result = rcbrt(x, /*pow standard: negative -> NaN*/Promise.ZeroOrGreater); break; }
                    case 0f:       { result = 1f; break; }
                    case 1f / 3f:  { result = cbrt(x, /*pow standard: negative -> NaN*/Promise.ZeroOrGreater); break; }
                    case 0.5f:     { result = sqrt(x); break; }
                    case 0.25f:    { result = rsqrt(rsqrt(x)); break; }
                    case 0.125f:   { result = sqrt(rsqrt(rsqrt(x))); break; }

                    default: result = Unity.Mathematics.math.pow(x, (float)y); break;
                }

                if (powsqrt)
                {
                    result *= sqrt(x);
                }
                if (powcbrt)
                {
                    result *= cbrt(x, /*pow standard: negative -> NaN*/Promise.ZeroOrGreater);
                }
            }
            else
            {
                result = Unity.Mathematics.math.pow(x, y);
            }

            return result;
        }
        
        /// <summary>       Returns the componentwise result of raising <paramref name="x"/> to the power <paramref name="y"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 pow(float2 x, float2 y)
        {
            if (constexpr.IS_CONST(y))
            {
                if (y.x == y.y)
                {
                    return pow(x, y.x);
                }
            }
            if (constexpr.IS_CONST(x))
            {
                if (all(x == E))
                {
                    return exp(y);
                }
                if (all(x == 2))
                {
                    return exp2(y);
                }
                if (all(x == 10))
                {
                    return exp2(y);
                }
            }

            return Unity.Mathematics.math.pow(x, y);
        }
        
        /// <summary>       Returns the componentwise result of raising <paramref name="x"/> to the power <paramref name="y"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 pow(float3 x, float3 y)
        {
            if (constexpr.IS_CONST(y))
            {
                if (y.x == y.y
                 && y.x == y.z)
                {
                    return pow(x, y.x);
                }
            }
            if (constexpr.IS_CONST(x))
            {
                if (all(x == E))
                {
                    return exp(y);
                }
                if (all(x == 2))
                {
                    return exp2(y);
                }
                if (all(x == 10))
                {
                    return exp2(y);
                }
            }

            return Unity.Mathematics.math.pow(x, y);
        }
        
        /// <summary>       Returns the componentwise result of raising <paramref name="x"/> to the power <paramref name="y"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 pow(float4 x, float4 y)
        {
            if (constexpr.IS_CONST(y))
            {
                if (y.x == y.y
                 && y.x == y.z
                 && y.x == y.w)
                {
                    return pow(x, y.x);
                }
            }
            if (constexpr.IS_CONST(x))
            {
                if (all(x == E))
                {
                    return exp(y);
                }
                if (all(x == 2))
                {
                    return exp2(y);
                }
                if (all(x == 10))
                {
                    return exp2(y);
                }
            }

            return Unity.Mathematics.math.pow(x, y);
        }

        /// <summary>       Returns the componentwise result of raising <paramref name="x"/> to the power <paramref name="y"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 pow(float8 x, float8 y)
        {
            if (constexpr.IS_CONST(y))
            {
                if (y.x0 == y.x1
                 && y.x0 == y.x2
                 && y.x0 == y.x3
                 && y.x0 == y.x4
                 && y.x0 == y.x5
                 && y.x0 == y.x6
                 && y.x0 == y.x7)
                {
                    return pow(x, y.x0);
                }
            }
            if (constexpr.IS_CONST(x))
            {
                if (all(x == E))
                {
                    return exp(y);
                }
                if (all(x == 2))
                {
                    return exp2(y);
                }
                if (all(x == 10))
                {
                    return exp2(y);
                }
            }

            if (Avx.IsAvxSupported)
            {
                float8 r = Uninitialized<float8>.Create();

                for (int i = 0; i < 8; i++)
                {
                    *((float*)&r + i) = pow(*((float*)&x + i), *((float*)&y + i));
                }

                return r;
            }
            else
            {
                return new float8(pow(x.v4_0, y.v4_0), pow(x.v4_4, y.v4_4));
            }
        }


        /// <summary>       Returns the result of raising <paramref name="x"/> to the power <paramref name="y"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double pow(double x, double y)
        {
            double result;

            if (constexpr.IS_CONST(y))
            {
                if (x == E_DBL)
                {
                    return exp(y);
                }
                if (x == 2)
                {
                    return exp2(y);
                }
                if (x == 10)
                {
                    return exp10(y);
                }

                double t = trunc(y);
                bool powsqrt = y > 1d & (y - t == 0.5d);
                bool powcbrt = y > 1d & (y == t + 1d / 3d);

                bool integer = t == y;
                if (integer && isinrange(t, int.MinValue, int.MaxValue))
                {
                    return pow(x, (int)t);
                }

                if (powsqrt | powcbrt)
                {
                    y = t;
                }

                switch (y)
                {
                    case -0.5d:    { result = rsqrt(x); break; }
                    case -1d / 3d: { result = /*pow standard: negative -> NaN*/select(rcbrt(x), double.NaN, x < 0d); break; }
                    case 0d:       { result = 1f; break; }
                    case 1d / 3d:  { result = /*pow standard: negative -> NaN*/select(cbrt(x), double.NaN, x < 0d); break; }
                    case 0.5d:     { result = sqrt(x); break; }
                    case 0.25d:    { result = rsqrt(rsqrt(x)); break; }
                    case 0.125d:   { result = sqrt(rsqrt(rsqrt(x))); break; }

                    default: result = Unity.Mathematics.math.pow(x, (double)y); break;
                }

                if (powsqrt)
                {
                    result *= sqrt(x);
                }
                if (powcbrt)
                {
                    result *= /*pow standard: negative -> NaN*/select(cbrt(x), double.NaN, x < 0d);
                }
            }
            else
            {
                result = Unity.Mathematics.math.pow(x, (double)y);
            }

            return result;
        }
        
        /// <summary>       Returns the componentwise result of raising <paramref name="x"/> to the power <paramref name="y"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 pow(double2 x, double2 y)
        {
            if (constexpr.IS_CONST(y))
            {
                if (y.x == y.y)
                {
                    return pow(x, y.x);
                }
            }
            if (constexpr.IS_CONST(x))
            {
                if (all(x == E_DBL))
                {
                    return exp(y);
                }
                if (all(x == 2))
                {
                    return exp2(y);
                }
                if (all(x == 10))
                {
                    return exp2(y);
                }
            }

            return Unity.Mathematics.math.pow(x, y);
        }
        
        /// <summary>       Returns the componentwise result of raising <paramref name="x"/> to the power <paramref name="y"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 pow(double3 x, double3 y)
        {
            if (constexpr.IS_CONST(y))
            {
                if (y.x == y.y
                 && y.x == y.z)
                {
                    return pow(x, y.x);
                }
            }
            if (constexpr.IS_CONST(x))
            {
                if (all(x == E_DBL))
                {
                    return exp(y);
                }
                if (all(x == 2))
                {
                    return exp2(y);
                }
                if (all(x == 10))
                {
                    return exp2(y);
                }
            }

            return Unity.Mathematics.math.pow(x, y);
        }
        
        /// <summary>       Returns the componentwise result of raising <paramref name="x"/> to the power <paramref name="y"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 pow(double4 x, double4 y)
        {
            if (constexpr.IS_CONST(y))
            {
                if (y.x == y.y
                 && y.x == y.z
                 && y.x == y.w)
                {
                    return pow(x, y.x);
                }
            }
            if (constexpr.IS_CONST(x))
            {
                if (all(x == E_DBL))
                {
                    return exp(y);
                }
                if (all(x == 2))
                {
                    return exp2(y);
                }
                if (all(x == 10))
                {
                    return exp2(y);
                }
            }

            return Unity.Mathematics.math.pow(x, y);
        }


        /// <summary>       Returns the result of raising each <paramref name="x"/> component to the power <paramref name="y"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 pow(float8 x, float y)
        {
            float8 result;

            if (constexpr.IS_CONST(y))
            {
                float t = trunc(y);
                bool powsqrt = y > 1f & (y - t == 0.5f);
                bool powcbrt = y > 1f & (y == t + 1f / 3f);

                bool integer = t == y;
                if (integer && isinrange(t, int.MinValue, int.MaxValue))
                {
                    return pow(x, (int)t);
                }

                if (powsqrt | powcbrt)
                {
                    y = t;
                }

                switch (y)
                {
                    case -0.5f:    { result = rsqrt(x); break; }
                    case -1f / 3f: { result = rcbrt(x, /*pow standard: negative -> NaN*/Promise.ZeroOrGreater); break; }
                    case 0f:       { result = 1f; break; }
                    case 1f / 3f:  { result = cbrt(x, /*pow standard: negative -> NaN*/Promise.ZeroOrGreater); break; }
                    case 0.5f:     { result = sqrt(x); break; }
                    case 0.25f:    { result = rsqrt(rsqrt(x)); break; }
                    case 0.125f:   { result = sqrt(rsqrt(rsqrt(x))); break; }

                    default: result = pow(x, (float8)y); break;
                }

                if (powsqrt)
                {
                    result *= sqrt(x);
                }
                if (powcbrt)
                {
                    result *= cbrt(x, /*pow standard: negative -> NaN*/Promise.ZeroOrGreater);
                }
            }
            else
            {
                result = pow(x, (float8)y);
            }

            return result;
        }

        /// <summary>       Returns the result of raising each <paramref name="x"/> component to the power <paramref name="y"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 pow(float4 x, float y)
        {
            float4 result;

            if (constexpr.IS_CONST(y))
            {
                float t = trunc(y);
                bool powsqrt = y > 1f & (y - t == 0.5f);
                bool powcbrt = y > 1f & (y == t + 1f / 3f);

                bool integer = t == y;
                if (integer && isinrange(t, int.MinValue, int.MaxValue))
                {
                    return pow(x, (int)t);
                }

                if (powsqrt | powcbrt)
                {
                    y = t;
                }

                switch (y)
                {
                    case -0.5f:    { result = rsqrt(x); break; }
                    case -1f / 3f: { result = rcbrt(x, /*pow standard: negative -> NaN*/Promise.ZeroOrGreater); break; }
                    case 0f:       { result = 1f; break; }
                    case 1f / 3f:  { result = cbrt(x, /*pow standard: negative -> NaN*/Promise.ZeroOrGreater); break; }
                    case 0.5f:     { result = sqrt(x); break; }
                    case 0.25f:    { result = rsqrt(rsqrt(x)); break; }
                    case 0.125f:   { result = sqrt(rsqrt(rsqrt(x))); break; }

                    default: result = pow(x, (float4)y); break;
                }

                if (powsqrt)
                {
                    result *= sqrt(x);
                }
                if (powcbrt)
                {
                    result *= cbrt(x, /*pow standard: negative -> NaN*/Promise.ZeroOrGreater);
                }
            }
            else
            {
                result = pow(x, (float4)y);
            }

            return result;
        }

        /// <summary>       Returns the result of raising each <paramref name="x"/> component to the power <paramref name="y"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 pow(float3 x, float y)
        {
            float3 result;

            if (constexpr.IS_CONST(y))
            {
                float t = trunc(y);
                bool powsqrt = y > 1f & (y - t == 0.5f);
                bool powcbrt = y > 1f & (y == t + 1f / 3f);

                bool integer = t == y;
                if (integer && isinrange(t, int.MinValue, int.MaxValue))
                {
                    return pow(x, (int)t);
                }

                if (powsqrt | powcbrt)
                {
                    y = t;
                }

                switch (y)
                {
                    case -0.5f:    { result = rsqrt(x); break; }
                    case -1f / 3f: { result = rcbrt(x, /*pow standard: negative -> NaN*/Promise.ZeroOrGreater); break; }
                    case 0f:       { result = 1f; break; }
                    case 1f / 3f:  { result = cbrt(x, /*pow standard: negative -> NaN*/Promise.ZeroOrGreater); break; }
                    case 0.5f:     { result = sqrt(x); break; }
                    case 0.25f:    { result = rsqrt(rsqrt(x)); break; }
                    case 0.125f:   { result = sqrt(rsqrt(rsqrt(x))); break; }

                    default: result = pow(x, (float3)y); break;
                }

                if (powsqrt)
                {
                    result *= sqrt(x);
                }
                if (powcbrt)
                {
                    result *= cbrt(x, /*pow standard: negative -> NaN*/Promise.ZeroOrGreater);
                }
            }
            else
            {
                result = pow(x, (float3)y);
            }

            return result;
        }

        /// <summary>       Returns the result of raising each <paramref name="x"/> component to the power <paramref name="y"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 pow(float2 x, float y)
        {
            float2 result;

            if (constexpr.IS_CONST(y))
            {
                float t = trunc(y);
                bool powsqrt = y > 1f & (y - t == 0.5f);
                bool powcbrt = y > 1f & (y == t + 1f / 3f);

                bool integer = t == y;
                if (integer && isinrange(t, int.MinValue, int.MaxValue))
                {
                    return pow(x, (int)t);
                }

                if (powsqrt | powcbrt)
                {
                    y = t;
                }

                switch (y)
                {
                    case -0.5f:    { result = rsqrt(x); break; }
                    case -1f / 3f: { result = rcbrt(x, /*pow standard: negative -> NaN*/Promise.ZeroOrGreater); break; }
                    case 0f:       { result = 1f; break; }
                    case 1f / 3f:  { result = cbrt(x, /*pow standard: negative -> NaN*/Promise.ZeroOrGreater); break; }
                    case 0.5f:     { result = sqrt(x); break; }
                    case 0.25f:    { result = rsqrt(rsqrt(x)); break; }
                    case 0.125f:   { result = sqrt(rsqrt(rsqrt(x))); break; }

                    default: result = pow(x, (float2)y); break;
                }

                if (powsqrt)
                {
                    result *= sqrt(x);
                }
                if (powcbrt)
                {
                    result *= cbrt(x, /*pow standard: negative -> NaN*/Promise.ZeroOrGreater);
                }
            }
            else
            {
                result = pow(x, (float2)y);
            }

            return result;
        }


        /// <summary>       Returns the result of raising each <paramref name="x"/> component to the power <paramref name="y"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 pow(double4 x, double y)
        {
            double4 result;

            if (constexpr.IS_CONST(y))
            {
                double t = trunc(y);
                bool powsqrt = y > 1d & (y - t == 0.5d);
                bool powcbrt = y > 1d & (y == t + 1d / 3d);

                bool integer = t == y;
                if (integer && isinrange(t, int.MinValue, int.MaxValue))
                {
                    return pow(x, (int)t);
                }

                if (powsqrt | powcbrt)
                {
                    y = t;
                }

                switch (y)
                {
                    case -0.5d:    { result = rsqrt(x); break; }
                    case -1d / 3d: { result = /*pow standard: negative -> NaN*/select(rcbrt(x), double.NaN, x < 0d); break; }
                    case 0d:       { result = 1f; break; }
                    case 1d / 3d:  { result = /*pow standard: negative -> NaN*/select(cbrt(x), double.NaN, x < 0d); break; }
                    case 0.5d:     { result = sqrt(x); break; }
                    case 0.25d:    { result = rsqrt(rsqrt(x)); break; }
                    case 0.125d:   { result = sqrt(rsqrt(rsqrt(x))); break; }

                    default: result = pow(x, (double4)y); break;
                }

                if (powsqrt)
                {
                    result *= sqrt(x);
                }
                if (powcbrt)
                {
                    result *= /*pow standard: negative -> NaN*/select(cbrt(x), double.NaN, x < 0d);
                }
            }
            else
            {
                result = pow(x, (double4)y);
            }

            return result;
        }

        /// <summary>       Returns the result of raising each <paramref name="x"/> component to the power <paramref name="y"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 pow(double3 x, double y)
        {
            double3 result;

            if (constexpr.IS_CONST(y))
            {
                double t = trunc(y);
                bool powsqrt = y > 1d & (y - t == 0.5d);
                bool powcbrt = y > 1d & (y == t + 1d / 3d);

                bool integer = t == y;
                if (integer && isinrange(t, int.MinValue, int.MaxValue))
                {
                    return pow(x, (int)t);
                }

                if (powsqrt | powcbrt)
                {
                    y = t;
                }

                switch (y)
                {
                    case -0.5d:    { result = rsqrt(x); break; }
                    case -1d / 3d: { result = /*pow standard: negative -> NaN*/select(rcbrt(x), double.NaN, x < 0d); break; }
                    case 0d:       { result = 1f; break; }
                    case 1d / 3d:  { result = /*pow standard: negative -> NaN*/select(cbrt(x), double.NaN, x < 0d); break; }
                    case 0.5d:     { result = sqrt(x); break; }
                    case 0.25d:    { result = rsqrt(rsqrt(x)); break; }
                    case 0.125d:   { result = sqrt(rsqrt(rsqrt(x))); break; }

                    default: result = pow(x, (double3)y); break;
                }

                if (powsqrt)
                {
                    result *= sqrt(x);
                }
                if (powcbrt)
                {
                    result *= /*pow standard: negative -> NaN*/select(cbrt(x), double.NaN, x < 0d);
                }
            }
            else
            {
                result = pow(x, (double3)y);
            }

            return result;
        }

        /// <summary>       Returns the result of raising each <paramref name="x"/> component to the power <paramref name="y"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 pow(double2 x, double y)
        {
            double2 result;

            if (constexpr.IS_CONST(y))
            {
                double t = trunc(y);
                bool powsqrt = y > 1d & (y - t == 0.5d);
                bool powcbrt = y > 1d & (y == t + 1d / 3d);

                bool integer = t == y;
                if (integer && isinrange(t, int.MinValue, int.MaxValue))
                {
                    return pow(x, (int)t);
                }

                if (powsqrt | powcbrt)
                {
                    y = t;
                }

                switch (y)
                {
                    case -0.5d:    { result = rsqrt(x); break; }
                    case -1d / 3d: { result = /*pow standard: negative -> NaN*/select(rcbrt(x), double.NaN, x < 0d); break; }
                    case 0d:       { result = 1f; break; }
                    case 1d / 3d:  { result = /*pow standard: negative -> NaN*/select(cbrt(x), double.NaN, x < 0d); break; }
                    case 0.5d:     { result = sqrt(x); break; }
                    case 0.25d:    { result = rsqrt(rsqrt(x)); break; }
                    case 0.125d:   { result = sqrt(rsqrt(rsqrt(x))); break; }

                    default: result = pow(x, (double2)y); break;
                }

                if (powsqrt)
                {
                    result *= sqrt(x);
                }
                if (powcbrt)
                {
                    result *= /*pow standard: negative -> NaN*/select(cbrt(x), double.NaN, x < 0d);
                }
            }
            else
            {
                result = pow(x, (double2)y);
            }

            return result;
        }


        /// <summary>       Returns the base-e exponential of <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float exp(float x)
        {
            return Unity.Mathematics.math.exp(x);
        }

        /// <summary>       Returns the componentwise base-e exponential of <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 exp(float2 x)
        {
            return Unity.Mathematics.math.exp(x);
        }

        /// <summary>       Returns the componentwise base-e exponential of <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 exp(float3 x)
        {
            return Unity.Mathematics.math.exp(x);
        }

        /// <summary>       Returns the componentwise base-e exponential of <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 exp(float4 x)
        {
            return Unity.Mathematics.math.exp(x);
        }

        /// <summary>       Returns the componentwise base-e exponential of <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 exp(float8 x)
        {
            if (Avx.IsAvxSupported)
            {
                float8 r = Uninitialized<float8>.Create();

                for (int i = 0; i < 8; i++)
                {
                    *((float*)&r + i) = exp(*((float*)&x + i));
                }

                return r;
            }
            else
            {
                return new float8(exp(x.v4_0), exp(x.v4_4));
            }
        }


        /// <summary>       Returns the base-e exponential of <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double exp(double x)
        {
            return Unity.Mathematics.math.exp(x);
        }

        /// <summary>       Returns the componentwise base-e exponential of <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 exp(double2 x)
        {
            return Unity.Mathematics.math.exp(x);
        }

        /// <summary>       Returns the componentwise base-e exponential of <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 exp(double3 x)
        {
            return Unity.Mathematics.math.exp(x);
        }

        /// <summary>       Returns the componentwise base-e exponential of <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 exp(double4 x)
        {
            return Unity.Mathematics.math.exp(x);
        }


        /// <summary>       Returns the base-2 exponential of <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float exp2(float x)
        {
            return Unity.Mathematics.math.exp2(x);
        }

        /// <summary>       Returns the componentwise base-2 exponential of <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 exp2(float2 x)
        {
            return Unity.Mathematics.math.exp2(x);
        }

        /// <summary>       Returns the componentwise base-2 exponential of <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 exp2(float3 x)
        {
            return Unity.Mathematics.math.exp2(x);
        }

        /// <summary>       Returns the componentwise base-2 exponential of <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 exp2(float4 x)
        {
            return Unity.Mathematics.math.exp2(x);
        }

        /// <summary>       Returns the componentwise base-2 exponential of <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 exp2(float8 x)
        {
            if (Avx.IsAvxSupported)
            {
                float8 r = Uninitialized<float8>.Create();

                for (int i = 0; i < 8; i++)
                {
                    *((float*)&r + i) = exp2(*((float*)&x + i));
                }

                return r;
            }
            else
            {
                return new float8(exp2(x.v4_0), exp2(x.v4_4));
            }
        }


        /// <summary>       Returns the base-2 exponential of <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double exp2(double x)
        {
            return Unity.Mathematics.math.exp2(x);
        }

        /// <summary>       Returns the componentwise base-2 exponential of <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 exp2(double2 x)
        {
            return Unity.Mathematics.math.exp2(x);
        }

        /// <summary>       Returns the componentwise base-2 exponential of <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 exp2(double3 x)
        {
            return Unity.Mathematics.math.exp2(x);
        }

        /// <summary>       Returns the componentwise base-2 exponential of <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 exp2(double4 x)
        {
            return Unity.Mathematics.math.exp2(x);
        }


        /// <summary>       Returns the base-10 exponential of <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float exp10(float x)
        {
            return Unity.Mathematics.math.exp10(x);
        }

        /// <summary>       Returns the componentwise base-10 exponential of <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 exp10(float2 x)
        {
            return Unity.Mathematics.math.exp10(x);
        }

        /// <summary>       Returns the componentwise base-10 exponential of <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 exp10(float3 x)
        {
            return Unity.Mathematics.math.exp10(x);
        }

        /// <summary>       Returns the componentwise base-10 exponential of <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 exp10(float4 x)
        {
            return Unity.Mathematics.math.exp10(x);
        }

        /// <summary>       Returns the componentwise base-10 exponential of <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 exp10(float8 x)
        {
            if (Avx.IsAvxSupported)
            {
                float8 r = Uninitialized<float8>.Create();

                for (int i = 0; i < 8; i++)
                {
                    *((float*)&r + i) = exp10(*((float*)&x + i));
                }

                return r;
            }
            else
            {
                return new float8(exp10(x.v4_0), exp10(x.v4_4));
            }
        }


        /// <summary>       Returns the base-10 exponential of <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double exp10(double x)
        {
            return Unity.Mathematics.math.exp10(x);
        }

        /// <summary>       Returns the componentwise base-10 exponential of <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 exp10(double2 x)
        {
            return Unity.Mathematics.math.exp10(x);
        }

        /// <summary>       Returns the componentwise base-10 exponential of <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 exp10(double3 x)
        {
            return Unity.Mathematics.math.exp10(x);
        }

        /// <summary>       Returns the componentwise base-10 exponential of <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 exp10(double4 x)
        {
            return Unity.Mathematics.math.exp10(x);
        }
    }
}