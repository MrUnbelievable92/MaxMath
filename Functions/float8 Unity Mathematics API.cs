using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 rcp(float8 x)
        {
            return Avx.mm256_rcp_ps(x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 frac(float8 x)
        {
            return x - floor(x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 modf(float8 x, out float8 i)
        {
            return x - (i = trunc(x));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 mad(float8 a, float8 b, float8 c)
        {
            return Fma.mm256_fmadd_ps(a, b, c);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 saturate(float8 x) 
        { 
            return clamp(x, 0.0f, 1.0f); 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 clamp(float8 x, float8 min, float8 max)
        {
            return maxmath.max(min, maxmath.min(x, max));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 trunc(float8 x)
        {
            return Avx.mm256_round_ps(x, (int)X86.RoundingMode.FROUND_TRUNC);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 round(float8 x)
        {
            return Avx.mm256_round_ps(x, (int)X86.RoundingMode.FROUND_NINT);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 floor(float8 x)
        {
            return Avx.mm256_floor_ps(x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 ceil(float8 x)
        {
            return Avx.mm256_ceil_ps(x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 sqrt(float8 x)
        {
            return Avx.mm256_sqrt_ps(x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 rsqrt(float8 x)
        {
            return Avx.mm256_rsqrt_ps(x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 fmod(float8 x, float8 y)
        {
            float8 quotient = x / y;

            return y * (quotient - trunc(quotient));
        }

        /// <summary>       Returns the result of a componentwise linear interpolating from x to y using the corresponding components of the interpolation parameter s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 lerp(float8 x, float8 y, float8 s) 
        { 
            return maxmath.mad(s, y - x, x);
        }
    }
}