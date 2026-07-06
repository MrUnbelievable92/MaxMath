# MaxMath
MaxMath is the most powerful and extensive SIMD math library available to Unity developers. Built on top of Unity.Mathematics and utilizing Unity.Burst, it introduces the following key features:

- **Support For All Primitive Data Types:** MaxMath adds support for `(s)byte`, `(u)short`, and `(u)long` vectors and matrices. These data types come with specialized overloads for all functions in Unity.Mathematics. Additionally, specialized `Random8/16/32/64/128` types are available for efficient pseudo-random number generation.
- **Wider Vectors With Full Hardware Support:** Vector types are expanded to 256 bits, enabling types like `byte32`, `short16`, `int8`, and `float8`. This allows you to leverage the full potential of SIMD computation.
- **Many Additional Functions:** MaxMath includes a massive library of mathematical functions not found in Unity.Mathematics, with about five times as many highly optimized functions at your disposal. Each function is fully documented with XML annotations. A full list is provided further below.
- **Exotic Data Types:** MaxMath introduces data types such as `(U)Int128` (scalar only), 128-bit `quadruple` precision floats (scalar only), and 8-bit `quarter` precision floats (in both scalar and vector forms). Additionally, `Divider<T>` offers highly optimized integer division operations, extending and outperforming specialized libraries like libdivide.
- **Written Entirely With Hardware Intrinsics:** MaxMath guarantees optimal performance by utilizing specialized CPU instructions for both ARM and x86 ISAs, while abstracting these complexities away from the user entirely.
- **Extends The Burst Compiler:** MaxMath integrates deeply with Unity.Burst and LLVM, leveraging `Unity.Burst.CompilerServices.Constant.IsConstantExpression<T>()` to include code typically only found in optimizing compilers. This functionality allows MaxMath to choose more optimized code paths at compile time, and users can influence this behavior via the optional `Promise` enum parameter available in many functions. MaxMath also systematically annotates virtually every operation with rich semantic postconditions communicated direcly to Burst via `Unity.Burst.CompilerServices.Hint.Assume()`, preserving mathematical and bit-level properties across opaque implementations so LLVM can continue propagating optimization opportunities beyond abstraction boundaries.
- **Easy To Use:** MaxMath is just as easy to use as Unity.Mathematics. It supports features like `implicit` and `explicit` type conversions, making it seamless for you to use if you expect typical C# behavior of primitive types.
- **Extensive Test Coverage:** MaxMath is backed by 250,000 lines of unit tests for its 750,000 lines of code, as well as `DEBUG` only runtime checks where appropriate, together ensuring it is _production ready_.

## Why MaxMath over Unity.Mathematics?
Prior to version 3.0, MaxMath served as a supplementary library to Unity.Mathematics. Starting with 3.0, it is a drop-in replacement/wrapper for Unity.Mathematics, fully compatible while extending it with additional MaxMath functionality. Because MaxMath had been developed as an extension library for several years, this architectural change was among the most difficult design decisions in the project's history. Nevertheless, it ultimately became clear that a wrapper architecture was necessary for the following reasons:

MaxMath builds on Unity.Mathematics with additional functionality and numerous performance improvements (See the 3.0 patch notes for the changes). Several bugs in Unity.Mathematics have not been fixed for multiple years, particularly with regards to `half`.

MaxMath is actively maintained, with recent releases and public GitHub Issues/Discussions for feedback. By comparison, Unity.Mathematics still shows a substantial amount of open issues and feature requests in its public repository, and its README notes that pull requests are not accepted.

Given its development history, it appears unlikely that Unity.Mathematics will take advantage of the Unity ecosystem's migration to the CoreCLR scripting runtime and the direct access to hardware intrinsics this enables, limiting its long-term potential for managed C# performance. Likewise, it is unlikely to adopt newer C# language features, such as the generalized shift operators introduced in C# 11, where the shift count is no longer restricted to `int`.

# Types

<details>
<summary>Integer</summary>

