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
//   
//    
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
//
//   
//    
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
//    
//
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
//}
