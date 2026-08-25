using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Burst.CompilerServices;
using Unity.Burst.Intrinsics;
using MaxMath.CompilerServices;
using MaxMath.Intrinsics;

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

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static quadruple pow_Base(quadruple x, quadruple y)
        {
            quadruple.ConstChecked two113 = new quadruple(0x0000_0000_0000_0000, 0x4070_0000_0000_0000);
        
            quadruple.ConstChecked LN_0 = new quadruple(0xD351_763D_521C_F8D2, 0xC003_EC77_8283_108D);
            quadruple.ConstChecked LN_1 = new quadruple(0x634C_653D_9344_2FEA, 0x4005_048B_0968_DA68);
            quadruple.ConstChecked LN_2 = new quadruple(0xBBA2_2AE6_2447_44E8, 0xC004_7280_DD26_AB32);
            quadruple.ConstChecked LN_3 = new quadruple(0x1CD1_C99C_785B_5FD7, 0x4002_9053_A023_4C25);
            quadruple.ConstChecked LN_4 = new quadruple(0xD1FB_8916_3835_3084, 0xBFFE_FC3F_1F7D_5799);
        
            quadruple.ConstChecked LD_0 = new quadruple(0x3019_37DD_C470_295E, 0xC004_9A63_976D_3876);
            quadruple.ConstChecked LD_1 = new quadruple(0xB6C4_2A88_A788_8557, 0x4006_2267_2C06_4F53);
            quadruple.ConstChecked LD_2 = new quadruple(0xCE1C_70B9_C662_0DC8, 0xC006_30CF_0405_7312);
            quadruple.ConstChecked LD_3 = new quadruple(0x4169_123F_BEA8_F6A3, 0x4005_2171_4A56_547D);
            quadruple.ConstChecked LD_4 = new quadruple(0x9601_94F8_F1D9_F146, 0xC002_DE24_C65F_C66A);
        
            quadruple.ConstChecked PN_0 = new quadruple(0xE86D_ACEC_7D0C_4054, 0x401B_E4A3_6C93_1089);
            quadruple.ConstChecked PN_1 = new quadruple(0xE3E6_18A4_38A1_5AF6, 0x4016_1DAB_FE99_88E2);
            quadruple.ConstChecked PN_2 = new quadruple(0xBAA8_F4FD_B268_3287, 0x400E_4932_0690_B3D2);
            quadruple.ConstChecked PN_3 = new quadruple(0x152F_8666_0A12_0EFC, 0x4004_A014_9D04_634B);
            quadruple.ConstChecked PN_4 = new quadruple(0x9CC0_10B8_DCC7_94E7, 0x3FF8_29CE_C291_D944);
        
            quadruple.ConstChecked PD_0 = new quadruple(0x6E52_41B1_5DC9_3056, 0x401E_6B7A_916E_4C67);
            quadruple.ConstChecked PD_1 = new quadruple(0x87E5_3E0C_F616_1D0C, 0x4019_981B_F72D_FA14);
            quadruple.ConstChecked PD_2 = new quadruple(0x2C43_03B1_2D43_967F, 0x4012_9348_B8B2_7A6A);
            quadruple.ConstChecked PD_3 = new quadruple(0x8725_A341_C32C_275E, 0x4009_D425_5D86_476D);
        
            quadruple.ConstChecked lg2_h = new quadruple(0xF000_0000_0000_0000, 0x3FFE_62E4_2FEF_A39E);
            quadruple.ConstChecked lg2_l = new quadruple(0xF2F6_AF40_F343_2673, 0x3FC7_ABC9_E3B3_9803);
            quadruple.ConstChecked ovt   = new quadruple(0xE459_FDE3_A492_DA6D, 0x3FC9_7154_7652_B82F);
            quadruple.ConstChecked cp    = new quadruple(0xD749_FC15_522B_C2F9, 0x3FFE_EC70_9DC3_A03F);
            quadruple.ConstChecked cp_h  = new quadruple(0xD000_0000_0000_0000, 0x3FFE_EC70_9DC3_A03F);
            quadruple.ConstChecked cp_l  = new quadruple(0xBE29_B09C_E4FC_7094, 0x3FC8_D27F_0554_8AF0);
        
            quadruple.ConstChecked z = default;
            quadruple.ConstChecked ax = default;
            quadruple.ConstChecked z_l = default;
            quadruple.ConstChecked p_h = default;
            quadruple.ConstChecked p_l = default;
            quadruple.ConstChecked y1 = default;
            quadruple.ConstChecked t1 = default;
            quadruple.ConstChecked t2 = default;
            quadruple.ConstChecked t3 = default;
            quadruple.ConstChecked r = default;
            quadruple.ConstChecked s = default;
            quadruple.ConstChecked t = default;
            quadruple.ConstChecked u = default;
            quadruple.ConstChecked v = default;
            quadruple.ConstChecked w = default;
            quadruple.ConstChecked s2 = default;
            quadruple.ConstChecked s_h = default;
            quadruple.ConstChecked s_l = default;
            quadruple.ConstChecked t_h = default;
            quadruple.ConstChecked t_l = default;
            quadruple.ConstChecked ay = default;
            quadruple.ConstChecked bp = 1;
        
            z.Promise.NotNaN   = true;
            ax.Promise.NotNaN  = true;
            z_l.Promise.NotNaN = true;
            p_h.Promise.NotNaN = true;
            p_l.Promise.NotNaN = true;
            y1.Promise.NotNaN  = true;
            t1.Promise.NotNaN  = true;
            t2.Promise.NotNaN  = true;
            t3.Promise.NotNaN  = true;
            r.Promise.NotNaN   = true;
            s.Promise.NotNaN   = true;
            t.Promise.NotNaN   = true;
            u.Promise.NotNaN   = true;
            v.Promise.NotNaN   = true;
            w.Promise.NotNaN   = true;
            s2.Promise.NotNaN  = true;
            s_h.Promise.NotNaN = true;
            s_l.Promise.NotNaN = true;
            t_h.Promise.NotNaN = true;
            t_l.Promise.NotNaN = true;
            ay.Promise.NotNaN  = true;
        
        
            int i, j, k, yisint, n;
            uint ix, iy;
            int hx, hy;

            hx = (int)(x.value.hi64 >> 32);
            ix = (uint)(hx & 0x7FFF_FFFF);

            hy = (int)(y.value.hi64 >> 32);
            iy = (uint)(hy & 0x7FFF_FFFF);


            if (Hint.Unlikely((iy | (uint)y.value.hi64 | y.value.lo64) == 0
                            & !isnan(x)))
            {
                return 1;
            }
            if (Hint.Unlikely(x == 1 
                            & !isnan(y)))
            {
                return 1;
            }
            if (Hint.Unlikely((x == -1) 
                            & (iy == 0x7FFF_0000)
                            & ((uint)y.value.hi64 | y.value.lo64) == 0))
            {
                return 1;
            }
            if (Hint.Unlikely((ix > 0x7FFF_0000)
                            | isnan(x)
                            | (iy > 0x7FFF_0000)
                            | isnan(y)))
            {
                return quadruple.NaN;
            }

            yisint = 0;
            if (hx < 0)
            {
                if (iy >= 0x4070_0000)
                {
                    yisint = 2;
                }
                else if (iy >= 0x3FFF_0000)
	            {
	                if (isint(y, Promise.Unsafe0))
	                {
	                    z = 0.5 * y;
	                    if (isint(z, Promise.Unsafe0))
                        {
                            yisint = 2;
                        }
	                    else
                        {
                            yisint = 1;
                        }
	                }
	            }
            }

            if (Hint.Unlikely(((uint)y.value.hi64 | y.value.lo64) == 0))
            {
                if (iy == 0x7FFF_0000)
	            {
	                if (((ix - 0x3FFF_0000) | (uint)x.value.hi64 | x.value.lo64) == 0)
                    {
                        return quadruple.NaN;
                    }
	                else if (ix >= 0x3FFF_0000)
                    {
                        return hy >= 0 ? y : 0;
                    }
	                else
                    {
                        return hy < 0 ? -y : 0;
                    }
	            }
                if (iy == 0x3FFF_0000)
	            {
                    return hy < 0 ? rcp(x) : x;
	            }
                if (hy == 0x4000_0000)
                {
                    return square(x);
                }
                if ((hy == 0x3FFE_0000)
                  & hx >= 0)
	            {
                    return sqrt(x);
	            }
            }

            ax = abs(x);

            if (Hint.Unlikely(((uint)x.value.hi64 | x.value.lo64) == 0))
            {
                if ((ix == 0x7FFF_0000) 
                  | (ix == 0)
                  | (ix == 0x3FFF_0000))
	            {
	                z = ax;
	                if (hy < 0)
                    {
                        z = rcp(z);
                    }
	                if (hx < 0)
	                {
	                    if (((ix - 0x3FFF_0000) | (uint)yisint) == 0)
	            	    {
	            	        z = quadruple.NaN;
	            	    }
	                    else if (yisint == 1)
                        {
                            z = -z;
                        }
	                }
	                return z;
	            }
            }

            if (((((uint)hx >> 31) - 1) | (uint)yisint) == 0)
            {
                return quadruple.NaN;
            }
              
            bool negate = ((((uint)hx >> 31) - 1) | ((uint)yisint - 1)) == 0;

            if (iy > 0x401D_654B)
            {
                if (iy > 0x407D_654B)
	            {
	                if (ix <= 0x3FFE_FFFF)
                    {
	                    return (hy < 0) ? hugeQuadruple * hugeQuadruple : tinyQuadruple * tinyQuadruple;
                    }
	                if (ix >= 0x3FFF_0000)
                    {
	                    return (hy > 0) ? hugeQuadruple * hugeQuadruple : tinyQuadruple * tinyQuadruple;
                    }
	            }
                if (ix < 0x3FFE_FFFF)
                {
	                return negateif(hy < 0 ? hugeQuadruple * hugeQuadruple : tinyQuadruple * tinyQuadruple, negate);
                }
                if (ix > 0x3FFF_0000)
                {
	                return negateif(hy > 0 ? hugeQuadruple * hugeQuadruple : tinyQuadruple * tinyQuadruple, negate);
                }
            }

            ay = abs(y);

            if (ay < new quadruple(0, 0x3F7F_0000_0000_0000))
            {
                y = copysign(new quadruple(0, 0x3F7F_0000_0000_0000), y);
            }

            n = 0;
            if (Hint.Unlikely(ix < 0x0001_0000))
            {
                ax *= two113;
                n -= 113;
                ix = (uint)(ax.Value.value.hi64 >> 32);
            }
            n += (int)(((ix) >> 16) - 0x3FFF);
            j = (ushort)ix;
            ix = (uint)j | 0x3FFF_0000;
            bp = 1;
            k = 0;
            if (!(j > 0x3988))
            {
                ;
            }
            else if (j < 0xBB67)
            {
                bp = 1.5;
                k = 1;
            }
            else
            {
                n += 1;
                ix -= 0x0001_0000;
            }

            ax = new quadruple(ax.Value.value.lo64, (uint)ax.Value.value.hi64 | ((ulong)ix << 32));

            u = ax - bp;
            v = rcp(ax + bp);
            s = u * v;
            s_h = s;
            s_h = new quadruple(s_h.Value.value.lo64 & 0xF800_0000_0000_0000, s_h.Value.value.hi64);
            t_h = ax + bp;
            t_h = new quadruple(t_h.Value.value.lo64 & 0xF800_0000_0000_0000, t_h.Value.value.hi64);
            t_l = ax - (t_h - bp);
            s_l = v * quadruple.fnmadd(s_h, t_l, quadruple.fnmadd(s_h, t_h, u));
            s2 = square(s);
            u = quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(LN_4, s2, LN_3), s2, LN_2), s2, LN_1), s2, LN_0);
            v = quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(LD_4 + s2, s2, LD_3), s2, LD_2), s2, LD_1), s2, LD_0);
            r = square(s2) * u / v;
            r = quadruple.fmadd(s_l, s_h + s, r);
            t_h = r + quadruple.fmadd(s_h, s_h, 3.0);
            t_h = new quadruple(t_h.Value.value.lo64 & 0xF800_0000_0000_0000, t_h.Value.value.hi64);
            t_l = r - quadruple.fnmadd(s_h, s_h, t_h - 3.0);
            v = quadruple.fmadd(t_l, s, s_l * t_h);
            p_h = quadruple.fmadd(s_h, t_h, v);
            p_h = new quadruple(p_h.Value.value.lo64 & 0xF800_0000_0000_0000, p_h.Value.value.hi64);
            p_l = v - quadruple.fnmadd(s_h, t_h, p_h);
            z_l = quadruple.fmadd(p_l, cp, cp_l * p_h);
            if (k != 0)
            {
                z_l += new quadruple(0xA2EB_7449_3CF9_A8E9, 0x3FC9_E7E8_02C4_8281);
            }
            t = n;
            t3 = quadruple.fmadd(cp_h, p_h, z_l);
            if (k == 0)
            {
                t1 = t3 + t;
                t1 = new quadruple(t1.Value.value.lo64 & 0xF800_0000_0000_0000, t1.Value.value.hi64);
                t2 = z_l - quadruple.fnmadd(cp_h, p_h, t1 - t);
            }
            else
            {
                quadruple.ConstChecked dp_h = new quadruple(0x0000_0000_0000_0000, 0x3FFE_2B80_3473_F7AD);

                t1 = t3 + dp_h + t;
                t1 = new quadruple(t1.Value.value.lo64 & 0xF800_0000_0000_0000, t1.Value.value.hi64);
                t2 = z_l - quadruple.fnmadd(cp_h, p_h, t1 - t - dp_h);
            }

            quadruple.ConstChecked __y = y;
            __y.Promise.MakeFiniteNotNaN();
            __y.Promise.NonZero = true;

            y1 = new quadruple(__y.Value.value.lo64 & 0xF800_0000_0000_0000, __y.Value.value.hi64);
            p_l = quadruple.fmadd(__y - y1, t1, y * t2);
            z = quadruple.fmadd(y1, t1, p_l);
            j = (int)(z.Value.value.hi64 >> 32);
            if (j >= 0x400D_0000)
            {
                if (((uint)(j - 0x400D_0000) | (z.Value.value.hi64 & 0xFFFF_FFFF) | z.Value.value.lo64) != 0)
	            {
	                return negateif(hugeQuadruple * hugeQuadruple, negate);
	            }
                else
	            {
	                if (p_l + ovt > quadruple.fnmadd(y1, t1, z))
                    {
                        return negateif(hugeQuadruple * hugeQuadruple, negate);
                    }
	            }
            }
            else if ((j & 0x7FFF_FFFF) >= 0x400D_01B9)
            {
                if (((uint)(j - 0xC00D_01BC) | (z.Value.value.hi64 & 0xFFFF_FFFF) | z.Value.value.lo64) != 0)
	            {
	                return negateif(tinyQuadruple * tinyQuadruple, negate);
	            }
                else
	            {
	                if (p_l <= quadruple.fnmadd(y1, t1, z))
                    {
	                    return negateif(tinyQuadruple * tinyQuadruple, negate);
                    }
	            }
            }
            i = j & 0x7FFF_FFFF;
            if (i > 0x3FFE_0000)
            {
                n = (int)floor(z + 0.5);
                t.Value = n;
                p_h = quadruple.fmsub(y1, t1, t);
                t = p_l + p_h;
                t = new quadruple(t.Value.value.lo64 & 0xF800_0000_0000_0000, t.Value.value.hi64);
                t3 = t - p_h;
            }
            else
            {
                n = 0;
                t = quadruple.fmadd(y1, t1, p_l);
                t = new quadruple(t.Value.value.lo64 & 0xF800_0000_0000_0000, t.Value.value.hi64);
                t3 = quadruple.fnmadd(y1, t1, t);
            }
            v = quadruple.fmadd(p_l - t3, LN2_QUAD, t * lg2_l);
            z = quadruple.fmadd(t, lg2_h, v);
            w = v - quadruple.fnmadd(t, lg2_h, z);
            t = square(z);
            u = quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(PN_4, t, PN_3), t, PN_2), t, PN_1), t, PN_0);
            v = quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(z, z, PD_3), t, PD_2), t, PD_1), t, PD_0);
            t1 = z - t * u / v;
            r = (z * t1) / (t1 - 2) - quadruple.fmadd(z, w, w);
            z = 1 - (r - z);
            long j2 = (long)z.Value.value.hi64;
            j2 += (long)(uint)n << 48;

            if (j2 >> 48 <= 0)
            {
                z = scalbn(z, n);
            }
            else
            {
                z = new quadruple(z.Value.value.lo64, (uint)z.Value.value.hi64 | ((ulong)j2 & 0xFFFF_FFFF_0000_0000));
            }

            return negateif(z, negate);
        }
        
        /// <summary>       Returns the result of raising <paramref name="x"/> to the power <paramref name="y"/>.      </summary>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static quadruple pow(quadruple x, quadruple y)
        {
            return pow_Base(x, y);
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
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static quadruple.ConstChecked exp_Base(quadruple.ConstChecked x)
        {
            quadruple himark    = new quadruple(0xF357_93C7_6730_07E6, 0x400C_62E4_2FEF_A39E);
            quadruple lomark    = new quadruple(0xBB05_9FAB_B506_FF34, 0xC00C_654B_B3B2_C73E);
            quadruple THREEp96  = new quadruple(0x0000_0000_0000_0000, 0x4060_8000_0000_0000);
            quadruple THREEp103 = new quadruple(0x0000_0000_0000_0000, 0x4067_8000_0000_0000);
            quadruple THREEp111 = new quadruple(0x0000_0000_0000_0000, 0x406F_8000_0000_0000);
            quadruple M_1_LN2   = new quadruple(0xE177_7D0F_FDA0_D23A, 0x3FFF_7154_7652_B82F);
            quadruple M_LN2_0   = new quadruple(0xF357_93C7_6730_0000, 0x3FFE_62E4_2FEF_A39E);
            quadruple M_LN2_1   = new quadruple(0x9339_4C5B_16C5_068C, 0xBF98_F97B_57A0_79A1);
            quadruple TINY      = new quadruple(0x52E4_D255_44B1_042E, 0x0069_7769_BEAD_75EC);
            quadruple P2        = new quadruple(0x5555_5555_5555_5556, 0x3FFC_5555_5555_5555);
            quadruple P3        = new quadruple(0x5555_5527_D27D_1C71, 0x3FFA_5555_5555_5555);
            quadruple P4        = new quadruple(0x1111_10F4_2BB4_7B2B, 0x3FF8_1111_1111_1111);
            quadruple P5        = new quadruple(0x2223_8E62_7FE3_C23D, 0x3FF5_6C16_C16C_2222);
            quadruple P6        = new quadruple(0x91EE_1F07_C213_326A, 0x3FF2_A01A_01A0_2590);

            if (Hint.Likely(x < himark 
                          & x > lomark))
            {
                int tval1, tval2, __unsafe, n_i;
                quadruple x22, n, t, result, xl;
                quadruple ex2_u, scale_u;

                n = quadruple.fmadd(x, M_1_LN2, THREEp111);
                n -= THREEp111;

                x = quadruple.fnmadd(n, M_LN2_0, x);

                t = x + THREEp103;
                t -= THREEp103;

                tval1 = (int)(t * 256);

                x -= LUT.QUADRUPLE.exp(2 * 89 + 2 * tval1);
                xl = quadruple.fmsub(n, M_LN2_1, LUT.QUADRUPLE.exp(2 * 89 + 2 * tval1 + 1));

                t = x + THREEp96;
                t -= THREEp96;

                tval2 = (int)(t * 32768);

                x -= LUT.QUADRUPLE.exp((2 * 2 * 89 + 2 + 2 * 65) + 2 * tval2);
                xl -= LUT.QUADRUPLE.exp((2 * 2 * 89 + 2 + 2 * 65) + 2 * tval2 + 1);

                x += xl;

                ex2_u = LUT.QUADRUPLE.exp(((2 * 2 * 89 + 2 + 2 * 65) + 2 + 2 * 65 + 89) + tval1)
	        	      * LUT.QUADRUPLE.exp((((2 * 2 * 89 + 2 + 2 * 65) + 2 + 2 * 65 + 89) + 1 + 89 + 65) + tval2);

                n_i = (int)n;
                if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                {
                    __unsafe = tobyte(abs(n_i) >= 15000);
                }
                else
                {
                    __unsafe = tobyte(abs(n) >= 15000);
                }

                ulong exphi = ex2_u.value.hi64 + ((ulong)(n_i >> __unsafe) << quadruple.MANTISSA_BITS_HI64);
                ex2_u = asquadruple(new UInt128(ex2_u.value.lo64, bits_select(ex2_u.value.hi64, exphi, bitmask64((ulong)quadruple.EXPONENT_BITS, (ulong)quadruple.MANTISSA_BITS_HI64))));

                x22 = quadruple.fmadd(
                      quadruple.fmadd(
                      quadruple.fmadd(
                      quadruple.fmadd(
                      quadruple.fmadd(
                      quadruple.fmadd(x, P6, P5), 
                                          x, P4), 
                                          x, P3), 
                                          x, P2), 
                                          x, 0.5), 
                                  square(x), x);

                result = quadruple.fmadd(x22, ex2_u, ex2_u);

                if (__unsafe == 0)
                {
                    return result;
                }
                else
	            {
                    scale_u = 1;
                    exphi = scale_u.value.hi64 + ((ulong)(n_i - (n_i >> __unsafe)) << quadruple.MANTISSA_BITS_HI64);
                    scale_u = asquadruple(new UInt128(0, bits_select(scale_u.value.hi64, exphi, bitmask64((ulong)quadruple.EXPONENT_BITS, (ulong)quadruple.MANTISSA_BITS_HI64))));
	                
                    return quadruple.MultiplyByPowerOfTwo(result, pow2: scale_u);
	            }
            }
            else 
            {
                return select(select(quadruple.PositiveInfinity, 
                                     x, 
                                     isnan(x)), 
                              select(TINY * TINY, 
                                     0, 
                                     x.Value == quadruple.NegativeInfinity.value), 
                              x < himark);
            }
        }
        
        /// <summary>       Returns the base-e exponential of <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static quadruple exp(quadruple x)
        {
            return exp_Base(x);
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

        
        /// <summary>       Returns the base-2 exponential of <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static quadruple exp2(quadruple x)
        {
            if (Hint.Likely(x < 16384))
            {
                quadruple.ConstChecked __x = x;
                __x.Promise.NotNaN = true;

                if (Hint.Likely(__x >= (-16381 - 133 - 1)))
	            {
	                int intx = (int)__x.Value;
	                quadruple.ConstChecked fractx = frac(__x);
                    fractx.Promise.MakeFiniteNotNaN();

	                if (Hint.Unlikely(abs(fractx) < new quadruple(0x0000_0000_0000_0000, 0x3F8D_0000_0000_0000)))
                    {
	                    return scalbn(1 + fractx, intx);
                    }
	                else
                    {

	                    return scalbn(exp_Base(LN2_QUAD * fractx), intx);
                    }
	            }
                else
	            {
                    return 0;
	            }
            }
            else
            {
                return isnan(x) 
                     ? x 
                     : copysign(quadruple.PositiveInfinity, x);
            }
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
        

        /// <summary>       Returns the base-10 exponential of <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static quadruple exp10(quadruple x)
        {
            return pow_Base(10, x);
        }
    }
}