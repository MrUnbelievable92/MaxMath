using System.Runtime.CompilerServices;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        ///         <summary>Returns a bool8 indicating for each component of a float8 whether it is a finite floating point value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 isfinite(float8 x) 
        { 
            return abs(x) < float.PositiveInfinity; 
        }
        
        ///         <summary>Returns a bool8 indicating for each component of a float8 whether it is an infinite floating point value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 isinf(float8 x) 
        { 
            return abs(x) == float.PositiveInfinity; 
        }
        
        ///<summary>        Returns a bool8 indicating for each component of a float8 whether it is a NaN (not a number) floating point value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 isnan(float8 x) 
        { 
            return (asint(x) & (int)bitmask32(31)) > 0x7F80_0000; 
        }


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

        /// <summary>       Performs a componentwise split of a float8 vector into an integral part i and a fractional part that gets returned. Both parts take the sign of the corresponding input component.      </summary>
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

        /// <summary>       Returns the result of a componentwise clamping of the float8 vector x into the interval [0, 1].        </summary>
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


        /// <summary>       Returns the componentwise square root of a float8 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 sqrt(float8 x)
        {
            return Avx.mm256_sqrt_ps(x);
        }

        /// <summary>       Returns the componentwise reciprocal square root of a float8 vector     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 rsqrt(float8 x)
        {
            return Avx.mm256_rsqrt_ps(x);
        }

        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static float8 fmod(float8 x, float8 y)
        //{
        //    float8 quotient = x / y;
        //
        //    return y * (quotient - trunc(quotient));
        //}

        /// <summary>       Returns the result of a componentwise linear interpolating from x to y using the corresponding components of the interpolation parameter s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 lerp(float8 x, float8 y, float8 s) 
        { 
            return maxmath.mad(s, y - x, x);
        }
    }
}