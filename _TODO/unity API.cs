using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;



//public static partial class math
//{
//    
//


//    /// <summary>
//    /// Checks if the input is a power of two.
//    /// </summary>
//    /// <remarks>If x is less than or equal to zero, then this function returns false.</remarks>
//    /// <param name="x">Integer input.</param>
//    /// <returns>bool where true indicates that input was a power of two.</returns>
//    [MethodImpl(MethodImplOptions.AggressiveInlining)]
//    public static bool ispow2(int x)
//    {
//        return x > 0 && ((x & (x - 1)) == 0);
//    }
//
//    /// <summary>
//    /// Checks if each component of the input is a power of two.
//    /// </summary>
//    /// <remarks>If a component of x is less than or equal to zero, then this function returns false in that component.</remarks>
//    /// <param name="x"><see cref="int2"/> input</param>
//    /// <returns><see cref="bool2"/> where true in a component indicates the same component in the input was a power of two.</returns>
//    [MethodImpl(MethodImplOptions.AggressiveInlining)]
//    public static bool2 ispow2(int2 x)
//    {
//        return new bool2(ispow2(x.x), ispow2(x.y));
//    }
//
//
//    /// <summary>
//    /// Checks if the input is a power of two.
//    /// </summary>
//    /// <remarks>If x is less than or equal to zero, then this function returns false.</remarks>
//    /// <param name="x">Unsigned integer input.</param>
//    /// <returns>bool where true indicates that input was a power of two.</returns>
//    [MethodImpl(MethodImplOptions.AggressiveInlining)]
//    public static bool ispow2(uint x)
//    {
//        return x > 0 && ((x & (x - 1)) == 0);
//    }
//
//    /// <summary>
//    /// Checks if each component of the input is a power of two.
//    /// </summary>
//    /// <remarks>If a component of x is less than or equal to zero, then this function returns false in that component.</remarks>
//    /// <param name="x"><see cref="uint2"/> input</param>
//    /// <returns><see cref="bool2"/> where true in a component indicates the same component in the input was a power of two.</returns>
//    [MethodImpl(MethodImplOptions.AggressiveInlining)]
//    public static bool2 ispow2(uint2 x)
//    {
//        return new bool2(ispow2(x.x), ispow2(x.y));
//    }
//
//    /// <summary>Returns the componentwise result of normalizing a floating point value x to a range [a, b]. The opposite of lerp. Equivalent to (x - a) / (b - a).</summary>
//    [MethodImpl(MethodImplOptions.AggressiveInlining)]
//    public static float4 unlerp(float4 a, float4 b, float4 x) { return (x - a) / (b - a); }
//
//
//   
//    /// <summary>Returns the componentwise result of a non-clamping linear remapping of a value x from [a, b] to [c, d].</summary>
//    [MethodImpl(MethodImplOptions.AggressiveInlining)]
//    public static float4 remap(float4 a, float4 b, float4 c, float4 d, float4 x) { return lerp(c, d, unlerp(a, b, x)); }
//
//
//    
//
//    /// <summary>Returns the result of a componentwise multiply-add operation (a * b + c) on 3 int4 vectors.</summary>
//    [MethodImpl(MethodImplOptions.AggressiveInlining)]
//    public static int4 mad(int4 a, int4 b, int4 c) { return a * b + c; }
//
//
//    
//    /// <summary>Returns the result of a componentwise multiply-add operation (a * b + c) on 3 uint4 vectors.</summary>
//    [MethodImpl(MethodImplOptions.AggressiveInlining)]
//    public static uint4 mad(uint4 a, uint4 b, uint4 c) { return a * b + c; }
//
//
//    /// <summary>Returns the result of a multiply-add operation (a * b + c) on 3 long values.</summary>
//    [MethodImpl(MethodImplOptions.AggressiveInlining)]
//    public static long mad(long a, long b, long c) { return a * b + c; }
//
//
//    /// <summary>Returns the result of a multiply-add operation (a * b + c) on 3 ulong values.</summary>
//    [MethodImpl(MethodImplOptions.AggressiveInlining)]
//    public static ulong mad(ulong a, ulong b, ulong c) { return a * b + c; }
//
//
//    /// <summary>Returns the result of a componentwise multiply-add operation (a * b + c) on 3 float4 vectors.</summary>
//    [MethodImpl(MethodImplOptions.AggressiveInlining)]
//    public static float4 mad(float4 a, float4 b, float4 c) { return a * b + c; }
//
//
//    /// <summary>Returns the result of clamping the value x into the interval [a, b], where x, a and b are int values.</summary>
//    [MethodImpl(MethodImplOptions.AggressiveInlining)]
//    public static int clamp(int x, int a, int b) { return max(a, min(b, x)); }
//
//   
//    /// <summary>Returns the result of a componentwise clamping of the value x into the interval [a, b], where x, a and b are int4 vectors.</summary>
//    [MethodImpl(MethodImplOptions.AggressiveInlining)]
//    public static int4 clamp(int4 x, int4 a, int4 b) { return max(a, min(b, x)); }
//
//
//    /// <summary>Returns the result of clamping the value x into the interval [a, b], where x, a and b are uint values.</summary>
//    [MethodImpl(MethodImplOptions.AggressiveInlining)]
//    public static uint clamp(uint x, uint a, uint b) { return max(a, min(b, x)); }
//
//
//    /// <summary>Returns the result of a componentwise clamping of the value x into the interval [a, b], where x, a and b are uint4 vectors.</summary>
//    [MethodImpl(MethodImplOptions.AggressiveInlining)]
//    public static uint4 clamp(uint4 x, uint4 a, uint4 b) { return max(a, min(b, x)); }
//
//
//    /// <summary>Returns the result of clamping the value x into the interval [a, b], where x, a and b are long values.</summary>
//    [MethodImpl(MethodImplOptions.AggressiveInlining)]
//    public static long clamp(long x, long a, long b) { return max(a, min(b, x)); }
//
//    /// <summary>Returns the result of clamping the value x into the interval [a, b], where x, a and b are ulong values.</summary>
//    [MethodImpl(MethodImplOptions.AggressiveInlining)]
//    public static ulong clamp(ulong x, ulong a, ulong b) { return max(a, min(b, x)); }
//
//    
//
//    /// <summary>Returns the componentwise tangent of a float4 vector.</summary>
//    [MethodImpl(MethodImplOptions.AggressiveInlining)]
//    public static float4 tan(float4 x) { return new float4(tan(x.x), tan(x.y), tan(x.z), tan(x.w)); }
//
//
//   
//    /// <summary>Returns the componentwise hyperbolic tangent of a float4 vector.</summary>
//    [MethodImpl(MethodImplOptions.AggressiveInlining)]
//    public static float4 tanh(float4 x) { return new float4(tanh(x.x), tanh(x.y), tanh(x.z), tanh(x.w)); }
//
//
//    /// <summary>Returns the componentwise arctangent of a float4 vector.</summary>
//    [MethodImpl(MethodImplOptions.AggressiveInlining)]
//    public static float4 atan(float4 x) { return new float4(atan(x.x), atan(x.y), atan(x.z), atan(x.w)); }
//
//
//    /// <summary>Returns the componentwise 2-argument arctangent of a pair of floats4 vectors.</summary>
//    [MethodImpl(MethodImplOptions.AggressiveInlining)]
//    public static float4 atan2(float4 y, float4 x) { return new float4(atan2(y.x, x.x), atan2(y.y, x.y), atan2(y.z, x.z), atan2(y.w, x.w)); }
//
//
//   
//    /// <summary>Returns the componentwise cosine of a float4 vector.</summary>
//    [MethodImpl(MethodImplOptions.AggressiveInlining)]
//    public static float4 cos(float4 x) { return new float4(cos(x.x), cos(x.y), cos(x.z), cos(x.w)); }
//
//
//    
//
//    /// <summary>Returns the componentwise hyperbolic cosine of a float4 vector.</summary>
//    [MethodImpl(MethodImplOptions.AggressiveInlining)]
//    public static float4 cosh(float4 x) { return new float4(cosh(x.x), cosh(x.y), cosh(x.z), cosh(x.w)); }
//
//
//   
//
//    /// <summary>Returns the componentwise arccosine of a float4 vector.</summary>
//    [MethodImpl(MethodImplOptions.AggressiveInlining)]
//    public static float4 acos(float4 x) { return new float4(acos(x.x), acos(x.y), acos(x.z), acos(x.w)); }
//
//
//   
//    /// <summary>Returns the componentwise sine of a float4 vector.</summary>
//    [MethodImpl(MethodImplOptions.AggressiveInlining)]
//    public static float4 sin(float4 x) { return new float4(sin(x.x), sin(x.y), sin(x.z), sin(x.w)); }
//
//    /// <summary>Returns the componentwise hyperbolic sine of a float4 vector.</summary>
//    [MethodImpl(MethodImplOptions.AggressiveInlining)]
//    public static float4 sinh(float4 x) { return new float4(sinh(x.x), sinh(x.y), sinh(x.z), sinh(x.w)); }
//
//
//    /// <summary>Returns the componentwise arcsine of a float4 vector.</summary>
//    [MethodImpl(MethodImplOptions.AggressiveInlining)]
//    public static float4 asin(float4 x) { return new float4(asin(x.x), asin(x.y), asin(x.z), asin(x.w)); }
//
//    /// <summary>Returns the result of rounding each component of a float4 vector value to the nearest integral value.</summary>
//    [MethodImpl(MethodImplOptions.AggressiveInlining)]
//    public static float4 round(float4 x) { return new float4(round(x.x), round(x.y), round(x.z), round(x.w)); }
//
//
//    /// <summary>Returns the componentwise fractional parts of a float4 vector.</summary>
//    [MethodImpl(MethodImplOptions.AggressiveInlining)]
//    public static float4 frac(float4 x) { return x - floor(x); }
//
//
//    /// <summary>Returns the fractional part of a double value.</summary>
//    
//    /// <summary>Returns the componentwise reciprocal a float4 vector.</summary>
//    [MethodImpl(MethodImplOptions.AggressiveInlining)]
//    public static float4 rcp(float4 x) { return 1.0f / x; }
//
//
//   
//    /// <summary>Returns the componentwise sign of a float4 value. 1.0f for positive components, 0.0f for zero components and -1.0f for negative components.</summary>
//    [MethodImpl(MethodImplOptions.AggressiveInlining)]
//    public static float4 sign(float4 x) { return new float4(sign(x.x), sign(x.y), sign(x.z), sign(x.w)); }
//
//
//    /// <summary>Returns the componentwise result of raising x to the power y.</summary>
//    [MethodImpl(MethodImplOptions.AggressiveInlining)]
//    public static float4 pow(float4 x, float4 y) { return new float4(pow(x.x, y.x), pow(x.y, y.y), pow(x.z, y.z), pow(x.w, y.w)); }
//
//
//    /// <summary>Returns the componentwise base-e exponential of x.</summary>
//    [MethodImpl(MethodImplOptions.AggressiveInlining)]
//    public static float4 exp(float4 x) { return new float4(exp(x.x), exp(x.y), exp(x.z), exp(x.w)); }
//
//
//    
//    /// <summary>Returns the componentwise base-2 exponential of x.</summary>
//    [MethodImpl(MethodImplOptions.AggressiveInlining)]
//    public static float4 exp2(float4 x) { return new float4(exp2(x.x), exp2(x.y), exp2(x.z), exp2(x.w)); }
//
//
//    
//    /// <summary>Returns the componentwise base-10 exponential of x.</summary>
//    [MethodImpl(MethodImplOptions.AggressiveInlining)]
//    public static float4 exp10(float4 x) { return new float4(exp10(x.x), exp10(x.y), exp10(x.z), exp10(x.w)); }
//
//
//    /// <summary>Returns the componentwise natural logarithm of a float4 vector.</summary>
//    [MethodImpl(MethodImplOptions.AggressiveInlining)]
//    public static float4 log(float4 x) { return new float4(log(x.x), log(x.y), log(x.z), log(x.w)); }
//
//
//   
//    /// <summary>Returns the componentwise base-2 logarithm of a float4 vector.</summary>
//    [MethodImpl(MethodImplOptions.AggressiveInlining)]
//    public static float4 log2(float4 x) { return new float4(log2(x.x), log2(x.y), log2(x.z), log2(x.w)); }
//
//
//    
//    /// <summary>Returns the componentwise base-10 logarithm of a float4 vector.</summary>
//    [MethodImpl(MethodImplOptions.AggressiveInlining)]
//    public static float4 log10(float4 x) { return new float4(log10(x.x), log10(x.y), log10(x.z), log10(x.w)); }
//
//
//    
//    /// <summary>Returns the componentwise floating point remainder of x/y.</summary>
//    [MethodImpl(MethodImplOptions.AggressiveInlining)]
//    public static float4 fmod(float4 x, float4 y) { return new float4(x.x % y.x, x.y % y.y, x.z % y.z, x.w % y.w); }
//
//
//
//    
//
//   
//    /// <summary>Returns a normalized version of the float4 vector x by scaling it by 1 / length(x).</summary>
//    [MethodImpl(MethodImplOptions.AggressiveInlining)]
//    public static float4 normalize(float4 x) { return rsqrt(dot(x, x)) * x; }
//
//
//    /// <summary>Returns a normalized version of the double2 vector x by scaling it by 1 / length(x).</summary>
//   
//    /// <summary>
//    /// Returns a safe normalized version of the float4 vector x by scaling it by 1 / length(x).
//    /// Returns the given default value when 1 / length(x) does not produce a finite number.
//    /// </summary>
//    [MethodImpl(MethodImplOptions.AggressiveInlining)]
//    static public float4 normalizesafe(float4 x, float4 defaultvalue = new float4())
//    {
//        float len = math.dot(x, x);
//        return math.select(defaultvalue, x * math.rsqrt(len), len > FLT_MIN_NORMAL);
//    }
//
//    /// <summary>Returns the length of a float4 vector.</summary>
//    [MethodImpl(MethodImplOptions.AggressiveInlining)]
//    public static float length(float4 x) { return sqrt(dot(x, x)); }
//
//
//    
//    /// <summary>Returns the squared length of a float4 vector.</summary>
//    [MethodImpl(MethodImplOptions.AggressiveInlining)]
//    public static float lengthsq(float4 x) { return dot(x, x); }
//
//
//  
//    /// <summary>Returns the distance between two float4 vectors.</summary>
//    [MethodImpl(MethodImplOptions.AggressiveInlining)]
//    public static float distance(float4 x, float4 y) { return length(y - x); }
//
//
//    /// <summary>Returns the distance between two float4 vectors.</summary>
//    [MethodImpl(MethodImplOptions.AggressiveInlining)]
//    public static float distancesq(float4 x, float4 y) { return lengthsq(y - x); }
//
//
//   
//
//    /// <summary>Returns a componentwise smooth Hermite interpolation between 0.0f and 1.0f when x is in [a, b].</summary>
//    [MethodImpl(MethodImplOptions.AggressiveInlining)]
//    public static float4 smoothstep(float4 a, float4 b, float4 x)
//    {
//        var t = saturate((x - a) / (b - a));
//        return t * t * (3.0f - (2.0f * t));
//    }
//
//    /// <summary>Returns true if any components of the input int4 vector is non-zero, false otherwise.</summary>
//    [MethodImpl(MethodImplOptions.AggressiveInlining)]
//    public static bool any(int4 x) { return x.x != 0 || x.y != 0 || x.z != 0 || x.w != 0; }
//
//
//    /// <summary>Returns true if any components of the input uint4 vector is non-zero, false otherwise.</summary>
//    [MethodImpl(MethodImplOptions.AggressiveInlining)]
//    public static bool any(uint4 x) { return x.x != 0 || x.y != 0 || x.z != 0 || x.w != 0; }
//
//
//    /// <summary>Returns true if any component of the input float4 vector is non-zero, false otherwise.</summary>
//    [MethodImpl(MethodImplOptions.AggressiveInlining)]
//    public static bool any(float4 x) { return x.x != 0.0f || x.y != 0.0f || x.z != 0.0f || x.w != 0.0f; }
//
//
//    /// <summary>Returns true if all components of the input int4 vector are non-zero, false otherwise.</summary>
//    [MethodImpl(MethodImplOptions.AggressiveInlining)]
//    public static bool all(int4 x) { return x.x != 0 && x.y != 0 && x.z != 0 && x.w != 0; }
//
//
//  
//    /// <summary>Returns true if all components of the input uint4 vector are non-zero, false otherwise.</summary>
//    [MethodImpl(MethodImplOptions.AggressiveInlining)]
//    public static bool all(uint4 x) { return x.x != 0 && x.y != 0 && x.z != 0 && x.w != 0; }
//
//    /// <summary>Returns true if all components of the input float4 vector are non-zero, false otherwise.</summary>
//    [MethodImpl(MethodImplOptions.AggressiveInlining)]
//    public static bool all(float4 x) { return x.x != 0.0f && x.y != 0.0f && x.z != 0.0f && x.w != 0.0f; }
//
//
//    /// <summary>Returns the result of a componentwise step function where each component is 1.0f when x >= y and 0.0f otherwise.</summary>
//    [MethodImpl(MethodImplOptions.AggressiveInlining)]
//    public static float4 step(float4 y, float4 x) { return select(float4(0.0f), float4(1.0f), x >= y); }
//
//
//    /// <summary>Given an incident vector i and a normal vector n, returns the reflection vector r = i - 2.0f * dot(i, n) * n.</summary>
//    [MethodImpl(MethodImplOptions.AggressiveInlining)]
//    public static float4 reflect(float4 i, float4 n) { return i - 2f * n * dot(i, n); }
//
//
//    /// <summary>Returns the refraction vector given the incident vector i, the normal vector n and the refraction index eta.</summary>
//    [MethodImpl(MethodImplOptions.AggressiveInlining)]
//    public static float4 refract(float4 i, float4 n, float eta)
//    {
//        float ni = dot(n, i);
//        float k = 1.0f - eta * eta * (1.0f - ni * ni);
//        return select(0.0f, eta * i - (eta * ni + sqrt(k)) * n, k >= 0);
//    }
//
//
//
//    /// <summary>
//    /// Compute vector projection of a onto b.
//    /// </summary>
//    /// <remarks>
//    /// Some finite vectors a and b could generate a non-finite result. This is most likely when a's components
//    /// are very large (close to Single.MaxValue) or when b's components are very small (close to FLT_MIN_NORMAL).
//    /// In these cases, you can call <see cref="projectsafe(Unity.Mathematics.float4,Unity.Mathematics.float4,Unity.Mathematics.float4)"/>
//    /// which will use a given default value if the result is not finite.
//    /// </remarks>
//    /// <param name="a">Vector to project.</param>
//    /// <param name="b">Non-zero vector to project onto.</param>
//    /// <returns>Vector projection of a onto b.</returns>
//    [MethodImpl(MethodImplOptions.AggressiveInlining)]
//    public static float4 project(float4 a, float4 b)
//    {
//        return (dot(a, b) / dot(b, b)) * b;
//    }
//
//    /// <summary>
//    /// Compute vector projection of a onto b. If result is not finite, then return the default value instead.
//    /// </summary>
//    /// <remarks>
//    /// This function performs extra checks to see if the result of projecting a onto b is finite. If you know that
//    /// your inputs will generate a finite result or you don't care if the result is finite, then you can call
//    /// <see cref="project(Unity.Mathematics.float4,Unity.Mathematics.float4)"/> instead which is faster than this
//    /// function.
//    /// </remarks>
//    /// <param name="a">Vector to project.</param>
//    /// <param name="b">Non-zero vector to project onto.</param>
//    /// <param name="defaultValue">Default value to return if projection is not finite.</param>
//    /// <returns>Vector projection of a onto b or the default value.</returns>
//    [MethodImpl(MethodImplOptions.AggressiveInlining)]
//    public static float4 projectsafe(float4 a, float4 b, float4 defaultValue = new float4())
//    {
//        var proj = project(a, b);
//
//        return select(defaultValue, proj, all(isfinite(proj)));
//    }
//
//    /// <summary>Conditionally flips a vector n to face in the direction of i. Returns n if dot(i, ng) &lt; 0, -n otherwise.</summary>
//    [MethodImpl(MethodImplOptions.AggressiveInlining)]
//    public static float4 faceforward(float4 n, float4 i, float4 ng) { return select(n, -n, dot(ng, i) >= 0.0f); }
//
//    /// <summary>Returns the componentwise sine and cosine of the input float4 vector x through the out parameters s and c.</summary>
//    [MethodImpl(MethodImplOptions.AggressiveInlining)]
//    public static void sincos(float4 x, out float4 s, out float4 c) { s = sin(x); c = cos(x); }
//
//
//    /// <summary>Returns component-wise number of 1-bits in the binary representation of an int4 vector. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.</summary>
//    /// <param name="x">Number in which to count bits.</param>
//    /// <returns>int4 containing number of bits set to 1 within each component of x.</returns>
//    [MethodImpl(MethodImplOptions.AggressiveInlining)]
//    public static int4 countbits(int4 x) { return countbits((uint4)x); }
//
//
//    /// <summary>Returns the componentwise number of leading zeros in the binary representations of an int4 vector.</summary>
//    [MethodImpl(MethodImplOptions.AggressiveInlining)]
//    public static int4 lzcnt(int4 x) { return int4(lzcnt(x.x), lzcnt(x.y), lzcnt(x.z), lzcnt(x.w)); }
//
//
//    /// <summary>Returns the componentwise number of leading zeros in the binary representations of an int4 vector.</summary>
//    [MethodImpl(MethodImplOptions.AggressiveInlining)]
//    public static int4 tzcnt(int4 v) { return int4(tzcnt(v.x), tzcnt(v.y), tzcnt(v.z), tzcnt(v.w)); }
//
//
//    /// <summary>Returns the result of performing a componentwise reversal of the bit pattern of an int4 vector.</summary>
//    [MethodImpl(MethodImplOptions.AggressiveInlining)]
//    public static int4 reversebits(int4 x) { return (int4)reversebits((uint4)x); }
//
//
//    /// <summary>Returns the componentwise result of rotating the bits of an int4 left by bits n.</summary>
//    [MethodImpl(MethodImplOptions.AggressiveInlining)]
//    public static int4 rol(int4 x, int n) { return (int4)rol((uint4)x, n); }
//
//    /// <summary>Returns the componentwise result of rotating the bits of an int4 right by bits n.</summary>
//    [MethodImpl(MethodImplOptions.AggressiveInlining)]
//    public static int4 ror(int4 x, int n) { return (int4)ror((uint4)x, n); }
//
//
//
//    /// <summary>Returns the result of a componentwise calculation of the smallest power of two greater than or equal to the input.</summary>
//    [MethodImpl(MethodImplOptions.AggressiveInlining)]
//    public static int4 ceilpow2(int4 x)
//    {
//        x -= 1;
//        x |= x >> 1;
//        x |= x >> 2;
//        x |= x >> 4;
//        x |= x >> 8;
//        x |= x >> 16;
//        return x + 1;
//    }
//
//
//
//    /// <summary>
//    /// Computes the componentwise ceiling of the base-2 logarithm of x.
//    /// </summary>
//    /// <remarks>
//    /// Components of x must be greater than 0, otherwise the result for that component is undefined.
//    /// </remarks>
//    /// <param name="x"><see cref="int4"/> to be used as input.</param>
//    /// <returns>Componentwise ceiling of the base-2 logarithm of x.</returns>
//    [MethodImpl(MethodImplOptions.AggressiveInlining)]
//    public static int4 ceillog2(int4 x)
//    {
//        return new int4(ceillog2(x.x), ceillog2(x.y), ceillog2(x.z), ceillog2(x.w));
//    }
//
//    /// <summary>
//    /// Computes the componentwise floor of the base-2 logarithm of x.
//    /// </summary>
//    /// <remarks>Components of x must be greater than zero, otherwise the result of the component is undefined.</remarks>
//    /// <param name="x"><see cref="int4"/> to be used as input.</param>
//    /// <returns>Componentwise floor of base-2 logarithm of x.</returns>
//    [MethodImpl(MethodImplOptions.AggressiveInlining)]
//    public static int4 floorlog2(int4 x)
//    {
//        return new int4(floorlog2(x.x), floorlog2(x.y), floorlog2(x.z), floorlog2(x.w));
//    }
//    /// <summary>Returns the result of a componentwise conversion of a float4 vector from degrees to radians.</summary>
//    [MethodImpl(MethodImplOptions.AggressiveInlining)]
//    public static float4 radians(float4 x) { return x * 0.0174532925f; }
//
//
//    /// <summary>Returns the result of a componentwise conversion of a double4 vector from radians to degrees.</summary>
//    [MethodImpl(MethodImplOptions.AggressiveInlining)]
//    public static float4 degrees(float4 x) { return x * 57.295779513f; }
//
//    /// <summary>Returns the floating point representation of a half-precision floating point vector.</summary>
//    [MethodImpl(MethodImplOptions.AggressiveInlining)]
//    public static float4 f16tof32(uint4 x)
//    {
//        const uint shifted_exp = (0x7c00 << 13);
//        uint4 uf = (x & 0x7fff) << 13;
//        uint4 e = uf & shifted_exp;
//        uf += (127 - 15) << 23;
//        uf += select(0, (128u - 16u) << 23, e == shifted_exp);
//        uf = select(uf, asuint(asfloat(uf + (1 << 23)) - 6.10351563e-05f), e == 0);
//        uf |= (x & 0x8000) << 16;
//        return asfloat(uf);
//    }
//
//
//    /// <summary>Returns the result of a componentwise conversion of a float4 vector to its nearest half-precision floating point representation.</summary>
//    [MethodImpl(MethodImplOptions.AggressiveInlining)]
//    public static uint4 f32tof16(float4 x)
//    {
//        const int infinity_32 = 255 << 23;
//        const uint msk = 0x7FFFF000u;
//
//        uint4 ux = asuint(x);
//        uint4 uux = ux & msk;
//        uint4 h = (uint4)(asint(min(asfloat(uux) * 1.92592994e-34f, 260042752.0f)) + 0x1000) >> 13;   // Clamp to signed infinity if overflowed
//        h = select(h, select(0x7c00u, 0x7e00u, (int4)uux > infinity_32), (int4)uux >= infinity_32);   // NaN->qNaN and Inf->Inf
//        return h | (ux & ~msk) >> 16;
//    }
//}
