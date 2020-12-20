using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        ///		<summary>       Returns the componentwise tangent of a float8 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 tan(float8 x) 
        { 
            return new float8(math.tan(x.v4_0), math.tan(x.v4_4)); 
        }
        
        ///		<summary>       Returns the componentwise hyperbolic tangent of a float8 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 tanh(float8 x)
        {
            return new float8(math.tanh(x.v4_0), math.tanh(x.v4_4));
        }

        ///		<summary>       Returns the componentwise arctangent of a float8 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 atan(float8 x)
        {
            return new float8(math.atan(x.v4_0), math.atan(x.v4_4));
        }

        ///		<summary>       Returns the componentwise 2-argument arctangent of a pair of floats4 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 atan2(float8 y, float8 x)
        {
            return new float8(math.atan2(y.v4_0, x.v4_0), math.atan2(y.v4_4, x.v4_4));
        }

        ///		<summary>       Returns the componentwise cosine of a float8 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 cos(float8 x)
        {
            return new float8(math.cos(x.v4_0), math.cos(x.v4_4));
        }

        ///		<summary>       Returns the componentwise hyperbolic cosine of a float8 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 cosh(float8 x)
        {
            return new float8(math.cosh(x.v4_0), math.cosh(x.v4_4));
        }

        ///		<summary>       Returns the componentwise arccosine of a float8 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 acos(float8 x)
        {
            return new float8(math.acos(x.v4_0), math.acos(x.v4_4));
        }

        ///		<summary>       Returns the componentwise sine of a float8 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 sin(float8 x)
        {
            return new float8(math.sin(x.v4_0), math.sin(x.v4_4));
        }

        ///		<summary>       Returns the componentwise hyperbolic sine of a float8 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 sinh(float8 x)
        {
            return new float8(math.sinh(x.v4_0), math.sinh(x.v4_4));
        }

        ///     <summary>       Returns the componentwise arcsine of a float8 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 asin(float8 x)
        {
            return new float8(math.asin(x.v4_0), math.asin(x.v4_4));
        }

        ///     <summary>       Returns the componentwise sine and cosine of the input float8 vector x through the out parameters s and c.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void sincos(float8 x, out float8 s, out float8 c)
        {
            math.sincos(x.v4_0, out float4 sinLo, out float4 cosLo);
            math.sincos(x.v4_4, out float4 sinHi, out float4 cosHi);

            s = new float8(sinLo, sinHi);
            c = new float8(cosLo, cosHi);
        }


        ///		<summary>       Returns the componentwise result of raising x to the power y.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 pow(float8 x, float8 y)
        {
            return new float8(math.pow(x.v4_0, y.v4_0), math.pow(x.v4_4, y.v4_4));
        }


        ///		<summary>       Returns the componentwise base-e exponential of x.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 exp(float8 x)
        {
            return new float8(math.exp(x.v4_0), math.exp(x.v4_4));
        }

        ///		<summary>       Returns the componentwise base-2 exponential of x.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 exp2(float8 x)
        {
            return new float8(math.exp2(x.v4_0), math.exp2(x.v4_4));
        }

        ///		<summary>       Returns the componentwise base-10 exponential of x.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 exp10(float8 x)
        {
            return new float8(math.exp10(x.v4_0), math.exp10(x.v4_4));
        }


        ///		<summary>       Returns the componentwise natural logarithm of a float8 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 log(float8 x)
        {
            return new float8(math.log(x.v4_0), math.log(x.v4_4));
        }

        ///		<summary>       Returns the componentwise base-2 logarithm of a float8 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 log2(float8 x)
        {
            return new float8(math.log2(x.v4_0), math.log2(x.v4_4));
        }

        ///		<summary>       Returns the componentwise base-10 logarithm of a float8 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 log10(float8 x)
        {
            return new float8(math.log10(x.v4_0), math.log10(x.v4_4));
        }
    }
}