![alt text](https://i.imgur.com/fnQckrB.png)

![alt text](https://i.imgur.com/Yi2EPbK.png)

![alt text](https://i.imgur.com/6WcYu0z.png)

![alt text](https://i.imgur.com/NanVlIA.png)

![alt text](https://i.imgur.com/ktNzIfD.png)

![alt text](https://i.imgur.com/BAkEEfb.png)

![alt text](https://i.imgur.com/j4aKCjH.png)

![alt text](https://i.imgur.com/e6IA8OI.png)

![alt text](https://i.imgur.com/d3h7RA5.png)

![alt text](https://i.imgur.com/Uthhn88.png)

</details>

<details>
<summary>Floating Point</summary>
  
![alt text](https://i.imgur.com/IPguC5S.png)
  
![alt text](https://i.imgur.com/hAyWhlR.png)
  
![alt text](https://i.imgur.com/RzEmCI1.png)
  
![alt text](https://i.imgur.com/CkM9G3E.png)
  
![alt text](https://i.imgur.com/WYpL71r.png)
  
</details>

<details>
<summary>Geometry</summary>
  
![alt text](https://i.imgur.com/X3voW3T.png)
  
</details>

<details>
<summary>Miscellaneous</summary>
  
![alt text](https://i.imgur.com/ri7JP3Q.png)
  
![alt text](https://i.imgur.com/cyVjd6t.png)
  
![alt text](https://i.imgur.com/IHGzZIR.png)
  
</details>

# Functions

**Note**: The function signatures (but not their names), parameter names, and descriptions shown below have been intentionally simplified to keep this catalog concise and easy to browse. They do not reflect the naming conventions or XML documentation used throughout MaxMath, which provide substantially more descriptive parameter names, detailed explanations, and full IntelliSense support in IDEs (see the example below). 

This section is intended solely as a high-level overview of the available functionality rather than a replacement for the library's built-in documentation. 

In addition, many functions have an optional `enum Promise` parameter for optimized code paths not listed here. 

Each operation is available for all applicable scalar, vector, and matrix types.

An example for XML documentation used in MaxMath:
![alt text](https://i.imgur.com/srZkJNy.png)

<details>
<summary>Arithmetic</summary><blockquote>

<details>
<summary>Miscellaneous</summary><blockquote>
<ul>
<li><code>addsub(a, b))</code> - alternating add/subtract</li>
<li><code>subadd(a, b))</code> - alternating subtract/add</li>
<li><code>avg([integer type] a, [integer type] b))</code> - rounded average</li>
<li><code>avg([floating point type] a, [floating point type] b))</code></li>
<li><code>divrem(a, b, out remainder))</code></li>
<li><code>square(a))</code></li>
<li><code>mad(a, b, c))</code> - multiply-add</li>
<li><code>msub(a, b, c))</code> - multiply-subtract</li>
<li><code>maddsub(a, b, c))</code> - alternating multiply-add/subtract</li>
<li><code>msubadd(a, b, c))</code> - alternating multiply-add/subtract</li>
</ul>
</blockquote></details>

<details>
<summary>Floating Point</summary><blockquote>
<ul>
<li><code>sqrt(a)</code></li>
<li><code>rsqrt(a)</code> - 1 / sqrt(a)</li>
<li><code>fastrsqrt(a)</code> - fast-approximate rsqrt(a)</li>
<li><code>cbrt(a)</code></li>
<li><code>rcbrt(a)</code> - 1 / cbrt(a)</li>
<li><code>hypot(a, b)</code> - sqrt(a² + b²) without overflow</li>
<li><code>pow(a, [floating point type] b)</code></li>
<li><code>pow(a, [integer type] b)</code> - optimized for integer exponents</li>
<li><code>exp(a)</code></li>
<li><code>exp2([floating point type] a)</code></li>
<li><code>exp2([integer type] a)</code> - optimized for integer arguments</li>
<li><code>exp10(a)</code></li>
<li><code>log(a)</code></li>
<li><code>log2(a)</code></li>
<li><code>log10(a)</code></li>
<li><code>log(a, b)</code> - logarithm with arbitrary base</li>
<li><code>frac(a)</code> - fractional part</li>
<li><code>modf(a, out i)</code> - split into fractional and integer parts</li>
<li><code>rcp(a)</code></li>
<li><code>fastrcp(a)</code> - fast-approximate rcp(a)</li>
<li><code>fmod(a, b)</code> - a % b</li>
<li><code>round(a)</code></li>
<li><code>trunc(a)</code></li>
<li><code>floor(a)</code></li>
<li><code>ceil(a)</code></li>
<li><code>div(a, b, [bool] fast)</code> - (fast-approximate) division</li>
<li><code>dad(a, b, c, [bool] fast)</code> - fast-approximate) divide-add</li>
<li><code>dsub(a, b, c, [bool] fast)</code> - fast-approximate) divide-subtract</li>
<li><code>daddsub(a, b, c, [bool] fast)</code> - fast-approximate) alternating divide-add/subtract</li>
<li><code>dsubadd(a, b, c, [bool] fast)</code> - fast-approximate) alternating divide-add/subtract</li>
</ul>
</blockquote></details>

<details>
<summary>Integer</summary><blockquote>
<ul>
<li><code>mulwide(a, b, out lo, out hi)</code> - full precision multiplication</li>
<li><code>isdivisible(a, b)</code> - a % b == 0</li>
<li><code>intsqrt(a)</code></li>
<li><code>intcbrt(a)</code></li>
<li><code>inthypot(a, b)</code> - intsqrt(a² + b²) without overflow</li>
<li><code>intpow(a, b)</code></li>
<li><code>floorpow2(a)</code> - round to nearest smaller power of 2</li>
<li><code>ceilpow2(a)</code> - round to nearest greater power of 2</li>
<li><code>intlog10(a)</code></li>
<li><code>intlog2(a)</code></li>
<li><code>floorlog2(a)</code> - intlog2(floorpow2(a))</li>
<li><code>ceillog2(a)</code> - intlog2(ceilpow2(a))</li>
<li><code>factorial(a)</code></li>
<li><code>gcd(a, b)</code> - greatest common divisor</li>
<li><code>lcm(a, b)</code> - least common multiple</li>
<li><code>comb(a, b)</code> - binomial coefficient</li>
<li><code>perm(a, b)</code> - number of k-permutations of n / ordered selections without repetition and with order</li>
</ul>
</blockquote></details>

<details>
<summary>Saturation Arithmetic (returns type.MinValue/MaxValue in case of overflow)</summary><blockquote>
<ul>
<li><code>addsaturated(a, b)</code></li>
<li><code>subsaturated(a, b)</code></li>
<li><code>mulsaturated(a, b)</code></li>
<li><code>divsaturated(a, b)</code></li>
<li><code>csumsaturated(a, b)</code> - column sum</li>
<li><code>cprodsaturated(a, b)</code> - column product</li>
<li><code>to[any type]saturated([any type] a)</code> - cast the input to the return type, saturated to Min/MaxValue in case of overflow</li>
</ul>
</blockquote></details>

<details>
<summary>Sequences</summary><blockquote>
<ul>
<li><code>nextgreater(a)</code> - next greater representable value, primarily intended for floating point values</li>
<li><code>nextsmaller(a)</code> - next smaller representable value, primarily intended for floating point values</li>
<li><code>nexttoward(a, b)</code> - next representable value from a towards b</li>
<li><code>roundmultiple(a, b)</code> - among all multiples of b, returns the nearest one to a</li>
<li><code>floormultiple(a, b)</code> - among all multiples of b, returns the nearest smaller one to a</li>
<li><code>truncmultiple(a, b)</code> - among all multiples of b, returns the nearest greater one to a</li>
<li><code>truncmultiple(a, b)</code> - among all multiples of b, returns the nearest one to a towards 0</li>
</ul>
</blockquote></details>

<details>
<summary>Sign Manipulation</summary><blockquote>
<ul>
<li><code>abs(a)</code></li>
<li><code>nabs(a)</code> - -abs(a)</li>
<li><code>chgsign(a, b)</code> - b < 0 ? -a : a</li>
<li><code>copysign(a, b)</code> - copy the sign of b to a</li>
<li><code>sign(a)</code> - if (a == 0) return 0; else return a < 0 ? -1 : 1;</li>
</ul>
</blockquote></details>

<details>
<summary>Vector Reduction</summary><blockquote>
<ul>
<li><code>csum(a)</code> - sum of all vector elements</li>
<li><code>cprod(a)</code> - product of all vector elements</li>
<li><code>cavg([integer type] a)</code> - the ceiling of the average of all vector elements</li>
<li><code>cavg([floating point type] a)</code> - the true average of all vector elements</li>
<li><code>dot(a, b)</code></li>
<li><code>sad(a, b)</code> - Sum of Absolute Differences of corresponding vector components</li>
</ul>
</blockquote></details>
</details></blockquote>

<details>
<summary>Bitwise</summary><blockquote>
<details>
<summary>Bitfields</summary><blockquote>
<ul>
<li><code>bitfield(params a)</code> - pack multiple values into one larger integer</li>
<li><code>bitfield[numBits](a, b)</code> - create a bitfield of `a` consecutive 1-bits starting at bit index b</li>
<li><code>bitmask(a)</code> - create a bitfield from a boolean vector</li>
<li><code>bits_extract(a, b, c)</code> - extract c number of bits from a starting at index b</li>
<li><code>lzmask(a)</code> - create a mask from leading zeros of a</li>
<li><code>l1mask(a)</code> - create a mask from leading ones of a</li>
<li><code>tzmask(a)</code> - create a mask from trailing zeros of a</li>
<li><code>t1mask(a)</code> - create a mask from trailing ones of a</li>
<li><code>bits_masktolowest(a)</code> - mask up to lowest 1-bit (inclusive)</li>
<li><code>bits_masktolowest0(a)</code> - mask up to lowest 0-bit (inclusive)</li>
<li><code>bits_maskfromlowest(a)</code> - mask from lowest 1-bit (inclusive)</li>
<li><code>bits_maskfromlowest0(a)</code> - mask from lowest 0-bit (inclusive)</li>
<li><code>bits_extractparallel(a, b)</code> - pack the bits from a selected by the bitmask b into contiguous low-order bits</li>
<li><code>bits_depositparallel(a, b)</code> - inverse of bits_extractparallel; scatter contiguous low-order bits from a into the positions selected by the bitmask b</li>
<li><code>tobool[bits](a)</code> - boolean vector from a bitmask</li>
<li><code>signextend(a, b)</code> - treat a as an integer with b bits and sign-extend it</li>
</ul>
</blockquote></details>

<details>
<summary>Testing Bits</summary><blockquote>
<ul>
<li><code>testbit(a, b)</code> - test whether bit b of a is set</li>
<li><code>testbitset(ref a, b)</code> - test whether bit b of a is set and set it to 1 afterwards</li>
<li><code>testbitreset(ref a, b)</code> - test whether bit b of a is set and set it to 0 afterwards</li>
<li><code>testbitflip(ref a, b)</code> - test whether bit b of a is set and set it to its opposite afterwards</li>
</ul>
</blockquote></details>

<details>
<summary>Boolean Operations</summary><blockquote>
<ul>
<li><code>andnot(a, b)</code> - a & ~b</li>
<li><code>bits_select(a, b, c)</code> - per-bit conditional select</li>
</ul>
</blockquote></details>

<details>
<summary>Counting Bits</summary><blockquote>
<ul>
<li><code>countbits(a)</code> - count bits set to 1</li>
<li><code>countzerobits(a)</code> - count bits set to 0</li>
<li><code>lzcnt(a)</code> - count leading bits set to 0</li>
<li><code>l1cnt(a)</code> - count leading bits set to 1</li>
<li><code>tzcnt(a)</code> - count trailing bits set to 0</li>
<li><code>t1cnt(a)</code> - count trailing bits set to 1</li>
<li><code>parityeven(a)</code> - test whether the number of set bits in a is even</li>
<li><code>parityodd(a)</code> - test whether the number of set bits in a is odd</li>
</ul>
</blockquote></details>

<details>
<summary>Bitwise Transformations</summary><blockquote>
<ul>
<li><code>shl/shrl/shra(a, [vector integer type] b)</code> - per-element logical/arithmetic bit shift left/right of vector types</li>
<li><code>rol/ror(a, [scalar integer type] b)</code> - uniform bitwise rotate left/right</li>
<li><code>rol/ror([vector integer type] a, [vector integer type] b)</code> - bitwise per-element rotate left/right</li>
<li><code>reversebits(a)</code></li>
<li><code>reversebytes(a)</code></li>
<li><code>bits_zerohigh(a, b)</code> - set all bits in a to 0 starting at index b</li>
<li><code>lzfill(a)</code> - set leading zeros to 1</li>
<li><code>tzfill(a)</code> - set trailing zeros to 1</li>
<li><code>l1clear(a)</code> - set leading ones to 0</li>
<li><code>t1clear(a)</code> - set trailing ones to 0</li>
<li><code>bits_extractlowest(a)</code> - extract only the lowest 1-bit as a 1-bit</li>
<li><code>bits_extractlowest0(a)</code> - extract only the lowest 0-bit as a 1-bit</li>
<li><code>bits_setlowest(a)</code> - set the lowest 0-bit to 1</li>
<li><code>bits_resetlowest(a)</code> - set the lowest 1-bit to 0</li>
<li><code>bits_surroundlowest(a)</code> - set the lowest 1-bit to 0 and all other bits to 1</li>
<li><code>bits_surroundlowest0(a)</code> - set the lowest 0-bit to 0 and all other bits to 1</li>
</ul>
</blockquote></details>

<details>
<summary>Vector Reduction</summary><blockquote>
<ul>
<li><code>cand(a)</code> - bitwise AND between all vector elements</li>
<li><code>cor(a)</code> - bitwise OR between all vector elements</li>
<li><code>cxor(a)</code> - bitwise XOR between all vector elements</li>
</ul>
</blockquote></details>
</details></blockquote>

<details>
<summary>Comparison</summary><blockquote>
<details>
<summary>Miscellaneous</summary><blockquote>
<ul>
<li><code>approx([floating point type] a, [floating point type] b)</code> - test for approximate equality</li>
<li><code>compareto(a, b)</code> - a == b => 0; a < b => -1, a > b => 1 (IComparable.CompareTo)</li>
<li><code>step(a, b)</code> - a >= b ? 1 : 0</li>
<li><code>ispow2(a)</code></li>
<li><code>isnan(a)</code></li>
<li><code>isinf(a)</code></li>
<li><code>isfinite(a)</code></li>
<li><code>isnormal(a)</code></li>
<li><code>issubnormal(a)</code></li>
<li><code>indexof([vector type] a, [scalar type] b)</code></li>
<li><code>isinrange(a, b, c)</code> - test whether a lies in [b, c]</li>
</ul>
</blockquote></details>
<details>
  
<summary>Selection</summary><blockquote>
<ul>
<li><code>min(a)</code></li>
<li><code>max(a)</code></li>
<li><code>minmax(a, out b, out c)</code> - minimum and maximum value as out parameters</li>
<li><code>minmag(a)</code> - minimum value with regards to absolute magnitude</li>
<li><code>maxmag(a)</code> - maximum value with regards to absolute magnitude</li>
<li><code>minmaxmag(a, out b, out c)</code> - minimum and maximum value with regards to absolute magnitude as out parameters</li>
<li><code>clamp(a, b, c)</code></li>
<li><code>saturate(a)</code> - clamp within [0, 1]</li>
<li><code>select(a, b, [boolean type] c)</code> - select between a and b based on c</li>
<li><code>select(a, b, [scalar integer] c)</code> - select between a and b based on bitmask c</li>
<li><code>negateif(a, [boolean type] c)</code> - negate a if c is true</li>
</ul>
</blockquote></details>

<details>
<summary>Vector Evaluation</summary><blockquote>
<ul>
<li><code>all([numeric type] a)</code> - test whether all values are non-zero</li>
<li><code>all([boolean type] a)</code> - test whether all values are true</li>
<li><code>any([numeric type] a)</code> - test whether any value is non-zero</li>
<li><code>any([boolean type] a)</code> - test whether any value is true</li>
<li><code>all_dif(a, b)</code> - test whether a and b do not share any components with each other</li>
<li><code>all_dif(a)</code> - test whether all values in a are unique</li>
<li><code>all_eq(a)</code> - test whether all values are the same within a vector</li>
<li><code>count([boolean type] a)</code> - number of true values</li>
<li><code>first([boolean type] a)</code> - index of the first true value</li>
<li><code>last([boolean type] a)</code> - index of the last true value</li>
</ul>
</blockquote></details>

<details>
<summary>Vector Reduction</summary><blockquote>
<ul>
<li><code>cmin(a)</code> - minimum value in a vector</li>
<li><code>cmax(a)</code> - maximum value in a vector</li>
<li><code>cminmax(a, out b, out c)</code> - minimum and maximum values in a vector as out parameters</li>
<li><code>cminmag(a)</code> - minimum value with regards to absolute magnitude in a vector</li>
<li><code>cmaxmag(a)</code> - maximum value with regards to absolute magnitude in a vector</li>
<li><code>cminmaxmag(a, out b, out c)</code> - minimum and maximum values with regards to absolute magnitude in a vector as out parameters</li>
</ul>
</blockquote></details>
</details></blockquote>

<details>
<summary>Geometry</summary><blockquote>
<details>
  
<summary>Miscellaneous</summary><blockquote>
<ul>
<li><code>transform(a, MinMaxAABB aabb)</code></li>
<li><code>angle(a, b)</code> - unsigned angle between a and b in radians</li>
<li><code>angledelta(a, b)</code> - smallest difference of two angles in unsigned radians</li>
<li><code>angledeltasgn(a, b)</code> - smallest difference of two angles in signed radians</li>
<li><code>angledeltadeg(a, b)</code> - smallest difference of two angles in unsigned degrees</li>
<li><code>angledeltasgndeg(a, b)</code> - smallest difference of two angles in signed degrees</li>
<li><code>cross(a, b)</code></li>
<li><code>project(a)</code></li>
<li><code>projectsafe(a)</code></li>
<li><code>normalize(a)</code></li>
<li><code>normalizesafe(a)</code></li>
<li><code>length(a)</code></li>
<li><code>lengthsq(a)</code></li>
<li><code>distance(a, b)</code></li>
<li><code>distancesq(a, b)</code></li>
<li><code>reflect(a, b)</code></li>
<li><code>refract(a, b, c)</code></li>
<li><code>faceforward(a, b, c)</code> - flips a vector if the two other vectors are pointing in the same direction</li>
<li><code>orthonormal_basis(a, out b, out c)</code> </li>
<li><code>orthonormalize(a)</code> </li>
</ul>
</blockquote></details>

<details>
<summary>Trigonometry</summary><blockquote>
<ul>
<li><code>radians(a)</code></li>
<li><code>degrees(a)</code></li>
<li><code>sin(a)</code></li>
<li><code>cos(a)</code></li>
<li><code>sincos(a, out b, out c)</code></li>
<li><code>tan(a)</code></li>
<li><code>asin(a)</code></li>
<li><code>acos(a)</code></li>
<li><code>atan(a)</code></li>
<li><code>atan2(a, b)</code></li>
<li><code>sinh(a)</code></li>
<li><code>cosh(a)</code></li>
<li><code>tanh(a)</code></li>
<li><code>asinh(a)</code></li>
<li><code>acosh(a)</code></li>
<li><code>atanh(a)</code></li>
</ul>
</blockquote></details>

<details>
<summary>RigidTransform</summary><blockquote>
<ul>
<li><code>inverse(a)</code></li>
<li><code>mul(a, b)</code></li>
<li><code>rotate(a, b)</code></li>
<li><code>transform(a, b)</code></li>
</ul>
</blockquote></details>

<details>
<summary>AffineTransform</summary><blockquote>
<ul>
<li><code>decompose(a, out b, out c, out d)</code></li>
<li><code>inverse(a)</code></li>
<li><code>mul(a, b)</code></li>
<li><code>rotate(a, b)</code></li>
<li><code>transform(a, b)</code></li>
</ul>
</blockquote></details>

<details>
<summary>Quaternion</summary><blockquote>
<ul>
<li><code>conjugate(a)</code></li>
<li><code>inverse(a)</code></li>
<li><code>dot(a, b)</code></li>
<li><code>length(a)</code></li>
<li><code>lengthsq(a)</code></li>
<li><code>normalize(a)</code></li>
<li><code>normalizesafe(a)</code></li>
<li><code>exp(a)</code></li>
<li><code>unitexp(a)</code></li>
<li><code>log(a)</code></li>
<li><code>unitlog(a)</code></li>
<li><code>mul(a, b)</code></li>
<li><code>rotate(a, b)</code></li>
<li><code>slerp(a, b, c)</code></li>
<li><code>nlerp(a, b, c)</code></li>
<li><code>angle(a, b)</code></li>
<li><code>Euler(a, b)</code></li>
<li><code>EulerXYZ(a)</code></li>
<li><code>EulerXZY(a)</code></li>
<li><code>EulerYXZ(a)</code></li>
<li><code>EulerYZX(a)</code></li>
<li><code>EulerZXY(a)</code></li>
<li><code>EulerZYX(a)</code></li>
</ul>
</blockquote></details>
</details></blockquote>

<details>
<summary>Interpolation</summary><blockquote>
<ul>
<li><code>lerp(a, b, c)</code></li>
<li><code>unlerp(a, b, c)</code></li>
<li><code>remap(a, b, c, d, e)</code></li>
<li><code>pingpong(a, b)</code> - back and forth between 0 and b</li>
<li><code>repeat(a, b)</code> - loop between 0 and b</li>
<li><code>smoothlerp(a, b, c)</code> - cubic interpolation</li>
<li><code>smoothstep(a, b, c)</code> - hermite interpolation</li>
</ul>
</blockquote></details>

<details>
<summary>Matrix Operations</summary><blockquote>
<ul>
<li><code>determinant(a)</code></li>
<li><code>inverse(a)</code></li>
<li><code>fastinverse(a)</code></li>
<li><code>pseudoinverse(a)</code></li>
<li><code>transpose(a)</code></li>
<li><code>transform(a, b)</code></li>
<li><code>mul(a, b)</code> - all possible matrix multiplication operations between matrices and vectors</li>
<li><code>rotate(a, b)</code> - rotate a vector by a rotation matrix</li>
<li><code>mulScale(a, b)</code></li>
<li><code>scaleMul(a, b)</code></li>
<li><code>svdInverse(a)</code> - singular value decomposition (svd)</li>
<li><code>svdRotation(a)</code> - singular value decomposition (svd)</li>
</ul>
</blockquote></details>

<details>
<summary>Vector Shuffling</summary><blockquote>
<ul>
<li><code>compress([pointer] a, b, c, [boolean type] d)</code> - filter out disabled components and left-pack the remaining ones</li>
<li><code>reverse(a)</code></li>
<li><code>shuffle(a, [integer vector] b)</code> - shuffle a vector based on indices stored in order in b</li>
<li><code>shuffle(a, b, params [ShuffleComponent] c)</code> - shuffle two vectors together, selecting elements with ShuffleComponent arguments in order</li>
<li><code>vshl/vshr(a, [integer vector] b)</code> - similar to logical bitshifting where one bit corresponds to one vector element</li>
<li><code>vrol/vror(a, [integer vector] b)</code> - similar to bitwise rotation where one bit corresponds to one vector element</li>
</ul>
</blockquote></details>

<details>
<summary>Special Functions</summary><blockquote>
<ul>
<li><code>gamma(a)</code></li>
<li><code>erf(a)</code> - error function</li>
<li><code>erfc(a)</code> - complementary error function</li>
</ul>
</blockquote></details>

<details>
<summary>Type Conversion</summary><blockquote>
<ul>
<li><code>roundto[integer type]([floating point type] a)</code></li>
<li><code>truncto[integer type]([floating point type] a)</code></li>
<li><code>floorto[integer type]([floating point type] a)</code></li>
<li><code>ceilto[integer type]([floating point type] a)</code></li>
<li><code>to[numeric type]([boolean type] a)</code> - 0 or 1 based on the boolean argument (unsafe)</li>
<li><code>to[numeric type]safe([boolean type] a)</code> - 0 or 1 based on the boolean argument (safe)</li>
<li><code>to[boolean type]([numeric type] a)</code> - true or false based on whether the argument is 0 or 1 (unsafe)</li>
<li><code>to[boolean type]safe([numeric type] a)</code> - true or false based on whether the argument is 0 or not (safe)</li>
<li><code>to[floating point type]unsafe([integer type] a)</code> - unsafe, fast conversion of integer to floating point types based on optional `enum Promise` argument</li>
</ul>
</blockquote></details>

<details>
<summary>Noise</summary><blockquote>
<ul>
<li><code>noise.cellular(a)</code></li>
<li><code>noise.cellular2x2(a)</code></li>
<li><code>noise.cellular2x2x2(a)</code></li>
<li><code>noise.cnoise(a)</code> - perlin noise</li>
<li><code>noise.pnoise(a)</code> - periodic perlin noise</li>
<li><code>noise.snoise(a)</code> - simplex noise</li>
<li><code>noise.psrdnoise(a)</code> - periodic simplex noise with fixed gradients and analytical derivative</li>
<li><code>noise.psrnoise(a)</code> - periodic simplex noise with rotating gradients, but without the analytical derivative</li>
<li><code>noise.srdnoise(a)</code> - non-periodic simplex noise with rotating gradients and analytical derivative</li>
<li><code>noise.srnoise(a)</code> - non-periodic simplex noise with fixed gradients, without the analytical derivative</li>
</ul>
</blockquote></details>

# What Kind Of Performance To Expect

![alt text](https://i.imgur.com/Bi79n4Q.jpg)

MaxMath was designed with performance as a primary objective from the very beginning. While it started as an extension of Unity.Mathematics to cover every C# primitive type - including integer vectors, matrices, and numerous additional mathematical functions - it has since evolved into a complete rewrite and replacement of it.

The 1.x development cycle focused on vectorizing virtually every operation and mathematical function. 
The 2.x cycle introduced architecture-specific implementations with optimized instruction selection and fallbacks across multiple SIMD instruction sets, initially targeting x86 (AVX2 → AVX → SSE4 → SSE2) before expanding to ARM NEON. 
The current 3.x cycle removes fundamental limitations inherited from Unity.Mathematics, such as inefficient boolean vector representations (and non-vectorized or poorly-vectorized algorithms), by introducing native SIMD masks internally while preserving a familiar boolean vector API.

Performance work has been an ongoing effort throughout every release. Nearly every function and operator has undergone repeated optimization with an emphasis on minimizing latency, reducing instruction count and code size, and generating predictable machine code. Whenever practical, implementations are written directly with SIMD intrinsics to retain precise control over the generated assembly and avoid compiler-dependent code generation.

Many operations employ state-of-the-art algorithms drawn from academic literature, while others are based on novel implementations developed specifically for MaxMath to achieve exceptionally efficient SIMD execution. Combined with extensive architecture-specific specialization and years of iterative optimization, the result is a library essentially generating hand-written machine code out-of-the-box while remaining entirely accessible through a high-level C# API.


## Recommendations for Optimal Performance

- MaxMath uses [C# Dev Tools](https://github.com/MrUnbelievable92/C-Sharp-Dev-Tools) to provide DEBUG-build-only assertions that help catch programmer errors during development. These checks are semi-conservative but may cause the Burst Inspector to display significantly more generated code than will actually be emitted in release builds. This is primarily due to naïve assertion implementations (often extracting vector elements one at a time, performing scalar validation, and throwing exceptions on failure), which also causes Burst to include large code blocks from `BurstString.cs`. 
To inspect the actual release code generation, run performance benchmarks, or execute performance-critical editor code, these safety checks can be disabled via `Window` → `C# Dev Tools` → `Manage Safety Checks...` in the Unity Editor. 
It is strongly recommended to keep them enabled during normal development, as they protect against potentially severe programming errors - including memory corruption, infinite loops, Unity Editor crashes, and other subtle but difficult-to-diagnose bugs.
- It is recommended, just like with Unity.Mathematics, to use vector types that use up an entire SIMD register (128 and 256 bits, respectively). LLVM has a very hard time optimizing code which does not follow this recommendation
- Wherever possible, it is adviced not to declare boolean vectors as temporary variables on the stack. MaxMath uses a 1:1 representation of SIMD masks for boolean data in the form of `ref struct`s named `mask[BITS]x[COLUMNS]x[ROWS]`. They are implicitly convertible to and from boolean vectors and matrices and should therefore be invisible to the user and cannot leave the stack, so the expected behaviour from using the Unity.Mathematics and earlier MaxMath API is still guaranteed, yet converting to and from boolean types comes at a performance cost already present in both Unity.Mathematics (although rarer) and MaxMath. Since the mask types are `public` and have the exact same API as corresponding boolean types, you are free to use them instead, yet their obscurity through specialization opens up a larger surface area for programmer error.
- One of the core strengths of MaxMath is that it provides operations whose implementations are better than what a compiler can synthesize from primitive operators; prefer using dedicated MaxMath operations over composing equivalent expressions manually. Many functions map to specialized SIMD instructions or architecture-specific implementations that cannot be recognized reliably by Burst or LLVM. If you are able to exploit specialized SIMD instructions for mathematical algorithms, consider submitting the resulting code to MaxMath as a pull-request. Otherwise you are very much welcome to open a feature request via the issue tracker.

# Migrating from Unity.Mathematics
⚠️ Back up your project before migrating.

Although the migration is usually straightforward, some serialized values, especially vector fields in the Inspector, may need to be rechecked afterwards.

For most projects, a simple find-and-replace is enough: replace Unity.Mathematics with MaxMath.

Sub-namespaces were merged into MaxMath directly. After replacing Unity.Mathematics with MaxMath, replace:

`MaxMath.Geometry.Math` → `MaxMath.math`
and
`MaxMath.Geometry` → `MaxMath`

A number of types, members, and Unity.Mathematics.math functions have been marked as obsolete and may need small code adjustments during migration in order to avoid warnings and improve performance.

Vector fields are exposed as ref properties in MaxMath. This means you cannot take their address in an unsafe context, and you must initialize the vector before assigning to its components either directly or using the out keyword.
Because fields are no longer exposed directly, serialized Unity.Mathematics vector values shown in the Inspector may be invalidated during migration. MaxMath uses custom property serialization for these types.  

For best performance, avoid declaring `bool{X}` vectors directly, such as `bool3 cmp = myVec3a > myVec3b`. MaxMath uses optimized mask types behind the scenes. That code still works (bool vectors exist in MaxMath and are not marked as obsolete, all mask types are implicitly convertible to and from bool vectors and matrices, they retain the entire boolean vector API), and keeping it as-is does not hurt performance compared to Unity.Mathematics - this would simply be an additional, sometimes very relevant performance optimization.

If you encountered another required step during migration, please open an issue to report it.


# How To Install This Library

It is highly encouraged to use the Scoped Registries feature for installing MaxMath.

Installing using Scoped Registries:
- Open your Unity project.
- Go to Edit → Project Settings → Package Manager.
- Under Scoped Registries, click + to add a new registry.
- Enter the registry details:

<blockquote>
<ul>
<li>Name: MrUnbelievable</li>
<li>URL: https://registry.npmjs.org</li>
<li>Scopes: com.mrunbelievable</li>
</ul>
</blockquote>

- Click Save.
- Open Window → Package Manager.
- In the package list, select My Registries.
- Install MaxMath from the registry.

## Why use a scoped registry?
- Easy updates – Receive new versions directly through Unity’s Package Manager without manual downloads.
- Version management – Switch, lock, or roll back versions cleanly using Unity’s built-in tooling.
- Cleaner projects – No need to store package files inside your repository or project folder.
- Dependency resolution – Unity automatically handles dependencies and compatibility.
- Team-friendly – Everyone on the project uses the same source and versions with minimal setup.
- Faster setup – Install in a few clicks instead of manually importing or maintaining local packages.
- No IDE clutter – The package source code does not appear in your IDE, keeping your workspace focused on your own project code.

# Donations

If this repository has been valuable to your projects and you'd like to support my work, consider making a donation.

[![donateBTC](https://github.com/MrUnbelievable92/MaxMath/blob/master/donate_bitcoin.png)](https://raw.githubusercontent.com/MrUnbelievable92/MaxMath/master/bitcoin_address.txt)
[![donatePP](https://github.com/MrUnbelievable92/MaxMath/blob/master/donate_paypal.png)](https://www.paypal.com/donate/?hosted_button_id=MARSK3E7WZP9C)
