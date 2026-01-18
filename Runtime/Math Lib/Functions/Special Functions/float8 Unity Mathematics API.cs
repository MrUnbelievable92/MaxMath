using System.Runtime.CompilerServices;
using Unity.Mathematics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the result of a componentwise truncation of a <see cref="MaxMath.float8"/> to an integral <see cref="MaxMath.float8"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 trunc(float8 x)
        {
            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_trunc_ps(x);
            }
            else
            {
                return new float8(math.trunc(x.v4_0), math.trunc(x.v4_4));
            }
        }

        /// <summary>       Returns the result of rounding each component of a <see cref="MaxMath.float8"/> to the nearest numerical value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 round(float8 x)
        {
            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_round_ps(x);
            }
            else
            {
                return new float8(math.round(x.v4_0), math.round(x.v4_4));
            }
        }

        /// <summary>       Returns the result of rounding each component of a <see cref="MaxMath.float8"/> down to the nearest value less or equal to the original value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 floor(float8 x)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_floor_ps(x);
            }
            else
            {
                return new float8(math.floor(x.v4_0), math.floor(x.v4_4));
            }
        }

        /// <summary>       Returns the result of rounding each component of a <see cref="MaxMath.float8"/> up to the nearest value greater or equal to the original value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 ceil(float8 x)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_ceil_ps(x);
            }
            else
            {
                return new float8(math.ceil(x.v4_0), math.ceil(x.v4_4));
            }
        }

        ///<summary>        Returns a <see cref="MaxMath.bool8"/> indicating for each component of a <see cref="MaxMath.float8"/> whether it is a finite floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 isfinite(float8 x)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_INF ? true : abs(x) < float.PositiveInfinity;
        }

        ///<summary>        Returns a <see cref="MaxMath.bool8"/> indicating for each component of a <see cref="MaxMath.float8"/> whether it is an infinite floating point value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 isinf(float8 x)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_INF ? false : (asint(x) << 1) == (math.asint(float.PositiveInfinity) << 1);
        }

        ///<summary>        Returns a <see cref="MaxMath.bool8"/> indicating for each component of a <see cref="MaxMath.float8"/> whether it is a NaN (not a number) floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 isnan(float8 x)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_NAN ? false : (asint(x) & bitmask32(31)) > 0x7F80_0000;
        }

        /// <summary>       Returns the componentwise reciprocal a <see cref="MaxMath.float8"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 rcp(float8 x)
        {
            // replaced by rcp + 2 fma instructions (Newton-Raphson) when floatmode fast is enabled
            return 1f / x;
        }

        /// <summary>       Returns the componentwise fractional parts of a <see cref="MaxMath.float8"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 frac(float8 x)
        {
            return x - floor(x);
        }

        /// <summary>       Performs a componentwise split of a <see cref="MaxMath.float8"/> into an integral part <paramref name="i"/> and a fractional part that gets returned. Both parts take the sign of the corresponding input component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 modf(float8 x, out float8 i)
        {
            return x - (i = trunc(x));
        }


        /// <summary>       Returns the result of a componentwise conversion of a <see cref="MaxMath.float8"/> from degrees to radians.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 radians(float8 x)
        {
            return x * 0.0174532925f;
        }

        /// <summary>       Returns the result of a componentwise conversion of a <see cref="MaxMath.float8"/> from radians to degrees.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 degrees(float8 x)
        {
            return x * 57.295779513f;
        }


        /// <summary>       Returns the componentwise square root of a <see cref="MaxMath.float8"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 sqrt(float8 x)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_sqrt_ps(x);
            }
            else
            {
                return new float8(math.sqrt(x.v4_0), math.sqrt(x.v4_4));
            }
        }

        /// <summary>       Returns the componentwise reciprocal square root of a <see cref="MaxMath.float8"/>    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 rsqrt(float8 x)
        {
            // replaced by rsqrt + 2 fma instructions (Newton-Raphson) when floatmode fast is enabled
            return 1f / sqrt(x);
        }

        /// <summary>       Returns the result of a componentwise linear interpolation from <paramref name="x"/> to <paramref name="y"/> using the corresponding components of the interpolation parameter <paramref name="s"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 lerp(float8 x, float8 y, float8 s)
        {
            return mad(s, y - x, x);
        }

        /// <summary>       Returns the componentwise result of normalizing a floating point value <paramref name="x"/> to a range [<paramref name="a"/>, <paramref name="b"/>]. The opposite of <see cref="lerp"/>. Equivalent to (<paramref name="x"/> - <paramref name="a"/>) / (<paramref name="b"/> - <paramref name="a"/>).     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 unlerp(float8 a, float8 b, float8 x)
        {
            return (x - a) / (b - a);
        }

        ///<summary>        Returns the componentwise result of a non-clamping linear remapping of a value <paramref name="x"/> from [<paramref name="a"/>, <paramref name="b"/>] to [<paramref name="c"/>, <paramref name="d"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 remap(float8 a, float8 b, float8 c, float8 d, float8 x)
        {
            return lerp(c, d, unlerp(a, b, x));
        }

        /// <summary>       Returns a componentwise smooth Hermite interpolation between 0.0f and 1.0f when <paramref name="x"/> is in [<paramref name="a"/>, <paramref name="b"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 smoothstep(float8 a, float8 b, float8 x)
        {
            float8 temp = saturate(unlerp(a, b, x));

            return (temp * temp) * mad(-2f, temp, 3f);
        }

        /// <summary>       Returns the result of a componentwise step function where each component is 1.0f when <paramref name="x"/> >= <paramref name="y"/> and 0.0f otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 step(float8 y, float8 x)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_and_ps(new float8(1f), Intrinsics.Xse.mm256_cmpge_ps(x, y));
            }
            else
            {
                return new float8(math.step(x.v4_0, y.v4_0), math.step(x.v4_4, y.v4_4));
            }
        }


        /// <summary>       Returns the squared length of a <see cref="MaxMath.float8"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float lengthsq(float8 x)
        {
            return dot(x, x);
        }

        /// <summary>       Returns the squared length of a <see cref="MaxMath.float8"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float length(float8 x)
        {
            return math.sqrt(lengthsq(x));
        }

        /// <summary>       Returns a normalized version of the <see cref="MaxMath.float8"/> <paramref name="x"/> by scaling it by 1 <see langword="/"/> length(<paramref name="x"/>).    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 normalize(float8 x)
        {
            return x / length(x);
        }

        /// <summary>       Returns a safe normalized version of the <see cref="MaxMath.float8"/> <paramref name="x"/> by scaling it by 1 <see langword="/"/> length(<paramref name="x"/>). Returns the given default value when 1 <see langword="/"/> length(<paramref name="x"/>) does not produce a finite number.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 normalizesafe(float8 x, float8 defaultvalue = default(float8))
        {
            float len = dot(x, x);

            return select(defaultvalue, x / math.sqrt(len), len > math.FLT_MIN_NORMAL);
        }

        /// <summary>       Returns the distance between two <see cref="MaxMath.float8"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float distance(float8 x, float8 y)
        {
            return length(y - x);
        }

        /// <summary>       Returns the distance between two <see cref="MaxMath.float8"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float distancesq(float8 x, float8 y)
        {
            return lengthsq(y - x);
        }
    }
}