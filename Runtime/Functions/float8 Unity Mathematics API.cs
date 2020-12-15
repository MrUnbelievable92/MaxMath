using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        ///<summary>        Returns a bool8 indicating for each component of a float8 whether it is a finite floating point value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 isfinite(float8 x) 
        { 
            return abs(x) < float.PositiveInfinity; 
        }
        
        ///<summary>        Returns a bool8 indicating for each component of a float8 whether it is an infinite floating point value.      </summary>
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

        /// <summary>       Returns the componentwise reciprocal a float8 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 rcp(float8 x)
        {
            return Avx.mm256_rcp_ps(x);
        }

        /// <summary>       Returns the componentwise fractional parts of a float8 vector.      </summary>
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


        /// <summary>       Returns the result of a componentwise conversion of a float8 vector from degrees to radians.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 radians(float8 x) 
        { 
            return x * 0.0174532925f; 
        }
        
        /// <summary>       Returns the result of a componentwise conversion of a float8 vector from radians to degrees.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 degrees(float8 x) 
        { 
            return x * 57.295779513f; 
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


        /// <summary>       Returns the componentwise sign of a float8 value. 1.0f for positive components, 0.0f for zero components and -1.0f for negative components.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 sign(float8 x) 
        {
            v256 exp = new v256(math.asfloat(0x3F80_0000));

            float8 zeroMask = Avx.mm256_cmp_ps(x, default(v256), (int)Avx.CMP.EQ_OQ);
            float8 negativeMask = Avx.mm256_cmp_ps(x, default(v256), (int)Avx.CMP.LT_OS);
            float8 positiveMask = Avx.mm256_cmp_ps(x, default(v256), (int)Avx.CMP.GT_OS);

            negativeMask = Avx.mm256_and_ps(negativeMask, exp);
            positiveMask = Avx.mm256_and_ps(positiveMask, exp);


            return Avx.mm256_blendv_ps(positiveMask - negativeMask, x, zeroMask);
        }


        /// <summary>       Returns the result of a componentwise linear interpolation from x to y using the corresponding components of the interpolation parameter s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 lerp(float8 x, float8 y, float8 s) 
        { 
            return mad(s, y - x, x);
        }

        /// <summary>       Returns the componentwise result of normalizing a floating point value x to a range [a, b]. The opposite of lerp. Equivalent to (x - a) / (b - a).      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 unlerp(float8 a, float8 b, float8 x) 
        {
            return (x - a) / (b - a); 
        }

        ///<summary>        Returns the componentwise result of a non-clamping linear remapping of a value x from [a, b] to [c, d].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 remap(float8 a, float8 b, float8 c, float8 d, float8 x) 
        {
            return lerp(c, d, unlerp(a, b, x)); 
        }

        /// <summary>       Returns a componentwise smooth Hermite interpolation between 0.0f and 1.0f when x is in [a, b].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 smoothstep(float8 a, float8 b, float8 x)
        {
            float8 t = saturate((x - a) / (b - a));

            return (t * t) * mad(-2f, t, 3f);
        }

        /// <summary>       Returns the result of a componentwise step function where each component is 1.0f when x >= y and 0.0f otherwise.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 step(float8 y, float8 x) 
        { 
            return Avx.mm256_blendv_ps(default(float8), new float8(1f), Avx.mm256_cmp_ps(x, y, (int)Avx.CMP.GE_OS)); 
        }
    }
}