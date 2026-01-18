using System.Runtime.CompilerServices;
using Unity.Mathematics;
using MaxMath.Intrinsics;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the result of raising each <paramref name="x"/> component to the power <paramref name="y"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 pow(float8 x, float y)
        {
            float8 result;

            if (constexpr.IS_CONST(y))
            {
                float t = math.trunc(y);
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
                float t = math.trunc(y);
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
                    case -0.5f:    { result = math.rsqrt(x); break; }
                    case -1f / 3f: { result = rcbrt(x, /*pow standard: negative -> NaN*/Promise.ZeroOrGreater); break; }
                    case 0f:       { result = 1f; break; }
                    case 1f / 3f:  { result = cbrt(x, /*pow standard: negative -> NaN*/Promise.ZeroOrGreater); break; }
                    case 0.5f:     { result = math.sqrt(x); break; }
                    case 0.25f:    { result = math.rsqrt(math.rsqrt(x)); break; }
                    case 0.125f:   { result = math.sqrt(math.rsqrt(math.rsqrt(x))); break; }

                    default: result = math.pow(x, (float4)y); break;
                }

                if (powsqrt)
                {
                    result *= math.sqrt(x);
                }
                if (powcbrt)
                {
                    result *= cbrt(x, /*pow standard: negative -> NaN*/Promise.ZeroOrGreater);
                }
            }
            else
            {
                result = math.pow(x, (float4)y);
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
                float t = math.trunc(y);
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
                    case -0.5f:    { result = math.rsqrt(x); break; }
                    case -1f / 3f: { result = rcbrt(x, /*pow standard: negative -> NaN*/Promise.ZeroOrGreater); break; }
                    case 0f:       { result = 1f; break; }
                    case 1f / 3f:  { result = cbrt(x, /*pow standard: negative -> NaN*/Promise.ZeroOrGreater); break; }
                    case 0.5f:     { result = math.sqrt(x); break; }
                    case 0.25f:    { result = math.rsqrt(math.rsqrt(x)); break; }
                    case 0.125f:   { result = math.sqrt(math.rsqrt(math.rsqrt(x))); break; }

                    default: result = math.pow(x, (float3)y); break;
                }

                if (powsqrt)
                {
                    result *= math.sqrt(x);
                }
                if (powcbrt)
                {
                    result *= cbrt(x, /*pow standard: negative -> NaN*/Promise.ZeroOrGreater);
                }
            }
            else
            {
                result = math.pow(x, (float3)y);
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
                float t = math.trunc(y);
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
                    case -0.5f:    { result = math.rsqrt(x); break; }
                    case -1f / 3f: { result = rcbrt(x, /*pow standard: negative -> NaN*/Promise.ZeroOrGreater); break; }
                    case 0f:       { result = 1f; break; }
                    case 1f / 3f:  { result = cbrt(x, /*pow standard: negative -> NaN*/Promise.ZeroOrGreater); break; }
                    case 0.5f:     { result = math.sqrt(x); break; }
                    case 0.25f:    { result = math.rsqrt(math.rsqrt(x)); break; }
                    case 0.125f:   { result = math.sqrt(math.rsqrt(math.rsqrt(x))); break; }

                    default: result = math.pow(x, (float2)y); break;
                }

                if (powsqrt)
                {
                    result *= math.sqrt(x);
                }
                if (powcbrt)
                {
                    result *= cbrt(x, /*pow standard: negative -> NaN*/Promise.ZeroOrGreater);
                }
            }
            else
            {
                result = math.pow(x, (float2)y);
            }

            return result;
        }

        /// <summary>       Returns the result of raising <paramref name="x"/> to the power <paramref name="y"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float pow(float x, float y)
        {
            float result;

            if (constexpr.IS_CONST(y))
            {
                float t = math.trunc(y);
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
                    case -0.5f:    { result = math.rsqrt(x); break; }
                    case -1f / 3f: { result = rcbrt(x, /*pow standard: negative -> NaN*/Promise.ZeroOrGreater); break; }
                    case 0f:       { result = 1f; break; }
                    case 1f / 3f:  { result = cbrt(x, /*pow standard: negative -> NaN*/Promise.ZeroOrGreater); break; }
                    case 0.5f:     { result = math.sqrt(x); break; }
                    case 0.25f:    { result = math.rsqrt(math.rsqrt(x)); break; }
                    case 0.125f:   { result = math.sqrt(math.rsqrt(math.rsqrt(x))); break; }

                    default: result = math.pow(x, (float)y); break;
                }

                if (powsqrt)
                {
                    result *= math.sqrt(x);
                }
                if (powcbrt)
                {
                    result *= cbrt(x, /*pow standard: negative -> NaN*/Promise.ZeroOrGreater);
                }
            }
            else
            {
                result = math.pow(x, (float)y);
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
                double t = math.trunc(y);
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
                    case -0.5d:    { result = math.rsqrt(x); break; }
                    case -1d / 3d: { result = /*pow standard: negative -> NaN*/math.select(rcbrt(x), double.NaN, x < 0d); break; }
                    case 0d:       { result = 1f; break; }
                    case 1d / 3d:  { result = /*pow standard: negative -> NaN*/math.select(cbrt(x), double.NaN, x < 0d); break; }
                    case 0.5d:     { result = math.sqrt(x); break; }
                    case 0.25d:    { result = math.rsqrt(math.rsqrt(x)); break; }
                    case 0.125d:   { result = math.sqrt(math.rsqrt(math.rsqrt(x))); break; }

                    default: result = math.pow(x, (double4)y); break;
                }

                if (powsqrt)
                {
                    result *= math.sqrt(x);
                }
                if (powcbrt)
                {
                    result *= /*pow standard: negative -> NaN*/math.select(cbrt(x), double.NaN, x < 0d);
                }
            }
            else
            {
                result = math.pow(x, (double4)y);
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
                double t = math.trunc(y);
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
                    case -0.5d:    { result = math.rsqrt(x); break; }
                    case -1d / 3d: { result = /*pow standard: negative -> NaN*/math.select(rcbrt(x), double.NaN, x < 0d); break; }
                    case 0d:       { result = 1f; break; }
                    case 1d / 3d:  { result = /*pow standard: negative -> NaN*/math.select(cbrt(x), double.NaN, x < 0d); break; }
                    case 0.5d:     { result = math.sqrt(x); break; }
                    case 0.25d:    { result = math.rsqrt(math.rsqrt(x)); break; }
                    case 0.125d:   { result = math.sqrt(math.rsqrt(math.rsqrt(x))); break; }

                    default: result = math.pow(x, (double3)y); break;
                }

                if (powsqrt)
                {
                    result *= math.sqrt(x);
                }
                if (powcbrt)
                {
                    result *= /*pow standard: negative -> NaN*/math.select(cbrt(x), double.NaN, x < 0d);
                }
            }
            else
            {
                result = math.pow(x, (double3)y);
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
                double t = math.trunc(y);
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
                    case -0.5d:    { result = math.rsqrt(x); break; }
                    case -1d / 3d: { result = /*pow standard: negative -> NaN*/math.select(rcbrt(x), double.NaN, x < 0d); break; }
                    case 0d:       { result = 1f; break; }
                    case 1d / 3d:  { result = /*pow standard: negative -> NaN*/math.select(cbrt(x), double.NaN, x < 0d); break; }
                    case 0.5d:     { result = math.sqrt(x); break; }
                    case 0.25d:    { result = math.rsqrt(math.rsqrt(x)); break; }
                    case 0.125d:   { result = math.sqrt(math.rsqrt(math.rsqrt(x))); break; }

                    default: result = math.pow(x, (double2)y); break;
                }

                if (powsqrt)
                {
                    result *= math.sqrt(x);
                }
                if (powcbrt)
                {
                    result *= /*pow standard: negative -> NaN*/math.select(cbrt(x), double.NaN, x < 0d);
                }
            }
            else
            {
                result = math.pow(x, (double2)y);
            }

            return result;
        }

        /// <summary>       Returns the result of raising <paramref name="x"/> to the power <paramref name="y"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double pow(double x, double y)
        {
            double result;

            if (constexpr.IS_CONST(y))
            {
                double t = math.trunc(y);
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
                    case -0.5d:    { result = math.rsqrt(x); break; }
                    case -1d / 3d: { result = /*pow standard: negative -> NaN*/math.select(rcbrt(x), double.NaN, x < 0d); break; }
                    case 0d:       { result = 1f; break; }
                    case 1d / 3d:  { result = /*pow standard: negative -> NaN*/math.select(cbrt(x), double.NaN, x < 0d); break; }
                    case 0.5d:     { result = math.sqrt(x); break; }
                    case 0.25d:    { result = math.rsqrt(math.rsqrt(x)); break; }
                    case 0.125d:   { result = math.sqrt(math.rsqrt(math.rsqrt(x))); break; }

                    default: result = math.pow(x, (double)y); break;
                }

                if (powsqrt)
                {
                    result *= math.sqrt(x);
                }
                if (powcbrt)
                {
                    result *= /*pow standard: negative -> NaN*/math.select(cbrt(x), double.NaN, x < 0d);
                }
            }
            else
            {
                result = math.pow(x, (double)y);
            }

            return result;
        }
    }
}